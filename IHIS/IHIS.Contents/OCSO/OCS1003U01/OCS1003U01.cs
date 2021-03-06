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

namespace IHIS.OCSO
{
	/// <summary>
	/// OCS1003U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS1003U01 : IHIS.Framework.XScreen
	{
		#region [Save_End]
		bool islayReturnList = false;
		bool isSavedReturnList = false;
		#endregion

		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 		
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//등록번호
		private string mBunho = "";
		//진료과
		private string mGwa = "";
		//의사
		private string mDoctor = "";
		//입력구분
		private string mInput_gubun = "";
		//내원일자
		private string mNaewon_date = "";
		//Input_part
		private string mInput_part = "";
		//pk_order
		private string mPk_order = "";

		private const string IOEGUBUN = "I"; // 입원		
		private const int    GIJUN_NALSU = 90; // 처방이 가능한 Max일수
		
		private System.Drawing.Color DATAEXISTSTABCOLOR   = Color.Red;
		private System.Drawing.Color DATAUNEXISTSTABCOLOR = Color.Black;
		
		#endregion

		private IHIS.Framework.XPatientBox xPatientBox1;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XDatePicker dpkNaewon_date;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XRadioButton rbtDC;
		private IHIS.Framework.XRadioButton rbtReturn;
		private IHIS.Framework.XMstGrid grdOUT1001;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGrid grdOCS1003;
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
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell68;
		private IHIS.Framework.XEditGridCell xEditGridCell69;
		private IHIS.Framework.XEditGridCell xEditGridCell70;
		private IHIS.Framework.XEditGridCell xEditGridCell71;
		private IHIS.Framework.XEditGridCell xEditGridCell72;
		private IHIS.Framework.XEditGridCell xEditGridCell97;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XTabControl tabOrder_gubun;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XEditGridCell xEditGridCell74;
		private IHIS.Framework.XEditGridCell xEditGridCell75;
		private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell73;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
		private IHIS.Framework.XEditGridCell xEditGridCell80;
		private IHIS.Framework.XEditGridCell xEditGridCell81;
		private IHIS.Framework.XEditGridCell xEditGridCell82;
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
		private IHIS.Framework.XEditGridCell xEditGridCell85;
		private IHIS.Framework.XEditGridCell xEditGridCell86;
		private IHIS.Framework.XEditGridCell xEditGridCell87;
		private IHIS.Framework.XEditGridCell xEditGridCell88;
		private IHIS.Framework.XEditGridCell xEditGridCell89;
		private IHIS.Framework.XEditGridCell xEditGridCell90;
		private IHIS.Framework.XEditGridCell xEditGridCell91;
		private IHIS.Framework.XEditGridCell xEditGridCell92;
		private IHIS.Framework.XEditGridCell xEditGridCell93;
		private IHIS.Framework.XEditGridCell xEditGridCell94;
		private IHIS.Framework.XEditGridCell xEditGridCell95;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.MultiLayout layOrder_danui;
		private IHIS.Framework.MultiLayout layOrder_gubun;
		private IHIS.Framework.MultiLayout layReturnList;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private XPanel xPanel6;
        private XRadioButton rbtCancel;
        private XRadioButton rbtOrder_date;
        private XRadioButton xRadioButton3;
        private XRadioButton xRadioButton4;
        private XPanel xPanel5;
        private XRadioButton xRadioButton1;
        private XRadioButton xRadioButton2;
        private XEditGridCell xEditGridCell101;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS1003U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리
		
			layReturnList.SavePerformer  = new XSavePerformer(this);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003U01));
            this.xPatientBox1 = new IHIS.Framework.XPatientBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbtCancel = new IHIS.Framework.XRadioButton();
            this.rbtOrder_date = new IHIS.Framework.XRadioButton();
            this.xRadioButton3 = new IHIS.Framework.XRadioButton();
            this.xRadioButton4 = new IHIS.Framework.XRadioButton();
            this.rbtReturn = new IHIS.Framework.XRadioButton();
            this.rbtDC = new IHIS.Framework.XRadioButton();
            this.dpkNaewon_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOUT1001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xRadioButton1 = new IHIS.Framework.XRadioButton();
            this.xRadioButton2 = new IHIS.Framework.XRadioButton();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.tabOrder_gubun = new IHIS.Framework.XTabControl();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.layOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layOrder_gubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.layReturnList = new IHIS.Framework.MultiLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder_gubun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPatientBox1
            // 
            this.xPatientBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPatientBox1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPatientBox1.Location = new System.Drawing.Point(0, 0);
            this.xPatientBox1.Name = "xPatientBox1";
            this.xPatientBox1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.xPatientBox1.Size = new System.Drawing.Size(960, 30);
            this.xPatientBox1.TabIndex = 9;
            this.xPatientBox1.PatientSelected += new System.EventHandler(this.xPatientBox1_PatientSelected);
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.xPanel6);
            this.xPanel1.Controls.Add(this.rbtReturn);
            this.xPanel1.Controls.Add(this.rbtDC);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 30);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 33);
            this.xPanel1.TabIndex = 10;
            // 
            // xPanel6
            // 
            this.xPanel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel6.BackgroundImage")));
            this.xPanel6.Controls.Add(this.rbtCancel);
            this.xPanel6.Controls.Add(this.rbtOrder_date);
            this.xPanel6.Controls.Add(this.xRadioButton3);
            this.xPanel6.Controls.Add(this.xRadioButton4);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Location = new System.Drawing.Point(0, 0);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(198, 31);
            this.xPanel6.TabIndex = 12;
            // 
            // rbtCancel
            // 
            this.rbtCancel.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtCancel.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtCancel.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtCancel.ImageIndex = 0;
            this.rbtCancel.Location = new System.Drawing.Point(98, 1);
            this.rbtCancel.Name = "rbtCancel";
            this.rbtCancel.Size = new System.Drawing.Size(95, 26);
            this.rbtCancel.TabIndex = 12;
            this.rbtCancel.Text = "取消";
            this.rbtCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtCancel.UseVisualStyleBackColor = false;
            // 
            // rbtOrder_date
            // 
            this.rbtOrder_date.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtOrder_date.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtOrder_date.Checked = true;
            this.rbtOrder_date.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOrder_date.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtOrder_date.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtOrder_date.ImageIndex = 1;
            this.rbtOrder_date.Location = new System.Drawing.Point(2, 1);
            this.rbtOrder_date.Name = "rbtOrder_date";
            this.rbtOrder_date.Size = new System.Drawing.Size(95, 26);
            this.rbtOrder_date.TabIndex = 11;
            this.rbtOrder_date.TabStop = true;
            this.rbtOrder_date.Text = "処理";
            this.rbtOrder_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtOrder_date.UseVisualStyleBackColor = false;
            // 
            // xRadioButton3
            // 
            this.xRadioButton3.Appearance = System.Windows.Forms.Appearance.Button;
            this.xRadioButton3.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.xRadioButton3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xRadioButton3.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.xRadioButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xRadioButton3.ImageIndex = 0;
            this.xRadioButton3.ImageList = this.ImageList;
            this.xRadioButton3.Location = new System.Drawing.Point(316, 4);
            this.xRadioButton3.Name = "xRadioButton3";
            this.xRadioButton3.Size = new System.Drawing.Size(112, 26);
            this.xRadioButton3.TabIndex = 9;
            this.xRadioButton3.Text = "      オ―ダ返却";
            this.xRadioButton3.UseVisualStyleBackColor = false;
            this.xRadioButton3.Visible = false;
            // 
            // xRadioButton4
            // 
            this.xRadioButton4.Appearance = System.Windows.Forms.Appearance.Button;
            this.xRadioButton4.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xRadioButton4.Checked = true;
            this.xRadioButton4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xRadioButton4.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xRadioButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xRadioButton4.ImageIndex = 1;
            this.xRadioButton4.ImageList = this.ImageList;
            this.xRadioButton4.Location = new System.Drawing.Point(200, 4);
            this.xRadioButton4.Name = "xRadioButton4";
            this.xRadioButton4.Size = new System.Drawing.Size(114, 26);
            this.xRadioButton4.TabIndex = 0;
            this.xRadioButton4.TabStop = true;
            this.xRadioButton4.Text = "      オ―ダ取消";
            this.xRadioButton4.UseVisualStyleBackColor = false;
            // 
            // rbtReturn
            // 
            this.rbtReturn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtReturn.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtReturn.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtReturn.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtReturn.ImageIndex = 0;
            this.rbtReturn.ImageList = this.ImageList;
            this.rbtReturn.Location = new System.Drawing.Point(316, 4);
            this.rbtReturn.Name = "rbtReturn";
            this.rbtReturn.Size = new System.Drawing.Size(112, 26);
            this.rbtReturn.TabIndex = 9;
            this.rbtReturn.Text = "      オ―ダ返却";
            this.rbtReturn.UseVisualStyleBackColor = false;
            this.rbtReturn.Visible = false;
            // 
            // rbtDC
            // 
            this.rbtDC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtDC.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtDC.Checked = true;
            this.rbtDC.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtDC.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtDC.ImageIndex = 1;
            this.rbtDC.ImageList = this.ImageList;
            this.rbtDC.Location = new System.Drawing.Point(200, 4);
            this.rbtDC.Name = "rbtDC";
            this.rbtDC.Size = new System.Drawing.Size(114, 26);
            this.rbtDC.TabIndex = 0;
            this.rbtDC.TabStop = true;
            this.rbtDC.Text = "      オ―ダ取消";
            this.rbtDC.UseVisualStyleBackColor = false;
            this.rbtDC.CheckedChanged += new System.EventHandler(this.rbtDC_CheckedChanged);
            // 
            // dpkNaewon_date
            // 
            this.dpkNaewon_date.Location = new System.Drawing.Point(91, 4);
            this.dpkNaewon_date.Name = "dpkNaewon_date";
            this.dpkNaewon_date.ReadOnly = true;
            this.dpkNaewon_date.Size = new System.Drawing.Size(102, 20);
            this.dpkNaewon_date.TabIndex = 7;
            this.dpkNaewon_date.TabStop = false;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(3, 4);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(88, 19);
            this.xLabel5.TabIndex = 6;
            this.xLabel5.Text = "オ―ダ日付";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 552);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(960, 38);
            this.xPanel2.TabIndex = 11;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.xButtonList1.Location = new System.Drawing.Point(788, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOUT1001);
            this.xPanel3.Controls.Add(this.xPanel5);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 63);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(200, 489);
            this.xPanel3.TabIndex = 12;
            // 
            // grdOUT1001
            // 
            this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell76,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell12});
            this.grdOUT1001.ColPerLine = 2;
            this.grdOUT1001.Cols = 2;
            this.grdOUT1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOUT1001.EnableMultiSelection = true;
            this.grdOUT1001.FixedRows = 1;
            this.grdOUT1001.HeaderHeights.Add(31);
            this.grdOUT1001.ImageList = this.ImageList;
            this.grdOUT1001.Location = new System.Drawing.Point(0, 27);
            this.grdOUT1001.Name = "grdOUT1001";
            this.grdOUT1001.QuerySQL = resources.GetString("grdOUT1001.QuerySQL");
            this.grdOUT1001.Rows = 2;
            this.grdOUT1001.RowStateCheckOnPaint = false;
            this.grdOUT1001.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOUT1001.Size = new System.Drawing.Size(198, 460);
            this.grdOUT1001.TabIndex = 1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.HeaderText = "オ―ダ日付";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "gwa";
            this.xEditGridCell2.CellWidth = 62;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "診療科";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.CellWidth = 66;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "医師";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "bunho";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "doctor";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "naewon_type";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "naewon_type";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "jubsu_no";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.HeaderText = "jubsu_no";
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pk_naewon";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "pk_naewon";
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "input_gubun";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "input_gubun";
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.CellName = "gwa_name";
            this.xEditGridCell12.CellWidth = 71;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.HeaderText = "診療科";
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xPanel5
            // 
            this.xPanel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel5.BackgroundImage")));
            this.xPanel5.Controls.Add(this.xRadioButton1);
            this.xPanel5.Controls.Add(this.dpkNaewon_date);
            this.xPanel5.Controls.Add(this.xRadioButton2);
            this.xPanel5.Controls.Add(this.xLabel5);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(198, 27);
            this.xPanel5.TabIndex = 11;
            // 
            // xRadioButton1
            // 
            this.xRadioButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.xRadioButton1.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.xRadioButton1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xRadioButton1.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.xRadioButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xRadioButton1.ImageIndex = 0;
            this.xRadioButton1.ImageList = this.ImageList;
            this.xRadioButton1.Location = new System.Drawing.Point(316, 4);
            this.xRadioButton1.Name = "xRadioButton1";
            this.xRadioButton1.Size = new System.Drawing.Size(112, 26);
            this.xRadioButton1.TabIndex = 9;
            this.xRadioButton1.Text = "      オ―ダ返却";
            this.xRadioButton1.UseVisualStyleBackColor = false;
            this.xRadioButton1.Visible = false;
            // 
            // xRadioButton2
            // 
            this.xRadioButton2.Appearance = System.Windows.Forms.Appearance.Button;
            this.xRadioButton2.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xRadioButton2.Checked = true;
            this.xRadioButton2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xRadioButton2.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xRadioButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xRadioButton2.ImageIndex = 1;
            this.xRadioButton2.ImageList = this.ImageList;
            this.xRadioButton2.Location = new System.Drawing.Point(200, 4);
            this.xRadioButton2.Name = "xRadioButton2";
            this.xRadioButton2.Size = new System.Drawing.Size(114, 26);
            this.xRadioButton2.TabIndex = 0;
            this.xRadioButton2.TabStop = true;
            this.xRadioButton2.Text = "      オ―ダ取消";
            this.xRadioButton2.UseVisualStyleBackColor = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdOCS1003);
            this.xPanel4.Controls.Add(this.tabOrder_gubun);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(200, 63);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(760, 489);
            this.xPanel4.TabIndex = 13;
            // 
            // grdOCS1003
            // 
            this.grdOCS1003.AddedHeaderLine = 1;
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell68,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell13,
            this.xEditGridCell31,
            this.xEditGridCell89,
            this.xEditGridCell24,
            this.xEditGridCell55,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell56,
            this.xEditGridCell10,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell96,
            this.xEditGridCell98,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell17,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell18,
            this.xEditGridCell88,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell11,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell19,
            this.xEditGridCell79,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell90,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell80,
            this.xEditGridCell52,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell42,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell73,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell74,
            this.xEditGridCell95,
            this.xEditGridCell75,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell46,
            this.xEditGridCell4,
            this.xEditGridCell101});
            this.grdOCS1003.ColPerLine = 21;
            this.grdOCS1003.Cols = 21;
            this.grdOCS1003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS1003.EnableMultiSelection = true;
            this.grdOCS1003.FixedRows = 2;
            this.grdOCS1003.HeaderHeights.Add(32);
            this.grdOCS1003.HeaderHeights.Add(0);
            this.grdOCS1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS1003.Location = new System.Drawing.Point(0, 24);
            this.grdOCS1003.MasterLayout = this.grdOUT1001;
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.QuerySQL = resources.GetString("grdOCS1003.QuerySQL");
            this.grdOCS1003.Rows = 3;
            this.grdOCS1003.RowStateCheckOnPaint = false;
            this.grdOCS1003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1003.Size = new System.Drawing.Size(758, 463);
            this.grdOCS1003.TabIndex = 4;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1003_MouseDown);
            this.grdOCS1003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1003_QueryEnd);
            this.grdOCS1003.GridFilterChanged += new System.EventHandler(this.grdOCS1003_GridFilterChanged);
            this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1003_QueryStarting);
            this.grdOCS1003.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS1003_GridColumnProtectModify);
            this.grdOCS1003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1003_GridColumnChanged);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "mix_group";
            this.xEditGridCell68.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.HeaderText = "mix_group";
            this.xEditGridCell68.IsUpdatable = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.CellWidth = 74;
            this.xEditGridCell20.Col = 3;
            this.xEditGridCell20.HeaderText = "オ―ダコード";
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 200;
            this.xEditGridCell21.Col = 4;
            this.xEditGridCell21.HeaderText = "オ―ダ名";
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "specimen_code";
            this.xEditGridCell22.CellWidth = 43;
            this.xEditGridCell22.Col = 5;
            this.xEditGridCell22.HeaderText = "検体";
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell23.CellWidth = 49;
            this.xEditGridCell23.Col = 6;
            this.xEditGridCell23.DecimalDigits = 3;
            this.xEditGridCell23.HeaderText = "数量";
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sunab_suryang";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "sunab_suryang";
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "subul_suryang";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.HeaderText = "subul_suryang";
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "order_danui";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.HeaderText = "オ―ダ単位";
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellLen = 100;
            this.xEditGridCell24.CellName = "order_danui_name";
            this.xEditGridCell24.CellWidth = 57;
            this.xEditGridCell24.Col = 7;
            this.xEditGridCell24.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell24.HeaderText = "単位";
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "subul_danui";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.HeaderText = "subul_danui";
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 24;
            this.xEditGridCell25.Col = 8;
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell25.HeaderText = "dv_time";
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellLen = 2;
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellWidth = 42;
            this.xEditGridCell26.Col = 9;
            this.xEditGridCell26.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell26.HeaderText = "dv";
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.MaxDropDownItems = 10;
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellLen = 2;
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellWidth = 38;
            this.xEditGridCell27.Col = 10;
            this.xEditGridCell27.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell27.HeaderText = "日数";
            this.xEditGridCell27.MaxDropDownItems = 10;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell27.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "sunab_nalsu";
            this.xEditGridCell56.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.HeaderText = "sunab_nalsu";
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellName = "bannab_suryang";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell10.CellWidth = 65;
            this.xEditGridCell10.Col = 11;
            this.xEditGridCell10.DecimalDigits = 3;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell10.HeaderForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell10.HeaderText = "返却数量";
            this.xEditGridCell10.RowSpan = 2;
            this.xEditGridCell10.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "jusa";
            this.xEditGridCell28.CellWidth = 34;
            this.xEditGridCell28.Col = 13;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell28.HeaderText = "注射";
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellName = "bogyong_code";
            this.xEditGridCell29.CellWidth = 69;
            this.xEditGridCell29.Col = 14;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell29.HeaderText = "用法";
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 23;
            this.xEditGridCell30.Col = 18;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.HeaderText = "院\r\n外";
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell96.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell96.CellWidth = 31;
            this.xEditGridCell96.Col = 15;
            this.xEditGridCell96.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell96.HeaderText = "当日\r\n施行";
            this.xEditGridCell96.IsUpdatable = false;
            this.xEditGridCell96.RowSpan = 2;
            this.xEditGridCell96.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell96.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell98.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell98.CellWidth = 31;
            this.xEditGridCell98.Col = 16;
            this.xEditGridCell98.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell98.HeaderText = "当日\r\n結果";
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.RowSpan = 2;
            this.xEditGridCell98.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell98.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 21;
            this.xEditGridCell32.Col = 17;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.HeaderText = "緊\r\n急";
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "pay";
            this.xEditGridCell33.CellWidth = 35;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.HeaderText = "請求\r\n区分";
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.CellName = "fluid_yn";
            this.xEditGridCell34.CellWidth = 32;
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "輸液";
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.CellName = "tpn_yn";
            this.xEditGridCell35.CellWidth = 33;
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.HeaderText = "TPN";
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "anti_cancer_yn";
            this.xEditGridCell36.CellWidth = 42;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "抗癌剤";
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell37.CellName = "muhyo";
            this.xEditGridCell37.CellWidth = 21;
            this.xEditGridCell37.Col = 19;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell37.HeaderText = "無\r\n効";
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.RowSpan = 2;
            this.xEditGridCell37.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell37.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "jaeryo_jundal_yn";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "jaeryo_jundal_yn";
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "portable_yn";
            this.xEditGridCell38.CellWidth = 38;
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.HeaderText = "移動\r\n撮影";
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell39.CellName = "symya";
            this.xEditGridCell39.CellWidth = 38;
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.HeaderText = "深夜";
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell39.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.CellName = "bichi_yn";
            this.xEditGridCell18.CellWidth = 21;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "配\r\n置";
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell18.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell88.CellName = "powder_yn";
            this.xEditGridCell88.CellWidth = 21;
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.HeaderText = "粉\r\n薬";
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            this.xEditGridCell88.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "ocs_flag";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.HeaderText = "ocs_flag";
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "order_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.HeaderText = "order_gubun";
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.CellName = "order_gubun_name";
            this.xEditGridCell11.CellWidth = 64;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.HeaderText = "オーダ\r\n区分";
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.RowSpan = 2;
            this.xEditGridCell11.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell11.SuppressRepeating = true;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "after_act_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.HeaderText = "after_act_yn";
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jundal_table";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.HeaderText = "jundal_table";
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.HeaderText = "jundal_part";
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.CellWidth = 58;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "グループ";
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "dv_1";
            this.xEditGridCell79.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.HeaderText = "dv_1";
            this.xEditGridCell79.IsUpdatable = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "dv_2";
            this.xEditGridCell85.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.HeaderText = "dv_2";
            this.xEditGridCell85.IsUpdatable = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "dv_3";
            this.xEditGridCell86.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.HeaderText = "dv_3";
            this.xEditGridCell86.IsUpdatable = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "dv_4";
            this.xEditGridCell87.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.HeaderText = "dv_4";
            this.xEditGridCell87.IsUpdatable = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell90.CellName = "hope_date";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell90.CellWidth = 118;
            this.xEditGridCell90.Col = 20;
            this.xEditGridCell90.HeaderText = "希望日";
            this.xEditGridCell90.IsUpdatable = false;
            this.xEditGridCell90.RowSpan = 2;
            this.xEditGridCell90.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell90.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bunho";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.HeaderText = "bunho";
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "naewon_date";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.HeaderText = "naewon_date";
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "gwa";
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "doctor";
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "naewon_type";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "naewon_type";
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "jubsu_no";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "jubsu_no";
            this.xEditGridCell80.IsUpdatable = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "pk_order";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.HeaderText = "pk_order";
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "input_id";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "input_id";
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "input_part";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "input_part";
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell42.CellName = "input_gubun";
            this.xEditGridCell42.CellWidth = 67;
            this.xEditGridCell42.Col = 2;
            this.xEditGridCell42.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell42.HeaderText = "入力\r\n区分";
            this.xEditGridCell42.IsReadOnly = true;
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.RowSpan = 2;
            this.xEditGridCell42.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell42.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell42.SuppressRepeating = true;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "seq";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.HeaderText = "seq";
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pkocs1003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.HeaderText = "pkocs1003";
            this.xEditGridCell54.IsUpdatable = false;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "slip_code";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.HeaderText = "slip_code";
            this.xEditGridCell69.IsUpdatable = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "group_yn";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.HeaderText = "group_yn";
            this.xEditGridCell70.IsUpdatable = false;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "sg_code";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.HeaderText = "sg_code";
            this.xEditGridCell71.IsUpdatable = false;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "order_gubun_bas";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.HeaderText = "order_gubun_bas";
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "suga_yn";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.HeaderText = "suga_yn";
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "jaeryo_yn";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.HeaderText = "jaeryo_yn";
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "nday_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.HeaderText = "nday_yn";
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "input_control";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.HeaderText = "input_control";
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "dc_yn";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.HeaderText = "dc_yn";
            this.xEditGridCell60.IsUpdatable = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "dc_gubun";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.HeaderText = "dc_gubun";
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "bannab_yn";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.HeaderText = "bannab_yn";
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "bannab_confirm";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.HeaderText = "bannab_confirm";
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "source_fkocs1003";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.HeaderText = "source_fkocs1003";
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "sunab_check";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.HeaderText = "sunab_check";
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "dc_check";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.HeaderText = "dc_check";
            this.xEditGridCell66.IsUpdatable = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "bannab_can_yn";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.HeaderText = "bannab_can_yn";
            this.xEditGridCell67.IsUpdatable = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "bannab_can_suryang";
            this.xEditGridCell74.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.HeaderText = "bannab_can_suryang";
            this.xEditGridCell74.IsUpdatable = false;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "bannab_danui";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.HeaderText = "bannab_danui";
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell75.CellName = "bannab_danui_name";
            this.xEditGridCell75.CellWidth = 65;
            this.xEditGridCell75.Col = 12;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell75.HeaderForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell75.HeaderText = "返却単位";
            this.xEditGridCell75.IsUpdatable = false;
            this.xEditGridCell75.RowSpan = 2;
            this.xEditGridCell75.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell75.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "sunab_yn";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.HeaderText = "sunab_yn";
            this.xEditGridCell77.IsUpdatable = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "dc_sunab_check";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.HeaderText = "dc_sunab_check";
            this.xEditGridCell78.IsUpdatable = false;
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "nurse_confirm_user";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.HeaderText = "nurse_confirm_user";
            this.xEditGridCell81.IsUpdatable = false;
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "nurse_confirm_date";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.HeaderText = "nurse_confirm_date";
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "nurse_confirm_time";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.HeaderText = "nurse_confirm_time";
            this.xEditGridCell83.IsUpdatable = false;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "tel_yn";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.HeaderText = "tel_yn";
            this.xEditGridCell84.IsUpdatable = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "specimen_name";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.HeaderText = "specimen_name";
            this.xEditGridCell91.IsUpdatable = false;
            this.xEditGridCell91.IsUpdCol = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "jusa_name";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.HeaderText = "jusa_name";
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsUpdCol = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "pay_name";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "pay_name";
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsUpdCol = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "bogyong_name";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.HeaderText = "bogyong_name";
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsUpdCol = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "bun_code";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.HeaderText = "bun_code";
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.IsUpdCol = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "sg_gesan";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.HeaderText = "sg_gesan";
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "dc_order_yn";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.HeaderText = "dc_order_yn";
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "select";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.HeaderText = "選択";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "cancel_mode_yn";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.HeaderText = "cancel_mode_yn";
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 8;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 24;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // tabOrder_gubun
            // 
            this.tabOrder_gubun.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabOrder_gubun.IDEPixelArea = true;
            this.tabOrder_gubun.IDEPixelBorder = false;
            this.tabOrder_gubun.ImageList = this.ImageList;
            this.tabOrder_gubun.Location = new System.Drawing.Point(0, 0);
            this.tabOrder_gubun.Name = "tabOrder_gubun";
            this.tabOrder_gubun.Size = new System.Drawing.Size(758, 24);
            this.tabOrder_gubun.TabIndex = 2;
            this.tabOrder_gubun.SelectionChanged += new System.EventHandler(this.tabOrder_gubun_SelectionChanged);
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.AlterateRowImageIndex = 0;
            this.xEditGridCell97.CellName = "select";
            this.xEditGridCell97.CellWidth = 36;
            this.xEditGridCell97.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell97.HeaderText = "選択";
            this.xEditGridCell97.ImageList = this.ImageList;
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.RowImageIndex = 0;
            this.xEditGridCell97.RowSpan = 2;
            this.xEditGridCell97.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "suga_yn";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "suga_yn";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // layOrder_danui
            // 
            this.layOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // layOrder_gubun
            // 
            this.layOrder_gubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            // layReturnList
            // 
            this.layReturnList.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.layReturnList_SaveEnd);
            // 
            // OCS1003U01
            // 
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPatientBox1);
            this.Name = "OCS1003U01";
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder_gubun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			return base.Command (command, commandParam);
		}

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);
			
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(OpenParam["bunho"].ToString().Trim() == "")
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

					if(OpenParam.Contains("gwa"))
					{
						if(OpenParam["gwa"].ToString().Trim() == "")
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正確ではないです. 確認してください." : "진료과가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							this.Close();
							return;
						}
						else
							mGwa = OpenParam["gwa"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正確ではないです. 確認してください." : "진료과가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}

					if(OpenParam.Contains("doctor"))
					{
						if(OpenParam["doctor"].ToString().Trim() == "")
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "診療医師が正確ではないです. 確認してください." : "진료의사가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							this.Close();
							return;
						}
						else
							mDoctor = OpenParam["doctor"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "診療医師が正確ではないです. 確認してください." : "진료의사가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						this.Close();
						return;
					}

		
					if(OpenParam.Contains("input_gubun"))
					{
						if(OpenParam["input_gubun"].ToString().Trim() == "")
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

					if(OpenParam.Contains("input_part"))
					{
						if(TypeCheck.IsNull(OpenParam["input_part"].ToString().Trim()))
						{
							//							mbxMsg = NetInfo.Language == LangMode.Jr ? "入力部署が正確ではないです. 確認してください." : "입력부서가 정확하지않습니다. 확인바랍니다.";
							//							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							//							XMessageBox.Show(mbxMsg, mbxCap);
							//							mBunho = "";
							//							return;
						}
						else
							mInput_part = OpenParam["input_part"].ToString().Trim();
					}
					else
					{
						//						mbxMsg = NetInfo.Language == LangMode.Jr ? "入力部署が正確ではないです. 確認してください." : "입력부서가 정확하지않습니다. 확인바랍니다.";
						//						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						//						XMessageBox.Show(mbxMsg, mbxCap);							
						//						return;
					}		

					
					mNaewon_date = DateTime.Now.ToString("yyyy/MM/dd");
					if(OpenParam.Contains("naewon_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
							mNaewon_date = OpenParam["naewon_date"].ToString();
					}
					dpkNaewon_date.SetDataValue(mNaewon_date);

				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
			}	
	
			this.grdOCS1003.FixedCols = 4;

			
			//DC일때는 반납수량을 표시하지 않는다.
			this.grdOCS1003.AutoSizeColumn(11, 0);
			this.grdOCS1003.AutoSizeColumn(12, 0);
			
			//Set M/D Relation			
			grdOCS1003.SetRelationKey("bunho", "bunho");
			grdOCS1003.SetRelationKey("naewon_date", "naewon_date");
			grdOCS1003.SetRelationKey("gwa", "gwa");
			grdOCS1003.SetRelationKey("doctor", "doctor");
			grdOCS1003.SetRelationKey("naewon_type", "naewon_type");
			grdOCS1003.SetRelationKey("input_gubun", "input_gubun");
			
			PostCallHelper.PostCall(new PostMethod(PostLoad));	
		}        
		
		private void PostLoad()
		{			 
			//처방구분
			LoadBaseData();

			rbtDC.Tag = "N";
			rbtReturn.Tag = "N";

			//comboBox생성
			CreateCombo();
            
			//Create ReturnValue
			CreateLayout();
			
			grdOUT1001.SetBindVarValue("f_bunho", mBunho);			
			grdOUT1001.SetBindVarValue("f_naewon_date", mNaewon_date);			
			grdOUT1001.SetBindVarValue("f_gwa", mGwa);			
			grdOUT1001.SetBindVarValue("f_doctor", mDoctor);
			grdOUT1001.SetBindVarValue("f_input_gubun", mInput_gubun);
			
			//grdOUT1001.Call();
			xPatientBox1.SetPatientID(mBunho);

							
		}   	

		/// <summary>
		/// 기준정보 DataLayout생성
		/// </summary>
		private void LoadBaseData()
		{
			//Order 단위
			layOrder_gubun.QuerySQL = " SELECT CODE, CODE_NAME "
				+ "   FROM OCS0132 "
				+ "  WHERE CODE_TYPE = 'ORDER_GUBUN' "
				+ "  ORDER BY CODE ";
			layOrder_gubun.QueryLayout(true);
		}

		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{			
			//OCS1003
			foreach(XEditGridCell cell in this.grdOCS1003.CellInfos)
			{
				layReturnList.LayoutItems.Add(cell.CellName, (DataType)cell.CellType, false, cell.IsUpdCol);
			}

			layReturnList.InitializeLayoutTable();				
		
		}

		#endregion

		#region [Combo 생성]
		
		private void CreateCombo()
		{
			// Combo 세팅
			DataTable dtTemp = null;

			// 입력구분(Display용)
			dtTemp = this.mOrderBiz.LoadComboDataSource("input_gubun_disp").LayoutTable;
			this.grdOCS1003.SetComboItems("input_gubun", dtTemp, "code_name", "code", XComboSetType.AppendNone);
			
			// 급여구분
			dtTemp  = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
			this.grdOCS1003.SetListItems("pay", dtTemp, "code_name", "code", XComboSetType.NoAppend);
		
			// DV_TIME
			dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
			this.grdOCS1003.SetListItems("dv_time", dtTemp, "code", "code", XComboSetType.NoAppend);

			// 이동촬영여부
			dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
			this.grdOCS1003.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

			//DV, NALSU처리
			this.mOrderBiz.SetNumCombo(this.grdOCS1003, "dv");
			this.mOrderBiz.SetNumCombo(this.grdOCS1003, "nalsu");

		}		

		#endregion

		#region [Tab 정보]
        
		/// <summary>
		/// Order_gubun을 tab으로 생성합니다.
		/// </summary>
		private void CreateOrder_gubun()
		{	
			//Clear
			try
			{
				tabOrder_gubun.TabPages.Clear();
			}
			catch{}
			
			grdOCS1003.ClearFilter();
			if(grdOCS1003.RowCount < 1) return;
			
			IHIS.X.Magic.Controls.TabPage page = new IHIS.X.Magic.Controls.TabPage();			
			page.Title = "全体";
			page.Tag = "%";
			page.ImageIndex = 1;
			tabOrder_gubun.TabPages.Add(page);

			if(tabOrder_gubun.TabPages.Count > 1) return;

            
			//Tab page생성	
			string filter = "";
			if(rbtDC.Checked)
				filter = " bannab_can_yn <> 'Y' ";
			else
				filter = " bannab_can_yn = 'Y' ";
            
			string order_gubun = "", order_gubun_name = "";

			foreach(DataRow row in grdOCS1003.LayoutTable.Select(filter, " order_gubun "))
			{
				if(row["order_gubun"].ToString() != order_gubun )
				{
					order_gubun = row["order_gubun"].ToString().Trim();

					//order_gubun명을 가져온다.
					foreach( DataRow ordRow in this.layOrder_gubun.LayoutTable.Select(" code = '" + order_gubun + "' ", ""))
					{
						order_gubun_name = ordRow["code_name"].ToString();
					}

					if(order_gubun_name == "") continue;

					page = new IHIS.X.Magic.Controls.TabPage();					
					page.Title = order_gubun_name;
					page.Tag = order_gubun;
					page.ImageIndex = 0;
					tabOrder_gubun.TabPages.Add(page);
				}
			}				
			
			tabOrder_gubun.SelectedIndex = 0;

		}

		private void tabOrder_gubun_SelectionChanged(object sender, System.EventArgs e)
		{
			foreach( IHIS.X.Magic.Controls.TabPage page in tabOrder_gubun.TabPages)
			{
				if(tabOrder_gubun.SelectedTab == page)
					page.ImageIndex = 1;
				else
					page.ImageIndex = 0;
			}

			string filter = tabOrder_gubun.SelectedTab.Tag.ToString() == "%" ? "" : " order_gubun = '" + tabOrder_gubun.SelectedTab.Tag.ToString().Trim() + "' and ";

			if(rbtDC.Checked)
				filter = filter + " bannab_can_yn <> 'Y' ";
			else
				filter = filter + " bannab_can_yn = 'Y' ";

			this.grdOCS1003.ClearFilter();
			if( grdOCS1003.RowCount >0 ) this.grdOCS1003.SetFilter(filter);
			
		}

		#endregion
        
		#region [Control Event]
		private void rbtDC_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtDC.Checked)
			{
				rbtDC.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				if(rbtDC.Tag.ToString() != "Y") rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtDC.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size, FontStyle.Bold);
				rbtDC.ImageIndex = 1;

				rbtReturn.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				if(rbtReturn.Tag.ToString() != "Y") rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtReturn.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size);
				rbtReturn.ImageIndex = 0;  
    
				//DC일때는 반납수량을 표시하지 않는다.
				this.grdOCS1003.AutoSizeColumn(11, 0);
				this.grdOCS1003.AutoSizeColumn(12, 0);

			}
			else
			{
				rbtReturn.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				if(rbtReturn.Tag.ToString() != "Y") rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtReturn.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size, FontStyle.Bold);
				rbtReturn.ImageIndex = 1;

				rbtDC.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				if(rbtDC.Tag.ToString() != "Y") rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtDC.Font = new Font(rbtDC.Font.FontFamily, rbtDC.Font.Size);
				rbtDC.ImageIndex = 0;
                
				//반납일때는 반납수량을 표시한다.
				this.grdOCS1003.AutoSizeColumn(11, 65);
				this.grdOCS1003.AutoSizeColumn(12, 65);
			
			}

			CreateOrder_gubun();
		
		}

		private void xPatientBox1_PatientSelected(object sender, System.EventArgs e)
		{
			mBunho = xPatientBox1.BunHo;
			grdOUT1001.SetBindVarValue("f_bunho", mBunho);
			grdOUT1001.QueryLayout(false);

		}

        private string GetOUT1001QuerySQL()
        {
            string cmd = "";

            if (this.rbtOrder_date.Checked == true)
            {
                cmd = @"SELECT DISTINCT
       A.ORDER_DATE,
       A.GWA,
       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)
                                         DOCTOR_NAME,
       A.BUNHO      ,
       A.DOCTOR     ,
       A.NAEWON_TYPE,
       1,
       A.FKOUT1001                                                      PK_NAEWON,
       :f_input_gubun                                                   INPUT_GUBUN,
       FN_BAS_LOAD_GWA_NAME( A.GWA, A.ORDER_DATE)                      GWA_NAME
  FROM OCS1003 A,
       OCS0103 B
 WHERE A.BUNHO                = :f_bunho
   AND A.ORDER_DATE          <= :f_naewon_date
   AND A.GWA                  = :f_gwa
   AND A.DOCTOR               = :f_doctor
   AND (( A.INPUT_GUBUN   = :f_input_gubun       ) OR
        ( :f_input_gubun  = 'D%' AND A.INPUT_GUBUN LIKE :f_input_gubun ))
  -- AND NVL(A.OCS_DATA_YN,'Y') = 'Y'
   AND NVL(A.DC_YN,'N')       = 'N'
   AND NVL(A.DISPLAY_YN, 'Y') = 'Y'
   AND A.NALSU                > 0
   AND NVL(A.IO_GUBUN, ' ')  <> 'I'
   AND B.HANGMOG_CODE         = A.HANGMOG_CODE
/*
   AND (  ( A.OCS_FLAG = '2' AND A.ACTING_DATE IS NULL )
       OR (   A.ACTING_DATE IS NOT NULL
          AND NVL(A.WONYOI_ORDER_YN,'N') = 'N'
          AND B.RETURN_YN  = 'Y'
          AND (  (   A.JUNDAL_TABLE = 'DRG'
                 AND A.JUNDAL_PART IN ('PA','AC','AT') )
              OR ( ( A.JUNDAL_PART IN ( 'IR', 'PIR', 'IK' ) )
                 AND A.SUNAB_NALSU > 1 AND A.ACTING_DAY < A.SUNAB_NALSU ))))
*/
   AND A.OCS_FLAG = '2'
   AND A.ACTING_DATE IS NULL
   AND A.JUNDAL_PART NOT IN ( 'PA', 'IR' )
 ORDER BY A.ORDER_DATE DESC";
            }
            else
            {
                cmd = @"SELECT DISTINCT
       A.ORDER_DATE,
       A.GWA,
       FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.ORDER_DATE)
                                         DOCTOR_NAME,
       A.BUNHO      ,
       A.DOCTOR     ,
       A.NAEWON_TYPE,
       1,
       A.FKOUT1001                                                      PK_NAEWON,
       :f_input_gubun                                                   INPUT_GUBUN,
       FN_BAS_LOAD_GWA_NAME( A.GWA, A.ORDER_DATE)                      GWA_NAME
  FROM OCS1003 A,
       OCS0103 B
 WHERE A.BUNHO                = :f_bunho
   AND A.ORDER_DATE          <= :f_naewon_date
   AND A.GWA                  = :f_gwa
   AND A.DOCTOR               = :f_doctor
   AND (( A.INPUT_GUBUN   = :f_input_gubun       ) OR
        ( :f_input_gubun  = 'D%' AND A.INPUT_GUBUN LIKE :f_input_gubun ))
   AND NVL(A.DC_YN,'N')       = 'N'
   AND NVL(A.DISPLAY_YN, 'Y') = 'Y'
   AND A.NALSU               < 0
   AND NVL(A.IO_GUBUN, ' ')  <> 'I'
   AND B.HANGMOG_CODE         = A.HANGMOG_CODE
   AND A.JUNDAL_PART NOT IN ( 'PA', 'IR' )
 ORDER BY A.ORDER_DATE DESC";
            }

            return cmd;
        }
		#endregion

		#region [grdOCS1003 Event]

		private void grdOCS1003_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			//select Skip
			if(e.ColName == "select") return;

			object previousValue   = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value


			if(e.DataRow["bannab_can_yn"].ToString() == "Y")
			{
				if(e.ColName == "bannab_suryang")
				{				
					if(TypeCheck.IsDecimal(e.ChangeValue.ToString().Trim()))
					{
						if(Double.Parse(e.ChangeValue.ToString()) > grdOCS1003.GetItemDouble(e.RowNumber, "bannab_can_suryang"))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "返却可能な数量より大きいです。確認してください。" : "반납수량보다 큽니다. 확인바랍니다"; 
							mbxCap = NetInfo.Language == LangMode.Jr ? "返却数量" : "返却数量";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);

							this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
						}
					}					
				}
			}
			else
			{
				////////////////////// 필드 Validation 및 Value Setting 공통모듈 Call ///////////////////
				if (!this.mHangmogInfo.ColumnChanged("I", mBunho, grd.GetItemString(e.RowNumber, "naewon_date"), grd, e)) return;
				/////////////////////////////////////////////////////////////////////////////////////////

				// 항목코드와 추가적인 필드 Validation 및 Value Setting
				switch (e.ColName)
				{
					
					case "nalsu": // 날수
						#region
						int nalsu = int.Parse(TypeCheck.NVL(e.ChangeValue, "0").ToString());

						if (grd.GetItemString(e.RowNumber, "input_control").Trim() == "3") ///마취인 경우는 분(minute)임
						{
					
						}
						else
						{
							// 처방가능 일수보다 큰 경우는 기준일자(90일)까지만 입력케 한다(단 마취는 제외)
							if (nalsu > GIJUN_NALSU)
							{
								mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ入力時、日数は[{0}]日を超えられません。" : "처방입력시 일수는 [{0}]일을 초과할수 없습니다.";
								mbxMsg = String.Format(mbxMsg, GIJUN_NALSU.ToString().Trim());
								XMessageBox.Show(mbxMsg, mbxCap);
						
								this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
								return;
							}
						}

						break;
						#endregion
					
					default:
						break;
				}

				//DC 처방
				grd.SetItemValue(e.RowNumber, "dc_order_yn", "Y");
			}			
		}


		private void grdOCS1003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				int rowIndex = grdOCS1003.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS1003.CurrentColNumber == 0)
				{					
					if(grdOCS1003.GetItemString(rowIndex, "select") == "")
					{
						grdOCS1003.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS1003.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}
				}
			}	
		}

		private void grdOCS1003_GridFilterChanged(object sender, System.EventArgs e)
		{
			SelectionBackColorChange(grdOCS1003);		
		}

		private void grdOCS1003_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
			if(e.DataRow["bannab_can_yn"].ToString() == "Y")
			{
				if(e.ColName == "bannab_suryang")
					e.Protect = false;
				else
					e.Protect = true;				
			}
			else
			{
				if(e.ColName == "bannab_suryang")
					e.Protect = true;
				else
				{
					// InputControl별 필드 입력불가 제어
					// 처방 Field DataChange 가능여부 체크 입력불가 제어
					if (this.mInputControl.IsProtectedColumn(grdOCS1003.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ) e.Protect = true;
				}
			}
		}

		private void grdOCS1003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;	

			if(e.ColName == "select") return;

			// 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
			// ReadOnly인 경우 
			// InputControl별 필드 입력불가 제어
			// 처방 Field DataChange 가능여부 체크
			//			if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable && 
			//				(grd.GetRowState(e.RowNumber) == DataRowState.Unchanged || grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
			//				(((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly) ||
			//				( this.mInputControl.IsProtectedColumn(grd.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName)) )
			//			{
			//				e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
			//				e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
			//			}

			#region 코드만 화면 Display하는 필드를 명칭으로 ToolTip 처리
			switch (e.ColName)
			{
				
				case "specimen_code": // 검체코드
					grd[e.RowNumber, e.ColName].ToolTipText = grd.GetItemString(e.RowNumber, "specimen_name");
					break;

				case "jusa": // 주사
					grd[e.RowNumber, e.ColName].ToolTipText = grd.GetItemString(e.RowNumber, "jusa_name");
					break;

				case "pay": // 급여
					grd[e.RowNumber, e.ColName].ToolTipText = grd.GetItemString(e.RowNumber, "pay_name");
					break;

				case "bogyong_code": // 용법코드
					grd[e.RowNumber, e.ColName].ToolTipText = grd.GetItemString(e.RowNumber, "bogyong_name");
					break;
				
			}
			#endregion
		}

		private void grdOCS1003_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

			string order_date  = grd.GetItemString(e.RowNumber, "naewon_date"); // 처방일자
			string bunho        = grd.GetItemString(e.RowNumber, "bunho");       // 등록번호
			string hangmog_code = grd.GetItemString(e.RowNumber, "hangmog_code"); // 항목코드

			switch (e.ColName)
			{
				case "specimen_code":   // 검체코드 (항목코드별)

					((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("specimen_code_hangmog", hangmog_code);
					
					break;


				case "ord_danui_name": // 처방단위 (항목코드별)

					((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName, hangmog_code);					
					
					break;

				case "jundal_part":

					((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker("jundal_part_inp", order_date);

					break;
			    				
				default:

					((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = this.mOrderBiz.GetFindWorker(e.ColName);

					break;

			}
		}

		private void grdOCS1003_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
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

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grid, int currentRowIndex, string data)
		{
			XEditGrid grdObject = (XEditGrid)grid;          
            
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if(data == "Y")
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
		}
		
		private void SelectionBackColorChange(object grid)
		{
			XEditGrid grdObject = (XEditGrid)grid;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{
				//불용은 넘어간다.
				if(grdObject.CellInfos.Contains("bulyong_check") && grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" ) continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
					}
				}
				else
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion

		#region [Button List Event]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			switch (e.Func)
			{
				case FunctionType.Process:
					
					e.IsBaseCall = false;

					if(!CreateReturnValue())
						return;

					if(layReturnList.SaveLayout())
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
						SetMsg(mbxMsg);

						grdOCS1003.QueryLayout(false);

						try
						{
							IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

							CommonItemCollection commandParams  = new CommonItemCollection();
							commandParams.Add( "retrieve", "Y");
							scrOpener.Command(this.ScreenID, commandParams);
						}
						catch
						{
						}
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が失敗しました。" : "처리 실패하였습니다."; 
						mbxMsg = mbxMsg + Service.ErrMsg;
						mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
					}

					break;
					
				default:

					break;
			}
		}
		#endregion

		#region [DC/반납정보생성]

		private bool CreateReturnValue()
		{
			layReturnList.Reset();

			this.AcceptData();

			foreach(DataRow row in grdOCS1003.LayoutTable.Rows)
			{
				if(row["select"].ToString() == " ")
				{
					row["input_id"   ] = UserInfo.UserID;
					if(!TypeCheck.IsNull(mInput_part))
						row["input_part" ] = mInput_part;

					//row["input_gubun"] = mInput_gubun;

					//DC, 반납여부
					if(rbtDC.Checked)
						row["bannab_yn"] = "N";
					else
						row["bannab_yn"] = "Y";

                    if (rbtOrder_date.Checked)
                        row["cancel_mode_yn"] = "N";
                    else
                        row["cancel_mode_yn"] = "Y";

					layReturnList.LayoutTable.ImportRow(row);				
				}
			}

			if(layReturnList.LayoutTable.Rows.Count > 0 )
				return true;
			else
				return false;
		}

		#endregion

		#region[Service Event]
		private void grdOCS1003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
            grdOCS1003.SetBindVarValue("f_fkout1001", grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pk_naewon"));
			grdOCS1003.SetBindVarValue("f_input_gubun",grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber,"input_gubun"));
		}

        private string GetOCS1003QuerySQL()
        {
            string cmd = "";

            if (this.rbtOrder_date.Checked)
            {
                cmd = @"SELECT A.MIX_GROUP                                                                      MIX_GROUP                  ,
       A.HANGMOG_CODE                                                                   HANGMOG_CODE               ,
       B.HANGMOG_NAME                                                                   HANGMOG_NAME               ,
       A.SPECIMEN_CODE                                                                  SPECIMEN_CODE              ,
       A.SURYANG                                                                        SURYANG                    ,
       A.SUNAB_SURYANG                                                                  SUNAB_SURYANG              ,
       A.SUBUL_SURYANG                                                                  SUBUL_SURYANG              ,
       A.ORD_DANUI                                                                      ORD_DANUI                  ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)                                  ORD_DANUI_NAME             ,
       A.SUBUL_DANUI                                                                    SUBUL_DANUI                ,
       A.DV_TIME                                                                        DV_TIME                    ,
       A.DV                                                                             DV                         ,
       A.NALSU                                                                          NALSU                      ,
       A.NALSU                                                                          SUNAB_NALSU                ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('O',A.PKOCS1003)), 0)     BANNAB_SURYANG ,
       A.JUSA                                                                           JUSA                       ,
       A.BOGYONG_CODE                                                                   BOGYONG_CODE               ,
       A.WONYOI_ORDER_YN                                                                WONYOI_ORDER_YN            ,
       NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                                               DANGIL_GUMSA_ORDER_YN      ,
       NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                                               DANGIL_GUMSA_RESULT_YN     ,
       A.EMERGENCY                                                                      EMERGENCY                  ,
       A.PAY                                                                            PAY                        ,
       'N'                                                                              FLUID_YN                   ,
       'N'                                                                              TPN_YN                     ,
       A.ANTI_CANCER_YN                                                                 ANTI_CANCER_YN             ,
       A.MUHYO                                                                          MUHYO                      ,
       A.JAERYO_JUNDAL_YN                                                               JAERYO_JUNDAL_YN           ,
       A.PORTABLE_YN                                                                    PORTABLE_YN                ,
       'N'                                                                              SYMYA                      ,
       A.BICHI_YN                                                                       BICHI_YN                   ,
       A.POWDER_YN                                                                      POWDER_YN                  ,
       A.OCS_FLAG                                                                       OCS_FLAG                   ,
       A.ORDER_GUBUN                                                                    ORDER_GUBUN                ,
       NVL(D.CODE_NAME, 'Etc')                                                          ORDER_GUBUN_NAME           ,
       A.AFTER_ACT_YN                                                                   AFTER_ACT_YN               ,
       A.JUNDAL_TABLE                                                                   JUNDAL_TABLE               ,
       A.JUNDAL_PART                                                                    JUNDAL_PART                ,
       A.GROUP_SER                                                                      GROUP_SER                  ,
       A.DV_1                                                                           DV_1                       ,
       A.DV_2                                                                           DV_2                       ,
       A.DV_3                                                                           DV_3                       ,
       A.DV_4                                                                           DV_4                       ,
       A.HOPE_DATE                                                                      HOPE_DATE                  ,
       A.BUNHO                                                                          BUNHO                      ,
       A.ORDER_DATE                                                                     NAEWON_DATE                ,
       A.GWA                                                                            GWA                        ,
       A.DOCTOR                                                                         DOCTOR                     ,
       A.NAEWON_TYPE                                                                    NAEWON_TYPE                ,
       1                                                                                JUBSU_NO                   ,
       A.FKOUT1001                                                                      PK_ORDER                  ,
       A.INPUT_ID                                                                       INPUT_ID                   ,
       A.INPUT_PART                                                                     INPUT_PART                 ,
       A.INPUT_GUBUN                                                                    INPUT_GUBUN                ,
       A.SEQ                                                                            SEQ                        ,
       A.PKOCS1003                                                                      PKOCS1003                  ,
       B.SLIP_CODE                                                                      SLIP_CODE                  ,
       B.GROUP_YN                                                                       GROUP_YN                   ,
       B.SG_CODE                                                                        SG_CODE                    ,
       B.ORDER_GUBUN                                                                    ORDER_GUBUN_BAS            ,
       NVL(B.SUGA_YN,'N')                                                               SUGA_YN                    ,
       NVL(B.JAERYO_YN,'N')                                                             JAERYO_YN                  ,
       NVL(B.NDAY_YN,'N')                                                               NDAY_YN                    ,
       B.INPUT_CONTROL                                                                  INPUT_CONTROL              ,
       A.DC_YN                                                                          DC_YN                      ,
       A.DC_GUBUN                                                                       DC_GUBUN                   ,
       A.BANNAB_YN                                                                      BANNAB_YN                  ,
       A.BANNAB_CONFIRM                                                                 BANNAB_CONFIRM             ,
       A.SOURCE_FKOCS1003                                                               SOURCE_FKOCS1003           ,
       DECODE(A.SUNAB_DATE, NULL, 'N','Y')                                              SUNAB_CHECK                ,
       DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                                            DC_CHECK                   ,
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                               BANNAB_CAN_YN              ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('O',A.PKOCS1003)), 0) BANNAB_CAN_SURYANG ,
       DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE))          BANNAB_DANUI                 ,
       DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE)))
                                                                                                BANNAB_DANUI_NAME  ,
       A.SUNAB_YN                                                                       SUNAB_YN                   ,
       DECODE(A.SUNAB_DATE, NULL, DECODE(A.OCS_FLAG,'2','Y','N'),'N')                   DC_SUNAB_CHECK             ,
       A.NURSE_CONFIRM_USER                                                             NURSE_CONFIRM_USER         ,
       A.NURSE_CONFIRM_DATE                                                             NURSE_CONFIRM_DATE         ,
       A.NURSE_CONFIRM_TIME                                                             NURSE_CONFIRM_TIME         ,
       A.TEL_YN                                                                         TEL_YN                     ,
       FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)                                       SPECIMEN_NAME              ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                                            JUSA_NAME                  ,
       FN_OCS_LOAD_CODE_NAME('PAY',  A.PAY)                                             PAY_NAME                   ,
       FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                      BOGYONG_NAME               ,
       E.BUN_CODE                                                                       BUN_CODE
