using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.BusinessLogic;
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace RepairView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IRepairWorkLogic logicA;
        private readonly MainLogic logicM;
        public FormCreateOrder(IRepairWorkLogic logicA, MainLogic logicM)
        {
            InitializeComponent();
            this.logicA = logicA;
            this.logicM = logicM;
        }

        private void comboBoxRepairWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void CalcSum()
        {
            if (comboBoxRepairWork.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxRepairWork.SelectedValue);
                    RepairWorkViewModel repairWork = logicA.Read(new RepairWorkBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * repairWork?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<RepairWorkViewModel> list = logicA.Read(null);
                if (list != null)
                {
                    comboBoxRepairWork.DisplayMember = "RepairWorkName";
                    comboBoxRepairWork.ValueMember = "Id";
                    comboBoxRepairWork.DataSource = list;
                    comboBoxRepairWork.SelectedItem = null;
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
            if (comboBoxRepairWork.SelectedValue == null)
            {
                MessageBox.Show("Выберите сборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    RepairWorkId = Convert.ToInt32(comboBoxRepairWork.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
