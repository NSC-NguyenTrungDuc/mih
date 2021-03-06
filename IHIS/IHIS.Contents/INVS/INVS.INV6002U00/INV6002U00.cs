#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector.Contracts.Arguments.Invs;
using IHIS.Framework;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.INVS;
using IHIS.CloudConnector.Contracts.Arguments.INVS;
using IHIS.CloudConnector.Contracts.Results.INVS;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.INVS.Properties;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Invs;
using IHIS.CloudConnector.Contracts.Models.Invs;
#endregion

namespace IHIS.INVS
{
	/// <summary>
	/// INV6002U00에 대한 요약 설명입니다.
	/// </summary>
	public class INV6002U00 : IHIS.Framework.XScreen
	{
		#region [Instance Variable]		
        private string mHospCode = EnvironInfo.HospCode;
		#endregion

        #region Controls
        private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
        private IHIS.Framework.XPanel pnlQuery;
		private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private XMonthBox monthbox;
        private XLabel xLabel1;
        private XDictComboBox cbxActor;
        private XLabel xLabel28;
        private XDatePicker dtpChuriDate;
        private XLabel xLabel14;
        private XButton btnSetCode;
        private XEditGrid grdINV6002;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XDictComboBox cbxJaeryoGubun;
        private XComboItem xComboItem8;
        private XComboItem xComboItem9;
        private XComboItem xComboItem10;
        private XLabel xLabel3;
        private XButton btnExportExcel;
        private XEditGridCell xEditGridCell9;
        private XLabel xLabel4;
        private XTextBox txtMasterial;
        private XDisplayBox txtUserID;
        private XDisplayBox txtUserName;
        private XButton btnChange;
		private System.ComponentModel.IContainer components;
        #endregion

        public INV6002U00()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

            //this.grdINV6002.SavePerformer = new XSavePerformer(this);
            this.InitCloud();

