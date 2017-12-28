#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0311U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0311U00 : IHIS.Framework.XScreen
	{

		#region 사용자 변수
		string msgCode = string.Empty;
		#endregion

		private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XTextBox txtMent;
		private IHIS.Framework.XFindWorker fwkFind;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.SingleLayout layFind;
		private IHIS.Framework.SingleLayout layBilLoad;
        private IHIS.Framework.SingleLayout layPointAMTBanyoung;
        private IHIS.Framework.XEditGrid grdList;
        private SingleLayoutItem singleLayoutItem1;
        private XDisplayBox dbxDanui_Name;
        private XLabel xLabel62;
        private XLabel xLabel12;
        private XLabel xLabel11;
        private XLabel xLabel37;
        private XLabel xLabel36;
        private XLabel xLabel35;
        private XLabel xLabel33;
        private XDisplayBox dbxMarume_Name;
        private XCheckBox cbxGroup_Gubun;
        private XLabel xLabel19;
        private XLabel xLabel16;
        private XDisplayBox dbxBun_Code_Name;
        private XLabel xLabel14;
        private XLabel xLabel13;
        private XLabel xLabel5;
        private XLabel xLabel3;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XDisplayBox dbxSg_Code;
        private XDisplayBox dbxSg_Union;
        private XDisplayBox dbxSg_Name;
        private XDisplayBox dbxSg_Name_Kana;
        private XDisplayBox dbxSuga_Change;
        private XDisplayBox dbxBulyong_Sayu;
        private XDisplayBox dbxBulyong_Ymd;
        private XDisplayBox dbxSg_Ymd;
        private XDisplayBox dbxHubal_Gubun;
        private XDisplayBox dbxSunab_Qcode_Out;
        private XDisplayBox dbxSunab_Qcode_Inp;
        private XEditGridCell xEditGridCell18;
        private XCheckBox cbxTax_yn;
        private XLabel xLabel4;
		
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0311U00()
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
		/// 이 메서드의 내용을 コード 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0311U00));
            this.fwkFind = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.dbxSg_Code = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.cbxGroup_Gubun = new IHIS.Framework.XCheckBox();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.dbxSg_Name = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.dbxSg_Name_Kana = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.dbxSg_Ymd = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.dbxSuga_Change = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.dbxBulyong_Ymd = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.dbxBulyong_Sayu = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.dbxDanui_Name = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.dbxBun_Code_Name = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.dbxSg_Union = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.txtMent = new IHIS.Framework.XTextBox();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.dbxMarume_Name = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.dbxHubal_Gubun = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.dbxSunab_Qcode_Out = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.dbxSunab_Qcode_Inp = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.cbxTax_yn = new IHIS.Framework.XCheckBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel37 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel62 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel36 = new IHIS.Framework.XLabel();
            this.xLabel35 = new IHIS.Framework.XLabel();
            this.xLabel33 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layFind = new IHIS.Framework.SingleLayout();
            this.layBilLoad = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layPointAMTBanyoung = new IHIS.Framework.SingleLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // fwkFind
            // 
            this.fwkFind.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkFind.ExecuteQuery = null;
            this.fwkFind.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkFind.ParamList")));
            this.fwkFind.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkFind.ServerFilter = true;
            this.fwkFind.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkFind_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "sg_code";
            this.findColumnInfo1.ColWidth = 119;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sg_name";
            this.findColumnInfo2.ColWidth = 364;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdList
            // 
            resources.ApplyResources(this.grdList, "grdList");
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell18});
            this.grdList.ColPerLine = 4;
            this.grdList.Cols = 4;
            this.grdList.ControlBinding = true;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(27);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.ReadOnly = true;
            this.grdList.Rows = 2;
            this.grdList.ToolTipActive = true;
            this.grdList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdList_RowFocusChanged);
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.BindControl = this.dbxSg_Code;
            this.xEditGridCell1.CellName = "sg_code";
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // dbxSg_Code
            // 
            this.dbxSg_Code.AccessibleDescription = null;
            this.dbxSg_Code.AccessibleName = null;
            resources.ApplyResources(this.dbxSg_Code, "dbxSg_Code");
            this.dbxSg_Code.Image = null;
            this.dbxSg_Code.Name = "dbxSg_Code";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.BindControl = this.cbxGroup_Gubun;
            this.xEditGridCell2.CellName = "group_gubun";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // cbxGroup_Gubun
            // 
            this.cbxGroup_Gubun.AccessibleDescription = null;
            this.cbxGroup_Gubun.AccessibleName = null;
            resources.ApplyResources(this.cbxGroup_Gubun, "cbxGroup_Gubun");
            this.cbxGroup_Gubun.BackgroundImage = null;
            this.cbxGroup_Gubun.Name = "cbxGroup_Gubun";
            this.cbxGroup_Gubun.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.dbxSg_Name;
            this.xEditGridCell3.CellName = "sg_name";
            this.xEditGridCell3.CellWidth = 191;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // dbxSg_Name
            // 
            this.dbxSg_Name.AccessibleDescription = null;
            this.dbxSg_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxSg_Name, "dbxSg_Name");
            this.dbxSg_Name.Image = null;
            this.dbxSg_Name.Name = "dbxSg_Name";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.dbxSg_Name_Kana;
            this.xEditGridCell4.CellName = "sg_name_kana";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // dbxSg_Name_Kana
            // 
            this.dbxSg_Name_Kana.AccessibleDescription = null;
            this.dbxSg_Name_Kana.AccessibleName = null;
            resources.ApplyResources(this.dbxSg_Name_Kana, "dbxSg_Name_Kana");
            this.dbxSg_Name_Kana.Image = null;
            this.dbxSg_Name_Kana.Name = "dbxSg_Name_Kana";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.dbxSg_Ymd;
            this.xEditGridCell5.CellName = "sg_ymd";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 93;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // dbxSg_Ymd
            // 
            this.dbxSg_Ymd.AccessibleDescription = null;
            this.dbxSg_Ymd.AccessibleName = null;
            resources.ApplyResources(this.dbxSg_Ymd, "dbxSg_Ymd");
            this.dbxSg_Ymd.Image = null;
            this.dbxSg_Ymd.Name = "dbxSg_Ymd";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "suga_change";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.dbxSuga_Change;
            this.xEditGridCell7.CellName = "suga_change_nm_d";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // dbxSuga_Change
            // 
            this.dbxSuga_Change.AccessibleDescription = null;
            this.dbxSuga_Change.AccessibleName = null;
            resources.ApplyResources(this.dbxSuga_Change, "dbxSuga_Change");
            this.dbxSuga_Change.Image = null;
            this.dbxSuga_Change.Name = "dbxSuga_Change";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.dbxBulyong_Ymd;
            this.xEditGridCell8.CellName = "bulyong_ymd";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.CellWidth = 123;
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // dbxBulyong_Ymd
            // 
            this.dbxBulyong_Ymd.AccessibleDescription = null;
            this.dbxBulyong_Ymd.AccessibleName = null;
            resources.ApplyResources(this.dbxBulyong_Ymd, "dbxBulyong_Ymd");
            this.dbxBulyong_Ymd.Image = null;
            this.dbxBulyong_Ymd.Name = "dbxBulyong_Ymd";
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "bulyong_sayu";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.dbxBulyong_Sayu;
            this.xEditGridCell10.CellName = "bulyong_sayu_nm_d";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // dbxBulyong_Sayu
            // 
            this.dbxBulyong_Sayu.AccessibleDescription = null;
            this.dbxBulyong_Sayu.AccessibleName = null;
            resources.ApplyResources(this.dbxBulyong_Sayu, "dbxBulyong_Sayu");
            this.dbxBulyong_Sayu.Image = null;
            this.dbxBulyong_Sayu.Name = "dbxBulyong_Sayu";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "danui";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.BindControl = this.dbxDanui_Name;
            this.xEditGridCell12.CellName = "danui_name";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // dbxDanui_Name
            // 
            this.dbxDanui_Name.AccessibleDescription = null;
            this.dbxDanui_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxDanui_Name, "dbxDanui_Name");
            this.dbxDanui_Name.Image = null;
            this.dbxDanui_Name.Name = "dbxDanui_Name";
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bun_code";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.dbxBun_Code_Name;
            this.xEditGridCell14.CellName = "bun_code_name";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // dbxBun_Code_Name
            // 
            this.dbxBun_Code_Name.AccessibleDescription = null;
            this.dbxBun_Code_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxBun_Code_Name, "dbxBun_Code_Name");
            this.dbxBun_Code_Name.Image = null;
            this.dbxBun_Code_Name.Name = "dbxBun_Code_Name";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "marume_gubun";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.dbxSg_Union;
            this.xEditGridCell16.CellName = "sg_union";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // dbxSg_Union
            // 
            this.dbxSg_Union.AccessibleDescription = null;
            this.dbxSg_Union.AccessibleName = null;
            resources.ApplyResources(this.dbxSg_Union, "dbxSg_Union");
            this.dbxSg_Union.Image = null;
            this.dbxSg_Union.Name = "dbxSg_Union";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.BindControl = this.txtMent;
            this.xEditGridCell17.CellName = "remark";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // txtMent
            // 
            this.txtMent.AccessibleDescription = null;
            this.txtMent.AccessibleName = null;
            resources.ApplyResources(this.txtMent, "txtMent");
            this.txtMent.BackgroundImage = null;
            this.txtMent.Name = "txtMent";
            this.txtMent.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtMent_DataValidating);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.dbxMarume_Name;
            this.xEditGridCell19.CellLen = 100;
            this.xEditGridCell19.CellName = "marume_name";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // dbxMarume_Name
            // 
            this.dbxMarume_Name.AccessibleDescription = null;
            this.dbxMarume_Name.AccessibleName = null;
            resources.ApplyResources(this.dbxMarume_Name, "dbxMarume_Name");
            this.dbxMarume_Name.Image = null;
            this.dbxMarume_Name.Name = "dbxMarume_Name";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.BindControl = this.dbxHubal_Gubun;
            this.xEditGridCell20.CellLen = 1;
            this.xEditGridCell20.CellName = "hubal_drg_yn";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // dbxHubal_Gubun
            // 
            this.dbxHubal_Gubun.AccessibleDescription = null;
            this.dbxHubal_Gubun.AccessibleName = null;
            resources.ApplyResources(this.dbxHubal_Gubun, "dbxHubal_Gubun");
            this.dbxHubal_Gubun.Image = null;
            this.dbxHubal_Gubun.Name = "dbxHubal_Gubun";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.BindControl = this.dbxSunab_Qcode_Out;
            this.xEditGridCell21.CellLen = 2;
            this.xEditGridCell21.CellName = "sunab_qcode_out";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // dbxSunab_Qcode_Out
            // 
            this.dbxSunab_Qcode_Out.AccessibleDescription = null;
            this.dbxSunab_Qcode_Out.AccessibleName = null;
            resources.ApplyResources(this.dbxSunab_Qcode_Out, "dbxSunab_Qcode_Out");
            this.dbxSunab_Qcode_Out.Image = null;
            this.dbxSunab_Qcode_Out.Name = "dbxSunab_Qcode_Out";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.BindControl = this.dbxSunab_Qcode_Inp;
            this.xEditGridCell22.CellLen = 2;
            this.xEditGridCell22.CellName = "sunab_qcode_inp";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // dbxSunab_Qcode_Inp
            // 
            this.dbxSunab_Qcode_Inp.AccessibleDescription = null;
            this.dbxSunab_Qcode_Inp.AccessibleName = null;
            resources.ApplyResources(this.dbxSunab_Qcode_Inp, "dbxSunab_Qcode_Inp");
            this.dbxSunab_Qcode_Inp.Image = null;
            this.dbxSunab_Qcode_Inp.Name = "dbxSunab_Qcode_Inp";
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.cbxTax_yn;
            this.xEditGridCell18.CellName = "tax_yn";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // cbxTax_yn
            // 
            this.cbxTax_yn.AccessibleDescription = null;
            this.cbxTax_yn.AccessibleName = null;
            resources.ApplyResources(this.cbxTax_yn, "cbxTax_yn");
            this.cbxTax_yn.BackgroundImage = null;
            this.cbxTax_yn.Name = "cbxTax_yn";
            this.cbxTax_yn.UseVisualStyleBackColor = false;
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xLabel37);
            this.xPanel2.Controls.Add(this.cbxTax_yn);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.dbxSunab_Qcode_Inp);
            this.xPanel2.Controls.Add(this.dbxSunab_Qcode_Out);
            this.xPanel2.Controls.Add(this.dbxHubal_Gubun);
            this.xPanel2.Controls.Add(this.dbxSg_Name_Kana);
            this.xPanel2.Controls.Add(this.dbxSg_Name);
            this.xPanel2.Controls.Add(this.dbxBulyong_Sayu);
            this.xPanel2.Controls.Add(this.dbxSuga_Change);
            this.xPanel2.Controls.Add(this.dbxBulyong_Ymd);
            this.xPanel2.Controls.Add(this.dbxSg_Ymd);
            this.xPanel2.Controls.Add(this.dbxSg_Union);
            this.xPanel2.Controls.Add(this.dbxSg_Code);
            this.xPanel2.Controls.Add(this.dbxDanui_Name);
            this.xPanel2.Controls.Add(this.xLabel62);
            this.xPanel2.Controls.Add(this.xLabel12);
            this.xPanel2.Controls.Add(this.xLabel11);
            this.xPanel2.Controls.Add(this.xLabel36);
            this.xPanel2.Controls.Add(this.xLabel35);
            this.xPanel2.Controls.Add(this.xLabel33);
            this.xPanel2.Controls.Add(this.dbxMarume_Name);
            this.xPanel2.Controls.Add(this.cbxGroup_Gubun);
            this.xPanel2.Controls.Add(this.xLabel19);
            this.xPanel2.Controls.Add(this.xLabel16);
            this.xPanel2.Controls.Add(this.dbxBun_Code_Name);
            this.xPanel2.Controls.Add(this.xLabel14);
            this.xPanel2.Controls.Add(this.xLabel13);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel37
            // 
            this.xLabel37.AccessibleDescription = null;
            this.xLabel37.AccessibleName = null;
            resources.ApplyResources(this.xLabel37, "xLabel37");
            this.xLabel37.Image = null;
            this.xLabel37.Name = "xLabel37";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel62
            // 
            this.xLabel62.AccessibleDescription = null;
            this.xLabel62.AccessibleName = null;
            resources.ApplyResources(this.xLabel62, "xLabel62");
            this.xLabel62.Image = null;
            this.xLabel62.Name = "xLabel62";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel36
            // 
            this.xLabel36.AccessibleDescription = null;
            this.xLabel36.AccessibleName = null;
            resources.ApplyResources(this.xLabel36, "xLabel36");
            this.xLabel36.Image = null;
            this.xLabel36.Name = "xLabel36";
            // 
            // xLabel35
            // 
            this.xLabel35.AccessibleDescription = null;
            this.xLabel35.AccessibleName = null;
            resources.ApplyResources(this.xLabel35, "xLabel35");
            this.xLabel35.Image = null;
            this.xLabel35.Name = "xLabel35";
            // 
            // xLabel33
            // 
            this.xLabel33.AccessibleDescription = null;
            this.xLabel33.AccessibleName = null;
            resources.ApplyResources(this.xLabel33, "xLabel33");
            this.xLabel33.Image = null;
            this.xLabel33.Name = "xLabel33";
            // 
            // xLabel19
            // 
            this.xLabel19.AccessibleDescription = null;
            this.xLabel19.AccessibleName = null;
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.Image = null;
            this.xLabel19.Name = "xLabel19";
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.Image = null;
            this.xLabel16.Name = "xLabel16";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.txtMent);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // layFind
            // 
            this.layFind.ExecuteQuery = null;
            this.layFind.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layFind.ParamList")));
            this.layFind.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layFind_QueryStarting);
            this.layFind.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layFind_QueryEnd);
            // 
            // layBilLoad
            // 
            this.layBilLoad.ExecuteQuery = null;
            this.layBilLoad.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layBilLoad.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBilLoad.ParamList")));
            this.layBilLoad.QuerySQL = resources.GetString("layBilLoad.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "IoValue";
            // 
            // layPointAMTBanyoung
            // 
            this.layPointAMTBanyoung.ExecuteQuery = null;
            this.layPointAMTBanyoung.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPointAMTBanyoung.ParamList")));
            // 
            // BAS0311U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.xButtonList1);
            this.Name = "BAS0311U00";
            this.Load += new System.EventHandler(this.BAS0311U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		// Form Load
		private void BAS0311U00_Load(object sender, System.EventArgs e)
		{
			if (this.OpenParam != null ) 
			{
                this.xPanel2.Enabled = false;
                //this.xPanel3.Enabled = false;
                grdList.ParamList = new List<string>(new String[] { "f_hosp_code", "f_sg_code" });
			    this.grdList.ExecuteQuery = ExecuteQueryGrdListItem;
				msgCode = this.OpenParam["sg_code"].ToString();
				this.grdList.SetBindVarValue("f_sg_code", msgCode);
				this.grdList.QueryLayout(false);
			}
		}

		#region Find 클릭
		private void fbxSgCode_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox findBox = (XFindBox) sender;
			this.MakeFindWorker(findBox.Name);
		}
		#endregion


		#region MakeFindWorker
		//각각의 컨트롤(파인드박스)에 적합한 파인드 워커로 셋팅
		private bool MakeFindWorker(string aCtrName)
		{	
			bool result = false;

            string findQuery3 = @"SELECT A.BUN_CODE
                                       , A.BUN_NAME
                                    FROM BAS0230 A
                                   WHERE A.HOSP_CODE = :f_hosp_code 
                                     AND A.BUN_YMD  = (SELECT MAX(B.BUN_YMD)
                                                         FROM BAS0230 B
                                                        WHERE B.HOSP_CODE = A.HOSP_CODE
                                                          AND B.BUN_CODE  = A.BUN_CODE)
                                     AND (  A.BUN_CODE LIKE :f_find1 || '%'
                                         OR A.BUN_NAME LIKE :f_find1 || '%')
                                   ORDER BY A.BUN_CODE";

            string findQuery4 = @"SELECT CODE
                                       , CODE_NAME
                                    FROM BAS0102
                                   WHERE HOSP_CODE = :f_hosp_code
                                     AND CODE_TYPE = :f_code_type
                                   ORDER BY CODE";

            string findQuery5 = @"SELECT CUSTOMER_CODE
                                         , CUSTOMER_NAME
                                      FROM INV0111
                                     WHERE HOSP_CODE = :f_hosp_code 
                                       AND CUST_GUBUN = '1'
                                     ORDER BY CUSTOMER_CODE";

            string findQuery6 = @"SELECT CODE
                                         , CODE_NAME
                                      FROM OCS0132
                                     WHERE HOSP_CODE = :f_hosp_code 
                                       AND CODE_TYPE = 'ORD_DANUI'
                                     ORDER BY CODE";

            string findQuery7 = @"SELECT A.SUTAK_CODE
                                         , A.YOYANG_NAME
                                      FROM BAS0320 A
                                     WHERE A.HOSP_CODE = :f_hosp_code 
                                       AND A.SUTAK_YMD = (SELECT MAX(B.SUTAK_YMD)
                                                            FROM BAS0320 B
                                                           WHERE B.HOSP_CODE = A.HOSP_CODE
                                                             AND B.SUTAK_CODE = A.SUTAK_CODE)
                                     ORDER BY A.SUTAK_CODE";

            string findQuery8 = @"SELECT CODE
                                     , CODE_NAME
                                  FROM BAS0102
                                 WHERE HOSP_CODE = :f_hosp_code 
                                   AND CODE_TYPE = 'GASAN_GUBUN'
                                   AND (CODE >= 'A' AND CODE <= 'Z')
                                 ORDER BY CODE";

            string findQuery9 = @"SELECT DISTINCT
                                           CODE
                                         , CODE_NAME
                                      FROM BAS0102
                                     WHERE HOSP_CODE = :f_hosp_code 
                                       AND CODE_TYPE = 'CHEGAM_GUBUN'
                                     ORDER BY CODE";

			switch ( aCtrName )
			{
                //case "fbxSgCode":
                //    this.fwkFind.FormText = "点数コード照会";
                //    this.fwkFind.WorkTp = '2';
                //    this.fwkFind.ColInfos[0].HeaderText = "点数コード";
                //    this.fwkFind.ColInfos[1].HeaderText = "点数コード名";
                //    this.fwkFind.InputLayoutItems.Clear();
                //    this.fwkFind.InputLayoutItems.Add("code");
                //    result = true;
                //    break;
                //case "fbxBunCode1":
                //    this.fwkFind.FormText = "分類コード照会";
                //    this.fwkFind.WorkTp = '3';
                //    this.fwkFind.ColInfos[0].HeaderText = "分類コード";
                //    this.fwkFind.ColInfos[1].HeaderText = "分類コード名";
                //    this.fwkFind.InputLayoutItems.Clear();
                //    this.fwkFind.InputLayoutItems.Add("code");
                //    result = true;
                //    break;
				case "fbxBunCode":
					this.fwkFind.FormText = "分類コード照会";
                    this.fwkFind.InputSQL = findQuery3;
					this.fwkFind.ColInfos[0].HeaderText = "分類コード";
					this.fwkFind.ColInfos[1].HeaderText = "分類コード名";
					result = true;
					break;
				case "fbxSubBunCode":
                    this.fwkFind.FormText = "細部分類コード照会";
                    this.fwkFind.InputSQL = findQuery3;
                    this.fwkFind.ColInfos[0].HeaderText = "細部分類コード";
                    this.fwkFind.ColInfos[1].HeaderText = "細部分類コード名";
					result = true;
					break;
				case "fbxBon100YN":
                    this.fwkFind.FormText = "非給与算定コード照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "非給与算定コード";
					this.fwkFind.ColInfos[1].HeaderText = "非給与算定コード名";
					this.fwkFind.SetBindVarValue("f_code_type", "BON_100_YN");
					result = true;
					break;
				case "fbxSgSusuryo":
                    this.fwkFind.FormText = "手数料発生コード照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "手数料発生コード";
					this.fwkFind.ColInfos[1].HeaderText = "手数料発生コード名";
                    this.fwkFind.SetBindVarValue("f_code_type", "SUSURYO_GUBUN");
					result = true;
					break;
				case "fbxSgGesan":
                    this.fwkFind.FormText = "点数計算方法照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "点数計算方法コード";
					this.fwkFind.ColInfos[1].HeaderText = "点数計算方法コード名";
                    this.fwkFind.SetBindVarValue("f_code_type", "GYESAN_METHOD");
					result = true;
					break;
				case "fbxSgEdiGubun":
                    this.fwkFind.FormText = "EID適用コード照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "EDI適用コード";
					this.fwkFind.ColInfos[1].HeaderText = "EDI適用コード名";
                    this.fwkFind.SetBindVarValue("f_code_type", "SG_EDI_GUBUN");
					result = true;
					break;
				case "fbxSunabQcodeOut":
                    this.fwkFind.FormText = "外来収納適用コード照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "外来収納適用コード";
					this.fwkFind.ColInfos[1].HeaderText = "外来収納適用コード名";
                    this.fwkFind.SetBindVarValue("f_code_type", "SUNAB_CONV_CODE");
					result = true;
					break;
				case "fbxSunabQcodeInp":
                    this.fwkFind.FormText = "入院収納適用コード照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "入院収納適用コード";
					this.fwkFind.ColInfos[1].HeaderText = "入院収納適用コード名";
                    this.fwkFind.SetBindVarValue("f_code_type", "SUNAB_CONV_CODE");
					result = true;
					break;
				case "fbxSunabQcodeEr":
                    this.fwkFind.FormText = "応急収納適用コード照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "応急収納適用コード";
					this.fwkFind.ColInfos[1].HeaderText = "応急収納適用コード名";
                    this.fwkFind.SetBindVarValue("f_code_type", "SUNAB_CONV_CODE");
					result = true;
					break;
				case "fbxSugaChange":
                    this.fwkFind.FormText = "点数変更事由照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "点数変更事由コード";
					this.fwkFind.ColInfos[1].HeaderText = "点数変更事由名";
                    this.fwkFind.SetBindVarValue("f_code_type", "SUGA_CHANGE");
					result = true;
					break;
				case "fbxBulyongSayu":
                    this.fwkFind.FormText = "不用事由照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "不用事由コード";
                    this.fwkFind.ColInfos[1].HeaderText = "不用事由名";
                    this.fwkFind.SetBindVarValue("f_code_type", "BULYONG_SAYU");
					result = true;
					break;
				case "fbxSgJangbiCode":
                    this.fwkFind.FormText = "装備コード照会";
                    this.fwkFind.InputSQL = findQuery4;
					this.fwkFind.ColInfos[0].HeaderText = "装備コード";
					this.fwkFind.ColInfos[1].HeaderText = "装備コード名";
                    this.fwkFind.SetBindVarValue("f_code_type", "SG_JANGBI_CODE");
					result = true;
					break;
				case "fbxCompanyCode":
                    this.fwkFind.FormText = "製造会社照会";
                    this.fwkFind.InputSQL = findQuery5;
					this.fwkFind.ColInfos[0].HeaderText = "製造会社コード";
                    this.fwkFind.ColInfos[1].HeaderText = "製造会社名";
					result = true;
					break;
				case "fbxDanwi":
                    this.fwkFind.FormText = "薬剤点数単位照会";
                    this.fwkFind.InputSQL = findQuery6;
					this.fwkFind.ColInfos[0].HeaderText = "点数単位";
					this.fwkFind.ColInfos[1].HeaderText = "単位名";
					result = true;
					break;
				case "fbxSutakCode":
                    this.fwkFind.FormText = "外部依頼コード照会";
                    this.fwkFind.InputSQL = findQuery7;
					this.fwkFind.ColInfos[0].HeaderText = "外部依頼コード";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgBoheomEtc":
                    this.fwkFind.FormText = "保険その他照会";
                    this.fwkFind.InputSQL = findQuery8;
					this.fwkFind.ColInfos[0].HeaderText = "コード";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgBohoEtc":
                    this.fwkFind.FormText = "保護その他照会";
                    this.fwkFind.InputSQL = findQuery8;
					this.fwkFind.ColInfos[0].HeaderText = "コード";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgCarEtc":
                    this.fwkFind.FormText = "自賠その他照会";
                    this.fwkFind.InputSQL = findQuery8;
					this.fwkFind.ColInfos[0].HeaderText = "コード";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgSanEtc":
                    this.fwkFind.FormText = "労災その他照会";
                    this.fwkFind.InputSQL = findQuery8;
					this.fwkFind.ColInfos[0].HeaderText = "コード";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgIlbanEtc":
                    this.fwkFind.FormText = "一般その他照会";
                    this.fwkFind.InputSQL = findQuery8;
					this.fwkFind.ColInfos[0].HeaderText = "コード";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgEtcEtc":
                    this.fwkFind.FormText = "外国人その他照会";
                    this.fwkFind.InputSQL = findQuery8;
					this.fwkFind.ColInfos[0].HeaderText = "コード";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgBoheomDec":
                    this.fwkFind.FormText = "保険逓減区分";
                    this.fwkFind.InputSQL = findQuery9;
					this.fwkFind.ColInfos[0].HeaderText = "逓減区分";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgBohoDec":
                    this.fwkFind.FormText = "保護逓減区分";
                    this.fwkFind.InputSQL = findQuery9;
					this.fwkFind.ColInfos[0].HeaderText = "逓減区分";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgCarDec":
                    this.fwkFind.FormText = "自賠逓減区分";
                    this.fwkFind.InputSQL = findQuery9;
					this.fwkFind.ColInfos[0].HeaderText = "逓減区分";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgSanDec":
                    this.fwkFind.FormText = "労災逓減区分";
                    this.fwkFind.InputSQL = findQuery9;
					this.fwkFind.ColInfos[0].HeaderText = "逓減区分";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				case "fbxSgIlbanDec":
                    this.fwkFind.FormText = "一般逓減区分";
                    this.fwkFind.InputSQL = findQuery9;
					this.fwkFind.ColInfos[0].HeaderText = "逓減区分";
					this.fwkFind.ColInfos[1].HeaderText = "コード名";
					result = true;
					break;
				default:
                    //XMessageBox.Show("컨트롤을 찾을 수 없음","에러");
					result = false;
					break;
			}
			return result;

		}
		#endregion

		#region FindBox에 포커스가 갈때 Validation 체크
		private void fbxSgCode_Enter(object sender, System.EventArgs e)
		{
			XFindBox findBox = (XFindBox) sender;
		}
		#endregion


        #region Validation 서비스 호출전에 InValue를 셋팅
        private void layFind_QueryStarting(object sender, CancelEventArgs e)
        {

        }

		#endregion

        #region Validation 서비스 호출후의 값 셋팅
        private void layFind_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //foreach (IHIS.Framework.SingleLayoutItem item in this.layFind.LayoutItems)
            //{
            //    item.BindControl.Text = this.layFind.OutputText.Trim();
            //}
        }
		#endregion
		
		#region 텍스트 박스에 대한 Validating
		private void txtSgBoheomPointGubun_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//XTextBox txtChk = (XTextBox) sender;
			Control aCnt = (Control) sender;
			MakeDateCheck(aCnt.Name);
		}

		private void MakeDateCheck(string aColName)
		{
	
		}
		#endregion

		#region 유형별 반영 비율 가져오기
		private Double PointDanga(string aGubunSuga, string aBunCode, string aSgCode, string aOrderDate)
		{
            layPointAMTBanyoung.Reset();
            layBilLoad.SetBindVarValue("f_gubun_suga", aGubunSuga);
            layBilLoad.SetBindVarValue("f_bun_code", aBunCode);
            layBilLoad.SetBindVarValue("f_sg_code", aSgCode);
            layBilLoad.SetBindVarValue("f_order_date", aOrderDate);
            if (!layBilLoad.QueryLayout())
			{
				XMessageBox.Show(Service.ErrFullMsg.ToString());
				return 0;
			}

			double aPointDanga = Double.Parse(layBilLoad.GetItemValue("IoValue").ToString());
			return aPointDanga;

		}
		#endregion

		#region 유형별 반영 금액 재계산하여 setting(PR_BAS_POINT_AMT_BANYOUNG)
		private void PointAMTBanyoung(string aDataValue, string aColName, string aDate, string aBunCode, string aSgCode)
		{
		}
		#endregion

		#region 텍스트 Protect
		private void txtSgBoheomPointGubun_Validated(object sender, System.EventArgs e)
		{
			//XTextBox txtChk = (XTextBox) sender;
			Control aCnt = (Control) sender;
			MakeDateProtect(aCnt.Name);
		
		}

		private void MakeDateProtect(string aCtlName)
		{
		}
		#endregion

		#region 그리드 포커스 이동시
		private void grdList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{		
		}
		#endregion
	
		#region 버튼리스트 클릭
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			if (e.Func == FunctionType.Insert)
			{
				e.IsBaseCall = false;
//				if (Validateion_Check() != 0)
//				{
//					e.IsBaseCall = false;
//				}
			}
			else if (e.Func == FunctionType.Delete)
			{
				e.IsBaseCall = false;
//				if (XMessageBox.Show("点数コード[ " + txtSgCode.GetDataValue().ToString() + " ]를 정말로 삭제 하시겠습니까", "경고", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.No)
//				{
//					e.IsBaseCall = false;
//				}
			}
			else if (e.Func == FunctionType.Update)
			{
				e.IsBaseCall = false;
//				if (Validateion_Check() != 0)
//				{
//					e.IsBaseCall = false;
//				}
			}
			
		}
		#endregion

		#region Row Validation
		private int Validateion_Check()
		{
			if (grdList.CurrentRowNumber < 0) 
			{
				return 0;
			}
			return 0;

		}
		#endregion

		#region 해당 컨트롤이 활성활 될때 메세지 처리
		private void cbxSgJinchalYN_Enter(object sender, System.EventArgs e)
		{
			Control Ctl = (Control) sender;
			MakeEnterMsg(Ctl.Name);
		}
		#endregion

		#region 활성화될때 메세지 처리
		private void MakeEnterMsg(string aCtl)
		{

		}
		#endregion

		#region 버튼 리스트에서 클릭 후 이벤트
		private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			if (e.Func == FunctionType.Reset)
			{
				ClaerSetting();
				//fbxSgCode.Focus();
			}
		}
		#endregion

		#region 초기화 셋팅
		private void ClaerSetting()
		{
		}
		#endregion

        private string mFindName = "";
        private void fbx_DataValidating(object sender, DataValidatingEventArgs e)
        {
            Control aCtl = (Control)sender;
            //Message처리
            string mbxMsg = "", mbxCap = "";

            mFindName = aCtl.Name;

            this.layFind.LayoutItems.Clear();

            switch (aCtl.Name)
            {
                case "fbxBunCode":
                    if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
                    {
                        //dbxBunCodeName.SetDataValue("");
                        return;
                    }
                    this.layFind.QuerySQL = @"SELECT A.BUN_NAME
                                                   , A.BUN_NAME 
                                                FROM BAS0230 A 
                                               WHERE A.HOSP_CODE = :f_hosp_code
                                                 AND A.BUN_CODE  = :f_code
                                                 AND A.BUN_YMD = (SELECT MAX(B.BUN_YMD) 
                                                                    FROM BAS0230 B 
                                                                   WHERE B.HOSP_CODE = A.HOSP_CODE
                                                                     AND B.BUN_CODE  = A.BUN_CODE )";

                    this.layFind.LayoutItems.Add("dbxBunCodeName");
                    this.layFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layFind.SetBindVarValue("f_code", e.DataValue);
                    
                    if (layFind.QueryLayout())
                    {
                        //dbxBunCodeName.SetEditValue(layFind.GetItemValue("dbxBunCodeName").ToString());
                        //dbxBunCodeName.AcceptData();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "分類コードが正確ではないです. 確認してください."
                            : "분류기호가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;

                case "fbxSubBunCode":
                    if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
                    {
                        //dbxSubBunCodeName.SetDataValue("");
                        return;
                    }
                    this.layFind.QuerySQL = @"SELECT A.BUN_NAME
                                                   , A.BUN_NAME 
                                                FROM BAS0230 A 
                                               WHERE A.HOSP_CODE = :f_hosp_code
                                                 AND A.BUN_CODE  = :f_code
                                                 AND A.BUN_YMD = (SELECT MAX(B.BUN_YMD) 
                                                                    FROM BAS0230 B 
                                                                   WHERE B.HOSP_CODE = A.HOSP_CODE
                                                                     AND B.BUN_CODE  = A.BUN_CODE ) ";

                    this.layFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layFind.SetBindVarValue("f_code", e.DataValue);
                    this.layFind.LayoutItems.Add("dbxSubBunCodeName");
                    
                    if (layFind.QueryLayout())
                    {
                        //dbxSubBunCodeName.SetEditValue(layFind.GetItemValue("dbxSubBunCodeName").ToString());
                        //dbxSubBunCodeName.AcceptData();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "細部分類コードが正確ではないです. 確認してください."
                            : "분류기호가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }
                    break;

                // 非給与算定
                case "fbxBon100YN":

                    if (TypeCheck.IsNull(e.DataValue.ToString()) == true)
                    {
                        //dbxBon100YND.SetDataValue("");
                        return;
                    }

                    this.layFind.QuerySQL = @"SELECT CODE_NAME
                                                   , CODE_NAME 
                                                FROM BAS0102 
                                               WHERE HOSP_CODE = :f_hosp_code 
                                                 AND CODE_TYPE = 'BON_100_YN' 
                                                 AND CODE = :f_code";

                    this.layFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.layFind.SetBindVarValue("f_code", e.DataValue);
                    this.layFind.LayoutItems.Add("dbxBon100YND");
                   
                    if (layFind.QueryLayout())
                    {
                        //dbxBon100YND.SetEditValue(layFind.GetItemValue("dbxBon100YND").ToString());
                        //dbxBon100YND.AcceptData();
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "非給与算定コードが正確ではないです. 確認してください."
                            : "비급여산정이 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        e.Cancel = true;
                    }

                    break;

                default:
                    //XMessageBox.Show("벨리데이션 컨트롤을 찾을 수 없음", "에러");
                    //result = false;
                    break;
            }
        }

        private void grdList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fwkFind_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkFind.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void txtMent_DataValidating(object sender, DataValidatingEventArgs e)
        {

        }

        #region Connect to cloud\

        private IList<object[]> ExecuteQueryGrdListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            BAS0311U00GridListArgs vBas0311U00GridListArgs = new BAS0311U00GridListArgs();
            vBas0311U00GridListArgs.FHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            vBas0311U00GridListArgs.FSgCode = bc["f_sg_code"] != null ? bc["f_sg_code"].VarValue : "";
            BAS0311U00GridListResult result = CloudService.Instance.Submit<BAS0311U00GridListResult, BAS0311U00GridListArgs>(vBas0311U00GridListArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0311U00GridListItemInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.SgCode,
                        item.GroupGubun,
                        item.SgName,
                        item.SgNameKana,
                        item.SgYmd,
                        item.SugaChange,
                        item.SugaChangeNmD,
                        item.BulyongYmd,
                        item.BulyongSayu,
                        item.BulyongSayuNmD,
                        item.Danui,
                        item.DanuiName,
                        item.BunCode,
                        item.BunCodeName,
                        item.MarumeGubun,
                        item.SgUnion,
                        item.Remark,
                        item.MarumeName,
                        item.HubalDrgYn,
                        item.SunabQcodeOutName,
                        item.SunabQcodeInpName,
                        item.TaxYn
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion
    }
}

