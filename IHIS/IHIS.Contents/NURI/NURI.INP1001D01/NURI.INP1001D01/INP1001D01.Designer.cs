namespace IHIS.NURI
{
    partial class INP1001D01
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1001D01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxAutoQuery = new IHIS.Framework.XCheckBox();
            this.txtName = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpQueryDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cboHoDong = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdINP1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "선택.ICO");
            this.ImageList.Images.SetKeyName(1, "미선택.ICO");
            this.ImageList.Images.SetKeyName(2, "퇴원예정.gif");
            this.ImageList.Images.SetKeyName(3, "진료자.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel1.Controls.Add(this.cbxAutoQuery);
            this.xPanel1.Controls.Add(this.txtName);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.dtpQueryDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.cboHoDong);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(707, 43);
            this.xPanel1.TabIndex = 0;
            // 
            // cbxAutoQuery
            // 
            this.cbxAutoQuery.Checked = true;
            this.cbxAutoQuery.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAutoQuery.Location = new System.Drawing.Point(615, 14);
            this.cbxAutoQuery.Margin = new System.Windows.Forms.Padding(5);
            this.cbxAutoQuery.Name = "cbxAutoQuery";
            this.cbxAutoQuery.Size = new System.Drawing.Size(75, 18);
            this.cbxAutoQuery.TabIndex = 6;
            this.cbxAutoQuery.Text = "自動照会";
            this.cbxAutoQuery.UseVisualStyleBackColor = false;
            // 
            // txtName
            // 
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.txtName.Location = new System.Drawing.Point(420, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(180, 20);
            this.txtName.TabIndex = 5;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(354, 11);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(66, 21);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "患者名";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpQueryDate
            // 
            this.dtpQueryDate.Location = new System.Drawing.Point(223, 11);
            this.dtpQueryDate.Name = "dtpQueryDate";
            this.dtpQueryDate.Size = new System.Drawing.Size(125, 20);
            this.dtpQueryDate.TabIndex = 3;
            this.dtpQueryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpQueryDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(146, 11);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(77, 21);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "照会日付";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboHoDong
            // 
            this.cboHoDong.Location = new System.Drawing.Point(63, 10);
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(77, 21);
            this.cboHoDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoDong.TabIndex = 1;
            this.cboHoDong.UserSQL = resources.GetString("cboHoDong.UserSQL");
            this.cboHoDong.SelectedValueChanged += new System.EventHandler(this.cboHoDong_SelectedValueChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(11, 10);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(52, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "病棟";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdINP1001
            // 
            this.grdINP1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell15,
            this.xEditGridCell14});
            this.grdINP1001.ColPerLine = 9;
            this.grdINP1001.Cols = 10;
            this.grdINP1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1001.FixedCols = 1;
            this.grdINP1001.FixedRows = 1;
            this.grdINP1001.HeaderHeights.Add(28);
            this.grdINP1001.Location = new System.Drawing.Point(0, 43);
            this.grdINP1001.Name = "grdINP1001";
            this.grdINP1001.QuerySQL = resources.GetString("grdINP1001.QuerySQL");
            this.grdINP1001.ReadOnly = true;
            this.grdINP1001.RowHeaderVisible = true;
            this.grdINP1001.Rows = 2;
            this.grdINP1001.Size = new System.Drawing.Size(707, 608);
            this.grdINP1001.TabIndex = 2;
            this.grdINP1001.ToolTipActive = true;
            this.grdINP1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdINP1001_MouseDown);
            this.grdINP1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdINP1001_QueryEnd);
            this.grdINP1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pkinp1001";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "pkinp1001";
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderText = "患者番号";
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.CellWidth = 98;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.HeaderText = "氏名";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "gwa";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gwa_name";
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.HeaderText = "診療科";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "doctor";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "doctor_name";
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.HeaderText = "主治医";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ho_dong";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "ho_dong";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ho_dong_name";
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.HeaderText = "病棟";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "ho_code";
            this.xEditGridCell10.CellWidth = 42;
            this.xEditGridCell10.Col = 6;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.HeaderText = "病室";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bed_no";
            this.xEditGridCell11.CellWidth = 38;
            this.xEditGridCell11.Col = 7;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.HeaderText = "ベット";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ipwon_date";
            this.xEditGridCell13.Col = 8;
            this.xEditGridCell13.EnableSort = true;
            this.xEditGridCell13.HeaderText = "入院日";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "toiwon_goji_date";
            this.xEditGridCell15.Col = 9;
            this.xEditGridCell15.EnableSort = true;
            this.xEditGridCell15.HeaderText = "退院予定日";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "toi_res";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "toiwon_goji_yn";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xPanel3
            // 
            this.xPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.Location = new System.Drawing.Point(0, 651);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(707, 39);
            this.xPanel3.TabIndex = 3;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(540, 2);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 24;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // INP1001D01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdINP1001);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "INP1001D01";
            this.Size = new System.Drawing.Size(707, 690);
            this.Load += new System.EventHandler(this.INP1001D00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDatePicker dtpQueryDate;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDictComboBox cboHoDong;
        private IHIS.Framework.XEditGrid grdINP1001;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XTextBox txtName;
        private IHIS.Framework.XLabel xLabel3;
        private System.Windows.Forms.Timer timer1;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XCheckBox cbxAutoQuery;
    }
}
