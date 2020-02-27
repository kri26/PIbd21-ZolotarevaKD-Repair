using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int RepairWorkId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
