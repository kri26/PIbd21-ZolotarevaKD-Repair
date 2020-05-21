using RepairBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace RepairBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrdersViewModel> Orders { get; set; }
    }
}