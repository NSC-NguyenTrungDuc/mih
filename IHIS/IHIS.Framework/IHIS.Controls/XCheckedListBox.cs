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
	/// XListBox에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.CheckedListBox))]
	public class XCheckedListBox : System.Windows.Forms.CheckedListBox
	{
		#region Fields
		private XColor xBackColor				= XColor.XListBoxBackColor;
		private XColor xForeColor				= XColor.NormalForeColor;
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XListBoxBackColor"),
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
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region 생성자
		public XCheckedListBox()
		{
			//Default 색 지정
			this.BackColor = XColor.XListBoxBackColor;
			this.ForeColor = XColor.NormalForeColor;

			// 2005/05/09 신종석 폰트 수정
			this.Font = new Font("MS UI Gothic", 9.75f);
		}
		#endregion

		#region OnParentBackColorChanged
		protected override void OnParentBackColorChanged(EventArgs e)
		{
			//ColorStyle 적용 (자세한 설명은 XTrackBar::OnParentBackColorChanged 참조)
			base.BackColor = this.xBackColor.Color;
			base.ForeColor = this.xForeColor.Color;
			base.OnParentBackColorChanged(e);
		}
		#endregion
	}
}
