using System;
using System.Collections.Generic;
using System.Text;
using RepairBusinessLogic.Enums;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace RepairBusinessLogic.BusinessLogic
{
    public class WorkModeling
    {
        private readonly IImplementerLogic implementerLogic;
        private readonly IOrderLogic orderLogic;
        private readonly MainLogic mainLogic;
        private readonly Random rnd;

        public WorkModeling(IImplementerLogic implementerLogic, IOrderLogic orderLogic, MainLogic mainLogic)
        {
            this.implementerLogic = implementerLogic;
            this.orderLogic = orderLogic;
            this.mainLogic = mainLogic;
            rnd = new Random(1000);
        }

        public void DoWork()
        {
            var implementers = implementerLogic.Read(null);
            var orders = orderLogic.Read(new OrderBindingModel { FreeOrder = true });
            foreach (var implementer in implementers)
            {
                WorkerWorkAsync(implementer, orders);
            }
        }

        private async void WorkerWorkAsync(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {
            // ищем заказы, которые уже в работе (вдруг исполнителя прервали)
            var runOrders = await Task.Run(() => orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id
            }));
            foreach (var order in runOrders)
            {
                // делаем работу заново
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                mainLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = order.Id
                });
                // отдыхаем
                Thread.Sleep(implementer.PauseTime);
            }
            var notEnoughMaterialsOrders = orders
               .Where(x => x.Status == OrderStatus.Треубуются_материалы)
               .Select(x => x)
               .ToList();
            var isNotEnoughMaterialsBookings = bookingLogic.Read(new BookingBindingModel
            {
                IsNotEnoughMaterialsBookings = true
            });
            orders.RemoveAll(x => notEnoughMaterialsOrders.Contains(x));
            DoWork(implementer, notEnoughMaterialsOrders);
            await Task.Run(() =>
            {
                DoWork(implementer, orders);
            });
        }

        private void DoWork(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {
            foreach (var order in orders)
            {
                // пытаемся назначить заказ на исполнителя
                try
                {
                    mainLogic.TakeOrderInWork(new ChangeStatusBindingModel
                    {
                        OrderId = order.Id,
                        ImplementerId = implementer.Id
                    });
                    Boolean isNotEnoughMaterials = orderLogic.Read(new OrderBindingModel
                    {
                        Id = order.Id
                    }).FirstOrDefault().Status == OrderStatus.Треубуются_материалы;
                    if (isNotEnoughMaterials)
                    {
                        continue;
                    }
                    // делаем работу
                    Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                    mainLogic.FinishOrder(new ChangeStatusBindingModel
                    {
                        OrderId = order.Id,
                        ImplementerId = implementer.Id,
                        ImplementerFIO = implementer.ImplementerFIO
                    });
                    // отдыхаем
                    Thread.Sleep(implementer.PauseTime);
                }
                catch (Exception) { }
            }
        }
    }

}
