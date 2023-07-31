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
    public class VeterinariesController : Controller
    {
        private readonly IVeterinaryRepository _veterinaryRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public VeterinariesController(
            IVeterinaryRepository veterinaryRepository,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _veterinaryRepository = veterinaryRepository;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
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
        public async Task<IActionResult> Create(VeterinaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imagePath = string.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "veterinaries");
                }

                var veterinary = _converterHelper.ToVeterinary(model, imagePath, true);

                await _veterinaryRepository.CreateAsync(veterinary);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
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

            var model = _converterHelper.ToVeterinaryViewModel(veterinary);

            return View(model);
        }

        // POST: Veterinaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VeterinaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imagePath = model.ProfileImageUrl;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "veterinaries");
                    }

                    var veterinary = _converterHelper.ToVeterinary(model, imagePath, false);

                    await _veterinaryRepository.UpdateAsync(veterinary);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _veterinaryRepository.ExistsAsync(model.Id))
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
