using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerRepairBusinessLogic.BindingModels
{
    public class PaymentBindingModel
    {
        public int? Id { get; set; }

        public DateTime DateOfPayment { get; set; }

        public decimal Summ { get; set; }

        public int ContractId { get; set; }
    }
}
