using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ComputerRepairBusinessLogic.ViewModels
{
    public class MaterialsViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
