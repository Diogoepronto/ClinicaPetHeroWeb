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
using ClinicaPetHeroWeb.Models.Entities;
using ClinicaPetHeroWeb.Helpers;

namespace ClinicaPetHeroWeb.Controllers
{
    public class PetOwnersController : Controller
    {
        private readonly IPetOwnerRepository _petOwnerRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public PetOwnersController(
            IPetOwnerRepository petOwnerRepository,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _petOwnerRepository = petOwnerRepository;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
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
        public async Task<IActionResult> Create(PetOwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imagePath = string.Empty;

                if(model.ImageFile != null && model. ImageFile.Length > 0)
                {
                    imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "petowners");
                }

                var petOwner = _converterHelper.ToPetOwner(model, imagePath, true);

                await _petOwnerRepository.CreateAsync(petOwner);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
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

            var model = _converterHelper.ToPetOwnerViewModel(petOwner);

            return View(model);
        }

        // POST: PetOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PetOwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imagePath = model.ProfileImageUrl;

                    if(model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "petowners");
                    }

                    var petOwner = _converterHelper.ToPetOwner(model, imagePath, false);

                    await _petOwnerRepository.UpdateAsync(petOwner);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await _petOwnerRepository.ExistsAsync(model.Id))
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
