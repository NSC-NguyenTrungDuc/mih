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
	/// INP1001R04에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP1001R04 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel pnlSearch;
		private IHIS.Framework.XGrid grdIpToiList;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
		private IHIS.Framework.XGridCell xGridCell10;
		private IHIS.Framework.XGridCell xGridCell11;
		private IHIS.Framework.XGridCell xGridCell12;
		private IHIS.Framework.XGridCell xGridCell13;
		private IHIS.Framework.XGridCell xGridCell14;
		private IHIS.Framework.XGridComputedCell xGridComputedCell5;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDictComboBox cboHoDong;
		private IHIS.Framework.XGridComputedCell xGridComputedCell8;
		private IHIS.Framework.XGridComputedCell xGridComputedCell26;
		private IHIS.Framework.XGridComputedCell xGridComputedCell27;
		private IHIS.Framework.XGridComputedCell xGridComputedCell28;
		private IHIS.Framework.XGridComputedCell xGridComputedCell29;
		private IHIS.Framework.XGridComputedCell xGridComputedCell31;
		private IHIS.Framework.XGridComputedCell xGridComputedCell32;
		private IHIS.Framework.XGridComputedCell xGridComputedCell33;
		private IHIS.Framework.XGridComputedCell xGridComputedCell34;
		private IHIS.Framework.XGridComputedCell xGridComputedCell1;
		private IHIS.Framework.XDataStore dsPrint;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XGridCell xGridCell15;
		private IHIS.Framework.XGridCell xGridCell16;
		private IHIS.Framework.XGridCell xGridCell17;
		private IHIS.Framework.XGridComputedCell xGridComputedCell2;
        private XDatePicker dtpToDate;
        private XLabel xLabel3;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public INP1001R04()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1001R04));
            this.pnlSearch = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.cboHoDong = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdIpToiList = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.xGridCell11 = new IHIS.Framework.XGridCell();
            this.xGridCell12 = new IHIS.Framework.XGridCell();
            this.xGridCell13 = new IHIS.Framework.XGridCell();
            this.xGridCell14 = new IHIS.Framework.XGridCell();
            this.xGridCell15 = new IHIS.Framework.XGridCell();
            this.xGridCell16 = new IHIS.Framework.XGridCell();
            this.xGridCell17 = new IHIS.Framework.XGridCell();
            this.xGridComputedCell5 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell26 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell27 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell28 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell29 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell31 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell32 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell33 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell34 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell1 = new IHIS.Framework.XGridComputedCell();
            this.xGridComputedCell2 = new IHIS.Framework.XGridComputedCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xGridComputedCell8 = new IHIS.Framework.XGridComputedCell();
            this.dsPrint = new IHIS.Framework.XDataStore();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIpToiList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSearch.BackgroundImage")));
            this.pnlSearch.Controls.Add(this.xLabel3);
            this.pnlSearch.Controls.Add(this.dtpToDate);
            this.pnlSearch.Controls.Add(this.cboHoDong);
            this.pnlSearch.Controls.Add(this.xLabel2);
            this.pnlSearch.Controls.Add(this.dtpFromDate);
            this.pnlSearch.Controls.Add(this.xLabel1);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(4, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(952, 36);
            this.pnlSearch.TabIndex = 0;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(226, 8);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(22, 20);
            this.xLabel3.TabIndex = 5;
            this.xLabel3.Text = "～";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.IsJapanYearType = true;
            this.dtpToDate.Location = new System.Drawing.Point(248, 8);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(120, 20);
            this.dtpToDate.TabIndex = 4;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
            // 
            // cboHoDong
            // 
            this.cboHoDong.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHoDong.Location = new System.Drawing.Point(471, 8);
            this.cboHoDong.MaxDropDownItems = 15;
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(94, 20);
            this.cboHoDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoDong.TabIndex = 3;
            this.cboHoDong.UserSQL = resources.GetString("cboHoDong.UserSQL");
            this.cboHoDong.SelectedIndexChanged += new System.EventHandler(this.cboHoDong_SelectedIndexChanged);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(403, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(68, 20);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "病棟";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.IsJapanYearType = true;
            this.dtpFromDate.Location = new System.Drawing.Point(106, 8);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 20);
            this.dtpFromDate.TabIndex = 1;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpQueryDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(22, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(84, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "照会日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdIpToiList
            // 
            this.grdIpToiList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell6,
            this.xGridCell7,
            this.xGridCell8,
            this.xGridCell9,
            this.xGridCell10,
            this.xGridCell11,
            this.xGridCell12,
            this.xGridCell13,
            this.xGridCell14,
            this.xGridCell15,
            this.xGridCell16,
            this.xGridCell17});
            this.grdIpToiList.ColPerLine = 11;
            this.grdIpToiList.Cols = 12;
            this.grdIpToiList.ComputedCellInfos.AddRange(new IHIS.Framework.XGridComputedCell[] {
            this.xGridComputedCell5,
            this.xGridComputedCell26,
            this.xGridComputedCell27,
            this.xGridComputedCell28,
            this.xGridComputedCell29,
            this.xGridComputedCell31,
            this.xGridComputedCell32,
            this.xGridComputedCell33,
            this.xGridComputedCell34,
            this.xGridComputedCell1,
            this.xGridComputedCell2});
            this.grdIpToiList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIpToiList.FixedCols = 1;
            this.grdIpToiList.FixedRows = 1;
            this.grdIpToiList.GroupInfos.AddRange(new IHIS.Framework.XGridGroupInfo[] {
            new IHIS.Framework.XGridGroupInfo("Group1", new object[] {
                        ((object)("ip_toi_gubun"))}),
            new IHIS.Framework.XGridGroupInfo("Group2", new object[] {
                        ((object)("ip_toi_gubun")),
                        ((object)("ho_dong1"))})});
            this.grdIpToiList.HeaderHeights.Add(21);
            this.grdIpToiList.Location = new System.Drawing.Point(4, 40);
            this.grdIpToiList.Name = "grdIpToiList";
            this.grdIpToiList.QuerySQL = resources.GetString("grdIpToiList.QuerySQL");
            this.grdIpToiList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdIpToiList.RowHeaderVisible = true;
            this.grdIpToiList.Rows = 4;
            this.grdIpToiList.Size = new System.Drawing.Size(952, 510);
            this.grdIpToiList.TabIndex = 1;
            this.grdIpToiList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIpToiList_QueryStarting);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "query_date";
            this.xGridCell1.Col = -1;
            this.xGridCell1.HeaderText = "query_date";
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "ip_toi_gubun";
            this.xGridCell2.Col = -1;
            this.xGridCell2.HeaderText = "ip_toi_gubun";
            this.xGridCell2.IsVisible = false;
            this.xGridCell2.Row = -1;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "ip_toi_gubun_name";
            this.xGridCell3.CellWidth = 59;
            this.xGridCell3.Col = 1;
            this.xGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell3.HeaderText = "入/退院";
            this.xGridCell3.SuppressRepeating = true;
            this.xGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "bunho";
            this.xGridCell4.Col = 2;
            this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell4.HeaderText = "患者番号";
            this.xGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "suname";
            this.xGridCell5.CellWidth = 107;
            this.xGridCell5.Col = 3;
            this.xGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell5.HeaderText = "氏名(漢字)";
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "gubun_name";
            this.xGridCell6.CellWidth = 93;
            this.xGridCell6.Col = 5;
            this.xGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell6.HeaderText = "保険種別";
            // 
            // xGridCell7
            // 
            this.xGridCell7.CellName = "ipwon_date";
            this.xGridCell7.CellWidth = 124;
            this.xGridCell7.Col = 8;
            this.xGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell7.HeaderText = "入院日";
            this.xGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "toiwon_date";
            this.xGridCell8.CellWidth = 125;
            this.xGridCell8.Col = 9;
            this.xGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell8.HeaderText = "退院日";
            this.xGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell9
            // 
            this.xGridCell9.CellName = "ho_dong1";
            this.xGridCell9.Col = -1;
            this.xGridCell9.HeaderText = "病棟";
            this.xGridCell9.IsVisible = false;
            this.xGridCell9.Row = -1;
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "ho_dong_name1";
            this.xGridCell10.CellWidth = 73;
            this.xGridCell10.Col = 6;
            this.xGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell10.HeaderText = "病棟";
            // 
            // xGridCell11
            // 
            this.xGridCell11.CellName = "ho_code1";
            this.xGridCell11.CellWidth = 47;
            this.xGridCell11.Col = 7;
            this.xGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell11.HeaderText = "病室";
            this.xGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell12
            // 
            this.xGridCell12.CellName = "sex";
            this.xGridCell12.CellWidth = 40;
            this.xGridCell12.Col = 4;
            this.xGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell12.HeaderText = "性別";
            this.xGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell13
            // 
            this.xGridCell13.CellName = "tel";
            this.xGridCell13.CellWidth = 96;
            this.xGridCell13.Col = 11;
            this.xGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell13.HeaderText = "電話番号";
            // 
            // xGridCell14
            // 
            this.xGridCell14.CellName = "address1";
            this.xGridCell14.CellWidth = 134;
            this.xGridCell14.Col = -1;
            this.xGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell14.HeaderText = "住所";
            this.xGridCell14.IsVisible = false;
            this.xGridCell14.Row = -1;
            // 
            // xGridCell15
            // 
            this.xGridCell15.CellName = "siksa_magam_date";
            this.xGridCell15.Col = -1;
            this.xGridCell15.HeaderText = "siksa_magam_date";
            this.xGridCell15.IsVisible = false;
            this.xGridCell15.Row = -1;
            // 
            // xGridCell16
            // 
            this.xGridCell16.CellName = "ki_gubun";
            this.xGridCell16.Col = -1;
            this.xGridCell16.HeaderText = "ki_gubun";
            this.xGridCell16.IsVisible = false;
            this.xGridCell16.Row = -1;
            // 
            // xGridCell17
            // 
            this.xGridCell17.CellName = "result";
            this.xGridCell17.CellWidth = 61;
            this.xGridCell17.Col = 10;
            this.xGridCell17.HeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridCell17.HeaderText = "退院事由";
            this.xGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridComputedCell5
            // 
            this.xGridComputedCell5.Col = 3;
            this.xGridComputedCell5.Expression = "\"【入退院別合計】\"";
            this.xGridComputedCell5.GroupName = "Group1";
            // 
            // xGridComputedCell26
            // 
            this.xGridComputedCell26.Col = 8;
            this.xGridComputedCell26.Expression = "\" \"";
            this.xGridComputedCell26.GroupName = "Group1";
            // 
            // xGridComputedCell27
            // 
            this.xGridComputedCell27.Col = 1;
            this.xGridComputedCell27.Expression = "\" \"";
            this.xGridComputedCell27.GroupName = "Group1";
            // 
            // xGridComputedCell28
            // 
            this.xGridComputedCell28.Col = 2;
            this.xGridComputedCell28.Expression = "\" \"";
            this.xGridComputedCell28.GroupName = "Group1";
            // 
            // xGridComputedCell29
            // 
            this.xGridComputedCell29.Col = 4;
            this.xGridComputedCell29.Expression = "\" \"";
            this.xGridComputedCell29.GroupName = "Group1";
            // 
            // xGridComputedCell31
            // 
            this.xGridComputedCell31.Col = 6;
            this.xGridComputedCell31.Expression = "\" \"";
            this.xGridComputedCell31.GroupName = "Group1";
            // 
            // xGridComputedCell32
            // 
            this.xGridComputedCell32.Col = 7;
            this.xGridComputedCell32.Expression = "\" \"";
            this.xGridComputedCell32.GroupName = "Group1";
            // 
            // xGridComputedCell33
            // 
            this.xGridComputedCell33.Col = 9;
            this.xGridComputedCell33.Expression = "\" \"";
            this.xGridComputedCell33.GroupName = "Group1";
            // 
            // xGridComputedCell34
            // 
            this.xGridComputedCell34.Col = 11;
            this.xGridComputedCell34.Expression = "\" \"";
            this.xGridComputedCell34.GroupName = "Group1";
            // 
            // xGridComputedCell1
            // 
            this.xGridComputedCell1.Col = 5;
            this.xGridComputedCell1.ComputedKind = IHIS.Framework.XGridComputedKind.Count;
            this.xGridComputedCell1.Expression = "Count(ip_toi_gubun) ";
            this.xGridComputedCell1.GroupName = "Group1";
            // 
            // xGridComputedCell2
            // 
            this.xGridComputedCell2.Col = 10;
            this.xGridComputedCell2.Expression = "\"\"";
            this.xGridComputedCell2.GroupName = "Group1";
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(708, 554);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 2;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xGridComputedCell8
            // 
            this.xGridComputedCell8.Col = 1;
            this.xGridComputedCell8.Expression = "\" \"";
            this.xGridComputedCell8.GroupName = "Group1";
            // 
            // dsPrint
            // 
            this.dsPrint.DataWindowObject = "inp1001r04";
            this.dsPrint.LibraryList = "..\\NURI\\nuri.inp1001r04.pbd";
            // 
            // INP1001R04
            // 
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdIpToiList);
            this.Controls.Add(this.pnlSearch);
            this.Name = "INP1001R04";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Load += new System.EventHandler(this.INP1001R04_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdIpToiList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrint)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen Load

		private void INP1001R04_Load(object sender, System.EventArgs e)
		{
			if (EnvironInfo.CurrSystemID == "NUTS")
			{
				this.dsPrint.DataWindowObject = "inp1001r04_1";
			}
			else
			{
				this.dsPrint.DataWindowObject = "inp1001r04";
			}

			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			InitScreen();
		}

		#endregion

		#region Function

		private void InitScreen ()
		{
			// 조회일자 셋팅 기본 오늘
            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

			// 병동은 전체로 셋팅 
			this.cboHoDong.SetDataValue("%");

		}

		#endregion

		#region Data Load

		private void DataLoad()
		{
			this.grdIpToiList.QueryLayout(false);
		}

		#endregion

		#region XDatePicker

		private void dtpQueryDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			this.DataLoad();
		}

		#endregion

		#region XDictCombo

		private void cboHoDong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.DataLoad();
		}

		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query : 

					e.IsBaseCall = false;

					this.DataLoad();

					break;

				case FunctionType.Print :

					e.IsBaseCall = false;

					this.DataLoad();

					this.dsPrint.Reset();

					this.dsPrint.FillData(this.grdIpToiList.LayoutTable);

					try
					{
						this.dsPrint.Print();
					}
					catch
					{
					}

					break;

				case FunctionType.Close :

					break;
			}
		}

        private void grdIpToiList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdIpToiList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdIpToiList.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdIpToiList.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdIpToiList.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
        }
	}
}

