﻿using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairBusinessLogic.Enums;

namespace RepairDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.RepairWorkId = model.RepairWorkId == 0 ? element.RepairWorkId : model.RepairWorkId;
                element.ClientFIO = model.ClientFIO;
                element.ClientId = model.ClientId.Value;
                element.ImplementerFIO = model.ImplementerFIO;
                element.ImplementerId = model.ImplementerId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                return context.Orders
            .Include(rec => rec.RepairWork)
            .Where(
                    rec => model == null
                    || (rec.Id == model.Id && model.Id.HasValue)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)

                    || (model.ClientId == rec.ClientId)
                    || (model.FreeOrder.HasValue && model.FreeOrder.Value && !(rec.ImplementerFIO != null)) 
                    || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == OrderStatus.Выполняется))
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                RepairWorkName = rec.RepairWork.RepairWorkName,
                ClientFIO = rec.ClientFIO,
                ClientId = rec.ClientId,
                ImplementorId = rec.ImplementerId,
                ImplementerFIO = !string.IsNullOrEmpty(rec.ImplementerFIO) ? rec.ImplementerFIO : string.Empty,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            })
            .ToList();
            }
        }
    }
}
