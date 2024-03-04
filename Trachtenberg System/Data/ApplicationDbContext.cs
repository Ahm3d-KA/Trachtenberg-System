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
    public DbSet<HighScoresClass> HighScores { get; set; }
}