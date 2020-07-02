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
                     if ((model.Id.HasValue && booking.Id == model.Id)
                        || (model.DateFrom.HasValue && model.DateTo.HasValue && booking.DateCreate >= model.DateFrom && booking.DateCreate <= model.DateTo)
                        || (booking.ClientId == model.ClientId)
                        || (model.FreeOrder.HasValue && model.FreeOrder.Value && !booking.ImplementerId.HasValue)
                        || (model.ImplementerId.HasValue && booking.ImplementerId == model.ImplementerId && booking.Status == BookingStatus.Выполняется))
                    {
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
            RepairWork repairWork = null;

            foreach (RepairWork i in source.RepairWork)
            {
                if (i.Id == model.RepairWork)
                {
                    repairWork = i;
                    break;
                }
            }

            Client client = null;

            foreach (Client c in source.Clients)
            {
                if (c.Id == model.ClientId)
                {
                    client = c;
                    break;
                }
            }

            Implementer implementer = null;

            foreach (Implementer i in source.Implementers)
            {
                if (i.Id == model.ImplementerId)
                {
                    implementer = i;
                    break;
                }
            }

            if (repairWork == null || client == null || model.ImplementerId.HasValue && implementer == null)
            {
                throw new Exception("Элемент не найден");
            }
            
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
            RepairWork repairWork = null;

            foreach (RepairWork repair in source.RepairWork)
            {
                if (repair.Id == order.RepairWorkId)
                {
                    repairWork = repair;
                    break;
                }
            }

            Client client = null;

            foreach (Client c in source.Clients)
            {
                if (c.Id == order.RepairWorkId)
                {
                    client  = c;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                Count = order.Count,
                ClientId = order.ClientId,
                ClientFIO = client.ClientFIO,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                ImplementorId = order.ImplementerId,
                ImplementerFIO = implementer.ImplementerFIO,
                RepairWorkName = repairWork.RepairWorkName,
                RepairWorkId = order.RepairWorkId,
                Status = order.Status,
                Sum = order.Sum
            };
        }
    }
}
