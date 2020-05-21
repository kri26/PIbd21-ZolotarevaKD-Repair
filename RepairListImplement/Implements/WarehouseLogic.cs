using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairListImplement.Models;
using System;
using System.Collections.Generic;

namespace RepairListImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly DataListSingleton source;

        public WarehouseLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            Warehouse tempWarehouse = model.Id.HasValue ? null : new Warehouse { Id = 1, WarehouseName = model.WarehouseName };

            foreach (var warehouse in source.Warehouses)
            {
                if (warehouse.WarehouseName == model.WarehouseName && warehouse.Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }

                if (!model.Id.HasValue && warehouse.Id >= tempWarehouse.Id)
                {
                    tempWarehouse.Id = warehouse.Id + 1;
                }
                else if (model.Id.HasValue && warehouse.Id == model.Id)
                {
                    tempWarehouse = warehouse;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempWarehouse == null)
                {
                    throw new Exception("Элемент не найден");
                }

                tempWarehouse.WarehouseName = model.WarehouseName;
            }
            else
            {
                source.Warehouses.Add(tempWarehouse);
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            for (int i = 0; i < source.WarehouseMaterials.Count; ++i)
            {
                if (source.WarehouseMaterials[i].WarehouseId == model.Id)
                {
                    source.WarehouseMaterials.RemoveAt(i--);
                }
            }

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddMaterial(WarehouseMaterialBindingModel model)
        {
            for (int i = 0; i < source.WarehouseMaterials.Count; ++i)
            {
                if (source.WarehouseMaterials[i].WarehouseId == model.WarehouseId &&
                    source.WarehouseMaterials[i].MaterialId == model.MaterialId)
                {
                    source.WarehouseMaterials[i].Count += model.Count;
                    model.Id = source.WarehouseMaterials[i].Id;
                    return;
                }
            }

            int maxWCId = 0;

            for (int i = 0; i < source.WarehouseMaterials.Count; ++i)
            {
                if (source.WarehouseMaterials[i].Id > maxWCId)
                {
                    maxWCId = source.WarehouseMaterials[i].Id;
                }
            }

            if (model.Id == 0)
            {
                source.WarehouseMaterials.Add(new WarehouseMaterial
                {
                    Id = ++maxWCId,
                    WarehouseId = model.WarehouseId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();

            foreach (var warehouse in source.Warehouses)
            {
                if (model != null)
                {
                    if (warehouse.Id == model.Id)
                    {
                        result.Add(CreateViewModel(warehouse));
                        break;
                    }

                    continue;
                }

                result.Add(CreateViewModel(warehouse));
            }

            return result;
        }

        private WarehouseViewModel CreateViewModel(Warehouse warehouse)
        {

            Dictionary<string, int> warehouseMaterials = new Dictionary<string, int>();

            foreach (var wc in source.WarehouseMaterials)
            {
                if (wc.WarehouseId == warehouse.Id)
                {
                    string MaterialName = string.Empty;

                    foreach (var Material in source.Materials)
                    {
                        if (wc.MaterialId == Material.Id)
                        {
                            MaterialName = Material.MaterialName;
                            break;
                        }
                    }

                    warehouseMaterials.Add(MaterialName, wc.Count);
                }
            }

            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseMaterials = warehouseMaterials
            };
        }

        public bool AreMaterialsEnough(OrderViewModel model)
        {
            // Заглушка
            return true;
        }

        public void WriteOffMaterials(OrderViewModel model)
        {
            // Заглушка
        }
    }
}