using RepairListImplemen.Models;
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
        public List<Client> Clients { set; get; }
        public List<Implementer> Implementers { set; get; }
        private DataListSingleton()
        {
            Materials = new List<Material>();
            Orders = new List<Order>();
            RepairWorks = new List<RepairWork>();
            RepairWorkMaterials = new List<RepairWorkMaterial>();
            Warehouses = new List<Warehouse>();
            WarehouseMaterials = new List<WarehouseMaterial>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
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