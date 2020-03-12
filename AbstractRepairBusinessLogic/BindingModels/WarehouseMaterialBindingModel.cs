using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.BindingModels
{
    public class WarehouseMaterialBindingModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}
