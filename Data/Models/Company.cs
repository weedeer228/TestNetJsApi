using System.Collections.Generic;

namespace Data.Models
{
    public class Company
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }

        public IEnumerable<Order> History { get; set; }
        public IEnumerable<Note> Notes { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }

    public class SimplifiledCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public IEnumerable<object> History { get; set; }
        public IEnumerable<object> Notes { get; set; }

        public IEnumerable<object> Employees { get; set; }
    }
}
