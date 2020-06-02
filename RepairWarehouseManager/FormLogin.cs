using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepairWarehouseManager
{
    public partial class FormLogin : Form
    {
        public string Password { private set; get; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Button_AcceptEvent(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(textBoxPassword.Text))
            {
                Password = textBoxPassword.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Неправильный пароль!", "Ошибка", MessageBoxButtons.OK);
        }
    }
}