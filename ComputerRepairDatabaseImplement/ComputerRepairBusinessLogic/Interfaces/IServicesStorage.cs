using System;
using System.Collections.Generic;
using System.Text;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.ViewModels;

namespace ComputerRepairBusinessLogic.Interfaces
{
    public interface IServicesStorage
    {
        List<ServicesViewModel> GetFullList();

        ServicesViewModel GetElement(ServicesBindingModel model);

        void Insert(ServicesBindingModel model);

        void Update(ServicesBindingModel model);

        void Delete(ServicesBindingModel model);
    }
}
