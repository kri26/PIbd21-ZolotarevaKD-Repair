namespace RepairView
{
    partial class FormReportMaterialWarehouses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerMaterialWarehouses = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonMakePdfMaterialStorages = new System.Windows.Forms.Button();
            this.buttonMakeReportMaterialStorages = new System.Windows.Forms.Button();
            this.ReportMaterialWarehouseViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportMaterialWarehouseViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerMaterialWarehouses
            // 
            reportDataSource1.Name = "DataSetMaterialWarehouse";
            reportDataSource1.Value = this.ReportMaterialWarehouseViewModelBindingSource;
            this.reportViewerMaterialWarehouses.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerMaterialWarehouses.LocalReport.ReportEmbeddedResource = "AbstractRepairView.ReportMaterialWarehouses.rdlc";
            this.reportViewerMaterialWarehouses.Location = new System.Drawing.Point(-1, 42);
            this.reportViewerMaterialWarehouses.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewerMaterialWarehouses.Name = "reportViewerMaterialWarehouses";
            this.reportViewerMaterialWarehouses.ServerReport.BearerToken = null;
            this.reportViewerMaterialWarehouses.Size = new System.Drawing.Size(802, 403);
            this.reportViewerMaterialWarehouses.TabIndex = 7;
            // 
            // buttonMakePdfMaterialStorages
            // 
            this.buttonMakePdfMaterialStorages.Location = new System.Drawing.Point(421, 6);
            this.buttonMakePdfMaterialStorages.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMakePdfMaterialStorages.Name = "buttonMakePdfMaterialStorages";
            this.buttonMakePdfMaterialStorages.Size = new System.Drawing.Size(112, 25);
            this.buttonMakePdfMaterialStorages.TabIndex = 6;
            this.buttonMakePdfMaterialStorages.Text = "В PDF";
            this.buttonMakePdfMaterialStorages.UseVisualStyleBackColor = true;
            this.buttonMakePdfMaterialStorages.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // buttonMakeReportMaterialStorages
            // 
            this.buttonMakeReportMaterialStorages.Location = new System.Drawing.Point(248, 6);
            this.buttonMakeReportMaterialStorages.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMakeReportMaterialStorages.Name = "buttonMakeReportMaterialStorages";
            this.buttonMakeReportMaterialStorages.Size = new System.Drawing.Size(124, 25);
            this.buttonMakeReportMaterialStorages.TabIndex = 5;
            this.buttonMakeReportMaterialStorages.Text = "Сформировать";
            this.buttonMakeReportMaterialStorages.UseVisualStyleBackColor = true;
            this.buttonMakeReportMaterialStorages.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // ReportMaterialWarehouseViewModelBindingSource
            // 
            this.ReportMaterialWarehouseViewModelBindingSource.DataSource = typeof(RepairBusinessLogic.ViewModels.ReportMaterialWarehouseViewModel);
            // 
            // FormReportMaterialWarehouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 441);
            this.Controls.Add(this.reportViewerMaterialWarehouses);
            this.Controls.Add(this.buttonMakePdfMaterialStorages);
            this.Controls.Add(this.buttonMakeReportMaterialStorages);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReportMaterialWarehouses";
            this.Text = "Материал в хранилищах";
            this.Load += new System.EventHandler(this.FormReportMaterialWarehouses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportMaterialWarehouseViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerMaterialWarehouses;
        private System.Windows.Forms.Button buttonMakePdfMaterialStorages;
        private System.Windows.Forms.Button buttonMakeReportMaterialStorages;
        private System.Windows.Forms.BindingSource ReportMaterialWarehouseViewModelBindingSource;
    }
}