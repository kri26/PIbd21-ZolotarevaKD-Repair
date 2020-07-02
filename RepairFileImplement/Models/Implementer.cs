using System;
using System.Collections.Generic;
using System.Text;

namespace RepairFileImplement.Models
{
    public class Implementer
    {
        public int Id { set; get; }
        public string ImplementerFIO { set; get; }
        public int WorkTime { set; get; }
        public int PauseTime { set; get; }
        public virtual List<Order> Orders { set; get; }
    }
}
