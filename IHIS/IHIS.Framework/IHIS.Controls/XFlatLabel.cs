using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// ADisplayBox에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.Label))]
	public class XFlatLabel : System.Windows.Forms.Label
	{
		#region Class Variables
		private XColor xBackColor		= XColor.XLabelBackColor;
		private XColor xForeColor		= XColor.XLabelForeColor;
		#endregion

		#region base 속성 재정의
		[DefaultValue(typeof(XColor),"XLabelBackColor"),
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
		[DefaultValue(typeof(XColor),"XLabelForeColor"),
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
		//TextAlign 기본속성
		/// <summary>
		/// 텍스트 맞춤을 가져오거나 설정합니다.(Default Value 재정의)
		/// </summary>
		[DefaultValue(ContentAlignment.MiddleLeft)]
		public new ContentAlignment TextAlign
		{
			get {return base.TextAlign;}
			set {base.TextAlign = value;}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Constructor(s)
		/// <summary>
		/// ADisplayBox 생성자
		/// </summary>
		public XFlatLabel()
		{
			// 2005/05/09 신종석 폰트 수정
			this.Font = new Font("MS UI Gothic", 9.75f);
			this.TextAlign = ContentAlignment.MiddleLeft;
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