using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace RepairBusinessLogic.ViewModels
{
    [DataContract]
    public class RepairWorkViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название ремонтных работ")]
        public string RepairWorkName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> RepairWorkMaterials { get; set; }
    }
}
