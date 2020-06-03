namespace RepairWarehouseManager
{
    partial class FormDisplayWarehouseMaterials
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            this.textBoxNameStorage = new System.Windows.Forms.TextBox();
            this.labelNameStorage = new System.Windows.Forms.Label();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(322, 261);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(72, 24);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.dataGridViewComponents);
            this.groupBoxComponents.Location = new System.Drawing.Point(12, 37);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Size = new System.Drawing.Size(390, 219);
            this.groupBoxComponents.TabIndex = 11;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Материалы";
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.Location = new System.Drawing.Point(8, 17);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            this.dataGridViewComponents.Size = new System.Drawing.Size(374, 196);
            this.dataGridViewComponents.TabIndex = 0;
            // 
            // textBoxNameStorage
            // 
            this.textBoxNameStorage.Location = new System.Drawing.Point(85, 4);
            this.textBoxNameStorage.Name = "textBoxNameStorage";
            this.textBoxNameStorage.Size = new System.Drawing.Size(173, 20);
            this.textBoxNameStorage.TabIndex = 9;
            this.textBoxNameStorage.Enabled = false;
            // 
            // labelNameStorage
            // 
            this.labelNameStorage.AutoSize = true;
            this.labelNameStorage.Location = new System.Drawing.Point(19, 7);
            this.labelNameStorage.Name = "labelNameStorage";
            this.labelNameStorage.Size = new System.Drawing.Size(60, 13);
            this.labelNameStorage.TabIndex = 7;
            this.labelNameStorage.Text = "Название:";
            // 
            // FormDisplayStorageMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 287);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxNameStorage);
            this.Controls.Add(this.labelNameStorage);
            this.Name = "FormDisplayStorageMaterials";
            this.Text = "Хранилище";
            this.Load += new System.EventHandler(this.FormDisplayStorageMaterials_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxComponents;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
        private System.Windows.Forms.TextBox textBoxNameStorage;
        private System.Windows.Forms.Label labelNameStorage;
    }
}