using Dapper;
using EasyScada.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipODFreq
{
    public partial class Form1 : Form
    {
        #region Properties
        private List<PartInfoModel> partInfo = new List<PartInfoModel>();
        private string partNum = null;

        char[] partNumChar = new char[10];//chứa các ký tự convert từ HMI truyền về

        bool sendData = false;//khi co barcode mới thì bật bit này lên để get data từ SQL truyền xuống cho máy chạy part mới.

        Timer t = new Timer();
        #endregion

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            easyDriverConnector1.Started += EasyDriverConnector1_Started;

            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            Timer _t = (Timer)sender;
            t.Enabled = false;

            if (sendData)
            {
                if (labPartNum.InvokeRequired)
                {
                    labPartNum.Text = partNum;
                }
                else
                {
                    labPartNum.Text = partNum;
                }

                //get data partInfo
                using (var connection = GlobalVariables.GetDbConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@partNum", partNum);

                    partInfo = connection.Query<PartInfoModel>("sp_GetFullPartInfo", para, commandType: CommandType.StoredProcedure).ToList();
                }

                //ghi các giá trị cài đặt xuống các PLC
                if (partInfo.Count > 0)
                {
                    gridPartInfo.DataSource = partInfo;

                    #region Station1 HMI 1 cổng LAN
                    easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FreqTarget", partInfo[0].Freq.ToString(), WritePiority.Default);
                    easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGId", partInfo[0].FormulaGId.ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGU", partInfo[0].GU.ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGV", partInfo[0].GV.ToString(), WritePiority.Default);
                    ////số thập phân, 3 số lẻ, nên nhân 1000 để thành số nguyên để truyền xuống PLC. dưới PLC đọc chia 1000 để ra số liệu thực.
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGX", (partInfo[0].GX * 1000).ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGY", (partInfo[0].GY * 1000).ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGZ", partInfo[0].GZ.ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGP", (partInfo[0].GP * 1000).ToString(), WritePiority.Default);
                    #endregion

                    #region Station2 PLC, truyền thông modbus RTU Id 1
                    var index = 1;
                    foreach (var item in partInfo)
                    {
                        easyDriverConnector1.WriteTagAsync($"Local Station/Station23/Station2Plc/DiamLL{index}", (item.DiamLL * 100).ToString(), WritePiority.Default);
                        easyDriverConnector1.WriteTagAsync($"Local Station/Station23/Station2Plc/DiamUL{index}", (item.DiamUL * 100).ToString(), WritePiority.Default);
                        easyDriverConnector1.WriteTagAsync($"Local Station/Station23/Station2Plc/TipOdLength{index}", item.TipOdLength.ToString(), WritePiority.Default);

                        index += 1;
                    }
                    #endregion

                    #region Station3 HMI, truyền thông modbus RTU Id 2
                    easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station3Hmi/FormulaPoId", partInfo[0].FormulaPoId.ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station3Hmi/FormulaPoU", partInfo[0].PoU.ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station3Hmi/FormulaPoV", partInfo[0].PoV.ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station3Hmi/FormulaPoX", (partInfo[0].PoX * 1000).ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station3Hmi/FormulaPoY", (partInfo[0].PoY * 1000).ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station3Hmi/FormulaPoZ", partInfo[0].PoZ.ToString(), WritePiority.Default);
                    //easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station3Hmi/FormulaPoP", (partInfo[0].PoP * 1000).ToString(), WritePiority.Default);
                    #endregion
                }

                sendData = false;
            }

            t.Enabled = true;
        }

        private void EasyDriverConnector1_Started(object sender, EventArgs e)
        {
            BarcodeChar1_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar1"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar1")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar1").Value));
            BarcodeChar2_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar2"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar2")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar2").Value));
            BarcodeChar3_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar3"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar3")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar3").Value));
            BarcodeChar4_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar4"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar4")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar4").Value));
            BarcodeChar5_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar5"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar5")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar5").Value));

            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar1").ValueChanged += BarcodeChar1_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar2").ValueChanged += BarcodeChar2_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar3").ValueChanged += BarcodeChar3_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar4").ValueChanged += BarcodeChar4_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar5").ValueChanged += BarcodeChar5_ValueChanged;
            //Sensor
            easyDriverConnector1.GetTag("Local Station/Sensor/Device/Value").ValueChanged += Value_ValueChanged;
        }

        private void Value_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            easyDriverConnector1.WriteTagAsync("Local Station/Station23/Station2Plc/Sensor", e.NewValue, WritePiority.High);
        }

        private void BarcodeChar1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            //1 tag chứa 2 ký tự. đc chuyển thành số DEC. giờ phải chyển về HEX. rồi đảo ngược lại
            //Ex: từ HMI truyền lên chữ 'YM': --> mã ASSCII(HEX): Y(59) M(4D) -->truyền lên dảo ngược lại là MY (4D59)--> chuyển HEX sang số DEC 4D59:19801
            //trên máy tính đọc về thì làm ngược lại. DEC-->HEX-->đảo ngược lại-->HEX về lại  ASSCII suy ra ký tự

            if (e.NewValue != "0")
            {
                var value = int.TryParse(e.NewValue, out int res) ? res : 0;

                //DEC-->HEX
                string hexValue = value.ToString("X");

                for (int a = 0; a < hexValue.Length; a = a + 2)

                {

                    string Char2Convert = hexValue.Substring(a, 2);

                    int n = Convert.ToInt32(Char2Convert, 16);//chuyển đổi từ HEX --> DEC

                    //đảo ngược ký tự trước ra sau
                    if (a == 0)
                    {
                        partNumChar[1] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        partNumChar[0] = (char)n;
                    }
                }
            }
        }

        private void BarcodeChar2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            //1 tag chứa 2 ký tự. đc chuyển thành số DEC. giờ phải chyển về HEX. rồi đảo ngược lại
            //Ex: từ HMI truyền lên chữ 'YM': --> mã ASSCII(HEX): Y(59) M(4D) -->truyền lên dảo ngược lại là MY (4D59)--> chuyển HEX sang số DEC 4D59:19801
            //trên máy tính đọc về thì làm ngược lại. DEC-->HEX-->đảo ngược lại-->HEX về lại  ASSCII suy ra ký tự

            if (e.NewValue != "0")
            {
                var value = int.TryParse(e.NewValue, out int res) ? res : 0;

                //DEC-->HEX
                string hexValue = value.ToString("X");

                for (int a = 0; a < hexValue.Length; a = a + 2)

                {

                    string Char2Convert = hexValue.Substring(a, 2);

                    int n = Convert.ToInt32(Char2Convert, 16);//chuyển đổi từ HEX --> DEC

                    //đảo ngược ký tự trước ra sau
                    if (a == 0)
                    {
                        partNumChar[3] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        partNumChar[2] = (char)n;
                    }
                }
            }
        }

        private void BarcodeChar3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            //1 tag chứa 2 ký tự. đc chuyển thành số DEC. giờ phải chyển về HEX. rồi đảo ngược lại
            //Ex: từ HMI truyền lên chữ 'YM': --> mã ASSCII(HEX): Y(59) M(4D) -->truyền lên dảo ngược lại là MY (4D59)--> chuyển HEX sang số DEC 4D59:19801
            //trên máy tính đọc về thì làm ngược lại. DEC-->HEX-->đảo ngược lại-->HEX về lại  ASSCII suy ra ký tự

            if (e.NewValue != "0")
            {
                var value = int.TryParse(e.NewValue, out int res) ? res : 0;

                //DEC-->HEX
                string hexValue = value.ToString("X");

                for (int a = 0; a < hexValue.Length; a = a + 2)

                {

                    string Char2Convert = hexValue.Substring(a, 2);

                    int n = Convert.ToInt32(Char2Convert, 16);//chuyển đổi từ HEX --> DEC

                    //đảo ngược ký tự trước ra sau
                    if (a == 0)
                    {
                        partNumChar[5] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        partNumChar[4] = (char)n;
                    }
                }
            }
        }

        private void BarcodeChar4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            //1 tag chứa 2 ký tự. đc chuyển thành số DEC. giờ phải chyển về HEX. rồi đảo ngược lại
            //Ex: từ HMI truyền lên chữ 'YM': --> mã ASSCII(HEX): Y(59) M(4D) -->truyền lên dảo ngược lại là MY (4D59)--> chuyển HEX sang số DEC 4D59:19801
            //trên máy tính đọc về thì làm ngược lại. DEC-->HEX-->đảo ngược lại-->HEX về lại  ASSCII suy ra ký tự

            if (e.NewValue != "0")
            {
                var value = int.TryParse(e.NewValue, out int res) ? res : 0;

                //DEC-->HEX
                string hexValue = value.ToString("X");

                for (int a = 0; a < hexValue.Length; a = a + 2)

                {

                    string Char2Convert = hexValue.Substring(a, 2);

                    int n = Convert.ToInt32(Char2Convert, 16);//chuyển đổi từ HEX --> DEC

                    //đảo ngược ký tự trước ra sau
                    if (a == 0)
                    {
                        partNumChar[7] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        partNumChar[6] = (char)n;
                    }
                }
            }
        }

        private void BarcodeChar5_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            //1 tag chứa 2 ký tự. đc chuyển thành số DEC. giờ phải chyển về HEX. rồi đảo ngược lại
            //Ex: từ HMI truyền lên chữ 'YM': --> mã ASSCII(HEX): Y(59) M(4D) -->truyền lên dảo ngược lại là MY (4D59)--> chuyển HEX sang số DEC 4D59:19801
            //trên máy tính đọc về thì làm ngược lại. DEC-->HEX-->đảo ngược lại-->HEX về lại  ASSCII suy ra ký tự

            if (e.NewValue != "0")
            {
                var value = int.TryParse(e.NewValue, out int res) ? res : 0;

                //DEC-->HEX
                string hexValue = value.ToString("X");

                for (int a = 0; a < hexValue.Length; a = a + 2)

                {

                    string Char2Convert = hexValue.Substring(a, 2);

                    int n = Convert.ToInt32(Char2Convert, 16);//chuyển đổi từ HEX --> DEC

                    //đảo ngược ký tự trước ra sau
                    if (a == 0)
                    {
                        partNumChar[9] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        partNumChar[8] = (char)n;
                    }
                }

                //khi tag chứa giá trị cuối cùng thay đổi, nghĩa là HMI đã truyền đầy đủ ký tự lên, ghép lại thành chuối partNum
                partNum = null;
                foreach (var item in partNumChar)
                {
                    if (item != 32)
                    {
                        partNum += item;
                    }
                }

                sendData = true;//bat bit nay len để get các thông số truyền xuống cho PLC

                Console.WriteLine($"Ky tu: {partNum}");
            }
        }
    }
}
