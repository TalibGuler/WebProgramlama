using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoforunuSec.Data;
using SoforunuSec.Models;

namespace SoforunuSec.Controllers
{
    public class SoforController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public SoforController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Sofor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sofor.Include(s => s.Araba).Include(s => s.Dil).Include(s => s.Sehir).Include(s => s.Ulke);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sofor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Sofor
                .Include(s => s.Araba)
                .Include(s => s.Dil)
                .Include(s => s.Sehir)
                .Include(s => s.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sofor == null)
            {
                return NotFound();
            }

            return View(sofor);
        }

        // GET: Sofor/Create
        public IActionResult Create()
        {
            ViewData["arabaId"] = new SelectList(_context.Araba, "Id", "Marka");
            ViewData["dilId"] = new SelectList(_context.Dil, "Id", "dilAd");
            ViewData["sehirId"] = new SelectList(_context.Sehir, "Id", "sehirAd");
            ViewData["ulkeId"] = new SelectList(_context.Ulke, "Id", "ulkeAd");
            return View();
        }

        // POST: Sofor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,adSoyad,dogumTarihi,kazaSayisi,Cinsiyet,Fotograf,arabaId,dilId,ulkeId,sehirId")] Sofor sofor)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\Sofor");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                sofor.Fotograf = @"\images\Sofor\" + fileName + extension;

                _context.Add(sofor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["arabaId"] = new SelectList(_context.Araba, "Id", "Marka", sofor.arabaId);
            ViewData["dilId"] = new SelectList(_context.Dil, "Id", "dilAd", sofor.dilId);
            ViewData["sehirId"] = new SelectList(_context.Sehir, "Id", "sehirAd", sofor.sehirId);
            ViewData["ulkeId"] = new SelectList(_context.Ulke, "Id", "ulkeAd", sofor.ulkeId);
            return View(sofor);
        }

        // GET: Sofor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Sofor.FindAsync(id);
            if (sofor == null)
            {
                return NotFound();
            }
            ViewData["arabaId"] = new SelectList(_context.Araba, "Id", "Marka", sofor.arabaId);
            ViewData["dilId"] = new SelectList(_context.Dil, "Id", "dilAd", sofor.dilId);
            ViewData["sehirId"] = new SelectList(_context.Sehir, "Id", "sehirAd", sofor.sehirId);
            ViewData["ulkeId"] = new SelectList(_context.Ulke, "Id", "ulkeAd", sofor.ulkeId);
            return View(sofor);
        }

        // POST: Sofor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,adSoyad,dogumTarihi,kazaSayisi,Cinsiyet,Fotograf,arabaId,dilId,ulkeId,sehirId")] Sofor sofor)
        {
            if (id != sofor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sofor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoforExists(sofor.Id))
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
            ViewData["arabaId"] = new SelectList(_context.Araba, "Id", "Marka", sofor.arabaId);
            ViewData["dilId"] = new SelectList(_context.Dil, "Id", "dilAd", sofor.dilId);
            ViewData["sehirId"] = new SelectList(_context.Sehir, "Id", "sehirAd", sofor.sehirId);
            ViewData["ulkeId"] = new SelectList(_context.Ulke, "Id", "ulkeAd", sofor.ulkeId);
            return View(sofor);
        }

        // GET: Sofor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofor = await _context.Sofor
                .Include(s => s.Araba)
                .Include(s => s.Dil)
                .Include(s => s.Sehir)
                .Include(s => s.Ulke)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sofor == null)
            {
                return NotFound();
            }

            return View(sofor);
        }

        // POST: Sofor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sofor = await _context.Sofor.FindAsync(id);
            _context.Sofor.Remove(sofor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoforExists(int id)
        {
            return _context.Sofor.Any(e => e.Id == id);
        }
    }
}
