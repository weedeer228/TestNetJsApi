using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public Company Company { get; set; }

        public IEnumerable<Note> Notes { get; set; }

        public Positions Position { get; set; }
    }

}
