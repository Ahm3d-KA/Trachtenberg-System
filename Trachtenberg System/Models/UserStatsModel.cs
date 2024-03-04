using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trachtenberg_System.Models;

public struct Highscores
{
    public int MultiplicationEasyTest { get; set; }
}
// stores all the user stats and information for each user
public class UserStatsModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string AccountName { get; set; }
    [NotMapped]
    public Highscores UserHighscores { get; set; }
    
}