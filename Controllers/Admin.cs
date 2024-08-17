using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers;

[Authorize]
public class Admin : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}