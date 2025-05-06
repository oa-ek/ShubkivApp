using Microsoft.EntityFrameworkCore;
using ShubkivApp.Models.Entity;

namespace ShubkivApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Guide> Guides => Set<Guide>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<TourProgram> TourPrograms => Set<TourProgram>();
        public DbSet<Day> Days => Set<Day>();
        public DbSet<Tour> Tours => Set<Tour>();
        public DbSet<TourClients> TourClients => Set<TourClients>();
        public DbSet<TourGuides> TourGuides => Set<TourGuides>();
        public DbSet<EventImage> EventImages => Set<EventImage>();
        public DbSet<TourImage> TourImages => Set<TourImage>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<CategoryProduct> CategoryProducts => Set<CategoryProduct>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TourGuides>()
                .HasOne(tg => tg.Tour)
                .WithMany(t => t.TourGuides)
                .HasForeignKey(tg => tg.TourId);

            modelBuilder.Entity<TourGuides>()
                .HasOne(tg => tg.Guide)
                .WithMany(g => g.TourGuides)
                .HasForeignKey(tg => tg.GuideId);

            modelBuilder.Entity<TourClients>()
                .HasKey(tc => tc.Id);

            modelBuilder.Entity<TourClients>()
                .HasOne(tc => tc.Tour)
                .WithMany(t => t.TourClients)
                .HasForeignKey(tc => tc.TourId);

            modelBuilder.Entity<TourClients>()
                .HasOne(tc => tc.Client)
                .WithMany(g => g.TourClients)
                .HasForeignKey(tc => tc.ClientId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Day)
                .WithMany(d => d.Events)
                .HasForeignKey(e => e.DayId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Day>()
                .HasOne(d => d.TourProgram)
                .WithMany(tp => tp.Days)
                .HasForeignKey(d => d.TourProgramId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
