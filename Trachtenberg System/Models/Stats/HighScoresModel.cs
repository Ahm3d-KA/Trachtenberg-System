using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Trachtenberg_System.Areas.Identity.Data;

namespace Trachtenberg_System.Models;

// stores the user's high scores for all kinds of tests
// one to one relationship with UserStatsModel
// dependent (child)
public class HighScoresModel
{
    public int Id { get; set; }
    // public string WebsiteUserId { get; set; }
    // public int WebsiteUserId { get; set; }
    // public WebsiteUser WebsiteUser { get; set; }

    public int MultiplicationEasyTestScore { get; set; } = 0;
    // stores id of corresponding user stats record
    // used as a reference by the database to travel to the user stats record
}