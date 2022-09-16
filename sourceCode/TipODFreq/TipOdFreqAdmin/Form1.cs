using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipOdFreqAdmin
{
    public partial class Form1 : Form
    {
        Timer nT = new Timer();
        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nT.Interval = 100;
            nT.Enabled = true;
            nT.Tick += NT_Tick;
        }

        private void NT_Tick(object sender, EventArgs e)
        {
            Timer _nt = (Timer)sender;

            _nt.Enabled = false;

            if (labStatus.InvokeRequired)
            {
                labStatus.Invoke(new Action(()=> {
                    labStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                }));
            }
            else
                labStatus.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            _nt.Enabled = true;
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            try
            {
                int countExecute = 0;

                #region Tip Od Freq
                string[] lines = System.IO.File.ReadAllLines(GlobalVariables.PathOd);

                if (lines.Count() > 0)
                {
                    var dataTip = new List<tblTipOdFreqModel>();

                    int index = 0;
                    foreach (string line in lines)
                    {
                        if (index != 0)
                        {
                            string[] columns = line.Split(',');
                            dataTip.Add(new tblTipOdFreqModel()
                            {
                                ItemNumber = columns[0],
                                FreqTarget = int.TryParse(columns[1], out int value) ? value : 0,
                                DiamLL = double.TryParse(columns[2], out double value1) ? value1 : 0,
                                DiamUL = double.TryParse(columns[3], out value1) ? value1 : 0,
                                TipOdLength = columns[4],
                                FormulaGId = int.TryParse(columns[5], out value) ? value : 0,
                                FormulaPoId = int.TryParse(columns[6], out value) ? value : 0,
                            });
                        }
                        index += 1;
                    }

                    using (var connection = GlobalVariables.GetDbConnection())
                    {
                        connection.Execute("delete tblTipOdFreq");

                        var count = connection.Execute(@"insert tblTipOdFreq (ItemNumber, FreqTarget, DiamLL,DiamUL,TipOdLength,FormulaGId,FormulaPoId) 
                                                    values (@ItemNumber, @Freqtarget,@DiamLL,@DiamUL,@TipOdLength,@FormulaGId,@FormulaPoId)", dataTip);

                        if (dataTip.Count() == count)
                        {
                            countExecute += 1;
                        }
                    }
                }
                #endregion

                #region Formula G
                //lines = System.IO.File.ReadAllLines(GlobalVariables.PathFormulaG);

                //if (lines.Count() > 0)
                //{
                //    var dataFormulaG = new List<tblFormulaGModel>();

                //    int index = 0;
                //    foreach (string line in lines)
                //    {
                //        if (index != 0)
                //        {
                //            string[] columns = line.Split(',');
                //            dataFormulaG.Add(new tblFormulaGModel()
                //            {
                //                Id = int.TryParse(columns[0], out int value) ? value : 0,
                //                U = int.TryParse(columns[1], out value) ? value : 0,
                //                V = int.TryParse(columns[2], out value) ? value : 0,
                //                X = double.TryParse(columns[3], out double value1) ? value1 : 0,
                //                Y = double.TryParse(columns[4], out value1) ? value1 : 0,
                //                Z = int.TryParse(columns[5], out value) ? value : 0,
                //                P = int.TryParse(columns[6], out value) ? value : 0,
                //            });
                //        }
                //        index += 1;
                //    }

                //    using (var connection = GlobalVariables.GetDbConnection())
                //    {
                //        connection.Execute("delete tblFormulaG");

                //        var count = connection.Execute(@"insert tblFormulaG (Id, U, V,X,Y,Z,P) 
                //                                        values (@Id, @U,@V,@X,@Y,@Z,@P)", dataFormulaG);

                //        if (dataFormulaG.Count() == count)
                //        {
                //            countExecute += 1;
                //        }
                //    }
                //}
                #endregion

                #region Formula PO
                //lines = System.IO.File.ReadAllLines(GlobalVariables.PathFormulaPo);

                //if (lines.Count() > 0)
                //{
                //    var dataFormulaPo = new List<tblFormulaPoModel>();

                //    int index = 0;
                //    foreach (string line in lines)
                //    {
                //        if (index != 0)
                //        {
                //            string[] columns = line.Split(',');
                //            dataFormulaPo.Add(new tblFormulaPoModel()
                //            {
                //                Id = int.TryParse(columns[0], out int value) ? value : 0,
                //                U = int.TryParse(columns[1], out value) ? value : 0,
                //                V = int.TryParse(columns[2], out value) ? value : 0,
                //                X = double.TryParse(columns[3], out double value1) ? value1 : 0,
                //                Y = double.TryParse(columns[4], out value1) ? value1 : 0,
                //                Z = int.TryParse(columns[5], out value) ? value : 0,
                //                P = int.TryParse(columns[6], out value) ? value : 0,
                //            });
                //        }
                //        index += 1;
                //    }

                //    using (var connection = GlobalVariables.GetDbConnection())
                //    {
                //        connection.Execute("delete tblFormulaPo");

                //        var count = connection.Execute(@"insert tblFormulaPo (Id, U, V,X,Y,Z,P) 
                //                                        values (@Id, @U,@V,@X,@Y,@Z,@P)", dataFormulaPo);

                //        if (dataFormulaPo.Count() == count)
                //        {
                //            countExecute += 1;
                //        }
                //    }
                //}
                #endregion

                if (countExecute == 1)
                {
                    MessageBox.Show("Impport data successfull.");
                }
                else
                {
                    MessageBox.Show("Fail.");
                }
            }
            catch
            {

            }
        }
    }
}
