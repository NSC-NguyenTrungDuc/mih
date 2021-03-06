#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCS;
#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0301Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0301Q00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//사용자
		private string mMemb = "";
		//진료과
		private string mGwa    = "";
		//진료의사
        //private string mDoctor = "";
		//입력구분 
        private string mInput_tab = "%";
		//약속코드
        //private string mYaksok_code = "";	
		//내원일자
        //private string mNaewon_date = "";
		//신규그룹번호발생여부
        //private bool   mIsNewGroupSer = true;

		//환자등록번호
		private string mBunho = "";

        //ntt 자식여부
        private string mChildYN = "";

		private IHIS.X.Magic.Menus.PopupMenu popupSetOrderCopy = new IHIS.X.Magic.Menus.PopupMenu(); // Set Gubun		
		private IHIS.X.Magic.Menus.PopupMenu popupMenu         = new IHIS.X.Magic.Menus.PopupMenu();

        private OCS.OrderBiz ob = new OrderBiz();


        // Hospital Code
        private string mHospCode = EnvironInfo.HospCode;
		#endregion

        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList xButtonList1;
        private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.MultiLayout dloOrder_danui;
		private IHIS.Framework.MultiLayout dloSelectOCS0301;
		private IHIS.Framework.MultiLayout dloSelectOCS0303;
        private IHIS.Framework.MultiLayout dloInputControl;
        private IHIS.Framework.XButton btnProcess;
        private System.Windows.Forms.CheckBox chkIsNewGroup;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private IHIS.Framework.XRadioButton rbt;
		private IHIS.Framework.MultiLayout dloMemb;
        private IHIS.Framework.XPanel panMemb;
        private System.Windows.Forms.TreeView tvwOCS0300;
		private IHIS.Framework.XButton btnCPLInfo;
		private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XTextBox txtSearchSetName;
        private IHIS.Framework.MultiLayout dloSetOrderCopy;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell142;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell146;
        private XEditGridCell xEditGridCell147;
        private XMstGrid grdOCS0301;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
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
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell162;
        private XEditGrid grdOCS0303;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell107;
        private XEditGridCell xEditGridCell108;
        private XEditGridCell xEditGridCell109;
        private XEditGridCell xEditGridCell110;
        private XEditGridCell xEditGridCell111;
        private XEditGridCell xEditGridCell112;
        private XEditGridCell xEditGridCell113;
        private XEditGridCell xEditGridCell114;
        private XEditGridCell xEditGridCell115;
        private XEditGridCell xEditGridCell116;
        private XEditGridCell xEditGridCell117;
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell127;
        private XEditGridCell xEditGridCell128;
        private XEditGridCell xEditGridCell129;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell149;
        private XEditGridCell xEditGridCell151;
        private XEditGridCell xEditGridCell152;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell154;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell156;
        private XEditGridCell xEditGridCell157;
        private XEditGridCell xEditGridCell158;
        private XEditGridCell xEditGridCell159;
        private XEditGridCell xEditGridCell160;
        private XEditGridCell xEditGridCell161;
        private XGridHeader xGridHeader1;
        private XPanel pnlOrder;
        private XTabControl tabGroupSerial;
        private XPanel pnlTop;
        private XButton btnSelectAllTab;
        private XButton btnSelectCurrentTab;
        private XPanel pnlFill;
        private XEditGridCell xEditGridCell3;
        private XGridHeader xGridHeader2;
        private XGridHeader xGridHeader3;
        private XEditGridCell xEditGridCell4;
        protected ImageList imageList1;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
		private System.ComponentModel.IContainer components;

		public OCS0301Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리 			
			
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0301Q00));
            this.panMemb = new IHIS.Framework.XPanel();
            this.rbt = new IHIS.Framework.XRadioButton();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtSearchSetName = new IHIS.Framework.XTextBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnCPLInfo = new IHIS.Framework.XButton();
            this.chkIsNewGroup = new System.Windows.Forms.CheckBox();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0301 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dloSelectOCS0301 = new IHIS.Framework.MultiLayout();
            this.dloSelectOCS0303 = new IHIS.Framework.MultiLayout();
            this.dloOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.dloInputControl = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
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
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.dloMemb = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.tvwOCS0300 = new System.Windows.Forms.TreeView();
            this.dloSetOrderCopy = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.grdOCS0303 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell152 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell157 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell158 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell159 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell160 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xEditGridCell161 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.tabGroupSerial = new IHIS.Framework.XTabControl();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.btnSelectAllTab = new IHIS.Framework.XButton();
            this.btnSelectCurrentTab = new IHIS.Framework.XButton();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.panMemb.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0301)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0301)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0303)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInputControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloMemb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSetOrderCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0303)).BeginInit();
            this.pnlOrder.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
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
            // 
            // panMemb
            // 
            this.panMemb.AutoScroll = true;
            this.panMemb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panMemb.BackgroundImage")));
            this.panMemb.Controls.Add(this.rbt);
            this.panMemb.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMemb.Location = new System.Drawing.Point(0, 0);
            this.panMemb.Name = "panMemb";
            this.panMemb.Size = new System.Drawing.Size(1085, 46);
            this.panMemb.TabIndex = 0;
            // 
            // rbt
            // 
            this.rbt.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbt.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbt.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbt.ImageIndex = 0;
            this.rbt.ImageList = this.ImageList;
            this.rbt.Location = new System.Drawing.Point(2, 2);
            this.rbt.Name = "rbt";
            this.rbt.Size = new System.Drawing.Size(140, 26);
            this.rbt.TabIndex = 13;
            this.rbt.Text = "      病院セット";
            this.rbt.UseVisualStyleBackColor = false;
            this.rbt.Visible = false;
            // 
            // xLabel4
            // 
            this.xLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel4.Image = ((System.Drawing.Image)(resources.GetObject("xLabel4.Image")));
            this.xLabel4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel4.Location = new System.Drawing.Point(755, 6);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(94, 22);
            this.xLabel4.TabIndex = 20;
            this.xLabel4.Text = "検索語";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchSetName
            // 
            this.txtSearchSetName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchSetName.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txtSearchSetName.Location = new System.Drawing.Point(851, 6);
            this.txtSearchSetName.Name = "txtSearchSetName";
            this.txtSearchSetName.Size = new System.Drawing.Size(228, 20);
            this.txtSearchSetName.TabIndex = 19;
            this.txtSearchSetName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchSetName_DataValidating);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnCPLInfo);
            this.xPanel2.Controls.Add(this.chkIsNewGroup);
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1085, 40);
            this.xPanel2.TabIndex = 1;
            // 
            // btnCPLInfo
            // 
            this.btnCPLInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCPLInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCPLInfo.Image")));
            this.btnCPLInfo.Location = new System.Drawing.Point(190, 5);
            this.btnCPLInfo.Name = "btnCPLInfo";
            this.btnCPLInfo.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCPLInfo.Size = new System.Drawing.Size(118, 28);
            this.btnCPLInfo.TabIndex = 23;
            this.btnCPLInfo.Text = "検査情報照会";
            this.btnCPLInfo.Visible = false;
            this.btnCPLInfo.Click += new System.EventHandler(this.btnCPLInfo_Click);
            // 
            // chkIsNewGroup
            // 
            this.chkIsNewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsNewGroup.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkIsNewGroup.Checked = true;
            this.chkIsNewGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkIsNewGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkIsNewGroup.ImageIndex = 1;
            this.chkIsNewGroup.ImageList = this.ImageList;
            this.chkIsNewGroup.Location = new System.Drawing.Point(319, 6);
            this.chkIsNewGroup.Name = "chkIsNewGroup";
            this.chkIsNewGroup.Size = new System.Drawing.Size(218, 24);
            this.chkIsNewGroup.TabIndex = 22;
            this.chkIsNewGroup.Text = "     新規オーダグループ番号生成可否";
            this.chkIsNewGroup.UseVisualStyleBackColor = false;
            this.chkIsNewGroup.Visible = false;
            this.chkIsNewGroup.CheckedChanged += new System.EventHandler(this.chkIsNewGroup_CheckedChanged);
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(784, 5);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(98, 28);
            this.btnProcess.TabIndex = 18;
            this.btnProcess.Text = "選択";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(882, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0301
            // 
            this.grdOCS0301.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell138,
            this.xEditGridCell141,
            this.xEditGridCell139,
            this.xEditGridCell140,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell142,
            this.xEditGridCell162,
            this.xEditGridCell144,
            this.xEditGridCell145,
            this.xEditGridCell146,
            this.xEditGridCell147});
            this.grdOCS0301.ColPerLine = 12;
            this.grdOCS0301.Cols = 12;
            this.grdOCS0301.ControlBinding = true;
            this.grdOCS0301.FixedRows = 1;
            this.grdOCS0301.HeaderHeights.Add(21);
            this.grdOCS0301.Location = new System.Drawing.Point(3, 444);
            this.grdOCS0301.Name = "grdOCS0301";
            this.grdOCS0301.QuerySQL = resources.GetString("grdOCS0301.QuerySQL");
            this.grdOCS0301.Rows = 2;
            this.grdOCS0301.RowStateCheckOnPaint = false;
            this.grdOCS0301.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0301.Size = new System.Drawing.Size(181, 100);
            this.grdOCS0301.TabIndex = 1;
            this.grdOCS0301.Visible = false;
            this.grdOCS0301.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0301_QueryEnd);
            this.grdOCS0301.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0301_RowFocusChanged);
            this.grdOCS0301.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0301_QueryStarting);
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "memb";
            this.xEditGridCell138.CellWidth = 65;
            this.xEditGridCell138.HeaderText = "memb";
            this.xEditGridCell138.IsUpdatable = false;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.CellName = "pk_seq";
            this.xEditGridCell141.Col = 3;
            this.xEditGridCell141.HeaderText = "pk_seq";
            this.xEditGridCell141.IsUpdatable = false;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.CellName = "yaksok_gubun";
            this.xEditGridCell139.Col = 1;
            this.xEditGridCell139.HeaderText = "yaksok_gubun";
            this.xEditGridCell139.IsUpdatable = false;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.CellName = "yaksok_gubun_name";
            this.xEditGridCell140.Col = 2;
            this.xEditGridCell140.HeaderText = "yaksok_gubun_name";
            this.xEditGridCell140.IsUpdatable = false;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "yaksok_code";
            this.xEditGridCell1.Col = 10;
            this.xEditGridCell1.HeaderText = "セットコード";
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "yaksok_name";
            this.xEditGridCell2.Col = 5;
            this.xEditGridCell2.HeaderText = "セットコード名";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "input_tab";
            this.xEditGridCell142.Col = 4;
            this.xEditGridCell142.HeaderText = "input_tab\r\ninput_tab";
            this.xEditGridCell142.IsUpdatable = false;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "pk_yaksok";
            this.xEditGridCell162.Col = 11;
            this.xEditGridCell162.HeaderText = "pk_yaksok";
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsUpdCol = false;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "select";
            this.xEditGridCell144.Col = 6;
            this.xEditGridCell144.HeaderText = "選択";
            this.xEditGridCell144.IsUpdatable = false;
            this.xEditGridCell144.IsUpdCol = false;
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.CellName = "select_sang";
            this.xEditGridCell145.Col = 7;
            this.xEditGridCell145.HeaderText = "select_sang";
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.IsUpdCol = false;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.CellName = "node1";
            this.xEditGridCell146.Col = 8;
            this.xEditGridCell146.HeaderText = "node1";
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.IsUpdCol = false;
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.CellName = "node2";
            this.xEditGridCell147.Col = 9;
            this.xEditGridCell147.HeaderText = "node2";
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.IsUpdCol = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 46);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 504);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // dloOrder_danui
            // 
            this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code_name";
            // 
            // dloInputControl
            // 
            this.dloInputControl.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27});
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "input_control";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "input_control_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "specimen_cr_yn";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "suryang_cr_yn";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ord_danui_cr_yn";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "dv_time_cr_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "dv_cr_yn";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "nalsu_cr_yn";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "jusa_cr_yn";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "bogyong_code_cr_yn";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "toiwon_drg_cr_yn";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "tpn_cr_yn";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "anti_cancer_cr_yn";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "fluid_cr_yn";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "portable_cr_yn";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "doner_cr_yn";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "amt_cr_yn";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // dloMemb
            // 
            this.dloMemb.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "memb";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "memb_name";
            // 
            // tvwOCS0300
            // 
            this.tvwOCS0300.AllowDrop = true;
            this.tvwOCS0300.BackColor = System.Drawing.SystemColors.Window;
            this.tvwOCS0300.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwOCS0300.HideSelection = false;
            this.tvwOCS0300.HotTracking = true;
            this.tvwOCS0300.ImageIndex = 2;
            this.tvwOCS0300.ImageList = this.ImageList;
            this.tvwOCS0300.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tvwOCS0300.Location = new System.Drawing.Point(1, 46);
            this.tvwOCS0300.Name = "tvwOCS0300";
            this.tvwOCS0300.SelectedImageIndex = 3;
            this.tvwOCS0300.Size = new System.Drawing.Size(187, 504);
            this.tvwOCS0300.TabIndex = 25;
            this.tvwOCS0300.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwOCS0300_AfterSelect);
            this.tvwOCS0300.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwOCS0300_MouseDown);
            // 
            // dloSetOrderCopy
            // 
            this.dloSetOrderCopy.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "source_memb";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "source_yaksok_code";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "target_memb";
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "yaksok_code";
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "yaksok_name";
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "input_tab";
            this.multiLayoutItem11.IsUpdItem = true;
            // 
            // grdOCS0303
            // 
            this.grdOCS0303.AddedHeaderLine = 1;
            this.grdOCS0303.ApplyPaintEventToAllColumn = true;
            this.grdOCS0303.CallerID = '2';
            this.grdOCS0303.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell125,
            this.xEditGridCell126,
            this.xEditGridCell127,
            this.xEditGridCell128,
            this.xEditGridCell129,
            this.xEditGridCell133,
            this.xEditGridCell134,
            this.xEditGridCell135,
            this.xEditGridCell136,
            this.xEditGridCell137,
            this.xEditGridCell143,
            this.xEditGridCell148,
            this.xEditGridCell149,
            this.xEditGridCell151,
            this.xEditGridCell152,
            this.xEditGridCell153,
            this.xEditGridCell154,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell157,
            this.xEditGridCell158,
            this.xEditGridCell159,
            this.xEditGridCell160,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell15});
            this.grdOCS0303.ColPerLine = 25;
            this.grdOCS0303.Cols = 26;
            this.grdOCS0303.ControlBinding = true;
            this.grdOCS0303.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0303.FixedCols = 1;
            this.grdOCS0303.FixedRows = 2;
            this.grdOCS0303.HeaderHeights.Add(37);
            this.grdOCS0303.HeaderHeights.Add(0);
            this.grdOCS0303.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader3});
            this.grdOCS0303.Location = new System.Drawing.Point(0, 0);
            this.grdOCS0303.Name = "grdOCS0303";
            this.grdOCS0303.QuerySQL = resources.GetString("grdOCS0303.QuerySQL");
            this.grdOCS0303.ReadOnly = true;
            this.grdOCS0303.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0303.RowHeaderVisible = true;
            this.grdOCS0303.Rows = 3;
            this.grdOCS0303.RowStateCheckOnPaint = false;
            this.grdOCS0303.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0303.Size = new System.Drawing.Size(895, 464);
            this.grdOCS0303.TabIndex = 44;
            this.grdOCS0303.ToolTipActive = true;
            this.grdOCS0303.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0303_MouseDown);
            this.grdOCS0303.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0303_QueryEnd);
            this.grdOCS0303.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0303_QueryStarting);
            this.grdOCS0303.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0303_GridColumnChanged);
            this.grdOCS0303.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0303_GridCellPainting);
            this.grdOCS0303.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0303_RowFocusChanged);
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "memb";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.HeaderText = "memb";
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "yaksok_code";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.HeaderText = "yaksok_code";
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "pk_yaksok";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "pk_yaksok";
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "pkocs0303";
            this.xEditGridCell81.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.HeaderText = "pkocs0303";
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "group_ser";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell82.CellWidth = 25;
            this.xEditGridCell82.Col = 4;
            this.xEditGridCell82.HeaderText = "G\r\nR";
            this.xEditGridCell82.RowSpan = 2;
            this.xEditGridCell82.SuppressRepeating = true;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "mix_group";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.HeaderText = "mix_group";
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "seq";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "seq";
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "order_gubun";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.HeaderText = "order_gubun";
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "order_gubun_name";
            this.xEditGridCell86.CellWidth = 60;
            this.xEditGridCell86.Col = 3;
            this.xEditGridCell86.HeaderText = "オ―ダ\r\n区分";
            this.xEditGridCell86.RowSpan = 2;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "input_tab";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.HeaderText = "input_tab";
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "hangmog_code";
            this.xEditGridCell88.CellWidth = 75;
            this.xEditGridCell88.Col = 5;
            this.xEditGridCell88.HeaderText = "オ―ダコード";
            this.xEditGridCell88.RowSpan = 2;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellLen = 85;
            this.xEditGridCell89.CellName = "hangmog_name";
            this.xEditGridCell89.CellWidth = 268;
            this.xEditGridCell89.Col = 6;
            this.xEditGridCell89.HeaderText = "オ―ダ名";
            this.xEditGridCell89.RowSpan = 2;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "specimen_code";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.HeaderText = "specimen_code";
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellLen = 100;
            this.xEditGridCell91.CellName = "specimen_name";
            this.xEditGridCell91.CellWidth = 60;
            this.xEditGridCell91.Col = 7;
            this.xEditGridCell91.HeaderText = "検体";
            this.xEditGridCell91.RowSpan = 2;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "suryang";
            this.xEditGridCell92.CellWidth = 30;
            this.xEditGridCell92.Col = 8;
            this.xEditGridCell92.HeaderText = "数量";
            this.xEditGridCell92.RowSpan = 2;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "ord_danui";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "ord_danui";
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellLen = 6;
            this.xEditGridCell94.CellName = "order_danui_name";
            this.xEditGridCell94.CellWidth = 40;
            this.xEditGridCell94.Col = 9;
            this.xEditGridCell94.HeaderText = "単位";
            this.xEditGridCell94.RowSpan = 2;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellLen = 1;
            this.xEditGridCell95.CellName = "dv_time";
            this.xEditGridCell95.CellWidth = 15;
            this.xEditGridCell95.Col = 10;
            this.xEditGridCell95.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell95.HeaderText = "DV類型";
            this.xEditGridCell95.Row = 1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "dv";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell96.CellWidth = 17;
            this.xEditGridCell96.Col = 11;
            this.xEditGridCell96.HeaderText = "回数";
            this.xEditGridCell96.Row = 1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "dv_1";
            this.xEditGridCell97.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.HeaderText = "dv_1";
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "dv_2";
            this.xEditGridCell98.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.HeaderText = "dv_2";
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "dv_3";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.HeaderText = "dv_3";
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "dv_4";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell100.CellWidth = 10;
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.HeaderText = "dv_4";
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "nalsu";
            this.xEditGridCell101.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell101.CellWidth = 30;
            this.xEditGridCell101.Col = 12;
            this.xEditGridCell101.HeaderText = "日\r\n数";
            this.xEditGridCell101.RowSpan = 2;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jusa";
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.HeaderText = "jusa";
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellLen = 100;
            this.xEditGridCell103.CellName = "jusa_name";
            this.xEditGridCell103.CellWidth = 68;
            this.xEditGridCell103.Col = 14;
            this.xEditGridCell103.HeaderText = "注射";
            this.xEditGridCell103.RowSpan = 2;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "bogyong_code";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.HeaderText = "bogyong_code";
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "bogyong_name";
            this.xEditGridCell105.CellWidth = 90;
            this.xEditGridCell105.Col = 13;
            this.xEditGridCell105.HeaderText = "用法";
            this.xEditGridCell105.RowSpan = 2;
            this.xEditGridCell105.SuppressRepeating = true;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "jusa_spd_gubun";
            this.xEditGridCell106.CellWidth = 40;
            this.xEditGridCell106.Col = 15;
            this.xEditGridCell106.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell106.HeaderText = "ml\r\nhr";
            this.xEditGridCell106.RowSpan = 2;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "hubal_change_yn";
            this.xEditGridCell107.CellWidth = 30;
            this.xEditGridCell107.Col = 23;
            this.xEditGridCell107.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell107.HeaderText = "後発\r\n不可";
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.RowSpan = 2;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "pharmacy";
            this.xEditGridCell108.CellWidth = 22;
            this.xEditGridCell108.Col = 22;
            this.xEditGridCell108.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell108.HeaderText = "簡\r\n易";
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.RowSpan = 2;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "drg_pack_yn";
            this.xEditGridCell109.CellWidth = 22;
            this.xEditGridCell109.Col = 21;
            this.xEditGridCell109.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell109.HeaderText = "一\r\n包";
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.RowSpan = 2;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellLen = 1;
            this.xEditGridCell110.CellName = "emergency";
            this.xEditGridCell110.CellWidth = 22;
            this.xEditGridCell110.Col = 18;
            this.xEditGridCell110.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell110.HeaderText = "緊\r\n急";
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.RowSpan = 2;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellLen = 1;
            this.xEditGridCell111.CellName = "pay";
            this.xEditGridCell111.CellWidth = 52;
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.HeaderText = "請求\r\n区分";
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellLen = 1;
            this.xEditGridCell112.CellName = "portable_yn";
            this.xEditGridCell112.CellWidth = 49;
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.HeaderText = "移動\r\n撮影";
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellLen = 1;
            this.xEditGridCell113.CellName = "powder_yn";
            this.xEditGridCell113.CellWidth = 22;
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.HeaderText = "粉\r\n薬";
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellLen = 1;
            this.xEditGridCell114.CellName = "muhyo";
            this.xEditGridCell114.CellWidth = 25;
            this.xEditGridCell114.Col = 20;
            this.xEditGridCell114.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell114.HeaderText = "無\r\n効";
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.RowSpan = 2;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellLen = 1;
            this.xEditGridCell115.CellName = "prn_yn";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.HeaderText = "prn_yn";
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "order_remark";
            this.xEditGridCell116.CellWidth = 112;
            this.xEditGridCell116.Col = 24;
            this.xEditGridCell116.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell116.HeaderText = "Comment";
            this.xEditGridCell116.IsUpdatable = false;
            this.xEditGridCell116.RowSpan = 2;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "nurse_remark";
            this.xEditGridCell117.CellWidth = 109;
            this.xEditGridCell117.Col = 25;
            this.xEditGridCell117.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell117.HeaderText = "看護\r\nComment";
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.RowSpan = 2;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "bulyong_check";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.HeaderText = "bulyong_check";
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "slip_code";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.HeaderText = "slip_code";
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "group_yn";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.HeaderText = "group_yn";
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "order_gubun_bas";
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.HeaderText = "order_gubun_bas";
            this.xEditGridCell121.IsUpdatable = false;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "input_control";
            this.xEditGridCell122.Col = -1;
            this.xEditGridCell122.HeaderText = "input_control";
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "sg_code";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.HeaderText = "sg_code";
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "suga_yn";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.HeaderText = "suga_yn";
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "emergency_check";
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.HeaderText = "emergency_check";
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "limit_suryang";
            this.xEditGridCell126.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.HeaderText = "limit_suryang";
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "specimen_yn";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.HeaderText = "specimen_yn";
            this.xEditGridCell127.IsUpdatable = false;
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "jaeryo_yn";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.HeaderText = "jaeryo_yn";
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "ord_danui_check";
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.HeaderText = "ord_danui_check";
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.CellName = "wonyoi_order_yn";
            this.xEditGridCell133.CellWidth = 22;
            this.xEditGridCell133.Col = 19;
            this.xEditGridCell133.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell133.HeaderText = "院\r\n外";
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.RowSpan = 2;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.HeaderText = "施行";
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.HeaderText = "結果";
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.HeaderText = "wonyoi_order_cr_yn";
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "nday_yn";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.HeaderText = "nday_yn";
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "muhyo_yn";
            this.xEditGridCell143.Col = -1;
            this.xEditGridCell143.HeaderText = "muhyo_yn";
            this.xEditGridCell143.IsUpdatable = false;
            this.xEditGridCell143.IsVisible = false;
            this.xEditGridCell143.Row = -1;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "pay_name";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.HeaderText = "pay_name";
            this.xEditGridCell148.IsUpdatable = false;
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "bun_code";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.HeaderText = "bun_code";
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "data_control";
            this.xEditGridCell151.Col = -1;
            this.xEditGridCell151.HeaderText = "data_control";
            this.xEditGridCell151.IsUpdatable = false;
            this.xEditGridCell151.IsVisible = false;
            this.xEditGridCell151.Row = -1;
            // 
            // xEditGridCell152
            // 
            this.xEditGridCell152.CellName = "donbog_yn";
            this.xEditGridCell152.Col = -1;
            this.xEditGridCell152.HeaderText = "donbog_yn";
            this.xEditGridCell152.IsUpdatable = false;
            this.xEditGridCell152.IsVisible = false;
            this.xEditGridCell152.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.CellName = "dv_name";
            this.xEditGridCell153.Col = -1;
            this.xEditGridCell153.HeaderText = "dv_name";
            this.xEditGridCell153.IsUpdatable = false;
            this.xEditGridCell153.IsVisible = false;
            this.xEditGridCell153.Row = -1;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.CellName = "drg_info";
            this.xEditGridCell154.Col = -1;
            this.xEditGridCell154.HeaderText = "drg_info";
            this.xEditGridCell154.IsReadOnly = true;
            this.xEditGridCell154.IsUpdatable = false;
            this.xEditGridCell154.IsVisible = false;
            this.xEditGridCell154.Row = -1;
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "drg_bunryu";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.HeaderText = "drg_bunryu";
            this.xEditGridCell155.IsReadOnly = true;
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.CellName = "child_gubun";
            this.xEditGridCell156.CellWidth = 19;
            this.xEditGridCell156.Col = 2;
            this.xEditGridCell156.IsUpdatable = false;
            this.xEditGridCell156.RowSpan = 2;
            // 
            // xEditGridCell157
            // 
            this.xEditGridCell157.CellName = "bom_source_key";
            this.xEditGridCell157.Col = -1;
            this.xEditGridCell157.IsUpdatable = false;
            this.xEditGridCell157.IsVisible = false;
            this.xEditGridCell157.Row = -1;
            // 
            // xEditGridCell158
            // 
            this.xEditGridCell158.CellName = "haengwee_yn";
            this.xEditGridCell158.Col = -1;
            this.xEditGridCell158.IsUpdatable = false;
            this.xEditGridCell158.IsVisible = false;
            this.xEditGridCell158.Row = -1;
            // 
            // xEditGridCell159
            // 
            this.xEditGridCell159.CellName = "org_key";
            this.xEditGridCell159.Col = -1;
            this.xEditGridCell159.IsUpdatable = false;
            this.xEditGridCell159.IsVisible = false;
            this.xEditGridCell159.Row = -1;
            // 
            // xEditGridCell160
            // 
            this.xEditGridCell160.CellName = "parent_key";
            this.xEditGridCell160.Col = -1;
            this.xEditGridCell160.IsUpdatable = false;
            this.xEditGridCell160.IsVisible = false;
            this.xEditGridCell160.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "fkocs0300_seq";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "child_yn";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jundal_table_out";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jundal_part_out";
            this.xEditGridCell8.CellWidth = 60;
            this.xEditGridCell8.Col = 16;
            this.xEditGridCell8.HeaderText = "外来\r\n行為部署";
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "jundal_table_inp";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jundal_part_inp";
            this.xEditGridCell10.CellWidth = 60;
            this.xEditGridCell10.Col = 17;
            this.xEditGridCell10.HeaderText = "入院\r\n行為部署";
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "move_part_out";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "move_part_inp";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jundal_part_out_name";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "jundal_part_inp_name";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.CellName = "select";
            this.xEditGridCell15.CellWidth = 30;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.HeaderText = "選択";
            this.xEditGridCell15.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 10;
            this.xGridHeader3.ColSpan = 2;
            this.xGridHeader3.HeaderText = "回数";
            this.xGridHeader3.HeaderWidth = 15;
            // 
            // xEditGridCell161
            // 
            this.xEditGridCell161.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell161.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell161.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell161.CellName = "select";
            this.xEditGridCell161.CellWidth = 30;
            this.xEditGridCell161.Col = 1;
            this.xEditGridCell161.HeaderText = "選択";
            this.xEditGridCell161.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell161.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell161.RowSpan = 2;
            this.xEditGridCell161.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.grdOCS0303);
            this.pnlOrder.Controls.Add(this.tabGroupSerial);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrder.DrawBorder = true;
            this.pnlOrder.Location = new System.Drawing.Point(0, 0);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(897, 466);
            this.pnlOrder.TabIndex = 19;
            // 
            // tabGroupSerial
            // 
            this.tabGroupSerial.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabGroupSerial.IDEPixelArea = true;
            this.tabGroupSerial.IDEPixelBorder = false;
            this.tabGroupSerial.ImageList = this.ImageList;
            this.tabGroupSerial.Location = new System.Drawing.Point(0, 0);
            this.tabGroupSerial.Name = "tabGroupSerial";
            this.tabGroupSerial.Size = new System.Drawing.Size(895, 0);
            this.tabGroupSerial.TabIndex = 0;
            this.tabGroupSerial.SelectionChanged += new System.EventHandler(this.tabGroupSerial_SelectionChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnSelectAllTab);
            this.pnlTop.Controls.Add(this.btnSelectCurrentTab);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(188, 46);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(897, 38);
            this.pnlTop.TabIndex = 47;
            // 
            // btnSelectAllTab
            // 
            this.btnSelectAllTab.Image = global::IHIS.OCSA.Properties.Resources.YESEN1;
            this.btnSelectAllTab.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectAllTab.Location = new System.Drawing.Point(54, 5);
            this.btnSelectAllTab.Name = "btnSelectAllTab";
            this.btnSelectAllTab.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSelectAllTab.Size = new System.Drawing.Size(43, 29);
            this.btnSelectAllTab.TabIndex = 1;
            this.btnSelectAllTab.Tag = "n";
            this.btnSelectAllTab.Click += new System.EventHandler(this.btnDeleteAllTab_Click);
            // 
            // btnSelectCurrentTab
            // 
            this.btnSelectCurrentTab.Image = global::IHIS.OCSA.Properties.Resources.YESUP1;
            this.btnSelectCurrentTab.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectCurrentTab.Location = new System.Drawing.Point(6, 5);
            this.btnSelectCurrentTab.Name = "btnSelectCurrentTab";
            this.btnSelectCurrentTab.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSelectCurrentTab.Size = new System.Drawing.Size(43, 29);
            this.btnSelectCurrentTab.TabIndex = 0;
            this.btnSelectCurrentTab.Click += new System.EventHandler(this.btnSelectAllTab_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlOrder);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(188, 84);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(897, 466);
            this.pnlFill.TabIndex = 48;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "jundal_table_out";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jundal_table_out";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "dv_5";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dv_6";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "dv_7";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "dv_8";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // OCS0301Q00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grdOCS0301);
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.txtSearchSetName);
            this.Controls.Add(this.tvwOCS0300);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panMemb);
            this.Name = "OCS0301Q00";
            this.Size = new System.Drawing.Size(1085, 590);
            this.UserChanged += new System.EventHandler(this.OCS0301Q00_UserChanged);
            this.panMemb.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0301)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0301)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS0303)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloInputControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloMemb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSetOrderCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0303)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        #region [Screen Event]

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "OCS0270Q00": // 의사조회

                    //if (!TypeCheck.IsNull(commandParam["doctor"].ToString()))
                    //{
                    //    this.fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                    //}

                    //fbxDoctor.AcceptData();
                    //fbxDoctor.Focus();
                    //fbxDoctor.SelectAll();

                    break;

            }
            return base.Command(command, commandParam);
        }

        protected override void OnLoad(EventArgs e)
        {
            // 회수 Header 한칸으로 처리하기
            if (this.grdOCS0303[0, 10] != null)
                this.grdOCS0303[0, 10].RowSpan = 2;
            if (this.grdOCS0303[1, 10] != null)
                this.grdOCS0303[1, 10] = null;
            if (this.grdOCS0303[1, 11] != null)
                this.grdOCS0303[1, 11] = null;

            base.OnLoad(e);

            try
            {
                popupMenu.MenuCommands.Clear();
                popupMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "検査情報照会" : "검사정보조회", (Image)this.ImageList.Images[4],
                    new EventHandler(this.PopUpMenuGumsaInfo_Click)));

                popupSetOrderCopy.MenuCommands.Clear();
                popupSetOrderCopy.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(NetInfo.Language == LangMode.Jr ? "セットオ―ダコピー" : "Set오더 Copy", (Image)this.ImageList.Images[5],
                    new EventHandler(this.PopUpMenuSetOrderCopy_Click)));
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message);
            }

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    // 호출한 화면의 사용자 memb
                    if (OpenParam.Contains("memb"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["memb"].ToString()))
                            mMemb = OpenParam["memb"].ToString();
                    }

                    //호출한 화면의 사용자의 과
                    if (OpenParam.Contains("gwa"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["gwa"].ToString()))
                            mGwa = OpenParam["gwa"].ToString();
                    }

                    if (OpenParam.Contains("input_tab"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["input_tab"].ToString()))
                            mInput_tab = OpenParam["input_tab"].ToString();
                    }

                    //mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
                    //if (OpenParam.Contains("naewon_date"))
                    //{
                    //    if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                    //        mNaewon_date = OpenParam["naewon_date"].ToString();
                    //}
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
                //mYaksok_code = "";
            }

            InitialDesign();

            //Set M/D Relation
            grdOCS0303.SetRelationKey("memb", "memb");
            grdOCS0303.SetRelationKey("yaksok_code", "yaksok_code");
            grdOCS0303.SetRelationKey("input_tab", "input_tab");

            grdOCS0303.SetBindVarValue("f_input_tab", mInput_tab);
            grdOCS0303.SetBindVarValue("f_input_tab", mInput_tab);


            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0301;
            this.CurrMQLayout = this.grdOCS0301;

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void InitialDesign()
        {
            grdOCS0303.FixedCols = 7;
            //panel 경계부분 splitter가 있는 경우 경계부분 panel bordColor처리
            splitter1.BackColor = XColor.XDisplayBoxGradientEndColor.Color;

            //column invible처리
            foreach (XGridCell cell in grdOCS0303.CellInfos)
            {
                if (cell.IsVisible)
                {
                    if (mInput_tab == "%" || this.mInputControl.IsVisibleColumn(mInput_tab, cell.CellName))
                    {
                        grdOCS0303.AutoSizeColumn(cell.Col, cell.CellWidth);
                    }
                    else
                        grdOCS0303.AutoSizeColumn(cell.Col, 0);

                }
            }
        }

        private void PostLoad()
        {
            //comboBox생성
            CreateCombo();

            //DataLayout 생성
            CreateLayout();

            /// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            this.OCS0301Q00_UserChanged(this, new System.EventArgs());
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void OCS0301Q00_UserChanged(object sender, System.EventArgs e)
        {
            this.panMemb.Visible = true;
            SetUserCheckBox();
        }

        private bool IsDoctor(string aMemb)
        {
            string cmdText = @"SELECT 'Y'
                                  FROM DUAL
                                 WHERE EXISTS ( SELECT DOCTOR
                                                  FROM BAS0270
                                                 WHERE HOSP_CODE = :f_hosp_code
                                                   AND DOCTOR    = :f_doctor
                                                   AND SYSDATE   BETWEEN START_DATE AND END_DATE )";

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", mHospCode);
            bc.Add("f_doctor", aMemb);

            object retVal = Service.ExecuteScalar(cmdText, bc);
            if (!TypeCheck.IsNull(retVal))
            {
                if (retVal.ToString() == "Y")
                    return true;
            }

            return false;
        }

        //사용자 checkBox 생성
        private void SetUserCheckBox()
        {
            //memb reset
            dloMemb.Reset();
            int insertRow;

            //병원공통약속order			
            insertRow = dloMemb.InsertRow(-1);
            dloMemb.SetItemValue(insertRow, "memb", "ADMIN");
            dloMemb.SetItemValue(insertRow, "memb_name", "病院セット");

            //해당과           
            string gwa_name = "";
            if(mGwa != "")
            {
                if (ob.LoadColumnCodeName("gwa_all", mGwa, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref gwa_name))
                {
                    insertRow = dloMemb.InsertRow(-1);
                    dloMemb.SetItemValue(insertRow, "memb", mGwa);
                    dloMemb.SetItemValue(insertRow, "memb_name", gwa_name);
                }
            }
            
            string user_name = "";
            if (this.mMemb != "")
            {
                if (ob.LoadColumnCodeName("gwa_doctor", "%", mMemb, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref user_name))
                {
                    // 의사인경우는... 의사공통을 가져가야한다.
                    //해당 사용자 User
                    insertRow = dloMemb.InsertRow(-1);
                    //dloMemb.SetItemValue(insertRow, "memb", mMemb.Replace(mGwa, ""));
                    dloMemb.SetItemValue(insertRow, "memb", UserInfo.UserID); 
                    dloMemb.SetItemValue(insertRow, "memb_name", user_name + "【共通】");
                }
                else if (ob.LoadColumnCodeName("user_id", mMemb, ref user_name))
                {
                }
                //과별개인셋트오더취득
                SingleLayout layCommon = new SingleLayout();
                layCommon.QuerySQL = @" SELECT 'Y'
                                           FROM DUAL 
                                          WHERE EXISTS ( SELECT 'X'
                                                           FROM  OCS0301 Z 
                                                          WHERE  Z.HOSP_CODE = :f_hosp_code
                                                            AND  Z.MEMB      = :f_memb)";
                layCommon.LayoutItems.Add("check_yn");   
                layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layCommon.SetBindVarValue("f_memb", mMemb);

                if (layCommon.QueryLayout() && (layCommon.GetItemValue("check_yn").ToString()=="Y"))
                {
                    //해당 사용자 User
                    insertRow = dloMemb.InsertRow(-1);
                    dloMemb.SetItemValue(insertRow, "memb", mMemb);
                    dloMemb.SetItemValue(insertRow, "memb_name", user_name + "【" + gwa_name + "】");
                }
            }
            
            //검색어 문제로 해당부분을 막는다.
            //			if(UserInfo.UserGubun == UserType.Nurse && EnvironInfo.CurrSystemID == "NURI")
            //				this.LoadHoDongComUSer(ref dloMemb);

            //사용자 약속코드 정보 Load
            if (dloMemb.RowCount > 0)
            {
                if (dloMemb.RowCount <= 5)
                    panMemb.SetBounds(panMemb.Location.X, panMemb.Location.Y, panMemb.Size.Width, rbt.Location.Y + rbt.Size.Height + 2);
                
                ShowMemb();
            }
            else
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "該当画面に使用権限がない使用者です。ご確認下さい。" : "해당 화면에 사용권한이 없는 사용자입니다. 확인하십시요.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "使用権限" : "사용권한";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
                this.Close();
            }

        }

        //사용자 ComboBox생성
        //private void SetUserCombo()
        //{
        //    //CreateGwaCombo();
        //}

        /// <summary>
        /// DataLayout LayoutItems생성
        /// </summary>
        private void CreateLayout()
        {
            //OCS0301
            foreach (XGridCell cell in this.grdOCS0301.CellInfos)
            {
                dloSelectOCS0301.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS0301.InitializeLayoutTable();

            //OCS0303
            foreach (XGridCell cell in this.grdOCS0303.CellInfos)
            {
                dloSelectOCS0303.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
            }

            dloSelectOCS0303.InitializeLayoutTable();
        }

        /// <summary>
        /// 기준정보 DataLayout생성
        /// </summary>
        private void LoadBaseData()
        {
            //Order 단위
            dloOrder_danui.QuerySQL = @"SELECT CODE
                                          FROM OCS0132
                                         WHERE CODE_TYPE = 'ORD_DANUI'
                                           AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                         ORDER BY CODE";
            dloOrder_danui.QueryLayout(false);

            //InputControl
            dloInputControl.QuerySQL = @"SELECT INPUT_CONTROL     , 
                                                INPUT_CONTROL_NAME, 
                                                SPECIMEN_CR_YN    , 
                                                SURYANG_CR_YN     , 
                                                ORD_DANUI_CR_YN   , 
                                         --       DV_TIME_CR_YN     , 
                                                DV_CR_YN          , 
                                                NALSU_CR_YN       , 
                                                JUSA_CR_YN        , 
                                                BOGYONG_CODE_CR_YN, 
                                                TOIWON_DRG_CR_YN  , 
                                         --       TPN_CR_YN         , 
                                         --       ANTI_CANCER_CR_YN , 
                                         --       FLUID_CR_YN       , 
                                                PORTABLE_CR_YN    , 
                                         --       DONER_CR_YN       , 
                                                AMT_CR_YN           
                                           FROM OCS0133
                                          WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()";
            dloInputControl.QueryLayout(false);
        }

        #endregion

        #region [병동간호 공통유져]

//        private void LoadHoDongComUSer(ref MultiLayout dloMemb)
//        {
//            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

//            //SLIP_GUBUN DataLayout;
//            layoutCombo.Reset();
//            layoutCombo.LayoutItems.Clear();
//            layoutCombo.LayoutItems.Add("memb", DataType.String);
//            layoutCombo.LayoutItems.Add("memb_name", DataType.String);
//            layoutCombo.InitializeLayoutTable();

//            layoutCombo.QuerySQL = @"SELECT A.MEMB, A.MEMB_NAME FROM OCS0130 A         
//                                      WHERE A.MEMB_GUBUN = 'B'
//                                        AND A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
//                                      ORDER BY MEMB ";

//            layoutCombo.QueryLayout(false);

//            if (Service.ErrCode.ToString() == "0" && layoutCombo.LayoutTable != null)
//            {
//                int insertRow = -1;
//                foreach (DataRow row in layoutCombo.LayoutTable.Rows)
//                {
//                    if (dloMemb.LayoutTable.Select(" memb = '" + row["memb"].ToString() + "' ", "").Length == 0)
//                    {
//                        insertRow = dloMemb.InsertRow(-1);
//                        dloMemb.SetItemValue(insertRow, "memb", row["memb"]);
//                        dloMemb.SetItemValue(insertRow, "memb_name", row["memb_name"]);
//                    }
//                }
//            }

//        }

        #endregion

        #region [사용자공통 USER를 가져옵니다.]

        
        /// <summary>
        /// 해당 사용자의 공통 USER ID를 가져옵니다.
        /// </summary>
        /// <param name="aUser_gubun">공통사용자구분</param>
        /// <param name="aUser_id">사용자ID</param>
        /// <returns></returns>
        //private string GetOCSCOM_USER_ID(string aUser_gubun, string aUser_id)
        //{
        //    string comUser_id = "";
        //    string cmdText = "";
        //    BindVarCollection bindVars = new BindVarCollection();
        //    object retVal = null;

        //    cmdText = "SELECT FN_OCS_LOAD_MEMB_COMID(:f_gubun, :f_user_id) FROM DUAL";
        //    bindVars.Add("f_gubun", aUser_gubun);
        //    bindVars.Add("f_user_id", aUser_id);

        //    retVal = Service.ExecuteScalar(cmdText, bindVars);

        //    if (!TypeCheck.IsNull(retVal))
        //    {
        //        comUser_id = retVal.ToString();
        //    }

        //    return comUser_id;
        //}

        
        #endregion

        #region [사용자 RadioBotton 생성]

        const int INPUT_GUBUN_WIDTH = 160;
        const int INPUT_GUBUN_HEIGHT = 26;//	140, 34	

        private void ShowMemb()
        {
            panMemb.Controls.Clear();

            XRadioButton rbtMemb;

            int startX = 4;
            bool isVisible = true;

            foreach (DataRow row in dloMemb.LayoutTable.Rows)
            {
                rbtMemb = new XRadioButton();
                rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
                rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
                rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                rbtMemb.ImageList = this.ImageList;
                rbtMemb.ImageIndex = 0;
                rbtMemb.Location = new System.Drawing.Point(startX, 4);
                rbtMemb.Name = "rbt" + row["memb"];
                rbtMemb.Size = new System.Drawing.Size(INPUT_GUBUN_WIDTH, INPUT_GUBUN_HEIGHT);
                rbtMemb.Text = "     " + row["memb_name"].ToString();
                rbtMemb.Tag = row["memb"].ToString();
                rbtMemb.Visible = isVisible;
                //rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
                rbtMemb.CheckedChanged += new EventHandler(rbtMemb_CheckedChanged);
                panMemb.Controls.Add(rbtMemb);

                startX = startX + INPUT_GUBUN_WIDTH;
            }

            // 간호
            //if (UserInfo.UserGubun == UserType.Nurse)
            //{
            //    rbtMemb = new XRadioButton();
            //    rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
            //    rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
            //    rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    rbtMemb.ImageList = this.ImageList;
            //    rbtMemb.ImageIndex = 0;
            //    rbtMemb.Location = new System.Drawing.Point(startX, 4);
            //    rbtMemb.Name = "rbtGwa";
            //    rbtMemb.Size = new System.Drawing.Size(78, INPUT_GUBUN_HEIGHT);
            //    rbtMemb.Text = "      診療科";
            //    rbtMemb.Tag = "GWA";
            //    rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
            //    panMemb.Controls.Add(rbtMemb);
            //    startX = startX + 78;

            //    rbtMemb = new XRadioButton();
            //    rbtMemb.Appearance = System.Windows.Forms.Appearance.Button;
            //    rbtMemb.Cursor = System.Windows.Forms.Cursors.Hand;
            //    rbtMemb.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            //    rbtMemb.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //    rbtMemb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //    rbtMemb.ImageList = this.ImageList;
            //    rbtMemb.ImageIndex = 0;
            //    rbtMemb.Location = new System.Drawing.Point(startX, 4);
            //    rbtMemb.Name = "rbtDoctor";
            //    rbtMemb.Size = new System.Drawing.Size(78, INPUT_GUBUN_HEIGHT);
            //    rbtMemb.Text = "      医師";
            //    rbtMemb.Tag = "DOCTOR";
            //    rbtMemb.Click += new System.EventHandler(this.rbtMemb_Click);
            //    panMemb.Controls.Add(rbtMemb);
            //}

            if (dloMemb.RowCount > 0)
            {
                if (dloMemb.RowCount >= 3)
                {
                    //정형외과는 정형외과가 선택되도록 변경
                    //if (UserInfo.UserGubun == UserType.Doctor && UserInfo.Gwa == "06")
                    //    rbtMemb_Click(panMemb.Controls[dloMemb.RowCount - 1], null);
                    //else
                    //    rbtMemb_Click(panMemb.Controls[1], null);
                    //rbtMemb_Click(panMemb.Controls[dloMemb.RowCount - 1], null);
                    
                    //this.rbtMemb_CheckedChanged(panMemb.Controls[dloMemb.RowCount - 1], new EventArgs());
                    //공통으로변경
                    ((XRadioButton)panMemb.Controls[2]).Checked = true;
                }
                else
                {
                    //this.rbtMemb_CheckedChanged(panMemb.Controls[dloMemb.RowCount - 1], new EventArgs());
                    ((XRadioButton)panMemb.Controls[0]).Checked = true;
                }
            }
        }

        void rbtMemb_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;

            if (rbt.Checked)
            {
                rbt.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbt.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbt.ImageIndex = 1;

                //if (!((XRadioButton)obj).Checked)
                //    ((XRadioButton)obj).Checked = true;

                grdOCS0301.ClearFilter();

                //현재선택된 row trans			
                for (int i = 0; i < grdOCS0301.RowCount; i++)
                {
                    if (grdOCS0301.GetItemString(i, "select") == "Y")
                        dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
                }

                //현재선택된 row trans			
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "select") == "Y")
                        InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
                }

                string isGrantNur = "%";

                if (rbt.Tag.ToString() == "GWA")
                {
                    //this.pnlMemb_1.Visible = true;
                    //this.lblGwaDoctor.Text = "診療科";
                    //this.fbxDoctor.Visible = false;
                    //this.dbxDoctor_name.Visible = false;
                    //this.cboGwa.Visible = true;

                    //if (cboGwa.SelectedIndex >= 0)
                    //    mMemb = cboGwa.GetDataValue();
                    //else
                    //    mMemb = "";

                    isGrantNur = "Y";

                }
                else if (rbt.Tag.ToString() == "DOCTOR")
                {
                    //this.pnlMemb_1.Visible = true;
                    //lblGwaDoctor.Text = "医師";
                    //this.fbxDoctor.Visible = true;

                    //주치의 자동세팅
                    //this.fbxDoctor.SetEditValue(mDoctor);
                    //this.fbxDoctor.AcceptData();

                    //this.dbxDoctor_name.Visible = true;
                    //this.cboGwa.Visible = false;

                    //mMemb = fbxDoctor.GetDataValue();

                    isGrantNur = "Y";
                }
                else if (rbt.Tag.ToString() == "ADMIN")
                {
                    //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
                    if (!IsDoctor(mMemb))
                        isGrantNur = "Y";
                    else
                        isGrantNur = "%";

                    mMemb = rbt.Tag.ToString();
                }
                else
                {
                    //this.pnlMemb_1.Visible = false;
                    mMemb = rbt.Tag.ToString();
                }
                grdOCS0301.SetBindVarValue("memb", mMemb);
                grdOCS0301.SetBindVarValue("yaksok_code", "");
                //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
                grdOCS0301.QueryLayout(true);
            }
            else
            {
                rbt.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbt.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbt.ImageIndex = 0;
                //if (((XRadioButton)obj).Checked)
                //    ((XRadioButton)obj).Checked = false;
            }

            //modify by yoonB [Query2回実行回避] 2012/03/23
            //foreach (object obj in panMemb.Controls)
            //{
            //    //if (((XRadioButton)obj).Name == rbt.Name)

            //    if (((XRadioButton)obj).Checked == true)
            //    {
            //        ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
            //        ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
            //        ((XRadioButton)obj).ImageIndex = 1;

            //        if (!((XRadioButton)obj).Checked)
            //            ((XRadioButton)obj).Checked = true;

            //        grdOCS0301.ClearFilter();

            //        //현재선택된 row trans			
            //        for (int i = 0; i < grdOCS0301.RowCount; i++)
            //        {
            //            if (grdOCS0301.GetItemString(i, "select") == "Y")
            //                dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //        }

            //        //현재선택된 row trans			
            //        for (int i = 0; i < grdOCS0303.RowCount; i++)
            //        {
            //            if (grdOCS0303.GetItemString(i, "select") == "Y")
            //                InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            //        }

            //        string isGrantNur = "%";

            //        if (((XRadioButton)obj).Tag.ToString() == "GWA")
            //        {
            //            //this.pnlMemb_1.Visible = true;
            //            //this.lblGwaDoctor.Text = "診療科";
            //            //this.fbxDoctor.Visible = false;
            //            //this.dbxDoctor_name.Visible = false;
            //            //this.cboGwa.Visible = true;

            //            //if (cboGwa.SelectedIndex >= 0)
            //            //    mMemb = cboGwa.GetDataValue();
            //            //else
            //            //    mMemb = "";

            //            isGrantNur = "Y";

            //        }
            //        else if (((XRadioButton)obj).Tag.ToString() == "DOCTOR")
            //        {
            //            //this.pnlMemb_1.Visible = true;
            //            //lblGwaDoctor.Text = "医師";
            //            //this.fbxDoctor.Visible = true;

            //            //주치의 자동세팅
            //            //this.fbxDoctor.SetEditValue(mDoctor);
            //            //this.fbxDoctor.AcceptData();

            //            //this.dbxDoctor_name.Visible = true;
            //            //this.cboGwa.Visible = false;

            //            //mMemb = fbxDoctor.GetDataValue();

            //            isGrantNur = "Y";
            //        }
            //        else if ((((XRadioButton)obj).Tag.ToString() == "ADMIN"))
            //        {
            //            //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
            //            if (!IsDoctor(mMemb))
            //                isGrantNur = "Y";
            //            else
            //                isGrantNur = "%";

            //            mMemb = ((XRadioButton)obj).Tag.ToString();
            //        }
            //        else
            //        {
            //            //this.pnlMemb_1.Visible = false;
            //            mMemb = ((XRadioButton)obj).Tag.ToString();
            //        }


            //        grdOCS0301.SetBindVarValue("memb", mMemb);
            //        grdOCS0301.SetBindVarValue("yaksok_code", "");
            //        //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
            //        grdOCS0301.QueryLayout(true);

            //    }
            //    else
            //    {
            //        ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
            //        ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
            //        ((XRadioButton)obj).ImageIndex = 0;

            //        if (((XRadioButton)obj).Checked)
            //            ((XRadioButton)obj).Checked = false;
            //    }
            //}
        }

        private void rbtMemb_Click(object sender, System.EventArgs e)
        {
            if (!isMouseDown) //탭클링어하는데 이게 자꾸 왜타지냐
                return;

            XRadioButton rbt = sender as XRadioButton;

            foreach (object obj in panMemb.Controls)
            {
                //if (((XRadioButton)obj).Name == rbt.Name)
                if (((XRadioButton)obj).Checked == true)
                {
                    ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                    ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                    ((XRadioButton)obj).ImageIndex = 1;

                    if (!((XRadioButton)obj).Checked)
                        ((XRadioButton)obj).Checked = true;

                    grdOCS0301.ClearFilter();

                    //현재선택된 row trans			
                    for (int i = 0; i < grdOCS0301.RowCount; i++)
                    {
                        if (grdOCS0301.GetItemString(i, "select") == "Y")
                            dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
                    }

                    //현재선택된 row trans			
                    for (int i = 0; i < grdOCS0303.RowCount; i++)
                    {
                        if (grdOCS0303.GetItemString(i, "select") == "Y")
                            InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
                    }

                    string isGrantNur = "%";

                    if (((XRadioButton)obj).Tag.ToString() == "GWA")
                    {
                        //this.pnlMemb_1.Visible = true;
                        //this.lblGwaDoctor.Text = "診療科";
                        //this.fbxDoctor.Visible = false;
                        //this.dbxDoctor_name.Visible = false;
                        //this.cboGwa.Visible = true;

                        //if (cboGwa.SelectedIndex >= 0)
                        //    mMemb = cboGwa.GetDataValue();
                        //else
                        //    mMemb = "";

                        isGrantNur = "Y";

                    }
                    else if (((XRadioButton)obj).Tag.ToString() == "DOCTOR")
                    {
                        //this.pnlMemb_1.Visible = true;
                        //lblGwaDoctor.Text = "医師";
                        //this.fbxDoctor.Visible = true;

                        //주치의 자동세팅
                        //this.fbxDoctor.SetEditValue(mDoctor);
                        //this.fbxDoctor.AcceptData();

                        //this.dbxDoctor_name.Visible = true;
                        //this.cboGwa.Visible = false;

                        //mMemb = fbxDoctor.GetDataValue();

                        isGrantNur = "Y";
                    }
                    else if ((((XRadioButton)obj).Tag.ToString() == "ADMIN"))
                    {
                        //병원공통세트의 경우 의사가 아닌 경우는 간호오더가 가능한 세트만 보여 주도록 한다.
                        if (!IsDoctor(mMemb))
                            isGrantNur = "Y";
                        else
                            isGrantNur = "%";

                        mMemb = ((XRadioButton)obj).Tag.ToString();
                    }
                    else
                    {
                        //this.pnlMemb_1.Visible = false;
                        mMemb = ((XRadioButton)obj).Tag.ToString();
                    }
                     

                    grdOCS0301.SetBindVarValue("memb", mMemb);
                    grdOCS0301.SetBindVarValue("yaksok_code", "");
                    //grdOCS0301.SetBindVarValue("grant_nur", isGrantNur);
                    grdOCS0301.QueryLayout(true);

                }
                else
                {
                    ((XRadioButton)obj).BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                    ((XRadioButton)obj).ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                    ((XRadioButton)obj).ImageIndex = 0;

                    if (((XRadioButton)obj).Checked)
                        ((XRadioButton)obj).Checked = false;
                }
            }
        }
        #endregion

        #region [TreeView 약속처방구분]

        private void ShowOCS0300()
        {
            tvwOCS0300.Nodes.Clear();
            if (grdOCS0301.RowCount < 1) return;

            string pk_seq = "";
            int rowNum = 0;
            int node1 = -1, node2 = -1;
            TreeNode node;

            foreach (DataRow row in grdOCS0301.LayoutTable.Rows)
            {
                if (pk_seq != row["pk_seq"].ToString())
                {
                    node = new TreeNode(row["yaksok_gubun_name"].ToString());
                    node.Tag = row["pk_seq"].ToString();
                    tvwOCS0300.Nodes.Add(node);
                    pk_seq = row["pk_seq"].ToString();

                    row["node1"] = -1;
                    row["node1"] = -1;
                    node1 = node1 + 1;
                    node2 = -1;
                }

                node = new TreeNode(row["yaksok_name"].ToString());
                node.Tag = rowNum;

                if (row["select"].ToString() == "Y")
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                }
                else
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                }

                tvwOCS0300.Nodes[tvwOCS0300.Nodes.Count - 1].Nodes.Add(node);
                node2 = node2 + 1;
                row["node1"] = node1;
                row["node2"] = node2;

                rowNum++;
            }

            foreach(TreeNode parentNode in this.tvwOCS0300.Nodes)
            {
                foreach (TreeNode childNode in parentNode.Nodes)
                {
                    if (childNode.ImageIndex == 1)
                    {
                        parentNode.Expand();
                        break;
                    }
                    
                }
            }

        }

        private void tvwOCS0300_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (tvwOCS0300.SelectedNode.Parent == null) return;

            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                grdOCS0301.SetFocusToItem(int.Parse(tvwOCS0300.SelectedNode.Tag.ToString()), 1);

            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }

        }

        bool isMouseDown = false;
        private void tvwOCS0300_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                isMouseDown = true;
                if (tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)) == null || tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)).Parent == null) return;

                if (mMemb == UserInfo.YaksokOpenID || TypeCheck.IsNull(UserInfo.YaksokOpenID)) return;
                //PopUp Menu Show
                tvwOCS0300.SelectedNode = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));
                popupSetOrderCopy.TrackPopup(tvwOCS0300.PointToScreen(new Point(e.X, e.Y)));

                isMouseDown = false;
            }
            //delete by yoonB [ダブルクリックでチェックされるロジック削除] 2012/03/23
            //else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    if (tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)) == null || tvwOCS0300.GetNodeAt(new Point(e.X, e.Y)).Parent == null) return;
            //    tvwOCS0300.SelectedNode = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));

            //    if ((tvwOCS0300.SelectedNode == null) || (tvwOCS0300.SelectedNode.Parent == null)) return;

            //    TreeNode node = tvwOCS0300.GetNodeAt(new Point(e.X, e.Y));

            //    if (node.ImageIndex == 1)
            //    {
            //        //DeleteRow
            //        node.ImageIndex = 0;
            //        node.SelectedImageIndex = 0;
            //        DeleteRow("%");
            //    }
            //    else
            //    {
            //        node.ImageIndex = 1;
            //        node.SelectedImageIndex = 1;
            //        SelectRow("%");
            //    }

            //}
        }



        #endregion

        #region [Combo 생성]

        private void CreateCombo()
        {
            DataTable dtTemp;

            // DV_TIME
            dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
            this.grdOCS0303.SetComboItems("dv_time", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            // 이동촬영여부
            dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
            this.grdOCS0303.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            //급여여부
            dtTemp = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
            this.grdOCS0303.SetComboItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);

            // 주사스피드구분
            dtTemp = this.mOrderBiz.LoadComboDataSource("jusa_spd_gubun").LayoutTable;
            this.grdOCS0303.SetComboItems("jusa_spd_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);

            //CreateGwaCombo();

        }

        #endregion

        #region [Control Event]

        private void txtSearchSetName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //			//현재선택된 row trans			
            //			for(int i = 0; i < grdOCS0301.RowCount; i++)
            //			{
            //				if(grdOCS0301.GetItemString(i, "select") == " ")
            //					dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //			}
            //
            //			//현재선택된 row trans			
            //			for(int i = 0; i < grdOCS0303.RowCount; i++)
            //			{
            //				if(grdOCS0303.GetItemString(i, "select") == " ")
            //					dloSelectOCS0303.LayoutTable.ImportRow(grdOCS0303.LayoutTable.Rows[i]);
            //			}	
            //
            //			dsvLDOCS0301.ExhaustiveCall(true);

            grdOCS0301.ClearFilter();

            if (!TypeCheck.IsNull(txtSearchSetName.GetDataValue().Trim()))
            {
                if (grdOCS0301.RowCount > 0)
                    grdOCS0301.SetFilter(" yaksok_name like '%" + txtSearchSetName.GetDataValue().Trim() + "%'");
            }

            //if (grdOCS0301.CurrentRowNumber >= 0 && grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "select_sang") == "Y")
            //    lblSelectSang.ImageIndex = 1;
            //else
            //    lblSelectSang.ImageIndex = 0;

            ShowOCS0300();

        }

        //private void lblSelectOrder_Click(object sender, System.EventArgs e)
        //{
        //    if (lblSelectOrder.ImageIndex == 0)
        //    {
        //        if (grdSelectAll(grdOCS0303, true))
        //        {
        //            lblSelectOrder.ImageIndex = 1;
        //            lblSelectOrder.Text = " 全体選択取消";
        //        }
        //    }
        //    else
        //    {
        //        if (grdSelectAll(grdOCS0303, false))
        //        {
        //            lblSelectOrder.ImageIndex = 0;
        //            lblSelectOrder.Text = " 全体選択";
        //        }
        //    }
        //}

        //private void lblSelectSang_Click(object sender, System.EventArgs e)
        //{
        //    if (lblSelectSang.ImageIndex == 0)
        //    {
        //        lblSelectSang.ImageIndex = 1;
        //        if (grdOCS0301.CurrentRowNumber >= 0)
        //            grdOCS0301.SetItemValue(grdOCS0301.CurrentRowNumber, "select_sang", "Y");

        //    }
        //    else
        //    {
        //        lblSelectSang.ImageIndex = 0;
        //        if (grdOCS0301.CurrentRowNumber >= 0)
        //            grdOCS0301.SetItemValue(grdOCS0301.CurrentRowNumber, "select_sang", "N");
        //    }

        //    //선택된 row 표시
        //    SetSelectYaksok();
        //}

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, bool select)
        //{
        //    int rowIndex = -1;

        //    if (select)
        //    {
        //        for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        {
        //            /*
        //            //의사인 경우 order 권한 Check한다.
        //            if (UserInfo.UserGubun == UserType.Doctor)
        //            {
        //                if (!this.mOrderBiz.CheckOrderAuthority(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), UserInfo.Gwa, UserInfo.UserID))
        //                {
        //                    mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】の入力権限がありません。確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】오더에 대해서 입력권한이 없습니다. 확인바랍니다.";
        //                    mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
        //                    XMessageBox.Show(mbxMsg, mbxCap);
        //                    continue;
        //                }
        //            }

        //            //환자별 특수약제
        //            if (!TypeCheck.IsNull(mBunho) && this.mOrderBiz.CheckSpecialDrugForPatient(mBunho, grdObject.GetItemString(rowIndex, "hangmog_code"), grdObject.GetItemString(rowIndex, "hangmog_name")))
        //                continue;

        //            //자식일 경우
        //            string insertYN = string.Empty;
        //            if (this.mChildYN == "Y")
        //            {
        //                //자식입력여부로드
        //                if (this.mHangmogInfo.LoadChildInsertYN(grdObject.GetItemString(rowIndex, "hangmog_code"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref insertYN))
        //                {
        //                    if (insertYN != "Y") continue;
        //                }
        //            }
        //            else
        //            {
        //                //자식일 경우는 스킵
        //                if (grdObject.GetItemString(rowIndex, "child_gubun") != "3")
        //                {
        //                    //단독입력여부로드
        //                    if (this.mHangmogInfo.LoadDandokInsertYN(grdObject.GetItemString(rowIndex, "hangmog_code"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdObject.GetItemString(rowIndex, "order_gubun").Substring(1, 1), ref insertYN))
        //                    {
        //                        if (insertYN != "Y") continue;
        //                    }
        //                }
        //            }
        //             //*/

        //            if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y") grdObject.SetItemValue(rowIndex, "select", " ");
        //        }
        //    }
        //    else
        //    {
        //        for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
        //        {
        //            if (grdObject.GetItemString(rowIndex, "bulyong_check") != "Y") grdObject.SetItemValue(rowIndex, "select", "");
        //        }
        //    }

        //    SelectionBackColorChange(grdObject);

        //    //선택된 row 표시
        //    SetSelectYaksok();
        //    return true;

        //}

        private void btnProcess_Click(object sender, System.EventArgs e)
        {
            // 현재 로우를 반영한다.
            //현재선택된 row trans			
            for (int i = 0; i < grdOCS0303.RowCount; i++)
            {
                if (grdOCS0303.GetItemString(i, "select") == "Y")
                    InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            }

            CreateReturnLayout();
        }

        private void chkIsNewGroup_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkIsNewGroup.Checked)
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkIsNewGroup.ImageIndex = 1;
                //mIsNewGroupSer = true;

            }
            else
            {
                chkIsNewGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkIsNewGroup.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkIsNewGroup.ImageIndex = 0;
                //mIsNewGroupSer = false;
            }
        }


        #endregion

        #region [DataService Event]

        private void grdOCS0301_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            ///이전에 선택한 약속코드가 있으면 선택상태로
            foreach (DataRow row in dloSelectOCS0301.LayoutTable.Select(" memb = '" + mMemb + "' ", ""))
            {
                for (int i = 0; i < grdOCS0301.RowCount; i++)
                {
                    if (grdOCS0301.GetItemString(i, "pk_seq") == row["pk_seq"].ToString() &&
                        grdOCS0301.GetItemString(i, "yaksok_code") == row["yaksok_code"].ToString())
                    {
                        grdOCS0301.SetItemValue(i, "select", "Y");
                        //grdOCS0301.SetItemValue(i, "select_sang", row["select_sang"].ToString());
                    }
                }
            }

            ////이전 선택정보를 삭제한다.
            //for (int i = 0; i < dloSelectOCS0301.RowCount; i++)
            //{
            //    if (dloSelectOCS0301.GetItemString(i, "memb") == mMemb)
            //    {
            //        dloSelectOCS0301.LayoutTable.Rows.Remove(dloSelectOCS0301.LayoutTable.Rows[i]);
            //        i = i - 1;
            //    }
            //}

            if (!TypeCheck.IsNull(txtSearchSetName.GetDataValue().Trim()))
                grdOCS0301.SetFilter(" yaksok_name like '%" + txtSearchSetName.GetDataValue().Trim() + "%'");

            ShowOCS0300();

            if (this.grdOCS0301.RowCount == 0)
                this.grdOCS0303.Reset();
        }

        private void grdOCS0303_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
        {
            string pk_yaksok = grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "pk_yaksok");

            ///이전에 선택한 약속처방이 있으면 선택상태로
            foreach (DataRow row in dloSelectOCS0303.LayoutTable.Select(" pk_yaksok = '" + pk_yaksok + "' ", ""))
            {
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "pkocs0303") == row["pkocs0303"].ToString())
                    {
                        //값 setting
                        foreach (XEditGridCell cell in grdOCS0303.CellInfos)
                        {
                            //if(cell.CellName == "select")
                                grdOCS0303.SetItemValue(i, cell.CellName, row[cell.CellName]);
                        }
                    }
                }
            }

            //이전 선택정보를 삭제한다.
            //for (int i = 0; i < dloSelectOCS0303.RowCount; i++)
            //{
            //    if (dloSelectOCS0303.GetItemString(i, "pk_yaksok") == pk_yaksok)
            //    {
            //        dloSelectOCS0303.LayoutTable.Rows.Remove(dloSelectOCS0303.LayoutTable.Rows[i]);
            //        i = i - 1;
            //    }
            //}

            SelectionBackColorChange(grdOCS0303);

            //MakeGroupTab(this.grdOCS0303);

        }

        private void MakeGroupTab(XEditGrid aGrid)
        {
            string currentGroupSer = "";
            string title = "";
            IHIS.X.Magic.Controls.TabPage tpgGroup;

            this.tabGroupSerial.SelectionChanged -= new EventHandler(tabGroupSerial_SelectionChanged);

            // 탭페이지 클리어
            try
            {
                this.tabGroupSerial.TabPages.Clear();
            }
            catch
            {
                this.tabGroupSerial.Refresh();
            }

            bool isSelected = false;
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                isSelected = false;
                if (currentGroupSer != aGrid.GetItemString(i, "group_ser"))
                {
                    if (aGrid.GetItemString(i, "input_tab") == "01") // 약인경우는 그룹탭에 복용법을 같이 보여준다.
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ : " + aGrid.GetItemString(i, "bogyong_name");
                    }
                    else
                    {
                        title = aGrid.GetItemString(i, "group_ser") + " グループ";
                    }
                    if (aGrid.GetItemString(i, "select") == "Y")
                        isSelected = true;

                    tpgGroup = new IHIS.X.Magic.Controls.TabPage(title);
                    tpgGroup.ImageList = this.ImageList;
                    if (isSelected)
                        tpgGroup.ImageIndex = 1;
                    else
                        tpgGroup.ImageIndex = 0;

                    tpgGroup.Tag = aGrid.GetItemString(i, "group_ser");

                    this.tabGroupSerial.TabPages.Add(tpgGroup);

                    currentGroupSer = aGrid.GetItemString(i, "group_ser");
                }
            }

            this.tabGroupSerial.SelectionChanged += new EventHandler(tabGroupSerial_SelectionChanged);

            SetTabImage();

            this.tabGroupSerial_SelectionChanged(this.tabGroupSerial, new EventArgs());
        }

        //private void SetTabImage()
        //{
        //    string group_ser = "";

        //    for (int j = 0; j < this.tabGroupSerial.TabPages.Count; j++)
        //    {
        //        tabGroupSerial.TabPages[j].ImageIndex = 0;
        //    }
        //    for (int i = 0; i < this.grdOCS0303.RowCount; i++)
        //    {
        //        if (this.grdOCS0303.GetItemString(i, "select") == "Y")
        //        {
        //            group_ser = this.grdOCS0303.GetItemString(i, "group_ser");

        //            for (int j = 0; j < this.tabGroupSerial.TabPages.Count; j++)
        //            {
        //                if (group_ser == this.tabGroupSerial.TabPages[j].Tag.ToString())
        //                {
        //                    tabGroupSerial.TabPages[j].ImageIndex = 1;
        //                }
        //            }
        //        }
        //    }
        //}

        private void SetTabImage()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in this.tabGroupSerial.TabPages)
            {
                if (this.IsExistSelectedOrder(tpg.Tag.ToString()) == true)
                {
                    tpg.ImageIndex = 1;
                }
                else
                {
                    tpg.ImageIndex = 0;
                }
            }
        }
        private bool IsExistSelectedOrder(string aGroupSer)
        {
            DataRow[] dr = this.dloSelectOCS0303.LayoutTable.Select("group_ser =" + aGroupSer );

            if (dr.Length > 0) return true;
            
            return false;
        }
        #endregion

        #region [grdOCS0301]

        private void grdOCS0301_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //현재선택된 row trans			
            for (int i = 0; i < grdOCS0303.RowCount; i++)
            {
                if (grdOCS0303.GetItemString(i, "select") == "Y")
                    InsertBackTable(grdOCS0303.LayoutTable.Rows[i]);
            }


            this.grdOCS0303.QueryLayout(true);
        }

        #endregion

        #region [grdOCS0303]
        private void grdOCS0303_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            if (e.DataRow["bulyong_check"].ToString() == "Y" || e.DataRow["bulyong_check"].ToString() == "Z")
            {
                e.BackColor = ((XEditGridCell)grdOCS0303.CellInfos[e.ColName]).RowBackColor.Color;
                if (e.ColName != "child_gubun")
                    e.ForeColor = Color.Red;
            }

            #region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
            switch (e.ColName)
            {

                case "pay": // 급여
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "pay_name");
                    break;

                case "bogyong_name": // 급여
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "bogyong_name") + grdOCS0303.GetItemString(e.RowNumber, "dv_name");
                    break;

                case "jundal_part_out": // 전달부서 외래
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "jundal_part_out_name");
                    break;

                case "jundal_part_inp": // 전달부서 입원
                    grdOCS0303[e.RowNumber, e.ColName].ToolTipText = grdOCS0303.GetItemString(e.RowNumber, "jundal_part_inp_name");
                    break;

            }
            #endregion

        }

        private void grdOCS0303_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int rowIndex;
            rowIndex = grdOCS0303.GetHitRowNumber(e.Y);
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                //return; //무효처리

                if (rowIndex < 0) return;

                if (grdOCS0303.CurrentColNumber == 0)
                {
                    //불용처리된 것은 선택을 막는다.
                    if (grdOCS0303.GetItemString(rowIndex, "bulyong_check") == "Y")
                    {
                        //불용인 경우에는 해당 항목의 심사기준을 보여준다.
                        mbxMsg = this.mOrderBiz.LoadSimsa_comment(grdOCS0303.GetItemString(rowIndex, "hangmog_code"));
                        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                        if (!TypeCheck.IsNull(mbxMsg)) XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);

                        return;
                    }

                    if (this.grdOCS0303.GetItemString(rowIndex, "select") == "Y")
                    {
                        this.grdOCS0303.SetItemValue(rowIndex, "select", "N");
                        SelectionBackColorChange(sender, rowIndex, "N");                        
                        this.RemoveBackTable(this.grdOCS0303.LayoutTable.Rows[rowIndex]);
                    }
                    else
                    {
                        this.grdOCS0303.SetItemValue(rowIndex, "select", "Y");
                        SelectionBackColorChange(sender, rowIndex, "Y");
                        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[rowIndex]);
                    }
                    
                    /*
                    //의사인 경우 order 권한 Check한다.
                    if (UserInfo.UserGubun == UserType.Doctor)
                    {
                        if (!this.mOrderBiz.CheckOrderAuthority(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), UserInfo.Gwa, UserInfo.UserID))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】の入力権限がありません。確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】오더에 대해서 입력권한이 없습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
                            XMessageBox.Show(mbxMsg, mbxCap);
                            return;
                        }
                    }

                    //환자별 특수약제
                    if (!TypeCheck.IsNull(mBunho) && this.mOrderBiz.CheckSpecialDrugForPatient(mBunho, grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name")))
                        return;

                    if (grdOCS0303.GetItemString(rowIndex, "select") == "")
                    {
                        //2009.12.14 ntt 자식입력에서 호출일 경우 재료만 선택가능하게
                        if (this.mChildYN == "Y")
                        {
                            if (!this.mHangmogInfo.IsChildInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                                return;

                            //자식선택일 경우만 반드시 "3"으로 입력
                            grdOCS0303.SetItemValue(rowIndex, "child_gubun", "3");
                        }
                        else
                        {
                            //체크된 오다가 자식인 경우 부모가 선택되어 있는지 체크하여 메시지 처리
                            if (grdOCS0303.GetItemString(rowIndex, "child_gubun") == "3")
                            {
                                string child_key = grdOCS0303.GetItemString(rowIndex, "child_key");
                                bool isInsertYN = false;
                                for (int i = 0; i < grdOCS0303.RowCount; i++)
                                {
                                    if (grdOCS0303.GetItemString(i, "parents_key") == child_key && grdOCS0303.GetItemString(i, "select") == " ")
                                    {
                                        isInsertYN = true;
                                        break;
                                    }
                                    else
                                        isInsertYN = false;

                                }
                                if (!isInsertYN)
                                {
                                    mbxMsg = NetInfo.Language == LangMode.Jr ? "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "】 選択されたオーダは材料オーダですので先に手技オーダを選択して下さい！確認してください。" : "【" + grdOCS0303.GetItemString(rowIndex, "hangmog_name") + "　선택된 오다는 재료오더입니다 먼저 수기오다를 선택하십시오!. 확인바랍니다.";
                                    mbxCap = NetInfo.Language == LangMode.Jr ? "入力権限" : "입력권한";
                                    XMessageBox.Show(mbxMsg, mbxCap);
                                    return;
                                }
                            }
                            else
                            {
                                //단독으로 입력할 수 있는지 체크
                                if (!this.mHangmogInfo.IsDandokInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdOCS0303.GetItemString(rowIndex, "order_gubun").Substring(1, 1)))
                                    return;
                            }
                        }

                        grdOCS0303.SetItemValue(rowIndex, "select", " ");
                        SelectionBackColorChange(sender, rowIndex, "Y");
                    }
                    else
                    {
                        grdOCS0303.SetItemValue(rowIndex, "select", "");
                        SelectionBackColorChange(sender, rowIndex, "N");
                    }
                     * */

                    SetSelectYaksok();
                    SetTabImage();
                }
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (rowIndex < 0) return;

                /*
                //2009.12.14 ntt 자식입력에서 호출일 경우 재료만 선택가능하게
                if (this.mChildYN == "Y")
                {
                    if (!this.mHangmogInfo.IsChildInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                        return;

                    //자식선택일 경우만 반드시 "3"으로 입력
                    grdOCS0303.SetItemValue(rowIndex, "child_gubun", "3");
                }
                else
                {
                    //단독입력가능여부 체크
                    if (grdOCS0303.GetItemString(rowIndex, "child_gubun") != "3")
                    {
                        if (!this.mHangmogInfo.IsDandokInsert(grdOCS0303.GetItemString(rowIndex, "hangmog_code"), grdOCS0303.GetItemString(rowIndex, "hangmog_name"), IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), "%", grdOCS0303.GetItemString(rowIndex, "order_gubun").Substring(1, 1)))
                            return;
                    }
                }
                * */
 
                //CreateReturnLayout();
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                rowIndex = grdOCS0303.GetHitRowNumber(e.Y);
                if (rowIndex < 0) return;

                if (grdOCS0303.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

                popupMenu.TrackPopup(((IHIS.Framework.XEditGrid)sender).PointToScreen(new Point(e.X, e.Y)));
            }

        }

        private void InsertBackTable(DataRow dr)
        {
            DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0303=" + dr["pkocs0303"].ToString());
            if(rows.Length < 1)
                this.dloSelectOCS0303.LayoutTable.ImportRow(dr);
        }

        private void RemoveBackTable(DataRow dr)
        {
            DataRow[] rows = this.dloSelectOCS0303.LayoutTable.Select("pkocs0303=" + dr["pkocs0303"].ToString());
            foreach (DataRow row in rows)
                this.dloSelectOCS0303.LayoutTable.Rows.Remove(row);
        }

        private void grdOCS0303_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            if (e.CurrentRow >= 0)
            {
                // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
                this.mHangmogInfo.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
            }
        }

        #endregion

        #region [ButtonList]

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                default:

                    break;
            }
        }

        #endregion

        #region [Fuction]

        //private void DetailSelect(bool select)
        //{
        //    if (select)
        //    {
        //        // Detail 전체 Select
        //        // OCS0303
        //        for (int i = 0; i < grdOCS0303.RowCount; i++)
        //        {
        //            grdOCS0303.SetItemValue(i, "select", " ");
        //        }

        //        SelectionBackColorChange(grdOCS0303);
        //    }
        //    else
        //    {
        //        // Detail 전체 Select
        //        // OCS0303
        //        for (int i = 0; i < grdOCS0303.RowCount; i++)
        //        {
        //            grdOCS0303.SetItemValue(i, "select", "");
        //        }

        //        SelectionBackColorChange(grdOCS0303);
        //    }
        //}

        private void SetSelectYaksok()
        {
            int currentRow = grdOCS0301.CurrentRowNumber;
            bool select = false;
            int node1 = -1, node2 = -1;

            if (grdOCS0301.CurrentRowNumber < 0) return;

            //if (grdOCS0301.CurrentRowNumber >= 0)
            //{
            //    //if (grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "select_sang") == "Y")
            //        select = true;
            //}

            // OCS1003
            if (!select)
            {
                for (int i = 0; i < grdOCS0303.RowCount; i++)
                {
                    if (grdOCS0303.GetItemString(i, "select") != "Y") continue;
                    select = true;
                    break;
                }
            }

            if (select)
            {
                grdOCS0301.SetItemValue(currentRow, "select", "Y");
                //SelectionBackColorChange(grdOCS0301, currentRow, "Y");

                node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                tvwOCS0300.Nodes[node1].Nodes[node2].ImageIndex = 1;
                tvwOCS0300.Nodes[node1].Nodes[node2].SelectedImageIndex = 1;
            }
            else
            {
                grdOCS0301.SetItemValue(currentRow, "select", "N");
                //SelectionBackColorChange(grdOCS0301, currentRow, "N");

                node1 = int.Parse(grdOCS0301.GetItemString(currentRow, "node1"));
                node2 = int.Parse(grdOCS0301.GetItemString(currentRow, "node2"));
                tvwOCS0300.Nodes[node1].Nodes[node2].ImageIndex = 0;
                tvwOCS0300.Nodes[node1].Nodes[node2].SelectedImageIndex = 0;
            }
        }

        #endregion

        #region [Return Layout 생성]

        //날수 및 기타 기본정보변경
        private void CreateReturnLayout()
        {
            grdOCS0301.ClearFilter();

            this.AcceptData();

            //현재선택된 row trans
            //OCS0301
            //for (int i = 0; i < grdOCS0301.RowCount; i++)
            //{
            //    if (grdOCS0301.GetItemString(i, "select_sang") == "Y" && !TypeCheck.IsNull(grdOCS0301.GetItemString(i, "sang_code")))
            //        dloSelectOCS0301.LayoutTable.ImportRow(grdOCS0301.LayoutTable.Rows[i]);
            //}

            // 상병이 선택된 경우만 넘긴다
            //for (int i = 0; i < dloSelectOCS0301.RowCount; i++)
            //{
            //    if (dloSelectOCS0301.GetItemString(i, "select_sang") != "Y")
            //    {
            //        dloSelectOCS0301.DeleteRow(i);
            //        i--;
            //    }
            //}

            //OCS0303
            //for (int i = 0; i < grdOCS0303.RowCount; i++)
            //{
            //    if (grdOCS0303.GetItemString(i, "select") == "Y")
            //        dloSelectOCS0303.LayoutTable.ImportRow(grdOCS0303.LayoutTable.Rows[i]);
            //}

            //string pk_yaksok = "";
            //int base_Nalsu = 0;
            //DataRow[] tempRow = null;

            //foreach (DataRow row in dloSelectOCS0303.LayoutTable.Rows)
            //{
            //    //order 단위가 현재 존재하지 않는 경우
            //    //				if(dloOrder_danui.LayoutTable.Select(" code = '" + row["ord_danui"].ToString() + "' ", "").Length < 1)
            //    //					row["ord_danui"] = row["ord_danui_check"];

            //    pk_yaksok = row["pk_yaksok"].ToString();

            //    tempRow = dloSelectOCS0301.LayoutTable.Select(" pk_yaksok = '" + pk_yaksok + "' ", "");
            //    if (tempRow.Length < 1 || !TypeCheck.IsInt(tempRow[0]["nalsu"].ToString()) || tempRow[0]["nalsu"].ToString() == "0")
            //        base_Nalsu = int.Parse(row["nalsu"].ToString() == "" ? "0" : row["nalsu"].ToString());
            //    else
            //        base_Nalsu = int.Parse(tempRow[0]["nalsu"].ToString());

            //    if (base_Nalsu <= 0) continue;

            //    //내복약,외용약
            //    if (row["order_gubun_bas"].ToString() == "C" || row["order_gubun_bas"].ToString() == "D")
            //    {
            //        row["nalsu"] = base_Nalsu;
            //    }

            //}

            //if (dloSelectOCS0301.LayoutTable.Rows.Count < 1 && dloSelectOCS0303.LayoutTable.Rows.Count < 1)
            if (dloSelectOCS0303.LayoutTable.Rows.Count < 1)
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダが選択されていません。ご確認下さい。" : "처방이 선택되지 않았습니다. 확인하세요.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }

            //if (chkIsNewGroup.Checked)
            //    mIsNewGroupSer = true;
            //else
            //    mIsNewGroupSer = false;

            //약속코드선택정보가 있는 경우 Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

            CommonItemCollection commandParams = new CommonItemCollection();
            //commandParams.Add("OCS0301", dloSelectOCS0301);
            //commandParams.Add("isnewgroup", mIsNewGroupSer);
            commandParams.Add("OCS0303", dloSelectOCS0303);
            scrOpener.Command(ScreenID, commandParams);

            this.Close();
        }
        #endregion

        #region Mix Group 데이타 Image Display (DiaplayMixGroup)
        /// <summary>
        /// Mix Group 데이타 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DiaplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                //aGrd.Redraw = false; // Grid Display 멈춤

                int imageCnt = 0;

                // 기존 image 클리어
                for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group
                            if (aGrd.GetItemValue(i, "order_gubun").ToString().Trim() == aGrd.GetItemValue(j, "order_gubun").ToString().Trim() &&
                                aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim())
                            {
                                count++;
                                if (count > 1)
                                {
                                    //      헤더를 빼야 실제 Row
                                    aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
                                }
                            }
                        }
                        // 현재는 image 갯수만큼 처리
                        if (count > 1) imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
                    }
                }
            }
            finally
            {
                //aGrd.Redraw = true; // Grid Display 
            }

        }
        #endregion

        #region [그리드에서 선택한 Row에 대한 BackColor를 변경한다]

        private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            if (currentRowIndex < 0) return;

            //선택된 Row에대해서 색을 변경한다
            //data   Y :색을 변경, N :색을 변경 해제
            //image 설정
            if (data == "Y")
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
            }
            else
            {
                //image 변경
                if (grdObject.RowHeaderVisible)
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                else
                    grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
            }

            for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
            {
                if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                {
                    // 돈복여부
                    if (grdObject.GetItemString(currentRowIndex, "donbog_yn") == "Y")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                        continue;
                    }

                    // 불균등분할
                    if (!TypeCheck.IsNull(grdObject.GetItemString(currentRowIndex, "dv_name")))
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                        continue;
                    }
                }

                if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                {
                    if (data == "Y")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    }
                    else
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    }
                }
                else
                { 
                
                }
            }

            //child 이미지 세팅
            ChildSetImage();
        }


        private void SelectionBackColorChange(object grid)
        {
            XEditGrid grdObject = (XEditGrid)grid;

            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "select").ToString() == "Y")
                {
                    //image 변경
                    if (grdObject.RowHeaderVisible)
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                    else
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];

                    //ColorYn Y :색을 변경, N :색을 변경 해제
                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                        }
                    }
                }
                else
                {
                    //image 변경
                    if (grdObject.RowHeaderVisible)
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
                    else
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

                    for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                    {
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName == "bogyong_name")
                        {
                            // 돈복여부
                            if (grdObject.GetItemString(rowIndex, "donbog_yn") == "Y")
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.Beige);
                                continue;
                            }

                            // 불균등분할
                            if (!TypeCheck.IsNull(grdObject.GetItemString(rowIndex, "dv_name")))
                            {
                                grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = new XColor(System.Drawing.Color.LightCyan);
                                continue;
                            }
                        }

                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "select")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                        }
                    }
                }
            }

            if (grdObject.Name == "grdOCS0303") DiaplayMixGroup(grdObject);


            //child 이미지 세팅
            ChildSetImage();
        }

        #endregion

        #region [검사정보조회]

        // 검사정보조회
        private void PopUpMenuGumsaInfo_Click(object sender, System.EventArgs e)
        {
            if (this.CurrMSLayout == null || CurrMSLayout.CurrentRowNumber < 0) return;

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("hangmog_code", CurrMSLayout.GetItemValue(CurrMSLayout.CurrentRowNumber, "hangmog_code"));
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        #endregion

        #region [ SetOrder Copy ]

        // Set Order Copy
        private void PopUpMenuSetOrderCopy_Click(object sender, System.EventArgs e)
        {
            if (tvwOCS0300.SelectedNode.Tag == null) return;

            int currentRow = int.Parse(tvwOCS0300.SelectedNode.Tag.ToString());

            string yaksok_memb = grdOCS0301.GetItemString(currentRow, "memb");
            string yaksok_code = grdOCS0301.GetItemString(currentRow, "yaksok_code");
            string newYaksok_code = "";
            string newYaksok_name = grdOCS0301.GetItemString(currentRow, "yaksok_name");
            string insert_tab = grdOCS0301.GetItemString(currentRow, "tab_gubun");


            if (CheckExistsYasokCode(yaksok_code))
            {
                //약속코드를 입력받는다.
                frmYaksok_code frm = new frmYaksok_code();
                frm.Yaksok_name = newYaksok_name;
                frm.ShowDialog();

                //선택시 처리
                if (frm.DialogResult == DialogResult.OK)
                {
                    newYaksok_code = frm.Yaksok_code;
                    newYaksok_name = frm.Yaksok_name;
                }
                else
                    return;
            }
            else
            {
                newYaksok_code = yaksok_code;
            }

            this.dloSetOrderCopy.Reset();
            int insertRow = this.dloSetOrderCopy.InsertRow(-1);
            this.dloSetOrderCopy.SetItemValue(insertRow, "source_memb", yaksok_memb);
            this.dloSetOrderCopy.SetItemValue(insertRow, "source_yaksok_code", yaksok_code);
            this.dloSetOrderCopy.SetItemValue(insertRow, "target_memb", UserInfo.YaksokOpenID);
            this.dloSetOrderCopy.SetItemValue(insertRow, "yaksok_code", newYaksok_code);
            this.dloSetOrderCopy.SetItemValue(insertRow, "yaksok_name", newYaksok_name);
            this.dloSetOrderCopy.SetItemValue(insertRow, "insert_tab",  insert_tab);

            if (this.SetOrderCopy())
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピーが完了しました。" : "Set Order Copy가 완료되었습니다.";
                mbxCap = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピー" : "Set Order Copy";
                XMessageBox.Show(mbxMsg, mbxCap);
            }
            else
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピーが失敗しました。\n" : "Set Order Copy가 실패하였습니다.";
                mbxMsg = mbxMsg + Service.ErrMsg;
                mbxCap = NetInfo.Language == LangMode.Jr ? "セットオ―ダコピー" : "Set Order Copy";
                XMessageBox.Show(mbxMsg, mbxCap);
            }

        }

        private bool SetOrderCopy()
        {
            ArrayList inputList = new ArrayList();
            inputList.Add(dloSetOrderCopy.GetItemString(0, "source_memb"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "source_yaksok_code"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "target_memb"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "yaksok_code"));
            inputList.Add(dloSetOrderCopy.GetItemString(0, "yaksok_name"));
            ArrayList outputList = new ArrayList();

            if (!Service.ExecuteProcedure("PR_OCS_COPY_SET_ORDER", inputList, outputList))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return false;
            }
            return true;
        }

        private bool CheckExistsYasokCode(string aYasok_code)
        {
            //중복check
            string cmdText = "";
            object retVal = null;
            cmdText = " SELECT YAKSOK_NAME "
                    + "   FROM OCS0301 "
                    + "  WHERE MEMB = '" + UserInfo.YaksokOpenID + "' "
                    + "    AND YAKSOK_CODE = '" + aYasok_code + "' "
                    + "    AND HOSP_CODE   = '" + mHospCode + "' " ;

            retVal = Service.ExecuteScalar(cmdText);

            if (!TypeCheck.IsNull(retVal))
                return false;
            else
                return true;
        }


        #endregion

        #region [선택한 검사정보 조회]
        private void btnCPLInfo_Click(object sender, System.EventArgs e)
        {
            int rowIndex = grdOCS0303.CurrentRowNumber;
            if (rowIndex < 0) return;

            if (grdOCS0303.GetItemString(rowIndex, "slip_code").Substring(0, 1) != "B") return;

            popupMenu.MenuCommands[0].OnClick(null);

        }
        #endregion

        #region ChildSetImage
        private void ChildSetImage()
        {
            for (int i = 0; i < this.grdOCS0303.RowCount; i++)
            {
                this.grdOCS0303[i, "child_gubun"].ForeColor = new XColor(System.Drawing.Color.Transparent);
                switch (this.grdOCS0303.GetItemString(i, "child_gubun"))
                {
                    case "1": //자식있음
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[6];
                        break;
                    case "2": //자식없음
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[7];
                        break;
                    case "3": //자식
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[8];
                        break;
                    default:
                        this.grdOCS0303[i, "child_gubun"].Image = this.ImageList.Images[7];
                        break;
                }
                this.grdOCS0303[i, "child_gubun"].ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
        }
        #endregion

        #region 각 그리드에 바인드 변수(병원코드) 설정
        private void grdOCS0301_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0301.SetBindVarValue("f_hosp_code", mHospCode);
            
            //hard coding
            grdOCS0301.SetBindVarValue("f_memb", mMemb);
            grdOCS0301.SetBindVarValue("f_input_tab", mInput_tab);
        }

        private void grdOCS0303_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0303.SetBindVarValue("f_hosp_code", mHospCode);
            //grdOCS0303.SetBindVarValue("f_group_ser", tabGroupSerial.SelectedTab.Title);

            //hard coding
            grdOCS0303.SetBindVarValue("f_memb", mMemb);
            grdOCS0303.SetBindVarValue("f_fkocs0300_seq", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "pk_seq"));
            grdOCS0303.SetBindVarValue("f_yaksok_code", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            grdOCS0303.SetBindVarValue("f_input_tab", grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "input_tab"));
        }
        #endregion

        private void tabGroupSerial_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdOCS0303.RowCount; i++)
            {
                if (this.grdOCS0303.GetItemString(i, "group_ser") == this.tabGroupSerial.SelectedTab.Tag.ToString())
                {
                    this.grdOCS0303.SetRowVisible(i, true);
                }
                else
                {
                    this.grdOCS0303.SetRowVisible(i, false);
                }
            }
        }

        private void btnDeleteAllTab_Click(object sender, EventArgs e)
        {
            //if (this.tabGroupSerial.SelectedTab != null)
            //    SelectRow(this.tabGroupSerial.SelectedTab.Tag.ToString());
            //if (this.tabGroupSerial.SelectedTab != null)
                DeleteRow("%");
        }

        private void btnSelectAllTab_Click(object sender, EventArgs e)
        {
            //if (this.tabGroupSerial.SelectedTab != null)
                SelectRow("%");
        }
        private void SelectRow(string groupSerial)
        {
            if (groupSerial == "%")
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                        continue;

                    this.grdOCS0303.SetItemValue(i, "select", "Y");
                    SelectionBackColorChange(grdOCS0303, i, "Y");
                    this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                }
            }
            else
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "group_ser") == groupSerial)
                    {
                        if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                            continue;

                        this.grdOCS0303.SetItemValue(i, "select", "Y");
                        SelectionBackColorChange(grdOCS0303, i, "Y");
                        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                    }
                }
            }

            SetSelectYaksok();
            SetTabImage();
        }

        private void DeleteRow(string groupSerial)
        {
            if (groupSerial == "%")
            {
                for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                {
                    if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                        continue;

                    this.grdOCS0303.SetItemValue(i, "select", "N");
                    SelectionBackColorChange(grdOCS0303, i, "N");
                    this.RemoveBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                }
            }
            else
            {
                //for (int i = 0; i < this.grdOCS0303.RowCount; i++)
                //{
                //    if (this.grdOCS0303.GetItemString(i, "group_ser") == groupSerial)
                //    {
                //        if (this.grdOCS0303.GetItemString(i, "bulyong_check") == "Y")
                //            continue;

                //        this.grdOCS0303.SetItemValue(i, "select", "Y");
                //        SelectionBackColorChange(grdOCS0303, i, "Y");
                //        this.InsertBackTable(this.grdOCS0303.LayoutTable.Rows[i]);
                //    }
                //}
            }

            SetSelectYaksok();
            SetTabImage();
        }


        private void grdOCS0303_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

    }
}

