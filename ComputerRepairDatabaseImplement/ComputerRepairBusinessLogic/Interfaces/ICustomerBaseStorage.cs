using System;
using System.Collections.Generic;
using System.Text;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.ViewModels;

namespace ComputerRepairBusinessLogic.Interfaces
{
    public interface ICustomerBaseStorage
    {
        List<CustomerBaseViewModel> GetFullList();

        CustomerBaseViewModel GetElement(CustomerBaseBindingModel model);

        void Insert(CustomerBaseBindingModel model);

        void Update(CustomerBaseBindingModel model);

        void Delete(CustomerBaseBindingModel model);
    }
}
