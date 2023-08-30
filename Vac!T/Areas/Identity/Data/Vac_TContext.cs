/*using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vac_T.Areas.Identity.Data;
using Vac_T.Models;

namespace Vac_T.Data;

public class Vac_TContext : IdentityDbContext<Vac_TUser>
{
    public Vac_TContext(DbContextOptions<Vac_TContext> options)
        : base(options)
    {
    }
    public DbSet<Vac_TUser> Users { get; set; }
    public DbSet<UserProfile> Profiles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<JobOffer> JobOffers { get; set; }
    public DbSet<UserJobOffer> UserJobOffers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

}
*/