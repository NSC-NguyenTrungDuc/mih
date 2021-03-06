using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;

namespace IHIS.Framework
{
	/// <summary>
	/// XCalendarMonth에 대한 요약 설명입니다.
	/// </summary>
	[TypeConverter(typeof(SimpleTypeConverter))]
	public class XCalendarMonth : IDisposable
	{
		#region  ColorCollection
		[TypeConverter(typeof(SimpleTypeConverter))]
		public class ColorCollection
		{
			#region Fields
			private XColor monthBackColor			= XColor.XCalendarMonthBackColor;
			private XColor dateBackColor			= XColor.XCalendarDateBackColor;
			private XColor dateborderColor			= XColor.XCalendarDateBorderColor;
			private XColor selectedDateBackColor	= XColor.XCalendarSelectedDateBackColor;  //선택된 날의 배경색
			private XColor selectedDateBorderColor	= XColor.XCalendarSelectedDateBorderColor; //선택된 날의 Border 색
			private XColor dateTextColor			= XColor.XCalendarDateTextColor;   //날짜 Text 색
			private XColor trailingDateBackColor	= XColor.XCalendarTrailingDateBackColor;
			private XColor trailingDateTextColor	= XColor.XCalendarTrailingDateTextColor;
			private XColor halfHolidayBackColor		= XColor.XCalendarHalfHolidayBackColor;   //반휴일 배경색
			private XColor halfHolidayTextColor		= XColor.XCalendarHalfHolidayTextColor; //반휴일 Date색
			private XColor fullHolidayBackColor		= XColor.XCalendarFullHolidayBackColor;   //Full휴일 배경색
			private XColor fullHolidayTextColor		= XColor.XCalendarFullHolidayTextColor;  //Full휴일 Date 색
			private XColor disabledDateBackColor	= XColor.XCalendarDisabledDateBackColor;  //Disable날짜 배경색
			private XColor disabledDateTextColor	= XColor.XCalendarDisabledDateTextColor;
			internal XCalendarMonth calendarMonth;
			#endregion

