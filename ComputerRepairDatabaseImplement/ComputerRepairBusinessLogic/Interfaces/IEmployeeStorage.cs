using System;
using System.Collections.Generic;
using System.Text;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.ViewModels;

namespace ComputerRepairBusinessLogic.Interfaces
{
    public interface IEmployeeStorage
    {
        List<EmployeeViewModel> GetFullList();

        EmployeeViewModel GetElement(EmployeeBindingModel model);

        void Insert(EmployeeBindingModel model);

        void Update(EmployeeBindingModel model);

        void Delete(EmployeeBindingModel model);
    }
}
