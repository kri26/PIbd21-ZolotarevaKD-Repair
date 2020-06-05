using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using RepairBusinessLogic.Attributes;

namespace RepairBusinessLogic.ViewModels
{
    [DataContract]
    public class RepairWorkViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Ремонтные работы", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string RepairWorkName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> RepairWorkMaterials { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "RepairWorkName", "Price" };
    }
}
