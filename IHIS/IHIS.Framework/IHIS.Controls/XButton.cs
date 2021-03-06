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
using System.Drawing.Design;
using System.Reflection;

namespace IHIS.Framework
{

	#region Enum
	/// <summary>
	/// Button의 색깔톤을 나타내는 Enum입니다.
	/// </summary>
	[Serializable]
	public enum XButtonSchemes
	{
		/// <summary>
		/// Blue 색깔톤
		/// </summary>
		Blue = 0,
		/// <summary>
		/// OliveGreen 색깔톤
		/// </summary>
		OliveGreen = 1,
		/// <summary>
		/// Silver 색깔톤
		/// </summary>
		Silver = 2,
		/// <summary>
		/// Green 색깔톤
		/// </summary>
		Green  = 3,
		/// <summary>
		/// SkyBlue 색깔톤
		/// </summary>
		SkyBlue = 4,
		/// <summary>
		/// HotPink 색깔톤
		/// </summary>
		HotPink = 5
	}
	#endregion

	/// <summary>
	/// XButton에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(IHIS.Framework.XButton),"Images.XButton.bmp")]
	public class XButton : System.Windows.Forms.Control, IButtonControl, IEditorControl
	{
		#region enum
		/// <summary>
		/// Button의 상태를 나타내는 Enum입니다.
		/// </summary>
		private enum States
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
		#endregion

		#region Private Fields
		private System.ComponentModel.Container components = null;
		
		private const int cMinPaintSize = 10;  // 10 fixel
		private States state = States.Normal;
		private XButtonSchemes scheme = XButtonSchemes.Blue;

		private Image image;
		private ContentAlignment imageAlign = ContentAlignment.MiddleLeft;
		private ContentAlignment textAlign = ContentAlignment.MiddleCenter;
		private Point imagePadding = new Point(0,0);
		private Point textPadding  = new Point(0,0);
		private ImageList	imageList = null;
		private int			imageIndex = -1;
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
		public XButton()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.StandardDoubleClick, false);
			this.SetStyle(ControlStyles.Selectable, true);

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

		#endregion

