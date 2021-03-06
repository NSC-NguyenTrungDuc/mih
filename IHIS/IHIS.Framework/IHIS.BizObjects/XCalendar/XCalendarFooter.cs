using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XCalendarFooter에 대한 요약 설명입니다.
	/// </summary>
	[TypeConverter(typeof(SimpleTypeConverter))]
	public class XCalendarFooter : IDisposable
	{
		#region Fields
		private XCalendar calendar = null;
		private XColor backColor = XColor.XCalendarFooterBackColor;
		private XColor textColor = XColor.XCalendarFooterTextColor;
		private Font font = new Font("MS UI Gothic", 9.75f, FontStyle.Bold);
		private string footerText = "";
		private bool showToday = true;
		private Rectangle footerRect = Rectangle.Empty;
		private HorizontalAlignment textAlign = HorizontalAlignment.Left;
		private Region footerRegion;
		private StringFormat textFormat = new StringFormat();
		#endregion
		
		#region Properties
		internal Rectangle FooterRect
		{
			get	{ return footerRect;}
			set	
			{ 
				if (footerRect != value)
				{
					footerRect = value;
					//Footer 영역 설정
					footerRegion = new Region(footerRect);
				}
			}
		}
		
		[Description("Text의 Aligment를 지정합니다.")]
		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment TextAlign
		{
			get	{ return textAlign; }
			set
			{
				if (textAlign!=value)
				{
					textAlign = value;
					calendar.Invalidate(this.footerRect);
				}
			}
		}

		[Description("Footer의 Text를 지정합니다.")]
		[DefaultValue("")]
		public string FooterText
		{
			get	{ return footerText;}
			set
			{
				if (value!=footerText)
				{
					footerText = value;
					calendar.Invalidate(this.footerRect);
				}
			}

		}

		[Description("오늘날짜를 보여줄지 여부를 설정합니다.")]
		[DefaultValue(true)]
		public bool ShowToday
		{
			get { return showToday; }
			set
			{
				if (value!=showToday)
				{
					showToday = value;
					calendar.Invalidate(this.footerRect);
				}
			}

		}
		[DefaultValue(typeof(XColor),"XCalendarFooterBackColor"),
		Description("배경색을 지정합니다.")]
		public XColor BackColor
		{
			get { return backColor; }
			set
			{
				if (backColor!=value)
				{
					backColor = value;
					calendar.Invalidate(this.footerRect);
				}
			}
		}
		[DefaultValue(typeof(XColor),"XCalendarFooterTextColor"),
		Description("텍스트을 지정합니다.")]
		public XColor TextColor
		{
			get	{ return textColor;	}
			set
			{
				if (textColor!=value)
				{
					textColor = value;
					calendar.Invalidate(this.footerRect);
				}
			}
		}
		[Description("Footer 폰트를 지정합니다.")]
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
					calendar.Invalidate(this.footerRect);
				}
			}
		}
		
		
		#endregion

		#region EventHandlers
		internal event XCalendarClickEventHandler Click;
		internal event XCalendarClickEventHandler DoubleClick;
		#endregion

		#region 생성자
		public XCalendarFooter(XCalendar calendar)
		{
			this.calendar = calendar;
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			try
			{
				font.Dispose();
				footerRegion.Dispose();
			}
			catch{}
		}
		#endregion

		#region Methods
		internal void MouseMove(Point mouseLocation)
		{
			if (footerRegion.IsVisible(mouseLocation))
			{
				calendar.ActiveRegion = XCalendarRegion.Footer;
			}
		}

		internal void MouseClick(Point mouseLocation, MouseButtons button, bool isDoubleClick)
		{
			if (footerRegion.IsVisible(mouseLocation))
			{
				if (!isDoubleClick)
				{
					if (this.Click!=null)
						this.Click(this,new XCalendarClickEventArgs(button));
				}
				else
				{
					if (this.DoubleClick!=null)
						this.DoubleClick(this,new XCalendarClickEventArgs(button));
				}
			}
		}


		internal void Draw(Graphics e)
		{
			Brush textBrush = new SolidBrush(TextColor.Color); 
			Rectangle txtRect;
			
			//Fill Footer Rect
			using (Brush bgBrush = new SolidBrush(BackColor.Color))
				e.FillRectangle(bgBrush,footerRect);
			
			textFormat.LineAlignment = StringAlignment.Center;
			textFormat.Alignment = StringAlignment.Near;
			
			txtRect = new Rectangle(footerRect.Left + 2,footerRect.Top,footerRect.Width - (2*2),footerRect.Height);
			if (showToday)  //오늘날짜는 좌측에 표시
			{
				//오늘날짜 Draw(YYYY/MM/DD형식으로)
				string today = DateTime.Today.ToString("yyyy/MM/dd").Replace("-","/");

				//2006.01.13 Calendar의 일본와력표시 속성 추가
				if (this.calendar.IsJapanYearType)
				{
					today = JapanYearHelper.GetDisplayText(MaskType.Date, today);
				}
				Size todaySize = DrawHelper.GetTextSize(e, today, Font);
				e.DrawString(today, Font, textBrush, txtRect, textFormat);
				//textRect의 Width를 todaySize만큼 줄여서 옆에 보여줌
				txtRect.X += todaySize.Width + 2;
				txtRect.Width -= todaySize.Width + 2;
			}

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
			//Text Draw
			e.DrawString(footerText ,Font,textBrush,txtRect,textFormat);

			// Clean up
			textBrush.Dispose();
		}
		#endregion
	}
}
