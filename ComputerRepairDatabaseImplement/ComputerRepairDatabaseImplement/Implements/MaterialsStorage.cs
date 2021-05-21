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
    public class MaterialsStorage : IMaterialsStorage
    {
        public void Delete(MaterialsBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Materials.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public MaterialsViewModel GetElement(MaterialsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerRepairDatabase())
            {
                var material = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                return material != null ? new MaterialsViewModel
                {
                    Id = material.Id,
                    Name = material.Name,
                    Price = material.Price
                } : null;
            }
        }

        public List<MaterialsViewModel> GetFullList()
        {
            using (var context = new ComputerRepairDatabase())
            {
                return context.Materials.Select(rec => new MaterialsViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Price = rec.Price
                }).ToList();
            }
        }

        public void Insert(MaterialsBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                context.Materials.Add(CreateModel(model, new Materials()));
                context.SaveChanges();
            }
        }

        public void Update(MaterialsBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private Materials CreateModel(MaterialsBindingModel model, Materials materials)
        {
            materials.Name = model.Name;
            materials.Price = model.Price;
            return materials;
        }
    }
}
