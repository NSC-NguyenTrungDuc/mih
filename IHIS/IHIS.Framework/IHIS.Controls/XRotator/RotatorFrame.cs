using System;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace IHIS.Framework
{
	#region delegator
	/// <summary>
	/// Defines the delegate for the event of finishing animating the header text
	/// </summary>
	internal delegate void RotatorFrameTextAnimationFinished(object sender, EventArgs args);

	/// <summary>
	/// Definition of the event raised whenever a repaint of this control is needed(used for the animation part)
	/// </summary>
	internal delegate void NotifyRepaintEvent();
	#endregion

	#region RotatorFrame
	internal class RotatorFrame : XRotatorBaseControl
	{
		#region Members
		const double constPercentage = 0.02f;
		/// <summary>
		/// flag telling whether the image needs resizing or the text size needs to be recalculated; flagged on the resize event and whenever the Data property is modified
		/// </summary>
		private bool bufferAdjusment = true;
		/// <summary>
		/// Enables text animation
		/// </summary>
		private bool enableTextAnimation = false;

		/// <summary>
		/// the string format object used for measuring the size of the main text.
		/// </summary>
		private StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.MeasureTrailingSpaces);

		/// <summary>
		/// The size of the main text 
		/// </summary>
		private SizeF bufferedTextSize = SizeF.Empty;

		/// <summary>
		/// Cached rectangle where to draw the header text
		/// </summary>
		private RectangleF headerTextRect = RectangleF.Empty;

		/// <summary>
		/// instance of the header graphic path
		/// </summary>
		private GraphicsPath headerPath = null;

		/// <summary>
		/// instance of the main text area graphic path
		/// </summary>
		private GraphicsPath bodyPath = null;

		/// <summary>
		/// instance of the object handling the text animation
		/// </summary>
		private TextAnimation textAnimation = null;

		/// <summary>
		/// reference to the template holding all the values for rendering this control : text color, background color,font an so on
		/// </summary>
		private RotatorFrameTemplate frameTemplate = null;

		/// <summary>
		/// reference to the data this object is linked to
		/// </summary>
		private XRotatorItem data = null;

		/// <summary>
		/// A notifier object that will raise the reapaint event
		/// </summary>
		private EventNotifier repaintNotifier = null;

		/// <summary>
		/// Callback for forcing the repaint (thread safe , the notifier spawns a thread so access to the frame object should be thread safe)
		/// </summary>
		private NotifyRepaintEvent RepaintNotifyHandler = null;
		#endregion

		#region Properties

		/// <summary>
		/// Flags whether or not the text animation should take place
		/// </summary>
		internal bool EnableTextAnimation
		{
			get { return enableTextAnimation;}
			set
			{
				enableTextAnimation = value;
				if (enableTextAnimation)
				{
					repaintNotifier.Pause = false;
					repaintNotifier.Start();
				}
				else 
				{
					repaintNotifier.Stop();
				}
			}
		}
		/// <summary>
		/// Get/Set the template for this frame
		/// </summary>
		internal RotatorFrameTemplate FrameTemplate
		{
			get	{ return frameTemplate; }
			set { frameTemplate = value; }
		}
		/// <summary>
		/// Get/Set the data linked to this object
		/// </summary>
		public XRotatorItem Data
		{
			get { return data; }
			set 
			{ 
				data = value;
				if (data != null)
				{
					bufferAdjusment = true;
					InitializeHeaderPath();

					if (this.textAnimation != null)
					{
						//<IHIS> ItemData Set (Text Measuring Set)
						this.textAnimation.ItemData = data;
						this.textAnimation.Text = data.BodyText;
						this.textAnimation.Reset();
					}
				}
			}
		}
		//<IHIS>
		internal TextAnimation TextAnimation
		{
			get { return this.textAnimation;}
		}
		#endregion

		#region Event
		/// <summary>
		/// The event raised whenever the text animation has finished
		/// </summary>
		internal event RotatorFrameTextAnimationFinished AnimationFinished;
		#endregion
        
		#region 생성자
		public RotatorFrame(RotatorFrameTemplate template)
		{
			this.frameTemplate = template;
			//set the header size change event handler
			this.frameTemplate.HeaderPersantageChanged += new HeaderPersantageChangedEvent(OnHeaderPersantageChanged);
			//set the main text color changed event handler
			this.frameTemplate.BodyTextColorChanged += new BodyTextColorChangedEvent(OnBodyTextColorChanged);
			//set the event handler for the event raised whenever the animation delay has been modified
			this.frameTemplate.TextAnimationDelayChanged += new TextAnimationDelayChangedEvent(OnTextAnimationDelayChanged);
			//set up the graphic
			InitializeGraphicPath();
			//create the notifier
			this.repaintNotifier = new EventNotifier(template.TextAnimationDelay, new NotifierEvent(OnNotifierEvent));
			//set the callback for the repaint
			this.RepaintNotifyHandler = new NotifyRepaintEvent(Repaint);
            
            
		}
		public RotatorFrame(RotatorFrameTemplate template,XRotatorItem data) : this(template)
		{
			this.data = data;
		}
		#endregion

		#region Private

		private void StopEventNotifier()
		{
			repaintNotifier.Stop();
		}

		/// <summary>
		/// initialize the header graphic path
		/// </summary>
		private void InitializeHeaderPath()
		{
			if (null != headerPath)
			{
				headerPath.Dispose();
				headerPath = null;
			}

			int width = (this.Width * (int)frameTemplate.HeaderPersantage) / 100;
			
			headerPath = new GraphicsPath();
            
			if (cornerSquare == 0)
				cornerSquare = 1;

			headerPath.StartFigure();

			//TopLeft, BottomLeft Arc만 그림 (Border 고려 Fixel 조정)
			/*
			headerPath.AddArc(-1, -1, cornerSquare, cornerSquare, 180, 90);
			headerPath.AddLine(cornerSquare - cornerSquare / 2, -1, width, -1);
			headerPath.AddLine(width, -1, width, Height);
			headerPath.AddLine(cornerSquare - cornerSquare / 2, Height, width, Height);
			//BottomLeft Arc
			headerPath.AddArc(-1, Height - cornerSquare, cornerSquare, cornerSquare, 90, 90);
			headerPath.AddLine(-1, cornerSquare - cornerSquare / 2, -1, Height - cornerSquare + cornerSquare / 2);
			headerPath.CloseFigure();
			*/
			headerPath.AddArc(0, 0, cornerSquare, cornerSquare, 180, 90);
			headerPath.AddLine(cornerSquare - cornerSquare / 2, 0, width, 0);
			headerPath.AddLine(width, 0, width, Height);
			headerPath.AddLine(cornerSquare - cornerSquare / 2, Height - 1, width, Height - 1);
			//BottomLeft Arc
			headerPath.AddArc(0, Height - cornerSquare, cornerSquare, cornerSquare, 90, 90);
			headerPath.AddLine(0, cornerSquare - cornerSquare / 2, 0, Height - cornerSquare + cornerSquare / 2);
			headerPath.CloseFigure();
		}

		/// <summary>
		/// initialize the main text area graphic path
		/// </summary>
		private void InitializeBodyPath()
		{
			if (null != bodyPath)
			{
				bodyPath.Dispose();
				bodyPath = null;
			}

			bodyPath = new GraphicsPath();

			int startingPoint = (this.Width * (int)frameTemplate.HeaderPersantage)/ 100;
			//check to see the corner mode, based on this create the graphic path
			bodyPath.StartFigure();
			
			//<IHIS> RightTop, RightBottom Arc 만 그림
			/*
			bodyPath.AddLine(startingPoint , -1, Width - cornerSquare + cornerSquare / 2, -1);
			//RightTop
			bodyPath.AddArc(Width - cornerSquare, -1, cornerSquare, cornerSquare, -90, 90);
			bodyPath.AddLine(Width, cornerSquare - cornerSquare / 2, Width, Height - cornerSquare + cornerSquare / 2);
			//RightBottom
			bodyPath.AddArc(Width - cornerSquare, Height - cornerSquare, cornerSquare, cornerSquare, 0, 90);
			bodyPath.AddLine(Width - cornerSquare + cornerSquare / 2, Height, startingPoint, Height);
			bodyPath.AddLine(startingPoint , Height, startingPoint , -1);
			*/
			bodyPath.AddLine(startingPoint , 0, Width - cornerSquare + cornerSquare / 2, 0);
			//RightTop
			bodyPath.AddArc(Width - cornerSquare, 0, cornerSquare -1, cornerSquare -1, -90, 90);
			bodyPath.AddLine(Width - 1 , cornerSquare - cornerSquare / 2, Width - 1, Height - cornerSquare + cornerSquare / 2);
			//RightBottom
			bodyPath.AddArc(Width - cornerSquare, Height - cornerSquare - 1, cornerSquare -1, cornerSquare -1, 0, 90);
			bodyPath.AddLine(Width - cornerSquare + cornerSquare / 2, Height - 1, startingPoint, Height - 1);
			bodyPath.AddLine(startingPoint , Height, startingPoint , 0);
			bodyPath.CloseFigure();
		}

		/// <summary>
		/// Initializes the text animation in this case a typingtextanimation
		/// </summary>
		private void InitializeTextAnimation()
		{

			textAnimation = new TypingTextAnimation();
			//set the animation area
			RectangleF area = bodyPath.GetBounds();
			//set data needed for the animation
			//<IHIS>
			//textAnimation.Area = new RectangleF(new PointF(area.X + cornerSquare, area.Y), new SizeF(area.Width - cornerSquare, area.Height));
			textAnimation.FrameArea = new RectangleF(new PointF(area.X + cornerSquare, area.Y), new SizeF(area.Width - cornerSquare, area.Height));
			textAnimation.ItemData = data;
			textAnimation.Text = data.BodyText;
			textAnimation.TextColor = frameTemplate.BodyTextColor.Color;
			textAnimation.Font = frameTemplate.BodyFont;
			(textAnimation as TypingTextAnimation).AnimationFinished += new AnimationFinished(OnTextAnimationFinished);
		}
        
		#endregion

		#region Public
		/// <summary>
		/// 
		/// </summary>
		public void ResetAnimation()
		{
			if (null != textAnimation)
				textAnimation.Reset();
		}

		#endregion

		#region Override
		/// <summary>
		/// Set up the graphic path used for drawing the borders
		/// </summary>
		protected override void InitializeGraphicPath()
		{
			cornerSquare = (int)(Height > Width ? Height * constPercentage : Width * constPercentage);

			InitializeHeaderPath();
			base.InitializeGraphicPath();
			this.Region = new Region(regionPath);
		}
		/// <summary>
		/// Handle the resize event. need to recreat the graphics paths and eventually the brushes
		/// </summary>
		/// <param name="eventargs"></param>
		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			//check if the header size has been set to 0; default to 20%of the control
			if (frameTemplate.HeaderPersantage == 0)
				frameTemplate.HeaderPersantage = (int)(this.Width * 0.2);

			InitializeGraphicPath();
			InitializeBodyPath();
            
			if (null != textAnimation)
			{
				///recreate the area for the animation
				RectangleF area = bodyPath.GetBounds();
				//<IHIS>
				textAnimation.FrameArea = new RectangleF(new PointF(area.X + cornerSquare, area.Y), new SizeF(area.Width - cornerSquare, area.Height));
			}
			//text size needs to be recalculated
			bufferAdjusment = true;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			bufferAdjusment = true;
		}
      
		/// <summary>
		/// Override the paint event raised for a WM_PAINT message
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			base.OnPaint(e);
			//set up some flags
			e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

			//check to see if the path has been initialized
			if (graphicPath == null)
				InitializeGraphicPath();

			// Fill Body
			if (frameTemplate.BodyBrushType == XRotatorBrushType.Solid)  //Solid
			{
				using (Brush br = new SolidBrush(frameTemplate.BodyBackColor.Color))
					e.Graphics.FillPath(br, bodyPath);
			}
			else  //Gradient
			{
				using (Brush br = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), frameTemplate.BodyGradientStartColor.Color, frameTemplate.BodyGradientEndColor.Color, LinearGradientMode.Horizontal))
					e.Graphics.FillPath(br, bodyPath);
			}
			//Draw Body Border
			using (Pen bPen = new Pen(frameTemplate.BorderColor.Color))
				e.Graphics.DrawPath(bPen, bodyPath);

			//Fill Header
			if (frameTemplate.HeaderBrushType == XRotatorBrushType.Solid)  //Solid
			{
				using (Brush br = new SolidBrush(frameTemplate.HeaderBackColor.Color))
					e.Graphics.FillPath(br, headerPath);
			}
			else  //Gradient
			{
				using (Brush br = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), frameTemplate.HeaderGradientStartColor.Color, frameTemplate.HeaderGradientEndColor.Color, LinearGradientMode.Horizontal))
					e.Graphics.FillPath(br, headerPath);
			}
				
			//Draw Border
			using (Pen hPen = new Pen(frameTemplate.BorderColor.Color))
				e.Graphics.DrawPath(hPen, headerPath);

			//is there data linked to this object
			if (null != data)
			{
				//값이 없으면 알 림으로 고정
				string drawText = (data.HeaderText == "" ? XMsg.GetField("F016") : data.HeaderText);
				if (drawText != "")  //<IHIS>
				{
					//recalculate the text size if necessary
					if (bufferAdjusment)
					{
						headerTextRect = headerPath.GetBounds();
						headerTextRect = new RectangleF(headerTextRect.X + cornerSquare, 0, headerTextRect.Width - cornerSquare, Height);
						bufferedTextSize = e.Graphics.MeasureString(drawText, frameTemplate.HeaderFont, headerTextRect.Size, stringFormat);
						bufferAdjusment = false;
						//set the header area 
						headerTextRect = new RectangleF(new PointF(headerTextRect.X + (headerTextRect.Width - bufferedTextSize.Width) * 0.5f, headerTextRect.Y + (headerTextRect.Height - bufferedTextSize.Height) * 0.5f), bufferedTextSize);
					}
                
					//render the header text
					using (Brush textBrush = new SolidBrush(frameTemplate.HeaderTextColor.Color))
						e.Graphics.DrawString(drawText, frameTemplate.HeaderFont, textBrush, headerTextRect, stringFormat);
				}
			}
           
			//is animation enabled
			if (enableTextAnimation)
			{
				//initialize animation if necessary
				if (null == textAnimation)
				{
					InitializeTextAnimation();
				}
				//set the graphics object
				textAnimation.Graphics = e.Graphics;
				//render the main text
				textAnimation.DrawText();
				textAnimation.Graphics = null;
				this.repaintNotifier.Pause = false;
			}
			else
			{
				//pause the repaint event notifier
				this.repaintNotifier.Pause = true;
			}
		}

		#endregion

		#region Events Handler
		/// <summary>
		/// Handler for the animation delay changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnTextAnimationDelayChanged(object sender, EventArgs args)
		{
			repaintNotifier.NotifyPeriod = frameTemplate.TextAnimationDelay;
		}

		/// <summary>
		/// The callback method for the repaint notify event(control has to be thread safe)
		/// </summary>
		private void Repaint()
		{
			this.Invalidate(new Region(bodyPath));
			this.Update();
		}

		/// <summary>
		/// Handler for the repaint event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnNotifierEvent(object sender, EventArgs args)
		{

			this.repaintNotifier.Pause = true;

			//invoke the delegate; thread safe access
			this.Invoke(RepaintNotifyHandler);
		}


		/// <summary>
		/// Handler of the text animation finished event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTextAnimationFinished(object sender, EventArgs e)
		{
			//stop the repaint notfier
			StopEventNotifier();
			if (null != AnimationFinished)
			{
				//raise the event further if the case
				AnimationFinished(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Handler for the header size changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnHeaderPersantageChanged(object sender, EventArgs args)
		{
			//need to recreate the graphic paths
			InitializeHeaderPath();
			InitializeBodyPath();
		}

		/// <summary>
		/// Hanlder for the main text color changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnBodyTextColorChanged(object sender, EventArgs args)
		{
			if (null != textAnimation)
			{
				textAnimation.TextColor = this.frameTemplate.BodyTextColor.Color;
			}
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Clear the memory; stop the notifier
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (null != repaintNotifier)
			{
				StopEventNotifier();
			}
			if (null != graphicPath)
			{
				graphicPath.Dispose();
			}
			if (null != bodyPath)
			{
				bodyPath.Dispose();
			}
			if (null != headerPath)
			{
				headerPath.Dispose();
			}

			base.Dispose(disposing);
		}
         
        
		#endregion
	}
	#endregion
}
