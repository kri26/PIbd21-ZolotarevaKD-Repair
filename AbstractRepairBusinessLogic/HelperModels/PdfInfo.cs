using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace RepairBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportReparWorkMaterialViewModel> ProductComponents { get; set; }
    }
}