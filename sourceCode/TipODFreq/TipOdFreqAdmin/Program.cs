using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipOdFreqAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Đọc các thông số cấu hình ban đầu từ settings
            GlobalVariables.ConnectionString = EncodeMD5.DecryptString(Properties.Settings.Default.ConString, "@Aldila@123");

            GlobalVariables.PathApp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            GlobalVariables.PathOd = Properties.Settings.Default.PathCsvDataOd;
            GlobalVariables.PathFormulaG = Properties.Settings.Default.PathCsvDataFormulaG;
            GlobalVariables.PathFormulaPo = Properties.Settings.Default.PathCsvDataFormulaPo;

            //Console.WriteLine($"Path app: {Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}");
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
