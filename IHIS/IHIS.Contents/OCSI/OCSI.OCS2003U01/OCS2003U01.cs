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
	/// OCS2003U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS2003U01 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리		
		private IHIS.OCS.HangmogInfo mHangmogInfo = null;     // OCS 항목정보 그룹 라이브러리
		private IHIS.OCS.InputControl mInputControl = null;   // 입력제어 그룹 라이브러리 
		private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 항목컬럼Control 그룹 라이브러리 
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//등록번호
		private string mBunho = "";
		//입원키
		private int    mFkinp1001;
		//입력구분
		private string mInput_gubun = "";
		//처방일자
		private string mOrder_date = "";
		
		//의사
		private string mDoctor     = "";
		//Resident
		private string mResident   = "";
		//Input_part
		private string mInput_part = "";
		
		//이중유형구분
		private string mDouble_ipwon_type_yn = "N";

		private const string IOEGUBUN = "I"; // 입원		
		private const int    GIJUN_NALSU = 90; // 처방이 가능한 Max일수
		
		private System.Drawing.Color DATAEXISTSTABCOLOR   = Color.Red;
		private System.Drawing.Color DATAUNEXISTSTABCOLOR = Color.Black;

        private bool mIsDoctorMode = false;
		

		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XRadioButton rbtDC;
		private IHIS.Framework.XRadioButton rbtReturn;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGrid grdOCS2003;
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
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
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
		private IHIS.Framework.MultiLayout dloOrder_danui;
		private IHIS.Framework.MultiLayout dloOrder_gubun;
		private IHIS.Framework.XTabControl tabOrder_gubun;
		private IHIS.Framework.MultiLayout dloReturnList;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XEditGridCell xEditGridCell66;
		private IHIS.Framework.XEditGridCell xEditGridCell67;
		private IHIS.Framework.XEditGridCell xEditGridCell74;
		private IHIS.Framework.XEditGridCell xEditGridCell75;
		private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XMstGrid grdOrder_date;
		private IHIS.Framework.XMstGrid grdHangmog_code;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell73;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
		private IHIS.Framework.XEditGridCell xEditGridCell80;
		private IHIS.Framework.XLabel xLabel1;
		private System.Windows.Forms.Panel pnlHangmogSearch;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XComboBox cboPay;
		private IHIS.Framework.XFindBox fbxHangmog_code;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell81;
		private IHIS.Framework.XEditGridCell xEditGridCell82;
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
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
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XComboBox cboNotNurseConfirmSlip;
		private IHIS.Framework.XRadioButton rbtCancel;
		private IHIS.Framework.XRadioButton rbtOrder_date;
		private IHIS.Framework.XDisplayBox dpxOrder_date;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
		private IHIS.Framework.XEditGridCell xEditGridCell96;
		private IHIS.Framework.XEditGridCell xEditGridCell98;
		private IHIS.Framework.XEditGridCell xEditGridCell99;
		private IHIS.Framework.XEditGridCell xEditGridCell100;
		private IHIS.Framework.XEditGridCell xEditGridCell101;
		private IHIS.Framework.XEditGridCell xEditGridCell102;
		private IHIS.Framework.XEditGridCell xEditGridCell103;
		private IHIS.Framework.XEditGridCell xEditGridCell104;
		private IHIS.Framework.XEditGridCell xEditGridCell105;
		private IHIS.Framework.XEditGridCell xEditGridCell106;
		private IHIS.Framework.XEditGridCell xEditGridCell107;
		private IHIS.Framework.XEditGridCell xEditGridCell108;
		private IHIS.Framework.XEditGridCell xEditGridCell109;
		private IHIS.Framework.XEditGridCell xEditGridCell110;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private XEditGridCell xEditGridCell34;
        private ImageList imageListMixGroup;
        private XEditGridCell xEditGridCell35;
        private IContainer components;

		public OCS2003U01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
			this.mOrderFunc = new IHIS.OCS.OrderFunc();                     // OCS 그룹 Function 라이브러리			
			this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.ScreenID);    // OCS 항목정보 그룹 라이브러리
			this.mInputControl = new IHIS.OCS.InputControl(this.ScreenID);  // 입력제어 그룹 라이브러리 
			this.mColumnControl = new IHIS.OCS.ColumnControl(this.ScreenID);// OCS 항목컬럼Control 그룹 라이브러리 

			this.dloReturnList.SavePerformer = new XSavePerformer(this);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2003U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dpxOrder_date = new IHIS.Framework.XDisplayBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.rbtReturn = new IHIS.Framework.XRadioButton();
            this.rbtDC = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdHangmog_code = new IHIS.Framework.XMstGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.grdOrder_date = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.rbtCancel = new IHIS.Framework.XRadioButton();
            this.rbtOrder_date = new IHIS.Framework.XRadioButton();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdOCS2003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.tabOrder_gubun = new IHIS.Framework.XTabControl();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.cboNotNurseConfirmSlip = new IHIS.Framework.XComboBox();
            this.pnlHangmogSearch = new System.Windows.Forms.Panel();
            this.cboPay = new IHIS.Framework.XComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.fbxHangmog_code = new IHIS.Framework.XFindBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.dloOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.dloOrder_gubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.dloReturnList = new IHIS.Framework.MultiLayout();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder_date)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.pnlHangmogSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_gubun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "Plus.ico");
            this.ImageList.Images.SetKeyName(3, "오른쪽_회색1.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.dpxOrder_date);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 30);
            this.xPanel1.TabIndex = 10;
            // 
            // dpxOrder_date
            // 
            this.dpxOrder_date.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dpxOrder_date.Location = new System.Drawing.Point(90, 6);
            this.dpxOrder_date.Name = "dpxOrder_date";
            this.dpxOrder_date.Size = new System.Drawing.Size(92, 19);
            this.dpxOrder_date.TabIndex = 8;
            this.dpxOrder_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(2, 6);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(88, 19);
            this.xLabel5.TabIndex = 6;
            this.xLabel5.Text = "オ―ダ日付";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtReturn
            // 
            this.rbtReturn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtReturn.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtReturn.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtReturn.ImageIndex = 0;
            this.rbtReturn.ImageList = this.ImageList;
            this.rbtReturn.Location = new System.Drawing.Point(110, 2);
            this.rbtReturn.Name = "rbtReturn";
            this.rbtReturn.Size = new System.Drawing.Size(112, 26);
            this.rbtReturn.TabIndex = 9;
            this.rbtReturn.Text = "      オ―ダ返却";
            this.rbtReturn.UseVisualStyleBackColor = false;
            // 
            // rbtDC
            // 
            this.rbtDC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtDC.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtDC.Checked = true;
            this.rbtDC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtDC.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtDC.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtDC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtDC.ImageIndex = 1;
            this.rbtDC.ImageList = this.ImageList;
            this.rbtDC.Location = new System.Drawing.Point(2, 2);
            this.rbtDC.Name = "rbtDC";
            this.rbtDC.Size = new System.Drawing.Size(106, 26);
            this.rbtDC.TabIndex = 0;
            this.rbtDC.TabStop = true;
            this.rbtDC.Text = "      オ―ダ取消";
            this.rbtDC.UseVisualStyleBackColor = false;
            this.rbtDC.CheckedChanged += new System.EventHandler(this.rbtDC_CheckedChanged);
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
            this.xButtonList1.Location = new System.Drawing.Point(787, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdHangmog_code);
            this.xPanel3.Controls.Add(this.grdOrder_date);
            this.xPanel3.Controls.Add(this.xPanel5);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(0, 30);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(178, 522);
            this.xPanel3.TabIndex = 12;
            // 
            // grdHangmog_code
            // 
            this.grdHangmog_code.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell12,
            this.xEditGridCell73,
            this.xEditGridCell76,
            this.xEditGridCell18,
            this.xEditGridCell80,
            this.xEditGridCell46,
            this.xEditGridCell2});
            this.grdHangmog_code.ColPerLine = 2;
            this.grdHangmog_code.Cols = 2;
            this.grdHangmog_code.EnableMultiSelection = true;
            this.grdHangmog_code.FixedRows = 1;
            this.grdHangmog_code.HeaderHeights.Add(21);
            this.grdHangmog_code.ImageList = this.ImageList;
            this.grdHangmog_code.Location = new System.Drawing.Point(30, 210);
            this.grdHangmog_code.Name = "grdHangmog_code";
            this.grdHangmog_code.QuerySQL = resources.GetString("grdHangmog_code.QuerySQL");
            this.grdHangmog_code.ReadOnly = true;
            this.grdHangmog_code.Rows = 2;
            this.grdHangmog_code.RowStateCheckOnPaint = false;
            this.grdHangmog_code.Size = new System.Drawing.Size(120, 202);
            this.grdHangmog_code.TabIndex = 3;
            this.grdHangmog_code.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdHangmog_code_RowFocusChanged);
            this.grdHangmog_code.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmog_code_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "bunho";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "fkinp1001";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "fkinp1001";
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell73.CellName = "hangmog_code";
            this.xEditGridCell73.HeaderText = "項目コード";
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell73.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell76.CellName = "hangmog_name";
            this.xEditGridCell76.Col = 1;
            this.xEditGridCell76.HeaderText = "項目コード名";
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell76.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pk_hangmog";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "pk_hangmog";
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "pay";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "pay";
            this.xEditGridCell80.IsUpdatable = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "input_gubun";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.HeaderText = "input_gubun";
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "order_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "order_date";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // grdOrder_date
            // 
            this.grdOrder_date.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdOrder_date.ColPerLine = 1;
            this.grdOrder_date.Cols = 2;
            this.grdOrder_date.EnableMultiSelection = true;
            this.grdOrder_date.FixedCols = 1;
            this.grdOrder_date.FixedRows = 1;
            this.grdOrder_date.HeaderHeights.Add(21);
            this.grdOrder_date.ImageList = this.ImageList;
            this.grdOrder_date.Location = new System.Drawing.Point(12, 48);
            this.grdOrder_date.Name = "grdOrder_date";
            this.grdOrder_date.QuerySQL = resources.GetString("grdOrder_date.QuerySQL");
            this.grdOrder_date.ReadOnly = true;
            this.grdOrder_date.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOrder_date.RowHeaderVisible = true;
            this.grdOrder_date.Rows = 2;
            this.grdOrder_date.RowStateCheckOnPaint = false;
            this.grdOrder_date.Size = new System.Drawing.Size(120, 202);
            this.grdOrder_date.TabIndex = 1;
            this.grdOrder_date.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOrder_date_RowFocusChanged);
            this.grdOrder_date.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrder_date_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "order_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "オ―ダ日付";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
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
            this.xEditGridCell6.CellName = "fkinp1001";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "fkinp1001";
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
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pk_order_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "pk_order_date";
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
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.rbtCancel);
            this.xPanel5.Controls.Add(this.rbtOrder_date);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(176, 30);
            this.xPanel5.TabIndex = 2;
            // 
            // rbtCancel
            // 
            this.rbtCancel.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtCancel.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtCancel.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtCancel.ImageIndex = 0;
            this.rbtCancel.Location = new System.Drawing.Point(88, 2);
            this.rbtCancel.Name = "rbtCancel";
            this.rbtCancel.Size = new System.Drawing.Size(85, 26);
            this.rbtCancel.TabIndex = 10;
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
            this.rbtOrder_date.Location = new System.Drawing.Point(2, 2);
            this.rbtOrder_date.Name = "rbtOrder_date";
            this.rbtOrder_date.Size = new System.Drawing.Size(85, 26);
            this.rbtOrder_date.TabIndex = 1;
            this.rbtOrder_date.TabStop = true;
            this.rbtOrder_date.Text = "オーダ日付";
            this.rbtOrder_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtOrder_date.UseVisualStyleBackColor = false;
            this.rbtOrder_date.CheckedChanged += new System.EventHandler(this.rbtOrder_date_CheckedChanged);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdOCS2003);
            this.xPanel4.Controls.Add(this.tabOrder_gubun);
            this.xPanel4.Controls.Add(this.xPanel6);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(178, 30);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(782, 522);
            this.xPanel4.TabIndex = 13;
            // 
            // grdOCS2003
            // 
            this.grdOCS2003.AddedHeaderLine = 1;
            this.grdOCS2003.ApplyPaintEventToAllColumn = true;
            this.grdOCS2003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell68,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell31,
            this.xEditGridCell99,
            this.xEditGridCell24,
            this.xEditGridCell55,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell10,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell17,
            this.xEditGridCell81,
            this.xEditGridCell38,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell13,
            this.xEditGridCell51,
            this.xEditGridCell86,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell11,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell19,
            this.xEditGridCell56,
            this.xEditGridCell65,
            this.xEditGridCell96,
            this.xEditGridCell98,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell47,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell52,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell43,
            this.xEditGridCell94,
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
            this.xEditGridCell95,
            this.xEditGridCell50,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell74,
            this.xEditGridCell105,
            this.xEditGridCell75,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell110,
            this.xEditGridCell34,
            this.xEditGridCell79,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell4,
            this.xEditGridCell35});
            this.grdOCS2003.ColPerLine = 31;
            this.grdOCS2003.Cols = 32;
            this.grdOCS2003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS2003.EnableMultiSelection = true;
            this.grdOCS2003.FixedCols = 1;
            this.grdOCS2003.FixedRows = 2;
            this.grdOCS2003.HeaderHeights.Add(39);
            this.grdOCS2003.HeaderHeights.Add(0);
            this.grdOCS2003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS2003.Location = new System.Drawing.Point(0, 54);
            this.grdOCS2003.Name = "grdOCS2003";
            this.grdOCS2003.QuerySQL = resources.GetString("grdOCS2003.QuerySQL");
            this.grdOCS2003.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS2003.RowHeaderVisible = true;
            this.grdOCS2003.Rows = 3;
            this.grdOCS2003.RowStateCheckOnPaint = false;
            this.grdOCS2003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS2003.Size = new System.Drawing.Size(780, 466);
            this.grdOCS2003.TabIndex = 4;
            this.grdOCS2003.ToolTipActive = true;
            this.grdOCS2003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS2003_MouseDown);
            this.grdOCS2003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2003_QueryEnd);
            this.grdOCS2003.GridFilterChanged += new System.EventHandler(this.grdOCS2003_GridFilterChanged);
            this.grdOCS2003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2003_QueryStarting);
            this.grdOCS2003.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS2003_GridColumnProtectModify);
            this.grdOCS2003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS2003_GridColumnChanged);
            this.grdOCS2003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS2003_GridCellPainting);
            this.grdOCS2003.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS2003_GridFindClick);
            this.grdOCS2003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS2003_RowFocusChanged);
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
            this.xEditGridCell20.CellWidth = 81;
            this.xEditGridCell20.Col = 6;
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
            this.xEditGridCell21.CellWidth = 191;
            this.xEditGridCell21.Col = 7;
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
            this.xEditGridCell22.CellWidth = 31;
            this.xEditGridCell22.Col = 8;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
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
            this.xEditGridCell23.CellWidth = 48;
            this.xEditGridCell23.Col = 9;
            this.xEditGridCell23.DecimalDigits = 2;
            this.xEditGridCell23.HeaderText = "数量";
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
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
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "ord_danui";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.HeaderText = "ord_danui";
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellLen = 100;
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 60;
            this.xEditGridCell24.Col = 10;
            this.xEditGridCell24.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell24.HeaderText = "単位";
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
            this.xEditGridCell25.CellWidth = 31;
            this.xEditGridCell25.Col = 11;
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell25.HeaderText = "dv_time";
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell26.CellWidth = 30;
            this.xEditGridCell26.Col = 12;
            this.xEditGridCell26.HeaderText = "dv";
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell27.CellWidth = 30;
            this.xEditGridCell27.Col = 13;
            this.xEditGridCell27.HeaderText = "日数";
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellName = "bannab_hoisu";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.CellWidth = 68;
            this.xEditGridCell10.Col = 14;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell10.HeaderForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell10.HeaderText = "返却回数";
            this.xEditGridCell10.RowSpan = 2;
            this.xEditGridCell10.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "jusa";
            this.xEditGridCell28.CellWidth = 34;
            this.xEditGridCell28.Col = 16;
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
            this.xEditGridCell29.CellWidth = 39;
            this.xEditGridCell29.Col = 17;
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
            this.xEditGridCell30.CellWidth = 36;
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell30.HeaderText = "院\r\n外";
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 24;
            this.xEditGridCell32.Col = 18;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.HeaderText = "緊\r\n急";
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "pay";
            this.xEditGridCell33.CellWidth = 35;
            this.xEditGridCell33.Col = 19;
            this.xEditGridCell33.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell33.HeaderText = "請求\r\n区分";
            this.xEditGridCell33.RowSpan = 2;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "anti_cancer_yn";
            this.xEditGridCell36.CellWidth = 42;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderText = "抗癌剤";
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "muhyo";
            this.xEditGridCell37.CellWidth = 22;
            this.xEditGridCell37.Col = 23;
            this.xEditGridCell37.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell37.HeaderText = "無\r\n効";
            this.xEditGridCell37.RowSpan = 2;
            this.xEditGridCell37.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
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
            // xEditGridCell81
            // 
            this.xEditGridCell81.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell81.CellName = "toiwon_drg_yn";
            this.xEditGridCell81.CellWidth = 45;
            this.xEditGridCell81.Col = 28;
            this.xEditGridCell81.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell81.HeaderText = "退院薬";
            this.xEditGridCell81.RowSpan = 2;
            this.xEditGridCell81.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "portable_yn";
            this.xEditGridCell38.CellWidth = 48;
            this.xEditGridCell38.Col = 21;
            this.xEditGridCell38.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell38.HeaderText = "移動\r\n撮影";
            this.xEditGridCell38.RowSpan = 2;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell82.CellLen = 1;
            this.xEditGridCell82.CellName = "prn_yn";
            this.xEditGridCell82.CellWidth = 31;
            this.xEditGridCell82.Col = 31;
            this.xEditGridCell82.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell82.HeaderText = "P\r\nR\r\nN";
            this.xEditGridCell82.RowSpan = 2;
            this.xEditGridCell82.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "doner_yn";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.HeaderText = "doner_yn";
            this.xEditGridCell83.IsUpdatable = false;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell84.CellName = "append_yn";
            this.xEditGridCell84.CellWidth = 23;
            this.xEditGridCell84.Col = 29;
            this.xEditGridCell84.HeaderText = "追\r\n加";
            this.xEditGridCell84.RowSpan = 2;
            this.xEditGridCell84.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell85.CellName = "tel_yn";
            this.xEditGridCell85.CellWidth = 27;
            this.xEditGridCell85.Col = 30;
            this.xEditGridCell85.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell85.HeaderText = "TEL";
            this.xEditGridCell85.RowSpan = 2;
            this.xEditGridCell85.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 1;
            this.xEditGridCell13.CellName = "bichi_yn";
            this.xEditGridCell13.CellWidth = 22;
            this.xEditGridCell13.Col = 22;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell13.HeaderText = "配\r\n置";
            this.xEditGridCell13.RowSpan = 2;
            this.xEditGridCell13.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "power_yn";
            this.xEditGridCell51.CellWidth = 26;
            this.xEditGridCell51.Col = 20;
            this.xEditGridCell51.HeaderText = "粉\r\n薬";
            this.xEditGridCell51.RowSpan = 2;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "error_flag";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.HeaderText = "error_flag";
            this.xEditGridCell86.IsUpdatable = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
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
            this.xEditGridCell11.CellWidth = 67;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.HeaderText = "オーダ\r\n区分";
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.RowSpan = 2;
            this.xEditGridCell11.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.SuppressRepeating = true;
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
            this.xEditGridCell45.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.CellWidth = 79;
            this.xEditGridCell45.Col = 26;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell45.HeaderText = "実行\r\n部署";
            this.xEditGridCell45.RowSpan = 2;
            this.xEditGridCell45.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
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
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "dv_1";
            this.xEditGridCell56.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.HeaderText = "dv_1";
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "dv_2";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.HeaderText = "dv_2";
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "dv_3";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.HeaderText = "dv_3";
            this.xEditGridCell96.IsUpdatable = false;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "dv_4";
            this.xEditGridCell98.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.HeaderText = "dv_4";
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell108.CellName = "order_remark";
            this.xEditGridCell108.Col = 24;
            this.xEditGridCell108.DisplayMemoText = true;
            this.xEditGridCell108.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell108.HeaderText = "Comment";
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsUpdCol = false;
            this.xEditGridCell108.RowSpan = 2;
            this.xEditGridCell108.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell109.CellName = "nurse_remark";
            this.xEditGridCell109.Col = 25;
            this.xEditGridCell109.DisplayMemoText = true;
            this.xEditGridCell109.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell109.HeaderText = "看護\r\nComment";
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsUpdCol = false;
            this.xEditGridCell109.RowSpan = 2;
            this.xEditGridCell109.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
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
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "fkinp1001";
            this.xEditGridCell87.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.HeaderText = "fkinp1001";
            this.xEditGridCell87.IsUpdatable = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell88.CellName = "order_date";
            this.xEditGridCell88.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell88.Col = 2;
            this.xEditGridCell88.HeaderText = "オーダ日付";
            this.xEditGridCell88.IsUpdatable = false;
            this.xEditGridCell88.RowSpan = 2;
            this.xEditGridCell88.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell88.SuppressRepeating = true;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell89.CellName = "double_ipwon_type";
            this.xEditGridCell89.CellWidth = 32;
            this.xEditGridCell89.Col = 27;
            this.xEditGridCell89.HeaderText = "他\r\n保険";
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.RowSpan = 2;
            this.xEditGridCell89.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "double_ipwon_type_yn";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.HeaderText = "double_ipwon_type_yn";
            this.xEditGridCell90.IsUpdatable = false;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
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
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "pk_order_bannab";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.HeaderText = "pk_order_bannab";
            this.xEditGridCell91.IsUpdatable = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "pk_order_bannab_order";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.HeaderText = "pk_order_bannab_order";
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "pk_hangmog_order";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.HeaderText = "pk_hangmog_order";
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "pk_hangmog_order_bannab";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.HeaderText = "pk_hangmog_order_bannab";
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "pk_hangmog_order_bannab_order";
            this.xEditGridCell94.Col = -1;
            this.xEditGridCell94.HeaderText = "pk_hangmog_order_bannab_order";
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.IsVisible = false;
            this.xEditGridCell94.Row = -1;
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
            this.xEditGridCell42.CellName = "input_gubun";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.HeaderText = "input_gubun";
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
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
            this.xEditGridCell54.CellName = "pkocs2003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.HeaderText = "pkocs2003";
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
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "default_jaeryo_jundal_yn";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.HeaderText = "default_jaeryo_jundal_yn";
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "input_control";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.HeaderText = "input_control";
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
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
            this.xEditGridCell64.CellName = "source_fkocs2003";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.HeaderText = "source_fkocs2003";
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
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
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "bannab_danui";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.HeaderText = "bannab_danui";
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell75.CellName = "bannab_danui_name";
            this.xEditGridCell75.CellWidth = 67;
            this.xEditGridCell75.Col = 15;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell75.HeaderForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xEditGridCell75.HeaderText = "返却単位";
            this.xEditGridCell75.IsUpdatable = false;
            this.xEditGridCell75.RowSpan = 2;
            this.xEditGridCell75.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "sunab_date";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.HeaderText = "sunab_date";
            this.xEditGridCell77.IsUpdatable = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "confirm_check";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.HeaderText = "confirm_check";
            this.xEditGridCell78.IsUpdatable = false;
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "specimen_name";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.HeaderText = "specimen_name";
            this.xEditGridCell101.IsUpdatable = false;
            this.xEditGridCell101.IsUpdCol = false;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "jusa_name";
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.HeaderText = "jusa_name";
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.IsUpdCol = false;
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "pay_name";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.HeaderText = "pay_name";
            this.xEditGridCell103.IsUpdatable = false;
            this.xEditGridCell103.IsUpdCol = false;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "bogyong_name";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.HeaderText = "bogyong_name";
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsUpdCol = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "bun_code";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.HeaderText = "bun_code";
            this.xEditGridCell106.IsUpdatable = false;
            this.xEditGridCell106.IsUpdCol = false;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "sg_gesan";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.HeaderText = "sg_gesan";
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.IsUpdCol = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell110.CellName = "input_gubun_name";
            this.xEditGridCell110.CellWidth = 64;
            this.xEditGridCell110.Col = 3;
            this.xEditGridCell110.HeaderText = "入力\r\n区分";
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsUpdCol = false;
            this.xEditGridCell110.RowSpan = 2;
            this.xEditGridCell110.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell110.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell110.SuppressRepeating = true;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell34.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell34.CellName = "child_yn";
            this.xEditGridCell34.CellWidth = 25;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.IsReadOnly = true;
            this.xEditGridCell34.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell34.RowSpan = 2;
            this.xEditGridCell34.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "dc_order_yn";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.HeaderText = "dc_order_yn";
            this.xEditGridCell79.IsUpdatable = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "doctor";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.HeaderText = "doctor";
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "resident";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.HeaderText = "resident";
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "select";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.HeaderText = "選択";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "cancel_mode_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.HeaderText = "cancel_mode_yn";
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 11;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 31;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // tabOrder_gubun
            // 
            this.tabOrder_gubun.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabOrder_gubun.IDEPixelArea = true;
            this.tabOrder_gubun.IDEPixelBorder = false;
            this.tabOrder_gubun.ImageList = this.ImageList;
            this.tabOrder_gubun.Location = new System.Drawing.Point(0, 30);
            this.tabOrder_gubun.Name = "tabOrder_gubun";
            this.tabOrder_gubun.Size = new System.Drawing.Size(780, 24);
            this.tabOrder_gubun.TabIndex = 2;
            this.tabOrder_gubun.SelectionChanged += new System.EventHandler(this.tabOrder_gubun_SelectionChanged);
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.cboNotNurseConfirmSlip);
            this.xPanel6.Controls.Add(this.pnlHangmogSearch);
            this.xPanel6.Controls.Add(this.rbtDC);
            this.xPanel6.Controls.Add(this.rbtReturn);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.Location = new System.Drawing.Point(0, 0);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(780, 30);
            this.xPanel6.TabIndex = 5;
            // 
            // cboNotNurseConfirmSlip
            // 
            this.cboNotNurseConfirmSlip.Location = new System.Drawing.Point(280, 6);
            this.cboNotNurseConfirmSlip.Name = "cboNotNurseConfirmSlip";
            this.cboNotNurseConfirmSlip.Size = new System.Drawing.Size(61, 21);
            this.cboNotNurseConfirmSlip.TabIndex = 25;
            this.cboNotNurseConfirmSlip.Visible = false;
            // 
            // pnlHangmogSearch
            // 
            this.pnlHangmogSearch.Controls.Add(this.cboPay);
            this.pnlHangmogSearch.Controls.Add(this.xLabel2);
            this.pnlHangmogSearch.Controls.Add(this.fbxHangmog_code);
            this.pnlHangmogSearch.Controls.Add(this.xLabel1);
            this.pnlHangmogSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHangmogSearch.Location = new System.Drawing.Point(546, 0);
            this.pnlHangmogSearch.Name = "pnlHangmogSearch";
            this.pnlHangmogSearch.Size = new System.Drawing.Size(234, 30);
            this.pnlHangmogSearch.TabIndex = 11;
            // 
            // cboPay
            // 
            this.cboPay.Location = new System.Drawing.Point(296, 4);
            this.cboPay.Name = "cboPay";
            this.cboPay.Size = new System.Drawing.Size(108, 21);
            this.cboPay.TabIndex = 13;
            this.cboPay.Visible = false;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(236, 5);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(58, 20);
            this.xLabel2.TabIndex = 12;
            this.xLabel2.Text = "給与";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel2.Visible = false;
            // 
            // fbxHangmog_code
            // 
            this.fbxHangmog_code.AutoTabDataSelected = true;
            this.fbxHangmog_code.Location = new System.Drawing.Point(97, 5);
            this.fbxHangmog_code.Name = "fbxHangmog_code";
            this.fbxHangmog_code.Size = new System.Drawing.Size(131, 20);
            this.fbxHangmog_code.TabIndex = 11;
            this.fbxHangmog_code.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHangmog_code_DataValidating);
            this.fbxHangmog_code.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxHangmog_code_FindClick);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(6, 5);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(88, 20);
            this.xLabel1.TabIndex = 10;
            this.xLabel1.Text = "項目コード";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // dloOrder_danui
            // 
            this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            // dloOrder_gubun
            // 
            this.dloOrder_gubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            // dloReturnList
            // 
            this.dloReturnList.CallerID = '3';
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "wonyoi_order_yn";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.HeaderText = "wonyoi_order_yn";
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.IsUpdCol = false;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "20.gif");
            this.imageListMixGroup.Images.SetKeyName(1, "1.gif");
            this.imageListMixGroup.Images.SetKeyName(2, "2.gif");
            this.imageListMixGroup.Images.SetKeyName(3, "3.gif");
            this.imageListMixGroup.Images.SetKeyName(4, "4.gif");
            this.imageListMixGroup.Images.SetKeyName(5, "5.gif");
            this.imageListMixGroup.Images.SetKeyName(6, "6.gif");
            this.imageListMixGroup.Images.SetKeyName(7, "7.gif");
            this.imageListMixGroup.Images.SetKeyName(8, "8.gif");
            this.imageListMixGroup.Images.SetKeyName(9, "9.gif");
            this.imageListMixGroup.Images.SetKeyName(10, "10.gif");
            this.imageListMixGroup.Images.SetKeyName(11, "11.gif");
            this.imageListMixGroup.Images.SetKeyName(12, "12.gif");
            this.imageListMixGroup.Images.SetKeyName(13, "13.gif");
            this.imageListMixGroup.Images.SetKeyName(14, "14.gif");
            this.imageListMixGroup.Images.SetKeyName(15, "15.gif");
            this.imageListMixGroup.Images.SetKeyName(16, "16.gif");
            this.imageListMixGroup.Images.SetKeyName(17, "17.gif");
            this.imageListMixGroup.Images.SetKeyName(18, "18.gif");
            this.imageListMixGroup.Images.SetKeyName(19, "19.gif");
            // 
            // OCS2003U01
            // 
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS2003U01";
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder_date)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.pnlHangmogSearch.ResumeLayout(false);
            this.pnlHangmogSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_gubun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			switch (command)
			{				
				case "OCS0103Q00": //항목검색

					#region
					if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null && 
						((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
					{
						//  항목검색인 FindBox로 처리한 건이기 때문에 현재 Focus에 있는 코드부터 세팅한다
						fbxHangmog_code.SetEditValue(((MultiLayout)commandParam["OCS0103"]).GetItemString(0, "hangmog_code"));
					}

					break;
					#endregion
			}		
	
			if(command == "F") return base.Command (command, commandParam);	
			
			return base.Command (command, commandParam);
		}

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);

            if (this.Opener is XScreen)
            {
                // 외래 오더 메인이고 유저가 닥터이고 현재 시스템이 OCSI 이면 닥터모드로...
                if (((XScreen)this.Opener).Name == "OCS2003P01")
                {
                    if (UserInfo.UserGubun == UserType.Doctor && EnvironInfo.CurrSystemID == "OCSI")
                    {
                        this.mIsDoctorMode = true;
                    }
                }
            }
			
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
						return;
					}

					if(OpenParam.Contains("fkinp1001"))
					{
						if(!TypeCheck.IsInt(OpenParam["fkinp1001"].ToString()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が正確ではないです. 確認してください." : "입원정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);	
							mBunho = "";
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

					if(OpenParam.Contains("doctor"))
					{
						if(TypeCheck.IsNull(OpenParam["doctor"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "医師情報が正確ではないです. 確認してください." : "의사정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							mBunho = "";
							return;
						}
						else
						{
							mDoctor   = OpenParam["doctor"].ToString().Trim();
							mResident = OpenParam["doctor"].ToString().Trim();
						}
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "医師情報が正確ではないです. 確認してください." : "입력구분이 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);							
						return;
					}	
		
					if(OpenParam.Contains("input_part"))
					{
						if(TypeCheck.IsNull(OpenParam["input_part"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入力部署が正確ではないです. 確認してください." : "입력부서가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
							XMessageBox.Show(mbxMsg, mbxCap);
							mBunho = "";
							return;
						}
						else
							mInput_part = OpenParam["input_part"].ToString().Trim();
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入力部署が正確ではないです. 確認してください." : "입력부서가 정확하지않습니다. 확인바랍니다.";
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
							mBunho = "";
							return;
						}
						else
						{
							//임시
							if( OpenParam["input_gubun"].ToString().Substring(0, 1) == "D" )
								mInput_gubun = "D%";
							else
                                mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
						}
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入力区分が正確ではないです. 確認してください." : "입력구분이 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);							
						return;
					}					
					
					mOrder_date = DateTime.Now.ToString("yyyy/MM/dd");
					if(OpenParam.Contains("order_date"))
					{
						if(TypeCheck.IsDateTime(OpenParam["order_date"].ToString()))
							mOrder_date = OpenParam["order_date"].ToString();
					}
					dpxOrder_date.SetDataValue(mOrder_date);

					mDouble_ipwon_type_yn = "N";
					if(OpenParam.Contains("double_ipwon_type_yn"))
					{
						if(TypeCheck.IsNull(OpenParam["double_ipwon_type_yn"].ToString().Trim()))
							mDouble_ipwon_type_yn = OpenParam["double_ipwon_type_yn"].ToString();
					}

				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");
					mBunho = "";	
				}
			}
			else
			{				
				mBunho = "00400032";
				mFkinp1001 = 38259;
				mOrder_date = DateTime.Now.ToString("yyyy/MM/dd");				
				dpxOrder_date.SetDataValue(mOrder_date);
				mInput_part = "01";
				mInput_gubun = "D0";
				mDoctor = "01006";
				mResident = "01006";
				mDouble_ipwon_type_yn = "N";
			}
            
			//처방일자는 숨긴다.
			//this.grdOCS2003.AutoSizeColumn(2, 0); //
            
			//DC일때는 반납수량을 표시하지 않는다.
			this.grdOCS2003.AutoSizeColumn(14, 0);//
			this.grdOCS2003.AutoSizeColumn(15, 0);//
			
			PostCallHelper.PostCall(new PostMethod(PostLoad));	
		}        
		
		private void PostLoad()
		{	
			if(mBunho.Trim() == "")
				this.Close();

			InitialDesign();

			//처방구분
			LoadBaseData();

			//comboBox생성
			CreateCombo();
            
			//Create ReturnValue
			CreateLayout();
			
		
			this.grdOrder_date.QueryLayout(true);
			
		
						
		} 
  	
		/// <summary>
		/// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
		/// </summary>
		private void InitialDesign()
		{
			rbtDC.Tag = "N";
			rbtReturn.Tag = "N";
			//Fixed column 설정
			this.grdOCS2003.FixedCols = 5; 
          
			// Dock 처리
			this.grdOrder_date.Dock = DockStyle.Fill;			
			this.grdHangmog_code.Dock = DockStyle.Fill;	
		
			grdHangmog_code.Visible = false;
            //pnlHangmogSearch.Visible = false;
			rbtDC.Checked = true;
		}

		/// <summary>
		/// 기준정보 DataLayout생성
		/// </summary>
		private void LoadBaseData()
		{
			//Order 단위
			dloOrder_gubun.QuerySQL 
				= " SELECT CODE, CODE_NAME "
				+ "   FROM OCS0132 "
				+ "  WHERE CODE_TYPE = 'ORDER_GUBUN' "
				+ "  ORDER BY CODE ";

			dloOrder_gubun.QueryLayout(true);
		}

		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{	
			//bool updFlag = false;
			//OCS2003
			foreach(XEditGridCell cell in this.grdOCS2003.CellInfos)
			{
				dloReturnList.LayoutItems.Add(cell.CellName, (DataType)cell.CellType, false, cell.IsUpdCol);
			}

			dloReturnList.InitializeLayoutTable();		
		}

		
		#endregion

		#region [GetFindWorker]

		private XFindWorker GetFindWorker(string findMode)
		{
			XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
			
			switch (findMode)
			{	
				case "sang_code":
                    
					fdwCommon.AutoQuery = true;					
					fdwCommon.InputSQL = "SELECT A.SANG_CODE, A.SANG_NAME "   
						+ "  FROM CHT0110 A ";
                    
					fdwCommon.FormText = "傷病コード照会";
					fdwCommon.ColInfos.Add("sang_code", "傷病コード", FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("sang_name", "傷病コード名", FindColType.String, 300, 0, true, FilterType.No);

					break;

				case "specimen_code":
                    
					fdwCommon.AutoQuery = true;
					fdwCommon.InputSQL = " SELECT A.SPECIMEN_CODE, A.SPECIMEN_NAME "
						+ "   FROM OCS0116 A ";
                    
					fdwCommon.FormText = "検体コード照会";
					fdwCommon.ColInfos.Add("specimen_code", "検体コード", FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("specimen_name", "検体コード名", FindColType.String, 300, 0, true, FilterType.No);

					break;	

				case "bogyong_code":
                    
					fdwCommon.AutoQuery = true;
					fdwCommon.InputSQL = " SELECT A.BOGYONG_CODE, A.BOGYONG_NAME "
						+ " FROM DRG0120 A ";
                    
					fdwCommon.FormText = "服用コード照会";
					fdwCommon.ColInfos.Add("bogyong_code", "服用コード", FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("bogyong_name", "服用コード名", FindColType.String, 300, 0, true, FilterType.No);

					break;
			    
				default:					
					break;
			}

			return fdwCommon;
		}


		#endregion

		#region [Load Code Name]
        
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";
			string cmdText = "";
			object retVal = "";

			if(code.Trim() == "" ) return codeName;

			switch (codeMode)
			{

				case "specimen_code":
          
					cmdText
						= " SELECT SPECIMEN_NAME "
						+ "   FROM OCS0116 "
						+ "  WHERE SPECIMEN_CDDE = '" + code + "' ";
					
					retVal = Service.ExecuteScalar(cmdText);

					if( retVal != null )
						codeName = retVal.ToString();
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "検体コードが正確ではないです. 確認してください." : "검체코드가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
					}
					break;

				case "wonnae_sayu_code":

					cmdText
						= " SELECT A.WONNAE_SAYU_NAME "
						+ "   FROM BAS0401 A "
						+ "  WHERE A.WONNAE_SAYU_CODE = '" + code + "'"
						+ "    AND A.OCS_DISP_YN      = 'Y'";

					retVal = Service.ExecuteScalar(cmdText);

					if( retVal != null )
						codeName = retVal.ToString();
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "院外理由コードが正確ではないです. 確認してください." : "원외사유코드가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);						
					}
					                    
					break;
				
				case "bogyong_code":

					cmdText 
						= " SELECT A.BOGYONG_NAME "
						+ " FROM DRG0120 A "
						+ " WHERE A.BOGYONG_CODE '" + code + "'"
						+ "   AND A.BUNRYU1 IN('C','D') ";

					retVal = Service.ExecuteScalar(cmdText);

					if( retVal != null )
						codeName = retVal.ToString();
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "服用コードが正確ではないです. 確認してください." : "복용코드가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);						
					}
					
					break;	

				case "doctor":

					cmdText
						= " SELECT DOCTOR_NAME "
						+ " FROM BAS0270 A "
						+ " WHERE A.DOCTOR '" + code + "'";
					
					retVal = Service.ExecuteScalar(cmdText);

					if( retVal != null )
						codeName = retVal.ToString();
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "医師コードが正確ではないです. 確認してください." : "의사코드가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);						
					}

					break;	

				default:
					break;
			}

			return codeName;
		}

		#endregion

		#region [Combo 생성]
		
		private void CreateCombo()
		{	

			// Combo 세팅
			DataTable dtTemp = null;

			// 간호Confirm을 하지않는 특정Slip코드정보
			dtTemp  = this.mOrderBiz.LoadComboDataSource("NOT_CONFIRM_SLIP").LayoutTable;
			this.cboNotNurseConfirmSlip.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);

			// 급여구분
			dtTemp  = this.mOrderBiz.LoadComboDataSource("pay").LayoutTable;
			this.grdOCS2003.SetListItems("pay", dtTemp, "code", "code", XComboSetType.NoAppend);
			this.cboPay.SetComboItems(dtTemp, "code_name", "code", XComboSetType.AppendAll);
			this.cboPay.SelectedIndex = 0;
		
			// DV_TIME
			dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
			this.grdOCS2003.SetListItems("dv_time", dtTemp, "code", "code", XComboSetType.NoAppend);

			// 이동촬영여부
			dtTemp = this.mOrderBiz.LoadComboDataSource("portable_yn").LayoutTable;
			this.grdOCS2003.SetComboItems("portable_yn", dtTemp, "code_name", "code", XComboSetType.NoAppend);

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

			grdOCS2003.ClearFilter();
			if(grdOCS2003.RowCount < 1) return;
				
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

			foreach(DataRow row in grdOCS2003.LayoutTable.Select(filter, " order_gubun "))
			{
				if(row["order_gubun"].ToString() != order_gubun )
				{
					order_gubun = row["order_gubun"].ToString().Trim();

					//order_gubun명을 가져온다.
					foreach( DataRow ordRow in this.dloOrder_gubun.LayoutTable.Select(" code = '" + order_gubun + "' ", ""))
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

			this.grdOCS2003.ClearFilter();
			if( grdOCS2003.RowCount >0 ) this.grdOCS2003.SetFilter(filter);
			
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
				this.grdOCS2003.AutoSizeColumn(14, 0);//
				this.grdOCS2003.AutoSizeColumn(15, 0);//

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
                
				//반납일때는 반납수량을 표시한다.(의사인 경우에는 안보인다)
				if(mInput_gubun != "D%") this.grdOCS2003.AutoSizeColumn(14, 0);
				if(mInput_gubun != "D%") this.grdOCS2003.AutoSizeColumn(15, 0);
			
			}

			CreateOrder_gubun();

            this.DiaplayMixGroup(this.grdOCS2003);
            
		}

		private void rbtOrder_date_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtOrder_date.Checked)
			{
				rbtOrder_date.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtOrder_date.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				
				rbtCancel.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtCancel.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                //pnlHangmogSearch.Visible = false;
				
				this.grdOCS2003.Reset();
				this.grdOrder_date.Visible = true;
				this.grdHangmog_code.Visible = false;
				//처방일자인 경우에는 처방일자를 보이지 않는다.
				//this.grdOCS2003.AutoSizeColumn(2, 0);
				

				QueryMasterList();
				LoadOCS2003();
			}
			else
			{
				rbtCancel.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtCancel.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                //pnlHangmogSearch.Visible = true;

                rbtOrder_date.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtOrder_date.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				
				this.grdOCS2003.Reset();
                //this.grdOrder_date.Visible = false;
                //this.grdHangmog_code.Visible = true;
				//처방일자인 경우에는 처방일자를 보이지 않는다.				
				//this.grdOCS2003.AutoSizeColumn(2, 0);		
	
				QueryMasterList();
				LoadOCS2003();
			}		
		}
        
		/// <summary>
		/// 항목코드 조회
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fbxHangmog_code_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			
			CommonItemCollection openParams  = new CommonItemCollection();
			//값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
			openParams.Add("hangmog_code", fbxHangmog_code.Text.Trim());
			// Multi 선택여부 (default : MultiSelect )
			openParams.Add("multiSelect", false);
			//항목조회화면 Open
			XScreen.OpenScreenWithParam( this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, openParams);

		}

		private void fbxHangmog_code_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            this.LoadOCS2003();

            PostCallHelper.PostCall(new PostMethod(PostValidating));
		}

        private void PostValidating()
        {
            if (this.grdOCS2003.RowCount > 0)
            {
                this.fbxHangmog_code.SetDataValue("");
            }
        }
		
		#endregion

		#region [grdOCS2003 Event]
		
		private void grdOCS2003_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
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
						if(Double.Parse(e.ChangeValue.ToString()) > grdOCS2003.GetItemDouble(e.RowNumber, "bannab_can_suryang"))
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
				if (!this.mColumnControl.ColumnChanged("I", mBunho, grd.GetItemString(e.RowNumber, "order_date"), grd, e)) return;
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

							// 퇴원/외출약인 경우만 NDay가능함 (Nday_yn 예약은 빼고)
							if (grd.GetItemString(e.RowNumber, "toiwon_drg_yn").Trim() != "0" &&
								grd.GetItemString(e.RowNumber, "toiwon_drg_yn").Trim() != "1" &&
								nalsu > 1)
							{
								this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
								return;					
							}

						}

						break;
						#endregion
					case "double_ipwon_type": // 이중유형체크
						#region
						// 이중유형 가능한 경우만 이중유형처리가능
						// double_ipwon_type(동일과안에서), inp_double_ipwon_type(전체과 안에서) 
						if (mDouble_ipwon_type_yn != "Y")
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ?  "二重類型患者様ではありません。" : "이중유형 환자가 아닙니다";	
							XMessageBox.Show(mbxMsg, mbxCap);
						
							this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue); // 이전값과 이전 RowState를 유지시킨다
							return;			
						}
						break;
						#endregion;
					default:
						break;
				}

				//DC 처방
				grd.SetItemValue(e.RowNumber, "dc_order_yn", "Y");
			}

			
		}

		private void grdOCS2003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				int rowIndex = grdOCS2003.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdOCS2003.CurrentColNumber == 0)
				{					
					if(grdOCS2003.GetItemString(rowIndex, "select") == "")
					{
						grdOCS2003.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdOCS2003.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}
				}
			}	
		}

		private void grdOCS2003_GridFilterChanged(object sender, System.EventArgs e)
		{
			SelectionBackColorChange(grdOCS2003);		
		}

		private void grdOCS2003_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
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
					if (this.mInputControl.IsProtectedColumn(grdOCS2003.GetItemValue(e.RowNumber, "input_control").ToString(), e.ColName) ) e.Protect = true;
				}
			}
		}

		private void grdOCS2003_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;	

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

		private void grdOCS2003_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;

			if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

			string order_date  = grd.GetItemString(e.RowNumber, "order_date"); // 처방일자
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

		private void grdOCS2003_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (sender == null) return;

			XEditGrid grd = sender as XEditGrid;			

			if (e.CurrentRow >= 0) 
			{				
				// 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
				this.mColumnControl.DisplaySpecialColHeader("O", grd, e.CurrentRow, grd.GetItemString(e.CurrentRow, "hangmog_code"));
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
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];

			for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
			{
				if(data == "Y")
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                    if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "child_yn")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                    }
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                    if (grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "child_yn")
                    {
                        grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                    }
				}
			}

            if (grdObject.GetItemString(currentRowIndex, "mix_group") != "")
            {
                for (int i = 0; i < grdObject.RowCount; i++)
                {
                    if (i == currentRowIndex ||
                        grdObject.GetItemString(currentRowIndex, "mix_group") != grdObject.GetItemString(i, "mix_group") ) continue;

                    if ((data == "Y" && grdObject.GetItemString(i, "select") != " ") ||
                         (data != "Y" && grdObject.GetItemString(i, "select") == " "))
                    {

                        grdObject.SetItemValue(i, "select", (data == "Y" ? " " : ""));

                        if (data == "Y")
                            grdObject[i + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
                        else
                            grdObject[i + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];

                        for (int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
                        {
                            if (data == "Y")
                            {
                                grdObject[i + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                                if (grdObject[i + grdObject.HeaderHeights.Count, liColCnt].CellName != "child_yn")
                                {
                                    grdObject[i + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                                }
                            }
                            else
                            {
                                grdObject[i + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                                if (grdObject[i + grdObject.HeaderHeights.Count, liColCnt].CellName != "child_yn")
                                {
                                    grdObject[i + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                                }
                            }
                        }
                    }

                }
            }
		}

        private void SelectionBackColorChange(object grid)
		{
			XEditGrid grdObject = (XEditGrid)grid;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{
                if (grdObject.GetItemString(rowIndex, "child_yn") == "Y")
                {
                    grdObject[rowIndex+grdObject.HeaderHeights.Count, 4].Image = this.ImageList.Images[3];
                }
                else
                {
                    grdObject[rowIndex+grdObject.HeaderHeights.Count, 4].Image = this.ImageList.Images[2];
                }
				//불용은 넘어간다.
				if(grdObject.CellInfos.Contains("bulyong_check") && grdObject.GetItemString(rowIndex, "bulyong_check") == "Y" ) continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{
                        grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "child_yn")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
                        }
					}
				}
				else
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
                        if (grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].CellName != "child_yn")
                        {
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
                        }
					}
				}
			}
		}
		#endregion

		#region [DataService Event]		


		private void grdOCS2003_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			string filter = "";

			//조회시 
			string dcYn     = "N";
			string bannabYn = "N";

			filter =" bannab_can_yn <> 'Y' ";
			if(grdOCS2003.LayoutTable.Select(filter, "").Length > 0)
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
            
			filter =" bannab_can_yn = 'Y' ";
            // 의사로그인인 경우만 가능하다.
            if (this.mIsDoctorMode == true)
            {
                if (grdOCS2003.LayoutTable.Select(filter, "").Length > 0)
                {
                    bannabYn = "Y";
                    rbtReturn.Tag = bannabYn;
                    rbtReturn.ForeColor = new XColor(Color.Red);
                }
                else
                {
                    if (rbtReturn.Checked)
                        rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                    else
                        rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);

                    rbtReturn.Tag = "N";
                }

                if (dcYn == "N" && bannabYn == "Y")
                {
                    rbtReturn.Checked = true;
                }
                else
                {
                    rbtDC.Checked = true;
                    filter = " bannab_can_yn <> 'Y' ";
                }
            }
            else
            {
                this.rbtReturn.Visible = false;

                if (this.rbtDC.Checked == false)
                    this.rbtDC.Checked = true;

                bannabYn = "N";

            }

			if( dcYn == "N" && bannabYn == "Y")
			{
				rbtReturn.Checked = true;
			}
			else
			{
				rbtDC.Checked = true;
				filter =" bannab_can_yn <> 'Y' ";
			}

			this.grdOCS2003.ClearFilter();
			if( grdOCS2003.RowCount >0 ) this.grdOCS2003.SetFilter(filter);

			//dloReturn.Reset();
			CreateOrder_gubun();
			tabOrder_gubun.Refresh();
			SelectionBackColorChange(grdOCS2003);
			
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

					if( dloReturnList.SaveLayout())
					{
						
						mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
						SetMsg(mbxMsg);
                        
						this.grdOCS2003.QueryLayout(true);

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
			dloReturnList.Reset();

			this.AcceptData();

			foreach(DataRow row in grdOCS2003.LayoutTable.Rows)
			{
				if(row["select"].ToString() == " ")
				{
					//seq 부여
					//처방일자가 다른 경우 999
					if(mOrder_date != row["order_date"].ToString())
					{
						row["order_date"] = mOrder_date;
						row["seq"       ] = 999;
					}
                    
					row["doctor"     ] = mDoctor        ;
					row["resident"   ] = mResident      ;
					row["input_id"   ] = UserInfo.UserID;
					row["input_part" ] = mInput_part;
					// row["input_gubun"] = mInput_gubun;

					//DC, 반납여부
					if(rbtDC.Checked)
						row["bannab_yn"] = "N";
					else
						row["bannab_yn"] = "Y";

                    if (this.rbtOrder_date.Checked)
                        row["cancel_mode_yn"] = "N";
                    else
                        row["cancel_mode_yn"] = "Y";

					dloReturnList.LayoutTable.ImportRow(row);	
			

				}
			}

			if(dloReturnList.LayoutTable.Rows.Count > 0 )
				return true;
			else
				return false;
		}

		#endregion
		
		#region [DC/반납 처방조회]
		
		private void grdOrder_date_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			LoadOCS2003();
		}

		private void grdHangmog_code_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			LoadOCS2003();		
		}

		private void LoadOCS2003()
		{
		

			//Control Clear
			ClearControl();

            if (this.rbtOrder_date.Checked)
                this.grdOCS2003.QuerySQL = this.GetOCS2003QuerySQL(false);
            else
                this.grdOCS2003.QuerySQL = this.GetOCS2003QuerySQL(true);
			
			this.grdOCS2003.QueryLayout(true);

            this.DiaplayMixGroup(this.grdOCS2003);
		}

        private string GetOCS2003QuerySQL(bool aIsCancelMode)
        {
            string cmd = "";
            if (aIsCancelMode == false)
            {
                cmd = @"SELECT A.MIX_GROUP                                                                              MIX_GROUP                    ,
       A.HANGMOG_CODE                                                                           HANGMOG_CODE                 ,
       B.HANGMOG_NAME                                                                           HANGMOG_NAME                 ,
       A.SPECIMEN_CODE                                                                          SPECIMEN_CODE                ,
       A.SURYANG                                                                                SURYANG                      ,
       A.SUBUL_SURYANG                                                                          SUBUL_SURYANG                ,
       A.ORD_DANUI                                                                              ORD_DANUI                    ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)                                          ORD_DANUI_NAME               ,
       A.SUBUL_DANUI                                                                            SUBUL_DANUI                  ,
       A.DV_TIME                                                                                DV_TIME                      ,
       A.DV                                                                                     DV                           ,
       A.NALSU                                                                                  NALSU                        ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('I',A.PKOCS2003)), 0) BANNAB_SURYANG               ,
       A.JUSA                                                                                   JUSA                         ,
       A.BOGYONG_CODE                                                                           BOGYONG_CODE                 ,
       A.WONYOI_ORDER_YN                                                                        WONYOI_ORDER_YN              ,
       A.EMERGENCY                                                                              EMERGENCY                    ,
       A.PAY                                                                                    PAY                          ,
