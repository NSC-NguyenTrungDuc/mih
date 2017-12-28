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
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL3020U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL3020U02 : IHIS.Framework.XScreen
    {
        #region 自動生成
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XPanel xPanel6;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XLabel xLabel10;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XLabel xLabel2;
        private System.Windows.Forms.Panel panel1;
        private IHIS.Framework.XPanel xPanel4;
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
        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XMstGrid grdPa;
        private IHIS.Framework.XCheckBox cbxGubun;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XDisplayBox dbxBunho;
        private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XDisplayBox dbxHoCode;
        private IHIS.Framework.XDisplayBox dbxHoDong;
        private IHIS.Framework.XDisplayBox dbxInOutGubun;
        private IHIS.Framework.XDisplayBox dbxTat2;
        private IHIS.Framework.XDisplayBox dbxTa2;
        private IHIS.Framework.XDisplayBox dbxTat1;
        private IHIS.Framework.XDisplayBox dbxTa1;
        private IHIS.Framework.XDisplayBox dbxGwa;
        private IHIS.Framework.XDisplayBox dbxPartJubsuTime;
        private IHIS.Framework.XDisplayBox dbxPartJunbsuDate;
        private IHIS.Framework.XDisplayBox dbxSpecimenName;
        private IHIS.Framework.XDisplayBox dbxSpecimenCode;
        private IHIS.Framework.XDisplayBox dbxSpecimenSer;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGrid grdResult;
        private IHIS.Framework.SingleLayout laySpecimenInfo;
        private IHIS.Framework.XDisplayBox dbxNote;
        private IHIS.Framework.XFindBox fbxNote;
        private IHIS.Framework.SingleLayout vsvNote;
        private IHIS.Framework.XFindWorker fwkNote;
        private IHIS.Framework.FindColumnInfo findColumnInfo3;
        private IHIS.Framework.FindColumnInfo findColumnInfo4;
        private IHIS.Framework.SingleLayout dsvNote;
        private IHIS.Framework.XFindWorker fwkResult;
        private IHIS.Framework.FindColumnInfo findColumnInfo5;
        private IHIS.Framework.FindColumnInfo findColumnInfo6;
        private IHIS.Framework.MultiLayout layNoteUpdate;
        private IHIS.Framework.XButton btnBeforeResult;
        private IHIS.Framework.XButton btnUpdateResult;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XDisplayBox dbxSex;
        private IHIS.Framework.XDisplayBox dbxAge;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XButton btnResult;
        private IHIS.Framework.XButton btnAllDp;
        private IHIS.Framework.XButton btnAllCheck;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XButton btnSigeyul;
        private IHIS.Framework.XPanel pnlSigeyul;
        private IHIS.Framework.XTabControl tabSigeyul;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
//        private IHIS.CPLS.MultiResultView multiResultView;
//        private IHIS.CPLS.GraphResultView graphResultView;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem20;
        private SingleLayoutItem singleLayoutItem21;
        private SingleLayoutItem singleLayoutItem22;
        private SingleLayoutItem singleLayoutItem23;
        private SingleLayoutItem singleLayoutItem24;
        private SingleLayoutItem singleLayoutItem25;
        private SingleLayoutItem singleLayoutItem26;
        private SingleLayoutItem singleLayoutItem28;
        private SingleLayoutItem singleLayoutItem30;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private SingleLayoutItem singleLayoutItem31;
        private XTextBox txtNote;
        private XLabel xLabel4;
        private XLabel xLabel1;
        private SingleLayoutItem singleLayoutItem32;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private SingleLayoutItem singleLayoutItem33;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private XEditGrid grdNoteUpdate;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private SingleLayout layCommon;
        private XDictComboBox cbxActor;
        private XLabel xLabel5;
        private XDictComboBox cbxJangbiCode;
        private SingleLayout vsvJubsuja;
        private SingleLayoutItem singleLayoutItem27;
        #endregion
        private XButton btnEquipResult;
        private XButton btnOutResult;
        private XCheckBox cbxAutoConfirm;
        private XEditGridCell xEditGridCell43;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private CPL3020U00GrdPaRowFocusChangedResult vCPL3020U00GrdPaRowFocusChangedResult;

        public CPL3020U02()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //MED-12912
            if (SystemInformation.VirtualScreen.Width == 1366 && SystemInformation.VirtualScreen.Height == 768)
            {
                this.Height -= 180;
            }

            // Set ExecuteQuery and ParamList
            this.cbxActor.ExecuteQuery = ExecuteQueryFwkActor;
            this.cbxActor.SetDictDDLB();

            this.fwkNote.ParamList = new List<string>(new String[] { "f_jundal_gubun" });
            this.fwkNote.ExecuteQuery = ExecuteQueryFwkNote;

            this.vsvNote.ParamList = new List<string>(new String[] { "f_jundal_gubun", "f_code" });
            this.vsvNote.ExecuteQuery = ExecuteQueryVsvNote;

            this.cbxJangbiCode.ExecuteQuery = ExecuteQueryCbxJangbi;
            this.cbxJangbiCode.SetDictDDLB();

            this.grdPa.ParamList = new List<string>(new String[] { "f_from_date", "f_to_date", "f_jangbi_code" });
            this.grdPa.ExecuteQuery = ExecuteQueryGrdPa;

            this.grdResult.ParamList = new List<string>(new String[] { "f_lab_no", "f_specimen_ser", "f_jundal_gubun" });
            this.grdResult.ExecuteQuery = ExecuteQueryGrdResult;

            this.fwkResult.ParamList = new List<string>(new String[] { "f_code_type", "f_dummy", "f_result_form" });
            this.fwkResult.ExecuteQuery = ExecuteQueryFwkResult;

            // https://sofiamedix.atlassian.net/browse/MED-12767
            this.fwkResult.FormText = Resources.fwkResultFormText;
            this.fwkNote.FormText = Resources.fwkNoteFormText;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL3020U02));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdResult = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.fwkResult = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.pnlSigeyul = new IHIS.Framework.XPanel();
            this.tabSigeyul = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.txtNote = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fbxNote = new IHIS.Framework.XFindBox();
            this.fwkNote = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dbxNote = new IHIS.Framework.XDisplayBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnSigeyul = new IHIS.Framework.XButton();
            this.dbxAge = new IHIS.Framework.XDisplayBox();
            this.dbxSpecimenSer = new IHIS.Framework.XDisplayBox();
            this.dbxSpecimenName = new IHIS.Framework.XDisplayBox();
            this.dbxSpecimenCode = new IHIS.Framework.XDisplayBox();
            this.dbxGwa = new IHIS.Framework.XDisplayBox();
            this.dbxTat2 = new IHIS.Framework.XDisplayBox();
            this.dbxTa2 = new IHIS.Framework.XDisplayBox();
            this.dbxTat1 = new IHIS.Framework.XDisplayBox();
            this.dbxTa1 = new IHIS.Framework.XDisplayBox();
            this.dbxHoCode = new IHIS.Framework.XDisplayBox();
            this.dbxHoDong = new IHIS.Framework.XDisplayBox();
            this.dbxInOutGubun = new IHIS.Framework.XDisplayBox();
            this.dbxPartJubsuTime = new IHIS.Framework.XDisplayBox();
            this.dbxPartJunbsuDate = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.dbxBunho = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dbxSex = new IHIS.Framework.XDisplayBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdPa = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.cbxAutoConfirm = new IHIS.Framework.XCheckBox();
            this.btnOutResult = new IHIS.Framework.XButton();
            this.btnEquipResult = new IHIS.Framework.XButton();
            this.grdNoteUpdate = new IHIS.Framework.XEditGrid();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.btnAllDp = new IHIS.Framework.XButton();
            this.btnAllCheck = new IHIS.Framework.XButton();
            this.btnResult = new IHIS.Framework.XButton();
            this.btnUpdateResult = new IHIS.Framework.XButton();
            this.btnBeforeResult = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.cbxJangbiCode = new IHIS.Framework.XDictComboBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.cbxGubun = new IHIS.Framework.XCheckBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.laySpecimenInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem20 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.vsvNote = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem33 = new IHIS.Framework.SingleLayoutItem();
            this.dsvNote = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem23 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem24 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem25 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem26 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem32 = new IHIS.Framework.SingleLayoutItem();
            this.layNoteUpdate = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.singleLayoutItem28 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem30 = new IHIS.Framework.SingleLayoutItem();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.singleLayoutItem31 = new IHIS.Framework.SingleLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.vsvJubsuja = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem27 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            this.pnlSigeyul.SuspendLayout();
            this.tabSigeyul.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoteUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNoteUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.pnlSigeyul);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.grdResult);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdResult
            // 
            resources.ApplyResources(this.grdResult, "grdResult");
            this.grdResult.ApplyPaintEventToAllColumn = true;
            this.grdResult.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
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
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell33,
            this.xEditGridCell32,
            this.xEditGridCell34});
            this.grdResult.ColPerLine = 10;
            this.grdResult.ColResizable = true;
            this.grdResult.Cols = 11;
            this.grdResult.ExecuteQuery = null;
            this.grdResult.FixedCols = 1;
            this.grdResult.FixedRows = 1;
            this.grdResult.HeaderHeights.Add(21);
            this.grdResult.Name = "grdResult";
            this.grdResult.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdResult.ParamList")));
            this.grdResult.RowHeaderVisible = true;
            this.grdResult.Rows = 2;
            this.grdResult.RowStateCheckOnPaint = false;
            this.grdResult.ToolTipActive = true;
            this.grdResult.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdResult_PreSaveLayout);
            this.grdResult.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdResult_GridColumnProtectModify);
            this.grdResult.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdResult_GridFindSelected);
            this.grdResult.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdResult_ItemValueChanging);
            this.grdResult.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdResult_GridButtonClick);
            this.grdResult.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdResult_SaveEnd);
            this.grdResult.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdResult_RowFocusChanged);
            this.grdResult.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdResult_GridCellPainting);
            this.grdResult.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdResult_GridColumnChanged);
            this.grdResult.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdResult_QueryStarting);
            this.grdResult.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdResult_QueryEnd);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "pkcpl3020";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "gumsa_name";
            this.xEditGridCell6.CellWidth = 260;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdCol = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell7.AlterateRowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell7.CellName = "standard_yn";
            this.xEditGridCell7.CellWidth = 25;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell7.RowForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell7.SelectedForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "cpl_result";
            this.xEditGridCell8.CellWidth = 96;
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.FindWorker = this.fwkResult;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // fwkResult
            // 
            this.fwkResult.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fwkResult.ExecuteQuery = null;
            this.fwkResult.FormText = "RESULT照会";
            this.fwkResult.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkResult.ParamList")));
            this.fwkResult.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkResult.ServerFilter = true;
            this.fwkResult.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkResult_QueryStarting);
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "code";
            this.findColumnInfo5.ColWidth = 106;
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "code_name";
            this.findColumnInfo6.ColWidth = 144;
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "confirm_yn";
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "before_result";
            this.xEditGridCell10.CellWidth = 97;
            this.xEditGridCell10.Col = 7;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell11.CellName = "panic_yn";
            this.xEditGridCell11.CellWidth = 25;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell11.SelectedForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell12.CellName = "delta_yn";
            this.xEditGridCell12.CellWidth = 25;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell12.SelectedForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "danui_name";
            this.xEditGridCell13.Col = 8;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdCol = false;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "standard";
            this.xEditGridCell14.CellWidth = 101;
            this.xEditGridCell14.Col = 9;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 80;
            this.xEditGridCell15.CellName = "comments";
            this.xEditGridCell15.CellWidth = 118;
            this.xEditGridCell15.Col = 10;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "fkocs";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "fkcpl2010";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "lab_no";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "hangmog_code";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "specimen_code";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "emergency";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "gumsaja";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "bunho";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "result_date";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "specimen_ser";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "result_form";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "source_gumsa";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "group_gubun";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "group_hangmog";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "display_yn";
            this.xEditGridCell32.CellWidth = 35;
            this.xEditGridCell32.Col = 6;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell34.ButtonImage")));
            this.xEditGridCell34.CellName = "btnResult";
            this.xEditGridCell34.CellWidth = 26;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            // 
            // pnlSigeyul
            // 
            resources.ApplyResources(this.pnlSigeyul, "pnlSigeyul");
            this.pnlSigeyul.Controls.Add(this.tabSigeyul);
            this.pnlSigeyul.Name = "pnlSigeyul";
            // 
            // tabSigeyul
            // 
            resources.ApplyResources(this.tabSigeyul, "tabSigeyul");
            this.tabSigeyul.IDEPixelArea = true;
            this.tabSigeyul.IDEPixelBorder = false;
            this.tabSigeyul.Name = "tabSigeyul";
            this.tabSigeyul.SelectedIndex = 0;
            this.tabSigeyul.SelectedTab = this.tabPage1;
            this.tabSigeyul.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.tabSigeyul.SelectionChanged += new System.EventHandler(this.tabSigeyul_SelectionChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage1.Icon")));
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Icon = ((System.Drawing.Icon)(resources.GetObject("tabPage2.Icon")));
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.txtNote);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.Controls.Add(this.panel1);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // txtNote
            // 
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            this.txtNote.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtNote_DataValidating);
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Name = "xLabel4";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.fbxNote);
            this.panel1.Controls.Add(this.xLabel1);
            this.panel1.Controls.Add(this.dbxNote);
            this.panel1.Name = "panel1";
            // 
            // fbxNote
            // 
            resources.ApplyResources(this.fbxNote, "fbxNote");
            this.fbxNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxNote.FindWorker = this.fwkNote;
            this.fbxNote.Name = "fbxNote";
            this.fbxNote.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxNote_DataValidating);
            // 
            // fwkNote
            // 
            this.fwkNote.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkNote.ExecuteQuery = null;
            this.fwkNote.FormText = "照会";
            this.fwkNote.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkNote.ParamList")));
            this.fwkNote.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkNote.ServerFilter = true;
            this.fwkNote.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkNote_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "gubun";
            this.findColumnInfo3.ColWidth = 106;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "gubun_name";
            this.findColumnInfo4.ColWidth = 475;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // dbxNote
            // 
            resources.ApplyResources(this.dbxNote, "dbxNote");
            this.dbxNote.Name = "dbxNote";
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.btnSigeyul);
            this.xPanel2.Controls.Add(this.dbxAge);
            this.xPanel2.Controls.Add(this.dbxSpecimenSer);
            this.xPanel2.Controls.Add(this.dbxSpecimenName);
            this.xPanel2.Controls.Add(this.dbxSpecimenCode);
            this.xPanel2.Controls.Add(this.dbxGwa);
            this.xPanel2.Controls.Add(this.dbxTat2);
            this.xPanel2.Controls.Add(this.dbxTa2);
            this.xPanel2.Controls.Add(this.dbxTat1);
            this.xPanel2.Controls.Add(this.dbxTa1);
            this.xPanel2.Controls.Add(this.dbxHoCode);
            this.xPanel2.Controls.Add(this.dbxHoDong);
            this.xPanel2.Controls.Add(this.dbxInOutGubun);
            this.xPanel2.Controls.Add(this.dbxPartJubsuTime);
            this.xPanel2.Controls.Add(this.dbxPartJunbsuDate);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.xLabel10);
            this.xPanel2.Controls.Add(this.dbxBunho);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.dbxSex);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.dbxSuname);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnSigeyul
            // 
            resources.ApplyResources(this.btnSigeyul, "btnSigeyul");
            this.btnSigeyul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnSigeyul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSigeyul.Image = ((System.Drawing.Image)(resources.GetObject("btnSigeyul.Image")));
            this.btnSigeyul.Name = "btnSigeyul";
            this.btnSigeyul.Click += new System.EventHandler(this.btnSigeyul_Click);
            // 
            // dbxAge
            // 
            resources.ApplyResources(this.dbxAge, "dbxAge");
            this.dbxAge.Name = "dbxAge";
            // 
            // dbxSpecimenSer
            // 
            resources.ApplyResources(this.dbxSpecimenSer, "dbxSpecimenSer");
            this.dbxSpecimenSer.Name = "dbxSpecimenSer";
            // 
            // dbxSpecimenName
            // 
            resources.ApplyResources(this.dbxSpecimenName, "dbxSpecimenName");
            this.dbxSpecimenName.Name = "dbxSpecimenName";
            // 
            // dbxSpecimenCode
            // 
            resources.ApplyResources(this.dbxSpecimenCode, "dbxSpecimenCode");
            this.dbxSpecimenCode.Name = "dbxSpecimenCode";
            // 
            // dbxGwa
            // 
            resources.ApplyResources(this.dbxGwa, "dbxGwa");
            this.dbxGwa.Name = "dbxGwa";
            // 
            // dbxTat2
            // 
            resources.ApplyResources(this.dbxTat2, "dbxTat2");
            this.dbxTat2.Mask = global::IHIS.CPLS.Properties.Resources.MaskText;
            this.dbxTat2.Name = "dbxTat2";
            // 
            // dbxTa2
            // 
            resources.ApplyResources(this.dbxTa2, "dbxTa2");
            this.dbxTa2.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.dbxTa2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.dbxTa2.EdgeRounding = false;
            this.dbxTa2.Name = "dbxTa2";
            // 
            // dbxTat1
            // 
            resources.ApplyResources(this.dbxTat1, "dbxTat1");
            this.dbxTat1.Mask = global::IHIS.CPLS.Properties.Resources.MaskText;
            this.dbxTat1.Name = "dbxTat1";
            // 
            // dbxTa1
            // 
            resources.ApplyResources(this.dbxTa1, "dbxTa1");
            this.dbxTa1.BackColor = IHIS.Framework.XColor.XLabelBackColor;
            this.dbxTa1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.dbxTa1.EdgeRounding = false;
            this.dbxTa1.Name = "dbxTa1";
            // 
            // dbxHoCode
            // 
            resources.ApplyResources(this.dbxHoCode, "dbxHoCode");
            this.dbxHoCode.Name = "dbxHoCode";
            // 
            // dbxHoDong
            // 
            resources.ApplyResources(this.dbxHoDong, "dbxHoDong");
            this.dbxHoDong.Name = "dbxHoDong";
            // 
            // dbxInOutGubun
            // 
            resources.ApplyResources(this.dbxInOutGubun, "dbxInOutGubun");
            this.dbxInOutGubun.Name = "dbxInOutGubun";
            // 
            // dbxPartJubsuTime
            // 
            resources.ApplyResources(this.dbxPartJubsuTime, "dbxPartJubsuTime");
            this.dbxPartJubsuTime.Mask = "##:##";
            this.dbxPartJubsuTime.Name = "dbxPartJubsuTime";
            // 
            // dbxPartJunbsuDate
            // 
            resources.ApplyResources(this.dbxPartJunbsuDate, "dbxPartJunbsuDate");
            this.dbxPartJunbsuDate.Name = "dbxPartJunbsuDate";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Name = "xLabel10";
            // 
            // dbxBunho
            // 
            resources.ApplyResources(this.dbxBunho, "dbxBunho");
            this.dbxBunho.Name = "dbxBunho";
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Name = "xLabel7";
            // 
            // dbxSex
            // 
            resources.ApplyResources(this.dbxSex, "dbxSex");
            this.dbxSex.Name = "dbxSex";
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Name = "xLabel6";
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.grdPa);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdPa
            // 
            resources.ApplyResources(this.grdPa, "grdPa");
            this.grdPa.ApplyPaintEventToAllColumn = true;
            this.grdPa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell43});
            this.grdPa.ColPerLine = 5;
            this.grdPa.ColResizable = true;
            this.grdPa.Cols = 6;
            this.grdPa.ExecuteQuery = null;
            this.grdPa.FixedCols = 1;
            this.grdPa.FixedRows = 1;
            this.grdPa.HeaderHeights.Add(21);
            this.grdPa.Name = "grdPa";
            this.grdPa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPa.ParamList")));
            this.grdPa.RowHeaderVisible = true;
            this.grdPa.Rows = 2;
            this.grdPa.ToolTipActive = true;
            this.grdPa.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPa_RowFocusChanged);
            this.grdPa.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPa_GridCellPainting);
            this.grdPa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPa_QueryStarting);
            this.grdPa.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPa_QueryEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "lab_no";
            this.xEditGridCell1.CellWidth = 55;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 150;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "specimen_ser";
            this.xEditGridCell3.CellWidth = 110;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "lab_sort";
            this.xEditGridCell4.CellWidth = 73;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "part_jubsu_date";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell17.CellWidth = 130;
            this.xEditGridCell17.Col = 5;
            this.xEditGridCell17.EnableSort = true;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "jundal_gubun";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "gubun";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "result_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "confirm_yn";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "result_status";
            this.xEditGridCell37.CellWidth = 20;
            this.xEditGridCell37.Col = 1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "batch_confirm_yn";
            this.xEditGridCell43.CellWidth = 46;
            this.xEditGridCell43.Col = 2;
            this.xEditGridCell43.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            // 
            // xPanel8
            // 
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Controls.Add(this.cbxAutoConfirm);
            this.xPanel8.Controls.Add(this.btnOutResult);
            this.xPanel8.Controls.Add(this.btnEquipResult);
            this.xPanel8.Controls.Add(this.grdNoteUpdate);
            this.xPanel8.Controls.Add(this.btnAllDp);
            this.xPanel8.Controls.Add(this.btnAllCheck);
            this.xPanel8.Controls.Add(this.btnResult);
            this.xPanel8.Controls.Add(this.btnUpdateResult);
            this.xPanel8.Controls.Add(this.btnBeforeResult);
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            // 
            // cbxAutoConfirm
            // 
            resources.ApplyResources(this.cbxAutoConfirm, "cbxAutoConfirm");
            this.cbxAutoConfirm.Name = "cbxAutoConfirm";
            this.cbxAutoConfirm.UseVisualStyleBackColor = false;
            // 
            // btnOutResult
            // 
            resources.ApplyResources(this.btnOutResult, "btnOutResult");
            this.btnOutResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnOutResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOutResult.ImageIndex = 1;
            this.btnOutResult.ImageList = this.ImageList;
            this.btnOutResult.Name = "btnOutResult";
            this.btnOutResult.Click += new System.EventHandler(this.btnOutResult_Click);
            // 
            // btnEquipResult
            // 
            resources.ApplyResources(this.btnEquipResult, "btnEquipResult");
            this.btnEquipResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnEquipResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEquipResult.Image = ((System.Drawing.Image)(resources.GetObject("btnEquipResult.Image")));
            this.btnEquipResult.Name = "btnEquipResult";
            this.btnEquipResult.Click += new System.EventHandler(this.btnEquipResult_Click);
            // 
            // grdNoteUpdate
            // 
            resources.ApplyResources(this.grdNoteUpdate, "grdNoteUpdate");
            this.grdNoteUpdate.CallerID = '2';
            this.grdNoteUpdate.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42});
            this.grdNoteUpdate.ColPerLine = 5;
            this.grdNoteUpdate.Cols = 5;
            this.grdNoteUpdate.ExecuteQuery = null;
            this.grdNoteUpdate.FixedRows = 1;
            this.grdNoteUpdate.HeaderHeights.Add(12);
            this.grdNoteUpdate.Name = "grdNoteUpdate";
            this.grdNoteUpdate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdNoteUpdate.ParamList")));
            this.grdNoteUpdate.Rows = 2;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "jundal_gubun";
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "specimen_ser";
            this.xEditGridCell39.Col = 1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "note";
            this.xEditGridCell40.Col = 2;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "code";
            this.xEditGridCell41.Col = 3;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "etc_comment";
            this.xEditGridCell42.Col = 4;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            // 
            // btnAllDp
            // 
            resources.ApplyResources(this.btnAllDp, "btnAllDp");
            this.btnAllDp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllDp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllDp.ImageIndex = 1;
            this.btnAllDp.ImageList = this.ImageList;
            this.btnAllDp.Name = "btnAllDp";
            this.btnAllDp.Click += new System.EventHandler(this.btnAllDp_Click);
            // 
            // btnAllCheck
            // 
            resources.ApplyResources(this.btnAllCheck, "btnAllCheck");
            this.btnAllCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnAllCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAllCheck.ImageIndex = 1;
            this.btnAllCheck.ImageList = this.ImageList;
            this.btnAllCheck.Name = "btnAllCheck";
            this.btnAllCheck.Click += new System.EventHandler(this.btnAllCheck_Click);
            // 
            // btnResult
            // 
            resources.ApplyResources(this.btnResult, "btnResult");
            this.btnResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnResult.Image = ((System.Drawing.Image)(resources.GetObject("btnResult.Image")));
            this.btnResult.Name = "btnResult";
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // btnUpdateResult
            // 
            resources.ApplyResources(this.btnUpdateResult, "btnUpdateResult");
            this.btnUpdateResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnUpdateResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdateResult.ImageIndex = 0;
            this.btnUpdateResult.ImageList = this.ImageList;
            this.btnUpdateResult.Name = "btnUpdateResult";
            this.btnUpdateResult.Click += new System.EventHandler(this.btnUpdateResult_Click);
            // 
            // btnBeforeResult
            // 
            resources.ApplyResources(this.btnBeforeResult, "btnBeforeResult");
            this.btnBeforeResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnBeforeResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBeforeResult.Image = ((System.Drawing.Image)(resources.GetObject("btnBeforeResult.Image")));
            this.btnBeforeResult.Name = "btnBeforeResult";
            this.btnBeforeResult.Click += new System.EventHandler(this.btnBeforeResult_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            // 
            // xPanel6
            // 
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.cbxActor);
            this.xPanel6.Controls.Add(this.xLabel5);
            this.xPanel6.Controls.Add(this.cbxJangbiCode);
            this.xPanel6.Controls.Add(this.xLabel8);
            this.xPanel6.Controls.Add(this.cbxGubun);
            this.xPanel6.Controls.Add(this.dtpToDate);
            this.xPanel6.Controls.Add(this.label1);
            this.xPanel6.Controls.Add(this.dtpFromDate);
            this.xPanel6.Controls.Add(this.xLabel9);
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Name = "xPanel6";
            // 
            // cbxActor
            // 
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.ExecuteQuery = null;
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Name = "xLabel5";
            // 
            // cbxJangbiCode
            // 
            resources.ApplyResources(this.cbxJangbiCode, "cbxJangbiCode");
            this.cbxJangbiCode.ExecuteQuery = null;
            this.cbxJangbiCode.Name = "cbxJangbiCode";
            this.cbxJangbiCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxJangbiCode.ParamList")));
            this.cbxJangbiCode.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxJangbiCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cbxJangbiCode_DataValidating);
            this.cbxJangbiCode.SelectedValueChanged += new System.EventHandler(this.cbxJangbiCode_SelectedValueChanged);
            // 
            // xLabel8
            // 
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Name = "xLabel8";
            // 
            // cbxGubun
            // 
            resources.ApplyResources(this.cbxGubun, "cbxGubun");
            this.cbxGubun.Name = "cbxGubun";
            this.cbxGubun.UseVisualStyleBackColor = false;
            this.cbxGubun.CheckedChanged += new System.EventHandler(this.cbxGubun_CheckedChanged);
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Name = "xLabel9";
            // 
            // laySpecimenInfo
            // 
            this.laySpecimenInfo.ExecuteQuery = null;
            this.laySpecimenInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18,
            this.singleLayoutItem19,
            this.singleLayoutItem20,
            this.singleLayoutItem21,
            this.singleLayoutItem22});
            this.laySpecimenInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySpecimenInfo.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxBunho;
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.dbxSuname;
            this.singleLayoutItem2.DataName = "suname";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.BindControl = this.dbxSex;
            this.singleLayoutItem3.DataName = "sex";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "birth";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.dbxGwa;
            this.singleLayoutItem5.DataName = "gwa";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "doctor_name";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.BindControl = this.dbxHoDong;
            this.singleLayoutItem7.DataName = "ho_dong";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.BindControl = this.dbxHoCode;
            this.singleLayoutItem8.DataName = "ho_code";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "order_date";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "jubsu_date";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.BindControl = this.dbxPartJunbsuDate;
            this.singleLayoutItem11.DataName = "part_jubsu_date";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "jubsu_time";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.BindControl = this.dbxPartJubsuTime;
            this.singleLayoutItem13.DataName = "part_jubsu_time";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "jubsuja";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.BindControl = this.dbxInOutGubun;
            this.singleLayoutItem15.DataName = "in_out_gubun";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "jundal_gubun";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.BindControl = this.dbxSpecimenCode;
            this.singleLayoutItem17.DataName = "specimen_code";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.BindControl = this.dbxSpecimenName;
            this.singleLayoutItem18.DataName = "specimen_name";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.BindControl = this.dbxTat1;
            this.singleLayoutItem19.DataName = "tat1";
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.BindControl = this.dbxTat2;
            this.singleLayoutItem20.DataName = "tat2";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.BindControl = this.dbxAge;
            this.singleLayoutItem21.DataName = "age";
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.DataName = "switch";
            // 
            // vsvNote
            // 
            this.vsvNote.ExecuteQuery = null;
            this.vsvNote.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem33});
            this.vsvNote.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvNote.ParamList")));
            // 
            // singleLayoutItem33
            // 
            this.singleLayoutItem33.DataName = "note";
            // 
            // dsvNote
            // 
            this.dsvNote.ExecuteQuery = null;
            this.dsvNote.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem23,
            this.singleLayoutItem24,
            this.singleLayoutItem25,
            this.singleLayoutItem26,
            this.singleLayoutItem32});
            this.dsvNote.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvNote.ParamList")));
            this.dsvNote.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dsvNote_QueryStarting);
            // 
            // singleLayoutItem23
            // 
            this.singleLayoutItem23.DataName = "jundal_gubun";
            // 
            // singleLayoutItem24
            // 
            this.singleLayoutItem24.DataName = "specimen_ser";
            // 
            // singleLayoutItem25
            // 
            this.singleLayoutItem25.BindControl = this.dbxNote;
            this.singleLayoutItem25.DataName = "dbxNote";
            // 
            // singleLayoutItem26
            // 
            this.singleLayoutItem26.BindControl = this.fbxNote;
            this.singleLayoutItem26.DataName = "fbxNote";
            // 
            // singleLayoutItem32
            // 
            this.singleLayoutItem32.BindControl = this.txtNote;
            this.singleLayoutItem32.DataName = "txtNote";
            // 
            // layNoteUpdate
            // 
            this.layNoteUpdate.CallerID = '2';
            this.layNoteUpdate.ExecuteQuery = null;
            this.layNoteUpdate.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24});
            this.layNoteUpdate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layNoteUpdate.ParamList")));
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "jundal_gubun";
            this.multiLayoutItem20.IsUpdItem = true;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "specimen_ser";
            this.multiLayoutItem21.IsUpdItem = true;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "note";
            this.multiLayoutItem22.IsUpdItem = true;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "code";
            this.multiLayoutItem23.IsUpdItem = true;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "etc_comment";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // singleLayoutItem28
            // 
            this.singleLayoutItem28.DataName = "dbxJundalGubunName";
            // 
            // singleLayoutItem30
            // 
            this.singleLayoutItem30.BindControl = this.dbxNote;
            this.singleLayoutItem30.DataName = "note";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jundal_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "specimen_ser";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "note";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code";
            // 
            // singleLayoutItem31
            // 
            this.singleLayoutItem31.DataName = "jundal_gubun";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "jundal_gubun";
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "specimen_ser";
            this.multiLayoutItem11.IsUpdItem = true;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "note";
            this.multiLayoutItem12.IsUpdItem = true;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "code";
            this.multiLayoutItem13.IsUpdItem = true;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "etc_comment";
            this.multiLayoutItem14.IsUpdItem = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "jundal_gubun";
            this.multiLayoutItem5.IsUpdItem = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "specimen_ser";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "note";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "code";
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "etc_comment";
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // vsvJubsuja
            // 
            this.vsvJubsuja.ExecuteQuery = null;
            this.vsvJubsuja.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem27});
            this.vsvJubsuja.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvJubsuja.ParamList")));
            this.vsvJubsuja.QuerySQL = "SELECT USER_NM\r\n  FROM ADM3200\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND USER_ID  " +
    " = :f_code";
            // 
            // singleLayoutItem27
            // 
            this.singleLayoutItem27.DataName = "jubsuja_name";
            // 
            // CPL3020U02
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel6);
            this.Name = "CPL3020U02";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CPL3020U02_Closing);
            this.xPanel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            this.pnlSigeyul.ResumeLayout(false);
            this.tabSigeyul.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).EndInit();
            this.xPanel8.ResumeLayout(false);
            this.xPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoteUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNoteUpdate)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // TODO comment use connect cloud
            /*this.grdResult.SavePerformer = new XSavePerformer(this);
            //this.layNoteUpdate.SavePerformer = this.grdResult.SavePerformer;
            this.grdNoteUpdate.SavePerformer = this.grdResult.SavePerformer;*/

            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dbxTa1.SetDataValue("TAT1");
            this.dbxTa2.SetDataValue("TAT2");
            this.CurrMQLayout = this.grdPa;

            // 実施者に 現在ログインしている IDを セットする｡
            this.cbxActor.SetDataValue(UserInfo.UserID);
        }
        #endregion

        private void setAutoConfirmChecked()
        {
            if (this.cbxJangbiCode.SelectedValue != null)
            {
                /*string cmd = @" SELECT A.CODE_VALUE
                              FROM CPL0109 A
                             WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                               AND A.CODE_TYPE = 'AUTO_CONFIRM'
                               AND A.CODE      = '" + cbxJangbiCode.SelectedValue.ToString() + @"'";
                object obj = Service.ExecuteScalar(cmd);

                if (obj != null)
                    this.cbxAutoConfirm.Checked = obj.ToString() == "Y" ? true : false;*/

                // Connect to cloud
                CPL3020U02AutoConfirmCheckedArgs args = new CPL3020U02AutoConfirmCheckedArgs();
                args.CodeType = "AUTO_CONFIRM";
                args.JangbiCode = cbxJangbiCode.SelectedValue.ToString();
                CPL3020U02AutoConfirmCheckedResult checkedResult =
                    CloudService.Instance.Submit<CPL3020U02AutoConfirmCheckedResult, CPL3020U02AutoConfirmCheckedArgs>(
                        args);
                if (checkedResult != null && checkedResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    this.cbxAutoConfirm.Checked = checkedResult.CodeValue == "Y" ? true : false;
                }
            }
            else
                this.cbxAutoConfirm.Checked = false;
        }

        #region 환자그리드 포우포커스체인지
        private void grdPa_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            this.grdResult.QueryLayout(true);

            // Connect to cloud service
            vCPL3020U00GrdPaRowFocusChangedResult = EnsureCPL3020U00GrdPaRowFocusChangedResultProceed(
            this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"),
            this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"),
            this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));

            GetSpecimenInfo(this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));

            this.dbxSpecimenSer.SetDataValue(this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));

            this.dsvNote.ExecuteQuery = ExecuteQueryDsvNote;
            this.dsvNote.QueryLayout();
        }
        #endregion

        #region
        private void GetSpecimenInfo(string pSpecimen_ser)
        {

            // User connect to cloud
            this.laySpecimenInfo.Reset();
            if (vCPL3020U00GrdPaRowFocusChangedResult != null &&
                vCPL3020U00GrdPaRowFocusChangedResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<CPL3020U00CplSpecimenInfo> lstCplSpecimenInfos =
                    vCPL3020U00GrdPaRowFocusChangedResult.CplSpecimenItem;
                if (lstCplSpecimenInfos != null && lstCplSpecimenInfos.Count > 0)
                {
                    foreach (CPL3020U00CplSpecimenInfo cplSpecimenInfo in lstCplSpecimenInfos)
                    {
                        string gwa_name = vCPL3020U00GrdPaRowFocusChangedResult.GwaName;
                        string ho_dong_name = vCPL3020U00GrdPaRowFocusChangedResult.HoDongName;

                        this.laySpecimenInfo.SetItemValue("bunho", cplSpecimenInfo.Bunho);
                        this.laySpecimenInfo.SetItemValue("suname", cplSpecimenInfo.Suname);
                        this.laySpecimenInfo.SetItemValue("sex", cplSpecimenInfo.Sex);
                        this.laySpecimenInfo.SetItemValue("birth", cplSpecimenInfo.Birth);
                        //this.laySpecimenInfo.SetItemValue("gwa", outputList[6].ToString()); 
                        this.laySpecimenInfo.SetItemValue("gwa", gwa_name);
                        this.laySpecimenInfo.SetItemValue("doctor_name", cplSpecimenInfo.DoctorName);
                        //this.laySpecimenInfo.SetItemValue("ho_dong", outputList[8].ToString()); 
                        this.laySpecimenInfo.SetItemValue("ho_dong", ho_dong_name);
                        this.laySpecimenInfo.SetItemValue("ho_code", cplSpecimenInfo.HoCode);
                        this.laySpecimenInfo.SetItemValue("order_date", cplSpecimenInfo.OrderDate);
                        this.laySpecimenInfo.SetItemValue("jubsu_date", cplSpecimenInfo.JubsuDate);
                        this.laySpecimenInfo.SetItemValue("part_jubsu_date", cplSpecimenInfo.PartJubsuDate);
                        this.laySpecimenInfo.SetItemValue("jubsu_time", cplSpecimenInfo.JubsuTime);
                        this.laySpecimenInfo.SetItemValue("part_jubsu_time", cplSpecimenInfo.PartJubsuTime);
                        this.laySpecimenInfo.SetItemValue("jubsuja", cplSpecimenInfo.Jubsuja);
                        this.laySpecimenInfo.SetItemValue("in_out_gubun", cplSpecimenInfo.InOutGubun);
                        this.laySpecimenInfo.SetItemValue("jundal_gubun", cplSpecimenInfo.JundalGubun);
                        this.laySpecimenInfo.SetItemValue("specimen_code", cplSpecimenInfo.SpecimenCode);
                        this.laySpecimenInfo.SetItemValue("specimen_name", cplSpecimenInfo.SpecimenName);
                        this.laySpecimenInfo.SetItemValue("tat1", cplSpecimenInfo.Tat1);
                        this.laySpecimenInfo.SetItemValue("tat2", cplSpecimenInfo.Tat2);
                        this.laySpecimenInfo.SetItemValue("age", cplSpecimenInfo.Age);
                        this.laySpecimenInfo.SetItemValue("switch", cplSpecimenInfo.SwitchValue);
                    }
                }
            }

            // TODO comment use connect cloud
            /*ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();
            inputList.Add(pSpecimen_ser);
            this.laySpecimenInfo.Reset();

            if (!Service.ExecuteProcedure("PR_CPL_SPECIMEN_INFO_RESULT", inputList, outputList))
            {
                XMessageBox.Show("PR_CPL_SPECIMEN_INFO_RESULT\r\n" + Service.ErrFullMsg, "", MessageBoxIcon.Error);
                return;
            }

            if (outputList.Count > 0)
            {
                string cmdText = @" SELECT FN_BAS_LOAD_GWA_NAME(TRIM(:o_gwa),TO_DATE(:o_order_date,'YYYY/MM/DD'))       GWA_NAME
                                         , FN_BAS_LOAD_GWA_NAME(TRIM(:o_ho_dong),TO_DATE(:o_order_date,'YYYY/MM/DD'))   HO_DONG_NAME
                                      FROM DUAL";
                BindVarCollection bc = new BindVarCollection();
                bc.Add("o_gwa", outputList[6].ToString());
                bc.Add("o_ho_dong", outputList[8].ToString());

                if (outputList[10].ToString().Length > 10)
                    bc.Add("o_order_date", outputList[10].ToString().Substring(0,10));
                else
                    bc.Add("o_order_date", "");

                DataTable dt = Service.ExecuteDataTable(cmdText, bc);
                
                string gwa_name = "";
                string ho_dong_name = "";

                if (!TypeCheck.IsNull(dt))
                {
                    gwa_name = dt.Rows[0]["gwa_name"].ToString();
                    ho_dong_name = dt.Rows[0]["ho_dong_name"].ToString();
                }
                
                this.laySpecimenInfo.SetItemValue("bunho", outputList[0].ToString()); 
                this.laySpecimenInfo.SetItemValue("suname", outputList[1].ToString()); 
                this.laySpecimenInfo.SetItemValue("sex", outputList[2].ToString()); 
                this.laySpecimenInfo.SetItemValue("birth", outputList[3].ToString()); 
                //this.laySpecimenInfo.SetItemValue("gwa", outputList[6].ToString()); 
                this.laySpecimenInfo.SetItemValue("gwa", gwa_name);
                this.laySpecimenInfo.SetItemValue("doctor_name", outputList[7].ToString()); 
                //this.laySpecimenInfo.SetItemValue("ho_dong", outputList[8].ToString()); 
                this.laySpecimenInfo.SetItemValue("ho_dong", ho_dong_name); 
                this.laySpecimenInfo.SetItemValue("ho_code", outputList[9].ToString()); 
                this.laySpecimenInfo.SetItemValue("order_date", outputList[10].ToString()); 
                this.laySpecimenInfo.SetItemValue("jubsu_date", outputList[11].ToString()); 
                this.laySpecimenInfo.SetItemValue("part_jubsu_date", outputList[12].ToString()); 
                this.laySpecimenInfo.SetItemValue("jubsu_time", outputList[13].ToString()); 
                this.laySpecimenInfo.SetItemValue("part_jubsu_time", outputList[14].ToString()); 
                this.laySpecimenInfo.SetItemValue("jubsuja", outputList[15].ToString()); 
                this.laySpecimenInfo.SetItemValue("in_out_gubun", outputList[16].ToString()); 
                this.laySpecimenInfo.SetItemValue("jundal_gubun", outputList[17].ToString()); 
                this.laySpecimenInfo.SetItemValue("specimen_code", outputList[18].ToString()); 
                this.laySpecimenInfo.SetItemValue("specimen_name", outputList[19].ToString()); 
                this.laySpecimenInfo.SetItemValue("tat1", outputList[20].ToString()); 
                this.laySpecimenInfo.SetItemValue("tat2", outputList[21].ToString()); 
                this.laySpecimenInfo.SetItemValue("age", outputList[22].ToString()); 
                this.laySpecimenInfo.SetItemValue("switch", outputList[23].ToString()); 
            }*/


        }
        #endregion

        #region 결과 파인드 선택 후
        private void grdResult_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
        {
            if (e.ColName == "cpl_result")
            {
                this.grdResult.SetItemValue(e.RowNumber, "cpl_result", e.ReturnValues[1].ToString());
            }
        }
        #endregion

        private void grdResult_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "cpl_result")
            {
                if (this.grdResult.GetItemString(e.RowNumber, "confirm_yn") == "Y")
                    e.Protect = true;
                else
                    e.Protect = false;
            }
        }

        private void btnUpdateResult_Click(object sender, System.EventArgs e)
        {
            ///*********************
            ///  폼으로 보여줄 때 
            ///********************/
            //if ( this.grdResult.RowCount > 0 )
            //{
            //    if ( this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"confirm_yn") != "Y" )
            //    {
            //        string msg = (NetInfo.Language == LangMode.Ko ? "확정되지 않은 결과수정은 사유를 입력하지 않아도 가능합니다."
            //            : "確定されていない結果の修正は事由を入力しなくても可能です。");
            //        XMessageBox.Show(msg);
            //    }
            //    else
            //    {
            //        string pkcpl3020 = this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"pkcpl3020");
            //        RESULTUPDATE dlg = new RESULTUPDATE(this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"lab_no"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"hangmog_code"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"specimen_code"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"emergency"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"before_result"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"gumsaja"),
            //            pkcpl3020);

            //        dlg.ShowDialog();
            //        if ( dlg.DialogResult == DialogResult.OK)
            //        {
            //            LoadResultByKey(pkcpl3020);
            //        }
            //    }
            //}
            //else
            //{
            //    string msg = (NetInfo.Language == LangMode.Ko ? "수정할 결과가 없습니다."
            //        : "修正できる結果がございません。");
            //    XMessageBox.Show(msg);
            //}
        }

        private void LoadResultByKey(string pkcpl3020)
        {
            //            string tQuery = this.grdResult.QuerySQL;

            //            this.grdResult.QuerySQL = @"SELECT C.PKCPL3020                          PKCPL3020,
            //                                               D.GUMSA_NAME                         GUMSA_NAME, 
            //                                               C.STANDARD_YN                        STANDARD_YN,   
            //                                               C.CPL_RESULT                         CPL_RESULT,   
            //                                               C.CONFIRM_YN                         CONFIRM_YN,   
            //                                               C.BEFORE_RESULT                      BEFORE_RESULT,   
            //                                               C.PANIC_YN                           PANIC_YN,   
            //                                               C.DELTA_YN                           DELTA_YN,   
            //                                               E.CODE_NAME                          DANUI_NAME,
            //                                               DECODE(C.TO_STANDARD,NULL,C.FROM_STANDARD,C.FROM_STANDARD || ' ~ ' || C.TO_STANDARD)    STANDARD,
            //                                               C.COMMENTS                           COMMENTS,   
            //                                               A.FKOCS2003                          FKOCS2003,
            //                                               C.FKCPL2010                          FKCPL2010,
            //                                               C.LAB_NO                             LAB_NO,
            //                                               C.HANGMOG_CODE                       HANGMOG_CODE,
            //                                               C.SPECIMEN_CODE                      SPECIMEN_CODE,
            //                                               C.EMERGENCY                          EMERGENCY,
            //                                               C.GUMSAJA                            GUMSAJA,
            //                                               A.BUNHO                              BUNHO,
            //                                               C.RESULT_DATE                        RESULT_DATE,
            //                                               C.SPECIMEN_SER                       SPECIMEN_SER,
            //                                               C.RESULT_FORM                        RESULT_FORM,
            //                                               ''                                   SOURCE_GUMSA,
            //                                               ''                                   GROUP_GUBUN,
            //                                               ''                                   GROUP_HANGMOG,
            //                                               NVL(C.DISPLAY_YN,'Y')                DISPLAY_YN
            //                                          FROM CPL0109 E,
            //                                               CPL0101 D,
            //                                               CPL3020 C,   
            //                                               CPL2010 A  
            //                                         WHERE D.HOSP_CODE        = :f_hosp_code
            //                                           AND A.HOSP_CODE        = D.HOSP_CODE       
            //                                           AND C.HOSP_CODE        = D.HOSP_CODE
            //                                           AND E.HOSP_CODE(+)     = D.HOSP_CODE 
            //                                           AND C.LAB_NO           = :f_lab_no
            //                                           AND C.PKCPL3020        = :f_pkcpl3020
            //                                           AND A.PKCPL2010        = C.FKCPL2010
            //                                           AND C.HANGMOG_CODE     = D.HANGMOG_CODE
            //                                           AND C.SPECIMEN_CODE    = D.SPECIMEN_CODE
            //                                           AND C.EMERGENCY        = D.EMERGENCY
            //                                           AND E.CODE(+)          = D.DANUI
            //                                           AND E.CODE_TYPE(+)     = '03'
            //                                         ORDER BY RPAD(D.GUMSA_NAME,100,'0')||RPAD(C.PKCPL3020,10,'0')";

            //            this.grdResult.SetBindVarValue("f_pkcpl3020", pkcpl3020);
            //            this.grdResult.QueryLayout(true);

            //            this.grdResult.QuerySQL = tQuery;

        }

        #region 결과조회버튼
        private void btnBeforeResult_Click(object sender, System.EventArgs e)
        {
            this.CPL3020Q00_Call();
        }
        #endregion

        #region 결과조회 Call
        private void CPL3020Q00_Call()
        {
            string result_date = "";
            if (this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "result_date").Length == 0)
                result_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            else
                result_date = this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "result_date");

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("ToDate", result_date);
            openParams.Add("Bunho", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "bunho"));
            openParams.Add("HangmogCode", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "hangmog_code"));
            openParams.Add("SpecimenCode", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "specimen_code"));

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL3020Q00", IHIS.Framework.ScreenOpenStyle.PopUpSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
        }
        #endregion

        #region 버튼리스트 수행 전
        private bool mIsSaveSuccess = true;
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    if (this.cbxActor.GetDataValue().Length == 0)
                    {
                        XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox1_caption, MessageBoxIcon.Warning);
                        this.cbxActor.Focus();
                        mIsSaveSuccess = false;
                        e.IsBaseCall = false;
                        return;
                    }
                    else if (this.cbxJangbiCode.GetDataValue().Length == 0)
                    {
                        XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox2_caption, MessageBoxIcon.Warning);
                        this.cbxJangbiCode.Focus();
                        mIsSaveSuccess = false;
                        e.IsBaseCall = false;
                        return;
                    }

                    e.IsBaseCall = false;

                    try
                    {
                        // TODO comment use connect cloud
                        /*Service.BeginTransaction();

                        if (!this.grdResult.SaveLayout())
                            throw new Exception();


                        //if (!this.layNoteUpdate.SaveLayout())
                        //    throw new Exception();

                        if (!this.grdNoteUpdate.SaveLayout())
                            throw new Exception();


                        #region [一括選択保存処理]

                        string spName = "PR_CPL_AUTO_CONFIRM_UPDATE";

                        for (int i = 0; i < this.grdPa.DisplayRowCount; i++)
                        {
                            if (this.grdPa.GetItemString(i, "batch_confirm_yn") == "Y"
                                && this.grdPa.GetRowState(i) == DataRowState.Modified)
                            {
                                ArrayList inputList = new ArrayList();
                                ArrayList ouputList = new ArrayList();

                                inputList.Add(this.grdPa.GetItemString(i, "lab_sort"));
                                inputList.Add(this.grdPa.GetItemString(i, "specimen_ser"));
                                inputList.Add(this.grdPa.GetItemString(i, "jundal_gubun"));
                                inputList.Add(this.cbxActor.GetDataValue());
                                inputList.Add("Y");

                                try
                                {
                                    if (!Service.ExecuteProcedure(spName, inputList, ouputList)) throw new Exception(Service.ErrFullMsg);
                                }
                                catch (Exception xe)
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show("実施処理にエラーが発生しました。 \n\r" + xe.Message + "\n\r" + xe.StackTrace, "実施エラー",
                                        MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        #endregion [一括選択保存処理]

                        Service.CommitTransaction();*/

                        // Connect to cloud service
                        //                        UpdateResult updateResult = CPL3020U02SavePerformer();
                        CPL3020U02SaveArgs args = new CPL3020U02SaveArgs();
                        args.GrdResultItemInfo = CreateListCPL3020U00GrdResultItem();
                        args.GrdNoteUpdateItemInfo = CreateListGrdNoteUpdate();
                        args.GrdPaItemInfo = CreateListGrdPa();
                        args.UserId = UserInfo.UserID;
                        args.Gumsaja = this.cbxActor.GetDataValue();
                        UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, CPL3020U02SaveArgs>(args);
                        if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                            updateResult.Result == false)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox3_caption,
                                MessageBoxIcon.Information);
                        }

                        // Save End
                        GrdResultSaveEnd();
                    }
                    catch (Exception ex)
                    {
                        //                        Service.RollbackTransaction();
                        mIsSaveSuccess = false;
						//https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(Resources.XMessageBox4, Resources.XMessageBox4_caption, MessageBoxIcon.Error);
                    }


                    break;

                case FunctionType.Query:

                    this.setAutoConfirmChecked();

                    this.cbxJangbiCode.ExecuteQuery = ExecuteQueryCbxJangbi;
                    this.cbxJangbiCode.SetDictDDLB();

                    if (this.CurrMQLayout == this.grdResult)
                    {
                        e.IsBaseCall = false;
                        this.grdPa.QueryLayout(false);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// GrdResultSaveEnd
        /// </summary>
        private void GrdResultSaveEnd()
        {
            CPL3020U00PrOcsoChkResultMsgArgs chkResultMsgArgs = new CPL3020U00PrOcsoChkResultMsgArgs();
            chkResultMsgArgs.Ocskey = this.grdResult.GetItemString(grdResult.CurrentRowNumber, "fkocs");
            chkResultMsgArgs.UserId = UserInfo.UserID;
            CPL3020U00PrOcsoChkResultMsgResult chkResultMsgResult =
                CloudService.Instance.Submit<CPL3020U00PrOcsoChkResultMsgResult, CPL3020U00PrOcsoChkResultMsgArgs>(
                    chkResultMsgArgs);
            if (chkResultMsgResult == null || chkResultMsgResult.ExecutionStatus != ExecutionStatus.Success)
            {
                XMessageBox.Show("Execute PR_OCSO_CHK_RESULT_MSG fail");
            }

            CPL3020U00PrOcsoChkResultMsgListItemInfo chkResultMsgListItemInfo = chkResultMsgResult.ResultList;
            string t_gwa_ip = "";
            string t_result_msg = "";
            string t_err_flag = "";

            if (!TypeCheck.IsNull(chkResultMsgListItemInfo))
            {
                t_gwa_ip = chkResultMsgListItemInfo.IpValue;
                t_result_msg = chkResultMsgListItemInfo.TextValue;
                t_err_flag = chkResultMsgListItemInfo.ErrFlag;

                if (t_err_flag == "0")
                {
                    XMsgSender.SendToSystem(t_gwa_ip, "NURO", "GUMSAMSG", t_result_msg);
                }
            }
        }

        #endregion

        #region cbxGubun_CheckedChanged
        private void cbxGubun_CheckedChanged(object sender, System.EventArgs e)
        {
            this.grdPa.QueryLayout(false);
        }
        #endregion

        #region 그리드 셀페인팅
        private void grdResult_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (this.grdResult.GetItemString(e.RowNumber, "confirm_yn") == "Y")
            {
                e.BackColor = XColor.XLabelGradientEndColor.Color;
            }
            else
            {
                e.BackColor = Color.White;
            }

            if ((this.grdResult.GetItemString(e.RowNumber, "group_gubun") == "01") || (this.grdResult.GetItemString(e.RowNumber, "group_gubun") == "03"))
                //e.BackColor = XColor.XDisplayBoxGradientEndColor.Color;
                e.ForeColor = Color.Brown;

        }
        #endregion

        private void btnResult_Click(object sender, System.EventArgs e)
        {
            //if ( this.grdResult.RowCount > 0 )
            //{
            //    if ( this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"hangmog_code") == "????" )
            //    {
            //        string msg = (NetInfo.Language == LangMode.Ko ? "확정되지 않은 결과수정은 사유를 입력하지 않아도 가능합니다."
            //            : "確定されていない結果の修正は事由を入力しなくても可能です。");
            //        XMessageBox.Show(msg);
            //    }
            //    else
            //    {
            //        string pkcpl3020 = this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"pkcpl3020");
            //        RESULTINSERT dlg = new RESULTINSERT(this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"lab_no"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"hangmog_code"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"specimen_code"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"emergency"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"before_result"),
            //            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber,"gumsaja"),
            //            pkcpl3020);

            //        dlg.ShowDialog();
            //        if ( dlg.DialogResult == DialogResult.OK)
            //        {
            //            LoadResultByKey(pkcpl3020);
            //        }
            //    }
            //}
            //else
            //{
            //    string msg = (NetInfo.Language == LangMode.Ko ? "입력할 결과가 없습니다."
            //        : "入力できる結果がございません。");
            //    XMessageBox.Show(msg);
            //}
        }


        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    if (e.IsSuccess == true)
                        this.grdResult.QueryLayout(true);
                    break;
                default:
                    break;
            }
        }

        private void btnAllCheck_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.grdResult.RowCount; i++)
            {
                this.grdResult.SetItemValue(i, "confirm_yn", "Y");
            }
        }

        private void btnAllDp_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < this.grdResult.RowCount; i++)
            {
                this.grdResult.SetItemValue(i, "display_yn", "Y");
            }
        }

        #region Command 결과 받기

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "CPLFINDLIB": /* 검체검사 결과 파인드 */

                    if (commandParam.Contains("cpl_result"))
                    {
                        this.grdResult.SetItemValue(grdResult.CurrentRowNumber, "cpl_result", commandParam["cpl_result"].ToString());
                    }

                    break;

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        #endregion

        #region 파인드 버튼 클릭 (결과입력)
        private void grdResult_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        {
            //큰 파인드 박스 띄우기
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("work_tp", 'D');
            openParams.Add("service_name", "CPLFINDLIB");
            openParams.Add("product_name", "cpls51");
            openParams.Add("result_form", grdResult.GetItemString(e.RowNumber, "result_form"));
            XScreen.OpenScreenWithParam(this, "CPLS", "CPLFINDLIB", IHIS.Framework.ScreenOpenStyle.ResponseSizable, ScreenAlignment.ParentTopLeft, openParams);
        }
        #endregion

        #region 시계열 팝업 열고 닫기
        private void btnSigeyul_Click(object sender, System.EventArgs e)
        {
            //multiResultView.ModifyDW();
            //if (pnlSigeyul.Size.Height == 0)
            //    pnlSigeyul.Size = new Size(887, 300);
            //else
            //    pnlSigeyul.Size = new Size(887, 0);
        }
        #endregion

        #region 결과그리드 로우 포커스 체인지(그룹항목 시계열,그래프 조회)
        private void grdResult_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //if (pnlSigeyul.Size.Height > 0)
            //{
            //    if (this.grdResult.GetItemString(e.CurrentRow, "group_hangmog") != this.grdResult.GetItemString(e.PreviousRow, "group_hangmog"))
            //    {
            //        if (tabSigeyul.SelectedIndex == 0)
            //        {
            //            //그룹항목 시계열 자동 조회
            //            this.multiResultView.SetSigeyul(grdResult.GetItemString(grdResult.CurrentRowNumber, "bunho"), grdResult.GetItemString(grdResult.CurrentRowNumber, "group_hangmog"));
            //        }
            //        else if (tabSigeyul.SelectedIndex == 1)
            //        {
            //            //그룹항목 그래프 자동 조회
            //            this.graphResultView.SetGraph(grdResult.GetItemString(grdResult.CurrentRowNumber, "bunho"), grdResult.GetItemString(grdResult.CurrentRowNumber, "group_hangmog"));
            //        }
            //    }
            //}
        }
        #endregion

        #region 텝페이지 클릭
        private void tabSigeyul_SelectionChanged(object sender, System.EventArgs e)
        {
            //if (tabSigeyul.SelectedIndex == 0)
            //{
            //    //그룹항목 시계열 자동 조회
            //    this.multiResultView.SetSigeyul(grdResult.GetItemString(grdResult.CurrentRowNumber, "bunho"), grdResult.GetItemString(grdResult.CurrentRowNumber, "group_hangmog"));
            //}
            //else if (tabSigeyul.SelectedIndex == 1)
            //{
            //    //그룹항목 그래프 자동 조회
            //    this.graphResultView.SetGraph(grdResult.GetItemString(grdResult.CurrentRowNumber, "bunho"), grdResult.GetItemString(grdResult.CurrentRowNumber, "group_hangmog"));
            //}
        }
        #endregion

        #region 결과 상태 이모티 표시
        private void grdPa_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.ColName == "result_status")
            {
                if (e.DataRow["result_yn"].ToString() == "Y")
                    e.Image = this.ImageList.Images[2];

                if (e.DataRow["confirm_yn"].ToString() == "Y")
                    e.Image = this.ImageList.Images[3];
                else if (e.DataRow["confirm_yn"].ToString() == "M")
                    e.Image = this.ImageList.Images[4];
            }
        }
        #endregion

        #region 부모항목 체크시 하위 항목 모두 체크 혹은 언체크
        private void grdResult_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            //부모항목 체크시 하위 항목 모두 체크 혹은 언체크
            for (int i = 0; i < grdResult.RowCount; i++)
            {
                if (e.DataRow["hangmog_code"].ToString() == grdResult.GetItemString(i, "group_hangmog"))
                {
                    if (e.DataRow["hangmog_code"].ToString() != grdResult.GetItemString(i, "hangmog_code"))
                    {
                        grdResult.SetItemValue(i, e.ColName, e.ChangeValue);
                    }
                }
            }
        }
        #endregion

        private void grdPa_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPa.Reset();
            this.laySpecimenInfo.Reset();
            this.dbxSpecimenSer.ResetData();

            this.grdPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdPa.SetBindVarValue("f_gubun", this.cbxGubun.GetDataValue());
            this.grdPa.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdPa.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            //this.grdPa.SetBindVarValue("f_jangbi_code", this.fbxJangbiCode.GetDataValue());
            this.grdPa.SetBindVarValue("f_jangbi_code", this.cbxJangbiCode.GetDataValue());
        }

        private void grdResult_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdResult.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdResult.SetBindVarValue("f_lab_no", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "lab_sort"));
            this.grdResult.SetBindVarValue("f_specimen_ser", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));
            this.grdResult.SetBindVarValue("f_jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
        }

        private void dsvNote_QueryStarting(object sender, CancelEventArgs e)
        {
            this.dsvNote.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.dsvNote.SetBindVarValue("f_specimen_ser", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));
            this.dsvNote.SetBindVarValue("f_jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
        }

        private void fbxNote_DataValidating(object sender, DataValidatingEventArgs e)
        {
            SetMsg("");

            if (e.DataValue == "")
                return;

            this.vsvNote.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            if (this.grdPa.RowCount > 0)
                this.vsvNote.SetBindVarValue("f_jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
            this.vsvNote.SetBindVarValue("f_code", e.DataValue);

            this.vsvNote.QueryLayout();

            if (this.vsvNote.GetItemValue("note").ToString() == "")
            {
                e.Cancel = true;
                SetMsg(Resources.msg, MsgType.Error);
                return;
            }
            dbxNote.SetDataValue(this.vsvNote.GetItemValue("note").ToString());


            //while (this.layNoteUpdate.RowCount > 0)
            //{
            //    this.layNoteUpdate.DeleteRow(0);
            //}

            //while (this.layNoteUpdate.RowCount > 0)
            //{
            //    this.layNoteUpdate.DeleteRow(0);
            //}

            //if(this.layNoteUpdate.RowCount < 1)
            //    this.layNoteUpdate.InsertRow(0);

            //this.layNoteUpdate.SetItemValue(0, "jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
            //this.layNoteUpdate.SetItemValue(0, "specimen_ser", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));
            //this.layNoteUpdate.SetItemValue(0, "code", this.fbxNote.GetDataValue());
            //this.layNoteUpdate.SetItemValue(0, "note", this.dbxNote.GetDataValue());
            //this.layNoteUpdate.SetItemValue(0, "etc_comment", this.txtNote.GetDataValue());

            if (this.grdNoteUpdate.RowCount < 1)
                this.grdNoteUpdate.InsertRow(0);

            this.grdNoteUpdate.SetItemValue(0, "jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
            this.grdNoteUpdate.SetItemValue(0, "specimen_ser", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));
            this.grdNoteUpdate.SetItemValue(0, "code", this.fbxNote.GetDataValue());
            this.grdNoteUpdate.SetItemValue(0, "note", this.dbxNote.GetDataValue());
            this.grdNoteUpdate.SetItemValue(0, "etc_comment", this.txtNote.GetDataValue());
        }

        private void txtNote_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //while (this.layNoteUpdate.RowCount > 0)
            //{
            //    this.layNoteUpdate.DeleteRow(0);
            //}

            //if(this.layNoteUpdate.RowCount < 1)
            //    this.layNoteUpdate.InsertRow(0);

            //this.layNoteUpdate.SetItemValue(0, "jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
            //this.layNoteUpdate.SetItemValue(0, "specimen_ser", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));
            //this.layNoteUpdate.SetItemValue(0, "code", this.fbxNote.GetDataValue());
            //this.layNoteUpdate.SetItemValue(0, "note", this.dbxNote.GetDataValue());
            //this.layNoteUpdate.SetItemValue(0, "etc_comment", this.txtNote.GetDataValue());

            if (this.grdNoteUpdate.RowCount < 1)
                this.grdNoteUpdate.InsertRow(0);

            this.grdNoteUpdate.SetItemValue(0, "jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
            this.grdNoteUpdate.SetItemValue(0, "specimen_ser", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser"));
            this.grdNoteUpdate.SetItemValue(0, "code", this.fbxNote.GetDataValue());
            this.grdNoteUpdate.SetItemValue(0, "note", this.dbxNote.GetDataValue());
            this.grdNoteUpdate.SetItemValue(0, "etc_comment", this.txtNote.GetDataValue());
        }


        private void grdResult_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            if (e.RowState == DataRowState.Modified)
            {
                this.grdResult.SetItemValue(e.RowNumber, "gumsaja", this.cbxActor.GetDataValue());
            }
        }

        private void grdResult_SaveEnd(object sender, SaveEndEventArgs e)
        {

            CPL3020U00PrOcsoChkResultMsgArgs chkResultMsgArgs = new CPL3020U00PrOcsoChkResultMsgArgs();
            chkResultMsgArgs.Ocskey = this.grdResult.GetItemString(grdResult.CurrentRowNumber, "fkocs");
            chkResultMsgArgs.UserId = UserInfo.UserID;
            CPL3020U00PrOcsoChkResultMsgResult chkResultMsgResult =
                CloudService.Instance.Submit<CPL3020U00PrOcsoChkResultMsgResult, CPL3020U00PrOcsoChkResultMsgArgs>(
                    chkResultMsgArgs);
            if (chkResultMsgResult == null || chkResultMsgResult.ExecutionStatus != ExecutionStatus.Success)
            {
                XMessageBox.Show("Execute PR_OCSO_CHK_RESULT_MSG fail");
            }

            CPL3020U00PrOcsoChkResultMsgListItemInfo chkResultMsgListItemInfo = chkResultMsgResult.ResultList;
            string t_gwa_ip = "";
            string t_result_msg = "";
            string t_err_flag = "";

            if (!TypeCheck.IsNull(chkResultMsgListItemInfo))
            {
                t_gwa_ip = chkResultMsgListItemInfo.IpValue;
                t_result_msg = chkResultMsgListItemInfo.TextValue;
                t_err_flag = chkResultMsgListItemInfo.ErrFlag;

                if (t_err_flag == "0")
                {
                    XMsgSender.SendToSystem(t_gwa_ip, "NURO", "GUMSAMSG", t_result_msg);
                }
            }

            // TODO comment use connect cloud
            /*ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(this.grdResult.GetItemString(grdResult.CurrentRowNumber, "fkocs"));
            inputList.Add(UserInfo.UserID);

            Service.ExecuteProcedure("PR_OCSO_CHK_RESULT_MSG", inputList, outputList);

            string t_gwa_ip = "";
            string t_result_msg = "";
            string t_err_flag = "";

            if (!TypeCheck.IsNull(outputList))
            {
                t_gwa_ip = outputList[0].ToString();
                t_result_msg = outputList[1].ToString();
                t_err_flag = outputList[2].ToString();

                if (t_err_flag == "0")
                {
                    XMsgSender.SendToSystem(t_gwa_ip, "NURO" , "GUMSAMSG", t_result_msg);
                }
            }*/
        }

        #region connect to cloud
        /// <summary>
        /// LoadDataCbxActor
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryFwkActor(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboADM3200FwkActorArgs args = new ComboADM3200FwkActorArgs();
            //ComboResult result = CacheService.Instance.Get<ComboADM3200FwkActorArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_ADM3200_FWKACTOR,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<ComboADM3200FwkActorArgs, ComboResult>(
                args, delegate(ComboResult cboResult)
                {
                    return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
                           cboResult.ComboItem.Count > 0;
                });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }

            return dataList;
        }

        /// <summary>
        /// ExecuteQueryFwkNote
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryFwkNote(BindVarCollection var)
        {
            List<object[]> res = new List<object[]>();
            CPL3020U00FwkNoteGubunArgs args = new CPL3020U00FwkNoteGubunArgs();
            args.JundalGubun = var["f_jundal_gubun"].VarValue;
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, CPL3020U00FwkNoteGubunArgs>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstListItemInfo = comboResult.ComboItem;
                if (lstListItemInfo != null && lstListItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lstListItemInfo)
                    {
                        res.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }

                }
            }
            return res;
        }

        /// <summary>
        /// layPrintName
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryVsvNote(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            CPL3020U00VsvNoteArgs args = new CPL3020U00VsvNoteArgs();
            args.JundalGubun = bc["f_jundal_gubun"].VarValue;
            args.Code = bc["f_code"].VarValue;
            CPL3020U00VsvNoteResult result =
                CloudService.Instance.Submit<CPL3020U00VsvNoteResult, CPL3020U00VsvNoteArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[] { result.Note });
            }

            return res;
        }

        /// <summary>
        /// Get data when grdPa row focus changed
        /// </summary>
        /// <param name="aSpecimentSer"></param>
        /// <param name="aGwa"></param>
        /// <param name="aOrderDate"></param>
        /// <param name="aHoDong"></param>
        /// <param name="aSpecimenSer"></param>
        /// <param name="aJundalGubun"></param>
        /// <returns></returns>
        private CPL3020U00GrdPaRowFocusChangedResult EnsureCPL3020U00GrdPaRowFocusChangedResultProceed(
            string aSpecimentSer, string aSpecimenSer, string aJundalGubun)
        {
            CPL3020U00GrdPaRowFocusChangedArgs vCPL3020U00GrdPaRowFocusChangedArgs =
                new CPL3020U00GrdPaRowFocusChangedArgs();
            vCPL3020U00GrdPaRowFocusChangedArgs.SpecimentSer = aSpecimentSer;
            vCPL3020U00GrdPaRowFocusChangedArgs.SpecimenSer = aSpecimenSer;
            vCPL3020U00GrdPaRowFocusChangedArgs.JundalGubun = aJundalGubun;
            return
                CloudService.Instance.Submit<CPL3020U00GrdPaRowFocusChangedResult, CPL3020U00GrdPaRowFocusChangedArgs>(
                    vCPL3020U00GrdPaRowFocusChangedArgs);
        }

        /// <summary>
        /// ExecuteQueryCbxJangbi
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryCbxJangbi(BindVarCollection var)
        {
            IList<object[]> dataList = new List<object[]>();
            CPL3020U02CbxJangbiArgs args = new CPL3020U02CbxJangbiArgs();
            //ComboResult result = CacheService.Instance.Get<CPL3020U02CbxJangbiArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_CPL_CBO_JANGBI_KEY,
            //    args, delegate(ComboResult cboResult)
            //    {
            //        return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
            //               cboResult.ComboItem.Count > 0;
            //    });
            ComboResult result = CacheService.Instance.Get<CPL3020U02CbxJangbiArgs, ComboResult>(args, delegate(ComboResult cboResult)
                {
                    return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
                           cboResult.ComboItem.Count > 0;
                });
            if (result.ExecutionStatus == ExecutionStatus.Success && result.ComboItem != null && result.ComboItem.Count > 0)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }

            return dataList;
        }

        /// <summary>
        /// DsvNote 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryDsvNote(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();

            if (vCPL3020U00GrdPaRowFocusChangedResult != null &&
                vCPL3020U00GrdPaRowFocusChangedResult.ExecutionStatus == ExecutionStatus.Success &&
                vCPL3020U00GrdPaRowFocusChangedResult.DsvNoteItem != null)
            {
                foreach (CPL3020U00DsvNoteListItemInfo item in vCPL3020U00GrdPaRowFocusChangedResult.DsvNoteItem)
                {
                    object[] objects =
                    {
                        item.JundalPart,
                        item.SpecimenSer,
                        item.Note,
                        item.Code,
                        item.EtcComment
                    };
                    res.Add(objects);
                }
            }
            return res;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdPa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3020U02GrdPaArgs vCPL3020U02GrdPaArgs = new CPL3020U02GrdPaArgs();
            vCPL3020U02GrdPaArgs.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            vCPL3020U02GrdPaArgs.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            vCPL3020U02GrdPaArgs.JangbiCode = bc["f_jangbi_code"] != null ? bc["f_jangbi_code"].VarValue : "";
            CPL3020U02GrdPaResult result = CloudService.Instance.Submit<CPL3020U02GrdPaResult, CPL3020U02GrdPaArgs>(vCPL3020U02GrdPaArgs);
            if (result != null)
            {
                foreach (CPL3020U00GrdPaListItemInfo item in result.GrdPaItemInfo)
                {
                    object[] objects = 
				{ 
					item.LabNo, 
					item.Suname, 
					item.SpecimenSer, 
					item.LabSort, 
					item.PartJubsuDate, 
					item.JundalGubun, 
					item.Gubun, 
					item.ResultYn, 
					item.ConfirmYn, 
					item.BatchConfirmYn, 
					item.DataRowState
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGrdResult
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryGrdResult(BindVarCollection var)
        {
            IList<object[]> lstObject = new List<object[]>();
            CPL3020U02GrdResultArgs args = new CPL3020U02GrdResultArgs();
            args.JundalGubun = var["f_jundal_gubun"].VarValue;
            args.LabNo = var["f_lab_no"].VarValue;
            args.SpecimenSer = var["f_specimen_ser"].VarValue;

            CPL3020U02GrdResultResult result =
                CloudService.Instance.Submit<CPL3020U02GrdResultResult, CPL3020U02GrdResultArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<CPL3020U00GrdResultListItemInfo> lstItemInfos = result.GrdResultItemInfo;
                if (lstItemInfos != null && lstItemInfos.Count > 0)
                {
                    foreach (CPL3020U00GrdResultListItemInfo itemInfo in lstItemInfos)
                    {
                        lstObject.Add(new object[]
                        {
                            itemInfo.Pkcpl3020,
                            itemInfo.GumsaName,
                            itemInfo.StandardYn,
                            itemInfo.CplResult,
                            itemInfo.ConfirmYn,
                            itemInfo.BeforeResult,
                            itemInfo.PanicYn,
                            itemInfo.DeltaYn,
                            itemInfo.DanuiName,
                            itemInfo.Standard,
                            itemInfo.Comments,
                            itemInfo.Fkocs,
                            itemInfo.Fkcpl2010,
                            itemInfo.LabNo,
                            itemInfo.HangmogCode,
                            itemInfo.SpecimenCode,
                            itemInfo.Emergency,
                            itemInfo.Gumsaja,
                            itemInfo.Bunho,
                            itemInfo.ResultDate,
                            itemInfo.SpecimenSer,
                            itemInfo.ResultForm,
                            itemInfo.SourceGumsa,
                            itemInfo.GroupGubun,
                            itemInfo.GroupHangmog,
                            itemInfo.DisplayYn,
                            itemInfo.KeyValue
                        });
                    }
                }
            }
            return lstObject;
        }

        /// <summary>
        /// CPL3020U02SavePerformer
        /// </summary>
        /// <returns></returns>
        private UpdateResult CPL3020U02SavePerformer()
        {
            CPL3020U02SaveArgs args = new CPL3020U02SaveArgs();
            args.GrdResultItemInfo = CreateListCPL3020U00GrdResultItem();
            args.GrdNoteUpdateItemInfo = CreateListGrdNoteUpdate();
            args.GrdPaItemInfo = CreateListGrdPa();
            args.UserId = UserInfo.UserID;
            args.Gumsaja = this.cbxActor.GetDataValue();
            return CloudService.Instance.Submit<UpdateResult, CPL3020U02SaveArgs>(args);
        }

        /// <summary>
        /// CreateListCPL3020U00GrdResultItem
        /// </summary>
        /// <returns></returns>
        private List<CPL3020U00GrdResultListItemInfo> CreateListCPL3020U00GrdResultItem()
        {
            List<CPL3020U00GrdResultListItemInfo> lstGrdResultListItemInfo = new List<CPL3020U00GrdResultListItemInfo>();
            for (int i = 0; i < grdResult.RowCount; i++)
            {
                if (grdResult.GetRowState(i) == DataRowState.Added || grdResult.GetRowState(i) == DataRowState.Modified)
                {
                    CPL3020U00GrdResultListItemInfo grdResultListItemInfo = new CPL3020U00GrdResultListItemInfo();
                    grdResultListItemInfo.Pkcpl3020 = grdResult.GetItemString(i, "pkcpl3020");
                    grdResultListItemInfo.GumsaName = grdResult.GetItemString(i, "gumsa_name");
                    grdResultListItemInfo.StandardYn = grdResult.GetItemString(i, "standard_yn");
                    grdResultListItemInfo.CplResult = grdResult.GetItemString(i, "cpl_result");
                    grdResultListItemInfo.ConfirmYn = grdResult.GetItemString(i, "confirm_yn");
                    grdResultListItemInfo.BeforeResult = grdResult.GetItemString(i, "before_result");
                    grdResultListItemInfo.PanicYn = grdResult.GetItemString(i, "panic_yn");
                    grdResultListItemInfo.DeltaYn = grdResult.GetItemString(i, "delta_yn");
                    grdResultListItemInfo.DanuiName = grdResult.GetItemString(i, "danui_name");
                    grdResultListItemInfo.Standard = grdResult.GetItemString(i, "standard");
                    grdResultListItemInfo.Comments = grdResult.GetItemString(i, "comments");
                    grdResultListItemInfo.Fkocs = grdResult.GetItemString(i, "fkocs");
                    grdResultListItemInfo.Fkcpl2010 = grdResult.GetItemString(i, "fkcpl2010");
                    grdResultListItemInfo.LabNo = grdResult.GetItemString(i, "lab_no");
                    grdResultListItemInfo.HangmogCode = grdResult.GetItemString(i, "hangmog_code");
                    grdResultListItemInfo.SpecimenCode = grdResult.GetItemString(i, "specimen_code");
                    grdResultListItemInfo.Emergency = grdResult.GetItemString(i, "emergency");
                    grdResultListItemInfo.Bunho = grdResult.GetItemString(i, "bunho");
                    grdResultListItemInfo.ResultDate = grdResult.GetItemString(i, "result_date");
                    grdResultListItemInfo.SpecimenSer = grdResult.GetItemString(i, "specimen_ser");
                    grdResultListItemInfo.ResultForm = grdResult.GetItemString(i, "result_form");
                    grdResultListItemInfo.SourceGumsa = grdResult.GetItemString(i, "source_gumsa");
                    grdResultListItemInfo.GroupGubun = grdResult.GetItemString(i, "group_gubun");
                    grdResultListItemInfo.GroupHangmog = grdResult.GetItemString(i, "group_hangmog");
                    grdResultListItemInfo.DisplayYn = grdResult.GetItemString(i, "display_yn");

                    if (grdResult.GetRowState(i) == DataRowState.Modified)
                    {
                        grdResultListItemInfo.Gumsaja = this.cbxActor.GetDataValue();
                    }
                    grdResultListItemInfo.DataRowState = grdResult.GetRowState(i).ToString();

                    lstGrdResultListItemInfo.Add(grdResultListItemInfo);
                }
            }
            return lstGrdResultListItemInfo;
        }

        /// <summary>
        /// CreateListGrdNoteUpdate
        /// </summary>
        /// <returns></returns>
        private List<CPL3020U00GrdNoteUpdateInfo> CreateListGrdNoteUpdate()
        {
            List<CPL3020U00GrdNoteUpdateInfo> lstGrdResultListItemInfo = new List<CPL3020U00GrdNoteUpdateInfo>();
            for (int i = 0; i < grdNoteUpdate.RowCount; i++)
            {
                if (grdNoteUpdate.GetRowState(i) == DataRowState.Added ||
                    grdNoteUpdate.GetRowState(i) == DataRowState.Modified)
                {
                    CPL3020U00GrdNoteUpdateInfo noteUpdateInfo = new CPL3020U00GrdNoteUpdateInfo();
                    noteUpdateInfo.JundalGubun = grdNoteUpdate.GetItemString(i, "jundal_gubun");
                    noteUpdateInfo.SpecimenSer = grdNoteUpdate.GetItemString(i, "specimen_ser");
                    noteUpdateInfo.Code = grdNoteUpdate.GetItemString(i, "code");
                    noteUpdateInfo.Note = grdNoteUpdate.GetItemString(i, "note");
                    noteUpdateInfo.EtcComment = grdNoteUpdate.GetItemString(i, "etc_comment");
                    noteUpdateInfo.DataRowState = grdNoteUpdate.GetRowState(i).ToString();

                    lstGrdResultListItemInfo.Add(noteUpdateInfo);
                }

            }
            return lstGrdResultListItemInfo;
        }

        /// <summary>
        /// create CPL3020U00GrdPaListItemInfo
        /// </summary>
        /// <returns></returns>
        private List<CPL3020U00GrdPaListItemInfo> CreateListGrdPa()
        {
            List<CPL3020U00GrdPaListItemInfo> lstGrdPaListItemInfo = new List<CPL3020U00GrdPaListItemInfo>();
            for (int i = 0; i < grdPa.RowCount; i++)
            {
                if (grdPa.GetRowState(i) == DataRowState.Added || grdPa.GetRowState(i) == DataRowState.Modified)
                {
                    CPL3020U00GrdPaListItemInfo itemInfo = new CPL3020U00GrdPaListItemInfo();
                    itemInfo.LabNo = grdPa.GetItemString(i, "lab_no");
                    itemInfo.Suname = grdPa.GetItemString(i, "suname");
                    itemInfo.SpecimenSer = grdPa.GetItemString(i, "specimen_ser");
                    itemInfo.LabSort = grdPa.GetItemString(i, "lab_sort");
                    itemInfo.PartJubsuDate = grdPa.GetItemString(i, "part_jubsu_date");
                    itemInfo.JundalGubun = grdPa.GetItemString(i, "jundal_gubun");
                    itemInfo.Gubun = grdPa.GetItemString(i, "gubun");
                    itemInfo.ResultYn = grdPa.GetItemString(i, "result_yn");
                    itemInfo.ConfirmYn = grdPa.GetItemString(i, "confirm_yn");
                    itemInfo.BatchConfirmYn = grdPa.GetItemString(i, "batch_confirm_yn");
                    itemInfo.DataRowState = grdPa.GetRowState(i).ToString();
                    lstGrdPaListItemInfo.Add(itemInfo);
                }
            }
            return lstGrdPaListItemInfo;
        }

        /// <summary>
        /// ExecuteQueryFwkResult
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryFwkResult(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL3020U00FwkResultInputSQLArgs fwkResultInputSqlArgs = new CPL3020U00FwkResultInputSQLArgs();
            fwkResultInputSqlArgs.Dummy = bc["f_dummy"].VarValue;
            fwkResultInputSqlArgs.CodeType = bc["f_code_type"].VarValue;
            fwkResultInputSqlArgs.ResultForm = bc["f_result_form"].VarValue;

            CPL3020U00FwkResultInputSQLResult inputSqlResult =
                CloudService.Instance.Submit<CPL3020U00FwkResultInputSQLResult, CPL3020U00FwkResultInputSQLArgs>(
                    fwkResultInputSqlArgs);
            if (inputSqlResult != null && inputSqlResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = inputSqlResult.FwkResultList;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo itemInfo in listItemInfo)
                    {
                        res.Add(new object[] { itemInfo.Code, itemInfo.CodeName });
                    }

                }
            }
            return res;
        }
        #endregion

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            CPL3020U02 parent;

            public XSavePerformer(CPL3020U02 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();

                DataTable dt = new DataTable();

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                switch (callerID)
                {
                    /* cpl2010 : MASTER */
                    case '1':

                        if (item.RowState == DataRowState.Modified)
                        {
                            if (item.BindVarList["f_confirm_yn"].VarValue == "Y")
                            {
                                cmdText = @"UPDATE CPL3020
                                               SET UPD_ID       = :q_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , CONFIRM_YN   = 'Y'
                                                 , CONFIRM_DATE = TRUNC(SYSDATE)
                                                 , GUMSAJA1     = :f_gumsaja
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND PKCPL3020    = :f_pkcpl3020";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                            }
                            else if (item.BindVarList["f_confirm_yn"].VarValue == "N")
                            {
                                cmdText = @"UPDATE CPL3020
                                               SET UPD_ID       = :q_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , CONFIRM_YN   = 'N'
                                                 , CONFIRM_DATE = NULL
                                                 , GUMSAJA1     = NULL
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND PKCPL3020    = :f_pkcpl3020";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                            }

                            cmdText = @"SELECT IN_OUT_GUBUN
                                             , DECODE(IN_OUT_GUBUN, 'I', FKOCS2003, FKOCS1003)  FKOCS
                                          FROM CPL2010
                                         WHERE HOSP_CODE = :f_hosp_code
                                           AND PKCPL2010 = :f_fkcpl2010";

                            dt.Clear();
                            dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

                            string t_in_out_gubun = "";
                            string t_fkocs = "";

                            if (!TypeCheck.IsNull(dt))
                            {
                                t_in_out_gubun = dt.Rows[0]["in_out_gubun"].ToString();
                                t_fkocs = dt.Rows[0]["fkocs"].ToString();
                            }

                            if (item.BindVarList["f_cpl_result"].VarValue == "")
                            {
                                cmdText = @"UPDATE CPL3020
                                               SET UPD_ID      = :q_user_id
                                                 , UPD_DATE    = SYSDATE
                                                 , RESULT_YN   = 'N'
                                                 , RESULT_DATE = NULL
                                                 , RESULT_TIME = NULL
                                                 , CPL_RESULT  = NULL
                                                 , GUMSAJA     = NULL
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND PKCPL3020   = :f_pkcpl3020";
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"UPDATE CPL3010
                                               SET UPD_ID       = :q_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , RESULT_DATE  = NULL
                                                 , RESULT_TIME  = NULL
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND LAB_NO       = :f_lab_no
                                               AND SPECIMEN_SER = :f_specimen_ser  ";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }

                                //inputList.Clear();
                                //outputList.Clear();

                                //inputList.Add(t_in_out_gubun);
                                //inputList.Add(t_fkocs);
                                //inputList.Add(DBNull.Value);
                                //inputList.Add(DBNull.Value);

                                if (!Service.ExecuteProcedure("PR_OCS_UPDATE_RESULT", t_in_out_gubun, t_fkocs, DBNull.Value, DBNull.Value))
                                {
                                    XMessageBox.Show(Resources.XMessageBox6 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                #region Compare standard_result and cpl_result
                                //cmdText = @"SELECT A.FROM_STANDARD  FROM_STANDARD
                                //                                                 , A.TO_STANDARD    TO_STANDARD
                                //                                                 , A.SPECIMEN_CODE  SPECIMEN_CODE
                                //                                                 , A.EMERGENCY      EMERGENCY
                                //                                                 , B.ORDER_DATE     ORDER_DATE
                                //                                              FROM CPL2010 B
                                //                                                 , CPL3020 A
                                //                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                //                                               AND B.HOSP_CODE    = A.HOSP_CODE
                                //                                               AND A.PKCPL3020    = :f_pkcpl3020
                                //                                               AND B.PKCPL2010    = A.FKCPL2010";
                                //                                dt.Clear();
                                //                                dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

                                //                                string t_from_standard = "";
                                //                                string t_to_standard = "";
                                //                                string t_specimen_code = "";
                                //                                string t_emergency = "";
                                //                                string t_order_date = "";

                                //                                if (!TypeCheck.IsNull(dt))
                                //                                {
                                //                                    t_from_standard = dt.Rows[0]["from_standard"].ToString();
                                //                                    t_to_standard = dt.Rows[0]["to_standard"].ToString();
                                //                                    t_specimen_code = dt.Rows[0]["specimen_code"].ToString();
                                //                                    t_emergency = dt.Rows[0]["emergency"].ToString();
                                //                                    t_order_date = dt.Rows[0]["order_date"].ToString();
                                //                                }

                                //                                inputList.Clear();
                                //                                outputList.Clear();

                                //                                inputList.Add(item.BindVarList["f_cpl_result"].VarValue);
                                //                                inputList.Add(t_from_standard);
                                //                                inputList.Add(t_to_standard);

                                //                                if (!Service.ExecuteProcedure("PR_CPL_NUM_STANDARD_CHECK", inputList, outputList))
                                //                                {
                                //                                    XMessageBox.Show("保存処理中にエラーが発生しました。\r\n PR_CPL_NUM_STANDARD_CHECK \r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                                //                                    return false;
                                //                                }

                                //                                string t_standard_yn = "";
                                //                                if (!TypeCheck.IsNull(outputList))
                                //                                {
                                //                                    t_standard_yn = outputList[0].ToString();
                                //                                }

                                //                                inputList.Clear();
                                //                                outputList.Clear();

                                //                                inputList.Add(item.BindVarList["f_bunho"].VarValue);
                                //                                inputList.Add(t_order_date);
                                //                                inputList.Add(item.BindVarList["f_hangmog_code"].VarValue);
                                //                                inputList.Add(t_specimen_code);
                                //                                inputList.Add(t_emergency);
                                //                                inputList.Add(item.BindVarList["f_cpl_result"].VarValue);
                                //                                inputList.Add(t_order_date);

                                //                                if (!Service.ExecuteProcedure("PR_CPL_PANIC_CHK", inputList, outputList))
                                //                                {
                                //                                    XMessageBox.Show("保存処理中にエラーが発生しました。\r\n PR_CPL_PANIC_CHK \r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                                //                                    return false;
                                //                                }

                                //                                string t_panic_yn = "";
                                //                                if (!TypeCheck.IsNull(outputList))
                                //                                {
                                //                                    t_panic_yn = outputList[0].ToString();
                                //}
                                #endregion Compare standard_result and cpl_result

                                cmdText = @"UPDATE CPL3020
                                               SET UPD_ID       = :q_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , RESULT_YN    = 'Y'
                                                 --, STANDARD_YN  = :t_standard_yn
                                                 --, PANIC_YN     = :t_panic_yn
                                                 , RESULT_DATE  = TRUNC(SYSDATE)
                                                 , RESULT_TIME  = TO_CHAR(SYSDATE,'HH24MI')
                                                 , CPL_RESULT   = :f_cpl_result
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND PKCPL3020    = :f_pkcpl3020";

                                //item.BindVarList.Add("t_standard_yn", t_standard_yn);
                                //item.BindVarList.Add("t_panic_yn", t_panic_yn);

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE CPL3010
                                               SET UPD_ID       = :q_user_id
                                                 , UPD_DATE     = SYSDATE
                                                 , RESULT_DATE  = TRUNC(SYSDATE)
                                                 , RESULT_TIME  = TO_CHAR(SYSDATE,'HH24MI')
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND LAB_NO       = :f_lab_no
                                               AND SPECIMEN_SER = :f_specimen_ser";

                                //item.BindVarList.Add("t_standard_yn", t_standard_yn);
                                //item.BindVarList.Add("t_panic_yn", t_panic_yn);

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }

                                if (!Service.ExecuteProcedure("PR_OCS_UPDATE_RESULT", t_in_out_gubun, t_fkocs, "CPL", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                                {
                                    XMessageBox.Show(Resources.XMessageBox6 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                    return false;
                                }
                            }

                            cmdText = @"UPDATE CPL3020
                                           SET UPD_ID       = :q_user_id
                                             , UPD_DATE     = SYSDATE
                                             , COMMENTS     = :f_comments
                                             , DISPLAY_YN   = :f_display_yn
                                         WHERE HOSP_CODE    = :f_hosp_code
                                           AND PKCPL3020    = :f_pkcpl3020";

                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                {
                                    XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                    return false;
                                }
                            }

                            ///*기준치 연산식*/
                            //if (!Service.ExecuteProcedure("PR_CPL_CAL_INSERT_BASE_RESULT", 
                            //                                item.BindVarList["f_specimen_ser"].VarValue ,
                            //                                item.BindVarList["f_hangmog_code"].VarValue ,
                            //                                item.BindVarList["f_cpl_result"].VarValue  ))
                            //{
                            //    XMessageBox.Show("保存処理中にエラーが発生しました。\r\n PR_OCS_UPDATE_RESULT\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                            //    return false;
                            //} 

                        }

                        break;

                    /* 주의사항 저장 */
                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM CPL2090
                                                             WHERE HOSP_CODE    = :f_hosp_code
                                                               AND JUNDAL_PART  = :f_jundal_gubun
                                                               AND SPECIMEN_SER = :f_specimen_ser)";

                                object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                string t_exist_yn = "";

                                if (!TypeCheck.IsNull(retVal))
                                {
                                    t_exist_yn = retVal.ToString();
                                }

                                if (t_exist_yn == "Y")
                                {
                                    cmdText = @" UPDATE CPL2090
                                                   SET UPD_ID       = :q_user_id
                                                     , UPD_DATE     = SYSDATE
                                                     , NOTE         = :f_note
                                                     , CODE         = :f_code
                                                     , ETC_COMMENT  = :f_etc_comment
                                                 WHERE HOSP_CODE    = :f_hosp_code
                                                   AND JUNDAL_PART  = :f_jundal_gubun
                                                   AND SPECIMEN_SER = :f_specimen_ser";
                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                        {
                                            XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    cmdText = @"INSERT INTO CPL2090 (
                                                      SYS_DATE,         SYS_ID,          
                                                      UPD_DATE,         UPD_ID,         HOSP_CODE, 
                                                      JUNDAL_PART,      SPECIMEN_SER,    
                                                      CODE,             NOTE        ,   ETC_COMMENT
                                                    ) VALUES (
                                                      SYSDATE,          :q_user_id,         
                                                      SYSDATE,          :q_user_id,     :f_hosp_code, 
                                                      :f_jundal_gubun,  :f_specimen_ser, 
                                                      :f_code,          :f_note        , :f_etc_comment)";

                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        XMessageBox.Show(Resources.XMessageBox5 + Service.ErrFullMsg, Resources.XMessageBox5_Caption, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }

                                break;
                        }
                        break;
                }

                return true;
            }

        }
        #endregion


        private void fwkNote_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkNote.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkNote.SetBindVarValue("f_jundal_gubun", this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "jundal_gubun"));
        }

        private void fwkResult_QueryStarting(object sender, CancelEventArgs e)
        {
            // TODO comment use connect cloud
            /*string cmdText = @"SELECT 'Y'                                 
                                  FROM DUAL                                      
                                 WHERE EXISTS ( SELECT 'X'                       
                                                  FROM CPL0155 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND A.RESULT_CODE_GUBUN = :f_result_form) ";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);
            bc.Add("f_result_form", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "result_form"));

            object retVal = Service.ExecuteScalar(cmdText, bc);*/

            // Connect to cloud service
            CPL3020U00FwkResultGetYArgs args = new CPL3020U00FwkResultGetYArgs();
            args.ResultForm = this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "result_form");
            CPL3020U00FwkResultGetYResult getYResult =
                CloudService.Instance.Submit<CPL3020U00FwkResultGetYResult, CPL3020U00FwkResultGetYArgs>(args);

            string t_dummy = "N";
            if (getYResult != null && getYResult.ExecutionStatus == ExecutionStatus.Success && !TypeCheck.IsNull(getYResult.YValue))
            {
                t_dummy = getYResult.YValue;
            }


            /*if (!TypeCheck.IsNull(retVal))
            {
                t_dummy = retVal.ToString();    
            }

            if (t_dummy == "N")
            {
                fwkResult.InputSQL = @"SELECT CODE
                                            , CODE_NAME
                                         FROM CPL0109
                                        WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                          AND ((CODE        LIKE '%'||:f_find1||'%')
                                           OR  (CODE_NAME   LIKE '%'||:f_find1||'%'))
                                          AND CODE_TYPE     = '38'
                                        ORDER BY CODE";
            }
            else
            {
                fwkResult.InputSQL = @"SELECT CODE
                                            , CODE_NAME
                                         FROM CPL0155
                                        WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                          AND ((CODE        LIKE '%'||:f_find1||'%')
                                           OR  (CODE_NAME   LIKE '%'||:f_find1||'%'))
                                          AND RESULT_CODE_GUBUN    = :f_result_form
                                        ORDER BY CODE  ";
                this.fwkResult.SetBindVarValue("f_result_form", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "result_form"));
            }*/

            this.fwkResult.SetBindVarValue("f_code_type", "38");
            this.fwkResult.SetBindVarValue("f_dummy", t_dummy);
            this.fwkResult.SetBindVarValue("f_result_form",
            this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "result_form"));
            this.fwkResult.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdPa_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.grdPa.RowCount < 1)
                this.grdResult.Reset();
        }

        private void grdResult_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //if (this.grdResult.RowCount < 1)
            //{
            //    this.multiResultView.ResetData();
            //    this.graphResultView.ResetData();
            //}
        }

        private void CPL3020U02_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsSaveSuccess)
                e.Cancel = true;

            mIsSaveSuccess = true;

        }

        private void cbxJangbiCode_DataValidating(object sender, DataValidatingEventArgs e)
        {

        }

        private void dtpFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.grdPa.QueryLayout(false);
        }

        private void dtpToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.grdPa.QueryLayout(false);
        }

        private void btnEquipResult_Click(object sender, EventArgs e)
        {
            if (this.grdPa.RowCount < 1) return;

            string equip_code = this.cbxJangbiCode.GetDataValue();
            string equip_name = this.cbxJangbiCode.Text;
            string from_date = this.dtpFromDate.GetDataValue();
            string to_date = this.dtpToDate.GetDataValue();

            string suname = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "suname");
            string specimen_ser = this.grdPa.GetItemString(this.grdPa.CurrentRowNumber, "specimen_ser");

            RESULTMAP dlg = new RESULTMAP(equip_code, equip_name, from_date, to_date, suname, specimen_ser);

            dlg.ShowDialog();

            if (dlg.procYN.Equals("Y"))
            {
                XMessageBox.Show(Resources.XMessageBox7, Resources.XMessageBox7_Caption, MessageBoxIcon.Information);

                this.grdPa.QueryLayout(false);
            }
        }

        private void grdResult_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void btnOutResult_Click(object sender, EventArgs e)
        {
            //TestFileLoad aOutMapForm = new TestFileLoad();
            TestFileLoad aOutMapForm = new TestFileLoad(cbxJangbiCode.GetDataValue());
            aOutMapForm.ShowDialog();
        }

        private void cbxJangbiCode_SelectedValueChanged(object sender, EventArgs e)
        {
            setAutoConfirmChecked();

            this.grdPa.QueryLayout(false);
        }
    }


}

