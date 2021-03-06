using System;
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

namespace IHIS.Framework
{
	#region Enum
	public enum XCalendarDayFormat
	{
		Short = 0,  //약식 (월,화,수)
		Long		//전체 (월요일,,,)
	}
	public enum XCalendarClickMode 
	{
		Single = 0, 
		Double
	}
	//날짜 종류
	public enum XDateKind
	{
		/// <summary>
		/// 평일
		/// </summary>
		Ordinary,
		/// <summary>
		/// 전체휴일
		/// </summary>
		FullHoliday,
		/// <summary>
		/// 반휴일
		/// </summary>
		HalfHoliday

	}
	internal enum XCalendarRegion 
	{
		None = 0, 
		Day, 
		Header , 
		Footer, 
		Weekdays, 
		Month
	}
	internal enum XCalendarDayState
	{
		Normal = 0, //XCalendarDay의 정상상태
		Focus,   //Focus를 받은 상태
		Selected //선택된 상태
	}
	#endregion

	#region Event Delegator
	public delegate void XCalendarClickEventHandler(object sender, XCalendarClickEventArgs e);
	public delegate void XCalendarWeekDayClickEventHandler(object sender, XCalendarWeekDayClickEventArgs e);
	public delegate void XCalendarDayClickEventHandler(object sender, XCalendarDayClickEventArgs e);
	public delegate void XCalendarDayEventHandler(object sender, XCalendarDayEventArgs e);
	public delegate void XCalendarDaySelectedEventHandler(object sender, XCalendarDaySelectedEventArgs e);
	public delegate void XCalendarMonthChangedEventHandler(object sender, XCalendarMonthChangedEventArgs e);
	public delegate void XCalendarDayDragDropEventHandler(object sender, XCalendarDayDragDropEventArgs e);
	#endregion

	#region EventArgs

	#region XCalendarClickEventArgs
	public class XCalendarClickEventArgs : EventArgs
	{
		#region Fields
		private MouseButtons button = MouseButtons.Left;
		public MouseButtons Button
		{
			get { return button;}
		}
		#endregion

		#region Constructor
		public XCalendarClickEventArgs(MouseButtons button)
		{
			this.button = button;
		}
		#endregion
	}
	#endregion

	#region XCalendarMonthChangedEventArgs
	public class XCalendarMonthChangedEventArgs : EventArgs
	{
		#region Fields and Properties
		private int month = 0;
		private int year = 0;
		private DateTime displayStartDate;  //해당월에 보여지는 Display시작일
		private DateTime displayEndDate;	//해당월에 보여지는 Display종료일
		public int Month
		{
			get { return month;}
		}
		public int Year
		{
			get { return year;}
		}
		public DateTime DisplayStartDate
		{
			get { return displayStartDate;}
		}
		public DateTime DisplayEndDate
		{
			get { return displayEndDate;}
		}
		#endregion

		#region Constructor
		public XCalendarMonthChangedEventArgs(int month, int year, DateTime displayStartDate, DateTime displayEndDate)
		{
			this.month = month;
			this.year = year;
			this.displayStartDate = displayStartDate;
			this.displayEndDate = displayEndDate;
		}
		#endregion
	}
	#endregion

	#region XCalendarWeekDayClickEventArgs
	public class XCalendarWeekDayClickEventArgs : EventArgs
	{
		#region Fields and Properties
		private int day = 0;
		private MouseButtons button = MouseButtons.Left;
		public int Day
		{
			get { return day;}
		}

		public MouseButtons Button
		{
			get { return button;}
		}
		#endregion

		#region Constructor
		public XCalendarWeekDayClickEventArgs(int day, MouseButtons button)
		{
			this.day =day;
			this.button = button;
		}
		#endregion
	
	}
	#endregion

	#region XCalendarDayEventArgs
	
	public class XCalendarDayEventArgs : EventArgs
	{
		#region Fields and Properties
		private XDateItem dateItem;
		public XDateItem DateItem
		{
			get { return dateItem;}
		}
		#endregion

		#region Constructor
		public XCalendarDayEventArgs(XDateItem dateItem)
		{
			this.dateItem = dateItem;
		}
		#endregion
	}
	#endregion

