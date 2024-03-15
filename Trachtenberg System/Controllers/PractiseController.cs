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

    [NonAction]
    // FIX TIME LIMIT
    // makes timelimit and accuracy to numbers between 1 and 0, adds them together
    // then turns it into a number between 1 and 1000 taking into account difficulty
    public int CalculateStandardScore(int timeTaken, LengthEnum testLength, double accuracy, DifficultyEnum difficulty)
    {
        double difficultyModifier = 0;
        int timeLimit = 5;
        
        // uses length enum to determine an arbitrary time limit
        switch (testLength)
        {
            case LengthEnum.Short:
                timeLimit = 60;
                break;
            case LengthEnum.Medium:
                timeLimit = 120;
                break;
            case LengthEnum.Long:
                timeLimit = 180;
                break;
            case LengthEnum.Marathon:
                timeLimit = 240;
                break;
                
        }
        
        // prevents the time component from being negative and messing with calculations
        if (timeTaken > timeLimit)
        {
            timeTaken = timeLimit;
        }

        
        // multiply the difficultyModifier with intermediateScore so easier tests give lower scores
        switch (difficulty)
        {
            case DifficultyEnum.Easy:
                difficultyModifier = 0.7;
                break;
            case DifficultyEnum.Medium:
                difficultyModifier = 0.8;
                break;
            case DifficultyEnum.Hard:
                difficultyModifier = 0.9;
                break;
            case DifficultyEnum.Expert:
                difficultyModifier = 1;
                break;
            default:
                difficultyModifier = 1;
                break;
        }
        
        // makes the time a number between 0 and 1 with a higher number meaning a faster time
        double timeComponent = 1 - (((double)timeTaken / timeLimit));
        // makes the accuracy a number between 0 and 1 with a higher number meaning higher accuracy
        double accuracyComponent = accuracy / 100;
        
        // easier tests give users a lower score
        double intermediateScore = (timeComponent + accuracyComponent) * difficultyModifier;
        // scores is a whole number between 0 and 1000
        int standardisedScore = (int)(intermediateScore * 50 * 10);
        return standardisedScore;

    }

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
        theResults.TestLength = (LengthEnum)theResults.NumberOfQuestions;
        ResultsModel resultsOutput = new ResultsModel();
        
        // checks to see if values needed are in obj
        if (theResults.Result != null && theResults.NumberOfQuestions != null)
        {
            // Finds % score and rounds to 1 dp
            theResults.Accuracy = Math.Round(((double)theResults.Result / theResults.NumberOfQuestions * 100), 1);
            resultsOutput.StandardisedScore = CalculateStandardScore(theResults.TimeTaken, theResults.TestLength,
                theResults.Accuracy, theResults.Difficulty);
        }
        
        // gets logged in user id
        var userId = _userManager.GetUserId(HttpContext.User);
        var loggedInUser = _db.Users.Find(userId);

        resultsOutput.Result = theResults.Result;
        resultsOutput.Accuracy = theResults.Accuracy;
        resultsOutput.NumberOfQuestions = theResults.NumberOfQuestions;
        resultsOutput.TimeTaken = theResults.TimeTaken;
        
        
        // checks to see if the model exists in the db to prevent null reference
        if (loggedInUser.UserStats == null)
        {
            loggedInUser.UserStats = new UserStatsModel();
        }

        if (loggedInUser.UserStats.AccountName == null)
        {
            loggedInUser.UserStats.AccountName = loggedInUser.AccountName;
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
