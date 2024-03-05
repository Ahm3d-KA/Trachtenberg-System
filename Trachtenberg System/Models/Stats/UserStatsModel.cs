using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Innofactor.EfCoreJsonValueConverter;
namespace Trachtenberg_System.Models;


// stores all the user stats and information for each user
public class UserStatsModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [ForeignKey("HighScoresClass")]
    public int HighScoresId { get; set; }
    [Required]
    public string AccountName { get; set; }
    
}
    // public HighScoresClass? UserHighscores { get; set; }

// allows me to configure how the database is built. E.g. if I have a complex database that I want stored in a specific way
public class UserStatsModelConfiguration : IEntityTypeConfiguration<UserStatsModel>
{
    public void Configure(EntityTypeBuilder<UserStatsModel> builder)
    {
       
    }
}