using RepairBusinessLogic.BindingModels;
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
    public partial class FormWarehouse : Form
    {
        public int? Id { set; get; }

        public FormWarehouse()
        {
            InitializeComponent();
        }

        private void FormStorage_Load(object sender, EventArgs args)
        {
            if (Id.HasValue)
            {
                var model = ApiClient.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getwarehouses")
                    .FirstOrDefault(s => s.Id == Id.Value);
                textBoxStorageName.Text = model.WarehouseName;
            }
        }

        private void ButtonAccept_Click(object sender, EventArgs args)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxStorageName.Text))
                {
                    ApiClient.PostRequest($"api/warehouse/createorupdateWarehouse", new WarehouseBindingModel()
                    {
                        Id = Id ?? null,
                        WarehouseName = textBoxStorageName.Text
                    });
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs args)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}