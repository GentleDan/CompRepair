using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerRepairBusinessLogic.BusinessLogic
{
    public class ServicesLogic
    {
        private readonly IServicesStorage _servicesStorage;
        public ServicesLogic(IServicesStorage servicesStorage)
        {
            _servicesStorage = servicesStorage;
        }
        public List<ServicesViewModel> Read(ServicesBindingModel model)
        {
            if (model.Id.HasValue)
            {
                return new List<ServicesViewModel> { _servicesStorage.GetElement(model) };
            }
            return _servicesStorage.GetFullList();
        }
        public void CreateOrUpdate(ServicesBindingModel model)
        {
            var element = _servicesStorage.GetElement(new ServicesBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть услуга с таким названием");
            }
            if (model.Id.HasValue)
            {
                _servicesStorage.Update(model);
            }
            else
            {
                _servicesStorage.Insert(model);
            }
        }
        public void Delete(ServicesBindingModel model)
        {
            var element = _servicesStorage.GetElement(new ServicesBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _servicesStorage.Delete(model);
        }
    }
}
