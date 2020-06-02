using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
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
    public partial class FormAddMaterial : Form
    {
        public FormAddMaterial()
        {
            InitializeComponent();
        }

        private void Load_Data(object sender, EventArgs args)
        {
            try
            {
                comboBoxStorages.DataSource = ApiClient.GetRequest<List<WarehouseViewModel>>($"api/warehouse/getwarehouses");
                comboBoxStorages.DisplayMember = "WarehouseName";
                comboBoxComponent.DataSource = ApiClient.GetRequest<List<MaterialViewModel>>($"api/main/getmaterials");
                comboBoxComponent.DisplayMember = "MaterialName";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs args)
        {
            try
            {
                if (comboBoxStorages.SelectedItem != null && comboBoxComponent.SelectedItem != null &&
                    !string.IsNullOrEmpty(textBoxCountComponent.Text))
                {
                    ApiClient.PostRequest($"api/storage/addmaterialtowarehouse",
                        new WarehouseMaterialBindingModel()
                        {
                            WarehouseId = (comboBoxStorages.SelectedItem as WarehouseViewModel).Id,
                            MaterialId = (comboBoxComponent.SelectedItem as MaterialViewModel).Id,
                            Count = Convert.ToInt32(textBoxCountComponent.Text)
                        });
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
            Close();
        }
    }
}