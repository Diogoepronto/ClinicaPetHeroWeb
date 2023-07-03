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
    public class PetOwnersController : Controller
    {
        private readonly IPetOwnerRepository _petOwnerRepository;

        public PetOwnersController(
            IPetOwnerRepository petOwnerRepository)
        {
            _petOwnerRepository = petOwnerRepository;
        }


        // #######################################
        // #                INDEX                #
        // #######################################

        // GET: PetOwners
        public IActionResult Index()
        {
            return View(_petOwnerRepository.GetAll().OrderBy(o => o.FirstName).ThenBy(o => o.LastName));
        }

        // #########################################
        // #                DETAILS                #
        // #########################################

        // GET: PetOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _petOwnerRepository.GetByIdAsync(id.Value);

            if (petOwner == null)
            {
                return NotFound();
            }

            return View(petOwner);
        }

        // ########################################
        // #                CREATE                #
        // ########################################

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
        public async Task<IActionResult> Create(PetOwner petOwner)
        {
            if (ModelState.IsValid)
            {
                await _petOwnerRepository.CreateAsync(petOwner);

                return RedirectToAction(nameof(Index));
            }
            return View(petOwner);
        }


        // ######################################
        // #                EDIT                #
        // ######################################

        // GET: PetOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _petOwnerRepository.GetByIdAsync(id.Value);

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
        public async Task<IActionResult> Edit(int id, PetOwner petOwner)
        {
            if (id != petOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _petOwnerRepository.UpdateAsync(petOwner);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _petOwnerRepository.ExistsAsync(petOwner.Id))
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


        // ########################################
        // #                DELETE                #
        // ########################################

        // GET: PetOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petOwner = await _petOwnerRepository.GetByIdAsync(id.Value);
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
            var petOwner = await _petOwnerRepository.GetByIdAsync(id);

            await _petOwnerRepository.DeleteAsync(petOwner);

            return RedirectToAction(nameof(Index));
        }
    }
}
