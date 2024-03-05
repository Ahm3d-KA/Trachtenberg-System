using Microsoft.EntityFrameworkCore;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Data;

// used to create, read, update and delete to the database
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    // represents the UserStats table in the TrachDb
    public DbSet<UserStatsModel> UserStats { get; set; }
    public DbSet<HighScoresModel> HighScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // applying constraints in userstatsmodel file
        modelBuilder.ApplyConfiguration(new UserStatsModelConfiguration());
        
        // builds relationship between UserStatsModel and HighScoresModel
        modelBuilder.Entity<UserStatsModel>()
            // indicates one-to-one relationship between HighScoreModel and UserStatsModel
            .HasOne(e => e.HighScore)
            .WithOne(e => e.UserStatsModel)
            // UserStatsModelId is the foreign key in the relationship
            .HasForeignKey<HighScoresModel>(e => e.UserStatsModelId)
            // every HighScoresModel must be associated with a UserStatsModel
            .IsRequired();
    }
}