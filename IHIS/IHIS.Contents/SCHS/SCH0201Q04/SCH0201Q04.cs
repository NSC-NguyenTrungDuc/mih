#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector.Caching;
#endregion

namespace IHIS.SCHS
{
	/// <summary>
	/// SCH0201Q04에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class SCH0201Q04 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string mMonth = IHIS.Framework.EnvironInfo.GetSysDate().Year.ToString()+IHIS.Framework.EnvironInfo.GetSysDate().Month.ToString("00");
		private string mSelectDay = "";
        private const string CACHE_COMBOGUMSA_KEYS = "SCHS.SCH0201Q04.CmbGumsa";
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XCalendar calReser;
		private IHIS.Framework.XDataWindow dwSch0201;
		private IHIS.Framework.MultiLayout layGetMonthReserInfo;
        private IHIS.Framework.MultiLayout layReser_Info;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGrid grdPrartList;
		private IHIS.Framework.MultiLayout layReserTimeList;
        private IHIS.Framework.XPanel xPanel1;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
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
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private SingleLayout layPreReser_Info1;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private MultiLayout layPreReser_Info2;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
        private MultiLayoutItem multiLayoutItem62;
        private MultiLayoutItem multiLayoutItem63;
        private MultiLayoutItem multiLayoutItem64;
        private MultiLayoutItem multiLayoutItem65;
        private MultiLayoutItem multiLayoutItem66;
        private MultiLayoutItem multiLayoutItem67;
        private MultiLayoutItem multiLayoutItem68;
        private MultiLayoutItem multiLayoutItem69;
        private MultiLayoutItem multiLayoutItem70;
        private MultiLayoutItem multiLayoutItem71;
        private MultiLayoutItem multiLayoutItem72;
        private XLabel xLabel12;
        private XDictComboBox cboGumsa;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem58;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 추가사항
		public SCH0201Q04()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
            //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 135);
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            Size = new System.Drawing.Size(rc.Width - 60, rc.Height - 145);
            this.cboGumsa.ExecuteQuery = GetCboGumsa;
            this.grdPrartList.ExecuteQuery = GetGrdPrartList;
            this.layGetMonthReserInfo.ParamList = new List<string>(new string[] { "jundal_table", "jundal_part", "month" });
            this.layGetMonthReserInfo.ExecuteQuery = GetMonthReserInfo;
            this.layReserTimeList.ParamList = new List<string>(new string[] { "jundal_table", "jundal_part" });
            this.layReserTimeList.ExecuteQuery = GetReserTimeList;

