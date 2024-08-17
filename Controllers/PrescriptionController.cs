using AspNetCoreHero.ToastNotification.Abstractions;
using HospitalManagementProject.Data;
using HospitalManagementProject.DTO.PrescriptionDto;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers;
[Authorize]
public class PrescriptionController(IPrescription prescriptionService,INotyfService notifyService,ApplicationDbContext _context) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var prescription = await prescriptionService.GetAllAsync();
        return View(prescription);
    }
     public async Task<IActionResult> Detail(Guid id)
        {
            var prescription = await prescriptionService.GetByIdAsync(id);
            return View(prescription);
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
        public async Task<ActionResult> Create(CreatePrescriptionDto createEntity)
        {
            if (!ModelState.IsValid) return View(createEntity);
            var id = await prescriptionService.AddAsync(createEntity);
            notifyService.Information("Prescription Created Successfully" );
            return RedirectToAction("Index");
        }
        // GET: PatientController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var isExistingPrescription = await prescriptionService.GetByIdAsync(id);
            var editPatientDto = new EditPrescriptionDto(
                Id:isExistingPrescription.Id,
                Symptoms: isExistingPrescription.Symptoms,
                 Diagnosis:isExistingPrescription.Diagnosis,
                 Medications:isExistingPrescription.Medications,
                 Treatment:isExistingPrescription.Treatment,
                 Doctor:isExistingPrescription.Doctor.DoctorId,
                 Patient:isExistingPrescription.Patient.PatientId
                );
            return View(editPatientDto);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPrescriptionDto editPrescriptionDto)
        {
               var value =  await prescriptionService.UpdateAsync(editPrescriptionDto);
               if (!value) return NotFound();
               notifyService.Information("Prescription Edited Successfully");
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
         
                var value = await prescriptionService.DeleteAsync(id);
                if (!value) return NotFound();
                notifyService.Success("Deleted Successfully");
                return RedirectToAction("Index");

        }
}