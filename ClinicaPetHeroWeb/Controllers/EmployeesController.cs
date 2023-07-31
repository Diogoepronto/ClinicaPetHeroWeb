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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _employeeRepository = employeeRepository;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }


        // #######################################
        // #                INDEX                #
        // #######################################

        // GET: Employees
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAll().OrderBy(e => e.FirstName).ThenBy(o => o.LastName));
        }


        // #########################################
        // #                DETAILS                #
        // #########################################

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        // ########################################
        // #                CREATE                #
        // ########################################

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var imagePath = string.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "employees");
                }

                var employee = _converterHelper.ToEmployee(model, imagePath, true);

                await _employeeRepository.CreateAsync(employee);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        // ######################################
        // #                EDIT                #
        // ######################################

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToEmployeeViewModel(employee);

            return View(model);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imagePath = model.ProfileImageUrl;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        imagePath = await _imageHelper.UploadImageAsync(model.ImageFile, "employees");
                    }

                    var employee = _converterHelper.ToEmployee(model, imagePath, false);

                    await _employeeRepository.UpdateAsync(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _employeeRepository.ExistsAsync(model.Id))
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

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeRepository.GetByIdAsync(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            
            await _employeeRepository.DeleteAsync(employee);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
