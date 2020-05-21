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
using RepairBusinessLogic.Interfaces;
using RepairBusinessLogic.ViewModels;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.BusinessLogic;

namespace RepairView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IRepairWorkLogic logicP;
        private readonly IClientLogic logicC;
        private readonly MainLogic logicM;

        public FormCreateOrder(IRepairWorkLogic logicP, MainLogic logicM, IClientLogic logicC)
        {
            InitializeComponent();
            this.logicP = logicP;
            this.logicM = logicM;
            this.logicC = logicC;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                //Логика загрузки списка компонент в выпадающий список
                var listRepairWorkes = logicP.Read(null);
                if (listRepairWorkes != null)
                {
                    comboBoxProduct.DisplayMember = "RepairWorkName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = listRepairWorkes;
                    comboBoxProduct.SelectedItem = null;
                }

                var listClients = logicC.Read(null);
                if (listClients != null)
                {
                    comboBoxClients.DisplayMember = "ClientFIO";
                    comboBoxClients.DataSource = listClients;
                    comboBoxClients.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    RepairWorkViewModel product = logicP.Read(new RepairWorkBindingModel
                    {
                        Id = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ComboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClients.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    RepairWorkId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    ClientId = (comboBoxClients.SelectedItem as ClientViewModel).Id,
                    ClientFIO = (comboBoxClients.SelectedItem as ClientViewModel).ClientFIO
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}