            //https://sofiamedix.atlassian.net/browse/MED-14597
            txtUserID.Text = UserInfo.UserID;
            txtUserName.Text = UserInfo.UserName;
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV6002U00));
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.pnlQuery = new IHIS.Framework.XPanel();
            this.btnChange = new IHIS.Framework.XButton();
            this.txtUserName = new IHIS.Framework.XDisplayBox();
            this.txtUserID = new IHIS.Framework.XDisplayBox();
            this.txtMasterial = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cbxJaeryoGubun = new IHIS.Framework.XDictComboBox();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.dtpChuriDate = new IHIS.Framework.XDatePicker();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.monthbox = new IHIS.Framework.XMonthBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdINV6002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnExportExcel = new IHIS.Framework.XButton();
            this.btnSetCode = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlQuery.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV6002)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "excel.gif");
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ImageIndex = 1;
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ImageIndex = 1;
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ImageIndex = 1;
            this.xComboItem3.ValueItem = "2";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ImageIndex = 1;
            this.xComboItem4.ValueItem = "3";
            // 
            // pnlQuery
            // 
            this.pnlQuery.AccessibleDescription = null;
            this.pnlQuery.AccessibleName = null;
            resources.ApplyResources(this.pnlQuery, "pnlQuery");
            this.pnlQuery.BackgroundImage = null;
            this.pnlQuery.Controls.Add(this.btnChange);
            this.pnlQuery.Controls.Add(this.txtUserName);
            this.pnlQuery.Controls.Add(this.txtUserID);
            this.pnlQuery.Controls.Add(this.txtMasterial);
            this.pnlQuery.Controls.Add(this.xLabel4);
            this.pnlQuery.Controls.Add(this.cbxJaeryoGubun);
            this.pnlQuery.Controls.Add(this.xLabel3);
            this.pnlQuery.Controls.Add(this.xLabel1);
            this.pnlQuery.Controls.Add(this.cbxActor);
            this.pnlQuery.Controls.Add(this.xLabel28);
            this.pnlQuery.Controls.Add(this.dtpChuriDate);
            this.pnlQuery.Controls.Add(this.xLabel14);
            this.pnlQuery.Controls.Add(this.monthbox);
            this.pnlQuery.Controls.Add(this.xLabel2);
            this.pnlQuery.DrawBorder = true;
            this.pnlQuery.Font = null;
            this.pnlQuery.Name = "pnlQuery";
            this.toolTip1.SetToolTip(this.pnlQuery, resources.GetString("pnlQuery.ToolTip"));
            // 
            // btnChange
            // 
            this.btnChange.AccessibleDescription = null;
            this.btnChange.AccessibleName = null;
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.BackgroundImage = null;
            this.btnChange.Image = ((System.Drawing.Image)(resources.GetObject("btnChange.Image")));
            this.btnChange.Name = "btnChange";
            this.toolTip1.SetToolTip(this.btnChange, resources.GetString("btnChange.ToolTip"));
            this.btnChange.Click += new System.EventHandler(this.btnRadioData_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.AccessibleDescription = null;
            this.txtUserName.AccessibleName = null;
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Image = null;
            this.txtUserName.Name = "txtUserName";
            this.toolTip1.SetToolTip(this.txtUserName, resources.GetString("txtUserName.ToolTip"));
            // 
            // txtUserID
            // 
            this.txtUserID.AccessibleDescription = null;
            this.txtUserID.AccessibleName = null;
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.Image = null;
            this.txtUserID.Name = "txtUserID";
            this.toolTip1.SetToolTip(this.txtUserID, resources.GetString("txtUserID.ToolTip"));
            // 
            // txtMasterial
            // 
            this.txtMasterial.AccessibleDescription = null;
            this.txtMasterial.AccessibleName = null;
            resources.ApplyResources(this.txtMasterial, "txtMasterial");
            this.txtMasterial.BackgroundImage = null;
            this.txtMasterial.Name = "txtMasterial";
            this.toolTip1.SetToolTip(this.txtMasterial, resources.GetString("txtMasterial.ToolTip"));
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            this.toolTip1.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // cbxJaeryoGubun
            // 
            this.cbxJaeryoGubun.AccessibleDescription = null;
            this.cbxJaeryoGubun.AccessibleName = null;
            resources.ApplyResources(this.cbxJaeryoGubun, "cbxJaeryoGubun");
            this.cbxJaeryoGubun.BackgroundImage = null;
            this.cbxJaeryoGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem8,
            this.xComboItem9,
            this.xComboItem10});
            this.cbxJaeryoGubun.ExecuteQuery = null;
            this.cbxJaeryoGubun.Name = "cbxJaeryoGubun";
            this.cbxJaeryoGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxJaeryoGubun.ParamList")));
            this.cbxJaeryoGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip1.SetToolTip(this.cbxJaeryoGubun, resources.GetString("cbxJaeryoGubun.ToolTip"));
            this.cbxJaeryoGubun.UserSQL = resources.GetString("cbxJaeryoGubun.UserSQL");
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "%";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "1";
            // 
            // xComboItem10
            // 
            resources.ApplyResources(this.xComboItem10, "xComboItem10");
            this.xComboItem10.ValueItem = "2";
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
            this.toolTip1.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            this.toolTip1.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // cbxActor
            // 
            this.cbxActor.AccessibleDescription = null;
            this.cbxActor.AccessibleName = null;
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.BackgroundImage = null;
            this.cbxActor.ExecuteQuery = null;
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip1.SetToolTip(this.cbxActor, resources.GetString("cbxActor.ToolTip"));
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // xLabel28
            // 
            this.xLabel28.AccessibleDescription = null;
            this.xLabel28.AccessibleName = null;
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel28.EdgeRounding = false;
            this.xLabel28.Image = null;
            this.xLabel28.Name = "xLabel28";
            this.toolTip1.SetToolTip(this.xLabel28, resources.GetString("xLabel28.ToolTip"));
            // 
            // dtpChuriDate
            // 
            this.dtpChuriDate.AccessibleDescription = null;
            this.dtpChuriDate.AccessibleName = null;
            resources.ApplyResources(this.dtpChuriDate, "dtpChuriDate");
            this.dtpChuriDate.BackgroundImage = null;
            this.dtpChuriDate.IsVietnameseYearType = false;
            this.dtpChuriDate.Name = "dtpChuriDate";
            this.toolTip1.SetToolTip(this.dtpChuriDate, resources.GetString("dtpChuriDate.ToolTip"));
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            this.toolTip1.SetToolTip(this.xLabel14, resources.GetString("xLabel14.ToolTip"));
            // 
            // monthbox
            // 
            this.monthbox.AccessibleDescription = null;
            this.monthbox.AccessibleName = null;
            resources.ApplyResources(this.monthbox, "monthbox");
            this.monthbox.BackgroundImage = null;
            this.monthbox.IsVietnameseYearType = false;
            this.monthbox.MonthEditable = false;
            this.monthbox.Name = "monthbox";
            this.toolTip1.SetToolTip(this.monthbox, resources.GetString("monthbox.ToolTip"));
            this.monthbox.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthbox_NextButtonClick);
            this.monthbox.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthbox_NextButtonClick);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XGridColHeaderGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip1.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdINV6002);
            this.xPanel3.Controls.Add(this.xPanel1);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip1.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // grdINV6002
            // 
            resources.ApplyResources(this.grdINV6002, "grdINV6002");
            this.grdINV6002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell1,
            this.xEditGridCell9});
            this.grdINV6002.ColPerLine = 7;
            this.grdINV6002.ColResizable = true;
            this.grdINV6002.Cols = 8;
            this.grdINV6002.ExecuteQuery = null;
            this.grdINV6002.FixedCols = 1;
            this.grdINV6002.FixedRows = 1;
            this.grdINV6002.HeaderHeights.Add(21);
            this.grdINV6002.IsAllDataQuery = true;
            this.grdINV6002.Name = "grdINV6002";
            this.grdINV6002.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINV6002.ParamList")));
            this.grdINV6002.RowHeaderVisible = true;
            this.grdINV6002.Rows = 2;
            this.toolTip1.SetToolTip(this.grdINV6002, resources.GetString("grdINV6002.ToolTip"));
            this.grdINV6002.ToolTipActive = true;
            this.grdINV6002.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdINV6002_PreSaveLayout);
            this.grdINV6002.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdINV6002_QueryEnd);
            this.grdINV6002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINV6002_QueryStarting);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "jaeryo_code";
            this.xEditGridCell2.CellWidth = 95;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "jaeryo_name";
            this.xEditGridCell3.CellWidth = 544;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "exist_count";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell4.CellWidth = 113;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "subul_danui_name";
            this.xEditGridCell5.CellWidth = 94;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "input_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.Col = 7;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "input_user";
            this.xEditGridCell7.CellWidth = 133;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell7.UserSQL = resources.GetString("xEditGridCell7.UserSQL");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "jaeryo_gubun";
            this.xEditGridCell8.CellWidth = 71;
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell8.UserSQL = resources.GetString("xEditGridCell8.UserSQL");
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "magam_month";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "input_user_id";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.btnExportExcel);
            this.xPanel1.Controls.Add(this.btnSetCode);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip1.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.AccessibleDescription = null;
            this.btnExportExcel.AccessibleName = null;
            resources.ApplyResources(this.btnExportExcel, "btnExportExcel");
            this.btnExportExcel.BackgroundImage = null;
            this.btnExportExcel.ImageIndex = 2;
            this.btnExportExcel.ImageList = this.ImageList;
            this.btnExportExcel.Name = "btnExportExcel";
            this.toolTip1.SetToolTip(this.btnExportExcel, resources.GetString("btnExportExcel.ToolTip"));
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSetCode
            // 
            this.btnSetCode.AccessibleDescription = null;
            this.btnSetCode.AccessibleName = null;
            resources.ApplyResources(this.btnSetCode, "btnSetCode");
            this.btnSetCode.BackgroundImage = null;
            this.btnSetCode.Name = "btnSetCode";
            this.btnSetCode.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.toolTip1.SetToolTip(this.btnSetCode, resources.GetString("btnSetCode.ToolTip"));
            this.btnSetCode.Click += new System.EventHandler(this.btnSetCode_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "処理", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.toolTip1.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // INV6002U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.pnlQuery);
            this.Name = "INV6002U00";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.pnlQuery.ResumeLayout(false);
            this.pnlQuery.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINV6002)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region [OnLoad Event]
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            this.monthbox.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));
            this.dtpChuriDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            cbxJaeryoGubun.ExecuteQuery = LoadcbxJaeryoGubun;
            cbxJaeryoGubun.SetDictDDLB();
            //cbxActor.ExecuteQuery = LoadCbxActor;
            //cbxActor.SetDictDDLB();
            // 実施者に 現在ログインしている IDを セットする｡
            this.cbxActor.SetDataValue(UserInfo.UserID);

            // 材料区分
            this.cbxJaeryoGubun.SelectedIndex = 0;
            this.cbxActor.SelectedIndex = 0;
			

			PostCallHelper.PostCall(new PostMethod(PostLoad));
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 118);
		}

        private IList<object[]> LoadcbxJaeryoGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj= new List<object[]>();
            INV6002U00GrdINV6002LoadCbxJaeryoGubunArgs args = new INV6002U00GrdINV6002LoadCbxJaeryoGubunArgs();
            ComboResult res = CloudService.Instance.Submit<ComboResult, INV6002U00GrdINV6002LoadCbxJaeryoGubunArgs>(args);
            if(res.ExecutionStatus==ExecutionStatus.Success)
            {
                foreach(ComboListItemInfo item in res.ComboItem)
                {
                     lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName
                        
                    });
                }
                return lObj;
            }
            return null;
        }
        private IList<object[]> LoadCbxActor(BindVarCollection bvc)
        {
            
            IList<object[]> lObj= new List<object[]>();
            INV6002U00GrdINV6002LoadcbxActorArgs args = new INV6002U00GrdINV6002LoadcbxActorArgs();
            INV6002U00GrdINV6002LoadcbxActorResult res = CloudService.Instance.Submit<INV6002U00GrdINV6002LoadcbxActorResult, INV6002U00GrdINV6002LoadcbxActorArgs>(args);
            if(res.ExecutionStatus==ExecutionStatus.Success)
            {
                foreach(INV6002U00GrdINV6002LoadcbxActorInfo item in res.Item)
                {
                     lObj.Add(new object[]
                    {
                        item.UserId,
                        item.UserNm
                        
                    });
                }
                return lObj;
            }
            return null;
        }
		private void PostLoad()
		{
            this.btnList.PerformClick(FunctionType.Query);
		}
		#endregion

        #region [Button List Event]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.ProcQueryCmd("After");

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    //if (!this.grdINV6002.SaveLayout())
                    //{
                    //    XMessageBox.Show(Service.ErrFullMsg);
                    //    return;
                    //}
                    List<INV6002U00GrdINV6002ExcuteInfo> listItem= getGridDetailExcute();
                    if (listItem.Count==0)
                    {
                        return;
                    }
                    if (SaveGridINV6002(listItem) == true)
                    {
                        XMessageBox.Show(Properties.Resources.MesseageBox1, Properties.Resources.MesseageBox1Title, MessageBoxIcon.Information);
                        this.ProcQueryCmd("After");
                    }
                    else
                    {
                        XMessageBox.Show(Properties.Resources.MesseageBoxErrFullMsg);
                    }
                    break;
            }
        }
        #endregion

        private bool SaveGridINV6002(List<INV6002U00GrdINV6002ExcuteInfo> listItem)
        {
            INV6002U00GrdINV6002ExcuteArgs args = new INV6002U00GrdINV6002ExcuteArgs();
            args.Item =listItem;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, INV6002U00GrdINV6002ExcuteArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                return res.Result;
            }
            return false;

        }

        private List<INV6002U00GrdINV6002ExcuteInfo> getGridDetailExcute()
        {
            List<INV6002U00GrdINV6002ExcuteInfo> lstExcute = new List<INV6002U00GrdINV6002ExcuteInfo>();
            for (int i = 0; i < grdINV6002.RowCount; i++)
            {
                if (grdINV6002.GetRowState(i) != DataRowState.Unchanged)
                {
                    INV6002U00GrdINV6002ExcuteInfo info = new INV6002U00GrdINV6002ExcuteInfo();
                    info.ExistCount = grdINV6002.GetItemString(i, "exist_count").ToString();
                    info.HospCode = mHospCode;
                    info.InputDate = grdINV6002.GetItemString(i, "input_date").ToString();
                    info.InputUser = grdINV6002.BindVarList["f_gubun"].VarValue == "Before" ? grdINV6002.GetItemString(i, "input_user_id").ToString() : txtUserID.GetDataValue();//cbxActor.GetDataValue();
                    info.JaeryoCode = grdINV6002.GetItemString(i, "jaeryo_code").ToString();
                    //info.MagamMonth = grdINV6002.GetItemString(i, "magam_month").ToString();
                    info.MagamMonth = monthbox.GetDataValue();
                    info.UserId = UserInfo.UserID;
                    lstExcute.Add(info);
                }   
            }
            return lstExcute;
        }

		#region [検索条件 Event]
        private void monthbox_NextButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [grdINV6002 Event]
        private void grdINV6002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINV6002.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdINV6002.SetBindVarValue("f_month", this.monthbox.GetDataValue());
            this.grdINV6002.SetBindVarValue("f_jaeryo_gubun", this.cbxJaeryoGubun.GetDataValue());
        }

        private void grdINV6002_QueryEnd(object sender, QueryEndEventArgs e)
        {
            int rowCnt = this.grdINV6002.RowCount;

            if (rowCnt > 0)
            {
                for (int i = 0; i < rowCnt; i++)
                {
                    this.grdINV6002.SetItemValue(i, "input_date", this.dtpChuriDate.GetDataValue());

                    // https://sofiamedix.atlassian.net/browse/MED-11743
                    if (this.grdINV6002.BindVarList["f_gubun"].VarValue == "Before")
                    {
                        //this.grdINV6002.SetItemValue(i, "input_user", this.cbxActor.GetDataValue());
                        this.grdINV6002.SetItemValue(i, "input_user", this.cbxActor.Text);
                        this.grdINV6002.SetItemValue(i, "input_user_id", txtUserID.GetDataValue());//this.cbxActor.GetDataValue());
                    }
                }
                this.grdINV6002.ResetUpdate();
            }
        }

        private void grdINV6002_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            this.grdINV6002.SetItemValue(e.RowNumber, "magam_month", this.monthbox.GetDataValue());
        }
        #endregion

        #region btnSetCode_Click
        private void btnSetCode_Click(object sender, EventArgs e)
        {
            this.ProcQueryCmd("Before");
        }
        #endregion

        #region Proc Query Cmd

        //private IList<object[]> LoadgrdINV6002Before(BindVarCollection bvc)
        //{
        //    IList<object[]> lObj = new List<object[]>();
        //    INV6002U00GrdINV6002BeforeArgs args = new INV6002U00GrdINV6002BeforeArgs();
        //    args.HospCode = mHospCode;//String.IsNullOrEmpty(bvc["f_hosp_code"].VarValue) ? "" : bvc["f_hosp_code"].VarValue;
        //    args.JaeryoGubun = this.cbxJaeryoGubun.GetDataValue();// String.IsNullOrEmpty(bvc["f_jaeryo_gubun"].VarValue) ? "" : bvc["f_jaeryo_gubun"].VarValue;
        //    args.Month = this.monthbox.GetDataValue();//String.IsNullOrEmpty(bvc["f_month"].VarValue) ? "" : bvc["f_month"].VarValue;
        //    args.PageNumber = bvc["f_page_number"].VarValue;
        //    args.Offset = "200";

        //    INV6002U00grdINV6002BeforeResult res = CloudService.Instance.Submit<INV6002U00grdINV6002BeforeResult, INV6002U00GrdINV6002BeforeArgs>(args);
        //    if (res.ExecutionStatus == ExecutionStatus.Success)
        //    {
        //        //res.Item.ForEach(delegate(INV6002U00GrdINV6002BeforeInfo item)
        //        //{
        //        //    lObj.Add(new object[]
        //        //    {
        //        //        item.JaeryoCode,
        //        //        item.SubulDanuiName,
        //        //        item.JaeryoName,
        //        //        item.JaryoGubun,
        //        //    });
        //        //});
        //        foreach (INV6002U00GrdINV6002BeforeInfo item in res.Item)
        //        {
        //            lObj.Add(new object[]
        //            {
        //                item.JaeryoCode,
        //                item.JaeryoName,
        //                null,
        //                item.SubulDanuiName,
        //                item.JaryoGubun,
        //                null,
        //                null,
        //                monthbox.GetDataValue(),
        //            });
        //        }

        //    }

        //    return lObj;
        //}
        //private IList<object[]> LoadgrdINV6002After(BindVarCollection bvc)
        //{
        //    IList<object[]> lObj = new List<object[]>();
        //    INV6002U00GrdINV6002AfterArgs args = new INV6002U00GrdINV6002AfterArgs();
        //    /*
        //     this.grdINV6002.SetBindVarValue("f_hosp_code", mHospCode);
        //    this.grdINV6002.SetBindVarValue("f_month", this.monthbox.GetDataValue());
        //    this.grdINV6002.SetBindVarValue("f_jaeryo_gubun", this.cbxJaeryoGubun.GetDataValue());
        //     */
        //    args.HospCode = mHospCode;//String.IsNullOrEmpty(bvc["f_hosp_code"].VarValue) ? "" : bvc["f_hosp_code"].VarValue;
        //    args.JaeryoGubun = this.cbxJaeryoGubun.GetDataValue();// String.IsNullOrEmpty(bvc["f_jaeryo_gubun"].VarValue) ? "" : bvc["f_jaeryo_gubun"].VarValue;
        //    args.Month = this.monthbox.GetDataValue();//String.IsNullOrEmpty(bvc["f_month"].VarValue) ? "" : bvc["f_month"].VarValue;
        //    args.PageNumber = bvc["f_page_number"].VarValue;
        //    args.Offset = "200";

        //    INV6002U00GrdINV6002AfterResult res = CloudService.Instance.Submit<INV6002U00GrdINV6002AfterResult, INV6002U00GrdINV6002AfterArgs>(args);
        //    if (res.ExecutionStatus == ExecutionStatus.Success)
        //    {
        //        //res.Item.ForEach(delegate(INV6002U00GrdINV6002AfterInfo item)
        //        //{
        //        //    lObj.Add(new object[]
        //        //    {
        //        //        item.ExistCount,
        //        //        item.InputDate,
        //        //        item.InputUser,
        //        //        item.JaeryoName,
        //        //        item.JaryoGubun,
        //        //        item.SubulDanuiName,
        //        //    });
        //        //});
        //        foreach (INV6002U00GrdINV6002AfterInfo item in res.Item)
        //        {
        //            lObj.Add(new object[]
        //                {
        //                    item.JaeryoCode,
        //                    item.JaeryoName,
        //                    item.ExistCount,

        //                    item.SubulDanuiName,
        //                    item.InputDate,
        //                    // https://sofiamedix.atlassian.net/browse/MED-11743
        //                    item.InputUser,
        //                    item.JaryoGubun,
        //                });
        //        }
        //    }
        //    return lObj;
        //}
        
        private void ProcQueryCmd(string gubun)
        {
            //if (gubun == "Before")
            //{
            //    grdINV6002.ExecuteQuery = LoadgrdINV6002Before;
            //}
            //if (gubun == "After")
            //{
            //    grdINV6002.ExecuteQuery = LoadgrdINV6002After;
            //}

            this.grdINV6002.SetBindVarValue("f_gubun", gubun);
            this.grdINV6002.QueryLayout(false);
        }
