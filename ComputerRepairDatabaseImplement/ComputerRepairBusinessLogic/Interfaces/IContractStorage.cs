using System;
using System.Collections.Generic;
using System.Text;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.ViewModels;

namespace ComputerRepairBusinessLogic.Interfaces
{
    public interface IContractStorage
    {
        List<ContractViewModel> GetFullList();

        ContractViewModel GetElement(ContractBindingModel model);

        void Insert(ContractBindingModel model);

        void Update(ContractBindingModel model);

        void Delete(ContractBindingModel model);
    }
}
