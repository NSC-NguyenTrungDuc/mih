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

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL2010U02에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL2010U02 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel6;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGrid grdSpecimen;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XLabel xLabel4;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDictComboBox cboJubsu;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XButton btnPrintSetup;
        private IHIS.Framework.XButton btnBarcode;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private MultiLayout layBarcode;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayout layBarcodeOne;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private XButton btnAllUnCheck;
        private XButton btnAllCheck;
        private XDictComboBox cbxActor;
        private XLabel xLabel11;
        private XDictComboBox cbxBuseo;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell13;
        private XLabel xLabel3;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CPL2010U02()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdSpecimen.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdSpecimen);
            
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010U02));
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.cboJubsu = new IHIS.Framework.XDictComboBox();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdSpecimen = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnAllUnCheck = new IHIS.Framework.XButton();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.btnBarcode = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.layBarcode = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.layBarcodeOne = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "채열실.ico");
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.xLabel3);
            this.xPanel6.Controls.Add(this.cbxBuseo);
            this.xPanel6.Controls.Add(this.cbxActor);
            this.xPanel6.Controls.Add(this.xLabel11);
            this.xPanel6.Controls.Add(this.cboJubsu);
            this.xPanel6.Controls.Add(this.xLabel2);
            this.xPanel6.Controls.Add(this.xLabel7);
            this.xPanel6.Controls.Add(this.dtpToDate);
            this.xPanel6.Controls.Add(this.dtpFromDate);
            this.xPanel6.Controls.Add(this.xLabel4);
            this.xPanel6.Controls.Add(this.label1);
            this.xPanel6.Controls.Add(this.paBox);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Location = new System.Drawing.Point(5, 5);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(1057, 59);
            this.xPanel6.TabIndex = 9;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(4, 31);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(64, 20);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "患者番号";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.Location = new System.Drawing.Point(218, 5);
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.Size = new System.Drawing.Size(92, 21);
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxBuseo.TabIndex = 295;
            this.cbxBuseo.UserSQL = resources.GetString("cbxBuseo.UserSQL");
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);
            // 
            // cbxActor
            // 
            this.cbxActor.Location = new System.Drawing.Point(920, 5);
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.Size = new System.Drawing.Size(114, 21);
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxActor.TabIndex = 292;
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.Location = new System.Drawing.Point(866, 5);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(54, 21);
            this.xLabel11.TabIndex = 293;
            this.xLabel11.Text = "受付者";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboJubsu
            // 
            this.cboJubsu.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem2,
            this.xComboItem3});
            this.cboJubsu.Location = new System.Drawing.Point(68, 5);
            this.cboJubsu.Name = "cboJubsu";
            this.cboJubsu.Size = new System.Drawing.Size(82, 21);
            this.cboJubsu.TabIndex = 291;
            this.cboJubsu.SelectedIndexChanged += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "未採血";
            this.xComboItem2.ValueItem = "N";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "採血";
            this.xComboItem3.ValueItem = "Y";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(4, 5);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(64, 21);
            this.xLabel2.TabIndex = 290;
            this.xLabel2.Text = "採血可否";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Location = new System.Drawing.Point(154, 5);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(64, 21);
            this.xLabel7.TabIndex = 283;
            this.xLabel7.Text = "病 棟";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(519, 6);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate.TabIndex = 288;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(409, 6);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFromDate.TabIndex = 287;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Location = new System.Drawing.Point(315, 6);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(94, 20);
            this.xLabel4.TabIndex = 286;
            this.xLabel4.Text = "オーダ/予約日";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(509, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 285;
            this.label1.Text = "~";
            // 
            // paBox
            // 
            this.paBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paBox.Location = new System.Drawing.Point(-2, 26);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(1029, 32);
            this.paBox.TabIndex = 289;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdSpecimen);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(1055, 481);
            this.xPanel5.TabIndex = 3;
            // 
            // grdSpecimen
            // 
            this.grdSpecimen.ApplyPaintEventToAllColumn = true;
            this.grdSpecimen.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell15,
            this.xEditGridCell14,
            this.xEditGridCell8,
            this.xEditGridCell7,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell1,
            this.xEditGridCell12,
            this.xEditGridCell16});
            this.grdSpecimen.ColPerLine = 13;
            this.grdSpecimen.ColResizable = true;
            this.grdSpecimen.Cols = 14;
            this.grdSpecimen.ControlBinding = true;
            this.grdSpecimen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSpecimen.FixedCols = 1;
            this.grdSpecimen.FixedRows = 1;
            this.grdSpecimen.HeaderHeights.Add(21);
            this.grdSpecimen.Location = new System.Drawing.Point(0, 0);
            this.grdSpecimen.Name = "grdSpecimen";
            this.grdSpecimen.QuerySQL = resources.GetString("grdSpecimen.QuerySQL");
            this.grdSpecimen.RowHeaderVisible = true;
            this.grdSpecimen.Rows = 2;
            this.grdSpecimen.Size = new System.Drawing.Size(1053, 479);
            this.grdSpecimen.TabIndex = 1;
            this.grdSpecimen.ToolTipActive = true;
            this.grdSpecimen.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdSpecimen_ItemValueChanging);
            this.grdSpecimen.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdSpecimen_QueryEnd);
            this.grdSpecimen.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSpecimen_QueryStarting);
            this.grdSpecimen.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdSpecimen_GridColumnProtectModify);
            this.grdSpecimen.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdSpecimen_GridCellPainting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "specimen_ser";
            this.xEditGridCell2.CellWidth = 89;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.HeaderText = "検体番号";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "specimen_code";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 20;
            this.xEditGridCell13.CellName = "specimen_code_name";
            this.xEditGridCell13.CellWidth = 78;
            this.xEditGridCell13.Col = 5;
            this.xEditGridCell13.HeaderText = "検体";
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 84;
            this.xEditGridCell3.Col = 6;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 98;
            this.xEditGridCell4.Col = 7;
            this.xEditGridCell4.HeaderText = "患者氏名";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 30;
            this.xEditGridCell5.CellName = "gwa_name";
            this.xEditGridCell5.CellWidth = 95;
            this.xEditGridCell5.Col = 8;
            this.xEditGridCell5.HeaderText = "診療科";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "ho_dong";
            this.xEditGridCell6.CellWidth = 59;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderText = "病棟";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "ho_code";
            this.xEditGridCell15.CellWidth = 62;
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.HeaderText = "病室";
            this.xEditGridCell15.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "jubsuja";
            this.xEditGridCell14.CellWidth = 91;
            this.xEditGridCell14.Col = 9;
            this.xEditGridCell14.HeaderText = "ラベル発行者";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jundal_gubun";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "gum_jubsu_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 93;
            this.xEditGridCell7.Col = 11;
            this.xEditGridCell7.HeaderText = "採血日";
            this.xEditGridCell7.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gum_jubsu_time";
            this.xEditGridCell9.CellWidth = 65;
            this.xEditGridCell9.Col = 12;
            this.xEditGridCell9.HeaderText = "採血時間";
            this.xEditGridCell9.Mask = "##:##";
            this.xEditGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "gum_jubsuja";
            this.xEditGridCell10.CellWidth = 97;
            this.xEditGridCell10.Col = 10;
            this.xEditGridCell10.HeaderText = "採血者";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "remark";
            this.xEditGridCell1.CellWidth = 62;
            this.xEditGridCell1.Col = 13;
            this.xEditGridCell1.DisplayMemoText = true;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell1.HeaderText = "医師指示";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jubsu_flag";
            this.xEditGridCell12.CellWidth = 35;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightYellow);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "check_yn";
            this.xEditGridCell16.Col = 1;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.HeaderText = "採血";
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.btnAllUnCheck);
            this.xPanel8.Controls.Add(this.btnAllCheck);
            this.xPanel8.Controls.Add(this.btnPrintSetup);
            this.xPanel8.Controls.Add(this.btnBarcode);
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel8.Location = new System.Drawing.Point(0, 481);
            this.xPanel8.Name = "xPanel8";
            this.xPanel8.Size = new System.Drawing.Size(1055, 38);
            this.xPanel8.TabIndex = 5;
            // 
            // btnAllUnCheck
            // 
            this.btnAllUnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllUnCheck.Image")));
            this.btnAllUnCheck.Location = new System.Drawing.Point(48, 4);
            this.btnAllUnCheck.Name = "btnAllUnCheck";
            this.btnAllUnCheck.Size = new System.Drawing.Size(42, 28);
            this.btnAllUnCheck.TabIndex = 277;
            this.btnAllUnCheck.Click += new System.EventHandler(this.btnAllUnCheck_Click);
            // 
            // btnAllCheck
            // 
            this.btnAllCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnAllCheck.Image")));
            this.btnAllCheck.Location = new System.Drawing.Point(5, 4);
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Size = new System.Drawing.Size(42, 28);
            this.btnAllCheck.TabIndex = 276;
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Location = new System.Drawing.Point(293, 4);
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Size = new System.Drawing.Size(158, 28);
            this.btnPrintSetup.TabIndex = 275;
            this.btnPrintSetup.Text = "バーコードプリンター設定";
            this.btnPrintSetup.Visible = false;
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.Location = new System.Drawing.Point(159, 4);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(134, 28);
            this.btnBarcode.TabIndex = 274;
            this.btnBarcode.Text = "バーコード再印刷";
            this.btnBarcode.Visible = false;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(794, 1);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel1.Location = new System.Drawing.Point(5, 64);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1057, 521);
            this.xPanel1.TabIndex = 0;
            // 
            // layBarcode
            // 
            this.layBarcode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18});
            this.layBarcode.QuerySQL = resources.GetString("layBarcode.QuerySQL");
            this.layBarcode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBarcode_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jundal_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "specimen_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "specimen_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "tube_code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "tube_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "in_out_gubun";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "specimen_ser";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "bunho";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "suname";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gwa_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "danger_yn";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "jangbi_code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jangbi_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "tube_max_amt";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "tube_numbering";
            // 
            // layBarcodeOne
            // 
            this.layBarcodeOne.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36});
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "jundal_gubun";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "jundal_gubun_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "specimen_code";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "specimen_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "tube_code";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "tube_name";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "in_out_gubun";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "specimen_ser";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "bunho";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "suname";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "gwa_name";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "danger_yn";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "specimen_ser_ba";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "jangbi_code";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "jangbi_name";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "gumsa_name_re";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "tube_max_amt";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "tube_numbering";
            // 
            // CPL2010U02
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel6);
            this.Name = "CPL2010U02";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1067, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL2010U02_ScreenOpen);
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSpecimen)).EndInit();
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarcodeOne)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region
        int selectedCbxBuseoIndex = 0;
        #endregion

        #region 오픈시 병동 자동 셋팅
        private void CPL2010U02_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            this.cboJubsu.SelectedIndexChanged -= new System.EventHandler(this.paBox_PatientSelected);
            //this.paBox.PatientSelected -= new System.EventHandler(this.paBox_PatientSelected);
            this.cbxBuseo.SelectionChangeCommitted -= new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);

            this.dtpFromDate.SetDataValue(System.DateTime.Today);
            this.dtpToDate.SetDataValue(System.DateTime.Today);
            this.cboJubsu.SetDataValue("N");

            if (!TypeCheck.IsNull(OpenParam))
            {
                //if (this.OpenParam.Contains("bunho"))
                //    paBox.SetPatientID(this.OpenParam["bunho"].ToString());

                if (this.OpenParam.Contains("ho_dong"))
                {
                    selectedCbxBuseoIndex = int.Parse(this.OpenParam["ho_dong"].ToString());
                    //this.cbxBuseo.SetEditValue(this.OpenParam["ho_dong"].ToString());
                    //this.cbxBuseo.AcceptData();
                }

                if (this.OpenParam.Contains("dtpFromDate"))
                {
                    this.dtpFromDate.SetEditValue(this.OpenParam["dtpFromDate"].ToString());
                    this.dtpFromDate.AcceptData();
                }

                if (this.OpenParam.Contains("dtpToDate"))
                {
                    this.dtpToDate.SetEditValue(this.OpenParam["dtpToDate"].ToString());
                    this.dtpToDate.AcceptData();
                }

                if (this.OpenParam.Contains("actor"))
                {
                    this.cbxActor.SetEditValue(this.OpenParam["actor"].ToString());
                    this.cbxActor.AcceptData();
                }
            }

            this.cboJubsu.SelectedIndexChanged += new System.EventHandler(this.paBox_PatientSelected);
            //this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            this.cbxBuseo.SelectionChangeCommitted += new System.EventHandler(this.cbxBuseo_SelectionChangeCommitted);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 病棟選択
            this.cbxBuseo.SelectedIndex = selectedCbxBuseoIndex;

            // リスト照会
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region 버튼리스트 수행 후
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Reset:
                    this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
                    this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
                    break;
                case FunctionType.Update:
                    if (e.IsSuccess == true)
                    {
                        grdSpecimen.QueryLayout(false);
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 버튼리스트 수행 전
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    if (!grdSpecimen.QueryLayout(false))
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;
                    e.IsSuccess = true;

                    // パート受付実施可否チェック
                    if (isCheckEnable() == false) return;

                    try
                    {
                        Service.BeginTransaction();

                        if (this.grdSpecimen.SaveLayout())
                        {
                            Service.CommitTransaction();

                            if (this.cboJubsu.GetDataValue() == "N")
                            {
                                XMessageBox.Show("採血実施が保存されました。\r\n", "採血完了", MessageBoxIcon.Information);
                            }
                            else
                            {
                                XMessageBox.Show("採血取消が保存されました。\r\n", "採血取消完了", MessageBoxIcon.Information);
                            }

                            this.btnList.PerformClick(FunctionType.Query);
                        }
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        e.IsSuccess = false;
                        XMessageBox.Show("保存に失敗しました。\r\n", "保存失敗", MessageBoxIcon.Error);
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region [isCheckEnable パート受付実施可否チェック]
        private bool isCheckEnable()
        {
            bool rtnVal = false;

            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                // 未受付でチェックが入ってあるとPASS
                if (this.cboJubsu.GetDataValue() == "N")
                {
                    if(this.grdSpecimen.GetItemString(i, "check_yn") == "Y") rtnVal = true;
                }

                // 受付済でチェックが外れてあるとPASS
                if (this.cboJubsu.GetDataValue() == "Y")
                {
                    if(this.grdSpecimen.GetItemString(i, "check_yn") == "N") rtnVal = true;
                }
            }

            return rtnVal;
        }
        #endregion

        #region 그리드셀페인팅
        private void grdSpecimen_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (this.grdSpecimen.GetItemString(e.RowNumber, "jubsu_flag") == "Y")
                e.BackColor = Color.LightYellow;
            else
                e.BackColor = Color.White;
        }
        #endregion

        #region 프린터 설정 과 바코드 출력 재출력시
        private void SetPrintBacode()
        {
            //			//바코드프린터명 가져오기
            //			this.DataServiceCall(this.dsvPrintName);
            //			string printSetName = this.dsvPrintName.GetOutValue("print_name").ToString();
            //
            //			if ( this.grdSpecimen.RowCount < 1 ) return;
            //
            //			dwBarcode.Reset();
            //			layBarcode.Reset();
            //
            //			string specimen_ser = grdSpecimen.GetItemString(grdSpecimen.CurrentRowNumber, "specimen_ser");
            //			this.dsvBarcode2.SetInValue("specimen_ser", specimen_ser);
            //			DataServiceCall(dsvBarcode2);
            //			if (layBarcode.RowCount > 0)
            //			{
            //				//바코드를 한껀씩 보냄 여러껀 보낼때 밀림
            //				for (int j=0 ; j<this.layBarcode.RowCount; j++)
            //				{
            //					dwBarcode.Reset();
            //					layBarcodeOne.Reset();
            //
            //					layBarcodeOne.InsertRow();
            //					layBarcodeOne.SetItemValue(0,"jundal_gubun",this.layBarcode.GetItemString(j,"jundal_gubun"));	
            //					layBarcodeOne.SetItemValue(0,"jundal_gubun_name",this.layBarcode.GetItemString(j,"jundal_gubun_name"));	
            //					layBarcodeOne.SetItemValue(0,"specimen_code",this.layBarcode.GetItemString(j,"specimen_code"));	
            //					layBarcodeOne.SetItemValue(0,"specimen_name",this.layBarcode.GetItemString(j,"specimen_name"));	
            //					layBarcodeOne.SetItemValue(0,"tube_code",this.layBarcode.GetItemString(j,"tube_code"));	
            //					layBarcodeOne.SetItemValue(0,"tube_name",this.layBarcode.GetItemString(j,"tube_name"));	
            //					layBarcodeOne.SetItemValue(0,"specimen_ser",this.layBarcode.GetItemString(j,"specimen_ser"));	
            //					layBarcodeOne.SetItemValue(0,"bunho",this.layBarcode.GetItemString(j,"bunho"));	
            //					layBarcodeOne.SetItemValue(0,"suname",this.layBarcode.GetItemString(j,"suname"));	
            //					layBarcodeOne.SetItemValue(0,"gwa_name",this.layBarcode.GetItemString(j,"gwa_name"));	
            //					layBarcodeOne.SetItemValue(0,"danger_yn",this.layBarcode.GetItemString(j,"danger_yn"));	
            //					layBarcodeOne.SetItemValue(0,"specimen_ser_ba",this.layBarcode.GetItemString(j,"specimen_ser_ba"));	
            //					layBarcodeOne.SetItemValue(0,"jangbi_code",this.layBarcode.GetItemString(j,"jangbi_code"));	
            //					layBarcodeOne.SetItemValue(0,"jangbi_name",this.layBarcode.GetItemString(j,"jangbi_name"));	
            //					layBarcodeOne.SetItemValue(0,"in_out_gubun",this.layBarcode.GetItemString(j,"in_out_gubun"));	
            //					layBarcodeOne.SetItemValue(0,"gumsa_name_re",this.layBarcode.GetItemString(j,"gumsa_name_re"));	
            //					layBarcodeOne.SetItemValue(0,"tube_max_amt",this.layBarcode.GetItemString(j,"tube_max_amt"));	
            //					layBarcodeOne.SetItemValue(0,"tube_numbering",this.layBarcode.GetItemString(j,"tube_numbering"));	
            //					
            //					dwBarcode.FillData(layBarcodeOne);
            //					dwBarcode.PrintProperties.PrinterName = printSetName;
            //					try
            //					{
            //						dwBarcode.Print();
            //					}
            //					catch{}
            //				}
            //			}

        }
        #endregion

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.grdSpecimen.QueryLayout(false);
        }

        #region 채혈 체크시
        private void grdSpecimen_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.ToString() == "Y")
            {
                if (this.cbxActor.GetDataValue().Length == 0)
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? "채혈자를 입력해 주세요."
                        : "採血者を入力してください。");
                    XMessageBox.Show(msg);
                    this.cbxActor.Focus();
                }
                else
                {
                    this.grdSpecimen.SetItemValue(e.RowNumber, "gum_jubsuja", this.cbxActor.Text);
                    this.grdSpecimen.SetItemValue(e.RowNumber, "gum_jubsu_date", EnvironInfo.GetSysDate());
                    this.grdSpecimen.SetItemValue(e.RowNumber, "gum_jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                }
            }
            else
            {
                this.grdSpecimen.SetItemValue(e.RowNumber, "gum_jubsuja", "");
                this.grdSpecimen.SetItemValue(e.RowNumber, "gum_jubsu_date", "");
                this.grdSpecimen.SetItemValue(e.RowNumber, "gum_jubsu_time", "");
            }
        }
        #endregion

        /*
        #region 조회 시작시 바코드 리셋
        private void dsvSpecimen_ServiceStart(object sender, IHIS.Framework.ServiceStartEventArgs e)
        {
            dwBarcode1.Reset();
            dwBarcode2.Reset();
            dwBarcode3.Reset();
            dwBarcode4.Reset();
            dwBarcode1.Refresh();
            dwBarcode2.Refresh();
            dwBarcode3.Refresh();
            dwBarcode4.Refresh();
        }
        #endregion

        #region 바코드 아이피 셋팅 조회 관련
        private void dsvSetBarcode_ServiceStart(object sender, IHIS.Framework.ServiceStartEventArgs e)
        {
            this.dsvSetBarcode.SetInValue("ip_addr", Service.ClientIP.ToString());
        }

        private void dsvPrintName_ServiceStart(object sender, IHIS.Framework.ServiceStartEventArgs e)
        {
            this.dsvPrintName.SetBindVarValue("f_ip_addr", Service.ClientIP.ToString());
        }
        #endregion
        */

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private CPL2010U02 parent = null;
            public XSavePerformer(CPL2010U02 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                Hashtable inputList = new Hashtable();
                Hashtable outputList = new Hashtable();

                ArrayList inArrayList = new ArrayList();
                ArrayList outArrayList = new ArrayList();

                string cmdText = "";
                BindVarCollection bc = new BindVarCollection();

                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_specimen_ser", item.BindVarList["f_specimen_ser"].VarValue);
                bc.Add("f_part_jubsuja", parent.cbxActor.GetDataValue());
                bc.Add("f_gum_jubsu_date", item.BindVarList["f_gum_jubsu_date"].VarValue);
                bc.Add("f_gum_jubsu_time", item.BindVarList["f_gum_jubsu_time"].VarValue);

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Modified:

                        if (parent.cboJubsu.GetDataValue() == "N")
                        {
                            // PART JUBSU Start
                            if (item.BindVarList["f_check_yn"].VarValue == "Y")
                            {
                                cmdText = @"UPDATE CPL2010
                                           SET GUM_JUBSU_DATE = :f_gum_jubsu_date
                                             , GUM_JUBSU_TIME = :f_gum_jubsu_time
                                             , GUM_JUBSUJA    = '" + parent.cbxActor.GetDataValue() + @"'
                                         WHERE HOSP_CODE      = :f_hosp_code
                                           AND SPECIMEN_SER   = :f_specimen_ser
                                           AND GUM_JUBSU_DATE IS NULL";

                                if (!Service.ExecuteNonQuery(cmdText, bc))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show("受付処理中にエラー発生しました。\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                                        return false;
                                    }
                                }

                                #region [PART JUBSU Process 2013/08/01 by P.w.j]
                                //   PART JUBSU
                                string strCMD = @"SELECT 'Y'
                                                    FROM DUAL
                                                   WHERE EXISTS (SELECT NULL
                                                                   FROM CPL0109
                                                                  WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                                    AND CODE_TYPE = '20'
                                                                    AND CODE      ='" + item.BindVarList["f_specimen_code"].VarValue + "')";

                                object retVal = Service.ExecuteScalar(strCMD);

                                if (TypeCheck.IsNull(retVal))
                                {
//                                    cmdText = @"SELECT MAX(JUNDAL_GUBUN)
//                                                  FROM CPL2010
//                                                 WHERE HOSP_CODE       = :f_hosp_code
//                                                   AND SPECIMEN_SER    = :f_specimen_ser
//                                                   AND PART_JUBSU_DATE IS NULL
//                                                 GROUP BY JUNDAL_GUBUN";

//                                    retVal = Service.ExecuteScalar(cmdText);

//                                    if (!TypeCheck.IsNull(retVal))
//                                    {
                                        inputList.Clear();
                                        outputList.Clear();

                                        inputList.Add("I_SPECIMEN_SER", item.BindVarList["f_specimen_ser"].VarValue);
                                        inputList.Add("I_JUNDAL_GUBUN", item.BindVarList["f_specimen_code"].VarValue);
                                        inputList.Add("I_PART_JUBSU_DATE", item.BindVarList["f_gum_jubsu_date"].VarValue);
                                        inputList.Add("I_PART_JUBSU_TIME", item.BindVarList["f_gum_jubsu_time"].VarValue);
                                        inputList.Add("I_PART_JUBSUJA", parent.cbxActor.GetDataValue());
                                        inputList.Add("I_USER_ID", parent.cbxActor.GetDataValue());

                                        if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU", inputList, outputList))
                                        {
                                            XMessageBox.Show("受付処理中にエラー発生しました。\r\nPR_CPL_PART_JUBSU エラー\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                                            throw new Exception();
                                        }
                                    //}
                                    //else {
                                    //    XMessageBox.Show("検査項目の分類が正しくありません。\r\nPR_CPL_PART_JUBSU エラー\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                                    //    throw new Exception();
                                    //}
                                }
                                #endregion
                            }
                        }
                        // PART JUBSU Cancel Start
                        if (parent.cboJubsu.GetDataValue() == "Y")
                        {
                            // PART JUBSU Start
                            if (item.BindVarList["f_check_yn"].VarValue == "N")
                            {
                                cmdText = @"UPDATE CPL2010
                                           SET GUM_JUBSU_DATE = NULL
                                             , GUM_JUBSU_TIME = NULL
                                             , GUM_JUBSUJA    = NULL
                                         WHERE HOSP_CODE      = :f_hosp_code 
                                           AND SPECIMEN_SER   = :f_specimen_ser
                                           AND GUM_JUBSU_DATE IS NOT NULL";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        return false;
                                    }
                                }

                                inArrayList.Clear();
                                inArrayList.Add(parent.cbxActor.GetDataValue());
                                inArrayList.Add(item.BindVarList["f_specimen_ser"].VarValue);
                                inArrayList.Add(DBNull.Value);
                                inArrayList.Add("1");
                                //inArrayList.Add(item.BindVarList["f_part_jubsuja"].VarValue);

                                if (!Service.ExecuteProcedure("PR_CPL_PART_JUBSU_CANCEL", inArrayList, outArrayList))
                                {
                                    return false;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
                return true;
            }
        }
        #endregion

        #region 조회인변수 셋팅
        private void grdSpecimen_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdSpecimen.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.grdSpecimen.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdSpecimen.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdSpecimen.SetBindVarValue("f_ho_dong", this.cbxBuseo.GetDataValue());
            this.grdSpecimen.SetBindVarValue("f_jubsu_yn", this.cboJubsu.GetDataValue());
        }
        #endregion

        #region [grdSpecimen_QueryEnd ]
        private void grdSpecimen_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdSpecimen.RowCount < 1) return;

            // [未採決]の場合､チェックを入れたら採血日付､時間をセットする｡
            if (this.cboJubsu.GetDataValue() == "Y")
            {
                for (int i = 0; i < this.grdSpecimen.RowCount; i++)
                {
                    this.grdSpecimen.SetItemValue(i, "check_yn", "Y");
                }

                this.setGrdHeaderImage(this.grdSpecimen);
            }
        }
        #endregion

        #region [grdSpecimen_GridColumnProtectModify ]
        private void grdSpecimen_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "gum_jubsu_date" || e.ColName == "gum_jubsu_time")
            {
                if (this.grdSpecimen.GetItemString(e.RowNumber, "jubsu_flag") == "Y") e.Protect = true;
                else e.Protect = false;
            }
        }
        #endregion

        #region 그리드 이미지 셋팅
        private void setGrdHeaderImage(XEditGrid grid)
        {
            if (grid.Name == "grdSpecimen")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    // 受付完了患者のアイコンを表示する｡
                    if (grid.GetItemString(i, "jubsu_flag") == "Y")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "採血済";
                    }
                }
            }
        }
        #endregion

        private void layBarcode_QueryStarting(object sender, CancelEventArgs e)
        {
            layBarcode.SetBindVarValue("f_specimen_ser", grdSpecimen.GetItemString(grdSpecimen.CurrentRowNumber, "specimen_ser"));
        }

        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdSpecimen.RowCount; i++)
            {
                this.grdSpecimen.SetItemValue(i, "check_yn", "Y");

                this.grdSpecimen.SetItemValue(i, "gum_jubsuja", this.cbxActor.Text);
                this.grdSpecimen.SetItemValue(i, "gum_jubsu_date", EnvironInfo.GetSysDate());
                this.grdSpecimen.SetItemValue(i, "gum_jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
            }
            this.grdSpecimen.Refresh();
        }

        private void btnAllUnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdSpecimen.RowCount; i++)
            {
                this.grdSpecimen.SetItemValue(i, "check_yn", "N");

                this.grdSpecimen.SetItemValue(i, "gum_jubsuja", "");
                this.grdSpecimen.SetItemValue(i, "gum_jubsu_date", "");
                this.grdSpecimen.SetItemValue(i, "gum_jubsu_time", "");
            }
            this.grdSpecimen.Refresh();
        }

        private void cbxBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dtpFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dtpToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
    }
}

