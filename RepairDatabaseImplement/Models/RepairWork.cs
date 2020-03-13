using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairDatabaseImplement.Models
{
    public class RepairWork
    {
        public int Id { get; set; }
        [Required]
        public string RepairWorkName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<RepairWorkMaterial> RepairWorkMaterials { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
