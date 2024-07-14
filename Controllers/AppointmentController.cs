using AspNetCoreHero.ToastNotification.Abstractions;
using HospitalManagementProject.DTO.AppointmentsDto;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers;

[Authorize]
public class AppointmentController(IAppointment apppointmentService,INotyfService notifyService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var prescription = await apppointmentService.GetAllAsync();
        return View(prescription);
    }
     public async Task<IActionResult> Detail(Guid id)
        {
            var prescription = await apppointmentService.GetByIdAsync(id);
            return View(prescription);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAppointmentDto createEntity)
        {
            if (!ModelState.IsValid) return View(createEntity);
            var id = await apppointmentService.AddAsync(createEntity);
            notifyService.Information("Appointment Created Successfully with id "+ id);
            return RedirectToAction("Index");
        }
        // GET: AppointmentController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var isExistingAppointment = await apppointmentService.GetByIdAsync(id);
            var editAppointmentDto = new EditAppointmentDto(
                 Id:isExistingAppointment.Id,
                 Title:isExistingAppointment.Title,
                 Notes:isExistingAppointment.Notes,
                 AppointmentTime:isExistingAppointment.AppointmentTime,
                 PatientId:isExistingAppointment.Patient.PatientId,
                 DoctorId:isExistingAppointment.Doctor.DoctorId
                );
            return View(editAppointmentDto);
        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditAppointmentDto editAppointmentDto)
        {
               var value =  await apppointmentService.UpdateAsync(editAppointmentDto);
               if (!value) return NotFound();
               notifyService.Information("Appointment Edited Successfully");
               return RedirectToAction("Index");
        }

        // GET: AppointmentController/Delete/5
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id)
        {
         
                var value = await apppointmentService.DeleteAsync(id);
                if (!value) return NotFound();
                notifyService.Success("Deleted Successfully");
                return RedirectToAction("Index");
        }
}