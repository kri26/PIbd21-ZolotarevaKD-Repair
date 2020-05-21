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
using RepairBusinessLogic.BusinessLogic;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;

namespace RepairView
{
    public partial class FormReportWarehouses : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;

        public FormReportWarehouses(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            dataGridViewWarehouses.Columns.Add("Склад", "Склад");
            dataGridViewWarehouses.Columns.Add("Материал", "Материал");
            dataGridViewWarehouses.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewWarehouses.Columns.Add("Количество", "Количество");
        }
        private void FormReportWarehouses_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = logic.GetWarehouses();
                if (dict != null)
                {
                    dataGridViewWarehouses.Rows.Clear();
                    foreach (var Warehouse in dict)
                    {
                        dataGridViewWarehouses.Rows.Add(Warehouse.WarehouseName, "", "");
                        int totalCount = 0;
                        foreach (var mat in Warehouse.Materials)
                        {
                            dataGridViewWarehouses.Rows.Add("", mat.Key, mat.Value);
                            totalCount += mat.Value;
                        }
                        dataGridViewWarehouses.Rows.Add("Всего", "", totalCount);
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
                        logic.SaveWarehousesToExcelFile(new ReportBindingModel
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