//        private void ProcQueryCmd(string gubun)
//        {
//            string cmd = null;

//            if (gubun == "Before")
//            {
//                cmd = @" -- INV0110 Get Base Code --
//                            SELECT A.JAERYO_CODE
//                                 , A.JAERYO_NAME
//                                 , NULL
//                                 , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', A.SUBUL_DANUI) SUBUL_DANUI_NAME
//                                 , NULL
//                                 , NULL
//                                 , C.ORDER_GUBUN  AS JARYO_GUBUN
//                              FROM OCS0103 C
//                                 , INV0110 A
//                             WHERE A.HOSP_CODE   = :f_hosp_code
//                               AND A.JAERYO_CODE NOT IN ( SELECT B.JAERYO_CODE
//                                                            FROM INV6002 B
//                                                           WHERE B.HOSP_CODE   = :f_hosp_code
//                                                             AND B.MAGAM_MONTH = :f_month
//                                                             AND B.EXIST_COUNT IS NOT NULL
//                                                         ) 
//                               AND A.STOCK_YN      = 'Y'
//                               --
//                               AND C.HOSP_CODE     = A.HOSP_CODE
//                               AND C.ORDER_GUBUN   LIKE :f_jaeryo_gubun
//                               AND C.HANGMOG_CODE  = A.JAERYO_CODE
//                               AND TRUNC(SYSDATE)  BETWEEN C.START_DATE AND C.END_DATE
//                             ORDER BY
//                                   C.ORDER_GUBUN
//                                 , A.JAERYO_NAME "
//                    ;
//            }

