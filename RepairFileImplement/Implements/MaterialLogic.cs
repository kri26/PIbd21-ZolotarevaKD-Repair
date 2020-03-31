using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairListImplement.Models;
using System;
using System.Collections.Generic;

namespace RepairListImplement.Implements
{
    public class RepairWorkLogic : IRepairWorkLogic
    {
        private readonly DataListSingleton source;

        public RepairWorkLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(RepairWorkBindingModel model)
        {
            RepairWork tempRepairWork = model.Id.HasValue ? null : new RepairWork { Id = 1 };

            foreach (var repairWork in source.RepairWorks)
            {
                if (repairWork.RepairWorkName == model.RepairWorkName && repairWork.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }

                if (!model.Id.HasValue && repairWork.Id >= tempRepairWork.Id)
                {
                    tempRepairWork.Id = repairWork.Id + 1;
                }
                else if (model.Id.HasValue && repairWork.Id == model.Id)
                {
                    tempRepairWork = repairWork;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempRepairWork == null)
                {
                    throw new Exception("Элемент не найден");
                }

                CreateModel(model, tempRepairWork);
            }
            else
            {
                source.RepairWorks.Add(CreateModel(model, tempRepairWork));
            }
        }

        public void Delete(RepairWorkBindingModel model)
        {
            for (int i = 0; i < source.RepairWorkMaterials.Count; ++i)
            {
                if (source.RepairWorkMaterials[i].RepairWorkId == model.Id)
                {
                    source.RepairWorkMaterials.RemoveAt(i--);
                }
            }

            for (int i = 0; i < source.RepairWorks.Count; ++i)
            {
                if (source.RepairWorks[i].Id == model.Id)
                {
                    source.RepairWorks.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        private RepairWork CreateModel(RepairWorkBindingModel model, RepairWork repairWork)
        {
            repairWork.RepairWorkName = model.RepairWorkName;
            repairWork.Price = model.Price;
            int maxPCId = 0;

            for (int i = 0; i < source.RepairWorkMaterials.Count; ++i)
            {
                if (source.RepairWorkMaterials[i].Id > maxPCId)
                {
                    maxPCId = source.RepairWorkMaterials[i].Id;
                }

                if (source.RepairWorkMaterials[i].RepairWorkId == repairWork.Id)
                {
                    if (model.RepairWorkMaterials.ContainsKey(source.RepairWorkMaterials[i].MaterialId))
                    {
                        source.RepairWorkMaterials[i].Count = model.RepairWorkMaterials[source.RepairWorkMaterials[i].MaterialId].Item2;
                        model.RepairWorkMaterials.Remove(source.RepairWorkMaterials[i].MaterialId);
                    }

                    else
                    {
                        source.RepairWorkMaterials.RemoveAt(i--);
                    }
                }
            }

            foreach (var pc in model.RepairWorkMaterials)
            {
                source.RepairWorkMaterials.Add(new RepairWorkMaterial
                {
                    Id = ++maxPCId,
                    RepairWorkId = repairWork.Id,
                    MaterialId = pc.Key,
                    Count = pc.Value.Item2
                });
            }

            return repairWork;
        }

        public List<RepairWorkViewModel> Read(RepairWorkBindingModel model)
        {
            List<RepairWorkViewModel> result = new List<RepairWorkViewModel>();

            foreach (var repairWork in source.RepairWorks)
            {
                if (model != null)
                {
                    if (repairWork.Id == model.Id)
                    {
                        result.Add(CreateViewModel(repairWork));
                        break;
                    }

                    continue;
                }

                result.Add(CreateViewModel(repairWork));
            }

            return result;
        }

        private RepairWorkViewModel CreateViewModel(RepairWork repairWork)
        {

            Dictionary<int, (string, int)> repairWorkMaterials = new Dictionary<int, (string, int)>();

            foreach (var pc in source.RepairWorkMaterials)
            {
                if (pc.RepairWorkId == repairWork.Id)
                {
                    string materialName = string.Empty;

                    foreach (var material in source.Materials)
                    {
                        if (pc.MaterialId == material.Id)
                        {
                            materialName = material.MaterialName;
                            break;
                        }
                    }

                    repairWorkMaterials.Add(pc.MaterialId, (materialName, pc.Count));
                }
            }

            return new RepairWorkViewModel
            {
                Id = repairWork.Id,
                RepairWorkName = repairWork.RepairWorkName,
                Price = repairWork.Price,
                RepairWorkMaterials = repairWorkMaterials
            };
        }
    }
}