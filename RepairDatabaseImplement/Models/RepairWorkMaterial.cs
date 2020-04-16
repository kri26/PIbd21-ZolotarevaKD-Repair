using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RepairDatabaseImplement.Models
{
    public class RepairWorkMaterial
    {
        public int Id { get; set; }
        public int RepairWorkId { get; set; }
        public int MaterialId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Material Material { get; set; }
        public virtual RepairWork RepairWork { get; set; }
    }
}