--       E.SG_GESAN                                                                       SG_GESAN
  FROM OCS1003 A,
       OCS0103 B,
       OCS0132 C,
       OCS0132 D,
       ( SELECT X.SG_CODE
              , X.BUN_CODE
           FROM BAS0310 X
          WHERE X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
                               FROM BAS0310 Z
                              WHERE Z.SG_CODE = X.SG_CODE
                                AND Z.SG_YMD <= TRUNC(SYSDATE) )
       ) E
 WHERE A.FKOUT1001 = :f_fkout1001
   AND (( A.INPUT_GUBUN   = :f_input_gubun       ) OR
        ( :f_input_gubun  = 'D%' AND A.INPUT_GUBUN LIKE :f_input_gubun ))
--   AND NVL(A.OCS_DATA_YN,'Y') = 'Y'
   AND NVL(A.DC_YN,'N')       = 'N'
   AND NVL(A.DISPLAY_YN, 'Y') = 'Y'
   AND A.NALSU                > 0
   AND NVL(A.IO_GUBUN, ' ')  <> 'I'
   AND B.HANGMOG_CODE         = A.HANGMOG_CODE
   AND A.OCS_FLAG = '2'
   AND A.ACTING_DATE IS NULL
   AND A.JUNDAL_PART NOT IN ('PA', 'IR')
   AND C.CODE     (+)  = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)  = 'INPUT_GUBUN'
   AND D.CODE     (+)  = A.ORDER_GUBUN
   AND D.CODE_TYPE(+)  = 'ORDER_GUBUN'
   AND E.SG_CODE  (+)  = B.SG_CODE
