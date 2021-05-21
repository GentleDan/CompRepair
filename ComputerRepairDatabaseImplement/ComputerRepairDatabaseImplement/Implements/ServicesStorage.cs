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
    public class ServicesStorage : IServicesStorage
    {
        public void Delete(ServicesBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Services.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public ServicesViewModel GetElement(ServicesBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerRepairDatabase())
            {
                var service = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                return service != null ? new ServicesViewModel
                {
                    Id = service.Id,
                    Name = service.Name,
                    Price = service.Price
                } : null;
            }
        }

        public List<ServicesViewModel> GetFullList()
        {
            using (var context = new ComputerRepairDatabase())
            {
                return context.Materials.Select(rec => new ServicesViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Price = rec.Price
                }).ToList();
            }
        }

        public void Insert(ServicesBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                context.Services.Add(CreateModel(model, new Services()));
                context.SaveChanges();
            }
        }

        public void Update(ServicesBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private Services CreateModel(ServicesBindingModel model, Services service)
        {
            service.Name = model.Name;
            service.Price = model.Price;
            return service;
        }
    }
}
