using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
namespace ComputerRepairBusinessLogic.BusinessLogic
{
    public class CustomerBaseLogic
    {
        private readonly ICustomerBaseStorage _customerBaseStorage;
        public CustomerBaseLogic(ICustomerBaseStorage customerBaseStorage)
        {
            _customerBaseStorage = customerBaseStorage;
        }
        public List<CustomerBaseViewModel> Read(CustomerBaseBindingModel model)
        {
            if (model.Id.HasValue)
            {
                return new List<CustomerBaseViewModel> { _customerBaseStorage.GetElement(model) };
            }
            return _customerBaseStorage.GetFullList();
        }
        public void CreateOrUpdate(CustomerBaseBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _customerBaseStorage.Update(model);
            }
            else
            {
                _customerBaseStorage.Insert(model);
            }
        }
        public void Delete(CustomerBaseBindingModel model)
        {
            var element = _customerBaseStorage.GetElement(new CustomerBaseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _customerBaseStorage.Delete(model);
        }
    }
}