		#region Properties
		/// <summary>
		/// 버튼의 바탕색깔톤을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(XButtonSchemes.Blue),
		MergableProperty(true),
		Description("버튼의 바탕색깔의 모양을 정합니다.")]
		public XButtonSchemes Scheme
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
				if (image != value)
				{
					//ImageFormat이 BMP이면 TransParent 지정
					if (value != null)
					{
						try
						{
							Bitmap bmp = (Bitmap) value;
							bmp.MakeTransparent();
							image = bmp;
						}
						catch{}
					}
					else
						image = null;

					//ImageList, Index Clear
					if (image != null)
					{
						this.imageIndex = -1;
						this.imageList = null;
					}
					this.Invalidate();

				}
			}
		}
		/// <summary>
		/// 버튼 ImageAlignment를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(ContentAlignment.MiddleCenter),
		MergableProperty(true),
		Description("버튼 Text의 Alignment를 설정합니다.")]
		public ContentAlignment TextAlign
		{
			get { return textAlign; }
			set
			{
				textAlign = value;
				this.Invalidate();
			}
		}
		/// <summary>
		/// 버튼 ImageAlignment를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(ContentAlignment.MiddleLeft),
		MergableProperty(true),
		Description("버튼 Image의 Alignment를 설정합니다.")]
		public ContentAlignment ImageAlign
		{
			get { return imageAlign; }
			set
			{
				imageAlign = value;
				this.Invalidate();
			}
		}
		[Browsable(true),
		Category("Appearance"),
		DefaultValue(typeof(Point),"0,0"),
		MergableProperty(true),
		Description("Image 위치의 Padding을 지정합니다.")]
		public Point ImagePadding
		{
			get { return imagePadding; }
			set
			{
				imagePadding = value;
				Invalidate();
			}
		}
		[Browsable(true),
		Category("Appearance"),
		DefaultValue(typeof(Point),"0,0"),
		MergableProperty(true),
		Description("Text 위치의 Padding을 지정합니다.")]
		public Point TextPadding
		{
			get { return textPadding; }
			set
			{
				textPadding = value;
				Invalidate();
			}
		}
		/// <summary>
		/// 버튼의 이미지를 표시할 이미지목록을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(null),
		MergableProperty(true),
		Description("버튼의 이미지를 표시할 이미지목록을 설정합니다.")]
		public ImageList ImageList
		{
			get { return imageList; }
			set
			{
				if (imageList != value)
				{
					imageList = value;
					if (imageList == null)
					{
						this.imageIndex = -1;
						this.image = null;
						Invalidate();
					}
					else
					{
						try
						{
							this.image = imageList.Images[imageIndex];
						}
						catch
						{
							this.image = null;
						}
						Invalidate();
					}
				}
			}
		}
		/// <summary>
		/// 버튼의 이미지를 표시할 이미지목록의 인덱스를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(-1),
		MergableProperty(true),
		Description("버튼의 이미지를 표시할 이미지목록의 인덱스를 설정합니다.")]
		[Editor(typeof(IHIS.Framework.ImageIndexesEditor), typeof(System.Drawing.Design.UITypeEditor))]
		[ImageList("ImageList")]
		public  int ImageIndex
		{
			get { return imageIndex; }
			set
			{
				if (imageIndex != value)
				{
					imageIndex = value;
					if (imageIndex < 0)
					{
						this.image = null;
						Invalidate();
					}
					else
					{
						try
						{
							this.image = imageList.Images[value];
						}
						catch
						{
							this.image = null;
						}
						Invalidate();
					}
				}
			}
		}
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


		/// <summary>
		/// 버튼의 폰트를 지정 합니다.
		/// </summary>
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}

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
				//Mouse Down
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
			textFormat.Trimming = StringTrimming.EllipsisWord;

			int textLen = this.Text.Length;
			// Menomic 문자 처리
			if ((this.Text.IndexOf("&") >= 0) && (textLen > this.Text.IndexOf("&") + 1))
				textLen --;

			int X = this.Width;
			int Y = this.Height;
			
			// Size가 최초 Size미만 이면 그리지 않음
			if ((X < cMinPaintSize) || (Y < cMinPaintSize)) return;

			e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;

			PointF textPoint = PointF.Empty;
			Rectangle imageRect = Rectangle.Empty;
			Rectangle textRect = this.ClientRectangle;
			//Image가 있으면 Default Margin을 줌
			if (image != null)
			{
				textRect.X += 5;
				textRect.Width -= 5;
			}
			//textRect.Y += 1;
			//textRect.Height -= 1;
			
			if (image != null)
			{
				//ImagePadding 적용
				Rectangle iRect = GetRectByPadding(this.ImageAlign, this.imagePadding, textRect);
				PointF pointImage = DrawHelper.GetObjAlignment(this.ImageAlign,iRect.Left, iRect.Top, iRect.Width, iRect.Height, Image.Width, Image.Height);
				RectangleF iRectF = iRect;
				iRectF.Intersect(new RectangleF(pointImage, Image.PhysicalDimension));
				imageRect = Rectangle.Truncate(iRectF);
				//imageAlignment가 Left이면 X이동 Width 감소, Right이면 Width감소
				if (DrawHelper.IsLeft(this.ImageAlign))
				{
					textRect.X += Image.Width;
					textRect.Width -= Image.Width;
				}
				else if (DrawHelper.IsRight(this.ImageAlign))
				{
					textRect.Width -= Image.Width;
				}
			}
			//TextPoint 계산
			Rectangle tRect = GetRectByPadding(this.TextAlign, this.textPadding, textRect);
			Size textSize = DrawHelper.GetTextSize(e.Graphics, this.Text, this.Font, tRect.Width);
			textPoint = DrawHelper.GetObjAlignment(this.TextAlign, tRect.Left, tRect.Top, tRect.Width, tRect.Height, textSize.Width, textSize.Height);

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
						ControlPaint.DrawImageDisabled(e.Graphics, image, imageRect.X, imageRect.Y, this.BackColor);
					if (this.Text != "")
						e.Graphics.DrawString(this.Text, this.Font, SystemBrushes.ControlDark, textPoint, textFormat);

					_brush.Dispose();
					_brush01.Dispose();
					_pen01.Dispose();
					_pen02.Dispose();
				}
				catch{}
				return;
			}
			
			//Selected, MouseOver Color는 동일
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
				case XButtonSchemes.OliveGreen:
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

				case XButtonSchemes.Silver:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(250, 252, 254), Color.FromArgb(228, 232, 248), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(228, 232, 248));
					pen02 = new Pen(Color.FromArgb(206, 213, 238));
					pen03 = new Pen(Color.FromArgb(182, 187, 224));

					pen04 = new Pen(Color.FromArgb(206, 213, 238));
					pen05 = new Pen(Color.FromArgb(182, 187, 224));
					
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(113, 121, 149));
					pen1 = new Pen(Color.FromArgb(113, 121, 149));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;

				case XButtonSchemes.Green:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(252, 254, 250), Color.FromArgb(232, 247, 227), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(232, 247, 227));
					pen02 = new Pen(Color.FromArgb(217, 238, 206));
					pen03 = new Pen(Color.FromArgb(191, 224, 180));

					pen04 = new Pen(Color.FromArgb(217, 238, 206));
					pen05 = new Pen(Color.FromArgb(191, 224, 180));
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(117, 141, 137));
					pen1 = new Pen(Color.FromArgb(117, 141, 137));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;
				case XButtonSchemes.HotPink:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(253, 250, 253), Color.FromArgb(247, 233, 243), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(247, 233, 243));
					pen02 = new Pen(Color.FromArgb(236, 212, 231));
					pen03 = new Pen(Color.FromArgb(224, 192, 214));

					pen04 = new Pen(Color.FromArgb(236, 212, 231));
					pen05 = new Pen(Color.FromArgb(224, 192, 214));
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(147, 120, 142));
					pen1 = new Pen(Color.FromArgb(147, 120, 142));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;
				case XButtonSchemes.SkyBlue:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(249, 253, 251), Color.FromArgb(223, 244, 239), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(223, 244, 239));
					pen02 = new Pen(Color.FromArgb(196, 228, 221));
					pen03 = new Pen(Color.FromArgb(169, 213, 209));

					pen04 = new Pen(Color.FromArgb(196, 228, 221));
					pen05 = new Pen(Color.FromArgb(169, 213, 209));
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(93, 136, 139));
					pen1 = new Pen(Color.FromArgb(93, 136, 139));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
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
					pen0 = new Pen(Color.FromArgb(116, 143, 139));
					pen1 = new Pen(Color.FromArgb(116, 143, 139));
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
				if (image != null)
					e.Graphics.DrawImage(image, imageRect);
				if (Text != "")
					e.Graphics.DrawString(this.Text, this.Font, SystemBrushes.ControlText, textPoint, textFormat);

				
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
		private Rectangle GetRectByPadding(ContentAlignment align, Point padPoint, Rectangle origRect)
		{
			int left = origRect.Left;
			int top  = origRect.Top;
			int width = origRect.Width;
			int height = origRect.Height;
			if (padPoint.X > 0)
			{
				if (DrawHelper.IsLeft(align) || DrawHelper.IsHCenter(align))
					left += padPoint.X;
				else
					width = Math.Max(width - padPoint.X,0);
			}
			if (padPoint.Y > 0)
			{
				if (DrawHelper.IsTop(align) || DrawHelper.IsVCenter(align))
					top += padPoint.Y;
				else
					height = Math.Max(height - padPoint.Y,0);
			}
			return new Rectangle(left, top, width, height);
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
				
				// DialogResult가 None이 아니면 Form에 Result를 전달하여  Form Close
				if (this.DialogResult != DialogResult.None)
				{
					try
					{
						Form form = this.FindForm();
						form.DialogResult = this.DialogResult;
					}
					catch{}
				}
				base.OnClick(e);
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
			//2006.02.09 Mnemonic 문자는 Enable 상태에서만 처리가능하게
			if (this.Enabled && XButton.IsMnemonic(charCode, this.Text))
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

		#region IEditorControl Implementation
		/// <summary>
		/// Button은 DataValue를 관리하지 않음
		/// </summary>
		object IEditorControl.DataValue
		{
			get { return string.Empty;}
			set {}
		}
		/// <summary>
		/// 편집가능여부
		/// </summary>
		bool IEditorControl.Protect
		{
			get { return !this.Enabled;}
			set { this.Enabled = !value;}
		}
		#endregion

	}
}
