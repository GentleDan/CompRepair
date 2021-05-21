using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;


namespace ComputerRepairBusinessLogic.BusinessLogic
{
    public class ContractLogic
    {
        private readonly IContractStorage _contractStorage;
        public ContractLogic(IContractStorage contractStorage)
        {
            _contractStorage = contractStorage;
        }
        public List<ContractViewModel> Read(ContractBindingModel model)
        {
            if (model.Id.HasValue)
            {
                return new List<ContractViewModel> { _contractStorage.GetElement(model) };
            }
            return _contractStorage.GetFullList();
        }

        public void CreateOrUpdate(ContractBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _contractStorage.Update(model);
            }
            else
            {
                _contractStorage.Insert(model);
            }
        }
        public void Delete(ContractBindingModel model)
        {
            var element = _contractStorage.GetElement(new ContractBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Контракт не найден");
            }
            _contractStorage.Delete(model);
        }
    }
}
