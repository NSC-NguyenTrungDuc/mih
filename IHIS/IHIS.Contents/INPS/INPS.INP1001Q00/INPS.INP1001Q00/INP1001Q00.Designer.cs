namespace IHIS.INPS
{
    partial class INP1001Q00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1001Q00));
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
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnChiryo = new IHIS.Framework.XButton();
            this.btnVital = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDateTimePicker();
            this.dtpFromDate = new IHIS.Framework.XDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel1.SuspendLayout();
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
            this.xEditGridCell12,
            this.xEditGridCell13});
            this.grdINP1001.ColPerLine = 8;
            this.grdINP1001.Cols = 9;
            resources.ApplyResources(this.grdINP1001, "grdINP1001");
            this.grdINP1001.FixedCols = 1;
            this.grdINP1001.FixedRows = 1;
            this.grdINP1001.HeaderHeights.Add(28);
            this.grdINP1001.Name = "grdINP1001";
            this.grdINP1001.QuerySQL = resources.GetString("grdINP1001.QuerySQL");
            this.grdINP1001.ReadOnly = true;
            this.grdINP1001.RowHeaderVisible = true;
            this.grdINP1001.Rows = 2;
            this.grdINP1001.ToolTipActive = true;
            this.grdINP1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdINP1001_MouseDown);
            this.grdINP1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pkinp1001";
            this.xEditGridCell1.Col = -1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ipwon_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "toiwon_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 98;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa";
            this.xEditGridCell4.Col = -1;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gwa_name";
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "doctor_name";
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ho_dong";
            this.xEditGridCell8.Col = -1;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ho_dong_name";
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "ho_code";
            this.xEditGridCell10.CellWidth = 42;
            this.xEditGridCell10.Col = 6;
            this.xEditGridCell10.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bed_no";
            this.xEditGridCell11.CellWidth = 49;
            this.xEditGridCell11.Col = 7;
            this.xEditGridCell11.EnableSort = true;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jaewon_days";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.CellWidth = 60;
            this.xEditGridCell12.Col = 8;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jaewon_flag";
            this.xEditGridCell13.Col = -1;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xPanel3
            // 
            this.xPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel3.Controls.Add(this.btnChiryo);
            this.xPanel3.Controls.Add(this.btnVital);
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnChiryo
            // 
            this.btnChiryo.Image = ((System.Drawing.Image)(resources.GetObject("btnChiryo.Image")));
            resources.ApplyResources(this.btnChiryo, "btnChiryo");
            this.btnChiryo.Name = "btnChiryo";
            this.btnChiryo.Click += new System.EventHandler(this.btnChiryo_Click);
            // 
            // btnVital
            // 
            this.btnVital.Image = ((System.Drawing.Image)(resources.GetObject("btnVital.Image")));
            resources.ApplyResources(this.btnVital, "btnVital");
            this.btnVital.Name = "btnVital";
            this.btnVital.Click += new System.EventHandler(this.btnVital_Click);
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.dtpToDate);
            this.xPanel1.Controls.Add(this.dtpFromDate);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Value = new System.DateTime(2013, 10, 7, 0, 0, 0, 0);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Value = new System.DateTime(2013, 10, 7, 0, 0, 0, 0);
            // 
            // INP1001Q00
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdINP1001);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.paBox);
            this.Controls.Add(this.xPanel1);
            this.Name = "INP1001Q00";
            this.Load += new System.EventHandler(this.INP1001D00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1001)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XDateTimePicker dtpToDate;
        private IHIS.Framework.XDateTimePicker dtpFromDate;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XButton btnVital;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButton btnChiryo;
    }
}
