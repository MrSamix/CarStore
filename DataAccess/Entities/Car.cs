using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int CarTypeId { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int FuelTypeId { get; set; }
        public string? Description { get; set; }

        // conn
        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public CarType CarType { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public FuelType FuelType { get; set; }
    }
}
