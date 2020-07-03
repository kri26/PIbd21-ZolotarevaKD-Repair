using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepairWarehouseManager
{
    static class Program
    {
        public static bool IsLogined { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApiClient.Connect();
            var form = new FormLogin();
             if (IsLogined)
            {
                Application.Run(new FormMain());
            }
            else
                MessageBox.Show("Ïàðîëü íåâåðíûé!", "Îøèáêà", MessageBoxButtons.OK);
        }
    }
}
