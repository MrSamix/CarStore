using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
