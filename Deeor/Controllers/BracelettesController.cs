using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deeor.Data;
using Deeor.Models;

namespace Deeor.Controllers
{
    public class BracelettesController : Controller
    {
        private readonly DeeorContext _context;

        public BracelettesController(DeeorContext context)
        {
            _context = context;
        }

        // GET: Bracelettes
        public async Task<IActionResult> Index()
        {
              return _context.Bracelette != null ? 
                          View(await _context.Bracelette.ToListAsync()) :
                          Problem("Entity set 'DeeorContext.Bracelette'  is null.");
        }

        // GET: Bracelettes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bracelette == null)
            {
                return NotFound();
            }

            var bracelette = await _context.Bracelette
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bracelette == null)
            {
                return NotFound();
            }

            return View(bracelette);
        }

        // GET: Bracelettes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bracelettes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Material,Length,Beads,Color,ClassType,Price,Brand")] Bracelette bracelette)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bracelette);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bracelette);
        }

        // GET: Bracelettes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bracelette == null)
            {
                return NotFound();
            }

            var bracelette = await _context.Bracelette.FindAsync(id);
            if (bracelette == null)
            {
                return NotFound();
            }
            return View(bracelette);
        }

        // POST: Bracelettes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Material,Length,Beads,Color,ClassType,Price,Brand")] Bracelette bracelette)
        {
            if (id != bracelette.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bracelette);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BraceletteExists(bracelette.Id))
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
            return View(bracelette);
        }

        // GET: Bracelettes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bracelette == null)
            {
                return NotFound();
            }

            var bracelette = await _context.Bracelette
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bracelette == null)
            {
                return NotFound();
            }

            return View(bracelette);
        }

        // POST: Bracelettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bracelette == null)
            {
                return Problem("Entity set 'DeeorContext.Bracelette'  is null.");
            }
            var bracelette = await _context.Bracelette.FindAsync(id);
            if (bracelette != null)
            {
                _context.Bracelette.Remove(bracelette);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BraceletteExists(int id)
        {
          return (_context.Bracelette?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
