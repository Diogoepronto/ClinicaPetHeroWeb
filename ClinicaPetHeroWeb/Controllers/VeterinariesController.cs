using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaPetHeroWeb.Data;
using ClinicaPetHeroWeb.Data.Entities;
using ClinicaPetHeroWeb.Data.Repos;

namespace ClinicaPetHeroWeb.Controllers
{
    public class VeterinariesController : Controller
    {
        private readonly IVeterinaryRepository _veterinaryRepository;

        public VeterinariesController(IVeterinaryRepository veterinaryRepository)
        {
            _veterinaryRepository = veterinaryRepository;
        }


        // #######################################
        // #                INDEX                #
        // #######################################

        // GET: Veterinaries
        public IActionResult Index()
        {
            return View(_veterinaryRepository.GetAll().OrderBy(v => v.FirstName).ThenBy(o => o.LastName));
        }


        // #########################################
        // #                DETAILS                #
        // #########################################

        // GET: Veterinaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinary = await _veterinaryRepository.GetByIdAsync(id.Value);

            if (veterinary == null)
            {
                return NotFound();
            }

            return View(veterinary);
        }


        // ########################################
        // #                CREATE                #
        // ########################################

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
        public async Task<IActionResult> Create(Veterinary veterinary)
        {
            if (ModelState.IsValid)
            {
                await _veterinaryRepository.CreateAsync(veterinary);

                return RedirectToAction(nameof(Index));
            }

            return View(veterinary);
        }


        // ######################################
        // #                EDIT                #
        // ######################################

        // GET: Veterinaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinary = await _veterinaryRepository.GetByIdAsync(id.Value);

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
        public async Task<IActionResult> Edit(int id, Veterinary veterinary)
        {
            if (id != veterinary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _veterinaryRepository.UpdateAsync(veterinary);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _veterinaryRepository.ExistsAsync(veterinary.Id))
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


        // ########################################
        // #                DELETE                #
        // ########################################

        // GET: Veterinaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veterinary = await _veterinaryRepository.GetByIdAsync(id.Value);

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
            var veterinary = await _veterinaryRepository.GetByIdAsync(id);

            await _veterinaryRepository.DeleteAsync(veterinary);

            return RedirectToAction(nameof(Index));
        }
    }
}
