using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        // conn
        public Country Country { get; set; }
    }
}
