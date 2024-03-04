using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trachtenberg_System.Models;


public class HighScoresClass
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UserStatsModel")]
    public int UserStatsId { get; set; }
    public int MultiplicationEasyTest { get; set; }
}