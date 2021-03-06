using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework;
using IHIS.XRTS.Properties;

namespace IHIS.XRTS
{
    public partial class XRT0001U00
    {
        private IHIS.Framework.XButtonList xButtonList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGrid grdXRT;
        private System.Windows.Forms.GroupBox groupBox1;
        private IHIS.Framework.XTextBox txtSpYN1;
        private IHIS.Framework.XTextBox txtSlipCode1;
        private IHIS.Framework.XEditMask txtRealCnt1;
        private IHIS.Framework.XGroupBox XGroupBox4;
        private IHIS.Framework.XRadioButton rbnSpN1;
        private IHIS.Framework.XRadioButton rbnSpY1;
        private IHIS.Framework.XTextBox txtSugaCode1;
        private IHIS.Framework.XEditMask txtXrayCnt1;
        private IHIS.Framework.XFindBox fbxReserType1;
        private IHIS.Framework.XTextBox txtResType1;
        private IHIS.Framework.XCheckBox cbxNCard1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XFindBox fbxXrayBuwi1;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XTextBox txtXrayBuwi1;
        private IHIS.Framework.XTextBox txtModality1;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XFindBox fbxXrayRoom1;
        private IHIS.Framework.XFindBox fbxXrayGubun1;
        private IHIS.Framework.XLabel xLabel10;
        private IHIS.Framework.XTextBox txtXrayGubun1;
        private IHIS.Framework.XTextBox txtXrayRoom1;
        private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XTextBox txtXrayName1;
        private IHIS.Framework.XTextBox txtXrayCode1;
        private IHIS.Framework.XLabel xLabel12;
        private IHIS.Framework.XLabel xLabel13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XFindWorker fwkXRT0001;
        private IHIS.Framework.FindColumnInfo findColumnInfo11;
        private IHIS.Framework.FindColumnInfo findColumnInfo12;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XTextBox txtSort1;
        private IHIS.Framework.XLabel xLabel27;
        private IHIS.Framework.XLabel xLabel28;
        private IHIS.Framework.XComboBox cboJaeryoYn1;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.SingleLayout layDup;
        private IHIS.Framework.XTextBox txtNameCardYn;
        private System.Windows.Forms.ToolTip toolTip;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XComboBox cboSpot1;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XLabel xLabel31;
        private IHIS.Framework.XComboItem xComboItem9;
        private SingleLayout vsvXRT0001;
        private SingleLayoutItem singleLayoutItem1;
        private XRadioButton rbxAll;
        private XRadioButton rbxSpecialY;
        private XEditGridCell xEditGridCell22;
        private XCheckBox cbxFreq1;
        private XLabel xLabel33;
        private XEditGridCell xEditGridCell23;
        private XPanel xPanel3;
        private XFindBox fbxBuwiTong1;
        private XLabel xLabel36;
        private XTextBox txtBuwiTong1;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XFindBox fbxModality1;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XTextBox txtXrayKanaName1;
        private XLabel xLabel37;
        private XEditGridCell xEditGridCell28;
        private XTextBox txtParam;
        private XLabel xLabel14;
        private XDictComboBox cbxXrayGubun;
        private XRadioButton rbxSpecialN;
        private XEditGrid grdRadioList;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private System.ComponentModel.IContainer components;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT0001U00));
            this.xButtonList = new IHIS.Framework.XButtonList();
            this.grdXRT = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.txtXrayCode1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.txtXrayName1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.fbxXrayGubun1 = new IHIS.Framework.XFindBox();
            this.fwkXRT0001 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo11 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo12 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.fbxXrayRoom1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fbxXrayBuwi1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.fbxBuwiTong1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.txtXrayCnt1 = new IHIS.Framework.XEditMask();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.cbxNCard1 = new IHIS.Framework.XCheckBox();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.txtSugaCode1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.txtRealCnt1 = new IHIS.Framework.XEditMask();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.txtSlipCode1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.fbxReserType1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.txtXrayGubun1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.txtXrayRoom1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.txtXrayBuwi1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.txtBuwiTong1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.txtResType1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.cboJaeryoYn1 = new IHIS.Framework.XComboBox();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.cboSpot1 = new IHIS.Framework.XComboBox();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.cbxFreq1 = new IHIS.Framework.XCheckBox();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.fbxModality1 = new IHIS.Framework.XFindBox();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.txtModality1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.txtSort1 = new IHIS.Framework.XTextBox();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.txtXrayKanaName1 = new IHIS.Framework.XTextBox();
            this.txtSpYN1 = new IHIS.Framework.XTextBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxXrayGubun = new IHIS.Framework.XDictComboBox();
            this.txtParam = new IHIS.Framework.XTextBox();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.xLabel31 = new IHIS.Framework.XLabel();
            this.txtNameCardYn = new IHIS.Framework.XTextBox();
            this.xLabel27 = new IHIS.Framework.XLabel();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.XGroupBox4 = new IHIS.Framework.XGroupBox();
            this.rbnSpN1 = new IHIS.Framework.XRadioButton();
            this.rbnSpY1 = new IHIS.Framework.XRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdRadioList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.layDup = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rbxAll = new IHIS.Framework.XRadioButton();
            this.rbxSpecialY = new IHIS.Framework.XRadioButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.rbxSpecialN = new IHIS.Framework.XRadioButton();
            this.vsvXRT0001 = new IHIS.Framework.SingleLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXRT)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.XGroupBox4.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRadioList)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "선택.ICO");
            this.ImageList.Images.SetKeyName(1, "미선택.ICO");
            // 
            // xButtonList
            // 
            resources.ApplyResources(this.xButtonList, "xButtonList");
            this.xButtonList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList.Name = "xButtonList";
            this.xButtonList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdXRT
            // 
            this.grdXRT.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell24,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell25,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell23,
            this.xEditGridCell28});
            this.grdXRT.ColPerLine = 4;
            this.grdXRT.ColResizable = true;
            this.grdXRT.Cols = 5;
            this.grdXRT.ControlBinding = true;
            this.grdXRT.ExecuteQuery = null;
            this.grdXRT.FixedCols = 1;
            this.grdXRT.FixedRows = 1;
            this.grdXRT.HeaderHeights.Add(24);
            resources.ApplyResources(this.grdXRT, "grdXRT");
            this.grdXRT.Name = "grdXRT";
            this.grdXRT.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdXRT.ParamList")));
            this.grdXRT.QuerySQL = resources.GetString("grdXRT.QuerySQL");
            this.grdXRT.RowHeaderVisible = true;
            this.grdXRT.Rows = 2;
            this.grdXRT.TabStop = false;
            this.grdXRT.Click += new System.EventHandler(this.grdXRT_Click);
            this.grdXRT.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdXRT_QueryEnd);
            this.grdXRT.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdXRT_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.BindControl = this.txtXrayCode1;
            this.xEditGridCell1.CellName = "xray_code";
            this.xEditGridCell1.CellWidth = 63;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtXrayCode1
            // 
            this.txtXrayCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtXrayCode1, "txtXrayCode1");
            this.txtXrayCode1.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtXrayCode1.Name = "txtXrayCode1";
            this.txtXrayCode1.ReadOnly = true;
            this.txtXrayCode1.TabStop = false;
            this.txtXrayCode1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtXrayCode1_DataValidating);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.BindControl = this.txtXrayName1;
            this.xEditGridCell2.CellName = "xray_name";
            this.xEditGridCell2.CellWidth = 195;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtXrayName1
            // 
            resources.ApplyResources(this.txtXrayName1, "txtXrayName1");
            this.txtXrayName1.Name = "txtXrayName1";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.BindControl = this.fbxXrayGubun1;
            this.xEditGridCell3.CellName = "xray_gubun";
            this.xEditGridCell3.CellWidth = 61;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // fbxXrayGubun1
            // 
            this.fbxXrayGubun1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxXrayGubun1.FindWorker = this.fwkXRT0001;
            resources.ApplyResources(this.fbxXrayGubun1, "fbxXrayGubun1");
            this.fbxXrayGubun1.Name = "fbxXrayGubun1";
            this.fbxXrayGubun1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxXrayGubun1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxXrayGubun1_FindClick);
            // 
            // fwkXRT0001
            // 
            this.fwkXRT0001.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo11,
            this.findColumnInfo12});
            this.fwkXRT0001.ExecuteQuery = null;
            this.fwkXRT0001.FormText = global::IHIS.XRTS.Properties.Resources.fwkXRT0001Text1;
            this.fwkXRT0001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkXRT0001.ParamList")));
            this.fwkXRT0001.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkXRT0001.ServerFilter = true;
            // 
            // findColumnInfo11
            // 
            this.findColumnInfo11.ColName = "code";
            this.findColumnInfo11.ColWidth = 131;
            this.findColumnInfo11.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo11, "findColumnInfo11");
            // 
            // findColumnInfo12
            // 
            this.findColumnInfo12.ColName = "name";
            this.findColumnInfo12.ColWidth = 269;
            this.findColumnInfo12.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo12, "findColumnInfo12");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.BindControl = this.fbxXrayRoom1;
            this.xEditGridCell4.CellName = "xray_room";
            this.xEditGridCell4.CellWidth = 61;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // fbxXrayRoom1
            // 
            this.fbxXrayRoom1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxXrayRoom1.FindWorker = this.fwkXRT0001;
            resources.ApplyResources(this.fbxXrayRoom1, "fbxXrayRoom1");
            this.fbxXrayRoom1.Name = "fbxXrayRoom1";
            this.fbxXrayRoom1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxXrayRoom1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxXrayRoom1_FindClick);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.BindControl = this.fbxXrayBuwi1;
            this.xEditGridCell5.CellName = "xray_buwi";
            this.xEditGridCell5.CellWidth = 65;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // fbxXrayBuwi1
            // 
            this.fbxXrayBuwi1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.fbxXrayBuwi1, "fbxXrayBuwi1");
            this.fbxXrayBuwi1.Name = "fbxXrayBuwi1";
            this.fbxXrayBuwi1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxXrayBuwi1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxXrayBuwi1_FindClick);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "xray_buwi_kaikei";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell6.BindControl = this.fbxBuwiTong1;
            this.xEditGridCell6.CellName = "xray_buwi_tong";
            this.xEditGridCell6.CellWidth = 70;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // fbxBuwiTong1
            // 
            this.fbxBuwiTong1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.fbxBuwiTong1, "fbxBuwiTong1");
            this.fbxBuwiTong1.Name = "fbxBuwiTong1";
            this.fbxBuwiTong1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxBuwiTong1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBuwiTong1_FindClick);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell7.BindControl = this.txtXrayCnt1;
            this.xEditGridCell7.CellName = "xray_cnt";
            this.xEditGridCell7.CellWidth = 56;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtXrayCnt1
            // 
            this.txtXrayCnt1.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.txtXrayCnt1, "txtXrayCnt1");
            this.txtXrayCnt1.MaxinumCipher = 5;
            this.txtXrayCnt1.Name = "txtXrayCnt1";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell8.BindControl = this.cbxNCard1;
            this.xEditGridCell8.CellName = "name_print_yn";
            this.xEditGridCell8.CellWidth = 61;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // cbxNCard1
            // 
            resources.ApplyResources(this.cbxNCard1, "cbxNCard1");
            this.cbxNCard1.Name = "cbxNCard1";
            this.cbxNCard1.TabStop = false;
            this.cbxNCard1.UseVisualStyleBackColor = false;
            this.cbxNCard1.CheckedChanged += new System.EventHandler(this.cbxNCard1_CheckedChanged);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell9.BindControl = this.txtSugaCode1;
            this.xEditGridCell9.CellName = "suga_code";
            this.xEditGridCell9.CellWidth = 55;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtSugaCode1
            // 
            resources.ApplyResources(this.txtSugaCode1, "txtSugaCode1");
            this.txtSugaCode1.Name = "txtSugaCode1";
            this.txtSugaCode1.TabStop = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell10.CellName = "special_yn";
            this.xEditGridCell10.CellWidth = 30;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell11.BindControl = this.txtRealCnt1;
            this.xEditGridCell11.CellName = "xray_real_cnt";
            this.xEditGridCell11.CellWidth = 53;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtRealCnt1
            // 
            this.txtRealCnt1.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.txtRealCnt1, "txtRealCnt1");
            this.txtRealCnt1.MaxinumCipher = 5;
            this.txtRealCnt1.Name = "txtRealCnt1";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell12.BindControl = this.txtSlipCode1;
            this.xEditGridCell12.CellName = "slip_code";
            this.xEditGridCell12.CellWidth = 54;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtSlipCode1
            // 
            resources.ApplyResources(this.txtSlipCode1, "txtSlipCode1");
            this.txtSlipCode1.Name = "txtSlipCode1";
            this.txtSlipCode1.TabStop = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell13.BindControl = this.fbxReserType1;
            this.xEditGridCell13.CellName = "reser_type";
            this.xEditGridCell13.CellWidth = 67;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // fbxReserType1
            // 
            this.fbxReserType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxReserType1.FindWorker = this.fwkXRT0001;
            resources.ApplyResources(this.fbxReserType1, "fbxReserType1");
            this.fbxReserType1.Name = "fbxReserType1";
            this.fbxReserType1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxReserType1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxReserType1_FindClick);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell14.BindControl = this.txtXrayGubun1;
            this.xEditGridCell14.CellName = "gubun_name";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtXrayGubun1
            // 
            resources.ApplyResources(this.txtXrayGubun1, "txtXrayGubun1");
            this.txtXrayGubun1.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtXrayGubun1.Name = "txtXrayGubun1";
            this.txtXrayGubun1.ReadOnly = true;
            this.txtXrayGubun1.TabStop = false;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell15.BindControl = this.txtXrayRoom1;
            this.xEditGridCell15.CellName = "room_name";
            this.xEditGridCell15.CellWidth = 68;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtXrayRoom1
            // 
            resources.ApplyResources(this.txtXrayRoom1, "txtXrayRoom1");
            this.txtXrayRoom1.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtXrayRoom1.Name = "txtXrayRoom1";
            this.txtXrayRoom1.ReadOnly = true;
            this.txtXrayRoom1.TabStop = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell16.BindControl = this.txtXrayBuwi1;
            this.xEditGridCell16.CellName = "buwi_name";
            this.xEditGridCell16.CellWidth = 72;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtXrayBuwi1
            // 
            resources.ApplyResources(this.txtXrayBuwi1, "txtXrayBuwi1");
            this.txtXrayBuwi1.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtXrayBuwi1.Name = "txtXrayBuwi1";
            this.txtXrayBuwi1.ReadOnly = true;
            this.txtXrayBuwi1.TabStop = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "buwi_kaikei_name";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell17.BindControl = this.txtBuwiTong1;
            this.xEditGridCell17.CellName = "buwi_tong_name";
            this.xEditGridCell17.CellWidth = 73;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtBuwiTong1
            // 
            resources.ApplyResources(this.txtBuwiTong1, "txtBuwiTong1");
            this.txtBuwiTong1.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtBuwiTong1.Name = "txtBuwiTong1";
            this.txtBuwiTong1.ReadOnly = true;
            this.txtBuwiTong1.TabStop = false;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell18.BindControl = this.txtResType1;
            this.xEditGridCell18.CellName = "reser_type_name";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // txtResType1
            // 
            resources.ApplyResources(this.txtResType1, "txtResType1");
            this.txtResType1.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtResType1.Name = "txtResType1";
            this.txtResType1.ReadOnly = true;
            this.txtResType1.TabStop = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell19.BindControl = this.cboJaeryoYn1;
            this.xEditGridCell19.CellName = "jaeryo_yn";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // cboJaeryoYn1
            // 
            this.cboJaeryoYn1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            resources.ApplyResources(this.cboJaeryoYn1, "cboJaeryoYn1");
            this.cboJaeryoYn1.Name = "cboJaeryoYn1";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "N";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell20.CellName = "tong_gubun";
            this.xEditGridCell20.CellWidth = 24;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.EnableSort = true;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.BindControl = this.cboSpot1;
            this.xEditGridCell21.CellName = "xray_way";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // cboSpot1
            // 
            this.cboSpot1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem9});
            resources.ApplyResources(this.cboSpot1, "cboSpot1");
            this.cboSpot1.Name = "cboSpot1";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "A";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "S";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "X";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.BindControl = this.cbxFreq1;
            this.xEditGridCell22.CellLen = 1;
            this.xEditGridCell22.CellName = "frequent_use_yn";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // cbxFreq1
            // 
            resources.ApplyResources(this.cbxFreq1, "cbxFreq1");
            this.cbxFreq1.Name = "cbxFreq1";
            this.cbxFreq1.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.BindControl = this.fbxModality1;
            this.xEditGridCell26.CellName = "modality";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // fbxModality1
            // 
            this.fbxModality1.FindWorker = this.fwkXRT0001;
            resources.ApplyResources(this.fbxModality1, "fbxModality1");
            this.fbxModality1.Name = "fbxModality1";
            this.fbxModality1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbx_DataValidating);
            this.fbxModality1.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxModality1_FindClick);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.BindControl = this.txtModality1;
            this.xEditGridCell27.CellName = "modality_name";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // txtModality1
            // 
            resources.ApplyResources(this.txtModality1, "txtModality1");
            this.txtModality1.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtModality1.Name = "txtModality1";
            this.txtModality1.ReadOnly = true;
            this.txtModality1.TabStop = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.BindControl = this.txtSort1;
            this.xEditGridCell23.CellName = "sort";
            this.xEditGridCell23.CellWidth = 65;
            this.xEditGridCell23.Col = 3;
            this.xEditGridCell23.EnableSort = true;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // txtSort1
            // 
            resources.ApplyResources(this.txtSort1, "txtSort1");
            this.txtSort1.Name = "txtSort1";
            this.txtSort1.Protect = true;
            this.txtSort1.ReadOnly = true;
            this.txtSort1.TabStop = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.BindControl = this.txtXrayKanaName1;
            this.xEditGridCell28.CellLen = 100;
            this.xEditGridCell28.CellName = "xray_name2";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // txtXrayKanaName1
            // 
            resources.ApplyResources(this.txtXrayKanaName1, "txtXrayKanaName1");
            this.txtXrayKanaName1.Name = "txtXrayKanaName1";
            // 
            // txtSpYN1
            // 
            resources.ApplyResources(this.txtSpYN1, "txtSpYN1");
            this.txtSpYN1.Name = "txtSpYN1";
            this.txtSpYN1.TabStop = false;
            this.txtSpYN1.TextChanged += new System.EventHandler(this.txtSpYN1_TextChanged);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxXrayGubun);
            this.groupBox1.Controls.Add(this.txtParam);
            this.groupBox1.Controls.Add(this.xLabel14);
            this.groupBox1.Controls.Add(this.txtXrayKanaName1);
            this.groupBox1.Controls.Add(this.xLabel37);
            this.groupBox1.Controls.Add(this.fbxModality1);
            this.groupBox1.Controls.Add(this.cbxFreq1);
            this.groupBox1.Controls.Add(this.xLabel33);
            this.groupBox1.Controls.Add(this.cboSpot1);
            this.groupBox1.Controls.Add(this.xLabel31);
            this.groupBox1.Controls.Add(this.txtNameCardYn);
            this.groupBox1.Controls.Add(this.cboJaeryoYn1);
            this.groupBox1.Controls.Add(this.txtSort1);
            this.groupBox1.Controls.Add(this.xLabel27);
            this.groupBox1.Controls.Add(this.xLabel28);
            this.groupBox1.Controls.Add(this.txtSpYN1);
            this.groupBox1.Controls.Add(this.txtSlipCode1);
            this.groupBox1.Controls.Add(this.txtRealCnt1);
            this.groupBox1.Controls.Add(this.XGroupBox4);
            this.groupBox1.Controls.Add(this.txtSugaCode1);
            this.groupBox1.Controls.Add(this.txtXrayCnt1);
            this.groupBox1.Controls.Add(this.fbxReserType1);
            this.groupBox1.Controls.Add(this.txtResType1);
            this.groupBox1.Controls.Add(this.cbxNCard1);
            this.groupBox1.Controls.Add(this.xLabel1);
            this.groupBox1.Controls.Add(this.xLabel2);
            this.groupBox1.Controls.Add(this.xLabel3);
            this.groupBox1.Controls.Add(this.xLabel4);
            this.groupBox1.Controls.Add(this.xLabel5);
            this.groupBox1.Controls.Add(this.xLabel6);
            this.groupBox1.Controls.Add(this.xLabel7);
            this.groupBox1.Controls.Add(this.fbxBuwiTong1);
            this.groupBox1.Controls.Add(this.xLabel36);
            this.groupBox1.Controls.Add(this.txtBuwiTong1);
            this.groupBox1.Controls.Add(this.fbxXrayBuwi1);
            this.groupBox1.Controls.Add(this.xLabel8);
            this.groupBox1.Controls.Add(this.txtXrayBuwi1);
            this.groupBox1.Controls.Add(this.txtModality1);
            this.groupBox1.Controls.Add(this.xLabel9);
            this.groupBox1.Controls.Add(this.fbxXrayRoom1);
            this.groupBox1.Controls.Add(this.fbxXrayGubun1);
            this.groupBox1.Controls.Add(this.xLabel10);
            this.groupBox1.Controls.Add(this.txtXrayGubun1);
            this.groupBox1.Controls.Add(this.txtXrayRoom1);
            this.groupBox1.Controls.Add(this.xLabel11);
            this.groupBox1.Controls.Add(this.txtXrayName1);
            this.groupBox1.Controls.Add(this.txtXrayCode1);
            this.groupBox1.Controls.Add(this.xLabel12);
            this.groupBox1.Controls.Add(this.xLabel13);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbxXrayGubun
            // 
            this.cbxXrayGubun.ExecuteQuery = null;
            resources.ApplyResources(this.cbxXrayGubun, "cbxXrayGubun");
            this.cbxXrayGubun.Name = "cbxXrayGubun";
            this.cbxXrayGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxXrayGubun.ParamList")));
            this.cbxXrayGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxXrayGubun.UserSQL = resources.GetString("cbxXrayGubun.UserSQL");
            this.cbxXrayGubun.SelectedIndexChanged += new System.EventHandler(this.cbxXrayGubun_SelectedIndexChanged);
            // 
            // txtParam
            // 
            this.txtParam.EnterKeyToTab = false;
            resources.ApplyResources(this.txtParam, "txtParam");
            this.txtParam.Name = "txtParam";
            this.txtParam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParam_KeyDown);
            // 
            // xLabel14
            // 
            this.xLabel14.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.SkyBlue);
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel37
            // 
            resources.ApplyResources(this.xLabel37, "xLabel37");
            this.xLabel37.Name = "xLabel37";
            // 
            // xLabel33
            // 
            resources.ApplyResources(this.xLabel33, "xLabel33");
            this.xLabel33.Name = "xLabel33";
            // 
            // xLabel31
            // 
            resources.ApplyResources(this.xLabel31, "xLabel31");
            this.xLabel31.Name = "xLabel31";
            // 
            // txtNameCardYn
            // 
            resources.ApplyResources(this.txtNameCardYn, "txtNameCardYn");
            this.txtNameCardYn.Name = "txtNameCardYn";
            this.txtNameCardYn.TabStop = false;
            // 
            // xLabel27
            // 
            resources.ApplyResources(this.xLabel27, "xLabel27");
            this.xLabel27.Name = "xLabel27";
            // 
            // xLabel28
            // 
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.Name = "xLabel28";
            // 
            // XGroupBox4
            // 
            this.XGroupBox4.Controls.Add(this.rbnSpN1);
            this.XGroupBox4.Controls.Add(this.rbnSpY1);
            resources.ApplyResources(this.XGroupBox4, "XGroupBox4");
            this.XGroupBox4.Name = "XGroupBox4";
            this.XGroupBox4.TabStop = false;
            // 
            // rbnSpN1
            // 
            resources.ApplyResources(this.rbnSpN1, "rbnSpN1");
            this.rbnSpN1.Name = "rbnSpN1";
            this.rbnSpN1.UseVisualStyleBackColor = false;
            this.rbnSpN1.CheckedChanged += new System.EventHandler(this.rbnSpN1_CheckedChanged);
            // 
            // rbnSpY1
            // 
            resources.ApplyResources(this.rbnSpY1, "rbnSpY1");
            this.rbnSpY1.Name = "rbnSpY1";
            this.rbnSpY1.UseVisualStyleBackColor = false;
            this.rbnSpY1.CheckedChanged += new System.EventHandler(this.rbnSpY1_CheckedChanged);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel36
            // 
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.Name = "xLabel36";
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel11
            // 
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel12
            // 
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel13
            // 
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Name = "xLabel13";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdRadioList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // grdRadioList
            // 
            this.grdRadioList.CallerID = '2';
            this.grdRadioList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38});
            this.grdRadioList.ColPerLine = 8;
            this.grdRadioList.Cols = 9;
            this.grdRadioList.ExecuteQuery = null;
            this.grdRadioList.FixedCols = 1;
            this.grdRadioList.FixedRows = 1;
            this.grdRadioList.HeaderHeights.Add(32);
            resources.ApplyResources(this.grdRadioList, "grdRadioList");
            this.grdRadioList.Name = "grdRadioList";
            this.grdRadioList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdRadioList.ParamList")));
            this.grdRadioList.QuerySQL = resources.GetString("grdRadioList.QuerySQL");
            this.grdRadioList.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grdRadioList.RowHeaderVisible = true;
            this.grdRadioList.Rows = 2;
            this.grdRadioList.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdRadioList.ToolTipActive = true;
            this.grdRadioList.Click += new System.EventHandler(this.grdRadioList_Click);
            this.grdRadioList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdRadioList_QueryStarting);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "xray_code";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "xray_gubun";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 2;
            this.xEditGridCell31.CellName = "xray_code_idx";
            this.xEditGridCell31.CellWidth = 30;
            this.xEditGridCell31.Col = 1;
            this.xEditGridCell31.EnableSort = true;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.SuppressRepeating = true;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 50;
            this.xEditGridCell32.CellName = "xray_code_idx_nm";
            this.xEditGridCell32.CellWidth = 120;
            this.xEditGridCell32.Col = 2;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell33.CellName = "tube_vol";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell33.CellWidth = 122;
            this.xEditGridCell33.Col = 3;
            this.xEditGridCell33.DecimalDigits = 3;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.InitValue = "0";
            this.xEditGridCell33.RowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell34.CellName = "tube_cur";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell34.CellWidth = 113;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.DecimalDigits = 3;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.InitValue = "0";
            this.xEditGridCell34.RowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell35.CellName = "xray_time";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell35.CellWidth = 112;
            this.xEditGridCell35.Col = 5;
            this.xEditGridCell35.DecimalDigits = 3;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.InitValue = "0";
            this.xEditGridCell35.RowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell36.CellName = "tube_cur_time";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell36.CellWidth = 112;
            this.xEditGridCell36.Col = 6;
            this.xEditGridCell36.DecimalDigits = 3;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.InitValue = "0";
            this.xEditGridCell36.RowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell37.CellName = "irradiation_time";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell37.CellWidth = 135;
            this.xEditGridCell37.Col = 7;
            this.xEditGridCell37.DecimalDigits = 3;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.InitValue = "0";
            this.xEditGridCell37.RowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell38.CellName = "xray_distance";
            this.xEditGridCell38.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell38.CellWidth = 137;
            this.xEditGridCell38.Col = 8;
            this.xEditGridCell38.DecimalDigits = 3;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.InitValue = "0";
            this.xEditGridCell38.RowFont = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // layDup
            // 
            this.layDup.ExecuteQuery = null;
            this.layDup.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDup.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // toolTip
            // 
            this.toolTip.ShowAlways = true;
            // 
            // rbxAll
            // 
            resources.ApplyResources(this.rbxAll, "rbxAll");
            this.rbxAll.BackColor = IHIS.Framework.XColor.XCalendarWeekDayBackColor;
            this.rbxAll.Checked = true;
            this.rbxAll.ImageList = this.ImageList;
            this.rbxAll.Name = "rbxAll";
            this.rbxAll.TabStop = true;
            this.rbxAll.UseVisualStyleBackColor = false;
            this.rbxAll.Click += new System.EventHandler(this.rbxAll_Click);
            this.rbxAll.CheckedChanged += new System.EventHandler(this.rbxAll_CheckedChanged);
            // 
            // rbxSpecialY
            // 
            resources.ApplyResources(this.rbxSpecialY, "rbxSpecialY");
            this.rbxSpecialY.BackColor = IHIS.Framework.XColor.XRotatorBodyGradientEndColor;
            this.rbxSpecialY.ImageList = this.ImageList;
            this.rbxSpecialY.Name = "rbxSpecialY";
            this.rbxSpecialY.UseVisualStyleBackColor = false;
            this.rbxSpecialY.Click += new System.EventHandler(this.rbxAll_Click);
            this.rbxSpecialY.CheckedChanged += new System.EventHandler(this.rbxAll_CheckedChanged);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xButtonList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // rbxSpecialN
            // 
            resources.ApplyResources(this.rbxSpecialN, "rbxSpecialN");
            this.rbxSpecialN.BackColor = IHIS.Framework.XColor.XRotatorBodyGradientEndColor;
            this.rbxSpecialN.ImageList = this.ImageList;
            this.rbxSpecialN.Name = "rbxSpecialN";
            this.rbxSpecialN.UseVisualStyleBackColor = false;
            this.rbxSpecialN.Click += new System.EventHandler(this.rbxAll_Click);
            this.rbxSpecialN.CheckedChanged += new System.EventHandler(this.rbxAll_CheckedChanged);
            // 
            // vsvXRT0001
            // 
            this.vsvXRT0001.ExecuteQuery = null;
            this.vsvXRT0001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvXRT0001.ParamList")));
            // 
            // XRT0001U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.rbxSpecialN);
            this.Controls.Add(this.rbxSpecialY);
            this.Controls.Add(this.rbxAll);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.grdXRT);
            this.Controls.Add(this.xPanel3);
            this.Name = "XRT0001U00";
            resources.ApplyResources(this, "$this");
            this.Closing += new System.ComponentModel.CancelEventHandler(this.XRT0001U00_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdXRT)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.XGroupBox4.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRadioList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
