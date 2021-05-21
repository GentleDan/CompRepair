using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComputerRepairDatabaseImplement.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Contract = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Post { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
