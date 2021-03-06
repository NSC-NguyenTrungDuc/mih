using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using IHIS.Framework;

namespace IHIS.OCSI
{
    public class frmInpwonList : System.Windows.Forms.Form //IHIS.Framework.XForm
	{
		//입원 LIST
		private IHIS.Framework.MultiLayout layoutInpwon_list;
		//선택된 Row
		private int mSelectRow = -1;
		
		private IHIS.Framework.XGrid grdInpwonList;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell7;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XGridCell xGridCell9;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButton btnSelect;
		private IHIS.Framework.XButton btnExit;
		private System.ComponentModel.IContainer components = null;

		public frmInpwonList()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			// TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInpwonList));
            this.grdInpwonList = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell7 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell9 = new IHIS.Framework.XGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnExit = new IHIS.Framework.XButton();
            this.btnSelect = new IHIS.Framework.XButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdInpwonList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdInpwonList
            // 
            this.grdInpwonList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell6,
            this.xGridCell7,
            this.xGridCell8,
            this.xGridCell9});
            this.grdInpwonList.ColPerLine = 4;
            this.grdInpwonList.Cols = 5;
            this.grdInpwonList.FixedCols = 1;
            this.grdInpwonList.FixedRows = 1;
            this.grdInpwonList.HeaderHeights.Add(23);
            this.grdInpwonList.Location = new System.Drawing.Point(0, -1);
            this.grdInpwonList.Name = "grdInpwonList";
            this.grdInpwonList.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdInpwonList.RowHeaderVisible = true;
            this.grdInpwonList.Rows = 2;
            this.grdInpwonList.Size = new System.Drawing.Size(384, 345);
            this.grdInpwonList.TabIndex = 1;
            this.grdInpwonList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdInpwonList_MouseDown);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "pkinp1001";
            this.xGridCell1.Col = -1;
            this.xGridCell1.IsVisible = false;
            this.xGridCell1.Row = -1;
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "bunho";
            this.xGridCell2.Col = -1;
            this.xGridCell2.IsVisible = false;
            this.xGridCell2.Row = -1;
            // 
            // xGridCell3
            // 
            this.xGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell3.CellName = "ipwon_date";
            this.xGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell3.Col = 1;
            this.xGridCell3.HeaderText = "入院日付";
            this.xGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "gwa";
            this.xGridCell4.Col = -1;
            this.xGridCell4.IsVisible = false;
            this.xGridCell4.Row = -1;
            // 
            // xGridCell5
            // 
            this.xGridCell5.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell5.CellName = "gwa_name";
            this.xGridCell5.Col = 2;
            this.xGridCell5.HeaderText = "診療科";
            this.xGridCell5.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell5.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "doctor";
            this.xGridCell6.Col = -1;
            this.xGridCell6.IsVisible = false;
            this.xGridCell6.Row = -1;
            // 
            // xGridCell7
            // 
            this.xGridCell7.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell7.CellName = "doctor_name";
            this.xGridCell7.CellWidth = 82;
            this.xGridCell7.Col = 3;
            this.xGridCell7.HeaderText = "診療医師";
            this.xGridCell7.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell7.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "gubun";
            this.xGridCell8.Col = -1;
            this.xGridCell8.IsVisible = false;
            this.xGridCell8.Row = -1;
            // 
            // xGridCell9
            // 
            this.xGridCell9.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridCell9.CellName = "gubun_name";
            this.xGridCell9.CellWidth = 87;
            this.xGridCell9.Col = 4;
            this.xGridCell9.HeaderText = "保険種別";
            this.xGridCell9.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xGridCell9.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnExit);
            this.xPanel1.Controls.Add(this.btnSelect);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 345);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(384, 37);
            this.xPanel1.TabIndex = 46;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(299, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 26);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "閉じる";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(227, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(71, 27);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "選択";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmInpwonList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(384, 382);
            this.ControlBox = false;
            this.Controls.Add(this.grdInpwonList);
            this.Controls.Add(this.xPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInpwonList";
            this.Load += new System.EventHandler(this.frmInpwonList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdInpwonList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region [Form]
        
		private void frmInpwonList_Load(object sender, System.EventArgs e)
		{
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			if(layoutInpwon_list == null || layoutInpwon_list.RowCount == 0)
				this.DialogResult = DialogResult.Cancel;

			foreach(DataRow row in layoutInpwon_list.LayoutTable.Rows)
			{
				grdInpwonList.LayoutTable.ImportRow(row);
			}

			grdInpwonList.DisplayData();
		}

		#endregion
	

		#region [properties]
		
		public MultiLayout INPWON_LIST
		{
			get
			{
				return layoutInpwon_list;
			}
			set
			{
				layoutInpwon_list = value;
			}
		}

		public int SELECT_ROW
		{
			get
			{
				return mSelectRow;
			}
			set
			{
				mSelectRow = value;
			}
		}

		#endregion

		#region [Control Event]

		private void grdInpwonList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				mSelectRow = grdInpwonList.GetHitRowNumber(e.Y);
				if(mSelectRow < 0) return;

				this.DialogResult = DialogResult.OK;
			}
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			mSelectRow = grdInpwonList.CurrentRowNumber;
			this.DialogResult = DialogResult.OK;
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion

		
	}
}

