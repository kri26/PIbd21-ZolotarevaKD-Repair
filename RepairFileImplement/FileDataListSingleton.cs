using RepairBusinessLogic.Enums;
using RepairFileImplement.Models;
using RepairListImplemen.Models;
using RepairListImplement.Models;
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
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        public List<Material> Materials { get; set; }
        public List<Order> Orders { get; set; }
        public List<RepairWork> RepairWorks { get; set; }
        public List<RepairWorkMaterial> RepairWorkMaterials { get; set; }
        public List<Models.Client> Clients { set; get; }
        public List<Implementer> Implementers { set; get; }
        private FileDataListSingleton()
        {
            Materials = LoadMaterials();
            Orders = LoadOrders();
            RepairWorks = LoadRepairWorks();
            RepairWorkMaterials = LoadRepairWorkMaterials();
            Clients = LoadClients();
            Implementers = LoadImplementers();
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
            SaveClients();
            SaveImplementers();
        }

        private List<Models.Client> LoadClients()
        {
            var list = new List<Models.Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Models.Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
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
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementor").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value
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
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
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
        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MaterialFileName);
            }
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
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
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
    }
}