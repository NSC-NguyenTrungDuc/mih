using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IHIS.Framework
{

	#region Enumerations
	/// <summary>
	/// ScrollBar의 Scroll시 Event 발생시기를 나타내는 Enum입니다.
	/// </summary>
	public enum ThumbDraggedFireFrequency
	{
		/// <summary>
		/// MouseMove시 Event를 발생시킴.
		/// </summary>
		MouseMove,
		/// <summary>
		/// MouseUp시 Event를 발생시킴.
		/// </summary>
		MouseUp
	}
	/// <summary>
	/// ScrollBar의 그리기 패턴을 나타내는 Enum입니다.
	/// </summary>
	public enum ScrollBarDrawType
	{
		/// <summary>
		/// Flat하게 그리기
		/// </summary>
		Flat,
		/// <summary>
		/// Gradient로 그리기
		/// </summary>
		Gradient,
		/// <summary>
		/// Skin형태로 그리기
		/// </summary>
		Skin
	}
	#endregion

	#region Delegates
	/// <summary>
	/// Scroll영역 변경시 발생하는 Event를 처리할 메서드 입니다.
	/// </summary>
	public delegate void ThumbHandler(object sender, int delta);
	#endregion

	/// <summary>
	/// XScrollBar에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class XScrollBar : System.Windows.Forms.Control
	{
		#region Events
		/// <summary>
		/// Scroll이 시작될때 발생하는 Event입니다.
		/// </summary>
		public event EventHandler StartingAutomaticScrolling = null;
		/// <summary>
		/// Scroll이 종료될때 발생하는 Event입니다.
		/// </summary>
		public event EventHandler StoppingAutomaticScrolling = null;
		/// <summary>
		/// Thumb영역이 사라질때 발생하는 Event입니다.
		/// </summary>
		public event EventHandler ThumbReleased = null;
		/// <summary>
		/// ScrollBar의 값이 변경되면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler ValueChanged = null;
		#endregion

		#region Class Enumerations
		/// <summary>
		/// ScrollBar의 모양을 나타내는 Enum입니다.
		/// </summary>
		public enum ScrollBarDirection
		{
			/// <summary>
			/// None
			/// </summary>
			None,
			/// <summary>
			/// Vertival ScrollBar
			/// </summary>
			Vertical,
			/// <summary>
			/// Horizontal ScrollBar
			/// </summary>
			Horizontal
		}
		#endregion

		#region Class Variables
		// Constants
		/// <summary>
		/// Gripper의 너비
		/// </summary>
		protected const int GRIPPER_WIDTH = 8;
		/// <summary>
		/// Gripper의 높이
		/// </summary>
		protected const int GRIPPER_HEIGHT = 8;
		/// <summary>
		/// Gripper를 가진 Thumb의 최초 너비값
		/// </summary>
		protected const int MINIMUM_THUMB_WITH_GRIPPER_SIZE = 12;
		/// <summary>
		/// Time Interval
		/// </summary>
		protected const int TIMER_INTERVAL = 200;
        		
		// Parent control for the scrollbar
		/// <summary>
		/// ScrollBar를 포함하는 Conrol
		/// </summary>
		protected Control parentWindow;

		// property backing variables
		int hThumb = -1;
		int vThumb = -1;
		int borderGap = 0;
		/// <summary>
		/// ScrollBar의 최소값
		/// </summary>
		protected int min = 0;
		/// <summary>
		/// ScrollBar의 최대값
		/// </summary>
		protected int max = 100;
		/// <summary>
		/// ScrollBar의 위치
		/// </summary>
		protected double pos = 0;
		/// <summary>
		/// ScrollBar의 이전 위치
		/// </summary>
		protected double previousPos = 0;
		/// <summary>
		/// ScrollBar의 SmallChange 값
		/// </summary>
		protected int smallChange = 10;
		/// <summary>
		/// ScrollBar의 LargeChange 값
		/// </summary>
		protected int largeChange = 20;
		/// <summary>
		/// ThumbDraggedFireFrequency
		/// </summary>
		protected ThumbDraggedFireFrequency dragFrequency = ThumbDraggedFireFrequency.MouseMove;
		/// <summary>
		/// ScrollBar의 모양
		/// </summary>
		protected ScrollBarDirection direction = ScrollBarDirection.None;

		/// <summary>
		/// ScrollBar의 그리기 Pattern
		/// </summary>
		protected ScrollBarDrawType backDrawType = ScrollBarDrawType.Gradient;
		/// <summary>
		/// ScrollBar의 배경색
		/// </summary>
		protected Color backgroundColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 전경색
		/// </summary>
		protected Color foregroundColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 테두리색
		/// </summary>
		protected Color borderColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 Arrow색
		/// </summary>
		protected Color arrowColor = Color.Empty;
		/// <summary>
		/// ScrollBar Gripper의 밝은색
		/// </summary>
		protected Color gripperLightColor = Color.Empty;
		/// <summary>
		/// ScrollBar Gripper의 어두운색
		/// </summary>
		protected Color gripperDarkColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 Hover 색
		/// </summary>
		protected Color hoverColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 Pressed 색
		/// </summary>
		protected Color pressedColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 Grient시작색
		/// </summary>
		protected Color gradientStartBackgroundColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 Grient종료색
		/// </summary>
		protected Color gradientEndBackgroundColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 전경 Gradient시작색
		/// </summary>
		protected Color gradientStartForegroundColor = Color.Empty;
		/// <summary>
		/// ScrollBar의 전경 Gradient종료색
		/// </summary>
		protected Color gradientEndForegroundColor = Color.Empty;

		// Skin support
		/// <summary>
		/// Thumb영역 ImageList
		/// </summary>
		protected ImageList thumbImageList = null;
		/// <summary>
		/// scrollShaft ImageList
		/// </summary>
		protected Image scrollShaftImage = null;
		/// <summary>
		/// UpArrow ImageList
		/// </summary>
		protected ImageList upArrowImageList = null;
		/// <summary>
		/// DownArrow ImageList
		/// </summary>
		protected ImageList downArrowImageList = null;
                				
		// Keep track of the UI element state
		/// <summary>
		/// Thumb영역 그리기모드
		/// </summary>
		protected DrawState thumbDrawState = DrawState.Normal;

		/// <summary>
		/// Scrolling 종료여부
		/// </summary>
		// Other helper variables
		protected bool stopAutomaticScrolling = false;
		
		// Keeps track of the ScrollBar objects constructed
		// so that we can transparently--to the user--check if
		// an horizontal and vertical bars are both being used
		// on the same parent window to be able to leave the 
		// lower right corner empty space that avoids the two
		// scrollbars overlapping on the arrow button
		static ArrayList scrollBarList = new ArrayList();
		/// <summary>
		/// Vertical, Horizontal 둘다 사용여부
		/// </summary>
		protected bool usingBothScrollBars = false;

		// Miscellaneous
		/// <summary>
		/// Gripper 그리기 여부
		/// </summary>
		protected bool drawGripper = true;
                
		#endregion
		
		#region Constructors
		/// <summary>
		/// XScrollBar 생성자
		/// </summary>
		public XScrollBar()
		{
		}
		/// <summary>
		/// XScrollBar 생성자
		/// </summary>
		/// <param name="parentControl"> ScrollBar를 포함하는 Control </param>
		public XScrollBar(Control parentControl)
		{
			// We are going to do all of the painting so better 
			// setup the control to use double buffering
			SetStyle(ControlStyles.AllPaintingInWmPaint|ControlStyles.ResizeRedraw|
				ControlStyles.Opaque|ControlStyles.UserPaint|ControlStyles.DoubleBuffer, true);
			TabStop = false;

			hThumb = User32.GetSystemMetrics(Win32.SystemMetricsCodes.SM_CXHTHUMB);
			vThumb = User32.GetSystemMetrics(Win32.SystemMetricsCodes.SM_CYVTHUMB);
		
			parentWindow = parentControl;
			parentWindow.SizeChanged += new EventHandler(ParentSizeChanged);

			// Need to check setting of flag
			CheckForUsingBothScrollBarsFlag(this);
			scrollBarList.Add(this);
		}
		#endregion

		#region Overrides
		/// <summary>
		/// 컨트롤에서 사용하는 관리되지 않는 리소스를 해제합니다.
		/// </summary>
		/// <param name="disposing"> 해제여부 </param>
		protected override void Dispose(bool disposing)
		{
			/* <MEMORY LEAK> 2007.10.17 생성자에서 parentWindow의 SizeChanged Event를 Handling하여
			 * ScrollBar의 Bound를 설정하는데(SizeScrollBar), Dispose시에 이 Event가 해제가 되지 않아서,
			 * XScrollBar를 Dispose해도 Memory 해제가 되지 않는 현상이 발생함. 이 현상을 방지하기 위해
			 * Dispose에서 Event Handler를 Clear해주어야 한다.
			*/
			if (parentWindow != null)
				parentWindow.SizeChanged -= new EventHandler(ParentSizeChanged);
			scrollBarList.Remove(this);
			base.Dispose (disposing);
		}
		/// <summary>
		/// HandleCreated 이벤트를 발생시킵니다.
		/// (override) ScrollBar의 Size를 조정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
		
			// Set the parent for the scrollBar
			User32.SetParent(Handle, parentWindow.Handle);
			SizeScrollBar();
		}
		/// <summary>
		/// Paint 이벤트를 발생시킵니다.
		/// (override) ScrollBar를 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 PaintEventArgs </param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics g = e.Graphics;
			DrawScrollBar(g);
		}
		/// <summary>
		/// Window Message를 처리합니다.
		/// </summary>
		/// <param name="message"> (ref) 처리할 Windows Message </param>
		protected override  void WndProc(ref Message message)
		{
			base.WndProc(ref message);

			switch ((Win32.Msgs)message.Msg)
			{	
				case Win32.Msgs.WM_LBUTTONUP:
					stopAutomaticScrolling = true;
					break;
				default:
					break;
			}
		}
		#endregion

		#region Virtuals
		// Need to be implemented by a derived class
		// This shoud have been abstract methods but 
		// because of the comments at the class declaration
		// above, this could not be
		/// <summary>
		/// ScrollBar의 Size를 조정합니다.
		/// </summary>
		protected virtual void SizeScrollBar()
		{
		}
		/// <summary>
		/// ScrollBar를 그립니다.
		/// </summary>
		/// <param name="g"> Paint시 사용할 Graphics 개체 </param>
		protected virtual void DrawScrollBar(Graphics g)
		{
		}
		/// <summary>
		/// Thumb영역을 가져옵니다.
		/// </summary>
		/// <returns> Thumb영역 Rectangle </returns>
		protected virtual Rectangle GetThumbRect()
		{
			return Rectangle.Empty;
		}
		/// <summary>
		/// ScrollBar의 배경을 그립니다.
		/// </summary>
		/// <param name="g"> Paint시 사용할 Graphics 개체 </param>
		protected virtual void DrawBackground(Graphics g)
		{
			Rectangle rc = ClientRectangle;

			if ((backDrawType == ScrollBarDrawType.Skin) && (scrollShaftImage != null))
			{
				// Draw background bitmap
				g.DrawImage(scrollShaftImage, rc);
			}
			else if (backDrawType == ScrollBarDrawType.Flat)
			{
				Color backColor = (( backgroundColor != Color.Empty ) ? backgroundColor : SystemColors.ControlLight);
				using ( Brush b = new SolidBrush(backColor) )
				{
					// Fill background;
					g.FillRectangle(b, rc);
				}
			}
			else
			{
				LinearGradientMode mode = LinearGradientMode.Horizontal;
				if (direction == ScrollBarDirection.Horizontal)
					mode = LinearGradientMode.Vertical;
				Color startColor = (( gradientStartBackgroundColor != Color.Empty ) ? gradientStartBackgroundColor : Color.LightGray);
				Color endColor = (( gradientEndBackgroundColor != Color.Empty ) ? gradientEndBackgroundColor : Color.WhiteSmoke);
				using ( LinearGradientBrush b = new LinearGradientBrush( rc, startColor, endColor, mode) )
				{
					g.FillRectangle(b, rc);
				}
			}
		}
		/// <summary>
		/// ScrollBar의 ArrowButton영역을 그립니다.
		/// </summary>
		/// <param name="g"> Paint시 사용할 Graphics 개체 </param>
		/// <param name="rc"> 그리기 영역 </param>
		/// <param name="arrowGlyph"> Arrow의 종류 </param>
		/// <param name="drawState"> 그리기 상태 </param>
		protected virtual void DrawFlatArrowButton(Graphics g, Rectangle rc, ArrowGlyph arrowGlyph, DrawState drawState)
		{
			// Make rectangle 1 pixel smaller
			// makes it look nicer
			rc.Inflate(-1, -1);

			Color border = Color.Empty;
			Color background = Color.Empty;

			if ( drawState == DrawState.Normal )
			{
				border = ColorHelper.VSNetBorderColor;
				background = ColorHelper.VSNetControlColor;
				if ( backgroundColor != Color.Empty )
					background = foregroundColor;
			}
			else if ( drawState == DrawState.Hot )
			{
				border = ColorHelper.VSNetBorderColor;
				background = ColorHelper.VSNetSelectionColor;
				if ( hoverColor != Color.Empty )
					background = hoverColor;
			}
			else if ( drawState == DrawState.Pressed )
			{
				border = ColorHelper.VSNetBorderColor;
				background = ColorHelper.VSNetPressedColor;
				if ( pressedColor != Color.Empty )
					background = pressedColor;
			}

			// Which arrow glyph we need to draw
			bool upArrow = (arrowGlyph == ArrowGlyph.Up || arrowGlyph == ArrowGlyph.Left);
			bool paintBorder = true;

			if ( (upArrow && upArrowImageList != null && upArrowImageList.Images.Count > (int)drawState)
				|| (!upArrow && downArrowImageList != null && downArrowImageList.Images.Count > (int)drawState) )
			{
				if ( upArrow )
					g.DrawImage(upArrowImageList.Images[(int)drawState], rc);
				else
					g.DrawImage(downArrowImageList.Images[(int)drawState], rc);
				paintBorder = false;
			}
			else if ( gradientStartForegroundColor != Color.Empty && gradientEndForegroundColor != Color.Empty 
				&& drawState == DrawState.Normal )
			{
				using ( LinearGradientBrush b = new LinearGradientBrush( rc, gradientStartForegroundColor, 
							gradientEndForegroundColor, LinearGradientMode.Horizontal) )
				{
					g.FillRectangle(b, rc);
				}
			}
			else
			{
				using ( Brush b = new SolidBrush(background) )
				{
					// Fill background;
					g.FillRectangle(b, rc);
				}
			}
			
			// Check if the user set custom colors
			if ( borderColor != Color.Empty )
				border = borderColor;
			using ( Pen p = new Pen(border) )
			{
				if ( paintBorder )
					g.DrawRectangle(p, rc.Left, rc.Top, rc.Width-1, rc.Height-1);
				Color arrow = Color.Black;
				if ( arrowColor != Color.Empty )
					arrow = arrowColor;
				using ( Brush b = new SolidBrush(arrow) ) 
				{
					DrawHelper.DrawArrowGlyph(g, rc, 7, 4, arrowGlyph, b);
				}
			}
		}
		/// <summary>
		/// ScrollBar의 Thumb영역을 그립니다.
		/// </summary>
		/// <param name="g"> Paint시 사용할 Graphics 개체 </param>
		/// <param name="drawState"> 그리기 상태 </param>
		protected virtual void DrawThumb(Graphics g, DrawState drawState)
		{
			Rectangle rc = GetThumbRect();
			Color border = Color.Empty;
			Color background = Color.Empty;

			if ( drawState == DrawState.Normal )
			{
				border = ColorHelper.VSNetBorderColor;
				background = ColorHelper.VSNetControlColor;
				if ( backgroundColor != Color.Empty )
					background = foregroundColor;
			}
			else if ( drawState == DrawState.Hot )
			{
				border = ColorHelper.VSNetBorderColor;
				background = ColorHelper.VSNetSelectionColor;
				if ( hoverColor != Color.Empty )
					background = hoverColor;
			}
			else if ( drawState == DrawState.Pressed )
			{
				border = ColorHelper.VSNetBorderColor;
				background = ColorHelper.VSNetPressedColor;
				if ( pressedColor != Color.Empty )
					background = pressedColor;
			}

			// Paint border by default
			bool paintBorder = true;
            
			if ( thumbImageList != null && thumbImageList.Images.Count > (int)drawState )
			{
				// We need to draw the thumb in chunks to avoid distorting the thumb image
				// We are assuming that the corners of the image require at most 10 pixel
				// on both size, the rest will be the area we strech
				if (direction != ScrollBarDirection.Vertical)
				{
					// Draw start corner
					Image image = thumbImageList.Images[(int)drawState];
					g.DrawImage(image, new Rectangle(rc.Left, rc.Top, 10, rc.Height), 0, 0, 10, rc.Height, GraphicsUnit.Pixel);
					// Draw middle part
					g.DrawImage(image, new Rectangle(rc.Left+10, rc.Top, rc.Width-20, rc.Height), 10, 0, image.Width-20, rc.Height, GraphicsUnit.Pixel);
					// Draw end corner
					g.DrawImage(image, new Rectangle(rc.Right-10, rc.Top, 10, rc.Height), image.Width-10, 0, 10, rc.Height, GraphicsUnit.Pixel);
				}
				else
				{
					// Draw start corner
					Image image = thumbImageList.Images[(int)drawState];
					g.DrawImage(image, new Rectangle(rc.Left, rc.Top, rc.Width, 10), 0, 0, rc.Width, 10, GraphicsUnit.Pixel);
					// Draw middle part
					g.DrawImage(image, new Rectangle(rc.Left, rc.Top+10, rc.Width, rc.Height-20), 0, 10, rc.Width, image.Height - 20, GraphicsUnit.Pixel);
					// Draw end corner
					g.DrawImage(image, new Rectangle(rc.Left, rc.Bottom-10, rc.Width, 10), 0, image.Height-10, rc.Width, 10, GraphicsUnit.Pixel);

				}
				paintBorder = false;
			}
			else if ( gradientStartForegroundColor != Color.Empty && gradientEndForegroundColor != Color.Empty )
			{
				Color startColor = gradientStartForegroundColor;
				if ( drawState == DrawState.Hot || drawState == DrawState.Pressed )
					startColor = background;
				
				LinearGradientMode mode = LinearGradientMode.Horizontal;
				if (direction == ScrollBarDirection.Horizontal)
					mode = LinearGradientMode.Vertical;
				
				using ( LinearGradientBrush b = new LinearGradientBrush( rc, startColor, 
							gradientEndForegroundColor, mode) )
				{
					g.FillRectangle(b, rc);
				}
			}
			else
			{
				using ( Brush b = new SolidBrush(background) )
				{
					// Fill background;
					g.FillRectangle(b, rc);
				}
			}
			
			if ( paintBorder )
			{
				// If border color was set by the user
				if ( borderColor != Color.Empty )
					border = borderColor;
				using ( Pen p = new Pen(border) )
				{
					g.DrawRectangle(p, rc.Left, rc.Top, rc.Width-1, rc.Height-1);
				}
			}
		}
		/// <summary>
		/// ValueChanged Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
				ValueChanged(this, e);
		}
		#endregion

		#region Properties
		/// <summary>
		/// ScrollBar의 현재위치값을 가져오거나 설정합니다.
		/// </summary>
		public int Position
		{
			set
			{
				if ( pos != value )
				{
					previousPos = pos;
					int newValue = value;

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
					{
						Invalidate();
						OnValueChanged(EventArgs.Empty);
					}
				}
				else
					previousPos = pos;
			}
			get 
			{
				return (int)pos;
			}
		}
		/// <summary>
		/// ScrollBar의 현재위치값을 가져오거나 설정합니다.
		/// </summary>
		public int Value
		{
			get { return Position; }
			set { Position = value; }
		}
		/// <summary>
		/// ScrollBar의 그리기 패턴을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(ScrollBarDrawType.Gradient)]
		public ScrollBarDrawType BackDrawType
		{
			get { return backDrawType; }
			set { backDrawType = value; }
		}
		/// <summary>
		/// Vertical ScrollBar의 Thumb의 Y위치를 가져옵니다.
		/// </summary>
		public int VThumb
		{
			get { return vThumb;}
		}
		/// <summary>
		/// Horizontal ScrollBar의 Thumb의 X위치를 가져옵니다.
		/// </summary>
		public int HThumb
		{
			get { return hThumb;}
		}
		/// <summary>
		/// Border의 Gap을 가져오거나 설정합니다.
		/// </summary>
	
		public int BorderGap
		{
			set { borderGap = value;}
			get { return borderGap; }
		}
		/// <summary>
		/// SmallChange를 가져오거나 설정합니다.
		/// </summary>
		public int SmallChange
		{
			set 
			{
				if ( value < min || value > max)
					smallChange = 1;
				smallChange = value;				
			}
			get { return smallChange;}
		}
		/// <summary>
		/// LargeChange를 가져오거나 설정합니다.
		/// </summary>
		public int LargeChange
		{
			set 
			{
				if ( value < min || value > max )
					largeChange = 1;
				largeChange = value;				
			}
			get { return largeChange;}
		}
		/// <summary>
		/// ScrollBar의 최소값을 가져오거나 설정합니다.
		/// </summary>
		public int Minimum
		{
			set { min = value;}
			get { return min; }
		}
		/// <summary>
		/// ScrollBar의 최대값을 가져오거나 설정합니다.
		/// </summary>
		public int Maximum
		{
			set { max = value;}
			get { return max; }
		}
		/// <summary>
		/// ScrollBar의 이전위치값을 가져옵니다.
		/// </summary>
		public int PreviousPosition
		{
			get { return (int)previousPos; }
		}
		/// <summary>
		/// ScrollBar의 Scroll시 Event 발생시기를 가져오거나 설정합니다.
		/// </summary>
		public ThumbDraggedFireFrequency ThumbDraggedFireFrequency
		{
			set { dragFrequency = value; }
			get { return dragFrequency; }
		}
		/// <summary>
		/// 배경색을 가져오거나 설정합니다.
		/// </summary>
		public Color BackgroundColor
		{
			set { backgroundColor = value;}
			get { return backgroundColor; }
		}
		/// <summary>
		/// 전경색을 가져오거나 설정합니다.
		/// </summary>
		public Color ForegroundColor
		{
			set { foregroundColor = value;}
			get { return foregroundColor; }
		}
		/// <summary>
		/// 테두리색을 가져오거나 설정합니다.
		/// </summary>
		public Color BorderColor
		{
			set { borderColor = value;}
			get { return borderColor; }
		}
		/// <summary>
		/// Pressed 상태의 색을 가져오거나 설정합니다.
		/// </summary>
		public Color PressedColor
		{
			set { pressedColor = value;}
			get { return pressedColor; }
		}
		/// <summary>
		/// Hover시 색을 가져오거나 설정합니다.
		/// </summary>
		public Color HoverColor
		{
			set { hoverColor = value;}
			get { return hoverColor; }
		}
		/// <summary>
		/// Arrow의 색을 가져오거나 설정합니다.
		/// </summary>
		public Color ArrowColor
		{
			set { arrowColor = value;}
			get { return arrowColor; }
		}
		/// <summary>
		/// Gripper의 밝은색을 가져오거나 설정합니다.
		/// </summary>
		public Color GripperLightColor
		{
			set { gripperLightColor = value;}
			get { return gripperLightColor; }
		}
		/// <summary>
		/// Gripper의 어두운색을 가져오거나 설정합니다.
		/// </summary>
		public Color GripperDarkColor
		{
			set { gripperDarkColor = value;}
			get { return gripperDarkColor; }
		}
		/// <summary>
		/// Horizontal, Vertical을 둘다사용하는지 여부를 가져오거나 설정합니다.
		/// </summary>
        
		public bool UsingBothScrollBars
		{
			set { usingBothScrollBars = value; }
			get { return usingBothScrollBars; }
		}
		/// <summary>
		/// Gripper를 그릴지 여부를 가져오거나 설정합니다.
		/// </summary>
		public bool DrawGripper
		{
			set 
			{ 
				drawGripper = value;
				Invalidate();
			}
			get { return drawGripper; }
		}
		/// <summary>
		/// 배경 Gradient시작색을 가져오거나 설정합니다.
		/// </summary>
		public Color GradientStartBackgroundColor
		{
			set { gradientStartBackgroundColor = value;}
			get { return gradientStartBackgroundColor; }
		}
		/// <summary>
		/// 배경 Gradient종료색을 가져오거나 설정합니다.
		/// </summary>
		public Color GradientEndBackgroundColor
		{
			set { gradientEndBackgroundColor = value;}
			get { return gradientEndBackgroundColor; }
		}
		/// <summary>
		/// 전경 Gradient시작색을 가져오거나 설정합니다.
		/// </summary>
		public Color GradientStartForegroundColor
		{
			set { gradientStartForegroundColor = value;}
			get { return gradientStartForegroundColor; }
		}
		/// <summary>
		/// 전경 Gradient종료색을 가져오거나 설정합니다.
		/// </summary>
		public Color GradientEndForegroundColor
		{
			set { gradientEndForegroundColor = value;}
			get { return gradientEndForegroundColor; }
		}
		/// <summary>
		/// Thumb영역의 ImageList를 가져오거나 설정합니다.
		/// </summary>
		public ImageList ThumbImageList
		{
			set { thumbImageList = value; }
			get { return thumbImageList; }
		}
		/// <summary>
		/// ScrollShaft영역의 Image를 가져오거나 설정합니다.
		/// </summary>
		public Image ScrollShaftImage
		{
			set { scrollShaftImage = value; }
			get { return scrollShaftImage; }
		}

		#endregion
		
		#region Implementation
		void CheckForUsingBothScrollBarsFlag(XScrollBar scrollBar)
		{
			for ( int i = 0; i < scrollBarList.Count; i++ )
			{
				XScrollBar currentScrollBar = (XScrollBar)scrollBarList[i];
				Debug.Assert(currentScrollBar != null);
				if ( currentScrollBar.parentWindow == scrollBar.parentWindow )
				{
					if ( currentScrollBar.GetType() != scrollBar.GetType() )
					{
						currentScrollBar.usingBothScrollBars = true;
						scrollBar.usingBothScrollBars = true;
					}
				}
			}
		}
		
		void ParentSizeChanged(object sender, EventArgs e)
		{
			SizeScrollBar();
		}
		/// <summary>
		/// StartingAutomaticScrolling Event를 발생시킵니다.
		/// </summary>
		protected void FireStartingAutomaticScrolling()
		{
			if ( StartingAutomaticScrolling != null )
				StartingAutomaticScrolling(this, EventArgs.Empty);
		}
		/// <summary>
		/// StoppingAutomaticScrolling Event를 발생시킵니다.
		/// </summary>
		protected void FireStoppingAutomaticScrolling()
		{
			if ( StoppingAutomaticScrolling != null )
				StoppingAutomaticScrolling(this, EventArgs.Empty);
		}
		/// <summary>
		/// ThumbReleased Event를 발생시킵니다.
		/// </summary>
		protected void FireThumbRelease()
		{
			if ( ThumbReleased != null )
				ThumbReleased(this, EventArgs.Empty);
		}

		#endregion

	}
}