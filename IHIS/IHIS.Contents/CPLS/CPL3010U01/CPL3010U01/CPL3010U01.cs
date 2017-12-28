using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text;
using IHIS.CPLS.Properties;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using System.Threading;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL3010U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class CPL3010U01 : IHIS.Framework.XScreen
    {
        #region Auto-gen code
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XLabel xLabel10;
        private IHIS.Framework.XDisplayBox dbxJubsuTime;
        private IHIS.Framework.XDisplayBox dbxGwa;
        private IHIS.Framework.XDisplayBox dbxInOutGubun;
        private IHIS.Framework.XDisplayBox dbxJubsuDate;
        private IHIS.Framework.XDisplayBox dbxSpecimenName;
        private IHIS.Framework.XDisplayBox dbxSpecimenCode;
        private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XDatePicker dtpJubsuDate;
        private IHIS.Framework.XTextBox txtJubsuja;
        private IHIS.Framework.XDisplayBox dbxJubsujaName;
        private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XDisplayBox dbxHoDong;
        private IHIS.Framework.XDisplayBox dbxHoCode;
        private IHIS.Framework.XDisplayBox dbxJu;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XDisplayBox dbxSex;
        private IHIS.Framework.XDisplayBox dbxAge;
        private IHIS.Framework.XEditGrid grdHangmog;
        private IHIS.Framework.XMstGrid grdPa;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
        private IHIS.Framework.XEditGridCell xEditGridCell45;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
        private IHIS.Framework.XButton btnFile;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XButton btnResultLoad;
        private System.Windows.Forms.Splitter splitter2;
        private IHIS.Framework.XEditGrid grdResult;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell48;
        private IHIS.Framework.XEditGridCell xEditGridCell49;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell57;
        private System.Windows.Forms.ToolTip toolTip1;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XDatePicker dtpToJubsuDate;
        private IHIS.Framework.XEditMask txtFromSeq;
        private IHIS.Framework.XEditMask txtToSeq;
        private IHIS.Framework.XButton btnPrePrint;
    //    private IHIS.Framework.XDataWindow dwPrint2;
        private IHIS.Framework.XDisplayBox dbxMaxSpecimenSer;
        private IHIS.Framework.XDisplayBox dbxMaxDate;
        private IHIS.Framework.XDisplayBox dbxMaxTime;
        private IHIS.Framework.XRadioButton cbxJubsuDate;
        private IHIS.Framework.XRadioButton cbxSpecimenSer;
        private IHIS.Framework.XEditMask txtFromSpecimenSer;
        private IHIS.Framework.XEditMask txtToSpecimenSer;
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private SingleLayout laySpecimenInfo;
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
        private MultiLayout layResult;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayout layPrint2;
        private CheckBox chkEmergency;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private CheckBox chkSend;
        private CheckBox chkAll;
        private Label label2;
        private FolderBrowserDialog fdPath;
        private XDisplayBox dbxDoctorName;
        private XLabel xLabel2;
        private SingleLayoutItem singleLayoutItem23;
        private XButton btnDel;
        private MultiLayoutItem multiLayoutItem18;
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
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem35;
        private XButton btnIfHistory;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell13;
        private XDictComboBox cboMasterType;
        private XComboItem xComboItem4;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XLabel xLabel9;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL3010U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdResult = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.grdPa = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.dbxJu = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.grdHangmog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.dbxMaxSpecimenSer = new IHIS.Framework.XDisplayBox();
            this.dbxMaxDate = new IHIS.Framework.XDisplayBox();
            this.dbxMaxTime = new IHIS.Framework.XDisplayBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboMasterType = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxJubsuDate = new IHIS.Framework.XDisplayBox();
            this.txtToSpecimenSer = new IHIS.Framework.XEditMask();
            this.txtFromSpecimenSer = new IHIS.Framework.XEditMask();
            this.cbxSpecimenSer = new IHIS.Framework.XRadioButton();
            this.cbxJubsuDate = new IHIS.Framework.XRadioButton();
            this.txtToSeq = new IHIS.Framework.XEditMask();
            this.txtFromSeq = new IHIS.Framework.XEditMask();
            this.dtpToJubsuDate = new IHIS.Framework.XDatePicker();
            this.dbxAge = new IHIS.Framework.XDisplayBox();
            this.dbxHoCode = new IHIS.Framework.XDisplayBox();
            this.dbxHoDong = new IHIS.Framework.XDisplayBox();
            this.dbxJubsuTime = new IHIS.Framework.XDisplayBox();
            this.dbxGwa = new IHIS.Framework.XDisplayBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.dbxInOutGubun = new IHIS.Framework.XDisplayBox();
            this.dbxSpecimenName = new IHIS.Framework.XDisplayBox();
            this.dbxSpecimenCode = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dbxSex = new IHIS.Framework.XDisplayBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpJubsuDate = new IHIS.Framework.XDatePicker();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnDel = new IHIS.Framework.XButton();
            this.btnFile = new IHIS.Framework.XButton();
            this.btnIfHistory = new IHIS.Framework.XButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkSend = new System.Windows.Forms.CheckBox();
            this.chkEmergency = new System.Windows.Forms.CheckBox();
            this.btnPrePrint = new IHIS.Framework.XButton();
            this.btnResultLoad = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.txtJubsuja = new IHIS.Framework.XTextBox();
            this.dbxJubsujaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.singleLayoutItem23 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.layResult = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layPrint2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.fdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrint2)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // xPanel4
            // 
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Controls.Add(this.grdResult);
            this.xPanel4.Controls.Add(this.splitter2);
            this.xPanel4.Controls.Add(this.grdHangmog);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            this.toolTip1.SetToolTip(this.xPanel4, resources.GetString("xPanel4.ToolTip"));
            // 
            // grdResult
            // 
            resources.ApplyResources(this.grdResult, "grdResult");
            this.grdResult.ApplyPaintEventToAllColumn = true;
            this.grdResult.CallerID = '2';
            this.grdResult.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell8,
            this.xEditGridCell60,
            this.xEditGridCell61});
            this.grdResult.ColPerLine = 8;
            this.grdResult.ColResizable = true;
            this.grdResult.Cols = 9;
            this.grdResult.ExecuteQuery = null;
            this.grdResult.FixedCols = 1;
            this.grdResult.FixedRows = 1;
            this.grdResult.HeaderHeights.Add(21);
            this.grdResult.MasterLayout = this.grdPa;
            this.grdResult.Name = "grdResult";
            this.grdResult.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdResult.ParamList")));
            this.grdResult.QuerySQL = resources.GetString("grdResult.QuerySQL");
            this.grdResult.ReadOnly = true;
            this.grdResult.RowHeaderVisible = true;
            this.grdResult.Rows = 2;
            this.toolTip1.SetToolTip(this.grdResult, resources.GetString("grdResult.ToolTip"));
            this.grdResult.ToolTipActive = true;
            this.grdResult.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdResult_GridCellPainting);
            this.grdResult.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdResult_QueryStarting);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellLen = 2;
            this.xEditGridCell18.CellName = "recode_gubun";
            this.xEditGridCell18.CellWidth = 39;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellLen = 6;
            this.xEditGridCell19.CellName = "center_code";
            this.xEditGridCell19.CellWidth = 81;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellLen = 20;
            this.xEditGridCell22.CellName = "request_key";
            this.xEditGridCell22.CellWidth = 124;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.CellLen = 15;
            this.xEditGridCell23.CellName = "hangmog_code";
            this.xEditGridCell23.CellWidth = 64;
            this.xEditGridCell23.Col = 2;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.CellLen = 15;
            this.xEditGridCell48.CellName = "srl_code";
            this.xEditGridCell48.CellWidth = 62;
            this.xEditGridCell48.Col = 5;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsReadOnly = true;
            this.xEditGridCell48.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell49.CellLen = 15;
            this.xEditGridCell49.CellName = "specimen_code";
            this.xEditGridCell49.CellWidth = 72;
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsReadOnly = true;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            this.xEditGridCell49.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.CellLen = 15;
            this.xEditGridCell50.CellName = "emergency";
            this.xEditGridCell50.CellWidth = 38;
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell51.CellLen = 3;
            this.xEditGridCell51.CellName = "space";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.CellLen = 13;
            this.xEditGridCell52.CellName = "specimen_ser";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsReadOnly = true;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.CellName = "jundal_gubun_name";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsReadOnly = true;
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.CellName = "cpl_result";
            this.xEditGridCell54.Col = 3;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsReadOnly = true;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.CellName = "standard_yn";
            this.xEditGridCell55.CellWidth = 31;
            this.xEditGridCell55.Col = 4;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.CellName = "comments";
            this.xEditGridCell56.CellWidth = 103;
            this.xEditGridCell56.Col = 8;
            this.xEditGridCell56.DisplayMemoText = true;
            this.xEditGridCell56.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell57.CellName = "print_yn";
            this.xEditGridCell57.CellWidth = 32;
            this.xEditGridCell57.Col = 1;
            this.xEditGridCell57.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsReadOnly = true;
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "result_yn";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell60.CellName = "gumsa_name";
            this.xEditGridCell60.CellWidth = 120;
            this.xEditGridCell60.Col = 6;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.CellName = "specimen_name";
            this.xEditGridCell61.Col = 7;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            this.xEditGridCell61.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdPa
            // 
            resources.ApplyResources(this.grdPa, "grdPa");
            this.grdPa.ApplyPaintEventToAllColumn = true;
            this.grdPa.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell62,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell21,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13});
            this.grdPa.ColPerLine = 29;
            this.grdPa.ColResizable = true;
            this.grdPa.Cols = 30;
            this.grdPa.ControlBinding = true;
            this.grdPa.ExecuteQuery = null;
            this.grdPa.FixedCols = 1;
            this.grdPa.FixedRows = 1;
            this.grdPa.HeaderHeights.Add(45);
            this.grdPa.Name = "grdPa";
            this.grdPa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPa.ParamList")));
            this.grdPa.RowHeaderVisible = true;
            this.grdPa.Rows = 2;
            this.toolTip1.SetToolTip(this.grdPa, resources.GetString("grdPa.ToolTip"));
            this.grdPa.ToolTipActive = true;
            this.grdPa.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPa_GridCellPainting);
            this.grdPa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPa_QueryStarting);
            this.grdPa.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPa_QueryEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellLen = 2;
            this.xEditGridCell1.CellName = "recode_gubun";
            this.xEditGridCell1.Col = 11;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellLen = 6;
            this.xEditGridCell2.CellName = "center_code";
            this.xEditGridCell2.Col = 12;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellLen = 20;
            this.xEditGridCell3.CellName = "request_key";
            this.xEditGridCell3.CellWidth = 141;
            this.xEditGridCell3.Col = 10;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell62.CellName = "hospital_code";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            this.xEditGridCell62.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsUpdCol = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            this.xEditGridCell62.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellLen = 15;
            this.xEditGridCell4.CellName = "gwa_name";
            this.xEditGridCell4.Col = 13;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellLen = 15;
            this.xEditGridCell5.CellName = "ho_dong_name";
            this.xEditGridCell5.CellWidth = 130;
            this.xEditGridCell5.Col = 14;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "in_out_gubun";
            this.xEditGridCell6.CellWidth = 70;
            this.xEditGridCell6.Col = 15;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "doctor_name";
            this.xEditGridCell9.CellWidth = 120;
            this.xEditGridCell9.Col = 16;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellLen = 15;
            this.xEditGridCell10.CellName = "bunho";
            this.xEditGridCell10.CellWidth = 90;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellLen = 15;
            this.xEditGridCell14.CellName = "jinryo_card";
            this.xEditGridCell14.Col = 17;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellLen = 20;
            this.xEditGridCell15.CellName = "suname";
            this.xEditGridCell15.CellWidth = 120;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellLen = 1;
            this.xEditGridCell16.CellName = "sex";
            this.xEditGridCell16.CellWidth = 44;
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellLen = 1;
            this.xEditGridCell21.CellName = "age_gubun";
            this.xEditGridCell21.CellWidth = 64;
            this.xEditGridCell21.Col = 18;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellLen = 3;
            this.xEditGridCell24.CellName = "age";
            this.xEditGridCell24.Col = 19;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellLen = 1;
            this.xEditGridCell25.CellName = "birth_gubun";
            this.xEditGridCell25.Col = 20;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.CellLen = 6;
            this.xEditGridCell26.CellName = "birth";
            this.xEditGridCell26.CellWidth = 160;
            this.xEditGridCell26.Col = 21;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellLen = 6;
            this.xEditGridCell27.CellName = "jubsu_date";
            this.xEditGridCell27.CellWidth = 90;
            this.xEditGridCell27.Col = 8;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.CellLen = 4;
            this.xEditGridCell28.CellName = "jubsu_time";
            this.xEditGridCell28.Col = 9;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.CellLen = 3;
            this.xEditGridCell29.CellName = "hangmog_cnt";
            this.xEditGridCell29.Col = 22;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.CellLen = 4;
            this.xEditGridCell30.CellName = "height";
            this.xEditGridCell30.CellWidth = 55;
            this.xEditGridCell30.Col = 23;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.CellLen = 4;
            this.xEditGridCell31.CellName = "weight";
            this.xEditGridCell31.CellWidth = 70;
            this.xEditGridCell31.Col = 24;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.CellLen = 4;
            this.xEditGridCell32.CellName = "nyo_ryang";
            this.xEditGridCell32.Col = 25;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.CellLen = 2;
            this.xEditGridCell33.CellName = "nyo_danui";
            this.xEditGridCell33.CellWidth = 70;
            this.xEditGridCell33.Col = 26;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.CellLen = 2;
            this.xEditGridCell34.CellName = "pregnancy_jusu";
            this.xEditGridCell34.CellWidth = 100;
            this.xEditGridCell34.Col = 27;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.CellLen = 1;
            this.xEditGridCell35.CellName = "dialysis";
            this.xEditGridCell35.CellWidth = 150;
            this.xEditGridCell35.Col = 28;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.CellLen = 1;
            this.xEditGridCell36.CellName = "emergency";
            this.xEditGridCell36.CellWidth = 70;
            this.xEditGridCell36.Col = 3;
            this.xEditGridCell36.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.BindControl = this.dbxJu;
            this.xEditGridCell37.CellLen = 90;
            this.xEditGridCell37.CellName = "comment";
            this.xEditGridCell37.Col = 29;
            this.xEditGridCell37.DisplayMemoText = true;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxJu
            // 
            resources.ApplyResources(this.dbxJu, "dbxJu");
            this.dbxJu.Name = "dbxJu";
            this.toolTip1.SetToolTip(this.dbxJu, resources.GetString("dbxJu.ToolTip"));
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.CellLen = 4;
            this.xEditGridCell38.CellName = "space";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "send_yn";
            this.xEditGridCell11.CellWidth = 60;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "end_send_yn";
            this.xEditGridCell12.CellWidth = 60;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "specimen_ser";
            this.xEditGridCell13.Col = 7;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            this.toolTip1.SetToolTip(this.splitter2, resources.GetString("splitter2.ToolTip"));
            // 
            // grdHangmog
            // 
            resources.ApplyResources(this.grdHangmog, "grdHangmog");
            this.grdHangmog.ApplyPaintEventToAllColumn = true;
            this.grdHangmog.CallerID = '2';
            this.grdHangmog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell63,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell7,
            this.xEditGridCell58,
            this.xEditGridCell59});
            this.grdHangmog.ColPerLine = 6;
            this.grdHangmog.ColResizable = true;
            this.grdHangmog.Cols = 7;
            this.grdHangmog.ExecuteQuery = null;
            this.grdHangmog.FixedCols = 1;
            this.grdHangmog.FixedRows = 1;
            this.grdHangmog.HeaderHeights.Add(45);
            this.grdHangmog.MasterLayout = this.grdPa;
            this.grdHangmog.Name = "grdHangmog";
            this.grdHangmog.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdHangmog.ParamList")));
            this.grdHangmog.QuerySQL = resources.GetString("grdHangmog.QuerySQL");
            this.grdHangmog.ReadOnly = true;
            this.grdHangmog.RowHeaderVisible = true;
            this.grdHangmog.Rows = 2;
            this.toolTip1.SetToolTip(this.grdHangmog, resources.GetString("grdHangmog.ToolTip"));
            this.grdHangmog.ToolTipActive = true;
            this.grdHangmog.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdHangmog_RowFocusChanged);
            this.grdHangmog.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdHangmog_GridCellPainting);
            this.grdHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmog_QueryStarting);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellLen = 2;
            this.xEditGridCell39.CellName = "recode_gubun";
            this.xEditGridCell39.CellWidth = 29;
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.CellLen = 6;
            this.xEditGridCell40.CellName = "center_code";
            this.xEditGridCell40.CellWidth = 81;
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell41.CellLen = 20;
            this.xEditGridCell41.CellName = "request_key";
            this.xEditGridCell41.CellWidth = 124;
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell63.CellName = "hospital_code";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            this.xEditGridCell63.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.CellLen = 17;
            this.xEditGridCell42.CellName = "hangmog_code";
            this.xEditGridCell42.CellWidth = 60;
            this.xEditGridCell42.Col = 2;
            this.xEditGridCell42.EnableSort = true;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell43.CellLen = 15;
            this.xEditGridCell43.CellName = "san_code";
            this.xEditGridCell43.CellWidth = 64;
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.EnableSort = true;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsReadOnly = true;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.CellLen = 15;
            this.xEditGridCell44.CellName = "specimen_code";
            this.xEditGridCell44.CellWidth = 85;
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsReadOnly = true;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell45.CellLen = 15;
            this.xEditGridCell45.CellName = "emergency";
            this.xEditGridCell45.CellWidth = 48;
            this.xEditGridCell45.Col = 1;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell45.EnableSort = true;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsReadOnly = true;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell45.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.CellLen = 3;
            this.xEditGridCell46.CellName = "space";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsReadOnly = true;
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.CellLen = 13;
            this.xEditGridCell47.CellName = "specimen_ser";
            this.xEditGridCell47.CellWidth = 120;
            this.xEditGridCell47.Col = 5;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsReadOnly = true;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "jundal_gubun_name";
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell58.CellName = "gumsa_name";
            this.xEditGridCell58.CellWidth = 180;
            this.xEditGridCell58.Col = 3;
            this.xEditGridCell58.EnableSort = true;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsReadOnly = true;
            this.xEditGridCell58.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell59.CellName = "specimen_name";
            this.xEditGridCell59.CellWidth = 84;
            this.xEditGridCell59.Col = 4;
            this.xEditGridCell59.EnableSort = true;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip1.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // xPanel5
            // 
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Controls.Add(this.grdPa);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            this.toolTip1.SetToolTip(this.xPanel5, resources.GetString("xPanel5.ToolTip"));
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.dbxJu);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.xLabel11);
            this.xPanel3.Controls.Add(this.dbxMaxSpecimenSer);
            this.xPanel3.Controls.Add(this.dbxMaxDate);
            this.xPanel3.Controls.Add(this.dbxMaxTime);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            this.toolTip1.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            this.toolTip1.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // xLabel11
            // 
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            this.toolTip1.SetToolTip(this.xLabel11, resources.GetString("xLabel11.ToolTip"));
            // 
            // dbxMaxSpecimenSer
            // 
            resources.ApplyResources(this.dbxMaxSpecimenSer, "dbxMaxSpecimenSer");
            this.dbxMaxSpecimenSer.Name = "dbxMaxSpecimenSer";
            this.toolTip1.SetToolTip(this.dbxMaxSpecimenSer, resources.GetString("dbxMaxSpecimenSer.ToolTip"));
            // 
            // dbxMaxDate
            // 
            resources.ApplyResources(this.dbxMaxDate, "dbxMaxDate");
            this.dbxMaxDate.Name = "dbxMaxDate";
            this.toolTip1.SetToolTip(this.dbxMaxDate, resources.GetString("dbxMaxDate.ToolTip"));
            // 
            // dbxMaxTime
            // 
            resources.ApplyResources(this.dbxMaxTime, "dbxMaxTime");
            this.dbxMaxTime.Mask = "##:##";
            this.dbxMaxTime.Name = "dbxMaxTime";
            this.toolTip1.SetToolTip(this.dbxMaxTime, resources.GetString("dbxMaxTime.ToolTip"));
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.cboMasterType);
            this.xPanel2.Controls.Add(this.xLabel9);
            this.xPanel2.Controls.Add(this.dbxDoctorName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.dbxJubsuDate);
            this.xPanel2.Controls.Add(this.txtToSpecimenSer);
            this.xPanel2.Controls.Add(this.txtFromSpecimenSer);
            this.xPanel2.Controls.Add(this.cbxSpecimenSer);
            this.xPanel2.Controls.Add(this.cbxJubsuDate);
            this.xPanel2.Controls.Add(this.txtToSeq);
            this.xPanel2.Controls.Add(this.txtFromSeq);
            this.xPanel2.Controls.Add(this.dtpToJubsuDate);
            this.xPanel2.Controls.Add(this.dbxAge);
            this.xPanel2.Controls.Add(this.dbxHoCode);
            this.xPanel2.Controls.Add(this.dbxHoDong);
            this.xPanel2.Controls.Add(this.dbxJubsuTime);
            this.xPanel2.Controls.Add(this.dbxGwa);
            this.xPanel2.Controls.Add(this.xLabel10);
            this.xPanel2.Controls.Add(this.dbxInOutGubun);
            this.xPanel2.Controls.Add(this.dbxSpecimenName);
            this.xPanel2.Controls.Add(this.dbxSpecimenCode);
            this.xPanel2.Controls.Add(this.xLabel7);
            this.xPanel2.Controls.Add(this.dbxSex);
            this.xPanel2.Controls.Add(this.xLabel6);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.dbxSuname);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.dtpJubsuDate);
            this.xPanel2.Name = "xPanel2";
            this.toolTip1.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // cboMasterType
            // 
            resources.ApplyResources(this.cboMasterType, "cboMasterType");
            this.cboMasterType.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem2});
            this.cboMasterType.ExecuteQuery = null;
            this.cboMasterType.Name = "cboMasterType";
            this.cboMasterType.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboMasterType.ParamList")));
            this.toolTip1.SetToolTip(this.cboMasterType, resources.GetString("cboMasterType.ToolTip"));
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "00";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "01";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "02";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "03";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "99";
            // 
            // xLabel9
            // 
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Name = "xLabel9";
            this.toolTip1.SetToolTip(this.xLabel9, resources.GetString("xLabel9.ToolTip"));
            // 
            // dbxDoctorName
            // 
            resources.ApplyResources(this.dbxDoctorName, "dbxDoctorName");
            this.dbxDoctorName.Name = "dbxDoctorName";
            this.toolTip1.SetToolTip(this.dbxDoctorName, resources.GetString("dbxDoctorName.ToolTip"));
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // dbxJubsuDate
            // 
            resources.ApplyResources(this.dbxJubsuDate, "dbxJubsuDate");
            this.dbxJubsuDate.Name = "dbxJubsuDate";
            this.toolTip1.SetToolTip(this.dbxJubsuDate, resources.GetString("dbxJubsuDate.ToolTip"));
            // 
            // txtToSpecimenSer
            // 
            resources.ApplyResources(this.txtToSpecimenSer, "txtToSpecimenSer");
            this.txtToSpecimenSer.EditVietnameseMaskType = IHIS.Framework.MaskType.String;
            this.txtToSpecimenSer.IsVietnameseYearType = false;
            this.txtToSpecimenSer.Mask = "###########";
            this.txtToSpecimenSer.Name = "txtToSpecimenSer";
            this.toolTip1.SetToolTip(this.txtToSpecimenSer, resources.GetString("txtToSpecimenSer.ToolTip"));
            // 
            // txtFromSpecimenSer
            // 
            resources.ApplyResources(this.txtFromSpecimenSer, "txtFromSpecimenSer");
            this.txtFromSpecimenSer.EditVietnameseMaskType = IHIS.Framework.MaskType.String;
            this.txtFromSpecimenSer.IsVietnameseYearType = false;
            this.txtFromSpecimenSer.Mask = "###########";
            this.txtFromSpecimenSer.Name = "txtFromSpecimenSer";
            this.toolTip1.SetToolTip(this.txtFromSpecimenSer, resources.GetString("txtFromSpecimenSer.ToolTip"));
            // 
            // cbxSpecimenSer
            // 
            resources.ApplyResources(this.cbxSpecimenSer, "cbxSpecimenSer");
            this.cbxSpecimenSer.BackColor = IHIS.Framework.XColor.XProgressBarTextColor;
            this.cbxSpecimenSer.Name = "cbxSpecimenSer";
            this.toolTip1.SetToolTip(this.cbxSpecimenSer, resources.GetString("cbxSpecimenSer.ToolTip"));
            this.cbxSpecimenSer.UseVisualStyleBackColor = false;
            this.cbxSpecimenSer.CheckedChanged += new System.EventHandler(this.cbxSpecimenSer_CheckedChanged);
            // 
            // cbxJubsuDate
            // 
            resources.ApplyResources(this.cbxJubsuDate, "cbxJubsuDate");
            this.cbxJubsuDate.BackColor = IHIS.Framework.XColor.XProgressBarGradientStartColor;
            this.cbxJubsuDate.Checked = true;
            this.cbxJubsuDate.Name = "cbxJubsuDate";
            this.cbxJubsuDate.TabStop = true;
            this.toolTip1.SetToolTip(this.cbxJubsuDate, resources.GetString("cbxJubsuDate.ToolTip"));
            this.cbxJubsuDate.UseVisualStyleBackColor = false;
            this.cbxJubsuDate.CheckedChanged += new System.EventHandler(this.cbxJubsuDate_CheckedChanged);
            // 
            // txtToSeq
            // 
            resources.ApplyResources(this.txtToSeq, "txtToSeq");
            this.txtToSeq.EditVietnameseMaskType = IHIS.Framework.MaskType.String;
            this.txtToSeq.IsVietnameseYearType = false;
            this.txtToSeq.Mask = "##:##";
            this.txtToSeq.Name = "txtToSeq";
            this.toolTip1.SetToolTip(this.txtToSeq, resources.GetString("txtToSeq.ToolTip"));
            this.txtToSeq.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtToSeq_DataValidating);
            // 
            // txtFromSeq
            // 
            resources.ApplyResources(this.txtFromSeq, "txtFromSeq");
            this.txtFromSeq.EditVietnameseMaskType = IHIS.Framework.MaskType.String;
            this.txtFromSeq.IsVietnameseYearType = false;
            this.txtFromSeq.Mask = "##:##";
            this.txtFromSeq.Name = "txtFromSeq";
            this.toolTip1.SetToolTip(this.txtFromSeq, resources.GetString("txtFromSeq.ToolTip"));
            this.txtFromSeq.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtFromSeq_DataValidating);
            // 
            // dtpToJubsuDate
            // 
            resources.ApplyResources(this.dtpToJubsuDate, "dtpToJubsuDate");
            this.dtpToJubsuDate.IsVietnameseYearType = false;
            this.dtpToJubsuDate.Name = "dtpToJubsuDate";
            this.toolTip1.SetToolTip(this.dtpToJubsuDate, resources.GetString("dtpToJubsuDate.ToolTip"));
            this.dtpToJubsuDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToJubsuDate_DataValidating);
            // 
            // dbxAge
            // 
            resources.ApplyResources(this.dbxAge, "dbxAge");
            this.dbxAge.Name = "dbxAge";
            this.toolTip1.SetToolTip(this.dbxAge, resources.GetString("dbxAge.ToolTip"));
            // 
            // dbxHoCode
            // 
            resources.ApplyResources(this.dbxHoCode, "dbxHoCode");
            this.dbxHoCode.Name = "dbxHoCode";
            this.toolTip1.SetToolTip(this.dbxHoCode, resources.GetString("dbxHoCode.ToolTip"));
            // 
            // dbxHoDong
            // 
            resources.ApplyResources(this.dbxHoDong, "dbxHoDong");
            this.dbxHoDong.Name = "dbxHoDong";
            this.toolTip1.SetToolTip(this.dbxHoDong, resources.GetString("dbxHoDong.ToolTip"));
            // 
            // dbxJubsuTime
            // 
            resources.ApplyResources(this.dbxJubsuTime, "dbxJubsuTime");
            this.dbxJubsuTime.Mask = "##:##";
            this.dbxJubsuTime.Name = "dbxJubsuTime";
            this.toolTip1.SetToolTip(this.dbxJubsuTime, resources.GetString("dbxJubsuTime.ToolTip"));
            // 
            // dbxGwa
            // 
            resources.ApplyResources(this.dbxGwa, "dbxGwa");
            this.dbxGwa.Name = "dbxGwa";
            this.toolTip1.SetToolTip(this.dbxGwa, resources.GetString("dbxGwa.ToolTip"));
            // 
            // xLabel10
            // 
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            this.toolTip1.SetToolTip(this.xLabel10, resources.GetString("xLabel10.ToolTip"));
            // 
            // dbxInOutGubun
            // 
            resources.ApplyResources(this.dbxInOutGubun, "dbxInOutGubun");
            this.dbxInOutGubun.Name = "dbxInOutGubun";
            this.toolTip1.SetToolTip(this.dbxInOutGubun, resources.GetString("dbxInOutGubun.ToolTip"));
            // 
            // dbxSpecimenName
            // 
            resources.ApplyResources(this.dbxSpecimenName, "dbxSpecimenName");
            this.dbxSpecimenName.Name = "dbxSpecimenName";
            this.toolTip1.SetToolTip(this.dbxSpecimenName, resources.GetString("dbxSpecimenName.ToolTip"));
            // 
            // dbxSpecimenCode
            // 
            resources.ApplyResources(this.dbxSpecimenCode, "dbxSpecimenCode");
            this.dbxSpecimenCode.Name = "dbxSpecimenCode";
            this.toolTip1.SetToolTip(this.dbxSpecimenCode, resources.GetString("dbxSpecimenCode.ToolTip"));
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            this.toolTip1.SetToolTip(this.xLabel7, resources.GetString("xLabel7.ToolTip"));
            // 
            // dbxSex
            // 
            resources.ApplyResources(this.dbxSex, "dbxSex");
            this.dbxSex.Name = "dbxSex";
            this.toolTip1.SetToolTip(this.dbxSex, resources.GetString("dbxSex.ToolTip"));
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            this.toolTip1.SetToolTip(this.xLabel6, resources.GetString("xLabel6.ToolTip"));
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            this.toolTip1.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            this.toolTip1.SetToolTip(this.dbxSuname, resources.GetString("dbxSuname.ToolTip"));
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            this.toolTip1.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // dtpJubsuDate
            // 
            resources.ApplyResources(this.dtpJubsuDate, "dtpJubsuDate");
            this.dtpJubsuDate.IsVietnameseYearType = false;
            this.dtpJubsuDate.Name = "dtpJubsuDate";
            this.toolTip1.SetToolTip(this.dtpJubsuDate, resources.GetString("dtpJubsuDate.ToolTip"));
            this.dtpJubsuDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJubsuDate_DataValidating);
            // 
            // xPanel8
            // 
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Controls.Add(this.btnDel);
            this.xPanel8.Controls.Add(this.btnFile);
            this.xPanel8.Controls.Add(this.btnIfHistory);
            this.xPanel8.Controls.Add(this.label2);
            this.xPanel8.Controls.Add(this.chkAll);
            this.xPanel8.Controls.Add(this.chkSend);
            this.xPanel8.Controls.Add(this.chkEmergency);
            this.xPanel8.Controls.Add(this.btnPrePrint);
            this.xPanel8.Controls.Add(this.btnResultLoad);
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.Controls.Add(this.txtJubsuja);
            this.xPanel8.Controls.Add(this.dbxJubsujaName);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            this.toolTip1.SetToolTip(this.xPanel8, resources.GetString("xPanel8.ToolTip"));
            // 
            // btnDel
            // 
            resources.ApplyResources(this.btnDel, "btnDel");
            this.btnDel.Name = "btnDel";
            this.toolTip1.SetToolTip(this.btnDel, resources.GetString("btnDel.ToolTip"));
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnFile
            // 
            resources.ApplyResources(this.btnFile, "btnFile");
            this.btnFile.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.Image")));
            this.btnFile.Name = "btnFile";
            this.btnFile.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip1.SetToolTip(this.btnFile, resources.GetString("btnFile.ToolTip"));
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnIfHistory
            // 
            resources.ApplyResources(this.btnIfHistory, "btnIfHistory");
            this.btnIfHistory.Name = "btnIfHistory";
            this.btnIfHistory.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.toolTip1.SetToolTip(this.btnIfHistory, resources.GetString("btnIfHistory.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // chkAll
            // 
            resources.ApplyResources(this.chkAll, "chkAll");
            this.chkAll.Name = "chkAll";
            this.toolTip1.SetToolTip(this.chkAll, resources.GetString("chkAll.ToolTip"));
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkSend
            // 
            resources.ApplyResources(this.chkSend, "chkSend");
            this.chkSend.Name = "chkSend";
            this.toolTip1.SetToolTip(this.chkSend, resources.GetString("chkSend.ToolTip"));
            this.chkSend.CheckedChanged += new System.EventHandler(this.chkSend_CheckedChanged);
            // 
            // chkEmergency
            // 
            resources.ApplyResources(this.chkEmergency, "chkEmergency");
            this.chkEmergency.Name = "chkEmergency";
            this.toolTip1.SetToolTip(this.chkEmergency, resources.GetString("chkEmergency.ToolTip"));
            this.chkEmergency.CheckedChanged += new System.EventHandler(this.chkEmergency_CheckedChanged);
            // 
            // btnPrePrint
            // 
            resources.ApplyResources(this.btnPrePrint, "btnPrePrint");
            this.btnPrePrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrePrint.Image")));
            this.btnPrePrint.Name = "btnPrePrint";
            this.btnPrePrint.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.toolTip1.SetToolTip(this.btnPrePrint, resources.GetString("btnPrePrint.ToolTip"));
            this.btnPrePrint.Click += new System.EventHandler(this.btnPrePrint_Click);
            // 
            // btnResultLoad
            // 
            resources.ApplyResources(this.btnResultLoad, "btnResultLoad");
            this.btnResultLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnResultLoad.Image")));
            this.btnResultLoad.Name = "btnResultLoad";
            this.btnResultLoad.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.toolTip1.SetToolTip(this.btnResultLoad, resources.GetString("btnResultLoad.ToolTip"));
            this.btnResultLoad.Click += new System.EventHandler(this.btnResultLoad_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.toolTip1.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            // 
            // txtJubsuja
            // 
            resources.ApplyResources(this.txtJubsuja, "txtJubsuja");
            this.txtJubsuja.AutoTabAtMaxLength = true;
            this.txtJubsuja.Name = "txtJubsuja";
            this.toolTip1.SetToolTip(this.txtJubsuja, resources.GetString("txtJubsuja.ToolTip"));
            // 
            // dbxJubsujaName
            // 
            resources.ApplyResources(this.dbxJubsujaName, "dbxJubsujaName");
            this.dbxJubsujaName.Name = "dbxJubsujaName";
            this.toolTip1.SetToolTip(this.dbxJubsujaName, resources.GetString("dbxJubsujaName.ToolTip"));
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "part_jubsu_flag";
            this.xEditGridCell17.CellWidth = 28;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "part_jubsuja";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            this.singleLayoutItem23,
            this.singleLayoutItem22});
            this.laySpecimenInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySpecimenInfo.ParamList")));
            this.laySpecimenInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySpecimenInfo_QueryStarting);
            // 
            // singleLayoutItem1
            // 
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
            this.singleLayoutItem10.BindControl = this.dbxJubsuDate;
            this.singleLayoutItem10.DataName = "jubsu_date";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "part_jubsu_date";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.BindControl = this.dbxJubsuTime;
            this.singleLayoutItem12.DataName = "jubsu_time";
            // 
            // singleLayoutItem13
            // 
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
            this.singleLayoutItem19.DataName = "tat1";
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.DataName = "tat2";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.BindControl = this.dbxAge;
            this.singleLayoutItem21.DataName = "age";
            // 
            // singleLayoutItem23
            // 
            this.singleLayoutItem23.BindControl = this.dbxDoctorName;
            this.singleLayoutItem23.DataName = "doctor_name";
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.DataName = "switch";
            // 
            // layResult
            // 
            this.layResult.ExecuteQuery = null;
            this.layResult.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layResult.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layResult.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "request_key";
            this.multiLayoutItem1.IsUpdItem = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "bml_code";
            this.multiLayoutItem2.IsUpdItem = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "cpl_result";
            this.multiLayoutItem3.IsUpdItem = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "standard_yn";
            this.multiLayoutItem4.IsUpdItem = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "comment1";
            this.multiLayoutItem5.IsUpdItem = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "comment2";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // layPrint2
            // 
            this.layPrint2.ExecuteQuery = null;
            this.layPrint2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem18,
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
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem35});
            this.layPrint2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPrint2.ParamList")));
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "part_jubsu_date";
            this.multiLayoutItem18.IsUpdItem = true;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "bunho";
            this.multiLayoutItem19.IsUpdItem = true;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "suname2";
            this.multiLayoutItem20.IsUpdItem = true;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "hangmog_code";
            this.multiLayoutItem21.IsUpdItem = true;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "hangmog_name";
            this.multiLayoutItem22.IsUpdItem = true;
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "specimen_name";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "gwa_name";
            this.multiLayoutItem24.IsUpdItem = true;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "doctor_name";
            this.multiLayoutItem25.IsUpdItem = true;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "sex";
            this.multiLayoutItem26.IsUpdItem = true;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "age";
            this.multiLayoutItem27.IsUpdItem = true;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "specimen_ser";
            this.multiLayoutItem28.IsUpdItem = true;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "nyo_ryang";
            this.multiLayoutItem29.IsUpdItem = true;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "nyo_danui";
            this.multiLayoutItem32.IsUpdItem = true;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "emergency";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "total_specimen_count";
            // 
            // fdPath
            // 
            resources.ApplyResources(this.fdPath, "fdPath");
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell72.CellLen = 13;
            this.xEditGridCell72.CellName = "specimen_ser";
            this.xEditGridCell72.CellWidth = 85;
            this.xEditGridCell72.Col = 5;
            this.xEditGridCell72.ExecuteQuery = null;
            this.xEditGridCell72.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            this.xEditGridCell72.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell72.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell73.CellName = "jundal_gubun_name";
            this.xEditGridCell73.CellWidth = 65;
            this.xEditGridCell73.Col = 6;
            this.xEditGridCell73.EnableSort = true;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsReadOnly = true;
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.CellName = "gumsa_name";
            this.xEditGridCell74.CellWidth = 180;
            this.xEditGridCell74.Col = 3;
            this.xEditGridCell74.EnableSort = true;
            this.xEditGridCell74.ExecuteQuery = null;
            this.xEditGridCell74.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsReadOnly = true;
            this.xEditGridCell74.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell75.CellName = "specimen_name";
            this.xEditGridCell75.CellWidth = 84;
            this.xEditGridCell75.Col = 4;
            this.xEditGridCell75.EnableSort = true;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // CPL3010U01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL3010U01";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.xPanel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.xPanel8.ResumeLayout(false);
            this.xPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrint2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #endregion

        #region fields
        private string MaxSpecimenSer = "";
        private string MaxPartJubsuDate = "";
        private string MaxPartJusbuTime = "";

        //private enum InfoGubun
        //{
        //    PartJubsuTime,
        //    SpecimenSer
        //};
        #endregion

        #region Constructor
        /// <summary>
        /// CPL3010U01
        /// </summary>
        public CPL3010U01()
        {
            try
            {
                // 이 호출은 Windows Form 디자이너에 필요합니다.
                InitializeComponent();
                // Updated by Cloud
                InitItemControls();

                // https://sofiamedix.atlassian.net/browse/MED-15136
                if (NetInfo.Language == LangMode.Vi)
                {
                    SetSizeForColumn();
                }

                // https://sofiamedix.atlassian.net/browse/MED-16236
                this.cboMasterType.ResetData();
                this.cboMasterType.SQLType = XComboSQLType.UserSQL;
                this.cboMasterType.ExecuteQuery = this.GetCboCompany;
                this.cboMasterType.SetDictDDLB();
            }
            catch// (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.StackTrace);
                //XMessageBox.Show(ex.Source);
            }
        }
        #endregion

        private void SetSizeForColumn()
        {
            grdPa.AutoSizeColumn(xEditGridCell28.Col, 110);
            grdPa.AutoSizeColumn(xEditGridCell6.Col, 80);
            grdPa.AutoSizeColumn(xEditGridCell30.Col, 60);
            grdPa.AutoSizeColumn(xEditGridCell32.Col, 100);
            grdPa.AutoSizeColumn(xEditGridCell33.Col, 100);
            grdPa.AutoSizeColumn(xEditGridCell34.Col, 105);

            //https://sofiamedix.atlassian.net/browse/MED-15265
            grdResult.AutoSizeColumn(xEditGridCell23.Col, 80);

            xLabel5.Height = 25;
            xLabel4.Height = 25;
            
        }
        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbxJubsuDate.Text = Resources.cbxJubsuDate;
            cbxSpecimenSer.Text = Resources.cbxSpecimenSer;
            this.dtpJubsuDate.SetDataValue(EnvironInfo.GetSysDate());
            this.dtpToJubsuDate.SetDataValue(EnvironInfo.GetSysDate());
            this.txtFromSeq.SetDataValue("0700");
            this.txtToSeq.SetDataValue("2400");
            string from = EnvironInfo.GetSysDate().ToString("yyMMdd") + "00001";
            string to = EnvironInfo.GetSysDate().ToString("yyMMdd") + "99999";
            this.txtFromSpecimenSer.SetDataValue(from);
            this.txtToSpecimenSer.SetDataValue(to);

            String s = Thread.CurrentThread.CurrentCulture.Name;
            String t = Thread.CurrentThread.CurrentUICulture.Name;

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    break;
                default:
                    break;
            }
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdPa.QueryLayout(true);
                    break;
                default:
                    break;
            }
        }

        private void dtpJubsuDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //this.txtJubsuja.SetDataValue("");
            //this.dbxJubsujaName.SetDataValue("");

            //this.DataServiceCall(this.dsvPa);    

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void dtpToJubsuDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //this.DataServiceCall(this.dsvPa);    
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdHangmog_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (!laySpecimenInfo.QueryLayout())
                XMessageBox.Show(Service.ErrFullMsg);
        }

        private void btnFile_Click(object sender, System.EventArgs e)
        {
            bool isSelected = false;

            for (int i = 0; i < grdPa.RowCount; i++)
            {
                if (grdPa.GetItemString(i, "send_yn") == "Y")
                {
                    isSelected = true;
                    break;
                }
            }

            // https://sofiamedix.atlassian.net/browse/MED-16236
            // Only do request exporting file for Master type ACT
            if (cboMasterType.GetDataValue().Equals("04"))
            {
                this.RequestExportFile(isSelected);
                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.RootFolder = Environment.SpecialFolder.MyComputer;

            string usbPath = null;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                usbPath = dialog.SelectedPath;
                //XMessageBox.Show(usbPath);
            }

            if (TypeCheck.IsNull(usbPath))
            {
                XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox1_caption, MessageBoxIcon.Error);
                return;
            }

            // https://sofiamedix.atlassian.net/browse/MED-16236 - moves to the top of funtion
            //bool isSelected = false;

            //for (int i = 0; i < grdPa.RowCount; i++)
            //{
            //    if (grdPa.GetItemString(i, "send_yn") == "Y")
            //        isSelected = true;
            //}

            if (isSelected == true)
            {
                if (this.isFileWrite(usbPath))
                {
                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox2_caption, MessageBoxIcon.Information);

                    // 外注依頼リスト印刷
                    this.btnPrePrint.PerformClick();
                }
                else XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox3_Caption, MessageBoxIcon.Error);


                // 画面再照会
                this.btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                string msg = Resources.msg;
                XMessageBox.Show(msg, Resources.msg_caption, MessageBoxIcon.Warning);
            }
        }

        private void btnResultLoad_Click(object sender, System.EventArgs e)
        {
            FileRead();
        }

        private void grdResult_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["result_yn"].ToString() == "N")
                e.ForeColor = Color.SteelBlue;
        }

        private void txtFromSeq_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //this.DataServiceCall(this.dsvPa);    
        }

        private void txtToSeq_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //this.DataServiceCall(this.dsvPa);    
        }

        private void xButton1_Click(object sender, System.EventArgs e)
        {
    //        ApplyMultiLangDwPrint2();
    //        this.dwPrint2.Reset();
            this.layPrint2.Reset();

            #region deleted by Cloud
//            if (this.cbxJubsuDate.Checked == true)
//            {
//                layPrint2.QuerySQL = @"SELECT TO_CHAR(B.PART_JUBSU_DATE,'YYYY/MM/DD')
//                                            , LPAD(SUBSTR(B.BUNHO,2),9,' ') BUNHO
//                                            , C.SUNAME2
//                                            , LPAD(D.JANGBI_OUT_CODE,5,'0')          HANGMOG_CODE
//                                            , FN_CPL_GUMSA_NM('1',A.HANGMOG_CODE,A.SPECIMEN_CODE)
//                                            , DECODE(B.IN_OUT_GUBUN,'I',FN_BAS_LOAD_GWA_NAME(B.HO_DONG,B.ORDER_DATE),FN_BAS_LOAD_GWA_NAME(B.GWA,B.ORDER_DATE))
//                                            , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR,B.ORDER_DATE)
//                                            , C.SEX
//                                            , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),C.BIRTH,'XXXXXX')
//                                            , B.SPECIMEN_SER
//                                            , DECODE(D.SPCIAL_NAME, '04', FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN), '')                     NYO_RYANG
//                                            , DECODE(D.SPCIAL_NAME, '04', DECODE(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN),NULL,NULL,'ml'), '')  NYO_DANUI
//                                            , NVL(B.EMERGENCY,'N') EMERGENCY
//                                         FROM OUT0101 C
//                                            , CPL0101 D
//                                            , CPL3020 A
//                                            , CPL2010 B
//                                        WHERE B.HOSP_CODE = :f_hosp_code
//                                          AND B.PART_JUBSU_DATE||B.PART_JUBSU_TIME BETWEEN TO_DATE(:f_from_part_jubsu_date,'YYYY/MM/DD')||:f_from_seq
//                                                                                       AND TO_DATE(:f_to_part_jubsu_date,'YYYY/MM/DD')||:f_to_seq
//                                          AND B.UITAK_CODE      = '01'
//                                          AND C.HOSP_CODE       = B.HOSP_CODE
//                                          AND C.BUNHO           = B.BUNHO
//                                          AND A.HOSP_CODE       = B.HOSP_CODE
//                                          AND A.FKCPL2010       = B.PKCPL2010
//                                          AND A.SPECIMEN_SER    = B.SPECIMEN_SER
//                                          AND D.HOSP_CODE       = A.HOSP_CODE
//                                          AND D.HANGMOG_CODE    = A.HANGMOG_CODE
//                                          AND D.SPECIMEN_CODE   = A.SPECIMEN_CODE
//                                          AND D.EMERGENCY       = A.EMERGENCY
//                                          AND D.UITAK_CODE      = '01'
//                                          --AND NVL(D.CHUBANG_YN,'Y')   = 'Y'
//                                          AND D.JANGBI_OUT_CODE IS NOT NULL
//                                          AND EXISTS (SELECT 'X' FROM CPLREQ1 X WHERE X.REQUEST_KEY = TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')||B.PART_JUBSU_TIME||B.BUNHO AND X.CUR_SEND_YN = 'Y')
//                                        ORDER BY B.PART_JUBSU_DATE,B.PART_JUBSU_TIME,B.BUNHO,B.SPECIMEN_SER,A.PKCPL3020";

//                layPrint2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                layPrint2.SetBindVarValue("f_from_part_jubsu_date", dtpJubsuDate.GetDataValue());
//                layPrint2.SetBindVarValue("f_to_part_jubsu_date", dtpToJubsuDate.GetDataValue());
//                layPrint2.SetBindVarValue("f_from_seq", txtFromSeq.GetDataValue());
//                layPrint2.SetBindVarValue("f_to_seq", txtToSeq.GetDataValue());
//            }
//            else
//            {
//                layPrint2.QuerySQL = @"SELECT TO_CHAR(B.PART_JUBSU_DATE,'YYYY/MM/DD')
//                                            , LPAD(SUBSTR(B.BUNHO,2),9,' ') BUNHO
//                                            , C.SUNAME2
//                                            , LPAD(D.JANGBI_OUT_CODE,5,'0')                HANGMOG_CODE
//                                            , FN_CPL_GUMSA_NM('1',A.HANGMOG_CODE,A.SPECIMEN_CODE)
//                                            , DECODE(B.IN_OUT_GUBUN,'I',FN_BAS_LOAD_GWA_NAME(B.HO_DONG,B.ORDER_DATE),FN_BAS_LOAD_GWA_NAME(B.GWA,B.ORDER_DATE))
//                                            , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR,B.ORDER_DATE)
//                                            , C.SEX
//                                            , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),C.BIRTH,'XXXXXX')
//                                            , B.SPECIMEN_SER
//                                            , DECODE(D.SPCIAL_NAME, '04', FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN), '')                     NYO_RYANG
//                                            , DECODE(D.SPCIAL_NAME, '04', DECODE(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN),NULL,NULL,'ml'), '')  NYO_DANUI
//                                            , NVL(B.EMERGENCY,'N') EMERGENCY
//                                         FROM OUT0101 C
//                                            , CPL0101 D
//                                            , CPL3020 A
//                                            , CPL2010 B
//                                        WHERE B.HOSP_CODE       = :f_hosp_code
//                                          AND B.SPECIMEN_SER BETWEEN :f_from_specimen_ser 
//                                                                 AND :f_to_specimen_ser
//                                          AND B.UITAK_CODE      = '01'
//                                          AND C.HOSP_CODE       = B.HOSP_CODE
//                                          AND C.BUNHO           = B.BUNHO
//                                          AND A.HOSP_CODE       = B.HOSP_CODE
//                                          AND A.FKCPL2010       = B.PKCPL2010
//                                          AND A.SPECIMEN_SER    = B.SPECIMEN_SER
//                                          AND D.HOSP_CODE       = A.HOSP_CODE
//                                          AND D.HANGMOG_CODE    = A.HANGMOG_CODE
//                                          AND D.SPECIMEN_CODE   = A.SPECIMEN_CODE
//                                          AND D.EMERGENCY       = A.EMERGENCY
//                                          AND D.UITAK_CODE      = '01'
//                                          --AND NVL(D.CHUBANG_YN,'Y')   = 'Y'
//                                          AND D.JANGBI_OUT_CODE IS NOT NULL
//                                          AND EXISTS (SELECT 'X' FROM CPLREQ1 X WHERE X.REQUEST_KEY = TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')||B.PART_JUBSU_TIME||B.BUNHO AND X.CUR_SEND_YN = 'Y')
//                                        ORDER BY B.PART_JUBSU_DATE,B.PART_JUBSU_TIME,B.BUNHO,B.SPECIMEN_SER,A.PKCPL3020";


//                layPrint2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                layPrint2.SetBindVarValue("f_from_specimen_ser", txtFromSpecimenSer.GetDataValue());
//                layPrint2.SetBindVarValue("f_to_specimen_ser", txtToSpecimenSer.GetDataValue());
//            }
            #endregion

            // Cloud updated code START
            layPrint2.ParamList = new List<string>(new  string[]
                {
                    "f_hosp_code",
                    "f_from_part_jubsu_date",
                    "f_to_part_jubsu_date",
                    "f_from_seq",
                    "f_to_seq",
                    "f_from_specimen_ser",
                    "f_to_specimen_ser",
                });

            layPrint2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layPrint2.SetBindVarValue("f_from_part_jubsu_date", dtpJubsuDate.GetDataValue());
            layPrint2.SetBindVarValue("f_to_part_jubsu_date", dtpToJubsuDate.GetDataValue());
            layPrint2.SetBindVarValue("f_from_seq", txtFromSeq.GetDataValue());
            layPrint2.SetBindVarValue("f_to_seq", txtToSeq.GetDataValue());
            layPrint2.SetBindVarValue("f_from_specimen_ser", txtFromSpecimenSer.GetDataValue());
            layPrint2.SetBindVarValue("f_to_specimen_ser", txtToSpecimenSer.GetDataValue());
            layPrint2.ExecuteQuery = GetLayPrint2ForXButton1Click;
            // Cloud updated code END

            if (!layPrint2.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }

            if (this.layPrint2.RowCount > 0)
            {
                //검체번호 카운트 추가
                string pre_specimen_ser = "";
                int total_specimen_count = 0;
                for (int i = 0; i < layPrint2.RowCount; i++)
                {
                    if (pre_specimen_ser != layPrint2.GetItemString(i, "specimen_ser"))
                    {
                        total_specimen_count++;
                    }
                    pre_specimen_ser = layPrint2.GetItemString(i, "specimen_ser");
                }
                for (int i = 0; i < layPrint2.RowCount; i++)
                {
                    layPrint2.SetItemValue(i, "total_specimen_count", total_specimen_count);
                }
         //       this.dwPrint2.FillData(this.layPrint2.LayoutTable);
         //       this.dwPrint2.Print();
            }
        }

        private void ApplyMultiLangDwPrint2()
        {
            //dwPrint2
            //dwPrint2.Modify(string.Format("pkapl1000_t.text = '{0}'", Properties.Resources.DW_TXT_001));
            //dwPrint2.Modify(string.Format("t_8.text = '{0}'", Properties.Resources.DW_TXT_002));
            //dwPrint2.Modify(string.Format("t_1.text = '{0}'", Properties.Resources.DW_TXT_003));
            //dwPrint2.Modify(string.Format("t_3.text = '{0}'", Properties.Resources.DW_TXT_004));
            //dwPrint2.Modify(string.Format("t_4.text = '{0}'", Properties.Resources.DW_TXT_005));
            //dwPrint2.Modify(string.Format("t_5.text = '{0}'", Properties.Resources.DW_TXT_006));
            //dwPrint2.Modify(string.Format("t_9.text = '{0}'", Properties.Resources.DW_TXT_007));
            //dwPrint2.Modify(string.Format("t_2.text = '{0}'", Properties.Resources.DW_TXT_008));
            //dwPrint2.Modify(string.Format("t_6.text = '{0}'", Properties.Resources.DW_TXT_009));
            //dwPrint2.Modify(string.Format("t_7.text = '{0}'", Properties.Resources.DW_TXT_010));
            //dwPrint2.Modify(string.Format("t_12.text = '{0}'", Properties.Resources.DW_TXT_011));
            //dwPrint2.Modify(string.Format("t_11.text = '{0}'", Properties.Resources.DW_TXT_012));
            //dwPrint2.Modify(string.Format("t_10.text = '{0}'", Properties.Resources.DW_TXT_013));
            //if (NetInfo.Language != LangMode.Jr)
            //{
            //    dwPrint2.Modify(string.Format("pkapl1000_t.Font.Face='{0}'", Service.COMMON_FONT_BOLD.Name));
            //    dwPrint2.Modify(string.Format("t_8.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_1.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_3.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_4.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_5.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_9.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_2.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_6.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_7.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_12.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_11.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("t_10.Font.Face='{0}'", Service.COMMON_FONT.Name));

            //    dwPrint2.Modify(string.Format("part_jubsu_date.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("gwa_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("doctor_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("bunho.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("suname2.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("sex.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("age.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("specimen_ser.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("hangmog_code.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("nyo_ryang.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("nyo_danui.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("emergency.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("specimen_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //    dwPrint2.Modify(string.Format("hangmog_name.Font.Face='{0}'", Service.COMMON_FONT.Name));
            //}

            // https://sofiamedix.atlassian.net/browse/MED-16420
    //        dwPrint2.Modify(string.Format("t_13.text = '{0}'", UserInfo.HospName));
        }

        private void cbxJubsuDate_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cbxJubsuDate.Checked == true)
            {
                this.cbxJubsuDate.BackColor = XColor.XProgressBarGradientStartColor;
                if (!grdPa.QueryLayout(true))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }
                this.cbxSpecimenSer.Checked = false;
            }
            else
            {
                this.cbxJubsuDate.BackColor = XColor.XProgressBarTextColor;
            }
        }

        private void cbxSpecimenSer_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cbxSpecimenSer.Checked == true)
            {
                this.cbxSpecimenSer.BackColor = XColor.XProgressBarGradientStartColor;
                if (!grdPa.QueryLayout(true))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }
                this.cbxJubsuDate.Checked = false;
            }
            else
            {
                this.cbxSpecimenSer.BackColor = XColor.XProgressBarTextColor;
            }
        }

        private void laySpecimenInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            laySpecimenInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            laySpecimenInfo.SetBindVarValue("f_specimen_ser", grdHangmog.GetItemString(grdHangmog.CurrentRowNumber, "specimen_ser"));
        }

        private void grdPa_QueryStarting(object sender, CancelEventArgs e)
        {
            #region deleted by Cloud
//            if (cbxJubsuDate.Checked)
//            {
//                grdPa.QuerySQL = @"SELECT /*+ MASTER 1 +*/
//                                          'O1'                                                                  RECODE_GUBUN
//                                        , 'SAN   '                                                              CENTER_CODE
//                                        , TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')||B.PART_JUBSU_TIME||B.BUNHO       REQUEST_KEY
//                                        , '        '                                                            HOSPITAL_CODE
//                                        , MIN(FN_ADM_CONVERT_KATAKANA_HALF(2,FN_BAS_LOAD_GWA_NAME2(B.GWA,B.ORDER_DATE)))           GWA_NAME
//                                        , MIN(FN_BAS_LOAD_GWA_NAME2(NVL(E.HO_DONG1,B.HO_DONG),SYSDATE))         HO_DONG_NAME
//                                        , MIN(DECODE(B.IN_OUT_GUBUN,'I','1','O','2'))         IN_OUT_GUBUN
//                                        , MIN(FN_ADM_CONVERT_KATAKANA_HALF(2,FN_BAS_LOAD_DOCTOR_NAME2(B.DOCTOR,B.ORDER_DATE)))     DOCTOR_NAME
//                                        , MIN(B.BUNHO)                                        BUNHO
//                                        , MIN(B.BUNHO)                                        JINRYO_CARD
//                                        , MIN(FN_ADM_CONVERT_KATAKANA_HALF(2,D.SUNAME2))      SUNAME2
//                                        , MIN(D.SEX)                                          SEX
//                                        , 'Y'                                                 AGE_GUBUN
//                                        , MIN(FN_BAS_LOAD_AGE(B.JUBSU_DATE, D.BIRTH, NULL))   AGE
//                                        , MIN(SUBSTR(FN_BAS_TO_JAPAN_DATE_CONVERT('3',D.BIRTH),1,1))     BIRTH_GUBUN
//                                        , MIN(SUBSTR(FN_BAS_TO_JAPAN_DATE_CONVERT('3',D.BIRTH),2))       BIRTH
//                                        , MIN(DECODE(B.IN_OUT_GUBUN, 'O', TO_CHAR(B.JUBSU_DATE,'YYMMDD'), TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')))    JUBSU_DATE
//                                        , MIN(DECODE(B.IN_OUT_GUBUN, 'O', B.JUBSU_TIME, B.PART_JUBSU_TIME))                                        JUBSU_TIME
//                                        , MIN(FN_CPL_LOAD_HANGMOG_CNT(B.BUNHO,B.PART_JUBSU_DATE))  HANGMOG_CNT
//                                        , MIN(FN_NUR_LOAD_HEIGHT(B.BUNHO,SYSDATE))                 HEIGHT
//                                        , ' '                                                      WEIGHT
//                                        , MAX(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN))                           NYO_RYANG
//                                        , MAX(DECODE(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN),NULL,NULL,'ml'))    NYO_DANUI
//                                        , ' '                                                 PREGNANCY_JUSU
//                                        , ' '                                                 DIALYSIS
//                                        --, MAX((SELECT MAX(NVL(F.EMERGENCY,'N')) FROM CPL2010 F WHERE F.HOSP_CODE = :f_hosp_code AND F.PART_JUBSU_DATE = B.PART_JUBSU_DATE AND F.PART_JUBSU_TIME = B.PART_JUBSU_TIME AND F.BUNHO = B.BUNHO))   EMERGENCY
//                                        , DECODE(MAX(FN_CPL_SPECIMEN_PRN_YN(B.IN_OUT_GUBUN, B.FKOCS1003, B.FKOCS2003)), 'Z', 'Y', 'N') EMERGENCY
//                                        , ' '                                                 COMMENTS
//                                        , ' ' 
//                                        , 'N'
//                                        , MIN(NVL((SELECT NVL(A.SEND_YN,'N') FROM CPLREQ1 A WHERE A.REQUEST_KEY = TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')||B.PART_JUBSU_TIME||B.BUNHO),'N'))  SEND_YN
//                                     FROM VW_OCS_INP1001_01 E,
//                                          OUT0101 D,
//                                          CPL0101 C,
//                                          (SELECT *
//                                             FROM CPL2010 A
//                                            WHERE A.HOSP_CODE = 'K01'
//                                              AND A.PART_JUBSU_DATE BETWEEN TO_DATE(:f_from_part_jubsu_date,'YYYY/MM/DD') AND TO_DATE(:f_to_part_jubsu_date,'YYYY/MM/DD')
//                                              AND NVL(A.DC_YN,'N')  = 'N'
//                                           ) B
//                                    WHERE B.HOSP_CODE = :f_hosp_code
//                                      --AND B.PART_JUBSU_DATE BETWEEN TO_DATE(:f_from_part_jubsu_date,'YYYY/MM/DD') AND TO_DATE(:f_to_part_jubsu_date,'YYYY/MM/DD')
//                                      --AND B.PART_JUBSU_TIME BETWEEN :f_from_seq AND :f_to_seq
//                                      AND B.PART_JUBSU_DATE || B.PART_JUBSU_TIME BETWEEN TO_DATE(:f_from_part_jubsu_date,'YYYY/MM/DD') || :f_from_seq AND TO_DATE(:f_to_part_jubsu_date,'YYYY/MM/DD') || :f_to_seq
//                                      --AND B.PART_JUBSU_DATE IS NOT NULL
//                                      --AND NVL(B.DC_YN,'N')        = 'N'
//                                      AND C.HOSP_CODE             = B.HOSP_CODE
//                                      AND C.HANGMOG_CODE          = B.HANGMOG_CODE
//                                      AND C.SPECIMEN_CODE         = B.SPECIMEN_CODE
//                                      AND C.EMERGENCY             = B.EMERGENCY
//                                      AND C.UITAK_CODE            = '01' 
//                                      AND D.HOSP_CODE             = B.HOSP_CODE
//                                      AND D.BUNHO                 = B.BUNHO
//                                      AND E.HOSP_CODE(+)          = B.HOSP_CODE
//                                      AND E.BUNHO(+)              = B.BUNHO
//                                    GROUP BY B.PART_JUBSU_DATE, B.PART_JUBSU_TIME, B.BUNHO
//                                    ORDER BY B.PART_JUBSU_DATE, B.PART_JUBSU_TIME, B.BUNHO";

//                grdPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                grdPa.SetBindVarValue("f_from_part_jubsu_date", dtpJubsuDate.GetDataValue());
//                grdPa.SetBindVarValue("f_to_part_jubsu_date", dtpToJubsuDate.GetDataValue());
//                grdPa.SetBindVarValue("f_from_seq", txtFromSeq.GetDataValue());
//                grdPa.SetBindVarValue("f_to_seq", txtToSeq.GetDataValue());
//            }
//            else
//            {
//                grdPa.QuerySQL = @"SELECT /*+ MASTER 2 +*/
//                                          'O1'                                                RECODE_GUBUN
//                                        , 'SAN   '                                            CENTER_CODE
//                                        , TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')||B.PART_JUBSU_TIME||B.BUNHO       REQUEST_KEY
//                                        , '        '                                          HOSPITAL_CODE
//                                        , MIN(FN_ADM_CONVERT_KATAKANA_HALF(2,FN_BAS_LOAD_GWA_NAME2(B.GWA,B.ORDER_DATE)))           GWA_NAME
//                                        , MIN(FN_BAS_LOAD_GWA_NAME2(NVL(E.HO_DONG1,B.HO_DONG),SYSDATE))       HO_DONG_NAME
//                                        , MIN(DECODE(B.IN_OUT_GUBUN,'I','1','O','2'))         IN_OUT_GUBUN
//                                        , MIN(FN_ADM_CONVERT_KATAKANA_HALF(2,FN_BAS_LOAD_DOCTOR_NAME2(B.DOCTOR,B.ORDER_DATE)))     DOCTOR_NAME
//                                        , MIN(B.BUNHO)                                        BUNHO
//                                        , MIN(B.BUNHO)                                        JINRYO_CARD
//                                        , MIN(FN_ADM_CONVERT_KATAKANA_HALF(2,D.SUNAME2))      SUNAME2
//                                        , MIN(D.SEX)                                          SEX
//                                        , 'Y'                                                 AGE_GUBUN
//                                        , MIN(FN_BAS_LOAD_AGE(B.JUBSU_DATE, D.BIRTH, NULL))   AGE
//                                        , MIN(SUBSTR(FN_BAS_TO_JAPAN_DATE_CONVERT('3',D.BIRTH),1,1))     BIRTH_GUBUN
//                                        , MIN(SUBSTR(FN_BAS_TO_JAPAN_DATE_CONVERT('3',D.BIRTH),2))       BIRTH
//                                        , MIN(DECODE(B.IN_OUT_GUBUN, 'O', TO_CHAR(B.JUBSU_DATE,'YYMMDD'), TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')))    JUBSU_DATE
//                                        , MIN(DECODE(B.IN_OUT_GUBUN, 'O', B.JUBSU_TIME, B.PART_JUBSU_TIME))                                        JUBSU_TIME
//                                        , MIN(FN_CPL_LOAD_HANGMOG_CNT(B.BUNHO,B.PART_JUBSU_DATE))  HANGMOG_CNT
//                                        , MIN(FN_NUR_LOAD_HEIGHT(B.BUNHO,SYSDATE))                 HEIGHT
//                                        , ' '                                                      WEIGHT
//                                        , MAX(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN))                    NYO_RYANG
//                                        , MAX(DECODE(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN),NULL,NULL,'ml'))    NYO_DANUI
//                                        , ' '                                                 PREGNANCY_JUSU
//                                        , ' '                                                 DIALYSIS
//                                        --, MAX((SELECT MAX(NVL(F.EMERGENCY,'N')) FROM CPL2010 F WHERE F.HOSP_CODE = :f_hosp_code AND F.PART_JUBSU_DATE = B.PART_JUBSU_DATE AND F.PART_JUBSU_TIME = B.PART_JUBSU_TIME AND F.BUNHO = B.BUNHO))   EMERGENCY
//                                        , DECODE(MAX(FN_CPL_SPECIMEN_PRN_YN(B.IN_OUT_GUBUN, B.FKOCS1003, B.FKOCS2003)), 'Z', 'Y', 'N') EMERGENCY
//                                        , ' '                                                 COMMENTS
//                                        , ' '  
//                                        , 'N'
//                                        , MIN(NVL((SELECT NVL(A.SEND_YN,'N') FROM CPLREQ1 A WHERE A.REQUEST_KEY = TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD')||B.PART_JUBSU_TIME||B.BUNHO),'N'))  SEND_YN
//                                     FROM VW_OCS_INP1001_01 E,
//                                          OUT0101 D,                      
//                                          CPL0101 C,
//                                          CPL2010 B
//                                    WHERE B.HOSP_CODE             = :f_hosp_code
//                                      AND B.SPECIMEN_SER BETWEEN :f_from_specimen_ser 
//                                                             AND :f_to_specimen_ser
//                                      AND B.PART_JUBSU_DATE IS NOT NULL
//                                      AND NVL(B.DC_YN,'N')        = 'N'
//                                      AND C.HOSP_CODE             = B.HOSP_CODE
//                                      AND C.HANGMOG_CODE          = B.HANGMOG_CODE
//                                      AND C.SPECIMEN_CODE         = B.SPECIMEN_CODE
//                                      AND C.EMERGENCY             = B.EMERGENCY
//                                      AND C.UITAK_CODE            = '01'
//                                      AND D.HOSP_CODE             = B.HOSP_CODE
//                                      AND D.BUNHO                 = B.BUNHO
//                                      AND E.HOSP_CODE(+)          = B.HOSP_CODE
//                                      AND E.BUNHO(+)              = B.BUNHO
//                                    GROUP BY B.PART_JUBSU_DATE, B.PART_JUBSU_TIME, B.BUNHO
//                                    ORDER BY B.PART_JUBSU_DATE, B.PART_JUBSU_TIME, B.BUNHO";

//                grdPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                grdPa.SetBindVarValue("f_from_specimen_ser", txtFromSpecimenSer.GetDataValue());
//                grdPa.SetBindVarValue("f_to_specimen_ser", txtToSpecimenSer.GetDataValue());
//            }
            #endregion

            // Cloud updated code START
            grdPa.ParamList = new List<string>(new string[]
                {
                    "f_hosp_code",
                    "f_from_part_jubsu_date",
                    "f_to_part_jubsu_date",
                    "f_from_seq",
                    "f_to_seq",
                    "f_from_specimen_ser",
                    "f_to_specimen_ser",
                    "f_uitak_code", 
                    "f_center_code"
                });

            grdPa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdPa.SetBindVarValue("f_from_part_jubsu_date", dtpJubsuDate.GetDataValue());
            grdPa.SetBindVarValue("f_to_part_jubsu_date", dtpToJubsuDate.GetDataValue());
            grdPa.SetBindVarValue("f_from_seq", txtFromSeq.GetDataValue());
            grdPa.SetBindVarValue("f_to_seq", txtToSeq.GetDataValue());
            grdPa.SetBindVarValue("f_from_specimen_ser", txtFromSpecimenSer.GetDataValue());
            grdPa.SetBindVarValue("f_to_specimen_ser", txtToSpecimenSer.GetDataValue());
            if (!TypeCheck.IsNull(cboMasterType.GetDataValue()))
            {
                grdPa.SetBindVarValue("f_uitak_code", cboMasterType.GetDataValue());
            }
            else
            {
                grdPa.SetBindVarValue("f_uitak_code", "");
            }

            if (cboMasterType.GetDataValue().Equals("01"))
            {
                grdPa.SetBindVarValue("f_center_code", "SAN   ");
            }
            else if (cboMasterType.GetDataValue().Equals("02"))
            {
                grdPa.SetBindVarValue("f_center_code", "BML   ");
            }
            else if (cboMasterType.GetDataValue().Equals("03"))
            {
                grdPa.SetBindVarValue("f_center_code", "SRL   ");
            }
            // https://sofiamedix.atlassian.net/browse/MED-16348
            else if (cboMasterType.GetDataValue().Equals("04"))
            {
                grdPa.SetBindVarValue("f_center_code", cboMasterType.GetDataValue());
            }
            else
            {
                grdPa.SetBindVarValue("f_center_code", "      ");
            }
            grdPa.ExecuteQuery = GetGrdPa;
            // Cloud updated code END
        }

        private void grdHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            grdHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            // https://sofiamedix.atlassian.net/browse/MED-16341
            if (cboMasterType.GetDataValue().Equals("04"))
            {
                string requestKey = grdPa.GetItemString(grdPa.CurrentRowNumber, "jubsu_date") + grdPa.GetItemString(grdPa.CurrentRowNumber, "jubsu_time") + grdPa.GetItemString(grdPa.CurrentRowNumber, "bunho");
                grdHangmog.SetBindVarValue("f_request_key", requestKey);
            }
            else
            {
                grdHangmog.SetBindVarValue("f_request_key", grdPa.GetItemString(grdPa.CurrentRowNumber, "request_key"));
            }
            grdHangmog.SetBindVarValue("f_specimen_ser", grdPa.GetItemString(grdPa.CurrentRowNumber, "specimen_ser"));
            if (!TypeCheck.IsNull(cboMasterType.GetDataValue()))
            {
                grdPa.SetBindVarValue("f_uitak_code", cboMasterType.GetDataValue());
            }
            else
            {
                grdPa.SetBindVarValue("f_uitak_code", "");
            }

            if (cboMasterType.GetDataValue().Equals("01"))
            {
                grdHangmog.SetBindVarValue("f_center_code", "SAN   ");
            }
            else if (cboMasterType.GetDataValue().Equals("02"))
            {
                grdHangmog.SetBindVarValue("f_center_code", "BML   ");
            }
            else if (cboMasterType.GetDataValue().Equals("03"))
            {
                grdHangmog.SetBindVarValue("f_center_code", "SRL   ");
            }
            else
            {
                grdHangmog.SetBindVarValue("f_center_code", "      ");
            }
        }

        private void grdResult_QueryStarting(object sender, CancelEventArgs e)
        {
            grdResult.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdResult.SetBindVarValue("f_request_key", grdPa.GetItemString(grdPa.CurrentRowNumber, "request_key"));
        }

        private void chkEmergency_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grdPa.RowCount; i++)
            {
                if (grdPa.GetItemString(i, "emergency") == "Y")
                {
                    if (chkEmergency.Checked)
                    {
                        if (grdPa.GetItemString(i, "end_send_yn") == "N")
                        {
                            grdPa.SetItemValue(i, "send_yn", "Y");
                        }
                    }
                    else
                    {
                        grdPa.SetItemValue(i, "send_yn", "N");
                    }
                }
            }
        }

        private void chkSend_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grdPa.RowCount; i++)
            {
                if (grdPa.GetItemString(i, "end_send_yn") == "N")
                {
                    if (chkSend.Checked)
                    {
                        grdPa.SetItemValue(i, "send_yn", "Y");
                    }
                    else
                    {
                        grdPa.SetItemValue(i, "send_yn", "N");
                    }
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grdPa.RowCount; i++)
            {
                if (chkAll.Checked)
                {
                    grdPa.SetItemValue(i, "send_yn", "Y");
                }
                else
                {
                    grdPa.SetItemValue(i, "send_yn", "N");
                }
            }
        }

        private void SetGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdPa" && grid.GetItemString(e.RowNumber, "emergency") == "Y")
            {
                e.BackColor = Color.Pink;
            }

            if (grid.Name == "grdHangmog" && grid.GetItemString(e.RowNumber, "emergency") == "Y")
            {
                e.BackColor = Color.MistyRose;
            }
        }

        private void grdPa_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            SetGrdBackColor(sender, e);
        }

        private void grdHangmog_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            SetGrdBackColor(sender, e);
        }

        private void btnPrePrint_Click(object sender, EventArgs e)
        {
            if (grdPa.RowCount > 0)
            {
                string iraiStr = "";
                int iraicnt = 0;

                for (int i = 0; i < grdPa.RowCount; i++)
                {
                    if (grdPa.GetItemString(i, "send_yn") == "Y")
                    {
                        iraiStr += grdPa.GetItemString(i, "request_key") + ",";
                        iraicnt++;
                    }
                }
                if (iraicnt > 0)
                {
                    iraiStr = iraiStr.Substring(0, iraiStr.Length - 1);

                    ApplyMultiLangDwPrint2();
                    layPrint2.Reset();
          //          dwPrint2.Reset();

                    #region deleted by Cloud
//                    layPrint2.QuerySQL = @"SELECT TO_CHAR(B.PART_JUBSU_DATE,'YYYY/MM/DD')                                                                                   PART_JUBSU_DATE
//                                                , LPAD(SUBSTR(B.BUNHO,2),9,' ')                                                                                             BUNHO
//                                                , C.SUNAME2                                                                                                                 SUNAME2
//                                                --, LPAD(D.JANGBI_OUT_CODE,5,'0')                HANGMOG_CODE
//                                                , D.JANGBI_OUT_CODE                                                                                                           HANGMOG_CODE
//                                                , FN_CPL_GUMSA_NM('1',A.HANGMOG_CODE,A.SPECIMEN_CODE)                                                                       HANGMOG_NAME
//                                                , FN_CPL_CODE_NAME('04',D.SPECIMEN_CODE)                                                                                    SPECIMEN_NAME
//                                                , DECODE(B.IN_OUT_GUBUN,'I',FN_BAS_LOAD_GWA_NAME(B.HO_DONG,B.ORDER_DATE),FN_BAS_LOAD_GWA_NAME(B.GWA,B.ORDER_DATE))          GWA_NAME
//                                                , FN_BAS_LOAD_DOCTOR_NAME(B.DOCTOR,B.ORDER_DATE)                                                                            DOCTOR_NAME
//                                                , C.SEX                                                                                                                     SEX
//                                                , FN_BAS_LOAD_AGE(TRUNC(SYSDATE),C.BIRTH,'XXXXXX')                                                                          AGE
//                                                , B.SPECIMEN_SER                                                                                                            SPECIMEN_SER
//                                                , DECODE(D.SPCIAL_NAME, '04', FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN), '')                     NYO_RYANG
//                                                , DECODE(D.SPCIAL_NAME, '04', DECODE(FN_CPL_LOAD_URINE('2',B.SPECIMEN_SER,DECODE(B.IN_OUT_GUBUN,'I',B.FKOCS2003,B.FKOCS1003),B.IN_OUT_GUBUN),NULL,NULL,'ml'), '')  NYO_DANUI
//                                                , DECODE(FN_OCS_EMERGENCY_CHK(B.IN_OUT_GUBUN, B.FKOCS1003, B.FKOCS2003), 'Y', '○', '')   EMERGENCY_YN
//                                             FROM OUT0101 C
//                                                , CPL0101 D
//                                                , CPL3020 A
//                                                , CPL2010 B
//                                            WHERE B.HOSP_CODE       = :f_hosp_code
//                                              AND B.UITAK_CODE      = '01'
//                                              AND C.HOSP_CODE       = B.HOSP_CODE
//                                              AND C.BUNHO           = B.BUNHO
//                                              AND A.HOSP_CODE       = B.HOSP_CODE
//                                              AND A.FKCPL2010       = B.PKCPL2010
//                                              AND A.SPECIMEN_SER    = B.SPECIMEN_SER
//                                              AND D.HOSP_CODE       = A.HOSP_CODE
//                                              AND D.HANGMOG_CODE    = A.HANGMOG_CODE
//                                              AND D.SPECIMEN_CODE   = A.SPECIMEN_CODE
//                                              AND D.EMERGENCY       = A.EMERGENCY
//                                              AND D.UITAK_CODE      = '01'
//                                              --AND NVL(D.CHUBANG_YN,'Y')   = 'Y'
//                                              AND D.JANGBI_OUT_CODE IS NOT NULL
//                                              AND ( (TO_CHAR(B.PART_JUBSU_DATE,'YYMMDD') || B.PART_JUBSU_TIME || B.BUNHO) IN (" + iraiStr + @")
//                                                  )
//                                            ORDER BY B.PART_JUBSU_DATE,B.PART_JUBSU_TIME,B.BUNHO,B.SPECIMEN_SER,A.PKCPL3020";
                    #endregion

                    // Cloud updated code START
                    layPrint2.ParamList = new List<string>(new string[] { "f_irai_str", "f_uitak_code" });
                    layPrint2.SetBindVarValue("f_irai_str", iraiStr);
                    layPrint2.SetBindVarValue("f_uitak_code", cboMasterType.GetDataValue());
                    layPrint2.ExecuteQuery = GetLayPrint2ForBtnPrePrintClick;
                    // Cloud updated code END

                    if (!layPrint2.QueryLayout(true))
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }

                    if (this.layPrint2.RowCount > 0)
                    {
                        //검체번호 카운트 추가
                        string pre_specimen_ser = "";
                        int total_specimen_count = 0;
                        for (int i = 0; i < layPrint2.RowCount; i++)
                        {
                            if (pre_specimen_ser != layPrint2.GetItemString(i, "specimen_ser"))
                            {
                                total_specimen_count++;
                            }
                            pre_specimen_ser = layPrint2.GetItemString(i, "specimen_ser");
                        }
                        for (int i = 0; i < layPrint2.RowCount; i++)
                        {
                            layPrint2.SetItemValue(i, "total_specimen_count", total_specimen_count);
                        }
        //                this.dwPrint2.FillData(this.layPrint2.LayoutTable);
                        try
                        {
         //                   this.dwPrint2.Print();
                        }
                        catch
                        {
        //                    dwPrint2.Hide();
                        }
                    }

                }
            }
        }

        private void grdPa_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.chkAll.Checked = false;
            this.chkSend.Checked = false;
            this.chkEmergency.Checked = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DateTime from_date;
            DateTime to_date;

            from_date = EnvironInfo.GetSysDate().AddMonths(-3);
            to_date = EnvironInfo.GetSysDate().AddMonths(-2);

            for (; from_date <= to_date; from_date = from_date.AddDays(1))
            {
                if (Directory.Exists("C:\\ICMJ\\" + from_date.ToString("yyyyMMdd")))
                {
                    Directory.Delete("C:\\ICMJ\\" + from_date.ToString("yyyyMMdd"), true);
                }
            }
        }

        #endregion

        #region cboMasterType_SelectedIndexChanged
        private void cboMasterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeCheck.IsNull(cboMasterType.GetDataValue())) return;

            if (!grdPa.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }
         #endregion

        #region Methods(private)

        #region unused codes
