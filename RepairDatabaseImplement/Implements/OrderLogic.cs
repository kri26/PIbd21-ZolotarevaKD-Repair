using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairDatabaseImplement.Models;

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
                    element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

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
                .Where(rec => model == null || rec.Id == model.Id)
                .Include(rec => rec.RepairWork)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    RepairWorkId = rec.RepairWorkId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    RepairWorkName = rec.RepairWork.RepairWorkName
                })
                .ToList();
            }
        }
    }
}