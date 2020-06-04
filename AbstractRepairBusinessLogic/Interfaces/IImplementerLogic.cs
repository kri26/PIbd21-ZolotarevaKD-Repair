using System;
using System.Collections.Generic;
using System.Text;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;

namespace RepairBusinessLogic.Interfaces
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}
