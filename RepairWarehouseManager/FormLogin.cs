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
                if (textBoxPassword.Text == ConfigurationManager.AppSettings["Password"])
                {
                    Program.IsLogined = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButtons.OK);
        }
    }
}
