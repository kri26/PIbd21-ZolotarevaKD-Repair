using RepairBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int RepairWorkId { get; set; }
        public int ClientId { set; get; }
        public string ClientFIO { set; get; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
