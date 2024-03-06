using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trachtenberg_System.Areas.Identity.Data;
using Trachtenberg_System.Models;

namespace Trachtenberg_System.Areas.Identity.Data;

public class WebsiteUserDbContext : IdentityDbContext<WebsiteUser>
{
    public WebsiteUserDbContext(DbContextOptions<WebsiteUserDbContext> options)
        : base(options)
    {
    }
    // public DbSet<UserStatsModel> UserStats { get; set; }
    public DbSet<HighScoresModel> HighScores { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        // applying constraints in userstatsmodel file

        builder.Entity<WebsiteUser>()
            .HasOne(e => e.HighScoresRef)
            .WithOne(e => e.WebsiteUser)
            .HasForeignKey<HighScoresModel>(e => e.Id)
            .IsRequired();
        
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<WebsiteUser>
{
    public void Configure(EntityTypeBuilder<WebsiteUser> builder)
    {
        builder.Property(item => item.AccountName).HasMaxLength(100);
        builder.Property(item => item.AccountName).IsRequired();

    }
}