--       A.FLUID_YN                                                                               FLUID_YN                     ,
--       A.TPN_YN                                                                                 TPN_YN                       ,
       A.ANTI_CANCER_YN                                                                         ANTI_CANCER_YN               ,
       A.MUHYO                                                                                  MUHYO                        ,
       A.JAERYO_JUNDAL_YN                                                                       JAERYO_JUNDAL_YN             ,
       A.TOIWON_DRG_YN                                                                          TOIWON_DRG_YN                ,
       A.PORTABLE_YN                                                                            PORTABLE_YN                  ,
--       A.SYMYA                                                                                  SYMYA                        ,
       A.PRN_YN                                                                                 PRN_YN                       ,
       A.DONER_YN                                                                               DONER_YN                     ,
       A.APPEND_YN                                                                              APPEND_YN                    ,
       A.TEL_YN                                                                                 TEL_YN                       ,
       A.BICHI_YN                                                                               BICHI_YN                     ,
       A.POWDER_YN                                                                              POWDER_YN                    ,
       A.ERROR_FLAG                                                                             ERROR_FLAG                   ,
       A.OCS_FLAG                                                                               OCS_FLAG                     ,
       A.ORDER_GUBUN                                                                            ORDER_GUBUN                  ,
       NVL(C.CODE_NAME, 'Etc')                                                                  ORDER_GUBUN_NAME             ,
       A.JUNDAL_TABLE                                                                           JUNDAL_TABLE                 ,
       A.JUNDAL_PART                                                                            JUNDAL_PART                  ,
       A.GROUP_SER                                                                              GROUP_SER                    ,
       A.DV_1                                                                                   DV_1                         ,
       A.DV_2                                                                                   DV_2                         ,
       A.DV_3                                                                                   DV_3                         ,
       A.DV_4                                                                                   DV_4                         ,
       A.ORDER_REMARK                                                                           ORDER_REMARK                 ,
       A.NURSE_REMARK                                                                           NURSE_REMARK                 ,
       A.BUNHO                                                                                  BUNHO                        ,
       A.FKINP1001                                                                              FKINP1001                    ,
       A.ORDER_DATE                                                                             ORDER_DATE                   ,
       DECODE(NVL(A.IPWON_TYPE,'0'),'2','Y','N')                                                DOUBLE_IPWON_TYPE            ,
       :f_double_ipwon_type_yn                                                                  DOUBLE_IPWON_TYPE_YN         ,
       A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')                                   PK_ORDER                     ,
       A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                                       PK_ORDER_BANNAB              ,
       A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') ||
       DECODE(A.ACTING_DATE,NULL,'N','Y')||
       DECODE(B.ORDER_GUBUN,'B','A', B.ORDER_GUBUN)                                             PK_ORDER_BANNAB_ORDER        ,
       A.BUNHO||A.FKINP1001||A.HANGMOG_CODE                                                     PK_HANGMOG_ORDER             ,
       A.BUNHO||A.FKINP1001||A.HANGMOG_CODE||
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                                       PK_HANGMOG_ORDER_BANNAB      ,
       A.BUNHO||A.FKINP1001||A.HANGMOG_CODE||
       DECODE(A.ACTING_DATE,NULL,'N','Y')||
       DECODE(B.ORDER_GUBUN,'B','A', B.ORDER_GUBUN)                                             PK_HANGMOG_ORDER_BANNAB_ORDER,
       A.INPUT_ID                                                                               INPUT_ID                     ,
       A.INPUT_PART                                                                             INPUT_PART                   ,
       A.INPUT_GUBUN                                                                            INPUT_GUBUN                  ,
       A.SEQ                                                                                    SEQ                          ,
       A.PKOCS2003                                                                              PKOCS2003                    ,
       B.SLIP_CODE                                                                              SLIP_CODE                    ,
       B.GROUP_YN                                                                               GROUP_YN                     ,
       B.SG_CODE                                                                                SG_CODE                      ,
       B.ORDER_GUBUN                                                                            ORDER_GUBUN_BAS              ,
       NVL(B.SUGA_YN,'N')                                                                       SUGA_YN                      ,
       NVL(B.JAERYO_YN,'N')                                                                     JAERYO_YN                    ,
       NVL(B.NDAY_YN,'N')                                                                       NDAY_YN                      ,
       FN_OCS_LOAD_JAERYO_JUNDAL_YN('I', A.INPUT_PART,A.HANGMOG_CODE)                           DEFAULT_JAERYO_JUNDAL_YN     ,
       B.INPUT_CONTROL                                                                          INPUT_CONTROL                ,
       A.DC_YN                                                                                  DC_YN                        ,
       A.DC_GUBUN                                                                               DC_GUBUN                     ,
       A.BANNAB_YN                                                                              BANNAB_YN                    ,
       A.BANNAB_CONFIRM                                                                         BANNAB_CONFIRM               ,
       A.SOURCE_FKOCS2003                                                                       SOURCE_FKOCS2003             ,
       DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                                                    DC_CHECK                     ,
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                                       BANNAB_CAN_YN                ,
       --NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('I',A.PKOCS2003)), 0) BANNAB_CAN_SURYANG           ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_HOISU('I', A.PKOCS2003)), 0)  BANNAB_CAN_HOISU             ,
       --DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE))          BANNAB_DANUI                 ,
       DECODE(A.ACTING_DATE, NULL, NULL, A.ORD_DANUI)                                           BANNAB_DANUI                 ,
       --DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE)))
       DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI))
                                                                                                BANNAB_DANUI_NAME            ,
       A.SUNAB_DATE                                                                             SUNAB_DATE                   ,
       DECODE(A.NURSE_CONFIRM_DATE, NULL, 'N','Y')                                              CONFIRM_CHECK                ,
       FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)                                               SPECIMEN_NAME                ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                                                    JUSA_NAME                    ,
       FN_OCS_LOAD_CODE_NAME('PAY',  A.PAY)                                                     PAY_NAME                     ,
       FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                              BOGYONG_NAME                 ,
       D.BUN_CODE                                                                               BUN_CODE                     ,
       NULL                                                                                     SG_GESAN                     ,
       NVL(E.CODE_NAME, 'Etc')                                                                  INPUT_GUBUN_NAME             , 
       DECODE(A.BOM_SOURCE_KEY, NULL, 'N', 'Y')                                                 CHILD_YN                     ,
       A.INPUT_TAB || TRIM(TO_CHAR(A.GROUP_SER, '0000000000')) || 
       TO_CHAR(CASE WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS2003 ELSE A.BOM_SOURCE_KEY END, '0000000000') ||
       A.PKOCS2003                                                                              ORDERBYKEY
  FROM OCS2003 A,
       OCS0103 B,
       OCS0132 C,
       ( SELECT X.SG_CODE
              , X.BUN_CODE
           FROM BAS0310 X
          WHERE X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
                               FROM BAS0310 Z
                              WHERE Z.SG_CODE = X.SG_CODE
                                AND Z.SG_YMD <= TO_DATE(:f_order_date,'YYYY/MM/DD') )
       ) D,
       OCS0132 E
 WHERE A.BUNHO               = :f_bunho
   AND A.FKINP1001           = :f_fkinp1001
   AND ( ( :f_hangmog_code  = '%' AND A.ORDER_DATE  = TO_DATE(:f_order_date,'YYYY/MM/DD') )
         OR
         ( :f_hangmog_code <> '%' AND A.ORDER_DATE <= TO_DATE(:f_order_date, 'YYYY/MM/DD') + 14)
       )
   AND A.HANGMOG_CODE       LIKE :f_hangmog_code
   AND A.PAY                LIKE :f_pay
   AND (  ( :f_input_gubun  = 'D%'
            AND ( NVL(A.DC_GUBUN,'N') = 'N' AND A.INPUT_GUBUN  LIKE :f_input_gubun )
          )
          OR
          ( :f_input_gubun <> 'D%'
            AND ( NVL(A.DC_GUBUN,'N') = 'Y' OR  A.INPUT_GUBUN  = :f_input_gubun    )
          )
       )
   AND A.NALSU              >= 0
   AND NVL(A.IO_GUBUN,'X')   NOT IN ('I','O')
   AND (
         ( SUBSTR(A.ORDER_GUBUN, 2, 1) IN ( 'B', 'C', 'D') 
           AND NVL(A.NDAY_YN, 'N') != 'Y' )
         OR
         ( SUBSTR(A.ORDER_GUBUN, 2, 1) NOT IN ( 'B', 'C', 'D') )
       )
   AND B.HANGMOG_CODE        = A.HANGMOG_CODE
   AND NVL(A.DC_YN,'N')      = 'N'
   AND A.JUNDAL_PART NOT IN ( 'HOM ')
   AND ( 
         ( A.JUNDAL_PART = 'PA' 
           AND FN_OCS_LOAD_BANNAB_CAN_HOISU ( 'I', A.PKOCS2003 ) != 0 )
         OR
         ( A.JUNDAL_PART != 'PA'
           AND A.JUBSU_DATE IS NOT NULL
           AND A.ACTING_DATE IS NULL )
       )
   AND A.SUNAB_DATE IS NULL
   AND C.CODE     (+)  = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)  = 'ORDER_GUBUN'
   AND D.SG_CODE  (+)  = B.SG_CODE
   AND E.CODE     (+)  = A.INPUT_GUBUN
   AND E.CODE_TYPE(+)  = 'INPUT_GUBUN'
