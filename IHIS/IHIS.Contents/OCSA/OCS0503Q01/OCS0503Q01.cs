#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
	/// <summary>
	/// OCS0503Q01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class OCS0503Q01 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XDatePicker dpkTo_date;
		private IHIS.Framework.XDatePicker dpkFrom_date;
		private IHIS.Framework.XLabel xLabel3;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XPatientBox pbBunho;
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGrid grdOCS0503;
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
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OCS0503Q01()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            this.xComboItem1.DisplayItem = Resource.xComboItem_DisplayItem_O;
            this.xComboItem2.DisplayItem = Resource.xComboItem_DisplayItem_Y;

            this.xEditGridCell14.ButtonText = Resource.xEditGridCell14_ButtonText;
            this.xEditGridCell15.ButtonText = Resource.xEditGridCell15_ButtonText;

            // Create param list for grdOCS0503
            this.grdOCS0503.ParamList = new List<string>(new String[]{"f_bunho", "f_from_date", "f_to_date"});
            // Execute query
		    this.grdOCS0503.ExecuteQuery = grdOCS0503_ExecuteQuery;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0503Q01));
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.pbBunho = new IHIS.Framework.XPatientBox();
            this.dpkTo_date = new IHIS.Framework.XDatePicker();
            this.dpkFrom_date = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdOCS0503 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
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
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBunho)).BeginInit();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0503)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Controls.Add(this.pbBunho);
            this.xPanel3.Controls.Add(this.dpkTo_date);
            this.xPanel3.Controls.Add(this.dpkFrom_date);
            this.xPanel3.Controls.Add(this.xLabel3);
            this.xPanel3.Controls.Add(this.label1);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // pbBunho
            // 
            this.pbBunho.AccessibleDescription = null;
            this.pbBunho.AccessibleName = null;
            resources.ApplyResources(this.pbBunho, "pbBunho");
            this.pbBunho.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pbBunho.BackgroundImage = null;
            this.pbBunho.Name = "pbBunho";
            this.pbBunho.PatientSelectionFailed += new System.EventHandler(this.pbBunho_PatientSelectionFailed);
            this.pbBunho.PatientSelected += new System.EventHandler(this.pbBunho_PatientSelected);
            // 
            // dpkTo_date
            // 
            this.dpkTo_date.AccessibleDescription = null;
            this.dpkTo_date.AccessibleName = null;
            resources.ApplyResources(this.dpkTo_date, "dpkTo_date");
            this.dpkTo_date.BackgroundImage = null;
            this.dpkTo_date.IsVietnameseYearType = false;
            this.dpkTo_date.Name = "dpkTo_date";
            this.dpkTo_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkTo_date_DataValidating);
            // 
            // dpkFrom_date
            // 
            this.dpkFrom_date.AccessibleDescription = null;
            this.dpkFrom_date.AccessibleName = null;
            resources.ApplyResources(this.dpkFrom_date, "dpkFrom_date");
            this.dpkFrom_date.BackgroundImage = null;
            this.dpkFrom_date.IsVietnameseYearType = false;
            this.dpkFrom_date.Name = "dpkFrom_date";
            this.dpkFrom_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkFrom_date_DataValidating);
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.xButtonList1);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            // 
            // grdOCS0503
            // 
            resources.ApplyResources(this.grdOCS0503, "grdOCS0503");
            this.grdOCS0503.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell15});
            this.grdOCS0503.ColPerLine = 9;
            this.grdOCS0503.Cols = 9;
            this.grdOCS0503.ExecuteQuery = null;
            this.grdOCS0503.FixedRows = 1;
            this.grdOCS0503.HeaderHeights.Add(36);
            this.grdOCS0503.Name = "grdOCS0503";
            this.grdOCS0503.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0503.ParamList")));
            this.grdOCS0503.QuerySQL = resources.GetString("grdOCS0503.QuerySQL");
            this.grdOCS0503.Rows = 2;
            this.grdOCS0503.ToolTipActive = true;
            this.grdOCS0503.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdOCS0503_GridButtonClick);
            this.grdOCS0503.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0503_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "io_gubun";
            this.xEditGridCell1.CellWidth = 120;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "O";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "I";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "req_date";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "jinryo_pre_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 96;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "req_gwa";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "req_doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "app_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 103;
            this.xEditGridCell7.Col = 8;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "consult_gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "consult_doctor";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "req_gwa_name";
            this.xEditGridCell10.CellWidth = 116;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "req_doctor_name";
            this.xEditGridCell11.CellWidth = 109;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdatable = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "consult_gwa_name";
            this.xEditGridCell12.CellWidth = 103;
            this.xEditGridCell12.Col = 6;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsUpdatable = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "consult_doctor_name";
            this.xEditGridCell13.CellWidth = 108;
            this.xEditGridCell13.Col = 7;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsUpdatable = false;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell14.ButtonImage")));
            this.xEditGridCell14.ButtonText = "依頼";
            this.xEditGridCell14.CellName = "request_info";
            this.xEditGridCell14.CellWidth = 100;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell15.ButtonImage")));
            this.xEditGridCell15.ButtonText = "返信";
            this.xEditGridCell15.CellName = "answer_info";
            this.xEditGridCell15.CellWidth = 100;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            // 
            // OCS0503Q01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdOCS0503);
            this.Controls.Add(this.xPanel6);
            this.Controls.Add(this.xPanel3);
            this.Name = "OCS0503Q01";
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBunho)).EndInit();
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0503)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]

		protected override void OnLoad(EventArgs e)
		{	
			base.OnLoad (e);

			InitialDesign();
		    
			PostCallHelper.PostCall(new PostMethod(PostLoad));

            if (!NetInfo.Language.Equals(LangMode.Jr))
            {                
                this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            }
		}
        
		/// <summary>
		/// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
		/// </summary>
		private void InitialDesign()
		{
			
		}

		private void PostLoad()
		{	
			dpkFrom_date.SetDataValue(EnvironInfo.GetSysDate().AddMonths(-3));
			dpkTo_date.SetDataValue(EnvironInfo.GetSysDate());

			XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
			if (patientInfo != null)
			{
				this.pbBunho.SetPatientID(patientInfo.BunHo);
			}
		}

	
		#endregion

		#region [Control Event]

		private void dpkFrom_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            grdOCS0503.QueryLayout(false);
		}

		private void dpkTo_date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            grdOCS0503.QueryLayout(false);
		}

		private void pbBunho_PatientSelected(object sender, System.EventArgs e)
        {
            grdOCS0503.QueryLayout(false);
		}

		private void pbBunho_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.grdOCS0503.Reset();		
		}

		#endregion

		#region [grid Event]

		private void grdOCS0503_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			if(e.ColName == "request_info")
			{
				if(e.RowNumber < 0) return;

				string bunho      = grdOCS0503.GetItemString(e.RowNumber, "bunho");
				string req_gwa    = grdOCS0503.GetItemString(e.RowNumber, "req_gwa");
				string req_doctor = grdOCS0503.GetItemString(e.RowNumber, "req_doctor");
				string req_date   = grdOCS0503.GetItemString(e.RowNumber, "req_date");

				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add("bunho"     , bunho);
				openParams.Add("req_gwa"   , req_gwa);
				openParams.Add("req_doctor", req_doctor);
				openParams.Add("req_date"  , req_date);
				XScreen.OpenScreenWithParam( this, "OCSA", "OCS0503U00", ScreenOpenStyle.ResponseFixed, openParams);
			}
			else if(e.ColName == "answer_info")
			{
				if(e.RowNumber < 0) return;

				string bunho          = grdOCS0503.GetItemString(e.RowNumber, "bunho");
				string consult_gwa    = grdOCS0503.GetItemString(e.RowNumber, "consult_gwa");
				string consult_doctor = grdOCS0503.GetItemString(e.RowNumber, "consult_doctor");
				string req_date       = grdOCS0503.GetItemString(e.RowNumber, "jinryo_pre_date");

				CommonItemCollection openParams  = new CommonItemCollection();
				openParams.Add("bunho"         , bunho);
				openParams.Add("consult_gwa"   , consult_gwa);
				openParams.Add("consult_doctor", consult_doctor);
				openParams.Add("req_date"      , req_date);
				XScreen.OpenScreenWithParam( this, "OCSA", "OCS0503U01", ScreenOpenStyle.ResponseFixed, openParams);
			}
		}

		#endregion

        #region grdOCS0503 QueryStarting 바인드변수 설정
        private void grdOCS0503_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0503.SetBindVarValue("f_bunho",     pbBunho.BunHo);
            grdOCS0503.SetBindVarValue("f_from_date", dpkFrom_date.GetDataValue());
            grdOCS0503.SetBindVarValue("f_to_date",   dpkTo_date.GetDataValue());
            grdOCS0503.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }
        #endregion

        #region Connect to cloud service: get data for grdOCS0503
        /// <summary>
        /// grdOCS0503_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> grdOCS0503_ExecuteQuery(BindVarCollection varCollection)
	    {
	        IList<object[]> lstObject = new List<object[]>();
	        OcsaOCS0503Q01ListDataArgs ocs0503Q01ListDataArgs = new OcsaOCS0503Q01ListDataArgs();
	        ocs0503Q01ListDataArgs.Bunho = varCollection["f_bunho"].VarValue;
	        ocs0503Q01ListDataArgs.FromDate = varCollection["f_from_date"].VarValue;
	        ocs0503Q01ListDataArgs.ToDate = varCollection["f_to_date"].VarValue;
	        OcsaOCS0503Q01ListDataResult ocs0503Q01ListDataResult =
	            CloudService.Instance.Submit<OcsaOCS0503Q01ListDataResult, OcsaOCS0503Q01ListDataArgs>(
	                ocs0503Q01ListDataArgs);
	        if (ocs0503Q01ListDataResult != null && ocs0503Q01ListDataResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            List<OcsaOCS0503Q01ListDataInfo> lstDataInfo = ocs0503Q01ListDataResult.ListItem;
	            if (lstDataInfo != null && lstDataInfo.Count > 0)
	            {
	                foreach (OcsaOCS0503Q01ListDataInfo dataInfo in lstDataInfo)
	                {
	                    lstObject.Add(new object[]
	                    {
	                        dataInfo.IoGubun,
	                        dataInfo.Bunho,
	                        dataInfo.ReqDate,
	                        dataInfo.JinryoPreDate,
	                        dataInfo.ReqGwa,
	                        dataInfo.ReqDoctor,
	                        dataInfo.AppDate,
	                        dataInfo.ConsultGwa,
	                        dataInfo.ConsultDoctor,
	                        dataInfo.ReqGwaName,
	                        dataInfo.ReqDoctorName,
	                        dataInfo.ConsultGwaName,
	                        dataInfo.ConsultDoctorName
	                    });
	                }
	            }
	        }
	        return lstObject;
        }
        #endregion
    }
}

