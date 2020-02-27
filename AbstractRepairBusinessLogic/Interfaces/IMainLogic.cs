using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.Interfaces
{
    public interface IMainLogic
    {
        List<OrderViewModel> GetOrders();
        void CreateOrder(OrderBindingModel model);
        void TakeOrderInWork(OrderBindingModel model);
        void FinishOrder(OrderBindingModel model);
        void PayOrder(OrderBindingModel model);
    }
}