			#region Properties
			[DefaultValue(typeof(XColor),"XCalendarMonthBackColor"),
			Description("달력의 달영역의 배경색을 지정합니다.")]
			public XColor MonthBackColor
			{
				get { return monthBackColor;}
				set
				{
					if (monthBackColor != value)
					{
						monthBackColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarDateBackColor"),
			Description("날짜의 배경색을 지정합니다.")]
			public XColor DateBackColor
			{
				get { return dateBackColor;}
				set
				{
					if (dateBackColor != value)
					{
						dateBackColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarDateBorderColor"),
			Description("날짜의 테두리색을 지정합니다.")]
			public XColor DateBorderColor
			{
				get { return dateborderColor;}
				set
				{
					if (dateborderColor != value)
					{
						dateborderColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarSelectedDateBackColor"),
			Description("선택된 날짜의 배경색을 지정합니다.")]
			public XColor SelectedDateBackColor
			{
				get { return selectedDateBackColor;}
				set
				{
					if (selectedDateBackColor != value)
					{
						selectedDateBackColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarSelectedDateBorderColor"),
			Description("선택된 날짜의 테두리색을 지정합니다.")]
			public XColor SelectedDateBorderColor
			{
				get { return selectedDateBorderColor;}
				set
				{
					if (selectedDateBorderColor != value)
					{
						selectedDateBorderColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarDateTextColor"),
			Description("날짜의 기본 텍스트색을 지정합니다.")]
			public XColor DateTextColor
			{
				get { return dateTextColor;}
				set
				{
					if (dateTextColor != value)
					{
						dateTextColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarTrailingDateBackColor"),
			Description("따라오는 날짜(전달,다음달)의 배경색을 지정합니다.")]
			public XColor TrailingDateBackColor
			{
				get { return trailingDateBackColor;}
				set
				{
					if (trailingDateBackColor != value)
					{
						trailingDateBackColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarTrailingDateTextColor"),
			Description("따라오는 날짜(전달,다음달)의 텍스트색을 지정합니다.")]
			public XColor TrailingDateTextColor
			{
				get { return trailingDateTextColor;}
				set
				{
					if (trailingDateTextColor != value)
					{
						trailingDateTextColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarHalfHolidayBackColor"),
			Description("반공휴일의 배경색을 지정합니다.")]
			public XColor HalfHolidayBackColor
			{
				get { return halfHolidayBackColor;}
				set
				{
					if (halfHolidayBackColor != value)
					{
						halfHolidayBackColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarHalfHolidayTextColor"),
			Description("반공휴일의 텍스트색을 지정합니다.")]
			public XColor HalfHolidayTextColor
			{
				get { return halfHolidayTextColor;}
				set
				{
					if (halfHolidayTextColor != value)
					{
						halfHolidayTextColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarFullHolidayBackColor"),
			Description("Full공휴일의 배경색을 지정합니다.")]
			public XColor FullHolidayBackColor
			{
				get { return fullHolidayBackColor;}
				set
				{
					if (fullHolidayBackColor != value)
					{
						fullHolidayBackColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarFullHolidayTextColor"),
			Description("Full공휴일의 텍스트색을 지정합니다.")]
			public XColor FullHolidayTextColor
			{
				get { return fullHolidayTextColor;}
				set
				{
					if (fullHolidayTextColor != value)
					{
						fullHolidayTextColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarDisabledDateBackColor"),
			Description("Disabled 날짜의 배경색을 지정합니다.")]
			public XColor DisabledDateBackColor
			{
				get { return disabledDateBackColor;}
				set
				{
					if (disabledDateBackColor != value)
					{
						disabledDateBackColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			[DefaultValue(typeof(XColor),"XCalendarDisabledDateTextColor"),
			Description("Disabled 날짜의 텍스트색을 지정합니다.")]
			public XColor DisabledDateTextColor
			{
				get { return disabledDateTextColor;}
				set
				{
					if (disabledDateTextColor != value)
					{
						disabledDateTextColor = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
			}
			#endregion
			
			#region 생성자
			public ColorCollection(XCalendarMonth month)
			{
				calendarMonth = month;
			}
			#endregion

		}
		#endregion

		#region  BorderStyleCollection
	

		[TypeConverter(typeof(SimpleTypeConverter))]
		public class BorderStyleCollection
		{
			#region Fields
			internal XCalendarMonth calendarMonth;
			
			private ButtonBorderStyle dateBorder = ButtonBorderStyle.Solid;
//			private ButtonBorderStyle focusDateBorder = ButtonBorderStyle.Solid;
			private ButtonBorderStyle selectedDateBorder = ButtonBorderStyle.Solid;
			#endregion

			#region Properties
			[Description("기본 날짜의 BorderStyle을 지정합니다.")]
			[DefaultValue(ButtonBorderStyle.Solid)]
			public ButtonBorderStyle DateBorder
			{
				get { return dateBorder;}
				set 
				{
					if (dateBorder!=value)
					{
						dateBorder = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);
					}
				}
				
			}
			
//			[Description("Focus가 있는 날짜의 BorderStyle을 지정합니다.")]
//			[DefaultValue(ButtonBorderStyle.Solid)]
//			public ButtonBorderStyle FocusDateBorder
//			{
//				get	{ return focusDateBorder; }
//				set
//				{
//					if (focusDateBorder!=value)
//					{
//						focusDateBorder = value;
//						calendarMonth.Calendar.Invalidate();
//					}
//				}
//				
//			}
			
			[Description("선택된 날짜의 BorderStyle색을 지정합니다.")]
			[DefaultValue(ButtonBorderStyle.Solid)]
			public ButtonBorderStyle SelectedDateBorder
			{
				get { return selectedDateBorder; }
				set
				{
					if (selectedDateBorder!=value)
					{
						selectedDateBorder = value;
						calendarMonth.Calendar.Invalidate(calendarMonth.monthRect); 
					}
				}
	
			}
			#endregion
			
			#region 생성자
			public BorderStyleCollection(XCalendarMonth month)
			{
				calendarMonth = month;
			}
			#endregion
		}
		#endregion

		#region  PaddingCollection

		[TypeConverter(typeof(PaddingCollectionTypeConverter))]		
		public class PaddingCollection
		{
			private XCalendarMonth calendarMonth;
			private int horizontal;
			private int vertical;
			
			public PaddingCollection(XCalendarMonth month)
			{
				// set the control to which the collection belong
				calendarMonth = month;
				// Default values
				horizontal = 2;
				vertical = 2;
			}
			
			[RefreshProperties(System.ComponentModel.RefreshProperties.All)]
			[Description("수평 Padding을 지정합니다.")]
			[DefaultValue(2)]
			public int Horizontal
			{
				get { return horizontal; }
				set
				{
					if (horizontal!=value)
					{
						horizontal = Math.Max(value,0);
						if (calendarMonth!=null)
						{
							// padding has changed , force DoLayout
							calendarMonth.SetupDays();
							calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);  
				
						}
					}
				}
			}
			
			[RefreshProperties(System.ComponentModel.RefreshProperties.All)]
			[Description("수직 Padding을 지정합니다.")]
			[DefaultValue(2)]
			public int Vertical
			{
				get	{ return vertical; }
				set
				{
					if (vertical!=value)
					{
						vertical = Math.Max(value,0);
						if (calendarMonth!=null)
						{						
							calendarMonth.SetupDays();
							calendarMonth.Calendar.Invalidate(calendarMonth.monthRect);  
						}
					}
				}
			}

		}
		#endregion

		#region Fields
		private XCalendar calendar;
		private Font dateTextFont = new Font("MS UI Gothic", 9.75f, FontStyle.Bold);
		private Rectangle monthRect;
		private Region monthRegion;
		private int transparency = 175;
		internal XDateItemCollection SelectedDays = new  XDateItemCollection();
		internal XCalendarDay[] CalendarDays;
		internal XCalendarDay	SelectedStartDay = null; //선택이 시작된 XCalendarDay
		
		private PaddingCollection padding;
		private ContentAlignment dateTextAlign = ContentAlignment.TopRight;
	
		private bool isMouseDown = false;
		private ColorCollection colors;
		private BorderStyleCollection borderStyles;
		private DateTime selectedMonth;
				
		private int dayInFocus = -1;  //현재 Focus가 있는 달의 Index
		private float dayWidth = 0f;
		private float dayHeight = 0f;
		internal DateTime DisplayStartDate;  //달력에 표시되는 Display시작일(TrailingDates를 보여줄때)
		internal DateTime DisplayEndDate;	 //달력에 표시되는 Display종료일
		#endregion

		#region Properties
		internal bool IsMouseDown
		{
			get { return isMouseDown;}
		}
		internal XCalendar Calendar
		{
			get { return calendar;}
		}
		internal DateTime SelectedMonth  //현재 선택된 달
		{
			get { return selectedMonth;}
			set { selectedMonth = value;}
		}

		internal Rectangle MonthRect
		{
			get { return monthRect;}
			set 
			{
				if (monthRect != value)
				{
					monthRect = value;
					//Region 설정
					this.monthRegion = new Region(monthRect);
				}
			}
		}
		internal float DayWidth  //날의 너비
		{
			get { return dayWidth;}
		}
		internal float DayHeight  //날의 높이
		{
			get { return dayHeight;}
		}

		[Browsable(true)]
		[Category("모양")]
		[Description("색깔의 투명도를 지정합니다. (0-255)")]
		[DefaultValue(175)]
		public int Transparency
		{
			get { return transparency;}
			set
			{
				if (transparency!=value)
				{
					transparency = Math.Max(0, Math.Min(255,value));
					calendar.Invalidate(this.monthRect); 
				}
			}
		}
		[Browsable(true)]
		[Category("모양")]
		[Description("날짜사이의 간격을 지정합니다.(Horizontal;Vertical)")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PaddingCollection Padding
		{
			get { return padding;}
			set
			{
				if (value!=padding)
				{
					if (value != null)	padding = value;
					SetupDays();
					calendar.Invalidate(this.monthRect);
				}
			}
		}

		[Category("모양")]
		[Description("날짜 표시 Text의 Align을 지정합니다.")]
		[DefaultValue(ContentAlignment.TopRight)]
		public ContentAlignment DateTextAlign
		{
			get { return dateTextAlign;} 
			set
			{
				if (dateTextAlign!=value)
				{
					dateTextAlign = value;
					Calendar.Invalidate(this.monthRect);
				}
			}
		}
		[Category("모양")]
		[Description("날짜의 Border Style (Normal,Selected)를 지정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public BorderStyleCollection BorderStyles
		{
			get	{ return borderStyles; }
		}
		[Category("모양")]
		[Description("달력에 사용될 컬러를 지정합니다.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ColorCollection Colors
		{
			get { return colors;}
		}
		[Category("모양")]
		[Description("날짜 Text의 Font를 지정합니다.")]
		[DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt, style=Bold")]
		public Font DateTextFont
		{
			get { return dateTextFont;}
			set 
			{
				if (dateTextFont!=value)
				{
					dateTextFont = value;
					Calendar.Invalidate(this.monthRect);
				}
			}
		}
		#endregion

		#region Events
		internal event XCalendarDayEventHandler DayLostFocus;
		internal event XCalendarDayEventHandler DayGotFocus;
		internal event XCalendarDayClickEventHandler DayClick;
		internal event XCalendarDayClickEventHandler DayDoubleClick;
		internal event XCalendarDaySelectedEventHandler DaySelected;
		internal event XCalendarDaySelectedEventHandler DayDeSelected;
		#endregion

		#region 생성자
		public XCalendarMonth(XCalendar calendar)
		{
			this.calendar = calendar;

			// we need 42 (7 * 6) days for display
			CalendarDays = new XCalendarDay[42];
			for (int i = 0;i < 42 ; i++)
			{
				CalendarDays[i] = new XCalendarDay();
				CalendarDays[i].Month = this;
				CalendarDays[i].Calendar = calendar;
			}

			colors = new ColorCollection(this); 
			borderStyles = new BorderStyleCollection(this); 
			this.padding = new PaddingCollection(this); 
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
				
		}
		#endregion

		#region Methods
			
		internal void SelectDate(DateTime date)
		{
			date = DateTime.Parse(date.ToShortDateString());
			for (int i = 0;i < 42 ; i++)
			{
				if (date == CalendarDays[i].DateItem.Date)
				{
					//Multi선택이 되지 않는 경우만 이전 Select Clear
					if (!calendar.EnableMultiSelection)
						RemoveSelect(true);
					
					bool isSelect = true;
					XDateItem dateItem = CalendarDays[i].DateItem;

					//2005.11.18 Full공휴일, 반공휴일 선택여부에 따라 Add 결졍
					if (!calendar.FullHolidaySelectable && (dateItem.DateKind == XDateKind.FullHoliday))
						isSelect = false;
					if (!calendar.HalfHolidaySelectable && (dateItem.DateKind == XDateKind.HalfHoliday))
						isSelect = false;
					
					if (isSelect)
					{
						CalendarDays[i].DayState = XCalendarDayState.Selected;
						dayInFocus = -1;
					
						//선택된 날짜 SET
						SelectedDays.Add(dateItem);
						//선택시작 객체 SET
						this.SelectedStartDay = CalendarDays[i];
						Calendar.Invalidate(this.monthRect);
						//DaySelected Event call
						if (this.DaySelected != null)
							this.DaySelected(this, new XCalendarDaySelectedEventArgs(SelectedDays));
					}
				}
			}
		}
		
		//시작행과 끝행사이의 좌표를 가지는 Day Select
		internal void SelectDate(int startRow, int endRow, int startCol, int endCol, bool isForward)
		{
			RemoveSelect(true);
			XCalendarDay day = null;
			bool isAdd = true;
			for (int i = 0 ; i < 42 ; i++)
			{
				day = CalendarDays[i];
				if ((day.Row >= startRow) && (day.Row <= endRow) && (day.Col >= startCol) && (day.Col <= endCol))
				{
					//Calendar의 SelectTrailingDates가 true이면 전체 선택, 아니면 TrailingDate는 선택하지 않음
					//동일한 달이 아니면 Select 불가
					if (!this.calendar.SelectTrailingDates && (day.DateItem.Date.Month != this.SelectedMonth.Month))
						isAdd = false;
					
					//2005.11.18 Full공휴일, 반공휴일 선택여부에 따라 Add 결졍
					if (!calendar.FullHolidaySelectable && (day.DateItem.DateKind == XDateKind.FullHoliday))
						isAdd = false;
					if (!calendar.HalfHolidaySelectable && (day.DateItem.DateKind == XDateKind.HalfHoliday))
						isAdd = false;

					if (isAdd)
					{
						day.DayState = XCalendarDayState.Selected;
						SelectedDays.Add(day.DateItem);
						//선택시작객체 SET(앞에서 뒤로 선택 isForward = true이면 마지막 객체, 반대이면 시작객체
						if (isForward)
						{
							if ((day.Row == endRow) && (day.Col == endCol))
								this.SelectedStartDay = day;
						}
						else
						{
							if ((day.Row == startRow) && (day.Col == startCol))
								this.SelectedStartDay = day;
						}
					}
				}
				isAdd = true;
			}
			Calendar.Invalidate(this.monthRect);
		}

		internal void DoubleClick(Point mouseLocation, MouseButtons button)
		{
			if (monthRegion.IsVisible(mouseLocation))
			{
				for (int i = 0;i < 42 ; i++)
				{
					if (CalendarDays[i].HitTest(mouseLocation))
					{
						if (this.DayDoubleClick!=null)
							this.DayDoubleClick(this,new XCalendarDayClickEventArgs(CalendarDays[i].DateItem ,button));
					}
				}
			}
		}
		
		internal void MouseUp()
		{
			isMouseDown = false;
			if (SelectedDays.Count > 0)
			{
				if (this.DaySelected!=null)
					this.DaySelected(this,new XCalendarDaySelectedEventArgs(SelectedDays));
			}
		}

		internal void Click(Point mouseLocation,MouseButtons button, bool clearSelect)
		{
			int infoIndex = -1;
			bool dayEnabled = true;
			XDateItem dateItem = null;
			if (monthRegion.IsVisible(mouseLocation))
			{
				for (int i = 0;i < 42 ; i++)
				{
					if (CalendarDays[i].HitTest(mouseLocation))
					{
						dateItem = CalendarDays[i].DateItem;

						//LeftButton Click시만 SELECT 변경
						if (button == MouseButtons.Left)
						{
							infoIndex = calendar.Dates.IndexOf(dateItem.Date);
							//XCalendarDate의 Enabled속성에 따라 선택가능여부 판단
							if (infoIndex!=-1)
								dayEnabled = calendar.Dates[infoIndex].Enabled;

							if ( ((calendar.SelectTrailingDates) || (SelectedMonth.Month  == dateItem.Date.Month)) &&
								((calendar.MinDate<= dateItem.Date) && (calendar.MaxDate >= dateItem.Date)) && (dayEnabled) ) 	
							{
								dayInFocus = -1;
								// If day is already selected ,toggle to focus
								if (CalendarDays[i].DayState == XCalendarDayState.Selected)
								{
									//2005.11.09 calendar가 toggleSection이면 전체 Selection해제하지 않고 자신만 해제하고, 
									//아니면 전체선택 해제함
									if (calendar.ToggleSelection)
									{
										CalendarDays[i].DayState = XCalendarDayState.Focus;
										//선택시작 객체 Clear
										this.SelectedStartDay = null;
										SelectedDays.Remove(dateItem);
									}
									else
									{
										RemoveSelect(true);
										CalendarDays[i].DayState = XCalendarDayState.Focus;
										//선택시작 객체 Clear
										this.SelectedStartDay = null;
									}
								}
								else  //Normal, Focus상태일떄는 해당 Day Select
								{
									//이전선택내역 Clear시만 Clear
									if (clearSelect)
										RemoveSelect(true);
									
									//2005.11.18 Full공휴일, 반공휴일 선택여부에 따라 Add 결졍
									bool isSelect = true;
									if (!calendar.FullHolidaySelectable && (dateItem.DateKind == XDateKind.FullHoliday))
										isSelect = false;
									if (!calendar.HalfHolidaySelectable && (dateItem.DateKind == XDateKind.HalfHoliday))
										isSelect = false;

									if (isSelect)
									{
										CalendarDays[i].DayState = XCalendarDayState.Selected;
										//선택된 날에 Add
										SelectedDays.Add(dateItem);
										//선택시작 객체 SET
										this.SelectedStartDay = CalendarDays[i];
									}
								}
								isMouseDown = true;
							}
						}

						//either way ceate DayClick event
						if (this.DayClick!=null)
							this.DayClick(this,new XCalendarDayClickEventArgs(dateItem,button));
						break;
					}
				}
				calendar.Invalidate(this.monthRect);
			}
		}

		internal void MouseMove (Point mouseLocation)
		{
			int infoIndex = -1;
			bool dayEnabled = true;
			XDateItem dateItem = null;

			// is mouse pointer inside month region
			if (monthRegion.IsVisible(mouseLocation))
			{
				//Calendar의 Active 영역 Enum SET
				calendar.ActiveRegion = XCalendarRegion.Month;
				// Check which day has focus
				for (int i = 0;i<42;i++)
				{
					dateItem = CalendarDays[i].DateItem;

					if (CalendarDays[i].HitTest(mouseLocation))
					{
						infoIndex = calendar.Dates.IndexOf(dateItem.Date);
						if (infoIndex!=-1)
							dayEnabled = calendar.Dates[infoIndex].Enabled;
 						
						// check if its a new day
						if (dayInFocus!=i)
						{
							//MouseDown하지 않고 MOVE시에는 DayGotFocus, DayLostFocus 적용
							if (!isMouseDown) 
							{
								if ( ((calendar.SelectTrailingDates) || (SelectedMonth.Month  == dateItem.Date.Month)) && (dayEnabled))
									
								{
									//XCalendarDay의 상태변경
									if (CalendarDays[i].DayState != XCalendarDayState.Selected)
										CalendarDays[i].DayState = XCalendarDayState.Focus;
									if ((dayInFocus!= -1) && (CalendarDays[dayInFocus].DayState != XCalendarDayState.Selected)) 
										CalendarDays[dayInFocus].DayState = XCalendarDayState.Normal;
							
									// raise events
									if ((DayLostFocus!=null) && (dayInFocus!=-1))
										DayLostFocus(this,new XCalendarDayEventArgs(dateItem));	
									if (DayGotFocus!=null)
										DayGotFocus(this,new XCalendarDayEventArgs(dateItem));	
								}
								else
								{
									if ((dayInFocus!= -1) && (CalendarDays[dayInFocus].DayState != XCalendarDayState.Selected)) 
										CalendarDays[dayInFocus].DayState = XCalendarDayState.Normal;
								}
							
								dayInFocus = i;
							}
						}
						break;
					}
				}
			}
			else
			{
				
				RemoveFocus();
			}
		}
			
		internal string DateInFocus()
		{
			return CalendarDays[dayInFocus].DateItem.Date.ToShortDateString(); 
		}

		internal int GetDay(Point mouseLocation)
		{
			int day = -1;
			for (int i = 0;i<42;i++)
				if (CalendarDays[i].HitTest(mouseLocation))
					day = i;
			return day;
		}
		internal DateTime GetDate(Point mouseLocation)
		{
			DateTime date = DateTime.MinValue; //최소값으로 Default Set(없으면)
			for (int i = 0;i<42;i++)
				if (CalendarDays[i].HitTest(mouseLocation))
					return CalendarDays[i].DateItem.Date;
			return date;
		}
		internal XDateItem GetDateItem(Point mouseLocation)
		{
			for (int i = 0;i<42;i++)
				if (CalendarDays[i].HitTest(mouseLocation))
					return CalendarDays[i].DateItem;
			return null;
		}

		internal void RemoveFocus()
		{
			//DayLostFocus Event call, 상태를 정상으로 변경
			if ((DayLostFocus!=null) && (dayInFocus!=-1))
				DayLostFocus(this,new XCalendarDayEventArgs(CalendarDays[dayInFocus].DateItem));	
			
			dayInFocus = -1;
			for (int i = 0;i<42;i++)
				if (CalendarDays[i].DayState != XCalendarDayState.Selected)
					CalendarDays[i].DayState = XCalendarDayState.Normal; 
		}
		
		internal void RemoveSelect(bool raiseEvent)
		{
			// Reset all days to "Normal"
			for (int i = 0;i<42;i++)
				CalendarDays[i].DayState = XCalendarDayState.Normal;
			//raise deselect event
			if (raiseEvent)
			{
				if (SelectedDays.Count != 0)
					if (this.DayDeSelected!=null)
						this.DayDeSelected(this,new XCalendarDaySelectedEventArgs(SelectedDays));
			}
			
			// Clear selected array
			SelectedDays.Clear();
			//선택시작 객체 Clear
			this.SelectedStartDay = null;
		}
		//Selected 날짜 UnSelect
		internal void UnSelectDate(DateTime date)
		{
			date = DateTime.Parse(date.ToShortDateString());
			for (int i = 0 ; i < 42 ; i++)
			{
				if ((date == CalendarDays[i].DateItem.Date) && (CalendarDays[i].DayState == XCalendarDayState.Selected))
				{
					CalendarDays[i].DayState = XCalendarDayState.Normal;
					SelectedDays.Remove(date);  //선택된 날짜 리스트에서 제거
				}
			}
		}

		internal bool IsSelectedDate(DateTime date)
		{
			date = DateTime.Parse(date.ToShortDateString());
			for (int i = 0 ; i < 42 ; i++)
			{
				if ((date == CalendarDays[i].DateItem.Date) && (CalendarDays[i].DayState == XCalendarDayState.Selected))
					return true;
			}
			return false;
		}

		internal void Setup()
		{
			int startPos=0;
			DateTime currentDate;
			
			//달력에 표시되는 Display시작일 종료일 SET
			//TrailingDate를 보여줄때 계산, 안보여주면 1-말일
			if (!calendar.ShowTrailingDates)
			{
				this.DisplayStartDate = DateTime.Parse(SelectedMonth.Year.ToString() + "-" + SelectedMonth.Month.ToString() + "-01");
				this.DisplayEndDate = DateTime.Parse(SelectedMonth.Year.ToString() + "-" + SelectedMonth.Month.ToString() 
					+ "-" + DateTime.DaysInMonth(SelectedMonth.Year, SelectedMonth.Month).ToString());
			}
			startPos = (int) this.SelectedMonth.DayOfWeek;
			//해당월의 DayOfWeek가 0.일요일이면 7부터 시작
			if (startPos == 0) startPos = 7;

			currentDate = SelectedMonth;
			XDateKind dateKind = XDateKind.Ordinary;
			//일요일은 Full휴일, 법정공휴일 아님, 그외는 평일로 SET
			//법정 공휴일은 XCalendar의 Setup에서 설정함
			for (int i = startPos ; i < 42 ; i++)
			{
				dateKind = (currentDate.DayOfWeek == DayOfWeek.Sunday ? XDateKind.FullHoliday : XDateKind.Ordinary);
				CalendarDays[i].DateItem = new XDateItem(currentDate, dateKind, false);
				CalendarDays[i].Row = (i/7);  //행번호 설정
				CalendarDays[i].Col = (i%7);  //열번호 설정

				currentDate = currentDate.AddDays(1); 
			}
			//마지막 일 SET
			if (calendar.ShowTrailingDates)
				this.DisplayEndDate = currentDate.AddDays(-1);

			currentDate = selectedMonth;
			for (int i= startPos ; i >= 0 ; i--)
			{
				dateKind = (currentDate.DayOfWeek == DayOfWeek.Sunday ? XDateKind.FullHoliday : XDateKind.Ordinary);
				CalendarDays[i].DateItem = new XDateItem(currentDate, dateKind, false);
				CalendarDays[i].Row = (i/7);  //행번호 설정
				CalendarDays[i].Col = (i%7);  //열번호 설정
				currentDate = currentDate.AddDays(-1); 
			}
			//시작일 SET
			if (calendar.ShowTrailingDates)
				this.DisplayStartDate = currentDate.AddDays(1);
		}
		
		internal void Draw(Graphics e)
		{
			using (Brush bgBrush =  new SolidBrush(Colors.MonthBackColor.Color))
				e.FillRectangle(bgBrush,monthRect);
			
			// Draw days
			for (int i = 0;i<42;i++)
			{
				CalendarDays[i].Draw(e);
			}
		}

		internal void SetupDays()
		{
			int row = 0;
			int col = 0;
			int index;
			
			Rectangle dayRect = new Rectangle(); 
			
			dayHeight = (float)((monthRect.Height - (padding.Vertical*7))  / 6);
			dayWidth =  (float)((monthRect.Width - (padding.Horizontal*8)) / 7);
			
			// setup rectangles for days
			row = 0;
			index = 0;
						
			for (int i = 0;i<6;i++)  // rows
			{
				col = 0;
				for (int j = 0;j<7;j++)  // colums
				{
					dayRect.X = (int)(dayWidth * col)+(col+1)*padding.Horizontal+ monthRect.Left;
					dayRect.Y = (int)(dayHeight *row)+(row+1)*padding.Vertical + monthRect.Top;
					if (j ==6)
						dayRect.Width = monthRect.Width - (int)(padding.Horizontal*8) - (int)(dayWidth*6)-1;
					else
						dayRect.Width = (int)dayWidth;
					if ( i==5)
						dayRect.Height = monthRect.Height - (int)(padding.Vertical*7) - (int)(dayHeight*5)-1;
					else
						dayRect.Height = (int)dayHeight;
									
					CalendarDays[index].DayRect = dayRect;
					index++;
					col++;
				}
				row++;
			}
		}
		#endregion

	}
}