//        private void SearchMaxInfo(InfoGubun infoGb)
//        {
//            string cmdStr = "";
//            BindVarCollection bindVarList = new BindVarCollection();

//            if (infoGb == InfoGubun.PartJubsuTime)
//            {
//                cmdStr = @"SELECT MAX(B.SPECIMEN_SER)
//                                , MAX(TO_CHAR(B.PART_JUBSU_DATE,'YYYY/MM/DD'))
//                                , MAX(B.PART_JUBSU_TIME)
//                             FROM CPL2010 B
//                            WHERE B.HOSP_CODE = :f_hosp_code
//                              AND B.PART_JUBSU_DATE BETWEEN TO_DATE(:f_from_part_jubsu_date,'YYYY/MM/DD')
//                                                        AND TO_DATE(:f_to_part_jubsu_date,'YYYY/MM/DD')
//                              AND B.PART_JUBSU_DATE||B.PART_JUBSU_TIME BETWEEN TO_DATE(:f_from_part_jubsu_date,'YYYY/MM/DD')||:f_from_seq
//                                                        AND TO_DATE(:f_to_part_jubsu_date,'YYYY/MM/DD')||:f_to_seq
//                              AND B.PART_JUBSU_DATE IS NOT NULL
//                              AND NVL(B.DC_YN,'N')  = 'N'
//                              AND B.UITAK_CODE      = '01'
//                              AND ROWNUM = 1
//                            ORDER BY B.PART_JUBSU_DATE DESC, B.PART_JUBSU_TIME DESC, B.SPECIMEN_SER DESC";

