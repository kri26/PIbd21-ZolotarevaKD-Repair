using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.ViewModels
{
    public class ReportWarehouseViewModel
    {
        public string WarehouseName { set; get; }
        public Dictionary<string, int> Materials { set; get; }
    }
}
