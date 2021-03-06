using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	[ToolboxBitmap(typeof(System.Windows.Forms.Panel))]
	public class XRoundPanel : System.Windows.Forms.Panel
	{
		#region Fields
		private XColor gradientStart = XColor.XRoundPanelGradientStartColor;
		private XColor gradientEnd = XColor.XRoundPanelGradientEndColor;
		private XColor borderColor = XColor.XRoundPanelBorderColor;
		private XColor uBackColor = XColor.XRoundPanelBackColor;
		private PanelDrawMode drawMode = PanelDrawMode.Flat;
		private int borderWidth = 1; //Border의 Width
		private int curvature = 10; //곡율
		private BorderStyle borderStyle = BorderStyle.FixedSingle; //base의 BorderStyle을 쓰지 하지 않고 따로 적용
		private PanelCurveMode curveMode = PanelCurveMode.All; // Curve 그리기 모드
		#endregion

		#region Base Properties
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get { return base.Font; }
			set { base.Font = value; }
		}
		[Browsable(false)]
		public override Color ForeColor
		{
			get { return base.ForeColor;}
			set { base.ForeColor = value;}
		}
		[Category("추가속성")]
		[DefaultValue(BorderStyle.FixedSingle)]
		public new BorderStyle BorderStyle
		{
			get { return borderStyle; }
			set
			{
				borderStyle = value;
				Invalidate();
			}
		}
		#endregion

		#region Properties
		[DefaultValue(typeof(XColor), "XRoundPanelBackColor"),
		Description("Flat형일때 배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return uBackColor; }
			set
			{
				uBackColor = value;
				Invalidate();

			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 시작색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor), "XRoundPanelGradientStartColor"),
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
				Invalidate();
			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 종료색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor), "XRoundPanelGradientEndColor"),
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
				Invalidate();
			}
		}
		/// <summary>
		/// 경계선색(Color형)을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor), "XRoundPanelBorderColor"),
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
				Invalidate();
			}
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(PanelDrawMode.Flat),
		MergableProperty(true),
		Description("배경 칠하기 속성을 지정합니다.")]
		public PanelDrawMode DrawMode
		{
			get { return drawMode; }
			set
			{
				drawMode = value;
				Invalidate();
			}
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(1),
		MergableProperty(true),
		Description("Border의 Width(1-30)를 지정합니다.(Fixed Single시 적용)")]
		public int BorderWidth
		{
			get { return borderWidth; }
			set
			{
				borderWidth = Math.Max(1, Math.Min(value,30));
				Invalidate();
			}
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(10),
		MergableProperty(true),
		Description("Border의 곡율(0-90)을 지정합니다.")]
		public int Curvature
		{
			get { return curvature; }
			set
			{
				curvature = Math.Max(0, Math.Min(90,value));
				Invalidate();
			}
		}
		[Browsable(true),
		Category("추가속성"),
		DefaultValue(PanelCurveMode.All),
		MergableProperty(true),
		Description("Border의 곡선모드를 지정합니다.")]
		public PanelCurveMode CurveMode
		{
			get { return curveMode; }
			set
			{
				curveMode = value;
				Invalidate();
			}
		}
		private int adjustedCurve
		{
			get
			{
				int curve = 0;
				if (!(this.curveMode == PanelCurveMode.None))
				{
					if (this.curvature > (this.ClientRectangle.Width / 2))
					{
						curve = this.ClientRectangle.Width / 2;
					}
					else
					{
						curve = this.curvature;
					}
					if (curve > (this.ClientRectangle.Height / 2))
					{
						curve = this.ClientRectangle.Height / 2;
					}
				}
				return curve;
			}
		}
		#endregion

		#region 생성자
		public XRoundPanel()
		{
			this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

			this.Font = new Font("MS UI Gothic", 9.75f);
			//Base BackColor 투명색 (base.OnPaintBackground()에서 투명하게 그리도록함
			base.BackColor = Color.Transparent;
			//Base의 BorderStyle 적용하지 않음 (None)
			base.BorderStyle = BorderStyle.None;
		}
		#endregion

		#region OnPaintBackground override
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			GraphicsPath graphPath;
			graphPath = this.GetPath();
			//	Create Gradient Brush (Cannot be width or height 0)
			LinearGradientBrush filler;
			Rectangle rect = this.ClientRectangle;
			if (this.ClientRectangle.Width == 0)
			{
				rect.Width += 1;
			}
			if (this.ClientRectangle.Height == 0)
			{
				rect.Height += 1;
			}
			if (this.drawMode == PanelDrawMode.Flat)
			{
				filler = new LinearGradientBrush(rect, this.uBackColor.Color, this.uBackColor.Color, LinearGradientMode.Vertical);
			}
			else
			{
				filler = new LinearGradientBrush(rect, this.gradientStart.Color, this.gradientEnd.Color, ((LinearGradientMode)this.drawMode));
			}
			pevent.Graphics.FillPath(filler, graphPath);
			filler.Dispose();

			//Border Draw (None은 그리지 않음)
			if (this.borderStyle == BorderStyle.FixedSingle)
			{
				using (Pen borderPen = new Pen(this.borderColor.Color, this.borderWidth))
				{
					pevent.Graphics.DrawPath(borderPen, graphPath);
				}
			}
			else if (this.borderStyle == BorderStyle.Fixed3D)
			{
				DrawBorder3D(pevent.Graphics, this.ClientRectangle);
			}
			filler.Dispose();
			graphPath.Dispose();
		}
		#endregion

		#region 그리기 함수
		protected GraphicsPath GetPath()
		{
			GraphicsPath graphPath = new GraphicsPath();
			if (this.borderStyle == BorderStyle.Fixed3D)
			{
				graphPath.AddRectangle(this.ClientRectangle);
			}
			else
			{
				try
				{
					int curve = 0;
					Rectangle rect = this.ClientRectangle;
					int offset = 0;
					if (this.borderStyle == BorderStyle.FixedSingle)
					{
						if (this.borderWidth > 1)
							offset = borderWidth / 2;
						curve = this.adjustedCurve;
					}
					else if (this.borderStyle == System.Windows.Forms.BorderStyle.None)
					{
						curve = this.adjustedCurve;
					}
					if (curve == 0)
					{
						graphPath.AddRectangle(Rectangle.Inflate(rect, -offset, -offset));
					}
					else
					{
						int rectWidth = rect.Width - 1 - offset;
						int rectHeight = rect.Height - 1 - offset;
						int curveWidth = 1;
						if ((this.curveMode & PanelCurveMode.TopRight) != 0)
						{
							curveWidth = (curve * 2);
						}
						else
						{
							curveWidth = 1;
						}
						graphPath.AddArc(rectWidth - curveWidth, offset, curveWidth, curveWidth, 270, 90);
						if ((this.curveMode & PanelCurveMode.BottomRight) != 0)
						{
							curveWidth = (curve * 2);
						}
						else
						{
							curveWidth = 1;
						}
						graphPath.AddArc(rectWidth - curveWidth, rectHeight - curveWidth, curveWidth, curveWidth, 0, 90);
						if ((this.curveMode & PanelCurveMode.BottomLeft) != 0)
						{
							curveWidth = (curve * 2);
						}
						else
						{
							curveWidth = 1;
						}
						graphPath.AddArc(offset, rectHeight - curveWidth, curveWidth, curveWidth, 90, 90);
						if ((this.curveMode & PanelCurveMode.TopLeft) != 0)
						{
							curveWidth = (curve * 2);
						}
						else
						{
							curveWidth = 1;
						}
						graphPath.AddArc(offset, offset, curveWidth, curveWidth, 180, 90);
						graphPath.CloseFigure();
					}
				}
				catch (System.Exception)
				{
					graphPath.AddRectangle(this.ClientRectangle);
				}
			}
			return graphPath;
		}

		private static void DrawBorder3D(Graphics graphics, Rectangle rectangle)
		{
			graphics.SmoothingMode = SmoothingMode.Default;
			graphics.DrawLine(SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Y);
			graphics.DrawLine(SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.X, rectangle.Height - 1);
			graphics.DrawLine(SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 1, rectangle.Y + 1);
			graphics.DrawLine(SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.X + 1, rectangle.Height - 1);
			graphics.DrawLine(SystemPens.ControlLight, rectangle.X + 1, rectangle.Height - 2, rectangle.Width - 2, rectangle.Height - 2);
			graphics.DrawLine(SystemPens.ControlLight, rectangle.Width - 2, rectangle.Y + 1, rectangle.Width - 2, rectangle.Height - 2);
			graphics.DrawLine(SystemPens.ControlLightLight, rectangle.X, rectangle.Height - 1, rectangle.Width - 1, rectangle.Height - 1);
			graphics.DrawLine(SystemPens.ControlLightLight, rectangle.Width - 1, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
		}
		#endregion
	}

	#region enum
	public enum PanelCurveMode
	{

		None = 0,
		TopLeft = 1,
		TopRight = 2,
		TopLeft_TopRight = 3,
		BottomLeft = 4,
		TopLeft_BottomLeft = 5,
		TopRight_BottomLeft = 6,
		TopLeft_TopRight_BottomLeft = 7,
		BottomRight = 8,
		BottomRight_TopLeft = 9,
		BottomRight_TopRight = 10,
		BottomRight_TopLeft_TopRight = 11,
		BottomRight_BottomLeft = 12,
		BottomRight_TopLeft_BottomLeft = 13,
		BottomRight_TopRight_BottomLeft = 14,
		All = 15

	}
	public enum PanelDrawMode
	{
		Horizontal = 0,
		Vertical = 1,
		ForwardDiagonal = 2,
		BackwardDiagonal = 3,
		Flat = 4
	}
	#endregion
}
