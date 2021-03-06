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

namespace IHIS.OCSI
{
	/// <summary>
	/// OCS2003R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS2003R00 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		
        
		//등록번호
		private string mBunho = "";
		//입원Key
		private int mFkinp1001 = 0;
		//입력구분
		private string mInput_gubun = "";
		//처방일자
		private string mOrder_date = "";

		//진료의사, 진료의사
		//진료과가 다른 경우에는 해당 의사 처방만 출력한다.
		private string mDoctor = "";
		private string mGwa    = "";
		
		//MAX LINE
		private const int MAXLINE    = 30;
		private int       mPrintLine = 1;

		//출력구분
		private int       mPrintGubun = 1;

		//화면 닫을지 여부
		//private bool mAuto_close = false;
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;		
		private IHIS.Framework.XDisplayBox dbxZoom;
		private IHIS.Framework.XButton btnZoomIn;
		private IHIS.Framework.XButton btnZoomOut;
		private IHIS.Framework.XButton btnExcel;
		private IHIS.Framework.MultiLayout dloPatientInfo;
		private IHIS.Framework.MultiLayout dloOCS2001;
		private IHIS.Framework.XDataWindow dw_order_list;
		private IHIS.Framework.MultiLayout dloOCS2003;
		private IHIS.Framework.XRadioButton rbtOUT;
		private IHIS.Framework.XRadioButton rbtOCS;
		private IHIS.Framework.XRadioButton rbtALL;
		private IHIS.Framework.MultiLayout dloOCS2003_PRINT;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem8;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem13;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem14;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem15;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem16;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem17;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem18;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem19;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem20;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem21;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem22;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem55;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem56;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem57;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem58;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem59;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem60;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem61;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem62;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem63;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem64;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem65;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem66;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem67;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem68;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem69;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem70;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem71;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem72;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem73;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem74;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem75;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem76;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem77;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem78;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem79;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem80;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem81;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem82;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem83;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem84;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem85;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem86;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem87;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem88;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem89;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem90;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem91;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem92;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem93;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem94;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem95;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem96;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem97;
        private MultiLayoutItem multiLayoutItem98;
        private MultiLayoutItem multiLayoutItem99;
        private MultiLayoutItem multiLayoutItem100;
        private MultiLayoutItem multiLayoutItem101;
        private MultiLayoutItem multiLayoutItem102;
        private MultiLayoutItem multiLayoutItem103;
        private MultiLayoutItem multiLayoutItem104;
        private MultiLayoutItem multiLayoutItem105;
        private MultiLayoutItem multiLayoutItem106;
        private MultiLayoutItem multiLayoutItem107;
        private MultiLayoutItem multiLayoutItem108;
        private MultiLayoutItem multiLayoutItem109;
        private MultiLayoutItem multiLayoutItem110;
        private MultiLayoutItem multiLayoutItem111;
        private MultiLayoutItem multiLayoutItem112;
        private MultiLayoutItem multiLayoutItem113;
        private MultiLayoutItem multiLayoutItem114;
        private MultiLayoutItem multiLayoutItem115;
        private MultiLayoutItem multiLayoutItem116;
        private MultiLayoutItem multiLayoutItem117;
        private MultiLayoutItem multiLayoutItem118;
        private MultiLayoutItem multiLayoutItem119;
        private MultiLayoutItem multiLayoutItem120;
        private MultiLayoutItem multiLayoutItem121;
        private MultiLayoutItem multiLayoutItem122;
        private MultiLayoutItem multiLayoutItem123;
        private MultiLayoutItem multiLayoutItem124;
        private MultiLayoutItem multiLayoutItem125;
        private MultiLayoutItem multiLayoutItem126;
        private MultiLayoutItem multiLayoutItem127;
        private MultiLayoutItem multiLayoutItem128;
        private MultiLayoutItem multiLayoutItem129;
        private MultiLayoutItem multiLayoutItem130;
        private MultiLayoutItem multiLayoutItem134;
        private MultiLayoutItem multiLayoutItem135;
        private MultiLayoutItem multiLayoutItem136;
        private MultiLayoutItem multiLayoutItem137;
        private MultiLayoutItem multiLayoutItem138;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS2003R00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2003R00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.rbtOUT = new IHIS.Framework.XRadioButton();
            this.rbtOCS = new IHIS.Framework.XRadioButton();
            this.rbtALL = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnExcel = new IHIS.Framework.XButton();
            this.btnZoomIn = new IHIS.Framework.XButton();
            this.dbxZoom = new IHIS.Framework.XDisplayBox();
            this.btnZoomOut = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.dloPatientInfo = new IHIS.Framework.MultiLayout();
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
            this.dloOCS2001 = new IHIS.Framework.MultiLayout();
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
            this.dloOCS2003 = new IHIS.Framework.MultiLayout();
            this.dw_order_list = new IHIS.Framework.XDataWindow();
            this.dloOCS2003_PRINT = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem73 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem74 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem75 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem76 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem77 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem78 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem79 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem80 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem81 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem82 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem83 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem84 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem85 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem86 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem87 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem88 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem89 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem90 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem91 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem92 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem93 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem94 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem95 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem96 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem97 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem98 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem99 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem100 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem101 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem102 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem103 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem104 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem105 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem106 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem107 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem108 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem109 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem110 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem111 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem112 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem113 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem114 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem115 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem116 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem117 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem118 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem119 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem120 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem121 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem122 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem123 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem124 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem125 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem126 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem127 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem128 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem129 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem130 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem134 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem135 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem136 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem137 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem138 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloPatientInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS2001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS2003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS2003_PRINT)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.rbtOUT);
            this.xPanel1.Controls.Add(this.rbtOCS);
            this.xPanel1.Controls.Add(this.rbtALL);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(578, 34);
            this.xPanel1.TabIndex = 0;
            this.xPanel1.Visible = false;
            // 
            // rbtOUT
            // 
            this.rbtOUT.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtOUT.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtOUT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOUT.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtOUT.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtOUT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtOUT.ImageIndex = 0;
            this.rbtOUT.ImageList = this.ImageList;
            this.rbtOUT.Location = new System.Drawing.Point(401, 1);
            this.rbtOUT.Name = "rbtOUT";
            this.rbtOUT.Size = new System.Drawing.Size(112, 26);
            this.rbtOUT.TabIndex = 29;
            this.rbtOUT.Text = "      医事会計用";
            this.rbtOUT.UseVisualStyleBackColor = false;
            this.rbtOUT.Visible = false;
            this.rbtOUT.Click += new System.EventHandler(this.rbtPrint_Click);
            // 
            // rbtOCS
            // 
            this.rbtOCS.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtOCS.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtOCS.Checked = true;
            this.rbtOCS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOCS.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtOCS.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtOCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtOCS.ImageIndex = 1;
            this.rbtOCS.ImageList = this.ImageList;
            this.rbtOCS.Location = new System.Drawing.Point(289, 1);
            this.rbtOCS.Name = "rbtOCS";
            this.rbtOCS.Size = new System.Drawing.Size(112, 26);
            this.rbtOCS.TabIndex = 28;
            this.rbtOCS.TabStop = true;
            this.rbtOCS.Text = "      オーダ記録";
            this.rbtOCS.UseVisualStyleBackColor = false;
            this.rbtOCS.Visible = false;
            this.rbtOCS.Click += new System.EventHandler(this.rbtPrint_Click);
            // 
            // rbtALL
            // 
            this.rbtALL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtALL.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtALL.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtALL.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtALL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtALL.ImageIndex = 0;
            this.rbtALL.ImageList = this.ImageList;
            this.rbtALL.Location = new System.Drawing.Point(181, 1);
            this.rbtALL.Name = "rbtALL";
            this.rbtALL.Size = new System.Drawing.Size(106, 26);
            this.rbtALL.TabIndex = 27;
            this.rbtALL.Text = "      全体";
            this.rbtALL.UseVisualStyleBackColor = false;
            this.rbtALL.Visible = false;
            this.rbtALL.Click += new System.EventHandler(this.rbtPrint_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.btnExcel);
            this.xPanel2.Controls.Add(this.btnZoomIn);
            this.xPanel2.Controls.Add(this.dbxZoom);
            this.xPanel2.Controls.Add(this.btnZoomOut);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 832);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(578, 40);
            this.xPanel2.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(235, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(88, 28);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.Location = new System.Drawing.Point(112, 6);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(26, 26);
            this.btnZoomIn.TabIndex = 3;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // dbxZoom
            // 
            this.dbxZoom.EditMaskType = IHIS.Framework.MaskType.Number;
            this.dbxZoom.GeneralNumberFormat = true;
            this.dbxZoom.Location = new System.Drawing.Point(43, 7);
            this.dbxZoom.Name = "dbxZoom";
            this.dbxZoom.Size = new System.Drawing.Size(68, 24);
            this.dbxZoom.TabIndex = 2;
            this.dbxZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.Location = new System.Drawing.Point(16, 6);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(26, 26);
            this.btnZoomOut.TabIndex = 1;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(329, 4);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // dloPatientInfo
            // 
            this.dloPatientInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem11});
            this.dloPatientInfo.QuerySQL = resources.GetString("dloPatientInfo.QuerySQL");
            this.dloPatientInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloPatientInfo_QueryStarting);
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
            this.multiLayoutItem3.DataName = "suname2";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "birth";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "age_sex";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "doctor";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "doctor_name";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "gwa";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "gwa_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "order_date";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "input_gubun";
            // 
            // dloOCS2001
            // 
            this.dloOCS2001.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem22});
            this.dloOCS2001.QuerySQL = resources.GetString("dloOCS2001.QuerySQL");
            this.dloOCS2001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloOCS2001_QueryStarting);
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "ju_sang_yn";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "sang_code";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "ser";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "dis_sang_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "sang_start_date";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "sang_end_date";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "sang_end_sayu";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "sang_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "pre_modifier_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "post_modifier_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "end_yn";
            // 
            // dloOCS2003
            // 
            this.dloOCS2003.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem98,
            this.multiLayoutItem99,
            this.multiLayoutItem100,
            this.multiLayoutItem101,
            this.multiLayoutItem102,
            this.multiLayoutItem103,
            this.multiLayoutItem104,
            this.multiLayoutItem105,
            this.multiLayoutItem106,
            this.multiLayoutItem107,
            this.multiLayoutItem108,
            this.multiLayoutItem109,
            this.multiLayoutItem110,
            this.multiLayoutItem111,
            this.multiLayoutItem112,
            this.multiLayoutItem113,
            this.multiLayoutItem114,
            this.multiLayoutItem115,
            this.multiLayoutItem116,
            this.multiLayoutItem117,
            this.multiLayoutItem118,
            this.multiLayoutItem119,
            this.multiLayoutItem120,
            this.multiLayoutItem121,
            this.multiLayoutItem122,
            this.multiLayoutItem123,
            this.multiLayoutItem124,
            this.multiLayoutItem125,
            this.multiLayoutItem126,
            this.multiLayoutItem127,
            this.multiLayoutItem128,
            this.multiLayoutItem129,
            this.multiLayoutItem130,
            this.multiLayoutItem134,
            this.multiLayoutItem135,
            this.multiLayoutItem136,
            this.multiLayoutItem137,
            this.multiLayoutItem138});
            this.dloOCS2003.QuerySQL = resources.GetString("dloOCS2003.QuerySQL");
            this.dloOCS2003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloOCS2003_QueryStarting);
            // 
            // dw_order_list
            // 
            this.dw_order_list.DataWindowObject = "dw_order_list_orderinfo";
            this.dw_order_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dw_order_list.LibraryList = "..\\OCSI\\ocsi.ocs2003r00.pbd";
            this.dw_order_list.Location = new System.Drawing.Point(0, 34);
            this.dw_order_list.Name = "dw_order_list";
            this.dw_order_list.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dw_order_list.Size = new System.Drawing.Size(578, 798);
            this.dw_order_list.TabIndex = 2;
            this.dw_order_list.Text = "xDataWindow1";
            // 
            // dloOCS2003_PRINT
            // 
            this.dloOCS2003_PRINT.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72,
            this.multiLayoutItem73,
            this.multiLayoutItem74,
            this.multiLayoutItem75,
            this.multiLayoutItem76,
            this.multiLayoutItem77,
            this.multiLayoutItem78,
            this.multiLayoutItem79,
            this.multiLayoutItem80,
            this.multiLayoutItem81,
            this.multiLayoutItem82,
            this.multiLayoutItem83,
            this.multiLayoutItem84,
            this.multiLayoutItem85,
            this.multiLayoutItem86,
            this.multiLayoutItem87,
            this.multiLayoutItem88,
            this.multiLayoutItem89,
            this.multiLayoutItem90,
            this.multiLayoutItem91,
            this.multiLayoutItem92,
            this.multiLayoutItem93,
            this.multiLayoutItem94,
            this.multiLayoutItem95,
            this.multiLayoutItem96,
            this.multiLayoutItem97});
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "print_gubun";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "title_gubun";
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "bunho";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "suname";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "suname2";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "birth";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "age_sex";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "doctor";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "doctor_name";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "gwa";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "gwa_name";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "order_date";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "comment";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "order_end_yn";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "record_gubun";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "ju_sang_yn";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "dis_sang_name";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "input_gubun";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "input_gubun_name";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "group_ser";
            this.multiLayoutItem74.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "mix_group";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "order_gubun_name";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "hangmog_code";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "hangmog_name";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "suryang";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "ord_danui";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "ord_danui_name";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "dv_time";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "dv";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "nalsu";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "order_detail";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "wonyoi_order_yn";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "specimen_code";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "specimen_name";
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "jusa";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "jusa_name";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "bogyong_code";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "bogyong_name";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "order_remark";
            // 
            // multiLayoutItem94
            // 
            this.multiLayoutItem94.DataName = "tel_yn";
            // 
            // multiLayoutItem95
            // 
            this.multiLayoutItem95.DataName = "seq";
            this.multiLayoutItem95.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem96
            // 
            this.multiLayoutItem96.DataName = "prn_yn";
            // 
            // multiLayoutItem97
            // 
            this.multiLayoutItem97.DataName = "prtmode";
            // 
            // multiLayoutItem98
            // 
            this.multiLayoutItem98.DataName = "input_gubun";
            // 
            // multiLayoutItem99
            // 
            this.multiLayoutItem99.DataName = "input_gubun_name";
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "group_ser";
            this.multiLayoutItem100.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "mix_group";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "order_gubun";
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "order_gubun_name";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "order_gubun_bas";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "hangmog_code";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "hangmog_name";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "sg_code";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "sg_name";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "suryang";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "ord_danui";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "ord_danui_name";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "dv_time";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "dv";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "nalsu";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "wonyoi_order_yn";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "specimen_code";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "specimen_name";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "jusa";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "jusa_name";
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "bogyong_code";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "bogyong_name";
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "hope_date";
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "order_remark";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "nurse_remark";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "emergency";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "tel_yn";
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "prn_yn";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "reser_yn";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "seq";
            this.multiLayoutItem129.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "brought_drg_yn";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "powder_yn";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "drg_pack_yn";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "instead_yn";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "approve_yn";
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "postapprove_yn";
            // 
            // OCS2003R00
            // 
            this.Controls.Add(this.dw_order_list);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS2003R00";
            this.Size = new System.Drawing.Size(578, 872);
            this.UserChanged += new System.EventHandler(this.OCS2003R00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS2003R00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloPatientInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS2001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS2003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOCS2003_PRINT)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			// DataWindow Preview설정
			dw_order_list.Modify("DataWindow.Print.Preview=Yes");						
			dw_order_list.Modify("DataWindow.Print.Preview.Zoom= 100");
			dbxZoom.SetDataValue("100");
		}

		private void OCS2003R00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			
				// Call된 경우
			if ( this.OpenParam != null )
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです. 確認してください." : "환자번호가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							this.Close();
							return;
						}
						else
							mBunho = OpenParam["bunho"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が正確ではないです. 確認してください." : "환자번호가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}

					if(OpenParam.Contains("fkinp1001"))
					{
						if(!TypeCheck.IsInt(OpenParam["fkinp1001"].ToString()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正確ではないです. 確認してください." : "입원정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);							
							return;
						}
						else
							mFkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString().Trim());
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正確ではないです. 確認してください." : "입원정보가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);							
						return;
					}

					if(OpenParam.Contains("input_gubun"))
					{
						if(TypeCheck.IsNull(OpenParam["input_gubun"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正確ではないです. 確認してください." : "입력구분이 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							this.Close();
							return;
						}
						else
							mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正確ではないです. 確認してください." : "입력구분이 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}					
					
					mOrder_date = DateTime.Now.ToString("yyyy/MM/dd");
					if(OpenParam.Contains("order_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["order_date"].ToString()))
							mOrder_date = OpenParam["order_date"].ToString();
					}
					
					if(OpenParam.Contains("doctor"))
					{
						if(!TypeCheck.IsNull(OpenParam["doctor"].ToString()))
							mDoctor = OpenParam["doctor"].ToString();
					}

					if(OpenParam.Contains("gwa"))
					{
						if(!TypeCheck.IsNull(OpenParam["gwa"].ToString()))
							mGwa = OpenParam["gwa"].ToString();
					}


                    ////Data가 없는 경우 화면 닫을지 여부
                    //if(OpenParam.Contains("auto_close"))
                    //{
                    //    mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
                    //    if(mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
                    //}

				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
			}
			else
			{
                
                this.Close();
			}
			

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		
		}

		private void PostLoad()
		{	
			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS2003R00_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			LoadData();

            //if(mAuto_close)
            //{
            //    //OCS
            //    if(dw_order_list.RowCount > 0) this.Print();				
            //    this.Close();
            //    return;
            //}
			
		}

		private void OCS2003R00_UserChanged(object sender, System.EventArgs e)
		{
			if(TypeCheck.IsNull(mDoctor) && UserInfo.UserGubun == UserType.Doctor)
				mDoctor = UserInfo.UserID;

			if(TypeCheck.IsNull(mGwa) && UserInfo.UserGubun == UserType.Doctor)
				mGwa = UserInfo.Gwa;
		}

		#endregion

		#region [Data Load]

		private void LoadData()
		{
			try
			{	
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SetMsg("");

				this.dloPatientInfo.QueryLayout(true);
				this.dloOCS2001.QueryLayout(true);
				this.dloOCS2003.QueryLayout(true);


				SetOrderData(false);
				
			}
			finally
			{
				SetMsg(" ");
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		private void SetOrderData(bool allPrint)
		{
			dw_order_list.Reset();
			this.dloOCS2003_PRINT.Reset();

			if( dloPatientInfo.RowCount < 1 || dloOCS2003.RowCount < 1 ) return;

			int currentRowIndex = -1;

			//input_gubun, group_ser, 복용법, 일수 등등 출력관련
			string pre_input_gubun, pre_group_ser, pre_bogyong_code, pre_hope_date, pre_nalsu;
			
			//처방단위, DV, 일수는 출력에 맞게 수정한다.
			string order_name, ord_danui, dv, nalsu, order_detail, remark;
            
			//환자정보(접수정보)
			for(int patientIndex = 0; patientIndex < dloPatientInfo.RowCount; patientIndex++)
			{
				mPrintLine = 1;
                
//				currentRowIndex = InsertPrintRow(patientIndex, allPrint);
//
//				//dataWindow group header
//				if(dloOCS2001.RowCount > 0) mPrintLine = mPrintLine + 1;
//                
//				//상병
//				for(int ocs1001Index = 0; ocs1001Index < dloOCS2001.RowCount; ocs1001Index++)
//				{
//					if(currentRowIndex != 0)
//						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
//
//					//record gubun
//					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "0");
//					//prtmode
//					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "2");
//					//주상병
//					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "ju_sang_yn", dloOCS2001.GetItemString(ocs1001Index, "ju_sang_yn"));
//					//상병명
//					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "dis_sang_name", dloOCS2001.GetItemString(ocs1001Index, "dis_sang_name"));
//
//					if(currentRowIndex == 0) currentRowIndex++;
//				}

				//처방
				//dataWindow group header
				if(dloOCS2003.RowCount > 0)
				{
					mPrintLine = mPrintLine == MAXLINE ? 1 : mPrintLine + 1;
					pre_input_gubun  = " ";
					pre_group_ser    = dloOCS2003.GetItemString(0, "group_ser"   );
					pre_bogyong_code = dloOCS2003.GetItemString(0, "bogyong_code"); 
					pre_hope_date    = dloOCS2003.GetItemString(0, "hope_date"   ); 
					pre_nalsu        = dloOCS2003.GetItemString(0, "nalsu"       );
                    
				}
				else
				{
					pre_input_gubun  = " ";
					pre_group_ser    = " ";
					pre_bogyong_code = " ";
					pre_hope_date    = " ";
					pre_nalsu        = " ";
				}
				
				for(int ocs2003Index = 0; ocs2003Index < dloOCS2003.RowCount; ocs2003Index++)
				{					
					if(currentRowIndex != 0)
					{
						if( pre_input_gubun  != dloOCS2003.GetItemString(ocs2003Index, "input_gubun" ) ||
							pre_group_ser    != dloOCS2003.GetItemString(ocs2003Index, "group_ser"   ) ||
							pre_bogyong_code != dloOCS2003.GetItemString(ocs2003Index, "bogyong_code") ||
							pre_hope_date    != dloOCS2003.GetItemString(ocs2003Index, "hope_date"   ) ||
							pre_nalsu        != dloOCS2003.GetItemString(ocs2003Index, "nalsu"       ) )
						{
							//내복약리[복용법, 복용시작일, 날수]
							if(  dloOCS2003.GetItemString(ocs2003Index -1, "order_gubun_bas" ).Trim() == "C" )
							{
								currentRowIndex = InsertPrintRow(patientIndex, allPrint);
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "input_gubun"     , dloOCS2003.GetItemString(ocs2003Index -1, "input_gubun"     ));
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index -1, "group_ser"       ));
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index -1, "order_gubun_name"));
                                
								//복용법
								remark = dloOCS2003.GetItemString(ocs2003Index  -1, "bogyong_name" );
                                
								//투약시작일
								if(!TypeCheck.IsNull(dloOCS2003.GetItemString(ocs2003Index  -1, "hope_date" ).Trim()))
								{
									dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);

									currentRowIndex = InsertPrintRow(patientIndex, allPrint);
									dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
									dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
									dloOCS2003_PRINT.SetItemValue(currentRowIndex, "input_gubun"     , dloOCS2003.GetItemString(ocs2003Index -1, "input_gubun"     ));
									dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index -1, "group_ser"       ));
									dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index -1, "order_gubun_name"));
									remark = " ◈ 投薬スタート日 : " + dloOCS2003.GetItemString(ocs2003Index  -1, "hope_date" );
								}

								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
                                
								//날수
								nalsu = dloOCS2003.GetItemString(ocs2003Index -1, "nalsu").Trim().Replace("D", "") + "日";
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "nalsu", nalsu);
							}

							//그룹이 변경될 때 New로 표시한다.
							if(pre_group_ser != dloOCS2003.GetItemString(ocs2003Index, "group_ser") && mPrintLine != MAXLINE )
							{
								//							currentRowIndex = InsertPrintRow(patientIndex);
								//							//record gubun
								//							dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
								//							//prtmode
								//							dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");

							}

							//input_gubun이 변경될 때 input_gubun명을 표시한다.
							if(pre_input_gubun != dloOCS2003.GetItemString(ocs2003Index, "input_gubun"))
							{
								currentRowIndex = InsertPrintRow(patientIndex, allPrint);
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "2");
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "input_gubun"     , dloOCS2003.GetItemString(ocs2003Index, "input_gubun"     ));
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "input_gubun_name", "【"+ dloOCS2003.GetItemString(ocs2003Index, "input_gubun_name") + "】");
							}
						}

						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
					}
					else
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "2");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "input_gubun"     , dloOCS2003.GetItemString(ocs2003Index, "input_gubun"     ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "input_gubun_name", "【"+ dloOCS2003.GetItemString(ocs2003Index, "input_gubun_name") + "】");
					}

					//record gubun
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
					//prtmode
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "0");
					
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "mix_group"       , dloOCS2003.GetItemString(ocs2003Index, "mix_group"       ));
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "hangmog_code"    , dloOCS2003.GetItemString(ocs2003Index, "hangmog_code"    ));
					
					//원외, PRN, 응급, MIX여부 표시
					order_name = "";

                    // 代行
                    if (dloOCS2003.LayoutTable.Columns.Contains("instead_yn"))
                    {
                        if (dloOCS2003.GetItemString(ocs2003Index, "instead_yn") == "Y" && dloOCS2003.GetItemString(ocs2003Index, "approve_yn") == "Y")
                            order_name = order_name + "[承]";
                        else if (dloOCS2003.GetItemString(ocs2003Index, "instead_yn") == "Y" && dloOCS2003.GetItemString(ocs2003Index, "approve_yn") == "N")
                            order_name = order_name + "[代]";
                    }

                    if (dloOCS2003.GetItemString(ocs2003Index, "brought_drg_yn") == "Y")
                        order_name = order_name + "[持]";

                    //粉砕
                    if (dloOCS2003.GetItemString(ocs2003Index, "powder_yn") == "Y")
                        order_name = order_name + "[砕]";

                    //一包化
                    if (dloOCS2003.GetItemString(ocs2003Index, "drg_pack_yn") == "Y")
                        order_name = order_name + "[包]";

					//응급
					if(dloOCS2003.GetItemString(ocs2003Index, "emergency") == "Y")
                        order_name = order_name + "[急]";

					//예약
					if(dloOCS2003.GetItemString(ocs2003Index, "reser_yn") == "Y")
						order_name = order_name + "[予]";

					//PRN
					if(dloOCS2003.GetItemString(ocs2003Index, "prn_yn") == "Y")
						order_name = "[PRN]";
					
					//원외여부
					if(dloOCS2003.GetItemString(ocs2003Index, "wonyoi_order_yn") == "Y")
						order_name = order_name + "[院外]";

					//MIX
					if(!TypeCheck.IsNull(dloOCS2003.GetItemString(ocs2003Index, "mix_group")))
						order_name = order_name + "[MIX " + dloOCS2003.GetItemString(ocs2003Index, "mix_group").Trim() + "] ";
					
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "hangmog_name"    , order_name + dloOCS2003.GetItemString(ocs2003Index, "hangmog_name" ));					

					//Order 상세[수량 + 단위 + DV Time + DV]
					order_detail = dloOCS2003.GetItemString(ocs2003Index, "suryang");
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "suryang"         , order_detail);
					
					//Order 단위
					ord_danui = "";					

					if( dloOCS2003.GetItemString(ocs2003Index, "ord_danui_name") == "H" )
						ord_danui = "時間";
					else if( dloOCS2003.GetItemString(ocs2003Index, "ord_danui_name") == "L" )
						ord_danui = "ℓ/分";
					else
						ord_danui = dloOCS2003.GetItemString(ocs2003Index, "ord_danui_name");

					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "ord_danui"       , dloOCS2003.GetItemString(ocs2003Index, "ord_danui"  ));
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "ord_danui_name"  , ord_danui);

					order_detail = order_detail + ord_danui.Trim();
                    					
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "dv_time"         , dloOCS2003.GetItemString(ocs2003Index, "dv_time"    ));					
					dv = dloOCS2003.GetItemString(ocs2003Index, "dv_time").Trim() + " " + dloOCS2003.GetItemString(ocs2003Index, "dv").Trim();
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "dv"              , dv );

					order_detail = order_detail + dv;
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_detail"    , order_detail );
					
					//날수
					if( dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() != "C" &&  
						dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() != "D"  )
					{
						nalsu = "";
						if( dloOCS2003.GetItemString(ocs2003Index, "nalsu").IndexOf("D") >= 0 )
							nalsu = dloOCS2003.GetItemString(ocs2003Index, "nalsu").Trim().Replace("D", "") + "日";
						else if( dloOCS2003.GetItemString(ocs2003Index, "nalsu").IndexOf("M") >= 0 )
							nalsu = dloOCS2003.GetItemString(ocs2003Index, "nalsu").Trim().Replace("M", "") + "分";

						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "nalsu", nalsu);
					}
					
					//검체명
					if(dloOCS2003.GetItemString(ocs2003Index, "specimen_name" ).Trim() != "" && dloOCS2003.GetItemString(ocs2003Index, "specimen_name" ).Trim() != "*")
					{
						if(!TypeCheck.IsNull(dloOCS2003.GetItemString(ocs2003Index, "suryang")) && dloOCS2003.GetItemString(ocs2003Index, "suryang") != "1")
							dloOCS2003_PRINT.SetItemValue(currentRowIndex, "specimen_name", dloOCS2003.GetItemString(ocs2003Index, "specimen_name") + "     " + order_detail + "回");
						else
							dloOCS2003_PRINT.SetItemValue(currentRowIndex, "specimen_name", dloOCS2003.GetItemString(ocs2003Index, "specimen_name"));
					}

                    
					//의사회계용인 경우에는 점수명을 보여준다.
					if(allPrint && !TypeCheck.IsNull(dloOCS2003.GetItemString(ocs2003Index, "sg_code")))
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark"    , "└ [" + dloOCS2003.GetItemString(ocs2003Index, "sg_code") + "] " +dloOCS2003.GetItemString(ocs2003Index, "sg_name"));
					}

					remark = "";

					//주사
					if(( dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() == "A"  ||  
						dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() == "B"  ) && 
						dloOCS2003.GetItemString(ocs2003Index, "jusa" ).Trim() != "0" && dloOCS2003.GetItemString(ocs2003Index, "jusa_name" ).Trim() != "")
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));

						remark = " 注射 : " + dloOCS2003.GetItemString(ocs2003Index, "jusa_name" );
						if( (dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() == "A" || dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() == "B" )
							&& dloOCS2003.GetItemString(ocs2003Index, "bogyong_code" ).Trim() != "")
							remark = remark + " [速度 : " + dloOCS2003.GetItemString(ocs2003Index, "bogyong_code" ).Trim() + " ㎖/hr]";

						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
					}

					//희망일자
					if(!TypeCheck.IsNull(dloOCS2003.GetItemString(ocs2003Index, "hope_date" ).Trim())) 
					{   
						if( dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() != "C" &&  
							dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() != "D"  )
						{
							if(remark.Length == 0)
							{
								currentRowIndex = InsertPrintRow(patientIndex, allPrint);
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
								dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));
							}

							remark = remark +" 希望日 : " + dloOCS2003.GetItemString(ocs2003Index, "hope_date" );

							dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
						}
						
					}
                    
					//외용약
					if( dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() == "D" )
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));
                                
						//복용법
						remark = dloOCS2003.GetItemString(ocs2003Index, "bogyong_name" );
                                
						//투약시작일
						if(!TypeCheck.IsNull(dloOCS2003.GetItemString(ocs2003Index, "hope_date" ).Trim()))
							remark = remark + " 投薬スタート日 : " + dloOCS2003.GetItemString(ocs2003Index, "hope_date" );
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
					}


					//처치 부위
					if( dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() == "H" &&
						dloOCS2003.GetItemString(ocs2003Index, "bogyong_name" ).Trim() != "")
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));

						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark"    , dloOCS2003.GetItemString(ocs2003Index, "bogyong_name" ).Trim());
					}


					//처방 Remark
					if(dloOCS2003.GetItemString(ocs2003Index, "order_remark" ).Trim() != "")
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));

						remark = "┗ " + dloOCS2003.GetItemString(ocs2003Index, "order_remark" );
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
					}

					//간호 Remark
					if(dloOCS2003.GetItemString(ocs2003Index, "nurse_remark" ).Trim() != "")
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));

						remark = "┗ 看護 : " + dloOCS2003.GetItemString(ocs2003Index, "nurse_remark" );
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
					}

					pre_input_gubun  = dloOCS2003.GetItemString(ocs2003Index, "input_gubun" );
					pre_group_ser    = dloOCS2003.GetItemString(ocs2003Index, "group_ser"   );
					pre_bogyong_code = dloOCS2003.GetItemString(ocs2003Index, "bogyong_code");
					pre_hope_date    = dloOCS2003.GetItemString(ocs2003Index, "hope_date"   ); 
					pre_nalsu        = dloOCS2003.GetItemString(ocs2003Index, "nalsu"       );

					//if(currentRowIndex == 0) currentRowIndex++;

					//마직막 row인 경우 내복약, 외용약처리 [복용법, 투약시작일, 날수]
					if( ocs2003Index == dloOCS2003.RowCount -1 &&
						dloOCS2003.GetItemString(ocs2003Index, "order_gubun_bas" ).Trim() == "C" )
					{
						currentRowIndex = InsertPrintRow(patientIndex, allPrint);
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "record_gubun", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "prtmode", "1");
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "group_ser"       , dloOCS2003.GetItemString(ocs2003Index, "group_ser"       ));
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_gubun_name", dloOCS2003.GetItemString(ocs2003Index, "order_gubun_name"));
                                
						//복용법
						remark = dloOCS2003.GetItemString(ocs2003Index, "bogyong_name" );
                                
						//투약시작일
						if(!TypeCheck.IsNull(dloOCS2003.GetItemString(ocs2003Index, "hope_date" ).Trim()))
							remark = remark + " 投薬スタート日 : " + dloOCS2003.GetItemString(ocs2003Index, "hope_date" );
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "order_remark", remark);
                                
						nalsu = dloOCS2003.GetItemString(ocs2003Index, "nalsu").Trim().Replace("D", "") + "日";
						dloOCS2003_PRINT.SetItemValue(currentRowIndex, "nalsu", nalsu);
					}

					if(currentRowIndex == 0) currentRowIndex++;

				}

			}

			//출력에 맞게 Data를 가공한다.
			if(dloOCS2003_PRINT.RowCount > 0)
				dw_order_list.FillData(dloOCS2003_PRINT.LayoutTable);

		}

		private int InsertPrintRow(int patInfo, bool allPrint)
		{
			int currentRowIndex = dloOCS2003_PRINT.InsertRow(-1);

			if(allPrint)
				dloOCS2003_PRINT.SetItemValue(currentRowIndex, "print_gubun", "医事会計用");

			if(mInput_gubun.Substring(0, 1) == "D")
			{
				dloOCS2003_PRINT.SetItemValue(currentRowIndex, "title_gubun", "医師指示記録");
			}
			else if(mInput_gubun == "NR")
			{
				dloOCS2003_PRINT.SetItemValue(currentRowIndex, "title_gubun", "看護オーダ記録");
			}
			else if(mInput_gubun == "XX")
			{
				dloOCS2003_PRINT.SetItemValue(currentRowIndex, "title_gubun", "会計オーダ記録");
			}
			else
				dloOCS2003_PRINT.SetItemValue(currentRowIndex, "title_gubun", "部門オーダ記録");
								
				
			foreach(MultiLayoutItem item in dloPatientInfo.LayoutItems)
			{
				if(dloOCS2003_PRINT.LayoutItems.Contains(item.DataName))
					dloOCS2003_PRINT.SetItemValue(currentRowIndex, item.DataName, dloPatientInfo.GetItemString(patInfo, item.DataName));
			}

			string comment = "";
			
			dloOCS2003_PRINT.SetItemValue(currentRowIndex, "comment", comment);

			//page가 넘어갈 때 dataWindow group header line을 감안해서 2로 가져간다.
			if(dloOCS2001.RowCount > 0) mPrintLine = mPrintLine == MAXLINE ? 2 : mPrintLine + 1;

			return currentRowIndex;
		}

		#endregion

		#region [Zoom 처리]

		private void btnZoomIn_Click(object sender, System.EventArgs e)
		{			
			int zoom = int.Parse(dbxZoom.GetDataValue());
			if (zoom < 200 ) zoom = zoom + 10;
            
			dw_order_list.Modify("DataWindow.Print.Preview.Zoom= " + zoom.ToString());

			dbxZoom.SetDataValue(zoom);			
		}

		private void btnZoomOut_Click(object sender, System.EventArgs e)
		{
			int zoom = int.Parse(dbxZoom.GetDataValue());
			if (zoom > 0) zoom = zoom -10;

			dw_order_list.Modify("DataWindow.Print.Preview.Zoom= " + zoom.ToString());			
			
			dbxZoom.SetDataValue(zoom);
		}

		#endregion

		#region [출력]

		private void Print()
		{
//			XMessageBox.Show("Printing");
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                SetMsg("");

                if (dw_order_list.RowCount > 0)
                    dw_order_list.Print(true);
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "出力するデータが存在しません。 確認してください。" : "출력할 데이터가 존재하지 않습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "出力" : "출력";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

            }
            finally
            {
                SetMsg(" ");
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
		}

		#endregion
		
		#region [ButtonList Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:

					e.IsBaseCall = false;
                    
					LoadData();

					break;

				case FunctionType.Print:

					e.IsBaseCall = false;

					if(mPrintGubun == 0)
					{
						//OCS
						this.Print();
						//의사회계
						SetOrderData(true);
						this.Print();
					}
					else if(mPrintGubun == 1)
					{
						//OCS
						this.Print();
					}
					else
					{
						//의사회계
						SetOrderData(true);
						this.Print();						
					}

					SetOrderData(false);


					break;
			}
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			if(this.dw_order_list.RowCount == 0) return;

			string fileName;			

			SaveFileDialog saveFileDialogExcel = new SaveFileDialog();       
			saveFileDialogExcel.Filter = "excel files (*.xls)|*.xls";
			saveFileDialogExcel.FilterIndex = 1;
			saveFileDialogExcel.RestoreDirectory = true ;
			saveFileDialogExcel.OverwritePrompt  = false ;

			if(saveFileDialogExcel.ShowDialog() == DialogResult.OK)
			{   
				fileName = saveFileDialogExcel.FileName;				
			}
			else
			{
				return;
			}
			
			dw_order_list.SaveAsFormattedText(fileName,"\t","","\r\n", true, Sybase.DataWindow.FileSaveAsEncoding.Ansi);	
		}
		#endregion
		
		#region [Control]

		private void rbtPrint_Click(object sender, System.EventArgs e)
		{
			if(rbtALL.Checked)
			{
				rbtALL.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);				
				rbtALL.Font = new Font(rbtALL.Font.FontFamily, rbtALL.Font.Size, FontStyle.Bold);
				rbtALL.ImageIndex = 1;

				rbtOCS.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtOCS.Font = new Font(rbtOCS.Font.FontFamily, rbtOCS.Font.Size);
				rbtOCS.ImageIndex = 0;
  
				rbtOUT.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtOUT.Font = new Font(rbtOUT.Font.FontFamily, rbtOUT.Font.Size);
				rbtOUT.ImageIndex = 0;

				mPrintGubun = 0;

			}
			else if(rbtOCS.Checked)
			{
				rbtOCS.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);				
				rbtOCS.Font = new Font(rbtOCS.Font.FontFamily, rbtOCS.Font.Size, FontStyle.Bold);
				rbtOCS.ImageIndex = 1;

				rbtALL.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtALL.Font = new Font(rbtALL.Font.FontFamily, rbtALL.Font.Size);
				rbtALL.ImageIndex = 0;
  
				rbtOUT.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtOUT.Font = new Font(rbtOUT.Font.FontFamily, rbtOUT.Font.Size);
				rbtOUT.ImageIndex = 0;

				mPrintGubun = 1;
			
			}	
			else 
			{
				rbtOUT.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);				
				rbtOUT.Font = new Font(rbtOUT.Font.FontFamily, rbtOUT.Font.Size, FontStyle.Bold);
				rbtOUT.ImageIndex = 1;

				rbtALL.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtALL.Font = new Font(rbtALL.Font.FontFamily, rbtALL.Font.Size);
				rbtALL.ImageIndex = 0;
  
				rbtOCS.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtOCS.Font = new Font(rbtOCS.Font.FontFamily, rbtOCS.Font.Size);
				rbtOCS.ImageIndex = 0;
			
				mPrintGubun = 2;
			}	
		}

		#endregion

		private void dloPatientInfo_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.dloPatientInfo.SetBindVarValue("f_bunho"      , mBunho      );
			this.dloPatientInfo.SetBindVarValue("f_fkinp1001"  , mFkinp1001.ToString()  );
			this.dloPatientInfo.SetBindVarValue("f_order_date" , mOrder_date );
			this.dloPatientInfo.SetBindVarValue("f_input_gubun", mInput_gubun);
			this.dloPatientInfo.SetBindVarValue("f_doctor"     , mDoctor     );
			this.dloPatientInfo.SetBindVarValue("f_gwa"        , mGwa        );
            this.dloPatientInfo.SetBindVarValue("f_hosp_code"  , EnvironInfo.HospCode);
			
		}

		private void dloOCS2001_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.dloOCS2001.SetBindVarValue("f_bunho"      , mBunho      );
			this.dloOCS2001.SetBindVarValue("f_fkinp1001"  , mFkinp1001.ToString()  );
			this.dloOCS2001.SetBindVarValue("f_gwa"        , mGwa        );
            this.dloOCS2001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
		}

		private void dloOCS2003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.dloOCS2003.SetBindVarValue("f_bunho"      , mBunho      );
			this.dloOCS2003.SetBindVarValue("f_fkinp1001"  , mFkinp1001.ToString()  );
			this.dloOCS2003.SetBindVarValue("f_order_date" , mOrder_date );
			this.dloOCS2003.SetBindVarValue("f_input_gubun", mInput_gubun);
			this.dloOCS2003.SetBindVarValue("f_doctor"     , mDoctor     );
			this.dloOCS2003.SetBindVarValue("f_gwa"        , mGwa        );
            this.dloOCS2003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
		}

		
	}
}

