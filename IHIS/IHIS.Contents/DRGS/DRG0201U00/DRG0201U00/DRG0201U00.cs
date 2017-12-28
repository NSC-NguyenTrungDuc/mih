#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.DRGS.Properties;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG0201U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class DRG0201U00 : IHIS.Framework.XScreen
    {
        #region Auto generated code

        private IHIS.Framework.XPanel PnlLeft;
        private IHIS.Framework.XFlatRadioButton rbx1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGrid grdPaid;
        private IHIS.Framework.XPanel pnlLeftInTop;
        private IHIS.Framework.XFlatRadioButton rbx2;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
        private IHIS.Framework.XEditGridCell xEditGridCell45;
        private IHIS.Framework.XEditGridCell xEditGridCell46;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
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
        private IHIS.Framework.XEditGridCell xEditGridCell58;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XFlatRadioButton rbx3;
        private IHIS.Framework.XPanel pnlFillDown;
        private System.Windows.Forms.Panel pnlFillIn3;
        private IHIS.Framework.XTextBox txtOrderRemark;
        private System.Windows.Forms.Panel pnlFillIn2;
        private IHIS.Framework.XTextBox txtCautionName;
        private System.Windows.Forms.Panel pnlFillIn1;
        private IHIS.Framework.XTextBox txtBogyongName;
        private IHIS.Framework.XPanel pnlFillInTop;
        private IHIS.Framework.XTextBox txtDrgBunho;
        private IHIS.Framework.XPatientBox paid;
        private IHIS.Framework.XDatePicker dtpOrderDate;
        private IHIS.Framework.XMstGrid grdOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGrid grdOrderList;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell62;
        private IHIS.Framework.XEditGridCell xEditGridCell90;
        private IHIS.Framework.XEditGridCell xEditGridCell63;
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell97;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell102;
        private IHIS.Framework.XEditGridCell xEditGridCell103;
        private IHIS.Framework.XEditGridCell xEditGridCell104;
        private IHIS.Framework.XEditGridCell xEditGridCell105;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private IHIS.Framework.XDisplayBox dbxSuname2;
        private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XLabel xLabel26;
        private IHIS.Framework.XDisplayBox dbxAge;
        private IHIS.Framework.XDisplayBox dbxGwa;
        private IHIS.Framework.XDisplayBox dbxSex;
        private IHIS.Framework.XLabel xLabel29;
        private IHIS.Framework.XDisplayBox dbxDoctor;
        private IHIS.Framework.XLabel xLabel36;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell72;
        private IHIS.Framework.XEditGridCell xEditGridCell73;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XPatientBox paInfo;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XTextBox tbxBarCode;
        private IHIS.Framework.XCheckBox cbxBarCode;
        private IHIS.Framework.XGroupBox xGroupBox1;
        private IHIS.Framework.XFlatLabel xFlatLabel1;
        private XLabel xLabel1;
        private XLabel lbSuname;
        private XButton btnQuery;
        private XButton btnProcess;
        private XButton btnUpdateComment;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell107;
        private XDictComboBox cbxActor;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell108;
        private XCheckBox cbxAdmMediYN;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem42;
        private XButton btnPrintAdmMedi;
        private XEditGridCell xEditGridCell109;
        private XEditGridCell xEditGridCell110;
        private XEditGridCell xEditGridCell111;
        private XButton btnFindUser;
        private XDisplayBox dbxUserName;
        private XDisplayBox dbxUserId;
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0201U00));
            this.PnlLeft = new IHIS.Framework.XPanel();
            this.grdPaid = new IHIS.Framework.XEditGrid();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.pnlLeftInTop = new IHIS.Framework.XPanel();
            this.lbSuname = new IHIS.Framework.XLabel();
            this.cbxBarCode = new IHIS.Framework.XCheckBox();
            this.tbxBarCode = new IHIS.Framework.XTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbx3 = new IHIS.Framework.XFlatRadioButton();
            this.rbx1 = new IHIS.Framework.XFlatRadioButton();
            this.txtDrgBunho = new IHIS.Framework.XTextBox();
            this.rbx2 = new IHIS.Framework.XFlatRadioButton();
            this.paid = new IHIS.Framework.XPatientBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxAdmMediYN = new IHIS.Framework.XCheckBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpOrderDate = new IHIS.Framework.XDatePicker();
            this.xGroupBox1 = new IHIS.Framework.XGroupBox();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOrderList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.txtBogyongName = new IHIS.Framework.XTextBox();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.txtCautionName = new IHIS.Framework.XTextBox();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.txtOrderRemark = new IHIS.Framework.XTextBox();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.grdOrder = new IHIS.Framework.XMstGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.dbxDoctor = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.dbxGwa = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pnlFillDown = new IHIS.Framework.XPanel();
            this.pnlFillIn3 = new System.Windows.Forms.Panel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.pnlFillIn2 = new System.Windows.Forms.Panel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlFillIn1 = new System.Windows.Forms.Panel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnPrintAdmMedi = new IHIS.Framework.XButton();
            this.btnQuery = new IHIS.Framework.XButton();
            this.btnProcess = new IHIS.Framework.XButton();
            this.btnUpdateComment = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.pnlFillInTop = new IHIS.Framework.XPanel();
            this.btnFindUser = new IHIS.Framework.XButton();
            this.dbxUserName = new IHIS.Framework.XDisplayBox();
            this.dbxUserId = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.dbxSuname2 = new IHIS.Framework.XDisplayBox();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xLabel26 = new IHIS.Framework.XLabel();
            this.dbxAge = new IHIS.Framework.XDisplayBox();
            this.dbxSex = new IHIS.Framework.XDisplayBox();
            this.xLabel29 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.paInfo = new IHIS.Framework.XPatientBox();
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.PnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaid)).BeginInit();
            this.pnlLeftInTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.xGroupBox1.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.pnlFillDown.SuspendLayout();
            this.pnlFillIn3.SuspendLayout();
            this.pnlFillIn2.SuspendLayout();
            this.pnlFillIn1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.pnlFillInTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "save.gif");
            this.ImageList.Images.SetKeyName(1, "적용.gif");
            this.ImageList.Images.SetKeyName(2, "조회.gif");
            // 
            // PnlLeft
            // 
            this.PnlLeft.Controls.Add(this.grdPaid);
            this.PnlLeft.Controls.Add(this.pnlLeftInTop);
            resources.ApplyResources(this.PnlLeft, "PnlLeft");
            this.PnlLeft.DrawBorder = true;
            this.PnlLeft.Name = "PnlLeft";
            // 
            // grdPaid
            // 
            this.grdPaid.ApplyPaintEventToAllColumn = true;
            this.grdPaid.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell110,
            this.xEditGridCell25,
            this.xEditGridCell2,
            this.xEditGridCell26,
            this.xEditGridCell28,
            this.xEditGridCell22,
            this.xEditGridCell66,
            this.xEditGridCell75});
            this.grdPaid.ColPerLine = 6;
            this.grdPaid.ColResizable = true;
            this.grdPaid.Cols = 7;
            resources.ApplyResources(this.grdPaid, "grdPaid");
            this.grdPaid.ExecuteQuery = null;
            this.grdPaid.FixedCols = 1;
            this.grdPaid.FixedRows = 1;
            this.grdPaid.HeaderHeights.Add(42);
            this.grdPaid.Name = "grdPaid";
            this.grdPaid.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaid.ParamList")));
            this.grdPaid.QuerySQL = resources.GetString("grdPaid.QuerySQL");
            this.grdPaid.RowHeaderVisible = true;
            this.grdPaid.Rows = 2;
            this.grdPaid.ToolTipActive = true;
            this.grdPaid.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPaid_RowFocusChanged);
            this.grdPaid.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaid_GridCellPainting);
            this.grdPaid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdPaid_MouseUp);
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "trial";
            this.xEditGridCell110.Col = 1;
            this.xEditGridCell110.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsReadOnly = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "drg_bunho";
            this.xEditGridCell25.CellWidth = 61;
            this.xEditGridCell25.Col = 2;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 77;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_date";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "joje_yn";
            this.xEditGridCell28.CellWidth = 28;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "suname";
            this.xEditGridCell22.CellWidth = 74;
            this.xEditGridCell22.Col = 3;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "order_remark";
            this.xEditGridCell66.CellWidth = 42;
            this.xEditGridCell66.Col = 5;
            this.xEditGridCell66.DisplayMemoText = true;
            this.xEditGridCell66.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsReadOnly = true;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "drg_remark";
            this.xEditGridCell75.CellWidth = 36;
            this.xEditGridCell75.Col = 6;
            this.xEditGridCell75.DisplayMemoText = true;
            this.xEditGridCell75.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsReadOnly = true;
            // 
            // pnlLeftInTop
            // 
            this.pnlLeftInTop.Controls.Add(this.lbSuname);
            this.pnlLeftInTop.Controls.Add(this.cbxBarCode);
            this.pnlLeftInTop.Controls.Add(this.tbxBarCode);
            this.pnlLeftInTop.Controls.Add(this.groupBox2);
            this.pnlLeftInTop.Controls.Add(this.paid);
            this.pnlLeftInTop.Controls.Add(this.groupBox1);
            this.pnlLeftInTop.Controls.Add(this.xGroupBox1);
            resources.ApplyResources(this.pnlLeftInTop, "pnlLeftInTop");
            this.pnlLeftInTop.Name = "pnlLeftInTop";
            this.pnlLeftInTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlLeftInTop_MouseUp);
            // 
            // lbSuname
            // 
            this.lbSuname.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.lbSuname, "lbSuname");
            this.lbSuname.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.lbSuname.Name = "lbSuname";
            // 
            // cbxBarCode
            // 
            resources.ApplyResources(this.cbxBarCode, "cbxBarCode");
            this.cbxBarCode.Name = "cbxBarCode";
            this.cbxBarCode.UseVisualStyleBackColor = false;
            this.cbxBarCode.CheckedChanged += new System.EventHandler(this.cbxBarCode_CheckedChanged);
            // 
            // tbxBarCode
            // 
            resources.ApplyResources(this.tbxBarCode, "tbxBarCode");
            this.tbxBarCode.EnterKeyToTab = false;
            this.tbxBarCode.Name = "tbxBarCode";
            this.tbxBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxBarCode_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbx3);
            this.groupBox2.Controls.Add(this.rbx1);
            this.groupBox2.Controls.Add(this.txtDrgBunho);
            this.groupBox2.Controls.Add(this.rbx2);
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rbx3
            // 
            this.rbx3.CheckedValue = "3";
            resources.ApplyResources(this.rbx3, "rbx3");
            this.rbx3.Name = "rbx3";
            this.rbx3.UseVisualStyleBackColor = false;
            this.rbx3.Click += new System.EventHandler(this.rbx3_Click);
            // 
            // rbx1
            // 
            this.rbx1.Checked = true;
            this.rbx1.CheckedValue = "1";
            resources.ApplyResources(this.rbx1, "rbx1");
            this.rbx1.Name = "rbx1";
            this.rbx1.TabStop = true;
            this.rbx1.UseVisualStyleBackColor = false;
            this.rbx1.Click += new System.EventHandler(this.rbx1_Click);
            // 
            // txtDrgBunho
            // 
            resources.ApplyResources(this.txtDrgBunho, "txtDrgBunho");
            this.txtDrgBunho.Name = "txtDrgBunho";
            this.txtDrgBunho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrgBunho_KeyPress);
            // 
            // rbx2
            // 
            this.rbx2.CheckedValue = "2";
            resources.ApplyResources(this.rbx2, "rbx2");
            this.rbx2.Name = "rbx2";
            this.rbx2.UseVisualStyleBackColor = false;
            this.rbx2.Click += new System.EventHandler(this.rbx2_Click);
            // 
            // paid
            // 
            resources.ApplyResources(this.paid, "paid");
            this.paid.Name = "paid";
            this.paid.ShowBoxImage = false;
            this.paid.PatientSelected += new System.EventHandler(this.paid_PatientSelected);
            this.paid.PatientSelectionFailed += new System.EventHandler(this.paid_PatientSelectionFailed);
            this.paid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paid_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxAdmMediYN);
            this.groupBox1.Controls.Add(this.xLabel1);
            this.groupBox1.Controls.Add(this.dtpOrderDate);
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbxAdmMediYN
            // 
            this.cbxAdmMediYN.CheckedText = global::IHIS.DRGS.Properties.Resources.cbxAdmMediYN_ON;
            resources.ApplyResources(this.cbxAdmMediYN, "cbxAdmMediYN");
            this.cbxAdmMediYN.Name = "cbxAdmMediYN";
            this.cbxAdmMediYN.UnCheckedText = global::IHIS.DRGS.Properties.Resources.cbxAdmMediYN_OFF;
            this.cbxAdmMediYN.UseVisualStyleBackColor = false;
            // 
            // xLabel1
            // 
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // dtpOrderDate
            // 
            resources.ApplyResources(this.dtpOrderDate, "dtpOrderDate");
            this.dtpOrderDate.IsVietnameseYearType = false;
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpOrderDate_DataValidating);
            // 
            // xGroupBox1
            // 
            this.xGroupBox1.Controls.Add(this.xFlatLabel1);
            resources.ApplyResources(this.xGroupBox1, "xGroupBox1");
            this.xGroupBox1.Name = "xGroupBox1";
            this.xGroupBox1.Protect = true;
            this.xGroupBox1.TabStop = false;
            // 
            // xFlatLabel1
            // 
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.xPanel2);
            this.pnlFill.Controls.Add(this.xPanel1);
            this.pnlFill.Controls.Add(this.pnlFillDown);
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Name = "pnlFill";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdOrderList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdOrderList
            // 
            this.grdOrderList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell61,
            this.xEditGridCell17,
            this.xEditGridCell89,
            this.xEditGridCell62,
            this.xEditGridCell90,
            this.xEditGridCell63,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell60,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell38,
            this.xEditGridCell98,
            this.xEditGridCell37,
            this.xEditGridCell64,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell39,
            this.xEditGridCell65,
            this.xEditGridCell12,
            this.xEditGridCell14,
            this.xEditGridCell36,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell59,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82});
            this.grdOrderList.ColPerLine = 15;
            this.grdOrderList.ColResizable = true;
            this.grdOrderList.Cols = 16;
            this.grdOrderList.ControlBinding = true;
            resources.ApplyResources(this.grdOrderList, "grdOrderList");
            this.grdOrderList.ExecuteQuery = null;
            this.grdOrderList.FixedCols = 1;
            this.grdOrderList.FixedRows = 1;
            this.grdOrderList.HeaderHeights.Add(33);
            this.grdOrderList.MasterLayout = this.grdOrder;
            this.grdOrderList.Name = "grdOrderList";
            this.grdOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderList.ParamList")));
            this.grdOrderList.QuerySQL = resources.GetString("grdOrderList.QuerySQL");
            this.grdOrderList.RowHeaderVisible = true;
            this.grdOrderList.Rows = 2;
            this.grdOrderList.ToolTipActive = true;
            this.grdOrderList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrderList_GridCellPainting);
            this.grdOrderList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderList_QueryStarting);
            this.grdOrderList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdOrderList_MouseUp);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "bunho";
            this.xEditGridCell83.CellWidth = 25;
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "drg_bunho";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            this.xEditGridCell84.IsReadOnly = true;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "naewon_date";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.IsReadOnly = true;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "group_ser";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "jubsu_date";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.IsReadOnly = true;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "order_date";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.IsReadOnly = true;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.ApplyPaintingEvent = true;
            this.xEditGridCell61.CellName = "jaeryo_code";
            this.xEditGridCell61.CellWidth = 116;
            this.xEditGridCell61.Col = 2;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsReadOnly = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.CellName = "nalsu";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.CellWidth = 48;
            this.xEditGridCell17.Col = 7;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "divide";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.ApplyPaintingEvent = true;
            this.xEditGridCell62.CellName = "ord_suryang";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell62.CellWidth = 59;
            this.xEditGridCell62.Col = 4;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "order_suryang";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.IsReadOnly = true;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.ApplyPaintingEvent = true;
            this.xEditGridCell63.CellName = "order_danui";
            this.xEditGridCell63.CellWidth = 64;
            this.xEditGridCell63.Col = 8;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "subul_danui";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.IsReadOnly = true;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "group_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "jaeryo_gubun";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.ApplyPaintingEvent = true;
            this.xEditGridCell60.CellName = "bogyong_code";
            this.xEditGridCell60.CellWidth = 63;
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsReadOnly = true;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.BindControl = this.txtBogyongName;
            this.xEditGridCell94.CellName = "bogyong_name";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.ExecuteQuery = null;
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // txtBogyongName
            // 
            resources.ApplyResources(this.txtBogyongName, "txtBogyongName");
            this.txtBogyongName.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtBogyongName.Name = "txtBogyongName";
            this.txtBogyongName.Protect = true;
            this.txtBogyongName.ReadOnly = true;
            this.txtBogyongName.TabStop = false;
            this.txtBogyongName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtBogyongName_MouseUp);
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.BindControl = this.txtCautionName;
            this.xEditGridCell95.CellName = "caution_name";
            this.xEditGridCell95.CellWidth = 46;
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // txtCautionName
            // 
            resources.ApplyResources(this.txtCautionName, "txtCautionName");
            this.txtCautionName.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtCautionName.Name = "txtCautionName";
            this.txtCautionName.Protect = true;
            this.txtCautionName.ReadOnly = true;
            this.txtCautionName.TabStop = false;
            this.txtCautionName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtCautionName_MouseUp);
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "caution_code";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "mix_yn";
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.ApplyPaintingEvent = true;
            this.xEditGridCell38.CellLen = 35;
            this.xEditGridCell38.CellName = "atc_yn";
            this.xEditGridCell38.CellWidth = 35;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsReadOnly = true;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "remark";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.ApplyPaintingEvent = true;
            this.xEditGridCell37.CellName = "dv";
            this.xEditGridCell37.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell37.CellWidth = 42;
            this.xEditGridCell37.Col = 6;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.ApplyPaintingEvent = true;
            this.xEditGridCell64.CellName = "dv_time";
            this.xEditGridCell64.CellWidth = 33;
            this.xEditGridCell64.Col = 5;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsReadOnly = true;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "dc_yn";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "bannab_yn";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "source_fkocs1003";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "fkocs1003";
            this.xEditGridCell102.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.ExecuteQuery = null;
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "fkout1001";
            this.xEditGridCell103.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            this.xEditGridCell103.IsReadOnly = true;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "sunab_date";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            this.xEditGridCell104.IsReadOnly = true;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "pattern";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            this.xEditGridCell105.IsReadOnly = true;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.ApplyPaintingEvent = true;
            this.xEditGridCell39.CellName = "jaeryo_name";
            this.xEditGridCell39.CellWidth = 261;
            this.xEditGridCell39.Col = 3;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 35;
            this.xEditGridCell65.CellName = "sunab_nalsu";
            this.xEditGridCell65.CellWidth = 35;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            this.xEditGridCell65.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "wonyoi_yn";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.txtOrderRemark;
            this.xEditGridCell14.CellName = "ocs_remark";
            this.xEditGridCell14.CellWidth = 33;
            this.xEditGridCell14.Col = 13;
            this.xEditGridCell14.DisplayMemoText = true;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // txtOrderRemark
            // 
            resources.ApplyResources(this.txtOrderRemark, "txtOrderRemark");
            this.txtOrderRemark.ForeColor = IHIS.Framework.XColor.DisabledForeColor;
            this.txtOrderRemark.Name = "txtOrderRemark";
            this.txtOrderRemark.Protect = true;
            this.txtOrderRemark.ReadOnly = true;
            this.txtOrderRemark.TabStop = false;
            this.txtOrderRemark.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtOrderRemark_MouseUp);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "act_date";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "mayak";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.IsReadOnly = true;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "tpn_joje_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.IsReadOnly = true;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "ui_jusa_yn";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.IsReadOnly = true;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "subul_suryang";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.IsReadOnly = true;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.ApplyPaintingEvent = true;
            this.xEditGridCell59.CellName = "serial_v";
            this.xEditGridCell59.CellWidth = 35;
            this.xEditGridCell59.Col = 1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsReadOnly = true;
            this.xEditGridCell59.SuppressRepeating = true;
            this.xEditGridCell59.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "order_remark";
            this.xEditGridCell77.CellWidth = 48;
            this.xEditGridCell77.Col = 14;
            this.xEditGridCell77.DisplayMemoText = true;
            this.xEditGridCell77.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsReadOnly = true;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "drg_remark";
            this.xEditGridCell78.CellWidth = 50;
            this.xEditGridCell78.Col = 15;
            this.xEditGridCell78.DisplayMemoText = true;
            this.xEditGridCell78.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsReadOnly = true;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "hubal_change_yn";
            this.xEditGridCell79.CellWidth = 25;
            this.xEditGridCell79.Col = 12;
            this.xEditGridCell79.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.IsReadOnly = true;
            this.xEditGridCell79.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "pharmacy";
            this.xEditGridCell80.Col = 10;
            this.xEditGridCell80.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "drg_pack_yn";
            this.xEditGridCell81.CellWidth = 37;
            this.xEditGridCell81.Col = 11;
            this.xEditGridCell81.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "powder_yn";
            this.xEditGridCell82.CellWidth = 25;
            this.xEditGridCell82.Col = 9;
            this.xEditGridCell82.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdOrder
            // 
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell106,
            this.xEditGridCell6,
            this.xEditGridCell32,
            this.xEditGridCell5,
            this.xEditGridCell33,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell107,
            this.xEditGridCell21,
            this.xEditGridCell7,
            this.xEditGridCell34,
            this.xEditGridCell108,
            this.xEditGridCell1,
            this.xEditGridCell27,
            this.xEditGridCell69,
            this.xEditGridCell76,
            this.xEditGridCell109,
            this.xEditGridCell70,
            this.xEditGridCell111});
            this.grdOrder.ColPerLine = 13;
            this.grdOrder.ColResizable = true;
            this.grdOrder.Cols = 14;
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(32);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.Rows = 2;
            this.grdOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            this.grdOrder.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOrder_ItemValueChanging);
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_RowFocusChanged);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting_1);
            this.grdOrder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseUp);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.ApplyPaintingEvent = true;
            this.xEditGridCell3.CellName = "drg_bunho";
            this.xEditGridCell3.CellWidth = 63;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "bunho";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "order_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.CellWidth = 76;
            this.xEditGridCell30.Col = 5;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "jubsu_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.CellWidth = 73;
            this.xEditGridCell31.Col = 6;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "drg_jubsu_date";
            this.xEditGridCell106.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell106.CellWidth = 85;
            this.xEditGridCell106.Col = 7;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.ApplyPaintingEvent = true;
            this.xEditGridCell6.CellName = "jubsu_time";
            this.xEditGridCell6.CellWidth = 58;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.Mask = "##:##";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "doctor";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell5.ApplyPaintingEvent = true;
            this.xEditGridCell5.BindControl = this.dbxDoctor;
            this.xEditGridCell5.CellName = "doctor_name";
            this.xEditGridCell5.CellWidth = 103;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // dbxDoctor
            // 
            resources.ApplyResources(this.dbxDoctor, "dbxDoctor");
            this.dbxDoctor.Name = "dbxDoctor";
            this.dbxDoctor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbxDoctor_MouseUp);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "gwa";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.IsReadOnly = true;
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.BindControl = this.dbxGwa;
            this.xEditGridCell4.CellName = "buseo_name";
            this.xEditGridCell4.CellWidth = 83;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // dbxGwa
            // 
            resources.ApplyResources(this.dbxGwa, "dbxGwa");
            this.dbxGwa.Name = "dbxGwa";
            this.dbxGwa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbxGwa_MouseUp);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.CellName = "act_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 76;
            this.xEditGridCell8.Col = 9;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "act_time";
            this.xEditGridCell107.CellWidth = 128;
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.ApplyPaintingEvent = true;
            this.xEditGridCell21.CellName = "act_yn";
            this.xEditGridCell21.CellWidth = 65;
            this.xEditGridCell21.Col = 13;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.CellName = "sunab_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 68;
            this.xEditGridCell7.Col = 10;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "chulgo_date";
            this.xEditGridCell34.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "act_user_name";
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.ApplyPaintingEvent = true;
            this.xEditGridCell1.CellName = "wonyoi_yn";
            this.xEditGridCell1.CellWidth = 42;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "dis_gubun";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "order_remark";
            this.xEditGridCell69.CellWidth = 69;
            this.xEditGridCell69.Col = 11;
            this.xEditGridCell69.DisplayMemoText = true;
            this.xEditGridCell69.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            this.xEditGridCell69.IsUpdCol = false;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "drg_remark";
            this.xEditGridCell76.CellWidth = 78;
            this.xEditGridCell76.Col = 12;
            this.xEditGridCell76.DisplayMemoText = true;
            this.xEditGridCell76.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsReadOnly = true;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "fkout1001";
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.ExecuteQuery = null;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "chulgo_buseo";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "if_data_send_yn";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdOrder);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // pnlFillDown
            // 
            this.pnlFillDown.Controls.Add(this.pnlFillIn3);
            this.pnlFillDown.Controls.Add(this.pnlFillIn2);
            this.pnlFillDown.Controls.Add(this.pnlFillIn1);
            resources.ApplyResources(this.pnlFillDown, "pnlFillDown");
            this.pnlFillDown.Name = "pnlFillDown";
            // 
            // pnlFillIn3
            // 
            resources.ApplyResources(this.pnlFillIn3, "pnlFillIn3");
            this.pnlFillIn3.Controls.Add(this.txtOrderRemark);
            this.pnlFillIn3.Controls.Add(this.xLabel5);
            this.pnlFillIn3.Name = "pnlFillIn3";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xLabel5_MouseUp);
            // 
            // pnlFillIn2
            // 
            resources.ApplyResources(this.pnlFillIn2, "pnlFillIn2");
            this.pnlFillIn2.Controls.Add(this.txtCautionName);
            this.pnlFillIn2.Controls.Add(this.xLabel4);
            this.pnlFillIn2.Name = "pnlFillIn2";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xLabel4_MouseUp);
            // 
            // pnlFillIn1
            // 
            resources.ApplyResources(this.pnlFillIn1, "pnlFillIn1");
            this.pnlFillIn1.Controls.Add(this.txtBogyongName);
            this.pnlFillIn1.Controls.Add(this.xLabel3);
            this.pnlFillIn1.Name = "pnlFillIn1";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xLabel3_MouseUp);
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.CellName = "order_remark";
            this.xEditGridCell71.CellWidth = 60;
            this.xEditGridCell71.Col = 12;
            this.xEditGridCell71.DisplayMemoText = true;
            this.xEditGridCell71.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsReadOnly = true;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "jaeryo_comments";
            this.xEditGridCell72.CellWidth = 60;
            this.xEditGridCell72.Col = 13;
            this.xEditGridCell72.DisplayMemoText = true;
            this.xEditGridCell72.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsReadOnly = true;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "bohum";
            this.xEditGridCell73.CellWidth = 35;
            this.xEditGridCell73.Col = 9;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsReadOnly = true;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "huntak";
            this.xEditGridCell74.CellWidth = 35;
            this.xEditGridCell74.Col = 10;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "serial_v";
            this.xEditGridCell10.CellWidth = 35;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bogyong_code";
            this.xEditGridCell11.CellWidth = 64;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 35;
            this.xEditGridCell13.CellName = "atc_yn";
            this.xEditGridCell13.CellWidth = 38;
            this.xEditGridCell13.Col = 4;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "dv_time";
            this.xEditGridCell15.CellWidth = 30;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.Row = 1;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "dv";
            this.xEditGridCell16.CellWidth = 30;
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.Row = 1;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellLen = 35;
            this.xEditGridCell18.CellName = "sunab_nalsu";
            this.xEditGridCell18.CellWidth = 39;
            this.xEditGridCell18.Col = 12;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 35;
            this.xEditGridCell19.CellName = "atc_yn";
            this.xEditGridCell19.CellWidth = 30;
            this.xEditGridCell19.Col = 11;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "powder_yn";
            this.xEditGridCell24.CellWidth = 30;
            this.xEditGridCell24.Col = 10;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "jaeryo_name";
            this.xEditGridCell20.CellWidth = 222;
            this.xEditGridCell20.Col = 3;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.RowSpan = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPrintAdmMedi);
            this.pnlBottom.Controls.Add(this.btnQuery);
            this.pnlBottom.Controls.Add(this.btnProcess);
            this.pnlBottom.Controls.Add(this.btnUpdateComment);
            this.pnlBottom.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlBottom_MouseUp);
            // 
            // btnPrintAdmMedi
            // 
            this.btnPrintAdmMedi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnPrintAdmMedi, "btnPrintAdmMedi");
            this.btnPrintAdmMedi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintAdmMedi.Name = "btnPrintAdmMedi";
            this.btnPrintAdmMedi.Click += new System.EventHandler(this.btnPrintAdmMedi_Click);
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.ImageIndex = 2;
            this.btnQuery.ImageList = this.ImageList;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.ImageIndex = 1;
            this.btnProcess.ImageList = this.ImageList;
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnUpdateComment
            // 
            this.btnUpdateComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            resources.ApplyResources(this.btnUpdateComment, "btnUpdateComment");
            this.btnUpdateComment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdateComment.ImageIndex = 0;
            this.btnUpdateComment.ImageList = this.ImageList;
            this.btnUpdateComment.Name = "btnUpdateComment";
            this.btnUpdateComment.Click += new System.EventHandler(this.btnUpdateComment_Click);
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.DRGS.Properties.Resources.DRG0201U00_InitializeComponent_btnClose, -1, "")});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "wonyoi_yn";
            this.xEditGridCell9.CellWidth = 44;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "order_danui";
            this.xEditGridCell23.Col = 11;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.Row = 1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "bunho";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "order_suryang";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "subul_danui";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "group_yn";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jaeryo_gubun";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "bogyong_name";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "caution_name";
            this.xEditGridCell47.Col = 10;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.Row = 1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "caution_code";
            this.xEditGridCell48.Col = 11;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.Row = 1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "mix_yn";
            this.xEditGridCell49.Col = 13;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.Row = 1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "atc_yn";
            this.xEditGridCell50.Col = 14;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.Row = 1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "remark";
            this.xEditGridCell51.Col = 15;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.Row = 1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "dc_yn";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "bannab_yn";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "source_fkocs1003";
            this.xEditGridCell54.Col = 16;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.Row = 1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "fkocs1003";
            this.xEditGridCell55.Col = 17;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.Row = 1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "fkout1001";
            this.xEditGridCell56.Col = 18;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.Row = 1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "sunab_date";
            this.xEditGridCell57.Col = 19;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.Row = 1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "pattern";
            this.xEditGridCell58.Col = 20;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.Row = 1;
            // 
            // pnlFillInTop
            // 
            this.pnlFillInTop.Controls.Add(this.btnFindUser);
            this.pnlFillInTop.Controls.Add(this.dbxUserName);
            this.pnlFillInTop.Controls.Add(this.dbxUserId);
            this.pnlFillInTop.Controls.Add(this.dbxDoctor);
            this.pnlFillInTop.Controls.Add(this.xLabel2);
            this.pnlFillInTop.Controls.Add(this.cbxActor);
            this.pnlFillInTop.Controls.Add(this.dbxSuname2);
            this.pnlFillInTop.Controls.Add(this.dbxSuname);
            this.pnlFillInTop.Controls.Add(this.xLabel26);
            this.pnlFillInTop.Controls.Add(this.dbxAge);
            this.pnlFillInTop.Controls.Add(this.dbxGwa);
            this.pnlFillInTop.Controls.Add(this.dbxSex);
            this.pnlFillInTop.Controls.Add(this.xLabel29);
            this.pnlFillInTop.Controls.Add(this.xLabel36);
            this.pnlFillInTop.Controls.Add(this.paInfo);
            resources.ApplyResources(this.pnlFillInTop, "pnlFillInTop");
            this.pnlFillInTop.DrawBorder = true;
            this.pnlFillInTop.Name = "pnlFillInTop";
            this.pnlFillInTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlFillInTop_MouseUp);
            // 
            // btnFindUser
            // 
            resources.ApplyResources(this.btnFindUser, "btnFindUser");
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // dbxUserName
            // 
            resources.ApplyResources(this.dbxUserName, "dbxUserName");
            this.dbxUserName.Name = "dbxUserName";
            // 
            // dbxUserId
            // 
            resources.ApplyResources(this.dbxUserId, "dbxUserId");
            this.dbxUserId.Name = "dbxUserId";
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // cbxActor
            // 
            this.cbxActor.ExecuteQuery = null;
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // dbxSuname2
            // 
            resources.ApplyResources(this.dbxSuname2, "dbxSuname2");
            this.dbxSuname2.Name = "dbxSuname2";
            this.dbxSuname2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbxSuname2_MouseUp);
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            this.dbxSuname.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbxSuname_MouseUp);
            // 
            // xLabel26
            // 
            this.xLabel26.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel26, "xLabel26");
            this.xLabel26.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel26.Name = "xLabel26";
            this.xLabel26.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xLabel26_MouseUp);
            // 
            // dbxAge
            // 
            resources.ApplyResources(this.dbxAge, "dbxAge");
            this.dbxAge.Name = "dbxAge";
            this.dbxAge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbxAge_MouseUp);
            // 
            // dbxSex
            // 
            resources.ApplyResources(this.dbxSex, "dbxSex");
            this.dbxSex.Name = "dbxSex";
            this.dbxSex.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbxSex_MouseUp);
            // 
            // xLabel29
            // 
            this.xLabel29.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel29, "xLabel29");
            this.xLabel29.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel29.Name = "xLabel29";
            this.xLabel29.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xLabel29_MouseUp);
            // 
            // xLabel36
            // 
            this.xLabel36.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.ForeColor = IHIS.Framework.XColor.XPanelBorderColor;
            this.xLabel36.Name = "xLabel36";
            this.xLabel36.MouseUp += new System.Windows.Forms.MouseEventHandler(this.xLabel36_MouseUp);
            // 
            // paInfo
            // 
            resources.ApplyResources(this.paInfo, "paInfo");
            this.paInfo.Name = "paInfo";
            this.paInfo.PatientSelected += new System.EventHandler(this.paInfo_PatientSelected);
            this.paInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paInfo_MouseUp);
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem4,
            this.multiLayoutItem15,
            this.multiLayoutItem42});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "code_name";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "code_value";
            // 
            // DRG0201U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlFillInTop);
            this.Controls.Add(this.PnlLeft);
            this.Controls.Add(this.pnlBottom);
            resources.ApplyResources(this, "$this");
            this.Name = "DRG0201U00";
            this.Activated += new System.EventHandler(this.DRG0201U00_Activated);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DRG0201U00_MouseUp);
            this.PnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaid)).EndInit();
            this.pnlLeftInTop.ResumeLayout(false);
            this.pnlLeftInTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.xGroupBox1.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.pnlFillDown.ResumeLayout(false);
            this.pnlFillIn3.ResumeLayout(false);
            this.pnlFillIn3.PerformLayout();
            this.pnlFillIn2.ResumeLayout(false);
            this.pnlFillIn2.PerformLayout();
            this.pnlFillIn1.ResumeLayout(false);
            this.pnlFillIn1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.pnlFillInTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region Properties and fields
        /// <summary>
        /// variable declare
        /// </summary>
        /// 
        private string mActYn = "";

        // 服薬指導せんのグロバール変数
        private string i_jubsu_date = null;
        private string i_drg_bunho = null;
        private string i_bunho = null;
        private string i_fkout1001 = null;
        private bool mIsPatient = false;
        private string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region Constructor
        /// <summary>
        /// DRG0201U00
        /// </summary>
        public DRG0201U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //MED-12656
            if (NetInfo.Language == LangMode.Jr)
            {
                this.dtpOrderDate.IsJapanYearType = true;
                this.dtpOrderDate.IsJapanYearType = true;
            }

            // Cloud updated
            InitItemsControl();

            //Disable items due to task MED-3959
            cbxAdmMediYN.Enabled = false;
            btnPrintAdmMedi.Enabled = false;
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 135);

            //https://sofiamedix.atlassian.net/browse/MED-15055
            //set size for column
            if (NetInfo.Language == LangMode.Jr)
            {
                SetSizeForColumn();
            }
            

        }

        private void SetSizeForColumn()
        {
            grdPaid.AutoSizeColumn(xEditGridCell25.Col, 35);
            grdPaid.AutoSizeColumn(xEditGridCell22.Col, 75);
            grdPaid.AutoSizeColumn(xEditGridCell2.Col, 80);
            grdPaid.AutoSizeColumn(xEditGridCell66.Col, 27);
            grdPaid.AutoSizeColumn(xEditGridCell75.Col, 27);

            grdOrder.AutoSizeColumn(xEditGridCell1.Col, 34);
            grdOrder.AutoSizeColumn(xEditGridCell3.Col, 39);
            grdOrder.AutoSizeColumn(xEditGridCell4.Col, 83);
            grdOrder.AutoSizeColumn(xEditGridCell5.Col, 103);
            grdOrder.AutoSizeColumn(xEditGridCell30.Col, 85);
            grdOrder.AutoSizeColumn(xEditGridCell31.Col, 85);
            grdOrder.AutoSizeColumn(xEditGridCell106.Col, 85);
            grdOrder.AutoSizeColumn(xEditGridCell6.Col, 40);
            grdOrder.AutoSizeColumn(xEditGridCell8.Col, 85);
            grdOrder.AutoSizeColumn(xEditGridCell7.Col, 85);
            grdOrder.AutoSizeColumn(xEditGridCell69.Col, 50);
            grdOrder.AutoSizeColumn(xEditGridCell76.Col, 50);
            grdOrder.AutoSizeColumn(xEditGridCell21.Col, 33);

            grdOrderList.AutoSizeColumn(xEditGridCell59.Col, 35);
            grdOrderList.AutoSizeColumn(xEditGridCell61.Col, 116);
            grdOrderList.AutoSizeColumn(xEditGridCell39.Col, 292);
            grdOrderList.AutoSizeColumn(xEditGridCell62.Col, 50);
            grdOrderList.AutoSizeColumn(xEditGridCell64.Col, 31);
            grdOrderList.AutoSizeColumn(xEditGridCell37.Col, 35);
            grdOrderList.AutoSizeColumn(xEditGridCell17.Col, 35);
            grdOrderList.AutoSizeColumn(xEditGridCell63.Col, 64);
            grdOrderList.AutoSizeColumn(xEditGridCell82.Col, 27);
            grdOrderList.AutoSizeColumn(xEditGridCell80.Col, 30);
            grdOrderList.AutoSizeColumn(xEditGridCell81.Col, 25);
            grdOrderList.AutoSizeColumn(xEditGridCell79.Col, 25);
            grdOrderList.AutoSizeColumn(xEditGridCell14.Col, 33);
            grdOrderList.AutoSizeColumn(xEditGridCell77.Col, 29);
            grdOrderList.AutoSizeColumn(xEditGridCell78.Col, 31);

        }
        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dtpOrderDate.SetDataValue(EnvironInfo.GetSysDate());

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void btnBohoum_Click(object sender, System.EventArgs e)
        {
            if (grdPaid.RowCount > 0)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", grdPaid.GetItemString(grdPaid.CurrentRowNumber, "bunho"));
                openParams.Add("query_date", grdPaid.GetItemString(grdPaid.CurrentRowNumber, "order_date"));
                XScreen.OpenScreenWithParam(this, "OUTS", "OUT0102Q00", ScreenOpenStyle.PopUpFixed, openParams);
            }
            else
            {
                XMessageBox.Show(Resources.XMessageBox_msg, Resources.MSGCAPTION);
            }

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void paInfo_PatientSelected(object sender, System.EventArgs e)
        {
            this.dbxSuname.Text = paInfo.SuName;
            this.dbxSuname2.Text = paInfo.SuName2;
            this.dbxAge.Text = paInfo.YearAge.ToString();
            this.dbxSex.Text = paInfo.Sex;
        }

        private void grdOrder_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            this.dbxDoctor.Text = grdOrder.GetItemString(e.CurrentRow, "doctor_name");
            this.dbxGwa.Text = grdOrder.GetItemString(e.CurrentRow, "buseo_name");

            string jubsuja = this.grdOrder.GetItemString(e.CurrentRow, "act_user_name");
            if (jubsuja.Equals(""))
                // 実施者に 現在ログインしている IDを セットする｡
                this.cbxActor.SetDataValue(UserInfo.UserID);
            else
                // 実施者をセットする。
                this.cbxActor.Text = this.grdOrder.GetItemString(e.CurrentRow, "act_user_name");

            // 実施済TABのみ
            if (this.rbx2.Checked)
            {
                // 服薬指導せんのグロバール変数セット
                this.i_jubsu_date = this.grdOrder.GetItemString(e.CurrentRow, "jubsu_date");
                this.i_drg_bunho = this.grdOrder.GetItemString(e.CurrentRow, "drg_bunho");
                this.i_bunho = this.grdOrder.GetItemString(e.CurrentRow, "bunho");
                this.i_fkout1001 = this.grdOrder.GetItemString(e.CurrentRow, "fkout1001");
            }
        }

        private void cbxBarCode_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
            {
                this.grdPaid.Reset();
                this.tbxBarCode.Enabled = true;
                this.tbxBarCode.Focus();
            }
            else
            {
                this.tbxBarCode.Enabled = false;
                if (!grdPaid.QueryLayout(false))
                {
                    //XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
            }
        }

        private void tbxBarCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (this.tbxBarCode.GetDataValue().ToString() == "") return;

            string ls_bar_code = "";
            string ls_drg_bunho = "";
            string ls_order_date = "";

            this.grdPaid.Reset();
            this.grdOrder.Reset();

            if (e.KeyChar == (char)13)
            {
                ls_bar_code = this.tbxBarCode.GetDataValue().ToString();

                ls_order_date = ls_bar_code.Substring(0, 8);
                ls_drg_bunho = ls_bar_code.Substring(8, 4);

                #region deleted by Cloud
                // 투약확인 유무 체크
                //mActYn = ActChk(ls_order_date, ls_drg_bunho); @See GetGrdOrderForTbxBarCodeKeyPress

                //                grdOrder.QuerySQL = @"SELECT A.DRG_BUNHO                                 DRG_BUNHO
                //                                           , MAX(A.BUNHO)                                BUNHO
                //                                           , MAX(A.ORDER_DATE)                           ORDER_DATE
                //                                           , MAX(A.JUBSU_DATE)                           JUBSU_DATE
                //                                           , MAX(TRUNC(A.JUBSU_ILSI))                    DRG_JUBSU_DATE
                //                                           , MAX(A.JUBSU_TIME)                           JUBSU_TIME
                //                                           , MAX(A.DOCTOR)                               DOCTOR
                //                                           , MAX(C.DOCTOR_NAME)                          DOCTOR_NAME
                //                                           , MAX(A.GWA)                                  GWA
                //                                           , MAX(B.BUSEO_NAME)                           BUSEO_NAME
                //                                           , MAX(A.ACT_DATE)                             ACT_DATE
                //                                           , MAX(A.ACT_ILSI)                             ACT_TIME
                //                                           , MAX(DECODE(NVL(A.ACT_GWA,'N'),'N','N','Y')) ACT_YN
                //                                           , MAX(D.IF_DATA_SEND_DATE)                    SUNAB_DATE
                //                                           , MAX(A.CHULGO_DATE)                          CHULGO_DATE
                //                                           --, FN_ADM_LOAD_USER_NM(A.ACT_USER, A.JUBSU_DATE) ACT_USER_NAME
                //                                           , NVL(A.WONYOI_ORDER_YN, 'N')                 WONYOI_ORDER_YN
                //                                           , MAX(A.DIS_GUBUN )                           DIS_GUBUN
                //                                           , MAX(E.ORDER_REMARK)                         ORDER_REMARK
                //                                           , MAX(E.DRG_REMARK)                           DRG_REMARK
                //                                        FROM DRG9040     E
                //                                           , OCS1003     D
                //                                           , BAS0270     C
                //                                           , VW_GWA_NAME B
                //                                           , DRG2010     A
                //                                       WHERE A.ORDER_DATE               = TO_DATE(:f_orer_date,'YYYY/MM/DD')
                //                                         AND A.DRG_BUNHO                = TO_NUMBER(:f_drg_bunho)
                //                                         AND A.HOSP_CODE                = :f_hosp_code
                //                                         AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
                //                                         AND A.SOURCE_FKOCS1003         IS NULL
                //                                         AND NVL(A.DC_YN,'N')           <> 'Y'
                //                                         AND A.JUNDAL_PART              = 'PA'
                //                                         AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
                //                                         AND B.BUSEO_CODE               = A.GWA
                //                                         AND C.DOCTOR                (+)= A.DOCTOR
                //                                         AND A.FKOCS1003                = D.PKOCS1003
                //                                         AND A.SOURCE_FKOCS1003         IS NULL
                //                                         AND E.JUBSU_DATE            (+)= A.JUBSU_DATE
                //                                         AND E.DRG_BUNHO             (+)= A.DRG_BUNHO
                //                                         AND E.HOSP_CODE             (+)= A.HOSP_CODE
                //                                         AND D.HOSP_CODE                = A.HOSP_CODE
                //                                         AND C.HOSP_CODE             (+)= A.HOSP_CODE
                //                                         AND B.HOSP_CODE                = A.HOSP_CODE
                //                                       GROUP BY A.BUNHO, A.DRG_BUNHO, NVL(A.WONYOI_ORDER_YN, 'N')
                //                                       ORDER BY 1";

                //                grdOrder.SetBindVarValue("f_orer_date", ls_order_date.Replace("-", "").Replace("/", "").Substring(0, 8));
                //                grdOrder.SetBindVarValue("f_drg_bunho", ls_drg_bunho);
                //                grdOrder.SetBindVarValue("f_hosp_code", mHospCode);
                #endregion

                // Cloud updated code START
                grdOrder.ParamList = new List<string>(new string[] { "f_orer_date", "f_drg_bunho" });
                grdOrder.SetBindVarValue("f_orer_date", ls_order_date.Replace("-", "").Replace("/", "").Substring(0, 8));
                grdOrder.SetBindVarValue("f_drg_bunho", ls_drg_bunho);
                grdOrder.ExecuteQuery = GetGrdOrderForTbxBarCodeKeyPress;
                // Cloud updated code END

                if (!grdOrder.QueryLayout(false))
                {
                    //XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
                else
                {
                    //////////////////////////////////////////////////////////////////////////////
                    /* dsvBarOrder_ServiceEnd (바코드 리딩 후 데이터를 읽어 와서 환자번호 설정) */
                    //////////////////////////////////////////////////////////////////////////////

                    if (this.grdOrder.RowCount > 0)
                        paInfo.SetPatientID(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));

                    if (mActYn == "Y")       // acting
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.msg_Y_Ko : Resources.msgY);
                        XMessageBox.Show(msg);
                    }
                    else if (mActYn == "1")   // 미접수
                    {
                        string msg = (NetInfo.Language == LangMode.Ko ? Resources.msg_N_Ko : Resources.msg_N);
                        XMessageBox.Show(msg);
                    }
                    else
                    {
                        // 투약확인 처리
                        for (int i = 0; i <= this.grdOrder.RowCount; i++)
                        {
                            this.grdOrder.SetItemValue(i, "act_yn", "Y");
                        }

                        // 투약확인 저장
                        if (!LockChk()) return;
                        DRG2010Save();
                    }
                    mActYn = "";
                    this.tbxBarCode.ResetData();
                    this.tbxBarCode.Focus();
                }
            }
        }

        private void DRG0201U00_Activated(object sender, System.EventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();

            // 実施者に 現在ログインしている IDを セットする｡
            this.cbxActor.SetDataValue(UserInfo.UserID);
        }

        private void DRG0201U00_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void pnlLeftInTop_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void grdPaid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void grdOrder_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void grdOrderList_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void pnlFillInTop_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void txtBogyongName_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void txtCautionName_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void txtOrderRemark_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xLabel3_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xLabel4_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xLabel5_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void pnlBottom_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xPanel3_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xLabel26_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void dbxSuname_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void dbxSuname2_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void dbxSex_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void dbxAge_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void paInfo_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xLabel36_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void dbxGwa_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xLabel29_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void dbxDoctor_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void paid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void grdOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOrderList.SetBindVarValue("f_jubsu_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            grdOrderList.SetBindVarValue("f_drg_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));
            grdOrderList.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            switch (e.ColName)
            {
                case "act_yn":

                    if (this.rbx3.Checked)
                    {
                        e.Protect = true;
                        return;
                    }
                    e.Protect = false;
                    break;

                default:
                    break;
            }

            // 投与の場合、非活性化する（投与日、投与時間）
            if (this.rbx2.Checked && e.ColName == "act_date") e.Protect = true;

            // if (this.rbx2.Checked && e.ColName == "act_time") e.Protect = true;
        }

        private void grdOrder_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            if (e.ColName == "act_yn")
            {
                if (e.DataRow["dis_gubun"].ToString() != "1")
                {

                    if (e.ChangeValue.ToString() == "Y")
                    {
                        // 미접수 유무 체크
                        // 투약확인 유무 체크
                        if (ActChk(e.DataRow["order_date"].ToString(), e.DataRow["drg_bunho"].ToString()) == "1")
                        {
                            grdOrder.SetItemValue(e.RowNumber, "act_yn", "N");
                            string msg = (NetInfo.Language == LangMode.Ko ? "접수되지 않는 오더가 있습니다. 접수를 확인해주세요." : Resources.msg_N);
                            XMessageBox.Show(msg);
                            return;
                        }

                        #region 투약 전 회계 여부 확인 무효화

                        /*
                        if (TypeCheck.IsNull(e.DataRow["sunab_date"]))
                        {
                            if (MessageBox.Show("会計処理されませんでした。 投薬しますか?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                grdOrder.SetItemValue(e.RowNumber, "chulgo_buseo", IHIS.Framework.UserInfo.BuseoCode);
                                grdOrder.SetItemValue(e.RowNumber, "act_date", IHIS.Framework.EnvironInfo.GetSysDate());
                            }
                            else
                            {
                                grdOrder.SetItemValue(e.RowNumber, "act_yn", "N");
                                grdOrder.AcceptData();
                                grdOrder.DisplayData();
                                return;
                            }
                        }
                        else
                        {
                            grdOrder.SetItemValue(e.RowNumber, "chulgo_buseo", IHIS.Framework.UserInfo.BuseoCode);
                            grdOrder.SetItemValue(e.RowNumber, "act_date", IHIS.Framework.EnvironInfo.GetSysDate());
                        }*/
                        #endregion

                        this.grdOrder.SetItemValue(e.RowNumber, "chulgo_buseo", IHIS.Framework.UserInfo.BuseoCode);


                        if (this.rbx1.Checked) //未投与画面のみ設定
                        {
                            this.grdOrder.SetItemValue(e.RowNumber, "act_date", IHIS.Framework.EnvironInfo.GetSysDate());
                            //this.grdOrder.SetItemValue(e.RowNumber, "act_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                            //this.grdOrder.SetItemValue(e.RowNumber, "act_time", IHIS.Framework.EnvironInfo.GetSysDateTime());
                        }

                        this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());
                    }
                    else
                    {
                        if (this.rbx1.Checked) //未投与画面のみ設定
                        {
                            this.grdOrder.SetItemValue(e.RowNumber, "act_date", "");
                            //this.grdOrder.SetItemValue(e.RowNumber, "act_time", "");
                        }

                        this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());
                    }
                }
            }
        }

        private void txtDrgBunho_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            string bunho = string.Empty;
            string dt = this.dtpOrderDate.GetDataValue();
            bunho = paid.BunHo;

            string cmdText = string.Empty;
            object retVal = null;

            if (TypeCheck.IsNull(bunho))
            {
                //cmdText = "select distinct bunho from drg2010 WHERE drg_bunho = " + e.DataValue.ToString() + " AND jubsu_date = TO_DATE(\'" + dt + "\' , \'YYYY/MM/DD\') AND HOSP_CODE = \'" + mHospCode + "\'";
                DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs args = new DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs();
                args.Bunho = e.DataValue.ToString();
                args.JubsuDate = dt;
                DRG0201U00TxtDrgBunhoDataValidatingKeyPressResult res = CloudService.Instance.Submit<DRG0201U00TxtDrgBunhoDataValidatingKeyPressResult,
                    DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    retVal = res.Result;
                }

                //retVal = Service.ExecuteScalar(cmdText);
                if (!TypeCheck.IsNull(retVal))
                {
                    bunho = retVal.ToString();
                }
                if (Service.ErrCode != 1403 && Service.ErrMsg == "")
                {
                    bunho = bunho.Substring(0, bunho.IndexOf('\n', 0) - 1);
                }
                if (bunho != "")
                {
                    paid.SetPatientID(bunho);
                    return;
                }
                else
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? "환자번호가 없습니다" : "患者番号がありません");
                    XMessageBox.Show(msg);
                    return;
                }

            }
            DetailServerCall(dt, bunho, e.DataValue);
        }

        private void txtDrgBunho_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;

            string drg_bunho = txtDrgBunho.Text;
            string bunho = string.Empty;
            string dt = this.dtpOrderDate.GetDataValue();

            string cmdText = string.Empty;
            object retVal = null;

            if (TypeCheck.IsNull(bunho))
            {
                //cmdText = "select distinct bunho from drg2010 WHERE drg_bunho = " + drg_bunho + " AND jubsu_date = TO_DATE(\'" + dt + "\' , \'YYYY/MM/DD\') AND HOSP_CODE = \'" + mHospCode + "\'";
                DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs args = new DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs();
                args.Bunho = drg_bunho;
                args.JubsuDate = dt;
                DRG0201U00TxtDrgBunhoDataValidatingKeyPressResult res = CloudService.Instance.Submit<DRG0201U00TxtDrgBunhoDataValidatingKeyPressResult,
                    DRG0201U00TxtDrgBunhoDataValidatingKeyPressArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    retVal = res.Result;
                }

                //retVal = Service.ExecuteScalar(cmdText);
                if (!TypeCheck.IsNull(retVal))
                {
                    bunho = retVal.ToString();
                }
                if (bunho.IndexOf('\n', 0) >= 1)
                {
                    bunho = bunho.Substring(0, bunho.IndexOf('\n', 0) - 1);
                }
                if (bunho != "")
                {
                    paid.SetPatientID(bunho);
                    return;
                }
                else
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? "환자번호가 없습니다" : Resources.txtDrgBunho_msg_jp);
                    XMessageBox.Show(msg);
                    return;
                }

            }
            DetailServerCall(dt, bunho, drg_bunho);

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void grdOrderList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["dc_yn"].ToString() == "Y")
            {
                switch (e.ColName)
                {
                    case "serial_v":
                    case "jaeryo_code":
                    case "jaeryo_name":
                    case "ord_suryang":
                    case "dv_time":
                    case "dv":
                    case "bogyong_code":
                    case "nalsu":
                    case "order_danui":
                    case "powder_yn":
                    case "atc_yn":
                        e.DrawMiddleLine = true;
                        e.MiddleLineColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }

        }

        private void btnCommentForm_Click(object sender, System.EventArgs e)
        {
            if (!LockChk()) return;

            if (paInfo.BunHo == "")
            {
                MessageBox.Show(Resources.messageBox);
            }

            if (grdPaid.RowCount > 0)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("in_out_gubun", "O");
                openParams.Add("from_date", dtpOrderDate.GetDataValue());
                openParams.Add("to_date", dtpOrderDate.GetDataValue());
                openParams.Add("bunho", paInfo.BunHo);

                XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U00", ScreenOpenStyle.PopUpFixed, openParams);
            }
            else
            {
                XMessageBox.Show(Resources.XMessageBox_msg, Resources.MSGCAPTION);
            }

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    //MasterServerCall();
                    //if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                    //    this.tbxBarCode.Focus();
                    break;
                case FunctionType.Process://저장로직
                    e.IsBaseCall = false;
                    //if (!LockChk()) return;

                    //DRG2010Save();

                    //if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                    //    this.tbxBarCode.Focus();
                    break;
                case FunctionType.Update://코멘트 등록 팝업
                    //if (!LockChk()) return;

                    //if (paInfo.BunHo == "")
                    //{
                    //    MessageBox.Show("患者番号を入力してください。");
                    //}

                    //if (grdPaid.RowCount > 0)
                    //{
                    //    CommonItemCollection openParams = new CommonItemCollection();
                    //    openParams.Add("in_out_gubun", "O");
                    //    openParams.Add("from_date", dtpOrderDate.GetDataValue());
                    //    openParams.Add("to_date", dtpOrderDate.GetDataValue());
                    //    openParams.Add("bunho", paInfo.BunHo);

                    //    XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U01", ScreenOpenStyle.PopUpFixed, openParams);
                    //}
                    //else
                    //{
                    //    XMessageBox.Show("患者が選択されていないです。ご確認下さい。", "Error");
                    //}

                    //if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                    //    this.tbxBarCode.Focus();

                    // updated by Cloud
                    e.IsBaseCall = false;
                    if (this.rbx2.Checked)
                    {
                        foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                        {
                            // 会計未処理のみ
                            if (dtRow["if_data_send_yn"].ToString() == "Y")
                            {
                                XMessageBox.Show(Resources.XMessageBox2, "", MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    DRG2010Save();
                    break;
            }
        }

        private void grdPaid_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (!TypeCheck.IsNull(paid.BunHo)) paid.Reset();
            mIsPatient = true;
            paInfo.SetPatientID(grdPaid.GetItemString(e.CurrentRow, "bunho"));

            DetailServerCall(grdPaid.GetItemString(e.CurrentRow, "order_date"),
                             grdPaid.GetItemString(e.CurrentRow, "bunho"),
                             grdPaid.GetItemString(e.CurrentRow, "drg_bunho"));
            mIsPatient = false;
        }

        private void paid_PatientSelected(object sender, System.EventArgs e)
        {
            // grdMaster_RowFocusChanged call 하면 return 한다.
            if (mIsPatient) return;
            if (TypeCheck.IsNull(txtDrgBunho.GetDataValue()))
            {
                //XMessageBox.Show("투약번호를 입력하세요");
                return;
            }
            DetailServerCall(dtpOrderDate.GetDataValue(), paid.BunHo, txtDrgBunho.GetDataValue());

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void paid_PatientSelectionFailed(object sender, System.EventArgs e)
        {

        }

        private void rbx1_Click(object sender, System.EventArgs e)
        {
            this.btnProcess.Text = Resources.DRG0201U00_rbx1_Click_1;

            // 服薬指導せん出力ボタン
            this.btnPrintAdmMedi.Visible = false;

            rbx1.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            rbx2.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx3.ForeColor = IHIS.Framework.XColor.NormalForeColor;

            this.cbxActor.Enabled = true;
            this.cbxActor.SelectedIndex = 0;

            // https://sofiamedix.atlassian.net/browse/MED-14735
            this.btnFindUser.Enabled = true;

            // 実施者に 現在ログインしている IDを セットする｡
            this.cbxActor.SetDataValue(UserInfo.UserID);

            this.MasterServerCall();

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void rbx2_Click(object sender, System.EventArgs e)
        {
            this.btnProcess.Text = Resources.DRG0201U00_rbx2_Click_2;

            // 服薬指導せん出力ボタン
            //this.btnPrintAdmMedi.Visible = true;

            rbx1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx2.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            rbx3.ForeColor = IHIS.Framework.XColor.NormalForeColor;

            this.cbxActor.Enabled = false;

            // https://sofiamedix.atlassian.net/browse/MED-14735
            this.btnFindUser.Enabled = false;

            this.MasterServerCall();

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void rbx3_Click(object sender, System.EventArgs e)
        {
            this.btnProcess.Text = Resources.DRG0201U00_rbx3_Click_3;

            // 服薬指導せん出力ボタン
            this.btnPrintAdmMedi.Visible = false;

            rbx1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx2.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            rbx3.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;

            this.cbxActor.Enabled = false;

            this.MasterServerCall();

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void dtpOrderDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            MasterServerCall();

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void grdOrder_GridCellPainting_1(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["dis_gubun"].ToString() == "1")
            {
                switch (e.ColName)
                {
                    case "buseo_name":
                        e.ForeColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }
        }

        private void grdOrder_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            e.BackColor = (e.DataRow["boryu_yn"].ToString() == "Y" ? XColor.XListViewHeaderBackColor.Color : XColor.XGridRowBackColor.Color);
            if (e.ColName == "boryu_yn")
                e.ForeColor = (e.DataRow["boryu_yn"].ToString() == "Y" ? XColor.ErrMsgForeColor.Color : XColor.NormalForeColor.Color);
        }

        private void btnUpdateComment_Click(object sender, EventArgs e)
        {
            if (!LockChk()) return;

            if (paInfo.BunHo == "")
            {
                MessageBox.Show(Resources.messageBox);
            }

            if (grdPaid.RowCount > 0)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("in_out_gubun", "O");
                openParams.Add("from_date", dtpOrderDate.GetDataValue());
                openParams.Add("to_date", dtpOrderDate.GetDataValue());
                openParams.Add("bunho", paInfo.BunHo);

                XScreen.OpenScreenWithParam(this, "DRGS", "DRG9040U01", ScreenOpenStyle.PopUpFixed, openParams);
            }
            else
            {
                XMessageBox.Show(Resources.XMessageBox_msg, Resources.MSGCAPTION);
            }

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.MasterServerCall();
            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (this.rbx3.Checked || this.grdOrderList.RowCount < 1) return;

            if (this.rbx1.Checked && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("N")) return;

            if (this.rbx2.Checked && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y")) return;

            // https://sofiamedix.atlassian.net/browse/MED-14601
            //if (this.rbx1.Checked && this.cbxActor.Text.Length == 0)
            if (this.rbx1.Checked && this.dbxUserId.Text.Length == 0)
            {
                XMessageBox.Show(Resources.MSG_001, Resources.MSG_001_CAP, MessageBoxIcon.Warning);
                return;
            }
            if (this.rbx2.Checked)
            {
                foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                {
                    // 会計未処理のみ
                    if (dtRow["if_data_send_yn"].ToString() == "Y")
                    {
                        XMessageBox.Show(Resources.XMessageBox2, "", MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            this.DRG2010Save();

            if (this.cbxBarCode.GetDataValue().ToString() == "Y")
                this.tbxBarCode.Focus();
        }

        private void btnPrintAdmMedi_Click(object sender, EventArgs e)
        {
            #region deleted by Cloud
            //            BindVarCollection item = new BindVarCollection();
            //            object retVal = null;
            //            string ordChkDrg = "";
            //            string cmdText = null;

            //            #region CHECK DRG
            //            cmdText = @"SELECT DISTINCT 'Y' 
            //                          FROM (
            //                                SELECT SUBSTR(A.ORDER_GUBUN,2,1) ORDER_GUBUN
            //                                  FROM OCS1003 A
            //                                 WHERE A.HOSP_CODE = :f_hosp_code
            //                                   AND A.PKOCS1003 IN (SELECT B.FKOCS1003
            //                                                         FROM DRG2010 B
            //                                                        WHERE B.HOSP_CODE  = A.HOSP_CODE
            //                                                          AND B.JUBSU_DATE = :f_jubsu_date
            //                                                          AND B.DRG_BUNHO  = :f_drg_bunho
            //                                                          AND B.BUNHO      = :f_bunho)
            //                               ) C
            //                         WHERE C.ORDER_GUBUN IN ('C', 'D')";

            //            item.Clear();
            //            item.Add("f_hosp_code", EnvironInfo.HospCode);
            //            item.Add("f_jubsu_date", this.i_jubsu_date);
            //            item.Add("f_drg_bunho", this.i_drg_bunho);
            //            item.Add("f_bunho", this.i_bunho);

            //            retVal = Service.ExecuteScalar(cmdText, item);
            //            if (!TypeCheck.IsNull(retVal))
            //            {
            //                ordChkDrg = retVal.ToString();
            //            }

            //            if (ordChkDrg.Equals("Y"))
            //            {
            //                bool value = this.procJihInterface("D");

            //                if (value == false)
            //                {
            //                    throw new Exception();
            //                }
            //            }
            //#endregion

            //            #region CHECK INJ
            //            string ordChkInj = "";

            //            cmdText = @"SELECT DISTINCT 'Y' 
            //                          FROM (
            //                                SELECT SUBSTR(A.ORDER_GUBUN,2,1) ORDER_GUBUN
            //                                  FROM OCS1003 A
            //                                 WHERE A.HOSP_CODE = :f_hosp_code
            //                                   AND A.PKOCS1003 IN (SELECT B.FKOCS1003
            //                                                         FROM DRG2010 B
            //                                                        WHERE B.HOSP_CODE  = A.HOSP_CODE
            //                                                          AND B.JUBSU_DATE = :f_jubsu_date
            //                                                          AND B.DRG_BUNHO  = :f_drg_bunho
            //                                                          AND B.BUNHO      = :f_bunho)
            //                               ) C
            //                         WHERE C.ORDER_GUBUN IN ('B')";

            //            item.Clear();
            //            item.Add("f_hosp_code", EnvironInfo.HospCode);
            //            item.Add("f_jubsu_date", this.i_jubsu_date);
            //            item.Add("f_drg_bunho", this.i_drg_bunho);
            //            item.Add("f_bunho", this.i_bunho);

            //            retVal = Service.ExecuteScalar(cmdText, item);
            //            if (!TypeCheck.IsNull(retVal))
            //            {
            //                ordChkInj = retVal.ToString();
            //            }

            //            if (!TypeCheck.IsNull(ordChkInj) && ordChkInj.Equals("Y"))
            //            {
            //                bool value = this.procJihInterface("I");

            //                if (value == false)
            //                {
            //                    throw new Exception();
            //                }
            //            }
            //            #endregion
            #endregion

            #region updated by Cloud

            // No records count
            if (grdOrder.RowCount == 0) return;

            #region Check DRG - Cloud updated
            // Cloud updated code START
            DRG0201U00PrintAdmMediCheckDrgArgs drgArgs = new DRG0201U00PrintAdmMediCheckDrgArgs();
            drgArgs.JubsuDate = this.i_jubsu_date;
            drgArgs.DrgBunho = this.i_drg_bunho;
            drgArgs.Bunho = this.i_bunho;
            drgArgs.DataDubun = "0";
            drgArgs.InOutGubun = "O";
            drgArgs.Fk = this.i_fkout1001;
            drgArgs.IoGubun = "O";
            drgArgs.SendYn = "Y";
            drgArgs.Gubun = "D";
            drgArgs.UserId = UserInfo.UserID;
            DRG0201U00PrintAdmMediCheckResult drgRes = CloudService.Instance.Submit<DRG0201U00PrintAdmMediCheckResult,
                DRG0201U00PrintAdmMediCheckDrgArgs>(drgArgs);

            if (null == drgRes || !TypeCheck.IsNull(drgRes.ErrMsg))
            {
                XMessageBox.Show(drgRes.ErrMsg, "服薬指導せんデータ転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (drgRes.MsgResult == "1")
            {
                throw new Exception("転送マスタ（DRG5010）作成に問題が発生しました。");
            }

            if (drgRes.MsgResult == "2")
            {
                throw new Exception("薬局情報に反映されませんでした。");
            }

            if (drgRes.MsgResult == "3")
            {
                throw new Exception("服薬指導せんデータ（IFS7301, IFS7302）作成に問題が発生しました。");
            }

            //３．じほうにFILE転送
            if (drgRes.RetVal == "0")
            {
                if (this.atcTrans(drgRes.Pkdrg, "D"))
                {
                    XMessageBox.Show("服薬指導せんデータ転送の申請を成功しました。", "服薬指導せんデータ転送要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            // Cloud updated code END
            #endregion

            #region Check INJ - Cloud updated

            DRG0201U00PrintAdmMediCheckInjArgs injArgs = new DRG0201U00PrintAdmMediCheckInjArgs();
            injArgs.JubsuDate = this.i_jubsu_date;
            injArgs.DrgBunho = this.i_drg_bunho;
            injArgs.Bunho = this.i_bunho;
            injArgs.DataDubun = "0";
            injArgs.InOutGubun = "O";
            injArgs.Fk = this.i_fkout1001;
            injArgs.IoGubun = "O";
            injArgs.SendYn = "Y";
            injArgs.Gubun = "I";
            injArgs.UserId = UserInfo.UserID;
            DRG0201U00PrintAdmMediCheckResult injRes = CloudService.Instance.Submit<DRG0201U00PrintAdmMediCheckResult,
                DRG0201U00PrintAdmMediCheckInjArgs>(injArgs);

            if (null == injRes || !TypeCheck.IsNull(injRes.ErrMsg))
            {
                XMessageBox.Show(injRes.ErrMsg, "服薬指導せんデータ転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (injRes.MsgResult == "1")
            {
                throw new Exception("転送マスタ（DRG5030）作成に問題が発生しました。"); // I1
            }

            if (injRes.MsgResult == "2")
            {
                throw new Exception("薬局情報に反映されませんでした。"); // I2
            }

            if (injRes.MsgResult == "3")
            {
                throw new Exception("服薬指導せんデータ（IFS7303, IFS7304）作成に問題が発生しました。"); // I3
            }

            //３．じほうにFILE転送
            if (injRes.RetVal == "0")
            {
                if (this.atcTrans(injRes.Pkdrg, "D"))
                {
                    XMessageBox.Show("服薬指導せんデータ転送の申請を成功しました。", "服薬指導せんデータ転送要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            #endregion

            #endregion
        }

        #endregion

        #region Methods(private)

        private void PostLoad()
        {
            string admMediIF_yn = "";

            // 注射画面コントロールデータ照会
            //            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
            //                                            FROM INV0102
            //                                           WHERE HOSP_CODE = :f_hosp_code
            //                                             AND CODE_TYPE = 'DRG_CONSTANT'
            //                                        ORDER BY CODE";

            // Cloud udated code START
            this.mlayConstantInfo.ExecuteQuery = GetLayConstantInfo;
            // Cloud udated code END

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("admMediIF_yn")) admMediIF_yn = mlayConstantInfo.GetItemString(i, "code_value");
                }
            }

            // 服薬指導自動設定可否
            if (admMediIF_yn.Equals("Y"))
            {
                this.cbxAdmMediYN.Checked = true;
            }
            else
            {
                this.cbxAdmMediYN.Checked = false;
            }

            // https://sofiamedix.atlassian.net/browse/MED-14601
            this.dbxUserId.SetDataValue(UserInfo.UserID);
            this.dbxUserName.SetDataValue(UserInfo.UserName);
        }

        private void MasterServerCall()
        {
            string gubun = string.Empty;
            foreach (Control con in groupBox2.Controls)
                if (con is XFlatRadioButton && ((XFlatRadioButton)con).Checked) gubun = ((XFlatRadioButton)con).CheckedValue;

            this.grdOrder.Reset();
            this.grdOrderList.Reset();

            grdPaid.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());
            grdPaid.SetBindVarValue("f_gubun", gubun);
            grdPaid.SetBindVarValue("f_bunho", paid.BunHo);
            grdPaid.SetBindVarValue("f_hosp_code", mHospCode);
            grdPaid.QueryLayout(false);
        }

        private void DetailServerCall(string aOrderDate, string aBunho, string aDrgBunho)
        {
            #region deleted by Cloud
            //            this.grdOrder.QuerySQL = @"-- grdOrder --
            //                                  SELECT A.DRG_BUNHO                                 DRG_BUNHO
            //                                       , MAX(A.BUNHO)                                BUNHO
            //                                       , MAX(A.ORDER_DATE)                           ORDER_DATE
            //                                       , MAX(A.JUBSU_DATE)                           JUBSU_DATE
            //                                       , MAX(TRUNC(A.JUBSU_ILSI))                    DRG_JUBSU_DATE
            //                                       , MAX(A.JUBSU_TIME)                           JUBSU_TIME
            //                                       , MAX(A.DOCTOR)                               DOCTOR
            //                                       , MAX(C.DOCTOR_NAME)                          DOCTOR_NAME
            //                                       , MAX(A.GWA)                                  GWA
            //                                       , MAX(B.BUSEO_NAME)                           BUSEO_NAME
            //                                       , MAX(A.ACT_DATE)                             ACT_DATE
            //                                       , MAX(A.ACT_ILSI)                             ACT_TIME
            //                                       , MAX(DECODE(NVL(A.ACT_GWA,'N'),'N','N','Y')) ACT_YN
            //                                       , MAX(D.IF_DATA_SEND_DATE)                    SUNAB_DATE
            //                                       , MAX(A.CHULGO_DATE)                          CHULGO_DATE
            //                                       , MAX(FN_ADM_LOAD_USER_NM(A.ACT_USER, A.JUBSU_DATE)) ACT_USER_NAME
            //                                       , NVL(A.WONYOI_ORDER_YN, 'N')                 WONYOI_ORDER_YN
            //                                       , MAX(A.DIS_GUBUN )                           DIS_GUBUN
            //                                       , MAX(E.ORDER_REMARK)                         ORDER_REMARK
            //                                       , MAX(E.DRG_REMARK)                           DRG_REMARK
            //                                       --, MAX(A.FKOCS1003)                            FKOCS1003
            //                                       , MAX(D.FKOUT1001)                            FKOUT1001
            //                                    FROM DRG9040     E
            //                                       , OCS1003     D
            //                                       , BAS0270     C
            //                                       , VW_GWA_NAME B
            //                                       , DRG2010     A
            //                                   WHERE A.ORDER_DATE               = TO_DATE(:f_jubsu_date, 'YYYY/MM/DD')
            //                                     AND A.BUNHO                    = :f_bunho
            //                                     AND ((nvl(:f_drg_bunho, 'N')  != 'N' AND A.DRG_BUNHO = :f_drg_bunho)
            //                                       OR (nvl(:f_drg_bunho, 'N')   = 'N' AND A.DRG_BUNHO > 0))
            //                                     AND A.HOSP_CODE                = :f_hosp_code
            //                                     AND A.SOURCE_FKOCS1003         IS NULL
            //                                     AND NVL(A.DC_YN,'N')           <> 'Y'
            //                                     AND A.JUNDAL_PART              = 'PA'
            //                                     AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
            //                                     AND B.BUSEO_CODE               = A.GWA
            //                                     AND C.DOCTOR                (+)= A.DOCTOR
            //                                     AND A.FKOCS1003                = D.PKOCS1003
            //                                     AND A.SOURCE_FKOCS1003         IS NULL
            //                                     AND E.JUBSU_DATE            (+)= A.JUBSU_DATE
            //                                     AND E.DRG_BUNHO             (+)= A.DRG_BUNHO
            //                                     AND E.HOSP_CODE             (+)= A.HOSP_CODE
            //                                     AND D.HOSP_CODE                = A.HOSP_CODE
            //                                     AND C.HOSP_CODE             (+)= A.HOSP_CODE
            //                                     AND B.HOSP_CODE                = A.HOSP_CODE
            //                                   GROUP BY A.BUNHO, A.DRG_BUNHO, NVL(A.WONYOI_ORDER_YN, 'N')
            //                                   ORDER BY 1";
            //            grdOrder.SetBindVarValue("f_jubsu_date", aOrderDate.Replace("-", "").Replace("/", "").Substring(0, 8));
            //            grdOrder.SetBindVarValue("f_bunho", aBunho);
            //            grdOrder.SetBindVarValue("f_drg_bunho", aDrgBunho);
            //            grdOrder.SetBindVarValue("f_hosp_code", mHospCode);
            //            if (!grdOrder.QueryLayout(false))
            //            {
            //                XMessageBox.Show(Service.ErrFullMsg);
            //                return;
            //            }
            #endregion

            // Cloud updated code START
            grdOrder.ParamList = new List<string>(new string[]
                {
                    "f_jubsu_date",
                    "f_bunho",
                    "f_drg_bunho",
                    "f_hosp_code",
                });

            grdOrder.SetBindVarValue("f_jubsu_date", aOrderDate.Replace("-", "").Replace("/", "").Substring(0, 8));
            grdOrder.SetBindVarValue("f_bunho", aBunho);
            grdOrder.SetBindVarValue("f_drg_bunho", aDrgBunho);
            grdOrder.SetBindVarValue("f_hosp_code", mHospCode);

            grdOrder.ExecuteQuery = GetGrdOrderForDetailServerCall;
            if (!grdOrder.QueryLayout(false))
            {
                //XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            // Cloud updated code END
        }

        #region deleted by CloudService
        /*
        [Obsolete("this method is now updated by CloudService", true)]
        private bool procJihInterface(string gubun)
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            //１．中間テーブルデータ生成（DRG5010）
            inputList.Clear();
            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);       // 病院コード
            inputList.Add("I_JUBSU_DATE", this.i_jubsu_date);         // 受付日付
            inputList.Add("I_DRG_BUNHO", this.i_drg_bunho);           // 投薬番号

            inputList.Add("I_DATA_DUBUN", "0");                       // データ区分(登録)
            //if (rbx2.Checked) inputList.Add("I_DATA_DUBUN", "2");   // データ区分(取消)

            inputList.Add("I_IN_OUT_GUBUN", "O");                     // 入外区分
            inputList.Add("I_BUNHO", this.i_bunho);                   // 患者番号
            inputList.Add("I_FK", this.i_fkout1001);                  // FKOUT1001

            #region PR_JIH_DRG_DRG5010_INSERT
            if (gubun.Equals("D"))
            {
                try
                {
                    Service.BeginTransaction();

                    // IFSテーブル作成リターン値
                    int rtnIfsCnt = -1;
                    string pkdrg5010 = "";

                    bool value = Service.ExecuteProcedure("PR_JIH_DRG_DRG5010_INSERT", inputList, outputList);

                    if (value == false || TypeCheck.IsNull(outputList["O_PK"]) || outputList["O_PK"].ToString().Equals("-1"))
                    {
                        throw new Exception("転送マスタ（DRG5010）作成に問題が発生しました。"); //D1
                    }
                    else
                    {
                        pkdrg5010 = outputList["O_PK"].ToString();

                        BindVarCollection item = new BindVarCollection();

                        //OCS1003に転送情報Update
                        string QuerySQL = @"UPDATE DRG2010 A
                                           SET A.FKJIHKEY     = :f_pkdrg5010
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.JUBSU_DATE   = :f_jubsu_date
                                           AND A.DRG_BUNHO    = :f_drg_bunho
                                           AND A.BUNHO        = :f_bunho
                                           AND A.BUNRYU1      IN('1', '6')";

                        item.Clear();
                        item.Add("f_pkdrg5010", pkdrg5010);
                        item.Add("f_hosp_code", EnvironInfo.HospCode);
                        item.Add("f_jubsu_date", this.i_jubsu_date);
                        item.Add("f_drg_bunho", this.i_drg_bunho);
                        item.Add("f_bunho", this.i_bunho);

                        if (!Service.ExecuteNonQuery(QuerySQL, item))
                        {
                            throw new Exception("薬局情報に反映されませんでした。"); //D2
                        }

                        //２．I/Fテーブルデータ生成（IFS7301, IFS7302）
                        rtnIfsCnt = this.makeIFSTBL("O", pkdrg5010, "Y", "D");
                    }
                    Service.CommitTransaction();

                    //３．じほうにFILE転送
                    if (rtnIfsCnt == 0)
                    {
                        if (this.atcTrans(pkdrg5010, "D"))
                            XMessageBox.Show("服薬指導せんデータ転送の申請を成功しました。", "服薬指導せんデータ転送要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show(ex.Message, "服薬指導せんデータ転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);//D99
                    return false;
                }
            }
            #endregion

            #region PR_JIH_INJ_DRG5030_INSERT
            if (gubun.Equals("I"))
            {
                try
                {
                    Service.BeginTransaction();

                    // IFSテーブル作成リターン値
                    int rtnIfsCnt = -1;
                    string pkdrg5030 = "";

                    bool value = Service.ExecuteProcedure("PR_JIH_INJ_DRG5030_INSERT", inputList, outputList);

                    if (value == false || TypeCheck.IsNull(outputList["O_PK"]) || outputList["O_PK"].ToString().Equals("-1"))
                    {
                        throw new Exception("転送マスタ（DRG5030）作成に問題が発生しました。"); // I1
                    }
                    else
                    {
                        pkdrg5030 = outputList["O_PK"].ToString();

                        BindVarCollection item = new BindVarCollection();

                        //OCS1003に転送情報Update
                        string QuerySQL = @"UPDATE DRG2010 A
                                           SET A.FKJIHKEY     = :f_pkdrg5030
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.JUBSU_DATE   = :f_jubsu_date
                                           AND A.DRG_BUNHO    = :f_drg_bunho
                                           AND A.BUNHO        = :f_bunho
                                           AND A.BUNRYU1      = '4'";

                        item.Clear();
                        item.Add("f_pkdrg5030", pkdrg5030);
                        item.Add("f_hosp_code", EnvironInfo.HospCode);
                        item.Add("f_jubsu_date", this.i_jubsu_date);
                        item.Add("f_drg_bunho", this.i_drg_bunho);
                        item.Add("f_bunho", this.i_bunho);

                        if (!Service.ExecuteNonQuery(QuerySQL, item))
                        {
                            throw new Exception("薬局情報に反映されませんでした。"); // I2
                        }

                        //２．I/Fテーブルデータ生成（IFS7303, IFS7304）
                        rtnIfsCnt = this.makeIFSTBL("O", pkdrg5030, "Y", "I");
                    }
                    Service.CommitTransaction();

                    //３．じほうにFILE転送
                    if (rtnIfsCnt == 0)
                    {
                        if (this.atcTrans(pkdrg5030, "I"))
                            XMessageBox.Show("服薬指導せんデータ転送の申請を成功しました。", "服薬指導せんデータ転送要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show(ex.Message, "服薬指導せんデータ転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error); // I99
                    return false;
                }
            }
            #endregion

            return true;
        }

        [Obsolete("this method is now updated by CloudService", true)]
        private int makeIFSTBL(string io_gubun, string pkdrg, string send_yn, string gubun)
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            int retVal = -1;

            inputList.Clear();
            outputList.Clear();

            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
            inputList.Add("I_IO_GUBUN", io_gubun);
            //inputList.Add("I_JUBSU_DATE", this.i_jubsu_date);
            //inputList.Add("I_DRG_BUNHO", this.i_drg_bunho);
            inputList.Add("I_FKDRG", pkdrg);
            inputList.Add("I_USER_ID", UserInfo.UserID);
            //inputList.Add(send_yn);

            if (gubun.Equals("D")) // DRG
            {
                bool ret = Service.ExecuteProcedure("PR_JIH_DRG_IFS_PROC", inputList, outputList);

                if (ret == false || TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() == "1")
                {
                    throw new Exception("服薬指導せんデータ（IFS7301, IFS7302）作成に問題が発生しました。"); // D3
                }
                else retVal = Int32.Parse(outputList["O_ERR"].ToString());
            }

            if (gubun.Equals("I")) //INJ
            {
                bool ret = Service.ExecuteProcedure("PR_JIH_INJ_IFS_PROC", inputList, outputList);

                if (ret == false || TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() == "1")
                {
                    throw new Exception("服薬指導せんデータ（IFS7303, IFS7304）作成に問題が発生しました。"); // I3
                }
                else retVal = Int32.Parse(outputList["O_ERR"].ToString());
            }

            return retVal;
        }
        */
        #endregion

        private bool atcTrans(string pkdrg, string gubun)
        {
            if (TypeCheck.IsNull(pkdrg))
            {
                throw new Exception("転送するデータが存在しません。");
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText = null;

            if (gubun.Equals("D")) msgText = "97301" + pkdrg;
            if (gubun.Equals("I")) msgText = "97303" + pkdrg;

            //if (gubun.Equals("D")) msgText = "95010" + pkdrg;
            //if (gubun.Equals("I")) msgText = "95030" + pkdrg;

            // TODO Printer connect
            //int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            //if (ret == -1)
            //{
            //    throw new Exception("服薬指導せんデータを転送中､問題が発生しました。電文：" + msgText);
            //}
            return true;
        }

        private string ActChk(string orderDate, string drgBunho)
        {
            string actChk = "";
            //string cmdText = "";
            //object retVal = null;
            //BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_order_date", orderDate.Replace("-", "").Replace("/", "").Substring(0, 8));
            //bindVars.Add("f_drg_bunho", drgBunho);
            //bindVars.Add("f_hosp_code", mHospCode);

            // Cloud updated code START
            DRG0201U00ActChkArgs args = new DRG0201U00ActChkArgs();
            args.DrgBunho = drgBunho;
            args.OrderDate = orderDate.Replace("-", "").Replace("/", "").Substring(0, 8);
            DRG0201U00ActChkResult res = CloudService.Instance.Submit<DRG0201U00ActChkResult, DRG0201U00ActChkArgs>(args);

            if (null != res)
            {
                actChk = res.Result;
            }
            // Cloud updated code END

            #region Deleted by CloudService
            //            /*********************************************************/
            //            /* ACTING이 안된 것이 있으면 'N',                        */
            //            /* 모두 ACTING이 되었으면 'Y'                            */
            //            /*********************************************************/
            //            cmdText = @"SELECT 'N'
            //                          FROM (
            //                                 SELECT 'X'
            //                                   FROM DRG2010 A
            //                                  WHERE A.ORDER_DATE        = TO_DATE(:f_order_date,'YYYY/MM/DD')
            //                                    AND A.DRG_BUNHO         = TO_NUMBER(:f_drg_bunho)
            //                                    AND A.HOSP_CODE         = :f_hosp_code
            //                                    AND A.ACT_DATE         IS NULL
            //                                    AND NVL(A.DC_YN,'N')    = 'N'
            //                                    AND A.SOURCE_FKOCS1003 IS NULL
            //                                )";
            //            retVal = Service.ExecuteScalar(cmdText, bindVars);

            //            if (TypeCheck.IsNull(retVal))
            //            {
            //                actChk = "Y";
            //            }
            //            else if (!TypeCheck.IsNull(retVal))
            //            {
            //                actChk = retVal.ToString();
            //            }

            //            /****************************************************************/
            //            /* 미접수건이 있으면 '1'                                        */
            //            /****************************************************************/
            //            cmdText = string.Empty;
            //            retVal = null;
            //            cmdText = @"SELECT '1'
            //                          FROM (
            //                                 SELECT 'X'
            //                                   FROM DRG2010 A
            //                                  WHERE A.ORDER_DATE        = TO_DATE(:f_order_date,'YYYY/MM/DD')
            //                                    AND A.DRG_BUNHO         = TO_NUMBER(:f_drg_bunho)
            //                                    AND A.HOSP_CODE         = :f_hosp_code
            //                                    AND A.JUBSU_ILSI       IS NULL
            //                                    AND NVL(A.DC_YN,'N')    = 'N'
            //                                    AND A.SOURCE_FKOCS1003 IS NULL
            //                                )";
            //            retVal = Service.ExecuteScalar(cmdText, bindVars);

            //            if (!TypeCheck.IsNull(retVal))
            //            {
            //                actChk = retVal.ToString();
            //            }
            #endregion

            return actChk;
        }

        //시스템에 따른 사용가능여부 체크
        private bool LockChk()
        {
            //drgs는 체크하지 않음
            if (EnvironInfo.CurrSystemID == "DRGS")
                return true;

            //            //drgs를 제외한 시스템은 사용여부 체크
            //            if (!TypeCheck.IsNull(Service.ExecuteScalar(@"SELECT 'Y'
            //                                                            FROM DRG9043
            //                                                           WHERE TO_CHAR(SYSDATE,'yyyymmddhh24mi')
            //                                                                 BETWEEN TO_CHAR(START_DATE,'yyyymmdd') || START_TIME
            //                                                                     AND TO_CHAR(END_DATE,'yyyymmdd') || END_TIME
            //                                                             AND CANCEL_DATE IS NULL
            //                                                             AND HOSP_CODE = '" + mHospCode + "'")))
            //            {
            //                return true;
            //            }

            // Cloud updated code START
            DRG0201U00LockChkResult res = CloudService.Instance.Submit<DRG0201U00LockChkResult,
                DRG0201U00LockChkArgs>(new DRG0201U00LockChkArgs());

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!TypeCheck.IsNull(res.Result))
                {
                    return true;
                }
            }
            // Cloud updated code END

            MessageBox.Show("プログラムを使用できません。薬局に問合せしてください!!!");

            return false;
        }

        private void DRG2010Save()
        {
            #region Deleted by Cloud
            //ArrayList inputList = new ArrayList(); 
            //ArrayList outputList = new ArrayList();

            //inputList.Add(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            //inputList.Add(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho"));

            //if (rbx1.Checked)
            //{
            //    inputList.Add(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_date"));
            //    //inputList.Add(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_date"));
            //    inputList.Add(this.cbxActor.GetDataValue());
            //}
            //else
            //{
            //    inputList.Add(null);
            //    //inputList.Add(null);
            //    inputList.Add(null);
            //}

            //inputList.Add(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "chulgo_buseo"));
            //inputList.Add(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonyoi_yn"));
            //inputList.Add(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn"));
            ////inputList.Add(mHospCode);


            //// 服薬指導せんのグロバール変数セット --------------------------------------------------------
            //this.i_jubsu_date = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_date");
            //this.i_drg_bunho = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "drg_bunho");
            //this.i_bunho = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho");
            //this.i_fkout1001 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "fkout1001");
            ////---------------------------------------------------------------------------------------------


            //// 投薬か取消かをチェックする｡
            string jihYN = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn");
            #endregion

            #region Updated by Cloud

            // No change?
            if (grdOrder.RowCount == 0) return;

            //https://sofiamedix.atlassian.net/browse/MED-11178
            List<OBCheckInventoryParamInfo> inputLst = new List<OBCheckInventoryParamInfo>();
            List<DRG0201U00InventoryInfo> orderLst = new List<DRG0201U00InventoryInfo>();
            for (int i = 0; i < grdOrderList.RowCount; i++)
            {
                OBCheckInventoryParamInfo item = new OBCheckInventoryParamInfo();
                item.HangmogCode = grdOrderList.GetItemString(i, "jaeryo_code");
                item.HangmogName = grdOrderList.GetItemString(i, "jaeryo_name");
                item.Dv = grdOrderList.GetItemString(i, "dv");
                item.Nalsu = grdOrderList.GetItemString(i, "nalsu");
                item.Suryang = grdOrderList.GetItemString(i, "ord_suryang");
                inputLst.Add(item);

                DRG0201U00InventoryInfo order = new DRG0201U00InventoryInfo();
                order.JaeryoCode = grdOrderList.GetItemString(i, "jaeryo_code");
                order.Dv = grdOrderList.GetItemString(i, "dv");
                order.Nalsu = grdOrderList.GetItemString(i, "nalsu");
                order.OrdSuryang = grdOrderList.GetItemString(i, "ord_suryang");
                order.DvTime = grdOrderList.GetItemString(i, "dv_time");
                order.Fkocs1003 = grdOrderList.GetItemString(i, "fkocs1003");
                orderLst.Add(order);
            }

            if (!Utilities.CheckInventory(inputLst))
            {
                return;
            }
            bool updateRes = false;
            DRG0201U00PrDrgUpdateChulgoArgs args = new DRG0201U00PrDrgUpdateChulgoArgs();
            args.JubsuDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            args.DrgBunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
            args.ChulgoDate = (rbx1.Checked) ? grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_date") : string.Empty;

            // https://sofiamedix.atlassian.net/browse/MED-14601
            //args.ActUser = (rbx1.Checked) ? this.cbxActor.GetDataValue() : string.Empty;
            args.ActUser = (rbx1.Checked) ? this.dbxUserId.GetDataValue() : string.Empty;

            args.ChulgoBuseo = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "chulgo_buseo");
            args.WonyoiOrderYn = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "wonyoi_yn");
            args.ActYn = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn");
            args.Lst = orderLst;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, DRG0201U00PrDrgUpdateChulgoArgs>(args);
            if (null != res)
            {
                updateRes = res.Result;
            }
            // Cloud updated code END

            if (/*!Service.ExecuteProcedure("PR_DRG_UPDATE_CHULGO", inputList, outputList)*/!updateRes) // updated by Cloud
            {
                XMessageBox.Show(Resources.MSG_Fail);
                return;
            }
            else
            {
                if (this.cbxBarCode.GetDataValue().ToString() == "N")
                {
                    string bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
                    string order_date = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
                    string drg_bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "drg_bunho");
                    bunho = paid.BunHo;

                    //this.DetailServerCall(order_date, bunho, drg_bunho);

                    //this.MasterServerCall();

                    //this.rbx2.Checked = true;

                    this.btnQuery.PerformClick();

                    // 服薬指導ON、投薬の場合のみ　自動出力する。
                    if (this.cbxAdmMediYN.Checked == true && jihYN.Equals("Y"))
                    {
                        //// 服薬指導せん出力ボタン
                        //this.btnPrintAdmMedi.Visible = true;

                        // 服薬指導せん出力ボタン実行
                        this.btnPrintAdmMedi.PerformClick();
                    }
                }
            }

            #endregion
        }

        #endregion

        #region Cloud connector updated

        #region InitItemsControl
        /// <summary>
        /// InitItemsControl
        /// </summary>
        private void InitItemsControl()
        {
            // grdOrderList
            grdOrderList.ParamList = new List<string>(new string[]
                {
                    "f_jubsu_date",
                    "f_drg_bunho",
                    "f_hosp_code",
                });
            grdOrderList.ExecuteQuery = GetGrdOrderList;

            // grdPaid
            this.grdPaid.ParamList = new List<string>(new string[]
                {
                    "f_order_date",
                    "f_gubun",
                    "f_bunho",
                    "f_hosp_code",
                });
            this.grdPaid.ExecuteQuery = GetGrdPaid;

            // cbxActor
            cbxActor.ExecuteQuery = GetCbxActor;
            cbxActor.SetDictDDLB();
        }
        #endregion

        #region GetGrdOrderList
        /// <summary>
        /// GetGrdOrderList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOrderList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRG0201U00GrdOrderListArgs args = new DRG0201U00GrdOrderListArgs();
            args.DrgBunho = bvc["f_drg_bunho"].VarValue;
            args.JubsuDate = bvc["f_jubsu_date"].VarValue;
            DRG0201U00GrdOrderListResult res = CloudService.Instance.Submit<DRG0201U00GrdOrderListResult, DRG0201U00GrdOrderListArgs>(args);

            if (null != res)
            {
                foreach (DRG0201U00GrdOrderListInfo item in res.GrdOrderListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        item.DrgBunho,
                        item.NaewonDate,
                        item.GroupSer,
                        item.JubsuDate,
                        item.OrderDate,
                        item.JaeryoCode,
                        item.Nalsu,
                        item.Divide,
                        item.OrdSuryang,
                        item.OrderSuryang,
                        item.OrderDanui,
                        item.SubulDanui,
                        item.GroupYn,
                        item.JaeryoGubun,
                        item.BogyongCode,
                        item.BogyongName,
                        item.CautionName,
                        item.CautionCode,
                        item.MixYn,
                        item.AtcYn,
                        item.Remark,
                        item.Dv,
                        item.DvTime,
                        item.DcYn,
                        item.BannabYn,
                        item.SourceFkocs1003,
                        item.Fkocs1003,
                        item.Fkout1001,
                        item.SunabDate,
                        item.Pattern,
                        item.JaeryoName,
                        item.SunabNalsu,
                        item.WonyoiYn,
                        item.OcsRemark,
                        item.ActDate,
                        item.Mayak,
                        item.TpnJojeGubun,
                        item.UiJusaYn,
                        item.SubulSuryang,
                        item.SerialV,
                        item.OrderRemark,
                        item.DrgRemark,
                        item.HubakChangeYn,
                        item.Pharmacy,
                        item.DrgPackYn,
                        item.PowderYn,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdPaid
        /// <summary>
        /// GetGrdPaid
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPaid(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRG0201U00GrdPaidArgs args = new DRG0201U00GrdPaidArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.Gubun = bvc["f_gubun"].VarValue;
            args.OrderDate = bvc["f_order_date"].VarValue;
            DRG0201U00GrdPaidResult res = CloudService.Instance.Submit<DRG0201U00GrdPaidResult, DRG0201U00GrdPaidArgs>(args);

            if (null != res)
            {
                foreach (DRG0201U00GrdPaidInfo item in res.GrdPaidItem)
                {
                    lObj.Add(new object[]
                    {
                        item.TrialYn,
                        item.DrgBunho,
                        item.Bunho,
                        item.OrderDate,
                        item.JojeYn,
                        item.Suname,
                        item.OrderRemark,
                        item.DrgRemark,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetLayConstantInfo
        /// <summary>
        /// GetLayConstantInfo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetLayConstantInfo(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            //LayConstantInfoResult res = CacheService.Instance.Get<LayConstantInfoArgs,
            //    LayConstantInfoResult>(Constants.CacheKeyCbo.CACHE_DRG_LAY_CONSTANT_INFO_KEYS, new LayConstantInfoArgs());
            LayConstantInfoResult res = CacheService.Instance.Get<LayConstantInfoArgs, LayConstantInfoResult>(new LayConstantInfoArgs());

            if (null != res)
            {
                foreach (LayConstantInfo item in res.LayConstantItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                        item.CodeValue,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetCbxActor
        /// <summary>
        /// GetCbxActor
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCbxActor(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRG0201U00CbxActorResult res = CloudService.Instance.Submit<DRG0201U00CbxActorResult,
                DRG0201U00CbxActorArgs>(new DRG0201U00CbxActorArgs());

            if (null != res)
            {
                foreach (ComboListItemInfo item in res.CbxActorItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdOrderForDetailServerCall
        /// <summary>
        /// GetGrdOrderForDetailServerCall
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOrderForDetailServerCall(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRG0201U00GrdOrderDetailServerCallArgs args = new DRG0201U00GrdOrderDetailServerCallArgs();
            args.Bunho = bvc["f_bunho"].VarValue;
            args.DrgBunho = bvc["f_drg_bunho"].VarValue;
            args.JubsuDate = bvc["f_jubsu_date"].VarValue;
            DRG0201U00GrdOrderDetailServerCallResult res = CloudService.Instance.Submit<DRG0201U00GrdOrderDetailServerCallResult,
                DRG0201U00GrdOrderDetailServerCallArgs>(args);

            if (null != res)
            {
                foreach (DRG0201U00GrdOrderInfo item in res.GrdOrderItem)
                {
                    lObj.Add(new object[]
                    {
                        item.DrgBunho,
                        item.Bunho,
                        item.OrderDate,
                        item.JubsuDate,
                        item.DrgJubsuDate,
                        item.JubsuTime,
                        item.Doctor,
                        item.DoctorName,
                        item.Gwa,
                        item.BuseoName,
                        item.ActDate,
                        item.ActTime,
                        item.ActYn,
                        item.SunabDate,
                        item.ChulgoDate,
                        item.ActUserName,
                        item.WonyoiOrderYn,
                        item.DisGubun,
                        item.OrderRemark,
                        item.DrgRemark,
                        item.Fkout1001,
                        item.BuseoName,
                        item.IfDataSendYn
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdOrderForTbxBarCodeKeyPress
        /// <summary>
        /// GetGrdOrderForTbxBarCodeKeyPress
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOrderForTbxBarCodeKeyPress(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRG0201U00GrdOrderTbxBarCodeArgs args = new DRG0201U00GrdOrderTbxBarCodeArgs();
            args.DrgBunho = bvc["f_drg_bunho"].VarValue;
            args.OrerDate = bvc["f_orer_date"].VarValue;
            DRG0201U00GrdOrderTbxBarCodeResult res = CloudService.Instance.Submit<DRG0201U00GrdOrderTbxBarCodeResult,
                DRG0201U00GrdOrderTbxBarCodeArgs>(args);

            if (null != res)
            {
                // ActCheck
                mActYn = res.ActYn;

                foreach (DRG0201U00GrdOrderInfo item in res.GrdOrderItem)
                {
                    lObj.Add(new object[]
                    {
                        item.DrgBunho,
                        item.Bunho,
                        item.OrderDate,
                        item.JubsuDate,
                        item.DrgJubsuDate,
                        item.JubsuTime,
                        item.Doctor,
                        item.DoctorName,
                        item.Gwa,
                        item.BuseoName,
                        item.ActDate,
                        item.ActTime,
                        item.ActYn,
                        item.SunabDate,
                        item.ChulgoDate,
                        item.ActUserName,
                        item.WonyoiOrderYn,
                        item.DisGubun,
                        item.OrderRemark,
                        item.DrgRemark,
                        item.Fkout1001,
                    });
                }
            }

            return lObj;
        }
        #endregion

        private void grdPaid_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //trial patient
            if (e.DataRow["trial"].ToString() == "Y")
            {
                this.grdPaid[e.RowNumber + 1, 1].ToolTipText = Resources.SMS_TRIAL;
            }
            if (e.DataRow["trial"].ToString() == "N")
            {
                this.grdPaid[e.RowNumber + 1, 1].ToolTipText = " ";
            }
        }

        #endregion

        #region https://sofiamedix.atlassian.net/browse/MED-14601

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", dbxUserId.GetDataValue());
            param.Add("user_name", dbxUserName.GetDataValue());
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "ADM104Q":

                    #region https://sofiamedix.atlassian.net/browse/MED-14601

                    string userId = "";
                    string userName = "";

                    if (commandParam != null && commandParam.Contains("user_id"))
                    {
                        userId = commandParam["user_id"].ToString();
                        this.dbxUserId.SetDataValue(userId);
                    }

                    if (commandParam != null && commandParam.Contains("user_name"))
                    {
                        userName = commandParam["user_name"].ToString();
                        this.dbxUserName.SetDataValue(userName);
                    }

                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        this.grdOrder.SetItemValue(i, "act_doctor", userId);
                        this.grdOrder.SetItemValue(i, "act_doctor_name", userName);
                    }
                    break;

                    #endregion

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        #endregion
    }
}