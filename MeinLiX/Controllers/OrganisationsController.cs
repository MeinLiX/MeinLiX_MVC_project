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
    public class OrganisationsController : Controller
    {
        private readonly DB_ORGContext _context;

        public OrganisationsController(DB_ORGContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Sponsorship(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation.FindAsync(id);
            if (organisation == null)
            {
                return NotFound();
            }
            @ViewBag.organisationID = organisation.IdOrganisation;
            @ViewBag.organisationName = organisation.OrganisationName;
            var Sponsors = _context.ContractOrganisation.Where(o => o.IdOrganisation == id).Include(o => o.IdSponsorNavigation);
            return View(Sponsors);
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == 0)
                return RedirectToAction("Index", "Home");

            return View(await _context.Organisation.Include(o => o.IdRegionNavigation).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation
                .FirstOrDefaultAsync(m => m.IdOrganisation == id);
            if (organisation == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Subdivisions", new { id });
        }

        public IActionResult Create()
        {
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "RegionName");
            var org = new Organisation
            {
                OrganisationFoundation = DateTime.Today
            };
            return View(org);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrganisation,OrganisationName,IdRegion,OrganisationWebpage,OrganisationFoundation")] Organisation organisation)
        {
            if (organisation.OrganisationName != null)
            {
                var NameValid = _context.Organisation.Where(o => o.OrganisationName.ToUpper() == organisation.OrganisationName.ToUpper()).FirstOrDefault();
                if (NameValid != null)
                {
                    ModelState.AddModelError("OrganisationName", "Already taken!");
                }
            }
            if (organisation.OrganisationWebpage != null && !Regex.IsMatch(organisation.OrganisationWebpage, "(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$"))
            {
                ModelState.AddModelError("OrganisationWebpage", "Invalid link");
            }
            if (organisation.OrganisationFoundation > DateTime.Today)
            {
                ModelState.AddModelError("OrganisationFoundation", "Invalid date");
            }
            if (ModelState.IsValid)
            {
                _context.Add(organisation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "RegionName");
            return View(organisation);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation.FindAsync(id);
            if (organisation == null)
            {
                return NotFound();
            }
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "RegionName");
            return View(organisation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrganisation,OrganisationName,IdRegion,OrganisationWebpage,OrganisationFoundation")] Organisation organisation)
        {
            if (id != organisation.IdOrganisation)
            {
                return NotFound();
            }
            if (organisation.OrganisationName != null)
            {
                var NameValid = _context.Organisation.AsNoTracking().Where(o => o.OrganisationName.ToUpper() == organisation.OrganisationName.ToUpper() && o.IdOrganisation != id).FirstOrDefault();
                if (NameValid != null)
                {
                    ModelState.AddModelError("OrganisationName", "Already taken!");
                }
            }
            if (organisation.OrganisationWebpage != null && !Regex.IsMatch(organisation.OrganisationWebpage, "(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$"))
            {
                ModelState.AddModelError("OrganisationWebpage", "Invalid link");
            }
            if (organisation.OrganisationFoundation > DateTime.Today)
            {
                ModelState.AddModelError("OrganisationFoundation", "Invalid date");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organisation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganisationExists(organisation.IdOrganisation))
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
            ViewData["IdRegion"] = new SelectList(_context.Region, "IdRegion", "RegionName");
            return View(organisation);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation
                .FirstOrDefaultAsync(m => m.IdOrganisation == id);
            if (organisation == null)
            {
                return NotFound();
            }
            ViewBag.organisationId = organisation.IdOrganisation;
            return View(organisation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisation = await _context.Organisation.FindAsync(id); ;
            try
            {
                _context.Organisation.Remove(organisation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("OrganisationName", "Can't be deleted!");
                return View(organisation);
            }
        }

        public async Task<IActionResult> CreateContract(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var organisation_data = await _context.Organisation.FindAsync(id);
            if (organisation_data == null)
            {
                return NotFound();
            }
            ViewBag.organisationName = organisation_data.OrganisationName;
            ViewBag.organisationId = id;
            ViewData["Sponsors"] = new SelectList(_context.Sponsor, "IdSponsor", "SponsorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContract(int? id, [Bind("IdContract,IdSponsor,IdOrganisation,ContractValidUntil,ContractBalance")] ContractOrganisation contract)
        {
            if (id == null && id != contract.IdOrganisation)
            {
                return NotFound();
            }
            var organisation_data = await _context.Organisation.FindAsync(id);
            if (organisation_data == null)
            {
                return NotFound();
            }
            ViewBag.organisationName = organisation_data.OrganisationName;


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
                contract.IdOrganisation = id.GetValueOrDefault();
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction("Sponsorship", "Organisations", new { id });
            }
            ViewBag.organisationId = contract.IdOrganisation;
            ViewData["Sponsors"] = new SelectList(_context.Sponsor, "IdSponsor", "SponsorName", contract.IdSponsor);
            return View();
        }

        private bool OrganisationExists(int id)
        {
            return _context.Organisation.Any(e => e.IdOrganisation == id);
        }
    }
}
