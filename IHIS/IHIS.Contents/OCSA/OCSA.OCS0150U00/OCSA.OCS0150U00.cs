#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using IHIS.Framework;
using IHIS.OCSA.Properties;
using ComboListItemInfo = IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo;
using OCS0150Q00GridOCS0150Info = IHIS.CloudConnector.Contracts.Models.Ocsa.OCS0150Q00GridOCS0150Info;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Caching;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0150U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0150U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Message처리
        string mMsg = "", mCap = "";

        //bool isgrdOCS0133Save = false;
        //bool isSaved0133 = false;

        string mHospCode = EnvironInfo.HospCode;
        //사용자
        private string mMemb = "";
        private string mGwa = "";
        private bool mDoctorLogin = false;

        private IHIS.OCS.OrderBiz mOrderBiz;

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGrid grdOCS0150;
        private System.Windows.Forms.PictureBox pictureBox1;
        private XEditGridCell xEditGridCell12;
        private XDisplayBox dbxMembName;
        private XDictComboBox cboGwa;
        private XLabel xLabel1;
        private XLabel xLabel3;
        private XFindBox fbxmemb;
        private XEditGridCell xEditGridCell6;
        private XComboBox cboIOGubun;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XLabel xLabel2;
        private XComboItem xComboItem3;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell18;
        private XComboItem xComboItem4;
        private XComboItem xComboItem5;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell24;
        private const string SPACE = "  ";
        private string _rule = "";
        private string _time = "";
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0150U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //			SaveLayoutList.Add(this.grdOCS0150);
            //this.grdOCS0150.SavePerformer = new XSavePerformer(this);

            // Create param list and ExecuteQuery for gridOCS0150
            this.grdOCS0150.ParamList = new List<string>(new String[] { "f_doctor", "f_gwa", "f_io_gubun", "f_order_date" });
            this.grdOCS0150.ExecuteQuery = grdOCS0150_ExecuteQuery;

            // Create param list and ExecuteQuery for combo gwa
            this.cboGwa.ParamList = new List<string>(new String[] { "f_memb" });
            this.cboGwa.ExecuteQuery = CoboGwa_ExecuteQuery;

            if (NetInfo.Language.Equals(LangMode.En))
            {
                //xEditGridCell19.CellWidth = 50;
                //xEditGridCell18.CellWidth = 44;
                //xEditGridCell5.CellWidth = 255;

                //xEditGridCell7.CellWidth = 46;
                //xEditGridCell8.CellWidth = 46;
                //xEditGridCell9.CellWidth = 84;

                //xEditGridCell13.CellWidth = 70;
                //xEditGridCell14.CellWidth = 95;
                //xEditGridCell16.CellWidth = 85;
                //xEditGridCell20.CellWidth = 74;
                //xEditGridCell21.CellWidth = 105;
                //xEditGridCell22.CellWidth = 79;
                grdOCS0150.AutoSizeColumn(xEditGridCell19.Col,46);
                grdOCS0150.AutoSizeColumn(xEditGridCell18.Col,42);
                grdOCS0150.AutoSizeColumn(xEditGridCell5.Col,87);
                grdOCS0150.AutoSizeColumn(xEditGridCell7.Col,46);
                grdOCS0150.AutoSizeColumn(xEditGridCell8.Col,44);
                grdOCS0150.AutoSizeColumn(xEditGridCell9.Col,64);
                grdOCS0150.AutoSizeColumn(xEditGridCell13.Col,46);
                grdOCS0150.AutoSizeColumn(xEditGridCell14.Col,47);
                grdOCS0150.AutoSizeColumn(xEditGridCell16.Col,57);
                grdOCS0150.AutoSizeColumn(xEditGridCell20.Col,44);
                grdOCS0150.AutoSizeColumn(xEditGridCell21.Col,75);
                grdOCS0150.AutoSizeColumn(xEditGridCell22.Col,49);
            }

            
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
        /// 2015/07/17
        /// Note: xEditGridCell10 is disable(refer MED-1448) by setting CellWidth = 0 and IsUpdatable = false
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0150U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS0150 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.cboIOGubun = new IHIS.Framework.XComboBox();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.dbxMembName = new IHIS.Framework.XDisplayBox();
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.fbxmemb = new IHIS.Framework.XFindBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0150)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.grdOCS0150);
            this.xPanel2.Controls.Add(this.cboIOGubun);
            this.xPanel2.Controls.Add(this.dbxMembName);
            this.xPanel2.Controls.Add(this.cboGwa);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.fbxmemb);
            this.xPanel2.Controls.Add(this.pictureBox1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOCS0150
            // 
            resources.ApplyResources(this.grdOCS0150, "grdOCS0150");
            this.grdOCS0150.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell19,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell12,
            this.xEditGridCell6,
            this.xEditGridCell17,
            this.xEditGridCell15,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell18,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell24});
            this.grdOCS0150.ColPerLine = 19;
            this.grdOCS0150.Cols = 20;
            this.grdOCS0150.ExecuteQuery = null;
            this.grdOCS0150.FixedCols = 1;
            this.grdOCS0150.FixedRows = 1;
            this.grdOCS0150.FocusColumnName = "doctor";
            this.grdOCS0150.HeaderHeights.Add(73);
            this.grdOCS0150.Name = "grdOCS0150";
            this.grdOCS0150.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0150.ParamList")));
            this.grdOCS0150.QuerySQL = resources.GetString("grdOCS0150.QuerySQL");
            this.grdOCS0150.RowHeaderVisible = true;
            this.grdOCS0150.Rows = 2;
            this.grdOCS0150.ToolTipActive = true;
            this.grdOCS0150.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0150_GridFindClick);
            this.grdOCS0150.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0133_GridColumnChanged);
            this.grdOCS0150.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0133_QueryStarting);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellLen = 1;
            this.xEditGridCell19.CellName = "checking_drug_yn";
            this.xEditGridCell19.CellWidth = 37;
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellLen = 8;
            this.xEditGridCell1.CellName = "doctor";
            this.xEditGridCell1.CellWidth = 72;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellLen = 40;
            this.xEditGridCell2.CellName = "doctor_name";
            this.xEditGridCell2.CellWidth = 86;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "gwa";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "gwa_name";
            this.xEditGridCell6.CellWidth = 144;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellLen = 1;
            this.xEditGridCell17.CellName = "io_gubun";
            this.xEditGridCell17.CellWidth = 62;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem4,
            this.xComboItem5});
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderBackColor = IHIS.Framework.XColor.XGridRowHeaderBackColor;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = global::IHIS.OCSA.Properties.Resource.xComboItem1;
            this.xComboItem4.ValueItem = "O";
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = global::IHIS.OCSA.Properties.Resource.xComboItem2;
            this.xComboItem5.ValueItem = "I";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "hosp_code";
            this.xEditGridCell15.CellWidth = 45;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellLen = 1;
            this.xEditGridCell3.CellName = "drg_prt_yn";
            this.xEditGridCell3.CellWidth = 36;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellLen = 1;
            this.xEditGridCell4.CellName = "xrt_prt_yn";
            this.xEditGridCell4.CellWidth = 36;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 1;
            this.xEditGridCell5.CellName = "reser_prt_yn";
            this.xEditGridCell5.CellWidth = 38;
            this.xEditGridCell5.Col = 8;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellLen = 1;
            this.xEditGridCell7.CellName = "vitalsigns_pop_yn";
            this.xEditGridCell7.CellWidth = 34;
            this.xEditGridCell7.Col = 10;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellLen = 1;
            this.xEditGridCell8.CellName = "allergy_pop_yn";
            this.xEditGridCell8.CellWidth = 30;
            this.xEditGridCell8.Col = 11;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellLen = 1;
            this.xEditGridCell9.CellName = "specialwrite_pop_yn";
            this.xEditGridCell9.CellWidth = 30;
            this.xEditGridCell9.Col = 12;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellLen = 1;
            this.xEditGridCell10.CellName = "emr_pop_yn";
            this.xEditGridCell10.CellWidth = 0;
            this.xEditGridCell10.Col = 5;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellLen = 1;
            this.xEditGridCell11.CellName = "do_order_pop_yn";
            this.xEditGridCell11.CellWidth = 31;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellLen = 1;
            this.xEditGridCell13.CellName = "sentou_search_yn";
            this.xEditGridCell13.CellWidth = 30;
            this.xEditGridCell13.Col = 13;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellLen = 1;
            this.xEditGridCell14.CellName = "order_label_prt_yn";
            this.xEditGridCell14.CellWidth = 30;
            this.xEditGridCell14.Col = 14;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellLen = 1;
            this.xEditGridCell16.CellName = "general_disp_yn";
            this.xEditGridCell16.CellWidth = 43;
            this.xEditGridCell16.Col = 15;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellLen = 1;
            this.xEditGridCell18.CellName = "same_name_check_yn";
            this.xEditGridCell18.CellWidth = 42;
            this.xEditGridCell18.Col = 7;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.HeaderTextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "potion_drug_order";
            this.xEditGridCell20.CellWidth = 43;
            this.xEditGridCell20.Col = 16;
            this.xEditGridCell20.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellName = "disease_name_unregistered";
            this.xEditGridCell21.CellWidth = 43;
            this.xEditGridCell21.Col = 17;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellName = "infection";
            this.xEditGridCell22.CellWidth = 43;
            this.xEditGridCell22.Col = 18;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellName = "back_time";
            this.xEditGridCell24.CellWidth = 76;
            this.xEditGridCell24.Col = 19;
            this.xEditGridCell24.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // cboIOGubun
            // 
            resources.ApplyResources(this.cboIOGubun, "cboIOGubun");
            this.cboIOGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem1,
            this.xComboItem2});
            this.cboIOGubun.Name = "cboIOGubun";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = global::IHIS.OCSA.Properties.Resource.xComboItem3;
            this.xComboItem3.ValueItem = "%";
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = global::IHIS.OCSA.Properties.Resource.xComboItem1;
            this.xComboItem1.ValueItem = "O";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = global::IHIS.OCSA.Properties.Resource.xComboItem2;
            this.xComboItem2.ValueItem = "I";
            // 
            // dbxMembName
            // 
            resources.ApplyResources(this.dbxMembName, "dbxMembName");
            this.dbxMembName.Name = "dbxMembName";
            // 
            // cboGwa
            // 
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.ExecuteQuery = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGwa.ParamList")));
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboGwa_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // fbxmemb
            // 
            resources.ApplyResources(this.fbxmemb, "fbxmemb");
            this.fbxmemb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxmemb.Name = "fbxmemb";
            this.fbxmemb.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxmemb_FindClick);
            this.fbxmemb.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxmemb_DataValidating);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // OCS0150U00
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0150U00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0150U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0150)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0150;

            //            if (UserInfo.UserGroup.Substring(0, 3) == "ADM")
            //            {
            //                grdOCS0150.QuerySQL = grdOCS0150.QuerySQL + " ORDER BY A.INPUT_CONTROL";
            //            }
            //            else
            //            {
            ////                grdOCS0150.QuerySQL = grdOCS0150.QuerySQL +
            //// @" AND A.INPUT_CONTROL NOT IN('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z')
            //// ORDER BY A.INPUT_CONTROL";
            //            }

            //            grdOCS0150.SetBindVarValue("f_input_control", "");
            grdOCS0150.QueryLayout(false);
        }
        #endregion

        #region [ButtonList Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            SetMsg("");
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = grdOCS0150.InsertRow();
                        this.grdOCS0150.SetItemValue(currentRow, "doctor", mMemb);
                        this.grdOCS0150.SetItemValue(currentRow, "doctor_name", dbxMembName.Text);
                        this.grdOCS0150.SetItemValue(currentRow, "gwa", mGwa);
                        this.grdOCS0150.SetItemValue(currentRow, "potion_drug_order", "Y");
                        this.grdOCS0150.SetItemValue(currentRow, "disease_name_unregistered", "Y");                        

                        if (mGwa != "%")
                            this.grdOCS0150.SetItemValue(currentRow, "gwa_name", cboGwa.SelectedText);
                        else
                            this.grdOCS0150.SetItemValue(currentRow, "gwa_name", Resource.xComboItem3);

                        if (this.cboIOGubun.GetDataValue().ToString() == "%")
                        {
                            if (EnvironInfo.CurrSystemID == "OCSO" || EnvironInfo.CurrSystemID == "INSO")
                                this.grdOCS0150.SetItemValue(currentRow, "io_gubun", "O");
                            else if (EnvironInfo.CurrSystemID == "OCSI" || EnvironInfo.CurrSystemID == "INSI")
                                this.grdOCS0150.SetItemValue(currentRow, "io_gubun", "I");
                            else
                                this.grdOCS0150.SetItemValue(currentRow, "io_gubun", "O");
                        }
                        else
                        {
                            if(this.cboIOGubun.GetDataValue().ToString() == "O")
                                this.grdOCS0150.SetItemValue(currentRow, "io_gubun", "O");
                            else
                                this.grdOCS0150.SetItemValue(currentRow, "io_gubun", "I");
                        }


                    }
                    else
                    {
                        e.IsBaseCall = false;
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }
                    break;
                case FunctionType.Update:

                    e.IsBaseCall = false;

                    try
                    {
                        // TODO comment: use connect cloud
                        /*Service.BeginTransaction();

                        if (this.grdOCS0150.SaveLayout())
                        {

                        }
                        else
                        {
                            XMessageBox.Show(Resource.XMessageBox1);
                            Service.RollbackTransaction();
                        }

                        Service.CommitTransaction();*/

                        // Connect cloud service impl save layout
                        List<OCS0150Q00GridOCS0150Info> lstGridOcs0150Info = CreateListDataInfo();
                        if (lstGridOcs0150Info == null || lstGridOcs0150Info.Count < 1)
                        {
                            return;
                        }
                        OCS0150Q00SaveLayoutForGridOCS0150Args args = new OCS0150Q00SaveLayoutForGridOCS0150Args();
                        args.GridOcs0150Info = lstGridOcs0150Info;
                        args.UserId = UserInfo.UserID;
                        UpdateResult updateResult =
                            CloudService.Instance.Submit<UpdateResult, OCS0150Q00SaveLayoutForGridOCS0150Args>(args);
                        
                        if (updateResult.ExecutionStatus != ExecutionStatus.Success || updateResult.Result == false)
                        {
                            XMessageBox.Show(Resource.XMessageBox1);
                        }
                        else
                        {
                            XMessageBox.Show(Resource.SMS_TEXT);
                            this.grdOCS0150.ResetUpdate();    
                        }

                        // End connect cloud
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        this.mMsg = (NetInfo.Language == LangMode.Ko ? Resource.XMessageBox2_KO : Resource.XMessageBox2_JP);
                        this.mCap = (NetInfo.Language == LangMode.Ko ? Resource.XMessageBox3_Ko : Resource.XMessageBox3_Jp);

                        XMessageBox.Show(this.mMsg + "-" + Service.ErrFullMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    break;
                case FunctionType.Query:
                    //this.grdOCS0150.QueryLayout(false);
                    grdOCS0150.QueryLayout(true);
                    break;

                default:
                    break;
            }
        }


        #endregion

        #region [grdOCS0133]
        private void grdOCS0133_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            //e.Cancel = false;
            //switch (e.ColName)
            //{
            //    case "input_control":
            //        if(e.ChangeValue.ToString().Trim() == "" ) break;

            //        // 조건조회로 Data를 가져오는 경우 아래경우 다 check
            //        // 중복 Check
            //        // 현재 화면
            //        for(int i = 0; i < grdOCS0150.RowCount; i++)
            //        {
            //            if(i != e.RowNumber)
            //            {
            //                if( grdOCS0150.GetItemString(i, "input_control").Trim() == e.ChangeValue.ToString().Trim() )
            //                {
            //                    mbxMsg = NetInfo.Language == LangMode.Jr ? "入力制御コードに同一コードがあります。 ご確認ください。" : "입력제어코드가 중복됩니다. 확인바랍니다.";
            //                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
            //                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
            //                    e.Cancel= true;								
            //                }
            //            }
            //        } 

            //        if(e.Cancel) break;

            //        // Delete Table Check
            //        // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
            //        if(grdOCS0150.DeletedRowTable != null)
            //        {
            //            foreach(DataRow row in grdOCS0150.DeletedRowTable.Rows)
            //            {
            //                if(row[e.ColName].ToString() == e.ChangeValue.ToString())
            //                    break;
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }



        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }
            return celReturn;
        }
        #endregion


        #region grdOCS0133 SetBindVarValue
        private void grdOCS0133_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS0150.SetBindVarValue("f_doctor", this.mMemb.ToString());
            this.grdOCS0150.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue().ToString());
            this.grdOCS0150.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdOCS0150.SetBindVarValue("f_io_gubun", this.cboIOGubun.GetDataValue().ToString());
            this.grdOCS0150.SetBindVarValue("f_order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
        }
        #endregion

        #region [FindWorker]
        private XFindWorker GetFindWorker(string findMode)
        {
            XFindWorker fdwCommon = new XFindWorker();

            switch (findMode)
            {
                case "memb":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    // TODO comment: use connect to cloud
                    /*fdwCommon.InputSQL = @"SELECT '%', '全体', 3
                                             FROM SYS.DUAL
                                            UNION ALL
                                           SELECT A.USER_ID, B.USER_NM, 3 
                                             FROM ADM3200 A, ADM3211 B 
                                            WHERE A.HOSP_CODE = :f_hosp_code
                                              AND A.USER_ID = B.USER_ID 
                                              AND B.START_DATE = ( SELECT MAX(X.START_DATE) 
                                                                     FROM ADM3211 X 
                                                                    WHERE X.HOSP_CODE = :f_hosp_code
                                                                      AND B.HOSP_CODE = X.HOSP_CODE 
                                                                      AND X.USER_ID = B.USER_ID 
                                                                      AND X.START_DATE <= TRUNC(SYSDATE) ) 
                                              AND B.USER_NM LIKE :f_find1 || '%' 
                                            ORDER BY 3, 1";

                    fdwCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);*/

                    // Start connect cloud
                    fdwCommon.ParamList = new List<string>(new String[] { "f_find1" });

                    fdwCommon.ExecuteQuery = FindboxMemb;
                    // End connect cloud

                    fdwCommon.FormText = Resource.formText;
                    fdwCommon.ColInfos.Add("memb", Resource.memb, FindColType.String, 100, 0, true, FilterType.Yes);
                    fdwCommon.ColInfos.Add("memb_name", Resource.memb_name, FindColType.String, 300, 0, true, FilterType.Yes);

                    break;
            }
            return fdwCommon;
        }
        #endregion

        #region [XSavePerformer Class]
        //        private class XSavePerformer : IHIS.Framework.ISavePerformer
        //        {
        //            private OCS0150U00 parent = null;

        //            public XSavePerformer(OCS0150U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                item.BindVarList.Add("f_user_id",UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
        //                //item.BindVarList.Add("f_io_gubun", "I");

        //                switch(callerID)
        //                {
        //                    case '1':
        //                    switch(item.RowState)
        //                    {
        //                        case DataRowState.Added:
        //                            cmdText = @"INSERT INTO OCS0150
        //                                             (  
        //                                                SYS_DATE,                
        //                                                SYS_ID,                
        //                                                UPD_DATE,                
        //                                                UPD_ID,                
        //                                                DOCTOR,                
        //                                                GWA,                
        //                                                HOSP_CODE,                
        //                                                IO_GUBUN,                
        //                                                ALLERGY_POP_YN,                
        //                                                DO_ORDER_POP_YN,                
        //                                                DRG_PRT_YN,                
        //                                                EMR_POP_YN,                
        //                                                RESER_PRT_YN,                
        //                                                SPECIALWRITE_POP_YN,                
        //                                                VITALSIGNS_POP_YN,                
        //                                                XRT_PRT_YN,
        //                                                SENTOU_SEARCH_YN,
        //                                                ORDER_LABEL_PRT_YN,
        //                                                GENERAL_DISP_YN,
        //                                                SAME_NAME_CHECK_YN  
        //                                              )
        //                                        VALUES
        //                                             ( SYSDATE
        //                                             , :f_user_id
        //                                             , SYSDATE
        //                                             , :f_user_id
        //                                             , :f_doctor
        //                                             , :f_gwa
        //                                             , :f_hosp_code
        //                                             , :f_io_gubun
        //                                             , NVL(:f_allergy_pop_yn     , 'N')
        //                                             , NVL(:f_do_order_pop_yn    , 'N')
        //                                             , NVL(:f_drg_prt_yn         , 'N')
        //                                             , NVL(:f_emr_pop_yn         , 'N')
        //                                             , NVL(:f_reser_prt_yn       , 'N')
        //                                             , NVL(:f_specialwrite_pop_yn, 'N')
        //                                             , NVL(:f_vitalsigns_pop_yn  , 'N')
        //                                             , NVL(:f_xrt_prt_yn         , 'N')
        //                                             , NVL(:f_sentou_search_yn   , 'N')
        //                                             , NVL(:f_order_label_prt_yn , 'N')
        //                                             , NVL(:f_general_disp_yn    , 'N')
        //                                             , NVL(:f_same_name_check_yn , 'N')
        //                                              )";
        //                            break;
        //                        case DataRowState.Modified:
        //                            cmdText = @"UPDATE OCS0150 A
        //                                           SET ALLERGY_POP_YN       = NVL(:f_allergy_pop_yn     , 'N')                
        //                                               , DO_ORDER_POP_YN     = NVL(:f_do_order_pop_yn    , 'N')                
        //                                               , DRG_PRT_YN          = NVL(:f_drg_prt_yn         , 'N')                
        //                                               , EMR_POP_YN          = NVL(:f_emr_pop_yn         , 'N')                
        //                                               , RESER_PRT_YN        = NVL(:f_reser_prt_yn       , 'N')                
        //                                               , SPECIALWRITE_POP_YN = NVL(:f_specialwrite_pop_yn, 'N')                
        //                                               , VITALSIGNS_POP_YN   = NVL(:f_vitalsigns_pop_yn  , 'N')                
        //                                               , XRT_PRT_YN          = NVL(:f_xrt_prt_yn         , 'N')
        //                                               , SENTOU_SEARCH_YN    = NVL(:f_sentou_search_yn   , 'N')
        //                                               , ORDER_LABEL_PRT_YN  = NVL(:f_order_label_prt_yn , 'N')
        //                                               , GENERAL_DISP_YN     = NVL(:f_general_disp_yn    , 'N')
        //                                               , SAME_NAME_CHECK_YN  = NVL(:f_same_name_check_yn , 'N')
        //                                          WHERE A.DOCTOR    = :f_doctor
        //                                            AND A.GWA       = :f_gwa
        //                                            AND A.IO_GUBUN  = :f_io_gubun
        //                                            AND A.HOSP_CODE = :f_hosp_code";
        //                            break;
        //                        case DataRowState.Deleted:
        //                            cmdText = @"DELETE
        //                                          FROM OCS0150 A
        //                                         WHERE A.DOCTOR    = :f_doctor
        //                                           AND A.GWA       = :f_gwa
        //                                           AND A.IO_GUBUN  = :f_io_gubun
        //                                           AND A.HOSP_CODE = :f_hosp_code";
        //                            break;
        //                    }
        //                    break;
        //                }
        //                return Service.ExecuteNonQuery(cmdText,item.BindVarList);
        //            }
        //        }
        #endregion

        private void fbxmemb_FindClick(object sender, CancelEventArgs e)
        {
            this.fbxmemb.FindWorker = this.GetFindWorker("memb");
        }

        private void fbxmemb_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string name = "";
            // 사용자 체크 
            this.mOrderBiz.LoadColumnCodeName("user_id", e.DataValue, ref name);
            this.dbxMembName.SetDataValue(name);
            this.mMemb = "";
            this.mMemb = this.fbxmemb.GetDataValue().ToString();
            this.MakeGwaCombo(e.DataValue);

        }

        private void OCS0150U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.mOrderBiz = new IHIS.OCS.OrderBiz(this.Name);
            if (UserInfo.UserGubun == UserType.Doctor)
                this.mDoctorLogin = true;
            else
                this.mDoctorLogin = false;


            PostCallHelper.PostCall(this.PostScreenLoad);
        }

        private void PostScreenLoad()
        {
            //this.MakeGwaCombo(UserInfo.UserID);


            if (EnvironInfo.CurrSystemID == "OCSA")
            {
            }
            else
            {

                this.fbxmemb.SetEditValue(UserInfo.UserID);
                this.fbxmemb.AcceptData();
                this.cboGwa.SetEditValue(UserInfo.Gwa);
                this.cboGwa.AcceptData();

                if (EnvironInfo.CurrSystemID == "OCSO" || EnvironInfo.CurrSystemID == "INSO")
                    this.cboIOGubun.SetEditValue("O");
                else if (EnvironInfo.CurrSystemID == "OCSI" || EnvironInfo.CurrSystemID == "INSI")
                    this.cboIOGubun.SetEditValue("I");

                //this.fbxmemb.Protect = true;
            }
            if (this.mDoctorLogin)
            {

            }
            else
            {
                this.cboIOGubun.SetEditValue("%");
                this.cboGwa.SetEditValue("%");
                this.cboGwa.AcceptData();
            }

            this.cboIOGubun.Enabled = this.mDoctorLogin;
            this.cboGwa.Enabled = this.mDoctorLogin;
            this.fbxmemb.Enabled = this.mDoctorLogin;


        }



        #region [ 사용자별 진료과 ]

        private void MakeGwaCombo(string aMemb)
        {
            this.cboGwa.SelectedValueChanged -= new EventHandler(cboGwa_SelectedValueChanged);
            this.cboGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.cboGwa.SetBindVarValue("f_memb", this.mMemb);

            //            this.cboGwa.UserSQL = @" SELECT '%', '全体'
            //                                       FROM SYS.DUAL
            //
            //                                      UNION ALL
            //
            //                                     SELECT A.DOCTOR_GWA, B.GWA_NAME 
            //                                       FROM BAS0272 A 
            //                                          , BAS0260 B 
            //                                      WHERE A.HOSP_CODE  = :f_hosp_code
            //                                        AND A.SABUN      = :f_memb
            //                                        AND B.HOSP_CODE  = A.HOSP_CODE 
            //                                        AND A.DOCTOR_GWA = B.GWA 
            //                                        AND TRUNC(SYSDATE) BETWEEN B.START_DATE AND NVL(B.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) 
            //                                        AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
            //                                      ORDER BY 1 ";

            this.cboGwa.SetDictDDLB();
            this.cboGwa.SelectedValueChanged += new EventHandler(cboGwa_SelectedValueChanged);
        }

        void cboGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            this.mMemb = this.fbxmemb.GetDataValue();

            btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        private void cboGwa_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.mGwa = this.cboGwa.GetDataValue().ToString();
        }

        #region connect to cloud service

        /// <summary>
        /// grdOCS0150 get data from cloud service
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        IList<object[]> grdOCS0150_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> listObj = new List<object[]>();
            OCS0150Q00GridOCS0150Args gridOcs0150Args = new OCS0150Q00GridOCS0150Args();
            gridOcs0150Args.Doctor = varCollection["f_doctor"].VarValue;
            gridOcs0150Args.Gwa = varCollection["f_gwa"].VarValue;
            gridOcs0150Args.IoGubun = varCollection["f_io_gubun"].VarValue;
            gridOcs0150Args.OrderDate = varCollection["f_order_date"].VarValue;
            OCS0150Q00GridOCS0150Result result =
                CloudService.Instance.Submit<OCS0150Q00GridOCS0150Result, OCS0150Q00GridOCS0150Args>(gridOcs0150Args);
            if (result != null)
            {
                List<OCS0150Q00GridOCS0150Info> lstOcs0150Info = result.GridOcs0150Info;
                if (lstOcs0150Info != null && lstOcs0150Info.Count > 0)
                {
                    foreach (OCS0150Q00GridOCS0150Info ocs0150Info in lstOcs0150Info)
                    {
                        listObj.Add(new object[]
	                    {
                            ocs0150Info.CheckingDrugYn,
	                        ocs0150Info.Doctor,
	                        ocs0150Info.DoctorName,
	                        ocs0150Info.Gwa,
	                        ocs0150Info.GwaName,
	                        ocs0150Info.IoGubun,
	                        ocs0150Info.HospCode,
	                        ocs0150Info.DrgPrtYn,
	                        ocs0150Info.XrtPrtYn,
	                        ocs0150Info.ReserPrtYn,
	                        ocs0150Info.VitalsignsPopYn,
	                        ocs0150Info.AllergyPopYn,
	                        ocs0150Info.SpecialwritePopYn,
	                        ocs0150Info.EmrPopYn,
	                        ocs0150Info.DoOrderPopYn,
	                        ocs0150Info.SentouSearchYn,
	                        ocs0150Info.OrderLabelPrtYn,
	                        ocs0150Info.GeneralDispYn,
	                        ocs0150Info.SameNameCheckYn,
                            ocs0150Info.PotionDrugOrder,
                            ocs0150Info.DiseaseNameUnregistered,
                            ocs0150Info.Infection,
                            ocs0150Info.EmrBakRemindRule + SPACE + ocs0150Info.EmrBakRemindTime
	                    });

                        _rule = ocs0150Info.EmrBakRemindRule;
                        _time = ocs0150Info.EmrBakRemindTime;
                    }
                }
            }
            return listObj;
        }

        /// <summary>
        /// find box memb
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> FindboxMemb(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            OCS0150Q00FindboxMembArgs findboxMembArgs = new OCS0150Q00FindboxMembArgs();

            ComboResult comboResult =
                CloudService.Instance.Submit<ComboResult, OCS0150Q00FindboxMembArgs>(findboxMembArgs);
            if (comboResult != null)
            {
                List<ComboListItemInfo> lstItemInfo = comboResult.ComboItem;
                foreach (ComboListItemInfo itemInfo in lstItemInfo)
                {
                    lstObject.Add(new object[]
	                {
	                    itemInfo.Code,
	                    itemInfo.CodeName
	                });
                }
            }
            return lstObject;
        }
        #endregion

        #region Create list data for save grid OCS0150

        /// <summary>
        /// CreateListDataInfo
        /// </summary>
        /// <returns></returns>
        private List<OCS0150Q00GridOCS0150Info> CreateListDataInfo()
        {
            List<OCS0150Q00GridOCS0150Info> lstGridOcs0150Info = new List<OCS0150Q00GridOCS0150Info>();
            for (int i = 0; i < grdOCS0150.RowCount; i++)
            {
                if (grdOCS0150.GetRowState(i) == DataRowState.Added || grdOCS0150.GetRowState(i) == DataRowState.Modified)
                {
                    OCS0150Q00GridOCS0150Info ocs0150Info = new OCS0150Q00GridOCS0150Info();
                    ocs0150Info.CheckingDrugYn = grdOCS0150.GetItemString(i, "checking_drug_yn") != String.Empty ? grdOCS0150.GetItemString(i, "checking_drug_yn") : "N";
                    ocs0150Info.Doctor = grdOCS0150.GetItemString(i, "doctor") != String.Empty ? grdOCS0150.GetItemString(i, "doctor") : "N";
                    ocs0150Info.DoctorName = grdOCS0150.GetItemString(i, "doctor_name") != String.Empty ? grdOCS0150.GetItemString(i, "doctor_name") : "N";
                    ocs0150Info.Gwa = grdOCS0150.GetItemString(i, "gwa") != String.Empty ? grdOCS0150.GetItemString(i, "gwa") : "N";
                    ocs0150Info.GwaName = grdOCS0150.GetItemString(i, "gwa_name") != String.Empty ? grdOCS0150.GetItemString(i, "gwa_name") : "N";
                    ocs0150Info.IoGubun = grdOCS0150.GetItemString(i, "io_gubun") != String.Empty ? grdOCS0150.GetItemString(i, "io_gubun") : "N";
                    //ocs0150Info.DrgPrtYn = grdOCS0150.GetItemString(i, "drg_prt_yn") != String.Empty ? grdOCS0150.GetItemString(i, "drg_prt_yn") : "N";
                    //ocs0150Info.XrtPrtYn = grdOCS0150.GetItemString(i, "xrt_prt_yn") != String.Empty ? grdOCS0150.GetItemString(i, "xrt_prt_yn") : "N";
                    ocs0150Info.DrgPrtYn = "N";
                    ocs0150Info.XrtPrtYn = "N";
                    ocs0150Info.ReserPrtYn = grdOCS0150.GetItemString(i, "reser_prt_yn") != String.Empty ? grdOCS0150.GetItemString(i, "reser_prt_yn") : "N";
                    ocs0150Info.VitalsignsPopYn = grdOCS0150.GetItemString(i, "vitalsigns_pop_yn") != String.Empty ? grdOCS0150.GetItemString(i, "vitalsigns_pop_yn") : "N";
                    ocs0150Info.AllergyPopYn = grdOCS0150.GetItemString(i, "allergy_pop_yn") != String.Empty ? grdOCS0150.GetItemString(i, "allergy_pop_yn") : "N";
                    ocs0150Info.SpecialwritePopYn = grdOCS0150.GetItemString(i, "specialwrite_pop_yn") != String.Empty ? grdOCS0150.GetItemString(i, "specialwrite_pop_yn") : "N";
                    ocs0150Info.EmrPopYn = grdOCS0150.GetItemString(i, "emr_pop_yn") != String.Empty ? grdOCS0150.GetItemString(i, "emr_pop_yn") : "N";
                    ocs0150Info.DoOrderPopYn = grdOCS0150.GetItemString(i, "do_order_pop_yn") != String.Empty ? grdOCS0150.GetItemString(i, "do_order_pop_yn") : "N";
                    ocs0150Info.SentouSearchYn = grdOCS0150.GetItemString(i, "sentou_search_yn") != String.Empty ? grdOCS0150.GetItemString(i, "sentou_search_yn") : "N";
                    ocs0150Info.OrderLabelPrtYn = grdOCS0150.GetItemString(i, "order_label_prt_yn") != String.Empty ? grdOCS0150.GetItemString(i, "order_label_prt_yn") : "N";
                    ocs0150Info.GeneralDispYn = grdOCS0150.GetItemString(i, "general_disp_yn") != String.Empty ? grdOCS0150.GetItemString(i, "general_disp_yn") : "N";
                    ocs0150Info.SameNameCheckYn = grdOCS0150.GetItemString(i, "same_name_check_yn") != String.Empty ? grdOCS0150.GetItemString(i, "same_name_check_yn") : "N";
                    ocs0150Info.PotionDrugOrder = grdOCS0150.GetItemString(i, "potion_drug_order") != String.Empty ? grdOCS0150.GetItemString(i, "potion_drug_order") : "Y";
                    ocs0150Info.DiseaseNameUnregistered = grdOCS0150.GetItemString(i, "disease_name_unregistered") != String.Empty ? grdOCS0150.GetItemString(i, "disease_name_unregistered") : "Y";
                    ocs0150Info.Infection = grdOCS0150.GetItemString(i, "infection") != String.Empty ? grdOCS0150.GetItemString(i, "infection") : "N";
                    ocs0150Info.EmrBakRemindRule = _rule;
                    ocs0150Info.EmrBakRemindTime = _time;
                    
                    ocs0150Info.DataRowState = grdOCS0150.GetRowState(i).ToString();

                    lstGridOcs0150Info.Add(ocs0150Info);
                }

            }

            if (grdOCS0150.DeletedRowTable != null && grdOCS0150.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdOCS0150.DeletedRowTable.Rows)
                {
                    OCS0150Q00GridOCS0150Info ocs0150Info = new OCS0150Q00GridOCS0150Info();
                    ocs0150Info.Doctor = row["doctor"].ToString();
                    ocs0150Info.Gwa = row["gwa"].ToString();
                    ocs0150Info.IoGubun = row["io_gubun"].ToString();
                    ocs0150Info.DataRowState = DataRowState.Deleted.ToString();

                    lstGridOcs0150Info.Add(ocs0150Info);
                }
            }

            return lstGridOcs0150Info;
        }
        #endregion

        #region combo gwa
        /// <summary>
        /// CoboGwa get data from cloud service
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> CoboGwa_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> listObject = new List<object[]>();
            ComboDoctorGwaArgs args = new ComboDoctorGwaArgs();
            args.Memb = varCollection["f_memb"].VarValue;
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, ComboDoctorGwaArgs>(args);
            if (comboResult != null)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo comboListItemInfo in listItemInfo)
                    {
                        listObject.Add(new object[]
	                    {
	                        comboListItemInfo.Code,
	                        comboListItemInfo.CodeName
	                    });
                    }
                }
            }
            return listObject;
        }

        #endregion

        private void grdOCS0150_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            if (grd == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

            if (e.ColName == "back_time")
            {
                string list_permission = grdOCS0150.GetItemString(grdOCS0150.CurrentRowNumber, "back_time").ToString();

                /*FrmSettingTime frmSettingTime = new FrmSettingTime("W1", "11:50:00");*/
                string backTime = grdOCS0150.GetItemString(grdOCS0150.CurrentRowNumber, "back_time");
                string rule = "";
                string time = "";
                if (!string.IsNullOrEmpty(backTime))
                {
                    if (backTime.Contains(SPACE))
                    {
                        string[] bufferSepaArr = backTime.Split(new string[] { SPACE }, StringSplitOptions.None);
                        rule = !string.IsNullOrEmpty(bufferSepaArr[0]) ? bufferSepaArr[0] : "D";
                        time = bufferSepaArr[1];
                    }
                    else
                    {
                        rule = "D";
                        time = backTime;
                    }
                }

                FrmSettingTime frmSettingTime = new FrmSettingTime(rule, time);
                frmSettingTime.invokeControl = new FrmSettingTime.InvokeControl(InvokeControl);
                frmSettingTime.StartPosition = FormStartPosition.Manual;
                frmSettingTime.Location = new Point(Cursor.Position.X - 70, Cursor.Position.Y + 9);

                frmSettingTime.ShowDialog(this);
            }
        }

        private void InvokeControl(string rule, string time)
        {
            _rule = rule;
            _time = time;
            string backTimeValue = rule + SPACE + time;
            if (!string.IsNullOrEmpty(backTimeValue))
            {
                grdOCS0150.SetItemValue(grdOCS0150.CurrentRowNumber, "back_time", backTimeValue);
            }
        }
    }
}

