namespace IHIS.BASS
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbByouMei = new System.Windows.Forms.ToolStripButton();
            this.tsbSusikCode = new System.Windows.Forms.ToolStripButton();
            this.tspDrugCode = new System.Windows.Forms.ToolStripButton();
            this.tsbJinryoHangwi = new System.Windows.Forms.ToolStripButton();
            this.tsbTokuteiCode = new System.Windows.Forms.ToolStripButton();
            this.tsbJabiCode = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxTableId = new System.Windows.Forms.TextBox();
            this.txtInitialSgCode = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnList = new IHIS.Framework.XButtonList();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.tabGubun = new IHIS.Framework.XTabControl();
            this.tpgBoheom = new IHIS.X.Magic.Controls.TabPage();
            this.tpgGongbi = new IHIS.X.Magic.Controls.TabPage();
            this.tpgPatient = new IHIS.X.Magic.Controls.TabPage();
            this.tpgPatientBoheom = new IHIS.X.Magic.Controls.TabPage();
            this.tpgPatientGongbi = new IHIS.X.Magic.Controls.TabPage();
            this.tpgPatientSang = new IHIS.X.Magic.Controls.TabPage();
            this.tpgInputSet = new IHIS.X.Magic.Controls.TabPage();
            this.tpgInputCd = new IHIS.X.Magic.Controls.TabPage();
            this.tpgUser = new IHIS.X.Magic.Controls.TabPage();
            this.tpgZip = new IHIS.X.Magic.Controls.TabPage();
            this.tpgJohapGubun = new IHIS.X.Magic.Controls.TabPage();
            this.tpgJohapMaster = new IHIS.X.Magic.Controls.TabPage();
            this.tpgGongbiMaster = new IHIS.X.Magic.Controls.TabPage();
            this.tpgJabi = new IHIS.X.Magic.Controls.TabPage();
            this.tpgHospInfo = new IHIS.X.Magic.Controls.TabPage();
            this.tpgHoDong = new IHIS.X.Magic.Controls.TabPage();
            this.tpgHoRoom = new IHIS.X.Magic.Controls.TabPage();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.tabGubun.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbByouMei,
            this.tsbSusikCode,
            this.tspDrugCode,
            this.tsbJinryoHangwi,
            this.tsbTokuteiCode,
            this.tsbJabiCode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(944, 51);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolBar";
            this.toolStrip1.Visible = false;
            // 
            // tsbByouMei
            // 
            this.tsbByouMei.Image = ((System.Drawing.Image)(resources.GetObject("tsbByouMei.Image")));
            this.tsbByouMei.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbByouMei.Name = "tsbByouMei";
            this.tsbByouMei.Size = new System.Drawing.Size(51, 48);
            this.tsbByouMei.Text = "傷    病";
            this.tsbByouMei.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbByouMei.Click += new System.EventHandler(this.tsbByouMei_Click);
            // 
            // tsbSusikCode
            // 
            this.tsbSusikCode.Image = ((System.Drawing.Image)(resources.GetObject("tsbSusikCode.Image")));
            this.tsbSusikCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSusikCode.Name = "tsbSusikCode";
            this.tsbSusikCode.Size = new System.Drawing.Size(55, 48);
            this.tsbSusikCode.Text = "修 飾 語";
            this.tsbSusikCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSusikCode.Click += new System.EventHandler(this.tsbSusikCode_Click);
            // 
            // tspDrugCode
            // 
            this.tspDrugCode.Image = ((System.Drawing.Image)(resources.GetObject("tspDrugCode.Image")));
            this.tspDrugCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspDrugCode.Name = "tspDrugCode";
            this.tspDrugCode.Size = new System.Drawing.Size(55, 48);
            this.tspDrugCode.Text = "医 薬 品";
            this.tspDrugCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tspDrugCode.Click += new System.EventHandler(this.tspDrugCode_Click);
            // 
            // tsbJinryoHangwi
            // 
            this.tsbJinryoHangwi.Image = ((System.Drawing.Image)(resources.GetObject("tsbJinryoHangwi.Image")));
            this.tsbJinryoHangwi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJinryoHangwi.Name = "tsbJinryoHangwi";
            this.tsbJinryoHangwi.Size = new System.Drawing.Size(59, 48);
            this.tsbJinryoHangwi.Text = "診療行為";
            this.tsbJinryoHangwi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJinryoHangwi.Click += new System.EventHandler(this.tsbJinryoHangwi_Click);
            // 
            // tsbTokuteiCode
            // 
            this.tsbTokuteiCode.Image = ((System.Drawing.Image)(resources.GetObject("tsbTokuteiCode.Image")));
            this.tsbTokuteiCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTokuteiCode.Name = "tsbTokuteiCode";
            this.tsbTokuteiCode.Size = new System.Drawing.Size(59, 48);
            this.tsbTokuteiCode.Text = "特定器材";
            this.tsbTokuteiCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTokuteiCode.Click += new System.EventHandler(this.tsbTokuteiCode_Click);
            // 
            // tsbJabiCode
            // 
            this.tsbJabiCode.Image = ((System.Drawing.Image)(resources.GetObject("tsbJabiCode.Image")));
            this.tsbJabiCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbJabiCode.Name = "tsbJabiCode";
            this.tsbJabiCode.Size = new System.Drawing.Size(71, 48);
            this.tsbJabiCode.Text = "自費コード";
            this.tsbJabiCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbJabiCode.Click += new System.EventHandler(this.tsbJabiCode_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbxTableId);
            this.panel1.Controls.Add(this.txtInitialSgCode);
            this.panel1.Controls.Add(this.lbCount);
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 40);
            this.panel1.TabIndex = 2;
            // 
            // tbxTableId
            // 
            this.tbxTableId.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.tbxTableId.Location = new System.Drawing.Point(80, 8);
            this.tbxTableId.MaxLength = 20;
            this.tbxTableId.Name = "tbxTableId";
            this.tbxTableId.Size = new System.Drawing.Size(116, 21);
            this.tbxTableId.TabIndex = 3;
            this.tbxTableId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxTableId.Visible = false;
            // 
            // txtInitialSgCode
            // 
            this.txtInitialSgCode.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtInitialSgCode.Location = new System.Drawing.Point(12, 8);
            this.txtInitialSgCode.MaxLength = 1;
            this.txtInitialSgCode.Name = "txtInitialSgCode";
            this.txtInitialSgCode.Size = new System.Drawing.Size(53, 21);
            this.txtInitialSgCode.TabIndex = 2;
            this.txtInitialSgCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInitialSgCode.Visible = false;
            // 
            // lbCount
            // 
            this.lbCount.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbCount.Location = new System.Drawing.Point(222, 8);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(356, 23);
            this.lbCount.TabIndex = 1;
            this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnList
            // 
            this.btnList.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(610, 6);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(325, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // gridData
            // 
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.Location = new System.Drawing.Point(0, 27);
            this.gridData.Name = "gridData";
            this.gridData.RowTemplate.Height = 23;
            this.gridData.Size = new System.Drawing.Size(944, 519);
            this.gridData.TabIndex = 3;
            // 
            // tabGubun
            // 
            this.tabGubun.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabGubun.IDEPixelArea = true;
            this.tabGubun.IDEPixelBorder = false;
            this.tabGubun.Location = new System.Drawing.Point(0, 0);
            this.tabGubun.Name = "tabGubun";
            this.tabGubun.SelectedIndex = 0;
            this.tabGubun.SelectedTab = this.tpgBoheom;
            this.tabGubun.Size = new System.Drawing.Size(944, 27);
            this.tabGubun.TabIndex = 4;
            this.tabGubun.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tpgBoheom,
            this.tpgGongbi,
            this.tpgPatient,
            this.tpgPatientBoheom,
            this.tpgPatientGongbi,
            this.tpgPatientSang,
            this.tpgInputSet,
            this.tpgInputCd,
            this.tpgUser,
            this.tpgZip,
            this.tpgJohapGubun,
            this.tpgJohapMaster,
            this.tpgGongbiMaster,
            this.tpgJabi,
            this.tpgHospInfo,
            this.tpgHoDong,
            this.tpgHoRoom});
            this.tabGubun.SelectionChanged += new System.EventHandler(this.tabGubun_SelectionChanged);
            // 
            // tpgBoheom
            // 
            this.tpgBoheom.Enabled = false;
            this.tpgBoheom.Location = new System.Drawing.Point(0, 25);
            this.tpgBoheom.Name = "tpgBoheom";
            this.tpgBoheom.Size = new System.Drawing.Size(944, 2);
            this.tpgBoheom.TabIndex = 3;
            this.tpgBoheom.Tag = "1";
            this.tpgBoheom.Title = "保険";
            this.tpgBoheom.Visible = false;
            // 
            // tpgGongbi
            // 
            this.tpgGongbi.Enabled = false;
            this.tpgGongbi.Location = new System.Drawing.Point(0, 25);
            this.tpgGongbi.Name = "tpgGongbi";
            this.tpgGongbi.Selected = false;
            this.tpgGongbi.Size = new System.Drawing.Size(944, 2);
            this.tpgGongbi.TabIndex = 4;
            this.tpgGongbi.Tag = "2";
            this.tpgGongbi.Title = "公費";
            this.tpgGongbi.Visible = false;
            // 
            // tpgPatient
            // 
            this.tpgPatient.Location = new System.Drawing.Point(0, 25);
            this.tpgPatient.Name = "tpgPatient";
            this.tpgPatient.Selected = false;
            this.tpgPatient.Size = new System.Drawing.Size(944, 2);
            this.tpgPatient.TabIndex = 5;
            this.tpgPatient.Tag = "3";
            this.tpgPatient.Title = "患者情報";
            // 
            // tpgPatientBoheom
            // 
            this.tpgPatientBoheom.Location = new System.Drawing.Point(0, 25);
            this.tpgPatientBoheom.Name = "tpgPatientBoheom";
            this.tpgPatientBoheom.Selected = false;
            this.tpgPatientBoheom.Size = new System.Drawing.Size(944, 2);
            this.tpgPatientBoheom.TabIndex = 6;
            this.tpgPatientBoheom.Tag = "4";
            this.tpgPatientBoheom.Title = "患者別保険";
            // 
            // tpgPatientGongbi
            // 
            this.tpgPatientGongbi.Location = new System.Drawing.Point(0, 25);
            this.tpgPatientGongbi.Name = "tpgPatientGongbi";
            this.tpgPatientGongbi.Selected = false;
            this.tpgPatientGongbi.Size = new System.Drawing.Size(944, 2);
            this.tpgPatientGongbi.TabIndex = 7;
            this.tpgPatientGongbi.Tag = "5";
            this.tpgPatientGongbi.Title = "患者別公費";
            // 
            // tpgPatientSang
            // 
            this.tpgPatientSang.Location = new System.Drawing.Point(0, 25);
            this.tpgPatientSang.Name = "tpgPatientSang";
            this.tpgPatientSang.Selected = false;
            this.tpgPatientSang.Size = new System.Drawing.Size(944, 2);
            this.tpgPatientSang.TabIndex = 8;
            this.tpgPatientSang.Tag = "13";
            this.tpgPatientSang.Title = "患者別傷病";
            // 
            // tpgInputSet
            // 
            this.tpgInputSet.Location = new System.Drawing.Point(0, 25);
            this.tpgInputSet.Name = "tpgInputSet";
            this.tpgInputSet.Selected = false;
            this.tpgInputSet.Size = new System.Drawing.Size(944, 2);
            this.tpgInputSet.TabIndex = 9;
            this.tpgInputSet.Tag = "6";
            this.tpgInputSet.Title = "セットオーダ";
            // 
            // tpgInputCd
            // 
            this.tpgInputCd.Location = new System.Drawing.Point(0, 25);
            this.tpgInputCd.Name = "tpgInputCd";
            this.tpgInputCd.Selected = false;
            this.tpgInputCd.Size = new System.Drawing.Size(944, 2);
            this.tpgInputCd.TabIndex = 10;
            this.tpgInputCd.Tag = "7";
            this.tpgInputCd.Title = "セットコード";
            // 
            // tpgUser
            // 
            this.tpgUser.Location = new System.Drawing.Point(0, 25);
            this.tpgUser.Name = "tpgUser";
            this.tpgUser.Selected = false;
            this.tpgUser.Size = new System.Drawing.Size(944, 2);
            this.tpgUser.TabIndex = 11;
            this.tpgUser.Tag = "8";
            this.tpgUser.Title = "ユーザー";
            // 
            // tpgZip
            // 
            this.tpgZip.Location = new System.Drawing.Point(0, 25);
            this.tpgZip.Name = "tpgZip";
            this.tpgZip.Selected = false;
            this.tpgZip.Size = new System.Drawing.Size(944, 2);
            this.tpgZip.TabIndex = 12;
            this.tpgZip.Tag = "9";
            this.tpgZip.Title = "郵便番号";
            // 
            // tpgJohapGubun
            // 
            this.tpgJohapGubun.Location = new System.Drawing.Point(0, 25);
            this.tpgJohapGubun.Name = "tpgJohapGubun";
            this.tpgJohapGubun.Selected = false;
            this.tpgJohapGubun.Size = new System.Drawing.Size(944, 2);
            this.tpgJohapGubun.TabIndex = 13;
            this.tpgJohapGubun.Tag = "10";
            this.tpgJohapGubun.Title = "保険種別";
            // 
            // tpgJohapMaster
            // 
            this.tpgJohapMaster.Location = new System.Drawing.Point(0, 25);
            this.tpgJohapMaster.Name = "tpgJohapMaster";
            this.tpgJohapMaster.Selected = false;
            this.tpgJohapMaster.Size = new System.Drawing.Size(944, 2);
            this.tpgJohapMaster.TabIndex = 14;
            this.tpgJohapMaster.Tag = "11";
            this.tpgJohapMaster.Title = "保険者";
            // 
            // tpgGongbiMaster
            // 
            this.tpgGongbiMaster.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tpgGongbiMaster.Location = new System.Drawing.Point(0, 25);
            this.tpgGongbiMaster.Name = "tpgGongbiMaster";
            this.tpgGongbiMaster.Selected = false;
            this.tpgGongbiMaster.Size = new System.Drawing.Size(944, 2);
            this.tpgGongbiMaster.TabIndex = 15;
            this.tpgGongbiMaster.Tag = "12";
            this.tpgGongbiMaster.Title = "公費Master";
            // 
            // tpgJabi
            // 
            this.tpgJabi.Location = new System.Drawing.Point(0, 25);
            this.tpgJabi.Name = "tpgJabi";
            this.tpgJabi.Selected = false;
            this.tpgJabi.Size = new System.Drawing.Size(944, 2);
            this.tpgJabi.TabIndex = 16;
            this.tpgJabi.Tag = "14";
            this.tpgJabi.Title = "自費";
            // 
            // tpgHospInfo
            // 
            this.tpgHospInfo.Location = new System.Drawing.Point(0, 25);
            this.tpgHospInfo.Name = "tpgHospInfo";
            this.tpgHospInfo.Selected = false;
            this.tpgHospInfo.Size = new System.Drawing.Size(944, 2);
            this.tpgHospInfo.TabIndex = 17;
            this.tpgHospInfo.Tag = "15";
            this.tpgHospInfo.Title = "病院情報";
            // 
            // tpgHoDong
            // 
            this.tpgHoDong.Location = new System.Drawing.Point(0, 25);
            this.tpgHoDong.Name = "tpgHoDong";
            this.tpgHoDong.Selected = false;
            this.tpgHoDong.Size = new System.Drawing.Size(944, 2);
            this.tpgHoDong.TabIndex = 18;
            this.tpgHoDong.Tag = "16";
            this.tpgHoDong.Title = "病棟";
            // 
            // tpgHoRoom
            // 
            this.tpgHoRoom.Location = new System.Drawing.Point(0, 25);
            this.tpgHoRoom.Name = "tpgHoRoom";
            this.tpgHoRoom.Selected = false;
            this.tpgHoRoom.Size = new System.Drawing.Size(944, 2);
            this.tpgHoRoom.TabIndex = 19;
            this.tpgHoRoom.Tag = "17";
            this.tpgHoRoom.Title = "病室";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 586);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.tabGubun);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "マスタ管理";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.tabGubun.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbByouMei;
        private System.Windows.Forms.ToolStripButton tsbSusikCode;
        private System.Windows.Forms.ToolStripButton tspDrugCode;
        private System.Windows.Forms.ToolStripButton tsbJinryoHangwi;
        private System.Windows.Forms.ToolStripButton tsbTokuteiCode;
        private System.Windows.Forms.Panel panel1;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.ToolStripButton tsbJabiCode;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.TextBox txtInitialSgCode;
        private System.Windows.Forms.TextBox tbxTableId;
        private IHIS.Framework.XTabControl tabGubun;
        private IHIS.X.Magic.Controls.TabPage tpgBoheom;
        private IHIS.X.Magic.Controls.TabPage tpgGongbi;
        private IHIS.X.Magic.Controls.TabPage tpgPatient;
        private IHIS.X.Magic.Controls.TabPage tpgPatientBoheom;
        private IHIS.X.Magic.Controls.TabPage tpgPatientGongbi;
        private IHIS.X.Magic.Controls.TabPage tpgInputSet;
        private IHIS.X.Magic.Controls.TabPage tpgInputCd;
        private IHIS.X.Magic.Controls.TabPage tpgUser;
        private IHIS.X.Magic.Controls.TabPage tpgZip;
        private IHIS.X.Magic.Controls.TabPage tpgJohapGubun;
        private IHIS.X.Magic.Controls.TabPage tpgGongbiMaster;
        private IHIS.X.Magic.Controls.TabPage tpgJohapMaster;
        private IHIS.X.Magic.Controls.TabPage tpgPatientSang;
        private IHIS.X.Magic.Controls.TabPage tpgJabi;
        private IHIS.X.Magic.Controls.TabPage tpgHospInfo;
        private IHIS.X.Magic.Controls.TabPage tpgHoDong;
        private IHIS.X.Magic.Controls.TabPage tpgHoRoom;
    }
}

