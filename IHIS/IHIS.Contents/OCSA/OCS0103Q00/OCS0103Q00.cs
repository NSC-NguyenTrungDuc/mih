#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using System.Text.RegularExpressions;
using IHIS.OCSA.Properties;




#endregion


namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0103Q00에 대한 요약 설명입니다.
	/// </summary>
	public class OCS0103Q00 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]		
		//Message처리
		private string mbxMsg = "", mbxCap = "";		
		private string mHangmog_code = "";
		private bool   mMultiSelect  = true;

		//환자등록번호
		private string mBunho = "";
        //HOSP_CODE
        private string mHospCode = EnvironInfo.HospCode;

        // INPUT TAB
        private string mInputTab = "%";

        // Child YN 
        private string mChildYN = "%";

        private IHIS.OCS.OrderBiz mOrderBiz = null;           // OCS 그룹 Business 라이브러리	
        private IHIS.OCS.ColumnControl mColumnControl = null; // OCS 그룹 Column Control 라이브러리
		#endregion

		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XPanel pnlQuery;
		private IHIS.Framework.XComboBox cboQuery_gubun;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XTextBox txtHangmog_index;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XTabControl tabQuery;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XGrid grdHangmogInfo;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell4;
        private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.MultiLayout dloReturnValue;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XRadioButton rbtSearchAll;
		private IHIS.Framework.XRadioButton rbtSearchStart;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
		private System.Windows.Forms.ToolTip toolTip1;
        private Button button1;
        private XGridCell xGridCell6;
        private XGridCell xGridCell10;
        private XGridCell xGridCell11;
        private XGridCell xGridCell12;
		private System.ComponentModel.IContainer components;

		public OCS0103Q00()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			// TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리

            // 
            grdHangmogInfo.ParamList = new List<string>(new String[] { "f_query_code", "f_order_gubun", "f_input_tab", "f_child_yn", "f_page_number", });

            // deleted by AnhNV (use GrdHangmogInfo_ExecuteQuery2)
		    //grdHangmogInfo.ExecuteQuery = GrdHangmogInfo_ExecuteQuery;
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103Q00));
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.pnlQuery = new IHIS.Framework.XPanel();
            this.rbtSearchStart = new IHIS.Framework.XRadioButton();
            this.rbtSearchAll = new IHIS.Framework.XRadioButton();
            this.cboQuery_gubun = new IHIS.Framework.XComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtHangmog_index = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdHangmogInfo = new IHIS.Framework.XGrid();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.xGridCell11 = new IHIS.Framework.XGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.tabQuery = new IHIS.Framework.XTabControl();
            this.dloReturnValue = new IHIS.Framework.MultiLayout();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.xGridCell12 = new IHIS.Framework.XGridCell();
            this.pnlQuery.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmogInfo)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ImageIndex = 1;
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ImageIndex = 1;
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ImageIndex = 1;
            this.xComboItem3.ValueItem = "2";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ImageIndex = 1;
            this.xComboItem4.ValueItem = "3";
            // 
            // pnlQuery
            // 
            this.pnlQuery.AccessibleDescription = null;
            this.pnlQuery.AccessibleName = null;
            resources.ApplyResources(this.pnlQuery, "pnlQuery");
            this.pnlQuery.BackgroundImage = null;
            this.pnlQuery.Controls.Add(this.rbtSearchStart);
            this.pnlQuery.Controls.Add(this.rbtSearchAll);
            this.pnlQuery.Controls.Add(this.cboQuery_gubun);
            this.pnlQuery.Controls.Add(this.xLabel1);
            this.pnlQuery.Controls.Add(this.xLabel3);
            this.pnlQuery.Controls.Add(this.txtHangmog_index);
            this.pnlQuery.Controls.Add(this.xLabel2);
            this.pnlQuery.DrawBorder = true;
            this.pnlQuery.Font = null;
            this.pnlQuery.Name = "pnlQuery";
            this.toolTip1.SetToolTip(this.pnlQuery, resources.GetString("pnlQuery.ToolTip"));
            // 
            // rbtSearchStart
            // 
            this.rbtSearchStart.AccessibleDescription = null;
            this.rbtSearchStart.AccessibleName = null;
            resources.ApplyResources(this.rbtSearchStart, "rbtSearchStart");
            this.rbtSearchStart.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtSearchStart.BackgroundImage = null;
            this.rbtSearchStart.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtSearchStart.ImageList = this.ImageList;
            this.rbtSearchStart.Name = "rbtSearchStart";
            this.toolTip1.SetToolTip(this.rbtSearchStart, resources.GetString("rbtSearchStart.ToolTip"));
            this.rbtSearchStart.UseVisualStyleBackColor = false;
            // 
            // rbtSearchAll
            // 
            this.rbtSearchAll.AccessibleDescription = null;
            this.rbtSearchAll.AccessibleName = null;
            resources.ApplyResources(this.rbtSearchAll, "rbtSearchAll");
            this.rbtSearchAll.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtSearchAll.BackgroundImage = null;
            this.rbtSearchAll.Checked = true;
            this.rbtSearchAll.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtSearchAll.ImageList = this.ImageList;
            this.rbtSearchAll.Name = "rbtSearchAll";
            this.rbtSearchAll.TabStop = true;
            this.toolTip1.SetToolTip(this.rbtSearchAll, resources.GetString("rbtSearchAll.ToolTip"));
            this.rbtSearchAll.UseVisualStyleBackColor = false;
            this.rbtSearchAll.CheckedChanged += new System.EventHandler(this.rbtSearchAll_CheckedChanged);
            // 
            // cboQuery_gubun
            // 
            this.cboQuery_gubun.AccessibleDescription = null;
            this.cboQuery_gubun.AccessibleName = null;
            resources.ApplyResources(this.cboQuery_gubun, "cboQuery_gubun");
            this.cboQuery_gubun.BackgroundImage = null;
            this.cboQuery_gubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4});
            this.cboQuery_gubun.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQuery_gubun.DropDownWidth = 200;
            this.cboQuery_gubun.Name = "cboQuery_gubun";
            this.toolTip1.SetToolTip(this.cboQuery_gubun, resources.GetString("cboQuery_gubun.ToolTip"));
            this.cboQuery_gubun.SelectedIndexChanged += new System.EventHandler(this.cboQuery_gubun_SelectedIndexChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            this.toolTip1.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // txtHangmog_index
            // 
            this.txtHangmog_index.AccessibleDescription = null;
            this.txtHangmog_index.AccessibleName = null;
            resources.ApplyResources(this.txtHangmog_index, "txtHangmog_index");
            this.txtHangmog_index.BackgroundImage = null;
            this.txtHangmog_index.Name = "txtHangmog_index";
            this.toolTip1.SetToolTip(this.txtHangmog_index, resources.GetString("txtHangmog_index.ToolTip"));
            this.txtHangmog_index.ImeModeChanged += new System.EventHandler(this.txtHangmog_index_ImeModeChanged);
            this.txtHangmog_index.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHangmog_index_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XGridColHeaderGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdHangmogInfo);
            this.xPanel3.Controls.Add(this.xPanel1);
            this.xPanel3.Controls.Add(this.tabQuery);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip1.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // grdHangmogInfo
            // 
            resources.ApplyResources(this.grdHangmogInfo, "grdHangmogInfo");
            this.grdHangmogInfo.ApplyPaintEventToAllColumn = true;
            this.grdHangmogInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell1,
            this.xGridCell4,
            this.xGridCell12,
            this.xGridCell5,
            this.xGridCell9,
            this.xGridCell7,
            this.xGridCell6,
            this.xGridCell8,
            this.xGridCell10,
            this.xGridCell11});
            this.grdHangmogInfo.ColPerLine = 5;
            this.grdHangmogInfo.Cols = 5;
            this.grdHangmogInfo.ExecuteQuery = null;
            this.grdHangmogInfo.FixedRows = 1;
            this.grdHangmogInfo.HeaderHeights.Add(24);
            this.grdHangmogInfo.Name = "grdHangmogInfo";
            this.grdHangmogInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdHangmogInfo.ParamList")));
            this.grdHangmogInfo.Rows = 2;
            this.grdHangmogInfo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.toolTip1.SetToolTip(this.grdHangmogInfo, resources.GetString("grdHangmogInfo.ToolTip"));
            this.grdHangmogInfo.ToolTipActive = true;
            this.grdHangmogInfo.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdHangmogInfo_GridCellPainting);
            this.grdHangmogInfo.GridContDisplayed += new IHIS.Framework.XGridContDisplayedEventHandler(this.grdHangmogInfo_GridContDisplayed);
            this.grdHangmogInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdHangmogInfo_MouseDown);
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "order_gubun";
            this.xGridCell2.Col = -1;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.IsVisible = false;
            this.xGridCell2.Row = -1;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "slip_code";
            this.xGridCell3.Col = -1;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            this.xGridCell3.IsVisible = false;
            this.xGridCell3.Row = -1;
            // 
            // xGridCell1
            // 
            this.xGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell1.CellName = "slip_name";
            this.xGridCell1.CellWidth = 143;
            this.xGridCell1.Col = 1;
            this.xGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xGridCell1.SuppressRepeating = true;
            // 
            // xGridCell4
            // 
            this.xGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell4.CellName = "hangmog_code";
            this.xGridCell4.CellWidth = 117;
            this.xGridCell4.Col = 2;
            this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridCell5
            // 
            this.xGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell5.CellName = "hangmog_name";
            this.xGridCell5.CellWidth = 299;
            this.xGridCell5.Col = 4;
            this.xGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            this.xGridCell5.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell5.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "sg_code";
            this.xGridCell9.Col = -1;
            resources.ApplyResources(this.xGridCell9, "xGridCell9");
            this.xGridCell9.IsVisible = false;
            this.xGridCell9.Row = -1;
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "bulyong_check";
            this.xGridCell7.Col = -1;
            resources.ApplyResources(this.xGridCell7, "xGridCell7");
            this.xGridCell7.IsVisible = false;
            this.xGridCell7.Row = -1;
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "wonnae_drg_yn";
            this.xGridCell6.Col = -1;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            this.xGridCell6.IsVisible = false;
            this.xGridCell6.Row = -1;
            // 
            // xGridCell8
            // 
            this.xGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell8.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell8.CellName = "select";
            this.xGridCell8.CellWidth = 43;
            this.xGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell8, "xGridCell8");
            this.xGridCell8.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xGridCell8.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell8.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "input_control";
            this.xGridCell10.Col = -1;
            resources.ApplyResources(this.xGridCell10, "xGridCell10");
            this.xGridCell10.IsVisible = false;
            this.xGridCell10.Row = -1;
            // 
            // xGridCell11
            // 
            this.xGridCell11.CellName = "bun_code";
            this.xGridCell11.Col = -1;
            resources.ApplyResources(this.xGridCell11, "xGridCell11");
            this.xGridCell11.IsVisible = false;
            this.xGridCell11.Row = -1;
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.button1);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.toolTip1.SetToolTip(this.button1, resources.GetString("button1.ToolTip"));
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Process, -1, global::IHIS.OCSA.Properties.Resources.btn_Process),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Search, -1, global::IHIS.OCSA.Properties.Resources.btn_Search),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Exit, -1, global::IHIS.OCSA.Properties.Resources.btn_Exit)});
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.toolTip1.SetToolTip(this.xButtonList1, resources.GetString("xButtonList1.ToolTip"));
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // tabQuery
            // 
            this.tabQuery.AccessibleDescription = null;
            this.tabQuery.AccessibleName = null;
            resources.ApplyResources(this.tabQuery, "tabQuery");
            this.tabQuery.Appearance = IHIS.X.Magic.Common.VisualAppearance.MultiBox;
            this.tabQuery.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.tabQuery.BackgroundImage = null;
            this.tabQuery.BoldSelectedPage = true;
            this.tabQuery.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabQuery.Font = null;
            this.tabQuery.IDEPixelArea = true;
            this.tabQuery.ImageList = this.ImageList;
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.ShowArrows = true;
            this.tabQuery.ShrinkPagesToFit = false;
            this.toolTip1.SetToolTip(this.tabQuery, resources.GetString("tabQuery.ToolTip"));
            this.tabQuery.SelectionChanged += new System.EventHandler(this.tabQuery_SelectionChanged);
            // 
            // dloReturnValue
            // 
            this.dloReturnValue.ExecuteQuery = null;
            this.dloReturnValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloReturnValue.ParamList")));
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // xGridCell12
            // 
            this.xGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell12.CellName = "accounting Code";
            this.xGridCell12.CellWidth = 218;
            this.xGridCell12.Col = 3;
            this.xGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell12, "xGridCell12");
            // 
            // OCS0103Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.pnlQuery);
            this.Name = "OCS0103Q00";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.pnlQuery.ResumeLayout(false);
            this.pnlQuery.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmogInfo)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnValue)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            this.mOrderBiz = new IHIS.OCS.OrderBiz(TypeCheck.NVL(this.ScreenID, this.Name).ToString());
            this.mColumnControl = new IHIS.OCS.ColumnControl(TypeCheck.NVL(this.ScreenID, this.Name).ToString());
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("hangmog_code"))
					{
						if(OpenParam["hangmog_code"].ToString().Trim() != "")
						{
							mHangmog_code = OpenParam["hangmog_code"].ToString();
							txtHangmog_index.SetDataValue(mHangmog_code);

						}
					}

					if(OpenParam.Contains("multiSelection"))
					{
						if(TypeCheck.IsBoolean(OpenParam["multiSelection"]))
						{
							mMultiSelect = bool.Parse(OpenParam["multiSelection"].ToString());							
						}
					}

					if(OpenParam.Contains("bunho"))
					{
						if(!TypeCheck.IsNull(OpenParam["bunho"].ToString()))
						{
							mBunho = OpenParam["bunho"].ToString();
						}
					}

                    if (OpenParam.Contains("input_tab"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["input_tab"].ToString()))
                        {
                            this.mInputTab = OpenParam["input_tab"].ToString();
                        }
                    }

                    if (OpenParam.Contains("child_yn"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["child_yn"].ToString()))
                        {
                            this.mChildYN = this.OpenParam["child_yn"].ToString();
                        }
                    }
				}
				catch
				{
				}
			}

			PostCallHelper.PostCall(new PostMethod(PostLoad));		
		}
		

		private void PostLoad()
		{	
			cboQuery_gubun.SelectedIndex = 0;

			CreateLayout();
			CreateOrder_gubun();			

			//mHangmog_code가 존재하면 항목정보 Load
			//			if(mHangmog_code.Trim().Length > 0)
			//			{
			//				this.txtHangmog_index.SetDataValue(mHangmog_code);
			//				LoadOCS0103();
			//			}

			txtHangmog_index.Focus();
			txtHangmog_index.SelectAll();

			this.txtHangmog_index.ImeMode = System.Windows.Forms.ImeMode.Disable;
		

		}

		private void CreateLayout()
		{
			// LayoutItems 생성
			foreach(XGridCell cell in grdHangmogInfo.CellInfos)
			{
				dloReturnValue.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

			dloReturnValue.InitializeLayoutTable();				
		}

		#endregion

		#region [Combo 정보]
        
		/// <summary>
		/// 선택한 cboItem정보를 표시합니다.
		/// </summary>		
		private void SetComboItemImage(int selectIndex)
		{
			if( selectIndex < 0) return;

			for(int i = 0; i < cboQuery_gubun.ComboItems.Count; i ++)
			{
				if(i == selectIndex )
					cboQuery_gubun.ComboItems[i].ImageIndex = 1;
				else
					cboQuery_gubun.ComboItems[i].ImageIndex = 0;

			}
		}

		private void cboQuery_gubun_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetComboItemImage(cboQuery_gubun.SelectedIndex);	
		}

		#endregion

		#region [Tab 정보]
        
		/// <summary>
		/// Order_gubun을 tab으로 생성합니다.
		/// </summary>
		private void CreateOrder_gubun()
		{	
			tabQuery.BackColor = XColor.XPanelBackColor;
			tabQuery.Cursor = Cursors.Hand;
				
			IHIS.X.Magic.Controls.TabPage page = new IHIS.X.Magic.Controls.TabPage(Properties.Resources.tabpage);
			page.Tag = "%";
			page.ImageIndex = 1;
			page.BackColor = XColor.XDisplayBoxBackColor.Color;			
			tabQuery.TabPages.Add(page);
            
			//Tab page생성
			IHIS.Framework.MultiLayout layoutCombo;
			layoutCombo = new MultiLayout();

			//처방구분 DataLayout;
			layoutCombo.Reset();
			layoutCombo.LayoutItems.Clear();
			layoutCombo.LayoutItems.Add("code", DataType.String);
			layoutCombo.LayoutItems.Add("code_name", DataType.String);
			layoutCombo.InitializeLayoutTable();

//            layoutCombo.QuerySQL = @"SELECT DISTINCT A.CODE, A.CODE_NAME, A.SORT_KEY
//                                       FROM OCS0132 A
//                                          , OCS0142 B
//                                      WHERE A.CODE_TYPE = 'ORDER_GUBUN_BAS'
//                                        AND A.HOSP_CODE = :f_hosp_code
//                                        AND A.CODE      = B.ORDER_GUBUN
//                                        AND B.INPUT_TAB LIKE :f_input_tab 
//                                      ORDER BY A.SORT_KEY";

            layoutCombo.ParamList = new List<string>(new String[] { "f_input_tab" });
		    layoutCombo.ExecuteQuery = layoutCombo_ExecuteQuery;
            layoutCombo.SetBindVarValue("f_hosp_code", mHospCode);
            layoutCombo.SetBindVarValue("f_input_tab", mInputTab);
            if(layoutCombo.QueryLayout(false))
            {
				foreach(DataRow row in layoutCombo.LayoutTable.Rows)
				{
					page = new IHIS.X.Magic.Controls.TabPage(row["code_name"].ToString());
					page.Tag = row["code"];
					page.ImageIndex = 0;
					page.BackColor = IHIS.Framework.XColor.XDisplayBoxBackColor.Color;
					tabQuery.TabPages.Add(page);
				}				
			}

			tabQuery.SelectedIndex = 0;

		}

		private void tabQuery_SelectionChanged(object sender, System.EventArgs e)
		{
			foreach( IHIS.X.Magic.Controls.TabPage page in tabQuery.TabPages)
			{
				if(tabQuery.SelectedTab == page)
					page.ImageIndex = 1;
				else
					page.ImageIndex = 0;
			}

			LoadOCS0103();
		}

		#endregion

		#region [Function]
		/// <summary>
		/// 선택한정보를 dloReturnValue로 생성합니다.		
		/// </summary>
		private void CreateReturnValue()
		{  
			dloReturnValue.LayoutTable.Rows.Clear();
			
			try
			{
				//선택한 정보 import
				for(int i = 0; i < grdHangmogInfo.RowCount; i ++)
				{
					if(grdHangmogInfo.GetItemString(i, "select") == " ")
						dloReturnValue.LayoutTable.ImportRow(grdHangmogInfo.LayoutTable.Rows[i]);
				}
			}
			catch
			{				
				
			}

			if(dloReturnValue.LayoutTable.Rows.Count < 1 )
			{
                mbxMsg = Resources.XMessageBox1;
				mbxCap = Resources.Caption1;
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;									
			}


            /* ★呼び出し画面に返すものの確認
            for (int i = 0; i < dloReturnValue.RowCount ;i++)
            {
                XMessageBox.Show("order_gubun: " + dloReturnValue.GetItemString(i, "order_gubun") + "\r\n"+
                                 "slip_code: " + dloReturnValue.GetItemString(i, "slip_code") + "\r\n" +
                                 "slip_name: " + dloReturnValue.GetItemString(i, "slip_name") + "\r\n" +
                                 "hangmog_code: " + dloReturnValue.GetItemString(i, "hangmog_code") + "\r\n" +
                                 "hangmog_name: " + dloReturnValue.GetItemString(i, "hangmog_name") + "\r\n" +
                                 "sg_code: " + dloReturnValue.GetItemString(i, "sg_code") + "\r\n" +
                                 "bulyong_check: " + dloReturnValue.GetItemString(i, "bulyong_check") + "\r\n" +
                                 "select: " + dloReturnValue.GetItemString(i, "select"));
             
            }
            */


			//Return Value
            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS0103", dloReturnValue);
            commandParams.Add("hangmog_name", grdHangmogInfo.GetItemString(grdHangmogInfo.CurrentRowNumber, "hangmog_name"));
			scrOpener.Command(ScreenID, commandParams);
			this.Close();
		}

		/// <summary>
		/// 항목정보를 조회합니다.
		/// </summary>
		private void LoadOCS0103()
		{			
			string query_gubun = cboQuery_gubun.GetDataValue();
            string query_code = this.txtHangmog_index.GetDataValue().Trim();
			string order_gubun = tabQuery.SelectedTab.Tag.ToString();
            //Fix bug MED-8876 
            //if( query_code == "%" ||
            //    query_code == "")
            //{
            //    return;	
            //}
            
			//grdHangmogInfo.SetBindVarValue("f_query_code",  query_code);

            // Linhnt Comment
//            grdHangmogInfo.QuerySQL = this.GetQuerySql(query_code);
            grdHangmogInfo.SetBindVarValue("f_query_code", this.GetQuerySql(query_code));
            grdHangmogInfo.SetBindVarValue("f_order_gubun", order_gubun);
            grdHangmogInfo.SetBindVarValue("f_hosp_code",   mHospCode);
            grdHangmogInfo.SetBindVarValue("f_input_tab", mInputTab);
            
            ////약,주사인 경우는 검색어가 3자리 이상이어야 조회한다.
            //if( txtHangmog_index.GetDataValue().Trim().Length >= 3)
            //    grdHangmogInfo.SetBindVarValue("f_drg_yn", "Y");
            //else
            //    grdHangmogInfo.SetBindVarValue("f_drg_yn", "N");

            // 부모자식 여부
            grdHangmogInfo.SetBindVarValue("f_child_yn", this.mChildYN);            
            grdHangmogInfo.ExecuteQuery = GrdHangmogInfo_ExecuteQuery2;
            //Fix bug MED-8876
            //if (grdHangmogInfo.QueryLayout(true))
            //{				
            //}
            grdHangmogInfo.QueryLayout(false);
			SelectionBackColorChange(grdHangmogInfo);

			return;
		}

        private string LoadKatakanaFull(string aText)
        {
//            string cmd = "SELECT FN_ADM_CONVERT_KATAKANA_FULL('" + aText + "' )"
//                       + "  FROM DUAL ";
//            object retValue = Service.ExecuteScalar(cmd);

            OCS0103Q00LoadKatakanaFullArgs args = new OCS0103Q00LoadKatakanaFullArgs();
            args.Text = aText;
            OCS0103Q00LoadKatakanaFullResult retValue = CloudService.Instance.Submit<OCS0103Q00LoadKatakanaFullResult, OCS0103Q00LoadKatakanaFullArgs>(args);
            if (retValue == null || retValue.ExecutionStatus != ExecutionStatus.Success)
                return "";

            return retValue.Result;
        }

        private string GetQuerySql(string aText)
        {
            string searchWord = "";
//            string cmd = " SELECT FN_ADM_CONVERT_KATAKANA_FULL('" + aText + "' ) FROM DUAL";
//            object returnVal = null ;
            //turning perfomance
            if (String.IsNullOrEmpty(aText))
            {
                return searchWord;
            }
            
            // 2016.03.01 fixed bug https://sofiamedix.atlassian.net/browse/MED-7989
            // Load full width Katakana
            if (NetInfo.Language != LangMode.Jr || aText == "%")
            {
                return aText;
            }

            OCS0103Q00LoadKatakanaFullArgs args = new OCS0103Q00LoadKatakanaFullArgs();
            args.Text = aText;
            OCS0103Q00LoadKatakanaFullResult result = null;

            if (aText != "%")
            {
//                returnVal = Service.ExecuteScalar(cmd);
                result = CloudService.Instance.Submit<OCS0103Q00LoadKatakanaFullResult, OCS0103Q00LoadKatakanaFullArgs>(args);
            }

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.Result != "" && result.Result != "%")
            {
                searchWord = result.Result;
            }

    //            cmd = @" SELECT DISTINCT '0' || A.ORDER_GUBUN  ORDER_GUBUN,
    //       A.SLIP_CODE                    ,
    //       NVL(B.SLIP_NAME, ' ') SLIP_NAME,
    //       A.HANGMOG_CODE                 ,
    //       ( CASE WHEN A.ORDER_GUBUN IN ('A', 'B', 'C', 'D')
    //              THEN NVL(FN_DRG_SPEC_NAME(A.HANGMOG_CODE), '')||A.HANGMOG_NAME
    //              ELSE A.HANGMOG_NAME  END ) HANGMOG_NAME,
    //       A.SG_CODE                                          SG_CODE      ,
    //       CASE WHEN NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) < TRUNC(SYSDATE)    THEN 'Y'
    //            WHEN NVL(D.BULYONG_YMD, TO_DATE('99981231', 'YYYYMMDD')) < TRUNC(SYSDATE) THEN 'Y'
    //            ELSE 'N'
    //       END    BULYONG_CHECK,
    //       NVL(A.WONNAE_DRG_YN, 'N')   WONNAE_DRG_YN,
    //       ''                         SELECT_YN,
    //       A.INPUT_CONTROL,
    //       D.BUN_CODE,
    //       A.SEQ
    //  FROM OCS0103 A,
    //       OCS0102 B,
    //       OCS0142 C,
    //       ( SELECT X.SG_CODE
    //              , X.SG_NAME
    //              , X.SG_YMD
    //              , X.BULYONG_YMD 
    //              , X.BUN_CODE
    //           FROM BAS0310 X
    //          WHERE X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
    //                               FROM BAS0310 Z
    //                              WHERE Z.SG_CODE = X.SG_CODE 
    //                                AND Z.SG_YMD <= TRUNC(SYSDATE) )
    //       ) D
    // WHERE A.HANGMOG_NAME_INX LIKE " + "'%'||'" + searchWord + "'||'%' "
    //   + @"AND A.ORDER_GUBUN      LIKE :f_order_gubun
    //   AND A.HOSP_CODE        = :f_hosp_code
    //   AND (
    //         ( :f_child_yn = 'Y'
    //           AND 
    //           A.IF_INPUT_CONTROL != 'P' )
    //         OR
    //         ( :f_child_yn = 'N'
    //           AND 
    //           A.IF_INPUT_CONTROL = 'P' )
    //         OR
    //         ( :f_child_yn = '%' )
    //       )
    //--   AND NVL(A.DISPLAY_YN, 'Y') = 'Y'
    //   AND B.SLIP_CODE        = A.SLIP_CODE
    //   AND B.HOSP_CODE        = A.HOSP_CODE
    //   AND A.ORDER_GUBUN      = C.ORDER_GUBUN
    //   AND C.INPUT_TAB     LIKE :f_input_tab
    //   AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
    //   AND A.SG_CODE          = D.SG_CODE (+)
    //ORDER BY 2, 10, 5, 6 ";

