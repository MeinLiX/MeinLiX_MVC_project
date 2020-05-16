using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeinLiX;

namespace MeinLiX.Controllers
{
    public class GamesController : Controller
    {
        private readonly DB_ORGContext _context;

        public GamesController(DB_ORGContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Game.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.IdGame == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGame,GameName")] Game game)
        {
            var NameValid = _context.Game.AsNoTracking().Where(g => g.GameName.ToUpper() == game.GameName.ToUpper()).FirstOrDefault();
            if (NameValid != null)
            {
                ModelState.AddModelError("GameName", "Already added");
            }
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGame,GameName")] Game game)
        {
            if (id != game.IdGame)
            {
                return NotFound();
            }
            var NameValid = _context.Game.AsNoTracking().Where(g => g.GameName.ToUpper() == game.GameName.ToUpper() && g.IdGame != id).FirstOrDefault();
            if (NameValid != null)
            {
                ModelState.AddModelError("GameName", "Already added");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.IdGame))
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
            return View(game);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .FirstOrDefaultAsync(m => m.IdGame == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            try
            {
                _context.Game.Remove(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("GameName", "Can't be deleted!");
                return View(game);
            }
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.IdGame == id);
        }
    }
}
