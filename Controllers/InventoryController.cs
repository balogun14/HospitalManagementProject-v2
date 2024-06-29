using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementProject.Controllers;

public class InventoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}