using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairFileImplement.Models;
using RepairBusinessLogic.ViewModels;
using RepairFileImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using RepairBusinessLogic.Enums;


namespace RepairFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;
        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order element;
            if (model.Id.HasValue)
            {
                element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec =>
               rec.Id) : 0;
                element = new Order { Id = maxId + 1 };
                source.Orders.Add(element);
            }
            element.RepairWorkId = model.RepairWorkId == 0 ? element.RepairWorkId : model.RepairWorkId;
            element.ClientFIO = model.ClientFIO;
            element.ClientId = model.ClientId;
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateCreate = model.DateCreate;
            element.ImplementerFIO = model.ImplementerFIO;
            element.ImplementerId = model.ImplementerId;
            element.DateImplement = model.DateImplement;
        }
        public void Delete(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
             .Where(rec => model == null 
                  || (model.Id.HasValue && rec.Id == model.Id && rec.ClientId == model.ClientId)
                  || (model.DateTo.HasValue && model.DateFrom.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) 
                  || (model.ClientId.HasValue && rec.ClientId == model.ClientId) 
                  || (model.FreeOrder.HasValue && model.FreeOrder.Value && !(rec.ImplementerFIO != null)) 
                  || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == BookingStatus.Выполняется))
            .Select(rec => new OrderViewModel
             {
                 Id = rec.Id,
                 RepairWorkId = rec.RepairWorkId,
                 RepairWorkName = source.RepairWorks.FirstOrDefault((r) => r.Id == rec.RepairWorkId).RepairWorkName,
                 ClientFIO = rec.ClientFIO,
                 ClientId = rec.ClientId.Value,
                 ImplementorId = rec.ImplementerId,
                 ImplementerFIO = !string.IsNullOrEmpty(rec.ImplementerFIO) ? rec.ImplementerFIO : string.Empty,
                 Count = rec.Count,
                 DateCreate = rec.DateCreate,
                 DateImplement = rec.DateImplement,
                 Status = rec.Status,
                 Sum = rec.Sum
             }).ToList();
        }

        private string GetRepairWorkName(int id)
        {
            string name = "";
            var RepairWork = source.RepairWorks.FirstOrDefault(x => x.Id == id);
            name = RepairWork != null ? RepairWork.RepairWorkName : "";
            return name;
        }
    }
}