ORDER BY MIX_GROUP,HANGMOG_CODE ";
            }
            else
            {
                cmd = @"SELECT A.MIX_GROUP                                                                      MIX_GROUP                  ,
       A.HANGMOG_CODE                                                                   HANGMOG_CODE               ,
       B.HANGMOG_NAME                                                                   HANGMOG_NAME               ,
       A.SPECIMEN_CODE                                                                  SPECIMEN_CODE              ,
       A.SURYANG                                                                        SURYANG                    ,
       A.SUNAB_SURYANG                                                                  SUNAB_SURYANG              ,
       A.SUBUL_SURYANG                                                                  SUBUL_SURYANG              ,
       A.ORD_DANUI                                                                      ORD_DANUI                  ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)                                  ORD_DANUI_NAME             ,
       A.SUBUL_DANUI                                                                    SUBUL_DANUI                ,
       A.DV_TIME                                                                        DV_TIME                    ,
       A.DV                                                                             DV                         ,
       A.NALSU                                                                          NALSU                      ,
       A.NALSU                                                                          SUNAB_NALSU                ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('O',A.PKOCS1003)), 0)     BANNAB_SURYANG ,
       A.JUSA                                                                           JUSA                       ,
       A.BOGYONG_CODE                                                                   BOGYONG_CODE               ,
       A.WONYOI_ORDER_YN                                                                WONYOI_ORDER_YN            ,
       NVL(A.DANGIL_GUMSA_ORDER_YN , 'N')                                               DANGIL_GUMSA_ORDER_YN      ,
       NVL(A.DANGIL_GUMSA_RESULT_YN, 'N')                                               DANGIL_GUMSA_RESULT_YN     ,
       A.EMERGENCY                                                                      EMERGENCY                  ,
       A.PAY                                                                            PAY                        ,
       'N'                                                                              FLUID_YN                   ,
       'N'                                                                              TPN_YN                     ,
       A.ANTI_CANCER_YN                                                                 ANTI_CANCER_YN             ,
       A.MUHYO                                                                          MUHYO                      ,
       A.JAERYO_JUNDAL_YN                                                               JAERYO_JUNDAL_YN           ,
       A.PORTABLE_YN                                                                    PORTABLE_YN                ,
       'N'                                                                              SYMYA                      ,
       A.BICHI_YN                                                                       BICHI_YN                   ,
       A.POWDER_YN                                                                      POWDER_YN                  ,
       A.OCS_FLAG                                                                       OCS_FLAG                   ,
       A.ORDER_GUBUN                                                                    ORDER_GUBUN                ,
       NVL(D.CODE_NAME, 'Etc')                                                          ORDER_GUBUN_NAME           ,
       A.AFTER_ACT_YN                                                                   AFTER_ACT_YN               ,
       A.JUNDAL_TABLE                                                                   JUNDAL_TABLE               ,
       A.JUNDAL_PART                                                                    JUNDAL_PART                ,
       A.GROUP_SER                                                                      GROUP_SER                  ,
       A.DV_1                                                                           DV_1                       ,
       A.DV_2                                                                           DV_2                       ,
       A.DV_3                                                                           DV_3                       ,
       A.DV_4                                                                           DV_4                       ,
       A.HOPE_DATE                                                                      HOPE_DATE                  ,
       A.BUNHO                                                                          BUNHO                      ,
       A.ORDER_DATE                                                                     NAEWON_DATE                ,
       A.GWA                                                                            GWA                        ,
       A.DOCTOR                                                                         DOCTOR                     ,
       A.NAEWON_TYPE                                                                    NAEWON_TYPE                ,
       1                                                                                JUBSU_NO                   ,
       A.FKOUT1001                                                                      PK_ORDER                  ,
       A.INPUT_ID                                                                       INPUT_ID                   ,
       A.INPUT_PART                                                                     INPUT_PART                 ,
       A.INPUT_GUBUN                                                                    INPUT_GUBUN                ,
       A.SEQ                                                                            SEQ                        ,
       A.PKOCS1003                                                                      PKOCS1003                  ,
       B.SLIP_CODE                                                                      SLIP_CODE                  ,
       B.GROUP_YN                                                                       GROUP_YN                   ,
       B.SG_CODE                                                                        SG_CODE                    ,
       B.ORDER_GUBUN                                                                    ORDER_GUBUN_BAS            ,
       NVL(B.SUGA_YN,'N')                                                               SUGA_YN                    ,
       NVL(B.JAERYO_YN,'N')                                                             JAERYO_YN                  ,
       NVL(B.NDAY_YN,'N')                                                               NDAY_YN                    ,
       B.INPUT_CONTROL                                                                  INPUT_CONTROL              ,
       A.DC_YN                                                                          DC_YN                      ,
       A.DC_GUBUN                                                                       DC_GUBUN                   ,
       A.BANNAB_YN                                                                      BANNAB_YN                  ,
       A.BANNAB_CONFIRM                                                                 BANNAB_CONFIRM             ,
       A.SOURCE_FKOCS1003                                                               SOURCE_FKOCS1003           ,
       DECODE(A.SUNAB_DATE, NULL, 'N','Y')                                              SUNAB_CHECK                ,
       DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                                            DC_CHECK                   ,
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                               BANNAB_CAN_YN              ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('O',A.PKOCS1003)), 0) BANNAB_CAN_SURYANG ,
       DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE))          BANNAB_DANUI                 ,
       DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE)))
                                                                                                BANNAB_DANUI_NAME  ,
       A.SUNAB_YN                                                                       SUNAB_YN                   ,
       DECODE(A.SUNAB_DATE, NULL, DECODE(A.OCS_FLAG,'2','Y','N'),'N')                   DC_SUNAB_CHECK             ,
       A.NURSE_CONFIRM_USER                                                             NURSE_CONFIRM_USER         ,
       A.NURSE_CONFIRM_DATE                                                             NURSE_CONFIRM_DATE         ,
       A.NURSE_CONFIRM_TIME                                                             NURSE_CONFIRM_TIME         ,
       A.TEL_YN                                                                         TEL_YN                     ,
       FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)                                       SPECIMEN_NAME              ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                                            JUSA_NAME                  ,
       FN_OCS_LOAD_CODE_NAME('PAY',  A.PAY)                                             PAY_NAME                   ,
       FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                      BOGYONG_NAME               ,
       E.BUN_CODE                                                                       BUN_CODE