-- ORDER BY A.ORDER_DATE DESC, NVL(E.SORT_KEY, 99)
 ORDER BY A.ORDER_DATE DESC, ORDERBYKEY  ";
            }
            else
            {
                cmd = @"SELECT A.MIX_GROUP                                                                              MIX_GROUP                    ,
       A.HANGMOG_CODE                                                                           HANGMOG_CODE                 ,
       B.HANGMOG_NAME                                                                           HANGMOG_NAME                 ,
       A.SPECIMEN_CODE                                                                          SPECIMEN_CODE                ,
       A.SURYANG                                                                                SURYANG                      ,
       A.SUBUL_SURYANG                                                                          SUBUL_SURYANG                ,
       A.ORD_DANUI                                                                              ORD_DANUI                    ,
       FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI)                                          ORD_DANUI_NAME               ,
       A.SUBUL_DANUI                                                                            SUBUL_DANUI                  ,
       A.DV_TIME                                                                                DV_TIME                      ,
       A.DV                                                                                     DV                           ,
       A.NALSU                                                                                  NALSU                        ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('I',A.PKOCS2003)), 0) BANNAB_SURYANG               ,
       A.JUSA                                                                                   JUSA                         ,
       A.BOGYONG_CODE                                                                           BOGYONG_CODE                 ,
       A.WONYOI_ORDER_YN                                                                        WONYOI_ORDER_YN              ,
       A.EMERGENCY                                                                              EMERGENCY                    ,
       A.PAY                                                                                    PAY                          ,
