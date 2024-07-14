using AspNetCoreHero.ToastNotification.Abstractions;
using HospitalManagementProject.DTO.DoctorsDto;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers;
[Authorize]
public class DoctorController(IDoctor doctorService,INotyfService notifyService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var doctors = await doctorService.GetAllAsync();
        return View(doctors);
    }
     public async Task<IActionResult> Detail(Guid id)
        {
            var doctors = await doctorService.GetByIdAsync(id);
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDoctorDto createEntity)
        {
            if (!ModelState.IsValid) return View(createEntity);
            var id = await doctorService.AddAsync(createEntity);
            notifyService.Information("Doctor Added Successfully with Id "+ id  );
            return RedirectToAction("Index");
        }
        // GET: PatientController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var isExistingDoctor = await doctorService.GetByIdAsync(id);
            var editPatientDto = new EditDoctorDto(
                Id:isExistingDoctor.Id,
                Firstname:isExistingDoctor.Firstname,
                LastName:isExistingDoctor.LastName,
                Speciality:isExistingDoctor.Speciality,
                PhoneNumber:isExistingDoctor.PhoneNumber
                );
            return View(editPatientDto);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDoctorDto editDoctor)
        {
               var value =  await doctorService.UpdateAsync(editDoctor);
               if (!value) return NotFound();
               notifyService.Information("Doctor Edited Successfully");
               return RedirectToAction("Index");

        }

        // GET: PatientController/Delete/5
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        // POST: PatientController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
         
                var value = await doctorService.DeleteAsync(id);
                if (!value) return NotFound();
                notifyService.Success("Deleted Successfully");
                return RedirectToAction("Index");

        }
}