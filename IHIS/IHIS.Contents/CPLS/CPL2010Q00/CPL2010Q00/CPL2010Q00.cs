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

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL2010Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL2010Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XLabel xLabel1;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XEditGrid grdResult;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XDatePicker dtpToDate;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
	//	private IHIS.Framework.XDataWindow dw_ResultPRN;
		private IHIS.Framework.MultiLayout layResultPRN;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDictComboBox cboJundalGubun;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
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
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem23;
        private XEditGridCell xEditGridCell10;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPL2010Q00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdResult = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.cboJundalGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel3 = new IHIS.Framework.XPanel();
   ///         this.dw_ResultPRN = new IHIS.Framework.XDataWindow();
            this.layResultPRN = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layResultPRN)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 548);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1172, 37);
            this.xPanel1.TabIndex = 0;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(910, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdResult);
            this.xPanel2.Controls.Add(this.xPanel4);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 5);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(428, 543);
            this.xPanel2.TabIndex = 1;
            // 
            // grdResult
            // 
            this.grdResult.ApplyPaintEventToAllColumn = true;
            this.grdResult.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell6,
            this.xEditGridCell8,
            this.xEditGridCell2,
            this.xEditGridCell7,
            this.xEditGridCell1,
            this.xEditGridCell10,
            this.xEditGridCell9});
            this.grdResult.ColPerLine = 6;
            this.grdResult.ColResizable = true;
            this.grdResult.Cols = 7;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.FixedCols = 1;
            this.grdResult.FixedRows = 1;
            this.grdResult.HeaderHeights.Add(35);
            this.grdResult.Location = new System.Drawing.Point(2, 58);
            this.grdResult.Name = "grdResult";
            this.grdResult.QuerySQL = resources.GetString("grdResult.QuerySQL");
            this.grdResult.RowHeaderVisible = true;
            this.grdResult.Rows = 2;
            this.grdResult.RowStateCheckOnPaint = false;
            this.grdResult.Size = new System.Drawing.Size(422, 481);
            this.grdResult.TabIndex = 1;
            this.grdResult.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdResult_QueryStarting);
            this.grdResult.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdResult_GridCellPainting);
            this.grdResult.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdResult_RowFocusChanged);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "bunho";
            this.xEditGridCell4.CellWidth = 77;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.HeaderText = "患者番号";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "suname";
            this.xEditGridCell5.CellWidth = 85;
            this.xEditGridCell5.Col = 6;
            this.xEditGridCell5.HeaderText = "氏名";
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "in_out_gubun";
            this.xEditGridCell3.CellWidth = 45;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.HeaderText = "外/入";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "入院";
            this.xComboItem1.ValueItem = "I";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "外来";
            this.xComboItem2.ValueItem = "O";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "order_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 68;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.HeaderText = "診療科";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jundal_gubun";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "select";
            this.xEditGridCell1.CellWidth = 24;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.HeaderText = "印\r\n刷";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "result_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.Col = 5;
            this.xEditGridCell10.HeaderText = "結果日付";
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "print_yn";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.cboJundalGubun);
            this.xPanel4.Controls.Add(this.xLabel2);
            this.xPanel4.Controls.Add(this.dtpFromDate);
            this.xPanel4.Controls.Add(this.dtpToDate);
            this.xPanel4.Controls.Add(this.xLabel1);
            this.xPanel4.Controls.Add(this.label1);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Location = new System.Drawing.Point(2, 2);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(422, 56);
            this.xPanel4.TabIndex = 0;
            // 
            // cboJundalGubun
            // 
            this.cboJundalGubun.Location = new System.Drawing.Point(78, 28);
            this.cboJundalGubun.MaxDropDownItems = 10;
            this.cboJundalGubun.Name = "cboJundalGubun";
            this.cboJundalGubun.Size = new System.Drawing.Size(118, 21);
            this.cboJundalGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJundalGubun.TabIndex = 5;
            this.cboJundalGubun.UserSQL = "SELECT \'%\'\r\n     , FN_ADM_MSG(\'221\')\r\n  FROM DUAL\r\n UNION ALL\r\nSELECT CODE\r\n     " +
                ", CODE_NAME\r\n  FROM CPL0109\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n   AND " +
                "CODE_TYPE = \'01\'";
            this.cboJundalGubun.SelectionChangeCommitted += new System.EventHandler(this.cboJundalGubun_SelectionChangeCommitted);
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(4, 28);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(72, 21);
            this.xLabel2.TabIndex = 4;
            this.xLabel2.Text = "伝達パート";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(78, 4);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(118, 20);
            this.dtpFromDate.TabIndex = 1;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(216, 4);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(118, 20);
            this.dtpToDate.TabIndex = 2;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(4, 4);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(72, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "結果日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(202, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "~";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // xPanel3
            // 
  //          this.xPanel3.Controls.Add(this.dw_ResultPRN);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(433, 5);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel3.Size = new System.Drawing.Size(744, 543);
            this.xPanel3.TabIndex = 2;
            // 
            // dw_ResultPRN
            // 
            //this.dw_ResultPRN.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            //this.dw_ResultPRN.DataWindowObject = "d_result_prn3";
            //this.dw_ResultPRN.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.dw_ResultPRN.LibraryList = "..\\CPLS\\cpls.cpl2010q00.pbd";
            //this.dw_ResultPRN.Location = new System.Drawing.Point(2, 2);
            //this.dw_ResultPRN.Name = "dw_ResultPRN";
            //this.dw_ResultPRN.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            //this.dw_ResultPRN.Size = new System.Drawing.Size(738, 537);
            //this.dw_ResultPRN.TabIndex = 0;
            //this.dw_ResultPRN.Text = "xDataWindow1";
            // 
            // layResultPRN
            // 
            this.layResultPRN.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem23});
            this.layResultPRN.QuerySQL = resources.GetString("layResultPRN.QuerySQL");
            this.layResultPRN.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layResultPRN_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "suname";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "age";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "sex";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "gwa_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "doctor_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "ho_dong";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "order_date";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "specimen_ser";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "part_jubsu_date";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "part_jubsu_time";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "result_date";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "speciman_name";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "gumsaja";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "standard_yn";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "panic_yn";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "cpl_result";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "standard";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "danui_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "gumsa_name";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "fix_note";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "note";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "pkcpl3020";
            // 
            // CPL2010Q00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL2010Q00";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1182, 590);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layResultPRN)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
	
		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
			this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
			this.cboJundalGubun.SetDataValue("%");

            if (!this.grdResult.QueryLayout(false))
            {
                XMessageBox.Show("照会中にエラーが発生しました。\r\n" + Service.ErrFullMsg, "注意", MessageBoxIcon.Error);
                return;
            }

		}
		#endregion

		#region result print query
		private void ResultPRNQuery()
		{
            //dw_ResultPRN.Reset();
            //layResultPRN.Reset();
            //if(this.layResultPRN.QueryLayout(true))
            //{	
            //    if (layResultPRN.RowCount > 0)
            //    {
            //        dw_ResultPRN.PrintProperties.Preview = true;
            //        dw_ResultPRN.FillData(layResultPRN.LayoutTable);
            //    }
            //    else
            //    {
            //        dw_ResultPRN.PrintProperties.Preview = false;
            //    }				
            //}
            //else
            //{
            //    MessageBox.Show(Service.ErrFullMsg);
            //}
		}
		#endregion

		#region result print
		private void ResultPrint()
        {
            string cmdText = "";
            BindVarCollection bc = new BindVarCollection();

			for ( int i = 0; i< this.grdResult.RowCount; i++ )
			{
                if (this.grdResult.GetItemString(i, "select") == "Y")
				{
                    this.grdResult.SetFocusToItem(i, "select");
					this.ResultPRNQuery();
	//				this.dw_ResultPRN.Print();

                    cmdText = @"UPDATE CPL2010 
                                   SET DONER_YN      = 'Y'
                                 WHERE HOSP_CODE     = :f_hosp_code
                                   AND BUNHO         = :f_bunho
                                   AND ORDER_DATE    = TO_DATE(:f_order_date,'YYYY/MM/DD')
                                   AND IN_OUT_GUBUN  = :f_in_out_gubun
                                   AND GWA           = :f_gwa
                                   --AND RESULT_DATE   BETWEEN TO_DATE(:f_from_date,'YYYY/MM/DD') AND TO_DATE(:f_to_date,'YYYY/MM/DD')
                                   AND RESULT_DATE   = TO_DATE(:f_result_date,'YYYY/MM/DD') 
                                   AND JUNDAL_GUBUN  LIKE :f_jundal_gubun";

                    bc.Add("f_hosp_code", EnvironInfo.HospCode);
                    bc.Add("f_bunho", this.grdResult.GetItemString(i, "bunho"));
                    bc.Add("f_order_date", this.grdResult.GetItemString(i, "order_date"));
                    bc.Add("f_in_out_gubun", this.grdResult.GetItemString(i, "in_out_gubun"));
                    bc.Add("f_gwa", this.grdResult.GetItemString(i, "gwa"));
                    bc.Add("f_result_date", dtpFromDate.GetDataValue());
                    //bc.Add("f_from_date", dtpFromDate.GetDataValue());
                    //bc.Add("f_to_date", dtpToDate.GetDataValue());
                    bc.Add("f_jundal_gubun", cboJundalGubun.GetDataValue());

                    if (!Service.ExecuteNonQuery(cmdText, bc))
                    {
                        XMessageBox.Show("印刷フラッグ処理中エラーが発生しました。", "注意", MessageBoxIcon.Error);
                        return;
                    }
				}
			}
		}
		#endregion

		private void grdResult_Click(object sender, System.EventArgs e)
		{
		}

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Print:
					ResultPrint();
					break;
                case FunctionType.Query:
                        this.grdResult.QueryLayout(false);
                break;
				default:
					break;
			}
		}

		private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.grdResult.QueryLayout(false);
		}

		private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.grdResult.QueryLayout(false);
		}

		private void cboJundalGubun_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            this.grdResult.QueryLayout(false);
		}

		private void grdResult_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
            if (e.DataRow["print_yn"].ToString() == "Y")
				e.BackColor = Color.LightPink;
		}

        private void grdResult_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdResult.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdResult.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdResult.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.grdResult.SetBindVarValue("f_jundal_gubun", cboJundalGubun.GetDataValue());
        }

        private void layResultPRN_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layResultPRN.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layResultPRN.SetBindVarValue("f_bunho", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "bunho"));
            this.layResultPRN.SetBindVarValue("f_order_date", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "order_date"));
            this.layResultPRN.SetBindVarValue("f_in_out_gubun", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "in_out_gubun"));
            this.layResultPRN.SetBindVarValue("f_gwa", this.grdResult.GetItemString(this.grdResult.CurrentRowNumber, "gwa"));
            this.layResultPRN.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.layResultPRN.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.layResultPRN.SetBindVarValue("f_jundal_gubun", cboJundalGubun.GetDataValue());
        }

        private void grdResult_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            ResultPRNQuery();
        }

	}
}

