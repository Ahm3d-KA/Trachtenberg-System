using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trachtenberg_System.Models;

// stores the user's highscores for all kinds of tests
public class HighScoresModel
{
    [Key]
    // unique number that separates it from the other records in the database
    public int Id { get; set; }
    [ForeignKey("UserStatsModel")]
    // stores the id of the corresponding UserStats Id
    public int UserStatsId { get; set; }
    // stores score from this test
    public int MultiplicationEasyTestScore { get; set; }
}