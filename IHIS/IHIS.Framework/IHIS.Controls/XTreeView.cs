using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XTreeView에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.TreeView))]
	public class XTreeView : System.Windows.Forms.TreeView
	{
		#region Fields
		private XColor xBackColor				= XColor.XTreeViewBackColor;
		private XColor xForeColor				= XColor.NormalForeColor;
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XTreeViewBackColor"),
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
		public XTreeView()
		{
			//Default 색 지정
			this.BackColor = XColor.XTreeViewBackColor;
			this.ForeColor = XColor.NormalForeColor;

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
