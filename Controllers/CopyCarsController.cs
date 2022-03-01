using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement21A2.Data;
using StudentManagement21A2.Models;

namespace StudentManagement21A2.Controllers
{
    public class CopyCarsController : Controller
    {
        private readonly StudentContext _context;

        public CopyCarsController(StudentContext context)
        {
            _context = context;
        }

        // GET: CopyCars
        public async Task<IActionResult> Index()
        {
            return View(await _context.CopyCars.ToListAsync());
        }

        // GET: CopyCars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copyCar = await _context.CopyCars
                .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.Nr_rej == id);
            if (copyCar == null)
            {
                return NotFound();
            }

            return View(copyCar);
        }

        // GET: CopyCars/Create
        public IActionResult Create()
        {
            ViewData["Id_auta"] = new SelectList(_context.Car, "Id_auta", "Model");
            return View();
        }

        // POST: CopyCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nr_rej,Id_auta")] CopyCar copyCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(copyCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_auta"] = new SelectList(_context.Car, "Id_auta", "Model", copyCar.Id_auta);
            return View(copyCar);
        }

        // GET: CopyCars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copyCar = await _context.CopyCars.FindAsync(id);
            if (copyCar == null)
            {
                return NotFound();
            }
            ViewData["Id_auta"] = new SelectList(_context.Car, "Id_auta", "Model", copyCar.Id_auta);
            return View(copyCar);
        }

        // POST: CopyCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nr_rej,Id_auta")] CopyCar copyCar)
        {
            if (id != copyCar.Nr_rej)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(copyCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CopyCarExists(copyCar.Nr_rej))
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
            ViewData["Id_auta"] = new SelectList(_context.Car, "Id_auta", "Model", copyCar.Id_auta);
            return View(copyCar);
        }

        // GET: CopyCars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copyCar = await _context.CopyCars
                  .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.Nr_rej == id);
            if (copyCar == null)
            {
                return NotFound();
            }

            return View(copyCar);
        }

        // POST: CopyCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var copyCar = await _context.CopyCars.FindAsync(id);
            _context.CopyCars.Remove(copyCar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CopyCarExists(string id)
        {
            return _context.CopyCars.Any(e => e.Nr_rej == id);
        }
    }
}
