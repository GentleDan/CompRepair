using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ComputerRepairBusinessLogic.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Дата оплаты")]
        public DateTime DateOfPayment { get; set; }
        [DisplayName("Сумма")]
        public decimal Summ { get; set; }

        public int ContractId { get; set; }
    }
}