	#region XCalendarDayClickEventArgs
	public class XCalendarDayClickEventArgs : EventArgs
	{
		#region Fields and Properties
		private XDateItem dateItem;
		private MouseButtons button;
		public XDateItem DateItem
		{
			get { return dateItem;}
		}
		public MouseButtons Button
		{
			get { return button;}
		}
		#endregion

		#region Constructor
		public XCalendarDayClickEventArgs(XDateItem dateItem, MouseButtons button)
		{
			this.dateItem =dateItem;
			this.button = button;
		}
		#endregion
	}
	#endregion

	#region XCalendarDaySelectedEventArgs
	
	public class XCalendarDaySelectedEventArgs : EventArgs
	{
		#region Fields and Properties
		XDateItemCollection dateItems;
		public XDateItemCollection DateItems
		{
			get { return dateItems;}
		}
		#endregion

		#region Constructor
		public XCalendarDaySelectedEventArgs(XDateItemCollection dateItems)
		{
			this.dateItems = dateItems;
		}
		#endregion
	}
	#endregion

	#region XCalendarDayDragDropEventArgs
	
	public class XCalendarDayDragDropEventArgs : EventArgs
	{

		#region Fields and Properties
		private XDateItem dateItem;
		private int keyState;
		private IDataObject data;
		public XDateItem DateItem
		{
			get { return dateItem;}
		}

		public int KeyState
		{
			get { return keyState;}
		}

		public IDataObject Data
		{
			get { return data;}
		}
		#endregion

		#region Constructor
		public XCalendarDayDragDropEventArgs(IDataObject data, int keystate , XDateItem dateItem)
		{
			this.dateItem = dateItem;
			this.data = data;
			this.keyState = keystate;	
		}
		#endregion
	}
	#endregion
	#endregion

	#region TypeConverter