//            if (gubun == "After")
//            {
//                cmd = @" -- INV0110 --
//                            SELECT A.JAERYO_CODE
//                                 , B.JAERYO_NAME
//                                 , A.EXIST_COUNT
//                                 , FN_OCS_LOAD_CODE_NAME ( 'ORD_DANUI', B.SUBUL_DANUI) SUBUL_DANUI_NAME
//                                 , A.INPUT_DATE
//                                 , A.INPUT_USER
//                                 , C.ORDER_GUBUN  AS JARYO_GUBUN
//                              FROM OCS0103 C
//                                 , INV0110 B
//                                 , INV6002 A
//                             WHERE A.HOSP_CODE     = :f_hosp_code
//                               AND A.MAGAM_MONTH   = :f_month
//                               --
//                               AND B.HOSP_CODE     = A.HOSP_CODE
//                               AND B.JAERYO_CODE   = A.JAERYO_CODE
//                               -- 
//                               AND C.HOSP_CODE     = A.HOSP_CODE
//                               AND C.ORDER_GUBUN   LIKE :f_jaeryo_gubun
//                               AND C.HANGMOG_CODE  = A.JAERYO_CODE
//                               AND TRUNC(SYSDATE)  BETWEEN C.START_DATE AND C.END_DATE
//                             ORDER BY
//                                   C.ORDER_GUBUN
//                                 , B.JAERYO_NAME "
//                    ;
//            }

