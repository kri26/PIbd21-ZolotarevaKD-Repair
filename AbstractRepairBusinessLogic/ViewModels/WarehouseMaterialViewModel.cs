using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RepairBusinessLogic.ViewModels
{
    public class WarehouseMaterialViewModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int MaterialId { get; set; }
        [DisplayName("Материал")]
        public string MaterialName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
