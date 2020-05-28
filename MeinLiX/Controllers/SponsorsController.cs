using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeinLiX;
using System.Text.RegularExpressions;
using System.Diagnostics.Contracts;

namespace MeinLiX.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly DB_ORGContext _context;

        public SponsorsController(DB_ORGContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(uint? id)
        {
            if (id == null)
                return View(await _context.Sponsor.ToListAsync());
            else if (id == 0)
                return RedirectToAction("Index", "Home");
            return View(await _context.Sponsor.ToListAsync());
        }



        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = _context.Sponsor
                .FirstOrDefault(m => m.IdSponsor == id);
            if (sponsor == null)
            {
                return NotFound();
            }
            ViewBag.SponsorName = sponsor.SponsorName;
            ViewBag.OrganisationsCount = _context.ContractOrganisation.Where(contract => contract.IdSponsor == sponsor.IdSponsor).Count();
            ViewBag.PlayersCount = _context.ContractPlayer.Where(contract => contract.IdSponsor == sponsor.IdSponsor).Count();
            ViewBag.EventsCount = _context.ContractEvent.Where(contract => contract.IdSponsor == sponsor.IdSponsor).Count();

            var contractOrg = _context.ContractOrganisation.Where(o => o.IdSponsor == sponsor.IdSponsor).Include(o => o.IdOrganisationNavigation).Select(o => o.IdOrganisationNavigation.OrganisationName);
            List<SelectListItem> listORG = new List<SelectListItem>();
            foreach (var name in contractOrg)
                listORG.Add(new SelectListItem() { Text = name, Value = name });
            ViewBag.Organisations = new SelectList(listORG, "Value", "Text");

            var contractPL = _context.ContractPlayer.Where(o => o.IdSponsor == sponsor.IdSponsor).Include(o => o.IdPlayerNavigation).Select(o => o.IdPlayerNavigation.PlayerNickname);
            List<SelectListItem> listPL = new List<SelectListItem>();
            foreach (var name in contractPL)
                listPL.Add(new SelectListItem() { Text = name, Value = name });
            ViewBag.Players = new SelectList(listPL, "Value", "Text");

            var contractEV = _context.ContractEvent.Where(o => o.IdSponsor == sponsor.IdSponsor).Include(o => o.IdEventNavigation).Select(o => o.IdEventNavigation.EventName);
            List<SelectListItem> listEV = new List<SelectListItem>();
            foreach (var name in contractEV)
                listEV.Add(new SelectListItem() { Text = name, Value = name });
            ViewBag.Events = new SelectList(listEV, "Value", "Text");


            @ViewBag.SponsorId = sponsor.IdSponsor;
            return View();
        }

        public IActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSponsor,SponsorName,SponsorWebpage,SponsorFoundation")] Sponsor sponsor)
        {
            if (!Regex.IsMatch(sponsor.SponsorWebpage, "(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$"))
            {
                ModelState.AddModelError("SponsorWebpage", "Invalid link");
            }
            if (sponsor.SponsorFoundation > DateTime.Today)
            {
                ModelState.AddModelError("SponsorFoundation", "Invalid date");
            }
            if (ModelState.IsValid)
            {
                _context.Add(sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor.FindAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return View(sponsor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSponsor,SponsorName,SponsorWebpage,SponsorFoundation")] Sponsor sponsor)
        {
            if (id != sponsor.IdSponsor)
            {
                return NotFound();
            }
            if (!Regex.IsMatch(sponsor.SponsorWebpage, "(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$"))
            {
                ModelState.AddModelError("SponsorWebpage", "Invalid link");
            }
            if (sponsor.SponsorFoundation > DateTime.Today)
            {
                ModelState.AddModelError("SponsorFoundation", "Invalid date");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorExists(sponsor.IdSponsor))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sponsor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsor = await _context.Sponsor
                .FirstOrDefaultAsync(m => m.IdSponsor == id);
            if (sponsor == null)
            {
                return NotFound();
            }

            return View(sponsor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsor = await _context.Sponsor.FindAsync(id);
            try
            {
                _context.Sponsor.Remove(sponsor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("SponsorName", "Can't be deleted!");
                return View(sponsor);
            }
        }

        private bool SponsorExists(int id)
        {
            return _context.Sponsor.Any(e => e.IdSponsor == id);
        }
    }
}
