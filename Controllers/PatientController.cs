using AspNetCoreHero.ToastNotification.Abstractions;
using HospitalManagementProject.DTO.PatientsDto;
using HospitalManagementProject.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HospitalManagementProject.Controllers
{
    [Authorize]
    public class PatientController(IPatient patientService,INotyfService notifyService) : Controller
    {
        // GET: PatientController

        public async Task<IActionResult> Index()
        {
            var patients = await patientService.GetAllAsync();
            return View(patients);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var patient = await patientService.GetByIdAsync(id);
            return View(patient);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePatientDto createEntity)
        {
            if (!ModelState.IsValid) return View(createEntity);
            var id = await patientService.AddAsync(createEntity);
            notifyService.Information("Patient Added Successfully ");
            return RedirectToAction("Index");
        }
        // GET: PatientController/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var isExistingPatient = await patientService.GetByIdAsync(id);
            var editPatientDto = new EditPatientDto(
                Id:isExistingPatient.Id,
                GivenName:isExistingPatient.GivenName,
                FamilyName:isExistingPatient.FamilyName,
                Sex:isExistingPatient.Sex,
                BloodGroups:isExistingPatient.BloodGroups,
                MaritalStatus:isExistingPatient.MaritalStatus,
                Address:isExistingPatient.Address,
                PhoneNumber:isExistingPatient.PhoneNumber,
                Email:isExistingPatient.Email               
                );
            return View(editPatientDto);
        }

        // POST: PatientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditPatientDto editPatient)
        {
               var value =  await patientService.UpdateAsync(editPatient);
               if (!value) return NotFound();
               notifyService.Information("Patient Edited Successfully");
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
         
                var value = await patientService.DeleteAsync(id);
                if (!value) return NotFound();
                notifyService.Success("Deleted Successfully");
                return RedirectToAction("Index");

        }
    }
}
