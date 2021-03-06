using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	#region XRotator
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(IHIS.Framework.XRotator), "Images.XTaskBar.bmp")]
	[DefaultProperty("Items")]
	[DesignerAttribute(typeof(XRotatorDesigner))]
	public class XRotator : XRotatorBaseControl
	{
		#region Fields
		const double constPercentage = 0.02f;
		/// <summary>
		/// flag if the title text needs to be centered
		/// </summary>
		private bool calculateTitleArea = true;

		/// <summary>
		/// reference to the text displayed as title
		/// </summary>
		private string titleText = "";

		/// <summary>
		/// the collection of rotatoritemdata objects
		/// </summary>
		private XRotatorItemCollection items = null;

		/// <summary>
		/// The template for the rotator frames
		/// </summary>
		private RotatorFrameTemplate template = null;

		/// <summary>
		/// the container for the rotator frames
		/// </summary>
		private RotatorFrameContainer frameContainer = null;

		/// <summary>
		/// Text color for the text displayed 
		/// </summary>
		private XColor titleTextColor = XColor.XRotatorTitleTextColor;

		/// <summary>
		/// instance of the text area 
		/// </summary>
		private RectangleF titleArea = RectangleF.Empty;

		private XColor xBackColor = XColor.XRotatorBackColor;
		private XColor gradientStartColor = XColor.XRotatorGradientStartColor;
		private XColor gradientEndColor = XColor.XRotatorGradientEndColor;
		private XRotatorBrushType backgroundBrushType = XRotatorBrushType.Gradient;
		#endregion

		#region base Properties
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set
			{
				base.Font = value;
				calculateTitleArea = true;
			}
		}
		[DefaultValue(typeof(XColor),"XRotatorBackColor"),
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
		#endregion

		#region Properties
		[Browsable(true)]
		[Category("추가속성")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("XRotatorItem을 관리하는 Collection을 가져옵니다.")]
		[Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
		public XRotatorItemCollection Items
		{
			get	{ return this.items;}
		}

		[Browsable(true)]
		[Category("추가속성")]
		[DefaultValue(XRotatorBrushType.Gradient)]
		[Description("배경영역을 그릴때 그리기모드(Solid,Gradient)를 지정합니다.")]
		public XRotatorBrushType BackgroundBrushType
		{
			get	{ return backgroundBrushType; }
			set	
			{ 
				if (backgroundBrushType != value)
				{
					backgroundBrushType = value; 
					this.Invalidate(true);
				}
			}
		}
		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorGradientStartColor")]
		[Description("배경을 Gradient로 그릴때 GradientStart Color를 지정합니다.")]
		public XColor GradientStartColor
		{
			get	{ return gradientStartColor;}
			set
			{
				if (gradientStartColor != value)
				{
					gradientStartColor = value;
					this.Invalidate(true);
				}
			}
		}
		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorGradientEndColor")]
		[Description("배경을 Gradient로 그릴때 GradientStart Color를 지정합니다.")]
		public XColor GradientEndColor
		{
			get	{ return gradientEndColor;}
			set
			{
				if (gradientEndColor != value)
				{
					gradientEndColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorTitleTextColor")]
		[Description("Title의 TextColor를 지정합니다.")]
		public XColor TitleTextColor
		{
			get	{ return titleTextColor;}
			set
			{
				if (titleTextColor != value)
				{
					titleTextColor = value;
					this.Invalidate(true);
				}
			}
		}
        
		[Category("추가속성")]
		[DefaultValue("")]
		[Description("Title의 Text를 지정합니다.")]
		public string TitleText
		{
			get	{ return titleText; }
			set
			{
				//<IHIS> TitleText 변경시 Area 다시 계산 Refresh
				if (titleText != value)
				{
					titleText = value;
					OnResize(EventArgs.Empty);
					Refresh();
				}
			}
		}
		[Category("추가속성")]
		[DefaultValue(150)]
		[Description("Frame이 움직일때 대기시간(mileSecond)을 지정합니다.")]
		public int FrameAnimationDelay
		{
			get { return frameContainer.AnimationDelay; }
			set	{ frameContainer.AnimationDelay = value;}
		}

		[Category("추가속성")]
		[DefaultValue(10)]
		[Description("Frame이 움직일때의 움직임의 단위(Pixel)을 지정합니다.(+로 지정시 아래에서 위로,-로 지정시 위에서 아래로 이동)")]
		public int FrameAnimationStep
		{
			get	{ return frameContainer.AnimationStep; }
			set	{ frameContainer.AnimationStep = value; }
		}

		[Category("추가속성")]
		[DefaultValue(XRotatorAxisMode.YAxis)]
		[Description("Frame의 움직임을 X축으로 할지, Y축으로 할지를 지정합니다.")]
		public XRotatorAxisMode AxisMode
		{
			get	{ return frameContainer.AnimationMode; }
			set	{ frameContainer.AnimationMode = value;	}
		}
		[Browsable(true)]
		[Category("추가속성")]
		[DefaultValue(XRotatorBrushType.Solid)]
		[Description("Frame의 Header영역을 그릴때 그리기모드(Solid,Gradient)를 지정합니다.")]
		public XRotatorBrushType HeaderBrushType
		{
			get	{ return template.HeaderBrushType; }
			set	
			{ 
				if (template.HeaderBrushType != value)
				{
					template.HeaderBrushType = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorHeaderBackColor")]
		[Description("Frame Header영역의 그리기모드가 Solid Type일때 배경색을 지정합니다.")]
		public XColor HeaderBackColor
		{
			get { return template.HeaderBackColor;}
			set	
			{ 
				if (template.HeaderBackColor != value)
				{
					template.HeaderBackColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorHeaderGradientStartColor")]
		[Description("Frame의 Header영역의 그리기모드가 Gradient Type일때 Gradient시작색을 지정합니다.")]
		public XColor HeaderGradientStartColor
		{
			get	{ return template.HeaderGradientStartColor;}
			set	
			{ 
				if (template.HeaderGradientStartColor != value)
				{
					template.HeaderGradientStartColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorHeaderGradientEndColor")]
		[Description("Frame의 Header영역의 그리기모드가 Gradient Type일때 Gradient종료색을 지정합니다.")]
		public XColor HeaderGradientEndColor
		{
			get { return template.HeaderGradientEndColor;}
			set	
			{ 
				if (template.HeaderGradientEndColor != value)
				{
					template.HeaderGradientEndColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorHeaderTextColor")]
		[Description("Frame Header영역의 Text색을 지정합니다.")]
		public XColor HeaderTextColor
		{
			get	{ return template.HeaderTextColor;}
			set	
			{ 
				if (template.HeaderTextColor != value)
				{
					template.HeaderTextColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[Category("추가속성")]
		[DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		[Description("Frame Header영역의 Font를 설정합니다.")]
		public Font HeaderFont
		{
			get	{ return template.HeaderFont;}
			set	
			{ 
				if (template.HeaderFont != value)
				{
					template.HeaderFont = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[Category("추가속성")]
		[DefaultValue(20)]
		[Description("전체 Frame중에서 Header의 비율을 지정(10%~90%)합니다.")]
		public int HeaderPersantage
		{
			get	{ return template.HeaderPersantage;}
			set	{ template.HeaderPersantage = Math.Max(10, Math.Min(value,90));}
		}

		[Browsable(true)]
		[Category("추가속성")]
		[DefaultValue(XRotatorBrushType.Solid)]
		[Description("Frame Body영역의 그리기모드(Solid, Gradient)를 지정합니다.")]
		public XRotatorBrushType BodyBrushType
		{
			get { return template.BodyBrushType;}
			set	
			{ 
				if (template.BodyBrushType != value)
				{
					template.BodyBrushType = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorBodyBackColor")]
		[Description("Frame Body영역의 그리기모드가 Solid Type일때 배경색을 지정합니다.")]
		public XColor BodyBackColor
		{
			get { return template.BodyBackColor;}
			set	
			{ 
				if (template.BodyBackColor != value)
				{
					template.BodyBackColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorBodyGradientStartColor")]
		[Description("Frame의 Body영역의 그리기모드가 Gradient Type일때 Gradient시작색을 지정합니다.")]
		public XColor BodyGradientStartColor
		{
			get	{ return template.BodyGradientStartColor;}
			set	
			{ 
				if (template.BodyGradientStartColor != value)
				{
					template.BodyGradientStartColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorBodyGradientEndColor")]
		[Description("Frame의 Body영역의 그리기모드가 Gradient Type일때 Gradient종료색을 지정합니다.")]
		public XColor BodyGradientEndColor
		{
			get { return template.BodyGradientEndColor;}
			set	
			{ 
				if (template.BodyGradientEndColor != value)
				{
					template.BodyGradientEndColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[DefaultValue(typeof(XColor),"XRotatorBodyTextColor")]
		[Description("Frame Body영역의 Text색을 지정합니다.")]
		public XColor BodyTextColor
		{
			get	{ return template.BodyTextColor;}
			set	
			{ 
				if (template.BodyTextColor != value)
				{
					template.BodyTextColor = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[Category("추가속성")]
		[DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		[Description("Frame Body영역의 Font를 설정합니다.")]
		public Font BodyFont
		{
			get	{ return template.BodyFont;}
			set	
			{ 
				if (template.BodyFont != value)
				{
					template.BodyFont = value;
					this.Invalidate(true);
				}
			}
		}

		[Browsable(true)]
		[Category("추가속성")]
		[DefaultValue(200)]
		[Description("Text를 Animation할때 Delay Time(mileSecond)를 지정합니다.")]
		public int TextAnimationDelay
		{
			get	{ return template.TextAnimationDelay;}
			set	{ template.TextAnimationDelay = value;}
		}

		#endregion

		#region 생성자
		public XRotator()
		{
			this.Font = new Font("MS UI Gothic", 9.75f);
			this.BackColor = XColor.XRotatorBackColor;

			//initialize the objects
			this.items = new XRotatorItemCollection();
			this.template = new RotatorFrameTemplate();
			this.template.HeaderFont = this.Font;
			this.template.BodyFont = this.Font;
            
			//initialize the components of this control
			InitializeComponents();            
		}

		#endregion

		#region InitializeComponents
		private void InitializeComponents()
		{
			this.frameContainer = new RotatorFrameContainer(items, template);
			this.SuspendLayout();
            
			this.frameContainer.TabIndex = 0;
			this.frameContainer.Name = "frameContainer";
			this.Location = new Point(0, 0);
			this.Controls.Add(this.frameContainer);

			this.ResumeLayout(false);
		}
		#endregion

		#region InitializeGraphicPath
		protected override void InitializeGraphicPath()
		{
			cornerSquare = (int)(Height > Width ? Height * constPercentage : Width * constPercentage);
			base.InitializeGraphicPath();
			this.Region = new Region(regionPath);
		}
		#endregion

		#region Override 
		/// <summary>
		/// Override the handler for the resize event;the frame container needs to be repositioned, title area needs to be reset
		/// </summary>
		/// <param name="eventargs"></param>
		protected override void OnResize(EventArgs e)
		{
			InitializeGraphicPath();

			//<IHIS> TitleText가 있으면 titleArea 계산
			if (this.titleText != "")
			{

				int quarterHeight = (this.Height) / 4;
				this.frameContainer.Location = new Point(cornerSquare/2, quarterHeight);
				//<IHIS> 아래 영역을 줄임
				this.frameContainer.Size = new Size(this.Width - 2 * (cornerSquare/2), Height - quarterHeight- (quarterHeight/5));
				this.titleArea = new RectangleF(cornerSquare, 0, Width - 2 * cornerSquare, quarterHeight);
				this.calculateTitleArea = true;
			}
			else
			{
				this.frameContainer.Location = new Point(cornerSquare/2, cornerSquare/2);
				this.frameContainer.Size = new Size(this.Width - 2 * (cornerSquare/2), Height - 2 * (cornerSquare/2));
				this.calculateTitleArea = false;
			}
            
			base.OnResize(e);
			//repaint control to reflect changes
			Refresh();
		}

		/// <summary>
		/// Handler to the paint event
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			if (base.BackColor != this.xBackColor.Color)
				base.BackColor = this.xBackColor.Color;
			base.OnPaint(e);
			//set up some flags
			e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			//check to see if the path has been initialized
			if (graphicPath == null)
				InitializeGraphicPath();

			//<IHIS> Gradient 적용
			if (this.backgroundBrushType == XRotatorBrushType.Solid)
			{
				//paint the background
				using (Brush brush = new SolidBrush(this.BackColor.Color))
					e.Graphics.FillPath(brush, graphicPath);
			}
			else //Gradient
			{
				using (Brush brush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), gradientStartColor.Color, gradientEndColor.Color, LinearGradientMode.Vertical))
					e.Graphics.FillPath(brush, graphicPath);
			}
			//draw the border
			using (Pen pen = new Pen(borderColor.Color))
				e.Graphics.DrawPath(pen , graphicPath);
			
			//<IHIS> TitleText가 있을 경우만 SET
			if (this.titleText != "")
			{
				if (calculateTitleArea)
				{
					StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.MeasureTrailingSpaces);
					SizeF size = e.Graphics.MeasureString(titleText, Font, titleArea.Size, stringFormat);
					float widthAdjustment = (titleArea.Width - size.Width) / 2;
					float heightAdjustment = (titleArea.Height - size.Height) / 2;

					titleArea = new RectangleF(new PointF(titleArea.X, titleArea.Y + heightAdjustment), size);
					calculateTitleArea = false;
				}
				using (Brush titleBrush = new SolidBrush(this.titleTextColor.Color))
					e.Graphics.DrawString(titleText, this.Font, titleBrush, titleArea);
			}
            
		}

		protected override void Dispose(bool disposing)
		{
			if (null != items)
				items.Clear();

			frameContainer.Dispose();
			base.Dispose(disposing);
		}
		#endregion

		#region StopAnimation
		//<IHIS> Animation 종료
		public void StopAnimation()
		{
			this.frameContainer.StopFrameAnimation();
		}
		#endregion
	}
	#endregion

	#region XRotatorDesigner
	internal class XRotatorDesigner : ScrollableControlDesigner
	{
		public XRotatorDesigner()
		{
		}
		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			base.PreFilterProperties(properties);
			//필요없는 Property 제거
			properties.Remove("BackgroundImage");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("RightToLeft");
			properties.Remove("Text");
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("CausesValidation");
			properties.Remove("AutoScroll");
			properties.Remove("AutoScrollMargin");
			properties.Remove("AutoScrollMinSize");
		}
	}
	#endregion
}
