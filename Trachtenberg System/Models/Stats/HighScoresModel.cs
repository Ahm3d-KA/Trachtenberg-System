using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trachtenberg_System.Models;

// stores the user's high scores for all kinds of tests
// one to one relationship with UserStatsModel
// dependent (child)
public class HighScoresModel
{
    public int Id { get; set; }
    public int MultiplicationEasyTestScore { get; set; }
    // stores id of corresponding user stats record
    public int UserStatsModelId { get; set; }
    // used as a reference by the database to travel to the user stats record
    public UserStatsModel UserStatsModel { get; set; } = null!;
}