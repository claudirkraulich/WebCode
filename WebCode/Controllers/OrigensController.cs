using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCode.Data;
using WebCode.Models;

namespace WebCode.Controllers
{
    public class OrigensController : Controller
    {
        private readonly WebCodeContext _context;

        public OrigensController(WebCodeContext context)
        {
            _context = context;
        }

        // GET: Origens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Origem.ToListAsync());
        }

        // GET: Origens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origem = await _context.Origem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origem == null)
            {
                return NotFound();
            }

            return View(origem);
        }

        // GET: Origens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Origens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Origem origem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(origem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origem);
        }

        // GET: Origens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origem = await _context.Origem.FindAsync(id);
            if (origem == null)
            {
                return NotFound();
            }
            return View(origem);
        }

        // POST: Origens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Origem origem)
        {
            if (id != origem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(origem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrigemExists(origem.Id))
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
            return View(origem);
        }

        // GET: Origens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origem = await _context.Origem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origem == null)
            {
                return NotFound();
            }

            return View(origem);
        }

        // POST: Origens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var origem = await _context.Origem.FindAsync(id);
            _context.Origem.Remove(origem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrigemExists(int id)
        {
            return _context.Origem.Any(e => e.Id == id);
        }
    }
}
