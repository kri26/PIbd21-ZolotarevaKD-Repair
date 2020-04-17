using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairFileImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly FileDataListSingleton source;

        public WarehouseLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName && rec.Id != model.Id);

            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }

            if (model.Id.HasValue)
            {
                element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;
                element = new Warehouse { Id = maxId + 1 };
                source.Warehouses.Add(element);
            }

            element.WarehouseName = model.WarehouseName;
        }

        public void Delete(WarehouseBindingModel model)
        {
            source.WarehouseMaterials.RemoveAll(rec => rec.WarehouseId == model.Id);
            Warehouse element = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                source.Warehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public void AddMaterial(WarehouseMaterialBindingModel model)
        {
            WarehouseMaterial element = source.WarehouseMaterials
                        .FirstOrDefault(rec => rec.WarehouseId == model.WarehouseId && rec.MaterialId == model.MaterialId);

            if (element != null)
            {
                element.Count += model.Count;
                return;
            }

            source.WarehouseMaterials.Add(new WarehouseMaterial
            {
                Id = source.WarehouseMaterials.Count > 0 ? source.WarehouseMaterials.Max(rec => rec.Id) + 1 : 0,
                WarehouseId = model.WarehouseId,
                MaterialId = model.MaterialId,
                Count = model.Count
            });
        }

        private WarehouseViewModel CreateViewModel(Warehouse warehouse)
        {

            Dictionary<int, (string, int)> warehouseMaterials = new Dictionary<int, (string, int)>();

            foreach (var wc in source.WarehouseMaterials)
            {
                if (wc.WarehouseId == warehouse.Id)
                {
                    string materialName = string.Empty;

                    foreach (var material in source.Materials)
                    {
                        if (wc.MaterialId == material.Id)
                        {
                            materialName = material.MaterialName;
                            break;
                        }
                    }

                    warehouseMaterials.Add(wc.MaterialId, (materialName, wc.Count));
                }
            }

            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                WarehouseMaterials = warehouseMaterials
            };
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            return source.Warehouses
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new WarehouseViewModel
            {
                Id = rec.Id,
                WarehouseName = rec.WarehouseName,
                WarehouseMaterials = source.WarehouseMaterials
                                    .Where(recWC => recWC.WarehouseId == rec.Id)
                                    .ToDictionary(
                                        recWC => recWC.MaterialId,
                                        recWC => (
                                            source.Materials.FirstOrDefault(recC => recC.Id == recWC.MaterialId)?.MaterialName, recWC.Count
                                            )
                                        )
            })
            .ToList();
        }

        public bool WriteOffMaterials(OrderViewModel model)
        {
            var repairWorkMaterials = source.RepairWorkMaterials.Where(rec => rec.Id == model.RepairWorkId).ToList();

            if (repairWorkMaterials == null)
            {
                throw new Exception("Не найдена связь продукта с компонентами");
            }

            foreach (var pc in repairWorkMaterials)
            {
                var warehouseMaterial = source.WarehouseMaterials.Where(rec => rec.MaterialId == pc.MaterialId);
                int sum = warehouseMaterial.Sum(rec => rec.Count);

                if (sum < pc.Count * model.Count)
                {
                    return false;
                }
            }

            foreach (var pc in repairWorkMaterials)
            {
                var warehouseMaterial = source.WarehouseMaterials.Where(rec => rec.MaterialId == pc.MaterialId);
                int neededCount = pc.Count * model.Count;

                foreach (var wc in warehouseMaterial)
                {
                    if (wc.Count >= neededCount)
                    {
                        wc.Count -= neededCount;
                        break;
                    }
                    else
                    {
                        neededCount -= wc.Count;
                        wc.Count = 0;
                    }
                }
            }

            return true;
        }
    }
}