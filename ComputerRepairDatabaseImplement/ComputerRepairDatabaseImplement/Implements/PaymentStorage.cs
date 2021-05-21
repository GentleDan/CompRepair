using Microsoft.EntityFrameworkCore;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using ComputerRepairDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ComputerRepairDatabaseImplement.DatabaseContext;

namespace ComputerRepairDatabaseImplement.Implements
{
    public class PaymentStorage : IPaymentStorage
    {
        public void Delete(PaymentBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Payment.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Payment.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public PaymentViewModel GetElement(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerRepairDatabase())
            {
                var payment = context.Payment.FirstOrDefault(rec => rec.Id == model.Id);
                return payment != null ? new PaymentViewModel
                {
                    Id = payment.Id,
                    Summ = payment.Summ,
                    DateOfPayment = payment.DateOfPayment
                } : null;
            }
        }

        public List<PaymentViewModel> GetFullList()
        {
            using (var context = new ComputerRepairDatabase())
            {
                return context.Payment.Select(rec => new PaymentViewModel
                {
                    Id = rec.Id,
                    DateOfPayment = rec.DateOfPayment,
                    Summ = rec.Summ
                }).ToList();
            }
        }

        public void Insert(PaymentBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                context.Payment.Add(CreateModel(model, new Payment()));
                context.SaveChanges();
            }
        }

        public void Update(PaymentBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Payment.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private Payment CreateModel(PaymentBindingModel model, Payment payment)
        {
            payment.DateOfPayment = model.DateOfPayment;
            payment.Summ = model.Summ;
            return payment;
        }
    }
}
