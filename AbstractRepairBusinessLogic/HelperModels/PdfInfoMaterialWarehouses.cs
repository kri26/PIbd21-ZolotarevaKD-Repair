﻿using System;
using System.Collections.Generic;
using System.Text;
using RepairBusinessLogic.ViewModels;

namespace RepairBusinessLogic.HelperModels
{
    public class PdfInfoMaterialWarehouses
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportMaterialWarehouseViewModel> MaterialWarehouses { get; set; }
    }
}
