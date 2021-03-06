using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design; 
using System.Drawing.Drawing2D;
using System.Drawing.Printing; 
using System.Windows.Forms;
using System.Windows.Forms.Design; 
using System.Runtime.Serialization;
using System.Globalization;
using System.Threading;
using System.Diagnostics;

namespace IHIS.Framework
{
	/// <summary>
	/// XCalendar에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(true)]
	[DesignerAttribute(typeof(XCalendarDesigner))]
	[ToolboxBitmap(typeof(IHIS.Framework.XCalendar), "Images.XCalendar.bmp")]
	public class XCalendar : System.Windows.Forms.Control, System.ComponentModel.ISupportInitialize
	{
		#region Class members
		private XColor borderColor = XColor.XCalendarBorderColor;
				
		private XCalendarWeekDay calendarWeekDay;
		private XCalendarMonth calendarMonth;
		private XCalendarFooter calendarFooter;
		private XCalendarRegion activeRegion = XCalendarRegion.None;
		private XCalendarHeader calendarHeader;
		private bool showTrailingDates = true;
		private bool selectTrailingDates = false;
		private ImageList imageList = null;
		private XCalendarDateCollection calendarDates ;
		private ButtonBorderStyle borderStyle = ButtonBorderStyle.Solid;
		private DateTime minimumDate;
		private DateTime maximumDate;
		private bool fullHolidaySelectable = false;  //Full공휴일(일요일포함) 선택가능여부
		private bool halfHolidaySelectable = true;   //반공휴일 선택가능여부
		private bool isJapanYearType = false;   //Header와 Footer의 달, 날짜를 일본와력형식으로 보여줄지 여부
		
		private PrintDocument printDoc = new PrintDocument(); 
			
		/* 헤더,Footer, Month의 영역관리 */
		private Rectangle weekDaysRect = Rectangle.Empty;
		private Rectangle monthRect = Rectangle.Empty;
		private Rectangle footerRect = Rectangle.Empty;
		private Rectangle headerRect = Rectangle.Empty;
		

		
		private bool enableMultiSelection = true;
		private bool showFooter = true;
		private bool showWeekDays = true;
		private bool showHeader = true;
		private bool reDraw = true;  // 속성설정간 그리기를 멈출지 여부 
		private bool toggleSelection = false; //여러개의 선택을 Ctrl을 누르지 않고 선택가능하게 하는 Option
		
		private XCalendarActiveMonth activeMonth;

		private Point mouseLocation;
		private MouseButtons mouseButton;

		#endregion

		#region Properties
		
		internal XCalendarRegion ActiveRegion
		{
			get {  return activeRegion;	}
			set
			{
				if (value !=  activeRegion)
				{
					// raise OnLeave event...
					switch (activeRegion)
					{
						case XCalendarRegion.None:
						case XCalendarRegion.Month:
						case XCalendarRegion.Day:
						{
							break;
						}
						case XCalendarRegion.Header:
						{
							OnHeaderMouseLeave(EventArgs.Empty);
							break;
						}
						case XCalendarRegion.Weekdays:
						{
							OnWeekDayMouseLeave(EventArgs.Empty);
							break;
						}
						case XCalendarRegion.Footer:
						{
							OnFooterMouseLeave(EventArgs.Empty);
							break;
						}
					}
					activeRegion = value;
					// Raise onEnter event...
					switch (activeRegion)
					{
						case XCalendarRegion.None:
						case XCalendarRegion.Month:
						case XCalendarRegion.Day:
						{
							break;
						}
						case XCalendarRegion.Header:
						{
							OnFooterMouseEnter(EventArgs.Empty);
							break;
						}
						case XCalendarRegion.Weekdays:
						{
							OnWeekDayMouseEnter(EventArgs.Empty);
							break;
						}
						case XCalendarRegion.Footer:
						{
							OnFooterMouseEnter(EventArgs.Empty);
							break;
						}
					}
				}
			}
		}

		[Description("Trailing Dates(다음달,전달의 날짜)를 보여줄지 여부를 지정합니다.")]
		[Category("동작")]
		[DefaultValue(true)]
		public bool ShowTrailingDates
		{
			get	{ return showTrailingDates;	}
			set
			{
				if (showTrailingDates!=value)
				{
					showTrailingDates = value;
					if (value == false)
						SelectTrailingDates = false; 
					Invalidate();			
				}
			}
		}
				
