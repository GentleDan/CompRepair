using System;
using System.Collections.Generic;
using System.Text;
using ComputerRepairBusinessLogic.ViewModels;

namespace ComputerRepairBusinessLogic.BindingModels
{
    public class ContractBindingModel
    {
        public int? Id { get; set; }

        public DateTime DateOfConclusion { get; set; }

        public int CustomerBaseId { get; set; }

        public int EmployeeId { get; set; }

        public List<int> MaterialsContract { get; set; }
        public List<int> ServicesContract { get; set; }
        public int PaymentId { get; set; }
    }
}
