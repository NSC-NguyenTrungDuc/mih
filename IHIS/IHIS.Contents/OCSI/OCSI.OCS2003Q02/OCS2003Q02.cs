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
	/// OCS2003Q02에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS2003Q02 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		#endregion

		#region [Instance Variable]		
		//Message처리
		string mbxMsg = "", mbxCap = "";		

		//등록번호
		private string mBunho = "";
		//처방일자
		private string mOrder_date = "";		
		//진료의사
		private string mDoctor = "";
		//진료과
		private string mGwa = "";
		//병동
		private string mHo_dong = "";
		//팀
		private string mHo_team = "";
		//입력구분
		private string mInput_gubun = "";

        private string mTimeGubun = "";

        private ArrayList mCancel_drg_bunho_list = new ArrayList();
        private ArrayList mCancel_jubsu_list = new ArrayList();
        private ArrayList mCancel_input_list = new ArrayList();

		#endregion

		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel5;
		private IHIS.Framework.XPatientBox pbxSearch;
		private IHIS.Framework.XEditGrid grdNotActing;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.XEditGridCell xEditGridCell70;
		private IHIS.Framework.XEditGridCell xEditGridCell75;
		private IHIS.Framework.XEditGridCell xEditGridCell76;
		private IHIS.Framework.XEditGridCell xEditGridCell77;
		private IHIS.Framework.XEditGridCell xEditGridCell78;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
		private IHIS.Framework.XEditGridCell xEditGridCell80;
		private IHIS.Framework.XEditGridCell xEditGridCell89;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XFindBox fbxDoctor;
		private IHIS.Framework.XLabel xLabel2;
		private System.Windows.Forms.RadioButton rbtToday;
		private System.Windows.Forms.RadioButton rbtPre;
		private System.Windows.Forms.RadioButton rbtPost;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XFindBox fbxGwa;
		private IHIS.Framework.XDisplayBox dbxGwa_name;
		private IHIS.Framework.XDisplayBox dbxDoctor_name;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XDatePicker dpkOrder_date;
		private IHIS.Framework.MultiLayout dloDCOrder;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private XComboBox cboHo_dong;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XButton btnDeleteAll;
        private XButton btnSelectAll;
        private XEditGridCell xEditGridCell22;
        private XPanel xPanel2;
        private XDictComboBox cbxOrderGubun;
        private XLabel xLabel4;
        private XButton btnDrgInjCancel;
        private PictureBox pbxDrgInjNoActOrder;
        private XEditGridCell xEditGridCell23;
        private XButton btnHelp2;
        private XPanel pnlHelp2;
        private XLabel xLabel6;
        private XLabel xLabel9;
        private XLabel xLabel7;
        private XLabel xLabel18;
        private XLabel xLabel11;
        private XButton btnBatchDeleteProcess;
        private XDatePicker dpkBatchDeleteDate;
        private XLabel xLabel8;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS2003Q02()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.dloDCOrder.SavePerformer = new XSavePerformer(this);

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2003Q02));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pbxSearch = new IHIS.Framework.XPatientBox();
            this.cboHo_dong = new IHIS.Framework.XComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dbxDoctor_name = new IHIS.Framework.XDisplayBox();
            this.dbxGwa_name = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.fbxGwa = new IHIS.Framework.XFindBox();
            this.dpkOrder_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnBatchDeleteProcess = new IHIS.Framework.XButton();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.dpkBatchDeleteDate = new IHIS.Framework.XDatePicker();
            this.pbxDrgInjNoActOrder = new System.Windows.Forms.PictureBox();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnDrgInjCancel = new IHIS.Framework.XButton();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.rbtToday = new System.Windows.Forms.RadioButton();
            this.rbtPre = new System.Windows.Forms.RadioButton();
            this.rbtPost = new System.Windows.Forms.RadioButton();
            this.grdNotActing = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.dloDCOrder = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.btnDeleteAll = new IHIS.Framework.XButton();
            this.btnSelectAll = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cbxOrderGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.btnHelp2 = new IHIS.Framework.XButton();
            this.pnlHelp2 = new IHIS.Framework.XPanel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDrgInjNoActOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotActing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloDCOrder)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlHelp2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(3, "YESUP1.ICO");
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlTop.Controls.Add(this.pbxSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1255, 30);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // pbxSearch
            // 
            this.pbxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxSearch.Location = new System.Drawing.Point(0, 0);
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pbxSearch.ShowBoxImage = false;
            this.pbxSearch.Size = new System.Drawing.Size(1255, 30);
            this.pbxSearch.TabIndex = 1;
            this.pbxSearch.PatientSelected += new System.EventHandler(this.pbxSearch_PatientSelected);
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.Location = new System.Drawing.Point(626, 37);
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(70, 21);
            this.cboHo_dong.TabIndex = 0;
            this.cboHo_dong.SelectedIndexChanged += new System.EventHandler(this.cboHo_dong_SelectedIndexChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(558, 37);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(68, 21);
            this.xLabel3.TabIndex = 11;
            this.xLabel3.Text = "病棟";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxDoctor_name
            // 
            this.dbxDoctor_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxDoctor_name.EdgeRounding = false;
            this.dbxDoctor_name.Location = new System.Drawing.Point(1090, 38);
            this.dbxDoctor_name.Name = "dbxDoctor_name";
            this.dbxDoctor_name.Size = new System.Drawing.Size(94, 20);
            this.dbxDoctor_name.TabIndex = 16;
            // 
            // dbxGwa_name
            // 
            this.dbxGwa_name.BackColor = IHIS.Framework.XColor.XLabelGradientEndColor;
            this.dbxGwa_name.EdgeRounding = false;
            this.dbxGwa_name.Location = new System.Drawing.Point(818, 38);
            this.dbxGwa_name.Name = "dbxGwa_name";
            this.dbxGwa_name.Size = new System.Drawing.Size(103, 20);
            this.dbxGwa_name.TabIndex = 15;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(702, 38);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(68, 20);
            this.xLabel1.TabIndex = 10;
            this.xLabel1.Text = "診療科";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.Location = new System.Drawing.Point(1006, 38);
            this.fbxDoctor.MaxLength = 7;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.Size = new System.Drawing.Size(84, 20);
            this.fbxDoctor.TabIndex = 0;
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            this.fbxDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxDoctor_FindClick);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(938, 38);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(68, 20);
            this.xLabel2.TabIndex = 13;
            this.xLabel2.Text = "診療医師";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxGwa
            // 
            this.fbxGwa.Location = new System.Drawing.Point(769, 38);
            this.fbxGwa.MaxLength = 2;
            this.fbxGwa.Name = "fbxGwa";
            this.fbxGwa.Size = new System.Drawing.Size(50, 20);
            this.fbxGwa.TabIndex = 12;
            this.fbxGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxGwa_DataValidating);
            this.fbxGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxGwa_FindClick);
            // 
            // dpkOrder_date
            // 
            this.dpkOrder_date.Location = new System.Drawing.Point(449, 38);
            this.dpkOrder_date.Name = "dpkOrder_date";
            this.dpkOrder_date.Size = new System.Drawing.Size(102, 20);
            this.dpkOrder_date.TabIndex = 1;
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(351, 38);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(98, 20);
            this.xLabel5.TabIndex = 6;
            this.xLabel5.Text = "照会基準日";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnBatchDeleteProcess);
            this.xPanel3.Controls.Add(this.xLabel11);
            this.xPanel3.Controls.Add(this.dpkBatchDeleteDate);
            this.xPanel3.Controls.Add(this.pbxDrgInjNoActOrder);
            this.xPanel3.Controls.Add(this.xLabel8);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Controls.Add(this.btnDrgInjCancel);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.Location = new System.Drawing.Point(0, 546);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(1255, 44);
            this.xPanel3.TabIndex = 2;
            // 
            // btnBatchDeleteProcess
            // 
            this.btnBatchDeleteProcess.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBatchDeleteProcess.Location = new System.Drawing.Point(472, 7);
            this.btnBatchDeleteProcess.Name = "btnBatchDeleteProcess";
            this.btnBatchDeleteProcess.Size = new System.Drawing.Size(96, 31);
            this.btnBatchDeleteProcess.TabIndex = 30;
            this.btnBatchDeleteProcess.Text = "一括削除";
            this.btnBatchDeleteProcess.Click += new System.EventHandler(this.btnBatchDeleteProcess_Click);
            // 
            // xLabel11
            // 
            this.xLabel11.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel11.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xLabel11.Location = new System.Drawing.Point(223, 12);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(257, 20);
            this.xLabel11.TabIndex = 31;
            this.xLabel11.Text = "一括削除日からの検査オーダ";
            this.xLabel11.UseWaitCursor = true;
            // 
            // dpkBatchDeleteDate
            // 
            this.dpkBatchDeleteDate.Location = new System.Drawing.Point(108, 12);
            this.dpkBatchDeleteDate.Name = "dpkBatchDeleteDate";
            this.dpkBatchDeleteDate.Size = new System.Drawing.Size(100, 20);
            this.dpkBatchDeleteDate.TabIndex = 29;
            // 
            // pbxDrgInjNoActOrder
            // 
            this.pbxDrgInjNoActOrder.Image = ((System.Drawing.Image)(resources.GetObject("pbxDrgInjNoActOrder.Image")));
            this.pbxDrgInjNoActOrder.Location = new System.Drawing.Point(738, 15);
            this.pbxDrgInjNoActOrder.Name = "pbxDrgInjNoActOrder";
            this.pbxDrgInjNoActOrder.Size = new System.Drawing.Size(16, 17);
            this.pbxDrgInjNoActOrder.TabIndex = 28;
            this.pbxDrgInjNoActOrder.TabStop = false;
            this.pbxDrgInjNoActOrder.Visible = false;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel8.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel8.Location = new System.Drawing.Point(8, 12);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(98, 20);
            this.xLabel8.TabIndex = 6;
            this.xLabel8.Text = "一括削除日";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "取消", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(1008, 7);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // btnDrgInjCancel
            // 
            this.btnDrgInjCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDrgInjCancel.ImageIndex = 0;
            this.btnDrgInjCancel.Location = new System.Drawing.Point(729, 9);
            this.btnDrgInjCancel.Name = "btnDrgInjCancel";
            this.btnDrgInjCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDrgInjCancel.Size = new System.Drawing.Size(254, 29);
            this.btnDrgInjCancel.TabIndex = 7;
            this.btnDrgInjCancel.Tag = "0";
            this.btnDrgInjCancel.Text = "薬　注射　　　「返却・取消」";
            this.btnDrgInjCancel.Click += new System.EventHandler(this.btnDrgInjCancel_Click);
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.fbxDoctor);
            this.xPanel1.Controls.Add(this.rbtToday);
            this.xPanel1.Controls.Add(this.rbtPre);
            this.xPanel1.Controls.Add(this.cboHo_dong);
            this.xPanel1.Controls.Add(this.rbtPost);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.fbxGwa);
            this.xPanel1.Controls.Add(this.pnlTop);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.dbxDoctor_name);
            this.xPanel1.Controls.Add(this.dpkOrder_date);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dbxGwa_name);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1255, 68);
            this.xPanel1.TabIndex = 0;
            // 
            // rbtToday
            // 
            this.rbtToday.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtToday.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtToday.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtToday.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtToday.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtToday.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtToday.ImageIndex = 0;
            this.rbtToday.ImageList = this.ImageList;
            this.rbtToday.Location = new System.Drawing.Point(247, 34);
            this.rbtToday.Name = "rbtToday";
            this.rbtToday.Size = new System.Drawing.Size(84, 27);
            this.rbtToday.TabIndex = 26;
            this.rbtToday.Text = "全体";
            this.rbtToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtToday.UseVisualStyleBackColor = false;
            this.rbtToday.Click += new System.EventHandler(this.Reser_gubun_RadioButton_Click);
            // 
            // rbtPre
            // 
            this.rbtPre.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtPre.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtPre.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtPre.Checked = true;
            this.rbtPre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtPre.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtPre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtPre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtPre.ImageIndex = 1;
            this.rbtPre.ImageList = this.ImageList;
            this.rbtPre.Location = new System.Drawing.Point(2, 34);
            this.rbtPre.Name = "rbtPre";
            this.rbtPre.Size = new System.Drawing.Size(100, 27);
            this.rbtPre.TabIndex = 25;
            this.rbtPre.TabStop = true;
            this.rbtPre.Text = "以前";
            this.rbtPre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtPre.UseVisualStyleBackColor = false;
            this.rbtPre.Click += new System.EventHandler(this.Reser_gubun_RadioButton_Click);
            // 
            // rbtPost
            // 
            this.rbtPost.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtPost.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtPost.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtPost.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtPost.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtPost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtPost.ImageIndex = 0;
            this.rbtPost.ImageList = this.ImageList;
            this.rbtPost.Location = new System.Drawing.Point(108, 34);
            this.rbtPost.Name = "rbtPost";
            this.rbtPost.Size = new System.Drawing.Size(133, 27);
            this.rbtPost.TabIndex = 24;
            this.rbtPost.Text = "以降(当日含む)";
            this.rbtPost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtPost.UseVisualStyleBackColor = false;
            this.rbtPost.Click += new System.EventHandler(this.Reser_gubun_RadioButton_Click);
            // 
            // grdNotActing
            // 
            this.grdNotActing.AddedHeaderLine = 1;
            this.grdNotActing.ApplyPaintEventToAllColumn = true;
            this.grdNotActing.CallerID = '2';
            this.grdNotActing.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell3,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell70,
            this.xEditGridCell75,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell89,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell2});
            this.grdNotActing.ColPerLine = 23;
            this.grdNotActing.Cols = 24;
            this.grdNotActing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNotActing.FixedCols = 1;
            this.grdNotActing.FixedRows = 2;
            this.grdNotActing.HeaderHeights.Add(30);
            this.grdNotActing.HeaderHeights.Add(0);
            this.grdNotActing.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdNotActing.Location = new System.Drawing.Point(0, 102);
            this.grdNotActing.Name = "grdNotActing";
            this.grdNotActing.QuerySQL = resources.GetString("grdNotActing.QuerySQL");
            this.grdNotActing.RowHeaderVisible = true;
            this.grdNotActing.Rows = 3;
            this.grdNotActing.RowStateCheckOnPaint = false;
            this.grdNotActing.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNotActing.Size = new System.Drawing.Size(1255, 444);
            this.grdNotActing.TabIndex = 5;
            this.grdNotActing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdNotActing_MouseDown);
            this.grdNotActing.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNotActing_QueryStarting);
            this.grdNotActing.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNotActing_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_code";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "ho_code";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellName = "ho_dong";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "病棟";
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.CellWidth = 68;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.HeaderText = "患者番号";
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.RowSpan = 2;
            this.xEditGridCell5.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pkinp1001";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "pkinp1001";
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.CellName = "suname";
            this.xEditGridCell7.CellWidth = 75;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderText = "患者名";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowSpan = 2;
            this.xEditGridCell7.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pkocs2003";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "pkocs2003";
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "group_ser";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "group_ser";
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "order_gubun";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "order_gubun";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellName = "hangmog_code";
            this.xEditGridCell10.CellWidth = 68;
            this.xEditGridCell10.Col = 7;
            this.xEditGridCell10.HeaderText = "オーダコード";
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.RowSpan = 2;
            this.xEditGridCell10.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.CellName = "hangmog_name";
            this.xEditGridCell11.CellWidth = 173;
            this.xEditGridCell11.Col = 8;
            this.xEditGridCell11.HeaderText = "オーダコード名";
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.RowSpan = 2;
            this.xEditGridCell11.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "specimen_code";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "specimen_code";
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.CellName = "specimen_name";
            this.xEditGridCell13.CellWidth = 30;
            this.xEditGridCell13.Col = 9;
            this.xEditGridCell13.HeaderText = "検体";
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.RowSpan = 2;
            this.xEditGridCell13.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell14.CellName = "suryang";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell14.CellWidth = 36;
            this.xEditGridCell14.Col = 10;
            this.xEditGridCell14.DecimalDigits = 2;
            this.xEditGridCell14.HeaderText = "数量";
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.RowSpan = 2;
            this.xEditGridCell14.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "ord_danui";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "ord_danui";
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell16.CellName = "ord_danui_name";
            this.xEditGridCell16.CellWidth = 34;
            this.xEditGridCell16.Col = 11;
            this.xEditGridCell16.HeaderText = "単位";
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.RowSpan = 2;
            this.xEditGridCell16.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dv_time";
            this.xEditGridCell17.CellWidth = 30;
            this.xEditGridCell17.Col = 12;
            this.xEditGridCell17.HeaderText = "dv_time";
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.Row = 1;
            this.xEditGridCell17.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "dv";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell18.CellWidth = 26;
            this.xEditGridCell18.Col = 13;
            this.xEditGridCell18.HeaderText = "dv";
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.Row = 1;
            this.xEditGridCell18.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "nalsu";
            this.xEditGridCell49.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell49.CellWidth = 34;
            this.xEditGridCell49.Col = 14;
            this.xEditGridCell49.HeaderText = "日数";
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.RowSpan = 2;
            this.xEditGridCell49.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "toiwon_drg_yn";
            this.xEditGridCell50.CellWidth = 39;
            this.xEditGridCell50.Col = 15;
            this.xEditGridCell50.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell50.HeaderText = "退院薬";
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.RowSpan = 2;
            this.xEditGridCell50.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "seq";
            this.xEditGridCell51.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.HeaderText = "seq";
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "input_gubun";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.HeaderText = "input_gubun";
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.CellName = "order_date";
            this.xEditGridCell57.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell57.Col = 5;
            this.xEditGridCell57.HeaderText = "オーダ日";
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.RowSpan = 2;
            this.xEditGridCell57.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "append_yn";
            this.xEditGridCell58.CellWidth = 35;
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.HeaderText = "追加";
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            this.xEditGridCell58.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "emergency";
            this.xEditGridCell62.CellWidth = 35;
            this.xEditGridCell62.Col = 16;
            this.xEditGridCell62.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell62.HeaderText = "緊急";
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.RowSpan = 2;
            this.xEditGridCell62.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "act_buseo";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.HeaderText = "act_buseo";
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "reser_date";
            this.xEditGridCell70.Col = 17;
            this.xEditGridCell70.HeaderText = "reser_date";
            this.xEditGridCell70.IsUpdatable = false;
            this.xEditGridCell70.Row = 1;
            this.xEditGridCell70.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell70.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "reser_time";
            this.xEditGridCell75.CellWidth = 40;
            this.xEditGridCell75.Col = 18;
            this.xEditGridCell75.HeaderText = "reser_time";
            this.xEditGridCell75.IsUpdatable = false;
            this.xEditGridCell75.Row = 1;
            this.xEditGridCell75.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "ocs_flag";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.HeaderText = "ocs_flag";
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "gwa";
            this.xEditGridCell77.CellWidth = 60;
            this.xEditGridCell77.Col = 19;
            this.xEditGridCell77.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell77.HeaderText = "入院科";
            this.xEditGridCell77.IsUpdatable = false;
            this.xEditGridCell77.RowSpan = 2;
            this.xEditGridCell77.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell77.UserSQL = resources.GetString("xEditGridCell77.UserSQL");
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "doctor";
            this.xEditGridCell78.CellWidth = 70;
            this.xEditGridCell78.Col = 20;
            this.xEditGridCell78.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell78.HeaderText = "主治医";
            this.xEditGridCell78.IsUpdatable = false;
            this.xEditGridCell78.RowSpan = 2;
            this.xEditGridCell78.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell78.UserSQL = "SELECT A.DOCTOR, A.DOCTOR_NAME, A.DOCTOR\r\n  FROM BAS0270 A\r\n WHERE TRUNC(SYSDATE)" +
                " BETWEEN A.START_DATE \r\n                          AND ADD_MONTHS(NVL(A.END_DATE," +
                " TO_DATE(\'99981231\')), 1) \r\n ORDER BY 3";
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "reser_yn_inp";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.HeaderText = "reser_yn_inp";
            this.xEditGridCell79.IsUpdatable = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "reser_yn";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.HeaderText = "reser_yn";
            this.xEditGridCell80.IsUpdatable = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "banab_gubun";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.HeaderText = "banab_gubun";
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "input_tab";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "input_tab";
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "input_gwa";
            this.xEditGridCell20.CellWidth = 60;
            this.xEditGridCell20.Col = 21;
            this.xEditGridCell20.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell20.HeaderText = "診療科";
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell20.UserSQL = resources.GetString("xEditGridCell20.UserSQL");
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "input_doctor";
            this.xEditGridCell21.CellWidth = 70;
            this.xEditGridCell21.Col = 22;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell21.HeaderText = "診療医師";
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell21.UserSQL = "SELECT A.DOCTOR, A.DOCTOR_NAME, A.DOCTOR\r\n  FROM BAS0270 A\r\n WHERE TRUNC(SYSDATE)" +
                " BETWEEN A.START_DATE \r\n                          AND ADD_MONTHS(NVL(A.END_DATE," +
                " TO_DATE(\'99981231\')), 1) \r\n ORDER BY 3";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "order_gubun_name";
            this.xEditGridCell22.CellWidth = 64;
            this.xEditGridCell22.Col = 6;
            this.xEditGridCell22.HeaderText = "オーダ区分";
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "jubsu_date";
            this.xEditGridCell23.CellWidth = 11;
            this.xEditGridCell23.Col = 23;
            this.xEditGridCell23.HeaderText = "jubsu_date";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.RowSpan = 2;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.CellName = "select";
            this.xEditGridCell2.CellWidth = 30;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "選択";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.RowSpan = 2;
            this.xEditGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 12;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 30;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 17;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderText = "予約日時";
            // 
            // dloDCOrder
            // 
            this.dloDCOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            this.multiLayoutItem1.IsUpdItem = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "pkinp1001";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem2.IsUpdItem = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname";
            this.multiLayoutItem3.IsUpdItem = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pkocs2003";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem4.IsUpdItem = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "order_gubun";
            this.multiLayoutItem5.IsUpdItem = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "hangmog_code";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "hangmog_name";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteAll.ImageIndex = 0;
            this.btnDeleteAll.ImageList = this.ImageList;
            this.btnDeleteAll.Location = new System.Drawing.Point(52, 3);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDeleteAll.Size = new System.Drawing.Size(43, 29);
            this.btnDeleteAll.TabIndex = 7;
            this.btnDeleteAll.Tag = "0";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectAll.ImageIndex = 1;
            this.btnSelectAll.ImageList = this.ImageList;
            this.btnSelectAll.Location = new System.Drawing.Point(5, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSelectAll.Size = new System.Drawing.Size(43, 29);
            this.btnSelectAll.TabIndex = 6;
            this.btnSelectAll.Tag = "1";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.cbxOrderGubun);
            this.xPanel2.Controls.Add(this.btnSelectAll);
            this.xPanel2.Controls.Add(this.btnDeleteAll);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 68);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1255, 34);
            this.xPanel2.TabIndex = 8;
            // 
            // cbxOrderGubun
            // 
            this.cbxOrderGubun.DropDownHeight = 150;
            this.cbxOrderGubun.IntegralHeight = false;
            this.cbxOrderGubun.ItemHeight = 13;
            this.cbxOrderGubun.Location = new System.Drawing.Point(199, 7);
            this.cbxOrderGubun.Name = "cbxOrderGubun";
            this.cbxOrderGubun.Size = new System.Drawing.Size(121, 21);
            this.cbxOrderGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cbxOrderGubun.TabIndex = 8;
            this.cbxOrderGubun.UserSQL = resources.GetString("cbxOrderGubun.UserSQL");
            this.cbxOrderGubun.SelectedIndexChanged += new System.EventHandler(this.cbxOrderGubun_SelectedIndexChanged);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Location = new System.Drawing.Point(101, 7);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(98, 21);
            this.xLabel4.TabIndex = 6;
            this.xLabel4.Text = "オーダ区分";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHelp2
            // 
            this.btnHelp2.ImageIndex = 15;
            this.btnHelp2.ImageList = this.ImageList;
            this.btnHelp2.Location = new System.Drawing.Point(1, 102);
            this.btnHelp2.Name = "btnHelp2";
            this.btnHelp2.Size = new System.Drawing.Size(25, 32);
            this.btnHelp2.TabIndex = 21;
            this.btnHelp2.Text = "色";
            this.btnHelp2.Click += new System.EventHandler(this.btnHelp2_Click);
            // 
            // pnlHelp2
            // 
            this.pnlHelp2.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.pnlHelp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHelp2.Controls.Add(this.xLabel18);
            this.pnlHelp2.Controls.Add(this.xLabel7);
            this.pnlHelp2.Controls.Add(this.xLabel6);
            this.pnlHelp2.Controls.Add(this.xLabel9);
            this.pnlHelp2.Location = new System.Drawing.Point(2, 134);
            this.pnlHelp2.Name = "pnlHelp2";
            this.pnlHelp2.Size = new System.Drawing.Size(107, 178);
            this.pnlHelp2.TabIndex = 22;
            this.pnlHelp2.Visible = false;
            // 
            // xLabel18
            // 
            this.xLabel18.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Gold);
            this.xLabel18.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel18.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel18.Location = new System.Drawing.Point(4, 102);
            this.xLabel18.Name = "xLabel18";
            this.xLabel18.Size = new System.Drawing.Size(97, 29);
            this.xLabel18.TabIndex = 12;
            this.xLabel18.Text = "予約済み";
            this.xLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.YellowGreen);
            this.xLabel7.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel7.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel7.Location = new System.Drawing.Point(4, 69);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(97, 29);
            this.xLabel7.TabIndex = 11;
            this.xLabel7.Text = "部門受付済み";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGray);
            this.xLabel6.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel6.Location = new System.Drawing.Point(4, 37);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(97, 29);
            this.xLabel6.TabIndex = 10;
            this.xLabel6.Text = "会計済み";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel9
            // 
            this.xLabel9.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.xLabel9.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel9.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel9.Location = new System.Drawing.Point(4, 5);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(97, 29);
            this.xLabel9.TabIndex = 4;
            this.xLabel9.Text = "会計未完了";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OCS2003Q02
            // 
            this.Controls.Add(this.btnHelp2);
            this.Controls.Add(this.pnlHelp2);
            this.Controls.Add(this.grdNotActing);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel3);
            this.Name = "OCS2003Q02";
            this.Size = new System.Drawing.Size(1255, 590);
            this.UserChanged += new System.EventHandler(this.OCS2003Q02_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS2003Q02_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDrgInjNoActOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotActing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloDCOrder)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.pnlHelp2.ResumeLayout(false);
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
			
			CreateCboHo_dong();
            
			PostCallHelper.PostCall(new PostMethod(PostLoad));			
		}

		private void OCS2003Q02_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(!TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
							mBunho = OpenParam["bunho"].ToString().Trim();
					}


                    if (OpenParam.Contains("order_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["order_date"].ToString()))
                        {
                            this.dpkOrder_date.SetDataValue(OpenParam["order_date"].ToString());
                            this.dpkBatchDeleteDate.SetDataValue(DateTime.Parse(OpenParam["order_date"].ToString()).AddDays(1));
                        }
                    }
                    else
                    {
                        this.dpkOrder_date.SetDataValue(EnvironInfo.GetSysDate());
                        this.dpkBatchDeleteDate.SetDataValue(EnvironInfo.GetSysDate());
                    }
				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
			}
			else
			{
				XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
				if (patientInfo != null)
				{
					mBunho = patientInfo.BunHo;					
				}

                this.dpkOrder_date.SetDataValue(EnvironInfo.GetSysDate());
                this.dpkBatchDeleteDate.SetDataValue(EnvironInfo.GetSysDate());
			}

			if (this.cbxOrderGubun.ComboItems.Count > 0)
                this.cbxOrderGubun.SelectedIndex = 0;
					
		}
        
		private void PostLoad()
		{	
			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS2003Q02_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////			
		}

		private void OCS2003Q02_UserChanged(object sender, System.EventArgs e)
		{
			bool query = true;

			ClearControl();

			if(UserInfo.UserGubun == UserType.Doctor)
			{
                //pnlDoctor.Visible = true;
                //pnlNurse.Visible = false;

				mGwa = UserInfo.Gwa;
                //fbxGwa.SetDataValue(UserInfo.Gwa);
                //dbxGwa_name.SetDataValue(UserInfo.GwaName);
                fbxGwa.SetDataValue("%");
                dbxGwa_name.SetDataValue("全体");

				mDoctor = UserInfo.UserID;
                //fbxDoctor.SetDataValue(UserInfo.DoctorID);
                //dbxDoctor_name.SetDataValue(UserInfo.UserName);
                fbxDoctor.SetDataValue("%");
                dbxDoctor_name.SetDataValue("全体");

				mInput_gubun = "D%";

                this.rbtPost.Checked = true;
			}
			else
			{
                //pnlDoctor.Visible = false;
                //pnlNurse.Visible = true;

				if(UserInfo.UserGubun == UserType.Nurse)
				{
					mHo_dong = "%";
					mHo_team = UserInfo.NurseTeam;

					try
					{
						if(!TypeCheck.IsNull(mHo_dong))
						{
							cboHo_dong.SelectedValue = mHo_dong;
						}
					}
					catch
					{
						try
						{
							cboHo_dong.SelectedValue = "%";
							query= false;
						}
						catch{}
					}
				}

				mInput_gubun = "NR";

                this.rbtToday.Checked = true;
			}

			if(!TypeCheck.IsNull(mBunho))
			{
				query= false;
				this.pbxSearch.SetPatientID(mBunho);
			}

			if(query) this.LoadData();

		}		

		#endregion

		#region [Combo Control]
        
		private void CreateCboHo_dong()
		{
			this.cboHo_dong.DataSource = null;
			this.cboHo_dong.SetComboItems(this.mOrderBiz.LoadComboDataSource("ho_dong").LayoutTable, "code_name", "code", XComboSetType.AppendAll);
			this.cboHo_dong.SelectedIndex = 0;
		}

		/// <summary>
		/// 병동 변경시 간호팀 combo 재구성
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cboHo_dong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ho_dong = cboHo_dong.SelectedValue.ToString();

			if(mInput_gubun == "NR")
				this.LoadData();
		}

		#endregion

		#region [GetFindWorker]

		private XFindWorker GetFindWorker(string findMode, string ref_code)
		{
			XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
			
			switch (findMode)
			{
				case "gwa":

					fdwCommon.AutoQuery    = true;
					fdwCommon.ServerFilter = false;
                    fdwCommon.InputSQL = @"SELECT '%', '全体', '0'
                                             FROM SYS.DUAL
                                            UNION
                                           SELECT A.GWA, A.GWA_NAME, A.GWA
                        	                 FROM VW_BAS_GWA A
                        	                WHERE A.IPWON_YN = 'Y'
                                              AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
                                              AND A.BUSEO_GUBUN = '1'
						                    ORDER BY 3";

					fdwCommon.FormText = "診療科照会";
					fdwCommon.ColInfos.Add("hangmog_code", "診療科コード", FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("hangmog_name", "診療科名 ", FindColType.String, 300, 0, true, FilterType.Yes);

					break;

				case "doctor":

					fdwCommon.AutoQuery    = true;
					fdwCommon.ServerFilter = false;
                    fdwCommon.InputSQL = @"SELECT '%', '全体', '0'
                                            FROM SYS.DUAL
                                           UNION
                                          SELECT A.DOCTOR, A.DOCTOR_NAME, A.DOCTOR
                                            FROM BAS0270 A
                                           WHERE A.DOCTOR_GWA = '" + ref_code + @"'
                                             AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND ADD_MONTHS(NVL(A.END_DATE, TO_DATE('99981231')), 1) 
                                           ORDER BY 3";

					fdwCommon.FormText = "診療医師照会";
					fdwCommon.ColInfos.Add("hangmog_code", "診療医師コード", FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("hangmog_name", "診療医師名 ", FindColType.String, 300, 0, true, FilterType.Yes);

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
				case "gwa_name":
                    if (code == "%")
                        codeName = "全体";
                    else
                    {
                        cmdText = " SELECT A.GWA_NAME                                                   "
                                + "	  FROM VW_BAS_GWA A                                                     "
                                + "	 WHERE GWA = '" + code + "' "
                                + "    AND A.IPWON_YN = 'Y'                                                 "
                                + "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) "
                                + "	   AND A.BUSEO_GUBUN = '1' ";

                        retVal = Service.ExecuteScalar(cmdText);

                        if (retVal != null)
                            codeName = retVal.ToString();
                        else
                            codeName = "";
                    }
					break;

				case "doctor_name":
                    if (code == "%")
                        codeName = "全体";
                    else
                    {
                        string gwa = fbxGwa.GetDataValue();

                        if (TypeCheck.IsNull(gwa))
                        {
                            codeName = "XXX";
                            break;
                        }

                        cmdText = "SELECT A.DOCTOR_NAME                                                      "
                            + "  FROM BAS0270 A                                                          "
                            + " WHERE A.DOCTOR = '" + code + "' "
                            + "   AND A.DOCTOR_GWA = '" + gwa + "' "
                            + "   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND ADD_MONTHS(NVL(A.END_DATE, TO_DATE('99981231')), 1) ";


                        retVal = Service.ExecuteScalar(cmdText);

                        if (retVal != null)
                            codeName = retVal.ToString();
                        else
                            codeName = "";
                    }
					break;


			        
				default:
					break;
			}

			return codeName;
		}

		#endregion

		#region [Find Control]
		
		private void fbxGwa_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			fbxGwa.FindWorker = this.GetFindWorker("gwa", "");
		}

		private void fbxGwa_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string codeName = "";

			fbxDoctor.SetDataValue("%");
			dbxDoctor_name.SetDataValue("全体");

			if(e.DataValue == "")
			{
				dbxGwa_name.SetDataValue("");				
				return;
			}

			//Check Origin Data
			codeName = this.GetCodeName("gwa_name", e.DataValue.ToString());

			if(codeName == "")
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正確でがはないです. 確認してください." : "진료과가 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);			
				dbxGwa_name.SetEditValue("");
			}					
			else
			{
				dbxGwa_name.SetEditValue(codeName);
				if(mInput_gubun == "D%")
					this.LoadData();
			}
		
		}

		private void fbxDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string gwa = fbxGwa.GetDataValue();

			if(TypeCheck.IsNull(gwa))
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正確でがはないです. 確認してください." : "진료과가 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				return;
			}
					
			fbxDoctor.FindWorker = this.GetFindWorker("doctor", gwa);		
		}

		private void fbxDoctor_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string codeName = "";

			if(e.DataValue == "")
			{
				dbxDoctor_name.SetDataValue("");				
				return;
			}

			codeName = this.GetCodeName("doctor_name", e.DataValue.ToString());

			if(codeName == "")
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "診療医師が正確でがはないです. 確認してください." : "진료의사가 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				dbxDoctor_name.SetEditValue("");			
			}	
			else if(codeName == "XXX")
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "診療科が正確でがはないです. 確認してください." : "진료과가 정확하지않습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap);
				dbxDoctor_name.SetEditValue("");				
			}			
			else
			{
				dbxDoctor_name.SetEditValue(codeName);
				if(mInput_gubun == "D%")
					this.LoadData();
			}

		}

		#endregion

		#region [예약검사여부에 따른 Filtering]
		/// <summary>
		/// 내원구분에 따른 내원자 Filtering
		/// </summary>
		private void Reser_gubun_RadioButton_Click(object sender, System.EventArgs e)
		{
            if (this.pbxSearch.BunHo == "")
                return;

            //grdNotActing.ClearFilter();
            this.mTimeGubun = "";

			if(rbtPre.Checked)
			{
				rbtPre.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtPre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtPre.ImageIndex = 1;

				rbtPost.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtPost.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtPost.ImageIndex = 0;

				rbtToday.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtToday.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtToday.ImageIndex = 0;
                this.mTimeGubun = "PRE";

                //grdNotActing.ClearFilter();
                //if(this.grdNotActing.RowCount > 0) grdNotActing.SetFilter(" reser_yn_inp = 'Y' ");
				
			}
			else if(rbtPost.Checked)
			{
				rbtPost.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtPost.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtPost.ImageIndex = 1;

				rbtPre.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtPre.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtPre.ImageIndex = 0;

				rbtToday.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtToday.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtToday.ImageIndex = 0;
                this.mTimeGubun = "POST";

                //grdNotActing.ClearFilter();
                //if(grdNotActing.RowCount > 0) grdNotActing.SetFilter(" reser_yn_inp <> 'Y' ");
			}
			else
			{
				rbtToday.BackColor = System.Drawing.SystemColors.ActiveCaption;
				rbtToday.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				rbtToday.ImageIndex = 1;

				rbtPre.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtPre.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtPre.ImageIndex = 0;

				rbtPost.BackColor = System.Drawing.SystemColors.InactiveCaption;
				rbtPost.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
				rbtPost.ImageIndex = 0;
                this.mTimeGubun = "ALL";

                //grdNotActing.ClearFilter();
			}
            this.grdNotActing.QueryLayout(true);
			SelectionBackColorChange(this.grdNotActing);
            this.CheckDrgInjNoActOrder();
		}
		#endregion

		#region [Data Load]

		private void LoadData()
		{
            if (this.pbxSearch.BunHo == "")
                return;

			if(!TypeCheck.IsDateTime(dpkOrder_date.GetDataValue()))
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "日付を間違えて入力しました。. 確認してください." : "일자를 잘못 입력하셨습니다. 확인바랍니다.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				dpkOrder_date.Focus();
				return;
			}
			
			try
			{	
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				SetMsg("");

				this.grdNotActing.ClearFilter();
				
                //mOrder_date = dpkOrder_date.GetDataValue();
				mGwa     = TypeCheck.IsNull(fbxGwa.GetDataValue()) ? "%" : fbxGwa.GetDataValue();
				mDoctor  = TypeCheck.IsNull(fbxDoctor.GetDataValue()) ? "%" : fbxDoctor.GetDataValue();
				mHo_dong = cboHo_dong.SelectedValue == null ? "%" : cboHo_dong.SelectedValue.ToString();
				mBunho   = TypeCheck.IsNull(pbxSearch.BunHo) ? "%" : pbxSearch.BunHo;

                this.grdNotActing.QueryLayout(true);

				SelectionBackColorChange(this.grdNotActing);
                
				//예약검사
				Reser_gubun_RadioButton_Click(rbtPre, new System.EventArgs());
				
			}
			finally
			{
				SetMsg(" ");
                CheckDrgInjNoActOrder();
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}
	
		#endregion

		#region [Control Clear]
        
		/// <summary>
		/// 조회조건 Clear
		/// </summary>
		private void ClearControl()
		{
			grdNotActing.ClearFilter();
			grdNotActing.Reset();

			//Doctor
			fbxGwa.SetDataValue("");
			dbxGwa_name.SetDataValue("");

			fbxDoctor.SetDataValue("");
			dbxDoctor_name.SetDataValue("");
            
			try
			{
				cboHo_dong.SelectedValue = "%";
			}
			catch{}

		}

		#endregion

		#region [grdNotActing Event]
		
		private void grdNotActing_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				int rowIndex = grdNotActing.GetHitRowNumber(e.Y);				
				if(rowIndex < 0) return;

				if(grdNotActing.CurrentColNumber == 0)
				{	
					if(grdNotActing.GetItemInt(rowIndex, "suryang") < 0)
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "まだ返却確認がされてないオーダです。該当部署に確認してください。" : "아직 반납확인이 되지 않은 Order입니다. 해당 부서에 확인하십시오.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "확인" : "確認";
						XMessageBox.Show(mbxMsg, mbxCap);	
						return;
					}

					if(grdNotActing.GetItemString(rowIndex, "select") == "")
					{
						grdNotActing.SetItemValue(rowIndex, "select", " ");
						SelectionBackColorChange(sender, rowIndex, "Y");
					}
					else
					{
						grdNotActing.SetItemValue(rowIndex, "select", "");
						SelectionBackColorChange(sender, rowIndex, "N");
					}
				}
			}	
		}

		#endregion
		
		#region 환자번호입력시
		private void pbxSearch_PatientSelected(object sender, System.EventArgs e)
		{
			if(!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
			{
				/* 재원화자 정보 조회 */
				this.Fkinp1001();
			}
		}
		#endregion
		
		#region 재원여부 조회
		/// <summary>
		/// 환자의 재원여부를 조회한다.
		/// </summary>
		private bool Fkinp1001()
		{
			string bunho = pbxSearch.BunHo;

			/* 환자의 입원이력을 조회한다. */
			string cmdText 
				= "  SELECT PKINP1001				"
				+ "      FROM INP1001                           "
				+ "     WHERE NVL(CANCEL_YN,'N')   = 'N'        "
				+ "       AND NVL(JAEWON_FLAG,'N') = 'Y'        "
				+ "       AND IPWON_TYPE           = '0'        "
				+ "       AND BUNHO                = '"+bunho+"'   ";

			object retVal = Service.ExecuteScalar(cmdText);

			if( retVal != null ) //재원환자이면(조회및 입력이 가능)
			{
				LoadData();
				return true;
			}
			else
			{
				/* 재원중인 환자가 아니므로 메세지를 보여준다. */
				mbxMsg = NetInfo.Language == LangMode.Jr ? "在院中の患者様ではありません." + "\n" + "患者番号を確認してください." : "재원중인 환자가 아닙니다." + "\n" +" 환자번호를 확인해 주세요";
				mbxCap = NetInfo.Language == LangMode.Jr ? "Infomation" : "Infomation";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return false;
			}

		}

        private string GetPKINP1001()
        {
            string bunho = pbxSearch.BunHo;

            /* 환자의 입원이력을 조회한다. */
            string cmdText
                = "  SELECT PKINP1001				"
                + "      FROM INP1001                           "
                + "     WHERE NVL(CANCEL_YN,'N')   = 'N'        "
                + "       AND NVL(JAEWON_FLAG,'N') = 'Y'        "
                + "       AND IPWON_TYPE           = '0'        "
                + "       AND BUNHO                = '" + bunho + "'   ";

            object retVal = Service.ExecuteScalar(cmdText);

            if (retVal != null) //재원환자이면(조회및 입력이 가능)
            {
                LoadData();
                return retVal.ToString();
            }
            else
            {
                /* 재원중인 환자가 아니므로 메세지를 보여준다. */
                mbxMsg = NetInfo.Language == LangMode.Jr ? "在院中の患者様ではありません." + "\n" + "患者番号を確認してください." : "재원중인 환자가 아닙니다." + "\n" + " 환자번호를 확인해 주세요";
                mbxCap = NetInfo.Language == LangMode.Jr ? "Infomation" : "Infomation";
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return "0";
            }

        }
		#endregion

		#region [DC정보생성]

		private bool CreateReturnValue()
		{
			dloDCOrder.Reset();

			this.AcceptData();

			grdNotActing.ClearFilter();
			int newRowIndex;

			foreach(DataRow row in grdNotActing.LayoutTable.Rows)
			{
				if(row["select"].ToString() == " ")
				{
					newRowIndex = dloDCOrder.InsertRow(-1);
					dloDCOrder.SetItemValue(newRowIndex, "bunho"       , row["bunho"       ]);
					dloDCOrder.SetItemValue(newRowIndex, "pkinp1001"   , row["pkinp1001"   ]);
					dloDCOrder.SetItemValue(newRowIndex, "suname"      , row["suname"      ]);
					dloDCOrder.SetItemValue(newRowIndex, "pkocs2003"   , row["pkocs2003"   ]);
					dloDCOrder.SetItemValue(newRowIndex, "order_gubun" , row["order_gubun" ]);
					dloDCOrder.SetItemValue(newRowIndex, "hangmog_code", row["hangmog_code"]);
					dloDCOrder.SetItemValue(newRowIndex, "hangmog_name", row["hangmog_name"]);
				}
			}

			if(dloDCOrder.LayoutTable.Rows.Count > 0 )
				return true;
			else
				return false;
		}

		#endregion

        private bool CheckDrgInjNoActOrder()
        {
            //未実施薬があるかどうかチェック
            string cmd = @" SELECT FN_OCS_IS_YET_BANNAB_ORDER(:f_hosp_code, :f_bunho, :f_kijun_date) FROM SYS.DUAL";

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_bunho", this.pbxSearch.BunHo.ToString());
            bind.Add("f_kijun_date", this.dpkOrder_date.GetDataValue());

            //if(this.mTimeGubun == "PRE")
            //    bind.Add("f_be_af_gubun", "BEFORE");
            //else if(this.mTimeGubun == "POST")
            //    bind.Add("f_be_af_gubun", "AFTER");
            //else
            //    bind.Add("f_be_af_gubun", "ALL");

            object obj = Service.ExecuteScalar(cmd, bind);
            /* RETURN VALUE 
             * BEFORE : 基準日より前に未投与オーダがある場合
             * AFTER  : 基準日より後にオーダが出ている場合
             * ALL　　: BEFORE, AFTER 両方ある場合
             * NOROW　: 未実施のオーダがない場合
            */

            if (obj != null && obj.ToString() != "NOROW")
            {
                this.pbxDrgInjNoActOrder.Visible = true;
                return true;
            }
            else
            {
                this.pbxDrgInjNoActOrder.Visible = false;
                return false;
            }
        }

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					
					e.IsBaseCall = false;

					LoadData();
                    
					break;

				case FunctionType.Update:

                    if (this.pbxSearch.BunHo == "")
                        return;

					e.IsBaseCall = false;

                    //if(!CreateReturnValue())
                    //    return;

                    //if(dloDCOrder.SaveLayout())
                    //{						
                    //    mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が完了しました。" : "처리가 완료되었습니다.";
                    //    SetMsg(mbxMsg);
                        
                    //    this.LoadData();

                    //    try
                    //    {
                    //        IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

                    //        CommonItemCollection commandParams  = new CommonItemCollection();
                    //        commandParams.Add( "retrieve", "Y");
                    //        scrOpener.Command(this.ScreenID, commandParams);
                    //    }
                    //    catch
                    //    {
                    //    }
                    //}
                    //else
                    //{
                    //    mbxMsg = NetInfo.Language == LangMode.Jr ? "処理が失敗しました。" : "처리 실패하였습니다."; 
                    //    //mbxMsg = mbxMsg + dsvSave.ErrMsg;
                    //    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    //    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                    //}

                    //[中止しようとした場合、中止するデータがあるのかまた中止日が設定されているのかをチェック]
                    if (!this.BannabProcessCheck(true))
                        return;

                    if (this.BannabProcess(true))
                        this.grdNotActing.QueryLayout(true);

					break;
				
				default:

					break;
			}	
		}


		#endregion

        private bool BannabProcessCheck(bool isBannab)
        {
            string msg = "";
            bool isExistData = false;

            //for (int i = 0; i < this.grdNotActing.RowCount; i++)
            //{
            //    if (this.grdNotActing.GetItemString(i, "select") == " ")
            //    {
            //        isExistData = true;
            //        if (isBannab && this.grdNotActing.GetItemString(i, "stop_date") == "")
            //        {
            //            msg = "[" + this.grdNotActing.GetItemString(i, "hangmog_code") + "] " + this.grdNotActing.GetItemString(i, "hangmog_name") + "\n"
            //                + "=====================================================================" + "\n"
            //                + XMsg.GetMsg("M002");

            //            XMessageBox.Show(msg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return false;
            //        }
            //    }
            //}
            //if (isExistData == false)
            //{
            //    XMessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            return true;
        }

        private bool BannabProcess(bool aIsBannab)
        {
            string procName = "PR_OCSI_PROCESS_BANNAB_NEW";
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();
            string sysdate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            //mCancel_info.Clear();
            mCancel_drg_bunho_list.Clear();
            mCancel_jubsu_list.Clear();
            mCancel_input_list.Clear();

            Service.BeginTransaction();
            try
            {
                foreach (DataRow row in this.grdNotActing.LayoutTable.Rows)
                {
                    if (row["select"].ToString() == " ")
                    {
                        inList.Clear();
                        inList.Add((aIsBannab == true ? "I" : "C")); //aIsBannab(rbtDC.Checked)
                        inList.Add(row["bunho"].ToString());
                        inList.Add(row["pkinp1001"].ToString());
                        inList.Add(row["pkocs2003"].ToString());
                        inList.Add((aIsBannab == true ? row["order_date"].ToString() : sysdate));
                        inList.Add((aIsBannab == true ? row["order_date"].ToString() : sysdate));
                        inList.Add(row["input_doctor"].ToString());
                        inList.Add(UserInfo.UserID);
                        inList.Add("1"); // 1:返却、2:退院処方に変更

                        inList.Add(row["dv"].ToString()); // 返却回数
                        inList.Add(""); // 返却後服用方法

                        inList.Add(row["dv"].ToString()); // 退院処方回数
                        inList.Add(""); // 退院処方服用方法

                        outList.Clear();

                        if (Service.ExecuteProcedure(procName, inList, outList) == false)
                        {
                            throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                        }

                        if (outList[0].ToString() != "0")
                        {
                            throw new Exception(XMsg.GetMsg("M004") + "-" + outList[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageBox.Show(ex.Message, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Service.RollbackTransaction();
                return false;
            }

            Service.CommitTransaction();

            //DrgPrintProcess();

            return true;
        }



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
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
				}
			}
		}

		private void grdNotActing_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.grdNotActing.SetBindVarValue("f_order_date",   this.dpkOrder_date.GetDataValue());
			this.grdNotActing.SetBindVarValue("f_gwa",          this.mGwa);
			this.grdNotActing.SetBindVarValue("f_doctor",       this.mDoctor);
			this.grdNotActing.SetBindVarValue("f_ho_dong",      this.mHo_dong);
			this.grdNotActing.SetBindVarValue("f_ho_team",      this.mHo_team);
			this.grdNotActing.SetBindVarValue("f_bunho",        this.mBunho);
			this.grdNotActing.SetBindVarValue("f_input_gubun",  this.mInput_gubun);
            this.grdNotActing.SetBindVarValue("f_time_gubun",   this.mTimeGubun);
            this.grdNotActing.SetBindVarValue("f_order_gubun",  this.cbxOrderGubun.SelectedValue.ToString());

		}
		
		private void SelectionBackColorChange(object grid)
		{
			XEditGrid grdObject = (XEditGrid)grid;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];					

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
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion

		
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
			private OCS2003Q02 parent = null;

			/// <summary>
			/// XSavePerformer 를 사용.
			/// </summary>
			/// <param name="parent">화면 생성자 (프로그램명)</param>
			public XSavePerformer(OCS2003Q02 parent)
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
				string spName = "PR_OCSI_PROCESS_DOCTOR_CANCEL";
                string cmdText = "";
                ArrayList inList = new ArrayList();
                ArrayList outList = new ArrayList();
				object retVal = ""; 
				string mbxMsg = "", mbxCap = "";		
			
				switch (callerID)
				{
					case '1':
						#region  dloDCOrder  저장 로직.   DC 건 생성
					    switch (item.RowState)
					    {
						    case DataRowState.Added:
                            case DataRowState.Modified:
                            case DataRowState.Deleted:
							    cmdText = " SELECT DECODE(ACTING_DATE, NULL, 'N', 'Y')  FROM OCS2003 "
								        + " WHERE PKOCS2003 = :f_pkocs2003 ";

							    retVal = Service.ExecuteScalar(cmdText,item.BindVarList);

							    if( retVal != null )
							    {
								    if( retVal.ToString() == "Y")
								    {
									    mbxMsg = NetInfo.Language == LangMode.Jr ? "既に施行されたオーダ ["+item.BindVarList["f_bunho"].VarValue+"]["+item.BindVarList["f_suname"].VarValue+"]["+item.BindVarList["f_hangmog_code"].VarValue+"]["+item.BindVarList["f_hangmog_name"].VarValue+"]が存在します。再照会を行って処理してください。": "이미 시행된 Order ["+item.BindVarList["f_bunho"].VarValue+"]["+item.BindVarList["f_suname"].VarValue+"]["+item.BindVarList["f_hangmog_code"].VarValue+"]["+item.BindVarList["f_hangmog_name"].VarValue+"]가 존재합니다. 재조회하신후에 처리하십시오.";
									    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
									    XMessageBox.Show(mbxMsg, mbxCap);

                                        return false;
								    }
							    }

                                inList.Clear();
                                outList.Clear();

                                inList.Add(item.BindVarList["f_pkocs2003"].VarValue);
                                inList.Add(UserInfo.UserID);

                                if (Service.ExecuteProcedure(spName, inList, outList) == false)
                                {
                                    return false;
                                }

                                if (outList[0].ToString() != "0")
                                {
                                    mbxMsg = "オーダ取消に失敗しました。-" + outList[0].ToString();
                                    mbxCap = "保存失敗";
                                    MessageBox.Show(mbxMsg, mbxCap);
                                    return false;
                                }

							    break;

					    }
						#endregion

                        break;
				}

				return true;

			}
		}
		#endregion

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;

            if (ctl.Tag.ToString() == "1")
                this.grdSelectAll(this.grdNotActing);
            else
                this.grdDeleteAll(this.grdNotActing);
        }

        /// <summary>
        /// 해당 Grid 전체선택 해제
        /// </summary>
        /// <param name="grd"></param>
        /// <param name="select"></param>
        //private bool grdSelectAll(XGrid grdObject, string aGroupSer, bool select)
        private bool grdSelectAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                grdObject.SetItemValue(rowIndex, "select", " ");
                SelectionBackColorChange(grdObject, rowIndex, "Y");
            }

            return true;

        }

        private bool grdDeleteAll(XGrid grdObject)
        {
            int rowIndex = -1;

            for (rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
            {
                grdObject.SetItemValue(rowIndex, "select", "");
                SelectionBackColorChange(grdObject, rowIndex, "N");
            }
            return true;
        }

        private void cbxOrderGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDrgInjCancel_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            string aPKINP1001 = "";

            aPKINP1001 = GetPKINP1001();
            if (aPKINP1001 != "0")
                param.Add("fkinp1001", aPKINP1001);

            param.Add("bunho", this.pbxSearch.BunHo);
            param.Add("query_date", this.dpkOrder_date.GetDataValue());

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U03", ScreenOpenStyle.ResponseFixed, param);
        }

        private void grdNotActing_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["jubsu_date"].ToString() != "" && e.ColName == "hangmog_name")
                e.BackColor = Color.YellowGreen;
            if (e.ColName == "hangmog_name")
            {
                switch (e.DataRow["ocs_flag"].ToString())
                {
                    case "1":
                        break;
                    case "2":
                        e.BackColor = Color.YellowGreen;
                        break;
                    case "3":
                        e.BackColor = Color.LightBlue;
                        break;
                    case "4":
                        e.BackColor = Color.LightGray;
                        break;
                    case "5":
                        e.BackColor = Color.Gold;
                        break;

                }
            }
        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            if(this.pnlHelp2.Visible == false)
                pnlHelp2.Visible = true;
            else
                pnlHelp2.Visible = false;
        }

        private void btnBatchDeleteProcess_Click(object sender, EventArgs e)
        {
            /*
              I_PKINP1001       IN NUMBER
              I_DELETE_DATE     IN DATE
              O_PROCESSED_COUNT OUT NUMBER
              O_ERR             OUT VARCHAR2 
             */
            string procName = "PR_OCSI_BATCH_DELETE_ORDER";
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();

            if (XMessageBox.Show("["+ this.dpkBatchDeleteDate.GetDataValue() +"]　からの　「薬」、「注射薬」を除外したすべてのオーダが削除されます。宜しいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                Service.BeginTransaction();
                try
                {
                    inList.Clear();
                    inList.Add(GetPKINP1001());
                    inList.Add(this.dpkBatchDeleteDate.GetDataValue());

                    outList.Clear();

                    if (Service.ExecuteProcedure(procName, inList, outList) == false)
                    {
                        throw new Exception(outList[1].ToString());
                    }

                    if (int.Parse(outList[0].ToString()) == 0)
                    {
                        throw new Exception("削除対象が存在しませんでした。処理件数「0」件");
                    }

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Service.RollbackTransaction();
                    return;
                }
                finally
                {
                    Cursor.Current = System.Windows.Forms.Cursors.Default;
                }

                Service.CommitTransaction();
                XMessageBox.Show("一括削除が正常に終了しました。処理件数「" + outList[0].ToString() + "」", "確認");
                btnList.PerformClick(FunctionType.Query);
            }
        }
	}
}

