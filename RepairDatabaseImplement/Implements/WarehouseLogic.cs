using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

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
                    throw new Exception("Уже есть изделие с таким названием");
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
            }
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                return context.Warehouses.Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new WarehouseViewModel
                {
                    Id = rec.Id,
                    WarehouseName = rec.WarehouseName,
                    WarehouseMaterials = context.WarehouseMaterials.
                                                Include(recSM => recSM.Material)
                                                .Where(recSM => recSM.WarehouseId == rec.Id)
                                                .ToDictionary(recSM => recSM.MaterialId, 
                                                recSM => (recSM.Material?.MaterialName, recSM.Count))
                }).ToList();
            }
        }

        public void WriteOffMaterials(OrderViewModel order)
        {
            using (var context = new RepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var repairWorkMaterials = context.RepairWorkMaterials.Where(dm => dm.RepairWorkId == order.RepairWorkId).ToList();
                        var warehouseMaterials = context.WarehouseMaterials.ToList();
                        foreach (var material in repairWorkMaterials)
                        {
                            var materialCount = material.Count * order.Count;
                            foreach (var sm in warehouseMaterials)
                            {
                                if (sm.MaterialId == material.MaterialId && sm.Count >= materialCount)
                                {
                                    sm.Count -= materialCount;
                                    materialCount = 0;
                                    context.SaveChanges();
                                    break;
                                }
                                else if (sm.MaterialId == material.MaterialId && sm.Count < materialCount)
                                {
                                    materialCount -= sm.Count;
                                    sm.Count = 0;
                                    context.SaveChanges();
                                }
                            }
                            if (materialCount > 0)
                                throw new Exception("Не хватает материалов на складах!");
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
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
                var warehouseMaterial = context.WarehouseMaterials
                    .FirstOrDefault(sm => sm.MaterialId == model.MaterialId && sm.WarehouseId == model.WarehouseId);
                if (warehouseMaterial != null)
                    warehouseMaterial.Count += model.Count;
                else
                    context.WarehouseMaterials.Add(new WarehouseMaterial()
                    {
                        MaterialId = model.MaterialId,
                        WarehouseId = model.WarehouseId,
                        Count = model.Count
                    });
                context.SaveChanges();
            }
        }
    }
}