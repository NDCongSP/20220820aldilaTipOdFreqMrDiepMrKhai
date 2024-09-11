using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipODFreq
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                MessageBox.Show("Ứng dụng đang mở, không được mở lại.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region Đọc các thông số cấu hình ban đầu từ settings
            GlobalVariables.ConnectionString = EncodeMD5.DecryptString(Properties.Settings.Default.ConString, "@Aldila@123");

            GlobalVariables.PathApp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GlobalVariables.PathOd = Properties.Settings.Default.PathCsvDataOd;
            GlobalVariables.PathFormulaG = Properties.Settings.Default.PathCsvDataFormulaG;
            GlobalVariables.PathFormulaPo = Properties.Settings.Default.PathCsvDataFormulaPo;

            GlobalVariables.ShaftNumSanding = Properties.Settings.Default.ShaftNumSanding;
            GlobalVariables.ShaftNumOd = Properties.Settings.Default.ShaftNumOd;
            GlobalVariables.ShaftNumPolishing = Properties.Settings.Default.ShaftNumPolishing;
            GlobalVariables.ShaftNumSave = Properties.Settings.Default.ShaftNumSave;

            //Console.WriteLine($"Path app: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}");
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
