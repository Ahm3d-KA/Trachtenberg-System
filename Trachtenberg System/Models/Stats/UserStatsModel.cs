using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Innofactor.EfCoreJsonValueConverter;
using Trachtenberg_System.Areas.Identity.Data;

namespace Trachtenberg_System.Models;


// stores all the user stats and information for each user
// one-to-one relationship with HighScoresModel which stores highscores
// principle (parent)
public class UserStatsModel
{
    public int Id { get; set; }
    public string? AccountName { get; set; }
    // used as a reference to travel to high score record
    public int NumberOfTestsCompleted { get; set; }
    public double AverageAccuracy { get; set; }
}

// allows me to configure how the database is built. E.g. if I have a complex database that I want stored in a specific way
public class UserStatsModelConfiguration : IEntityTypeConfiguration<UserStatsModel>
{
    public void Configure(EntityTypeBuilder<UserStatsModel> builder)
    {
       
    }
}