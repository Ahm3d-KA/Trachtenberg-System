using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trachtenberg_System.Areas.Identity.Data;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Controllers;


public class PractiseController : Controller
{
    private readonly ILogger<PractiseController> _logger;
    private readonly ApplicationUserDbContext _db;
    private readonly UserManager<ApplicationUser> _userDb;
    

    public PractiseController(ILogger<PractiseController> logger, ApplicationUserDbContext db, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _db = db;
        _userDb = userManager;
    }
    // GET
    public IActionResult Index()
    {
        // creating an instance of the class
        PractiseModel objPractise = new PractiseModel();
        // passing the object to the front end
        return View(objPractise);
    }
    
    // INDEX - POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    // receives user form on test settings and sends to practise controller
    public IActionResult Index(PractiseModel objPractise)
    {
        return RedirectToAction("Session", "Practise", objPractise);
    }


    // SESSION - GET
    // method sends the test customisation settings to front end and renders view
    public IActionResult Session(PractiseModel objPractise)
    {
        // turns the object into a json string
        string jsonObjPractise = JsonConvert.SerializeObject(objPractise);
        CombinedPractiseResultsModel combinedModel = new CombinedPractiseResultsModel
        {
            Practise = jsonObjPractise,
            ResultObj = new ResultsModel()
        };
        // returns Session View with the json string to be used in Test class
        return View("Session", combinedModel);
    }
    
    [HttpGet]
    public IActionResult TestResults()
    {
        return View("TestResults");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    // SESSION - POST
    // receives results obj after user completes test and returns the test results view
    public IActionResult Session(ResultsModel theResults)
    {
        _db.SaveChanges();
        // take score out of results object and pass it in the results view
        // int score = theResults.Result;
        var anyUser = _db.Users.First();
        anyUser.HighScores = new HighScoresModel();
        anyUser.HighScores.MultiplicationEasyTestScore = 5;
        _db.Update(anyUser);
        _db.SaveChanges();

        var anotherUser = _userDb.Users.First();
        
        return View("TestResults", 5);
    }
}
