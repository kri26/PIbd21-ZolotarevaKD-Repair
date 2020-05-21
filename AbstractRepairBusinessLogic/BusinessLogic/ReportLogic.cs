using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.HelperModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RepairBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IMaterialLogic materialLogic;
        private readonly IRepairWorkLogic repairWorkLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IWarehouseLogic warehouseLogic;

        public ReportLogic(IRepairWorkLogic productLogic, IMaterialLogic componentLogic,
            IOrderLogic orderLLogic, IWarehouseLogic warehouseLogic)
        {
            this.repairWorkLogic = productLogic;
            this.materialLogic = componentLogic;
            this.orderLogic = orderLLogic;
            this.warehouseLogic = warehouseLogic;
        }

        public List<ReportRepairWorkMaterialViewModel> GetRepairWorkMaterials()
        {
            List<ReportRepairWorkMaterialViewModel> reports = new List<ReportRepairWorkMaterialViewModel>();
            foreach (var repairWork in repairWorkLogic.Read(null))
            {
                foreach (var material in repairWork.RepairWorkMaterials)
                {
                    reports.Add(new ReportRepairWorkMaterialViewModel()
                    {
                        RepairWorkName = repairWork.RepairWorkName,
                        MaterialName = material.Value.Item1,
                        MaterialCount = material.Value.Item2
                    });
                }
            }
            return reports;
        }

        // Получение списка заказов за определенный период
        public List<IGrouping<DateTime, ReportOrdersViewModel>> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                RepairWorkName = x.RepairWorkName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .GroupBy(x => x.DateCreate)
           .ToList();
        }

        public List<ReportOrdersViewModel> GetOrders()
        {
            return orderLogic.Read(null)
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                RepairWorkName = x.RepairWorkName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        public List<ReportWarehouseViewModel> GetWarehouses()
        {
            return warehouseLogic.Read(null).Select(s => new ReportWarehouseViewModel()
            {
                WarehouseName = s.WarehouseName,
                Materials = s.WarehouseMaterials 
            }).ToList();
        }

        public List<ReportMaterialWarehouseViewModel> GetMaterialWarehouses()
        {
            var warehouses = warehouseLogic.Read(null);
            List<ReportMaterialWarehouseViewModel> reportMaterialWarehouses = new List<ReportMaterialWarehouseViewModel>();
            foreach (var warehouse in warehouses)
            {
                foreach (var material in warehouse.WarehouseMaterials)
                {
                    reportMaterialWarehouses.Add(new ReportMaterialWarehouseViewModel()
                    {
                        WarehouseName = warehouse.WarehouseName,
                        MaterialName = material.Key,
                        MaterialCount = material.Value
                    });
                }
            }
            return reportMaterialWarehouses;
        }

        // Сохранение компонент в файл-Word
        public void SaveRepairWorksToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Ремонтные работы",
                RepairWorks = repairWorkLogic.Read(null)
            });
        }

        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfoWarehouses
            {
                FileName = model.FileName,
                Title = "Хранилища",
                Warehouses = warehouseLogic.Read(null)
            });
        }

        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SaveProductComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Заказы",
                Orders = GetOrders()
            });
        }

        public void SaveWarehousesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfoWarehouse
            {
                FileName = model.FileName,
                Title = "Хранилища",
                Warehouses = GetWarehouses()
            });
        }

        public void SaveRepairWorkMaterialsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Ремонтные работы",
                RepairWorks = GetRepairWorkMaterials()
            });
        }

        public void SaveMaterialWarehousesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfoMaterialWarehouses
            {
                FileName = model.FileName,
                Title = "Материал на складах",
                MaterialWarehouses = GetMaterialWarehouses()
            });
        }
    }
}