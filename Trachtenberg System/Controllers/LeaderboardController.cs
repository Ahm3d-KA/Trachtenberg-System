using Microsoft.AspNetCore.Mvc;
using Trachtenberg_System.Areas.Identity.Data;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Controllers;

public class LeaderboardController : Controller
{
    private readonly ILogger<PractiseController> _logger;
    private readonly ApplicationUserDbContext _db;
    
    public LeaderboardController(ILogger<PractiseController> logger, ApplicationUserDbContext db)
    {
        _logger = logger;
        _db = db;
    }
    
    // GET: LeaderboardController
    public ActionResult Index()
    {
        // var highScoresList = from highScore in _db.HighScores select highScore orderby 
        // selects all the highscore records in the table and orders by MultiplicationEasyTestScore
        IEnumerable<HighScoresModel> highScoresList =
            _db.HighScores.OrderByDescending(highScore => highScore.MultiplicationEasyTestScore);
        // foreach (HighScoresModel highScore in highScoresList)
        // {
        //     var relatedUser = from user in _db.Users
        //         where _db.Users.FirstOrDefault(e => e.HighScores.Id == highScore.Id)
        //         select user;
        // }
        return View("Index", highScoresList);
        
    }

}

