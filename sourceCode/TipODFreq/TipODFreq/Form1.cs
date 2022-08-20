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

namespace TipODFreq
{
    public partial class Form1 : Form
    {
        private List<PartInfoModel> partInfo = new List<PartInfoModel>();

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var connection = GlobalVariables.GetDbConnection())
            {
                var para = new DynamicParameters();
                para.Add("@partNum", "G5WR60A");

                partInfo = connection.Query<PartInfoModel>("sp_GetFullPartInfo", para, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
