using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trachtenberg_System.Areas.Identity.Data;

namespace Trachtenberg_System.Areas.Identity.Data;

public class WebsiteUserDbContext : IdentityDbContext<WebsiteUser>
{
    public WebsiteUserDbContext(DbContextOptions<WebsiteUserDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<WebsiteUser>
{
    public void Configure(EntityTypeBuilder<WebsiteUser> builder)
    {
        builder.Property(item => item.UserName).HasMaxLength(100);
        builder.Property(item => item.UserName).IsRequired();

    }
}