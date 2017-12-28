/*
** CPL0105U00 検査項目別DELTA, PANIC, CRITICAL値
** Date		: 2007. 11. 08
** Modified	: 2007. 11. 08
**			  Park Seung Hwan
*/

#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0105U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0105U00 : IHIS.Framework.XScreen
    {
        #region IHIS Controls
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XTextBox txtEmergency;
        private IHIS.Framework.XTextBox txtSpecimenCode;
        private IHIS.Framework.XTextBox txtGumsaName;
        private IHIS.Framework.XTextBox txtHangmogCode;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XComboItem xComboItem3;
        private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XGridHeader xGridHeader2;
        private IHIS.Framework.XGridHeader xGridHeader3;
        private IHIS.Framework.XComboItem xComboItem5;
        private IHIS.Framework.XComboItem xComboItem6;
        private IHIS.Framework.XComboItem xComboItem7;
        private IHIS.Framework.XComboItem xComboItem8;
        private IHIS.Framework.XComboItem xComboItem9;
        private IHIS.Framework.XEditGrid grdPanic;
        private IHIS.Framework.XLabel xLabel5;
        private System.Windows.Forms.Splitter splitter2;
        private IHIS.Framework.XPanel xPanel6;
        private System.Windows.Forms.Splitter splitter3;
        private IHIS.Framework.XPanel xPanel7;
        private System.Windows.Forms.Splitter splitter4;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XEditGrid grdBase;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XComboItem xComboItem10;
        private IHIS.Framework.XComboItem xComboItem11;
        private IHIS.Framework.XComboItem xComboItem12;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XComboItem xComboItem13;
        private IHIS.Framework.XComboItem xComboItem14;
        private IHIS.Framework.XComboItem xComboItem15;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XComboItem xComboItem16;
        private IHIS.Framework.XComboItem xComboItem17;
        private IHIS.Framework.XComboItem xComboItem18;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XGridHeader xGridHeader4;
        private IHIS.Framework.XGridHeader xGridHeader5;
        private IHIS.Framework.XGridHeader xGridHeader6;
        private IHIS.Framework.XEditGrid grdDelta;
        private IHIS.Framework.XEditGrid grdQryBase;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XFindWorker fwkGesan;
        private IHIS.Framework.XGridHeader xGridHeader7;
        private IHIS.Framework.XGridHeader xGridHeader8;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        #endregion

        private System.ComponentModel.Container components = null;
        private XSavePerformer savePerformer = null;

        #region 메인, 소멸자
        public CPL0105U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
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
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0105U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.grdBase = new IHIS.Framework.XEditGrid();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem12 = new IHIS.Framework.XComboItem();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xComboItem13 = new IHIS.Framework.XComboItem();
            this.xComboItem14 = new IHIS.Framework.XComboItem();
            this.xComboItem15 = new IHIS.Framework.XComboItem();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xComboItem16 = new IHIS.Framework.XComboItem();
            this.xComboItem17 = new IHIS.Framework.XComboItem();
            this.xComboItem18 = new IHIS.Framework.XComboItem();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.xGridHeader6 = new IHIS.Framework.XGridHeader();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.grdQryBase = new IHIS.Framework.XEditGrid();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.grdDelta = new IHIS.Framework.XEditGrid();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.fwkGesan = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader7 = new IHIS.Framework.XGridHeader();
            this.xGridHeader8 = new IHIS.Framework.XGridHeader();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdPanic = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtEmergency = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtSpecimenCode = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtGumsaName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtHangmogCode = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQryBase)).BeginInit();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDelta)).BeginInit();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPanic)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.Controls.Add(this.splitter4);
            this.xPanel1.Controls.Add(this.xPanel7);
            this.xPanel1.Controls.Add(this.splitter3);
            this.xPanel1.Controls.Add(this.xPanel6);
            this.xPanel1.Controls.Add(this.splitter2);
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.grdBase);
            this.xPanel8.Controls.Add(this.xLabel7);
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Name = "xPanel8";
            // 
            // grdBase
            // 
            this.grdBase.AddedHeaderLine = 1;
            this.grdBase.CallerID = '4';
            this.grdBase.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24});
            this.grdBase.ColPerLine = 7;
            this.grdBase.ColResizable = true;
            this.grdBase.Cols = 7;
            resources.ApplyResources(this.grdBase, "grdBase");
            this.grdBase.ExecuteQuery = null;
            this.grdBase.FixedRows = 2;
            this.grdBase.HeaderHeights.Add(21);
            this.grdBase.HeaderHeights.Add(0);
            this.grdBase.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader4,
            this.xGridHeader5,
            this.xGridHeader6});
            this.grdBase.MasterLayout = this.grdMaster;
            this.grdBase.Name = "grdBase";
            this.grdBase.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBase.ParamList")));
            this.grdBase.QuerySQL = resources.GetString("grdBase.QuerySQL");
            this.grdBase.Rows = 3;
            this.grdBase.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBase_QueryStarting);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "hangmog_code";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "specimen_code";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "emergency";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "sex";
            this.xEditGridCell18.CellWidth = 59;
            this.xEditGridCell18.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem10,
            this.xComboItem11,
            this.xComboItem12});
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "M";
            // 
            // xComboItem11
            // 
            resources.ApplyResources(this.xComboItem11, "xComboItem11");
            this.xComboItem11.ValueItem = "F";
            // 
            // xComboItem12
            // 
            resources.ApplyResources(this.xComboItem12, "xComboItem12");
            this.xComboItem12.ValueItem = "H";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "nai_from";
            this.xEditGridCell19.CellWidth = 37;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem13,
            this.xComboItem14,
            this.xComboItem15});
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.Row = 1;
            // 
            // xComboItem13
            // 
            resources.ApplyResources(this.xComboItem13, "xComboItem13");
            this.xComboItem13.ValueItem = "Y";
            // 
            // xComboItem14
            // 
            resources.ApplyResources(this.xComboItem14, "xComboItem14");
            this.xComboItem14.ValueItem = "M";
            // 
            // xComboItem15
            // 
            resources.ApplyResources(this.xComboItem15, "xComboItem15");
            this.xComboItem15.ValueItem = "D";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "nai_to";
            this.xEditGridCell20.CellWidth = 38;
            this.xEditGridCell20.Col = 2;
            this.xEditGridCell20.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem16,
            this.xComboItem17,
            this.xComboItem18});
            this.xEditGridCell20.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.Row = 1;
            // 
            // xComboItem16
            // 
            resources.ApplyResources(this.xComboItem16, "xComboItem16");
            this.xComboItem16.ValueItem = "Y";
            // 
            // xComboItem17
            // 
            resources.ApplyResources(this.xComboItem17, "xComboItem17");
            this.xComboItem17.ValueItem = "M";
            // 
            // xComboItem18
            // 
            resources.ApplyResources(this.xComboItem18, "xComboItem18");
            this.xComboItem18.ValueItem = "D";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "from_age";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell21.CellWidth = 44;
            this.xEditGridCell21.Col = 3;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.MaxinumCipher = 3;
            this.xEditGridCell21.Row = 1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "to_age";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell22.CellWidth = 44;
            this.xEditGridCell22.Col = 4;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.MaxinumCipher = 3;
            this.xEditGridCell22.Row = 1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 40;
            this.xEditGridCell23.CellName = "from_standard";
            this.xEditGridCell23.CellWidth = 99;
            this.xEditGridCell23.Col = 5;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.Row = 1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 40;
            this.xEditGridCell24.CellName = "to_standard";
            this.xEditGridCell24.CellWidth = 99;
            this.xEditGridCell24.Col = 6;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.Row = 1;
            // 
            // xGridHeader4
            // 
            this.xGridHeader4.Col = 1;
            this.xGridHeader4.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            this.xGridHeader4.HeaderWidth = 37;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 3;
            this.xGridHeader5.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader5, "xGridHeader5");
            this.xGridHeader5.HeaderWidth = 44;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 5;
            this.xGridHeader6.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader6, "xGridHeader6");
            this.xGridHeader6.HeaderWidth = 99;
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell7,
            this.xEditGridCell8});
            this.grdMaster.ColPerLine = 4;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 5;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(30);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.CellWidth = 87;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "specimen_code";
            this.xEditGridCell2.CellWidth = 73;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "emergency";
            this.xEditGridCell7.CellWidth = 32;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 100;
            this.xEditGridCell8.CellName = "gumsa_name";
            this.xEditGridCell8.CellWidth = 265;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // splitter4
            // 
            resources.ApplyResources(this.splitter4, "splitter4");
            this.splitter4.Name = "splitter4";
            this.splitter4.TabStop = false;
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.grdQryBase);
            this.xPanel7.Controls.Add(this.xLabel8);
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.Name = "xPanel7";
            // 
            // grdQryBase
            // 
            this.grdQryBase.CallerID = '5';
            this.grdQryBase.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell32});
            this.grdQryBase.ColPerLine = 1;
            this.grdQryBase.Cols = 2;
            resources.ApplyResources(this.grdQryBase, "grdQryBase");
            this.grdQryBase.ExecuteQuery = null;
            this.grdQryBase.FixedCols = 1;
            this.grdQryBase.FixedRows = 1;
            this.grdQryBase.HeaderHeights.Add(21);
            this.grdQryBase.MasterLayout = this.grdMaster;
            this.grdQryBase.Name = "grdQryBase";
            this.grdQryBase.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdQryBase.ParamList")));
            this.grdQryBase.QuerySQL = resources.GetString("grdQryBase.QuerySQL");
            this.grdQryBase.RowHeaderVisible = true;
            this.grdQryBase.Rows = 2;
            this.grdQryBase.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdQryBase_QueryStarting);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "hangmog_code";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "specimen_code";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "emergency";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellLen = 80;
            this.xEditGridCell32.CellName = "comments";
            this.xEditGridCell32.CellWidth = 396;
            this.xEditGridCell32.Col = 1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // splitter3
            // 
            resources.ApplyResources(this.splitter3, "splitter3");
            this.splitter3.Name = "splitter3";
            this.splitter3.TabStop = false;
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.grdDelta);
            this.xPanel6.Controls.Add(this.xLabel6);
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Name = "xPanel6";
            // 
            // grdDelta
            // 
            this.grdDelta.AddedHeaderLine = 1;
            this.grdDelta.CallerID = '3';
            this.grdDelta.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31});
            this.grdDelta.ColPerLine = 4;
            this.grdDelta.Cols = 4;
            resources.ApplyResources(this.grdDelta, "grdDelta");
            this.grdDelta.ExecuteQuery = null;
            this.grdDelta.FixedRows = 2;
            this.grdDelta.HeaderHeights.Add(21);
            this.grdDelta.HeaderHeights.Add(0);
            this.grdDelta.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader7,
            this.xGridHeader8});
            this.grdDelta.MasterLayout = this.grdMaster;
            this.grdDelta.Name = "grdDelta";
            this.grdDelta.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDelta.ParamList")));
            this.grdDelta.QuerySQL = resources.GetString("grdDelta.QuerySQL");
            this.grdDelta.Rows = 3;
            this.grdDelta.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdDelta_GridFindSelected);
            this.grdDelta.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDelta_QueryStarting);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "hangmog_code";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "specimen_code";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "emergency";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellLen = 40;
            this.xEditGridCell28.CellName = "from_delta_value";
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.Row = 1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 40;
            this.xEditGridCell29.CellName = "to_delta_value";
            this.xEditGridCell29.Col = 1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.Row = 1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 20;
            this.xEditGridCell30.CellName = "gesan";
            this.xEditGridCell30.CellWidth = 62;
            this.xEditGridCell30.Col = 2;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.FindWorker = this.fwkGesan;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.Row = 1;
            // 
            // fwkGesan
            // 
            this.fwkGesan.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkGesan.ExecuteQuery = null;
            this.fwkGesan.FormText = global::IHIS.CPLS.Properties.Resources.FWKGESAN_FORMTEXT;
            this.fwkGesan.InputSQL = resources.GetString("fwkGesan.InputSQL");
            this.fwkGesan.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkGesan.ParamList")));
            this.fwkGesan.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkGesan.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.ColWidth = 113;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 334;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 100;
            this.xEditGridCell31.CellName = "code_name";
            this.xEditGridCell31.CellWidth = 199;
            this.xEditGridCell31.Col = 3;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.Row = 1;
            // 
            // xGridHeader7
            // 
            this.xGridHeader7.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader7, "xGridHeader7");
            // 
            // xGridHeader8
            // 
            this.xGridHeader8.Col = 2;
            this.xGridHeader8.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader8, "xGridHeader8");
            this.xGridHeader8.HeaderWidth = 62;
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdPanic);
            this.xPanel5.Controls.Add(this.xLabel5);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdPanic
            // 
            this.grdPanic.AddedHeaderLine = 1;
            this.grdPanic.CallerID = '2';
            this.grdPanic.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdPanic.ColPerLine = 7;
            this.grdPanic.ColResizable = true;
            this.grdPanic.Cols = 7;
            resources.ApplyResources(this.grdPanic, "grdPanic");
            this.grdPanic.ExecuteQuery = null;
            this.grdPanic.FixedRows = 2;
            this.grdPanic.HeaderHeights.Add(21);
            this.grdPanic.HeaderHeights.Add(0);
            this.grdPanic.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2,
            this.xGridHeader3});
            this.grdPanic.MasterLayout = this.grdMaster;
            this.grdPanic.Name = "grdPanic";
            this.grdPanic.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPanic.ParamList")));
            this.grdPanic.QuerySQL = resources.GetString("grdPanic.QuerySQL");
            this.grdPanic.Rows = 3;
            this.grdPanic.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPanic_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_code";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "specimen_code";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "emergency";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sex";
            this.xEditGridCell6.CellWidth = 59;
            this.xEditGridCell6.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7});
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.InitValue = "F";
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "M";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "F";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "H";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "nai_from";
            this.xEditGridCell9.CellWidth = 37;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem8});
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.InitValue = "Y";
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.Row = 1;
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "M";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "D";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "nai_to";
            this.xEditGridCell10.CellWidth = 38;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4,
            this.xComboItem9});
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.InitValue = "Y";
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.Row = 1;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "M";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "D";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "from_age";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.CellWidth = 44;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.InitValue = "0";
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.MaxinumCipher = 3;
            this.xEditGridCell11.Row = 1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "to_age";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.CellWidth = 44;
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.InitValue = "999";
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.MaxinumCipher = 3;
            this.xEditGridCell12.Row = 1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 40;
            this.xEditGridCell13.CellName = "from_value";
            this.xEditGridCell13.CellWidth = 99;
            this.xEditGridCell13.Col = 5;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.Row = 1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 40;
            this.xEditGridCell14.CellName = "to_value";
            this.xEditGridCell14.CellWidth = 99;
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 37;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 3;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 44;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 5;
            this.xGridHeader3.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 99;
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdMaster);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.txtEmergency);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.txtSpecimenCode);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.txtGumsaName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.txtHangmogCode);
            this.xPanel2.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // txtEmergency
            // 
            resources.ApplyResources(this.txtEmergency, "txtEmergency");
            this.txtEmergency.Name = "txtEmergency";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // txtSpecimenCode
            // 
            resources.ApplyResources(this.txtSpecimenCode, "txtSpecimenCode");
            this.txtSpecimenCode.Name = "txtSpecimenCode";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // txtGumsaName
            // 
            resources.ApplyResources(this.txtGumsaName, "txtGumsaName");
            this.txtGumsaName.Name = "txtGumsaName";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // txtHangmogCode
            // 
            resources.ApplyResources(this.txtHangmogCode, "txtHangmogCode");
            this.txtHangmogCode.Name = "txtHangmogCode";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // CPL0105U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0105U00";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQryBase)).EndInit();
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDelta)).EndInit();
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPanic)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grdBase.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdBase.SetRelationKey("specimen_code", "specimen_code");
            this.grdBase.SetRelationKey("emergency", "emergency");
            this.grdBase.SetRelationTable("cpl0104");
            this.grdPanic.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdPanic.SetRelationKey("specimen_code", "specimen_code");
            this.grdPanic.SetRelationKey("emergency", "emergency");
            this.grdPanic.SetRelationTable("cpl0105");
            this.grdDelta.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdDelta.SetRelationKey("specimen_code", "specimen_code");
            this.grdDelta.SetRelationKey("emergency", "emergency");
            this.grdDelta.SetRelationTable("cpl0120");
            this.grdQryBase.SetRelationKey("hangmog_code", "hangmog_code");
            this.grdQryBase.SetRelationKey("specimen_code", "specimen_code");
            this.grdQryBase.SetRelationKey("emergency", "emergency");
            this.grdQryBase.SetRelationTable("cpl0103");

            this.CurrMQLayout = this.grdMaster;
            savePerformer = new XSavePerformer(this);
            this.grdBase.SavePerformer = savePerformer;
            this.grdDelta.SavePerformer = savePerformer;
            this.grdPanic.SavePerformer = savePerformer;
            this.grdQryBase.SavePerformer = savePerformer;
        }
        #endregion

        /********************************************************/

        #region [ #01 btnList_ButtonClick ]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            try
            {
                switch (e.Func)
                {
                    case FunctionType.Insert:
                        if (this.CurrMSLayout == this.grdMaster)
                            e.IsBaseCall = false;
                        else if (this.CurrMSLayout == this.grdDelta)
                        {
                            if (this.grdDelta.RowCount == 1)
                                e.IsBaseCall = false;
                        }
                        else if (this.CurrMSLayout == this.grdQryBase)
                        {
                            if (this.grdQryBase.RowCount == 1)
                                e.IsBaseCall = false;
                        }
                        break;

                    case FunctionType.Update:
                        e.IsBaseCall = false;

                        if (this.SaveValid())
                        {
                            Service.BeginTransaction();
                            if (!this.grdBase.SaveLayout() ||
                                !this.grdDelta.SaveLayout() ||
                                !this.grdPanic.SaveLayout() ||
                                !this.grdQryBase.SaveLayout())
                            {
                                throw new Exception();
                            }
                            else
                            {
                                // Update Success
                                Service.CommitTransaction();
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception err)
            {
                Service.RollbackTransaction();
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#01-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        #region [ #02 각 그리드의 쿼리 스타팅 이벤트 ]
        private void grdMaster_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdMaster.SetBindVarValue("f_hangmog_code", txtHangmogCode.GetDataValue());
            grdMaster.SetBindVarValue("f_specimen_code", txtSpecimenCode.GetDataValue());
            grdMaster.SetBindVarValue("f_emergency", txtEmergency.GetDataValue());
            grdMaster.SetBindVarValue("f_gumsa_name", txtGumsaName.GetDataValue());
        }

        private void grdPanic_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdPanic.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdPanic.SetBindVarValue("f_hangmog_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "hangmog_code"));
            grdPanic.SetBindVarValue("f_specimen_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code"));
            grdPanic.SetBindVarValue("f_emergency", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "emergency"));
        }

        private void grdDelta_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdDelta.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdDelta.SetBindVarValue("f_hangmog_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "hangmog_code"));
            grdDelta.SetBindVarValue("f_specimen_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code"));
            grdDelta.SetBindVarValue("f_emergency", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "emergency"));
        }

        private void grdBase_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdBase.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdBase.SetBindVarValue("f_hangmog_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "hangmog_code"));
            grdBase.SetBindVarValue("f_specimen_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code"));
            grdBase.SetBindVarValue("f_emergency", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "emergency"));
        }

        private void grdQryBase_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdQryBase.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdQryBase.SetBindVarValue("f_hangmog_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "hangmog_code"));
            grdQryBase.SetBindVarValue("f_specimen_code", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "specimen_code"));
            grdQryBase.SetBindVarValue("f_emergency", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "emergency"));
        }
        #endregion

        #region [ #03 Grid FindSelected ]
        private void grdDelta_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
        {
            if (e.ColName.Equals("gesan"))
            {
                grdDelta.SetItemValue(grdDelta.CurrentRowNumber, "code_name", e.ReturnValues[1]);
            }
        }
        #endregion

        /******************** CUSTOM METHOD ***************************/

        #region [ C #01 Save Valid ]
        private bool SaveValid()
        {
            for (int i = 0; i < grdPanic.RowCount; i++)
            {
                if (grdPanic.GetItemString(i, "sex").Trim().Equals(string.Empty)) return false;
            }

            for (int i = 0; i < grdDelta.RowCount; i++)
            {
                if (grdDelta.GetItemString(i, "from_delta_value").Trim().Equals(string.Empty)) return false;
            }

            for (int i = 0; i < grdBase.RowCount; i++)
            {
                if (grdBase.GetItemString(i, "sex").Trim().Equals(string.Empty)) return false;
            }

            return true;
        }
        #endregion

        /******************** SAVE PERFORMER *********************************/

        #region XSave Performer
        public class XSavePerformer : ISavePerformer
        {
            private CPL0105U00 parent = null;
            private bool result = true;
            private string cmdText = string.Empty;

            public XSavePerformer(CPL0105U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                if (callerID.Equals('1'))
                {
                    // Master Grid에는 수정, 삭제, 입력이 존재하지 않음
                    result = false;
                }
                else
                {
                    item.BindVarList.Add("q_user_id", UserInfo.UserID);
                    item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                    if (callerID.Equals('2'))		// PANIC
                    {
                        #region PANIC Query
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO CPL0105 (
											SYS_DATE,              SYS_ID,                  UPD_DATE,               UPD_ID,
											HANGMOG_CODE 
											,SPECIMEN_CODE
											,EMERGENCY    
											,SEX          
											,NAI_FROM     
											,NAI_TO       
											,FROM_AGE     
											,TO_AGE       
											,FROM_VALUE
											,TO_VALUE  
                                            ,HOSP_CODE 
											) VALUES (
											SYSDATE,               :q_user_id,               SYSDATE,               :q_user_id,
											:f_hangmog_code 
											,:f_specimen_code
											,:f_emergency    
											,:f_sex          
											,:f_nai_from     
											,:f_nai_to       
											,:f_from_age     
											,:f_to_age       
											,:f_from_value
											,:f_to_value 
                                            ,:f_hosp_code 
											)";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE CPL0105                            
											   SET UPD_ID           = :q_user_id      
												 , UPD_DATE         = SYSDATE         
												 , FROM_VALUE       = :f_from_value
												 , TO_VALUE         = :f_to_value  
											 WHERE HANGMOG_CODE     = :f_hangmog_code 
											   AND SPECIMEN_CODE    = :f_specimen_code
											   AND EMERGENCY        = :f_emergency    
											   AND SEX              = :f_sex          
											   AND NAI_FROM         = :f_nai_from     
											   AND NAI_TO           = :f_nai_to       
											   AND FROM_AGE         = :f_from_age     
											   AND TO_AGE           = :f_to_age
                                               AND HOSP_CODE        = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE CPL0105
											 WHERE HANGMOG_CODE     = :f_hangmog_code 
											   AND SPECIMEN_CODE    = :f_specimen_code
											   AND EMERGENCY        = :f_emergency    
											   AND SEX              = :f_sex          
											   AND NAI_FROM         = :f_nai_from     
											   AND NAI_TO           = :f_nai_to       
											   AND FROM_AGE         = :f_from_age     
											   AND TO_AGE           = :f_to_age
                                               AND HOSP_CODE        = :f_hosp_code";
                                break;
                        }
                        #endregion
                    }
                    else if (callerID.Equals('3'))	// DELTA
                    {
                        #region DELTA Query
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO CPL0120 (
											SYS_DATE,        SYS_ID,         UPD_DATE,          UPD_ID,
											HANGMOG_CODE    
											,SPECIMEN_CODE   
											,EMERGENCY       
											,FROM_DELTA_VALUE
											,TO_DELTA_VALUE  
											,GESAN	
                                            ,HOSP_CODE				                          
											) VALUES (
											SYSDATE,         :q_user_id,      SYSDATE,          :q_user_id,
											 :f_hangmog_code    
											,:f_specimen_code   
											,:f_emergency       
											,:f_from_delta_value
											,:f_to_delta_value  
											,:f_gesan   
                                            ,:f_hosp_code        
											)";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE CPL0120
											   SET USER_ID           = :q_user_id
											 	 , UPD_DATE          = SYSDATE
												 , FROM_DELTA_VALUE  = :f_from_delta_value
												 , TO_DELTA_VALUE    = :f_to_delta_value  
												 , GESAN             = :f_gesan           
											 WHERE HANGMOG_CODE      = :f_hangmog_code 
											   AND SPECIMEN_CODE     = :f_specimen_code
											   AND EMERGENCY         = :f_emergency
                                               AND HOSP_CODE         = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE CPL0120
											 WHERE HANGMOG_CODE      = :f_hangmog_code 
											   AND SPECIMEN_CODE     = :f_specimen_code
											   AND EMERGENCY         = :f_emergency
                                               AND HOSP_CODE         = :f_hosp_code";
                                break;
                        }
                        #endregion
                    }
                    else if (callerID.Equals('4'))	// BASE (基準値)
                    {
                        #region BASE (基準値)
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO CPL0104 (
											SYS_DATE,              SYS_ID,                  UPD_DATE,                   UPD_ID,
											 HANGMOG_CODE 
											,SPECIMEN_CODE
											,EMERGENCY    
											,SEX          
											,NAI_FROM     
											,NAI_TO       
											,FROM_AGE     
											,TO_AGE       
											,FROM_STANDARD
											,TO_STANDARD
                                            ,HOSP_CODE   
											) VALUES (
											SYSDATE,               :q_user_id,              SYSDATE,                    :q_user_id,
											 :f_hangmog_code 
											,:f_specimen_code
											,:f_emergency    
											,:f_sex          
											,:f_nai_from     
											,:f_nai_to       
											,:f_from_age     
											,:f_to_age       
											,:f_from_standard
											,:f_to_standard 
                                            ,:f_hosp_code 
											)";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE CPL0104
											   SET UPD_ID           = :q_user_id
											 	 , UPD_DATE         = SYSDATE
												 , FROM_STANDARD    = :f_from_standard                              
												 , TO_STANDARD      = :f_to_standard                            
											 WHERE HANGMOG_CODE     = :f_hangmog_code                     
											   AND SPECIMEN_CODE    = :f_specimen_code                     
											   AND EMERGENCY        = :f_emergency                        
											   AND SEX              = :f_sex          
											   AND NAI_FROM         = :f_nai_from                               
											   AND NAI_TO           = :f_nai_to                           
											   AND FROM_AGE         = :f_from_age     
											   AND TO_AGE           = :f_to_age
                                               AND HOSP_CODE        = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE CPL0104
											 WHERE HANGMOG_CODE     = :f_hangmog_code 
											   AND SPECIMEN_CODE    = :f_specimen_code
											   AND EMERGENCY        = :f_emergency    
											   AND SEX              = :f_sex          
											   AND NAI_FROM         = :f_nai_from     
											   AND NAI_TO           = :f_nai_to       
											   AND FROM_AGE         = :f_from_age     
											   AND TO_AGE           = :f_to_age
                                               AND HOSP_CODE        = :f_hosp_code";
                                break;
                        }
                        #endregion
                    }
                    else if (callerID.Equals('5'))	// COMMENTS
                    {
                        #region COMMENTS
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO CPL0103 (
											SYS_DATE,        SYS_ID,          UPD_DATE,            UPD_ID,
											 HANGMOG_CODE    
											,SPECIMEN_CODE   
											,EMERGENCY       
											,COMMENTS
											) VALUES (
											SYSDATE,         :q_user_id,      SYSDATE,             :q_user_id,
											 :f_hangmog_code    
											,:f_specimen_code   
											,:f_emergency       
											,:f_comments
											)";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE CPL0103
											   SET UPD_ID            = :q_user_id
											 	 , UPD_DATE          = SYSDATE
												 , COMMENTS          = :f_comments           
											 WHERE HANGMOG_CODE      = :f_hangmog_code 
											   AND SPECIMEN_CODE     = :f_specimen_code
											   AND EMERGENCY         = :f_emergency
                                               AND HOSP_CODE         = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE CPL0103
											 WHERE HANGMOG_CODE      = :f_hangmog_code 
											   AND SPECIMEN_CODE     = :f_specimen_code
											   AND EMERGENCY         = :f_emergency
                                               AND HOSP_CODE         = :f_hosp_code";
                                break;
                        }
                        #endregion
                    }

                    result = Service.ExecuteNonQuery(cmdText, item.BindVarList);
                }

                return result;
            }
        }
        #endregion
    }
}
