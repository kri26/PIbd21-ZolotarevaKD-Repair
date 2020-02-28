using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RepairFileImplement.Implements
{
    public class RepairWorkLogic : IRepairWorkLogic
    {
        private readonly FileDataListSingleton source;
        public RepairWorkLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(RepairWorkBindingModel model)
        {
            RepairWork element = source.RepairWorks.FirstOrDefault(rec => rec.RepairWorkName ==
           model.RepairWorkName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.RepairWorks.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.RepairWorks.Count > 0 ? source.Materials.Max(rec =>
               rec.Id) : 0;
                element = new RepairWork { Id = maxId + 1 };
                source.RepairWorks.Add(element);
            }
            element.RepairWorkName = model.RepairWorkName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.RepairWorkMaterials.RemoveAll(rec => rec.RepairWorkId == model.Id &&
           !model.RepairWorkMaterials.ContainsKey(rec.MaterialId));
            // обновили количество у существующих записей
            var updateMaterials = source.RepairWorkMaterials.Where(rec => rec.RepairWorkId ==
           model.Id && model.RepairWorkMaterials.ContainsKey(rec.MaterialId));
            foreach (var updateMaterial in updateMaterials)
            {
                updateMaterial.Count = model.RepairWorkMaterials[updateMaterial.MaterialId].Item2;
                model.RepairWorkMaterials.Remove(updateMaterial.MaterialId);
            }
            // добавили новые
            int maxPCId = source.RepairWorkMaterials.Count > 0 ?
           source.RepairWorkMaterials.Max(rec => rec.Id) : 0;
            foreach (var pc in model.RepairWorkMaterials)
            {
                source.RepairWorkMaterials.Add(new RepairWorkMaterial
                {
                    Id = ++maxPCId,
                    RepairWorkId = element.Id,
                    MaterialId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(RepairWorkBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.RepairWorkMaterials.RemoveAll(rec => rec.RepairWorkId == model.Id);
            RepairWork element = source.RepairWorks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.RepairWorks.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<RepairWorkViewModel> Read(RepairWorkBindingModel model)
        {
            return source.RepairWorks
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new RepairWorkViewModel
            {
                Id = rec.Id,
                RepairWorkName = rec.RepairWorkName,
                Price = rec.Price,
                RepairWorkMaterials = source.RepairWorkMaterials
            .Where(recPC => recPC.RepairWorkId == rec.Id)
           .ToDictionary(recPC => recPC.MaterialId, recPC =>
            (source.Materials.FirstOrDefault(recC => recC.Id ==
           recPC.MaterialId)?.MaterialName, recPC.Count))
            })
            .ToList();
        }
    }
}