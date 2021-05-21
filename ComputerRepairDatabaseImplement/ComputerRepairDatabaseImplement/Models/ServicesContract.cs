using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComputerRepairDatabaseImplement.Models
{
    public partial class ServicesContract
    {
        public int Id { get; set; }
        public int Servicesid { get; set; }
        public int Contractid { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Services Services { get; set; }
    }
}
