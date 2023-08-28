using Microsoft.EntityFrameworkCore;
using Vac_T.Models;

namespace Vac_T.Contexts
{
    public class VacItContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<UserJobOffer> UserJobOffers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Vac!T; Trusted_Connection=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserJobOffer>()
                .HasOne(e => e.JobOffer)
                .WithMany()
                .HasForeignKey(e => e.JobOfferId)
                .OnDelete(DeleteBehavior.NoAction);
                
                ;

            modelBuilder.Entity<UserJobOffer>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }*/
    }
}
