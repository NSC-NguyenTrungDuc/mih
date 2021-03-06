using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XTabControl에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(true)]
	public class XTabControl : IHIS.X.Magic.Controls.TabControl
	{
		private bool	executeCloseButton = false;
		private XColor  xBackColor = XColor.XTabControlBackColor;

		#region 속성
		[DefaultValue(typeof(XColor), "XTabControlBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor; }
			set
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		/// <summary>
		/// Close Button Click시 Tab Page종료여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("Action"),DefaultValue(false),
		Description("Close Button Click시 Tab Page종료여부를 지정합니다.")]
		public bool ExecuteCloseButton
		{
			get { return executeCloseButton;}
			set { executeCloseButton = value; }
		}
		/// <summary>
		/// TabPage의 갯수를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public virtual int TabCount
		{
			get { return TabPages.Count; }
		}
		/// <summary>
		/// TabPage의 Client영역을 가져옵니다.
		/// </summary>
		[Browsable(false),
		Description("Tab Page의 Client Rectangle Size입니다.")]
		public Rectangle PageRectangle
		{
			get
			{
				if (_recalculate)
					Recalculate();
				return _pageRect;
			}
		}
		#endregion

		/// <summary>
		/// IcmTabControl 생성자
		/// </summary>
		public XTabControl()
		{
			this.Font = new Font("MS UI Gothic", 9.75f);
		}
		/// <summary>
		/// ClosePressed Event를 발생시킵니다.
		/// (override) TabPage를 제거합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		public override void OnClosePressed(EventArgs e)
		{
			base.OnClosePressed(e);
			if (executeCloseButton && (SelectedIndex >= 0))
				TabPages.RemoveAt(SelectedIndex);
		}
		/// <summary>
		/// 지정한 Index의 Tab의 Client영역을 가져옵니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		/// <returns> Client영역 Rectangle </returns>
		public Rectangle GetTabRect(int index)
		{
			return (Rectangle)_tabRects[index];
		}
		
		/// <summary>
		/// 에러가 발생한 TabPage를 Remove(FormMdiParent::AddTabPage에서 TabControl의 TabPage에 Add
		/// 시에 Screen의 생성자 잘못으로(ex:지정한 DataWindowControl의 DataObject가 없음 등)
		/// TabPage를 Add하지 못할때 기생성한 에러TabPage를 처리함
		/// </summary>
		/// <param name="page"></param>
		internal void RemoveErrorTagPage(IHIS.X.Magic.Controls.TabPage page)
		{
			try
			{
				//선택해제
				this.DeselectPage(page);
				//TabPage삭제
				this.RemoveTabPage(page);
			}
			catch{}
		}

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			base.OnPaint(e);
		}
		#endregion
	}
}
