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
	public class XLabel : System.Windows.Forms.Label
	{
		#region Class Variables
		private DrawPattern lp = DrawPattern.Flat;	// 기본값
		private XColor gradientStart	= XColor.XLabelGradientStartColor;
		private XColor gradientEnd		= XColor.XLabelGradientEndColor;
		private XColor borderColor		= XColor.XLabelBorderColor;
		private XColor xBackColor		= XColor.XLabelBackColor;
		private XColor xForeColor		= XColor.XLabelForeColor;
		private bool	edgeRounding = true;
		private Point[]	regionPoints;
		private const int cMargin = 2;  //Draw시 Margin
		private Point imagePadding = new Point(0,0);
		private Point textPadding  = new Point(0,0);
		private StringFormat textFormat = new StringFormat(); //Text Draw Format
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
		/// <summary>
		/// 컨트롤의 테두리 스타일을 가져오거나 설정합니다(재정의 Not Browsable)
		/// </summary>
		[Browsable(false)]
		public override BorderStyle BorderStyle 
		{
			get { return base.BorderStyle;}
			set { base.BorderStyle = value;}
		}
		/// <summary>
		/// 레이블 컨트롤의 평면 스타일 모양을 가져오거나 설정합니다(재정의 Not Browsable)
		/// </summary>
		[Browsable(false)]
		public new FlatStyle FlatStyle
		{
			get { return base.FlatStyle;}
			set { base.FlatStyle = value;}
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
		/// <summary>
		/// Image를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(null)]
		public new Image Image 
		{
			get { return base.Image;}
			set 
			{
				if (base.Image != value)
				{
					//ImageFormat이 BMP이면 TransParent 지정
					if (value != null)
					{
						try
						{
							Bitmap bmp = (Bitmap) value;
							bmp.MakeTransparent();
							base.Image = bmp;
						}
						catch{}
					}
					else
						base.Image = value;
				}
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properties
		/// <summary>
		/// 배경색 칠하기 패턴(Plat,Gradient등)을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), 
		Category("추가속성"),
		DefaultValue(DrawPattern.Flat),
		MergableProperty(true),
		Description("바탕 칠하기 속성을 지정합니다.")]
		public DrawPattern BackGroundPattern
		{
			get { return lp; }
			set 
			{ 
				lp = value; 
				Invalidate(ClientRectangle); 
			}
		}
		/// <summary>
		/// 외곽 모서리를 둥글게 처리할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(true),
		MergableProperty(true),
		Description("외곽 모서리를 둥글게 처리할지 여부를 지정합니다.")]
		public bool EdgeRounding
		{
			get { return edgeRounding; }
			set
			{
				edgeRounding = value;
				OnParentChanged(new EventArgs());
			}
		}
		[Browsable(true),
		Category("추가속성"),
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
		Category("추가속성"),
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
		/// 배경을 Gradient로 그릴때 시작색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XLabelGradientStartColor"),
		MergableProperty(true),
		Description("배경을 Gradient로 그릴때 시작색을 지정합니다.")]
		public XColor GradientStartColor
		{
			get 
			{ 
				return gradientStart; 
			}
			set	
			{ 
				gradientStart = value;
				Invalidate(ClientRectangle);
			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 종료색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XLabelGradientEndColor"),
		MergableProperty(true),
		Description("배경을 Gradient로 그릴때 종료색을 지정합니다.")]
		public XColor GradientEndColor
		{
			get 
			{ 
				return gradientEnd; 
			}
			set	
			{ 
				gradientEnd = value;
				Invalidate(ClientRectangle);
			}
		}
		/// <summary>
		/// 경계선색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XLabelBorderColor"),
		MergableProperty(true),
		Description("경계선색을 지정합니다.")]
		public XColor BorderColor
		{
			get 
			{ 
				return borderColor; 
			}
			set	
			{ 
				borderColor = value;
				Invalidate(ClientRectangle);
			}
		}
		#endregion

		#region Constructor(s)
		/// <summary>
		/// ADisplayBox 생성자
		/// </summary>
		public XLabel()
		{
			SetStyle(ControlStyles.DoubleBuffer|ControlStyles.AllPaintingInWmPaint|ControlStyles.UserPaint|ControlStyles.Opaque, true);
			this.BackColor = XColor.XLabelBackColor;
			this.ForeColor = XColor.XLabelForeColor;
			this.Text = "";
			this.TextAlign = ContentAlignment.MiddleLeft;
			this.Height = 21;

			// 2005/05/09 신종석 폰트 수정
			// this.Font = new Font("MS UI Gothic", 9.75f);

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

		#region Overrides
		/// <summary>
		/// 지정한 배경색,텍스트색,패턴에 따라 컨트롤을 그립니다.
		/// </summary>
		/// <param name="pe"> 이벤트 데이터가 들어 있는 PaintEventArgs </param>
		protected override void OnPaint(PaintEventArgs pe)
		{
			switch (lp)
			{
				case DrawPattern.Flat :
				{
					using (SolidBrush b = new SolidBrush(this.BackColor.Color))
						pe.Graphics.FillRectangle(b, ClientRectangle);
				}
					break;
				case DrawPattern.HorizonGRAD1 :
				{
					using (Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle,	gradientStart.Color, gradientEnd.Color, System.Drawing.Drawing2D.LinearGradientMode.Vertical))
						pe.Graphics.FillRectangle (b, ClientRectangle);
				}
					break;
				case DrawPattern.HorizonGRAD2 :
				{
					System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
					gPath.AddRectangle(ClientRectangle);
					System.Drawing.Drawing2D.PathGradientBrush pgb = new System.Drawing.Drawing2D.PathGradientBrush(gPath);
					pgb.CenterColor = gradientEnd.Color; 
					pgb.SurroundColors = new Color[] {gradientStart.Color};
					pgb.WrapMode = System.Drawing.Drawing2D.WrapMode.TileFlipX;
					pgb.FocusScales = new PointF(1.0f, 0.125f);
					pe.Graphics.FillPath (pgb, gPath);
					pgb.Dispose();
					gPath.Dispose();
				}
					break;
				case DrawPattern.DiagonalGRAD :
				{
					using (Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle,	gradientStart.Color, gradientEnd.Color, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal))
						pe.Graphics.FillRectangle (b, ClientRectangle);
				}
					break;
				case DrawPattern.SurroundGRAD :
				{
					System.Drawing.Drawing2D.GraphicsPath gPath = new System.Drawing.Drawing2D.GraphicsPath();
					gPath.AddRectangle(ClientRectangle);
					System.Drawing.Drawing2D.PathGradientBrush pgb = new System.Drawing.Drawing2D.PathGradientBrush(gPath);
					pgb.CenterColor = gradientEnd.Color; 
					pgb.SurroundColors = new Color[] {gradientStart.Color};
					pgb.WrapMode = System.Drawing.Drawing2D.WrapMode.TileFlipX;
					pgb.FocusScales = new PointF(0.8f, 0.125f);
					pe.Graphics.FillPath (pgb, gPath);
					pgb.Dispose();
					gPath.Dispose();
				}
					break;
			}

			if (edgeRounding && (regionPoints != null))
			{
				Point[] points = (Point[])(regionPoints.Clone());
				points[1].Offset(-1, 0);
				points[2].Offset(-1, 0);
				points[3].Offset(-1, 0);
				points[4].Offset(-1, -1);
				points[5].Offset(-1, -1);
				points[6].Offset(-1, -1);
				points[7].Offset(0, -1);
				points[8].Offset(0, -1);
				using (Pen p = new Pen(borderColor.Color))
					pe.Graphics.DrawLines(p, points);
			}
			else
			{
				Rectangle rect = ClientRectangle;
				rect.Width --;
				rect.Height --;
				using (Pen p = new Pen(borderColor.Color))
					pe.Graphics.DrawRectangle(p, rect);
			}

			//draw text
			int length = 0;
			for (int i = 0; i < Text.Length; i++)
			{
				length += (((int) Text[i]) > 255 ? 2 : 1);
			}
			
			//Text align조정
			Rectangle txtRect = ClientRectangle;
			txtRect.X += cMargin;
			txtRect.Width -= cMargin;
			txtRect.Y += cMargin;
			txtRect.Height -= cMargin;
		
			//Image Draw
			if (this.Image != null)
			{
				//ImagePadding 적용
				Rectangle iRect = GetRectByPadding(this.ImageAlign, this.imagePadding, txtRect);
				PointF pointImage = DrawHelper.GetObjAlignment(this.ImageAlign,iRect.Left, iRect.Top, iRect.Width, iRect.Height, Image.Width, Image.Height);
				RectangleF imageRect = iRect;
				imageRect.Intersect(new RectangleF(pointImage, Image.PhysicalDimension));
				//Truncate the Rectangle for appreximation problem
				pe.Graphics.DrawImageUnscaled(Image,Rectangle.Truncate(imageRect));
				//imageAlignment가 Left이면 X이동 Width 감소, Right이면 Width감소
				if (DrawHelper.IsLeft(this.ImageAlign))
				{
					txtRect.X += Image.Width;
					txtRect.Width -= Image.Width;
				}
				else if (DrawHelper.IsRight(this.ImageAlign))
				{
					txtRect.Width -= Image.Width;
				}
			}
			
			//Text Draw
			if ((Text.Length > 0) && (txtRect.Width > 2) && (txtRect.Height > 2))
			{
				//TextPadding
//				Rectangle tRect = GetRectByPadding(this.TextAlign, this.textPadding, txtRect);
//				SizeF txtSize = DrawHelper.MeasureString(pe.Graphics, Text, Font, this.TextAlign);
//				PointF txtPoint = DrawHelper.GetObjAlignment(this.TextAlign, tRect.Left, tRect.Top, tRect.Width, tRect.Height, txtSize.Width, txtSize.Height);
//				// Text
//				pe.Graphics.DrawString(Text, Font, new SolidBrush(this.ForeColor.Color), txtPoint);

				Rectangle tRect = GetRectByPadding(this.TextAlign, this.textPadding, txtRect);
				//LineAlign, Align 적용
				if (DrawHelper.IsTop(this.TextAlign))
					textFormat.LineAlignment = StringAlignment.Near;
				else if (DrawHelper.IsBottom(this.TextAlign))
					textFormat.LineAlignment = StringAlignment.Far;
				else
					textFormat.LineAlignment = StringAlignment.Center;

				if (DrawHelper.IsLeft(this.TextAlign))
					textFormat.Alignment = StringAlignment.Near;
				else if (DrawHelper.IsRight(this.TextAlign))
					textFormat.Alignment = StringAlignment.Far;
				else
					textFormat.Alignment = StringAlignment.Center;

				// Text Draw
				using(Brush br = new SolidBrush(this.ForeColor.Color))
					pe.Graphics.DrawString(Text, Font, br, tRect, textFormat);
			}
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
		/// Resize Event를 발생시킵니다.
		/// (override) 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnResize(System.EventArgs e)
		{
			base.OnResize(e);
			OnParentChanged(e);
		}
		/// <summary>
		/// ParentChanged Event를 발생시킵니다.
		/// (override) 외곽선을 둥글게 그릴때 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnParentChanged(System.EventArgs e)
		{
			if (this.Parent == null) return;

			if (edgeRounding)
			{
				int X = this.Width;
				int Y = this.Height;
				int rnd = 1;
				regionPoints = new Point[] {
											   new Point(rnd, 0),
											   new Point(X-rnd, 0),
											   new Point(X-rnd, rnd),
											   new Point(X, rnd),
											   new Point(X, Y-rnd),
											   new Point(X-rnd, Y-rnd),
											   new Point(X-rnd, Y),
											   new Point(rnd, Y),
											   new Point(rnd, Y-rnd),
											   new Point(0, Y-rnd),
											   new Point(0, rnd),
											   new Point(rnd, rnd) };

				GraphicsPath path = new GraphicsPath();
				path.AddLines(regionPoints);

				this.Region = new Region(path);
				path.Dispose();
			}
			else
			{
				base.OnParentChanged(e);
				//Label이 Panel이나 TabPage등 다른 Control의 Control로 들어갈때는 영역이 주어지므로 영역을 다시 계산해야 한다.
				//영역은 Control의 Rectangle 기준
				if (this.Region != null)
					this.Region = new Region(this.ClientRectangle);
			}
		}
		#endregion

	}
}