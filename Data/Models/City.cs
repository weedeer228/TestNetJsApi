using System.Collections.Generic;

namespace Data.Models
{

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Company> Companies { get; set; }
    }
}