//                bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                bindVarList.Add("f_from_part_jubsu_date", dtpJubsuDate.GetDataValue());
//                bindVarList.Add("f_to_part_jubsu_date", dtpToJubsuDate.GetDataValue());
//                bindVarList.Add("f_from_seq", txtFromSeq.GetDataValue());
//                bindVarList.Add("f_to_seq", txtToSeq.GetDataValue());
//            }
//            else
//            {
//                cmdStr = @"SELECT MAX(B.SPECIMEN_SER)
//                                , MAX(TO_CHAR(B.PART_JUBSU_DATE,'YYYY/MM/DD'))
//                                , MAX(B.PART_JUBSU_TIME)
//                             FROM CPL2010 B
//                            WHERE B.HOSP_CODE = :f_hosp_code
//                              AND B.SPECIMEN_SER BETWEEN :f_from_specimen_ser 
//                                                     AND :f_to_specimen_ser
//                              AND B.PART_JUBSU_DATE IS NOT NULL
//                              AND NVL(B.DC_YN,'N')  = 'N'
//                              AND B.UITAK_CODE      = '01'
//                              AND ROWNUM = 1
//                            ORDER BY B.PART_JUBSU_DATE DESC, B.PART_JUBSU_TIME DESC, B.SPECIMEN_SER DESC";

