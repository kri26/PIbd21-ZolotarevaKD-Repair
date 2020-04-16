﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairDatabaseImplement.Models;

namespace RepairDatabaseImplement.Implements
{
    public class RepairWorkLogic : IRepairWorkLogic
    {
        public void CreateOrUpdate(RepairWorkBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        RepairWork element = context.RepairWorks.FirstOrDefault(rec => rec.RepairWorkName == model.RepairWorkName && rec.Id != model.Id);

                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }

                        if (model.Id.HasValue)
                        {
                            element = context.RepairWorks.FirstOrDefault(rec => rec.Id == model.Id);

                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new RepairWork();
                            context.RepairWorks.Add(element);
                        }

                        element.RepairWorkName = model.RepairWorkName;
                        element.Price = model.Price;

                        context.SaveChanges();

                        if (model.Id.HasValue)
                        {
                            var productMaterials = context.RepairWorkMaterials.Where(rec => rec.RepairWorkId == model.Id.Value).ToList();
                            context.RepairWorkMaterials.RemoveRange(productMaterials.Where(rec => !model.RepairWorkMaterials.ContainsKey(rec.MaterialId)).ToList());

                            context.SaveChanges();

                            foreach (var updateMaterial in productMaterials)
                            {
                                updateMaterial.Count =
                                model.RepairWorkMaterials[updateMaterial.MaterialId].Item2;

                                model.RepairWorkMaterials.Remove(updateMaterial.MaterialId);
                            }

                            context.SaveChanges();
                        }

                        foreach (var pc in model.RepairWorkMaterials)
                        {
                            context.RepairWorkMaterials.Add(new RepairWorkMaterial
                            {
                                RepairWorkId = element.Id,
                                MaterialId = pc.Key,
                                Count = pc.Value.Item2
                            });

                            context.SaveChanges();
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

        public void Delete(RepairWorkBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.RepairWorkMaterials.RemoveRange(context.RepairWorkMaterials.Where(rec => rec.RepairWorkId == model.Id));
                        RepairWork element = context.RepairWorks.FirstOrDefault(rec => rec.Id == model.Id);

                        if (element != null)
                        {
                            context.RepairWorks.Remove(element);
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

        public List<RepairWorkViewModel> Read(RepairWorkBindingModel model)
        {
            using (var context = new RepairDatabase())
            {
                return context.RepairWorks
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
                .Select(rec => new RepairWorkViewModel
                {
                    Id = rec.Id,
                    RepairWorkName = rec.RepairWorkName,
                    Price = rec.Price,
                    RepairWorkMaterials = context.RepairWorkMaterials
                                                .Include(recPC => recPC.Material)
                                                .Where(recPC => recPC.RepairWorkId == rec.Id)
                                                .ToDictionary(recPC => recPC.MaterialId, recPC => (
                                                    recPC.Material?.MaterialName, recPC.Count
                                                ))
                })
                .ToList();
            }
        }
    }
}