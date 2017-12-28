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

namespace IHIS.INJS
{
	/// <summary>
	/// INJ0000Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INJ0000Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XTabControl tabOrder;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
		private IHIS.Framework.XPatientBox paBox;
		private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.MultiLayout layOrderList;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XComboBox cbxGubun;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private System.Windows.Forms.Panel panel1;
		private IHIS.Framework.XCalendar xCalendar1;
		private IHIS.Framework.XPanel xPanel4;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XLabel xLabel2;
		private System.Windows.Forms.Splitter splitter2;
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.MultiLayout layActing;
        private IHIS.Framework.MultiLayout layOrder;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.MultiLayout layActDate;
		private IHIS.Framework.XLabel xLabel4;
//        private XDataWindow dwOrder;
//        private XDataWindow dwNotList;
//        private XDataWindow dwOrderList;
//        private XDataWindow dwResult;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private MultiLayoutItem multiLayoutItem55;
        private MultiLayoutItem multiLayoutItem56;
        private MultiLayoutItem multiLayoutItem57;
        private MultiLayoutItem multiLayoutItem58;
        private MultiLayoutItem multiLayoutItem59;
        private MultiLayoutItem multiLayoutItem60;
        private MultiLayoutItem multiLayoutItem61;
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
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
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
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public INJ0000Q00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
			//paBox.SetPatientID("00351620");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ0000Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.cbxGubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.tabOrder = new IHIS.Framework.XTabControl();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.layOrderList = new IHIS.Framework.MultiLayout();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xCalendar1 = new IHIS.Framework.XCalendar();
            this.layActing = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.layOrder = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.layActDate = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem55 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem56 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem57 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem58 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem59 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem60 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem61 = new IHIS.Framework.MultiLayoutItem();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.tabOrder.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderList)).BeginInit();
            this.panel1.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xCalendar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layActing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layActDate)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Controls.Add(this.cbxGubun);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.tabOrder);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // cbxGubun
            // 
            this.cbxGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4});
            resources.ApplyResources(this.cbxGubun, "cbxGubun");
            this.cbxGubun.Name = "cbxGubun";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "2";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "3";
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // tabOrder
            // 
            this.tabOrder.ButtonActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabOrder.ButtonInactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.tabOrder, "tabOrder");
            this.tabOrder.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabOrder.IDEPixelArea = true;
            this.tabOrder.IDEPixelBorder = false;
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.SelectedIndex = 0;
            this.tabOrder.SelectedTab = this.tabPage2;
            this.tabOrder.ShowClose = false;
            this.tabOrder.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage2});
            this.tabOrder.TextColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabOrder.SelectionChanged += new System.EventHandler(this.tabOrder_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.ImageList = this.ImageList;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // layOrderList
            // 
            this.layOrderList.ExecuteQuery = null;
            this.layOrderList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem28});
            this.layOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderList.ParamList")));
            this.layOrderList.QuerySQL = resources.GetString("layOrderList.QuerySQL");
            this.layOrderList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layOrderList_QueryEnd);
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "jundal_table";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "jundal_part";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "bunho";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "order_date";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "in_out_gubun";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "gwa";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "doctor";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "doctor_name";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "reser_date";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "remark";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "jubsu_date";
            this.multiLayoutItem25.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "act_date";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "pkinj1001";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "hangmog_name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xPanel4);
            this.panel1.Controls.Add(this.xCalendar1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xPanel6);
            this.xPanel4.Controls.Add(this.splitter2);
            this.xPanel4.Controls.Add(this.xPanel5);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.xLabel3);
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Name = "xPanel6";
            // 
            // xLabel3
            // 
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.xLabel2);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // xCalendar1
            // 
            this.xCalendar1.EnableMultiSelection = false;
            this.xCalendar1.FullHolidaySelectable = true;
            this.xCalendar1.ImageList = this.ImageList;
