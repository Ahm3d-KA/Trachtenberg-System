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
    private readonly UserManager<ApplicationUser> _userManager;
    

    public PractiseController(ILogger<PractiseController> logger, ApplicationUserDbContext db, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _db = db;
        _userManager = userManager;
    }
    
    private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
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
        
        // gets logged in user id
        var userId = _userManager.GetUserId(HttpContext.User);
        var loggedInUser = _db.Users.Find(userId);

        ResultsOutputModel resultsOutput = new ResultsOutputModel();
        resultsOutput.Result = theResults.Result;

        // checks to see if the model exists in the db to prevent null reference
        if (loggedInUser.UserStats == null)
        {
            loggedInUser.UserStats = new UserStatsModel();
        }
        
        // played one more game
        loggedInUser.UserStats.NumberOfTestsCompleted += 1;
        
         
        if (loggedInUser.HighScores == null)
        {
            loggedInUser.HighScores = new HighScoresModel();
        }
        
        // checks to see if the score is a new highscore
        if (loggedInUser.HighScores.MultiplicationEasyTestScore < theResults.Result)
        {
            // updates the highscore
            loggedInUser.HighScores.MultiplicationEasyTestScore = theResults.Result;
            // used to tell user it is a new highscore
            resultsOutput.HighScore = true;
        }
        _db.Update(loggedInUser);
        _db.SaveChanges();  

        // returns test results view with results obj
        return View("TestResults", resultsOutput);
    }
}
