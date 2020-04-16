using RepairListImplement.Models;
using System.Collections.Generic;

namespace RepairListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Material> Materials { get; set; }

        public List<Order> Orders { get; set; }

        public List<RepairWork> RepairWorks { get; set; }

        public List<RepairWorkMaterial> RepairWorkMaterials { get; set; }

        public List<Warehouse> Warehouses { get; set; }

        public List<WarehouseMaterial> WarehouseMaterials { get; set; }

        private DataListSingleton()
        {
            Materials = new List<Material>();
            Orders = new List<Order>();
            RepairWorks = new List<RepairWork>();
            RepairWorkMaterials = new List<RepairWorkMaterial>();
            Warehouses = new List<Warehouse>();
            WarehouseMaterials = new List<WarehouseMaterial>();
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