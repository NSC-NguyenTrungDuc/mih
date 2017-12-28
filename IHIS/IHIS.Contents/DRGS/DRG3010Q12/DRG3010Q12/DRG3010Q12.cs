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
using IHIS.DRGS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG3010Q12에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG3010Q12 : IHIS.Framework.XScreen
	{
		#region 화면변수
        private int DayCounts = 0;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdDrgHistory;
        private System.Windows.Forms.ImageList imageListMixGroup;
        private SingleLayout layCommon;
        private XLabel lblHo_dong;
        private XEditGrid grdPalist;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XMonthBox mbxMonth;
        private XLabel xLabel2;
        private XLabel xLabel1;
        private XDictComboBox cboBuseo;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XGridHeader xGridHeader1;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
   //     private XDataWindow dwWindow;
        private XButton btnAntibiotic;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
		private System.ComponentModel.IContainer components;
		#endregion

		#region 생성자
		public DRG3010Q12()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010Q12));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cboBuseo = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.mbxMonth = new IHIS.Framework.XMonthBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnAntibiotic = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdDrgHistory = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.grdPalist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrgHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "앞으로.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cboBuseo);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.mbxMonth);
            this.pnlTop.Controls.Add(this.paBox);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // cboBuseo
            // 
            this.cboBuseo.ExecuteQuery = null;
            resources.ApplyResources(this.cboBuseo, "cboBuseo");
            this.cboBuseo.Name = "cboBuseo";
            this.cboBuseo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBuseo.ParamList")));
            this.cboBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboBuseo.UserSQL = resources.GetString("cboBuseo.UserSQL");
            this.cboBuseo.SelectionChangeCommitted += new System.EventHandler(this.cboBuseo_SelectionChangeCommitted);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // mbxMonth
            // 
            resources.ApplyResources(this.mbxMonth, "mbxMonth");
            this.mbxMonth.IsVietnameseYearType = false;
            this.mbxMonth.Name = "mbxMonth";
            this.mbxMonth.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.mbxMonth_NextButtonClick);
            this.mbxMonth.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.mbxMonth_PrevButtonClick);
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAntibiotic);
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnAntibiotic
            // 
            resources.ApplyResources(this.btnAntibiotic, "btnAntibiotic");
            this.btnAntibiotic.Image = ((System.Drawing.Image)(resources.GetObject("btnAntibiotic.Image")));
            this.btnAntibiotic.Name = "btnAntibiotic";
            this.btnAntibiotic.Click += new System.EventHandler(this.btnAntibiotic_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdDrgHistory
            // 
            this.grdDrgHistory.AddedHeaderLine = 1;
            this.grdDrgHistory.ApplyPaintEventToAllColumn = true;
            this.grdDrgHistory.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell20,
            this.xEditGridCell19});
            this.grdDrgHistory.ColPerLine = 10;
            this.grdDrgHistory.Cols = 11;
            resources.ApplyResources(this.grdDrgHistory, "grdDrgHistory");
            this.grdDrgHistory.ExecuteQuery = null;
            this.grdDrgHistory.FixedCols = 1;
            this.grdDrgHistory.FixedRows = 2;
            this.grdDrgHistory.HeaderHeights.Add(20);
            this.grdDrgHistory.HeaderHeights.Add(16);
            this.grdDrgHistory.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdDrgHistory.Name = "grdDrgHistory";
            this.grdDrgHistory.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrgHistory.ParamList")));
            this.grdDrgHistory.QuerySQL = resources.GetString("grdDrgHistory.QuerySQL");
            this.grdDrgHistory.ReadOnly = true;
            this.grdDrgHistory.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdDrgHistory.RowHeaderVisible = true;
            this.grdDrgHistory.Rows = 3;
            this.grdDrgHistory.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdDrgHistory.ToolTipActive = true;
            this.grdDrgHistory.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdDrgHistory_GridCellPainting);
            this.grdDrgHistory.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrgHistory_QueryStarting);
            this.grdDrgHistory.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdDrgHistory_QueryEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gubun";
            this.xEditGridCell1.CellWidth = 70;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "order_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowSpan = 2;
            this.xEditGridCell2.SuppressRepeating = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "group_ser";
            this.xEditGridCell3.CellWidth = 25;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell3.SuppressRepeating = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 50;
            this.xEditGridCell4.CellName = "hangmog_name";
            this.xEditGridCell4.CellWidth = 239;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "suryang";
            this.xEditGridCell5.CellWidth = 30;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.RowSpan = 2;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "nalsu";
            this.xEditGridCell6.CellWidth = 48;
            this.xEditGridCell6.Col = 8;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.RowSpan = 2;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "danui";
            this.xEditGridCell7.CellWidth = 65;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 30;
            this.xEditGridCell8.CellName = "bogyong_name";
            this.xEditGridCell8.CellWidth = 109;
            this.xEditGridCell8.Col = 9;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "bunho";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "doctor";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellLen = 30;
            this.xEditGridCell11.CellName = "doctor_name";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 30;
            this.xEditGridCell12.CellName = "suname";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "gwa";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "yyyymm";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "donbok_yn";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "in_out";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "mix_group";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "ho_code";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "dv_time";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xEditGridCell22.CellName = "dv";
            this.xEditGridCell22.CellWidth = 47;
            this.xEditGridCell22.Col = 7;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.RowSpan = 2;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "antibiotic_yn";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "cont_key";
            this.xEditGridCell19.CellWidth = 14;
            this.xEditGridCell19.Col = 10;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 10;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 14;
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            resources.ApplyResources(this.lblHo_dong, "lblHo_dong");
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Name = "lblHo_dong";
            // 
            // grdPalist
            // 
            this.grdPalist.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell50,
            this.xEditGridCell41,
            this.xEditGridCell51,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49});
            this.grdPalist.ColPerLine = 8;
            this.grdPalist.Cols = 8;
            resources.ApplyResources(this.grdPalist, "grdPalist");
            this.grdPalist.ExecuteQuery = null;
            this.grdPalist.FixedRows = 1;
            this.grdPalist.HeaderHeights.Add(23);
            this.grdPalist.Name = "grdPalist";
            this.grdPalist.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPalist.ParamList")));
            this.grdPalist.QuerySQL = resources.GetString("grdPalist.QuerySQL");
            this.grdPalist.ReadOnly = true;
            this.grdPalist.Rows = 2;
            this.grdPalist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPalist_QueryStarting);
            this.grdPalist.Click += new System.EventHandler(this.grdPalist_Click);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "ho_dong";
            this.xEditGridCell50.Col = 6;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 4;
            this.xEditGridCell41.CellName = "ho_code";
            this.xEditGridCell41.CellWidth = 111;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "bed_no";
            this.xEditGridCell51.Col = 7;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellLen = 9;
            this.xEditGridCell44.CellName = "bunho";
            this.xEditGridCell44.CellWidth = 72;
            this.xEditGridCell44.Col = 1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellLen = 30;
            this.xEditGridCell45.CellName = "su_name";
            this.xEditGridCell45.CellWidth = 72;
            this.xEditGridCell45.Col = 2;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "pkinp1001";
            this.xEditGridCell46.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellLen = 20;
            this.xEditGridCell47.CellName = "age_sex";
            this.xEditGridCell47.CellWidth = 40;
            this.xEditGridCell47.Col = 3;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "ipwon_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.CellWidth = 90;
            this.xEditGridCell48.Col = 4;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsJapanYearType = true;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellLen = 30;
            this.xEditGridCell49.CellName = "doctor_name";
            this.xEditGridCell49.CellWidth = 100;
            this.xEditGridCell49.Col = 5;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            // 
            // DRG3010Q12
            // 
            this.Controls.Add(this.lblHo_dong);
            this.Controls.Add(this.grdDrgHistory);
            this.Controls.Add(this.grdPalist);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            resources.ApplyResources(this, "$this");
            this.Name = "DRG3010Q12";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.DRG3010Q12_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrgHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region 메세지처리 同期化完了
        /// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "user_id":
					msg = NetInfo.Language == LangMode.Ko ? Resources.msg1_Ko
						: Resources.msg1_JP;
					caption = NetInfo.Language == LangMode.Ko ? Resources.msg_Ko
                        : Resources.msg_JP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nurse_confirm_enable":
					msg = NetInfo.Language == LangMode.Ko ? Resources.msg2_Ko
						: Resources.msg2_JP;
					caption = NetInfo.Language == LangMode.Ko ? Resources.msg_Ko 
						: Resources.msg_JP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bannab_yn":
					msg = NetInfo.Language == LangMode.Ko ? Resources.msg3_Ko
						: Resources.msg3_Jp;
					caption = NetInfo.Language == LangMode.Ko ? Resources.msg_Ko
                        : Resources.msg_JP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? Resources.msg4_Ko
						: Resources.msg4_JP;
					caption = NetInfo.Language == LangMode.Ko ? Resources.msg_Ko
                        : Resources.msg5_JP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? Resources.msg6_Ko 
						: Resources.msg6_JP;
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? Resources.msg_Ko
                        : Resources.msg7_JP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "bannab_true":
					msg = NetInfo.Language == LangMode.Ko ? Resources.msg8_Ko
						: Resources.msg8_JP;
					caption = NetInfo.Language == LangMode.Ko ? Resources.msg_Ko
                        : Resources.msg5_JP;
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load 同期化完了
		private void DRG3010Q12_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            int width = this.Width;
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            if (rc.Width - 30 < this.Width)
            {
                width = rc.Width - 30;
            }
            this.ParentForm.Size = new System.Drawing.Size(width, this.Height);

            this.initProc();
		}
		#endregion

        #region [initProc]
        private void initProc()
        {
            this.CurrMQLayout = this.grdDrgHistory;

            this.paBox.Enabled = true;

            this.cboBuseo.SelectedIndex = 0;

            //this.mbxMonth.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));

            this.grdPalist.QueryLayout(true);
        }
        #endregion

        #region [OnLoad]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.mbxMonth.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));
            string str = this.mbxMonth.GetDataValue() + "01";
            DateTime time = Convert.ToDateTime(str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2));
            this.DayCounts = DateTime.DaysInMonth(time.Year, time.Month);
            this.grdDrgHistory.AddedHeaderLine = 1;
            this.grdDrgHistory.HeaderHeights.Add(20);
            this.grdDrgHistory.HeaderHeights.Add(0x17);
            this.grdDrgHistory.HeaderInfos.AddRange(new XGridHeader[] { this.xGridHeader1 });
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.HeaderText = time.Month.ToString() + "月";
            this.xGridHeader1.HeaderFont = new Font("MS UI Gothic", 9.75f, FontStyle.Bold);
            this.xGridHeader1.ColSpan = this.DayCounts;
            this.grdDrgHistory.FixedRows = 2;
            this.grdDrgHistory.Rows = 3;
            this.xGridHeader1.Col = 10;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell2.RowSpan = 2;
            this.xEditGridCell3.RowSpan = 2;
            this.xEditGridCell4.RowSpan = 2;
            this.xEditGridCell5.RowSpan = 2;
            this.xEditGridCell6.RowSpan = 2;
            this.xEditGridCell7.RowSpan = 2;
            this.xEditGridCell8.RowSpan = 2;
            for (int i = 0; i < this.DayCounts; i++)
            {
                XEditGridCell cellInfo = new XEditGridCell();
                int num2 = i + 1;
                cellInfo.CellName = "num" + num2.ToString().PadLeft(2, '0');
                cellInfo.Col = 10 + i;
                cellInfo.CellWidth = 20;
                cellInfo.HeaderText = time.AddDays((double)i).Day.ToString();
                cellInfo.RowSpan = 1;
                cellInfo.Row = 1;
                this.grdDrgHistory.Cols++;
                this.grdDrgHistory.ColPerLine++;
                this.grdDrgHistory.CellInfos.Add(cellInfo);
            }
            this.grdDrgHistory.InitializeColumns();
            this.grdDrgHistory.FixedCols = 10;
        }
        #endregion

        #region 복용법명칭 Tooltip처리 同期化完了
        private void grdNUR2017_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            //if (this.grdNUR2017.RowCount <= 0) return;

            //XCell ac = this.grdNUR2017.CellAtPoint(new Point(e.X,e.Y));

            //if (ac == null) return;

            //if (ac.CellName == "bogyong_code")
            //    ac.ToolTipText = this.grdNUR2017.GetItemString(ac.Row-2,"bogyong_name").ToString();

            if (this.grdDrgHistory.RowCount > 0)
            {
                XCell cell = this.grdDrgHistory.CellAtPoint(new Point(e.X, e.Y));
                if ((cell != null) && (cell.CellName == "bogyong_code"))
                {
                    cell.ToolTipText = this.grdDrgHistory.GetItemString(cell.Row - 2, "bogyong_name").ToString();
                }
            }

		}
		#endregion

        //#region Mix Group 데이타 Image Display (DisplayMixGroup) 同期化完了
        ///// <summary>
        ///// Mix Group 데이타 Image Display
        ///// </summary>
        ///// <param name="aGrd"> XEditGrid </param>
        ///// <returns> void  </returns>
        //private void DisplayMixGroup(XEditGrid aGrd)
        //{
        //    if (aGrd == null) return;

        //    try
        //    {
        //        //aGrd.Redraw = false; // Grid Display 멈춤

        //        int imageCnt = 0;

        //        // 기존 image 클리어
        //        //for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 1].Image = null;
        //        for (int i = 0; i < aGrd.RowCount; i++) aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

        //        for (int i = 0; i < aGrd.RowCount; i++)
        //        {
        //            // 이미 이미지 세팅이 안된건에 한해서 작업수행
        //            //if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 1].Image == null)
        //            if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "mix_group")) && aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
        //            {
        //                //이미수행한건 빼는로직이 있어야함..
        //                int count = 0;
        //                for (int j = i; j < aGrd.RowCount; j++)
        //                {
        //                    if (aGrd.GetItemValue(i, "input_gubun_text").ToString().Trim() == aGrd.GetItemValue(j, "input_gubun_text").ToString().Trim() &&
        //                    // 동일 group_ser, 동일 mix_group
        //                        aGrd.GetItemValue(i, "group_ser").ToString().Trim() == aGrd.GetItemValue(j, "group_ser").ToString().Trim() &&
        //                        aGrd.GetItemValue(i, "mix_group").ToString().Trim() == aGrd.GetItemValue(j, "mix_group").ToString().Trim() &&
        //                        aGrd.GetItemValue(i, "hope_date").ToString().Trim() == aGrd.GetItemValue(j, "hope_date").ToString().Trim() &&
        //                        aGrd.GetItemValue(i, "seq").ToString().Trim() == aGrd.GetItemValue(j, "seq").ToString().Trim())
        //                    {
        //                        count++;
        //                        if (count > 1)
        //                        {
        //                            //      헤더를 빼야 실제 Row
        //                            //aGrd[j + aGrd.HeaderHeights.Count, 1].Image = this.imageListMixGroup.Images[imageCnt];
        //                            //aGrd[i + aGrd.HeaderHeights.Count, 1].Image = this.imageListMixGroup.Images[imageCnt];
        //                            aGrd[j + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
        //                            aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[imageCnt];
        //                        }
        //                    }
        //                }
        //                // 현재는 image 갯수만큼 처리
        //                imageCnt = ++imageCnt % this.imageListMixGroup.Images.Count;
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        //aGrd.Redraw = true; // Grid Display 
        //    }

        //}
        //#endregion

		#region 환자번호가 입력이 됐을 때 同期化完了
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
            if (this.paBox.BunHo.ToString() != "")
            {
                this.display_date();

                /* 조회 */
                this.btnList.PerformClick(FunctionType.Query);
            }
		}
		#endregion

        #region 버튼리스트에서 클릭을 했을 때 同期化完了2
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;

					/* 조회 */
                    this.queryHistory();

					break;
				case FunctionType.Print:
                    e.IsBaseCall = false;
                    if (this.grdDrgHistory.RowCount < 1) return;

                    this.printDrgHistory();

					break;
				default:
					break;
			}
		}
		#endregion

        #region [薬歴データ照会]
        private void queryHistory()
        {
            if (TypeCheck.IsNull(this.paBox.BunHo))
            {
                XMessageBox.Show(Resources.XMessageBox1, Resources.msg_JP, MessageBoxIcon.Asterisk);
                this.paBox.Focus();
            }
            else
            {
                ArrayList inputList = new ArrayList();
                inputList.Add(UserInfo.UserID);
                inputList.Add(this.mbxMonth.GetDataValue().Replace("-", "").Replace("/", ""));
                inputList.Add(TypeCheck.NVL(this.paBox.BunHo, "%").ToString());
                inputList.Add("%");
                inputList.Add("");
                ArrayList outputList = new ArrayList();
                if (Service.ExecuteProcedure("PR_DRG_DRG9005_SERIES_NEW", inputList, outputList))
                {
                    if (!this.grdDrgHistory.QueryLayout(false))
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                }
                else
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                }
            }
        }
        #endregion

        #region [薬歴データ印刷 ]
        private void printDrgHistory()
        {
   //         this.dwWindow.Reset();
            MultiLayout layout = new MultiLayout();
            layout = this.grdDrgHistory.CloneToLayout();
            //string str = "";
            //string str2 = "";
            //string str3 = "";
            int rowNumber = 0;

            foreach (DataRow row in this.grdDrgHistory.LayoutTable.Rows)
            {
                layout.LayoutTable.ImportRow(row);
                //if (((str == row["group_ser"].ToString()) && (str2 == row["order_date"].ToString())) && (str3 == row["order_gubun"].ToString()))
                //{
                //    layout.SetItemValue(rowNumber, "group_ser", "");
                //}
                //else
                //{
                //    str = row["group_ser"].ToString();
                //    str2 = row["order_date"].ToString();
                //    str3 = row["order_gubun"].ToString();
                //}
                string yyyymm = row["yyyymm"].ToString();
                layout.SetItemValue(rowNumber, "yyyymm", yyyymm.Substring(0, 4) + "年" + yyyymm.Substring(4) + "月");

                rowNumber++;
            }

            //SingleLayout layout2 = new SingleLayout();
            //layout2.LayoutItems.Clear();
            //layout2.LayoutItems.Add("GWA_NAME");
            //layout2.QuerySQL = " SELECT FN_BAS_LOAD_GWA_NAME ( A.GWA, TRUNC(SYSDATE)  )                 GWA_NAME\r\n                                     FROM INP1001 A\r\n                                   WHERE A.HOSP_CODE = :f_hosp_code\r\n                                     AND A.BUNHO     = :f_bunho\r\n                                     AND TRUNC(SYSDATE)  BETWEEN A.IPWON_DATE AND NVL(A.TOIWON_DATE, '9998/12/31')\r\n                                     AND NVL(A.JAEWON_FLAG,'N' )= 'Y'    \r\n                                 ";
            //layout2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //layout2.SetBindVarValue("f_bunho", this.paBox.BunHo);
            //if (layout2.QueryLayout())
            //{
            //    this.dwWindow.Modify("t_gwa.text = '" + layout2.GetItemValue("GWA_NAME").ToString() + "'");
            //}

    //        this.dwWindow.FillData(layout.LayoutTable);
            //this.dwWindow.Modify("t_date.text = '" + this.mbxMonth.GetDataValue().ToString() + "'");
    //        this.dwWindow.Print();
        }
        #endregion

        #region [患者リストGRIDイベント]
        private void grdPalist_Click(object sender, EventArgs e)
        {
            if (grdPalist.CurrentRowNumber >= 0)
            {
                //환자번호 Set
                this.paBox.SetPatientID(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "bunho").ToString());
            }
        }

        private void grdPalist_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPalist.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPalist.SetBindVarValue("f_ho_dong", this.cboBuseo.GetDataValue());
        }
        #endregion

        #region [病棟変更]
        private void cboBuseo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.grdPalist.QueryLayout(true);
        }
        #endregion

        #region [grdDrgHistory 薬歴GRIDイベント]
        private void grdDrgHistory_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDrgHistory.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDrgHistory.SetBindVarValue("f_yyyymm", this.mbxMonth.GetDataValue().Replace("-", "").Replace("/", ""));
            this.grdDrgHistory.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }

        private void grdDrgHistory_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid aGrd = (XEditGrid)sender;
            this.DisplayMixGroup(aGrd);
        }

        private void DisplayMixGroup(XEditGrid aGrd)
        {
            if (aGrd != null)
            {
                try
                {
                    int num2;
                    int num = 0;
                    for (num2 = 0; num2 < aGrd.RowCount; num2++)
                    {
                        aGrd[num2 + aGrd.HeaderHeights.Count, 0].Image = null;
                    }
                    for (num2 = 0; num2 < aGrd.RowCount; num2++)
                    {
                        if (!TypeCheck.IsNull(aGrd.GetItemValue(num2, "mix_group")) && (aGrd[num2 + aGrd.HeaderHeights.Count, 0].Image == null))
                        {
                            int num3 = 0;
                            for (int i = num2; i < aGrd.RowCount; i++)
                            {
                                if (((aGrd.GetItemValue(num2, "group_ser").ToString().Trim() == aGrd.GetItemValue(i, "group_ser").ToString().Trim()) && (aGrd.GetItemValue(num2, "mix_group").ToString().Trim() == aGrd.GetItemValue(i, "mix_group").ToString().Trim())) && (aGrd.GetItemValue(num2, "order_date").ToString().Trim() == aGrd.GetItemValue(i, "order_date").ToString().Trim()))
                                {
                                    num3++;
                                    if (num3 > 1)
                                    {
                                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[num];
                                        aGrd[num2 + aGrd.HeaderHeights.Count, 0].Image = this.imageListMixGroup.Images[num];
                                    }
                                }
                            }
                            if (num3 > 1)
                            {
                                num = ++num % this.imageListMixGroup.Images.Count;
                            }
                        }
                    }
                }
                finally
                {
                }
            }
        }
        #endregion

        #region [照会月　変更]
        private void mbxMonth_NextButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            this.display_date();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void mbxMonth_PrevButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            this.display_date();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void display_date()
        {
            int num;
            for (num = this.DayCounts; num > 0; num--)
            {
                this.grdDrgHistory.CellInfos.Remove(this.grdDrgHistory.CellInfos[21 + num]);
                this.grdDrgHistory.Cols--;
                this.grdDrgHistory.ColPerLine--;
            }
            this.grdDrgHistory.InitializeColumns();
            string str = this.mbxMonth.GetDataValue() + "01";
            DateTime time = Convert.ToDateTime(str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2));
            this.DayCounts = DateTime.DaysInMonth(time.Year, time.Month);
            this.xGridHeader1.HeaderText = time.Month.ToString() + "月";
            this.xGridHeader1.ColSpan = this.DayCounts;
            for (num = 0; num < this.DayCounts; num++)
            {
                XEditGridCell cellInfo = new XEditGridCell();
                int num2 = num + 1;
                cellInfo.CellName = "num" + num2.ToString().PadLeft(2, '0');
                cellInfo.Col = 10 + num;
                cellInfo.CellWidth = 20;
                cellInfo.HeaderText = time.AddDays((double)num).Day.ToString();
                cellInfo.RowSpan = 1;
                cellInfo.Row = 1;
                this.grdDrgHistory.Cols++;
                this.grdDrgHistory.ColPerLine++;
                this.grdDrgHistory.CellInfos.Add(cellInfo);
            }
            this.grdDrgHistory.InitializeColumns();
            this.grdDrgHistory.FixedCols = 10;
        }
        #endregion

        #region [抗生剤一覧]
        private void btnAntibiotic_Click(object sender, EventArgs e)
        {
            AntibioticList dlg = new AntibioticList();

            dlg.ShowDialog();
        }
        #endregion

        #region grid backColor setting
        private void grdDrgHistory_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            SetGrdBackColor(sender, e);
        }

        private void SetGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdDrgHistory")
            {
                if ((e.ColName == "hangmog_name") && grid.GetItemString(e.RowNumber, "antibiotic_yn") == "Y")
                {
                    e.BackColor = Color.LightPink;
                }
            }
        }
        #endregion
    }
}

