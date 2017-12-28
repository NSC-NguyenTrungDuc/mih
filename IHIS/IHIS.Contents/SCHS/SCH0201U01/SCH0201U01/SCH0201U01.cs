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
#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0201U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201U01 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XDatePicker dtDate;
		private IHIS.Framework.XButton btPostDate;
		private IHIS.Framework.XButton btPreDate;
		private IHIS.Framework.XPatientBox paBoxPatient;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XDataWindow dwReserList;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XDataWindow dwReserAMList;
		private IHIS.Framework.XDataWindow dwReserPMList;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XLabel lbReserTime;
		private IHIS.Framework.XLabel lbReserDate;
		private IHIS.Framework.XTextBox txtTime;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnSave;
		private IHIS.Framework.XTextBox txtKey;
		private IHIS.Framework.XTextBox txtJundalTable;
		private IHIS.Framework.XDatePicker dtReserDate;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XButton xbtnHangmog;
		private IHIS.Framework.XTextBox txtHangmog;
		private IHIS.Framework.XLabel lbHangmogName;
		private IHIS.Framework.SingleLayout layHoliYN;
		private IHIS.Framework.XTextBox txtSuname;
		private IHIS.Framework.MultiLayout layReserList;
		private IHIS.Framework.XTextBox txtHangmogCode;
		private System.Windows.Forms.RadioButton rb_1;
		private System.Windows.Forms.RadioButton rb_2;
		private System.Windows.Forms.RadioButton rb_3;
		private System.Windows.Forms.RadioButton rb_4;
		private System.Windows.Forms.RadioButton rb_5;
		private System.Windows.Forms.RadioButton rb_６;
		private IHIS.Framework.SingleLayout layReserChk;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XTextBox txtComment;
		private IHIS.Framework.XLabel xlbHangmogCode;
		private IHIS.Framework.XPanel xpnXRTComment;
		private IHIS.Framework.MultiLayout layTimeList;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XFindBox fbxSogaeHop;
		private IHIS.Framework.XFindWorker fwHosp_name;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.XButton btnEtcOrder;
		private IHIS.Framework.XButton btnXrtOrder;
		private IHIS.Framework.XButton btnLabOrder;
		private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XButton btnClose;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private MultiLayout layLoadRES0101;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private MultiLayoutItem multiLayoutItem73;
        private MultiLayoutItem multiLayoutItem74;
        private MultiLayoutItem multiLayoutItem75;
        private MultiLayoutItem multiLayoutItem76;
        private MultiLayoutItem multiLayoutItem77;
        private MultiLayoutItem multiLayoutItem78;
        private MultiLayoutItem multiLayoutItem79;
        private MultiLayoutItem multiLayoutItem80;
        private MultiLayoutItem multiLayoutItem81;
        private MultiLayoutItem multiLayoutItem82;
        private MultiLayoutItem multiLayoutItem83;
        private MultiLayoutItem multiLayoutItem84;
        private MultiLayoutItem multiLayoutItem85;
        private MultiLayoutItem multiLayoutItem86;
        private MultiLayoutItem multiLayoutItem87;
        private MultiLayoutItem multiLayoutItem88;
        private MultiLayoutItem multiLayoutItem89;
        private MultiLayoutItem multiLayoutItem90;
        private MultiLayoutItem multiLayoutItem91;
        private MultiLayoutItem multiLayoutItem92;
        private MultiLayoutItem multiLayoutItem93;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayout layLoadReser;
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
        private MultiLayoutItem multiLayoutItem131;
        private MultiLayoutItem multiLayoutItem132;
        private MultiLayoutItem multiLayoutItem133;
        private MultiLayoutItem multiLayoutItem134;
        private MultiLayoutItem multiLayoutItem135;
        private MultiLayoutItem multiLayoutItem136;
        private MultiLayoutItem multiLayoutItem137;
        private MultiLayoutItem multiLayoutItem138;
        private MultiLayoutItem multiLayoutItem139;
        private MultiLayoutItem multiLayoutItem140;
        private MultiLayoutItem multiLayoutItem141;
        private MultiLayoutItem multiLayoutItem142;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private XLabel xLabel5;
        private XLabel xLabel4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public SCH0201U01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201U01));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.lbHangmogName = new IHIS.Framework.XLabel();
            this.btnEtcOrder = new IHIS.Framework.XButton();
            this.btnXrtOrder = new IHIS.Framework.XButton();
            this.btnLabOrder = new IHIS.Framework.XButton();
            this.xpnXRTComment = new IHIS.Framework.XPanel();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_3 = new System.Windows.Forms.RadioButton();
            this.rb_4 = new System.Windows.Forms.RadioButton();
            this.fbxSogaeHop = new IHIS.Framework.XFindBox();
            this.fwHosp_name = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.rb_5 = new System.Windows.Forms.RadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.rb_６ = new System.Windows.Forms.RadioButton();
            this.txtSuname = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xbtnHangmog = new IHIS.Framework.XButton();
            this.txtHangmog = new IHIS.Framework.XTextBox();
            this.xlbHangmogCode = new IHIS.Framework.XLabel();
            this.dtDate = new IHIS.Framework.XDatePicker();
            this.btPostDate = new IHIS.Framework.XButton();
            this.btPreDate = new IHIS.Framework.XButton();
            this.paBoxPatient = new IHIS.Framework.XPatientBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.dwReserList = new IHIS.Framework.XDataWindow();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.dwReserAMList = new IHIS.Framework.XDataWindow();
            this.dwReserPMList = new IHIS.Framework.XDataWindow();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.btnClose = new IHIS.Framework.XButton();
            this.txtComment = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtHangmogCode = new IHIS.Framework.XTextBox();
            this.lbReserTime = new IHIS.Framework.XLabel();
            this.lbReserDate = new IHIS.Framework.XLabel();
            this.txtTime = new IHIS.Framework.XTextBox();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnSave = new IHIS.Framework.XButton();
            this.txtKey = new IHIS.Framework.XTextBox();
            this.txtJundalTable = new IHIS.Framework.XTextBox();
            this.dtReserDate = new IHIS.Framework.XDatePicker();
            this.layReserList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
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
            this.layHoliYN = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.layReserChk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layTimeList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layLoadRES0101 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layLoadReser = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem131 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem132 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem133 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem134 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem135 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem136 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem137 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem138 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem139 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem140 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem141 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem142 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2.SuspendLayout();
            this.xpnXRTComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBoxPatient)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoadRES0101)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoadReser)).BeginInit();
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
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.lbHangmogName);
            this.xPanel2.Controls.Add(this.btnEtcOrder);
            this.xPanel2.Controls.Add(this.btnXrtOrder);
            this.xPanel2.Controls.Add(this.btnLabOrder);
            this.xPanel2.Controls.Add(this.xpnXRTComment);
            this.xPanel2.Controls.Add(this.txtSuname);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.xbtnHangmog);
            this.xPanel2.Controls.Add(this.txtHangmog);
            this.xPanel2.Controls.Add(this.xlbHangmogCode);
            this.xPanel2.Controls.Add(this.dtDate);
            this.xPanel2.Controls.Add(this.btPostDate);
            this.xPanel2.Controls.Add(this.btPreDate);
            this.xPanel2.Controls.Add(this.paBoxPatient);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 5);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(1285, 67);
            this.xPanel2.TabIndex = 11;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Location = new System.Drawing.Point(7, 40);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(65, 20);
            this.xLabel5.TabIndex = 45;
            this.xLabel5.Text = "項目コード";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Location = new System.Drawing.Point(7, 11);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(65, 20);
            this.xLabel4.TabIndex = 23;
            this.xLabel4.Text = "患者番号";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHangmogName
            // 
            this.lbHangmogName.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbHangmogName.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Brown);
            this.lbHangmogName.Location = new System.Drawing.Point(184, 40);
            this.lbHangmogName.Name = "lbHangmogName";
            this.lbHangmogName.Size = new System.Drawing.Size(299, 21);
            this.lbHangmogName.TabIndex = 11;
            // 
            // btnEtcOrder
            // 
            this.btnEtcOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEtcOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnEtcOrder.Image")));
            this.btnEtcOrder.Location = new System.Drawing.Point(315, 11);
            this.btnEtcOrder.Name = "btnEtcOrder";
            this.btnEtcOrder.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnEtcOrder.Size = new System.Drawing.Size(60, 21);
            this.btnEtcOrder.TabIndex = 44;
            this.btnEtcOrder.Text = "生体";
            this.btnEtcOrder.Visible = false;
            this.btnEtcOrder.Click += new System.EventHandler(this.btnEtcOrder_Click);
            // 
            // btnXrtOrder
            // 
            this.btnXrtOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXrtOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnXrtOrder.Image")));
            this.btnXrtOrder.Location = new System.Drawing.Point(179, 11);
            this.btnXrtOrder.Name = "btnXrtOrder";
            this.btnXrtOrder.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnXrtOrder.Size = new System.Drawing.Size(69, 21);
            this.btnXrtOrder.TabIndex = 42;
            this.btnXrtOrder.Text = "放射線";
            this.btnXrtOrder.Visible = false;
            this.btnXrtOrder.Click += new System.EventHandler(this.btnXrtOrder_Click);
            // 
            // btnLabOrder
            // 
            this.btnLabOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnLabOrder.Image")));
            this.btnLabOrder.Location = new System.Drawing.Point(247, 11);
            this.btnLabOrder.Name = "btnLabOrder";
            this.btnLabOrder.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnLabOrder.Size = new System.Drawing.Size(69, 21);
            this.btnLabOrder.TabIndex = 43;
            this.btnLabOrder.Text = "検体";
            this.btnLabOrder.Visible = false;
            this.btnLabOrder.Click += new System.EventHandler(this.btnLabOrder_Click);
            // 
            // xpnXRTComment
            // 
            this.xpnXRTComment.Controls.Add(this.rb_1);
            this.xpnXRTComment.Controls.Add(this.rb_2);
            this.xpnXRTComment.Controls.Add(this.rb_3);
            this.xpnXRTComment.Controls.Add(this.rb_4);
            this.xpnXRTComment.Controls.Add(this.fbxSogaeHop);
            this.xpnXRTComment.Controls.Add(this.rb_5);
            this.xpnXRTComment.Controls.Add(this.xLabel1);
            this.xpnXRTComment.Controls.Add(this.rb_６);
            this.xpnXRTComment.Location = new System.Drawing.Point(849, 33);
            this.xpnXRTComment.Name = "xpnXRTComment";
            this.xpnXRTComment.Size = new System.Drawing.Size(278, 30);
            this.xpnXRTComment.TabIndex = 20;
            // 
            // rb_1
            // 
            this.rb_1.Checked = true;
            this.rb_1.ForeColor = System.Drawing.Color.Blue;
            this.rb_1.Location = new System.Drawing.Point(0, 40);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(80, 17);
            this.rb_1.TabIndex = 14;
            this.rb_1.TabStop = true;
            this.rb_1.Text = "海村病院";
            this.rb_1.Visible = false;
            // 
            // rb_2
            // 
            this.rb_2.ForeColor = System.Drawing.Color.Blue;
            this.rb_2.Location = new System.Drawing.Point(80, 40);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(80, 17);
            this.rb_2.TabIndex = 15;
            this.rb_2.Text = "永木病院";
            this.rb_2.Visible = false;
            // 
            // rb_3
            // 
            this.rb_3.ForeColor = System.Drawing.Color.Blue;
            this.rb_3.Location = new System.Drawing.Point(160, 40);
            this.rb_3.Name = "rb_3";
            this.rb_3.Size = new System.Drawing.Size(80, 17);
            this.rb_3.TabIndex = 16;
            this.rb_3.Text = "飯倉病院";
            this.rb_3.Visible = false;
            // 
            // rb_4
            // 
            this.rb_4.ForeColor = System.Drawing.Color.Blue;
            this.rb_4.Location = new System.Drawing.Point(240, 40);
            this.rb_4.Name = "rb_4";
            this.rb_4.Size = new System.Drawing.Size(80, 17);
            this.rb_4.TabIndex = 17;
            this.rb_4.Text = "三技整形";
            this.rb_4.Visible = false;
            // 
            // fbxSogaeHop
            // 
            this.fbxSogaeHop.FindWorker = this.fwHosp_name;
            this.fbxSogaeHop.Location = new System.Drawing.Point(78, 5);
            this.fbxSogaeHop.Name = "fbxSogaeHop";
            this.fbxSogaeHop.Size = new System.Drawing.Size(192, 20);
            this.fbxSogaeHop.TabIndex = 22;
            // 
            // fwHosp_name
            // 
            this.fwHosp_name.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1});
            this.fwHosp_name.InputSQL = "SELECT CODE_NAME\r\n  FROM SCH0109 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_T" +
                "YPE = \'LINKED_HOSPITAL\'\r\n   AND CODE_NAME LIKE \'%\'||:f_find1||\'%\'\r\n ORDER BY 1";
            this.fwHosp_name.IsSetControlText = true;
            this.fwHosp_name.ServerFilter = true;
            this.fwHosp_name.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwHosp_name_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hosp_name";
            this.findColumnInfo1.ColWidth = 344;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "病院名";
            // 
            // rb_5
            // 
            this.rb_5.ForeColor = System.Drawing.Color.Blue;
            this.rb_5.Location = new System.Drawing.Point(320, 40);
            this.rb_5.Name = "rb_5";
            this.rb_5.Size = new System.Drawing.Size(72, 17);
            this.rb_5.TabIndex = 18;
            this.rb_5.Text = "旭中央";
            this.rb_5.Visible = false;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(7, 5);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(71, 20);
            this.xLabel1.TabIndex = 21;
            this.xLabel1.Text = "紹介病院";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rb_６
            // 
            this.rb_６.ForeColor = System.Drawing.Color.Blue;
            this.rb_６.Location = new System.Drawing.Point(392, 40);
            this.rb_６.Name = "rb_６";
            this.rb_６.Size = new System.Drawing.Size(64, 17);
            this.rb_６.TabIndex = 19;
            this.rb_６.Text = "その他";
            this.rb_６.Visible = false;
            // 
            // txtSuname
            // 
            this.txtSuname.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuname.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.txtSuname.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtSuname.Location = new System.Drawing.Point(1086, 7);
            this.txtSuname.MaxLength = 30;
            this.txtSuname.Name = "txtSuname";
            this.txtSuname.Size = new System.Drawing.Size(189, 26);
            this.txtSuname.TabIndex = 13;
            this.txtSuname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSuname_KeyPress);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(990, 7);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(96, 26);
            this.xLabel3.TabIndex = 12;
            this.xLabel3.Text = "患者氏名(漢字)";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xbtnHangmog
            // 
            this.xbtnHangmog.ImageIndex = 4;
            this.xbtnHangmog.ImageList = this.ImageList;
            this.xbtnHangmog.Location = new System.Drawing.Point(153, 40);
            this.xbtnHangmog.Name = "xbtnHangmog";
            this.xbtnHangmog.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.xbtnHangmog.Size = new System.Drawing.Size(27, 21);
            this.xbtnHangmog.TabIndex = 10;
            this.xbtnHangmog.Click += new System.EventHandler(this.xbtnHangmog_Click);
            // 
            // txtHangmog
            // 
            this.txtHangmog.Location = new System.Drawing.Point(72, 40);
            this.txtHangmog.Name = "txtHangmog";
            this.txtHangmog.Size = new System.Drawing.Size(81, 20);
            this.txtHangmog.TabIndex = 9;
            this.txtHangmog.TextChanged += new System.EventHandler(this.txtHangmog_TextChanged);
            // 
            // xlbHangmogCode
            // 
            this.xlbHangmogCode.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xlbHangmogCode.Location = new System.Drawing.Point(7, 40);
            this.xlbHangmogCode.Name = "xlbHangmogCode";
            this.xlbHangmogCode.Size = new System.Drawing.Size(64, 21);
            this.xlbHangmogCode.TabIndex = 8;
            this.xlbHangmogCode.Text = "項目コード";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(1126, 39);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(104, 20);
            this.dtDate.TabIndex = 7;
            this.dtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtDate_DataValidating);
            // 
            // btPostDate
            // 
            this.btPostDate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPostDate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btPostDate.ImageIndex = 0;
            this.btPostDate.ImageList = this.ImageList;
            this.btPostDate.Location = new System.Drawing.Point(1230, 38);
            this.btPostDate.Name = "btPostDate";
            this.btPostDate.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btPostDate.Size = new System.Drawing.Size(24, 22);
            this.btPostDate.TabIndex = 6;
            this.btPostDate.Click += new System.EventHandler(this.btPostDate_Click);
            // 
            // btPreDate
            // 
            this.btPreDate.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreDate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btPreDate.ImageIndex = 1;
            this.btPreDate.ImageList = this.ImageList;
            this.btPreDate.Location = new System.Drawing.Point(1254, 38);
            this.btPreDate.Name = "btPreDate";
            this.btPreDate.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btPreDate.Size = new System.Drawing.Size(24, 22);
            this.btPreDate.TabIndex = 5;
            this.btPreDate.Click += new System.EventHandler(this.btPreDate_Click);
            // 
            // paBoxPatient
            // 
            this.paBoxPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.paBoxPatient.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBoxPatient.Location = new System.Drawing.Point(2, 4);
            this.paBoxPatient.Name = "paBoxPatient";
            this.paBoxPatient.Padding = new System.Windows.Forms.Padding(0, 7, 0, 6);
            this.paBoxPatient.ShowBoxImage = false;
            this.paBoxPatient.Size = new System.Drawing.Size(650, 33);
            this.paBoxPatient.TabIndex = 3;
            this.paBoxPatient.PatientSelected += new System.EventHandler(this.paBoxPatient_PatientSelected);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.dwReserList);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(5, 72);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel3.Size = new System.Drawing.Size(1285, 256);
            this.xPanel3.TabIndex = 12;
            // 
            // dwReserList
            // 
            this.dwReserList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserList.DataWindowObject = "d_reser_list";
            this.dwReserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwReserList.LibraryList = "..\\SCHS\\schs.sch0201u01.pbd";
            this.dwReserList.Location = new System.Drawing.Point(2, 2);
            this.dwReserList.Name = "dwReserList";
            this.dwReserList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserList.Size = new System.Drawing.Size(1279, 250);
            this.dwReserList.TabIndex = 0;
            this.dwReserList.Text = "xDataWindow1";
            this.dwReserList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserList_RowFocusChanged);
            this.dwReserList.Click += new System.EventHandler(this.dwReserList_Click);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.dwReserAMList);
            this.xPanel4.Controls.Add(this.dwReserPMList);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(5, 328);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel4.Size = new System.Drawing.Size(1285, 407);
            this.xPanel4.TabIndex = 13;
            // 
            // dwReserAMList
            // 
            this.dwReserAMList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserAMList.DataWindowObject = "d_reser_time_list";
            this.dwReserAMList.Dock = System.Windows.Forms.DockStyle.Left;
            this.dwReserAMList.LibraryList = "..\\SCHS\\schs.sch0201u01.pbd";
            this.dwReserAMList.Location = new System.Drawing.Point(2, 2);
            this.dwReserAMList.Name = "dwReserAMList";
            this.dwReserAMList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserAMList.Size = new System.Drawing.Size(638, 401);
            this.dwReserAMList.TabIndex = 9;
            this.dwReserAMList.Text = "xDataWindow2";
            this.dwReserAMList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserAMList_RowFocusChanged);
            this.dwReserAMList.Click += new System.EventHandler(this.dwReserAMList_Click);
            // 
            // dwReserPMList
            // 
            this.dwReserPMList.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwReserPMList.DataWindowObject = "d_reser_time_list";
            this.dwReserPMList.Dock = System.Windows.Forms.DockStyle.Right;
            this.dwReserPMList.LibraryList = "..\\SCHS\\schs.sch0201u01.pbd";
            this.dwReserPMList.Location = new System.Drawing.Point(643, 2);
            this.dwReserPMList.Name = "dwReserPMList";
            this.dwReserPMList.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwReserPMList.Size = new System.Drawing.Size(638, 401);
            this.dwReserPMList.TabIndex = 10;
            this.dwReserPMList.Text = "xDataWindow3";
            this.dwReserPMList.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwReserPMList_RowFocusChanged);
            this.dwReserPMList.Click += new System.EventHandler(this.dwReserPMList_Click);
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.btnClose);
            this.xPanel5.Controls.Add(this.txtComment);
            this.xPanel5.Controls.Add(this.xLabel2);
            this.xPanel5.Controls.Add(this.txtHangmogCode);
            this.xPanel5.Controls.Add(this.lbReserTime);
            this.xPanel5.Controls.Add(this.lbReserDate);
            this.xPanel5.Controls.Add(this.txtTime);
            this.xPanel5.Controls.Add(this.btnCancel);
            this.xPanel5.Controls.Add(this.btnSave);
            this.xPanel5.Controls.Add(this.txtKey);
            this.xPanel5.Controls.Add(this.txtJundalTable);
            this.xPanel5.Controls.Add(this.dtReserDate);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Location = new System.Drawing.Point(5, 735);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel5.Size = new System.Drawing.Size(1285, 40);
            this.xPanel5.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = 5;
            this.btnClose.ImageList = this.ImageList;
            this.btnClose.Location = new System.Drawing.Point(1199, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 28);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.txtComment.Location = new System.Drawing.Point(557, 9);
            this.txtComment.MaxLength = 500;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(454, 21);
            this.txtComment.TabIndex = 19;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(493, 9);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(64, 21);
            this.xLabel2.TabIndex = 18;
            this.xLabel2.Text = "コメント";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHangmogCode
            // 
            this.txtHangmogCode.Location = new System.Drawing.Point(6, 104);
            this.txtHangmogCode.Name = "txtHangmogCode";
            this.txtHangmogCode.Size = new System.Drawing.Size(100, 20);
            this.txtHangmogCode.TabIndex = 17;
            this.txtHangmogCode.Visible = false;
            // 
            // lbReserTime
            // 
            this.lbReserTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserTime.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserTime.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.lbReserTime.Location = new System.Drawing.Point(160, 3);
            this.lbReserTime.Name = "lbReserTime";
            this.lbReserTime.Size = new System.Drawing.Size(80, 32);
            this.lbReserTime.TabIndex = 16;
            // 
            // lbReserDate
            // 
            this.lbReserDate.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbReserDate.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReserDate.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.lbReserDate.Location = new System.Drawing.Point(4, 3);
            this.lbReserDate.Name = "lbReserDate";
            this.lbReserDate.Size = new System.Drawing.Size(155, 32);
            this.lbReserDate.TabIndex = 15;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(110, 80);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(64, 20);
            this.txtTime.TabIndex = 14;
            this.txtTime.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageIndex = 3;
            this.btnCancel.ImageList = this.ImageList;
            this.btnCancel.Location = new System.Drawing.Point(1022, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCancel.Size = new System.Drawing.Size(96, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "予約取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.ImageList;
            this.btnSave.Location = new System.Drawing.Point(1119, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 28);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "予約";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(278, 80);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(100, 20);
            this.txtKey.TabIndex = 11;
            this.txtKey.Visible = false;
            // 
            // txtJundalTable
            // 
            this.txtJundalTable.Location = new System.Drawing.Point(182, 80);
            this.txtJundalTable.Name = "txtJundalTable";
            this.txtJundalTable.Size = new System.Drawing.Size(88, 20);
            this.txtJundalTable.TabIndex = 10;
            this.txtJundalTable.Visible = false;
            // 
            // dtReserDate
            // 
            this.dtReserDate.Location = new System.Drawing.Point(6, 80);
            this.dtReserDate.Name = "dtReserDate";
            this.dtReserDate.ReadOnly = true;
            this.dtReserDate.Size = new System.Drawing.Size(104, 20);
            this.dtReserDate.TabIndex = 8;
            this.dtReserDate.TabStop = false;
            this.dtReserDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtReserDate.Visible = false;
            // 
            // layReserList
            // 
            this.layReserList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
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
            this.multiLayoutItem93});
            this.layReserList.QuerySQL = resources.GetString("layReserList.QuerySQL");
            this.layReserList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layReserList_QueryEnd);
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "hangmog_code";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "hangmog_name";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "reser_date";
            this.multiLayoutItem46.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "reser_time";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "day_1";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "day_2";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "day_3";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "day_4";
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "day_5";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "day_6";
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "day_7";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "day_8";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "day_9";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "day_10";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "day_11";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "day_12";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "day_13";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "day_14";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "day_15";
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "day_16";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "day_17";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "day_18";
            // 
            // multiLayoutItem73
            // 
            this.multiLayoutItem73.DataName = "day_19";
            // 
            // multiLayoutItem74
            // 
            this.multiLayoutItem74.DataName = "day_20";
            // 
            // multiLayoutItem75
            // 
            this.multiLayoutItem75.DataName = "day_21";
            // 
            // multiLayoutItem76
            // 
            this.multiLayoutItem76.DataName = "day_22";
            // 
            // multiLayoutItem77
            // 
            this.multiLayoutItem77.DataName = "day_23";
            // 
            // multiLayoutItem78
            // 
            this.multiLayoutItem78.DataName = "day_24";
            // 
            // multiLayoutItem79
            // 
            this.multiLayoutItem79.DataName = "day_25";
            // 
            // multiLayoutItem80
            // 
            this.multiLayoutItem80.DataName = "day_26";
            // 
            // multiLayoutItem81
            // 
            this.multiLayoutItem81.DataName = "day_27";
            // 
            // multiLayoutItem82
            // 
            this.multiLayoutItem82.DataName = "day_28";
            // 
            // multiLayoutItem83
            // 
            this.multiLayoutItem83.DataName = "day_29";
            // 
            // multiLayoutItem84
            // 
            this.multiLayoutItem84.DataName = "day_30";
            // 
            // multiLayoutItem85
            // 
            this.multiLayoutItem85.DataName = "day_31";
            // 
            // multiLayoutItem86
            // 
            this.multiLayoutItem86.DataName = "jundal_table";
            // 
            // multiLayoutItem87
            // 
            this.multiLayoutItem87.DataName = "jundal_part";
            // 
            // multiLayoutItem88
            // 
            this.multiLayoutItem88.DataName = "key";
            this.multiLayoutItem88.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem89
            // 
            this.multiLayoutItem89.DataName = "reser_yn";
            // 
            // multiLayoutItem90
            // 
            this.multiLayoutItem90.DataName = "reser_gumsa_yn";
            // 
            // multiLayoutItem91
            // 
            this.multiLayoutItem91.DataName = "gwa_name";
            // 
            // multiLayoutItem92
            // 
            this.multiLayoutItem92.DataName = "gwa";
            // 
            // multiLayoutItem93
            // 
            this.multiLayoutItem93.DataName = "time_yn";
            // 
            // layHoliYN
            // 
            this.layHoliYN.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            this.layHoliYN.QuerySQL = "SELECT DECODE(A.HOLIDAY_YN,\'N\',\'N\',\'Y\')\r\n     , A.YOIL_GUBUN\r\n  FROM RES0101 A\r\n " +
                "WHERE A.HOSP_CODE = :f_hosp_code\r\n   AND A.HOLI_DAY  = TO_DATE(:f_date,\'yyyymmdd" +
                "\')";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "holi_yn";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "yoil_gubun";
            // 
            // layReserChk
            // 
            this.layReserChk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "reser_chk";
            // 
            // layTimeList
            // 
            this.layTimeList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24});
            this.layTimeList.QuerySQL = resources.GetString("layTimeList.QuerySQL");
            this.layTimeList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTimeList_QueryStarting);
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "reser_date";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "reser_time";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "bunho";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "suname";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "hangmog_code";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "hangmog_name";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "gwa";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "doctor_name";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "act_yn";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(5, 328);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1285, 3);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // layLoadRES0101
            // 
            this.layLoadRES0101.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layLoadRES0101.QuerySQL = resources.GetString("layLoadRES0101.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "holi_day";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "last_day";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "yoil_gubun";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "day";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "day_gubun";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "cnt";
            // 
            // layLoadReser
            // 
            this.layLoadReser.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem131,
            this.multiLayoutItem132,
            this.multiLayoutItem133,
            this.multiLayoutItem134,
            this.multiLayoutItem135,
            this.multiLayoutItem136,
            this.multiLayoutItem137,
            this.multiLayoutItem138,
            this.multiLayoutItem139,
            this.multiLayoutItem140,
            this.multiLayoutItem141,
            this.multiLayoutItem142});
            this.layLoadReser.QuerySQL = resources.GetString("layLoadReser.QuerySQL");
            // 
            // multiLayoutItem100
            // 
            this.multiLayoutItem100.DataName = "hangmog_code";
            // 
            // multiLayoutItem101
            // 
            this.multiLayoutItem101.DataName = "hangmog_name";
            // 
            // multiLayoutItem102
            // 
            this.multiLayoutItem102.DataName = "reser_date";
            this.multiLayoutItem102.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem103
            // 
            this.multiLayoutItem103.DataName = "reser_time";
            // 
            // multiLayoutItem104
            // 
            this.multiLayoutItem104.DataName = "day_1";
            // 
            // multiLayoutItem105
            // 
            this.multiLayoutItem105.DataName = "day_2";
            // 
            // multiLayoutItem106
            // 
            this.multiLayoutItem106.DataName = "day_3";
            // 
            // multiLayoutItem107
            // 
            this.multiLayoutItem107.DataName = "day_4";
            // 
            // multiLayoutItem108
            // 
            this.multiLayoutItem108.DataName = "day_5";
            // 
            // multiLayoutItem109
            // 
            this.multiLayoutItem109.DataName = "day_6";
            // 
            // multiLayoutItem110
            // 
            this.multiLayoutItem110.DataName = "day_7";
            // 
            // multiLayoutItem111
            // 
            this.multiLayoutItem111.DataName = "day_8";
            // 
            // multiLayoutItem112
            // 
            this.multiLayoutItem112.DataName = "day_9";
            // 
            // multiLayoutItem113
            // 
            this.multiLayoutItem113.DataName = "day_10";
            // 
            // multiLayoutItem114
            // 
            this.multiLayoutItem114.DataName = "day_11";
            // 
            // multiLayoutItem115
            // 
            this.multiLayoutItem115.DataName = "day_12";
            // 
            // multiLayoutItem116
            // 
            this.multiLayoutItem116.DataName = "day_13";
            // 
            // multiLayoutItem117
            // 
            this.multiLayoutItem117.DataName = "day_14";
            // 
            // multiLayoutItem118
            // 
            this.multiLayoutItem118.DataName = "day_15";
            // 
            // multiLayoutItem119
            // 
            this.multiLayoutItem119.DataName = "day_16";
            // 
            // multiLayoutItem120
            // 
            this.multiLayoutItem120.DataName = "day_17";
            // 
            // multiLayoutItem121
            // 
            this.multiLayoutItem121.DataName = "day_18";
            // 
            // multiLayoutItem122
            // 
            this.multiLayoutItem122.DataName = "day_19";
            // 
            // multiLayoutItem123
            // 
            this.multiLayoutItem123.DataName = "day_20";
            // 
            // multiLayoutItem124
            // 
            this.multiLayoutItem124.DataName = "day_21";
            // 
            // multiLayoutItem125
            // 
            this.multiLayoutItem125.DataName = "day_22";
            // 
            // multiLayoutItem126
            // 
            this.multiLayoutItem126.DataName = "day_23";
            // 
            // multiLayoutItem127
            // 
            this.multiLayoutItem127.DataName = "day_24";
            // 
            // multiLayoutItem128
            // 
            this.multiLayoutItem128.DataName = "day_25";
            // 
            // multiLayoutItem129
            // 
            this.multiLayoutItem129.DataName = "day_26";
            // 
            // multiLayoutItem130
            // 
            this.multiLayoutItem130.DataName = "day_27";
            // 
            // multiLayoutItem131
            // 
            this.multiLayoutItem131.DataName = "day_28";
            // 
            // multiLayoutItem132
            // 
            this.multiLayoutItem132.DataName = "day_29";
            // 
            // multiLayoutItem133
            // 
            this.multiLayoutItem133.DataName = "day_30";
            // 
            // multiLayoutItem134
            // 
            this.multiLayoutItem134.DataName = "day_31";
            // 
            // multiLayoutItem135
            // 
            this.multiLayoutItem135.DataName = "jundal_table";
            // 
            // multiLayoutItem136
            // 
            this.multiLayoutItem136.DataName = "jundal_part";
            // 
            // multiLayoutItem137
            // 
            this.multiLayoutItem137.DataName = "key";
            this.multiLayoutItem137.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem138
            // 
            this.multiLayoutItem138.DataName = "reser_yn";
            // 
            // multiLayoutItem139
            // 
            this.multiLayoutItem139.DataName = "reser_gumsa_yn";
            // 
            // multiLayoutItem140
            // 
            this.multiLayoutItem140.DataName = "gwa_name";
            // 
            // multiLayoutItem141
            // 
            this.multiLayoutItem141.DataName = "gwa";
            // 
            // multiLayoutItem142
            // 
            this.multiLayoutItem142.DataName = "time_yn";
            // 
            // SCH0201U01
            // 
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "SCH0201U01";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1295, 780);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.xpnXRTComment.ResumeLayout(false);
            this.xpnXRTComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBoxPatient)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoadRES0101)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLoadReser)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			dtDate.SetDataValue(DateTime.Now);

			if (IHIS.Framework.EnvironInfo.CurrSystemID == "HPCS")
			{
				xpnXRTComment.Visible = false;
				txtComment.Text = "検診";
			}
			else
				xpnXRTComment.Visible = true;
		}
		#endregion

        #region 오더 조회 창 오픈
        private void xbtnHangmog_Click(object sender, System.EventArgs e)
		{
			CommonItemCollection openParams  = new CommonItemCollection();
			//값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
			openParams.Add("hangmog_code", this.txtHangmog.GetDataValue().ToString());
			// Multi 선택여부 (default : MultiSelect )
			openParams.Add("multiSelect", false);
			//항목조회화면 Open
			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);

