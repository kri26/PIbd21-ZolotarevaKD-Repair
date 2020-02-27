using RepairBusinessLogic.BindingModels;
using RepairBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairBusinessLogic.Interfaces;
using Unity;

namespace RepairView
{
    public partial class FormRepairWork : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IRepairWorkLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> repairWorkMaterials;
        public FormRepairWork(IRepairWorkLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            repairWorkMaterials = new Dictionary<int, (string, int)>();
            var form = Container.Resolve<FormRepairWorkMaterial>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (repairWorkMaterials.ContainsKey(form.Id))
                {
                    repairWorkMaterials[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    repairWorkMaterials.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormRepairWorkMaterial>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = repairWorkMaterials[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    repairWorkMaterials[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        repairWorkMaterials.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (repairWorkMaterials == null || repairWorkMaterials.Count == 0)
            {
                MessageBox.Show("Заполните детали", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new RepairWorkBindingModel
                {
                    Id = id,
                    RepairWorkName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    RepairWorkMaterials = repairWorkMaterials
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormRepairWork_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RepairWorkViewModel view = logic.Read(new RepairWorkBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.RepairWorkName;
                        textBoxPrice.Text = view.Price.ToString();
                        repairWorkMaterials = view.RepairWorkMaterials;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                repairWorkMaterials = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("MaterialName", "Материал");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            try
            {
                if (repairWorkMaterials != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var ad in repairWorkMaterials)
                    {
                        dataGridView.Rows.Add(new object[] { ad.Key, ad.Value.Item1, ad.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
