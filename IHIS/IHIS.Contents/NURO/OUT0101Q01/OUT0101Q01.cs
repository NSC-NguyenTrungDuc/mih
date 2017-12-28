#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Models.Nuro;

#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// OUT0101Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OUT0101Q01 : IHIS.Framework.XScreen
	{
		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XGrid grdPatientList;
		private IHIS.Framework.XGridCell xGridCell1;
		private IHIS.Framework.XGridCell xGridCell2;
		private IHIS.Framework.XGridCell xGridCell3;
		private IHIS.Framework.XGridCell xGridCell4;
		private IHIS.Framework.XGridCell xGridCell5;
		private IHIS.Framework.XGridCell xGridCell6;
		private IHIS.Framework.XGridCell xGridCell8;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XDictComboBox cboSex;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XGridCell xGridCell10;
		private IHIS.Framework.XGridCell xGridCell11;
		private IHIS.Framework.XGridCell xGridCell12;
		private IHIS.Framework.XGridCell xGridCell13;
		private IHIS.Framework.XGridCell xGridCell14;
		private IHIS.Framework.XGridCell xGridCell15;
		private IHIS.Framework.XGridCell xGridCell16;
        private IHIS.Framework.XGridCell xGridCell17;
		private IHIS.Framework.XGridCell xGridCell21;
		private IHIS.Framework.XGridCell xGridCell22;
        private IHIS.Framework.XGridCell xGridCell23;
        private IHIS.Framework.XGridCell xGridCell25;
		private IHIS.Framework.XGridCell xGridCell31;
        private IHIS.Framework.XGridCell xGridCell32;
		private IHIS.Framework.XGridCell xGridCell35;
		private IHIS.Framework.XGridCell xGridCell36;
		private IHIS.Framework.XTextBox txtSuname2;
		private IHIS.Framework.XDatePicker dtpBirthDate;
		private IHIS.Framework.XTextBox txtTel;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.MultiLayout layReturnRow;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public OUT0101Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

		    BindExecuteQueryMethod();
		    cboSex.SetDictDDLB();

            //apply multi-language to date_time
            if (NetInfo.Language != LangMode.Jr)
            {
                this.xGridCell5.IsJapanYearType = false;
                this.xGridCell6.IsJapanYearType = false;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT0101Q01));
            this.txtSuname2 = new IHIS.Framework.XTextBox();
            this.cboSex = new IHIS.Framework.XDictComboBox();
            this.dtpBirthDate = new IHIS.Framework.XDatePicker();
            this.txtTel = new IHIS.Framework.XTextBox();
            this.grdPatientList = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.xGridCell10 = new IHIS.Framework.XGridCell();
            this.xGridCell11 = new IHIS.Framework.XGridCell();
            this.xGridCell12 = new IHIS.Framework.XGridCell();
            this.xGridCell13 = new IHIS.Framework.XGridCell();
            this.xGridCell14 = new IHIS.Framework.XGridCell();
            this.xGridCell15 = new IHIS.Framework.XGridCell();
            this.xGridCell16 = new IHIS.Framework.XGridCell();
            this.xGridCell17 = new IHIS.Framework.XGridCell();
            this.xGridCell21 = new IHIS.Framework.XGridCell();
            this.xGridCell22 = new IHIS.Framework.XGridCell();
            this.xGridCell23 = new IHIS.Framework.XGridCell();
            this.xGridCell25 = new IHIS.Framework.XGridCell();
            this.xGridCell31 = new IHIS.Framework.XGridCell();
            this.xGridCell32 = new IHIS.Framework.XGridCell();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            this.xGridCell35 = new IHIS.Framework.XGridCell();
            this.xGridCell8 = new IHIS.Framework.XGridCell();
            this.xGridCell36 = new IHIS.Framework.XGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layReturnRow = new IHIS.Framework.MultiLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturnRow)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSuname2
            // 
            resources.ApplyResources(this.txtSuname2, "txtSuname2");
            this.txtSuname2.Name = "txtSuname2";
            this.txtSuname2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSuname2_DataValidating);
            // 
            // cboSex
            // 
            this.cboSex.ExecuteQuery = null;
            resources.ApplyResources(this.cboSex, "cboSex");
            this.cboSex.Name = "cboSex";
            this.cboSex.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSex.ParamList")));
            this.cboSex.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSex.UserSQL = "SELECT CODE, CODE_NAME\r\n FROM BAS0102\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() " +
                "\r\n  AND CODE_TYPE = \'SEX_GUBUN\'";
            this.cboSex.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboSex_DataValidating);
            // 
            // dtpBirthDate
            // 
            resources.ApplyResources(this.dtpBirthDate, "dtpBirthDate");
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpBirthDate_DataValidating);
            // 
            // txtTel
            // 
            resources.ApplyResources(this.txtTel, "txtTel");
            this.txtTel.Name = "txtTel";
            this.txtTel.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTel_DataValidating);
            // 
            // grdPatientList
            // 
            this.grdPatientList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell10,
            this.xGridCell11,
            this.xGridCell12,
            this.xGridCell13,
            this.xGridCell14,
            this.xGridCell15,
            this.xGridCell16,
            this.xGridCell17,
            this.xGridCell21,
            this.xGridCell22,
            this.xGridCell23,
            this.xGridCell25,
            this.xGridCell31,
            this.xGridCell32,
            this.xGridCell6,
            this.xGridCell35,
            this.xGridCell8,
            this.xGridCell36});
            this.grdPatientList.ColPerLine = 9;
            this.grdPatientList.Cols = 9;
            resources.ApplyResources(this.grdPatientList, "grdPatientList");
            this.grdPatientList.ExecuteQuery = null;
            this.grdPatientList.FixedRows = 1;
            this.grdPatientList.HeaderHeights.Add(21);
            this.grdPatientList.Name = "grdPatientList";
            this.grdPatientList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientList.ParamList")));
            this.grdPatientList.QuerySQL = resources.GetString("grdPatientList.QuerySQL");
            this.grdPatientList.Rows = 2;
            this.grdPatientList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPatientList_MouseDown);
            this.grdPatientList.QueryStarting += new CancelEventHandler(grdPatientList_QueryStarting);
            this.grdPatientList.ColResizable = true;
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "bunho";
            this.xGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "suname";
            this.xGridCell2.CellWidth = 97;
            this.xGridCell2.Col = 1;
            this.xGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "suname2";
            this.xGridCell3.CellWidth = 96;
            this.xGridCell3.Col = 2;
            this.xGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "sex";
            this.xGridCell4.CellWidth = 46;
            this.xGridCell4.Col = -1;
            this.xGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell4, "xGridCell4");
            this.xGridCell4.IsVisible = false;
            this.xGridCell4.Row = -1;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "birth";
            this.xGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell5.CellWidth = 100;
            this.xGridCell5.Col = 4;
            this.xGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell5, "xGridCell5");
            this.xGridCell5.IsJapanYearType = true;
            // 
            // xGridCell10
            // 
            this.xGridCell10.CellName = "zip_code1";
            this.xGridCell10.Col = -1;
            resources.ApplyResources(this.xGridCell10, "xGridCell10");
            this.xGridCell10.IsVisible = false;
            this.xGridCell10.Row = -1;
            // 
            // xGridCell11
            // 
            this.xGridCell11.CellName = "zip_code2";
            this.xGridCell11.Col = -1;
            resources.ApplyResources(this.xGridCell11, "xGridCell11");
            this.xGridCell11.IsVisible = false;
            this.xGridCell11.Row = -1;
            // 
            // xGridCell12
            // 
            this.xGridCell12.CellName = "address1";
            this.xGridCell12.Col = -1;
            resources.ApplyResources(this.xGridCell12, "xGridCell12");
            this.xGridCell12.IsVisible = false;
            this.xGridCell12.Row = -1;
            // 
            // xGridCell13
            // 
            this.xGridCell13.CellName = "address2";
            this.xGridCell13.Col = -1;
            resources.ApplyResources(this.xGridCell13, "xGridCell13");
            this.xGridCell13.IsVisible = false;
            this.xGridCell13.Row = -1;
            // 
            // xGridCell14
            // 
            this.xGridCell14.CellName = "address";
            this.xGridCell14.CellWidth = 200;
            this.xGridCell14.Col = 6;
            this.xGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell14, "xGridCell14");
            // 
            // xGridCell15
            // 
            this.xGridCell15.CellName = "tel";
            this.xGridCell15.Col = -1;
            resources.ApplyResources(this.xGridCell15, "xGridCell15");
            this.xGridCell15.IsVisible = false;
            this.xGridCell15.Row = -1;
            // 
            // xGridCell16
            // 
            this.xGridCell16.CellName = "tel2";
            this.xGridCell16.Col = -1;
            resources.ApplyResources(this.xGridCell16, "xGridCell16");
            this.xGridCell16.IsVisible = false;
            this.xGridCell16.Row = -1;
            // 
            // xGridCell17
            // 
            this.xGridCell17.CellName = "gubun";
            this.xGridCell17.Col = -1;
            resources.ApplyResources(this.xGridCell17, "xGridCell17");
            this.xGridCell17.IsVisible = false;
            this.xGridCell17.Row = -1;
            // 
            // xGridCell21
            // 
            this.xGridCell21.CellName = "jubsu_break";
            this.xGridCell21.Col = -1;
            resources.ApplyResources(this.xGridCell21, "xGridCell21");
            this.xGridCell21.IsVisible = false;
            this.xGridCell21.Row = -1;
            // 
            // xGridCell22
            // 
            this.xGridCell22.CellName = "jubsu_break_reason";
            this.xGridCell22.Col = -1;
            resources.ApplyResources(this.xGridCell22, "xGridCell22");
            this.xGridCell22.IsVisible = false;
            this.xGridCell22.Row = -1;
            // 
            // xGridCell23
            // 
            this.xGridCell23.CellName = "delete_yn";
            this.xGridCell23.Col = -1;
            resources.ApplyResources(this.xGridCell23, "xGridCell23");
            this.xGridCell23.IsVisible = false;
            this.xGridCell23.Row = -1;
            // 
            // xGridCell25
            // 
            this.xGridCell25.CellName = "remark";
            this.xGridCell25.Col = -1;
            resources.ApplyResources(this.xGridCell25, "xGridCell25");
            this.xGridCell25.IsVisible = false;
            this.xGridCell25.Row = -1;
            // 
            // xGridCell31
            // 
            this.xGridCell31.CellName = "tel_hp";
            this.xGridCell31.Col = -1;
            resources.ApplyResources(this.xGridCell31, "xGridCell31");
            this.xGridCell31.IsVisible = false;
            this.xGridCell31.Row = -1;
            // 
            // xGridCell32
            // 
            this.xGridCell32.CellName = "email";
            this.xGridCell32.Col = -1;
            resources.ApplyResources(this.xGridCell32, "xGridCell32");
            this.xGridCell32.IsVisible = false;
            this.xGridCell32.Row = -1;
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "last_naewon_date";
            this.xGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell6.CellWidth = 110;
            this.xGridCell6.Col = 5;
            this.xGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell6, "xGridCell6");
            this.xGridCell6.IsJapanYearType = true;
            // 
            // xGridCell35
            // 
            this.xGridCell35.CellName = "sex_name";
            this.xGridCell35.CellWidth = 70;
            this.xGridCell35.Col = 3;
            this.xGridCell35.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell35, "xGridCell35");
            this.xGridCell35.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell8
            // 
            this.xGridCell8.CellName = "ipwon_yn";
            this.xGridCell8.CellWidth = 57;
            this.xGridCell8.Col = 7;
            this.xGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell8, "xGridCell8");
            this.xGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell36
            // 
            this.xGridCell36.CellName = "ho_dong";
            this.xGridCell36.CellWidth = 98;
            this.xGridCell36.Col = 8;
            this.xGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridCell36, "xGridCell36");
            this.xGridCell36.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.txtTel);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.dtpBirthDate);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.cboSex);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.txtSuname2);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resource.button_F2, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resource.button_select, 0, "Green"),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resource.button_close, -1, "")});
            this.btnList.ImageList = this.ImageList;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layReturnRow
            // 
            this.layReturnRow.ExecuteQuery = null;
            this.layReturnRow.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReturnRow.ParamList")));
            // 
            // OUT0101Q01
            // 
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdPatientList);
            this.Controls.Add(this.xPanel1);
            this.Name = "OUT0101Q01";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.OUT0101Q01_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturnRow)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region Field and properties

	    private bool _isDataValidating = false;

        #endregion

		#region Screen Load 이벤트 

		private void OUT0101Q01_Load(object sender, System.EventArgs e)
		{
			this.layReturnRow = this.grdPatientList.CloneToLayout();
            //MED-6865
            this.grdPatientList.QueryLayout(false);

            // https://sofiamedix.atlassian.net/browse/MED-13535
            if (NetInfo.Language != LangMode.Jr)
            {
                // Rename "Họ và tên 1"
                //xGridCell2.HeaderText = "Họ và tên";
                // Hide "Họ và tên 2"
                grdPatientList.AutoSizeColumn(xGridCell3.Col, 0);
            }
		}

		#endregion

		#region Function

		private void CommandInvoke ()
		{
			if (this.Opener is XScreen)
			{
				if (this.grdPatientList.RowCount > 0 && this.grdPatientList.CurrentRowNumber >= 0)
				{
					this.layReturnRow.LayoutTable.ImportRow(this.grdPatientList.LayoutTable.Rows[this.grdPatientList.CurrentRowNumber]);

					CommonItemCollection commandParam = new CommonItemCollection();

					commandParam.Add("OUT0101", this.layReturnRow);
					commandParam.Add("bunho"  , this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho"));
					commandParam.Add("suname" , this.grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "suname"));

					((XScreen)this.Opener).Command("OUT0101", commandParam);

					this.Close();
				}
			}
			else
			{
				return ;
			}
		}

		private bool IsAbleToQuery()
		{
			if (this.txtSuname2.GetDataValue() != "")
			{
				return true;
			}

			else
			{
				if (this.cboSex.GetDataValue() != "" && this.dtpBirthDate.GetDataValue() != "")
				{
					return true;
				}

				if (this.txtTel.GetDataValue() != "" && this.txtTel.GetDataValue().Length >= 4)
				{
					return true;
				}
			}

			return false;
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query :

					e.IsBaseCall = false;
					e.IsSuccess = false;

                    //MED-6865
                    //if (this.IsAbleToQuery())
                    //{
                        
                        this.grdPatientList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
						this.grdPatientList.SetBindVarValue("f_suname2", this.txtSuname2.Text);
						this.grdPatientList.SetBindVarValue("f_sex"    , this.cboSex.GetDataValue());
						this.grdPatientList.SetBindVarValue("f_birth"  , this.dtpBirthDate.GetDataValue());
						this.grdPatientList.SetBindVarValue("f_tel"    , this.txtTel.Text);

						if(!this.grdPatientList.QueryLayout(false))
						{
							XMessageBox.Show(Service.ErrFullMsg + " : grdPatientList Query Error");
							return;
						}
						else
						{
						    if (grdPatientList.RowCount == 0)
						    {
						        XMessageBox.Show(Resource.OUT0101Q01_WarningMessage, Resource.OUT0101Q01_Caption, MessageBoxIcon.Warning);
                                _isDataValidating = false;
						    }
						    else
						    {
                                for (int i = 0; i < this.grdPatientList.RowCount; i++)
                                {
                                    if (this.grdPatientList.GetItemString(i, "ho_dong").ToString().Length > 0)
                                    {
                                        this.grdPatientList.SetItemValue(i, "ipwon_yn", "入院");
                                    }
                                    else
                                    {
                                        this.grdPatientList.SetItemValue(i, "ipwon_yn", "");
                                    }
                                }
						    }
						}
                    //}

					break;

				case FunctionType.Process :

					e.IsBaseCall = false;
					e.IsSuccess = false;

					this.CommandInvoke();

					break;

				case FunctionType.Close :

					this.Close();

					break;
			}
		}

		#endregion

		#region DataValidating

		private void txtSuname2_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
		    _isDataValidating = true;
			this.btnList.PerformClick(FunctionType.Query);
		}

		private void cboSex_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            _isDataValidating = true;
            this.btnList.PerformClick(FunctionType.Query);
		}

		private void dtpBirthDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            _isDataValidating = true;
            this.btnList.PerformClick(FunctionType.Query);
		}

		private void txtTel_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            _isDataValidating = true;
            this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion

		private void grdPatientList_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowNumber = 0;

			if (this.grdPatientList.RowCount < 0)
				return;

			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				rowNumber = this.grdPatientList.GetHitRowNumber(e.Y);

				if (rowNumber < 0) return;

				this.CommandInvoke();
			}
        }

        #region DzungTA modify
        private void BindExecuteQueryMethod()
        {
            cboSex.ExecuteQuery = QueryCboSex;
            grdPatientList.ParamList = new List<string>(new String[] { "f_suname2", "f_sex", "f_birth", "f_tel", "f_hosp_code", "f_page_number" });
            grdPatientList.ExecuteQuery = QueryGrdPatientList;
        }

        private List<object[]> QueryCboSex(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            OUT0101Q01CboSexArgs args = new OUT0101Q01CboSexArgs();
            OUT0101Q01CboSexResult result = CacheService.Instance.Get<OUT0101Q01CboSexArgs, OUT0101Q01CboSexResult>(args, delegate(OUT0101Q01CboSexResult sexResult)
            {
                return sexResult != null && sexResult.ExecutionStatus == ExecutionStatus.Success && sexResult.Item != null && sexResult.Item.Count > 0;
            });
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {

                foreach (ComboListItemInfo item in result.Item)
                {
                    object[] obj =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(obj);
                }
            }

            return res;
        }

        private List<object[]> QueryGrdPatientList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();

            OUT0101Q01GrdPatientListArgs args = new OUT0101Q01GrdPatientListArgs();
            args.Birth = bc["f_birth"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.Sex = bc["f_sex"].VarValue;
            args.Suname2 = bc["f_suname2"].VarValue;
            args.Tel = bc["f_tel"].VarValue;
            args.PageNumber = bc["f_page_number"].VarValue;
            args.Offset = "200";
            OUT0101Q01GrdPatientListResult result = CloudService.Instance.Submit<OUT0101Q01GrdPatientListResult,OUT0101Q01GrdPatientListArgs>(args);
            if (result != null)
            {

                foreach (OUT0101Q01GrdPatientListInfo item in result.Item)
                {
                    object[] obj =
                    {
                        item.Bunho,
                        item.Suname,
                        item.Suname2,
                        item.Sex,
                        item.Birth,
                        item.ZipCode1,
                        item.ZipCode2,
                        item.Address1,
                        item.Address2,
                        item.Address,
                        item.Tel,
                        item.Tel1,
                        item.Gubun,
                        item.JubsuBreak,
                        item.JubsuBreakReason,
                        item.DeleteYn,
                        item.Remark,
                        item.TelHp,
                        item.Email,
                        item.FnOutLoadLastNaewonDate,
                        item.FnBasLoadCodeName,
                        item.NoHeader,
                        item.HoDong,
                        item.ContKey
                    };
                    res.Add(obj);
                }
            }

            return res;
        }
        #endregion

        // https://sofiamedix.atlassian.net/browse/MED-13525
        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdPatientList.SetBindVarValue("f_suname2", this.txtSuname2.Text);
            this.grdPatientList.SetBindVarValue("f_sex", this.cboSex.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_birth", this.dtpBirthDate.GetDataValue());
            this.grdPatientList.SetBindVarValue("f_tel", this.txtTel.Text);
        }
    }
}