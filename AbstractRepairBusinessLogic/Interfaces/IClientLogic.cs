using System;
using System.Collections.Generic;
using System.Text;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;

namespace RepairBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}