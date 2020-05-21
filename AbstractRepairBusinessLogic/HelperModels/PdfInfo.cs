using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace RepairBusinessLogic.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportRepairWorkMaterialViewModel> RepairWorks { get; set; }
    }
}