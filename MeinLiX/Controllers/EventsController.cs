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
    public class EventsController : Controller
    {
        private readonly DB_ORGContext _context;

        public EventsController(DB_ORGContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Sponsorship(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            @ViewBag.eventID = @event.IdEvent;
            @ViewBag.eventName = @event.EventName;
            var Sponsors = _context.ContractEvent.Where(o => o.IdEvent == id).Include(o => o.IdSponsorNavigation);
            return View(Sponsors);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.IdEvent == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEvent,EventName,EventLocation,EventWebpage,EventPrizeFund,EventStartDate")] Event @event)
        {
            if (@event.EventName != null && Regex.IsMatch(@event.EventName, "[^a-zA-Z0-9 ]"))
            {
                ModelState.AddModelError("EventName", "Invalid characters");
            }
            if (@event.EventPrizeFund < 0)
            {
                ModelState.AddModelError("EventPrizeFund", "Uncorrect Prize");
            }
            if (@event.EventStartDate < DateTime.Today)
            {
                ModelState.AddModelError("EventStartDate", "Invalid date");
            }
            if (@event.EventWebpage != null && !Regex.IsMatch(@event.EventWebpage, "(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$"))
            {
                ModelState.AddModelError("EventWebpage", "Invalid link");
            }
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEvent,EventName,EventLocation,EventWebpage,EventPrizeFund,EventStartDate")] Event @event)
        {
            if (id != @event.IdEvent)
            {
                return NotFound();
            }
            if (@event.EventName != null && Regex.IsMatch(@event.EventName, "[^a-zA-Z0-9 ]"))
            {
                ModelState.AddModelError("EventName", "Invalid characters");
            }
            if (@event.EventPrizeFund < 0)
            {
                ModelState.AddModelError("EventPrizeFund", "Uncorrect Prize");
            }
            if (@event.EventStartDate < DateTime.Today)
            {
                ModelState.AddModelError("EventStartDate", "Invalid date");
            }
            if (@event.EventWebpage != null && !Regex.IsMatch(@event.EventWebpage, "(http://www.|https://www.|http://|https://)?[a-z0-9]+([-.]{1}[a-z0-9]+)*.[a-z]{2,5}(:[0-9]{1,5})?(/.*)?$"))
            {
                ModelState.AddModelError("EventWebpage", "Invalid link");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.IdEvent))
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
            return View(@event);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Event
                .FirstOrDefaultAsync(m => m.IdEvent == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            try
            {
                _context.Event.Remove(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("EventName", "Can't be deleted!");
                return View(@event);
            }
        }

        public async Task<IActionResult> CreateContract(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var event_data = await _context.Event.FindAsync(id);
            if (event_data == null)
            {
                return NotFound();
            }
            ViewBag.eventName = event_data.EventName;

            ViewData["Sponsors"] = new SelectList(_context.Sponsor, "IdSponsor", "SponsorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContract(int? id, [Bind("IdContract,IdSponsor,IdEvent,ContractValidUntil,ContractBalance")] ContractEvent contract)
        {
            if (id == null && id != contract.IdEvent)
            {
                return NotFound();
            }
            var event_data = await _context.Event.FindAsync(id);
            if (event_data == null)
            {
                return NotFound();
            }
            ViewBag.eventName = event_data.EventName;


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
                contract.IdEvent = id.GetValueOrDefault();
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction("Sponsorship", "Events", new { id = id });
            }

            ViewData["Sponsors"] = new SelectList(_context.Sponsor, "IdSponsor", "SponsorName", contract.IdSponsor);
            return View();
        }


        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.IdEvent == id);
        }
    }
}
