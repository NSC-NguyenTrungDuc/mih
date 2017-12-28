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
	/// NUR9001U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR9001U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string tag       = string.Empty;
		private string sysid     = string.Empty;
		private string screen    = string.Empty;
        private bool jaewon = false;    //재원중인지 아닌지 체크하는 플래그
        string times1, times2, times3; //시간구분
        int paListRownum = 0; //현재 선택된 환자의 grid넘버
		#endregion

		#region 자동생성
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPanel pnlCenter;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XPanel pnlRightTop;
        private IHIS.Framework.XTreeView tvwSoap;
        private IHIS.Framework.XEditGrid grdNUR9001;
		private IHIS.Framework.XFindWorker fwkFind;
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
		private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XGridHeader xGridHeader2;
        private IHIS.Framework.XLabel lblBojo;
		private IHIS.Framework.XTextBox txtFkinp1001;
		private IHIS.Framework.XTextBox txtPknur9001;
		private IHIS.Framework.XPanel pnlButton;
		private IHIS.Framework.XButton btnSoap;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel lblHo_dong;
		private IHIS.Framework.XBuseoCombo cboHo_dong;
		private IHIS.Framework.XPanel pnlQuery;
		private IHIS.Framework.XLabel lblQuery;
		private IHIS.Framework.XDatePicker dtpQuery;
		private IHIS.Framework.XButton btnDc;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private MultiLayout layComboSet;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayout layBojoList;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayout layWorkTime;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private XPanel pnlRight;
        private XLabel xLabel1;
        private TreeView tvwNUR4003;
        private MultiLayout layNUR4001;
        private XButton btnOutPatient;
        private XButton btnPrint;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private MultiLayout layComboNUR4001;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private XFindWorker fwkNurse;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XLabel lblNurseId;
        private XDisplayBox dbxNurseName;
        private XTextBox txtNurse;
        private XButton btnClearNurse;
        private XButton btnNUR4001;
        private XPanel pnlLeft;
        private XEditGrid grdPalist;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell66;
        private XPanel pnlSession;
        private XLabel xLabel6;
        private XCheckBox cbxA;
        private XCheckBox cbxB;
        private XCheckBox cbxC;
        private XCheckBox cbxD;
        private XButton btnNextPatient;
        private XDatePicker dtpFromDate;
        private XLabel xLabel2;
        private XDatePicker dtpToDate;
        private XPanel pnlHelp;
        private XLabel lblHlep2;
        private XLabel lblHlep3;
        private XLabel lblHlep5;
        private XLabel lblHlep1;
        private XButton btnHelp;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem48;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR9001U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            //저장 Performer 생성 Set , Grid의 SavePerformer SET
            this.grdNUR9001.SavePerformer = new XSavePerformer(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR9001U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.pnlSession = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.btnOutPatient = new IHIS.Framework.XButton();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.lblNurseId = new IHIS.Framework.XLabel();
            this.dbxNurseName = new IHIS.Framework.XDisplayBox();
            this.txtNurse = new IHIS.Framework.XTextBox();
            this.btnClearNurse = new IHIS.Framework.XButton();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.txtPknur9001 = new IHIS.Framework.XTextBox();
            this.pnlQuery = new IHIS.Framework.XPanel();
            this.dtpQuery = new IHIS.Framework.XDatePicker();
            this.lblQuery = new IHIS.Framework.XLabel();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.grdNUR9001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fwkNurse = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnlButton = new IHIS.Framework.XPanel();
            this.btnNextPatient = new IHIS.Framework.XButton();
            this.btnNUR4001 = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnDc = new IHIS.Framework.XButton();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.tvwSoap = new IHIS.Framework.XTreeView();
            this.pnlRightTop = new IHIS.Framework.XPanel();
            this.btnSoap = new IHIS.Framework.XButton();
            this.lblBojo = new IHIS.Framework.XLabel();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layBojoList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layWorkTime = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.tvwNUR4003 = new System.Windows.Forms.TreeView();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layNUR4001 = new IHIS.Framework.MultiLayout();
            this.layComboNUR4001 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdPalist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.pnlHelp = new IHIS.Framework.XPanel();
            this.lblHlep2 = new IHIS.Framework.XLabel();
            this.lblHlep3 = new IHIS.Framework.XLabel();
            this.lblHlep5 = new IHIS.Framework.XLabel();
            this.lblHlep1 = new IHIS.Framework.XLabel();
            this.btnHelp = new IHIS.Framework.XButton();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlQuery.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9001)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnlRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBojoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWorkTime)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR4001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboNUR4001)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).BeginInit();
            this.pnlHelp.SuspendLayout();
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
            this.ImageList.Images.SetKeyName(12, "앞으로.gif");
            this.ImageList.Images.SetKeyName(13, "a36xJU_x0rQlz0r1406624906_1406624929.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.dtpToDate);
            this.pnlTop.Controls.Add(this.dtpFromDate);
            this.pnlTop.Controls.Add(this.pnlSession);
            this.pnlTop.Controls.Add(this.btnOutPatient);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.lblNurseId);
            this.pnlTop.Controls.Add(this.dbxNurseName);
            this.pnlTop.Controls.Add(this.txtNurse);
            this.pnlTop.Controls.Add(this.btnClearNurse);
            this.pnlTop.Controls.Add(this.txtFkinp1001);
            this.pnlTop.Controls.Add(this.txtPknur9001);
            this.pnlTop.Controls.Add(this.pnlQuery);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlTop.Size = new System.Drawing.Size(1516, 35);
            this.pnlTop.TabIndex = 0;
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel2.Location = new System.Drawing.Point(996, 10);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(14, 16);
            this.xLabel2.TabIndex = 134;
            this.xLabel2.Text = "-";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(1015, 7);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(91, 20);
            this.dtpToDate.TabIndex = 133;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(903, 7);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(91, 20);
            this.dtpFromDate.TabIndex = 132;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // pnlSession
            // 
            this.pnlSession.Controls.Add(this.xLabel6);
            this.pnlSession.Controls.Add(this.cbxA);
            this.pnlSession.Controls.Add(this.cbxB);
            this.pnlSession.Controls.Add(this.cbxC);
            this.pnlSession.Controls.Add(this.cbxD);
            this.pnlSession.Location = new System.Drawing.Point(1, 4);
            this.pnlSession.Name = "pnlSession";
            this.pnlSession.Size = new System.Drawing.Size(218, 22);
            this.pnlSession.TabIndex = 131;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(1, 1);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(63, 21);
            this.xLabel6.TabIndex = 20;
            this.xLabel6.Text = "チーム";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxA
            // 
            this.cbxA.AutoSize = true;
            this.cbxA.Location = new System.Drawing.Point(71, 3);
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
            this.cbxB.Location = new System.Drawing.Point(107, 3);
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
            this.cbxC.Location = new System.Drawing.Point(143, 3);
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
            this.cbxD.Location = new System.Drawing.Point(180, 3);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(31, 17);
            this.cbxD.TabIndex = 17;
            this.cbxD.Text = "D";
            this.cbxD.UseVisualStyleBackColor = false;
            this.cbxD.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // btnOutPatient
            // 
            this.btnOutPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOutPatient.ImageIndex = 8;
            this.btnOutPatient.ImageList = this.ImageList;
            this.btnOutPatient.Location = new System.Drawing.Point(225, 0);
            this.btnOutPatient.Name = "btnOutPatient";
            this.btnOutPatient.Size = new System.Drawing.Size(166, 29);
            this.btnOutPatient.TabIndex = 112;
            this.btnOutPatient.Text = "入院内訳照会";
            this.btnOutPatient.Click += new System.EventHandler(this.btnOutPatient_Click);
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(397, 2);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(495, 29);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // lblNurseId
            // 
            this.lblNurseId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNurseId.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNurseId.EdgeRounding = false;
            this.lblNurseId.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNurseId.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNurseId.Location = new System.Drawing.Point(1112, 5);
            this.lblNurseId.Name = "lblNurseId";
            this.lblNurseId.Size = new System.Drawing.Size(96, 23);
            this.lblNurseId.TabIndex = 130;
            this.lblNurseId.Text = "看護 ID";
            this.lblNurseId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxNurseName
            // 
            this.dbxNurseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbxNurseName.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxNurseName.Location = new System.Drawing.Point(1325, 5);
            this.dbxNurseName.Name = "dbxNurseName";
            this.dbxNurseName.Size = new System.Drawing.Size(120, 23);
            this.dbxNurseName.TabIndex = 129;
            // 
            // txtNurse
            // 
            this.txtNurse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNurse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNurse.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNurse.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtNurse.Location = new System.Drawing.Point(1211, 5);
            this.txtNurse.Name = "txtNurse";
            this.txtNurse.Size = new System.Drawing.Size(112, 23);
            this.txtNurse.TabIndex = 128;
            this.txtNurse.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtNurse_DataValidating);
            // 
            // btnClearNurse
            // 
            this.btnClearNurse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearNurse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearNurse.Image = ((System.Drawing.Image)(resources.GetObject("btnClearNurse.Image")));
            this.btnClearNurse.Location = new System.Drawing.Point(1447, 4);
            this.btnClearNurse.Name = "btnClearNurse";
            this.btnClearNurse.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnClearNurse.Size = new System.Drawing.Size(62, 25);
            this.btnClearNurse.TabIndex = 127;
            this.btnClearNurse.Text = "クリア";
            this.btnClearNurse.Click += new System.EventHandler(this.btnClearNurse_Click);
            // 
            // txtFkinp1001
            // 
            this.txtFkinp1001.Location = new System.Drawing.Point(521, 4);
            this.txtFkinp1001.Name = "txtFkinp1001";
            this.txtFkinp1001.Size = new System.Drawing.Size(77, 20);
            this.txtFkinp1001.TabIndex = 125;
            this.txtFkinp1001.Visible = false;
            // 
            // txtPknur9001
            // 
            this.txtPknur9001.Location = new System.Drawing.Point(606, 4);
            this.txtPknur9001.Name = "txtPknur9001";
            this.txtPknur9001.Size = new System.Drawing.Size(77, 20);
            this.txtPknur9001.TabIndex = 126;
            this.txtPknur9001.Visible = false;
            // 
            // pnlQuery
            // 
            this.pnlQuery.Controls.Add(this.dtpQuery);
            this.pnlQuery.Controls.Add(this.lblQuery);
            this.pnlQuery.Location = new System.Drawing.Point(226, 2);
            this.pnlQuery.Name = "pnlQuery";
            this.pnlQuery.Size = new System.Drawing.Size(248, 29);
            this.pnlQuery.TabIndex = 1;
            // 
            // dtpQuery
            // 
            this.dtpQuery.IsJapanYearType = true;
            this.dtpQuery.Location = new System.Drawing.Point(100, 4);
            this.dtpQuery.Name = "dtpQuery";
            this.dtpQuery.Size = new System.Drawing.Size(145, 20);
            this.dtpQuery.TabIndex = 111;
            this.dtpQuery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpQuery.Visible = false;
            this.dtpQuery.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpQuery_DataValidating);
            // 
            // lblQuery
            // 
            this.lblQuery.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblQuery.EdgeRounding = false;
            this.lblQuery.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuery.Location = new System.Drawing.Point(5, 4);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(93, 20);
            this.lblQuery.TabIndex = 110;
            this.lblQuery.Text = "照会日付";
            this.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuery.Visible = false;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grdNUR9001);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(235, 35);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(872, 519);
            this.pnlCenter.TabIndex = 1;
            // 
            // grdNUR9001
            // 
            this.grdNUR9001.AddedHeaderLine = 1;
            this.grdNUR9001.ApplyAutoHeight = true;
            this.grdNUR9001.ApplyPaintEventToAllColumn = true;
            this.grdNUR9001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell11,
            this.xEditGridCell10,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell18,
            this.xEditGridCell17,
            this.xEditGridCell15});
            this.grdNUR9001.ColPerLine = 9;
            this.grdNUR9001.Cols = 10;
            this.grdNUR9001.ControlBinding = true;
            this.grdNUR9001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR9001.FixedCols = 1;
            this.grdNUR9001.FixedRows = 2;
            this.grdNUR9001.HeaderHeights.Add(41);
            this.grdNUR9001.HeaderHeights.Add(0);
            this.grdNUR9001.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdNUR9001.IsAllDataQuery = true;
            this.grdNUR9001.Location = new System.Drawing.Point(0, 0);
            this.grdNUR9001.Name = "grdNUR9001";
            this.grdNUR9001.QuerySQL = resources.GetString("grdNUR9001.QuerySQL");
            this.grdNUR9001.RowHeaderVisible = true;
            this.grdNUR9001.Rows = 3;
            this.grdNUR9001.Size = new System.Drawing.Size(872, 519);
            this.grdNUR9001.TabIndex = 0;
            this.grdNUR9001.ToolTipActive = true;
            this.grdNUR9001.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR9001_ItemValueChanging);
            this.grdNUR9001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR9001_QueryEnd);
            this.grdNUR9001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR9001_QueryStarting);
            this.grdNUR9001.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdNUR9001_GridColumnProtectModify);
            this.grdNUR9001.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdNUR9001_RowFocusChanging);
            this.grdNUR9001.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR9001_GridColumnChanged);
            this.grdNUR9001.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdNUR9001_GridFindSelected);
            this.grdNUR9001.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR9001_SaveEnd);
            this.grdNUR9001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR9001_GridCellPainting);
            this.grdNUR9001.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdNUR9001_GridButtonClick);
            this.grdNUR9001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR9001_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pknur9001";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "경과기록키";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "입원키";
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 9;
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "환자번호";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell4.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell4.CellName = "record_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 63;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.HeaderText = "記録日付";
            this.xEditGridCell4.IsJapanYearType = true;
            this.xEditGridCell4.Row = 1;
            this.xEditGridCell4.SuppressRepeating = true;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell5.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell5.CellName = "record_time";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell5.CellWidth = 42;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.HeaderText = "記録時間";
            this.xEditGridCell5.Mask = "HH:MI";
            this.xEditGridCell5.Row = 1;
            this.xEditGridCell5.SuppressRepeating = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell6.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell6.CellLen = 1;
            this.xEditGridCell6.CellName = "soap_gubun";
            this.xEditGridCell6.CellWidth = 33;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "区分";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell7.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell7.CellLen = 4000;
            this.xEditGridCell7.CellName = "record_contents";
            this.xEditGridCell7.CellWidth = 21;
            this.xEditGridCell7.Col = 7;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "入\r\n力";
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 2;
            this.xEditGridCell8.CellName = "nur_plan_jin";
            this.xEditGridCell8.CellWidth = 40;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "診断名";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell9.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell9.CellLen = 8;
            this.xEditGridCell9.CellName = "record_user";
            this.xEditGridCell9.CellWidth = 60;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.FindWorker = this.fwkNurse;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "記録者";
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkNurse
            // 
            this.fwkNurse.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkNurse.FormText = "看護師";
            this.fwkNurse.InputSQL = resources.GetString("fwkNurse.InputSQL");
            this.fwkNurse.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkNurse_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "sabun";
            this.findColumnInfo3.ColWidth = 100;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "職員No.";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "sabun_name";
            this.findColumnInfo4.ColWidth = 193;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "職員名";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell11.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell11.CellLen = 30;
            this.xEditGridCell11.CellName = "record_user_name";
            this.xEditGridCell11.CellWidth = 92;
            this.xEditGridCell11.Col = 9;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "記録者名";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 1;
            this.xEditGridCell10.CellName = "vald";
            this.xEditGridCell10.CellWidth = 30;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "取消";
            this.xEditGridCell10.InitValue = "Y";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "dc_yn";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "dc_yn";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "dc_user";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "dc_user";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell14.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell14.CellName = "mayak_use_yn";
            this.xEditGridCell14.CellWidth = 25;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "麻\r\n薬";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "record_contents_dis";
            this.xEditGridCell16.CellWidth = 279;
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "内容";
            this.xEditGridCell16.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "fknur4001";
            this.xEditGridCell18.CellWidth = 211;
            this.xEditGridCell18.Col = 4;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.HeaderText = "看護診断";
            this.xEditGridCell18.RowSpan = 2;
            this.xEditGridCell18.SuppressRepeating = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "over24";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.ButtonScheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.xEditGridCell15.ButtonText = "DC";
            this.xEditGridCell15.CellName = "dc_button";
            this.xEditGridCell15.CellWidth = 28;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "DC";
            this.xEditGridCell15.ImageList = this.ImageList;
            this.xEditGridCell15.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 2;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "記録日付";
            this.xGridHeader1.HeaderWidth = 63;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 8;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "記録者";
            this.xGridHeader2.HeaderWidth = 60;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnNextPatient);
            this.pnlButton.Controls.Add(this.btnNUR4001);
            this.pnlButton.Controls.Add(this.btnPrint);
            this.pnlButton.Controls.Add(this.btnList);
            this.pnlButton.Controls.Add(this.btnDc);
            this.pnlButton.Controls.Add(this.pnlFill);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 554);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1516, 36);
            this.pnlButton.TabIndex = 127;
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.ImageIndex = 12;
            this.btnNextPatient.ImageList = this.ImageList;
            this.btnNextPatient.Location = new System.Drawing.Point(972, 3);
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Size = new System.Drawing.Size(124, 30);
            this.btnNextPatient.TabIndex = 41;
            this.btnNextPatient.Text = "次の患者さんへ";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // btnNUR4001
            // 
            this.btnNUR4001.Location = new System.Drawing.Point(152, 3);
            this.btnNUR4001.Name = "btnNUR4001";
            this.btnNUR4001.Size = new System.Drawing.Size(102, 29);
            this.btnNUR4001.TabIndex = 4;
            this.btnNUR4001.Text = "看護計画";
            this.btnNUR4001.Click += new System.EventHandler(this.btnNUR4001_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.ImageIndex = 11;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Location = new System.Drawing.Point(4, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(142, 29);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "看護経過記録出力";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(1107, 1);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(406, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // btnDc
            // 
            this.btnDc.Image = ((System.Drawing.Image)(resources.GetObject("btnDc.Image")));
            this.btnDc.Location = new System.Drawing.Point(260, 3);
            this.btnDc.Name = "btnDc";
            this.btnDc.Size = new System.Drawing.Size(82, 29);
            this.btnDc.TabIndex = 1;
            this.btnDc.Text = "DC設定";
            this.btnDc.Visible = false;
            this.btnDc.Click += new System.EventHandler(this.btnDc_Click);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.tvwSoap);
            this.pnlFill.Controls.Add(this.pnlRightTop);
            this.pnlFill.Location = new System.Drawing.Point(505, 29);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(250, 555);
            this.pnlFill.TabIndex = 3;
            this.pnlFill.Visible = false;
            // 
            // tvwSoap
            // 
            this.tvwSoap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwSoap.FullRowSelect = true;
            this.tvwSoap.Location = new System.Drawing.Point(0, 55);
            this.tvwSoap.Name = "tvwSoap";
            this.tvwSoap.Size = new System.Drawing.Size(250, 500);
            this.tvwSoap.TabIndex = 1;
            // 
            // pnlRightTop
            // 
            this.pnlRightTop.Controls.Add(this.btnSoap);
            this.pnlRightTop.Controls.Add(this.lblBojo);
            this.pnlRightTop.Controls.Add(this.cboHo_dong);
            this.pnlRightTop.Controls.Add(this.lblHo_dong);
            this.pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRightTop.Location = new System.Drawing.Point(0, 0);
            this.pnlRightTop.Name = "pnlRightTop";
            this.pnlRightTop.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.pnlRightTop.Size = new System.Drawing.Size(250, 55);
            this.pnlRightTop.TabIndex = 0;
            // 
            // btnSoap
            // 
            this.btnSoap.Image = ((System.Drawing.Image)(resources.GetObject("btnSoap.Image")));
            this.btnSoap.Location = new System.Drawing.Point(152, 29);
            this.btnSoap.Name = "btnSoap";
            this.btnSoap.Size = new System.Drawing.Size(96, 23);
            this.btnSoap.TabIndex = 1;
            this.btnSoap.Text = "SOAP登録";
            this.btnSoap.Click += new System.EventHandler(this.btnSoap_Click);
            // 
            // lblBojo
            // 
            this.lblBojo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBojo.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBojo.Image = ((System.Drawing.Image)(resources.GetObject("lblBojo.Image")));
            this.lblBojo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBojo.Location = new System.Drawing.Point(0, 25);
            this.lblBojo.Name = "lblBojo";
            this.lblBojo.Size = new System.Drawing.Size(250, 30);
            this.lblBojo.TabIndex = 0;
            this.lblBojo.Text = "補助機能";
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Location = new System.Drawing.Point(98, 3);
            this.cboHo_dong.MaxDropDownItems = 40;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(145, 21);
            this.cboHo_dong.TabIndex = 129;
            this.cboHo_dong.SelectionChangeCommitted += new System.EventHandler(this.cboHo_dong_SelectionChangeCommitted);
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.Location = new System.Drawing.Point(3, 3);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(93, 20);
            this.lblHo_dong.TabIndex = 128;
            this.lblHo_dong.Text = "病棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkFind
            // 
            this.fwkFind.InputSQL = resources.GetString("fwkFind.InputSQL");
            this.fwkFind.IsSetControlText = true;
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkFind.ServerFilter = true;
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboSet.QuerySQL = "SELECT CODE                   CODE,\r\n       CODE||\' : \'||CODE_NAME CODE_NAME\r\n  F" +
                "ROM NUR0102\r\n WHERE HOSP_CODE = :f_hosp_code \r\n   AND CODE_TYPE = \'SOAP\'\r\n ORDER" +
                " BY SORT_KEY";
            this.layComboSet.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layComboSet_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // layBojoList
            // 
            this.layBojoList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layBojoList.QuerySQL = resources.GetString("layBojoList.QuerySQL");
            this.layBojoList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layBojoList_QueryStarting);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "soap_bun1";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "soap_bun1_name";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "soap_bun2";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "soap_bun2_name";
            // 
            // layWorkTime
            // 
            this.layWorkTime.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layWorkTime.QuerySQL = "SELECT CODE         WORK_TIME_GUUBUN\r\n     , CODE_NAME    WORK_TIME\r\n  FROM NUR01" +
                "02 \r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = \'WORK_TIME\'";
            this.layWorkTime.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layWorkTime_QueryStarting);
            this.layWorkTime.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layWorkTime_QueryEnd);
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "time_gubun";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "time";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnHelp);
            this.pnlRight.Controls.Add(this.pnlHelp);
            this.pnlRight.Controls.Add(this.tvwNUR4003);
            this.pnlRight.Controls.Add(this.xLabel1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1107, 35);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(409, 519);
            this.pnlRight.TabIndex = 4;
            // 
            // tvwNUR4003
            // 
            this.tvwNUR4003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNUR4003.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.tvwNUR4003.ImageIndex = 10;
            this.tvwNUR4003.ImageList = this.ImageList;
            this.tvwNUR4003.Location = new System.Drawing.Point(0, 55);
            this.tvwNUR4003.Name = "tvwNUR4003";
            this.tvwNUR4003.SelectedImageIndex = 10;
            this.tvwNUR4003.Size = new System.Drawing.Size(409, 464);
            this.tvwNUR4003.TabIndex = 1;
            this.tvwNUR4003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwNUR4003_MouseDown);
            this.tvwNUR4003.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwNUR4003_KeyDown);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.xLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xLabel1.Image")));
            this.xLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel1.ImageIndex = 5;
            this.xLabel1.ImageList = this.ImageList;
            this.xLabel1.Location = new System.Drawing.Point(0, 0);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(410, 55);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = " 看 護 計 画";
            // 
            // layNUR4001
            // 
            this.layNUR4001.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem48});
            this.layNUR4001.QuerySQL = resources.GetString("layNUR4001.QuerySQL");
            this.layNUR4001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR4001_QueryStarting);
            this.layNUR4001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layNUR4001_QueryEnd);
            // 
            // layComboNUR4001
            // 
            this.layComboNUR4001.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            this.layComboNUR4001.QuerySQL = resources.GetString("layComboNUR4001.QuerySQL");
            this.layComboNUR4001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layComboNUR4001_QueryStarting);
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "code";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "code_name";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdPalist);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 35);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(235, 519);
            this.pnlLeft.TabIndex = 128;
            // 
            // grdPalist
            // 
            this.grdPalist.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell41,
            this.xEditGridCell66});
            this.grdPalist.ColPerLine = 6;
            this.grdPalist.Cols = 6;
            this.grdPalist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPalist.FixedRows = 1;
            this.grdPalist.HeaderHeights.Add(23);
            this.grdPalist.Location = new System.Drawing.Point(0, 0);
            this.grdPalist.Name = "grdPalist";
            this.grdPalist.QuerySQL = resources.GetString("grdPalist.QuerySQL");
            this.grdPalist.ReadOnly = true;
            this.grdPalist.Rows = 2;
            this.grdPalist.Size = new System.Drawing.Size(235, 519);
            this.grdPalist.TabIndex = 0;
            this.grdPalist.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPalist_QueryEnd);
            this.grdPalist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdPalist_MouseClick);
            this.grdPalist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPalist_QueryStarting);
            this.grdPalist.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPalist_RowFocusChanged);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.ApplyPaintingEvent = true;
            this.xEditGridCell19.CellLen = 4;
            this.xEditGridCell19.CellName = "ho_code";
            this.xEditGridCell19.CellWidth = 40;
            this.xEditGridCell19.HeaderText = "病室";
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellLen = 9;
            this.xEditGridCell20.CellName = "bunho";
            this.xEditGridCell20.CellWidth = 75;
            this.xEditGridCell20.Col = 1;
            this.xEditGridCell20.HeaderText = "患者番号";
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellLen = 30;
            this.xEditGridCell21.CellName = "su_name";
            this.xEditGridCell21.CellWidth = 100;
            this.xEditGridCell21.Col = 2;
            this.xEditGridCell21.HeaderText = "患者氏名";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "pkinp1001";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 20;
            this.xEditGridCell23.CellName = "age_sex";
            this.xEditGridCell23.CellWidth = 40;
            this.xEditGridCell23.Col = 3;
            this.xEditGridCell23.HeaderText = "年/性";
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "ipwon_date";
            this.xEditGridCell24.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell24.CellWidth = 90;
            this.xEditGridCell24.Col = 4;
            this.xEditGridCell24.HeaderText = "入院日付";
            this.xEditGridCell24.IsJapanYearType = true;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 30;
            this.xEditGridCell41.CellName = "doctor_name";
            this.xEditGridCell41.CellWidth = 100;
            this.xEditGridCell41.Col = 5;
            this.xEditGridCell41.HeaderText = "主治医";
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "cycle_order_group";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // pnlHelp
            // 
            this.pnlHelp.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.pnlHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHelp.Controls.Add(this.lblHlep2);
            this.pnlHelp.Controls.Add(this.lblHlep3);
            this.pnlHelp.Controls.Add(this.lblHlep5);
            this.pnlHelp.Controls.Add(this.lblHlep1);
            this.pnlHelp.Location = new System.Drawing.Point(327, 42);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(81, 138);
            this.pnlHelp.TabIndex = 15;
            this.pnlHelp.Visible = false;
            // 
            // lblHlep2
            // 
            this.lblHlep2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.SkyBlue);
            this.lblHlep2.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep2.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
            this.lblHlep2.Location = new System.Drawing.Point(4, 38);
            this.lblHlep2.Margin = new System.Windows.Forms.Padding(0);
            this.lblHlep2.Name = "lblHlep2";
            this.lblHlep2.Size = new System.Drawing.Size(71, 29);
            this.lblHlep2.TabIndex = 8;
            this.lblHlep2.Text = "本日評価";
            this.lblHlep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHlep3
            // 
            this.lblHlep3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.GreenYellow);
            this.lblHlep3.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep3.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Green);
            this.lblHlep3.Location = new System.Drawing.Point(4, 104);
            this.lblHlep3.Name = "lblHlep3";
            this.lblHlep3.Size = new System.Drawing.Size(71, 29);
            this.lblHlep3.TabIndex = 5;
            this.lblHlep3.Text = "計画終了";
            this.lblHlep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHlep5
            // 
            this.lblHlep5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Pink);
            this.lblHlep5.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep5.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Red);
            this.lblHlep5.Location = new System.Drawing.Point(4, 71);
            this.lblHlep5.Name = "lblHlep5";
            this.lblHlep5.Size = new System.Drawing.Size(71, 29);
            this.lblHlep5.TabIndex = 6;
            this.lblHlep5.Text = "評価日過ぎ";
            this.lblHlep5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHlep1
            // 
            this.lblHlep1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.White);
            this.lblHlep1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.lblHlep1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHlep1.Location = new System.Drawing.Point(4, 5);
            this.lblHlep1.Name = "lblHlep1";
            this.lblHlep1.Size = new System.Drawing.Size(71, 29);
            this.lblHlep1.TabIndex = 4;
            this.lblHlep1.Text = "通常";
            this.lblHlep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageIndex = 13;
            this.btnHelp.ImageList = this.ImageList;
            this.btnHelp.Location = new System.Drawing.Point(330, 17);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "ヘルプ";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "pknur4001";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "bunho";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "fkinp1001";
            this.multiLayoutItem25.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "nur_plan_jin";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "nur_plan_jin_name";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "purpose";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "plan_user";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "plan_date";
            this.multiLayoutItem30.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "pknur4003";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "nur_plan";
            this.multiLayoutItem32.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "nur_plan_ote";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "nur_dis_plan_name";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "pknur4004";
            this.multiLayoutItem40.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "nur_plan_detail";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "nur_plan_dename";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "plan_user_name";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "nur_plan_name";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "nur4001_vald";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "valu_date";
            // 
            // NUR9001U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlButton);
            this.Name = "NUR9001U00";
            this.Size = new System.Drawing.Size(1516, 590);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR9001U00_Closing);
            this.UserChanged += new System.EventHandler(this.NUR9001U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR9001U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlQuery.ResumeLayout(false);
            this.pnlQuery.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR9001)).EndInit();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBojoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWorkTime)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNUR4001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboNUR4001)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).EndInit();
            this.pnlHelp.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>txtFkinp1001
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
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + "\n" +" 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。" + "\n" + "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "record_date":
					msg = (NetInfo.Language == LangMode.Ko ? "기록일자를 입력해 주세요."
						: "記録日付を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "record_time":
					msg = (NetInfo.Language == LangMode.Ko ? "기록시간을 입력해 주세요."
						: "記録時間を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "soap_gubun":
					msg = (NetInfo.Language == LangMode.Ko ? "SOAP구분을 선택해 주세요."
						: "SOAP区分を選択してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "record_contents":
					msg = (NetInfo.Language == LangMode.Ko ? "SOAP구분을 입력해 주세요."
						: "内容を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nur_plan_":
					msg = (NetInfo.Language == LangMode.Ko ? "진단명을 입력해 주세요."
						: "診断名を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "record_user":
					msg = (NetInfo.Language == LangMode.Ko ? "기록자를 입력해 주세요."
						: "記録者を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "length":
					msg = (NetInfo.Language == LangMode.Ko ? "입력할 수 있는 글자수를 초과 하였습니다."
                        : "入力可能な文字数を超えました。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
                    //msg += "\r\n[" + this.dsvUpdate.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "에러" 
						: "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion


		// <summary>
		/// 중환자실환자대장등록 콤보박스 셋팅
		/// </summary>
		/// <param name="aComboGubun">
		/// 콤보구분
		/// </param>
		#region 콤보박스 셋팅
		private void SetComboSetting(string gubun)
		{

            switch (gubun)
            {
                case "soap":
                    if (layComboSet.QueryLayout(true))
                    {
                        if (this.layComboSet.LayoutTable.Rows.Count > 0)
                        {
                            //그리드에 소프 콤보박스 세팅 변경 2011.12.24 Merry Christmas -woo
                            this.grdNUR9001.SetComboItems("soap_gubun", this.layComboSet.LayoutTable, "code", "code");
                        }

                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                    break;


                case "nur4001":
                    if (this.layComboNUR4001.QueryLayout(true))
                    {
                        if (this.layComboNUR4001.LayoutTable.Rows.Count > 0)
                        {
                            this.grdNUR9001.SetComboItems("fknur4001", this.layComboNUR4001.LayoutTable, "code_name", "code");
                        }
                    }

                    break;




            }
           
		}
		#endregion

		/// <summary>
		/// 화면왼쪽의 구분을 선택을 하면 그에 해당하는
		/// SOAP대분류, 소분류 리스트가 조회된다.
		/// </summary>
		#region 보조기능에 있는 리스트를 조회한다.
		private void SetTvwBojoList()
		{
			this.tvwSoap.Nodes.Clear();
            //this.tvwSoap.ImageList = this.ImageList;

            if(layBojoList.QueryLayout(true))
            {
                if(this.layBojoList.RowCount > 0)
                {
                    string soapbun1 = string.Empty;
				
                    TreeNode atn = null;
				
                    foreach(DataRow dr in this.layBojoList.LayoutTable.Rows)
                    {
                        if (dr["soap_bun1"].ToString() != soapbun1)
                        {
                            TreeNode tn = new TreeNode(dr["soap_bun1_name"].ToString(),0,0);
                            
                            //tn.ImageIndex = 0;
                            //tn.SelectedImageIndex = 0;

                            this.tvwSoap.Nodes.Add(tn);
                            atn = tn;

                            if (dr["soap_bun2_name"].ToString().Trim() != "")
                            {
                                TreeNode ctn = new TreeNode(dr["soap_bun2_name"].ToString(), 1, 4);
                                //ctn.ImageIndex = -1;
                                //ctn.SelectedImageIndex = -1;
                                tn.Nodes.Add(ctn);
                                ctn.Tag = dr["soap_bun2_name"].ToString();
                            }
                        }
                        else
                        {
                            if (dr["soap_bun2_name"].ToString().Trim() != "")
                            {
                                TreeNode ctn = new TreeNode(dr["soap_bun2_name"].ToString(), 1, 4);
                                //ctn.ImageIndex = -1;
                                //ctn.SelectedImageIndex = -1;
                                atn.Nodes.Add(ctn);
                                ctn.Tag = dr["soap_bun2_name"].ToString();
                            }
                        }
				
                        soapbun1 = dr["soap_bun1"].ToString();
                        atn.ExpandAll();
                    }
                    this.tvwSoap.SelectedNode = this.tvwSoap.Nodes[0];
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
		}
		#endregion

		/// <summary>
		/// 화면을 클리어 한다.
		/// </summary>
		/// <param name="aScreenYn">
		/// 화면 잠금여부
		/// </param>
		#region 화면 클리어
		private void ResetControl()
		{
            this.grdNUR9001.Reset();
            this.tvwSoap.Nodes.Clear();
            this.lblBojo.Text = "補助機能";
            this.txtFkinp1001.ResetData();
            this.txtPknur9001.ResetData();
		}
		#endregion

		/// <summary>
		/// 환자의 재원여부를 조회한다.
		/// </summary>
		#region 재원여부 조회
		private void Fkinp1001(string q_date)
		{
            string sqlCmd = @"SELECT A.PKINP1001
                                FROM INP1001 A
                               WHERE A.HOSP_CODE            = :f_hosp_code
                                 AND A.BUNHO                = :f_bunho
                                 AND NVL(:f_todate, TRUNC(SYSDATE)) BETWEEN A.IPWON_DATE AND NVL(A.TOIWON_DATE, '9998/12/31')
                                 AND NVL(A.CANCEL_YN,'N')   = 'N'
                                 AND NVL(A.JAEWON_FLAG,'N') = 'Y'";


            BindVarCollection bindvar = new BindVarCollection();

            bindvar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindvar.Add("f_bunho", paBox.BunHo);
            bindvar.Add("f_todate", q_date);
            object pkInp1001 = Service.ExecuteScalar(sqlCmd, bindvar);
			/* 환자의 입원이력을 조회한다. */
            if (!TypeCheck.IsNull(pkInp1001))
            {
                jaewon = true;  //재원환자이면 true
                this.btnList.Enabled = true;    //버튼리스트를 사용할 수 있게 해 준다.
                this.btnNextPatient.Enabled = true;
                
                // 조회기간 기본 설정 (오늘 -6일)
                this.dtpFromDate.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
                this.dtpToDate.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
                               
                dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
                dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(-6));

                this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
                this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);

                this.txtFkinp1001.SetDataValue(pkInp1001.ToString());
            }
            else //재원환자가 아니면
            {
                jaewon = false; //재원환자가 아니면 false
                this.btnList.Enabled = false;   //버튼리스트를 사용 못하게 한다.2011.12.26 추가 woo
                this.btnNextPatient.Enabled = false;

                /* 재원중인 환자가 아니므로 메세지를 보여준다. */
                this.GetMessage("jeawonYn");
            }

            SetComboSetting("nur4001");
		}
		#endregion

		/// <summary>
		/// 입력을 하기전에 경과기록키로 입력한 값이 있는지 조회를 한다.
		/// </summary>
		/// <returns></returns>
		#region 데이터체크
		private bool Nur9001dataCheck()
		{
            object pkNur9001 = Service.ExecuteScalar("SELECT 'Y' FROM NUR9001 WHERE PKNUR9001 = '" + txtPknur9001.GetDataValue() + "'");

            if (TypeCheck.IsNull(pkNur9001)) return false;
            else return true;
		}
		#endregion

		#region 팝업화면으로 오픈이 됐을 때의 이벤트
        string mHospCode = "";
		private void NUR9001U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);

            mHospCode = EnvironInfo.HospCode;


            /* 콤보박스 셋팅 */
            this.SetComboSetting("soap");

            this.layWorkTime.QueryLayout(false);

            dtpQuery.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            /* 사용자의 병동을 디폴트로 셋팅 */
            if (UserInfo.HoDong.ToString() == "")
                this.cboHo_dong.SetEditValue("1");
            else
                this.cboHo_dong.SetEditValue(UserInfo.HoDong.ToString());



            //조회 기간 설정
            this.dtpFromDate.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            this.dtpToDate.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);

            // 조회기간 기본 설정 (오늘 -6일)
            dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
            dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().AddDays(-6));

            if (OpenParam != null)
            {
                this.sysid = OpenParam["sysid"].ToString();
                this.screen = OpenParam["screen"].ToString();                

                if (OpenParam.Contains("fkinp1001"))
                {
                    this.txtFkinp1001.SetDataValue(OpenParam["fkinp1001"].ToString());

                    this.SetComboSetting("nur4001");
                }
                if (OpenParam.Contains("bunho"))
                {
                    this.paBox.SetPatientID(OpenParam["bunho"].ToString());
                }

                if (OpenParam.Contains("toiwon_date"))
                {
                    dtpToDate.SetDataValue(DateTime.Parse(OpenParam["toiwon_date"].ToString()));
                    dtpFromDate.SetDataValue(DateTime.Parse(OpenParam["toiwon_date"].ToString()).AddDays(-6));
                }
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }

            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);

            grdPalist.QueryLayout(false);

            txtNurse.SetDataValue(UserInfo.UserID);
            txtNurse_DataValidating(txtNurse, new DataValidatingEventArgs(false, UserInfo.UserID));
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
				this.paBox.Focus();
				this.paBox.SetPatientID(info.BunHo);
                this.dtpQuery.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

				//조회
				if(this.dtpQuery.GetDataValue().ToString() != "" && this.paBox.BunHo.ToString() != "")
				{
                    if (grdNUR9001.QueryLayout(false))
                    {
                        if (this.grdNUR9001.RowCount <= 0)
                        {
                            this.dtpQuery.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            this.dtpQuery.AcceptData();
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }
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

		#region 환자번호를 입력 했을 때
		/* 정확히 입력이 됐을 때 */
		private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.grdNUR9001.Reset();

            /* 재원환자 정보 조회 */
            this.Fkinp1001(dtpToDate.GetDataValue());
            
			if(!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
                this.btnList.PerformClick(FunctionType.Query);
			}

            Set_grdPalist_Position(paBox.BunHo);
		}

		/* 틀리게 입력이 됐을 때 */
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
            this.btnList.Enabled = false; //2011.12.26 추가 woo
			/* 화면 클리어 */
			this.ResetControl();
		}
		#endregion

        //#region 트리뷰에서의 더블클릭
        //private void tvwSoap_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    if (tvwSoap.Nodes.Count <= 0 ) return;
            
        //    if (this.grdNUR9001.ReadOnly == true) return;

        //    string record_user = TypeCheck.NVL(this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "record_user"), UserInfo.UserID.ToString()).ToString();
        //    string current_user = UserInfo.UserID.ToString();

        //    if ((!jaewon) || this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "over24") == "Y" || (!record_user.Equals(current_user)))
        //    {
        //        return;
        //    }
			
        //    if(e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        if (TypeCheck.IsNull(tvwSoap.SelectedNode)) return;

        //        if (TypeCheck.IsNull(tvwSoap.SelectedNode.Tag)) return;

        //        tag = tvwSoap.SelectedNode.Tag.ToString();

        //        //제일상위폴더 선택시 리턴
        //        if (tag.ToString() == "") return;


        //        string temp = this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "record_contents");
        //        if(temp == "")
        //        {
        //            //2011.12.26 woo
        //            this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "record_contents", tag);

        //            this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "record_contents_dis", tag);
        //        }
        //        else
        //        {
        //            //2011.12.26 woo
        //            this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "record_contents", temp + "\r\n" + tag);

        //            this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "record_contents_dis", temp + "\r\n" + tag);
        //        }
        //        this.grdNUR9001.AcceptData();
        //    }
        //}

        //#endregion

        private bool Validation()
        {
            for (int i = 0; i < grdNUR9001.RowCount; i++)
            {
                if (grdNUR9001.GetRowState(i) == DataRowState.Added ||
                   grdNUR9001.GetRowState(i) == DataRowState.Modified)
                {
                    if (grdNUR9001.GetItemString(i, "record_date") == "")
                    {
                        GetMessage("record_date");
                        grdNUR9001.SetFocusToItem(i, "record_date");
                        return false;
                    }

                    if (grdNUR9001.GetItemString(i, "record_time") == "")
                    {
                        GetMessage("record_time");
                        grdNUR9001.SetFocusToItem(i, "record_time");
                        return false;
                    }

                    if (grdNUR9001.GetItemString(i, "soap_gubun") == "")
                    {
                        GetMessage("soap_gubun");
                        grdNUR9001.SetFocusToItem(i, "soap_gubun");
                        return false;
                    }

                    if (grdNUR9001.GetItemString(i, "record_contents") == "")
                    {
                        GetMessage("record_contents");
                        grdNUR9001.SetFocusToItem(i, "record_contents");
                        return false;
                    }

                    if (grdNUR9001.GetItemString(i, "record_user") == "")
                    {
                        GetMessage("record_user");
                        grdNUR9001.SetFocusToItem(i, "record_user");
                        return false;
                    }
                }
            }
            return true;
        }

        #region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }

                    //프레임웍에서 제공하는 디폴트 조회를 차단
                    e.IsBaseCall = false;

                    ///* 재원화자 정보 조회 */
                    //this.Fkinp1001();


                    if (DateTime.Parse(dtpFromDate.GetDataValue()) > DateTime.Parse(dtpToDate.GetDataValue()))
                    {
                        XMessageBox.Show("指定した日付をもう一度確認してください。");
                        dtpFromDate.Focus();

                        return;
                    }

                    if (this.dtpQuery.GetDataValue().ToString() != "" && this.paBox.BunHo.ToString() != "")
                    {
                        //조회한 데이터가 없을 때 바인딩에 의해 화면이 초기화 되는 것을 막기 위해
                        //바인딩을 푼다.
                        //this.grdNUR9001.ControlBinding = false;

                        if (!grdNUR9001.QueryLayout(false))
                        {
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }
                    }


                    this.layNUR4001.QueryLayout(true);
                    break;

                case FunctionType.Insert:

                    //프레임웍에서 제공하는 디폴트 입력을 차단
                    e.IsBaseCall = false;

                    if (!this.AcceptData())
                    {
                        e.IsSuccess = false;
                        return;
                    }

                    if (txtNurse.Text == "")
                    {
                        XMessageBox.Show("作成IDを入力してください");
                        e.IsSuccess = false;
                        txtNurse.Focus();

                        return;
                    }

                    this.grdNUR9001.AcceptData();

                    if (!Validation())
                    {
                        return;
                    }


                    //완전히 입력되지 않는 로우 체크 있으면 새로운 행 발생 방지


                    //foreach (DataRow dr in this.grdNUR9001.LayoutTable.Rows)
                    //{
                    //    if (dr.RowState == System.Data.DataRowState.Added)
                    //    {
                    //        if (dr["record_date"].ToString() == "")
                    //        {
                    //            GetMessage("record_date");
                    //            grdNUR9001.SetFocusToItem(grdNUR9001.CurrentRowNumber, "record_date");
                    //            return;
                    //        }

                    //        if (dr["record_time"].ToString() == "")
                    //        {
                    //            GetMessage("record_time");
                    //            grdNUR9001.SetFocusToItem(grdNUR9001.CurrentRowNumber, "record_time");
                    //            return;
                    //        }

                    //        if (dr["soap_gubun"].ToString() == "")
                    //        {
                    //            GetMessage("soap_gubun");
                    //            grdNUR9001.SetFocusToItem(grdNUR9001.CurrentRowNumber, "soap_gubun");
                    //            return;
                    //        }

                    //        if (dr["record_contents"].ToString() == "")
                    //        {
                    //            GetMessage("record_contents");
                    //            grdNUR9001.SetFocusToItem(grdNUR9001.CurrentRowNumber, "record_contents");
                    //            return;
                    //        }

                    //        if (dr["record_user"].ToString() == "")
                    //        {
                    //            GetMessage("record_user");
                    //            grdNUR9001.SetFocusToItem(grdNUR9001.CurrentRowNumber, "record_user");
                    //            return;
                    //        }
                    //    }
                    //}
                    /* dsvPKNUR9001Query service 변환 2010.05. 河中 */
                    //object pkNur9001 = Service.ExecuteScalar("SELECT NUR9001_SEQ.NEXTVAL FROM DUAL");

                    //빈Row를 생성(제일 마지막에 Row로 생성)
                    int rowNum = this.grdNUR9001.InsertRow(-1);

                    //if (!TypeCheck.IsNull(pkNur9001))
                    //{
                    //txtPknur9001.SetDataValue(pkNur9001.ToString());

                    this.grdNUR9001.SetItemValue(rowNum, "fkinp1001", this.txtFkinp1001.GetDataValue().ToString());
                    //this.grdNUR9001.SetItemValue(rowNum, "pknur9001", this.txtPknur9001.GetDataValue().ToString());
                    this.grdNUR9001.SetItemValue(rowNum, "bunho", this.paBox.BunHo.ToString());
                    this.grdNUR9001.SetItemValue(rowNum, "record_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    this.grdNUR9001.SetItemValue(rowNum, "record_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    //this.grdNUR9001.SetItemValue(rowNum, "record_user", UserInfo.UserID.ToString());
                    //this.grdNUR9001.SetItemValue(rowNum, "record_user_name", UserInfo.UserName.ToString());
                    this.grdNUR9001.SetItemValue(rowNum, "record_user", txtNurse.Text);
                    this.grdNUR9001.SetItemValue(rowNum, "record_user_name", dbxNurseName.GetDataValue());

                    string soap_gubun = "S";

                    if (rowNum > 0)
                    {
                        switch (this.grdNUR9001.GetItemString(rowNum - 1, "soap_gubun"))
                        {
                            case "S":
                                soap_gubun = "O";
                                break;

                            case "O":
                                soap_gubun = "A";
                                break;

                            case "A":
                                soap_gubun = "P";
                                break;

                            case "P":
                                soap_gubun = "S";
                                break;
                        }
                    }
                    this.grdNUR9001.SetItemValue(rowNum, "soap_gubun", soap_gubun);

                    this.grdNUR9001.AcceptData();
                    layBojoList.SetBindVarValue("f_soap_gubun", this.grdNUR9001.GetItemValue(this.grdNUR9001.CurrentRowNumber, "soap_gubun").ToString());
                    this.SetTvwBojoList();
                    //}
                    //else
                    //{
                    //    XMessageBox.Show(Service.ErrFullMsg);
                    //    return;
                    //}
                    break;

                case FunctionType.Delete:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }
                    if (this.grdNUR9001.RowCount <= 0)
                        return;
                    if (this.grdNUR9001.CurrentRowNumber < 0)
                        return;

                    if (this.grdNUR9001.GetRowState(this.grdNUR9001.CurrentRowNumber) != DataRowState.Added)
                    {
                        string dataDate = EnvironInfo.GetSysDate().ToString("yyyyMMdd");
                        if (this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "record_date") != "")
                        {
                            dataDate = this.grdNUR9001.GetItemDateTime(this.grdNUR9001.CurrentRowNumber, "record_date").ToString("yyyyMMdd");
                        }
                        string checkDate = EnvironInfo.GetSysDate().AddDays(-1).ToString("yyyyMMdd");
                        string dataUser = this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "record_user");
                        //string checkUser = UserInfo.UserID;
                        string checkUser = txtNurse.Text;

                        if (int.Parse(dataDate) < int.Parse(checkDate)) 
                        {
                            XMessageBox.Show("修正可能期間が過ぎました。DCで削除してください。");
                            e.IsBaseCall = false;
                        }

                        if (!dataUser.Equals(checkUser))
                        {
                            XMessageBox.Show("作成者以外は削除できません。");
                            e.IsBaseCall = false;
                        }
                    }
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = false;
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    ////soap 선택이 되었나 안되었나 체크체크~ 2011.12.27
                    //for (int i = 0; i < this.grdNUR9001.RowCount; i++)
                    //{
                    //    if (this.grdNUR9001.GetItemString(i, "soap_gubun") == "")
                    //    {
                    //        this.GetMessage("soap_gubun");
                    //        this.grdNUR9001.SetFocusToItem(i, "soap_gubun");
                    //        return;
                    //    }

                    //    if (this.grdNUR9001.GetItemString(i, "record_user") == "")
                    //    {
                    //        this.GetMessage("record_user");
                    //        this.grdNUR9001.SetFocusToItem(i, "record_user");
                    //        return;
                    //    }

                    //}



                    if (!Validation())
                    {
                        return;
                    }

                    //내용이 길 때 경고창 띄워주고 리턴~
                    if (this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "record_contents").Length > 4000)
                    {
                        this.GetMessage("length");
                        this.grdNUR9001.SetFocusToItem(this.grdNUR9001.CurrentRowNumber, "record_contents");
                        return;
                    }

                    if (this.grdNUR9001.SaveLayout())
                    {
                        grdNUR9001.QueryLayout(false);
                        e.IsSuccess = true;

                        //this.GetMessage("save_true");
                    }
                    else
                    {
                        this.GetMessage("save_false");
                    }
                    break;
                
                default:
                    break;
            }
		}
		#endregion

		#region 화면이 닫히는 동안에 발생한다.
		private void NUR9001U00_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			IHIS.Framework.IXScreen aScreen;
			aScreen = (IXScreen)Opener;

			if (aScreen == null)
			{              
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add( "FLAG", "Y");
				
				XScreen.OpenScreenWithParam(this, sysid, screen, IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter,  openParams);

			}
			else
			{
				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add("FLAG", "Y");
				//this.Close();
				aScreen.Command("FLAG", openParams);
			}
		}
		#endregion

		#region soap등록
		private void btnSoap_Click(object sender, System.EventArgs e)
		{
			CommonItemCollection cic = new CommonItemCollection();
            
            cic.Add("soap_gubun", this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "soap_gubun"));
            cic.Add("ho_dong", this.cboHo_dong.GetDataValue());

			IHIS.Framework.XScreen.OpenScreenWithParam(this,"NURI","NUR0901U00", ScreenOpenStyle.ResponseFixed, cic);
		}
		#endregion

		#region 포커스시 입력된 로우가 없으면, 강제로 로우 생성처리
		private void txtRecord_contents_Enter(object sender, System.EventArgs e)
		{
		}
		#endregion

		#region 병동선택 시 (2011.11.25 woo)
        private void cboHo_dong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cboHo_dong.GetDataValue().ToString() != "")
            {
                if (this.grdNUR9001.GetItemString(this.grdNUR9001.CurrentRowNumber, "soap_gubun") != "")
                {
                    this.SetTvwBojoList();
                }
            }
        }

		#endregion

		#region 사용자 변경이 있을 때
		private void NUR9001U00_UserChanged(object sender, System.EventArgs e)
		{
			this.cboHo_dong.SetDataValue("");
	
			/* 콤보박스 셋팅 */
			this.SetComboSetting("soap");

			if(OpenParam != null)
			{
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();

				this.paBox.SetPatientID(OpenParam["bunho"].ToString());
                this.dtpQuery.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
				
				//조회
				if(this.dtpQuery.GetDataValue().ToString() != "" && this.paBox.BunHo.ToString() != "")
				{
                    if (grdNUR9001.QueryLayout(false))
                    {
                        if(this.grdNUR9001.RowCount <= 0)
                        {
                            this.dtpQuery.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            this.dtpQuery.AcceptData();
                        }
                    }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }
				}
			}

			/* 사용자의 병동을 디폴트로 셋팅 */
			this.cboHo_dong.SetDataValue(UserInfo.HoDong.ToString());
		}
		#endregion

		#region 조회일자를 변경을 했을 때
		private void dtpQuery_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            //this.dtpRecord_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.btnList.PerformClick(FunctionType.Query);
            //this.grdNUR9001.QueryLayout(false);

		}
		#endregion

		#region DC설정
		private void btnDc_Click(object sender, System.EventArgs e)
		{
            //if(this.grdNUR9001.RowCount > 0)
            //{
            //    if(this.grdNUR9001.CurrentRowNumber >= 0)
            //    {
            //        if(this.grdNUR9001.GetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_yn").ToString() == "Y")
            //        {
            //            if(this.grdNUR9001.GetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_user").ToString().Trim() == UserInfo.UserID.ToString().Trim())
            //            {
            //                this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_yn", "N");
            //                this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_user", "");
            //                this.grdNUR9001.Refresh();
            //                return;
            //            }
            //            else
            //            {
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_yn", "Y");
            //            this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_user", UserInfo.UserID.ToString());
            //            this.grdNUR9001.Refresh();
            //            return;
            //        }
            //    }
            //}			
		}
		#endregion

		#region DC여부를 라인으로 표시
		private void grdNUR9001_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
            if (this.layWorkTime.RowCount < 1)
                return;

            //times1 = this.layWorkTime.GetItemString(0, "time"); // 일근
            //times2 = this.layWorkTime.GetItemString(1, "time"); // 준야
            //times3 = this.layWorkTime.GetItemString(2, "time"); // 심야

            string[] temp_time = null;

            //일근
            if (!TypeCheck.IsNull(times1))
            {
                temp_time = times1.Split('-');
                if (temp_time.Length == 2)
                {
                    if (int.Parse(e.DataRow["record_time"].ToString()) >= Convert.ToInt32(temp_time[0])
                        && int.Parse(e.DataRow["record_time"].ToString()) < Convert.ToInt32(temp_time[1]))
                    {
                        e.ForeColor = Color.Black;
                        if (e.DataRow["mayak_use_yn"].ToString() == "Y")
                        {
                            e.ForeColor = Color.Red;
                        }
                    }
                }
            }

            //준야
            if(!TypeCheck.IsNull(times2))
            {
                temp_time = times2.Split('-');
                if (temp_time.Length == 2)
                {
                    if (int.Parse(e.DataRow["record_time"].ToString()) >= Convert.ToInt32(temp_time[0])
                        && int.Parse(e.DataRow["record_time"].ToString()) < Convert.ToInt32(temp_time[1]))
                    {
                        e.ForeColor = Color.Blue;
                        if (e.DataRow["mayak_use_yn"].ToString() == "Y")
                        {
                            e.ForeColor = Color.Red;
                        }
                    }
                }
            }

            //심야
            if (!TypeCheck.IsNull(times3))
            {
                temp_time = times3.Split('-');
                if (temp_time.Length == 2)
                {
                    if ((int.Parse(e.DataRow["record_time"].ToString()) >= Convert.ToInt32(temp_time[0]) && int.Parse(e.DataRow["record_time"].ToString()) <= 2400)
                     || (int.Parse(e.DataRow["record_time"].ToString()) <= Convert.ToInt32(temp_time[1]) && int.Parse(e.DataRow["record_time"].ToString()) >= 0))
                    {
                        e.ForeColor = Color.Red;
                        if (e.DataRow["mayak_use_yn"].ToString() == "Y")
                        {
                            e.ForeColor = Color.Black;
                        }
                    }
                }
            }

            
			if(e.DataRow["dc_yn"].ToString() == "Y")
			{
				e.DrawMiddleLine = true;
			}
		}
		#endregion

		#region 엔터키를 누를 때 특수 문자로 변경
		private void txtRecord_contents_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				ProcessDialogKey(Keys.Enter);
			}
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			Keys keyCode = (Keys)(((int)keyData << 16) >> 16);
			Keys keyModifier = (Keys)(((int)keyData >> 16) << 16);

			CommonItemCollection openParams  = new CommonItemCollection();

			switch(keyCode)
			{
				case Keys.Enter:
					break;
				default:
					break;
			}

			return base.ProcessDialogKey (keyData);
		}
		#endregion

        #region 각 레이아웃, 그리드 바인드 변수 설정 2010.05 河中
        private void layBojoList_QueryStarting(object sender, CancelEventArgs e)
        {
            layBojoList.SetBindVarValue("f_hosp_code", this.mHospCode);
            layBojoList.SetBindVarValue("f_ho_dong", cboHo_dong.GetDataValue());
            //layBojoList.SetBindVarValue("f_soap_gubun", cboSoap_gubun.GetDataValue());
            //2011.12.24 MerryChristmas  -woo
            //layBojoList.SetBindVarValue("f_soap_gubun", this.grdNUR9001.GetItemValue(this.grdNUR9001.CurrentRowNumber, "soap_gubun").ToString());
        }

        private void grdNUR9001_QueryStarting(object sender, CancelEventArgs e)
        {
            //ControlScreen("Y"); //쿼리 시작 전에 컨트롤들을 잠군다. //2011.12.26 주석 woo
            grdNUR9001.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR9001.SetBindVarValue("f_bunho", paBox.BunHo);
            grdNUR9001.SetBindVarValue("f_fkinp1001", this.txtFkinp1001.GetDataValue());
            grdNUR9001.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            grdNUR9001.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            //grdNUR9001.SetBindVarValue("f_record_date", dtpQuery.GetDataValue());
        }

        private void layComboSet_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layComboSet.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void layWorkTime_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layWorkTime.SetBindVarValue("f_hosp_code", this.mHospCode);
        }


        #endregion

        #region layWorkTime_QueryEnd
        private void layWorkTime_QueryEnd(object sender, QueryEndEventArgs e)
        {
            for (int i = 0; i < this.layWorkTime.RowCount; i++)
            {
                if (this.layWorkTime.GetItemString(i, "time_gubun").Equals("1"))
                {
                    times1 = this.layWorkTime.GetItemString(i, "time");
                }
                else if (this.layWorkTime.GetItemString(i, "time_gubun").Equals("2"))
                {
                    times2 = this.layWorkTime.GetItemString(i, "time");
                }
                else if (this.layWorkTime.GetItemString(i, "time_gubun").Equals("3"))
                {
                    times3 = this.layWorkTime.GetItemString(i, "time");
                }
            }
        }
        #endregion

        #region grdNUR9001_ItemValueChanging Soap 구분에 따른 예문제목 변경 2011.12.24 MerryChristmas -woo
        private void grdNUR9001_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "soap_gubun")
            {
                this.grdNUR9001.AcceptData();
                if (this.cboHo_dong.GetDataValue().ToString() != "")
                {
                    if (this.grdNUR9001.GetItemValue(e.RowNumber, "soap_gubun").ToString() != "")
                    {
                        this.lblBojo.Text = Service.ExecuteScalar(string.Format(@"SELECT CODE||' : '||CODE_NAME CODE_NAME
                                                                                    FROM NUR0102
                                                                                   WHERE HOSP_CODE = fn_adm_load_hosp_code
                                                                                     AND CODE_TYPE = 'SOAP'
                                                                                     AND CODE = '{0}'
                                                                                   ORDER BY SORT_KEY", e.ChangeValue)).ToString();
                        this.layBojoList.SetBindVarValue("f_soap_gubun", e.ChangeValue.ToString());
                        this.SetTvwBojoList();
                    }
                }
            }
            if (e.ColName == "fknur4001")
            {
                BindVarCollection bindVar = new BindVarCollection();
                string strCmd = @"SELECT FN_NUR_PLAN_END_DATE(:f_hosp_code, :f_fknur4001, :f_date) FROM SYS.DUAL";

                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar.Add("f_fknur4001", e.ChangeValue.ToString());
                bindVar.Add("f_date", dtpQuery.GetDataValue());

                object retVar = Service.ExecuteScalar(strCmd, bindVar);

                if (retVar != null)
                {
                    if (DateTime.Parse(retVar.ToString()) <= DateTime.Parse(dtpQuery.GetDataValue()))
                    {
                        MessageBox.Show("既に終了されている看護計画です。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        #endregion

        #region grdNUR9001_RowFocusChanging 조건에 따른 수정 가능 여부 2011.12.26 woo
        private void grdNUR9001_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            //string writeDate = EnvironInfo.GetSysDate().ToString("yyyyMMdd");
            //if (this.grdNUR9001.GetItemString(e.NextRow, "record_date") != "")
            //{
            //    writeDate = this.grdNUR9001.GetItemDateTime(e.NextRow, "record_date").ToString("yyyyMMdd");
            //}

            //string loginDate = EnvironInfo.GetSysDate().AddDays(-1).ToString("yyyyMMdd");
            //string writeUser = TypeCheck.NVL(this.grdNUR9001.GetItemString(e.NextRow, "record_user"),
            //                                  UserInfo.UserID.ToString()).ToString();
            //string loginUser = UserInfo.UserID.ToString();
            //if ((!jaewon) || int.Parse(writeDate) < int.Parse(loginDate) || (!writeUser.Equals(loginUser)))
            //{
            //    this.grdNUR9001.ReadOnly = true;
            //}
            //else
            //{
            //    this.grdNUR9001.ReadOnly = false;
            //}
        }

        #endregion

        #region grdNUR9001_RowFocusChanged
        /// <summary>
        /// 선택한 row가 달라질 때 그 row의 soap구분에 해당하는 정형문을 조회 한다.
        /// 2011.12.26 woo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void grdNUR9001_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {

//            if (this.cboHo_dong.GetDataValue().ToString() != "")
//            {
//                string tempSoap = this.grdNUR9001.GetItemString(e.CurrentRow, "soap_gubun").ToString();
//                if (tempSoap != "")
//                {
//                    this.lblBojo.Text = Service.ExecuteScalar(string.Format(@"SELECT CODE||' : '||CODE_NAME CODE_NAME
//                                                                                    FROM NUR0102
//                                                                                   WHERE HOSP_CODE = fn_adm_load_hosp_code
//                                                                                     AND CODE_TYPE = 'SOAP'
//                                                                                     AND CODE = '{0}'
//                                                                                   ORDER BY SORT_KEY", tempSoap)).ToString();
//                    this.layBojoList.SetBindVarValue("f_soap_gubun", tempSoap);
//                    this.SetTvwBojoList();
//                }
//            }
        }
        #endregion

        #region [----------------------------------------------- XSavePerformer -----------------------------------------------]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR9001U00 parent = null;  //Parent 관리
            //생성자 : parent를 넘겨받아 SET
            public XSavePerformer(NUR9001U00 parent)
            {
                this.parent = parent;
            }
            //Execute 구현
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:     // 입력된 행 (INSERT)

                        if (item.BindVarList["f_pknur9001"].VarValue.Equals(""))
                        { 
                        
                        }

                        if (item.BindVarList["f_pknur9001"].VarValue.Equals("") || TypeCheck.IsNull(item.BindVarList["f_pknur9001"].VarValue))
                        {
                            item.BindVarList["f_pknur9001"].VarValue = Service.ExecuteScalar("SELECT NUR9001_SEQ.NEXTVAL FROM DUAL").ToString();
                        }
                        if (item.BindVarList["f_fkinp1001"].VarValue.Equals("") || TypeCheck.IsNull(item.BindVarList["f_fkinp1001"].VarValue))
                        {
                            cmdText = @"SELECT PKINP1001 
                                             FROM VW_OCS_INP1001_01
                                            WHERE HOSP_CODE = :f_hosp_code 
                                              AND BUNHO = :f_bunho
                                              AND NVL(JAEWON_FLAG, 'N') = 'Y'
                                              AND NVL(CANCEL_YN, 'N')   = 'N'
                                              AND ROWNUM                = 1";
                            object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                            if (!TypeCheck.IsNull(retVal))
                            {
                                item.BindVarList["f_fkinp1001"].VarValue = retVal.ToString();
                            }

                        }
                        cmdText = @"
                                INSERT INTO NUR9001 (SYS_DATE                              , SYS_ID                    , UPD_DATE                       ,
                                                     UPD_ID                                , HOSP_CODE                 ,
                                                     PKNUR9001                             , FKINP1001                 , BUNHO                          ,
                                                     RECORD_DATE                           , RECORD_TIME               , SOAP_GUBUN                     ,
                                                     RECORD_CONTENTS                       , NUR_PLAN_JIN              , RECORD_USER                    ,
                                                     VALD                                  , DC_YN                     , DC_USER                        ,
                                                     MAYAK_USE_YN                          , FKNUR4001)
                                VALUES              (SYSDATE                               , :q_user_id                , SYSDATE                        ,
                                                     :q_user_id                            , :f_hosp_code              ,
                                                     NVL(TRIM(:f_pknur9001), NUR9001_SEQ.NEXTVAL), :f_fkinp1001        , :f_bunho                       ,
                                                     :f_record_date                        , NVL(:f_record_time,'0000'), :f_soap_gubun                  ,
                                                     :f_record_contents                    , :f_nur_plan_jin           , NVL(:f_record_user, :q_user_id),
                                                     NVL(:f_vald, 'Y')                     , NVL(:f_dc_yn, 'N')        , :f_dc_user                     ,
                                                     :f_mayak_use_yn                       , :f_fknur4001)";
                        break;
                    case DataRowState.Modified:  // 수정된 행 (UPDATE)
                        cmdText = @"UPDATE NUR9001
                                       SET UPD_ID          = :q_user_id,
                                           UPD_DATE        = SYSDATE,
                                           RECORD_DATE     = :f_record_date,
                                           RECORD_TIME     = :f_record_time,
                                           SOAP_GUBUN      = :f_soap_gubun,
                                           RECORD_CONTENTS = :f_record_contents,
                                           NUR_PLAN_JIN    = :f_nur_plan_jin,
                                           RECORD_USER     = :f_record_user,
                                           VALD            = 'Y',
                                           DC_YN           = :f_dc_yn,
                                           DC_USER         = :f_dc_user,
                                           MAYAK_USE_YN    = :f_mayak_use_yn,
                                           FKNUR4001       = :f_fknur4001
                                     WHERE HOSP_CODE       = :f_hosp_code 
                                       AND PKNUR9001       = :f_pknur9001";
                        break;
                    case DataRowState.Deleted:   // 삭제된 행 (DELETE)
                        cmdText = @"UPDATE NUR9001 
                                       SET VALD      = 'N' 
                                     WHERE HOSP_CODE = :f_hosp_code 
                                       AND PKNUR9001 = :f_pknur9001";
                        break;
                }
                //저장 Method call
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void layNUR4001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNUR4001.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layNUR4001.SetBindVarValue("f_fkinp1001", this.txtFkinp1001.GetDataValue());
            this.layNUR4001.SetBindVarValue("f_bunho", paBox.BunHo);
            this.layNUR4001.SetBindVarValue("f_date", dtpQuery.GetDataValue());
        }

        private void layNUR4001_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.tvwNUR4003.Nodes.Clear();
            if (layNUR4001.RowCount < 1) return;

            //Node 단계 check변수
            string nur_plan_jin = "";
            //string nur_plan_pro = "";
            string nur_plan_ote = "";
            string nur_plan = "";
            string pknur4001 = "";
            string nur4001_vald = "";
            TreeNode node;

            foreach (DataRow row in layNUR4001.LayoutTable.Rows)
            {
                if (pknur4001 != row["pknur4001"].ToString())// || nur_plan_jin != row["nur_plan_jin"].ToString() || nur_plan_pro != row["nur_plan_pro"].ToString())
                {
                    node = new TreeNode(row["nur_plan_jin_name"].ToString() + "  ▶▶▶ " + row["plan_user_name"].ToString());
                    node.Tag = row["pknur4001"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_jin"].ToString();

                    if (row["valu_date"].ToString() != "")
                    {
                        if (DateTime.Parse(row["valu_date"].ToString()) == DateTime.Parse(dtpQuery.GetDataValue()))
                        {
                            node.BackColor = Color.LightSkyBlue;
                        }
                        else if (DateTime.Parse(row["valu_date"].ToString()) < DateTime.Parse(dtpQuery.GetDataValue()))
                        {
                            node.BackColor = Color.LightPink;
                        }
                    }

                    nur4001_vald = row["nur4001_vald"].ToString();
                    if (nur4001_vald == "N")
                        node.BackColor = Color.LightGreen;

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Bold);

                    tvwNUR4003.Nodes.Add(node);

                    pknur4001 = row["pknur4001"].ToString();
                    nur_plan_jin = row["nur_plan_jin"].ToString();
                    nur_plan_ote = "";
                    nur_plan = "";

                    if (row["purpose"].ToString() != "")
                    {
                        node = new TreeNode("目　　標　▶ " + row["purpose"].ToString());
                        node.Tag = row["pknur4001"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_ote"].ToString();
                        node.NodeFont = new Font("ＭＳ ゴシック", 10f, FontStyle.Regular);
                        node.SelectedImageIndex = 5;
                        node.ImageIndex = 5;
                        tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count - 1].Nodes.Add(node);
                    }
                }

                if (nur_plan_ote != row["nur_plan_ote"].ToString())
                {
                    node = new TreeNode();

                    if (row["nur_plan_ote"].ToString() == "P")
                        node.Text = "関連因子";
                    else if (row["nur_plan_ote"].ToString() == "O")
                        node.Text = "O P-観察";
                    else if (row["nur_plan_ote"].ToString() == "T")
                        node.Text = "T P-ケア";
                    else if (row["nur_plan_ote"].ToString() == "E")
                        node.Text = "E P-教育";

                    node.Tag = row["pknur4001"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_ote"].ToString();
                    node.SelectedImageIndex = 5;
                    node.ImageIndex = 5;

                    node.NodeFont = new Font("ＭＳ ゴシック", 10f, FontStyle.Regular);
                    tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count - 1].Nodes.Add(node);
                    nur_plan_ote = row["nur_plan_ote"].ToString();
                }

                if (nur_plan != row["nur_plan"].ToString())
                {
                    node = new TreeNode(row["nur_plan_name"].ToString());
                    node.Tag = row["pknur4001"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan"].ToString();
                    node.SelectedImageIndex = 6;
                    node.ImageIndex = 6;

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
                    tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count - 1].LastNode.Nodes.Add(node);
                    nur_plan = row["nur_plan"].ToString();
                }


                if (row["nur_plan_detail"].ToString() != "")
                {
                    node = new TreeNode(row["nur_plan_dename"].ToString());
                    node.Tag = row["pknur4001"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_detail"].ToString();
                    node.SelectedImageIndex = 7;
                    node.ImageIndex = 7;

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
                    tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count - 1].LastNode.LastNode.Nodes.Add(node);
                }
            }

            foreach (TreeNode nd in tvwNUR4003.Nodes)
            {
                nd.Expand();
            }


            //tvwNUR4003.ExpandAll();

            if (layNUR4001.RowCount > 0) tvwNUR4003.SelectedNode = tvwNUR4003.Nodes[0];

        }

        private void btnOutPatient_Click(object sender, EventArgs e)
        {
            string sysid = EnvironInfo.CurrSystemID;
            string screen = this.ScreenID;
            string bunho = this.paBox.BunHo.ToString();

            IHIS.Framework.IXScreen aScreen;
            aScreen = XScreen.FindScreen("NURI", "NUR9001Q01");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("sysid", sysid);
                openParams.Add("screen", screen);
                openParams.Add("bunho", bunho);

                XScreen.OpenScreenWithParam(this, "NURI", "NUR9001Q01", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleCenter, openParams);
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }
        #region 팝업화면에서 데이터 받기
        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "toiwon_date")
            {
                if (commandParam["toiwon_date"].ToString() != "")
                {

                    DateTime toiwon_date = DateTime.Parse(commandParam["toiwon_date"].ToString());
                    
                    this.txtFkinp1001.SetDataValue(commandParam["fkinp1001"].ToString());
                    this.dtpQuery.SetEditValue(toiwon_date);
                    this.dtpToDate.SetDataValue(toiwon_date);
                    this.dtpFromDate.SetDataValue(toiwon_date.AddDays(-6));
                    this.paBox.SetPatientID(commandParam["bunho"].ToString());
                    this.dtpQuery.AcceptData();                    
                }
                else
                {
                    this.dtpQuery.SetEditValue(EnvironInfo.GetSysDate());
                    this.dtpQuery.AcceptData();
                }

                if (!grdNUR9001.QueryLayout(false))
                {
                    XMessageBox.Show(Service.ErrFullMsg.ToString());
                }
            }
            return base.Command(command, commandParam);
        }
        #endregion

        private void tvwNUR4003_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                //PopUp Menu생성
                CreatePopUpMenu("1");
                //PopUp Menu Show
                tvwNUR4003.SelectedNode = tvwNUR4003.GetNodeAt(new Point(e.X, e.Y));
                popMenu.TrackPopup(tvwNUR4003.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        #region [PopUp Menu]
        IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();

        private void CreatePopUpMenu(string sPopMode)
        {
            //Item Clear
            popMenu.MenuCommands.Clear();

            //PopupMenu 
            IHIS.X.Magic.Menus.MenuCommand menuCmd = null;

            if (sPopMode == "0")
            {
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("コピー", this.ImageList.Images[9], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = "COPY";
                popMenu.MenuCommands.Add(menuCmd);
            }
            else
            {
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("コピー", this.ImageList.Images[9], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = "COPY";
                popMenu.MenuCommands.Add(menuCmd);
            }
        }

        private void OnPopMenuClick(object sender, EventArgs e)
        {
            string menuItemIndex = ((IHIS.X.Magic.Menus.MenuCommand)sender).Tag.ToString();

            switch (menuItemIndex)
            {
                case "COPY":
                    Clipboard.SetDataObject(this.tvwNUR4003.SelectedNode.Text, true);
                    break;
                default:

                    break;
            }
        }

        #endregion

        #region 간호경과기록출력버튼을 클릭을 했을 때
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo.ToString() != "")
            {
                string sysid = EnvironInfo.CurrSystemID;
                string screen = this.ScreenID;
                string bunho = this.paBox.BunHo.ToString();

                IHIS.Framework.IXScreen aScreen;
                aScreen = XScreen.FindScreen("NURI", "NUR9001R00");

                if (aScreen == null)
                {
                    CommonItemCollection openParams = new CommonItemCollection();
                    openParams.Add("sysid", sysid);
                    openParams.Add("screen", screen);
                    openParams.Add("bunho", bunho);
                    openParams.Add("from_date", dtpFromDate.GetDataValue());
                    openParams.Add("to_date", dtpToDate.GetDataValue());

                    XScreen.OpenScreenWithParam(this, "NURI", "NUR9001R00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleCenter, openParams);
                }
                else
                {
                    ((XScreen)aScreen).Activate();
                }
            }
        }
        #endregion

        private void grdNUR9001_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.grdNUR9001.SetFocusToItem(this.grdNUR9001.RowCount - 1, 0);
        }

        private void grdNUR9001_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.DataRow.RowState == DataRowState.Added)
            {
                e.Protect = false;
                return;
            }
            if (e.ColName == "dc_button")
            {
                if (jaewon == true)
                {
                    e.Protect = false;
                }
                else
                {
                    e.Protect = true;
                }
                return;            
            }

            //string record_date = this.grdNUR9001.GetItemDateTime(e.RowNumber, "record_date").ToString("yyyyMMdd");
            //DateTime record_date = this.grdNUR9001.GetItemDateTime(e.RowNumber, "record_date");
            //string record_time = this.grdNUR9001.GetItemString(e.RowNumber, "record_time");
            //string record_user = TypeCheck.NVL(this.grdNUR9001.GetItemString(e.RowNumber, "record_user"), UserInfo.UserID.ToString()).ToString();

            string record_user = TypeCheck.NVL(this.grdNUR9001.GetItemString(e.RowNumber, "record_user"), txtNurse.Text).ToString();

            //DateTime record_date_time = new DateTime(record_date.Year, record_date.Month, record_date.Day, 
                                                     //Convert.ToInt32(record_time.Substring(0, 2)), Convert.ToInt32(record_time.Substring(2, 2)),00);

            //if (this.grdNUR9001.GetItemString(e.RowNumber, "record_date") != "")
            //{
            //    writeDate = this.grdNUR9001.GetItemDateTime(e.RowNumber, "record_date").ToString("yyyyMMdd");
            //}
            //else
            //{
            //    writeDate = EnvironInfo.GetSysDate().ToString("yyyyMMdd");
            //}
            //DateTime current_date_time = EnvironInfo.GetSysDateTime();
            //string current_date = CurrentSysDate.ToString("yyyyMMdd");
            //string current_time = CurrentSysDate.ToShortTimeString();
            
            //string current_user = UserInfo.UserID.ToString();
            string current_user = txtNurse.Text;
            
            //TimeSpan ts = current_date_time - record_date_time;

            if ((!jaewon) || e.DataRow["over24"].ToString() == "Y" || (!record_user.Equals(current_user)))
            //if ((!jaewon) || ts.Days >= 1 || (!record_user.Equals(current_user)))
            //if ((!jaewon) || int.Parse(writeDate) < int.Parse(loginDate) || (!record_user.Equals(current_user)))
            {
                e.Protect = true;
            }
            else
            {
                e.Protect = false;
            }
        }

        private void grdNUR9001_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            if (e.DataRow["dc_yn"].ToString() == "Y")
            {
                //if (e.DataRow["dc_user"].ToString().Trim() == UserInfo.UserID.ToString().Trim())
                if (e.DataRow["dc_user"].ToString().Trim() == txtNurse.Text)
                {
                    e.DataRow["dc_yn"] = "N";
                    e.DataRow["dc_user"] = "";
                    //this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_yn", "N");
                    //this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_user", "");
                    this.grdNUR9001.Refresh();
                    return;
                }
                else
                {
                    XMessageBox.Show("DC設定したユーザーと異なるのでDC解除できません。", "ユーザー確認", MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                e.DataRow["dc_yn"] = "Y";
                e.DataRow["dc_user"] = txtNurse.Text; //UserInfo.UserID.ToString();
                //this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_yn", "Y");
                //this.grdNUR9001.SetItemValue(this.grdNUR9001.CurrentRowNumber, "dc_user", UserInfo.UserID.ToString());
                this.grdNUR9001.Refresh();
                return;
            }

        }

        private void grdNUR9001_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "record_contents")
            {
                this.grdNUR9001.SetItemValue(e.RowNumber, "record_contents_dis", e.ChangeValue);
                //this.grdNUR9001.SetFocusToItem(e.RowNumber, "record_contents_dis");
                grdNUR9001.AcceptData();
                this.grdNUR9001.DisplayData();
            }
            
            if (e.ColName == "record_date")
            {
                if (e.ChangeValue.ToString() == "")
                {
                    grdNUR9001.SetItemValue(e.RowNumber, e.ColName, dtpQuery.GetDataValue());
                }
            }

            if (e.ColName == "record_user")
            {
                BindVarCollection bindVar = new BindVarCollection();
                string strCmd = @"SELECT FN_ADM_LOAD_USER_NM(:f_record_user, :f_date) FROM SYS.DUAL";

                bindVar.Add("f_record_user", e.ChangeValue.ToString());
                bindVar.Add("f_date", dtpQuery.GetDataValue());

                object retVar = Service.ExecuteScalar(strCmd, bindVar);

                if (retVar.ToString() == "")
                {
                    XMessageBox.Show("ユーザを検索できませんでした。");
                    this.grdNUR9001.GridColumnChanged -= new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR9001_GridColumnChanged);
                    grdNUR9001.SetItemValue(e.RowNumber, e.ColName, "");
                    grdNUR9001.SetItemValue(e.RowNumber, "record_user_name", "");

                    PostCallHelper.PostCall(SetRecordUser, e.RowNumber);

                    this.grdNUR9001.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR9001_GridColumnChanged);
                }
                else
                {
                    this.grdNUR9001.SetItemValue(e.RowNumber, "record_user_name", retVar.ToString());
                }
            }

        }
        private void SetRecordUser(int rowNum)
        {
            grdNUR9001.SetFocusToItem(rowNum, "record_user");
        }
        private void tvwNUR4003_KeyDown(object sender, KeyEventArgs e)
        {
            TreeView treeview = sender as TreeView;

            if (treeview.SelectedNode != null)
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    Clipboard.SetDataObject(treeview.SelectedNode.Text, true);
                }
            }

        }

        private void layComboNUR4001_QueryStarting(object sender, CancelEventArgs e)
        {
            layComboNUR4001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layComboNUR4001.SetBindVarValue("f_fkinp1001", txtFkinp1001.Text);
        }

        private void fwkNurse_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkNurse.SetBindVarValue("f_buseo_code", UserInfo.BuseoCode);
        }

        private void grdNUR9001_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            if (e.ColName == "record_user")
            {
                grdNUR9001.SetItemValue(e.RowNumber, "record_user_name", e.ReturnValues[1].ToString());
            }
        }

        private void btnClearNurse_Click(object sender, EventArgs e)
        {
            txtNurse.SetDataValue("");
            dbxNurseName.SetDataValue("");
        }

        private void txtNurse_DataValidating(object sender, DataValidatingEventArgs e)
        {
            dbxNurseName.SetDataValue("");

            if (TypeCheck.IsNull(e.DataValue))
            {
                txtNurse.SetDataValue("");
            }

            string user_nm = GetAdminUSER_NAME(e.DataValue);

            if (TypeCheck.IsNull(user_nm))
            {
                txtNurse.SetDataValue("");
                txtNurse.Focus();
                txtNurse.SelectAll();
                return;
            }

            dbxNurseName.SetDataValue(user_nm);
        }

        private string GetAdminUSER_NAME(string aUser_id)
        {
            string user_name = "";
            string cmdText = "";

            string mbxMsg = "";
            string mbxCap = "";
            DataTable dtResult = new DataTable();

            cmdText = ""
                + " SELECT USER_NM, FN_PPE_LOAD_CONFIRM_ENABLE(USER_ID) CONFIRM_GRANT"
                + "   FROM ADM3200   "
                + "  WHERE HOSP_CODE = '" + mHospCode + "' "
                + "    AND USER_ID   = '" + aUser_id + "' ";
            dtResult = Service.ExecuteDataTable(cmdText);

            if (Service.ErrCode == 0 && !TypeCheck.IsNull(dtResult))
            {
                if (dtResult.Rows[0]["confirm_grant"].ToString() != "Y")
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "オーダ確認権限がありません。確認してください。" : "오더확인권한이 없습니다. 확인바랍니다.";
                    mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
                    return user_name;

                }
                user_name = dtResult.Rows[0]["user_nm"].ToString();
            }
            return user_name;
        }

        private void btnNUR4001_Click(object sender, EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("bunho", this.paBox.BunHo);

            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR4001U00", ScreenOpenStyle.PopUpFixed, cic);
        }

        private void cbxTeam_CheckedChanged(object sender, EventArgs e)
        {
            grdPalist.QueryLayout(false);
        }

        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            if (!this.Validation())
            {
                return;
            }
            if (IsChanged())
            {
                if (XMessageBox.Show("変更されたデータがあります。保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    btnList.PerformClick(FunctionType.Update);
                }
            }
            int rownum = paListRownum + 1 < grdPalist.RowCount ? paListRownum + 1 : 0;

            paBox.SetPatientID(grdPalist.GetItemString(rownum, "bunho"));

            paListRownum = rownum;

            grdPalist.UnSelectAll();
            grdPalist.SelectRow(rownum);
            grdPalist.SetFocusToItem(rownum, "bunho");
        }

        private void grdPalist_MouseClick(object sender, MouseEventArgs e)
        {
            if (grdPalist.CurrentRowNumber >= 0)
            {
                //환자번호 Set
                this.paBox.SetPatientID(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "bunho").ToString());
                this.txtFkinp1001.SetEditValue(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "pkinp1001").ToString());

                this.paListRownum = grdPalist.CurrentRowNumber;
            }

            //if (e.Button == MouseButtons.Right)
            //{
            //    grdPalist.UnSelectAll();
            //    grdPalist.SelectRow(grdPalist.GetHitRowNumber(e.Y));
            //    popMenu.TrackPopup(grdPalist.PointToScreen(e.Location));

            //    grdPalist.QueryLayout(true);
            //}
        }

        private void grdPalist_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPalist.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdPalist.SetBindVarValue("f_date", this.dtpQuery.GetDataValue());
            grdPalist.SetBindVarValue("f_ho_dong", cboHo_dong.GetDataValue());
            grdPalist.SetBindVarValue("f_a", cbxA.GetDataValue());
            grdPalist.SetBindVarValue("f_b", cbxB.GetDataValue());
            grdPalist.SetBindVarValue("f_c", cbxC.GetDataValue());
            grdPalist.SetBindVarValue("f_d", cbxD.GetDataValue());
        }

        private void grdPalist_QueryEnd(object sender, QueryEndEventArgs e)
        {
            Set_grdPalist_Position(paBox.BunHo);
        }

        private void Set_grdPalist_Position(string i_bunho)
        {
            this.grdPalist.UnSelectAll();
            for (int i = 0; i < this.grdPalist.RowCount; i++)
            {
                if (this.grdPalist.GetItemString(i, "bunho") == i_bunho)
                {
                    this.grdPalist.SelectRow(i);
                    grdPalist.SetFocusToItem(i, "bunho");
                    paListRownum = i;
                    break;
                }
            }
            grdPalist.SelectRow(paListRownum);
            grdPalist.SetFocusToItem(paListRownum, "bunho");
        }

        private bool IsChanged()
        {
            for (int i = 0; i < grdNUR9001.RowCount; i++)
            {
                if (grdNUR9001.GetRowState(i) == DataRowState.Added ||
                    grdNUR9001.GetRowState(i) == DataRowState.Modified ||
                    grdNUR9001.DeletedRowCount != 0)
                {
                    return true;
                }
            }


            return false;
        }

        private void grdPalist_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (grdPalist.CurrentRowNumber >= 0)
            {
                if (!Validation())
                {
                    this.grdPalist.RowFocusChanged -= new IHIS.Framework.RowFocusChangedEventHandler(this.grdPalist_RowFocusChanged);

                    grdPalist.UnSelectAll();
                    grdPalist.SelectRow(paListRownum);

                    this.grdPalist.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPalist_RowFocusChanged);
                    return;
                }

                if (IsChanged())
                {
                    if (XMessageBox.Show("変更されたデータがあります。保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                    }
                }
            }

        }

        private void grdNUR9001_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess == true)
            {
                XMessageBox.Show("保存しました。");
            }
        }

        private void dtpDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = !pnlHelp.Visible;
        }
    }
}

