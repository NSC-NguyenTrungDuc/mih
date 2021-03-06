using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XCalendarHeader에 대한 요약 설명입니다.
	/// </summary>
	[TypeConverter(typeof(SimpleTypeConverter))]
	public class XCalendarHeader : IDisposable
	{
		#region Fields
		
		private XCalendar calendar = null;
		private XColor backColor = XColor.XCalendarHeaderBackColor;
		private XColor textColor = XColor.XCalendarHeaderTextColor;
		private Font font = new Font("MS UI Gothic", 9.75f, FontStyle.Bold);
		private Rectangle headerRect = Rectangle.Empty;
		private Rectangle rigthBtnRect= Rectangle.Empty;
		private Rectangle leftBtnRect= Rectangle.Empty;
		private ButtonState leftBtnState = ButtonState.Normal;
		private ButtonState rightBtnState = ButtonState.Normal;
		private string headerText = "";
		private HorizontalAlignment textAlign = HorizontalAlignment.Center;
		private bool showMonth = true;
		private bool showSelectors = true;
		private Region headerRegion;
		private Region leftBtnRegion;
		private Region rightBtnRegion;
		private StringFormat textFormat = new StringFormat();
		#endregion

		#region Properties
		internal Rectangle HeaderRect
		{
			get	{ return headerRect;}
			set
			{
				if (headerRect != value)
				{
					headerRect = value;
					leftBtnRect = new Rectangle(10,5,20,20);
					rigthBtnRect = new Rectangle(headerRect.Width-30,5,20,20);
					//Region 설정
					headerRegion = new Region(headerRect);
					leftBtnRegion = new Region(leftBtnRect);
					rightBtnRegion = new Region(rigthBtnRect);
				}
			}
		}

		[Description("Text의 Aligment를 지정합니다.")]
		[DefaultValue(HorizontalAlignment.Center)]
		public HorizontalAlignment TextAlign
		{
			get { return textAlign;}
			set
			{
				if (textAlign!=value)
				{
					textAlign = value;
					calendar.Invalidate(this.headerRect);
				}
			}
		}
		
		[Description("Prev, Next 버튼을 보여줄지 여부를 지정합니다.")]
		[DefaultValue(true)]
		public bool ShowSelectors
		{
			get { return showSelectors;}
			set
			{
				if (showSelectors!=value)
				{
					showSelectors = value;
					if (showSelectors)
					{
						leftBtnRect = new Rectangle(10,5,20,20);
						rigthBtnRect = new Rectangle(headerRect.Width-30,5,20,20);
						//Region SET
						leftBtnRegion = new Region(leftBtnRect);
						rightBtnRegion = new Region(rigthBtnRect);
					}
					else
					{
						leftBtnRect = Rectangle.Empty;
						rigthBtnRect = Rectangle.Empty;
						leftBtnRegion = new Region(Rectangle.Empty);
						rightBtnRegion = new Region(Rectangle.Empty);
					}
					calendar.Invalidate(this.headerRect);
				}
			}
		}

		[Description("현재선택된 달을 보여줄지 여부를 지정합니다.")]
		[DefaultValue(true)]
		public bool ShowMonth
		{
			get	{ return showMonth;}
			set
			{
				if (showMonth!=value)
				{
					showMonth = value;
					calendar.Invalidate(this.headerRect);
				}
			}
		}

		[Description("Header에 Display할 Text를 지정합니다.")]
		[DefaultValue("")]
		public string HeaderText
		{
			get { return headerText; }
			set
			{
				if (headerText!=value)
				{
					headerText = value;
					calendar.Invalidate(this.headerRect);
				}
			}
		}

		[DefaultValue(typeof(XColor),"XCalendarHeaderBackColor"),
		Description("배경색을 지정합니다.")]
		public XColor BackColor
		{
			get { return backColor; }
			set
			{
				if (backColor!=value)
				{
					backColor = value;
					calendar.Invalidate(this.headerRect);
				}
			}
		}
		[DefaultValue(typeof(XColor),"XCalendarHeaderTextColor"),
		Description("텍스트을 지정합니다.")]
		public XColor TextColor
		{
			get { return textColor; }
			set
			{
				if (textColor!=value)
				{
					textColor = value;
					calendar.Invalidate(this.headerRect);
				}
			}
		}
		[Description("헤더의 폰트를 지정합니다.")]
		[DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt, style=Bold")]
		public Font Font
		{
			get	{ return font; }
			set
			{
				if (font!=value)
				{
					font = value;
					//Layout 다시 설정
					calendar.DoLayout();
					calendar.Invalidate(this.headerRect);
				}
			}
		}
		#endregion

		#region Eventhandlers
		internal event XCalendarClickEventHandler Click;
		internal event XCalendarClickEventHandler DoubleClick;
		internal event EventHandler PrevButtonClick;
		internal event EventHandler NextButtonClick;
		#endregion
		
		#region 생성자
		public XCalendarHeader(XCalendar calendar)
		{
			this.calendar = calendar;

            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.font = Service.COMMON_FONT_BOLD;
            }
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			try
			{
				font.Dispose();
				headerRegion.Dispose();
				leftBtnRegion.Dispose();
				rightBtnRegion.Dispose();
			}
			catch{}

		}
		#endregion

		#region Methods
		internal void MouseClick(Point mouseLocation, MouseButtons button, bool isDoubleClick)
		{
			bool btnClick = false;
			
			//현재 Mouse Point가 Header 영역이면
			if (headerRegion.IsVisible(mouseLocation))
			{
				if (ShowSelectors)
				{
					//Left Button 영역
					if ((leftBtnRegion.IsVisible(mouseLocation) && leftBtnState != ButtonState.Inactive))
					{
						leftBtnState = ButtonState.Pushed;
						if (this.PrevButtonClick!=null)
							this.PrevButtonClick(this,EventArgs.Empty);
						calendar.Invalidate(this.headerRect);
						btnClick = true;
					}
					if ((rightBtnRegion.IsVisible(mouseLocation) && rightBtnState != ButtonState.Inactive))
					{
						rightBtnState = ButtonState.Pushed;
						if (this.NextButtonClick!=null)
							this.NextButtonClick(this, EventArgs.Empty);
						calendar.Invalidate(this.headerRect);
						btnClick = true;
					}
				}
				if (!isDoubleClick)
				{
					if ((this.Click!=null) && (!btnClick))
						this.Click(this,new XCalendarClickEventArgs(button));
				}
				else
				{
					if ((this.DoubleClick!=null) && (!btnClick))
						this.DoubleClick(this,new XCalendarClickEventArgs(button));	
				}
			}
		}

		internal void MouseUp()
		{
			if (ShowSelectors)
			{
				string minMonth ;
				string maxMonth;
				string currentMonth;
				
				currentMonth = calendar.Month.SelectedMonth.Year.ToString()+"-"+calendar.Month.SelectedMonth.Month.ToString();
				minMonth = calendar.MinDate.Year.ToString()+"-"+calendar.MinDate.Month.ToString();
				maxMonth = calendar.MaxDate.Year.ToString()+"-"+calendar.MaxDate.Month.ToString();
				
				if (minMonth == currentMonth)
					leftBtnState = ButtonState.Inactive;
				else
					leftBtnState = ButtonState.Normal;
				if (maxMonth == currentMonth)
					rightBtnState = ButtonState.Inactive;
				else
					rightBtnState = ButtonState.Normal;
						
				// if mouse button is released no button should be pushed
				if (leftBtnState != ButtonState.Inactive) leftBtnState = ButtonState.Normal;
				if (rightBtnState != ButtonState.Inactive) rightBtnState = ButtonState.Normal;
		
			}
		}

		internal void MouseMove(Point mouseLocation)
		{
			if (ShowSelectors)
			{
				// Left 영역안에 Mouse가 있으면 Hover상태로 변경
				if (leftBtnRegion.IsVisible(mouseLocation))
				{
					if (leftBtnState != ButtonState.Inactive)
					{
						leftBtnState = ButtonState.Checked;  //Hover 상태
						calendar.Invalidate(this.headerRect);
					}
				}
				else  if (rightBtnRegion.IsVisible(mouseLocation))  //Next영역에 있으면 Next는 Hover
				{
					if (rightBtnState != ButtonState.Inactive)
					{
						rightBtnState = ButtonState.Checked; //Hover 상태
						calendar.Invalidate(this.headerRect);
					}
				}
				else  //두 영역 모두 없으면 Normal 상태로 변경
				{
					if (leftBtnState != ButtonState.Inactive)
						leftBtnState = ButtonState.Normal;  //Normal 상태
					if (rightBtnState != ButtonState.Inactive)
						rightBtnState = ButtonState.Normal; //Normal 상태
					calendar.Invalidate(this.headerRect);

				}
			}

			if (headerRegion.IsVisible(mouseLocation))
				calendar.ActiveRegion = XCalendarRegion.Header;
		}
		
		internal void Draw(Graphics e)
		{
			Brush textBrush = new SolidBrush(TextColor.Color);
			
			Rectangle txtRect;
			string month;
	
			textFormat.LineAlignment = StringAlignment.Center;
			switch (TextAlign)
			{
				case HorizontalAlignment.Center:
				{
					textFormat.Alignment = StringAlignment.Center;
					break;
				}
				case HorizontalAlignment.Left:
				{
					textFormat.Alignment = StringAlignment.Near;
					break;
				}
				case HorizontalAlignment.Right:
				{
					textFormat.Alignment = StringAlignment.Far;
					break;
				}
			}
			//Fill Rect
			using (Brush bgBrush = new SolidBrush(BackColor.Color))
				e.FillRectangle(bgBrush,headerRect);

			if (ShowSelectors)
			{
				txtRect = new Rectangle(leftBtnRect.Right + 2,0,headerRect.Width - (2*leftBtnRect.Right) - 4,headerRect.Height); 
				
				//상태에 따라 Image Set
				Image prevImage = null, nextImage = null;
				if (leftBtnState == ButtonState.Normal)  //Normal
					prevImage = DrawHelper.PrevNImage;
				else if (leftBtnState == ButtonState.Checked)  //Hover
					prevImage = DrawHelper.PrevHImage;
				else if (leftBtnState == ButtonState.Pushed)  //Pushed
					prevImage = DrawHelper.PrevPImage;
				else //Inactive
					prevImage = DrawHelper.PrevNImage;

				if (rightBtnState == ButtonState.Normal)  //Normal
					nextImage = DrawHelper.NextNImage;
				else if (rightBtnState == ButtonState.Checked)  //Hover
					nextImage = DrawHelper.NextHImage;
				else if (rightBtnState == ButtonState.Pushed)  //Pushed
					nextImage = DrawHelper.NextPImage;
				else //Inactive
					nextImage = DrawHelper.NextNImage;


				//Image로 설정하는 것은 나중에 확인하여 반영하기(Hover, Push, Normal Image가 필요함)
				PointF pointImageP = DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter,leftBtnRect.Left, leftBtnRect.Top, leftBtnRect.Width, leftBtnRect.Height, prevImage.Width, prevImage.Height);
				PointF pointImageN = DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter,rigthBtnRect.Left, rigthBtnRect.Top, rigthBtnRect.Width, rigthBtnRect.Height, nextImage.Width, nextImage.Height);
				RectangleF iRectP = leftBtnRect;
				RectangleF iRectN = rigthBtnRect;
				iRectP.Intersect(new RectangleF(pointImageP, prevImage.PhysicalDimension));
				iRectN.Intersect(new RectangleF(pointImageN, nextImage.PhysicalDimension));
				Rectangle imageRectP = Rectangle.Truncate(iRectP);
				Rectangle imageRectN = Rectangle.Truncate(iRectN);
				if (calendar.Enabled)
				{
					if (leftBtnState == ButtonState.Inactive)  //Inactive
					{
						ControlPaint.DrawImageDisabled(e, prevImage, imageRectP.X, imageRectP.Y, this.backColor.Color);
						e.DrawImageUnscaled(nextImage,imageRectN);
					}
					else if (rightBtnState == ButtonState.Inactive)
					{
						e.DrawImageUnscaled(prevImage,imageRectP); 
						ControlPaint.DrawImageDisabled(e, nextImage, imageRectN.X, imageRectN.Y, this.backColor.Color);
					}
					else
					{
						e.DrawImageUnscaled(prevImage,imageRectP); 
						e.DrawImageUnscaled(nextImage,imageRectN);
					}
//					ControlPaint.DrawScrollButton(e,leftBtnRect,ScrollButton.Left,leftBtnState);
//					ControlPaint.DrawScrollButton(e,rigthBtnRect,ScrollButton.Right,rightBtnState);
				}
				else
				{
					ControlPaint.DrawImageDisabled(e, prevImage, imageRectP.X, imageRectP.Y, BackColor.Color);
					ControlPaint.DrawImageDisabled(e, nextImage, imageRectN.X, imageRectN.Y, BackColor.Color);
//					ControlPaint.DrawScrollButton(e,leftBtnRect,ScrollButton.Left,ButtonState.Inactive);
//					ControlPaint.DrawScrollButton(e,rigthBtnRect,ScrollButton.Right,ButtonState.Inactive);
				}
			}
			else
				txtRect = new Rectangle(headerRect.Left + 2,0,headerRect.Width - (2*2),headerRect.Height);

			
			//2006.01.13 일본와력표시 속성 추가
            if (!calendar.IsJapanYearType)
            {
                month = calendar.Month.SelectedMonth.Year.ToString() + "/" + calendar.Month.SelectedMonth.Month.ToString("00");                
            }
            else
            {
                //YYYYMM 형식을 일본와력으로 변경
                month = calendar.Month.SelectedMonth.Year.ToString() + calendar.Month.SelectedMonth.Month.ToString("00");
                month = JapanYearHelper.GetDisplayText(MaskType.Month, month);
            }

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "vi-VN")
            {
                month = calendar.GetCalendarDateTime().ToString(MaskHelper.ViMonhMask);
            }

			//Text가 있으면 Text Draw하고 ShowMonth이면 ( 2005/01 )로 표시
			if (this.headerText != "")
			{
				string text = this.headerText;
				if (ShowMonth)
					text += " ( " + month + " ) ";
				e.DrawString(text,Font,textBrush,txtRect,textFormat);
			}
			else if (ShowMonth)
				e.DrawString(month,Font,textBrush,txtRect,textFormat); 
						
			textBrush.Dispose();
		}

		#endregion
	}
}
