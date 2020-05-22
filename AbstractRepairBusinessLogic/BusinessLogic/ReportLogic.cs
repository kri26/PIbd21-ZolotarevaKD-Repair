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
        private readonly IRepairWorkLogic repairWorkLogic;
        private readonly IOrderLogic orderLogic;

        public ReportLogic(IRepairWorkLogic repairWorkLogic, IMaterialLogic materialLogic, IOrderLogic orderLogic)
        {
            this.repairWorkLogic = repairWorkLogic;
            this.orderLogic = orderLogic;
        }

        public List<ReportRepairWorkMaterialViewModel> GetRepairWorkMaterial()
        {
            var repairWorks = repairWorkLogic.Read(null);
            var list = new List<ReportRepairWorkMaterialViewModel>();

            foreach (var repairWork in repairWorks)
            {
                foreach (var material in repairWork.RepairWorkMaterials)
                {
                    var record = new ReportRepairWorkMaterialViewModel
                    {
                        RepairWorkName = repairWork.RepairWorkName,
                        MaterialName = material.Value.Item1,
                        Count = material.Value.Item2
                    };

                    list.Add(record);
                }
            }
            return list;
        }

        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
           .Read(new OrderBindingModel
           {
               DateFrom = model.DateFrom,
               DateTo = model.DateTo
           })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();
            return list;
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
