namespace RepairWarehouseManager
{
    partial class FormMain
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
            this.dataGridViewStorages = new System.Windows.Forms.DataGridView();
            this.buttonAddStorage = new System.Windows.Forms.Button();
            this.buttonEditStorage = new System.Windows.Forms.Button();
            this.buttonDelStorage = new System.Windows.Forms.Button();
            this.buttonAddMaterial = new System.Windows.Forms.Button();
            this.buttonShowMaterials = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStorages
            // 
            this.dataGridViewStorages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStorages.Location = new System.Drawing.Point(1, 2);
            this.dataGridViewStorages.Name = "dataGridViewStorages";
            this.dataGridViewStorages.Size = new System.Drawing.Size(369, 288);
            this.dataGridViewStorages.TabIndex = 0;
            // 
            // buttonAddStorage
            // 
            this.buttonAddStorage.Location = new System.Drawing.Point(376, 12);
            this.buttonAddStorage.Name = "buttonAddStorage";
            this.buttonAddStorage.Size = new System.Drawing.Size(100, 26);
            this.buttonAddStorage.TabIndex = 1;
            this.buttonAddStorage.Text = "Создать";
            this.buttonAddStorage.UseVisualStyleBackColor = true;
            this.buttonAddStorage.Click += new System.EventHandler(this.ButtonAddStorage_Click);
            // 
            // buttonEditStorage
            // 
            this.buttonEditStorage.Location = new System.Drawing.Point(376, 44);
            this.buttonEditStorage.Name = "buttonEditStorage";
            this.buttonEditStorage.Size = new System.Drawing.Size(100, 26);
            this.buttonEditStorage.TabIndex = 2;
            this.buttonEditStorage.Text = "Изменить";
            this.buttonEditStorage.UseVisualStyleBackColor = true;
            this.buttonEditStorage.Click += new System.EventHandler(this.ButtonEditStorage_Click);
            // 
            // buttonDelStorage
            // 
            this.buttonDelStorage.Location = new System.Drawing.Point(376, 76);
            this.buttonDelStorage.Name = "buttonDelStorage";
            this.buttonDelStorage.Size = new System.Drawing.Size(100, 26);
            this.buttonDelStorage.TabIndex = 3;
            this.buttonDelStorage.Text = "Удалить";
            this.buttonDelStorage.UseVisualStyleBackColor = true;
            this.buttonDelStorage.Click += new System.EventHandler(this.ButtonDelStorage_Click);
            // 
            // buttonAddMaterial
            // 
            this.buttonAddMaterial.Location = new System.Drawing.Point(376, 175);
            this.buttonAddMaterial.Name = "buttonAddMaterial";
            this.buttonAddMaterial.Size = new System.Drawing.Size(100, 26);
            this.buttonAddMaterial.TabIndex = 4;
            this.buttonAddMaterial.Text = "Пополнить";
            this.buttonAddMaterial.UseVisualStyleBackColor = true;
            this.buttonAddMaterial.Click += new System.EventHandler(this.ButtonAddMaterial_Click);
            // 
            // buttonShowMaterial
            // 
            this.buttonShowMaterials.Location = new System.Drawing.Point(376, 220);
            this.buttonShowMaterials.Name = "buttonShowMaterial";
            this.buttonShowMaterials.Size = new System.Drawing.Size(100, 26);
            this.buttonShowMaterials.TabIndex = 5;
            this.buttonShowMaterials.Text = "Материалы";
            this.buttonShowMaterials.UseVisualStyleBackColor = true;
            this.buttonShowMaterials.Click += new System.EventHandler(this.ButtonShowMaterials_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 293);
            this.Controls.Add(this.buttonAddMaterial);
            this.Controls.Add(this.buttonDelStorage);
            this.Controls.Add(this.buttonEditStorage);
            this.Controls.Add(this.buttonAddStorage);
            this.Controls.Add(this.dataGridViewStorages);
            this.Controls.Add(this.buttonShowMaterials);
            this.Name = "FormMain";
            this.Text = "Менеджер складов";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStorages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStorages;
        private System.Windows.Forms.Button buttonAddStorage;
        private System.Windows.Forms.Button buttonEditStorage;
        private System.Windows.Forms.Button buttonDelStorage;
        private System.Windows.Forms.Button buttonAddMaterial;
        private System.Windows.Forms.Button buttonShowMaterials;
    }
}