//            this.grdINV6002.QuerySQL = cmd;

//            if (!this.grdINV6002.QueryLayout(true))
//            {
//                XMessageBox.Show("検索を失敗しました。", "確認", MessageBoxIcon.Information);
//                return;
//            }
//        }
        #endregion
        /* ====================================== SAVEPERFORMER ====================================== */
        #region [ XSavePerformer]
//        private class XSavePerformer : IHIS.Framework.ISavePerformer
//        {
//            private INV6002U00 parent = null;
//            public XSavePerformer(INV6002U00 parent)
//            {
//                this.parent = parent;
//            }
//            public bool Execute(char callerID, RowDataItem item)
//            {

//                string cmdText = "";
//                //object t_chk = "";
//                //object seq = "";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                switch (callerID)
//                {
//                    case '1':
//                        cmdText = @"  -- MERGE INV6002
//                                          MERGE INTO INV6002 A
//                                               USING SYS.DUAL
//                                                  ON (    A.HOSP_CODE      = :f_hosp_code
//                                                      AND A.MAGAM_MONTH    = :f_magam_month
//                                                      AND A.JAERYO_CODE    = :f_jaeryo_code
//                                                     )
//                                          WHEN MATCHED THEN
//                                                     UPDATE
//                                                        SET A.EXIST_COUNT  = :f_exist_count
//                                                          , A.UPD_DATE     = SYSDATE
//                                                          , A.UPD_ID       = :q_user_id
//                                          WHEN NOT MATCHED THEN
//                                                     INSERT (  SYS_DATE     
//                                                             , SYS_ID   
//                                                             , HOSP_CODE    
//                                                             , MAGAM_MONTH
//                                                             , JAERYO_CODE
//                                                             , EXIST_COUNT
//                                                             , INPUT_DATE
//                                                             , INPUT_USER
//                                                   ) VALUES (  SYSDATE
//                                                             , :q_user_id
//                                                             , :f_hosp_code
//                                                             , :f_magam_month
//                                                             , :f_jaeryo_code
//                                                             , :f_exist_count
//                                                             , :f_input_date
//                                                             , :f_input_user
//                                                             )"
//                            ;


