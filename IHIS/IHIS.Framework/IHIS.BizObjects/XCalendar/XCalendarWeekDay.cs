using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace IHIS.Framework
{
	/// <summary>
	/// XCalendarWeekDay에 대한 요약 설명입니다.
	/// </summary>
	[TypeConverter(typeof(SimpleTypeConverter))]
	public class XCalendarWeekDay
	{
		#region Fields
		private XCalendar calendar = null;
		private XColor backColor = XColor.XCalendarWeekDayBackColor;
		private XColor textColor = XColor.XCalendarWeekDayTextColor;
		private Font font = new Font("MS UI Gothic", 8.25f);
		private XCalendarDayFormat dayFormat = XCalendarDayFormat.Short;
		private HorizontalAlignment textAlign = HorizontalAlignment.Center;
		private Rectangle weekDayRect = Rectangle.Empty;
		private Region    weekDayRegion;  //WeekDay 영역
		private StringFormat textFormat = new StringFormat();
		#endregion

		#region Properties
		internal Rectangle WeekDayRect
		{
			get { return weekDayRect;}
			set 
			{ 
				if (weekDayRect != value)
				{
					weekDayRect = value;
					weekDayRegion = new Region(weekDayRect);  //영역 SET
				}
			}
		}
		[Description("요일을 약식으로(월,화)로 표시할지 전체(월요일)로 표시할지의 Format을 설정합니다.")]
		[DefaultValue(XCalendarDayFormat.Short)]
		public XCalendarDayFormat Format
		{
			get { return dayFormat;}
			set
			{
				if (dayFormat!=value)
				{
					dayFormat = value;
					calendar.Invalidate(this.weekDayRect);
				}
			}
		}
		[Description("Text의 Aligment를 지정합니다.")]
		[DefaultValue(HorizontalAlignment.Center)]
		public HorizontalAlignment TextAlign
		{
			get	{ return textAlign;	}
			set
			{
				if (textAlign!=value)
				{
					textAlign = value;
					calendar.Invalidate(this.weekDayRect);
				}
			}
		}
		
		[Description("Footer 폰트를 지정합니다.")]
		[DefaultValue(typeof(Font),"MS UI Gothic, 8.25pt")]
		public Font Font
		{
			get	{ return font;}
			set
			{
				if (font!=value)
				{
					font = value;
					calendar.DoLayout();
					calendar.Invalidate(this.weekDayRect);
				}
			}
		}
		[DefaultValue(typeof(XColor),"XCalendarWeekDayBackColor"),
		Description("배경색을 지정합니다.")]
		public XColor BackColor
		{
			get { return backColor;	}
			set
			{
				if (backColor!=value)
				{
					backColor = value;
					calendar.Invalidate(this.weekDayRect);
				}
			}
		}
		[DefaultValue(typeof(XColor),"XCalendarWeekDayTextColor"),
		Description("텍스트을 지정합니다.")]
		public XColor TextColor
		{
			get { return textColor;	}
			set
			{
				if (textColor!=value)
				{
					textColor = value;
					calendar.Invalidate(this.weekDayRect);
				}
			}
		}

		#endregion

		#region Events
		internal event XCalendarWeekDayClickEventHandler Click;
		internal event XCalendarWeekDayClickEventHandler DoubleClick;
		#endregion

		#region 생성자
		public XCalendarWeekDay(XCalendar calendar)
		{
			this.calendar = calendar;

            // MED-14286
            if (NetInfo.Language != LangMode.Jr && EnvironInfo.CurrSystemID == "OCSO")
            {
                this.font = new Font("Arial", 7, FontStyle.Bold);
            }
            else
            {
                this.font = new Font("Arial", 8, FontStyle.Bold);
            }                     
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			try
			{
				font.Dispose();
				weekDayRegion.Dispose();
			}
			catch{}
		}
		#endregion

		#region Methods
		
		internal void MouseMove(Point mouseLocation)
		{
			//달력의 현재 위치 영역을 WeekDays로 SET
			if (weekDayRegion.IsVisible(mouseLocation))
				calendar.ActiveRegion = XCalendarRegion.Weekdays;  
		}


		internal void MouseClick(Point mouseLocation,MouseButtons button, bool isDoubleClick)
		{
			if (weekDayRegion.IsVisible(mouseLocation))
			{
				int day;
				day = (mouseLocation.X / (int)calendar.Month.DayWidth);
				if (!isDoubleClick)
				{
					if (this.Click!=null)
						this.Click(this,new XCalendarWeekDayClickEventArgs(day,button)); 
				}
				else
				{
					if (this.DoubleClick!=null)
						this.DoubleClick(this,new XCalendarWeekDayClickEventArgs(day,button));
				}
		
			}
		}

		internal void Draw(Graphics e)
		{
			Rectangle dayRect = Rectangle.Empty;  //한날짜의 Draw Rect
			int dayWidth = (int)calendar.Month.DayWidth; //달력에서 Day의 길이
			int paddingX = calendar.Month.Padding.Horizontal;

			Brush headerTextBrush = new SolidBrush(this.TextColor.Color);
			Brush saturDayTextBrush = new SolidBrush(XColor.XCalendarHalfHolidayTextColor.Color);
			Brush sunDayTextBrush = new SolidBrush(XColor.XCalendarFullHolidayTextColor.Color);
			
			textFormat.LineAlignment = StringAlignment.Center;
			// Draw header
			switch (TextAlign)
			{
				case HorizontalAlignment.Left:
				{
					textFormat.Alignment = StringAlignment.Near;
					break;
				}
				case HorizontalAlignment.Center:
				{
					textFormat.Alignment = StringAlignment.Center;
					break;
				}
				case HorizontalAlignment.Right:
				{
					textFormat.Alignment = StringAlignment.Far;
					break;
				}
			}
			//Fill WeekDay 영역	
			using (Brush headerBrush = new SolidBrush(this.BackColor.Color))
				e.FillRectangle(headerBrush,0,weekDayRect.Top,calendar.Width,weekDayRect.Height);
			
			string text = "";
			DayNameItem item = null;
			//LOOP를 돌면서 한 요일씩 DrawString
			for (int i = 0 ; i < XCalendarUtils.DayNameList.Count ; i++)
			{
				item = XCalendarUtils.DayNameList[i.ToString()] as DayNameItem;
				dayRect.Y = weekDayRect.Y;
				dayRect.Width = dayWidth; 
				dayRect.Height = weekDayRect.Height;
				dayRect.X = (dayWidth * i) + (paddingX * (i + 1)) + weekDayRect.X;
				text = (this.dayFormat == XCalendarDayFormat.Short ? item.ShortName : item.LongName);
				if (i == 0)  //SunDay
					e.DrawString(text ,this.Font,sunDayTextBrush,dayRect,textFormat);
				else if (i == 6)  //SaturDay
                    e.DrawString(text ,this.Font,saturDayTextBrush,dayRect,textFormat);
				else
					e.DrawString(text ,this.Font,headerTextBrush,dayRect,textFormat);
			}
			//마지막에 LINE 그림
			using (Pen linePen = new Pen(Color.DarkGray,1))
				e.DrawLine(linePen,weekDayRect.X,weekDayRect.Bottom-1,weekDayRect.Right,weekDayRect.Bottom-1); 
			
			// Dispose
			headerTextBrush.Dispose();
			saturDayTextBrush.Dispose();
			sunDayTextBrush.Dispose();
		}

		#endregion
	}
}
