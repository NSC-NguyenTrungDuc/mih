#region 사용 NameSpace 지정
    using System;
    using System.Data;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Diagnostics;
    using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
    public class NUR8003U00 :  IHIS.Framework.XScreen
    {

        private string fkinp1001 = string.Empty;
        private int paListRownum = 0;
        private int updCnt = 0;

        private XPanel pnlTop;
        private XPanel pnlLeft;
        private XPanel pnlRight;
        private XCalendar calCalendar;
        private XPatientBox paBox;
        private XPanel pnlCenter;
        private XEditGrid grdPalist;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell41;
        private XPanel pnlB;
        private XPanel pnlA;
        private XButtonList btnList;
        private XPanel xPanel1;
        private XEditGrid grdA;
        private XLabel xLabel2;
        private XLabel xLabel1;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XLabel lblA;
        private XLabel lblB;
        private XLabel lblBCount;
        private XLabel lblACount;
        private XDatePicker dtpWriteDate;
        private XBuseoCombo cboHo_dong;
        private XLabel lblHo_dong;
        private XLabel lblYmd1;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell8;
        private XFindWorker fwkGrdB;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private FindColumnInfo findColumnInfo3;
        private XEditGrid grdB;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private MultiLayout layNurPoints;
        private XButton btnQuery;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private XEditGridCell xEditGridCell14;
        private XButton btnNextPatient;
        private XEditGridCell xEditGridCell19;
        private XPanel pnlSession;
        private XLabel xLabel6;
        private XCheckBox cbxA;
        private XCheckBox cbxB;
        private XCheckBox cbxC;
        private XCheckBox cbxD;
        private XPanel pnlBottom;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR8003U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlSession = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.lblYmd1 = new IHIS.Framework.XLabel();
            this.dtpWriteDate = new IHIS.Framework.XDatePicker();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdPalist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.pnlB = new IHIS.Framework.XPanel();
            this.grdB = new IHIS.Framework.XEditGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.fwkGrdB = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.lblBCount = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pnlA = new IHIS.Framework.XPanel();
            this.grdA = new IHIS.Framework.XEditGrid();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.lblACount = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnQuery = new IHIS.Framework.XButton();
            this.lblA = new IHIS.Framework.XLabel();
            this.lblB = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnNextPatient = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.calCalendar = new IHIS.Framework.XCalendar();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.layNurPoints = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdB)).BeginInit();
            this.pnlA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdA)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calCalendar)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNurPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "앞으로.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlSession);
            this.pnlTop.Controls.Add(this.cboHo_dong);
            this.pnlTop.Controls.Add(this.lblHo_dong);
            this.pnlTop.Controls.Add(this.lblYmd1);
            this.pnlTop.Controls.Add(this.dtpWriteDate);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1352, 38);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlSession
            // 
            this.pnlSession.Controls.Add(this.xLabel6);
            this.pnlSession.Controls.Add(this.cbxA);
            this.pnlSession.Controls.Add(this.cbxB);
            this.pnlSession.Controls.Add(this.cbxC);
            this.pnlSession.Controls.Add(this.cbxD);
            this.pnlSession.Location = new System.Drawing.Point(387, 7);
            this.pnlSession.Name = "pnlSession";
            this.pnlSession.Size = new System.Drawing.Size(236, 22);
            this.pnlSession.TabIndex = 22;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(1, 1);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(63, 21);
            this.xLabel6.TabIndex = 20;
            this.xLabel6.Text = "チーム";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxA
            // 
            this.cbxA.AutoSize = true;
            this.cbxA.Location = new System.Drawing.Point(74, 3);
            this.cbxA.Name = "cbxA";
            this.cbxA.Size = new System.Drawing.Size(31, 17);
            this.cbxA.TabIndex = 14;
            this.cbxA.Text = "A";
            this.cbxA.UseVisualStyleBackColor = false;
            this.cbxA.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckChanged);
            // 
            // cbxB
            // 
            this.cbxB.AutoSize = true;
            this.cbxB.Location = new System.Drawing.Point(116, 3);
            this.cbxB.Name = "cbxB";
            this.cbxB.Size = new System.Drawing.Size(31, 17);
            this.cbxB.TabIndex = 15;
            this.cbxB.Text = "B";
            this.cbxB.UseVisualStyleBackColor = false;
            this.cbxB.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckChanged);
            // 
            // cbxC
            // 
            this.cbxC.AutoSize = true;
            this.cbxC.Location = new System.Drawing.Point(158, 3);
            this.cbxC.Name = "cbxC";
            this.cbxC.Size = new System.Drawing.Size(32, 17);
            this.cbxC.TabIndex = 16;
            this.cbxC.Text = "C";
            this.cbxC.UseVisualStyleBackColor = false;
            this.cbxC.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckChanged);
            // 
            // cbxD
            // 
            this.cbxD.AutoSize = true;
            this.cbxD.Location = new System.Drawing.Point(201, 3);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(31, 17);
            this.cbxD.TabIndex = 17;
            this.cbxD.Text = "D";
            this.cbxD.UseVisualStyleBackColor = false;
            this.cbxD.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckChanged);
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Location = new System.Drawing.Point(83, 8);
            this.cboHo_dong.MaxDropDownItems = 40;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(109, 21);
            this.cboHo_dong.TabIndex = 8;
            this.cboHo_dong.SelectedIndexChanged += new System.EventHandler(this.cboHo_dong_SelectedIndexChanged);
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Location = new System.Drawing.Point(6, 8);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(73, 21);
            this.lblHo_dong.TabIndex = 9;
            this.lblHo_dong.Text = "病棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYmd1
            // 
            this.lblYmd1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblYmd1.EdgeRounding = false;
            this.lblYmd1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYmd1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblYmd1.Location = new System.Drawing.Point(199, 8);
            this.lblYmd1.Name = "lblYmd1";
            this.lblYmd1.Size = new System.Drawing.Size(63, 21);
            this.lblYmd1.TabIndex = 7;
            this.lblYmd1.Text = "記録日";
            this.lblYmd1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpWriteDate
            // 
            this.dtpWriteDate.Location = new System.Drawing.Point(268, 8);
            this.dtpWriteDate.Name = "dtpWriteDate";
            this.dtpWriteDate.Size = new System.Drawing.Size(113, 20);
            this.dtpWriteDate.TabIndex = 1;
            this.dtpWriteDate.TextChanged += new System.EventHandler(this.dtpWriteDate_TextChanged);
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(776, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(576, 38);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdPalist);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 38);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(256, 620);
            this.pnlLeft.TabIndex = 1;
            // 
            // grdPalist
            // 
            this.grdPalist.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell19,
            this.xEditGridCell41,
            this.xEditGridCell14});
            this.grdPalist.ColPerLine = 8;
            this.grdPalist.Cols = 8;
            this.grdPalist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPalist.FixedRows = 1;
            this.grdPalist.HeaderHeights.Add(23);
            this.grdPalist.Location = new System.Drawing.Point(0, 0);
            this.grdPalist.Name = "grdPalist";
            this.grdPalist.QuerySQL = resources.GetString("grdPalist.QuerySQL");
            this.grdPalist.ReadOnly = true;
            this.grdPalist.Rows = 2;
            this.grdPalist.Size = new System.Drawing.Size(256, 620);
            this.grdPalist.TabIndex = 1;
            this.grdPalist.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPalist_QueryEnd);
            this.grdPalist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPalist_QueryStarting);
            this.grdPalist.Click += new System.EventHandler(this.grdPalist_Click);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "ho_code";
            this.xEditGridCell1.CellWidth = 40;
            this.xEditGridCell1.HeaderText = "病室";
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 75;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "患者番号";
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "su_name";
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "患者氏名";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "pkinp1001";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 20;
            this.xEditGridCell6.CellName = "age_sex";
            this.xEditGridCell6.CellWidth = 40;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.HeaderText = "年/性";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ipwon_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 90;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderText = "入院日付";
            this.xEditGridCell7.IsJapanYearType = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "toiwon_date";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell19.CellWidth = 90;
            this.xEditGridCell19.Col = 5;
            this.xEditGridCell19.HeaderText = "退院日付";
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 30;
            this.xEditGridCell41.CellName = "doctor_name";
            this.xEditGridCell41.CellWidth = 71;
            this.xEditGridCell41.Col = 6;
            this.xEditGridCell41.HeaderText = "主治医";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "kaikei_hodong";
            this.xEditGridCell14.Col = 7;
            this.xEditGridCell14.HeaderText = "扱い病棟";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlB);
            this.pnlRight.Controls.Add(this.pnlA);
            this.pnlRight.Controls.Add(this.xPanel1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(546, 38);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(806, 620);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlB
            // 
            this.pnlB.Controls.Add(this.grdB);
            this.pnlB.Controls.Add(this.xLabel2);
            this.pnlB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlB.Location = new System.Drawing.Point(0, 273);
            this.pnlB.Name = "pnlB";
            this.pnlB.Size = new System.Drawing.Size(730, 347);
            this.pnlB.TabIndex = 1;
            // 
            // grdB
            // 
            this.grdB.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell12});
            this.grdB.ColPerLine = 5;
            this.grdB.Cols = 5;
            this.grdB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdB.FixedRows = 1;
            this.grdB.HeaderHeights.Add(32);
            this.grdB.Location = new System.Drawing.Point(0, 27);
            this.grdB.Name = "grdB";
            this.grdB.QuerySQL = resources.GetString("grdB.QuerySQL");
            this.grdB.Rows = 2;
            this.grdB.Size = new System.Drawing.Size(730, 320);
            this.grdB.TabIndex = 4;
            this.grdB.Tag = this.lblBCount;
            this.grdB.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grd_QueryEnd);
            this.grdB.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdB_QueryStarting);
            this.grdB.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            this.grdB.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdB_GridFindSelected);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "first_gubun";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "項目区分";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "gr_code";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "項目";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "gr_name";
            this.xEditGridCell27.CellWidth = 167;
            this.xEditGridCell27.HeaderText = "項目名";
            this.xEditGridCell27.IsReadOnly = true;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "sm_code";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.HeaderText = "sm_code";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 1000;
            this.xEditGridCell29.CellName = "sm_detail";
            this.xEditGridCell29.CellWidth = 244;
            this.xEditGridCell29.Col = 1;
            this.xEditGridCell29.DataIndex = 1;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell29.EnableEdit = false;
            this.xEditGridCell29.FindWorker = this.fwkGrdB;
            this.xEditGridCell29.HeaderText = "内容";
            // 
            // fwkGrdB
            // 
            this.fwkGrdB.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo3});
            this.fwkGrdB.FormText = "状態選択";
            this.fwkGrdB.InputSQL = "SELECT SM_CODE, SM_NAME, SM_POINT \r\n  FROM NUR8023\r\n WHERE HOSP_CODE = :f_hosp_co" +
                "de\r\n   AND FIRST_CODE = \'B\'\r\n   AND GR_CODE = :f_gr_code";
            this.fwkGrdB.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkGrdB.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGrdB_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sm_code";
            this.findColumnInfo1.ColWidth = 0;
            this.findColumnInfo1.HeaderText = "項目";
            this.findColumnInfo1.IsVisible = false;
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sm_name";
            this.findColumnInfo2.ColWidth = 376;
            this.findColumnInfo2.HeaderText = "項目名";
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "sm_point";
            this.findColumnInfo3.ColType = IHIS.Framework.FindColType.Number;
            this.findColumnInfo3.ColWidth = 43;
            this.findColumnInfo3.HeaderText = "点数";
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "nur_point";
            this.xEditGridCell30.CellWidth = 29;
            this.xEditGridCell30.Col = 2;
            this.xEditGridCell30.HeaderText = "点数";
            this.xEditGridCell30.IsReadOnly = true;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "new_sm_code";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.HeaderText = "new_sm_code";
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell32.CellLen = 1000;
            this.xEditGridCell32.CellName = "new_sm_detail";
            this.xEditGridCell32.CellWidth = 244;
            this.xEditGridCell32.Col = 3;
            this.xEditGridCell32.DataIndex = 1;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell32.EnableEdit = false;
            this.xEditGridCell32.FindWorker = this.fwkGrdB;
            this.xEditGridCell32.HeaderText = "追加\r\n内容";
            this.xEditGridCell32.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell33.CellName = "new_nur_point";
            this.xEditGridCell33.CellWidth = 29;
            this.xEditGridCell33.Col = 4;
            this.xEditGridCell33.HeaderText = "追加\r\n点数";
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ment";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "上下";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // lblBCount
            // 
            this.lblBCount.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCount.Location = new System.Drawing.Point(0, 333);
            this.lblBCount.Name = "lblBCount";
            this.lblBCount.Size = new System.Drawing.Size(76, 65);
            this.lblBCount.TabIndex = 1;
            this.lblBCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.Location = new System.Drawing.Point(0, 0);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(730, 27);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "B項目";
            // 
            // pnlA
            // 
            this.pnlA.Controls.Add(this.grdA);
            this.pnlA.Controls.Add(this.xLabel1);
            this.pnlA.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlA.Location = new System.Drawing.Point(0, 0);
            this.pnlA.Name = "pnlA";
            this.pnlA.Size = new System.Drawing.Size(730, 273);
            this.pnlA.TabIndex = 0;
            // 
            // grdA
            // 
            this.grdA.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell13,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell11});
            this.grdA.ColPerLine = 6;
            this.grdA.Cols = 6;
            this.grdA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdA.FixedRows = 1;
            this.grdA.HeaderHeights.Add(34);
            this.grdA.Location = new System.Drawing.Point(0, 29);
            this.grdA.Name = "grdA";
            this.grdA.QuerySQL = resources.GetString("grdA.QuerySQL");
            this.grdA.Rows = 2;
            this.grdA.Size = new System.Drawing.Size(730, 244);
            this.grdA.TabIndex = 0;
            this.grdA.Tag = this.lblACount;
            this.grdA.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grd_QueryEnd);
            this.grdA.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdA_QueryStarting);
            this.grdA.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grd_GridColumnChanged);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "first_gubun";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "項目区分";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gr_code";
            this.xEditGridCell4.CellWidth = 63;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "項目";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gr_name";
            this.xEditGridCell8.CellWidth = 167;
            this.xEditGridCell8.HeaderText = "項目名";
            this.xEditGridCell8.IsReadOnly = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 1000;
            this.xEditGridCell15.CellName = "sm_detail";
            this.xEditGridCell15.CellWidth = 218;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.DisplayMemoText = true;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell15.HeaderText = "内容";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "nur_point";
            this.xEditGridCell16.CellWidth = 39;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell16.HeaderText = "適用";
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "－";
            this.xComboItem1.ValueItem = "0";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "○";
            this.xComboItem2.ValueItem = "1";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 1000;
            this.xEditGridCell17.CellName = "new_sm_detail";
            this.xEditGridCell17.CellWidth = 218;
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.DisplayMemoText = true;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell17.HeaderText = "追加\r\n内容";
            this.xEditGridCell17.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell17.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell18.CellName = "new_nur_point";
            this.xEditGridCell18.CellWidth = 39;
            this.xEditGridCell18.Col = 5;
            this.xEditGridCell18.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell18.HeaderText = "追加\r\n適用";
            this.xEditGridCell18.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell18.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "－";
            this.xComboItem3.ValueItem = "0";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "○";
            this.xComboItem4.ValueItem = "1";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "get_point";
            this.xEditGridCell11.CellWidth = 35;
            this.xEditGridCell11.Col = 2;
            this.xEditGridCell11.HeaderText = "獲得\r\n点数";
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // lblACount
            // 
            this.lblACount.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblACount.Location = new System.Drawing.Point(0, 29);
            this.lblACount.Name = "lblACount";
            this.lblACount.Size = new System.Drawing.Size(76, 65);
            this.lblACount.TabIndex = 0;
            this.lblACount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.Location = new System.Drawing.Point(0, 0);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(730, 29);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "A項目";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnQuery);
            this.xPanel1.Controls.Add(this.lblA);
            this.xPanel1.Controls.Add(this.lblB);
            this.xPanel1.Controls.Add(this.lblBCount);
            this.xPanel1.Controls.Add(this.lblACount);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xPanel1.Location = new System.Drawing.Point(730, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(76, 620);
            this.xPanel1.TabIndex = 2;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1, 181);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "記録照会";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblA
            // 
            this.lblA.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.Location = new System.Drawing.Point(0, 1);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(76, 29);
            this.lblA.TabIndex = 3;
            this.lblA.Text = "A得点";
            this.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblB
            // 
            this.lblB.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB.Location = new System.Drawing.Point(0, 307);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(76, 27);
            this.lblB.TabIndex = 2;
            this.lblB.Text = "B得点";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnNextPatient);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 658);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1352, 40);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.ImageIndex = 0;
            this.btnNextPatient.ImageList = this.ImageList;
            this.btnNextPatient.Location = new System.Drawing.Point(902, 5);
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Size = new System.Drawing.Size(121, 28);
            this.btnNextPatient.TabIndex = 5;
            this.btnNextPatient.Text = "次の患者さんへ";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "全削除", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(1025, 3);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(325, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // calCalendar
            // 
            this.calCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calCalendar.EnableMultiSelection = false;
            this.calCalendar.FullHolidaySelectable = true;
            this.calCalendar.IsJapanYearType = true;
            this.calCalendar.Location = new System.Drawing.Point(0, 0);
            this.calCalendar.MaxDate = new System.DateTime(2023, 10, 9, 0, 0, 0, 0);
            this.calCalendar.MinDate = new System.DateTime(2003, 10, 9, 0, 0, 0, 0);
            this.calCalendar.Name = "calCalendar";
            this.calCalendar.Size = new System.Drawing.Size(290, 620);
            this.calCalendar.TabIndex = 0;
            this.calCalendar.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calCalendar_DaySelected);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.calCalendar);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(256, 38);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(290, 620);
            this.pnlCenter.TabIndex = 4;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gr_code";
            this.xEditGridCell9.HeaderText = "gr_code";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "gr_name";
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.HeaderText = "項目名";
            // 
            // layNurPoints
            // 
            this.layNurPoints.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem8,
            this.multiLayoutItem9});
            this.layNurPoints.QuerySQL = resources.GetString("layNurPoints.QuerySQL");
            this.layNurPoints.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNurPoints_QueryStarting);
            this.layNurPoints.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layNurPoints_QueryEnd);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "dayofmon";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "nur_point";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "need_yn";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "need_cnt";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "ho_dong";
            // 
            // NUR8003U00
            // 
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "NUR8003U00";
            this.Size = new System.Drawing.Size(1352, 698);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR8003U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdB)).EndInit();
            this.pnlA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdA)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calCalendar)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNurPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #region 생성자
        public NUR8003U00()
		{
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdA.SavePerformer = new XSavePerformer(this);
            this.grdB.SavePerformer = this.grdA.SavePerformer;

            this.SaveLayoutList.Add(grdA);
            this.SaveLayoutList.Add(grdB);

        }
        #endregion

        #region Starting
        private void NUR8003U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            dtpWriteDate.TextChanged -= new EventHandler(this.dtpWriteDate_TextChanged);
            dtpWriteDate.SetDataValue(EnvironInfo.GetSysDate());
            calCalendar.SelectDate(DateTime.Parse(dtpWriteDate.GetDataValue()));
            dtpWriteDate.TextChanged += new EventHandler(this.dtpWriteDate_TextChanged);

            if (this.OpenParam != null)
            {
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                    this.cboHo_dong.SetDataValue(UserInfo.HoDong);
                }
            }

            this.grdPalist.QueryLayout(true);

            SetPalistSelect(paBox.BunHo);

        }
        
        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            fkinp1001 = GetFkInp1001(paBox.BunHo);
            QueryAll();
            SetPalistSelect(paBox.BunHo);           
        }

        private void SetPalistSelect(string i_bunho)
        {
            grdPalist.UnSelectAll();
            for (int i = 0; i < grdPalist.RowCount; i++)
            {
                if (grdPalist.GetItemString(i, "bunho") == i_bunho)
                {
                    grdPalist.SelectRow(i);

                    paListRownum = i;
                    break;
                }
            }
        }

        private string GetFkInp1001(string i_bunho)
        {

            BindVarCollection bindVar = new BindVarCollection();
            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_bunho", i_bunho);
            bindVar.Add("f_date", dtpWriteDate.GetDataValue());

            string cmdText = @"SELECT PKINP1001 FROM INP1001 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho AND :f_date BETWEEN IPWON_DATE AND NVL(TOIWON_DATE, '9998/12/31')";

            object ret_fkinp1001 = Service.ExecuteScalar(cmdText, bindVar);

            if (ret_fkinp1001 != null)
            {
                return ret_fkinp1001.ToString();
            }
            return null;
        }

        private void QueryAll()
        {
            grdA.QueryLayout(true);
            grdB.QueryLayout(true);
            layNurPoints.QueryLayout(true);
        }
        #endregion


        #region 그리드 관련 함수
        private void grdPalist_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPalist.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdPalist.SetBindVarValue("f_ho_dong", cboHo_dong.GetDataValue());
            grdPalist.SetBindVarValue("f_date", dtpWriteDate.GetDataValue());

            grdPalist.SetBindVarValue("f_a", cbxA.GetDataValue());
            grdPalist.SetBindVarValue("f_b", cbxB.GetDataValue());
            grdPalist.SetBindVarValue("f_c", cbxC.GetDataValue());
            grdPalist.SetBindVarValue("f_d", cbxD.GetDataValue());
        }

        private void grdA_QueryStarting(object sender, CancelEventArgs e)
        {
            grdA.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdA.SetBindVarValue("f_bunho", paBox.BunHo);
            grdA.SetBindVarValue("f_write_date", dtpWriteDate.GetDataValue());
            grdA.SetBindVarValue("f_ho_dong", Get_Kaikei_Hodong(paBox.BunHo));

        }

        private void grdB_QueryStarting(object sender, CancelEventArgs e)
        {
            grdB.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdB.SetBindVarValue("f_bunho", paBox.BunHo);
            grdB.SetBindVarValue("f_write_date", dtpWriteDate.GetDataValue());
            grdB.SetBindVarValue("f_ho_dong", Get_Kaikei_Hodong(paBox.BunHo));
        }

        private string Get_Kaikei_Hodong(string i_bunho)
        {
            string strCmd = @"SELECT FN_INP_LOAD_KAIKEI_HODONG_HIS(:f_bunho, :f_date) FROM SYS.DUAL";

            string ret_hodong = "";

            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_bunho", i_bunho);
            bindVar.Add("f_date", dtpWriteDate.GetDataValue());

            object retVar = Service.ExecuteScalar(strCmd, bindVar);

            if (retVar != null)
            {
                ret_hodong = retVar.ToString();
            }
            else
            {
                XMessageBox.Show("扱い病棟を確認できませんでした。");
                ret_hodong = "C3";
            }
            return ret_hodong;
        }

        private void grd_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid grid = (XEditGrid)sender;

            SumGroupPoint(grid);
        }

        private void grd_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = (XEditGrid)sender;
            
            if (e.ColName == "nur_point" || e.ColName == "new_nur_point" || e.ColName == "sm_detail" || e.ColName == "new_sm_detail")
            {
                SumGroupPoint(grid);
            }

            if(grid.Name == "grdA")
            {
                if (e.ColName == "nur_point")
                {
                    grid.GridColumnChanged -= new GridColumnChangedEventHandler(grd_GridColumnChanged);
                    if (e.ChangeValue.Equals("1"))
                    {
                        grid.SetItemValue(e.RowNumber, "new_nur_point", "1");                       
                    }
                    grid.GridColumnChanged += new GridColumnChangedEventHandler(grd_GridColumnChanged);
                }
            }


        }

        private void grdPalist_Click(object sender, EventArgs e)
        {
            if (grdPalist.CurrentRowNumber > -1)
            {
                this.paBox.SetPatientID(grdPalist.GetItemString(grdPalist.CurrentRowNumber, "bunho"));
                this.fkinp1001 = grdPalist.GetItemString(grdPalist.CurrentRowNumber, "pkinp1001");
            }
        }

        private void SumGroupPoint(XEditGrid grid)
        {
            int sum = 0 ;

            if (grid.Name == "grdA")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    //nur_point, new_nur_point는 0,1 만 들어가고, get_point의 값(NUR0102.GROUP_KEY)을 가지고 계산을 한다.
                    if(grid.GetItemInt(i, "nur_point") != 0 || grid.GetItemInt(i, "new_nur_point") != 0)
                        sum += grid.GetItemInt(i, "get_point");
                }
            }
            else if (grid.Name == "grdB")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    // 항목에 따라 ment 에 L이 들어가 있으면 낮은 값을 우선하고, 그렇지 않으면 높은 값을 우선한다. 
                    if (grid.GetItemString(i, "ment").Trim() == "L" && !TypeCheck.IsNull(grid.GetItemString(i, "sm_detail")) && !TypeCheck.IsNull(grid.GetItemString(i, "new_sm_detail")))
                        sum+= grid.GetItemInt(i, "nur_point") < grid.GetItemInt(i, "new_nur_point") ? grid.GetItemInt(i, "nur_point") : grid.GetItemInt(i, "new_nur_point");
                    else
                        sum += grid.GetItemInt(i, "nur_point") > grid.GetItemInt(i, "new_nur_point") ? grid.GetItemInt(i, "nur_point") : grid.GetItemInt(i, "new_nur_point");
                }
            }


            ((XLabel)grid.Tag).Text = sum.ToString();
        }

        private void fwkGrdB_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkGrdB.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkGrdB.SetBindVarValue("f_gr_code", grdB.GetItemString(grdB.CurrentRowNumber, "gr_code"));
        }

        private void grdB_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            if (e.ColName == "sm_detail")
            {
                grdB.SetItemValue(grdB.CurrentRowNumber, "sm_code", e.ReturnValues[0].ToString());
                grdB.SetItemValue(grdB.CurrentRowNumber, "nur_point", e.ReturnValues[2].ToString());
            }
            else if (e.ColName == "new_sm_detail")
            {
                grdB.SetItemValue(grdB.CurrentRowNumber, "new_sm_code", e.ReturnValues[0].ToString());
                grdB.SetItemValue(grdB.CurrentRowNumber, "new_nur_point", e.ReturnValues[2].ToString());
            }
            grdB.AcceptData();
        }
        #endregion

        private void calCalendar_DaySelected(object sender, XCalendarDaySelectedEventArgs e)
        {
            dtpWriteDate.SetDataValue(e.DateItems[0].Date);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdPalist.QueryLayout(true);
                    QueryAll();
                    break;

                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    Delete_Today_All();
                    QueryAll();
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    grdA.SaveLayout();

                    grdB.SaveLayout();

                    if (this.updCnt != 0)
                    {
                        XMessageBox.Show("保存しました。");
                        updCnt = 0;
                    }

                    break; 
            }
        }

        private void Delete_Today_All()
        {
            if (XMessageBox.Show("今日のデータのすべてを削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                string cmdText = @"DELETE NUR8003
                                    WHERE HOSP_CODE        = :f_hosp_code
                                      AND BUNHO            = :f_bunho
                                      AND WRITE_DATE       = :f_write_date";

                BindVarCollection bindvar = new BindVarCollection();

                bindvar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindvar.Add("f_bunho", paBox.BunHo);
                bindvar.Add("f_write_date", dtpWriteDate.GetDataValue());

                if (Service.ExecuteNonQuery(cmdText, bindvar))
                {
                    XMessageBox.Show("削除されました。");
                }

            }
        }

        #region [====== [[ XSavePerformer ]] ======]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR8003U00 parent = null;
            public XSavePerformer(NUR8003U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {

                string cmdText = string.Empty;
                item.BindVarList.Add("q_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_bunho", parent.paBox.BunHo);
                item.BindVarList.Add("q_fkinp1001", parent.fkinp1001);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("q_write_date", parent.dtpWriteDate.GetDataValue());
                item.BindVarList.Add("q_ho_dong", parent.Get_Kaikei_Hodong(parent.paBox.BunHo));

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                parent.updCnt++;

                                cmdText = @"BEGIN 
                                            INSERT INTO NUR8003 (   SYS_ID          , SYS_DATE          , UPD_ID            , 
                                                                    UPD_DATE        , HOSP_CODE         , BUNHO             , 
                                                                    FKINP1001       , WRITE_DATE        , FIRST_GUBUN       , 
                                                                    GR_CODE         , NUR_POINT         , NEW_NUR_POINT     , 
                                                                    SM_DETAIL       , NEW_SM_DETAIL     , WRITE_HODONG      ) 
                                                        VALUES (    :q_user_id      , SYSDATE           , :q_user_id        ,
                                                                    SYSDATE         , :q_hosp_code      , :q_bunho          ,
                                                                    :q_fkinp1001    , :q_write_date     , :f_first_gubun    , 
                                                                    :f_gr_code      , :f_nur_point      , :f_new_nur_point  ,
                                                                    :f_sm_detail    , :f_new_sm_detail  , :q_ho_dong        );
                                            EXCEPTION WHEN DUP_VAL_ON_INDEX THEN

                                            UPDATE NUR8003
                                            SET    UPD_ID           = :q_user_id,
                                                   UPD_DATE         = SYSDATE,
                                                   NUR_POINT        = :f_nur_point,
                                                   NEW_NUR_POINT    = :f_new_nur_point,
                                                   SM_DETAIL        = :f_sm_detail,
                                                   NEW_SM_DETAIL    = :f_new_sm_detail,
                                                   WRITE_HODONG     = :q_ho_dong
                                            WHERE  HOSP_CODE        = :q_hosp_code
                                              AND  BUNHO            = :q_bunho
                                              AND  WRITE_DATE       = :q_write_date
                                              AND  FIRST_GUBUN      = :f_first_gubun
                                              AND  GR_CODE          = :f_gr_code;

                                            END ;";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList); ;
            }
        }
        #endregion

        private void layNurPoints_QueryStarting(object sender, CancelEventArgs e)
        {
            layNurPoints.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layNurPoints.SetBindVarValue("f_bunho", paBox.BunHo);
            layNurPoints.SetBindVarValue("f_start_date", calCalendar.DisplayStartDate.ToShortDateString());            
            layNurPoints.SetBindVarValue("f_query_date", dtpWriteDate.GetDataValue());
        }

        private void layNurPoints_QueryEnd(object sender, QueryEndEventArgs e)
        {
            SetCalPoints();
        }

        private void SetCalPoints()
        {
            this.calCalendar.SuspendLayout();
            this.calCalendar.Dates.Clear();

            IHIS.Framework.XCalendarDate dateItem;

            foreach (DataRow row in layNurPoints.LayoutTable.Rows)
            {
                dateItem = new XCalendarDate(DateTime.Parse(row["dayofmon"].ToString()));

                
                dateItem.ContentText = row["ho_dong"].ToString() + "\n\r" +row["nur_point"].ToString();
                if (row["need_yn"].ToString() == "Y")
                {
                    dateItem.ContentTextColor = XColor.ErrMsgForeColor;
                }

                 if (row["need_cnt"].ToString() != "")
                {
                    dateItem.BackColor = XColor.XProgressBarGradientStartColor;
                }

                calCalendar.Dates.Add(dateItem);
            }

            calCalendar.ResumeLayout();
            calCalendar.Refresh();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryForm fm = new QueryForm(EnvironInfo.HospCode, paBox.BunHo, fkinp1001, dtpWriteDate.GetDataValue());
            fm.Show(this);
        }

        private void cboHo_dong_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdPalist.QueryLayout(true);
        }

        private void dtpWriteDate_TextChanged(object sender, EventArgs e)
        {
            this.QueryAll();
        }

        private void grdPalist_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for (int i = 0; i < grdPalist.RowCount; i++)
            {
                
            }
        }

        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Update);

            int rownum = paListRownum + 1 < grdPalist.RowCount ? paListRownum + 1 : 0;

            paBox.SetPatientID(grdPalist.GetItemString(rownum, "bunho"));

            paListRownum = rownum;

            grdPalist.UnSelectAll();
            grdPalist.SelectRow(rownum);
            grdPalist.SetFocusToItem(rownum, "bunho");
            btnNextPatient.Focus();
        }

        private void cbxTeam_CheckChanged(object sender, EventArgs e)
        {
            grdPalist.QueryLayout(false);
        }

        //private Image ScreenShot(Point pt)
        //{
        //    Size sz = new Size(40, 40);
        //    Bitmap bmp = new Bitmap(40, 40, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    Graphics g = Graphics.FromImage(bmp);
        //    g.CopyFromScreen(pt.X - 20, pt.Y - 20, 0, 0, sz);
        //    Bitmap result_bmp = new Bitmap(bmp, pbxMag.Size);
        //    return result_bmp as Image;
        //}

        //private void calCalendar_MouseMove(object sender, MouseEventArgs e)
        //{
        //    pbxMag.Image = ScreenShot(((Control)sender).PointToScreen(e.Location));
        //    pbxMag.Location = new Point(e.X + 20, e.Y);
        //}

    }

}