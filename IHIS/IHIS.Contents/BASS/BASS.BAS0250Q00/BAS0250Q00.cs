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

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0250Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0250Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XEditGrid grdHOBED;
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
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnSelect;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XButton btnQuery;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.MultiLayout layJaewonList;
		private System.Windows.Forms.ToolTip toolTip1;
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
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XMstGrid grdBAS0260;
		private IHIS.Framework.SingleLayout layMaxBedNo;
		private IHIS.Framework.MultiLayout layReserBed;
		private IHIS.Framework.MultiLayout layBedStatus;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XButtonList btnList;
		private System.Windows.Forms.Panel pnlHelp;
		private IHIS.Framework.XButton btnHelp;
		private IHIS.Framework.XPictureBox xPictureBox1;
        private SingleLayoutItem singleLayoutItem1;
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
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
		private System.ComponentModel.IContainer components;

		public BAS0250Q00()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0250Q00));
            this.grdHOBED = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.layJaewonList = new IHIS.Framework.MultiLayout();
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
            this.grdBAS0260 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.layMaxBedNo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layReserBed = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.layBedStatus = new IHIS.Framework.MultiLayout();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.btnHelp = new IHIS.Framework.XButton();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.btnQuery = new IHIS.Framework.XButton();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdHOBED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJaewonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0260)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserBed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBedStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
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
            this.ImageList.Images.SetKeyName(5, "이석.gif");
            // 
            // grdHOBED
            // 
            this.grdHOBED.AddedHeaderLine = 1;
            this.grdHOBED.ApplyPaintEventToAllColumn = true;
            this.grdHOBED.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
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
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35});
            this.grdHOBED.ColPerLine = 31;
            this.grdHOBED.Cols = 31;
            this.grdHOBED.DefaultHeight = 26;
            this.grdHOBED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHOBED.FixedRows = 2;
            this.grdHOBED.HeaderHeights.Add(18);
            this.grdHOBED.HeaderHeights.Add(16);
            this.grdHOBED.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdHOBED.ImageList = this.ImageList;
            this.grdHOBED.Location = new System.Drawing.Point(104, 4);
            this.grdHOBED.Name = "grdHOBED";
            this.grdHOBED.QuerySQL = resources.GetString("grdHOBED.QuerySQL");
            this.grdHOBED.ReadOnly = true;
            this.grdHOBED.Rows = 3;
            this.grdHOBED.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdHOBED.Size = new System.Drawing.Size(599, 481);
            this.grdHOBED.TabIndex = 1;
            this.grdHOBED.ToolTipActive = true;
            this.grdHOBED.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdHOBED_MouseDown);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_dong";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ho_code";
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "病室";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowSpan = 2;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "ho_total_bed";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ho_grade";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ho_status";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell3.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell3.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.CellName = "01";
            this.xEditGridCell3.CellWidth = 57;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "1";
            this.xEditGridCell3.ImageList = this.ImageList;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.Row = 1;
            this.xEditGridCell3.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell3.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell3.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell4.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "02";
            this.xEditGridCell4.CellWidth = 57;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "2";
            this.xEditGridCell4.ImageList = this.ImageList;
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.Row = 1;
            this.xEditGridCell4.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell4.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell5.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell5.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.CellName = "03";
            this.xEditGridCell5.CellWidth = 57;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "3";
            this.xEditGridCell5.ImageList = this.ImageList;
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.Row = 1;
            this.xEditGridCell5.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell5.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell5.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell6.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell6.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell6.CellName = "04";
            this.xEditGridCell6.CellWidth = 57;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "4";
            this.xEditGridCell6.ImageList = this.ImageList;
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.Row = 1;
            this.xEditGridCell6.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell6.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell6.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell6.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell7.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.CellName = "05";
            this.xEditGridCell7.CellWidth = 57;
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "5";
            this.xEditGridCell7.ImageList = this.ImageList;
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.Row = 1;
            this.xEditGridCell7.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell7.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell8.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell8.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell8.CellName = "06";
            this.xEditGridCell8.CellWidth = 57;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "6";
            this.xEditGridCell8.ImageList = this.ImageList;
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell8.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell8.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell8.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell9.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell9.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell9.CellName = "07";
            this.xEditGridCell9.CellWidth = 57;
            this.xEditGridCell9.Col = 7;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "7";
            this.xEditGridCell9.ImageList = this.ImageList;
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.Row = 1;
            this.xEditGridCell9.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell9.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell9.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell10.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell10.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.CellName = "08";
            this.xEditGridCell10.CellWidth = 59;
            this.xEditGridCell10.Col = 8;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "8";
            this.xEditGridCell10.ImageList = this.ImageList;
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.Row = 1;
            this.xEditGridCell10.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell10.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell10.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell14.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell14.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell14.CellName = "09";
            this.xEditGridCell14.CellWidth = 57;
            this.xEditGridCell14.Col = 9;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "9";
            this.xEditGridCell14.Row = 1;
            this.xEditGridCell14.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell14.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell14.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell15.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.CellName = "10";
            this.xEditGridCell15.CellWidth = 57;
            this.xEditGridCell15.Col = 10;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "10";
            this.xEditGridCell15.Row = 1;
            this.xEditGridCell15.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell15.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell15.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell16.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell16.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell16.CellName = "11";
            this.xEditGridCell16.CellWidth = 57;
            this.xEditGridCell16.Col = 11;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "11";
            this.xEditGridCell16.Row = 1;
            this.xEditGridCell16.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell16.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell16.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell17.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell17.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell17.CellName = "12";
            this.xEditGridCell17.CellWidth = 57;
            this.xEditGridCell17.Col = 12;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "12";
            this.xEditGridCell17.Row = 1;
            this.xEditGridCell17.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell17.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell17.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell18.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell18.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell18.CellName = "13";
            this.xEditGridCell18.CellWidth = 57;
            this.xEditGridCell18.Col = 13;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.HeaderText = "13";
            this.xEditGridCell18.Row = 1;
            this.xEditGridCell18.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell18.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell18.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell19.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell19.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell19.CellName = "14";
            this.xEditGridCell19.CellWidth = 57;
            this.xEditGridCell19.Col = 14;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "14";
            this.xEditGridCell19.Row = 1;
            this.xEditGridCell19.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell19.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell19.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell20.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell20.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell20.CellName = "15";
            this.xEditGridCell20.CellWidth = 57;
            this.xEditGridCell20.Col = 15;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell20.HeaderText = "15";
            this.xEditGridCell20.Row = 1;
            this.xEditGridCell20.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell20.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell20.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell21.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell21.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell21.CellName = "16";
            this.xEditGridCell21.CellWidth = 57;
            this.xEditGridCell21.Col = 16;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell21.HeaderText = "16";
            this.xEditGridCell21.Row = 1;
            this.xEditGridCell21.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell21.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell21.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell22.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell22.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell22.CellName = "17";
            this.xEditGridCell22.CellWidth = 57;
            this.xEditGridCell22.Col = 17;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell22.HeaderText = "17";
            this.xEditGridCell22.Row = 1;
            this.xEditGridCell22.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell22.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell22.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell23.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell23.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell23.CellName = "18";
            this.xEditGridCell23.CellWidth = 57;
            this.xEditGridCell23.Col = 18;
            this.xEditGridCell23.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell23.HeaderText = "18";
            this.xEditGridCell23.Row = 1;
            this.xEditGridCell23.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell23.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell23.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell24.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell24.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell24.CellName = "19";
            this.xEditGridCell24.CellWidth = 57;
            this.xEditGridCell24.Col = 19;
            this.xEditGridCell24.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell24.HeaderText = "19";
            this.xEditGridCell24.Row = 1;
            this.xEditGridCell24.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell24.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell24.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell24.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell25.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell25.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell25.CellName = "20";
            this.xEditGridCell25.CellWidth = 57;
            this.xEditGridCell25.Col = 20;
            this.xEditGridCell25.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell25.HeaderText = "20";
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell25.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell25.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell26.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell26.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell26.CellName = "21";
            this.xEditGridCell26.CellWidth = 57;
            this.xEditGridCell26.Col = 21;
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell26.HeaderText = "21";
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell26.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell26.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell26.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell27.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell27.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell27.CellName = "22";
            this.xEditGridCell27.CellWidth = 57;
            this.xEditGridCell27.Col = 22;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell27.HeaderText = "22";
            this.xEditGridCell27.Row = 1;
            this.xEditGridCell27.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell27.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell27.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell27.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell28.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell28.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell28.CellName = "23";
            this.xEditGridCell28.CellWidth = 57;
            this.xEditGridCell28.Col = 23;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell28.HeaderText = "23";
            this.xEditGridCell28.Row = 1;
            this.xEditGridCell28.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell28.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell28.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell28.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell29.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell29.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell29.CellName = "24";
            this.xEditGridCell29.CellWidth = 57;
            this.xEditGridCell29.Col = 24;
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell29.HeaderText = "24";
            this.xEditGridCell29.Row = 1;
            this.xEditGridCell29.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell29.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell29.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell29.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell30.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell30.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell30.CellName = "25";
            this.xEditGridCell30.CellWidth = 57;
            this.xEditGridCell30.Col = 25;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell30.HeaderText = "25";
            this.xEditGridCell30.Row = 1;
            this.xEditGridCell30.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell30.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell30.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell30.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell31.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell31.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell31.CellName = "26";
            this.xEditGridCell31.CellWidth = 57;
            this.xEditGridCell31.Col = 26;
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell31.HeaderText = "26";
            this.xEditGridCell31.Row = 1;
            this.xEditGridCell31.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell31.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell31.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell32.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell32.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell32.CellName = "27";
            this.xEditGridCell32.CellWidth = 57;
            this.xEditGridCell32.Col = 27;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell32.HeaderText = "27";
            this.xEditGridCell32.Row = 1;
            this.xEditGridCell32.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell32.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell32.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell32.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell33.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell33.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell33.CellName = "28";
            this.xEditGridCell33.CellWidth = 57;
            this.xEditGridCell33.Col = 28;
            this.xEditGridCell33.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell33.HeaderText = "28";
            this.xEditGridCell33.Row = 1;
            this.xEditGridCell33.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell33.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell33.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell34.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell34.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell34.CellName = "29";
            this.xEditGridCell34.CellWidth = 57;
            this.xEditGridCell34.Col = 29;
            this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell34.HeaderText = "29";
            this.xEditGridCell34.Row = 1;
            this.xEditGridCell34.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell34.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell34.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell34.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell35.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell35.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell35.CellName = "30";
            this.xEditGridCell35.CellWidth = 57;
            this.xEditGridCell35.Col = 30;
            this.xEditGridCell35.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell35.HeaderText = "30";
            this.xEditGridCell35.Row = 1;
            this.xEditGridCell35.RowBackColor = new IHIS.Framework.XColor(System.Drawing.Color.LightGreen);
            this.xEditGridCell35.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell35.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell35.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.ColSpan = 30;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "病床";
            this.xGridHeader1.HeaderWidth = 57;
            // 
            // layJaewonList
            // 
            this.layJaewonList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10});
            this.layJaewonList.QuerySQL = resources.GetString("layJaewonList.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "ho_dong";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "ho_code";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "bed_no";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "ipwon_date";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "toiwon_res_date";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "toiwon_res_yn";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "sex";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "ipwon_type";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ipwon_type_name";
            // 
            // grdBAS0260
            // 
            this.grdBAS0260.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell36,
            this.xEditGridCell37});
            this.grdBAS0260.ColPerLine = 1;
            this.grdBAS0260.Cols = 1;
            this.grdBAS0260.DefaultHeight = 26;
            this.grdBAS0260.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdBAS0260.FixedRows = 1;
            this.grdBAS0260.HeaderHeights.Add(39);
            this.grdBAS0260.Location = new System.Drawing.Point(4, 4);
            this.grdBAS0260.Name = "grdBAS0260";
            this.grdBAS0260.QuerySQL = resources.GetString("grdBAS0260.QuerySQL");
            this.grdBAS0260.Rows = 2;
            this.grdBAS0260.Size = new System.Drawing.Size(100, 481);
            this.grdBAS0260.TabIndex = 6;
            this.grdBAS0260.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdBAS0260_RowFocusChanged);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "ho_dong";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell36.HeaderText = "病棟";
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "ho_dong_name";
            this.xEditGridCell37.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell37.HeaderText = "病棟";
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // layMaxBedNo
            // 
            this.layMaxBedNo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layMaxBedNo.QuerySQL = "SELECT MAX(A.HO_TOTAL_BED)\r\n  FROM BAS0250 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n" +
                "   AND A.HO_DONG   = :f_ho_dong\r\n   AND TO_DATE(:f_ho_code_ymd, \'YYYY/MM/DD\') BE" +
                "TWEEN A.START_DATE AND A.END_DATE";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "max_bed";
            // 
            // layReserBed
            // 
            this.layReserBed.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem22,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26});
            this.layReserBed.QuerySQL = resources.GetString("layReserBed.QuerySQL");
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "ho_dong";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "ho_code";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "bed_no";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "suname";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "reser_date";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Date;
            // 
            // layBedStatus
            // 
            this.layBedStatus.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem27,
            this.multiLayoutItem28});
            this.layBedStatus.QuerySQL = resources.GetString("layBedStatus.QuerySQL");
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "選択", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(539, 491);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 7;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlHelp
            // 
            this.pnlHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHelp.Controls.Add(this.xPictureBox1);
            this.pnlHelp.Location = new System.Drawing.Point(6, 358);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(268, 126);
            this.pnlHelp.TabIndex = 8;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "ho_dong";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "ho_code";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "bed_no";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "bed_status";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "code_name";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "from_bed_date";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "to_jy_date";
            this.multiLayoutItem28.DataType = IHIS.Framework.DataType.Date;
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(8, 490);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnHelp.Size = new System.Drawing.Size(86, 28);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "ヘルプ";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.BackgroundImage = global::IHIS.BASS.Properties.Resources.범례;
            this.xPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.Size = new System.Drawing.Size(266, 124);
            this.xPictureBox1.TabIndex = 0;
            this.xPictureBox1.TabStop = false;
            // 
            // btnQuery
            // 
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(334, 491);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 30);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "照会";
            this.btnQuery.Click += new System.EventHandler(this.XButton_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(253, 491);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 30);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "選択";
            this.btnSelect.Click += new System.EventHandler(this.XButton_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(415, 491);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.XButton_Click);
            // 
            // BAS0250Q00
            // 
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdHOBED);
            this.Controls.Add(this.grdBAS0260);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Name = "BAS0250Q00";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(707, 525);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0250Q00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdHOBED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJaewonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0260)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserBed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBedStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

        private string mParamHoCodeYMD    = "";
		private string mParamGumjinHoDong = "N";
		private string mParamHoDong       = "";
		private string mParamAcceptUseBed = "";


		private int    mMaxBedCnt = 8;
		private int    mDefaultColSize = 57;

		private string NON_USABLE_BED_STRING = "無";

		/************************************
		 * 환자 성별 표시 
		 * **********************************/
		private XColor mManColor = new XColor(Color.LightBlue);
		private XColor mWomanColor = new XColor(Color.Bisque);
        private XColor mNeutralColor = new XColor(Color.FromArgb(134, 229, 127));

		/************************************
		 * 숙박건진 표시
		 * **********************************/
		private XColor mGunjinColor = new XColor(Color.FromArgb(98,196,172));

		/************************************
		 * 환자 성별 표시 
		 * **********************************/
		private bool isAcceptUseBed = false;

		/************************************
		 * 범례 표시 관련
		 * **********************************/
		private bool mIsShowing = false;
		private bool mIsShown   = false;

		/* 범례 사이즈 */
		private int  MaxHeight  = 107;
		private int  MinHeight  = 0;

		#endregion

		#region Screen Open

		private void BAS0250Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{            
			if (this.OpenParam != null)
			{
				if (this.OpenParam.Contains("ipwon_date"))
				{
					this.mParamHoCodeYMD = this.OpenParam["ipwon_date"].ToString();
				}
				else
				{
					this.mParamHoCodeYMD = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
				}

				if (this.OpenParam.Contains("gumjin_hodong"))
				{
					this.mParamGumjinHoDong = this.OpenParam["gumjin_hodong"].ToString();
				}

				if (this.OpenParam.Contains("ho_dong"))
				{
					this.mParamHoDong = this.OpenParam["ho_dong"].ToString();
				}

				if (this.OpenParam.Contains("accept_use_bed"))
				{
					this.isAcceptUseBed = (this.OpenParam["accept_use_bed"].ToString() == "Y" ? true : false);
				}
				
			}

			else
			{
				this.mParamHoCodeYMD = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
			}

			// 병동 서비스 콜
			this.LoadHoDong();
            
			// 병동이 파라미터로 넘어온 경우 해당병동을 
			// 선택한다.
			if (this.mParamHoDong != "")
			{
				this.SelectHoDong(this.mParamHoDong);
			}

			/**************************
			 * 범례 관련 초기화 작업
			 * ************************/
			this.InitHelpPicture();

		}

		#endregion

		#region DataLoad

		private void LoadHoDong ()
        {
            this.grdBAS0260.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdBAS0260.SetBindVarValue("f_gumjin_hodong", this.mParamGumjinHoDong);
            this.grdBAS0260.SetBindVarValue("f_buseo_ymd", this.mParamHoCodeYMD);

            this.grdBAS0260.QueryLayout(false);
		}

		private void LoadMaxTotalBed()
		{
            // Max Total Bed를 가져오는 서비스 셋팅
            this.layMaxBedNo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layMaxBedNo.SetBindVarValue("f_ho_dong", this.grdBAS0260.GetItemString(this.grdBAS0260.CurrentRowNumber, "ho_dong"));
            this.layMaxBedNo.SetBindVarValue("f_ho_code_ymd", this.mParamHoCodeYMD);

            this.layMaxBedNo.QueryLayout();
		}

		private void LoadHoCode ()
		{
            // 병실 서비스 셋팅
            this.grdHOBED.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHOBED.SetBindVarValue("f_ho_dong", this.grdBAS0260.GetItemString(grdBAS0260.CurrentRowNumber, "ho_dong"));
            this.grdHOBED.SetBindVarValue("f_ho_code_ymd", this.mParamHoCodeYMD);
            this.grdHOBED.SetBindVarValue("f_gumjin_hodong_yn", this.mParamGumjinHoDong);

            this.grdHOBED.QueryLayout(true) ;
		}

		private void LoadHoStatus ()
		{
            // BED STATUS를 가져오는 서비스 셋팅
            this.layBedStatus.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layBedStatus.SetBindVarValue("f_ho_dong", this.grdBAS0260.GetItemString(grdBAS0260.CurrentRowNumber, "ho_dong"));
            this.layBedStatus.SetBindVarValue("f_ho_code_ymd", this.mParamHoCodeYMD);

            this.layBedStatus.QueryLayout(true) ;
		}

		private void LoadJaewonList ()
        {
            this.layJaewonList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layJaewonList.SetBindVarValue("f_ho_dong", this.grdBAS0260.GetItemString(grdBAS0260.CurrentRowNumber, "ho_dong"));

			this.layJaewonList.QueryLayout(true);
		}

		private void LoadReserBed ()
        {
            this.layReserBed.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layReserBed.SetBindVarValue("f_ho_dong", this.grdBAS0260.GetItemString(grdBAS0260.CurrentRowNumber, "ho_dong"));

            this.layReserBed.QueryLayout(true);
		}

		#endregion

		#region XButton

		private void btnHelp_Click(object sender, System.EventArgs e)
		{
			if (this.mIsShown)
			{
				this.pnlHelp.Size = new Size(this.pnlHelp.Width, MinHeight);

				this.pnlHelp.Visible = false;

				this.mIsShown = false;
			}
			else
			{
				this.pnlHelp.Size = new Size(this.pnlHelp.Width, MaxHeight);

				this.pnlHelp.Visible = true;

				this.mIsShown = true;
			}
		}

		private void XButton_Click(object sender, System.EventArgs e)
		{
			XButton control = sender as XButton;



			switch (control.Name)
			{
				case "btnClose":

					this.Close();

					break;
				case "btnSelect":

					if (grdHOBED.CurrentRowNumber >= 0 &&
						this.grdHOBED.Selection.Count > 0)
					{
						this.InvokeCommand(this.grdHOBED.CurrentRowNumber, this.grdHOBED.Selection[0]);
					}

					this.Close();

					break;
				case "btnQuery":

					this.LoadHoDong();

					break;
			}
		}

		#endregion

		#region Grid Mouse Down

		private void grdHOBED_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowNum = 0;

			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				rowNum = this.grdHOBED.GetHitRowNumber(e.Y);
				XCell cell = this.grdHOBED.CellAtPoint(new Point(e.X, e.Y));

				if (rowNum < 0) return;

				if (!TypeCheck.IsInt(cell.CellName))
				{
					return;
				}

				if (this.grdHOBED.GetItemString(rowNum, cell.CellName) != "" )
				{
					// 없는 베드 클릭시
					if (this.grdHOBED.GetItemString(rowNum, cell.CellName) == NON_USABLE_BED_STRING)
					{
						return;
					}

					// 사용중인 베드 클릭시
					if (this.grdHOBED.GetItemString(rowNum, cell.CellName).Substring(0,1) == "[" &&
						this.isAcceptUseBed == false )
					{
						return;
					}
				}

				this.InvokeCommand(rowNum, cell);

				this.Close();

			}
		}

		#endregion

		#region InvokeCommand

		private void InvokeCommand(int rowNum, XCell cell)
		{
			CommonItemCollection param = new CommonItemCollection();

			param.Add("ho_dong",   this.grdHOBED.GetItemString(rowNum, "ho_dong"));
			param.Add("ho_code",   this.grdHOBED.GetItemString(rowNum, "ho_code"));
			param.Add("bed_no",    cell.CellName.Substring(cell.CellName.Length-2, 2));
			param.Add("ho_grade",  this.grdHOBED.GetItemString(rowNum, "ho_grade"));
			param.Add("ho_status", this.grdHOBED.GetItemString(rowNum, "ho_status"));

				
			((XScreen)(this.Opener)).Command("BAS0250Q00", param);
		}

		#endregion

		#region ResetColumnHeaderSize

		private void ResetColumnHeaderSize()
		{
			for(int i=1; i<this.grdHOBED.Cols; i++)
			{
				this.grdHOBED.AutoSizeColumn(i, this.mDefaultColSize);
			}
		}

		#endregion

		#region 파라미터 병동 셀렉트

		private void SelectHoDong(string aHoDong)
		{
			if (aHoDong == "")
				return;

			for (int i= 0; i<this.grdBAS0260.RowCount; i++)
			{
				if (this.grdBAS0260.GetItemString(i, "ho_dong") == aHoDong)
				{
					this.grdBAS0260.SetFocusToItem(i, "ho_dong_name", false);
					break;
				}
			}
		}

		#endregion

		#region Grid RowFocusChanged

		private void grdBAS0260_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			this.ResetColumnHeaderSize();

			this.ReSizeGridColumn();

			this.LoadHoCode();

			this.MarkNonUsedBed();

			if (this.grdHOBED.RowCount > 0)
			{
				// 예약중인 베드 표시
				this.LoadReserBed();

				this.DisplayReserBed();

				// 청소중인 베드 표시
				this.LoadHoStatus();

				this.DisplayBedStatus();

				// 입원 혹은 퇴원예약중인 베드 표시
				this.LoadJaewonList();

				this.DisplayIpwonBed();
			}

			this.grdHOBED.ResetUpdate();
		}

		#endregion

		#region Function

		/// <summary>
		/// 범례 이미지 초기화
		/// </summary>
		private void InitHelpPicture()
		{
			this.mIsShowing = false;
			this.mIsShown = false;

			this.pnlHelp.Size = new Size(this.pnlHelp.Size.Width, MinHeight);
		}

		/// <summary>
		/// 베드 그리드의 컬럼의 갯수를 조정한다.
		/// </summary>
		private void ReSizeGridColumn()
		{
			int maxBed = 0;

			this.LoadMaxTotalBed();

			if (TypeCheck.IsInt(this.layMaxBedNo.GetItemValue("max_bed").ToString()))
			{
                maxBed = int.Parse(this.layMaxBedNo.GetItemValue("max_bed").ToString());

				if (maxBed < 8)
				{
					maxBed = 8;
					this.mMaxBedCnt = maxBed;
				}
				else
				{
					this.mMaxBedCnt = maxBed;
				}
					
				for (int i=maxBed+1; i<this.grdHOBED.Cols; i++)
				{
					this.grdHOBED.AutoSizeColumn(i,0);
				}
			}
		}

		/// <summary>
		/// 사용하지 않거나 없는 베드에 대하여 그리드의 배경색을 변경한다.
		/// </summary>
		private void MarkNonUsedBed()
		{
			string ext = "";

			XCell cell = null;

			for (int rowNumber = 0; rowNumber < this.grdHOBED.RowCount; rowNumber++)
			{
				int ho_bed_cnt = this.grdHOBED.GetItemInt(rowNumber, "ho_total_bed");

				for (int i=ho_bed_cnt; i<mMaxBedCnt; i++)
				{
					cell = this.grdHOBED[rowNumber+grdHOBED.HeaderHeights.Count, i+1];
					cell.BackColor = XColor.XDisplayBoxGradientEndColor;
					//cell.Image = ImageList.Images[1];
					if (i<10)
					{
						ext = "0";
					}
					this.grdHOBED.SetItemValue(rowNumber, cell.CellName, NON_USABLE_BED_STRING);
				}
			}

			this.grdHOBED.AcceptData();
		}

		/// <summary>
		/// 예약중인 베드를 그리드 상에 표시
		/// </summary>
		private void DisplayReserBed()
		{
			string text = "";

			foreach (DataRow dr in this.layReserBed.LayoutTable.Rows)
			{
				int rowNum = GetRowNumbyHoCode(dr["ho_code"].ToString());
				XCell cell = GetCell(rowNum, dr["bed_no"].ToString());

				if (cell != null)
				{
					text = this.grdHOBED.GetItemString(rowNum, cell.CellName);

					if (text != "")
					{
                        text += "\n";
					}

					text += dr["suname"].ToString() + "[ " + dr["reser_date"].ToString() + " ]";
					cell.Image = ImageList.Images[3];
					this.grdHOBED.SetItemValue(rowNum, cell.CellName, text);
				}
			}
		}

		/// <summary>
		/// 베드의 상태를 그리드 상에 표시
		/// </summary>
		private void DisplayBedStatus()
		{
			string text = "";

			foreach (DataRow dr in this.layBedStatus.LayoutTable.Rows)
			{
				int rowNum = GetRowNumbyHoCode(dr["ho_code"].ToString());
				XCell cell = GetCell(rowNum, dr["bed_no"].ToString());

				if (cell != null)
				{
					if (dr["bed_status"].ToString() == "05")   // 사용안함 코드
					{
                        text = "[ " + dr["code_name"].ToString() + " ]";
                        cell.Image = ImageList.Images[5];
						this.grdHOBED.SetItemValue(rowNum, cell.CellName, text);

					}
					else
					{
                        text = "[ " + dr["code_name"].ToString() + " ]";
						cell.Image = ImageList.Images[4];
						this.grdHOBED.SetItemValue(rowNum, cell.CellName, text);
					}
				}
			}
		}

		/// <summary>
		/// inp1001을 검색하여 입원중 혹은 퇴원예정인 베드에 대하여 정보를 가져온다.
		/// </summary>
		private void DisplayIpwonBed()
		{
			string text = "";

			foreach (DataRow dr in this.layJaewonList.LayoutTable.Rows)
			{
				int rowNum = GetRowNumbyHoCode(dr["ho_code"].ToString());
				XCell cell = GetCell(rowNum, dr["bed_no"].ToString());

				if (cell != null)
				{
					/**************************************
					 * 숙박건진 : LIght Green 으로 표시
					 * ************************************/
					if (dr["ipwon_type"].ToString() == "5")  // 숙박건진 색
					{
						text = "[ 入 院 中 ]" + "\n" + 
							   "氏    名 : " + dr["suname"].ToString() + "\n" + 
							   "入院類型 : " + dr["ipwon_type_name"].ToString();
						cell.Image = ImageList.Images[0];

                        cell.BackColor = this.mGunjinColor;

						this.grdHOBED.SetItemValue(rowNum, cell.CellName, text);
					}
					/**************************************
					* 일반입원 : 남자 여자 다른색으로 표시 
					* ************************************/
					else // 일반 입원환자
					{
						if (dr["toiwon_res_yn"].ToString() == "Y")
						{
							text = "[ 入 院 中 ]" + "\n" + 
								   "氏    名 : " + dr["suname"].ToString() + "\n" +
								   "退院予定 : " + dr["toiwon_res_date"].ToString() + "\n" +
								   "入院類型 : " + dr["ipwon_type_name"].ToString();
							cell.Image = ImageList.Images[2];
						
							if (dr["sex"].ToString() == "M") // 남자 인경우
							{
                                cell.BackColor = this.mManColor;
							}
							else // 여자 인경우
							{
                                cell.BackColor = this.mWomanColor;
							}

							this.grdHOBED.SetItemValue(rowNum, cell.CellName, text);
						}
						else
						{
							text = "[ 入 院 中 ]" + "\n" + 
								   "氏    名 : " + dr["suname"].ToString() + "\n" + 
							   	   "入院類型 : " + dr["ipwon_type_name"].ToString();
							cell.Image = ImageList.Images[0];

							if (dr["sex"].ToString() == "M") // 남자 인경우
							{
                                cell.BackColor = this.mManColor;
							}
                            else// 여자 인경우
                            {
                                cell.BackColor = this.mWomanColor;
                            }

							this.grdHOBED.SetItemValue(rowNum, cell.CellName, text);
						}
					}
				}

			}

			this.grdHOBED.LayoutTable.AcceptChanges();
		}


		/// <summary>
		/// 병실코드를 입력받아 베드 그리드의 로우넘버를 리턴
		/// </summary>
		/// <param name="aHoCode"></param>
		/// <returns></returns>
		private int GetRowNumbyHoCode(string aHoCode)
		{
			for (int i = 0; i<this.grdHOBED.RowCount; i++)
			{
				if (this.grdHOBED.GetItemString(i, "ho_code") == aHoCode)
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// 로우넘버와 베드넘버를 입력받아 해당 셀을 리턴
		/// </summary>
		/// <param name="rowNum"></param>
		/// <param name="aBedNo"></param>
		/// <returns></returns>
		private XCell GetCell(int rowNum, string aBedNo)
		{
			if (TypeCheck.IsInt(aBedNo) && rowNum >= 0)
			{
				return this.grdHOBED[rowNum, aBedNo];
			}

			return null;
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:

					// 조회된 건이 없다면 리턴..
					if (this.grdHOBED.CurrentRowNumber < 0)
					{
						return ;
					}

					if (this.grdHOBED.GetItemString(this.grdHOBED.CurrentRowNumber, this.grdHOBED.CurrentColName) != "" )
					{
						// 없는 베드 클릭시
						if (this.grdHOBED.GetItemString(grdHOBED.CurrentRowNumber, grdHOBED.CurrentColName) == NON_USABLE_BED_STRING)
						{
							return;
						}

						// 사용중인 베드 클릭시
						if (this.grdHOBED.GetItemString(grdHOBED.CurrentRowNumber, grdHOBED.CurrentColName).Substring(0,1) == "[" &&
							this.isAcceptUseBed == false )
						{
							return;
						}
					}

					
					this.InvokeCommand(this.grdHOBED.CurrentRowNumber, this.grdHOBED[this.grdHOBED.CurrentRowNumber,this.grdHOBED.CurrentColName]);

					this.Close();

					break;
			}
		}

		#endregion
	}
}

