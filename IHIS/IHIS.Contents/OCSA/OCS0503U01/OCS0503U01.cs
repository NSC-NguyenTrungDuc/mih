#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0503U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0503U01 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Control HashTable
        Hashtable htOCS0503;
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //환자등록번호
        string mBunho = "";
        //의뢰일자
        string mRequest_date = "";

        string mConsult_gwa = "";
        string mConsult_doctor = "";

        //Find관련
        XFindBox ActiveFincBox;

        //hospital code
        string mHospCode = EnvironInfo.HospCode;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPictureBox xPictureBox1;
        private IHIS.Framework.XEditGrid grdOCS0503;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XPanel pnlOCS0503;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XDisplayBox dbxConsult_gwa_name;
        private IHIS.Framework.XDisplayBox dbxConsult_doctor_name;
        private IHIS.Framework.XCheckBox chkWangjin_yn;
        private IHIS.Framework.XDisplayBox dbxApp_date;
        private IHIS.Framework.XTextBox txtAnswer;
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
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XPatientBox pbxRequest_bunho;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XDisplayBox dbxReq_gwa_name;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XDisplayBox dbxReq_doctor_name;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XDatePicker dpkReq_date;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XButton btnReq_remark;
        private IHIS.Framework.XDisplayBox dbxSang_code3;
        private IHIS.Framework.XDisplayBox dbxSang_code2;
        private IHIS.Framework.XDisplayBox dbxSang_code1;
        private IHIS.Framework.XDisplayBox dbxSang_name1;
        private IHIS.Framework.XDisplayBox dbxSang_name2;
        private IHIS.Framework.XDisplayBox dbxSang_name3;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XCheckBox chkConfirm_yn;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XCheckBox chkAnswer_end_yn;
        private IHIS.Framework.XComboBox cboAmPm_gubun;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XTextBox txtReq_remark;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XCheckBox chkDisplay_yn;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XTextBox txtConsult_sang_name;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.MultiLayout dloPrintInfo;
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
        private XCheckBox cbxMsgSysYN;
        private System.ComponentModel.IContainer components;

        public OCS0503U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            SaveLayoutList.Add(grdOCS0503);
            grdOCS0503.SavePerformer = new XSavePerformer(this);

            BindExecuteQueryMethod();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0503U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxMsgSysYN = new IHIS.Framework.XCheckBox();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dpkReq_date = new IHIS.Framework.XDatePicker();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.pbxRequest_bunho = new IHIS.Framework.XPatientBox();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.grdOCS0503 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlOCS0503 = new IHIS.Framework.XPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.cboAmPm_gubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.txtConsult_sang_name = new IHIS.Framework.XTextBox();
            this.chkDisplay_yn = new IHIS.Framework.XCheckBox();
            this.txtReq_remark = new IHIS.Framework.XTextBox();
            this.chkAnswer_end_yn = new IHIS.Framework.XCheckBox();
            this.chkConfirm_yn = new IHIS.Framework.XCheckBox();
            this.dbxSang_name1 = new IHIS.Framework.XDisplayBox();
            this.dbxSang_name2 = new IHIS.Framework.XDisplayBox();
            this.dbxSang_name3 = new IHIS.Framework.XDisplayBox();
            this.dbxSang_code1 = new IHIS.Framework.XDisplayBox();
            this.dbxSang_code2 = new IHIS.Framework.XDisplayBox();
            this.dbxSang_code3 = new IHIS.Framework.XDisplayBox();
            this.btnReq_remark = new IHIS.Framework.XButton();
            this.dbxReq_doctor_name = new IHIS.Framework.XDisplayBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.dbxReq_gwa_name = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dbxApp_date = new IHIS.Framework.XDisplayBox();
            this.txtAnswer = new IHIS.Framework.XTextBox();
            this.chkWangjin_yn = new IHIS.Framework.XCheckBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dbxConsult_doctor_name = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxConsult_gwa_name = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dloPrintInfo = new IHIS.Framework.MultiLayout();
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
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRequest_bunho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0503)).BeginInit();
            this.pnlOCS0503.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloPrintInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.cbxMsgSysYN);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // cbxMsgSysYN
            // 
            this.cbxMsgSysYN.AccessibleDescription = null;
            this.cbxMsgSysYN.AccessibleName = null;
            resources.ApplyResources(this.cbxMsgSysYN, "cbxMsgSysYN");
            this.cbxMsgSysYN.BackgroundImage = null;
            this.cbxMsgSysYN.Checked = true;
            this.cbxMsgSysYN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMsgSysYN.Name = "cbxMsgSysYN";
            this.toolTip1.SetToolTip(this.cbxMsgSysYN, resources.GetString("cbxMsgSysYN.ToolTip"));
            this.cbxMsgSysYN.UseVisualStyleBackColor = false;
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.toolTip1.SetToolTip(this.xButtonList1, resources.GetString("xButtonList1.ToolTip"));
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Controls.Add(this.xPictureBox1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip1.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.dpkReq_date);
            this.xPanel3.Controls.Add(this.xLabel8);
            this.xPanel3.Controls.Add(this.pbxRequest_bunho);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip1.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // dpkReq_date
            // 
            this.dpkReq_date.AccessibleDescription = null;
            this.dpkReq_date.AccessibleName = null;
            resources.ApplyResources(this.dpkReq_date, "dpkReq_date");
            this.dpkReq_date.BackgroundImage = null;
            this.dpkReq_date.IsVietnameseYearType = false;
            this.dpkReq_date.Name = "dpkReq_date";
            this.toolTip1.SetToolTip(this.dpkReq_date, resources.GetString("dpkReq_date.ToolTip"));
            this.dpkReq_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkReq_date_DataValidating);
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            this.toolTip1.SetToolTip(this.xLabel8, resources.GetString("xLabel8.ToolTip"));
            // 
            // pbxRequest_bunho
            // 
            this.pbxRequest_bunho.AccessibleDescription = null;
            this.pbxRequest_bunho.AccessibleName = null;
            resources.ApplyResources(this.pbxRequest_bunho, "pbxRequest_bunho");
            this.pbxRequest_bunho.BackgroundImage = null;
            this.pbxRequest_bunho.Name = "pbxRequest_bunho";
            this.toolTip1.SetToolTip(this.pbxRequest_bunho, resources.GetString("pbxRequest_bunho.ToolTip"));
            this.pbxRequest_bunho.PatientSelectionFailed += new System.EventHandler(this.pbxRequest_bunho_PatientSelectionFailed);
            this.pbxRequest_bunho.PatientSelected += new System.EventHandler(this.pbxRequest_bunho_PatientSelected);
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.AccessibleDescription = null;
            this.xPictureBox1.AccessibleName = null;
            resources.ApplyResources(this.xPictureBox1, "xPictureBox1");
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.BackgroundImage = null;
            this.xPictureBox1.Font = null;
            this.xPictureBox1.ImageLocation = null;
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.xPictureBox1, resources.GetString("xPictureBox1.ToolTip"));
            // 
            // grdOCS0503
            // 
            resources.ApplyResources(this.grdOCS0503, "grdOCS0503");
            this.grdOCS0503.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell35,
            this.xEditGridCell3,
            this.xEditGridCell31,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell39,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell2,
            this.xEditGridCell34,
            this.xEditGridCell36,
            this.xEditGridCell38,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell37});
            this.grdOCS0503.ColPerLine = 3;
            this.grdOCS0503.Cols = 3;
            this.grdOCS0503.ControlBinding = true;
            this.grdOCS0503.ExecuteQuery = null;
            this.grdOCS0503.FixedRows = 1;
            this.grdOCS0503.HeaderHeights.Add(21);
            this.grdOCS0503.Name = "grdOCS0503";
            this.grdOCS0503.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0503.ParamList")));
            this.grdOCS0503.QuerySQL = resources.GetString("grdOCS0503.QuerySQL");
            this.grdOCS0503.ReadOnly = true;
            this.grdOCS0503.Rows = 2;
            this.toolTip1.SetToolTip(this.grdOCS0503, resources.GetString("grdOCS0503.ToolTip"));
            this.grdOCS0503.ToolTipActive = true;
            this.grdOCS0503.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0503_PreSaveLayout);
            this.grdOCS0503.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0503_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "req_date";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "req_gwa";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "req_doctor";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "pkocs0503";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "consult_gwa";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "consult_doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "wangjin_yn";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "sang_code1";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 200;
            this.xEditGridCell9.CellName = "sang_name1";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "sang_code2";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 200;
            this.xEditGridCell11.CellName = "sang_name2";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "sang_code3";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 200;
            this.xEditGridCell13.CellName = "sang_name3";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "consult_sang_name";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 4000;
            this.xEditGridCell14.CellName = "req_remark";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "app_date";
            this.xEditGridCell15.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 4000;
            this.xEditGridCell16.CellName = "answer";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "in_out_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "fkout1001";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "fkinp1001";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "print_yn";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "emer_gubun";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "real_jinryo_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "result_arrive_date";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "confirm_yn";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "answer_end_yn";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "jinryo_pre_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xEditGridCell2.SuppressRepeating = true;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "ampm_gubun";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "req_end_yn";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "display_yn";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "suname";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "sex";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "age";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "consult_gwa_name";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell27.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "consult_doctor_name";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell28.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellName = "req_gwa_name";
            this.xEditGridCell29.CellWidth = 100;
            this.xEditGridCell29.Col = 1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell29.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "req_doctor_name";
            this.xEditGridCell30.CellWidth = 100;
            this.xEditGridCell30.Col = 2;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell30.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "old_old_answer_end_yn";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip1.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // pnlOCS0503
            // 
            this.pnlOCS0503.AccessibleDescription = null;
            this.pnlOCS0503.AccessibleName = null;
            resources.ApplyResources(this.pnlOCS0503, "pnlOCS0503");
            this.pnlOCS0503.BackgroundImage = null;
            this.pnlOCS0503.Controls.Add(this.label1);
            this.pnlOCS0503.Controls.Add(this.xLabel6);
            this.pnlOCS0503.Controls.Add(this.cboAmPm_gubun);
            this.pnlOCS0503.Controls.Add(this.txtConsult_sang_name);
            this.pnlOCS0503.Controls.Add(this.chkDisplay_yn);
            this.pnlOCS0503.Controls.Add(this.txtReq_remark);
            this.pnlOCS0503.Controls.Add(this.chkAnswer_end_yn);
            this.pnlOCS0503.Controls.Add(this.chkConfirm_yn);
            this.pnlOCS0503.Controls.Add(this.dbxSang_name1);
            this.pnlOCS0503.Controls.Add(this.dbxSang_name2);
            this.pnlOCS0503.Controls.Add(this.dbxSang_name3);
            this.pnlOCS0503.Controls.Add(this.dbxSang_code1);
            this.pnlOCS0503.Controls.Add(this.dbxSang_code2);
            this.pnlOCS0503.Controls.Add(this.dbxSang_code3);
            this.pnlOCS0503.Controls.Add(this.btnReq_remark);
            this.pnlOCS0503.Controls.Add(this.dbxReq_doctor_name);
            this.pnlOCS0503.Controls.Add(this.xLabel9);
            this.pnlOCS0503.Controls.Add(this.dbxReq_gwa_name);
            this.pnlOCS0503.Controls.Add(this.xLabel7);
            this.pnlOCS0503.Controls.Add(this.dbxApp_date);
            this.pnlOCS0503.Controls.Add(this.txtAnswer);
            this.pnlOCS0503.Controls.Add(this.chkWangjin_yn);
            this.pnlOCS0503.Controls.Add(this.xLabel5);
            this.pnlOCS0503.Controls.Add(this.xLabel4);
            this.pnlOCS0503.Controls.Add(this.xLabel3);
            this.pnlOCS0503.Controls.Add(this.dbxConsult_doctor_name);
            this.pnlOCS0503.Controls.Add(this.xLabel2);
            this.pnlOCS0503.Controls.Add(this.dbxConsult_gwa_name);
            this.pnlOCS0503.Controls.Add(this.xLabel1);
            this.pnlOCS0503.Font = null;
            this.pnlOCS0503.Name = "pnlOCS0503";
            this.toolTip1.SetToolTip(this.pnlOCS0503, resources.GetString("pnlOCS0503.ToolTip"));
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            this.toolTip1.SetToolTip(this.xLabel6, resources.GetString("xLabel6.ToolTip"));
            // 
            // cboAmPm_gubun
            // 
            this.cboAmPm_gubun.AccessibleDescription = null;
            this.cboAmPm_gubun.AccessibleName = null;
            resources.ApplyResources(this.cboAmPm_gubun, "cboAmPm_gubun");
            this.cboAmPm_gubun.BackgroundImage = null;
            this.cboAmPm_gubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboAmPm_gubun.Name = "cboAmPm_gubun";
            this.toolTip1.SetToolTip(this.cboAmPm_gubun, resources.GetString("cboAmPm_gubun.ToolTip"));
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "A";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "P";
            // 
            // txtConsult_sang_name
            // 
            this.txtConsult_sang_name.AccessibleDescription = null;
            this.txtConsult_sang_name.AccessibleName = null;
            resources.ApplyResources(this.txtConsult_sang_name, "txtConsult_sang_name");
            this.txtConsult_sang_name.ApplyByteLimit = true;
            this.txtConsult_sang_name.BackgroundImage = null;
            this.txtConsult_sang_name.Name = "txtConsult_sang_name";
            this.txtConsult_sang_name.ReadOnly = true;
            this.txtConsult_sang_name.TabStop = false;
            this.toolTip1.SetToolTip(this.txtConsult_sang_name, resources.GetString("txtConsult_sang_name.ToolTip"));
            // 
            // chkDisplay_yn
            // 
            this.chkDisplay_yn.AccessibleDescription = null;
            this.chkDisplay_yn.AccessibleName = null;
            resources.ApplyResources(this.chkDisplay_yn, "chkDisplay_yn");
            this.chkDisplay_yn.BackgroundImage = null;
            this.chkDisplay_yn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDisplay_yn.Name = "chkDisplay_yn";
            this.toolTip1.SetToolTip(this.chkDisplay_yn, resources.GetString("chkDisplay_yn.ToolTip"));
            this.chkDisplay_yn.UseVisualStyleBackColor = false;
            // 
            // txtReq_remark
            // 
            this.txtReq_remark.AccessibleDescription = null;
            this.txtReq_remark.AccessibleName = null;
            resources.ApplyResources(this.txtReq_remark, "txtReq_remark");
            this.txtReq_remark.ApplyByteLimit = true;
            this.txtReq_remark.BackgroundImage = null;
            this.txtReq_remark.Name = "txtReq_remark";
            this.txtReq_remark.ReadOnly = true;
            this.txtReq_remark.TabStop = false;
            this.toolTip1.SetToolTip(this.txtReq_remark, resources.GetString("txtReq_remark.ToolTip"));
            // 
            // chkAnswer_end_yn
            // 
            this.chkAnswer_end_yn.AccessibleDescription = null;
            this.chkAnswer_end_yn.AccessibleName = null;
            resources.ApplyResources(this.chkAnswer_end_yn, "chkAnswer_end_yn");
            this.chkAnswer_end_yn.BackgroundImage = null;
            this.chkAnswer_end_yn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAnswer_end_yn.Name = "chkAnswer_end_yn";
            this.toolTip1.SetToolTip(this.chkAnswer_end_yn, resources.GetString("chkAnswer_end_yn.ToolTip"));
            this.chkAnswer_end_yn.UseVisualStyleBackColor = false;
            // 
            // chkConfirm_yn
            // 
            this.chkConfirm_yn.AccessibleDescription = null;
            this.chkConfirm_yn.AccessibleName = null;
            resources.ApplyResources(this.chkConfirm_yn, "chkConfirm_yn");
            this.chkConfirm_yn.BackgroundImage = null;
            this.chkConfirm_yn.Name = "chkConfirm_yn";
            this.toolTip1.SetToolTip(this.chkConfirm_yn, resources.GetString("chkConfirm_yn.ToolTip"));
            this.chkConfirm_yn.UseVisualStyleBackColor = false;
            // 
            // dbxSang_name1
            // 
            this.dbxSang_name1.AccessibleDescription = null;
            this.dbxSang_name1.AccessibleName = null;
            resources.ApplyResources(this.dbxSang_name1, "dbxSang_name1");
            this.dbxSang_name1.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxSang_name1.EdgeRounding = false;
            this.dbxSang_name1.Image = null;
            this.dbxSang_name1.Name = "dbxSang_name1";
            this.toolTip1.SetToolTip(this.dbxSang_name1, resources.GetString("dbxSang_name1.ToolTip"));
            // 
            // dbxSang_name2
            // 
            this.dbxSang_name2.AccessibleDescription = null;
            this.dbxSang_name2.AccessibleName = null;
            resources.ApplyResources(this.dbxSang_name2, "dbxSang_name2");
            this.dbxSang_name2.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxSang_name2.EdgeRounding = false;
            this.dbxSang_name2.Image = null;
            this.dbxSang_name2.Name = "dbxSang_name2";
            this.toolTip1.SetToolTip(this.dbxSang_name2, resources.GetString("dbxSang_name2.ToolTip"));
            // 
            // dbxSang_name3
            // 
            this.dbxSang_name3.AccessibleDescription = null;
            this.dbxSang_name3.AccessibleName = null;
            resources.ApplyResources(this.dbxSang_name3, "dbxSang_name3");
            this.dbxSang_name3.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxSang_name3.EdgeRounding = false;
            this.dbxSang_name3.Image = null;
            this.dbxSang_name3.Name = "dbxSang_name3";
            this.toolTip1.SetToolTip(this.dbxSang_name3, resources.GetString("dbxSang_name3.ToolTip"));
            // 
            // dbxSang_code1
            // 
            this.dbxSang_code1.AccessibleDescription = null;
            this.dbxSang_code1.AccessibleName = null;
            resources.ApplyResources(this.dbxSang_code1, "dbxSang_code1");
            this.dbxSang_code1.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxSang_code1.EdgeRounding = false;
            this.dbxSang_code1.Image = null;
            this.dbxSang_code1.Name = "dbxSang_code1";
            this.toolTip1.SetToolTip(this.dbxSang_code1, resources.GetString("dbxSang_code1.ToolTip"));
            // 
            // dbxSang_code2
            // 
            this.dbxSang_code2.AccessibleDescription = null;
            this.dbxSang_code2.AccessibleName = null;
            resources.ApplyResources(this.dbxSang_code2, "dbxSang_code2");
            this.dbxSang_code2.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxSang_code2.EdgeRounding = false;
            this.dbxSang_code2.Image = null;
            this.dbxSang_code2.Name = "dbxSang_code2";
            this.toolTip1.SetToolTip(this.dbxSang_code2, resources.GetString("dbxSang_code2.ToolTip"));
            // 
            // dbxSang_code3
            // 
            this.dbxSang_code3.AccessibleDescription = null;
            this.dbxSang_code3.AccessibleName = null;
            resources.ApplyResources(this.dbxSang_code3, "dbxSang_code3");
            this.dbxSang_code3.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxSang_code3.EdgeRounding = false;
            this.dbxSang_code3.Image = null;
            this.dbxSang_code3.Name = "dbxSang_code3";
            this.toolTip1.SetToolTip(this.dbxSang_code3, resources.GetString("dbxSang_code3.ToolTip"));
            // 
            // btnReq_remark
            // 
            this.btnReq_remark.AccessibleDescription = null;
            this.btnReq_remark.AccessibleName = null;
            resources.ApplyResources(this.btnReq_remark, "btnReq_remark");
            this.btnReq_remark.BackgroundImage = null;
            this.btnReq_remark.Image = ((System.Drawing.Image)(resources.GetObject("btnReq_remark.Image")));
            this.btnReq_remark.Name = "btnReq_remark";
            this.toolTip1.SetToolTip(this.btnReq_remark, resources.GetString("btnReq_remark.ToolTip"));
            this.btnReq_remark.Click += new System.EventHandler(this.btnReq_remark_Click);
            // 
            // dbxReq_doctor_name
            // 
            this.dbxReq_doctor_name.AccessibleDescription = null;
            this.dbxReq_doctor_name.AccessibleName = null;
            resources.ApplyResources(this.dbxReq_doctor_name, "dbxReq_doctor_name");
            this.dbxReq_doctor_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxReq_doctor_name.EdgeRounding = false;
            this.dbxReq_doctor_name.Image = null;
            this.dbxReq_doctor_name.Name = "dbxReq_doctor_name";
            this.toolTip1.SetToolTip(this.dbxReq_doctor_name, resources.GetString("dbxReq_doctor_name.ToolTip"));
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            this.toolTip1.SetToolTip(this.xLabel9, resources.GetString("xLabel9.ToolTip"));
            // 
            // dbxReq_gwa_name
            // 
            this.dbxReq_gwa_name.AccessibleDescription = null;
            this.dbxReq_gwa_name.AccessibleName = null;
            resources.ApplyResources(this.dbxReq_gwa_name, "dbxReq_gwa_name");
            this.dbxReq_gwa_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxReq_gwa_name.EdgeRounding = false;
            this.dbxReq_gwa_name.Image = null;
            this.dbxReq_gwa_name.Name = "dbxReq_gwa_name";
            this.toolTip1.SetToolTip(this.dbxReq_gwa_name, resources.GetString("dbxReq_gwa_name.ToolTip"));
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            this.toolTip1.SetToolTip(this.xLabel7, resources.GetString("xLabel7.ToolTip"));
            // 
            // dbxApp_date
            // 
            this.dbxApp_date.AccessibleDescription = null;
            this.dbxApp_date.AccessibleName = null;
            resources.ApplyResources(this.dbxApp_date, "dbxApp_date");
            this.dbxApp_date.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxApp_date.EdgeRounding = false;
            this.dbxApp_date.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dbxApp_date.Image = null;
            this.dbxApp_date.Name = "dbxApp_date";
            this.toolTip1.SetToolTip(this.dbxApp_date, resources.GetString("dbxApp_date.ToolTip"));
            // 
            // txtAnswer
            // 
            this.txtAnswer.AccessibleDescription = null;
            this.txtAnswer.AccessibleName = null;
            resources.ApplyResources(this.txtAnswer, "txtAnswer");
            this.txtAnswer.ApplyByteLimit = true;
            this.txtAnswer.BackgroundImage = null;
            this.txtAnswer.Name = "txtAnswer";
            this.toolTip1.SetToolTip(this.txtAnswer, resources.GetString("txtAnswer.ToolTip"));
            // 
            // chkWangjin_yn
            // 
            this.chkWangjin_yn.AccessibleDescription = null;
            this.chkWangjin_yn.AccessibleName = null;
            resources.ApplyResources(this.chkWangjin_yn, "chkWangjin_yn");
            this.chkWangjin_yn.BackgroundImage = null;
            this.chkWangjin_yn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkWangjin_yn.Name = "chkWangjin_yn";
            this.toolTip1.SetToolTip(this.chkWangjin_yn, resources.GetString("chkWangjin_yn.ToolTip"));
            this.chkWangjin_yn.UseVisualStyleBackColor = false;
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            this.toolTip1.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            this.toolTip1.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // dbxConsult_doctor_name
            // 
            this.dbxConsult_doctor_name.AccessibleDescription = null;
            this.dbxConsult_doctor_name.AccessibleName = null;
            resources.ApplyResources(this.dbxConsult_doctor_name, "dbxConsult_doctor_name");
            this.dbxConsult_doctor_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxConsult_doctor_name.EdgeRounding = false;
            this.dbxConsult_doctor_name.Image = null;
            this.dbxConsult_doctor_name.Name = "dbxConsult_doctor_name";
            this.toolTip1.SetToolTip(this.dbxConsult_doctor_name, resources.GetString("dbxConsult_doctor_name.ToolTip"));
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // dbxConsult_gwa_name
            // 
            this.dbxConsult_gwa_name.AccessibleDescription = null;
            this.dbxConsult_gwa_name.AccessibleName = null;
            resources.ApplyResources(this.dbxConsult_gwa_name, "dbxConsult_gwa_name");
            this.dbxConsult_gwa_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxConsult_gwa_name.EdgeRounding = false;
            this.dbxConsult_gwa_name.Image = null;
            this.dbxConsult_gwa_name.Name = "dbxConsult_gwa_name";
            this.toolTip1.SetToolTip(this.dbxConsult_gwa_name, resources.GetString("dbxConsult_gwa_name.ToolTip"));
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            this.toolTip1.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // dloPrintInfo
            // 
            this.dloPrintInfo.ExecuteQuery = null;
            this.dloPrintInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            this.dloPrintInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloPrintInfo.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "suname";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "sex_age";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "req_date";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "req_doctor_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "app_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "consult_doctor_name";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "req_remark";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "answer";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "jinryo_pre_date";
            // 
            // OCS0503U01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlOCS0503);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdOCS0503);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0503U01";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS0503U01_Closing);
            this.Load += new System.EventHandler(this.OCS0503U01_Load);
            this.UserChanged += new System.EventHandler(this.OCS0503U01_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0503U01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRequest_bunho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0503)).EndInit();
            this.pnlOCS0503.ResumeLayout(false);
            this.pnlOCS0503.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloPrintInfo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "CHT0110M": // 상병조회

                    if (commandParam.Contains("CHT0110M") && (MultiLayout)commandParam["CHT0110M"] != null &&
                        ((MultiLayout)commandParam["CHT0110M"]).RowCount > 0)
                    {
                        switch (GetColumnName(ActiveFincBox))
                        {
                            case "sang_code1":
                                ActiveFincBox.SetEditValue(((MultiLayout)commandParam["CHT0110M"]).GetItemString(0, "sang_code"));
                                break;
                            case "sang_code2":
                                ActiveFincBox.SetEditValue(((MultiLayout)commandParam["CHT0110M"]).GetItemString(0, "sang_code"));
                                break;
                            case "sang_code3":
                                ActiveFincBox.SetEditValue(((MultiLayout)commandParam["CHT0110M"]).GetItemString(0, "sang_code"));
                                break;
                        }

                        ActiveFincBox.AcceptData();
                        ActiveFincBox.Focus();
                        ActiveFincBox.SelectAll();
                        //ActiveFincBox.SelectNextControl(ActiveFincBox, true, true, false, false);

                    }

                    break;

                case "BAS0270": // 의사조회

                    if (commandParam.Contains("BAS0270") && (MultiLayout)commandParam["BAS0270"] != null &&
                        ((MultiLayout)commandParam["BAS0270"]).RowCount > 0)
                        ActiveFincBox.SetEditValue(((MultiLayout)commandParam["BAS0270"]).GetItemString(0, "doctor"));

                    ActiveFincBox.AcceptData();
                    ActiveFincBox.Focus();
                    ActiveFincBox.SelectAll();

                    break;

                case "OCS0221Q01": // 상용어

                    #region

                    if (commandParam.Contains("COMMENT"))
                    {
                        if (grdOCS0503.CurrentRowNumber < 0) break;

                        int startIndex = 0;
                        string reservedRemark = "";

                        startIndex = txtAnswer.SelectionStart;
                        reservedRemark = txtAnswer.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
                                       + txtAnswer.Text.Substring(startIndex);

                        txtAnswer.SetEditValue(reservedRemark);
                        grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "answer", reservedRemark);

                    }
                    break;

                    #endregion

            }
            return base.Command(command, commandParam);
        }

        private void OCS0503U01_Load(object sender, System.EventArgs e)
        {
            SetControl(ref htOCS0503, pnlOCS0503, ref grdOCS0503);

            pnlOCS0503.Enabled = false;

            PostCallHelper.PostCall(new PostMethod(PostLoad));
            if (!NetInfo.Language.Equals(LangMode.Jr))
            {                
                this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            }
        }

        private void PostLoad()
        {
            //Current LayOut 설정
            CurrMSLayout = grdOCS0503;
            CurrMQLayout = grdOCS0503;

        }

        private void OCS0503U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                    {
                        mBunho = OpenParam["bunho"].ToString().Trim();
                    }

                    if (OpenParam.Contains("consult_gwa"))
                    {
                        mConsult_gwa = OpenParam["consult_gwa"].ToString().Trim();
                    }

                    if (OpenParam.Contains("consult_doctor"))
                    {
                        mConsult_doctor = OpenParam["consult_doctor"].ToString().Trim();
                    }

                    mRequest_date = DateTime.Now.ToString("yyyy/MM/dd");
                    if (OpenParam.Contains("req_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["req_date"].ToString()))
                            mRequest_date = OpenParam["req_date"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }
            else
            {
                mBunho = "";

                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    mBunho = patientInfo.BunHo;
                }

                mConsult_gwa = UserInfo.Gwa;
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    mConsult_doctor = UserInfo.DoctorID;
                }
                else
                {
                    mConsult_doctor = UserInfo.UserID;
                }
                mRequest_date = DateTime.Now.ToString("yyyy/MM/dd");
            }

            dpkReq_date.SetDataValue(mRequest_date);
            pbxRequest_bunho.SetPatientID(mBunho);

        }

        private void OCS0503U01_UserChanged(object sender, System.EventArgs e)
        {
            mConsult_gwa = UserInfo.Gwa;
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                mConsult_doctor = UserInfo.DoctorID;
            }
            else
            {
                mConsult_doctor = UserInfo.UserID;
            }
            LoadOCS0503();
        }

        private void OCS0503U01_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //확인여부를 check한다.
            if (grdOCS0503.CurrentRowNumber >= 0)
            {
                if (UserInfo.UserGubun == UserType.Doctor && grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "confirm_yn") != "Y")
                {
                    DialogResult result= DialogResult.No;
                    if (grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "consult_doctor") == UserInfo.DoctorID)
                    {
                        result = XMessageBox.Show(Resource.OCS0503U01_xnyckc, Resource.OCS0503U01_xn, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Question);
                    }
                    if (result == DialogResult.Yes)
                    {
                        grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "confirm_yn", "Y");
                        chkConfirm_yn.Checked = true;

                        if (!grdOCS0503.SaveLayout())
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "保存ﾆ失敗しました。" : Resource.OCS0503U01_ltb;
                            mbxMsg = mbxMsg + Service.ErrMsg;
                            mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        #endregion

        #region [Control]

        /// <summary>
        /// Control Binding, Set Hashtable
        /// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
        /// 2.해당Control Event Binding
        /// </summary>
        private void SetControl(ref Hashtable htControl, XPanel pnlControl, ref XEditGrid grdControl)
        {
            htControl = new Hashtable();
            string colName = "";

            foreach (object obj in pnlControl.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        if (grdControl.CellInfos.Contains(colName)) grdControl.SetBindControl(colName, ((IDataControl)obj));
                        ((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        if (grdControl.CellInfos.Contains(colName)) grdControl.SetBindControl(colName, ((IDataControl)obj));
                        ((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);

                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        if (grdControl.CellInfos.Contains(colName)) grdControl.SetBindControl(colName, ((IDataControl)obj));
                        ((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        if (grdControl.CellInfos.Contains(colName)) grdControl.SetBindControl(colName, ((IDataControl)obj));
                        ((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        if (grdControl.CellInfos.Contains(colName)) grdControl.SetBindControl(colName, ((IDataControl)obj));
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        if (grdControl.CellInfos.Contains(colName)) grdControl.SetBindControl(colName, ((IDataControl)obj));
                        ((XFindBox)obj).FindClick += new System.ComponentModel.CancelEventHandler(Control_FindClick);
                        ((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }

            grdControl.InitializeColumns();
        }

        /// <summary>
        /// Control 값들을 Clear한다.
        /// </summary>
        private void ClearControlData(Hashtable htControl)
        {
            foreach (object key in htControl.Keys)
            {
                ((IDataControl)htControl[key]).DataValue = "";
            }
        }

        /// <summary>
        /// 해당 항목 Control의 컬럼명을 가져온다.
        /// </summary>
        /// <param name="obj"> 항목 Control</param>
        /// <returns></returns>
        private string GetColumnName(object obj)
        {
            string colName = "";

            if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
            {
                colName = ((XComboBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
            {
                colName = ((XTextBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
            {
                colName = ((XEditMask)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
            {
                colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
            {
                colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
            {
                colName = ((XFindBox)obj).Name.Substring(3).ToLower();
            }

            return colName;
        }

        /// <summary>
        /// Control의 protect를 설정한다.
        /// </summary>
        private void SetControlProtect(ref XEditGrid grdControl, ref Hashtable htControl)
        {
            string consult_doctor = "";
            int rowIndex = grdControl.CurrentRowNumber;
            consult_doctor = grdControl.GetItemString(rowIndex, "consult_doctor");
            

            if (rowIndex < 0) return;
            
            // MinhLS: this below code only valid if Doctor ID is 5 chars => change to remove 2 first chars (department code)
            /*if (consult_doctor != "" && consult_doctor.Substring(consult_doctor.Length-5) != UserInfo.UserID)*/
            if (consult_doctor != "" && consult_doctor.Substring(2) != UserInfo.UserID)
            {
                foreach (string key in htControl.Keys)
                {
                    ((IDataControl)htControl[key]).Protect = true;
                }
                txtAnswer.Protect = true;
                btnReq_remark.Enabled = false;
            }
            else
            {
                foreach (string key in htControl.Keys)
                {
                    // Not Updatable 컬럼 protect설정
                    if (grdControl.GetRowState(rowIndex) != DataRowState.Added)
                    {
                        if (!((XEditGridCell)grdControl.CellInfos[key]).IsUpdatable)
                        {
                            ((IDataControl)htControl[key]).Protect = true;
                        }
                        else
                        {
                            ((IDataControl)htControl[key]).Protect = false;
                        }
                    }
                    else
                    {
                        ((IDataControl)htControl[key]).Protect = false;
                    }
                }
                txtAnswer.Protect = false;
                btnReq_remark.Enabled = true;
            }

            if (grdControl.GetItemString(rowIndex, "req_end_yn") == "Y")
            {
                this.chkConfirm_yn.Enabled = false;
                this.chkAnswer_end_yn.Enabled = false;
                this.txtAnswer.Enabled = false;
            }

            /*
            foreach (string key in htControl.Keys)
            {
                // Not Updatable 컬럼 protect설정
                if (grdControl.GetRowState(rowIndex) != DataRowState.Added)
                {
                    if (!((XEditGridCell)grdControl.CellInfos[key]).IsUpdatable)
                    {
                        ((IDataControl)htControl[key]).Protect = true;
                        continue;
                    }
                    else
                        ((IDataControl)htControl[key]).Protect = false;
                }
                else
                    ((IDataControl)htControl[key]).Protect = false;
            }
             * */
        }

        /// <summary>
        /// FindClick Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XFindBox fbxControl = sender as XFindBox;

            string colName = GetColumnName(sender);
            CommonItemCollection openParams;

            ActiveFincBox = fbxControl;

            switch (colName)
            {
                case "sang_code1":

                    openParams = new CommonItemCollection();
                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q00", ScreenOpenStyle.ResponseFixed, openParams);
                    fbxControl.SelectNextControl(fbxControl, true, true, false, false);

                    break;

                case "sang_code2":

                    openParams = new CommonItemCollection();
                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q00", ScreenOpenStyle.ResponseFixed, openParams);
                    fbxControl.SelectNextControl(fbxControl, true, true, false, false);

                    break;

                case "sang_code3":

                    openParams = new CommonItemCollection();
                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q00", ScreenOpenStyle.ResponseFixed, openParams);
                    fbxControl.SelectNextControl(fbxControl, true, true, false, false);

                    break;

                case "consult_doctor":

                    openParams = new CommonItemCollection();
                    XScreen.OpenScreenWithParam(this, "BASS", "BAS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
                    fbxControl.SelectNextControl(fbxControl, true, true, false, false);

                    break;

                default:
                    break;
            }
        }


        private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            e.Cancel = false;

            string codeName = "";
            string colName = GetColumnName(sender);

            switch (colName)
            {
                //				case "sang_code1":
                //
                //					if(e.DataValue.ToString().Trim() == "" ) break;
                //                    
                //					//Check Origin Data
                //					codeName = this.GetCodeName("sang_code", e.DataValue.ToString());
                //
                //					if(codeName == "")
                //					{
                //						mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病コードが正確でがはないです. 確認してください." : "상병코드가 정확하지않습니다. 확인바랍니다.";
                //						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                //						XMessageBox.Show(mbxMsg, mbxCap);
                //						e.Cancel= true;								
                //					}
                //					else
                //					{
                //						txtSang_name1.SetEditValue(codeName);
                //						txtSang_name1.AcceptData();
                //					}
                //
                //					
                //					break;	
                //
                //				case "sang_code2":
                //
                //					if(e.DataValue.ToString().Trim() == "" ) break;
                //                    
                //					//Check Origin Data
                //					codeName = this.GetCodeName("sang_code", e.DataValue.ToString());
                //
                //					if(codeName == "")
                //					{
                //						mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病コードが正確でがはないです. 確認してください." : "상병코드가 정확하지않습니다. 확인바랍니다.";
                //						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                //						XMessageBox.Show(mbxMsg, mbxCap);
                //						e.Cancel= true;								
                //					}					
                //					else
                //					{
                //						txtSang_name2.SetEditValue(codeName);
                //						txtSang_name2.AcceptData();
                //					}
                //					
                //					break;	
                //
                //				case "sang_code3":
                //
                //					if(e.DataValue.ToString().Trim() == "" ) break;
                //                    
                //					//Check Origin Data
                //					codeName = this.GetCodeName("sang_code", e.DataValue.ToString());
                //
                //					if(codeName == "")
                //					{
                //						mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病コードが正確でがはないです. 確認してください." : "상병코드가 정확하지않습니다. 확인바랍니다.";
                //						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                //						XMessageBox.Show(mbxMsg, mbxCap);
                //						e.Cancel= true;								
                //					}	
                //					else
                //					{
                //						txtSang_name3.SetEditValue(codeName);
                //						txtSang_name3.AcceptData();
                //					}
                //					
                //					break;	

                case "consult_gwa":

                    if (e.DataValue.ToString().Trim() == "") break;

                    //Check Origin Data
                    //codeName = this.GetCodeName("gwa_name", e.DataValue.ToString());
                    codeName = this.GetCodeName2("gwa_name", e.DataValue.ToString());

                    if (codeName == "")
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "施行科入力に間違いがあります。 ご確認ください。" : Resource.OCS0503U01_ks;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    else
                    {
                        dbxConsult_gwa_name.SetEditValue(codeName);
                        grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_gwa_name", codeName);
                    }

                    break;

                case "consult_doctor":

                    if (e.DataValue.ToString().Trim() == "") break;

                    //Check Origin Data
                    //codeName = this.GetCodeName("doctor_name", e.DataValue.ToString());
                    codeName = this.GetCodeName2("doctor_name", e.DataValue.ToString());

                    if (codeName == "")
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "施行医師入力に間違いがあります。 ご確認ください。" : Resource.OCS0503U01_bss;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    else
                    {
                        dbxConsult_doctor_name.SetEditValue(codeName);
                        grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_doctor_name", codeName);
                    }

                    break;

                default:
                    break;
            }

        }


        #endregion

        #region [Load Code Name]

        /// <summary>
        /// 해당 코드에 대한 명을 가져옵니다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns></returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";
            string cmdText = "";
            object retValu = null;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_code", code);
            bindVars.Add("f_hosp_code", mHospCode);

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "sang_code":

                    cmdText = @"SELECT A.SANG_NAME
                                  FROM CHT0110 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.SANG_CODE = :f_code";

                    retValu = Service.ExecuteScalar(cmdText, bindVars);

                    if (!TypeCheck.IsNull(retValu))
                    {
                        codeName = retValu.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

                    break;

                case "gwa_name":

                    cmdText = @"SELECT FN_BAS_LOAD_GWA_NAME( :f_code, SYSDATE ) FROM SYS.DUAL";

                    retValu = Service.ExecuteScalar(cmdText, bindVars);

                    if (!TypeCheck.IsNull(retValu))
                    {
                        codeName = retValu.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

                    break;

                case "doctor_name":

                    cmdText = @"SELECT FN_BAS_LOAD_DOCTOR_NAME( :f_code, SYSDATE ) FROM SYS.DUAL";

                    retValu = Service.ExecuteScalar(cmdText, bindVars);

                    if (!TypeCheck.IsNull(retValu))
                    {
                        codeName = retValu.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

                    break;



                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [Control Event]

        /// <summary>
        /// 등록번호 변경시 해당 등록번호의 의뢰내용을 보여준다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbxRequest_bunho_PatientSelected(object sender, System.EventArgs e)
        {
            mBunho = pbxRequest_bunho.BunHo;
            LoadOCS0503();
        }

        private void dpkReq_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {

            if (!TypeCheck.IsDateTime(e.DataValue.ToString()))
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "依頼日付に間違いがあります。ご確認ください。" : Resource.OCS0503U01_nycs;
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap);
                return;

            }
            else
            {
                mRequest_date = e.DataValue.ToString();
                if (mBunho == "") return;
                LoadOCS0503();
            }
        }

        private void pbxRequest_bunho_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            mBunho = "";
            grdOCS0503.Reset();
        }

        private void grdOCS0503_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //확인여부를 check한다.
            if (e.PreviousRow >= 0)
            {
                if (UserInfo.UserGubun == UserType.Doctor && grdOCS0503.GetItemString(e.PreviousRow, "confirm_yn") != "Y")
                {
                    DialogResult result;
                    result = XMessageBox.Show(Resource.OCS0503U01_nxndyck, Resource.OCS0503U01_xn, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        grdOCS0503.SetItemValue(e.PreviousRow, "confirm_yn", "Y");

                        if (grdOCS0503.SaveLayout())
                        {
                            mbxMsg = "保存が完了しました。";
                            SetMsg(mbxMsg);
                        }
                        else
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : Resource.OCS0503U01_ltb;
                            mbxMsg = mbxMsg + Service.ErrMsg;
                            mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                            XMessageBox.Show(mbxMsg, mbxCap);
                        }
                    }
                }
            }

            if (e.CurrentRow < 0)
            {
                pnlOCS0503.Enabled = false;

                //입원만
                chkDisplay_yn.Visible = false;

                return;
            }
            else
            {
                pnlOCS0503.Enabled = true;

                if (grdOCS0503.GetItemString(e.CurrentRow, "in_out_gubun") == "I")
                    chkDisplay_yn.Visible = true;
                else
                    chkDisplay_yn.Visible = false;

            }

            SetControlProtect(ref grdOCS0503, ref this.htOCS0503);
        }

        #endregion

        #region [Function]

        private void LoadOCS0503()
        {
            grdOCS0503.SetBindVarValue("f_req_date", mRequest_date);
            grdOCS0503.SetBindVarValue("f_consult_gwa", mConsult_gwa);
            grdOCS0503.SetBindVarValue("f_consult_doctor", mConsult_doctor);
            grdOCS0503.SetBindVarValue("f_bunho", mBunho);
            grdOCS0503.SetBindVarValue("f_hosp_code", mHospCode);

            if (!grdOCS0503.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);
        }

        #endregion

        #region [DataService Event]
        /// <summary>
        /// 저장전 Validation Check
        /// </summary>
        private void grdOCS0503_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            //grdOCS0503
            for (int rowIndex = 0; rowIndex < grdOCS0503.RowCount; rowIndex++)
            {
                if (grdOCS0503.LayoutTable.Rows[rowIndex].RowState == DataRowState.Modified)
                {
                    if (grdOCS0503.GetItemString(rowIndex, "confirm_yn") == "Y")
                    {
                        if (UserInfo.UserGubun == UserType.Doctor)
                        {
                            if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_doctor")) || grdOCS0503.GetItemString(rowIndex, "consult_doctor").PadRight(5).Substring(2) == "999")
                            {
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor", UserInfo.UserID);
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor_name", UserInfo.UserName);
                            }
                        }
                    }

                    if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "app_date")) && !TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "answer")))
                    {
                        grdOCS0503.SetItemValue(rowIndex, "confirm_yn", "Y");
                        grdOCS0503.SetItemValue(rowIndex, "app_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                        if (UserInfo.UserGubun == UserType.Doctor)
                        {
                            if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_doctor")) || grdOCS0503.GetItemString(rowIndex, "consult_doctor").PadRight(5).Substring(2) == "999")
                            {
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor", UserInfo.UserID);
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor_name", UserInfo.UserName);
                            }
                        }


                        if (grdOCS0503.CurrentRowNumber == rowIndex)
                        {
                            dbxApp_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            if (UserInfo.UserID == grdOCS0503.GetItemString(rowIndex, "consult_doctor")) dbxConsult_doctor_name.SetDataValue(UserInfo.UserName);
                            chkConfirm_yn.Checked = true;
                        }
                    }
                }
            }
        }

        #endregion

        #region [Button List Event]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;
                    LoadOCS0503();
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    PrepareDataBeforeSaving();
                    OCS0503U01SaveLayoutArgs args = new OCS0503U01SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.SaveList = GetListDataForSaveLayout();
                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS0503U01SaveLayoutArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result)
                    {
                        mbxMsg = "保存が完了しました。";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "保存" : "저장";
                        //XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                        SendMessageSystem();
                        grdOCS0503.ResetUpdate();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : Resource.OCS0503U01_ltb;
                        mbxMsg = mbxMsg + Service.ErrMsg;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                        XMessageBox.Show(mbxMsg, mbxCap);
                    }

                    break;

                case FunctionType.Delete:

                    break;

                case FunctionType.Print:

                    e.IsBaseCall = false;

                    //PrintRequest();

                    break;

                case FunctionType.Close:
                    ScreenCloseProcess(e.Func);
                    break;

                default:

                    break;
            }

        }

        #endregion

        private void ScreenCloseProcess(FunctionType functype)
        {
            if (this.Opener is XScreen && this.OpenParam != null)
            {
                CommonItemCollection param = new CommonItemCollection();
                XScreen screen = (XScreen)this.Opener;
                param.Add("OCS0503U01", true);
                ((XScreen)this.Opener).Command(this.Name, param);
            }
        }

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

        #region [상용어]
        /// <summary>
        /// 응답내역 상용어 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReq_remark_Click(object sender, System.EventArgs e)
        {
            ShowReservedScreen("02");
        }

        /// <summary>
        /// 상용어 조회화면을 Open한다.
        /// </summary>
        /// <param name="aCategory"></param>
        private void ShowReservedScreen(string aCategory)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("category_gubun", aCategory);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0221Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }
        #endregion

        //#region [의뢰지시서출력]

        //private void PrintRequest()
        //{

        //    if (grdOCS0503.CurrentRowNumber < 0) return;

        //    try
        //    {
        //        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계

        //        dloPrintInfo.Reset();
        //        int insertRow = dloPrintInfo.InsertRow(-1);
        //        dloPrintInfo.SetItemValue(insertRow, "bunho", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "bunho"));
        //        dloPrintInfo.SetItemValue(insertRow, "suname", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "suname"));

        //        string sex_age = "";
        //        if (grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "sex") == "M")
        //            sex_age = "男/" + this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "age");
        //        else
        //            sex_age = "女/" + this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "age");

        //        dloPrintInfo.SetItemValue(insertRow, "sex_age", sex_age);
        //        string temp = "";
        //        dloPrintInfo.SetItemValue(insertRow, "req_date", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_date"));
        //        dloPrintInfo.SetItemValue(insertRow, "jinryo_pre_date", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "jinryo_pre_date"));
        //        //의뢰진료과,의사
        //        temp = this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_gwa_name") + " - " + this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_doctor_name");
        //        dloPrintInfo.SetItemValue(insertRow, "req_doctor_name", temp);

        //        temp = "";

        //        dloPrintInfo.SetItemValue(insertRow, "app_date", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "app_date").Replace("-", "/"));
        //        temp = this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "consult_gwa_name") + " - " + this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "consult_doctor_name");
        //        dloPrintInfo.SetItemValue(insertRow, "consult_doctor_name", temp);

        //        temp = "";

        //        if (!TypeCheck.IsNull(this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "consult_sang_name")))
        //            temp = this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "consult_sang_name").Trim() + "\n\r\n\r" + this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_remark");
        //        else
        //            temp = this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_remark");

        //        dloPrintInfo.SetItemValue(insertRow, "req_remark", temp);
        //        dloPrintInfo.SetItemValue(insertRow, "answer", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "answer"));

        //        dwPrint.Reset();

        //        dwPrint.FillData(dloPrintInfo.LayoutTable);
        //        if (dwPrint.RowCount > 0)
        //        {
        //            dwPrint.Refresh();
        //            dwPrint.Print();
        //        }
        //    }
        //    finally
        //    {
        //        Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
        //    }
        //}

        //#endregion

        #region [Message System Send Message Process]
        /*
             *  TITLE   100BYTE
             *  MESSAGE 2000BYTE
             *  aReciverGubun     B=Beopo, G=BUSEO U=USER
             */
        private void SendMessageSystem(string aTitle, string aRow1, string aRow2, string aRow3, string aRow4, string aRow5, string aComment, string aSenderID, string aReciverGubun, string aReciverID, string aBuseoName)
        {
            string MsgSysMSG = "";
            string MsgPatientInfo = "";

            if (!TypeCheck.IsNull(aRow1)) MsgPatientInfo += aRow1 + "\r\n";
            if (!TypeCheck.IsNull(aRow2)) MsgPatientInfo += aRow2 + "\r\n";
            if (!TypeCheck.IsNull(aRow3)) MsgPatientInfo += aRow3 + "\r\n";
            if (!TypeCheck.IsNull(aRow4)) MsgPatientInfo += aRow4 + "\r\n";
            if (!TypeCheck.IsNull(aRow5)) MsgPatientInfo += aRow5 + "\r\n";

            MsgSysMSG += "===========================\r\n";

            if (!TypeCheck.IsNull(aComment)) MsgSysMSG += aComment + "\r\n";

            if (aSenderID != "" && aComment != "")
            {
                //if (XMessageBox.Show(MsgSysMSG + "===========================\r\n上記のように更新がありました。\r\n\r\n「" + aBuseoName + "」にお知らせメッセージを送信しますか？"
                //                    , aTitle
                //                    , MessageBoxButtons.YesNo
                //                    , MessageBoxDefaultButton.Button1
                //                    , MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                UdpHelper.SendMsgToID2(aSenderID, aReciverGubun, aReciverID, aTitle, MsgPatientInfo + MsgSysMSG);
                //}
            }

        }
        #endregion [Message System Send Message Process]

        #region [XSavePerformer Class]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OCS0503U01 parent = null;
            bool returnBool = false;

            public XSavePerformer(OCS0503U01 parent)
            {
                this.parent = parent;
            }

            /// <summary>
            /// Backup original method, remove 2 suffix to restore
            /// </summary>
            /// <param name="callerID"></param>
            /// <param name="item"></param>
            /// <returns></returns>
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                try
                {
                    Service.BeginTransaction();

                    switch (item.RowState)
                    {
                        case DataRowState.Added:
                            cmdText = @"INSERT INTO OCS0503
                                            (SYS_DATE         , SYS_ID            , BUNHO             ,
                                             REQ_DATE         , REQ_GWA           , REQ_DOCTOR        , PKOCS0503         ,
                                             CONSULT_GWA      , CONSULT_DOCTOR    , WANGJIN_YN        , SANG_CODE1        ,
                                             SANG_NAME1       , SANG_CODE2        , SANG_NAME2        , SANG_CODE3        ,
                                             SANG_NAME3       , REQ_REMARK        , APP_DATE          , ANSWER            ,
                                             IN_OUT_GUBUN     , FKINP1001         , PRINT_YN          , EMER_GUBUN        ,
                                             REAL_JINRYO_DATE , RESULT_ARRIVE_DATE, CONFIRM_YN        , ANSWER_END_YN     ,
                                             JINRYO_PRE_DATE  , AMPM_GUBUN        , REQ_END_YN        , DISPLAY_YN        ,
                                             CONSULT_SANG_NAME, HOSP_CODE   )
                                         VALUES
                                            (SYSDATE            , :f_user_id           , :f_bunho             ,
                                             :f_req_date        , :f_req_gwa           , :f_req_doctor        , OCS0503_SEQ.NEXTVAL,
                                             :f_consult_gwa     , :f_consult_doctor    , :f_wangjin_yn        , :f_sang_code1  ,
                                             :f_sang_name1      , :f_sang_code2        , :f_sang_name2        , :f_sang_code3  ,
                                             :f_sang_name3      , :f_req_remark        , :f_app_date          , :f_answer      ,
                                             :f_in_out_gubun    , :f_fkinp1001         , :f_print_yn          , :f_emer_gubun  ,
                                             :f_real_jinryo_date, :f_result_arrive_date, NVL(:f_confirm_yn, 'N'), NVL(:f_answer_end_yn, 'N'),
                                             :f_jinryo_pre_date , :f_ampm_gubun        , :f_req_end_yn        , :f_display_yn,
                                             :f_consult_sang_name, :f_hosp_code)";
                            returnBool = Service.ExecuteNonQuery(cmdText, item.BindVarList);

                            break;
                        case DataRowState.Modified:
                            cmdText = @"UPDATE OCS0503
                                           SET UPD_ID             = :f_user_id           ,
                                               UPD_DATE           = SYSDATE              ,
                                               CONSULT_GWA        = :f_consult_gwa       ,
                                               CONSULT_DOCTOR     = :f_consult_doctor    ,
                                               WANGJIN_YN         = :f_wangjin_yn        ,
                                               SANG_CODE1         = :f_sang_code1        ,
                                               SANG_NAME1         = :f_sang_name1        ,
                                               SANG_CODE2         = :f_sang_code2        ,
                                               SANG_NAME2         = :f_sang_name2        ,
                                               SANG_CODE3         = :f_sang_code3        ,
                                               SANG_NAME3         = :f_sang_name3        ,
                                               REQ_REMARK         = :f_req_remark        ,
                                               APP_DATE           = :f_app_date          ,
                                               ANSWER             = :f_answer            ,
                                               IN_OUT_GUBUN       = :f_in_out_gubun      ,
                                               FKINP1001          = :f_fkinp1001         ,
                                               PRINT_YN           = :f_print_yn          ,
                                               EMER_GUBUN         = :f_emer_gubun        ,
                                               REAL_JINRYO_DATE   = :f_real_jinryo_date  ,
                                               RESULT_ARRIVE_DATE = :f_result_arrive_date,
                                               CONFIRM_YN         = :f_confirm_yn        ,
                                               ANSWER_END_YN      = :f_answer_end_yn     ,
                                               JINRYO_PRE_DATE    = :f_jinryo_pre_date   ,
                                               AMPM_GUBUN         = :f_ampm_gubun        ,
                                               REQ_END_YN         = :f_req_end_yn        ,
                                               DISPLAY_YN         = :f_display_yn        ,
                                               CONSULT_SANG_NAME  = :f_consult_sang_name
                                         WHERE HOSP_CODE          = :f_hosp_code
                                           AND PKOCS0503          = :f_pkocs0503";
                            returnBool = Service.ExecuteNonQuery(cmdText, item.BindVarList);
                            break;
                        case DataRowState.Deleted:
                            cmdText = "DELETE OCS0503"
                                 + "	WHERE HOSP_CODE          = :f_hosp_code"
                                 + "      AND PKOCS0503          = :f_pkocs0503";
                            returnBool = Service.ExecuteNonQuery(cmdText, item.BindVarList);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Service.RollbackTransaction();
                }
                Service.CommitTransaction();

                string MsgSysMSG = "";
                string MsgTitle = "";

                if (parent.cbxMsgSysYN.Checked == true && returnBool)
                {
                    if (item.BindVarList["f_answer_end_yn"].VarValue == "Y")
                    {
                        MsgSysMSG += "返信医 : " + UserInfo.UserName + "\r\n";
                        MsgTitle += "[診療依頼返信]";
                        if (MsgSysMSG != "")
                        {
                            // B=Beopo, G=BUSEO U=USER
                            parent.SendMessageSystem(MsgTitle + "診療依頼に返信が登録されました。"
                                                 , "依頼元 : " + parent.grdOCS0503.GetItemString(parent.grdOCS0503.CurrentRowNumber, "req_doctor_name")
                                                 , "依頼先 : " + UserInfo.UserName
                                                 , "患者名 : " + parent.pbxRequest_bunho.SuName
                                                 , ""
                                                 , ""
                                                 , MsgSysMSG
                                                 , UserInfo.UserID
                                                 , "U"
                                                 , item.BindVarList["f_req_doctor"].VarValue.Substring(2)
                                                 , ""
                                                    );
                        }
                    }                    
                }
                return returnBool;
            }
        }
        #endregion		

        #region DzungTA modify

        private void BindExecuteQueryMethod()
        {
            grdOCS0503.ExecuteQuery = QueryGrdOCS0503;
        }

        private List<object[]> QueryGrdOCS0503(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            OcsaOCS0503U01GrdOCS0503ListArgs args = new OcsaOCS0503U01GrdOCS0503ListArgs();
            args.ConsultDoctor = bc["f_consult_doctor"].VarValue;
            args.FBunho = bc["f_bunho"].VarValue;
            args.ReqDate = bc["f_req_date"].VarValue;
            //args.ConsultDoctor = "0299999";
            //args.FBunho = "666666666";
            //args.ReqDate = "2014/11/11";
            OcsaOCS0503U01GrdOCS0503ListResult result = CloudService.Instance.Submit<OcsaOCS0503U01GrdOCS0503ListResult, OcsaOCS0503U01GrdOCS0503ListArgs>(args);

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<OcsaOCS0503U01GrdOCS0503ListInfo> lst = result.GridListItem;
                if (lst != null && lst.Count > 0)
                {
                    foreach (OcsaOCS0503U01GrdOCS0503ListInfo item in result.GridListItem)
                    {
                        object[] objects =
                    {
                        item.Bunho,
                        item.ReqDate,
                        item.ReqGwa,
                        item.ReqDoctor,
                        item.Pkocs0503,
                        item.ConsultGwa,
                        item.ConsultDoctor,
                        item.WangjinYn,
                        item.SangCode1,
                        item.SangName1,
                        item.SangCode2,
                        item.SangName2,
                        item.SangCode3,
                        item.SangName3,
                        item.ConsultSangName,
                        item.ReqRemark,
                        item.AppDate,
                        item.Answer,
                        item.InOutGubun,
                        item.ConsultFkout1001,
                        item.Fkinp1001,
                        item.PrintYn,
                        item.EmerGubun,
                        item.RealJinryoDate,
                        item.ResultArriveDate,
                        item.ConfirmYn,
                        item.AnswerEndYn,
                        item.JinryoPreDate,
                        item.AmpmGubun,
                        item.ReqEndYn,
                        item.DisplayYn,
                        item.Suname,
                        item.Sex,
                        item.Age,
                        item.ConsultGwaName,
                        item.ConsultDoctorName,
                        item.ReqGwaName,
                        item.ReqDoctorName,
                        item.OldAnswerEndYn
                    };
                        res.Add(objects);
                    }
                }
                
            }

            return res;
        }

        OcsaOCS0503U01CommonDataArgs args = new OcsaOCS0503U01CommonDataArgs();

        private string GetCodeName2(string codeMode, string code)
        {
            string codeName = "";
            string cmdText = "";
            object retValu = null;
            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_code", code);
            bindVars.Add("f_hosp_code", mHospCode);

            if (code.Trim() == "") return codeName;

            if (args.FCode == null 
                || args.FCode != bindVars["f_code"].VarValue)
            {
                args.FCode = bindVars["f_code"].VarValue; 
            }

            OcsaOCS0503U01CommonDataResult result = CacheService.Instance.Get<OcsaOCS0503U01CommonDataArgs, OcsaOCS0503U01CommonDataResult>(args);
            if (result == null)
            {
                return codeName;
            }

            switch (codeMode)
            {
                case "sang_code":
                    retValu = result.SangName;
                    if (!TypeCheck.IsNull(retValu))
                    {
                        codeName = retValu.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

                    break;

                case "gwa_name":
                    retValu = result.GwaName;
                    if (!TypeCheck.IsNull(retValu))
                    {
                        codeName = retValu.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

                    break;

                case "doctor_name":
                    retValu = result.DoctorName;
                    if (!TypeCheck.IsNull(retValu))
                    {
                        codeName = retValu.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }

                    break;



                default:
                    break;
            }

            return codeName;
        }

        private void PrepareDataBeforeSaving()
        {
            for (int rowIndex = 0; rowIndex < grdOCS0503.RowCount; rowIndex++)
            {
                if (grdOCS0503.LayoutTable.Rows[rowIndex].RowState == DataRowState.Modified)
                {
                    if (grdOCS0503.GetItemString(rowIndex, "confirm_yn") == "Y")
                    {
                        if (UserInfo.UserGubun == UserType.Doctor)
                        {
                            if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_doctor")) || grdOCS0503.GetItemString(rowIndex, "consult_doctor").PadRight(5).Substring(2) == "999")
                            {
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor", UserInfo.UserID);
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor_name", UserInfo.UserName);
                            }
                        }
                    }

                    if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "app_date")) && !TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "answer")))
                    {
                        grdOCS0503.SetItemValue(rowIndex, "confirm_yn", "Y");
                        grdOCS0503.SetItemValue(rowIndex, "app_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                        if (UserInfo.UserGubun == UserType.Doctor)
                        {
                            if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_doctor")) || grdOCS0503.GetItemString(rowIndex, "consult_doctor").PadRight(5).Substring(2) == "999")
                            {
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor", UserInfo.UserID);
                                grdOCS0503.SetItemValue(rowIndex, "consult_doctor_name", UserInfo.UserName);
                            }
                        }


                        if (grdOCS0503.CurrentRowNumber == rowIndex)
                        {
                            dbxApp_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            if (UserInfo.UserID == grdOCS0503.GetItemString(rowIndex, "consult_doctor")) dbxConsult_doctor_name.SetDataValue(UserInfo.UserName);
                            chkConfirm_yn.Checked = true;
                        }
                    }
                }
            }
        }

        private List<OcsaOCS0503U01GrdOCS0503ListInfo> GetListDataForSaveLayout()
        {
            List<OcsaOCS0503U01GrdOCS0503ListInfo> lstResult = new List<OcsaOCS0503U01GrdOCS0503ListInfo>();

            for (int i = 0; i < grdOCS0503.RowCount; i++)
            {
                OcsaOCS0503U01GrdOCS0503ListInfo item = new OcsaOCS0503U01GrdOCS0503ListInfo();

                item.Bunho = grdOCS0503.GetItemString(i, "bunho");
                item.ReqDate = grdOCS0503.GetItemString(i, "req_date");
                item.ReqGwa = grdOCS0503.GetItemString(i, "req_gwa");
                item.ReqDoctor = grdOCS0503.GetItemString(i, "req_doctor");
                item.ConsultGwa = grdOCS0503.GetItemString(i, "consult_gwa");
                item.ConsultDoctor = grdOCS0503.GetItemString(i, "consult_doctor");
                item.WangjinYn = grdOCS0503.GetItemString(i, "wangjin_yn");
                item.SangCode1 = grdOCS0503.GetItemString(i, "sang_code1");
                item.SangName1 = grdOCS0503.GetItemString(i, "sang_name1");
                item.SangCode2 = grdOCS0503.GetItemString(i, "sang_code2");
                item.SangName2 = grdOCS0503.GetItemString(i, "sang_name2");
                item.SangCode3 = grdOCS0503.GetItemString(i, "sang_code3");
                item.SangName3 = grdOCS0503.GetItemString(i, "sang_name3");
                item.ReqRemark = grdOCS0503.GetItemString(i, "req_remark");
                item.AppDate = grdOCS0503.GetItemString(i, "app_date");
                item.Answer = grdOCS0503.GetItemString(i, "answer");
                item.InOutGubun = grdOCS0503.GetItemString(i, "in_out_gubun");
                item.Fkinp1001 = grdOCS0503.GetItemString(i, "fkinp1001");
                item.PrintYn = grdOCS0503.GetItemString(i, "print_yn");
                item.EmerGubun = grdOCS0503.GetItemString(i, "emer_gubun");
                item.RealJinryoDate = grdOCS0503.GetItemString(i, "real_jinryo_date");
                item.AmpmGubun = grdOCS0503.GetItemString(i, "ampm_gubun");
                item.ReqEndYn = grdOCS0503.GetItemString(i, "req_end_yn");
                item.DisplayYn = grdOCS0503.GetItemString(i, "display_yn");
                item.ConsultSangName = grdOCS0503.GetItemString(i, "consult_sang_name");
                item.JinryoPreDate = grdOCS0503.GetItemString(i, "jinryo_pre_date");
                item.AnswerEndYn = grdOCS0503.GetItemString(i, "answer_end_yn");
                item.ConfirmYn = grdOCS0503.GetItemString(i, "confirm_yn");
                item.ResultArriveDate = grdOCS0503.GetItemString(i, "result_arrive_date");
                item.Pkocs0503 = grdOCS0503.GetItemString(i, "pkocs0503");

                item.DataRowState = grdOCS0503.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdOCS0503.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0503.DeletedRowTable.Rows)
                {
                    OcsaOCS0503U01GrdOCS0503ListInfo item = new OcsaOCS0503U01GrdOCS0503ListInfo();
                    item.Pkocs0503 = Convert.ToString(dr["pkocs0503"]);
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private void SendMessageSystem()
        {
            if (this.cbxMsgSysYN.Checked)
            {
                string MsgSysMSG = "";
                string MsgTitle = "";
                for (int i = 0; i < grdOCS0503.RowCount; i++)
                {
                    if (grdOCS0503.GetItemString(i, "answer_end_yn") == "Y")
                    {
                        MsgSysMSG += "返信医 : " + UserInfo.UserName + "\r\n";
                        MsgTitle += "[診療依頼返信]";
                        if (MsgSysMSG != "")
                        {
                            // B=Beopo, G=BUSEO U=USER
                            this.SendMessageSystem(MsgTitle + "診療依頼に返信が登録されました。"
                                ,
                                "依頼元 : " +
                                this.grdOCS0503.GetItemString(this.grdOCS0503.CurrentRowNumber, "req_doctor_name")
                                , "依頼先 : " + UserInfo.UserName
                                , "患者名 : " + this.pbxRequest_bunho.SuName
                                , ""
                                , ""
                                , MsgSysMSG
                                , UserInfo.UserID
                                , "U"
                                , grdOCS0503.GetItemString(i, "req_doctor").Substring(2)
                                , ""
                                );
                        }
                    }
                }
            }
        }

        #endregion
    }
}

