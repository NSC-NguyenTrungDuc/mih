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
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0208Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0208Q00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리		
		#endregion

		#region [Instance Variable]
		//Doctor
		string mDoctor = "";
		string mBongYongCode = "";
        string mIO_GUBUN = "";
        string mInputGubun = "";
		//구분
		string mGubun     = "0";
		string mBanghyang = "01";
		string mSuryang   = "";
		string mDv_time   = "/";
		int    mDv        = 3 ;
		string mDv_1      = "";
		string mDv_2      = "";
		string mDv_3      = "";
		string mDv_4      = "";
        string mOrder_remark = "";
        //Event 값 처리는 막기위함
		bool   mOpenSetParaValue = false;

		//Message처리
        string mbxMsg = "", mbxCap = "";

        // Hospital Code
        string mHospCode = EnvironInfo.HospCode;

        // selectTab
        int mSelectTabInd = 2;
		#endregion

		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XTabControl xTabControl1;
		private IHIS.Framework.MultiLayout dloSelectValue;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XEditGrid grdOCS0208;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XLabel lblSelectOCS0201;
        private IHIS.Framework.XTabControl tabGubun;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel6;
		private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGrid grdOCS0208_ALL;
		private IHIS.Framework.XRadioButton rbtBase;
		private IHIS.Framework.XRadioButton rbtUser;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XPanel pnlOrderInfo;
        private IHIS.Framework.XLabel lblSelectAll;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XTextBox txtOrder_remark;
		private IHIS.Framework.XComboBox cboDv_time;
		private IHIS.Framework.XLabel lblDv;
		private IHIS.Framework.XLabel lblSuryang;
		private IHIS.Framework.XEditMask emSuryang;
		private IHIS.Framework.XPanel xPanel7;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XComboBox cboCnt_perday;
		private IHIS.Framework.XButton btnAct_dq;
		private IHIS.Framework.XCheckBox chkAct_dq4;
		private IHIS.Framework.XCheckBox chkAct_dq3;
		private IHIS.Framework.XCheckBox chkAct_dq1;
		private IHIS.Framework.XCheckBox chkAct_dq2;
		private IHIS.Framework.XFlatLabel xFlatLabel2;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XButton btnLimitCnt_perday;
		private IHIS.Framework.XButton btnAct_Fg;
		private IHIS.Framework.XEditMask emkDv_1;
		private IHIS.Framework.XEditMask emkDv_2;
		private IHIS.Framework.XEditMask emkDv_4;
        private IHIS.Framework.XEditMask emkDv_3;
		private IHIS.Framework.XCheckBox chkFg_3;
		private IHIS.Framework.XCheckBox chkFg_1;
		private IHIS.Framework.XCheckBox chkFg_2;
		private IHIS.Framework.XComboBox cboDV;
		private IHIS.Framework.XPanel pnlDv_info;
		private IHIS.Framework.XFlatLabel xFlatLabel3;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XFlatLabel xFlatLabel4;
		private IHIS.Framework.XFlatLabel xFlatLabel5;
        private IHIS.Framework.XFlatLabel xFlatLabel6;
        private XEditGridCell xEditGridCell12;
        private MultiLayout layTabGubun;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem6;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;

	    private OCS0208Q00CommonDataResult commonDataResult;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0208Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			this.mOrderBiz  = new IHIS.OCS.OrderBiz();                      // OCS 그룹 Business 라이브러리
		    grdOCS0208.ParamList = CreateGrdOCS0208ParamList();
		    grdOCS0208.ExecuteQuery = LoadGrdOCS0208;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0208Q00));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xTabControl1 = new IHIS.Framework.XTabControl();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0208 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.dloSelectValue = new IHIS.Framework.MultiLayout();
            this.grdOCS0208_ALL = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.lblSelectOCS0201 = new IHIS.Framework.XLabel();
            this.tabGubun = new IHIS.Framework.XTabControl();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.xFlatLabel6 = new IHIS.Framework.XFlatLabel();
            this.btnAct_Fg = new IHIS.Framework.XButton();
            this.chkFg_3 = new IHIS.Framework.XCheckBox();
            this.chkFg_1 = new IHIS.Framework.XCheckBox();
            this.chkFg_2 = new IHIS.Framework.XCheckBox();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.cboCnt_perday = new IHIS.Framework.XComboBox();
            this.btnAct_dq = new IHIS.Framework.XButton();
            this.btnLimitCnt_perday = new IHIS.Framework.XButton();
            this.chkAct_dq4 = new IHIS.Framework.XCheckBox();
            this.chkAct_dq3 = new IHIS.Framework.XCheckBox();
            this.chkAct_dq1 = new IHIS.Framework.XCheckBox();
            this.chkAct_dq2 = new IHIS.Framework.XCheckBox();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtOrder_remark = new IHIS.Framework.XTextBox();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            this.pnlOrderInfo = new IHIS.Framework.XPanel();
            this.xFlatLabel4 = new IHIS.Framework.XFlatLabel();
            this.pnlDv_info = new IHIS.Framework.XPanel();
            this.emkDv_1 = new IHIS.Framework.XEditMask();
            this.emkDv_2 = new IHIS.Framework.XEditMask();
            this.emkDv_3 = new IHIS.Framework.XEditMask();
            this.emkDv_4 = new IHIS.Framework.XEditMask();
            this.cboDV = new IHIS.Framework.XComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.emSuryang = new IHIS.Framework.XEditMask();
            this.cboDv_time = new IHIS.Framework.XComboBox();
            this.lblDv = new IHIS.Framework.XLabel();
            this.lblSuryang = new IHIS.Framework.XLabel();
            this.lblSelectAll = new IHIS.Framework.XLabel();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbtBase = new IHIS.Framework.XRadioButton();
            this.rbtUser = new IHIS.Framework.XRadioButton();
            this.layTabGubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208_ALL)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel7.SuspendLayout();
            this.pnlOrderInfo.SuspendLayout();
            this.pnlDv_info.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layTabGubun)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "6.gif");
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnProcess);
            this.xPanel2.Controls.Add(this.xTabControl1);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnProcess
            // 
            this.btnProcess.AccessibleDescription = null;
            this.btnProcess.AccessibleName = null;
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.BackgroundImage = null;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // xTabControl1
            // 
            this.xTabControl1.AccessibleDescription = null;
            this.xTabControl1.AccessibleName = null;
            resources.ApplyResources(this.xTabControl1, "xTabControl1");
            this.xTabControl1.BackgroundImage = null;
            this.xTabControl1.Font = null;
            this.xTabControl1.IDEPixelArea = true;
            this.xTabControl1.IDEPixelBorder = false;
            this.xTabControl1.Name = "xTabControl1";
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0208
            // 
            resources.ApplyResources(this.grdOCS0208, "grdOCS0208");
            this.grdOCS0208.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell3,
            this.xEditGridCell2,
            this.xEditGridCell4,
            this.xEditGridCell9,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell11});
            this.grdOCS0208.ColPerLine = 3;
            this.grdOCS0208.Cols = 3;
            this.grdOCS0208.ExecuteQuery = null;
            this.grdOCS0208.FixedRows = 1;
            this.grdOCS0208.FocusColumnName = "bogyong_code";
            this.grdOCS0208.HeaderHeights.Add(35);
            this.grdOCS0208.Name = "grdOCS0208";
            this.grdOCS0208.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0208.ParamList")));
            this.grdOCS0208.QuerySQL = resources.GetString("grdOCS0208.QuerySQL");
            this.grdOCS0208.ReadOnly = true;
            this.grdOCS0208.Rows = 2;
            this.grdOCS0208.ToolTipActive = true;
            this.grdOCS0208.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0208_MouseDown);
            this.grdOCS0208.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0208_RowFocusChanged);
            this.grdOCS0208.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0208_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gubun";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellLen = 7;
            this.xEditGridCell3.CellName = "bogyong_code";
            this.xEditGridCell3.CellWidth = 121;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "banghyang";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellLen = 400;
            this.xEditGridCell4.CellName = "bogyong_name";
            this.xEditGridCell4.CellWidth = 374;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.CellName = "donbog_yn";
            this.xEditGridCell9.CellWidth = 33;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "dv";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sory_key";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 1;
            this.xEditGridCell14.CellName = "user_yn";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "io_gubun";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell11.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell11.CellName = "select";
            this.xEditGridCell11.CellWidth = 39;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell11.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell11.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // dloSelectValue
            // 
            this.dloSelectValue.ExecuteQuery = null;
            this.dloSelectValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectValue.ParamList")));
            // 
            // grdOCS0208_ALL
            // 
            resources.ApplyResources(this.grdOCS0208_ALL, "grdOCS0208_ALL");
            this.grdOCS0208_ALL.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell10});
            this.grdOCS0208_ALL.ColPerLine = 2;
            this.grdOCS0208_ALL.Cols = 2;
            this.grdOCS0208_ALL.ExecuteQuery = null;
            this.grdOCS0208_ALL.FixedRows = 1;
            this.grdOCS0208_ALL.FocusColumnName = "bogyong_code";
            this.grdOCS0208_ALL.HeaderHeights.Add(21);
            this.grdOCS0208_ALL.Name = "grdOCS0208_ALL";
            this.grdOCS0208_ALL.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0208_ALL.ParamList")));
            this.grdOCS0208_ALL.ReadOnly = true;
            this.grdOCS0208_ALL.Rows = 2;
            this.grdOCS0208_ALL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0208_ALL_MouseDown);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gubun";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.CellLen = 7;
            this.xEditGridCell6.CellName = "bogyong_code";
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell6.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "banghyang";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell8.CellLen = 400;
            this.xEditGridCell8.CellName = "bogyong_name";
            this.xEditGridCell8.CellWidth = 291;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell8.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "donbog_yn";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.grdOCS0208_ALL);
            this.xPanel5.Controls.Add(this.xLabel1);
            this.xPanel5.Name = "xPanel5";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xLabel1.Font = null;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.grdOCS0208);
            this.xPanel4.Controls.Add(this.lblSelectOCS0201);
            this.xPanel4.Name = "xPanel4";
            // 
            // lblSelectOCS0201
            // 
            this.lblSelectOCS0201.AccessibleDescription = null;
            this.lblSelectOCS0201.AccessibleName = null;
            resources.ApplyResources(this.lblSelectOCS0201, "lblSelectOCS0201");
            this.lblSelectOCS0201.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOCS0201.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectOCS0201.Font = null;
            this.lblSelectOCS0201.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOCS0201.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOCS0201.Image = null;
            this.lblSelectOCS0201.Name = "lblSelectOCS0201";
            // 
            // tabGubun
            // 
            this.tabGubun.AccessibleDescription = null;
            this.tabGubun.AccessibleName = null;
            resources.ApplyResources(this.tabGubun, "tabGubun");
            this.tabGubun.Appearance = IHIS.X.Magic.Common.VisualAppearance.MultiBox;
            this.tabGubun.BackgroundImage = null;
            this.tabGubun.Font = null;
            this.tabGubun.IDEPixelArea = true;
            this.tabGubun.ImageList = this.ImageList;
            this.tabGubun.Name = "tabGubun";
            this.tabGubun.SelectionChanged += new System.EventHandler(this.tabGubun_SelectionChanged);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.xPanel7);
            this.xPanel3.Controls.Add(this.pnlOrderInfo);
            this.xPanel3.Controls.Add(this.xPanel5);
            this.xPanel3.Controls.Add(this.splitter1);
            this.xPanel3.Controls.Add(this.xPanel4);
            this.xPanel3.Controls.Add(this.tabGubun);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.xFlatLabel6);
            this.xPanel7.Controls.Add(this.btnAct_Fg);
            this.xPanel7.Controls.Add(this.chkFg_3);
            this.xPanel7.Controls.Add(this.chkFg_1);
            this.xPanel7.Controls.Add(this.chkFg_2);
            this.xPanel7.Controls.Add(this.xFlatLabel1);
            this.xPanel7.Controls.Add(this.cboCnt_perday);
            this.xPanel7.Controls.Add(this.btnAct_dq);
            this.xPanel7.Controls.Add(this.btnLimitCnt_perday);
            this.xPanel7.Controls.Add(this.chkAct_dq4);
            this.xPanel7.Controls.Add(this.chkAct_dq3);
            this.xPanel7.Controls.Add(this.chkAct_dq1);
            this.xPanel7.Controls.Add(this.chkAct_dq2);
            this.xPanel7.Controls.Add(this.xFlatLabel2);
            this.xPanel7.Controls.Add(this.xLabel3);
            this.xPanel7.Controls.Add(this.txtOrder_remark);
            this.xPanel7.Controls.Add(this.xFlatLabel5);
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            // 
            // xFlatLabel6
            // 
            this.xFlatLabel6.AccessibleDescription = null;
            this.xFlatLabel6.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel6, "xFlatLabel6");
            this.xFlatLabel6.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel6.Font = null;
            this.xFlatLabel6.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xFlatLabel6.Name = "xFlatLabel6";
            // 
            // btnAct_Fg
            // 
            this.btnAct_Fg.AccessibleDescription = null;
            this.btnAct_Fg.AccessibleName = null;
            resources.ApplyResources(this.btnAct_Fg, "btnAct_Fg");
            this.btnAct_Fg.BackgroundImage = null;
            this.btnAct_Fg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAct_Fg.Font = null;
            this.btnAct_Fg.Image = ((System.Drawing.Image)(resources.GetObject("btnAct_Fg.Image")));
            this.btnAct_Fg.Name = "btnAct_Fg";
            this.btnAct_Fg.Click += new System.EventHandler(this.btnAct_Fg_Click);
            // 
            // chkFg_3
            // 
            this.chkFg_3.AccessibleDescription = null;
            this.chkFg_3.AccessibleName = null;
            resources.ApplyResources(this.chkFg_3, "chkFg_3");
            this.chkFg_3.BackgroundImage = null;
            this.chkFg_3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkFg_3.Font = null;
            this.chkFg_3.Name = "chkFg_3";
            this.chkFg_3.UseVisualStyleBackColor = false;
            // 
            // chkFg_1
            // 
            this.chkFg_1.AccessibleDescription = null;
            this.chkFg_1.AccessibleName = null;
            resources.ApplyResources(this.chkFg_1, "chkFg_1");
            this.chkFg_1.BackgroundImage = null;
            this.chkFg_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkFg_1.Font = null;
            this.chkFg_1.Name = "chkFg_1";
            this.chkFg_1.UseVisualStyleBackColor = false;
            // 
            // chkFg_2
            // 
            this.chkFg_2.AccessibleDescription = null;
            this.chkFg_2.AccessibleName = null;
            resources.ApplyResources(this.chkFg_2, "chkFg_2");
            this.chkFg_2.BackgroundImage = null;
            this.chkFg_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkFg_2.Font = null;
            this.chkFg_2.Name = "chkFg_2";
            this.chkFg_2.UseVisualStyleBackColor = false;
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AccessibleDescription = null;
            this.xFlatLabel1.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel1.Font = null;
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // cboCnt_perday
            // 
            this.cboCnt_perday.AccessibleDescription = null;
            this.cboCnt_perday.AccessibleName = null;
            resources.ApplyResources(this.cboCnt_perday, "cboCnt_perday");
            this.cboCnt_perday.BackgroundImage = null;
            this.cboCnt_perday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboCnt_perday.Font = null;
            this.cboCnt_perday.Name = "cboCnt_perday";
            // 
            // btnAct_dq
            // 
            this.btnAct_dq.AccessibleDescription = null;
            this.btnAct_dq.AccessibleName = null;
            resources.ApplyResources(this.btnAct_dq, "btnAct_dq");
            this.btnAct_dq.BackgroundImage = null;
            this.btnAct_dq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAct_dq.Font = null;
            this.btnAct_dq.Image = ((System.Drawing.Image)(resources.GetObject("btnAct_dq.Image")));
            this.btnAct_dq.Name = "btnAct_dq";
            this.btnAct_dq.Click += new System.EventHandler(this.btnAct_dq_Click);
            // 
            // btnLimitCnt_perday
            // 
            this.btnLimitCnt_perday.AccessibleDescription = null;
            this.btnLimitCnt_perday.AccessibleName = null;
            resources.ApplyResources(this.btnLimitCnt_perday, "btnLimitCnt_perday");
            this.btnLimitCnt_perday.BackgroundImage = null;
            this.btnLimitCnt_perday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimitCnt_perday.Font = null;
            this.btnLimitCnt_perday.Image = ((System.Drawing.Image)(resources.GetObject("btnLimitCnt_perday.Image")));
            this.btnLimitCnt_perday.Name = "btnLimitCnt_perday";
            this.btnLimitCnt_perday.Click += new System.EventHandler(this.btnLimitCnt_perday_Click);
            // 
            // chkAct_dq4
            // 
            this.chkAct_dq4.AccessibleDescription = null;
            this.chkAct_dq4.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq4, "chkAct_dq4");
            this.chkAct_dq4.BackgroundImage = null;
            this.chkAct_dq4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq4.Font = null;
            this.chkAct_dq4.Name = "chkAct_dq4";
            this.chkAct_dq4.UseVisualStyleBackColor = false;
            // 
            // chkAct_dq3
            // 
            this.chkAct_dq3.AccessibleDescription = null;
            this.chkAct_dq3.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq3, "chkAct_dq3");
            this.chkAct_dq3.BackgroundImage = null;
            this.chkAct_dq3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq3.Font = null;
            this.chkAct_dq3.Name = "chkAct_dq3";
            this.chkAct_dq3.UseVisualStyleBackColor = false;
            // 
            // chkAct_dq1
            // 
            this.chkAct_dq1.AccessibleDescription = null;
            this.chkAct_dq1.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq1, "chkAct_dq1");
            this.chkAct_dq1.BackgroundImage = null;
            this.chkAct_dq1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq1.Font = null;
            this.chkAct_dq1.Name = "chkAct_dq1";
            this.chkAct_dq1.UseVisualStyleBackColor = false;
            // 
            // chkAct_dq2
            // 
            this.chkAct_dq2.AccessibleDescription = null;
            this.chkAct_dq2.AccessibleName = null;
            resources.ApplyResources(this.chkAct_dq2, "chkAct_dq2");
            this.chkAct_dq2.BackgroundImage = null;
            this.chkAct_dq2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAct_dq2.Font = null;
            this.chkAct_dq2.Name = "chkAct_dq2";
            this.chkAct_dq2.UseVisualStyleBackColor = false;
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.AccessibleDescription = null;
            this.xFlatLabel2.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel2.Font = null;
            this.xFlatLabel2.Name = "xFlatLabel2";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xLabel3.Font = null;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel3.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel3.Name = "xLabel3";
            // 
            // txtOrder_remark
            // 
            this.txtOrder_remark.AccessibleDescription = null;
            this.txtOrder_remark.AccessibleName = null;
            this.txtOrder_remark.AllowDrop = true;
            resources.ApplyResources(this.txtOrder_remark, "txtOrder_remark");
            this.txtOrder_remark.ApplyByteLimit = true;
            this.txtOrder_remark.BackgroundImage = null;
            this.txtOrder_remark.Font = null;
            this.txtOrder_remark.Name = "txtOrder_remark";
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.AccessibleDescription = null;
            this.xFlatLabel5.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel5, "xFlatLabel5");
            this.xFlatLabel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel5.Font = null;
            this.xFlatLabel5.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xFlatLabel5.Name = "xFlatLabel5";
            // 
            // pnlOrderInfo
            // 
            this.pnlOrderInfo.AccessibleDescription = null;
            this.pnlOrderInfo.AccessibleName = null;
            resources.ApplyResources(this.pnlOrderInfo, "pnlOrderInfo");
            this.pnlOrderInfo.BackgroundImage = null;
            this.pnlOrderInfo.Controls.Add(this.xFlatLabel4);
            this.pnlOrderInfo.Controls.Add(this.pnlDv_info);
            this.pnlOrderInfo.Controls.Add(this.cboDV);
            this.pnlOrderInfo.Controls.Add(this.xLabel2);
            this.pnlOrderInfo.Controls.Add(this.emSuryang);
            this.pnlOrderInfo.Controls.Add(this.cboDv_time);
            this.pnlOrderInfo.Controls.Add(this.lblDv);
            this.pnlOrderInfo.Controls.Add(this.lblSuryang);
            this.pnlOrderInfo.Controls.Add(this.lblSelectAll);
            this.pnlOrderInfo.Controls.Add(this.xFlatLabel3);
            this.pnlOrderInfo.Font = null;
            this.pnlOrderInfo.Name = "pnlOrderInfo";
            // 
            // xFlatLabel4
            // 
            this.xFlatLabel4.AccessibleDescription = null;
            this.xFlatLabel4.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel4, "xFlatLabel4");
            this.xFlatLabel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel4.Font = null;
            this.xFlatLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xFlatLabel4.Name = "xFlatLabel4";
            // 
            // pnlDv_info
            // 
            this.pnlDv_info.AccessibleDescription = null;
            this.pnlDv_info.AccessibleName = null;
            resources.ApplyResources(this.pnlDv_info, "pnlDv_info");
            this.pnlDv_info.BackgroundImage = null;
            this.pnlDv_info.Controls.Add(this.emkDv_1);
            this.pnlDv_info.Controls.Add(this.emkDv_2);
            this.pnlDv_info.Controls.Add(this.emkDv_3);
            this.pnlDv_info.Controls.Add(this.emkDv_4);
            this.pnlDv_info.Font = null;
            this.pnlDv_info.Name = "pnlDv_info";
            // 
            // emkDv_1
            // 
            this.emkDv_1.AccessibleDescription = null;
            this.emkDv_1.AccessibleName = null;
            resources.ApplyResources(this.emkDv_1, "emkDv_1");
            this.emkDv_1.BackgroundImage = null;
            this.emkDv_1.Font = null;
            this.emkDv_1.Name = "emkDv_1";
            this.emkDv_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emkDvSuryang_KeyPress);
            this.emkDv_1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.emkDvSuryang_KeyUp);
            // 
            // emkDv_2
            // 
            this.emkDv_2.AccessibleDescription = null;
            this.emkDv_2.AccessibleName = null;
            resources.ApplyResources(this.emkDv_2, "emkDv_2");
            this.emkDv_2.BackgroundImage = null;
            this.emkDv_2.Font = null;
            this.emkDv_2.Name = "emkDv_2";
            this.emkDv_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emkDvSuryang_KeyPress);
            this.emkDv_2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.emkDvSuryang_KeyUp);
            // 
            // emkDv_3
            // 
            this.emkDv_3.AccessibleDescription = null;
            this.emkDv_3.AccessibleName = null;
            resources.ApplyResources(this.emkDv_3, "emkDv_3");
            this.emkDv_3.BackgroundImage = null;
            this.emkDv_3.Font = null;
            this.emkDv_3.Name = "emkDv_3";
            this.emkDv_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emkDvSuryang_KeyPress);
            this.emkDv_3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.emkDvSuryang_KeyUp);
            // 
            // emkDv_4
            // 
            this.emkDv_4.AccessibleDescription = null;
            this.emkDv_4.AccessibleName = null;
            resources.ApplyResources(this.emkDv_4, "emkDv_4");
            this.emkDv_4.BackgroundImage = null;
            this.emkDv_4.Font = null;
            this.emkDv_4.Name = "emkDv_4";
            this.emkDv_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emkDvSuryang_KeyPress);
            this.emkDv_4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.emkDvSuryang_KeyUp);
            // 
            // cboDV
            // 
            this.cboDV.AccessibleDescription = null;
            this.cboDV.AccessibleName = null;
            resources.ApplyResources(this.cboDV, "cboDV");
            this.cboDV.BackgroundImage = null;
            this.cboDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboDV.Font = null;
            this.cboDV.Name = "cboDV";
            this.cboDV.SelectedIndexChanged += new System.EventHandler(this.cboDV_SelectedIndexChanged);
            this.cboDV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDV_KeyPress);
            this.cboDV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboDV_KeyUp);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Font = null;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // emSuryang
            // 
            this.emSuryang.AccessibleDescription = null;
            this.emSuryang.AccessibleName = null;
            resources.ApplyResources(this.emSuryang, "emSuryang");
            this.emSuryang.BackgroundImage = null;
            this.emSuryang.Font = null;
            this.emSuryang.Name = "emSuryang";
            this.emSuryang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emSuryang_KeyPress);
            this.emSuryang.KeyUp += new System.Windows.Forms.KeyEventHandler(this.emSuryang_KeyUp);
            // 
            // cboDv_time
            // 
            this.cboDv_time.AccessibleDescription = null;
            this.cboDv_time.AccessibleName = null;
            resources.ApplyResources(this.cboDv_time, "cboDv_time");
            this.cboDv_time.BackgroundImage = null;
            this.cboDv_time.Font = null;
            this.cboDv_time.Name = "cboDv_time";
            this.cboDv_time.Protect = true;
            this.cboDv_time.TabStop = false;
            this.cboDv_time.SelectedIndexChanged += new System.EventHandler(this.cboDv_time_SelectedIndexChanged);
            // 
            // lblDv
            // 
            this.lblDv.AccessibleDescription = null;
            this.lblDv.AccessibleName = null;
            resources.ApplyResources(this.lblDv, "lblDv");
            this.lblDv.Font = null;
            this.lblDv.Image = null;
            this.lblDv.Name = "lblDv";
            // 
            // lblSuryang
            // 
            this.lblSuryang.AccessibleDescription = null;
            this.lblSuryang.AccessibleName = null;
            resources.ApplyResources(this.lblSuryang, "lblSuryang");
            this.lblSuryang.Font = null;
            this.lblSuryang.Image = null;
            this.lblSuryang.Name = "lblSuryang";
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AccessibleDescription = null;
            this.lblSelectAll.AccessibleName = null;
            resources.ApplyResources(this.lblSelectAll, "lblSelectAll");
            this.lblSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll.Font = null;
            this.lblSelectAll.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll.Name = "lblSelectAll";
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.AccessibleDescription = null;
            this.xFlatLabel3.AccessibleName = null;
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel3.Font = null;
            this.xFlatLabel3.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xFlatLabel3.Name = "xFlatLabel3";
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Controls.Add(this.rbtBase);
            this.xPanel6.Controls.Add(this.rbtUser);
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            // 
            // rbtBase
            // 
            this.rbtBase.AccessibleDescription = null;
            this.rbtBase.AccessibleName = null;
            resources.ApplyResources(this.rbtBase, "rbtBase");
            this.rbtBase.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtBase.BackgroundImage = null;
            this.rbtBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtBase.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtBase.ImageList = this.ImageList;
            this.rbtBase.Name = "rbtBase";
            this.rbtBase.UseVisualStyleBackColor = false;
            // 
            // rbtUser
            // 
            this.rbtUser.AccessibleDescription = null;
            this.rbtUser.AccessibleName = null;
            resources.ApplyResources(this.rbtUser, "rbtUser");
            this.rbtUser.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtUser.BackgroundImage = null;
            this.rbtUser.Checked = true;
            this.rbtUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtUser.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtUser.ImageList = this.ImageList;
            this.rbtUser.Name = "rbtUser";
            this.rbtUser.TabStop = true;
            this.rbtUser.UseVisualStyleBackColor = false;
            this.rbtUser.CheckedChanged += new System.EventHandler(this.rbtUser_CheckedChanged);
            // 
            // layTabGubun
            // 
            this.layTabGubun.ExecuteQuery = null;
            this.layTabGubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem6});
            this.layTabGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layTabGubun.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "select_gubun";
            // 
            // OCS0208Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "OCS0208Q00";
            this.UserChanged += new System.EventHandler(this.OCS0208Q00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0208Q00_ScreenOpen);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208_ALL)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            this.xPanel7.PerformLayout();
            this.pnlOrderInfo.ResumeLayout(false);
            this.pnlOrderInfo.PerformLayout();
            this.pnlDv_info.ResumeLayout(false);
            this.pnlDv_info.PerformLayout();
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layTabGubun)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		protected override void OnLoad(EventArgs e)
		{
            // cloud service
		    commonDataResult = GetCommonDataResult();
            CreateCombo();

			mOpenSetParaValue = true;
			base.OnLoad (e);
			mOpenSetParaValue = false;
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void OCS0208Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (OpenParam["io_gubun"].ToString().Trim() != "")
                            mIO_GUBUN = OpenParam["io_gubun"].ToString();

                    }
                    if (OpenParam.Contains("inputgubun"))
                    {
                        if (OpenParam["inputgubun"].ToString().Trim() != "")
                            mInputGubun = OpenParam["inputgubun"].ToString();

                    }
					if(OpenParam.Contains("bogyong_code"))
					{
						if(OpenParam["bogyong_code"].ToString().Trim() != "")
							mBongYongCode = OpenParam["bogyong_code"].ToString();
					}

					if(OpenParam.Contains("suryang"))
					{
						if(!TypeCheck.IsNull(OpenParam["suryang"].ToString()))
						{
							mSuryang = OpenParam["suryang"].ToString();
							emSuryang.SetDataValue(mSuryang);
						}
					}

					if(OpenParam.Contains("dv_time"))
					{
						if(!TypeCheck.IsNull(OpenParam["dv_time"].ToString()))
						{
							mDv_time = OpenParam["dv_time"].ToString();
							cboDv_time.SetDataValue(mDv_time);
						}
					}

					if(OpenParam.Contains("dv"))
					{
						if(TypeCheck.IsInt(OpenParam["dv"].ToString()))
						{
							mDv = int.Parse(OpenParam["dv"].ToString());
							cboDV.SetDataValue(mDv);
							if( mDv_time != "/" )
								SetEnable(0);
							else
                                SetEnable(mDv);
						}
					}

					if(OpenParam.Contains("dv_1"))
					{
						if(!TypeCheck.IsNull(OpenParam["dv_1"].ToString()))
						{
							mDv_1 = OpenParam["dv_1"].ToString();
							emkDv_1.SetDataValue(mDv_1);
						}
					}

					if(OpenParam.Contains("dv_2"))
					{
						if(!TypeCheck.IsNull(OpenParam["dv_2"].ToString()))
						{
							mDv_2 = OpenParam["dv_2"].ToString();
							emkDv_2.SetDataValue(mDv_2);
						}
					}

					if(OpenParam.Contains("dv_3"))
					{
						if(!TypeCheck.IsNull(OpenParam["dv_3"].ToString()))
						{
							mDv_3 = OpenParam["dv_3"].ToString();
							emkDv_3.SetDataValue(mDv_3);
						}
					}

					if(OpenParam.Contains("dv_4"))
					{
						if(!TypeCheck.IsNull(OpenParam["dv_4"].ToString()))
						{
							mDv_4 = OpenParam["dv_4"].ToString();
							emkDv_4.SetDataValue(mDv_4);
						}
					}

					if(OpenParam.Contains("order_remark"))
					{
						if(!TypeCheck.IsNull(OpenParam["order_remark"].ToString().Trim()))
						{
							mOrder_remark = OpenParam["order_remark"].ToString();
							txtOrder_remark.SetDataValue(mOrder_remark);
						}
					}
					
				}
				catch
				{
				}
			}

            grdOCS0208.SetBindVarValue("f_dv", mDv.ToString());
		}

		private void PostLoad()
		{
			this.CurrMSLayout = grdOCS0208;
			this.CurrMQLayout = grdOCS0208;

            TabCreate();
			CreateLayout();

			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.OCS0208Q00_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}

		private void OCS0208Q00_UserChanged(object sender, System.EventArgs e)
		{
			//사용자를 가져온다.
			mDoctor = UserInfo.UserID;

            //MessageBox.Show("Before OCS0208 Query ");

            grdOCS0208.SetBindVarValue("f_doctor", mDoctor);

            this.grdOCS0208.QueryLayout(true);

            //MessageBox.Show("After OCS0208 Query ");

            tabGubun.SelectedIndex = mSelectTabInd;
            mBanghyang = tabGubun.TabPages[mSelectTabInd].Tag.ToString();
			SetFilter();	
				
			if(grdOCS0208.RowCount == 0)
				rbtBase.Checked = true;

			if( !TypeCheck.IsNull(mBongYongCode) )
				SetBanghyang_block(mBongYongCode);
			
		}
	

		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{	
			dloSelectValue = grdOCS0208.CloneToLayout();
		}

		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			SetMsg("");

			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;

                    this.grdOCS0208.QueryLayout(true);
					SetFilter();

					break;

				case FunctionType.Process:

					CreateReturnLayout();
					
					break;
					
				default:

					break;
			}
		}

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:
                    
					break;

					
				default:

					break;
			}
		}

		#endregion
        
		#region [Combo 생성]
		
		private void CreateCombo()
		{
			// Combo 세팅
			DataTable dtTemp = null;
			
			// DV_TIME
			// dtTemp = this.mOrderBiz.LoadComboDataSource("dv_time").LayoutTable;
		    dtTemp = Utility.ConvertToDataTable(commonDataResult.DvTimeInfo);
			this.cboDv_time.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);

			// 횟수
			// dtTemp = this.mOrderBiz.LoadComboDataSource("dv").LayoutTable;
		    dtTemp = Utility.ConvertToDataTable(commonDataResult.DvInfo);
			this.cboCnt_perday.SetComboItems(dtTemp, "code_name", "code", XComboSetType.NoAppend);
			this.cboCnt_perday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mOrderBiz.ComBoInt_KeyPress);
		}

		#endregion

        #region 텝 생성
        private void TabCreate()
        {
            

            // 텝 페이햨E생성시 첫번째 페이지가 선택된것으로 간주된다.
            // 따라서 픸E셉똑린?되므로 잠시 이벤트를 없애놓음
            this.tabGubun.SelectionChanged -= new System.EventHandler(this.tabGubun_SelectionChanged);
            layTabGubun.ExecuteQuery = LoadLayTabGubun;
            layTabGubun.QueryLayout(true);
            // 텝 페이햨E생성
            for (int i = 0; i < layTabGubun.RowCount; i++)
            {
                string code = layTabGubun.GetItemString(i, "code");
                string code_name = layTabGubun.GetItemString(i, "code_name");
                string select_gubun = layTabGubun.GetItemString(i, "select_gubun");

                IHIS.X.Magic.Controls.TabPage tabPage =
                    new IHIS.X.Magic.Controls.TabPage(code_name);
                

                /**
                 * 2010.01.20 kimminsoo
                 * inv0102 code_type = '35' --> 복용구분 중 code3 = '1' 인 구분이 선택되게 한다.
                 * ************************************/
                if (select_gubun == "1")
                {
                    tabPage.ImageIndex = 1;
                    tabPage.Selected = true;
                    mSelectTabInd = i;
                }
                else
                {
                    tabPage.ImageIndex = 0;
                    tabPage.Selected = false;
                }
                
                tabPage.Location = new System.Drawing.Point(0, 0);
                tabPage.Name = "page" + code;
                tabPage.Size = new System.Drawing.Size(399, 0);
                //tabPage.TabIndex = i;
                tabPage.Tag = code;
                
                tabGubun.TabPages.Add(tabPage);

            }

            this.tabGubun.SelectionChanged += new System.EventHandler(this.tabGubun_SelectionChanged);
        }
        #endregion

		#region [Control Event]

		private void tabGubun_SelectionChanged(object sender, System.EventArgs e)
		{
			foreach( IHIS.X.Magic.Controls.TabPage page in tabGubun.TabPages)
			{
				if(tabGubun.SelectedTab == page)
				{
					page.ImageIndex = 1;
					mBanghyang = page.Tag.ToString();
					SetFilter();
				}
				else
				{
					page.ImageIndex = 0;
				}
			}
		}
		
		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnLayout();
		}

		private void emSuryang_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(mOpenSetParaValue) return;

			XEditMask numEditMask = sender as XEditMask;
						
			if(e.KeyChar != (char)8 && e.KeyChar != (char)46 && !TypeCheck.IsInt(e.KeyChar.ToString()))
			{
				e.Handled = true;
				return;
			}
		
			if (e.KeyChar == (char)46 && numEditMask.Text.IndexOf(".") >= 0)
			{
				//소수점 재등록을 막는다.
				e.Handled = true;
			}

			try
			{
				//소수점 세자리까지만 들어가도록 막는다.
				if(TypeCheck.IsInt(e.KeyChar.ToString()))
				{					
					int pointPosition = numEditMask.Text.IndexOf(".");
					if( pointPosition >= 0 )
					{
						//현재 select position
						int selectIndex   = numEditMask.SelectionStart;
					
						if( numEditMask.Text.Substring(pointPosition + 1).Length == 3 && selectIndex > pointPosition && selectIndex <= pointPosition + 3 )
						{						
							e.Handled = true;
							numEditMask.Text = numEditMask.Text.Substring(0, selectIndex) + e.KeyChar.ToString() + numEditMask.Text.Substring(selectIndex + 1);
							numEditMask.SelectionStart = selectIndex + 1;
						
						}
						else if ( selectIndex > pointPosition + 3 )
						{
							e.Handled = true;
						}
					}
				}

			}
			catch{}
		}

		private void emSuryang_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(mOpenSetParaValue) return;
			ClearDvValue();		
		}
		

		private void cboDv_time_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(mOpenSetParaValue) return;

			if(cboDv_time.GetDataValue() != "/")
			    SetEnable(0);
			else
                SetEnable(mDv);
		}
		
		private void cboDV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(mOpenSetParaValue) return;

			PostCallHelper.PostCall(new PostMethod(SetDvValue));			
		}

		private void cboDV_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(mOpenSetParaValue) return;
		}

		private void cboDV_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(mOpenSetParaValue) return;
			
			PostCallHelper.PostCall(new PostMethod(SetDvValue));			
		}

		private void SetDvValue()
		{
			if(mOpenSetParaValue) return;

			if(TypeCheck.IsNull(cboDV.GetDataValue()))
				mDv = 1;
			else
				mDv = int.Parse(cboDV.GetDataValue());

			if( mDv.ToString() != cboDV.GetDataValue() )
				cboDV.SetDataValue(mDv);

			SetEnable(mDv);

			grdOCS0208.SetBindVarValue("f_dv", mDv.ToString());
            grdOCS0208.QueryLayout(true);
			SetFilter();
		}

		private void emkDvSuryang_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(mOpenSetParaValue) return;
			
			XEditMask numEditMask = sender as XEditMask;
						
			if(e.KeyChar != (char)8 && e.KeyChar != (char)46 && !TypeCheck.IsInt(e.KeyChar.ToString()))
			{
				e.Handled = true;
				//return;
			}
		
			if (e.KeyChar == (char)46 && numEditMask.Text.IndexOf(".") >= 0)
			{
				//소수점 재등록을 막는다.
				e.Handled = true;
			}

			try
			{
				//소수점 세자리까지만 들어가도록 막는다.
				if(TypeCheck.IsInt(e.KeyChar.ToString()))
				{					
					int pointPosition = numEditMask.Text.IndexOf(".");
					if( pointPosition >= 0 )
					{
						//현재 select position
						int selectIndex   = numEditMask.SelectionStart;
					
						if( numEditMask.Text.Substring(pointPosition + 1).Length == 3 && selectIndex > pointPosition && selectIndex <= pointPosition + 3 )
						{						
							e.Handled = true;
							numEditMask.Text = numEditMask.Text.Substring(0, selectIndex) + e.KeyChar.ToString() + numEditMask.Text.Substring(selectIndex + 1);
							numEditMask.SelectionStart = selectIndex + 1;
						
						}
						else if ( selectIndex > pointPosition + 3 )
						{
							e.Handled = true;
						}
					}
				}

			}
			catch{}		


			
		}

		private void emkDvSuryang_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(mOpenSetParaValue) return;
			PostCallHelper.PostCall(new PostMethod(SetSumSuryang));	
		}

		#endregion

		#region [GrdOCS0208 Event]

		private void grdOCS0208_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				int curRowIndex = grdOCS0208.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				CreateReturnLayout();
			}
		}

		private void grdOCS0208_ALL_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				int curRowIndex = grdOCS0208_ALL.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				CreateReturnLayout();
			}
		}

		private void grdOCS0208_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if(e.CurrentRow < 0) return;
			if(grdOCS0208.GetItemString(e.CurrentRow, "donbog_yn") == "Y")
				cboDv_time.SetDataValue("*");
			else
				cboDv_time.SetDataValue("/");

			SelectionBackColorChange(sender);
		
		}

		

        #endregion

		#region [Return Layout 생성]
        
		private void CreateReturnLayout()
		{
			if( CurrMQLayout == null ) return;

            string currIO_GUBUN = this.grdOCS0208.GetItemString(this.grdOCS0208.CurrentRowNumber, "io_gubun");

            if (this.mIO_GUBUN == "I" && currIO_GUBUN == "O" && this.mInputGubun != "D7")
            {
                XMessageBox.Show(Resources.MSG_001,Resources.CAP_001);
                return;
            }
            if (this.mIO_GUBUN == "O" && currIO_GUBUN == "I")
            {
                XMessageBox.Show(Resources.MSG_002, Resources.CAP_001);
                return;
            }

			this.AcceptData();
            dloSelectValue.Reset();

            for (int i = 0; i < this.CurrMQLayout.RowCount; i++)
			{
                if (((XEditGrid)CurrMQLayout).IsSelectedRow(i))
				{
                    if (this.CurrMQLayout.GetItemValue(i, "bogyong_code").ToString() == "999" && TypeCheck.IsNull(txtOrder_remark.GetDataValue().Trim()))
					{
						mbxCap = "";
						mbxMsg = Resources.MSG_003;
						
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
						this.txtOrder_remark.Focus();
						return;
					}
                    // 선택한 로우만 레이아웃에 담아 던짐
                    dloSelectValue.LayoutTable.ImportRow(CurrMQLayout.LayoutTable.Rows[i]);
				}
			}
														  
			if(dloSelectValue.LayoutTable.Rows.Count < 1 )
				return;
			
			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	
			CommonItemCollection commandParams  = new CommonItemCollection();

			if(!TypeCheck.IsNull(txtOrder_remark.GetDataValue()))
				commandParams.Add( "order_remark", txtOrder_remark.GetDataValue());
			
			commandParams.Add( "OCS0208", dloSelectValue);
			scrOpener.Command(ScreenID, commandParams);

			this.Close();
			
		}
		
		#endregion

		#region [Filtering]

		private void rbtUser_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbtUser.Checked)
			{
				rbtUser.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtUser.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtUser.ImageIndex = 1;

				rbtBase.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtBase.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtBase.ImageIndex = 0;
                
				mGubun = "0";
				
			}
			else
			{
				rbtBase.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
				rbtBase.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
				rbtBase.ImageIndex = 1;

				rbtUser.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
				rbtUser.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
				rbtUser.ImageIndex = 0;

				mGubun = "1";				
			}		

			SetFilter();
		}

		private void SetFilter()
		{
			this.grdOCS0208.ClearFilter();
			if(grdOCS0208.RowCount > 0) 
			{
				// 돈복
				if(mBanghyang == "99")
				{
					grdOCS0208.SetFilter(" gubun = '" + mGubun + "' and donbog_yn = 'Y' ");	
					cboDv_time.SetDataValue("*");
					
				}
				else
				{
					grdOCS0208.SetFilter(" gubun = '" + mGubun + "' and banghyang = '" + mBanghyang + "' ");			
					cboDv_time.SetDataValue("/");
				}
			}
            
			SelectionBackColorChange(this.grdOCS0208);
            UserSangChangeColor(this.grdOCS0208);
		}

		#endregion	
	
		#region [order comment 생성]

		private void btnLimitCnt_perday_Click(object sender, System.EventArgs e)
		{
			string direct_text = "";
			direct_text = txtOrder_remark.GetDataValue() + Resources.DIRECT_TEXT_001 + cboCnt_perday.Text + Resources.DIRECT_TEXT_002;

			txtOrder_remark.SetEditValue(direct_text);			
			txtOrder_remark.Focus();
			txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
		}

		private void btnAct_dq_Click(object sender, System.EventArgs e)
		{
			string direct_text = "";
			direct_text = txtOrder_remark.GetDataValue();

			if(chkAct_dq1.Checked)
				direct_text = direct_text + Resources.DIRECT_TEXT_DQ1;

			if(chkAct_dq2.Checked)
				direct_text = direct_text + Resources.DIRECT_TEXT_DQ2;
			
			if(chkAct_dq3.Checked)
				direct_text = direct_text + Resources.DIRECT_TEXT_DQ3;
			
			if(chkAct_dq4.Checked)
				direct_text = direct_text + Resources.DIRECT_TEXT_DQ4;

			txtOrder_remark.SetEditValue(direct_text);
			
			txtOrder_remark.Focus();
			txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
		
		}

		private void btnAct_Fg_Click(object sender, System.EventArgs e)
		{
			string direct_text = "";
			direct_text = txtOrder_remark.GetDataValue();

			if(chkFg_1.Checked)
				direct_text = direct_text + Resources.DIRECT_TEXT_FG1;

			if(chkFg_2.Checked)
				direct_text = direct_text + Resources.DIRECT_TEXT_FG2;
			
			if(chkFg_3.Checked)
				direct_text = direct_text + Resources.DIRECT_TEXT_FG3;

			txtOrder_remark.SetEditValue(direct_text);
			
			txtOrder_remark.Focus();
			txtOrder_remark.SelectionStart = txtOrder_remark.Text.Length;
		
		}

		#endregion

		#region [Dv값에 따른 Control 처리]
        
		private void ClearDvValue()
		{
			foreach(object obj in this.pnlDv_info.Controls)
			{
				((XEditMask)obj).SetDataValue("");
			}
		}

		private void SetEnable(int aDv)
		{
			int chk = 0;

			foreach(object obj in this.pnlDv_info.Controls)
			{
				chk ++;

				if( chk <= aDv )
					((XEditMask)obj).Enabled = true;
				else
					((XEditMask)obj).Enabled = false;

				((XEditMask)obj).SetDataValue("");
			}
		}

		private void SetSumSuryang()
		{
			double suryang = 0.0;

			foreach(object obj in this.pnlDv_info.Controls)
			{
				if( ((XEditMask)obj).Enabled && !TypeCheck.IsNull(((XEditMask)obj).GetDataValue()) )
				{
					suryang = suryang + double.Parse(((XEditMask)obj).GetDataValue());
				}
			}

			if( suryang > 0) this.emSuryang.SetDataValue(suryang);
		}

		private bool CheckDvValue()
		{
			double suryang = 0.0;

			foreach(object obj in this.pnlDv_info.Controls)
			{
				if( ((XEditMask)obj).Enabled && !TypeCheck.IsNull(((XEditMask)obj).GetDataValue()) )
				{
					suryang = suryang + double.Parse(((XEditMask)obj).GetDataValue());
				}
			}

			if( suryang > 0) 
				return true;
			else
				return false;
		}

		#endregion
        
		#region [ 해당 복용법을 선택한다. ]

		private void SetBanghyang_block(string aBogyong_code)
		{
            MultiLayout layBanghyang = new MultiLayout();

			string banghwang = "";
			string donbok_yn = "";

            layBanghyang.LayoutItems.Clear();
            layBanghyang.LayoutItems.Add("banghwang", DataType.String);
            layBanghyang.LayoutItems.Add("donbok_yn", DataType.String);

            /*layBanghyang.QuerySQL = @"SELECT A.BANGHYANG
                                           , NVL(A.DONBOG_YN, 'N') DONBOG_YN
                                        FROM DRG0120 A
                                       WHERE A.HOSP_CODE    = :f_hosp_code
                                         AND A.BOGYONG_CODE = :f_bogyong_code ";*/
            layBanghyang.SetBindVarValue("f_bogyong_code", aBogyong_code);
            layBanghyang.SetBindVarValue("f_hosp_code",    mHospCode);
		    layBanghyang.ExecuteQuery = LoadLayBanghyang;

			if(layBanghyang.QueryLayout(false))
			{
                banghwang = layBanghyang.GetItemString(0, "banghwang");
                donbok_yn = layBanghyang.GetItemString(0, "donbok_yn");
                				
				//tab page선택
				if( donbok_yn == "Y" )
				{
                    //2011.01.20 kimminsoo 막음.. 웨 핸는지 모르겠지만.. 필요 없을듯...
					//tabGubun.SelectedTab = page99;
				}
				else
				{					
					foreach( IHIS.X.Magic.Controls.TabPage page in tabGubun.TabPages)
					{
						if( page.Tag.ToString() == banghwang)
						{
							tabGubun.SelectedTab = page;
						}
					}
				}

				bool selectBogyongCode = false;

				for( int i = 0; i < grdOCS0208.RowCount; i++ )
				{
					if(grdOCS0208.GetItemString(i, "bogyong_code") == aBogyong_code)
					{
						grdOCS0208.SetFocusToItem(i, 0);
						selectBogyongCode = true;
						break;
					}
				}

				if (!selectBogyongCode )
				{
					if(rbtUser.Checked)
						rbtBase.Checked = true;
					else
						rbtUser.Checked = true;

					for( int i = 0; i < grdOCS0208.RowCount; i++ )
					{
						if(grdOCS0208.GetItemString(i, "bogyong_code") == aBogyong_code)
						{
							grdOCS0208.SetFocusToItem(i, 0);
							break;
						}
					}
				}
			}

		}

		private void SelectBogyong_code(string aBogyong_code)
		{
			for( int i = 0; i < grdOCS0208.RowCount; i++ )
			{
				if(grdOCS0208.GetItemString(i, "bogyong_code") == aBogyong_code)
				{
					grdOCS0208.SetFocusToItem(i, 0);
					break;
				}
			}
		}

        #endregion

        #region grdOCS0208 에 병원코드(f_hosp_code) 를 바인드 셋팅
        private void grdOCS0208_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0208.SetBindVarValue("f_hosp_code", mHospCode);
            grdOCS0208.SetBindVarValue("f_io_gubun", mIO_GUBUN);
        }
        #endregion

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다		
		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.DisplayRowCount; rowIndex++)
			{					
				if(grdObject.IsSelectedRow(rowIndex))
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];
				}
				else
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];					
				}
			}
		}
		#endregion
        #region [使用者服用コード色付け]
        private void UserSangChangeColor(XEditGrid grd)
        {
            XGrid grdObject = grd;
            //기존의 색으로 변경을 시킨다
            for (int rowIndex = 0; rowIndex < grdObject.DisplayRowCount; rowIndex++)
            {
                if (grdObject.GetItemString(rowIndex, "user_yn") != "N")
                {
                    XColor mSelectedForeColor = new XColor(Color.Red);
                    grdObject[rowIndex + grdObject.HeaderHeights.Count, 2].ForeColor = mSelectedForeColor;
                }
            }
        }
        #endregion

        #region cloud service

	    private OCS0208Q00CommonDataResult GetCommonDataResult()
	    {
	        OCS0208Q00CommonDataArgs args = new OCS0208Q00CommonDataArgs();
            args.DvTimeInfo = new ComboDataSourceInfo();
	        args.DvTimeInfo.ColName = "dv_time";
            args.DvInfo = new ComboDataSourceInfo();
            args.DvInfo.ColName = "dv";
            args.BogyongCode = mBongYongCode;
	        return CloudService.Instance.Submit<OCS0208Q00CommonDataResult, OCS0208Q00CommonDataArgs>(args);
	    }

        private List<object[]> LoadLayBanghyang(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (commonDataResult.BanghyangItemList != null)
            {
                foreach (OCS0208Q00LayBanghyangInfo item in commonDataResult.BanghyangItemList)
                {
                    object[] objects = 
					{ 
                        item.Banghyang, 
                        item.DonbogYn
					};
                    res.Add(objects);
                }
            }
            return res;
        }

	    private List<object[]> LoadLayTabGubun(BindVarCollection bc)
	    {
            List<object[]> res = new List<object[]>();
            if (commonDataResult.TabGubunItemList != null)
            {
                foreach (OCS0208Q00LayTabGubunInfo item in commonDataResult.TabGubunItemList)
                {
                    object[] objects = 
						{ 
                            item.Code, 
                            item.CodeName, 
                            item.Code3
						};
                    res.Add(objects);
                }
            }
            return res;
	    }

        private List<string> CreateGrdOCS0208ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_doctor");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0208(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0208Q00GrdOCS0208Args args = new OCS0208Q00GrdOCS0208Args();
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            OCS0208Q00GrdOCS0208Result result = CloudService.Instance.Submit<OCS0208Q00GrdOCS0208Result, OCS0208Q00GrdOCS0208Args>(args);
            if (result != null)
            {
                foreach (OCS0208Q00GrdOCS0208Info item in result.GrdItemList)
                {
                    object[] objects = 
				    { 
					    item.Gubun, 
					    item.BogyongCode, 
					    item.Banghyang, 
					    item.BogyongName, 
					    item.DonbogYn, 
					    item.Dv, 
					    item.SoryKey, 
					    item.UserYn, 
					    item.IoGubun
				    };
                    res.Add(objects);
                }
            }
            return res; 
        }
        #endregion
    }
}

