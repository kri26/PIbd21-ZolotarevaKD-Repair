using RepairBusinessLogic.Enums;
using RepairFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RepairFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string MaterialFileName = "Material.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string RepairWorkFileName = "RepairWork.xml";
        private readonly string RepairWorkMaterialFileName = "RepairWorkMaterial.xml";
        private readonly string WarehouseFileName = "Warehouse.xml";
        private readonly string WarehouseMaterialFileName = "WarehouseMaterial.xml";

        public List<Material> Materials { get; set; }
        public List<Order> Orders { get; set; }
        public List<RepairWork> RepairWorks { get; set; }
        public List<RepairWorkMaterial> RepairWorkMaterials { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<WarehouseMaterial> WarehouseMaterials { get; set; }

        private FileDataListSingleton()
        {
            Materials = LoadMaterials();
            Orders = LoadOrders();
            RepairWorks = LoadRepairWorks();
            RepairWorkMaterials = LoadRepairWorkMaterials();
            Warehouses = LoadWarehouses();
            WarehouseMaterials = LoadWarehouseMaterials();
        }

        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }

            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveMaterials();
            SaveOrders();
            SaveRepairWorks();
            SaveRepairWorkMaterials();
            SaveWarehouses();
            SaveWarehouseMaterials();
        }

        private List<Material> LoadMaterials()
        {
            var list = new List<Material>();

            if (File.Exists(MaterialFileName))
            {
                XDocument xDocument = XDocument.Load(MaterialFileName);
                var xElements = xDocument.Root.Elements("Material").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Material
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        MaterialName = elem.Element("MaterialName").Value
                    });
                }
            }

            return list;
        }

        private List<Order> LoadOrders()
        {
            var list = new List<Order>();

            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        RepairWorkId = Convert.ToInt32(elem.Element("RepairWorkId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                        elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                        Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }

            return list;
        }

        private List<RepairWork> LoadRepairWorks()
        {
            var list = new List<RepairWork>();

            if (File.Exists(RepairWorkFileName))
            {
                XDocument xDocument = XDocument.Load(RepairWorkFileName);
                var xElements = xDocument.Root.Elements("RepairWork").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new RepairWork
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        RepairWorkName = elem.Element("RepairWorkName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }

            return list;
        }

        private List<RepairWorkMaterial> LoadRepairWorkMaterials()
        {
            var list = new List<RepairWorkMaterial>();

            if (File.Exists(RepairWorkMaterialFileName))
            {
                XDocument xDocument = XDocument.Load(RepairWorkMaterialFileName);
                var xElements = xDocument.Root.Elements("RepairWorkMaterial").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new RepairWorkMaterial
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        RepairWorkId = Convert.ToInt32(elem.Element("RepairWorkId").Value),
                        MaterialId = Convert.ToInt32(elem.Element("MaterialId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }

            return list;
        }

        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();

            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value
                    });
                }
            }

            return list;
        }

        private List<WarehouseMaterial> LoadWarehouseMaterials()
        {
            var list = new List<WarehouseMaterial>();

            if (File.Exists(WarehouseMaterialFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseMaterialFileName);
                var xElements = xDocument.Root.Elements("WarehouseMaterial").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new WarehouseMaterial
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseId = Convert.ToInt32(elem.Element("WarehouseId").Value),
                        MaterialId = Convert.ToInt32(elem.Element("MaterialId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }

            return list;
        }

        private void SaveMaterials()
        {
            if (Materials != null)
            {
                var xElement = new XElement("Materials");

                foreach (var material in Materials)
                {
                    xElement.Add(new XElement("Material",
                    new XAttribute("Id", material.Id),
                    new XElement("MaterialName", material.MaterialName)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MaterialFileName);
            }
        }

        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("RepairWorkId", order.RepairWorkId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveRepairWorks()
        {
            if (RepairWorks != null)
            {
                var xElement = new XElement("RepairWorks");

                foreach (var repairWork in RepairWorks)
                {
                    xElement.Add(new XElement("RepairWork",
                    new XAttribute("Id", repairWork.Id),
                    new XElement("RepairWorkName", repairWork.RepairWorkName),
                    new XElement("Price", repairWork.Price)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(RepairWorkFileName);
            }
        }

        private void SaveRepairWorkMaterials()
        {
            if (RepairWorkMaterials != null)
            {
                var xElement = new XElement("RepairWorkMaterials");

                foreach (var repairWorkMaterial in RepairWorkMaterials)
                {
                    xElement.Add(new XElement("RepairWorkMaterial",
                    new XAttribute("Id", repairWorkMaterial.Id),
                    new XElement("RepairWorkId", repairWorkMaterial.RepairWorkId),
                    new XElement("MaterialId", repairWorkMaterial.MaterialId),
                    new XElement("Count", repairWorkMaterial.Count)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(RepairWorkMaterialFileName);
            }
        }

        private void SaveWarehouses()
        {
            if (RepairWorkMaterials != null)
            {
                var xElement = new XElement("Warehouses");

                foreach (var warehouse in Warehouses)
                {
                    xElement.Add(new XElement("Warehouse",
                    new XAttribute("Id", warehouse.Id),
                    new XElement("WarehouseName", warehouse.WarehouseName)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }

        private void SaveWarehouseMaterials()
        {
            if (WarehouseMaterials != null)
            {
                var xElement = new XElement("WarehouseMaterials");

                foreach (var warehouseMaterial in WarehouseMaterials)
                {
                    xElement.Add(new XElement("WarehouseMaterial",
                    new XAttribute("Id", warehouseMaterial.Id),
                    new XElement("WarehouseId", warehouseMaterial.WarehouseId),
                    new XElement("MaterialId", warehouseMaterial.MaterialId),
                    new XElement("Count", warehouseMaterial.Count)));
                }

                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseMaterialFileName);
            }
        }
    }
}