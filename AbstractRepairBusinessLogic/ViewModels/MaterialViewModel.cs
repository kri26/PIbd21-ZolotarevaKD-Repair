using RepairBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RepairBusinessLogic.ViewModels
{
    public class MaterialViewModel : BaseViewModel
    {
        public int Id { get; set; }
        [Column(title: "Материал", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string MaterialName { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "MaterialName" };
    }
}
