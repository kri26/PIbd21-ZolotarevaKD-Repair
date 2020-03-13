using RepairBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairListImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RepairWorkId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
