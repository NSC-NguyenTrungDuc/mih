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

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL2010Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL2010Q01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdHangmog;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XDatePicker dtpToDate;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XDictComboBox cboJundalGubun;
		private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private System.Windows.Forms.GroupBox groupBox2;
		private IHIS.Framework.XRadioButton rbxTodayChk;
		private IHIS.Framework.XRadioButton rbxAfterChk;
		private IHIS.Framework.XRadioButton rbxAll2;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private System.Windows.Forms.GroupBox groupBox3;
		private IHIS.Framework.XRadioButton rbxResult;
		private IHIS.Framework.XRadioButton rbxAll3;
		private IHIS.Framework.XRadioButton rbxMiResult;
		private IHIS.Framework.XButton btnMiDochakPnt;
		private IHIS.Framework.XButton btnMiResult;
	//	private IHIS.Framework.XDataWindow dwPnt;
		private IHIS.Framework.MultiLayout layMiDochak;
		private IHIS.Framework.MultiLayout layMiGumsa;
		private System.Windows.Forms.GroupBox groupBox4;
		private IHIS.Framework.XRadioButton rbxInline;
		private IHIS.Framework.XRadioButton rbxAll4;
		private IHIS.Framework.XRadioButton rbxSRL;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.SingleLayout layLog;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XPatientBox xPatientBox1;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private SingleLayoutItem singleLayoutItem1;
        private XTextBox txtLog;
        private XLabel xLabel2;
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
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem38;
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
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private XButton btnListPnt;
        private MultiLayout layPntList;
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
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem39;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPL2010Q01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010Q01));
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbxTodayChk = new IHIS.Framework.XRadioButton();
            this.rbxAfterChk = new IHIS.Framework.XRadioButton();
            this.rbxAll2 = new IHIS.Framework.XRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboJundalGubun = new IHIS.Framework.XDictComboBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbxInline = new IHIS.Framework.XRadioButton();
            this.rbxAll4 = new IHIS.Framework.XRadioButton();
            this.rbxSRL = new IHIS.Framework.XRadioButton();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbxResult = new IHIS.Framework.XRadioButton();
            this.rbxAll3 = new IHIS.Framework.XRadioButton();
            this.rbxMiResult = new IHIS.Framework.XRadioButton();
            this.xPatientBox1 = new IHIS.Framework.XPatientBox();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdHangmog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.txtLog = new IHIS.Framework.XTextBox();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnListPnt = new IHIS.Framework.XButton();
    //        this.dwPnt = new IHIS.Framework.XDataWindow();
            this.btnMiResult = new IHIS.Framework.XButton();
            this.btnMiDochakPnt = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.layMiDochak = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.layMiGumsa = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.layLog = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layPntList = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).BeginInit();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layMiDochak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMiGumsa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPntList)).BeginInit();
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
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.xLabel2);
            this.xPanel6.Controls.Add(this.groupBox2);
            this.xPanel6.Controls.Add(this.xLabel1);
            this.xPanel6.Controls.Add(this.cboJundalGubun);
            this.xPanel6.Controls.Add(this.dtpToDate);
            this.xPanel6.Controls.Add(this.groupBox4);
            this.xPanel6.Controls.Add(this.dtpFromDate);
            this.xPanel6.Controls.Add(this.xLabel9);
            this.xPanel6.Controls.Add(this.label1);
            this.xPanel6.Controls.Add(this.groupBox3);
            this.xPanel6.Controls.Add(this.xPatientBox1);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Location = new System.Drawing.Point(5, 5);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(1028, 55);
            this.xPanel6.TabIndex = 9;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(8, 31);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(65, 20);
            this.xLabel2.TabIndex = 28;
            this.xLabel2.Text = "患者番号";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbxTodayChk);
            this.groupBox2.Controls.Add(this.rbxAfterChk);
            this.groupBox2.Controls.Add(this.rbxAll2);
            this.groupBox2.Location = new System.Drawing.Point(624, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 30);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // rbxTodayChk
            // 
            this.rbxTodayChk.Location = new System.Drawing.Point(136, 8);
            this.rbxTodayChk.Name = "rbxTodayChk";
            this.rbxTodayChk.Size = new System.Drawing.Size(78, 18);
            this.rbxTodayChk.TabIndex = 2;
            this.rbxTodayChk.Text = "当日検体";
            this.rbxTodayChk.UseVisualStyleBackColor = false;
            this.rbxTodayChk.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAfterChk
            // 
            this.rbxAfterChk.Location = new System.Drawing.Point(57, 8);
            this.rbxAfterChk.Name = "rbxAfterChk";
            this.rbxAfterChk.Size = new System.Drawing.Size(78, 18);
            this.rbxAfterChk.TabIndex = 1;
            this.rbxAfterChk.Text = "後日検体";
            this.rbxAfterChk.UseVisualStyleBackColor = false;
            this.rbxAfterChk.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAll2
            // 
            this.rbxAll2.Checked = true;
            this.rbxAll2.Location = new System.Drawing.Point(4, 8);
            this.rbxAll2.Name = "rbxAll2";
            this.rbxAll2.Size = new System.Drawing.Size(52, 18);
            this.rbxAll2.TabIndex = 0;
            this.rbxAll2.TabStop = true;
            this.rbxAll2.Text = "全体";
            this.rbxAll2.UseVisualStyleBackColor = false;
            this.rbxAll2.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(273, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(65, 21);
            this.xLabel1.TabIndex = 24;
            this.xLabel1.Text = "伝達パート";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboJundalGubun
            // 
            this.cboJundalGubun.Location = new System.Drawing.Point(338, 6);
            this.cboJundalGubun.MaxDropDownItems = 15;
            this.cboJundalGubun.Name = "cboJundalGubun";
            this.cboJundalGubun.Size = new System.Drawing.Size(104, 21);
            this.cboJundalGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJundalGubun.TabIndex = 23;
            this.cboJundalGubun.UserSQL = "SELECT \'%\', FN_ADM_MSG(\'221\')\r\n  FROM DUAL\r\n UNION ALL\r\nSELECT CODE, CODE_NAME \r\n" +
                "  FROM CPL0109\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n   AND CODE_TYPE = \'" +
                "01\'";
            this.cboJundalGubun.SelectionChangeCommitted += new System.EventHandler(this.cboJundalGubun_SelectionChangeCommitted);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(175, 6);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 20);
            this.dtpToDate.TabIndex = 21;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbxInline);
            this.groupBox4.Controls.Add(this.rbxAll4);
            this.groupBox4.Controls.Add(this.rbxSRL);
            this.groupBox4.Location = new System.Drawing.Point(450, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 30);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            // 
            // rbxInline
            // 
            this.rbxInline.Location = new System.Drawing.Point(54, 8);
            this.rbxInline.Name = "rbxInline";
            this.rbxInline.Size = new System.Drawing.Size(50, 18);
            this.rbxInline.TabIndex = 1;
            this.rbxInline.Text = "院内";
            this.rbxInline.UseVisualStyleBackColor = false;
            this.rbxInline.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAll4
            // 
            this.rbxAll4.Checked = true;
            this.rbxAll4.Location = new System.Drawing.Point(4, 8);
            this.rbxAll4.Name = "rbxAll4";
            this.rbxAll4.Size = new System.Drawing.Size(50, 18);
            this.rbxAll4.TabIndex = 0;
            this.rbxAll4.TabStop = true;
            this.rbxAll4.Text = "全体";
            this.rbxAll4.UseVisualStyleBackColor = false;
            this.rbxAll4.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxSRL
            // 
            this.rbxSRL.Location = new System.Drawing.Point(104, 8);
            this.rbxSRL.Name = "rbxSRL";
            this.rbxSRL.Size = new System.Drawing.Size(50, 18);
            this.rbxSRL.TabIndex = 2;
            this.rbxSRL.Text = "BML";
            this.rbxSRL.UseVisualStyleBackColor = false;
            this.rbxSRL.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(73, 6);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtpFromDate.TabIndex = 20;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Location = new System.Drawing.Point(8, 6);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(65, 20);
            this.xLabel9.TabIndex = 7;
            this.xLabel9.Text = "オーダ日";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(165, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "~";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbxResult);
            this.groupBox3.Controls.Add(this.rbxAll3);
            this.groupBox3.Controls.Add(this.rbxMiResult);
            this.groupBox3.Location = new System.Drawing.Point(847, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(170, 30);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // rbxResult
            // 
            this.rbxResult.Location = new System.Drawing.Point(54, 8);
            this.rbxResult.Name = "rbxResult";
            this.rbxResult.Size = new System.Drawing.Size(50, 18);
            this.rbxResult.TabIndex = 1;
            this.rbxResult.Text = "検査";
            this.rbxResult.UseVisualStyleBackColor = false;
            this.rbxResult.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAll3
            // 
            this.rbxAll3.Checked = true;
            this.rbxAll3.Location = new System.Drawing.Point(4, 8);
            this.rbxAll3.Name = "rbxAll3";
            this.rbxAll3.Size = new System.Drawing.Size(50, 18);
            this.rbxAll3.TabIndex = 0;
            this.rbxAll3.TabStop = true;
            this.rbxAll3.Text = "全体";
            this.rbxAll3.UseVisualStyleBackColor = false;
            this.rbxAll3.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxMiResult
            // 
            this.rbxMiResult.Location = new System.Drawing.Point(104, 8);
            this.rbxMiResult.Name = "rbxMiResult";
            this.rbxMiResult.Size = new System.Drawing.Size(64, 18);
            this.rbxMiResult.TabIndex = 2;
            this.rbxMiResult.Text = "未検査";
            this.rbxMiResult.UseVisualStyleBackColor = false;
            this.rbxMiResult.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xPatientBox1
            // 
            this.xPatientBox1.Location = new System.Drawing.Point(3, 26);
            this.xPatientBox1.Name = "xPatientBox1";
            this.xPatientBox1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.xPatientBox1.Size = new System.Drawing.Size(960, 30);
            this.xPatientBox1.TabIndex = 27;
            this.xPatientBox1.PatientSelected += new System.EventHandler(this.xPatientBox1_PatientSelected);
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdHangmog);
            this.xPanel5.Controls.Add(this.txtLog);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(1026, 747);
            this.xPanel5.TabIndex = 3;
            // 
            // grdHangmog
            // 
            this.grdHangmog.ApplyPaintEventToAllColumn = true;
            this.grdHangmog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell20,
            this.xEditGridCell8,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell12,
            this.xEditGridCell14,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell7});
            this.grdHangmog.ColPerLine = 15;
            this.grdHangmog.ColResizable = true;
            this.grdHangmog.Cols = 16;
            this.grdHangmog.ControlBinding = true;
            this.grdHangmog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHangmog.FixedCols = 1;
            this.grdHangmog.FixedRows = 1;
            this.grdHangmog.HeaderHeights.Add(21);
            this.grdHangmog.Location = new System.Drawing.Point(0, 0);
            this.grdHangmog.Name = "grdHangmog";
            this.grdHangmog.QuerySQL = resources.GetString("grdHangmog.QuerySQL");
            this.grdHangmog.RowHeaderVisible = true;
            this.grdHangmog.Rows = 2;
            this.grdHangmog.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdHangmog.Size = new System.Drawing.Size(1024, 695);
            this.grdHangmog.TabIndex = 1;
            this.grdHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmog_QueryStarting);
            this.grdHangmog.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdHangmog_GridCellPainting);
            this.grdHangmog.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdHangmog_RowFocusChanged);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "order_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 83;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.EnableSort = true;
            this.xEditGridCell11.HeaderText = "オーダ日";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.SuppressRepeating = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bunho";
            this.xEditGridCell13.CellWidth = 77;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.EnableSort = true;
            this.xEditGridCell13.HeaderText = "患者番号";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsUpdCol = false;
            this.xEditGridCell13.SuppressRepeating = true;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 30;
            this.xEditGridCell15.CellName = "suname";
            this.xEditGridCell15.CellWidth = 89;
            this.xEditGridCell15.Col = 4;
            this.xEditGridCell15.EnableSort = true;
            this.xEditGridCell15.HeaderText = "氏名";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.SuppressRepeating = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "hangmog_code";
            this.xEditGridCell16.CellWidth = 65;
            this.xEditGridCell16.Col = 5;
            this.xEditGridCell16.EnableSort = true;
            this.xEditGridCell16.HeaderText = "項目コード";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 100;
            this.xEditGridCell17.CellName = "gumsa_name";
            this.xEditGridCell17.CellWidth = 203;
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.EnableSort = true;
            this.xEditGridCell17.HeaderText = "検査名";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell18.CellName = "order_yn";
            this.xEditGridCell18.CellWidth = 65;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "未採血";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell19.CellName = "chehyul_yn";
            this.xEditGridCell19.CellWidth = 65;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "採血";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell21.CellName = "part_jub_yn";
            this.xEditGridCell21.CellWidth = 65;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "検査中";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell22.CellName = "result_yn";
            this.xEditGridCell22.CellWidth = 65;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "結果";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell20.CellName = "confirm_yn";
            this.xEditGridCell20.CellWidth = 65;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "確認";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "print_yn";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "印刷";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "cpl_result";
            this.xEditGridCell6.CellWidth = 52;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.HeaderText = "結果値";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa_name";
            this.xEditGridCell9.CellWidth = 59;
            this.xEditGridCell9.Col = 7;
            this.xEditGridCell9.EnableSort = true;
            this.xEditGridCell9.HeaderText = "科/病棟";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.SuppressRepeating = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "specimen_ser";
            this.xEditGridCell10.Col = 15;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.HeaderText = "検体番号";
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "order_time";
            this.xEditGridCell12.CellWidth = 42;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.EnableSort = true;
            this.xEditGridCell12.HeaderText = "時間";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.Mask = "XX:XX";
            this.xEditGridCell12.SuppressRepeating = true;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "dp_yn";
            this.xEditGridCell14.CellWidth = 25;
            this.xEditGridCell14.Col = 14;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell14.EnableSort = true;
            this.xEditGridCell14.HeaderText = "Dp";
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "order";
            this.xEditGridCell1.CellWidth = 41;
            this.xEditGridCell1.Col = 9;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.HeaderText = "未採血";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.CellName = "chehyul";
            this.xEditGridCell2.CellWidth = 41;
            this.xEditGridCell2.Col = 10;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderText = "採血";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "part_jub";
            this.xEditGridCell4.CellWidth = 41;
            this.xEditGridCell4.Col = 11;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.HeaderText = "検査中";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.CellName = "result";
            this.xEditGridCell5.CellWidth = 41;
            this.xEditGridCell5.Col = 12;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.HeaderText = "結果";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.CellName = "confirm";
            this.xEditGridCell3.CellWidth = 37;
            this.xEditGridCell3.Col = 13;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.HeaderText = "確認";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.CellName = "print";
            this.xEditGridCell7.CellWidth = 41;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "印刷";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 695);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1024, 50);
            this.txtLog.TabIndex = 2;
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.btnListPnt);
   //         this.xPanel8.Controls.Add(this.dwPnt);
            this.xPanel8.Controls.Add(this.btnMiResult);
            this.xPanel8.Controls.Add(this.btnMiDochakPnt);
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel8.Location = new System.Drawing.Point(0, 747);
            this.xPanel8.Name = "xPanel8";
            this.xPanel8.Size = new System.Drawing.Size(1026, 36);
            this.xPanel8.TabIndex = 5;
            // 
            // btnListPnt
            // 
            this.btnListPnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListPnt.Image = ((System.Drawing.Image)(resources.GetObject("btnListPnt.Image")));
            this.btnListPnt.Location = new System.Drawing.Point(692, 3);
            this.btnListPnt.Name = "btnListPnt";
            this.btnListPnt.Size = new System.Drawing.Size(80, 28);
            this.btnListPnt.TabIndex = 4;
            this.btnListPnt.Text = "印刷";
            this.btnListPnt.Click += new System.EventHandler(this.btnListPnt_Click);
            // 
            // dwPnt
            // 
            //this.dwPnt.DataWindowObject = "d_cpllist";
            //this.dwPnt.LibraryList = "..\\CPLS\\cpls.cpl2010q01.pbd";
            //this.dwPnt.Location = new System.Drawing.Point(3, 5);
            //this.dwPnt.Name = "dwPnt";
            //this.dwPnt.Size = new System.Drawing.Size(74, 23);
            //this.dwPnt.TabIndex = 3;
            //this.dwPnt.Text = "xDataWindow1";
            //this.dwPnt.Visible = false;
            // 
            // btnMiResult
            // 
            this.btnMiResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiResult.Image = ((System.Drawing.Image)(resources.GetObject("btnMiResult.Image")));
            this.btnMiResult.Location = new System.Drawing.Point(509, 3);
            this.btnMiResult.Name = "btnMiResult";
            this.btnMiResult.Size = new System.Drawing.Size(80, 28);
            this.btnMiResult.TabIndex = 2;
            this.btnMiResult.Text = "未検査";
            this.btnMiResult.Visible = false;
            this.btnMiResult.Click += new System.EventHandler(this.btnMiResult_Click);
            // 
            // btnMiDochakPnt
            // 
            this.btnMiDochakPnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiDochakPnt.Image = ((System.Drawing.Image)(resources.GetObject("btnMiDochakPnt.Image")));
            this.btnMiDochakPnt.Location = new System.Drawing.Point(606, 3);
            this.btnMiDochakPnt.Name = "btnMiDochakPnt";
            this.btnMiDochakPnt.Size = new System.Drawing.Size(80, 28);
            this.btnMiDochakPnt.TabIndex = 1;
            this.btnMiDochakPnt.Text = "未到着";
            this.btnMiDochakPnt.Click += new System.EventHandler(this.btnMiDochakPnt_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(780, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel1.Location = new System.Drawing.Point(5, 60);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1028, 785);
            this.xPanel1.TabIndex = 0;
            // 
            // layMiDochak
            // 
            this.layMiDochak.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem34,
            this.multiLayoutItem38});
            this.layMiDochak.QuerySQL = resources.GetString("layMiDochak.QuerySQL");
            this.layMiDochak.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layMiDochak_QueryStarting);
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "bunho";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "order_date";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "in_out_gubun";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "gwa";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "doctor";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "doctor_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "jubsu_date";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "hangmog_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "gwa_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "part_jubsu_date";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "suname";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "specimen_ser";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "hangmog_code";
            // 
            // layMiGumsa
            // 
            this.layMiGumsa.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem36,
            this.multiLayoutItem37});
            this.layMiGumsa.QuerySQL = resources.GetString("layMiGumsa.QuerySQL");
            this.layMiGumsa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layMiGumsa_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "order_date";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "in_out_gubun";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "gwa";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "doctor";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "doctor_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "jubsu_date";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "gwa_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "part_jubsu_date";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "suname";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "specimen_ser";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "hangmog_code";
            // 
            // layLog
            // 
            this.layLog.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layLog.QuerySQL = resources.GetString("layLog.QuerySQL");
            this.layLog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layLog_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.txtLog;
            this.singleLayoutItem1.DataName = "txtLog";
            // 
            // layPntList
            // 
            this.layPntList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem33,
            this.multiLayoutItem35,
            this.multiLayoutItem39});
            this.layPntList.QuerySQL = resources.GetString("layPntList.QuerySQL");
            this.layPntList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPntList_QueryStarting);
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "bunho";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "order_date";
            this.multiLayoutItem24.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "in_out_gubun";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "gwa";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "doctor";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "doctor_name";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "jubsu_date";
            this.multiLayoutItem29.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "hangmog_name";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "gwa_name";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "part_jubsu_date";
            this.multiLayoutItem32.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "suname";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "specimen_ser";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "hangmog_code";
            // 
            // CPL2010Q01
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel6);
            this.Name = "CPL2010Q01";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1038, 850);
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPatientBox1)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).EndInit();
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layMiDochak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMiGumsa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPntList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.grdHangmog.SavePerformer = new XSavePerformer(this);
            this.SaveLayoutList.Add(this.grdHangmog);

            DateTime sysdate = EnvironInfo.GetSysDate();
            this.dtpFromDate.SetDataValue(sysdate.ToString("yyyy/MM/dd"));
            this.dtpToDate.SetDataValue(sysdate.ToString("yyyy/MM/dd"));
			this.cboJundalGubun.SetDataValue("%");
			QryList();
		}
		#endregion

		private void grdHangmog_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ( e.ColName == "order" )
			{
				//string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[0];
				}
			}
			else if ( e.ColName == "chehyul" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[1];
				}
			}
			else if ( e.ColName == "confirm" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[4];
				}
			}
			else if ( e.ColName == "part_jub" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[2];
				}
			}
			else if ( e.ColName == "result" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[3];
				}
			}
			else if ( e.ColName == "print" )
			{
                //string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[5];
				}
			}
		}

		private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			QryList();
		}

		private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			QryList();
		}

		private void cboJundalGubun_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			QryList();
		}

        private void xPatientBox1_PatientSelected(object sender, EventArgs e)
        {
            QryList();
        }

		#region 리스트 조회
		private void QryList()
		{
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.grdHangmog.QueryLayout(false);
            }
            catch { }
            finally 
            {
                this.Cursor = Cursors.Default;
            }

		}
		#endregion

		private void rbx_CheckedChanged(object sender, System.EventArgs e)
		{
			QryList();
		}

		private void btnMiDochakPnt_Click(object sender, System.EventArgs e)
		{
            //if ( this.layMiDochak.QueryLayout(true) )
            //{
            //    if (this.layMiDochak.RowCount == 0)
            //    {
            //        XMessageBox.Show("印刷するリストがありません。");
            //        return;
            //    }
            //    this.dwPnt.Reset();
            //    this.dwPnt.DataWindowObject = "d_cpllist";
            //    this.dwPnt.FillData(layMiDochak.LayoutTable);

            //    string text = "";

            //    text = "t_from_date.text = '" + dtpFromDate.Text + "'";
            //    dwPnt.Modify(text);
            //    text = "t_to_date.text = '" + dtpToDate.Text + "'";
            //    dwPnt.Modify(text);

            //    dwPnt.Refresh();

            //    this.dwPnt.Print();
            //}
		}

		private void btnMiResult_Click(object sender, System.EventArgs e)
		{
            //if ( this.layMiGumsa.QueryLayout(true) )
            //{
            //    if (this.layMiGumsa.RowCount == 0)
            //    {
            //        XMessageBox.Show("印刷するリストがありません。");
            //        return;
            //    }
            //    this.dwPnt.Reset();
            //    this.dwPnt.DataWindowObject = "d_cpllist2";
            //    this.dwPnt.FillData(layMiGumsa.LayoutTable);

            //    string text = "";

            //    text = "t_from_date.text = '" + dtpFromDate.Text + "'";
            //    dwPnt.Modify(text);
            //    text = "t_to_date.text = '" + dtpToDate.Text + "'";
            //    dwPnt.Modify(text);

            //    dwPnt.Refresh();

            //    this.dwPnt.Print();
            //}
		}

        private void btnListPnt_Click(object sender, EventArgs e)
        {
            //if (this.layPntList.QueryLayout(true))
            //{
            //    if (this.layPntList.RowCount == 0)
            //    {
            //        XMessageBox.Show("印刷するリストがありません。");
            //        return;
            //    }
            //    this.dwPnt.Reset();
            //    this.dwPnt.DataWindowObject = "d_cpllist3";
            //    this.dwPnt.FillData(layPntList.LayoutTable);

            //    string text = "";

            //    text = "t_from_date.text = '" + dtpFromDate.Text + "'";
            //    dwPnt.Modify(text);
            //    text = "t_to_date.text = '" + dtpToDate.Text + "'";
            //    dwPnt.Modify(text);

            //    dwPnt.Refresh();

            //    this.dwPnt.Print();
            //}
        }

		private void grdHangmog_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
            this.layLog.QueryLayout();
		}

        private void grdHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            //string dochack_yn = "";
            string after_yn = "";
            string result_yn = "";
            string inline_yn = "";

            //if (this.rbxAll.Checked == true)           dochack_yn = "0";
            //else if (this.rbxDochack.Checked == true)  dochack_yn = "1";
            //else                                       dochack_yn = "2";           
            
            if (this.rbxAll2.Checked == true)          after_yn = "0";
            else if (this.rbxTodayChk.Checked == true) after_yn = "1";
            else                                       after_yn = "2";


            if (this.rbxAll3.Checked == true)          result_yn = "0";
            else if (this.rbxResult.Checked == true)   result_yn = "1";
            else                                       result_yn = "2";

            if (this.rbxAll4.Checked == true)          inline_yn = "%";
            else if (this.rbxInline.Checked == true)   inline_yn = "IN";
            else                                       inline_yn = "BML";

            //if (dochack_yn == "0")
            //{
                //if (after_yn == "0")
                //{
                    /* 모든 내역을 다 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT
//                                                       A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//--                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//--                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , DECODE(C.RESULT_DATE,NULL,'N','Y')        RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE       
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//                else if (after_yn == "1")
//                {
//                    /* 나중에 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                       A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND (A.SPECIMEN_SER IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                    OR  A.SLIP_CODE     = '35S' ) -- 세포진
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//                else
//                {
//                    /* 당일 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                       A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND A.SPECIMEN_SER NOT IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                   AND A.SLIP_CODE     <> '35S' -- 세포진
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
            //}

            #region dochack_yn == "1"

//            else if (dochack_yn == "1")
//            {
//                if (after_yn == "0")
//                {
//                    /*  내역을 다 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                        A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND A.PART_JUBSU_DATE IS NOT NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//                else if (after_yn == "1")
//                {
//                    /* 나중에 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                        A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND A.PART_JUBSU_DATE IS NOT NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND (A.SPECIMEN_SER IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                    OR  A.SLIP_CODE     = '35S' ) -- 세포진
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//                else
//                {
//                    /* 당일 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                        A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND A.PART_JUBSU_DATE IS NOT NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND A.SPECIMEN_SER NOT IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                   AND A.SLIP_CODE     <> '35S' -- 세포진
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//            }
//            else/*미도착 항목들*/
//            {
//                if (after_yn == "0")
//                {
//                    /*  내역을 다 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                        A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND A.PART_JUBSU_DATE IS NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//                else if (after_yn == "1")
//                {
//                    /* 나중에 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                        A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND A.PART_JUBSU_DATE IS NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND (A.SPECIMEN_SER IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                    OR  A.SLIP_CODE     = '35S' ) -- 세포진
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//                else
//                {
//                    /* 당일 도착해야하는 항목들 모두 조회 */
//                    this.grdHangmog.QuerySQL = @"SELECT DISTINCT 
//                                                        A.ORDER_DATE
//                                                     , A.BUNHO
//                                                     , A.SUNAME
//                                                     , A.HANGMOG_CODE
//                                                     , B.GUMSA_NAME
//                                                     , 'Y'   ORDER_YN
//                                                     , DECODE(A.JUBSU_DATE,NULL,'N','Y')         CHEHYUL_YN
//                                                     , DECODE(A.PART_JUBSU_DATE,NULL,'N','Y')    GUM_JUB_YN
//                                                     , FN_CPL_LOAD_RESULT_YN(A.SPECIMEN_SER)     RESULT_YN
//                                                     , DECODE(A.RESULT_DATE,NULL,'N','Y')        CONFIRM_YN
//                                                     , NVL(A.DONER_YN,'N')                       PRINT_YN
//                                                     , C.CPL_RESULT
//                                                     , FN_BAS_LOAD_GWA_NAME(DECODE(A.IN_OUT_GUBUN,'I',A.HO_DONG,A.GWA),A.ORDER_DATE)  GWA_NAME
//                                                     , A.SPECIMEN_SER
//                                                     , A.ORDER_TIME                 
//                                                     , C.DISPLAY_YN
//                                                  FROM CPL3020 C
//                                                     , CPL0101 B
//                                                     , CPL2010 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND B.HOSP_CODE    = A.HOSP_CODE
//                                                   AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                   AND A.ORDER_DATE BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
//                                                   AND A.JUNDAL_GUBUN  LIKE :f_jundal_gubun
//                                                   AND A.BUNHO         LIKE :f_bunho||'%'
//                                                   AND DECODE(A.RESULT_DATE,NULL,'2','1') = DECODE(:f_result_yn,'0',DECODE(A.RESULT_DATE,NULL,'2','1'),:f_result_yn)
//                                                   AND A.PART_JUBSU_DATE IS NULL
//                                                   AND B.HANGMOG_CODE  = A.HANGMOG_CODE
//                                                   AND B.SPECIMEN_CODE = A.SPECIMEN_CODE
//                                                   AND B.EMERGENCY     = A.EMERGENCY
//                                                   AND NVL(B.UITAK_CODE,'IN') LIKE :f_inline_yn
//                                                   AND A.SPECIMEN_SER NOT IN ('19','21','94','59') -- 나중에 도착하는 검체
//                                                   AND A.SLIP_CODE     <> '35S' -- 세포진
//                                                   AND C.SPECIMEN_SER(+)    = A.SPECIMEN_SER
//                                                   AND C.HANGMOG_CODE(+) = A.HANGMOG_CODE
//                                                 ORDER BY A.SPECIMEN_SER DESC";
//                }
//            }

                #endregion dochack_yn == "1"

            this.grdHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHangmog.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_jundal_gubun", cboJundalGubun.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_bunho", this.xPatientBox1.BunHo);
            this.grdHangmog.SetBindVarValue("f_result_yn", result_yn);
            this.grdHangmog.SetBindVarValue("f_inline_yn", inline_yn);
            this.grdHangmog.SetBindVarValue("f_after_yn", after_yn);
        }

        private void layMiDochak_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layMiDochak.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layMiDochak.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.layMiDochak.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.layMiDochak.SetBindVarValue("f_jundal_gubun", cboJundalGubun.GetDataValue());

            string inline_yn = "";

            if (this.rbxAll4.Checked == true) inline_yn = "%";
            else if (this.rbxInline.Checked == true) inline_yn = "IN";
            else inline_yn = "BML";

            this.layMiDochak.SetBindVarValue("f_inline_yn", inline_yn);
        }
        
        private void layMiGumsa_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layMiGumsa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layMiGumsa.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.layMiGumsa.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.layMiGumsa.SetBindVarValue("f_jundal_gubun", cboJundalGubun.GetDataValue());

            string inline_yn = "";

            if (this.rbxAll4.Checked == true) inline_yn = "%";
            else if (this.rbxInline.Checked == true) inline_yn = "IN";
            else inline_yn = "BML";

            this.layMiGumsa.SetBindVarValue("f_inline_yn", inline_yn);

        }

        private void layLog_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layLog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layLog.SetBindVarValue("f_specimen_ser", this.grdHangmog.GetItemString(this.grdHangmog.CurrentRowNumber, "specimen_ser"));
            this.layLog.SetBindVarValue("f_hangmog_code", this.grdHangmog.GetItemString(this.grdHangmog.CurrentRowNumber, "hangmog_code"));
        }


        #region XSavePerformer

        private class XSavePerformer : ISavePerformer
        {
            CPL2010Q01 parent;

            public XSavePerformer(CPL2010Q01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                cmdText = @"UPDATE CPL3020
                               SET DISPLAY_YN   = :f_dp_yn
                             WHERE HOSP_CODE    = :f_hosp_code 
                               AND SPECIMEN_SER = :f_specimen_ser";

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion

        private void layPntList_QueryStarting(object sender, CancelEventArgs e)
        {

            string result_yn = "";
            string inline_yn = "";

            if (this.rbxAll3.Checked == true) result_yn = "0";
            else if (this.rbxResult.Checked == true) result_yn = "1";
            else result_yn = "2";

            if (this.rbxAll4.Checked == true) inline_yn = "%";
            else if (this.rbxInline.Checked == true) inline_yn = "IN";
            else inline_yn = "BML";
            
            this.layPntList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layPntList.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.layPntList.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.layPntList.SetBindVarValue("f_jundal_gubun", cboJundalGubun.GetDataValue());
            this.layPntList.SetBindVarValue("f_bunho", this.xPatientBox1.BunHo);
            this.layPntList.SetBindVarValue("f_result_yn", result_yn);
            this.layPntList.SetBindVarValue("f_inline_yn", inline_yn);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    QryList();
                    break;
            }
        }

    }
}

