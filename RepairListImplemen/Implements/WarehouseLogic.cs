using System;
using System.Collections.Generic;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairListImplement;
using RepairListImplement.Models;

namespace RepairListImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly DataListSingleton source;

        public WarehouseLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetList()
        {
            List<WarehouseViewModel> result = new List<WarehouseViewModel>();

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                List<WarehouseMaterialViewModel> warehouseMaterials = new List<WarehouseMaterialViewModel>();

                for (int j = 0; j < source.WarehouseMaterials.Count; ++j)
                {
                    if (source.WarehouseMaterials[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string materialName = string.Empty;

                        for (int k = 0; k < source.Materials.Count; ++k)
                        {
                            if (source.WarehouseMaterials[j].MaterialId == source.Materials[k].Id)
                            {
                                materialName = source.Materials[k].MaterialName;
                                break;
                            }
                        }

                        warehouseMaterials.Add(new WarehouseMaterialViewModel
                        {
                            Id = source.WarehouseMaterials[j].Id,
                            WarehouseId = source.WarehouseMaterials[j].WarehouseId,
                            MaterialId = source.WarehouseMaterials[j].MaterialId,
                            MaterialName = materialName,
                            Count = source.WarehouseMaterials[j].Count
                        });
                    }
                }

                result.Add(new WarehouseViewModel
                {
                    Id = source.Warehouses[i].Id,
                    WarehouseName = source.Warehouses[i].WarehouseName,
                    WarehouseMaterials = warehouseMaterials
                });
            }

            return result;
        }

        public WarehouseViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                List<WarehouseMaterialViewModel> warehouseMaterials = new List<WarehouseMaterialViewModel>();

                for (int j = 0; j < source.WarehouseMaterials.Count; ++j)
                {
                    if (source.WarehouseMaterials[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string materialName = string.Empty;

                        for (int k = 0; k < source.Materials.Count; ++k)
                        {
                            if (source.WarehouseMaterials[j].MaterialId == source.Materials[k].Id)
                            {
                                materialName = source.Materials[k].MaterialName;
                                break;
                            }
                        }

                        warehouseMaterials.Add(new WarehouseMaterialViewModel
                        {
                            Id = source.WarehouseMaterials[j].Id,
                            WarehouseId = source.WarehouseMaterials[j].WarehouseId,
                            MaterialId = source.WarehouseMaterials[j].MaterialId,
                            MaterialName = materialName,
                            Count = source.WarehouseMaterials[j].Count
                        });
                    }
                }

                if (source.Warehouses[i].Id == id)
                {
                    return new WarehouseViewModel
                    {
                        Id = source.Warehouses[i].Id,
                        WarehouseName = source.Warehouses[i].WarehouseName,
                        WarehouseMaterials = warehouseMaterials
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(WarehouseBindingModel model)
        {
            int maxId = 0;

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id > maxId)
                {
                    maxId = source.Warehouses[i].Id;
                }

                if (source.Warehouses[i].WarehouseName == model.WarehouseName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }

            source.Warehouses.Add(new Warehouse
            {
                Id = maxId + 1,
                WarehouseName = model.WarehouseName
            });
        }

        public void UpdElement(WarehouseBindingModel model)
        {
            int index = -1;

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    index = i;
                }

                if (source.Warehouses[i].WarehouseName == model.WarehouseName && source.Warehouses[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            source.Warehouses[index].WarehouseName = model.WarehouseName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.WarehouseMaterials.Count; ++i)
            {
                if (source.WarehouseMaterials[i].WarehouseId == id)
                {
                    source.WarehouseMaterials.RemoveAt(i--);
                }
            }

            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == id)
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
    }
}
