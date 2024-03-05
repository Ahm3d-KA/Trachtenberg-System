using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trachtenberg_System.Models;

using Microsoft.AspNetCore.Identity;
using Trachtenberg_System.Areas.Identity.Data;
using Trachtenberg_System.Data;

namespace Trachtenberg_System.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        UserStatsModel statsObj = new UserStatsModel();
        return View(statsObj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(UserStatsModel statsObj)
    {
        _db.UserStats.Add(statsObj);
        _db.SaveChanges();
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}