using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.ViewModels
{
    public class ReportMaterialRepairWorksViewModel
    {
        public string MaterialName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> RepairWorks { get; set; }
    }
}