//            return cmd ;
            return searchWord;
        }

		private void xButton1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(JapanTextHelper.GetFullKatakana(txtHangmog_index.GetDataValue().Trim(),true));
		
		}

		private void ClearSelect()
		{
			for(int i = 0; i < grdHangmogInfo.RowCount; i++)
			{
				grdHangmogInfo.SetItemValue(i, "select", "");				
			}

			SelectionBackColorChange(grdHangmogInfo);
		}

		#endregion

		#region [Control Event]
        
		/// <summary>
		/// 항목조회 パーキンソン
		/// </summary>
		private void txtHangmog_index_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadOCS0103();		
		}
        
		/// <summary>
		/// 선택한 row를 returnValue로 생성한다.
		/// </summary>
		private void grdHangmogInfo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex;
            curRowIndex = grdHangmogInfo.GetHitRowNumber(e.Y);
            if (curRowIndex < 0) return;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
                if (this.grdHangmogInfo.GetItemString(curRowIndex, "bulyong_check") == "Y")
                {
                    XMessageBox.Show("[" + this.grdHangmogInfo.GetItemString(curRowIndex, "hangmog_name") + Resources.XMessageBox3, Resources.Caption1);
                    return;
                }

                if (grdHangmogInfo.GetItemString(curRowIndex, "select") == "")
                {
                    this.grdHangmogInfo.SetItemValue(curRowIndex, "select", " ");
                    SelectionBackColorChange(sender, curRowIndex, "Y");
                }
				
				CreateReturnValue();
			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdHangmogInfo.CurrentColNumber < 1 )
			{
				if(grdHangmogInfo.CurrentColNumber < 1)
				{
                    if (this.grdHangmogInfo.GetItemString(curRowIndex, "bulyong_check") == "Y")
                    {
                        XMessageBox.Show("[" + this.grdHangmogInfo.GetItemString(curRowIndex, "hangmog_name") + Resources.XMessageBox3, Resources.Caption1);
                        return;
                    }

					//오더를 선택하면 검색어는 clear한다.
					txtHangmog_index.SetDataValue("");

					if(!mMultiSelect) this.ClearSelect();

					if(grdHangmogInfo.GetItemString(curRowIndex, "select") == "")
					{
						grdHangmogInfo.SetItemValue(curRowIndex, "select", " ");
						SelectionBackColorChange(sender, curRowIndex, "Y");
					}
					else
					{
						grdHangmogInfo.SetItemValue(curRowIndex, "select", "");
						SelectionBackColorChange(sender, curRowIndex, "N");
					}
				}

			}			
		}
        
		/// <summary>
		/// 선택한 row를 returnValue로 생성한다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnValue();		
		}

		private void rbtSearchAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtSearchAll.Checked)
			{
				rbtSearchAll.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtSearchAll.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);				
				rbtSearchAll.ImageIndex = 1;
				
				rbtSearchStart.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtSearchStart.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);				
				rbtSearchStart.ImageIndex = 0;
			}
			else
			{
				rbtSearchStart.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtSearchStart.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);				
				rbtSearchStart.ImageIndex = 1;

				rbtSearchAll.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtSearchAll.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtSearchAll.ImageIndex = 0;
			}

			LoadOCS0103();
		
		}

		private void grdHangmogInfo_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
            XGrid grid = sender as XGrid;

            if (e.DataRow["bulyong_check"].ToString() == "Y")
                e.ForeColor = Color.Red;
            else
                this.mColumnControl.ColumnColorForCodeQueryGrid("O", grid, e);
		     
		}

		private void txtHangmog_index_ImeModeChanged(object sender, System.EventArgs e)
		{
			PostCallHelper.PostCall( new PostMethod( setIMEKana ));
		}

		private void setIMEKana()
		{
			this.txtHangmog_index.ImeMode = System.Windows.Forms.ImeMode.Katakana;
		}
		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					LoadOCS0103();
					break;

				case FunctionType.Process:
					e.IsBaseCall = false;
					CreateReturnValue();
					break;
			}
		}

		#endregion

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
		{
			XGrid grdObject = (XGrid)grd;
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
					if(grdObject.GetItemString(currentRowIndex, "bulyong_check") != "Y" ) grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
				}
				else 
				{
					grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
					if(grdObject.GetItemString(currentRowIndex, "bulyong_check") != "Y" ) grdObject[currentRowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
				}
			}
			
		}
		
		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];					

					//ColorYn Y :색을 변경, N :색을 변경 해제
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridSelectedCellBackColor;

						if(grdObject.GetItemString(rowIndex, "bulyong_check") != "Y" )
                            grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.XGridSelectedCellForeColor;
						else
							grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = new XColor(Color.Red);
					}					
				}
				else
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						
						if(grdObject.GetItemString(rowIndex, "bulyong_check") != "Y" )
							grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
						else
							grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = new XColor(Color.Red);
					}
				}
			}
		}
		#endregion

        private void grdHangmogInfo_GridContDisplayed(object sender, XGridContDisplayedEventArgs e)
        {
            this.SelectionBackColorChange(grdHangmogInfo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
//            string cmd = " SELECT 'X' FROM OCS0103 WHERE HANGMOG_NAME_INX LIKE '%" + this.txtHangmog_index.GetDataValue() + "%' ";
//
//            DataTable temp = Service.ExecuteDataTable(cmd);

            DataTable temp = CreateDataTable(this.txtHangmog_index.GetDataValue());

            if (temp != null)
                MessageBox.Show(temp.Rows.Count.ToString());
                


            string cnvText = this.LoadKatakanaFull(this.txtHangmog_index.GetDataValue());
//            cmd = " SELECT 'X' FROM OCS0103 WHERE HANGMOG_NAME_INX LIKE '%" + cnvText + "%' ";
//
//            DataTable temp1 = Service.ExecuteDataTable(cmd);

            DataTable temp1 = CreateDataTable(cnvText);
            if (temp1 != null)
                MessageBox.Show(temp1.Rows.Count.ToString());

            cnvText = JapanTextHelper.GetFullKatakana(this.txtHangmog_index.GetDataValue(), false);
//            cmd = " SELECT 'X' FROM OCS0103 WHERE HANGMOG_NAME_INX LIKE '%" + cnvText + "%' ";
//
//            DataTable temp2 = Service.ExecuteDataTable(cmd);

            DataTable temp2 = CreateDataTable(cnvText);
            if (temp2 != null)
                MessageBox.Show(temp2.Rows.Count.ToString());

        }

	    #region connect to cloud

        //private List<object[]> GrdHangmogInfo_ExecuteQuery(BindVarCollection bc)
        //{
        //    List<object[]> res = new List<object[]>();
        //    Ocs0103Q00GrdHangMogArgs vOcs0103Q00GrdHangMogArgs = new Ocs0103Q00GrdHangMogArgs();
        //    vOcs0103Q00GrdHangMogArgs.QueryCode = bc["f_query_code"] != null ? bc["f_query_code"].VarValue : "";
        //    vOcs0103Q00GrdHangMogArgs.OrderGubun = bc["f_order_gubun"] != null ? bc["f_order_gubun"].VarValue : "";
        //    vOcs0103Q00GrdHangMogArgs.ChildYn = bc["f_child_yn"] != null ? bc["f_child_yn"].VarValue : "";
        //    vOcs0103Q00GrdHangMogArgs.InputTab = bc["f_input_tab"] != null ? bc["f_input_tab"].VarValue : "";
        //    Ocs0103Q00GrdHangMogResult result = CloudService.Instance.Submit<Ocs0103Q00GrdHangMogResult, Ocs0103Q00GrdHangMogArgs>(vOcs0103Q00GrdHangMogArgs);
        //    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
        //    {
        //        result.ListInfo.ForEach(delegate(Ocs0103Q00LoadOcs0103ListItemInfo item)
        //        {
        //            res.Add(new object[]
        //            {
        //                item.OrderGubun,
        //                item.SlipCode,
        //                item.SlipName,
        //                item.HangmogCode,
        //                item.HangmogName,
        //                item.SgCode,
        //                item.BulyongCheck,
        //                item.WonnaeDrgYn,
        //                item.SelectYn,
        //                item.InputControl,
        //                item.BunCode,
        //                item.Seq,
        //            });
        //        });
        //    }
        //    return res;
        //}

        private List<object[]> layoutCombo_ExecuteQuery(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0103Q00CreateOrderGubunArgs vOCS0103Q00CreateOrderGubunArgs = new OCS0103Q00CreateOrderGubunArgs();
            vOCS0103Q00CreateOrderGubunArgs.InputTab = bc["f_input_tab"] != null ? bc["f_input_tab"].VarValue : "";
            OCS0103Q00CreateOrderGubunResult result = CloudService.Instance.Submit<OCS0103Q00CreateOrderGubunResult, OCS0103Q00CreateOrderGubunArgs>(vOCS0103Q00CreateOrderGubunArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<OCS0103Q00CreateOrderGubunInfo> lstCreateOrderGubunInfo = result.OrderGubunInfo;
                if (lstCreateOrderGubunInfo != null && lstCreateOrderGubunInfo.Count > 0)
                {
                    foreach (OCS0103Q00CreateOrderGubunInfo item in result.OrderGubunInfo)
                    {
                        object[] objects =
                        {
                            item.Code,
                            item.CodeName,
                            item.SortKey
                        };
                        res.Add(objects);
                    }
                }
            }
            return res;
        }

        private List<object[]> GrdHangmogInfo_ExecuteQuery2(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            Ocs0103Q00LoadOcs0103Args vOcs0103Q00LoadOcs0103Args = new Ocs0103Q00LoadOcs0103Args();
            vOcs0103Q00LoadOcs0103Args.QueryCode = bc["f_query_code"] != null ? bc["f_query_code"].VarValue : "";
            vOcs0103Q00LoadOcs0103Args.OrderGubun = bc["f_order_gubun"] != null ? bc["f_order_gubun"].VarValue : "";
            vOcs0103Q00LoadOcs0103Args.ChildYn = bc["f_child_yn"] != null ? bc["f_child_yn"].VarValue : "";
            vOcs0103Q00LoadOcs0103Args.InputTab = bc["f_input_tab"] != null ? bc["f_input_tab"].VarValue : "";
            vOcs0103Q00LoadOcs0103Args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            vOcs0103Q00LoadOcs0103Args.OffSet = "200";
            Ocs0103Q00LoadOcs0103Result result = CloudService.Instance.Submit<Ocs0103Q00LoadOcs0103Result, Ocs0103Q00LoadOcs0103Args>(vOcs0103Q00LoadOcs0103Args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                result.ItemInfo.ForEach(delegate(Ocs0103Q00LoadOcs0103ListItemInfo item)
                {
                    res.Add(new object[]
                    {
                         item.OrderGubun,
                        item.SlipCode,
                        item.SlipName,
                        item.HangmogCode,
                        item.SgCode,
                        item.HangmogName,  
                        item.SgCode,
                        item.BulyongCheck,
                        item.WonnaeDrgYn,
                        item.SelectYn,
                        item.InputControl,
                        item.BunCode,
                        //item.Seq,
                        
                        
                        //item.OrderGubun,
                        //item.SlipCode,
                        //item.SlipName,
                        //item.HangmogCode,
                        //item.SgCode,
                        //item.HangmogName,                        
                        //item.BulyongCheck,
                        //item.WonnaeDrgYn,
                        //item.SelectYn,
                        //item.InputControl,
                        //item.BunCode,
                        //item.Seq,
                    });
                });
            }

            return res;
        }

        private DataTable CreateDataTable(string aValue)
        {
            DataTable temp = null;
            OCS0103Q00CheckHangmogNameInxArgs checkHangmogNameInxArgs = new OCS0103Q00CheckHangmogNameInxArgs();
            checkHangmogNameInxArgs.HangmogNameInx = aValue;
            OCS0103Q00CheckHangmogNameInxResult hangmogNameInxResult =
                CloudService.Instance.Submit<OCS0103Q00CheckHangmogNameInxResult, OCS0103Q00CheckHangmogNameInxArgs>(
                    checkHangmogNameInxArgs);
            if (hangmogNameInxResult != null && hangmogNameInxResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<DataStringListItemInfo> lstDataStringListItemInfo = hangmogNameInxResult.Result;
                if (lstDataStringListItemInfo != null && lstDataStringListItemInfo.Count > 0)
                    temp = Utility.ConvertToDataTable(lstDataStringListItemInfo);
            }
            return temp;
        }
        #endregion
    }
}
