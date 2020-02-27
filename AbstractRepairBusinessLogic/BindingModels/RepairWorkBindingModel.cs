using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.BindingModels
{
    public class RepairWorkBindingModel
    {
        public int? Id { get; set; }
        public string RepairWorkName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> RepairWorkMaterials { get; set; }
    }
}
