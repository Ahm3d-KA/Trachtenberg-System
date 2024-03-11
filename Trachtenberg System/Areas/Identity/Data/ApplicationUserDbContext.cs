using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trachtenberg_System.Areas.Identity.Data;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Areas.Identity.Data;

public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationUserDbContext(DbContextOptions<ApplicationUserDbContext> options)
        : base(options)
    {
    }
    // public DbSet<UserStatsModel> UserStats { get; set; }
    public DbSet<HighScoresModel> HighScores { get; set; }
    public DbSet<ApplicationUser> ApplicationUsersTesting { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        // applying constraints in userstatsmodel file

        // builder.Entity<HighScoresModel>()
        //     .HasOne(e => e.ApplicationUser)
        //     .WithOne(e => e.HighScoresRef)
        //     .HasForeignKey<HighScoresModel>(e => e.ApplicationUserId)
        //     .IsRequired();



    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(item => item.AccountName).HasMaxLength(100);
        builder.Property(item => item.AccountName).IsRequired();

    }
}