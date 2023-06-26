using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaPetHeroWeb.Data;
using ClinicaPetHeroWeb.Data.Entities;

namespace ClinicaPetHeroWeb.Controllers
{
    public class VeterinariesController : Controller
    {
        private readonly DataContext _context;

        public VeterinariesController(DataContext context)
        {
            _context = context;
        }

        // GET: Veterinaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Veterinaries.ToListAsync());
        }

        // GET: Veterinaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinary = await _context.Veterinaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinary == null)
            {
                return NotFound();
            }

            return View(veterinary);
        }

        // GET: Veterinaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veterinaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Specialty,Position,Id,FirstName,LastName,Gender,DateOfBirth,Address,City,State,PostalCode,Email,Phone")] Veterinary veterinary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veterinary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinary);
        }

        // GET: Veterinaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinary = await _context.Veterinaries.FindAsync(id);
            if (veterinary == null)
            {
                return NotFound();
            }
            return View(veterinary);
        }

        // POST: Veterinaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Specialty,Position,Id,FirstName,LastName,Gender,DateOfBirth,Address,City,State,PostalCode,Email,Phone")] Veterinary veterinary)
        {
            if (id != veterinary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veterinary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeterinaryExists(veterinary.Id))
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
            return View(veterinary);
        }

        // GET: Veterinaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinary = await _context.Veterinaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinary == null)
            {
                return NotFound();
            }

            return View(veterinary);
        }

        // POST: Veterinaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veterinary = await _context.Veterinaries.FindAsync(id);
            _context.Veterinaries.Remove(veterinary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinaryExists(int id)
        {
            return _context.Veterinaries.Any(e => e.Id == id);
        }
    }
}
