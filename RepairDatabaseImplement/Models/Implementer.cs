using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairDatabaseImplement.Models
{
    public class Implementer
    {
        public int Id { set; get; }
        public string ImplementerFIO { set; get; }
        [Required]
        public int WorkTime { set; get; }
        [Required]
        public int PauseTime { set; get; }
        public virtual List<Order> Orders { set; get; }
    }
}