using HospitalManagementProject.Data;
using HospitalManagementProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementProject.Controllers;

[Authorize]
public class Admin(ApplicationDbContext _dbContext) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var test = new AdminData();
        var totalDoctors = await _dbContext.Doctors.CountAsync();
        var totalpatients = await _dbContext.Patients.CountAsync();
        var totalinventory = await _dbContext.Inventories.CountAsync();
        var totalUser = totalDoctors + totalpatients;
        test.Pt = totalpatients;
        test.Dt = totalDoctors;
        test.Tt = totalUser;
        test.It = totalinventory;
        
        return View(test);
    }
}