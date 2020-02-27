using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RepairBusinessLogic.ViewModels
{
    public class RepairWorkMaterialViewModel
    {
        public int Id { get; set; }
        public int AssemblyId { get; set; }
        public int MaterialId { get; set; }
        [DisplayName("Материал")]
        public string MaterialName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
