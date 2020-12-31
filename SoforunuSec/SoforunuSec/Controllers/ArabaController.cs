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
    public class ArabaController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArabaController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Araba
        public async Task<IActionResult> Index()
        {
            return View(await _context.Araba.ToListAsync());
        }

        // GET: Araba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araba = await _context.Araba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (araba == null)
            {
                return NotFound();
            }

            return View(araba);
        }

        // GET: Araba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Araba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marka,Model,modelYılı,koltukSayisi,kmYakit,motorHacmi,Fotograf")] Araba araba)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\Araba");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                araba.Fotograf = @"\images\Araba\" + fileName + extension;

                _context.Add(araba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(araba);
        }

        // GET: Araba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araba = await _context.Araba.FindAsync(id);
            if (araba == null)
            {
                return NotFound();
            }
            return View(araba);
        }

        // POST: Araba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marka,Model,modelYılı,koltukSayisi,kmYakit,motorHacmi,Fotograf")] Araba araba)
        {
            if (id != araba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(araba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArabaExists(araba.Id))
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
            return View(araba);
        }

        // GET: Araba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var araba = await _context.Araba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (araba == null)
            {
                return NotFound();
            }

            return View(araba);
        }

        // POST: Araba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var araba = await _context.Araba.FindAsync(id);
            _context.Araba.Remove(araba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArabaExists(int id)
        {
            return _context.Araba.Any(e => e.Id == id);
        }
    }
}
