using System;
using System.Collections.Generic;
using System.Text;
using ComputerRepairBusinessLogic.BindingModels;
using ComputerRepairBusinessLogic.ViewModels;

namespace ComputerRepairBusinessLogic.Interfaces
{
    public interface IMaterialsStorage
    {
        List<MaterialsViewModel> GetFullList();

        MaterialsViewModel GetElement(MaterialsBindingModel model);

        void Insert(MaterialsBindingModel model);

        void Update(MaterialsBindingModel model);

        void Delete(MaterialsBindingModel model);
    }
}
