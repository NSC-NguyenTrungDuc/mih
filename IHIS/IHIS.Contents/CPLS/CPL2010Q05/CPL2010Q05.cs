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
using Dundas.Charting.WinControl;
#endregion

namespace IHIS.CPLS
{
	/// <summary>
	/// ADMCHART1에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL2010Q05 : IHIS.Framework.XScreen
	{
		#region Fields
		private Font   selectedFont = new Font("MS UI Gothic",10.0f, FontStyle.Bold);  //선택된 Radio Font
		private Font   unSelectedFont = new Font("MS UI Gothic",10.0f); //선택해제된 Radio Font
		private Color  selectedBackColor = Color.RoyalBlue;
		private Color  unSelectedBackColor = Color.LightSkyBlue;
		private Color  selectedForeColor   = Color.White;
		private Color  unSelectedForeColor = Color.Black;
		private Hashtable gwaCodeList = new Hashtable();  //과룸명을 Key로 과코드를 Value로 가지는 Hashtable
		private Hashtable doctorChartSeriesList = new Hashtable();  // Key는 구분자(D.약만, J.진료만, T.전체만) Value는 Series 객체를 관리
		private Hashtable lineChartSeriesList = new Hashtable();  //라인 차트 시리즈 리스트 (Key는 T.당월, P.전월, N.전전월)로 시리즈 관리
		private Hashtable monthRadioList = new Hashtable();  //월 선택 Radio Button List 관리
		private DataTable lineTable = new DataTable("Line"); //LineChart의 DataSource (일별 환자수를 조회하여 lineTable 구성함) 
		private DateTime selectedDate = DateTime.Today;
		//조회 Input용
		[DataBindable]
		public string SelectedDate
		{
			get { return selectedDate.ToString("yyyy/MM/dd").Replace("-","/");}
		}
		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private IHIS.Framework.XButton btnClose;
		private IHIS.Framework.XButton btnQuery;
		private System.ComponentModel.IContainer components = null;
		private Dundas.Charting.WinControl.Chart chartGwa;
		private System.Windows.Forms.RadioButton rbOnlyJinryo;
		private System.Windows.Forms.RadioButton rbOnlyDrug;
		private System.Windows.Forms.RadioButton rbOnlyTotal;  //Key를 과코드로, Value에 DataTable 관리
		private System.Windows.Forms.CheckBox cbxDoctor3D;
		private System.Windows.Forms.CheckBox cbxGwa3D;
		private Dundas.Charting.WinControl.Chart chartDoctor;
		private System.Windows.Forms.CheckBox cbxGwa100;
		private System.Windows.Forms.CheckBox cbxDoctor100;
		private IHIS.Framework.XCTrackBar tbGwaX;
		private IHIS.Framework.XCTrackBar tbGwaY;
		private IHIS.Framework.XButton btnGwaBase;
		private IHIS.Framework.XButton btnDoctorBase;
		private IHIS.Framework.XCTrackBar tbDoctorY;
		private IHIS.Framework.XCTrackBar tbDoctorX;
		private System.Windows.Forms.Panel pnlCenter;
		private System.Windows.Forms.Panel pnlBottom;
		private Dundas.Charting.WinControl.Chart chartLine;
		private System.Windows.Forms.RadioButton rbJan;
		private System.Windows.Forms.RadioButton rbFeb;
		private System.Windows.Forms.RadioButton rbApr;
		private System.Windows.Forms.RadioButton rbMar;
		private System.Windows.Forms.RadioButton rbAug;
		private System.Windows.Forms.RadioButton rbJul;
		private System.Windows.Forms.RadioButton rbJun;
		private System.Windows.Forms.RadioButton rbMay;
		private System.Windows.Forms.RadioButton rbDec;
		private System.Windows.Forms.RadioButton rbNov;
		private System.Windows.Forms.RadioButton rbOct;
		private System.Windows.Forms.RadioButton rbSep;
		private IHIS.Framework.XCTrackBar tbLineY;
		private IHIS.Framework.XCTrackBar tbLineX;
		private IHIS.Framework.XButton btnLineBase;
		private System.Windows.Forms.CheckBox cbxLine3D;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.RadioButton rbDoctorTotal;
		private System.Windows.Forms.RadioButton rbOnlyDangMonth;
		private System.Windows.Forms.RadioButton rbOnlyJunMonth;
		private System.Windows.Forms.RadioButton rbOnlyJunJunMonth;
		private System.Windows.Forms.RadioButton tbLineTotal;
        private IHIS.Framework.XButton btnUpDown;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XComboBox cboYear;
		private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.MultiLayout layGwaData; //각월별 일자 + 환자수 Table을 관리하는 List
        private IHIS.Framework.MultiLayout layDoctorData;
        private IHIS.Framework.MultiLayout layMonthData;
		private IHIS.Framework.XCalendar calendar;
		private IHIS.Framework.XLabel lbCalendar;
		private IHIS.Framework.XDisplayBox dbxToday;
        private IHIS.Framework.MultiLayout layJundalPart;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XComboItem xComboItem5;
		private IHIS.Framework.XComboItem xComboItem6;
		private IHIS.Framework.XComboItem xComboItem7;
		private IHIS.Framework.XComboItem xComboItem8;
		private IHIS.Framework.XComboItem xComboItem9;
		private IHIS.Framework.XComboItem xComboItem10;
		private IHIS.Framework.XComboItem xComboItem11;
		private IHIS.Framework.XComboItem xComboItem12;
		private IHIS.Framework.XComboItem xComboItem13;
		private IHIS.Framework.XComboItem xComboItem14;
		private IHIS.Framework.XComboItem xComboItem15;
		private IHIS.Framework.XComboItem xComboItem16;
		private IHIS.Framework.XComboItem xComboItem17;
		private IHIS.Framework.XComboItem xComboItem18;
		private IHIS.Framework.XComboItem xComboItem19;
		private IHIS.Framework.XComboItem xComboItem20;
		private IHIS.Framework.XComboItem xComboItem21;
		private IHIS.Framework.XComboItem xComboItem22;
		private IHIS.Framework.XComboItem xComboItem23;
        private IHIS.Framework.XComboItem xComboItem24;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private SingleLayout layTotalCnt;
        private SingleLayoutItem singleLayoutItem1;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem18;
		private IHIS.Framework.XComboItem xComboItem25;

		public CPL2010Q05()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
	

			//Series 객체를 리스트에 할당
			doctorChartSeriesList.Add("T", this.chartDoctor.Series["全体"]);  //T.Total Cnt
			doctorChartSeriesList.Add("J", this.chartDoctor.Series["入院"]);  //J.Jinryo Cnt
			doctorChartSeriesList.Add("D", this.chartDoctor.Series["外来"]);  //D.Drug Cnt

			//Line 차트의 시리즈 리스트 관리(Radio 변경시 시리즈 속성 변경을 위해 관리)
			lineChartSeriesList.Add("T", this.chartLine.Series["当月"]);
			lineChartSeriesList.Add("P", this.chartLine.Series["前月"]);
			lineChartSeriesList.Add("N", this.chartLine.Series["前前月"]);

			//MonthRadio List 구성 (Key는 월, Value는 RadioButton)
			monthRadioList.Add("1", this.rbJan);
			monthRadioList.Add("2", this.rbFeb);
			monthRadioList.Add("3", this.rbMar);
			monthRadioList.Add("4", this.rbApr);
			monthRadioList.Add("5", this.rbMay);
			monthRadioList.Add("6", this.rbJun);
			monthRadioList.Add("7", this.rbJul);
			monthRadioList.Add("8", this.rbAug);
			monthRadioList.Add("9", this.rbSep);
			monthRadioList.Add("10", this.rbOct);
			monthRadioList.Add("11", this.rbNov);
			monthRadioList.Add("12", this.rbDec);

			//chartLine의 DataSource를 LineTable로 구성(일자,당월수,전월수,전전월수)
			lineTable.Columns.Add("Day", typeof(int));
			lineTable.Columns.Add("DangMonth", typeof(int));
			lineTable.Columns.Add("JunMonth", typeof(int));
			lineTable.Columns.Add("JunJunMonth", typeof(int));

			//Track Bar의 기본값 설정 (Pie는 30,30, 의사 Chart는 30, 0)
			this.tbGwaX.Value = 30;
			this.tbGwaY.Value = 30;
			this.tbDoctorX.Value = 30;
			this.tbDoctorY.Value = 0;
			this.tbLineX.Value = 30;
			this.tbLineY.Value = 30;
		}

