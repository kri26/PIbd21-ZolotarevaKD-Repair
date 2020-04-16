using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RepairDatabaseImplement.Models
{
    public class WarehouseMaterial
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int MaterialId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Material Material { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}