--       E.SG_GESAN                                                                       SG_GESAN
  FROM OCS1003 A,
       OCS0103 B,
       OCS0132 C,
       OCS0132 D,
       ( SELECT X.SG_CODE
              , X.BUN_CODE
           FROM BAS0310 X
          WHERE X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
                               FROM BAS0310 Z
                              WHERE Z.SG_CODE = X.SG_CODE
                                AND Z.SG_YMD <= TRUNC(SYSDATE) )
       ) E
 WHERE A.FKOUT1001 = :f_fkout1001
   AND (( A.INPUT_GUBUN   = :f_input_gubun       ) OR
        ( :f_input_gubun  = 'D%' AND A.INPUT_GUBUN LIKE :f_input_gubun ))
--   AND NVL(A.OCS_DATA_YN,'Y') = 'Y'
   AND NVL(A.DC_YN,'N')       = 'N'
   AND NVL(A.DISPLAY_YN, 'Y') = 'Y'
   AND A.NALSU                < 0
   AND NVL(A.IO_GUBUN, ' ')  <> 'I'
   AND B.HANGMOG_CODE         = A.HANGMOG_CODE
   AND A.JUNDAL_PART NOT IN ('PA', 'IR')
   AND C.CODE     (+)  = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)  = 'INPUT_GUBUN'
   AND D.CODE     (+)  = A.ORDER_GUBUN
   AND D.CODE_TYPE(+)  = 'ORDER_GUBUN'
   AND E.SG_CODE  (+)  = B.SG_CODE
