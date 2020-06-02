using DocumentFormat.OpenXml.Office.CustomUI;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RepairWarehouseManager
{
    public partial class FormDisplayWarehouseMaterials : Form
    {
        public int? Id { set; get; }
        public FormDisplayWarehouseMaterials()
        {
            InitializeComponent();
            dataGridViewComponents.Columns.Add("MaterialName", "Материал");
            dataGridViewComponents.Columns.Add("Count", "Количество");
        }

        private void ButtonCancel_Click(object sender, EventArgs args)
        {
            Close();
        }

        private void FormDisplayStorageMaterials_Load(object sender, EventArgs args)
        {
            if (Id.HasValue)
            {
                var model = ApiClient.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getwarehouses")
                    .FirstOrDefault(s => s.Id == Id.Value);
                textBoxNameStorage.Text = model.WarehouseName;
                foreach (var mat in model.WarehouseMaterials)
                {
                    dataGridViewComponents.Rows.Add(mat.Key, mat.Value);
                }
            }
        }
    }
}