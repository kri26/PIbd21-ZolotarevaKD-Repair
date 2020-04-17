using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepairRestApi.Models
{
    public class RepairWork
    {
        public int Id { set; get; }
        public string RepairWorkName { set; get; }
        public decimal Price { set; get; }
    }
}