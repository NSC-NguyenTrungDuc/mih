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
	public class OCS2003Q03 : IHIS.Framework.XScreen
	{
		////////////////////////////////// Screen Level 개발자 변수 기술 ///////////////////////////////////
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리
		private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리

		private Hashtable mHtControl = null;

		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XFindBox fbxHo_Team;
		private IHIS.Framework.XLabel lblJaewon_Ho_Dong;
		private IHIS.Framework.XLabel lblHo_Team;
		private IHIS.Framework.XLabel lblOrder_DateTitle;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell15;
		private IHIS.Framework.XGridCell xGridCell18;
		private IHIS.Framework.XGridCell xGridCell14;
		private IHIS.Framework.XGridCell xGridCell23;
		private IHIS.Framework.XGridCell xGridCell27;
		private IHIS.Framework.XButton btnQuery;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDatePicker dtpFrom_Order_Date;
		private IHIS.Framework.XDatePicker dtpTo_Order_Date;
		private IHIS.Framework.XComboBox cboHo_Dong;
		private IHIS.Framework.XGrid grdNoConfirm;
        private System.Windows.Forms.Timer timerQuery;
		private System.ComponentModel.IContainer components;

		public OCS2003Q03()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2003Q03));
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdNoConfirm = new IHIS.Framework.XGrid();
            this.xGridCell27 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell23 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell18 = new IHIS.Framework.XGridCell();
            this.xGridCell15 = new IHIS.Framework.XGridCell();
            this.xGridCell14 = new IHIS.Framework.XGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpTo_Order_Date = new IHIS.Framework.XDatePicker();
            this.btnQuery = new IHIS.Framework.XButton();
            this.dtpFrom_Order_Date = new IHIS.Framework.XDatePicker();
            this.lblOrder_DateTitle = new IHIS.Framework.XLabel();
            this.lblHo_Team = new IHIS.Framework.XLabel();
            this.fbxHo_Team = new IHIS.Framework.XFindBox();
            this.cboHo_Dong = new IHIS.Framework.XComboBox();
            this.lblJaewon_Ho_Dong = new IHIS.Framework.XLabel();
            this.timerQuery = new System.Windows.Forms.Timer(this.components);
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoConfirm)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFill
            // 
            this.pnlFill.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlFill.Controls.Add(this.grdNoConfirm);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Location = new System.Drawing.Point(0, 34);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(516, 315);
            this.pnlFill.TabIndex = 1;
            // 
            // grdNoConfirm
            // 
            this.grdNoConfirm.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell27,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell23,
            this.xGridCell5,
            this.xGridCell6,
            this.xGridCell18,
            this.xGridCell15,
            this.xGridCell14});
            this.grdNoConfirm.ColPerLine = 7;
            this.grdNoConfirm.Cols = 7;
            this.grdNoConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNoConfirm.FixedRows = 1;
            this.grdNoConfirm.HeaderHeights.Add(25);
            this.grdNoConfirm.Location = new System.Drawing.Point(0, 0);
            this.grdNoConfirm.Name = "grdNoConfirm";
            this.grdNoConfirm.QuerySQL = resources.GetString("grdNoConfirm.QuerySQL");
            this.grdNoConfirm.Rows = 2;
            this.grdNoConfirm.Size = new System.Drawing.Size(514, 313);
            this.grdNoConfirm.TabIndex = 23;
            this.grdNoConfirm.DoubleClick += new System.EventHandler(this.grdNoConfirm_DoubleClick);
            // 
            // xGridCell27
            // 
            this.xGridCell27.CellName = "fkinp1001";
            this.xGridCell27.Col = -1;
            this.xGridCell27.IsVisible = false;
            this.xGridCell27.Row = -1;
            // 
            // xGridCell3
            // 
            this.xGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell3.CellName = "order_date";
            this.xGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell3.CellWidth = 90;
            this.xGridCell3.Col = 5;
            this.xGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell3.HeaderText = "オーダ日付";
            this.xGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell4
            // 
            this.xGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell4.CellName = "bunho";
            this.xGridCell4.CellWidth = 66;
            this.xGridCell4.Col = 2;
            this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell4.HeaderText = "患者番号";
            this.xGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell1
            // 
            this.xGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell1.CellName = "ho_dong";
            this.xGridCell1.CellWidth = 38;
            this.xGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell1.HeaderText = "病棟";
            this.xGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell2
            // 
            this.xGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell2.CellName = "ho_code";
            this.xGridCell2.CellWidth = 36;
            this.xGridCell2.Col = 1;
            this.xGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell2.HeaderText = "病室";
            this.xGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell23
            // 
            this.xGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell23.CellName = "team";
            this.xGridCell23.CellWidth = 28;
            this.xGridCell23.Col = 6;
            this.xGridCell23.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell23.HeaderText = "TE\r\nAM";
            this.xGridCell23.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell23.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell5
            // 
            this.xGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell5.CellName = "suname";
            this.xGridCell5.CellWidth = 142;
            this.xGridCell5.Col = 3;
            this.xGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell5.HeaderText = "患者名(漢字)";
            this.xGridCell5.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell5.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell6
            // 
            this.xGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell6.CellName = "suname2";
            this.xGridCell6.CellWidth = 90;
            this.xGridCell6.Col = 4;
            this.xGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell6.HeaderText = "患者名(ガナ)";
            this.xGridCell6.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell6.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell18
            // 
            this.xGridCell18.CellName = "gwa";
            this.xGridCell18.Col = -1;
            this.xGridCell18.HeaderText = "gwa";
            this.xGridCell18.IsVisible = false;
            this.xGridCell18.Row = -1;
            // 
            // xGridCell15
            // 
            this.xGridCell15.CellName = "doctor";
            this.xGridCell15.Col = -1;
            this.xGridCell15.HeaderText = "doctor";
            this.xGridCell15.IsVisible = false;
            this.xGridCell15.Row = -1;
            // 
            // xGridCell14
            // 
            this.xGridCell14.CellName = "ipwon_type";
            this.xGridCell14.Col = -1;
            this.xGridCell14.HeaderText = "입원유형";
            this.xGridCell14.IsVisible = false;
            this.xGridCell14.Row = -1;
            // 
            // pnlTop
            // 
            this.pnlTop.BorderColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.dtpTo_Order_Date);
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Controls.Add(this.dtpFrom_Order_Date);
            this.pnlTop.Controls.Add(this.lblOrder_DateTitle);
            this.pnlTop.Controls.Add(this.lblHo_Team);
            this.pnlTop.Controls.Add(this.fbxHo_Team);
            this.pnlTop.Controls.Add(this.cboHo_Dong);
            this.pnlTop.Controls.Add(this.lblJaewon_Ho_Dong);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(516, 34);
            this.pnlTop.TabIndex = 0;
            // 
            // xLabel1
            // 
            this.xLabel1.AllowDrop = true;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.Location = new System.Drawing.Point(156, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(12, 20);
            this.xLabel1.TabIndex = 34;
            this.xLabel1.Text = "~";
            // 
            // dtpTo_Order_Date
            // 
            this.dtpTo_Order_Date.AllowDrop = true;
            this.dtpTo_Order_Date.Location = new System.Drawing.Point(168, 6);
            this.dtpTo_Order_Date.Name = "dtpTo_Order_Date";
            this.dtpTo_Order_Date.Protect = true;
            this.dtpTo_Order_Date.ReadOnly = true;
            this.dtpTo_Order_Date.Size = new System.Drawing.Size(90, 20);
            this.dtpTo_Order_Date.TabIndex = 1;
            this.dtpTo_Order_Date.TabStop = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(458, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnQuery.Size = new System.Drawing.Size(54, 24);
            this.btnQuery.TabIndex = 32;
            this.btnQuery.Text = "照会";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dtpFrom_Order_Date
            // 
            this.dtpFrom_Order_Date.AllowDrop = true;
            this.dtpFrom_Order_Date.Location = new System.Drawing.Point(66, 6);
            this.dtpFrom_Order_Date.Name = "dtpFrom_Order_Date";
            this.dtpFrom_Order_Date.Protect = true;
            this.dtpFrom_Order_Date.ReadOnly = true;
            this.dtpFrom_Order_Date.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom_Order_Date.TabIndex = 0;
            this.dtpFrom_Order_Date.TabStop = false;
            // 
            // lblOrder_DateTitle
            // 
            this.lblOrder_DateTitle.AllowDrop = true;
            this.lblOrder_DateTitle.EdgeRounding = false;
            this.lblOrder_DateTitle.Location = new System.Drawing.Point(2, 6);
            this.lblOrder_DateTitle.Name = "lblOrder_DateTitle";
            this.lblOrder_DateTitle.Size = new System.Drawing.Size(64, 20);
            this.lblOrder_DateTitle.TabIndex = 31;
            this.lblOrder_DateTitle.Text = "オーダ日付";
            // 
            // lblHo_Team
            // 
            this.lblHo_Team.EdgeRounding = false;
            this.lblHo_Team.Location = new System.Drawing.Point(380, 6);
            this.lblHo_Team.Name = "lblHo_Team";
            this.lblHo_Team.Size = new System.Drawing.Size(39, 20);
            this.lblHo_Team.TabIndex = 29;
            this.lblHo_Team.Text = "Team";
            this.lblHo_Team.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHo_Team.Visible = false;
            // 
            // fbxHo_Team
            // 
            this.fbxHo_Team.AllowDrop = true;
            this.fbxHo_Team.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHo_Team.Location = new System.Drawing.Point(420, 6);
            this.fbxHo_Team.MaxLength = 9;
            this.fbxHo_Team.Name = "fbxHo_Team";
            this.fbxHo_Team.Size = new System.Drawing.Size(38, 20);
            this.fbxHo_Team.TabIndex = 3;
            this.fbxHo_Team.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fbxHo_Team.Visible = false;
            // 
            // cboHo_Dong
            // 
            this.cboHo_Dong.Location = new System.Drawing.Point(294, 6);
            this.cboHo_Dong.MaxDropDownItems = 30;
            this.cboHo_Dong.Name = "cboHo_Dong";
            this.cboHo_Dong.Size = new System.Drawing.Size(84, 21);
            this.cboHo_Dong.TabIndex = 2;
            // 
            // lblJaewon_Ho_Dong
            // 
            this.lblJaewon_Ho_Dong.EdgeRounding = false;
            this.lblJaewon_Ho_Dong.Location = new System.Drawing.Point(260, 6);
            this.lblJaewon_Ho_Dong.Name = "lblJaewon_Ho_Dong";
            this.lblJaewon_Ho_Dong.Size = new System.Drawing.Size(34, 20);
            this.lblJaewon_Ho_Dong.TabIndex = 27;
            this.lblJaewon_Ho_Dong.Text = "病棟";
            this.lblJaewon_Ho_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerQuery
            // 
            this.timerQuery.Interval = 60000;
            this.timerQuery.Tick += new System.EventHandler(this.timerQuery_Tick);
            // 
            // OCS2003Q03
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Name = "OCS2003Q03";
            this.Size = new System.Drawing.Size(516, 349);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS2003Q03_Closing);
            this.UserChanged += new System.EventHandler(this.OCS2003Q03_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS2003U01_ScreenOpen);
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNoConfirm)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
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

		#region 입원미확인처방조회 Screen Open (OpenNoConfirmQuery)
		/// <summary>
		/// 입원미확인처방조회 Screen Open
		/// </summary>
		/// <param name="aBunho"> string 등록번호 </param>
		/// <param name="aOrder_Date"> string 처방일자 </param>
		/// <param name="aPkInp1001"> string 입원키  </param>
		/// <returns> void </returns>		
		private void OpenNoConfirmQuery(string aBunho, string aOrder_Date, string aPkInp1001)
		{
			CommonItemCollection openParams  = new CommonItemCollection();
			
			if (!TypeCheck.IsNull(aBunho))
			{
				openParams.Add("bunho", aBunho);
				if (!TypeCheck.IsNull(aOrder_Date)) openParams.Add("order_date", aOrder_Date);
				if (!TypeCheck.IsNull(aPkInp1001))  openParams.Add("pkinp1001",  aPkInp1001);

				////openParams.Add("auto_close" , true);

				// 응답을 받아야 하기 때문에 Response로 띄운다
				XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003U10", ScreenOpenStyle.ResponseSizable, openParams);
			}

		}        
		#endregion

        #region 치료계획 화면 오픈 Screen Open ( 치료계획 Open )

        private void OpenScreen_OCS6010U10(string aBunho, string aPkInp1001)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("fkinp1001", aPkInp1001);

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        #region 미실행추가처방 리스트 조회 Service Call (QueryNoConfirmList)
        /// <summary>
		/// 미실행추가처방 리스트 조회 Service Call
		/// </summary>
		/// <param name="aFromOrderDate"> string From 처방일자 </param>
		/// <param name="aToOrderDate"> string To 처방일자 </param>
		/// <param name="aHoDong"> string 병동 </param>
		/// <param name="aHoTeam"> string 병동팀 </param>
		/// <param name="aIsAlarm"> bool 미확인데이타 존재 여부 알림여부 </param>
		/// <returns> bool </returns>
		public bool QueryNoConfirmList(string aFromOrderDate, string aToOrderDate, string aHoDong, string aHoTeam, bool aIsAlarm)
		{	
			bool isSuccess = false;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계				

				// 입원간호처방 : 병동은 필수 간호팀은 %허용
				string from_order_date, to_order_date, ho_dong, ho_team;

				from_order_date = aFromOrderDate; to_order_date = aToOrderDate;
				ho_dong = aHoDong; ho_team = aHoTeam;

				ho_dong = this.cboHo_Dong.GetDataValue(); ho_team = this.fbxHo_Team.GetDataValue();

				if (TypeCheck.IsNull(ho_team))  ho_team = "%";	
				
				this.grdNoConfirm.Reset();

				this.grdNoConfirm.SetBindVarValue("f_from_order_date", from_order_date);
				this.grdNoConfirm.SetBindVarValue("f_to_order_date",to_order_date);
				this.grdNoConfirm.SetBindVarValue("f_ho_dong", ho_dong);
				this.grdNoConfirm.SetBindVarValue("f_ho_team", ho_team);

				isSuccess = this.grdNoConfirm.QueryLayout(true); // 데이타 조회

				// 미시행 데이타 존재여부 표시
				if (isSuccess && this.grdNoConfirm.RowCount > 0)
				{

					if (aIsAlarm) // 미확인데이타 존재 여부 알림여부
					{
						DateTime beforeTime = DateTime.Now;
						try
						{
							this.timerQuery.Enabled = false; // 시간 멈춤					

							// 알림 Sound						
							try {IHIS.Framework.Kernel32.Nofify();} 
							catch{};
							// 알림 Form 오픈

							FormMsg frmMsg = new FormMsg();

							//frmMsg.BringToFront();
							frmMsg.ShowDialog();

							if (this.ParentForm.MdiParent is IHIS.Framework.MdiForm)
							{						
								Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
								((IHIS.Framework.MdiForm)this.ParentForm.MdiParent).Location = new Point(rc.Width - ((IHIS.Framework.MdiForm)this.ParentForm.MdiParent).Width, rc.Height - ((IHIS.Framework.MdiForm)this.ParentForm.MdiParent).Height);
								((IHIS.Framework.MdiForm)this.ParentForm.MdiParent).Show(); 
								((IHIS.Framework.MdiForm)this.ParentForm.MdiParent).Activate();
							}

						}
						finally
						{
							this.timerQuery.Enabled = true; // 시간 다시 수행

							// 미시행 메세지 화면을 오픈한지 5분이후에 확인한 경우 데이타 재조회..
							if (beforeTime.AddMinutes(5) <= DateTime.Now)
							{
								// 미실행추가처방 리스트 조회 Service Call
								this.QueryNoConfirmList(this.dtpFrom_Order_Date.GetDataValue(), this.dtpTo_Order_Date.GetDataValue(), 
									this.cboHo_Dong.GetDataValue(), this.fbxHo_Team.GetDataValue(), false);
							}

						}
					}
				}
			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
			}

			return isSuccess;
		}
		#endregion

		#region 미실행추가처방 검색 처리 (QueryNoConfirmProcess)
		/// <summary>
		/// 미실행추가처방 검색 처리
		/// </summary>
		/// <param name="aFromOrderDate"> string From 처방일자 </param>
		/// <param name="aToOrderDate"> string To 처방일자 </param>
		/// <param name="aHoDong"> string 병동 </param>
		/// <param name="aHoTeam"> string 병동팀 </param>
		/// <returns> bool </returns>
		public bool QueryNoConfirmProcess(string aFromOrderDate, string aToOrderDate, string aHoDong, string aHoTeam)
		{
			// 미실행추가처방 검색 처리
			if (this.QueryNoConfirmYn(aFromOrderDate, aToOrderDate, aHoDong, aHoTeam))
			{
				return true;
			}
			
			return false;
		}
		#endregion

		#region 미실행추가처방 여부 조회 Service Call (QueryNoConfirmYn)
		/// <summary>
		/// 미실행추가처방 여부 조회 Service Call
		/// </summary>
		/// <param name="aFromOrderDate"> string From 처방일자 </param>
		/// <param name="aToOrderDate"> string To 처방일자 </param>
		/// <param name="aHoDong"> string 병동 </param>
		/// <param name="aHoTeam"> string 병동팀 </param>
		/// <returns> bool </returns>
		public bool QueryNoConfirmYn(string aFromOrderDate, string aToOrderDate, string aHoDong, string aHoTeam)
		{	
			bool isSuccess = false;

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계				

				// 입원간호처방 : 병동은 필수 간호팀은 %허용
				string from_order_date, to_order_date, ho_dong, ho_team;

				from_order_date = aFromOrderDate; to_order_date = aToOrderDate;
				ho_dong = aHoDong; ho_team = aHoTeam;

				ho_dong = this.cboHo_Dong.GetDataValue(); ho_team = this.fbxHo_Team.GetDataValue();

				if (TypeCheck.IsNull(ho_team))  ho_team = "%";		
				
				string spName = "PR_OCS_INP_ADD_ORDER_OCCUR";
	
				ArrayList inputArrayList = new ArrayList();
				inputArrayList.Add(from_order_date);
				inputArrayList.Add(to_order_date);
				inputArrayList.Add(ho_dong);
				inputArrayList.Add(ho_team);
				ArrayList outputArrayList = new ArrayList();

				if(Service.ExecuteProcedure(spName, inputArrayList, outputArrayList))
				{
					if( outputArrayList[0].ToString() == "Y") isSuccess = true;

					if( outputArrayList[1].ToString() != "0" && outputArrayList[1].ToString() != "1")
					{
						XMessageBox.Show("OCS2003Q03 : QueryNoConfirmYn / Procedure IOFlag : " + outputArrayList[1].ToString());
					}
				}


			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
			}

			return isSuccess;
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
			// TIMER처리 PR_OCS_INP_ADD_ORDER_OCCUR

			// HashTable과 연결할 Control's Setting
			foreach(object obj in this.pnlTop.Controls) this.SetHashTableBinding(this.mHtControl, obj);
			
			// Combo 세팅
			DataTable dtTemp = null;

			// 병동(반드시 입력)
			dtTemp  = this.mOrderBiz.LoadComboDataSource("ho_dong").LayoutTable;
			this.cboHo_Dong.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);

			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS2003Q03_UserChanged(this, new System.EventArgs()); //this.OnUserChanged();
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}

		private void OCS2003Q03_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
		}

		/// <summary>
		/// Screen Open시 Parameter를 받는다
		/// </summary>
		/// <remarks>
		/// 해당 등록번호와 내원정보로 입원처방 데이타 조회
		/// </remarks>
		private void OCS2003U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if (!this.timerQuery.Enabled) this.timerQuery.Enabled = true;

		}

		/// <summary>
		/// 사용자 변경시
		/// </summary>
		/// <remarks>
		/// 사용자 구분에 따른 입력필드 정의
		/// </remarks>
		private void OCS2003Q03_UserChanged(object sender, System.EventArgs e)
		{
			// Control 초기화
			this.Reset();

			// 디폴트 값 세팅			
			this.dtpFrom_Order_Date.SetDataValue(EnvironInfo.GetSysDate().AddDays(-1));
			this.dtpTo_Order_Date.SetDataValue(EnvironInfo.GetSysDate());
							
			this.fbxHo_Team.SetDataValue("");                            // 간호팀 전체	 
			this.cboHo_Dong.SetDataValue(IHIS.Framework.UserInfo.HoDong); // 간호사 병동
            this.cboHo_Dong.SetEditValue("1");
            this.cboHo_Dong.AcceptData();

			// 미실행추가처방 리스트 조회 (알림처리)
			this.QueryNoConfirmList(this.dtpFrom_Order_Date.GetDataValue(), this.dtpTo_Order_Date.GetDataValue(), 
				this.cboHo_Dong.GetDataValue(),         this.fbxHo_Team.GetDataValue(), true);
		}

		#endregion
		///////////////////////////////////////////////////////////////////////////////////////////////////////

		#region 타Screen에서 Open (Command)	
		public override object Command(string command, CommonItemCollection commandParam)
		{                       
			switch(command.Trim())
			{
				case "retrieve": // 데이타 재조회
					#region

					this.btnQuery.PerformClick();

					break;
					#endregion

				case "UserChanged": // 사용자 변경

					/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
					this.OCS2003Q03_UserChanged(this, new System.EventArgs()); //this.OnUserChanged();
					////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

					break;
			}

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

					this.btnQuery.PerformClick();

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
				case "ho_dong": // 재원검색 ho_dong

					this.fbxHo_Team.SetDataValue("");
					
					this.btnQuery.PerformClick();

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

		#region 데이타 조회
		private void btnQuery_Click(object sender, System.EventArgs e)

		{
			// 미실행추가처방 리스트 조회 Service Call
			this.QueryNoConfirmList(this.dtpFrom_Order_Date.GetDataValue(), this.dtpTo_Order_Date.GetDataValue(), 
				                    this.cboHo_Dong.GetDataValue(),         this.fbxHo_Team.GetDataValue(), false);

		}
		#endregion

		// interval 300000 => 5분에 한번씩 자동조회 
		private void timerQuery_Tick(object sender, System.EventArgs e)
		{
			this.dtpFrom_Order_Date.SetDataValue(EnvironInfo.GetSysDate().AddDays(-1));
			this.dtpTo_Order_Date.SetDataValue(EnvironInfo.GetSysDate());

			// 미실행추가처방 리스트 조회 (알림처리)
			this.QueryNoConfirmList(this.dtpFrom_Order_Date.GetDataValue(), this.dtpTo_Order_Date.GetDataValue(), 
				this.cboHo_Dong.GetDataValue(),         this.fbxHo_Team.GetDataValue(), true);
		}

		private void grdNoConfirm_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.grdNoConfirm.CurrentRowNumber < 0) return;

			int curRow = this.grdNoConfirm.CurrentRowNumber;
            ////  입원미확인처방조회 Screen Open
            //this.OpenNoConfirmQuery(this.grdNoConfirm.GetItemString(curRow, "bunho"), this.grdNoConfirm.GetItemValue(curRow, "order_date").ToString().Replace("-","/"), 
            //                        this.grdNoConfirm.GetItemValue(curRow, "fkinp1001").ToString());

            // 치료계획 화면 오픈
            this.OpenScreen_OCS6010U10(this.grdNoConfirm.GetItemString(curRow, "bunho"), this.grdNoConfirm.GetItemString(curRow, "fkinp1001"));
				
		}

        private void xButton1_Click(object sender, EventArgs e)
        {
            FormMsg form = new FormMsg();

            form.ShowDialog();
        }
		//



	}
}
