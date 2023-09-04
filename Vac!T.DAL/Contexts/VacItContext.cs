using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vac_T.Areas.Identity.Data;
using Vac_T.Models;

namespace Vac_T.Contexts
{
    public class VacItContext : IdentityDbContext<Vac_TUser>
    {
        public VacItContext(DbContextOptions<VacItContext> options) : base(options) { }

        public DbSet<Vac_TUser> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<UserJobOffer> UserJobOffers { get; set; }



        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Vac!T; Trusted_Connection=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }


            /*modelBuilder.Entity<UserJobOffer>()
                .HasOne(e => e.JobOffer)
                .WithMany()
                .HasForeignKey(e => e.JobOfferId)
                .OnDelete(DeleteBehavior.NoAction);
                
                ;

            modelBuilder.Entity<UserJobOffer>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);*/
        
    }
}