//                        #region INV6002
////                        switch (item.RowState)
////                        {
////                            case DataRowState.Added:
////                                cmdText = @"INSERT INTO INV6002 (  SYS_DATE     
////                                                                 , SYS_ID   
////                                                                 , HOSP_CODE    
////                                                                 , MAGAM_MONTH
////                                                                 , JAERYO_CODE
////                                                                 , EXIST_COUNT
////                                                                 , INPUT_DATE
////                                                                 , INPUT_USER
////                                                      ) VALUES (   SYSDATE
////                                                                 , :q_user_id
////                                                                 , :f_hosp_code
////                                                                 , :f_magam_month
////                                                                 , :f_jaeryo_code
////                                                                 , :f_exist_count
////                                                                 , :f_input_date
////                                                                 , :f_input_user
////                                                               )";
////                                break;

////                            case DataRowState.Modified:

////                                cmdText = @" UPDATE INV6002        A
////                                                SET A.EXIST_COUNT  = :f_exist_count
////                                              WHERE A.HOSP_CODE    = :f_hosp_code
////                                                AND A.MAGAM_MONTH  = :f_magam_month
////                                                AND A.JAERYO_CODE  = :f_jaeryo_code
////                                           ";

////                                break;

////                            case DataRowState.Deleted:
////                                cmdText = @" DELETE FROM INV6002   A
////                                              WHERE A.HOSP_CODE    = :f_hosp_code
////                                                AND A.MAGAM_MONTH  = :f_magam_month
////                                                AND A.JAERYO_CODE  = :f_jaeryo_code
////                                           ";
////                                break;

