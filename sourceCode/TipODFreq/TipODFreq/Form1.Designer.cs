
namespace TipODFreq
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.easyDriverConnector1 = new EasyScada.Winforms.Controls.EasyDriverConnector(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labPartNum = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.gridPartInfo = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.labWorkOrder = new System.Windows.Forms.Label();
            this.labTime = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.easyLabel1 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel2 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel3 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel4 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel5 = new EasyScada.Winforms.Controls.EasyLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.easyLabel6 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel7 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel8 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel9 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel10 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel11 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel12 = new EasyScada.Winforms.Controls.EasyLabel();
            this.easyLabel13 = new EasyScada.Winforms.Controls.EasyLabel();
            this.labServerStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.easyDriverConnector1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPartInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel13)).BeginInit();
            this.SuspendLayout();
            // 
            // easyDriverConnector1
            // 
            this.easyDriverConnector1.CollectionName = null;
            this.easyDriverConnector1.CommunicationMode = EasyScada.Core.CommunicationMode.ReceiveFromServer;
            this.easyDriverConnector1.DatabaseName = null;
            this.easyDriverConnector1.MongoDb_ConnectionString = null;
            this.easyDriverConnector1.Port = ((ushort)(8800));
            this.easyDriverConnector1.RefreshRate = 100;
            this.easyDriverConnector1.ServerAddress = "192.168.1.10";
            this.easyDriverConnector1.StationName = null;
            this.easyDriverConnector1.Timeout = 30;
            this.easyDriverConnector1.UseMongoDb = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Num:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPartNum
            // 
            this.labPartNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPartNum.Location = new System.Drawing.Point(99, 16);
            this.labPartNum.Name = "labPartNum";
            this.labPartNum.Size = new System.Drawing.Size(154, 26);
            this.labPartNum.TabIndex = 0;
            this.labPartNum.Text = "-----";
            this.labPartNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdateData);
            this.groupBox1.Controls.Add(this.gridPartInfo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labWorkOrder);
            this.groupBox1.Controls.Add(this.labPartNum);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1121, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Part Info";
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.BackColor = System.Drawing.Color.Teal;
            this.btnUpdateData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdateData.Location = new System.Drawing.Point(836, 16);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(279, 34);
            this.btnUpdateData.TabIndex = 4;
            this.btnUpdateData.Text = "Update data sql from CSV file";
            this.btnUpdateData.UseVisualStyleBackColor = false;
            this.btnUpdateData.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridPartInfo
            // 
            this.gridPartInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPartInfo.Location = new System.Drawing.Point(9, 56);
            this.gridPartInfo.Name = "gridPartInfo";
            this.gridPartInfo.Size = new System.Drawing.Size(1106, 139);
            this.gridPartInfo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(347, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Work Order:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labWorkOrder
            // 
            this.labWorkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labWorkOrder.Location = new System.Drawing.Point(456, 16);
            this.labWorkOrder.Name = "labWorkOrder";
            this.labWorkOrder.Size = new System.Drawing.Size(154, 26);
            this.labWorkOrder.TabIndex = 0;
            this.labWorkOrder.Text = "----";
            this.labWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTime
            // 
            this.labTime.AutoSize = true;
            this.labTime.Location = new System.Drawing.Point(9, 666);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(35, 13);
            this.labTime.TabIndex = 4;
            this.labTime.Text = "label2";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Double click to Open.";
            this.notifyIcon.BalloonTipTitle = "App TipOdFreq";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TipOdFreqApp";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShow,
            this.toolStripMenuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            this.contextMenuStrip1.Text = "Show";
            // 
            // toolStripMenuItemShow
            // 
            this.toolStripMenuItemShow.Name = "toolStripMenuItemShow";
            this.toolStripMenuItemShow.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItemShow.Text = "Show";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::TipODFreq.Properties.Resources.logout;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Location = new System.Drawing.Point(1110, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // easyLabel1
            // 
            this.easyLabel1.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel1.Location = new System.Drawing.Point(101, 358);
            this.easyLabel1.Name = "easyLabel1";
            this.easyLabel1.Size = new System.Drawing.Size(100, 23);
            this.easyLabel1.StringFormat = null;
            this.easyLabel1.TabIndex = 7;
            this.easyLabel1.TagPath = "Local Station/Station1Hmi/Device/FreqTarget";
            this.easyLabel1.Text = "easyLabel1";
            // 
            // easyLabel2
            // 
            this.easyLabel2.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel2.Location = new System.Drawing.Point(101, 394);
            this.easyLabel2.Name = "easyLabel2";
            this.easyLabel2.Size = new System.Drawing.Size(100, 23);
            this.easyLabel2.StringFormat = null;
            this.easyLabel2.TabIndex = 8;
            this.easyLabel2.TagPath = "Local Station/Station1Hmi/Device/FormulaGId";
            this.easyLabel2.Text = "easyLabel2";
            // 
            // easyLabel3
            // 
            this.easyLabel3.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel3.Location = new System.Drawing.Point(636, 358);
            this.easyLabel3.Name = "easyLabel3";
            this.easyLabel3.Size = new System.Drawing.Size(100, 23);
            this.easyLabel3.StringFormat = null;
            this.easyLabel3.TabIndex = 9;
            this.easyLabel3.TagPath = "Local Station/Station2Plc/Device/DiamLL1";
            this.easyLabel3.Text = "easyLabel3";
            // 
            // easyLabel4
            // 
            this.easyLabel4.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel4.Location = new System.Drawing.Point(636, 394);
            this.easyLabel4.Name = "easyLabel4";
            this.easyLabel4.Size = new System.Drawing.Size(100, 23);
            this.easyLabel4.StringFormat = null;
            this.easyLabel4.TabIndex = 10;
            this.easyLabel4.TagPath = "Local Station/Station2Plc/Device/DiamUL1";
            this.easyLabel4.Text = "easyLabel4";
            // 
            // easyLabel5
            // 
            this.easyLabel5.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel5.Location = new System.Drawing.Point(259, 358);
            this.easyLabel5.Name = "easyLabel5";
            this.easyLabel5.Size = new System.Drawing.Size(100, 23);
            this.easyLabel5.StringFormat = null;
            this.easyLabel5.TabIndex = 11;
            this.easyLabel5.TagPath = "Local Station/Station3Hmi/Device/FreqTarget";
            this.easyLabel5.Text = "easyLabel5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "SANDING";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "POLISHING";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(633, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "TIP OD";
            // 
            // easyLabel6
            // 
            this.easyLabel6.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel6.Location = new System.Drawing.Point(259, 394);
            this.easyLabel6.Name = "easyLabel6";
            this.easyLabel6.Size = new System.Drawing.Size(100, 23);
            this.easyLabel6.StringFormat = null;
            this.easyLabel6.TabIndex = 15;
            this.easyLabel6.TagPath = "Local Station/Station3Hmi/Device/FormulaPoId";
            this.easyLabel6.Text = "easyLabel6";
            // 
            // easyLabel7
            // 
            this.easyLabel7.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel7.Location = new System.Drawing.Point(636, 431);
            this.easyLabel7.Name = "easyLabel7";
            this.easyLabel7.Size = new System.Drawing.Size(100, 23);
            this.easyLabel7.StringFormat = null;
            this.easyLabel7.TabIndex = 16;
            this.easyLabel7.TagPath = "Local Station/Station2Plc/Device/TipOdLength1";
            this.easyLabel7.Text = "easyLabel7";
            // 
            // easyLabel8
            // 
            this.easyLabel8.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel8.Location = new System.Drawing.Point(742, 431);
            this.easyLabel8.Name = "easyLabel8";
            this.easyLabel8.Size = new System.Drawing.Size(100, 23);
            this.easyLabel8.StringFormat = null;
            this.easyLabel8.TabIndex = 19;
            this.easyLabel8.TagPath = "Local Station/Station2Plc/Device/TipOdLength2";
            this.easyLabel8.Text = "easyLabel8";
            // 
            // easyLabel9
            // 
            this.easyLabel9.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel9.Location = new System.Drawing.Point(742, 394);
            this.easyLabel9.Name = "easyLabel9";
            this.easyLabel9.Size = new System.Drawing.Size(100, 23);
            this.easyLabel9.StringFormat = null;
            this.easyLabel9.TabIndex = 18;
            this.easyLabel9.TagPath = "Local Station/Station2Plc/Device/DiamUL2";
            this.easyLabel9.Text = "easyLabel9";
            // 
            // easyLabel10
            // 
            this.easyLabel10.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel10.Location = new System.Drawing.Point(742, 358);
            this.easyLabel10.Name = "easyLabel10";
            this.easyLabel10.Size = new System.Drawing.Size(100, 23);
            this.easyLabel10.StringFormat = null;
            this.easyLabel10.TabIndex = 17;
            this.easyLabel10.TagPath = "Local Station/Station2Plc/Device/DiamLL2";
            this.easyLabel10.Text = "easyLabel10";
            // 
            // easyLabel11
            // 
            this.easyLabel11.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel11.Location = new System.Drawing.Point(857, 431);
            this.easyLabel11.Name = "easyLabel11";
            this.easyLabel11.Size = new System.Drawing.Size(100, 23);
            this.easyLabel11.StringFormat = null;
            this.easyLabel11.TabIndex = 22;
            this.easyLabel11.TagPath = "Local Station/Station2Plc/Device/TipOdLength3";
            this.easyLabel11.Text = "easyLabel11";
            // 
            // easyLabel12
            // 
            this.easyLabel12.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel12.Location = new System.Drawing.Point(857, 394);
            this.easyLabel12.Name = "easyLabel12";
            this.easyLabel12.Size = new System.Drawing.Size(100, 23);
            this.easyLabel12.StringFormat = null;
            this.easyLabel12.TabIndex = 21;
            this.easyLabel12.TagPath = "Local Station/Station2Plc/Device/DiamUL3";
            this.easyLabel12.Text = "easyLabel12";
            // 
            // easyLabel13
            // 
            this.easyLabel13.DisplayMode = EasyScada.Winforms.Controls.DisplayMode.Value;
            this.easyLabel13.Location = new System.Drawing.Point(857, 358);
            this.easyLabel13.Name = "easyLabel13";
            this.easyLabel13.Size = new System.Drawing.Size(100, 23);
            this.easyLabel13.StringFormat = null;
            this.easyLabel13.TabIndex = 20;
            this.easyLabel13.TagPath = "Local Station/Station2Plc/Device/DiamLL3";
            this.easyLabel13.Text = "easyLabel13";
            // 
            // labServerStatus
            // 
            this.labServerStatus.AutoSize = true;
            this.labServerStatus.Location = new System.Drawing.Point(1019, 666);
            this.labServerStatus.Name = "labServerStatus";
            this.labServerStatus.Size = new System.Drawing.Size(114, 13);
            this.labServerStatus.TabIndex = 23;
            this.labServerStatus.Text = "Server Connect Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 688);
            this.Controls.Add(this.labServerStatus);
            this.Controls.Add(this.easyLabel11);
            this.Controls.Add(this.easyLabel12);
            this.Controls.Add(this.easyLabel13);
            this.Controls.Add(this.easyLabel8);
            this.Controls.Add(this.easyLabel9);
            this.Controls.Add(this.easyLabel10);
            this.Controls.Add(this.easyLabel7);
            this.Controls.Add(this.easyLabel6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.easyLabel5);
            this.Controls.Add(this.easyLabel4);
            this.Controls.Add(this.easyLabel3);
            this.Controls.Add(this.easyLabel2);
            this.Controls.Add(this.easyLabel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labTime);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.easyDriverConnector1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPartInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.easyLabel13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EasyScada.Winforms.Controls.EasyDriverConnector easyDriverConnector1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labPartNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridPartInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labWorkOrder;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Button btnExit;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel1;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel2;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel3;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel4;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel6;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel7;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel8;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel9;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel10;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel11;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel12;
        private EasyScada.Winforms.Controls.EasyLabel easyLabel13;
        private System.Windows.Forms.Label labServerStatus;
    }
}

