using System;

namespace Data.Models
{

    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public City City { get; set; }

    }
}