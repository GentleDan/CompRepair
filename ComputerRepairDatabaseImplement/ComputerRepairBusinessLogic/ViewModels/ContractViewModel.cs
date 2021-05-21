using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ComputerRepairBusinessLogic.ViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        [DisplayName("Дата заключения")]
        public DateTime DateOfConclusion { get; set; }
        [DisplayName("Заказчик")]
        public string CustomerBase { get; set; }
        [DisplayName("Работник")]
        public string Employee { get; set; }
        [DisplayName("Материалы")]
        public List<MaterialsViewModel> Materials { get; set; }
        [DisplayName("Услуги")]
        public List<ServicesViewModel> Services { get; set; }
        [DisplayName("Оплата")]
        public decimal Payment { get; set; }
        public int CustomerBaseId { get; set; }
        public int EmployeeId { get; set; }
    }
}
