using System;
using System.Collections.Generic;
using System.Text;
using RepairBusinessLogic.ViewModels;
using RepairBusinessLogic.BindingModels;

namespace RepairBusinessLogic.Interfaces
{
    public interface IRepairWorkLogic
    {        
        List<RepairWorkViewModel> Read(RepairWorkBindingModel model);
        void CreateOrUpdate(RepairWorkBindingModel model);
        void Delete(RepairWorkBindingModel model);        
    }
}