//                bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                bindVarList.Add("f_from_specimen_ser", txtFromSpecimenSer.GetDataValue());
//                bindVarList.Add("f_to_specimen_ser", txtToSpecimenSer.GetDataValue());
//            }

//            DataTable dtTable = Service.ExecuteDataTable(cmdStr, bindVarList);

//            if (dtTable != null && dtTable.Rows.Count > 0)
//            {
//                if (!TypeCheck.IsNull(dtTable.Rows[0][0]))
//                {
//                    this.MaxSpecimenSer = dtTable.Rows[0][0].ToString();
//                }
//                if (!TypeCheck.IsNull(dtTable.Rows[0][1]))
//                {
//                    this.MaxPartJubsuDate = dtTable.Rows[0][1].ToString();
//                }
//                if (!TypeCheck.IsNull(dtTable.Rows[0][2]))
//                {
//                    this.MaxPartJusbuTime = dtTable.Rows[0][2].ToString();
//                }
//            }
//        }

//        private void UpdateMaxInfo()
//        {
//            if (cbxJubsuDate.Checked)
//            {
//                SearchMaxInfo(InfoGubun.PartJubsuTime);
//            }
//            else
//            {
//                SearchMaxInfo(InfoGubun.SpecimenSer);
//            }

//            string cmdText = @"INSERT INTO CPL1001
//                                 VALUES ( SYSDATE,            :f_user_id, SYSDATE, 
//                                          TRUNC(SYSDATE),     :f_max_specimen_ser, TO_CHAR(SYSDATE, 'HH24MI'),
//                                          :f_part_jubsu_date, :f_part_jubsu_time,  '01', :f_user_id, :f_hosp_code)";

