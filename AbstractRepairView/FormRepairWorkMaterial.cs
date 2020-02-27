using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace RepairView
{
    public partial class FormRepairWorkMaterial : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxMaterial.SelectedValue); }
            set { comboBoxMaterial.SelectedValue = value; }
        }
        public string ComponentName
        {
            get { return comboBoxMaterial.Text; }
        }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set { textBoxCount.Text = value.ToString(); }
        }
        public FormRepairWorkMaterial(IMaterialLogic logic)
        {
            InitializeComponent();
            List<MaterialViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxMaterial.DisplayMember = "MaterialName";
                comboBoxMaterial.ValueMember = "Id";
                comboBoxMaterial.DataSource = list;
                comboBoxMaterial.SelectedItem = null;
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
                MessageBox.Show("Выберите деталь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
