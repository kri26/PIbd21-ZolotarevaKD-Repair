using System;
using System.Collections.Generic;
using System.Text;

namespace RepairListImplement.Models
{
    public class RepairWorkMaterial
    {
        public int Id { get; set; }
        public int RepairWorkId { get; set; }
        public int MaterialId { get; set; }
        public int Count { get; set; }
    }
}
