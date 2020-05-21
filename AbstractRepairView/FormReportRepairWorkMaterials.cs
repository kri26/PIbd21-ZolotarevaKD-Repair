﻿using System;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;
using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.BusinessLogic;
using System.Windows.Forms;
using Unity;

namespace RepairView
{
    public partial class FormReportRepairWorkMaterials : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly ReportLogic logic;

        public FormReportRepairWorkMaterials(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveRepairWorkMaterialsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
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

        private void reportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetRepairWorkMaterial();
                ReportDataSource source = new ReportDataSource("DataSetRepairWorkMaterial", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormReportRepairWorkMaterials_Load(object sender, EventArgs e)
        {

        }
    }
}
