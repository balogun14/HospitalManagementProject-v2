using AspNetCoreHero.ToastNotification.Abstractions;
using HospitalManagementProject.Data;
using HospitalManagementProject.DTO.AppointmentsDto;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers;

[Authorize]
public class AppointmentController(IAppointment apppointmentService,INotyfService notifyService, ApplicationDbContext _context) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var appointments = await apppointmentService.GetAllAsync();
        return View(appointments);
    }
     public async Task<IActionResult> Detail(Guid id)
        {
            var appointments = await apppointmentService.GetByIdAsync(id);
            return View(appointments);
        }
        public IActionResult Create()
        {
            var patients = _context.Patients.Select(p => new { p.PatientId, FullName = p.FirstName + " " + p.LastName }).ToList();
            var doctors = _context.Doctors.Select(d => new { d.DoctorId, FullName = d.FirstName + " " + d.LastName }).ToList();

            ViewBag.Patients = patients;
            ViewBag.Doctors = doctors;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAppointmentDto createEntity)
        {
            if (!ModelState.IsValid) return View(createEntity);
            var id = await apppointmentService.AddAsync(createEntity);
            notifyService.Information("Appointment Created Successfully ");
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