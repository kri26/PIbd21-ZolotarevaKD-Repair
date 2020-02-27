using RepairListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Material> Materials { get; set; }
        public List<Order> Orders { get; set; }
        public List<RepairWork> Assemblies { get; set; }
        public List<RepairWorkMaterial> RepairWorkMaterials { get; set; }
        private DataListSingleton()
        {
            Materials = new List<Material>();
            Orders = new List<Order>();
            Assemblies = new List<RepairWork>();
            RepairWorkMaterials = new List<RepairWorkMaterial>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
