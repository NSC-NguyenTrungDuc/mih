using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region enum (XProgressBarDrawMode)
	public enum XProgressBarDrawMode
	{
		Vertical,
		VerticalCenter,
		Horizontal,
		HorizontalCenter,
		Diagonal
	}
	#endregion

	/// <summary>
	/// XProgressBar에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
	[Designer(typeof(XProgressBarDesigner))]
	public class XProgressBar : System.Windows.Forms.Control
	{
		#region Fields without Properties
		private Image drawImage = null;
		private Rectangle innerRect;
		private LinearGradientBrush drawBrush1;
		private LinearGradientBrush drawBrush2;
		private Pen mPenIn = new Pen(Color.FromArgb(239, 239, 239));
		private Pen mPenOut = new Pen(Color.FromArgb(104, 104, 104));
		private Pen mPenOut2 = new Pen(Color.FromArgb(190, 190, 190));

		private Rectangle stepRect1;
		private Rectangle stepRect2;
		private Rectangle outerRect1;
		private Rectangle outerRect2;
		#endregion

		#region Fields having Properties
		private XColor gradientStart	= XColor.XProgressBarGradientStartColor;
		private XColor gradientEnd		= XColor.XProgressBarGradientEndColor;
		private XColor xBackColor		= XColor.XProgressBarBackColor;
		private XColor xForeColor		= XColor.XProgressBarTextColor;
		private XProgressBarDrawMode drawMode = XProgressBarDrawMode.VerticalCenter;
		private int maximum = 100;  //Max값
		private int minimum = 0;    //Min값
		private int data = 0;  //현재값
		private int stepWidth = 3;  //Step의 너비
		private int stepDistance = 1;  //Step사이의 간격
		private bool textShadow = true;
		private int textShadowAlpha = 150;  //TextShawdow의 색상의 Alpha값을 지정
		#endregion

		#region base override
		[Category("모양")]
		[DefaultValue(typeof(XColor),"XProgressBarBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
				this.InvalidateBuffer();
			}
		}
		[Category("모양")]
		[DefaultValue(typeof(XColor),"XProgressBarTextColor"),
		Description("텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
				this.InvalidateBuffer();
			}
		}
		[Category("모양")]
		[DefaultValue(null)]
		[Description("ProgressBar의 배경 Image를 설정합니다.")]
		public override Image BackgroundImage
		{
			get { return base.BackgroundImage; }
			set
			{
				base.BackgroundImage = value;
				InvalidateBuffer();
			}
		}
		[Category("모양")]
		[Description("ProgressBar에 보여질 Text를 지정합니다.")]
		[DefaultValue("")]
		public override string Text
		{
			get { return base.Text; }
			set
			{
				if (base.Text != value)
				{
					base.Text = value;
					this.Invalidate();
				}
			}
		}
		[Category("모양")]
		[Browsable(true), DefaultValue(typeof(Font), "Tahoma, 9.75pt, style=Bold")]
		[Description("ProgressBar에 보여질 Text의 Font를 설정합니다.")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	
			{ 
				if (base.Font != value)
				{
					base.Font = value;
					this.Invalidate();
				}
			}
		}
		protected override Size DefaultSize
		{
			get { return new Size(100, 29); }
		}
		#endregion

		#region Properties
		[Category("모양")]
		[DefaultValue(typeof(XColor),"XProgressBarGradientStartColor")]
		[Description("Bar의 Gradient 시작색을 지정합니다.")]
		public XColor GradientStart
		{
			get { return gradientStart; }
			set
			{
				gradientStart = value;
				InvalidateBuffer();
			}
		}
		[Category("모양")]
		[DefaultValue(typeof(XColor),"XProgressBarGradientEndColor")]
		[Description("Bar의 Gradient 종료색을 지정합니다.")]
		public XColor GradientEnd
		{
			get { return gradientEnd; }
			set
			{
				gradientEnd = value;
				InvalidateBuffer();
			}
		}
		[Category("모양")]
		[DefaultValue(XProgressBarDrawMode.VerticalCenter)]
		[Description("Bar의 그리기 모양을 지정합니다.")]
		public XProgressBarDrawMode DrawMode
		{
			get { return drawMode; }
			set
			{
				if (drawMode != value)
				{
					drawMode = value;
					InvalidateBuffer();
				}
			}
		}
		[Category("모양")]
		[DefaultValue(3)]
		[Description("Bar의 Step의 너비를 지정합니다.")]
		public int StepWidth
		{
			get { return stepWidth; }
			set
			{
				if (stepWidth != value)
				{
					stepWidth = Math.Max(0, value);
					this.InvalidateBuffer();
				}
			}
		}
		[Category("모양")]
		[DefaultValue(1)]
		[Description("Bar의 Step사이의 간격을 지정합니다.(0로 설정하면 Step간격이 없어집니다)")]
		public int StepDistance
		{
			get { return stepDistance; }
			set
			{
				if (stepDistance != value)
				{
					stepDistance = Math.Max(0, value);
					this.InvalidateBuffer();
				}
			}
		}
		[Category("모양")]
		[DefaultValue(true)]
		[Description("Bar Text에 Shadow를 적용할지 여부를 지정합니다.")]
		public bool TextShadow
		{
			get { return textShadow; }
			set
			{
				if (textShadow != value)
				{
					textShadow = value;
					Invalidate();
				}
			}
		}
		[Category("모양")]
		[DefaultValue(150)]
		[Description("Bar Text에 Shadow를 적용시에 ShadowText 색상의 Alpha값을 지정합니다.(0-255)")]
		public int TextShadowAlpha
		{
			get { return textShadowAlpha; }
			set
			{
				if (textShadowAlpha != value)
				{
					textShadowAlpha = Math.Max(0, Math.Min(value,255));
					Invalidate();
				}
			}
		}
		[Category("동작")]
		[DefaultValue(100)]
		[Description("Bar의 Max값을 지정합니다.")]
		public int Maximum
		{
			get { return maximum; }
			set
			{
				if (value > minimum)
				{
					maximum = value;
					if (data > maximum)
						data = maximum;
					InvalidateBuffer();
				}
			}
		}
		[Category("동작")]
		[DefaultValue(0)]
		[Description("Bar의 Min값을 지정합니다.")]
		public int Minimum
		{
			get { return minimum; }
			set
			{
				if (value < maximum)
				{
					minimum = value;
					if (data < minimum)
						data = minimum;
					InvalidateBuffer();
				}
			}
		}
		[Category("동작")]
		[DefaultValue(0)]
		[Description("Bar의 Value를 지정합니다.")]
		public int Value
		{
			get { return data; }
			set
			{
				if (data != value)
				{
					data = Math.Max(Math.Min(value, maximum), minimum);
					this.InvalidateBuffer();
				}
			}
		}
		#endregion

		#region 생성자
		public XProgressBar()
		{
			//base.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                base.Font = new Font("Tahoma", 9.75f, FontStyle.Bold);
            }
            else
            {
                base.Font = Service.COMMON_FONT_BOLD;
            }
		}
		#endregion

		#region Override
		protected override void Dispose(bool disposing)
		{
			//drawImage, Brush Dispose
			if (drawImage != null)
				drawImage.Dispose();
			if (drawBrush1 != null)
				drawBrush1.Dispose();
			if (drawBrush2 != null)
				drawBrush2.Dispose();

			base.Dispose(disposing);
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			if (!this.IsDisposed)
			{
				if (this.Height < 12)
					this.Height = 12;
				base.OnSizeChanged(e);
				this.InvalidateBuffer();
			}
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			//기능없음
		}
		#endregion

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			int stepTotalCount = stepWidth + stepDistance;
			float mUtilWidth = this.Width - 6 + stepDistance;

			if (drawImage == null)
			{
				mUtilWidth = this.Width - 6 + stepDistance;
				int maximumSteeps = (int) (mUtilWidth/stepTotalCount);
				this.Width = 6 + stepTotalCount*maximumSteeps;

				drawImage = new Bitmap(this.Width, this.Height);

				Graphics g2 = Graphics.FromImage(drawImage);

				CreatePaintElements();
				
				g2.Clear(xBackColor.Color);
				
				//BackGround Draw
				if (this.BackgroundImage != null)
				{
					using (TextureBrush br = new TextureBrush(this.BackgroundImage, WrapMode.Tile))
						g2.FillRectangle(br, 0, 0, this.Width, this.Height);
				}

				g2.DrawRectangle(mPenOut2, outerRect2);
				g2.DrawRectangle(mPenOut, outerRect1);
				g2.DrawRectangle(mPenIn, innerRect);
				g2.Dispose();

			}

			Image tempImage = new Bitmap(drawImage);

			Graphics gtemp = Graphics.FromImage(tempImage);

			int drawStepCount = (int) ((((float) data - minimum)/(maximum - minimum))*mUtilWidth/stepTotalCount);

			for (int i = 0; i < drawStepCount; i++)
			{
				DrawStep(gtemp, i);
			}

			if (this.Text != String.Empty)
			{
				gtemp.TextRenderingHint = TextRenderingHint.AntiAlias;
				DrawCenterString(gtemp, this.ClientRectangle);
			}

			e.Graphics.DrawImage(tempImage, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle, GraphicsUnit.Pixel);
			tempImage.Dispose();
			gtemp.Dispose();

		}
		#endregion

		#region Draw Method

		private void DrawStep(Graphics g, int number)
		{
			g.FillRectangle(drawBrush1, 4 + number*(stepDistance + stepWidth), stepRect1.Y + 1, stepWidth, stepRect1.Height);
			g.FillRectangle(drawBrush2, 4 + number*(stepDistance + stepWidth), stepRect2.Y + 1, stepWidth, stepRect2.Height - 1);
		}
		private void InvalidateBuffer()
		{
			//기 생성된 DrawImage Reset후 다시 그림
			if (drawImage != null)
			{
				drawImage.Dispose();
				drawImage = null;
			}
			//Redraw
			this.Invalidate();
		}

		private void DisposeBrushes()
		{
			if (drawBrush1 != null)
			{
				drawBrush1.Dispose();
				drawBrush1 = null;
			}

			if (drawBrush2 != null)
			{
				drawBrush2.Dispose();
				drawBrush2 = null;
			}

		}

		private void DrawCenterString(Graphics gfx, Rectangle box)
		{
			SizeF ss = gfx.MeasureString(this.Text, this.Font);

			float left = box.X + (box.Width - ss.Width)/2;
			float top = box.Y + (box.Height - ss.Height)/2;

			if (textShadow)
			{
				using (SolidBrush br = new SolidBrush(Color.FromArgb(textShadowAlpha, Color.Black)))
					gfx.DrawString(this.Text, this.Font, br, left + 1, top + 1);
			}
			using (SolidBrush br = new SolidBrush(this.xForeColor.Color))  //Text Draw
				gfx.DrawString(this.Text, this.Font, br, left, top);
		}
		#endregion

		#region CreatePaintElements (Paint시 사용할 Field 설정)
		private void CreatePaintElements()
		{
			DisposeBrushes();

			switch (drawMode)
			{
				case XProgressBarDrawMode.VerticalCenter:

					stepRect1 = new Rectangle(
						0,
						2,
						stepWidth,
						this.Height/2 + (int) (this.Height*0.05));
					drawBrush1 = new LinearGradientBrush(stepRect1, gradientStart.Color, gradientEnd.Color, LinearGradientMode.Vertical);

					stepRect2 = new Rectangle(
						0,
						stepRect1.Bottom - 1,
						stepWidth,
						this.Height - stepRect1.Height - 4);
					drawBrush2 = new LinearGradientBrush(stepRect2, gradientEnd.Color, gradientStart.Color, LinearGradientMode.Vertical);
					break;

				case XProgressBarDrawMode.Vertical:
					stepRect1 = new Rectangle(
						0,
						3,
						stepWidth,
						this.Height - 7);
					drawBrush1 = new LinearGradientBrush(stepRect1, gradientStart.Color, gradientEnd.Color, LinearGradientMode.Vertical);
					stepRect2 = new Rectangle(
						-100,
						-100,
						1,
						1);
					drawBrush2 = new LinearGradientBrush(stepRect2, gradientEnd.Color, gradientStart.Color, LinearGradientMode.Horizontal);
					break;


				case XProgressBarDrawMode.Horizontal:
					stepRect1 = new Rectangle(
						0,
						3,
						stepWidth,
						this.Height - 7);

					drawBrush1 = new LinearGradientBrush(this.ClientRectangle, gradientStart.Color, gradientEnd.Color, LinearGradientMode.Horizontal);
					stepRect2 = new Rectangle(
						-100,
						-100,
						1,
						1);
					drawBrush2 = new LinearGradientBrush(stepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
					break;


				case XProgressBarDrawMode.HorizontalCenter:
					stepRect1 = new Rectangle(
						0,
						3,
						stepWidth,
						this.Height - 7);
					drawBrush1 = new LinearGradientBrush(this.ClientRectangle, gradientStart.Color, gradientEnd.Color, LinearGradientMode.Horizontal);
					drawBrush1.SetBlendTriangularShape(0.5f);

					stepRect2 = new Rectangle(
						-100,
						-100,
						1,
						1);
					drawBrush2 = new LinearGradientBrush(stepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
					break;


				case XProgressBarDrawMode.Diagonal:
					stepRect1 = new Rectangle(
						0,
						3,
						stepWidth,
						this.Height - 7);
					drawBrush1 = new LinearGradientBrush(this.ClientRectangle, gradientStart.Color, gradientEnd.Color, LinearGradientMode.ForwardDiagonal);
					stepRect2 = new Rectangle(
						-100,
						-100,
						1,
						1);
					drawBrush2 = new LinearGradientBrush(stepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
					break;

				default:
					drawBrush1 = new LinearGradientBrush(stepRect1, gradientStart.Color, gradientEnd.Color, LinearGradientMode.Vertical);
					drawBrush2 = new LinearGradientBrush(stepRect2, gradientEnd.Color, gradientStart.Color, LinearGradientMode.Vertical);
					break;

			}

			innerRect = new Rectangle(
				this.ClientRectangle.X + 2,
				this.ClientRectangle.Y + 2,
				this.ClientRectangle.Width - 4,
				this.ClientRectangle.Height - 4);
			outerRect1 = new Rectangle(
				this.ClientRectangle.X,
				this.ClientRectangle.Y,
				this.ClientRectangle.Width - 1,
				this.ClientRectangle.Height - 1);
			outerRect2 = new Rectangle(
				this.ClientRectangle.X + 1,
				this.ClientRectangle.Y + 1,
				this.ClientRectangle.Width,
				this.ClientRectangle.Height);

		}
		#endregion
	}

	/// <summary>
	/// BlankTextDesigner에 대한 요약 설명입니다.
	/// 최초 Control을 Design할 때 기본으로 보이는 Text를 안보이게 합니다.
	/// </summary>
	internal class XProgressBarDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		/// <summary>
		/// 디자이너가 초기화될 때 호출되므로 디자이너는 구성 요소의 속성을 기본값으로 설정
		/// (override) 기본값을 정의하지 않음 
		/// </summary>
		//public override void OnSetComponentDefaults()
		//{
		//}
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            this.Control.Text = "";
        }

	}
}
