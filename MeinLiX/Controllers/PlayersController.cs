using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeinLiX;
using System.Text.RegularExpressions;

namespace MeinLiX.Controllers
{
    public class PlayersController : Controller
    {
        private readonly DB_ORGContext _context;

        public PlayersController(DB_ORGContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Sponsorship(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player_data = await _context.Player.FindAsync(id);
            if (player_data == null)
            {
                return NotFound();
            }
            ViewBag.PlayerID = player_data.IdPlayer;
            ViewBag.PlayerNickName = player_data.PlayerNickname;
            ViewBag.subdivisionId = player_data.IdSubdivision;
            var Sponsors = _context.ContractPlayer.Where(o => o.IdPlayer == id).Include(o => o.IdSponsorNavigation);
            return View(Sponsors);
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.subdivisionNAME = "ALL";
            if (id == null)
            {
                var dB_ORGContext = _context.Player.Include(p => p.IdSubdivisionNavigation);
                return View(await dB_ORGContext.ToListAsync());
            }
            else if (id == 0)
            {
                var dB_ORGContext = _context.Player.Where(p => p.IdSubdivisionNavigation == null);
                return View(await dB_ORGContext.ToListAsync());
            }


            var subdivision_data = await _context.Subdivision.FindAsync(id);
            if (subdivision_data == null)
            {
                return NotFound();
            }
            ViewBag.subdivisionNAME = subdivision_data.SubdivisionName;
            ViewBag.subdivisionID = subdivision_data.IdSubdivision;
            var dB_ORGContext_ = _context.Player.Where(b => b.IdSubdivision == id).Include(p => p.IdSubdivisionNavigation);
            return View(await dB_ORGContext_.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player_data = await _context.Player
                .Include(p => p.IdSubdivisionNavigation)
                .FirstOrDefaultAsync(m => m.IdPlayer == id);

            if (player_data == null)
            {
                return NotFound();
            }
            ViewBag.subdivisionId = player_data.IdSubdivision;

            return View(player_data);
        }

        public IActionResult Create(int? id)
        {
            Player player_data = new Player
            {
                PlayerJoin = DateTime.Today,
                PlayerBirth = DateTime.MinValue,
                IdSubdivision = id
            };
            ViewData["IdSubdivision"] = new SelectList(_context.Subdivision, "IdSubdivision", "SubdivisionName", player_data.IdSubdivision);
            ViewBag.subdivisionId = player_data.IdSubdivision;
            //need add empty item
            return View(player_data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlayer,IdSubdivision,PlayerName,PlayerNickname,PlayerJoin,PlayerBirth")] Player player)
        {

            DateTime dateNow = DateTime.Today;
            int year = dateNow.Year - player.PlayerBirth.Year;
            if (dateNow.Month < player.PlayerBirth.Month ||
                (dateNow.Month == player.PlayerBirth.Month && dateNow.Day < player.PlayerBirth.Day)) year--;
            if (year < 16)
            {
                ModelState.AddModelError("PlayerBirth", "Too young, only 16+");
            }
            if (player.PlayerName != null && Regex.IsMatch(player.PlayerName, "[^a-zA-Z]"))
            {
                ModelState.AddModelError("PlayerName", "Invalid characters");
            }
            if (player.PlayerNickname != null && Regex.IsMatch(player.PlayerNickname, "[^a-zA-Z0-9]"))
            {
                ModelState.AddModelError("PlayerNickname", "Invalid characters");
            }
            var subdivision_data = await _context.Subdivision.FindAsync(player.IdSubdivision);

            if (subdivision_data != null && player.PlayerJoin < subdivision_data.SubdivisionFoundation)
            {
                ModelState.AddModelError("PlayerJoin", "Subdivision has not been created in this date.");
            }
            if (player.PlayerJoin > dateNow)
            {
                ModelState.AddModelError("PlayerJoin", "You from future?");
            }
            if (player.PlayerNickname != null)
            {
                var NameValid = _context.Player.Where(o => o.PlayerNickname.ToUpper() == player.PlayerNickname.ToUpper() && o.IdPlayer != player.IdPlayer).FirstOrDefault();
                if (NameValid != null)
                {
                    ModelState.AddModelError("PlayerNickname", "Nickname already used.");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Players", new { id = player.IdSubdivision });
            }
            ViewBag.subdivisionId = player.IdSubdivision;
            ViewData["IdSubdivision"] = new SelectList(_context.Subdivision, "IdSubdivision", "SubdivisionName", player.IdSubdivision);
            return View(player);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewBag.subdivisionId = player.IdSubdivision;
            ViewData["IdSubdivision"] = new SelectList(_context.Subdivision, "IdSubdivision", "SubdivisionName", player.IdSubdivision);
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlayer,IdSubdivision,PlayerName,PlayerNickname,PlayerJoin,PlayerBirth")] Player player)
        {
            if (id != player.IdPlayer && player.IdPlayer != id)
            {
                return NotFound();
            }

            DateTime dateNow = DateTime.Today;
            int year = dateNow.Year - player.PlayerBirth.Year;
            if (dateNow.Month < player.PlayerBirth.Month ||
                (dateNow.Month == player.PlayerBirth.Month && dateNow.Day < player.PlayerBirth.Day)) year--;
            if (year < 16)
            {
                ModelState.AddModelError("PlayerBirth", "Too young, only 16+");
            }
            if (player.PlayerName != null && Regex.IsMatch(player.PlayerName, "[^a-zA-Z]"))
            {
                ModelState.AddModelError("PlayerName", "Invalid characters");
            }
            if (player.PlayerNickname != null && Regex.IsMatch(player.PlayerNickname, "[^a-zA-Z0-9]"))
            {
                ModelState.AddModelError("PlayerNickname", "Invalid characters");
            }
            var subdivision_data = await _context.Subdivision.FindAsync(player.IdSubdivision);
            if (subdivision_data != null && player.PlayerJoin < subdivision_data.SubdivisionFoundation)
            {
                ModelState.AddModelError("PlayerJoin", "Subdivision has not been created in this date.");
            }
            if (player.PlayerJoin > dateNow)
            {
                ModelState.AddModelError("PlayerJoin", "You from future?");
            }
            if (player.PlayerNickname != null)
            {
                var NameValid = _context.Player.Where(o => o.PlayerNickname.ToUpper() == player.PlayerNickname.ToUpper() && o.IdPlayer != player.IdPlayer).FirstOrDefault();
                if (NameValid != null)
                {
                    ModelState.AddModelError("PlayerNickname", "Nickname already used.");
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.IdPlayer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Players", new { id = player.IdSubdivision });
            }
            ViewBag.subdivisionId = player.IdSubdivision;
            ViewData["IdSubdivision"] = new SelectList(_context.Subdivision, "IdSubdivision", "SubdivisionName", player.IdSubdivision);
            return View(player);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Player
                .Include(p => p.IdSubdivisionNavigation)
                .FirstOrDefaultAsync(m => m.IdPlayer == id);
            if (player == null)
            {
                return NotFound();
            }
            ViewBag.subdivisionId = player.IdSubdivision;

            return View(player);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Player.FindAsync(id);
            try
            {
                _context.Player.Remove(player);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Players", new { id = player.IdSubdivision });
            }
            catch
            {
                ModelState.AddModelError("PlayerName", "Can't be deleted!");
                return View(player);
            }
        }

        public async Task<IActionResult> CreateContract(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var player_data = await _context.Player.FindAsync(id);
            if (player_data == null)
            {
                return NotFound();
            }
            ViewBag.playerID = id;
            ViewBag.PlayerNickName = player_data.PlayerNickname;
            ViewData["Sponsors"] = new SelectList(_context.Sponsor, "IdSponsor", "SponsorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContract(int? id, [Bind("IdContract,IdSponsor,IdPlayer,ContractValidUntil,ContractBalance")] ContractPlayer contract)
        {

            if (id == null && id != contract.IdPlayer)
            {
                return NotFound();
            }
            var player_data = await _context.Player.FindAsync(id);
            if (player_data == null)
            {
                return NotFound();
            }
            ViewBag.PlayerNickName = player_data.PlayerNickname;

            if (contract.ContractBalance < 0)
            {
                ModelState.AddModelError("ContractBalance", "Can't be negative balance");
            }
            if (contract.ContractValidUntil < DateTime.Today)
            {
                ModelState.AddModelError("ContractValidUntil", "Invalid date");
            }
            if (ModelState.IsValid)
            {
                contract.IdPlayer = id.GetValueOrDefault();
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction("Sponsorship", "Players", new { id = contract.IdPlayer });
            }
            ViewBag.playerID = id;
            ViewData["Sponsors"] = new SelectList(_context.Sponsor, "IdSponsor", "SponsorName");
            return View();
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.IdPlayer == id);
        }
    }
}
