using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURI
{
	/// <summary>
	/// ReserMemoForm에 대한 요약 설명입니다.
	/// </summary>
	public class ReserMemoForm : IHIS.Framework.XForm
	{
		private System.ComponentModel.IContainer components;

		public ReserMemoForm(string aCategoryGubun)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			this.mParamCategoryGubun = aCategoryGubun;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReserMemoForm));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboCategoryGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdCSC0108 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCSC0108)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.cboCategoryGubun);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(408, 46);
            this.xPanel1.TabIndex = 0;
            // 
            // cboCategoryGubun
            // 
            this.cboCategoryGubun.Location = new System.Drawing.Point(120, 12);
            this.cboCategoryGubun.Name = "cboCategoryGubun";
            this.cboCategoryGubun.Size = new System.Drawing.Size(148, 21);
            this.cboCategoryGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboCategoryGubun.TabIndex = 1;
            this.cboCategoryGubun.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM BAS0102\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() \r" +
                "\n  AND CODE_TYPE = \'RESER_MEMO_CATEGORY\'\r\nORDER BY CODE ";
            this.cboCategoryGubun.SelectedValueChanged += new System.EventHandler(this.cboCategoryGubun_SelectedValueChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(20, 12);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(100, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "定型文区分";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdCSC0108
            // 
            this.grdCSC0108.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdCSC0108.ColPerLine = 1;
            this.grdCSC0108.Cols = 2;
            this.grdCSC0108.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCSC0108.FixedCols = 1;
            this.grdCSC0108.FixedRows = 1;
            this.grdCSC0108.HeaderHeights.Add(27);
            this.grdCSC0108.Location = new System.Drawing.Point(0, 46);
            this.grdCSC0108.Name = "grdCSC0108";
            this.grdCSC0108.QuerySQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n     , \'N\'\r\n  FROM BAS0102 A\r\n WHERE A.HOSP_CO" +
                "DE = :f_hosp_code\r\n   AND A.CODE_TYPE = :f_category_gubun\r\n ORDER BY A.CODE";
            this.grdCSC0108.ReadOnly = true;
            this.grdCSC0108.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdCSC0108.RowHeaderVisible = true;
            this.grdCSC0108.Rows = 2;
            this.grdCSC0108.RowStateCheckOnPaint = false;
            this.grdCSC0108.Size = new System.Drawing.Size(408, 294);
            this.grdCSC0108.TabIndex = 1;
            this.grdCSC0108.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdCSC0108_MouseDown);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "reser_memo_category";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "reser_memo_category";
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "text";
            this.xEditGridCell3.CellWidth = 366;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.DisplayMemoText = true;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "定型文";
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "select_yn";
            this.xEditGridCell4.CellWidth = 55;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "選択";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 340);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(408, 40);
            this.xPanel2.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "選 択", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(238, 4);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "reser_memo_category";
            this.multiLayoutItem5.IsUpdItem = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "seq";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "text";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "select_yn";
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // ReserMemoForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(408, 402);
            this.Controls.Add(this.grdCSC0108);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "ReserMemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "定型文";
            this.Load += new System.EventHandler(this.ReserMemoForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.Controls.SetChildIndex(this.grdCSC0108, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCSC0108)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XDictComboBox cboCategoryGubun;
		private IHIS.Framework.XEditGrid grdCSC0108;
		private System.Windows.Forms.ImageList imageList1;

		#region Form 변수 

		private string mParamCategoryGubun = "";

		//string mPrevComment = "";
		private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
		//선택된 상용어구
		string mComment = "";

		#endregion

		#region Property

		public string SelectedText 
		{
			get 
			{
				return this.mComment;
			}
		}

		#endregion

		#region Form Load 이벤트

		private void ReserMemoForm_Load(object sender, System.EventArgs e)
		{
			if (this.mParamCategoryGubun != "") 
				this.cboCategoryGubun.SetDataValue(this.mParamCategoryGubun);
			else
				this.cboCategoryGubun.SelectedIndex = 0;
            this.LoadData(this.cboCategoryGubun.GetDataValue());
		}

		#endregion

		#region XEdit Grid 이벤트

		private void grdCSC0108_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			XEditGrid grd = sender as XEditGrid;

			int rowNumber = -1;

            if ( e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				rowNumber = grd.GetHitRowNumber(e.Y);

				if (rowNumber < 0) return;

				this.btnList.PerformClick(FunctionType.Process);
			}
		}

		#endregion

		#region DataLoad

		private void LoadData(string aCategoryGubun)
        {
            this.grdCSC0108.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdCSC0108.SetBindVarValue("f_category_gubun", aCategoryGubun);
            this.grdCSC0108.QueryLayout(true);
         }

		#endregion

		#region Combo Box

		private void cboCategoryGubun_SelectedValueChanged(object sender, System.EventArgs e)
		{
			this.LoadData(this.cboCategoryGubun.GetDataValue());
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process :

					if (this.grdCSC0108.CurrentRowNumber >= 0)
						this.mComment = this.grdCSC0108.GetItemString(this.grdCSC0108.CurrentRowNumber, "text");
					else
						this.mComment = "";

					this.DialogResult = DialogResult.OK;

					break;

				case FunctionType.Close :

					this.DialogResult = DialogResult.No;

					break;
			}
		}

		#endregion
      

	}
}
