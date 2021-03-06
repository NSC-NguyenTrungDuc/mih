using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// XFlatRadioButton에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.RadioButton))]
	public class XFlatRadioButton : System.Windows.Forms.RadioButton
	{
		#region Class Variables
		const int CIRCLE_DIAMETER = 11;
		DrawState drawState = DrawState.Normal;

		private string checkedValue = "Y";
		private string checkedText = "",   unCheckedText = "";
		private XColor xBackColor = XColor.XRadioButtonBackColor;
		private XColor xForeColor = XColor.NormalForeColor;
		#endregion
		
		#region Base Properties
		[DefaultValue(typeof(XColor),"XRadioButtonBackColor"),
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
		/// <summary>
		/// 단추 컨트롤의 평면 스타일 모양을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new FlatStyle FlatStyle
		{
			get {return base.FlatStyle;}
			set {base.FlatStyle = value;}
		}
		/// <summary>
		/// RadioButton 컨트롤의 모양을 결정하는 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Appearance  Appearance
		{
			get {return base.Appearance;}
			set {base.Appearance = value;}
		}
		#endregion

		#region Properties
		/// <summary>
		/// 체크된 상태의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue("Y"),
		Description("체크된 상태의 값을 지정합니다.")]
		public string CheckedValue
		{
			get	{return checkedValue;}
			set	{checkedValue = value;}
		}
		/// <summary>
		/// 체크된 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue(""),
		Description("체크된 상태에서 보여줄 문자를 지정합니다.")]
		public string CheckedText
		{
			get	{return checkedText;}
			set { checkedText = value;}
		}
		/// <summary>
		/// 체크되지 않은 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue(""),
		Description("체크되지 않은 상태에서 보여줄 문자를 지정합니다.")]
		public string UnCheckedText
		{
			get	{return unCheckedText;}
			set { unCheckedText = value;}
		}
		#endregion

		#region 생성자
		public XFlatRadioButton()
		{
			//Default 색 지정
			this.BackColor = XColor.XRadioButtonBackColor;
			this.ForeColor = XColor.NormalForeColor;

			// 2005/05/09 신종석 폰트 수정
			this.Font = new Font("MS UI Gothic", 9.75f);

			FlatStyle = FlatStyle.Flat;
			this.Appearance = Appearance.Normal;
		}
		#endregion

		#region Override
		/// <summary>
		/// CheckedChanged Event를 발생시킵니다.
		/// (override) 체크상태에 따라 Text를 변경합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnClick(EventArgs e)
		{
			// Checked에 따라 Text 변경
			if(this.Checked)
			{
				if(!this.checkedText.Trim().Equals(string.Empty))
					this.Text = this.checkedText;
			}
			else
			{
				if(!this.unCheckedText.Trim().Equals(string.Empty))
					this.Text = this.unCheckedText;
			}
			base.OnClick (e);

			//XGroupBox의 DataChanged 변경
			if (!this.DesignMode)
			{
				if ((this.Parent != null) && (this.Parent is XGroupBox))
				{
					((XGroupBox) Parent).SetDataChanged(true);
				}
			}
		}
		/// <summary>
		/// MouseEnter Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseEnter(EventArgs e)
		{
			// Set state to hot
			base.OnMouseEnter(e);
			drawState = DrawState.Hot;
			Invalidate();
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseLeave(EventArgs e)
		{
			// Set state to Normal
			base.OnMouseLeave(e);
			if ( !ContainsFocus )
			{
				drawState = DrawState.Normal;
				Invalidate();
			}
		}
		/// <summary>
		/// GotFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnGotFocus(EventArgs e)
		{
			// Set state to Hot
			base.OnGotFocus(e);
			drawState = DrawState.Hot;
			Invalidate();
		}
		/// <summary>
		/// LostFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnLostFocus(EventArgs e)
		{
			// Set state to Normal
			base.OnLostFocus(e);
			drawState = DrawState.Normal;
			Invalidate();
		}
		/// <summary>
		/// Window Message를 처리합니다.
		/// (override) 그리기시에 컨트롤의 상태에 따라 그립니다.
		/// </summary>
		/// <param name="m"> (ref) 처리할 Windows Message </param>
		protected override  void WndProc(ref Message m)
		{
			bool callBase = true;

			switch(m.Msg)
			{
				case ((int)Win32.Msgs.WM_PAINT):
				{
					// Let the edit control do its painting
					base.WndProc(ref m);
					// Now do our custom painting
					DrawRadioButtonState(Enabled?drawState:DrawState.Disable);
					callBase = false;
				}
					break;
				default:
					break;
			}

			if ( callBase )
				base.WndProc(ref m);

		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			if (base.ForeColor != xForeColor.Color)
				base.ForeColor = xForeColor.Color;

			base.OnPaint(e);
		}
		#endregion

		#region Paint Subroutines
		private void DrawRadioButtonState(DrawState state)
		{
			Rectangle rect = ClientRectangle;

			// Create DC for the whole edit window instead of just for the client area
			IntPtr hDC = User32.GetDC(Handle);
			Rectangle circleRect = new Rectangle(rect.Left, rect.Top + (rect.Height-CIRCLE_DIAMETER)/2,
				CIRCLE_DIAMETER, CIRCLE_DIAMETER);

			using (Graphics g = Graphics.FromHdc(hDC))
			{
				// Always paint the inner circle with the Window color
				g.FillEllipse(SystemBrushes.Window, circleRect);

				if ( state == DrawState.Normal )
				{
					// Draw normal black circle
					g.DrawEllipse(Pens.Black, circleRect);
				}
				else if ( state == DrawState.Hot )
				{
					g.DrawEllipse(SystemPens.Highlight, circleRect);
				}
				else if ( state == DrawState.Disable )
				{
					// draw highlighted rectangle
					g.DrawEllipse(SystemPens.ControlDark, circleRect);
				}

				if ( Checked )
					DrawCheckGlyph(g, state);
			}

			// Release DC
			User32.ReleaseDC(Handle, hDC);
		}

		void DrawCheckGlyph(Graphics g, DrawState state)
		{
			Rectangle rc = ClientRectangle;

			// Calculate coordinates
			Point point1 = new Point(rc.Left + 4, rc.Top + rc.Top + (rc.Height-4)/2 + 2);
			Point point2 = new Point(point1.X + 4, point1.Y);
			Point point3 = new Point(rc.Left + 6, rc.Top + rc.Top + (rc.Height-4)/2);
			Point point4 = new Point(point3.X, point3.Y + 4);

			// Choose color
			Color checkColor = Color.Empty;
			if ( state == DrawState.Normal )
				checkColor = XColor.NormalBorderColor.Color;
			else if (state == DrawState.Hot )
				checkColor = XColor.ActiveBorderColor.Color;
			else if ( state == DrawState.Disable )
				checkColor = SystemColors.ControlDark;

			// Draw the check mark
			using ( Pen pen = new Pen(checkColor, 2) )
			{
				g.DrawLine(pen, point1, point2);
				g.DrawLine(pen, point3, point4);
			}
		}
		#endregion

	}
}
