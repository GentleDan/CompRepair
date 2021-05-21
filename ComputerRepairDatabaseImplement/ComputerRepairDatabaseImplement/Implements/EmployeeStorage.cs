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
    public class EmployeeStorage : IEmployeeStorage
    {
        public void Delete(EmployeeBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Employee.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Employee.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerRepairDatabase())
            {
                var employee = context.Employee.FirstOrDefault(rec =>  rec.Id == model.Id);
                return employee != null ? new EmployeeViewModel
                {
                    Id = employee.Id,
                    Surname = employee.Surname,
                    Name = employee.Name,
                    Lastname = employee.Lastname,
                    DateOfBirthday = employee.DateOfBirthday,
                    Post = employee.Post
                } : null;
            }
        }

        public List<EmployeeViewModel> GetFullList()
        {
            using (var context = new ComputerRepairDatabase())
            {
                return context.Employee.Select(rec => new EmployeeViewModel
                {
                    Id = rec.Id,
                    Surname = rec.Surname,
                    Name = rec.Name,
                    Lastname = rec.Lastname,
                    DateOfBirthday = rec.DateOfBirthday,
                    Post = rec.Post
                }).ToList();
            }
        }

        public void Insert(EmployeeBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                context.Employee.Add(CreateModel(model, new Employee()));
                context.SaveChanges();
            }
        }

        public void Update(EmployeeBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var element = context.Employee.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        private Employee CreateModel(EmployeeBindingModel model, Employee employee)
        {
            employee.Surname = model.Surname;
            employee.Name = model.Name;
            employee.Lastname = model.Lastname;
            employee.DateOfBirthday = model.DateOfBirthday;
            employee.Post = model.Post;
            return employee;
        }
    }
}
