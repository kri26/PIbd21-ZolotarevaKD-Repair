using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Enums;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepairBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly object locker = new object();
        private readonly IWarehouseLogic warehouseLogic;
        public MainLogic(IOrderLogic orderLogic, IWarehouseLogic warehouseLogic)
        {
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                RepairWorkId = model.RepairWorkId,
                Count = model.Count,
                ClientId = model.ClientId,
                ClientFIO = model.ClientFIO,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Треубуются_материалы)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"или \"Требуются материалы\"");
                }
                if (order.ImplementorId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                
                var orderModel = new OrderBindingModel
                {
                    Id = order.Id,
                    RepairWorkId = order.RepairWorkId,
                    Count = order.Count,
                    Sum = order.Sum,
                    ClientId = order.ClientId,
                    ClientFIO = order.ClientFIO,
                    DateCreate = order.DateCreate
                };

                try
                {
                    warehouseLogic.WriteOffMaterials(order);
                    orderModel.DateImplement = DateTime.Now;
                    orderModel.Status = OrderStatus.Выполняется;
                    orderModel.ImplementerId = model.ImplementerId;
                }
                catch
                {
                    orderModel.Status = OrderStatus.Треубуются_материалы;
                    throw;
                }

                orderLogic.CreateOrUpdate(orderModel);
                
            }
        }
        public void FinishOrder (ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                RepairWorkId = order.RepairWorkId,
                Count = order.Count,
                Sum = order.Sum,
                ClientId = order.ClientId,
                ClientFIO = order.ClientFIO,
                ImplementerFIO = order.ImplementerFIO,
                ImplementerId = order.ImplementorId.Value,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Готов
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                RepairWorkId = order.RepairWorkId,
                Count = order.Count,
                Sum = order.Sum,
                ClientId = order.ClientId,
                ClientFIO = order.ClientFIO,
                DateCreate = order.DateCreate,
                ImplementerFIO = order.ImplementerFIO,
                ImplementerId = order.ImplementorId.Value,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
        public void ReplanishWarehouse(WarehouseMaterialBindingModel model)
        {
            warehouseLogic.AddMaterial(model);
        }
    }
}
