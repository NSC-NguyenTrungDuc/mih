using System;
using System.Drawing; 
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace IHIS.Framework
{
	/// <summary>
	/// XCalendarDay에 대한 요약 설명입니다.
	/// </summary>
	internal class XCalendarDay : IDisposable
	{
		#region Fields
		const int IMAGE_MARGIN = 2;
		private Rectangle dayRect;
		private Region dayRegion;
		private XDateItem dateItem;
		private XCalendar calendar = null;
		private XCalendarMonth month = null;
		private XCalendarDayState dayState = XCalendarDayState.Normal;
		private int row = 0;  //행좌표 위치
		private int col = 0;  //열좌표 위치
		#endregion

		#region properties
		internal XCalendar Calendar
		{
			get { return calendar;}
			set { calendar = value;}
		}

		internal XCalendarMonth Month
		{
			get { return month;}
			set { month = value;}
		}

		internal XCalendarDayState DayState
		{
			get { return dayState;}
			set { dayState = value;}
		}
		internal int Row   //해당날짜의 7*6에서의 행위치(0-5)
		{
			get { return row;}
			set { row = value;}
		}
		internal int Col  //해당날짜의 7*6에서의 열위치(0-6)
		{
			get { return col;}
			set { col = value;}
		}
		
		internal Rectangle DayRect
		{
			get { return dayRect;}
			set 
			{
				if (dayRect != value)
				{
					dayRect = value;
					this.dayRegion = new Region(dayRect);
				}
			}
		
		}

		internal XDateItem DateItem
		{
			get { return dateItem;}
			set { dateItem = value;}
		}
		#endregion

		#region 생성자
		public XCalendarDay()
		{
		}
		#endregion

		#region Dispose

		public void Dispose()
		{
			dayRegion.Dispose();
		}

		#endregion

		#region Methods
		private Image GetImage(int index)
		{
			// Check that an ImageList exists and that index is valid
			if (month.Calendar.ImageList != null)
			{
				if ((index>=0) && (index <month.Calendar.ImageList.Images.Count))
				{
					return month.Calendar.ImageList.Images[index]; 
				}
				else return null;
			}
			else return null;
					
		}
		
		private StringFormat GetStringAlignment(ContentAlignment align)
		{
			StringFormat sf = new StringFormat();
			sf.Trimming = StringTrimming.EllipsisCharacter;  //문자가 길면 ... 표시
 
			//StringFormat으로 Draw
			if (DrawHelper.IsTop(align))
				sf.LineAlignment = StringAlignment.Near;
			else if (DrawHelper.IsVCenter(align))
				sf.LineAlignment = StringAlignment.Center;
			else
				sf.LineAlignment = StringAlignment.Far;

			if (DrawHelper.IsLeft(align))
				sf.Alignment = StringAlignment.Near;
			else if (DrawHelper.IsHCenter(align))
				sf.Alignment = StringAlignment.Center;
			else
				sf.Alignment = StringAlignment.Far;
			
			return sf;
		}

		internal void Draw(Graphics e)
		{
			//선택된 날이거나 Trailing Date이면 Day Draw
			if ((month.SelectedMonth.Month != dateItem.Date.Month) && !month.Calendar.ShowTrailingDates)
				return;
			//Size는 MARGIN 적용하여 SET
			Rectangle imageRect = new Rectangle(dayRect.X + IMAGE_MARGIN,dayRect.Y + IMAGE_MARGIN,dayRect.Width - IMAGE_MARGIN*2 ,dayRect.Height - IMAGE_MARGIN*2);

			Brush dateBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.DateTextColor.Color)); 
			Brush bgBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.DateBackColor.Color));   
			Image  drawImage = null;

			//XDateKind에 따라 색깔 변경 (전체휴일은 일요일색, 반휴일은 토요일색, 평일은 일반색)
			if (dateItem.DateKind == XDateKind.FullHoliday)
			{
				bgBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.FullHolidayBackColor.Color));
				dateBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.FullHolidayTextColor.Color));
			}
			else if (dateItem.DateKind == XDateKind.HalfHoliday) //반휴일
			{
				bgBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.HalfHolidayBackColor.Color));
				dateBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.HalfHolidayTextColor.Color));
			}
			else if (month.SelectedMonth.Month  != dateItem.Date.Month)  //Trailing(TrailingDate라도 토,일요일은 동일하게 표시)
			{
				bgBrush = new SolidBrush(Color.FromArgb(month.Transparency, month.Colors.TrailingDateBackColor.Color)); 
				dateBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.TrailingDateTextColor.Color)); 
			}
			
			XCalendarDate dateInfo = calendar.Dates[dateItem.Date];
			
			// Check if there is formatting info about this day
			//if ((dateInfo != null) &&  (month.SelectedMonth.Month  == date.Month))
			if (dateInfo != null)
			{
				
				
				//Disabled 적용 -> 기본색이 아니면 적용
				if (!dateInfo.Enabled)
				{
					bgBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.DisabledDateBackColor.Color));	
					dateBrush = new SolidBrush(Color.FromArgb(month.Transparency,month.Colors.DisabledDateTextColor.Color));
				}
				else
				{
//					//기본색이 아니면 색깔 변경
//					//2005.11.18 기본색판단은 토요일,일요일,공휴일도 구분하여 판단함.
//					XColor bColor = XColor.XCalendarDateBackColor;
//					XColor tColor = XColor.XCalendarDateTextColor;
//					if (date.DayOfWeek == DayOfWeek.Saturday)
//					{
//						bColor = XColor.XCalendarSaturDayBackColor;
//						bColor = XColor.XCalendarSaturDayTextColor;
//					}
//					else if (date.DayOfWeek == DayOfWeek.Sunday)
//					{
//						bColor = XColor.XCalendarSunDayBackColor;
//						bColor = XColor.XCalendarSunDayTextColor;
//					}
//					//공휴일
//					if (calendar.DisplayHoliday && calendar.HolidayList.Contains(this.date))
//					{
//						bColor = XColor.XCalendarSunDayBackColor;
//						bColor = XColor.XCalendarSunDayTextColor;
//					}
					
					if (!dateInfo.BackColor.Equals(XColor.XCalendarDateBackColor))  
						bgBrush = new SolidBrush(Color.FromArgb(month.Transparency,dateInfo.BackColor.Color));
					if (!dateInfo.DateTextColor.Equals(XColor.XCalendarDateTextColor))  
						dateBrush = new SolidBrush(Color.FromArgb(month.Transparency,dateInfo.DateTextColor.Color));
				}
				drawImage = GetImage(dateInfo.ImageIndex);
			}
			
			//Image Draw
			if (drawImage != null)
			{
				PointF pointImage = DrawHelper.GetObjAlignment(dateInfo.ImageAlign,imageRect.Left, imageRect.Top, imageRect.Width, imageRect.Height, drawImage.Width, drawImage.Height);
				RectangleF iRectF = imageRect;
				iRectF.Intersect(new RectangleF(pointImage, drawImage.PhysicalDimension));
				imageRect = Rectangle.Truncate(iRectF);
			}

			//Fill
			e.FillRectangle(bgBrush,dayRect);
			//DrawBorder
			ControlPaint.DrawBorder(e,dayRect, month.Colors.DateBorderColor.Color , month.BorderStyles.DateBorder);
			//Image Draw
			if (drawImage != null)
			{
				if (dateInfo.Enabled)
					e.DrawImageUnscaled(drawImage, imageRect);
				else   //Disable
					ControlPaint.DrawImageDisabled(e , drawImage, imageRect.X,imageRect.Y, month.Colors.DisabledDateBackColor.Color);   
			}
        
			// Draw the day of month
			
			//Date Text Draw
			if (dateInfo == null)  //Month에 적용된 Font 적용
				e.DrawString(dateItem.Date.Day.ToString(), month.DateTextFont, dateBrush, dayRect, GetStringAlignment(month.DateTextAlign));
			else  //dateInfo에 적용된 Font, Align 적용
			{
				e.DrawString(dateItem.Date.Day.ToString(), dateInfo.DateFont, dateBrush, dayRect, GetStringAlignment(dateInfo.DateAlign));

				//Content가 있으면 Draw
                if (dateInfo.ContentText != "")
                {
                    StringFormat textFormat = GetStringAlignment(dateInfo.ContentAlign);
                    textFormat.Trimming = StringTrimming.EllipsisCharacter;  //Text가 길면 ...표시
                    //Image가 Top이면 이미지 아래에 Text 표시함 (Rect 조정)
                    Rectangle textRect = this.dayRect;

                    if ((drawImage != null) && DrawHelper.IsTop(dateInfo.ImageAlign))
                    {
                        textRect.Y += imageRect.Height + IMAGE_MARGIN * 2;
                        textRect.Height -= imageRect.Height + IMAGE_MARGIN * 2;
                    }
                    using (Brush br = new SolidBrush(Color.FromArgb(month.Transparency, dateInfo.ContentTextColor.Color)))
                    {
                        if (dateInfo.ContentMultiLine)
                        {
                            string[] lines = Regex.Split(dateInfo.ContentText, "\r\n");
                            Brush brline = new SolidBrush(Color.FromArgb(month.Transparency, dateInfo.ContentTextColorMultiLine.Color));
                            for (int i = 0; i < lines.Length; i++)
                            {
                                string content = lines[i];
                                for (int j = i; j < lines.Length - 1; j++)
                                {
                                    content += "\r\n ";
                                }
                                if (i == 0)
                                {
                                    e.DrawString(content, dateInfo.ContentFont, br, textRect, textFormat);
                                }
                                else
                                {
                                    e.DrawString(content, dateInfo.ContentFont, brline, textRect, textFormat);
                                }
                            }

                        }
                        else
                        {
                            e.DrawString(dateInfo.ContentText, dateInfo.ContentFont, br, textRect, textFormat);
                        }
                    }

                }
			}
			//SELECT상태일때 반영
			if (dayState == XCalendarDayState.Selected)
			{
				using (Brush selBrush = new SolidBrush(Color.FromArgb(125, this.Month.Colors.SelectedDateBackColor.Color)))  
					e.FillRectangle(selBrush, this.dayRect); 
				//Border Draw
				ControlPaint.DrawBorder(e, dayRect, Month.Colors.SelectedDateBorderColor.Color , Month.BorderStyles.SelectedDateBorder);
			}
//			else if (month.Calendar.ShowFocus) //FOCUS가 갈때 FOCUS DAY를 보여주면
//			{
//				// Check if day has focus
//				if (dayState == XCalendarDayState.Focus)
//				{
//					using (Brush br = new SolidBrush(Color.FromArgb(125,month.Colors.FocusDateBackColor.Color)))
//						e.FillRectangle(br , dayRect);
//
//					//Border
//					ControlPaint.DrawBorder(e,dayRect,month.Colors.FocusDateBorderColor.Color ,month.BorderStyles.FocusDateBorder);
//				}
//			}
			dateBrush.Dispose();
		}

		internal bool HitTest(Point p)
		{
			if (dayRegion.IsVisible(p))
				return true;
			else
				return false;
		}
		#endregion
	}
}
