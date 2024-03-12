using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using Trachtenberg_System.Areas.Identity.Data;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Controllers;

public class StatsController : Controller
{
    private readonly ILogger<PractiseController> _logger;
    private readonly ApplicationUserDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public StatsController(ILogger<PractiseController> logger, ApplicationUserDbContext db, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _db = db;
        _userManager = userManager; 
    }
    public IActionResult Index()
    {
        _db.SaveChanges();
        var userId = _userManager.GetUserId(HttpContext.User);
        var loggedInUser = _db.Users.Find(userId);
        var stats = _db.UserStats
            .Where(s => s.AccountName == loggedInUser.AccountName)
            .Select(s => s.NumberOfTestsCompleted);
        
        var userStats = loggedInUser.UserStats;
        
        // loggedInUser.UserStats.NumberOfTestsCompleted = 4;
        return View("Index", stats.FirstOrDefault());
    }
}
    
