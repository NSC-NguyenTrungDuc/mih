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

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0201U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0201U00 : IHIS.Framework.XScreen
	{
		bool isOCS0201Save = false;
		bool isOCS0202Save = false;

		bool isSavedOCS0201 = false;
		bool isSavedOCS0202 = false;

		#region [Instance Variable]
		//사용자
		private string mMemb = ""; 
		//Message처리
		string mbxMsg = "", mbxCap = "";
        //hospital code
        string mHospCode = EnvironInfo.HospCode;
		#endregion

		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XMstGrid grdOCS0201;
		private IHIS.Framework.XEditGrid grdOCS0202;
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
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XLabel lblSelectOCS0201;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XLabel lblSelectOCS0202;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XComboBox cboMemb;
		private IHIS.Framework.XLabel xLabel5;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.MultiLayout layOCS0202;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0201U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			SaveLayoutList.Add(grdOCS0201);
			SaveLayoutList.Add(layOCS0202);
            //SaveLayoutList.Add(grdOCS0202);

            grdOCS0201.SavePerformer = new XSavePerformer(this);
            layOCS0202.SavePerformer = grdOCS0201.SavePerformer;
            //grdOCS0202.SavePerformer = grdOCS0201.SavePerformer;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0201U00));
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0201 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.grdOCS0202 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.lblSelectOCS0201 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.lblSelectOCS0202 = new IHIS.Framework.XLabel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.cboMemb = new IHIS.Framework.XComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layOCS0202 = new IHIS.Framework.MultiLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0201)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0202)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0202)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(698, 4);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdOCS0201
            // 
            this.grdOCS0201.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell12,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell13});
            this.grdOCS0201.ColPerLine = 4;
            this.grdOCS0201.Cols = 5;
            this.grdOCS0201.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0201.FixedCols = 1;
            this.grdOCS0201.FixedRows = 1;
            this.grdOCS0201.FocusColumnName = "slip_gubun";
            this.grdOCS0201.HeaderHeights.Add(35);
            this.grdOCS0201.Location = new System.Drawing.Point(0, 24);
            this.grdOCS0201.Name = "grdOCS0201";
            this.grdOCS0201.QuerySQL = resources.GetString("grdOCS0201.QuerySQL");
            this.grdOCS0201.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0201.RowHeaderVisible = true;
            this.grdOCS0201.Rows = 2;
            this.grdOCS0201.RowStateCheckOnPaint = false;
            this.grdOCS0201.Size = new System.Drawing.Size(412, 494);
            this.grdOCS0201.TabIndex = 1;
            this.grdOCS0201.CheckDetailLayout += new System.ComponentModel.CancelEventHandler(this.grdOCS0201_CheckDetailLayout);
            this.grdOCS0201.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0201_GridColumnChanged);
            this.grdOCS0201.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0201_QueryEnd);
            this.grdOCS0201.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0201_MouseDown);
            this.grdOCS0201.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0201_GridFindClick);
            this.grdOCS0201.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS0201_RowFocusChanged);
            this.grdOCS0201.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "memb";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "memb";
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "seq";
            this.xEditGridCell2.CellWidth = 39;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "順番";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 1;
            this.xEditGridCell12.CellName = "display_yn";
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell12.HeaderText = "display_yn";
            this.xEditGridCell12.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellLen = 4;
            this.xEditGridCell3.CellName = "slip_gubun";
            this.xEditGridCell3.CellWidth = 71;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.HeaderText = "オ―ダ伝票\r\n区分";
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellLen = 80;
            this.xEditGridCell4.CellName = "slip_gubun_name";
            this.xEditGridCell4.CellWidth = 250;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.HeaderText = "オ―ダ伝票区分名";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell13.CellName = "select";
            this.xEditGridCell13.CellWidth = 42;
            this.xEditGridCell13.Col = 1;
            this.xEditGridCell13.HeaderText = "使用";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell13.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell13.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // grdOCS0202
            // 
            this.grdOCS0202.CallerID = '2';
            this.grdOCS0202.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell14});
            this.grdOCS0202.ColPerLine = 3;
            this.grdOCS0202.Cols = 4;
            this.grdOCS0202.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS0202.FixedCols = 1;
            this.grdOCS0202.FixedRows = 1;
            this.grdOCS0202.FocusColumnName = "slip_code";
            this.grdOCS0202.HeaderHeights.Add(32);
            this.grdOCS0202.Location = new System.Drawing.Point(0, 24);
            this.grdOCS0202.MasterLayout = this.grdOCS0201;
            this.grdOCS0202.Name = "grdOCS0202";
            this.grdOCS0202.QuerySQL = resources.GetString("grdOCS0202.QuerySQL");
            this.grdOCS0202.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS0202.RowHeaderVisible = true;
            this.grdOCS0202.Rows = 2;
            this.grdOCS0202.RowStateCheckOnPaint = false;
            this.grdOCS0202.Size = new System.Drawing.Size(543, 494);
            this.grdOCS0202.TabIndex = 2;
            this.grdOCS0202.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0202_MouseDown);
            this.grdOCS0202.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS0202_QueryEnd);
            this.grdOCS0202.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0202_QueryStarting);
            this.grdOCS0202.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0202_GridColumnChanged);
            this.grdOCS0202.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0202_GridFindClick);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "memb";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "memb";
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 2;
            this.xEditGridCell6.CellName = "slip_gubun";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "slip_gubun";
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell7.CellName = "seq";
            this.xEditGridCell7.CellWidth = 43;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "順番";
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            this.xEditGridCell7.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell7.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell8.CellLen = 1;
            this.xEditGridCell8.CellName = "display_yn";
            this.xEditGridCell8.CellWidth = 45;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "使用";
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell8.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell9.CellLen = 4;
            this.xEditGridCell9.CellName = "slip_code";
            this.xEditGridCell9.CellWidth = 79;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.HeaderText = "オ―ダ伝票";
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.CellLen = 40;
            this.xEditGridCell10.CellName = "slip_name";
            this.xEditGridCell10.CellWidth = 377;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.HeaderText = "オ―ダ伝票名";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell10.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell14.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell14.CellName = "select";
            this.xEditGridCell14.CellWidth = 43;
            this.xEditGridCell14.Col = 1;
            this.xEditGridCell14.HeaderText = "使用";
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell14.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell14.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xPanel1
            // 
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 548);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 42);
            this.xPanel1.TabIndex = 3;
            // 
            // xPanel2
            // 
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.Controls.Add(this.grdOCS0201);
            this.xPanel2.Controls.Add(this.lblSelectOCS0201);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel2.Location = new System.Drawing.Point(0, 30);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(412, 518);
            this.xPanel2.TabIndex = 4;
            // 
            // lblSelectOCS0201
            // 
            this.lblSelectOCS0201.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOCS0201.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectOCS0201.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectOCS0201.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOCS0201.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOCS0201.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectOCS0201.Image")));
            this.lblSelectOCS0201.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectOCS0201.ImageIndex = 0;
            this.lblSelectOCS0201.ImageList = this.ImageList;
            this.lblSelectOCS0201.Location = new System.Drawing.Point(0, 0);
            this.lblSelectOCS0201.Name = "lblSelectOCS0201";
            this.lblSelectOCS0201.Size = new System.Drawing.Size(412, 24);
            this.lblSelectOCS0201.TabIndex = 17;
            this.lblSelectOCS0201.Text = " 全体選択";
            this.lblSelectOCS0201.Click += new System.EventHandler(this.lblSelectOCS0201_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdOCS0202);
            this.xPanel3.Controls.Add(this.lblSelectOCS0202);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(417, 30);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(543, 518);
            this.xPanel3.TabIndex = 7;
            // 
            // lblSelectOCS0202
            // 
            this.lblSelectOCS0202.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblSelectOCS0202.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSelectOCS0202.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectOCS0202.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.lblSelectOCS0202.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.lblSelectOCS0202.Image = ((System.Drawing.Image)(resources.GetObject("lblSelectOCS0202.Image")));
            this.lblSelectOCS0202.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectOCS0202.ImageIndex = 0;
            this.lblSelectOCS0202.ImageList = this.ImageList;
            this.lblSelectOCS0202.Location = new System.Drawing.Point(0, 0);
            this.lblSelectOCS0202.Name = "lblSelectOCS0202";
            this.lblSelectOCS0202.Size = new System.Drawing.Size(543, 24);
            this.lblSelectOCS0202.TabIndex = 18;
            this.lblSelectOCS0202.Text = " 全体選択";
            this.lblSelectOCS0202.Click += new System.EventHandler(this.lblSelectOCS0202_Click);
            // 
            // xPanel4
            // 
            this.xPanel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel4.BackgroundImage")));
            this.xPanel4.Controls.Add(this.cboMemb);
            this.xPanel4.Controls.Add(this.xLabel5);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel4.Location = new System.Drawing.Point(0, 0);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(960, 30);
            this.xPanel4.TabIndex = 8;
            // 
            // cboMemb
            // 
            this.cboMemb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMemb.ImageList = this.ImageList;
            this.cboMemb.Location = new System.Drawing.Point(98, 6);
            this.cboMemb.Name = "cboMemb";
            this.cboMemb.Size = new System.Drawing.Size(121, 21);
            this.cboMemb.TabIndex = 7;
            this.cboMemb.SelectedIndexChanged += new System.EventHandler(this.cboMemb_SelectedIndexChanged);
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Location = new System.Drawing.Point(10, 6);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(88, 21);
            this.xLabel5.TabIndex = 6;
            this.xLabel5.Text = "使用者";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(412, 30);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 518);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // layOCS0202
            // 
            this.layOCS0202.CallerID = '2';
            this.layOCS0202.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.SaveEnd);
            this.layOCS0202.PreSaveLayout += new IHIS.Framework.MultiRecordEventHandler(this.layOCS0202_PreSaveLayout);
            // 
            // OCS0201U00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS0201U00";
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0201)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0202)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layOCS0202)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
		
		#region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
		public override object Command(string command, CommonItemCollection commandParam)
		{	
			if(command == "F") return base.Command (command, commandParam);

			mMemb = commandParam["memb"].ToString();
			
			return base.Command (command, commandParam);
		}
		#endregion
		
		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			//Set M/D Relation
			grdOCS0202.SetRelationKey("memb"      , "memb"      );
			grdOCS0202.SetRelationKey("slip_gubun", "slip_gubun");
		
			//Set Current Grid
			this.CurrMSLayout = this.grdOCS0201;
			this.CurrMQLayout = this.grdOCS0201;

			CreateLayout();
        
			/// 사용자 변경 Event Call /////////////////////////////////////
			this.OCS0201U00_UserChanged(this, new System.EventArgs()); 
			/////////////////////////////////////////////////////////////////
		}

		private void OCS0201U00_UserChanged(object sender, System.EventArgs e)
		{
			//reset
			this.grdOCS0201.Reset();
			this.grdOCS0202.Reset();
			
			//memb reset
			this.cboMemb.DataSource = null;
			XComboItem cboItem;			
            
			//해당 사용자 User
			if(UserInfo.SlipOpenID.Trim() != "")
			{
				cboItem = new XComboItem(UserInfo.SlipOpenID, GetOCSCOM_USER_NAME(UserInfo.SlipOpenID), 2); 
				cboMemb.ComboItems.Add(cboItem);
			}
			else if(UserInfo.UserGubun == UserType.Doctor)
			{
				cboItem = new XComboItem(UserInfo.UserID, GetOCSCOM_USER_NAME(UserInfo.UserID), 2); 
				cboMemb.ComboItems.Add(cboItem);
			}
                        
			//공통 User를 가져온다.
			if(UserInfo.SlipOpenID != UserInfo.SlipComID && UserInfo.SlipComID.Trim() != "")
			{
				cboItem = new XComboItem(UserInfo.SlipComID, GetOCSCOM_USER_NAME(UserInfo.SlipComID), 3); 
				cboMemb.ComboItems.Add(cboItem);
			}
			else
			{
				string slip_com_id = GetOCSCOM_USER_ID("SLIP", UserInfo.UserID);
				if(UserInfo.SlipOpenID != slip_com_id && slip_com_id != "")
				{
					cboItem = new XComboItem(slip_com_id, GetOCSCOM_USER_NAME(slip_com_id), 3); 
					cboMemb.ComboItems.Add(cboItem);
				}			
			}
			
			//사용자 서식지정보 Load
			cboMemb.RefreshComboItems();
			if (cboMemb.ComboItems.Count > 0 ) 
				cboMemb.SelectedIndex = 0;		
			else
			{
				mbxMsg = NetInfo.Language == LangMode.Jr ? "該当画面に使用権限がない使用者です。ご確認下さい。" : "해당 화면에 사용권한이 없는 사용자입니다. 확인하십시요.";
				mbxCap = NetInfo.Language == LangMode.Jr ? "使用権限" : "사용권한";
				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Stop);
				this.Close();
			}
		}

		/// <summary>
		/// DataLayout LayoutItems생성
		/// </summary>
		private void CreateLayout()
		{			
			//OCS0202
			foreach(XGridCell cell in this.grdOCS0202.CellInfos)
			{
				layOCS0202.LayoutItems.Add(cell.CellName, (DataType)cell.CellType, false, true);
			}

			layOCS0202.InitializeLayoutTable();				
		
		}

		#endregion

		#region [grdOCS0201 Event]
		private void grdOCS0201_CheckDetailLayout(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XMstGrid mstGrid = sender as XMstGrid;

			if (mstGrid.CurrentRowNumber < 0) return;
			
			int chk = 0;

			try
			{
				foreach( object obj in this.Controls )
				{
					if( obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
					{	
						chk = chk + ((XGrid)obj).RowCount;						
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XEditGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XEditGrid)obj).DeletedRowCount;
					}
					else if( obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XMstGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XMstGrid)obj).DeletedRowCount;
					}
					else if( obj.GetType().Name.ToString().IndexOf("XPanel") >= 0  )
					{
						foreach( object panObj in ((XPanel)obj).Controls )
						{
							if( panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)panObj).RowCount;						
							}
							else if( panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)panObj).DeletedRowCount;
							}
							else if( panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)panObj).DeletedRowCount;
							}							
						}
					}
				}
			}
			catch {}

			if(chk > 0)
			{				
				e.Cancel = true;
			}
			else
				e.Cancel = false;
		}

		private void grdOCS0201_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			e.Cancel = false;

			switch (e.ColName)
			{
				case "slip_gubun":
                    
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					//중복 Check
					for(int i = 0; i < grdOCS0201.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0201.GetItemString(i, "slip_gubun").Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダ伝票区分が重複されます. 確認してください." : "서식지구분이 중복됩니다. 확인바랍니다.";
								mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
								XMessageBox.Show(mbxMsg, mbxCap);
								e.Cancel= true;	
								break;
							}
						}
					} 

					if(e.Cancel) break;

					//Check Origin Data
					string cmdText = @" SELECT 'Y'
						                  FROM OCS0201
						                 WHERE MEMB       = :f_mMemb
						                   AND SLIP_GUBUN = :f_value
						                   AND ROWNUM     = 1 
                                           AND HOSP_CODE  = :f_hosp_code";

					IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
					bindVars.Add("f_value",e.ChangeValue.ToString().Trim());
					bindVars.Add("f_mMemb",mMemb);
                    bindVars.Add("f_hosp_code", mHospCode);

					object retCheck = Service.ExecuteScalar(cmdText,bindVars);

					if(retCheck != null)
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダ伝票区分が重複されます. 確認してください." : "서식지구분이 중복됩니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);
						e.Cancel= true;
						break;
					}              

					string slip_gubun_name = GetCodeName("slip_gubun", e.ChangeValue.ToString().Trim());

					if(slip_gubun_name == "")
						e.Cancel = true;
					else
						grdOCS0201.SetItemValue(e.RowNumber, "slip_gubun_name", slip_gubun_name);
					break;
				default:
					break;
			}
		}

		private void grdOCS0201_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "slip_gubun":
					((XFindBox)((XEditGridCell)grdOCS0201.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = GetFindWorker(e.ColName);
					break;
				default:
					break;
			}
		}

		private void grdOCS0201_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS0201.CurrentColNumber == 0)
			{
				int curRowIndex = grdOCS0201.GetHitRowNumber(e.Y);				
				if(curRowIndex < 0) return;

				if(grdOCS0201.CurrentColNumber == 0)
				{	
					if(grdOCS0201.GetItemString(curRowIndex, "select") == "")
					{
						grdOCS0201.SetItemValue(curRowIndex, "select", " ");
						grdOCS0201.SetItemValue(curRowIndex, "display_yn", "Y");
						SelectionBackColorChange(sender, curRowIndex, "Y");
					}
					else
					{
						grdOCS0201.SetItemValue(curRowIndex, "select", "");
						grdOCS0201.SetItemValue(curRowIndex, "display_yn", "N");
						SelectionBackColorChange(sender, curRowIndex, "N");

						//OCS0201 선택해제시 OCS0202 전체선택 해제
						lblSelectOCS0202.ImageIndex = 0;
						lblSelectOCS0202.Text = " 全体選択";
						setSelectAll(grdOCS0202, false);
					}
				}
			}
        }

        private void grdOCS0201_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //이전정보 Back
            if (e.PreviousRow >= 0)
                BackSelectRow();

            //grdOCS0202.Reset();

            //if (e.CurrentRow >= 0)
                //grdOCS0202.QueryLayout(false);
        }

		private void grdOCS0201_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			lblSelectOCS0201.ImageIndex = 0;
			lblSelectOCS0201.Text = " 全体選択";

			layOCS0202.Reset();
			SelectionBackColorChange(grdOCS0201);
		}
		#endregion
		
		#region [grdOCS0202 Event]
		private void grdOCS0202_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks == 1 && grdOCS0202.CurrentColNumber == 0)
			{
				int curRowIndex = grdOCS0202.GetHitRowNumber(e.Y);				
				if(curRowIndex < 0) return;

				if(grdOCS0201.CurrentRowNumber >= 0 && grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber, "display_yn") != "Y" ) return;

				if(grdOCS0202.CurrentColNumber == 0)
				{	
					if(grdOCS0202.GetItemString(curRowIndex, "select") == "")
					{
						grdOCS0202.SetItemValue(curRowIndex, "select", " ");
						grdOCS0202.SetItemValue(curRowIndex, "display_yn", "Y");
						SelectionBackColorChange(sender, curRowIndex, "Y");
					}
					else
					{
						grdOCS0202.SetItemValue(curRowIndex, "select", "");
						grdOCS0202.SetItemValue(curRowIndex, "display_yn", "N");
						SelectionBackColorChange(sender, curRowIndex, "N");
					}
				}
			}
		}

		private void grdOCS0202_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			e.Cancel = false;

			switch (e.ColName)
			{
				case "slip_code":
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					//중복 Check
					for(int i = 0; i < grdOCS0202.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdOCS0202.GetItemString(i, "slip_code").Trim() == e.ChangeValue.ToString().Trim() )
							{
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダ伝票コードが重複します。 ご確認ください。" : "서식지코드가 중복됩니다. 확인바랍니다.";
								mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
								XMessageBox.Show(mbxMsg, mbxCap);
								e.Cancel= true;
								break;
							}
						}
					} 

					if(e.Cancel) break;

					string slip_gubun = grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber, "slip_gubun");

					IHIS.Framework.SingleLayout layCommon = new SingleLayout();
					//Check Origin Data
					layCommon.Reset();
					layCommon.QuerySQL = " SELECT 'Y' "
					                   + "   FROM OCS0202 "
					                   + "  WHERE MEMB       = '" + mMemb + "' "
					                   + "    AND SLIP_GUBUN = '" + slip_gubun + "' "
					                   + "    AND SLIP_CODE  = '" + e.ChangeValue.ToString().Trim() + "' "
					                   + "    AND ROWNUM     = 1 "
                                       + "    AND HOSP_CODE  = '" + mHospCode + "' ";
					
					layCommon.LayoutItems.Clear();
                    layCommon.LayoutItems.Add("check");

					if(layCommon.QueryLayout() || layCommon.GetItemValue("check").ToString() == "Y")
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダ伝票コードに重複データがあります。 ご確認ください。" : "서식지코드가 중복됩니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);
						e.Cancel= true;
						break;
					}              
                    
					layCommon.Reset();
					layCommon.QuerySQL = "SELECT A.SLIP_NAME "   
						               + "  FROM OCS0102 A " 
						               + " WHERE A.SLIP_GUBUN = '" + slip_gubun + "' "
                                       + "   AND A.SLIP_CODE  = '" + e.ChangeValue + "'"
                                       + "   AND A.HOSP_CODE  = '" + mHospCode + "' "; ;
					
					layCommon.LayoutItems.Clear();
					layCommon.LayoutItems.Add("slip_name");

					if(layCommon.QueryLayout() || layCommon.GetItemValue("code_name").ToString() == "")
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダ伝票に間違いがあります。 ご確認ください。" : "서식지코드가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);	
						e.Cancel = true;
					}
					else
					{
						grdOCS0202.SetItemValue(e.RowNumber, "slip_name", layCommon.GetItemValue("slip_name").ToString());
					}
					break;
				default:
					break;
			}
		}

		private void grdOCS0202_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
			switch (e.ColName)
			{
				case "slip_code":
					((XFindBox)((XEditGridCell)grdOCS0202.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = GetFindWorker(e.ColName);
					break;
				default:
					break;
			}
		}

		private void grdOCS0202_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
		{
			grdOCS0202.SetBindVarValue("f_memb",grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber,"memb"));
			grdOCS0202.SetBindVarValue("f_slip_gubun",grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber,"slip_gubun"));
		}

		private void grdOCS0202_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			lblSelectOCS0202.ImageIndex = 0;
			lblSelectOCS0202.Text = " 全体選択";

			SetbackSelect();
		}
		#endregion
        
		/// <summary>
		/// 해당 사용자의 공통 USER ID를 가져옵니다.
		/// </summary>
		/// <param name="aUser_gubun">공통사용자구분</param>
		/// <param name="aUser_id">사용자ID</param>
		/// <returns></returns>
		private string GetOCSCOM_USER_ID(string aUser_gubun, string aUser_id)
		{
			string comUser_id = "";
			string cmdText = "";

			cmdText = ""
				+ " SELECT FN_OCS_LOAD_MEMB_COMID(:f_aUser_gubun , :f_aUser_id) "
				+ "   FROM DUAL ";

			IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
			bindVars.Add("f_aUser_gubun",aUser_gubun);
			bindVars.Add("f_aUser_id",aUser_id);

			object retComUserID = Service.ExecuteScalar(cmdText,bindVars);
                    
			if(retComUserID != null)
				comUser_id = retComUserID.ToString();

			return comUser_id;
		}

		private string GetOCSCOM_USER_NAME(string aUser_id)
		{
			string comUser_name = "";
			string cmdText = "";

			cmdText = @"SELECT MEMB_NAME
				          FROM OCS0130
				         WHERE MEMB      = :f_aUser_id
                           AND HOSP_CODE = :f_hosp_code ";

			IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();
			bindVars.Add("f_aUser_id",aUser_id);
            bindVars.Add("f_hosp_code", mHospCode);

			object retComUserName = Service.ExecuteScalar(cmdText,bindVars);
                    
			if(retComUserName != null)
				comUser_name = retComUserName.ToString();

			return comUser_name;
		}

		#region [Load Code Name]
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		/// <param name="codeMode">코드구분</param>
		/// <param name="code">코드Value</param>
		/// <returns></returns>
		private string GetCodeName(string codeMode, string code)
		{
			string codeName = "";
			string cmdText = "";
			IHIS.Framework.BindVarCollection bindCode = new BindVarCollection();
			object retCodeName = null;

			if(code.Trim() == "" ) return codeName;

			switch (codeMode)
			{
				case "slip_gubun":
					cmdText = "SELECT A.SLIP_GUBUN_NAME "   
						+ "  FROM OCS0101 A "
						+ " WHERE A.SLIP_GUBUN   = :f_code";

					bindCode.Clear();
					bindCode.Add("f_code",code);

					retCodeName = Service.ExecuteScalar(cmdText,bindCode);

					if(codeName == null)
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダ伝票区分が正確ではないです. 確認してください." : "서식지구분이 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);						
					}
					else
						codeName = retCodeName.ToString();
					break;
				case "slip_code":
					string slip_gubun = grdOCS0202.GetItemString(grdOCS0202.CurrentRowNumber, "slip_gubun");
                    
					cmdText = "SELECT A.SLIP_NAME "   
						+ "  FROM OCS0102 A " 
						+ " WHERE A.SLIP_GUBUN = :f_slip_gubun" 
						+ "   AND A.SLIP_CODE  = :f_code";

					bindCode.Clear();
					bindCode.Add("f_slip_gubun",slip_gubun);
					bindCode.Add("f_code",code);

					retCodeName = Service.ExecuteScalar(cmdText,bindCode);

					if(codeName == null)
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "オ―ダ伝票が正確ではないです. 確認してください." : "서식지코드가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
						XMessageBox.Show(mbxMsg, mbxCap);						
					}
					else
						codeName = retCodeName.ToString();
					break;
				default:
					break;
			}

			return codeName;
		}
		#endregion

		#region [GetFindWorker]
		private XFindWorker GetFindWorker(string findMode)
		{
			XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();
			switch (findMode)
			{	
				case "slip_gubun":
					fdwCommon.AutoQuery = true;
					fdwCommon.InputSQL = "SELECT A.SLIP_GUBUN, A.SLIP_GUBUN_NAME "   
						+ "  FROM OCS0101 A ";

					fdwCommon.ColInfos.Add("slip_gubun", "オ―ダ伝票区分", FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("slip_gubun_name", "オ―ダ伝票区分名", FindColType.String, 300, 0, true, FilterType.No);
					break;
				case "slip_code":
					string slip_gubun = grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber, "slip_gubun");
					fdwCommon.AutoQuery = true;
					fdwCommon.InputSQL = "SELECT A.SLIP_CODE, A.SLIP_NAME "   
						+ "  FROM OCS0102 A " 
						+ " WHERE A.SLIP_GUBUN   = '" + slip_gubun + "'";

					fdwCommon.ColInfos.Add("slip_code", "オ―ダ伝票コード", FindColType.String, 100, 0, true, FilterType.Yes); 
					fdwCommon.ColInfos.Add("slip_name", "オ―ダ伝票コード名", FindColType.String, 300, 0, true, FilterType.No);
					break;
				default:
					break;
			}
			return fdwCommon;
		}
		#endregion

		#region [Button List]
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdOCS0201.Reset();
                    grdOCS0202.Reset();

                    grdOCS0201.SetBindVarValue("f_memb", mMemb);
                    grdOCS0201.QueryLayout(false);
                    break;

				case FunctionType.Insert:
					e.IsBaseCall = false;
					DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
					if(chkCell.RowNumber < 0)
					{
						int currentRow = -1;
						if(this.CurrMSLayout == grdOCS0201)
						{
							currentRow = grdOCS0201.InsertRow();
							grdOCS0201.SetItemValue(currentRow, "memb", mMemb);
						}
						else
						{
							currentRow = grdOCS0202.InsertRow();
							grdOCS0202.SetItemValue(currentRow, "memb", mMemb);
							grdOCS0202.SetItemValue(currentRow, "slip_gubun", grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber, "slip_gubun"));
						}
					}
					else
						((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
					break;

				case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        SaveStarting();
                        grdOCS0201.SaveLayout();
                        layOCS0202.SaveLayout();
                    }
                    catch (Exception)
                    {
                        XMessageBox.Show(Service.ErrFullMsg, "保存エラー", MessageBoxIcon.Error);
                        return;
                    }
					break;
				case FunctionType.Delete:
					break;
				default:
					break;
			}
		}

		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:
					break;
				default:
					break;
			}
		}
		#endregion

		#region [Function]
		/// <summary>
		/// 해당 Grid가 다시 load되기 전에 선택된 row를 backup
		/// </summary>
		private void BackSelectRow()
		{
			this.AcceptData();

			foreach(DataRow row in grdOCS0202.LayoutTable.Rows)
			{
				layOCS0202.LayoutTable.ImportRow(row);				
			}
		}
	    
		private void SetbackSelect()
		{
			//OCS0201선택이 해제되어 있을때
			string slip_gubun = "";
			if(grdOCS0201.CurrentRowNumber >= 0 && grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber, "display_yn") != "Y" )
				slip_gubun = grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber, "slip_gubun");

			DataRow[] backSelectRow;			

			foreach(DataRow row in grdOCS0202.LayoutTable.Rows)
			{
				backSelectRow = layOCS0202.LayoutTable.Select(" slip_gubun = '" + row["slip_gubun"].ToString() + "' and slip_code = '" + row["slip_code"].ToString() + "' ", "");

				if(backSelectRow.Length > 0)
				{
					if(slip_gubun == "")
					{
						if(row["display_yn"].ToString() != backSelectRow[0]["display_yn"].ToString())
						{
							row["select"] = backSelectRow[0]["select"];
							row["display_yn"] = backSelectRow[0]["display_yn"];
						}
					}
					else
					{
						if(row["display_yn"].ToString() == "Y")
						{
							row["select"] = "";
							row["display_yn"] = "N";
						}
					}
					//backSelectRow는 삭제한다.
					layOCS0202.LayoutTable.Rows.Remove(backSelectRow[0]);
				}
			}

			SelectionBackColorChange(grdOCS0202);
		}

		private void setSelectAll(XEditGrid grd, bool select)
		{
			for(int i = 0; i < grd.RowCount; i++)
			{
				if(select)
				{
					grd.SetItemValue(i, "select", " ");
					grd.SetItemValue(i, "display_yn", "Y");
				}
				else
				{
					grd.SetItemValue(i, "select", "");
					grd.SetItemValue(i, "display_yn", "N");
				}
			}

			SelectionBackColorChange(grd);
		}

		#endregion
		
		#region [Control]
		private void cboMemb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			mMemb = cboMemb.SelectedValue.ToString();
			grdOCS0201.SetBindVarValue("f_memb", mMemb);
			grdOCS0201.QueryLayout(false);
		}

		private void lblSelectOCS0201_Click(object sender, System.EventArgs e)
		{
			if(lblSelectOCS0201.ImageIndex == 0)
			{
				lblSelectOCS0201.ImageIndex = 1;
				lblSelectOCS0201.Text = " 全体選択取消";
				setSelectAll(grdOCS0201, true);
			}
			else
			{
				lblSelectOCS0201.ImageIndex = 0;
				lblSelectOCS0201.Text = " 全体選択";
				setSelectAll(grdOCS0201, false);

				lblSelectOCS0202.ImageIndex = 0;
				lblSelectOCS0202.Text = " 全体選択";
				setSelectAll(grdOCS0202, false);
			}
		}

		private void lblSelectOCS0202_Click(object sender, System.EventArgs e)
		{
			if(grdOCS0201.CurrentRowNumber >= 0 && grdOCS0201.GetItemString(grdOCS0201.CurrentRowNumber, "display_yn") != "Y" ) return;

			if(lblSelectOCS0202.ImageIndex == 0)
			{
				lblSelectOCS0202.ImageIndex = 1;
				lblSelectOCS0202.Text = " 全体選択取消";
				setSelectAll(grdOCS0202, true);
			}
			else
			{
				lblSelectOCS0202.ImageIndex = 0;
				lblSelectOCS0202.Text = " 全体選択";
				setSelectAll(grdOCS0202, false);
			}
		}
		#endregion

		#region [SaveStart / SaveEnd]
        //private void SaveStarting(object sender, IHIS.Framework.GridRecordEventArgs e)
        private void SaveStarting()
		{
			AcceptData();
            
			//grdOCS0201
			int seq = 0;
			for(int rowIndex = 0; rowIndex < grdOCS0201.RowCount; rowIndex++)
			{	
				seq++;
				if(grdOCS0201.GetItemString(rowIndex, "seq") != seq.ToString()) grdOCS0201.SetItemValue(rowIndex, "seq", seq);

            }

            //layOCS0202

            //OCS0202 Back
            BackSelectRow();

            string slip_gubun = "";

            for (int rowIndex = 0; rowIndex < layOCS0202.RowCount; rowIndex++)
            {
                if (slip_gubun != layOCS0202.GetItemString(rowIndex, "slip_gubun"))
                {
                    seq = 1;
                    slip_gubun = layOCS0202.GetItemString(rowIndex, "slip_gubun");
                }

                if (layOCS0202.GetItemString(rowIndex, "seq") != seq.ToString()) layOCS0202.SetItemValue(rowIndex, "seq", seq);
            }
        }

        private void layOCS0202_PreSaveLayout(object sender, MultiRecordEventArgs e)
        {
            //layOCS0202

            //OCS0202 Back
            //BackSelectRow();

            //string slip_gubun = "";
            //int seq = 1;

            //for (int rowIndex = 0; rowIndex < layOCS0202.RowCount; rowIndex++)
            //{
            //    if (slip_gubun != layOCS0202.GetItemString(rowIndex, "slip_gubun"))
            //    {
            //        seq = 1;
            //        slip_gubun = layOCS0202.GetItemString(rowIndex, "slip_gubun");
            //    }

            //    if (layOCS0202.GetItemString(rowIndex, "seq") != seq.ToString()) layOCS0202.SetItemValue(rowIndex, "seq", seq);
            //}
        }
		
		private void SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
		{
			switch(e.CallerID)
			{
				case '1':
					isOCS0201Save = e.IsSuccess;
					isSavedOCS0201 = true;
					break;
				case '2':
					isOCS0202Save = e.IsSuccess;
					isSavedOCS0202 = true;
					break;
			}

			if(isSavedOCS0201 && isSavedOCS0202)
			{
				if(isOCS0201Save && isOCS0202Save)
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
					SetMsg(mbxMsg);
					grdOCS0202.ResetUpdate();
					layOCS0202.Reset();
				}
				else
				{
					mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다."; 
					mbxMsg = mbxMsg + e.ErrMsg;
					mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
					XMessageBox.Show(mbxMsg, mbxCap);
				}

				isOCS0201Save = false;
				isOCS0202Save = false;

				isSavedOCS0201 = false;
				isSavedOCS0202 = false;
			}
		}

		#endregion

		#region Insert한 Row 중에  Not Null필드 미입력 Row Search (GetEmptyNewRow)
		/// <summary>
		/// Insert한 Row 중에 Not Null필드 미입력 Row Search
		/// </summary>
		/// <remarks>
		/// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
		/// </remarks>
		/// <param name="aGrd"> XEditGrid  </param>
		/// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
		private DataGridCell GetEmptyNewRow(object aGrd)
		{
			DataGridCell celReturn = new DataGridCell(-1, -1);

			if (aGrd == null) return celReturn;

			XEditGrid grdChk = null;
            
			try
			{
				grdChk = (XEditGrid)aGrd;
			}
			catch
			{
				return celReturn;
			}

			foreach (XEditGridCell cell in grdChk.CellInfos)
			{
				// NotNull Check
				if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly) 
				{
					for( int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
					{
						if(grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
						{
							celReturn.ColumnNumber = cell.Col;
							celReturn.RowNumber   = rowIndex;
							break;
						}
					}

					if(celReturn.RowNumber < 0) 
						continue;
					else
						break;
				}

			}

			return celReturn;
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
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];
			else
				grdObject[currentRowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];

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
				if(grdObject.GetItemString(rowIndex, "display_yn").ToString() == "Y")
				{				
					if(grdObject.GetItemString(rowIndex, "select").ToString() != " ")
						grdObject.SetItemValue(rowIndex, "select", " ");

					//image 변경
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[1];					

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
					grdObject[rowIndex + grdObject.HeaderHeights.Count, 1].Image = this.ImageList.Images[0];
					for(int liColCnt = 0; liColCnt < grdObject.Cols; liColCnt++)
					{					
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].BackColor = XColor.XGridRowBackColor;
						grdObject[rowIndex + grdObject.HeaderHeights.Count, liColCnt].ForeColor = XColor.NormalForeColor;
					}
				}
			}

		}
		#endregion	  
	
		#region [XSavePerformer Class]
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private OCS0201U00 parent = null;

			public XSavePerformer(OCS0201U00 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";
				item.BindVarList.Add("f_user_id",UserInfo.UserID);
				bool retbl = false;

				switch(callerID)
				{
					case '1': 
						switch(item.RowState)
						{
							case DataRowState.Added :
								retbl = true;
								break;
							case DataRowState.Modified :
								cmdText = @"BEGIN
                                            UPDATE OCS0201
                                               SET UPD_ID     = :f_user_id    ,
                                                   UPD_DATE   = SYSDATE       ,
                                                   SEQ        = :f_seq        ,
                                                   DISPLAY_YN = :f_display_yn   
                                             WHERE MEMB       = :f_memb
                                               AND SLIP_GUBUN = :f_slip_gubun;
                                             
                                             IF SQL%NOTFOUND THEN 
                                                 INSERT INTO OCS0201
                                                        (SYS_DATE, SYS_ID, UPD_DATE,
                                                         MEMB, SEQ, SLIP_GUBUN, DISPLAY_YN)
                                                 VALUES (SYSDATE, :f_user_id, SYSDATE,
                                                         :f_memb, :f_seq, :f_slip_gubun, :f_display_yn);
                                             END IF;
                                             
                                             IF :f_display_yn = 'N' THEN
                                                UPDATE OCS0202
                                                   SET UPD_ID    = :f_user_id    ,
                                                       UPD_DATE   = SYSDATE       ,
                                                       DISPLAY_YN = 'N'   
                                                 WHERE MEMB       = :f_memb
                                                   AND SLIP_GUBUN = :f_slip_gubun;
                                             END IF;
                                             END;";

								retbl = Service.ExecuteNonQuery(cmdText,item.BindVarList);
								break;
							case DataRowState.Deleted :
								retbl = true;
								break;
						}
						break;
					case '2': 
						switch(item.RowState)
						{
							case DataRowState.Added :
								retbl = true;
								break;
							case DataRowState.Modified :
                                cmdText = @"BEGIN
                                            UPDATE OCS0202
                                               SET UPD_ID    = :f_user_id    ,
                                                   UPD_DATE   = SYSDATE       ,
                                                   SEQ        = :f_seq        ,
                                                   DISPLAY_YN = :f_display_yn
                                             WHERE MEMB       = :f_memb
                                               AND SLIP_GUBUN = :f_slip_gubun
                                               AND SLIP_CODE  = :f_slip_code;

                                            IF SQL%NOTFOUND THEN
                                               INSERT INTO OCS0202
                                                      (SYS_DATE, SYS_ID, UPD_DATE, MEMB, SLIP_GUBUN ,
                                                       SLIP_CODE, SEQ, DISPLAY_YN )
                                               VALUES (SYSDATE, :f_user_id, SYSDATE, :f_memb, :f_slip_gubun,
                                                       :f_slip_code, :f_seq, :f_display_yn );
                                            END IF;
                                            END;";

								retbl = Service.ExecuteNonQuery(cmdText,item.BindVarList);
								break;
							case DataRowState.Deleted :
								retbl = true;
								break;
						}
						break;
				}

				return retbl;
			}
		}
		#endregion
	}
}

