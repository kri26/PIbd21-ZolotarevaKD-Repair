using System;
using System.Collections.Generic;
using System.Text;

namespace RepairFileImplement.Models
{
    public class WarehouseMaterial
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}
