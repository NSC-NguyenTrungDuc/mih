#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.ADM.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using System.Security.Cryptography;
using ADM103UgrdUserGrpInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM103UgrdUserGrpInfo;
using ADM104UGridUserInfo = IHIS.CloudConnector.Contracts.Models.Adma.ADM104UGridUserInfo;
using ComboListItemInfo = IHIS.CloudConnector.Contracts.Models.System.ComboListItemInfo;

#endregion

namespace IHIS.ADMA
{
	/// <summary>
	/// ADM104U에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class ADM104U : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButton xButtonNewRow;
		private IHIS.Framework.XButton xButtonSave;
		private IHIS.Framework.XButton xButtonRESET;
		private IHIS.Framework.XButton xButtonDelete;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private IHIS.Framework.XFindWorker fwkUserGroup;
		//private IHIS.Framework.DataServiceSIMO dsvUserQry;
		private IHIS.Framework.XEditGrid grdUserList;
		//private IHIS.Framework.DataServiceMISO dsvUpdate;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell23;
		private IHIS.Framework.SingleLayout vsvUserGroup;
		private IHIS.Framework.XFindWorker fwkBuseoCode;
        private IHIS.Framework.SingleLayout vsvBuseoName;
		private IHIS.Framework.XFindWorker fwkUserTrm;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.FindColumnInfo findColumnInfo3;
		private IHIS.Framework.FindColumnInfo findColumnInfo4;
		private IHIS.Framework.FindColumnInfo findColumnInfo5;
		private IHIS.Framework.FindColumnInfo findColumnInfo6;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XTextBox txtSearchWord;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XDictComboBox cboUserGroup;
		private IHIS.Framework.XButton btnIlgwalInsert;
        private XLabel xLabel3;
        private XDictComboBox cboUserGubun;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XFindWorker fwkHospitalID;
        private IHIS.Framework.FindColumnInfo findColumnInfo7;
        private IHIS.Framework.FindColumnInfo findColumnInfo8;
        private XLabel xLabel4;
        private XDisplayBox dbxHospitalNm;
        private XFindBox fbxHospitalID;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
        private SingleLayoutItem singleLayoutItem1;
        private IHIS.Framework.SingleLayout layCommon;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private string mHospCode = "";

		public ADM104U()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

            fwkHospitalID.ParamList = new List<string>();
            fwkHospitalID.ExecuteQuery = GetFwkHospitalId;
            fwkUserGroup.ExecuteQuery = ExecuteQueryADM103UgrdUserGrp;

            grdUserList.ParamList = new List<string>(new String[] { "f_user_group", "f_search_word", "f_user_gubun" });
            grdUserList.ExecuteQuery = ExecuteQueryGridUser;

            fwkBuseoCode.ParamList = new List<string>(new String[] { "f_buseo_code", "f_gwa_name" });
            fwkBuseoCode.ExecuteQuery = ExecuteQueryFwkBuseoCode;

            cboUserGubun.ExecuteQuery = ExecuteQueryCboUserGubun;
            cboUserGroup.ExecuteQuery = ExecuteQueryCboUserGroup;

            layCommon.ParamList = new List<string>(new String[] { "f_hosp_code" });
            layCommon.ExecuteQuery = LoadDataLayCommon;

