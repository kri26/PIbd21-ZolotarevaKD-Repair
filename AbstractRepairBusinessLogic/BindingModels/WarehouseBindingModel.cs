using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseMaterialBindingModel> WarehouseComponent { get; set; }
    }
}
