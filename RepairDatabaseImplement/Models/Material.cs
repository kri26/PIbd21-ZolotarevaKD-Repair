using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepairDatabaseImplement.Models
{
    public class Material
    {
        public int Id { get; set; }
        [Required]
        public string MaterialName { get; set; }
        [ForeignKey("MaterialId")]
        public virtual List<RepairWorkMaterial> RepairWorkMaterials { get; set; }
    }
}
