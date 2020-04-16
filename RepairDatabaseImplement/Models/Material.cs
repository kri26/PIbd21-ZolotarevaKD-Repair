﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairDatabaseImplement.Models
{
    public class Material
    {
        public int Id { get; set; }

        [Required]
        public string MaterialName { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<RepairWorkMaterial> RepairWorkMaterials { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<WarehouseMaterial> WarehouseMaterials { get; set; }
    }
}
