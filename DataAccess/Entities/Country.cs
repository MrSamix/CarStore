using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // conn
        public ICollection<Region> Regions { get; set; }
    }
}