	#region SimpleTypeConverter
	internal class SimpleTypeConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			return ""; 
		}
	}
	#endregion

	#region PaddingCollectionTypeConverter

	internal class PaddingCollectionTypeConverter : ExpandableObjectConverter
	{
			        	
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if(sourceType == typeof(string))
				return true;
			return base.CanConvertFrom (context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if(destinationType == typeof(string))
				return true;
			return base.CanConvertTo (context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
				
			if(value.GetType() == typeof(string))
			{
				// Parse property string
				string[] ss = value.ToString().Split(new char[] {';'}, 2);
				if (ss.Length==2)
				{
					// Create new PaddingCollection
					XCalendarMonth.PaddingCollection item = new XCalendarMonth.PaddingCollection((XCalendarMonth)context.Instance); 
					// Set properties
					item.Horizontal = int.Parse(ss[0]);
					item.Vertical = int.Parse(ss[1]); 
					return item;				
				}
			}
			return base.ConvertFrom (context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			//2;2형식으로 Display					
			if(destinationType == typeof(string) && (value is XCalendarMonth.PaddingCollection) )
			{
				// cast value to paddingCollection
				XCalendarMonth.PaddingCollection dest = (XCalendarMonth.PaddingCollection)value;  
				// create property string
				return dest.Horizontal.ToString()+";"+dest.Vertical.ToString();
			}
			return base.ConvertTo (context, culture, value, destinationType);
		}

	}
	#endregion

	#region XCalendarImageTypeConverter

	internal class XCalendarImageTypeConverter : TypeConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context,System.Globalization.CultureInfo culture,object value,Type destinationType)
		{
			if (value.ToString() == "-1")
			{
				return "(none)";
			}
			else
			{
				return value.ToString();
			}
			
		}
        	
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{

			if(destinationType == typeof(string))
				return true;
			return base.CanConvertTo (context, destinationType);

		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if(sourceType == typeof(string))
				return true;
			return base.CanConvertFrom (context, sourceType);

		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if(value.GetType() == typeof(string))
			{
				// none = -1 = no image
				if (( value.ToString().ToUpper().IndexOf("NONE") >=0) || (value.ToString()==""))
					return -1;
				return
					Convert.ToInt16(value.ToString()); 
			}
			return base.ConvertFrom (context, culture, value);
			
		}

	}
	#endregion

	#endregion

	#region XCalendarActiveMonth

	internal class XCalendarActiveMonth
	{
		#region Fields
		private int month;
		private int year;
		private XCalendar calendar = null;
		internal bool IsCallMonthChanged = true;
		#endregion

		#region Properties
		[Browsable(false)]
		internal XCalendar Calendar
		{
			get { return calendar;}
		}
		
		public int Month
		{
			get { return month;}
			set
			{
				if (month != value)
				{
					//2005.09.24 Month와 Year속성에서 각각 MonthChanged Event를 Call하게 되면
					//XCalendar의 NextButton,PrevButton을 누를때 2005/12-> 2006/01로 넘어갈때
					//MonthChanged Event가 2번 발생을 하게 된다.(Month도 다르고, Year도 다르므로)
					//따라서, Flag를 하나주어서 Event 발생이 한번만 될 수 있도록 해야한다.
					month = value;
					if (IsCallMonthChanged)
					{
						//선택된 달 SET
						calendar.Month.SelectedMonth = DateTime.Parse(year.ToString()+"-"+month.ToString()+"-01");
						calendar.Setup();
						if (MonthChanged!=null)
							MonthChanged(this,new XCalendarMonthChangedEventArgs(month,year, calendar.Month.DisplayStartDate, calendar.Month.DisplayEndDate));    
						calendar.Invalidate(); 
					}
							
				}
			}
		}
		
		public int Year
		{
			get
			{
				return year;
			}
			set
			{
				if (year != value)
				{
					year = value;
					//Flag가 있을 경우에만 발생시킴
					if (IsCallMonthChanged)
					{
						calendar.Month.SelectedMonth = DateTime.Parse(year.ToString()+"-"+month.ToString()+"-01");
						calendar.Setup();
						if (MonthChanged!=null)
							MonthChanged(this,new XCalendarMonthChangedEventArgs(month,year,calendar.Month.DisplayStartDate, calendar.Month.DisplayEndDate));    
						calendar.Invalidate();
					}
				}
			}
		}
		#endregion
		
		#region Event
		internal event XCalendarMonthChangedEventHandler MonthChanged;
		#endregion

		#region 생성자
		public XCalendarActiveMonth(XCalendar calendar)
		{
			this.calendar = calendar;
			year = DateTime.Now.Year;
			month = DateTime.Now.Month;
		}
		#endregion
		
		//XCalendar의 생성자에서 ActiveMonth 설정시에 사용
		internal void SetYearMonth(int year, int month)
		{
			this.year = year;
			this.month = month;
		}
	}
	#endregion

	#region XCalendarUtils
	internal class XCalendarUtils
	{
		//요일명을 관리하는 LIST (KEY는 0.일요일 - 6.토요일로 관리)
		public static Hashtable DayNameList = new Hashtable();
		static XCalendarUtils()
		{

			//요일이름 리스트 설정
			DayNameList.Add("0", new DayNameItem(XMsg.GetField("F013"),XMsg.GetField("F020")));
			DayNameList.Add("1", new DayNameItem(XMsg.GetField("F014"),XMsg.GetField("F021")));
			DayNameList.Add("2", new DayNameItem(XMsg.GetField("F015"),XMsg.GetField("F022")));
			DayNameList.Add("3", new DayNameItem(XMsg.GetField("F016"),XMsg.GetField("F023")));
			DayNameList.Add("4", new DayNameItem(XMsg.GetField("F017"),XMsg.GetField("F024")));
			DayNameList.Add("5", new DayNameItem(XMsg.GetField("F018"),XMsg.GetField("F025")));
			DayNameList.Add("6", new DayNameItem(XMsg.GetField("F019"),XMsg.GetField("F026")));
		}
	}
	#endregion

	#region DayNameItem (CultureInfo를 쓰면 일본OS, 한글 OS에 따라 요일표기가 바뀌므로 요일이름 Class로 관리)
	internal class DayNameItem
	{
		public string ShortName = "";  //단축, 한글명(일,월,화,수,목,금,토)
		public string LongName = "";   //요일포함(일요일, 월요일,...)
		public DayNameItem(string shortName, string longName)
		{
			ShortName = shortName;
			LongName  = longName;
		}
	}
	#endregion

	#region XDateItem

	public class XDateItem
	{
		private DateTime date = DateTime.Today;
		private DayOfWeek dayOfWeek = DayOfWeek.Sunday;
		private XDateKind dateKind = XDateKind.Ordinary;  //일종류(평일, 전체휴일,반휴일)
		private bool isLegalHoliday = false; //법정공휴일 여부

		public DateTime Date
		{
			get { return date;}
		}
		public DayOfWeek DayOfWeek
		{
			get { return dayOfWeek;}
		}
		public XDateKind DateKind
		{
			get { return dateKind;}
			set { dateKind = value;}
		}
		public bool IsLegalHoliday
		{
			get { return isLegalHoliday;}
			set { isLegalHoliday = value;}
		}

		public XDateItem(DateTime date, XDateKind dateKind, bool isLegalHoliday)
		{
			//DateTime은 Time을 기본으로 함 (Time을 동일하게 맞춤)
			this.date = DateTime.Parse(date.ToShortDateString());
			this.dayOfWeek = date.DayOfWeek;
			this.dateKind = dateKind;
			this.isLegalHoliday = isLegalHoliday;
		}
	}
	#endregion

	#region XDateItemCollection
	/// <summary>
	/// XDateItem 을 관리하는 컬렉션입니다.
	/// </summary>
	public class XDateItemCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 지정한 인덱스에 있는 XDateItem 가져옵니다.
		/// </summary>
		public XDateItem this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XDateItem)List[index];
			}
		}
		/// <summary>
		/// 지정한 key(string)에 해당하는 ComboItem을 가져옵니다.
		/// </summary>
		public XDateItem this[DateTime date]
		{
			get
			{
				DateTime dt = DateTime.Parse(date.ToShortDateString());
				foreach (XDateItem item in this)
					if (item.Date == dt) return item;

				return null;
			}
		}
		/// <summary>
		/// ComboItem을 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="comboItem"> ComboItem 개체 </param>
		/// <returns> 추가한 ComboItem 개체 </returns>
		public void Add(XDateItem dateItem)
		{
			//이미 포함되어 있으면 Return
			if (Contains(dateItem.Date)) return;
			List.Add(dateItem);
		}
		/// <summary>
		/// ComboItem[]를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="items"> ComboItem[] </param>
		public void AddRange(XDateItem[] items)
		{
			List.Clear();
			foreach (XDateItem Item in items)
				Add(Item);
		}
		
		public void Add(DateTime date, XDateKind dateKind, bool isLegalHoliday)
		{
			foreach (XDateItem item in List)
			{
				if (item.Date.ToShortDateString() == date.ToShortDateString())
					throw(new Exception("[XDateItem]이미 등록된 날짜과 동일합니다."));
			}
			XDateItem	dateItem = new XDateItem(date, dateKind, isLegalHoliday);
			List.Add(dateItem);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0) 
				return;
			else
				List.RemoveAt(index); 
		}
		/// <summary>
		/// 지정한 실제값의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="valueMember"> ComboItem.ValueItem </param>
		public void Remove(DateTime date)
		{
			DateTime dt = DateTime.Parse(date.ToShortDateString());
			for (int i = 0 ; i < this.Count ; i++)
			{
				if (this[i].Date == dt)
				{
					this.Remove(i);
					break;
				}
			}
		}
		public void Remove(XDateItem item)
		{
			Remove(item.Date);
		}
		/// <summary>
		/// 컬렉션에 속하는 XComboItem을 ComboItem[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XComboItem[] </returns>
		public XDateItem[] ToArray()
		{
			XDateItem[] dateArray = new XDateItem[List.Count];
			for (int i = 0; i < List.Count; i++)
				dateArray[i] = (XDateItem) List[i];
			return dateArray;
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="dataName"></param>
		/// <returns> PreDataItem가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(DateTime date)
		{
			DateTime dt = DateTime.Parse(date.ToShortDateString());
			foreach (XDateItem item in List)
				if (item.Date == date)
					return true;
			return false;
		}
		public bool Contains(XDateItem item)
		{
			return Contains(item.Date);
		}
	}
	#endregion

}


	