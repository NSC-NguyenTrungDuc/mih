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
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.Framework;
using IHIS.CHTS.Properties;
#endregion

namespace IHIS.CHTS
{
	/// <summary>
	/// CHT0110Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CHT0110Q01 : IHIS.Framework.XScreen
	{
		//Message처리
		string mbxMsg = "", mbxCap = "";
        
		//Multi선택여부
		bool mMultiSelect = true;

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XTextBox txtSearchWord;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGrid xEditGrid1;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditGridCell xEditGridCell39;
		private IHIS.Framework.XEditGridCell xEditGridCell40;
		private IHIS.Framework.XEditGridCell xEditGridCell41;
		private IHIS.Framework.XEditGridCell xEditGridCell42;
		private IHIS.Framework.XEditGridCell xEditGridCell43;
		private IHIS.Framework.XEditGridCell xEditGridCell44;
		private IHIS.Framework.XEditGridCell xEditGridCell45;
		private IHIS.Framework.XEditGridCell xEditGridCell46;
		private IHIS.Framework.XEditGridCell xEditGridCell47;
		private IHIS.Framework.XEditGridCell xEditGridCell48;
		private IHIS.Framework.XEditGridCell xEditGridCell49;
		private IHIS.Framework.XEditGridCell xEditGridCell50;
		private IHIS.Framework.XEditGridCell xEditGridCell51;
		private IHIS.Framework.XEditGridCell xEditGridCell52;
		private IHIS.Framework.XEditGridCell xEditGridCell53;
		private IHIS.Framework.XEditGridCell xEditGridCell54;
		private IHIS.Framework.XEditGridCell xEditGridCell55;
		private IHIS.Framework.XEditGridCell xEditGridCell56;
		private IHIS.Framework.XEditGridCell xEditGridCell57;
		private IHIS.Framework.XEditGridCell xEditGridCell58;
		private IHIS.Framework.XEditGridCell xEditGridCell59;
		private IHIS.Framework.XEditGridCell xEditGridCell60;
		private IHIS.Framework.XEditGridCell xEditGridCell61;
		private IHIS.Framework.XEditGridCell xEditGridCell62;
		private IHIS.Framework.XGridHeader xGridHeader5;
		private IHIS.Framework.XGridHeader xGridHeader6;
		private IHIS.Framework.XGridHeader xGridHeader7;
		private IHIS.Framework.XGridHeader xGridHeader8;
		private IHIS.Framework.XEditGridCell xEditGridCell63;
		private IHIS.Framework.MultiLayout layCHT0110M;
		private IHIS.Framework.XEditGrid grdCHT0110M;
		private IHIS.Framework.XEditGridCell xEditGridCell64;
		private IHIS.Framework.XButton btnProcess;
        private IHIS.Framework.MultiLayout dloReturnValue;
		private IHIS.Framework.XEditGridCell xEditGridCell65;
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
        private XEditGridCell xEditGridCell2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CHT0110Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            grdCHT0110M.ParamList = CreateGrdCHT0110MParamList();
            grdCHT0110M.ExecuteQuery = LoadGrdCHT0110M;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CHT0110Q01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtSearchWord = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.grdCHT0110M = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGrid1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.xGridHeader6 = new IHIS.Framework.XGridHeader();
            this.xGridHeader7 = new IHIS.Framework.XGridHeader();
            this.xGridHeader8 = new IHIS.Framework.XGridHeader();
            this.layCHT0110M = new IHIS.Framework.MultiLayout();
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
            this.btnProcess = new IHIS.Framework.XButton();
            this.dloReturnValue = new IHIS.Framework.MultiLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0110M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCHT0110M)).BeginInit();
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
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.txtSearchWord);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.AccessibleDescription = null;
            this.txtSearchWord.AccessibleName = null;
            resources.ApplyResources(this.txtSearchWord, "txtSearchWord");
            this.txtSearchWord.BackgroundImage = null;
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchWord_DataValidating);
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
            this.xLabel2.Name = "xLabel2";
            // 
            // grdCHT0110M
            // 
            this.grdCHT0110M.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdCHT0110M, "grdCHT0110M");
            this.grdCHT0110M.ApplyPaintEventToAllColumn = true;
            this.grdCHT0110M.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell65,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell24,
            this.xEditGridCell63,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell28,
            this.xEditGridCell32,
            this.xEditGridCell2,
            this.xEditGridCell64});
            this.grdCHT0110M.ColPerLine = 12;
            this.grdCHT0110M.Cols = 12;
            this.grdCHT0110M.ExecuteQuery = null;
            this.grdCHT0110M.FixedRows = 2;
            this.grdCHT0110M.HeaderHeights.Add(25);
            this.grdCHT0110M.HeaderHeights.Add(1);
            this.grdCHT0110M.Name = "grdCHT0110M";
            this.grdCHT0110M.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdCHT0110M.ParamList")));
            this.grdCHT0110M.QuerySQL = resources.GetString("grdCHT0110M.QuerySQL");
            this.grdCHT0110M.Rows = 3;
            this.grdCHT0110M.RowStateCheckOnPaint = false;
            this.grdCHT0110M.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdCHT0110M.ToolTipActive = true;
            this.grdCHT0110M.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdCHT0110M_QueryEnd);
            this.grdCHT0110M.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdCHT0110M_MouseDown);
            this.grdCHT0110M.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdCHT0110M_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "sang_code";
            this.xEditGridCell1.CellWidth = 85;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell65.CellLen = 1000;
            this.xEditGridCell65.CellName = "sang_name";
            this.xEditGridCell65.CellWidth = 291;
            this.xEditGridCell65.Col = 2;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.RowSpan = 2;
            this.xEditGridCell65.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell65.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellLen = 1000;
            this.xEditGridCell3.CellName = "sang_name_han";
            this.xEditGridCell3.CellWidth = 248;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 1000;
            this.xEditGridCell4.CellName = "sang_name_self";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 1000;
            this.xEditGridCell6.CellName = "sang_name_inx";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "jukyong_date";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell20.CellWidth = 82;
            this.xEditGridCell20.Col = 4;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellName = "bulyong_yn";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "suga_sang_code";
            this.xEditGridCell24.Col = 5;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell63.CellName = "suga_sang_name";
            this.xEditGridCell63.CellWidth = 248;
            this.xEditGridCell63.Col = 6;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell63.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "junyeom_bunryu";
            this.xEditGridCell25.CellWidth = 152;
            this.xEditGridCell25.Col = 7;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "junyeon_kind";
            this.xEditGridCell26.CellWidth = 125;
            this.xEditGridCell26.Col = 8;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "samang_sang_group";
            this.xEditGridCell28.CellWidth = 102;
            this.xEditGridCell28.Col = 9;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "samang_sang_group_name";
            this.xEditGridCell32.CellWidth = 191;
            this.xEditGridCell32.Col = 10;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "rank";
            this.xEditGridCell2.CellWidth = 52;
            this.xEditGridCell2.Col = 11;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell64.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell64.CellName = "select";
            this.xEditGridCell64.CellWidth = 63;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsUpdCol = false;
            this.xEditGridCell64.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell64.RowSpan = 2;
            this.xEditGridCell64.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell64.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "suga_sang_code";
            this.xEditGridCell22.Col = 21;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "suga_sang_code";
            this.xEditGridCell23.Col = 22;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsUpdatable = false;
            // 
            // xEditGrid1
            // 
            this.xEditGrid1.AddedHeaderLine = 1;
            resources.ApplyResources(this.xEditGrid1, "xEditGrid1");
            this.xEditGrid1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62});
            this.xEditGrid1.ColPerLine = 27;
            this.xEditGrid1.Cols = 27;
            this.xEditGrid1.ExecuteQuery = null;
            this.xEditGrid1.FixedRows = 2;
            this.xEditGrid1.HeaderHeights.Add(31);
            this.xEditGrid1.HeaderHeights.Add(21);
            this.xEditGrid1.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader5,
            this.xGridHeader6,
            this.xGridHeader7,
            this.xGridHeader8});
            this.xEditGrid1.Name = "xEditGrid1";
            this.xEditGrid1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("xEditGrid1.ParamList")));
            this.xEditGrid1.Rows = 4;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "sang_code";
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdatable = false;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "sang_name";
            this.xEditGridCell34.CellWidth = 179;
            this.xEditGridCell34.Col = 1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdatable = false;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "sang_name_han";
            this.xEditGridCell35.CellWidth = 193;
            this.xEditGridCell35.Col = 2;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdatable = false;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "sang_name_self";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "sang_name_old";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "sang_name_inx";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "sang_gr_code";
            this.xEditGridCell39.CellWidth = 70;
            this.xEditGridCell39.Col = 3;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.Row = 1;
            this.xEditGridCell39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "sang_md_code";
            this.xEditGridCell40.CellWidth = 70;
            this.xEditGridCell40.Col = 5;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.Row = 1;
            this.xEditGridCell40.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "sang_so_code";
            this.xEditGridCell41.CellWidth = 69;
            this.xEditGridCell41.Col = 7;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.Row = 1;
            this.xEditGridCell41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "sang_dt_code";
            this.xEditGridCell42.CellWidth = 72;
            this.xEditGridCell42.Col = 9;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.Row = 1;
            this.xEditGridCell42.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "ju_sang";
            this.xEditGridCell43.CellWidth = 46;
            this.xEditGridCell43.Col = 11;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "drg_yn";
            this.xEditGridCell44.CellWidth = 34;
            this.xEditGridCell44.Col = 12;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsUpdatable = false;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jung_gubun";
            this.xEditGridCell45.CellWidth = 45;
            this.xEditGridCell45.Col = 13;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdatable = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "icd9_code";
            this.xEditGridCell46.CellWidth = 62;
            this.xEditGridCell46.Col = 14;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdatable = false;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "sang_sex";
            this.xEditGridCell47.CellWidth = 57;
            this.xEditGridCell47.Col = 15;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdatable = false;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "jinryo_yn";
            this.xEditGridCell48.CellWidth = 38;
            this.xEditGridCell48.Col = 16;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdatable = false;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "junyeum_yn";
            this.xEditGridCell49.CellWidth = 48;
            this.xEditGridCell49.Col = 17;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "np_wonnae_sayu_code";
            this.xEditGridCell50.CellWidth = 64;
            this.xEditGridCell50.Col = 18;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdatable = false;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "jukyong_date";
            this.xEditGridCell51.CellWidth = 82;
            this.xEditGridCell51.Col = 19;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "bulyong_yn";
            this.xEditGridCell52.Col = 20;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "suga_sang_code";
            this.xEditGridCell53.Col = 21;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "junyeom_bunryu";
            this.xEditGridCell54.CellWidth = 96;
            this.xEditGridCell54.Col = 22;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsUpdatable = false;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "junyeon_kind";
            this.xEditGridCell55.CellWidth = 118;
            this.xEditGridCell55.Col = 23;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsUpdatable = false;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "ori_cancer_yn";
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.Row = 1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "samang_sang_group";
            this.xEditGridCell57.Col = 1;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.Row = 1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "sang_gr_nm";
            this.xEditGridCell58.Col = 4;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.Row = 1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "sang_md_nm";
            this.xEditGridCell59.Col = 6;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.Row = 1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "sang_so_nm";
            this.xEditGridCell60.Col = 8;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.Row = 1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "sang_dt_nm";
            this.xEditGridCell61.Col = 10;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.Row = 1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "samang_sang_group_name";
            this.xEditGridCell62.Col = 2;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.Row = 1;
            // 
            // xGridHeader5
            // 
            this.xGridHeader5.Col = 3;
            this.xGridHeader5.ColSpan = 2;
            this.xGridHeader5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader5, "xGridHeader5");
            this.xGridHeader5.HeaderWidth = 70;
            // 
            // xGridHeader6
            // 
            this.xGridHeader6.Col = 5;
            this.xGridHeader6.ColSpan = 2;
            this.xGridHeader6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader6, "xGridHeader6");
            this.xGridHeader6.HeaderWidth = 70;
            // 
            // xGridHeader7
            // 
            this.xGridHeader7.Col = 7;
            this.xGridHeader7.ColSpan = 2;
            this.xGridHeader7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader7, "xGridHeader7");
            this.xGridHeader7.HeaderWidth = 69;
            // 
            // xGridHeader8
            // 
            this.xGridHeader8.Col = 9;
            this.xGridHeader8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader8, "xGridHeader8");
            this.xGridHeader8.HeaderWidth = 72;
            // 
            // layCHT0110M
            // 
            this.layCHT0110M.ExecuteQuery = null;
            this.layCHT0110M.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem13});
            this.layCHT0110M.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCHT0110M.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "sang_code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "sang_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "sang_name_han";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "sang_name_self";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "sang_name_inx";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "jukyong_date";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "bulyong_yn";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "suga_sang_code";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "suga_sang_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "junyeom_bunryu";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "junyeon_kind";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "samang_sang_group";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "samang_sang_group_name";
            // 
            // btnProcess
            // 
            this.btnProcess.AccessibleDescription = null;
            this.btnProcess.AccessibleName = null;
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.BackgroundImage = null;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // dloReturnValue
            // 
            this.dloReturnValue.ExecuteQuery = null;
            this.dloReturnValue.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloReturnValue.ParamList")));
            // 
            // CHT0110Q01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdCHT0110M);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xEditGrid1);
            this.Name = "CHT0110Q01";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CHT0110Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCHT0110M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layCHT0110M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloReturnValue)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			CreateLayout();		
			
		}

        string date = "";
        private string mIOGUBUN = "";
        private string mUSERID = "";

		private void CHT0110Q01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			if (this.OpenParam != null)
			{				
				if( OpenParam.Contains("sang_inx")) this.txtSearchWord.SetDataValue(this.OpenParam["sang_inx"].ToString());

				if( OpenParam.Contains("multiSelect")) 
				{
					mMultiSelect = bool.Parse(OpenParam["multiSelect"].ToString());
				}

                if (OpenParam.Contains("date"))
                {
                    date = OpenParam["date"].ToString();
                }

                if (OpenParam.Contains("io_gubun"))
                {
                    mIOGUBUN = OpenParam["io_gubun"].ToString();
                }

                if (OpenParam.Contains("user_id"))
                {
                    mUSERID = OpenParam["user_id"].ToString();
                }

				if(!mMultiSelect)
				{
					grdCHT0110M.AutoSizeColumn(0, 0);
				}
				
				LoadCHT0110();
			}
		}

		private void CreateLayout()
		{
			// LayoutItems 생성
			foreach(XGridCell cell in this.grdCHT0110M.CellInfos)
			{
				dloReturnValue.LayoutItems.Add(cell.CellName, (DataType)cell.CellType);
			}

			dloReturnValue.InitializeLayoutTable();				
		}

		#endregion

		#region [Control Event]

		private void grdCHT0110M_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int curRowIndex ;

			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				CreateReturnValue(false);
			}
			else if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdCHT0110M.CurrentColNumber <= 1)
			{
				curRowIndex = grdCHT0110M.GetHitRowNumber(e.Y);				
				if(!mMultiSelect || curRowIndex < 0) return;

				if(grdCHT0110M.CurrentColNumber <= 1)
				{	
					if (this.grdCHT0110M.GetItemString(curRowIndex, "bulyong_yn") == "Y") return;

					if(grdCHT0110M.GetItemString(curRowIndex, "select") == "")
					{
						grdCHT0110M.SetItemValue(curRowIndex, "select", " ");
						SelectionBackColorChange(sender, curRowIndex, "Y");
					}
					else
					{
						grdCHT0110M.SetItemValue(curRowIndex, "select", "");
						SelectionBackColorChange(sender, curRowIndex, "N");
					}
				}

			}			
		}

		private void grdCHT0110M_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (this.grdCHT0110M.GetItemString(e.RowNumber, "bulyong_yn") == "Y")
			{
				e.ForeColor = XColor.ErrMsgForeColor.Color;
			}
			// 상병종료일이 입력되지 않은 경우는 종료사유 입력 불가
			switch (e.ColName)
			{
				case "display_sang_name": case "sang_name": case "sang_name_han": // Display 상병명
					// 암 관련 상병명 암 표현법 (癌표시를 CA로 표시함) 
					try
					{
						grdCHT0110M[e.RowNumber, e.ColName].DisplayText = this.DisplayCancerSangName("", grdCHT0110M[e.RowNumber, e.ColName].DisplayText);
					}
					catch{}

					break;
			}
            

		}
		#region 암 관련 상병명 암 표현법 (癌표시를 CA로 표시함) (DisplayCancerSangName)
		/// <summary>
		/// 암 관련 상병명 암 표현법 (癌표시를 CA로 표시함)
		/// </summary>
		/// <param name="aInput_Part"> string 입력부서 </param>
		/// <returns> string </returns>
		private string DisplayCancerSangName(string aInput_Part, string aSangName)
		{
			string sangName = aSangName;

			sangName = sangName.Replace(NetInfo.Language == LangMode.Jr ? "癌" : "암", "CA");

			return sangName;
		}
		#endregion
		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			CreateReturnValue(mMultiSelect);
		}

		private void txtSearchWord_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			LoadCHT0110();
		}

		#endregion	

		#region [Function]

		/// <summary>
		/// 상병정보를 조회합니다.
		/// </summary>
		private void LoadCHT0110()
		{				
			try
			{
				Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                //string search_inx = JapanTextHelper.GetFullKatakana(txtSearchWord.GetDataValue().Trim(), false);
                grdCHT0110M.SetBindVarValue("f_sang_inx", txtSearchWord.GetDataValue().Trim());
                grdCHT0110M.SetBindVarValue("f_hosp_code",  EnvironInfo.HospCode);
                //INSERT BY JC
                grdCHT0110M.SetBindVarValue("f_date", date);
                grdCHT0110M.SetBindVarValue("f_io_gubun", TypeCheck.NVL(mIOGUBUN, "O").ToString());
                grdCHT0110M.SetBindVarValue("f_user_id", TypeCheck.NVL(mUSERID, "99999").ToString());
			    
                if (!this.grdCHT0110M.QueryLayout(false))
				{
                    XMessageBox.Show(Service.ErrFullMsg);
				}
				
			}
			finally
			{
				Cursor.Current = System.Windows.Forms.Cursors.Default;
			}
		}

		/// <summary>
		/// 선택한정보를 dloReturnValue로 생성합니다.		
		/// </summary>
		private void CreateReturnValue(bool multiSelect)
		{  
			dloReturnValue.LayoutTable.Rows.Clear();

            //if (dloReturnValue.RowCount < 1)
            //{
            //    this.grdCHT0110M.SetItemValue(this.grdCHT0110M.CurrentRowNumber, "select", " ");
            //    SelectionBackColorChange(this.grdCHT0110M, this.grdCHT0110M.CurrentRowNumber, "Y");

            //    //mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病が選択されていません。ご確認下さい。" : "상병이 선택되지 않았습니다. 확인하세요.";
            //    //mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : "확인";
            //    //XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
            //    //return;
            //}

			try
			{
				//선택한 정보 import
				if( mMultiSelect )
				{
					foreach(DataRow row in grdCHT0110M.LayoutTable.Rows)
					{
						if(row["select"].ToString() == " ")
							dloReturnValue.LayoutTable.ImportRow(row);				
					}
				}
                
				//선택한 상병이 없는 경우에는 현재 row상병을 가져간다.
				if( !multiSelect && dloReturnValue.RowCount == 0 && grdCHT0110M.CurrentRowNumber >= 0)
				{
					dloReturnValue.LayoutTable.ImportRow(grdCHT0110M.LayoutTable.Rows[grdCHT0110M.CurrentRowNumber]);				
				}
			}
			catch
			{				
				
			}
            if (dloReturnValue.RowCount < 1)
            {
                //this.grdCHT0110M.SetItemValue(this.grdCHT0110M.CurrentRowNumber, "select", " ");
                //SelectionBackColorChange(this.grdCHT0110M, this.grdCHT0110M.CurrentRowNumber, "Y");

                mbxMsg = Resources.MSG001;
                mbxCap = Resources.MSG001_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                return;
            }
			

			IHIS.Framework.XScreen scrOpener = (XScreen)Opener;	

			CommonItemCollection commandParams  = new CommonItemCollection();
			commandParams.Add( "CHT0110", dloReturnValue);
			scrOpener.Command(ScreenID, commandParams);
            
			this.Close();
		}
		#endregion

		#region [DataService Event]

		private void grdCHT0110M_ServiceEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			SelectionBackColorChange(grdCHT0110M);
		}

		#endregion

		#region [Button List Event]

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					LoadCHT0110();
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
			for(int rowIndex = 0; rowIndex < grdObject.DisplayRowCount; rowIndex++)
			{	
				if(grdObject.GetItemString(rowIndex, "bulyong_yn").ToString() == "Y") continue;

				if(grdObject.GetItemString(rowIndex, "select").ToString() == " ")
				{				
					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[1];					

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
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 0].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}
		}
		#endregion

        private void grdCHT0110M_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //insert by jc [checkboxImageInitialize] 2012/11/04
            SelectionBackColorChange(this.grdCHT0110M);

        }

        #region cloud service
        private List<string> CreateGrdCHT0110MParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_sang_inx");
            paramList.Add("f_date");
            paramList.Add("f_io_gubun");
            paramList.Add("f_user_id");
            return paramList;
        }

        private List<object[]> LoadGrdCHT0110M(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CHT0110Q01GrdCHT0110MListArgs args = new CHT0110Q01GrdCHT0110MListArgs();
            args.SangInx = bc["f_sang_inx"] != null ? bc["f_sang_inx"].VarValue : "";
            args.Date = bc["f_date"] != null ? bc["f_date"].VarValue : "";
            args.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            args.UserId = bc["f_user_id"] != null ? bc["f_user_id"].VarValue : "";
            CHT0110Q01GrdCHT0110MListResult result = CloudService.Instance.Submit<CHT0110Q01GrdCHT0110MListResult, CHT0110Q01GrdCHT0110MListArgs>(args);
            if (result != null)
            {
                foreach (CHT0110Q01GrdCHT0110MListInfo item in result.GrdListItem)
                {
                    object[] objects = 
				{ 
					item.SangCode, 
					item.SangName, 
					item.SangNameHan, 
					item.SangNameSelf, 
					item.SangNameInx, 
					item.StartDate, 
					item.BulyongYn, 
					item.SugaSangCode, 
					item.SugaSangName, 
					item.JunyeomBunryu, 
					item.JunyeomKind, 
					item.SamangSangGroup, 
					item.SamangGroupName, 
					item.RankCnt
				};
                    res.Add(objects);
                }
            }
            return res; 
        }
        #endregion
    }
}

