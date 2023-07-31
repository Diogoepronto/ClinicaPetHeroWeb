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
using ClinicaPetHeroWeb.Helpers;
using ClinicaPetHeroWeb.Models.Entities;

namespace ClinicaPetHeroWeb.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public AnimalsController(
            IAnimalRepository animalRepository,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _animalRepository = animalRepository;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
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
        public async Task<IActionResult> Create(AnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imagePath = string.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "animals");
                }

                var animal = _converterHelper.ToAnimal(model, imagePath, true);

                await _animalRepository.CreateAsync(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
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

            var model = _converterHelper.ToAnimalViewModel(animal);

            return View(model);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AnimalViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imagePath = model.AnimalImageUrl;

                    if(model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "animals");
                    }

                    var animal = _converterHelper.ToAnimal(model, imagePath, false);

                    await _animalRepository.UpdateAsync(animal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _animalRepository.ExistsAsync(model.Id))
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
            return View(model);
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
