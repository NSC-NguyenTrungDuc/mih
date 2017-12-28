using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
	/// <summary>
	/// IpwonSelectForm에 대한 요약 설명입니다.
	/// </summary>
	public class IpwonSelectForm : IHIS.Framework.XForm
	{
		#region 자동생성
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGrid grdIpwonHistory;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XGridHeader xGridHeader1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public IpwonSelectForm(string aBunho)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			this.mBunho = aBunho;
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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IpwonSelectForm));
            this.grdIpwonHistory = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            ((System.ComponentModel.ISupportInitialize)(this.grdIpwonHistory)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdIpwonHistory
            // 
            this.grdIpwonHistory.AddedHeaderLine = 1;
            this.grdIpwonHistory.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell21,
            this.xEditGridCell6,
            this.xEditGridCell16,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell17,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell5,
            this.xEditGridCell15,
            this.xEditGridCell18,
            this.xEditGridCell19});
            this.grdIpwonHistory.ColPerLine = 11;
            this.grdIpwonHistory.Cols = 12;
            this.grdIpwonHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdIpwonHistory.FixedCols = 1;
            this.grdIpwonHistory.FixedRows = 2;
            this.grdIpwonHistory.HeaderHeights.Add(21);
            this.grdIpwonHistory.HeaderHeights.Add(21);
            this.grdIpwonHistory.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdIpwonHistory.Location = new System.Drawing.Point(0, 0);
            this.grdIpwonHistory.Name = "grdIpwonHistory";
            this.grdIpwonHistory.QuerySQL = resources.GetString("grdIpwonHistory.QuerySQL");
            this.grdIpwonHistory.ReadOnly = true;
            this.grdIpwonHistory.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdIpwonHistory.RowHeaderVisible = true;
            this.grdIpwonHistory.Rows = 3;
            this.grdIpwonHistory.Size = new System.Drawing.Size(863, 364);
            this.grdIpwonHistory.TabIndex = 1;
            this.grdIpwonHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdIpwonHistory_MouseDown);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pkinp1001";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "pkinp1001";
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "bunho";
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "suname";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "suname";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "ipwon_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 90;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "入院日付";
            this.xEditGridCell4.IsJapanYearType = true;
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "ipwon_time";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "ipwon_time";
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "gisan_ipwon_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 90;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "起算日";
            this.xEditGridCell6.IsJapanYearType = true;
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "ipwon_type";
            this.xEditGridCell16.CellWidth = 81;
            this.xEditGridCell16.Col = 5;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "入院タイプ";
            this.xEditGridCell16.RowSpan = 2;
            this.xEditGridCell16.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell16.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE" +
                "() \r\n   AND CODE_TYPE  = \'IPWON_TYPE\'";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ipwon_rtn2";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "ipwon_rtn2";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "gwa";
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa_name";
            this.xEditGridCell9.CellWidth = 102;
            this.xEditGridCell9.Col = 3;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "診療科";
            this.xEditGridCell9.RowSpan = 2;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "doctor";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "doctor";
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "doctor_name";
            this.xEditGridCell11.CellWidth = 98;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "主治医";
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ho_dong";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "ho_dong";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "ho_dong_name";
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "病棟";
            this.xEditGridCell17.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "ho_code";
            this.xEditGridCell13.CellWidth = 54;
            this.xEditGridCell13.Col = 7;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "病室";
            this.xEditGridCell13.RowSpan = 2;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "bed_no";
            this.xEditGridCell14.CellWidth = 36;
            this.xEditGridCell14.Col = 8;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "病床";
            this.xEditGridCell14.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ho_grade";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "ho_grade_name";
            this.xEditGridCell15.CellWidth = 99;
            this.xEditGridCell15.Col = 9;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "病室等級";
            this.xEditGridCell15.RowSpan = 2;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.Location = new System.Drawing.Point(0, 364);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(863, 40);
            this.xPanel1.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "選 択", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(615, 2);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "kaikei_hodong";
            this.xEditGridCell18.CellWidth = 39;
            this.xEditGridCell18.Col = 10;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.HeaderText = "病棟";
            this.xEditGridCell18.Row = 1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "kaikei_hocode";
            this.xEditGridCell19.CellWidth = 47;
            this.xEditGridCell19.Col = 11;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "病室";
            this.xEditGridCell19.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 10;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader1.HeaderText = "会計";
            this.xGridHeader1.HeaderWidth = 39;
            // 
            // IpwonSelectForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(863, 426);
            this.Controls.Add(this.grdIpwonHistory);
            this.Controls.Add(this.xPanel1);
            this.Name = "IpwonSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入院履歴";
            this.Load += new System.EventHandler(this.IpwonSelectForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.grdIpwonHistory, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdIpwonHistory)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

		private string mBunho = "";
		
		public MultiLayout mReturnLayout ;

		private string mMsg = "";
		private string mCap = "";

		#endregion

		#region FormLoad

		private void IpwonSelectForm_Load(object sender, System.EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;

			this.mReturnLayout = this.grdIpwonHistory.CloneToLayout();

			this.btnList.PerformClick(FunctionType.Query);

			if (this.grdIpwonHistory.RowCount == 1)
			{
				this.MakeReturnLayout(0);
	
				this.btnList.PerformClick(FunctionType.Close);
			}
			else if (this.grdIpwonHistory.RowCount > 1)
			{
				this.WindowState = FormWindowState.Normal;
			}
			else
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "입원이력이 존재하지 않습니다" : "入院履歴が存在しません。";
				this.mCap = NetInfo.Language == LangMode.Ko ? "입원이력" : "入院履歴";

				XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

				this.btnList.PerformClick(FunctionType.Close);
			}
		}

		#endregion

		#region LoadData

		private void LoadData ()
        {
            this.grdIpwonHistory.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdIpwonHistory.SetBindVarValue("f_bunho", this.mBunho);
			
			if(!this.grdIpwonHistory.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdIpwonHistory Query Error");
				return;
			}
		}

		#endregion

		#region Function

		private void MakeReturnLayout (int aRowNumber)
		{
			if (aRowNumber < 0) return ;

			this.mReturnLayout.Reset();

			this.mReturnLayout.LayoutTable.ImportRow(this.grdIpwonHistory.LayoutTable.Rows[aRowNumber]);
		}

		#endregion

		#region XEditGrid

		private void grdIpwonHistory_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				int rowNumber = this.grdIpwonHistory.GetHitRowNumber(e.Y);

				if (rowNumber < 0)
					return;

				this.MakeReturnLayout(rowNumber);

				this.btnList.PerformClick(FunctionType.Close);
			}
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process :

					e.IsBaseCall = false;

					this.MakeReturnLayout(this.grdIpwonHistory.CurrentRowNumber);

					this.btnList.PerformClick(FunctionType.Close);

					break;

				case FunctionType.Query :

					e.IsBaseCall = false;

					this.LoadData();

					break;

				case FunctionType.Close :

					break;
			}
		}

		#endregion
	}
}
