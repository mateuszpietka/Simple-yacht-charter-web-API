using Microsoft.EntityFrameworkCore;
using YachtCharterWebApp.Core.Entities;

namespace YachtCharterWebApp.Infrastructure.Context
{
    public class YachtsAppDbContext : DbContext
    {
        public YachtsAppDbContext(DbContextOptions<YachtsAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Yacht> Yachts { get; set; }
        public DbSet<YachtType> YachtTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Yacht>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Yacht>()
                .Property(r => r.HomePort)
                .HasMaxLength(30);

            modelBuilder.Entity<Yacht>()
                .Property(r => r.Description)
                .HasMaxLength(1000);

            modelBuilder.Entity<YachtType>()
                .Property(r => r.TypeDescription)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Reservation>()
                .Property(x => x.StartDate)
                .IsRequired();

            modelBuilder.Entity<Reservation>()
                .Property(x => x.EndDate)
                .IsRequired();
        }
    }
}
