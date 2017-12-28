#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// NUR2004U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR2004U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private Hashtable mBedRadio = new Hashtable();
		private string FindName = string.Empty;
		private int mPkinp1001 = 0;
		private int mTrans_cnt = 0;
		private string mHodong = string.Empty;
        private string mTotalBed = string.Empty;
		#endregion
	
		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel8;
		private IHIS.Framework.XPatientBox ptbPatient;
		private System.Windows.Forms.ImageList imageList1;
		private IHIS.Framework.XDatePicker dtpJukyong_date;
		private IHIS.Framework.XDisplayBox dpbFromGwa;
		private IHIS.Framework.XDisplayBox dpbFromGwaName;
		private IHIS.Framework.XDisplayBox dpbFromDoctorName;
		private IHIS.Framework.XDisplayBox dpbFromDoctor;
		private IHIS.Framework.XDisplayBox dpbFromHodong;
		private IHIS.Framework.XDisplayBox dpbFromHocode;
        private IHIS.Framework.XDisplayBox dpbFromBed;
		private IHIS.Framework.XFindBox fbxToGwa;
		private IHIS.Framework.XFindBox fbxToDoctor;
		private IHIS.Framework.XFindBox fbxToHoDong;
		private IHIS.Framework.XDisplayBox dpbToGwa;
		private IHIS.Framework.XDisplayBox dpbToDoctor;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XPanel pnlToBed;
        private IHIS.Framework.XFindWorker fwkFind;
		private IHIS.Framework.XFindBox fbxToHoCode;
		private IHIS.Framework.XButton btnConfirm;
		private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XPanel pnlToJunip;
		private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XLabel xLabel13;
		private IHIS.Framework.XDisplayBox dbxBuDoctorList;
		private IHIS.Framework.XButton btnBuDoctorList;
        private IHIS.Framework.XButton btnCancelOpen;
        private IHIS.Framework.XTextBox txtFromHograde;
        private MultiLayout layCurrentBed;
        private MultiLayout layHocodeBedno;
		private System.ComponentModel.IContainer components;
        private SingleLayout layVaildCheck;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayout layMaxBedNo;
        private XButtonList btnList;
        private XLabel xLabel1;
        private XLabel xLabel14;
        private XLabel xLabel17;
        private XLabel xLabel16;
        private XLabel xLabel15;
        private SingleLayout layCommon;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private XDictComboBox cboToHograde;
        private XDictComboBox cboFromHograde;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private SingleLayout layHoSex;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem6;
        private XLabel xLabel19;
        private XBuseoCombo cboToKaikei_HoDong;
        private XDictComboBox cboToKaikei_HoCode;
        private XLabel xLabel9;
        private XDisplayBox dbxFromKaikei_HoCode;
        private XDisplayBox dbxFromKaikei_HoDong;
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
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private XButton btnSummary;
        private SingleLayoutItem singleLayoutItem5;
        
		#endregion

		#region 생성자
		public NUR2004U00()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2004U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.ptbPatient = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnSummary = new IHIS.Framework.XButton();
            this.btnConfirm = new IHIS.Framework.XButton();
            this.btnCancelOpen = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnBuDoctorList = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dpbFromGwa = new IHIS.Framework.XDisplayBox();
            this.dpbFromGwaName = new IHIS.Framework.XDisplayBox();
            this.dpbFromDoctorName = new IHIS.Framework.XDisplayBox();
            this.dpbFromDoctor = new IHIS.Framework.XDisplayBox();
            this.dpbFromHodong = new IHIS.Framework.XDisplayBox();
            this.dpbFromHocode = new IHIS.Framework.XDisplayBox();
            this.dpbFromBed = new IHIS.Framework.XDisplayBox();
            this.fbxToGwa = new IHIS.Framework.XFindBox();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.fbxToDoctor = new IHIS.Framework.XFindBox();
            this.fbxToHoDong = new IHIS.Framework.XFindBox();
            this.fbxToHoCode = new IHIS.Framework.XFindBox();
            this.dpbToGwa = new IHIS.Framework.XDisplayBox();
            this.dpbToDoctor = new IHIS.Framework.XDisplayBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtpJukyong_date = new IHIS.Framework.XDatePicker();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.dbxFromKaikei_HoCode = new IHIS.Framework.XDisplayBox();
            this.dbxFromKaikei_HoDong = new IHIS.Framework.XDisplayBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.cboFromHograde = new IHIS.Framework.XDictComboBox();
            this.txtFromHograde = new IHIS.Framework.XTextBox();
            this.dbxBuDoctorList = new IHIS.Framework.XDisplayBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.pnlToJunip = new IHIS.Framework.XPanel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.cboToKaikei_HoDong = new IHIS.Framework.XBuseoCombo();
            this.cboToKaikei_HoCode = new IHIS.Framework.XDictComboBox();
            this.cboToHograde = new IHIS.Framework.XDictComboBox();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.pnlToBed = new IHIS.Framework.XPanel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.layCurrentBed = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.layHocodeBedno = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.layVaildCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.layMaxBedNo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.layHoSex = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPatient)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.pnlToJunip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboToKaikei_HoDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCurrentBed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHocodeBedno)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "진료의사.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.ptbPatient);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(697, 34);
            this.xPanel1.TabIndex = 0;
            // 
            // ptbPatient
            // 
            this.ptbPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptbPatient.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptbPatient.Location = new System.Drawing.Point(0, 0);
            this.ptbPatient.Name = "ptbPatient";
            this.ptbPatient.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.ptbPatient.Size = new System.Drawing.Size(697, 30);
            this.ptbPatient.TabIndex = 0;
            this.ptbPatient.PatientSelectionFailed += new System.EventHandler(this.ptbPatient_PatientSelectionFailed);
            this.ptbPatient.PatientSelected += new System.EventHandler(this.ptbPatient_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnSummary);
            this.xPanel2.Controls.Add(this.btnConfirm);
            this.xPanel2.Controls.Add(this.btnCancelOpen);
            this.xPanel2.Controls.Add(this.btnClose);
            this.xPanel2.Controls.Add(this.btnCancel);
            this.xPanel2.Controls.Add(this.btnBuDoctorList);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 303);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.xPanel2.Size = new System.Drawing.Size(697, 36);
            this.xPanel2.TabIndex = 1;
            // 
            // btnSummary
            // 
            this.btnSummary.ImageIndex = 0;
            this.btnSummary.ImageList = this.ImageList;
            this.btnSummary.Location = new System.Drawing.Point(332, 4);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnSummary.Size = new System.Drawing.Size(105, 27);
            this.btnSummary.TabIndex = 48;
            this.btnSummary.Text = "サマリー作成";
            this.btnSummary.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(0, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(0, 0);
            this.btnConfirm.TabIndex = 46;
            // 
            // btnCancelOpen
            // 
            this.btnCancelOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelOpen.Image")));
            this.btnCancelOpen.Location = new System.Drawing.Point(500, 500);
            this.btnCancelOpen.Name = "btnCancelOpen";
            this.btnCancelOpen.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancelOpen.Size = new System.Drawing.Size(76, 32);
            this.btnCancelOpen.TabIndex = 4;
            this.btnCancelOpen.Text = "取消";
            this.btnCancelOpen.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(615, 138);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "閉じる";
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(126, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnCancel.Size = new System.Drawing.Size(76, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBuDoctorList
            // 
            this.btnBuDoctorList.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBuDoctorList.ImageIndex = 0;
            this.btnBuDoctorList.ImageList = this.ImageList;
            this.btnBuDoctorList.Location = new System.Drawing.Point(3, 3);
            this.btnBuDoctorList.Name = "btnBuDoctorList";
            this.btnBuDoctorList.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnBuDoctorList.Size = new System.Drawing.Size(124, 30);
            this.btnBuDoctorList.TabIndex = 44;
            this.btnBuDoctorList.Text = "副主治医登録";
            this.btnBuDoctorList.Visible = false;
            this.btnBuDoctorList.Click += new System.EventHandler(this.btnBuDoctorList_Click);
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "転科確認", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(443, 1);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(251, 34);
            this.btnList.TabIndex = 47;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = ((System.Drawing.Image)(resources.GetObject("xLabel3.Image")));
            this.xLabel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel3.Location = new System.Drawing.Point(0, 0);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(300, 28);
            this.xLabel3.TabIndex = 5;
            this.xLabel3.Text = "変 更 前";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = ((System.Drawing.Image)(resources.GetObject("xLabel4.Image")));
            this.xLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel4.Location = new System.Drawing.Point(0, 0);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(343, 28);
            this.xLabel4.TabIndex = 6;
            this.xLabel4.Text = "変 更 後";
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(4, 89);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(72, 22);
            this.xLabel5.TabIndex = 7;
            this.xLabel5.Text = "診療医";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(4, 157);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(72, 22);
            this.xLabel6.TabIndex = 8;
            this.xLabel6.Text = "病    棟";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Location = new System.Drawing.Point(4, 186);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(72, 22);
            this.xLabel7.TabIndex = 9;
            this.xLabel7.Text = "病    室";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Location = new System.Drawing.Point(4, 215);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(72, 22);
            this.xLabel8.TabIndex = 10;
            this.xLabel8.Text = "病    床";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpbFromGwa
            // 
            this.dpbFromGwa.EdgeRounding = false;
            this.dpbFromGwa.Location = new System.Drawing.Point(80, 60);
            this.dpbFromGwa.Name = "dpbFromGwa";
            this.dpbFromGwa.Size = new System.Drawing.Size(96, 22);
            this.dpbFromGwa.TabIndex = 12;
            this.dpbFromGwa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpbFromGwaName
            // 
            this.dpbFromGwaName.EdgeRounding = false;
            this.dpbFromGwaName.Location = new System.Drawing.Point(176, 60);
            this.dpbFromGwaName.Name = "dpbFromGwaName";
            this.dpbFromGwaName.Size = new System.Drawing.Size(125, 22);
            this.dpbFromGwaName.TabIndex = 13;
            // 
            // dpbFromDoctorName
            // 
            this.dpbFromDoctorName.EdgeRounding = false;
            this.dpbFromDoctorName.Location = new System.Drawing.Point(176, 89);
            this.dpbFromDoctorName.Name = "dpbFromDoctorName";
            this.dpbFromDoctorName.Size = new System.Drawing.Size(125, 22);
            this.dpbFromDoctorName.TabIndex = 15;
            // 
            // dpbFromDoctor
            // 
            this.dpbFromDoctor.EdgeRounding = false;
            this.dpbFromDoctor.Location = new System.Drawing.Point(80, 89);
            this.dpbFromDoctor.Name = "dpbFromDoctor";
            this.dpbFromDoctor.Size = new System.Drawing.Size(96, 22);
            this.dpbFromDoctor.TabIndex = 14;
            this.dpbFromDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpbFromHodong
            // 
            this.dpbFromHodong.EdgeRounding = false;
            this.dpbFromHodong.Location = new System.Drawing.Point(80, 157);
            this.dpbFromHodong.Name = "dpbFromHodong";
            this.dpbFromHodong.Size = new System.Drawing.Size(96, 22);
            this.dpbFromHodong.TabIndex = 16;
            this.dpbFromHodong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpbFromHocode
            // 
            this.dpbFromHocode.EdgeRounding = false;
            this.dpbFromHocode.Location = new System.Drawing.Point(80, 186);
            this.dpbFromHocode.Name = "dpbFromHocode";
            this.dpbFromHocode.Size = new System.Drawing.Size(96, 22);
            this.dpbFromHocode.TabIndex = 18;
            this.dpbFromHocode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpbFromBed
            // 
            this.dpbFromBed.EdgeRounding = false;
            this.dpbFromBed.Location = new System.Drawing.Point(80, 215);
            this.dpbFromBed.Name = "dpbFromBed";
            this.dpbFromBed.Size = new System.Drawing.Size(96, 22);
            this.dpbFromBed.TabIndex = 19;
            this.dpbFromBed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxToGwa
            // 
            this.fbxToGwa.FindWorker = this.fwkFind;
            this.fbxToGwa.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fbxToGwa.Location = new System.Drawing.Point(79, 60);
            this.fbxToGwa.Name = "fbxToGwa";
            this.fbxToGwa.Size = new System.Drawing.Size(110, 22);
            this.fbxToGwa.TabIndex = 21;
            this.fbxToGwa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxToGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxToDataValidating);
            this.fbxToGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // fbxToDoctor
            // 
            this.fbxToDoctor.FindWorker = this.fwkFind;
            this.fbxToDoctor.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fbxToDoctor.Location = new System.Drawing.Point(79, 89);
            this.fbxToDoctor.Name = "fbxToDoctor";
            this.fbxToDoctor.Size = new System.Drawing.Size(110, 22);
            this.fbxToDoctor.TabIndex = 22;
            this.fbxToDoctor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxToDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxToDataValidating);
            this.fbxToDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // fbxToHoDong
            // 
            this.fbxToHoDong.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fbxToHoDong.Location = new System.Drawing.Point(79, 124);
            this.fbxToHoDong.Name = "fbxToHoDong";
            this.fbxToHoDong.Size = new System.Drawing.Size(112, 22);
            this.fbxToHoDong.TabIndex = 23;
            this.fbxToHoDong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxToHoDong.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxToDataValidating);
            this.fbxToHoDong.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxToHodong_FindSelected);
            this.fbxToHoDong.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxToHodong_FindClick);
            // 
            // fbxToHoCode
            // 
            this.fbxToHoCode.FindWorker = this.fwkFind;
            this.fbxToHoCode.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fbxToHoCode.Location = new System.Drawing.Point(79, 153);
            this.fbxToHoCode.Name = "fbxToHoCode";
            this.fbxToHoCode.Size = new System.Drawing.Size(72, 22);
            this.fbxToHoCode.TabIndex = 24;
            this.fbxToHoCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxToHoCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxToDataValidating);
            this.fbxToHoCode.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxToHoCode_FindSelected);
            this.fbxToHoCode.FindClick += new System.ComponentModel.CancelEventHandler(this.fbx_FindClick);
            // 
            // dpbToGwa
            // 
            this.dpbToGwa.EdgeRounding = false;
            this.dpbToGwa.Location = new System.Drawing.Point(189, 60);
            this.dpbToGwa.Name = "dpbToGwa";
            this.dpbToGwa.Size = new System.Drawing.Size(154, 22);
            this.dpbToGwa.TabIndex = 26;
            // 
            // dpbToDoctor
            // 
            this.dpbToDoctor.EdgeRounding = false;
            this.dpbToDoctor.Location = new System.Drawing.Point(189, 89);
            this.dpbToDoctor.Name = "dpbToDoctor";
            this.dpbToDoctor.Size = new System.Drawing.Size(154, 22);
            this.dpbToDoctor.TabIndex = 27;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            this.imageList1.Images.SetKeyName(2, "12.gif");
            // 
            // dtpJukyong_date
            // 
            this.dtpJukyong_date.IsJapanYearType = true;
            this.dtpJukyong_date.Location = new System.Drawing.Point(79, 33);
            this.dtpJukyong_date.Name = "dtpJukyong_date";
            this.dtpJukyong_date.Size = new System.Drawing.Size(112, 20);
            this.dtpJukyong_date.TabIndex = 38;
            this.dtpJukyong_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpJukyong_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpJukyong_date_DataValidating);
            // 
            // xPanel4
            // 
            this.xPanel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.xPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.xPanel4.Controls.Add(this.dbxFromKaikei_HoCode);
            this.xPanel4.Controls.Add(this.dbxFromKaikei_HoDong);
            this.xPanel4.Controls.Add(this.xLabel9);
            this.xPanel4.Controls.Add(this.cboFromHograde);
            this.xPanel4.Controls.Add(this.txtFromHograde);
            this.xPanel4.Controls.Add(this.dbxBuDoctorList);
            this.xPanel4.Controls.Add(this.xLabel13);
            this.xPanel4.Controls.Add(this.xLabel5);
            this.xPanel4.Controls.Add(this.xLabel6);
            this.xPanel4.Controls.Add(this.dpbFromDoctorName);
            this.xPanel4.Controls.Add(this.xLabel1);
            this.xPanel4.Controls.Add(this.dpbFromBed);
            this.xPanel4.Controls.Add(this.dpbFromHocode);
            this.xPanel4.Controls.Add(this.dpbFromHodong);
            this.xPanel4.Controls.Add(this.dpbFromDoctor);
            this.xPanel4.Controls.Add(this.dpbFromGwaName);
            this.xPanel4.Controls.Add(this.dpbFromGwa);
            this.xPanel4.Controls.Add(this.xLabel8);
            this.xPanel4.Controls.Add(this.xLabel7);
            this.xPanel4.Controls.Add(this.xLabel3);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel4.Location = new System.Drawing.Point(0, 34);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(305, 269);
            this.xPanel4.TabIndex = 39;
            // 
            // dbxFromKaikei_HoCode
            // 
            this.dbxFromKaikei_HoCode.EdgeRounding = false;
            this.dbxFromKaikei_HoCode.Location = new System.Drawing.Point(176, 241);
            this.dbxFromKaikei_HoCode.Name = "dbxFromKaikei_HoCode";
            this.dbxFromKaikei_HoCode.Size = new System.Drawing.Size(127, 22);
            this.dbxFromKaikei_HoCode.TabIndex = 129;
            this.dbxFromKaikei_HoCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxFromKaikei_HoDong
            // 
            this.dbxFromKaikei_HoDong.EdgeRounding = false;
            this.dbxFromKaikei_HoDong.Location = new System.Drawing.Point(80, 241);
            this.dbxFromKaikei_HoDong.Name = "dbxFromKaikei_HoDong";
            this.dbxFromKaikei_HoDong.Size = new System.Drawing.Size(96, 22);
            this.dbxFromKaikei_HoDong.TabIndex = 128;
            this.dbxFromKaikei_HoDong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel9.Location = new System.Drawing.Point(4, 241);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(72, 22);
            this.xLabel9.TabIndex = 127;
            this.xLabel9.Text = "扱い病棟";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboFromHograde
            // 
            this.cboFromHograde.Enabled = false;
            this.cboFromHograde.Font = new System.Drawing.Font("MS UI Gothic", 10.5F);
            this.cboFromHograde.Location = new System.Drawing.Point(176, 186);
            this.cboFromHograde.Name = "cboFromHograde";
            this.cboFromHograde.Size = new System.Drawing.Size(142, 22);
            this.cboFromHograde.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboFromHograde.TabIndex = 49;
            this.cboFromHograde.UserSQL = "SELECT A.HO_GRADE\r\n     , A.HO_GRADE_NAME\r\n  FROM BAS0251 A\r\n WHERE A.HOSP_CODE  " +
                "  = FN_ADM_LOAD_HOSP_CODE()\r\n   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.EN" +
                "D_DATE";
            // 
            // txtFromHograde
            // 
            this.txtFromHograde.Location = new System.Drawing.Point(146, 314);
            this.txtFromHograde.Name = "txtFromHograde";
            this.txtFromHograde.Size = new System.Drawing.Size(100, 20);
            this.txtFromHograde.TabIndex = 45;
            // 
            // dbxBuDoctorList
            // 
            this.dbxBuDoctorList.EdgeRounding = false;
            this.dbxBuDoctorList.Location = new System.Drawing.Point(80, 119);
            this.dbxBuDoctorList.Name = "dbxBuDoctorList";
            this.dbxBuDoctorList.Size = new System.Drawing.Size(221, 22);
            this.dbxBuDoctorList.TabIndex = 44;
            this.dbxBuDoctorList.Visible = false;
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel13.Location = new System.Drawing.Point(4, 119);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(72, 22);
            this.xLabel13.TabIndex = 43;
            this.xLabel13.Text = "副主治医";
            this.xLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel13.Visible = false;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(4, 60);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(72, 22);
            this.xLabel1.TabIndex = 3;
            this.xLabel1.Text = "診療科";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel5
            // 
            this.xPanel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel5.BackgroundImage")));
            this.xPanel5.Controls.Add(this.xLabel11);
            this.xPanel5.Controls.Add(this.xLabel2);
            this.xPanel5.Controls.Add(this.xLabel10);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel5.Location = new System.Drawing.Point(305, 34);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(42, 269);
            this.xPanel5.TabIndex = 40;
            // 
            // xLabel11
            // 
            this.xLabel11.Image = ((System.Drawing.Image)(resources.GetObject("xLabel11.Image")));
            this.xLabel11.Location = new System.Drawing.Point(10, 97);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(22, 24);
            this.xLabel11.TabIndex = 3;
            // 
            // xLabel2
            // 
            this.xLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xLabel2.Image")));
            this.xLabel2.Location = new System.Drawing.Point(10, 165);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(22, 24);
            this.xLabel2.TabIndex = 2;
            // 
            // xLabel10
            // 
            this.xLabel10.Image = ((System.Drawing.Image)(resources.GetObject("xLabel10.Image")));
            this.xLabel10.Location = new System.Drawing.Point(10, 131);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(22, 24);
            this.xLabel10.TabIndex = 1;
            // 
            // pnlToJunip
            // 
            this.pnlToJunip.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlToJunip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlToJunip.Controls.Add(this.xLabel19);
            this.pnlToJunip.Controls.Add(this.cboToKaikei_HoDong);
            this.pnlToJunip.Controls.Add(this.cboToKaikei_HoCode);
            this.pnlToJunip.Controls.Add(this.cboToHograde);
            this.pnlToJunip.Controls.Add(this.xLabel17);
            this.pnlToJunip.Controls.Add(this.xLabel16);
            this.pnlToJunip.Controls.Add(this.xLabel15);
            this.pnlToJunip.Controls.Add(this.xLabel14);
            this.pnlToJunip.Controls.Add(this.pnlToBed);
            this.pnlToJunip.Controls.Add(this.xLabel4);
            this.pnlToJunip.Controls.Add(this.dpbToDoctor);
            this.pnlToJunip.Controls.Add(this.dpbToGwa);
            this.pnlToJunip.Controls.Add(this.fbxToHoCode);
            this.pnlToJunip.Controls.Add(this.fbxToHoDong);
            this.pnlToJunip.Controls.Add(this.fbxToDoctor);
            this.pnlToJunip.Controls.Add(this.fbxToGwa);
            this.pnlToJunip.Controls.Add(this.dtpJukyong_date);
            this.pnlToJunip.Controls.Add(this.xLabel12);
            this.pnlToJunip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlToJunip.Location = new System.Drawing.Point(347, 34);
            this.pnlToJunip.Name = "pnlToJunip";
            this.pnlToJunip.Size = new System.Drawing.Size(350, 269);
            this.pnlToJunip.TabIndex = 41;
            // 
            // xLabel19
            // 
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel19.Location = new System.Drawing.Point(4, 243);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(72, 22);
            this.xLabel19.TabIndex = 124;
            this.xLabel19.Text = "扱い病棟";
            this.xLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboToKaikei_HoDong
            // 
            this.cboToKaikei_HoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboToKaikei_HoDong.Location = new System.Drawing.Point(79, 243);
            this.cboToKaikei_HoDong.Name = "cboToKaikei_HoDong";
            this.cboToKaikei_HoDong.Size = new System.Drawing.Size(112, 21);
            this.cboToKaikei_HoDong.TabIndex = 122;
            this.cboToKaikei_HoDong.SelectedIndexChanged += new System.EventHandler(this.cboToKaikei_HoDong_SelectedIndexChanged);
            // 
            // cboToKaikei_HoCode
            // 
            this.cboToKaikei_HoCode.Location = new System.Drawing.Point(196, 243);
            this.cboToKaikei_HoCode.Name = "cboToKaikei_HoCode";
            this.cboToKaikei_HoCode.Size = new System.Drawing.Size(146, 21);
            this.cboToKaikei_HoCode.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboToKaikei_HoCode.TabIndex = 121;
            this.cboToKaikei_HoCode.UserSQL = "SELECT HO_CODE, HO_CODE\r\n  FROM BAS0250 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND" +
                " HO_DONG = :f_kaikei_hodong";
            this.cboToKaikei_HoCode.DDLBSetting += new System.EventHandler(this.cboToKaikei_HoCode_DDLBSetting);
            // 
            // cboToHograde
            // 
            this.cboToHograde.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.cboToHograde.Location = new System.Drawing.Point(153, 153);
            this.cboToHograde.Name = "cboToHograde";
            this.cboToHograde.Size = new System.Drawing.Size(190, 23);
            this.cboToHograde.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboToHograde.TabIndex = 48;
            this.cboToHograde.UserSQL = "SELECT A.HO_GRADE\r\n     , A.HO_GRADE_NAME\r\n  FROM BAS0251 A\r\n WHERE A.HOSP_CODE  " +
                "  = FN_ADM_LOAD_HOSP_CODE()\r\n   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.EN" +
                "D_DATE";
            // 
            // xLabel17
            // 
            this.xLabel17.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel17.EdgeRounding = false;
            this.xLabel17.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel17.Location = new System.Drawing.Point(4, 153);
            this.xLabel17.Name = "xLabel17";
            this.xLabel17.Size = new System.Drawing.Size(72, 22);
            this.xLabel17.TabIndex = 46;
            this.xLabel17.Text = "病    室";
            this.xLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel16.Location = new System.Drawing.Point(4, 124);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(72, 22);
            this.xLabel16.TabIndex = 47;
            this.xLabel16.Text = "病    棟";
            this.xLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel15
            // 
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel15.Location = new System.Drawing.Point(3, 89);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(72, 22);
            this.xLabel15.TabIndex = 46;
            this.xLabel15.Text = "診療医";
            this.xLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel14.Location = new System.Drawing.Point(3, 60);
            this.xLabel14.Name = "xLabel14";
            this.xLabel14.Size = new System.Drawing.Size(72, 22);
            this.xLabel14.TabIndex = 46;
            this.xLabel14.Text = "診療科";
            this.xLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlToBed
            // 
            this.pnlToBed.AutoScroll = true;
            this.pnlToBed.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(236))))));
            this.pnlToBed.Location = new System.Drawing.Point(4, 178);
            this.pnlToBed.Name = "pnlToBed";
            this.pnlToBed.Size = new System.Drawing.Size(339, 60);
            this.pnlToBed.TabIndex = 39;
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel12.Location = new System.Drawing.Point(3, 32);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(72, 22);
            this.xLabel12.TabIndex = 42;
            this.xLabel12.Text = "転出日付";
            this.xLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layCurrentBed
            // 
            this.layCurrentBed.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem32,
            this.multiLayoutItem37,
            this.multiLayoutItem38});
            this.layCurrentBed.QuerySQL = resources.GetString("layCurrentBed.QuerySQL");
            this.layCurrentBed.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCurrentBed_QueryStarting);
            this.layCurrentBed.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layCurrentBed_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gwa";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "gwa_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "doctor";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "doctor_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "ho_dong";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "ho_code";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "bed_no";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "suname";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "ipwon_date";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "toiwon_res_date";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "toiwon_res_yn";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "tot_bed";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "pkinp1001";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "trans_cnt";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "bu_doctor_list";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "ho_grade";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "kaikei_hodong";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "kaikei_hocode";
            // 
            // layHocodeBedno
            // 
            this.layHocodeBedno.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem17,
            this.multiLayoutItem18});
            this.layHocodeBedno.QuerySQL = resources.GetString("layHocodeBedno.QuerySQL");
            this.layHocodeBedno.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHocodeBedno_QueryStarting);
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "bed_no";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "bed_status";
            // 
            // layVaildCheck
            // 
            this.layVaildCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4});
            this.layVaildCheck.QuerySQL = "validationServiceDyn1";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "vali_code";
            this.singleLayoutItem2.IsUpdItem = true;
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "vali_code_1";
            this.singleLayoutItem3.IsUpdItem = true;
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "vali_code_2";
            this.singleLayoutItem4.IsUpdItem = true;
            // 
            // layMaxBedNo
            // 
            this.layMaxBedNo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5});
            this.layMaxBedNo.QuerySQL = resources.GetString("layMaxBedNo.QuerySQL");
            this.layMaxBedNo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layMaxBedNo_QueryStarting);
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "max_bed";
            // 
            // layCommon
            // 
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem18,
            this.singleLayoutItem19});
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "retVal1";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "retVal2";
            // 
            // layHoSex
            // 
            this.layHoSex.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem6});
            this.layHoSex.QuerySQL = resources.GetString("layHoSex.QuerySQL");
            this.layHoSex.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHoSex_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "ho_code";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "ho_sex";
            // 
            // NUR2004U00
            // 
            this.Controls.Add(this.pnlToJunip);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "NUR2004U00";
            this.Size = new System.Drawing.Size(697, 339);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR2004U00_Closing);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPatient)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.xPanel5.ResumeLayout(false);
            this.pnlToJunip.ResumeLayout(false);
            this.pnlToJunip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboToKaikei_HoDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCurrentBed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHocodeBedno)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 스크린 로드
        private string mHospCode = "";
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            mHospCode = EnvironInfo.HospCode;
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			this.dtpJukyong_date.SetDataValue(IHIS.Framework.EnvironInfo.GetSysDate());

            if (this.OpenParam != null)
			{
				this.ptbPatient.SetPatientID(this.OpenParam["bunho"].ToString());
			}
			else
			{
				//현재스크린 환자번호
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					this.ptbPatient.SetPatientID(patientInfo.BunHo);
					this.fbxToHoDong.Focus();
				}
            }

            cboToKaikei_HoCode.SetDictDDLB();

            cboToKaikei_HoDong.SetDataValue(fbxToHoDong.GetDataValue());
            cboToKaikei_HoCode.SetDataValue(fbxToHoCode.GetDataValue());

		}

		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.ptbPatient.Focus();
				this.ptbPatient.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.ptbPatient.BunHo.ToString()))
			{
				return new XPatientInfo(this.ptbPatient.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion

		#region CreateBed
		/// <summary>
		/// Bed 동적생성
		/// </summary>
		private void CreateBed()
		{
			XRadioButton rbBed;
			const int Height = 30;
			const int Width  = 30;
			const int Location_x = 2;
			const int Location_y = 2;
			int j=0;
			
			this.pnlToBed.Controls.Clear();

            if (this.layHocodeBedno.QueryLayout(true))
            {
                foreach (DataRow dr in this.layHocodeBedno.LayoutTable.Rows)
                {
                    rbBed = new XRadioButton();
                    rbBed.Size = new Size(Width, Height);
                    rbBed.Location = new Point(Location_x + (j * Width), Location_y);

                    rbBed.Text = dr["bed_no"].ToString();
                    rbBed.Tag = dr["bed_status"].ToString();
                    rbBed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    rbBed.CheckedChanged += new EventHandler(OnRadioButtons_CheckedChanged);
                    rbBed.Appearance = System.Windows.Forms.Appearance.Button;

                    if (dr["bed_status"].ToString() != "00") //공상이 아니고
                    {
                        if (this.dpbFromHocode.GetDataValue() != this.fbxToHoCode.GetDataValue())
                        {   /* 선택한 병실이 다른 병실 일 때*/
                            rbBed.Enabled = false;
                        }
                        else
                        {
                            if (rbBed.Text != dpbFromBed.Text) 
                                /*선택한 병실이 현재 병실이면서 다른 침상 일 때.*/
                                rbBed.Enabled = false;
                        }
                        /* 침상번호가 다를 경우만 선택 못하도록 한다면
                         * 다른 병실에 같은 침상번호가 공상이 아니여도
                         * 선택가능하도록 되었기 때문에 병실 조건을 추가
                         * (2011.11.24 woo)*/
                    }
                    else
                    {
                        rbBed.Enabled = true;

                    }

                    rbBed.BackColor = IHIS.Framework.XColor.XRadioButtonBackColor;

                    this.pnlToBed.Controls.Add(rbBed);
                    j++;
                }

                if ( this.pnlToBed.Controls.Count == 1)
                {
                    IHIS.Framework.XRadioButton ct = (IHIS.Framework.XRadioButton)this.pnlToBed.Controls[0];
                    if (ct.Tag.ToString() == "00")
                    {
                        /* 침상이 하나이면서 공상이라면 그 침상이 자동 선택되도록 함. (2011.11.24 woo)*/
                        ct.Checked = true;
                    }

                }
            }

		}

		#endregion

		#region Command
		public override object Command(string command, CommonItemCollection commandParam)
		{				
			if(command.Equals("BAS0250Q00") )//병실선택시
			{
				this.fbxToHoDong.SetDataValue(commandParam["ho_dong"].ToString());
				this.fbxToHoCode.SetEditValue(commandParam["ho_code"].ToString());
				this.fbxToHoCode.AcceptData();

                this.cboToHograde.SetEditValue(commandParam["ho_grade"].ToString());
                this.cboToHograde.AcceptData();

                this.cboToKaikei_HoDong.SetDataValue(commandParam["ho_dong"].ToString());
                this.cboToKaikei_HoCode.SetDataValue(commandParam["ho_code"].ToString()); 

				foreach(Control cs in this.pnlToBed.Controls)
				{
					if(((IHIS.Framework.XRadioButton)cs).Text == commandParam["bed_no"].ToString())
					{
						((IHIS.Framework.XRadioButton)cs).Checked = true;
						break;
					}
				}
			}

			if (command == "OCS0270Q00")
			{
				this.dpbToDoctor.SetEditValue(commandParam["doctor_name"].ToString());
				this.dpbToDoctor.AcceptData();

				this.fbxToDoctor.SetEditValue(commandParam["doctor"].ToString());
				this.fbxToDoctor.AcceptData();
			}
			return base.Command (command, commandParam);

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
				case "GWA":
					msg = (NetInfo.Language == LangMode.Ko ? "변경할 진료과를 입력해 주세요."
						: "変更する診療科を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "DOCTOR":
					msg = (NetInfo.Language == LangMode.Ko ? "변경할 진료의를 입력해 주세요."
						: "変更する診療医を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "HO_DONG":
					msg = (NetInfo.Language == LangMode.Ko ? "변경할 병동을 입력해 주세요."
						: "変更する病棟を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "HO_CODE":
					msg = (NetInfo.Language == LangMode.Ko ? "변경할 병실을 입력해 주세요."
						: "変更する病室を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "BED_NO":
					msg = (NetInfo.Language == LangMode.Ko ? "변경할 병상을 입력해 주세요."
						: "変更する病床を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
                case "KAIKEI_HODONG":
                    msg = (NetInfo.Language == LangMode.Ko ? "회계 될 병동을 입력해 주세요."
                        : "会計の基準になる病棟を選択してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "KAIKEI_HOCODE":
                    msg = (NetInfo.Language == LangMode.Ko ? "변경할 병상을 입력해 주세요."
                        : "会計の基準になる病室を選択してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                //case "HO_GRADE":
                //    msg = (NetInfo.Language == LangMode.Ko ? "변경할 병실등급을 입력해 주세요."
                //        : "変更する病室等級を入力してください。");
                //    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                //        : "お知らせ");
                //    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                //    break;
				case "BUNHO":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다. 확인바랍니다."
						: "在院中の患者ではありません。 ご確認ください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "SAVE_TRUE":
					msg = NetInfo.Language == LangMode.Ko ? "전과전실 처리 성공."
						: "転科転室を申し込みました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "SAVE_FALSE":
					msg = NetInfo.Language == LangMode.Ko ? "전과전실 처리 실패." 
						: "転科転室の申し込みに失敗しました。";
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "에러" 
						: "エラー";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "CANCEL_TRUE":
					msg = NetInfo.Language == LangMode.Ko ? "정상적으로 취소 되었습니다."
						: "取消が完了しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "CANCEL_FALSE":
					msg = NetInfo.Language == LangMode.Ko ? "취소실패." 
						: "取消失敗。";
                    msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "에러" 
						: "エラー";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		/// <summary>
		/// 파인드 박스 셋팅
		/// </summary>
		/// <param name="findMode">
		/// 파인드 구분
		/// </param>
		/// <returns></returns>
        /// edit start 2010/05/17
		#region [Find 창 open]
     	private void SetFindBox(string findMode)
		{
            this.fwkFind.ColInfos.Clear();
            switch (findMode)
			{
                case "fbxToGwa":
                    this.fwkFind.InputSQL = @" SELECT A.GWA         gwa,
                                                      A.GWA_NAME    gwa_name
                                                 FROM VW_GWA_NAME A
                                                WHERE A.HOSP_CODE   = :f_hosp_code 
                                                  AND A.BUSEO_GUBUN = '1'
                                                  AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                  AND ((A.GWA     LIKE :f_find1||'%')
                                                  OR  (A.GWA_NAME LIKE :f_find1||'%'))
                                                  AND A.IPWON_YN = 'Y'
                                                  ORDER BY 1";

                    this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkFind.SetBindVarValue("f_date", this.dtpJukyong_date.GetDataValue());
                    this.fwkFind.FormText = "診療科照会";
                   	this.fwkFind.ColInfos.Add("gwa" ,"診療科", FindColType.String, 100, 0, true, FilterType.InitYes); 
					this.fwkFind.ColInfos.Add("gwa_name", "診療科名", FindColType.String, 200, 0, true, FilterType.InitYes);

					break;

                case "fbxToDoctor":
                    if (this.fbxToGwa.GetDataValue() == "")
                        GetMessage("DOCTOR");
                    this.fwkFind.InputSQL = @"SELECT DISTINCT 
                                                       A.DOCTOR         doctor,
                                                       A.DOCTOR_NAME    doctor_name
                                                  FROM BAS0270 A
                                                 WHERE A.HOSP_CODE  = :f_hosp_code
                                                   AND A.DOCTOR_GWA LIKE :f_gwa||'%'
                                                   AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                   AND A.DOCTOR     LIKE :f_find1||'%'
                                                 ORDER BY 1";

                    this.fwkFind.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.fwkFind.SetBindVarValue("f_gwa", this.fbxToGwa.GetDataValue());
                    this.fwkFind.SetBindVarValue("f_date", this.dtpJukyong_date.GetDataValue());
                    this.fwkFind.FormText = "医師照会";
                    this.fwkFind.ColInfos.Add("doctor", "医師コード", FindColType.String, 100, 0, true, FilterType.InitYes);
                    this.fwkFind.ColInfos.Add("doctor_name", "医師名", FindColType.String, 200, 0, true, FilterType.InitYes); 
                    break;

                case "fbxToHoDong":
                    this.fwkFind.InputSQL = @"SELECT A.GWA      hodong,
                                                       A.GWA_NAME hodong_name
                                                  FROM BAS0260 A
                                                 WHERE A.HOSP_CODE  = :f_hosp_code
                                                   AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                   AND A.BUSEO_GUBUN = '2'
                                                 ORDER BY A.GWA_SORT1";

                    this.fwkFind.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.fwkFind.SetBindVarValue("f_date", this.dtpJukyong_date.GetDataValue());
                    this.fwkFind.FormText = "病棟照会";
                    this.fwkFind.ColInfos.Add("hodong", "病棟", FindColType.String, 100, 0, true, FilterType.InitYes);
                    this.fwkFind.ColInfos.Add("hodong_name", "病棟名", FindColType.String, 200, 0, true, FilterType.InitYes);
                    break;

                case "fbxToHoCode":
                    if (this.fbxToHoDong.GetDataValue() == "")
                        GetMessage("HO_CODE");

                    this.fwkFind.InputSQL = @"SELECT   A.HO_CODE  hocode
                                                     , B.HO_GRADE_NAME
                                                  FROM BAS0250 A
                                                     , BAS0251 B
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND B.HOSP_CODE = A.HOSP_CODE
                                                   AND B.HO_GRADE  = A.HO_GRADE
                                                   AND B.START_DATE = (SELECT MAX(X.START_DATE) 
                                                                         FROM BAS0251 X 
                                                                        WHERE X.HOSP_CODE = B.HOSP_CODE 
                                                                          AND X.HO_GRADE  = B.HO_GRADE 
                                                                          AND X.START_DATE <= TO_DATE(:f_date, 'YYYY/MM/DD'))
                                                   AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                   --AND A.HO_DONG LIKE NVL(:f_hodong,'%')
                                                   AND A.HO_DONG = :f_hodong
                                                 ORDER BY 1";

                    this.fwkFind.SetBindVarValue("f_hodong", this.fbxToHoDong.GetDataValue());
                    this.fwkFind.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.fwkFind.SetBindVarValue("f_date", this.dtpJukyong_date.GetDataValue());
                    this.fwkFind.FormText = "病室照会";
					this.fwkFind.ColInfos.Add("hocode" ,"病室", FindColType.String, 100, 0, true, FilterType.InitYes);
                    this.fwkFind.ColInfos.Add("ho_grade", "病室料", FindColType.String, 150, 0, true, FilterType.InitYes);
                    //this.fwkFind.ColInfos.Add("hodong", "病棟", FindColType.String, 100, 0, true, FilterType.InitYes); 
					break;

				default:
					break;
			}
		}
		#endregion
	
		/// <summary>
		///	파인드 박스 통합 Validation 체크 
		/// </summary>
		/// <param name="fbx">
		/// 파인드박스 명
		/// </param>
		/// <returns></returns> 
		#region Total Validation Check
        private void MakeValService(XFindBox fbx)
        {
            this.layVaildCheck.QuerySQL = "";
            //Validation 체크 해제 서버에서 하는 방향으로
            //잘못입력한후 닫기 버튼이 안되는 현상발생.
            switch (fbx.Name)
            {
                case "fbxToGwa":
                    this.layVaildCheck.QuerySQL = @"SELECT A.GWA_NAME   
                                                      FROM BAS0260 A 
                                                     WHERE A.HOSP_CODE   = :f_hosp_code
                                                       AND A.BUSEO_GUBUN = '1'
                                                       AND A.GWA  = :f_code 
                                                        AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";
                    break;

                case "fbxToDoctor":

                    string gwa = this.fbxToGwa.GetDataValue();

                    this.layVaildCheck.QuerySQL = @"SELECT DOCTOR_NAME  
                                                      FROM BAS0270 
                                                     WHERE HOSP_CODE = :f_hosp_code
                                                       AND DOCTOR_GWA = " + "'" + gwa + "'" + @" 
                                                       AND DOCTOR = :f_code
                                                       AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN START_DATE AND END_DATE";
                    break;

                case "fbxToHoDong":
                    this.layVaildCheck.QuerySQL = @"SELECT A.GWA_NAME 
                                                      FROM BAS0260 A 
                                                     WHERE A.HOSP_CODE   = :f_hosp_code
                                                       AND A.BUSEO_GUBUN = '2' 
                                                       AND A.GWA  = :f_code 
                                                       AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";
                    break;

                case "fbxToHoCode":
                    string hodong = this.fbxToHoDong.GetDataValue();
                    if (hodong == "")
                    {
                        hodong = "%";
                    }
                    this.layVaildCheck.QuerySQL = @"SELECT A.HO_CODE
                                                          ,A.HO_TOTAL_BED
                                                          ,A.HO_GRADE
                                                     FROM BAS0250 A 
                                                     WHERE A.HOSP_CODE  = :f_hosp_code
                                                       AND A.HO_DONG LIKE'" + hodong + "'" +
                                                     @"AND A.HO_CODE LIKE :f_code
                                                      AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";
                    break;

                default:
                    break;
            }
        }

        private void fbxToDataValidating(object sender, DataValidatingEventArgs e)
        {
            XFindBox fbSender = sender as XFindBox;
            this.MakeValService(fbSender);
            this.layVaildCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layVaildCheck.SetBindVarValue("f_code", e.DataValue);
            this.layVaildCheck.SetBindVarValue("f_date", this.dtpJukyong_date.GetDataValue());
            this.layVaildCheck.SetBindVarValue("f_hosp_code", this.mHospCode);

            if (this.layVaildCheck.QueryLayout())
            {
                switch (fbSender.Name)
                {
                    case "fbxToGwa":

                        string gwa_name = this.layVaildCheck.GetItemValue("vali_code").ToString();
                        this.dpbToGwa.SetEditValue(gwa_name);
                        this.dpbToGwa.AcceptData();
                        this.fbxToDoctor.ResetData();
                        this.dpbToDoctor.ResetData();

                        break;
                    case "fbxToDoctor":

                        string doctor_name = this.layVaildCheck.GetItemValue("vali_code").ToString();
                        this.dpbToDoctor.SetEditValue(doctor_name);
                        this.dpbToDoctor.AcceptData();

                        break;
                    case "fbxToHoDong":

                        string hodong_name = this.layVaildCheck.GetItemValue("vali_code").ToString();
                        


                        break;

                    case "fbxToHoCode":
                        string hocode_name = string.Empty;
                        int ho_total_bed = 0;
                        string ho_grade = string.Empty;
                        this.layHoSex.SetBindVarValue("f_ho_code", e.DataValue);
                        this.layHoSex.QueryLayout();

                        //if (this.layHoSex.GetItemValue("ho_code").ToString() == "")
                        //{
                        //    e.Cancel = true;
                        //    return;
                        //}

                        if (this.layHoSex.GetItemValue("ho_sex").ToString() != "")
                        {
                            if (this.ptbPatient.Sex != this.layHoSex.GetItemValue("ho_sex").ToString())
                            {

                                if (DialogResult.No == XMessageBox.Show("患者の性別と病室の性別が違います。続けますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                                {

                                    //this.fbxToHoDong.Clear();
                                    this.fbxToHoCode.Clear();
                                    this.cboToHograde.SetDataValue(null);
                                    e.Cancel = true;
                                    return;
                                }

                            }
                        }

                        if (this.layMaxBedNo.QueryLayout())
                        {
                            CreateBed();
                        }

                        hocode_name = this.layVaildCheck.GetItemValue("vali_code").ToString();
                        ho_total_bed = Convert.ToInt32(this.layVaildCheck.GetItemValue("vali_code_1").ToString());
                        ho_grade = this.layVaildCheck.GetItemValue("vali_code_2").ToString();
                        this.cboToHograde.SetEditValue(ho_grade);

                        FindName = "";
                        this.pnlToBed.Focus();

                        break;
                }
            }
            else
            {
                if (e.DataValue != "")
                {
                    e.Cancel = true;
                    XMessageBox.Show("コードが有効ではありません。", "注意", MessageBoxIcon.Warning);
                }
            }
        }

		private void fbxToGwa_Enter(object sender, System.EventArgs e)
		{
            this.MakeValService(this.fbxToGwa);
		}

		private void fbxToDoctor_Enter(object sender, System.EventArgs e)
		{
            this.MakeValService(this.fbxToDoctor);
        }

        private void fbxToHodong_Enter(object sender, System.EventArgs e)
        {
            this.MakeValService(this.fbxToHoDong);
        }

        private void fbxToHoCode_Enter(object sender, System.EventArgs e)
        {
            this.MakeValService(this.fbxToHoCode);
		}
		#endregion
		
		#region 각종 정보 파인드 클릭시
		private void fbx_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
            XFindBox fb = sender as XFindBox;
			SetFindBox(fb.Name);
		}

		private void fbxToDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			//SetFindBox("doctor");
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add("gwa", this.fbxToGwa.GetDataValue().ToString());
			openParams.Add("word", "");
			openParams.Add("all_gubun", "Y");
			openParams.Add("query_gubun", "%");
		
			XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
		}

		private void fbxToHodong_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{			
			CommonItemCollection cic = new CommonItemCollection();			
			cic.Add("ho_dong",this.fbxToHoDong.GetDataValue());
            IHIS.Framework.XScreen.OpenScreenWithParam(this,"BASS","BAS0250Q00", ScreenOpenStyle.ResponseFixed,cic);
			//SetFindBox("hodong");
		}

		private void fbxHoCode_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{			
            SetFindBox("hocode");
		}
		#endregion

		#region 환자변경시 현재병동정보 로드
		private void ptbPatient_PatientSelected(object sender, System.EventArgs e)
		{
            // GetInitJunip() 함수에서 환자 선택 이벤트를 한번 더 탄다. 그래서 막음. 

            ptbPatient.PatientSelected -= new EventHandler(this.ptbPatient_PatientSelected); 
            GetInitJunip();
            ptbPatient.PatientSelected += new EventHandler(this.ptbPatient_PatientSelected); 
		}

		private void GetInitJunip()
		{
            string strSql = string.Empty;
            BindVarCollection bindVarJunip = new BindVarCollection();
            //            
            foreach (Control cnt in xPanel4.Controls)
            {
                if (cnt.GetType().Name == "XDisplayBox")
                {
                    ((XDisplayBox)cnt).ResetData();
                }
            }
            this.cboFromHograde.ResetData();

            this.dtpJukyong_date.SetDataValue(EnvironInfo.GetSysDate());
            this.fbxToGwa.ResetData();
            this.dpbToGwa.ResetData();
            this.fbxToDoctor.ResetData();
            this.dpbToDoctor.ResetData();
            this.fbxToHoDong.ResetData();
            this.fbxToHoCode.ResetData();
            this.cboToHograde.ResetData();
            this.pnlToBed.Controls.Clear();

            if(this.ptbPatient.BunHo == "")
                return;

            //현재상태로드
            if (!layCurrentBed.QueryLayout(false))
			{	
				this.GetMessage("BUNHO");
			}

            if (this.layCurrentBed.RowCount > 0)
            {
                this.mPkinp1001 = Convert.ToInt32(layCurrentBed.GetItemString(0, "pkinp1001"));
                this.mHodong = layCurrentBed.GetItemString(0, "ho_dong");

                this.dpbFromGwa.SetDataValue(layCurrentBed.GetItemString(0, "gwa"));
                this.dpbFromGwaName.SetDataValue(layCurrentBed.GetItemString(0, "gwa_name"));
                this.dpbFromDoctor.SetDataValue(layCurrentBed.GetItemString(0, "doctor"));
                this.dpbFromDoctorName.SetDataValue(layCurrentBed.GetItemString(0, "doctor_name"));
                this.dpbFromHodong.SetDataValue(layCurrentBed.GetItemString(0, "ho_dong"));
                this.dpbFromHocode.SetDataValue(layCurrentBed.GetItemString(0, "ho_code"));
                this.cboFromHograde.SetDataValue(layCurrentBed.GetItemString(0, "ho_grade"));
                this.dpbFromBed.SetDataValue(layCurrentBed.GetItemString(0, "bed_no"));
                //this.dpbTotalBed.SetDataValue(layCurrentBed.GetItemString(0, "tot_bed"));

                this.fbxToHoDong.SetEditValue(layCurrentBed.GetItemString(0, "ho_dong"));
                this.fbxToHoCode.SetEditValue(layCurrentBed.GetItemString(0, "ho_code"));
                this.fbxToHoCode.AcceptData();

                this.mTrans_cnt = int.Parse(layCurrentBed.GetItemString(0, "trans_cnt"));
                this.fbxToGwa.SetDataValue(layCurrentBed.GetItemString(0, "gwa"));
                this.dpbToGwa.SetDataValue(layCurrentBed.GetItemString(0, "gwa_name"));
                this.fbxToDoctor.SetDataValue(layCurrentBed.GetItemString(0, "doctor"));
                this.dpbToDoctor.SetDataValue(layCurrentBed.GetItemString(0, "doctor_name"));
                this.dbxBuDoctorList.SetEditValue(layCurrentBed.GetItemString(0, "bu_doctor_list"));
                this.dbxFromKaikei_HoDong.SetEditValue(layCurrentBed.GetItemString(0, "kaikei_hodong"));
                this.dbxFromKaikei_HoCode.SetEditValue(layCurrentBed.GetItemString(0, "kaikei_hocode"));
                this.dbxBuDoctorList.AcceptData();

                foreach (Control cs in this.pnlToBed.Controls)
                {
                    if (((IHIS.Framework.XRadioButton)cs).Text == layCurrentBed.GetItemString(0, "bed_no"))
                    {
                        ((IHIS.Framework.XRadioButton)cs).Checked = true;
                        break;
                    }
                }

                //전입 미확인건 체크
                strSql = @"SELECT A.TO_GWA                                           to_gwa
                                , FN_BAS_LOAD_GWA_NAME(A.TO_GWA, A.START_DATE)       gwa_name
                                , A.TO_DOCTOR                                        to_doctor
                                , FN_BAS_LOAD_DOCTOR_NAME(A.TO_DOCTOR, A.START_DATE) doctor_name
                                , A.TO_HO_DONG1                                      ho_dong
                                , A.TO_HO_CODE1                                      ho_code
                                , A.TO_BED_NO                                        to_bed_no
                               , 'Y'                                                 unconfirm_yn
                            FROM INP2004 A
                           WHERE A.HOSP_CODE   = :f_hosp_code
                             AND A.FKINP1001   = TO_NUMBER(:f_fkinp1001)
                             AND A.TO_HO_DONG1 = :f_ho_dong
                             AND A.CANCEL_YN  != 'Y'
                             AND A.TO_NURSE_CONFIRM_DATE IS NULL
                             AND NVL(TO_DATE(:f_date, 'YYYY/MM/DD'), TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE
                           ORDER BY A.TRANS_CNT DESC";

                BindVarCollection bindVar = new BindVarCollection();
                bindVar.Add("f_hosp_code", this.mHospCode);
                bindVar.Add("f_date", this.dtpJukyong_date.GetDataValue());
                bindVar.Add("f_fkinp1001", this.mPkinp1001.ToString());
                bindVar.Add("f_ho_dong", this.mHodong);

                DataTable dtResult = Service.ExecuteDataTable(strSql, bindVar);

                if (Service.ErrCode == 0)
                {
                    ////미확인건존재
                    if (dtResult.Rows.Count > 1 && dtResult.Rows[0]["unconfirm_yn"].ToString() == "Y")
                    {
                        this.fbxToHoDong.SetDataValue(dtResult.Rows[0]["ho_dong"].ToString());
                        this.fbxToHoCode.SetEditValue(dtResult.Rows[0]["ho_code"].ToString());
                        //Datavalidating으로 베드패널에 베드표시
                        this.fbxToHoCode.AcceptData();

                        //베드 선택처리
                        foreach (Control cs in this.pnlToBed.Controls)
                        {
                            if (((IHIS.Framework.XRadioButton)cs).Text == dtResult.Rows[0]["to_bed_no"].ToString())//this.dsvGetJunipUnConfirm.GetOutValue("bed_no").ToString()
                            {
                                ((IHIS.Framework.XRadioButton)cs).Checked = true;
                                break;
                            }
                            if (this.pnlToBed.Controls.Count == 1)
                                ((IHIS.Framework.XRadioButton)cs).Checked = true;
                        }
                        //미확인된 전입건이 있을경우 취소처리
                        this.pnlToJunip.Enabled = false;
                    }
                    else
                    {
                        this.pnlToJunip.Enabled = true;
                        this.fbxToHoDong.Focus();
                    }
                }
            }
            else
            {
                XMessageBox.Show("[" + ptbPatient.SuName + "]様は入院中ではありません。", "入院確認");
            }
		}

        private void ptbPatient_PatientSelectionFailed(object sender, EventArgs e)
        {
            /*환자 번호 검색 실패 시 Data Reset로직 추가(2011.11.24 woo)*/

            foreach (Control cnt in xPanel4.Controls)
            {
                if (cnt.GetType().Name == "XDisplayBox")
                {
                    ((XDisplayBox)cnt).ResetData();
                }
            }
            this.cboFromHograde.ResetData();

            this.dtpJukyong_date.SetDataValue(EnvironInfo.GetSysDate());
            this.fbxToGwa.ResetData();
            this.dpbToGwa.ResetData();
            this.fbxToDoctor.ResetData();
            this.dpbToDoctor.ResetData();
            this.fbxToHoDong.ResetData();
            this.fbxToHoCode.ResetData();
            this.cboToHograde.ResetData();
            this.pnlToBed.Controls.Clear();
        }

		#endregion

		#region 베드선택시
		private void OnRadioButtons_CheckedChanged(object sender, System.EventArgs e)
		{
			IHIS.Framework.XRadioButton rb = (IHIS.Framework.XRadioButton)sender;

			foreach(Control cs in this.pnlToBed.Controls)
			{
				((IHIS.Framework.XRadioButton)cs).BackColor = IHIS.Framework.XColor.XRadioButtonBackColor;
			}
			if (rb.Checked)
				rb.BackColor = new XColor(Color.Silver);
		}
		#endregion

		#region 닫기 버튼을 클릭을 했을 때
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region 취소버튼을 클릭을 했을 때
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
            string strSql = @" SELECT 'Y'
                                 FROM DUAL
                                WHERE EXISTS ( SELECT 'X'
                                                 FROM INP2004
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND BUNHO     = :f_bunho
                                                  AND FKINP1001 = :f_fkinp1001
                                                  AND TRANS_CNT = :f_trans_cnt
                                                  AND TO_NURSE_CONFIRM_DATE IS NOT NULL )";

            BindVarCollection bindVar = new BindVarCollection();
            bindVar.Add("f_hosp_code", this.mHospCode);
            bindVar.Add("f_bunho", this.ptbPatient.BunHo);
            bindVar.Add("fkinp1001"     , this.mPkinp1001.ToString());
            bindVar.Add("trans_cnt"     , this.mTrans_cnt.ToString());
            bindVar.Add("cancel_sayu"   , "");

            object o_flag = Service.ExecuteScalar(strSql,bindVar);

            //  전과전실 확인건 리턴처리
            if (!o_flag.ToString().Equals("Y") && o_flag != null)
            {
                XMessageBox.Show("該当患者は既に転科転室が確認されました。");
                return;
            }
            else
            {
                try
                {
                    Service.BeginTransaction();
                    BindVarCollection bindUpdVar = new BindVarCollection();

                    strSql = @" UPDATE INP2004
                                   SET UPD_DATE = SYSDATE
                                      ,UPD_ID  = :q_user_id
                                      ,CANCEL_YN = 'Y'
                                      ,CANCEL_SAYU = :f_cancel_sayu
                                 WHERE HOSP_CODE = :f_hosp_code
                                  AND BUNHO     = :f_bunho
                                  AND FKINP1001 = :f_fkinp1001
                                  AND TRANS_CNT = :f_trans_cnt";
                    
                    bindUpdVar.Add("q_user_id"      ,UserInfo.UserID);
                    bindUpdVar.Add("f_hosp_code", this.mHospCode);
                    bindUpdVar.Add("f_bunho", this.ptbPatient.BunHo);
                    bindUpdVar.Add("f_cancel_sayu"  ," ");
                    bindUpdVar.Add("f_fkinp1001"    , this.mPkinp1001.ToString());
                    bindUpdVar.Add("f_trans_cnt"    , this.mTrans_cnt.ToString());

                    Service.ExecuteNonQuery(strSql, bindUpdVar);

                    Service.CommitTransaction();
                    this.GetMessage("CANCEL_TRUE");
                    this.btnCancel.Enabled = false;
                    this.btnConfirm.Enabled = true;
                    //재조회
                    GetInitJunip();
                                    
                }
                catch (Exception x) 
                {
                    x.StackTrace.ToString();
                    Service.RollbackTransaction();
                    XMessageBox.Show(Service.ErrFullMsg.ToString());
                    this.GetMessage("CANCEL_FALSE");
                    this.btnCancel.Enabled = true;
                    this.btnConfirm.Enabled = false;
                    
                    return;

                }
            }
		}
		#endregion	
            
		#region 부주치의 등록화면을 연다
		private void btnBuDoctorList_Click(object sender, System.EventArgs e)
		{
			CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.ptbPatient.BunHo.ToString());
            cic.Add("date", this.dtpJukyong_date.GetDataValue());
            cic.Add("gwa", this.fbxToGwa.GetDataValue());

			IHIS.Framework.XScreen.OpenScreenWithParam(this,"NURI","NUR1050U00", ScreenOpenStyle.ResponseFixed,cic);

			//조회
			GetInitJunip();
		}
		#endregion

		/// <summary>
		/// Screen 닫을때
		/// </summary>
		/// 
		#region NUR2004U00_Closing
		private void NUR2004U00_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = false;
		}
		#endregion	

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
            string bed_no = "";

            switch(e.Func)
			{
				case FunctionType.Process :
                   
					foreach(Control cs in this.pnlToBed.Controls)
					{
						if(((IHIS.Framework.XRadioButton)cs).Checked)
						{
                            bed_no = cs.Text;
							break;
						}
					}

					/* 변경할 진료과 확인(입력이 됐는지 유무) */
					if (this.fbxToGwa.GetDataValue().ToString() == "")
					{
						this.GetMessage("GWA");
						this.fbxToGwa.Focus();
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					/* 변경할 진료의 확인(입력이 됐는지 유무) */
					if (this.fbxToDoctor.GetDataValue().ToString() == "")
					{
						this.GetMessage("DOCTOR");
						this.fbxToDoctor.Focus();
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					/* 변경할 병동을 확인(입력이 됐는지 유무) */
					if (this.fbxToHoDong.GetDataValue().ToString() == "")
					{
						this.GetMessage("HO_DONG");
						this.fbxToHoDong.Focus();
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					/* 변경할 병실을 확인(입력이 됐는지 유무) */
					if (this.fbxToHoCode.GetDataValue().ToString() == "")
					{
						this.GetMessage("HO_CODE");
						this.fbxToHoCode.Focus();
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					/* 변경할 병상을 확인(입력이 됐는지 유무)*/
					if (bed_no.ToString() == "")
					{
						this.GetMessage("BED_NO");
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}
                    
                    /* 변경할 회계 병동을 확인(입력이 됐는지 유무)*/
					if (this.cboToKaikei_HoDong.GetDataValue().ToString() == "")
					{
						this.GetMessage("KAIKEI_HODONG");
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}
                    /* 변경할 회계 병실을 확인(입력이 됐는지 유무)*/
                    if (this.cboToKaikei_HoCode.GetDataValue().ToString() == "")
					{
						this.GetMessage("KAIKEI_HOCODE");
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}
                    
                    string hograde = string.Empty;
                    string hostatus = string.Empty;
                    string new_trans_cnt = string.Empty;
                    string junpyo_date = string.Empty;
                    string bed_no2 = string.Empty;
                    string trans_gubun = string.Empty;

                    BindVarCollection subBindvar = new BindVarCollection();
                    /**************************************************************************
                     Validation처리
                     0.심사마감체크 1.과체크 2.병동체크 3.병실체크 4.베드체크 5.의사체크
                    **************************************************************************/
                    bool r_temp = CheckPreInsert( this.mPkinp1001.ToString()            , this.fbxToGwa.GetDataValue()
                                                , this.dtpJukyong_date.GetDataValue()   , this.fbxToHoDong.GetDataValue()
                                                , this.fbxToHoCode.GetDataValue()       , bed_no    
                                                , this.fbxToDoctor.GetDataValue());

                    if (!r_temp)  return;

                    /*
                        진료과,진료의,병동,병실,INCU여부
                        전과('01'),전동('02'),전실('03'),전과전동('04'),전과전실('05'), 의사변경('06'),특진변경('07'), 병상변경('08')
                    */

                    /*    전과전실구분*/
                    trans_gubun = GetTransGubun(this.dpbFromGwa.GetDataValue(), this.fbxToGwa.GetDataValue()
                                               , this.dpbFromHocode.GetDataValue(), this.fbxToHoCode.GetDataValue()
                                               , this.dpbFromHodong.GetDataValue(), this.fbxToHoDong.GetDataValue()
                                               , this.dpbFromDoctor.GetDataValue(), this.fbxToDoctor.GetDataValue()
                                               , this.dpbFromBed.GetDataValue(), bed_no
                                               , this.dbxFromKaikei_HoDong.GetDataValue(), this.cboToKaikei_HoDong.GetDataValue()
                                               , this.dbxFromKaikei_HoCode.GetDataValue(), this.cboToKaikei_HoCode.GetDataValue());

                    if (trans_gubun.Equals(string.Empty))
                    {
                        return;
                    }

                    //전과전실횟차 로드
                    new_trans_cnt = GetTransCnt(this.mPkinp1001.ToString(), this.mTrans_cnt);
                    // 전표일자로드
                    junpyo_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

                    //HO_GRADE 조회
                    bed_no2 = GetBedNo(this.mPkinp1001.ToString());

                    string sub_strSql = @" SELECT A.HO_GRADE   HO_GRADE
                                                --, A.HO_STATUS  HO_STATUS
                                             FROM BAS0250 A
                                            WHERE A.HOSP_CODE = :f_hosp_code                                            
                                              AND A.HO_DONG   = :f_to_ho_dong1
                                              AND A.HO_CODE   = :f_to_ho_code1
                                              AND NVL(TO_DATE(:f_junpyo_date,'YYYY/MM/DD'), TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE";

                    subBindvar.Add("f_hosp_code"  , EnvironInfo.HospCode);
                    subBindvar.Add("f_to_ho_dong1", this.fbxToHoDong.GetDataValue());
                    subBindvar.Add("f_to_ho_code1", this.fbxToHoCode.GetDataValue());
                    subBindvar.Add("f_junpyo_date", junpyo_date);

                    DataTable dtSql = Service.ExecuteDataTable(sub_strSql, subBindvar);
                    if (!TypeCheck.IsNull(dtSql))
                    {
                        hograde = dtSql.Rows[0]["ho_grade"].ToString();
                        //hostatus = dtSql.Rows[0]["ho_status"].ToString();
                    }
                    
                    /*전과전실시 신청한 전과전실 정보 있는지 체크*/
                    string strSql = @"SELECT 'Y'
                                        FROM DUAL
                                       WHERE EXISTS ( SELECT 'X'
                                                        FROM INP2004
                                                       WHERE HOSP_CODE  = :f_hosp_code
                                                         AND BUNHO      = :f_bunho
                                                         AND FKINP1001  = TO_NUMBER(:f_fkinp1001)
                                                         AND TO_DATE(:f_date, 'YYYY/MM/DD') BETWEEN START_DATE AND END_DATE
                                                         --AND START_DATE = TO_DATE(:f_order_date,'YYYY/MM/DD')
                                                         AND NVL(CANCEL_YN,'N') = 'N'
                                                         AND TO_NURSE_CONFIRM_DATE IS NULL)";

                    subBindvar.Add("f_hosp_code", this.mHospCode);
                    subBindvar.Add("f_bunho", this.ptbPatient.BunHo);
                    subBindvar.Add("f_fkinp1001", this.mPkinp1001.ToString());
                    subBindvar.Add("f_date", this.dtpJukyong_date.GetDataValue());
                    subBindvar.Add("f_to_ho_dong1", this.fbxToHoDong.GetDataValue());

                    object rtn_value = Service.ExecuteScalar(strSql, subBindvar);
                   
                    if (rtn_value != null && rtn_value.ToString() == "Y")
                    {
                        XMessageBox.Show("既に申し込みされた転科転室情報があります。ご確認ください。", "確認");
                        return;
                    }

                    try
                    {
                        Service.BeginTransaction();

                        strSql = @"SELECT 'Y'
                                    FROM DUAL
                                   WHERE EXISTS (SELECT 'X'
                                                   FROM INP2004
                                                  WHERE HOSP_CODE     = :f_hosp_code
                                                    AND FKINP1001     = :f_fkinp1001
                                                    AND TRANS_CNT     = :f_trans_cnt
                                                    AND NVL(CANCEL_YN,'N') = 'N'
                                                    AND TO_NURSE_CONFIRM_DATE IS NULL
                                                    AND TO_HO_DONG1   = :f_to_ho_dong1
                                                    AND TO_HO_CODE1   = :f_to_ho_code1
                                                    AND TO_GWA        = TRIM(:f_to_gwa)
                                                    AND TO_DOCTOR     = :f_to_doctor
                                                    AND TO_BED_NO     = :f_to_bed_no )";

                        BindVarCollection bindUpd = new BindVarCollection();
                        bindUpd.Add("f_hosp_code", EnvironInfo.HospCode);
                        bindUpd.Add("f_fkinp1001", this.mPkinp1001.ToString());
                        //bindUpd.Add("f_trans_cnt", this.mTrans_cnt.ToString());
                        bindUpd.Add("f_trans_cnt", new_trans_cnt.ToString());
                        bindUpd.Add("f_to_doctor", this.fbxToDoctor.GetDataValue());
                        bindUpd.Add("f_to_gwa"   , this.fbxToGwa.GetDataValue());
                        bindUpd.Add("f_to_ho_dong1", this.fbxToHoDong.GetDataValue());
                        bindUpd.Add("f_to_ho_code1", this.fbxToHoCode.GetDataValue());

                        Object rtn_yn = Service.ExecuteScalar(strSql, bindUpd);

                        if (rtn_yn != null && rtn_yn.ToString().Equals("Y"))
                        {

                            strSql = @" UPDATE INP2004
                                       SET UPD_DATE      = SYSDATE
                                          ,UPD_ID        = :q_user_id
                                          ,TO_GWA        = TRIM(:f_to_gwa)
                                          ,TO_HO_DONG1   = :f_to_ho_dong1
                                          ,TO_HO_CODE1   = :f_to_ho_code1
                                          ,TO_HO_GRADE1  = :f_to_ho_grade1
                                          ,TO_HO_DONG2   = :f_to_ho_dong2
                                          ,TO_HO_CODE2   = :f_to_ho_code2
                                          ,TO_HO_GRADE2  = :f_to_ho_grade1
                                          ,TO_BED_NO     = :f_to_bed_no
                                          ,TO_BED_NO2    = :f_to_bed_no2
                                          ,TO_KAIKEI_HODONG = :f_to_kaikei_hodong
                                          ,TO_KAIKEI_HOCODE = :f_to_kaikei_hocode
                                     WHERE HOSP_CODE     = :f_hosp_code
                                       FKINP1001     = :f_fkinp1001
                                       AND TRANS_CNT     = :f_trans_cnt
                                       AND NVL(CANCEL_YN,'N') = 'N'
                                       AND TO_NURSE_CONFIRM_DATE IS NULL
                                       AND TO_HO_DONG1   = :f_to_ho_dong1
                                       AND TO_HO_CODE1   = :f_to_ho_code1
                                       AND TO_GWA        = TRIM(:f_to_gwa)
                                       AND TO_DOCTOR     = :f_to_doctor
                                       AND TO_BED_NO     = :f_to_bed_no";

                            bindUpd.Add("f_hosp_code", EnvironInfo.HospCode);
                            bindUpd.Add("q_user_id", UserInfo.UserID);
                            bindUpd.Add("f_to_ho_dong2", ""); //this.fbxToHoDong.GetDataValue());  // ""
                            bindUpd.Add("f_to_ho_code2", ""); //this.fbxToHoCode.GetDataValue());  // ""
                            bindUpd.Add("f_to_bed_no", bed_no);
                            bindUpd.Add("f_to_bed_no2", bed_no2);
                            bindUpd.Add("f_to_ho_grade1", hograde);
                            bindUpd.Add("f_to_kaikei_hodong", this.cboToKaikei_HoDong.GetDataValue());
                            bindUpd.Add("f_to_kaikei_hocode", this.cboToKaikei_HoCode.GetDataValue());
                            
                            if (Service.ExecuteNonQuery(strSql, bindUpd))
                            {
                                new_trans_cnt = this.mTrans_cnt.ToString();
                            }
                            else
                            {
                                throw new Exception("転室データの生成に失敗しました。\n\r" + Service.ErrFullMsg);
                            }
                            bindUpd.Clear();
                        }
                        else
                        {
                            string str_insert = @"INSERT INTO INP2004
                                         ( SYS_DATE             , SYS_ID                , UPD_DATE                 , UPD_ID       
                                         , HOSP_CODE            , FKINP1001             , BUNHO             
                                         , TRANS_CNT            , TRANS_TIME            , START_DATE               , TONGGYE_DATE          
                                         , FROM_GWA             , TO_GWA                , FROM_DOCTOR              , TO_DOCTOR             
                                         , FROM_RESIDENT        , TO_RESIDENT           , CANCEL_SAYU        
                                         , FROM_HO_CODE1        , FROM_HO_DONG1         , TO_HO_CODE1               , TO_HO_DONG1           
                                         , FROM_HO_CODE2        , FROM_HO_DONG2         , TO_HO_CODE2               , TO_HO_DONG2  
                                         , CANCEL_YN            , TRANS_GUBUN  
                                         , TO_NURSE_CONFIRM_ID  , TO_NURSE_CONFIRM_DATE , TO_NURSE_CONFIRM_TIME             
                                         , FROM_BED_NO          , TO_BED_NO             , FROM_BED_NO2              , TO_BED_NO2    
                                         , END_DATE             , TO_HO_GRADE1          , TO_HO_GRADE2
                                         , FROM_KAIKEI_HODONG   , FROM_KAIKEI_HOCODE    , TO_KAIKEI_HODONG          , TO_KAIKEI_HOCODE)
                                    VALUES
                                         ( SYSDATE                , :q_user_id               , SYSDATE                  , :q_user_id                                        
                                         , :f_hosp_code           , TO_NUMBER(:f_fkinp1001)  , :f_bunho                 
                                         , TO_NUMBER(:f_trans_cnt), TO_CHAR(SYSDATE,'HH24MI'), TO_DATE(:f_order_date,'YYYY/MM/DD HH24:MI:SS')   , SYSDATE
                                         , TRIM(:f_from_gwa)      , TRIM(:f_to_gwa)          , :f_from_doctor           , :f_to_doctor                                     
                                         , :f_from_resident       , :f_to_resident           ,  NULL                                            
                                         , :f_from_ho_code1       , :f_from_ho_dong1         , :f_to_ho_code1           , :f_to_ho_dong1                                   
                                         , :f_from_ho_code2       , :f_from_ho_dong2         , :f_to_ho_code2           , :f_to_ho_dong2                                                
                                         , 'N'                    , :f_trans_gubun                                            
                                         , NULL                   , NULL                     , NULL                                               
                                         , :f_from_bed_no         , :f_to_bed_no             , :f_from_bed_no           , :f_to_bed_no2                                          
                                         , TO_DATE('9998/12/31','YYYY/MM/DD')   ,  :f_to_ho_grade1      ,  :f_to_ho_grade1
                                         , :f_from_kaikei_hodong  , :f_from_kaikei_hocode    , :f_to_kaikei_hodong      , :f_to_kaikei_hocode)";

                            BindVarCollection bindVar = new BindVarCollection();
                            bindVar.Add("q_user_id", UserInfo.UserID);
                            bindVar.Add("f_fkinp1001", this.mPkinp1001.ToString());
                            bindVar.Add("f_bunho", this.ptbPatient.BunHo);
                            bindVar.Add("f_trans_cnt", new_trans_cnt);
                            bindVar.Add("f_order_date", this.dtpJukyong_date.GetDataValue());
                            bindVar.Add("f_from_gwa", this.dpbFromGwa.GetDataValue());
                            bindVar.Add("f_to_gwa", this.fbxToGwa.GetDataValue());
                            bindVar.Add("f_from_doctor", this.dpbFromDoctor.GetDataValue());
                            bindVar.Add("f_to_doctor", this.fbxToDoctor.GetDataValue());
                            bindVar.Add("f_from_resident", this.dpbFromDoctor.GetDataValue());
                            bindVar.Add("f_to_resident", this.fbxToDoctor.GetDataValue());
                            bindVar.Add("f_from_ho_code1", this.dpbFromHocode.GetDataValue());
                            bindVar.Add("f_from_ho_dong1", this.dpbFromHodong.GetDataValue());
                            bindVar.Add("f_to_ho_code1", this.fbxToHoCode.GetDataValue());
                            bindVar.Add("f_to_ho_dong1", this.fbxToHoDong.GetDataValue());

                            bindVar.Add("f_from_kaikei_hodong", this.dbxFromKaikei_HoDong.GetDataValue());
                            bindVar.Add("f_from_kaikei_hocode", this.dbxFromKaikei_HoCode.GetDataValue());
                            bindVar.Add("f_to_kaikei_hodong", this.cboToKaikei_HoDong.GetDataValue());
                            bindVar.Add("f_to_kaikei_hocode", this.cboToKaikei_HoCode.GetDataValue());
                            
                            bindVar.Add("f_from_ho_code2", this.dpbFromHocode.GetDataValue());
                            bindVar.Add("f_from_ho_dong2", this.dpbFromHodong.GetDataValue());
                            bindVar.Add("f_to_ho_dong2", "");//this.fbxToHoDong.GetDataValue()); // ""
                            bindVar.Add("f_to_ho_code2", ""); //this.fbxToHoCode.GetDataValue()); // ""
                            bindVar.Add("f_trans_gubun", trans_gubun);
                            bindVar.Add("f_from_bed_no", this.dpbFromBed.GetDataValue());
                            bindVar.Add("f_to_bed_no", bed_no);
                            bindVar.Add("f_to_bed_no2", bed_no2);
                            bindVar.Add("f_hosp_code", this.mHospCode);
                            bindVar.Add("f_to_ho_grade1", hograde);
                            
                            if (!Service.ExecuteNonQuery(str_insert, bindVar))
                            {
                                throw new Exception("転室データの生成に失敗しました。\n\r" + Service.ErrFullMsg);
                            } 
                        }
                        
                        /*전동('02'),전과전동('04') 타병동에서 확인을 해야하기때문에 그외의
                         전과('01'),전실('03'),전과전실('05'), 의사변경('06'),특진변경('07'), 병상변경('08')은
                         전과전실처리한 병동에서 확인처리한다. */

                        if (trans_gubun == "02" || trans_gubun == "04")
                        {
                            Service.CommitTransaction();
                            this.GetMessage("SAVE_TRUE");
                            this.btnCancel.Enabled = true;
                            this.btnConfirm.Enabled = false;

                            return;
                        }

//                        if (trans_gubun != "01" && trans_gubun != "06")
//                        {
//                            /*현재베드 상태 체크*/
                            
//                            strSql = @"SELECT 'Y'
//                            FROM DUAL
//                            WHERE EXISTS ( SELECT 'X'
//                                             FROM VW_OCS_INP1001_01 B
//                                            WHERE B.HOSP_CODE     = :f_hosp_code 
//                                              AND B.HO_DONG1      = :f_to_ho_dong1
//                                              AND B.HO_CODE1      = :f_to_ho_code1
//                                              AND B.BED_NO        = :f_to_bed_no
//                                              AND B.BUNHO        != TO_NUMBER(:f_bunho)
//                                              AND :f_change_gubun = 'N')";

//                            subBindvar.Clear();
//                            subBindvar.Add("f_hosp_code", EnvironInfo.HospCode);
//                            subBindvar.Add("f_to_ho_dong1", this.fbxToHoDong.GetDataValue());
//                            subBindvar.Add("f_to_ho_code1", this.fbxToHoCode.GetDataValue());
//                            subBindvar.Add("f_to_bed_no", bed_no);
//                            subBindvar.Add("f_bunho", this.ptbPatient.BunHo);
//                            subBindvar.Add("f_change_gubun", "N");

//                            rtn_value = Service.ExecuteScalar(strSql, subBindvar);
//                            subBindvar.Clear();

//                            if (!TypeCheck.IsNull(rtn_value) && rtn_value.ToString().Equals("Y"))
//                            {
//                                XMessageBox.Show("変更先病床は既に割り当てられた病床です。ご確認ください。", "注意", MessageBoxIcon.Asterisk);
//                                return;
//                            }
//                        }

                        int retVal = GetConfirmData(this.mPkinp1001, Convert.ToInt32(new_trans_cnt), bed_no, UserInfo.UserID);

                        if (retVal != 0)
                            throw new Exception("転室データの生成に失敗しました。\n\r" + Service.ErrFullMsg);
                      
                        this.GetMessage("SAVE_TRUE");
                        this.btnCancel.Enabled = true;
                        this.btnConfirm.Enabled = false;
                                                       
                        Service.CommitTransaction();

                        //SAKURA転科転室データ転送


                        
                        ArrayList inputList = new ArrayList();
                        ArrayList outputList = new ArrayList();
                        
                        inputList.Add(EnvironInfo.HospCode);
                        inputList.Add(dpbFromHodong.GetDataValue());

                        Service.ExecuteProcedure("PR_BAS_BAS0250_REFRESH", inputList, outputList);


                        //전송 여부 다시한번 확인. (관리용 병실정보만 바뀌었을 경우에는 전송 안함)
                        if (dbxFromKaikei_HoDong.Text.Equals(cboToKaikei_HoDong.GetDataValue()) 
                         && dbxFromKaikei_HoCode.Text.Equals(cboToKaikei_HoCode.GetDataValue())
                         && this.dpbFromDoctor.GetDataValue().Equals(this.fbxToDoctor.GetDataValue()))
                        {
                            return;
                        }
                        else
                        {
                            string if_key = SakuraChangeTrans("2", "I", ptbPatient.BunHo, this.dtpJukyong_date.GetDataValue(), cboToKaikei_HoDong.GetDataValue()
                                                              , cboToKaikei_HoCode.GetDataValue(), bed_no, fbxToGwa.GetDataValue(), fbxToDoctor.GetDataValue()
                                                              , mPkinp1001.ToString(), UserInfo.UserID, "");

                            if (!if_key.Equals(string.Empty))
                            {
                                IFServiceCall(if_key);
                            }
                        }

                        GetInitJunip();					
                                               
                    }
                    catch 
                    {
                        Service.RollbackTransaction();
                        //x.StackTrace.ToString(); 
                        //this.GetMessage("save_false");
                        this.btnConfirm.Enabled = true;
                        this.btnCancel.Enabled = false;
                    }
                    break;
               
                case FunctionType.Cancel:

					e.IsBaseCall = false;
					CommonItemCollection cic = new CommonItemCollection();			
					cic.Add("bunho", this.ptbPatient.BunHo.ToString());
                    IHIS.Framework.XScreen.OpenScreenWithParam(this,"NURI","NUR2004U02", ScreenOpenStyle.ResponseFixed,cic);
                    GetInitJunip();					

					break;

				default:
					break;
			}
        }
        #endregion 

        #region SakuraChangeTrans
        /// <summary>
        /// 転科転室転送情報作成(IFS3011)
        /// PR_IFS_MAKE_IPWON_HISTORY 사용
        /// </summary>
        /// <param name="data_gubun">1：入院, 2：転入, 4：退院</param>
        /// <param name="proc_gubun">I：登録, U：修正, D：削除</param>
        /// <param name="bunho">患者番号</param>
        /// <param name="data_date">データ日付</param>
        /// <param name="ho_dong">棟コード</param>
        /// <param name="ho_code">室コード</param>
        /// <param name="bed_no">床コード</param>
        /// <param name="gwa">科コード</param>
        /// <param name="doctor">医師コード</param>
        /// <param name="pkinp1001">PKINP1001</param>
        /// <param name="userid">登録者ID</param>
        /// <param name="toiwon_gubun">[""可] １：治癒、２：死亡、３：中止、４：他移、５：転医、６：転科、７：軽快、８：転棟、９：転室</param>

        private string SakuraChangeTrans(string data_gubun, string proc_gubun, string bunho, string data_date, string ho_dong, string ho_code, string bed_no, string gwa, string doctor, string pkinp1001, string userid, string toiwon_gubun)
        {
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            inputList.Add(EnvironInfo.HospCode);
            inputList.Add(proc_gubun);
            inputList.Add(bunho);
            inputList.Add(data_date);
            inputList.Add(ho_dong);
            inputList.Add(ho_code);
            inputList.Add(""); //inputList.Add(bed_no); ベッド番号は会計に必要ない。(20130621)
            inputList.Add(gwa);
            inputList.Add(doctor);
            inputList.Add(pkinp1001);
            inputList.Add(userid);
            inputList.Add(data_gubun);
            inputList.Add(toiwon_gubun);

            if (!Service.ExecuteProcedure("PR_IFS_MAKE_IPWON_HISTORY", inputList, outputList))
            {
                XMessageBox.Show("SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                  "処理失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return string.Empty;
            }
            else
            {
                if (outputList[1].ToString() != "0")
                {
                    XMessageBox.Show("SAKURAへのデータ処理に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                     "処理失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
                return outputList[0].ToString();
            }
        }

        private bool IFServiceCall(string If_key)
        {

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText = "00231" + If_key;

            //XMessageBox.Show(msgText);

            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);

            if (ret == -1)
            {
                XMessageBox.Show("SAKURAへのデータ転送に失敗しました。\r\n再転送を行ってください。\r\n" + Service.ErrFullMsg,
                                 "転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            XMessageBox.Show("SAKURAへのデータ転送が完了しました。",
                             "転送完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        #endregion


        #region GetBedNo
        private string GetBedNo(string param_Pkinp1001)
        {
            BindVarCollection bindVarBedNo = new BindVarCollection();

            string strSql = @"SELECT BED_NO2
                                FROM VW_OCS_INP1001_01
                               WHERE HOSP_CODE = :f_hosp_code 
                                 AND PKINP1001 = :f_fkinp1001";

            bindVarBedNo.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVarBedNo.Add("f_fkinp1001", param_Pkinp1001);

            object rtn_value = Service.ExecuteScalar(strSql,bindVarBedNo);
            if (rtn_value == null)
            {
                rtn_value = string.Empty;
            }
            return rtn_value.ToString();

        }
        #endregion 

        #region GetTransCnt
        private string GetTransCnt(string param_pkinp1001, int param_cnt)
        {
            BindVarCollection bindCnt = new BindVarCollection();

            string strSql = @"SELECT NVL(MAX(TRANS_CNT),0) + 1
                                FROM INP2004
                               WHERE HOSP_CODE = :f_hosp_code
                                 AND BUNHO     = :f_bunho
　　　　　　　　　　　　　　　　 AND FKINP1001 = :f_fkinp1001";

            bindCnt.Add("f_hosp_code", this.mHospCode);
            bindCnt.Add("f_bunho", this.ptbPatient.BunHo);
            bindCnt.Add("f_fkinp1001", param_pkinp1001);
            object rtn_value = Service.ExecuteScalar(strSql, bindCnt);

            strSql = @"SELECT NVL(MAX(TRANS_CNT),0)
                         FROM INP2004
                        WHERE HOSP_CODE = :f_hosp_code
                         AND BUNHO     = :f_bunho
　　　　　　　　　　　　 AND FKINP1001 = :f_fkinp1001
                          AND NVL(CANCEL_YN,'N') = 'N'";

            object rtn_old_value = Service.ExecuteScalar(strSql, bindCnt);

            /*    전과전실 변경된정보 존재 재조회하여 처리해야함.*/
            //if (rtn_old_value != null && param_cnt != Int32.Parse(rtn_old_value.ToString()))
            //{ 
            //    XMessageBox.Show("変更された転科転室情報が存在します。");
            //    return string.Empty;
            //}
            if (TypeCheck.IsNull(rtn_value))
                return "";
            else 
                return rtn_value.ToString();

        }
        #endregion

        #region GetTransGubun
        private string GetTransGubun( string param_from_gwa             , string param_to_gwa       
                                    , string param_from_ho_code1        , string param_to_ho_code1
                                    , string param_from_ho_dong1        , string param_to_ho_dong1
                                    , string param_from_doctor          , string param_to_doctor    
                                    , string param_from_bed             , string param_to_bed       
                                    , string param_from_kaikei_hodong   , string param_to_kaikei_hodong
                                    , string param_from_kaikei_hocode   , string parma_to_kaikei_ho_code)
        {
            string rtn_value = string.Empty;

            //병동이 같고,
            if (param_from_ho_dong1.Equals(param_to_ho_dong1))
            {
                //병실도 같고, 회계 병동도 변하지 않고, 회계 병실도 변하지 않았으면.
                if (param_from_ho_code1.Equals(param_to_ho_code1) && param_from_kaikei_hocode.Equals(parma_to_kaikei_ho_code) && param_from_kaikei_hodong.Equals(param_to_kaikei_hodong))
                {
                    // 의사가 다르면 転医
                    if (!param_from_doctor.Equals(param_to_doctor))
                    {
                        rtn_value = "06";　//転医
                    }
                    // 의사는 같고 병상만 다르면
                    else if (!param_from_bed.Equals(param_to_bed))　
                    {
                        rtn_value = "08";　//転床
                    }
                }
                // 병실이 다르거나, 회계 병동이 다르거나, 회계 병실이 다르거나.
                else
                {
                    rtn_value = "03"; //転室
                    
                    //과도 다르면
                    if (!param_from_gwa.Equals(param_to_gwa)) 
                    {
                        rtn_value = "05";　//転科転室
                    }
                }
            }
            else//병동이 다르면
            {
                rtn_value = "02"; //転棟
                if (!param_from_gwa.Equals(param_to_gwa)) //과도 다르면
                {
                    rtn_value = "04";　//転科転棟
                }
            }

            if (rtn_value.Equals(string.Empty))
            {
                XMessageBox.Show("転科、転室情報が有効ではありません。");
                return string.Empty;
            }            
            return rtn_value;
        }
        #endregion

        #region NUR2004U00_SetInp2004의 insert전의 체크 메소드.
        private bool CheckPreInsert( string param_pkinp1001
                                   , string param_to_gwa
                                   , string param_order_date
                                   , string param_to_ho_dong
                                   , string param_to_ho_code
                                   , string param_bed_no
                                   , string param_to_doctor)
        {
            bool vali_temp = true;
            try
            {                
                //0.퇴원예고체크
                string strSql = @"SELECT 'Y'
                                FROM DUAL
                               WHERE EXISTS ( SELECT 'X'
                                                FROM VW_OCS_INP1001_01 A
                                               WHERE A.HOSP_CODE = :f_hosp_code 
                                                 AND A.PKINP1001 = :f_fkinp1001
                                                 AND A.TOIWON_GOJI_YN = 'Y' )";


                BindVarCollection bindVar = new BindVarCollection();
                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar.Add("f_fkinp1001", param_pkinp1001);
                object rtn_yn = Service.ExecuteScalar(strSql, bindVar);

                if (rtn_yn != null && rtn_yn.ToString() == "Y")
                {
                    XMessageBox.Show("退院予告が完了され転棟転室を申し込む事ができません。");
                    vali_temp = false;
                    return vali_temp;
                }

                //1.과체크
                strSql = @"SELECT 'Y'
                         FROM DUAL
                        WHERE EXISTS ( SELECT 'X'
                                         FROM BAS0260 A
                                        WHERE A.HOSP_CODE  = :f_hosp_code
                                          AND A.GWA = TRIM(:f_to_gwa)
                                          AND A.BUSEO_GUBUN = '1'
                                          AND TO_DATE(:f_order_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE)";

                bindVar.Add("f_hosp_code", this.mHospCode);
                bindVar.Add("f_to_gwa", param_to_gwa);
                bindVar.Add("f_order_date", param_order_date);

                rtn_yn = Service.ExecuteScalar(strSql, bindVar);

                if (rtn_yn == null)//&& rtn_yn.ToString() != "Y"
                {
                    XMessageBox.Show("診療科が有効ではありません。ご確認ください。");
                    vali_temp = false;
                    return vali_temp;

                }

                //2.병동체크
                strSql = @"SELECT 'Y'
                         FROM DUAL
                        WHERE EXISTS ( SELECT 'X'
                                         FROM BAS0260 A
                                        WHERE A.HOSP_CODE = :f_hosp_code 
                                          AND A.GWA = TRIM(:f_to_ho_dong1)
                                          AND A.BUSEO_GUBUN = '2'
                                          AND TO_DATE(:f_order_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE )";

                bindVar.Add("f_to_ho_dong1", param_to_ho_dong);
                bindVar.Add("f_order_date", param_order_date);

                rtn_yn = Service.ExecuteScalar(strSql, bindVar);

                //3.병실체크
                strSql = @" SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS ( SELECT 'X'
                                          FROM BAS0250 A
                                         WHERE A.HOSP_CODE = :f_hosp_code 
                                           AND A.HO_DONG = :f_to_ho_dong1
                                           AND A.HO_CODE = :f_to_ho_code1
                                           AND TO_DATE(:f_order_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE )";
                bindVar.Add("f_to_ho_code1", param_to_ho_code);
                rtn_yn = Service.ExecuteScalar(strSql, bindVar);

                if (rtn_yn == null)//&& rtn_yn.ToString() != "Y"
                {
                    XMessageBox.Show("病室が有効ではありません。ご確認ください。");
                    vali_temp = false;
                    return vali_temp;

                }
                // 4.병상체크(이동하려는 병상을 현재 쓰고 있는지 체크)
                strSql = @" SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS (SELECT 'X'
                                             FROM VW_OCS_INP1001_01
                                            WHERE HOSP_CODE = :f_hosp_code 
                                              AND HO_DONG1              = :f_to_ho_dong1
                                              AND HO_CODE1              = :f_to_ho_code1
                                              AND BED_NO                = :f_to_bed_no
                                              AND NVL(JAEWON_FLAG, 'N') = 'Y'
                                              AND NVL(CANCEL_YN, 'N')   = 'N'
                                              AND BUNHO                <> :f_bunho  )"; //본인아닐때만..

                bindVar.Add("f_to_bed_no", param_bed_no);
                bindVar.Add("f_bunho", this.ptbPatient.BunHo);

                rtn_yn = Service.ExecuteScalar(strSql, bindVar);

                if (rtn_yn != null && rtn_yn.ToString() == "Y")
                {
                    XMessageBox.Show("移動先の病室の病床は既に使用中です。");
                    vali_temp = false;
                    return vali_temp;
                }
                //5.의사체크
                strSql = @"SELECT 'Y'
                        FROM DUAL
                       WHERE EXISTS ( SELECT 'X'
                                        FROM BAS0270 A
                                       WHERE A.HOSP_CODE = :f_hosp_code 
                                         AND A.DOCTOR_GWA = TRIM(:f_to_gwa)
                                         AND A.DOCTOR     = :f_to_doctor
                                         AND TO_DATE(:f_order_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE )";


                bindVar.Add("f_to_doctor", param_to_doctor);
                rtn_yn = Service.ExecuteScalar(strSql, bindVar);
                if (rtn_yn == null)//&& rtn_yn.ToString() != "Y"
                {
                    XMessageBox.Show("医師コードが有効ではありません。ご確認ください。");
                    vali_temp = false;
                    return vali_temp;
                }
            }
            catch (Exception x)
            {
               XMessageBox.Show(x.StackTrace.ToString());
               return vali_temp = false;
            }
            
            return vali_temp;
        }
        #endregion

        #region QueryStarting
        private void layCurrentBed_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCurrentBed.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCurrentBed.SetBindVarValue("f_bunho", ptbPatient.BunHo);
        }

         private void layHocodeBedno_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layHocodeBedno.SetBindVarValue("f_ho_dong", this.fbxToHoDong.GetDataValue());
            this.layHocodeBedno.SetBindVarValue("f_ho_code", this.fbxToHoCode.GetDataValue());
            this.layHocodeBedno.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void layMaxBedNo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layMaxBedNo.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layMaxBedNo.SetBindVarValue("f_ho_dong", this.fbxToHoDong.GetDataValue());
            this.layMaxBedNo.SetBindVarValue("f_ho_code_ymd ",IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
        }
        #endregion 

        #region GetConfirmData
        public int GetConfirmData(int param_pkinp1001, int param_trans_cnt, string param_bed_no, string param_user_id)
        {
            int rtnValue = 0;
            int o_max_trans = 0;
            int o_new_trans = 0;
            BindVarCollection confirmBindVar = new BindVarCollection();
            BindVarCollection sub_confirmBindVar = new BindVarCollection();
            string junpyo_date = string.Empty;
            /*입원정보 변경처리
              심사마감체크처리
               0.INP1001 정보변경처리
               2.이중유형에 대한 전실처리.->전과는 무시하고 전실은 이중유형에도 반영
               3.전실처리시(병동병실변경시) 영양실 네임카드 자동출력
               4.영양실 식이처방 병동병실정보수정
               5.특진여부 변경시 OCS2011반영
               6.고정차지 실행(반드시 영양실반영후 처리)
               7.슬립재처리(PR_INP_TRANS_SLIP)             */
            string strSql = @" SELECT A.FKINP1001
                                     ,A.BUNHO
                                     ,A.START_DATE
                                     ,A.TRANS_TIME
                                     ,A.TO_GWA
                                     ,A.TO_DOCTOR
                                     ,A.TO_RESIDENT
                                     ,A.TO_HO_CODE1
                                     ,A.TO_HO_DONG1
                                     ,A.TO_HO_CODE2
                                     ,A.TO_HO_DONG2
                                     ,A.TRANS_GUBUN
                                     ,A.TO_BED_NO
                                     ,A.TO_BED_NO2
                                     ,A.FROM_HO_CODE1
                                     ,A.FROM_HO_DONG1
                                     ,A.FROM_BED_NO
                                     ,A.TO_HO_GRADE1
                                     ,A.TO_HO_GRADE2
                                     ,A.TO_KAIKEI_HODONG
                                     ,A.TO_KAIKEI_HOCODE
                                 FROM INP2004 A
                                WHERE A.HOSP_CODE = :f_hosp_code
                                  AND A.FKINP1001 = :f_fkinp1001
                                  AND A.TRANS_CNT = :f_trans_cnt";

            confirmBindVar.Add("f_hosp_code", this.mHospCode);
            confirmBindVar.Add("f_fkinp1001", param_pkinp1001.ToString());
            confirmBindVar.Add("f_trans_cnt", param_trans_cnt.ToString());
            DataTable dtConfirm = Service.ExecuteDataTable(strSql, confirmBindVar);

            if (Service.ErrCode != 0 || dtConfirm.Rows.Count == 0 )
            {
                XMessageBox.Show("該当患者の転室情報の取り込み中にエラーが発生しました。", "エラー", MessageBoxIcon.Error);
                return 1;
            }
            string o_fkinp1001 = dtConfirm.Rows[0]["fkinp1001"].ToString();
            string o_bunho = dtConfirm.Rows[0]["bunho"].ToString();
            string o_order_date = dtConfirm.Rows[0]["start_date"].ToString();
            string o_trans_time = dtConfirm.Rows[0]["trans_time"].ToString();
            string o_to_gwa = dtConfirm.Rows[0]["to_gwa"].ToString();
            string o_to_doctor = dtConfirm.Rows[0]["to_doctor"].ToString();
            string o_to_resident = dtConfirm.Rows[0]["to_resident"].ToString();
            string o_to_ho_code1 = dtConfirm.Rows[0]["to_ho_code1"].ToString();
            string o_to_ho_dong1 = dtConfirm.Rows[0]["to_ho_dong1"].ToString();
            string o_to_ho_code2 = dtConfirm.Rows[0]["to_ho_code2"].ToString();
            string o_to_ho_dong2 = dtConfirm.Rows[0]["to_ho_dong2"].ToString();
            string o_trans_gubun = dtConfirm.Rows[0]["trans_gubun"].ToString();
            string o_to_bed_no = dtConfirm.Rows[0]["to_bed_no"].ToString();
            string o_to_bed_no2 = dtConfirm.Rows[0]["to_bed_no2"].ToString();
            string o_from_ho_code1 = dtConfirm.Rows[0]["from_ho_code1"].ToString();
            string o_from_ho_dong1 = dtConfirm.Rows[0]["from_ho_dong1"].ToString();
            string o_from_bed_no = dtConfirm.Rows[0]["from_bed_no"].ToString();
            string o_to_grade1 = dtConfirm.Rows[0]["to_ho_grade1"].ToString();
            string o_to_grade2 = dtConfirm.Rows[0]["to_ho_grade2"].ToString(); 
            string o_to_kaikei_hodong = dtConfirm.Rows[0]["to_kaikei_hodong"].ToString(); 
            string o_to_kaikei_hocode = dtConfirm.Rows[0]["to_kaikei_hocode"].ToString(); 
            string o_msg = string.Empty;

            /*0.퇴원예고체크*/
            string subStrSql = @"SELECT 'Y'
                                   FROM DUAL
                                  WHERE EXISTS (SELECT 'X'
                                                  FROM VW_OCS_INP1001_01 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code 
                                                   AND A.PKINP1001 = TO_NUMBER(:f_fkinp1001)
                                                   AND A.TOIWON_GOJI_YN = 'Y')";

            sub_confirmBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            sub_confirmBindVar.Add("f_fkinp1001", o_fkinp1001);
            Object rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (rtn_value != null && rtn_value.ToString().Equals("Y"))
            {
                XMessageBox.Show("退院予告が完了され転棟転室の確認ができません。", "注意", MessageBoxIcon.Asterisk);
                return 1;
            }

            string cmd = @" SELECT FN_INP_LOAD_SIMSA_YN(TO_NUMBER(:f_fkinp1001))
	                                   FROM DUAL";
            sub_confirmBindVar.Add("f_fkinp1001", o_fkinp1001);
            object inner_rtn = Service.ExecuteScalar(cmd, sub_confirmBindVar);
            sub_confirmBindVar.Clear();

            if (inner_rtn != null && inner_rtn.ToString().Equals("0"))
            {
                XMessageBox.Show("該当患者は実施締切が完了され転室できません。", "注意", MessageBoxIcon.Asterisk);
                return 1;
            }

            /*확인베드로 변경*/
            o_to_bed_no = param_bed_no;

            if (o_to_ho_dong1 == o_from_ho_dong1 &&
                o_to_ho_code1 == o_from_ho_code1 &&
                o_to_bed_no == o_from_bed_no)
            { }
            else
            {
                /*현재 확인된 베드체크*/
                subStrSql = @" SELECT 'Y'
                             FROM DUAL
                            WHERE EXISTS (SELECT 'X'
                                            FROM BAS0253 B
                                           WHERE B.HOSP_CODE = :f_hosp_code 
                                             AND B.HO_DONG   = :f_to_ho_dong
                                             AND B.HO_CODE   = :f_to_ho_code1
                                             AND B.BED_NO    = :f_to_bed_no
                                             AND B.BED_STATUS   IN ('00', '01')/*공베드,예약중 */
                                             AND TRUNC(SYSDATE) BETWEEN FROM_BED_DATE  
                                                                    AND NVL(TO_BED_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')))";

                sub_confirmBindVar.Add("f_to_ho_dong", this.fbxToHoDong.GetDataValue());
                sub_confirmBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                sub_confirmBindVar.Add("f_to_ho_code1", o_to_ho_code1);
                sub_confirmBindVar.Add("f_to_bed_no", o_to_bed_no);
                rtn_value = Service.ExecuteScalar(subStrSql, sub_confirmBindVar);
                sub_confirmBindVar.Clear();

                if (TypeCheck.IsNull(rtn_value))
                {
                    XMessageBox.Show("変更先病床が空床ではありません。ご確認ください。", "注意", MessageBoxIcon.Asterisk);
                    return 1;

                }
            }

            /* 먼저 여러번 전동 신청후 전동확인을 나중에 하는 경우 trans_cnt를 마지막으로 재부여 */
            this.layCommon.QuerySQL = @"SELECT MAX(TRANS_CNT)         max_trans_cnt,
                                               MAX(TRANS_CNT) + 1     new_trans_cnt
                                            FROM INP2004
                                           WHERE HOSP_CODE = :f_hosp_code
                                             AND FKINP1001 = :f_fkinp1001";

            this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCommon.SetBindVarValue("f_fkinp1001", o_fkinp1001);

            if (this.layCommon.QueryLayout())
            {
                o_max_trans = Convert.ToInt32(this.layCommon.GetItemValue("retVal1"));
                o_new_trans = Convert.ToInt32(this.layCommon.GetItemValue("retVal2"));
            }

            if (o_max_trans != param_trans_cnt)
            {
                o_max_trans = o_new_trans;
            }

            /*INP2004 전과전실확인*/
            ConfirmTrans(UserInfo.UserID, o_max_trans, param_bed_no, o_fkinp1001, param_trans_cnt);

            ConfirmTransCancel(UserInfo.UserID, o_fkinp1001);

            junpyo_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            /*0.입원정보변경처리*/

            BindVarCollection innerBindVar = new BindVarCollection();

             string innerSql = @"UPDATE INP1001                       
                                   SET  UPD_ID     = :f_upd_id
                                       ,UPD_DATE   = SYSDATE
                                       ,GWA        = TRIM(:f_to_gwa)  
                                       ,DOCTOR     = :f_to_doctor     
                                       ,RESIDENT   = :f_to_resident   
                                       ,HO_CODE1   = :f_to_ho_code1 
                                       ,HO_DONG1   = :f_to_ho_dong1 
                                       ,BED_NO     = :f_to_bed_no   
                                       ,BED_NO2    = :f_to_bed_no2     
                                       ,HO_CODE2   = :f_to_ho_code2   
                                       ,HO_DONG2   = :f_to_ho_dong2 
                                       ,HO_GRADE1  = :f_to_ho_grade1 
                                       ,HO_GRADE2  = :f_to_ho_grade2   
                                       ,KAIKEI_HODONG = :f_to_kaikei_hodong
                                       ,KAIKEI_HOCODE = :f_to_kaikei_hocode     
                                  WHERE HOSP_CODE  = :f_hosp_code
                                    AND PKINP1001   = TO_NUMBER(:f_fkinp1001)";

            innerBindVar.Add("f_hosp_code", this.mHospCode);
            innerBindVar.Add("f_to_gwa", o_to_gwa);
            innerBindVar.Add("f_to_doctor", o_to_doctor);
            innerBindVar.Add("f_to_resident", o_to_resident);
            innerBindVar.Add("f_to_ho_code1", o_to_ho_code1);
            innerBindVar.Add("f_to_ho_dong1", o_to_ho_dong1);
            innerBindVar.Add("f_to_bed_no", o_to_bed_no);
            innerBindVar.Add("f_to_bed_no2", o_to_bed_no2);
            innerBindVar.Add("f_to_ho_code2", o_to_ho_code2);
            innerBindVar.Add("f_to_ho_dong2", o_to_ho_dong2);
            innerBindVar.Add("f_to_ho_grade1", o_to_grade1);
            innerBindVar.Add("f_to_ho_grade2", o_to_grade2);
            innerBindVar.Add("f_fkinp1001", param_pkinp1001.ToString());
            innerBindVar.Add("f_upd_id", UserInfo.UserID);
            innerBindVar.Add("f_to_kaikei_hodong", o_to_kaikei_hodong);
            innerBindVar.Add("f_to_kaikei_hocode", o_to_kaikei_hocode);

            if (!Service.ExecuteNonQuery(innerSql, innerBindVar))
            {
                rtnValue = 1;
                throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }
            innerBindVar.Clear();

                //}
            //}

            if (o_from_ho_dong1.Equals(o_to_ho_dong1) && 
                o_from_ho_code1.Equals(o_to_ho_code1))// NurseCall Interface 전과전실
            {
                rtnValue = 0;
            }

        
            /*2.이중유형에 대한 전실처리.->전과는 무시하고 전실은 이중유형에도 반영*/
           ArrayList inputList = new ArrayList();
             ArrayList outputList = new ArrayList();

             inputList.Add('I');
             inputList.Add(param_user_id);
             inputList.Add(param_pkinp1001.ToString());
             inputList.Add('0');
             inputList.Add(o_bunho);
             inputList.Add(o_order_date.Substring(0,10));
             inputList.Add(o_trans_time);
             inputList.Add(o_to_ho_code1);
             inputList.Add(o_to_ho_dong1);
             inputList.Add(o_to_grade1);
             inputList.Add(o_to_ho_code2);
             inputList.Add(o_to_ho_dong2);
             inputList.Add(o_to_grade2);
             inputList.Add(o_to_bed_no);

             if (!Service.ExecuteProcedure("PR_INP_UPDATE_JENGWA", inputList, outputList))
             {
                 rtnValue = 1;
                 throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
             }

             if (outputList[0].ToString() != "0")
             {
                 rtnValue = 1;
                 throw new Exception("該当患者の二重入院情報病室変更時エラーが発生しました。");
             }
             else
             {
                 rtnValue = 0;
             }

             inputList.Clear();
             outputList.Clear();
            /*
                3.전실처리시(병동병실변경시) 영양실 네임카드 자동출력
                4.영양실 식이처방 병동병실정보수정
                5.특진여부 변경시 OCS2011반영
                6.고정차지 실행(반드시 영양실반영후 처리)
            */
           
          inputList.Add(param_pkinp1001.ToString());
          inputList.Add(o_bunho);
          inputList.Add(o_order_date.Substring(0,10));
          inputList.Add(junpyo_date);
          inputList.Add(o_to_doctor);
          inputList.Add(o_to_resident);
          inputList.Add(o_trans_gubun);
          inputList.Add(o_to_ho_dong1);
          inputList.Add(o_to_ho_code1);
          inputList.Add(param_user_id);

          if (Service.ExecuteProcedure("PR_NUR_CHANGE_GWAHODONG", inputList, outputList))
          {
              o_msg = outputList[0].ToString();
              if (o_msg != "0")
              {
                  rtnValue = 1;
                  throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
              }
          }
          else
          {
              rtnValue = 1;
              throw new Exception("該当患者の入院情報病室変更時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
          }

            sub_confirmBindVar.Clear();
            return rtnValue;

        }
        #endregion

        #region ConfirmTrans
        private void ConfirmTrans(string param_userId, int param_trans_cnt, string param_bed_no, string param_pkinp1001, int param_i_trans_cnt)
        {
            try
            {
                string strSql = @"UPDATE INP2004
                                      SET UPD_DATE              = SYSDATE
                                         ,UPD_ID                = :f_user_id
                                         ,TRANS_CNT             = :f_trans_cnt
                                         ,TO_NURSE_CONFIRM_ID   = :f_user_id
                                         ,TO_NURSE_CONFIRM_DATE = TO_CHAR(SYSDATE)
                                         ,TO_NURSE_CONFIRM_TIME = TO_CHAR(SYSDATE, 'HH24MI')
                                         ,TO_BED_NO             = DECODE(TRIM(:f_bed_no),NULL,TO_BED_NO,'',TO_BED_NO,:f_bed_no)
                                    WHERE HOSP_CODE             = :f_hosp_code
                                      AND BUNHO                 = :f_bunho
                                      AND FKINP1001             = :f_fkinp1001
                                      AND TRANS_CNT             = :f_i_trans_cnt";


                BindVarCollection bindVar = new BindVarCollection();
                bindVar.Add("f_hosp_code", this.mHospCode);
                bindVar.Add("f_bunho", this.ptbPatient.BunHo);
                bindVar.Add("f_user_id", param_userId);
                bindVar.Add("f_trans_cnt", param_trans_cnt.ToString());
                bindVar.Add("f_bed_no", param_bed_no);
                bindVar.Add("f_fkinp1001", param_pkinp1001);
                bindVar.Add("f_i_trans_cnt", param_i_trans_cnt.ToString());

                if (!Service.ExecuteNonQuery(strSql, bindVar))
                {
                    throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
                 }
            }
            catch
            {
                throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }

        }
        //전입전실을 취소 했을 경우. 간호사 확인 전..
        #endregion 

        #region ConfirmTransCancel
        private void ConfirmTransCancel(string param_userId, string param_pkinp1001)
        {
            BindVarCollection bindVars = new BindVarCollection();
            try
            {
                string strSql = @"UPDATE INP2004
                                     SET UPD_DATE  = SYSDATE
                                        ,UPD_ID    = :f_user_id
                                        ,CANCEL_YN = 'Y'
                                   WHERE HOSP_CODE = :f_hosp_code
                                      AND BUNHO     = :f_bunho
                                      AND FKINP1001 = :f_fkinp1001
                                     AND TO_NURSE_CONFIRM_DATE IS NULL";

                BindVarCollection bindVar = new BindVarCollection();
                bindVar.Add("f_hosp_code", this.mHospCode);
                bindVar.Add("f_bunho", this.ptbPatient.BunHo);
                bindVar.Add("f_user_id", param_userId);
                bindVar.Add("f_fkinp1001", param_pkinp1001);

                if (!Service.ExecuteNonQuery(strSql, bindVars))
                {
                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                        throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
                }

            }
            catch 
            {
                throw new Exception("該当患者の転室情報確認時にエラーが発生しました。\r\n" + Service.ErrFullMsg);
            }

        }
        #endregion


        private void layCurrentBed_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();
            object retVal = null;

            for (int i = 0; i < this.layCurrentBed.RowCount; i++)
            {
                cmdText = @"SELECT A.HO_TOTAL_BED
                              FROM BAS0250 A
                             WHERE A.HOSP_CODE    = :f_hosp_code
                               AND A.HO_CODE      = :f_ho_code
                               AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE";
                bc.Add("f_hosp_code", this.mHospCode);
                bc.Add("f_ho_code", this.layCurrentBed.GetItemString(i, "ho_code"));

                retVal = Service.ExecuteScalar(cmdText, bc);

                if (!TypeCheck.IsNull(retVal))
                {
                    this.layCurrentBed.SetItemValue(i, "tot_bed", retVal);
                }

                cmdText = @"SELECT NVL(MAX(TRANS_CNT),0)
                              FROM INP2004
                             WHERE HOSP_CODE = :f_hosp_code
                               AND BUNHO     = :f_bunho
                               AND FKINP1001 = :f_pkinp1001
                               AND NVL(CANCEL_YN, 'N') = 'N'";
                bc.Clear();
                bc.Add("f_hosp_code", this.mHospCode);
                bc.Add("f_bunho", ptbPatient.BunHo);
                bc.Add("f_pkinp1001", this.layCurrentBed.GetItemString(i, "pkinp1001"));

                retVal = Service.ExecuteScalar(cmdText, bc);

                if (!TypeCheck.IsNull(retVal))
                {
                    this.layCurrentBed.SetItemValue(i, "trans_cnt", retVal);
                }
            }
        }

        private void layHoSex_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layHoSex.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layHoSex.SetBindVarValue("f_ho_dong", this.fbxToHoDong.GetDataValue());
            this.layHoSex.SetBindVarValue("f_date", this.dtpJukyong_date.GetDataValue());
        }

        private void dtpJukyong_date_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //最終の転室日付を持って来る。
            string strSql = @" SELECT CASE WHEN :f_selected_date < MAX(START_DATE) 
                                             OR :f_selected_date > TRUNC(SYSDATE) THEN 'N'
                                           ELSE 'Y'
                                            END CASE
                                           FROM INP2004 A
                                          WHERE A.HOSP_CODE = :f_hosp_code
                                            AND A.FKINP1001 = :f_fkinp1001 ";
               
            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_fkinp1001", mPkinp1001.ToString());
            bindVar.Add("f_selected_date", dtpJukyong_date.GetDataValue());

            object retVal = Service.ExecuteScalar(strSql, bindVar);

            
            if (retVal == null || retVal.ToString() == "")
            {

                XMessageBox.Show("日付読み取りに失敗しました。", "警告", MessageBoxIcon.Warning);
                return;
            }
            else //比較して最終転室日より前の場合は転室出来ない。
            {
                if (retVal.ToString() == "N")
                {
                    XMessageBox.Show("前回転室した日より前か今日以降の日は選択できません。\r\n"
                                      + "確認してください", "警告", MessageBoxIcon.Information);
                    dtpJukyong_date.SetDataValue(EnvironInfo.GetSysDate());
                    return;
                }
            }
        }

        private void fbxToHodong_FindSelected(object sender, FindEventArgs e)
        {
            cboToKaikei_HoDong.SetDataValue(fbxToHoDong.GetDataValue());
        }

        private void fbxToHoCode_FindSelected(object sender, FindEventArgs e)
        {
            cboToKaikei_HoCode.SetDataValue(fbxToHoCode.GetDataValue());
        }

        private void cboToKaikei_HoCode_DDLBSetting(object sender, EventArgs e)
        {
            cboToKaikei_HoCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            cboToKaikei_HoCode.SetBindVarValue("f_kaikei_hodong", cboToKaikei_HoDong.GetDataValue());
        }

        private void cboToKaikei_HoDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboToKaikei_HoCode.SetDictDDLB();
            cboToKaikei_HoCode.ResetData();
        }
    }
}