////                        }
//                        #endregion
//                        break;
//                }

//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            this.grdINV6002.Export(true, true);
        }

        private void fbxMesterial_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("word", "");
            openParams.Add("all_gubun", "N");
            openParams.Add("query_gubun", "%");

            XScreen.OpenScreenWithParam(this, "INV", "INV0110Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }


        #region Cloud

        // https://sofiamedix.atlassian.net/browse/MED-11743
        private void InitCloud()
        {
            this.grdINV6002.ParamList = new List<string>(new string[]
                {
                    "f_gubun",
                    "f_hosp_code",
                    "f_month",
                    "f_jaeryo_gubun",
                    "f_magam_month",
                    "f_page_number",
                    "f_offset",
                });
            this.grdINV6002.ExecuteQuery = GetGrdINV6002;
        }

        private List<object[]> GetGrdINV6002(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV6002U00GrdINV6002Args args = new INV6002U00GrdINV6002Args();

            args.JaeryoCode = txtMasterial.Text;
            args.Gubun = bc["f_gubun"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.JaeryoGubun = bc["f_jaeryo_gubun"].VarValue;
            args.MagamMonth = bc["f_magam_month"].VarValue;
            args.Month = bc["f_month"].VarValue;
            args.Offset = "200";
            args.PageNumber = bc["f_page_number"].VarValue;
            INV6002U00GrdINV6002Result res = CloudService.Instance.Submit<INV6002U00GrdINV6002Result, INV6002U00GrdINV6002Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdItem.ForEach(delegate(INV6002U00GrdINV6002Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.JaeryoCode,
                        item.JaeryoName,
                        item.ExistCount,
                        item.SubulDanuiName,
                        item.InputDate,
                        item.InputUser,
                        item.JaryoGubun,
                        item.MagamMonth,
                    });
                });
            }

            return lObj;
        }

        #endregion

       
        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "ADM104Q")
            {
                //XMessageBox.Show(commandParam["user_id"].ToString() + "---" + commandParam["user_name"].ToString());
                txtUserID.SetDataValue(commandParam["user_id"]);
                txtUserName.SetDataValue(commandParam["user_name"]);
            }

            return base.Command(command, commandParam);
        }

        private void btnRadioData_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", txtUserID.Text);
            param.Add("user_name", txtUserName.Text);
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }
    }
}
