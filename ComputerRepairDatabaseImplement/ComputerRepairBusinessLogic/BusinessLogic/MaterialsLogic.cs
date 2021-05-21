using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.Interfaces;
using ComputerRepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputerRepairBusinessLogic.BusinessLogic
{
    public class MaterialsLogic
    {
        private readonly IMaterialsStorage _materialStorage;
        public MaterialsLogic(IMaterialsStorage materialStorage)
        {
            _materialStorage = materialStorage;
        }
        public List<MaterialsViewModel> Read(MaterialsBindingModel model)
        {
            if (model.Id.HasValue)
            {
                return new List<MaterialsViewModel> { _materialStorage.GetElement(model) };
            }
            return _materialStorage.GetFullList();
        }
        public void CreateOrUpdate(MaterialsBindingModel model)
        {
            var element = _materialStorage.GetElement(new MaterialsBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть материал с таким названием");
            }
            if (model.Id.HasValue)
            {
                _materialStorage.Update(model);
            }
            else
            {
                _materialStorage.Insert(model);
            }
        }
        public void Delete(MaterialsBindingModel model)
        {
            var element = _materialStorage.GetElement(new MaterialsBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _materialStorage.Delete(model);
        }
    }
}
