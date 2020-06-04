using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RepairBusinessLogic.Enums;

namespace RepairListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (!model.Id.HasValue && order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
                else if (model.Id.HasValue && order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null)
                {
                     if (order.Id == model.Id)
                    {
                        if (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                        {
                            result.Add(CreateViewModel(order));
                            continue;
                        }
                        if (model.ClientId == order.ClientId)
                        {
                            result.Add(CreateViewModel(order));
                            continue;
                        }
                        if (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && order.Status == OrderStatus.Выполняется)
                        {
                            result.Add(CreateViewModel(order));
                            continue;
                        }
                        if (model.FreeOrder.HasValue && model.FreeOrder.Value && !order.ImplementerId.HasValue)
                        {
                            result.Add(CreateViewModel(order));
                            continue;
                        }
                        if (model.Status == order.Status)
                        if (model.NotEnoughMaterialsOrders.HasValue &&
                            model.NotEnoughMaterialsOrders.Value &&
                            order.Status == OrderStatus.Треубуются_материалы)
                        {
                            result.Add(CreateViewModel(order));
                            continue;
                        }
                        result.Add(CreateViewModel(order));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.Count = model.Count;
            order.ClientId = model.ClientId.Value;
            order.ClientFIO = model.ClientFIO;
            order.DateCreate = model.DateCreate;
            order.ImplementerId = model.ImplementerId;
            order.ImplementerFIO = model.ImplementerFIO;
            order.DateImplement = model.DateImplement;
            order.RepairWorkId = model.RepairWorkId;
            order.Status = model.Status;
            order.Sum = model.Sum;
            return order;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            string RepairWorkName = "";
            foreach (var RepairWork in source.RepairWorks)
            {
                if (RepairWork.Id == order.RepairWorkId)
                {
                    RepairWorkName = RepairWork.RepairWorkName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                Count = order.Count,
                ClientId = order.ClientId,
                ClientFIO = order.ClientFIO,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                ImplementorId = order.ImplementerId,
                ImplementerFIO = order.ImplementerFIO,
                RepairWorkName = RepairWorkName,
                RepairWorkId = order.RepairWorkId,
                Status = order.Status,
                Sum = order.Sum
            };
        }
    }
}
