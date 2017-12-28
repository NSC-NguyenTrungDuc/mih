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
	/// NUR2017Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR2017Q00 : IHIS.Framework.XScreen
	{
		#region 화면변수
		private string order_date       = string.Empty;
		private string pkocs2003        = string.Empty;
		private string user_id          = string.Empty;
		private string order_gubun      = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdNUR2017;
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
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell29;
		private System.Windows.Forms.ImageList imageListMixGroup;
		private IHIS.Framework.XLabel lblOrder_date;
		private IHIS.Framework.XDatePicker dtpOrder_date;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.XGridHeader xGridHeader1;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
		private IHIS.Framework.XEditGridCell xEditGridCell32;
		private IHIS.Framework.XEditGridCell xEditGridCell33;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XLabel lblBunho;
		private System.ComponentModel.IContainer components;
		#endregion

		#region 생성자
        public NUR2017Q00()
		{
            try
            {
                // 이 호출은 Windows Form 디자이너에 필요합니다.
                InitializeComponent();
            }
            catch(Exception x)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.Data + " --- " + x.Message + "---" + x.StackTrace + "---" + x.Source);
            }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR2017Q00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblBunho = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.dtpOrder_date = new IHIS.Framework.XDatePicker();
            this.lblOrder_date = new IHIS.Framework.XLabel();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNUR2017 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR2017)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBunho);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.dtpOrder_date);
            this.pnlTop.Controls.Add(this.lblOrder_date);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1138, 31);
            this.pnlTop.TabIndex = 0;
            // 
            // lblBunho
            // 
            this.lblBunho.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblBunho.EdgeRounding = false;
            this.lblBunho.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblBunho.Location = new System.Drawing.Point(219, 5);
            this.lblBunho.Name = "lblBunho";
            this.lblBunho.Size = new System.Drawing.Size(100, 20);
            this.lblBunho.TabIndex = 27;
            this.lblBunho.Text = "患者番号";
            this.lblBunho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.paBox.Location = new System.Drawing.Point(249, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(889, 31);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // dtpOrder_date
            // 
            this.dtpOrder_date.IsJapanYearType = true;
            this.dtpOrder_date.Location = new System.Drawing.Point(104, 5);
            this.dtpOrder_date.Name = "dtpOrder_date";
            this.dtpOrder_date.Size = new System.Drawing.Size(112, 20);
            this.dtpOrder_date.TabIndex = 26;
            this.dtpOrder_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpOrder_date_DataValidating);
            // 
            // lblOrder_date
            // 
            this.lblOrder_date.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblOrder_date.EdgeRounding = false;
            this.lblOrder_date.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblOrder_date.Location = new System.Drawing.Point(4, 5);
            this.lblOrder_date.Name = "lblOrder_date";
            this.lblOrder_date.Size = new System.Drawing.Size(100, 20);
            this.lblOrder_date.TabIndex = 25;
            this.lblOrder_date.Text = "オーダ日付";
            this.lblOrder_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 555);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1138, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Location = new System.Drawing.Point(894, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNUR2017
            // 
            this.grdNUR2017.AddedHeaderLine = 1;
            this.grdNUR2017.ApplyPaintEventToAllColumn = true;
            this.grdNUR2017.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell34,
            this.xEditGridCell35});
            this.grdNUR2017.ColPerLine = 19;
            this.grdNUR2017.Cols = 20;
            this.grdNUR2017.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR2017.FixedCols = 1;
            this.grdNUR2017.FixedRows = 2;
            this.grdNUR2017.HeaderHeights.Add(36);
            this.grdNUR2017.HeaderHeights.Add(0);
            this.grdNUR2017.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2});
            this.grdNUR2017.Location = new System.Drawing.Point(0, 31);
            this.grdNUR2017.Name = "grdNUR2017";
            this.grdNUR2017.QuerySQL = resources.GetString("grdNUR2017.QuerySQL");
            this.grdNUR2017.ReadOnly = true;
            this.grdNUR2017.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdNUR2017.RowHeaderVisible = true;
            this.grdNUR2017.Rows = 3;
            this.grdNUR2017.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR2017.Size = new System.Drawing.Size(1138, 524);
            this.grdNUR2017.TabIndex = 2;
            this.grdNUR2017.ToolTipActive = true;
            this.grdNUR2017.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR2017_QueryEnd);
            this.grdNUR2017.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR2017_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_code1";
            this.xEditGridCell1.CellWidth = 35;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "病室";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "bunho";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "suname";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa_name";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "診療科";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "hangmog_code";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "項目コード";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "hangmog_name";
            this.xEditGridCell6.CellWidth = 200;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "項目名";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "suryang";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell7.CellWidth = 35;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "数量";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ord_danui";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "単位";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "dv_time";
            this.xEditGridCell9.CellWidth = 17;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "dv_time";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "dv";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.CellWidth = 18;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "dv";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.Row = 1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "jusa";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "注射";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "bogyong_code";
            this.xEditGridCell12.CellWidth = 50;
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "速度";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.RowSpan = 2;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "acting_date";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell13.CellWidth = 90;
            this.xEditGridCell13.Col = 13;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "acting_date";
            this.xEditGridCell13.IsJapanYearType = true;
            this.xEditGridCell13.Row = 1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "acting_time";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell14.CellWidth = 40;
            this.xEditGridCell14.Col = 14;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "acting_time";
            this.xEditGridCell14.Mask = "HH:MI";
            this.xEditGridCell14.Row = 1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "act_user";
            this.xEditGridCell15.CellWidth = 53;
            this.xEditGridCell15.Col = 15;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "act_user";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.Row = 1;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "acting_yn";
            this.xEditGridCell16.CellWidth = 20;
            this.xEditGridCell16.Col = 17;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "確認";
            this.xEditGridCell16.Row = 1;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "fkocs2003";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.HeaderText = "fkocs2003";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "seq";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "seq";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "order_date";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell19.CellWidth = 90;
            this.xEditGridCell19.Col = 4;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "オーダ日";
            this.xEditGridCell19.IsJapanYearType = true;
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.RowSpan = 2;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "bogyong_name";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "bogyong_name";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "dc_yn";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "dc_yn";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "group_ser";
            this.xEditGridCell22.CellWidth = 30;
            this.xEditGridCell22.Col = 2;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell22.HeaderText = "GR";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.RowSpan = 2;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "mix_group";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "mix_group";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "hope_date";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "hope_date";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "jusa_text";
            this.xEditGridCell25.CellWidth = 90;
            this.xEditGridCell25.Col = 10;
            this.xEditGridCell25.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell25.HeaderText = "注射";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.RowSpan = 2;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "danui_text";
            this.xEditGridCell26.CellWidth = 30;
            this.xEditGridCell26.Col = 7;
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell26.HeaderText = "単位";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.RowSpan = 2;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 2000;
            this.xEditGridCell27.CellName = "order_remark";
            this.xEditGridCell27.CellWidth = 64;
            this.xEditGridCell27.Col = 18;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell27.HeaderText = "コメント";
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.RowSpan = 2;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellLen = 2000;
            this.xEditGridCell28.CellName = "nurse_remark";
            this.xEditGridCell28.CellWidth = 64;
            this.xEditGridCell28.Col = 19;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell28.HeaderText = "看護コメント";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.RowSpan = 2;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "input_gubun_text";
            this.xEditGridCell29.CellWidth = 30;
            this.xEditGridCell29.Col = 1;
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell29.HeaderText = "区分";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.IsUpdCol = false;
            this.xEditGridCell29.RowSpan = 2;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "jusa_spd_gubun";
            this.xEditGridCell30.CellWidth = 40;
            this.xEditGridCell30.Col = 12;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell30.HeaderText = "ml\r\nhr";
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.IsUpdCol = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell30.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM OCS0132\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'JUSA_SPD_GUBUN\'\r\n ORDER BY 1\r\n";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "act_user_name";
            this.xEditGridCell31.CellWidth = 110;
            this.xEditGridCell31.Col = 16;
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell31.HeaderText = "act_user_name";
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.Row = 1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "bannab_yn";
            this.xEditGridCell32.CellWidth = 30;
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell32.HeaderText = "返納";
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "bannab_fkocs2003";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "old_bannab_yn";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.HeaderText = "old_bannab_yn";
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "drug_bannab_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.HeaderText = "drug_bannab_yn";
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 8;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 17;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 13;
            this.xGridHeader2.ColSpan = 5;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "確認内訳";
            this.xGridHeader2.HeaderWidth = 90;
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListMixGroup.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // NUR2017Q00
            // 
            this.Controls.Add(this.grdNUR2017);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR2017Q00";
            this.Size = new System.Drawing.Size(1138, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR2017Q00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR2017)).EndInit();
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
				case "user_id":
					msg = NetInfo.Language == LangMode.Ko ? "간호확인 ID가 정확하지 않습니다. 확인해 주세요."
						: "看護確認IDが有効ではありません。ご確認ください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "Infomation";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nurse_confirm_enable":
					msg = NetInfo.Language == LangMode.Ko ? "오더확인권한이 없습니다. 확인바랍니다."
						: "オーダ確認権限がありません。ご確認ください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "Infomation";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bannab_yn":
					msg = NetInfo.Language == LangMode.Ko ? "해당 오다는 반납처리를 할 수 없는 오다입니다."
						: "該当オーダは返却処理不可能なオーダです。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "Infomation";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bannab_true":
					msg = NetInfo.Language == LangMode.Ko ? "처리가 완료되었습니다."
						: "処理が完了しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "Infomation";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load
		private void NUR2017Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			this.CurrMQLayout = this.grdNUR2017;

            this.dtpOrder_date.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.dtpOrder_date.AcceptData();

			this.order_date = this.dtpOrder_date.GetDataValue().ToString();

			if (e.OpenParam != null)
			{
				if (e.OpenParam.Contains("order_date") && e.OpenParam["order_date"] != null)
				{
					this.order_date = this.OpenParam["order_date"].ToString();
					this.dtpOrder_date.SetEditValue(this.OpenParam["order_date"].ToString());
					this.dtpOrder_date.AcceptData();
				}

				if (e.OpenParam.Contains("pkocs2003") && e.OpenParam["pkocs2003"] != null)
				{
					this.pkocs2003  = this.OpenParam["pkocs2003"].ToString();
				}

				if (e.OpenParam.Contains("user_id") && e.OpenParam["user_id"] != null)
				{
					this.user_id    = this.OpenParam["user_id"].ToString();
				}

				if (e.OpenParam.Contains("order_gubun") && e.OpenParam["order_gubun"] != null)
				{
					this.order_gubun  = this.OpenParam["order_gubun"].ToString();
				}

				if (e.OpenParam.Contains("bunho") && e.OpenParam["bunho"] != null)
				{
					this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
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

		#region DC여부를 표현
		private void grdNUR2017_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if (e.DataRow["old_bannab_yn"].ToString() == "Y")
			{	
				e.DrawMiddleLine = true;
				e.MiddleLineColor = Color.Red;
			}

			if (e.DataRow["drug_bannab_yn"].ToString() == "Y")
			{	
				e.DrawMiddleLine = true;
				e.MiddleLineColor = Color.Red;
				e.BackColor = Color.MistyRose;
			}
	
		}
		#endregion

		#region 복용법명칭 Tooltip처리
		private void grdNUR2017_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.grdNUR2017.RowCount <= 0) return;

			XCell ac = this.grdNUR2017.CellAtPoint(new Point(e.X,e.Y));

			if (ac == null) return;

			if (ac.CellName == "bogyong_code")
				ac.ToolTipText = this.grdNUR2017.GetItemString(ac.Row-2,"bogyong_name").ToString();
		}
		#endregion

		#region Mix Group 데이타 Image Display (DiaplayMixGroup)
		/// <summary>
		/// Mix Group 데이타 Image Display
		/// </summary>
		/// <param name="aGrd"> XEditGrid </param>
		/// <returns> void  </returns>
		private void DiaplayMixGroup(XEditGrid aGrd)
		{
			if (aGrd == null) return;

			try
			{
				//aGrd.Redraw = false; // Grid Display 멈춤

				int imageCnt = 0;

				// 기존 image 클리어
				for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

				for (int i = 0; i < aGrd.RowCount; i++)
				{
					// 이미 이미지 세팅이 안된건에 한해서 작업수행
					if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
					{
						//이미수행한건 빼는로직이 있어야함..
						int count = 0;
						for (int j = i; j < aGrd.RowCount; j++)
						{
							// 동일 group_ser, 동일 mix_group
							if (aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
								aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
								aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
								aGrd.GetItemValue(i, "seq").ToString().Trim() == aGrd.GetItemValue(j, "seq").ToString().Trim())
							{
								count++;
								if (count > 1)
								{
									//      헤더를 빼야 실제 Row
									aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
									aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
								}
							}
						}
						// 현재는 image 갯수만큼 처리
						imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
					}
				}
			}
			finally
			{
				//aGrd.Redraw = true; // Grid Display 
			}

		}
		#endregion

		#region 환자번호가 입력이 됐을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			if(this.paBox.BunHo.ToString() != "")
			{
				/* 조회 */
				this.GetTuyaqkList();
			}
		}
		#endregion

		#region 조회
		private void GetTuyaqkList()
		{
			if(this.paBox.BunHo.ToString() != "")
            {
                this.grdNUR2017.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.grdNUR2017.SetBindVarValue("f_order_date", this.order_date);
                this.grdNUR2017.SetBindVarValue("f_pkocs2003", this.pkocs2003);
                this.grdNUR2017.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());

				if (this.order_gubun == "")
				{
                    this.grdNUR2017.SetBindVarValue("f_order_gubun", "%");
				}
				else
				{
                    this.grdNUR2017.SetBindVarValue("f_order_gubun", this.order_gubun);
				}
				if(this.grdNUR2017.QueryLayout(true))
				{
					this.DiaplayMixGroup(this.grdNUR2017);
				}
				else
				{
					XMessageBox.Show(Service.ErrFullMsg);
					return;
				}
			}
		}
		#endregion

		#region 버튼리스트에서 클릭을 했을 때
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

					/* 조회 */
					this.GetTuyaqkList();
					break;
				default:
					break;
			}
		}
		#endregion
	
		#region 날짜를 변경을 했을 때
		private void dtpOrder_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.order_date = "";
			this.order_date = this.dtpOrder_date.GetDataValue().ToString();

			if(this.paBox.BunHo.ToString() != "")
			{
				/* 조회 */
				this.GetTuyaqkList();
			}
		}
		#endregion

        private void grdNUR2017_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string cmdText = "";
            string tFKOCS2003 =  ""; 

            for(int i = 0 ; i < grdNUR2017.RowCount ; i++)
            {
                tFKOCS2003 = this.grdNUR2017.GetItemString(i, "bannab_fkocs2003");

                /* 약국반납여부를 조회한다. */
                if( tFKOCS2003 != "")
                {
                    cmdText = @"SELECT DECODE(A.ACTING_DATE, NULL, 'N', 'Y') DRUG_BANNAB_YN
                                  FROM OCS2003 A
                                 WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.PKOCS2003 = :f_bannab_fkocs2003";

                    BindVarCollection bc = new BindVarCollection();
                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
                    bc.Add("f_bannab_fkocs2003", tFKOCS2003);

                    object drug_bannab_yn = Service.ExecuteScalar(cmdText, bc);
                    if(!TypeCheck.IsNull(drug_bannab_yn))
                    {
                        this.grdNUR2017.SetItemValue(i, "drug_bannab_yn",drug_bannab_yn.ToString());
                    }

                }
            }
            this.grdNUR2017.ResetUpdate();

