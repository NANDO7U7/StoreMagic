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
    public class VansController : Controller
    {
        private readonly StoreMagicContext _context;

        public VansController(StoreMagicContext context)
        {
            _context = context;
        }

        // GET: Vans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vans.ToListAsync());
        }

        // GET: Vans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vans = await _context.Vans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vans == null)
            {
                return NotFound();
            }

            return View(vans);
        }

        // GET: Vans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Disponibles")] Vans vans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vans);
        }

        // GET: Vans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vans = await _context.Vans.FindAsync(id);
            if (vans == null)
            {
                return NotFound();
            }
            return View(vans);
        }

        // POST: Vans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Disponibles")] Vans vans)
        {
            if (id != vans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VansExists(vans.Id))
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
            return View(vans);
        }

        // GET: Vans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vans = await _context.Vans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vans == null)
            {
                return NotFound();
            }

            return View(vans);
        }

        // POST: Vans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vans = await _context.Vans.FindAsync(id);
            _context.Vans.Remove(vans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VansExists(int id)
        {
            return _context.Vans.Any(e => e.Id == id);
        }
    }
}
