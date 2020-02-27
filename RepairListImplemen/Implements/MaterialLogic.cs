using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairListImplement.Implements
{
    public class MaterialLogic : IMaterialLogic
    {
        private readonly DataListSingleton source;
        public MaterialLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(MaterialBindingModel model)
        {
            Material tempMaterial = model.Id.HasValue ? null : new Material { Id = 1 };
            foreach (var Material in source.Materials)
            {
                if (Material.MaterialName == model.MaterialName && Material.Id != model.Id)
                {
                    throw new Exception("Уже есть деталь с таким названием");
                }
                if (!model.Id.HasValue && Material.Id >= tempMaterial.Id)
                {
                    tempMaterial.Id = Material.Id + 1;
                }
                else if (model.Id.HasValue && Material.Id == model.Id)
                {
                    tempMaterial = Material;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempMaterial == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempMaterial);
            }
            else
            {
                source.Materials.Add(CreateModel(model, tempMaterial));
            }
        }
        public void Delete(MaterialBindingModel model)
        {
            for (int i = 0; i < source.Materials.Count; ++i)
            {
                if (source.Materials[i].Id == model.Id.Value)
                {
                    source.Materials.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Деталь не найдена");
        }
        public List<MaterialViewModel> Read(MaterialBindingModel model)
        {
            List<MaterialViewModel> result = new List<MaterialViewModel>();
            foreach (var Material in source.Materials)
            {
                if (model != null)
                {
                    if (Material.Id == model.Id)
                    {
                        result.Add(CreateViewModel(Material));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(Material));
            }
            return result;
        }
        private Material CreateModel(MaterialBindingModel model, Material Material)
        {
            Material.MaterialName = model.MaterialName;
            return Material;
        }
        private MaterialViewModel CreateViewModel(Material Material)
        {
            return new MaterialViewModel
            {
                Id = Material.Id,
                MaterialName = Material.MaterialName
            };
        }
    }
}
