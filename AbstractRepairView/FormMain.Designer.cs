namespace RepairView
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМатериаловToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыПоРемонтуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыПоСкладамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.материалыНаСкладахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хранилищаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(-3, 23);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(769, 228);
            this.dataGridView.TabIndex = 0;
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(938, 24);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem,
            this.складыToolStripMenuItem });
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.компонентыToolStripMenuItem.Text = "Материалы";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.MaterialsToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.изделияToolStripMenuItem.Text = "Ремонтные работы";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.RepairWorksToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.WarehouseToolStripMenuItem_Click);
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.AddWarehouseToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокМатериаловToolStripMenuItem,
            this.материалыПоРемонтуToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.материалыПоСкладамToolStripMenuItem,
            this.материалыНаСкладахToolStripMenuItem,
            this.хранилищаToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокМатериаловToolStripMenuItem
            // 
            this.списокМатериаловToolStripMenuItem.Name = "списокМатериаловToolStripMenuItem";
            this.списокМатериаловToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.списокМатериаловToolStripMenuItem.Text = "Ремонтные работы";
            this.списокМатериаловToolStripMenuItem.Click += new System.EventHandler(this.списокМатериаловToolStripMenuItem_Click);
            // 
            // материалыПоРемонтуToolStripMenuItem
            // 
            this.материалыПоРемонтуToolStripMenuItem.Name = "материалыПоРемонтуToolStripMenuItem";
            this.материалыПоРемонтуToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.материалыПоРемонтуToolStripMenuItem.Text = "Заказы по ремонту";
            this.материалыПоРемонтуToolStripMenuItem.Click += new System.EventHandler(this.материалыПоРемонтуToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Материалы по ремонту";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // материалыПоСкладамToolStripMenuItem
            // 
            this.материалыПоСкладамToolStripMenuItem.Name = "материалыПоСкладамToolStripMenuItem";
            this.материалыПоСкладамToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.материалыПоСкладамToolStripMenuItem.Text = "Материалы по складам";
            this.материалыПоСкладамToolStripMenuItem.Click += new System.EventHandler(this.материалыПоСкладамToolStripMenuItem_Click);
            // 
            // материалыНаСкладахToolStripMenuItem
            // 
            this.материалыНаСкладахToolStripMenuItem.Name = "материалыНаСкладахToolStripMenuItem";
            this.материалыНаСкладахToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.материалыНаСкладахToolStripMenuItem.Text = "Материалы на складах";
            this.материалыНаСкладахToolStripMenuItem.Click += new System.EventHandler(this.материалыНаСкладахToolStripMenuItem_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(772, 22);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(154, 26);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(772, 210);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(154, 26);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Обновить список";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // хранилищаToolStripMenuItem
            // 
            this.хранилищаToolStripMenuItem.Name = "хранилищаToolStripMenuItem";
            this.хранилищаToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.хранилищаToolStripMenuItem.Text = "Хранилища";
            this.хранилищаToolStripMenuItem.Click += new System.EventHandler(this.хранилищаToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 251);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "FormMain";
            this.Text = "Ремонт ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridView;
    private new System.Windows.Forms.MenuStrip Menu;
    private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem компонентыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
    private System.Windows.Forms.Button buttonCreateOrder;
    private System.Windows.Forms.Button buttonRefresh;
    private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem списокМатериаловToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem материалыПоРемонтуToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem материалыПоСкладамToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem материалыНаСкладахToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem хранилищаToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
    
    }
}