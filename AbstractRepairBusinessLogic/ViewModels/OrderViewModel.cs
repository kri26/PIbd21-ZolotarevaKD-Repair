using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using RepairBusinessLogic.Enums;
using System.Runtime.Serialization;
using RepairBusinessLogic.Attributes;

namespace RepairBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel : BaseViewModel
    {
        [DataMember]
        public int RepairWorkId { get; set; }
        [DataMember]
        [Column(title: "Ремонтные работы", gridViewAutoSize: GridViewAutoSize.DisplayedCells)]
        public string RepairWorkName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }
        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerFIO { set; get; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public int ClientId { set; get; }
        [DataMember]
        [Column(title: "ФИО Клиента", width: 150)]
        public string ClientFIO { set; get; }
        [DataMember]
        public int? ImplementorId { set; get; }
        public override List<string> Properties() => new List<string> { "Id",
        "ClientFIO", "RepairWorkName", "ImplementerFIO", "Count", "Sum", "Status", "DateCreate", "DateImplement" };
    }
}
