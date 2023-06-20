using IManager.Models;
using Microsoft.EntityFrameworkCore;

namespace IManager
{
    public class AppDbContext : DbContext
    {
        public DbSet<InvItem> Products { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<LocationInvItem> LocationInvItems { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Location> Locations { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationInvItem>()
                .HasKey(lii => new { lii.LocationInvItemId });

            modelBuilder.Entity<LocationInvItem>()
                .HasOne(lii => lii.Location)
                .WithMany(l => l.LocationInvItems)
                .HasForeignKey(lii => lii.locationId);

            modelBuilder.Entity<LocationInvItem>()
                .HasOne(lii => lii.InvItem)
                .WithMany(i => i.LocationInvItems)
                .HasForeignKey(lii => lii.itemId);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=IManager.db";
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