//			this.txtHangmog.SetDataValue(string.Empty);
//			
//
//			if ((IHIS.Framework.EnvironInfo.CurrSystemID == "XRTS") || (IHIS.Framework.EnvironInfo.CurrSystemID == "SCHS"))
//			{
//				frmXRTHangmogCode dlgXRT = new frmXRTHangmogCode();
//				dlgXRT.ShowDialog();
//				if ( dlgXRT.DialogResult == DialogResult.OK)
//				{	
//					this.txtHangmog.SetDataValue(dlgXRT.HangmogCode);
//				}
//			}
//
//			if (IHIS.Framework.EnvironInfo.CurrSystemID == "HPCS")
//			{
//				frmHPCHangmogCode dlgHPC = new frmHPCHangmogCode();
//				dlgHPC.ShowDialog();
//				if ( dlgHPC.DialogResult == DialogResult.OK)
//				{	
//					this.txtHangmog.SetDataValue(dlgHPC.HangmogCode);
//				}
//			}
        }
        #endregion 

        #region 타Screen에서 Open (Command)
        public override object Command(string command, CommonItemCollection commandParam)
		{                       

			switch(command.Trim())
			{
				case "OCS0103Q00": //항목검색

					if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null && 
						((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
					{
						foreach(DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
						{
							//  항목검색인 FindBox로 처리한 건이기 때문에 현재 Focus에 있는 코드부터 세팅한다
							this.txtHangmog.SetEditValue(row["hangmog_code"].ToString());
							this.txtHangmog.AcceptData();
							this.lbHangmogName.Text = row["hangmog_name"].ToString();
						}
					}
					break;

				case "OCS0103Q11": //방사선처방

					if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null && 
						((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
					{
						foreach(DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
						{
							//  항목검색인 FindBox로 처리한 건이기 때문에 현재 Focus에 있는 코드부터 세팅한다
							this.txtHangmog.SetEditValue(row["hangmog_code"].ToString());
							this.txtHangmog.AcceptData();
							this.lbHangmogName.Text = row["hangmog_name"].ToString();
						}
					}

					break;

				case "OCS0103Q12": //LAB 처방

					if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null && 
						((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
					{
						foreach(DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
						{
							//  항목검색인 FindBox로 처리한 건이기 때문에 현재 Focus에 있는 코드부터 세팅한다
							this.txtHangmog.SetEditValue(row["hangmog_code"].ToString());
							this.txtHangmog.AcceptData();
							this.lbHangmogName.Text = row["hangmog_name"].ToString();
						}
					}

					break;

				case "OCS0103Q16": //생체검사 처방

					if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null && 
						((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
					{
						foreach(DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
						{
							//  항목검색인 FindBox로 처리한 건이기 때문에 현재 Focus에 있는 코드부터 세팅한다
							this.txtHangmog.SetEditValue(row["hangmog_code"].ToString());
							this.txtHangmog.AcceptData();
							this.lbHangmogName.Text = row["hangmog_name"].ToString();
						}
					}

					break;

				default:
					break;
	        }

			return base.Command(command, commandParam);
		}
		#endregion

		#region 환자예약 조회
        string mReserDate= "";
        string mSuname = "";
        string mBunho = "";
		private void ReserQuery()
		{
			string text;
			DateTime dt;
			
			lbReserDate.Text = string.Empty;
			lbReserTime.Text = string.Empty;

            mReserDate = "";
            mSuname = "";
            mBunho = "";

            // 예약할 처방의 날짜별 가능여부 조회
            this.layReserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.layReserList.SetBindVarValue("f_hangmog_code", txtHangmog.GetDataValue());

            mReserDate = dtDate.GetDataValue();
			
            if (this.paBoxPatient.BunHo == "")
                mSuname = txtSuname.GetDataValue();
            else
                mBunho = this.paBoxPatient.BunHo;
			
			dwReserList.Reset();
			if (this.layReserList.QueryLayout(true))
			{
                //dwReserList.FillData(layReserList.LayoutTable);  QueryEnd에서 처리
			}
			else
			{
				MessageBox.Show(Service.ErrMsg);
			}

			//예약일자 Set
			dt = DateTime.Parse(dtDate.GetDataValue());
			// 일자 setting
			string dd;
			string yoil_gubun = string.Empty;
			string TextColor = string.Empty;
			
			for (int i = 1 ; i <= 31 ; i++) //kbh
			{
                //휴일 색 지정
                layHoliYN.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
				layHoliYN.SetBindVarValue("f_date", dt.AddDays(i - 1).ToString("yyyyMMdd"));

				if (layHoliYN.QueryLayout())
				{
					if (layHoliYN.GetItemValue("holi_yn").ToString() == "Y")
						text = "t_" + i.ToString("00") + ".color = '134217857'";
					else
						text = "t_" + i.ToString("00") + ".color = '33554432'";

					dwReserList.Modify(text);

                    yoil_gubun = layHoliYN.GetItemValue("yoil_gubun").ToString();
				}

				dd = dt.AddDays(i - 1).ToString("dd");

				text = "t_" + i.ToString("00") + ".text = '" + dd + "'";
				dwReserList.Modify(text);

				if ((dd == "01") || (i == 1))
				{
					dd = dt.AddDays(i - 1).ToString("MM");
					TextColor = "m_" + i.ToString("00") + ".color = '33554432'";
				}
				else
				{
					if (yoil_gubun == "1") yoil_gubun = "日";
					if (yoil_gubun == "2") yoil_gubun = "月";
					if (yoil_gubun == "3") yoil_gubun = "火";
					if (yoil_gubun == "4") yoil_gubun = "水";
					if (yoil_gubun == "5") yoil_gubun = "木";
					if (yoil_gubun == "6") yoil_gubun = "金";
					if (yoil_gubun == "7") yoil_gubun = "土";
					dd = yoil_gubun;					
					TextColor = "m_" + i.ToString("00") + ".color = '32768'";
				}

				text = "m_" + i.ToString("00") + ".text = '" + dd + "'";

				dwReserList.Modify(text);
				dwReserList.Modify(TextColor);
			}
			dwReserList.Refresh();

		}

        private void layReserList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string o_jundal_table, o_jundal_part, o_hangmog_code;

            for (int i = 0; i < this.layReserList.RowCount; i++)
            {
                o_jundal_table = this.layReserList.GetItemString(i, "jundal_table");
                o_jundal_part = this.layReserList.GetItemString(i, "jundal_part");
                o_hangmog_code = this.layReserList.GetItemString(i, "hangmog_code");

                this.layLoadRES0101.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                //this.layLoadRES0101.SetBindVarValue("f_bunho", this.paBoxPatient.BunHo.ToString());
                //this.layLoadRES0101.SetBindVarValue("f_doctor", this.cboDoctor.GetDataValue().ToString());
                this.layLoadRES0101.SetBindVarValue("f_reser_date", dtDate.GetDataValue());
                //this.layLoadRES0101.SetBindVarValue("f_gwa", this.cboGwa.GetDataValue().ToString());

                this.layLoadRES0101.SetBindVarValue("o_jundal_table", o_jundal_table);
                this.layLoadRES0101.SetBindVarValue("o_jundal_part", o_jundal_part);
                this.layLoadRES0101.SetBindVarValue("o_hangmog_code", o_hangmog_code);

                /* 일자별 예약가능일 조회 */
                this.layLoadRES0101.QueryLayout(true);

                for (int j = 0; j < layLoadRES0101.RowCount; j++)
                {
                    if (this.layLoadRES0101.GetItemString(j, "day") == "01" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_1", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "02" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_2", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "03" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_3", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "04" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_4", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "05" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_5", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "06" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_6", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "07" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_7", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "08" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_8", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "09" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_9", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "10" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_10", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "11" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_11", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "12" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_12", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "13" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_13", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "14" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_14", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "15" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_15", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "16" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_16", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "17" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_17", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "18" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_18", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "19" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_19", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "20" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_20", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "21" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_21", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "22" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_22", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "23" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_23", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "24" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_24", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "25" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_25", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "26" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_26", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "27" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_27", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "28" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_28", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "29" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_29", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "30" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_30", "Y");
                    if (this.layLoadRES0101.GetItemString(j, "day") == "31" && this.layLoadRES0101.GetItemString(j, "cnt") == "Y")
                        this.layReserList.SetItemValue(i, "day_31", "Y");
                }
            }
            this.layLoadReser.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layLoadReser.SetBindVarValue("f_bunho", this.mBunho);
            this.layLoadReser.SetBindVarValue("f_suname", this.mSuname);
            this.layLoadReser.SetBindVarValue("f_reser_date", dtDate.GetDataValue());
            this.layLoadReser.QueryLayout(true);

            //DataTable dt = new DataTable("temp_table");
            dwReserList.FillData(layReserList.LayoutTable);
            dwReserList.FillData(layLoadReser.LayoutTable);

            dwReserList.Refresh();
        }
		#endregion

        #region 환자 번호 입력 시
        private void paBoxPatient_PatientSelected(object sender, System.EventArgs e)
		{
			txtSuname.SetDataValue(paBoxPatient.SuName);
			//예약조회
			ReserQuery();
        }
        #endregion 

        #region 항목코드 입력
        private void txtHangmog_TextChanged(object sender, System.EventArgs e)
		{
			lbHangmogName.Text = "";

			if (txtHangmog.Text != "")
			{
				ReserQuery();
				if (dwReserList.RowCount > 0)
				{
					lbHangmogName.Text = dwGetString(dwReserList, 1, "hangmog_name");
				}
			}
        }
        #endregion 

        #region dwGetString
        private string dwGetString(XDataWindow dw, int row, string colNm)
		{
			if(!dw.IsItemNull(row,colNm))
				return dw.GetItemString(row, colNm);
			return " ";
		}
		#endregion

        #region 예약일자 DW 클릭
        //private bool mReservedFlage = false; // 현재 선택한 검사가 예약된것인지
        private void dwReserList_Click(object sender, System.EventArgs e)
		{
			string colname, hangmog_code = "", jundal_table = "", jundal_part = "", gwa = "";
			int    row, addDate;
            //mReservedFlage = false;
            if (dwReserList.RowCount < 1)
                return;
           
			try
			{
				txtTime.SetDataValue(string.Empty);

				Sybase.DataWindow.ObjectAtPointer oap = dwReserList.ObjectUnderMouse;
				colname = string.Empty;
                row = oap.RowNumber;
                if (row < 1) return;

                this.dwReserAMList.Reset();
                this.dwReserPMList.Reset();
                lbReserDate.Text = string.Empty;
                lbReserTime.Text = string.Empty;

                txtJundalTable.SetDataValue("");
                txtKey.SetDataValue("");
                dtReserDate.SetDataValue("");

			    dwReserList.SetRow(row);

				// 이미 예약이 된 건은 날자 이동이 되지 않도록 한다.
				// 2009.02.02. 이인철 하트라이프 병원
                // 20100419 예약정보 조회못하므로 여긴 주석으로 막고 
                // 시간 그리드 클릭시에 리턴 시킴.
                //if (dwGetString(dwReserList, row, "reser_yn") == "Y") return;

				colname = oap.Gob.Name;

				dwReserList.Refresh();

				if (colname == "DataWindow") return;

                if (colname.Substring(0, 2) != "d_") return; // 아무대나 클릭하지 못하도록

                string data_col = colname.Replace("d", "day");
                data_col = data_col.Replace("day_0", "day_");
                string reser_yn = dwGetString(dwReserList, row, data_col);
                if ((reser_yn != "Y")) //|| (reser_yn == "R"))
                {
                    return;
                }

				DateTime dt = DateTime.Parse(dtDate.GetDataValue());			
				addDate = int.Parse(colname.Substring(2,2));

				txtJundalTable.SetDataValue(dwGetString(dwReserList, row, "jundal_table"));
				txtKey.SetDataValue(dwGetString(dwReserList, row, "key"));
				dtReserDate.SetDataValue(dt.AddDays(addDate - 1));

				hangmog_code = dwGetString(dwReserList, row, "hangmog_code");
				jundal_table = dwGetString(dwReserList, row, "jundal_table");
				jundal_part  = dwGetString(dwReserList, row, "jundal_part" );
				gwa          = dwGetString(dwReserList, row, "gwa");
				//lbReserDate.Text = dtReserDate.ToString();
                //lbReserDate.Text = dt.ToString("yyyy/MM/dd");

                ReserTimeList(hangmog_code, gwa, jundal_table, jundal_part);

                dwReserList.Refresh();
			}
			catch(Exception xe)
			{
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(xe.Message);
			}
		}
       
		private void dwReserList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserList.Refresh();
        }
        #endregion

        #region AM, PM List
        string mHangmogCode = "";
        string mGwa = "";
        string mJundalTable = "";
        string mJundalPart = "";
        
		private void ReserTimeList(string hangmog_code, string gwa, string jundal_table, string jundal_part)
		{
			lbReserDate.Text = dtReserDate.GetDataValue().ToString();
			lbReserTime.Text = string.Empty;

			dwReserAMList.Reset();
			dwReserPMList.Reset();

            mHangmogCode = hangmog_code;
            mGwa = gwa;
            mJundalTable = jundal_table;
            mJundalPart = jundal_part;
            //dsvTimeList.SetInValue("reser_date", dtReserDate.GetDataValue());

			// 일자별 예약시간 조회

            layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);
            layTimeList.SetBindVarValue("f_am_pm_gubun", "A");
            //dsvTimeList.SetInValue("reser_date", dtReserDate.GetDataValue());

            if (layTimeList.QueryLayout(true))
			{
                if (this.layTimeList.RowCount > 0)
                {
                    dwReserAMList.FillData(layTimeList.LayoutTable);
                    dwReserAMList.Refresh();
                }
			}
			else
			{
				//XMessageBox.Show(Service.ErrFullMsg);
				return;
			}

			this.layTimeList.Reset();

            //layTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //layTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);
            layTimeList.SetBindVarValue("f_am_pm_gubun", "P");

            if (layTimeList.QueryLayout(true))
            {
                if (this.layTimeList.RowCount > 0)
                {
                    dwReserPMList.FillData(layTimeList.LayoutTable);
                    dwReserPMList.Refresh();
                }
			}
			else
			{
                //XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}
		#endregion


        #region ReserTimeCheck [예약시간 체크]
        private bool ReserTimeCheck(string dw_bunho, string reser_time)
		{
			string jundal_table     = "";
			string jundal_part      = "";			
			
			int row = dwReserList.CurrentRow;

			jundal_table = dwGetString(dwReserList, row, "jundal_table").Trim();
			jundal_part  = dwGetString(dwReserList, row, "jundal_part").Trim();
			
            /* 일단은 주석처리 2010/10/07
			if (jundal_part == "MRI_1")
			{
				layReserChk.SetInValue("jundal_table", jundal_table);
				layReserChk.SetInValue("jundal_part", jundal_part);
				layReserChk.SetInValue("reser_date", dtReserDate.GetDataValue());
				layReserChk.SetInValue("reser_time", reser_time);
				
				DataServiceCall(layReserChk);
				if (layReserChk.GetOutValue("reser_chk").ToString() == "N")
				{
					string msg = (NetInfo.Language == LangMode.Ko ? "이미 예약이 잡힌 예정시간입니다."
						: "既に予約されている予定時間です。");
					XMessageBox.Show( msg,"確認", MessageBoxButtons.OK );
					return true;
				}
			}
            */
			return false;
		}
		#endregion

        #region dwReserAMList_Click
        private void dwReserAMList_Click(object sender, System.EventArgs e)
        {
            dwReserAMList.Refresh();
            if (this.dwReserList.RowCount < 1)
                return;

            // 20110419 김보현
            if (dwGetString(dwReserList, this.dwReserList.CurrentRow, "reser_yn") == "Y")
                return;

            Sybase.DataWindow.ObjectAtPointer oap = dwReserAMList.ObjectUnderMouse;
            int row = oap.RowNumber;
            if (row < 1) return;

            string suname = dwGetString(dwReserAMList, row, "suname");
            if (suname.Trim() != "")
            {
                lbReserTime.Text = "";
                MessageBox.Show("予約時間ををチェックしてください。");
                return;
            }

            // 예약가능 체크
            if (ReserTimeCheck("1", dwGetString(dwReserAMList, row, "reser_time")))
            {
                txtTime.SetDataValue(string.Empty);
                txtHangmogCode.SetDataValue(string.Empty);
                lbReserTime.Text = string.Empty;

                return;
            }

            txtTime.SetDataValue(dwGetString(dwReserAMList, row, "reser_time"));
            txtHangmogCode.SetDataValue(dwGetString(dwReserAMList, row, "hangmog_code"));

            //
            lbReserTime.Text = txtTime.Text.Substring(0, 2) + ":" + txtTime.Text.Substring(2, 2);
        }
        #endregion

        #region dwReserPMList_Click
        private void dwReserPMList_Click(object sender, System.EventArgs e)
        {
            dwReserPMList.Refresh();
            if (this.dwReserList.RowCount < 1)
                return;

            // 20110419 김보현
            if (dwGetString(dwReserList, this.dwReserList.CurrentRow, "reser_yn") == "Y")
                return;

            Sybase.DataWindow.ObjectAtPointer oap = dwReserPMList.ObjectUnderMouse;
            int row = oap.RowNumber;
            if (row < 1) return;

            string suname = dwGetString(dwReserPMList, row, "suname");
            if (suname.Trim() != "")
            {
                lbReserTime.Text = "";
                MessageBox.Show("予約時間ををチェックしてください。");
                return;
            }

            // 예약가능 체크
            if (ReserTimeCheck("1", dwGetString(dwReserPMList, row, "reser_time")))
            {
                txtTime.SetDataValue(string.Empty);
                txtHangmogCode.SetDataValue(string.Empty);
                lbReserTime.Text = string.Empty;
                return;
            }

            txtTime.SetDataValue(dwGetString(dwReserPMList, row, "reser_time"));

            //
            lbReserTime.Text = txtTime.Text.Substring(0, 2) + ":" + txtTime.Text.Substring(2, 2);
            // 취소는 되게
            //txtTime.SetDataValue(string.Empty);
        }
        #endregion 

		private void dwReserAMList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserAMList.Refresh();
		}

		private void dwReserPMList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwReserPMList.Refresh();
        }

        #region 날짜변경 클릭
        private void btPostDate_Click(object sender, System.EventArgs e)
		{
			DateTime dt = DateTime.Parse(dtDate.GetDataValue());
			dtDate.SetDataValue(dt.AddDays(-20));
			this.ReserQuery();
		}

		private void btPreDate_Click(object sender, System.EventArgs e)
		{
			DateTime dt = DateTime.Parse(dtDate.GetDataValue());
			dtDate.SetDataValue(dt.AddDays(20));
			this.ReserQuery();
        }
        #endregion 

        #region 날짜 변경시
        private void dtDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.ReserQuery();
        }
        #endregion

        #region 저장버튼 클릭
        private void btnSave_Click(object sender, System.EventArgs e)
		{
			if ((paBoxPatient.BunHo != "") || (txtSuname.GetDataValue() != ""))
            {
                if (dwGetString(dwReserList, this.dwReserList.CurrentRow, "reser_yn") == "Y")
                {
                    MessageBox.Show("既に予約済みのデーターです。予約を変更するにはまず予約取消しを行ってください。", "注意");                
                }
                else
				    ReserSave();
			}
			else
			{
				MessageBox.Show("患者情報がありません。ご確認ください。");
			}
        }
        #endregion

        #region 예약시간 선택
        private bool PreReserSave()
		{
			if ((dwReserAMList.RowCount > 0) || (dwReserPMList.RowCount > 0))
			{
				if (lbReserTime.Text == "") // 예약검사, 예약시간					
				{
					XMessageBox.Show(lbHangmogName.Text + "  時間を選んでください。");
					return false;
				}
			}
		
			return true;
			
		}
		#endregion

		#region 예약
		private void ReserSave()
		{
			//예약시간 체크
			if (!PreReserSave()) return;

			if (dtReserDate.GetDataValue() == string.Empty)
			{
				MessageBox.Show("予約日を入力してください。");
				return;
			}
			if (txtTime.GetDataValue() == string.Empty)
			{
				txtTime.SetDataValue("0000");
				txtHangmogCode.SetDataValue(dwGetString(dwReserList, 1, "hangmog_code"));
				lbReserTime.Text = "00:00";
			}

			string comments = "";
			if (this.fbxSogaeHop.GetDataValue().ToString() != "")	comments = this.fbxSogaeHop.GetDataValue().ToString();

            /*
            PR_SCH_SCH0201_INSERT( :i_fkocs        ,:i_hangmog_code
                                  ,:i_bunho        ,:i_reser_date ,:i_reser_time
                                  ,:q_user_id      ,:i_comments   ,:i_suname, 0
                                  ,:i_err          );*/

            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

            //inputList.Add(txtKey.GetDataValue());
            inputList.Add(DBNull.Value);
            inputList.Add(txtHangmog.GetDataValue());
            inputList.Add(this.paBoxPatient.BunHo);
            inputList.Add(this.dtReserDate.GetDataValue());
            inputList.Add(this.txtTime.GetDataValue());
            inputList.Add(UserInfo.UserID);
            inputList.Add(txtComment.Text.Trim() + comments);
            inputList.Add(txtSuname.GetDataValue());
            inputList.Add(0);

            try
            {

                if (Service.ExecuteProcedure("PR_SCH_SCH0201_INSERT", inputList, outputList))
                {
                    txtHangmog.Text = string.Empty;
                    // 예약내역 재조회
                    this.ReserQuery();

                    dwReserAMList.Reset();
                    dwReserPMList.Reset();
                }
                else
                {
                    throw new Exception(Service.ErrFullMsg);
                }

                if (outputList.Count > 0)
                {
                    if (!TypeCheck.IsNull(outputList[0]))
                    {
                        if (outputList[0].ToString() == "X")
                        {
                            throw new Exception("予約可能な人数を超えました。\r\n２枠以上検査の場合には２枠以上の空き枠が必要です。");
                        }
                        if (outputList[0].ToString() != "0")
                        {
                            //throw new Exception(outputList[0].ToString() + "\r\n" + Service.ErrFullMsg);
                        }
                    }
                }
            }
            catch(Exception xe)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("保存できませんでした。\r\n" + xe.Message, "保存失敗", MessageBoxIcon.Error);            
            }
		}
		#endregion

        #region 예약취소 버튼 클릭
        private void btnCancel_Click(object sender, System.EventArgs e)
		{
			ReserCancelSave();
        }
        #endregion

        #region ReserCancelSave()
        private void ReserCancelSave()
		{
			string pksch0201 = "";
            string cmdText = @"DELETE SCH0201
                                 WHERE HOSP_CODE    = :f_hosp_code
                                   AND PKSCH0201    = :f_pksch0201
                                   AND IN_OUT_GUBUN = 'X'";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", EnvironInfo.HospCode);

            try
            {
                Service.BeginTransaction();
                for (int i = 1; i <= dwReserList.RowCount; i++)
                {
                    if (dwGetString(dwReserList, i, "reser_chk_yn").Trim() == "Y")
                    {
                        pksch0201 = dwGetString(dwReserList, i, "key").Trim();
                        bc.Add("f_pksch0201", pksch0201);

                        if (!Service.ExecuteNonQuery(cmdText, bc))
                        {
                            throw new Exception();
                        }

                        // 예약취소
                        //dsvReserCancel.SetInValue("pksch0201", pksch0201);
                        //DataServiceCall(dsvReserCancel);

                    }
                }
                Service.CommitTransaction();
            }
            catch
            {
                Service.RollbackTransaction();
            }

			ReserQuery();
			return;

//			// Reset
//			this.dwReserList.Reset();
//			this.ReserQuery();
//			txtHangmog.Text = string.Empty;
//			this.ReserQuery();
			/*
			string hangmog_code = "", jundal_table = "", jundal_part = "", gwa = "";
			int    row;

			row = dwReserList.CurrentRow;
			
			hangmog_code = dwGetString(dwReserList, row, "hangmog_code");
			jundal_table = dwGetString(dwReserList, row, "jundal_table");
			jundal_part  = dwGetString(dwReserList, row, "jundal_part" );
			gwa          = dwGetString(dwReserList, row, "gwa");

			ReserTimeList(hangmog_code, gwa, jundal_table, jundal_part);
			*/

		}
		#endregion

        #region 환자번호 입력시
        private void txtSuname_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				ReserQuery();
			}
        }
        #endregion

        #region 방사선검사버튼을 클릭을 했을 때
        private void btnXrtOrder_Click(object sender, System.EventArgs e)
		{
			// Xrt처방조회 화면 Open
			CommonItemCollection openParams  = new CommonItemCollection();

			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0103Q11", ScreenOpenStyle.ResponseSizable, openParams);
		}
		#endregion

		#region 검체검사버튼을 클릭을 했을 때
		private void btnLabOrder_Click(object sender, System.EventArgs e)
		{
			// Lab처방조회 화면 Open
			CommonItemCollection openParams  = new CommonItemCollection();

			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0103Q12", ScreenOpenStyle.ResponseSizable, openParams);
		}
		#endregion

		#region 생리검사버튼을 클릭을 했을 때
		private void btnEtcOrder_Click(object sender, System.EventArgs e)
		{
			// 생체검사조회 화면 Open
			CommonItemCollection openParams  = new CommonItemCollection();

			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0103Q16", ScreenOpenStyle.ResponseFixed, openParams);
		}
		#endregion

        #region btnClose_Click
        private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
        }
        #endregion

        #region 시간와꾸 조회
        private void layTimeList_QueryStarting(object sender, CancelEventArgs e)
        {
            if (!Service.ExecuteProcedure("PR_SCH_TIME_LIST", Service.ClientIP, mJundalTable, mJundalPart, mHangmogCode, dtReserDate.GetDataValue()))
            {
                XMessageBox.Show("時間枠の生成に失敗しました。\r\n" + Service.ErrFullMsg, "エラー", MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region 소개병원 조회
        private void fwHosp_name_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwHosp_name.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

    }
}

