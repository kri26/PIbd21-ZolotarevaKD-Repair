using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Unity;
using RepairBusinessLogic.BusinessLogic;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;

namespace RepairView
{
    public partial class FormReportRepairWorkOrders : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportRepairWorkOrders(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridViewMaterialToRepairWork.Columns.Add("Дата", "Дата");
            dataGridViewMaterialToRepairWork.Columns.Add("Заказ", "Заказ");
            dataGridViewMaterialToRepairWork.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewMaterialToRepairWork.Columns.Add("Сумма заказа", "Сумма заказа");
        }
        private void FormReportMaterialsToRepairWorks_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetOrders();
                if (dict != null)
                {
                    Dictionary<string, List<ReportOrdersViewModel>> dictOrders = new Dictionary<string, List<ReportOrdersViewModel>>();
                    dataGridViewMaterialToRepairWork.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        if (!dictOrders.ContainsKey(elem.DateCreate.ToShortDateString()))
                            dictOrders.Add(elem.DateCreate.ToShortDateString(), new List<ReportOrdersViewModel>() { elem });
                        else
                            dictOrders[elem.DateCreate.ToShortDateString()].Add(elem);
                    }
                    foreach (var order in dictOrders)
                    {
                        dataGridViewMaterialToRepairWork.Rows.Add(order.Key, "", "");
                        decimal totalPrice = 0;
                        foreach (var RepairWork in order.Value)
                        {
                            dataGridViewMaterialToRepairWork.Rows.Add("", RepairWork.RepairWorkName, RepairWork.Sum);
                            totalPrice += RepairWork.Sum;
                        }
                        dataGridViewMaterialToRepairWork.Rows.Add("Всего", "", totalPrice);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveProductComponentToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}