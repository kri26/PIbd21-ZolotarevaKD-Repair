using Microsoft.EntityFrameworkCore;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairDatabaseImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName && rec.Id != model.Id);

                if (element != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }

                if (model.Id.HasValue)
                {
                    element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Warehouse();
                    context.Warehouses.Add(element);
                }

                element.WarehouseName = model.WarehouseName;

                context.SaveChanges();
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.WarehouseMaterials.RemoveRange(context.WarehouseMaterials.Where(rec => rec.WarehouseId == model.Id));
                        Warehouse element = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element != null)
                        {
                            context.Warehouses.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void AddMaterial(WarehouseMaterialBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                WarehouseMaterial element =
                    context.WarehouseMaterials.FirstOrDefault(rec => rec.WarehouseId == model.WarehouseId && rec.MaterialId == model.MaterialId);

                if (element != null)
                {
                    element.Count += model.Count;
                }
                else
                {

                    element = new WarehouseMaterial();

                    context.WarehouseMaterials.Add(element);
                }

                element.WarehouseId = model.WarehouseId;
                element.MaterialId = model.MaterialId;
                element.Count = model.Count;

                context.SaveChanges();
            }
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                return context.Warehouses
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new WarehouseViewModel
                {
                    Id = rec.Id,
                    WarehouseName = rec.WarehouseName,
                    WarehouseMaterials = context.WarehouseMaterials
                                                .Include(recWC => recWC.Material)
                                                .Where(recWC => recWC.WarehouseId == rec.Id)
                                                .ToDictionary(recWC => recWC.MaterialId, recWC => (
                                                    recWC.Material?.MaterialName, recWC.Count
                                                ))
                })
                .ToList();
            }
        }

        public void WriteOffMaterials(OrderViewModel model)
        {
            using (var context = new RepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var productMaterials = context.RepairWorkMaterials.Where(rec => rec.RepairWorkId == model.RepairWorkId).ToList();

                        foreach (var pc in productMaterials)
                        {
                            var warehouseMaterial = context.WarehouseMaterials.Where(rec => rec.MaterialId == pc.MaterialId);
                            int neededCount = pc.Count * model.Count;

                            foreach (var wc in warehouseMaterial)
                            {
                                if (wc.Count >= neededCount)
                                {
                                    wc.Count -= neededCount;
                                    neededCount = 0;
                                    break;
                                }
                                else
                                {
                                    neededCount -= wc.Count;
                                    wc.Count = 0;
                                }
                            }

                            if (neededCount > 0)
                            {
                                throw new Exception("На складах недостаточно компонентов");
                            }

                        }

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}