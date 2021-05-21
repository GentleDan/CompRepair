using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerRepairBusinessLogic.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly IEmployeeStorage _employeeStorage;
        public EmployeeLogic(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }
        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { _employeeStorage.GetElement(model) };
            }
            return _employeeStorage.GetFullList();
        }
        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _employeeStorage.Update(model);
            }
            else
            {
                _employeeStorage.Insert(model);
            }
        }
        public void Delete(EmployeeBindingModel model)
        {
            var element = _employeeStorage.GetElement(new EmployeeBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _employeeStorage.Delete(model);
        }
    }
}
