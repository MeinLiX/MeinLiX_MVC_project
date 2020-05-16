using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeinLiX;
using Microsoft.CodeAnalysis;

namespace MeinLiX.Controllers
{
    public class SubdivisionsController : Controller
    {
        private readonly DB_ORGContext _context;

        public SubdivisionsController(DB_ORGContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.organisationNAME = "ALL";
            if (id == null)
            {
                var dB_ORGContext = _context.Subdivision.Include(p => p.IdOrganisationNavigation).Include(s => s.IdGameNavigation);
                return View(await dB_ORGContext.ToListAsync());
            }
            else if (id == 0)
                return RedirectToAction("Index", "Home");

            var organisation_data = await _context.Organisation.FindAsync(id);
            if (organisation_data == null)
            {
                return NotFound();
            }
            ViewBag.organisationNAME = organisation_data.OrganisationName;
            ViewBag.organisationID = organisation_data.IdOrganisation;
            var dB_ORGContext_ = _context.Subdivision.Where(b => b.IdOrganisation == id).Include(s => s.IdOrganisationNavigation).Include(s => s.IdGameNavigation);
            return View(await dB_ORGContext_.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var subdivision = await _context.Subdivision
                .Include(s => s.IdOrganisationNavigation)
                .FirstOrDefaultAsync(m => m.IdSubdivision == id);

            if (subdivision == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index", "Players", new { id });
        }

        public async Task<IActionResult> Create(int? id)
        {
            ViewData["IdGame"] = new SelectList(_context.Game, "IdGame", "GameName");
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "IdOrganisation", "OrganisationName", id);
            var org = await _context.Organisation.FindAsync(id);
            var sub = new Subdivision();
            if (org != null) sub.IdOrganisation = org.IdOrganisation;
            sub.SubdivisionFoundation = DateTime.Today;
            return View(sub);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubdivision,IdOrganisation,SubdivisionName,SubdivisionFoundation,IdGame")] Subdivision subdivision)
        {

            var organisation_data = await _context.Organisation.FindAsync(subdivision.IdOrganisation);
            if (subdivision.SubdivisionFoundation < organisation_data.OrganisationFoundation)
            {
                ModelState.AddModelError("SubdivisionFoundation", "Invalid date");
            }
            if (subdivision.SubdivisionFoundation > DateTime.Today)
            {
                ModelState.AddModelError("SubdivisionFoundation", "Invalid date");
            }
            var NameValid = _context.Subdivision.Where(s => s.IdOrganisation == subdivision.IdOrganisation && s.IdGame == subdivision.IdGame).FirstOrDefault();
            if (NameValid != null)
            {
                ModelState.AddModelError("IdGame", "Already created");
            }
            if (ModelState.IsValid)
            {
                var game_data = await _context.Game.FindAsync(subdivision.IdGame);
                subdivision.SubdivisionName = organisation_data.OrganisationName + " - " + game_data.GameName;
                _context.Add(subdivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = subdivision.IdOrganisation });
            }
            ViewData["IdGame"] = new SelectList(_context.Game, "IdGame", "GameName", subdivision.IdGame);
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "IdOrganisation", "OrganisationName", subdivision.IdOrganisation);
            return View(subdivision);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivision.FindAsync(id);
            if (subdivision == null)
            {
                return NotFound();
            }
            ViewData["IdGame"] = new SelectList(_context.Game, "IdGame", "GameName", subdivision.IdGame);
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "IdOrganisation", "OrganisationName", subdivision.IdOrganisation);
            return View(subdivision);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubdivision,IdOrganisation,SubdivisionName,SubdivisionFoundation,IdGame")] Subdivision subdivision)
        {
            if (id != subdivision.IdSubdivision)
            {
                return NotFound();
            }
            var organisation_data = await _context.Organisation.FindAsync(subdivision.IdOrganisation);
            if (subdivision.SubdivisionFoundation < organisation_data.OrganisationFoundation)
            {
                ModelState.AddModelError("SubdivisionFoundation", "Organisation has not been created in this date.");
            }
            if (subdivision.SubdivisionFoundation > DateTime.Today)
            {
                ModelState.AddModelError("SubdivisionFoundation", "Invalid date");
            }
            var NameValid = _context.Subdivision.Where(s => s.IdOrganisation == subdivision.IdOrganisation && s.IdGame == subdivision.IdGame).FirstOrDefault();
            if (NameValid != null)
            {
                ModelState.AddModelError("IdGame", "Already created");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var game_data = await _context.Game.FindAsync(subdivision.IdGame);
                    subdivision.SubdivisionName = organisation_data.OrganisationName + " - " + game_data.GameName;
                    _context.Update(subdivision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubdivisionExists(subdivision.IdSubdivision))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = subdivision.IdOrganisation });
            }
            ViewData["IdGame"] = new SelectList(_context.Game, "IdGame", "GameName", subdivision.IdGame);
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "IdOrganisation", "OrganisationName", subdivision.IdOrganisation);
            return View(subdivision);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _context.Subdivision
                .Include(s => s.IdGameNavigation)
                .Include(s => s.IdOrganisationNavigation)
                .FirstOrDefaultAsync(m => m.IdSubdivision == id);
            if (subdivision == null)
            {
                return NotFound();
            }

            return View(subdivision);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subdivision = await _context.Subdivision.FindAsync(id);
            try
            {
                _context.Subdivision.Remove(subdivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = subdivision.IdOrganisation });
            }
            catch
            {
                ModelState.AddModelError("SubdivisionName", "Can't be deleted!");
                return View(subdivision);
            }
        }

        private bool SubdivisionExists(int id)
        {
            return _context.Subdivision.Any(e => e.IdSubdivision == id);
        }
    }
}
