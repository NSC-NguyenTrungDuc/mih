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

namespace IHIS.NURI
{
	/// <summary>
	/// NUR4002R00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR4002R00 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XDataWindow dwNUR4002R00;
		private IHIS.Framework.XLabel lblPlan_date;
		private IHIS.Framework.XDatePicker dtpPlan_date;
		private IHIS.Framework.XDatePicker dtpReser_date;
		private IHIS.Framework.XLabel lblReser_date;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XLabel lblBunho;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel pnlLeft;
		private IHIS.Framework.XEditGrid grdInp1001;
		private IHIS.Framework.MultiLayout layQuery_1;
		private IHIS.Framework.MultiLayout layQuery_2;
		private IHIS.Framework.MultiLayout layPrint;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.MultiLayout layQuery_Nur4005;
        private MultiLayoutItem multiLayoutItem11;
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
        private XEditGridCell xEditGridCell1;
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
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem35;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR4002R00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR4002R00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblBunho = new IHIS.Framework.XLabel();
            this.dtpReser_date = new IHIS.Framework.XDatePicker();
            this.lblReser_date = new IHIS.Framework.XLabel();
            this.dtpPlan_date = new IHIS.Framework.XDatePicker();
            this.lblPlan_date = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dwNUR4002R00 = new IHIS.Framework.XDataWindow();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdInp1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.layQuery_1 = new IHIS.Framework.MultiLayout();
            this.layQuery_2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.layPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.layQuery_Nur4005 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery_Nur4005)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBunho);
            this.pnlTop.Controls.Add(this.dtpReser_date);
            this.pnlTop.Controls.Add(this.lblReser_date);
            this.pnlTop.Controls.Add(this.dtpPlan_date);
            this.pnlTop.Controls.Add(this.lblPlan_date);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1220, 31);
            this.pnlTop.TabIndex = 0;
            // 
            // lblBunho
            // 
            this.lblBunho.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBunho.EdgeRounding = false;
            this.lblBunho.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBunho.Location = new System.Drawing.Point(1, 5);
            this.lblBunho.Name = "lblBunho";
            this.lblBunho.Size = new System.Drawing.Size(68, 20);
            this.lblBunho.TabIndex = 5;
            this.lblBunho.Text = "患者番号";
            this.lblBunho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpReser_date
            // 
            this.dtpReser_date.IsJapanYearType = true;
            this.dtpReser_date.Location = new System.Drawing.Point(1072, 5);
            this.dtpReser_date.Name = "dtpReser_date";
            this.dtpReser_date.Size = new System.Drawing.Size(115, 20);
            this.dtpReser_date.TabIndex = 3;
            this.dtpReser_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpReser_date.Visible = false;
            // 
            // lblReser_date
            // 
            this.lblReser_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblReser_date.EdgeRounding = false;
            this.lblReser_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblReser_date.Location = new System.Drawing.Point(995, 5);
            this.lblReser_date.Name = "lblReser_date";
            this.lblReser_date.Size = new System.Drawing.Size(77, 20);
            this.lblReser_date.TabIndex = 2;
            this.lblReser_date.Text = "評価日付";
            this.lblReser_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReser_date.Visible = false;
            // 
            // dtpPlan_date
            // 
            this.dtpPlan_date.IsJapanYearType = true;
            this.dtpPlan_date.Location = new System.Drawing.Point(879, 5);
            this.dtpPlan_date.Name = "dtpPlan_date";
            this.dtpPlan_date.Size = new System.Drawing.Size(115, 20);
            this.dtpPlan_date.TabIndex = 1;
            this.dtpPlan_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpPlan_date.Visible = false;
            // 
            // lblPlan_date
            // 
            this.lblPlan_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblPlan_date.EdgeRounding = false;
            this.lblPlan_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblPlan_date.Location = new System.Drawing.Point(802, 5);
            this.lblPlan_date.Name = "lblPlan_date";
            this.lblPlan_date.Size = new System.Drawing.Size(77, 20);
            this.lblPlan_date.TabIndex = 0;
            this.lblPlan_date.Text = "作成日付";
            this.lblPlan_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlan_date.Visible = false;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(1220, 31);
            this.paBox.TabIndex = 4;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 555);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1220, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(976, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dwNUR4002R00
            // 
            this.dwNUR4002R00.DataWindowObject = "dw_nur4002r00";
            this.dwNUR4002R00.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwNUR4002R00.LibraryList = "..\\NURI\\nuri.nur4002r00.pbd";
            this.dwNUR4002R00.Location = new System.Drawing.Point(405, 31);
            this.dwNUR4002R00.Name = "dwNUR4002R00";
            this.dwNUR4002R00.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwNUR4002R00.Size = new System.Drawing.Size(815, 524);
            this.dwNUR4002R00.TabIndex = 2;
            this.dwNUR4002R00.Text = "xDataWindow1";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdInp1001);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 31);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(405, 524);
            this.pnlLeft.TabIndex = 3;
            // 
            // grdInp1001
            // 
            this.grdInp1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell1});
            this.grdInp1001.ColPerLine = 3;
            this.grdInp1001.Cols = 4;
            this.grdInp1001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInp1001.FixedCols = 1;
            this.grdInp1001.FixedRows = 1;
            this.grdInp1001.HeaderHeights.Add(21);
            this.grdInp1001.Location = new System.Drawing.Point(0, 0);
            this.grdInp1001.Name = "grdInp1001";
            this.grdInp1001.QuerySQL = resources.GetString("grdInp1001.QuerySQL");
            this.grdInp1001.ReadOnly = true;
            this.grdInp1001.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdInp1001.RowHeaderVisible = true;
            this.grdInp1001.Rows = 2;
            this.grdInp1001.Size = new System.Drawing.Size(405, 524);
            this.grdInp1001.TabIndex = 0;
            this.grdInp1001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdInp1001_GridCellPainting);
            this.grdInp1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdInp1001_RowFocusChanged);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "pknur4002";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "pknur4002";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "bunho";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "bunho";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "fkinp1001";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "fkinp1001";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "nur_plan_jin";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "nur_plan_jin";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ApplyPaintingEvent = true;
            this.xEditGridCell7.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell7.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell7.CellName = "plan_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 90;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "作成日付";
            this.xEditGridCell7.IsJapanYearType = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.ApplyPaintingEvent = true;
            this.xEditGridCell8.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell8.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell8.CellName = "nur_plan_proname";
            this.xEditGridCell8.CellWidth = 246;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "看護診断名";
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplyPaintingEvent = true;
            this.xEditGridCell1.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell1.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell1.CellName = "vald";
            this.xEditGridCell1.CellWidth = 35;
            this.xEditGridCell1.CheckedValue = "N";
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "終了";
            this.xEditGridCell1.UnCheckedValue = "Y";
            // 
            // layQuery_1
            // 
            this.layQuery_1.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem32,
            this.multiLayoutItem35});
            this.layQuery_1.QuerySQL = resources.GetString("layQuery_1.QuerySQL");
            this.layQuery_1.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layQuery_1_QueryStarting);
            // 
            // layQuery_2
            // 
            this.layQuery_2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15});
            this.layQuery_2.QuerySQL = resources.GetString("layQuery_2.QuerySQL");
            this.layQuery_2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layQuery_2_QueryStarting);
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "nur_plan";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "nur_plan_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "nur_plan_detail";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "nur_plan_detail_name";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "reser_date";
            // 
            // layPrint
            // 
            this.layPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "nur_plan_detail_name";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "reser_date";
            // 
            // layQuery_Nur4005
            // 
            this.layQuery_Nur4005.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21});
            this.layQuery_Nur4005.QuerySQL = resources.GetString("layQuery_Nur4005.QuerySQL");
            this.layQuery_Nur4005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layQuery_Nur4005_QueryStarting);
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "valu_date";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "valu_user_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "valu_contents";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "tag";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "ho_dong_name";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "bunho";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "birth";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "age";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "sex";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "plan_date";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "plan_user_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "nur_plan_proname";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "nur_plan_ote";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "nur_plan_name";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "nur_plan_detail_name";
            // 
            // NUR4002R00
            // 
            this.Controls.Add(this.dwNUR4002R00);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR4002R00";
            this.Size = new System.Drawing.Size(1220, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR4002R00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layQuery_Nur4005)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region 재원이력조회
		private void SetInp1001()
		{
			if (this.paBox.BunHo.ToString() == "") return;

            this.grdInp1001.Reset();
            this.grdInp1001.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdInp1001.SetBindVarValue("f_bunho", paBox.BunHo);
			if (!this.grdInp1001.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}
		#endregion

		#region 간호계획출력내용을 조회
		private void SetNur4002()
		{
			string nur_plan = string.Empty;

			if (this.paBox.BunHo.ToString() == "") return;

			if (this.grdInp1001.RowCount == 0) return;

			if (this.dtpPlan_date.GetDataValue().ToString() == "") return;

			if (this.dtpReser_date.GetDataValue().ToString() == "") return;

			this.dwNUR4002R00.Reset();

			this.layQuery_1.Reset();
			this.layQuery_2.Reset();
			this.layPrint.Reset();

			//조회1
			if (this.layQuery_1.QueryLayout(true))
			{
                this.dwNUR4002R00.FillChildData("dw_1", this.layQuery_1.LayoutTable);
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}


            /*
			//조회2
			this.layQuery_2.SetBindVarValue("f_nur_plan_ote", "O");

			this.layQuery_2.Reset();
			this.layPrint.Reset();
			nur_plan = "";

			if (this.layQuery_2.QueryLayout(true))
			{
				if (this.layQuery_2.RowCount > 0)
				{
					for (int i = 0; i < this.layQuery_2.RowCount; i++)
					{
						int aRow = this.layPrint.InsertRow(-1);
						string aText = string.Empty;

						if (nur_plan != this.layQuery_2.GetItemValue(i, "nur_plan").ToString())
						{
							if (this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString() != "")
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_name").ToString() + "\r\n" + this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString();
							}
							else
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_name").ToString();
							}
						}
						else
						{
							if (this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString() != "")
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString();
							}
						}
						
						this.layPrint.SetItemValue(aRow, "nur_plan_detail_name", aText);

						nur_plan = this.layQuery_2.GetItemValue(i, "nur_plan").ToString();
					}

					this.layPrint.InsertRow(-1);

					this.dwNUR4002R00.FillChildData("dw_2", this.layPrint.LayoutTable);
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}

			//조회3
			this.layQuery_2.SetBindVarValue("f_nur_plan_ote", "T");

			this.layQuery_2.Reset();
			this.layPrint.Reset();
			nur_plan = "";

			if (this.layQuery_2.QueryLayout(true))
			{
				if (this.layQuery_2.RowCount > 0)
				{
					for (int i = 0; i < this.layQuery_2.RowCount; i++)
					{
						int aRow = this.layPrint.InsertRow(-1);
						string aText = string.Empty;

						if (nur_plan != this.layQuery_2.GetItemValue(i, "nur_plan").ToString())
						{
							if (this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString() != "")
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_name").ToString() + "\r\n" + this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString();
							}
							else
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_name").ToString();
							}
						}
						else
						{
							if (this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString() != "")
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString();
							}
						}
						
						this.layPrint.SetItemValue(aRow, "nur_plan_detail_name", aText);
				
						nur_plan = this.layQuery_2.GetItemValue(i, "nur_plan").ToString();
					}

					this.layPrint.InsertRow(-1);

					this.dwNUR4002R00.FillChildData("dw_3", this.layPrint.LayoutTable);
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}

			//조회4
			this.layQuery_2.SetBindVarValue("f_nur_plan_ote", "E");

			this.layQuery_2.Reset();
			this.layPrint.Reset();
			nur_plan = "";

			if (this.layQuery_2.QueryLayout(true))
			{
				if (this.layQuery_2.RowCount > 0)
				{
					for (int i = 0; i < this.layQuery_2.RowCount; i++)
					{
						int aRow = this.layPrint.InsertRow(-1);
						string aText = string.Empty;

						if (nur_plan != this.layQuery_2.GetItemValue(i, "nur_plan").ToString())
						{
							if (this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString() != "")
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_name").ToString() + "\r\n" + this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString();
							}
							else
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_name").ToString();
							}
						}
						else
						{
							if (this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString() != "")
							{
								aText = this.layQuery_2.GetItemValue(i, "nur_plan_detail_name").ToString();
							}
						}
						
						this.layPrint.SetItemValue(aRow, "nur_plan_detail_name", aText);
				
						nur_plan = this.layQuery_2.GetItemValue(i, "nur_plan").ToString();
					}

					this.layPrint.InsertRow(-1);

					// 평가일자 셋팅 
                    //for (int i = 0; i < this.layPrint.RowCount; i++)
                    //{
                    //    this.layPrint.SetItemValue(i, "reser_date", this.dtpReser_date.Text.ToString());
                    //}
				
					this.dwNUR4002R00.FillChildData("dw_4", this.layPrint.LayoutTable);
				}
				else
				{
					this.layPrint.InsertRow(0);
                    //this.layPrint.SetItemValue(0, "reser_date", this.dtpReser_date.Text.ToString());

					this.dwNUR4002R00.FillChildData("dw_4", this.layPrint.LayoutTable);
				}
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
             * */

			//평가정보조회
			this.layQuery_Nur4005.Reset();

			if (this.layQuery_Nur4005.QueryLayout(true))
			{
				this.dwNUR4002R00.FillChildData("dw_5", this.layQuery_Nur4005.LayoutTable);
			}
			else
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return;
			}
		}
		#endregion

		#region Screen Load

        string mHospCode = "";
		private void NUR4002R00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            mHospCode = EnvironInfo.HospCode;

			if(this.OpenStyle == ScreenOpenStyle.PopUpFixed || this.OpenStyle == ScreenOpenStyle.PopUpSizable)
			{
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
				this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);
			}

            this.dtpPlan_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpPlan_date.AcceptData();

            this.dtpReser_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpReser_date.AcceptData();

			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(!TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
						{
							this.paBox.SetPatientID(OpenParam["bunho"].ToString().Trim());
						}
					}
				}
				catch (Exception ex)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//XMessageBox.Show(ex.Message, "");						
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

		#region 환자번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			/* 재원이력을 조회한다. */
			SetInp1001();
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					if (!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
						return;
					}

					e.IsBaseCall = false;

                    /* 재원이력을 조회한다. */
                    SetInp1001();
					//조회
					SetNur4002();
					break;
				case FunctionType.Print:
					this.dwNUR4002R00.Print(true);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 그리드에서 선택을 했을 때 조회처리
		private void grdInp1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (this.grdInp1001.RowCount != 0 && this.grdInp1001.CurrentRowNumber >= 0)
			{
				//조회
				SetNur4002();
			}
		}
		#endregion

        private void layQuery_1_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layQuery_1.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layQuery_1.SetBindVarValue("f_fkinp1001", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "fkinp1001"));
            this.layQuery_1.SetBindVarValue("f_bunho", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "bunho"));
            this.layQuery_1.SetBindVarValue("f_plan_date", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "plan_date"));
            this.layQuery_1.SetBindVarValue("f_pknur4002", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "pknur4002"));
        }

        private void layQuery_2_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layQuery_2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layQuery_2.SetBindVarValue("f_fkinp1001", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "fkinp1001"));
            this.layQuery_2.SetBindVarValue("f_bunho", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "bunho"));
            this.layQuery_2.SetBindVarValue("f_plan_date", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "plan_date"));
            this.layQuery_2.SetBindVarValue("f_reser_date", this.dtpReser_date.GetDataValue());
            this.layQuery_2.SetBindVarValue("f_pknur4002", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "pknur4002"));

        }

        private void layQuery_Nur4005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layQuery_Nur4005.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layQuery_Nur4005.SetBindVarValue("f_pknur4002", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "pknur4002"));
        }

        private void grdInp1001_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["vald"].ToString() == "N")
            {
                e.BackColor = Color.LightGreen;
            }

        }
	}
}

