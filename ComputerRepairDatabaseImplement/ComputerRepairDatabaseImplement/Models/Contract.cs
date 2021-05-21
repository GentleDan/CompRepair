using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ComputerRepairDatabaseImplement.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public DateTime DateOfConclusion { get; set; }
        public int CustomerBaseid { get; set; }
        public int Employeeid { get; set; }
        public int Paymentid { get; set; }
        public virtual CustomerBase CustomerBase { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Payment Payment { get; set; }
        [ForeignKey("Contractid")]
        public virtual List<ServicesContract> ServicesContracts { get; set; }
        [ForeignKey("Contractid")]
        public virtual List<MaterialsContract> MaterialsContracts { get; set; }
    }
}
