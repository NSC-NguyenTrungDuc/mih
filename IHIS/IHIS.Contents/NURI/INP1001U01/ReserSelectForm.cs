using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
	/// <summary>
	/// ReserSelectForm에 대한 요약 설명입니다.
    /// 
	/// </summary>
	public class ReserSelectForm : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGrid grdINP1003;
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
		private System.Windows.Forms.ImageList ImageList;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
		private System.ComponentModel.IContainer components;

		public ReserSelectForm(string aBunho)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
            this.mBunho = aBunho;
            this.InitForm();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReserSelectForm));
            this.grdINP1003 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1003)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdINP1003
            // 
            this.grdINP1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell19,
            this.xEditGridCell24,
            this.xEditGridCell25});
            this.grdINP1003.ColPerLine = 12;
            this.grdINP1003.Cols = 13;
            this.grdINP1003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1003.FixedCols = 1;
            this.grdINP1003.FixedRows = 1;
            this.grdINP1003.HeaderHeights.Add(31);
            this.grdINP1003.Location = new System.Drawing.Point(0, 0);
            this.grdINP1003.Name = "grdINP1003";
            this.grdINP1003.QuerySQL = resources.GetString("grdINP1003.QuerySQL");
            this.grdINP1003.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINP1003.RowHeaderVisible = true;
            this.grdINP1003.Rows = 2;
            this.grdINP1003.RowStateCheckOnPaint = false;
            this.grdINP1003.Size = new System.Drawing.Size(1117, 308);
            this.grdINP1003.TabIndex = 1;
            this.grdINP1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdINP1003_MouseDown);
            this.grdINP1003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdINP1003_GridColumnChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "exists_yn";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gwa";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "doctor";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "ho_dong";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "ho_code";
            this.xEditGridCell5.CellWidth = 50;
            this.xEditGridCell5.Col = 7;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "病室";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "ipwon_rtn2";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "reser_date";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pkinp1003";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "bed_no";
            this.xEditGridCell9.CellWidth = 35;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "病床";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "ho_grade";
            this.xEditGridCell10.CellWidth = 96;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell10.HeaderText = "病室\r\n等級";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.MaxDropDownItems = 20;
            this.xEditGridCell10.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell10.UserSQL = "SELECT A.HO_GRADE\r\n     , A.HO_GRADE_NAME \r\n  FROM BAS0251 A\r\n WHERE A.HOSP_CODE " +
                "= FN_ADM_LOAD_HOSP_CODE()";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "ho_status";
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "病室\r\n状態";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "reser_fkinp1001";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "remark";
            this.xEditGridCell13.CellWidth = 54;
            this.xEditGridCell13.Col = 11;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell13.HeaderText = "備考";
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "ipwon_mokjuk";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "reser_date_jp";
            this.xEditGridCell15.CellWidth = 122;
            this.xEditGridCell15.Col = 2;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "予約日";
            this.xEditGridCell15.IsReadOnly = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "gwa_name";
            this.xEditGridCell16.CellWidth = 94;
            this.xEditGridCell16.Col = 4;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "診療科";
            this.xEditGridCell16.IsReadOnly = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "doctor_name";
            this.xEditGridCell17.CellWidth = 86;
            this.xEditGridCell17.Col = 5;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "主治医";
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "ho_dong_name";
            this.xEditGridCell18.Col = 6;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.HeaderText = "病棟";
            this.xEditGridCell18.IsReadOnly = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "jisi_doctor";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "jisi_doctor";
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "jisi_doctor_name";
            this.xEditGridCell21.CellWidth = 98;
            this.xEditGridCell21.Col = 3;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell21.HeaderText = "指示医";
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "emergency_gubun";
            this.xEditGridCell22.CellWidth = 239;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell22.HeaderText = "emergency_gubun";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell22.UserSQL = "  SELECT CODE, CODE_NAME\r\n    FROM BAS0102\r\n   WHERE HOSP_CODE = FN_ADM_LOAD_HOSP" +
                "_CODE()\r\n     AND CODE_TYPE =\'EMERGENCY_GUBUN\'\r\nORDER BY CODE";
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "emergency_detail";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "emergency_detail";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell19.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell19.CellName = "select_yn";
            this.xEditGridCell19.CellWidth = 37;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "選択";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell19.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell19.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "emergency_text";
            this.xEditGridCell24.CellWidth = 238;
            this.xEditGridCell24.Col = 12;
            this.xEditGridCell24.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell24.HeaderText = "救急医療管理加算";
            this.xEditGridCell24.IsUpdatable = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.Location = new System.Drawing.Point(0, 308);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1117, 40);
            this.xPanel1.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "選 択", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(943, 4);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "fkout1001";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "fkout1001";
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // ReserSelectForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(1117, 370);
            this.Controls.Add(this.grdINP1003);
            this.Controls.Add(this.xPanel1);
            this.Name = "ReserSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "入院予約";
            this.Load += new System.EventHandler(this.ReserSelectForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.grdINP1003, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1003)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Form 변수 

		private string mBunho = "";

		private MultiLayout mReturnLayout ;

		private string mMsg = "";
        private string mCap = "";
        private int crdRowCount = 0;

		#endregion

		#region Property

		public MultiLayout ReturnLayout 
		{
			get
			{
				return this.mReturnLayout;
			}
		}

        public int grdRowCount
        {
            get
            {
                return crdRowCount;
            }
        }

		#endregion

		#region Form Load

		private void ReserSelectForm_Load(object sender, System.EventArgs e)
		{
            this.WindowState = FormWindowState.Minimized;

			if (this.grdINP1003.RowCount > 0)
			{
				this.WindowState = FormWindowState.Normal;
			}
			else
			{
				this.btnList.PerformClick(FunctionType.Close);
			}
		}

		#endregion

		#region Function

		#region InitForm

		private void InitForm ()
		{
			this.mReturnLayout = this.grdINP1003.CloneToLayout();
			
			this.LoadData();
		}

		#endregion

		#region SettingGridImage

		private void SettingGridImage ()
		{
			for (int i=0; i<this.grdINP1003.RowCount; i++)
			{
				if (this.grdINP1003.GetItemString(i, "select_yn") != "Y")
				{
					this.grdINP1003[i,"select_yn"].Image = ImageList.Images[1];
				}
				else
				{
					this.grdINP1003[i,"select_yn"].Image = ImageList.Images[0];
				}

				if (this.grdINP1003.GetItemString(i, "reser_fkinp1001") != "")
				{
					this.grdINP1003[i+this.grdINP1003.HeaderHeights.Count, 0].Image = ImageList.Images[2];
				}
			}
		}

		#endregion

		#region SelectRow

		private void SelectRow (bool aIsSelectableMultiRow, int aRowNumber)
		{
			if (aIsSelectableMultiRow == false)
			{
				for (int i=0; i<this.grdINP1003.RowCount; i++)
				{
					if (i != aRowNumber && this.grdINP1003.GetItemString(i, "select_yn") == "Y")
					{
						return;
					}
				}
			}

			if (this.grdINP1003.GetItemString(aRowNumber, "select_yn") == "Y")
			{
				this.grdINP1003.SetItemValue(aRowNumber, "select_yn", "N");
				this.grdINP1003[aRowNumber, "select_yn"].Image = ImageList.Images[1];
			}
			else
			{
				this.grdINP1003.SetItemValue(aRowNumber, "select_yn", "Y");
				this.grdINP1003[aRowNumber, "select_yn"].Image = ImageList.Images[0];
			}
		}

		#endregion

		#region 

		private void MakeReturnLayout ()
		{
			int rowNumber = -1;

			if (this.mReturnLayout == null)
			{
				this.mReturnLayout = this.grdINP1003.CloneToLayout();
			}

			this.mReturnLayout.Reset();

			for (int i=0; i<this.grdINP1003.RowCount; i++)
			{
				if (this.grdINP1003.GetItemString(i, "select_yn") == "Y")
				{
					rowNumber = i;
				}
			}

			if (rowNumber < 0) 
			{
				this.mReturnLayout = null;
			}
			else
			{
				this.mReturnLayout.LayoutTable.ImportRow(this.grdINP1003.LayoutTable.Rows[rowNumber]);
			}
		}

		#endregion

		#endregion

		#region LoadData
		private void LoadData ()
        {
            this.grdINP1003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdINP1003.SetBindVarValue("f_bunho", this.mBunho);

			if(!this.grdINP1003.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : grdINP1003 Query Error");
				return;
			}

            crdRowCount = this.grdINP1003.RowCount;

			this.SettingGridImage();
		}

		#endregion

		#region XEditGrid

		private void grdINP1003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			XEditGrid grd = sender as XEditGrid ;

			if (e.Button == MouseButtons.Left && e.Clicks == 1)
			{
				int rowNumber = grd.GetHitRowNumber(e.Y);

				if (rowNumber < 0) return;

				this.SelectRow(false, rowNumber);
			}
		}

		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			e.IsBaseCall = false;

			switch (e.Func)
			{
				case FunctionType.Process :

					this.MakeReturnLayout();

					if (this.mReturnLayout == null)
					{
						this.mMsg = NetInfo.Language == LangMode.Ko ? "선택된 예약건이 없습니다." : "選択された予約件がありません。";
						this.mCap = NetInfo.Language == LangMode.Ko ? "입원예약" : "入院予約";

						XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

						return;
					}

					this.Close();

					break;

				case FunctionType.Close :

					this.mReturnLayout = null;

					this.Close();

					break;
			}
		}

        private void grdINP1003_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
        }

	}
}
