using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// AListBox에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.MonthCalendar))]
	public class XMonthCalendar : System.Windows.Forms.MonthCalendar
	{
		#region Fields
		private XColor xBackColor				= XColor.XMonthCalendarBackColor;
		private XColor xForeColor				= XColor.NormalForeColor;
		private XColor xTitleBackColor			= XColor.XMonthCalendarTitleBackColor;
		private XColor xTitleForeColor			= XColor.XMonthCalendarTitleForeColor;
		private XColor xTrailingForeColor		= XColor.XMonthCalendarTrailingForeColor;
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XMonthCalendarBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"NormalForeColor"),
		Description("텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XMonthCalendarTitleBackColor"),
		Description("Title 배경색을 지정합니다.")]
		public new XColor TitleBackColor
		{
			get { return xTitleBackColor;}
			set 
			{
				xTitleBackColor = value;
				base.TitleBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XMonthCalendarTitleForeColor"),
		Description("Title 텍스트색을 지정합니다.")]
		public new XColor TitleForeColor
		{
			get { return xTitleForeColor;}
			set 
			{
				xTitleForeColor = value;
				base.TitleForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XMonthCalendarTrailingForeColor"),
		Description("이전달과 다음달 날짜의 텍스트색을 지정합니다.")]
		public new XColor TrailingForeColor
		{
			get { return xTrailingForeColor;}
			set 
			{
				xTrailingForeColor = value;
				base.TrailingForeColor = value.Color;
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region 생성자
		public XMonthCalendar()
		{
			//Default 색 지정
			this.BackColor = XColor.XMonthCalendarBackColor;
			this.ForeColor = XColor.NormalForeColor;
			this.TitleBackColor = XColor.XMonthCalendarTitleBackColor;
			this.TitleForeColor = XColor.XMonthCalendarTitleForeColor;
			this.TrailingForeColor = XColor.XMonthCalendarTrailingForeColor;

			// 2005/05/09 신종석 폰트 수정
			//this.Font = new Font("MS UI Gothic", 9.75f);

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }
		}
		#endregion

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			if (base.ForeColor != xForeColor.Color)
				base.ForeColor = xForeColor.Color;

			base.OnPaint(e);
		}
		#endregion
	}
}
