using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RepairBusinessLogic.ViewModels
{
    public class RepairWorkViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название ремонтных работ")]
        public string RepairWorkName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> RepairWorkMaterials { get; set; }
    }
}
