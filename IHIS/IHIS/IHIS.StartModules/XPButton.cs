using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace IHIS
{
	#region XPButton Enum
	/// <summary>
	/// Button의 상태를 나타내는 Enum입니다.
	/// </summary>
	internal enum States
	{
		/// <summary>
		/// 기본 상태
		/// </summary>
		Normal,
		/// <summary>
		/// Hover 상태
		/// </summary>
		MouseOver,
		/// <summary>
		/// Pushed 상태
		/// </summary>
		Pushed
	}
	/// <summary>
	/// Button의 색깔톤을 나타내는 Enum입니다.
	/// </summary>
	public enum Schemes
	{
		/// <summary>
		/// Blue 색깔톤
		/// </summary>
		Blue,
		/// <summary>
		/// OliveGreen 색깔톤
		/// </summary>
		OliveGreen,
		/// <summary>
		/// Silver 색깔톤
		/// </summary>
		Silver,
		/// <summary>
		/// Green 색깔톤
		/// </summary>
		Green
	}
	#endregion


	/// <summary>
	/// XPButton에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.Button))]
	public class XPButton : System.Windows.Forms.Control, IButtonControl
	{
		#region Private Fields
		private System.ComponentModel.Container components = null;
		
		private const int cLeftMargin = 6;
		private const int cTextMargin = 4;
		private const int cMinPaintSize = 10;  // 10 fixel
		private States state = States.Normal;
		private Schemes scheme = Schemes.Blue;

		private Image image;
		private Rectangle bounds;
		private bool selected;
		private Rectangle[] rects0; 
		private Rectangle[] rects1; 
		private bool isLeftButtonClick = true;

		private static Pen						
			pen0, pen1, pen2,
			pen01, pen02, pen03, pen04, pen05, pen06, 
			pen07, pen08, pen09, pen10, pen11, pen12, pen13;

		private static LinearGradientBrush
            brush01, brush02, brush03;
		private static SolidBrush brush1;
		#endregion

		#region 생성자
		/// <summary>
		/// XPButton 생성자
		/// </summary>
		public XPButton()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.StandardDoubleClick, false);
			this.SetStyle(ControlStyles.Selectable, true);
			//기본 Font는 MS UI Gothic
			this.Font = new Font("MS UI Gothic", 9.75f);
		}
		/// <summary>
		/// 컨트롤에서 사용하는 리소스를 모두 해제합니다.
		/// </summary>
		/// <param name="disposing"> Dispose 여부 </param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				DisposePensBrushes();
				if(components != null)
				{	
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region base Properties not Browsable
		/// <summary>
		/// 컨트롤의 배경색을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override Color BackColor
		{
			get {return base.BackColor;}
			set {base.BackColor = value;}
		}
		/// <summary>
		/// 컨트롤의 전경색을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override Color ForeColor
		{
			get {return base.ForeColor;}
			set {base.ForeColor = value;}
		}
		/// <summary>
		/// 컨트롤에 표시할 배경 이미지를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override Image BackgroundImage 
		{
			get { return base.BackgroundImage;}
			set { base.BackgroundImage = value;}
		}
		/// <summary>
		/// 오른쪽에서 왼쪽으로 쓰는 글꼴을 사용하는 로케일을 지원하도록 컨트롤 요소가 정렬되어 있는지 여부를 나타내는 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override RightToLeft RightToLeft 
		{
			get { return base.RightToLeft;}
			set { base.RightToLeft = value;}
		}
		
		// OnPaint에서 Heigh - 8 로 하여 Draw하는데, 이때 height - 8 = 0 이면 Error발생, height는 10이하는 안됨
		/// <summary>
		/// 컨트롤의 높이를 가져오거나 설정합니다.
		/// </summary>
		public new int Height
		{
			get { return ( base.Height > 8 ? base.Height : 10);}
			set { base.Height = (value > 8 ? value : 10); }
		}
		
		[Browsable(true),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properties
		/// <summary>
		/// 버튼의 바탕색깔톤을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(Schemes.Blue),
		MergableProperty(true),
		Description("버튼의 바탕색깔의 모양을 정합니다.")]
		public Schemes Scheme
		{
			get { return scheme; }
			set
			{
				scheme = value;
				this.Invalidate();
			}
		}
		/// <summary>
		/// 버튼의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(null),
		MergableProperty(true),
		Description("버튼의 Image을 설정합니다.")]
		public Image Image
		{
			get { return image; }
			set
			{
				image = value;
				this.Invalidate();
			}
		}
		//		/// <summary>
		//		/// 버튼 ImageAlignment를 가져오거나 설정합니다.
		//		/// </summary>
		//		[Browsable(true), Category("Appearance"),
		//		DefaultValue(ContentAlignment.MiddleLeft),
		//		MergableProperty(true),
		//		Description("버튼 Image의 Alignment를 설정합니다.")]
		//		public ContentAlignment ImageAlign
		//		{
		//			get { return imageAlign; }
		//			set
		//			{
		//				imageAlign = value;
		//				this.Invalidate();
		//			}
		//		}
		//		/// <summary>
		//		/// Image의 Stretch여부를 가져오거나 설정합니다.
		//		/// </summary>
		//		[Browsable(true), Category("Appearance"),
		//		DefaultValue(false),
		//		MergableProperty(true),
		//		Description("Image의 Stretch여부를 설정합니다.")]
		//		public bool ImageStretch
		//		{
		//			get { return imageStretch; }
		//			set
		//			{
		//				imageStretch = value;
		//				this.Invalidate();
		//			}
		//		}
		/// <summary>
		/// 버튼의 Text를 가져오거나 설정합니다.
		/// </summary>
		public override string Text
		{
			get { return base.Text; }
			set
			{
				base.Text = value;
				this.Invalidate();
			}
		}
		//		/// <summary>
		//		/// Text의 Alignment를 가져오거나 설정합니다.
		//		/// </summary>
		//		[Browsable(true), Category("Appearance"),
		//		DefaultValue(ContentAlignment.MiddleCenter),
		//		MergableProperty(true),
		//		Description("Text의 Alignment를 설정합니다.")]
		//		public ContentAlignment TextAlign
		//		{
		//			get { return textAlign; }
		//			set
		//			{
		//				textAlign = value;
		//				this.Invalidate();
		//			}
		//		}
		#endregion
		
		#region Override Method
		/// <summary>
		/// MouseMove Event를 발생시킵니다.
		/// (override) 버튼의 상태에 따라 모양을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			//if (this.Parent != null && !this.Parent.ContainsFocus) return;
			base.OnMouseMove(e);

			if (bounds.Contains(e.X, e.Y))
			{
				if (state == States.Normal)
				{
					state = States.MouseOver;
					this.Invalidate(bounds);
				}
			}
			else
			{
				if (state != States.Normal)
				{
					state = States.Normal;
					this.Invalidate(bounds);
				}
			}
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseLeave(System.EventArgs e)
		{
			base.OnMouseLeave(e);
			if (state != States.Normal)
			{
				state = States.Normal;
				this.Invalidate(bounds);
			}
		}
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// (override) 버튼의 상태에 따라 모양을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			this.isLeftButtonClick = false;

			base.OnMouseDown(e);
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
			
			//LeftButton Click
			this.isLeftButtonClick = true;

			if (bounds.Contains(e.X, e.Y))
			{
				state = States.Pushed;
				this.Focus();
			} 
			else
			{
				state = States.Normal;
			}
			this.Invalidate(bounds);
		}
		/// <summary>
		/// MouseUp Event를 발생시킵니다.
		/// (override) 버튼의 상태에 따라 모양을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				state = States.Normal;
				this.Invalidate(bounds);
			}
		}
		/// <summary>
		/// KeyDown Event를 발생시킵니다.
		/// (override) Space Key입력시 MouseDown Event를 발생시킵니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 KeyEventArgs </param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Space)
			{
				//MouseDown
				OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, 2, 2, 0));
				//Click
				OnClick(EventArgs.Empty);
			}
		}
		/// <summary>
		/// 버튼의 색깔톤, 상태에 따라 버튼을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 PaintEventArgs </param>
		protected override void OnPaint(PaintEventArgs e)
		{
			SolidBrush				_brush01, _brush;
			LinearGradientBrush		_brush02, _brush03, _brush04;
			Pen						_pen01, _pen02, _pen03, _pen04, _pen05, _pen06;
			
			StringFormat textFormat  = new StringFormat();
			textFormat.HotkeyPrefix  = HotkeyPrefix.Show;

			int textLen = this.Text.Length;
			// Menomic 문자 처리
			if ((this.Text.IndexOf("&") >= 0) && (textLen > this.Text.IndexOf("&") + 1))
				textLen --;

			int X = this.Width;
			int Y = this.Height;
			
			// Size가 최초 Size미만 이면 그리지 않음
			if ((X < cMinPaintSize) || (Y < cMinPaintSize)) return;

			e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;

			int y = 0;
			int x = 0;
			Point point;

			int _y = (this.Height - this.Font.Height) / 2 ;
			if (image != null) 
			{
				if (textLen == 0) x = (X - image.Width)/2;
				else x = cLeftMargin;
				y = (this.Height - image.Height) / 2;
				point = new Point(cLeftMargin + image.Width + cTextMargin, _y);
			}
			else 
			{
				Size size = XPButtonUtil.GetTextSize(e.Graphics, this.Text, this.Font, this.Size);
				int textWidth = size.Width;
				point = new Point((X - textWidth)/2, _y);					
			}
			

			if (!this.Enabled)
			{
				_brush = new SolidBrush(Color.FromArgb(64, 201, 199, 186));
				_brush01 = new SolidBrush(Color.FromArgb(245, 244, 234));
				_pen01 = new Pen(Color.FromArgb(201, 199, 186));
				_pen02 = new Pen(Color.FromArgb(170, 201, 199, 186));
				
				try
				{
					e.Graphics.FillRectangle(_brush01, 2, 2, X-4, Y-4);
					e.Graphics.DrawLine(_pen01, 3, 1, X-4, 1);
					e.Graphics.DrawLine(_pen01, 3, Y-2, X-4, Y-2);
					e.Graphics.DrawLine(_pen01, 1, 3, 1, Y-4);
					e.Graphics.DrawLine(_pen01, X-2, 3, X-2, Y-4);

					e.Graphics.DrawLine(_pen02, 1, 2, 2, 1);
					e.Graphics.DrawLine(_pen02, 1, Y-3, 2, Y-2);
					e.Graphics.DrawLine(_pen02, X-2, 2, X-3, 1);
					e.Graphics.DrawLine(_pen02, X-2, Y-3, X-3, Y-2);
					e.Graphics.FillRectangles(_brush, rects1);

					if (image != null)
						ControlPaint.DrawImageDisabled(e.Graphics, image, x, y, this.BackColor);
					if (this.Text != "")
						e.Graphics.DrawString(this.Text, this.Font, SystemBrushes.ControlDark, point, textFormat);

					_brush.Dispose();
					_brush01.Dispose();
					_pen01.Dispose();
					_pen02.Dispose();
				}
				catch{}
				return;
			}

			//Selected, Mouse Over는 동일
			pen06 = new Pen(Color.FromArgb(206, 231, 255));
			pen07 = new Pen(Color.FromArgb(188, 212, 246));
			pen08 = new Pen(Color.FromArgb(137, 173, 228));
			pen09 = new Pen(Color.FromArgb(105, 130, 238));

			//Mouse Over
			brush03 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
				, Color.FromArgb(253, 216, 137), Color.FromArgb(248, 178, 48), 90.0f);
			pen10 = new Pen(Color.FromArgb(255, 240, 207));
			pen11 = new Pen(Color.FromArgb(253, 216, 137));
			pen12 = new Pen(Color.FromArgb(248, 178, 48));
			pen13 = new Pen(Color.FromArgb(229, 151, 0));
			
			switch (scheme)
			{
				case Schemes.OliveGreen:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(254, 251, 250), Color.FromArgb(249, 243, 229), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(249, 243, 229));
					pen02 = new Pen(Color.FromArgb(242, 225, 208));
					pen03 = new Pen(Color.FromArgb(230, 209, 184));

					pen04 = new Pen(Color.FromArgb(242, 225, 208));
					pen05 = new Pen(Color.FromArgb(230, 209, 184));
					
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(142, 123, 117));
					pen1 = new Pen(Color.FromArgb(142, 123, 117));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;

				case Schemes.Silver:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(255,255,255), Color.FromArgb(229,226,241), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(229, 226, 241));
					pen02 = new Pen(Color.FromArgb(202, 195, 223));
					pen03 = new Pen(Color.FromArgb(160, 147, 196));

					pen04 = new Pen(Color.FromArgb(202, 195, 223));
					pen05 = new Pen(Color.FromArgb(160, 147, 196));
					
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(96, 73, 151));
					pen1 = new Pen(Color.FromArgb(96, 73, 151));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));

					//					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
					//						, Color.FromArgb(250, 252, 254), Color.FromArgb(228, 232, 248), 90.0f);
					//					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
					//						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);
					//
					//					pen01 = new Pen(Color.FromArgb(228, 232, 248));
					//					pen02 = new Pen(Color.FromArgb(206, 213, 238));
					//					pen03 = new Pen(Color.FromArgb(182, 187, 224));
					//
					//					pen04 = new Pen(Color.FromArgb(206, 213, 238));
					//					pen05 = new Pen(Color.FromArgb(182, 187, 224));
					//					
					//					//Border
					//					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					//					pen0 = new Pen(Color.FromArgb(113, 121, 149));
					//					pen1 = new Pen(Color.FromArgb(113, 121, 149));
					//					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;

				case Schemes.Green:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(255, 255, 255), Color.FromArgb(224, 247, 240), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(224, 247, 240));
					pen02 = new Pen(Color.FromArgb(193, 231, 222));
					pen03 = new Pen(Color.FromArgb(151, 203, 197));

					pen04 = new Pen(Color.FromArgb(193, 231, 222));
					pen05 = new Pen(Color.FromArgb(151, 203, 197));
					
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(75, 125, 130));
					pen1 = new Pen(Color.FromArgb(75, 125, 130));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));

					//					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
					//						, Color.FromArgb(252, 254, 250), Color.FromArgb(232, 247, 227), 90.0f);
					//					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
					//						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);
					//
					//					pen01 = new Pen(Color.FromArgb(232, 247, 227));
					//					pen02 = new Pen(Color.FromArgb(217, 238, 206));
					//					pen03 = new Pen(Color.FromArgb(191, 224, 180));
					//
					//					pen04 = new Pen(Color.FromArgb(217, 238, 206));
					//					pen05 = new Pen(Color.FromArgb(191, 224, 180));
					//					//Border
					//					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					//					pen0 = new Pen(Color.FromArgb(117, 141, 137));
					//					pen1 = new Pen(Color.FromArgb(117, 141, 137));
					//					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;

				default:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(255, 255, 255), Color.FromArgb(228, 237, 240), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(228, 237, 240));
					pen02 = new Pen(Color.FromArgb(216, 226, 230));
					pen03 = new Pen(Color.FromArgb(195, 210, 216));

					pen04 = new Pen(Color.FromArgb(216, 226, 230));
					pen05 = new Pen(Color.FromArgb(195, 210, 216));
					
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(127, 156, 161));
					pen1 = new Pen(Color.FromArgb(127, 156, 161));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;
			}
			
			try
			{
				LinearGradientBrush brush0 = new LinearGradientBrush(new Rectangle(0, 0, X, Y)
					, Color.FromArgb(64, 171, 168, 137), Color.FromArgb(92, 255, 255, 255), 85.0f);
				e.Graphics.FillRectangle(brush0, new Rectangle(0, 0, X, Y));
				brush0.Dispose();
			}
			catch{}
			
			try
			{
				switch (state)
				{
					case States.Normal:
						e.Graphics.FillRectangle(brush01, 2, 2, X-4, Y-7);
						e.Graphics.DrawLine(pen01, 2, Y-5, X-2, Y-5);
						e.Graphics.DrawLine(pen02, 2, Y-4, X-2, Y-4);
						e.Graphics.DrawLine(pen03, 2, Y-3, X-2, Y-3);
						e.Graphics.DrawLine(pen04, X-4, 4, X-4, Y-5);
						e.Graphics.DrawLine(pen05, X-3, 4, X-3, Y-5);

						if (selected)
						{
							e.Graphics.FillRectangles(brush02, rects0);
							e.Graphics.DrawLine(pen06, 2, 2, X-3, 2);
							e.Graphics.DrawLine(pen07, 2, 3, X-3, 3);
							e.Graphics.DrawLine(pen08, 2, Y-4, X-3, Y-4);
							e.Graphics.DrawLine(pen09, 2, Y-3, X-3, Y-3);
						}
						break;

					case States.MouseOver:
						e.Graphics.FillRectangle(brush01, 2, 2, X-4, Y-7);
						e.Graphics.DrawLine(pen01, 2, Y-5, X-4, Y-5);
						e.Graphics.DrawLine(pen02, 2, Y-4, X-4, Y-4);
						e.Graphics.DrawLine(pen03, 2, Y-3, X-4, Y-3);
						e.Graphics.DrawLine(pen04, X-4, 4, X-4, Y-5);
						e.Graphics.DrawLine(pen05, X-3, 4, X-3, Y-5);

						e.Graphics.FillRectangles(brush03, rects0);
						e.Graphics.DrawLine(pen10, 2, 2, X-3, 2);
						e.Graphics.DrawLine(pen11, 2, 3, X-3, 3);
						e.Graphics.DrawLine(pen12, 2, Y-4, X-3, Y-4);
						e.Graphics.DrawLine(pen13, 2, Y-3, X-3, Y-3);
						break;

					case States.Pushed:
						_brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-7)
							, Color.FromArgb(216, 212, 203), Color.FromArgb(218, 216, 207), 90.0f);
						_brush04 = new LinearGradientBrush(new Rectangle(3, 3, X-4, Y-7)
							, Color.FromArgb(221, 218, 209), Color.FromArgb(223, 222, 214), 90.0f);

						_brush03 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
							, Color.FromArgb(229, 228, 221), Color.FromArgb(226, 226, 218), 90.0f);
					
						_pen01 = new Pen(Color.FromArgb(209, 204, 192));
						_pen02 = new Pen(Color.FromArgb(220, 216, 207));
						_pen03 = new Pen(Color.FromArgb(234, 233, 227));
						_pen04 = new Pen(Color.FromArgb(242, 241, 238));
						_pen05 = new Pen(_brush02);
						_pen06 = new Pen(_brush04);

						e.Graphics.FillRectangle(_brush03, 2, 4, X-4, Y-8);
						e.Graphics.DrawLine(_pen05, 2, 3, 2, Y-4);
						e.Graphics.DrawLine(_pen06, 3, 3, 3, Y-4);
						e.Graphics.DrawLine(_pen01, 2, 2, X-3, 2);
						e.Graphics.DrawLine(_pen02, 2, 3, X-3, 3);
						e.Graphics.DrawLine(_pen03, 2, Y-4, X-3, Y-4);
						e.Graphics.DrawLine(_pen04, 2, Y-3, X-3, Y-3);

						_brush02.Dispose();
						_brush03.Dispose();
						_brush04.Dispose();
						_pen01.Dispose();
						_pen02.Dispose();
						_pen03.Dispose();
						_pen04.Dispose();
						_pen05.Dispose();
						_pen06.Dispose();
						break;				
				}
			}
			catch{}

			
			try
			{
				if (image != null) e.Graphics.DrawImage(image, x, y);
				e.Graphics.DrawString(this.Text, this.Font, SystemBrushes.ControlText, point, textFormat);

				
				e.Graphics.DrawLine(pen1, 1, 3, 3, 1);
				e.Graphics.DrawLine(pen1, X-2, 3, X-4, 1);
				e.Graphics.DrawLine(pen1, 1, Y-4, 3, Y-2);
				e.Graphics.DrawLine(pen1, X-2, Y-4, X-4, Y-2);

				e.Graphics.DrawLine(pen2, 1, 2, 2, 1);
				e.Graphics.DrawLine(pen2, 1, Y-3, 2, Y-2);
				e.Graphics.DrawLine(pen2, X-2, 2, X-3, 1);
				e.Graphics.DrawLine(pen2, X-2, Y-3, X-3, Y-2);						

				e.Graphics.DrawLine(pen0, 3, 1, X-4, 1);
				e.Graphics.DrawLine(pen0, 3, Y-2, X-4, Y-2);
				e.Graphics.DrawLine(pen0, 1, 3, 1, Y-4);
				e.Graphics.DrawLine(pen0, X-2, 3, X-2, Y-4);

				e.Graphics.FillRectangles(brush1, rects1);
			}
			catch{}

			DisposePensBrushes();
		}
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnClick(EventArgs e)
		{
			// LeftButton Click시만 OnClick Call
			if (this.isLeftButtonClick)
			{
				if (state == States.Pushed)
				{
					state = States.Normal;
					this.Invalidate(bounds);
				}

				base.OnClick(e);
				// DialogResult가 None이 아니면 Form에 Result를 전달하여  Form Close
				if (this.DialogResult != DialogResult.None)
					if( this.TopLevelControl is Form)
						((Form)this.TopLevelControl).DialogResult = this.DialogResult;
			}
		}
		/// <summary>
		/// Enter Event를 발생시킵니다.
		/// (override) 버튼을 Hover상태로 변경합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			selected = true;
			this.Invalidate(bounds);
		}
		/// <summary>
		/// Enter Event를 발생시킵니다.
		/// (override) 버튼을 기본상태로 변경합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			selected = false;
			this.Invalidate(bounds);
		}
		/// <summary>
		/// ParentChanged Event를 발생시킵니다.
		/// (override) 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>	
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (this.Parent == null) return;

			int X = this.Width;
			int Y = this.Height;

			this.bounds = new Rectangle(0, 0, X, Y);

			rects0 = new Rectangle[2];
			rects0[0] = new Rectangle(2, 4, 2, Y-8);
			rects0[1] = new Rectangle(X-4, 4, 2, Y-8);

			rects1 = new Rectangle[8];
			rects1[0] = new Rectangle(2, 1, 2, 2); 
			rects1[1] =	new Rectangle(1, 2, 2, 2);
			rects1[2] =	new Rectangle(X-4, 1, 2, 2);
			rects1[3] =	new Rectangle(X-3, 2, 2, 2);
			rects1[4] =	new Rectangle(2, Y-3, 2, 2);
			rects1[5] =	new Rectangle(1, Y-4, 2, 2);
			rects1[6] =	new Rectangle(X-4, Y-3, 2, 2);
			rects1[7] =	new Rectangle(X-3, Y-4, 2, 2);

			//this.BackColor = Color.FromArgb(0, this.Parent.BackColor);
			
			Point[] points = {
								 new Point(1, 0),
								 new Point(X-1, 0),
								 new Point(X-1, 1),
								 new Point(X, 1),
								 new Point(X, Y-1),
								 new Point(X-1, Y-1),
								 new Point(X-1, Y),
								 new Point(1, Y),
								 new Point(1, Y-1),
								 new Point(0, Y-1),
								 new Point(0, 1),
								 new Point(1, 1)};

			GraphicsPath path = new GraphicsPath();
			path.AddLines(points);

			this.Region = new Region(path);

		}
		/// <summary>
		/// Resize Event를 발생시킵니다.
		/// (override) 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>	
		protected override void OnResize(EventArgs e)
		{
			bounds = new Rectangle(0, 0, this.Width, this.Height);
			OnParentChanged(e);
			base.OnResize(e);
			this.Invalidate(bounds);
		}
		/// <summary>
		/// EnabledChanged Event를 발생시킵니다.
		/// (override) 활성,비활성에 따라 버튼을 다시 그립니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.Invalidate(bounds);
		}
		/// <summary>
		/// 니모닉 문자를 처리합니다.
		/// (override) 버튼의 Text에 니모닉 문자가 있으면 Click Event를 발생시킵니다.
		/// </summary>
		/// <param name="charCode"> 처리할 문자 </param>
		/// <returns> 컨트롤이 문자를 니모닉으로 처리하면 true이고, 그렇지 않으면 false </returns>
		protected override bool ProcessMnemonic(char charCode)
		{
			if (XPButton.IsMnemonic(charCode, this.Text))
			{
				// 단축키 Click, PerformClick
				this.PerformClick();
				return true;
			}
			return base.ProcessMnemonic(charCode);
		}
		#endregion

		#region Private Method

		private void DisposePensBrushes()
		{
			try
			{
				brush1.Dispose();
				pen0.Dispose();
				pen1.Dispose();
				pen2.Dispose();
				brush01.Dispose();
				brush02.Dispose();
				brush03.Dispose();
				pen01.Dispose();
				pen02.Dispose();
				pen03.Dispose();
				pen04.Dispose();
				pen05.Dispose();
				pen06.Dispose();
				pen07.Dispose();
				pen08.Dispose();
				pen09.Dispose();
				pen10.Dispose();
				pen11.Dispose();
				pen12.Dispose();
				pen13.Dispose();
			}
			catch{}
		}
		#endregion

		#region IButtonControl Implementation
		private DialogResult dialogResult = DialogResult.None;
		/// <summary>
		/// 모달 폼의 결과값을 가져오거나 설정합니다.
		/// </summary>
		[Category("Action"),
		DefaultValue(DialogResult.None),
		MergableProperty(true),
		Browsable(true),
		Description("모달 폼의 결과값을 지정합니다.")]
		public DialogResult DialogResult
		{
			get { return dialogResult;}
			set { dialogResult = value;}
		}
		// Button이 Default Button일때 Enter , Esc 키를 누르면 Call되는 Method
		// Form의 AcceptButton, CancelButton으로 지정되었거나, NotifyDefault의 value가 True이면 Key에 의해 발생함
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// </summary>
		public virtual void PerformClick()
		{
			// Click Event Call
			this.state = States.Pushed;
			this.isLeftButtonClick = true;  // LeftButtonClick
			OnClick(EventArgs.Empty);
		}
		// Do Nothing
		/// <summary>
		/// 해당 모양과 동작이 적절하게 조정되도록 이 단추가 기본 단추임을 컨트롤에 알립니다.
		/// </summary>
		/// <param name="value"> 컨트롤이 기본 단추로 동작해야 하면 true이고, 그렇지 않으면 false </param>
		public virtual void NotifyDefault(bool value){}
		#endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
	}
	/// <summary>
	/// XPButtonUtil에 대한 요약 설명입니다.
	/// </summary>
	internal class XPButtonUtil
	{
		/// <summary>
		/// Font, Size를 고려한 Text의 Size를 반환합니다.
		/// </summary>
		/// <param name="graphics"> Paint시 사용할 Graphics 개체 </param>
		/// <param name="text"> Text String </param>
		/// <param name="font"> Font </param>
		/// <param name="size"> Size </param>
		/// <returns> Text의 Size </returns>
		public static Size GetTextSize(Graphics graphics, string text, Font font, Size size)
		{
			StringFormat format = new StringFormat();
			format.HotkeyPrefix = HotkeyPrefix.Show;
			//format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			SizeF stringSize = graphics.MeasureString(text, font, size.Width, format);

			return new Size((int)stringSize.Width, (int)stringSize.Height);
		}
	}
}
