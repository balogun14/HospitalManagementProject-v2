using HospitalManagementProject.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers;

public class PatientProfile(IPatient patientService) : Controller
{
    // GET
    public async Task<IActionResult> Profile(Guid id)
    {
        var patient = await patientService.GetByIdAsync(id);
        return View(patient);
    }
}