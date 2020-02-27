using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.Interfaces
{
    public interface IMaterialLogic
    {
        List<MaterialViewModel> Read(MaterialBindingModel model);
        void CreateOrUpdate(MaterialBindingModel model);
        void Delete(MaterialBindingModel model);
    }
}
