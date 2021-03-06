using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using IHIS.Framework;

namespace IHIS.OCSI
{
	/// <summary>
	/// FormSettingHopeDate에 대한 요약 설명입니다.
	/// </summary>
	public class OCS2003Q11 : IHIS.Framework.XScreen
	{
		////////////////////////////////// Screen Level 개발자 변수 기술 ///////////////////////////////////
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리

		private Hashtable mHtControl = null;

        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;

		private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XLabel lblJaewon_Ho_Dong;
		private IHIS.Framework.XLabel lblOrder_DateTitle;
		private IHIS.Framework.XComboBox cboHo_Dong;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.MultiLayout dataLayoutMIO;
		private IHIS.Framework.XDataWindow dw_1;
		private IHIS.Framework.XDatePicker dtpOrder_Date;
		private IHIS.Framework.MultiLayout layQuery;
		private IHIS.Framework.MultiLayout layData;
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
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem98;
        private MultiLayoutItem multiLayoutItem99;
        private XButton btnCPLList;
        private XPanel pnlSession;
        private XLabel xLabel1;
        private XCheckBox cbxA;
        private XCheckBox cbxB;
        private XCheckBox cbxC;
        private XCheckBox cbxD;
		private System.ComponentModel.IContainer components = null;

		public OCS2003Q11()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2003Q11));
            this.pnlFill = new IHIS.Framework.XPanel();
            this.dw_1 = new IHIS.Framework.XDataWindow();
            this.dataLayoutMIO = new IHIS.Framework.MultiLayout();
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
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlSession = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.dtpOrder_Date = new IHIS.Framework.XDatePicker();
            this.lblOrder_DateTitle = new IHIS.Framework.XLabel();
            this.cboHo_Dong = new IHIS.Framework.XComboBox();
            this.lblJaewon_Ho_Dong = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnCPLList = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layQuery = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem98 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.layData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutMIO)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSession.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layData)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "채열실.ico");
            // 
            // pnlFill
            // 
            this.pnlFill.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlFill.Controls.Add(this.dw_1);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Location = new System.Drawing.Point(0, 34);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1096, 716);
            this.pnlFill.TabIndex = 1;
            // 
            // dw_1
            // 
            this.dw_1.DataWindowObject = "d_ocs2003q11_2";
            this.dw_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_1.LibraryList = "..\\OCSI\\ocsi.ocs2003q11.pbd";
            this.dw_1.Location = new System.Drawing.Point(0, 0);
            this.dw_1.Name = "dw_1";
            this.dw_1.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dw_1.Size = new System.Drawing.Size(1094, 714);
            this.dw_1.TabIndex = 0;
            this.dw_1.Text = "xDataWindow1";
            // 
            // dataLayoutMIO
            // 
            this.dataLayoutMIO.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem13});
            this.dataLayoutMIO.QuerySQL = resources.GetString("dataLayoutMIO.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sort_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "order_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "order_gubun_name";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "ho_code";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "bunho";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "suname";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "suname2";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_code";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "hangmog_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "input_gubun";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "input_gubun_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "pkocs2003";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "comment";
            // 
            // pnlTop
            // 
            this.pnlTop.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlTop.Controls.Add(this.pnlSession);
            this.pnlTop.Controls.Add(this.dtpOrder_Date);
            this.pnlTop.Controls.Add(this.lblOrder_DateTitle);
            this.pnlTop.Controls.Add(this.cboHo_Dong);
            this.pnlTop.Controls.Add(this.lblJaewon_Ho_Dong);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1096, 34);
            this.pnlTop.TabIndex = 1;
            // 
            // pnlSession
            // 
            this.pnlSession.Controls.Add(this.xLabel1);
            this.pnlSession.Controls.Add(this.cbxA);
            this.pnlSession.Controls.Add(this.cbxB);
            this.pnlSession.Controls.Add(this.cbxC);
            this.pnlSession.Controls.Add(this.cbxD);
            this.pnlSession.Location = new System.Drawing.Point(292, 5);
            this.pnlSession.Name = "pnlSession";
            this.pnlSession.Size = new System.Drawing.Size(202, 22);
            this.pnlSession.TabIndex = 32;
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(2, 1);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(34, 20);
            this.xLabel1.TabIndex = 28;
            this.xLabel1.Text = "病棟";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxA
            // 
            this.cbxA.AutoSize = true;
            this.cbxA.Location = new System.Drawing.Point(40, 3);
            this.cbxA.Name = "cbxA";
            this.cbxA.Size = new System.Drawing.Size(31, 17);
            this.cbxA.TabIndex = 14;
            this.cbxA.Text = "A";
            this.cbxA.UseVisualStyleBackColor = false;
            this.cbxA.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxB
            // 
            this.cbxB.AutoSize = true;
            this.cbxB.Location = new System.Drawing.Point(82, 3);
            this.cbxB.Name = "cbxB";
            this.cbxB.Size = new System.Drawing.Size(31, 17);
            this.cbxB.TabIndex = 15;
            this.cbxB.Text = "B";
            this.cbxB.UseVisualStyleBackColor = false;
            this.cbxB.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxC
            // 
            this.cbxC.AutoSize = true;
            this.cbxC.Location = new System.Drawing.Point(124, 3);
            this.cbxC.Name = "cbxC";
            this.cbxC.Size = new System.Drawing.Size(32, 17);
            this.cbxC.TabIndex = 16;
            this.cbxC.Text = "C";
            this.cbxC.UseVisualStyleBackColor = false;
            this.cbxC.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxD
            // 
            this.cbxD.AutoSize = true;
            this.cbxD.Location = new System.Drawing.Point(167, 3);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(31, 17);
            this.cbxD.TabIndex = 17;
            this.cbxD.Text = "D";
            this.cbxD.UseVisualStyleBackColor = false;
            this.cbxD.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // dtpOrder_Date
            // 
            this.dtpOrder_Date.AllowDrop = true;
            this.dtpOrder_Date.Location = new System.Drawing.Point(72, 6);
            this.dtpOrder_Date.Name = "dtpOrder_Date";
            this.dtpOrder_Date.Size = new System.Drawing.Size(94, 20);
            this.dtpOrder_Date.TabIndex = 0;
            // 
            // lblOrder_DateTitle
            // 
            this.lblOrder_DateTitle.AllowDrop = true;
            this.lblOrder_DateTitle.EdgeRounding = false;
            this.lblOrder_DateTitle.Location = new System.Drawing.Point(6, 6);
            this.lblOrder_DateTitle.Name = "lblOrder_DateTitle";
            this.lblOrder_DateTitle.Size = new System.Drawing.Size(64, 20);
            this.lblOrder_DateTitle.TabIndex = 31;
            this.lblOrder_DateTitle.Text = "オーダ日付";
            // 
            // cboHo_Dong
            // 
            this.cboHo_Dong.Location = new System.Drawing.Point(202, 6);
            this.cboHo_Dong.MaxDropDownItems = 30;
            this.cboHo_Dong.Name = "cboHo_Dong";
            this.cboHo_Dong.Size = new System.Drawing.Size(84, 21);
            this.cboHo_Dong.TabIndex = 1;
            // 
            // lblJaewon_Ho_Dong
            // 
            this.lblJaewon_Ho_Dong.EdgeRounding = false;
            this.lblJaewon_Ho_Dong.Location = new System.Drawing.Point(168, 6);
            this.lblJaewon_Ho_Dong.Name = "lblJaewon_Ho_Dong";
            this.lblJaewon_Ho_Dong.Size = new System.Drawing.Size(34, 20);
            this.lblJaewon_Ho_Dong.TabIndex = 27;
            this.lblJaewon_Ho_Dong.Text = "病棟";
            this.lblJaewon_Ho_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlBottom.Controls.Add(this.btnCPLList);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 750);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1096, 36);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnCPLList
            // 
            this.btnCPLList.ImageIndex = 0;
            this.btnCPLList.ImageList = this.ImageList;
            this.btnCPLList.Location = new System.Drawing.Point(721, 3);
            this.btnCPLList.Name = "btnCPLList";
            this.btnCPLList.Size = new System.Drawing.Size(123, 28);
            this.btnCPLList.TabIndex = 2;
            this.btnCPLList.Text = "採血リスト出力";
            this.btnCPLList.Click += new System.EventHandler(this.btnCPLList_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(850, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 1;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layQuery
            // 
            this.layQuery.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem98,
            this.multiLayoutItem99});
            this.layQuery.QuerySQL = resources.GetString("layQuery.QuerySQL");
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "bunho";
            this.multiLayoutItem14.IsUpdItem = true;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "suname";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "ho_code";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "fkinp1001";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem17.IsUpdItem = true;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "fkocs6010";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem18.IsUpdItem = true;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "cp_name";
            this.multiLayoutItem19.IsUpdItem = true;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "order_date";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.DateTime;
            this.multiLayoutItem20.IsUpdItem = true;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "order_end_date";
            this.multiLayoutItem28.DataType = IHIS.Framework.DataType.DateTime;
            this.multiLayoutItem28.IsUpdItem = true;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "input_gubun";
            this.multiLayoutItem29.IsUpdItem = true;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "input_gubun_name";
            this.multiLayoutItem30.IsUpdItem = true;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "order_gubun";
            this.multiLayoutItem31.IsUpdItem = true;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "order_gubun_name";
            this.multiLayoutItem32.IsUpdItem = true;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "hangmog_code";
            this.multiLayoutItem33.IsUpdItem = true;
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "hangmog_name";
            this.multiLayoutItem34.IsUpdItem = true;
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "suryang";
            this.multiLayoutItem35.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "nalsu";
            this.multiLayoutItem36.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "detail";
            this.multiLayoutItem37.IsUpdItem = true;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "order_remark";
            this.multiLayoutItem38.IsUpdItem = true;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "nurse_remark";
            this.multiLayoutItem39.IsUpdItem = true;
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "tel_yn";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "emergency";
            this.multiLayoutItem41.IsUpdItem = true;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "jusa_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "bogyong_name";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "jaewonil";
            this.multiLayoutItem44.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem44.IsUpdItem = true;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "pk";
            this.multiLayoutItem45.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem45.IsUpdItem = true;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "group_ser";
            this.multiLayoutItem46.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem46.IsUpdItem = true;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "mix_group";
            this.multiLayoutItem47.IsUpdItem = true;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "table_id";
            this.multiLayoutItem48.IsUpdItem = true;
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "confirm_yn";
            this.multiLayoutItem49.IsUpdItem = true;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "acting_yn";
            this.multiLayoutItem50.IsUpdItem = true;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "can_plan_change_yn";
            this.multiLayoutItem51.IsUpdItem = true;
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "can_confirm_yn";
            this.multiLayoutItem52.IsUpdItem = true;
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "can_acting_yn";
            this.multiLayoutItem53.IsUpdItem = true;
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "can_plan_app_yn";
            this.multiLayoutItem54.IsUpdItem = true;
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "input_name";
            this.multiLayoutItem55.IsUpdItem = true;
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "input_seq";
            this.multiLayoutItem56.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem56.IsUpdItem = true;
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "order_end_yn";
            this.multiLayoutItem57.IsUpdItem = true;
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "confirm_name";
            this.multiLayoutItem58.IsUpdItem = true;
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "inj_act_yn";
            this.multiLayoutItem98.IsUpdItem = true;
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "bulyong_check";
            this.multiLayoutItem99.IsUpdItem = true;
            // 
            // layData
            // 
            this.layData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27});
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "bunho";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "suname";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "note1";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "note2";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "note3";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "note4";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "ho_code";
            // 
            // OCS2003Q11
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "OCS2003Q11";
            this.Size = new System.Drawing.Size(1096, 786);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS2003Q11_Closing);
            this.UserChanged += new System.EventHandler(this.OCS2003Q11_UserChanged);
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutMIO)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layData)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [메소드 모듈]

		#region HashTable과 연결할 Control's Setting (SetHashTableBinding)
		/// <summary>
		/// HashTable과 연결할 Control's Setting
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="aHt"> HashTable 해당 Object </param>
		/// <param name="aObj"> object 해당 Object </param>
		/// <returns> void </returns>
		private void SetHashTableBinding(Hashtable aHt, object aObj)
		{
			if (aObj == null) return;

			if (aHt == null) aHt = new Hashtable();

			try
			{
				if (aObj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
				{					
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XComboBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XComboBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XComboBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XComboBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XComboBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XComboBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XComboBox)aObj).SelectedIndexChanged += new System.EventHandler(this.Control_SelectedIndexChanged);
				}
				else if (aObj.GetType().Name.ToString().IndexOf("XListBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XListBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XListBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XListBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XListBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XListBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XListBox)aObj).SelectedIndexChanged += new System.EventHandler(this.Control_SelectedIndexChanged);
				}
				else if(aObj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XTextBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XTextBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XTextBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XTextBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XTextBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XTextBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
				{						
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XEditMask)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XEditMask)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XEditMask)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XEditMask)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XEditMask)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XEditMask)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XCheckBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XCheckBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XCheckBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XCheckBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XCheckBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XCheckBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XCheckBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XCheckBox)aObj).CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
				}
				else if(aObj.GetType().ToString().IndexOf("XRadioButton") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XRadioButton)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XRadioButton)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XRadioButton)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XRadioButton)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XRadioButton)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XRadioButton)aObj).CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
				}
				else if(aObj.GetType().ToString().IndexOf("XDatePicker") >= 0)
				{
	
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add
	
					((XDatePicker)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XDatePicker)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XDatePicker)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XDatePicker)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XDatePicker)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XDatePicker)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XDisplayBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XDisplayBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XDisplayBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XDisplayBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XDisplayBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XDisplayBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
				}
				else if(aObj.GetType().ToString().IndexOf("XMemoBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XMemoBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XMemoBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XMemoBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XMemoBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XMemoBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XMemoBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
					((XMemoBox)aObj).OKButtonClicked += new System.EventHandler(this.Control_OKButtonClicked); // Ok버튼 클릭
				}
				else if(aObj.GetType().ToString().IndexOf("XFindBox") >= 0)
				{
					aHt.Add(this.mOrderFunc.GetHashTableColumnName(aObj), aObj); // Add

					((XFindBox)aObj).Enter += new System.EventHandler(this.Control_Enter);
					((XFindBox)aObj).Leave += new System.EventHandler(this.Control_Leave);
					((XFindBox)aObj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
					((XFindBox)aObj).DoubleClick += new System.EventHandler(this.Control_DoubleClick);
					((XFindBox)aObj).KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
					((XFindBox)aObj).KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);

					((XFindBox)aObj).FindClick += new System.ComponentModel.CancelEventHandler(this.Control_FindClick);
					((XFindBox)aObj).FindSelected += new IHIS.Framework.FindEventHandler(this.Control_FindSelected);
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "HashTable Binding Error");
			}
		}
		#endregion

        //#region 간호업무계획서 리스트 조회 Service Call (QueryList)
        ///// <summary>
        ///// 간호업무계획서 리스트 조회 Service Call
        ///// </summary>
        ///// <param name="aOrderDate"> string 처방일자 </param>
        ///// <param name="aHoDong"> string 병동 </param>
        ///// <param name="aHoTeam"> string 병동팀 </param>
        ///// <returns> bool </returns>
        //public bool QueryList(string aOrderDate, string aHoDong, string aHoTeam)
        //{	
        //    bool isSuccess = false;

        //    try
        //    {
        //        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계				

        //        // 입원간호처방 : 병동은 필수 간호팀은 %허용
        //        string order_date, ho_dong, ho_team;

        //        order_date = aOrderDate;
        //        ho_dong = aHoDong; ho_team = aHoTeam;

        //        ho_dong = this.cboHo_Dong.GetDataValue(); 
        //        //ho_team = this.fbxHo_Team.GetDataValue();

        //        if (TypeCheck.IsNull(ho_team))  ho_team = "%";											

        //        this.dataLayoutMIO.SetBindVarValue("f_order_date" , order_date);
        //        this.dataLayoutMIO.SetBindVarValue("f_ho_dong", ho_dong);
        //        this.dataLayoutMIO.SetBindVarValue("f_ho_team", ho_team);
        //        this.dataLayoutMIO.SetBindVarValue("f_hosp_code", mHospCode);

        //        XMessageBox.Show("f_order_date : " + order_date + "\n\r"
        //                  + "f_ho_dong : " + ho_dong + "\n\r"
        //                  + "f_ho_team : " + ho_team + "\n\r", "dataLayoutMIO");        

        //        isSuccess = dataLayoutMIO.QueryLayout(false); // 데이타 조회

        //        this.dw_1.Reset(); // 데이타 원도우 Reset

        //        if (isSuccess && this.dataLayoutMIO.RowCount > 0)
        //        {
        //            this.dw_1.FillChildData("dw_child_1", this.dataLayoutMIO.LayoutTable);
        //            //this.dw_1.SetFooterImage(); // 병원이미지 표시

        //            // 타이틀 표시 (조회 조건 + 업무계획서)
        //            string text = "";
        //            if (TypeCheck.IsNull(this.fbxHo_Team.GetDataValue()) || this.fbxHo_Team.GetDataValue() == "%")
        //            {
        //                text = this.cboHo_Dong.Text + " " + (NetInfo.Language == LangMode.Jr ?  "全体" : "전체");
        //            }
        //            else
        //            {
        //            text = this.cboHo_Dong.Text + " " + this.fbxHo_Team.GetDataValue() + (NetInfo.Language == LangMode.Jr ?  "チーム" : " 팀");
        //            }

        //            text += NetInfo.Language == LangMode.Jr ?  " 業務計画書" : " 업무계획서";
					
        //            this.dw_1.SetObjectText("t_title", text); //this.dw_1.Modify("t_title.Text='" + text + "'");
        //        }

        //    }
        //    finally
        //    {
        //        Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
        //    }

        //    return isSuccess;
        //}
        //#endregion

		#region 데이터윈도우에 데이터를 셋팅한다.
		/// <summary>
		/// Data를 Setting한다.
		/// </summary>
		private void LayoutData()
		{
			string displayText = "";
			string aold_bunho  = string.Empty;
			string anew_bunho  = string.Empty;
			string order_date  = string.Empty;
			string ho_dong     = string.Empty;
			string ho_team     = string.Empty;

			//처치텍스트
			string note1_text = string.Empty;
			//검사텍스트
			string note2_text = string.Empty;
			//화상텍스트
			string note3_text = string.Empty;
			//리하비리텍스트
			string note4_text = string.Empty;

			order_date = this.dtpOrder_Date.GetDataValue().ToString();
			ho_dong = this.cboHo_Dong.GetDataValue();
			//ho_team = this.fbxHo_Team.GetDataValue();
            ho_team = (cbxA.Checked ? "A " : "") + (cbxB.Checked ? "B " : "") + (cbxC.Checked ? "C " : "") + (cbxD.Checked ? "D " : "");

            if (ho_team.Length == 0)
            {
                ho_team = "A B C D ";
            }

			if (TypeCheck.IsNull(ho_team))  ho_team = "%";											

			this.layData.Reset();

			this.layQuery.SetBindVarValue("f_query_date" , order_date);
            this.layQuery.SetBindVarValue("f_ho_dong", ho_dong);
            this.layQuery.SetBindVarValue("f_ho_team", ho_team);
            this.layQuery.SetBindVarValue("f_hosp_code", mHospCode);
            this.layQuery.SetBindVarValue("f_a", cbxA.GetDataValue());
            this.layQuery.SetBindVarValue("f_b", cbxB.GetDataValue());
            this.layQuery.SetBindVarValue("f_c", cbxC.GetDataValue());
            this.layQuery.SetBindVarValue("f_d", cbxD.GetDataValue());

    
			if (layQuery.QueryLayout(true))
			{
                
            	for(int i = 0; i < this.layQuery.RowCount; i++)
				{
					aold_bunho  = this.layQuery.GetItemString(i, "bunho");
			    
					displayText = "      ";
                
					if( this.layQuery.GetItemString(i,"table_id") == "OCS2003" || this.layQuery.GetItemString(i,"table_id") == "OCS6013" )
					{  
						// 오더불용
						if( this.layQuery.GetItemString(i,"bulyong_check").Trim() == "Y" )
							displayText = displayText + "ⓧ オーダ不用 \r\n";

                        /*
						//Order중지여부
						if( this.layQuery.GetItemString(i,"order_end_yn").Trim() == "Y" )
							displayText = displayText + "ⓧ オーダ中止 \r\n";
                        */

						//진행중인 예정명칭 표시
						if( this.layQuery.GetItemString(i,"table_id") == "OCS6013")
						{
							displayText = displayText + "『" +   this.layQuery.GetItemString(i,"cp_name") + "』\r\n";
						}

                        //group Ser, mix 표시
                        //displayText = displayText + "【 GR " +   this.layQuery.GetItemString(i,"group_ser");		
                        //if( !TypeCheck.IsNull(this.layQuery.GetItemString(i,"mix_group").Trim()) )
                        //    displayText = displayText + " MIX " +   this.layQuery.GetItemString(i,"mix_group");

                        //displayText = displayText + " 】\r\n";

					}
                
					// 주기Order여부 표시
					if( this.layQuery.GetItemString(i,"table_id") == "OCS6013" && this.layQuery.GetItemString(i,"can_plan_change_yn") == "N")
						displayText = displayText + "[周期]" + this.layQuery.GetItemString(i, "hangmog_name") + "\r\n";
					else
						displayText = displayText +  " □ " + this.layQuery.GetItemString(i, "hangmog_name");
                    displayText = this.layQuery.GetItemString(i, "detail").Trim() == "" ? displayText + "\r\n" : displayText + " * " + this.layQuery.GetItemString(i, "detail") + "\r\n";
					displayText = this.layQuery.GetItemString(i, "jusa_name"   ).Trim() == "" ? displayText + "" : displayText + "    ┗ "       + this.layQuery.GetItemString(i, "jusa_name"   ) + "\r\n";
                    //displayText = this.layQuery.GetItemString(i, "bogyong_name").Trim() == "" ? displayText + "" : displayText + "    ┗ "       + this.layQuery.GetItemString(i, "bogyong_name") + "\r\n";
					displayText = this.layQuery.GetItemString(i, "order_remark").Trim() == "" ? displayText + "" : displayText + "    ┗ "       + this.layQuery.GetItemString(i, "order_remark") + "\r\n";
                    displayText = this.layQuery.GetItemString(i, "nurse_remark").Trim() == "" ? displayText + "" : displayText + "    ┗ [看護]" + this.layQuery.GetItemString(i, "nurse_remark") + "\r\n";
				
					//if(UserInfo.UserGubun != UserType.Doctor)
					//의사 지시 order경우 표시
					if( this.layQuery.GetItemString(i, "tel_yn" ).Trim() == "Y")
						displayText = this.layQuery.GetItemString(i, "input_name"  ).Trim() == ""  ? displayText + "" : displayText + "    ☞ [医師指示]\r\n" + this.layQuery.GetItemString(i, "input_name");
                    else
                        displayText = this.layQuery.GetItemString(i, "input_name"  ).Trim() == ""  ? displayText + "" : displayText + "    ☞ " + this.layQuery.GetItemString(i, "input_name");

                    //displayText = this.layQuery.GetItemString(i, "confirm_name"  ).Trim() == "" ? displayText + "" : displayText + "\r\n[オーダ確認] " + this.layQuery.GetItemString(i, "confirm_name");

					displayText =  displayText + "\r\n";

					if (aold_bunho != anew_bunho)
					{
						note1_text = "";
						note2_text = "";
						note3_text = "";
						note4_text = "";
						this.layData.InsertRow(-1);
					}

                    // H：処置
					if (this.layQuery.GetItemString(i, "order_gubun") == "H")
					{
						if (note1_text == "")
						{
							note1_text = displayText.Trim();
						}
						else
						{
							note1_text = note1_text + "\r\n" + displayText.Trim();
						}
					}

                    // N：生理検査、O:病理検査
                    //if (this.layQuery.GetItemString(i, "order_gubun") == "F" || this.layQuery.GetItemString(i, "order_gubun") == "O" || this.layQuery.GetItemString(i, "order_gubun") == "N")
                    if (this.layQuery.GetItemString(i, "order_gubun") == "N" || this.layQuery.GetItemString(i, "order_gubun") == "O")
					{
						if (note2_text == "")
						{
							note2_text = displayText.Trim();
						}
						else
						{
							note2_text = note2_text + "\r\n" + displayText.Trim();
						}
					}
					
                    // E：放射線
					if (this.layQuery.GetItemString(i, "order_gubun") == "E")
					{
						if (note3_text == "")
						{
							note3_text = displayText.Trim();
						}
						else
						{
							note3_text = note3_text + "\r\n" + displayText.Trim();
						}
					}
					
                    //　リハビリ、　G：手術
					if (this.layQuery.GetItemString(i, "order_gubun") == "G")
					{
						if (note4_text == "")
						{
							note4_text = displayText.Trim();
						}
						else
						{
							note4_text = note4_text + "\r\n" + displayText.Trim();
						}
					}

					this.layData.SetItemValue(this.layData.RowCount - 1, "bunho", this.layQuery.GetItemString(i, "bunho"));
					this.layData.SetItemValue(this.layData.RowCount - 1, "suname", this.layQuery.GetItemString(i, "suname"));
                    this.layData.SetItemValue(this.layData.RowCount - 1, "ho_code", this.layQuery.GetItemString(i, "ho_code"));

					if (this.layQuery.GetItemString(i, "order_gubun").Trim() == "H")
					{
						this.layData.SetItemValue(this.layData.RowCount - 1, "note1", "");
						this.layData.SetItemValue(this.layData.RowCount - 1, "note1", note1_text);
					}

                    //if (this.layQuery.GetItemString(i, "order_gubun").Trim() == "F" || this.layQuery.GetItemString(i, "order_gubun").Trim() == "O" || this.layQuery.GetItemString(i, "order_gubun").Trim() == "N")
                    if (this.layQuery.GetItemString(i, "order_gubun").Trim() == "F" || this.layQuery.GetItemString(i, "order_gubun").Trim() == "O" || this.layQuery.GetItemString(i, "order_gubun").Trim() == "N")
					{
						this.layData.SetItemValue(this.layData.RowCount - 1, "note2", "");
						this.layData.SetItemValue(this.layData.RowCount - 1, "note2", note2_text);
					}

					if (this.layQuery.GetItemString(i, "order_gubun").Trim() == "E")
					{
						this.layData.SetItemValue(this.layData.RowCount - 1, "note3", "");
						this.layData.SetItemValue(this.layData.RowCount - 1, "note3", note3_text);
					}

					if (this.layQuery.GetItemString(i, "order_gubun").Trim() == "G")
					{
						this.layData.SetItemValue(this.layData.RowCount - 1, "note4", "");
						this.layData.SetItemValue(this.layData.RowCount - 1, "note4", note4_text);
					}

					anew_bunho = this.layQuery.GetItemString(i, "bunho");
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg);
				return;
			}

			this.dw_1.Reset();

			this.dw_1.FillData(this.layData.LayoutTable);
			//this.dw_1.SetFooterImage(); // 병원이미지 표시

			// 타이틀 표시 (조회 조건 + 업무계획서)
			string text = "";

            //if (TypeCheck.IsNull(this.fbxHo_Team.GetDataValue()) || this.fbxHo_Team.GetDataValue() == "%")
            //{
            //    text = this.cboHo_Dong.Text + " " + (NetInfo.Language == LangMode.Jr ?  "全体" : "전체");
            //}
            //else
            //{
            //    text = this.cboHo_Dong.Text + " " + this.fbxHo_Team.GetDataValue() + (NetInfo.Language == LangMode.Jr ?  "チーム" : " 팀");
            //}

            text = this.cboHo_Dong.Text + " " + ho_team + (NetInfo.Language == LangMode.Jr ? "チーム" : " 팀");

			text += NetInfo.Language == LangMode.Jr ?  " 業務計画書" : " 업무계획서";

			this.dw_1.Modify("t_title.Text = '" + text +"'");

            this.dw_1.Modify("t_order_date.Text = '" + order_date + "'");
					

			//this.dw_1.SetObjectText("t_title", text); //this.dw_1.Modify("t_title.Text='" + text + "'");
		}
		#endregion

		#endregion
		///////////////////////////////////////////////////////////////////////////////////////////////////////

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [Screen Event]
		/// <summary>
		/// Screen Load시 Post Event로 Call 되서 Load시 처리할 로직들을 기술한다
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			this.PostLoad();

		}
		private void PostLoad()
		{
			// 화면 크기를 화면에 맞게 최대화 시킨다
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);
            
			// HashTable과 연결할 Control's Setting
			foreach(object obj in this.pnlTop.Controls) this.SetHashTableBinding(this.mHtControl, obj);
			
			// Combo 세팅
			DataTable dtTemp = null;

			// 병동(반드시 입력)
			dtTemp  = this.mOrderBiz.LoadComboDataSource("ho_dong").LayoutTable;
			this.cboHo_Dong.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);

			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS2003Q11_UserChanged(this, new System.EventArgs()); //this.OnUserChanged();
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}

		private void OCS2003Q11_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		/// <summary>
		/// 사용자 변경시
		/// </summary>
		/// <remarks>
		/// 사용자 구분에 따른 입력필드 정의
		/// </remarks>
		private void OCS2003Q11_UserChanged(object sender, System.EventArgs e)
		{
			// Control 초기화
			this.Reset();

			// 디폴트 값 세팅			
			this.dtpOrder_Date.SetDataValue(EnvironInfo.GetSysDate());
							
			//this.fbxHo_Team.SetDataValue("");                            // 간호팀 전체	 
			this.cboHo_Dong.SetDataValue(IHIS.Framework.UserInfo.HoDong); // 간호사 병동

            btnList.PerformClick(FunctionType.Query);
		}

		#endregion
		///////////////////////////////////////////////////////////////////////////////////////////////////////

		#region 타Screen에서 Open (Command)	
		public override object Command(string command, CommonItemCollection commandParam)
		{                       
//			switch(command.Trim())
//			{
//				case "retrieve": // 데이타 재조회
//					#region
//
//					this.btnQuery.PerformClick();
//
//					break;
//					#endregion
//			}

			return base.Command(command, commandParam);
		}
		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [Control's Event]
		
		#region Control Get Focus시 구동 Event (Control_Enter)
		/// <summary>
		/// 이전 Value값 Tag에 저장. 추후 Validation Chek 이전 Value로 Undo하기 위함
		/// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
		/// </summary>
		private void Control_Enter(object sender, System.EventArgs e)
		{
			if (sender == null) return;

			if (sender is IDataControl && sender is Control)
			{
				((Control)sender).Tag = ((IDataControl)sender).DataValue.ToString();
			}
		}
		#endregion

		#region Control Lost Focus시 구동 Event (Control_Leave)
		/// <summary>
		/// </summary>
		private void Control_Leave(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control Value변경시 처리 Event (Control_DataValidating)
		/// <summary>
		/// Binding된 Grid가 있는 경우 Current Grid 세팅등도 해야함
		/// </summary>
		private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{	
			if (sender == null) return;
			
			////string mbxMsg = "", mbxCap = "";
			string colName = this.mOrderFunc.GetHashTableColumnName(sender); // 현재 매핑되는 컬럼명을 얻어온다
		
			switch (colName)
			{
				case "ho_team": // 병동별 간호팀

					////this.btnList.PerformClick(FunctionType.Query);

					break;

				default:
					break;
			}
		}
		#endregion

		#region Control 더블클릭시 구동 Event (Control_DoubleClick)
		/// <summary>
		/// </summary>
		private void Control_DoubleClick(object sender, System.EventArgs e)
		{
			if (sender == null) return;
		}
		#endregion

		#region Control KeyDown Event (Control_KeyDown)
		/// <summary>
		/// </summary>
		private void Control_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

		#region Control Keyup Event (Control_KeyPress)
		/// <summary>
		/// </summary>
		private void Control_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (sender == null) return;		
		}
		#endregion

		#region Combo Control SelectIndexChanged시 구동 Event (Control_SelectedIndexChanged)
		/// <summary>
		/// </summary>
		private void Control_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (sender == null || (sender.GetType().Name.ToString().IndexOf("XComboBox") < 0 || sender.GetType().Name.ToString().IndexOf("XListBox") < 0)) return;

			string colName = this.mOrderFunc.GetHashTableColumnName(sender); // 현재 매핑되는 컬럼명을 얻어온다

			switch (colName)
			{
				case "ho_dong": // ho_dong

					//this.fbxHo_Team.SetDataValue("");
					
					////this.btnList.PerformClick(FunctionType.Query);

					break;
			}

		}
		#endregion

		#region Check Control Check Changed시 구동 Event (Control_CheckedChanged)
		/// <summary>
		/// </summary>
		private void Control_CheckedChanged(object sender, System.EventArgs e)
		{
			if (sender == null) return; 

			if (sender.GetType().Name.ToString().IndexOf("XCheckBox") < 0 && (sender.GetType().Name.ToString().IndexOf("XRadioButton") < 0)) return;

			string colName = this.mOrderFunc.GetHashTableColumnName(sender); // 현재 매핑되는 컬럼명을 얻어온다

		}
		#endregion

		#region Find Control FindClick Event : Find SQL조건 및 필드 정의 (Control_FindClick)
		/// <summary>
		/// </summary>
		private void Control_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XFindBox") < 0) return;

			XFindBox fbx = sender as XFindBox;

			string colName = this.mOrderFunc.GetHashTableColumnName(sender);

			switch (colName)
			{
				case "ho_team": // 간호팀
					fbx.FindWorker = this.mOrderBiz.GetFindWorker("ho_team", this.cboHo_Dong.GetDataValue()); // 컬럼별 Find 정보 얻기
			
					break;

				default:
					fbx.FindWorker = this.mOrderBiz.GetFindWorker(colName); // 컬럼별 Find 정보 얻기
					break;
			}				
		}
		#endregion

		#region Find Control FindSelected Event : Find 데이타 선택시 Value 세팅.. (Control_FindSelected)
		private void Control_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
		{
			if (sender == null || sender.GetType().Name.ToString().IndexOf("XFindBox") < 0) return;

			XFindBox fbx = sender as XFindBox;

			//string colName = this.mOrderFunc.GetHashTableColumnName(sender);

			fbx.AcceptData(); // DataValidating Event에서 선택한 값에 대한 Validation / 정보 세팅 로직 처리함 		
		}
		#endregion

		#region Memo Control Ok Button Click Event (Control_OKButtonClicked)
		/// <summary>
		/// </summary>
		private void Control_OKButtonClicked(object sender, System.EventArgs e)
		{
			if (sender == null) return;		

			if (sender == null || sender.GetType().Name.ToString().IndexOf("XMemoBox") < 0) return;

			XMemoBox mbx = sender as XMemoBox;

			string colName = this.mOrderFunc.GetHashTableColumnName(sender);

//			switch (colName)
//			{
//				case "order_remark": // 처방Comment
//					break;
//			}			
		}
		#endregion

		#endregion

		///////////////////////////////////////////////////////////////////////////////////////////////////////

		///////////////////////////////////////////////////////////////////////////////////////////////////////
		#region [ButtonList Event]

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query: // 미리보기

					// 간호업무계획서 리스트 조회 Service Call
					//this.QueryList(this.dtpOrder_Date.GetDataValue(), this.cboHo_Dong.GetDataValue(), this.fbxHo_Team.GetDataValue());
					this.LayoutData();

					break;

				case FunctionType.Print: // 출력

					try
					{
						dw_1.Print();
					}
					catch(Exception ex)
					{
						XMessageBox.Show(NetInfo.Language == LangMode.Jr ?  "プリンターの設定をご確認ください。" : "프린터 설정을 확인해 주십시오" + "\r\n" + ex.Message);
					}


					break;

				default:
					break;
			}
		}
        #endregion


        #region 검체 채취 리스트 팝업
        private void btnCPLList_Click(object sender, EventArgs e)
        {
            string ho_dong = "";

            //if ( !TypeCheck.IsNull(fbxHoDong.GetDataValue()) )
            if (!TypeCheck.IsNull(this.cboHo_Dong.GetDataValue()))
            {
                //ho_dong = fbxHoDong.GetDataValue();
                ho_dong = this.cboHo_Dong.GetDataValue();
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("ho_dong", ho_dong);
            openParams.Add("from_date", dtpOrder_Date.GetDataValue());
            openParams.Add("to_date", dtpOrder_Date.GetDataValue());


            XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010R01", IHIS.Framework.ScreenOpenStyle.ResponseSizable, ScreenAlignment.ScreenMiddleCenter, openParams);
        }
        #endregion

        private void cbxTeam_CheckedChanged(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
        }

	}
}
