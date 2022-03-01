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
    public class RentsController : Controller
    {
        private readonly StudentContext _context;

        public RentsController(StudentContext context)
        {
            _context = context;
        }

        // GET: Rents
        public async Task<IActionResult> Index()
        {
            var studentContext = _context.Rents.Include(r => r.Client).Include(r => r.CopyCar);
            return View(await studentContext.ToListAsync());
        }

        // GET: Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.Client)
                .Include(r => r.CopyCar)
                .FirstOrDefaultAsync(m => m.Id_wynajmu == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Rents/Create
        public IActionResult Create()
        {
            ViewData["Id_klienta"] = new SelectList(_context.Clients, "Id_klienta", "Nazwisko");
            ViewData["Nr_rej"] = new SelectList(_context.CopyCars, "Nr_rej", "Nr_rej");
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_wynajmu,Id_klienta,Nr_rej,Data_od,Data_do")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_klienta"] = new SelectList(_context.Clients, "Id_klienta", "Nazwisko", rent.Id_klienta);
            ViewData["Nr_rej"] = new SelectList(_context.CopyCars, "Nr_rej", "Nr_rej", rent.Nr_rej);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            ViewData["Id_klienta"] = new SelectList(_context.Clients, "Id_klienta", "Nazwisko", rent.Id_klienta);
            ViewData["Nr_rej"] = new SelectList(_context.CopyCars, "Nr_rej", "Nr_rej", rent.Nr_rej);
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_wynajmu,Id_klienta,Nr_rej,Data_od,Data_do")] Rent rent)
        {
            if (id != rent.Id_wynajmu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.Id_wynajmu))
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
            ViewData["Id_klienta"] = new SelectList(_context.Clients, "Id_klienta", "Nazwisko", rent.Id_klienta);
            ViewData["Nr_rej"] = new SelectList(_context.CopyCars, "Nr_rej", "Nr_rej", rent.Nr_rej);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.Client)
                .Include(r => r.CopyCar)
                .FirstOrDefaultAsync(m => m.Id_wynajmu == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.Id_wynajmu == id);
        }
    }
}
