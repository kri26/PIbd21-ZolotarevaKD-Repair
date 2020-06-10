using RepairBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepairDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int ClientId { set; get; }
        public int RepairWorkId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        public int? ImplementerId { set; get; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Client Client { set; get; }
        public virtual RepairWork RepairWork { get; set; }
        public virtual Implementer Implementer { set; get; }
    }
}
