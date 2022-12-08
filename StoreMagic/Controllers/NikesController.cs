using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreMagic.Data;
using StoreMagic.Models;

namespace StoreMagic.Controllers
{
    public class NikesController : Controller
    {
        private readonly StoreMagicContext _context;

        public NikesController(StoreMagicContext context)
        {
            _context = context;
        }

        // GET: Nikes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nike.ToListAsync());
        }

        // GET: Nikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nike = await _context.Nike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nike == null)
            {
                return NotFound();
            }

            return View(nike);
        }

        // GET: Nikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Disponibles")] Nike nike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nike);
        }

        // GET: Nikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nike = await _context.Nike.FindAsync(id);
            if (nike == null)
            {
                return NotFound();
            }
            return View(nike);
        }

        // POST: Nikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Disponibles")] Nike nike)
        {
            if (id != nike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NikeExists(nike.Id))
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
            return View(nike);
        }

        // GET: Nikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nike = await _context.Nike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nike == null)
            {
                return NotFound();
            }

            return View(nike);
        }

        // POST: Nikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nike = await _context.Nike.FindAsync(id);
            _context.Nike.Remove(nike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NikeExists(int id)
        {
            return _context.Nike.Any(e => e.Id == id);
        }
    }
}
