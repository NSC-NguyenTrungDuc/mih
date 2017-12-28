#region 사용 NameSpace 지정
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.SCHS.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Caching;
using System.Reflection;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;
#endregion

namespace IHIS.SCHS
{
	/// <summary>
    /// SCH0201Q12에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201Q12 : XScreen
    {
        private XPanel xPanel1;
        private XDatePicker dtpNaewonDate;
        private XEditGrid grdList;
		private XEditGridCell XEditGridCell1;
		private XEditGridCell XEditGridCell2;
        private XEditGridCell XEditGridCell3;
		private XEditGridCell XEditGridCell5;
        private XEditGridCell XEditGridCell6;
		private XEditGridCell XEditGridCell8;
		private XEditGridCell XEditGridCell9;
		private XEditGridCell XEditGridCell10;
		private XEditGridCell XEditGridCell11;
        private XEditGridCell XEditGridCell12;
        private XButtonList btnList;
        private XLabel xLabel2;
        private XDictComboBox cboGwa;
        private XEditGridCell xEditGridCell7;
        private XLabel xLabel3;
        private XDisplayBox dbxDoctorName;
        private XFindBox fbxDoctor;
        private XFindWorker fwkDoctor;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XPanel xPanel2;
        private XLabel xLabel4;
        private XCheckBox cbxDoctorPrint;
        private XPatientBox paBox;
        private XButton xBtnAfter;
        private XButton xBtnBefore;
        private XEditGridCell xEditGridCell4;
        private XButton xBtnReset;
        private XButton btnClear;
        private XLabel xLabel12;
        private XDictComboBox cboGumsa;
        private XEditGridCell xEditGridCell13;
        private XEditGrid grdPkschList;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XButton btnUpReserData;
        private XButton xBtnAllNotAct;
        private XLabel xLabel1;
        private XButton xBtnConfirm;
		//private IHIS.Framework.DataServiceDynSO dsvPrintName;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private Container components = null;

		public SCH0201Q12()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            this.cboGumsa.ExecuteQuery = GetGumsaCboSource;
            this.cboGwa.ExecuteQuery = GetGwaCboSource;
            this.grdList.ExecuteQuery = GetGrdList;

            this.fwkDoctor.ParamList = new List<String>(new String[] { "f_gwa", "f_find1", "f_hosp_code" });
            this.fwkDoctor.ExecuteQuery = GetFwkDoctor;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201Q12));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xBtnAllNotAct = new IHIS.Framework.XButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.btnClear = new IHIS.Framework.XButton();
            this.cboGumsa = new IHIS.Framework.XDictComboBox();
            this.xBtnReset = new IHIS.Framework.XButton();
            this.xBtnBefore = new IHIS.Framework.XButton();
            this.xBtnAfter = new IHIS.Framework.XButton();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.fbxDoctor = new IHIS.Framework.XFindBox();
            this.fwkDoctor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpNaewonDate = new IHIS.Framework.XDatePicker();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.XEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdPkschList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxDoctorPrint = new IHIS.Framework.XCheckBox();
            this.btnUpReserData = new IHIS.Framework.XButton();
            this.xBtnConfirm = new IHIS.Framework.XButton();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPkschList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "뒤로.gif");
            this.ImageList.Images.SetKeyName(1, "앞으로.gif");
            this.ImageList.Images.SetKeyName(2, "검사예약.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.xBtnAllNotAct);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.btnClear);
            this.xPanel1.Controls.Add(this.cboGumsa);
            this.xPanel1.Controls.Add(this.xBtnReset);
            this.xPanel1.Controls.Add(this.xBtnBefore);
            this.xPanel1.Controls.Add(this.xBtnAfter);
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Controls.Add(this.dbxDoctorName);
            this.xPanel1.Controls.Add(this.fbxDoctor);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.cboGwa);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xBtnAllNotAct
            // 
            this.xBtnAllNotAct.AccessibleDescription = null;
            this.xBtnAllNotAct.AccessibleName = null;
            resources.ApplyResources(this.xBtnAllNotAct, "xBtnAllNotAct");
            this.xBtnAllNotAct.BackgroundImage = null;
            this.xBtnAllNotAct.Name = "xBtnAllNotAct";
            this.xBtnAllNotAct.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.xBtnAllNotAct.Tag = "1";
            this.xBtnAllNotAct.Click += new System.EventHandler(this.xBtnAllNotAct_Click);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // btnClear
            // 
            this.btnClear.AccessibleDescription = null;
            this.btnClear.AccessibleName = null;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.BackgroundImage = null;
            this.btnClear.Image = global::IHIS.SCHS.Properties.Resources.행삭제;
            this.btnClear.Name = "btnClear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cboGumsa
            // 
            this.cboGumsa.AccessibleDescription = null;
            this.cboGumsa.AccessibleName = null;
            resources.ApplyResources(this.cboGumsa, "cboGumsa");
            this.cboGumsa.BackgroundImage = null;
            this.cboGumsa.ExecuteQuery = null;
            this.cboGumsa.Name = "cboGumsa";
            this.cboGumsa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGumsa.ParamList")));
            this.cboGumsa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGumsa.UserSQL = resources.GetString("cboGumsa.UserSQL");
            this.cboGumsa.SelectionChangeCommitted += new System.EventHandler(this.cboGumsa_SelectionChangeCommitted);
            // 
            // xBtnReset
            // 
            this.xBtnReset.AccessibleDescription = null;
            this.xBtnReset.AccessibleName = null;
            resources.ApplyResources(this.xBtnReset, "xBtnReset");
            this.xBtnReset.BackgroundImage = null;
            this.xBtnReset.Name = "xBtnReset";
            this.xBtnReset.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.xBtnReset.Tag = "3";
            this.xBtnReset.Click += new System.EventHandler(this.xBtnReset_Click);
            // 
            // xBtnBefore
            // 
            this.xBtnBefore.AccessibleDescription = null;
            this.xBtnBefore.AccessibleName = null;
            resources.ApplyResources(this.xBtnBefore, "xBtnBefore");
            this.xBtnBefore.BackgroundImage = null;
            this.xBtnBefore.Image = ((System.Drawing.Image)(resources.GetObject("xBtnBefore.Image")));
            this.xBtnBefore.Name = "xBtnBefore";
            this.xBtnBefore.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.xBtnBefore.Tag = "2";
            this.xBtnBefore.Click += new System.EventHandler(this.xBtnBefore_Click);
            // 
            // xBtnAfter
            // 
            this.xBtnAfter.AccessibleDescription = null;
            this.xBtnAfter.AccessibleName = null;
            resources.ApplyResources(this.xBtnAfter, "xBtnAfter");
            this.xBtnAfter.BackgroundImage = null;
            this.xBtnAfter.Image = ((System.Drawing.Image)(resources.GetObject("xBtnAfter.Image")));
            this.xBtnAfter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xBtnAfter.Name = "xBtnAfter";
            this.xBtnAfter.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.xBtnAfter.Tag = "4";
            this.xBtnAfter.Click += new System.EventHandler(this.xBtnAfter_Click);
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // dbxDoctorName
            // 
            this.dbxDoctorName.AccessibleDescription = null;
            this.dbxDoctorName.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctorName, "dbxDoctorName");
            this.dbxDoctorName.Image = null;
            this.dbxDoctorName.Name = "dbxDoctorName";
            // 
            // fbxDoctor
            // 
            this.fbxDoctor.AccessibleDescription = null;
            this.fbxDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxDoctor, "fbxDoctor");
            this.fbxDoctor.BackgroundImage = null;
            this.fbxDoctor.FindWorker = this.fwkDoctor;
            this.fbxDoctor.Name = "fbxDoctor";
            this.fbxDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxDoctor_DataValidating);
            // 
            // fwkDoctor
            // 
            this.fwkDoctor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkDoctor.ExecuteQuery = null;
            this.fwkDoctor.FormText = "検索";
            this.fwkDoctor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkDoctor.ParamList")));
            this.fwkDoctor.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkDoctor.ServerFilter = true;
            this.fwkDoctor.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkDoctor_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "user_code";
            this.findColumnInfo3.ColWidth = 99;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "user_name";
            this.findColumnInfo4.ColWidth = 273;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // cboGwa
            // 
            this.cboGwa.AccessibleDescription = null;
            this.cboGwa.AccessibleName = null;
            resources.ApplyResources(this.cboGwa, "cboGwa");
            this.cboGwa.BackgroundImage = null;
            this.cboGwa.ExecuteQuery = null;
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGwa.ParamList")));
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.UserSQL = resources.GetString("cboGwa.UserSQL");
            this.cboGwa.SelectionChangeCommitted += new System.EventHandler(this.cboGwa_SelectionChangeCommitted);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpNaewonDate
            // 
            this.dtpNaewonDate.AccessibleDescription = null;
            this.dtpNaewonDate.AccessibleName = null;
            resources.ApplyResources(this.dtpNaewonDate, "dtpNaewonDate");
            this.dtpNaewonDate.BackgroundImage = null;
            this.dtpNaewonDate.IsVietnameseYearType = false;
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            this.dtpNaewonDate.ReadOnly = true;
            this.dtpNaewonDate.TabStop = false;
            this.dtpNaewonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewonDate_DataValidating);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.XEditGridCell1,
            this.XEditGridCell2,
            this.XEditGridCell3,
            this.xEditGridCell7,
            this.XEditGridCell5,
            this.XEditGridCell6,
            this.xEditGridCell13,
            this.XEditGridCell8,
            this.XEditGridCell9,
            this.XEditGridCell10,
            this.XEditGridCell11,
            this.XEditGridCell12,
            this.xEditGridCell16,
            this.xEditGridCell15});
            this.grdList.ColPerLine = 9;
            this.grdList.Cols = 10;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(30);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.QuerySQL = resources.GetString("grdList.QuerySQL");
            this.grdList.ReadOnly = true;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdList.ToolTipActive = true;
            this.grdList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdList_QueryEnd);
            this.grdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "kizyun_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 150;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.HeaderImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // XEditGridCell1
            // 
            this.XEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell1.CellName = "gwa";
            this.XEditGridCell1.Col = -1;
            this.XEditGridCell1.ExecuteQuery = null;
            this.XEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell1, "XEditGridCell1");
            this.XEditGridCell1.IsVisible = false;
            this.XEditGridCell1.Row = -1;
            this.XEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XEditGridCell2
            // 
            this.XEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell2.CellLen = 30;
            this.XEditGridCell2.CellName = "gwa_name";
            this.XEditGridCell2.Col = 3;
            this.XEditGridCell2.ExecuteQuery = null;
            this.XEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell2, "XEditGridCell2");
            this.XEditGridCell2.IsReadOnly = true;
            this.XEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // XEditGridCell3
            // 
            this.XEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell3.CellName = "doctor";
            this.XEditGridCell3.CellWidth = 121;
            this.XEditGridCell3.Col = -1;
            this.XEditGridCell3.ExecuteQuery = null;
            this.XEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell3, "XEditGridCell3");
            this.XEditGridCell3.IsVisible = false;
            this.XEditGridCell3.Row = -1;
            this.XEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellLen = 30;
            this.xEditGridCell7.CellName = "doctor_name";
            this.xEditGridCell7.CellWidth = 160;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // XEditGridCell5
            // 
            this.XEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell5.CellName = "hangmog_code";
            this.XEditGridCell5.Col = -1;
            this.XEditGridCell5.ExecuteQuery = null;
            this.XEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell5, "XEditGridCell5");
            this.XEditGridCell5.IsVisible = false;
            this.XEditGridCell5.Row = -1;
            this.XEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // XEditGridCell6
            // 
            this.XEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell6.CellLen = 50;
            this.XEditGridCell6.CellName = "hangmog_name";
            this.XEditGridCell6.CellWidth = 201;
            this.XEditGridCell6.Col = 5;
            this.XEditGridCell6.ExecuteQuery = null;
            this.XEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell6, "XEditGridCell6");
            this.XEditGridCell6.IsReadOnly = true;
            this.XEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "jundal_table";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // XEditGridCell8
            // 
            this.XEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell8.CellName = "jundal_part";
            this.XEditGridCell8.Col = -1;
            this.XEditGridCell8.ExecuteQuery = null;
            this.XEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell8, "XEditGridCell8");
            this.XEditGridCell8.IsVisible = false;
            this.XEditGridCell8.Row = -1;
            this.XEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // XEditGridCell9
            // 
            this.XEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell9.CellLen = 30;
            this.XEditGridCell9.CellName = "jundal_part_name";
            this.XEditGridCell9.CellWidth = 150;
            this.XEditGridCell9.Col = 6;
            this.XEditGridCell9.ExecuteQuery = null;
            this.XEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell9, "XEditGridCell9");
            this.XEditGridCell9.IsReadOnly = true;
            this.XEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // XEditGridCell10
            // 
            this.XEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell10.CellName = "reser_time";
            this.XEditGridCell10.CellWidth = 150;
            this.XEditGridCell10.Col = 8;
            this.XEditGridCell10.ExecuteQuery = null;
            this.XEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell10, "XEditGridCell10");
            this.XEditGridCell10.IsReadOnly = true;
            this.XEditGridCell10.Mask = "##:##";
            this.XEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XEditGridCell11
            // 
            this.XEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell11.CellName = "reser_yn";
            this.XEditGridCell11.CellWidth = 150;
            this.XEditGridCell11.Col = 7;
            this.XEditGridCell11.ExecuteQuery = null;
            this.XEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell11, "XEditGridCell11");
            this.XEditGridCell11.IsReadOnly = true;
            this.XEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // XEditGridCell12
            // 
            this.XEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell12.CellName = "act_yn";
            this.XEditGridCell12.CellWidth = 60;
            this.XEditGridCell12.Col = 9;
            this.XEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.XEditGridCell12.ExecuteQuery = null;
            this.XEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.XEditGridCell12, "XEditGridCell12");
            this.XEditGridCell12.IsReadOnly = true;
            this.XEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.XEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "order_date";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell16.CellWidth = 100;
            this.xEditGridCell16.Col = 1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.SuppressRepeating = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "pksch";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.grdList);
            this.xPanel2.Controls.Add(this.grdPkschList);
            this.xPanel2.Controls.Add(this.xPanel1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // grdPkschList
            // 
            resources.ApplyResources(this.grdPkschList, "grdPkschList");
            this.grdPkschList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14});
            this.grdPkschList.ColPerLine = 1;
            this.grdPkschList.Cols = 1;
            this.grdPkschList.ExecuteQuery = null;
            this.grdPkschList.FixedRows = 1;
            this.grdPkschList.HeaderHeights.Add(18);
            this.grdPkschList.Name = "grdPkschList";
            this.grdPkschList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPkschList.ParamList")));
            this.grdPkschList.Rows = 2;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "pksch";
            this.xEditGridCell14.CellWidth = 89;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XRotatorGradientStartColor;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // cbxDoctorPrint
            // 
            this.cbxDoctorPrint.AccessibleDescription = null;
            this.cbxDoctorPrint.AccessibleName = null;
            resources.ApplyResources(this.cbxDoctorPrint, "cbxDoctorPrint");
            this.cbxDoctorPrint.BackgroundImage = null;
            this.cbxDoctorPrint.Checked = true;
            this.cbxDoctorPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxDoctorPrint.Name = "cbxDoctorPrint";
            this.cbxDoctorPrint.UseVisualStyleBackColor = false;
            this.cbxDoctorPrint.CheckedChanged += new System.EventHandler(this.cbxDoctorPrint_CheckedChanged);
            // 
            // btnUpReserData
            // 
            this.btnUpReserData.AccessibleDescription = null;
            this.btnUpReserData.AccessibleName = null;
            resources.ApplyResources(this.btnUpReserData, "btnUpReserData");
            this.btnUpReserData.BackgroundImage = null;
            this.btnUpReserData.ImageIndex = 2;
            this.btnUpReserData.ImageList = this.ImageList;
            this.btnUpReserData.Name = "btnUpReserData";
            this.btnUpReserData.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnUpReserData.Click += new System.EventHandler(this.btnUpReserData_Click);
            // 
            // xBtnConfirm
            // 
            this.xBtnConfirm.AccessibleDescription = null;
            this.xBtnConfirm.AccessibleName = null;
            resources.ApplyResources(this.xBtnConfirm, "xBtnConfirm");
            this.xBtnConfirm.BackgroundImage = null;
            this.xBtnConfirm.ImageIndex = 2;
            this.xBtnConfirm.ImageList = this.ImageList;
            this.xBtnConfirm.Name = "xBtnConfirm";
            this.xBtnConfirm.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.xBtnConfirm.Click += new System.EventHandler(this.xBtnConfirm_Click);
            // 
            // SCH0201Q12
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xBtnConfirm);
            this.Controls.Add(this.btnUpReserData);
            this.Controls.Add(this.dtpNaewonDate);
            this.Controls.Add(this.cbxDoctorPrint);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xLabel4);
            this.Name = "SCH0201Q12";
            this.Load += new System.EventHandler(this.SCH0201Q12_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.SCH0201Q12_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPkschList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Screen 변수 

        // 患者番号
        private string mBunho = "";

        // PKOUT1001
        private string mFkout1001 = "";

        // 初期画面リスト
        /*「A」：未実施、「P」：過去、「C」：当日、「F」：未来*/
        private string mInitBtn = "";

        // 画面フラグ
        private bool mIsAutoClose = false;

        // ボタン状態フラグ　(「P」：過去、「C」：当日、「F」：未来)
        private string statFlg = null;

        /// <summary>
        /// Gumsa cbo source
        /// </summary>
        private IList<object[]> _cboGumsaObj;

        /// <summary>
        /// Gwa cbo source
        /// </summary>
        private IList<object[]> _cboGwaObj;

        /// <summary>
        /// A list object return from Update action
        /// </summary>
        private IList<object[]> _grdListExist = new List<object[]>();

        /// <summary>
        /// Cache key
        /// </summary>
        private const string CACHE_COMBO_KEYS = "SCHS.SCH0201Q12.Cmb";

		#endregion

		#region [Screen Load]
        private void SCH0201Q12_Load(object sender, EventArgs e)
		{
            if (OpenParam != null)
			{
                if (OpenParam.Contains("bunho"))
                {
                    mBunho = OpenParam["bunho"].ToString();
                }

                if (OpenParam.Contains("gwa"))
                {
                    cboGwa.SetEditValue(OpenParam["gwa"].ToString());
                    cboGwa.AcceptData();
                }

                if (OpenParam.Contains("naewon_date"))
                {
                    dtpNaewonDate.SetDataValue(OpenParam["naewon_date"].ToString());
                }

                if (OpenParam.Contains("initial_btn"))
                    mInitBtn = OpenParam["initial_btn"].ToString();
                else
                    mInitBtn = "A";

                if (OpenParam.Contains("fkout1001"))
                {
                    mFkout1001 = OpenParam["fkout1001"].ToString();
                }

                if (OpenParam.Contains("auto_close"))
                {
                    ParentForm.WindowState = FormWindowState.Minimized;
                    mIsAutoClose = (bool)OpenParam["auto_close"];
                }

                if (mIsAutoClose)
                {
                    AutoCloseRoutine();
                }
			}

            InitialDesign();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
		}
		#endregion

        private void SCH0201Q12_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 
          //  Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
          //  this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Width, (rc.Height - 350));

            // Do not change the order of this loading
            this.LoadCombosData();
            this.cboGumsa.SetDictDDLB();
            this.cboGwa.SetDictDDLB();
            
        }

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>
        private void InitialDesign()
        {
            // 여기서 처리 하세요
        }

        private void PostLoad()
        {
            InitScreen();

            if (TypeCheck.IsNull(mBunho))
            {
                XPatientInfo patientInfo = GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    paBox.SetPatientID(patientInfo.BunHo);
                    btnList.Focus();
                }
            }
            else
            {
                paBox.SetPatientID(mBunho);
                btnList.Focus();
            }
        }

		#region [set Init]
		private void InitScreen ()
		{
            if(dtpNaewonDate.GetDataValue().Length == 0) dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-","/"));
            
            fbxDoctor.SetDataValue("");
            dbxDoctorName.SetDataValue("");
            if (cboGwa.ComboItems.Count > 0)
            {
                cboGwa.SelectedIndex = 0;
            }
            if (mInitBtn != "")
                statFlg = mInitBtn;
            else
                statFlg = "A";

            cboGumsa.SelectedIndex = 0;
		}
        private void CreatScreen()
        {
            dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            if (cboGwa.ComboItems.Count > 0)
            {
                cboGwa.SelectedIndex = 0;
            }
            fbxDoctor.SetDataValue("");
            dbxDoctorName.SetDataValue("");
            grdList.Reset();

            statFlg = "A";

            btnList.PerformClick(FunctionType.Query);
        }
		private void AutoCloseRoutine ()
		{
			btnList.PerformClick(FunctionType.Query);
			btnList.PerformClick(FunctionType.Print);
			btnList.PerformClick(FunctionType.Close);
		}
		#endregion

        #region [paBox_PatientSelected] 患者番号イベント
        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            if (paBox.BunHo.ToString() != "")
                grdList.QueryLayout(true);
        }
        #endregion

        #region DataLoad
        private void LoadData()
		{
            grdList.QueryLayout(true);
		}
		#endregion

		#region [XButtonList]
		private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
		{
			AcceptData();

			switch (e.Func)
			{
				case FunctionType.Query :
					e.IsBaseCall = false;
                    LoadData();
					break;
				
				case FunctionType.Reset :
					e.IsBaseCall = false;
                    CreatScreen();
					break;
			}
            paBox.Focus();
		}
		#endregion

        #region [grdList_QueryStarting]
        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            if (TypeCheck.IsNull(statFlg))
                XMessageBox.Show("Error");

            // ボタン状態セット
            if (statFlg.Equals("A"))
                grdList.SetBindVarValue("f_stat_flg", "A");

            if(statFlg.Equals("P"))
                grdList.SetBindVarValue("f_stat_flg", "P");

            if (statFlg.Equals("C"))
                grdList.SetBindVarValue("f_stat_flg", "C");

            if (statFlg.Equals("F"))
                grdList.SetBindVarValue("f_stat_flg", "F");

            // ボタン色セット
            changeBtnSelectModeColor(statFlg);

            grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdList.SetBindVarValue("f_bunho", paBox.BunHo);
            grdList.SetBindVarValue("f_naewon_date", dtpNaewonDate.GetDataValue());

            grdList.SetBindVarValue("f_reser_gubun", cboGumsa.GetDataValue());
            
            grdList.SetBindVarValue("f_gwa", cboGwa.GetDataValue());

            if (fbxDoctor.GetDataValue().Equals(""))
                grdList.SetBindVarValue("f_doctor", fbxDoctor.GetDataValue());
            else
                grdList.SetBindVarValue("f_doctor", cboGwa.GetDataValue() + fbxDoctor.GetDataValue());
        }
        #endregion

        #region [grdList_QueryEnd]
        private void grdList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            // 患者状態セット
            for (int i = 0; i < grdList.RowCount; i++)
            {
                string curState = grdList.GetItemString(i, "reser_yn");

                if (curState.Equals("A"))
                {
                    grdList.SetItemValue(i, "reser_yn", Resources.Waiting);
                }

                if (curState.Equals("N"))
                {
                    grdList.SetItemValue(i, "reser_yn", Resources.NotYet);
                }

                if (curState.Equals("Y"))
                {
                    grdList.SetItemValue(i, "reser_yn", Resources.Pre);
                }
            }

            // GRIDのFONT色を元に戻す。
            grdList.ResetUpdate();
        }
        #endregion

        #region [changeBtnSelectModeColor] ボタン色セット
        private void changeBtnSelectModeColor(string mode)
        {
            if (TypeCheck.IsNull(mode))
                return;

            if (mode.Equals("A"))
            {
                xBtnAllNotAct.Scheme = XButtonSchemes.HotPink;
                xBtnBefore.Scheme = XButtonSchemes.SkyBlue;
                xBtnReset.Scheme = XButtonSchemes.SkyBlue;
                xBtnAfter.Scheme = XButtonSchemes.SkyBlue;
            }

            if (mode.Equals("P"))
            {
                xBtnAllNotAct.Scheme = XButtonSchemes.SkyBlue;
                xBtnBefore.Scheme = XButtonSchemes.HotPink;
                xBtnReset.Scheme = XButtonSchemes.SkyBlue;
                xBtnAfter.Scheme = XButtonSchemes.SkyBlue;
            }

            if (mode.Equals("C"))
            {
                xBtnAllNotAct.Scheme = XButtonSchemes.SkyBlue;
                xBtnBefore.Scheme = XButtonSchemes.SkyBlue;
                xBtnReset.Scheme = XButtonSchemes.HotPink;
                xBtnAfter.Scheme = XButtonSchemes.SkyBlue;
            }

            if (mode.Equals("F"))
            {
                xBtnAllNotAct.Scheme = XButtonSchemes.SkyBlue;
                xBtnBefore.Scheme = XButtonSchemes.SkyBlue;
                xBtnReset.Scheme = XButtonSchemes.SkyBlue;
                xBtnAfter.Scheme = XButtonSchemes.HotPink;
            }
        }
        #endregion

        #region [fwkDoctor] 医師リスト検索関連
        private void fwkDoctor_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkDoctor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkDoctor.SetBindVarValue("f_gwa", cboGwa.GetDataValue());
        }

        private void fbxDoctor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                dbxDoctorName.SetDataValue("");
                if (cboGwa.GetDataValue() == "%")
                {
                    cbxDoctorPrint.Checked = true;
                }
            }
            else
            {
//                SingleLayout layCommon = new SingleLayout();

//                layCommon.QuerySQL = @"SELECT DISTINCT A.DOCTOR_NAME
//                                     FROM BAS0270 A
//                                    WHERE A.HOSP_CODE  = :f_hosp_code
//                                      AND A.DOCTOR_GWA LIKE :f_gwa || '%'
//                                      AND A.SABUN      = :f_doctor
//                                      AND A.START_DATE = ( SELECT MAX(B.START_DATE)
//                                                             FROM BAS0270 B
//                                                           WHERE B.HOSP_CODE = A.HOSP_CODE
//                                                             AND B.DOCTOR = A.DOCTOR)
//                                      AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > TRUNC(SYSDATE) ";
//                layCommon.LayoutItems.Add("doctor_name");
//                layCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                layCommon.SetBindVarValue("f_doctor", e.DataValue);
//                layCommon.SetBindVarValue("f_gwa", cboGwa.GetDataValue());
//                if (layCommon.QueryLayout())
//                {
//                    dbxDoctorName.SetDataValue(layCommon.GetItemValue("doctor_name").ToString());
//                }

                // Updated code
                DoValidateFbxDoctor(e.DataValue);

                cbxDoctorPrint.Checked = false;
            }

            btnList.PerformClick(FunctionType.Query);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            fbxDoctor.Clear();
            dbxDoctorName.Text = "";

            btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        private void dtpNaewonDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);

            //this.isColVisible(this.dtpNaewonDate.GetDataValue());
        }

        private void cbxDoctorPrint_CheckedChanged(object sender, EventArgs e)
        {
            bool bolval = true;
            if (cbxDoctorPrint.Checked)
            {
                cboGwa.SelectedIndex = 0;
                fbxDoctor.SetDataValue("");
                dbxDoctorName.SetDataValue("");
                btnList.PerformClick(FunctionType.Query);
                bolval = false;
            }
            foreach (XGridCell cell in grdList.CellInfos)
            {
                cell.EnableSort = bolval;
            }            
        }

        private void cboGwa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fbxDoctor.SetDataValue("");
            dbxDoctorName.SetDataValue("");
            
            if (cboGwa.GetDataValue() == "%")
            {
                cbxDoctorPrint.Checked = true;
            }
            else
            {
                cbxDoctorPrint.Checked = false;
                btnList.PerformClick(FunctionType.Query);
            }
        }

        #region [xBtnBefore, xBtnReset, xBtnAfter] ボタンCLICKイベント
        private void xBtnAllNotAct_Click(object sender, EventArgs e)
        {
            statFlg = "A";

            btnList.PerformClick(FunctionType.Query);
        }

        private void xBtnBefore_Click(object sender, EventArgs e)
        {
            statFlg = "P";

            btnList.PerformClick(FunctionType.Query);
            
            //this.isColVisible("9999/99/99");
        }

        private void xBtnReset_Click(object sender, EventArgs e)
        {
            statFlg = "C";

            btnList.PerformClick(FunctionType.Query);

            //this.isColVisible(this.dtpNaewonDate.GetDataValue());
        }

        private void xBtnAfter_Click(object sender, EventArgs e)
        {
            statFlg = "F";

            btnList.PerformClick(FunctionType.Query);
           
        }
        #endregion

        #region [isColVisible] GRID項目表示/非表示設定
        private void isColVisible(string strDate)
        {
            string currentDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/");
            
            if (strDate.Equals(currentDate))
            {
                grdList.CellInfos["kizyun_date"].CellWidth = 1;
                grdList.AutoSizeColumn(1, 1);
                grdList.Refresh();
            }
            else
            {
                grdList.CellInfos["kizyun_date"].CellWidth = 95;
                grdList.AutoSizeColumn(1, 95);
                grdList.Refresh();
            }
        }
        #endregion

        #region [cboGumsa_SelectionChangeCommitted 予約区分変更]
        private void cboGumsa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [grdList_RowFocusChanged 予約グループ選択]
        private void grdList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            string gwa = grdList.GetItemString(e.CurrentRow, "gwa");
            string doctor = grdList.GetItemString(e.CurrentRow, "doctor");
            string jundal_table = grdList.GetItemString(e.CurrentRow, "jundal_table");
            string jundal_part = grdList.GetItemString(e.CurrentRow, "jundal_part");
            string kizyun_date = grdList.GetItemString(e.CurrentRow, "kizyun_date");
            string reser_time = grdList.GetItemString(e.CurrentRow, "reser_time");

            grdPkschList.Reset();

            int newRow = 0;

            for (int i = 0; i < grdList.RowCount; i++)
            {
                if (grdList.GetItemString(i, "gwa").Equals(gwa) &&
                    grdList.GetItemString(i, "doctor").Equals(doctor) &&
                    grdList.GetItemString(i, "jundal_table").Equals(jundal_table) &&
                    grdList.GetItemString(i, "jundal_part").Equals(jundal_part) &&
                    grdList.GetItemString(i, "kizyun_date").Equals(kizyun_date) &&
                    grdList.GetItemString(i, "reser_time").Equals(reser_time))
                {
                    grdList.SelectRow(i);

                    grdPkschList.InsertRow(newRow);

                    grdPkschList.SetItemValue(newRow, "pksch", grdList.GetItemString(i, "pksch"));

                    newRow = newRow + 1;
                }
            }
        }
        #endregion

        #region [btnUpReserData_Click 今日に予約日付変更]
        private void btnUpReserData_Click(object sender, EventArgs e)
        {
            if (grdList.RowCount < 1) return;
            
            // Updated code
            DoUpdate();

            #region comments
            //XMessageBox.Show(this.mFkout1001);

//            string gubun = grdList.GetItemString(grdList.CurrentRowNumber, "jundal_table");

//            string jundal_part_name = grdList.GetItemString(grdList.CurrentRowNumber, "jundal_part_name");

//            BindVarCollection bindVals = new BindVarCollection();

//            string cmdText = "";

//            if (XMessageBox.Show("[" + jundal_part_name + Resources.SCH0201Q12_MSG, Resources.SCH0201Q12_XN, MessageBoxButtons.YesNo) == DialogResult.No)
//                return;
//            else
//            {
//                if (gubun.Equals("INJ"))
//                {
//                    //UPDATE INJ1002

//                    // [PR_SCH_SCH0201_IUD]のパラメタ設定
//                    for (int i = 0; i < grdPkschList.RowCount; i++)
//                    {
//                        bindVals.Clear();

//                        bindVals.Add("q_user_id", UserInfo.UserID);
//                        bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bindVals.Add("f_pkinj1002", grdPkschList.GetItemString(i, "pksch"));
//                        bindVals.Add("f_reser_date", dtpNaewonDate.GetDataValue());

//                        cmdText = @"DECLARE
//                              IO_MSG  VARCHAR(300);
//                              IO_FLAG VARCHAR(1);
//                            BEGIN
//                                 UPDATE INJ1002
//                                    SET RESER_DATE               = TO_DATE(:f_reser_date,'YYYY/MM/DD')
//                                  WHERE HOSP_CODE                = :f_hosp_code
//                                    AND PKINJ1002                = :f_pkinj1002
//                                    AND NVL(ACTING_FLAG, 'N')    = 'N';
//
//                              FOR C1 IN (
//                                SELECT B.FKOCS1003 FKOCS1003
//                                  FROM INJ1001 B,
//                                       INJ1002 A
//                                 WHERE A.HOSP_CODE               = :f_hosp_code
//                                   AND B.HOSP_CODE               = A.HOSP_CODE
//                                   AND A.PKINJ1002               = :f_pkinj1002
//                                   AND B.PKINJ1001               = A.FKINJ1001
//                                   AND NVL(A.ACTING_FLAG, 'N')   = 'N'
//                                   --AND B.ACT_DATE IS NULL  --실행된 오더는 안바뀌게
//                              )LOOP
//                                PR_OCS_UPDATE_HOPE_DATE('O',C1.FKOCS1003 ,TO_DATE(:f_reser_date,'YYYY/MM/DD'),IO_MSG, IO_FLAG);
//                              END LOOP;
//                            END;";

//                        if (!Service.ExecuteNonQuery(cmdText, bindVals))
//                        {
//                            throw new Exception(Service.ErrFullMsg);
//                        }
//                    }
//                }
//                else
//                {
//                    // UPDATE SCH0201

//                    Hashtable inputList = new Hashtable();
//                    Hashtable outputList = new Hashtable();

//                    // [PR_SCH_SCH0201_IUD]のパラメタ設定
//                    for (int i = 0; i < grdPkschList.RowCount; i++)
//                    {
//                        inputList.Clear();
//                        outputList.Clear();

//                        inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
//                        inputList.Add("I_IUD_GUBUN", "U");
//                        inputList.Add("I_FKSCH0201", grdPkschList.GetItemString(i, "pksch"));
//                        inputList.Add("I_RESER_DATE", dtpNaewonDate.GetDataValue());
//                        inputList.Add("I_RESER_TIME", grdList.GetItemString(grdList.CurrentRowNumber, "reser_time"));
//                        inputList.Add("I_INPUT_ID", UserInfo.UserID);

//                        if (!Service.ExecuteProcedure("PR_SCH_SCH0201_IUD", inputList, outputList))
//                        {
//                            throw new Exception(Service.ErrFullMsg);
//                        }
//                        else
//                        {
//                            if (outputList.Count > 0)
//                            {
//                                if (!TypeCheck.IsNull(outputList["IO_ERR"]))
//                                {
//                                    // [PR_SCH_SCH0201_INSERT]のリターン値チェック
//                                    if (outputList["IO_ERR"].ToString().Equals("X"))
//                                    {
//                                        XMessageBox.Show(outputList["IO_ERR"].ToString(), "PR_SCH_SCH0201_IUD", MessageBoxIcon.Error);
//                                        return;
//                                    }

//                                    if (outputList["IO_ERR"].ToString().Equals("0"))
//                                    {
//                                        continue;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }

//                btnList.PerformClick(FunctionType.Query);
//            }

//            // Update KENSA Flag
            //            xBtnConfirm.PerformClick();
            #endregion
        }

        private void xBtnConfirm_Click(object sender, EventArgs e)
        {
            #region comments
            //            BindVarCollection bindVals = new BindVarCollection();

//            string cmdText = "";

//            // Update KENSA Flag
//            bindVals.Clear();
//            bindVals.Add("f_hosp_code", EnvironInfo.HospCode);
//            bindVals.Add("f_pkout1001", mFkout1001);

//            cmdText = @"UPDATE OUT1001 A
//                               SET A.KENSA_YN  = 'N'
//                             WHERE A.HOSP_CODE = :f_hosp_code
//                               AND A.PKOUT1001 = :f_pkout1001
//                           ";

//            if (!Service.ExecuteNonQuery(cmdText, bindVals))
//            {
//                throw new Exception(Service.ErrFullMsg);
            //            }
            #endregion

            if (TypeCheck.IsNull(this.mFkout1001)) return;

            // Updated code
            if (!DoConfirm())
            {
                throw new Exception(Service.ErrFullMsg);
            }
        }
        #endregion

        #region Updated code

        #region LoadCombosData
        /// <summary>
        /// LoadCombosData
        /// </summary>
        private void LoadCombosData()
        {
            List<object[]> cboGumsa = new List<object[]>();
            List<object[]> cboGwa = new List<object[]>();

            SCH0201Q12ComboListResult res = CacheService.Instance.Get<SCH0201Q12ComboListArgs, SCH0201Q12ComboListResult>(new SCH0201Q12ComboListArgs());

            if (null != res)
            {
                foreach (ComboListItemInfo item in res.CboGumsa)
                {
                    cboGumsa.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }

                foreach (ComboListItemInfo item in res.CboGwa)
                {
                    cboGwa.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
            }

            this._cboGumsaObj = cboGumsa;
            this._cboGwaObj = cboGwa;
        }
        #endregion

        #region GetGumsaCboSource
        /// <summary>
        /// GetGumsaCboSource
        /// </summary>
        /// <returns></returns>
        private IList<object[]> GetGumsaCboSource(BindVarCollection bvc)
        {
            return this._cboGumsaObj;
        }
        #endregion

        #region GetGwaCboSource
        /// <summary>
        /// GetGwaCboSource
        /// </summary>
        /// <returns></returns>
        private IList<object[]> GetGwaCboSource(BindVarCollection bvc)
        {
            return this._cboGwaObj;
        }
        #endregion

        #region GetGrdList
        /// <summary>
        /// GetGrdList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdList(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SCH0201Q12GrdListArgs args = new SCH0201Q12GrdListArgs();
            args.StatFlg = this.statFlg;
            args.Bunho = paBox.BunHo;
            args.NaewonDate = dtpNaewonDate.GetDataValue();
            args.ReserGubun = cboGumsa.GetDataValue();
            args.Gwa = cboGwa.GetDataValue();
            args.Doctor = fbxDoctor.GetDataValue().Equals("") ? fbxDoctor.GetDataValue() : cboGwa.GetDataValue() + fbxDoctor.GetDataValue();
            SCH0201Q12GrdListResult res = CloudService.Instance.Submit<SCH0201Q12GrdListResult, SCH0201Q12GrdListArgs>(args);

            if (null != res)
            {
                foreach (SCH0201Q12GrdListItemInfo item in res.GrdListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.KizyunDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.JundalTable,
                        item.JundalPart,
                        item.JundalPartName,
                        item.ReserTime,
                        item.ReserYn,
                        item.ActYn,
                        item.OrderDate,
                        item.Pksch,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdListExist
        /// <summary>
        /// GetGrdListExist
        /// </summary>
        /// <returns></returns>
        private IList<object[]> GetGrdListExist(BindVarCollection list)
        {
            return this._grdListExist;
        }
        #endregion

        #region DoConfirm
        /// <summary>
        /// DoConfirm
        /// </summary>
        /// <returns></returns>
        private bool DoConfirm()
        {
            SCH0201Q12UpdateKensaYnArgs args = new SCH0201Q12UpdateKensaYnArgs();
            args.Pkout1001 = this.mFkout1001;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, SCH0201Q12UpdateKensaYnArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region DoUpdate
        /// <summary>
        /// DoUpdate
        /// </summary>
        private void DoUpdate()
        {
            string gubun = grdList.GetItemString(grdList.CurrentRowNumber, "jundal_table");
            string jundal_part_name = grdList.GetItemString(grdList.CurrentRowNumber, "jundal_part_name");

            if (XMessageBox.Show(string.Format("[{0}] {1}",jundal_part_name, Resources.SCH0201Q12_MSG), Resources.SCH0201Q12_XN, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // Get params for update
            List<SCH0201Q12UpdateReserData> lstUpdateData = new List<SCH0201Q12UpdateReserData>();
            for (int i = 0; i < grdPkschList.RowCount; i++)
            {
                lstUpdateData.Add(new SCH0201Q12UpdateReserData(grdPkschList.GetItemString(i, "pksch"),
                    grdPkschList.GetItemString(i, "pksch"),
                    grdList.GetItemString(grdList.CurrentRowNumber, "reser_time")));
            }

            // Executes update, reload the grid and perform an confirm button click
            SCH0201Q12UpdateReserDataArgs args = new SCH0201Q12UpdateReserDataArgs();
            // Update params
            args.Gubun = grdList.GetItemString(grdList.CurrentRowNumber, "jundal_table");
            args.UserId = UserInfo.UserID;
            args.ReserDate = dtpNaewonDate.GetDataValue();
            args.IudGubun = "U";
            args.Pkout1001 = this.mFkout1001;
            args.UpdateData = lstUpdateData;
            // Search params
            args.StatFlg = this.statFlg;
            args.Bunho = paBox.BunHo;
            args.NaewonDate = dtpNaewonDate.GetDataValue();
            args.ReserGubun = cboGumsa.GetDataValue();
            args.Gwa = cboGwa.GetDataValue();
            args.Doctor = fbxDoctor.GetDataValue().Equals("") ? fbxDoctor.GetDataValue() : cboGwa.GetDataValue() + fbxDoctor.GetDataValue();
            SCH0201Q12UpdateReserDataResult res = CloudService.Instance.Submit<SCH0201Q12UpdateReserDataResult,
                SCH0201Q12UpdateReserDataArgs>(args);

            if (null != res)
            {
                if (!res.ReserResult && TypeCheck.IsNull(this.mFkout1001)==false)
                {
                    throw new Exception(Service.ErrFullMsg);
                }

                if (!gubun.Equals("INJ") && res.Msg.Equals("X"))
                {
                    XMessageBox.Show(res.Msg, "PR_SCH_SCH0201_IUD", MessageBoxIcon.Error);
                    return;
                }

                if (res.Msg.Equals("0"))
                {
                    // No handle
                }

                // Search result
                foreach (SCH0201Q12GrdListItemInfo item in res.GrdListItem)
                {
                    this._grdListExist.Add(new object[]
                    {
                        item.KizyunDate,
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.HangmogCode,
                        item.HangmogName,
                        item.JundalTable,
                        item.JundalPart,
                        item.JundalPartName,
                        item.ReserTime,
                        item.ReserYn,
                        item.ActYn,
                        item.OrderDate,
                        item.Pksch,
                    });
                }

                grdList.ExecuteQuery = GetGrdListExist;
                grdList.QueryLayout(true);
            }

            grdList.ExecuteQuery = GetGrdList;
        }
        #endregion

        #region DoValidateFbxDoctor
        /// <summary>
        /// DoValidateFbxDoctor
        /// </summary>
        private void DoValidateFbxDoctor(string doctor)
        {
            SCH0201Q12FindBoxArgs args = new SCH0201Q12FindBoxArgs();
            args.Doctor = doctor;
            args.Gwa = cboGwa.GetDataValue();
            SCH0201Q12FindBoxResult res = CloudService.Instance.Submit<SCH0201Q12FindBoxResult, SCH0201Q12FindBoxArgs>(args);

            if (null != res)
            {
                dbxDoctorName.SetDataValue(res.DoctorName);
            }
        }
        #endregion

        #region GetFwkDoctor
        /// <summary>
        /// GetFwkDoctor
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetFwkDoctor(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SCH0201Q12FwkDoctorListArgs args = new SCH0201Q12FwkDoctorListArgs();
            args.Gwa = list["f_gwa"].VarValue;
            args.Find1 = list["f_find1"].VarValue;
            SCH0201Q12FwkDoctorListResult res = CloudService.Instance.Submit<SCH0201Q12FwkDoctorListResult,
                SCH0201Q12FwkDoctorListArgs>(args);

            if (null != res)
            {
                foreach (ComboListItemInfo item in res.FwkDoctorItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}