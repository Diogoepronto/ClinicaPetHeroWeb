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
    public class PetOwnersController : Controller
    {
        private readonly DataContext _context;

        public PetOwnersController(DataContext context)
        {
            _context = context;
        }

        // GET: PetOwners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Owners.ToListAsync());
        }

        // GET: PetOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        // GET: PetOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Gender,DateOfBirth,Address,City,State,PostalCode,Email,Phone")] PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petOwner);
        }

        // GET: PetOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _context.Owners.FindAsync(id);
            if (petOwner == null)
            {
                return NotFound();
            }
            return View(petOwner);
        }

        // POST: PetOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Gender,DateOfBirth,Address,City,State,PostalCode,Email,Phone")] PetOwner petOwner)
        {
            if (id != petOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetOwnerExists(petOwner.Id))
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
            return View(petOwner);
        }

        // GET: PetOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _context.Owners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        // POST: PetOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petOwner = await _context.Owners.FindAsync(id);
            _context.Owners.Remove(petOwner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetOwnerExists(int id)
        {
            return _context.Owners.Any(e => e.Id == id);
        }
    }
}
