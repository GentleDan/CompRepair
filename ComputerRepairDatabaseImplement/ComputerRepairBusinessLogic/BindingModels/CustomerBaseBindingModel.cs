using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerRepairBusinessLogic.BindingModels
{
    public class CustomerBaseBindingModel
    {
        public int? Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public DateTime DateOfBirthday { get; set; }
    }
}
