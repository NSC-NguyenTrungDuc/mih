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
using IHIS.CloudConnector.Contracts.Arguments.Chts;
using IHIS.CloudConnector.Contracts.Models.Chts;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.Framework;
#endregion

namespace IHIS.CHTS
{
	/// <summary>
	/// CHT0115Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CHT0115Q00 : IHIS.Framework.XScreen
	{
		//Message처리
		string mbxMsg = "", mbxCap = "";	
		
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XLabel xLabel62;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGrid grdPre_modifier;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGrid grdPost_modifier;
		private IHIS.Framework.XTreeView tvwPre_modifier;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.MultiLayout dloSangInfo;
		private IHIS.Framework.XButton btnSearchPre_code;
		private IHIS.Framework.XButton btnSearchPost_code;
		private IHIS.Framework.XTextBox txtPre_modifier_name;
		private IHIS.Framework.XTextBox txtPost_modifier_name;
		private IHIS.Framework.XButton btnDeletePre_modifier;
		private IHIS.Framework.XButton btnDeletePost_modifier;
		private IHIS.Framework.XButton btnProcess;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
		private IHIS.Framework.XFlatLabel xFlatLabel2;
		private IHIS.Framework.XFlatLabel xFlatLabel3;
		private IHIS.Framework.XLabel lblSang_name;
        private IHIS.Framework.XEditGrid grdScPre_modifier;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGrid grdScPost_modifier;
		private IHIS.Framework.XButton btnDownPre_modifier;
		private IHIS.Framework.XButton btnUpPre_modifier;
		private IHIS.Framework.XButton btnUpPost_modifier;
		private IHIS.Framework.XButton btnDownPost_modifier;
        private MultiLayout layLDCHT0115;
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
        private MultiLayoutItem multiLayoutItem23;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CHT0115Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		    grdScPost_modifier.ParamList = CreateGrdScPostParamList();
		    grdScPost_modifier.ExecuteQuery = LoadGrdScPost;
		    grdScPre_modifier.ParamList = CreateGrdScPreParamList();
		    grdScPre_modifier.ExecuteQuery = LoadGrdScPre;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHT0115Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnProcess = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.lblSang_name = new IHIS.Framework.XLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnUpPre_modifier = new IHIS.Framework.XButton();
            this.btnDownPre_modifier = new IHIS.Framework.XButton();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.tvwPre_modifier = new IHIS.Framework.XTreeView();
            this.btnSearchPre_code = new IHIS.Framework.XButton();
            this.txtPre_modifier_name = new IHIS.Framework.XTextBox();
            this.grdPre_modifier = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xLabel62 = new IHIS.Framework.XLabel();
            this.btnDeletePre_modifier = new IHIS.Framework.XButton();
            this.grdScPre_modifier = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnDownPost_modifier = new IHIS.Framework.XButton();
            this.btnUpPost_modifier = new IHIS.Framework.XButton();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.btnDeletePost_modifier = new IHIS.Framework.XButton();
            this.btnSearchPost_code = new IHIS.Framework.XButton();
            this.txtPost_modifier_name = new IHIS.Framework.XTextBox();
            this.grdPost_modifier = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdScPost_modifier = new IHIS.Framework.XEditGrid();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.dloSangInfo = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.layLDCHT0115 = new IHIS.Framework.MultiLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPre_modifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdScPre_modifier)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPost_modifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdScPost_modifier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSangInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLDCHT0115)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.BorderColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xPanel1.Controls.Add(this.btnProcess);
            this.xPanel1.Controls.Add(this.btnClose);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.lblSang_name);
            this.xPanel2.Controls.Add(this.xFlatLabel1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // lblSang_name
            // 
            resources.ApplyResources(this.lblSang_name, "lblSang_name");
            this.lblSang_name.Name = "lblSang_name";
            // 
            // xFlatLabel1
            // 
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // xPanel3
            // 
            this.xPanel3.BorderColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xPanel3.Controls.Add(this.btnUpPre_modifier);
            this.xPanel3.Controls.Add(this.btnDownPre_modifier);
            this.xPanel3.Controls.Add(this.xFlatLabel2);
            this.xPanel3.Controls.Add(this.tvwPre_modifier);
            this.xPanel3.Controls.Add(this.btnSearchPre_code);
            this.xPanel3.Controls.Add(this.txtPre_modifier_name);
            this.xPanel3.Controls.Add(this.grdPre_modifier);
            this.xPanel3.Controls.Add(this.xLabel62);
            this.xPanel3.Controls.Add(this.btnDeletePre_modifier);
            this.xPanel3.Controls.Add(this.grdScPre_modifier);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnUpPre_modifier
            // 
            this.btnUpPre_modifier.Image = ((System.Drawing.Image)(resources.GetObject("btnUpPre_modifier.Image")));
            resources.ApplyResources(this.btnUpPre_modifier, "btnUpPre_modifier");
            this.btnUpPre_modifier.Name = "btnUpPre_modifier";
            this.btnUpPre_modifier.Click += new System.EventHandler(this.btnUpPre_modifier_Click);
            // 
            // btnDownPre_modifier
            // 
            this.btnDownPre_modifier.Image = ((System.Drawing.Image)(resources.GetObject("btnDownPre_modifier.Image")));
            resources.ApplyResources(this.btnDownPre_modifier, "btnDownPre_modifier");
            this.btnDownPre_modifier.Name = "btnDownPre_modifier";
            this.btnDownPre_modifier.Click += new System.EventHandler(this.btnDownPre_modifier_Click);
            // 
            // xFlatLabel2
            // 
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.Name = "xFlatLabel2";
            // 
            // tvwPre_modifier
            // 
            resources.ApplyResources(this.tvwPre_modifier, "tvwPre_modifier");
            this.tvwPre_modifier.HideSelection = false;
            this.tvwPre_modifier.ImageList = this.ImageList;
            this.tvwPre_modifier.Name = "tvwPre_modifier";
            this.tvwPre_modifier.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwPre_modifier_AfterSelect);
            // 
            // btnSearchPre_code
            // 
            this.btnSearchPre_code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPre_code.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPre_code.Image")));
            resources.ApplyResources(this.btnSearchPre_code, "btnSearchPre_code");
            this.btnSearchPre_code.Name = "btnSearchPre_code";
            this.btnSearchPre_code.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSearchPre_code.Click += new System.EventHandler(this.btnSearchPre_code_Click);
            // 
            // txtPre_modifier_name
            // 
            resources.ApplyResources(this.txtPre_modifier_name, "txtPre_modifier_name");
            this.txtPre_modifier_name.Name = "txtPre_modifier_name";
            this.txtPre_modifier_name.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtPre_modifier_name_DataValidating);
            // 
            // grdPre_modifier
            // 
            this.grdPre_modifier.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdPre_modifier.ColPerLine = 1;
            this.grdPre_modifier.Cols = 2;
            this.grdPre_modifier.ExecuteQuery = null;
            this.grdPre_modifier.FixedCols = 1;
            this.grdPre_modifier.FixedRows = 1;
            this.grdPre_modifier.HeaderHeights.Add(0);
            resources.ApplyResources(this.grdPre_modifier, "grdPre_modifier");
            this.grdPre_modifier.Name = "grdPre_modifier";
            this.grdPre_modifier.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPre_modifier.ParamList")));
            this.grdPre_modifier.ReadOnly = true;
            this.grdPre_modifier.RowHeaderVisible = true;
            this.grdPre_modifier.Rows = 2;
            this.grdPre_modifier.RowStateCheckOnPaint = false;
            this.grdPre_modifier.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdPre_modifier_GiveFeedback);
            this.grdPre_modifier.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdPre_modifier_DragEnter);
            this.grdPre_modifier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPre_modifier_MouseDown);
            this.grdPre_modifier.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdPre_modifier_DragDrop);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pre_modifier";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "pre_modifier_name";
            this.xEditGridCell2.CellWidth = 144;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xLabel62
            // 
            this.xLabel62.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel62.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel62.BorderColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            resources.ApplyResources(this.xLabel62, "xLabel62");
            this.xLabel62.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel62.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel62.Name = "xLabel62";
            // 
            // btnDeletePre_modifier
            // 
            this.btnDeletePre_modifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePre_modifier.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePre_modifier.Image")));
            resources.ApplyResources(this.btnDeletePre_modifier, "btnDeletePre_modifier");
            this.btnDeletePre_modifier.Name = "btnDeletePre_modifier";
            this.btnDeletePre_modifier.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDeletePre_modifier.Click += new System.EventHandler(this.btnDeletePre_modifier_Click);
            // 
            // grdScPre_modifier
            // 
            resources.ApplyResources(this.grdScPre_modifier, "grdScPre_modifier");
            this.grdScPre_modifier.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10});
            this.grdScPre_modifier.ColPerLine = 1;
            this.grdScPre_modifier.Cols = 1;
            this.grdScPre_modifier.ExecuteQuery = null;
            this.grdScPre_modifier.FixedRows = 1;
            this.grdScPre_modifier.HeaderHeights.Add(21);
            this.grdScPre_modifier.Name = "grdScPre_modifier";
            this.grdScPre_modifier.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdScPre_modifier.ParamList")));
            this.grdScPre_modifier.QuerySQL = resources.GetString("grdScPre_modifier.QuerySQL");
            this.grdScPre_modifier.Rows = 2;
            this.grdScPre_modifier.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdScPre_modifier_GiveFeedback);
            this.grdScPre_modifier.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdScPre_modifier_DragEnter);
            this.grdScPre_modifier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdScPre_modifier_MouseDown);
            this.grdScPre_modifier.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdScPre_modifier_DragDrop);
            this.grdScPre_modifier.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdScPre_modifier_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "susik_code";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.CellName = "susik_name";
            this.xEditGridCell7.CellWidth = 175;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "susik_name_gana";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "susik_detail_gubun";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "seq";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xPanel4
            // 
            this.xPanel4.BorderColor = IHIS.Framework.XColor.InsertedForeColor;
            this.xPanel4.Controls.Add(this.btnDownPost_modifier);
            this.xPanel4.Controls.Add(this.btnUpPost_modifier);
            this.xPanel4.Controls.Add(this.xFlatLabel3);
            this.xPanel4.Controls.Add(this.btnDeletePost_modifier);
            this.xPanel4.Controls.Add(this.btnSearchPost_code);
            this.xPanel4.Controls.Add(this.txtPost_modifier_name);
            this.xPanel4.Controls.Add(this.grdPost_modifier);
            this.xPanel4.Controls.Add(this.xLabel1);
            this.xPanel4.Controls.Add(this.grdScPost_modifier);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // btnDownPost_modifier
            // 
            this.btnDownPost_modifier.Image = ((System.Drawing.Image)(resources.GetObject("btnDownPost_modifier.Image")));
            resources.ApplyResources(this.btnDownPost_modifier, "btnDownPost_modifier");
            this.btnDownPost_modifier.Name = "btnDownPost_modifier";
            this.btnDownPost_modifier.Click += new System.EventHandler(this.btnDownPost_modifier_Click);
            // 
            // btnUpPost_modifier
            // 
            this.btnUpPost_modifier.Image = ((System.Drawing.Image)(resources.GetObject("btnUpPost_modifier.Image")));
            resources.ApplyResources(this.btnUpPost_modifier, "btnUpPost_modifier");
            this.btnUpPost_modifier.Name = "btnUpPost_modifier";
            this.btnUpPost_modifier.Click += new System.EventHandler(this.btnUpPost_modifier_Click);
            // 
            // xFlatLabel3
            // 
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.Name = "xFlatLabel3";
            // 
            // btnDeletePost_modifier
            // 
            this.btnDeletePost_modifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePost_modifier.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePost_modifier.Image")));
            resources.ApplyResources(this.btnDeletePost_modifier, "btnDeletePost_modifier");
            this.btnDeletePost_modifier.Name = "btnDeletePost_modifier";
            this.btnDeletePost_modifier.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDeletePost_modifier.Click += new System.EventHandler(this.btnDeletePost_modifier_Click);
            // 
            // btnSearchPost_code
            // 
            this.btnSearchPost_code.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPost_code.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPost_code.Image")));
            resources.ApplyResources(this.btnSearchPost_code, "btnSearchPost_code");
            this.btnSearchPost_code.Name = "btnSearchPost_code";
            this.btnSearchPost_code.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSearchPost_code.Click += new System.EventHandler(this.btnSearchPost_code_Click);
            // 
            // txtPost_modifier_name
            // 
            resources.ApplyResources(this.txtPost_modifier_name, "txtPost_modifier_name");
            this.txtPost_modifier_name.Name = "txtPost_modifier_name";
            this.txtPost_modifier_name.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtPost_modifier_name_DataValidating);
            // 
            // grdPost_modifier
            // 
            this.grdPost_modifier.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdPost_modifier.ColPerLine = 1;
            this.grdPost_modifier.Cols = 2;
            this.grdPost_modifier.ExecuteQuery = null;
            this.grdPost_modifier.FixedCols = 1;
            this.grdPost_modifier.FixedRows = 1;
            this.grdPost_modifier.HeaderHeights.Add(0);
            resources.ApplyResources(this.grdPost_modifier, "grdPost_modifier");
            this.grdPost_modifier.Name = "grdPost_modifier";
            this.grdPost_modifier.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPost_modifier.ParamList")));
            this.grdPost_modifier.ReadOnly = true;
            this.grdPost_modifier.RowHeaderVisible = true;
            this.grdPost_modifier.Rows = 2;
            this.grdPost_modifier.RowStateCheckOnPaint = false;
            this.grdPost_modifier.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdPost_modifier_GiveFeedback);
            this.grdPost_modifier.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdPost_modifier_DragEnter);
            this.grdPost_modifier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPost_modifier_MouseDown);
            this.grdPost_modifier.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdPost_modifier_DragDrop);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "post_modifier";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellName = "post_modifier_name";
            this.xEditGridCell4.CellWidth = 112;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XDisplayBoxBorderColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.Name = "xLabel1";
            // 
            // grdScPost_modifier
            // 
            resources.ApplyResources(this.grdScPost_modifier, "grdScPost_modifier");
            this.grdScPost_modifier.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16});
            this.grdScPost_modifier.ColPerLine = 1;
            this.grdScPost_modifier.Cols = 1;
            this.grdScPost_modifier.ExecuteQuery = null;
            this.grdScPost_modifier.FixedRows = 1;
            this.grdScPost_modifier.HeaderHeights.Add(21);
            this.grdScPost_modifier.Name = "grdScPost_modifier";
            this.grdScPost_modifier.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdScPost_modifier.ParamList")));
            this.grdScPost_modifier.QuerySQL = resources.GetString("grdScPost_modifier.QuerySQL");
            this.grdScPost_modifier.Rows = 2;
            this.grdScPost_modifier.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdScPost_modifier_GiveFeedback);
            this.grdScPost_modifier.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdScPost_modifier_DragEnter);
            this.grdScPost_modifier.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdScPost_modifier_MouseDown);
            this.grdScPost_modifier.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdScPost_modifier_DragDrop);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "susik_code";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.CellName = "susik_name";
            this.xEditGridCell13.CellWidth = 175;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "susik_name_gana";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "susik_detail_gubun";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "seq";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // dloSangInfo
            // 
            this.dloSangInfo.ExecuteQuery = null;
            this.dloSangInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem23});
            this.dloSangInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSangInfo.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sang_name";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "pre_modifier1";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "pre_modifier2";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pre_modifier3";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "pre_modifier4";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "pre_modifier5";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "pre_modifier6";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "pre_modifier7";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "pre_modifier8";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "pre_modifier9";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "pre_modifier10";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "pre_modifier_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "post_modifier1";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "post_modifier2";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "post_modifier3";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "post_modifier4";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "post_modifier5";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "post_modifier6";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "post_modifier7";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "post_modifier8";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "post_modifier9";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "post_modifier10";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "post_modifier_name";
            // 
            // layLDCHT0115
            // 
            this.layLDCHT0115.ExecuteQuery = null;
            this.layLDCHT0115.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layLDCHT0115.ParamList")));
            // 
            // CHT0115Q00
            // 
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "CHT0115Q00";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.CHT0115Q00_Load);
            this.UserChanged += new System.EventHandler(this.CHT0115Q00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CHT0115Q00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPre_modifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdScPre_modifier)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPost_modifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdScPost_modifier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSangInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layLDCHT0115)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region 変数宣言

        private string mUSERID = "";
        private string mIOGUBUN = "";

        #endregion


        #region [Screen Event]

        private void CHT0115Q00_Load(object sender, System.EventArgs e)
		{		
			PostCallHelper.PostCall(new PostMethod(PostLoad));	
		}     
   
		private void CHT0115Q00_UserChanged(object sender, System.EventArgs e)
		{
			//this.dsvLDCHT0115.SetInValue("memb", UserInfo.UserID);

			//접두어 수식어 Display
			ShowSusikGubun();

			SetOpenParamValue();
			
			//접미어 조회
			LoadCHT0115("8", txtPost_modifier_name.GetDataValue().Trim());
		}
		
		private void PostLoad()
		{
			/// 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
			this.CHT0115Q00_UserChanged(this, new System.EventArgs()); 
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////	
		}  	

		private void CHT0115Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			dloSangInfo.Reset();
			dloSangInfo.InsertRow(-1);

			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("SANGINFO"))
					{
						foreach(DataRow row in ((MultiLayout)OpenParam["SANGINFO"]).LayoutTable.Rows)
						{
							foreach(MultiLayoutItem item in dloSangInfo.LayoutItems)
							{
                                if (((MultiLayout)OpenParam["SANGINFO"]).LayoutItems.Contains(item.DataName))
									dloSangInfo.SetItemValue(0, item.DataName, row[item.DataName]);
							}
						}
					}

                    if (OpenParam.Contains("io_gubun"))
                    {
                        mIOGUBUN = OpenParam["io_gubun"].ToString();
                    }

                    if (OpenParam.Contains("user_id"))
                    {
                        mUSERID = OpenParam["user_id"].ToString();
                    }

				}
				catch (Exception ex)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//XMessageBox.Show(ex.Message, "");	
					this.Close();
				}
			}

            PostCallHelper.PostFocus(this.txtPre_modifier_name);
		}

		private void SetOpenParamValue()
		{
			if( dloSangInfo.RowCount < 1 ) return;

			//접두어
			if( dloSangInfo.GetItemString(0, "pre_modifier1").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier1"));

			if( dloSangInfo.GetItemString(0, "pre_modifier2").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier2"));

			if( dloSangInfo.GetItemString(0, "pre_modifier3").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier3"));

			if( dloSangInfo.GetItemString(0, "pre_modifier4").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier4"));

			if( dloSangInfo.GetItemString(0, "pre_modifier5").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier5"));

			if( dloSangInfo.GetItemString(0, "pre_modifier6").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier5"));

			if( dloSangInfo.GetItemString(0, "pre_modifier7").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier5"));

			if( dloSangInfo.GetItemString(0, "pre_modifier8").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier5"));

			if( dloSangInfo.GetItemString(0, "pre_modifier9").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier5"));

			if( dloSangInfo.GetItemString(0, "pre_modifier10").Trim() != "")
				InsertSusik_code("0", dloSangInfo.GetItemString(0, "pre_modifier5"));
		    
			//접미어
			if( dloSangInfo.GetItemString(0, "post_modifier1").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier1"));

			if( dloSangInfo.GetItemString(0, "post_modifier2").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier2"));

			if( dloSangInfo.GetItemString(0, "post_modifier3").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier3"));

			if( dloSangInfo.GetItemString(0, "post_modifier4").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier4"));

			if( dloSangInfo.GetItemString(0, "post_modifier5").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier5"));

			if( dloSangInfo.GetItemString(0, "post_modifier6").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier5"));

			if( dloSangInfo.GetItemString(0, "post_modifier7").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier5"));

			if( dloSangInfo.GetItemString(0, "post_modifier8").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier5"));

			if( dloSangInfo.GetItemString(0, "post_modifier9").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier5"));

			if( dloSangInfo.GetItemString(0, "post_modifier10").Trim() != "")
				InsertSusik_code("8", dloSangInfo.GetItemString(0, "post_modifier5"));

			//상병명을 Display한다.
			ShowSang_name();
			
		}

		private void InsertSusik_code(string aSusik_gubun, string aSusik_code)
		{
			int insertRow;
            string cmdText = "";
            DataTable dtTemp;

		    CHT0115Q00SusikCodeArgs args = new CHT0115Q00SusikCodeArgs();
		    args.SusikCode = aSusik_code;
		    CHT0115Q00SusikCodeResult result =
		        CloudService.Instance.Submit<CHT0115Q00SusikCodeResult, CHT0115Q00SusikCodeArgs>(args);

			if(aSusik_gubun == "8")
			{
                /*cmdText = ""
					+ " SELECT A.SUSIK_NAME, A.SUSIK_NAME_GANA, A.SUSIK_DETAIL_GUBUN "   
					+ "   FROM CHT0115 A "
					+ "  WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                    + "    AND A.SUSIK_CODE = '" + aSusik_code + "' "
					+ "    AND ROWNUM = 1 ";

                dtTemp = Service.ExecuteDataTable(cmdText);*/

				//if(dtTemp != null && dtTemp.Rows.Count > 0)
                if (result.ExecutionStatus == ExecutionStatus.Success && result.SusikCodeInfo != null && result.SusikCodeInfo.Count > 0)
				{
					insertRow = grdPost_modifier.InsertRow(-1);
					grdPost_modifier.SetItemValue(insertRow, "post_modifier", aSusik_code);
                    //grdPost_modifier.SetItemValue(insertRow, "post_modifier_name", dtTemp.Rows[0]["susik_name"].ToString());
                    grdPost_modifier.SetItemValue(insertRow, "post_modifier_name", result.SusikCodeInfo[0].SusikName);
				}
			}
			else
			{
                /*cmdText = ""
					+ " SELECT A.SUSIK_NAME, A.SUSIK_NAME_GANA, A.SUSIK_DETAIL_GUBUN "   
					+ "   FROM CHT0115 A "
					+ "  WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                    + "    AND A.SUSIK_CODE = '" + aSusik_code + "' "
					+ "    AND ROWNUM = 1 ";

                dtTemp = Service.ExecuteDataTable(cmdText);*/

                //if (dtTemp != null && dtTemp.Rows.Count > 0)
                if (result.ExecutionStatus == ExecutionStatus.Success && result.SusikCodeInfo != null && result.SusikCodeInfo.Count > 0)
				{
					insertRow = grdPre_modifier.InsertRow(-1);
					grdPre_modifier.SetItemValue(insertRow, "pre_modifier", aSusik_code);
                    //grdPre_modifier.SetItemValue(insertRow, "pre_modifier_name", dtTemp.Rows[0]["susik_name"].ToString());
                    grdPre_modifier.SetItemValue(insertRow, "pre_modifier_name", result.SusikCodeInfo[0].SusikName);
				}
			}
		}

		#endregion
		
		#region [TreView]
        
		/// <summary>
		/// 수식구분을 TreeView로 보여준다.
		/// </summary>
		private void ShowSusikGubun()
		{
            IHIS.Framework.MultiLayout layoutCommon = new MultiLayout();

			layoutCommon.Reset();
			layoutCommon.LayoutItems.Clear();
			layoutCommon.LayoutItems.Add("code"     , DataType.String);
			layoutCommon.LayoutItems.Add("code_name", DataType.String);
			layoutCommon.InitializeLayoutTable();

            //layoutCommon.QuerySQL = " "
            //    + " SELECT CODE, CODE_NAME "
            //    + "   FROM BAS0102 "
            //    + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
            //    + "    AND CODE_TYPE = 'SUSIK_GUBUN' "
            //    + "    AND CODE      < '8'           ";

            /*layoutCommon.QuerySQL = @"  SELECT '%', FN_ADM_MSG(221)
                                          FROM SYS.DUAL
                                         UNION
                                        SELECT CODE, CODE_NAME 
                                          FROM BAS0102
                                         WHERE HOSP_CODE = '" + EnvironInfo.HospCode + @"'
                                           AND CODE_TYPE = 'SUSIK_GUBUN'
                                           AND CODE      < '8'";*/
		    layoutCommon.ExecuteQuery = LoadLayoutCommon;
            layoutCommon.QueryLayout(true);

			if(layoutCommon.RowCount > 0)
			{
				tvwPre_modifier.Nodes.Clear();
				if(layoutCommon.RowCount < 1) return;
            
				TreeNode node;

                this.tvwPre_modifier.AfterSelect -= new TreeViewEventHandler(tvwPre_modifier_AfterSelect);

				foreach(DataRow row in layoutCommon.LayoutTable.Rows)
				{
					node = new TreeNode( row["code_name"].ToString() );
					node.Tag = row["code"].ToString();
					tvwPre_modifier.Nodes.Add(node);		
				}

                this.tvwPre_modifier.AfterSelect += new TreeViewEventHandler(tvwPre_modifier_AfterSelect);

				tvwPre_modifier.SelectedNode = tvwPre_modifier.Nodes[0];
			}
		}

		#endregion

		#region [Function]
        
		/// <summary>
		/// 등록한 수식어를 기준으로 상병명을 보여준다.
		/// </summary>
		private void ShowSang_name()
		{
			string sang_name = "";
            
			//접두어생성
			foreach(DataRow preRow in grdPre_modifier.LayoutTable.Rows)
			{
				sang_name = sang_name + preRow["pre_modifier_name"].ToString().Trim();
			}
            
			//상병명
			sang_name = sang_name + dloSangInfo.GetItemString(0, "sang_name");
            
			//접미어생성
			foreach(DataRow postRow in grdPost_modifier.LayoutTable.Rows)
			{
				sang_name = sang_name + postRow["post_modifier_name"].ToString().Trim();
			}

			this.lblSang_name.Text = sang_name;

		}
        
		private void LoadCHT0115(string aSusik_gubun, string aSusink_name)
		{
            if (aSusik_gubun == "8")
            {
                this.grdScPost_modifier.SetBindVarValue("f_susik_detail_gubun", aSusik_gubun);
                this.grdScPost_modifier.SetBindVarValue("f_susik_name", aSusink_name);
                this.grdScPost_modifier.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdScPost_modifier.QueryLayout(true);
            }
            else
            {
                this.grdScPre_modifier.SetBindVarValue("f_susik_detail_gubun", aSusik_gubun);
                this.grdScPre_modifier.SetBindVarValue("f_susik_name", aSusink_name);
                this.grdScPre_modifier.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdScPre_modifier.QueryLayout(true);
            }
		}


		#endregion

		#region [Return Value 생성]

		private void ReturnValue()
		{
			if( dloSangInfo.RowCount == 0 )
				dloSangInfo.InsertRow(-1);
            
			string colName   = "";
			string sang_name = "";

			//reset
			for(int i = 1; i <= 10; i++)
			{
				colName = "pre_modifier" + i.ToString();
                
				if(dloSangInfo.LayoutItems.Contains(colName))
				{
					dloSangInfo.SetItemValue(0, colName, "");					
				}

				colName = "post_modifier" + i.ToString();
                
				if(dloSangInfo.LayoutItems.Contains(colName))
				{
					dloSangInfo.SetItemValue(0, colName, "");					
				}

			}

			//접두어 생성
			for(int preRow = 1; preRow <= grdPre_modifier.RowCount; preRow++)
			{
				colName = "pre_modifier" + preRow.ToString();
                
				if(dloSangInfo.LayoutItems.Contains(colName))
				{
					dloSangInfo.SetItemValue(0, colName, grdPre_modifier.GetItemString(preRow -1, "pre_modifier"));
                    sang_name = sang_name + grdPre_modifier.GetItemString(preRow -1, "pre_modifier_name");
				}
			}

			dloSangInfo.SetItemValue(0, "pre_modifier_name", sang_name);

			//접미어 생성
			colName   = "";
			sang_name = "";
			
			for(int preRow = 1; preRow <= grdPost_modifier.RowCount; preRow++)
			{
				colName = "post_modifier" + preRow.ToString();
                
				if(dloSangInfo.LayoutItems.Contains(colName))
				{
					dloSangInfo.SetItemValue(0, colName, grdPost_modifier.GetItemString(preRow -1, "post_modifier"));
					sang_name = sang_name + grdPost_modifier.GetItemString(preRow -1, "post_modifier_name");
				}
			}

			dloSangInfo.SetItemValue(0, "post_modifier_name", sang_name);

			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "CHT0115", dloSangInfo);
			scrOpener.Command(ScreenID, commandParams);

			this.Close();
		}

		#endregion

		#region [Control Event]

		private void txtPre_modifier_name_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string susik_gubun = this.tvwPre_modifier.SelectedNode.Tag.ToString();
			LoadCHT0115(susik_gubun, e.DataValue.Trim());
		}

		private void txtPost_modifier_name_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadCHT0115("8", e.DataValue.Trim());		
		}
	
		private void tvwPre_modifier_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			string susik_gubun = this.tvwPre_modifier.SelectedNode.Tag.ToString();
			LoadCHT0115(susik_gubun, txtPre_modifier_name.GetDataValue().Trim());		
		}

		#endregion

		#region [Button Event]
		private void btnSearchPre_code_Click(object sender, System.EventArgs e)
		{
			string susik_gubun = this.tvwPre_modifier.SelectedNode.Tag.ToString();
			LoadCHT0115(susik_gubun, txtPre_modifier_name.GetDataValue().Trim());
		}

		private void btnSearchPost_code_Click(object sender, System.EventArgs e)
		{
			LoadCHT0115("8", txtPost_modifier_name.GetDataValue().Trim());
		}

		private void btnDeletePre_modifier_Click(object sender, System.EventArgs e)
		{
			//if(this.grdPre_modifier.CurrentRowNumber < 0) return;

			grdPre_modifier.DeleteRow();
			ShowSang_name();
		}

		private void btnDeletePost_modifier_Click(object sender, System.EventArgs e)
		{
			//if(this.grdPost_modifier.CurrentRowNumber < 0) return;

			grdPost_modifier.DeleteRow();	
			ShowSang_name();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnProcess_Click(object sender, System.EventArgs e)
		{
			ReturnValue();		
		}

		#endregion

		#region [grdPre_modifier]

		private void grdPre_modifier_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{	
			int fromRowNum = -1;
			int toRowNum   = -1;
			if(e.Data.GetData("System.String").ToString().Split('|')[0] == "PRESANG")
			{
				// Client Point
				fromRowNum    = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
				Point clientPoint = grdPre_modifier.PointToClient(new Point(e.X, e.Y));

				toRowNum = grdPre_modifier.GetHitRowNumber(clientPoint.Y);

				if(toRowNum == fromRowNum || toRowNum < 0 ) 
					return;
			
				DataRow backRow = grdPre_modifier.LayoutTable.NewRow();			
				foreach(DataColumn col in grdPre_modifier.LayoutTable.Columns)
				{	
					backRow[col.ColumnName] = grdPre_modifier.GetItemString(toRowNum, col.ColumnName);
					grdPre_modifier.SetItemValue(toRowNum, col.ColumnName, grdPre_modifier.GetItemString(fromRowNum, col.ColumnName));
					grdPre_modifier.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
				}
				
				grdPre_modifier.UnSelectAll();
				grdPre_modifier.SelectRow(toRowNum);

				ShowSang_name();
			}
			else if(e.Data.GetData("System.String").ToString().Split('|')[0] == "SRPRESANG")
			{
				//10개까지 등록 가능하도록 한다.
				if(grdPre_modifier.RowCount == 10)
					return;

				// Client Point
				fromRowNum    = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
				Point clientPoint = grdPre_modifier.PointToClient(new Point(e.X, e.Y));

				toRowNum = grdPre_modifier.GetHitRowNumber(clientPoint.Y);
				toRowNum = grdPre_modifier.InsertRow(toRowNum);
				grdPre_modifier.SetItemValue(toRowNum, "pre_modifier", grdScPre_modifier.GetItemString(fromRowNum, "susik_code"));
				grdPre_modifier.SetItemValue(toRowNum, "pre_modifier_name", grdScPre_modifier.GetItemString(fromRowNum, "susik_name"));				
				grdPre_modifier.UnSelectAll();
				grdPre_modifier.SelectRow(toRowNum);

				ShowSang_name();
			}
		
		}

		private void grdPre_modifier_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시					
		}

		private void grdPre_modifier_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}			
		}

		private void grdPre_modifier_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(grdPre_modifier.GetHitRowNumber(e.Y) < 0) return;		
			int    curRowIndex = grdPre_modifier.GetHitRowNumber(e.Y);
			string dragInfo = "[" + grdPre_modifier.GetItemString(curRowIndex, "pre_modifier") + "]" + grdPre_modifier.GetItemString(curRowIndex, "pre_modifier_name");
			DragHelper.CreateDragCursor(grdPre_modifier, dragInfo, this.Font);
			grdPre_modifier.DoDragDrop("PRESANG|" + curRowIndex.ToString(), DragDropEffects.Move);		
		}

		#endregion        

		#region [grdPost_modifier Event]
		private void grdPost_modifier_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{			

			int fromRowNum = -1;
			int toRowNum   = -1;
			if(e.Data.GetData("System.String").ToString().Split('|')[0] == "POSTSANG")
			{
				// Client Point
				fromRowNum    = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
				Point clientPoint = grdPost_modifier.PointToClient(new Point(e.X, e.Y));

				toRowNum = grdPost_modifier.GetHitRowNumber(clientPoint.Y);

				if(toRowNum == fromRowNum || toRowNum < 0 ) 
					return;
			
				DataRow backRow = grdPost_modifier.LayoutTable.NewRow();			
				foreach(DataColumn col in grdPost_modifier.LayoutTable.Columns)
				{	
					backRow[col.ColumnName] = grdPost_modifier.GetItemString(toRowNum, col.ColumnName);
					grdPost_modifier.SetItemValue(toRowNum, col.ColumnName, grdPost_modifier.GetItemString(fromRowNum, col.ColumnName));
					grdPost_modifier.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
				}

				grdPost_modifier.UnSelectAll();
				grdPost_modifier.SelectRow(toRowNum);

				ShowSang_name();
			}
			else if(e.Data.GetData("System.String").ToString().Split('|')[0] == "SRPOSTSANG")
			{
				//10개까지 등록 가능하도록 한다.
				if(grdPre_modifier.RowCount == 10)
					return;

				// Client Point
				fromRowNum    = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
				Point clientPoint = grdPost_modifier.PointToClient(new Point(e.X, e.Y));

				toRowNum = grdPost_modifier.GetHitRowNumber(clientPoint.Y);
				toRowNum = grdPost_modifier.InsertRow(toRowNum);
				grdPost_modifier.SetItemValue(toRowNum, "post_modifier", grdScPost_modifier.GetItemString(fromRowNum, "susik_code"));
				grdPost_modifier.SetItemValue(toRowNum, "post_modifier_name", grdScPost_modifier.GetItemString(fromRowNum, "susik_name"));
				grdPost_modifier.SetFocusToItem(toRowNum, grdPost_modifier.CurrentColNumber);	
				
				grdPost_modifier.UnSelectAll();
				grdPost_modifier.SelectRow(toRowNum);

				ShowSang_name();
			}
		
		}

		private void grdPost_modifier_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시							
		}

		private void grdPost_modifier_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}			
		}

		private void grdPost_modifier_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(grdPost_modifier.GetHitRowNumber(e.Y) < 0) return;		
			int    curRowIndex = grdPost_modifier.GetHitRowNumber(e.Y);
			string dragInfo = "[" + grdPost_modifier.GetItemString(curRowIndex, "post_modifier") + "]" + grdPost_modifier.GetItemString(curRowIndex, "post_modifier_name");
			DragHelper.CreateDragCursor(grdPost_modifier, dragInfo, this.Font);
			grdPost_modifier.DoDragDrop("POSTSANG|" + curRowIndex.ToString(), DragDropEffects.Move);
		
		}

		#endregion

		#region [grdScPre_modifier Event]

		private void grdScPre_modifier_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시		
		}

		private void grdScPre_modifier_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}			
		}

		private void grdScPre_modifier_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;
			int insertRow   ;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdScPre_modifier.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				if(this.grdPre_modifier.RowCount == 10)
					return;
				else
				{
					insertRow = grdPre_modifier.InsertRow();
					grdPre_modifier.SetItemValue(insertRow, "pre_modifier", grdScPre_modifier.GetItemString(curRowIndex, "susik_code"));
					grdPre_modifier.SetItemValue(insertRow, "pre_modifier_name", grdScPre_modifier.GetItemString(curRowIndex, "susik_name"));

				}

				ShowSang_name();
			}
			else if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				curRowIndex = grdScPre_modifier.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				string dragInfo = "[" + grdScPre_modifier.GetItemString(curRowIndex, "susik_code") + "]" + grdScPre_modifier.GetItemString(curRowIndex, "susik_name");
				DragHelper.CreateDragCursor(grdScPre_modifier, dragInfo, this.Font);
				grdPre_modifier.DoDragDrop("SRPRESANG|" + curRowIndex.ToString(), DragDropEffects.Move);	
			}
		
		}

		private void grdScPre_modifier_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetData("System.String").ToString().Split('|')[0] != "SRPRESANG") return;

			// Client Point			
			int   fromRowNum  = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
			Point clientPoint = grdScPre_modifier.PointToClient(new Point(e.X, e.Y));

			int toRowNum = grdScPre_modifier.GetHitRowNumber(clientPoint.Y);

			if(toRowNum == fromRowNum || toRowNum < 0 ) return;

			AlterGridRowPosition(grdScPre_modifier, fromRowNum, toRowNum);
		}

		#endregion

		#region [grdScPost_modifier Event]

		private void grdScPost_modifier_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;  // Move 표시		
		}

		private void grdScPost_modifier_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;
			// Drag시에 Cursor 바꿈
			if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
			{
				Cursor.Current = DragHelper.DragCursor;
			}			
		}

		private void grdScPost_modifier_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex = -1;
			int insertRow   ;

			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				curRowIndex = grdScPost_modifier.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				if(this.grdPost_modifier.RowCount == 10)
					return;
				else
				{
					insertRow = grdPost_modifier.InsertRow();
					grdPost_modifier.SetItemValue(insertRow, "post_modifier", grdScPost_modifier.GetItemString(curRowIndex, "susik_code"));
					grdPost_modifier.SetItemValue(insertRow, "post_modifier_name", grdScPost_modifier.GetItemString(curRowIndex, "susik_name"));

				}

				ShowSang_name();
			}
			else if(e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				curRowIndex = grdScPost_modifier.GetHitRowNumber(e.Y);
				if(curRowIndex < 0) return;

				string dragInfo = "[" + grdScPost_modifier.GetItemString(curRowIndex, "susik_code") + "]" + grdScPost_modifier.GetItemString(curRowIndex, "susik_name");
				DragHelper.CreateDragCursor(grdScPost_modifier, dragInfo, this.Font);
				grdPost_modifier.DoDragDrop("SRPOSTSANG|" + curRowIndex.ToString(), DragDropEffects.Move);	
			}
		
		}

		private void grdScPost_modifier_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetData("System.String").ToString().Split('|')[0] != "SRPOSTSANG") return;

			// Client Point			
			int   fromRowNum  = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);
			Point clientPoint = grdScPost_modifier.PointToClient(new Point(e.X, e.Y));

			int toRowNum = grdScPost_modifier.GetHitRowNumber(clientPoint.Y);

			if(toRowNum == fromRowNum || toRowNum < 0 ) return;

			AlterGridRowPosition(grdScPost_modifier, fromRowNum, toRowNum);
		}

		#endregion

		#region [수식어순서 변경]

		/// <summary>
		/// 선택한 Row (from row)를 to row위치로 가져간다.
		/// </summary>
		/// <param name="grd">해당 Grid</param>
		/// <param name="fromRowNum">대상 row위치  </param>
		/// <param name="toRowNum"  >변경할 row위치</param>
		private void AlterGridRowPosition(XEditGrid grd, int fromRowNum, int toRowNum)
		{
			if( fromRowNum < 0 || toRowNum < 0 ||
				fromRowNum >= grd.RowCount || toRowNum >= grd.RowCount ) return;
			
			int currentColNum = grd.CurrentColNumber;
			if(currentColNum == -1) currentColNum = 0;

			MultiLayout copyLay = grd.CopyToLayout();
			grd.LayoutTable.Rows.Clear();

			for(int i = 0; i < copyLay.RowCount; i++ )
			{
				if( i == fromRowNum )
					continue;

				//변경위치로 Row를 가져간다.
				if( i == toRowNum )
				{
					if( fromRowNum < toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
					
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[fromRowNum]);

					if( fromRowNum > toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
				}
				else
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
			}

			grd.DisplayData();
			grd.SetFocusToItem(toRowNum, currentColNum);	
			grd.SelectRow(toRowNum);

            //if(!dsvSave.Call())
            //{				
            //    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다."; 
            //    mbxMsg = mbxMsg + dsvSave.ErrMsg;
            //    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
            //    XMessageBox.Show(mbxMsg, mbxCap);
            //}
			
		}
		#endregion
        
		#region [수식어 순서변경]
		
		private void btnUpPre_modifier_Click(object sender, System.EventArgs e)
		{
			if( grdScPre_modifier.CurrentRowNumber < 0 ) return;

			AlterGridRowPosition(grdScPre_modifier, grdScPre_modifier.CurrentRowNumber, grdScPre_modifier.CurrentRowNumber - 1);		
		}

		private void btnDownPre_modifier_Click(object sender, System.EventArgs e)
		{
			if( grdScPre_modifier.CurrentRowNumber < 0 ) return;

			AlterGridRowPosition(grdScPre_modifier, grdScPre_modifier.CurrentRowNumber, grdScPre_modifier.CurrentRowNumber + 1);	
		
		}

		private void btnUpPost_modifier_Click(object sender, System.EventArgs e)
		{
			if( grdScPost_modifier.CurrentRowNumber < 0 ) return;

			AlterGridRowPosition(grdScPost_modifier, grdScPost_modifier.CurrentRowNumber, grdScPost_modifier.CurrentRowNumber - 1);	
		
		}

		private void btnDownPost_modifier_Click(object sender, System.EventArgs e)
		{
			if( grdScPost_modifier.CurrentRowNumber < 0 ) return;

			AlterGridRowPosition(grdScPost_modifier, grdScPost_modifier.CurrentRowNumber, grdScPost_modifier.CurrentRowNumber + 1);	
		
		}

		#endregion

        private void grdScPre_modifier_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdScPre_modifier.SetBindVarValue("f_user_id",  TypeCheck.NVL(mUSERID, "99999").ToString());
            this.grdScPre_modifier.SetBindVarValue("f_io_gubun", TypeCheck.NVL(mIOGUBUN, "O").ToString());
        }

        #region cloud service
        private List<string> CreateGrdScPostParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_susik_detail_gubun");
            paramList.Add("f_susik_name");
            return paramList;
        }

        private List<object[]> LoadGrdScPost(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0115Q00GrdScPostArgs args = new CHT0115Q00GrdScPostArgs();
            args.SusikDetailGubun = bc["f_susik_detail_gubun"] != null ? bc["f_susik_detail_gubun"].VarValue : "";
            args.SusikName = bc["f_susik_name"] != null ? bc["f_susik_name"].VarValue : "";
            CHT0115Q00GrdScPostResult result = CloudService.Instance.Submit<CHT0115Q00GrdScPostResult, CHT0115Q00GrdScPostArgs>(args);
            if (result != null)
            {
                foreach (CHT0115Q00GrdScInfo item in result.GrdscPostInfo)
                {
                    object[] objects = 
				{ 
					item.SusikCode, 
					item.SusikName, 
					item.SusikNameGana, 
					item.SusikDetailGubun
				};
                    res.Add(objects);
                }
            }
            return res; 
        }
        private List<string> CreateGrdScPreParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_susik_detail_gubun");
            paramList.Add("f_susik_name");
            paramList.Add("f_io_gubun");
            paramList.Add("f_user_id");
            return paramList;
        }

        private List<object[]> LoadGrdScPre(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0115Q00GrdScPreArgs args = new CHT0115Q00GrdScPreArgs();
            args.SusikDetailGubun = bc["f_susik_detail_gubun"] != null ? bc["f_susik_detail_gubun"].VarValue : "";
            args.SusikName = bc["f_susik_name"] != null ? bc["f_susik_name"].VarValue : "";
            args.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            args.UserId = bc["f_user_id"] != null ? bc["f_user_id"].VarValue : "";
            CHT0115Q00GrdScPreResult result = CloudService.Instance.Submit<CHT0115Q00GrdScPreResult, CHT0115Q00GrdScPreArgs>(args);
            if (result != null)
            {
                foreach (CHT0115Q00GrdScInfo item in result.GrdscPreInfo)
                {
                    object[] objects = 
				{ 
					item.SusikCode, 
					item.SusikName, 
					item.SusikNameGana, 
					item.SusikDetailGubun
				};
                    res.Add(objects);
                }
            }
            return res; 
        }

        private List<object[]> LoadLayoutCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0115Q00LayoutCommonArgs args = new CHT0115Q00LayoutCommonArgs();
            CHT0115Q00LayoutCommonResult result = CloudService.Instance.Submit<CHT0115Q00LayoutCommonResult, CHT0115Q00LayoutCommonArgs>(args);
            if (result != null)
            {
                foreach (ComboListItemInfo item in result.LayoutCommonInfo)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        } 
        #endregion
    }
}