--       A.FLUID_YN                                                                               FLUID_YN                     ,
--       A.TPN_YN                                                                                 TPN_YN                       ,
       A.ANTI_CANCER_YN                                                                         ANTI_CANCER_YN               ,
       A.MUHYO                                                                                  MUHYO                        ,
       A.JAERYO_JUNDAL_YN                                                                       JAERYO_JUNDAL_YN             ,
       A.TOIWON_DRG_YN                                                                          TOIWON_DRG_YN                ,
       A.PORTABLE_YN                                                                            PORTABLE_YN                  ,
--       A.SYMYA                                                                                  SYMYA                        ,
       A.PRN_YN                                                                                 PRN_YN                       ,
       A.DONER_YN                                                                               DONER_YN                     ,
       A.APPEND_YN                                                                              APPEND_YN                    ,
       A.TEL_YN                                                                                 TEL_YN                       ,
       A.BICHI_YN                                                                               BICHI_YN                     ,
       A.POWDER_YN                                                                              POWDER_YN                    ,
       A.ERROR_FLAG                                                                             ERROR_FLAG                   ,
       A.OCS_FLAG                                                                               OCS_FLAG                     ,
       A.ORDER_GUBUN                                                                            ORDER_GUBUN                  ,
       NVL(C.CODE_NAME, 'Etc')                                                                  ORDER_GUBUN_NAME             ,
       A.JUNDAL_TABLE                                                                           JUNDAL_TABLE                 ,
       A.JUNDAL_PART                                                                            JUNDAL_PART                  ,
       A.GROUP_SER                                                                              GROUP_SER                    ,
       A.DV_1                                                                                   DV_1                         ,
       A.DV_2                                                                                   DV_2                         ,
       A.DV_3                                                                                   DV_3                         ,
       A.DV_4                                                                                   DV_4                         ,
       A.ORDER_REMARK                                                                           ORDER_REMARK                 ,
       A.NURSE_REMARK                                                                           NURSE_REMARK                 ,
       A.BUNHO                                                                                  BUNHO                        ,
       A.FKINP1001                                                                              FKINP1001                    ,
       A.ORDER_DATE                                                                             ORDER_DATE                   ,
       DECODE(NVL(A.IPWON_TYPE,'0'),'2','Y','N')                                                DOUBLE_IPWON_TYPE            ,
       :f_double_ipwon_type_yn                                                                  DOUBLE_IPWON_TYPE_YN         ,
       A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')                                   PK_ORDER                     ,
       A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD')||
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                                       PK_ORDER_BANNAB              ,
       A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') ||
       DECODE(A.ACTING_DATE,NULL,'N','Y')||
       DECODE(B.ORDER_GUBUN,'B','A', B.ORDER_GUBUN)                                             PK_ORDER_BANNAB_ORDER        ,
       A.BUNHO||A.FKINP1001||A.HANGMOG_CODE                                                     PK_HANGMOG_ORDER             ,
       A.BUNHO||A.FKINP1001||A.HANGMOG_CODE||
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                                       PK_HANGMOG_ORDER_BANNAB      ,
       A.BUNHO||A.FKINP1001||A.HANGMOG_CODE||
       DECODE(A.ACTING_DATE,NULL,'N','Y')||
       DECODE(B.ORDER_GUBUN,'B','A', B.ORDER_GUBUN)                                             PK_HANGMOG_ORDER_BANNAB_ORDER,
       A.INPUT_ID                                                                               INPUT_ID                     ,
       A.INPUT_PART                                                                             INPUT_PART                   ,
       A.INPUT_GUBUN                                                                            INPUT_GUBUN                  ,
       A.SEQ                                                                                    SEQ                          ,
       A.PKOCS2003                                                                              PKOCS2003                    ,
       B.SLIP_CODE                                                                              SLIP_CODE                    ,
       B.GROUP_YN                                                                               GROUP_YN                     ,
       B.SG_CODE                                                                                SG_CODE                      ,
       B.ORDER_GUBUN                                                                            ORDER_GUBUN_BAS              ,
       NVL(B.SUGA_YN,'N')                                                                       SUGA_YN                      ,
       NVL(B.JAERYO_YN,'N')                                                                     JAERYO_YN                    ,
       NVL(B.NDAY_YN,'N')                                                                       NDAY_YN                      ,
       FN_OCS_LOAD_JAERYO_JUNDAL_YN('I', A.INPUT_PART,A.HANGMOG_CODE)                           DEFAULT_JAERYO_JUNDAL_YN     ,
       B.INPUT_CONTROL                                                                          INPUT_CONTROL                ,
       A.DC_YN                                                                                  DC_YN                        ,
       A.DC_GUBUN                                                                               DC_GUBUN                     ,
       A.BANNAB_YN                                                                              BANNAB_YN                    ,
       A.BANNAB_CONFIRM                                                                         BANNAB_CONFIRM               ,
       A.SOURCE_FKOCS2003                                                                       SOURCE_FKOCS2003             ,
       DECODE(SIGN(A.NALSU),1,'N',0,'N','Y')                                                    DC_CHECK                     ,
       DECODE(A.ACTING_DATE,NULL,'N','Y')                                                       BANNAB_CAN_YN                ,
       --NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_SURYANG('I',A.PKOCS2003)), 0) BANNAB_CAN_SURYANG           ,
       NVL(DECODE(A.ACTING_DATE,NULL,NULL, FN_OCS_LOAD_BANNAB_CAN_HOISU('I', A.PKOCS2003)), 0)  BANNAB_CAN_HOISU             ,
       --DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE))          BANNAB_DANUI                 ,
       DECODE(A.ACTING_DATE, NULL, NULL, A.ORD_DANUI)                                           BANNAB_DANUI                 ,
       --DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', FN_OCS_LOAD_BANNAB_CAN_DANUI(A.HANGMOG_CODE)))
       DECODE(A.ACTING_DATE, NULL, NULL, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI))
                                                                                                BANNAB_DANUI_NAME            ,
       A.SUNAB_DATE                                                                             SUNAB_DATE                   ,
       DECODE(A.NURSE_CONFIRM_DATE, NULL, 'N','Y')                                              CONFIRM_CHECK                ,
       FN_OCS_LOAD_SPECIMEN_NAME(A.SPECIMEN_CODE)                                               SPECIMEN_NAME                ,
       FN_OCS_LOAD_CODE_NAME('JUSA', A.JUSA)                                                    JUSA_NAME                    ,
       FN_OCS_LOAD_CODE_NAME('PAY',  A.PAY)                                                     PAY_NAME                     ,
       FN_OCS_LOAD_BOGYONG_COL_NAME(B.ORDER_GUBUN, A.BOGYONG_CODE)                              BOGYONG_NAME                 ,
       D.BUN_CODE                                                                               BUN_CODE                     ,
       NULL                                                                                     SG_GESAN                     ,
       NVL(E.CODE_NAME, 'Etc')                                                                  INPUT_GUBUN_NAME             , 
       DECODE(A.BOM_SOURCE_KEY, NULL, 'N', 'Y')                                                 CHILD_YN                     ,
       A.INPUT_TAB || TRIM(TO_CHAR(A.GROUP_SER, '0000000000')) || 
       TO_CHAR(CASE WHEN A.BOM_SOURCE_KEY IS NULL THEN A.PKOCS2003 ELSE A.BOM_SOURCE_KEY END, '0000000000') ||
       A.PKOCS2003                                                                              ORDERBYKEY
  FROM OCS2003 A,
       OCS0103 B,
       OCS0132 C,
       ( SELECT X.SG_CODE
              , X.BUN_CODE
           FROM BAS0310 X
          WHERE X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
                               FROM BAS0310 Z
                              WHERE Z.SG_CODE = X.SG_CODE
                                AND Z.SG_YMD <= TO_DATE(:f_order_date,'YYYY/MM/DD') )
       ) D,
       OCS0132 E
 WHERE A.BUNHO               = :f_bunho
   AND A.FKINP1001           = :f_fkinp1001
   AND ( ( :f_hangmog_code  = '%' AND A.ORDER_DATE  = TO_DATE(:f_order_date,'YYYY/MM/DD') )
         OR
         ( :f_hangmog_code <> '%' AND A.ORDER_DATE <= TO_DATE(:f_order_date, 'YYYY/MM/DD') + 14)
       )
   AND A.HANGMOG_CODE       LIKE :f_hangmog_code
   AND A.PAY                LIKE :f_pay
   AND (
         ( NVL(A.DC_GUBUN, 'N') = 'N' AND NVL(A.DC_YN, 'N') = 'N' AND NVL(A.BANNAB_YN, 'N') = 'N' AND A.NALSU < 0 )
         OR
         ( NVL(A.DC_GUBUN, 'N') = 'Y' AND NVL(A.DC_YN, 'N') = 'N' AND NVL(A.BANNAB_YN, 'N') = 'N' )
       )
   AND NVL(A.IO_GUBUN,'X')   NOT IN ('I','O')
   AND (
         ( SUBSTR(A.ORDER_GUBUN, 2, 1) IN ( 'B', 'C', 'D') 
           AND NVL(A.NDAY_YN, 'N') != 'Y' )
         OR
         ( SUBSTR(A.ORDER_GUBUN, 2, 1) NOT IN ( 'B', 'C', 'D') )
       )
   AND B.HANGMOG_CODE        = A.HANGMOG_CODE
   AND C.CODE     (+)  = A.ORDER_GUBUN
   AND C.CODE_TYPE(+)  = 'ORDER_GUBUN'
   AND D.SG_CODE  (+)  = B.SG_CODE
   AND E.CODE     (+)  = A.INPUT_GUBUN
   AND E.CODE_TYPE(+)  = 'INPUT_GUBUN'
