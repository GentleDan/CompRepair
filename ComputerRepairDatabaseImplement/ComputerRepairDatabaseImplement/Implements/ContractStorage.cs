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
    public class ContractStorage : IContractStorage
    {
        public void Delete(ContractBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                var contract = context.Contract.FirstOrDefault(rec => rec.Id == model.Id);
                if (contract != null)
                {
                    context.Contract.Remove(contract);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ не найден");
                }
            }
        }

        public ContractViewModel GetElement(ContractBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new ComputerRepairDatabase())
            {
                var contract = context.Contract
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.ServicesContracts)
                    .ThenInclude(rec => rec.Services)
                    .Include(rec => rec.MaterialsContracts)
                    .ThenInclude(rec => rec.Materials)
                    .Include(rec => rec.Payment)
                    .Include(rec => rec.CustomerBase)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return contract != null ?
                new ContractViewModel
                {
                    Id = contract.Id,
                    DateOfConclusion = contract.DateOfConclusion,
                    CustomerBaseId = contract.CustomerBase.Id,
                    EmployeeId = contract.Employee.Id,
                    CustomerBase = contract.CustomerBase.Surname,
                    Employee = contract.Employee.Surname,
                    Payment = contract.Payment.Summ,
                    Materials = contract.MaterialsContracts
                    .Select(rc => new MaterialsViewModel { Id = rc.Materials.Id, Name = rc.Materials.Name, Price = rc.Materials.Price })
                    .ToList(),
                    Services = contract.ServicesContracts
                    .Select(rc => new ServicesViewModel { Id = rc.Services.Id, Name = rc.Services.Name, Price = rc.Services.Price })
                    .ToList()
                } :
                null;
            }
        }

        public List<ContractViewModel> GetFullList()
        {
            using (var context = new ComputerRepairDatabase())
            {
                return context.Contract
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.ServicesContracts)
                    .ThenInclude(rec => rec.Services)
                    .Include(rec => rec.MaterialsContracts)
                    .ThenInclude(rec => rec.Materials)
                    .Include(rec => rec.Payment)
                    .Include(rec => rec.CustomerBase)
                .Select(rec => new ContractViewModel
                {
                    Id = rec.Id,
                    DateOfConclusion = rec.DateOfConclusion,
                    CustomerBaseId = rec.CustomerBase.Id,
                    EmployeeId = rec.Employee.Id,
                    CustomerBase = rec.CustomerBase.Surname,
                    Employee = rec.Employee.Surname,
                    Payment = rec.Payment.Summ,
                    Materials = rec.MaterialsContracts
                    .Select(rc => new MaterialsViewModel { Id = rc.Materials.Id, Name = rc.Materials.Name, Price = rc.Materials.Price })
                    .ToList(),
                    Services = rec.ServicesContracts
                    .Select(rc => new ServicesViewModel { Id = rc.Services.Id, Name = rc.Services.Name, Price = rc.Services.Price })
                    .ToList()
                })
                .ToList();
            }
        }

        public void Insert(ContractBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Contract(), context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(ContractBindingModel model)
        {
            using (var context = new ComputerRepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Contract.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        private Contract CreateModel(ContractBindingModel model, Contract contract, ComputerRepairDatabase context)
        {
            contract.CustomerBaseid = model.CustomerBaseId;
            contract.Employeeid = model.EmployeeId;
            contract.Paymentid = model.PaymentId;
            contract.DateOfConclusion = model.DateOfConclusion;
            if (contract.Id == 0)
            {
                context.Contract.Add(contract);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                List<ServicesContract> servicesContract = context.ServicesContract.Where(rec => rec.Contractid == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ServicesContract.RemoveRange(servicesContract.Where(rec => !model.ServicesContract.Contains(rec.Servicesid)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateServices in servicesContract)
                {
                    model.ServicesContract.Remove(updateServices.Servicesid);
                }
                List<MaterialsContract> materialsContract = context.MaterialsContract.Where(rec => rec.Contractid == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.MaterialsContract.RemoveRange(materialsContract.Where(rec => !model.MaterialsContract.Contains(rec.Materialsid)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateMaterials in materialsContract)
                {
                    model.MaterialsContract.Remove(updateMaterials.Materialsid);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.ServicesContract)
            {
                context.ServicesContract.Add(new ServicesContract
                {
                    Contractid = contract.Id,
                    Servicesid = pc
                });
                context.SaveChanges();
            }
            foreach (var pc in model.MaterialsContract)
            {
                context.MaterialsContract.Add(new MaterialsContract
                {
                    Contractid = contract.Id,
                    Materialsid = pc
                });
                context.SaveChanges();
            }

            return contract;
        }
    }
}