		[Category("동작")]
		[DefaultValue(null)]
		[Description("날짜의 내용을 관리하는 XCalendarDate 객체를 관리하는 Collection을 지정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] 
		[Editor(typeof(XCalendarDateCollectionEditor), typeof(UITypeEditor))]
		public XCalendarDateCollection Dates
		{
			get
			{
				return this.calendarDates;
			}
			set
			{
				if (value!=calendarDates)
				{
					calendarDates = value;
					Invalidate();
				}
			}
		}
		
//		[Browsable(true)]
//		[Category("동작")]
//		[Description("Mouse 이동시에 Focus를 받은 Date를 표시할지 여부를 지정합니다.")]
//		[DefaultValue(true)]
//		public bool ShowFocus
//		{
//			get { return showFocus;}
//			set
//			{
//				if (value != showFocus)
//				{
//					showFocus = value;
//					Invalidate();
//				}
//			}
//		}


		[Browsable(true)]
		[Category("동작")]
		[Description("Trailing Dates가 선택가능한지 여부를 지정합니다.")]
		[DefaultValue(true)]
		public bool SelectTrailingDates
		{
			get { return selectTrailingDates; }
			set
			{
				if (value!=selectTrailingDates)
				{
					selectTrailingDates = value;
					Invalidate();
				}
			}
		}

		[Browsable(true)]
		[Category("모양")]
		[DefaultValue(null)]
		[Description("달력의 ImageList를 지정합니다.")]
		public ImageList ImageList
		{
			get { return imageList;	}
			set
			{
				if (value!=imageList)
				{
					imageList = value;
					Invalidate();
				}
			}
		}

		[Browsable(true)]
		[Category("동작")]
		[Description("Multi Selection이 가능한지 여부를 지정합니다.")]
		[DefaultValue(true)]
		public bool EnableMultiSelection
		{
			get { return enableMultiSelection;}
			set { enableMultiSelection = value;}
		}
		[Browsable(true)]
		[Category("동작")]
		[Description("Multi선택이 가능할때 Ctrl, Shift Key를 누르지 않고 선택가능한지 여부를 지정합니다.")]
		[DefaultValue(false)]
		public bool ToggleSelection
		{
			get { return toggleSelection; }
			set { toggleSelection = value;}
		}
		[Browsable(true)]
		[Category("동작")]
		[Description("Full 공휴일(일요일포함)을 선택가능한지를 지정합니다.")]
		[DefaultValue(false)]
		public bool FullHolidaySelectable
		{
			get { return fullHolidaySelectable;}
			set { fullHolidaySelectable = value;}
		}
		[Browsable(true)]
		[Category("동작")]
		[Description("반공휴일(Half 휴일)을 선택가능한지를 지정합니다.")]
		[DefaultValue(true)]
		public bool HalfHolidaySelectable
		{
			get { return halfHolidaySelectable;}
			set { halfHolidaySelectable = value;}
		}
		[Browsable(true)]
		[Category("동작")]
		[Description("달력에 표시될 Minimum Date를 지정합니다.")]
		public DateTime MinDate
		{
			get { return minimumDate;}
			set 
			{
				if ((minimumDate != value) && (value <= maximumDate))
					minimumDate = value;
			}
		}

		[Browsable(true)]
		[Category("동작")]
		[Description("달력에 표시될 Maximum Date를 지정합니다.")]
		public DateTime MaxDate
		{
			get { return maximumDate;}
			set 
			{
				if ((maximumDate != value) && (value >= minimumDate))
					maximumDate = value;
			}
		}
		
		[Browsable(true)]
		[Category("모양")]
		[Description("달력의 Header의 모양을 지정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public XCalendarHeader Header
		{
			get	{ return calendarHeader;}
		}
		
		[Browsable(true)]
		[Category("모양")]
		[Description("달력의 WeekDays(요일표시) 모양을 지정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public XCalendarWeekDay WeekDays
		{
			get { return calendarWeekDay; }
		}

		[Browsable(false)]
		public string CurrentMonth
		{
			get { return activeMonth.Year.ToString("0000") + "/" + activeMonth.Month.ToString("00");}
		}
		[Browsable(true)]
		[Category("모양")]
		[Description("달력의 월 영역의 모양을 지정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public XCalendarMonth Month
		{
			get { return calendarMonth;}
		}

		[Browsable(true)]
		[Category("모양")]
		[Description("달력의 Footer 영역의 모양을 지정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public XCalendarFooter Footer
		{
			get	{ return calendarFooter;}
		}
		
		[Browsable(true)]
		[Category("모양")]
		[Description("달력의 BorderStyle을 지정합니다.")]
		[DefaultValue(ButtonBorderStyle.Solid)]
		public ButtonBorderStyle BorderStyle
		{
			get { return borderStyle;}
			set
			{
				if (value!=borderStyle)
				{
					borderStyle = value;
					Invalidate();
				}
			}
		}
		
		[Browsable(true)]
		[Category("모양")]
		[Description("달력의 Border 색을 지정합니다.")]
		[DefaultValue(typeof(XColor),"XCalendarBorderColor")]
		public XColor BorderColor
		{
			get { return borderColor; }
			set
			{
				if (value != borderColor)
				{
					borderColor = value;
					Invalidate();
				}

			}
		}
	
		
		[Browsable(true)]
		[Category("모양")]
		[Description("Footer 영역을 보여줄지 여부를 지정합니다.")]
		[DefaultValue(true)]
		public bool ShowFooter
		{
			get { return showFooter; }
			set
			{
				if (value != showFooter)
				{
					showFooter = value;
					DoLayout();
					Invalidate();
				}

			}
		}
		[Browsable(true)]
		[Category("모양")]
		[Description("Header 영역을 보여줄지 여부를 지정합니다.")]
		[DefaultValue(true)]
		public bool ShowHeader
		{
			get { return showHeader; }
			set
			{
				if (value != showHeader)
				{
					showHeader = value;
					DoLayout();
					Invalidate();
				}

			}
		}
		[Browsable(true)]
		[Category("모양")]
		[Description("WeekDay 영역을 보여줄지 여부를 지정합니다.")]
		[DefaultValue(true)]
		public bool ShowWeekDays
		{
			get { return showWeekDays; }
			set
			{
				if (value != showWeekDays)
				{
					showWeekDays = value;
					DoLayout();
					Invalidate();
				}

			}
		}
		[Browsable(true)]
		[Category("모양")]
		[Description("헤더의 현재달, Footer의 오늘날짜를 일본와력형식으로 보여줄지 여부를 지정합니다.")]
		[DefaultValue(false)]
		public bool IsJapanYearType
		{
			get { return isJapanYearType; }
			set
			{
				if (isJapanYearType != value)
				{
					isJapanYearType = value;
					Invalidate();
				}

			}
		}
		/// <summary>
		/// Grid을 다시 그릴지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Redraw
		{
			get{return this.reDraw;}
			set
			{
				reDraw = value;
				if (reDraw)
					Invalidate(true);
			}
		}
		/// <summary>
		/// 현재 선택된 날짜(DateTime형)의 리스트를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public XDateItemCollection SelectedDays
		{
			get { return calendarMonth.SelectedDays;}
		}
		
		/// <summary>
		/// 달력에서 Display되는 시작일을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public DateTime DisplayStartDate
		{
			get { return calendarMonth.DisplayStartDate;}
		}
		/// <summary>
		/// 달력에서 Display되는 종료일을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public DateTime DisplayEndDate
		{
			get { return calendarMonth.DisplayEndDate;}
		}
		#endregion

		#region Base Properties Not Browse
		// obsolete properties

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		//[ObsoleteAttribute("This property is not supported",true)]
		public override Image BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}
		
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		//[ObsoleteAttribute("This property is not supported",true)]
		public override RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
			set
			{
				base.RightToLeft = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		//[ObsoleteAttribute("This property is not supported",true)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		//[ObsoleteAttribute("This property is not supported",true)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}
		
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		//[ObsoleteAttribute("This property is not supported",true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}
		
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		//[ObsoleteAttribute("This property is not supported",true)]
        public override Color ForeColor
        {
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		#endregion

		#region Events
		[Browsable(true)]
		[Description("달력의 달이 바뀌었을때 발생하는 Event입니다.")]
		[Category("추가이벤트")]
		public event XCalendarMonthChangedEventHandler MonthChanged;

		[Browsable(true)]
		[Description("달력의 Day영역을 Click했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarDayClickEventHandler DayClick;

		[Browsable(true)]
		[Description("달력의 Day영역을 DoubleClick했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarDayClickEventHandler DayDoubleClick;

		[Browsable(true)]
		[Description("달력의 Header 영역을 Click했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarClickEventHandler HeaderClick;

		[Browsable(true)]
		[Description("달력의 Header 영역을 DoubleClick했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarClickEventHandler HeaderDoubleClick;

		[Browsable(true)]
		[Description("달력의 Footer 영역을 Click했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarClickEventHandler FooterClick;

		[Browsable(true)]
		[Description("달력의 Footer 영역을 DoubleClick했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarClickEventHandler FooterDoubleClick;

		[Browsable(true)]
		[Description("달력의 날(One-More)이 선택되었을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarDaySelectedEventHandler DaySelected;
		[Browsable(true)]
		[Description("달력의 날(One-More)이 선택해제되었을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarDaySelectedEventHandler DayDeSelected;

		[Browsable(true)]
		[Description("달력의 날짜가 Focus를 잃었을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarDayEventHandler DayLostFocus;
		[Browsable(true)]
		[Description("달력의 날짜가 Focus를 가졌을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarDayEventHandler DayGotFocus;

		[Browsable(true)]
		[Description("달력의 WeekDay영역을 Click했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarWeekDayClickEventHandler WeekDayClick;
		[Browsable(true)]
		[Description("달력의 WeekDay영역을 Double Click했을때 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event XCalendarWeekDayClickEventHandler WeekDayDoubleClick;

		[Browsable(true)]
		[Description("달력의 마우스 포인터가 Footer영역에 들어가면 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event EventHandler FooterMouseEnter;

		[Browsable(true)]
		[Description("달력의 마우스 포인터가 Footer영역을 벗어나면 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event EventHandler FooterMouseLeave;

		[Browsable(true)]
		[Description("달력의 마우스 포인터가 Header영역에 들어가면 발생하는 이벤트입니다")]
		[Category("추가이벤트")]
		public event EventHandler HeaderMouseEnter;

		[Browsable(true)]
		[Description("달력의 마우스 포인터가 Header영역을 벗어나면 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event EventHandler HeaderMouseLeave;

		[Browsable(true)]
		[Description("달력의 마우스 포인터가 Weekday영역에 들어가면 발생하는 이벤트입니다")]
		[Category("추가이벤트")]
		public event EventHandler WeekDayMouseEnter;

		[Browsable(true)]
		[Description("달력의 마우스 포인터가 Weekday영역을 벗어나면 발생하는 이벤트입니다.")]
		[Category("추가이벤트")]
		public event EventHandler WeekDayMouseLeave;

		[Browsable(true)]
		[Description("달력에서 날짜를 DragDrop할때 발생하는 Event입니다.")]
		[Category("추가이벤트")]
		public event XCalendarDayDragDropEventHandler DayDragDrop;
		#endregion
		
		#region 생성자

		public XCalendar()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			
			//initiate rectangles	
			calendarWeekDay	= new XCalendarWeekDay(this);
			calendarMonth	= new XCalendarMonth(this);
			calendarFooter	= new XCalendarFooter(this);
			calendarHeader	= new XCalendarHeader(this);
 			calendarDates	= new XCalendarDateCollection(this);
			
			activeMonth		= new XCalendarActiveMonth(this);
			
			// setup internal events
			calendarMonth.DayLostFocus		+= new XCalendarDayEventHandler(OnMonthDayLostFocus); 
			calendarMonth.DayGotFocus		+= new XCalendarDayEventHandler(OnMonthDayGotFocus);	
			calendarMonth.DayClick			+= new XCalendarDayClickEventHandler(OnMonthDayClick);
			calendarMonth.DayDoubleClick	+= new XCalendarDayClickEventHandler(OnMonthDayDoubleClick);	
			calendarMonth.DaySelected		+= new XCalendarDaySelectedEventHandler(OnMonthDaySelected); 
			calendarMonth.DayDeSelected		+= new XCalendarDaySelectedEventHandler(OnMonthDayDeSelected); 
			
			calendarFooter.Click			+= new XCalendarClickEventHandler(OnFooterClick);	
			calendarFooter.DoubleClick		+= new XCalendarClickEventHandler(OnFooterDoubleClick);
			
			calendarWeekDay.Click			+= new XCalendarWeekDayClickEventHandler(OnWeekDayClick); 	
			calendarWeekDay.DoubleClick		+= new XCalendarWeekDayClickEventHandler(OnWeekDayDoubleClick);		
			
			calendarHeader.Click			+= new XCalendarClickEventHandler(OnHeaderClick);	
			calendarHeader.DoubleClick		+= new XCalendarClickEventHandler(OnHeaderDoubleClick);	
			calendarHeader.PrevButtonClick	+= new EventHandler(OnHeaderPrevButtonClick);		
			calendarHeader.NextButtonClick	+= new EventHandler(OnHeaderNextButtonClick); 		
			
			activeMonth.MonthChanged		+= new XCalendarMonthChangedEventHandler(OnActiveMonthChanged); 
			
			printDoc.BeginPrint			+= new PrintEventHandler(OnPrintDocBeginPrint); 
			printDoc.PrintPage			+= new PrintPageEventHandler(OnPrintDocPrintPage);
			printDoc.QueryPageSettings	+= new QueryPageSettingsEventHandler(OnPrintDocQueryPageSettings); 
			printDoc.DocumentName = "XCalendar"; 

			showFooter = true;
			showHeader = true;
			showWeekDays = true;
						
			enableMultiSelection = true;
			selectTrailingDates = true;
	
			minimumDate = DateTime.Today.AddYears(-10);
			maximumDate = DateTime.Today.AddYears(10);

			//초기값 설정 (Runtime시 Service를 Call하지 않게 하기 위해 SetYearMonth 사용)
			activeMonth.SetYearMonth(DateTime.Today.Year, DateTime.Today.Month);
			
			calendarMonth.SelectedMonth = DateTime.Parse(activeMonth.Year+"-"+activeMonth.Month+"-01");

			//날짜 Setup
			Setup(false);
						
		}

		#endregion
		
		#region Dispose

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				
				// delete internal events
				activeMonth.MonthChanged	-= new XCalendarMonthChangedEventHandler(OnActiveMonthChanged); 
				
				calendarMonth.DayLostFocus		-= new XCalendarDayEventHandler(OnMonthDayLostFocus); 
				calendarMonth.DayGotFocus		-= new XCalendarDayEventHandler(OnMonthDayGotFocus);	
				calendarMonth.DayClick			-= new XCalendarDayClickEventHandler(OnMonthDayClick);
				calendarMonth.DayDoubleClick	-= new XCalendarDayClickEventHandler(OnMonthDayDoubleClick);	
				calendarMonth.DaySelected		-= new XCalendarDaySelectedEventHandler(OnMonthDaySelected);
				calendarMonth.DayDeSelected		-= new XCalendarDaySelectedEventHandler(OnMonthDayDeSelected);

				calendarFooter.Click			-= new XCalendarClickEventHandler(OnFooterClick);	
				calendarFooter.DoubleClick		-= new XCalendarClickEventHandler(OnFooterDoubleClick);
				
				calendarWeekDay.Click			-= new XCalendarWeekDayClickEventHandler(OnWeekDayClick); 	
				calendarWeekDay.DoubleClick		-= new XCalendarWeekDayClickEventHandler(OnWeekDayDoubleClick);		
				
				calendarHeader.Click			-= new XCalendarClickEventHandler(OnHeaderClick);	
				calendarHeader.DoubleClick		-= new XCalendarClickEventHandler(OnHeaderDoubleClick);	
				calendarHeader.PrevButtonClick	-= new EventHandler(OnHeaderPrevButtonClick);		
				calendarHeader.NextButtonClick	-= new EventHandler(OnHeaderNextButtonClick); 		
				
				printDoc.BeginPrint				-= new PrintEventHandler(OnPrintDocBeginPrint); 
				printDoc.PrintPage				-= new PrintPageEventHandler(OnPrintDocPrintPage);
				printDoc.QueryPageSettings		-= new QueryPageSettingsEventHandler(OnPrintDocQueryPageSettings); 

				printDoc.Dispose();
				calendarHeader.Dispose();
				calendarWeekDay.Dispose();
				calendarMonth.Dispose();
				calendarFooter.Dispose();

			}
			base.Dispose( disposing );
		}

		#endregion
				
		#region Public Methods
		/// <summary>
		/// 선택날짜를 해제합니다.
		/// </summary>
		public void UnSelectAll()
		{
			calendarMonth.RemoveSelect(true); 
			Invalidate();
		}
		public void UnSelectDate(DateTime date)
		{
			calendarMonth.UnSelectDate(date);
			Invalidate();
		}
		public void SelectDate(DateTime date)
		{
			if ((date >= minimumDate) && (date<=maximumDate))    
				calendarMonth.SelectDate(date);
		}

		public bool IsSelectedDate(DateTime date)
		{
			return calendarMonth.IsSelectedDate(date);
		}
		/// <summary>
		/// 현재 달력의 모양을 Image로 Return합니다.
		/// </summary>
		/// <returns></returns>
		public Bitmap Snapshot()
		{
							
			Graphics e = this.CreateGraphics();   
			// Create a new bitmap
			Bitmap bmp = new Bitmap(this.Width,this.Height,e);
			// Create a graphics context connected to the bitmap
			e = Graphics.FromImage(bmp);
			// Draw the calendar on the bitmap
			Draw(e);
			
			e.Dispose();
			return bmp;
		}
		/// <summary>
		/// 현재 달력모양을 Print합니다.
		/// </summary>
		public void Print()
		{
			try
			{
				printDoc.Print();  	
			}
			catch (Exception)
			{

			}

		}

		public void AddCalendarDates(XCalendarDate[] items)
		{
			for (int i =0;i < items.Length;i++)
			{
				if (items[i]!=null)
					Dates.Add(items[i]);
			}
			Invalidate();
		}

		public void RemoveCalendarDate(DateTime date)
		{
			for (int i = 0;i< Dates.Count;i++)
			{
				if (Dates[i].Date.ToShortDateString() == date.ToShortDateString())
				{
					Dates.RemoveAt(i);
					break;
				}
			}
			Invalidate();
		}

		public void AddCalendarDate(XCalendarDate item)
		{
			Dates.Add(item);
			Invalidate();
		}

		public void ResetCalendarDates()
		{
			Dates.Clear();
			Invalidate();
		}

		public XCalendarDate[] GetCalendarDates()
		{
			XCalendarDate[] ret = new XCalendarDate[0];
			ret.Initialize(); 
			for (int i = 0;i<Dates.Count;i++)
			{
				ret = AddItem(Dates[i],ret);
			}
			return ret;
		}

		public XCalendarDate GetCalendarDate(DateTime date)
		{
			XCalendarDate ret = null;
			for (int i = 0;i<Dates.Count;i++)
			{
				if (Dates[i].Date.ToShortDateString() == date.ToShortDateString())
				{
					ret = Dates[i];
					break;
				}
			}
			return ret;
		}
		public void SetActiveMonth(int year, int month)
		{
			DateTime dt = DateTime.Today;
			try
			{
				dt = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-01");
			}
			catch
			{
				return;
			}
			if ((dt >= minimumDate) && (dt <= maximumDate)) 
			{
				//년,월이 둘다 다르면 Month 설정후 Year 설정시 Flag SET
				if ((this.activeMonth.Year != year) && (this.activeMonth.Month != month))
				{
					this.activeMonth.IsCallMonthChanged = false;
					this.activeMonth.Month = month;
					this.activeMonth.IsCallMonthChanged = true;  //Year설정시에 MonthChanged Event Call
					this.activeMonth.Year = year;
				}
				else
				{
					this.activeMonth.Month = month;
					this.activeMonth.Year = year;
				}
			}
		}
		public XDateItem GetDateItem(DateTime date)
		{
			//해당일에 속하는 XDateItem을 Return
			date = DateTime.Parse(date.ToShortDateString());
			foreach (XCalendarDay dayItem in this.calendarMonth.CalendarDays)
			{
				if (dayItem.DateItem.Date == date)
					return dayItem.DateItem;
			}
			return null;


		}
		/// <summary>
		/// 현재 MousePoint가 있는 Date를 가져옵니다.(없으면 DateTime.MinValue return)
		/// </summary>
		/// <param name="mouseLocation"></param>
		/// <returns></returns>
		public DateTime GetHitDate(Point mouseLocation)
		{
			return calendarMonth.GetDate(mouseLocation);
		}
		public XDateItem GetHitDateItem(Point mouseLocation)
		{
			return calendarMonth.GetDateItem(mouseLocation);
		}
		/// <summary>
		/// 현재 MousePoint가 있는 XCalendarDate를 가져옵니다.(없으면 null)
		/// </summary>
		/// <param name="mouseLocation"></param>
		/// <returns></returns>
		public XCalendarDate GetHitCalendarDate(Point mouseLocation)
		{
			return Dates[calendarMonth.GetDate(mouseLocation)];
		}
		/// <summary>
		/// 선택된 날짜에 있는 XCalendarDate의 Array를 Return 합니다.
		/// </summary>
		/// <returns></returns>
		public XCalendarDate[] GetSelectedCalendarDate()
		{
			ArrayList list = new ArrayList();
			
			foreach (DateTime dt in this.SelectedDays)
			{
				if (Dates[dt] != null)
					list.Add(Dates[dt]);
			}
			XCalendarDate[] dateItems = new XCalendarDate[list.Count];
			int index = 0;
			foreach (XCalendarDate item in list)
			{
				dateItems[index] = item;
				index++;
			}
			return dateItems;
		}
		#endregion

		#region Private Methods
		
		private void Draw(Graphics e)
		{
			//Draw시에 전체를 다시 그리지 않고, Clip영역에 속하는 것만 다시 그리도록 IsVisible 판단 추가
			if (ShowHeader && e.IsVisible(this.headerRect))
			{
				calendarHeader.Draw(e);
			}
			if (ShowWeekDays && e.IsVisible(this.weekDaysRect)) 
			{
				calendarWeekDay.Draw(e);
			}
			if (ShowFooter && e.IsVisible(this.footerRect)) 
			{
				calendarFooter.Draw(e);	
			}
			if (e.IsVisible(this.monthRect))
			{
				calendarMonth.Draw(e);
			}

			// Draw border
			ControlPaint.DrawBorder(e,this.ClientRectangle, this.BorderColor.Color, this.BorderStyle);  
			
		}

		private XCalendarDate[] AddItem(XCalendarDate dt, XCalendarDate[] old)
		{
			int l =  old.Length;
			int i;
			XCalendarDate[] n = new XCalendarDate[l+1];
			n.Initialize(); 
			for (i = 0;i<l;i++)
			{
				n[i] = old[i];
			}
			n[i] = dt;
			return n;
		}


		internal void Setup()
		{
			Setup(true);
//			calendarMonth.Setup();
//			//RunTime시에 법정공휴일 설정
//			if (!this.DesignMode)
//				this.SetLegalHolidays();
		}
		private void Setup(bool callService)
		{
			calendarMonth.Setup();

			if (!callService) return;

			//RunTime시에 법정공휴일 설정
			if (!this.DesignMode)
				this.SetLegalHolidays();
		}

		internal string[] AllowedMonths()
		{
			string[] monthList = new string[12];
			
			monthList.Initialize();
 						
			for (int i = 0;i<12;i++)
				monthList[i] = DateTimeFormatInfo.CurrentInfo.MonthNames[i];
					
			return monthList;
		
		}
		
		internal bool IsYearValid(string y)
		{
			string[] years = AllowedYears();
			bool ret = false;
			for(int i = 0;i<years.Length;i++)
			{
				if (y == years[i])
					ret = true;
			}
			return ret;
		}

		internal int MonthNumber(string m)
		{
			int ret = -1;
			string[] months;
			months = AllowedMonths();

			for (int i = 0;i<months.Length;i++)
			{
				if (m.ToLower()  == months[i].ToLower())
					return i+1;
			}
			if ((Convert.ToInt32(m)>=1) && (Convert.ToInt32(m)<=12))
			{
				ret = Convert.ToInt32(m);
			}
			return ret;
		}

		internal string MonthName(int m)
		{
			string[] validNames;
			string name = "";
			validNames = AllowedMonths();
			if ((m >=1) && (m <=12))  
			{
				name = validNames[m-1]; 
			}
			return name;
		}

		internal string[] AllowedYears()
		{
			
			string[] yearList = new string[(maximumDate.Year-minimumDate.Year)+1];
			
			yearList.Initialize();
 
			int year;
			
			year = 0;
			for (int i = minimumDate.Year;i<=maximumDate.Year;i++)
			{
				yearList[year] = i.ToString();
				year++;
			}
			
			return yearList;
		}
			
		internal void DoLayout()
		{
			int y = 0;
			int x = 0;
			
			if (ShowHeader)
			{
				if (calendarHeader.Font.Height > 31)
					y = 2 + this.Font.Height + 2;
				else 
					y = 31;
				
				headerRect = new Rectangle(0,0,this.Width,y);
			}
			else
			{
				headerRect = new Rectangle(0,0,0,0);
			}
			 
			if (ShowWeekDays)
			{
                //MED-6495 modified by Cloud version
                if (NetInfo.Language == LangMode.Jr)
                {
                    weekDaysRect.Height = 2 + calendarWeekDay.Font.Height + 2; 
                }
                else
                {
                    weekDaysRect.Height = 10 + calendarWeekDay.Font.Height + 10; 
                }
				weekDaysRect.Y = y; 
				weekDaysRect.Width = this.Width-x;
				weekDaysRect.X = x;
				y = y + weekDaysRect.Height; 
			}
			else 
				weekDaysRect = new Rectangle(0,0,0,0); 
			
			monthRect.Y = y;
			monthRect.X = x;
			monthRect.Width = this.Width-x;
			
			if (ShowFooter)
			{
				footerRect.Height = 2 + calendarFooter.Font.Height + 2 ;
				footerRect.Y = this.Height - footerRect.Height;
				footerRect.X = 0;
				footerRect.Width = this.Width;
				monthRect.Height = this.Height - footerRect.Height - y;
			}
			else
			{
				footerRect = new Rectangle(0,0,0,0);
				monthRect.Height = this.Height - y;	
			}
			
			calendarMonth.MonthRect = monthRect; 
			calendarMonth.SetupDays();
			
			calendarFooter.FooterRect = footerRect;
			calendarHeader.HeaderRect = headerRect;
			calendarWeekDay.WeekDayRect = weekDaysRect;
						
		}
		#endregion

		#region Overrides
		
		
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			base.OnDragDrop (drgevent);
			Point location = new Point(drgevent.X,drgevent.Y); 
			int day = calendarMonth.GetDay(mouseLocation);
			if (day!=-1)
			{
				if (DayDragDrop!=null)
					DayDragDrop(this,new XCalendarDayDragDropEventArgs(drgevent.Data,drgevent.KeyState,calendarMonth.CalendarDays[day].DateItem));   
						
			}
		}

		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			base.OnDragEnter (drgevent);
		}
		
		protected override void OnDragOver(DragEventArgs drgevent)
		{
			base.OnDragOver (drgevent);
			if ((drgevent.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)  
			{
				// By default, the drop action should be move, if allowed.
				drgevent.Effect = DragDropEffects.Move;
			}
		}
		
		protected override void OnDragLeave(EventArgs e)
		{
			base.OnDragLeave (e);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
						
			// set location and button
			mouseLocation = new Point(e.X,e.Y);
			mouseButton = e.Button; 
			
			/*MouseDown Case 별로 처리하기 (EnableMultiSelection일때 처리)
			 *1.Ctrl Key를 누른 상태에서 MouseDown시는 다른행 선택
			  2.Shift Key를 누른 상태에서는 시작위치 - 끝위치까지 모두 선택)
			  3.아무것도 누리지 않은 상태에서는 다른 날짜 선택
			 */
			if (!this.enableMultiSelection)
				calendarMonth.Click(mouseLocation, mouseButton, true);  //기존 선택영역 Clear
			else
			{
				//Left Button Click이 아니면 기존 Logic 그대로 반영
				if (e.Button == MouseButtons.Left)
				{
					if (this.toggleSelection)  //기존영역 Clear하지 않고 선택
					{
						calendarMonth.Click(mouseLocation, mouseButton, false);
					}
					else
					{
						if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
							calendarMonth.Click(mouseLocation, mouseButton, false);  //기존 선택영역 Clear하지 않음
						else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
						{
							//시작 위치의 행, 열은 선택된 날짜
							if (calendarMonth.SelectedStartDay == null) //선택된 객체가 하나도 없으면 선택
								calendarMonth.Click(mouseLocation, mouseButton, true);  //기존 선택영역 Clear
							else
							{
								//현재 MousePoint가 있는 XCalendarDay 가져오기
								int day = calendarMonth.GetDay(mouseLocation);
								if (day < 0) return;
							
								XCalendarDay startDay = calendarMonth.SelectedStartDay;
								XCalendarDay endDay = calendarMonth.CalendarDays[day];
								//같은 날짜이면 기존로직 그대로 반영
								if ((startDay.Row == endDay.Row) && (startDay.Col == endDay.Col))
								{
									calendarMonth.Click(mouseLocation, mouseButton, true);  //기존 선택영역 Clear
									return;
								}
								bool isForward = false;
								//Forward의 기준은 끝행이 크거나, 끝열이 큰경우
								if ((startDay.Row < endDay.Row) || (startDay.Col < endDay.Col))
									isForward = true;

								//선택영역 SET
								calendarMonth.SelectDate(Math.Min(startDay.Row, endDay.Row), Math.Max(startDay.Row, endDay.Row),
									Math.Min(startDay.Col, endDay.Col), Math.Max(startDay.Col, endDay.Col), isForward);
							
							}
						}
						else  //아무 보조키도 누리지 않은 상태에서는 
							calendarMonth.Click(mouseLocation, mouseButton, true);  //기존 선택영역 Clear
					}
				}
				else
					calendarMonth.Click(mouseLocation, mouseButton, true);  //기존 선택영역 Clear
			}
	
			//Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
						
			if (ShowHeader) calendarHeader.MouseUp();
			calendarMonth.MouseUp(); 
			//Invalidate();
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove (e);
			// set location and button
			mouseLocation = new Point(e.X,e.Y);
			mouseButton = e.Button; 
						
			if (ShowHeader) calendarHeader.MouseMove(mouseLocation);
			calendarMonth.MouseMove(mouseLocation);
			if (ShowFooter) calendarFooter.MouseMove(mouseLocation);
			if (ShowWeekDays) calendarWeekDay.MouseMove(mouseLocation);

			//Invalidate();	
		}
		
		protected override void OnMouseLeave(EventArgs e)
		{
			ActiveRegion = XCalendarRegion.None; 
			calendarMonth.RemoveFocus();
			base.OnMouseLeave (e);
			//Invalidate();
		}
	
		protected override void OnClick(EventArgs e)
		{
			base.OnClick (e);
			
			//Focus가 없으면 Focus를 준다
			if (!this.ContainsFocus)
				this.Focus();
			
			if (ShowHeader) calendarHeader.MouseClick(mouseLocation, mouseButton, false);
			if (ShowWeekDays) calendarWeekDay.MouseClick(mouseLocation, mouseButton,false);
			if (ShowFooter) calendarFooter.MouseClick(mouseLocation, mouseButton,false);
						
			//Invalidate();
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick (e);
			
			calendarMonth.DoubleClick(mouseLocation, mouseButton);
				
			if (ShowWeekDays) calendarWeekDay.MouseClick(mouseLocation, mouseButton,true);
			if (ShowHeader) calendarHeader.MouseClick(mouseLocation, mouseButton,true);
			if (ShowFooter) calendarFooter.MouseClick(mouseLocation, mouseButton,true);
			
			//Invalidate();
		}
        	
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			if (this.reDraw)
				Draw(e.Graphics);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize (e);
			DoLayout();
		}

		#endregion

		#region Events Handlers
		
		private void OnPrintDocBeginPrint(object sender, PrintEventArgs e)
		{
			
		}

		private void OnPrintDocPrintPage(object sender, PrintPageEventArgs e)
		{
			Bitmap bmp;
			bmp = Snapshot();
			e.Graphics.DrawImage(bmp,1,1,bmp.Width,bmp.Height);  
			e.HasMorePages = false;
			bmp.Dispose();
		}

		private void OnPrintDocQueryPageSettings(object sender, QueryPageSettingsEventArgs e)
		{
			  
		}
	
		private void OnActiveMonthChanged(object sender, XCalendarMonthChangedEventArgs e)
		{
			calendarMonth.RemoveSelect(true);
			OnMonthChanged(e);
		}

		private void OnMonthDaySelected(object sender, XCalendarDaySelectedEventArgs e)
		{
			OnDaySelected(e);
		}

		private void OnMonthDayDeSelected(object sender, XCalendarDaySelectedEventArgs e)
		{
			OnDayDeSelected(e);
		}
		
		private void OnMonthDayLostFocus(object sender, XCalendarDayEventArgs e)
		{
			OnDayLostFocus(e);
		}

		private void OnMonthDayGotFocus(object sender, XCalendarDayEventArgs e)
		{
			OnDayGotFocus(e);
		}

		private void OnMonthDayClick(object sender, XCalendarDayClickEventArgs e)
		{
			OnDayClick(e);
		}

		private void OnMonthDayDoubleClick(object sender, XCalendarDayClickEventArgs e)
		{
			OnDayDoubleClick(e);
		}

		private void OnFooterClick(object sender, XCalendarClickEventArgs e)
		{
			OnFooterClick(e);
		}

		private void OnFooterDoubleClick(object sender, XCalendarClickEventArgs e)
		{
			OnFooterDoubleClick(e);
		}

		private void OnHeaderClick(object sender, XCalendarClickEventArgs e)
		{
			OnHeaderClick(e);
		}

		private void OnHeaderDoubleClick(object sender, XCalendarClickEventArgs e)
		{
			OnHeaderDoubleClick(e);
		}

		private void OnHeaderPrevButtonClick(object sender, EventArgs e)
		{
			int bfYear = calendarMonth.SelectedMonth.Year;
			calendarMonth.SelectedMonth = calendarMonth.SelectedMonth.AddMonths(-1);
			int month = calendarMonth.SelectedMonth.Month; 
			int year = calendarMonth.SelectedMonth.Year;
			//Year가 변경되었으면 MonthChanged가 Year설정시 발생하도록 Flag false로 설정
			if (bfYear != year)
			{
				activeMonth.IsCallMonthChanged = false;
				activeMonth.Month = month;
				activeMonth.IsCallMonthChanged = true;  //Year설정시에 MonthChanged Event 발생시킴
				activeMonth.Year = year;
			}
			else
			{
				activeMonth.Month = month;
				activeMonth.Year = year;
			}
		}

		private void OnHeaderNextButtonClick(object sender, EventArgs e)
		{
			int bfYear = calendarMonth.SelectedMonth.Year;
			calendarMonth.SelectedMonth = calendarMonth.SelectedMonth.AddMonths(1);
			int month = calendarMonth.SelectedMonth.Month; 
			int year = calendarMonth.SelectedMonth.Year;
			//Year가 변경되었으면 MonthChanged가 Year설정시 발생하도록 Flag false로 설정
			if (bfYear != year)
			{
				activeMonth.IsCallMonthChanged = false;
				activeMonth.Month = month;
				activeMonth.IsCallMonthChanged = true;  //Year설정시에 MonthChanged Event 발생시킴
				activeMonth.Year = year;
			}
			else
			{
				activeMonth.Month = month;
				activeMonth.Year = year;
			}
			
		}

		private void OnWeekDayClick(object sender, XCalendarWeekDayClickEventArgs e)
		{
			OnWeekDayClick(e);
		}

		private void OnWeekDayDoubleClick(object sender, XCalendarWeekDayClickEventArgs e)
		{
			OnWeekDayDoubleClick(e);
		}
		#endregion

		#region Event Invoker
		protected virtual void OnMonthChanged(XCalendarMonthChangedEventArgs e)
		{
			if (this.MonthChanged != null)
				this.MonthChanged(this, e);
		}
		protected virtual void OnDayClick(XCalendarDayClickEventArgs e)
		{
			if (this.DayClick != null)
				this.DayClick(this, e);
		}
		protected virtual void OnDayDoubleClick(XCalendarDayClickEventArgs e)
		{
			if (this.DayDoubleClick != null)
				this.DayDoubleClick(this, e);
		}
		protected virtual void OnHeaderClick(XCalendarClickEventArgs e)
		{
			if (this.HeaderClick != null)
				this.HeaderClick(this, e);
		}
		protected virtual void OnHeaderDoubleClick(XCalendarClickEventArgs e)
		{
			if (this.HeaderDoubleClick != null)
				this.HeaderDoubleClick(this, e);
		}
		protected virtual void OnFooterClick(XCalendarClickEventArgs e)
		{
			if (this.FooterClick != null)
				this.FooterClick(this, e);
		}
		protected virtual void OnFooterDoubleClick(XCalendarClickEventArgs e)
		{
			if (this.FooterDoubleClick != null)
				this.FooterDoubleClick(this, e);
		}
		protected virtual void OnDayGotFocus(XCalendarDayEventArgs e)
		{
			if (this.DayGotFocus != null)
				this.DayGotFocus(this, e);
		}
		protected virtual void OnDayLostFocus(XCalendarDayEventArgs e)
		{
			if (this.DayLostFocus != null)
				this.DayLostFocus(this, e);
		}
		protected virtual void OnWeekDayClick(XCalendarWeekDayClickEventArgs e)
		{
			if (this.WeekDayClick != null)
				this.WeekDayClick(this, e);
		}
		protected virtual void OnWeekDayDoubleClick(XCalendarWeekDayClickEventArgs e)
		{
			if (this.WeekDayDoubleClick != null)
				this.WeekDayDoubleClick(this, e);
		}
		protected virtual void OnDaySelected(XCalendarDaySelectedEventArgs e)
		{
			if (this.DaySelected != null)
				this.DaySelected(this, e);
		}
		protected virtual void OnDayDeSelected(XCalendarDaySelectedEventArgs e)
		{
			if (this.DayDeSelected != null)
				this.DayDeSelected(this, e);
		}
		protected virtual void OnFooterMouseEnter(EventArgs e)
		{
			if (this.FooterMouseEnter != null)
				this.FooterMouseEnter(this, e);
		}
		protected virtual void OnFooterMouseLeave(EventArgs e)
		{
			if (this.FooterMouseLeave != null)
				this.FooterMouseLeave(this, e);
		}
		protected virtual void OnHeaderMouseEnter(EventArgs e)
		{
			if (this.HeaderMouseEnter != null)
				this.HeaderMouseEnter(this, e);
		}
		protected virtual void OnHeaderMouseLeave(EventArgs e)
		{
			if (this.HeaderMouseLeave != null)
				this.HeaderMouseLeave(this, e);
		}
		protected virtual void OnWeekDayMouseEnter(EventArgs e)
		{
			if (this.WeekDayMouseEnter != null)
				this.WeekDayMouseEnter(this, e);
		}
		protected virtual void OnWeekDayMouseLeave(EventArgs e)
		{
			if (this.WeekDayMouseLeave != null)
				this.WeekDayMouseLeave(this, e);
		}
		#endregion

		#region 법정 공휴일 SET
		public void SetLegalHolidays()
		{
			if (this.DesignMode) return;

			//<미확정> DB에서 관리할지 여부 확정 필요, 일단은 토,일을 설정

		}
		#endregion

		#region ISupportInitialize Implemetation
		/// <summary>
		/// 초기화가 시작됨을 개체에 알립니다.
		/// </summary>
		void ISupportInitialize.BeginInit()
		{
		}
		/// <summary>
		/// 초기화 종료시 컬럼을 초기화(InitializeColumns)합니다.
		/// </summary>
		void ISupportInitialize.EndInit()
		{
			if (!this.DesignMode)  //RunTime시 법정 공휴일 Set
				this.SetLegalHolidays();
		}

        public DateTime GetCalendarDateTime()
        {
            try
            {
               return new DateTime(activeMonth.Year, activeMonth.Month, 1);
            }
            //catch (Exception ex)
            catch
            {
                return new DateTime();
            }
        }
		#endregion
	}

	#region XCalendarDesigner
	internal class XCalendarDesigner  : ScrollableControlDesigner
	{

		public XCalendarDesigner()
		{
		}

		//public override void OnSetComponentDefaults()
		//{
		//	base.OnSetComponentDefaults();
        //}
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            this.Control.Text = "";
        }
		
		public override SelectionRules SelectionRules
		{
			get
			{
				// Remove all manual resizing of the control
				SelectionRules selectionRules = base.SelectionRules;
				selectionRules = SelectionRules.Visible |SelectionRules.AllSizeable | SelectionRules.Moveable;
				return selectionRules;
			}
		}

		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			base.PreFilterProperties(properties);
			
			// Remove obsolete properties
			properties.Remove("BackColor");
			properties.Remove("Font");
			properties.Remove("BackgroundImage");
			properties.Remove("ForeColor");
			properties.Remove("Text");
			properties.Remove("RightToLeft");
			properties.Remove("ImeMode");
		}
        
	}

	#endregion
}
