using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.HelperModels;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;

namespace RepairBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IMaterialLogic materialLogic;
        private readonly IRepairWorkLogic repairWorkLogic;
        private readonly IOrderLogic orderLogic;

        public ReportLogic(IRepairWorkLogic repairWorkLogic, IMaterialLogic materialLogic, IOrderLogic orderLogic)
        {
            this.repairWorkLogic = repairWorkLogic;
            this.materialLogic = materialLogic;
            this.orderLogic = orderLogic;
        }

        public List<ReportRepairWorkMaterialViewModel> GetRepairWorkMaterial()
        {
            var materials = materialLogic.Read(null);
            var repairWorks = repairWorkLogic.Read(null);
            var list = new List<ReportRepairWorkMaterialViewModel>();

            foreach (var repairWork in repairWorks)
            {
                foreach (var material in materials)
                {
                    if (repairWork.RepairWorkMaterials.ContainsKey(material.Id))
                    {
                        var record = new ReportRepairWorkMaterialViewModel
                        {
                            RepairWorkName = repairWork.RepairWorkName,
                            MaterialName = material.MaterialName,
                            Count = repairWork.RepairWorkMaterials[material.Id].Item2
                        };

                        list.Add(record);
                    }
                }
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
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
            .ToList();
        }

        public void SaveRepairWorksToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                RepairWorks = repairWorkLogic.Read(null)
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            var a = GetOrders(model);

            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        public void SaveRepairWorkMaterialsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список изделий с компонентами",
                RepairWorkMaterials = GetRepairWorkMaterial()
            });
        }
    }
}
