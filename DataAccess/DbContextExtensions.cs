using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DbContextExtensions 
    { 
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "USA" },
                new Country { Id = 2, Name = "Japan" },
                new Country { Id = 3, Name = "Germany" },
                new Country { Id = 4, Name = "France" },
                new Country { Id = 5, Name = "Ukraine" }
            );
        }
        public static void SeedRegions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = 1, Name = "California", CountryId = 1 },
                new Region { Id = 2, Name = "Tokyo", CountryId = 2 },
                new Region { Id = 3, Name = "Berlin", CountryId = 3 },
                new Region { Id = 4, Name = "Paris", CountryId = 4 },
                new Region { Id = 5, Name = "Kyiv", CountryId = 5 },
                new Region { Id = 6, Name = "Lviv", CountryId = 5 },
                new Region { Id = 7, Name = "Rivne", CountryId = 5 }
            );
        }
        public static void SeedBrands(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Toyota" },
                new Brand { Id = 2, Name = "Ford" },
                new Brand { Id = 3, Name = "BMW" },
                new Brand { Id = 4, Name = "Renault" },
                new Brand { Id = 5, Name = "ZAZ" },
                new Brand { Id = 6, Name = "Opel" }
            );
        }
        public static void SeedCarTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarType>().HasData(
                new CarType { Id = 1, Name = "Sedan" },
                new CarType { Id = 2, Name = "SUV" },
                new CarType { Id = 3, Name = "Hatchback" },
                new CarType { Id = 4, Name = "Coupe" },
                new CarType { Id = 5, Name = "Convertible" }
            );
        }
        public static void SeedColors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Red" },
                new Color { Id = 2, Name = "Blue" },
                new Color { Id = 3, Name = "Black" },
                new Color { Id = 4, Name = "White" },
                new Color { Id = 5, Name = "Silver" }
            );
        }
        public static void SeedFuelTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelType>().HasData(
                new FuelType { Id = 1, Name = "Gasoline" },
                new FuelType { Id = 2, Name = "Diesel" },
                new FuelType { Id = 3, Name = "Electric" },
                new FuelType { Id = 4, Name = "Hybrid" }
            );
        }
        public static void SeedCars(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Model = "Camry",
                    BrandId = 1,
                    CarTypeId = 1,
                    ColorId = 1,
                    FuelTypeId = 1,
                    CountryId = 1,
                    RegionId = 1,
                    Description = "A reliable sedan.",
                    Price = 24000,
                    ImageUrl = @"https://imgd.aeplcdn.com/1920x1080/n/cw/ec/192443/camry-exterior-right-front-three-quarter-14.jpeg?isig=0&q=80&q=80"
                },
                new Car
                {
                    Id = 2,
                    Model = "F-150",
                    BrandId = 2,
                    CarTypeId = 2,
                    ColorId = 2,
                    FuelTypeId = 2,
                    CountryId = 1,
                    RegionId = 1,
                    Description = "A popular pickup truck.",
                    Price = 30000,
                    ImageUrl = @"https://d2v1gjawtegg5z.cloudfront.net/posts/preview_images/000/015/499/original/2024_Ford_F-150.jpg?1725030127"
                },
                new Car
                {
                    Id = 3,
                    Model = "X5",
                    BrandId = 3,
                    CarTypeId = 2,
                    ColorId = 3,
                    FuelTypeId = 4,
                    CountryId = 3,
                    RegionId = 3,
                    Description = "A luxury SUV.",
                    Price = 59999.99,
                    ImageUrl = @"https://cdn.riastatic.com/photosnewr/auto/newauto_landing_photos/bmw-x5__5102-1920x1080x90.jpg"
                },
                new Car
                {
                    Id = 4,
                    Model = "Clio",
                    BrandId = 4,
                    CarTypeId = 3,
                    ColorId = 4,
                    FuelTypeId = 1,
                    CountryId = 4,
                    RegionId = 4,
                    Description = "A compact hatchback.",
                    Price = 15000,
                    ImageUrl = @"https://upload.wikimedia.org/wikipedia/commons/c/c6/Renault_Clio_V_%282023%29_1X7A1577.jpg"
                },
                new Car
                {
                    Id = 5,
                    Model = "Sens",
                    BrandId = 5,
                    CarTypeId = 1,
                    ColorId = 5,
                    FuelTypeId = 1,
                    CountryId = 5,
                    RegionId = 5,
                    Description = "A budget-friendly sedan.",
                    Price = 7000,
                    ImageUrl = @"https://i.infocar.ua/i/12/707/1400x936.jpg"
                },
                new Car
                {
                    Id = 6,
                    Model = "Astra",
                    BrandId = 6,
                    CarTypeId = 3,
                    ColorId = 1,
                    FuelTypeId = 2,
                    CountryId = 5,
                    RegionId = 6,
                    Description = "A reliable hatchback.",
                    Price = 12000,
                    ImageUrl = @"https://www.automoli.com/common/vehicles/_assets/img/gallery/f129/opel-astra-k.jpg"
                },
                new Car
                {
                    Id = 7,
                    Model = "Corolla",
                    BrandId = 1,
                    CarTypeId = 1,
                    ColorId = 2,
                    FuelTypeId = 1,
                    CountryId = 2,
                    RegionId = 2,
                    Description = "A best-selling sedan.",
                    Price = 20000,
                    ImageUrl = @"https://upload.wikimedia.org/wikipedia/commons/0/06/2020_Toyota_Corolla_LE_standard_front%2C_5.25.19.jpg"
                }
            );
        }
        public static void SeedAll(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCountries();
            modelBuilder.SeedRegions();
            modelBuilder.SeedBrands();
            modelBuilder.SeedCarTypes();
            modelBuilder.SeedColors();
            modelBuilder.SeedFuelTypes();
            modelBuilder.SeedCars();
        }
    }
}
