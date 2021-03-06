#region 사용 NameSpace 지정
using System;
using System.Data;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.DOCS
{
	/// <summary>
	/// DOC2001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DOC2001U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string strPic1         = string.Empty;
		private string strPic2         = string.Empty;
		private long intPic1		   = 0;
		private long intPic2		   = 0;
        private string fkinp1001 = string.Empty;
        private int currentIndex = -1;
        private string input_tab = "";

		// 데이터 수정됬는지 확인용 백업테이블
		private DataTable DOC2001Back;
        //private int PopCount = 0;

        // 라디오 버튼 컬러
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));
        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));
        Sang dlg;

        ArrayList allItems = new ArrayList();

		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlLeft;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPatientBox paBox;
		private System.Windows.Forms.Label lblCert_wrdt;
		private System.Windows.Forms.Label lblGwa;
        private IHIS.Framework.XDisplayBox dpbGwa;
		private IHIS.Framework.XDataWindow dwDoc2001u00;
		private System.Windows.Forms.GroupBox gbxPast_cert;
		private System.Windows.Forms.GroupBox gbxCert_rqin;
		private IHIS.Framework.XEditGrid grdCert_past;
		private IHIS.Framework.XEditGrid grdCert_rqin;
		private IHIS.Framework.XButton btnSang_code;
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
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.MultiLayout layComboSet; 
		private IHIS.Framework.XDatePicker dtpCert_wrdt;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGrid grdDOC2001;
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
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XButton btnReser_ward;
        private System.Windows.Forms.Label lblDoc0101;
		private IHIS.Framework.XPanel pnlPabox;
		private IHIS.Framework.XCalendar calDate;
        private IHIS.Framework.XButton btnUser;
		private IHIS.Framework.XButton btnPrint;
		private IHIS.Framework.XButton btnHospitalSearch;
		private IHIS.Framework.XButton btnDrug;
		private IHIS.Framework.XButton btnDoctor;
		private IHIS.Framework.XButton btnPic2Add;
		private IHIS.Framework.XButton btnPic2Del;
		private IHIS.Framework.XButton btnPic1Add;
		private IHIS.Framework.XButton btnPic1Del;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGrid grdImage;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XButton btnEmrOpen;
        private IHIS.Framework.XBuseoCombo cboGwa;
        private SingleLayout layToiwonBaseInfo;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem20;
        private SingleLayoutItem singleLayoutItem21;
        private SingleLayoutItem singleLayoutItem22;
        private SingleLayout layCert_wrdt;
        private XButton btnEMR;
        private SingleLayout layHospInfo;
        private SingleLayoutItem singleLayoutItem23;
        private SingleLayoutItem singleLayoutItem24;
        private SingleLayoutItem singleLayoutItem25;
        private SingleLayoutItem singleLayoutItem26;
        private SingleLayoutItem singleLayoutItem27;
        private SingleLayoutItem singleLayoutItem28;
        private SingleLayoutItem singleLayoutItem29;
        private XButtonList btnList;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private SingleLayout layDocInfo;
        private SingleLayoutItem singleLayoutItem37;
        private SingleLayoutItem singleLayoutItem38;
        private SingleLayoutItem singleLayoutItem30;
        private SingleLayoutItem singleLayoutItem31;
        private SingleLayoutItem singleLayoutItem32;
        private SingleLayoutItem singleLayoutItem33;
        private SingleLayoutItem singleLayoutItem34;
        private SingleLayoutItem singleLayoutItem35;
        private SingleLayoutItem singleLayoutItem36;
        private SingleLayoutItem singleLayoutItem41;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private SingleLayoutItem singleLayoutItem42;
        private MultiLayout layNurPlan;
        private MultiLayoutItem multiLayoutItem3;
        private XButton btnZoomIn;
        private XDisplayBox dbxZoom;
        private XButton btnZoomOut;
        private XButton btnSang;
        private XButtonList btnListUpdate;
        private XTreeView tvwDOC2001;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XPanel pnlBt;
        private XComboBox cboUse;
        private Label label1;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private XDictComboBox cboDoc0101;
        private SingleLayoutItem singleLayoutItem3;
        private XEditGrid grdToiwonList;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XPanel pnlInp;
        private XPanel xPanel2;
        private XRadioButton rbnOutData;
        private XRadioButton rbnInData;
        private XButton btnDo;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public DOC2001U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}
		#endregion

		#region 소멸자
		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DOC2001U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblCert_wrdt = new System.Windows.Forms.Label();
            this.dtpCert_wrdt = new IHIS.Framework.XDatePicker();
            this.pnlBt = new IHIS.Framework.XPanel();
            this.btnDo = new IHIS.Framework.XButton();
            this.btnHospitalSearch = new IHIS.Framework.XButton();
            this.btnSang = new IHIS.Framework.XButton();
            this.btnDoctor = new IHIS.Framework.XButton();
            this.btnDrug = new IHIS.Framework.XButton();
            this.btnPic2Del = new IHIS.Framework.XButton();
            this.btnSang_code = new IHIS.Framework.XButton();
            this.btnPic2Add = new IHIS.Framework.XButton();
            this.btnPic1Add = new IHIS.Framework.XButton();
            this.btnUser = new IHIS.Framework.XButton();
            this.btnReser_ward = new IHIS.Framework.XButton();
            this.btnPic1Del = new IHIS.Framework.XButton();
            this.cboGwa = new IHIS.Framework.XBuseoCombo();
            this.lblGwa = new System.Windows.Forms.Label();
            this.lblDoc0101 = new System.Windows.Forms.Label();
            this.pnlPabox = new IHIS.Framework.XPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUse = new IHIS.Framework.XComboBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.cboDoc0101 = new IHIS.Framework.XDictComboBox();
            this.calDate = new IHIS.Framework.XCalendar();
            this.dpbGwa = new IHIS.Framework.XDisplayBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnListUpdate = new IHIS.Framework.XButtonList();
            this.btnZoomIn = new IHIS.Framework.XButton();
            this.dbxZoom = new IHIS.Framework.XDisplayBox();
            this.btnZoomOut = new IHIS.Framework.XButton();
            this.btnEMR = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnEmrOpen = new IHIS.Framework.XButton();
            this.grdImage = new IHIS.Framework.XEditGrid();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdDOC2001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.pnlInp = new IHIS.Framework.XPanel();
            this.tvwDOC2001 = new IHIS.Framework.XTreeView();
            this.grdToiwonList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.rbnOutData = new IHIS.Framework.XRadioButton();
            this.rbnInData = new IHIS.Framework.XRadioButton();
            this.gbxCert_rqin = new System.Windows.Forms.GroupBox();
            this.grdCert_rqin = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.gbxPast_cert = new System.Windows.Forms.GroupBox();
            this.grdCert_past = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.dwDoc2001u00 = new IHIS.Framework.XDataWindow();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layToiwonBaseInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem42 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem20 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.layCert_wrdt = new IHIS.Framework.SingleLayout();
            this.layHospInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem23 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem28 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem24 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem25 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem26 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem27 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem29 = new IHIS.Framework.SingleLayoutItem();
            this.layDocInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem41 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem37 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem38 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem30 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem31 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem32 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem33 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem34 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem35 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem36 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layNurPlan = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlBt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).BeginInit();
            this.pnlPabox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDate)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDOC2001)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlInp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdToiwonList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.gbxCert_rqin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCert_rqin)).BeginInit();
            this.gbxPast_cert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCert_past)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNurPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "");
            this.ImageList.Images.SetKeyName(12, "");
            this.ImageList.Images.SetKeyName(13, "");
            this.ImageList.Images.SetKeyName(14, "");
            this.ImageList.Images.SetKeyName(15, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(16, "YESDN1.ICO");
            this.ImageList.Images.SetKeyName(17, "열린폴더.gif");
            this.ImageList.Images.SetKeyName(18, "닫힌폴더.gif");
            this.ImageList.Images.SetKeyName(19, "OCSI.ico");
            this.ImageList.Images.SetKeyName(20, "간호-부서처방2.ico");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblCert_wrdt);
            this.pnlTop.Controls.Add(this.dtpCert_wrdt);
            this.pnlTop.Controls.Add(this.pnlBt);
            this.pnlTop.Controls.Add(this.cboGwa);
            this.pnlTop.Controls.Add(this.lblGwa);
            this.pnlTop.Controls.Add(this.lblDoc0101);
            this.pnlTop.Controls.Add(this.pnlPabox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTop.Size = new System.Drawing.Size(1181, 84);
            this.pnlTop.TabIndex = 0;
            // 
            // lblCert_wrdt
            // 
            this.lblCert_wrdt.BackColor = System.Drawing.Color.Transparent;
            this.lblCert_wrdt.Location = new System.Drawing.Point(982, 51);
            this.lblCert_wrdt.Name = "lblCert_wrdt";
            this.lblCert_wrdt.Size = new System.Drawing.Size(59, 20);
            this.lblCert_wrdt.TabIndex = 1;
            this.lblCert_wrdt.Text = "作成日付";
            this.lblCert_wrdt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpCert_wrdt
            // 
            this.dtpCert_wrdt.IsJapanYearType = true;
            this.dtpCert_wrdt.Location = new System.Drawing.Point(1045, 51);
            this.dtpCert_wrdt.Name = "dtpCert_wrdt";
            this.dtpCert_wrdt.Size = new System.Drawing.Size(108, 20);
            this.dtpCert_wrdt.TabIndex = 3;
            this.dtpCert_wrdt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpCert_wrdt_DataValidating);
            // 
            // pnlBt
            // 
            this.pnlBt.BackgroundImage = global::IHIS.DOCS.Properties.Resources.TopBackground;
            this.pnlBt.Controls.Add(this.btnDo);
            this.pnlBt.Controls.Add(this.btnHospitalSearch);
            this.pnlBt.Controls.Add(this.btnSang);
            this.pnlBt.Controls.Add(this.btnDoctor);
            this.pnlBt.Controls.Add(this.btnDrug);
            this.pnlBt.Controls.Add(this.btnPic2Del);
            this.pnlBt.Controls.Add(this.btnSang_code);
            this.pnlBt.Controls.Add(this.btnPic2Add);
            this.pnlBt.Controls.Add(this.btnPic1Add);
            this.pnlBt.Controls.Add(this.btnUser);
            this.pnlBt.Controls.Add(this.btnReser_ward);
            this.pnlBt.Controls.Add(this.btnPic1Del);
            this.pnlBt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBt.Location = new System.Drawing.Point(0, 0);
            this.pnlBt.Name = "pnlBt";
            this.pnlBt.Size = new System.Drawing.Size(1181, 42);
            this.pnlBt.TabIndex = 15;
            // 
            // btnDo
            // 
            this.btnDo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDo.ImageIndex = 20;
            this.btnDo.ImageList = this.ImageList;
            this.btnDo.Location = new System.Drawing.Point(601, 0);
            this.btnDo.Name = "btnDo";
            this.btnDo.Size = new System.Drawing.Size(80, 42);
            this.btnDo.TabIndex = 13;
            this.btnDo.Text = "Doオーダ";
            this.btnDo.Visible = false;
            this.btnDo.Click += new System.EventHandler(this.btnDo_Click);
            // 
            // btnHospitalSearch
            // 
            this.btnHospitalSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHospitalSearch.ImageIndex = 10;
            this.btnHospitalSearch.ImageList = this.ImageList;
            this.btnHospitalSearch.Location = new System.Drawing.Point(400, 0);
            this.btnHospitalSearch.Name = "btnHospitalSearch";
            this.btnHospitalSearch.Size = new System.Drawing.Size(80, 42);
            this.btnHospitalSearch.TabIndex = 6;
            this.btnHospitalSearch.Text = "病院検索";
            this.btnHospitalSearch.Visible = false;
            // 
            // btnSang
            // 
            this.btnSang.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSang.ImageIndex = 4;
            this.btnSang.ImageList = this.ImageList;
            this.btnSang.Location = new System.Drawing.Point(681, 0);
            this.btnSang.Name = "btnSang";
            this.btnSang.Size = new System.Drawing.Size(100, 42);
            this.btnSang.TabIndex = 3;
            this.btnSang.Text = "患者別傷病";
            this.btnSang.Click += new System.EventHandler(this.btnSang_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDoctor.ImageIndex = 12;
            this.btnDoctor.ImageList = this.ImageList;
            this.btnDoctor.Location = new System.Drawing.Point(781, 0);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(80, 42);
            this.btnDoctor.TabIndex = 8;
            this.btnDoctor.Text = "主治医";
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // btnDrug
            // 
            this.btnDrug.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDrug.ImageIndex = 11;
            this.btnDrug.ImageList = this.ImageList;
            this.btnDrug.Location = new System.Drawing.Point(861, 0);
            this.btnDrug.Name = "btnDrug";
            this.btnDrug.Size = new System.Drawing.Size(80, 42);
            this.btnDrug.TabIndex = 4;
            this.btnDrug.Text = "定時薬";
            this.btnDrug.Click += new System.EventHandler(this.btnDrug_Click);
            // 
            // btnPic2Del
            // 
            this.btnPic2Del.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPic2Del.ImageIndex = 1;
            this.btnPic2Del.ImageList = this.ImageList;
            this.btnPic2Del.Location = new System.Drawing.Point(300, 0);
            this.btnPic2Del.Name = "btnPic2Del";
            this.btnPic2Del.Size = new System.Drawing.Size(100, 42);
            this.btnPic2Del.TabIndex = 10;
            this.btnPic2Del.Text = "ｲﾒｰｼﾞ2 削除";
            this.btnPic2Del.Visible = false;
            // 
            // btnSang_code
            // 
            this.btnSang_code.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSang_code.ImageIndex = 5;
            this.btnSang_code.ImageList = this.ImageList;
            this.btnSang_code.Location = new System.Drawing.Point(941, 0);
            this.btnSang_code.Name = "btnSang_code";
            this.btnSang_code.Size = new System.Drawing.Size(80, 42);
            this.btnSang_code.TabIndex = 1;
            this.btnSang_code.Text = "傷病";
            this.btnSang_code.Click += new System.EventHandler(this.btnSang_code_Click);
            // 
            // btnPic2Add
            // 
            this.btnPic2Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPic2Add.ImageIndex = 2;
            this.btnPic2Add.ImageList = this.ImageList;
            this.btnPic2Add.Location = new System.Drawing.Point(200, 0);
            this.btnPic2Add.Name = "btnPic2Add";
            this.btnPic2Add.Size = new System.Drawing.Size(100, 42);
            this.btnPic2Add.TabIndex = 9;
            this.btnPic2Add.Text = "ｲﾒｰｼﾞ2 追加";
            this.btnPic2Add.Visible = false;
            // 
            // btnPic1Add
            // 
            this.btnPic1Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPic1Add.ImageIndex = 2;
            this.btnPic1Add.ImageList = this.ImageList;
            this.btnPic1Add.Location = new System.Drawing.Point(100, 0);
            this.btnPic1Add.Name = "btnPic1Add";
            this.btnPic1Add.Size = new System.Drawing.Size(100, 42);
            this.btnPic1Add.TabIndex = 11;
            this.btnPic1Add.Text = "ｲﾒｰｼﾞ1 追加";
            this.btnPic1Add.Visible = false;
            // 
            // btnUser
            // 
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUser.ImageIndex = 4;
            this.btnUser.ImageList = this.ImageList;
            this.btnUser.Location = new System.Drawing.Point(1021, 0);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(80, 42);
            this.btnUser.TabIndex = 2;
            this.btnUser.Text = "傷病分類";
            this.btnUser.Visible = false;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnReser_ward
            // 
            this.btnReser_ward.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReser_ward.ImageIndex = 4;
            this.btnReser_ward.ImageList = this.ImageList;
            this.btnReser_ward.Location = new System.Drawing.Point(1101, 0);
            this.btnReser_ward.Name = "btnReser_ward";
            this.btnReser_ward.Size = new System.Drawing.Size(80, 42);
            this.btnReser_ward.TabIndex = 4;
            this.btnReser_ward.Text = "定形文";
            this.btnReser_ward.Click += new System.EventHandler(this.btnReser_ward_Click);
            // 
            // btnPic1Del
            // 
            this.btnPic1Del.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPic1Del.ImageIndex = 1;
            this.btnPic1Del.ImageList = this.ImageList;
            this.btnPic1Del.Location = new System.Drawing.Point(0, 0);
            this.btnPic1Del.Name = "btnPic1Del";
            this.btnPic1Del.Size = new System.Drawing.Size(100, 42);
            this.btnPic1Del.TabIndex = 12;
            this.btnPic1Del.Text = "ｲﾒｰｼﾞ1 削除";
            this.btnPic1Del.Visible = false;
            // 
            // cboGwa
            // 
            this.cboGwa.Location = new System.Drawing.Point(862, 51);
            this.cboGwa.MaxDropDownItems = 30;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.Size = new System.Drawing.Size(106, 21);
            this.cboGwa.TabIndex = 5;
            this.cboGwa.SelectedValueChanged += new System.EventHandler(this.cboGwa_SelectedValueChanged);
            // 
            // lblGwa
            // 
            this.lblGwa.BackColor = System.Drawing.Color.Transparent;
            this.lblGwa.Location = new System.Drawing.Point(788, 52);
            this.lblGwa.Name = "lblGwa";
            this.lblGwa.Size = new System.Drawing.Size(72, 20);
            this.lblGwa.TabIndex = 3;
            this.lblGwa.Text = "発行診療科";
            this.lblGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDoc0101
            // 
            this.lblDoc0101.BackColor = System.Drawing.Color.Transparent;
            this.lblDoc0101.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.lblDoc0101.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDoc0101.Location = new System.Drawing.Point(538, 51);
            this.lblDoc0101.Name = "lblDoc0101";
            this.lblDoc0101.Size = new System.Drawing.Size(46, 20);
            this.lblDoc0101.TabIndex = 2;
            this.lblDoc0101.Text = "諸証明";
            this.lblDoc0101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDoc0101.Visible = false;
            // 
            // pnlPabox
            // 
            this.pnlPabox.Controls.Add(this.label1);
            this.pnlPabox.Controls.Add(this.cboUse);
            this.pnlPabox.Controls.Add(this.paBox);
            this.pnlPabox.Controls.Add(this.cboDoc0101);
            this.pnlPabox.Location = new System.Drawing.Point(3, 46);
            this.pnlPabox.Name = "pnlPabox";
            this.pnlPabox.Size = new System.Drawing.Size(1178, 31);
            this.pnlPabox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(536, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "使用区分";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboUse
            // 
            this.cboUse.Location = new System.Drawing.Point(614, 5);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(121, 21);
            this.cboUse.TabIndex = 118;
            this.cboUse.SelectionChangeCommitted += new System.EventHandler(this.cboUse_SelectionChangeCommitted);
            // 
            // paBox
            // 
            this.paBox.Location = new System.Drawing.Point(3, 1);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(528, 30);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // cboDoc0101
            // 
            this.cboDoc0101.Location = new System.Drawing.Point(624, 5);
            this.cboDoc0101.Name = "cboDoc0101";
            this.cboDoc0101.Size = new System.Drawing.Size(121, 21);
            this.cboDoc0101.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDoc0101.TabIndex = 119;
            this.cboDoc0101.UserSQL = resources.GetString("cboDoc0101.UserSQL");
            this.cboDoc0101.Visible = false;
            // 
            // calDate
            // 
            this.calDate.EnableMultiSelection = false;
            this.calDate.FullHolidaySelectable = true;
            this.calDate.IsJapanYearType = true;
            this.calDate.Location = new System.Drawing.Point(535, 81);
            this.calDate.MaxDate = new System.DateTime(2016, 7, 18, 0, 0, 0, 0);
            this.calDate.MinDate = new System.DateTime(1996, 7, 18, 0, 0, 0, 0);
            this.calDate.Name = "calDate";
            this.calDate.Size = new System.Drawing.Size(174, 179);
            this.calDate.TabIndex = 4;
            this.calDate.Visible = false;
            this.calDate.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calDate_DaySelected);
            // 
            // dpbGwa
            // 
            this.dpbGwa.Location = new System.Drawing.Point(758, 44);
            this.dpbGwa.Name = "dpbGwa";
            this.dpbGwa.Size = new System.Drawing.Size(101, 21);
            this.dpbGwa.TabIndex = 4;
            this.dpbGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dpbGwa.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnListUpdate);
            this.pnlBottom.Controls.Add(this.btnZoomIn);
            this.pnlBottom.Controls.Add(this.dbxZoom);
            this.pnlBottom.Controls.Add(this.btnZoomOut);
            this.pnlBottom.Controls.Add(this.btnEMR);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnEmrOpen);
            this.pnlBottom.Controls.Add(this.grdImage);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 554);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBottom.Size = new System.Drawing.Size(1181, 36);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnListUpdate
            // 
            this.btnListUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnListUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnListUpdate.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnListUpdate.Location = new System.Drawing.Point(528, 3);
            this.btnListUpdate.Name = "btnListUpdate";
            this.btnListUpdate.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnListUpdate.Size = new System.Drawing.Size(163, 30);
            this.btnListUpdate.TabIndex = 15;
            this.btnListUpdate.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListUpdate_ButtonClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.Location = new System.Drawing.Point(955, 5);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(26, 26);
            this.btnZoomIn.TabIndex = 14;
            this.btnZoomIn.Visible = false;
            // 
            // dbxZoom
            // 
            this.dbxZoom.EditMaskType = IHIS.Framework.MaskType.Number;
            this.dbxZoom.GeneralNumberFormat = true;
            this.dbxZoom.Location = new System.Drawing.Point(886, 6);
            this.dbxZoom.Name = "dbxZoom";
            this.dbxZoom.Size = new System.Drawing.Size(68, 24);
            this.dbxZoom.TabIndex = 13;
            this.dbxZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dbxZoom.Visible = false;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.Location = new System.Drawing.Point(859, 5);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(26, 26);
            this.btnZoomOut.TabIndex = 12;
            this.btnZoomOut.Visible = false;
            // 
            // btnEMR
            // 
            this.btnEMR.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEMR.ImageIndex = 8;
            this.btnEMR.ImageList = this.ImageList;
            this.btnEMR.Location = new System.Drawing.Point(202, 3);
            this.btnEMR.Name = "btnEMR";
            this.btnEMR.Size = new System.Drawing.Size(90, 30);
            this.btnEMR.TabIndex = 10;
            this.btnEMR.Text = "EMR";
            this.btnEMR.Visible = false;
            this.btnEMR.Click += new System.EventHandler(this.btnEMR_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrint.ImageIndex = 9;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Location = new System.Drawing.Point(112, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "印刷";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEmrOpen
            // 
            this.btnEmrOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEmrOpen.ImageIndex = 13;
            this.btnEmrOpen.ImageList = this.ImageList;
            this.btnEmrOpen.Location = new System.Drawing.Point(3, 3);
            this.btnEmrOpen.Name = "btnEmrOpen";
            this.btnEmrOpen.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnEmrOpen.Size = new System.Drawing.Size(109, 30);
            this.btnEmrOpen.TabIndex = 8;
            this.btnEmrOpen.Text = "カルテ";
            this.btnEmrOpen.Visible = false;
            // 
            // grdImage
            // 
            this.grdImage.CallerID = '2';
            this.grdImage.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell43,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51});
            this.grdImage.ColPerLine = 7;
            this.grdImage.Cols = 7;
            this.grdImage.FixedRows = 1;
            this.grdImage.HeaderHeights.Add(21);
            this.grdImage.Location = new System.Drawing.Point(278, 12);
            this.grdImage.Name = "grdImage";
            this.grdImage.QuerySQL = "SELECT FKDOC1001,\r\n           IMG_PATH1,\r\n           IMG_PATH2\r\n      FROM DOC200" +
                "2\r\n     WHERE HOSP_CODE = :f_hosp_code\r\n       AND FKDOC1001 = :f_fkdoc1001";
            this.grdImage.ReadOnly = true;
            this.grdImage.Rows = 2;
            this.grdImage.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdImage.Size = new System.Drawing.Size(576, 154);
            this.grdImage.TabIndex = 7;
            this.grdImage.Visible = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "fkdoc1001";
            this.xEditGridCell46.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell46.HeaderText = "fkdoc1001";
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "image1";
            this.xEditGridCell47.CellType = IHIS.Framework.XCellDataType.Binary;
            this.xEditGridCell47.Col = 1;
            this.xEditGridCell47.HeaderText = "image1";
            this.xEditGridCell47.IsReadOnly = true;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "image2";
            this.xEditGridCell43.CellType = IHIS.Framework.XCellDataType.Binary;
            this.xEditGridCell43.Col = 2;
            this.xEditGridCell43.HeaderText = "image2";
            this.xEditGridCell43.IsReadOnly = true;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "imgext1";
            this.xEditGridCell48.Col = 3;
            this.xEditGridCell48.HeaderText = "imgext1";
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "imgext2";
            this.xEditGridCell49.Col = 4;
            this.xEditGridCell49.HeaderText = "imgext2";
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "imglen1";
            this.xEditGridCell50.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell50.Col = 5;
            this.xEditGridCell50.HeaderText = "imglen1";
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "imglen2";
            this.xEditGridCell51.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell51.Col = 6;
            this.xEditGridCell51.HeaderText = "imglen2";
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Location = new System.Drawing.Point(691, 3);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 30);
            this.btnList.TabIndex = 11;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdDOC2001
            // 
            this.grdDOC2001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell28,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell39,
            this.xEditGridCell40});
            this.grdDOC2001.ColPerLine = 17;
            this.grdDOC2001.Cols = 17;
            this.grdDOC2001.FixedRows = 1;
            this.grdDOC2001.HeaderHeights.Add(24);
            this.grdDOC2001.Location = new System.Drawing.Point(14, 412);
            this.grdDOC2001.Name = "grdDOC2001";
            this.grdDOC2001.QuerySQL = resources.GetString("grdDOC2001.QuerySQL");
            this.grdDOC2001.ReadOnly = true;
            this.grdDOC2001.Rows = 2;
            this.grdDOC2001.Size = new System.Drawing.Size(1000, 100);
            this.grdDOC2001.TabIndex = 1;
            this.grdDOC2001.Visible = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 9;
            this.xEditGridCell19.CellName = "bunho";
            this.xEditGridCell19.HeaderText = "환자번호";
            this.xEditGridCell19.IsUpdatable = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "fkdoc1001";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.Col = 1;
            this.xEditGridCell20.HeaderText = "제증명키";
            this.xEditGridCell20.IsUpdatable = false;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellLen = 3;
            this.xEditGridCell28.CellName = "cert_jncd";
            this.xEditGridCell28.Col = 9;
            this.xEditGridCell28.HeaderText = "제증명코드";
            this.xEditGridCell28.IsUpdatable = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "gwa";
            this.xEditGridCell21.Col = 2;
            this.xEditGridCell21.HeaderText = "진료과";
            this.xEditGridCell21.IsUpdatable = false;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "cert_rqdt";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.Col = 3;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell22.HeaderText = "요청일자";
            this.xEditGridCell22.IsUpdatable = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "cert_seqn";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell23.Col = 4;
            this.xEditGridCell23.HeaderText = "순번";
            this.xEditGridCell23.InitValue = "1";
            this.xEditGridCell23.IsUpdatable = false;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 20;
            this.xEditGridCell24.CellName = "cert_colm";
            this.xEditGridCell24.Col = 5;
            this.xEditGridCell24.HeaderText = "컬럼명";
            this.xEditGridCell24.IsUpdatable = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "cert_pgno";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell25.Col = 6;
            this.xEditGridCell25.HeaderText = "페이지번호";
            this.xEditGridCell25.InitValue = "1";
            this.xEditGridCell25.IsUpdatable = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellLen = 2000;
            this.xEditGridCell26.CellName = "cert_info";
            this.xEditGridCell26.Col = 7;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell26.HeaderText = "입력정보";
            this.xEditGridCell26.IsUpdatable = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "cert_wrdt";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.Col = 8;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell27.HeaderText = "작성일자";
            this.xEditGridCell27.IsUpdatable = false;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 1;
            this.xEditGridCell29.CellName = "upd_gubun";
            this.xEditGridCell29.Col = 10;
            this.xEditGridCell29.HeaderText = "저장구분";
            this.xEditGridCell29.IsUpdatable = false;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 1;
            this.xEditGridCell30.CellName = "cert_iogb";
            this.xEditGridCell30.Col = 11;
            this.xEditGridCell30.HeaderText = "입원외래구분";
            this.xEditGridCell30.IsUpdatable = false;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 4;
            this.xEditGridCell31.CellName = "ho_dong";
            this.xEditGridCell31.Col = 12;
            this.xEditGridCell31.HeaderText = "병동";
            this.xEditGridCell31.IsUpdatable = false;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "fkinp1001";
            this.xEditGridCell32.Col = 13;
            this.xEditGridCell32.HeaderText = "입원키";
            this.xEditGridCell32.IsUpdatable = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellLen = 30;
            this.xEditGridCell33.CellName = "fkout1001";
            this.xEditGridCell33.Col = 14;
            this.xEditGridCell33.HeaderText = "외래키";
            this.xEditGridCell33.IsUpdatable = false;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellLen = 100;
            this.xEditGridCell39.CellName = "img_path1";
            this.xEditGridCell39.Col = 15;
            this.xEditGridCell39.HeaderText = "path1";
            this.xEditGridCell39.IsUpdatable = false;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellLen = 100;
            this.xEditGridCell40.CellName = "img_path2";
            this.xEditGridCell40.Col = 16;
            this.xEditGridCell40.HeaderText = "path2";
            this.xEditGridCell40.IsUpdatable = false;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "img_path1";
            this.xEditGridCell44.CellType = IHIS.Framework.XCellDataType.Binary;
            this.xEditGridCell44.Col = 1;
            this.xEditGridCell44.HeaderText = "img_path1";
            this.xEditGridCell44.IsReadOnly = true;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "img_path2";
            this.xEditGridCell45.CellType = IHIS.Framework.XCellDataType.Binary;
            this.xEditGridCell45.Col = 2;
            this.xEditGridCell45.HeaderText = "img_path2";
            this.xEditGridCell45.IsReadOnly = true;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlInp);
            this.pnlLeft.Controls.Add(this.xPanel2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.DrawBorder = true;
            this.pnlLeft.Location = new System.Drawing.Point(0, 84);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(271, 470);
            this.pnlLeft.TabIndex = 2;
            // 
            // pnlInp
            // 
            this.pnlInp.Controls.Add(this.tvwDOC2001);
            this.pnlInp.Controls.Add(this.grdToiwonList);
            this.pnlInp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInp.Location = new System.Drawing.Point(0, 35);
            this.pnlInp.Name = "pnlInp";
            this.pnlInp.Size = new System.Drawing.Size(269, 433);
            this.pnlInp.TabIndex = 18;
            // 
            // tvwDOC2001
            // 
            this.tvwDOC2001.AllowDrop = true;
            this.tvwDOC2001.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Window);
            this.tvwDOC2001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDOC2001.HideSelection = false;
            this.tvwDOC2001.HotTracking = true;
            this.tvwDOC2001.ImageIndex = 18;
            this.tvwDOC2001.ImageList = this.ImageList;
            this.tvwDOC2001.Location = new System.Drawing.Point(0, 160);
            this.tvwDOC2001.Name = "tvwDOC2001";
            this.tvwDOC2001.SelectedImageIndex = 17;
            this.tvwDOC2001.Size = new System.Drawing.Size(269, 273);
            this.tvwDOC2001.TabIndex = 15;
            this.tvwDOC2001.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDOC2001_AfterSelect);
            this.tvwDOC2001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwDOC2001_MouseDown);
            // 
            // grdToiwonList
            // 
            this.grdToiwonList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68});
            this.grdToiwonList.ColPerLine = 2;
            this.grdToiwonList.Cols = 3;
            this.grdToiwonList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdToiwonList.FixedCols = 1;
            this.grdToiwonList.FixedRows = 1;
            this.grdToiwonList.HeaderHeights.Add(21);
            this.grdToiwonList.Location = new System.Drawing.Point(0, 0);
            this.grdToiwonList.Name = "grdToiwonList";
            this.grdToiwonList.QuerySQL = resources.GetString("grdToiwonList.QuerySQL");
            this.grdToiwonList.ReadOnly = true;
            this.grdToiwonList.RowHeaderVisible = true;
            this.grdToiwonList.Rows = 2;
            this.grdToiwonList.Size = new System.Drawing.Size(269, 160);
            this.grdToiwonList.TabIndex = 16;
            this.grdToiwonList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdToiwonList_QueryStarting);
            this.grdToiwonList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdToiwonList_RowFocusChanged);
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "ipwon_date";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell62.CellWidth = 104;
            this.xEditGridCell62.Col = 1;
            this.xEditGridCell62.HeaderText = "入院日付";
            this.xEditGridCell62.IsJapanYearType = true;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "toiwon_date";
            this.xEditGridCell63.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell63.CellWidth = 104;
            this.xEditGridCell63.Col = 2;
            this.xEditGridCell63.HeaderText = "退院日付";
            this.xEditGridCell63.IsJapanYearType = true;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "bunho";
            this.xEditGridCell64.CellWidth = 120;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.HeaderText = "患者番号";
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            this.xEditGridCell64.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "suname";
            this.xEditGridCell65.CellWidth = 120;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.HeaderText = "患者氏名";
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "pkinp1001";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.HeaderText = "pkinp1001";
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "ho_dong";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.HeaderText = "HO_DONG1";
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "ho_code";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.HeaderText = "HO_CODE1";
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.rbnOutData);
            this.xPanel2.Controls.Add(this.rbnInData);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(269, 35);
            this.xPanel2.TabIndex = 19;
            // 
            // rbnOutData
            // 
            this.rbnOutData.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnOutData.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbnOutData.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnOutData.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbnOutData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnOutData.ImageIndex = 15;
            this.rbnOutData.ImageList = this.ImageList;
            this.rbnOutData.Location = new System.Drawing.Point(135, 1);
            this.rbnOutData.Name = "rbnOutData";
            this.rbnOutData.Size = new System.Drawing.Size(135, 32);
            this.rbnOutData.TabIndex = 2;
            this.rbnOutData.Tag = "O";
            this.rbnOutData.Text = "外来";
            this.rbnOutData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnOutData.UseVisualStyleBackColor = false;
            this.rbnOutData.CheckedChanged += new System.EventHandler(this.rbnDataGubun_CheckedChanged);
            // 
            // rbnInData
            // 
            this.rbnInData.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnInData.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnInData.Checked = true;
            this.rbnInData.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnInData.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnInData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnInData.ImageIndex = 16;
            this.rbnInData.ImageList = this.ImageList;
            this.rbnInData.Location = new System.Drawing.Point(2, 1);
            this.rbnInData.Name = "rbnInData";
            this.rbnInData.Size = new System.Drawing.Size(133, 32);
            this.rbnInData.TabIndex = 3;
            this.rbnInData.TabStop = true;
            this.rbnInData.Tag = "I";
            this.rbnInData.Text = "入院";
            this.rbnInData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnInData.UseVisualStyleBackColor = false;
            this.rbnInData.CheckedChanged += new System.EventHandler(this.rbnDataGubun_CheckedChanged);
            // 
            // gbxCert_rqin
            // 
            this.gbxCert_rqin.Controls.Add(this.grdCert_rqin);
            this.gbxCert_rqin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxCert_rqin.Location = new System.Drawing.Point(377, 15);
            this.gbxCert_rqin.Name = "gbxCert_rqin";
            this.gbxCert_rqin.Size = new System.Drawing.Size(70, 129);
            this.gbxCert_rqin.TabIndex = 1;
            this.gbxCert_rqin.TabStop = false;
            this.gbxCert_rqin.Text = "諸証明要請件";
            this.gbxCert_rqin.Visible = false;
            // 
            // grdCert_rqin
            // 
            this.grdCert_rqin.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell16,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell12,
            this.xEditGridCell17,
            this.xEditGridCell18});
            this.grdCert_rqin.ColPerLine = 4;
            this.grdCert_rqin.Cols = 4;
            this.grdCert_rqin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCert_rqin.FixedRows = 1;
            this.grdCert_rqin.HeaderHeights.Add(21);
            this.grdCert_rqin.Location = new System.Drawing.Point(3, 16);
            this.grdCert_rqin.Name = "grdCert_rqin";
            this.grdCert_rqin.QuerySQL = resources.GetString("grdCert_rqin.QuerySQL");
            this.grdCert_rqin.ReadOnly = true;
            this.grdCert_rqin.Rows = 2;
            this.grdCert_rqin.Size = new System.Drawing.Size(64, 110);
            this.grdCert_rqin.TabIndex = 0;
            this.grdCert_rqin.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCert_rqin_QueryStarting);
            this.grdCert_rqin.Click += new System.EventHandler(this.grdCert_rqin_Click);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "bunho";
            this.xEditGridCell11.CellWidth = 90;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "患者番号";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "pkdoc1001";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "제증명키";
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "cert_jncd";
            this.xEditGridCell13.CellWidth = 130;
            this.xEditGridCell13.Col = 1;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell13.HeaderText = "諸証明";
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "gwa";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "診療科";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gwa_name";
            this.xEditGridCell15.CellWidth = 90;
            this.xEditGridCell15.Col = 2;
            this.xEditGridCell15.HeaderText = "診療科";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "cert_rqdt";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.CellWidth = 110;
            this.xEditGridCell12.HeaderText = "要請日付";
            this.xEditGridCell12.IsJapanYearType = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "cert_seqn";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "순번";
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "cert_rqnu";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell18.CellWidth = 53;
            this.xEditGridCell18.Col = 3;
            this.xEditGridCell18.HeaderText = "要請枚数";
            // 
            // gbxPast_cert
            // 
            this.gbxPast_cert.Controls.Add(this.gbxCert_rqin);
            this.gbxPast_cert.Controls.Add(this.grdCert_past);
            this.gbxPast_cert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxPast_cert.Location = new System.Drawing.Point(19, 185);
            this.gbxPast_cert.Name = "gbxPast_cert";
            this.gbxPast_cert.Size = new System.Drawing.Size(605, 278);
            this.gbxPast_cert.TabIndex = 0;
            this.gbxPast_cert.TabStop = false;
            this.gbxPast_cert.Text = "諸証明過去歴";
            this.gbxPast_cert.Visible = false;
            // 
            // grdCert_past
            // 
            this.grdCert_past.AddedHeaderLine = 1;
            this.grdCert_past.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell61,
            this.xEditGridCell4,
            this.xEditGridCell10,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60});
            this.grdCert_past.ColPerLine = 27;
            this.grdCert_past.Cols = 28;
            this.grdCert_past.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCert_past.FixedCols = 1;
            this.grdCert_past.FixedRows = 2;
            this.grdCert_past.HeaderHeights.Add(21);
            this.grdCert_past.HeaderHeights.Add(2);
            this.grdCert_past.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdCert_past.Location = new System.Drawing.Point(3, 16);
            this.grdCert_past.Name = "grdCert_past";
            this.grdCert_past.QuerySQL = resources.GetString("grdCert_past.QuerySQL");
            this.grdCert_past.ReadOnly = true;
            this.grdCert_past.RowHeaderVisible = true;
            this.grdCert_past.Rows = 3;
            this.grdCert_past.Size = new System.Drawing.Size(599, 259);
            this.grdCert_past.TabIndex = 0;
            this.grdCert_past.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdCert_past_QueryEnd);
            this.grdCert_past.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdCert_past_QueryStarting);
            this.grdCert_past.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdCert_past_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = 7;
            this.xEditGridCell1.HeaderText = "患者番号";
            this.xEditGridCell1.Row = 1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkdoc1001";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.Col = 6;
            this.xEditGridCell2.HeaderText = "제증명키";
            this.xEditGridCell2.Row = 1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "cert_jncd";
            this.xEditGridCell3.CellWidth = 140;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.HeaderText = "諸証明";
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell3.UserSQL = "SELECT A.CERT_JNCD CERT_JNCD \r\n      ,A.CERT_JNNM CERT_JNNM  \r\n      FROM DOC0101" +
                " A\r\n     WHERE A.CERT_VALD = \'Y\'\r\n       --AND A.CERT_RQGB = \'I\'\r\n     ORDER BY " +
                "2";
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "cert_jnnm";
            this.xEditGridCell61.Col = 8;
            this.xEditGridCell61.HeaderText = "cert_jnnm";
            this.xEditGridCell61.Row = 1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa";
            this.xEditGridCell4.Col = 9;
            this.xEditGridCell4.HeaderText = "診療科";
            this.xEditGridCell4.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "gwa_name";
            this.xEditGridCell10.CellWidth = 110;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.HeaderText = "診療科";
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "cert_rqdt";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = 10;
            this.xEditGridCell5.HeaderText = "要請日付";
            this.xEditGridCell5.Row = 1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "cert_seqn";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.Col = 11;
            this.xEditGridCell6.HeaderText = "順番";
            this.xEditGridCell6.Row = 1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "cert_wrdt";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 74;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell7.HeaderText = "作成日付";
            this.xEditGridCell7.IsJapanYearType = true;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "cert_wrid";
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.HeaderText = "作成者";
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "cert_wrid_nm";
            this.xEditGridCell9.CellWidth = 110;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.HeaderText = "作成者名";
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "cert_iogb";
            this.xEditGridCell34.Col = 12;
            this.xEditGridCell34.HeaderText = "입원외래구분";
            this.xEditGridCell34.Row = 1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "fkinp1001";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell35.Col = 13;
            this.xEditGridCell35.HeaderText = "입원키";
            this.xEditGridCell35.Row = 1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellLen = 30;
            this.xEditGridCell36.CellName = "fkout1001";
            this.xEditGridCell36.Col = 14;
            this.xEditGridCell36.HeaderText = "외래키";
            this.xEditGridCell36.Row = 1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "ho_dong";
            this.xEditGridCell37.Col = 15;
            this.xEditGridCell37.HeaderText = "병동";
            this.xEditGridCell37.Row = 1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "cert_prgb";
            this.xEditGridCell38.Col = 16;
            this.xEditGridCell38.HeaderText = "출력구분";
            this.xEditGridCell38.Row = 1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 100;
            this.xEditGridCell41.CellName = "path1";
            this.xEditGridCell41.Col = 17;
            this.xEditGridCell41.HeaderText = "path1";
            this.xEditGridCell41.Row = 1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellLen = 100;
            this.xEditGridCell42.CellName = "path2";
            this.xEditGridCell42.Col = 18;
            this.xEditGridCell42.HeaderText = "path2";
            this.xEditGridCell42.Row = 1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "piclen1";
            this.xEditGridCell52.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell52.Col = 19;
            this.xEditGridCell52.HeaderText = "piclen1";
            this.xEditGridCell52.Row = 1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "piclen2";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = 20;
            this.xEditGridCell53.HeaderText = "piclen2";
            this.xEditGridCell53.Row = 1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "cert_iuse";
            this.xEditGridCell54.Col = 21;
            this.xEditGridCell54.HeaderText = "CERT_IUSE";
            this.xEditGridCell54.Row = 1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "cert_ouse";
            this.xEditGridCell55.Col = 22;
            this.xEditGridCell55.HeaderText = "CERT_OUSE";
            this.xEditGridCell55.Row = 1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "cert_euse";
            this.xEditGridCell56.Col = 23;
            this.xEditGridCell56.HeaderText = "CERT_EUSE";
            this.xEditGridCell56.Row = 1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "data_win";
            this.xEditGridCell57.Col = 24;
            this.xEditGridCell57.HeaderText = "DATA_WIN";
            this.xEditGridCell57.Row = 1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "select";
            this.xEditGridCell58.Col = 25;
            this.xEditGridCell58.HeaderText = "select";
            this.xEditGridCell58.Row = 1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "node1";
            this.xEditGridCell59.Col = 26;
            this.xEditGridCell59.HeaderText = "node1";
            this.xEditGridCell59.Row = 1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "node2";
            this.xEditGridCell60.Col = 27;
            this.xEditGridCell60.HeaderText = "node2";
            this.xEditGridCell60.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 4;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "作成者";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.gbxPast_cert);
            this.pnlFill.Controls.Add(this.dpbGwa);
            this.pnlFill.Controls.Add(this.calDate);
            this.pnlFill.Controls.Add(this.grdDOC2001);
            this.pnlFill.Controls.Add(this.dwDoc2001u00);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Location = new System.Drawing.Point(271, 84);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(910, 470);
            this.pnlFill.TabIndex = 3;
            // 
            // dwDoc2001u00
            // 
            this.dwDoc2001u00.DataWindowObject = "dw_doc2001u01";
            this.dwDoc2001u00.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwDoc2001u00.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.dwDoc2001u00.LibraryList = "..\\DOCS\\docs.doc2001u00.pbd";
            this.dwDoc2001u00.Location = new System.Drawing.Point(0, 0);
            this.dwDoc2001u00.Name = "dwDoc2001u00";
            this.dwDoc2001u00.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwDoc2001u00.Size = new System.Drawing.Size(908, 468);
            this.dwDoc2001u00.TabIndex = 1;
            this.dwDoc2001u00.Text = "xDataWindow1";
            this.dwDoc2001u00.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dwDoc2001u00_MouseDown);
            this.dwDoc2001u00.DataWindowKeyDown += new Sybase.DataWindow.DataWindowKeyDownEventHandler(this.dwDoc2001u00_DataWindowKeyDown);
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboSet.QuerySQL = "SELECT A.CERT_JNCD CERT_JNCD \r\n      ,A.CERT_JNNM CERT_JNNM \r\n      FROM DOC0101 " +
                "A\r\n     WHERE A.CERT_VALD = \'Y\'\r\n       AND A.CERT_RQGB = \'I\'\r\n     ORDER BY 2";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "CERT_JNCD";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "CERT_JNNM";
            // 
            // layToiwonBaseInfo
            // 
            this.layToiwonBaseInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem13,
            this.singleLayoutItem14,
            this.singleLayoutItem15,
            this.singleLayoutItem42,
            this.singleLayoutItem1,
            this.singleLayoutItem3});
            this.layToiwonBaseInfo.QuerySQL = resources.GetString("layToiwonBaseInfo.QuerySQL");
            this.layToiwonBaseInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layToiwonBaseInfo_QueryStarting);
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "ipwon_date";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "toiwon_date";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "ho_dong";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "ho_code";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "sang_name";
            // 
            // singleLayoutItem42
            // 
            this.singleLayoutItem42.DataName = "jaewon_flag";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "jisi_doctor_name";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "gwa_name";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "suname";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "address";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "sex";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "tel";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "birth";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "ipwon_date";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "toiwon_date";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "age";
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.DataName = "ho_dong";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.DataName = "ho_code";
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.DataName = "sang_name";
            // 
            // layCert_wrdt
            // 
            this.layCert_wrdt.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem12,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18,
            this.singleLayoutItem19,
            this.singleLayoutItem20,
            this.singleLayoutItem21,
            this.singleLayoutItem22});
            this.layCert_wrdt.QuerySQL = resources.GetString("layCert_wrdt.QuerySQL");
            // 
            // layHospInfo
            // 
            this.layHospInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem23,
            this.singleLayoutItem28,
            this.singleLayoutItem24,
            this.singleLayoutItem25,
            this.singleLayoutItem26,
            this.singleLayoutItem27,
            this.singleLayoutItem29});
            this.layHospInfo.QuerySQL = resources.GetString("layHospInfo.QuerySQL");
            this.layHospInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHospInfo_QueryStarting);
            // 
            // singleLayoutItem23
            // 
            this.singleLayoutItem23.DataName = "zip_code";
            // 
            // singleLayoutItem28
            // 
            this.singleLayoutItem28.DataName = "yoyang_name";
            // 
            // singleLayoutItem24
            // 
            this.singleLayoutItem24.DataName = "hosp_address";
            // 
            // singleLayoutItem25
            // 
            this.singleLayoutItem25.DataName = "fax";
            // 
            // singleLayoutItem26
            // 
            this.singleLayoutItem26.DataName = "hosp_tel";
            // 
            // singleLayoutItem27
            // 
            this.singleLayoutItem27.DataName = "jaedan_name";
            // 
            // singleLayoutItem29
            // 
            this.singleLayoutItem29.DataName = "simple_yoyang_name";
            // 
            // layDocInfo
            // 
            this.layDocInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem41,
            this.singleLayoutItem37,
            this.singleLayoutItem38,
            this.singleLayoutItem30,
            this.singleLayoutItem31,
            this.singleLayoutItem32,
            this.singleLayoutItem33,
            this.singleLayoutItem34,
            this.singleLayoutItem35,
            this.singleLayoutItem36,
            this.singleLayoutItem2});
            this.layDocInfo.QuerySQL = resources.GetString("layDocInfo.QuerySQL");
            // 
            // singleLayoutItem41
            // 
            this.singleLayoutItem41.DataName = "cert_jncd";
            // 
            // singleLayoutItem37
            // 
            this.singleLayoutItem37.DataName = "cert_euse";
            // 
            // singleLayoutItem38
            // 
            this.singleLayoutItem38.DataName = "cert_iuse";
            // 
            // singleLayoutItem30
            // 
            this.singleLayoutItem30.DataName = "cert_ouse";
            // 
            // singleLayoutItem31
            // 
            this.singleLayoutItem31.DataName = "cert_rqgb";
            // 
            // singleLayoutItem32
            // 
            this.singleLayoutItem32.DataName = "cert_gubun";
            // 
            // singleLayoutItem33
            // 
            this.singleLayoutItem33.DataName = "cert_vald";
            // 
            // singleLayoutItem34
            // 
            this.singleLayoutItem34.DataName = "cert_wmcd";
            // 
            // singleLayoutItem35
            // 
            this.singleLayoutItem35.DataName = "cert_wuse";
            // 
            // singleLayoutItem36
            // 
            this.singleLayoutItem36.DataName = "data_win";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "cert_jnnm";
            // 
            // layNurPlan
            // 
            this.layNurPlan.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3});
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "NUR_PLAN_NAME";
            // 
            // DOC2001U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "DOC2001U00";
            this.Size = new System.Drawing.Size(1181, 590);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DOC2001U00_Closing);
            this.UserChanged += new System.EventHandler(this.DOC2001U00_UserChanged);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboGwa)).EndInit();
            this.pnlPabox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDate)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDOC2001)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlInp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdToiwonList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.gbxCert_rqin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCert_rqin)).EndInit();
            this.gbxPast_cert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCert_past)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNurPlan)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "user_gwa":
					msg = (NetInfo.Language == LangMode.Ko ? "로그인한 유저의 진료과 정보가 없습니다."
						: "ログインしたユーザの診療科情報がありません。");
					caption = (NetInfo.Language == LangMode.Ko ? "확인"
						: "`確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + " 환자번호를 확인해 주세요"
						: "在院中の患者様ではありません. 患者番号を確認してください.");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bunho":
					msg = (NetInfo.Language == LangMode.Ko ? " 환자번호를 확인해 주세요"
						: "患者番号を確認してください.");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    this.paBox.Focus();
					break;
				case "user_check":
					msg = (NetInfo.Language == LangMode.Ko ? "제증명의 사용권한은 의사에게만 있습니다."
						: "諸証明の使用権限はドクターだけがあります.");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "cert_jncd":
					msg = (NetInfo.Language == LangMode.Ko ? "제증명종류를 입력하십시오."
						: "諸証明種類を入力してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    this.cboDoc0101.Focus();
					break;
				case "cert_rqnu":
					msg = (NetInfo.Language == LangMode.Ko ? "제증명요청매수를 입력하십시오."
						: "諸証明の要請枚数を入力してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "patientbase":
					msg = (NetInfo.Language == LangMode.Ko ? "제증명을 작성을 할 수 없는 환자입니다."
						: "諸証明の作成が出来ない患者です。");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "pkdoc1001":
					msg = (NetInfo.Language == LangMode.Ko ? "제증명요청건에서 선택을 해 주세요."
						: "諸証明要請件で選択してください.");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "past":
					msg = (NetInfo.Language == LangMode.Ko ? "다른 종류의 제증명을 선택을 하셨습니다." +"\r\n" +
						"같은 종류의 제증명만이 제증명과거력을 통해서 조회가 가능합니다."
						: "他の種類の諸証明を選択しました。" + "\r\n" +"同じ種類の諸証明のみ諸証明過去歴によって照会することが出来ます。");
                    caption = (NetInfo.Language == LangMode.Ko ? "확인"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "print_err":
					msg = (NetInfo.Language == LangMode.Ko ? "저장을 먼저해 주십시오."
						: "先に保存を行ってください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "close":
					msg = (NetInfo.Language == LangMode.Ko ? "해당 화면에 사용권한이 없는 사용자입니다. 확인하십시요."
						: "該当画面に使用権限がない使用者です。ご確認下さい。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "確認");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
                    msg = NetInfo.Language == LangMode.Ko ? "저장완료" : "正常に終了しました。";
					caption = NetInfo.Language == LangMode.Ko ? "저장완료" : "保存完了";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました. 確認願います..";
                    //msg += "\r\n[" + this.dsvUpdate.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "エラー";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
                case "save_emr_true":
                    msg = NetInfo.Language == LangMode.Ko ? "전송완료" : "正常に転送しました。";
                    caption = NetInfo.Language == LangMode.Ko ? "전송완료" : "転送完了";
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "save_emr_false":
                    msg = NetInfo.Language == LangMode.Ko ? "전송 실패하였습니다. 확인바랍니다."
                        : "転送に失敗しました. 確認願います。";
                    //msg += "\r\n[" + this.dsvUpdate.ErrFullMsg + "]";
                    caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "エラー";
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    break;
				default:
					break;
			}
		}
		#endregion 

        #region 스크린 로드
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grdDOC2001.SavePerformer = new XSavePerformer(this);
            this.grdImage.SavePerformer = this.grdDOC2001.SavePerformer;
            PostCallHelper.PostCall(new PostMethod(PostLoad));
            //dbxZoom.SetDataValue("100");
            this.paBox.Focus();
            if (this.cboUse.ComboItems.Count > 0)
            {
                this.cboUse.SelectedIndex = 0;
            }
        }

        private void PostLoad()
        {
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            if (this.Opener is IHIS.Framework.MdiForm &&
                (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(this.Width, rc.Height - 105);
                this.btnListUpdate.Visible = false;
                this.btnList.Visible = true;
            }
            else
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(this.Width, rc.Height - 105);
                this.btnListUpdate.Visible = false;
                this.btnList.Visible = true;
            }

            // 콤보박스 유저과 셋팅
            // 유저과가 없으면 기본 셋팅
            for (int i = 0; i < cboGwa.Items.Count; i++)
            {
                if (cboGwa.ComboItems[i].ValueItem == UserInfo.Gwa)
                    this.cboGwa.SetDataValue(UserInfo.Gwa);
            }

            this.MakeCombo();

            if (this.Opener != null &&
                this.Opener is XScreen &&
                this.OpenParam != null)
            {
                XScreen screen = (XScreen)this.Opener;

                string cert_jncd = "";

                switch (screen.Name)
                {
                    case "INP1003U01":
                        cert_jncd = "010";
                        this.pnlLeft.Visible = false;
                        break;
                    case "NUR1020Q00":
                        cert_jncd = "009";
                        //this.pnlLeft.Visible = false;
                        break;
                }
                this.cboDoc0101.SetDataValue(cert_jncd);
                if (this.OpenParam.Contains("acting_date"))
                {
                    this.dtpCert_wrdt.SetDataValue(this.OpenParam["acting_date"].ToString());
                }
                else
                {
                    this.dtpCert_wrdt.SetDataValue(EnvironInfo.GetSysDate());
                }

                if (this.OpenParam.Contains("fkinp1001"))
                {
                    this.fkinp1001 = this.OpenParam["fkinp1001"].ToString();
                }
                
                if (this.OpenParam.Contains("cert_jncd"))
                {
                    cert_jncd = this.OpenParam["cert_jncd"].ToString();
                    
                }
                this.cboGwa.Protect = true;
                //this.btnList.PerformClick(FunctionType.Query);
                //if (this.grdCert_past.RowCount <= 0)
                //{
                //    this.btnList.PerformClick(FunctionType.Insert);
                //}                               
                //for (int i = 0; i < this.grdCert_past.RowCount; i++)
                //{
                //    if (this.grdCert_past.GetItemString(i, "cert_jncd") == cert_jncd)
                //    {
                //        this.grdCert_past.SetFocusToItem(i, 1);
                //        break;
                //    }
                //}
                if (this.OpenParam.Contains("bunho"))
                {
                    this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                    this.paBox.Enabled = false;
                }
                this.cboDoc0101.SetDataValue(this.OpenParam["cert_jncd"].ToString());
                //this.btnList.PerformClick(FunctionType.Insert);
                foreach (TreeNode parentNode in this.tvwDOC2001.Nodes)
                {
                    if (parentNode.Tag.ToString() == cert_jncd)
                    {
                        this.tvwDOC2001.SelectedNode = parentNode;
                        this.tvwDOC2001.SelectedNode.Expand();
                        break;
                    }
                    //foreach (TreeNode childNode in parentNode.Nodes)
                    //{
                    //    if (childNode.Tag.ToString() == cert_jncd)
                    //    {
                    //        this.tvwDOC2001.SelectedNode = childNode;
                    //        break;
                    //    }
                    //}
                }
            }
            else
            {
                this.paBox.Enabled = true;
                this.cboDoc0101.Protect = false;
                this.cboGwa.Protect = false;
                // 기본 처음걸로 콤보박스 셋팅 데이터윈도우랑 같이 셋트
                if (cboDoc0101.ComboItems.Count > 0)
                {
                    cboDoc0101.SelectedIndex = 0;
                }
                // 일자 오늘로 셋팅
                this.dtpCert_wrdt.SetDataValue(EnvironInfo.GetSysDate());
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }
        }
        #endregion

        #region 사용자 변경이 있을 때
        private void DOC2001U00_UserChanged(object sender, System.EventArgs e)
        {
            this.PostLoad();
        }
        #endregion

        #region [환자정보 Reques/Receive Event]
        /// <summary>opr50
        /// 
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                //this.bunho = info.BunHo;

                if (this.cboDoc0101.GetDataValue().ToString() == "")
                {
                    this.GetMessage("cert_jncd");
                    return;
                }
                else
                {
                    this.paBox.SetPatientID(info.BunHo);
                }
            }
        }
        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
            }
            return null;
        }
        #endregion

        #region 환자번호를 입력을 했을 때
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.dataLoad();
        }
        #endregion

        #region 작성일자를 변경을 했을 때 와력으로 변환을 하여 데이터 윈도우에 입력
        private void dtpCert_wrdt_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(cboDoc0101.GetDataValue())) return;

            // 입력상태일때만 이력에 동기화시켜준다.
            if (grdCert_past.GetRowState(grdCert_past.CurrentRowNumber) == DataRowState.Added)
            {
                grdCert_past.SetItemValue(grdCert_past.CurrentRowNumber, "cert_wrdt", e.DataValue);

                /* 작성일자를 와력으로 변환을 한다. */
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "cert_wrdt",
                                                japan_date_convert(e.DataValue));
            }
        }
        #endregion
        /* 와력으로 변환을 한다. */
        private string japan_date_convert(string date)
        {
            object retVal = null;
            string japan_date ="";
            
            string strsql = @"SELECT FN_BAS_TO_JAPAN_DATE_CONVERT('1', TO_DATE(:f_cert_wrdt, 'YYYY/MM/DD')) CERT_WRDT
                              FROM DUAL ";

            BindVarCollection item = new BindVarCollection();
            item.Add("f_cert_wrdt", date);
            retVal = Service.ExecuteScalar(strsql, item);
            if (retVal != null)
            {
               japan_date = retVal.ToString();
            }
            return japan_date;
        }

		/// <summary>
		/// 환자가 제증명 작성이 가능한 환자인지를 조회한다.
		/// 제증명 작성이 가능한 환자는 현재 시점에 병원에 재원이나 내원중인 환자만 가능
		/// </summary>
		#region 환자의 기본정보 조회하기(퇴원증명서는 제외)
		private void GetPatientBaseInfo()
		{
	    }
		#endregion

		#region 데이터 윈도우를 셋팅을 한다.
        private void SetDatawindow(string aCertJncd)
		{
            if (this.grdCert_past.CurrentRowNumber < 0)
            {
                return;
            }
            this.layDocInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDocInfo.SetBindVarValue("f_cert_jncd", aCertJncd);
            this.layDocInfo.Reset();

            if (!this.layDocInfo.QueryLayout())
            {
                this.GetMessage("cert_jncd");
                return;
            }

            string data_win = this.layDocInfo.GetItemValue("data_win").ToString();
            if (data_win == "")
            {
                return;
            }
            this.grdCert_past.SetItemValue(grdCert_past.CurrentRowNumber, "cert_iuse", layDocInfo.GetItemValue("cert_iuse").ToString());
            this.grdCert_past.SetItemValue(grdCert_past.CurrentRowNumber, "cert_ouse", layDocInfo.GetItemValue("cert_ouse").ToString());
            this.grdCert_past.SetItemValue(grdCert_past.CurrentRowNumber, "cert_euse", layDocInfo.GetItemValue("cert_euse").ToString());
            this.grdCert_past.SetItemValue(grdCert_past.CurrentRowNumber, "data_win", layDocInfo.GetItemValue("data_win").ToString());
            this.grdCert_past.SetItemValue(grdCert_past.CurrentRowNumber, "cert_jnnm", layDocInfo.GetItemValue("cert_jnnm").ToString());
           	this.grdDOC2001.Reset();
			// 20070705 - Add Start
			this.btnPic1Add.Visible = false;
			this.btnPic1Del.Visible = false;
			this.btnPic2Add.Visible = false;
			this.btnPic2Del.Visible = false;
			
            this.dwDoc2001u00.DataWindowObject = data_win;
            this.dwDoc2001u00.InsertRow(0);
            allItems.Clear();
            //컬럼취득
            for (int i = 1; i <= this.dwDoc2001u00.ColumnCount; i++)
            {
                allItems.Add(this.dwDoc2001u00.Describe("#" + (i).ToString() + ".Name").Trim());
            }
		}
		#endregion

		#region 환자의 제증명 요청건을 조회한다.
		private void GetDoc1001Query()
		{
            this.pnlFill.Enabled = true;
            this.grdCert_rqin.Reset();
            this.grdCert_past.QueryLayout(false);

            if (this.grdCert_rqin.QueryLayout(true))
            {
            }
			
		}
		#endregion

		#region 제증명 요청건에서 선택을 했을 때
		private void grdCert_rqin_Click(object sender, System.EventArgs e)
		{
			if(this.grdCert_rqin.RowCount > 0)
			{
				if(this.grdCert_rqin.CurrentRowNumber >= 0)
				{
					this.pnlFill.Enabled = true;
				}
			}
		}
		#endregion

		#region 진단명을 입력을 할 때 자동 탭 생성
		private void dwDoc2001u00_DataWindowKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			this.dwDoc2001u00.AcceptText();

			if(e.KeyCode == Keys.Enter)
			{
				//this.dwDoc2001u00.DataWindowKeyDown(this, new System.Windows.Forms.KeyEventArgs(Keys.Tab));
				//this.dwDoc2001u00.Scroll(Sybase.DataWindow..ScrollAction.ScrollNextPage);

                if (grdCert_past.CurrentRowNumber < 0) return;

                string column = this.dwDoc2001u00.GetColumnName().ToString();

                if ((column == "ipwon_date") || (column == "toiwon_date"))
                {
                    if ((this.dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, column) == "") &&
                        (this.allItems.Contains("sanjung_gigan")))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sanjung_gigan", "");
                    }
                }
			}
		}
		#endregion

		#region 과거력에서 선택을 했을 때

		#endregion

		#region 파일 FTP 가져오기
		private void GetFTPFile(string strKey)
		{
			this.dwDoc2001u00.Modify("p_1.filename = ''");
			this.dwDoc2001u00.Modify("p_2.filename = ''");
			this.dwDoc2001u00.Refresh();

			if(this.strPic1.Length == 0 && this.strPic2.Length == 0) return;
			
			int row = imgGridRow(strKey);

			bool file1 = false;
			bool file2 = false;

			try
			{
				if(this.strPic1.Length > 0)
				{
					file1 = true;
				}
				if(this.strPic2.Length > 0)
				{
					file2 = true;
				}
				if(file1 == true || file2 == true)
				{
					try
					{
						FtpClient sftp = new FtpClient(EnvironInfo.GetDownloadServerIP(), "medi", "medi0600", 30, 21);
						sftp.Login();
						sftp.BinaryMode = true;
						if(sftp.Logined)
						{
							if(file1 == true)
							{
                                sftp.Download("/MEDI/IHIS/DOCSImages/" + strKey + "-01", "C:\\IHIS\\DOCS\\" + strKey + "-01." + this.strPic1);	
							}

							if(file2 == true)
							{
                                sftp.Download("/MEDI/IHIS/DOCSImages/" + strKey + "-02", "C:\\IHIS\\DOCS\\" + strKey + "-02." + this.strPic2);	
							}
						}
						else
						{
							XMessageBox.Show("FTP : Login Fail");
							sftp.Close();
							return;
						}
						sftp.Close();
					}
					catch(Exception ex)
					{
						//https://sofiamedix.atlassian.net/browse/MED-10610
						//XMessageBox.Show("FTP Error : " + ex.ToString());
						return;
					}
				}
				if(this.strPic1.Length > 0)
				{
                    this.dwDoc2001u00.Modify("p_1.filename = '" + "C:\\IHIS\\DOCS\\" + strKey + "-01." + this.strPic1 + "'");
                    Image image = Image.FromFile("C:\\IHIS\\DOCS\\" + strKey + "-01." + this.strPic1);
                    FileInfo file = new FileInfo("C:\\IHIS\\DOCS\\" + strKey + "-01." + this.strPic1);					
					this.intPic1 = file.Length;					
					this.grdImage.SetItemValue(row, "image1", image);
					this.grdImage.SetItemValue(row, "imgext1", this.strPic1);
					this.grdImage.SetItemValue(row, "imglen1", this.intPic1);
					image.Dispose();
				} 
				if(this.strPic2.Length > 0)
				{
                    this.dwDoc2001u00.Modify("p_2.filename = '" + "C:\\IHIS\\DOCS\\" + strKey + "-02." + this.strPic2 + "'");
                    Image image = Image.FromFile("C:\\IHIS\\DOCS\\" + strKey + "-02." + this.strPic2);
                    FileInfo file = new FileInfo("C:\\IHIS\\DOCS\\" + strKey + "-02." + this.strPic2);
					this.intPic2 = file.Length;
					this.grdImage.SetItemValue(row, "image2", image);
					this.grdImage.SetItemValue(row, "imgext2", this.strPic2);
					this.grdImage.SetItemValue(row, "imglen2", this.intPic2);
					image.Dispose();
				}
			}
			catch(Exception ex)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show(ex.ToString());
			}
		} 
		#endregion

		#region 퇴원증명서에서 퇴원일 설정시 입원기본료 기본셋팅

		private void SetDefaultIpwonRyo ()
		{
            MultiLayout layCommon = new MultiLayout();

            layCommon.QuerySQL = @"SELECT A.CODE
                                         ,A.CODE_NAME
                                    FROM BAS0102 A
                                   WHERE A.HOSP_CODE = :f_hosp_code
                                     AND A.CODE_TYPE = :f_code_type
                                  ORDER BY A.CODE DESC ";
            layCommon.LayoutItems.Add("CODE", DataType.String);
            layCommon.LayoutItems.Add("CODE_NAME", DataType.String);
            layCommon.InitializeLayoutTable();
            layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layCommon.SetBindVarValue("f_code_type", "IPWONRYO_GUBUN");
            string strData = "";

            if (layCommon.QueryLayout(true))
            {
                for (int i=0; i<layCommon.RowCount; i++)
                {
                    strData += layCommon.GetItemString(i, "CODE_NAME");
                    strData += "\t" + layCommon.GetItemString(i, "CODE") + "/";
                }

                if (allItems.Contains("ipwonryo_gubun"))
                {
                    this.dwDoc2001u00.Modify("ipwonryo_gubun.values= " + "'" + strData + "'");
                    //this.dwDoc2001u00.Modify("ipwonryo_gubun.selected= '0'");
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "ipwonryo_gubun","B");
                }
                
            }
		}
		#endregion

		#region 환자의 과거에 작성된 제증명 정보를 데이터 윈도우에 보여준다.
		private void SetPastCert()
		{
			/* Page Number */
			int li_dwRow = 0;

			this.dwDoc2001u00.Reset();

			for (int i = 0; i < this.grdDOC2001.RowCount; i++)
			{
				if (li_dwRow != Convert.ToInt32(TypeCheck.NVL(this.grdDOC2001.GetItemValue(i, "cert_pgno").ToString(), "0").ToString()))
					//if (li_dwRow != Convert.ToInt32(dr["pgno"].ToString()))
				{	
					this.dwDoc2001u00.InsertRow(0);
					li_dwRow = Convert.ToInt32(TypeCheck.NVL(this.grdDOC2001.GetItemValue(i, "cert_pgno").ToString(),"0").ToString());
					//li_dwRow = Convert.ToInt32(dr["pgno"].ToString());
				}

				try
				{//XMessageBox.Show(li_dwRow.ToString() + " " + this.grdDOC2001.GetItemString(i, "cert_colm").ToString().ToLower());
					this.dwDoc2001u00.SetItemString(li_dwRow, this.grdDOC2001.GetItemString(i, "cert_colm").ToString().ToLower(), this.grdDOC2001.GetItemString(i, "cert_info").ToString());
				}
				catch
				{
				}
			}
			//parent.nudPgno.Maximum = parent.dwDiagnosis.RowCount;
		}
		#endregion

		#region 환자번호를 잘못 입력을 했을 때
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.grdDOC2001.Reset();
			this.grdCert_past.Reset();
            this.grdToiwonList.Reset();
		}
		#endregion

		#region 상병버튼을 클릭을 했을 때
		private void btnSang_code_Click(object sender, System.EventArgs e)
		{ 
            if (TypeCheck.IsNull(paBox.BunHo))
            {
                this.GetMessage("bunho");
                return;
            }
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("sang_inx", "");
			openParams.Add("multiSelect", false);
			XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
		}
		#endregion

		#region 예약글 버튼을 클릭을 했을 때
		private void btnReser_ward_Click(object sender, System.EventArgs e)
		{
            if (TypeCheck.IsNull(paBox.BunHo))
            {
                this.GetMessage("bunho");
                return;
            }     
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("category_gubun", "%"); 
			XScreen.OpenScreenWithParam(this, "OCSA", "OCS0221Q01", ScreenOpenStyle.ResponseFixed, openParams);
		}
		#endregion

		#region 팝업화면에서 데이터 받기
		public override object Command(string command, CommonItemCollection commandParam)
		{
			string sangText = string.Empty;
			string strText = string.Empty;
			string GWA_TEXT = string.Empty;
			string GWA      = string.Empty;
			string PKCSC0105 = string.Empty;

			if (command == "OCS0221Q01")
			{
                if (this.dwDoc2001u00.GetColumnName()!="")
				{
                    strText = commandParam["COMMENT"].ToString();
                    this.displayinfo(strText);
				}
			}

			if (commandParam.Contains("CHT0110") && (MultiLayout)commandParam["CHT0110"] != null && 
				((MultiLayout)commandParam["CHT0110"]).RowCount > 0)
			{
                strText = ((MultiLayout)commandParam["CHT0110"]).GetItemString(0, "sang_name").ToString();
                this.displayinfo(strText);
			}
            //if (command == "toiwon_date")
            //{
            //    if (commandParam["pkinp1001"].ToString() != "")
            //    {
            //        if ((grdCert_past.GetRowState(grdCert_past.CurrentRowNumber) == DataRowState.Added)||
            //            (grdCert_past.GetRowState(grdCert_past.CurrentRowNumber) == DataRowState.Modified))
            //        {
            //            grdCert_past.SetItemValue(grdCert_past.CurrentRowNumber, "fkinp1001", commandParam["pkinp1001"].ToString());
            //        }                
            //    }
            //    string toiwon_date = "";

            //    if (commandParam["toiwon_date"].ToString() != "")
            //    {
            //        toiwon_date = this.japan_date_convert(commandParam["toiwon_date"].ToString());
            //    }
            //    else
            //    {
            //        toiwon_date = this.japan_date_convert(this.dtpCert_wrdt.GetDataValue());
            //    }
            //    if (allItems.Contains("toiwon_date"))
            //    {
            //        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date", toiwon_date);
            //        this.dwDoc2001u00.AcceptText();
            //    }
            //}
			if (commandParam.Contains("OCS1023") && (MultiLayout)commandParam["OCS1023"] != null && 
				((MultiLayout)commandParam["OCS1023"]).RowCount > 0)
			{
				for (int i = 0; i < ((MultiLayout)commandParam["OCS1023"]).RowCount; i++)
				{
				    if ( i == 0 )
                        strText = ((MultiLayout)commandParam["OCS1023"]).GetItemString(i, "hangmog_name").ToString() + " " 
							+ ((MultiLayout)commandParam["OCS1023"]).GetItemString(i, "suryang").ToString() 
							+ ((MultiLayout)commandParam["OCS1023"]).GetItemString(i, "ord_danui_name").ToString();
					else
                        strText = strText + "\r\n" 
							+ ((MultiLayout)commandParam["OCS1023"]).GetItemString(i, "hangmog_name").ToString() + " " 
							+ ((MultiLayout)commandParam["OCS1023"]).GetItemString(i, "suryang").ToString() 
							+ ((MultiLayout)commandParam["OCS1023"]).GetItemString(i, "ord_danui_name").ToString();

                    if (strText != "")
					{
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), "");
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), strText);
						this.dwDoc2001u00.AcceptText();
					}
				}
			}	
			if (command == "DOC2001Q00")
			{
                strText = commandParam["DOCTOR_NAME"].ToString();
                if (this.dwDoc2001u00.GetColumnName() != "")
                {
                    if (strText != "")
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), "");
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), strText);
                        this.dwDoc2001u00.AcceptText();
                    }
                }
			}
            if (commandParam.Contains("OCS1003") && (MultiLayout)commandParam["OCS1003"] != null &&
                ((MultiLayout)commandParam["OCS1003"]).RowCount > 0)
            {
                string bogyong_code = "";
                string bogyong_name = "";
                for (int i = 0; i < ((MultiLayout)commandParam["OCS1003"]).RowCount; i++)
                {
                    if (this.input_tab == "04")
                    {
                        if (i == 0)
                            strText = ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "hangmog_name").ToString();
                        else
                            strText = strText + "\r\n"
                                + ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "hangmog_name").ToString();
                    }
                    else
                    {
                        if (i == 0)
                        {
                            strText = ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "hangmog_name").ToString() + " "
                                + ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "suryang").ToString()
                                + ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "ord_danui_name").ToString();
                        }
                        else
                        {
                            if ((bogyong_code != "") &&
                                (bogyong_code != ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "bogyong_code").ToString()))
                            {
                                strText = strText + "\r\n"
                                        + bogyong_name;
                                bogyong_name = "";
                            }
                            strText = strText + "\r\n"
                                + ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "hangmog_name").ToString() + " "
                                + ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "suryang").ToString()
                                + ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "ord_danui_name").ToString();
                        }
                        bogyong_name = ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "bogyong_name").ToString();
                        bogyong_code = ((MultiLayout)commandParam["OCS1003"]).GetItemString(i, "bogyong_code").ToString();
                    }
                }
                if (strText != "")
                {
                    if ((bogyong_name !="")&&(this.input_tab == "01"))
                    {
                        strText = strText + "\r\n"
                                       + bogyong_name;
                    }
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), strText);
                }
            }
			return base.Command (command, commandParam);
		}
		#endregion


        private void displayinfo(string strdate)
        {
            string strName = "";

            if (this.dwDoc2001u00.GetColumnName() != "")
            {
                try
                {
                    strName = this.dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName()).ToString();
                }
                catch 
                {
                }

                int count = this.dwDoc2001u00.CurrentEdit.SelectedStart;
                if (count > strName.Length+1)
                {
                    count = strName.Length;
                }
                if (strName == "")
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), strdate);
                    this.dwDoc2001u00.AcceptText();
                }
                else
                {
                    strName = strName.Insert(count, strdate);
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), "");
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, dwDoc2001u00.GetColumnName(), strName);
                    count += strdate.Length;
                    this.dwDoc2001u00.CurrentEdit.SelectText(short.Parse(count.ToString()), short.Parse(count.ToString()));
                    this.dwDoc2001u00.AcceptText();
                }
            }
        }

        #region EMRPrint 버튼 표시
        private void SetEMRPrintButton()
        {
            //EMR로 전송할 수 있는 양식의 경우 EMR 버튼을 보여준다.
            string cmd = @"SELECT 'Y' FROM OCSPEMR
                            WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                            AND PGM_ID = :f_pgm_id
                            AND DW_ID = :f_dw_id";

            BindVarCollection bindvar = new BindVarCollection();

            bindvar.Add("f_pgm_id", this.Name);
            bindvar.Add("f_dw_id", dwDoc2001u00.DataWindowObject);

            object ret = Service.ExecuteScalar(cmd, bindvar);

            if (ret != null)
            {
                this.btnEMR.Visible = true;
            }
            else
            {
                this.btnEMR.Visible = false;
            }
        }
        #endregion
		#region 진단서의 날짜를 달력으로 셋팅

		private void dwDoc2001u00_DataWindowCreated(object sender, Sybase.DataWindow.DataWindowCreatedEventArgs e)
		{
			dwDoc2001u00.ContextMenu = new System.Windows.Forms.ContextMenu(); 		
		}

		private void dwDoc2001u00_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            XDataWindow grd = sender as XDataWindow;

            this.calDate.Visible = false;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                string column = "";
                if (grdCert_past.CurrentRowNumber < 0) return;

                this.dwDoc2001u00.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
                this.calDate.Visible = false;

                if (!TypeCheck.IsNull(this.dwDoc2001u00.GetColumnName().ToString()))
                {
                    column = this.dwDoc2001u00.GetColumnName().ToString();

                    if (this.dwDoc2001u00.GetColumnName().ToString().IndexOf("date") >=0 )
                    {
                        this.calDate.Visible = true;
                        this.calDate.Location = new Point(e.X + 5, e.Y + 5);
                    }
                }
                else
                {
                    this.calDate.Visible = false;
                }
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if ((!TypeCheck.IsNull(this.dwDoc2001u00.GetColumnName().ToString())) && 
                    ((this.dwDoc2001u00.GetColumnName().ToString() == "current_recipe")||
                    (this.dwDoc2001u00.GetColumnName().ToString() == "checkup_opinion")))
                {
                    this.btnDo.Visible = true;
                }
                else
                {
                    this.btnDo.Visible = false;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                dwDoc2001u00.ContextMenu.Show(this, new Point(e.X, e.Y));
            }
		}
        #region 진단서 입력모드를 디폴트로 일본어로
        private void dwDoc2001u00_MouseEnter(object sender, System.EventArgs e)
        {
            this.dwDoc2001u00.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
        }
        #endregion
		private void calDate_DaySelected(object sender, IHIS.Framework.XCalendarDaySelectedEventArgs e)
		{
            dwDoc2001u00.Select();

			if(this.dwDoc2001u00.GetColumnName() != "")
			{   
                if ((this.dwDoc2001u00.GetColumnName().ToString().IndexOf("acting_date") >= 0) ||
                    (this.dwDoc2001u00.GetColumnName().ToString().IndexOf("gi") >= 0))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, this.dwDoc2001u00.GetColumnName(),
                            this.calDate.SelectedDays[0].Date.Month + "月" + this.calDate.SelectedDays[0].Date.Day + "日");
                }
                else
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, this.dwDoc2001u00.GetColumnName(),
                            this.japan_date_convert(this.calDate.SelectedDays[0].Date.ToString("yyyy/MM/dd")));
                }
                this.calDate.Visible = false;

                if ((this.dwDoc2001u00.GetColumnName() == "toiwon_date") ||
                    (this.dwDoc2001u00.GetColumnName() == "ipwon_date"))
                {
                    if ((this.allItems.Contains("sanjung_gigan")) &&
                        (this.allItems.Contains("ipwon_date"))&&
                        (this.allItems.Contains("toiwon_date"))
                        )
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sanjung_gigan",
                            this.Setsanjung_Gigan(dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date"),
                                             dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, "ipwon_date")));
                    }
                }
			}
			else
			{
				this.calDate.Visible = false;
			}
		}
		#endregion

        private string Setsanjung_Gigan(string to_date, string from_date)
        {
            string strval = "";

            if ((to_date.Trim() == "") || (from_date.Trim() == ""))
            {
                return strval;
            }
            strval = "0";

            DateTime dTo_date = DateTime.Parse(to_date);
            DateTime dFrom_date = DateTime.Parse(from_date);

            if (dTo_date >= dFrom_date)
            {
                TimeSpan timespan = dTo_date - dFrom_date.AddDays(-1);
                strval = timespan.Days.ToString();
            }
            return strval;
        }

		#region 퇴원증명서 작성시 기본 조회
		private void GetToiwonBaseInfo()
		{
            //if (this.grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "fkinp1001") != "")
            //{
            //    return;
            //}
            ///* 환자의 재원이력 창을 먼저 오픈 시킨다. */
            //if(this.paBox.BunHo.ToString() != "")
            //{
            //    string sysid       = EnvironInfo.CurrSystemID;
            //    string screen      = this.ScreenID;
            //    string pa_Bunho    = this.paBox.BunHo.ToString();
				
            //    IHIS.Framework.IXScreen aScreen;
            //    aScreen = XScreen.FindScreen("NURI", "NUR9001Q01");
   
            //    if (aScreen == null)
            //    {              
            //        CommonItemCollection openParams  = new CommonItemCollection();
            //        openParams.Add( "sysid", sysid);
            //        openParams.Add( "screen", screen);
            //        openParams.Add( "bunho", pa_Bunho);
		
            //        XScreen.OpenScreenWithParam(this, "NURI", "NUR9001Q01", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);
            //    }
            //    else
            //    {
            //        ((XScreen)aScreen).Activate();
            //    }
            //}
		}
		#endregion

		#region 사용자별 병명분류조회 화면을 오픈시킨다.
		private void btnUser_Click(object sender, System.EventArgs e)
		{
            if (TypeCheck.IsNull(paBox.BunHo))
            {
                this.GetMessage("bunho");
                return;
            }
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("sang_code", "");
			openParams.Add("memb", IHIS.Framework.UserInfo.UserID);
			//사용자조회 화면 Open
			XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseSizable, openParams);
		}
		#endregion

		#region 조회
        private void dataLoad()
        {
            if(this.rbnInData.Checked==true)
            {
                this.grdToiwonList.QueryLayout(false);
            }
            else 
            {   
                this.dataQuery();
            }
        }

		private void dataQuery()
		{
			strPic1		  = "";
			strPic2       = "";
			intPic1		  = 0;
			intPic2       = 0;
            int current = 0;

            current = this.grdCert_past.CurrentRowNumber;


			this.grdImage.Reset();
			/* 환자의 제증명 과거력을 조회한다. */
			this.grdCert_past.Reset();
            if (!this.grdCert_past.QueryLayout(true))
            {
                string mCap = NetInfo.Language == LangMode.Ko ? "취득실패" : "取得失敗";
                XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


		}
		#endregion
        //EMR 출력
        private void SendEMR()
        {
            if (dwDoc2001u00.DataWindowObject == "dw_doc2001u09")
            {
                string cmd = @"SELECT A.GUBUN
                            FROM EMR.EMRSHEET A ,
                                      MEDI.OCSPEMR B 
                           WHERE A.SHEETID = B.SHETSHTID
                           AND DW_ID = '" + dwDoc2001u00.DataWindowObject + "'";

                object ret = Service.ExecuteScalar(cmd);

                if (TypeCheck.IsNull(ret))
                {
                    return;
                }
                else
                {
                    bool isSuccess = false;
                    switch (ret.ToString())
                    {
                        case "IN":
                            isSuccess = EMRHelper.EMRPrint(dwDoc2001u00, EMRIOTGubun.IN, paBox.BunHo, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "", this.Name, grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "fkinp1001"));
                            break;

                        case "OUT":
                            isSuccess = EMRHelper.EMRPrint(dwDoc2001u00, EMRIOTGubun.OUT, paBox.BunHo, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "", this.Name, "");
                            break;

                        case "TOIWON":
                            isSuccess = EMRHelper.EMRPrint(dwDoc2001u00, EMRIOTGubun.TOIWON, paBox.BunHo, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "", this.Name, grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "fkinp1001"));
                            break;
                    }
                    if (isSuccess)
                    {
                        this.GetMessage("save_emr_true");
                        setPrinted();
                    }
                    else
                    {
                        this.GetMessage("save_emr_false");
                    }
                }
            }
        }

        private void setPrinted()
        {
            string strsql = "UPDATE DOC1001 "
                           + "   SET CERT_PRGB = 'Y' "
                           + "     , UPD_DATE  = SYSDATE "
                           + "     , UPD_ID    = '" + UserInfo.UserID + "'"
                           + " WHERE PKDOC1001 = '" + this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkdoc1001") + "'";
            if (!Service.ExecuteNonQuery(strsql))
            {
                throw new Exception(Service.ErrFullMsg);
            }
        }


		#region 버튼 이벤트

		//인쇄
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			string msg = string.Empty;
			string caption = string.Empty;
            string strsql = "";
            object retVal = null;

            int current = this.grdCert_past.CurrentRowNumber;
            if (current< 0)
            {
                return;
            }
            
            BindVarCollection item = new BindVarCollection();
			// 수정 20081010
			// 아직 저장전이면 출력안되게.
			foreach( DataRow dr in grdCert_past.LayoutTable.Rows )
			{
                if (dr.RowState == DataRowState.Added)
                {
                    this.GetMessage("print_err");
                    return;
                }
			}
            string pkdoc1001 = this.grdCert_past.GetItemValue(current, "fkdoc1001").ToString();


			/* 출력 가능 여부 체크 */
            if (!TypeCheck.IsNull(pkdoc1001))
			{
                strsql = @"SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM DOC1001
                                            WHERE PKDOC1001 = :f_pkdoc1001
                                              AND CERT_VALD = 'Y'
                                              AND CERT_WRGB = 'E')";

                item.Clear();
                item.Add("f_pkdoc1001", pkdoc1001);

                retVal = Service.ExecuteScalar(strsql, item);
                if (!TypeCheck.IsNull(retVal))
                {
                    if (retVal.ToString() != "Y")
                    {
                        this.GetMessage("print_err");
                        //this.btnSave.Focus();
                        return;
                    }
                    else
                    {
                        // 출력하기전에 데이터 수정된 것이 있으면 확인
                        if (!isSameDOC2001_back())
                        {
                            msg = NetInfo.Language == LangMode.Ko ? "변경된 내용을 저장후 프린트 하시겠습니까?"
                                : "変更された内容を保存後プリントしますか？";
                            caption = NetInfo.Language == LangMode.Ko ? "알림"
                                : "お知らせ";

                            if (XMessageBox.Show(msg, caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                // 저장후 메세지 및 이벤트를 안타게 제거
                                this.btnList.PerformClick(FunctionType.Update);
                            }
                        }
                        try
                        {
                            strsql = @"SELECT 'Y'
                                         FROM DUAL
                                        WHERE EXISTS (SELECT 'X'
                                                        FROM DOC1001
                                                       WHERE PKDOC1001 = :f_pkdoc1001
                                                         AND CERT_VALD = 'Y'
                                                         AND CERT_WRGB = 'E') ";
                            item.Clear();
                            item.Add("f_pkdoc1001", pkdoc1001);

                            retVal = Service.ExecuteScalar(strsql, item);
                            if (!TypeCheck.IsNull(retVal))
                            {
                                if (((XButton)sender).Name == "btnEMR")
                                {
                                    SendEMR();
                                }
                                else
                                {
                                    this.dwDoc2001u00.Print(true);
                                    setPrinted();
                                }
                            }
                            else
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                            }
                        }
                        catch (Exception ex)
                        {
                            msg = NetInfo.Language == LangMode.Ko ? "프린터 설정이 안되어 있습니다." + "\r\n" + "프린터 설정을 확인해 주십시오."
                                : "プリンターの設定がされていません." + "\r\n" + "プリンターの設定をご確認ください.";
                            msg += "\r\n[" + ex.Message.ToString() + "]";
                            caption = NetInfo.Language == LangMode.Ko ? "알림"
                                : "Error";
							//https://sofiamedix.atlassian.net/browse/MED-10610
                            //XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                        }                    
                    }
                }
                else
                {
                    XMessageBox.Show(Service.ErrFullMsg.ToString());
                    return;
                }
			}
        }
        #endregion
		#region 정시약조회 창 오픈
		private void btnDrug_Click(object sender, System.EventArgs e)
		{
            if (TypeCheck.IsNull(paBox.BunHo))
            {
                this.GetMessage("bunho");
                return;
            }
            if (cboGwa.GetDataValue() == "")
			{
				this.GetMessage("user_gwa");
				return;
			}
			else
			{
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add("bunho", this.paBox.BunHo.ToString());
				openParams.Add("gwa"  , cboGwa.GetDataValue());
				//사용자조회 화면 Open
				XScreen.OpenScreenWithParam(this, "OCSO", "OCS1023U00", ScreenOpenStyle.ResponseSizable, openParams);
			}
		}
		#endregion

		#region 주치의리스트를 조회한다.
		private void btnDoctor_Click(object sender, System.EventArgs e)
		{
            if (TypeCheck.IsNull(paBox.BunHo))
            {
                this.GetMessage("bunho");
                return;
            }
			if (cboGwa.GetDataValue() == "")
			{
				this.GetMessage("user_gwa");
				return;
			}
			else
			{
                //this.culName = "";
                //this.culName = this.dwDoc2001u00.GetColumnName().ToString();
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add("gwa"  , cboGwa.GetDataValue());
				//사용자조회 화면 Open
				XScreen.OpenScreenWithParam(this, "DOCS", "DOC2001Q00", ScreenOpenStyle.ResponseSizable, openParams);
			}
		}
		#endregion

		#region ImageAdd/Del Button

		private int imgGridRow(string fkdoc1001)
		{
			if(grdImage.RowCount > 0) 
			{
				for(int i = 0; i < grdImage.RowCount; i++)
				{
					if(grdImage.GetItemString(i, "fkdoc1001").Equals(fkdoc1001))
					{
						return i;
					}
				}
			}
			grdImage.InsertRow(-1);
			grdImage.SetItemValue(grdImage.RowCount - 1, "fkdoc1001", Convert.ToInt64(fkdoc1001));
			return grdImage.RowCount - 1;
		}
		
		private void btnPic1Add_Click(object sender, System.EventArgs e)
		{
            ////int row = imgGridRow(this.pkdoc1001);

            int row = imgGridRow(this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkdoc1001"));

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.dwDoc2001u00.Modify("p_1.filename = '" + dlg.FileName + "'");

                    Image image = Image.FromFile(dlg.FileName);
                    FileInfo file = new FileInfo(dlg.FileName);

                    this.grdImage.SetItemValue(row, "image1", image);
                    this.strPic1 = dlg.FileName.Substring(dlg.FileName.LastIndexOf(".") + 1);
                    this.intPic1 = file.Length;
                    this.grdImage.SetItemValue(row, "imgext1", this.strPic1);
                    this.grdImage.SetItemValue(row, "imglen1", this.intPic1);

                    image.Dispose();
                }
                catch (Exception xe)
                {
                    Debug.WriteLine(xe.Message);
                    Debug.WriteLine(xe.StackTrace);
                }
            }
		}

		private void btnPic2Add_Click(object sender, System.EventArgs e)
		{
            ////int row = imgGridRow(this.pkdoc1001);
            int row = imgGridRow(this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkdoc1001"));
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        this.dwDoc2001u00.Modify("p_2.filename = '" + dlg.FileName + "'");

            //        Image image = Image.FromFile(dlg.FileName);
            //        FileInfo file = new FileInfo(dlg.FileName);

            //        this.grdImage.SetItemValue(row, "image2", image);
            //        this.strPic2 = dlg.FileName.Substring(dlg.FileName.LastIndexOf(".") + 1);
            //        this.intPic2 = file.Length;
            //        this.grdImage.SetItemValue(row, "imgext2", this.strPic2);
            //        this.grdImage.SetItemValue(row, "imglen2", this.intPic2);

            //        image.Dispose();
            //    }
            //    catch (Exception xe)
            //    {
            //        Debug.WriteLine(xe.Message);
            //        Debug.WriteLine(xe.StackTrace);
            //    }
            //}
		}

		private void btnPic1Del_Click(object sender, System.EventArgs e)
		{
            //////int row = imgGridRow(this.pkdoc1001);
            //int row = imgGridRow(this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkdoc1001"));
            //this.dwDoc2001u00.Modify("p_1.filename = ''");
            //this.grdImage.SetItemValue(row, "image1", DBNull.Value);
            //this.grdImage.SetItemValue(row, "imgext1", DBNull.Value);
            //this.grdImage.SetItemValue(row, "imglen1", DBNull.Value);
            //this.strPic1 = "";
            //this.intPic1 = 0;
	    }

		private void btnPic2Del_Click(object sender, System.EventArgs e)
		{
            ////int row = imgGridRow(this.pkdoc1001);
            //this.dwDoc2001u00.Modify("p_2.filename = ''");
            //this.grdImage.SetItemValue(row, "image2", DBNull.Value);
            //this.grdImage.SetItemValue(row, "imgext2", DBNull.Value);
            //this.grdImage.SetItemValue(row, "imglen2", DBNull.Value);
            //this.strPic2 = "";
            //this.intPic2 = 0;
		}
		#endregion

		#region EMR연동
		private void btnEmrOpen_Click(object sender, System.EventArgs e)
		{
			//환자선택여부
			if (this.paBox.BunHo.ToString() == "")
				return;
			//EMR 설치여부를 check한다.
			if(!checkExistEMR()) return;
			try
			{
				//command = user id + user password + "2" + 환자번호
				//command도 프로그램에 맞게 생성
				string command = UserInfo.UserID + " " + UserInfo.UserPswd + " " + "2" + "  " + this.paBox.BunHo.ToString();
				System.Diagnostics.Process proExecute = new System.Diagnostics.Process();
				proExecute.StartInfo.FileName         = @"C:\ICM\ezEMR\ezEMR.exe";
				proExecute.StartInfo.Arguments        = command;
				proExecute.Start();
			}
			catch(Exception ex)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show( ex.Message, "ezEMR ERROR", MessageBoxIcon.Error);
			}
		}
		#endregion

		#region EMR 설치여부를 CHECK한다.
		private bool checkExistEMR()
		{
			bool returnValue = System.IO.Directory.Exists(@"C:\ICM\ezEMR");

			if (!returnValue )
			{
				string xMsg = NetInfo.Language == LangMode.Jr ? "電子カルテが設置されていません。担当者に連絡してください。" : "전자카르테가 설치되지 않았습니다. 담당자에게 연락바랍니다.";
				string xCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(xMsg, xCap);
			}
			return returnValue;
		}
		#endregion

		#region 20081010 추가 부분

        #region Grid Header Image Change
		private void GridHeaderImageChange()
		{
            this.tvwDOC2001.Nodes.Clear();

            if (this.grdCert_past.RowCount < 1) return;
            string pk_seq = "";
            int rowNum = 0;
            int node1 = -1, node2 = -1;
            TreeNode node;
            int count = 0;

            foreach (DataRow row in grdCert_past.LayoutTable.Rows)
            {
                if (pk_seq != row["cert_jncd"].ToString())
                {
                    node = new TreeNode(row["cert_jnnm"].ToString());
                    node.Tag = row["cert_jncd"].ToString();

                    if (tvwDOC2001.Nodes.Count > 0)
                    {
                        if((count > 0))
                        {
                            tvwDOC2001.Nodes[tvwDOC2001.Nodes.Count - 1].Text += "[" + count + "]";
                        }                
                    }
                    tvwDOC2001.Nodes.Add(node);
                    pk_seq = row["cert_jncd"].ToString();
                    row["node1"] = -1;
                    node1 = node1 + 1;
                    node2 = -1;
                    count = 0;
                }
                if (row["gwa"].ToString() == "")
                {
                    //tvwDOC2001.Nodes[tvwDOC2001.Nodes.Count-1].Tag = rowNum;
                    //node.Tag = rowNum;
                    rowNum++;
                    continue;
                }
                node = new TreeNode(row["gwa_name"].ToString() + "[" + row["cert_wrdt"].ToString() + "]");
                //node.Tag = rowNum;
                node.Tag = row["fkdoc1001"].ToString();
                rowNum++;

                if (row["select"].ToString() == "Y")
                {
                    node.ImageIndex = 16;
                    node.SelectedImageIndex = 16;
                }
                else
                {
                    node.ImageIndex = 15;
                    node.SelectedImageIndex = 15;
                }
                if (row["cert_prgb"].ToString() == "Y")
                {
                    node.ImageIndex = 9;
                    node.SelectedImageIndex = 9;
                }
                tvwDOC2001.Nodes[tvwDOC2001.Nodes.Count - 1].Nodes.Add(node);
                node2 = node2 + 1;
                row["node1"] = node1;
                row["node2"] = node2;
                count++;                
            }
            
            if (tvwDOC2001.Nodes[tvwDOC2001.Nodes.Count - 1].Nodes.Count > 0)
            {
                //tvwDOC2001.Nodes[tvwDOC2001.Nodes.Count - 1].Tag = rowNum;
                tvwDOC2001.Nodes[tvwDOC2001.Nodes.Count - 1].Text += "[" + count + "]";
            }
            foreach (TreeNode parentNode in this.tvwDOC2001.Nodes)
            {
                foreach (TreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.ImageIndex == 16)
                    {
                        parentNode.Expand();
                        break;
                    }
                }
            }
            //currentIndex

            if (this.currentIndex > -1)
            {
                string fkdoc1001 = this.grdCert_past.GetItemString(this.currentIndex, "fkdoc1001");

                foreach (TreeNode parentNode in this.tvwDOC2001.Nodes)
                {
                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        if (childNode.Tag.ToString() == fkdoc1001)
                        {
                            this.tvwDOC2001.SelectedNode = childNode;
                            break;
                        }
                    }
                }
            }



            //for (int i=0; i<this.grdCert_past.RowCount; i++)
            //{
            //    if (this.grdCert_past.GetItemString(i, "cert_prgb") == "Y")
            //    {
            //        this.grdCert_past[i + this.grdCert_past.HeaderHeights.Count, 0].Image = ImageList.Images[9];
            //    }
            //}
            this.grdCert_past.ResetUpdate();

		}
		#endregion
		private void ShowDWgrdCert_Past(int row)
		{
            if (grdCert_past.GetItemString(row, "fkdoc1001") == "")
            {
                this.dwDoc2001u00.Reset();
                this.dwDoc2001u00.DataWindowObject = "dw_doc2001u00";
                return;
            }
            this.SetDatawindow(grdCert_past.GetItemString(row, "cert_jncd"));

			this.pnlFill.Enabled = true;

			// 새로 입력한 로우일경우에는 DOC2001 데이터가 없으므로 
			if ( grdCert_past.GetRowState(row) == DataRowState.Added) 
			{
				// 기본정보를 다시 받아온다.
                GetPatientInfo();
				// 데이터윈도우에 셋팅
				SetDefaultDW();
				return;
			}
            this.grdDOC2001.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            this.grdDOC2001.SetBindVarValue("f_fkdoc1001",this.grdCert_past.GetItemValue(row, "fkdoc1001").ToString());
            this.grdDOC2001.SetBindVarValue("f_cert_jncd",this.grdCert_past.GetItemString(row, "cert_jncd").ToString());
            this.grdDOC2001.SetBindVarValue("f_gwa",this.grdCert_past.GetItemString(row, "gwa").ToString());
            this.grdDOC2001.SetBindVarValue("f_cert_rqdt",this.grdCert_past.GetItemString(row, "cert_rqdt").ToString());
            this.grdDOC2001.SetBindVarValue("f_cert_seqn", this.grdCert_past.GetItemString(row, "cert_seqn").ToString());
            if (this.grdDOC2001.QueryLayout(true))
            {
                // 20081010 데이터를 수정했는지 알아보기위한 백업테이블작성
                if (!TypeCheck.IsNull(DOC2001Back)) DOC2001Back.Clear();
                DOC2001Back = grdDOC2001.LayoutTable.Copy();
                /* 데이터 윈도우에 셋팅 */
                this.SetPastCert();
            }
            else
            {
                string mCap = NetInfo.Language == LangMode.Ko ? "취득실패" : "取得失敗";
                XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;            
            }
		}
		private void SetDefaultDW()
		{
            SingleLayout layCommon = new SingleLayout();
            int current = this.grdCert_past.CurrentRowNumber;            
            if (current < 0)
                return;
            string cert_jncd = grdCert_past.GetItemString(current, "cert_jncd");
            /* 디폴트 정보를 셋팅힌다. */
            if (allItems.Contains("cert_wrid_name"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "cert_wrid_name", UserInfo.UserName.ToString());
            }
            if (allItems.Contains("cert_wrid"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "cert_wrid", UserInfo.UserID.ToString());
            }
            if (allItems.Contains("cert_wrdt"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "cert_wrdt",
                                                grdCert_past.GetItemString(current, "cert_wrdt"));
                                               //japan_date_convert(grdCert_past.GetItemString(current, "cert_wrdt")));
            }
            if (allItems.Contains("cert_wrdt_year"))
            {
                DateTime strYear = Convert.ToDateTime(dtpCert_wrdt.GetDataValue());
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "cert_wrdt_year", strYear.ToString("yyyy/MM"));
            }
            /* 환자정보셋팅 */
            if (allItems.Contains("bunho"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "bunho", paBox.BunHo.ToString());
            }
            if (allItems.Contains("address"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "address", paBox.Address1);
            }
            if (allItems.Contains("suname"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "suname", paBox.SuName);
            }
            if (allItems.Contains("birth"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "birth", paBox.Birth);
            
            }
            if (allItems.Contains("suname2"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "suname2", paBox.SuName2);
            }
            if (allItems.Contains("birth_jp"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "birth_jp", this.japan_date_convert(paBox.Birth));
            }
            if (allItems.Contains("tel"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "tel", paBox.Tel);
            }
            if (allItems.Contains("age"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "age", paBox.YearAge.ToString());
            }
            if (allItems.Contains("sex"))
            {
                if (paBox.Sex == "M")
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sex", "男");
                else
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sex", "女");
            }

            if ((allItems.Contains("height")) || (allItems.Contains("weight")))
            {
                layCommon.Reset();
                layCommon.QuerySQL = @"SELECT A.HEIGHT
                                            , A.WEIGHT 
                                        FROM NUR7001 A
                                       WHERE A.HOSP_CODE = :f_hosp_code
                                         AND A.BUNHO = :f_bunho
                                         AND A.MEASURE_DATE = (SELECT MAX(Z.MEASURE_DATE)
                                                                 FROM NUR7001 Z
                                                                WHERE Z.HOSP_CODE = A.HOSP_CODE 
                                                                  AND Z.BUNHO = A.BUNHO ) ";
                layCommon.LayoutItems.Clear();
                layCommon.LayoutItems.Add("HEIGHT");
                layCommon.LayoutItems.Add("WEIGHT");
                layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layCommon.SetBindVarValue("f_bunho", paBox.BunHo.ToString());
                if (layCommon.QueryLayout())
                {
                    if (allItems.Contains("height"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "height", layCommon.GetItemValue("HEIGHT").ToString());
                    }
                    if (allItems.Contains("weight"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "weight", layCommon.GetItemValue("WEIGHT").ToString());
                    }
                }
            }
           
            /*병원정보셋팅*/
            if (this.layHospInfo.QueryLayout())
            {
                if (allItems.Contains("zip_code"))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "zip_code", this.layHospInfo.GetItemValue("zip_code").ToString());
                }
                if (allItems.Contains("hosp_address"))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "hosp_address", this.layHospInfo.GetItemValue("hosp_address").ToString());
                }
                if (allItems.Contains("simple_yoyang_name"))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "simple_yoyang_name", this.layHospInfo.GetItemValue("simple_yoyang_name").ToString());
                }
                if (allItems.Contains("hosp_tel"))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "hosp_tel", this.layHospInfo.GetItemValue("hosp_tel").ToString());
                }
                if (allItems.Contains("jaedan_name"))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "jaedan_name", this.layHospInfo.GetItemValue("jaedan_name").ToString());
                }

                if (allItems.Contains("fax"))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "fax", this.layHospInfo.GetItemValue("fax").ToString());
                }
            }
            if (allItems.Contains("gwa_name"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "gwa_name", grdCert_past.GetItemString(current, "gwa_name"));
            }
            if (allItems.Contains("doctor_name"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "doctor_name", UserInfo.UserName);
            }
            /* 입원정보셋팅 */
            if (grdCert_past.GetItemString(current, "cert_iuse")=="Y")
            {
                layCommon.Reset();
                layCommon.QuerySQL = @"SELECT FN_CHT_JAEWON_YN(:f_bunho) JAEWON_YN
                                                                FROM DUAL ";
                layCommon.LayoutItems.Clear();
                layCommon.LayoutItems.Add("JAEWON_YN");
                layCommon.SetBindVarValue("f_bunho", this.paBox.BunHo);
                if (layCommon.QueryLayout())
                {
                    this.layToiwonBaseInfo.SetBindVarValue("f_jaewon", layCommon.GetItemValue("JAEWON_YN").ToString());
                }
                this.layToiwonBaseInfo.SetBindVarValue("f_fkinp1001", grdCert_past.GetItemString(current, "fkinp1001"));
                this.layToiwonBaseInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                if (this.layToiwonBaseInfo.QueryLayout())
                {
                    if (allItems.Contains("gwa_name"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "gwa_name", this.layToiwonBaseInfo.GetItemValue("gwa_name").ToString());
                    }
                    if (allItems.Contains("damdang_name"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "damdang_name", this.layToiwonBaseInfo.GetItemValue("jisi_doctor_name").ToString());
                    }
                    if (allItems.Contains("ho_dong"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "ho_dong", this.layToiwonBaseInfo.GetItemValue("ho_dong").ToString());
                    }
                    if (allItems.Contains("ho_code"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "ho_code", this.layToiwonBaseInfo.GetItemValue("ho_code").ToString());
                    }
                    if (allItems.Contains("ipwon_date"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "ipwon_date", layToiwonBaseInfo.GetItemValue("ipwon_date").ToString());
                    }
                    if (allItems.Contains("toiwon_date"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date", layToiwonBaseInfo.GetItemValue("toiwon_date").ToString());
                    }
                    if (allItems.Contains("sanjung_gigan"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sanjung_gigan",
                                                        Setsanjung_Gigan(dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date"),
                                                                                                    this.layToiwonBaseInfo.GetItemValue("ipwon_date").ToString()));
                        //if ((this.layToiwonBaseInfo.GetItemValue("ipwon_date").ToString() != "") &&
                        //                           (dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date").Trim() != ""))
                        //{
                        //    //int sanjung_gigan = (int.Parse(DateTime.Parse(dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date")).ToString("yyyyMMdd")) -
                        //    //                     int.Parse(DateTime.Parse(this.layToiwonBaseInfo.GetItemValue("ipwon_date").ToString()).ToString("yyyyMMdd")));
                        //    //this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sanjung_gigan", sanjung_gigan.ToString());
                        //}
                    }
                    if (allItems.Contains("sanjung_from_gigan"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sanjung_from_gigan", this.layToiwonBaseInfo.GetItemValue("ipwon_date").ToString());
                    }
                    if (allItems.Contains("sanjung_to_gigan"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sanjung_to_gigan", dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date"));
                    }
                    //if (allItems.Contains("sanjung_from_gigan"))
                    //{
                    //    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sanjung_from_gigan", dwDoc2001u00.GetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_date"));
                    //}
                    if (allItems.Contains("sang_name"))
                    {
                        this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "sang_name", this.layToiwonBaseInfo.GetItemValue("sang_name").ToString());
                    }
                    if (allItems.Contains("toiwon_drg_plan"))
                    {

                        MultiLayout layoutcom = new MultiLayout();

                        layoutcom.LayoutItems.Clear();
                        layoutcom.LayoutItems.Add("group_ser", DataType.String);
                        layoutcom.LayoutItems.Add("toiwon_name", DataType.String);
                        layoutcom.LayoutItems.Add("bogyong_name", DataType.String);
                        layoutcom.LayoutItems.Add("nalsu", DataType.String);
                        layoutcom.InitializeLayoutTable();
                        layoutcom.QuerySQL = @"SELECT A.GROUP_SER,                                           
                                                      B.HANGMOG_NAME||'       '|| 
                                                      A.SURYANG||A.DV_TIME||A.DV ||' '||
                                                      FN_OCS_LOAD_CODE_NAME('ORD_DANUI',A.ORD_DANUI) ORD_DANUI_NAME,
                                                      DECODE(A.WONYOI_ORDER_YN,'Y','[院外]','[院内]' )||
                                                      FN_OCS_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE, A.JUSA_SPD_GUBUN)  BOGYONG_NAME,
                                                      A.NALSU||'日'
                                                 FROM OCS2003 A, OCS0103 B
                                                WHERE A.HOSP_CODE = :f_hosp_code 
                                                  AND A.BUNHO= :f_bunho
                                                  AND A.INPUT_GUBUN = 'D7'
                                                  AND A.HOSP_CODE = B.HOSP_CODE
                                                  AND A.HANGMOG_CODE = B.HANGMOG_CODE
                                                  AND A.ORDER_DATE BETWEEN B.START_DATE AND B.END_DATE  
                                                  ORDER BY  A.GROUP_SER,A.SEQ";
                        layoutcom.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        layoutcom.SetBindVarValue("f_bunho", this.paBox.BunHo);
                        if (layoutcom.QueryLayout(true))
                        {
                            string plan_name = "";
                            string group_ser = "";
                            string bogyong_name = "";

                            for (int i = 0; i < layoutcom.RowCount; i++)
                            {
                                if ((group_ser !="") && 
                                    (group_ser != layoutcom.GetItemString(i, "group_ser")))
                                {
                                    plan_name += bogyong_name;
                                }
                                else
                                {
                                    bogyong_name = "\r\n" + "    ★"+layoutcom.GetItemString(i, "bogyong_name") + "    " 
                                                          +layoutcom.GetItemString(i, "nalsu");
                                }
                                if (plan_name != "")
                                {
                                    plan_name += "\r\n";
                                }
                                plan_name += layoutcom.GetItemString(i, "toiwon_name");
                                group_ser = layoutcom.GetItemString(i, "group_ser");
                            }
                            plan_name += bogyong_name;
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "toiwon_drg_plan", plan_name);
                        }
                    }
                    //if (grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_jncd") == "002")
                    //{
                    //    this.SetDefaultIpwonRyo();
                    //}
                    if (allItems.Contains("ipwonryo_gubun"))
                    {
                        this.SetDefaultIpwonRyo();
                    }
                    if (allItems.Contains("nur_plan"))
                    {
                        this.layNurPlan.QuerySQL = @"SELECT B.NUR_PLAN_NAME 
                                                       FROM NUR4002 A, NUR4003 B
                                                      WHERE A.HOSP_CODE = :f_hosp_code
                                                        AND A.FKINP1001 = :f_fkinp1001
                                                        AND NVL(A.VALD, 'Y')     = 'Y'
                                                        AND  A.HOSP_CODE = B.HOSP_CODE
                                                        AND A.PKNUR4002 = B.FKNUR4002
                                                        AND B.NUR_PLAN_OTE ='P'    
                                                        AND NVL(B.VALD, 'Y')     = 'Y'
                                                      ORDER BY B.PKNUR4003 DESC";
                        this.layNurPlan.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        this.layNurPlan.SetBindVarValue("f_fkinp1001", this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkinp1001"));
                        if (this.layNurPlan.QueryLayout(true))
                        {
                            string plan_name = "";
                            for (int i = 0; i < this.layNurPlan.RowCount; i++)
                            {
                                if (plan_name != "")
                                {
                                    //plan_name += "\r\n";
                                    plan_name += ",";
                                }
                                plan_name += this.layNurPlan.GetItemString(i, "NUR_PLAN_NAME");
                            }
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "nur_plan", plan_name);
                        }
                    }

                    if (allItems.Contains("plan_pro_name")) 
                    {
                        this.layNurPlan.QuerySQL = @" SELECT A.NUR_PLAN_PRO_NAME
                                                        FROM  NUR4002 A
                                                       WHERE  A.HOSP_CODE = :f_hosp_code
                                                         AND  A.BUNHO     = :f_bunho
                                                         AND  A.FKINP1001 = :f_fkinp1001
                                                       ORDER BY PLAN_DATE DESC ";
                        this.layNurPlan.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        this.layNurPlan.SetBindVarValue("f_bunho", paBox.BunHo.ToString());
                        this.layNurPlan.SetBindVarValue("f_fkinp1001", this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkinp1001"));
                        if (this.layNurPlan.QueryLayout(true))
                        {
                            string plan_name = "";
                            for (int i = 0; i < this.layNurPlan.RowCount; i++)
                            {
                                if (plan_name != "")
                                {
                                    plan_name += "\r\n";
                                }
                                plan_name += this.layNurPlan.GetItemString(i, "NUR_PLAN_NAME");
                            }
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "plan_pro_name", plan_name);
                        }
                    }
                    if ((allItems.Contains("past_his")) || (allItems.Contains("main_appeal")) || (allItems.Contains("ipwon_course")) || (allItems.Contains("family_name"))) 
                    {
                        layCommon.Reset();
                        layCommon.QuerySQL = @" SELECT A.PAST_HIS
                                                     , A.MAIN_APPEAL
                                                     , A.IPWON_COURSE
                                                     , DECODE(A.FAMILY_NAME1, NULL,'',A.FAMILY_NAME1||','|| A.FAMILY_RELATION1||DECODE(A.IN_LIVE_YN1,'Y', ',(同居)','')  )||
                                                       DECODE(A.FAMILY_NAME2, NULL,'', '/ '|| A.FAMILY_NAME2||','|| A.FAMILY_RELATION2||DECODE(A.IN_LIVE_YN2,'Y', ',(同居)',''))||
                                                       DECODE(A.FAMILY_NAME3, NULL,'', '/ '|| A.FAMILY_NAME3||','|| A.FAMILY_RELATION3||DECODE(A.IN_LIVE_YN3,'Y', ',(同居)',''))||
                                                       DECODE(A.FAMILY_NAME4, NULL,'', '/ '|| A.FAMILY_NAME4||','|| A.FAMILY_RELATION4||DECODE(A.IN_LIVE_YN4,'Y', ',(同居)',''))||
                                                       DECODE(A.FAMILY_NAME5, NULL,'', '/ '|| A.FAMILY_NAME5||','|| A.FAMILY_RELATION5||DECODE(A.IN_LIVE_YN5,'Y', ',(同居)',''))||
                                                       DECODE(A.FAMILY_NAME6, NULL,'', '/ '|| A.FAMILY_NAME6||','|| A.FAMILY_RELATION6||DECODE(A.IN_LIVE_YN6,'Y', ',(同居)',''))||
                                                       DECODE(A.FAMILY_NAME7, NULL,'', '/ '|| A.FAMILY_NAME7||','|| A.FAMILY_RELATION7||DECODE(A.IN_LIVE_YN7,'Y', ',(同居)',''))
                                                       FAMILY_NAME
                                                  FROM  NUR1001 A
                                                 WHERE  A.HOSP_CODE = :f_hosp_code
                                                   AND  A.BUNHO = :f_bunho
                                                   AND  A.FKINP1001 = :f_fkinp1001 ";
                        layCommon.LayoutItems.Clear();
                        layCommon.LayoutItems.Add("PAST_HIS");
                        layCommon.LayoutItems.Add("MAIN_APPEAL");
                        layCommon.LayoutItems.Add("IPWON_COURSE");
                        layCommon.LayoutItems.Add("FAMILY_NAME");
                        layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        layCommon.SetBindVarValue("f_bunho", paBox.BunHo.ToString());
                        layCommon.SetBindVarValue("f_fkinp1001", this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkinp1001"));
                        if (layCommon.QueryLayout())
                        {
                            if (allItems.Contains("past_his"))
                            {
                                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "past_his", layCommon.GetItemValue("PAST_HIS").ToString());
                            }
                            if (allItems.Contains("main_appeal"))
                            {
                                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "main_appeal", layCommon.GetItemValue("MAIN_APPEAL").ToString());
                            }
                            if (allItems.Contains("ipwon_course"))
                            {
                                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "ipwon_course", layCommon.GetItemValue("IPWON_COURSE").ToString());
                            }
                            if (allItems.Contains("family_name"))
                            {
                                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "family_name",
                                    layCommon.GetItemValue("FAMILY_NAME").ToString());
                            }
                        }
                    }
                    if (allItems.Contains("allergy_info"))
                    {
                        this.layNurPlan.QuerySQL = @" SELECT A.ALLERGY_INFO
                                                        FROM  NUR1016 A
                                                       WHERE  A.HOSP_CODE = :f_hosp_code
                                                         AND  A.BUNHO = :f_bunho
                                                         AND  A.END_DATE IS NULL
                                                         AND :f_ipwon_date <= A.START_DATE 
                                                       ORDER BY START_DATE  DESC ";
                        this.layNurPlan.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        this.layNurPlan.SetBindVarValue("f_bunho", paBox.BunHo.ToString());
                        this.layNurPlan.SetBindVarValue("f_ipwon_date", DateTime.Parse(this.layToiwonBaseInfo.GetItemValue("ipwon_date").ToString()).ToString("yyyy/MM/dd"));
                        if (this.layNurPlan.QueryLayout(true))
                        {
                            string plan_name = "";
                            for (int i = 0; i < this.layNurPlan.RowCount; i++)
                            {
                                if (plan_name !="")
                                {
                                    plan_name += ",";
                                }
                                plan_name += this.layNurPlan.GetItemString(i, "NUR_PLAN_NAME");
                            }
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "allergy_info", plan_name);
                        }
                    }
                    if ((allItems.Contains("bph_value")) &&
                        (allItems.Contains("bpl_value")) &&
                        (allItems.Contains("t_value")) &&
                        (allItems.Contains("p_value")) &&
                        (allItems.Contains("kensa_date")))
                    {
                        layCommon.Reset();   
                        layCommon.QuerySQL = @"SELECT SUM( DECODE(A.pr_gubun,'T',A.pr_value,null))  T_VALUE
                                                     ,SUM(DECODE(A.pr_gubun,'PR',A.pr_value,null))  PR_VALUE
                                                     ,SUM(DECODE(A.pr_gubun,'BPH',A.pr_value,null)) BPH_VALUE
                                                     ,SUM(DECODE(A.pr_gubun,'BPL',A.pr_value,null)) BPL_VALUE
                                                     ,FN_BAS_TO_JAPAN_DATE_CONVERT('1', A.YMD)      YMD
                                                FROM ( SELECT Z.PR_GUBUN   PR_GUBUN
                                                             ,Z.PR_VALUE   PR_VALUE
                                                             ,Z.YMD
                                                       FROM   NUR1020 Z
                                                      WHERE Z.HOSP_CODE = :f_hosp_code
                                                        AND Z.FKINP1001 =  :f_fkinp1001
                                                        AND Z.YMD = (SELECT  MAX(X.YMD)
                                                                       FROM  NUR1020 X
                                                                      WHERE X.HOSP_CODE = Z.HOSP_CODE
                                                                       AND  X.FKINP1001 = Z.FKINP1001 )
                                                        AND Z.TIME_GUBUN =  (SELECT  MAX(X.TIME_GUBUN)
                                                                               FROM  NUR1020 X
                                                                              WHERE X.HOSP_CODE = Z.HOSP_CODE
                                                                               AND  X.FKINP1001 = Z.FKINP1001
                                                                               AND  X.YMD = Z.YMD )    
                                                     ) A
                                                GROUP BY A.YMD ";
                        layCommon.LayoutItems.Clear();
                        layCommon.LayoutItems.Add("T_VALUE");
                        layCommon.LayoutItems.Add("PR_VALUE");
                        layCommon.LayoutItems.Add("BPH_VALUE");
                        layCommon.LayoutItems.Add("BPL_VALUE");
                        layCommon.LayoutItems.Add("YMD");
                        layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        layCommon.SetBindVarValue("f_fkinp1001", this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "fkinp1001"));

                        if (layCommon.QueryLayout())
                        {
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "bph_value", layCommon.GetItemValue("BPH_VALUE").ToString());
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "bpl_value", layCommon.GetItemValue("BPL_VALUE").ToString());
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "t_value", layCommon.GetItemValue("T_VALUE").ToString());
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "p_value", layCommon.GetItemValue("PR_VALUE").ToString());
                            this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "kensa_date", layCommon.GetItemValue("YMD").ToString());
                        }
                    }
                }
            }
		}
		private void GetPatientInfo()
		{
            if (TypeCheck.IsNull(paBox.BunHo)) return;
            if (TypeCheck.IsNull(cboDoc0101.GetDataValue())) return;

            if (this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "cert_iuse") == "N")
            {
                /* 작성 가능한 환자인지를 조회한다. */
                this.GetPatientBaseInfo();
            }
            else
            {
                /* 퇴원증명서는 따로 환자의 기본조회를 관리한다. */
                //this.GetToiwonBaseInfo();
            }
		}
		private void cboGwa_SelectedValueChanged(object sender, System.EventArgs e)
		{
			// 입력상태일때만 이력에 동기화시켜준다.
			if ( grdCert_past.GetRowState( grdCert_past.CurrentRowNumber ) == DataRowState.Added )
			{
				grdCert_past.SetItemValue( grdCert_past.CurrentRowNumber, "gwa", cboGwa.GetDataValue() );
				grdCert_past.SetItemValue( grdCert_past.CurrentRowNumber, "gwa_name", cboGwa.Text );
                //gwa = cboDoc0101.Text;

                /* 진료과변경 */
                if (allItems.Contains("gwa_name"))
                {
                    this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "gwa_name", cboGwa.Text);
                }

			}		
		}		
		private bool isSameDOC2001_back()
		{
			// 새로입력한 행은 백업이 없음.
            if ((DOC2001Back == null) || (DOC2001Back.Rows.Count < 1)) return true;

			/* 저장에 쓰이는 변수들 */
			string colNM = string.Empty;
			int ll_i,ll_column_count, li_dwRow;

			// 입력한 데이터윈도우에서 저장그리드 만듬.
			this.dwDoc2001u00.AcceptText();
			this.AcceptData();

			ll_column_count = Convert.ToInt32(TypeCheck.NVL(this.dwDoc2001u00.Describe("Datawindow.column.count").ToString(), "0").ToString());
            
			this.grdDOC2001.Reset();
			int insertRow;
			for(li_dwRow = 1; li_dwRow <= this.dwDoc2001u00.RowCount; li_dwRow++)
			{
				for (ll_i = 1; ll_i<= ll_column_count; ll_i++)
				{
					colNM = this.dwDoc2001u00.Describe("#"+(ll_i).ToString()+".Name").Trim();
                    try
                    {
                        if (!TypeCheck.IsNull(this.dwDoc2001u00.GetItemString(li_dwRow, colNM).ToString().Trim()))
                        {
                            insertRow = this.grdDOC2001.InsertRow(-1);

                            this.grdDOC2001.SetItemValue(insertRow, "bunho", this.paBox.BunHo.ToString());
                            this.grdDOC2001.SetItemValue(insertRow, "cert_jncd", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_jncd"));
                            this.grdDOC2001.SetItemValue(insertRow, "gwa", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "gwa"));
                            this.grdDOC2001.SetItemValue(insertRow, "cert_rqdt", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_wrdt"));
                            this.grdDOC2001.SetItemValue(insertRow, "cert_seqn", 1);
                            this.grdDOC2001.SetItemValue(insertRow, "cert_colm", colNM.ToUpper().ToString());
                            this.grdDOC2001.SetItemValue(insertRow, "cert_pgno", li_dwRow);
                            if (this.dwDoc2001u00.GetItemString(li_dwRow, colNM).ToString().Trim() == "")
                            {
                                this.grdDOC2001.SetItemValue(insertRow, "cert_info", "");
                            }
                            else
                            {
                                this.grdDOC2001.SetItemValue(insertRow, "cert_info", this.dwDoc2001u00.GetItemString(li_dwRow, colNM).ToString());
                            }
                            this.grdDOC2001.SetItemValue(insertRow, "cert_wrdt", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_wrdt"));
                            this.grdDOC2001.SetItemValue(insertRow, "upd_gubun", "I");
                            this.grdDOC2001.SetItemValue(insertRow, "cert_iogb", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_iogb"));
                            this.grdDOC2001.SetItemValue(insertRow, "fkinp1001", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "fkinp1001"));
                            this.grdDOC2001.SetItemValue(insertRow, "fkout1001", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "fkout1001"));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.GetType().Name == "SqlNullValueException")
                        {
                            continue;
                        }
                        else
                        {
                            XMessageBox.Show(ex.Message);
                            this.grdDOC2001.Reset();
                        return false;
                        }
                    }
				}
			}
			// 비교2
			foreach( DataRow dr1 in grdDOC2001.LayoutTable.Rows )
			{
				// 순서가 달라졌을수 있으므로 컬럼명으로 비교
				// 
				bool isExistcolm = false;
				foreach ( DataRow dr2 in DOC2001Back.Rows )
				{
					// 데이터윈도우의 로우가 증가될수 있음. 추가되면
					if ( dr1["cert_colm"].ToString() == dr2["cert_colm"].ToString() )
					{
						// 일단 존재하는 컬럼
						isExistcolm = true;
						if ( dr1["cert_info"].ToString() != dr2["cert_info"].ToString() )
						{
							// 다름
							return false;
						}
						break;
					}
				}
				// 존재하지 않는 컬럼이 있으면 그 컬럼이 널인지 확인하고
				// 널이면 넘어가고 널이 아니면 다름.
				if ( !isExistcolm )
				{
					if ( !TypeCheck.IsNull( dr1["cert_info"].ToString() ) )
					{
						return false;
					}
				}
			}
			// 같음
			return true;
		}
		#endregion
        private void grdCert_past_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (e.PreviousRow > -1)
            {
                string msg = NetInfo.Language == LangMode.Ko ? "저장하지 않은 데이터가 존재합니다.저장하시겠습니까?" : "保存してないデータが存在します。保存しますか？";
                msg += NetInfo.Language == LangMode.Ko ? "\n" + "(저장하지 않은데이터는 삭제 됩니다.)" : "\n(保存してないデータは削除されます。)";
                string cap = NetInfo.Language == LangMode.Ko ? "저장확인" : "保存確認";
                if ((this.grdCert_past.GetRowState(e.PreviousRow) != DataRowState.Unchanged) || (!isSameDOC2001_back()))
                {
                    if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {   
                        this.dataSave(e.PreviousRow);
                        this.grdCert_past.SetFocusToItem(e.CurrentRow, 1);
                    }
                    else
                    {
                        if (this.grdCert_past.GetRowState(e.PreviousRow) != DataRowState.Unchanged)
                        {
                            this.grdCert_past.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdCert_past_RowFocusChanged);
                            this.grdCert_past.ResetUpdate();
                            this.grdCert_past.Refresh();
                            this.grdCert_past.SetFocusToItem(e.CurrentRow, 1);                            
                            this.grdCert_past.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdCert_past_RowFocusChanged);
                        }
                    }
                }
            }
            if (grdCert_past.RowCount < 1 || grdCert_past.CurrentRowNumber < 0) return;
            // 수정 20081010 새로 인서트한 행처리
            if (grdCert_past.GetRowState(e.CurrentRow) == DataRowState.Added)
            {
                this.dwDoc2001u00.Reset();
                cboDoc0101.SetDataValue(grdCert_past.GetItemString(e.CurrentRow, "cert_jncd"));
                dtpCert_wrdt.SetDataValue(grdCert_past.GetItemString(e.CurrentRow, "cert_wrdt"));
                cboGwa.SetDataValue(grdCert_past.GetItemString(e.CurrentRow, "gwa"));
                this.cboDoc0101.Protect = false;
                this.dtpCert_wrdt.Protect = false;
                this.cboGwa.Protect = false;
            }
            else
            {
                this.cboDoc0101.Protect = true;
                this.dtpCert_wrdt.Protect = true;
                this.cboGwa.Protect = true;
                this.cboDoc0101.SetDataValue(this.grdCert_past.GetItemString(e.CurrentRow, "cert_jncd"));
            }
            if (this.grdCert_past.RowCount > 0)
            {
                if (e.CurrentRow >= 0)
                {
                    ShowDWgrdCert_Past(e.CurrentRow);
                    SetEMRPrintButton();
                }
            }
        }
        
        private void grdCert_past_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdCert_past.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdCert_past.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            this.grdCert_past.SetBindVarValue("f_cert_jncd", this.cboDoc0101.GetDataValue());
            this.grdCert_past.SetBindVarValue("f_use_gubun", this.cboUse.GetDataValue());
            this.grdCert_past.SetBindVarValue("f_fkinp1001", this.rbnInData.Checked == true ? this.grdToiwonList.GetItemString(this.grdToiwonList.CurrentRowNumber, "pkinp1001"):"%");
            this.grdCert_past.SetBindVarValue("f_io_gubun", this.rbnInData.Checked == true ? "I" : "O");
        }
        private void grdCert_past_QueryEnd(object sender, QueryEndEventArgs e)
        {
            GridHeaderImageChange();		
        }
        private void layToiwonBaseInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layToiwonBaseInfo.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            this.layToiwonBaseInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layToiwonBaseInfo.SetBindVarValue("f_fkinp1001", this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber,"fkinp1001"));
        }

        private void layHospInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layHospInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layHospInfo.SetBindVarValue("f_start_date", this.dtpCert_wrdt.GetDataValue());
        }
        private void grdImage_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdImage.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdImage.SetBindVarValue("f_fkdoc1001", this.grdCert_past.GetItemValue(this.grdCert_past.CurrentRowNumber, "fkdoc1001").ToString());
        }
        private void grdCert_rqin_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdCert_rqin.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdCert_rqin.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            this.grdCert_rqin.SetBindVarValue("f_cert_jncd", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_jncd"));
            this.grdCert_rqin.SetBindVarValue("f_gwa", this.cboDoc0101.GetDataValue());
            this.grdCert_rqin.SetBindVarValue("f_fkinp1001", grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "fkinp1001"));
        }
        private void btnEMR_Click(object sender, EventArgs e)
        {
            btnPrint_Click(sender, e);
        }
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            if ((TypeCheck.IsNull(paBox.BunHo)) && 
                ((e.Func != FunctionType.Close) &&
                 (e.Func != FunctionType.Reset)))
            {
                this.GetMessage("bunho");
                return;
            }
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.dataLoad();
                    break;
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    this.dataInser();
                    break;
                case FunctionType.Update:
                    this.currentIndex = this.grdCert_past.CurrentRowNumber;
                    this.dataSave(this.grdCert_past.CurrentRowNumber);
                    this.grdCert_past.SetFocusToItem(this.currentIndex, 1);
                    this.currentIndex = -1;
                    break;
                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    //this.currentIndex = this.grdCert_past.CurrentRowNumber;
                    this.dataDelete();
                    //this.grdCert_past.SetFocusToItem(this.currentIndex, 1);
                    //this.currentIndex = -1;
                    break;
                case FunctionType.Reset:
                    e.IsBaseCall = false;
                    this.dataReset();
                    break;
            }
        }
        private void btnListUpdate_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            if (TypeCheck.IsNull(paBox.BunHo))
            {
                this.GetMessage("bunho");
                return;
            }
            switch (e.Func)
            {
                case FunctionType.Update:
                    this.dataSave(this.grdCert_past.CurrentRowNumber);
                    break;
            }
        }
        private void MakeCombo()
        {
            string UserSQL = "";

            UserSQL = @" SELECT '%'  CODE
                              ,FN_ADM_MSG(221) CODE_NAME
                          FROM DUAL
                        UNION ALL    
                        SELECT A.CODE 
                              ,A.CODE_NAME 
                        FROM DOC0002 A
                        WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                          AND A.CODE_TYPE  = 'USE_GUBUN'
                          AND  A.GROUP_KEY = :f_io_gubun
                        ORDER BY CODE";
            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();
            layoutCombo.QuerySQL = UserSQL;
            layoutCombo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layoutCombo.SetBindVarValue("f_io_gubun", this.rbnInData.Checked == true ? "I" : "O");

            if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            {
                this.cboUse.SetComboItems(layoutCombo.LayoutTable, "code_name", "code");
                this.cboUse.SelectedIndex = 0;
            }
        }
        private void DOC2001U00_Closing(object sender, CancelEventArgs e)
        {
            string msg = NetInfo.Language == LangMode.Ko ? "저장하지 않은 데이터가 존재합니다.저장하시겠습니까?" : "保存してないデータが存在します。保存しますか？";
            msg += NetInfo.Language == LangMode.Ko ? "\n" + "(저장하지 않은데이터는 삭제 됩니다.)" : "\n(保存してないデータは削除されます。)";
            string cap = NetInfo.Language == LangMode.Ko ? "저장확인" : "保存確認";

            this.DOC2001_back();
            foreach (DataRow drRow in this.grdCert_past.LayoutTable.Rows)
            {
                if (drRow.RowState != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.btnList.PerformClick(FunctionType.Update);
                    }
                }
            }
        }

        private void DOC2001_back()
        {
            string msg = NetInfo.Language == LangMode.Ko ? "저장하지 않은 데이터가 존재합니다.저장하시겠습니까?" : "保存してないデータが存在します。保存しますか？";
            msg += NetInfo.Language == LangMode.Ko ? "\n" + "(저장하지 않은데이터는 삭제 됩니다.)" : "\n(保存してないデータは削除されます。)";
            string cap = NetInfo.Language == LangMode.Ko ? "저장확인" : "保存確認";
            if (!isSameDOC2001_back())
            {
                if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.btnList.PerformClick(FunctionType.Update);
                }
                return;
            }
            //foreach (DataRow drRow in this.grdCert_past.LayoutTable.Rows)
            //{
            //    if (drRow.RowState != DataRowState.Unchanged)
            //    {
            //        if (XMessageBox.Show(msg, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            this.btnList.PerformClick(FunctionType.Update);
            //        }
            //    }
            //}
        }
        //초기화
        private void dataReset()
        {
            ///* 초기화 */
            strPic1 = "";
            strPic2 = "";
            intPic1 = 0;
            intPic2 = 0;
            this.grdImage.Reset();

            if (this.dwDoc2001u00.DataWindowObject != "")
            {
                this.dwDoc2001u00.Reset();
                if (cboDoc0101.GetDataValue().Equals("018"))
                {
                    this.dwDoc2001u00.Modify("p_1.filename = ''");
                    this.dwDoc2001u00.Modify("p_2.filename = ''");
                }
                this.dwDoc2001u00.InsertRow(0);
            }
            this.dtpCert_wrdt.SetDataValue(EnvironInfo.GetSysDate().ToString());
        }
        //저장
        private void dataSave( int rowNumber)
        {
            object retVal = null;
            string strsql = "";
            string pkdoc1001 = "";

            if (rowNumber < 0)
                return;
            int current = rowNumber;
            this.grdDOC2001.Reset();

            ////int CurrentRow = grdCert_past.CurrentRowNumber;

            // 추가 20081010 홍선희
            // 저장할때는 grdCert_past의 로우를 확인해서 있는것만 저장한다.
            // 즉 입력을 누르면 전역변수 pkdoc1001과 그리드의 pkdoc1001을 비교해서 같은것만 저장되게 한다.
            //if (grdCert_past.GetItemString(current, "fkdoc1001")
            //     != pkdoc1001)
            //{
            //    // 새로 작성하려면 입력을 누른후 저장해야함
            //    return;
            //}

            // 사용자가 제증명을 바꾸는 경우에 저장이 안되게 한다.
            if (grdCert_past.GetItemString(current, "cert_jncd")
                != cboDoc0101.GetDataValue())
            {
                return;
            }

            // 출력된 제증명은 수정 및 삭제를 못하게 한다. 삭제부분에도 있음.
            /*
            if ( grdCert_past.GetItemString( current, "cert_prgb") == "Y" )
            {
                string xMsg = NetInfo.Language == LangMode.Jr ? "出力された諸証明は修正/削除できません。"
                    : "출력이 된 제증명은 수정/삭제가 불가능합니다.";
                string xCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(xMsg, xCap);
                return;
            }
            */

            // 작성자랑 수정하는 사람이랑 다를때 비교
            if (grdCert_past.GetItemString(current, "cert_wrid") != UserInfo.UserID)
            {
                string wr_name = grdCert_past.GetItemString(current, "cert_wrid_nm") + "[" + grdCert_past.GetItemString(current, "cert_wrid") + "] ";
                string doc_name = grdCert_past.GetComboDisplayValue(current, "cert_jncd");

                string xMsg = NetInfo.Language == LangMode.Jr ? wr_name + "が作成した[" + doc_name + "]です。このまま 保存しますか。"
                    : wr_name + "가 작성한" + doc_name + "입니다. 그래도 저장하시겠습니까?";
                string xCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                if (XMessageBox.Show(xMsg, xCap, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

//            cmd = @"SELECT DOC1001_SEQ.NEXTVAL
//                         FROM DUAL ";

//            object t_chk = Service.ExecuteScalar(cmd);
//            if (t_chk == null)
//            {
//                string mCap = NetInfo.Language == LangMode.Ko ? "취득실패" : "取得失敗";
//                XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return false;
//            }
//            else
//            {
//                item.BindVarList.Add("f_fkdoc1001", t_chk.ToString());
//                this.parent.grdCert_past
//            }
            if (this.grdCert_past.GetItemString(current, "fkdoc1001") == "")
            {
                strsql = @"SELECT DOC1001_SEQ.NEXTVAL
                         FROM DUAL ";

                retVal = Service.ExecuteScalar(strsql);

                if (retVal == null)
                {
                    string mCap = NetInfo.Language == LangMode.Ko ? "취득실패" : "取得失敗";
                    XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //pkdoc1001 = retVal.ToString();
                this.grdCert_past.SetItemValue(current, "fkdoc1001", retVal.ToString());
            }
           
            /* 저장에 쓰이는 변수들 */
            string colNM = string.Empty;
            int ll_i, ll_column_count, li_dwRow;

            // 입력한 데이터윈도우에서 저장그리드 만듬.
            this.dwDoc2001u00.AcceptText();
            this.AcceptData();
            ll_column_count = this.dwDoc2001u00.ColumnCount;

            int insertRow;
            for (li_dwRow = 1; li_dwRow <= this.dwDoc2001u00.RowCount; li_dwRow++)
            {
                for (ll_i = 1; ll_i <= ll_column_count; ll_i++)
                {   
                    colNM = this.dwDoc2001u00.Describe("#" + (ll_i).ToString() + ".Name").Trim();
                    try
                    {
                        if (!TypeCheck.IsNull(this.dwDoc2001u00.GetItemString(li_dwRow, colNM).ToString().Trim()))
                        {
                            insertRow = this.grdDOC2001.InsertRow(-1);
                            this.grdDOC2001.SetItemValue(insertRow, "bunho", this.paBox.BunHo);
                            this.grdDOC2001.SetItemValue(insertRow, "fkdoc1001", this.grdCert_past.GetItemString(current, "fkdoc1001"));
                            this.grdDOC2001.SetItemValue(insertRow, "cert_jncd", this.grdCert_past.GetItemString(current, "cert_jncd"));
                            this.grdDOC2001.SetItemValue(insertRow, "gwa", this.grdCert_past.GetItemString(current, "gwa"));
                            this.grdDOC2001.SetItemValue(insertRow, "cert_rqdt", this.grdCert_past.GetItemString(current, "cert_rqdt"));
                            this.grdDOC2001.SetItemValue(insertRow, "cert_seqn", 1);
                            this.grdDOC2001.SetItemValue(insertRow, "cert_colm", colNM.ToUpper().ToString());
                            this.grdDOC2001.SetItemValue(insertRow, "cert_pgno", li_dwRow);
                            if (this.dwDoc2001u00.GetItemString(li_dwRow, colNM).ToString().Trim() == "")
                            {
                                this.grdDOC2001.SetItemValue(insertRow, "cert_info", "");
                            }
                            else
                            {
                                this.grdDOC2001.SetItemValue(insertRow, "cert_info", this.dwDoc2001u00.GetItemString(li_dwRow, colNM).ToString());
                            }
                            this.grdDOC2001.SetItemValue(insertRow, "cert_wrdt", this.grdCert_past.GetItemString(current, "cert_rqdt"));
                            this.grdDOC2001.SetItemValue(insertRow, "upd_gubun", "U");
                            this.grdDOC2001.SetItemValue(insertRow, "cert_iogb", this.grdCert_past.GetItemString(current, "cert_iogb"));
                            this.grdDOC2001.SetItemValue(insertRow, "fkinp1001", this.grdCert_past.GetItemString(current, "fkinp1001"));
                            this.grdDOC2001.SetItemValue(insertRow, "fkout1001", this.grdCert_past.GetItemString(current, "fkout1001"));
                        }                    
                    }
                    catch (Exception ex)
                    {
                        if (ex.GetType().Name == "SqlNullValueException")
                        {
                            continue;
                        }
                        else
                        {
                            XMessageBox.Show(ex.Message);
                            this.grdDOC2001.Reset();
                            return;
                        }
                    }
                }
            }
            if (this.grdDOC2001.RowCount > 0)
            {
                this.grdDOC2001.SetItemValue(0, "upd_gubun", "I");
            }
            this.grdDOC2001.AcceptData();
            try
            { 
                if (this.grdDOC2001.SaveLayout())
                {
                    this.GetMessage("save_true");
                    if (cboDoc0101.GetDataValue().ToString().Equals("006"))
                    {
                        this.SendMsgToID(grdCert_past.GetItemString(current, "cert_jnnm"),
                            this.paBox.BunHo + grdCert_past.GetItemString(current, "cert_jnnm")+"追加");
                    }
                }
                else
                {
                    throw new Exception(Service.ErrFullMsg);
                }
                grdCert_past.ResetUpdate();
                if (!TypeCheck.IsNull(DOC2001Back)) DOC2001Back.Clear();
                DOC2001Back = grdDOC2001.LayoutTable.Copy();
                this.dwDoc2001u00.Refresh();
                this.cboDoc0101.Protect = true;
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message);
                return;
            }

            //if (this.Opener is XScreen &&
            //    this.OpenParam != null)
            //{
            //    XScreen screen = (XScreen)this.Opener;
            //    if (screen.Name != "")
            //    {
            //        CommonItemCollection openParams;
            //        openParams = new CommonItemCollection();
            //        IHIS.Framework.IXScreen aScreen;
            //        aScreen = XScreen.OpenScreenWithParam(this, screen.ScreenID, screen.Name, ScreenOpenStyle.ResponseFixed, openParams);

            //        aScreen.Activate();
            //        this.btnList.PerformClick(FunctionType.Close);
            //    }
            //}
            //else
            //{
            this.grdCert_past.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdCert_past_RowFocusChanged);
            this.grdCert_past.QueryLayout(true);
            this.grdCert_past.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdCert_past_RowFocusChanged);
            //    //this.btnList.PerformClick(FunctionType.Query);
            //    //this.grdCert_past.SetFocusToItem(CurrentRow, 1);
            //    //this.grdCert_past.AcceptData();
            //}
        }
        private void SendMsgToID(string Title, string Contents)
        {

            string cmd = @"SELECT DISTINCT 
                                   A.SYS_ID 
                                 --, A.IP_ADDR
                                 , A.USER_ID 
                              FROM ADM3400 A 
                             WHERE A.SYS_ID IN ('DRGS') --,'DRGS', 'INPS', 'NUTS')
                               AND TRUNC(A.ENTR_TIME) = TRUNC(SYSDATE)
                             ORDER BY A.SYS_ID";

            DataTable ipTable = Service.ExecuteDataTable(cmd);

            string senderID = UserInfo.UserID;
            string senderBuseo = UserInfo.BuseoCode;

            if (ipTable != null && ipTable.Rows.Count > 0)
            {
                foreach (DataRow ip in ipTable.Rows)
                {
                    string recieverID = ip["USER_ID"].ToString();

                    string msgTitle = Title;// "服薬指導依頼書";
                    string msgContents = Contents;// this.paBox.BunHo + "服薬指導依頼書追加";
                    //string doctor = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "doctor").Substring(2);
                    //string suname = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "suname");

                    object tempobject = null;
                    string sendSeq = "";

                    cmd = @"SELECT NVL(MAX(SEND_SEQ),0) + 1 
                              FROM ADM0700 
                             WHERE SEND_DT   = TRUNC(SYSDATE) 
                               AND SENDER_ID = :f_sender_id";

                    BindVarCollection bindVar = new BindVarCollection();
                    bindVar.Add("f_sender_id", senderID);

                    tempobject = Service.ExecuteScalar(cmd, bindVar);

                    if (tempobject == null || tempobject.ToString() == "")
                        sendSeq = "1";
                    else
                        sendSeq = tempobject.ToString();

                    // ｡ﾁ狡ｴｰ杦 insert 
                    cmd = @" INSERT INTO ADM0700
                                  ( SEND_DT         , SENDER_ID         , SEND_SEQ      , SEND_SPOT
                                  , MSG_TITLE       , MSG_CONTENTS      , VALID_YN      , SEND_ALL_CNFM_YN
                                  , RECV_ALL_CNFM_YN, FILE_ATCH_YN      , CR_MEMB       , CR_TIME           , CR_TRM)
                             VALUES
                                  ( TRUNC(SYSDATE)  , :f_sender_id      , :f_send_seq   , :f_sender_buseo
                                  , :f_msg_title    , :f_msg_contents   , 'Y'           , :f_send_all_cnfm_yn
                                  , 'N'             , :f_file_atch_yn   , :f_user_id    , SYSDATE           , :f_user_trm)";

                    bindVar.Add("f_send_seq", sendSeq);
                    bindVar.Add("f_sender_buseo", senderBuseo);
                    bindVar.Add("f_msg_title", msgTitle);
                    bindVar.Add("f_msg_contents", msgContents);
                    bindVar.Add("f_send_all_cnfm_yn", "N");
                    bindVar.Add("f_file_atch_yn", "N");
                    bindVar.Add("f_user_id", senderID);
                    bindVar.Add("f_user_trm", "");

                    if (Service.ExecuteNonQuery(cmd, bindVar) == false)
                    {
                        string mCap = NetInfo.Language == LangMode.Ko ? "취득실패" : "送信失敗";
                        XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    object recv_spot = null;

                    cmd = @" SELECT A.DEPT_CODE 
                               FROM ADM3200 A 
                              WHERE A.USER_ID = :f_reciever_id";

                    bindVar.Add("f_reciever_id", recieverID);

                    recv_spot = Service.ExecuteScalar(cmd, bindVar);

                    if (recv_spot == null)
                        recv_spot = "";

                    bindVar.Add("f_recv_spot", recv_spot.ToString());

                    cmd = @"DECLARE 
                              T_CHECK   VARCHAR2(1); 
                            BEGIN 
                              T_CHECK := 'N'; 
                              FOR R1 IN ( SELECT 'X' 
                                            FROM ADM0710 X 
                                           WHERE SEND_DT = TRUNC(SYSDATE) 
                                             AND SENDER_ID = :f_user_id 
                                             AND SEND_SEQ  = :f_send_seq  
                                             AND RECV_SPOT = :f_recv_spot
                                             AND RECVER_ID = :f_reciever_id    ) LOOP 
                                 T_CHECK := 'Y'; 
                               END LOOP;

                               IF T_CHECK != 'Y' THEN 
                                 INSERT INTO ADM0710 
                                      ( SEND_DT         , SENDER_ID     , SEND_SEQ      , RECV_SPOT 
                                      , RECVER_ID       , RECV_SPOT_YN  , CNFM_YN       , RECV_ALL_CNFM_YN 
                                      , FILE_ATCH_YN    , VALID_YN      , UP_MEMB       , UP_TIME 
                                      , UP_TRM          , CR_MEMB       , CR_TIME       , CR_TRM           )
                                 VALUES 
                                      ( TRUNC(SYSDATE)  , :f_user_id    , :f_send_seq   , :f_recv_spot
                                      , :f_reciever_id  , 'Y'           , 'N'           , 'N' 
                                      , 'N'             , 'Y'           , :f_user_id    , SYSDATE 
                                      , ''              , :f_user_id    , SYSDATE       , '' ); 
                               END IF; 
                             END ;";

                    if (Service.ExecuteNonQuery(cmd, bindVar) == false)
                    {
                        string mCap = NetInfo.Language == LangMode.Ko ? "취득실패" : "送信失敗";
                        XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    IHIS.Framework.UdpHelper.SendMsgToID(senderID, recieverID, msgTitle, msgContents);
                }
            }
        }
        //삭제
        private void dataDelete()
        {
            // 출력된 제증명은 수정 및 삭제를 못하게 한다. 저장부분에도 있음.
            /*
            if ( grdCert_past.GetItemString( grdCert_past.CurrentRowNumber, "cert_prgb") == "Y" )
            {
                string xMsg = NetInfo.Language == LangMode.Jr ? "出力された諸証明は修正/削除できません。"
                    : "출력이 된 제증명은 수정/삭제가 불가능합니다.";
                string xCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(xMsg, xCap);
                return;
            }
            */

            // 새로 인서트 한거 삭제 할때
            if (grdCert_past.GetRowState(grdCert_past.CurrentRowNumber) == DataRowState.Added)
            {
                grdCert_past.DeleteRow(grdCert_past.CurrentRowNumber);
                this.btnList.PerformClick(FunctionType.Query);
                return;
            }

            string xMsg = "";
            string xCap = "";
            string wr_name = "";
            string doc_name = "";
            // 작성자랑 삭제하는 사람이랑 다를때 비교
            if (grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_wrid") != UserInfo.UserID)
            {
                wr_name = grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_wrid_nm") + "[" + grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_wrid") + "] ";
                doc_name = grdCert_past.GetComboDisplayValue(grdCert_past.CurrentRowNumber, "cert_jncd");

                xMsg = NetInfo.Language == LangMode.Jr ? wr_name + "が作成した[" + doc_name + "]です。このまま 削除しますか。"
                    : wr_name + "가 작성한" + doc_name + "입니다. 그래도 삭제하시겠습니까?";
                xCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                if (XMessageBox.Show(xMsg, xCap, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                // 삭제할지 메세지로 확인
                doc_name = grdCert_past.GetComboDisplayValue(grdCert_past.CurrentRowNumber, "cert_jncd");
                wr_name = grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_wrdt");
                xMsg = NetInfo.Language == LangMode.Jr ? "[" + wr_name + "]  [" + doc_name + "]を削除しますか。"
                    : "[" + wr_name + "][" + doc_name + "]를 삭제하시겠습니까?";
                xCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                if (XMessageBox.Show(xMsg, xCap, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No) return;
            }
            for (int i = 0; i < this.grdDOC2001.RowCount; i++)
            {
                this.grdDOC2001.SetItemValue(i, "upd_gubun", "D");
            }
            


            this.grdDOC2001.AcceptData();

            if (this.grdDOC2001.SaveLayout())
            {
                // 20070705 - Add Start 
                if (cboDoc0101.GetDataValue().ToString().Equals("018"))
                {
                    if (!this.grdImage.SaveLayout())
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                }
                // 20070705 - Add End
                this.strPic1 = "";
                this.strPic2 = "";
                this.intPic1 = 0;
                this.intPic2 = 0;
                this.grdImage.Reset();

                //this.pkdoc1001 = "";
                this.dwDoc2001u00.Reset();
                if (cboDoc0101.GetDataValue().Equals("018"))
                {
                    this.dwDoc2001u00.Modify("p_1.filename = ''");
                    this.dwDoc2001u00.Modify("p_2.filename = ''");
                }
                this.btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }
        /*
         * 행추가 
         */
        private void dataInser()
        {
            //string xMsg = "";
            //string xCap = "";
            //this.PopCount = 0;
            //string strsql = "";
            //object retVal = null;
            string cert_rqdt = "";
            string pkdoc1001 = "";
            string cert_wrdt = "";

            
            // 값없으면 아무동작 안하게
            if (TypeCheck.IsNull(cboDoc0101.GetDataValue()))
            {
                this.GetMessage("cert_jncd");
                return;
            }
            // 현재 추가된 행이 있으면 또 인서트 안되게
            foreach (DataRow dr in grdCert_past.LayoutTable.Rows)
            {
                if (dr.RowState == DataRowState.Added) return;
            }

            // 한줄을 더 생성
            // 로우포커스 이벤트로 옮긴후 처리때문에 이벤트를 죽였다가 살림
            this.grdCert_past.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdCert_past_RowFocusChanged);

            int row = 0;

            if (this.grdCert_past.GetItemString(this.grdCert_past.CurrentRowNumber, "cert_wrdt") != "")
            {
                row = grdCert_past.InsertRow();
            }
            else
            {
                row = this.grdCert_past.CurrentRowNumber;
            }
            this.cboDoc0101.Protect = false;
            this.dtpCert_wrdt.Protect = false;
            this.cboGwa.Protect = false;
            this.grdCert_past.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdCert_past_RowFocusChanged);

            // 그리드에 데이터윈도우, 작성일자, 과정보 입력
            this.grdCert_past.SetItemValue(row, "cert_wrdt", dtpCert_wrdt.GetDataValue());
            this.grdCert_past.SetItemValue(row, "cert_jncd", cboDoc0101.GetDataValue());
            this.grdCert_past.SetItemValue(row, "gwa_name", cboGwa.Text);
            this.grdCert_past.SetItemValue(row, "gwa", cboGwa.GetDataValue());
            this.grdCert_past.SetItemValue(row, "cert_wrid", UserInfo.UserID);
            this.grdCert_past.SetItemValue(row, "cert_wrid_nm", UserInfo.UserName);
            if (this.rbnInData.Checked == true)
            {
                this.grdCert_past.SetItemValue(row, "fkinp1001", this.grdToiwonList.GetItemString(this.grdToiwonList.CurrentRowNumber, "pkinp1001"));
            }

            // 데이터윈도우를 콤보박스 선택 한걸로 셋팅한다.
            if (this.dwDoc2001u00.DataWindowObject != "")
                this.dwDoc2001u00.Reset();
            //데이터윈도우셋팅
            this.SetDatawindow(cboDoc0101.GetDataValue());

            // 환자정보를 받아온다.
            GetPatientInfo();

//            strsql = @"SELECT DOC1001_SEQ.NEXTVAL
//                         FROM DUAL ";

//            retVal = Service.ExecuteScalar(strsql);

//            if (retVal != null)
//            {
//                pkdoc1001 = retVal.ToString();
//                if (this.dtpCert_wrdt.GetDataValue().ToString() == "")
//                    cert_rqdt = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
//                else
//                    cert_rqdt = this.dtpCert_wrdt.GetDataValue().ToString();
//            }
//            else
//            {
//                string mCap = NetInfo.Language == LangMode.Ko ? "취득실패" : "取得失敗";
//                XMessageBox.Show(Service.ErrFullMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }
            if (this.dtpCert_wrdt.GetDataValue().ToString() == "")
                cert_rqdt = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            else
                cert_rqdt = this.dtpCert_wrdt.GetDataValue().ToString();

            /* 작성일자를 와력으로 변환을 한다. */
            cert_wrdt = japan_date_convert(cert_rqdt);
            if (this.allItems.Contains("cert_wrdt"))
            {
                this.dwDoc2001u00.SetItemString(this.dwDoc2001u00.CurrentRow, "cert_wrdt", cert_wrdt);
            }
            // 데이터윈도우에 업데이트 될거 업데이트
            grdCert_past.SetItemValue(row, "cert_wrdt", cert_wrdt);
            grdCert_past.SetItemValue(row, "cert_rqdt", cert_rqdt);
            grdCert_past.SetItemValue(row, "cert_seqn", 1);
            grdCert_past.SetItemValue(row, "gwa_name", cboGwa.Text);
            grdCert_past.SetItemValue(row, "gwa", cboGwa.GetDataValue());
            grdCert_past.SetItemValue(row, "cert_wrid", UserInfo.UserID);
            grdCert_past.SetItemValue(row, "cert_wrid_nm", UserInfo.UserName);
            // 전역변수값을 dw에 셋팅
            SetDefaultDW();
        }
        private void btnSang_Click(object sender, EventArgs e)
        {
            string IOGubun = "O";
            if (grdCert_past.GetItemString(grdCert_past.CurrentRowNumber, "cert_iuse") == "Y")
            {
                IOGubun = "I";
            }

            dlg = new Sang(this.paBox.BunHo, IOGubun);
            dlg.Owner = this.ParentForm;

            
            dlg.ShowDialog();
            this.displayinfo(dlg.Sangname);            
        }

        private void tvwDOC2001_MouseDown(object sender, MouseEventArgs e)
        {
            this.calDate.Visible = false;
            for (int i = 0; i < this.tvwDOC2001.Nodes.Count; i++)
            {
                for (int j = 0; j < this.tvwDOC2001.Nodes[i].Nodes.Count; j++)
                {
                    if (this.tvwDOC2001.Nodes[i].Nodes[j].ImageIndex != 9)
                    {
                        this.tvwDOC2001.Nodes[i].Nodes[j].ImageIndex = 15;
                    }

                }
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (tvwDOC2001.GetNodeAt(new Point(e.X, e.Y)) == null || tvwDOC2001.GetNodeAt(new Point(e.X, e.Y)).Parent == null) return;
                tvwDOC2001.SelectedNode = tvwDOC2001.GetNodeAt(new Point(e.X, e.Y));
                if ((tvwDOC2001.SelectedNode == null) || (tvwDOC2001.SelectedNode.Parent == null)) return;
                TreeNode node = tvwDOC2001.GetNodeAt(new Point(e.X, e.Y));
                if (node.ImageIndex == 9)
                {
                    return;
                }
                if (node.ImageIndex == 15)
                {
                    node.ImageIndex = 16;
                    node.SelectedImageIndex = 16;
                }
                else
                {
                    node.ImageIndex = 15;
                    node.SelectedImageIndex = 15;
                }
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {

            }
        }

        private void tvwDOC2001_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int currnRow =0;
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                if (tvwDOC2001.SelectedNode.Parent == null)
                {
                    for (int i = 0; i < this.grdCert_past.RowCount; i++)
                    {
                        if (tvwDOC2001.SelectedNode.Tag.ToString() == this.grdCert_past.GetItemString(i, "cert_jncd"))
                        {
                            currnRow = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.grdCert_past.RowCount; i++)
                    {
                        if (tvwDOC2001.SelectedNode.Tag.ToString() == this.grdCert_past.GetItemString(i, "fkdoc1001"))
                        {
                            currnRow = i;
                            break;
                        }
                    }
                }
                grdCert_past.SetFocusToItem(currnRow, 1);
                grdCert_past.AcceptData();
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
        private void cboUse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdToiwonList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdToiwonList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdToiwonList.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void grdToiwonList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.dataQuery();
        }

        // 입원,외래 버튼클릭이벤트처리
        private void rbnDataGubun_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton button = sender as XRadioButton;
            if (button.Checked == true)
            {
                this.DOC2001_back();

                if (button.Name == "rbnInData")
                {
                    this.grdToiwonList.Height = 160;
                }
                else 
                {
                    this.grdToiwonList.Height = 0;
                }
                button.ImageIndex = 16;
                button.BackColor = this.mSelectedBackColor;
                button.ForeColor = this.mSelectedForeColor;
                
                this.MakeCombo();
                this.dataLoad();
            }
            else
            {
                button.ImageIndex = 15;
                button.BackColor = this.mUnSelectedBackColor;
                button.ForeColor = this.mUnSelectedForeColor;
            }            
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            
            if (rbnOutData.Checked)
            {
                if (this.dwDoc2001u00.GetColumnName().ToString() == "current_recipe")
                {
                    this.input_tab = "01";
                }
                else
                {
                    this.input_tab = "04";
                }
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", paBox.BunHo);
                openParams.Add("gwa", this.cboGwa.GetDataValue());
                openParams.Add("doctor", "%");
                openParams.Add("naewon_date", this.dtpCert_wrdt.GetDataValue());
                openParams.Add("input_gubun", "D0");
                //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
                openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다
                openParams.Add("auto_close", false);
                openParams.Add("input_tab", input_tab);
                openParams.Add("io_gubun", "O");
                openParams.Add("childYN", "N");
                XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q00", ScreenOpenStyle.ResponseSizable, openParams);
            }
            else 
            {
            }
 
        }
	}
    

    #region XSaverPerformer
    class XSavePerformer : ISavePerformer
    {
        DOC2001U00 parent;

        public XSavePerformer(DOC2001U00 parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerID, RowDataItem item)
        {
            string cmd = "";
            item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
            item.BindVarList.Add("f_user_id", UserInfo.UserID);

            switch (callerID)
            {
                case '1':
                    switch (item.RowState)
                    {
                        case DataRowState.Added:
                        case DataRowState.Modified:

                            /* 입력된 제증명의 요청정보가 있는지 조회를 한다. */
                            cmd = @"SELECT 'Y'
                                      FROM DUAL
                                     WHERE EXISTS (SELECT 'X'
                                                     FROM DOC1001
                                                    WHERE HOSP_CODE = :f_hosp_code
                                                      AND BUNHO     = :f_bunho
                                                      AND PKDOC1001 = :f_fkdoc1001
                                                      AND CERT_JNCD = :f_cert_jncd
                                                      AND GWA       = :f_gwa
                                                      AND CERT_RQDT = TO_DATE(:f_cert_rqdt, 'YYYY/MM/DD')
                                                      AND CERT_SEQN = :f_cert_seqn)";

                            object retVal = Service.ExecuteScalar(cmd, item.BindVarList);

                            if (!TypeCheck.IsNull(retVal))
                            {
                                /* 요청테이블의 예정 정보를 작성으로 바꾼다. */
                                cmd = @"UPDATE DOC1001
                                               SET UPD_ID    = :f_user_id,
                                                   UPD_DATE  = SYSDATE,
                                                   CERT_WRDT = TO_DATE(:f_cert_wrdt, 'YYYY/MM/DD'),
                                                   CERT_WRGB = 'E',
                                                   CERT_WRID = :f_user_id
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND BUNHO     = :f_bunho
                                               AND PKDOC1001 = :f_fkdoc1001
                                               AND CERT_JNCD = :f_cert_jncd
                                               AND GWA       = :f_gwa
                                               AND CERT_RQDT = TO_DATE(:f_cert_rqdt, 'YYYY/MM/DD')
                                               AND CERT_SEQN = :f_cert_seqn";
                            }
                            else
                            {
                                /* 제증명 요청정보를 저장한다. */
                                cmd = @"INSERT INTO DOC1001 (SYS_DATE    , SYS_ID      , UPD_DATE    ,
                                                             BUNHO       , PKDOC1001   , CERT_JNCD   ,
                                                             GWA         , CERT_RQDT   , CERT_SEQN   ,
                                                             CERT_VALD   , CERT_IOGB   , HO_DONG     ,
                                                             CERT_RQNU   , CERT_BIGO   , CERT_WRDT   ,
                                                             CERT_WRGB   , CERT_WRID   , CERT_PRGB   ,
                                                             FKINP1001   , FKOUT1001   , HOSP_CODE)
                                            VALUES          (SYSDATE     , :f_user_id  , SYSDATE     ,
                                                             :f_bunho    , :f_fkdoc1001, :f_cert_jncd,
                                                             :f_gwa      , TO_DATE(:f_cert_rqdt, 'YYYY/MM/DD'), :f_cert_seqn,
                                                             'Y'         , :f_cert_iogb, :f_ho_dong  ,
                                                             1           , ''          , TO_DATE(:f_cert_wrdt, 'YYYY/MM/DD'),
                                                             'E'         , :f_user_id  , ''          ,
                                                             :f_fkinp1001, :f_fkout1001, :f_hosp_code)";
                            }
                            if (!Service.ExecuteNonQuery(cmd, item.BindVarList))
                            {
                                XMessageBox.Show("Update Error : " + Service.ErrFullMsg);
                                return false;
                            }

                            if (item.BindVarList["f_upd_gubun"].VarValue == "I")
                            {
                                /* 입력된 정보를 삭제를 하고 다시 입력을 한다. */
                                cmd = @"DELETE DOC2001
                                         WHERE HOSP_CODE = :f_hosp_code
                                           AND BUNHO     = :f_bunho
                                           AND FKDOC1001 = :f_fkdoc1001
                                           AND CERT_JNCD = :f_cert_jncd
                                           AND GWA       = :f_gwa
                                           AND CERT_RQDT = :f_cert_rqdt
                                           AND CERT_SEQN = :f_cert_seqn
                                           AND HOSP_CODE = :f_hosp_code ";

                                if (!Service.ExecuteNonQuery(cmd, item.BindVarList))
                                {
                                    XMessageBox.Show("Update Error : " + Service.ErrFullMsg);
                                    return false;
                                }
                            }

                            if (item.BindVarList["f_upd_gubun"].VarValue == "D")
                            {
                                /* 출력된 데이터는 삭제가 불가능하다. */
                                /*EXEC SQL
                                SELECT 'Y'
                                  INTO :o_print_chk
                                  FROM DUAL
                                 WHERE EXISTS (SELECT 'X'
                                                 FROM DOC1001
                                                WHERE BUNHO     = :i_bunho
                                                  AND PKDOC1001 = :i_fkdoc1001
                                                  AND CERT_JNCD = :i_cert_jncd
                                                  AND GWA       = :i_gwa
                                                  AND CERT_RQDT = :i_cert_rqdt
                                                  AND CERT_SEQN = :i_cert_seqn
                                                  AND CERT_PRGB = 'Y');

                                if (sqlca.sqlcode != 0 && sqlca.sqlcode != EXC_NO_DATA_FOUND)
                                    return (SqlErr(MessageOut,NULL, 1));

                                if(sqlca.sqlcode == 0)
                                {
                                    memset(o_msg,0X00,sizeof(o_msg));

                                    DOCCOMSVC_GetAdmMsg("1011", o_msg);

                                    return SysErr(MessageOut, "99991", o_msg, NULL, 0);
                                }*/
                                /* 입력된 요청정보도 삭제를 한다. */
                                cmd = @" UPDATE DOC1001
                                       SET CERT_VALD = 'N',
                                           UPD_ID    = :f_user_id,
                                           UPD_DATE  = SYSDATE
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND BUNHO     = :f_bunho
                                       AND PKDOC1001 = :f_fkdoc1001
                                       AND CERT_JNCD = :f_cert_jncd
                                       AND GWA       = :f_gwa
                                       AND CERT_RQDT = :f_cert_rqdt
                                       AND CERT_SEQN = :f_cert_seqn";

                                if (Service.ExecuteNonQuery(cmd, item.BindVarList))
                                {
                                    /* 입력된 정보를 삭제한다. */
                                    cmd = @"UPDATE DOC2001
                                       SET CERT_VALD = 'N',
                                           UPD_ID    = :f_user_id,
                                           UPD_DATE  = SYSDATE
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND BUNHO     = :f_bunho
                                       AND FKDOC1001 = :f_fkdoc1001
                                       AND CERT_JNCD = :f_cert_jncd
                                       AND GWA       = :f_gwa
                                       AND CERT_RQDT = :f_cert_rqdt
                                       AND CERT_SEQN = :f_cert_seqn";

                                    if (!Service.ExecuteNonQuery(cmd, item.BindVarList))
                                    {
                                        XMessageBox.Show("Update Error : " + Service.ErrFullMsg);
                                        return false;
                                    }
                                }
                                else
                                {
                                    XMessageBox.Show("Update Error : " + Service.ErrFullMsg);
                                    return false;
                                }
                            }
                            else
                            {
                                if (item.BindVarList["f_cert_info"].VarValue != "")
                                {
                                    /* 제증명입력 정보를 저장한다. */
                                    cmd = @"INSERT INTO DOC2001 
                                                    (   SYS_DATE    , SYS_ID      , UPD_DATE    ,
                                                        BUNHO       , FKDOC1001   , CERT_JNCD   ,
                                                        GWA         , CERT_RQDT   , CERT_SEQN   ,
                                                        CERT_COLM   , CERT_PGNO   , CERT_INFO   ,
                                                        CERT_WRDT   , CERT_VALD   , HOSP_CODE )
                                                VALUES              
                                                    (   SYSDATE     , :f_user_id  , SYSDATE     ,
                                                        :f_bunho    , :f_fkdoc1001, :f_cert_jncd,
                                                        :f_gwa      , TO_DATE(:f_cert_rqdt, 'YYYY/MM/DD'), :f_cert_seqn,
                                                        :f_cert_colm, :f_cert_pgno, :f_cert_info,
                                                        TO_DATE(:f_cert_wrdt, 'YYYY/MM/DD'), 'Y', :f_hosp_code )";
                                }
                            }
                            break;

                        case DataRowState.Deleted:
                            break;

                    }
                    break;
                case '2':
                    switch (item.RowState)
                    {
                        case DataRowState.Added:
                        case DataRowState.Modified:
                            cmd = @" UPDATE DOC2002
				                           SET USER_ID   = :f_user_id    ,
				                               UPD_DATE  = SYSDATE       ,
				                               IMG_PATH1 = :f_file_name1 ,
				                               IMG_PATH2 = :f_file_name2 ,
				                               IMG_EXT1  = :f_ext1       ,
				                               IMG_EXT2  = :f_ext2       ,
				                               IMG_LEN1  = :f_len1       ,
				                               IMG_LEN2  = :f_len2
		                                 WHERE FKDOC1001 = :f_fkdoc1001;
                        									
				                        IF SQL%NOTFOUND THEN
                        		
					                        INSERT INTO DOC2002
							                        (SYS_DATE,		USER_ID,		UPD_DATE,       
							                         FKDOC1001,		IMG_PATH1,		IMG_PATH2,
							                         IMG_EXT1,      IMG_EXT2,		IMG_LEN1,
							                         IMG_LEN2)
					                        VALUES (SYSDATE,		:q_user_id,		SYSDATE,
							                        :f_fkdoc1001,   :f_file_name1,  :f_file_name2,
							                        :f_ext1,		:f_ext2,		:f_len1,
							                        :f_len2);                        		
				                        END IF;                        				
				                        END;";
                            break;
                        case DataRowState.Deleted:
                            cmd = @" DELETE DOC2002
			                          WHERE FKDOC1001 = :f_fkdoc1001";
                            break;
                    }
                    break;
            }
            return Service.ExecuteNonQuery(cmd, item.BindVarList);
        }
    }
    #endregion
}


