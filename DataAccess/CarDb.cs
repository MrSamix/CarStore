using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CarDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = "Data Source=DESKTOP-3P42OP0\\SQLEXPRESS;Initial Catalog=CarStoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;";
            optionsBuilder.UseSqlServer(connStr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Region)
                .WithMany()
                .HasForeignKey(c => c.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.SeedAll();
        }
        public CarDb() : base() { }
        public CarDb(DbContextOptions<CarDb> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
