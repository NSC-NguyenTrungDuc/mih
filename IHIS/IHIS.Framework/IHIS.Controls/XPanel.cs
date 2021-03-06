using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	/// <summary>
	/// XPanel에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
	public class XPanel : System.Windows.Forms.Panel
	{
		#region Fields
		private XColor xBackColor = XColor.XPanelBackColor;
		private XColor xForeColor = XColor.NormalForeColor;
		private XColor borderColor	= XColor.XPanelBorderColor;
		private int borderWidth = 1;
		private bool drawBorder = false; //None Style에서 Border를 그릴지 여부
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XPanelBackColor"),
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
		#endregion

		#region Property
		/// <summary>
		/// 경계선색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XPanelBorderColor"),
		MergableProperty(true),
		Description("경계선색을 지정합니다.(BorderStyle이 None일때만 적용됨)")]
		public XColor BorderColor
		{
			get { return borderColor; }
			set	
			{ 
				borderColor = value;
				Invalidate(ClientRectangle);
			}
		}
		[DefaultValue(false),
		Category("추가속성"),
		MergableProperty(true),
		Description("경계선을 그릴지여부를 지정합니다.(BorderStyle이 None일때만 적용됨)")]
		public bool DrawBorder
		{
			get { return drawBorder; }
			set	
			{ 
				drawBorder = value;
				Invalidate(ClientRectangle);
			}
		}
//		[DefaultValue(1),
//		Category("추가속성"),
//		MergableProperty(true),
//		Description("경계선을 그릴때 경계선의 너비(1-5까지)를 지정합니다.")]
//		public int BorderWidth
//		{
//			get { return borderWidth; }
//			set	
//			{ 
//				borderWidth = Math.Min(Math.Max(1, value),5);
//				if (this.drawBorder)
//					Invalidate(ClientRectangle);
//			}
//		}
		#endregion
		
		#region 생성자
		public XPanel()
		{
			//Default 색 지정
			this.BackColor = XColor.XPanelBackColor;
			this.ForeColor = XColor.NormalForeColor;
		}
		#endregion

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			if (base.ForeColor != xForeColor.Color)
				base.ForeColor = xForeColor.Color;
			base.OnPaint (e);
		}
		#endregion

		#region WndProc
		/// <summary>
		/// Window 메세지를 처리합니다.
		/// (override) 연속조회요청, Border를 그립니다.
		/// </summary>
		/// <param name="msg"> (ref) Message </param>
		protected override void WndProc(ref Message msg)
		{
			base.WndProc(ref msg);

			//NC영역 Get
			switch (msg.Msg)
			{
				case (int)Win32.Msgs.WM_NCCALCSIZE :
					//None일때만 NonClient영역 Size 다시계산
					if (this.drawBorder && (this.BorderStyle == BorderStyle.None))
					{
						//Client size Catch
						Win32.RECT newRect = (Win32.RECT)(Marshal.PtrToStructure(msg.LParam, typeof(Win32.RECT)));
						newRect.left += borderWidth;
						newRect.right -= borderWidth;
						newRect.top += borderWidth;
						newRect.bottom -= borderWidth;
						Marshal.StructureToPtr(newRect, msg.LParam, true);
					}
					break;
				case (int)Win32.Msgs.WM_NCHITTEST :
					//None일때만 NonClient영역 Size 다시계산
					if (this.drawBorder && (this.BorderStyle == BorderStyle.None))
					{
						int x = (int)msg.LParam % 0x10000;
						int y = (int)msg.LParam / 0x10000;
						Point pos = this.PointToClient(new Point(x, y));
						if (x >= (Bounds.Width - borderWidth) || x <= borderWidth ||
							y >= (Bounds.Height - borderWidth) || y <= borderWidth )
						{
							msg.Result = (IntPtr)18;		// Border
						}
					}
					break;
				case (int)Win32.Msgs.WM_NCPAINT :
					//None일때만 NonClient영역 다시 그림
					if (this.drawBorder && (this.BorderStyle == BorderStyle.None))
						BorderPaint(msg.HWnd);
					msg.Result = IntPtr.Zero;
					break;
			}
		}
		//Border는 NC영역에서 그리기
		private void BorderPaint(IntPtr hwnd)
		{
			//BorderStyle이 None일때만 그림
			IntPtr hDC = User32.GetWindowDC(hwnd);
			Graphics g = Graphics.FromHdc(hDC);
			using (Pen rectPen = new Pen(borderColor.Color,(float) borderWidth))
				g.DrawRectangle(rectPen , 0,0, this.Width - borderWidth, this.Height - borderWidth);

			g.Dispose();
			User32.ReleaseDC(hwnd, hDC);
		}
		#endregion
	}
}
