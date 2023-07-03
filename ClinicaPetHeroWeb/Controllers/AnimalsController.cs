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
    public class AnimalsController : Controller
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        
        // #######################################
        // #                INDEX                #
        // #######################################

        // GET: Animals
        public IActionResult Index()
        {
            return View(_animalRepository.GetAll().OrderBy(a => a.Name));
        }


        // #########################################
        // #                DETAILS                #
        // #########################################

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _animalRepository.GetByIdAsync(id.Value);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }


        // ########################################
        // #                CREATE                #
        // ########################################

        // GET: Animals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                await _animalRepository.CreateAsync(animal);

                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }


        // ######################################
        // #                EDIT                #
        // ######################################

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _animalRepository.GetByIdAsync(id.Value);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _animalRepository.UpdateAsync(animal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _animalRepository.ExistsAsync(animal.Id))
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
            return View(animal);
        }


        // ########################################
        // #                DELETE                #
        // ########################################

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _animalRepository.GetByIdAsync(id.Value);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);

            await _animalRepository.DeleteAsync(animal);

            return RedirectToAction(nameof(Index));
        }
    }
}
