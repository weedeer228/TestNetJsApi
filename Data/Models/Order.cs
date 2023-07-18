using System;
using System.Xml.Linq;

namespace Data.Models
{

    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public City City { get; set; }

        public Company Company { get; set; }

    }
}