using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MeinLiX.Controllers
{
    public class SQLController : Controller
    {
        private readonly DB_ORGContext _context;

        public SQLController(DB_ORGContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QueriesORG(IQueryable<Organisation> results)
        {
            return View(await results.ToListAsync());
        }
        public IActionResult Error(string Message)
        {
            ViewBag.Message = Message;
            return View();
        }
        public IActionResult Index(int? Query4, int? Query5)
        {
            ViewBag.Query4 = Query4;
            ViewBag.Query5 = Query5;
            var empty = new SelectList(new List<string> { "--Empty--" });
            var AnyOrg = _context.Organisation.Any();
            var AnyPlayer = _context.Player.Any();

            ViewBag.OrgIds = AnyOrg ? new SelectList(_context.Organisation, "IdOrganisation", "IdOrganisation") : empty;
            ViewBag.OrgNames = AnyOrg ? new SelectList(_context.Organisation, "OrganisationName", "OrganisationName") : empty;
            ViewBag.PlayerIds = AnyPlayer ? new SelectList(_context.Player, "IdPlayer", "IdPlayer") : empty;
            ViewBag.PlayerNicknames = AnyPlayer ? new SelectList(_context.Player, "PlayerNickname", "PlayerNickname") : empty;
            ViewBag.GameName = _context.Game.Any() ? new SelectList(_context.Game, "GameName", "GameName") : empty;
            ViewBag.Regions = _context.Region.Any() ? new SelectList(_context.Region, "RegionName", "RegionName") : empty;
            ViewBag.Sponsors = _context.Region.Any() ? new SelectList(_context.Sponsor, "SponsorName", "SponsorName") : empty;
            ViewBag.Events = _context.Event.Any() ? new SelectList(_context.Event, "EventName", "EventName") : empty;
            ViewBag.Symbol = new SelectList(new List<string> { ">", "<", ">=", "<=", "=" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries0(string Message1)
        {
            //LINq var result = await _context.Organisation.Where(o => o.OrganisationName.StartsWith(Message)).Include(o => o.IdRegionNavigation).ToListAsync();
            var result = _context.Organisation.FromSqlRaw($"SELECT * FROM [Organisation]  WHERE [Organisation].[organisation_name] Like '{Message1}%'");
            return View(await result.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries1(string Message1)
        {
            //LINq var result = await _context.Organisation.Where(o => o.OrganisationName.StartsWith(Message)).Include(o => o.IdRegionNavigation).ToListAsync();
            var result = _context.Player.FromSqlRaw($"SELECT * FROM Player WHERE Player.id_subdivision IN (SELECT Subdivision.id_subdivision FROM Subdivision Where Subdivision.id_organisation IN (SELECT Organisation.id_organisation FROM Organisation Where Organisation.organisation_name Like '{Message1}%'))").Include(o => o.IdSubdivisionNavigation);
            return View(await result.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries2([Bind("Symbol,Message")]string Symbol, string Message1)
        {
            if (new List<string> { ">", "<", ">=", "<=", "=" }.Where(o => o == Symbol).FirstOrDefault() == null)
            {
                return RedirectToAction("Error", new { Message = "Incorrect Symbol" });
            }
            var result = _context.Organisation.FromSqlRaw($"SELECT * FROM Organisation WHERE Organisation.id_organisation IN (SELECT Subdivision.id_organisation FROM Subdivision INNER JOIN Organisation ON Subdivision.id_organisation = Organisation.id_organisation GROUP BY Subdivision.id_organisation HAVING count(Subdivision.id_subdivision) {Symbol} (SELECT COUNT(Subdivision.id_subdivision)FROM Subdivision INNER JOIN Organisation ON Subdivision.id_organisation = Organisation.id_organisation WHERE Organisation.organisation_name = '{Message1}'))");
            return View(await result.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries3(string Message1)
        {
            var result = _context.Organisation.FromSqlRaw($"SELECT * FROM Organisation WHERE id_organisation IN (SELECT Subdivision.id_organisation FROM Subdivision Where Subdivision.id_game IN (SELECT Game.id_game FROM Game WHERE GAME.game_name like '{Message1}'))");
            return View(await result.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries4(string Message1)
        {
            var result = _context.Organisation.FromSqlRaw($"SELECT Count(id_organisation) as id_organisation FROM Organisation JOIN Region ON Organisation.id_region=Region.id_region WHERE Region.region_name='{Message1}'").Select(o => o.IdOrganisation);
            return RedirectToAction("Index", new { Query4 = await result.FirstOrDefaultAsync() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries5(string Message1)
        {
            var result = _context.ContractPlayer.FromSqlRaw($"SELECT SUM(CASE WHEN ContractPlayer.contract_balance IS NULL THEN 0 ELSE ContractPlayer.contract_balance END + CASE WHEN ContractEvent.contract_balance IS NULL THEN 0 ELSE ContractEvent.contract_balance END + CASE WHEN ContractOrganisation.contract_balance IS NULL THEN 0 ELSE ContractOrganisation.contract_balance END) as contract_balance from Sponsor Left JOIN ContractPlayer on ContractPlayer.id_sponsor=Sponsor.id_sponsor Left JOIN ContractEvent on ContractEvent.id_sponsor =Sponsor.id_sponsor Left JOIN ContractOrganisation on ContractOrganisation.id_sponsor=Sponsor.id_sponsor where sponsor_name='{Message1}'").Select(o => o.ContractBalance);
            return RedirectToAction("Index", new { Query5 = Decimal.ToInt32(await result.FirstOrDefaultAsync()) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries6(string Message1)
        {
            var result = _context.Event.FromSqlRaw($"Select distinct * From [Event] as E where E.event_name != '{Message1}' and not Exists(Select * from Sponsor join ContractEvent on Sponsor.id_sponsor = ContractEvent.id_sponsor join [Event] on ContractEvent.id_event = [Event].id_event where [Event].event_name = '{Message1}' and Sponsor.id_sponsor not in (select ContractEvent.id_sponsor from ContractEvent join [Event] on ContractEvent.id_event = [Event].id_event where [Event].id_event = E.id_event)); ");
            return View(await result.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries7(string Message1)
        {
            var result = _context.Player.FromSqlRaw($"Select distinct * From Player as P where P.player_nickname != '{Message1}' and not Exists((Select  Sponsor.id_sponsor from Sponsor join ContractPlayer on Sponsor.id_sponsor = ContractPlayer.id_sponsor join Player on ContractPlayer.id_player = Player.id_player where Player.player_nickname = P.player_nickname) EXCEPT(Select Sponsor.id_sponsor from Sponsor join ContractPlayer on Sponsor.id_sponsor = ContractPlayer.id_sponsor join Player on ContractPlayer.id_player = Player.id_player where Player.player_nickname = '{Message1}')) and not Exists((Select Sponsor.id_sponsor from Sponsor join ContractPlayer on Sponsor.id_sponsor = ContractPlayer.id_sponsor join Player on ContractPlayer.id_player = Player.id_player where Player.player_nickname = '{Message1}') EXCEPT(Select  Sponsor.id_sponsor from Sponsor join ContractPlayer on Sponsor.id_sponsor = ContractPlayer.id_sponsor join Player on ContractPlayer.id_player = Player.id_player where Player.player_nickname = P.player_nickname))").Include(o => o.IdSubdivisionNavigation);
            return View(await result.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Queries8(string Message1)
        {
            var result = _context.Organisation.FromSqlRaw($"select * from Organisation as O WHERE organisation_name = '{Message1}' and not exists((SELECT ContractOrganisation.id_sponsor from ContractOrganisation join Organisation on Organisation.id_organisation = ContractOrganisation.id_organisation where O.organisation_name = Organisation.organisation_name) EXCEPT(select id_sponsor from Sponsor)) and not exists((select id_sponsor from Sponsor) EXCEPT(SELECT ContractOrganisation.id_sponsor from ContractOrganisation join Organisation on Organisation.id_organisation = ContractOrganisation.id_organisation where O.organisation_name = Organisation.organisation_name)); ");
            return View(await result.ToListAsync());
        }



    }
}