-- ORDER BY A.ORDER_DATE DESC, NVL(E.SORT_KEY, 99)
 ORDER BY A.ORDER_DATE DESC, ORDERBYKEY ";
            }

            return cmd;
        }

		#endregion

        #region MIX Group 처리

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
                    if (aGrd.GetItemString(i, "dc_check") == "Y") continue;

                    // 이미 이미지 세팅이 안된건에 한해서 작업수행
                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //이미수행한건 빼는로직이 있어야함..
                        int count = 0;
                        for (int j = i; j < aGrd.RowCount; j++)
                        {
                            // 동일 group_ser, 동일 mix_group, 동일 희망일자, 동일 OrderGubun가 Mix구별임..
                            if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
                                aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
                                aGrd.GetItemValue(i, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1) ==
                                aGrd.GetItemValue(j, "order_gubun").ToString().Trim().PadRight(2).Substring(1, 1))
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

        #endregion

        #region [처방일자, 항목코드 조회]

        private void dpkOrder_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if(TypeCheck.IsDateTime(e.DataValue))
				QueryMasterList();
		}

		private void QueryMasterList()
		{
            if (this.rbtOrder_date.Checked)
                this.grdOrder_date.QuerySQL = this.GetMasterQuerySQL(false);
            else
                this.grdOrder_date.QuerySQL = this.GetMasterQuerySQL(true);

            this.grdOrder_date.QueryLayout(true);
		}

        private string GetMasterQuerySQL(bool aIsCancelMode)
        {
            string cmd = "";
            if (aIsCancelMode == false)
            {
                cmd = @"SELECT DISTINCT									       
                               A.ORDER_DATE                                                        ,                
                               A.BUNHO                                                             ,                
                               A.FKINP1001                                                         ,                    
                               A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') PK_ORDER_DATE,                
                               :f_input_gubun                                         INPUT_GUBUN              
                          FROM OCS2003 A,                                                                           
                               OCS0103 B                                                                      
                         WHERE A.BUNHO               = :f_bunho                                                 
                           AND A.FKINP1001           = :f_fkinp1001                                             
                           AND A.ORDER_DATE         <= TO_DATE(:f_order_date, 'YYYY/MM/DD') + 14                
                           AND NVL(A.PRN_YN,'N')     = 'N'                                                      
                           AND (  ( :f_input_gubun  = 'D%' AND ( NVL(A.DC_GUBUN,'N') = 'N' AND A.INPUT_GUBUN  LIKE :f_input_gubun ))          
                                  OR 
                                  ( :f_input_gubun <> 'D%' AND ( NVL(A.DC_GUBUN,'N') = 'Y' OR  A.INPUT_GUBUN  = :f_input_gubun    )) )    
                           AND A.NALSU              >= 0                                                                                  
                           AND NVL(A.IO_GUBUN,'X')   NOT IN ('I','O')                                                                     
                           AND B.HANGMOG_CODE        = A.HANGMOG_CODE                                                                     
                           AND NVL(A.DC_YN,'N')      = 'N'                                                                                
                           AND ( 
                                 ( A.JUNDAL_PART = 'PA' 
                                   AND FN_OCS_LOAD_BANNAB_CAN_HOISU ( 'I', A.PKOCS2003 ) != 0 )
                                 OR
                                 ( A.JUNDAL_PART != 'PA'
                                   AND A.JUBSU_DATE IS NOT NULL
                                   AND A.ACTING_DATE IS NULL )
                               )
                           AND A.SUNAB_DATE IS NULL
                           AND A.JUNDAL_PART NOT IN ('HOM')
                         ORDER BY A.ORDER_DATE DESC   ";
            }
            else
            {
                cmd = @"SELECT DISTINCT
                               A.ORDER_DATE                                                        ,
                               A.BUNHO                                                             ,
                               A.FKINP1001                                                         ,
                               A.BUNHO||A.FKINP1001||TO_CHAR(A.ORDER_DATE,'YYYYMMDD') PK_ORDER_DATE,
                               :f_input_gubun                                         INPUT_GUBUN
                          FROM OCS2003 A,
                               OCS0103 B
                         WHERE A.BUNHO               = :f_bunho
                           AND A.FKINP1001           = :f_fkinp1001
                           AND A.ORDER_DATE         <= TO_DATE(:f_order_date, 'YYYY/MM/DD') + 14
                           AND NVL(A.PRN_YN,'N')     = 'N'
                           AND (  ( :f_input_gubun  = 'D%' AND A.INPUT_GUBUN  LIKE :f_input_gubun )
                                  OR
                                  ( :f_input_gubun <> 'D%' AND ( NVL(A.DC_GUBUN,'N') = 'Y' OR  A.INPUT_GUBUN  = :f_input_gubun    )) )
                           AND ( 
                                  A.NALSU              < 0
                                  OR
                                  ( NVL(A.DC_GUBUN, 'N') = 'Y' AND NVL(A.BANNAB_YN, 'N') = 'N' AND NVL(A.DC_YN, 'N') = 'N')
                               )                                    
                           AND NVL(A.IO_GUBUN,'X')   NOT IN ('I','O')
                           AND B.HANGMOG_CODE        = A.HANGMOG_CODE
                         ORDER BY A.ORDER_DATE DESC  ";
            }

            return cmd;
        }

        #endregion

		#region [Clear Control]

		private void ClearControl()
		{
			if(rbtDC.Checked)
			{
				rbtDC.Tag = "N";
				rbtReturn.Tag = "N";
				rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				
				
			}
			else
			{
				rbtDC.Tag = "N";
				rbtReturn.Tag = "N";
				rbtDC.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtReturn.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
			}

			//Clear
			try
			{
				tabOrder_gubun.TabPages.Clear();
			}
			catch{}	

			tabOrder_gubun.Refresh();

		}

		#endregion

		private void grdOrder_date_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.grdOrder_date.SetBindVarValue("f_bunho", this.mBunho);
			this.grdOrder_date.SetBindVarValue("f_fkinp1001", this.mFkinp1001.ToString());
			this.grdOrder_date.SetBindVarValue("f_order_date", this.mOrder_date);
			this.grdOrder_date.SetBindVarValue("f_input_gubun", this.mInput_gubun);
            this.grdOrder_date.SetBindVarValue("f_hangmog_code", this.fbxHangmog_code.GetDataValue());
		}

		private void grdHangmog_code_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.grdHangmog_code.SetBindVarValue("f_bunho", this.mBunho);			
			this.grdHangmog_code.SetBindVarValue("f_fkinp1001", this.mFkinp1001.ToString());			
			this.grdHangmog_code.SetBindVarValue("f_order_date", this.mOrder_date);			
			this.grdHangmog_code.SetBindVarValue("f_input_gubun", this.mInput_gubun);
			this.grdHangmog_code.SetBindVarValue("f_hangmog_code", this.fbxHangmog_code.GetDataValue());
			this.grdHangmog_code.SetBindVarValue("f_pay", this.cboPay.GetDataValue());
		}

		private void grdOCS2003_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{		
			int currentRow = -1;

            currentRow = this.grdOrder_date.CurrentRowNumber;
            if (currentRow < 0) return;

            this.grdOCS2003.SetBindVarValue("f_bunho", mBunho);
            this.grdOCS2003.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.grdOCS2003.SetBindVarValue("f_order_date", grdOrder_date.GetItemString(currentRow, "order_date"));
            this.grdOCS2003.SetBindVarValue("f_hangmog_code", TypeCheck.NVL(this.fbxHangmog_code.GetDataValue(), "%").ToString());
            this.grdOCS2003.SetBindVarValue("f_pay", "%");
            this.grdOCS2003.SetBindVarValue("f_input_gubun", mInput_gubun);
            this.grdOCS2003.SetBindVarValue("f_double_ipwon_type_yn", mDouble_ipwon_type_yn);

            //if (this.rbtOrder_date.Checked)
            //{
            //    currentRow = this.grdOrder_date.CurrentRowNumber;
            //    if (currentRow < 0) return;

            //    this.grdOCS2003.SetBindVarValue("f_bunho", mBunho);
            //    this.grdOCS2003.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            //    this.grdOCS2003.SetBindVarValue("f_order_date", grdOrder_date.GetItemString(currentRow, "order_date"));
            //    this.grdOCS2003.SetBindVarValue("f_hangmog_code", "%");
            //    this.grdOCS2003.SetBindVarValue("f_pay", "%");
            //    this.grdOCS2003.SetBindVarValue("f_input_gubun", mInput_gubun);
            //    this.grdOCS2003.SetBindVarValue("f_double_ipwon_type_yn", mDouble_ipwon_type_yn);
            //}
            //else
            //{
            //    currentRow = this.grdHangmog_code.CurrentRowNumber;
            //    if (currentRow < 0) return;

            //    this.grdOCS2003.SetBindVarValue("f_bunho", mBunho);
            //    this.grdOCS2003.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            //    this.grdOCS2003.SetBindVarValue("f_order_date", grdHangmog_code.GetItemString(currentRow, "order_date"));
            //    this.grdOCS2003.SetBindVarValue("f_hangmog_code", grdHangmog_code.GetItemString(currentRow, "hangmog_code"));
            //    this.grdOCS2003.SetBindVarValue("f_pay", "%");
            //    this.grdOCS2003.SetBindVarValue("f_input_gubun", mInput_gubun);
            //    this.grdOCS2003.SetBindVarValue("f_double_ipwon_type_yn", mDouble_ipwon_type_yn);

            //}
		}

		
		#region XSavePerformer     :  입력/변경/삭제 private class
		/// <summary>
		/// XSavePerformer 를 private class로 선언하는 이유는 
		/// XSavePerformer의 parent (화면) 의 세부 controls 들을 제어 하기 위해서 이다. 
		/// public class 로 선언할경우 화면 내부의 값들을 제어 할수 없음.
		/// </summary>
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			/// <summary>
			/// 현재 화면 생성자(프로그램명)을 parent 로 지정 
			/// </summary>
			private OCS2003U01 parent = null;

			/// <summary>
			/// XSavePerformer 를 사용.
			/// </summary>
			/// <param name="parent">화면 생성자 (프로그램명)</param>
			public XSavePerformer(OCS2003U01 parent)
			{
				this.parent = parent;
			}

			/// <summary>
			/// 실제 쿼리문을 db에 보내는 함수
			/// </summary>
			/// <param name="callerID"> 각 그P리드의 CallerID ( IFC 의 LayoutID와 동일 )              </param>
			/// <param name="item">     각 로우의 현재 상태를 나타낸다 . ( I/U/D >> 입력/변경/삭제 ) </param>
			/// <returns>nonquery 리턴 : 조회 문이 아닌 경우에만 사용 하는 쿼리 실행 </returns>
			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";
				object retVal = ""; 
				string pkOCS2003 = ""; 
				string userGubun = "";
				item.BindVarList.Add("q_user_id", UserInfo.UserID);

                string spName = "";
                ArrayList inList = new ArrayList();
                ArrayList outList = new ArrayList();

				switch (callerID)
				{
					case '3':
						#region dloReturnList 
                        retVal = true;
						if (item.RowState == DataRowState.Modified)
						{
                            if (item.BindVarList["f_cancel_mode_yn"].VarValue == "N")
                            {
                                // 지금부터 시작 합니다.
                                // 반납인경우
                                if (item.BindVarList["f_bannab_yn"].VarValue == "Y")
                                {
                                    inList.Clear();
                                    outList.Clear();
                                    spName = "PR_OCSI_PROCESS_BANNAB";
                                    inList.Add("1"); // 반납지시
                                    inList.Add(item.BindVarList["f_pkocs2003"].VarValue);
                                    inList.Add("0");
                                    inList.Add(item.BindVarList["q_user_id"].VarValue);
                                }
                                // 취소인경우
                                else
                                {
                                    inList.Clear();
                                    outList.Clear();
                                    spName = "PR_OCSI_PROCESS_DOCTOR_CANCEL";
                                    inList.Add(item.BindVarList["f_pkocs2003"].VarValue);
                                    inList.Add(item.BindVarList["q_user_id"].VarValue);
                                }

                                retVal = Service.ExecuteProcedure(spName, inList, outList);
                            }
                            else
                            {
                                if (item.BindVarList["f_bannab_yn"].VarValue == "Y")
                                {
                                    cmdText = @"UPDATE OCS2003 
                                                   SET UPD_ID = :q_user_id 
                                                     , UPD_DATE = SYSDATE 
                                                     , DC_GUBUN = 'N'
                                                 WHERE PKOCS2003 = :f_pkocs2003";


                                    retVal = Service.ExecuteNonQuery(cmdText, item.BindVarList);
                                }
                                else
                                {
                                    inList.Clear();
                                    outList.Clear();
                                    spName = "PR_OCS_UPDATE_DC_YN";

                                    inList.Add("I");
                                    inList.Add(item.BindVarList["f_source_fkocs2003"].VarValue);

                                    retVal = Service.ExecuteProcedure(spName, inList, outList);

                                    if (((bool)retVal) == true)
                                    {
                                        cmdText = @"DELETE FROM OCS2003
                                                 WHERE PKOCS2003 = :f_pkocs2003";

                                        retVal = Service.ExecuteNonQuery(cmdText, item.BindVarList);
                                    }
                                }
                            }

                            
						}
                        return (bool)retVal;
						#endregion
				
					default:    // CallerID 전달 실패 
						break;
				}

				return true;

			}
		}
		#endregion





    }
}