            if (!NetInfo.Language.Equals(LangMode.Jr))
            {
                this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
                //dwSch0201.Modify("t_8.Font.Face='{0}'", Service.COMMON_FONT.Name);                
               
            }
		}
		#endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0201Q04));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.cboGumsa = new IHIS.Framework.XDictComboBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdPrartList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.calReser = new IHIS.Framework.XCalendar();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.dwSch0201 = new IHIS.Framework.XDataWindow();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.layGetMonthReserInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layReser_Info = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.layReserTimeList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.layPreReser_Info1 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.layPreReser_Info2 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem62 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem63 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem64 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem65 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem66 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem67 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem68 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem69 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem70 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem71 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem72 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrartList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calReser)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layGetMonthReserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReser_Info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserTimeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreReser_Info2)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.xLabel12);
            this.pnlTop.Controls.Add(this.cboGumsa);
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.Font = null;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            // 
            // cboGumsa
            // 
            this.cboGumsa.AccessibleDescription = null;
            this.cboGumsa.AccessibleName = null;
            resources.ApplyResources(this.cboGumsa, "cboGumsa");
            this.cboGumsa.BackgroundImage = null;
            this.cboGumsa.ExecuteQuery = null;
            this.cboGumsa.Font = null;
            this.cboGumsa.Name = "cboGumsa";
            this.cboGumsa.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboGumsa.ParamList")));
            this.cboGumsa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGumsa.SelectedValueChanged += new System.EventHandler(this.cboGumsa_SelectedValueChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdPrartList
            // 
            resources.ApplyResources(this.grdPrartList, "grdPrartList");
            this.grdPrartList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3});
            this.grdPrartList.ColPerLine = 1;
            this.grdPrartList.Cols = 2;
            this.grdPrartList.ExecuteQuery = null;
            this.grdPrartList.FixedCols = 1;
            this.grdPrartList.FixedRows = 1;
            this.grdPrartList.HeaderHeights.Add(21);
            this.grdPrartList.Name = "grdPrartList";
            this.grdPrartList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPrartList.ParamList")));
            this.grdPrartList.QuerySQL = resources.GetString("grdPrartList.QuerySQL");
            this.grdPrartList.RowHeaderVisible = true;
            this.grdPrartList.Rows = 2;
            this.grdPrartList.ToolTipActive = true;
            this.grdPrartList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPrartList_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "jundal_table";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "jundal_part";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "jundal_part_name";
            this.xEditGridCell3.CellWidth = 310;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // calReser
            // 
            this.calReser.AccessibleDescription = null;
            this.calReser.AccessibleName = null;
            resources.ApplyResources(this.calReser, "calReser");
            this.calReser.EnableMultiSelection = false;
            this.calReser.FullHolidaySelectable = true;
            this.calReser.ImageList = this.ImageList;
            this.calReser.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.calReser.MinDate = new System.DateTime(1996, 8, 8, 0, 0, 0, 0);
            this.calReser.Name = "calReser";
            this.calReser.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calReser_DaySelected);
            this.calReser.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.calReser_DayClick);
            this.calReser.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.calReser_MonthChanged);
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Controls.Add(this.dwSch0201);
            this.pnlFill.Controls.Add(this.xPanel1);
            this.pnlFill.DrawBorder = true;
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // dwSch0201
            // 
            resources.ApplyResources(this.dwSch0201, "dwSch0201");
            this.dwSch0201.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwSch0201.DataWindowObject = "d_reser_list_01";
            this.dwSch0201.LibraryList = "SCHS\\schs.sch0201q04.pbd";
            this.dwSch0201.Name = "dwSch0201";
            this.dwSch0201.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwSch0201.RowFocusChanged += new Sybase.DataWindow.RowFocusChangedEventHandler(this.dwSch0201_RowFocusChanged);
            this.dwSch0201.Click += new System.EventHandler(this.dwSch0201_Click);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.calReser);
            this.xPanel1.Controls.Add(this.grdPrartList);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // layGetMonthReserInfo
            // 
            this.layGetMonthReserInfo.ExecuteQuery = null;
            this.layGetMonthReserInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layGetMonthReserInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGetMonthReserInfo.ParamList")));
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "holi_day";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "reser_cnt";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "inwon_cnt";
            // 
            // layReser_Info
            // 
            this.layReser_Info.ExecuteQuery = null;
            this.layReser_Info.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
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
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31});
            this.layReser_Info.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReser_Info.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pksch0201";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "in_out_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "fkocs";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "bunho";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "gwa";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "gumsaja";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "hangmog_code";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "jundal_table";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "jundal_part";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "reser_date";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "reser_time";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "input_date";
            this.multiLayoutItem15.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "input_id";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "suname";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "reser_yn";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "cancel_yn";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "acting_date";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "hope_date";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "comments";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "hangmog_name";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "jundal_part_name";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "gwa_name";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "ho_dong";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "sex";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "age";
            this.multiLayoutItem28.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "birth";
            this.multiLayoutItem29.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "input_gwa";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "bunho_cnt";
            // 
            // layReserTimeList
            // 
            this.layReserTimeList.ExecuteQuery = null;
            this.layReserTimeList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem58});
            this.layReserTimeList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layReserTimeList.ParamList")));
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "hangmog_code";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "hangmog_name";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "reser_date";
            this.multiLayoutItem34.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "reser_time";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "suname";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "input_id";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "in_out_gubun";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "input_gwa";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "sex";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "age";
            this.multiLayoutItem41.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "acting_date";
            this.multiLayoutItem42.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "comments";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "bunho";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "upd_name";
            // 
            // layPreReser_Info1
            // 
            this.layPreReser_Info1.ExecuteQuery = null;
            this.layPreReser_Info1.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4});
            this.layPreReser_Info1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPreReser_Info1.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "avg_time";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "inwon";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "start_date";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "start_time";
            // 
            // layPreReser_Info2
            // 
            this.layPreReser_Info2.ExecuteQuery = null;
            this.layPreReser_Info2.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61,
            this.multiLayoutItem62,
            this.multiLayoutItem63,
            this.multiLayoutItem64,
            this.multiLayoutItem65,
            this.multiLayoutItem66,
            this.multiLayoutItem67,
            this.multiLayoutItem68,
            this.multiLayoutItem69,
            this.multiLayoutItem70,
            this.multiLayoutItem71,
            this.multiLayoutItem72});
            this.layPreReser_Info2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPreReser_Info2.ParamList")));
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "pksch0201";
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "reser_date";
            this.multiLayoutItem60.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "reser_time";
            // 
            // multiLayoutItem62
            // 
            this.multiLayoutItem62.DataName = "bunho";
            // 
            // multiLayoutItem63
            // 
            this.multiLayoutItem63.DataName = "hangmog_code";
            // 
            // multiLayoutItem64
            // 
            this.multiLayoutItem64.DataName = "hangmog_name";
            // 
            // multiLayoutItem65
            // 
            this.multiLayoutItem65.DataName = "suname";
            // 
            // multiLayoutItem66
            // 
            this.multiLayoutItem66.DataName = "input_id";
            // 
            // multiLayoutItem67
            // 
            this.multiLayoutItem67.DataName = "gwa";
            // 
            // multiLayoutItem68
            // 
            this.multiLayoutItem68.DataName = "t_inwon";
            // 
            // multiLayoutItem69
            // 
            this.multiLayoutItem69.DataName = "acting_date";
            this.multiLayoutItem69.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem70
            // 
            this.multiLayoutItem70.DataName = "sex";
            // 
            // multiLayoutItem71
            // 
            this.multiLayoutItem71.DataName = "age";
            // 
            // multiLayoutItem72
            // 
            this.multiLayoutItem72.DataName = "gwa_name";
            // 
            // SCH0201Q04
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = null;
            this.Name = "SCH0201Q04";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.SCH0201Q04_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrartList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calReser)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layGetMonthReserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReser_Info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layReserTimeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPreReser_Info2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen Load
		private void SCH0201Q04_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            this.cboGumsa.SetDictDDLB();
            this.cboGumsa.SelectedIndex = 0;
			this.calReser.SetActiveMonth(IHIS.Framework.EnvironInfo.GetSysDate().Year,IHIS.Framework.EnvironInfo.GetSysDate().Month);

			PartListQuery();
			
			GetSchedule();
            ApplyMultiLanguages();
		}
		#endregion

		#region 월 스케쥴 로드
		private void GetSchedule()
		{
			string reser_text = "";
			int    reser_cnt = 0, inwon_cnt = 0;

			//조회월이 없으면 리턴
			if (this.mMonth == "") return;
			
			//달력리셋
			//달력초기화
			this.calReser.ResetText();
			
			this.calReser.Dates.Clear();

			this.calReser.UnSelectAll();

			//데이터윈도우 초기화
			this.dwSch0201.Reset();

			int row =0;

			//월별 예약현황 조회
			row = grdPrartList.CurrentRowNumber;

            //this.layGetMonthReserInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGetMonthReserInfo.SetBindVarValue("jundal_table", grdPrartList.GetItemString(row, "jundal_table"));
            this.layGetMonthReserInfo.SetBindVarValue("jundal_part", grdPrartList.GetItemString(row, "jundal_part"));
            this.layGetMonthReserInfo.SetBindVarValue("month", this.mMonth);
		
			if(this.layGetMonthReserInfo.QueryLayout(true))
			{
				this.calReser.Dates.Clear();

				this.calReser.Redraw = false;
				foreach(DataRow dr in this.layGetMonthReserInfo.LayoutTable.Rows)
				{
					//예약일자 생성
					IHIS.Framework.XCalendarDate date = new XCalendarDate(DateTime.Parse(dr["holi_day"].ToString()));
					//예약일자 추가
					this.calReser.Dates.Add(date);

					//예약 정보 셋팅
					
					reser_text = "";
					reser_cnt = 0;
					inwon_cnt = 0;
					date.ImageIndex = -1;

					reser_cnt = int.Parse(dr["reser_cnt"].ToString());
					inwon_cnt = int.Parse(dr["inwon_cnt"].ToString());
					
					if ((reser_cnt != 0) || (inwon_cnt != 0))
						reser_text = reser_cnt.ToString() + "/" + inwon_cnt.ToString();

					if (reser_cnt > 0)
						date.ImageIndex = 1;

					/////////////////////////////
					//date.ContentAlign = System.Drawing.ContentAlignment.BottomCenter;
					//date.ContentFont = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
					date.ContentTextColor = new IHIS.Framework.XColor(System.Drawing.Color.Blue);
					date.ContentText = reser_text;
					/////////////////////////////

					if ((reser_cnt >= inwon_cnt) && (reser_cnt != 0))
						date.ImageIndex = 0;


				}
				this.calReser.Redraw = true;
			}

            this.calReser.SelectDate(EnvironInfo.GetSysDate().Date);


			#region 오늘일자 setting 후 조회 주석처리... 
            //이 로직은 머지? 그냥 오늘 날짜만 셋팅해주면 안되나??

            //calReser.SelectDate(EnvironInfo.GetSysDate());
			
            //this.mSelectDay = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            ///* 데이터 윈도우를 조회한다.(일별예약현황 조회) */
            //if(this.mSelectDay.ToString() != "")
            //{
            //    row = grdPrartList.CurrentRowNumber;

            //    //this.dsvGetReser_Info.SetInValue("jundal_table", grdPrartList.GetItemString(row, "jundal_table"));
            //    //this.dsvGetReser_Info.SetInValue("jundal_part", grdPrartList.GetItemString(row, "jundal_part"));
            //    //this.dsvGetReser_Info.SetInValue("mSelectday", this.mSelectDay.ToString());

            //    this.dwSch0201.Reset();
            //    if(LoadReserInfo())
            //    {
            //        this.dwSch0201.FillData(this.layReser_Info.LayoutTable);
            //        return;
            //    }
            //    else
            //    {
            //        XMessageBox.Show(Service.ErrFullMsg);
            //        return;
            //    }
            //}
			#endregion

        }

        #region LoadReserInfo 주석 안쓰임. 나중에 삭제처리
        private bool LoadReserInfo()
        {
//            string o_avg_time = "";
//            int o_inwon = 0;
//            string o_start_date = "";
//            string o_start_time = "";
//            string o_end_date = "";
//            string o_end_time = "";

//            double t_inwon = 0;
//            double t_round = 0;
//            int o_res_inwon = 0;

//            int row = grdPrartList.CurrentRowNumber;
//            string jundal_table = grdPrartList.GetItemString(row, "jundal_table");
//            string jundal_part = grdPrartList.GetItemString(row, "jundal_part");

//            /* 예외사항 정보조회 */
//            this.layPreReser_Info1.QuerySQL = @"SELECT DECODE(:f_time_gubun, 'AM', AM_AVG_TIME, PM_AVG_TIME)          AVG_TIME
//                                                     ,DECODE(:f_time_gubun, 'AM', NVL(AM_INWON,0), NVL(PM_INWON,0))  INWON
//                                                     ,DECODE(:f_time_gubun, 'AM', TO_DATE(:f_reser_date || ' 0800','yyyy/mm/dd hh24mi') ,
//                                                      TO_DATE(:f_reser_date || ' 1300','yyyy/mm/dd hh24mi'))        START_DATE
//                                                     ,TO_CHAR(DECODE(:f_time_gubun, 'AM', TO_DATE(:f_reser_date || ' ' || NVL(AM_START_TIME,'0800'),'yyyy/mm/dd hh24mi') ,
//                                                      TO_DATE(:f_reser_date || ' ' || NVL(PM_START_TIME,'1300'),'yyyy/mm/dd hh24mi')), 'hh24mi')  START_TIME
//                                                 FROM SCH0199
//                                                WHERE HOSP_CODE    = :f_hosp_code
//                                                  AND JUNDAL_TABLE = :f_jundal_table
//                                                  AND JUNDAL_PART  = :f_jundal_part
//                                                  AND RESER_DATE   = TO_DATE(:f_reser_date,'YYYY/MM/DD')";

//            this.layPreReser_Info1.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//            this.layPreReser_Info1.SetBindVarValue("f_jundal_table", jundal_table);
//            this.layPreReser_Info1.SetBindVarValue("f_jundal_part", jundal_part);
//            this.layPreReser_Info1.SetBindVarValue("f_reser_date", this.mSelectDay);

//            this.layPreReser_Info1.QueryLayout();

//            if (TypeCheck.IsNull(this.layPreReser_Info1.GetItemValue("inwon")))
//            {
//                /* 검사 시작시간 및 검사 인원정보 조회*/
//                this.layPreReser_Info1.QuerySQL = @"SELECT DECODE(:f_time_gubun, 'AM', AM_AVG_TIME, PM_AVG_TIME)          AVG_TIME
//                                                          ,DECODE(:f_time_gubun, 'AM', NVL(AM_INWON,0), NVL(PM_INWON,0))  INWON
//                                                          ,DECODE(:f_time_gubun, 'AM', TO_DATE(:f_reser_date || ' 0800','yyyy/mm/dd hh24mi') ,
//                                                           TO_DATE(:f_reser_date || ' 1300','yyyy/mm/dd hh24mi'))       START_DATE
//                                                          ,TO_CHAR(DECODE(:f_time_gubun, 'AM', TO_DATE(:f_reser_date || ' ' || NVL(AM_START_TIME,'0800'),'yyyy/mm/dd hh24mi') ,
//                                                           TO_DATE(:f_reser_date || ' ' || NVL(PM_START_TIME,'1300'),'yyyy/mm/dd hh24mi')), 'hh24mi') START_TIME
//                                                      FROM SCH0101
//                                                     WHERE HOSP_CODE    = :f_hosp_code
//                                                       AND JUNDAL_TABLE = :f_jundal_table
//                                                       AND JUNDAL_PART  = :f_jundal_part
//                                                       AND YOIL_GUBUN   = TO_CHAR(TO_DATE(:f_reser_date,'YYYY/MM/DD'),'D')";

//                this.layPreReser_Info1.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                this.layPreReser_Info1.SetBindVarValue("f_jundal_table", jundal_table);
//                this.layPreReser_Info1.SetBindVarValue("f_jundal_part", jundal_part);
//                this.layPreReser_Info1.SetBindVarValue("f_reser_date", this.mSelectDay);

//                this.layPreReser_Info1.QueryLayout();
//            }

//            o_avg_time = this.layPreReser_Info1.GetItemValue("avg_time").ToString();

//            if (!TypeCheck.IsNull(this.layPreReser_Info1.GetItemValue("inwon")))
//                o_inwon = Convert.ToInt32(this.layPreReser_Info1.GetItemValue("inwon").ToString());

//            o_start_date = this.layPreReser_Info1.GetItemValue("start_date").ToString();
//            o_start_time = this.layPreReser_Info1.GetItemValue("start_time").ToString();

//            /* 예약 시간관리를 하지 않는 경우는 모두 조회되계 */
//            this.layReser_Info.Reset();

//            if (o_inwon == 0 || o_inwon <= t_inwon)
//            {
//                this.layPreReser_Info2.QuerySQL = @"SELECT MIN(A.PKSCH0201),
//                                                           A.RESER_DATE,
//                                                           A.RESER_TIME,
//                                                           A.BUNHO,
//                                                           MIN(A.HANGMOG_CODE) HANGMOG_CODE,
//                                                           MIN(B.HANGMOG_NAME) HANGMOG_NAME,
//                                                           NVL(C.SUNAME,A.SUNAME)||' ('||FN_OUT_LOAD_SUNAME2(A.BUNHO)||')',
//                                                           MIN(A.INPUT_ID),
//                                                           A.GWA,
//                                                           DECODE(DECODE(A.JUNDAL_PART,'MRI',DECODE(A.GWA,'HC', 0.5, 1), 1),
//                                                                  1, ROUND(:t_inwon + DECODE(A.JUNDAL_PART,'MRI',DECODE(A.GWA,'HC', 0.5, 1), 1)),
//                                                                  :t_inwon + DECODE(A.JUNDAL_PART,'MRI',DECODE(A.GWA,'HC', 0.5, 1), 1)),
//                                                          A.ACTING_DATE                                     ACTING_DATE,
//                                                          C.SEX                                             SEX,
//                                                          FN_BAS_LOAD_AGE(A.INPUT_DATE, C.BIRTH, NULL)      AGE,
//                                                          FN_BAS_LOAD_GWA_NAME(A.GWA     , A.INPUT_DATE)    INPUT_GWA
//                                                      FROM OUT0101 C,
//                                                           OCS0103 B,
//                                                           SCH0201 A
//                                                     WHERE A.HOSP_CODE    = :f_hosp_code
//                                                       AND B.HOSP_CODE    = A.HOSP_CODE
//                                                       AND C.HOSP_CODE(+) = A.HOSP_CODE
//                                                       AND A.RESER_DATE   = :f_reser_date
//                                                       AND A.JUNDAL_TABLE = :f_jundal_table
//                                                       AND A.JUNDAL_PART  LIKE DECODE(:f_jundal_part, 'MRI', 'MRI%', 'MRI_1', 'MRI%', :f_jundal_part)
//                                                       AND NVL(A.RESER_TIME,'0800')   BETWEEN DECODE(:f_time_gubun, 'AM', '0800', '1300') AND DECODE(:f_time_gubun, 'AM', '1259', '1900')
//                                                       AND NVL(A.CANCEL_YN,'N')    = 'N'
//                                                       AND A.HANGMOG_CODE NOT IN ( SELECT HANGMOG_CODE
//                                                                                     FROM SCH0101
//                                                                                    WHERE HOSP_CODE    = :f_jundal_table
//                                                                                      AND JUNDAL_TABLE = :f_jundal_table
//                                                                                      AND JUNDAL_PART  = :f_jundal_part
//                                                                                      AND HANGMOG_CODE <> '%')
//                                                       AND B.HANGMOG_CODE = A.HANGMOG_CODE
//                                                       AND C.BUNHO    (+) = A.BUNHO
//                                                     GROUP BY A.RESER_DATE, A.RESER_TIME, A.BUNHO, A.SUNAME, A.GWA, A.JUNDAL_PART, A.ACTING_DATE, A.INPUT_DATE, C.SUNAME, C.BIRTH, C.SEX
//                                                     ORDER BY A.RESER_TIME, A.GWA";

//                this.layPreReser_Info2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//                this.layPreReser_Info2.SetBindVarValue("t_inwon", t_inwon.ToString());
//                this.layPreReser_Info2.SetBindVarValue("f_reser_date", this.mSelectDay);
//                this.layPreReser_Info2.SetBindVarValue("f_jundal_table", jundal_table);
//                this.layPreReser_Info2.SetBindVarValue("f_jundal_part", jundal_part);
//                this.layPreReser_Info2.SetBindVarValue("f_time_gubun", "");

//                if (!this.layPreReser_Info2.QueryLayout(true))
//                {
//                    return false;
//                }

//                for (int i = 0; i > this.layPreReser_Info2.RowCount; i++)
//                {
//                    this.layReser_Info.InsertRow(i);
//                    this.layReser_Info.SetItemValue(i, "pksch0201", this.layPreReser_Info2.GetItemString(i, "pksch0201"));
//                    this.layReser_Info.SetItemValue(i, "reser_date", this.layPreReser_Info2.GetItemString(i, "reser_date"));
//                    this.layReser_Info.SetItemValue(i, "reser_time", this.layPreReser_Info2.GetItemString(i, "reser_time"));
//                    this.layReser_Info.SetItemValue(i, "bunho", this.layPreReser_Info2.GetItemString(i, "bunho"));
//                    this.layReser_Info.SetItemValue(i, "hangmog_code", this.layPreReser_Info2.GetItemString(i, "hangmog_code"));
//                    this.layReser_Info.SetItemValue(i, "hangmog_name", this.layPreReser_Info2.GetItemString(i, "hangmog_name"));
//                    this.layReser_Info.SetItemValue(i, "suname", this.layPreReser_Info2.GetItemString(i, "suname"));
//                    this.layReser_Info.SetItemValue(i, "input_id", this.layPreReser_Info2.GetItemString(i, "input_id"));
//                    this.layReser_Info.SetItemValue(i, "gwa", this.layPreReser_Info2.GetItemString(i, "gwa"));
//                    //this.layReser_Info.SetItemValue(i, "t_inwon", this.layPreReser_Info2.GetItemString(i, "t_inwon"));
//                    this.layReser_Info.SetItemValue(i, "acting_date", this.layPreReser_Info2.GetItemString(i, "acting_date"));
//                    this.layReser_Info.SetItemValue(i, "sex", this.layPreReser_Info2.GetItemString(i, "sex"));
//                    this.layReser_Info.SetItemValue(i, "age", this.layPreReser_Info2.GetItemString(i, "age"));
//                    this.layReser_Info.SetItemValue(i, "pksch0201", this.layPreReser_Info2.GetItemString(i, "gwa_name"));
//                }

//                o_start_time = o_end_time;
//                return true;
//            }

//            string cmdText = "";
//            BindVarCollection bc = new BindVarCollection();

//            /* 예약 시간이 존재하는 경우 */
//            for (; ; )
//            {
//                /* 정원 체크 */
//                if (o_inwon == 0 || o_inwon <= t_inwon)
//                {
//                    /* To Time Load */
//                    cmdText = @"SELECT TO_DATE(:f_reser_date || :o_start_time ,'yyyy/mm/ddhh24mi') + (TO_NUMBER(:o_avg_time) /24/60)  end_date
//                                      ,DECODE(:f_time_gubun, 'AM', '1259','2359')   end_time
//                                  FROM DUAL";
//                    bc.Clear();
//                    bc.Add("f_reser_date", this.mSelectDay);
//                    bc.Add("o_start_time", o_start_time);
//                    bc.Add("o_avg_time", o_avg_time);
//                    bc.Add("f_time_gubun", "");

//                    DataTable dt = Service.ExecuteDataTable(cmdText, bc);
//                    o_end_date = dt.Rows[0]["end_date"].ToString();
//                    o_end_time = dt.Rows[0]["end_time"].ToString();

//                    /* mri_1 인경우 end time 증가.*/
                    

//                    return true;
//                }
//            }
            return true;
        }
            #endregion

		#endregion

		#region 월변경을 했을 때
		private void calReser_MonthChanged(object sender, IHIS.Framework.XCalendarMonthChangedEventArgs e)
		{
			this.mMonth = e.Year.ToString()+e.Month.ToString("00");

			GetSchedule();
		}
		#endregion

		#region 예약일자를 선택을 했을 때
		private void calReser_DayClick(object sender, IHIS.Framework.XCalendarDayClickEventArgs e)
        {
        //    this.mSelectDay = e.DateItem.Date.ToString("yyyy/MM/dd");

        //    /* 데이터 윈도우를 조회한다.(일별예약현황 조회) */
        //    if (this.mSelectDay.ToString() != "")
        //    {
        //        int row = grdPrartList.CurrentRowNumber;
        //        this.dwSch0201.Reset();

        //        //this.layReserTimeList.SetBindVarValue("f_jundal_table", grdPrartList.GetItemString(row, "jundal_table"));
        //        //this.layReserTimeList.SetBindVarValue("f_jundal_part", grdPrartList.GetItemString(row, "jundal_part"));
        //        //this.layReserTimeList.SetBindVarValue("f_reser_date", this.mSelectDay.ToString());

        //        string jundal_table = grdPrartList.GetItemString(row, "jundal_table");
        //        string jundal_part  = grdPrartList.GetItemString(row, "jundal_part");

        //        if (!Service.ExecuteProcedure("PR_SCH_TIME_LIST", Service.ClientIP, jundal_table, jundal_part,"%",this.mSelectDay))
        //        {
        //            XMessageBox.Show(Service.ErrFullMsg);
        //            return;
        //        }

        //        this.layReserTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        //        this.layReserTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

        //        if (this.layReserTimeList.QueryLayout(true))
        //        {
        //            this.dwSch0201.FillData(this.layReserTimeList.LayoutTable);
        //        }
        //        else
        //        {
        //            XMessageBox.Show(Service.ErrFullMsg);
        //            return;
        //        }
        //    }
		}
		#endregion

		#region 버튼리스트에서 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					GetSchedule();
					break;
				default:
					break;
			}
		}
		#endregion

		#region 검사파트를 변경을 했을 때
		private void cboGumsaPart_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GetSchedule();
		}
		#endregion

		#region 파트조회
		private void PartListQuery()
		{
            //this.grdPrartList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdPrartList.SetBindVarValue("f_jundal_table", this.cboGumsa.GetDataValue());
			this.grdPrartList.QueryLayout(false);
		}
		#endregion

		
		private void grdPrartList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			GetSchedule();
		}

		private void dwSch0201_Click(object sender, System.EventArgs e)
		{
			dwSch0201.Refresh();
		}

		private void dwSch0201_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
		{
			dwSch0201.Refresh();
//			if (e.RowNumber > 0)
//			{
//				if (!dwSch0201.IsItemNull(e.RowNumber, "comments"))
//					XMessageBox.Show(dwSch0201.GetItemString(e.RowNumber, "comments"), "依頼書指示内容");
//			}
		}

        private void calReser_DaySelected(object sender, XCalendarDaySelectedEventArgs e)
        {
			this.mSelectDay = e.DateItems[0].Date.ToString("yyyy/MM/dd");

			/* 데이터 윈도우를 조회한다.(일별예약현황 조회) */
			if (this.mSelectDay.ToString() != "")
			{
				int row = grdPrartList.CurrentRowNumber;
				this.dwSch0201.Reset();
			    
                // Updated code
                this.layReserTimeList.SetBindVarValue("jundal_table", grdPrartList.GetItemString(row, "jundal_table"));
                this.layReserTimeList.SetBindVarValue("jundal_part", grdPrartList.GetItemString(row, "jundal_part"));
                this.layReserTimeList.QueryLayout(true);

                if (null != this.layReserTimeList.LayoutTable)
                {
                    this.dwSch0201.FillData(this.layReserTimeList.LayoutTable);
                }

                #region comments
                //string jundal_table = grdPrartList.GetItemString(row, "jundal_table");
                //string jundal_part  = grdPrartList.GetItemString(row, "jundal_part");

                //if (!Service.ExecuteProcedure("PR_SCH_TIME_LIST", Service.ClientIP, jundal_table, jundal_part,"%",this.mSelectDay))
                //{
                //    XMessageBox.Show(Service.ErrFullMsg);
                //    return;
                //}

                //this.layReserTimeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                //this.layReserTimeList.SetBindVarValue("q_ip_addr", Service.ClientIP);

                //if (this.layReserTimeList.QueryLayout(true))
                //{
                //    this.dwSch0201.FillData(this.layReserTimeList.LayoutTable);
                //}
                //else
                //{
                //    XMessageBox.Show(Service.ErrFullMsg);
                //    return;
                //}
                #endregion
            }

        }

        private void cboGumsa_SelectedValueChanged(object sender, EventArgs e)
        {
            PartListQuery();
        }

        #region Updated code

        #region GetCboGumsa
        /// <summary>
        /// GetCboGumsa
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetCboGumsa(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SchsSCH0201Q04GetCboListResult res = CacheService.Instance.Get<SchsSCH0201Q04GetCboListArgs, SchsSCH0201Q04GetCboListResult>(new SchsSCH0201Q04GetCboListArgs());
            //SchsSCH0201Q04GetCboListArgs args = new SchsSCH0201Q04GetCboListArgs();
            //SchsSCH0201Q04GetCboListResult res = CloudService.Instance.Submit<SchsSCH0201Q04GetCboListResult, SchsSCH0201Q04GetCboListArgs>(args);

            if (null != res)
            {
                foreach (ComboListItemInfo item in res.CboItem)
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

        #region GetGrdPrartList
        /// <summary>
        /// GetGrdPrartList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPrartList(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SchsSCH0201Q04PrartListArgs args = new SchsSCH0201Q04PrartListArgs();
            args.JundalTable = this.cboGumsa.GetDataValue();
            SchsSCH0201Q04PrartListResult res = CloudService.Instance.Submit<SchsSCH0201Q04PrartListResult,
                SchsSCH0201Q04PrartListArgs>(args);

            if (null != res)
            {
                foreach (SchsSCH0201Q04PrartListItemInfo item in res.PrartListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.JundalTable,
                        item.JundalPart,
                        item.JundalPartName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetMonthReserInfo
        /// <summary>
        /// GetMonthReserInfo
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetMonthReserInfo(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SchsSCH0201Q04GetMonthReserListInfoArgs args = new SchsSCH0201Q04GetMonthReserListInfoArgs();
            args.Month = list["month"].VarValue;
            args.JundalTable = list["jundal_table"].VarValue;
            args.JundalPart = list["jundal_part"].VarValue;
            SchsSCH0201Q04GetMonthReserListInfoResult res = CloudService.Instance.Submit<SchsSCH0201Q04GetMonthReserListInfoResult,
                SchsSCH0201Q04GetMonthReserListInfoArgs>(args);

            if (null != res)
            {
                foreach (SchsSCH0201Q04GetMonthReserListInfo item in res.MonthReserListItem)
                {
                    lObj.Add(new object[]
                    {
                        item.HoliDay,
                        item.ReserCnt,
                        item.InwonCnt,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetReserTimeList
        /// <summary>
        /// GetReserTimeList
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GetReserTimeList(BindVarCollection list)
        {
            IList<object[]> lObj = new List<object[]>();

            SchsSCH0201Q04GetCalReserArgs args = new SchsSCH0201Q04GetCalReserArgs();
            args.Gumsaja = "%";
            args.IpAddr = Service.ClientIP;
            args.JundalPart = list["jundal_part"].VarValue;
            args.JundalTable = list["jundal_table"].VarValue;
            args.ReserDate = this.mSelectDay;
            SchsSCH0201Q04GetCalReserResult res = CloudService.Instance.Submit<SchsSCH0201Q04GetCalReserResult,
                SchsSCH0201Q04GetCalReserArgs>(args);

            if (null != res)
            {
                if (!res.Result)
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    lObj = null;
                }
                else
                {
                    foreach (SchsSCH0201Q04ReserTimeListInfo item in res.ReserTimeListItem)
                    {
                        lObj.Add(new object[]
                        {
                            item.HangmogCode,
                            item.HangmogName,
                            item.ReserDate,
                            item.ReserTime,
                            item.Suname,
                            item.InputId,
                            item.InOutGubun,
                            item.InputGwa,
                            item.Sex,
                            item.Age,
                            item.ActingDate,
                            item.Comments,
                            item.Bunho,
                            item.Doctor,
                            item.UpdName,
                        });
                    }
                }
            }

            return lObj;
        }
        #endregion

        #endregion

        #region Apply multi languages
        private void ApplyMultiLanguages()
        {
            try
            {
                //dwSch0201
                dwSch0201.Refresh();
                dwSch0201.Modify(string.Format("t_2.text = '{0}'", Resources.DW_TXT_1));
                dwSch0201.Modify(string.Format("t_6.text = '{0}'", Resources.DW_TXT_2));
                dwSch0201.Modify(string.Format("t_1.text = '{0}'", Resources.DW_TXT_3));
                dwSch0201.Modify(string.Format("t_8.text = '{0}'", Resources.DW_TXT_4));
                dwSch0201.Modify(string.Format("t_11.text = '{0}'", Resources.DW_TXT_5));
                dwSch0201.Modify(string.Format("t_13.text = '{0}'", Resources.DW_TXT_6));
                dwSch0201.Modify(string.Format("t_3.text = '{0}'", Resources.DW_TXT_7));
                dwSch0201.Modify(string.Format("panm_t.text = '{0}'", Resources.DW_TXT_8));
                dwSch0201.Modify(string.Format("t_5.text = '{0}'", Resources.DW_TXT_9));

                if (!NetInfo.Language.Equals(LangMode.Jr))
                {
                    dwSch0201.Modify(string.Format("t_2.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("t_1.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("t_8.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("t_11.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("t_13.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("t_3.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("t_6.Font.Face = '{0}'", "Arial"));

                    dwSch0201.Modify(string.Format("panm_t.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("t_5.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("reser_time.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("suname.Font.Face = '{0}'", "Arial"));

                    dwSch0201.Modify(string.Format("age.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("input_gwa.Font.Face = '{0}'", "Arial"));
                    dwSch0201.Modify(string.Format("acting_date.Font.Face = '{0}'", "Arial"));
                    
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.StackTrace);
            }
        }
        #endregion

    }
}

