using System;
using System.Collections.Generic;
using System.Text;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.ViewModels;

namespace ComputerRepairBusinessLogic.Interfaces
{
    public interface IPaymentStorage
    {
        List<PaymentViewModel> GetFullList();

        PaymentViewModel GetElement(PaymentBindingModel model);

        void Insert(PaymentBindingModel model);

        void Update(PaymentBindingModel model);

        void Delete(PaymentBindingModel model);
    }
}