ORDER BY MIX_GROUP,HANGMOG_CODE ";
            }

            return cmd;
        }

		private void grdOCS1003_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			string filter = "";

			//조회시 
			string dcYn     = "N";
			string bannabYn = "N";

            filter = " bannab_can_yn <> 'Y' ";

			if(grdOCS1003.LayoutTable.Select(filter, "").Length > 0)
			{
				dcYn = "Y";
				rbtDC.Tag = dcYn;
				rbtDC.ForeColor = new XColor(Color.Red);
			}
			else
			{
				if(rbtDC.Checked)
					rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				else
					rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);

				rbtDC.Tag = "N";
			}
            
            //filter =" bannab_can_yn = 'Y' ";
            //if(grdOCS1003.LayoutTable.Select(filter, "").Length > 0)
            //{
            //    bannabYn = "Y";
            //    rbtReturn.Tag = bannabYn;
            //    rbtReturn.ForeColor = new XColor(Color.Red);
            //}
            //else
            //{
            //    if(rbtReturn.Checked)
            //        rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
            //    else
            //        rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);

            //    rbtReturn.Tag = "N";
            //}

            //if( dcYn == "N" && bannabYn == "Y")
            //{
            //    rbtReturn.Checked = true;
            //}
            //else
            //{
            //    rbtDC.Checked = true;
            //    filter =" bannab_can_yn <> 'Y' ";
            //}
            rbtDC.Checked = true;
            filter = " bannab_can_yn <> 'Y' ";

			this.grdOCS1003.ClearFilter();
			if( grdOCS1003.RowCount >0 ) this.grdOCS1003.SetFilter(filter);

			//dloReturn.Reset();
			CreateOrder_gubun();
			tabOrder_gubun.Refresh();
			SelectionBackColorChange(grdOCS1003);
		}
		
		private void layReturnList_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
