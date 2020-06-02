using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RepairBusinessLogic.BindingModels
{
    public class WarehouseMaterialBindingModel
    {
        public int Id { get; set; }
        [DataMember]
        public int WarehouseId { get; set; }
        [DataMember]
        public int MaterialId { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
