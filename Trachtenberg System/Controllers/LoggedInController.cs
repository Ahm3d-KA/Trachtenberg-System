using Microsoft.AspNetCore.Mvc;

namespace Trachtenberg_System.Controllers;

public class LoggedInController : Controller
{
    // GET
    public IActionResult Index(string loggedIn)
    {
        return View();
    }
}