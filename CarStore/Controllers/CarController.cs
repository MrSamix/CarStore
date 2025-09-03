using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarStore.Controllers
{
    public class CarController : Controller
    {
        CarDb db;
        public CarController(CarDb db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Cars.Include(c => c.Brand).ToList());
        }
        public IActionResult Details(int id)
        {
            var Car = GetCars().FirstOrDefault(c => c.Id == id);
            if (Car == null)
            {
                return NotFound();
            }
            return View(Car);
        }
        public IActionResult Delete(int id)
        {
            var Car = GetCars().FirstOrDefault(c => c.Id == id);
            if (Car == null)
            {
                return NotFound();
            }
            db.Cars.Remove(Car);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            GetViewBags();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            car = LinkCarDependencies(car);

            db.Cars.Add(car);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private Car LinkCarDependencies(Car car)
        {
            string Brand = car.Brand.Name.Trim();
            var findBrandObj = db.Brands.FirstOrDefault(c => c.Name == Brand);
            if (findBrandObj != null)
            {
                car.Brand = findBrandObj;
            }

            string Country = car.Country.Name.Trim();
            var findCountryObj = db.Countries.FirstOrDefault(c => c.Name == Country);
            if (findCountryObj != null)
            {
                car.Country = findCountryObj;
            }
            else
            {
                db.Countries.Add(new Country() { Name = Country });
                db.SaveChanges();
                car.Country = db.Countries.FirstOrDefault(c => c.Name == Country)!;
            }

            string Region = car.Region.Name.Trim();
            var findRegionObj = db.Regions.FirstOrDefault(c => c.Name == Region);
            if (findRegionObj != null)
            {
                car.Region = findRegionObj;
            }
            else
            {
                car.Region.Country = car.Country;
            }
            return car;
        }

        public IActionResult Edit(int id)
        {
            var Car = GetCars().FirstOrDefault(c => c.Id == id);
            if (Car == null)
            {
                return NotFound();
            }
            GetViewBags();
            return View(Car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            car = LinkCarDependencies(car);
            db.Cars.Update(car);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IQueryable<Car> GetCars()
        {
            return db.Cars
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.CarType)
                .Include(c => c.FuelType)
                .Include(c => c.Region)
                .Include(c => c.Country);
        }
        public void GetViewBags()
        {
            ViewBag.Brands = new SelectList(db.Brands.ToList(), nameof(Brand.Id), nameof(Brand.Name));
            ViewBag.Colors = new SelectList(db.Colors.ToList(), nameof(Color.Id), nameof(Color.Name));
            ViewBag.CarTypes = new SelectList(db.CarTypes.ToList(), nameof(CarType.Id), nameof(CarType.Name));
            ViewBag.Countries = new SelectList(db.Countries.ToList(), nameof(Country.Id), nameof(Country.Name));
            ViewBag.Regions = new SelectList(db.Regions.ToList(), nameof(Region.Id), nameof(Region.Name));
            ViewBag.FuelTypes = new SelectList(db.FuelTypes.ToList(), nameof(FuelType.Id), nameof(FuelType.Name));
        }
    }
}
