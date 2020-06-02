using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RepairWarehouseManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Load_Data();
        }

        private void Load_Data()
        {
            try
            {
                dataGridViewStorages.DataSource =
                    ApiClient.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getwarehouses");
                dataGridViewStorages.Columns[0].Visible = false;
                dataGridViewStorages.Columns[2].Visible = false;
                dataGridViewStorages.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ButtonAddStorage_Click(object sender, EventArgs args)
        {
            var form = new FormWarehouse();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Load_Data();
            }
        }

        private void ButtonEditStorage_Click(object sender, EventArgs args)
        {
            if (dataGridViewStorages.SelectedRows.Count == 1)
            {
                var form = new FormWarehouse();
                form.Id = Convert.ToInt32(dataGridViewStorages.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Load_Data();
                }
            }
        }

        private void ButtonDelStorage_Click(object sender, EventArgs args)
        {
            try
            {
                if (dataGridViewStorages.SelectedRows.Count == 1)
                {
                    ApiClient.PostRequest($"api/warehouse/deletewarehouse", new WarehouseBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridViewStorages.SelectedRows[0].Cells[0].Value)
                    });
                    Load_Data();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ButtonAddMaterial_Click(object sender, EventArgs args)
        {
            var form = new FormAddMaterial();
            form.Show();
        }

        private void ButtonShowMaterials_Click(object sender, EventArgs args)
        {
            if (dataGridViewStorages.SelectedRows.Count == 1)
            {
                var form = new FormDisplayWarehouseMaterials();
                form.Id = Convert.ToInt32(dataGridViewStorages.SelectedRows[0].Cells[0].Value);
                form.Show();
            }
        }
    }
}