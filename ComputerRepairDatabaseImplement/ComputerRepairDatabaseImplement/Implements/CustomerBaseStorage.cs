using Microsoft.EntityFrameworkCore;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using ComputerRepairDatabaseImplement.Models;
using ComputerRepairDatabaseImplement.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerRepairDatabaseImplement.Implements
{
    public class CustomerBaseStorage : ICustomerBaseStorage
    {
        public void Delete(CustomerBaseBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.CustomerBase.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.CustomerBase.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public CustomerBaseViewModel GetElement(CustomerBaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerRepairDatabase())
            {
                var custBase = context.CustomerBase.FirstOrDefault(rec => rec.Id == model.Id);
                return custBase != null ? new CustomerBaseViewModel
                {
                    Id = custBase.Id,
                    Surname = custBase.Surname,
                    Name = custBase.Name,
                    Lastname = custBase.Lastname,
                    DateOfBirthday = custBase.DateOfBirthday
                } : null;
            }
        }

        public List<CustomerBaseViewModel> GetFullList()
        {
            using (var context = new ComputerRepairDatabase())
            {
                return context.Employee.Select(rec => new CustomerBaseViewModel
                {
                    Id = rec.Id,
                    Surname = rec.Surname,
                    Name = rec.Name,
                    Lastname = rec.Lastname,
                    DateOfBirthday = rec.DateOfBirthday,
                }).ToList();
            }
        }

        public void Insert(CustomerBaseBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                context.CustomerBase.Add(CreateModel(model, new CustomerBase()));
                context.SaveChanges();
            }
        }

        public void Update(CustomerBaseBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.CustomerBase.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private CustomerBase CreateModel(CustomerBaseBindingModel model, CustomerBase custBase)
        {
            custBase.Surname = model.Surname;
            custBase.Name = model.Name;
            custBase.Lastname = model.Lastname;
            custBase.DateOfBirthday = model.DateOfBirthday;
            return custBase;
        }
    }
}