//            BindVarCollection bindVarList = new BindVarCollection();
//            bindVarList.Add("f_user_id", UserInfo.UserID);
//            bindVarList.Add("f_max_specimen_ser", this.MaxSpecimenSer);
//            bindVarList.Add("f_part_jubsu_date", this.MaxPartJubsuDate);
//            bindVarList.Add("f_part_jubsu_time", this.MaxPartJusbuTime);
//            bindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//            if (!Service.ExecuteNonQuery(cmdText, bindVarList))
//            {
//                XMessageBox.Show(Service.ErrFullMsg);
//            }

//        }
        #endregion

        private bool isFileWrite(string usbPath)
        {
            string fileCreateDay = String.Format("{0:yyyMMdd}", EnvironInfo.GetSysDate());
            string cmdStr;
            string path = "";
            string fileName = "";

            StreamWriter writer = null;

            // Cloud updated code START
//            cmdStr = @"SELECT CODE_VALUE
//                          FROM CPL0109
//                         WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
//                           AND CODE_TYPE = 'IF'
//                           AND CODE      = 'IFPATH'";

//            object retval = Service.ExecuteScalar(cmdStr);

//            if (retval != null)
//            {
//                path = retval.ToString() + fileCreateDay;
//                usbPath = usbPath + @"\" + fileCreateDay;
//            }

            CPL3010U01CodeValueResult cvRes = CloudService.Instance.Submit<CPL3010U01CodeValueResult, CPL3010U01CodeValueArgs>(new CPL3010U01CodeValueArgs());
            if (cvRes.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!TypeCheck.IsNull(cvRes.CodeValue))
                {
                    path = cvRes.CodeValue + fileCreateDay;
                    usbPath = usbPath + @"\" + fileCreateDay;
                }
            }
            // Cloud updated code END

            // 기존에 디렉토리가 존재하지 않는다면 만들어줌
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            // ファイルPATH + ファイル名
            fileName = @"\irai" + EnvironInfo.GetSysDateTime().ToString("_yyMMdd_HHmmss") + ".txt";

            // Local PCに格納する。
            writer = new StreamWriter(path + fileName, false, Encoding.GetEncoding("Shift_JIS"));

            string recode_pa = "";
            string recode_hangmog = "";
            int total_pa = this.grdPa.RowCount;

            try
            {
                #region deleted by Cloud
                //Service.BeginTransaction();

                //                if (total_pa > 0)
                //                {
                //                    cmdStr = @"UPDATE CPLREQ1
                //                              SET CUR_SEND_YN = 'N'
                //                            WHERE TRUNC(REQUEST_DATE) = TRUNC(SYSDATE)";

                //                    if (!Service.ExecuteNonQuery(cmdStr))
                //                    {
                //                        XMessageBox.Show(Service.ErrFullMsg);
                //                        Service.RollbackTransaction();
                //                        writer.Close();
                //                        return false;
                //                    }
                //                }

                //                for (int k = 0; k < total_pa; k++)
                //                {
                //                    #region [依頼電文ファイルの　患者情報セット]

                //                    this.grdPa.SetFocusToItem(k, "bunho");
                //                    int total_hangmog = this.grdHangmog.RowCount;

                //                    string tempbunho = this.grdPa.GetItemString(k, "bunho");
                //                    string tempkrt = this.grdPa.GetItemString(k, "jinryo_card");

                //                    // 患者番号、診療カードは　8桁にセット
                //                    tempbunho = tempbunho.Substring(1, 8);
                //                    tempkrt = tempkrt.Substring(1, 8);


                //                    if (grdPa.GetItemString(k, "send_yn") != "Y") continue;

                //                    /* 「患者情報」
                //                     * 区分(2)
                //                     * センターコード(6)
                //                     * 依頼キー (20)
                //                     * 科名 (15)
                //                     * 病棟名 (15)
                //                     * 外来/入院 (1)
                //                     * 医師名 (10)
                //                     * 患者番号 (15)
                //                     * 診療カード (15)
                //                     * 患者名 (20)
                //                     * 性別 (1)
                //                     * 年齢区分(1)
                //                     * 年齢(3)
                //                     * 誕生日区分(1)
                //                     * 誕生日(6)
                //                     * 採取日(6)
                //                     * 採取時間(4) 6, 未使用
                //                     * 項目個数(3)
                //                     * 身長(4)
                //                     * 体重(4)
                //                     * 尿量(4)
                //                     * 尿単位(2)
                //                     * 妊娠週数(2)
                //                     * 透析前後(1)
                //                     * 緊急報告(1)
                //                     * 空白(256までの残り)
                //                     * */
                //                    recode_pa = "";
                //                    recode_pa += this.grdPa.GetItemString(k, "recode_gubun").PadRight(2, ' ').Substring(0, 2);
                //                    recode_pa += this.grdPa.GetItemString(k, "center_code").PadRight(6, ' ').Substring(0, 6);
                //                    recode_pa += this.grdPa.GetItemString(k, "request_key").PadRight(20, ' ').Substring(0, 20);
                //                    recode_pa += this.grdPa.GetItemString(k, "gwa_name").PadRight(15, ' ').Substring(0, 15);
                //                    recode_pa += this.grdPa.GetItemString(k, "ho_dong_name").PadRight(15, ' ').Substring(0, 15);
                //                    recode_pa += this.grdPa.GetItemString(k, "in_out_gubun").PadRight(1, ' ').Substring(0, 1);
                //                    recode_pa += this.grdPa.GetItemString(k, "doctor_name").PadRight(10, ' ').Substring(0, 10);
                //                    recode_pa += tempbunho.PadRight(15, ' ').Substring(0, 15);
                //                    recode_pa += tempkrt.PadRight(15, ' ').Substring(0, 15);

                //                    recode_pa += this.grdPa.GetItemString(k, "suname").PadRight(20, ' ').Substring(0, 20);
                //                    recode_pa += this.grdPa.GetItemString(k, "sex").PadRight(1, ' ').Substring(0, 1);
                //                    recode_pa += this.grdPa.GetItemString(k, "age_gubun").PadRight(1, ' ').Substring(0, 1);
                //                    recode_pa += this.grdPa.GetItemString(k, "age").PadLeft(3, '0').Substring(0, 3);
                //                    recode_pa += this.grdPa.GetItemString(k, "birth_gubun").PadRight(1, ' ').Substring(0, 1);
                //                    recode_pa += this.grdPa.GetItemString(k, "birth").PadRight(6, ' ').Substring(0, 6);
                //                    recode_pa += this.grdPa.GetItemString(k, "jubsu_date").PadRight(6, ' ').Substring(0, 6);
                //                    recode_pa += this.grdPa.GetItemString(k, "jubsu_time").PadRight(4, '0').Substring(0, 4);
                //                    recode_pa += total_hangmog.ToString().PadLeft(3, '0').Substring(0, 3);
                //                    recode_pa += this.grdPa.GetItemString(k, "height").PadLeft(4, ' ').Substring(0, 4);
                //                    recode_pa += this.grdPa.GetItemString(k, "weight").PadLeft(4, ' ').Substring(0, 4);
                //                    recode_pa += this.grdPa.GetItemString(k, "nyo_ryang").PadLeft(4, ' ').Substring(0, 4);
                //                    recode_pa += this.grdPa.GetItemString(k, "nyo_danui").PadLeft(2, ' ').Substring(0, 2); ;
                //                    recode_pa += this.grdPa.GetItemString(k, "pregnancy_jusu").PadRight(2, ' ').Substring(0, 2);
                //                    recode_pa += this.grdPa.GetItemString(k, "dialysis").PadRight(1, ' ').Substring(0, 1);
                //                    if (this.grdPa.GetItemString(k, "emergency") == "Y")
                //                        recode_pa += "1";
                //                    else
                //                        recode_pa += " ";
                //                    recode_pa = recode_pa.PadRight(256, ' ');

                //                    writer.WriteLine(recode_pa);
                //                    #endregion

                //                    #region [CPLREQ1の　データ作成＆更新]

                //                    BindVarCollection bindVar = new BindVarCollection();
                //                    bindVar.Add("f_user_id", UserInfo.UserID);
                //                    bindVar.Add("f_request_key", this.grdPa.GetItemString(k, "request_key"));
                //                    bindVar.Add("f_bunho", this.grdPa.GetItemString(k, "bunho"));
                //                    bindVar.Add("f_jubsu_date", this.grdPa.GetItemString(k, "jubsu_date"));
                //                    bindVar.Add("f_jubsu_time", this.grdPa.GetItemString(k, "jubsu_time"));
                //                    bindVar.Add("f_hangmog_cnt", total_hangmog.ToString());
                //                    bindVar.Add("f_urine", this.grdPa.GetItemString(k, "nyo_ryang"));
                //                    bindVar.Add("f_send_yn", this.grdPa.GetItemString(k, "send_yn"));

                //                    //해당 키 존재여부 파악
                //                    cmdStr = @"SELECT 'Y' 
                //                             FROM CPLREQ1
                //                            WHERE REQUEST_KEY = :f_request_key";

                //                    object retVal = Service.ExecuteScalar(cmdStr, bindVar);

                //                    if (!TypeCheck.IsNull(retVal) && retVal.ToString() == "Y")
                //                    {
                //                        //send data update
                //                        cmdStr = @"UPDATE CPLREQ1
                //                                  SET UPD_DATE     = SYSDATE
                //                                    , UPD_ID       = :f_user_id
                //                                    , REQUEST_DATE = SYSDATE
                //                                    , REQUEST_ID   = :f_user_id
                //                                    , BUNHO        = :f_bunho
                //                                    , JUBSU_DATE   = :f_jubsu_date
                //                                    , JUBSU_TIME   = :f_jubsu_time
                //                                    , HANGMOG_CNT  = :f_hangmog_cnt
                //                                    , URINE        = :f_urine
                //                                    , SEND_YN      = :f_send_yn
                //                                    , CUR_SEND_YN  = :f_send_yn
                //                                WHERE REQUEST_KEY  = :f_request_key";
                //                    }
                //                    else
                //                    {
                //                        //send data insert
                //                        cmdStr = @"INSERT INTO CPLREQ1 ( SYS_DATE
                //                                                   , SYS_ID
                //                                                   , UPD_DATE
                //                                                   , UPD_ID 
                //                                                   , REQUEST_KEY
                //                                                   , REQUEST_DATE
                //                                                   , REQUEST_ID
                //                                                   , BUNHO
                //                                                   , JUBSU_DATE
                //                                                   , JUBSU_TIME
                //                                                   , HANGMOG_CNT
                //                                                   , URINE
                //                                                   , SEND_YN
                //                                                   , CUR_SEND_YN
                //                                                   ) VALUES (
                //                                                     SYSDATE
                //                                                   , :f_user_id
                //                                                   , SYSDATE
                //                                                   , :f_user_id
                //                                                   , :f_request_key
                //                                                   , SYSDATE
                //                                                   , :f_user_id
                //                                                   , :f_bunho
                //                                                   , :f_jubsu_date
                //                                                   , :f_jubsu_time
                //                                                   , :f_hangmog_cnt
                //                                                   , :f_urine
                //                                                   , :f_send_yn
                //                                                   , :f_send_yn
                //                                                   )";
                //                    }

                //                    if (!Service.ExecuteNonQuery(cmdStr, bindVar))
                //                    {
                //                        Service.RollbackTransaction();
                //                        XMessageBox.Show(Service.ErrFullMsg);
                //                        break;
                //                    }

                //                    #endregion

                //                    #region [依頼電文ファイルの　項目情報セット]
                //                    /* 「項目情報」
                //                     * 区分(2)
                //                     * センターコード(6)
                //                     * 依頼キー (20)
                //                     * 項目コード(9)
                //                     * 負荷時間(16)
                //                     * 空白(256までの残り)
                //                     * */

                //                    recode_hangmog = "";
                //                    string recode_hangmog_2 = "";

                //                    for (int j = 0; j < total_hangmog; j++)
                //                    {
                //                        if ((j % 9) == 0)
                //                        {
                //                            recode_hangmog += this.grdHangmog.GetItemString(0, "recode_gubun").Substring(0, 2);
                //                            recode_hangmog += this.grdHangmog.GetItemString(0, "center_code").PadRight(6, ' ').Substring(0, 6);
                //                            recode_hangmog += this.grdHangmog.GetItemString(0, "request_key").PadRight(20, ' ').Substring(0, 20);
                //                            //recode_hangmog += this.grdHangmog.GetItemString(0, "hospital_code").PadLeft(8, ' ');
                //                        }
                //                        if (j < total_hangmog)
                //                        {
                //                            recode_hangmog_2 = "";
                //                            /* 
                //                             * 016318 [(外)尿中Ｃペプタイド　前 [蓄尿]]
                //                               016331 [(外)尿中Ｃペプタイド　前 [尿]]
                //                             * 
                //                             * 尿の項目がサンリツに存在しない。
                //                             * 尿量を見て「蓄尿」か「尿」かを区別する。
                //                             * 
                //                             * 項目が両方がないとオーダでは
                //                             * 先生がオーダしても検査室で「蓄尿」か「尿」か分からない。
                //                             * ＯＣＳでは項目を増やして区分する。
                //                             * 
                //                             * 外注に依頼時は一つの項目　016318　に渡す。
                //                             * その元の項目データが　「CPL0101」の　「JANGBI_OUT_CODE」 にある。
                //                             * 
                //                             */
                //                            recode_hangmog_2 += this.grdHangmog.GetItemString(j, "san_code").PadRight(15, ' ').Substring(0, 15);
                //                            recode_hangmog_2 = recode_hangmog_2.PadRight(25, ' ');
                //                        }

                //                        recode_hangmog += recode_hangmog_2;

                //                        if (((j > 0) && (j % 9) == 8) || (total_hangmog - 1) == j)
                //                        {
                //                            recode_hangmog = recode_hangmog.PadRight(256, ' ');
                //                            writer.WriteLine(recode_hangmog);
                //                            recode_hangmog = "";
                //                        }
                //                    }
                //                    #endregion
                //                }
                #endregion

                #region Updated by Cloud
                List<CPL3010U01IsFileWriteInfo> lstData = new List<CPL3010U01IsFileWriteInfo>();

                for (int k = 0; k < total_pa; k++)
                {
                    #region [依頼電文ファイルの　患者情報セット]

                    this.grdPa.SetFocusToItem(k, "bunho");
                    int total_hangmog = this.grdHangmog.RowCount;

                    string tempbunho = this.grdPa.GetItemString(k, "bunho");
                    string tempkrt = this.grdPa.GetItemString(k, "jinryo_card");

                    // 患者番号、診療カードは　8桁にセット
                    tempbunho = tempbunho.Substring(1, 8);
                    tempkrt = tempkrt.Substring(1, 8);


                    if (grdPa.GetItemString(k, "send_yn") != "Y") continue;

                    /* 「患者情報」
                     * 区分(2)
                     * センターコード(6)
                     * 依頼キー (20)
                     * 科名 (15)
                     * 病棟名 (15)
                     * 外来/入院 (1)
                     * 医師名 (10)
                     * 患者番号 (15)
                     * 診療カード (15)
                     * 患者名 (20)
                     * 性別 (1)
                     * 年齢区分(1)
                     * 年齢(3)
                     * 誕生日区分(1)
                     * 誕生日(6)
                     * 採取日(6)
                     * 採取時間(4) 6, 未使用
                     * 項目個数(3)
                     * 身長(4)
                     * 体重(4)
                     * 尿量(4)
                     * 尿単位(2)
                     * 妊娠週数(2)
                     * 透析前後(1)
                     * 緊急報告(1)
                     * 空白(256までの残り)
                     * */
                    recode_pa = "";
                    recode_pa += this.grdPa.GetItemString(k, "recode_gubun").PadRight(2, ' ').Substring(0, 2);
                    recode_pa += this.grdPa.GetItemString(k, "center_code").PadRight(6, ' ').Substring(0, 6);
                    recode_pa += this.grdPa.GetItemString(k, "request_key").PadRight(20, ' ').Substring(0, 20);
                    recode_pa += this.grdPa.GetItemString(k, "gwa_name").PadRight(15, ' ').Substring(0, 15);
                    recode_pa += this.grdPa.GetItemString(k, "ho_dong_name").PadRight(15, ' ').Substring(0, 15);
                    recode_pa += this.grdPa.GetItemString(k, "in_out_gubun").PadRight(1, ' ').Substring(0, 1);
                    recode_pa += this.grdPa.GetItemString(k, "doctor_name").PadRight(10, ' ').Substring(0, 10);
                    recode_pa += tempbunho.PadRight(15, ' ').Substring(0, 15);
                    recode_pa += tempkrt.PadRight(15, ' ').Substring(0, 15);

                    recode_pa += this.grdPa.GetItemString(k, "suname").PadRight(20, ' ').Substring(0, 20);
                    recode_pa += this.grdPa.GetItemString(k, "sex").PadRight(1, ' ').Substring(0, 1);
                    recode_pa += this.grdPa.GetItemString(k, "age_gubun").PadRight(1, ' ').Substring(0, 1);
                    recode_pa += this.grdPa.GetItemString(k, "age").PadLeft(3, '0').Substring(0, 3);
                    recode_pa += this.grdPa.GetItemString(k, "birth_gubun").PadRight(1, ' ').Substring(0, 1);
                    recode_pa += this.grdPa.GetItemString(k, "birth").PadRight(6, ' ').Substring(0, 6);
                    recode_pa += this.grdPa.GetItemString(k, "jubsu_date").PadRight(6, ' ').Substring(0, 6);
                    recode_pa += this.grdPa.GetItemString(k, "jubsu_time").PadRight(4, '0').Substring(0, 4);
                    recode_pa += total_hangmog.ToString().PadLeft(3, '0').Substring(0, 3);
                    recode_pa += this.grdPa.GetItemString(k, "height").PadLeft(4, ' ').Substring(0, 4);
                    recode_pa += this.grdPa.GetItemString(k, "weight").PadLeft(4, ' ').Substring(0, 4);
                    recode_pa += this.grdPa.GetItemString(k, "nyo_ryang").PadLeft(4, ' ').Substring(0, 4);
                    recode_pa += this.grdPa.GetItemString(k, "nyo_danui").PadLeft(2, ' ').Substring(0, 2); ;
                    recode_pa += this.grdPa.GetItemString(k, "pregnancy_jusu").PadRight(2, ' ').Substring(0, 2);
                    recode_pa += this.grdPa.GetItemString(k, "dialysis").PadRight(1, ' ').Substring(0, 1);
                    if (this.grdPa.GetItemString(k, "emergency") == "Y")
                        recode_pa += "1";
                    else
                        recode_pa += " ";
                    recode_pa = recode_pa.PadRight(256, ' ');
                    recode_pa += this.grdPa.GetItemString(k, "comment").PadRight(20, ' ').Substring(0, 20);
                    recode_pa += this.grdPa.GetItemString(k, "specimen_ser").PadRight(11, ' ').Substring(0, 11);
                    writer.WriteLine(recode_pa);
                    #endregion

                    #region [CPLREQ1の　データ作成＆更新]

                    CPL3010U01IsFileWriteInfo item = new CPL3010U01IsFileWriteInfo();
                    item.Bunho = this.grdPa.GetItemString(k, "bunho");
                    item.HangmogCnt = total_hangmog.ToString();
                    item.JubsuDate = this.grdPa.GetItemString(k, "jubsu_date");
                    item.JubsuTime = this.grdPa.GetItemString(k, "jubsu_time");
                    item.RequestKey = this.grdPa.GetItemString(k, "request_key");
                    item.SendYn = this.grdPa.GetItemString(k, "send_yn");
                    item.Urine = this.grdPa.GetItemString(k, "nyo_ryang");

                    lstData.Add(item);

                    #endregion

                    #region [依頼電文ファイルの　項目情報セット]
                    /* 「項目情報」
                     * 区分(2)
                     * センターコード(6)
                     * 依頼キー (20)
                     * 項目コード(9)
                     * 負荷時間(16)
                     * 空白(256までの残り)
                     * */

                    recode_hangmog = "";
                    string recode_hangmog_2 = "";

                    for (int j = 0; j < total_hangmog; j++)
                    {
                        if ((j % 9) == 0)
                        {
                            recode_hangmog += this.grdHangmog.GetItemString(0, "recode_gubun").Substring(0, 2);
                            recode_hangmog += this.grdHangmog.GetItemString(0, "center_code").PadRight(6, ' ').Substring(0, 6);
                            recode_hangmog += this.grdHangmog.GetItemString(0, "request_key").PadRight(20, ' ').Substring(0, 20);
                            //recode_hangmog += this.grdHangmog.GetItemString(0, "hospital_code").PadLeft(8, ' ');
                        }
                        if (j < total_hangmog)
                        {
                            recode_hangmog_2 = "";
                            /* 
                             * 016318 [(外)尿中Ｃペプタイド　前 [蓄尿]]
                               016331 [(外)尿中Ｃペプタイド　前 [尿]]
                             * 
                             * 尿の項目がサンリツに存在しない。
                             * 尿量を見て「蓄尿」か「尿」かを区別する。
                             * 
                             * 項目が両方がないとオーダでは
                             * 先生がオーダしても検査室で「蓄尿」か「尿」か分からない。
                             * ＯＣＳでは項目を増やして区分する。
                             * 
                             * 外注に依頼時は一つの項目　016318　に渡す。
                             * その元の項目データが　「CPL0101」の　「JANGBI_OUT_CODE」 にある。
                             * 
                             */
                            recode_hangmog_2 += this.grdHangmog.GetItemString(j, "san_code").PadRight(15, ' ').Substring(0, 15);
                            recode_hangmog_2 = recode_hangmog_2.PadRight(25, ' ');
                        }

                        recode_hangmog += recode_hangmog_2;

                        if (((j > 0) && (j % 9) == 8) || (total_hangmog - 1) == j)
                        {
                            recode_hangmog = recode_hangmog.PadRight(256, ' ');
                            writer.WriteLine(recode_hangmog);
                            recode_hangmog = "";
                        }
                    }
                    #endregion
                }

                CPL3010U01IsFileWriteArgs args = new CPL3010U01IsFileWriteArgs();
                args.TotalPa = total_pa.ToString();
                args.UserId = UserInfo.UserID;
                args.FileWriteLst = lstData;
                CPL3010U01IsFileWriteResult res = CloudService.Instance.Submit<CPL3010U01IsFileWriteResult, CPL3010U01IsFileWriteArgs>(args);

                if (res.ExecutionStatus != ExecutionStatus.Success || !res.Result)
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }
                #endregion

                this.WriteHistory();

                writer.Close();
            }
            catch
            {
                //Service.RollbackTransaction();
                return false;
            }
            finally
            {

            }
            //Service.CommitTransaction();

            // 外注依頼ファイルCOPY
            if (this.CopyDirectory(path, usbPath)) return true;
            else return false;
        }

        private bool WriteHistory()
        {
            //bool result = true;

            #region deleted by Cloud
            ////Service.BeginTransaction();

            //string procedure_name = "";
            //BindVarCollection bind = new BindVarCollection();

            //ArrayList inList = new ArrayList();
            //ArrayList outList = new ArrayList();

            //for (int i = 0; i < this.grdPa.RowCount; i++)
            //{
            //    if (this.grdPa.GetItemString(i, "send_yn") != "Y")
            //        continue;

            //    inList = new ArrayList();
            //    outList = new ArrayList();
            //    /*
            //        I_CREATE_USER    
            //        I_CREATE_DATE    
            //        I_CREATE_TIME    
            //        I_IRAI_KEY       
            //        I_BUNHO          
            //        I_PART_JUBSU_DATE
            //        I_PART_JUBSU_TIME
            //        I_GUBUN          
            //        I_CENTER_CODE    

            //     */
            //    inList.Add(UserInfo.UserID);    // I_CREATE_USER
            //    inList.Add(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));    // I_CREATE_DATE
            //    inList.Add(EnvironInfo.GetSysDateTime().ToString("HHmm"));      // I_CREATE_TIME
            //    inList.Add(this.grdPa.GetItemString(i, "request_key"));         // I_IRAI_KEY
            //    inList.Add(this.grdPa.GetItemString(i, "bunho"));               // I_BUNHO
            //    inList.Add(DateTime.Parse("20" + this.grdPa.GetItemString(i, "jubsu_date").Substring(0, 2) + "/" + this.grdPa.GetItemString(i, "jubsu_date").Substring(2, 2) + "/" + this.grdPa.GetItemString(i, "jubsu_date").Substring(4, 2)).ToString("yyyy/MM/dd"));          // I_PART_JUBSU_DATE
            //    inList.Add(this.grdPa.GetItemString(i, "jubsu_time"));          // I_PART_JUBSU_TIME
            //    inList.Add(this.grdPa.GetItemString(i, "recode_gubun"));        // I_GUBUN
            //    inList.Add(this.grdPa.GetItemString(i, "center_code").Trim());         // I_CENTER_CODE

            //    try
            //    {
            //        procedure_name = "PR_CPL_INSERT_CPL9000";
            //        Service.ExecuteProcedure(procedure_name, inList, outList);

            //        if (outList[0].ToString() != "-1")
            //        {

            //        }
            //        else
            //        {
            //            throw new Exception(Resources.Exception + Service.ErrMsg);
            //        }
            //    }
            //    catch (Exception ee)
            //    {
            //        result = false;
            //        Service.RollbackTransaction();
            //        XMessageBox.Show(ee.Message);
            //    }
            //}
            ////Service.CommitTransaction();
            #endregion

            // Cloud updated code START
            List<CPL3010U01PrCplInsertCpl9000Info> lstData = new List<CPL3010U01PrCplInsertCpl9000Info>();
            for (int i = 0; i < this.grdPa.RowCount; i++)
            {
                if (this.grdPa.GetItemString(i, "send_yn") != "Y") continue;

                CPL3010U01PrCplInsertCpl9000Info item = new CPL3010U01PrCplInsertCpl9000Info();
                item.Bunho = this.grdPa.GetItemString(i, "bunho");
                item.CenterCode = this.grdPa.GetItemString(i, "center_code").Trim();
                item.Gubun = this.grdPa.GetItemString(i, "recode_gubun");
                item.IraiKey = this.grdPa.GetItemString(i, "request_key");
                item.PartJubsuDate = DateTime.Parse("20" + this.grdPa.GetItemString(i, "jubsu_date").Substring(0, 2)
                    + "/" + this.grdPa.GetItemString(i, "jubsu_date").Substring(2, 2)
                    + "/" + this.grdPa.GetItemString(i, "jubsu_date").Substring(4, 2)).ToString("yyyy/MM/dd").ToString();
                item.PartJubsuTime = this.grdPa.GetItemString(i, "jubsu_time");

                lstData.Add(item);
            }

            CPL3010U01PrCplInsertCpl9000Args args = new CPL3010U01PrCplInsertCpl9000Args();
            args.UserId = UserInfo.UserID;
            args.PrCplLst = lstData;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, CPL3010U01PrCplInsertCpl9000Args>(args);

            if (res.ExecutionStatus != ExecutionStatus.Success)
            {
                return false;
            }

            if (!res.Result)
            {
                throw new Exception(Resources.Exception + Service.ErrMsg);
            }
            // Cloud updated code END

            return true;
        }

        /// <summary>  
        /// 디렉토리 Copy  
        /// </summary>  
        /// <param name="sourcePath">원본 디렉토리 경로</param>  
        /// <param name="destinationPath">생성 디렉토리 경로</param>  
        public bool CopyDirectory(string sourcePath, string destinationPath)
        {
            DirectoryInfo source = new DirectoryInfo(sourcePath);
            DirectoryInfo destination = new DirectoryInfo(destinationPath);
            CopyDirectory(source, destination);

            return true;
        }

        /// <summary>  
        /// 디렉토리 Copy  
        /// </summary>  
        /// <param name="source">원본 디렉토리</param>  
        /// <param name="destination">생성 디렉토리</param>  
        public void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            CreateDirectory(destination);

            // Copy all files.  
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name));
            }

            // Process subdirectories.  
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                // Get destination directory.  
                string destinationDir = Path.Combine(destination.FullName, dir.Name);
                CopyDirectory(dir, new DirectoryInfo(destinationDir)); // Call CopyDirectory() recursively.  
            }
        }

        public void CreateDirectory(DirectoryInfo dInfo)
        {
            if (!dInfo.Exists) dInfo.Create();
            else
            {
                Directory.Delete(dInfo.FullName, true);
                dInfo.Create();
            }
        }

        public static string getWordByByte(string src, int sPos, int byteCount)
        {
            System.Text.Encoding myEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");

            byte[] buf = myEncoding.GetBytes(src);

            string result = myEncoding.GetString(buf, sPos, byteCount);

            //if (byteCount != result.Length)
            //{
            //    result = myEncoding.GetString(buf, sPos, byteCount);
            //}
            return result;
        }

        public static string getWordByByte(string src, int byteCount)
        {
            System.Text.Encoding myEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");

            byte[] buf = myEncoding.GetBytes(src);

            string result = myEncoding.GetString(buf, byteCount, buf.Length - byteCount);

            return result;
        }

        private void FileRead()
        {
            string jubsuday = this.dtpJubsuDate.GetDataValue().Replace("/", "");
            string path = @"C:\SRL_FILES\" + jubsuday;

            //기존에 디렉토리가 존재하지 않는다면 만들어줌
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filepath = path + @"\KEKADATA.DAT";

            StreamReader reader = new StreamReader(filepath, Encoding.GetEncoding("Shift_JIS"));

            //read the file back and display the contents
            //            StreamReader reader=File.OpenText(filepath);
            string output = "";
            string output2;
            int cnt = 0;

            this.layResult.Reset();
            while ((output = reader.ReadLine()) != null)
            {
                if (output.Length < 20) break;

                //                XMessageBox.Show(output);
                string request_key = output.Substring(8, 20).Trim();
                string srl_code = output.Substring(78, 17).Trim();
                string cpl_result = output.Substring(95, 8).Trim();
                string standard_yn = output.Substring(103, 1).Trim();
                string comment1 = output.Substring(104, 3).Trim();
                string comment2 = output.Substring(107, 3).Trim();

                this.layResult.InsertRow(-1);
                this.layResult.SetItemValue(cnt, "request_key", request_key);
                this.layResult.SetItemValue(cnt, "srl_code", srl_code);
                this.layResult.SetItemValue(cnt, "cpl_result", cpl_result);
                this.layResult.SetItemValue(cnt, "standard_yn", standard_yn);
                this.layResult.SetItemValue(cnt, "comment1", comment1);
                this.layResult.SetItemValue(cnt, "comment2", comment2);

                cnt++;

                output2 = output.Substring(110, 32);
                for (int i = 1; i < 5; i++)
                {
                    if (output2.Trim().Length == 0)
                        break;

                    srl_code = output2.Substring(0, 17).Trim();
                    cpl_result = output2.Substring(17, 8).Trim();
                    standard_yn = output2.Substring(25, 1).Trim();
                    comment1 = output2.Substring(26, 3).Trim();
                    comment2 = output2.Substring(29, 3).Trim();

                    //                    if ( standard_yn == "E" )
                    //                        cpl_result = cpl_result + "以下";
                    //                    else if ( standard_yn == "U" )
                    //                        cpl_result = cpl_result + "以上";
                    //                    else if ( standard_yn == "L" )
                    //                        cpl_result = cpl_result + "未満";
                    //                    else if ( standard_yn == "O" )
                    //                        cpl_result = cpl_result + "超過";

                    this.layResult.InsertRow(-1);
                    this.layResult.SetItemValue(cnt, "request_key", request_key);
                    this.layResult.SetItemValue(cnt, "srl_code", srl_code);
                    this.layResult.SetItemValue(cnt, "cpl_result", cpl_result);
                    this.layResult.SetItemValue(cnt, "standard_yn", standard_yn);
                    this.layResult.SetItemValue(cnt, "comment1", comment1);
                    this.layResult.SetItemValue(cnt, "comment2", comment2);

                    cnt++;

                    if (i < 4)
                        output2 = output.Substring(110 + 32 * i, 32);

                }

            }
            reader.Close();

            // Cloud updated code START
            //layResult.SaveLayout();
            if (null != grdResult)
            {
                List<CPL3010U01SaveLayoutInfo> lstData = new List<CPL3010U01SaveLayoutInfo>();
                for (int i = 0; i < grdResult.LayoutTable.Rows.Count; i++)
                {
                    CPL3010U01SaveLayoutInfo item = new CPL3010U01SaveLayoutInfo();
                    item.BmlCode = grdResult.LayoutTable.Rows[i]["bml_code"].ToString();
                    item.Comments1 = grdResult.LayoutTable.Rows[i]["comment1"].ToString();
                    item.Comments2 = grdResult.LayoutTable.Rows[i]["comment2"].ToString();
                    item.CplResult = grdResult.LayoutTable.Rows[i]["cpl_result"].ToString();
                    item.RequestKey = grdResult.LayoutTable.Rows[i]["request_key"].ToString();
                    item.StandardYn = grdResult.LayoutTable.Rows[i]["standard_yn"].ToString();

                    lstData.Add(item);
                }

                CPL3010U01SaveLayoutArgs args = new CPL3010U01SaveLayoutArgs();
                args.UserId = UserInfo.UserID;
                args.SaveLayoutLst = lstData;
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, CPL3010U01SaveLayoutArgs>(args);
            }
            // Cloud updated code END

            if (!grdResult.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        #endregion

        #region Cloud updated code

        #region InitItemControls
        /// <summary>
        /// InitItemControls
        /// </summary>
        private void InitItemControls()
        {
            // grdHangmog
            grdHangmog.ParamList = new List<string>(new string[] { "f_request_key", "f_specimen_ser" });
            grdHangmog.ExecuteQuery = GetGrdHangmog;

            // grdResult
            grdResult.ParamList = new List<string>(new string[] { "f_request_key" });
            grdResult.ExecuteQuery = GetGrdResult;

            // laySpecimenInfo
            laySpecimenInfo.ParamList = new List<string>(new string[] { "f_specimen_ser" });
            laySpecimenInfo.ExecuteQuery = GetLaySpecimenInfo;
        }
        #endregion

        #region GetGrdHangmog
        /// <summary>
        /// GetGrdHangmog
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdHangmog(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL3010U01GrdHangmogArgs args = new CPL3010U01GrdHangmogArgs();
            args.RequestKey = bvc["f_request_key"].VarValue;
            // https://sofiamedix.atlassian.net/browse/MED-16101
            args.SpecimenSer = bvc["f_specimen_ser"].VarValue;
            // https://sofiamedix.atlassian.net/browse/MED-16341
            args.UitakCode = cboMasterType.GetDataValue().Equals("04") ? cboMasterType.GetDataValue() : "01";
            CPL3010U01GrdHangmogResult res = CloudService.Instance.Submit<CPL3010U01GrdHangmogResult, CPL3010U01GrdHangmogArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdHangmogLst.ForEach(delegate(CPL3010U01GrdHangmogInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.RecodeGubun,
                        item.CenterCode,
                        item.RequestKey,
                        item.HospitalCode,
                        item.HangmogCode,
                        item.SanCode,
                        item.SpecimenCode,
                        item.Emergency,
                        item.EmptyString,
                        item.SpecimenSer,
                        item.JundalGubunName,
                        item.GumsaName,
                        item.SpecimenName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdResult
        /// <summary>
        /// GetGrdResult
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdResult(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL3010U01GrdResultArgs args = new CPL3010U01GrdResultArgs();
            args.RequestKey = bvc["f_request_key"].VarValue;
            CPL3010U01GrdResultResult res = CloudService.Instance.Submit<CPL3010U01GrdResultResult, CPL3010U01GrdResultArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdResultLst.ForEach(delegate(CPL3010U01GrdResultInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.RecodeGubun,
                        item.CenterCode,
                        item.RequestKey,
                        item.HangmogCode,
                        item.SrlCode,
                        item.SpecimenCode,
                        item.Emergency,
                        item.EmptyString,
                        item.SpecimenSer,
                        item.JundalGubunName,
                        item.LabNo,
                        item.CplResult,
                        item.StandardYn,
                        item.Comments,
                        item.Vitros,
                        item.ResultYn,
                        item.GumsaName,
                        item.SpecimenName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLaySpecimenInfo
        /// <summary>
        /// GetLaySpecimenInfo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLaySpecimenInfo(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL3010U01LaySpecimenArgs args = new CPL3010U01LaySpecimenArgs();
            args.SpecimenSer = bvc["f_specimen_ser"].VarValue;
            CPL3010U01LaySpecimenResult res = CloudService.Instance.Submit<CPL3010U01LaySpecimenResult, CPL3010U01LaySpecimenArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL3010U01LaySpecimenInfo item in res.LaySpecimenLst)
                {
                    lObj.Add(new object[] 
                    {
                        item.Bunho,
                        item.Suname,
                        item.Sex,
                        item.Birth,
                        item.Gwa,
                        item.DoctorName,
                        item.HoDong,
                        item.HoCode,
                        item.OrderDate,
                        item.JubsuDate,
                        item.PartJubsuDate,
                        item.JubsuTime,
                        item.PartJubsuTime,
                        item.Jubsuja,
                        item.InOutGubun,
                        item.JundalGubun,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.Tat1,
                        item.Tat2,
                        item.Age,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetLayPrint2ForXButton1Click
        /// <summary>
        /// GetLayPrint2ForXButton1Click
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayPrint2ForXButton1Click(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL3010U01LayPrint2Args args = new CPL3010U01LayPrint2Args();
            args.CbxJubsuDate               = cbxJubsuDate.Checked;
            args.FromPartJubsuDate          = bvc["f_from_part_jubsu_date"].VarValue;
            args.ToPartJubsuDate            = bvc["f_to_part_jubsu_date"].VarValue;
            args.FromSeq                    = bvc["f_from_seq"].VarValue;
            args.ToSeq                      = bvc["f_to_seq"].VarValue;
            args.FromSpecimenSer            = bvc["f_from_specimen_ser"].VarValue;
            args.ToSpecimenSer              = bvc["f_to_specimen_ser"].VarValue;
            CPL3010U01LayPrint2Result res = CloudService.Instance.Submit<CPL3010U01LayPrint2Result, CPL3010U01LayPrint2Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayPrintLst.ForEach(delegate(CPL3010U01LayPrint2Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.PartJubsuDate,
                        item.Bunho,
                        item.Suname2,
                        item.HangmogCode,
                        item.GumsaNm,
                        item.GwaName,
                        item.DoctorName,
                        item.Sex,
                        item.Age,
                        item.SpecimenSer,
                        item.NyoRyang,
                        item.NyoDanui,
                        item.Emergency,
                        
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdPa
        /// <summary>
        /// GetGrdPa
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPa(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL3010U01GrdPaArgs args = new CPL3010U01GrdPaArgs();
            args.CbxJubsuDate           = cbxJubsuDate.Checked;
            args.FromPartJubsuDate      = bvc["f_from_part_jubsu_date"].VarValue;
            args.ToPartJubsuDate        = bvc["f_to_part_jubsu_date"].VarValue;
            args.FromSeq                = bvc["f_from_seq"].VarValue;
            args.ToSeq                  = bvc["f_to_seq"].VarValue;
            args.FromSpecimenSer        = bvc["f_from_specimen_ser"].VarValue;
            args.ToSpecimenSer          = bvc["f_to_specimen_ser"].VarValue;
            args.UitakCode              = bvc["f_uitak_code"].VarValue;
            args.CenterCode             = bvc["f_center_code"].VarValue;
            CPL3010U01GrdPaResult res = CloudService.Instance.Submit<CPL3010U01GrdPaResult, CPL3010U01GrdPaArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdPaLst.ForEach(delegate(CPL3010U01GrdPaInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.RecodeGubun,
                        item.CenterCode,
                        item.RequestKey,
                        item.HospitalCode,
                        item.GwaName,
                        item.HoDongName,
                        item.InOutGubun,
                        item.DoctorName,
                        item.Bunho,
                        item.JinryoCard,
                        item.Suname2,
                        item.Sex,
                        item.AgeGubun,
                        item.Age,
                        item.BirthGubun,
                        item.Birth,
                        item.JubsuDate,
                        item.JubsuTime,
                        item.HangmogCnt,
                        item.Height,
                        item.Weight,
                        item.NyoRyang,
                        item.NyoDanui,
                        item.PregnancyJusu,
                        item.Dialysis,
                        item.Emergency,
                        item.Comments,
                        item.EmptyString,
                        item.SendYn,
                        item.NString,
                        item.SpecimenSer
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetLayPrint2ForBtnPrePrintClick
        /// <summary>
        /// GetLayPrint2ForBtnPrePrintClick
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayPrint2ForBtnPrePrintClick(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL3010U01PrePrintArgs args = new CPL3010U01PrePrintArgs();
            args.IraiStr = bvc["f_irai_str"].VarValue;
            args.UitakCode = bvc["f_uitak_code"].VarValue;
            CPL3010U01PrePrintResult res = CloudService.Instance.Submit<CPL3010U01PrePrintResult, CPL3010U01PrePrintArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.PrePrintLst.ForEach(delegate(CPL3010U01PrePrintInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.PartJubsuDate,
                        item.Bunho,
                        item.Suname2,
                        item.HangmogCode,
                        item.HangmogName,
                        item.SpecimenName,
                        item.GwaName,
                        item.DoctorName,
                        item.Sex,
                        item.Age,
                        item.SpecimenSer,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #endregion

        /***************** XSave Performer ***************************/
        #region [ XSavePerformer ]
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private CPL3010U01 parent = null;
//            public XSavePerformer(CPL3010U01 parent)
//            {
//                this.parent = parent;
//            }
//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                //Grid에서 넘어온 Bind 변수에 f_user_id SET
//                item.BindVarList.Add("f_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                cmdText = @"UPDATE CPL3020
//                               SET CPL_RESULT    = :f_cpl_result
//                                 , STANDARD_YN   = :f_standard_yn
//                                 , COMMENTS      = FN_CPL_CODE_NAME('S_COM1',:f_comments1)||' '||FN_CPL_CODE_NAME('S_COM1',:f_comments2)
//                                 , VITROS        = 'Y'    /*결과로드 업데이트*/
//                                 , UPD_DATE      = SYSDATE
//                                 , USER_ID       = :f_user_id
//                                 , RESULT_DATE   = TRUNC(SYSDATE)
//                                 , RESULT_TIME   = TO_CHAR(SYSDATE,'HH24MI')
//                                 , CONFIRM_DATE  = TRUNC(SYSDATE)
//                                 , CONFIRM_YN    = 'Y'
//                                 , RESULT_YN     = 'Y'
//                                 , DISPLAY_YN    = 'Y'
//                             WHERE HOSP_CODE     = :f_hosp_code
//                               AND SPECIMEN_SER  = SUBSTR(:f_request_key,3)     
//                               AND HANGMOG_CODE  = :f_bml_code";


//                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                {
//                    cmdText = @"UPDATE CPL3010
//                                   SET USER_ID      = :f_user_id
//                                     , UPD_DATE     = SYSDATE
//                                     , RESULT_DATE  = TRUNC(SYSDATE)           
//                                     , RESULT_TIME  = TO_CHAR(SYSDATE,'HH24MI')
//                                 WHERE HOSP_CODE    = :f_hosp_code
//                                   AND SPECIMEN_SER = SUBSTR(:f_request_key,3)";

//                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                    {
//                        return false;
//                    }

//                }
//                else
//                {
//                    return false;
//                }

//                return true;
//            }
//        }
        #endregion

        #region https://sofiamedix.atlassian.net/browse/MED-16236

        private void RequestExportFile(bool validated)
        {
            // Do not pass the validation
            if (!validated)
            {
                // No item was selected
                string msg = Resources.msg;
                XMessageBox.Show(msg, Resources.msg_caption, MessageBoxIcon.Warning);
                return;
            }

            List<CPL3010U01GrdPaInfo> lstPa;
            List<CPL3010U01GrdHangmogInfo> lstHangmog;
            List<CPL3010U01IsFileWriteInfo> lstCplReq;
            this.GetListGrd(out lstPa, out lstHangmog, out lstCplReq);

            CPL3010U01ExportFileArgs args = new CPL3010U01ExportFileArgs();
            args.PaItem = lstPa;
            args.HangmogItem = lstHangmog;
            // https://sofiamedix.atlassian.net/browse/MED-16419
            args.TotalPa = grdPa.RowCount.ToString();
            args.UserId = UserInfo.UserID;
            args.FileWriteItem = lstCplReq;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, CPL3010U01ExportFileArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
            {
                // Succeeded
                XMessageBox.Show(Resources.MSG_EXPORT_SUCCESS, Resources.CAP_EXPORT, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Print
                this.btnPrePrint.PerformClick();
            }
            else
            {
                // Failed
                XMessageBox.Show(Resources.MSG_EXPORT_FAIL, Resources.CAP_EXPORT, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetListGrd(out List<CPL3010U01GrdPaInfo> lstPa, out List<CPL3010U01GrdHangmogInfo> lstHangmog, out List<CPL3010U01IsFileWriteInfo> lstCplReq)
        {
            lstPa = new List<CPL3010U01GrdPaInfo>();
            lstHangmog = new List<CPL3010U01GrdHangmogInfo>();
            lstCplReq = new List<CPL3010U01IsFileWriteInfo>();

            for (int i = 0; i < grdPa.RowCount; i++)
            {
                // grdPa.SetFocusToItem(i, "bunho");
                if (grdPa.GetItemString(i, "send_yn") != "Y") continue;

                CPL3010U01GrdPaInfo item = new CPL3010U01GrdPaInfo();
                item.Age = grdPa.GetItemString(i, "age");
                item.AgeGubun = grdPa.GetItemString(i, "age_gubun");
                item.Birth = grdPa.GetItemString(i, "birth");
                item.BirthGubun = grdPa.GetItemString(i, "birth_gubun");
                item.Bunho = grdPa.GetItemString(i, "bunho");
                item.CenterCode = grdPa.GetItemString(i, "center_code");
                item.Comments = grdPa.GetItemString(i, "comment");
                item.Dialysis = grdPa.GetItemString(i, "dialysis");
                item.DoctorName = grdPa.GetItemString(i, "doctor_name");
                item.Emergency = grdPa.GetItemString(i, "emergency");
                item.EmptyString = "";// grdPa.GetItemString(i, "empty_string");
                item.GwaName = grdPa.GetItemString(i, "gwa_name");
                item.HangmogCnt = grdPa.GetItemString(i, "hangmog_cnt");
                item.Height = grdPa.GetItemString(i, "height");
                item.HoDongName = grdPa.GetItemString(i, "ho_dong_name");
                item.HospitalCode = grdPa.GetItemString(i, "hospital_code");
                item.InOutGubun = grdPa.GetItemString(i, "in_out_gubun");
                item.JinryoCard = grdPa.GetItemString(i, "jinryo_card");
                item.JubsuDate = grdPa.GetItemString(i, "jubsu_date");
                item.JubsuTime = grdPa.GetItemString(i, "jubsu_time");
                item.NString = "";// grdPa.GetItemString(i, "n_string");
                item.NyoDanui = grdPa.GetItemString(i, "nyo_danui");
                item.NyoRyang = grdPa.GetItemString(i, "nyo_ryang");
                item.PregnancyJusu = grdPa.GetItemString(i, "pregnancy_jusu");
                item.RecodeGubun = grdPa.GetItemString(i, "recode_gubun");
                //item.RequestKey = grdPa.GetItemString(i, "request_key");
                item.RequestKey = grdPa.GetItemString(i, "jubsu_date") + grdPa.GetItemString(i, "jubsu_time") + grdPa.GetItemString(i, "bunho");
                item.SendYn = grdPa.GetItemString(i, "send_yn");
                item.Sex = grdPa.GetItemString(i, "sex");
                item.SpecimenSer = grdPa.GetItemString(i, "specimen_ser");
                item.Suname2 = grdPa.GetItemString(i, "suname");
                item.Weight = grdPa.GetItemString(i, "weight");

                lstPa.Add(item);

                CPL3010U01GrdHangmogArgs args = new CPL3010U01GrdHangmogArgs();
                args.RequestKey = grdPa.GetItemString(i, "jubsu_date") + grdPa.GetItemString(i, "jubsu_time") + grdPa.GetItemString(i, "bunho");
                args.SpecimenSer = grdPa.GetItemString(i, "specimen_ser");
                args.UitakCode = cboMasterType.GetDataValue().Equals("04") ? cboMasterType.GetDataValue() : "01";
                CPL3010U01GrdHangmogResult res = CloudService.Instance.Submit<CPL3010U01GrdHangmogResult, CPL3010U01GrdHangmogArgs>(args);

                for (int k = 0; k < res.GrdHangmogLst.Count; k++)
                {
                    CPL3010U01GrdHangmogInfo hangmogItem = new CPL3010U01GrdHangmogInfo();
                    hangmogItem.CenterCode = res.GrdHangmogLst[k].CenterCode;
                    hangmogItem.RecodeGubun = res.GrdHangmogLst[k].RecodeGubun;
                    hangmogItem.RequestKey = res.GrdHangmogLst[k].RequestKey;
                    hangmogItem.SpecimenSer = res.GrdHangmogLst[k].SpecimenSer;
                    hangmogItem.SanCode = res.GrdHangmogLst[k].SanCode;
                    lstHangmog.Add(hangmogItem);
                }

                // https://sofiamedix.atlassian.net/browse/MED-16419
                #region [CPLREQ1の　データ作成＆更新]

                CPL3010U01IsFileWriteInfo cplFileWriteitem = new CPL3010U01IsFileWriteInfo();
                cplFileWriteitem.Bunho = this.grdPa.GetItemString(i, "bunho");
                cplFileWriteitem.HangmogCnt = res.GrdHangmogLst.Count.ToString();
                cplFileWriteitem.JubsuDate = this.grdPa.GetItemString(i, "jubsu_date");
                cplFileWriteitem.JubsuTime = this.grdPa.GetItemString(i, "jubsu_time");
                cplFileWriteitem.RequestKey = this.grdPa.GetItemString(i, "request_key");
                cplFileWriteitem.SendYn = this.grdPa.GetItemString(i, "send_yn");
                cplFileWriteitem.Urine = this.grdPa.GetItemString(i, "nyo_ryang");
                lstCplReq.Add(cplFileWriteitem);

                #endregion
            }
        }

        private List<object[]> GetCboCompany(BindVarCollection bvc)
        {
            List<object[]> lstObj = new List<object[]>();

            ComboResult res = CloudService.Instance.Submit<ComboResult, CPL3010U01GetCboCompanyArgs>(new CPL3010U01GetCboCompanyArgs());
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lstObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lstObj;
        }

        #endregion
    }
}