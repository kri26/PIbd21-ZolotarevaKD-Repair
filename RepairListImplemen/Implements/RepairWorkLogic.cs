using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            foreach (var RepairWork in source.Assemblies)
            {
                if (RepairWork.RepairWorkName == model.RepairWorkName && RepairWork.Id != model.Id)
                {
                    throw new Exception("Уже есть сборка с таким названием");
                }
                if (!model.Id.HasValue && RepairWork.Id >= tempRepairWork.Id)
                {
                    tempRepairWork.Id = RepairWork.Id + 1;
                }
                else if (model.Id.HasValue && RepairWork.Id == model.Id)
                {
                    tempRepairWork = RepairWork;
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
                source.Assemblies.Add(CreateModel(model, tempRepairWork));
            }
        }
        public void Delete(RepairWorkBindingModel model)
        {
            // удаляем записи по деталям при удалении сборки
            for (int i = 0; i < source.RepairWorkMaterials.Count; ++i)
            {
                if (source.RepairWorkMaterials[i].RepairWorkId == model.Id)
                {
                    source.RepairWorkMaterials.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Assemblies.Count; ++i)
            {
                if (source.Assemblies[i].Id == model.Id)
                {
                    source.Assemblies.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private RepairWork CreateModel(RepairWorkBindingModel model, RepairWork RepairWork)
        {
            RepairWork.RepairWorkName = model.RepairWorkName;
            RepairWork.Price = model.Price;
            //обновляем существующие детали и ищем максимальный идентификатор
            int maxADId = 0;
            for (int i = 0; i < source.RepairWorkMaterials.Count; ++i)
            {
                if (source.RepairWorkMaterials[i].Id > maxADId)
                {
                    maxADId = source.RepairWorkMaterials[i].Id;
                }
                if (source.RepairWorkMaterials[i].RepairWorkId == RepairWork.Id)
                {
                    // если в модели пришла запись детали с таким id
                    if (model.RepairWorkMaterials.ContainsKey(source.RepairWorkMaterials[i].MaterialId))
                    {
                        // обновляем количество
                        source.RepairWorkMaterials[i].Count = model.RepairWorkMaterials[source.RepairWorkMaterials[i].MaterialId].Item2;
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                        model.RepairWorkMaterials.Remove(source.RepairWorkMaterials[i].MaterialId);
                    }
                    else
                    {
                        source.RepairWorkMaterials.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var ad in model.RepairWorkMaterials)
            {
                source.RepairWorkMaterials.Add(new RepairWorkMaterial
                {
                    Id = ++maxADId,
                    RepairWorkId = RepairWork.Id,
                    MaterialId = ad.Key,
                    Count = ad.Value.Item2
                });
            }
            return RepairWork;
        }
        public List<RepairWorkViewModel> Read(RepairWorkBindingModel model)
        {
            List<RepairWorkViewModel> result = new List<RepairWorkViewModel>();
            foreach (var RepairWork in source.Assemblies)
            {
                if (model != null)
                {
                    if (RepairWork.Id == model.Id)
                    {
                        result.Add(CreateViewModel(RepairWork));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(RepairWork));
            }
            return result;
        }
        private RepairWorkViewModel CreateViewModel(RepairWork RepairWork)
        {
            // требуется дополнительно получить список деталей для сборки с названиями и их количество
            Dictionary<int, (string, int)> RepairWorkMaterials = new Dictionary<int, (string, int)>();
            foreach (var ad in source.RepairWorkMaterials)
            {
                if (ad.RepairWorkId == RepairWork.Id)
                {
                    string MaterialName = string.Empty;
                    foreach (var Material in source.Materials)
                    {
                        if (ad.MaterialId == Material.Id)
                        {
                            MaterialName = Material.MaterialName;
                            break;
                        }
                    }
                    RepairWorkMaterials.Add(ad.MaterialId, (MaterialName, ad.Count));
                }
            }
            return new RepairWorkViewModel
            {
                Id = RepairWork.Id,
                RepairWorkName = RepairWork.RepairWorkName,
                Price = RepairWork.Price,
                RepairWorkMaterials = RepairWorkMaterials
            };
        }
    }
}
