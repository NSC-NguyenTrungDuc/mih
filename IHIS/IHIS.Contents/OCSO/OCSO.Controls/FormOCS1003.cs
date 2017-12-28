using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSO
{
	/// <summary>
	/// FormOCS1003에 대한 요약 설명입니다.
	/// </summary>
	public class FormOCS1003 : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XEditGrid grdOCS1003;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnSelect;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell11;
        private XDatePicker dtpEnd;
        private XDatePicker dtpStart;
        private XLabel xLabel1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;


		public FormOCS1003(string aBunho, string aReserDate)
		{
			InitializeComponent();

            /* 조회하기 위한 기간을 설정 추가. 2011.12.12 woo*/
            this.dtpStart.SetDataValue(Convert.ToDateTime(aReserDate).ToString("yyyy/MM/dd"));
            this.dtpEnd.SetDataValue(Convert.ToDateTime(aReserDate).AddMonths(1));

			GetServiceCall(aBunho, aReserDate);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOCS1003));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpEnd = new IHIS.Framework.XDatePicker();
            this.dtpStart = new IHIS.Framework.XDatePicker();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.grdOCS1003);
            this.xPanel1.Controls.Add(this.pnlBottom);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // grdOCS1003
            // 
            resources.ApplyResources(this.grdOCS1003, "grdOCS1003");
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell6,
            this.xEditGridCell11,
            this.xEditGridCell7,
            this.xEditGridCell1,
            this.xEditGridCell8,
            this.xEditGridCell10});
            this.grdOCS1003.ColPerLine = 5;
            this.grdOCS1003.Cols = 6;
            this.grdOCS1003.ExecuteQuery = null;
            this.grdOCS1003.FixedCols = 1;
            this.grdOCS1003.FixedRows = 1;
            this.grdOCS1003.HeaderHeights.Add(20);
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1003.ParamList")));
            this.grdOCS1003.QuerySQL = resources.GetString("grdOCS1003.QuerySQL");
            this.grdOCS1003.RowHeaderVisible = true;
            this.grdOCS1003.Rows = 2;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.DoubleClick += new System.EventHandler(this.grdOCS1003_DoubleClick);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "reser_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.CellWidth = 121;
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "order_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 96;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "acting_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 135;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "gwa";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gwa_name";
            this.xEditGridCell1.CellWidth = 66;
            this.xEditGridCell1.Col = 4;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "doctor";
            this.xEditGridCell8.CellWidth = 180;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "doctor_name";
            this.xEditGridCell10.CellWidth = 74;
            this.xEditGridCell10.Col = 5;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.xLabel1);
            this.pnlBottom.Controls.Add(this.dtpEnd);
            this.pnlBottom.Controls.Add(this.dtpStart);
            this.pnlBottom.Controls.Add(this.btnSelect);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // dtpEnd
            // 
            this.dtpEnd.AccessibleDescription = null;
            this.dtpEnd.AccessibleName = null;
            resources.ApplyResources(this.dtpEnd, "dtpEnd");
            this.dtpEnd.BackgroundImage = null;
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpEnd_DataValidating);
            // 
            // dtpStart
            // 
            this.dtpStart.AccessibleDescription = null;
            this.dtpStart.AccessibleName = null;
            resources.ApplyResources(this.dtpStart, "dtpStart");
            this.dtpStart.BackgroundImage = null;
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpStart_DataValidating);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleDescription = null;
            this.btnSelect.AccessibleName = null;
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.BackgroundImage = null;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellName = "ct";
            this.xEditGridCell2.CellWidth = 33;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellName = "mri";
            this.xEditGridCell3.CellWidth = 33;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.CellName = "gen";
            this.xEditGridCell4.CellWidth = 33;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.CellName = "a";
            this.xEditGridCell5.CellWidth = 33;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // FormOCS1003
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Name = "FormOCS1003";
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region fields
        private string mOrderDate = "";
        private string mReserDate = "";
		private string mGwa		= "";
		private string mDoctor = "";
        private string mActingFlag = "";
        private string mBunho = "";
		#endregion

		#region properties
		internal string MorderDate
		{
			get { return mOrderDate; }
        }

        internal string MreserDate
        {
            get { return mReserDate; }
        }

		internal string Mgwa
		{
			get { return mGwa; }
		}

		internal string Mdoctor
		{
			get { return mDoctor; }
		}
        internal string MactingFlag
        {
            get { return mActingFlag; }
        }
        internal string Mbunho
        {
            get { return mBunho; }
        }

		#endregion
	
		#region Common Method
		private void GetServiceCall(string aBunho, string aReserDate)
        {
            this.grdOCS1003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOCS1003.SetBindVarValue("f_bunho", aBunho);
            this.grdOCS1003.SetBindVarValue("f_reser_date", aReserDate);
            this.grdOCS1003.SetBindVarValue("f_start_date", this.dtpStart.GetDataValue());
            this.grdOCS1003.SetBindVarValue("f_end_date", this.dtpEnd.GetDataValue());

            this.mBunho = aBunho;
            this.grdOCS1003.QueryLayout(false);
		}
		private void SetOkReturn()
		{
			int row = grdOCS1003.CurrentRowNumber;
            if (grdOCS1003.RowCount > 0)
			{
				this.mDoctor	= grdOCS1003.GetItemString(row, "doctor");
                this.mOrderDate = grdOCS1003.GetItemString(row, "order_date");
                this.mReserDate = grdOCS1003.GetItemString(row, "reser_date");
				this.mGwa		= grdOCS1003.GetItemString(row, "gwa");
                this.mActingFlag = grdOCS1003.GetItemString(row, "acting_date").ToString() == "" ? "N" : "Y";  //2011.12.12 추가 woo
                this.DialogResult = DialogResult.OK;
			}
			else
			{
				this.DialogResult = DialogResult.No;
			}
			this.Close();
		}
		#endregion

		private void grdOCS1003_DoubleClick(object sender, System.EventArgs e)
		{
			SetOkReturn();
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			SetOkReturn();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

        private void grdOCS1003_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (!e.DataRow["acting_date"].ToString().Equals(""))
            {
                e.ForeColor = Color.LightGray;
            }
        }

        private void dtpStart_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.grdOCS1003.SetBindVarValue("f_start_date", this.dtpStart.GetDataValue());
            this.grdOCS1003.SetBindVarValue("f_end_date", this.dtpEnd.GetDataValue());
            this.grdOCS1003.QueryLayout(false);
        }

        private void dtpEnd_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.grdOCS1003.SetBindVarValue("f_start_date", this.dtpStart.GetDataValue());
            this.grdOCS1003.SetBindVarValue("f_end_date", this.dtpEnd.GetDataValue());
            this.grdOCS1003.QueryLayout(false);
        }
	}
}
