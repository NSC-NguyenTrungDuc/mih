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
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0204Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0204Q00 : IHIS.Framework.XScreen
	{
		#region [OCS Library]
		private IHIS.OCS.OrderBiz  mOrderBiz  = null;         // OCS 그룹 Business 라이브러리		
		#endregion

		#region [DynService Control]		
//		private IHIS.Framework.ValidationServiceDyn layCommon = new ValidationServiceDyn();
		private IHIS.Framework.SingleLayout layCommon = new SingleLayout();
//		private IHIS.Framework.DataServiceDynMO     mDsdCombo  = new DataServiceDynMO();
		private IHIS.Framework.MultiLayout layCombo = new MultiLayout();
//		private IHIS.Framework.DataServiceDynMO     mDsdCommon = new DataServiceDynMO();
		#endregion

		#region [Instance Variable]		
		//Message처리
		private string mbxMsg = "", mbxCap = "";		
		//사용자
		private string mMemb = "";
		//진료과
		private string mGwa    = "";
		//진료의사
		private string mDoctor = "";

		//진단코드
		private string mSang_code = "";
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XTreeView tvwSang_gubun;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtSang_name_inx;
		private IHIS.Framework.XEditGrid grdOCS0205;
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
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XLabel lblSelectAll;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XComboBox cboMemb;
		private IHIS.Framework.XPanel pnlMemb_1;
		private IHIS.Framework.XComboBox cboGwa;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XComboBox cboDoctor;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XPanel pnlMemb;
		private IHIS.Framework.MultiLayout layReturnValue;
		private IHIS.Framework.MultiLayout layOCS0204;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
		private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
		private System.ComponentModel.IContainer components = null;

		public OCS0204Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
			
			this.mOrderBiz  = new IHIS.OCS.OrderBiz();	// OCS 그룹 Business 라이브러리

            grdOCS0205.ParamList = new List<string>(new String[] { "f_memb", "f_sang_gubun", "f_sang_name_inx" });
		    grdOCS0205.ExecuteQuery = ExecuteQueryGrdOcs0205Item;

            layOCS0204.ParamList = new List<string>(new String[] { "f_memb" });
            layOCS0204.ExecuteQuery = ExecuteQueryGrdOcs0204Item;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0204Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnProcess = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.tvwSang_gubun = new IHIS.Framework.XTreeView();
            this.pnlMemb = new IHIS.Framework.XPanel();
            this.cboMemb = new IHIS.Framework.XComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtSang_name_inx = new IHIS.Framework.XTextBox();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdOCS0205 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.lblSelectAll = new IHIS.Framework.XLabel();
            this.pnlMemb_1 = new IHIS.Framework.XPanel();
            this.cboGwa = new IHIS.Framework.XComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboDoctor = new IHIS.Framework.XComboBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.layReturnValue = new IHIS.Framework.MultiLayout();
            this.layOCS0204 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlMemb.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0205)).BeginInit();
            this.pnlMemb_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layReturnValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0204)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.btnProcess);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
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
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.tvwSang_gubun);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // tvwSang_gubun
            // 
            this.tvwSang_gubun.AccessibleDescription = null;
            this.tvwSang_gubun.AccessibleName = null;
            resources.ApplyResources(this.tvwSang_gubun, "tvwSang_gubun");
            this.tvwSang_gubun.BackgroundImage = null;
            this.tvwSang_gubun.ImageList = this.ImageList;
            this.tvwSang_gubun.Name = "tvwSang_gubun";
            this.tvwSang_gubun.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSang_gubun_AfterSelect);
            // 
            // pnlMemb
            // 
            this.pnlMemb.AccessibleDescription = null;
            this.pnlMemb.AccessibleName = null;
            resources.ApplyResources(this.pnlMemb, "pnlMemb");
            this.pnlMemb.Controls.Add(this.cboMemb);
            this.pnlMemb.Controls.Add(this.xLabel2);
            this.pnlMemb.Controls.Add(this.xLabel1);
            this.pnlMemb.Controls.Add(this.txtSang_name_inx);
            this.pnlMemb.DrawBorder = true;
            this.pnlMemb.Font = null;
            this.pnlMemb.Name = "pnlMemb";
            // 
            // cboMemb
            // 
            this.cboMemb.AccessibleDescription = null;
            this.cboMemb.AccessibleName = null;
            resources.ApplyResources(this.cboMemb, "cboMemb");
            this.cboMemb.BackgroundImage = null;
            this.cboMemb.Name = "cboMemb";
            this.cboMemb.SelectedIndexChanged += new System.EventHandler(this.cboMemb_SelectedIndexChanged);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
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
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // txtSang_name_inx
            // 
            this.txtSang_name_inx.AccessibleDescription = null;
            this.txtSang_name_inx.AccessibleName = null;
            resources.ApplyResources(this.txtSang_name_inx, "txtSang_name_inx");
            this.txtSang_name_inx.BackgroundImage = null;
            this.txtSang_name_inx.Name = "txtSang_name_inx";
            this.txtSang_name_inx.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSang_name_inx_DataValidating);
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.grdOCS0205);
            this.xPanel4.Controls.Add(this.lblSelectAll);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdOCS0205
            // 
            resources.ApplyResources(this.grdOCS0205, "grdOCS0205");
            this.grdOCS0205.ApplyPaintEventToAllColumn = true;
            this.grdOCS0205.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
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
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27});
            this.grdOCS0205.ColPerLine = 3;
            this.grdOCS0205.Cols = 3;
            this.grdOCS0205.ExecuteQuery = null;
            this.grdOCS0205.FixedRows = 1;
            this.grdOCS0205.HeaderHeights.Add(21);
            this.grdOCS0205.Name = "grdOCS0205";
            this.grdOCS0205.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0205.ParamList")));
            this.grdOCS0205.QuerySQL = resources.GetString("grdOCS0205.QuerySQL");
            this.grdOCS0205.Rows = 2;
            this.grdOCS0205.RowStateCheckOnPaint = false;
            this.grdOCS0205.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS0205.ToolTipActive = true;
            this.grdOCS0205.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0205_MouseDown);
            this.grdOCS0205.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS0205_GridCellPainting);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "sang_gubun";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "pk_seq";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "sang_code";
            this.xEditGridCell1.CellWidth = 157;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "display_sang_name";
            this.xEditGridCell2.CellWidth = 440;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "ser";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "sang_name";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "pre_modifier1";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pre_modifier2";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "pre_modifier3";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pre_modifier4";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "pre_modifier5";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "pre_modifier6";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "pre_modifier7";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "pre_modifier8";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "pre_modifier9";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "pre_modifier10";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "pre_modifier_name";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "post_modifier1";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "post_modifier2";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "post_modifier3";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "post_modifier4";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "post_modifier5";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "post_modifier6";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "post_modifier7";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "post_modifier8";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "post_modifier9";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "post_modifier10";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "post_modifier_name";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell27.CellName = "select";
            this.xEditGridCell27.CellWidth = 69;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // lblSelectAll
            // 
            this.lblSelectAll.AccessibleDescription = null;
            this.lblSelectAll.AccessibleName = null;
            resources.ApplyResources(this.lblSelectAll, "lblSelectAll");
            this.lblSelectAll.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectAll.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectAll.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectAll.ImageList = this.ImageList;
            this.lblSelectAll.Name = "lblSelectAll";
            this.lblSelectAll.Click += new System.EventHandler(this.lblSelectAll_Click);
            // 
            // pnlMemb_1
            // 
            this.pnlMemb_1.AccessibleDescription = null;
            this.pnlMemb_1.AccessibleName = null;
            resources.ApplyResources(this.pnlMemb_1, "pnlMemb_1");
            this.pnlMemb_1.Controls.Add(this.cboGwa);
            this.pnlMemb_1.Controls.Add(this.xLabel3);
            this.pnlMemb_1.Controls.Add(this.cboDoctor);
            this.pnlMemb_1.Controls.Add(this.xLabel4);
            this.pnlMemb_1.Font = null;
            this.pnlMemb_1.Name = "pnlMemb_1";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
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
            // 
            // cboDoctor
            // 
            this.cboDoctor.AccessibleDescription = null;
            this.cboDoctor.AccessibleName = null;
            resources.ApplyResources(this.cboDoctor, "cboDoctor");
            this.cboDoctor.BackgroundImage = null;
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.SelectedIndexChanged += new System.EventHandler(this.cboDoctor_SelectedIndexChanged);
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // layReturnValue
            // 
            this.layReturnValue.ExecuteQuery = null;
            this.layReturnValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReturnValue.ParamList")));
            // 
            // layOCS0204
            // 
            this.layOCS0204.ExecuteQuery = null;
            this.layOCS0204.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layOCS0204.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOCS0204.ParamList")));
            this.layOCS0204.QuerySQL = resources.GetString("layOCS0204.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "memb";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "sang_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "sang_gubun_name";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "node";
            // 
            // OCS0204Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.pnlMemb_1);
            this.Controls.Add(this.pnlMemb);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0204Q00";
            this.UserChanged += new System.EventHandler(this.OCS0204Q00_UserChanged);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.pnlMemb.ResumeLayout(false);
            this.pnlMemb.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0205)).EndInit();
            this.pnlMemb_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layReturnValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0204)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					//선택된 환자의 진료과
					if(OpenParam.Contains("gwa"))
					{
						if(!TypeCheck.IsNull(OpenParam["gwa"].ToString()))
							mGwa = OpenParam["gwa"].ToString();
					}
                    
					//선택한 환자의 진료의
					if(OpenParam.Contains("doctor"))
					{
						if(!TypeCheck.IsNull(OpenParam["doctor"].ToString()))
							mDoctor = OpenParam["doctor"].ToString();
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
			CreateLayout();

			/// 사용자 변경 Event Call //////////////////////////////////
			this.OCS0204Q00_UserChanged(this, new System.EventArgs()); 
			///////////////////////////////////////////////////////////////
		}

		private void OCS0204Q00_UserChanged(object sender, System.EventArgs e)
		{
			//사용자가 회계직원인 경우에는 진료과와 진료의사를 선택할 수 있도록 한다.
			if (UserInfo.BuseoCode.PadRight(10).Substring(0, 2) == "44")
			{
				this.pnlMemb.Visible   = false;
				this.pnlMemb_1.Visible = true;
				CreateGwaCombo();
			}
			else
			{
				this.pnlMemb.Visible   = true ;
				this.pnlMemb_1.Visible = false;
				
				// 사용자가 의사인 경우에는 해당 과 전체 의사를 조회할 수 있도록 한다.
				if(UserInfo.UserGubun == UserType.Doctor)
				{
					CreateUserCombo();

                    if (UserInfo.UserGubun == UserType.Doctor)
                    {
                        if (this.cboMemb.ComboItems.Contains(UserInfo.DoctorID))
                        {
                            this.cboMemb.SetEditValue(UserInfo.DoctorID);
                            this.cboMemb.AcceptData();
                        }
                    }
				}
				else
				{
					//memb reset
					this.cboMemb.DataSource = null;
					XComboItem cboItem;

					if(!TypeCheck.IsNull(UserInfo.SangOpenID))
					{
						cboItem = new XComboItem(UserInfo.SangOpenID, GetOCS_USER_NAME(UserInfo.SangOpenID)); 
						cboMemb.ComboItems.Add(cboItem);
						cboMemb.SelectedIndex = 0;
					}
				}
			}		
		}

		private void CreateLayout()
		{
			layReturnValue = grdOCS0205.CloneToLayout();
		}
		#endregion

		#region [ 사용자 combo ]        
		private void cboMemb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.pnlMemb.Visible)
			{
				if( TypeCheck.IsNull(cboMemb.GetDataValue()))
					mMemb = "";
				else
					mMemb = cboMemb.GetDataValue();

				LoadUserSangInfo();
			}
		}
		#endregion

		#region [진료과, 진료의사 Combo]		
		private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CreateDoctorCombo(cboGwa.GetDataValue());
		}

		private void cboDoctor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.pnlMemb_1.Visible)
			{
				if( TypeCheck.IsNull(cboDoctor.GetDataValue()))
					mMemb = "";
				else
					mMemb = cboDoctor.GetDataValue();

				LoadUserSangInfo();
			}
		}
		#endregion

		#region [OCS SangOpenID 명을 가져옵니다.]
		private string GetOCS_USER_NAME(string aUser_id)
		{
			string comUser_name = "";

			layCommon.Reset();
			layCommon.QuerySQL = ""
				+ " SELECT MEMB_NAME "
				+ "   FROM OCS0130 "
				+ "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                + "    AND MEMB = '" + aUser_id + "' ";

			layCommon.LayoutItems.Clear();
            layCommon.LayoutItems.Add("user_name", false);
                    
			if(layCommon.QueryLayout())
				comUser_name = layCommon.GetItemValue("user_name").ToString();

			return comUser_name;
		}
		#endregion

		#region [Combo 생성]		
		private void CreateUserCombo()
		{
			IHIS.Framework.MultiLayoutItem sangOpenId = new MultiLayoutItem();
			sangOpenId.DataName = "sang_open_id";
			sangOpenId.DataType = IHIS.Framework.DataType.String;
			IHIS.Framework.MultiLayoutItem doctorName = new MultiLayoutItem();
			doctorName.DataName = "doctor_name";
			doctorName.DataType = IHIS.Framework.DataType.String;

			layCombo.Reset();
			layCombo.LayoutItems.Clear();
			layCombo.LayoutItems.Add(sangOpenId);
			layCombo.LayoutItems.Add(doctorName);
			layCombo.InitializeLayoutTable();
			
			/*layCombo.QuerySQL = " "
				+ " SELECT A.DOCTOR, A.DOCTOR_NAME "
				+ "   FROM BAS0270 A "
                + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                + "    AND A.DOCTOR_GWA = '" + UserInfo.Gwa + "' "
				+ "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) "
				+ "  ORDER BY SUBSTR(A.DOCTOR, 3, 1), A.DOCTOR                               ";    */

            layCombo.ParamList = new List<string>(new String[] { "f_gwa" });
            layCombo.SetBindVarValue("f_gwa", UserInfo.Gwa);
            layCombo.ExecuteQuery = ExecuteQueryLoadCBoDoctor;
			if(layCombo.QueryLayout(false))
			{
				cboMemb.SetComboItems( layCombo.LayoutTable, "doctor_name", "sang_open_id");
				cboMemb.SetDataValue(UserInfo.SangOpenID);
			}
		}

		private void CreateGwaCombo()
		{
			IHIS.Framework.MultiLayoutItem gwaItem = new MultiLayoutItem();
			gwaItem.DataName = "gwa";
			gwaItem.DataType = IHIS.Framework.DataType.String;
			IHIS.Framework.MultiLayoutItem gwaNameItem = new MultiLayoutItem();
			gwaNameItem.DataName = "gwa_name";
			gwaNameItem.DataType = IHIS.Framework.DataType.String;

			//SLIP_GUBUN DataLayout;
			layCombo.Reset();
			layCombo.LayoutItems.Clear();
			layCombo.LayoutItems.Add(gwaItem);
			layCombo.LayoutItems.Add(gwaNameItem);
			layCombo.InitializeLayoutTable();
			
			/*layCombo.QuerySQL = " "
				+ " SELECT A.GWA, A.BUSEO_NAME " 
				+ "   FROM BAS0260 A " 
				+ "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                + "    AND ( A.OUT_JUBSU_YN = 'Y' OR A.IPWON_YN = 'Y') " 
				+ "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) "
				+ "  ORDER BY A.GWA ";*/

            layCombo.ExecuteQuery = ExecuteQueryComboGwa;
			if(layCombo.QueryLayout(false))
			{
				cboGwa.SetComboItems( layCombo.LayoutTable, "gwa_name", "gwa", XComboSetType.AppendNone);
				if (!TypeCheck.IsNull(mGwa) )
				{
					cboGwa.SetDataValue(mGwa);
					mGwa = "";
				}
				else
					cboGwa.SelectedIndex = 0;
			}
		}

		private void CreateDoctorCombo(string aGwa)
		{
			cboDoctor.DataSource = null;

			IHIS.Framework.MultiLayoutItem sangOpenId = new MultiLayoutItem();
			sangOpenId.DataName = "sang_open_id";
			sangOpenId.DataType = IHIS.Framework.DataType.String;
			IHIS.Framework.MultiLayoutItem doctorName = new MultiLayoutItem();
			doctorName.DataName = "doctor_name";
			doctorName.DataType = IHIS.Framework.DataType.String;

			layCombo.Reset();
			layCombo.LayoutItems.Clear();
			layCombo.LayoutItems.Add(sangOpenId);
			layCombo.LayoutItems.Add(sangOpenId);
			layCombo.InitializeLayoutTable();
			
			/*layCombo.QuerySQL = " "
				+ " SELECT B.SANG_OPEN_ID, A.DOCTOR_NAME "
				+ "   FROM OCS0130 B, "
				+ "        BAS0270 A "
				+ "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                + "    AND A.DOCTOR_GWA = '" + aGwa + "' "
				+ "    AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) "
                + "    AND B.HOSP_CODE = A.HOSP_CODE "
                + "    AND B.MEMB = A.SABUN "
				+ "  ORDER BY 1 ";*/

            layCombo.ParamList = new List<string>(new String[] { "f_gwa" });
            layCombo.SetBindVarValue("f_gwa", aGwa);
            layCombo.ExecuteQuery = ExecuteQueryLoadCBoDoctor2;
			if(layCombo.QueryLayout(false))
			{
				cboDoctor.SetComboItems( layCombo.LayoutTable, "doctor_name", "sang_open_id",  XComboSetType.AppendNone);
				if( !TypeCheck.IsNull(mDoctor) )
				{
					cboDoctor.SetDataValue (mDoctor);
					mDoctor = "";
				}
				else
					cboDoctor.SelectedIndex = 0;
			}
			else
			{
				cboDoctor.SetComboItems( layCombo.LayoutTable, "doctor_name", "sang_open_id",  XComboSetType.AppendNone);
				cboDoctor.SelectedIndex = 0;
			}
		}
		#endregion

		#region [Control Event]
		private void tvwSang_gubun_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if( tvwSang_gubun.SelectedNode.Tag.ToString().Trim() == "" ) return;
			//initailize
			BackSelectRow();
			this.grdOCS0205.SetBindVarValue("f_memb", mMemb);
			this.grdOCS0205.SetBindVarValue("f_sang_gubun" , tvwSang_gubun.SelectedNode.Tag.ToString());
            this.grdOCS0205.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			txtSang_name_inx.SetDataValue("");
			this.grdOCS0205.SetBindVarValue("f_sang_name_inx" , "");
			if(grdOCS0205.QueryLayout(false))
			{
				lblSelectAll.ImageIndex = 2;
                lblSelectAll.Text = Properties.Resources.LableSelectAll1;
				SetSelect();
			}
		}

		private void txtSang_name_inx_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if(e.DataValue.Trim() == "") return;
			LoadOCS0205();
		}
		
		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			CreateReturnValue();			
		}

		private void lblSelectAll_Click(object sender, System.EventArgs e)
		{
			if(lblSelectAll.ImageIndex == 2)
			{
				grdSelectAll(this.grdOCS0205, true);
				lblSelectAll.ImageIndex = 3;
                lblSelectAll.Text = Properties.Resources.LableSelectAll2;
			}
			else
			{
				grdSelectAll(this.grdOCS0205, false);
				lblSelectAll.ImageIndex = 2;
                lblSelectAll.Text = Properties.Resources.LableSelectAll3;
			}
		}
        
		/// <summary>
		/// 해당 Grid 전체선택 해제
		/// </summary>
		/// <param name="grd"></param>
		/// <param name="select"></param>
		private void grdSelectAll(XGrid grdObject, bool select)
		{
			int rowIndex = -1;

			if(select)
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					grdObject.SetItemValue(rowIndex, "select", " ");
				}
			}
			else
			{
				for(rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
				{
					grdObject.SetItemValue(rowIndex, "select", "");
				}
			}
			SelectionBackColorChange(grdObject);
            
			//선택된 Tab표시
			SetSelectTab();
		}		
		#endregion

		#region [Function]
		private void LoadUserSangInfo()
		{
			this.layReturnValue.Reset();
			this.grdOCS0205.Reset();

			this.layOCS0204.SetBindVarValue("f_memb", mMemb);
            this.layOCS0204.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

			//TreeView
			tvwSang_gubun.Nodes.Clear();
			TreeNode node = new TreeNode( Resources.MSG_4 );
			node.Tag = "";
			tvwSang_gubun.Nodes.Add(node);	

			try
			{
				if(layOCS0204.QueryLayout(false))
				{
					//TreeView를 생성한다.
					if(layOCS0204.RowCount > 0)
					{
						TreeNode eventNode;				
						int      node1 = 0;
						foreach(DataRow row in layOCS0204.LayoutTable.Rows)
						{   
							eventNode = new TreeNode( "[" + row["sang_gubun"].ToString() + "]" + row["sang_gubun_name"].ToString() );
							eventNode.Tag = row["sang_gubun"].ToString();
							eventNode.ImageIndex = 2;
							eventNode.SelectedImageIndex = 2;	
							tvwSang_gubun.Nodes[0].Nodes.Add(eventNode);
							row["node"] = node1;
							node1++;
						}
						tvwSang_gubun.SelectedNode = tvwSang_gubun.Nodes[0].Nodes[0];
					}
				}

				if(this.mSang_code != "")
				{
					txtSang_name_inx.SetDataValue(mSang_code);
					LoadOCS0205();
				}
			}
			catch (Exception ex)
			{
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// 해당 Grid가 다시 load되기 전에 선택된 row를 backup
		/// </summary>
		private void BackSelectRow()
		{
			this.AcceptData();

			foreach(DataRow row in grdOCS0205.LayoutTable.Rows)
			{
				if(row["select"].ToString() == " ")
					layReturnValue.LayoutTable.ImportRow(row);				
			}

			SetSelectTab();
		}
	    
		private void SetSelect()
		{
			DataRow[] backSelectRow;
			foreach(DataRow row in grdOCS0205.LayoutTable.Rows)
			{
				backSelectRow = layReturnValue.LayoutTable.Select("sang_gubun = '" + row["sang_gubun"].ToString() + "' and pk_seq = " + row["pk_seq"].ToString() + " ", "");

				if(backSelectRow.Length > 0)
				{
					row["select"] = " ";
					//backSelectRow는 삭제한다.
					layReturnValue.LayoutTable.Rows.Remove(backSelectRow[0]);
				}
			}

			SelectionBackColorChange(grdOCS0205);
		}

		private void ClearSelect()
		{
			//선택된 Tab
			ClearSelectTab();

			//선택된 row Clear
			for(int i = 0; i < this.grdOCS0205.RowCount; i++)
			{
				grdOCS0205.SetItemValue(i, "select", "");
			}

			SelectionBackColorChange(grdOCS0205);
			layReturnValue.Reset();
		}
        
		/// <summary>
		/// tree node의 이미지를 Clear한다.
		/// </summary>
		private void ClearSelectTab()
		{			
			for(int i = 0; i < layOCS0204.RowCount; i++)	
			{
				tvwSang_gubun.Nodes[0].Nodes[i].ImageIndex = 2;
				tvwSang_gubun.Nodes[0].Nodes[i].SelectedImageIndex = 2;
			}
		}

		/// <summary>
		/// 선택된 항목이 있는 경우 tab의 이미지를 변경한다.
		/// 조건검색에 따른 항목조회가 있기 때문에 선택된 항목 전체를 check한다.
		/// </summary>
		private void SetSelectTab()
		{
			ClearSelectTab();
            
			DataRow[] sang_gubun;
			int       node;
            
			//선택되어진 항목
			foreach(DataRow row in layReturnValue.LayoutTable.Rows)
			{
				//해당 항목의 sang_gubun정보를 가져온다.
				sang_gubun = layOCS0204.LayoutTable.Select(" sang_gubun = '" + row["sang_gubun"].ToString() + "' ", "");
				if(sang_gubun.Length < 1) continue;
				node = int.Parse(sang_gubun[0]["node"].ToString());
				tvwSang_gubun.Nodes[0].Nodes[node].ImageIndex = 3;
				tvwSang_gubun.Nodes[0].Nodes[node].SelectedImageIndex = 3;
			}

			//선택된 항목
			//space는 filter를 못함 --;
			for(int rowIndex = 0; rowIndex < grdOCS0205.RowCount; rowIndex++)
			{
				if(grdOCS0205.GetItemString(rowIndex, "select") == "") continue;
				//해당 항목의 xray_gubun정보를 가져온다.
				sang_gubun = layOCS0204.LayoutTable.Select(" sang_gubun = '" + grdOCS0205.GetItemString(rowIndex, "sang_gubun")  + "' ", "");
			
				if(sang_gubun.Length < 1) continue;
				node = int.Parse(sang_gubun[0]["node"].ToString());
				tvwSang_gubun.Nodes[0].Nodes[node].ImageIndex = 3;
				tvwSang_gubun.Nodes[0].Nodes[node].SelectedImageIndex = 3;
			}			
		}

		/// <summary>
		/// 선택한정보를 layReturnValue로 생성합니다.		
		/// </summary>
		private void CreateReturnValue()
		{  
			this.AcceptData();
			
			BackSelectRow();

			if(layReturnValue.RowCount < 1) 
			{
				mbxMsg = Resources.MSG_1;
				mbxCap = Resources.CAP_1;
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
				return;
			}

			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "OCS0205", layReturnValue);
			scrOpener.Command(ScreenID, commandParams);
            
			this.Close();
		}

		/// <summary>
		/// 상병정보를 조회합니다.
		/// </summary>
		private void LoadOCS0205()
		{	
			BackSelectRow();

			string sang_name_inx  = txtSang_name_inx.GetDataValue().Trim();
		
			if( sang_name_inx.Length < 1)
			{
				mbxMsg = Resources.MSG_2;
				mbxCap = Resources.CAP_1;
				XMessageBox.Show(mbxMsg, mbxCap);						
				return;
			}

			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
				
				string msg = Resources.MSG_3;
				SetMsg(msg);

                this.grdOCS0205.SetBindVarValue("f_sang_gubun", "%");
                this.grdOCS0205.SetBindVarValue("f_sang_name_inx", sang_name_inx);
                this.grdOCS0205.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

				if(grdOCS0205.QueryLayout(false))
				{
					lblSelectAll.ImageIndex = 2;
                    lblSelectAll.Text = Resources.LableSelectAll3;
					SetSelect();
				}
			}
			finally
			{
				SetMsg("");
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
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
					LoadOCS0205();
					break;					
				default:
					break;
			}
		}
		#endregion

		#region [grdOCS0205 ]
		private void grdOCS0205_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				CreateReturnValue();
			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS0205.CurrentColNumber == 0)
			{
				curRowIndex = grdOCS0205.GetHitRowNumber(e.Y);				
				if(curRowIndex < 0) return;

				if(grdOCS0205.CurrentColNumber == 0)
				{	
					if(grdOCS0205.GetItemString(curRowIndex, "select") == "")
					{
						grdOCS0205.SetItemValue(curRowIndex, "select", " ");
						SelectionBackColorChange(sender, curRowIndex, "Y");
						SetSelectTab();
					}
					else
					{
						grdOCS0205.SetItemValue(curRowIndex, "select", "");
						SelectionBackColorChange(sender, curRowIndex, "N");
						SetSelectTab();
					}
				}
			}		
		}

		#region  필드 색상/폰트 관리 Event (GridCellPainting)
		/// <remarks>
		/// 로직으로 필드 색상 변경
		/// </remarks>
		private void grdOCS0205_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (sender == null || e.RowNumber < 0) return;

			XEditGrid grd = sender as XEditGrid;
			// 상병종료일이 입력되지 않은 경우는 종료사유 입력 불가
			switch (e.ColName)
			{
				case "display_sang_name": // Display 상병명
					// 암 관련 상병명 암 표현법 (癌표시를 CA로 표시함) 
			        OrderVariables.CommonInfo.SetCommonInfo();
					grd[e.RowNumber, e.ColName].DisplayText = this.mOrderBiz.DisplayCancerSangName(OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString(), grd[e.RowNumber, e.ColName].DisplayText);
					break;					
			}
		}
		#endregion
	
		#endregion

		#region 그리드에서 선택한 Row에 대한 BackColor를 변경한다
		private void SelectionBackColorChange(object grd, int currentRowIndex, string data)
		{
			XGrid grdObject = (XGrid)grd;
			//선택된 Row에대해서 색을 변경한다
			//data   Y :색을 변경, N :색을 변경 해제
			//image 설정
			if(data == "Y")
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];

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

		private void SelectionBackColorChange(object grd)
		{
			XGrid grdObject = (XGrid)grd;

			//기존의 색으로 변경을 시킨다
			for(int rowIndex = 0; rowIndex < grdObject.RowCount; rowIndex++)
			{	
				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];					

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
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[2];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion	

        #region
        /// <summary>
        /// ExecuteQueryGrdOcs0205Item
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOcs0205Item(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0204Q00GrdOCS0205Args vOCS0204Q00GrdOCS0205Args = new OCS0204Q00GrdOCS0205Args();
            vOCS0204Q00GrdOCS0205Args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            vOCS0204Q00GrdOCS0205Args.SangGubun = bc["f_sang_gubun"] != null ? bc["f_sang_gubun"].VarValue : "";
            vOCS0204Q00GrdOCS0205Args.SangNameInx = bc["f_sang_name_inx"] != null ? bc["f_sang_name_inx"].VarValue : "";
            OCS0204Q00GrdOCS0205Result result = CloudService.Instance.Submit<OCS0204Q00GrdOCS0205Result, OCS0204Q00GrdOCS0205Args>(vOCS0204Q00GrdOCS0205Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (Ocs0204Q00GrdOcs0205ListItemInfo item in result.Grdocs0205Info)
                {
                    object[] objects =
                    {
                        item.SangGubun,
                        item.PkSeq,
                        item.SangCode,
                        item.DisSangName,
                        item.Ser,
                        item.SangName,
                        item.PreModifier1,
                        item.PreModifier2,
                        item.PreModifier3,
                        item.PreModifier4,
                        item.PreModifier5,
                        item.PreModifier6,
                        item.PreModifier7,
                        item.PreModifier8,
                        item.PreModifier9,
                        item.PreModifier10,
                        item.PreModifierName,
                        item.PostModifier1,
                        item.PostModifier2,
                        item.PostModifier3,
                        item.PostModifier4,
                        item.PostModifier5,
                        item.PostModifier6,
                        item.PostModifier7,
                        item.PostModifier8,
                        item.PostModifier9,
                        item.PostModifier10,
                        item.PostModifierName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        
        /// <summary>
        /// ExecuteQueryGrdOcs0204Item
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGrdOcs0204Item(BindVarCollection bc)
        {
            
            List<object[]> res = new List<object[]>();
            OCS0204Q00LayOCS0204Args vOCS0204Q00LayOCS0204Args = new OCS0204Q00LayOCS0204Args();
            vOCS0204Q00LayOCS0204Args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            OCS0204Q00LayOCS0204Result result = CloudService.Instance.Submit<OCS0204Q00LayOCS0204Result, OCS0204Q00LayOCS0204Args>(vOCS0204Q00LayOCS0204Args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (Ocs0204Q00GrdOcs0204ListItemInfo item in result.LayOCS0204Info)
                {
                    object[] objects = 
				{ 
					item.Memb, 
					item.SangGubun, 
					item.SangGubunName, 
					item.Seq
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGetOcsUserName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0204Q00GetOcsUserNameArgs vOCS0204Q00GetOcsUserNameArgs = new OCS0204Q00GetOcsUserNameArgs();
            vOCS0204Q00GetOcsUserNameArgs.UserId = bc["f_user_id"] != null ? bc["f_user_id"].VarValue : "";
            OCS0204Q00GetOcsUserNameResult result =
                CloudService.Instance.Submit<OCS0204Q00GetOcsUserNameResult, OCS0204Q00GetOcsUserNameArgs>(
                    vOCS0204Q00GetOcsUserNameArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[] {result.MembName});
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> ExecuteQueryLoadCBoDoctor(BindVarCollection bc)
	    {
            List<object[]> res = new List<object[]>();
            OCS0204Q00CreateDoctorComboArgs args = new OCS0204Q00CreateDoctorComboArgs();
	        args.Gwa = bc["f_gwa"]!= null ? bc["f_gwa"].VarValue : "";
	        ComboResult comboResult = CloudService.Instance.Submit<ComboResult, OCS0204Q00CreateDoctorComboArgs>(args);
	        if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (ComboListItemInfo info in comboResult.ComboItem)
	            {
	                res.Add(new object[]{info.Code, info.CodeName});
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryLoadCBoDoctor2(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0204Q00CreateDoctorCombo1Args args = new OCS0204Q00CreateDoctorCombo1Args();
            args.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, OCS0204Q00CreateDoctorCombo1Args>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    res.Add(new object[] { info.Code, info.CodeName });
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryComboGwa
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
	    private List<object[]> ExecuteQueryComboGwa(BindVarCollection bc)
	    {
            List<object[]> res = new List<object[]>();
            CreateGwaComboArgs args = new CreateGwaComboArgs();
	        ComboResult comboResult =
	            CacheService.Instance.Get<CreateGwaComboArgs, ComboResult>(args,delegate(ComboResult result)
	                {
	                    return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
	                           result.ComboItem != null;
	                } );
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    res.Add(new object[] { info.Code, info.CodeName });
                }
            }
            return res;
	    } 
        #endregion
	}
}