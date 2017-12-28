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
	/// NUR1014U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1014U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string close_yn = "N";
		#endregion

		#region 자동생성
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDatePicker dtpOut_date;
		private IHIS.Framework.XEditMask edtOut_time;
		private IHIS.Framework.XDatePicker dtpNut_start_date;
		private IHIS.Framework.XLabel lblOut_time;
		private IHIS.Framework.XLabel lblIn_hope_time;
		private IHIS.Framework.XEditMask edtIn_hope_time;
		private IHIS.Framework.XDatePicker dtpIn_hope_date;
		private IHIS.Framework.XDatePicker dtpNut_end_date;
		private IHIS.Framework.XLabel lblNut_end;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XEditMask edtIn_true_time;
		private IHIS.Framework.XLabel lblIn_true_time;
		private IHIS.Framework.XDatePicker dtpIn_true_date;
		private IHIS.Framework.XLabel lblIn_true_date;
		private IHIS.Framework.XComboBox cboOut_object;
		private IHIS.Framework.XLabel lblOut_object;
		private IHIS.Framework.XEditGrid grdNur1014;
		private IHIS.Framework.XComboBox cboNut_end_kini;
		private IHIS.Framework.XComboBox cboNut_start_kini;
		private IHIS.Framework.XLabel lblIn_hope_date;
		private IHIS.Framework.XLabel lblNut_start_date;
		private IHIS.Framework.XLabel lblOut_date;
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
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XTextBox txtFkinp1001;
		private IHIS.Framework.SingleLayout layFkinp1001;
		private IHIS.Framework.XPanel pnlFillFill;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XComboItem xComboItem5;
		private IHIS.Framework.XComboItem xComboItem6;
		private IHIS.Framework.MultiLayout layComboSet;
		private IHIS.Framework.SingleLayout layValidationChk;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XRadioButton rbxWoichul;
        private IHIS.Framework.XRadioButton rbxWoibak;
        private IHIS.Framework.SingleLayout layCheck_order;
		private IHIS.Framework.XLabel xLabel1;
        private SingleLayoutItem singleLayoutItem1;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XButton btnRePrint;
        private SingleLayout layLoadDocNur;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem20;
        private SingleLayoutItem singleLayoutItem21;
        private XDataWindow dwPrint;
        private MultiLayout layPrint;
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
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private XCheckBox cbxNut_end_yn;
        private XEditGridCell xEditGridCell15;
        private XLabel xLabel2;
        private XLabel xLabel5;
        private XTextBox txtDestTel;
        private XLabel xLabel4;
        private XLabel xLabel3;
        private XTextBox txtDestAddr;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XCheckBox cbxisHome;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1014U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1014U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnRePrint = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dtpOut_date = new IHIS.Framework.XDatePicker();
            this.edtOut_time = new IHIS.Framework.XEditMask();
            this.dtpNut_start_date = new IHIS.Framework.XDatePicker();
            this.lblOut_time = new IHIS.Framework.XLabel();
            this.lblIn_hope_time = new IHIS.Framework.XLabel();
            this.edtIn_hope_time = new IHIS.Framework.XEditMask();
            this.dtpIn_hope_date = new IHIS.Framework.XDatePicker();
            this.dtpNut_end_date = new IHIS.Framework.XDatePicker();
            this.lblNut_end = new IHIS.Framework.XLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlFillFill = new IHIS.Framework.XPanel();
            this.cbxisHome = new IHIS.Framework.XCheckBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.txtDestTel = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.rbxWoibak = new IHIS.Framework.XRadioButton();
            this.rbxWoichul = new IHIS.Framework.XRadioButton();
            this.cboNut_end_kini = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.lblIn_true_time = new IHIS.Framework.XLabel();
            this.lblOut_object = new IHIS.Framework.XLabel();
            this.cboOut_object = new IHIS.Framework.XComboBox();
            this.lblIn_true_date = new IHIS.Framework.XLabel();
            this.dtpIn_true_date = new IHIS.Framework.XDatePicker();
            this.edtIn_true_time = new IHIS.Framework.XEditMask();
            this.cbxNut_end_yn = new IHIS.Framework.XCheckBox();
            this.lblOut_date = new IHIS.Framework.XLabel();
            this.lblNut_start_date = new IHIS.Framework.XLabel();
            this.lblIn_hope_date = new IHIS.Framework.XLabel();
            this.cboNut_start_kini = new IHIS.Framework.XComboBox();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dwPrint = new IHIS.Framework.XDataWindow();
            this.txtDestAddr = new IHIS.Framework.XTextBox();
            this.grdNur1014 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.layFkinp1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layComboSet = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layValidationChk = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layCheck_order = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.layLoadDocNur = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem20 = new IHIS.Framework.SingleLayoutItem();
            this.layPrint = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnlFillFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1014)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "출력.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.txtFkinp1001);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(654, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // txtFkinp1001
            // 
            this.txtFkinp1001.Location = new System.Drawing.Point(406, 6);
            this.txtFkinp1001.Name = "txtFkinp1001";
            this.txtFkinp1001.Size = new System.Drawing.Size(80, 20);
            this.txtFkinp1001.TabIndex = 2;
            this.txtFkinp1001.Visible = false;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(654, 32);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRePrint);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 336);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(654, 34);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnRePrint
            // 
            this.btnRePrint.ImageIndex = 1;
            this.btnRePrint.ImageList = this.ImageList;
            this.btnRePrint.Location = new System.Drawing.Point(4, 4);
            this.btnRePrint.Name = "btnRePrint";
            this.btnRePrint.Size = new System.Drawing.Size(135, 26);
            this.btnRePrint.TabIndex = 44;
            this.btnRePrint.Text = "許可申請書再発行";
            this.btnRePrint.Click += new System.EventHandler(this.btnRePrint_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(167, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dtpOut_date
            // 
            this.dtpOut_date.IsJapanYearType = true;
            this.dtpOut_date.Location = new System.Drawing.Point(161, 40);
            this.dtpOut_date.Name = "dtpOut_date";
            this.dtpOut_date.Size = new System.Drawing.Size(122, 20);
            this.dtpOut_date.TabIndex = 1;
            this.dtpOut_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpOut_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpOut_date_DataValidating);
            // 
            // edtOut_time
            // 
            this.edtOut_time.EditMaskType = IHIS.Framework.MaskType.Time;
            this.edtOut_time.Location = new System.Drawing.Point(283, 40);
            this.edtOut_time.Mask = "HH:MI";
            this.edtOut_time.Name = "edtOut_time";
            this.edtOut_time.Size = new System.Drawing.Size(70, 20);
            this.edtOut_time.TabIndex = 2;
            this.edtOut_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.edtOut_time.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.edtOut_time_DataValidating);
            // 
            // dtpNut_start_date
            // 
            this.dtpNut_start_date.IsJapanYearType = true;
            this.dtpNut_start_date.Location = new System.Drawing.Point(161, 96);
            this.dtpNut_start_date.Name = "dtpNut_start_date";
            this.dtpNut_start_date.Size = new System.Drawing.Size(122, 20);
            this.dtpNut_start_date.TabIndex = 2;
            this.dtpNut_start_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOut_time
            // 
            this.lblOut_time.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblOut_time.EdgeRounding = false;
            this.lblOut_time.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblOut_time.Location = new System.Drawing.Point(353, 40);
            this.lblOut_time.Name = "lblOut_time";
            this.lblOut_time.Size = new System.Drawing.Size(30, 20);
            this.lblOut_time.TabIndex = 7;
            this.lblOut_time.Text = "時";
            this.lblOut_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIn_hope_time
            // 
            this.lblIn_hope_time.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblIn_hope_time.EdgeRounding = false;
            this.lblIn_hope_time.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblIn_hope_time.Location = new System.Drawing.Point(353, 68);
            this.lblIn_hope_time.Name = "lblIn_hope_time";
            this.lblIn_hope_time.Size = new System.Drawing.Size(30, 20);
            this.lblIn_hope_time.TabIndex = 10;
            this.lblIn_hope_time.Text = "時";
            this.lblIn_hope_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // edtIn_hope_time
            // 
            this.edtIn_hope_time.EditMaskType = IHIS.Framework.MaskType.Time;
            this.edtIn_hope_time.Location = new System.Drawing.Point(283, 68);
            this.edtIn_hope_time.Mask = "HH:MI";
            this.edtIn_hope_time.Name = "edtIn_hope_time";
            this.edtIn_hope_time.Size = new System.Drawing.Size(70, 20);
            this.edtIn_hope_time.TabIndex = 4;
            this.edtIn_hope_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpIn_hope_date
            // 
            this.dtpIn_hope_date.IsJapanYearType = true;
            this.dtpIn_hope_date.Location = new System.Drawing.Point(161, 68);
            this.dtpIn_hope_date.Name = "dtpIn_hope_date";
            this.dtpIn_hope_date.Size = new System.Drawing.Size(122, 20);
            this.dtpIn_hope_date.TabIndex = 3;
            this.dtpIn_hope_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpIn_hope_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpIn_hope_date_DataValidating);
            // 
            // dtpNut_end_date
            // 
            this.dtpNut_end_date.IsJapanYearType = true;
            this.dtpNut_end_date.Location = new System.Drawing.Point(161, 134);
            this.dtpNut_end_date.Name = "dtpNut_end_date";
            this.dtpNut_end_date.Size = new System.Drawing.Size(122, 20);
            this.dtpNut_end_date.TabIndex = 11;
            this.dtpNut_end_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNut_end
            // 
            this.lblNut_end.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNut_end.EdgeRounding = false;
            this.lblNut_end.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNut_end.Location = new System.Drawing.Point(353, 134);
            this.lblNut_end.Name = "lblNut_end";
            this.lblNut_end.Size = new System.Drawing.Size(68, 21);
            this.lblNut_end.TabIndex = 16;
            this.lblNut_end.Text = "まで食止";
            this.lblNut_end.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlFillFill);
            this.pnlFill.Controls.Add(this.grdNur1014);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 36);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(654, 300);
            this.pnlFill.TabIndex = 2;
            // 
            // pnlFillFill
            // 
            this.pnlFillFill.Controls.Add(this.cbxisHome);
            this.pnlFillFill.Controls.Add(this.xLabel5);
            this.pnlFillFill.Controls.Add(this.txtDestTel);
            this.pnlFillFill.Controls.Add(this.xLabel4);
            this.pnlFillFill.Controls.Add(this.xLabel3);
            this.pnlFillFill.Controls.Add(this.xLabel2);
            this.pnlFillFill.Controls.Add(this.rbxWoibak);
            this.pnlFillFill.Controls.Add(this.rbxWoichul);
            this.pnlFillFill.Controls.Add(this.cboNut_end_kini);
            this.pnlFillFill.Controls.Add(this.dtpOut_date);
            this.pnlFillFill.Controls.Add(this.lblOut_time);
            this.pnlFillFill.Controls.Add(this.lblIn_hope_time);
            this.pnlFillFill.Controls.Add(this.lblIn_true_time);
            this.pnlFillFill.Controls.Add(this.lblOut_object);
            this.pnlFillFill.Controls.Add(this.cboOut_object);
            this.pnlFillFill.Controls.Add(this.lblIn_true_date);
            this.pnlFillFill.Controls.Add(this.dtpIn_true_date);
            this.pnlFillFill.Controls.Add(this.edtIn_true_time);
            this.pnlFillFill.Controls.Add(this.lblNut_end);
            this.pnlFillFill.Controls.Add(this.cbxNut_end_yn);
            this.pnlFillFill.Controls.Add(this.dtpNut_end_date);
            this.pnlFillFill.Controls.Add(this.dtpIn_hope_date);
            this.pnlFillFill.Controls.Add(this.edtIn_hope_time);
            this.pnlFillFill.Controls.Add(this.lblOut_date);
            this.pnlFillFill.Controls.Add(this.lblNut_start_date);
            this.pnlFillFill.Controls.Add(this.lblIn_hope_date);
            this.pnlFillFill.Controls.Add(this.dtpNut_start_date);
            this.pnlFillFill.Controls.Add(this.edtOut_time);
            this.pnlFillFill.Controls.Add(this.cboNut_start_kini);
            this.pnlFillFill.Controls.Add(this.xLabel1);
            this.pnlFillFill.Controls.Add(this.dwPrint);
            this.pnlFillFill.Controls.Add(this.txtDestAddr);
            this.pnlFillFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillFill.Location = new System.Drawing.Point(223, 0);
            this.pnlFillFill.Name = "pnlFillFill";
            this.pnlFillFill.Size = new System.Drawing.Size(431, 300);
            this.pnlFillFill.TabIndex = 37;
            // 
            // cbxisHome
            // 
            this.cbxisHome.Location = new System.Drawing.Point(167, 165);
            this.cbxisHome.Name = "cbxisHome";
            this.cbxisHome.Size = new System.Drawing.Size(70, 20);
            this.cbxisHome.TabIndex = 52;
            this.cbxisHome.Text = "自宅";
            this.cbxisHome.UseVisualStyleBackColor = false;
            this.cbxisHome.CheckedChanged += new System.EventHandler(this.cbxisHome_CheckedChanged);
            // 
            // xLabel5
            // 
            this.xLabel5.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel5.Location = new System.Drawing.Point(17, 250);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(366, 19);
            this.xLabel5.TabIndex = 51;
            this.xLabel5.Text = "※　実際帰室した後で入力してください。";
            // 
            // txtDestTel
            // 
            this.txtDestTel.Location = new System.Drawing.Point(167, 215);
            this.txtDestTel.Name = "txtDestTel";
            this.txtDestTel.Size = new System.Drawing.Size(254, 20);
            this.txtDestTel.TabIndex = 50;
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Location = new System.Drawing.Point(85, 214);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(77, 20);
            this.xLabel4.TabIndex = 48;
            this.xLabel4.Text = "連絡先";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(85, 191);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(77, 20);
            this.xLabel3.TabIndex = 47;
            this.xLabel3.Text = "住所";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(17, 163);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(144, 20);
            this.xLabel2.TabIndex = 45;
            this.xLabel2.Text = "目的地";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbxWoibak
            // 
            this.rbxWoibak.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxWoibak.Location = new System.Drawing.Point(465, 296);
            this.rbxWoibak.Name = "rbxWoibak";
            this.rbxWoibak.Size = new System.Drawing.Size(52, 24);
            this.rbxWoibak.TabIndex = 38;
            this.rbxWoibak.Text = "外泊";
            this.rbxWoibak.UseVisualStyleBackColor = false;
            this.rbxWoibak.Visible = false;
            // 
            // rbxWoichul
            // 
            this.rbxWoichul.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbxWoichul.Location = new System.Drawing.Point(408, 296);
            this.rbxWoichul.Name = "rbxWoichul";
            this.rbxWoichul.Size = new System.Drawing.Size(54, 24);
            this.rbxWoichul.TabIndex = 37;
            this.rbxWoichul.Text = "外出";
            this.rbxWoichul.UseVisualStyleBackColor = false;
            this.rbxWoichul.Visible = false;
            this.rbxWoichul.CheckedChanged += new System.EventHandler(this.rbxWoichul_CheckedChanged);
            // 
            // cboNut_end_kini
            // 
            this.cboNut_end_kini.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboNut_end_kini.Location = new System.Drawing.Point(283, 134);
            this.cboNut_end_kini.Name = "cboNut_end_kini";
            this.cboNut_end_kini.Size = new System.Drawing.Size(70, 21);
            this.cboNut_end_kini.TabIndex = 25;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "朝";
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "昼";
            this.xComboItem2.ValueItem = "2";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "夕";
            this.xComboItem3.ValueItem = "3";
            // 
            // lblIn_true_time
            // 
            this.lblIn_true_time.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblIn_true_time.EdgeRounding = false;
            this.lblIn_true_time.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblIn_true_time.Location = new System.Drawing.Point(353, 269);
            this.lblIn_true_time.Name = "lblIn_true_time";
            this.lblIn_true_time.Size = new System.Drawing.Size(30, 20);
            this.lblIn_true_time.TabIndex = 36;
            this.lblIn_true_time.Text = "時";
            this.lblIn_true_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOut_object
            // 
            this.lblOut_object.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblOut_object.EdgeRounding = false;
            this.lblOut_object.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblOut_object.Location = new System.Drawing.Point(17, 12);
            this.lblOut_object.Name = "lblOut_object";
            this.lblOut_object.Size = new System.Drawing.Size(144, 21);
            this.lblOut_object.TabIndex = 31;
            this.lblOut_object.Text = "外出 ·外泊目的";
            this.lblOut_object.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboOut_object
            // 
            this.cboOut_object.Location = new System.Drawing.Point(161, 12);
            this.cboOut_object.MaxDropDownItems = 50;
            this.cboOut_object.Name = "cboOut_object";
            this.cboOut_object.Size = new System.Drawing.Size(182, 21);
            this.cboOut_object.TabIndex = 0;
            // 
            // lblIn_true_date
            // 
            this.lblIn_true_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblIn_true_date.EdgeRounding = false;
            this.lblIn_true_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblIn_true_date.Location = new System.Drawing.Point(17, 269);
            this.lblIn_true_date.Name = "lblIn_true_date";
            this.lblIn_true_date.Size = new System.Drawing.Size(144, 20);
            this.lblIn_true_date.TabIndex = 33;
            this.lblIn_true_date.Text = "帰室日時";
            this.lblIn_true_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpIn_true_date
            // 
            this.dtpIn_true_date.IsJapanYearType = true;
            this.dtpIn_true_date.Location = new System.Drawing.Point(161, 269);
            this.dtpIn_true_date.Name = "dtpIn_true_date";
            this.dtpIn_true_date.Size = new System.Drawing.Size(122, 20);
            this.dtpIn_true_date.TabIndex = 5;
            this.dtpIn_true_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpIn_true_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpIn_true_date_DataValidating);
            // 
            // edtIn_true_time
            // 
            this.edtIn_true_time.EditMaskType = IHIS.Framework.MaskType.Time;
            this.edtIn_true_time.Location = new System.Drawing.Point(283, 269);
            this.edtIn_true_time.Mask = "HH:MI";
            this.edtIn_true_time.Name = "edtIn_true_time";
            this.edtIn_true_time.Size = new System.Drawing.Size(70, 20);
            this.edtIn_true_time.TabIndex = 6;
            this.edtIn_true_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxNut_end_yn
            // 
            this.cbxNut_end_yn.Location = new System.Drawing.Point(85, 134);
            this.cbxNut_end_yn.Name = "cbxNut_end_yn";
            this.cbxNut_end_yn.Size = new System.Drawing.Size(70, 20);
            this.cbxNut_end_yn.TabIndex = 15;
            this.cbxNut_end_yn.Text = "食止なし";
            this.cbxNut_end_yn.UseVisualStyleBackColor = false;
            this.cbxNut_end_yn.CheckedChanged += new System.EventHandler(this.cbxNut_end_yn_CheckedChanged);
            // 
            // lblOut_date
            // 
            this.lblOut_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblOut_date.EdgeRounding = false;
            this.lblOut_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblOut_date.Location = new System.Drawing.Point(17, 40);
            this.lblOut_date.Name = "lblOut_date";
            this.lblOut_date.Size = new System.Drawing.Size(144, 20);
            this.lblOut_date.TabIndex = 20;
            this.lblOut_date.Text = "開始予定日時";
            this.lblOut_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNut_start_date
            // 
            this.lblNut_start_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNut_start_date.EdgeRounding = false;
            this.lblNut_start_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNut_start_date.Location = new System.Drawing.Point(17, 96);
            this.lblNut_start_date.Name = "lblNut_start_date";
            this.lblNut_start_date.Size = new System.Drawing.Size(144, 20);
            this.lblNut_start_date.TabIndex = 21;
            this.lblNut_start_date.Text = "食事中止期間";
            this.lblNut_start_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIn_hope_date
            // 
            this.lblIn_hope_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblIn_hope_date.EdgeRounding = false;
            this.lblIn_hope_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblIn_hope_date.Location = new System.Drawing.Point(17, 68);
            this.lblIn_hope_date.Name = "lblIn_hope_date";
            this.lblIn_hope_date.Size = new System.Drawing.Size(144, 20);
            this.lblIn_hope_date.TabIndex = 22;
            this.lblIn_hope_date.Text = "終了予定日時";
            this.lblIn_hope_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboNut_start_kini
            // 
            this.cboNut_start_kini.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6});
            this.cboNut_start_kini.Location = new System.Drawing.Point(283, 96);
            this.cboNut_start_kini.Name = "cboNut_start_kini";
            this.cboNut_start_kini.Size = new System.Drawing.Size(70, 21);
            this.cboNut_start_kini.TabIndex = 24;
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "朝";
            this.xComboItem4.ValueItem = "1";
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "昼";
            this.xComboItem5.ValueItem = "2";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "夕";
            this.xComboItem6.ValueItem = "3";
            // 
            // xLabel1
            // 
            this.xLabel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xLabel1.Image")));
            this.xLabel1.Location = new System.Drawing.Point(203, 114);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(32, 18);
            this.xLabel1.TabIndex = 43;
            // 
            // dwPrint
            // 
            this.dwPrint.DataWindowObject = "dw_hospital";
            this.dwPrint.LibraryList = "..\\NURI\\nuri.nur1014u00.pbd";
            this.dwPrint.Location = new System.Drawing.Point(612, 290);
            this.dwPrint.Name = "dwPrint";
            this.dwPrint.Size = new System.Drawing.Size(166, 34);
            this.dwPrint.TabIndex = 44;
            this.dwPrint.Text = "xDataWindow1";
            this.dwPrint.Visible = false;
            // 
            // txtDestAddr
            // 
            this.txtDestAddr.Location = new System.Drawing.Point(167, 191);
            this.txtDestAddr.Name = "txtDestAddr";
            this.txtDestAddr.Size = new System.Drawing.Size(254, 20);
            this.txtDestAddr.TabIndex = 49;
            // 
            // grdNur1014
            // 
            this.grdNur1014.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell1,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18});
            this.grdNur1014.ColPerLine = 2;
            this.grdNur1014.Cols = 3;
            this.grdNur1014.ControlBinding = true;
            this.grdNur1014.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdNur1014.FixedCols = 1;
            this.grdNur1014.FixedRows = 1;
            this.grdNur1014.HeaderHeights.Add(21);
            this.grdNur1014.Location = new System.Drawing.Point(0, 0);
            this.grdNur1014.Name = "grdNur1014";
            this.grdNur1014.QuerySQL = resources.GetString("grdNur1014.QuerySQL");
            this.grdNur1014.ReadOnly = true;
            this.grdNur1014.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdNur1014.RowHeaderVisible = true;
            this.grdNur1014.Rows = 2;
            this.grdNur1014.Size = new System.Drawing.Size(223, 300);
            this.grdNur1014.TabIndex = 30;
            this.grdNur1014.TabStop = false;
            this.grdNur1014.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNur1014_QueryStarting);
            this.grdNur1014.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNur1014_SaveEnd);
            this.grdNur1014.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNur1014_RowFocusChanged);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "bunho";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "fkinp1001";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "fkinp1001";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.BindControl = this.dtpOut_date;
            this.xEditGridCell1.CellName = "out_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 135;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "外出 ·外泊日";
            this.xEditGridCell1.IsJapanYearType = true;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.edtOut_time;
            this.xEditGridCell4.CellName = "out_time";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "out_time";
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.dtpIn_hope_date;
            this.xEditGridCell5.CellName = "in_hope_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "in_hope_date";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.edtIn_hope_time;
            this.xEditGridCell6.CellName = "in_hope_time";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "in_hope_time";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.dtpIn_true_date;
            this.xEditGridCell7.CellName = "in_true_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "in_true_date";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.edtIn_true_time;
            this.xEditGridCell8.CellName = "in_true_time";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "in_true_time";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.BindControl = this.dtpNut_start_date;
            this.xEditGridCell9.CellName = "nut_start_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "nut_start_date";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.cboNut_start_kini;
            this.xEditGridCell10.CellName = "nut_start_kini";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "nut_start_kini";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.dtpNut_end_date;
            this.xEditGridCell11.CellName = "nut_end_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "nut_end_date";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.cboNut_end_kini;
            this.xEditGridCell12.CellName = "nut_end_kini";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "nut_end_kini";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.cboOut_object;
            this.xEditGridCell13.CellName = "out_object";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "out_object";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "flag";
            this.xEditGridCell14.CellWidth = 40;
            this.xEditGridCell14.Col = 2;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "区分";
            this.xEditGridCell14.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell14.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'WOICHUL_WOPIBAK_GUBUN\'";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.BindControl = this.cbxNut_end_yn;
            this.xEditGridCell15.CellName = "nut_end_yn";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "nut_end_yn";
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.cbxisHome;
            this.xEditGridCell16.CellName = "dest_ishome";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "dest_ishome";
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.BindControl = this.txtDestAddr;
            this.xEditGridCell17.CellName = "dest_addr";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "dest_addr";
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.txtDestTel;
            this.xEditGridCell18.CellName = "dest_tel";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "dest_tel";
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // layFkinp1001
            // 
            this.layFkinp1001.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layFkinp1001.QuerySQL = "SELECT PKINP1001\r\n  FROM VW_OCS_INP1001_01\r\n WHERE HOSP_CODE            = :f_hosp" +
                "_code \r\n   AND BUNHO                = :f_bunho\r\n   AND NVL(CANCEL_YN,\'N\')   = \'N" +
                "\'\r\n   AND NVL(JAEWON_FLAG,\'N\') = \'Y\'";
            this.layFkinp1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layFkinp1001_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.txtFkinp1001;
            this.singleLayoutItem1.DataName = "fkinp1001";
            // 
            // layComboSet
            // 
            this.layComboSet.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboSet.QuerySQL = "SELECT CODE      CODE,\r\n       CODE_NAME CODE_NAME,\r\n       SORT_KEY\r\n  FROM NUR0" +
                "102\r\n WHERE HOSP_CODE = :f_hosp_code \r\n   AND CODE_TYPE = :f_code_type\r\n ORDER B" +
                "Y 1, 3";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // layValidationChk
            // 
            this.layValidationChk.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layValidationChk.QuerySQL = resources.GetString("layValidationChk.QuerySQL");
            this.layValidationChk.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layValidationChk_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "YorN";
            // 
            // layCheck_order
            // 
            this.layCheck_order.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem3});
            this.layCheck_order.QuerySQL = resources.GetString("layCheck_order.QuerySQL");
            this.layCheck_order.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCheck_order_QueryStarting);
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "check_order";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "bunho";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.DataName = "out_date";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "out_time";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.DataName = "in_hope_date";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.DataName = "in_hope_time";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.DataName = "in_true_date";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.DataName = "in_true_time";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.DataName = "nut_start_date";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.DataName = "nut_start_kini";
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.DataName = "nut_end_date";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.DataName = "nut_end_kini";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.DataName = "doctor";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.DataName = "nurse";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.DataName = "ho_code";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.DataName = "out_object";
            // 
            // layLoadDocNur
            // 
            this.layLoadDocNur.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem20});
            this.layLoadDocNur.QuerySQL = resources.GetString("layLoadDocNur.QuerySQL");
            this.layLoadDocNur.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layLoadDocNur_QueryStarting);
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "doctor";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "nurse";
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.DataName = "ho_code";
            // 
            // layPrint
            // 
            this.layPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18});
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bunho";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "out_date";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "out_time";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "in_hope_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "in_hope_time";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "in_true_date";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "in_true_time";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "out_object";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "nut_start_date";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "nut_start_kini";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "nut_end_date";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "nut_end_kini";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "doctor";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "nurse";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "ho_code";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "flag";
            // 
            // NUR1014U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1014U00";
            this.Size = new System.Drawing.Size(654, 370);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFillFill.ResumeLayout(false);
            this.pnlFillFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNur1014)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layComboSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrint)).EndInit();
            this.ResumeLayout(false);

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
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + " 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bunho":
					msg = (NetInfo.Language == LangMode.Ko ? " 환자번호를 확인해 주세요"
						: "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "query":
					msg = (NetInfo.Language == LangMode.Ko ? "조회실패."
						: "照会失敗。");
					caption = (NetInfo.Language == LangMode.Ko ? "Error"
						: "エラー");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "woichul_gubun":
					msg = (NetInfo.Language == LangMode.Ko ? "외출외박구분을 선택해주세요."
						: "外出外泊区分を選択してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "out_date":
					msg = (NetInfo.Language == LangMode.Ko ? "외출외박개시일자를 확인해 주세요"
						: "外出·外泊開始日時を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "out_date_check":
					msg = (NetInfo.Language == LangMode.Ko ? "기존에 등록된 외출 외박일자를 확인해 주세요."
						: "既に登録されている外出·外泊の日時と重なります。ご確認ください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "in_hope_date":
					msg = (NetInfo.Language == LangMode.Ko ? "외출외박종료일자를 확인해 주세요"
						: "外出·外泊終了日時を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "in_hope_time":
					msg = (NetInfo.Language == LangMode.Ko ? "외출외박종료시간을 확인해 주세요"
						: "外出·外泊終了時間を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "in_true_date":
					msg = (NetInfo.Language == LangMode.Ko ? "귀실일자를 확인해 주세요"
						: "帰室日付を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
                case "in_true_time":
                    msg = (NetInfo.Language == LangMode.Ko ? "귀실시간 확인해 주세요"
                        : "帰室時間を確認してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
				case "out_time":
					msg = (NetInfo.Language == LangMode.Ko ? "외출외박시간을 확인해 주세요"
						: "外出·外泊開始時間を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
                case "nut_start_date":
                    msg = (NetInfo.Language == LangMode.Ko ? "식사중지의 시작 날짜를 확인해 주세요"
                        : "食止めの開始日を確認してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "nut_end_date":
                    msg = (NetInfo.Language == LangMode.Ko ? "식사중지의 종료 날짜를 확인해 주세요"
                        : "食止めの終了日を確認してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "nut_start_kini":
                    msg = (NetInfo.Language == LangMode.Ko ? "식사중지의 시작 끼니를 확인해 주세요"
                        : "何食から止めるか確認してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "nut_end_kini":
                    msg = (NetInfo.Language == LangMode.Ko ? "식사 중지의 종료 끼니를 확인해 주세요"
                        : "何食まで止めるか確認してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;

				case "tel":
					msg = (NetInfo.Language == LangMode.Ko ? "과거일자로 외출, 외박을 등록을 할 경우에는" + "\r\n" + " 입원의사회계로 연락을 하셔야합니다."
						: "過去日付で外出、外泊を登録する場合は、" + "\r\n" + " 入院事務に連絡してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nut_start_info":
					msg = (NetInfo.Language == LangMode.Ko ? "금식시작정보를 입력해 주세요."
						: "食止開始を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nut_end_info":
					msg = (NetInfo.Language == LangMode.Ko ? "금식종료정보를 입력해 주세요."
						: "食止終了を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
                case "nut_info_error":
                    msg = (NetInfo.Language == LangMode.Ko ? "금식정보를 확인해주세요."
                        : "食止め情報を確認してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
				case "check_order":
					msg = (NetInfo.Language == LangMode.Ko ? "외박기간중에 실시를 해야 하는 오다가 존재 합니다."
						: "外泊期間中に実施予定のオーダがあります。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存が完了しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。";
					msg += "\r\n" + Service.ErrFullMsg;
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		// <summary>
		/// 수술예약 등록 콤보박스 셋팅
		/// </summary>
		/// <param name="aComboGubun">
		/// 콤보구분
		/// </param>
		#region 콤보박스 셋팅
		private void GetComboSetting(string aComboGubun)
        {
            this.layComboSet.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.layComboSet.SetBindVarValue("f_code_type", aComboGubun);

			if(this.layComboSet.QueryLayout(true))
			{
				switch(aComboGubun)
				{
					case "OUT_OBJECT":
						if(this.layComboSet.LayoutTable.Rows.Count > 0)
						{
							this.cboOut_object.SetComboItems(this.layComboSet.LayoutTable, "code_name", "code");
						}
						break;
					default:
						break;
				}
			}
			else
            {

                if (Service.ErrFullMsg != "")
                {
                    XMessageBox.Show(Service.ErrFullMsg.ToString());
                    return;
                }
			}
		}
		#endregion


		#region 스크린 로드
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            this.grdNur1014.SavePerformer = new XSavePerformer(this);

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{

			if(EnvironInfo.CurrSystemID != "NURI")
			{
				this.pnlFillFill.Enabled = false;
			}
			else
			{
				this.pnlFillFill.Enabled = true;
			}

			this.GetComboSetting("OUT_OBJECT");

            this.dtpOut_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpOut_date.AcceptData();

            this.dtpIn_hope_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpIn_hope_date.AcceptData();

//			this.dtpIn_true_date.SetEditValue(EnvironInfo.GetSysDate().AddDays(1).ToString());
//			this.dtpIn_true_date.AcceptData();
	
			this.CurrMSLayout = this.grdNur1014;
			this.CurrMQLayout = this.grdNur1014;

			if (this.OpenParam != null)
			{
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
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

		/// <summary>
		/// 환자번호로 입원키를 찾는다.
		/// </summary>
		#region 환자의 입원키를 찾는다.
		private void GetFkinp1001()
		{
            this.layFkinp1001.QueryLayout();
			if(TypeCheck.IsNull(this.layFkinp1001.GetItemValue("fkinp1001")))
			{
				this.GetMessage("jeawonYn");
				this.pnlFillFill.Enabled = false;
				this.paBox.Focus();
				return;
			}
			else
			{
				this.pnlFillFill.Enabled = true;

				if(this.grdNur1014.QueryLayout(false))
				{
					if(EnvironInfo.CurrSystemID == "NURI")
					{
						if(this.grdNur1014.RowCount == 0)
						{
							this.grdNur1014.InsertRow(0);

							this.cboOut_object.SetEditValue("00");
							this.cboOut_object.AcceptData();

                            this.dtpOut_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
							this.dtpOut_date.AcceptData();

                            this.dtpIn_hope_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
							this.dtpIn_hope_date.AcceptData();

							//							this.dtpIn_true_date.SetEditValue(EnvironInfo.GetSysDate().AddDays(1).ToString());
							//							this.dtpIn_true_date.AcceptData();

							this.grdNur1014.SetItemValue(this.grdNur1014.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
							this.grdNur1014.SetItemValue(this.grdNur1014.CurrentRowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue().ToString());
						}
					}
				}
				else
                {

                    if (Service.ErrFullMsg != "")
                    {
                        XMessageBox.Show(Service.ErrFullMsg.ToString());
                        return;
                    }
				}
			}
		}
		#endregion

		#region 등록번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			this.grdNur1014.Reset();

			if(!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				this.GetFkinp1001();
			}
		}

        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            /*틀린 환자번호 또는 Null 값이 들어 갔을 경우 추가 (2011.11.24 woo)*/
            this.grdNur1014.Reset();
        }

		#endregion

		#region 행이 변경이 됐을 때
		private void grdNur1014_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if(this.grdNur1014.GetRowState(this.grdNur1014.CurrentRowNumber) == DataRowState.Added)
			{
				/* 20070605 - Add Start */
				/*this.dtpOut_date.Protect = true;
				this.cboOut_object.Protect = true;
				this.edtOut_time.Protect = true;
				this.dtpIn_hope_date.Protect = true;
				this.dtpIn_true_date.Protect = true;
				this.edtIn_hope_time.Protect = true;
				this.edtIn_true_time.Protect = true;

				this.lblIn_hope_date.Visible = true;
				this.dtpIn_hope_date.Visible = false;
				this.lblIn_true_date.Visible = true;
				this.dtpIn_true_date.Visible = false;*/
				/* 20070605 - Add End */
				
				/*this.dtpIn_true_date.Protect = true;
				this.edtIn_true_time.Protect = true;*/

				this.rbxWoichul.Checked = false;
				this.rbxWoibak.Checked = false;
			}
			else
			{
				this.dtpIn_true_date.Protect = false;
				this.edtIn_true_time.Protect = false;
				//this.dtpIn_true_date.SetEditValue(this.dtpIn_hope_date.GetDataValue().ToString());
				//this.dtpIn_true_date.AcceptData();

				/* 20070523 - Add Start */
				if(this.grdNur1014.GetItemString(e.CurrentRow, "flag") == "01")
				{
					/*this.dtpOut_date.Protect = false;
					this.cboOut_object.Protect = false;
					this.edtOut_time.Protect = false;
					this.dtpIn_hope_date.Protect = false;
					this.dtpIn_true_date.Protect = false;
					this.edtIn_hope_time.Protect = false;
					this.edtIn_true_time.Protect = false;

					this.lblIn_hope_date.Visible = true;
					this.dtpIn_hope_date.Visible = false;
					this.lblIn_true_date.Visible = true;
					this.dtpIn_true_date.Visible = false;*/

					this.rbxWoichul.Checked = true;
				}
				else if(this.grdNur1014.GetItemString(e.CurrentRow, "flag") == "02")
				{
					/*this.dtpOut_date.Protect = false;
					this.cboOut_object.Protect = false;
					this.edtOut_time.Protect = false;
					this.dtpIn_hope_date.Protect = false;
					this.dtpIn_true_date.Protect = false;
					this.edtIn_hope_time.Protect = false;
					this.edtIn_true_time.Protect = false;

					this.lblIn_hope_date.Visible = true;
					this.dtpIn_hope_date.Visible = true;
					this.lblIn_true_date.Visible = true;
					this.dtpIn_true_date.Visible = true;*/
					
					this.rbxWoibak.Checked = true;
				}
				else
				{
					
					/* 20070605 - Modify Start */
					/*this.dtpOut_date.Protect = true;
					this.cboOut_object.Protect = true;
					this.edtOut_time.Protect = true;
					this.dtpIn_hope_date.Protect = true;
					this.dtpIn_true_date.Protect = true;
					this.edtIn_hope_time.Protect = true;
					this.edtIn_true_time.Protect = true;

					this.lblIn_hope_date.Visible = true;
					this.dtpIn_hope_date.Visible = false;
					this.lblIn_true_date.Visible = true;
					this.dtpIn_true_date.Visible = false;*/
					/* 20070605 - Modify End */


				}
				/* 20070523 - Add End */

                grdNur1014.ResetUpdate();
			}
		}
		#endregion	


		#region 버튼리스트를 클릭을 했을 때
        bool mPrintFlag = false;
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}
					e.IsBaseCall = false;

					this.GetFkinp1001();
					break;
				case FunctionType.Insert:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					if(EnvironInfo.CurrSystemID != "NURI")
					{
						e.IsBaseCall = false;
					}
					break;
				case FunctionType.Delete:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					if(EnvironInfo.CurrSystemID != "NURI")
					{
						e.IsBaseCall = false;
						return;
					}
					break;


				case FunctionType.Update:

                    e.IsBaseCall = false;

					if(!this.AcceptData())
					{
						e.IsSuccess = false;
						return;
                    }

                    if (!ValidationCheck())
                    {
                        e.IsSuccess = false;
                        break;
                    }

                    mPrintFlag = false;

                    if (!this.grdNur1014.SaveLayout())
                    {
                        this.GetMessage("save_false");
                    }
                    else
                    {
                        this.GetMessage("save_true");

                        //string iswoichul = rbxWoichul.Checked == true ? "2": "1" ;

                        //if(!AutoCreateStopData(iswoichul, dtpNut_start_date.GetDataValue(), cboNut_start_kini.GetDataValue(), dtpNut_end_date.GetDataValue(), cboNut_end_kini.GetDataValue()))
                        //{
                        //    XMessageBox.Show("食事箋の内容が修正されました。\r\n もう一度確認してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        //}
                        //else
                        //{
                        //    XMessageBox.Show("食事箋の内容が修正出来ませんでした。。\r\n ご確認おねがいします。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}

                        //OpenFoodOrder(paBox.BunHo);

                        //if (this.grdNur1014.QueryLayout(false))
                        //{
                        //}

                        if(mPrintFlag)
                            RePrint();

                        //				if(Convert.ToInt64(this.dtpOut_date.GetDataValue().Replace("/", "")) < Convert.ToInt64(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("/", "").Replace("-", "")))
                        //				{
                        //					this.GetMessage("tel");
                        //				}
                    
                    }

                    
                        break;
				default:
					break;
			}
		}
		#endregion

        #region 외박일자를 입력을 했을 때 Validation 체크
        private void dtpOut_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            /* 20070523 - Add Start */
            /*if(cboWoichul.Checked == true)
            {
                this.lblIn_hope_date.Visible = true;
                this.dtpIn_hope_date.Visible = false;
                this.lblIn_true_date.Visible = true;
                this.dtpIn_true_date.Visible = false;
            }
            else if(cboWoibak.Checked == true)
            {
                this.lblIn_hope_date.Visible = true;
                this.dtpIn_hope_date.Visible = true;
                this.lblIn_true_date.Visible = true;
                this.dtpIn_true_date.Visible = true;
            }*/
            /* 20070523 - Add Start */

            if (this.dtpOut_date.GetDataValue() != "")
            {
                /* 식사마감시작일자를 셋팅 */
                this.dtpNut_start_date.SetEditValue(this.dtpOut_date.GetDataValue().ToString());
                this.dtpNut_start_date.AcceptData();

                if (Convert.ToInt64(this.dtpOut_date.GetDataValue().Replace("/", "").Replace("-", "")) < Convert.ToInt64(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                {
                }
                else
                {
                    if (this.layValidationChk.QueryLayout())
                    {
                        if (!TypeCheck.IsNull(layValidationChk.GetItemValue("YorN")))
                        {
                            /* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                            if (layValidationChk.GetItemValue("YorN").ToString() == "Y")
                            {
                                this.GetMessage("out_date_check");
                                //e.Cancel = true;    
                                return;
                            }
                        }
                    }
                    else
                    {

                        if (Service.ErrFullMsg != "")
                        {
                            XMessageBox.Show(Service.ErrFullMsg.ToString());
                            return;
                        }
                    }
                }
            }

        }
        #endregion

        #region 복귀희망일자를 입력을 했을 때 Validaton 체크
        private void dtpIn_hope_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (this.dtpIn_hope_date.GetDataValue() != "")
            {
                if (Convert.ToInt64(this.dtpIn_hope_date.GetDataValue().Replace("/", "")) < Convert.ToInt64(this.dtpOut_date.GetDataValue().Replace("/", "")))
                {
                    this.GetMessage("in_hope_date");
                    e.Cancel = true;
                    return;
                }

                if (dtpOut_date.GetDataValue().Equals(dtpIn_hope_date.GetDataValue()))
                {
                    rbxWoichul.Checked = true;
                }
                else
                {
                    rbxWoibak.Checked = true;
                }

                /* 식사마감일자 셋팅 */
                this.dtpNut_end_date.SetEditValue(this.dtpIn_hope_date.GetDataValue().ToString());
                this.dtpNut_end_date.AcceptData();
            }
        }
        #endregion

        #region 귀실일자를 입력을 했을 때 Validation 체크
        private void dtpIn_true_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (this.dtpIn_true_date.GetDataValue() != "")
            {
                if (Convert.ToInt64(this.dtpIn_true_date.GetDataValue().Replace("/", "")) < Convert.ToInt64(this.dtpOut_date.GetDataValue().Replace("/", "")))
                {
                    this.GetMessage("in_hope_date");
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion

        private bool ValidationCheck()
        {
            if (EnvironInfo.CurrSystemID != "NURI")
            {
                return false;
            }

            if (TypeCheck.IsNull(this.paBox.BunHo))
            {
                return false;
            }

            if (this.grdNur1014.GetRowState(this.grdNur1014.CurrentRowNumber) == DataRowState.Added ||
                this.grdNur1014.GetRowState(this.grdNur1014.CurrentRowNumber) == DataRowState.Modified)
            {
                //現在のローだけ反映されるように。
                
                //コントロールは隠しておいた。
                if (this.rbxWoichul.Checked == false && this.rbxWoibak.Checked == false)
                {
                    this.GetMessage("woichul_gubun");
                    this.rbxWoichul.Focus();
                    return false;
                }

                //開始予定日
                if (this.dtpOut_date.GetDataValue() == "")
                {
                    this.GetMessage("out_date");
                    this.dtpOut_date.Focus();
                    return false;
                }

                //開始予定時間
                if (this.edtOut_time.GetDataValue() == "")
                {
                    this.GetMessage("out_time");
                    this.edtOut_time.Focus();
                    return false;
                }

                //終了予定日
                if (this.dtpIn_hope_date.GetDataValue() == "")
                {
                    this.GetMessage("in_hope_date");
                    this.dtpIn_hope_date.Focus();
                    return false;
                }
                
                //終了予定時間
                if (this.edtIn_hope_time.GetDataValue() == "")
                {
                    this.GetMessage("in_hope_time");
                    this.edtIn_hope_time.Focus();
                    return false;
                }

                //食事関連 (食止め有無)
                if (this.cbxNut_end_yn.Checked == false)
                {
                    if (this.dtpNut_start_date.GetDataValue() == "")
                    {
                        this.GetMessage("nut_start_date");
                        this.dtpNut_start_date.Focus();
                        return false;
                    }
                    if (this.dtpNut_end_date.GetDataValue() == "")
                    {
                        this.GetMessage("nut_end_date");
                        this.dtpNut_end_date.Focus();
                        return false;
                    }
                    if (this.cboNut_start_kini.GetDataValue() == "")
                    {
                        this.GetMessage("nut_start_kini");
                        this.cboNut_start_kini.Focus();
                        return false; 
                    }
                    if (this.cboNut_end_kini.GetDataValue() == "")
                    {
                        this.GetMessage("nut_end_kini");
                        this.cboNut_end_kini.Focus();
                        return false;
                    }
                    if (Convert.ToInt64(this.dtpNut_start_date.GetDataValue().Replace("/", "") + this.cboNut_start_kini.GetDataValue()) >
                       Convert.ToInt64(this.dtpNut_end_date.GetDataValue().Replace("/", "") + this.cboNut_end_kini.GetDataValue()))
                    {
                        this.GetMessage("nut_info_error");
                        this.edtIn_true_time.Focus();
                        return false;
                    }
                }

                //帰院日
                if (this.dtpIn_true_date.GetDataValue() != "")
                {
                    if (this.edtIn_true_time.GetDataValue() == "")
                    {
                        this.GetMessage("in_true_time");
                        this.edtIn_true_time.Focus();
                        return false;
                    }

                    //帰院日付
                    if (Convert.ToInt64(this.dtpIn_true_date.GetDataValue().Replace("/", "") + this.edtIn_true_time.GetDataValue().Replace(":", "")) <
                        Convert.ToInt64(this.dtpOut_date.GetDataValue().Replace("/", "") + this.edtOut_time.GetDataValue().Replace(":", "")))
                    {
                        this.GetMessage("in_true_time");
                        this.edtIn_true_time.Focus();
                        return false;
                    }

                }

                //if (this.dtpNut_start_date.GetDataValue() != "" && this.cboNut_start_kini.GetDataValue() == "")
                //{
                //    this.GetMessage("nut_start_info");
                //    this.cboNut_start_kini.Focus();
                //    return false;
                //}

                //if (this.cboNut_start_kini.GetDataValue() == "")
                //{
                //    this.GetMessage("nut_start_info");
                //    this.cboNut_start_kini.Focus();
                //    return false;
                //}

                //if (this.dtpNut_end_date.GetDataValue() != "" && this.cboNut_end_kini.GetDataValue() == "")
                //{
                //    this.GetMessage("nut_end_info");
                //    this.cboNut_end_kini.Focus();
                //    return false;
                //}

                //if (this.cboNut_end_kini.GetDataValue() == "")
                //{
                //    this.GetMessage("nut_end_info");
                //    this.cboNut_end_kini.Focus();
                //    return false;
                //}

                if (this.rbxWoibak.Checked == true)
                {
                    /* 외박시 실시 및 점수가 발생하는 오다가 있는지 조회를 한다. */
                    if (this.layCheck_order.QueryLayout())
                    {
                        if (this.layCheck_order.GetItemValue("check_order").ToString() == "Y")
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (Service.ErrFullMsg != "")
                        {
                            XMessageBox.Show(Service.ErrFullMsg.ToString());
                            return false;
                        }
                    }
                }
                return true;
            }
            return true;
        }


		#region 버튼리스트에서 버튼을 클릭을 하고 난후의 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
                    this.dtpOut_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpOut_date.AcceptData();

					this.cboOut_object.SetEditValue("00");
					this.cboOut_object.AcceptData();

                    this.dtpIn_hope_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpIn_hope_date.AcceptData();

//					this.dtpIn_true_date.SetEditValue(EnvironInfo.GetSysDate().AddDays(1).ToString());
//					this.dtpIn_true_date.AcceptData();

					this.grdNur1014.SetItemValue(this.grdNur1014.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
					this.grdNur1014.SetItemValue(this.grdNur1014.CurrentRowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue().ToString());
					break;
				case FunctionType.Reset:
					this.pnlFillFill.Enabled = false;
                    this.dtpOut_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpOut_date.AcceptData();

                    this.dtpIn_hope_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpIn_hope_date.AcceptData();

//					this.dtpIn_true_date.SetEditValue(EnvironInfo.GetSysDate().AddDays(1).ToString());
//					this.dtpIn_true_date.AcceptData();
					break;
				default:
					break;
			}
		}
		#endregion

		

		#region 중복체크
		private void edtOut_time_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (this.layValidationChk.QueryLayout())
            {
                /* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
                if (layValidationChk.GetItemValue("YorN").ToString() == "Y")
                {
                    this.GetMessage("out_date_check");
                    //e.Cancel = true;    
                    return;
                }
            }
        }

		#endregion

		private void rbxWoichul_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbxWoichul.Checked == true)
			{
				this.grdNur1014.SetItemValue(this.grdNur1014.CurrentRowNumber, "flag", "01");
			}

			if (rbxWoibak.Checked == true)
			{
				this.grdNur1014.SetItemValue(this.grdNur1014.CurrentRowNumber, "flag", "02");
			}
		}

		#region 금식개시취소버튼을 클리을 했을 때
		private void btnNut_Start_Cancel_Click(object sender, System.EventArgs e)
		{
			this.dtpNut_start_date.ResetData();
			this.cboNut_start_kini.SetEditValue("");
			this.cboNut_start_kini.AcceptData();
		}
		#endregion

		#region 금식종료취소버튼을 클릭을 했을 때
		private void btnNut_End_Cancel_Click(object sender, System.EventArgs e)
		{
			this.dtpNut_end_date.ResetData();
			this.cboNut_end_kini.SetEditValue("");
			this.cboNut_end_kini.AcceptData();
		}
		#endregion

		private void btnSiksaClear_Click(object sender, System.EventArgs e)
		{
			this.dtpNut_start_date.ResetData();
			this.cboNut_start_kini.SetEditValue("");
			this.cboNut_start_kini.AcceptData();
			this.dtpNut_end_date.ResetData();
			this.cboNut_end_kini.SetEditValue("");
			this.cboNut_end_kini.AcceptData();
		}

        private void layFkinp1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layFkinp1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layFkinp1001.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void grdNur1014_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNur1014.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNur1014.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void layValidationChk_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layValidationChk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layValidationChk.SetBindVarValue("f_bunho", this.grdNur1014.GetItemString(this.grdNur1014.CurrentRowNumber, "bunho"));
            this.layValidationChk.SetBindVarValue("f_fkinp1001", this.grdNur1014.GetItemString(this.grdNur1014.CurrentRowNumber, "fkinp1001"));
            this.layValidationChk.SetBindVarValue("f_out_date", this.dtpOut_date.GetDataValue());
            this.layValidationChk.SetBindVarValue("f_out_time", this.edtOut_time.GetDataValue().Replace(":", ""));

        }

        private void layCheck_order_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layValidationChk.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layValidationChk.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layValidationChk.SetBindVarValue("f_fkinp1001", this.grdNur1014.GetItemString(this.grdNur1014.CurrentRowNumber, "fkinp1001"));
            this.layValidationChk.SetBindVarValue("f_out_date", this.dtpOut_date.GetDataValue());
            this.layValidationChk.SetBindVarValue("f_in_date", this.dtpIn_hope_date.GetDataValue());

        }

        #region XSavePerformer
        string mErrMsg = "";
        private class XSavePerformer : ISavePerformer
        {
            private NUR1014U00 parent;

            

            public XSavePerformer(NUR1014U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                parent.mErrMsg = "";
                CommonItemCollection cic = new CommonItemCollection();

                Service.BeginTransaction();

                try
                {

                    item.BindVarList.Add("q_user_id", UserInfo.UserID);
                    item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                    /* 중복체크 */
                    /*
                    cmdText = @"SELECT 'Y'
                                  FROM DUAL
                                 WHERE EXISTS (SELECT 'X'
                                                 FROM NUR1014
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND BUNHO     = :f_bunho
                                                  AND OUT_DATE  = TO_DATE(:f_out_date, 'YYYY/MM/DD')
                                                  AND OUT_TIME  = REPLACE(:f_out_time, ':'))";


                    object dup_chck = Service.ExecuteScalar(cmdText, item.BindVarList);
                    */
                    /*
                    I_FKINP1001     IN  VARCHAR2
                                                          , I_START_DATE    IN  VARCHAR2
                                                          , I_START_TIME    IN  VARCHAR2
                                                          , I_END_DATE      IN  VARCHAR2
                                                          , I_END_TIME      IN  VARCHAR2*/

                    //   bool isDup = false;
                    /*
                 if (!TypeCheck.IsNull(dup_chck))
                 {
                     if (dup_chck.ToString() == "Y")
                         isDup = true;
                 }
                 */

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            ArrayList inputList = new ArrayList();
                            ArrayList outputList = new ArrayList();

                            inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
                            inputList.Add(item.BindVarList["f_out_date"].VarValue);
                            inputList.Add(item.BindVarList["f_out_time"].VarValue);
                            inputList.Add(item.BindVarList["f_in_hope_date"].VarValue);
                            inputList.Add(item.BindVarList["f_in_hope_time"].VarValue);

                            if (!Service.ExecuteProcedure("PR_INP_JAEWON_RANGE_CHECK", inputList, outputList))
                                throw new Exception("在院期間照会に問題があります。");

                            if (outputList[0].ToString() != "0")
                                throw new Exception(outputList[1].ToString());


                            if (parent.cbxNut_end_yn.Checked == false)
                            {
                                inputList.Clear();
                                outputList.Clear();

                                inputList.Add(item.BindVarList["f_nut_start_date"].VarValue);
                                inputList.Add(item.BindVarList["f_nut_start_kini"].VarValue);
                                inputList.Add(item.BindVarList["f_nut_end_date"].VarValue);
                                inputList.Add(item.BindVarList["f_nut_end_kini"].VarValue);
                                inputList.Add(item.BindVarList["f_bunho"].VarValue);
                                inputList.Add(EnvironInfo.HospCode);
                                inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);
                                inputList.Add(UserInfo.UserID);
                                inputList.Add(item.BindVarList["f_flag"].VarValue);
                                inputList.Add("I");
                                inputList.Add("");

                                if (Service.ExecuteProcedure("PR_OCS_CREATE_STOP_SIKSA", inputList, outputList))
                                {
                                    XMessageBox.Show("食事箋の内容が修正されました。\r\n もう一度確認してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    XMessageBox.Show("食事箋の内容が修正出来ませんでした。。\r\n ご確認おねがいします。", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                cic.Add("bunho", item.BindVarList["f_bunho"].VarValue);
                                OpenScreenWithParam(this, "OCSI", "OCS2005U02", ScreenOpenStyle.ResponseFixed, cic);
                            }
                            parent.mPrintFlag = true;
                            //if (isDup)
                            //{
                            //    parent.mErrMsg = item.BindVarList["f_bunho"].VarValue + "患者の「" 
                            //                   + item.BindVarList["f_out_date"].VarValue + "、"
                            //                   + item.BindVarList["f_out_time"].VarValue + "」のデータは既に登録されています。";
                            //    return false;                        
                            //}

                            cmdText = @"INSERT INTO NUR1014 
                                         ( SYS_DATE         , SYS_ID         , UPD_DATE         , UPD_ID      ,
                                           HOSP_CODE        ,
                                           BUNHO            , FKINP1001      , 
                                           OUT_DATE         , OUT_TIME       , 
                                           IN_HOPE_DATE     , IN_HOPE_TIME   ,
                                           IN_TRUE_DATE     , IN_TRUE_TIME   , 
                                           NUT_START_DATE   , NUT_START_KINI , 
                                           NUT_END_DATE     , NUT_END_KINI     ,
                                           OUT_OBJECT       , WOICHUL_WOIBAK_GUBUN              , NUT_END_YN    , 
                                           DEST_ISHOME      , DEST_ADDR      , DEST_TEL  )
                                    VALUES 
                                         ( SYSDATE          , :q_user_id        , SYSDATE          , :q_user_id     ,
                                           :f_hosp_code     ,
                                           :f_bunho         , :f_fkinp1001      , 
                                           TO_DATE(:f_out_date, 'yyyy/mm/dd')   , REPLACE(:f_out_time, ':')      , 
                                           TO_DATE(:f_in_hope_date,'yyyy/mm/dd'), REPLACE(:f_in_hope_time, ':')  ,
                                           TO_DATE(:f_in_true_date,'yyyy/mm/dd'), REPLACE(:f_in_true_time, ':')  , 
                                           :f_nut_start_date, :f_nut_start_kini , 
                                           :f_nut_end_date  , :f_nut_end_kini  ,
                                           :f_out_object    , :f_flag                            , :f_nut_end_yn    ,
                                           :f_dest_ishome   , :f_dest_addr      , :f_dest_tel)";

                            break;

                        case DataRowState.Modified:

                            cmdText = @"UPDATE NUR1014
                                       SET UPD_ID               = :q_user_id,
                                           UPD_DATE             = SYSDATE,
                                           IN_HOPE_DATE         = TO_DATE(:f_in_hope_date, 'YYYY/MM/DD'),
                                           IN_HOPE_TIME         = REPLACE(:f_in_hope_time, ':'),
                                           IN_TRUE_DATE         = TO_DATE(:f_in_true_date, 'YYYY/MM/DD'),
                                           IN_TRUE_TIME         = REPLACE(:f_in_true_time, ':'),
                                           NUT_START_DATE       = :f_nut_start_date,
                                           NUT_START_KINI       = :f_nut_start_kini,
                                           NUT_END_DATE         = :f_nut_end_date,
                                           NUT_END_KINI         = :f_nut_end_kini,
                                           OUT_OBJECT           = :f_out_object,
                                           WOICHUL_WOIBAK_GUBUN = :f_flag,
                                           NUT_END_YN           = :f_nut_end_yn,
                                           DEST_ISHOME          = :f_dest_ishome,
                                           DEST_ADDR            = :f_dest_addr,
                                           DEST_TEL             = :f_dest_tel
                                     WHERE HOSP_CODE            = :f_hosp_code
                                       AND BUNHO                = :f_bunho
                                       AND FKINP1001            = :f_fkinp1001
                                       AND OUT_DATE             = TO_DATE(:f_out_date, 'YYYY/MM/DD')
                                       AND OUT_TIME             = REPLACE(:f_out_time, ':')";


                            XMessageBox.Show("外出・外泊情報が変更されました。\r\n 食事箋を確認してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cic.Add("bunho", item.BindVarList["f_bunho"].VarValue);
                            OpenScreenWithParam(this, "OCSI", "OCS2005U02", ScreenOpenStyle.ResponseFixed, cic);

                            break;

                        case DataRowState.Deleted:
                            cmdText = @"DELETE NUR1014
                                     WHERE HOSP_CODE    = :f_hosp_code
                                       AND BUNHO        = :f_bunho
                                       AND FKINP1001    = :f_fkinp1001
                                       AND OUT_DATE     = :f_out_date
                                       AND OUT_TIME     = REPLACE(:f_out_time, ':')";

                            XMessageBox.Show("外出・外泊情報が削除されました。\r\n 食事箋を確認してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cic.Add("bunho", item.BindVarList["f_bunho"].VarValue);
                            OpenScreenWithParam(this, "OCSI", "OCS2005U02", ScreenOpenStyle.ResponseFixed, cic);
                            
                            break;
                    }
                    if(!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                        throw new Exception(Service.ErrFullMsg);

                }
                catch(Exception ex)
                {
                    parent.mErrMsg = ex.Message;
                    Service.RollbackTransaction();
                    return false;
                }

                Service.CommitTransaction();
                return true;
            }
        }
        #endregion

        private void btnRePrint_Click(object sender, EventArgs e)
        {
            RePrint();           
        }

        private void RePrint()
        {
            if (this.grdNur1014.RowCount < 1)
                return;
            
            if (this.grdNur1014.CurrentRowNumber < 0)
            {
                XMessageBox.Show("再発行する外出・外泊情報を選択してください。", "注意", MessageBoxIcon.Warning);
                return;
            }

            if (this.grdNur1014.GetRowState(this.grdNur1014.CurrentRowNumber) == DataRowState.Added)
            {
                XMessageBox.Show("まだ保存していない情報です。保存してください。", "注意", MessageBoxIcon.Warning);
                return;            
            }

            //string columnName = "";
            //for (int i = 0; i < this.layPrint1.LayoutItems.Count; i++)
            //{
            //    columnName = this.layPrint1.LayoutItems[i].DataName;

            //    for (int j = 0; j < this.grdNur1014.LayoutTable.Columns.Count; j++)
            //    {
            //        if (columnName == this.grdNur1014.LayoutTable.Columns[j].ColumnName)
            //            this.layPrint1.SetItemValue(columnName, this.grdNur1014.GetItemString(this.grdNur1014.CurrentRowNumber, columnName));
            //    }
            //}

            //this.layLoadDocNur.QueryLayout();

            //this.layPrint.Reset();
            //this.layPrint.InsertRow(0);
            //this.layPrint.SetItemValue(0, "bunho", this.paBox.BunHo);
            //this.layPrint.SetItemValue(0, "out_date", this.dtpOut_date.Text);
            //this.layPrint.SetItemValue(0, "out_time", this.edtOut_time.Text);
            //this.layPrint.SetItemValue(0, "in_hope_date", this.dtpIn_hope_date.Text);
            //this.layPrint.SetItemValue(0, "in_hope_time", this.edtIn_hope_time.Text);
            //this.layPrint.SetItemValue(0, "in_true_date", this.dtpIn_true_date.Text);
            //this.layPrint.SetItemValue(0, "in_true_time", this.edtIn_true_time.Text);
            //this.layPrint.SetItemValue(0, "out_object", this.cboOut_object.Text);
            //this.layPrint.SetItemValue(0, "nut_start_date", this.dtpNut_start_date.Text);
            //this.layPrint.SetItemValue(0, "nut_start_kini", this.cboNut_start_kini.Text);
            //this.layPrint.SetItemValue(0, "nut_end_date", this.dtpNut_end_date.Text);
            //this.layPrint.SetItemValue(0, "nut_end_kini", this.cboNut_end_kini.Text);
            //this.layPrint.SetItemValue(0, "doctor", this.layLoadDocNur.GetItemValue("doctor"));
            //this.layPrint.SetItemValue(0, "nurse", this.layLoadDocNur.GetItemValue("nurse"));
            //this.layPrint.SetItemValue(0, "ho_code", this.layLoadDocNur.GetItemValue("ho_code"));
            //this.layPrint.SetItemValue(0, "flag", this.grdNur1014.GetItemString(this.grdNur1014.CurrentRowNumber,"flag"));

            //this.dwPrint.FillData(this.layPrint.LayoutTable);
            //this.dwPrint.Print();

            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", this.paBox.BunHo);
            cic.Add("flag", this.grdNur1014.GetItemString(this.grdNur1014.CurrentRowNumber, "flag"));
            cic.Add("order_date", this.dtpOut_date.GetDataValue());
            cic.Add("out_time", edtOut_time.GetDataValue());
            cic.Add("in_hope_date", dtpIn_hope_date.GetDataValue());
            cic.Add("in_hope_time", edtIn_hope_time.GetDataValue());
            cic.Add("isCalled", "N");
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1014R00", ScreenOpenStyle.ResponseFixed, cic);
        }

        private void layLoadDocNur_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layLoadDocNur.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layLoadDocNur.SetBindVarValue("f_fkinp1001", this.grdNur1014.GetItemString(this.grdNur1014.CurrentRowNumber, "fkinp1001"));
        }

        private void cbxNut_end_yn_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNut_end_yn.Checked)
            {
                this.dtpNut_start_date.ResetData();
                this.cboNut_start_kini.SetEditValue("");
                this.cboNut_start_kini.AcceptData();
                this.dtpNut_end_date.ResetData();
                this.cboNut_end_kini.SetEditValue("");
                this.cboNut_end_kini.AcceptData();

                this.dtpNut_start_date.Enabled = false;
                this.cboNut_start_kini.Enabled = false;
                this.dtpNut_end_date.Enabled = false;
                this.cboNut_end_kini.Enabled = false;
            }
            else
            {
                this.dtpNut_start_date.Enabled = true;
                this.cboNut_start_kini.Enabled = true;
                this.dtpNut_end_date.Enabled = true;
                this.cboNut_end_kini.Enabled = true;

                this.dtpNut_start_date.SetDataValue(this.dtpOut_date.GetDataValue());
                this.dtpNut_end_date.SetDataValue(this.dtpIn_hope_date.GetDataValue());

                dtpNut_start_date.Focus();
            }
        }

        private void grdNur1014_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (!e.IsSuccess)
            {
                XMessageBox.Show(this.mErrMsg, "警告", MessageBoxIcon.Error);
            }
        }

        #region 식사오더 마감 여부 확인 Screen Open (OpenFoodOrder)
        /// <summary>
        /// 식사오더 마감 여부 확인 Screen Open
        /// </summary>
        /// <param name="aBunho"> string 등록번호 </param>
        /// <param name="aOrder_Date"> string 처방일자 </param>
        /// <returns> void </returns>		
        private void OpenFoodOrder(string aBunho)
        {
            XMessageBox.Show("患者の食事箋を確認してください。");
            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", aBunho);
            //cic.Add("hodong", grdInp1001.GetItemString(grdInp1001.CurrentRowNumber, "ho_dong"));
            //cic.Add("hocode", grdInp1001.GetItemString(grdInp1001.CurrentRowNumber, "ho_code"));

            OpenScreenWithParam(this, "OCSI", "OCS2005U02", ScreenOpenStyle.ResponseFixed, cic);

        }
        #endregion

        private void cbxisHome_DataValidating(object sender, DataValidatingEventArgs e)
        {

        }

        private void cbxisHome_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxisHome.Checked == true)
            {
                txtDestAddr.Text = paBox.Address1;
                txtDestTel.Text = paBox.Tel;

                txtDestAddr.AcceptData();
                txtDestTel.AcceptData();
            }
            else
            {
                txtDestAddr.Text = "";
                txtDestTel.Text = "";
            }
        }
    }
}

