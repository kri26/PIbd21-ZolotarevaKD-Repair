using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using RepairBusinessLogic.BusinessLogic;

namespace RepairView
{
    public partial class FormReplenishWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MainLogic logic;
        private readonly IMaterialLogic materialLogic;
        private readonly IWarehouseLogic warehouseLogic;

        public FormReplenishWarehouse(MainLogic logic, IMaterialLogic componenmtLogic, IWarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.materialLogic = componenmtLogic;
            this.warehouseLogic = warehouseLogic;
        }

        private void FormReplenishWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                List<MaterialViewModel> list = materialLogic.Read(null);
                if (list != null)
                {
                    comboBoxMaterial.DisplayMember = "MaterialName";
                    comboBoxMaterial.ValueMember = "Id";
                    comboBoxMaterial.DataSource = list;
                    comboBoxMaterial.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                List<WarehouseViewModel> list = warehouseLogic.Read(null);
                if (list != null)
                {
                    comboBoxWarehouse.DisplayMember = "WarehouseName";
                    comboBoxWarehouse.ValueMember = "Id";
                    comboBoxWarehouse.DataSource = list;
                    comboBoxWarehouse.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxMaterial.SelectedValue == null)
            {
                MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.ReplanishWarehouse(new WarehouseMaterialBindingModel
                {
                    Id = 0,
                    WarehouseId = Convert.ToInt32(comboBoxWarehouse.SelectedValue),
                    MaterialId = Convert.ToInt32(comboBoxMaterial.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });

                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
