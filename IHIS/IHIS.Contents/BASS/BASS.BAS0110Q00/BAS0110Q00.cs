#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.BASS.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Bass;
using IHIS.CloudConnector.Contracts.Models.Bass;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Bass;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
#endregion

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0110Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class BAS0110Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XTabControl tabJohapGubun;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XComboBox cboSearchItem;
		private IHIS.Framework.XTextBox txtSearchWord;
		private IHIS.Framework.XEditGrid grdBAS0110;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.MultiLayout layJohapGubun;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.MultiLayout layReturn;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
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
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0110Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		    grdBAS0110.ParamList = CreateGrdBAS0110ParamList();
		    grdBAS0110.ExecuteQuery = LoadGrdBAS0110;
		    layJohapGubun.ExecuteQuery = LoadLayJohapGubun;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0110Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtSearchWord = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cboSearchItem = new IHIS.Framework.XComboBox();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.tabJohapGubun = new IHIS.Framework.XTabControl();
            this.grdBAS0110 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.layJohapGubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layReturn = new IHIS.Framework.MultiLayout();
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
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0110)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJohapGubun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.txtSearchWord);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.cboSearchItem);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
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
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // cboSearchItem
            // 
            this.cboSearchItem.AccessibleDescription = null;
            this.cboSearchItem.AccessibleName = null;
            resources.ApplyResources(this.cboSearchItem, "cboSearchItem");
            this.cboSearchItem.BackgroundImage = null;
            this.cboSearchItem.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem2,
            this.xComboItem3});
            this.cboSearchItem.Name = "cboSearchItem";
            this.cboSearchItem.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboSearchItem_DataValidating);
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = global::IHIS.BASS.Properties.Resources.xComboItem2;
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = global::IHIS.BASS.Properties.Resources.xComboItem3;
            this.xComboItem3.ValueItem = "2";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // tabJohapGubun
            // 
            this.tabJohapGubun.AccessibleDescription = null;
            this.tabJohapGubun.AccessibleName = null;
            resources.ApplyResources(this.tabJohapGubun, "tabJohapGubun");
            this.tabJohapGubun.BackgroundImage = null;
            this.tabJohapGubun.Font = null;
            this.tabJohapGubun.IDEPixelArea = true;
            this.tabJohapGubun.IDEPixelBorder = false;
            this.tabJohapGubun.Name = "tabJohapGubun";
            this.tabJohapGubun.SelectionChanged += new System.EventHandler(this.tabJohapGubun_SelectionChanged);
            // 
            // grdBAS0110
            // 
            resources.ApplyResources(this.grdBAS0110, "grdBAS0110");
            this.grdBAS0110.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21});
            this.grdBAS0110.ColPerLine = 3;
            this.grdBAS0110.Cols = 3;
            this.grdBAS0110.ExecuteQuery = null;
            this.grdBAS0110.FixedRows = 1;
            this.grdBAS0110.HeaderHeights.Add(25);
            this.grdBAS0110.Name = "grdBAS0110";
            this.grdBAS0110.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdBAS0110.ParamList")));
            this.grdBAS0110.QuerySQL = resources.GetString("grdBAS0110.QuerySQL");
            this.grdBAS0110.ReadOnly = true;
            this.grdBAS0110.Rows = 2;
            this.grdBAS0110.ToolTipActive = true;
            this.grdBAS0110.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdBAS0110_MouseDown);
            this.grdBAS0110.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0110_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "johap";
            this.xEditGridCell1.CellWidth = 98;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "start_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "johap_name";
            this.xEditGridCell3.CellWidth = 341;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "johap_gubun";
            this.xEditGridCell4.CellWidth = 97;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "zip_code1";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "zip_code2";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "address";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "tel";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "law_no";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "dodobuhyeun_no";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "boheomja_no";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "cd";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "giho";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "remark";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "check_digit_yn";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "johap_gubun_name";
            this.xEditGridCell21.CellWidth = 90;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.SuppressRepeating = true;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, Resources.btnProcess, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // layJohapGubun
            // 
            this.layJohapGubun.ExecuteQuery = null;
            this.layJohapGubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layJohapGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layJohapGubun.ParamList")));
            this.layJohapGubun.QuerySQL = resources.GetString("layJohapGubun.QuerySQL");
            this.layJohapGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layJohapGubun_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "johap_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "johap_gubun_name";
            // 
            // layReturn
            // 
            this.layReturn.ExecuteQuery = null;
            this.layReturn.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.layReturn.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReturn.ParamList")));
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "johap";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "start_date";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "johap_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "johap_gubun";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "zip_code1";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "zip_code2";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "address";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "tel";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "johap_daepyo";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "new_johap";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "law_no";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "dodobuhyeun_no";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "boheomja_no";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "cd";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "giho";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "johap_rate";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "johap_rate1";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "direct_receipt_yn";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "remark";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "check_digit_yn";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "johap_gubun_name";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            // 
            // BAS0110Q00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdBAS0110);
            this.Controls.Add(this.tabJohapGubun);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0110Q00";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BAS0110Q00_Closing);
            this.Load += new System.EventHandler(this.BAS0110Q00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0110)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJohapGubun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReturn)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region XComboBox

		/// <summary>
		/// 콤보박스 선택값이 바뀐경우 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cboSearchItem_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			switch (e.DataValue)
			{
				case "1" :   /* 보험자번호 */

					this.txtSearchWord.ImeMode = ImeMode.Alpha;
					this.txtSearchWord.CharacterCasing = CharacterCasing.Upper;

					break;
				case "2" :   /* 보험자번호 명칭 */

					this.txtSearchWord.ImeMode = ImeMode.Hiragana;

					break;
			}
		}

		#endregion

		#region XTextBox

		/// <summary>
		/// 텍스트 박스에서 엔터키 입력시
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSearchWord_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if (e.DataValue != "")
			{
				this.Load_BAS0110();
			}
		}

		#endregion

		#region XButtonList

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Reset :

					// 리셋후 초기화
					this.Initialize();

					break;
			}
		}

		#endregion

		#region Function

		/// <summary>
		/// 화면 오픈시 초시화 셋팅
		/// </summary>
		private void Initialize()
		{
			// 콤보 아이템 전체로 선택
			this.cboSearchItem.SetEditValue("2");
			this.cboSearchItem.AcceptData();

			// 레이아웃 클리어
			this.layReturn.Reset();

			// 화면오픈인 경우
			if (this.OpenParam != null)
			{
				if (this.OpenParam.Contains("johap_ymd"))
				{
					//this.grdBAS0110.SetBindVarValue("johap_ymd", this.OpenParam["johap_ymd"].ToString());
				}

				if (this.OpenParam.Contains("johap"))
				{
					this.cboSearchItem.SetEditValue("1");
					this.cboSearchItem.AcceptData();

					this.txtSearchWord.SetEditValue(this.OpenParam["johap"].ToString());
					this.txtSearchWord.AcceptData();

                    this.grdBAS0110.QueryLayout(false);
				}
            }
		}

		/// <summary>
		/// 텝 페이지 생성
		/// </summary>
		private void MakeTabPage ()
		{
			IHIS.X.Magic.Controls.TabPage tpgItem;

			this.layJohapGubun.QueryLayout(true);

			try
			{
				this.tabJohapGubun.TabPages.Clear();
			}
			catch
			{
			}

			foreach (DataRow dr in this.layJohapGubun.LayoutTable.Rows)
            {
				tpgItem = new IHIS.X.Magic.Controls.TabPage(dr["johap_gubun_name"].ToString(),null,ImageList,1);
				tpgItem.Tag = dr["johap_gubun"].ToString();     
				tpgItem.ImageIndex = 1;

				tabJohapGubun.TabPages.Add(tpgItem);
			}

			if (tabJohapGubun.TabPages.Count > 0)
			{
				this.tabJohapGubun.SelectedIndex = 0;
			}
		}

		#endregion

		#region Form Load

		private void BAS0110Q00_Load(object sender, System.EventArgs e)
		{
			// 폼 초기화

            //this.Initialize();
			this.cboSearchItem.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.cboSearchItem_DataValidating);

			this.MakeTabPage();

			this.cboSearchItem.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.cboSearchItem_DataValidating);
            
            this.Initialize();//여기서 조회되지만 결과안나옴 시간이 너무오래걸리므로 그냥 이게 나을 듯
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{
			this.txtSearchWord.Focus();
		}

		#endregion

		#region XEditGrid

		/// <summary>
		/// 마우스 다운 이벤트
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void grdBAS0110_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			int rowNum = -1;

			if (e.Button == MouseButtons.Left &&
				e.Clicks == 2 )
			{
				rowNum = this.grdBAS0110.GetHitRowNumber(e.Y);

				if (rowNum >= 0)
				{
					layReturn.Reset();
					layReturn.LayoutTable.ImportRow(this.grdBAS0110.LayoutTable.Rows[rowNum]);

					this.Close();
				}
			}
		}

		#endregion

		#region XTabPage

		private void tabJohapGubun_SelectionChanged(object sender, System.EventArgs e)
		{
			#region 이미지 변신

			foreach (IHIS.X.Magic.Controls.TabPage tpgItem in this.tabJohapGubun.TabPages)
			{
				if (tpgItem == this.tabJohapGubun.SelectedTab)
				{
					tpgItem.ImageIndex = 0;
				}
				else
				{
					tpgItem.ImageIndex = 1;
				}
			}

			#endregion

			// 데이터 재조회
            if (this.txtSearchWord.GetDataValue() != "") //데이타량이 많아서 시간이 오래 걸리므로
            {
				this.Load_BAS0110();
            }
		}

		#endregion

		#region DataLoading 

		private void Load_BAS0110 ()
		{

			if (this.tabJohapGubun.SelectedTab == null)
			{
				return;
			}

            //this.grdBAS0110.SetBindVarValue("f_johap_gubun", this.tabJohapGubun.SelectedTab.Tag.ToString());
					
			this.grdBAS0110.QueryLayout(false);
		}

		#endregion

		#region Screen Closing 

		private void BAS0110Q00_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.layReturn.RowCount > 0)
			{
				CommonItemCollection returnParam = new CommonItemCollection();

				returnParam.Add("BAS0110", this.layReturn);

				((XScreen)this.Opener).Command("BAS0110Q00", returnParam);
			}
		}

		#endregion

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Process:

					if (this.grdBAS0110.RowCount > 0)
					{
						layReturn.Reset();
						layReturn.LayoutTable.ImportRow(this.grdBAS0110.LayoutTable.Rows[this.grdBAS0110.CurrentRowNumber]);

						this.Close();
					}

                    break;

                case FunctionType.Query:

