using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ComputerRepairBusinessLogic.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Отчество")]
        public string Lastname { get; set; }
        [DisplayName("Дата рождения")]
        public DateTime DateOfBirthday { get; set; }
        [DisplayName("Должность")]
        public string Post { get; set; }
    }
}
