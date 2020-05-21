using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using RepairBusinessLogic.Enums;
using System.Runtime.Serialization;

namespace RepairBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int RepairWorkId { get; set; }
        [DataMember]
        [DisplayName("Ремонтные работы")]
        public string RepairWorkName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public int ClientId { set; get; }
        [DataMember]
        [DisplayName("ФИО клиента")]
        public string ClientFIO { set; get; }
    }
}