            if (NetInfo.Language != LangMode.Jr)
            {
                SetSizeForColumn();
            }
		}

        private void SetSizeForColumn()
        {
            grdUserList.AutoSizeColumn(xEditGridCell6.Col, 100);
            grdUserList.AutoSizeColumn(xEditGridCell9.Col, 110);
        }
        /// <summary>
        /// Get Data PassWord
        /// </summary>
        //Fix MED-8114
        // public string pass;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADM104U));
            this.fwkUserGroup = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.grdUserList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.fwkBuseoCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.fwkUserTrm = new IHIS.Framework.XFindWorker();
            this.findColumnInfo5 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xButtonNewRow = new IHIS.Framework.XButton();
            this.xButtonSave = new IHIS.Framework.XButton();
            this.xButtonRESET = new IHIS.Framework.XButton();
            this.xButtonDelete = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.vsvUserGroup = new IHIS.Framework.SingleLayout();
            this.vsvBuseoName = new IHIS.Framework.SingleLayout();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxHospitalNm = new IHIS.Framework.XDisplayBox();
            this.fbxHospitalID = new IHIS.Framework.XFindBox();
            this.fwkHospitalID = new IHIS.Framework.XFindWorker();
            this.findColumnInfo7 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo8 = new IHIS.Framework.FindColumnInfo();
            this.cboUserGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.cboUserGroup = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtSearchWord = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnIlgwalInsert = new IHIS.Framework.XButton();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            // 
            // fwkUserGroup
            // 
            this.fwkUserGroup.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkUserGroup.ExecuteQuery = null;
            this.fwkUserGroup.FormText = global::IHIS.ADM.Properties.Resources.FormText_Header_1;
            this.fwkUserGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkUserGroup.ParamList")));
            this.fwkUserGroup.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkUserGroup_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "userGrp";
            this.findColumnInfo1.ColWidth = 107;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "userGrpNM";
            this.findColumnInfo2.ColWidth = 191;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // grdUserList
            // 
            resources.ApplyResources(this.grdUserList, "grdUserList");
            this.grdUserList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell1,
            this.xEditGridCell14,
            this.xEditGridCell16,
            this.xEditGridCell23,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell2,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell15,
            this.xEditGridCell17,
            this.xEditGridCell18});
            this.grdUserList.ColPerLine = 15;
            this.grdUserList.Cols = 16;
            this.grdUserList.ExecuteQuery = null;
            this.grdUserList.FixedCols = 1;
            this.grdUserList.FixedRows = 1;
            this.grdUserList.FocusColumnName = "user_id";
            this.grdUserList.HeaderHeights.Add(36);
            this.grdUserList.Name = "grdUserList";
            this.grdUserList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdUserList.ParamList")));
            this.grdUserList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdUserList.RowHeaderVisible = true;
            this.grdUserList.Rows = 2;
            this.grdUserList.ToolTipActive = true;
            this.grdUserList.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdUserList_GridFindSelected);
            this.grdUserList.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdUserList_GridButtonClick);
            this.grdUserList.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdUserList_GridColumnChanged);
            this.grdUserList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdUserList_RowFocusChanged);
            this.grdUserList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdUserList_GridCellPainting);
            this.grdUserList.PreEndInitializing += new System.EventHandler(this.grdUserList_PreEndInitializing);
            this.grdUserList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdUserList_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "user_id";
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 20;
            this.xEditGridCell9.CellName = "user_nm";
            this.xEditGridCell9.CellWidth = 83;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.Han;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 16;
            this.xEditGridCell10.CellName = "user_scrt";
            this.xEditGridCell10.CellWidth = 62;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.PasswordChar = '*';
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "dept_code";
            this.xEditGridCell11.CellWidth = 79;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.FindWorker = this.fwkBuseoCode;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkBuseoCode
            // 
            this.fwkBuseoCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkBuseoCode.ExecuteQuery = null;
            this.fwkBuseoCode.FormText = global::IHIS.ADM.Properties.Resources.FormText_Header_2;
            this.fwkBuseoCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkBuseoCode.ParamList")));
            this.fwkBuseoCode.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkBuseoCode_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "buserCode";
            this.findColumnInfo3.ColWidth = 106;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "buserNM";
            this.findColumnInfo4.ColWidth = 253;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellLen = 40;
            this.xEditGridCell12.CellName = "deptName";
            this.xEditGridCell12.CellWidth = 76;
            this.xEditGridCell12.Col = 5;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 6;
            this.xEditGridCell13.CellName = "user_group";
            this.xEditGridCell13.CellWidth = 109;
            this.xEditGridCell13.Col = 6;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.FindWorker = this.fwkUserGroup;
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "grpName";
            this.xEditGridCell1.CellWidth = 84;
            this.xEditGridCell1.Col = 7;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsUpdCol = false;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "user_level";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell14.CellWidth = 31;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "user_end_ymd";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell16.Col = 9;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 1;
            this.xEditGridCell23.CellName = "user_gubun";
            this.xEditGridCell23.CellWidth = 82;
            this.xEditGridCell23.Col = 8;
            this.xEditGridCell23.DictColumn = "USER_GUBUN";
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "nurse_confirm_enable_yn";
            this.xEditGridCell3.CellWidth = 60;
            this.xEditGridCell3.Col = 11;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 5;
            this.xEditGridCell4.CellName = "co_id";
            this.xEditGridCell4.Col = 12;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.ButtonText = global::IHIS.ADM.Properties.Resources.ButtonText_1;
            this.xEditGridCell2.CellName = "reg_entr_sys";
            this.xEditGridCell2.CellWidth = 64;
            this.xEditGridCell2.Col = 10;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdCol = false;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 40;
            this.xEditGridCell5.CellName = "email";
            this.xEditGridCell5.CellWidth = 76;
            this.xEditGridCell5.Col = 13;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "smo_organize";
            this.xEditGridCell7.CellWidth = 118;
            this.xEditGridCell7.Col = 14;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell7.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "change_pwd_flg";
            this.xEditGridCell8.Col = 15;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "loginflg";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "pwd_history";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "plain_pwd";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // fwkUserTrm
            // 
            this.fwkUserTrm.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo5,
            this.findColumnInfo6});
            this.fwkUserTrm.ExecuteQuery = null;
            this.fwkUserTrm.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkUserTrm.ParamList")));
            // 
            // findColumnInfo5
            // 
            this.findColumnInfo5.ColName = "trmID";
            this.findColumnInfo5.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo5, "findColumnInfo5");
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "trmNM";
            this.findColumnInfo6.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo6, "findColumnInfo6");
            // 
            // xButtonNewRow
            // 
            this.xButtonNewRow.AccessibleDescription = null;
            this.xButtonNewRow.AccessibleName = null;
            resources.ApplyResources(this.xButtonNewRow, "xButtonNewRow");
            this.xButtonNewRow.BackgroundImage = null;
            this.xButtonNewRow.Name = "xButtonNewRow";
            // 
            // xButtonSave
            // 
            this.xButtonSave.AccessibleDescription = null;
            this.xButtonSave.AccessibleName = null;
            resources.ApplyResources(this.xButtonSave, "xButtonSave");
            this.xButtonSave.BackgroundImage = null;
            this.xButtonSave.Name = "xButtonSave";
            // 
            // xButtonRESET
            // 
            this.xButtonRESET.AccessibleDescription = null;
            this.xButtonRESET.AccessibleName = null;
            resources.ApplyResources(this.xButtonRESET, "xButtonRESET");
            this.xButtonRESET.BackgroundImage = null;
            this.xButtonRESET.Name = "xButtonRESET";
            // 
            // xButtonDelete
            // 
            this.xButtonDelete.AccessibleDescription = null;
            this.xButtonDelete.AccessibleName = null;
            resources.ApplyResources(this.xButtonDelete, "xButtonDelete");
            this.xButtonDelete.BackgroundImage = null;
            this.xButtonDelete.Name = "xButtonDelete";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // vsvUserGroup
            // 
            this.vsvUserGroup.ExecuteQuery = null;
            this.vsvUserGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvUserGroup.ParamList")));
            // 
            // vsvBuseoName
            // 
            this.vsvBuseoName.ExecuteQuery = null;
            this.vsvBuseoName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("vsvBuseoName.ParamList")));
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dbxHospitalNm);
            this.xPanel1.Controls.Add(this.fbxHospitalID);
            this.xPanel1.Controls.Add(this.cboUserGubun);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.cboUserGroup);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.txtSearchWord);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxHospitalNm
            // 
            this.dbxHospitalNm.AccessibleDescription = null;
            this.dbxHospitalNm.AccessibleName = null;
            resources.ApplyResources(this.dbxHospitalNm, "dbxHospitalNm");
            this.dbxHospitalNm.Image = null;
            this.dbxHospitalNm.Name = "dbxHospitalNm";
            // 
            // fbxHospitalID
            // 
            this.fbxHospitalID.AccessibleDescription = null;
            this.fbxHospitalID.AccessibleName = null;
            resources.ApplyResources(this.fbxHospitalID, "fbxHospitalID");
            this.fbxHospitalID.BackgroundImage = null;
            this.fbxHospitalID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHospitalID.FindWorker = this.fwkHospitalID;
            this.fbxHospitalID.Name = "fbxHospitalID";
            this.fbxHospitalID.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHospitalID_DataValidating);
            this.fbxHospitalID.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxID_FindSelected);
            // 
            // fwkHospitalID
            // 
            this.fwkHospitalID.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo7,
            this.findColumnInfo8});
            this.fwkHospitalID.ExecuteQuery = null;
            this.fwkHospitalID.InputSQL = resources.GetString("fwkHospitalID.InputSQL");
            this.fwkHospitalID.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkHospitalID.ParamList")));
            this.fwkHospitalID.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkHospitalID_QueryStarting);
            // 
            // findColumnInfo7
            // 
            this.findColumnInfo7.ColName = "hospitalID";
            this.findColumnInfo7.ColWidth = 105;
            this.findColumnInfo7.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo7, "findColumnInfo7");
            // 
            // findColumnInfo8
            // 
            this.findColumnInfo8.ColName = "hospitalNM";
            this.findColumnInfo8.ColWidth = 218;
            this.findColumnInfo8.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo8, "findColumnInfo8");
            // 
            // cboUserGubun
            // 
            this.cboUserGubun.AccessibleDescription = null;
            this.cboUserGubun.AccessibleName = null;
            resources.ApplyResources(this.cboUserGubun, "cboUserGubun");
            this.cboUserGubun.BackgroundImage = null;
            this.cboUserGubun.ExecuteQuery = null;
            this.cboUserGubun.Name = "cboUserGubun";
            this.cboUserGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboUserGubun.ParamList")));
            this.cboUserGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboUserGubun.SelectedIndexChanged += new System.EventHandler(this.cboUser_SelectedIndexChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackColor = IHIS.Framework.XColor.XScreenBackColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // cboUserGroup
            // 
            this.cboUserGroup.AccessibleDescription = null;
            this.cboUserGroup.AccessibleName = null;
            resources.ApplyResources(this.cboUserGroup, "cboUserGroup");
            this.cboUserGroup.BackgroundImage = null;
            this.cboUserGroup.ExecuteQuery = null;
            this.cboUserGroup.Name = "cboUserGroup";
            this.cboUserGroup.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboUserGroup.ParamList")));
            this.cboUserGroup.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboUserGroup.SelectedIndexChanged += new System.EventHandler(this.cboUser_SelectedIndexChanged);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.AccessibleDescription = null;
            this.txtSearchWord.AccessibleName = null;
            resources.ApplyResources(this.txtSearchWord, "txtSearchWord");
            this.txtSearchWord.BackgroundImage = null;
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtSearchWord_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // btnIlgwalInsert
            // 
            this.btnIlgwalInsert.AccessibleDescription = null;
            this.btnIlgwalInsert.AccessibleName = null;
            resources.ApplyResources(this.btnIlgwalInsert, "btnIlgwalInsert");
            this.btnIlgwalInsert.BackgroundImage = null;
            this.btnIlgwalInsert.ImageIndex = 0;
            this.btnIlgwalInsert.ImageList = this.ImageList;
            this.btnIlgwalInsert.Name = "btnIlgwalInsert";
            this.btnIlgwalInsert.Click += new System.EventHandler(this.btnIlgwalInsert_Click);
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            this.layCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCommon_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxHospitalNm;
            this.singleLayoutItem1.DataName = "HospitalName";
            // 
            // ADM104U
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnIlgwalInsert);
            this.Controls.Add(this.grdUserList);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xButtonDelete);
            this.Controls.Add(this.xButtonRESET);
            this.Controls.Add(this.xButtonSave);
            this.Controls.Add(this.xButtonNewRow);
            this.Name = "ADM104U";
            this.Load += new System.EventHandler(this.ADM104U_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수
		private XColor endForeColor = new XColor(Color.Red);        
        private string mMsg = "";
        private string mCap = "";
		#endregion

		#region 다른화면 혹은 폼 오픈

		private void OpenForm_DoctorIlgwalRegform ()
		{
			DoctorIlgwalRegForm form = new DoctorIlgwalRegForm(fbxHospitalID.Text);

			form.ShowDialog()	;

			this.txtSearchWord.SetDataValue(form.UserNm);

			this.btnList.PerformClick(FunctionType.Query);
		}

		#endregion

		#region Pre/Post Validation Service Call


		private void vsvBuseoName_PreServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			vsvBuseoName.SetBindVarValue("i_buseo_code", grdUserList.GetItemValue(grdUserList.CurrentRowNumber, "deptCode").ToString());
		}

		#endregion

		#region 벨리데이션 PreServiceCall

		private void vsvUserGroup_PreServiceCall(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			vsvUserGroup.SetBindVarValue("i_user_group", this.grdUserList.GetItemValue(grdUserList.CurrentRowNumber, "userGroup").ToString());
		}

		#endregion

		#region OnLoad

		private void ADM104U_Load(object sender, System.EventArgs e)
		{
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                this.mHospCode = fbxHospitalID.Text;
            }
            else
            {
                xLabel4.Visible = false;
                fbxHospitalID.Visible = false;
                dbxHospitalNm.Visible = false;

                this.mHospCode = UserInfo.HospCode;
            }

            cboUserGroup.SetDictDDLB();
            cboUserGubun.SetDictDDLB();
            
            //this.CurrMILayout = this.grdUserList;
            //this.CurrMOLayout = this.grdUserList;
            //this.grdUserList.SavePerformer = new XSavePerformer(this);
			// 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
			if (this.Opener is IHIS.Framework.MdiForm && 
				(this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
			{
				Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;			
				this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Size.Width, rc.Height - 105);
				//this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 105);
			}

			//최초 입력가능하도록 행입력
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}
	

		private void PostLoad ()
		{
			this.InitScreen();
		}

		#endregion

		#region Function

		private void InitScreen ()
		{
			this.cboUserGroup.SetDataValue("%");
            this.cboUserGubun.SetDataValue("%");
		}

		#endregion

		#region XEditGrid

		private void grdUserList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			//신규입력이면 로그인등록버튼 Disable
			//버튼 활성화 처리 (Inserted된 Row는 버튼 활성화 하면 안됨)
			if ((e.CurrentRow >= 0) && (this.grdUserList.GetRowState(e.CurrentRow) == DataRowState.Added))
			{
				this.grdUserList.ChangeButtonEnable("reg_entr_sys", e.CurrentRow, false);
			}
		}

		private void grdUserList_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
		{
			if (e.ColName == "reg_entr_sys")
			{
                string userID = e.DataRow["user_id"].ToString();
				RegSystemForm dlg = new RegSystemForm(userID, mHospCode);
				dlg.ShowDialog(EnvironInfo.MdiForm);
				dlg.Dispose();
			}
		}

		private void grdUserList_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
            string endDate = this.grdUserList.GetItemString(e.RowNumber, "user_end_ymd");

			if (!TypeCheck.IsDateTime(endDate))
			{
				return ;
			}

			DateTime dtEndDate = DateTime.Parse(endDate);

			if (dtEndDate <= EnvironInfo.GetSysDate())
			{
				e.ForeColor = this.endForeColor.Color;
			}
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query :

					e.IsBaseCall = false;
                    if (UserInfo.AdminType == AdminType.SuperAdmin)
                    {
                        xEditGridCell7.ComboItems.Clear();
                        xEditGridCell7.ComboItems.Add("", "");
                        foreach (ComboListItemInfo item in ExecuteGrdCombo())
                        {
                            xEditGridCell7.ComboItems.Add(item.Code, item.CodeName);
                        }
                        grdUserList.RefreshComboItems("smo_organize");
                    }

                    //this.dsvUserQry.SetInValue("user_group" , this.cboUserGroup.GetDataValue());
                    //this.dsvUserQry.SetInValue("search_word", this.txtSearchWord.GetDataValue());

                    //this.DataServiceCall(this.dsvUserQry);
                    //this.grdUserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //this.grdUserList.SetBindVarValue("f_user_group", this.cboUserGroup.GetDataValue().ToString());
                    //this.grdUserList.SetBindVarValue("f_search_word", this.txtSearchWord.GetDataValue().ToString());
                    this.grdUserList.QueryLayout(true);
					break;
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    try
                    {
                        //Service.BeginTransaction();

                        //ADM104UGridUserSaveLayoutArgs args = new ADM104UGridUserSaveLayoutArgs();
                        //args.ItemInfo = CreateListADM104UGridUser();

                        //// No record was modified
                        //if (args.ItemInfo.Count == 0)
                        //{
                        //    XMessageBox.Show(Resources.MSG_4, Resources.MSG_CAP_2, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}

                        //args.UserId = UserInfo.UserID;
                        ////args.HospCode = this.fbxHospitalID.Text;
                        //args.HospCode = mHospCode;
                        //if (!checkValidate())
                        //{
                        //    this.mCap = Resources.MSG_CAP_2;
                        //    XMessageBox.Show(Resources.MSG_RQ_INPUT, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //else
                        //{
                        //    UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, ADM104UGridUserSaveLayoutArgs>(args);

                        //    if (updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result == true)
                        //    {
                        //        this.mMsg = Resources.MSG_CAP_1;
                        //        this.mCap = Resources.MSG_1;
                        //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //        //                            Service.CommitTransaction();

                        //        this.grdUserList.QueryLayout(true);
                        //    }
                        //    else
                        //    {
                        //        this.mCap = Resources.MSG_CAP_2;
                        //        XMessageBox.Show(Resources.MSG_SAVE_ERROR, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                               
                        //    }
                        //}

                        // 2015.08.11 AnhNV Added START
                        string errMsg = string.Empty;
                        
                        ADM104UGridUserSaveLayoutArgs args = new ADM104UGridUserSaveLayoutArgs();
                        args.ItemInfo = CreateListADM104UGridUser(out errMsg);
                        args.UserId = UserInfo.UserID;
                        args.HospCode = mHospCode;

                        // Moves this validate into CreateListADM104UGridUser
                        // https://sofiamedix.atlassian.net/browse/MED-10181
                        //if (!Validate(args.ItemInfo))
                        //{
                        //    return;
                        //}
                        if (!CheckNameValid(args.ItemInfo))
                        {
                            XMessageBox.Show(Resources.MSG_9, Resources.Cap_9, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdUserList.SetFocusToItem(grdUserList.CurrentRowNumber, "user_nm", true);
                            return;
                        }                    
                        if (!TypeCheck.IsNull(errMsg))
                        {
                            this.mCap = Resources.MSG_CAP_2;
                            XMessageBox.Show(errMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, ADM104UGridUserSaveLayoutArgs>(args);

                        if (updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result == true)
                        {
                            this.mMsg = Resources.MSG_CAP_1;
                            this.mCap = Resources.MSG_1;
                            XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            //this.grdUserList.ResetUpdate();
                        }
                        else
                        {
                            this.mCap = Resources.MSG_CAP_2;
                            XMessageBox.Show(Resources.MSG_SAVE_ERROR, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        // 2015.08.11 AnhNV Added END
                    }
                    catch (Exception ee)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(ee.Message);
                        //Service.RollbackTransaction();
                    }
                    finally
                    {

                    }
                    this.btnList.PerformClick(FunctionType.Query);
                    break;

				case FunctionType.Reset :

					e.IsBaseCall = false;

					this.Reset();

					this.InitScreen();

					break;
			}
		}

        private bool CheckNameValid(List<ADM104UGridUserInfo> list)
        {
            foreach (ADM104UGridUserInfo info in list)
            {
                if (!Utilities.ValidateName(info.UserNm))
                {
                    return false;
                }
            }
            return true;
        }

		#endregion

		private void btnIlgwalInsert_Click(object sender, System.EventArgs e)
		{
			this.OpenForm_DoctorIlgwalRegform();
		}

        private void grdUserList_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            if (e.ColName == "dept_code")
            {
                this.grdUserList.SetItemValue(e.RowNumber, "deptName", e.ReturnValues[1].ToString());
            }
            else if (e.ColName == "user_group")
            {
                this.grdUserList.SetItemValue(e.RowNumber, "grpName", e.ReturnValues[1].ToString());
            }
        }

        #region XSavePerformer
//        private class XSavePerformer : ISavePerformer
//        {
//            private ADM104U parent = null;

//            public XSavePerformer(ADM104U parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";
//                object t_dup_check = "";

//                string procName = "PR_ADM_INSERT_SUBPART_DOCTOR";
//                ArrayList inList = new ArrayList();
//                ArrayList outList = new ArrayList();

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("f_sys_id", UserInfo.UserID);

//                switch (callerID)
//                {
//                    case '1':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @" INSERT INTO ADM3200
//                                             (  HOSP_CODE
//                                             ,  SYS_ID
//                                             ,  USER_ID
//                                             ,  USER_NM
//                                             ,  USER_SCRT
//                                             ,  DEPT_CODE
//                                             ,  USER_GROUP
//                                             ,  USER_LEVEL
//                                             ,  USER_END_YMD
//                                             ,  USER_GUBUN
//                                             ,  UP_MEMB
//                                             ,  UP_TIME  
//                                             ,  CR_MEMB
//                                             ,  CR_TIME
//                                             ,  NURSE_CONFIRM_ENABLE_YN
//                                             ,  CO_ID
//                                              )
//                                        VALUES (:f_hosp_code
//                                             ,  :f_sys_id
//                                             ,  :f_user_id
//                                             ,  :f_user_nm
//                                             ,  :f_user_scrt
//                                             ,  :f_dept_code
//                                             ,  :f_user_group
//                                             ,  :f_user_level
//                                             ,  :f_user_end_ymd
//                                             ,  :f_user_gubun
//                                             ,  :f_sys_id
//                                             ,   SYSDATE
//                                             ,  :f_sys_id
//                                             ,   SYSDATE
//                                             ,  :f_nurse_confirm_enable_yn
//                                             ,  :f_co_id) ";

//                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                    return false;

//                                inList = new ArrayList();
//                                outList = new ArrayList();

//                                inList.Add(EnvironInfo.HospCode);
//                                inList.Add(item.BindVarList["f_user_id"].VarValue);
//                                inList.Add("I");

//                                if (Service.ExecuteProcedure(procName, inList, outList) == false)
//                                {
//                                    throw new Exception(outList[1].ToString());
//                                    XMessageBox.Show(outList[1].ToString());
//                                    return false;
//                                }
                                    
//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE ADM3200
//                                               SET USER_NM       = :f_user_nm
//                                                 , USER_SCRT     = :f_user_scrt
//                                                 , DEPT_CODE     = :f_dept_code
//                                                 , USER_GROUP    = :f_user_group
//                                                 , USER_LEVEL    = :f_user_level
//                                                 , USER_END_YMD  = :f_user_end_ymd
//                                                 , USER_GUBUN    = :f_user_gubun
//                                                 , UP_MEMB       = :f_sys_id
//                                                 , UP_TIME       = SYSDATE
//                                                 , NURSE_CONFIRM_ENABLE_YN = :f_nurse_confirm_enable_yn
//                                                 , CO_ID         = :f_co_id
//                                             WHERE HOSP_CODE    = :f_hosp_code
//                                               AND USER_ID      = :f_user_id";

//                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                    return false;

//                                break;
//                            case DataRowState.Deleted:

//                                inList = new ArrayList();
//                                outList = new ArrayList();

//                                inList.Add(EnvironInfo.HospCode);
//                                inList.Add(item.BindVarList["f_user_id"].VarValue);
//                                inList.Add("D");

//                                if (Service.ExecuteProcedure(procName, inList, outList) == false)
//                                {
//                                    throw new Exception(outList[1].ToString());
//                                    XMessageBox.Show(outList[1].ToString());
//                                    return false;
//                                }

//                                cmdText = @"DELETE FROM ADM3200
//                                             WHERE HOSP_CODE    = :f_hosp_code
//                                               AND USER_ID      = :f_user_id ";

//                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
//                                    return false;

//                                break;
//                        }
//                        break;
//                }

//                return true;
//            }
//        }
        #endregion

        private void txtSearchWord_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //this.grdUserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdUserList.SetBindVarValue("f_user_group", this.cboUserGroup.GetDataValue().ToString());
            //this.grdUserList.SetBindVarValue("f_search_word", this.txtSearchWord.GetDataValue().ToString());
            //this.grdUserList.SetBindVarValue("f_user_gubun", this.cboUserGubun.GetDataValue().ToString());
            this.grdUserList.QueryLayout(true);
        }


        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.grdUserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdUserList.SetBindVarValue("f_user_group", this.cboUserGroup.GetDataValue().ToString());
            //this.grdUserList.SetBindVarValue("f_search_word", this.txtSearchWord.GetDataValue().ToString());
            //this.grdUserList.SetBindVarValue("f_user_gubun", this.cboUserGubun.GetDataValue().ToString());
            this.grdUserList.QueryLayout(true);
        }

        private void grdUserList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdUserList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdUserList.SetBindVarValue("f_user_group", this.cboUserGroup.GetDataValue().ToString());
            this.grdUserList.SetBindVarValue("f_search_word", this.txtSearchWord.GetDataValue().ToString());
            this.grdUserList.SetBindVarValue("f_user_gubun", this.cboUserGubun.GetDataValue().ToString());
        }

        private void fwkUserGroup_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkUserGroup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fwkBuseoCode_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkBuseoCode.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fwkHospitalID_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkHospitalID.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxID_FindSelected(object sender, FindEventArgs e)
        {
            XFindBox control = (XFindBox)sender;
            XDisplayBox dbxBox = this.dbxHospitalNm;
            dbxBox = this.dbxHospitalNm;
            if (TypeCheck.IsNull(e.ReturnValues) == true)
            {
                dbxBox.SetDataValue("");
            }
            else
            {
                dbxBox.SetDataValue(e.ReturnValues[1].ToString());
            }
        }

        #region Connect to cloud service

        /// <summary>
        /// ExecuteQueryFwkBuseoCode
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryFwkBuseoCode(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM104UFwkBuseoCodeArgs args = new ADM104UFwkBuseoCodeArgs();
            args.BuseoCode = bc["f_buseo_code"] != null ? bc["f_buseo_code"].VarValue : "";
            args.GwaName = bc["f_gwa_name"] != null ? bc["f_gwa_name"].VarValue : "";
            args.HospCode = mHospCode;
            ADM104UFwkBuseoCodeResult result = CloudService.Instance.Submit<ADM104UFwkBuseoCodeResult, ADM104UFwkBuseoCodeArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (
                    ComboListItemInfo item in result.ItemInfo)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryGridUser
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryGridUser(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM104UGridUserArgs args = new ADM104UGridUserArgs();
            args.UserGroup = bc["f_user_group"] != null ? bc["f_user_group"].VarValue : "";
            args.SearchWord = bc["f_search_word"] != null ? bc["f_search_word"].VarValue : "";
            args.UserGubun = bc["f_user_gubun"] != null ? bc["f_user_gubun"].VarValue : "";
            //args.HospCode = this.fbxHospitalID.Text;
            args.HospCode = mHospCode;

            ADM104UGridUserResult result = CloudService.Instance.Submit<ADM104UGridUserResult, ADM104UGridUserArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM104UGridUserInfo item in result.GridUserInfo)
                {
                    object[] objects = 
				{ 
					item.UserId, 
					item.UserNm, 
					item.UserScrt, 
					item.DeptCode, 
					item.BuseoName, 
					item.UserGroup, 
					item.GroupNm, 
					item.UserLevel, 
					item.UserEndYmd, 
					item.UserGubun, 
					item.NurseConfirmEnableYn, 
					item.CoId,
                    null,                    
                    item.Email,
                    item.ClisSmoId,
                    item.ChangePwdFlg,
                    item.LoginFlg,                    
                    item.PwdHistory,
                    item.IschangePwd
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// ExecuteQueryADM103UgrdUserGrp
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryADM103UgrdUserGrp(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UgrdUserGrpArgs args = new ADM103UgrdUserGrpArgs();
            //args.HospCode = this.fbxHospitalID.Text;
            args.HospCode = mHospCode;

            ADM103UgrdUserGrpResult result = CloudService.Instance.Submit<ADM103UgrdUserGrpResult, ADM103UgrdUserGrpArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ADM103UgrdUserGrpInfo item in result.UserList)
                {
                    object[] objects =
                    {
                        item.UserGroup,
                        item.GroupNm
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
	    private List<object[]> ExecuteQueryCboUserGubun(BindVarCollection var)
	    {
            List<object[]> res = new List<object[]>();
            ComboADM1110GetByColNameArgs args = new ComboADM1110GetByColNameArgs();
	        args.ColName = "USER_GUBUN";
            args.GetAll = true;
            //args.HospCode = fbxHospitalID.Text;
            args.HospCode = mHospCode;

            ComboResult comboResult = CacheService.Instance.Get<ComboADM1110GetByColNameArgs, ComboResult>(args);
                //CacheService.Instance.Get<ComboADM1110GetByColNameArgs, ComboResult>(
                //    Constants.CacheKeyCbo.CACHE_COMBO_ADM1110_GET_BY_COL_USER_GUBUN_ALL,
                //    args, delegate(ComboResult result) { return
	                    
                //            result != null && result.ExecutionStatus == ExecutionStatus.Success && result.ComboItem != null && result.ComboItem.Count > 0;
	                    
                //    });

	        if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
	        {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
	            {
	                res.Add(new object[] {info.Code, info.CodeName});
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// ExecuteQueryCboUserGroup
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
	    private List<object[]> ExecuteQueryCboUserGroup(BindVarCollection var)
	    {
	        List<object[]> res = new List<object[]>();
	        ComboUserGroupArgs args = new ComboUserGroupArgs();
            args.GetAll = true;
            //args.HospCode = fbxHospitalID.Text;
            args.HospCode = mHospCode;

            ComboResult comboResult = CacheService.Instance.Get<ComboUserGroupArgs, ComboResult>(args);
                //CacheService.Instance.Get<ComboUserGroupArgs, ComboResult>(
                //    Constants.CacheKeyCbo.CACHE_COMBO_USER_GROUP,
                //    args, delegate(ComboResult result)
                //    {
                //        return
                //            result != null && result.ExecutionStatus == ExecutionStatus.Success && result.ComboItem != null &&
                //            result.ComboItem.Count > 0;
                //    });

	        if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
	        {
	            foreach (ComboListItemInfo info in comboResult.ComboItem)
	            {
	                res.Add(new object[] {info.Code, info.CodeName});
	            }
	        }
	        return res;
	    }

        /// <summary>
        /// GridUserSaveLayout
        /// </summary>
        /// <returns></returns>
        //private bool GridUserSaveLayout()
        //{
        //    ADM104UGridUserSaveLayoutArgs args = new ADM104UGridUserSaveLayoutArgs();
        //    args.ItemInfo = CreateListADM104UGridUser();
        //    args.UserId = UserInfo.UserID;
        //    //args.HospCode = this.fbxHospitalID.Text;
        //    args.HospCode = mHospCode;

        //    UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, ADM104UGridUserSaveLayoutArgs>(args);
        //    if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
        //        updateResult.Result == false)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
      
        /// <summary>
        /// CreateListADM104UGridUser
        /// </summary>
        /// <returns></returns>
	    private List<ADM104UGridUserInfo> CreateListADM104UGridUser(out string errMsg)
	    {
            errMsg = string.Empty;

	        List<ADM104UGridUserInfo> ListGridUser = new List<ADM104UGridUserInfo>();
	        for (int i = 0; i < grdUserList.Rows; i++)
	        {
	            if (grdUserList.GetRowState(i) == DataRowState.Added || grdUserList.GetRowState(i) == DataRowState.Modified)
	            {
	                // UserId is empty
	                if (TypeCheck.IsNull(grdUserList.GetItemString(i, "user_id")))
	                {
	                    errMsg = Resources.MSG_REQ_USER_ID;
	                    return ListGridUser;
	                }

	                // Password is empty
	                if (TypeCheck.IsNull(grdUserList.GetItemString(i, "user_scrt")))
	                {
	                    errMsg = Resources.MSG_REQ_PSW;
	                    return ListGridUser;
	                }

                    //Check CLIS MED-9435
                    if (grdUserList.GetItemString(i, "user_group") == "CLIS" && TypeCheck.IsNull(grdUserList.GetItemString(i, "smo_organize")))
                    {
                        errMsg = Resources.MSG_CLIS;
                        return ListGridUser;
                    }

                    // Validate email
                    // https://sofiamedix.atlassian.net/browse/MED-10181
                    string email = grdUserList.GetItemString(i, "email");
                    if (UserInfo.VpnYn)
                    {
                        // In case of using VPN
                        if (TypeCheck.IsNull(email))
                        {
                            errMsg = Resources.MSG_REQ_EMAIL;
                            return ListGridUser;
                        }
                    }

                    // In case of non-using VPN
                    if (!TypeCheck.IsNull(email) && !EmailIsValid(email))
                    {
                        errMsg = Resources.MSG_EMAIL_INVALID;
                        return ListGridUser;
                    }

                    //check pass
                    string isChangePwd = "";
                    string pswHist = "";
                    int count = 0;

                    // Code review
                    //foreach (char c in grdUserList.GetItemString(i, "pwd_history"))
                    //{
                    //    if (c == '>') count++;
                    //}
                    count = grdUserList.GetItemString(i, "pwd_history").Split('>').Length - 1;

                    //count = 2
                    if (count == 2)
                    {
                        string[] pwdHis = grdUserList.GetItemString(i, "pwd_history").Split('>');
                        if (grdUserList.GetItemString(i, "user_scrt") == pwdHis[0])
                        {
                            isChangePwd = "0" ;
                        }
                        else
                        {
                            isChangePwd = "1"  ;
                        }

                        if(isChangePwd == "1" && grdUserList.GetItemString(i, "user_scrt") == pwdHis[0])
                        {
                            errMsg = Resources.MSG_6;
                            return ListGridUser;
                        }

                        if(isChangePwd == "1" && grdUserList.GetItemString(i, "user_scrt") == pwdHis[1])
                        {
                            errMsg = Resources.MSG_7;
                            return ListGridUser;
                        }

                        if(isChangePwd == "1" && grdUserList.GetItemString(i, "user_scrt") == pwdHis[2])
                        {
                            errMsg = Resources.MSG_7;
                            return ListGridUser;
                        }

                        string pw = grdUserList.GetItemString(i, "pwd_history");
                        if (pw == string.Empty)
                        {
                            pswHist = grdUserList.GetItemString(i, "user_scrt");
                        }
                        else
                        {
                            try
                            {
                                pswHist = grdUserList.GetItemString(i, "user_scrt") + ">" + pw.Remove(pw.IndexOf(">", pw.IndexOf(">") + 1));
                            }
                            catch
                            {
                                pswHist = grdUserList.GetItemString(i, "user_scrt") + ">" + pw.Remove(pw.IndexOf(">"));
                            }
                        }
                    }

                    //count == 1
                    if (count == 1)
                    {
                        string[] pwdHis = grdUserList.GetItemString(i, "pwd_history").Split('>');
                        if (grdUserList.GetItemString(i, "user_scrt") == pwdHis[0])
                        {
                            isChangePwd = "0" ;
                        }
                        else
                        {
                            isChangePwd = "1";
                        }

                        if (isChangePwd == "1" && grdUserList.GetItemString(i, "user_scrt") == pwdHis[0])
                        {
                            errMsg = Resources.MSG_6;
                            return ListGridUser;
                        }

                        if (isChangePwd == "1" && grdUserList.GetItemString(i, "user_scrt") == pwdHis[1])
                        {
                            errMsg = Resources.MSG_7;
                            return ListGridUser;
                        }

                        string pw = grdUserList.GetItemString(i, "pwd_history");
                        if (pw == string.Empty)
                        {
                            pswHist = grdUserList.GetItemString(i, "user_scrt");
                        }
                        else
                        {
                            pswHist = grdUserList.GetItemString(i, "user_scrt") + ">" + pw;
                        }
                    }

                    //count = 0 
                    if (count == 0)
                    {
                        isChangePwd = "1";

                        string pw = grdUserList.GetItemString(i, "pwd_history");
                        pswHist = grdUserList.GetItemString(i, "user_scrt") + ">" + pw;
                    }

                    ADM104UGridUserInfo gridUserInfo = new ADM104UGridUserInfo();
                    gridUserInfo.UserId = grdUserList.GetItemString(i, "user_id");
                    gridUserInfo.UserNm = grdUserList.GetItemString(i, "user_nm");
                    gridUserInfo.UserScrt = grdUserList.GetItemString(i, "user_scrt");
                    gridUserInfo.DeptCode = grdUserList.GetItemString(i, "dept_code");
                    gridUserInfo.BuseoName = grdUserList.GetItemString(i, "deptName");
                    gridUserInfo.UserGroup = grdUserList.GetItemString(i, "user_group");
                    gridUserInfo.GroupNm = grdUserList.GetItemString(i, "grpName");
                    gridUserInfo.UserLevel = grdUserList.GetItemString(i, "user_level");
                    gridUserInfo.UserEndYmd = grdUserList.GetItemString(i, "user_end_ymd");
                    gridUserInfo.UserGubun = grdUserList.GetItemString(i, "user_gubun");
                    gridUserInfo.NurseConfirmEnableYn = grdUserList.GetItemString(i, "nurse_confirm_enable_yn");
                    gridUserInfo.CoId = grdUserList.GetItemString(i, "co_id");
                    gridUserInfo.Email = grdUserList.GetItemString(i, "email");
                    gridUserInfo.ClisSmoId = grdUserList.GetItemString(i, "smo_organize");
                    gridUserInfo.DataRowState = grdUserList.GetRowState(i).ToString();
                    gridUserInfo.ChangePwdFlg = grdUserList.GetItemValue(i, "change_pwd_flg").ToString();
                    gridUserInfo.PwdHistory = pswHist;
                    gridUserInfo.IschangePwd = isChangePwd;
                    // MED-10901
                    gridUserInfo.PlainPwd = grdUserList.GetItemString(i, "plain_pwd");
                    //gridUserInfo.Pl = isChangePwd;
                    ListGridUser.Add(gridUserInfo);
	            }
	        }

	        if (grdUserList.DeletedRowTable != null && grdUserList.DeletedRowCount > 0)
	        {
	            foreach (DataRow row in grdUserList.DeletedRowTable.Rows)
	            {
                    ADM104UGridUserInfo gridUserInfo = new ADM104UGridUserInfo();

                    gridUserInfo.UserId = row["user_id"].ToString();
                    gridUserInfo.UserNm = row["user_nm"].ToString();
                    gridUserInfo.UserScrt = row["user_scrt"].ToString();
                    gridUserInfo.DeptCode = row["dept_code"].ToString();
                    gridUserInfo.BuseoName = row["deptName"].ToString();
                    gridUserInfo.UserGroup = row["user_group"].ToString();
                    gridUserInfo.GroupNm = row["grpName"].ToString();
                    gridUserInfo.UserLevel = row["user_level"].ToString();
                    gridUserInfo.UserEndYmd = row["user_end_ymd"].ToString();
                    gridUserInfo.UserGubun = row["user_gubun"].ToString();
                    gridUserInfo.NurseConfirmEnableYn = row["nurse_confirm_enable_yn"].ToString();
                    gridUserInfo.CoId = row["co_id"].ToString();
                    gridUserInfo.Email = row["email"].ToString();
                    gridUserInfo.ClisSmoId = row["smo_organize"].ToString();
                    gridUserInfo.DataRowState = DataRowState.Deleted.ToString();

                    ListGridUser.Add(gridUserInfo);
	            }
	        }
	        return ListGridUser;
	    }

        private IList<object[]> GetFwkHospitalId(BindVarCollection bvc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UGetFwkHospitalArgs args = new ADM103UGetFwkHospitalArgs();
            ADM103UGetFwkHospitalResult result = CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.HospList)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDataLayCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UValidateFwkHospitalArgs args = new ADM103UValidateFwkHospitalArgs();
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            ADM103UValidateFwkHospitalResult result = CloudService.Instance.Submit<ADM103UValidateFwkHospitalResult, ADM103UValidateFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.HospName
                });
            }
            return res;
        } 

        #endregion

        private void layCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCommon.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void fbxHospitalID_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.mHospCode = fbxHospitalID.Text;
            cboUserGroup.SetDictDDLB();
            cboUserGubun.SetDictDDLB();

            this.layCommon.QueryLayout();
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                this.btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                this.grdUserList.QueryLayout(true);
            }
        }
        private IList<object[]> ExecuteGrdCombo(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            object[] nullobjects = { "", "" };
            res.Add(nullobjects);
            ADM104UClisComboArgs args = new ADM104UClisComboArgs();
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                args.HospCode = fbxHospitalID.Text.Trim();
            }
            else
            {
                args.HospCode = UserInfo.HospCode;
            }
            //args.HospCode = mHospCode;
            ADM104UClisComboResult result = CloudService.Instance.Submit<ADM104UClisComboResult, ADM104UClisComboArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeName,
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<ComboListItemInfo> ExecuteGrdCombo()
        {
            IList<object[]> res = new List<object[]>();
            ADM104UClisComboArgs args = new ADM104UClisComboArgs();
            if (fbxHospitalID.Visible)
            {
                args.HospCode = fbxHospitalID.Text.Trim();
            }
            else
            {
                args.HospCode = UserInfo.HospCode;
            }
            //args.HospCode = mHospCode;
            ADM104UClisComboResult result = CloudService.Instance.Submit<ADM104UClisComboResult, ADM104UClisComboArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Dt;
            }
            return null;
        }

        private void grdUserList_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell7.ExecuteQuery = ExecuteGrdCombo;
        }

        private bool Validate(List<ADM104UGridUserInfo> lst)
	    {
            foreach (ADM104UGridUserInfo item in lst)
            {
                if ((item.DataRowState == "Added" || item.DataRowState == "Updated" || item.DataRowState == "Modified") && item.Email != null && item.Email != "")
                {
                    if (!EmailIsValid(item.Email))
                    {
                        XMessageBox.Show(Resources.MSG_5, Resources.CAP_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                
            }
            return true;
	    }

	    public static bool EmailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void grdUserList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "user_scrt")
            {
                XEditGrid grid = sender as XEditGrid;
                
                string pass = grid.GetItemString(e.RowNumber, "user_scrt").Trim();
                //Fix MED-8114
                if (pass.Length < 8)
                {
                    string errMsg = Resources.MSG_8;
                    XMessageBox.Show(errMsg, mCap, MessageBoxIcon.Error);
                    grid.SetItemValue(grid.CurrentRowNumber, "user_scrt", null);
                    return;
                }
                else
                {
                    grid.SetItemValue(grid.CurrentRowNumber, "user_scrt", Utility.CreateMd5Hash(pass, false));

                    // MED-10901
                    grid.SetItemValue(grid.CurrentRowNumber, "plain_pwd", pass);
                }
            }
                // 항목코드
            
        }
        //add validate
        //private bool checkValidate()
        //{

        //    List<ADM104UGridUserInfo> args = CreateListADM104UGridUser();
                     
        //    foreach (ADM104UGridUserInfo info in args)
        //    {
        //        if (info.UserId == "")
        //        {
        //            return false;
        //        }
        //        if (info.UserNm == "")
        //        {
        //            return false;
        //        }
        //        if (info.UserScrt == "")
        //        {
        //            return false;
        //        }
        //        if (info.DeptCode == "")
        //        {
        //            return false;
        //        } 
        //        if (info.BuseoName == "")
        //        {
        //            return false;
        //        } 
        //        if (info.UserGroup == "")
        //        {
        //            return false;
        //        } 
        //        if (info.UserLevel == "")
        //        {
        //            return false;
        //        }
                
        //    }
        //    return true;
        //}
    }
}

