using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace RepairBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string WarehouseName { get; set; }
    }
}
