using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerRepairBusinessLogic.BusinessLogic
{
    public class PaymentLogic
    {
        private readonly IPaymentStorage _paymentStorage;
        public PaymentLogic(IPaymentStorage paymentStorage)
        {
            _paymentStorage = paymentStorage;
        }
        public List<PaymentViewModel> Read(PaymentBindingModel model)
        {
            if (model.Id.HasValue)
            {
                return new List<PaymentViewModel> { _paymentStorage.GetElement(model) };
            }
            return _paymentStorage.GetFullList();
        }
        public void CreateOrUpdate(PaymentBindingModel model)
        {
            var element = _paymentStorage.GetElement(new PaymentBindingModel
            {
                ContractId = model.ContractId
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Заказ уже оплачен");
            }
            if (model.Id.HasValue)
            {
                _paymentStorage.Update(model);
            }
            else
            {
                _paymentStorage.Insert(model);
            }
        }
        public void Delete(PaymentBindingModel model)
        {
            var element = _paymentStorage.GetElement(new PaymentBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _paymentStorage.Delete(model);
        }
    }
}
