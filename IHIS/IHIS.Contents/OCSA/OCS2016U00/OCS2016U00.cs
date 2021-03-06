#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Web.Caching;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;
using System.Web;
using System.Threading;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0503U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS2016U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Control HashTable
        Hashtable htOCS0503;
        //Message처리
        string mbxMsg = "", mbxCap = "";

        //환자등록번호
        string mBunho = "";
        //의뢰과
        string mRequest_gwa = "";
        string mRequest_gwa_name = "";
        //의뢰의사
        string mRequest_doctor = "";
        string mRequest_doctor_name = "";
        //pk_key
        string mNaewon_key = "";
        //의뢰일자
        string mRequest_date = "";
        //입원/외래구분
        string mIn_out_gubun = "O";

        //입원Key
        int mFkinp1001 = 0;


        //Find관련
        XFindBox ActiveFincBox;

        //hospital code
        string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region [SaveEnd]
        ////bool isgrdOCS0503Save = false;
        ////bool isSavedOCS0503 = false;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPictureBox xPictureBox1;
        private IHIS.Framework.XEditGrid grdOCS0503;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XPanel pnlOCS2016U00;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XFindBox fbxConsult_gwa;
        private IHIS.Framework.XDisplayBox dbxConsult_gwa_name;
        private IHIS.Framework.XDisplayBox dbxConsult_doctor_name;
        private IHIS.Framework.XFindBox fbxConsult_doctor;
        private IHIS.Framework.XTextBox txtReq_remark;
        private IHIS.Framework.XDisplayBox dbxApp_date;
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
        private IHIS.Framework.XCheckBox chkConfirm_yn;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XCheckBox chkAnswer_end_yn;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XLabel lblAmPm_gubun;
        private IHIS.Framework.XTextBox txtAnswer;
        private IHIS.Framework.XDatePicker dpkJinryo_pre_date;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private MultiLayout dloPrintInfo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private XTextBox txtSang_name1;
        private XTextBox txtSang_name3;
        private XTextBox txtSang_name2;
        private XFindBox fbxSang_code1;
        private XFindBox fbxSang_code3;
        private XFindBox fbxSang_code2;
        private XEditGridCell xEditGridCell39;
        private SingleLayout layNaewonChk;
        private SingleLayoutItem singleLayoutItem1;
        private MultiLayout layTerm;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private SingleLayout layReserCanYN;
        private SingleLayoutItem singleLayoutItem2;
        private XEditMask enkReser_time;
        private MultiLayout layOrderInfo;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private XCheckBox cbxMsgSysYN;
        private XDisplayBox xDisplayBox1;
        private XFindBox xFindBox1;
        private XPanel pnlTab1Info;
        private XPanel pnlTab2Info;
        private XLabel lblDoctorReq;
        private XLabel lblDepartmentExecute;
        private XDisplayBox dplDepartmentBexecute;
        private XLabel lblDepartmentReq;
        private XDisplayBox dplBxDoctorExecute;
        private XLabel lblHosptalCode;
        private XDisplayBox dplBxDoctorReq;
        private Label label2;
        private XDisplayBox dplBDepartmentReq;
        private XDisplayBox dplBHosptalCode;
        private XLabel lblDoctorExecute;
        private XPanel pnlGrdContainner;
        private XPanel xPnlSelectTab;
        private XRadioButton rbnTab2;
        private XRadioButton rbnTab1;
        private System.ComponentModel.IContainer components;

        public OCS2016U00()
        {
            InitializeComponent();
            BindExecuteQueryMethod();
        }
        //val
        private string mCallerScreenID = "";
        //Lib
        //private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2016U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxMsgSysYN = new IHIS.Framework.XCheckBox();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dpkReq_date = new IHIS.Framework.XDatePicker();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.pbxRequest_bunho = new IHIS.Framework.XPatientBox();
            this.grdOCS0503 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
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
            this.pnlOCS2016U00 = new IHIS.Framework.XPanel();
            this.pnlTab2Info = new IHIS.Framework.XPanel();
            this.dplBHosptalCode = new IHIS.Framework.XDisplayBox();
            this.lblDoctorExecute = new IHIS.Framework.XLabel();
            this.dplBDepartmentReq = new IHIS.Framework.XDisplayBox();
            this.lblDoctorReq = new IHIS.Framework.XLabel();
            this.lblDepartmentExecute = new IHIS.Framework.XLabel();
            this.dplDepartmentBexecute = new IHIS.Framework.XDisplayBox();
            this.lblDepartmentReq = new IHIS.Framework.XLabel();
            this.dplBxDoctorExecute = new IHIS.Framework.XDisplayBox();
            this.lblHosptalCode = new IHIS.Framework.XLabel();
            this.dplBxDoctorReq = new IHIS.Framework.XDisplayBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTab1Info = new IHIS.Framework.XPanel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xDisplayBox1 = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xFindBox1 = new IHIS.Framework.XFindBox();
            this.fbxConsult_gwa = new IHIS.Framework.XFindBox();
            this.dbxConsult_gwa_name = new IHIS.Framework.XDisplayBox();
            this.enkReser_time = new IHIS.Framework.XEditMask();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.fbxConsult_doctor = new IHIS.Framework.XFindBox();
            this.dbxConsult_doctor_name = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dbxReq_gwa_name = new IHIS.Framework.XDisplayBox();
            this.dbxReq_doctor_name = new IHIS.Framework.XDisplayBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAmPm_gubun = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dpkJinryo_pre_date = new IHIS.Framework.XDatePicker();
            this.txtReq_remark = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.fbxSang_code3 = new IHIS.Framework.XFindBox();
            this.fbxSang_code2 = new IHIS.Framework.XFindBox();
            this.fbxSang_code1 = new IHIS.Framework.XFindBox();
            this.txtSang_name3 = new IHIS.Framework.XTextBox();
            this.txtSang_name2 = new IHIS.Framework.XTextBox();
            this.txtSang_name1 = new IHIS.Framework.XTextBox();
            this.txtAnswer = new IHIS.Framework.XTextBox();
            this.chkAnswer_end_yn = new IHIS.Framework.XCheckBox();
            this.chkConfirm_yn = new IHIS.Framework.XCheckBox();
            this.btnReq_remark = new IHIS.Framework.XButton();
            this.dbxApp_date = new IHIS.Framework.XDisplayBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
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
            this.layNaewonChk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layTerm = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.layReserCanYN = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layOrderInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.pnlGrdContainner = new IHIS.Framework.XPanel();
            this.xPnlSelectTab = new IHIS.Framework.XPanel();
            this.rbnTab2 = new IHIS.Framework.XRadioButton();
            this.rbnTab1 = new IHIS.Framework.XRadioButton();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRequest_bunho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0503)).BeginInit();
            this.pnlOCS2016U00.SuspendLayout();
            this.pnlTab2Info.SuspendLayout();
            this.pnlTab1Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloPrintInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderInfo)).BeginInit();
            this.pnlGrdContainner.SuspendLayout();
            this.xPnlSelectTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "타과의뢰.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.cbxMsgSysYN);
            this.xPanel1.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // cbxMsgSysYN
            // 
            resources.ApplyResources(this.cbxMsgSysYN, "cbxMsgSysYN");
            this.cbxMsgSysYN.Checked = true;
            this.cbxMsgSysYN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxMsgSysYN.Name = "cbxMsgSysYN";
            this.toolTip1.SetToolTip(this.cbxMsgSysYN, resources.GetString("cbxMsgSysYN.ToolTip"));
            this.cbxMsgSysYN.UseVisualStyleBackColor = false;
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Controls.Add(this.xPictureBox1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.dpkReq_date);
            this.xPanel3.Controls.Add(this.xLabel8);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // dpkReq_date
            // 
            resources.ApplyResources(this.dpkReq_date, "dpkReq_date");
            this.dpkReq_date.Name = "dpkReq_date";
            this.dpkReq_date.Protect = true;
            this.dpkReq_date.ReadOnly = true;
            this.dpkReq_date.TabStop = false;
            this.dpkReq_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkReq_date_DataValidating);
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            resources.ApplyResources(this.xPictureBox1, "xPictureBox1");
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.TabStop = false;
            // 
            // pbxRequest_bunho
            // 
            resources.ApplyResources(this.pbxRequest_bunho, "pbxRequest_bunho");
            this.pbxRequest_bunho.Name = "pbxRequest_bunho";
            this.pbxRequest_bunho.PatientSelectionFailed += new System.EventHandler(this.pbxRequest_bunho_PatientSelectionFailed);
            this.pbxRequest_bunho.PatientSelected += new System.EventHandler(this.pbxRequest_bunho_PatientSelected);
            // 
            // grdOCS0503
            // 
            resources.ApplyResources(this.grdOCS0503, "grdOCS0503");
            this.grdOCS0503.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
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
            this.xEditGridCell35,
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
            this.grdOCS0503.ColPerLine = 5;
            this.grdOCS0503.Cols = 5;
            this.grdOCS0503.ControlBinding = true;
            this.grdOCS0503.ExecuteQuery = null;
            this.grdOCS0503.FixedRows = 1;
            this.grdOCS0503.HeaderHeights.Add(19);
            this.grdOCS0503.Name = "grdOCS0503";
            this.grdOCS0503.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0503.ParamList")));
            this.grdOCS0503.QuerySQL = resources.GetString("grdOCS0503.QuerySQL");
            this.grdOCS0503.ReadOnly = true;
            this.grdOCS0503.Rows = 2;
            this.grdOCS0503.ToolTipActive = true;
            this.grdOCS0503.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0503_QueryEnd);
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
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "req_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SuppressRepeating = true;
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
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
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
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "jinryo_pre_date";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell35.CellWidth = 120;
            this.xEditGridCell35.Col = 3;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsNotNull = true;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "reser_time";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell34.CellWidth = 100;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsNotNull = true;
            this.xEditGridCell34.Mask = "HH:MI";
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
            this.xEditGridCell27.CellName = "consult_gwa_name";
            this.xEditGridCell27.CellWidth = 100;
            this.xEditGridCell27.Col = 1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsNotNull = true;
            this.xEditGridCell27.IsUpdCol = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "consult_doctor_name";
            this.xEditGridCell28.CellWidth = 100;
            this.xEditGridCell28.Col = 2;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsNotNull = true;
            this.xEditGridCell28.IsUpdCol = false;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "req_gwa_name";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "req_doctor_name";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "old_answer_end_yn";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // pnlOCS2016U00
            // 
            this.pnlOCS2016U00.Controls.Add(this.pnlTab2Info);
            this.pnlOCS2016U00.Controls.Add(this.pnlTab1Info);
            this.pnlOCS2016U00.Controls.Add(this.txtReq_remark);
            this.pnlOCS2016U00.Controls.Add(this.xLabel4);
            this.pnlOCS2016U00.Controls.Add(this.fbxSang_code3);
            this.pnlOCS2016U00.Controls.Add(this.fbxSang_code2);
            this.pnlOCS2016U00.Controls.Add(this.fbxSang_code1);
            this.pnlOCS2016U00.Controls.Add(this.txtSang_name3);
            this.pnlOCS2016U00.Controls.Add(this.txtSang_name2);
            this.pnlOCS2016U00.Controls.Add(this.txtSang_name1);
            this.pnlOCS2016U00.Controls.Add(this.txtAnswer);
            this.pnlOCS2016U00.Controls.Add(this.chkAnswer_end_yn);
            this.pnlOCS2016U00.Controls.Add(this.chkConfirm_yn);
            this.pnlOCS2016U00.Controls.Add(this.btnReq_remark);
            this.pnlOCS2016U00.Controls.Add(this.dbxApp_date);
            this.pnlOCS2016U00.Controls.Add(this.xLabel5);
            resources.ApplyResources(this.pnlOCS2016U00, "pnlOCS2016U00");
            this.pnlOCS2016U00.Name = "pnlOCS2016U00";
            // 
            // pnlTab2Info
            // 
            this.pnlTab2Info.Controls.Add(this.dplBHosptalCode);
            this.pnlTab2Info.Controls.Add(this.lblDoctorExecute);
            this.pnlTab2Info.Controls.Add(this.dplBDepartmentReq);
            this.pnlTab2Info.Controls.Add(this.lblDoctorReq);
            this.pnlTab2Info.Controls.Add(this.lblDepartmentExecute);
            this.pnlTab2Info.Controls.Add(this.dplDepartmentBexecute);
            this.pnlTab2Info.Controls.Add(this.lblDepartmentReq);
            this.pnlTab2Info.Controls.Add(this.dplBxDoctorExecute);
            this.pnlTab2Info.Controls.Add(this.lblHosptalCode);
            this.pnlTab2Info.Controls.Add(this.dplBxDoctorReq);
            this.pnlTab2Info.Controls.Add(this.label2);
            resources.ApplyResources(this.pnlTab2Info, "pnlTab2Info");
            this.pnlTab2Info.Name = "pnlTab2Info";
            // 
            // dplBHosptalCode
            // 
            this.dplBHosptalCode.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dplBHosptalCode.EdgeRounding = false;
            resources.ApplyResources(this.dplBHosptalCode, "dplBHosptalCode");
            this.dplBHosptalCode.Name = "dplBHosptalCode";
            this.toolTip1.SetToolTip(this.dplBHosptalCode, resources.GetString("dplBHosptalCode.ToolTip"));
            // 
            // lblDoctorExecute
            // 
            this.lblDoctorExecute.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDoctorExecute.EdgeRounding = false;
            this.lblDoctorExecute.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblDoctorExecute, "lblDoctorExecute");
            this.lblDoctorExecute.Name = "lblDoctorExecute";
            this.toolTip1.SetToolTip(this.lblDoctorExecute, resources.GetString("lblDoctorExecute.ToolTip"));
            // 
            // dplBDepartmentReq
            // 
            this.dplBDepartmentReq.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dplBDepartmentReq.EdgeRounding = false;
            resources.ApplyResources(this.dplBDepartmentReq, "dplBDepartmentReq");
            this.dplBDepartmentReq.Name = "dplBDepartmentReq";
            this.toolTip1.SetToolTip(this.dplBDepartmentReq, resources.GetString("dplBDepartmentReq.ToolTip"));
            // 
            // lblDoctorReq
            // 
            this.lblDoctorReq.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDoctorReq.EdgeRounding = false;
            this.lblDoctorReq.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblDoctorReq, "lblDoctorReq");
            this.lblDoctorReq.Name = "lblDoctorReq";
            // 
            // lblDepartmentExecute
            // 
            this.lblDepartmentExecute.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDepartmentExecute.EdgeRounding = false;
            this.lblDepartmentExecute.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblDepartmentExecute, "lblDepartmentExecute");
            this.lblDepartmentExecute.Name = "lblDepartmentExecute";
            // 
            // dplDepartmentBexecute
            // 
            this.dplDepartmentBexecute.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dplDepartmentBexecute.EdgeRounding = false;
            resources.ApplyResources(this.dplDepartmentBexecute, "dplDepartmentBexecute");
            this.dplDepartmentBexecute.Name = "dplDepartmentBexecute";
            // 
            // lblDepartmentReq
            // 
            this.lblDepartmentReq.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblDepartmentReq.EdgeRounding = false;
            this.lblDepartmentReq.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblDepartmentReq, "lblDepartmentReq");
            this.lblDepartmentReq.Name = "lblDepartmentReq";
            this.toolTip1.SetToolTip(this.lblDepartmentReq, resources.GetString("lblDepartmentReq.ToolTip"));
            // 
            // dplBxDoctorExecute
            // 
            this.dplBxDoctorExecute.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dplBxDoctorExecute.EdgeRounding = false;
            resources.ApplyResources(this.dplBxDoctorExecute, "dplBxDoctorExecute");
            this.dplBxDoctorExecute.Name = "dplBxDoctorExecute";
            this.toolTip1.SetToolTip(this.dplBxDoctorExecute, resources.GetString("dplBxDoctorExecute.ToolTip"));
            // 
            // lblHosptalCode
            // 
            this.lblHosptalCode.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHosptalCode.EdgeRounding = false;
            this.lblHosptalCode.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblHosptalCode, "lblHosptalCode");
            this.lblHosptalCode.Name = "lblHosptalCode";
            // 
            // dplBxDoctorReq
            // 
            this.dplBxDoctorReq.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dplBxDoctorReq.EdgeRounding = false;
            resources.ApplyResources(this.dplBxDoctorReq, "dplBxDoctorReq");
            this.dplBxDoctorReq.Name = "dplBxDoctorReq";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // pnlTab1Info
            // 
            this.pnlTab1Info.Controls.Add(this.xLabel9);
            this.pnlTab1Info.Controls.Add(this.xDisplayBox1);
            this.pnlTab1Info.Controls.Add(this.pbxRequest_bunho);
            this.pnlTab1Info.Controls.Add(this.xLabel1);
            this.pnlTab1Info.Controls.Add(this.xFindBox1);
            this.pnlTab1Info.Controls.Add(this.fbxConsult_gwa);
            this.pnlTab1Info.Controls.Add(this.dbxConsult_gwa_name);
            this.pnlTab1Info.Controls.Add(this.enkReser_time);
            this.pnlTab1Info.Controls.Add(this.xLabel2);
            this.pnlTab1Info.Controls.Add(this.fbxConsult_doctor);
            this.pnlTab1Info.Controls.Add(this.dbxConsult_doctor_name);
            this.pnlTab1Info.Controls.Add(this.xLabel7);
            this.pnlTab1Info.Controls.Add(this.dbxReq_gwa_name);
            this.pnlTab1Info.Controls.Add(this.dbxReq_doctor_name);
            this.pnlTab1Info.Controls.Add(this.label1);
            this.pnlTab1Info.Controls.Add(this.lblAmPm_gubun);
            this.pnlTab1Info.Controls.Add(this.xLabel6);
            this.pnlTab1Info.Controls.Add(this.dpkJinryo_pre_date);
            resources.ApplyResources(this.pnlTab1Info, "pnlTab1Info");
            this.pnlTab1Info.Name = "pnlTab1Info";
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // xDisplayBox1
            // 
            this.xDisplayBox1.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.xDisplayBox1.EdgeRounding = false;
            resources.ApplyResources(this.xDisplayBox1, "xDisplayBox1");
            this.xDisplayBox1.Name = "xDisplayBox1";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xFindBox1
            // 
            this.xFindBox1.ApplyByteLimit = true;
            this.xFindBox1.AutoTabDataSelected = true;
            this.xFindBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.xFindBox1, "xFindBox1");
            this.xFindBox1.Name = "xFindBox1";
            // 
            // fbxConsult_gwa
            // 
            this.fbxConsult_gwa.ApplyByteLimit = true;
            this.fbxConsult_gwa.AutoTabDataSelected = true;
            this.fbxConsult_gwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.fbxConsult_gwa, "fbxConsult_gwa");
            this.fbxConsult_gwa.Name = "fbxConsult_gwa";
            this.fbxConsult_gwa.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxConsult_gwa_FindSelected);
            this.fbxConsult_gwa.TextChanged += new System.EventHandler(this.fbxConsult_gwa_TextChanged);
            // 
            // dbxConsult_gwa_name
            // 
            this.dbxConsult_gwa_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxConsult_gwa_name.EdgeRounding = false;
            resources.ApplyResources(this.dbxConsult_gwa_name, "dbxConsult_gwa_name");
            this.dbxConsult_gwa_name.Name = "dbxConsult_gwa_name";
            // 
            // enkReser_time
            // 
            this.enkReser_time.EditMaskType = IHIS.Framework.MaskType.Time;
            resources.ApplyResources(this.enkReser_time, "enkReser_time");
            this.enkReser_time.Mask = "HH:MI";
            this.enkReser_time.Name = "enkReser_time";
            this.enkReser_time.Protect = true;
            this.enkReser_time.ReadOnly = true;
            this.enkReser_time.TabStop = false;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // fbxConsult_doctor
            // 
            this.fbxConsult_doctor.ApplyByteLimit = true;
            this.fbxConsult_doctor.AutoTabDataSelected = true;
            this.fbxConsult_doctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.fbxConsult_doctor, "fbxConsult_doctor");
            this.fbxConsult_doctor.Name = "fbxConsult_doctor";
            this.toolTip1.SetToolTip(this.fbxConsult_doctor, resources.GetString("fbxConsult_doctor.ToolTip"));
            this.fbxConsult_doctor.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxConsult_doctor_FindSelected);
            // 
            // dbxConsult_doctor_name
            // 
            this.dbxConsult_doctor_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxConsult_doctor_name.EdgeRounding = false;
            resources.ApplyResources(this.dbxConsult_doctor_name, "dbxConsult_doctor_name");
            this.dbxConsult_doctor_name.Name = "dbxConsult_doctor_name";
            this.toolTip1.SetToolTip(this.dbxConsult_doctor_name, resources.GetString("dbxConsult_doctor_name.ToolTip"));
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // dbxReq_gwa_name
            // 
            this.dbxReq_gwa_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxReq_gwa_name.EdgeRounding = false;
            resources.ApplyResources(this.dbxReq_gwa_name, "dbxReq_gwa_name");
            this.dbxReq_gwa_name.Name = "dbxReq_gwa_name";
            // 
            // dbxReq_doctor_name
            // 
            this.dbxReq_doctor_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxReq_doctor_name.EdgeRounding = false;
            resources.ApplyResources(this.dbxReq_doctor_name, "dbxReq_doctor_name");
            this.dbxReq_doctor_name.Name = "dbxReq_doctor_name";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblAmPm_gubun
            // 
            this.lblAmPm_gubun.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblAmPm_gubun.EdgeRounding = false;
            this.lblAmPm_gubun.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.lblAmPm_gubun, "lblAmPm_gubun");
            this.lblAmPm_gubun.Name = "lblAmPm_gubun";
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // dpkJinryo_pre_date
            // 
            resources.ApplyResources(this.dpkJinryo_pre_date, "dpkJinryo_pre_date");
            this.dpkJinryo_pre_date.Name = "dpkJinryo_pre_date";
            this.dpkJinryo_pre_date.Protect = true;
            this.dpkJinryo_pre_date.ReadOnly = true;
            this.dpkJinryo_pre_date.TabStop = false;
            this.dpkJinryo_pre_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkJinryo_pre_date_DataValidating);
            // 
            // txtReq_remark
            // 
            this.txtReq_remark.ApplyByteLimit = true;
            resources.ApplyResources(this.txtReq_remark, "txtReq_remark");
            this.txtReq_remark.Name = "txtReq_remark";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // fbxSang_code3
            // 
            this.fbxSang_code3.ApplyByteLimit = true;
            this.fbxSang_code3.AutoTabDataSelected = true;
            this.fbxSang_code3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.fbxSang_code3, "fbxSang_code3");
            this.fbxSang_code3.Name = "fbxSang_code3";
            // 
            // fbxSang_code2
            // 
            this.fbxSang_code2.ApplyByteLimit = true;
            this.fbxSang_code2.AutoTabDataSelected = true;
            this.fbxSang_code2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.fbxSang_code2, "fbxSang_code2");
            this.fbxSang_code2.Name = "fbxSang_code2";
            // 
            // fbxSang_code1
            // 
            this.fbxSang_code1.ApplyByteLimit = true;
            this.fbxSang_code1.AutoTabDataSelected = true;
            this.fbxSang_code1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.fbxSang_code1, "fbxSang_code1");
            this.fbxSang_code1.Name = "fbxSang_code1";
            // 
            // txtSang_name3
            // 
            this.txtSang_name3.ApplyByteLimit = true;
            resources.ApplyResources(this.txtSang_name3, "txtSang_name3");
            this.txtSang_name3.Name = "txtSang_name3";
            // 
            // txtSang_name2
            // 
            this.txtSang_name2.ApplyByteLimit = true;
            resources.ApplyResources(this.txtSang_name2, "txtSang_name2");
            this.txtSang_name2.Name = "txtSang_name2";
            // 
            // txtSang_name1
            // 
            this.txtSang_name1.ApplyByteLimit = true;
            resources.ApplyResources(this.txtSang_name1, "txtSang_name1");
            this.txtSang_name1.Name = "txtSang_name1";
            // 
            // txtAnswer
            // 
            this.txtAnswer.ApplyByteLimit = true;
            resources.ApplyResources(this.txtAnswer, "txtAnswer");
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.ReadOnly = true;
            this.txtAnswer.TabStop = false;
            // 
            // chkAnswer_end_yn
            // 
            resources.ApplyResources(this.chkAnswer_end_yn, "chkAnswer_end_yn");
            this.chkAnswer_end_yn.Name = "chkAnswer_end_yn";
            this.chkAnswer_end_yn.UseVisualStyleBackColor = false;
            // 
            // chkConfirm_yn
            // 
            resources.ApplyResources(this.chkConfirm_yn, "chkConfirm_yn");
            this.chkConfirm_yn.Name = "chkConfirm_yn";
            this.chkConfirm_yn.UseVisualStyleBackColor = false;
            // 
            // btnReq_remark
            // 
            resources.ApplyResources(this.btnReq_remark, "btnReq_remark");
            this.btnReq_remark.Image = ((System.Drawing.Image)(resources.GetObject("btnReq_remark.Image")));
            this.btnReq_remark.Name = "btnReq_remark";
            this.btnReq_remark.Click += new System.EventHandler(this.btnReq_remark_Click);
            // 
            // dbxApp_date
            // 
            this.dbxApp_date.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxApp_date.EdgeRounding = false;
            this.dbxApp_date.EditMaskType = IHIS.Framework.MaskType.Date;
            resources.ApplyResources(this.dbxApp_date, "dbxApp_date");
            this.dbxApp_date.Name = "dbxApp_date";
            this.toolTip1.SetToolTip(this.dbxApp_date, resources.GetString("dbxApp_date.ToolTip"));
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "";
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
            this.multiLayoutItem9});
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
            this.multiLayoutItem3.DataName = "req_date";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "req_gwa_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "req_doctor_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "consult_gwa_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "consult_doctor_name";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "header";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "jinryo_pre_date";
            // 
            // layNaewonChk
            // 
            this.layNaewonChk.ExecuteQuery = null;
            this.layNaewonChk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layNaewonChk.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layNaewonChk.ParamList")));
            this.layNaewonChk.QuerySQL = "select naewon_yn \r\n  from out1001 \r\n where HOSP_CODE = :f_hosp_code\r\n   and PKOUT" +
                "1001 = :f_naewon_key";
            this.layNaewonChk.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNaewonChk_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "naewon_yn";
            // 
            // layTerm
            // 
            this.layTerm.ExecuteQuery = null;
            this.layTerm.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14});
            this.layTerm.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTerm.ParamList")));
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "am_start";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "am_end";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "pm_start";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "pm_end";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.DateTime;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "avg_time";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // layReserCanYN
            // 
            this.layReserCanYN.ExecuteQuery = null;
            this.layReserCanYN.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layReserCanYN.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserCanYN.ParamList")));
            this.layReserCanYN.QuerySQL = "SELECT FN_OUT_CHECK_CAN_RESER_YN(:f_reser_date, :f_reser_time, :f_reser_doctor) \r" +
                "\n                                                FROM DUAL";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "result";
            // 
            // layOrderInfo
            // 
            this.layOrderInfo.ExecuteQuery = null;
            this.layOrderInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23});
            this.layOrderInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderInfo.ParamList")));
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "bunho";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "suname";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "req_date";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "req_gwa_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "req_doctor_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "consult_gwa_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "consult_doctor_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "header";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "jinryo_pre_date";
            // 
            // pnlGrdContainner
            // 
            this.pnlGrdContainner.Controls.Add(this.xPnlSelectTab);
            this.pnlGrdContainner.Controls.Add(this.grdOCS0503);
            resources.ApplyResources(this.pnlGrdContainner, "pnlGrdContainner");
            this.pnlGrdContainner.Name = "pnlGrdContainner";
            // 
            // xPnlSelectTab
            // 
            this.xPnlSelectTab.Controls.Add(this.rbnTab2);
            this.xPnlSelectTab.Controls.Add(this.rbnTab1);
            resources.ApplyResources(this.xPnlSelectTab, "xPnlSelectTab");
            this.xPnlSelectTab.Name = "xPnlSelectTab";
            // 
            // rbnTab2
            // 
            resources.ApplyResources(this.rbnTab2, "rbnTab2");
            this.rbnTab2.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnTab2.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnTab2.Name = "rbnTab2";
            this.rbnTab2.Tag = "";
            this.rbnTab2.UseVisualStyleBackColor = false;
            // 
            // rbnTab1
            // 
            resources.ApplyResources(this.rbnTab1, "rbnTab1");
            this.rbnTab1.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbnTab1.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbnTab1.Name = "rbnTab1";
            this.rbnTab1.TabStop = true;
            this.rbnTab1.Tag = "";
            this.rbnTab1.UseVisualStyleBackColor = false;
            // 
            // OCS2016U00
            // 
            this.Controls.Add(this.pnlOCS2016U00);
            this.Controls.Add(this.pnlGrdContainner);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS2016U00";
            resources.ApplyResources(this, "$this");
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS0503U00_Closing);
            this.Load += new System.EventHandler(this.OCS0503U00_Load);
            this.UserChanged += new System.EventHandler(this.OCS0503U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0503U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRequest_bunho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0503)).EndInit();
            this.pnlOCS2016U00.ResumeLayout(false);
            this.pnlOCS2016U00.PerformLayout();
            this.pnlTab2Info.ResumeLayout(false);
            this.pnlTab1Info.ResumeLayout(false);
            this.pnlTab1Info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloPrintInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderInfo)).EndInit();
            this.pnlGrdContainner.ResumeLayout(false);
            this.xPnlSelectTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            //switch (command.Trim())
            //{
            //    case "CHT0110Q01": // 상병조회

            //        if (commandParam.Contains("CHT0110") && (MultiLayout)commandParam["CHT0110"] != null &&
            //            ((MultiLayout)commandParam["CHT0110"]).RowCount > 0)
            //        {
            //            string sang_name = txtConsult_sang_name.GetDataValue();
            //            for (int i = 0; i < ((MultiLayout)commandParam["CHT0110"]).RowCount; i++)
            //            {
            //                if (TypeCheck.IsNull(sang_name))
            //                    sang_name = sang_name + ((MultiLayout)commandParam["CHT0110"]).GetItemString(i, "sang_name");
            //                else
            //                    sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["CHT0110"]).GetItemString(i, "sang_name");
            //            }
            //            txtConsult_sang_name.SetEditValue(sang_name);
            //            if (grdOCS0503.CurrentRowNumber >= 0) this.grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_sang_name", sang_name);
            //            txtConsult_sang_name.Focus();
            //            if (!TypeCheck.IsNull(txtConsult_sang_name.Text)) txtConsult_sang_name.SelectionStart = sang_name.Length;
            //            txtConsult_sang_name.ScrollToCaret();
            //        }
            //        break;
            //    case "BAS0270": // 의사조회
            //        if (commandParam.Contains("BAS0270") && (MultiLayout)commandParam["BAS0270"] != null &&
            //            ((MultiLayout)commandParam["BAS0270"]).RowCount > 0)
            //            ActiveFincBox.SetEditValue(((MultiLayout)commandParam["BAS0270"]).GetItemString(0, "doctor"));
            //        ActiveFincBox.AcceptData();
            //        ActiveFincBox.Focus();
            //        ActiveFincBox.SelectAll();
            //        break;

            //    case "OCS0270Q00": // 의사조회
            //        if (!TypeCheck.IsNull(commandParam["doctor"].ToString()))
            //        {
            //            ActiveFincBox.SetEditValue(commandParam["doctor"].ToString());
            //            if (grdOCS0503.CurrentRowNumber >= 0) this.grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_doctor", commandParam["doctor"].ToString());
            //        }
            //        ActiveFincBox.AcceptData();
            //        ActiveFincBox.Focus();
            //        ActiveFincBox.SelectAll();
            //        break;
            //    case "OCS0221Q01": // 상용어
            //        #region
            //        if (commandParam.Contains("COMMENT"))
            //        {
            //            if (grdOCS0503.CurrentRowNumber < 0) break;
            //            int startIndex = 0;
            //            string reservedRemark = "";
            //            startIndex = txtReq_remark.SelectionStart;
            //            reservedRemark = txtReq_remark.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
            //                + txtReq_remark.Text.Substring(startIndex);

            //            txtReq_remark.SetEditValue(reservedRemark);
            //            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "req_remark", reservedRemark);
            //        }
            //        break;
            //        #endregion

            //    case "OCS0204Q00": // 상병조회

            //        if (commandParam.Contains("OCS0205") && (MultiLayout)commandParam["OCS0205"] != null &&
            //            ((MultiLayout)commandParam["OCS0205"]).RowCount > 0)
            //        {
            //            string sang_name = txtConsult_sang_name.GetDataValue();
            //            for (int i = 0; i < ((MultiLayout)commandParam["OCS0205"]).RowCount; i++)
            //            {
            //                if (TypeCheck.IsNull(sang_name))
            //                    sang_name = sang_name + ((MultiLayout)commandParam["OCS0205"]).GetItemString(i, "sang_name");
            //                else
            //                    sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["OCS0205"]).GetItemString(i, "sang_name");

            //            }
            //            txtConsult_sang_name.SetEditValue(sang_name);
            //            if (grdOCS0503.CurrentRowNumber >= 0) this.grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_sang_name", sang_name);
            //            txtConsult_sang_name.Focus();
            //            txtConsult_sang_name.SelectAll();
            //            if (!TypeCheck.IsNull(txtConsult_sang_name.Text)) txtConsult_sang_name.SelectionStart = sang_name.Length;
            //            txtConsult_sang_name.ScrollToCaret();
            //        }
            //        break;

            //    case "OUTSANGQ00":
            //        if (commandParam.Contains("OUTSANG") && (MultiLayout)commandParam["OUTSANG"] != null &&
            //            ((MultiLayout)commandParam["OUTSANG"]).RowCount > 0)
            //        {
            //            string sang_name = txtConsult_sang_name.GetDataValue();
            //            for (int i = 0; i < ((MultiLayout)commandParam["OUTSANG"]).RowCount; i++)
            //            {
            //                if (TypeCheck.IsNull(sang_name))
            //                    sang_name = sang_name + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_name");
            //                else
            //                    sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_name");
            //            }

            //            txtConsult_sang_name.SetEditValue(sang_name);
            //            if (grdOCS0503.CurrentRowNumber >= 0) this.grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_sang_name", sang_name);
            //            txtConsult_sang_name.Focus();
            //            if (!TypeCheck.IsNull(txtConsult_sang_name.Text)) txtConsult_sang_name.SelectionStart = sang_name.Length;
            //            txtConsult_sang_name.ScrollToCaret();
            //        }
            //        break;
            //    case "RES1001U00":
            //        if (commandParam != null)
            //        {
            //            if ((commandParam.Contains("naewon_date")) && !TypeCheck.IsNull(commandParam["naewon_date"]))
            //            {
            //                //this.dpkJinryo_pre_date.SetDataValue(commandParam["naewon_date"].ToString());
            //                this.dpkJinryo_pre_date.SetEditValue(commandParam["naewon_date"].ToString());
            //                this.dpkJinryo_pre_date.AcceptData();
            //            }
            //            if ((commandParam.Contains("reser_time")) && !TypeCheck.IsNull(commandParam["reser_time"]))
            //            {
            //                //this.txtReser_time.SetDataValue(commandParam["reser_time"].ToString());
            //                //string time = commandParam["reser_time"].ToString();
            //                //if (dpkJinryo_pre_date.GetDataValue() == EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"))
            //                //{
            //                //    XMessageBox.Show("当日診療依頼は時間指定ができません。", "確認", MessageBoxIcon.Information);
            //                //    time = "0000";
            //                //}
            //                this.enkReser_time.SetEditValue(commandParam["reser_time"].ToString());
            //                this.enkReser_time.AcceptData();
            //            }
            //        }
            //        break;
            //}
            return base.Command(command, commandParam);
        }

        private void OCS0503U00_Load(object sender, System.EventArgs e)
        {
            SetControl(ref htOCS0503, pnlOCS2016U00, ref grdOCS0503);

            pnlOCS2016U00.Enabled = false;

            this.layOrderInfo = this.grdOCS0503.CloneToLayout();
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        private void PostLoad()
        {
            //Current LayOut 설정
            CurrMSLayout = grdOCS0503;
            CurrMQLayout = grdOCS0503;
        }
        private void OCS0503U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            // Call된 경우
            if (this.Opener != null &&
                this.Opener is XScreen &&
                this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                    {
                        mBunho = OpenParam["bunho"].ToString().Trim();
                    }
                    if (OpenParam.Contains("req_gwa"))
                    {
                        mRequest_gwa = OpenParam["req_gwa"].ToString().Trim();
                        mRequest_gwa_name = GetCodeName("gwa_name", mRequest_gwa);
                    }
                    if (OpenParam.Contains("req_doctor"))
                    {
                        mRequest_doctor = OpenParam["req_doctor"].ToString().Trim();
                        mRequest_doctor_name = GetCodeName("doctor_name", mRequest_doctor);
                    }
                    if (OpenParam.Contains("naewon_key"))
                    {
                        mNaewon_key = OpenParam["naewon_key"].ToString().Trim();
                    }

                    mRequest_date = DateTime.Now.ToString("yyyy/MM/dd");
                    if (OpenParam.Contains("req_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["req_date"].ToString()))
                            mRequest_date = OpenParam["req_date"].ToString();
                    }

                    if (OpenParam.Contains("naewon_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                        {
                            this.dpkJinryo_pre_date.SetDataValue(OpenParam["req_date"].ToString());
                            //this.dpkJinryo_pre_date.AcceptData();
                        }
                    }
                    if (OpenParam.Contains("reser_time"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["reser_time"].ToString()))
                        {
                            this.enkReser_time.SetDataValue(OpenParam["reser_time"].ToString());
                            //this.enkReser_time.AcceptData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "");
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

                mRequest_gwa = UserInfo.Gwa;
                mRequest_gwa_name = UserInfo.GwaName;
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    mRequest_doctor = UserInfo.DoctorID;
                }
                else
                {
                    mRequest_doctor = UserInfo.UserID;
                }
                mRequest_doctor_name = UserInfo.UserName;
                mRequest_date = DateTime.Now.ToString("yyyy/MM/dd");

                if (EnvironInfo.CurrSystemID == "OCSI" ||
                    EnvironInfo.CurrSystemID == "NURI" ||
                    EnvironInfo.CurrSystemID == "INPS")
                    mIn_out_gubun = "I";
                else
                    mIn_out_gubun = "O";
            }
            this.dpkReq_date.SetDataValue(mRequest_date);
            pbxRequest_bunho.SetPatientID(mBunho);

            if (this.OpenParam != null && this.OpenParam.Contains("caller_screen_id"))
            {
                this.mCallerScreenID = this.OpenParam["caller_screen_id"].ToString();
            }
        }
        private void OCS0503U00_UserChanged(object sender, System.EventArgs e)
        {
            mRequest_gwa = UserInfo.Gwa;
            mRequest_gwa_name = UserInfo.GwaName;
            mRequest_doctor = UserInfo.UserID;
            mRequest_doctor_name = UserInfo.UserName;
            LoadOCS0503();
        }
        private void OCS0503U00_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //grdOCS0503
            for (int rowIndex = 0; rowIndex < grdOCS0503.RowCount; rowIndex++)
            {
                if (grdOCS0503.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_gwa").Trim()) && TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "req_remark").Trim()))
                    {
                        grdOCS0503.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }
            }
            // 변경된 내용체크
            foreach (DataRow dr in this.grdOCS0503.LayoutTable.Rows)
            {
                if (dr.RowState != DataRowState.Unchanged)
                {
                    this.mbxMsg = Resources.mbxMsg1658;
                    this.mbxCap = Resources.mbxCap1659;

                    if (XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.xButtonList1.PerformClick(FunctionType.Update);
                        return;
                    }
                }
            }
            //insert by jc 
            if (grdOCS0503.DeletedRowCount > 0)
            {
                this.mbxMsg = Resources.mbxMsg1658;
                this.mbxCap = Resources.mbxCap1659;

                if (XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.xButtonList1.PerformClick(FunctionType.Update);
                    return;
                }
            }

            if (this.Opener is XScreen &&
                this.OpenParam != null)
            {
                XScreen screen = (XScreen)this.Opener;
                if (screen.Name == "RES1001U00")
                {
                    this.RES1001U00_Open("");
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
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XFindBox)obj).FindClick += new System.ComponentModel.CancelEventHandler(Control_FindClick);
                        ((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDatePicker)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message);
                }
            }
            grdControl.InitializeColumns();
        }

        /// <summary>
        /// 해당 Grid에 Binding 
        /// ** Frame에서 제공하는 SetBindControl이 문제가 있어서 별도 처리.
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        private void SetGridBinding(XEditGrid aGrid, string colName, IDataControl control)
        {
            foreach (XEditGridCell cell in aGrid.CellInfos)
            {
                if (cell.CellName == colName)
                    cell.BindControl = control;
            }
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
        /// 画面をUPDATE後のメッセージ出力
        /// </summary>
        private void SaveAfterMSG(bool flg)
        {
            this.PrintJinryoReser();
            // 저장완료후.....
            //this.mbxMsg = "保存が完了しました。";
            //this.mbxCap = "保存完了";
            //XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if ((flg) && (UserInfo.UserGubun == UserType.Doctor))
            {
                if (this.layNaewonChk.QueryLayout())
                {
                    if (this.layNaewonChk.GetItemValue("naewon_yn").ToString() == "Y")
                    {
                        XMessageBox.Show(Resources.OCS0503U00_SaveAfterMSG_1814, Resources.OCS0503U00_SaveAfterMSG_1814_2, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
            else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
            {
                colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
            }
            return colName;
        }

        /// <summary>
        /// Control의 protect를 설정한다.
        /// </summary>
        private void SetControlProtect(ref XEditGrid grdControl, ref Hashtable htControl)
        {

            int rowIndex = grdControl.CurrentRowNumber;

            if (rowIndex < 0) return;

            //insert by jc
            //if (grdControl.GetRowState(rowIndex) != DataRowState.Added)
            //{
            //    this.cboAmPm_gubun.Protect = true;
            //}

            //if ((grdControl.GetItemString(rowIndex, "req_doctor") != "") &&
            //    (grdControl.GetItemString(rowIndex, "req_doctor") != UserInfo.DoctorID))
            //{
            //    foreach (string key in htControl.Keys)
            //    {
            //        ((IDataControl)htControl[key]).Protect = true;
            //    }
            //    txtConsult_sang_name.Protect = true;
            //    txtReq_remark.Protect = true;
            //    dpkJinryo_pre_date.Protect = true;
            //    btnOutsang.Enabled = false;
            //    btnSangCode.Enabled = false;
            //    btnUserSangCode.Enabled = false;
            //    btnReq_remark.Enabled = false;
            //    chkReq_end_yn.Protect = true;
            //    if (UserInfo.UserGubun != UserType.Doctor)
            //    {
            //        //this.btnResOpen.Visible = true;
            //        this.dpkJinryo_pre_date.Protect = false;
            //    }
            //    else 
            //    {
            //        //this.btnResOpen.Visible = false;
            //        this.dpkJinryo_pre_date.Protect = true;
            //    }
            //}
            //else
            //{
            //    foreach (string key in htControl.Keys)
            //    {
            //        // Not Updatable 컬럼 protect설정
            //        if (grdControl.GetRowState(rowIndex) != DataRowState.Added)
            //        {
            //            if (key.Equals("ampm_gubun"))
            //            {
            //                continue;
            //            }
            //            if ((!((XEditGridCell)grdControl.CellInfos[key]).IsUpdatable) || 
            //                (key.Equals("jinryo_pre_date")) || 
            //                (key.Equals("reser_time")))
            //            {
            //                ((IDataControl)htControl[key]).Protect = true;
            //            }
            //            else
            //            {
            //                ((IDataControl)htControl[key]).Protect = false;
            //            }
            //        }
            //        else
            //        {
            //            ((IDataControl)htControl[key]).Protect = false;
            //        }
            //    }
            //    this.txtConsult_sang_name.Protect = false;
            //    this.txtReq_remark.Protect = false;
            //    this.btnOutsang.Enabled = true;
            //    this.btnSangCode.Enabled = true;
            //    this.btnUserSangCode.Enabled = true;
            //    this.btnReq_remark.Enabled = true;
            //    if ((this.fbxConsult_gwa.GetDataValue().ToString() != "") &&
            //        (this.fbxConsult_doctor.GetDataValue().ToString() != "")&&
            //        (grdControl.GetItemString(rowIndex, "confirm_yn")) != "Y")
            //    {
            //        //this.btnResOpen.Visible = true;
            //        this.dpkJinryo_pre_date.Protect = false;
            //    }
            //    else
            //    {
            //        if (this.fbxConsult_gwa.GetDataValue().ToString() == "")
            //        {
            //            this.fbxConsult_doctor.Protect = true;
            //        }
            //        //this.btnResOpen.Visible = false;
            //    }
            //}
            //chkConfirm_yn.Protect = true;
            //chkAnswer_end_yn.Protect = true;
            //if (this.dpkJinryo_pre_date.GetDataValue()!="")
            //{
            //    this.SetControlbtnResOpen();
            //}

            //if (grdControl.GetItemString(rowIndex, "answer_end_yn") == "Y" || grdControl.GetItemString(rowIndex, "confirm_yn") == "Y")
            //{
            //    this.txtConsult_sang_name.Enabled = false;
            //    this.txtReq_remark.Enabled = false;

            //}

            //if (grdControl.GetItemString(rowIndex, "req_end_yn") == "Y")
            //{
            //    this.txtAnswer.Enabled = false;
            //}

            //==================================
            //if (grdControl.GetItemString(rowIndex, "req_doctor") != UserInfo.DoctorID)
            //{
            //    //chkReq_end_yn.Protect = true;
            //    //btnResOpen.Visible = false;
            //}

            //if (this.fbxConsult_gwa.GetDataValue().ToString() == "")
            //{
            //    this.fbxConsult_doctor.Protect = true;
            //    //this.dbxConsult_doctor_name.Visible = false;
            //    //this.btnResOpen.Visible = false;
            //}
            //if (this.fbxConsult_doctor.GetDataValue().ToString() == "")
            //{
            //    //this.dpkJinryo_pre_date.Protect = true;
            //    //this.ibtPre_date_clear.Enabled = false;
            //    //this.btnResOpen.Visible = false;
            //}

            //if ((this.fbxConsult_gwa.GetDataValue().ToString() != "") &&
            //    (this.fbxConsult_doctor.GetDataValue().ToString() != ""))
            //{
            //    this.btnResOpen.Visible = true;
            //}
            //else
            //{
            //    this.btnResOpen.Visible = false;
            //}

            //if (!TypeCheck.IsDateTime(grdControl.GetItemString(rowIndex, "jinryo_pre_date")) ||
            //    int.Parse(DateTime.Parse(dpkJinryo_pre_date.GetDataValue()).ToString("yyyyMMdd")) <= int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            ////int.Parse(grdControl.GetItemDateTime(rowIndex, "jinryo_pre_date").ToString("yyyyMMdd")) <= int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            //{
            //    //lblAmPm_gubun.Visible = false;
            //    cboAmPm_gubun.Visible = false;
            //}
            //else
            //{
            //    //lblAmPm_gubun.Visible = true;
            //    cboAmPm_gubun.Visible = true;
            //}

            //if (dpkJinryo_pre_date.Protect)
            //    ibtPre_date_clear.Enabled = false;
            //else
            //    ibtPre_date_clear.Enabled = true;

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
                    openParams.Add("sang_inx", ActiveFincBox.GetDataValue().Trim());
                    openParams.Add("multiSelect", false);
                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
                    fbxControl.SelectNextControl(fbxControl, true, true, false, false);
                    break;

                case "sang_code2":
                    openParams = new CommonItemCollection();
                    openParams.Add("sang_inx", ActiveFincBox.GetDataValue().Trim());
                    openParams.Add("multiSelect", false);
                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
                    fbxControl.SelectNextControl(fbxControl, true, true, false, false);
                    break;

                case "sang_code3":
                    openParams = new CommonItemCollection();
                    openParams.Add("sang_inx", ActiveFincBox.GetDataValue().Trim());
                    openParams.Add("multiSelect", false);
                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
                    fbxControl.SelectNextControl(fbxControl, true, true, false, false);
                    break;
                case "consult_gwa":
                    //fbxControl.FindWorker = this.GetFindWorker("consult_gwa", "");
                    fbxControl.FindWorker = this.GetFindWorker2("consult_gwa", "");
                    break;

                case "consult_doctor":

                    fbxControl.FindWorker = null;
                    string gwa = fbxConsult_gwa.GetDataValue();
                    if (TypeCheck.IsNull(gwa))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "施行科が入力されてないか、入力間違っています。ご確認ください。" : Resources.OCS0503U00_msg2066;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                        break;
                    }
                    fbxControl.FindWorker = this.GetFindWorker2("consult_doctor", gwa);
                    //openParams = new CommonItemCollection();
                    //openParams.Add("gwa", gwa);
                    //openParams.Add("word", "");
                    //openParams.Add("all_gubun", "N");
                    //openParams.Add("query_gubun", "%");
                    //XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
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

            //switch (colName)
            //{
            //    case "sang_code1":
            //        if (e.DataValue.ToString().Trim() == "") break;
            //        //Check Origin Data
            //        codeName = this.GetCodeName("sang_code", e.DataValue.ToString());
            //        if (codeName == "")
            //        {
            //            ActiveFincBox = sender as XFindBox;
            //            CommonItemCollection openParams = new CommonItemCollection();
            //            openParams.Add("sang_inx", e.DataValue.ToString().Trim());
            //            openParams.Add("multiSelect", false);
            //            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
            //            break;
            //        }
            //        else
            //        {
            //            txtSang_name1.SetEditValue(codeName);
            //            txtSang_name1.AcceptData();
            //        }
            //        break;
            //    case "sang_code2":
            //        if (e.DataValue.ToString().Trim() == "") break;
            //        //Check Origin Data
            //        codeName = this.GetCodeName("sang_code", e.DataValue.ToString());
            //        if (codeName == "")
            //        {
            //            ActiveFincBox = sender as XFindBox;

            //            CommonItemCollection openParams = new CommonItemCollection();
            //            openParams.Add("sang_inx", e.DataValue.ToString().Trim());
            //            openParams.Add("multiSelect", false);
            //            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
            //            break;
            //        }
            //        else
            //        {
            //            txtSang_name2.SetEditValue(codeName);
            //            txtSang_name2.AcceptData();
            //        }
            //        break;
            //    case "sang_code3":
            //        if (e.DataValue.ToString().Trim() == "") break;
            //        //Check Origin Data
            //        codeName = this.GetCodeName("sang_code", e.DataValue.ToString());
            //        if (codeName == "")
            //        {
            //            ActiveFincBox = sender as XFindBox;

            //            CommonItemCollection openParams = new CommonItemCollection();
            //            openParams.Add("sang_inx", e.DataValue.ToString().Trim());
            //            openParams.Add("multiSelect", false);
            //            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
            //            break;
            //        }
            //        else
            //        {
            //            txtSang_name3.SetEditValue(codeName);
            //            txtSang_name3.AcceptData();
            //        }
            //        break;

            //    case "consult_gwa":
            //        dbxConsult_doctor_name.SetEditValue("");
            //        grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_doctor_name", "");
            //        this.fbxConsult_doctor.ResetText();
            //        this.fbxConsult_doctor.Clear();
            //        this.dbxConsult_doctor_name.ResetText();
            //        //this.dpkJinryo_pre_date.SetDataValue(EnvironInfo.GetSysDate());
            //        //SetControlProtect(ref grdOCS0503, ref this.htOCS0503);
            //        //if (this.fbxConsult_gwa.GetDataValue().ToString() != "")
            //        //{
            //        //    this.fbxConsult_doctor.Protect = false;
            //        //    //this.dpkJinryo_pre_date.Protect = false;
            //        //    //this.ibtPre_date_clear.Enabled = true;
            //        //    //this.dbxConsult_doctor_name.Visible = true;
            //        //}
            //        //else
            //        //{
            //        //    this.fbxConsult_doctor.Protect = true;
            //        //    //this.dpkJinryo_pre_date.Protect = true;
            //        //    //this.ibtPre_date_clear.Enabled = false;
            //        //    this.dbxConsult_gwa_name.Text = "";

            //        //    //this.dbxConsult_doctor_name.Visible = false;
            //        //}
            //        if (e.DataValue.ToString().Trim() == "")
            //        {
            //            dbxConsult_gwa_name.SetEditValue(codeName);
            //            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_gwa_name", codeName);
            //            this.fbxConsult_doctor.Protect = true;
            //            this.dbxConsult_gwa_name.Text = "";
            //            this.dpkJinryo_pre_date.Protect = true;
            //            this.SetControlbtnResOpen();
            //            break;  
            //        }
            //        //Check Origin Data
            //        codeName = this.GetCodeName("gwa_name", e.DataValue.ToString());
            //        if (codeName == "")
            //        {
            //            mbxMsg = NetInfo.Language == LangMode.Jr ? "施行科入力が間違っています。ご確認ください。" : Resources.OCS0503U00_msg2066;
            //            mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : Resources.OCS0503U00_text_xn;
            //            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
            //            e.Cancel = true;
            //        }
            //        else
            //        {
            //            dbxConsult_gwa_name.SetEditValue(codeName);
            //            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_gwa_name", codeName);
            //            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "req_gwa", e.DataValue.ToString());
            //            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_gwa", e.DataValue.ToString());
            //            this.fbxConsult_doctor.Protect = false;
            //            this.dpkJinryo_pre_date.Protect = false;
            //            this.fbxConsult_doctor.Focus();
            //        }
            //        break;
            //    case "consult_doctor":
            //        if (e.DataValue.ToString().Trim() == "")
            //        {
            //            dbxConsult_doctor_name.SetEditValue("");
            //            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_doctor_name", "");
            //            this.SetControlbtnResOpen();
            //            break;
            //        }
            //        //Check Origin Data
            //        codeName = this.GetCodeName("doctor_name", e.DataValue.ToString());
            //        if (codeName == "")
            //        {
            //            mbxMsg = NetInfo.Language == LangMode.Jr ? "施行医師入力が間違っています。ご確認ください。" : Resources.OCS0503U00_text2216;
            //            mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : Resources.OCS0503U00_text_xn;
            //            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
            //            e.Cancel = true;
            //        }
            //        else if (codeName == "XXX")
            //        {
            //            mbxMsg = NetInfo.Language == LangMode.Jr ? "施行科入力が間違っています。ご確認ください。" : Resources.OCS0503U00_msg2066;
            //            mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : Resources.OCS0503U00_text_xn;
            //            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
            //            e.Cancel = true;
            //        }
            //        else
            //        {
            //            dbxConsult_doctor_name.SetEditValue(codeName);
            //            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "consult_doctor_name", codeName);
            //            this.SetControlbtnResOpen();
            //            this.txtConsult_sang_name.Focus();
            //        }
            //        break;
            //    case "jinryo_pre_date":
            //        //if (!TypeCheck.IsDateTime(e.DataValue))
            //        //{
            //        //    //lblAmPm_gubun.Visible = false;
            //        //    cboAmPm_gubun.Visible = false;
            //        //    break;
            //        //}

            //        //if (int.Parse(DateTime.Parse(e.DataValue).ToString("yyyyMMdd")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            //        //{
            //        //    //lblAmPm_gubun.Visible = true;
            //        //    cboAmPm_gubun.Visible = true;
            //        //}
            //        //else
            //        //{
            //        //    //lblAmPm_gubun.Visible = false;
            //        //    cboAmPm_gubun.Visible = false;
            //        //}
            //        if (e.DataValue.ToString().Trim() == "") break;
            //        grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "jinryo_pre_date", e.DataValue);
            //        PostCallHelper.PostCall(check_jinryo_pre_date, e.DataValue);
            //        break;
            //    case "reser_time":
            //        PostCallHelper.PostCall(check_reser_time, e.DataValue);
            //        break;
            //    default:
            //        break;
            //}
        }
        #endregion
        void check_reser_time(string DataValue)
        {
            string Value = DataValue;
            if (dpkJinryo_pre_date.GetDataValue() == EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"))
            {
                XMessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxIcon.Information);
                return;
            }
            grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "reser_time", Value);
        }
        void check_jinryo_pre_date(string DataValue)
        {
            if (int.Parse(DataValue.Replace("/", "").Replace("-", "")) < int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").Trim()))
            {
                XMessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F003"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dpkJinryo_pre_date.SetDataValue(EnvironInfo.GetSysDate());
                this.grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "jinryo_pre_date", this.dpkJinryo_pre_date.GetDataValue());
            }
            this.grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "reser_time", "0000");
        }
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
            IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;

            if (code.Trim() == "") return codeName;

            OCS0503U00GetCodeNameArgs args = new OCS0503U00GetCodeNameArgs();
            args.Code = code;
            args.CodeMode = codeMode;
            OCS0503U00GetCodeNameResult result =
                CloudService.Instance.Submit<OCS0503U00GetCodeNameResult, OCS0503U00GetCodeNameArgs>(args);
            if (result != null)
            {
                codeName = result.CodeName;
            }

            return codeName;
        }
        #endregion

        #region [GetFindWorker]
        private XFindWorker GetFindWorker(string findMode, string ref_code)
        {
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
            return fdwCommon;
        }
        #endregion
        #region [Control Event]
        private void pbxRequest_bunho_PatientSelected(object sender, System.EventArgs e)
        {
            mBunho = pbxRequest_bunho.BunHo;
            //CheckInpPatient(mBunho);
            CheckInpPatient2(mBunho);
            LoadOCS0503();
            if (TypeCheck.IsDateTime(mRequest_date) && grdOCS0503.RowCount < 1) InsertRow_grdOCS0503();
        }
        private void dpkReq_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //if (!TypeCheck.IsDateTime(e.DataValue.ToString()))
            //{
            //    mbxMsg = NetInfo.Language == LangMode.Jr ? "依頼日付の入力に間違いがあります。 ご確認ください。" : "의뢰일자가 정확하지않습니다. 확인바랍니다.";
            //    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
            //    XMessageBox.Show(mbxMsg, mbxCap);
            //    return;
            //}
            //else
            //{
            //    mRequest_date = e.DataValue.ToString();

            //    if (mBunho == "") return;
            //    LoadOCS0503();
            //}
        }
        private void pbxRequest_bunho_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            mBunho = "";
            mIn_out_gubun = "O";
            mFkinp1001 = 0;
            grdOCS0503.Reset();
        }
        private void grdOCS0503_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //this.txtConsult_sang_name.Enabled = true;
            //this.txtReq_remark.Enabled = true;
            //this.txtAnswer.Enabled = true;
            //if (e.CurrentRow < 0)
            //{
            //    pnlOCS0503.Enabled = false;
            //    this.chkReq_end_yn.Enabled = false;
            //    //lblAmPm_gubun.Visible = true;
            //    //cboAmPm_gubun.Visible = true;
            //    return;
            //}
            //else
            //{
            //    pnlOCS0503.Enabled = true;

            //    if (this.grdOCS0503.GetItemString(this.grdOCS0503.CurrentRowNumber, "req_end_yn") == "Y")
            //    {
            //        this.chkReq_end_yn.Checked = true;
            //    }
            //    else
            //    {
            //        this.chkReq_end_yn.Checked = false;
            //    }

            //    //this.CreateTimeCombo(fbxConsult_doctor.GetDataValue().ToString(), dpkJinryo_pre_date.GetDataValue().ToString(), true);
            //}
            SetControlProtect(ref grdOCS0503, ref this.htOCS0503);
        }
        private void ibtPre_date_clear_Click(object sender, System.EventArgs e)
        {
            this.dpkJinryo_pre_date.SetEditValue("");
            if (grdOCS0503.CurrentRowNumber >= 0) grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "jinryo_pre_date", "");
            this.AcceptData();
            //lblAmPm_gubun.Visible = false;
            //cboAmPm_gubun.Visible = false;
        }
        #endregion

        #region [Function]
        private void LoadOCS0503()
        {
            grdOCS0503.SetBindVarValue("f_req_date", mRequest_date.Substring(0, 10));// .Replace(" 0:00:00", "")  );
            grdOCS0503.SetBindVarValue("f_req_gwa", mRequest_gwa);
            grdOCS0503.SetBindVarValue("f_req_doctor", mRequest_doctor);
            grdOCS0503.SetBindVarValue("f_bunho", mBunho);
            grdOCS0503.SetBindVarValue("f_hosp_code", mHospCode);
            grdOCS0503.QueryLayout(false);
        }
        /// <summary>
        /// 의뢰내용 등록
        /// </summary>
        private void InsertRow_grdOCS0503()
        {
            this.AcceptData();

            if (!this.IsInsertGridOCS0503()) return;

            if (mBunho == "")
            {
                mbxMsg = Resources.OCS0503U00_tmsbn;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            //int pkocs0503 = GetPKOCS0503();
            int pkocs0503 = GetPKOCS0503_2();
            if (pkocs0503 == 0) return;

            int currentDateRow = -1;
            string currentDate = DateTime.Now.ToString("yyyy/MM/dd");
            if (TypeCheck.IsDateTime(dpkReq_date.GetDataValue()))
                currentDate = dpkReq_date.GetDataValue();
            dpkJinryo_pre_date.SetDataValue(currentDate);
            //해당일자의 마지막에 등록가능하게 Insert위치를 찾는다.
            //for (int i = 0; i < grdOCS0503.RowCount; i++)
            //{
            //    if (currentDate == grdOCS0503.GetItemString(i, "req_date"))
            //    {
            //        currentDateRow = i;
            //    }
            //}
            //int insertRow = grdOCS0503.InsertRow(currentDateRow);
            currentDateRow = (grdOCS0503.RowCount - 1);
            int insertRow = grdOCS0503.InsertRow(currentDateRow);
            //initial value
            grdOCS0503.SetItemValue(insertRow, "req_date", currentDate);
            grdOCS0503.SetItemValue(insertRow, "jinryo_pre_date", currentDate);


            //if( int.Parse(DateTime.Parse(currentDate).ToString("yyyyMMdd")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")) )
            //{
            //    lblAmPm_gubun.Visible = true;
            //    cboAmPm_gubun.Visible = true;
            //}
            //else
            //{
            //    //lblAmPm_gubun.Visible = false;
            //    cboAmPm_gubun.Visible = false;
            //}
            this.dpkJinryo_pre_date.Protect = true;
            this.enkReser_time.Protect = true;
            grdOCS0503.SetItemValue(insertRow, "req_doctor", mRequest_doctor);
            grdOCS0503.SetItemValue(insertRow, "req_doctor_name", mRequest_doctor_name);
            dbxReq_doctor_name.SetDataValue(mRequest_doctor_name);
            grdOCS0503.SetItemValue(insertRow, "req_gwa", mRequest_gwa);
            grdOCS0503.SetItemValue(insertRow, "req_gwa_name", mRequest_gwa_name);
            dbxReq_gwa_name.SetDataValue(mRequest_gwa_name);
            grdOCS0503.SetItemValue(insertRow, "bunho", mBunho);
            grdOCS0503.SetItemValue(insertRow, "pkocs0503", pkocs0503);
            grdOCS0503.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
            grdOCS0503.SetItemValue(insertRow, "in_out_gubun", mIn_out_gubun);
            grdOCS0503.SetItemValue(insertRow, "confirm_yn", "N");
            //cboAmPm_gubun.SelectedIndex = 0;
            //grdOCS0503.SetItemValue(insertRow, "ampm_gubun"     , "A"          );
            grdOCS0503.SetItemValue(insertRow, "reser_time", "0000");
            grdOCS0503.SetItemValue(insertRow, "display_yn", "Y");
            fbxConsult_gwa.Focus();
            fbxConsult_gwa.SelectAll();
            txtAnswer.ReadOnly = true;
            this.SetControlbtnResOpen();
        }
        private bool IsInsertGridOCS0503()
        {
            //if (this.IsInputAvailable("2") == false) return false;
            ArrayList list = new ArrayList();
            bool isFind = false;
            foreach (XEditGridCell cell in this.grdOCS0503.CellInfos)
            {
                if (cell.IsNotNull)
                {
                    list.Add(cell.CellName);
                }
            }
            for (int i = 0; i < this.grdOCS0503.RowCount; i++)
            {
                if (this.grdOCS0503.GetRowState(i) == DataRowState.Added)
                {
                    foreach (string cellName in list)
                    {
                        if (this.grdOCS0503.GetItemString(i, cellName) == "")
                        {
                            isFind = true;
                            break;
                        }
                    }
                }
            }
            if (isFind) return false;
            return true;
        }


        #endregion


        #region [ButtonList]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    if (UserInfo.UserGubun != UserType.Doctor)
                    {
                        XMessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F003"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                        InsertRow_grdOCS0503();
                    else
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    break;
                case FunctionType.Update:
                    if (!this.JinryoDatacheck())
                    {
                        return;
                    }

                    //                    if (!grdOCS0503.SaveLayout())
                    bool returnBool = OCS0503U00SaveLayout();

                    if (!returnBool)
                    {
                        if (Service.ErrFullMsg != "")
                        {
                            XMessageBox.Show(Service.ErrFullMsg, Resources.OCS0503U00_ltb, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        this.xButtonList1.PerformClick(FunctionType.Query);
                        this.grdOCS0503.ResetUpdate();
                        return;
                    }
                    else
                    {
                        SaveEnd();
                    }
                    this.SaveAfterMSG(true);
                    this.grdOCS0503.ResetUpdate();
                    this.xButtonList1.PerformClick(FunctionType.Close);
                    // 다른 화면에서 오픈된경우는 자동 닫기.
                    //this.ScreenCloseProcess(FunctionType.Update);
                    //if (this.Opener is XScreen &&
                    //    this.OpenParam != null)
                    //{
                    //    XScreen screen = (XScreen)this.Opener;
                    //    if (screen.Name == "RES1001U00")
                    //    {
                    //        this.RES1001U00_Open("");
                    //    }
                    //    this.xButtonList1.PerformClick(FunctionType.Close);
                    //}
                    break;
                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    string GetMsg = "";
                    if (this.grdOCS0503.CurrentRowNumber >= 0)
                    {
                        DialogResult result = DialogResult.Yes;
                        if ((grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "confirm_yn") == "Y") ||
                            (grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "answer_end_yn") == "Y"))
                        {
                            XMessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F003"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_doctor") != UserInfo.DoctorID)
                        {
                            if (UserInfo.DoctorID == "")
                            {
                                GetMsg = XMsg.GetMsg("M011");
                            }
                            else
                            {
                                GetMsg = XMsg.GetMsg("M005");
                            }
                            result = XMessageBox.Show(GetMsg, XMsg.GetField("F003"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            //result = XMessageBox.Show("他の先生の依頼ですが、削除しますか？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        }
                        if (result == DialogResult.Yes)
                        {
                            grdOCS0503.DeleteRow(grdOCS0503.CurrentRowNumber);
                        }
                    }
                    if (grdOCS0503.RowCount == 0)
                    {
                        this.pnlOCS2016U00.Enabled = false;
                    }
                    SetControlProtect(ref grdOCS0503, ref this.htOCS0503);
                    break;

                case FunctionType.Close:
                    ScreenCloseProcess(e.Func);
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void SaveEnd()
        {
            string MsgSysMSG = "";
            string MsgTitle = "";
            for (int i = 0; i < grdOCS0503.RowCount; i++)
            {
                if (cbxMsgSysYN.Checked == true)
                {

                    if (grdOCS0503.GetItemString(i, "answer_end_yn") != "Y")
                    {
                        MsgSysMSG += "依頼医 : " + UserInfo.UserName + "\r\n";
                        MsgTitle += "[診療依頼]";
                        if (MsgSysMSG != "")
                        {
                            string receiveId = "";
                            if (!TypeCheck.IsNull(grdOCS0503.GetItemString(i, "consult_doctor_name")))
                            {
                                receiveId = grdOCS0503.GetItemString(i, "consult_doctor_name").Substring(0, 2);
                            }
                            // B=Beopo, G=BUSEO U=USER
                            SendMessageSystem(MsgTitle + "新しい診療依頼が届きました。"
                                , "依頼元 : " + UserInfo.UserName
                                ,
                                "依頼先 : " +
                                grdOCS0503.GetItemString(i, "consult_doctor_name")
                                , "患者名 : " + pbxRequest_bunho.SuName
                                , ""
                                , ""
                                , MsgSysMSG
                                , UserInfo.UserID
                                , "U"
                                //, item.BindVarList["f_consult_doctor"].VarValue.Substring(2)
                                , receiveId
                                , ""
                                );
                        }
                    }
                }
            }

        }

        private void ScreenCloseProcess(FunctionType functype)
        {
            if (this.Opener is XScreen && this.OpenParam != null)
            {
                CommonItemCollection param = new CommonItemCollection();
                XScreen screen = (XScreen)this.Opener;
                param.Add("OCS0503U00", true);
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
        /// 의뢰내역 상용어 조회
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

        #region [사용자상병조회]
        private void btnSang_code1_Click(object sender, System.EventArgs e)
        {
            ActiveFincBox = this.fbxSang_code1;
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("sang_code", "");
            openParams.Add("memb", IHIS.Framework.UserInfo.UserID);
            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }
        private void btnSang_code2_Click(object sender, System.EventArgs e)
        {
            ActiveFincBox = this.fbxSang_code2;
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("sang_code", "");
            openParams.Add("memb", IHIS.Framework.UserInfo.UserID);
            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }
        private void btnSang_code3_Click(object sender, System.EventArgs e)
        {
            ActiveFincBox = this.fbxSang_code3;
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("sang_code", "");
            openParams.Add("memb", IHIS.Framework.UserInfo.UserID);
            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }
        #endregion

        #region [진료예약표 출력]
        private void PrintJinryoReser()
        {
            if (this.layOrderInfo.RowCount < 0)
                return;

            for (int i = 0; i < this.layOrderInfo.RowCount; i++)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("auto_close", "Y");
                openParams.Add("bunho", layOrderInfo.GetItemString(i, "bunho"));
                openParams.Add("reser_date", layOrderInfo.GetItemString(i, "jinryo_pre_date"));
                XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseFixed, openParams);
            }
        }
        #endregion
        #region [진료예약표 출력]
        private bool JinryoDatacheck()
        {

            string mbxMsg = "";

            this.layOrderInfo.Reset();

            for (int i = 0; i < this.grdOCS0503.RowCount; i++)
            {
                if (grdOCS0503.GetRowState(i) == DataRowState.Added || grdOCS0503.GetRowState(i) == DataRowState.Modified)
                {
                    if ((grdOCS0503.GetItemValue(i, "consult_gwa").ToString() == ""))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が設定されておりません。ご確認ください。" :
                                                                   Resources.OCS0503U00_cdcd_xnl;
                        XMessageBox.Show(mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.fbxConsult_gwa.Focus();
                        return false;
                    }
                    if ((grdOCS0503.GetItemValue(i, "consult_doctor").ToString() == ""))
                    {
                        mbxMsg = "診療医が設定されておりません。ご確認ください。";
                        ;
                        XMessageBox.Show(mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.fbxConsult_doctor.Focus();
                        return false;
                    }
                    if ((grdOCS0503.GetItemValue(i, "jinryo_pre_date").ToString() == ""))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "診療依頼日付が設定されておりません。ご確認ください。" :
                                                                    Resources.OCS0503U00_nyck;
                        XMessageBox.Show(mbxMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.dpkJinryo_pre_date.Focus();
                        return false;
                    }
                    if (int.Parse(grdOCS0503.GetItemValue(i, "jinryo_pre_date").ToString().Replace("/", "")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                    {
                        string print_yn = grdOCS0503.GetItemValue(i, "print_yn").ToString();

                        if (((grdOCS0503.GetItemValue(i, "reser_time").ToString() == "") || (grdOCS0503.GetItemValue(i, "reser_time").ToString() == "0000")
                            && this.mIn_out_gubun == "O"
                            ))
                        {
                            XMessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F003"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        if (print_yn != "Y")
                        {
                            mbxMsg = Resources.OCS0503U00_inhk;
                            mbxCap = Resources.OCS0503U00_ibhk;
                            DialogResult dialogResult = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.Yes)
                                print_yn = "Y";
                            else
                                print_yn = "N";
                        }
                        grdOCS0503.SetItemValue(i, "print_yn", print_yn);
                        if (print_yn == "Y")
                        {
                            this.layOrderInfo.LayoutTable.ImportRow(this.grdOCS0503.LayoutTable.Rows[i]);
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region [DataService Event]

        private void grdOCS0503_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            if (grdOCS0503.RowCount == 0)
            {
                pnlOCS2016U00.Enabled = false;
                lblAmPm_gubun.Visible = true;
                //cboAmPm_gubun.Visible = true;
                InsertRow_grdOCS0503();
            }

            //XMessageBox.Show(grdOCS0503.GetItemString(0, "req_remark").Length.ToString());
        }

        private void grdOCS0503_SaveStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AcceptData();
            string public_doctor = "";
            string public_doctor_name = "";

            //grdOCS0503
            for (int rowIndex = 0; rowIndex < grdOCS0503.RowCount; rowIndex++)
            {
                if (grdOCS0503.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_gwa").Trim()) && TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "req_remark").Trim()))
                    {
                        grdOCS0503.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                    else if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_gwa").Trim()))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "施行科の入力が間違っています。ご確認ください。" : Resources.OCS0503U00_msg2066;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        grdOCS0503.SetFocusToItem(rowIndex, 0);
                        fbxConsult_gwa.Focus();
                        fbxConsult_gwa.SelectAll();
                        e.Cancel = true;
                        break;

                        //grdOCS0503.DeleteRow(rowIndex);
                        //rowIndex = rowIndex - 1;						
                    }

                    if (TypeCheck.IsNull(grdOCS0503.GetItemString(rowIndex, "consult_doctor").Trim()))
                    {
                        public_doctor = "D" + grdOCS0503.GetItemString(rowIndex, "consult_gwa").Substring(1, 1) + "999";
                        public_doctor_name = this.GetCodeName("doctor_name", public_doctor);

                        if (!TypeCheck.IsNull(public_doctor_name))
                        {
                            //의뢰의사가 없는 경우에는 공통의사를 넣어준다.
                            grdOCS0503.SetItemValue(rowIndex, "consult_doctor", public_doctor);
                            grdOCS0503.SetItemValue(rowIndex, "consult_doctor_name", public_doctor_name);
                        }
                    }
                }
            }
        }

        private void grdOCS0503_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {

            //this.PrintJinryoReser();
            //isgrdOCS0503Save = e.IsSuccess;
            //isSavedOCS0503 = true;

            //if (isSavedOCS0503)
            //{
            //    if (isgrdOCS0503Save)
            //    {
            //        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
            //        mbxCap = NetInfo.Language == LangMode.Jr ? "保存" : "저장";
            //        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

            //        //int currentRow = grdOCS0503.CurrentRowNumber;

            //        grdOCS0503.QueryLayout(false);

            //        PostCallHelper.PostCall(new PostMethod(PrintJinryoReser));

            //        //						if(grdOCS0503.RowCount >= currentRow)
            //        //							grdOCS0503.SetFocusToItem(currentRow, 0);
            //    }
            //    else
            //    {
            //        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다.";
            //        mbxMsg = mbxMsg + e.ErrMsg;
            //        mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
            //        XMessageBox.Show(mbxMsg, mbxCap);
            //    }

            //    isgrdOCS0503Save = false;
            //    isSavedOCS0503 = false;
            //}
        }

        #endregion

        #region btn Event
        private void btnOutsang_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mRequest_gwa);
            openParams.Add("io_gubun", mIn_out_gubun);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void btnSangCode_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("multiSelect", true);
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void btnUserSangCode_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("sang_code", "");
            openParams.Add("memb", UserInfo.UserID);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }
        #endregion

        #region [환자상병 Load]


        #endregion

        //delete by jc [依頼指示書出力未使用] 20120830
        //#region [의뢰지시서출력]

        //private void PrintRequest()
        //{
        //    if (grdOCS0503.CurrentRowNumber < 0 || grdOCS0503.GetRowState(grdOCS0503.CurrentRowNumber) == DataRowState.Added) return;

        //    string origin_print = IHIS.Framework.PrintHelper.GetDefaultPrinterName();
        //    string print_name = "";

        //    foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
        //    {
        //        if (s == "SATO")
        //        {
        //            print_name = "SATO";
        //            break;
        //        }
        //        else
        //        {
        //            if (s.IndexOf("SATO") >= 0)
        //                print_name = s;
        //        }
        //    }

        //    if (print_name.IndexOf("SATO") < 0)
        //    {
        //        MessageBox.Show("ラベルプリンタの設定がされていません。");
        //        return;
        //    }

        //    try
        //    {
        //        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계

        //        dloPrintInfo.Reset();
        //        int insertRow = dloPrintInfo.InsertRow(-1);
        //        dloPrintInfo.SetItemValue(insertRow, "bunho", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "bunho"));
        //        dloPrintInfo.SetItemValue(insertRow, "suname", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "suname"));
        //        dloPrintInfo.SetItemValue(insertRow, "req_date", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_date"));
        //        dloPrintInfo.SetItemValue(insertRow, "req_gwa_name", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_gwa_name"));
        //        dloPrintInfo.SetItemValue(insertRow, "req_doctor_name", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "req_doctor_name"));
        //        dloPrintInfo.SetItemValue(insertRow, "consult_gwa_name", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "consult_gwa_name"));
        //        dloPrintInfo.SetItemValue(insertRow, "consult_doctor_name", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "consult_doctor_name"));
        //        dloPrintInfo.SetItemValue(insertRow, "jinryo_pre_date", this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "jinryo_pre_date"));

        //        string header = "";
        //        if (this.grdOCS0503.GetItemString(grdOCS0503.CurrentRowNumber, "in_out_gubun") == "O")
        //            header = "【診療依頼-外来】";
        //        else
        //            header = "【診療依頼-入院】";

        //        dloPrintInfo.SetItemValue(insertRow, "header", header);

        //        dwPrint.PrintProperties.PrinterName = print_name;
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



        private void fbxConsult_gwa_TextChanged(object sender, EventArgs e)
        {

            //this.fbxConsult_doctor.ResetText();
            //this.fbxConsult_doctor.Clear();
            //this.dbxConsult_doctor_name.ResetText();
            ////this.dpkJinryo_pre_date.SetDataValue(EnvironInfo.GetSysDate());
            //SetControlProtect(ref grdOCS0503, ref this.htOCS0503);
            //this.dpkJinryo_pre_date.Protect = true;
            //this.enkReser_time.Protect = true;

            //if (this.fbxConsult_gwa.GetDataValue().ToString() != "")
            //{
            //    this.fbxConsult_doctor.Protect = false;
            //    //this.dpkJinryo_pre_date.Protect = false;
            //    //this.ibtPre_date_clear.Enabled = true;
            //    //this.dbxConsult_doctor_name.Visible = true;
            //}
            //else
            //{
            //    this.fbxConsult_doctor.Protect = true;
            //    //this.dpkJinryo_pre_date.Protect = true;
            //    //this.ibtPre_date_clear.Enabled = false;
            //    this.dbxConsult_gwa_name.Text = "";

            //    //this.dbxConsult_doctor_name.Visible = false;
            //}

        }
        private void layNaewonChk_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNaewonChk.SetBindVarValue("f_hosp_code", mHospCode);
            this.layNaewonChk.SetBindVarValue("f_naewon_key", mNaewon_key);
        }
        private void cboAmPm_gubun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //txtReser_time.SetDataValue(cboAmPm_gubun.GetDataValue().ToString());
        }
        private void dpkJinryo_pre_date_DataValidating(object sender, DataValidatingEventArgs e)
        {

            this.SetControlbtnResOpen();

            //if (TypeCheck.IsDateTime(dpkJinryo_pre_date.GetDataValue()))
            //{
            //    if (int.Parse(DateTime.Parse(dpkJinryo_pre_date.GetDataValue()).ToString("yyyyMMdd")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            //    {
            //        this.CreateTimeCombo(fbxConsult_doctor.GetDataValue().ToString(), e.DataValue, false);//true:全体、false:予約可能時間のみ
            //        //this.txtReser_time.SetDataValue(cboAmPm_gubun.GetDataValue().ToString());
            //    }
            //    else if (int.Parse(DateTime.Parse(dpkJinryo_pre_date.GetDataValue()).ToString("yyyyMMdd")) == int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            //    {    //this.txtReser_time.SetDataValue("0000");
            //    }
            //    else
            //    {
            //        //e.Cancel = true;
            //        //PostCallHelper.PostCall(test);

            //    }
            //}

            //if (TypeCheck.IsDateTime(dpkJinryo_pre_date.GetDataValue()))
            //{
            //    this.grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "jinryo_pre_date", this.dpkJinryo_pre_date.GetDataValue());

            //}
        }
        private void SetControlbtnResOpen()
        {
            //if ((DateTime.Parse(dpkJinryo_pre_date.GetDataValue()) > EnvironInfo.GetSysDate())
            //    && this.fbxConsult_doctor.GetDataValue()!="" 
            //    && this.mIn_out_gubun == "O")
            //{
            //    this.btnResOpen.Visible = true;
            //}
            //else
            //{
            //    this.btnResOpen.Visible = false;
            //}
        }

        private void txtReser_time_TextChanged(object sender, EventArgs e)
        {
            //grdOCS0503.SetItemValue(grdOCS0503.CurrentRowNumber, "reser_time", txtReser_time.GetDataValue().ToString());
        }
        private void fbxConsult_doctor_FindSelected(object sender, FindEventArgs e)
        {
            ////insert by jc 医師を選択した場合、日付が当日であれば、予約時間を作らないように。
            ////if (int.Parse(aJinryo_pre_date.ToString().Replace("/", "")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))

            //if (TypeCheck.IsDateTime(dpkJinryo_pre_date.GetDataValue()))
            //{
            //    if (int.Parse(DateTime.Parse(dpkJinryo_pre_date.GetDataValue()).ToString("yyyyMMdd")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            //    {

            //        this.CreateTimeCombo(fbxConsult_doctor.GetDataValue().ToString(), dpkJinryo_pre_date.GetDataValue().ToString(), false);
            //        this.txtReser_time.SetDataValue(cboAmPm_gubun.GetDataValue().ToString());
            //        //if (int.Parse(DateTime.Parse(dpkJinryo_pre_date.GetDataValue()).ToString("yyyyMMdd")) > int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
            //        //{
            //        //  this.txtReser_time.SetDataValue(cboAmPm_gubun.GetDataValue().ToString());
            //        //}
            //    }
            //}
        }

        private void fbxConsult_gwa_FindSelected(object sender, FindEventArgs e)
        {
            //this.fbxConsult_doctor.ResetText();
        }

        private void cboAmPm_gubun_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //cboAmPm_gubun.Enabled = fbxConsult_gwa.Enabled;
        }

        private void btnResOpen_Click(object sender, EventArgs e)
        {
            this.RES1001U00_Open("OCS0503U00");
        }

        private void RES1001U00_Open(string caller_name)
        {
            IHIS.Framework.IXScreen aScreen;
            aScreen = XScreen.FindScreen("NURO", "RES1001U00");

            if (aScreen == null)
            {
                CommonItemCollection openParams;

                openParams = new CommonItemCollection();
                openParams.Add("gwa", fbxConsult_gwa.GetDataValue());
                openParams.Add("doctor", this.fbxConsult_doctor.GetDataValue());
                openParams.Add("bunho", mBunho);
                openParams.Add("naewon_date", this.dpkJinryo_pre_date.GetDataValue());
                openParams.Add("caller_name", caller_name);
                if (caller_name == "")
                {
                    aScreen = XScreen.OpenScreenWithParam(this, "NURO", "RES1001U00", ScreenOpenStyle.PopUpFixed, openParams);

                }
                else
                {
                    aScreen = XScreen.OpenScreenWithParam(this, "NURO", "RES1001U00", ScreenOpenStyle.ResponseFixed, openParams);

                }
                aScreen.Activate();
            }
            else
            {
                aScreen.Activate();
            }
        }

        #region DzungTA modify
        private void BindExecuteQueryMethod()
        {
            grdOCS0503.ParamList = new List<string>(new String[] { "f_bunho", "f_req_doctor" });
            grdOCS0503.ExecuteQuery = QueryGrdOCS0503;
            layNaewonChk.ParamList = new List<string>(new String[] { "f_reser_date", "f_reser_doctor", "f_reser_time" });
            layNaewonChk.ExecuteQuery = QueryLayNaewonChk;
            layReserCanYN.ParamList = new List<string>(new String[] { "f_reser_date", "f_reser_doctor", "f_reser_time" });
            layReserCanYN.ExecuteQuery = QueryLayReserCanYN;
        }

        OCS0503U00CommonArgs commonArgs = new OCS0503U00CommonArgs();

        private List<object[]> QueryLayReserCanYN(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            if (commonArgs.NaewonKey == null || commonArgs.NaewonKey != mNaewon_key
                || commonArgs.ReserDate == null || commonArgs.ReserDate != bc["f_reser_date"].VarValue
                || commonArgs.ReserDoctor == null || commonArgs.ReserDoctor != bc["f_reser_doctor"].VarValue
                || commonArgs.ReserTime == null || commonArgs.ReserTime != bc["f_reser_time"].VarValue)
            {
                commonArgs.NaewonKey = mNaewon_key;
                commonArgs.ReserDate = bc["f_reser_date"].VarValue;
                commonArgs.ReserDoctor = bc["f_reser_doctor"].VarValue;
                commonArgs.ReserTime = bc["f_reser_time"].VarValue;
            }

            OCS0503U00CommonResult result =
                CloudService.Instance.Submit<OCS0503U00CommonResult, OCS0503U00CommonArgs>(commonArgs);

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                object[] objects =
	            {
	                result.ReserYn
	            };
                res.Add(objects);
            }

            // Self caching/Updating cache for later function call
            //Cache.Insert("NaewonKey", args.NaewonKey);
            //Cache.Insert("ReserDate", args.ReserDate);
            //Cache.Insert("ReserDoctor", args.ReserDoctor);
            //Cache.Insert("ReserTime", args.ReserTime);

            return res;
        }

        private List<object[]> QueryLayNaewonChk(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            if (commonArgs.NaewonKey == null || commonArgs.NaewonKey != mNaewon_key
                || commonArgs.ReserDate == null || commonArgs.ReserDate != bc["f_reser_date"].VarValue
                || commonArgs.ReserDoctor == null || commonArgs.ReserDoctor != bc["f_reser_doctor"].VarValue
                || commonArgs.ReserTime == null || commonArgs.ReserTime != bc["f_reser_time"].VarValue)
            {
                commonArgs.NaewonKey = mNaewon_key;
                commonArgs.ReserDate = bc["f_reser_date"].VarValue;
                commonArgs.ReserDoctor = bc["f_reser_doctor"].VarValue;
                commonArgs.ReserTime = bc["f_reser_time"].VarValue;
            }

            OCS0503U00CommonResult result =
                CloudService.Instance.Submit<OCS0503U00CommonResult, OCS0503U00CommonArgs>(commonArgs);

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.NaewonYn)
                {
                    object[] objects =
	                {
	                    item.DataValue
	                };
                    res.Add(objects);
                }
            }

            // Self caching/Updating cache for later function call
            //Cache.Insert("NaewonKey", args.NaewonKey);
            //Cache.Insert("ReserDate", args.ReserDate);
            //Cache.Insert("ReserDoctor", args.ReserDoctor);
            //Cache.Insert("ReserTime", args.ReserTime);


            return res;
        }

        private List<object[]> QueryGrdOCS0503(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            OCS0503U00gridOSC0503ListArgs args = new OCS0503U00gridOSC0503ListArgs();
            args.Bunho = bc["f_bunho"].VarValue;
            args.ReqDoctor = bc["f_req_doctor"].VarValue;
            OCS0503U00gridOSC0503ListResult result = CloudService.Instance.Submit<OCS0503U00gridOSC0503ListResult, OCS0503U00gridOSC0503ListArgs>(args); //tu caching vao memory

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OCS0503U00gridOSC0503ListInfo item in result.GridOSC0503)
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
                        item.ReserTime,
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

            return res;
        }

        /// <summary>
        /// OCS0503U00SaveLayout
        /// </summary>
        /// <returns></returns>
        private bool OCS0503U00SaveLayout()
        {
            OCS0503U00SaveLayoutArgs args = new OCS0503U00SaveLayoutArgs();
            args.GrdOcs0503Item = CreateListGrdOCS0503Info();
            args.UserId = UserInfo.UserID;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OCS0503U00SaveLayoutArgs>(args);
            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// CreateListGrdOCS0503Info
        /// </summary>
        /// <returns></returns>
        private List<OCS0503U00gridOSC0503ListInfo> CreateListGrdOCS0503Info()
        {
            List<OCS0503U00gridOSC0503ListInfo> listGrdGridOsc0503ListInfo = new List<OCS0503U00gridOSC0503ListInfo>();
            for (int i = 0; i < grdOCS0503.RowCount; i++)
            {
                if (grdOCS0503.GetRowState(i) == DataRowState.Added ||
                    grdOCS0503.GetRowState(i) == DataRowState.Modified)
                {
                    OCS0503U00gridOSC0503ListInfo info = new OCS0503U00gridOSC0503ListInfo();
                    info.Bunho = grdOCS0503.GetItemString(i, "bunho");
                    info.ReqDate = grdOCS0503.GetItemString(i, "req_date");
                    info.ReqGwa = grdOCS0503.GetItemString(i, "req_gwa");
                    info.ReqDoctor = grdOCS0503.GetItemString(i, "req_doctor");
                    info.Pkocs0503 = grdOCS0503.GetItemString(i, "pkocs0503");
                    info.ConsultGwa = grdOCS0503.GetItemString(i, "consult_gwa");
                    info.ConsultDoctor = grdOCS0503.GetItemString(i, "consult_doctor");
                    info.WangjinYn = grdOCS0503.GetItemString(i, "wangjin_yn");
                    info.SangCode1 = grdOCS0503.GetItemString(i, "sang_code1");
                    info.SangName1 = grdOCS0503.GetItemString(i, "sang_name1");
                    info.SangCode2 = grdOCS0503.GetItemString(i, "sang_code2");
                    info.SangName2 = grdOCS0503.GetItemString(i, "sang_name2");
                    info.SangCode3 = grdOCS0503.GetItemString(i, "sang_code3");
                    info.SangName3 = grdOCS0503.GetItemString(i, "sang_name3");
                    info.ConsultSangName = grdOCS0503.GetItemString(i, "consult_sang_name");
                    info.ReqRemark = grdOCS0503.GetItemString(i, "req_remark");
                    info.AppDate = grdOCS0503.GetItemString(i, "app_date");
                    info.Answer = grdOCS0503.GetItemString(i, "answer");
                    info.InOutGubun = grdOCS0503.GetItemString(i, "in_out_gubun");
                    info.ConsultFkout1001 = grdOCS0503.GetItemString(i, "fkout1001");
                    info.Fkinp1001 = grdOCS0503.GetItemString(i, "fkinp1001");
                    info.PrintYn = grdOCS0503.GetItemString(i, "print_yn");
                    info.EmerGubun = grdOCS0503.GetItemString(i, "emer_gubun");
                    info.RealJinryoDate = grdOCS0503.GetItemString(i, "real_jinryo_date");
                    info.ResultArriveDate = grdOCS0503.GetItemString(i, "result_arrive_date");
                    info.ConfirmYn = grdOCS0503.GetItemString(i, "confirm_yn");
                    info.AnswerEndYn = grdOCS0503.GetItemString(i, "answer_end_yn");
                    info.JinryoPreDate = grdOCS0503.GetItemString(i, "jinryo_pre_date");
                    info.ReserTime = grdOCS0503.GetItemString(i, "reser_time");
                    info.ReqEndYn = grdOCS0503.GetItemString(i, "req_end_yn");
                    info.DisplayYn = grdOCS0503.GetItemString(i, "display_yn");
                    info.Suname = grdOCS0503.GetItemString(i, "suname");
                    info.Sex = grdOCS0503.GetItemString(i, "sex");
                    info.Age = grdOCS0503.GetItemString(i, "age");
                    info.ConsultGwaName = grdOCS0503.GetItemString(i, "consult_gwa_name");
                    info.ConsultDoctorName = grdOCS0503.GetItemString(i, "consult_doctor_name");
                    info.ReqGwaName = grdOCS0503.GetItemString(i, "req_gwa_name");
                    info.ReqDoctorName = grdOCS0503.GetItemString(i, "req_doctor_name");
                    info.OldAnswerEndYn = grdOCS0503.GetItemString(i, "old_answer_end_yn");

                    info.RowState = grdOCS0503.GetRowState(i).ToString();

                    listGrdGridOsc0503ListInfo.Add(info);
                }
            }
            if (grdOCS0503.DeletedRowTable != null && grdOCS0503.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdOCS0503.DeletedRowTable.Rows)
                {
                    OCS0503U00gridOSC0503ListInfo info = new OCS0503U00gridOSC0503ListInfo();
                    info.Pkocs0503 = row["pkocs0503"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();
                    listGrdGridOsc0503ListInfo.Add(info);
                }

            }
            return listGrdGridOsc0503ListInfo;
        }

        private XFindWorker GetFindWorker2(string findMode, string ref_code)
        {
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
            string naewon_date =
                        TypeCheck.NVL(dpkJinryo_pre_date.GetDataValue(), EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"))
                            .ToString();

            fdwCommon.ParamList = new List<string>(new string[]
                {
                    "f_find_mode",
                    "f_in_out_gubun",
                    "f_naewon_date",
                    "f_ref_code",
                });

            switch (findMode)
            {
                case "consult_gwa":
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;
                    fdwCommon.ColInfos.Add("hangmog_code", Resources.OCS0503U00_mkk, FindColType.String, 100, 0, true,
                        FilterType.Yes);
                    fdwCommon.ColInfos.Add("hangmog_name", Resources.OCS0503U00_tkk, FindColType.String, 300, 0, true,
                        FilterType.Yes);
                    break;

                case "consult_doctor":
                    this.dpkJinryo_pre_date.SetDataValue(naewon_date);
                    fdwCommon.AutoQuery = true;
                    fdwCommon.ServerFilter = false;

                    if (int.Parse(naewon_date.Replace("/", "").Replace("-", "")) <
                        int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd").Trim()))
                    {
                        XMessageBox.Show(Resources.OCS0503U00_qkk, Resources.OCS0503U00_ly, MessageBoxIcon.Warning);
                        return null;
                    }

                    fdwCommon.FormText = Resources.OCS0503U00_tcbsk;
                    fdwCommon.ColInfos.Add("doctor", Resources.OCS0503U00_mbsk, FindColType.String, 100, 0, true,
                        FilterType.Yes);
                    fdwCommon.ColInfos.Add("doctor_name", Resources.OCS0503U00_tbsk, FindColType.String, 200, 0, true,
                        FilterType.Yes);
                    fdwCommon.ColInfos.Add("AMPM", Resources.OCS0503U00_ampm, FindColType.String, 200, 0, true,
                        FilterType.Yes);
                    break;
                default:
                    break;
            }

            fdwCommon.SetBindVarValue("f_find_mode", findMode);
            fdwCommon.SetBindVarValue("f_in_out_gubun", mIn_out_gubun);
            fdwCommon.SetBindVarValue("f_naewon_date", naewon_date);
            fdwCommon.SetBindVarValue("f_ref_code", ref_code);
            fdwCommon.ExecuteQuery = QueryFdwCommon;

            return fdwCommon;
        }

        private IList<object[]> QueryFdwCommon(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();

            OCS0503U00GetFindWorkerArgs args = new OCS0503U00GetFindWorkerArgs();
            args.FindMode = bc["f_find_mode"].VarValue;
            args.MInOutGubun = bc["f_in_out_gubun"].VarValue;
            args.NaewonDate = bc["f_naewon_date"].VarValue;
            args.RefCode = bc["f_ref_code"].VarValue;

            OCS0503U00GetFindWorkerResult result =
                CloudService.Instance.Submit<OCS0503U00GetFindWorkerResult, OCS0503U00GetFindWorkerArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (bc["f_find_mode"].VarValue == "consult_gwa")
                {
                    result.FindWorker.ForEach(delegate(OCS0503U00GetFindWorkerConsultGwaInfo item)
                    {
                        res.Add(new object[]
                        {
                            item.HangmogCode,
                            item.HangmogName,
                        });
                    });
                }
                else
                {
                    result.FindWorker.ForEach(delegate(OCS0503U00GetFindWorkerConsultGwaInfo item)
                    {
                        res.Add(new object[]
                        {
                            item.Doctor,
                            item.DoctorName,
                            item.Ampm,
                        });
                    });
                }
            }
            return res;
        }

        private void CheckInpPatient2(string bunho)
        {
            mIn_out_gubun = "O";
            mFkinp1001 = 0;

            OCS0503U00CheckInpPatientArgs args = new OCS0503U00CheckInpPatientArgs();
            args.Bunho = bunho;
            OCS0503U00CheckInpPatientResult result =
                CloudService.Instance.Submit<OCS0503U00CheckInpPatientResult, OCS0503U00CheckInpPatientArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && !string.IsNullOrEmpty(result.Pkinp1001))
            {
                mIn_out_gubun = "I";
                mFkinp1001 = int.Parse(result.Pkinp1001);
            }
        }

        private int GetPKOCS0503_2()
        {
            if (commonArgs.NaewonKey == null || commonArgs.NaewonKey != mNaewon_key
                || commonArgs.ReserDate == null || commonArgs.ReserDate != dpkJinryo_pre_date.GetDataValue().ToString()
                || commonArgs.ReserDoctor == null || commonArgs.ReserDoctor != fbxConsult_doctor.GetDataValue().ToString()
                || commonArgs.ReserTime == null || commonArgs.ReserTime != this.enkReser_time.GetDataValue())
            {
                commonArgs.NaewonKey = mNaewon_key;
                commonArgs.ReserDate = dpkJinryo_pre_date.GetDataValue().ToString();
                commonArgs.ReserDoctor = fbxConsult_doctor.GetDataValue().ToString();
                commonArgs.ReserTime = this.enkReser_time.GetDataValue();
            }

            OCS0503U00CommonResult result =
                CloudService.Instance.Submit<OCS0503U00CommonResult, OCS0503U00CommonArgs>(commonArgs);

            if (result == null || result.ExecutionStatus != ExecutionStatus.Success)
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "データエラー発生の恐れがあります。" : Resources.OCS0503U00_lndl;
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap);
            }
            else
            {
                if (!String.IsNullOrEmpty(result.Seq))
                    return int.Parse(result.Seq);
            }

            return 0;
        }

        private string LoadOutSang2(string aBunho, string aGwa)
        {
            string returnValue = "";

            IHIS.Framework.MultiLayout layoutSang;
            layoutSang = new MultiLayout();

            //처방구분 DataLayout;
            layoutSang.Reset();
            layoutSang.LayoutItems.Clear();
            layoutSang.LayoutItems.Add("sang_name", DataType.String);
            layoutSang.InitializeLayoutTable();
            layoutSang.SetBindVarValue("f_bunho", aBunho);
            layoutSang.SetBindVarValue("f_gwa", aGwa);
            layoutSang.SetBindVarValue("f_io_gubun", mIn_out_gubun);
            layoutSang.SetBindVarValue("f_hosp_code", mHospCode);
            layoutSang.ExecuteQuery = QueryLayoutSang;

            if (!layoutSang.QueryLayout(false)) XMessageBox.Show(Service.ErrFullMsg);

            if (layoutSang.LayoutTable != null)
            {
                for (int i = 0; i < layoutSang.LayoutTable.Rows.Count; i++)
                {
                    returnValue = returnValue + layoutSang.LayoutTable.Rows[i]["sang_name"].ToString() + "\r\n";
                }
            }

            return returnValue;
        }

        private List<object[]> QueryLayoutSang(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            OCS0503U00LoadOutSangArgs args = new OCS0503U00LoadOutSangArgs();
            args.Bunho = bc["f_bunho"].VarValue;
            args.Gwa = bc["f_gwa"].VarValue;
            args.IoGubun = bc["f_io_gubun"].VarValue;
            OCS0503U00LoadOutSangResult result = CloudService.Instance.Submit<OCS0503U00LoadOutSangResult, OCS0503U00LoadOutSangArgs>(args); //tu caching vao memory

            if (result != null)
            {
                foreach (string item in result.SangName)
                {
                    object[] objects =
                    {
                        item
                    };
                    res.Add(objects);
                }
            }

            return res;
        }

        #region Internal caching
        private static HttpRuntime _httpRuntime;

        public static Cache Cache
        {
            get
            {
                EnsureHttpRuntime();
                return HttpRuntime.Cache;
            }
        }

        private static void EnsureHttpRuntime()
        {
            if (null == _httpRuntime)
            {
                try
                {
                    Monitor.Enter(typeof(string));
                    if (null == _httpRuntime)
                    {
                        // Create an Http Content to give us access to the cache.
                        _httpRuntime = new HttpRuntime();
                    }
                }
                finally
                {
                    Monitor.Exit(typeof(string));
                }
            }
        }
        #endregion

        #endregion

    }

}

