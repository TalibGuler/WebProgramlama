using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoforunuSec.Data;
using SoforunuSec.Models;

namespace SoforunuSec.Controllers
{
    public class BizeUlasinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BizeUlasinController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BizeUlasin
        public async Task<IActionResult> Index()
        {
            return View(await _context.BizeUlasin.ToListAsync());
        }

        // GET: BizeUlasin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bizeUlasin = await _context.BizeUlasin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bizeUlasin == null)
            {
                return NotFound();
            }

            return View(bizeUlasin);
        }

        // GET: BizeUlasin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BizeUlasin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Mail,Telefon,Konum")] BizeUlasin bizeUlasin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bizeUlasin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bizeUlasin);
        }

        // GET: BizeUlasin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bizeUlasin = await _context.BizeUlasin.FindAsync(id);
            if (bizeUlasin == null)
            {
                return NotFound();
            }
            return View(bizeUlasin);
        }

        // POST: BizeUlasin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Mail,Telefon,Konum")] BizeUlasin bizeUlasin)
        {
            if (id != bizeUlasin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bizeUlasin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BizeUlasinExists(bizeUlasin.Id))
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
            return View(bizeUlasin);
        }

        // GET: BizeUlasin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bizeUlasin = await _context.BizeUlasin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bizeUlasin == null)
            {
                return NotFound();
            }

            return View(bizeUlasin);
        }

        // POST: BizeUlasin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bizeUlasin = await _context.BizeUlasin.FindAsync(id);
            _context.BizeUlasin.Remove(bizeUlasin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BizeUlasinExists(int id)
        {
            return _context.BizeUlasin.Any(e => e.Id == id);
        }
    }
}