//			islayReturnList = e.IsSuccess;
//			isSavedReturnList = true;
//			
//			if(isSavedReturnList)
//			{
//				if(islayReturnList)
//				{
//					mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
//					SetMsg(mbxMsg);
//
//					grdOCS1003.QueryLayout(false);
//
//					try
//					{
//						IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	
//
//						CommonItemCollection commandParams  = new CommonItemCollection();
//						commandParams.Add( "retrieve", "Y");
//						scrOpener.Command(this.ScreenID, commandParams);
//					}
//					catch
//					{
//					}
//				}
//				else
//				{
//					mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が失敗しました。" : "처리 실패하였습니다."; 
//					mbxMsg = mbxMsg + e.ErrMsg;
//					mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
//					XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
//				}
//			}

		}

		#endregion

		#region [XSavePerformer Class]
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private OCS1003U01 parent = null;

			//Hashtable inputVal = new Hashtable();
            ArrayList inputList = new ArrayList();
            ArrayList outputList = new ArrayList();

			public XSavePerformer(OCS1003U01 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				bool retVal = false;
				item.BindVarList.Add("f_user_id",UserInfo.UserID);
                string cmdText = "";
                string spName = "";

				switch(item.RowState)	
				{
					case DataRowState.Added :
						break;
					case DataRowState.Modified :

                        if (item.BindVarList["f_cancel_mode_yn"].VarValue != "Y")
                        {

                            inputList.Clear();
                            outputList.Clear();

                            inputList.Add(item.BindVarList["f_pkocs1003"].VarValue);
                            inputList.Add(item.BindVarList["f_user_id"].VarValue);

                            //MessageBox.Show(item.BindVarList["f_pkocs1003"].VarValue);

                            retVal = Service.ExecuteProcedure("PR_OCSO_PROCESS_DOCTOR_CANCEL", inputList, outputList);
                        }
                        else
                        {
                            inputList.Clear();
                            outputList.Clear();
                            inputList.Add("O");
                            inputList.Add(item.BindVarList["f_source_fkocs1003"].VarValue);

                            spName = "PR_OCS_UPDATE_DC_YN";

                            retVal = Service.ExecuteProcedure(spName, inputList, outputList);

                            if (((bool)retVal) == true)
                            {
                                cmdText = @"DELETE FROM OCS1003
                                                 WHERE PKOCS1003 = :f_pkocs1003";

                                retVal = Service.ExecuteNonQuery(cmdText, item.BindVarList);
                            }
                        }
						break;
					case DataRowState.Deleted :
						break;
				}

				return retVal;
			}
		}
		#endregion

	}
}