//            resources.ApplyResources(this.xCalendar1, "xCalendar1");
            this.xCalendar1.MaxDate = new System.DateTime(2025, 8, 31, 0, 0, 0, 0);
            this.xCalendar1.MinDate = new System.DateTime(1996, 8, 31, 0, 0, 0, 0);
            this.xCalendar1.Name = "xCalendar1";
            this.xCalendar1.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.xCalendar1_DayClick);
            // 
            // layActing
            // 
            this.layActing.ExecuteQuery = null;
            this.layActing.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem48,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52});
            this.layActing.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layActing.ParamList")));
            this.layActing.QuerySQL = resources.GetString("layActing.QuerySQL");
            this.layActing.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layActing_QueryEnd);
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "gwa";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "doctor_name";
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "result_date";
            this.multiLayoutItem50.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "hangmog_code";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "hangmog_name";
            // 
            // layOrder
            // 
            this.layOrder.ExecuteQuery = null;
            this.layOrder.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem45,
            this.multiLayoutItem46});
            this.layOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrder.ParamList")));
            this.layOrder.QuerySQL = resources.GetString("layOrder.QuerySQL");
            this.layOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layOrder_QueryEnd);
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "jundal_table";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "jundal_part";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "bunho";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "order_date";
            this.multiLayoutItem37.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "in_out_gubun";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "gwa";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "doctor";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "doctor_name";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "result_date";
            this.multiLayoutItem42.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "jubsu_date";
            this.multiLayoutItem43.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "act_date";
            this.multiLayoutItem44.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "pkinj1001";
            this.multiLayoutItem45.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "hangmog_name";
            // 
            // layActDate
            // 
            this.layActDate.ExecuteQuery = null;
            this.layActDate.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem53,
            this.multiLayoutItem54,
            this.multiLayoutItem55,
            this.multiLayoutItem56,
            this.multiLayoutItem57,
            this.multiLayoutItem58,
            this.multiLayoutItem59,
            this.multiLayoutItem60,
            this.multiLayoutItem61});
            this.layActDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layActDate.ParamList")));
            this.layActDate.QuerySQL = resources.GetString("layActDate.QuerySQL");
            this.layActDate.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layActDate_QueryEnd);
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "jundal_table";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "jundal_part";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "bunho";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "order_date";
            this.multiLayoutItem32.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "in_out_gubun";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "gwa";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "doctor";
            // 
            // multiLayoutItem55
            // 
            this.multiLayoutItem55.DataName = "doctor_name";
            // 
            // multiLayoutItem56
            // 
            this.multiLayoutItem56.DataName = "result_date";
            this.multiLayoutItem56.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem57
            // 
            this.multiLayoutItem57.DataName = "remark";
            // 
            // multiLayoutItem58
            // 
            this.multiLayoutItem58.DataName = "jubsu_date";
            this.multiLayoutItem58.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem59
            // 
            this.multiLayoutItem59.DataName = "act_date";
            this.multiLayoutItem59.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem60
            // 
            this.multiLayoutItem60.DataName = "pkinj1001";
            this.multiLayoutItem60.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem61
            // 
            this.multiLayoutItem61.DataName = "hangmog_name";
            // 
            // xLabel4
            // 
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.ForeColor = IHIS.Framework.XColor.UpdatedForeColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // INJ0000Q00
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "INJ0000Q00";
            resources.ApplyResources(this, "$this");
            this.Activated += new System.EventHandler(this.INJ0000Q00_Activated);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.INJ0000Q00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.tabOrder.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xCalendar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layActing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layActDate)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.paBox.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(paBox.BunHo))
			{
				return new XPatientInfo(paBox.BunHo, paBox.SuName, "", "", this.ScreenName);
			}
			return null;
		}
		#endregion

		#region Open, Activated

        private void INJ0000Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            //if (e.OpenParam != null)
            //{
            //    if (e.OpenParam.Contains("bunho"))
            //        paBox.SetPatientID(e.OpenParam["bunho"].ToString());
            //}
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			cbxGubun.SelectedIndex = 3;
            if (this.OpenParam != null)
            {
                this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                cbxGubun.SelectedIndex = 3;
            }
            else
            {
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }
		}

		private void INJ0000Q00_Activated(object sender, System.EventArgs e)
		{
			// 2개 이상의 환자번호가 존재하면 문제있습니다
//			XPatientInfo paid = XScreen.GetPreviousScreenBunHo(true);
//			if (paid != null && !TypeCheck.IsNull(paid.BunHo))
//			{
//				paid = XScreen.GetOtherScreenBunHo(this, true);
//				try
//				{
//					paBox.SetPatientID(paid.BunHo);
//				}
//				catch{}
//			}
		}

		#endregion		

		#region btn List
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					OrderListQuery();
					break;
				default:
					break;
			}
		}
		#endregion

		#region Order Query
		private void OrderListQuery()
		{
            //dwOrder.Reset();
            //dwNotList.Reset();
            //dwOrderList.Reset();
			
			string bunho;
			bunho = paBox.BunHo;
            if (bunho == "") return;

            layOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layOrderList.SetBindVarValue("f_bunho", bunho);
            layOrderList.SetBindVarValue("f_message_gubun", tabOrder.SelectedIndex.ToString());
            layOrderList.SetBindVarValue("f_gubun", cbxGubun.GetDataValue());
            layOrderList.QueryLayout(true);

            layActDate.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layActDate.SetBindVarValue("f_bunho", bunho);
            layActDate.SetBindVarValue("f_message_gubun", tabOrder.SelectedIndex.ToString());
            layActDate.SetBindVarValue("f_gubun", "1");
            layActDate.QueryLayout(true);

            layOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layOrder.SetBindVarValue("f_bunho", bunho);
            layOrder.SetBindVarValue("f_message_gubun", tabOrder.SelectedIndex.ToString());
            layOrder.SetBindVarValue("f_gubun", "2"); // 미실시 오다
            layOrder.QueryLayout(true);
		}
		#endregion

		#region 결과조회
		private void ResultQuery()
		{
            //int row = dwOrderList.ObjectUnderMouse.RowNumber;
            //if (row < 1) return;

            //this.dwResult.DataWindowObject = "d_null";

            //row = row - 1;
            //Row = row;

            //if (layOrderList.GetItemString(row,"jundal_table") == "INJ")	
            //{
            //}

            //if (layOrderList.GetItemString(row,"jundal_table") == "PHY")
            //{
            //}
			
            //this.dwResult.AcceptText();
            //this.dwResult.Refresh();
		}
		#endregion

        #region DW Rowfocus
        private void dwOrder_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            //			dwOrder.Refresh();
        }
        private void dwOrder_Click(object sender, System.EventArgs e)
        {
            //			dwOrder.Refresh();
        }
        private void dwNotList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            //		dwNotList.Refresh();
        }
        private void dwNotList_Click(object sender, System.EventArgs e)
        {
            //		dwNotList.Refresh();
        }
        private void dwOrderList_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            if (e.RowNumber == 0) return;
            int row = 0;
            //		dwResult.Reset();
            //row = dwResult.InsertRow(0);

            //if (this.layOrderList.GetItemString(e.RowNumber - 1, "remark").Trim() != "")
            //{
            //    dwResult.SetItemString(row, "remark", dwOrderList.GetItemString(e.RowNumber, "remark"));
            //    dwResult.Refresh();
            //}
        }
        #endregion

		#region Controls Query
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			OrderListQuery();
		}

		private void tabOrder_SelectionChanged(object sender, System.EventArgs e)
		{
			 OrderListQuery();
		}
		#endregion
      
		#region Calendar
		private void xCalendar1_DayClick(object sender, IHIS.Framework.XCalendarDayClickEventArgs e)
        {
            layActing.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			layActing.SetBindVarValue("f_bunho"		, paBox.BunHo );
            layActing.SetBindVarValue("f_message_gubun", tabOrder.SelectedIndex.ToString());
            layActing.SetBindVarValue("f_act_date", e.DateItem.Date.ToShortDateString());
            layActing.QueryLayout(true);
		}
		#endregion

        #region QueryStarting_End Event

        private void layOrderList_QueryStarting(object sender, CancelEventArgs e)
        {
            layOrderList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOrderList.SetBindVarValue("f_gubun", this.cbxGubun.GetDataValue());
        }

        private void layOrderList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //dwOrderList.Reset();
            //dwResult.Reset();

            //dwOrderList.FillData(layOrderList.LayoutTable);
            //dwOrderList.Refresh();
        }

        private void layActDate_QueryEnd(object sender, QueryEndEventArgs e)
        {
            xCalendar1.ResetCalendarDates();

            // 선택일자 Reset
            //Add간 Invalidate 잠시보류
            XCalendarDate date = null;
            xCalendar1.Redraw = false;
            if (e.IsSuccess)
            {
                if (layActDate.LayoutTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in layActDate.LayoutTable.Rows)
                    {
                        if (!TypeCheck.IsNull(dr["act_date"]))
                        {
                            date = new XCalendarDate(DateTime.Parse(dr["act_date"].ToString()));
                            date.ImageIndex = 0;
                            date.Tag = dr;
                            date.ImageAlign = ContentAlignment.MiddleCenter;
                            xCalendar1.Dates.Add(date);
                        }
                    }
                }
                string ds = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
                xCalendar1.SetActiveMonth(int.Parse(ds.Substring(0, 4)), int.Parse(ds.Substring(5, 2)));
                DateTime dt = DateTime.Parse(ds);
                xCalendar1.SelectDate(dt);
            }

            //Redraw
            xCalendar1.Redraw = true;
        }

        private void layActing_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //dwOrder.Reset();
            //dwOrder.FillData(layActing.LayoutTable);
            //dwOrder.Refresh();
        }

        private void layOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //dwNotList.Reset();
            //dwNotList.FillData(layOrder.LayoutTable);
            //dwNotList.Refresh();
        }
        #endregion

        #region MouseDown
        private void dwNotList_MouseDown(object sender, MouseEventArgs e)
        {
  //          this.dwNotList.Refresh();
        }

        private void dwOrder_MouseDown(object sender, MouseEventArgs e)
        {
   //         this.dwOrder.Refresh();
        }

        private void dwOrderList_MouseDown(object sender, MouseEventArgs e)
        {
  //          this.dwOrderList.Refresh();
        }
        #endregion

    }
}

