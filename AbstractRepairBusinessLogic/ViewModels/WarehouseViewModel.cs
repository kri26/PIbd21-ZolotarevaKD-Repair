using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RepairBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }
        public List<WarehouseMaterialViewModel> WarehouseMaterials { get; set; }
    }
}
