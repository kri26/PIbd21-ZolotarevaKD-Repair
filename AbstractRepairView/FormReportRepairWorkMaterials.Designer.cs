namespace AbstractRepairView
{
    partial class FormReportRepairWorkMaterials
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AbstractRepairView.ReportOrders.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(4, 62);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1377, 658);
            this.reportViewer.TabIndex = 1;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load);
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(16, 15);
            this.ButtonToPdf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(183, 28);
            this.ButtonToPdf.TabIndex = 6;
            this.ButtonToPdf.Text = "В PDF";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // FormReportRepairWorkMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 724);
            this.Controls.Add(this.ButtonToPdf);
            this.Controls.Add(this.reportViewer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormReportRepairWorkMaterials";
            this.Text = "Компоненты и изделия";
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.Button ButtonToPdf;
    }
}