//        /* 간호사반납여부를 확인한다. */
//        lprintf("sqlca.sqlcode 2 = %d\n", sqlca.sqlcode);
//        memset(o_order_bannab_yn, 0x00, sizeof(o_order_bannab_yn));
        
//        if (strcmp(o_old_bannab_yn, "N") == 0)
//        {
//            EXEC SQL
//            SELECT NVL(A.DC_GUBUN,'N')  DC_GUBUN
//               FROM OCS2003 A
//             WHERE A.PKOCS2003 = :o_fkocs2003
//               AND NOT EXISTS (SELECT 'Y'
//                                 FROM OCS2017 B
//                                WHERE B.FKOCS2003 = :o_fkocs2003
//                                  AND B.SEQ       = :o_seq
//                                  AND B.BANNAB_YN = 'Y'    );
             
//            lprintf("sqlca.sqlcode 2 = %d\n", sqlca.sqlcode);
            
//            if (sqlca.sqlcode != 0 && sqlca.sqlcode != EXC_NO_DATA_FOUND && sqlca.sqlcode != EXC_COLUMN_NULL)
//            {
//                EXEC SQL CLOSE NUR2017U00_GetTuyakList;
//                return (SqlErr(MessageOut,NULL, 0));
//            }
            
//            if (sqlca.sqlcode == EXC_NO_DATA_FOUND)
//            {
//                strcpy(o_order_bannab_yn, "N");
//            }
//        }
        
        }
	}
}