//                    this.grdBAS0110.QueryLayout(false);

                    break;

				case FunctionType.Cancel:

					this.layReturn.Reset();

					this.Close();

					break;
			}
		}

        private void grdBAS0110_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0110.SetBindVarValue("f_hosp_code",   EnvironInfo.HospCode);
            this.grdBAS0110.SetBindVarValue("f_search_gubun", this.cboSearchItem.GetDataValue());
            this.grdBAS0110.SetBindVarValue("f_search_word", this.txtSearchWord.GetDataValue());
            this.grdBAS0110.SetBindVarValue("f_johap_gubun", this.tabJohapGubun.SelectedTab.Tag.ToString());
        }


        private void layJohapGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            layJohapGubun.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        #region cloud services

	    private List<string> CreateGrdBAS0110ParamList()
	    {
	        List<string> paramList = new List<string>();
            paramList.Add("f_johap_gubun");
            paramList.Add("f_search_gubun");
            paramList.Add("f_search_word");
	        return paramList;
	    }

        private List<object[]> LoadGrdBAS0110(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0110Q00GrdBAS0110Args args = new BAS0110Q00GrdBAS0110Args();
            args.JohapGubun = bc["f_johap_gubun"] != null ? bc["f_johap_gubun"].VarValue : "";
            args.SearchGubun = bc["f_search_gubun"] != null ? bc["f_search_gubun"].VarValue : "";
            args.SearchWord = bc["f_search_word"] != null ? bc["f_search_word"].VarValue : "";
            BAS0110Q00GrdBAS0110Result result = CloudService.Instance.Submit<BAS0110Q00GrdBAS0110Result, BAS0110Q00GrdBAS0110Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BAS0110Q00GrdBAS0110ItemInfo item in result.GrdBas0110ItemInfo)
                {
                    object[] objects = 
				{ 
					item.Johap, 
					item.StartDate, 
					item.JohapName, 
					item.JohapGubun, 
					item.ZipCode1, 
					item.ZipCode2, 
					item.Address, 
					item.Tel, 
					item.LawNo, 
					item.DodobuhyeunNo, 
					item.BoheomjaNo, 
					item.Cd, 
					item.Giho, 
					item.Remark, 
					item.CheckDigitYn, 
					item.JohapGubunName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadLayJohapGubun(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BAS0110Q00LayJohapGubunArgs args = new BAS0110Q00LayJohapGubunArgs();
            ComboResult result = CloudService.Instance.Submit<ComboResult, BAS0110Q00LayJohapGubunArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
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

        #endregion
    }
}

