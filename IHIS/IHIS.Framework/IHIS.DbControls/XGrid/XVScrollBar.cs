using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XVScrollBar에 대한 요약설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class XVScrollBar : IHIS.Framework.XScrollBar
	{
		#region Events
		/// <summary>
		/// Thumb영역을 up 이동시 발생하는 Event입니다.
		/// </summary>
		public event ThumbHandler ThumbUp = null;
		/// <summary>
		/// Thumb영역을 down 이동시 발생하는 Event입니다.
		/// </summary>
		public event ThumbHandler ThumbDown = null;
		/// <summary>
		/// Arrow영역을 up 이동시 발생하는 Event입니다.
		/// </summary>
		public event EventHandler LineUp = null;
		/// <summary>
		/// Arrow영역을 down 이동시 발생하는 Event입니다.
		/// </summary>
		public event EventHandler LineDown = null;
		/// <summary>
		/// Page영역을 up 이동시 발생하는 Event입니다.
		/// </summary>
		public event EventHandler PageUp = null;
		/// <summary>
		/// Page영역을 down 이동시 발생하는 Event입니다.
		/// </summary>
		public event EventHandler PageDown = null;
		#endregion
		
		#region Class variables
		DrawState upArrowDrawState = DrawState.Normal;
		DrawState downArrowDrawState = DrawState.Normal;
		bool ignoreMouseMove = false;
		bool draggingThumb = false;
		int oldMouseY = 0;
		ScrollBarHit currentTarget = ScrollBarHit.None;
		bool firstTick = false;
		double thumbPixelPos = 0;
		bool processingAutomaticScrolling = false;
		#endregion
				
		#region Constructors
		/// <summary>
		/// XVScrollBar 생성자
		/// </summary>
		public XVScrollBar()
		{
			direction = ScrollBarDirection.Vertical;
		}
		/// <summary>
		/// XVScrollBar 생성자
		/// </summary>
		/// <param name="parent"> ScrollBar를 포함하는 Control </param>
		public XVScrollBar(Control parent) : base(parent)
		{
			direction = ScrollBarDirection.Vertical;
		}
		
		#endregion

		#region Properties
		/// <summary>
		/// UpArrow ImageList를 가져오거나 설정합니다.
		/// </summary>
		public ImageList UpArrowImageList
		{
			set {  upArrowImageList = value; }
			get { return upArrowImageList; }
		}
		/// <summary>
		/// DownArrow ImageList를 가져오거나 설정합니다.
		/// </summary>
		public ImageList DownArrowImageList
		{
			set {  downArrowImageList = value; }
			get { return downArrowImageList; }
		}

		#endregion

		#region Overrides
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// (override) LeftButton Down시 Click한 영역에 따라 Scroll을 이동합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if ( e.Button != MouseButtons.Left )
				return;

			ScrollBarHit hit = HitTest(new Point(e.X, e.Y));
			if ( hit == ScrollBarHit.UpArrow )
			{
				upArrowDrawState = DrawState.Hot;
				Position -= smallChange;
				FireLineUp();
			}
			else if ( hit == ScrollBarHit.DownArrow )
			{
				downArrowDrawState = DrawState.Hot;
				Position += smallChange;
				FireLineDown();
			}
			else if ( hit == ScrollBarHit.PageUp )
			{
				Position -= largeChange;
				FirePageUp();
			}
			else if ( hit == ScrollBarHit.PageDown )
			{
				Position += largeChange;
				FirePageDown();
			}
			else if ( hit == ScrollBarHit.Thumb )
			{
				Capture = true;
				draggingThumb = true;
				thumbDrawState = DrawState.Pressed;
				oldMouseY = e.Y;
				thumbPixelPos = GetThumbPixelPosition(pos);
				Invalidate();
			}

			// Don't create reentry problems
			if ( !processingAutomaticScrolling )
			{
				if ( hit != ScrollBarHit.Thumb && hit != ScrollBarHit.None )
					ProcessScrolling(hit);
			}

		}
		/// <summary>
		/// MouseMove Event를 발생시킵니다.
		/// (override) LeftButton Down후 이동시 영역에 따라 Scroll을 이동합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			
			if ( ignoreMouseMove) 
			{
				ignoreMouseMove = false;
				return;
			}
			
			// Reset every thing to normal state
			upArrowDrawState = DrawState.Normal;
			downArrowDrawState = DrawState.Normal;
			thumbDrawState = DrawState.Normal;

			ScrollBarHit hit = HitTest(new Point(e.X, e.Y));
			if ( hit == ScrollBarHit.UpArrow )
			{
				upArrowDrawState = DrawState.Hot;
			}
			else if ( hit == ScrollBarHit.DownArrow )
			{
				downArrowDrawState = DrawState.Hot;
			}
			else if ( hit == ScrollBarHit.Thumb || draggingThumb )
			{
				if ( draggingThumb )
				{
					thumbDrawState = DrawState.Pressed;
					UpdatePosition(e.Y);
					oldMouseY = e.Y;
					if ( dragFrequency == ThumbDraggedFireFrequency.MouseMove )
					{
						if ( pos > previousPos )
							FireThumbDown((int)pos-(int)previousPos);
						else
							FireThumbUp((int)previousPos-(int)pos);
					}
				}
				else
				{
					thumbDrawState = DrawState.Hot;
				}
			}
			Invalidate();
		}
		/// <summary>
		/// MouseUp Event를 발생시킵니다.
		/// (override) LeftButton Down후 이동후 영역에 따라 Scroll을 이동합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if ( e.Button != MouseButtons.Left )
				return;

			// Reset drawing to normal state
			upArrowDrawState = DrawState.Normal;
			downArrowDrawState = DrawState.Normal;
			thumbDrawState = DrawState.Normal;
			ignoreMouseMove = true;

			if ( draggingThumb )
			{
				Capture = false;
				thumbDrawState = DrawState.Normal;
				UpdatePosition(e.Y);
				draggingThumb = false;
                
				if ( pos > previousPos )
				{
					FireThumbDown((int)pos-(int)previousPos);
				}
				else
					FireThumbUp((int)previousPos-(int)pos);

				// For users who that want to know when the
				// Thumb is released
				FireThumbRelease();

			}
			Invalidate();
		}
		/// <summary>
		/// MouseEnter Event를 발생시킵니다.
		/// (override) 현재 Hit한 영역에 따라 컨트롤의 모양을 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseEnter(EventArgs e)
		{
			// Set state to hot
			base.OnMouseEnter(e);
			Point pos = Control.MousePosition;
			pos = PointToClient(pos);

			ScrollBarHit hit = HitTest(pos);
			if ( hit == ScrollBarHit.UpArrow )
			{
				upArrowDrawState = DrawState.Hot;
			}
			else if ( hit == ScrollBarHit.DownArrow )
			{
				downArrowDrawState = DrawState.Hot;
			}
			else if ( hit == ScrollBarHit.Thumb )
			{
				thumbDrawState = DrawState.Hot;
			}
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
			upArrowDrawState = DrawState.Normal;
			downArrowDrawState = DrawState.Normal;
			thumbDrawState = DrawState.Normal;
			Invalidate();
		}
		/// <summary>
		/// ScrollBar의 Size를 Client영역에 맞추어 조정합니다.
		/// </summary>
		protected override void SizeScrollBar()
		{
			// Resize scrollbar
			// Size scrollbar to have the standard dimensions
			// of an operating system created scrollbar
			Rectangle rcParent = parentWindow.ClientRectangle;
			// If both scrollbar are being used
			if ( usingBothScrollBars )
			{
				Bounds =  new Rectangle(rcParent.Right-VThumb-BorderGap, 
					rcParent.Top+BorderGap, VThumb, rcParent.Bottom - BorderGap*2 - HThumb);
			}
			else
			{
				Bounds =  new Rectangle(rcParent.Right-VThumb-BorderGap, 
					rcParent.Top+BorderGap, VThumb, rcParent.Bottom - BorderGap*2);
			}

		}
		/// <summary>
		/// ScrollBar를 그립니다.
		/// </summary>
		/// <param name="g"> 칠하는 데 사용할 Graphics 개체 </param>
		protected override void DrawScrollBar(Graphics g)
		{
			// Draw background
			DrawBackground(g);

			// Draw Button up arrow
			if ( Enabled )
			{
				// Up and Down buttons
				DrawArrowButtons(g);

				// Draw Thumb
				DrawThumb(g, thumbDrawState);

				// Draw Gripper
				if ( drawGripper )
					DrawThumbGripper(g, thumbDrawState);
			}
		}
		#endregion

		#region Implementation
		/// <summary>
		/// ThumbUp, ValueChanged Event를 발생시킵니다.
		/// </summary>
		/// <param name="delta"> 이동 차이값 </param>
		void FireThumbUp(int delta)
		{
			if ( previousPos != pos )
			{
				if (ThumbUp != null)
					ThumbUp(this, delta);
				OnValueChanged(EventArgs.Empty);
			}
		}
		/// <summary>
		/// ThumbDown, ValueChanged Event를 발생시킵니다.
		/// </summary>
		/// <param name="delta"> 이동 차이값 </param>
		void FireThumbDown(int delta)
		{
			if ( previousPos != pos )
			{
				if (ThumbDown != null)
					ThumbDown(this, delta);
				OnValueChanged(EventArgs.Empty);
			}
		}
		/// <summary>
		/// LineUp Event를 발생시킵니다.
		/// </summary>
		void FireLineUp()
		{
			if ( previousPos != pos )
			{
				if (LineUp != null)
					LineUp(this, EventArgs.Empty);
				//OnValueChanged(EventArgs.Empty);
			}
		}
		/// <summary>
		/// LineDown Event를 발생시킵니다.
		/// </summary>
		void FireLineDown()
		{
			if ( previousPos != pos )
			{
				if (LineDown != null)
					LineDown(this, EventArgs.Empty);
				//OnValueChanged(EventArgs.Empty);
			}
		}
		/// <summary>
		/// PageUp Event를 발생시킵니다.
		/// </summary>
		void FirePageUp()
		{
			if ( previousPos != pos )
			{
				if (PageUp != null)
					PageUp(this, EventArgs.Empty);
				//OnValueChanged(EventArgs.Empty);
			}
		}
		/// <summary>
		/// PageDown Event를 발생시킵니다.
		/// </summary>
		void FirePageDown()
		{
			if ( previousPos != pos )
			{
				if (PageDown != null)
					PageDown(this, EventArgs.Empty);
				//OnValueChanged(EventArgs.Empty);
			}
		}
		/// <summary>
		/// Hit 영역에 따라 Scrolling합니다.
		/// </summary>
		/// <param name="hit"> ScrollBar에서 Hit한 영역 </param>
		void ProcessScrolling(ScrollBarHit hit)
		{
			// Capture the mouse
			stopAutomaticScrolling = false;
			Capture = true;
			firstTick = true;
					
			// Start timer
			System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
			timer.Tick += new EventHandler(ScrollingTick);
			timer.Interval = TIMER_INTERVAL;
			timer.Start();
			currentTarget = hit;
                         
			while ( stopAutomaticScrolling == false ) 
			{
				// Check messages until we find a condition to break out of the loop
				Win32.MSG msg = new Win32.MSG();
				User32.GetMessage(ref msg, 0, 0, 0);
				Point point = new Point(0,0);
				if ( msg.message == (int)Win32.Msgs.WM_MOUSEMOVE 
					|| msg.message == (int)Win32.Msgs.WM_LBUTTONUP || msg.message == (int)Win32.Msgs.WM_LBUTTONDBLCLK )
				{
					point = User32.GetPointFromLPARAM((int)msg.lParam);
				}

				Win32.Msgs thisMessage = (Win32.Msgs)msg.message;
				switch ((Win32.Msgs)msg.message)
				{
					case Win32.Msgs.WM_MOUSEMOVE:
					{
						ScrollBarHit current = HitTest(point);
						ProcessMouseMoveScrolling(current);
						Invalidate();
						break;
					}
					case Win32.Msgs.WM_LBUTTONUP:
					case Win32.Msgs.WM_LBUTTONDBLCLK:
					{
						stopAutomaticScrolling = true;
						User32.DispatchMessage(ref msg);
						break;
					}
					case Win32.Msgs.WM_KEYDOWN:
					{
						if ( (int)msg.wParam == (int)Win32.VirtualKeys.VK_ESCAPE) 
							stopAutomaticScrolling = true;
						break;
					}
					default:
						User32.DispatchMessage(ref msg);
						break;
				}
			}

			// Stop timer
			timer.Stop();
			timer.Dispose();
			Invalidate();
			// Release the capture
			Capture = false;
			if ( processingAutomaticScrolling )
			{
				processingAutomaticScrolling = false;
				FireStoppingAutomaticScrolling();
			}
		}
		/// <summary>
		/// Hit 영역에 따라 MouseMove시 Scrolling합니다.
		/// </summary>
		/// <param name="hit"> ScrollBar에서 Hit한 영역 </param>
		void ProcessMouseMoveScrolling(ScrollBarHit hit)
		{
			upArrowDrawState = DrawState.Normal;
			downArrowDrawState = DrawState.Normal;
			if ( hit == ScrollBarHit.UpArrow )
				upArrowDrawState = DrawState.Hot;
			else if ( hit == ScrollBarHit.DownArrow )
				downArrowDrawState = DrawState.Hot;
            
		}

		void ScrollingTick(Object timeObject, EventArgs eventArgs) 
		{
			
			processingAutomaticScrolling = true;
			FireStartingAutomaticScrolling();
			
			// Ignore the first tick since sometimes the user
			// is just clicking and the first tick happens
			// so fast that produces the effect of scrolling twice
			if ( firstTick )
			{
				firstTick = false;
				return;
			}
								
			// Get mouse coordinates
			Point point = Control.MousePosition;
			point = PointToClient(point);
			Rectangle rc = Rectangle.Empty;
			
			if ( currentTarget == ScrollBarHit.UpArrow )
			{
				rc = GetArrowButtonRectangle(true);
				if ( rc.Contains(point) )
				{
					Position -= smallChange;
					FireLineUp();
				}
			}
			else if ( currentTarget == ScrollBarHit.DownArrow )
			{
				rc = GetArrowButtonRectangle(false);
				if ( rc.Contains(point) )
				{
					Position += smallChange;
					FireLineDown();
				}
			}
			else if ( currentTarget == ScrollBarHit.PageUp )
			{
				rc = GetPageRect(true);
				if ( rc.Contains(point) )
				{
					Position -= largeChange;
					FirePageUp();
				}
			}
			else if ( currentTarget == ScrollBarHit.PageDown )
			{
				rc = GetPageRect(false);
				if ( rc.Contains(point) )
				{
					Position += largeChange;
					FirePageDown();
				}
			}
		}

		void SetPosition(double fpos)
		{
			if ( pos != fpos )
			{
				previousPos = pos;
				double newValue = fpos;

				if ( newValue >= max-largeChange ) 
				{
					// Position cannot be larger than
					// max-largeChange
					pos = max-largeChange;
				}
				else if ( newValue < 0 )
				{
					// Negative values don't make sense
					pos = 0;
				}
				else
					pos = newValue;
				
				if ( previousPos != pos )
					Invalidate();
			}
			else
				previousPos = pos;
		}

		void UpdatePosition(int yPos)
		{
			int increment = 0;
			if ( yPos >= oldMouseY )
				increment = yPos - oldMouseY;
			else
				increment = (oldMouseY - yPos)*(-1);
		
			thumbPixelPos += increment; 
			double fPos = GetThumbLogicalPosition(thumbPixelPos);
			SetPosition(fPos);
		}
		/// <summary>
		/// ScrollBar에서 ArrowButton을 그립니다.
		/// </summary>
		/// <param name="g"> 칠하는 데 사용할 Graphics 개체 </param>
		protected virtual void DrawArrowButtons(Graphics g)
		{
			Rectangle upRect = GetArrowButtonRectangle(true); 
			Rectangle downRect = GetArrowButtonRectangle(false);
			DrawFlatArrowButton(g, upRect, ArrowGlyph.Up, upArrowDrawState);
			DrawFlatArrowButton(g, downRect, ArrowGlyph.Down, downArrowDrawState);
		}
		/// <summary>
		/// ScrollBar에서 Thumb영역을 상태에 따라 그립니다.
		/// </summary>
		/// <param name="g"> 칠하는 데 사용할 Graphics 개체 </param>
		/// <param name="drawState"> 그리기 상태 </param>
		protected virtual void DrawThumbGripper(Graphics g, DrawState drawState)
		{
			Rectangle rc = GetThumbRect();

			// Don't draw it if it won't fit
			if ( rc.Height < MINIMUM_THUMB_WITH_GRIPPER_SIZE )
				return;

			int yMiddle = rc.Top + rc.Height/2;
			int xPos = rc.Left + (rc.Width - GRIPPER_WIDTH)/2;
            
			Color lightColor = ColorHelper.VSNetSelectionColor;
			Color darkColor = ColorHelper.VSNetPressedColor;

			// Check if the user set custom colors for the gripper
			if ( gripperLightColor != Color.Empty )
				lightColor = gripperLightColor;
			if ( gripperDarkColor != Color.Empty )
				darkColor = gripperDarkColor;
			
			Pen lightPen = new Pen(lightColor);
			Pen darkPen = new Pen(darkColor);

			Point pt1 = new Point(xPos, yMiddle-GRIPPER_HEIGHT/2);
			Point pt2 = new Point(xPos + GRIPPER_WIDTH, yMiddle-GRIPPER_HEIGHT/2);
			g.DrawLine(lightPen, pt1, pt2);

			pt1 = new Point(xPos+1, yMiddle-GRIPPER_HEIGHT/2+1);
			pt2 = new Point(xPos + GRIPPER_WIDTH + 1, yMiddle-GRIPPER_HEIGHT/2+1);
			g.DrawLine(darkPen, pt1, pt2);

			pt1 = new Point(xPos, yMiddle-GRIPPER_HEIGHT/2+2);
			pt2 = new Point(xPos + GRIPPER_WIDTH, yMiddle-GRIPPER_HEIGHT/2+2);
			g.DrawLine(lightPen, pt1, pt2);

			pt1 = new Point(xPos+1, yMiddle-GRIPPER_HEIGHT/2+3);
			pt2 = new Point(xPos + GRIPPER_WIDTH + 1, yMiddle-GRIPPER_HEIGHT/2+3);
			g.DrawLine(darkPen, pt1, pt2);

			pt1 = new Point(xPos, yMiddle-GRIPPER_HEIGHT/2+4);
			pt2 = new Point(xPos + GRIPPER_WIDTH, yMiddle-GRIPPER_HEIGHT/2+4);
			g.DrawLine(lightPen, pt1, pt2);

			pt1 = new Point(xPos+1, yMiddle-GRIPPER_HEIGHT/2+5);
			pt2 = new Point(xPos + GRIPPER_WIDTH+1, yMiddle-GRIPPER_HEIGHT/2+5);
			g.DrawLine(darkPen, pt1, pt2);

			pt1 = new Point(xPos, yMiddle-GRIPPER_HEIGHT/2+6);
			pt2 = new Point(xPos + GRIPPER_WIDTH, yMiddle-GRIPPER_HEIGHT/2+6);
			g.DrawLine(lightPen, pt1, pt2);

			pt1 = new Point(xPos+1, yMiddle-GRIPPER_HEIGHT/2+7);
			pt2 = new Point(xPos + GRIPPER_WIDTH + 1, yMiddle-GRIPPER_HEIGHT/2+7);
			g.DrawLine(darkPen, pt1, pt2);

			// Cleanup 
			lightPen.Dispose();
			darkPen.Dispose();
			
		}

		Rectangle GetArrowButtonRectangle( bool upButton)
		{
			Rectangle rc = ClientRectangle;
			if ( upButton )
			{
				return new Rectangle(0, rc.Top,
					VThumb, VThumb);
			}
			else
			{
				return new Rectangle(0, rc.Bottom-VThumb,
					VThumb, VThumb);
			}
		}
		/// <summary>
		/// Thumb영역을 가져옵니다.
		/// </summary>
		/// <returns> Thumb영역을 나타내는 Rectangle </returns>
		protected override Rectangle GetThumbRect()
		{
			double thumbHeight = GetThumbPixelSize();
			int drawPos = 0;

			if ( draggingThumb  ) 
			{
				// If dragging the thumb don't use
				// a position based on the scaled calculation
				// but the actual one from the OnMouseMove event
				// to avoid jerkiness from rounding off errors
				drawPos = GetSafeThumbPixelPos((int)thumbHeight);
			}
			else
			{
				drawPos = (int)GetThumbPixelPosition(pos);
			}

			// To avoid rounding off errors
			if ( pos == max-largeChange )
			{
				drawPos = ClientRectangle.Height - VThumb - (int)thumbHeight;
			}
			Rectangle rc = Rectangle.Empty;
			
			// Smaller than the total width of the scrollbar
			// to make it look nicer
			rc = new Rectangle(0, drawPos, VThumb, (int)thumbHeight);
			rc.Inflate(-1, 0);
			return rc;
		}

		int GetSafeThumbPixelPos(int thumbHeight)
		{
			if ( thumbPixelPos > (ClientRectangle.Height - VThumb)-thumbHeight) 
			{
				// Position cannot be larger than
				// max-largeChange
				return (ClientRectangle.Height - VThumb)-thumbHeight;
			}
			else if ( thumbPixelPos <= VThumb )
			{
				// Negative values don't make sense
				return VThumb;
			}
			else
				return (int)thumbPixelPos;
		}

		Rectangle GetPageRect(bool up)
		{
			Rectangle rcClient = ClientRectangle;
			Rectangle rcThumb = GetThumbRect();
			Rectangle pageRect;
			if ( up )
			{
				pageRect = new Rectangle(rcClient.Left, 
					rcClient.Top+VThumb+1, rcClient.Width, rcThumb.Top-VThumb-2);
			}
			else
			{
				pageRect = new Rectangle(rcClient.Left, 
					rcThumb.Bottom+1, rcClient.Width, rcClient.Bottom-VThumb-1);
			}
			return pageRect;
		}

		double GetThumbPixelSize()
		{
			int height = ClientRectangle.Height - VThumb*2;
			if ( largeChange == 0 || (max-min) == 0)
				return 0;
			float numOfPages = (float)(max-min)/(float)largeChange;
			return Math.Max(height/numOfPages, 6);
		}

		double GetThumbPixelPosition(double logicalPos)
		{
			double fHeight = ClientRectangle.Height - VThumb*2;
			double fRange = (max-min);
			double fLogicalPos = logicalPos;
			return (fLogicalPos*fHeight)/fRange + VThumb;
		}

		double GetThumbLogicalPosition(double pixelPos)
		{
			double fHeight = ClientRectangle.Height - VThumb*2;
			double fRange = (max-min);
			double fpixelPos = pixelPos;
			return (fRange*(fpixelPos-VThumb)/fHeight);
		}

		ScrollBarHit HitTest(Point point)
		{
			Rectangle upArrow = GetArrowButtonRectangle(true);
			if ( upArrow.Contains(point) )
				return ScrollBarHit.UpArrow;
			
			Rectangle downArrow = GetArrowButtonRectangle(false);
			if ( downArrow.Contains(point) )
				return ScrollBarHit.DownArrow;

			Rectangle upPageRect = GetPageRect(true);
			if ( upPageRect.Contains(point) )
				return ScrollBarHit.PageUp;

			Rectangle downPageRect = GetPageRect(false);
			if ( downPageRect.Contains(point) )
				return ScrollBarHit.PageDown;

			Rectangle thumbRect = GetThumbRect();
			if ( thumbRect.Contains(point) )
				return ScrollBarHit.Thumb;
            
			return ScrollBarHit.None;
		}
		#endregion
	}
}