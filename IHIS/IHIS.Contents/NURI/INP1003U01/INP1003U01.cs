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
using IHIS.Framework;
using IHIS.NURI;
#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// INP1003U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP1003U01 : IHIS.Framework.XScreen
    {
        #region 자동생성

        private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XDisplayBox dbxHeader;
		private IHIS.Framework.XDisplayBox dbxBody;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XDatePicker dtpReserDate;
		private IHIS.Framework.XFindBox fbxBunho;
		private IHIS.Framework.XDisplayBox dbxSuname;
		private IHIS.Framework.XFindBox fbxGwa;
		private IHIS.Framework.XDisplayBox dbxGwaName;
		private IHIS.Framework.XFindBox fbxDoctor;
        private IHIS.Framework.XDisplayBox dbxDoctorName;
		private IHIS.Framework.SingleLayout layBunhoDupCheck;
		private IHIS.Framework.SingleLayout layBunhoValidation;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XEditGrid grdINP1003;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        //private IHIS.Framework.DataServiceMISO dsvUpdate;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
        //private IHIS.Framework.DataServiceSIMO dsvQryReser;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.SingleLayout layDelete;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XLabel xLabel7;
		private IHIS.Framework.XTextBox txtRemark;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XButton btnTransIpwonsi;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XDisplayBox dbxJisiDoctorName;
		private IHIS.Framework.XFindBox fbxJisiDoctor;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XTextBox txtSangBigo;
		private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XButton btnSang;
		private IHIS.Framework.XFindBox fbxSang;
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
        private SingleLayout layIpwonMokjuk;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;

        #endregion
        private XDisplayBox dbxHoDong;
        private XButton btnBedButton;
        private XDisplayBox dbxHoCode;
        private XLabel xLabel9;
        private SingleLayoutItem singleLayoutItem13;
        private XEditGridCell xEditGridCell20;
        private XTextBox txtSex;
        private XDisplayBox dbxBedNo;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XPanel pnlLeft;
        private XPanel pnlRight;
        private XButton btnOutSang;
        private XButton btnIpwonOrder;
        private XLabel xLabel10;
        private XDisplayBox xDisplayBox1;
        private XDictComboBox cboEmergency_add;
        private XTextBox txtEmegency_add_etc;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private IContainer components;

		public INP1003U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}

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

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1003U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.txtEmegency_add_etc = new IHIS.Framework.XTextBox();
            this.cboEmergency_add = new IHIS.Framework.XDictComboBox();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xDisplayBox1 = new IHIS.Framework.XDisplayBox();
            this.btnOutSang = new IHIS.Framework.XButton();
            this.dbxBedNo = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtSex = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxHoDong = new IHIS.Framework.XDisplayBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.btnBedButton = new IHIS.Framework.XButton();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dbxHoCode = new IHIS.Framework.XDisplayBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.dtpReserDate = new IHIS.Framework.XDatePicker();
            this.txtSangBigo = new IHIS.Framework.XTextBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.fbxSang = new IHIS.Framework.XFindBox();
            this.fbxGwa = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.btnSang = new IHIS.Framework.XButton();
            this.dbxGwaName = new IHIS.Framework.XDisplayBox();
            this.dbxJisiDoctorName = new IHIS.Framework.XDisplayBox();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.fbxJisiDoctor = new IHIS.Framework.XFindBox();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.txtRemark = new IHIS.Framework.XTextBox();
            this.dbxBody = new IHIS.Framework.XDisplayBox();
            this.dbxHeader = new IHIS.Framework.XDisplayBox();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdINP1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.layBunhoDupCheck = new IHIS.Framework.SingleLayout();
            this.layBunhoValidation = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.layDelete = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnTransIpwonsi = new IHIS.Framework.XButton();
            this.layIpwonMokjuk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.btnIpwonOrder = new IHIS.Framework.XButton();
            this.xPanel1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "32_3.ico");
            this.ImageList.Images.SetKeyName(4, "처방.ico");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.pnlRight);
            this.xPanel1.Controls.Add(this.pnlLeft);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(4, 4);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(693, 456);
            this.xPanel1.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.txtEmegency_add_etc);
            this.pnlRight.Controls.Add(this.cboEmergency_add);
            this.pnlRight.Controls.Add(this.xLabel10);
            this.pnlRight.Controls.Add(this.xDisplayBox1);
            this.pnlRight.Controls.Add(this.btnOutSang);
            this.pnlRight.Controls.Add(this.dbxBedNo);
            this.pnlRight.Controls.Add(this.xLabel1);
            this.pnlRight.Controls.Add(this.txtSex);
            this.pnlRight.Controls.Add(this.xLabel2);
            this.pnlRight.Controls.Add(this.dbxHoDong);
            this.pnlRight.Controls.Add(this.xLabel3);
            this.pnlRight.Controls.Add(this.btnBedButton);
            this.pnlRight.Controls.Add(this.xLabel4);
            this.pnlRight.Controls.Add(this.dbxHoCode);
            this.pnlRight.Controls.Add(this.xLabel5);
            this.pnlRight.Controls.Add(this.xLabel9);
            this.pnlRight.Controls.Add(this.dtpReserDate);
            this.pnlRight.Controls.Add(this.txtSangBigo);
            this.pnlRight.Controls.Add(this.fbxBunho);
            this.pnlRight.Controls.Add(this.xLabel8);
            this.pnlRight.Controls.Add(this.dbxSuname);
            this.pnlRight.Controls.Add(this.fbxSang);
            this.pnlRight.Controls.Add(this.fbxGwa);
            this.pnlRight.Controls.Add(this.btnSang);
            this.pnlRight.Controls.Add(this.dbxGwaName);
            this.pnlRight.Controls.Add(this.dbxJisiDoctorName);
            this.pnlRight.Controls.Add(this.fbxDoctor);
            this.pnlRight.Controls.Add(this.fbxJisiDoctor);
            this.pnlRight.Controls.Add(this.dbxDoctorName);
            this.pnlRight.Controls.Add(this.xLabel6);
            this.pnlRight.Controls.Add(this.xLabel7);
            this.pnlRight.Controls.Add(this.txtRemark);
            this.pnlRight.Controls.Add(this.dbxBody);
            this.pnlRight.Controls.Add(this.dbxHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(307, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(386, 456);
            this.pnlRight.TabIndex = 108;
            // 
            // txtEmegency_add_etc
            // 
            this.txtEmegency_add_etc.Location = new System.Drawing.Point(11, 405);
            this.txtEmegency_add_etc.Multiline = true;
            this.txtEmegency_add_etc.Name = "txtEmegency_add_etc";
            this.txtEmegency_add_etc.Size = new System.Drawing.Size(362, 44);
            this.txtEmegency_add_etc.TabIndex = 111;
            this.txtEmegency_add_etc.Visible = false;
            // 
            // cboEmergency_add
            // 
            this.cboEmergency_add.ItemHeight = 13;
            this.cboEmergency_add.Location = new System.Drawing.Point(11, 383);
            this.cboEmergency_add.MaxDropDownItems = 11;
            this.cboEmergency_add.Name = "cboEmergency_add";
            this.cboEmergency_add.Size = new System.Drawing.Size(362, 21);
            this.cboEmergency_add.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboEmergency_add.TabIndex = 109;
            this.cboEmergency_add.UserSQL = resources.GetString("cboEmergency_add.UserSQL");
            this.cboEmergency_add.SelectedValueChanged += new System.EventHandler(this.cboEmergency_add_SelectedValueChanged);
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel10.Location = new System.Drawing.Point(11, 350);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(362, 31);
            this.xLabel10.TabIndex = 21;
            this.xLabel10.Text = "  重症加算に適用される場合は、下記のア～コの中で該当するものを選択してください。";
            // 
            // xDisplayBox1
            // 
            this.xDisplayBox1.BackColor = IHIS.Framework.XColor.XDataGridSelectionBackColor;
            this.xDisplayBox1.Location = new System.Drawing.Point(11, 350);
            this.xDisplayBox1.Name = "xDisplayBox1";
            this.xDisplayBox1.Size = new System.Drawing.Size(362, 99);
            this.xDisplayBox1.TabIndex = 108;
            // 
            // btnOutSang
            // 
            this.btnOutSang.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.btnOutSang.ImageIndex = 3;
            this.btnOutSang.ImageList = this.ImageList;
            this.btnOutSang.Location = new System.Drawing.Point(24, 255);
            this.btnOutSang.Name = "btnOutSang";
            this.btnOutSang.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOutSang.Size = new System.Drawing.Size(338, 27);
            this.btnOutSang.TabIndex = 107;
            this.btnOutSang.Text = "患 者 傷 病 登 録";
            this.btnOutSang.Click += new System.EventHandler(this.btnOutSang_Click);
            // 
            // dbxBedNo
            // 
            this.dbxBedNo.Location = new System.Drawing.Point(272, 178);
            this.dbxBedNo.Name = "dbxBedNo";
            this.dbxBedNo.Size = new System.Drawing.Size(38, 21);
            this.dbxBedNo.TabIndex = 106;
            this.dbxBedNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xLabel1.Image")));
            this.xLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel1.Location = new System.Drawing.Point(265, 12);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(100, 21);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "入院予約";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel1.Visible = false;
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(250, 72);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(100, 20);
            this.txtSex.TabIndex = 105;
            this.txtSex.Visible = false;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel2.Location = new System.Drawing.Point(25, 75);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(94, 20);
            this.xLabel2.TabIndex = 3;
            this.xLabel2.Text = "入院予定日";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHoDong
            // 
            this.dbxHoDong.Location = new System.Drawing.Point(147, 178);
            this.dbxHoDong.Name = "dbxHoDong";
            this.dbxHoDong.Size = new System.Drawing.Size(70, 21);
            this.dbxHoDong.TabIndex = 104;
            this.dbxHoDong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel3.Location = new System.Drawing.Point(25, 49);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(94, 20);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "患 者 番 号";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBedButton
            // 
            this.btnBedButton.Image = ((System.Drawing.Image)(resources.GetObject("btnBedButton.Image")));
            this.btnBedButton.Location = new System.Drawing.Point(122, 177);
            this.btnBedButton.Name = "btnBedButton";
            this.btnBedButton.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnBedButton.Size = new System.Drawing.Size(25, 23);
            this.btnBedButton.TabIndex = 101;
            this.btnBedButton.Click += new System.EventHandler(this.btnBedButton_Click);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel4.Location = new System.Drawing.Point(25, 101);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(94, 20);
            this.xLabel4.TabIndex = 5;
            this.xLabel4.Text = "診   療   科";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxHoCode
            // 
            this.dbxHoCode.Location = new System.Drawing.Point(217, 178);
            this.dbxHoCode.Name = "dbxHoCode";
            this.dbxHoCode.Size = new System.Drawing.Size(55, 21);
            this.dbxHoCode.TabIndex = 103;
            this.dbxHoCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel5.Location = new System.Drawing.Point(25, 127);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(94, 20);
            this.xLabel5.TabIndex = 6;
            this.xLabel5.Text = "主   治   医";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Location = new System.Drawing.Point(25, 178);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(94, 20);
            this.xLabel9.TabIndex = 102;
            this.xLabel9.Text = "病     棟";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpReserDate
            // 
            this.dtpReserDate.IsJapanYearType = true;
            this.dtpReserDate.Location = new System.Drawing.Point(121, 75);
            this.dtpReserDate.Name = "dtpReserDate";
            this.dtpReserDate.Size = new System.Drawing.Size(108, 20);
            this.dtpReserDate.TabIndex = 1;
            this.dtpReserDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpReserDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpReserDate_DataValidating);
            // 
            // txtSangBigo
            // 
            this.txtSangBigo.ApplyByteLimit = true;
            this.txtSangBigo.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSangBigo.Location = new System.Drawing.Point(121, 284);
            this.txtSangBigo.MaxLength = 1000;
            this.txtSangBigo.Multiline = true;
            this.txtSangBigo.Name = "txtSangBigo";
            this.txtSangBigo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSangBigo.Size = new System.Drawing.Size(218, 50);
            this.txtSangBigo.TabIndex = 20;
            // 
            // fbxBunho
            // 
            this.fbxBunho.AutoTabDataSelected = true;
            this.fbxBunho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxBunho.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxBunho.Location = new System.Drawing.Point(121, 49);
            this.fbxBunho.MaxLength = 9;
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Size = new System.Drawing.Size(108, 20);
            this.fbxBunho.TabIndex = 0;
            this.fbxBunho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxBunho_DataValidating);
            this.fbxBunho.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxBunho_FindClick);
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel8.Location = new System.Drawing.Point(25, 284);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(94, 50);
            this.xLabel8.TabIndex = 21;
            this.xLabel8.Text = "病名コメント";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxSuname
            // 
            this.dbxSuname.Location = new System.Drawing.Point(231, 49);
            this.dbxSuname.Name = "dbxSuname";
            this.dbxSuname.Size = new System.Drawing.Size(128, 20);
            this.dbxSuname.TabIndex = 9;
            // 
            // fbxSang
            // 
            this.fbxSang.Location = new System.Drawing.Point(335, 286);
            this.fbxSang.Name = "fbxSang";
            this.fbxSang.Size = new System.Drawing.Size(25, 20);
            this.fbxSang.TabIndex = 23;
            this.fbxSang.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxSang_FindClick);
            // 
            // fbxGwa
            // 
            this.fbxGwa.AutoTabDataSelected = true;
            this.fbxGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGwa.FindWorker = this.fwkCommon;
            this.fbxGwa.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxGwa.Location = new System.Drawing.Point(121, 101);
            this.fbxGwa.MaxLength = 2;
            this.fbxGwa.Name = "fbxGwa";
            this.fbxGwa.Size = new System.Drawing.Size(64, 20);
            this.fbxGwa.TabIndex = 2;
            this.fbxGwa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxGwa_DataValidating);
            this.fbxGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxGwa_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.HeaderText = "コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 214;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "コード名称";
            // 
            // btnSang
            // 
            this.btnSang.ImageIndex = 2;
            this.btnSang.ImageList = this.ImageList;
            this.btnSang.Location = new System.Drawing.Point(339, 306);
            this.btnSang.Name = "btnSang";
            this.btnSang.Size = new System.Drawing.Size(23, 28);
            this.btnSang.TabIndex = 22;
            this.btnSang.Click += new System.EventHandler(this.btnSang_Click);
            // 
            // dbxGwaName
            // 
            this.dbxGwaName.Location = new System.Drawing.Point(187, 101);
            this.dbxGwaName.Name = "dbxGwaName";
            this.dbxGwaName.Size = new System.Drawing.Size(172, 20);
            this.dbxGwaName.TabIndex = 11;
            // 
            // dbxJisiDoctorName
            // 
            this.dbxJisiDoctorName.Location = new System.Drawing.Point(231, 153);
            this.dbxJisiDoctorName.Name = "dbxJisiDoctorName";
            this.dbxJisiDoctorName.Size = new System.Drawing.Size(128, 20);
            this.dbxJisiDoctorName.TabIndex = 19;
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.ApplyByteLimit = true;
            this.fbxDoctor.AutoTabDataSelected = true;
            this.fbxDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxDoctor.FindWorker = this.fwkCommon;
            this.fbxDoctor.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxDoctor.Location = new System.Drawing.Point(121, 127);
            this.fbxDoctor.MaxLength = 20;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.Size = new System.Drawing.Size(108, 20);
            this.fbxDoctor.TabIndex = 3;
            this.fbxDoctor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
            // 
            // fbxJisiDoctor
            // 
            this.fbxJisiDoctor.ApplyByteLimit = true;
            this.fbxJisiDoctor.AutoTabDataSelected = true;
            this.fbxJisiDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJisiDoctor.EnableEdit = false;
            this.fbxJisiDoctor.FindWorker = this.fwkCommon;
            this.fbxJisiDoctor.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fbxJisiDoctor.Location = new System.Drawing.Point(121, 153);
            this.fbxJisiDoctor.MaxLength = 20;
            this.fbxJisiDoctor.Name = "fbxJisiDoctor";
            this.fbxJisiDoctor.Protect = true;
            this.fbxJisiDoctor.ReadOnly = true;
            this.fbxJisiDoctor.Size = new System.Drawing.Size(108, 20);
            this.fbxJisiDoctor.TabIndex = 4;
            this.fbxJisiDoctor.TabStop = false;
            this.fbxJisiDoctor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxJisiDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJisiDoctor_DataValidating);
            this.fbxJisiDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxJisiDoctor_FindClick);
            // 
            // dbxDoctorName
            // 
            this.dbxDoctorName.Location = new System.Drawing.Point(231, 127);
            this.dbxDoctorName.Name = "dbxDoctorName";
            this.dbxDoctorName.Size = new System.Drawing.Size(128, 20);
            this.dbxDoctorName.TabIndex = 13;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel6.Location = new System.Drawing.Point(25, 153);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(94, 20);
            this.xLabel6.TabIndex = 18;
            this.xLabel6.Text = "指   示   医";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel7.Location = new System.Drawing.Point(25, 203);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(94, 50);
            this.xLabel7.TabIndex = 16;
            this.xLabel7.Text = "備     考";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemark
            // 
            this.txtRemark.ApplyByteLimit = true;
            this.txtRemark.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtRemark.Location = new System.Drawing.Point(121, 203);
            this.txtRemark.MaxLength = 4000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(238, 50);
            this.txtRemark.TabIndex = 5;
            // 
            // dbxBody
            // 
            this.dbxBody.BackColor = IHIS.Framework.XColor.XDataGridSelectionBackColor;
            this.dbxBody.Location = new System.Drawing.Point(11, 42);
            this.dbxBody.Name = "dbxBody";
            this.dbxBody.Size = new System.Drawing.Size(362, 298);
            this.dbxBody.TabIndex = 1;
            // 
            // dbxHeader
            // 
            this.dbxHeader.BackColor = IHIS.Framework.XColor.XDataGridSelectionBackColor;
            this.dbxHeader.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxHeader.Location = new System.Drawing.Point(11, 6);
            this.dbxHeader.Name = "dbxHeader";
            this.dbxHeader.Size = new System.Drawing.Size(362, 34);
            this.dbxHeader.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdINP1003);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(307, 456);
            this.pnlLeft.TabIndex = 107;
            // 
            // grdINP1003
            // 
            this.grdINP1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell10,
            this.xEditGridCell3,
            this.xEditGridCell11,
            this.xEditGridCell4,
            this.xEditGridCell12,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell15,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell19,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell7,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell16});
            this.grdINP1003.ColPerLine = 3;
            this.grdINP1003.Cols = 4;
            this.grdINP1003.ControlBinding = true;
            this.grdINP1003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1003.FixedCols = 1;
            this.grdINP1003.FixedRows = 1;
            this.grdINP1003.HeaderHeights.Add(28);
            this.grdINP1003.Location = new System.Drawing.Point(0, 0);
            this.grdINP1003.Name = "grdINP1003";
            this.grdINP1003.QuerySQL = resources.GetString("grdINP1003.QuerySQL");
            this.grdINP1003.ReadOnly = true;
            this.grdINP1003.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINP1003.RowHeaderVisible = true;
            this.grdINP1003.Rows = 2;
            this.grdINP1003.Size = new System.Drawing.Size(307, 456);
            this.grdINP1003.TabIndex = 2;
            this.grdINP1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1003_QueryStarting);
            this.grdINP1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINP1003_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.BindControl = this.dtpReserDate;
            this.xEditGridCell1.CellName = "reser_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "予約日";
            this.xEditGridCell1.IsJapanYearType = true;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.Bisque);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "bunho";
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "suname";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "suname";
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.fbxGwa;
            this.xEditGridCell3.CellName = "gwa";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "gwa";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.dbxGwaName;
            this.xEditGridCell11.CellName = "gwa_name";
            this.xEditGridCell11.CellWidth = 99;
            this.xEditGridCell11.Col = 2;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "診療科";
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.Color.Bisque);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.fbxDoctor;
            this.xEditGridCell4.CellName = "doctor";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "doctor";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.dbxDoctorName;
            this.xEditGridCell12.CellName = "doctor_name";
            this.xEditGridCell12.Col = 3;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "主治医";
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "tel";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "tel";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "tel2";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "tel2";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pkinp1001";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "pkinp1001";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "pkinp1003";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "pkinp1003";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.BindControl = this.txtRemark;
            this.xEditGridCell15.CellLen = 4000;
            this.xEditGridCell15.CellName = "remark";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "remark";
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ipwon_mokjuk";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "ipwon_mokjuk";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "ipwonsi_order_yn";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "ipwonsi_order_yn";
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.txtSangBigo;
            this.xEditGridCell19.CellLen = 1000;
            this.xEditGridCell19.CellName = "sang_bigo";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "sang_bigo";
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.BindControl = this.fbxJisiDoctor;
            this.xEditGridCell17.CellLen = 20;
            this.xEditGridCell17.CellName = "jisi_doctor";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "jisi_doctor";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.dbxJisiDoctorName;
            this.xEditGridCell18.CellName = "jisi_doctor_name";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "jisi_doctor_name";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.BindControl = this.txtSex;
            this.xEditGridCell20.CellName = "sex";
            this.xEditGridCell20.CellWidth = 29;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "sex";
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "ho_dong";
            this.xEditGridCell21.CellWidth = 49;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "ho_dong";
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.BindControl = this.dbxHoDong;
            this.xEditGridCell25.CellName = "ho_dong_name";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "ho_dong_name";
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.BindControl = this.dbxHoCode;
            this.xEditGridCell26.CellName = "ho_code";
            this.xEditGridCell26.CellWidth = 46;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "ho_code";
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.BindControl = this.dbxBedNo;
            this.xEditGridCell27.CellName = "bed_no";
            this.xEditGridCell27.CellWidth = 48;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.HeaderText = "bed_no";
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "reser_yn";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "reser_yn";
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "doc_yn";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.HeaderText = "doc_yn";
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.BindControl = this.cboEmergency_add;
            this.xEditGridCell29.CellName = "emergency_gubun";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.HeaderText = "救急医療管理加算";
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.BindControl = this.txtEmegency_add_etc;
            this.xEditGridCell30.CellLen = 500;
            this.xEditGridCell30.CellName = "emergency_detail";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.HeaderText = "加算その他";
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "dummy";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "dummy";
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // layBunhoValidation
            // 
            this.layBunhoValidation.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8,
            this.singleLayoutItem9,
            this.singleLayoutItem13,
            this.singleLayoutItem10});
            this.layBunhoValidation.QuerySQL = resources.GetString("layBunhoValidation.QuerySQL");
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "suname";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "tel";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "tel2";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "delete_yn";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "jubsu_break";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "code_name";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "sex";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "flag";
            // 
            // layDelete
            // 
            this.layDelete.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            this.layDelete.QuerySQL = "SELECT A.BUNHO\r\n     , A.RESER_FKINP1001\r\n     , A.RESER_DATE\r\n  FROM INP1003 A\r\n" +
                " WHERE A.HOSP_CODE = :f_hosp_code\r\n   AND A.PKINP1003 = :f_pkinp1003\r\n   AND A.R" +
                "ESER_END_TYPE = \'0\'";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "bunho";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "fkinp1001";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "reser_date";
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.F7, "新規予約", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.F3, "削 除", 0, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.F8, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.ImageList = this.ImageList;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(205, 464);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(494, 34);
            this.btnList.TabIndex = 3;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // btnTransIpwonsi
            // 
            this.btnTransIpwonsi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransIpwonsi.ImageIndex = 1;
            this.btnTransIpwonsi.ImageList = this.ImageList;
            this.btnTransIpwonsi.Location = new System.Drawing.Point(6, 466);
            this.btnTransIpwonsi.Name = "btnTransIpwonsi";
            this.btnTransIpwonsi.Size = new System.Drawing.Size(136, 30);
            this.btnTransIpwonsi.TabIndex = 4;
            this.btnTransIpwonsi.Text = "入院時オーダに変更";
            this.btnTransIpwonsi.Visible = false;
            this.btnTransIpwonsi.Click += new System.EventHandler(this.btnTransIpwonsi_Click);
            // 
            // layIpwonMokjuk
            // 
            this.layIpwonMokjuk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem11,
            this.singleLayoutItem12});
            this.layIpwonMokjuk.QuerySQL = "SELECT A.IPWON_MOKJUK\r\n     , A.IPWONSI_ORDER_YN\r\n  FROM INP1003 A\r\n WHERE A.HOSP" +
                "_CODE = :f_hosp_code\r\n   AND A.PKINP1003 = :f_pkinp1003";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "ipwon_mokjuk";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "ipwonsi_order_yn";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "ho_code";
            this.xEditGridCell22.Col = 6;
            this.xEditGridCell22.HeaderText = "ho_code";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "bed_no";
            this.xEditGridCell23.Col = 7;
            this.xEditGridCell23.HeaderText = "bed_no";
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "ho_dong";
            this.xEditGridCell24.Col = 8;
            this.xEditGridCell24.HeaderText = "ho_dong_name";
            // 
            // btnIpwonOrder
            // 
            this.btnIpwonOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIpwonOrder.ImageIndex = 4;
            this.btnIpwonOrder.ImageList = this.ImageList;
            this.btnIpwonOrder.Location = new System.Drawing.Point(6, 466);
            this.btnIpwonOrder.Name = "btnIpwonOrder";
            this.btnIpwonOrder.Size = new System.Drawing.Size(136, 30);
            this.btnIpwonOrder.TabIndex = 5;
            this.btnIpwonOrder.Text = "入院オーダ登録";
            this.btnIpwonOrder.Click += new System.EventHandler(this.btnIpwonOrder_Click);
            // 
            // INP1003U01
            // 
            this.Controls.Add(this.btnIpwonOrder);
            this.Controls.Add(this.btnTransIpwonsi);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel1);
            this.Name = "INP1003U01";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(701, 500);
            this.Load += new System.EventHandler(this.INP1003U01_Load);
            this.xPanel1.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

		private string mMsg = "";
		private string mCap = "";

		private string mParamBunho     = "";
		private string mParamDoctor    = "";
        private string mParamJisiDoctor = "";
		private string mParamGwa       = "";
		private string mParamReserDate = "";
        private string mFKOUT1001 = "";
		private string mJaewonFlag     = "N";

		private string mReserStatus    = "0"; /* 0: 신규, 1:일반예약, 2:입원시예약 */

		#endregion

		#region Screen Load

		private void INP1003U01_Load(object sender, System.EventArgs e)
		{
			this.InitScreen();

            this.grdINP1003.SavePerformer = new XSavePerformer(this);
            
			if (this.OpenParam == null)
			{
				XPatientInfo patientInfo = XScreen.GetOtherScreenBunHo(sender, true);

				if (patientInfo != null)
				{
					this.fbxBunho.SetEditValue(patientInfo.BunHo);
					this.fbxBunho.AcceptData();
				}
				else
				{
					this.ControlProtect();

					this.fbxBunho.Focus();
				}
				
			}

		}

		#endregion

		#region OpenScreen_OUT0101Q01

		private void OpenScreen_OUT0101Q01 ()
		{
			XScreen.OpenScreen(this, "OUT0101Q01", ScreenOpenStyle.ResponseFixed);
		}

		#endregion

		#region Function 

		#region InitScreen 

		private void InitScreen ()
		{
			if (this.OpenParam != null)
			{
				#region 파라미터 셋팅

				if (this.OpenParam.Contains("doctor"))
				{
					this.mParamDoctor = this.OpenParam["doctor"].ToString();
                    this.mParamJisiDoctor = this.OpenParam["doctor"].ToString();
				}

				if (this.OpenParam.Contains("reser_date"))
				{
					this.mParamReserDate = this.OpenParam["reser_date"].ToString();
				}

                if (this.OpenParam.Contains("gwa"))
                {
                    this.mParamGwa = this.OpenParam["gwa"].ToString();

                    bool result = IsIpwonPossibleGwa(this.mParamGwa);

                    if (!result)
                    {
                        this.mParamGwa = "";
                        this.mParamDoctor = "";
                    }
                }

				if (this.OpenParam.Contains("bunho") )
				{
					this.mParamBunho = this.OpenParam["bunho"].ToString();

					this.fbxBunho.SetEditValue(this.mParamBunho);
					this.fbxBunho.AcceptData();
				}

                if (this.OpenParam.Contains("fkout1001"))
                {
                    this.mFKOUT1001 = this.OpenParam["fkout1001"].ToString();
                }
				#endregion
			}
			else
			{
				// 그리드 초기화
				this.InitGrid();
			}
		}

		#endregion

		#region InitGrid

		private void InitGrid ()
		{
			string reserDate = this.dtpReserDate.GetDataValue();

			if (this.grdINP1003.RowCount > 0)
			{
				this.grdINP1003.Reset();
			}

			this.ClearData();
			
		}

		#endregion

		#region JaewonCheck

		private string JaewonPatientYN (string aBunho, string aReserDate)
		{
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add("2"); //I_GUBUN
            inputList.Add(aBunho); //I_BUNHO
            inputList.Add(aReserDate); //I_IPWON_DATE
            inputList.Add(""); //I_IPWON_TYPE

            if (!Service.ExecuteProcedure("PR_INP_LOAD_JAEWON_PKINP1001", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return "";
            }

            ///IO_PKINP1001       IN OUT NUMBER,  IO_JAEWON_FLAG     IN OUT VARCHAR2,  IO_FLAG            IN OUT VARCHAR2

            this.mJaewonFlag = "";
            if (!TypeCheck.IsNull(outputList[1]))
                this.mJaewonFlag = outputList[1].ToString();

            return mJaewonFlag;
		}

		#endregion

		#region ClearData

		private void ClearData()
		{
			this.mJaewonFlag = "N";

			this.mReserStatus = "0";

			//this.InitGrid();

			this.dbxHeader.SetDataValue("");

			this.btnTransIpwonsi.Visible = false;
		}

		#endregion

		#region ControlProtect

		private void ControlProtect ()
		{
			if (this.grdINP1003.RowCount > 0)
			{
				switch (this.mReserStatus)
				{
					case "0":    // 신규 예약
						this.dtpReserDate.Protect  = false;
						this.fbxDoctor.Protect     = false;

						this.fbxGwa.Protect        = false;
						//this.fbxJisiDoctor.Protect = false;
						break;
					case "1":    // 일반예약

						this.dtpReserDate.Protect  = true;
						this.fbxDoctor.Protect     = true;
						this.fbxGwa.Protect        = true;
						//this.fbxJisiDoctor.Protect = true;

						break;
					case "2":    // 예약완료

						// 예약한 선생님이 아닌경우는 아무것도 변경못함.
                        if (UserInfo.DoctorID == this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "doctor"))
						{
							this.dtpReserDate.Protect = false;
						}
						else
						{
							this.dtpReserDate.Protect = true;
						}
						this.fbxDoctor.Protect     = true;
						this.fbxGwa.Protect        = true;
						//this.fbxJisiDoctor.Protect = true;

						break;
				}

				if (this.OpenParam != null)
				{
					this.fbxBunho.Protect = true;
					//this.fbxGwa.Protect   = true;
				}
				else
				{
					this.fbxBunho.Protect = false;
				}
			}
			else
			{
				this.fbxBunho.Protect      = false;
				this.dtpReserDate.Protect  = true;
				this.fbxDoctor.Protect     = true;
				this.fbxGwa.Protect        = true;
				//this.fbxJisiDoctor.Protect = true;
				this.txtRemark.Protect     = true;
			}
		}

		#endregion

		#region CheckReserDate

		private bool CheckReserDate (string aReserDate)
		{
            //DateTime today = DateTime.Parse(INP.GetName.GetSysDate().Replace("-", "/"));
            DateTime today = EnvironInfo.GetSysDate();
			DateTime reserDate ;

			if (TypeCheck.IsDateTime(aReserDate))
			{
				reserDate = DateTime.Parse(aReserDate);

				if (today > reserDate) return false;
			}
			else
			{
				return false;
			}
			
			return true;
		}

		#endregion

		#region 저장전 INP3003 데이터 체크

		private bool CheckINP3003Data ()
		{
            if (DateTime.Parse(this.dtpReserDate.GetDataValue()) == EnvironInfo.GetSysDate())
            {
                if (this.cboEmergency_add.GetDataValue() == "")
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "구급의료관리가산을 체크해주세요." : "予定入院以外の場合は、緊急医療管理加算をチェックしてください。入力しますか？";
                    this.mCap = NetInfo.Language == LangMode.Ko ? "확인" : "確認";

                    if(XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        return false;
                }
            }
			for (int i=0; i<this.grdINP1003.RowCount; i++)
			{
				this.mMsg = this.grdINP1003.GetItemString(i, "reser_date") + " " + this.grdINP1003.GetItemString(i, "gwa_name") + " " ;
				if (this.grdINP1003.GetItemString(i, "reser_date") == "")
				{
					this.mMsg = NetInfo.Language == LangMode.Ko ? "예약일자를 입력해 주세요." : "予約日付けを入力してください。";
					this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}

				if (this.grdINP1003.GetItemString(i, "bunho") == "")
				{
					this.mMsg = NetInfo.Language == LangMode.Ko ? "환자번호를 입력하십시오." : "患者番号を入力してください。";
					this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}

				if (this.grdINP1003.GetItemString(i, "gwa") == "")
				{
					this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과를 입력해 주세요" : "診療科を入力してください。";
					this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}

				if (this.grdINP1003.GetItemString(i, "doctor") == "")
				{
					this.mMsg = NetInfo.Language == LangMode.Ko ? "주치의를 입력해 주세요." : "主治医を入力してください。";
					this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}

				if (this.CheckReserDate(this.grdINP1003.GetItemString(i, "reser_date")) == false)
				{
					this.mMsg = NetInfo.Language == LangMode.Ko ? "예약일자가 유효하지 않습니다." : "予約日付が有効ではありません。";
					this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return false;
				}
			}

			this.mMsg = "";
			this.mCap = "";

			return true;

		}

		#endregion

		#region Invoke_COMMAND 

		private void Invoke_COMMAND(string aPkinp1001, string aReserDate, string aBunho, string aCommand)
		{
			if (this.Opener != null)
			{
				if (this.Opener is XScreen)
				{
					CommonItemCollection commandParam = new CommonItemCollection();

					commandParam.Add("pkinp1001" , aPkinp1001);
					commandParam.Add("reser_date", aReserDate);
					commandParam.Add("bunho"     , aBunho    );

					((XScreen)this.Opener).Command(aCommand, commandParam);
				}
			}			
		}

		#endregion

		#region InsertNewData 

		private void InsertNewData ()
		{
			this.grdINP1003.InsertRow(-1);

			if (this.OpenParam != null)
			{
				this.dtpReserDate.SetEditValue(this.mParamReserDate);
				this.dtpReserDate.AcceptData();

				this.fbxGwa.SetEditValue(this.mParamGwa);
				this.fbxGwa.AcceptData();

				this.fbxDoctor.SetEditValue(this.mParamDoctor);
				this.fbxDoctor.AcceptData();

                this.fbxJisiDoctor.SetEditValue(this.mParamJisiDoctor);
				this.fbxJisiDoctor.AcceptData();

				this.fbxBunho.SetDataValue(this.mParamBunho);
				this.dbxSuname.SetDataValue(NURI.Methodes.GetSUNAME(this.mParamBunho));
				this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber,"bunho", this.mParamBunho);
			}
			else
			{
				this.dtpReserDate.SetEditValue(EnvironInfo.GetSysDate());
				this.dtpReserDate.AcceptData();

				this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "bunho", this.fbxBunho.GetDataValue());

				// 진료과와 주치의 로그인 아이디가 의사인 경우 디폴트 셋팅
				if (UserInfo.UserGubun == UserType.Doctor)
				{
					this.fbxGwa.SetEditValue(UserInfo.Gwa);
					this.fbxGwa.AcceptData();

                    this.fbxDoctor.SetEditValue(UserInfo.DoctorID);
					this.fbxDoctor.AcceptData();

                    this.fbxJisiDoctor.SetEditValue(UserInfo.DoctorID);
					this.fbxJisiDoctor.AcceptData();
				}
			}
		}

		#endregion

		#region SelectDoctor 

		/// <summary>
		/// 조회 완료후 의사 선택
		/// </summary>
		/// <param name="aDoctor"> 로그인 의사 </param>
		private void SelectDoctor (string aDoctor)
		{
			for (int i=0; i<this.grdINP1003.RowCount; i++)
			{
				if (this.grdINP1003.GetItemString(i, "doctor") == aDoctor)
				{
					this.grdINP1003.SetFocusToItem(i, "reser_date");
					break;
				}
			}
		}

		#endregion

		#endregion

		#region DataLoad

		private void LoadReserData (string aBunho)
        {
            this.grdINP1003.SetBindVarValue("f_bunho", aBunho);

            this.grdINP1003.QueryLayout(false);

			if (this.grdINP1003.RowCount <= 0)
			{
				this.fbxBunho.SetDataValue(aBunho);

				this.btnList.PerformClick(FunctionType.Insert);
			}

            this.SelectDoctor(UserInfo.DoctorID);
		}

		#endregion

		#region Cancel ReserVation

		private bool CancelReserVation ()
		{
            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();
            string pkinp1003 = this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1003");

            /* 오더 삭제 */
            this.layDelete.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDelete.SetBindVarValue("f_pkinp1003", pkinp1003);

            this.layDelete.QueryLayout();

            if (this.layDelete.GetItemValue("bunho").ToString() == "")
            {
                XMessageBox.Show(EnvironInfo.GetServerMsg(2109));
                return false;
            }

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(UserInfo.DoctorID);
            inputList.Add(this.layDelete.GetItemValue("bunho").ToString());
            inputList.Add(this.layDelete.GetItemValue("fkinp1001").ToString());

            try
            {
                Service.BeginTransaction();

                if (!Service.ExecuteProcedure("PR_OCS_DELETE_INP_ORDER_RES", inputList, outputList))
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "취소에 실패 하였습니다." : "取消に失敗しました。";
                    this.mMsg += "-" + Service.ErrFullMsg;
                    this.mCap = NetInfo.Language == LangMode.Ko ? "취소완료" : "取消失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                if (TypeCheck.IsNull(outputList[1]))
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "취소에 실패 하였습니다." : "取消に失敗しました。";
                    this.mMsg += "-" + Service.ErrFullMsg;
                    this.mCap = NetInfo.Language == LangMode.Ko ? "취소완료" : "取消失敗";

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                if (!TypeCheck.IsNull(outputList))
                {
                    if (outputList[1].ToString() == "0" || outputList[1].ToString() == "1")
                    {
                        /* 입원 목적 조회 */
                        this.layIpwonMokjuk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                        this.layIpwonMokjuk.SetBindVarValue("f_pkinp1003", pkinp1003);

                        this.layIpwonMokjuk.QueryLayout();


                        /* INP1003 삭제 */
                        /* 입원목적이 입원시 오더가 아닌경우는 Reser_Fkinp1001만 NULL로 한다 */
                        if (this.layIpwonMokjuk.GetItemValue("ipwonsi_order_yn").ToString() == "Y")
                        {
                            cmdText = @"UPDATE INP1003 A
                                       SET A.RESER_END_TYPE = '5'   /* 예약 취소 */
                                         , A.RESER_END_DATE = SYSDATE
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.PKINP1003 = :f_pkinp1003";
                        }
                        else
                        {
                            cmdText = @"UPDATE INP1003 A
                                       SET A.RESER_FKINP1001 = NULL  /* RESER_FKINP1001 만 NULL로 한다 */
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.PKINP1003 = :f_pkinp1003";
                        }

                        bc.Add("f_hosp_code", EnvironInfo.HospCode);
                        bc.Add("f_pkinp1003", pkinp1003);

                        if (!Service.ExecuteNonQuery(cmdText, bc))
                            throw new Exception();

                        Service.CommitTransaction();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch 
            {
                Service.RollbackTransaction();
                this.mMsg += "-" + (TypeCheck.IsNull(outputList[0]) ? "" : outputList[0].ToString()) + " " + Service.ErrFullMsg;
                this.mCap = NetInfo.Language == LangMode.Ko ? "취소완료" : "取消失敗";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }


            this.mMsg = NetInfo.Language == LangMode.Ko ? "입원예약이 정상적으로 취소 되었습니다." : "取消処理が完了しました。";
            this.mCap = NetInfo.Language == LangMode.Ko ? "취소완료" : "取消完了";

            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
		}

		#endregion

		#region UpdateData

		/// <summary>
		/// 저장시 처리 함수
		///    저장시 조회해온 데이터 혹은 만들어진 데이터는 
		///    데이터를 만든경우는 날라 가겠지만 조회해온 데이터인경우 
		///    상황에 따라서 날리거나 날리지 말아야 함
		///    
		///       만들어진 경우 - 무조건 날아감
		///       조회해온 경우 
		///           - 일반예약건의 경우 : 무조건 날아감
		///           - 입원시 오더의경우 : 변경 사항이 있는 경우만 날아감
		/// </summary>
		/// <returns></returns>
		private bool UpdateData ()
		{
			this.AcceptData();

			if (this.grdINP1003.SaveLayout())
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "정상적으로 저장 되었습니다." : "保存が完了しました。");
				XMessageBox.Show(this.mMsg, "保存完了",MessageBoxIcon.Information);

				return true;
			}
			else
			{
				this.mMsg = "保存に失敗しました。\r\n" + this.mErrMsg + "\r\n" + Service.ErrFullMsg;
				XMessageBox.Show(this.mMsg, "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		#endregion

		#region XButtonList
		
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			DialogResult result ;

			switch (e.Func)
			{
				case FunctionType.Query :

					#region 조회

					e.IsBaseCall = false;

					// 컨트롤 프로텍트
					this.LoadReserData(this.fbxBunho.GetDataValue());

					#endregion

					break;

				case FunctionType.Delete :

					#region 삭제

					e.IsBaseCall = false;

					if (this.grdINP1003.GetRowState(grdINP1003.CurrentRowNumber) == DataRowState.Added)
					{
						this.grdINP1003.DeleteRow(grdINP1003.CurrentRowNumber);
					}
					else
					{
						// 수정 20080827 홍선희
						// 지시의도 삭제할수 있도록 수정
                        // 科関係なくする。
                        if (   UserInfo.UserID != this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "doctor").Substring(2)
                            && UserInfo.UserID != this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "jisi_doctor").Substring(2))
						{
							this.mMsg = "【"+this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "doctor") + "】" +
								        this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber,"doctor_name") + 
								        (NetInfo.Language == LangMode.Ko ? "선생님의 예약건 입니다.삭제가 불가능합니다." : "先生の予約件です。削除出来ません。");
							this.mCap = NetInfo.Language == LangMode.Ko ? "삭제불가" : "削除不可";

							XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

							return;
						}

						if (this.mReserStatus != "2")
						{
							this.mMsg = (NetInfo.Language == LangMode.Ko ? "예약완료 상태에서만 예약취소가 가능합니다." : "予約完了状態のみ予約取消が可能です。");
							this.mCap = (NetInfo.Language == LangMode.Ko ? "예약취소" : "予約取消");

							XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

							return;
						}

						this.mMsg = (NetInfo.Language == LangMode.Ko ? "입원예약이 변경되면 이전 오더가 삭제 됩니다. 예약을 변경 하시겠습니까?" : 
                                                                       "入院予約が削除されると、以前オーダは削除されます。\n予約を変更しますか？");
						this.mCap = (NetInfo.Language == LangMode.Ko ? "경고" : "警告");

						result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2, MessageBoxIcon.Warning);

						if (result == DialogResult.Yes)
						{
							if (this.CancelReserVation())
							{
								this.btnList.PerformClick(FunctionType.Query);

								if (this.OpenParam != null)
								{
									this.Invoke_COMMAND("", "", "", "INP1003U01_DELETE");

									this.btnList.PerformClick(FunctionType.Close);
								}
							}
						}
					}

					#endregion

					break;

				case FunctionType.Update :

					#region 저장 

					e.IsBaseCall = false;

					if (this.CheckINP3003Data() == true)
					{
						for (int i= 0; i<this.grdINP1003.RowCount; i++)
						{
							if (this.grdINP1003.GetRowState(i) == DataRowState.Modified)
							{
								if (this.grdINP1003.GetItemString(i, "reser_date") != 
									this.grdINP1003.GetItemString(i, "reser_date", DataBufferType.OriginalBuffer))
								{
									this.mMsg = this.grdINP1003.GetItemString(i, "reser_date") + " " + this.grdINP1003.GetItemString(i, "gwa_name") + " " + 
										(NetInfo.Language == LangMode.Ko ? "입원예정일 변경시 예약오더는 전부 삭제 처리 됩니다.\n(단, 치료계획은 삭제되지 않습니다.)\n예약일 변경을 하시겠습니까?"
										: "入院予定日変更時、予約オーダは全部削除処理されます。\n(但し、ＣＰ計画は削除されません。)\n予約日変更をしますか？");
									this.mCap = (NetInfo.Language == LangMode.Ko ? "예약일 변경" : "予定日変更");

									result = XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

									if (result != DialogResult.Yes)
									{
										return ;
									}

								}
							}
						}

						if (this.grdINP1003.GetRowState(this.grdINP1003.CurrentRowNumber) == DataRowState.Unchanged &&
							TypeCheck.IsNull(this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001")))
						{
							this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "dummy", "Y");
						}
						if (this.UpdateData())
						{
							// 같은 날에는 예약건이 1건만 존재 하므로 날짜로 이전에 선택된 행을 체크 한다.
							string selectedDate = this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "reser_date");

							this.btnList.PerformClick(FunctionType.Query);

							for (int i=0; i<this.grdINP1003.RowCount; i++)
							{
								if (this.grdINP1003.GetItemString(i, "reser_date") == selectedDate)
								{
									this.grdINP1003.SetFocusToItem(i, "reser_date");
									break;
								}
							}

							// 현재 선택된 로우의 의사 ID가 로그인한 ID와 틀릴 경우 물어본다.
                            if (UserInfo.DoctorID != this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "doctor"))
							{
								this.mMsg = "【"+this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "doctor") + "】" +
									this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber,"doctor_name") + 
									(NetInfo.Language == LangMode.Ko ? "선생님의 예약건 입니다. 입원시 오더를 입력하시겠습니까?"
									: "先生の予約件です。入院時オーダーを入力しますか？");
								this.mCap = NetInfo.Language == LangMode.Ko ? "입원시오더" : "入院時オーダー";

								if (DialogResult.Yes != XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
								{
									return;
								}
							}
							// 저장 완료후 주기오더 창 ( 입원시 오더 창 오픈)
							if (this.OpenParam != null)
                            {

                                CommonItemCollection openParams = new CommonItemCollection();
                                openParams.Add("bunho", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "bunho").Trim());
                                openParams.Add("fkinp1001", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001").Trim());
                                openParams.Add("reser_date", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "reser_date").Trim());
                                openParams.Add("acting_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                                //if (this.grdINP1003.GetItemString(this.grdINP1003.CurrentRowNumber, "doc_yn") != "Y")
                                //{
                                //    //문서관리
                                //    XScreen.OpenScreenWithParam(this, "DOCS", "DOC2001U00", ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
                                //}
                                if (XMessageBox.Show("今、「" + dbxSuname.Text + "」の入院オーダーを登録しますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
								    this.Invoke_COMMAND(this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001"),
									    this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "reser_date"),
									    this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "bunho")       ,
									    "INP1003U01");
                                }
								this.btnList.PerformClick(FunctionType.Close);
							}
							else
							{
								if (grdINP1003.CurrentRowNumber >= 0 &&
									!TypeCheck.IsNull(this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001" )) &&
									!TypeCheck.IsNull(this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "reser_date")) && 
									!TypeCheck.IsNull(this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "bunho"     )))
								{


									CommonItemCollection openParams = new CommonItemCollection();
									openParams.Add("bunho",      this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "bunho"     ).Trim());
									openParams.Add("naewon_key", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001" ).Trim());
									openParams.Add("order_date", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "reser_date").Trim());

                                    
                                    // 치료계획등록
                                    XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003P01", ScreenOpenStyle.ResponseSizable, ScreenAlignment.ParentTopLeft, openParams);
                                    this.btnList.PerformClick(FunctionType.Close);
								}

								
							}

						}
						else
						{
								
						}
					}

					#endregion

					break;

				case FunctionType.Insert :

					#region 신규 예약 

					e.IsBaseCall = false;

					// 환자번호가 입력되어 있지 않다면 리턴
					if (this.fbxBunho.GetDataValue() == "")
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "먼저 환자번호를 입력해 주세요." : "患者番号を入力してください。";
						this.mCap = NetInfo.Language == LangMode.Ko ? "입원예약" : "入院予約";

						XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

						this.fbxBunho.Focus();

						return;
					}

					bool isExistNewRecord = false;

					foreach (DataRow dr in this.grdINP1003.LayoutTable.Rows)
					{
						if (dr.RowState == DataRowState.Added)
						{
							isExistNewRecord = true;

							this.mMsg = NetInfo.Language == LangMode.Ko ? "새로 입력된 입원예약건이 존재 합니다. 저장후 다시 입력하세요." : "新しく入力された予約件が存在します。保存した後もう一回入力してください。";
							this.mCap = NetInfo.Language == LangMode.Ko ? "입원예약" : "入院予約";

							XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

							break;
						}
					}

					if (isExistNewRecord == true)
					{
						return ;
					}

					

					this.InsertNewData();

					#endregion

					break;

				case FunctionType.Reset :

					#region 리셋

					// 다른 화면에서 열린 경우 리셋기능 삭제
					if (this.OpenParam != null)
					{
						e.IsBaseCall = false;
					}

					#endregion

					break;

				case FunctionType.Close :

					break;
			}
		}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Reset :

					this.ControlProtect();

					this.fbxBunho.Focus();

					break;
			}
		}

		#endregion

		#region XFindBox

		#region 환자번호

		#region FindClick

		private void fbxBunho_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.OpenScreen_OUT0101Q01();
		}

		#endregion

		#region Validation

		private void fbxBunho_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "")
			{
				this.InitGrid();
				this.SetMsg("");
				return;
			}

			string bunho = e.DataValue;

			bunho = BizCodeHelper.GetStandardBunHo(bunho);

			string name = "";

            this.layBunhoValidation.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.layBunhoValidation.SetBindVarValue("f_bunho", bunho);

			this.layBunhoValidation.QueryLayout();

			name = this.layBunhoValidation.GetItemValue("suname").ToString();

			if (name == "")
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "환자번호가 정확하지않습니다. 확인바랍니다." : "患者番号が有効ではありません。";

				this.SetMsg(this.mMsg, MsgType.Error);

				e.Cancel = true;

				return;
			}
			else
			{
                if (this.dtpReserDate.GetDataValue() == "")
                    this.dtpReserDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
				if (this.JaewonPatientYN(bunho, this.dtpReserDate.GetDataValue()) == "Y")
				{
					this.mMsg = name + (NetInfo.Language == LangMode.Ko ? " 환자는 현재 재원중입니다 " : "現在在院中の患者です。");
					this.mCap = NetInfo.Language == LangMode.Ko ? "재원환자" : "在院患者";

					XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

					return;
				}

				this.LoadReserData(bunho);

				this.dbxSuname.SetDataValue(name);

				PostCallHelper.PostCall(new PostMethodStr(PostValdBunho), bunho);
			}
		}

		private void PostValdBunho (string bunho)
		{
			this.fbxBunho.SetDataValue(bunho);

			if (this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "bunho") != bunho)
			{
				this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "bunho", bunho);
			}
		}

		#endregion

		#endregion

		#region 진료과

		private void fbxGwa_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 서비스 셋팅
            this.fwkCommon.InputSQL = @"SELECT A.GWA
                                             , A.GWA_NAME
                                             , A.BUSEO_CODE
                                          FROM BAS0260 A
                                         WHERE A.HOSP_CODE   = :f_hosp_code
                                           AND A.BUSEO_GUBUN = '1'/*診療科（진료과）*/
                                           AND :f_buseo_ymd BETWEEN A.START_DATE AND A.END_DATE
                                           AND(A.GWA       LIKE '%' || :f_find1 || '%'
                                            OR A.GWA_NAME  LIKE '%' || :f_find1 || '%')
                                           AND A.IPWON_YN    = 'Y'
                                         ORDER BY A.GWA";

            // In변수 셋팅
            this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkCommon.SetBindVarValue("f_buseo_ymd", this.dtpReserDate.GetDataValue());
            this.fwkCommon.FormText = "診療科照会";
            this.fwkCommon.ColInfos.Clear();
            this.fwkCommon.ColInfos.Add("code", "診療科", FindColType.String, 100, 0, true, FilterType.InitYes);
            this.fwkCommon.ColInfos.Add("code_name", "診療科名", FindColType.String, 200, 0, true, FilterType.InitYes);
		}

        private void resetGwa()
        {
            this.fbxGwa.SetDataValue("");
        }
		private void fbxGwa_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            if (!this.IsIpwonPossibleGwa(e.DataValue))
            {
                PostCallHelper.PostCall(resetGwa); 
                e.Cancel = true;
                return;
            }

			if (e.DataValue == "")
			{
				this.dbxGwaName.SetDataValue("");

				this.SetMsg("");

				return;
			}

			string name = NURI.Methodes.GetGwaNameBAS0260(e.DataValue, this.dtpReserDate.GetDataValue());

			if (name == "")
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "진료과가 정확하지않습니다. 확인바랍니다." 
					: "診療科が有効ではありません。");
						
				this.SetMsg(this.mMsg, MsgType.Error);

				e.Cancel = true;
				
				this.dbxGwaName.SetDataValue("");
				this.fbxDoctor.SetEditValue("");
				this.fbxDoctor.AcceptData();

				return;
			}
			
			this.dbxGwaName.SetDataValue(name);
			this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "gwa_name", name);
			this.fbxDoctor.SetEditValue("");
			this.fbxDoctor.AcceptData();

		}

		#endregion

		#region 진료의

		private void fbxDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 서비스 셋팅
            this.fwkCommon.InputSQL = @"SELECT A.DOCTOR
                                             , A.DOCTOR_NAME
                                             , A.DOCTOR_GWA || A.DOCTOR            CONT_KEY
                                          FROM BAS0270 A
                                         WHERE A.HOSP_CODE   = :f_hosp_code
                                           AND DECODE(:f_gwa, '%', '%', A.DOCTOR_GWA)   = :f_gwa
                                           AND(A.DOCTOR       LIKE '%' || :f_find1 || '%'
                                            OR A.DOCTOR_NAME  LIKE '%' || :f_find1 || '%')
                                           AND :f_doctor_ymd BETWEEN A.START_DATE AND A.END_DATE
                                         ORDER BY CONT_KEY";

            // In변수 셋팅
            this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkCommon.SetBindVarValue("f_doctor_ymd", this.dtpReserDate.GetDataValue());
            this.fwkCommon.SetBindVarValue("f_gwa", this.fbxGwa.GetDataValue());
            this.fwkCommon.FormText = "医師照会";
            this.fwkCommon.ColInfos.Clear();
            this.fwkCommon.ColInfos.Add("code", "医師コード", FindColType.String, 100, 0, true, FilterType.InitYes);
            this.fwkCommon.ColInfos.Add("code_name", "医師名", FindColType.String, 200, 0, true, FilterType.InitYes);
		}

		private void fbxDoctor_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "")
			{
				this.dbxDoctorName.SetDataValue("");
				this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "doctor_name", "");

				this.SetMsg("");

				return;
			}

			string name = NURI.Methodes.GetDoctorNameBAS0270(e.DataValue , this.fbxGwa.GetDataValue(), this.dtpReserDate.GetDataValue());

			if (name == "")
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "의사코드가 정확하지않습니다. 확인바랍니다." 
					: "医師コードが有効ではありません。");
				
				this.dbxDoctorName.SetDataValue("");

				this.SetMsg(this.mMsg, MsgType.Error);

				e.Cancel = true;

				return;
			}

			this.dbxDoctorName.SetDataValue(name);
			this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "doctor_name", name);
		}

		#endregion

		#region 지시의사

		private void fbxJisiDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 서비스 셋팅
            this.fwkCommon.InputSQL = @"SELECT A.DOCTOR
                                             , A.DOCTOR_NAME
                                             , A.DOCTOR_GWA || A.DOCTOR_NAME2 || A.DOCTOR            CONT_KEY
                                          FROM BAS0270 A
                                         WHERE A.HOSP_CODE   = :f_hosp_code
                                           AND DECODE(:f_gwa, '%', '%', A.DOCTOR_GWA)   = :f_gwa
                                           AND(A.DOCTOR       LIKE '%' || :f_find1 || '%'
                                            OR A.DOCTOR_NAME  LIKE '%' || :f_find1 || '%')
                                           AND :f_doctor_ymd BETWEEN A.START_DATE AND A.END_DATE
                                         ORDER BY CONT_KEY";

            // In변수 셋팅
            this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkCommon.SetBindVarValue("f_doctor_ymd", this.dtpReserDate.GetDataValue());
            this.fwkCommon.SetBindVarValue("f_gwa", this.fbxGwa.GetDataValue());
            this.fwkCommon.FormText = "医師照会";
            this.fwkCommon.ColInfos.Clear();
            this.fwkCommon.ColInfos.Add("code", "医師コード", FindColType.String, 100, 0, true, FilterType.InitYes);
            this.fwkCommon.ColInfos.Add("code_name", "医師名", FindColType.String, 200, 0, true, FilterType.InitYes);
		}

		private void fbxJisiDoctor_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue == "")
			{
				this.dbxJisiDoctorName.SetDataValue("");
				this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "jisi_doctor_name", "");

				this.SetMsg("");

				return;
			}

            string name = NURI.Methodes.GetDoctorNameBAS0270(e.DataValue, e.DataValue.Substring(0, 2), this.dtpReserDate.GetDataValue());

			if (name == "")
			{
				this.mMsg = (NetInfo.Language == LangMode.Ko ? "의사코드가 정확하지않습니다. 확인바랍니다." 
					: "医師コードが有効ではありません。");
				
				this.dbxJisiDoctorName.SetDataValue("");

				this.SetMsg(this.mMsg, MsgType.Error);

				e.Cancel = true;

				return;
			}

			this.dbxJisiDoctorName.SetDataValue(name);
			this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "jisi_doctor_name", name);
		}

		#endregion

		#endregion

		#region XDatePicker

		private void dtpReserDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue != "" && this.CheckReserDate(e.DataValue) == false)
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "선택한 날자는 유효하지 않습니다." : "選択された日付は有効ではありません。";
				
				SetMsg(this.mMsg, MsgType.Error);

				e.Cancel = true;

				return;
			}

			this.SetMsg("");
		}

		#endregion

		#region Command

		public override object Command(string command, CommonItemCollection commandParam)
		{
			string sangName = "";
			switch (command)
			{
				case "OUT0101":

					if (commandParam != null)
					{
						this.fbxBunho.Focus();
						this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["bunho"].ToString());
                        this.fbxBunho.AcceptData();
                        this.txtSex.SetEditValue(((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["sex"].ToString());
                        this.txtSex.AcceptData();
						this.AcceptData();
						this.fbxGwa.Focus();
					}

					break;

				case "CHT0110Q01": // 상병조회					

					#region
					if (commandParam.Contains("CHT0110") && (MultiLayout)commandParam["CHT0110"] != null && 
						((MultiLayout)commandParam["CHT0110"]).RowCount > 0)
					{
						foreach(DataRow row in ((MultiLayout)commandParam["CHT0110"]).LayoutTable.Rows)
						{
							sangName = txtSangBigo.Text;
							sangName += row["sang_name"].ToString() + "\r\n";
							txtSangBigo.SetDataValue(sangName);
							grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "sang_bigo", sangName);
						}
					}

					break;	
					#endregion

				case "OCS0204Q00": // 사용자 약속상병조회					

					#region
					if (commandParam.Contains("OCS0205") && (MultiLayout)commandParam["OCS0205"] != null && 
						((MultiLayout)commandParam["OCS0205"]).RowCount > 0)
					{
						foreach(DataRow row in ((MultiLayout)commandParam["OCS0205"]).LayoutTable.Rows)
						{							
							sangName = txtSangBigo.Text;
							sangName += row["sang_name"].ToString() + "\r\n";
							txtSangBigo.SetDataValue(sangName);
							grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "sang_bigo", sangName);
						}
					}

					break;

                case "BAS0250Q00":
                    this.dbxHoDong.SetDataValue(NURI.Methodes.GetGwaNameBAS0260(commandParam["ho_dong"].ToString()
                        , this.dtpReserDate.GetDataValue()));
                    this.dbxHoCode.SetDataValue(commandParam["ho_code"].ToString());
                    this.dbxBedNo.SetDataValue(commandParam["bed_no"].ToString());
                    //this.cboHoGrade1.SetDataValue(commandParam["ho_grade"].ToString());

                    this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "ho_dong", commandParam["ho_dong"].ToString());
                    this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "ho_code", commandParam["ho_code"].ToString());
                    this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "bed_no", commandParam["bed_no"].ToString());
                    //this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "ho_grade1", commandParam["ho_grade"].ToString());

                    break;

					#endregion

			}

			return base.Command (command, commandParam);
		}

		#endregion

		#region 현Screen의 등록번호,성명,부서,병동 스크린명를 타Screen에 넘긴다
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.fbxBunho.GetDataValue()))
				return new XPatientInfo(this.fbxBunho.GetDataValue() , this.dbxSuname.GetDataValue(), this.fbxGwa.GetDataValue(), null,null,PatientPKGubun.None, this.ScreenName);
			return base.OnRequestBunHo ();
		}
		#endregion 

		#region 환자 번호를 받아온다

		public override void OnReceiveBunHo(XPatientInfo info)
		{
			this.ClearData();

			this.fbxBunho.SetEditValue(info.BunHo);
			this.fbxBunho.AcceptData();

			base.OnReceiveBunHo (info);
		}

		#endregion

		#region XEditGrid 

		private void grdINP1003_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (this.grdINP1003.GetRowState(e.CurrentRow) == DataRowState.Added)
			{
				this.dbxHeader.SetDataValue("   ▶ 予約状態 : 新規予約 ");

				this.mReserStatus = "0";

				//2009.01.29 저장버튼으로 통합처리
				//this.btnTransIpwonsi.Visible = false;
			}
			else
			{
				if (this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001") == "")
				{
					this.dbxHeader.SetDataValue("   ▶ 予約状態 : 一般予約存在 ");

					this.mReserStatus = "1";

					//2009.01.29 저장버튼으로 통합처리
					//if (this.grdINP1003.GetItemString(e.CurrentRow, "doctor") == UserInfo.UserID)
						//this.btnTransIpwonsi.Visible = true;
				}
				else
				{
					this.dbxHeader.SetDataValue("   ▶ 予約状態 : 予約完了 ");

					this.mReserStatus = "2";

					//2009.01.29 저장버튼으로 통합처리
					//this.btnTransIpwonsi.Visible = false;
				}
			}

			this.ControlProtect();		
		}

		#endregion

		#region XButton

		private void btnTransIpwonsi_Click(object sender, System.EventArgs e)
		{
			if (this.grdINP1003.CurrentRowNumber >=0)
			{
				this.grdINP1003.SetItemValue(grdINP1003.CurrentRowNumber, "dummy", "Y");

				this.btnList.PerformClick(FunctionType.Update);
			}
		}

		#endregion

		private void fbxSang_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (TypeCheck.IsNull(fbxBunho.GetDataValue())) return;

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("sang_inx", fbxSang.GetDataValue());

            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseSizable, openParams);
		
		}

		private void btnSang_Click(object sender, System.EventArgs e)
		{
			if ( TypeCheck.IsNull( fbxBunho.GetDataValue() ) ) return;

			CommonItemCollection openParams  = new CommonItemCollection();

			openParams.Add("sang_code", "");
            openParams.Add("memb", IHIS.Framework.UserInfo.DoctorID);

			//사용자조회 화면 Open
			XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseSizable, openParams);
		
		}

        private void grdINP1003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP1003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void IpwonSiksaInput(string aIUD_GUBUN, string aDATA_DATE, string aPKINP1001, string aBUNHO)
        {
            try
            {
                Service.BeginTransaction();
                /*
                 I_HOSP_CODE   IN VARCHAR2
                , I_PKINP1001   IN NUMBER
                , I_BUNHO       IN NUMBER
                , I_IPWON_DATE  IN DATE
                , I_IUD_GUBUN   IN VARCHAR2
                 */
                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();

                inputList.Add(EnvironInfo.HospCode);
                inputList.Add(aPKINP1001);
                inputList.Add(aBUNHO);
                inputList.Add(aDATA_DATE);
                inputList.Add(aIUD_GUBUN);

                if (!Service.ExecuteProcedure("PR_OCS_INIT_CREATE_SIKSA", inputList, outputList))
                {
                    throw new Exception();
                    //return;
                }
                else
                    Service.CommitTransaction();
            }
            catch
            {
                Service.RollbackTransaction();
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        #region XSavePerformer
        string mErrMsg;
        private class XSavePerformer : ISavePerformer
        {
            private INP1003U01 parent;

            public XSavePerformer(INP1003U01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                parent.mErrMsg = "";
                object pkinp1001 = null;
                object pkinp1003 = null;

                item.BindVarList.Add("q_user_id", UserInfo.DoctorID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                /* 서비스 들어가기전에 체크 사항 
                - 예약일자 : 과거 일자 불가
                - 진료과, 주치의 코드 체크  */

                /* 예약일자 */
                DateTime tReserDate = DateTime.Parse(item.BindVarList["f_reser_date"].VarValue);

                if (tReserDate < EnvironInfo.GetSysDate())
                {
                    /* 예약일자가 유효하지 않습니다.*/
                    parent.mErrMsg = EnvironInfo.GetServerMsg(3739);
                    return false;
                }

                /* 진료과 */
                cmdText = @"SELECT 'Y'
                              FROM SYS.DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM BAS0260 A
                                            WHERE A.HOSP_CODE = :f_hosp_code
                                              AND A.GWA       = :f_gwa
                                              AND NVL(:f_reser_date, TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE )";

                object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                if (!TypeCheck.IsNull(retVal))
                {
                    if (retVal.ToString() != "Y")
                    {
                        /* 진료과가 정확하지않습니다. 확인바랍니다.*/
                        parent.mErrMsg = EnvironInfo.GetServerMsg(241);
                        return false;
                    }
                }

                /* 주치의 */
                cmdText = @"SELECT 'Y'
                              FROM SYS.DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM BAS0270 A
                                            WHERE A.HOSP_CODE  = :f_hosp_code
                                              AND A.DOCTOR     = :f_doctor
                                              AND A.DOCTOR_GWA = :f_gwa
                                              AND NVL(:f_reser_date, TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE )";
                retVal = null;
                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                if (!TypeCheck.IsNull(retVal))
                {
                    if (retVal.ToString() != "Y")
                    {
                        /* 진료과가 정확하지않습니다. 확인바랍니다.*/
                        parent.mErrMsg = EnvironInfo.GetServerMsg(2080);
                        return false;
                    }
                }

                switch (item.RowState)
                { 
                    case DataRowState.Added:

                        Service.BeginTransaction();

                        try
                        {
                            if (item.BindVarList["f_bunho"].VarValue == "")
                            {
                                /* 환자번호를 입력하십시오.*/
                                parent.mErrMsg = EnvironInfo.GetServerMsg(290);
                                return false;
                            }

                            /****************************환자번호 유효성체크 */
                            string tErrMsg = "";
                            if (NURI.Methodes.ChkBunho(item.BindVarList["f_bunho"].VarValue, ref tErrMsg) != "0")
                            {
                                parent.mErrMsg = tErrMsg;
                                return false;
                            }


                            /*****************************예약중인 환자 체크 */
                            cmdText = @"SELECT 'Y'
                                      FROM SYS.DUAL
                                     WHERE EXISTS ( SELECT 'X'
                                                      FROM INP1003 A
                                                     WHERE A.HOSP_CODE = :f_hosp_code
                                                       AND A.BUNHO     = :f_bunho
                                                       AND A.RESER_END_TYPE = '0' )";
                            retVal = null;
                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if (!TypeCheck.IsNull(retVal))
                            {
                                if (retVal.ToString() == "Y")
                                {
                                    parent.mErrMsg = item.BindVarList["f_bunho"].VarValue + " " + EnvironInfo.GetServerMsg(3162);
                                    return false;
                                }
                            }


                            /*****************************재원중인 환자 체크 */
                            if (NURI.Methodes.IsJaewon(item.BindVarList["f_bunho"].VarValue, item.BindVarList["f_reser_date"].VarValue) == "Y")
                            {
                                /* 환자는 현재 재원 중입니다. */
                                parent.mErrMsg = EnvironInfo.GetServerMsg(293);
                                return false;
                            }

                            /*****************************진료과 NULL 체크 */
                            if (item.BindVarList["f_gwa"].VarValue == "")
                            {
                                /* 진료과 정보가 없습니다. 확인해 주세요.*/
                                parent.mErrMsg = EnvironInfo.GetServerMsg(297);
                                return false;
                            }

                            /*****************************주치의 NULL 체크 */
                            if (item.BindVarList["f_doctor"].VarValue == "")
                            {
                                /* 주치의 정보가 없습니다. 확인해 주세요.*/
                                parent.mErrMsg = EnvironInfo.GetServerMsg(298);
                                return false;
                            }


                            /*****************************PKINP1003 Key 생성 */
                            cmdText = @"SELECT INP1003_SEQ.NEXTVAL FROM SYS.DUAL";

                            pkinp1003 = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(pkinp1003))
                            {
                                parent.mErrMsg = "PKINP1003の生成に失敗しました。";
                                return false;
                            }

                            item.BindVarList.Add("t_pkinp1003", pkinp1003.ToString());

                            /*****************************전표 데이트 Load   */
                            item.BindVarList.Add("t_junpyo_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));


                            /*****************************입원키 발생 pkinp1001 */
                            cmdText = @"SELECT INP1001_SEQ.NEXTVAL FROM SYS.DUAL";

                            pkinp1001 = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(pkinp1001))
                            {
                                parent.mErrMsg = "pkinp1001の生成に失敗しました。";
                                return false;
                            }

                            item.BindVarList.Add("f_reser_fkinp1001", pkinp1001.ToString());


                            cmdText = @"SELECT A.TEL
                                      FROM OUT0101 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.BUNHO     = :f_bunho";

                            object tel = Service.ExecuteScalar(cmdText, item.BindVarList);

                            string tTel = "";
                            if (!TypeCheck.IsNull(tel))
                                tTel = tel.ToString();

                            item.BindVarList.Add("f_tel", tTel);
                            item.BindVarList.Add("f_fkout1001", parent.mFKOUT1001);
                            
                            /*****************************PKINP1003 INSERT   */

                            cmdText = @"INSERT INTO INP1003
                                         ( SYS_DATE            , SYS_ID            , UPD_DATE          , UPD_ID
                                         , HOSP_CODE           , PKINP1003         , JUNPYO_DATE       , BUNHO
                                         , TEL1                , TEL2              , RESER_DATE        , GWA
                                         , DOCTOR              , HO_CODE           , RESER_END_TYPE    , SUSUL_RESER_YN
                                         , IPWON_RTN2          , HO_DONG           , BED_NO            , RESER_FKINP1001  
                                         , IPWONSI_ORDER_YN    , REMARK            , JISI_DOCTOR       , SANG_BIGO
                                         , EMERGENCY_GUBUN     , EMERGENCY_DETAIL  , FKOUT1001)
                                    VALUES
                                        ( SYSDATE           , :q_user_id        , SYSDATE           , :q_user_id
                                        , :f_hosp_code      , :t_pkinp1003      , :t_junpyo_date    , :f_bunho
                                        , :f_tel            , :f_tel            , :f_reser_date     , :f_gwa
                                        , :f_doctor         , :f_ho_code        , '0' /* 予約中 */  , 'N'
                                        , '1' /*外来*/      , :f_ho_dong        , :f_bed_no         , :f_reser_fkinp1001
                                        , 'Y' /*入院時可否*/, :f_remark         , :f_jisi_doctor    , :f_sang_bigo     
                                        , :f_emergency_gubun  , :f_emergency_detail, :f_fkout1001    )/* 오키나와 추가 변수 */";
                            Service.ExecuteNonQuery(cmdText, item.BindVarList);
                        }
                        catch
                        {
                            Service.RollbackTransaction();
                        }

                        Service.CommitTransaction();

                        // IpwonSiksaInput(string aIUD_GUBUN, string aDATA_DATE, string aPKINP1001, string aBUNHO)
                        parent.IpwonSiksaInput("I", item.BindVarList["f_reser_date"].VarValue, item.BindVarList["f_reser_fkinp1001"].VarValue, item.BindVarList["f_bunho"].VarValue);
                        break;



                    case DataRowState.Modified:
                        /* 수정 로직 */
                        /* 1 예약일자 비교 동일한 날자인 경우 업데이트 처리
                         * 2 오더 삭제
                         * 3 예약건 삭제
                         * 4 예약 생성 - 입원키 새로 생성
                         */

                        /* 일반 예약후 입원시 오더 입력시 */
                        /* 1. 예약키로 조회후 Reser_Fkinp1001 키가 없다면 일반예약건
                         * 2. 오더 삭제 및 예약건 삭제는 하지 말고
                         * 3. 기존 예약 건에 inp1001 업데이트 */

                        /*****************************재원중인 환자 체크 */
                        Service.BeginTransaction();

                        try
                        {
                            if (NURI.Methodes.IsJaewon(item.BindVarList["f_bunho"].VarValue, item.BindVarList["f_reser_date"].VarValue) == "Y")
                            {
                                /* 환자는 현재 재원 중입니다. */
                                parent.mErrMsg = EnvironInfo.GetServerMsg(293);
                                return false;
                            }

                            /* 입원예약건 조회 */
                            cmdText = @"SELECT A.RESER_FKINP1001    RESER_FKINP1001
                                         , CASE WHEN A.RESER_DATE = :f_reser_date THEN 'Y'
                                                                                  ELSE 'N'  
                                           END            FLAG
                                         , A.RESER_DATE   OLD_RESER_DATE
                                      FROM INP1003 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.PKINP1003 = :f_pkinp1003
                                       AND A.RESER_END_TYPE = '0' /* 予約中、예약중 */";

                            DataTable dt = Service.ExecuteDataTable(cmdText, item.BindVarList);

                            //기존 예약건이 일반 예약건인 경우 
                            if (TypeCheck.IsNull(dt) || (!TypeCheck.IsNull(dt) && dt.Rows[0]["reser_fkinp1001"].ToString() == ""))
                            {
                                //동일 일자인 경우  - 업데이트 만.
                                if (!TypeCheck.IsNull(dt) && dt.Rows[0]["flag"].ToString() == "Y")
                                {
                                    /*****************************입원키 발생 pkinp1001 */
                                    cmdText = @"SELECT INP1001_SEQ.NEXTVAL FROM SYS.DUAL";

                                    pkinp1001 = Service.ExecuteScalar(cmdText);

                                    if (TypeCheck.IsNull(pkinp1001))
                                    {
                                        parent.mErrMsg = "PKINP1001の生成に失敗しました。";
                                        return false;
                                    }

                                    item.BindVarList.Add("f_reser_fkinp1001", pkinp1001.ToString());

                                    /* INP1003 업데이트 */
                                    cmdText = @"UPDATE INP1003
        	    	                           SET UPD_DATE         = SYSDATE
        	    	                             , UPD_ID           = :q_user_id
        	    	                             , IPWON_MOKJUK     = '17'
        	    	                             , RESER_FKINP1001  = :f_reser_fkinp1001
        	    	                             , REMARK           = :f_remark
        	    	                             , SANG_BIGO        = :f_sang_bigo
        	    	                             , IPWONSI_ORDER_YN = 'Y'
                                                 , EMERGENCY_GUBUN  = :f_emergency_gubun
                                                 , EMERGENCY_DETAIL = :f_emergency_detail
        	    	                         WHERE HOSP_CODE        = :f_hosp_code
                                               AND PKINP1003        = :f_pkinp1003 ";

                                }
                                else //다른 일자인 경우  - 다른 일자인 경우 새로 만든다.
                                {
                                    /* 예약건 삭제 */
                                    cmdText = @"UPDATE INP1003 A
                       	                   SET A.RESER_END_TYPE = '5'   /* 予約取り消し、예약 취소 */
                       	                     , A.RESER_END_DATE = SYSDATE
                       	                 WHERE A.HOSP_CODE      = :f_hosp_code
                                           AND A.PKINP1003      = :f_pkinp1003
                                           --AND 1 = 2 
                                           ";

                                    if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                    {
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        //if(Service.ErrFullMsg != "No Data Changed")
                                    }

                                    /* 새로운 예약 생성 */
                                    /*****************************PKINP1003 Key 생성 */
                                    cmdText = @"SELECT INP1003_SEQ.NEXTVAL FROM SYS.DUAL";

                                    pkinp1003 = Service.ExecuteScalar(cmdText);

                                    if (TypeCheck.IsNull(pkinp1003))
                                    {
                                        parent.mErrMsg = "PKINP1003の生成に失敗しました。";
                                        return false;
                                    }

                                    item.BindVarList.Add("t_pkinp1003", pkinp1003.ToString());


                                    /*****************************전표 데이트 Load   */
                                    item.BindVarList.Add("t_junpyo_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));


                                    /*****************************입원키 발생 pkinp1001 */
                                    cmdText = @"SELECT INP1001_SEQ.NEXTVAL FROM SYS.DUAL";

                                    pkinp1001 = Service.ExecuteScalar(cmdText);

                                    if (TypeCheck.IsNull(pkinp1001))
                                    {
                                        parent.mErrMsg = "PKINP1001の生成に失敗しました。";
                                        return false;
                                    }

                                    item.BindVarList.Add("f_reser_fkinp1001", pkinp1001.ToString());
                                    item.BindVarList.Add("f_fkout1001", parent.mFKOUT1001);

                                    /*****************************PKINP1003 INSERT   */
                                    cmdText = @"INSERT INTO INP1003
                                                 ( SYS_DATE             , SYS_ID              , UPD_DATE          , UPD_ID
                                                 , HOSP_CODE            , PKINP1003           , JUNPYO_DATE       , BUNHO
                                                 , TEL1                 , TEL2                , RESER_DATE        , GWA
                                                 , DOCTOR               , HO_CODE             , RESER_END_TYPE    , SUSUL_RESER_YN
                                                 , IPWON_RTN2           , HO_DONG             , BED_NO            , IPWON_MOKJUK
                                                 , RESER_FKINP1001      , IPWONSI_ORDER_YN    , REMARK            , JISI_DOCTOR           
                                                 , SANG_BIGO            , EMERGENCY_GUBUN     , EMERGENCY_DETAIL  , FKOUT1001)
                                            VALUES
                                                 ( SYSDATE              , :q_user_id          , SYSDATE           , :q_user_id
                                                 , :f_hosp_code         , :t_pkinp1003        , :t_junpyo_date    , :f_bunho
                                                 , :f_tel               , :f_tel2             , :f_reser_date     , :f_gwa
                                                 , :f_doctor            , :f_ho_code          , '0'/* 예약중 */   , 'N'
                                                 , '1'                  , :f_ho_dong          , :f_bed_no         , '17'   /* 오늘만 디폴트 */
                                                 , :f_reser_fkinp1001   , 'Y'/* 입원시 오더 여부 */  , :f_remark, :f_jisi_doctor        
                                                 , :f_sang_bigo         , :f_emergency_gubun    , :f_emergency_detail , :f_fkout1001)";
                                }

                            }
                            else //기존 예약건이 입원시 오더인 경우
                            {
                                if (!TypeCheck.IsNull(dt))
                                {
                                    /* 기존 입원시 예약건이 있고 동일 일자인경우는 그냥 업데이트 만 */
                                    if (dt.Rows[0]["flag"].ToString() == "Y")
                                    {
                                        cmdText = @"UPDATE INP1003
        				                           SET UPD_DATE     = SYSDATE
        				                             , UPD_ID       = :q_user_id
        				                             , DOCTOR       = :f_doctor
        				                             , REMARK       = :f_remark
        				                             , JISI_DOCTOR  = :f_jisi_doctor
        				                             , SANG_BIGO    = :f_sang_bigo
                                                     , HO_DONG      = :f_ho_dong
                                                     , HO_CODE      = :f_ho_code
                                                     , BED_NO       = :f_bed_no
                                                     , EMERGENCY_GUBUN  = :f_emergency_gubun
                                                     , EMERGENCY_DETAIL = :f_emergency_detail
        				                         WHERE HOSP_CODE    = :f_hosp_code
                                                   AND PKINP1003    = :f_pkinp1003";
                                    }
                                    else
                                    {
                                        /* 기존 예약건이 존재하는 경우는 기존오더 및 예약건 삭제 */
                                        /* 오더 삭제 */

                                        /* INP1003에서 환자번호와 INP1001 키 받아옮. */
                                        cmdText = @"SELECT A.BUNHO            BUNHO
                                                     , A.RESER_FKINP1001  RESER_FKINP1001
                                                  FROM INP1003 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND A.PKINP1003 = :f_pkinp1003
                                                   AND A.RESER_END_TYPE = '0' ";
                                        DataTable dt1 = Service.ExecuteDataTable(cmdText, item.BindVarList);

                                        string tBunho = "";
                                        string tFKINP1001 = "";

                                        if (!TypeCheck.IsNull(dt1) && dt1.Rows.Count > 0)
                                        {
                                            tBunho = dt1.Rows[0]["bunho"].ToString();
                                            tFKINP1001 = dt1.Rows[0]["reser_fkinp1001"].ToString();

                                            ArrayList input = new ArrayList();
                                            ArrayList output = new ArrayList();

                                            input.Add(tBunho);
                                            input.Add(tFKINP1001);
                                            input.Add(dt.Rows[0]["old_reser_date"].ToString());
                                            input.Add(item.BindVarList["f_reser_date"].VarValue);
                                            input.Add(UserInfo.DoctorID);

                                            Service.ExecuteProcedure("PR_OCS_ALTER_RESER_INPWON_DATE", input, output);

                                            if (output[1].ToString() == "0" || output[1].ToString() == "1")
                                            {
                                                cmdText = @"UPDATE INP1003 A
                        	                               SET A.UPD_ID      = :q_user_id
                        	                                 , A.UPD_DATE    = SYSDATE
                        	                                 , A.GWA         = :f_gwa
                        	                                 , A.DOCTOR      = :f_doctor
                        	                                 , A.RESER_DATE  = :f_reser_date 
                        	                                 , A.REMARK      = :f_remark 
                        	                                 , A.JISI_DOCTOR = :f_jisi_doctor
                        	                                 , A.SANG_BIGO   = :f_sang_bigo
                                                             , HO_DONG      = :f_ho_dong
                                                             , HO_CODE      = :f_ho_code
                                                             , BED_NO       = :f_bed_no
                                                             , EMERGENCY_GUBUN  = :f_emergency_gubun
                                                             , EMERGENCY_DETAIL = :f_emergency_detail
                        	                             WHERE A.HOSP_CODE   = :f_hosp_code
                                                           AND A.PKINP1003   = :f_pkinp1003";
                                            }
                                        }
                                        else
                                        {
                                            /* 입원시 오더 예약건을 찾을 수 없습니다. */
                                            parent.mErrMsg = EnvironInfo.GetServerMsg(2109);
                                            return false;
                                        }

                                    }
                                }
                            }

                            Service.ExecuteNonQuery(cmdText, item.BindVarList);
                        }
                        catch
                        {
                            Service.RollbackTransaction();
                        }
                        
                        Service.CommitTransaction();

                        //parent.IpwonSiksaInput("D", item.BindVarList["f_reser_date"].VarValue, item.BindVarList["f_pkinp1001"].VarValue, item.BindVarList["f_bunho"].VarValue);
                        parent.IpwonSiksaInput("I", item.BindVarList["f_reser_date"].VarValue, item.BindVarList["f_pkinp1001"].VarValue, item.BindVarList["f_bunho"].VarValue);

                        break;
                    case DataRowState.Deleted:

                        Service.ExecuteNonQuery(cmdText, item.BindVarList);
                        break;

                }
                return true;
                
            }
        }
        #endregion
        /// <summary>
        /// 베드 선택 화면 오픈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBedButton_Click(object sender, System.EventArgs e)
        {
            if (this.grdINP1003.RowCount <= 0 || fbxBunho.GetDataValue() == "")
            {
                return;
            }

            CommonItemCollection param = new CommonItemCollection();

            param.Add("ho_dong", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "ho_dong"));
            param.Add("ipwon_date", dtpReserDate.GetDataValue());
            param.Add("accept_use_bed", "Y");
            param.Add("sex", this.txtSex);

            XScreen.OpenScreenWithParam(this, "BASS", "BAS0250Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void btnOutSang_Click(object sender, EventArgs e)
        {
            if(this.fbxBunho.Text == "")
                return;

            CommonItemCollection openParams = new CommonItemCollection();
            //openParams.Add("naewon_date", this.grdInp1001.GetItemDateTime(this.grdInp1001.CurrentRowNumber, "ipwon_date").ToString("yyyy/MM/dd"));
            openParams.Add("bunho", this.fbxBunho.GetDataValue());
            openParams.Add("io_gubun", "O");
            //openParams.Add("gwa", this.layNUR1001A.GetItemValue("gwa").ToString());
            XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGU00", ScreenOpenStyle.ResponseSizable, openParams);

        }

        private void btnIpwonOrder_Click(object sender, EventArgs e)
        {
            if (grdINP1003.CurrentRowNumber < 0)
                return;

            if(TypeCheck.IsNull(this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001")))
            {
                XMessageBox.Show("まだ保存されていない情報ですので入院オーダ登録できません。\r\n保存してください。", "未登録情報", MessageBoxIcon.Information);
            }
            else
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "bunho").Trim());
                openParams.Add("naewon_key", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "pkinp1001").Trim());
                openParams.Add("order_date", this.grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "reser_date").Trim());

                // 入院オーダ登録
                XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003P01", ScreenOpenStyle.ResponseSizable, ScreenAlignment.ParentTopLeft, openParams);
            }
        }

        private void cboEmergency_add_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboEmergency_add.GetDataValue() == "10")
                this.txtEmegency_add_etc.Visible = true;
            else
            {
                this.txtEmegency_add_etc.Visible = false;
                this.txtEmegency_add_etc.Text = "";
            }
        }

        private bool IsIpwonPossibleGwa(string aGWA)
        {
            if (aGWA == "")
                return true;

            string cmd = @"
                           SELECT 'X' 
                             FROM BAS0260 A
                            WHERE A.HOSP_CODE   = :f_hosp_code
                              AND A.BUSEO_GUBUN = '1'/*診療科（진료과）*/
                              AND :f_buseo_ymd BETWEEN A.START_DATE AND A.END_DATE
                              AND A.GWA         = :f_gwa
                              AND A.IPWON_YN    = 'Y'
                            ORDER BY A.GWA"
                ;

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_buseo_ymd", this.mParamReserDate);
            bind.Add("f_gwa", aGWA);

            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj == null)
            {
                this.fbxGwa.SetDataValue("");
                return false;
            }
            return true;
        }

    }
}