		#region Dispose
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010Q05));
            Dundas.Charting.WinControl.ChartArea chartArea1 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend1 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series1 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title1 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea2 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend2 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series2 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series3 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series4 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title2 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.ChartArea chartArea3 = new Dundas.Charting.WinControl.ChartArea();
            Dundas.Charting.WinControl.Legend legend3 = new Dundas.Charting.WinControl.Legend();
            Dundas.Charting.WinControl.Series series5 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series6 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Series series7 = new Dundas.Charting.WinControl.Series();
            Dundas.Charting.WinControl.Title title3 = new Dundas.Charting.WinControl.Title();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.dbxToday = new IHIS.Framework.XDisplayBox();
            this.lbCalendar = new IHIS.Framework.XLabel();
            this.cboYear = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem12 = new IHIS.Framework.XComboItem();
            this.xComboItem13 = new IHIS.Framework.XComboItem();
            this.xComboItem14 = new IHIS.Framework.XComboItem();
            this.xComboItem15 = new IHIS.Framework.XComboItem();
            this.xComboItem16 = new IHIS.Framework.XComboItem();
            this.xComboItem17 = new IHIS.Framework.XComboItem();
            this.xComboItem18 = new IHIS.Framework.XComboItem();
            this.xComboItem19 = new IHIS.Framework.XComboItem();
            this.xComboItem20 = new IHIS.Framework.XComboItem();
            this.xComboItem21 = new IHIS.Framework.XComboItem();
            this.xComboItem22 = new IHIS.Framework.XComboItem();
            this.xComboItem23 = new IHIS.Framework.XComboItem();
            this.xComboItem24 = new IHIS.Framework.XComboItem();
            this.xComboItem25 = new IHIS.Framework.XComboItem();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDec = new System.Windows.Forms.RadioButton();
            this.rbNov = new System.Windows.Forms.RadioButton();
            this.rbOct = new System.Windows.Forms.RadioButton();
            this.rbSep = new System.Windows.Forms.RadioButton();
            this.rbAug = new System.Windows.Forms.RadioButton();
            this.rbJul = new System.Windows.Forms.RadioButton();
            this.rbJun = new System.Windows.Forms.RadioButton();
            this.rbMay = new System.Windows.Forms.RadioButton();
            this.rbApr = new System.Windows.Forms.RadioButton();
            this.rbMar = new System.Windows.Forms.RadioButton();
            this.rbFeb = new System.Windows.Forms.RadioButton();
            this.rbJan = new System.Windows.Forms.RadioButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnQuery = new IHIS.Framework.XButton();
            this.rbOnlyTotal = new System.Windows.Forms.RadioButton();
            this.rbOnlyDrug = new System.Windows.Forms.RadioButton();
            this.rbOnlyJinryo = new System.Windows.Forms.RadioButton();
            this.rbDoctorTotal = new System.Windows.Forms.RadioButton();
            this.btnGwaBase = new IHIS.Framework.XButton();
            this.tbGwaY = new IHIS.Framework.XCTrackBar();
            this.tbGwaX = new IHIS.Framework.XCTrackBar();
            this.cbxGwa100 = new System.Windows.Forms.CheckBox();
            this.cbxGwa3D = new System.Windows.Forms.CheckBox();
            this.chartGwa = new Dundas.Charting.WinControl.Chart();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.calendar = new IHIS.Framework.XCalendar();
            this.tbDoctorY = new IHIS.Framework.XCTrackBar();
            this.tbDoctorX = new IHIS.Framework.XCTrackBar();
            this.btnDoctorBase = new IHIS.Framework.XButton();
            this.cbxDoctor100 = new System.Windows.Forms.CheckBox();
            this.cbxDoctor3D = new System.Windows.Forms.CheckBox();
            this.chartDoctor = new Dundas.Charting.WinControl.Chart();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnUpDown = new IHIS.Framework.XButton();
            this.rbOnlyDangMonth = new System.Windows.Forms.RadioButton();
            this.rbOnlyJunMonth = new System.Windows.Forms.RadioButton();
            this.rbOnlyJunJunMonth = new System.Windows.Forms.RadioButton();
            this.tbLineTotal = new System.Windows.Forms.RadioButton();
            this.tbLineY = new IHIS.Framework.XCTrackBar();
            this.tbLineX = new IHIS.Framework.XCTrackBar();
            this.btnLineBase = new IHIS.Framework.XButton();
            this.cbxLine3D = new System.Windows.Forms.CheckBox();
            this.chartLine = new Dundas.Charting.WinControl.Chart();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.layGwaData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.layDoctorData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.layMonthData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.layJundalPart = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layTotalCnt = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGwa)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoctor)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGwaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDoctorData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMonthData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJundalPart)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "로테이트.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.dbxToday);
            this.pnlTop.Controls.Add(this.lbCalendar);
            this.pnlTop.Controls.Add(this.cboYear);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.rbDec);
            this.pnlTop.Controls.Add(this.rbNov);
            this.pnlTop.Controls.Add(this.rbOct);
            this.pnlTop.Controls.Add(this.rbSep);
            this.pnlTop.Controls.Add(this.rbAug);
            this.pnlTop.Controls.Add(this.rbJul);
            this.pnlTop.Controls.Add(this.rbJun);
            this.pnlTop.Controls.Add(this.rbMay);
            this.pnlTop.Controls.Add(this.rbApr);
            this.pnlTop.Controls.Add(this.rbMar);
            this.pnlTop.Controls.Add(this.rbFeb);
            this.pnlTop.Controls.Add(this.rbJan);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1196, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // dbxToday
            // 
            this.dbxToday.EditMaskType = IHIS.Framework.MaskType.Date;
            this.dbxToday.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbxToday.IsJapanYearType = true;
            this.dbxToday.Location = new System.Drawing.Point(96, 4);
            this.dbxToday.Name = "dbxToday";
            this.dbxToday.Size = new System.Drawing.Size(120, 26);
            this.dbxToday.TabIndex = 104;
            this.dbxToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCalendar
            // 
            this.lbCalendar.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.lbCalendar.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCalendar.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.lbCalendar.Location = new System.Drawing.Point(2, 2);
            this.lbCalendar.Name = "lbCalendar";
            this.lbCalendar.Size = new System.Drawing.Size(92, 30);
            this.lbCalendar.TabIndex = 0;
            this.lbCalendar.Text = "カレンダ";
            this.lbCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCalendar.MouseEnter += new System.EventHandler(this.lbCalendar_MouseEnter);
            // 
            // cboYear
            // 
            this.cboYear.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8,
            this.xComboItem9,
            this.xComboItem10,
            this.xComboItem11,
            this.xComboItem12,
            this.xComboItem13,
            this.xComboItem14,
            this.xComboItem15,
            this.xComboItem16,
            this.xComboItem17,
            this.xComboItem18,
            this.xComboItem19,
            this.xComboItem20,
            this.xComboItem21,
            this.xComboItem22,
            this.xComboItem23,
            this.xComboItem24,
            this.xComboItem25});
            this.cboYear.Location = new System.Drawing.Point(270, 8);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(84, 21);
            this.cboYear.TabIndex = 3;
            this.cboYear.Visible = false;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "2006";
            this.xComboItem1.ValueItem = "2006";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "2007";
            this.xComboItem2.ValueItem = "2007";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "2008";
            this.xComboItem3.ValueItem = "2008";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "2009";
            this.xComboItem4.ValueItem = "2009";
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "2010";
            this.xComboItem5.ValueItem = "2010";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "2011";
            this.xComboItem6.ValueItem = "2011";
            // 
            // xComboItem7
            // 
            this.xComboItem7.DisplayItem = "2012";
            this.xComboItem7.ValueItem = "2012";
            // 
            // xComboItem8
            // 
            this.xComboItem8.DisplayItem = "2013";
            this.xComboItem8.ValueItem = "2013";
            // 
            // xComboItem9
            // 
            this.xComboItem9.DisplayItem = "2014";
            this.xComboItem9.ValueItem = "2014";
            // 
            // xComboItem10
            // 
            this.xComboItem10.DisplayItem = "2015";
            this.xComboItem10.ValueItem = "2015";
            // 
            // xComboItem11
            // 
            this.xComboItem11.DisplayItem = "2016";
            this.xComboItem11.ValueItem = "2016";
            // 
            // xComboItem12
            // 
            this.xComboItem12.DisplayItem = "2017";
            this.xComboItem12.ValueItem = "2017";
            // 
            // xComboItem13
            // 
            this.xComboItem13.DisplayItem = "2018";
            this.xComboItem13.ValueItem = "2018";
            // 
            // xComboItem14
            // 
            this.xComboItem14.DisplayItem = "2019";
            this.xComboItem14.ValueItem = "2019";
            // 
            // xComboItem15
            // 
            this.xComboItem15.DisplayItem = "2020";
            this.xComboItem15.ValueItem = "2020";
            // 
            // xComboItem16
            // 
            this.xComboItem16.DisplayItem = "2021";
            this.xComboItem16.ValueItem = "2021";
            // 
            // xComboItem17
            // 
            this.xComboItem17.DisplayItem = "2022";
            this.xComboItem17.ValueItem = "2022";
            // 
            // xComboItem18
            // 
            this.xComboItem18.DisplayItem = "2023";
            this.xComboItem18.ValueItem = "2023";
            // 
            // xComboItem19
            // 
            this.xComboItem19.DisplayItem = "2024";
            this.xComboItem19.ValueItem = "2024";
            // 
            // xComboItem20
            // 
            this.xComboItem20.DisplayItem = "2025";
            this.xComboItem20.ValueItem = "2025";
            // 
            // xComboItem21
            // 
            this.xComboItem21.DisplayItem = "2026";
            this.xComboItem21.ValueItem = "2026";
            // 
            // xComboItem22
            // 
            this.xComboItem22.DisplayItem = "2027";
            this.xComboItem22.ValueItem = "2027";
            // 
            // xComboItem23
            // 
            this.xComboItem23.DisplayItem = "2028";
            this.xComboItem23.ValueItem = "2028";
            // 
            // xComboItem24
            // 
            this.xComboItem24.DisplayItem = "2029";
            this.xComboItem24.ValueItem = "2029";
            // 
            // xComboItem25
            // 
            this.xComboItem25.DisplayItem = "2030";
            this.xComboItem25.ValueItem = "2030";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 22);
            this.label1.TabIndex = 103;
            this.label1.Text = "年度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // rbDec
            // 
            this.rbDec.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDec.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbDec.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDec.Location = new System.Drawing.Point(932, 6);
            this.rbDec.Name = "rbDec";
            this.rbDec.Size = new System.Drawing.Size(52, 26);
            this.rbDec.TabIndex = 102;
            this.rbDec.Tag = "12";
            this.rbDec.Text = "12月";
            this.rbDec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDec.UseVisualStyleBackColor = false;
            this.rbDec.Visible = false;
            this.rbDec.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbNov
            // 
            this.rbNov.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbNov.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbNov.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNov.Location = new System.Drawing.Point(880, 6);
            this.rbNov.Name = "rbNov";
            this.rbNov.Size = new System.Drawing.Size(52, 26);
            this.rbNov.TabIndex = 101;
            this.rbNov.Tag = "11";
            this.rbNov.Text = "11月";
            this.rbNov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbNov.UseVisualStyleBackColor = false;
            this.rbNov.Visible = false;
            this.rbNov.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbOct
            // 
            this.rbOct.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOct.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbOct.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOct.Location = new System.Drawing.Point(828, 6);
            this.rbOct.Name = "rbOct";
            this.rbOct.Size = new System.Drawing.Size(52, 26);
            this.rbOct.TabIndex = 100;
            this.rbOct.Tag = "10";
            this.rbOct.Text = "10月";
            this.rbOct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOct.UseVisualStyleBackColor = false;
            this.rbOct.Visible = false;
            this.rbOct.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbSep
            // 
            this.rbSep.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbSep.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbSep.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSep.Location = new System.Drawing.Point(776, 6);
            this.rbSep.Name = "rbSep";
            this.rbSep.Size = new System.Drawing.Size(52, 26);
            this.rbSep.TabIndex = 99;
            this.rbSep.Tag = "9";
            this.rbSep.Text = "9月";
            this.rbSep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSep.UseVisualStyleBackColor = false;
            this.rbSep.Visible = false;
            this.rbSep.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbAug
            // 
            this.rbAug.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAug.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbAug.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAug.Location = new System.Drawing.Point(724, 6);
            this.rbAug.Name = "rbAug";
            this.rbAug.Size = new System.Drawing.Size(52, 26);
            this.rbAug.TabIndex = 98;
            this.rbAug.Tag = "8";
            this.rbAug.Text = "8月";
            this.rbAug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAug.UseVisualStyleBackColor = false;
            this.rbAug.Visible = false;
            this.rbAug.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbJul
            // 
            this.rbJul.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbJul.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbJul.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbJul.Location = new System.Drawing.Point(672, 6);
            this.rbJul.Name = "rbJul";
            this.rbJul.Size = new System.Drawing.Size(52, 26);
            this.rbJul.TabIndex = 97;
            this.rbJul.Tag = "7";
            this.rbJul.Text = "7月";
            this.rbJul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbJul.UseVisualStyleBackColor = false;
            this.rbJul.Visible = false;
            this.rbJul.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbJun
            // 
            this.rbJun.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbJun.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbJun.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbJun.Location = new System.Drawing.Point(620, 6);
            this.rbJun.Name = "rbJun";
            this.rbJun.Size = new System.Drawing.Size(52, 26);
            this.rbJun.TabIndex = 96;
            this.rbJun.Tag = "6";
            this.rbJun.Text = "6月";
            this.rbJun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbJun.UseVisualStyleBackColor = false;
            this.rbJun.Visible = false;
            this.rbJun.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbMay
            // 
            this.rbMay.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbMay.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbMay.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMay.Location = new System.Drawing.Point(568, 6);
            this.rbMay.Name = "rbMay";
            this.rbMay.Size = new System.Drawing.Size(52, 26);
            this.rbMay.TabIndex = 95;
            this.rbMay.Tag = "5";
            this.rbMay.Text = "5月";
            this.rbMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbMay.UseVisualStyleBackColor = false;
            this.rbMay.Visible = false;
            this.rbMay.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbApr
            // 
            this.rbApr.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbApr.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbApr.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbApr.Location = new System.Drawing.Point(516, 6);
            this.rbApr.Name = "rbApr";
            this.rbApr.Size = new System.Drawing.Size(52, 26);
            this.rbApr.TabIndex = 94;
            this.rbApr.Tag = "4";
            this.rbApr.Text = "4月";
            this.rbApr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbApr.UseVisualStyleBackColor = false;
            this.rbApr.Visible = false;
            this.rbApr.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbMar
            // 
            this.rbMar.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbMar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbMar.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMar.Location = new System.Drawing.Point(464, 6);
            this.rbMar.Name = "rbMar";
            this.rbMar.Size = new System.Drawing.Size(52, 26);
            this.rbMar.TabIndex = 93;
            this.rbMar.Tag = "3";
            this.rbMar.Text = "3月";
            this.rbMar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbMar.UseVisualStyleBackColor = false;
            this.rbMar.Visible = false;
            this.rbMar.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbFeb
            // 
            this.rbFeb.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbFeb.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbFeb.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFeb.Location = new System.Drawing.Point(412, 6);
            this.rbFeb.Name = "rbFeb";
            this.rbFeb.Size = new System.Drawing.Size(52, 26);
            this.rbFeb.TabIndex = 92;
            this.rbFeb.Tag = "2";
            this.rbFeb.Text = "2月";
            this.rbFeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbFeb.UseVisualStyleBackColor = false;
            this.rbFeb.Visible = false;
            this.rbFeb.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // rbJan
            // 
            this.rbJan.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbJan.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbJan.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbJan.Location = new System.Drawing.Point(360, 6);
            this.rbJan.Name = "rbJan";
            this.rbJan.Size = new System.Drawing.Size(52, 26);
            this.rbJan.TabIndex = 91;
            this.rbJan.Tag = "1";
            this.rbJan.Text = "1月";
            this.rbJan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbJan.UseVisualStyleBackColor = false;
            this.rbJan.Visible = false;
            this.rbJan.CheckedChanged += new System.EventHandler(this.OnMonthRadioCheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1112, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.Location = new System.Drawing.Point(1034, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 28);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "照会";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // rbOnlyTotal
            // 
            this.rbOnlyTotal.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOnlyTotal.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbOnlyTotal.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbOnlyTotal.Location = new System.Drawing.Point(602, 36);
            this.rbOnlyTotal.Name = "rbOnlyTotal";
            this.rbOnlyTotal.Size = new System.Drawing.Size(64, 24);
            this.rbOnlyTotal.TabIndex = 3;
            this.rbOnlyTotal.Tag = "T";
            this.rbOnlyTotal.Text = "全体のみ";
            this.rbOnlyTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOnlyTotal.UseVisualStyleBackColor = false;
            this.rbOnlyTotal.CheckedChanged += new System.EventHandler(this.OnDoctorRadioCheckedChanged);
            // 
            // rbOnlyDrug
            // 
            this.rbOnlyDrug.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOnlyDrug.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbOnlyDrug.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbOnlyDrug.Location = new System.Drawing.Point(666, 36);
            this.rbOnlyDrug.Name = "rbOnlyDrug";
            this.rbOnlyDrug.Size = new System.Drawing.Size(64, 24);
            this.rbOnlyDrug.TabIndex = 2;
            this.rbOnlyDrug.Tag = "D";
            this.rbOnlyDrug.Text = "外来のみ";
            this.rbOnlyDrug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOnlyDrug.UseVisualStyleBackColor = false;
            this.rbOnlyDrug.CheckedChanged += new System.EventHandler(this.OnDoctorRadioCheckedChanged);
            // 
            // rbOnlyJinryo
            // 
            this.rbOnlyJinryo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOnlyJinryo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbOnlyJinryo.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbOnlyJinryo.Location = new System.Drawing.Point(666, 12);
            this.rbOnlyJinryo.Name = "rbOnlyJinryo";
            this.rbOnlyJinryo.Size = new System.Drawing.Size(64, 24);
            this.rbOnlyJinryo.TabIndex = 1;
            this.rbOnlyJinryo.Tag = "J";
            this.rbOnlyJinryo.Text = "入院のみ";
            this.rbOnlyJinryo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOnlyJinryo.UseVisualStyleBackColor = false;
            this.rbOnlyJinryo.CheckedChanged += new System.EventHandler(this.OnDoctorRadioCheckedChanged);
            // 
            // rbDoctorTotal
            // 
            this.rbDoctorTotal.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDoctorTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this.rbDoctorTotal.Checked = true;
            this.rbDoctorTotal.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbDoctorTotal.ForeColor = System.Drawing.Color.White;
            this.rbDoctorTotal.Location = new System.Drawing.Point(602, 12);
            this.rbDoctorTotal.Name = "rbDoctorTotal";
            this.rbDoctorTotal.Size = new System.Drawing.Size(64, 24);
            this.rbDoctorTotal.TabIndex = 0;
            this.rbDoctorTotal.TabStop = true;
            this.rbDoctorTotal.Tag = "A";
            this.rbDoctorTotal.Text = "ALL";
            this.rbDoctorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbDoctorTotal.UseVisualStyleBackColor = false;
            this.rbDoctorTotal.CheckedChanged += new System.EventHandler(this.OnDoctorRadioCheckedChanged);
            // 
            // btnGwaBase
            // 
            this.btnGwaBase.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGwaBase.ImageIndex = 2;
            this.btnGwaBase.ImageList = this.ImageList;
            this.btnGwaBase.Location = new System.Drawing.Point(540, 60);
            this.btnGwaBase.Name = "btnGwaBase";
            this.btnGwaBase.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnGwaBase.Size = new System.Drawing.Size(29, 36);
            this.btnGwaBase.TabIndex = 92;
            this.btnGwaBase.Visible = false;
            this.btnGwaBase.Click += new System.EventHandler(this.btnGwaBase_Click);
            // 
            // tbGwaY
            // 
            this.tbGwaY.BarBorderColor = new IHIS.Framework.XColor(System.Drawing.Color.CadetBlue);
            this.tbGwaY.BarColor = new IHIS.Framework.XColor(System.Drawing.Color.LightCyan);
            this.tbGwaY.Location = new System.Drawing.Point(444, 82);
            this.tbGwaY.Maximum = 180;
            this.tbGwaY.Minimum = -180;
            this.tbGwaY.Name = "tbGwaY";
            this.tbGwaY.Size = new System.Drawing.Size(94, 14);
            this.tbGwaY.TabIndex = 104;
            this.tbGwaY.Visible = false;
            this.tbGwaY.ValueChanged += new System.EventHandler(this.tbGwaY_ValueChanged);
            // 
            // tbGwaX
            // 
            this.tbGwaX.Location = new System.Drawing.Point(444, 62);
            this.tbGwaX.Maximum = 90;
            this.tbGwaX.Minimum = -90;
            this.tbGwaX.Name = "tbGwaX";
            this.tbGwaX.Size = new System.Drawing.Size(94, 14);
            this.tbGwaX.TabIndex = 103;
            this.tbGwaX.Visible = false;
            this.tbGwaX.ValueChanged += new System.EventHandler(this.tbGwaX_ValueChanged);
            // 
            // cbxGwa100
            // 
            this.cbxGwa100.Location = new System.Drawing.Point(444, 10);
            this.cbxGwa100.Name = "cbxGwa100";
            this.cbxGwa100.Size = new System.Drawing.Size(104, 24);
            this.cbxGwa100.TabIndex = 99;
            this.cbxGwa100.Text = "百分率に表示";
            this.cbxGwa100.CheckedChanged += new System.EventHandler(this.cbxGwa100_CheckedChanged);
            // 
            // cbxGwa3D
            // 
            this.cbxGwa3D.Location = new System.Drawing.Point(444, 34);
            this.cbxGwa3D.Name = "cbxGwa3D";
            this.cbxGwa3D.Size = new System.Drawing.Size(104, 24);
            this.cbxGwa3D.TabIndex = 97;
            this.cbxGwa3D.Text = "3D表示";
            this.cbxGwa3D.CheckedChanged += new System.EventHandler(this.cbxGwa3D_CheckedChanged);
            // 
            // chartGwa
            // 
            this.chartGwa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartGwa.BackGradientEndColor = System.Drawing.Color.White;
            this.chartGwa.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.chartGwa.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chartGwa.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.chartGwa.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.chartGwa.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.chartGwa.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.chartGwa.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Light = Dundas.Charting.WinControl.LightStyle.Realistic;
            chartArea1.AxisX.LabelStyle.Interval = 0;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.Interval = 0;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 0;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorTickMark.Interval = 0;
            chartArea1.AxisX.MajorTickMark.IntervalOffset = 0;
            chartArea1.AxisX.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.LabelStyle.Interval = 0;
            chartArea1.AxisX2.LabelStyle.IntervalOffset = 0;
            chartArea1.AxisX2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorGrid.Interval = 0;
            chartArea1.AxisX2.MajorGrid.IntervalOffset = 0;
            chartArea1.AxisX2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.MajorTickMark.Interval = 0;
            chartArea1.AxisX2.MajorTickMark.IntervalOffset = 0;
            chartArea1.AxisX2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.LabelStyle.Interval = 0;
            chartArea1.AxisY.LabelStyle.IntervalOffset = 0;
            chartArea1.AxisY.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.Interval = 0;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 0;
            chartArea1.AxisY.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorTickMark.Interval = 0;
            chartArea1.AxisY.MajorTickMark.IntervalOffset = 0;
            chartArea1.AxisY.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.LabelStyle.Interval = 0;
            chartArea1.AxisY2.LabelStyle.IntervalOffset = 0;
            chartArea1.AxisY2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorGrid.Interval = 0;
            chartArea1.AxisY2.MajorGrid.IntervalOffset = 0;
            chartArea1.AxisY2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.MajorTickMark.Interval = 0;
            chartArea1.AxisY2.MajorTickMark.IntervalOffset = 0;
            chartArea1.AxisY2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Empty;
            chartArea1.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            this.chartGwa.ChartAreas.Add(chartArea1);
            this.chartGwa.Dock = System.Windows.Forms.DockStyle.Left;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.AutoFitText = false;
            legend1.BackColor = System.Drawing.Color.White;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            legend1.Name = "Default";
            legend1.ShadowOffset = 2;
            this.chartGwa.Legends.Add(legend1);
            this.chartGwa.Location = new System.Drawing.Point(0, 0);
            this.chartGwa.Name = "chartGwa";
            this.chartGwa.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.ChartType = "Doughnut";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            series1.Name = "SeriesGwa";
            series1.ShadowOffset = 1;
            series1.ShowLabelAsValue = true;
            series1.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series1.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            this.chartGwa.Series.Add(series1);
            this.chartGwa.Size = new System.Drawing.Size(584, 520);
            this.chartGwa.TabIndex = 0;
            title1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "【 パート別診療状況 】";
            this.chartGwa.Titles.Add(title1);
            this.chartGwa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartGwa_MouseMove);
            this.chartGwa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartGwa_MouseDown);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.calendar);
            this.pnlCenter.Controls.Add(this.btnGwaBase);
            this.pnlCenter.Controls.Add(this.tbGwaY);
            this.pnlCenter.Controls.Add(this.tbGwaX);
            this.pnlCenter.Controls.Add(this.cbxGwa100);
            this.pnlCenter.Controls.Add(this.cbxGwa3D);
            this.pnlCenter.Controls.Add(this.tbDoctorY);
            this.pnlCenter.Controls.Add(this.tbDoctorX);
            this.pnlCenter.Controls.Add(this.btnDoctorBase);
            this.pnlCenter.Controls.Add(this.rbOnlyTotal);
            this.pnlCenter.Controls.Add(this.rbOnlyDrug);
            this.pnlCenter.Controls.Add(this.rbOnlyJinryo);
            this.pnlCenter.Controls.Add(this.rbDoctorTotal);
            this.pnlCenter.Controls.Add(this.cbxDoctor100);
            this.pnlCenter.Controls.Add(this.cbxDoctor3D);
            this.pnlCenter.Controls.Add(this.chartDoctor);
            this.pnlCenter.Controls.Add(this.chartGwa);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(2, 38);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1196, 520);
            this.pnlCenter.TabIndex = 6;
            // 
            // calendar
            // 
            this.calendar.EnableMultiSelection = false;
            this.calendar.IsJapanYearType = true;
            this.calendar.Location = new System.Drawing.Point(2, 4);
            this.calendar.MaxDate = new System.DateTime(2016, 5, 20, 0, 0, 0, 0);
            this.calendar.MinDate = new System.DateTime(1996, 5, 20, 0, 0, 0, 0);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(230, 230);
            this.calendar.TabIndex = 112;
            this.calendar.Visible = false;
            this.calendar.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.calendar_DayClick);
            this.calendar.MouseLeave += new System.EventHandler(this.calendar_MouseLeave);
            // 
            // tbDoctorY
            // 
            this.tbDoctorY.BarBorderColor = new IHIS.Framework.XColor(System.Drawing.Color.CadetBlue);
            this.tbDoctorY.BarColor = new IHIS.Framework.XColor(System.Drawing.Color.LightCyan);
            this.tbDoctorY.Location = new System.Drawing.Point(1054, 82);
            this.tbDoctorY.Maximum = 180;
            this.tbDoctorY.Minimum = -180;
            this.tbDoctorY.Name = "tbDoctorY";
            this.tbDoctorY.Size = new System.Drawing.Size(94, 14);
            this.tbDoctorY.TabIndex = 110;
            this.tbDoctorY.Visible = false;
            this.tbDoctorY.ValueChanged += new System.EventHandler(this.tbDoctorY_ValueChanged);
            // 
            // tbDoctorX
            // 
            this.tbDoctorX.Location = new System.Drawing.Point(1054, 62);
            this.tbDoctorX.Maximum = 90;
            this.tbDoctorX.Minimum = -90;
            this.tbDoctorX.Name = "tbDoctorX";
            this.tbDoctorX.Size = new System.Drawing.Size(94, 14);
            this.tbDoctorX.TabIndex = 109;
            this.tbDoctorX.Visible = false;
            this.tbDoctorX.ValueChanged += new System.EventHandler(this.tbDoctorX_ValueChanged);
            // 
            // btnDoctorBase
            // 
            this.btnDoctorBase.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctorBase.ImageIndex = 2;
            this.btnDoctorBase.ImageList = this.ImageList;
            this.btnDoctorBase.Location = new System.Drawing.Point(1150, 60);
            this.btnDoctorBase.Name = "btnDoctorBase";
            this.btnDoctorBase.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDoctorBase.Size = new System.Drawing.Size(29, 36);
            this.btnDoctorBase.TabIndex = 108;
            this.btnDoctorBase.Visible = false;
            this.btnDoctorBase.Click += new System.EventHandler(this.btnDoctorBase_Click);
            // 
            // cbxDoctor100
            // 
            this.cbxDoctor100.Location = new System.Drawing.Point(1054, 10);
            this.cbxDoctor100.Name = "cbxDoctor100";
            this.cbxDoctor100.Size = new System.Drawing.Size(104, 24);
            this.cbxDoctor100.TabIndex = 103;
            this.cbxDoctor100.Text = "百分率に表示";
            this.cbxDoctor100.CheckedChanged += new System.EventHandler(this.cbxDoctor100_CheckedChanged);
            // 
            // cbxDoctor3D
            // 
            this.cbxDoctor3D.Location = new System.Drawing.Point(1054, 34);
            this.cbxDoctor3D.Name = "cbxDoctor3D";
            this.cbxDoctor3D.Size = new System.Drawing.Size(102, 24);
            this.cbxDoctor3D.TabIndex = 96;
            this.cbxDoctor3D.Text = "3D表示";
            this.cbxDoctor3D.CheckedChanged += new System.EventHandler(this.cbxDoctor3D_CheckedChanged);
            // 
            // chartDoctor
            // 
            this.chartDoctor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartDoctor.BackGradientEndColor = System.Drawing.Color.White;
            this.chartDoctor.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.chartDoctor.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chartDoctor.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.chartDoctor.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.chartDoctor.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.chartDoctor.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.chartDoctor.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea2.AxisX.Interval = 1;
            chartArea2.AxisX.LabelsAutoFit = false;
            chartArea2.AxisX.LabelStyle.Interval = 1;
            chartArea2.AxisX.LabelStyle.IntervalOffset = 0;
            chartArea2.AxisX.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.Interval = 1;
            chartArea2.AxisX.MajorGrid.IntervalOffset = 0;
            chartArea2.AxisX.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorTickMark.Interval = 1;
            chartArea2.AxisX.MajorTickMark.IntervalOffset = 0;
            chartArea2.AxisX.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("MS UI Gothic", 9.75F);
            chartArea2.AxisX2.LabelStyle.Interval = 0;
            chartArea2.AxisX2.LabelStyle.IntervalOffset = 0;
            chartArea2.AxisX2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX2.MajorGrid.Interval = 0;
            chartArea2.AxisX2.MajorGrid.IntervalOffset = 0;
            chartArea2.AxisX2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX2.MajorTickMark.Interval = 0;
            chartArea2.AxisX2.MajorTickMark.IntervalOffset = 0;
            chartArea2.AxisX2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.LabelStyle.Interval = 0;
            chartArea2.AxisY.LabelStyle.IntervalOffset = 0;
            chartArea2.AxisY.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MajorGrid.Interval = 0;
            chartArea2.AxisY.MajorGrid.IntervalOffset = 0;
            chartArea2.AxisY.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorTickMark.Interval = 0;
            chartArea2.AxisY.MajorTickMark.IntervalOffset = 0;
            chartArea2.AxisY.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("MS UI Gothic", 9.75F);
            chartArea2.AxisY2.LabelStyle.Interval = 0;
            chartArea2.AxisY2.LabelStyle.IntervalOffset = 0;
            chartArea2.AxisY2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY2.MajorGrid.Interval = 0;
            chartArea2.AxisY2.MajorGrid.IntervalOffset = 0;
            chartArea2.AxisY2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY2.MajorTickMark.Interval = 0;
            chartArea2.AxisY2.MajorTickMark.IntervalOffset = 0;
            chartArea2.AxisY2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea2.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            chartArea2.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea2.Name = "Default";
            chartArea2.ShadowOffset = 2;
            this.chartDoctor.ChartAreas.Add(chartArea2);
            this.chartDoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.AutoFitText = false;
            legend2.BackColor = System.Drawing.Color.White;
            legend2.BorderColor = System.Drawing.Color.Transparent;
            legend2.Docking = Dundas.Charting.WinControl.LegendDocking.Top;
            legend2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            legend2.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend2.Name = "Default";
            legend2.ShadowOffset = 2;
            this.chartDoctor.Legends.Add(legend2);
            this.chartDoctor.Location = new System.Drawing.Point(584, 0);
            this.chartDoctor.Name = "chartDoctor";
            this.chartDoctor.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series2.BorderWidth = 2;
            series2.ChartType = "Line";
            series2.CustomAttributes = "LabelStyle=Top";
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            series2.FontColor = System.Drawing.Color.Blue;
            series2.MarkerSize = 8;
            series2.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Diamond;
            series2.Name = "全体";
            series2.ShadowOffset = 2;
            series2.ShowLabelAsValue = true;
            series2.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series2.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series3.ChartType = "StackedColumn";
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            series3.Name = "入院";
            series3.ShadowOffset = 2;
            series3.ShowLabelAsValue = true;
            series3.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series3.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series4.ChartType = "StackedColumn";
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            series4.Name = "外来";
            series4.ShadowOffset = 2;
            series4.ShowLabelAsValue = true;
            series4.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series4.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            this.chartDoctor.Series.Add(series2);
            this.chartDoctor.Series.Add(series3);
            this.chartDoctor.Series.Add(series4);
            this.chartDoctor.Size = new System.Drawing.Size(612, 520);
            this.chartDoctor.TabIndex = 99;
            title2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "【 医師別診療状況 】";
            this.chartDoctor.Titles.Add(title2);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUpDown);
            this.pnlBottom.Controls.Add(this.rbOnlyDangMonth);
            this.pnlBottom.Controls.Add(this.rbOnlyJunMonth);
            this.pnlBottom.Controls.Add(this.rbOnlyJunJunMonth);
            this.pnlBottom.Controls.Add(this.tbLineTotal);
            this.pnlBottom.Controls.Add(this.tbLineY);
            this.pnlBottom.Controls.Add(this.tbLineX);
            this.pnlBottom.Controls.Add(this.btnLineBase);
            this.pnlBottom.Controls.Add(this.cbxLine3D);
            this.pnlBottom.Controls.Add(this.chartLine);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(2, 558);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1196, 300);
            this.pnlBottom.TabIndex = 7;
            // 
            // btnUpDown
            // 
            this.btnUpDown.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpDown.ImageIndex = 0;
            this.btnUpDown.ImageList = this.ImageList;
            this.btnUpDown.Location = new System.Drawing.Point(12, 12);
            this.btnUpDown.Name = "btnUpDown";
            this.btnUpDown.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnUpDown.Size = new System.Drawing.Size(36, 30);
            this.btnUpDown.TabIndex = 120;
            this.btnUpDown.Click += new System.EventHandler(this.btnUpDown_Click);
            // 
            // rbOnlyDangMonth
            // 
            this.rbOnlyDangMonth.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOnlyDangMonth.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbOnlyDangMonth.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbOnlyDangMonth.Location = new System.Drawing.Point(878, 38);
            this.rbOnlyDangMonth.Name = "rbOnlyDangMonth";
            this.rbOnlyDangMonth.Size = new System.Drawing.Size(76, 24);
            this.rbOnlyDangMonth.TabIndex = 119;
            this.rbOnlyDangMonth.Tag = "T";
            this.rbOnlyDangMonth.Text = "当月のみ";
            this.rbOnlyDangMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOnlyDangMonth.UseVisualStyleBackColor = false;
            this.rbOnlyDangMonth.CheckedChanged += new System.EventHandler(this.OnLineRadioCheckedChanged);
            // 
            // rbOnlyJunMonth
            // 
            this.rbOnlyJunMonth.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOnlyJunMonth.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbOnlyJunMonth.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbOnlyJunMonth.Location = new System.Drawing.Point(954, 38);
            this.rbOnlyJunMonth.Name = "rbOnlyJunMonth";
            this.rbOnlyJunMonth.Size = new System.Drawing.Size(78, 24);
            this.rbOnlyJunMonth.TabIndex = 118;
            this.rbOnlyJunMonth.Tag = "P";
            this.rbOnlyJunMonth.Text = "前月のみ";
            this.rbOnlyJunMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOnlyJunMonth.UseVisualStyleBackColor = false;
            this.rbOnlyJunMonth.CheckedChanged += new System.EventHandler(this.OnLineRadioCheckedChanged);
            // 
            // rbOnlyJunJunMonth
            // 
            this.rbOnlyJunJunMonth.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbOnlyJunJunMonth.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rbOnlyJunJunMonth.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbOnlyJunJunMonth.Location = new System.Drawing.Point(954, 14);
            this.rbOnlyJunJunMonth.Name = "rbOnlyJunJunMonth";
            this.rbOnlyJunJunMonth.Size = new System.Drawing.Size(78, 24);
            this.rbOnlyJunJunMonth.TabIndex = 117;
            this.rbOnlyJunJunMonth.Tag = "N";
            this.rbOnlyJunJunMonth.Text = "前前月のみ";
            this.rbOnlyJunJunMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbOnlyJunJunMonth.UseVisualStyleBackColor = false;
            this.rbOnlyJunJunMonth.CheckedChanged += new System.EventHandler(this.OnLineRadioCheckedChanged);
            // 
            // tbLineTotal
            // 
            this.tbLineTotal.Appearance = System.Windows.Forms.Appearance.Button;
            this.tbLineTotal.BackColor = System.Drawing.Color.RoyalBlue;
            this.tbLineTotal.Checked = true;
            this.tbLineTotal.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbLineTotal.ForeColor = System.Drawing.Color.White;
            this.tbLineTotal.Location = new System.Drawing.Point(878, 14);
            this.tbLineTotal.Name = "tbLineTotal";
            this.tbLineTotal.Size = new System.Drawing.Size(76, 24);
            this.tbLineTotal.TabIndex = 116;
            this.tbLineTotal.TabStop = true;
            this.tbLineTotal.Tag = "A";
            this.tbLineTotal.Text = "ALL";
            this.tbLineTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tbLineTotal.UseVisualStyleBackColor = false;
            this.tbLineTotal.CheckedChanged += new System.EventHandler(this.OnLineRadioCheckedChanged);
            // 
            // tbLineY
            // 
            this.tbLineY.BarBorderColor = new IHIS.Framework.XColor(System.Drawing.Color.CadetBlue);
            this.tbLineY.BarColor = new IHIS.Framework.XColor(System.Drawing.Color.LightCyan);
            this.tbLineY.Location = new System.Drawing.Point(1052, 50);
            this.tbLineY.Maximum = 180;
            this.tbLineY.Minimum = -180;
            this.tbLineY.Name = "tbLineY";
            this.tbLineY.Size = new System.Drawing.Size(94, 14);
            this.tbLineY.TabIndex = 115;
            this.tbLineY.Visible = false;
            this.tbLineY.ValueChanged += new System.EventHandler(this.tbLineY_ValueChanged);
            // 
            // tbLineX
            // 
            this.tbLineX.Location = new System.Drawing.Point(1052, 32);
            this.tbLineX.Maximum = 90;
            this.tbLineX.Minimum = -90;
            this.tbLineX.Name = "tbLineX";
            this.tbLineX.Size = new System.Drawing.Size(94, 14);
            this.tbLineX.TabIndex = 114;
            this.tbLineX.Visible = false;
            this.tbLineX.ValueChanged += new System.EventHandler(this.tbLineX_ValueChanged);
            // 
            // btnLineBase
            // 
            this.btnLineBase.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineBase.ImageIndex = 2;
            this.btnLineBase.ImageList = this.ImageList;
            this.btnLineBase.Location = new System.Drawing.Point(1150, 30);
            this.btnLineBase.Name = "btnLineBase";
            this.btnLineBase.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnLineBase.Size = new System.Drawing.Size(29, 36);
            this.btnLineBase.TabIndex = 113;
            this.btnLineBase.Visible = false;
            this.btnLineBase.Click += new System.EventHandler(this.btnLineBase_Click);
            // 
            // cbxLine3D
            // 
            this.cbxLine3D.Location = new System.Drawing.Point(1052, 8);
            this.cbxLine3D.Name = "cbxLine3D";
            this.cbxLine3D.Size = new System.Drawing.Size(102, 24);
            this.cbxLine3D.TabIndex = 111;
            this.cbxLine3D.Text = "3D表示";
            this.cbxLine3D.CheckedChanged += new System.EventHandler(this.cbxLine3D_CheckedChanged);
            // 
            // chartLine
            // 
            this.chartLine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartLine.BackGradientEndColor = System.Drawing.Color.White;
            this.chartLine.BackGradientType = Dundas.Charting.WinControl.GradientType.DiagonalLeft;
            this.chartLine.BorderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chartLine.BorderLineStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            this.chartLine.BorderSkin.FrameBackColor = System.Drawing.Color.CornflowerBlue;
            this.chartLine.BorderSkin.FrameBackGradientEndColor = System.Drawing.Color.CornflowerBlue;
            this.chartLine.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
            this.chartLine.BorderSkin.SkinStyle = Dundas.Charting.WinControl.BorderSkinStyle.Emboss;
            chartArea3.Area3DStyle.Light = Dundas.Charting.WinControl.LightStyle.Realistic;
            chartArea3.Area3DStyle.RightAngleAxes = false;
            chartArea3.AxisX.LabelsAutoFit = false;
            chartArea3.AxisX.LabelStyle.Interval = 0;
            chartArea3.AxisX.LabelStyle.IntervalOffset = 0;
            chartArea3.AxisX.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX.MajorGrid.Interval = 0;
            chartArea3.AxisX.MajorGrid.IntervalOffset = 0;
            chartArea3.AxisX.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MajorTickMark.Interval = 0;
            chartArea3.AxisX.MajorTickMark.IntervalOffset = 0;
            chartArea3.AxisX.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.StartFromZero = false;
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("MS UI Gothic", 9.75F);
            chartArea3.AxisX2.LabelStyle.Interval = 0;
            chartArea3.AxisX2.LabelStyle.IntervalOffset = 0;
            chartArea3.AxisX2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX2.MajorGrid.Interval = 0;
            chartArea3.AxisX2.MajorGrid.IntervalOffset = 0;
            chartArea3.AxisX2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX2.MajorTickMark.Interval = 0;
            chartArea3.AxisX2.MajorTickMark.IntervalOffset = 0;
            chartArea3.AxisX2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisX2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.LabelsAutoFit = false;
            chartArea3.AxisY.LabelStyle.Interval = 0;
            chartArea3.AxisY.LabelStyle.IntervalOffset = 0;
            chartArea3.AxisY.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY.MajorGrid.Interval = 0;
            chartArea3.AxisY.MajorGrid.IntervalOffset = 0;
            chartArea3.AxisY.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MajorTickMark.Interval = 0;
            chartArea3.AxisY.MajorTickMark.IntervalOffset = 0;
            chartArea3.AxisY.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.Title = "【 診療患者数 】";
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY2.LabelStyle.Interval = 0;
            chartArea3.AxisY2.LabelStyle.IntervalOffset = 0;
            chartArea3.AxisY2.LabelStyle.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY2.LabelStyle.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY2.MajorGrid.Interval = 0;
            chartArea3.AxisY2.MajorGrid.IntervalOffset = 0;
            chartArea3.AxisY2.MajorGrid.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY2.MajorGrid.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY2.MajorTickMark.Interval = 0;
            chartArea3.AxisY2.MajorTickMark.IntervalOffset = 0;
            chartArea3.AxisY2.MajorTickMark.IntervalOffsetType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY2.MajorTickMark.IntervalType = Dundas.Charting.WinControl.DateTimeIntervalType.Auto;
            chartArea3.AxisY2.MinorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            chartArea3.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Solid;
            chartArea3.Name = "Default";
            chartArea3.ShadowOffset = 2;
            this.chartLine.ChartAreas.Add(chartArea3);
            this.chartLine.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.AutoFitText = false;
            legend3.BackColor = System.Drawing.Color.White;
            legend3.BorderColor = System.Drawing.Color.Transparent;
            legend3.Docking = Dundas.Charting.WinControl.LegendDocking.Top;
            legend3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            legend3.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            legend3.Name = "Default";
            legend3.ShadowOffset = 2;
            this.chartLine.Legends.Add(legend3);
            this.chartLine.Location = new System.Drawing.Point(0, 0);
            this.chartLine.Name = "chartLine";
            this.chartLine.Palette = Dundas.Charting.WinControl.ChartColorPalette.Dundas;
            series5.ChartType = "Line";
            series5.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
            series5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            series5.FontColor = System.Drawing.Color.DodgerBlue;
            series5.MarkerSize = 6;
            series5.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Square;
            series5.Name = "前前月";
            series5.ToolTip = "#VALY";
            series5.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series5.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series6.BorderWidth = 2;
            series6.ChartType = "Line";
            series6.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
            series6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            series6.FontColor = System.Drawing.Color.DarkOrange;
            series6.MarkerSize = 8;
            series6.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Diamond;
            series6.Name = "当月";
            series6.ShadowOffset = 2;
            series6.ToolTip = "#VALY";
            series6.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series6.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series7.ChartType = "Line";
            series7.EmptyPointStyle.BorderStyle = Dundas.Charting.WinControl.ChartDashStyle.Dash;
            series7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold);
            series7.FontColor = System.Drawing.Color.DarkRed;
            series7.MarkerSize = 6;
            series7.MarkerStyle = Dundas.Charting.WinControl.MarkerStyle.Circle;
            series7.Name = "前月";
            series7.ToolTip = "#VALY";
            series7.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            series7.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
            this.chartLine.Series.Add(series5);
            this.chartLine.Series.Add(series6);
            this.chartLine.Series.Add(series7);
            this.chartLine.Size = new System.Drawing.Size(1196, 300);
            this.chartLine.TabIndex = 0;
            title3.Name = "Title1";
            this.chartLine.Titles.Add(title3);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Khaki;
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(2, 554);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1196, 4);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // layGwaData
            // 
            this.layGwaData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17});
            this.layGwaData.QuerySQL = resources.GetString("layGwaData.QuerySQL");
            this.layGwaData.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGwaData_QueryStarting);
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "Gwa";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "GwaName";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "PersonCnt";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "Persantage";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Number;
            // 
            // layDoctorData
            // 
            this.layDoctorData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem18});
            this.layDoctorData.QuerySQL = resources.GetString("layDoctorData.QuerySQL");
            this.layDoctorData.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDoctorData_QueryStarting);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "DoctorID";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "DoctorName";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "TotalCnt";
            this.multiLayoutItem12.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "DrugCnt";
            this.multiLayoutItem13.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "JinryoCnt";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            // 
            // layMonthData
            // 
            this.layMonthData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            this.layMonthData.QuerySQL = resources.GetString("layMonthData.QuerySQL");
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "NaewonDate";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "Count";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Number;
            // 
            // layJundalPart
            // 
            this.layJundalPart.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layJundalPart.QuerySQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM CPL0109\r\n WHERE HOSP_CODE = :f_hosp_code\r\n " +
                "  AND CODE_TYPE = \'01\'";
            this.layJundalPart.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layJundalPart_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "jundal_part";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "jundal_part_name";
            // 
            // layTotalCnt
            // 
            this.layTotalCnt.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layTotalCnt.QuerySQL = resources.GetString("layTotalCnt.QuerySQL");
            this.layTotalCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTotalCnt_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "TotalCnt";
            // 
            // CPL2010Q05
            // 
            this.BackGroundColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Window);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "CPL2010Q05";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(1200, 860);
            this.Activated += new System.EventHandler(this.CPL2010Q05_Activated);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGwa)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoctor)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGwaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDoctorData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layMonthData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layJundalPart)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region DisplayGwaChart (과차트 Display)
		private void DisplayGwaChart()
		{
			this.chartGwa.DataSource = null;
			//DataService 조회하여 성공시 DataSource 연결 -> LayoutTable로
			int totalCount = 0;

            this.layTotalCnt.QueryLayout();

			//SingleOutput 에서 전체 카운드 SET
			totalCount = Int32.Parse(layTotalCnt.GetItemValue("TotalCnt").ToString());

            if (totalCount > 0)
            {
                this.layGwaData.SetBindVarValue("o_total_count", totalCount.ToString());

                if (layGwaData.QueryLayout(true))
                {
                    chartGwa.DataSource = this.layGwaData.LayoutTable;
                    chartGwa.DataBind();
                    //Title은 내과의사별진료현황
                    this.chartGwa.Titles[0].Text = "パート別診療状況 総人数(" + totalCount.ToString() + ")";
                }
                else
                {
                    XMessageBox.Show("パート別診療状況照会エラー[" + Service.ErrFullMsg + "]");
                }
            }
            else
            {
                this.layGwaData.Reset();
                this.chartGwa.DataSource = this.layGwaData.LayoutTable;
                this.chartGwa.DataBind();
                this.chartGwa.Invalidate();
                this.chartGwa.Titles[0].Text = "【 パート別診療状況 】";
                chartDoctor.Titles[0].Text = "【 医師別診療状況 】";
            }

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			//촬영구분List 구성
            this.layJundalPart.QueryLayout(true);

			if (layJundalPart != null)
			{
				//Code, CodeName이 넘어오므로 과명을 Key로 과코드를 Value로
				foreach (DataRow dataRow in layJundalPart.LayoutTable.Rows)
				{
					this.gwaCodeList.Add(dataRow[1], dataRow[0]);
				}
			}

			//현재날짜 설정, 현재월 Radio 선택
			this.selectedDate = EnvironInfo.GetSysDate();
			this.dbxToday.SetDataValue(selectedDate);  //선택일 Display
			//칼렌다의 현재일 SET
			this.calendar.SelectDate(this.selectedDate);
			this.cboYear.SetDataValue(selectedDate.Year);
			//현재월의 RadioButton Check하여 일별환자수 Chart 구성
			if (this.monthRadioList.Contains(selectedDate.Month.ToString()))
			{
				RadioButton rbo = monthRadioList[selectedDate.Month.ToString()] as RadioButton;
				rbo.Checked = true;
			}

			//과별 차트 (해당 Series의 X, Y에 컬럼명 Mapping)
			chartGwa.Series["SeriesGwa"].ValueMemberX = "GwaName";  
			chartGwa.Series["SeriesGwa"].ValueMembersY = "PersonCnt";
			//DataService 조회하여 성공시 DataSource 연결 -> LayoutTable로
			//과차트 Display
			DisplayGwaChart();

			//의사 Chart 각 Series별 컬럼명 SET
			chartDoctor.Series["外来"].ValueMemberX = "DoctorName";
			chartDoctor.Series["外来"].ValueMembersY = "DrugCnt";

			chartDoctor.Series["入院"].ValueMemberX = "DoctorName";
			chartDoctor.Series["入院"].ValueMembersY = "JinryoCnt";

			chartDoctor.Series["全体"].ValueMemberX = "DoctorName";
			chartDoctor.Series["全体"].ValueMembersY = "TotalCnt";

			//Data Font 설정
			//chartDoctor.ChartAreas["Default"].AxisX.LabelStyle.Font = new Font("Arial", 9);
			//의사명이 전부 보이도록, Default = 2 (한칸씩 띄어서 보여줌
			//chartDoctor.ChartAreas["Default"].AxisX.Interval = 1;

			//Cylinder 모양으로 Series 설정
			chartDoctor.Series["外来"]["DrawingStyle"] = "Cylinder";
			chartDoctor.Series["入院"]["DrawingStyle"] = "Cylinder";

			//Count MAX, Min값 SET
			chartDoctor.ChartAreas["Default"].AxisY.Minimum = 0;
			//MAX값은 데이타중에서 제일 큰값으로 조금 마진을 두어 동적으로 설정(DisplayDoctorChart에서 SET)
			chartDoctor.ChartAreas["Default"].AxisY.Maximum = 100;
			//데이타 소스 연결은 Chart의 MouseDown에서 선택시

			//Line Chart 구성 (시리즈에 컬럼  Mapping) - X는 일자, Y는 전월,전전월,당월환자수 컬럼
			chartLine.Series["前前月"].ValueMemberX = "Day";
			chartLine.Series["前前月"].ValueMembersY = "JunJunMonth";

			chartLine.Series["前月"].ValueMemberX = "Day";
			chartLine.Series["前月"].ValueMembersY = "JunMonth";

			chartLine.Series["当月"].ValueMemberX = "Day";
			chartLine.Series["当月"].ValueMembersY = "DangMonth";

			chartLine.Series["当月"]["EmptyPointValue"] = "Zero";
			chartLine.Series["前月"]["EmptyPointValue"] = "Zero";
			chartLine.Series["前前月"]["EmptyPointValue"] = "Zero";

			//this.cbxGwa3D.Checked = true;
		}
		#endregion

		#region 과차트 MouseDown, MouseMove (과 선택 Logic)
		private void chartGwa_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;

			// Call Hit Test Method
			HitTestResult result = chartGwa.HitTest( e.X, e.Y );

			// Exit event if no item was clicked on (PointResult will be negative one)
			if(result.PointIndex < 0)
				return;

			// Check if data point is already exploded.
			DataPoint selectedPoint = chartGwa.Series[0].Points[result.PointIndex];
			//Exploded 상태인지 여부
			bool exploded = (selectedPoint.CustomAttributes == "Exploded=true" )? true : false ;

			// Remove all exploded attributes
			foreach( DataPoint point in chartGwa.Series[0].Points )
			{
				//동일한 DataPoint 선택시에 기존 선택상태 Clear하지 않음(이미 선택되었으면 다시 원상태로)
				//if (!point.Equals(selectedPoint))
				point.CustomAttributes = "";
			}

			// If data point is already exploded get out.
			if( exploded )
			{
				ClearChartDoctor();
				return;
			}
			
			bool isQryDoctor = false; //과내 의사별 내역 조회여부
			// If data point is selected
			if( result.ChartElementType == ChartElementType.DataPoint )
			{
				// 선택된 DataPoint에 Exploded Attribute Set
				selectedPoint.CustomAttributes = "Exploded = true";
				isQryDoctor = true;  //과가 바뀌었으므로 과내 의사별 내역 조회
			}

			else if( result.ChartElementType == ChartElementType.DataPointLabel )  // If data point label is selected
			{
				// Set Attribute
				selectedPoint.CustomAttributes = "Exploded = true";
				isQryDoctor = true;  //과가 바뀌었으므로 과내 의사별 내역 조회
			}
			else if( result.ChartElementType == ChartElementType.LegendItem ) // If legend item is selected
			{
				// Set Attribute
				selectedPoint.CustomAttributes = "Exploded = true";
				isQryDoctor = true;  //과가 바뀌었으므로 과내 의사별 내역 조회
			}
			else
			{
				ClearChartDoctor();
			}

			//현재 선택된 과의 과코드를 DataPoint에서 관리할 수 없다.
			//AxisLabel에 과명을 가져올 수가 있는데, 이를 Mapping하는 Hashtable을 하나 관리하여 과명으로 과코드를 가져오도록 하자.
			//과내 의사별 내역 조회
			if (isQryDoctor)
			{
				//Doctor Chart 구성
				DisplayDoctorChart(this.gwaCodeList[selectedPoint.AxisLabel].ToString(),selectedPoint.AxisLabel);
			}
		}
		private void chartGwa_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Call Hit Test Method
			HitTestResult result = chartGwa.HitTest( e.X, e.Y );

			// Reset Data Point Attributes
			foreach( DataPoint point in chartGwa.Series[0].Points )
			{
				point.BackGradientEndColor = Color.Black;
				point.BackHatchStyle = ChartHatchStyle.None;
				point.BorderWidth = 1;
			}
			
			// If a Data Point, DataPointLabel or a Legend item is selected.
			if((result.ChartElementType == ChartElementType.DataPoint) ||(result.ChartElementType == ChartElementType.DataPointLabel)
				||(result.ChartElementType == ChartElementType.LegendItem))
			{				
				// Set cursor type 
				this.Cursor = Cursors.Hand;

				// Find selected data point
				DataPoint point = chartGwa.Series[0].Points[result.PointIndex];

				// Set End Gradient Color to White
				point.BackGradientEndColor = Color.Ivory;

				// Set selected hatch style
				point.BackHatchStyle = ChartHatchStyle.Percent50;

				// Increase border width

				point.BorderWidth = 2;
			}
			else
			{
				// Set default cursor
				this.Cursor = Cursors.Default;
			}
		}
		#endregion

		#region DisplayDoctorChart (과내 의사별 진료내역 조회 ,Chart 구성)
		private void DisplayDoctorChart(string gwaCode, string gwaName)
		{
			//기존 Source Null
			this.chartDoctor.DataSource = null;
			//해당과의 의사별 진료현황을 조회하여 의사 Chart 구성
			//Input중 과코드 SET
            this.layDoctorData.SetBindVarValue("f_jundal_gubun", gwaCode);

            if (this.layDoctorData.QueryLayout(true))
			{
				//MAX값은 데이타중에서 제일 큰값으로 조금 마진을 두어 동적으로 설정(DisplayDoctorChart에서 SET)
				int maxValue = 0;
				foreach (DataRow dtRow in this.layDoctorData.LayoutTable.Rows)
				{
					maxValue = Math.Max(maxValue, Int32.Parse(dtRow["TotalCnt"].ToString()));
				}
				//50단위로 Display함
				maxValue = (maxValue/50 + 1) * 50;
				chartDoctor.ChartAreas["Default"].AxisY.Maximum = maxValue;

				//Title은 내과의사별진료현황
				this.chartDoctor.Titles[0].Text = gwaName + "医師別診療状況";
				this.chartDoctor.DataSource = this.layDoctorData.LayoutTable;
				this.chartDoctor.DataBind();
			}
			else
			{
				this.chartDoctor.Titles[0].Text = "医師別診療状況";
				XMessageBox.Show("医師別診療状況照会エラー[" + Service.ErrFullMsg + "]");

			}
		}
		#endregion

		#region OnDoctorRadioCheckedChanged (A.전체, J.진료만, D.약만, T.토탈만 Radio Button Check시)
		private void OnDoctorRadioCheckedChanged(object sender, EventArgs e)
		{
			//Tag에 저장된 A.전체, J.진료만, D.약만, T.토탈에 따라 Series Visible 변경
			RadioButton rbo = (RadioButton) sender;
			string gubun = rbo.Tag.ToString();
			if (rbo.Checked)
			{
				//rbo.Font = this.selectedFont;
				rbo.BackColor = this.selectedBackColor;
				rbo.ForeColor = this.selectedForeColor;

				//DataDisplay 될때만
				if (this.chartDoctor.DataSource == null) return;

				if (gubun == "A")  //전체
				{
					// 전체 Visible
					foreach (Dundas.Charting.WinControl.Series series in this.doctorChartSeriesList.Values)
						series.Enabled = true;
				}
				else
				{
					foreach (string key in this.doctorChartSeriesList.Keys) //Key와 일치하는 것만 Enable, 나머지는 Disable
					{
						Dundas.Charting.WinControl.Series dSeries = doctorChartSeriesList[key] as Series;
						if (key == gubun)
							dSeries.Enabled = true;
						else
							dSeries.Enabled = false;
					}
				}
			}
			else
			{
				//rbo.Font = this.unSelectedFont;
				rbo.BackColor = this.unSelectedBackColor;
				rbo.ForeColor = this.unSelectedForeColor;
			}
		}
		#endregion

		#region 3D로 표시 CheckBox
		private void cbxDoctor3D_CheckedChanged(object sender, System.EventArgs e)
		{
			//의사 Chart 3D로 보여주기
			if (cbxDoctor3D.Checked)
			{
				//DataSource가 없으면 return
				if (chartDoctor.DataSource == null) return;

				chartDoctor.ChartAreas["Default"].Area3DStyle.Enable3D = true;
				//Angle을 조정하여 3D로도 잘보이게 함. XAngle = 30, YAngle = 0
				chartDoctor.ChartAreas["Default"].Area3DStyle.YAngle = 0;
				chartDoctor.ChartAreas["Default"].Area3DStyle.XAngle = 30;
				//Tracker Visible
				tbDoctorX.Value = 30;
				tbDoctorY.Value = 0;
				tbDoctorX.Visible = true;
				tbDoctorY.Visible = true;
				btnDoctorBase.Visible = true;
			}
			else
			{
				chartDoctor.ChartAreas["Default"].Area3DStyle.Enable3D = false;
				tbDoctorX.Visible = false;
				tbDoctorY.Visible = false;
				btnDoctorBase.Visible = false;
			}
		}

		private void cbxGwa3D_CheckedChanged(object sender, System.EventArgs e)
		{
			//2D, 3D 변형
			if (cbxGwa3D.Checked)
			{
				//DataSource가 없으면 return
				if (chartGwa.DataSource == null) return;

				chartGwa.ChartAreas["Default"].Area3DStyle.Enable3D = true;
				//TrackBar visible
				tbGwaX.Visible = true;
				tbGwaY.Visible = true;
				btnGwaBase.Visible = true;
			}
			else
			{
				chartGwa.ChartAreas["Default"].Area3DStyle.Enable3D = false;
				tbGwaX.Visible = false;
				tbGwaY.Visible = false;
				btnGwaBase.Visible = false;
			}
		}
		private void cbxLine3D_CheckedChanged(object sender, System.EventArgs e)
		{
			//2D, 3D 변형
			if (cbxLine3D.Checked)
			{
				//DataSource가 없으면 return
				if (chartLine.DataSource == null) return;

				chartLine.ChartAreas["Default"].Area3DStyle.Enable3D = true;
				//TrackBar visible
				tbLineX.Visible = true;
				tbLineY.Visible = true;
				btnLineBase.Visible = true;
			}
			else
			{
				chartLine.ChartAreas["Default"].Area3DStyle.Enable3D = false;
				//TrackBar visible
				tbLineX.Visible = false;
				tbLineY.Visible = false;
				btnLineBase.Visible = false;
			}
		}
		#endregion

		#region 백분율로 표시 CheckBox
		private void cbxGwa100_CheckedChanged(object sender, System.EventArgs e)
		{
			if (cbxGwa100.Checked)
			{
				//컬럼 Mapping을 환자수로
				chartGwa.Series["SeriesGwa"].ValueMembersY = "Persantage";
				//컬럼 변경 반영 (DataBind)
				chartGwa.DataBind();
			}
			else
			{
				//컬럼 Mapping을 환자수로
				chartGwa.Series["SeriesGwa"].ValueMembersY = "PersonCnt";
				chartGwa.DataBind();
			}
		}

		private void cbxDoctor100_CheckedChanged(object sender, System.EventArgs e)
		{
			//RadioBox를 전체로 선택해서 적용되도록 함.
			this.rbDoctorTotal.Checked = true;

			//백분율로 표시
			if (cbxDoctor100.Checked)
			{
				//전체 Series는 보이지 않게 하고, 나머지 Series
				chartDoctor.Series["全体"].Enabled = false;
				//진료,약만 시리즈는 StackedColumn -> StackedColumn100으로
				chartDoctor.Series["入院"].Type = SeriesChartType.StackedColumn100;
				chartDoctor.Series["外来"].Type = SeriesChartType.StackedColumn100;
			}
			else //환자수 표시
			{
				//전체 Series는 Visible
				chartDoctor.Series["全体"].Enabled = true;
				//진료,약만 시리즈는 StackedColumn100 -> StackedColumn으로
				chartDoctor.Series["入院"].Type = SeriesChartType.StackedColumn;
				chartDoctor.Series["外来"].Type = SeriesChartType.StackedColumn;
			}
		}
		#endregion

		#region TrackBar, 기본값으로 변경 버튼
		private void tbGwaX_ValueChanged(object sender, System.EventArgs e)
		{
			chartGwa.ChartAreas["Default"].Area3DStyle.XAngle = tbGwaX.Value;
		}

		private void tbGwaY_ValueChanged(object sender, System.EventArgs e)
		{
			chartGwa.ChartAreas["Default"].Area3DStyle.YAngle = tbGwaY.Value;
		}

		private void btnGwaBase_Click(object sender, System.EventArgs e)
		{
			//기본 Angle 설정
			tbGwaX.Value = 30;
			tbGwaY.Value = 30;
		}

		private void tbDoctorX_ValueChanged(object sender, System.EventArgs e)
		{
			chartDoctor.ChartAreas["Default"].Area3DStyle.XAngle = tbDoctorX.Value;
		}

		private void tbDoctorY_ValueChanged(object sender, System.EventArgs e)
		{
			chartDoctor.ChartAreas["Default"].Area3DStyle.YAngle = tbDoctorY.Value;
		}

		private void btnDoctorBase_Click(object sender, System.EventArgs e)
		{
			//기본 Angle 설정 (30, 0)
			tbDoctorX.Value = 30;
			tbDoctorY.Value = 0;	
		}
		private void tbLineX_ValueChanged(object sender, System.EventArgs e)
		{
			chartLine.ChartAreas["Default"].Area3DStyle.XAngle = tbLineX.Value;
		}

		private void tbLineY_ValueChanged(object sender, System.EventArgs e)
		{
			chartLine.ChartAreas["Default"].Area3DStyle.YAngle = tbLineY.Value;
		}

		private void btnLineBase_Click(object sender, System.EventArgs e)
		{
			//기본 Angle 설정 (30, 30)
			tbLineX.Value = 30;
			tbLineY.Value = 30;	
		}
		#endregion

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#region 월변경 RadioButton Check Event(해당월을 당월로하여 데이타를 조회하여 Grid Line Set)
		private void OnMonthRadioCheckedChanged(object sender, EventArgs e)
		{
			RadioButton rbo = (RadioButton) sender;
			if (rbo.Checked)
			{
				//rbo.Font = this.selectedFont;
				rbo.BackColor = this.selectedBackColor;
				rbo.ForeColor = this.selectedForeColor;

				//기존 DataSouce Clear
				this.chartLine.DataSource = null;

				//Tag에 저장된 월수 가져옴
				int month = Int32.Parse(rbo.Tag.ToString());

				//시작일(전전월시작일) - 종료일(당월말일)을 Input으로 데이타를 조회하여 lineTable을 구성
				lineTable.Rows.Clear();  //기존 Data Clear
				DateTime thisMonth = DateTime.Parse(this.cboYear.GetDataValue() + "/" + month.ToString("00") + "/01");
				DateTime startDt = thisMonth.AddMonths(-2);
				int daysInMonth = DateTime.DaysInMonth(Int32.Parse(this.cboYear.GetDataValue()), month);
				DateTime endDt   = thisMonth.AddDays(daysInMonth -1);
				DateTime naewonDate = DateTime.Now;
				DataRow dtRow;
				int maxPaCount = 0;  //Max환자수
                //Input Set (start_dt, end_dt)

                this.layMonthData.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.layMonthData.SetBindVarValue("f_start_dt", startDt.ToString("yyyy/MM/dd"));
                this.layMonthData.SetBindVarValue("f_end_dt", endDt.ToString("yyyy/MM/dd"));

				if (this.layMonthData.QueryLayout(true))
				{
					//내월일자가 당월,전월,전전월에 속하는지를 비교하여 DangMonth, JunMonth, JunJunMonth 설정
					//데이타는 전전월부터 조회됨
					foreach (DataRow dataRow in this.layMonthData.LayoutTable.Rows)
					{
						naewonDate = DateTime.Parse(dataRow["NaewonDate"].ToString());
						if (naewonDate.Month == endDt.Month) //당월
						{
							//이미 다른값이 설정되었는지, 아니면 처음 생성되는지 확인하여 새행을 만들지, 기존행에 넣을지를 결정
							if (lineTable.Rows.Count >= naewonDate.Day)
							{
								dtRow = lineTable.Rows[naewonDate.Day -1];  //Index는 0부터 시작하므로 Day -1
								if (TypeCheck.IsInt(dataRow["Count"].ToString()))
								{
									dtRow["DangMonth"] = Int32.Parse(dataRow["Count"].ToString());
									maxPaCount = Math.Max(maxPaCount, (int) dtRow["DangMonth"]);
								}
							}
							else //새행 생성
							{
								dtRow = lineTable.NewRow();
								dtRow["Day"] = naewonDate.Day;
								if (TypeCheck.IsInt(dataRow["Count"].ToString()))
								{
									dtRow["DangMonth"] = Int32.Parse(dataRow["Count"].ToString());
									maxPaCount = Math.Max(maxPaCount, (int) dtRow["DangMonth"]);
								}
								lineTable.Rows.Add(dtRow);
							}
						}
						else if (naewonDate.Month == startDt.Month)  //전전월
						{
							//이미 다른값이 설정되었는지, 아니면 처음 생성되는지 확인하여 새행을 만들지, 기존행에 넣을지를 결정
							if (lineTable.Rows.Count >= naewonDate.Day)
							{
								dtRow = lineTable.Rows[naewonDate.Day -1];  //Index는 0부터 시작하므로 Day -1
								if (TypeCheck.IsInt(dataRow["Count"].ToString()))
								{
									dtRow["JunJunMonth"] = Int32.Parse(dataRow["Count"].ToString());
									maxPaCount = Math.Max(maxPaCount, (int) dtRow["JunJunMonth"]);
								}
							}
							else //새행 생성
							{
								dtRow = lineTable.NewRow();
								dtRow["Day"] = naewonDate.Day;
								if (TypeCheck.IsInt(dataRow["Count"].ToString()))
								{
									dtRow["JunJunMonth"] = Int32.Parse(dataRow["Count"].ToString());
									maxPaCount = Math.Max(maxPaCount, (int) dtRow["JunJunMonth"]);
								}
								lineTable.Rows.Add(dtRow);
							}
						}
						else //전월
						{
							//이미 다른값이 설정되었는지, 아니면 처음 생성되는지 확인하여 새행을 만들지, 기존행에 넣을지를 결정
							if (lineTable.Rows.Count >= naewonDate.Day)
							{
								dtRow = lineTable.Rows[naewonDate.Day -1];  //Index는 0부터 시작하므로 Day -1
								if (TypeCheck.IsInt(dataRow["Count"].ToString()))
								{
									dtRow["JunMonth"] = Int32.Parse(dataRow["Count"].ToString());
									maxPaCount = Math.Max(maxPaCount, (int) dtRow["JunMonth"]);
								}
							}
							else //새행 생성
							{
								dtRow = lineTable.NewRow();
								dtRow["Day"] = naewonDate.Day;
								if (TypeCheck.IsInt(dataRow["Count"].ToString()))
								{
									dtRow["JunMonth"] = Int32.Parse(dataRow["Count"].ToString());
									maxPaCount = Math.Max(maxPaCount, (int) dtRow["JunMonth"]);
								}
								lineTable.Rows.Add(dtRow);
							}
						}
					}
					lineTable.AcceptChanges();

					try
					{
						//값을 조회하여 MAX값보다 조금 크게 마진 적용하여 설정해야함(50단위)
						maxPaCount = (maxPaCount/50 + 1) * 50;
						chartLine.ChartAreas["Default"].AxisY.Maximum = maxPaCount;
						this.chartLine.DataSource = lineTable;
						this.chartLine.DataBind();
					}
					catch
					{
					}
				}
				else
				{
					XMessageBox.Show("日別患者数照会エラー[" + Service.ErrMsg + "]");
				}
			}
			else
			{
				//rbo.Font = this.unSelectedFont;
				rbo.BackColor = this.unSelectedBackColor;
				rbo.ForeColor = this.unSelectedForeColor;
			}
		}
		#endregion

		#region Line 차트의 Radio 버튼 체크 변경시( 선택한 월만 Display)
		private void OnLineRadioCheckedChanged(object sender, System.EventArgs e)
		{
			//Tag에 저장된 A.전체, T.당월만, P.전월만, N.전전월에 따라 Series Visible 변경
			RadioButton rbo = (RadioButton) sender;
			string gubun = rbo.Tag.ToString();
			if (rbo.Checked)
			{
				//rbo.Font = this.selectedFont;
				rbo.BackColor = this.selectedBackColor;
				rbo.ForeColor = this.selectedForeColor;

				//DataDisplay 될때만
				if (this.chartLine.DataSource == null) return;

				if (gubun == "A")  //전체
				{
					// 전체 Visible
					foreach (Dundas.Charting.WinControl.Series series in this.lineChartSeriesList.Values)
					{
						series.Enabled = true;
						//PointLabel Visible false
						series.ShowLabelAsValue = false;
					}
				}
				else
				{
					foreach (string key in this.lineChartSeriesList.Keys) //Key와 일치하는 것만 Enable, 나머지는 Disable
					{
						Dundas.Charting.WinControl.Series dSeries = lineChartSeriesList[key] as Series;
						if (key == gubun)
						{
							dSeries.Enabled = true;
							//PointLabel Visible true
							dSeries.ShowLabelAsValue = true;
						}
						else
						{
							dSeries.Enabled = false;
							//PointLabel Visible false
							dSeries.ShowLabelAsValue = false;
						}
					}

					Dundas.Charting.WinControl.Series currSeries = lineChartSeriesList["T"] as Series;

					currSeries.Enabled = true;
					currSeries.ShowLabelAsValue = true;
				}
			}
			else
			{
				//rbo.Font = this.unSelectedFont;
				rbo.BackColor = this.unSelectedBackColor;
				rbo.ForeColor = this.unSelectedForeColor;
			}
		}
		#endregion

		#region Line 차트 높이 조정
		private bool isUpLineChart = true;  
		private void btnUpDown_Click(object sender, System.EventArgs e)
		{
			if (isUpLineChart)  //위로 올리면 pnlBottom의 높이 550, 낮추면 300
			{
				this.pnlBottom.Height = 550;
				this.btnUpDown.ImageIndex = 1;  //Down Image
			}
			else
			{
				this.pnlBottom.Height = 300;
				this.btnUpDown.ImageIndex = 0;  //Up Image
			}
			this.isUpLineChart = !this.isUpLineChart;
		}
		#endregion

		#region ClearChartDoctor

		private void ClearChartDoctor()
		{
			chartDoctor.Titles[0].Text = "【 医師別診療状況 】";
			this.layDoctorData.Reset();
			this.chartDoctor.DataSource = this.layDoctorData.LayoutTable;
			this.chartDoctor.DataBind();
			this.chartDoctor.Invalidate();
		}

		#endregion

		private void cboYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//년도 변경시에 현재선택된 Radio가 있으면 내역 다시 조회
			RadioButton selectedRbo = null;
			foreach (RadioButton rbo in this.monthRadioList.Values)
			{
				if (rbo.Checked)
				{
					selectedRbo = rbo;
					break;
				}
			}
			if (selectedRbo != null)
				this.OnMonthRadioCheckedChanged(selectedRbo, EventArgs.Empty);
		}

		private void calendar_DayClick(object sender, IHIS.Framework.XCalendarDayClickEventArgs e)
		{
			//달력 Click시에 Click된 날짜의 데이타를 조회하고 칼렌다 감춤
			this.selectedDate = e.DateItem.Date;
			this.dbxToday.SetDataValue(selectedDate);  //선택일 Display
			
			//과 차트 Display
			this.DisplayGwaChart();
			//<미해결> 일단 내과기준으로 조회하여 설정함
			this.DisplayDoctorChart("01", "生化学");

			this.calendar.Visible = false;			
		}

		private void calendar_MouseLeave(object sender, System.EventArgs e)
		{
			this.calendar.Visible = false;
		}

		private void lbCalendar_MouseEnter(object sender, System.EventArgs e)
		{
			//Mouse가 칼렌다에 가면 Calendar visible change
			if (!this.calendar.Visible)
				this.calendar.Visible = true;
			else
				this.calendar.Visible = false;
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//다시 조회
			//의사 Calendar Clear
			this.chartDoctor.DataSource = null;
			this.chartDoctor.DataBind();
			//과 차트 Display
			this.DisplayGwaChart();
			//<미해결> 일단 내과기준으로 조회하여 설정함 (기존 닥터 Chart가 화면이 Clear안됨)
			this.DisplayDoctorChart("01", "生化学");
			this.calendar.Visible = false;
			
			//현재선택된 Radio가 있으면 내역 다시 조회
			RadioButton selectedRbo = null;
			foreach (RadioButton rbo in this.monthRadioList.Values)
			{
				if (rbo.Checked)
				{
					selectedRbo = rbo;
					break;
				}
			}
			if (selectedRbo != null)
				this.OnMonthRadioCheckedChanged(selectedRbo, EventArgs.Empty);
		}

		private void CPL2010Q05_Activated(object sender, System.EventArgs e)
		{
			this.btnQuery.PerformClick();
		}

        private void layTotalCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTotalCnt.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layTotalCnt.SetBindVarValue("f_part_jubsu_date", this.SelectedDate);
        }

        private void layGwaData_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGwaData.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGwaData.SetBindVarValue("f_part_jubsu_date", this.SelectedDate);
        }

        private void layJundalPart_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layJundalPart.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void layDoctorData_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDoctorData.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDoctorData.SetBindVarValue("f_part_jubsu_date", this.SelectedDate);
        }

	}
}

