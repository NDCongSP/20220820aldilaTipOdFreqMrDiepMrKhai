using CsvHelper;
using Dapper;
using EasyScada.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
        private string partNum = null, workOrder = null;

        char[] partNumChar = new char[12];//chứa các ký tự convert từ HMI truyền về
        char[] partNumChar1 = new char[2];

        char[] workOrderChar = new char[12];//chứa các ký tự convert từ HMI truyền về
        char[] workOrderChar1 = new char[2];

        bool sendPartNumber = false;//khi co barcode mới thì bật bit này lên để get data từ SQL truyền xuống cho máy chạy part mới.
        bool sendWorkOrder = false;
        bool initialFlag = false;

        Timer t = new Timer();

        #region các thông số cần lưu lên DB
        string formularGId = null, freq01Reading = null, freq02Reading = null, motorSanding = null, shaftNum = null;
        string diamLLRead1 = null, diamULRead1 = null, passFail1 = null, diamLLRead2 = null, diamULRead2 = null,
            passFail2 = null, diamLLRead3 = null, diamULRead3 = null, passFail3 = null;

        string shaftNumStation3 = null;
        #endregion
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

            if (sendPartNumber)
            {
                Console.WriteLine($"Part number:{partNum}");
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

                if (initialFlag)
                {
                    //ghi các giá trị cài đặt xuống các PLC
                    if (partInfo.Count > 0)
                    {
                        gridPartInfo.DataSource = partInfo;

                        #region Station1 HMI 1, truyền thông modbus TCP
                        easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FreqTarget", partInfo[0].FreqTarget.ToString(), WritePiority.Default);
                        easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FormulaGId", partInfo[0].FormulaGId.ToString(), WritePiority.Default);
                        #endregion

                        #region Station2 PLC, truyền thông modbus TCP
                        var index = 1;
                        foreach (var item in partInfo)
                        {
                            easyDriverConnector1.WriteTagAsync($"Local Station/Station2Plc/Device/DiamLL{index}", (item.DiamLL * 100).ToString(), WritePiority.Default);
                            easyDriverConnector1.WriteTagAsync($"Local Station/Station2Plc/Device/DiamUL{index}", (item.DiamUL * 100).ToString(), WritePiority.Default);
                            easyDriverConnector1.WriteTagAsync($"Local Station/Station2Plc/Device/TipOdLength{index}", item.TipOdLength.ToString(), WritePiority.Default);

                            index += 1;
                        }
                        #endregion

                        #region Station3 HMI, truyền thông modbus TCP
                        easyDriverConnector1.WriteTagAsync("Local Station/Station3Hmi/Device/FormulaPoId", partInfo[0].FormulaPoId.ToString(), WritePiority.Default);
                        easyDriverConnector1.WriteTagAsync("Local Station/Station3Hmi/Device/FreqTarget", partInfo[0].FreqTarget.ToString(), WritePiority.Default);
                        #endregion

                        //set bit reset
                        easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/Reset", "1", WritePiority.Default);
                        //easyDriverConnector1.WriteTagAsync("Local Station/Station2Plc/Device/Reset", "1", WritePiority.Default);
                        //easyDriverConnector1.WriteTagAsync("Local Station/Station3Hmi/Device/Reset", "1", WritePiority.Default);
                    }

                    easyDriverConnector1.WriteTagAsync("Local Station/Station3Hmi/Device/Internal_PartNumber", partNum, WritePiority.High);
                    easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FlagPartScan", "0", WritePiority.High);

                }

                sendPartNumber = false;
            }

            if (sendWorkOrder)
            {
                Console.WriteLine($"Work order:{workOrder}");
                if (labWorkOrder.InvokeRequired)
                {
                    labWorkOrder.Text = workOrder;
                }
                else
                {
                    labWorkOrder.Text = workOrder;
                }

                if (initialFlag)
                {
                    easyDriverConnector1.WriteTagAsync("Local Station/Station3Hmi/Device/Internal_WorkOrder", workOrder, WritePiority.High);
                    easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/FlagWorkOrderScan", "0", WritePiority.High);
                }

                sendWorkOrder = false;
            }

            t.Enabled = true;
        }

        private void EasyDriverConnector1_Started(object sender, EventArgs e)
        {
            #region Doc cac tag ban dau

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
            BarcodeChar6_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar6"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar6")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar6").Value));

            WorkOrder1_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder1"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder1")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder1").Value));
            WorkOrder2_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder2"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder2")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder2").Value));
            WorkOrder3_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder3"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder3")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder3").Value));
            WorkOrder4_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder4"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder4")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder4").Value));
            WorkOrder5_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder5"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder5")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder5").Value));
            WorkOrder6_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder6"),
                          new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder6")
                          , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder6").Value));

            Freq02Reading_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Freq02Reading"),
                       new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Freq02Reading")
                       , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Freq02Reading").Value));

            FinishStation1_ValueChanged(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Finish"),
                      new TagValueChangedEventArgs(easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Finish")
                      , "", easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Finish").Value));

            #endregion

            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar1").ValueChanged += BarcodeChar1_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar2").ValueChanged += BarcodeChar2_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar3").ValueChanged += BarcodeChar3_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar4").ValueChanged += BarcodeChar4_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar5").ValueChanged += BarcodeChar5_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/BarcodeChar6").ValueChanged += BarcodeChar6_ValueChanged;

            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder1").ValueChanged += WorkOrder1_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder2").ValueChanged += WorkOrder2_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder3").ValueChanged += WorkOrder3_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder4").ValueChanged += WorkOrder4_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder5").ValueChanged += WorkOrder5_ValueChanged;
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/WorkOrder6").ValueChanged += WorkOrder6_ValueChanged;

            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Freq02Reading").ValueChanged += Freq02Reading_ValueChanged;

            //easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/FlagPartScan").ValueChanged += FlagPartScan_ValueChanged;
            //easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/FlagWorkOrderScan").ValueChanged += FlagWorkOrderScan_ValueChanged;

            //các tag báo máy đã đo xong,  staion 1 và 2, khi đo xong sẽ truyền các thông số đo sang station3 để khi station3 đo xong thì nó sẽ log data vào DB
            easyDriverConnector1.GetTag("Local Station/Station1Hmi/Device/Finish").ValueChanged += FinishStation1_ValueChanged;
            //easyDriverConnector1.GetTag("Local Station/Station2Plc/Device/Finish").ValueChanged += FinishStation2_ValueChanged;
            //easyDriverConnector1.GetTag("Local Station/Station3Hmi/Device/Finish").ValueChanged += FinishStation3_ValueChanged;

            initialFlag = true;
        }

        #region TagValueChange Events
        #region PartNumber
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

                partNum = null;
                foreach (var item in partNumChar)
                {
                    if (item != 32)
                    {
                        partNum += item;
                    }
                }

                sendPartNumber = true;
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

                partNum = null;
                foreach (var item in partNumChar)
                {
                    if (item != 32)
                    {
                        partNum += item;
                    }
                }                
                sendPartNumber = true;
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

                partNum = null;
                foreach (var item in partNumChar)
                {
                    if (item != 32)
                    {
                        partNum += item;
                    }
                }
                sendPartNumber = true;
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

                partNum = null;
                foreach (var item in partNumChar)
                {
                    if (item != 32)
                    {
                        partNum += item;
                    }
                }
                sendPartNumber = true;
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

                partNum = null;
                foreach (var item in partNumChar)
                {
                    if (item != 32)
                    {
                        partNum += item;
                    }
                }
                sendPartNumber = true;
            }
        }
        private void BarcodeChar6_ValueChanged(object sender, TagValueChangedEventArgs e)
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
                        partNumChar[11] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        partNumChar[10] = (char)n;
                    }
                }

                partNum = null;
                foreach (var item in partNumChar)
                {
                    if (item != 32)
                    {
                        partNum += item;
                    }
                }
                sendPartNumber = true;
            }
        }

        private void FlagPartScan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            System.Threading.Thread.Sleep(6000);
            if (e.NewValue == "1")
            {
                partNum = null;
                #region đọc thông tin từ tag, rồi chuyển đổi thành ký tự
                int res = 0, value = 0;
                string tagValue = null;

                for (int i = 0; i < 6; i++)
                {
                    tagValue = easyDriverConnector1.GetTag($"Local Station/Station1Hmi/Device/BarcodeChar{i + 1}").Value;
                    value = int.TryParse(tagValue, out res) ? res : 0;

                    //DEC-->HEX
                    string hexValue = value.ToString("X");

                    for (int a = 0; a < hexValue.Length; a = a + 2)

                    {

                        string Char2Convert = hexValue.Substring(a, 2);

                        int n = Convert.ToInt32(Char2Convert, 16);//chuyển đổi từ HEX --> DEC

                        //đảo ngược ký tự trước ra sau
                        if (a == 0)
                        {
                            partNumChar1[1] = (char)n;//chuyen doi tu DEC 
                        }
                        else
                        {
                            partNumChar1[0] = (char)n;
                        }
                    }

                    foreach (var item in partNumChar1)
                    {
                        if (item != 32)
                        {
                            partNum += item;
                        }
                    }
                }

                #endregion

                ////khi tag chứa giá trị cuối cùng thay đổi, nghĩa là HMI đã truyền đầy đủ ký tự lên, ghép lại thành chuối partNum
                //partNum = null;
                //foreach (var item in partNumChar)
                //{
                //    if (item != 32)
                //    {
                //        partNum += item;
                //    }
                //}

                sendPartNumber = true;//bat bit nay len để get các thông số truyền xuống cho PLC

                Console.WriteLine($"Part number: {partNum}");
            }
        }
        #endregion

        #region WorkOrder
        private void WorkOrder1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
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
                        workOrderChar[1] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        workOrderChar[0] = (char)n;
                    }
                }

                workOrder = null;
                foreach (var item in workOrderChar)
                {
                    if (item != 32)
                    {
                        workOrder += item;
                    }
                }
                sendWorkOrder = true;
            }
        }
        private void WorkOrder2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
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
                        workOrderChar[3] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        workOrderChar[2] = (char)n;
                    }
                }

                workOrder = null;
                foreach (var item in workOrderChar)
                {
                    if (item != 32)
                    {
                        workOrder += item;
                    }
                }
                sendWorkOrder = true;
            }
        }
        private void WorkOrder3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
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
                        workOrderChar[5] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        workOrderChar[4] = (char)n;
                    }
                }
                workOrder = null;
                foreach (var item in workOrderChar)
                {
                    if (item != 32)
                    {
                        workOrder += item;
                    }
                }
                sendWorkOrder = true;

            }
        }
        private void WorkOrder4_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
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
                        workOrderChar[7] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        workOrderChar[6] = (char)n;
                    }
                }

                workOrder = null;
                foreach (var item in workOrderChar)
                {
                    if (item != 32)
                    {
                        workOrder += item;
                    }
                }
                sendWorkOrder = true;
            }
        }
        private void WorkOrder5_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
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
                        workOrderChar[9] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        workOrderChar[8] = (char)n;
                    }
                }

                workOrder = null;
                foreach (var item in workOrderChar)
                {
                    if (item != 32)
                    {
                        workOrder += item;
                    }
                }
                sendWorkOrder = true;
            }
        }
        private void WorkOrder6_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
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
                        workOrderChar[11] = (char)n;//chuyen doi tu DEC 
                    }
                    else
                    {
                        workOrderChar[10] = (char)n;
                    }
                }

                workOrder = null;
                foreach (var item in workOrderChar)
                {
                    if (item != 32)
                    {
                        workOrder += item;
                    }
                }
                sendWorkOrder = true;
            }
        }

        private void FlagWorkOrderScan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            System.Threading.Thread.Sleep(6000);

            if (e.NewValue == "1")
            {
                workOrder = null;
                #region đọc thông tin từ tag, rồi chuyển đổi thành ký tự
                int res = 0;
                for (int i = 0; i < 6; i++)
                {
                    var tagValue = easyDriverConnector1.GetTag($"Local Station/Station1Hmi/Device/WorkOrder{i + 1}").Value;
                    var value = int.TryParse(tagValue, out res) ? res : 0;

                    //DEC-->HEX
                    string hexValue = value.ToString("X");

                    for (int a = 0; a < hexValue.Length; a = a + 2)

                    {

                        string Char2Convert = hexValue.Substring(a, 2);

                        int n = Convert.ToInt32(Char2Convert, 16);//chuyển đổi từ HEX --> DEC

                        //đảo ngược ký tự trước ra sau
                        if (a == 0)
                        {
                            workOrderChar1[1] = (char)n;//chuyen doi tu DEC 
                        }
                        else
                        {
                            workOrderChar1[0] = (char)n;
                        }
                    }

                    foreach (var item in workOrderChar1)
                    {
                        if (item != 32)
                        {
                            workOrder += item;
                        }
                    }
                }

                #endregion
                //khi tag chứa giá trị cuối cùng thay đổi, nghĩa là HMI đã truyền đầy đủ ký tự lên, ghép lại thành chuối partNum
                //workOrder = null;
                //foreach (var item in workOrderChar)
                //{
                //    if (item != 32)
                //    {
                //        workOrder += item;
                //    }
                //}

                sendWorkOrder = true;
                Console.WriteLine($"Work Order: {workOrder}");
            }
        }
        #endregion

        #region Finish
        private void FinishStation1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            if (e.NewValue != "0")
            {
                //truyen cac thông số qua cho PLC 3, để phục vụ cho việc log data lên DB.
                //code ở đây
                easyDriverConnector1.WriteTagAsync("Local Station/Station3Hmi/Device/Freq02Reading", freq02Reading, WritePiority.High);
                easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/Finish1", "1", WritePiority.High);
            }
            else
            {
                easyDriverConnector1.WriteTagAsync("Local Station/Station1Hmi/Device/Finish1", "0", WritePiority.High);
            }
        }

        private void FinishStation3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            if (e.NewValue == "1")
            {
                //Log DB.
                //code ở đây
            }
        }

        private void FinishStation2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            if (e.NewValue == "1")
            {
                //truyen cac thông số qua cho PLC 3, để phục vụ cho việc log data lên DB.
                //code ở đây
            }
        }
        #endregion

        private void Freq02Reading_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            freq02Reading = e.NewValue;
        }
        //update data vao sql tu csv file
        private void button1_Click(object sender, EventArgs e)
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
            lines = System.IO.File.ReadAllLines(GlobalVariables.PathFormulaG);

            if (lines.Count() > 0)
            {
                var dataFormulaG = new List<tblFormulaGModel>();

                int index = 0;
                foreach (string line in lines)
                {
                    if (index != 0)
                    {
                        string[] columns = line.Split(',');
                        dataFormulaG.Add(new tblFormulaGModel()
                        {
                            Id = int.TryParse(columns[0], out int value) ? value : 0,
                            U = int.TryParse(columns[1], out value) ? value : 0,
                            V = int.TryParse(columns[2], out value) ? value : 0,
                            X = double.TryParse(columns[3], out double value1) ? value1 : 0,
                            Y = double.TryParse(columns[4], out value1) ? value1 : 0,
                            Z = int.TryParse(columns[5], out value) ? value : 0,
                            P = int.TryParse(columns[6], out value) ? value : 0,
                        });
                    }
                    index += 1;
                }

                using (var connection = GlobalVariables.GetDbConnection())
                {
                    connection.Execute("delete tblFormulaG");

                    var count = connection.Execute(@"insert tblFormulaG (Id, U, V,X,Y,Z,P) 
                                                    values (@Id, @U,@V,@X,@Y,@Z,@P)", dataFormulaG);

                    if (dataFormulaG.Count() == count)
                    {
                        countExecute += 1;
                    }
                }
            }
            #endregion

            #region Formula PO
            lines = System.IO.File.ReadAllLines(GlobalVariables.PathFormulaPo);

            if (lines.Count() > 0)
            {
                var dataFormulaPo = new List<tblFormulaPoModel>();

                int index = 0;
                foreach (string line in lines)
                {
                    if (index != 0)
                    {
                        string[] columns = line.Split(',');
                        dataFormulaPo.Add(new tblFormulaPoModel()
                        {
                            Id = int.TryParse(columns[0], out int value) ? value : 0,
                            U = int.TryParse(columns[1], out value) ? value : 0,
                            V = int.TryParse(columns[2], out value) ? value : 0,
                            X = double.TryParse(columns[3], out double value1) ? value1 : 0,
                            Y = double.TryParse(columns[4], out value1) ? value1 : 0,
                            Z = int.TryParse(columns[5], out value) ? value : 0,
                            P = int.TryParse(columns[6], out value) ? value : 0,
                        });
                    }
                    index += 1;
                }

                using (var connection = GlobalVariables.GetDbConnection())
                {
                    connection.Execute("delete tblFormulaPo");

                    var count = connection.Execute(@"insert tblFormulaPo (Id, U, V,X,Y,Z,P) 
                                                    values (@Id, @U,@V,@X,@Y,@Z,@P)", dataFormulaPo);

                    if (dataFormulaPo.Count() == count)
                    {
                        countExecute += 1;
                    }
                }
            }
            #endregion

            if (countExecute == 3)
            {
                MessageBox.Show("Impport data successfull.");
            }
            else
            {
                MessageBox.Show("Fail.");
            }
        }
        #endregion
    }
}
