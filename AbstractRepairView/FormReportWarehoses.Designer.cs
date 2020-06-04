namespace RepairView
{
    partial class FormReportWarehouses
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
            this.buttonSaveToExcelWarehouses = new System.Windows.Forms.Button();
            this.dataGridViewWarehouses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouses)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveToExcelWarehouses
            // 
            this.buttonSaveToExcelWarehouses.Location = new System.Drawing.Point(12, 2);
            this.buttonSaveToExcelWarehouses.Name = "buttonSaveToExcelWarehouses";
            this.buttonSaveToExcelWarehouses.Size = new System.Drawing.Size(137, 23);
            this.buttonSaveToExcelWarehouses.TabIndex = 3;
            this.buttonSaveToExcelWarehouses.Text = "Сохранить в Excel";
            this.buttonSaveToExcelWarehouses.UseVisualStyleBackColor = true;
            this.buttonSaveToExcelWarehouses.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // dataGridViewWarehouses
            // 
            this.dataGridViewWarehouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouses.Location = new System.Drawing.Point(-1, 31);
            this.dataGridViewWarehouses.Name = "dataGridViewWarehouses";
            this.dataGridViewWarehouses.Size = new System.Drawing.Size(514, 418);
            this.dataGridViewWarehouses.TabIndex = 2;
            // 
            // FormReportWarehouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 450);
            this.Controls.Add(this.buttonSaveToExcelWarehouses);
            this.Controls.Add(this.dataGridViewWarehouses);
            this.Name = "FormReportWarehouses";
            this.Text = "Отчет по сладам";
            this.Load += new System.EventHandler(this.FormReportWarehouses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveToExcelWarehouses;
        private System.Windows.Forms.DataGridView dataGridViewWarehouses;
    }
}