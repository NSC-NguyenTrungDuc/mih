using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace IHIS.Framework
{
	#region Enums
	/// <summary>
	/// Arrow의 모양을 나타내는 Enum입니다.
	/// </summary>
	public enum ArrowGlyph
	{
		/// <summary>
		/// Up 화살표 모양
		/// </summary>
		Up,
		/// <summary>
		/// Down 화살표 모양
		/// </summary>
		Down,
		/// <summary>
		/// Left 화살표 모양
		/// </summary>
		Left,
		/// <summary>
		/// Right 화살표 모양
		/// </summary>
		Right
	}
	/// <summary>
	/// Paint시에 상태를 나타내는 Enum입니다.
	/// </summary>
	
	public enum DrawState
	{
		/// <summary>
		/// 정상상태
		/// </summary>
		Normal,
		/// <summary>
		/// Focus, MouseHover상태
		/// </summary>
		Hot,
		/// <summary>
		/// 눌려진 상태
		/// </summary>
		Pressed,
		/// <summary>
		/// 비활성 상태
		/// </summary>
		Disable
	}
	/// <summary>
	/// ScrollBar의 Hit위치를 나타내는 Enum입니다.
	/// </summary>
	public enum ScrollBarHit
	{
		/// <summary>
		/// Up 화살표 영역 Hit
		/// </summary>
		UpArrow,
		/// <summary>
		/// Down 화살표 영역 Hit
		/// </summary>
		DownArrow,
		/// <summary>
		/// PageUp 영역 Hit
		/// </summary>
		PageUp,
		/// <summary>
		/// PageDown 영역 Hit
		/// </summary>
		PageDown,
		/// <summary>
		/// Thumb 영역 Hit
		/// </summary>
		Thumb,
		/// <summary>
		/// Left 화살표 영역 Hit
		/// </summary>
		LeftArrow,
		/// <summary>
		/// Right 화살표 영역 Hit
		/// </summary>
		RightArrow,
		/// <summary>
		/// PageLeft 영역 Hit
		/// </summary>
		PageLeft,
		/// <summary>
		/// PageRight 영역 Hit
		/// </summary>
		PageRight,
		/// <summary>
		/// Hit 영역 없음
		/// </summary>
		None
	}
	#endregion

	/// <summary>
	/// DrawHelper에 대한 요약 설명입니다.
	/// </summary>
	public class DrawHelper
	{
		#region static Fields and Properties
		private const string cImagePath = @"IHIS.Framework.Images.";
		private static Image	checkIcon;
		private static Image	unCheckIcon;
		private static Cursor	dragCursor;
		private static Image	dragPoint;
		private static Image	findImage;
		private static Image	memoImage;
		private static Image	memoImages;
		private static Image	pickerImage;
		private static Image	nextNImage;
		private static Image	nextHImage;
		private static Image	nextPImage;
		private static Image	prevNImage;
		private static Image	prevHImage;
		private static Image	prevPImage;
		private static Image	portraitImage;
		private static Image	landscapeImage;
		private static Image	msgIconAsterisk;
		private static Image	msgIconError;
		private static Image	msgIconExclamation;
		private static Image	msgIconHand;
		private static Image	msgIconInformation;
		private static Image	msgIconQuestion;
		private static Image	msgIconStop;
		private static Image	msgIconWarning;

		/// <summary>
		/// Check 모양 Icon을 가져옵니다.
		/// </summary>
		public static Image CheckIcon
		{
			get { return checkIcon;}
		}
		/// <summary>
		/// UnCheck 배경색 Icon을 가져옵니다.
		/// </summary>
		public static Image UnCheckIcon
		{
			get { return unCheckIcon;}
		}
		/// <summary>
		/// Drag Cursor 을 가져옵니다.
		/// </summary>
		public static Cursor DragCursor
		{
			get { return dragCursor;}
		}
		/// <summary>
		/// DragHelper에서 쓰이는 DragPoint 를 가져옵니다.
		/// </summary>
		public static Image DragPoint
		{
			get { return dragPoint;}
		}
		/// <summary>
		/// FindBox의 Image 가져옵니다.
		/// </summary>
		public static Image FindImage
		{
			get { return findImage;}
		}
		/// <summary>
		/// DatePicker의 Image 가져옵니다.
		/// </summary>
		public static Image PickerImage
		{
			get { return pickerImage;}
		}
		/// <summary>
		/// MemoBox의 Image 가져옵니다.
		/// </summary>
		public static Image MemoImage
		{
			get { return memoImage;}
		}
		/// <summary>
		/// MemoBox의 Image 가져옵니다.
		/// </summary>
		public static Image MemoImages
		{
			get { return memoImages;}
		}
		/// <summary>
		/// 화살표(왼쪽) Image(Normal)을 가져옵니다.
		/// </summary>
		public static Image PrevNImage
		{
			get { return prevNImage;}
		}
		/// <summary>
		/// 화살표(왼쪽) Image(Hover)을 가져옵니다.
		/// </summary>
		public static Image PrevHImage
		{
			get { return prevHImage;}
		}
		/// <summary>
		/// 화살표(왼쪽) Image(Push)을 가져옵니다.
		/// </summary>
		public static Image PrevPImage
		{
			get { return prevPImage;}
		}
		/// <summary>
		/// 화살표(오른쪽) Image(Normal)을 가져옵니다.
		/// </summary>
		public static Image NextNImage
		{
			get { return nextNImage;}
		}
		/// <summary>
		/// 화살표(왼쪽) Image(Hover)을 가져옵니다.
		/// </summary>
		public static Image NextHImage
		{
			get { return nextHImage;}
		}
		/// <summary>
		/// 화살표(왼쪽) Image(Push)을 가져옵니다.
		/// </summary>
		public static Image NextPImage
		{
			get { return nextPImage;}
		}
		/// <summary>
		/// -> 화살표 Image을 가져옵니다.
		/// </summary>
		public static Image PortraitImage
		{
			get { return portraitImage;}
		}
		/// <summary>
		/// MessageBox의 Icon을 가져옵니다.
		/// </summary>
		public static Image LandscapeImage
		{
			get { return landscapeImage;}
		}
		/// <summary>
		/// MsgBox의 Asterisk Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconAsterisk
		{
			get { return msgIconAsterisk;}
		}
		/// <summary>
		/// MsgBox의 Error Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconError
		{
			get { return msgIconError;}
		}
		/// <summary>
		/// MsgBox의 Exlamation Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconExclamation
		{
			get { return msgIconExclamation;}
		}
		/// <summary>
		/// MsgBox의 Hand Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconHand
		{
			get { return msgIconHand;}
		}
		/// <summary>
		/// MsgBox의 Information Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconInformation
		{
			get { return msgIconInformation;}
		}
		/// <summary>
		/// MsgBox의 Question Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconQuestion
		{
			get { return msgIconQuestion;}
		}
		/// <summary>
		/// MsgBox의 Stop Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconStop
		{
			get { return msgIconStop;}
		}
		/// <summary>
		/// MsgBox의 Warning Icon을 가져옵니다.
		/// </summary>
		public static Image MsgIconWarning
		{
			get { return msgIconWarning;}
		}
		#endregion
		
		#region 생성자
		// No need to construct this object
		static DrawHelper()
		{
			checkIcon		= ExtractImage("CheckBox.gif");
			unCheckIcon		= ExtractImage("UnCheckBox.gif");
			dragCursor		= ExtractCursor("DragCursor.cur");
			dragPoint		= ExtractImage("DragPoint.bmp");
			findImage		= ExtractImage("FindImage.gif");
			pickerImage		= ExtractImage("PickerImage.gif");
			memoImage		= ExtractImage("MemoImage.gif");
			memoImages		= ExtractImage("MemoImages.gif");
			nextNImage		= ExtractImage("NextN.gif");
			nextHImage		= ExtractImage("NextH.gif");
			nextPImage		= ExtractImage("NextP.gif");
			prevNImage		= ExtractImage("PrevN.gif");
			prevHImage		= ExtractImage("PrevH.gif");
			prevPImage		= ExtractImage("PrevP.gif");
			portraitImage	= ExtractImage("Portrait.gif");
			landscapeImage	= ExtractImage("Landscape.gif");
			msgIconAsterisk		= ExtractImage("Asterisk.gif");
			msgIconError		= ExtractImage("Error.gif");
			msgIconExclamation	= ExtractImage("Exclamation.gif");
			msgIconHand			= ExtractImage("Hand.gif");
			msgIconInformation	= ExtractImage("Information.gif");
			msgIconQuestion		= ExtractImage("Question.gif");
			msgIconStop			= ExtractImage("Stop.gif");
			msgIconWarning		= ExtractImage("Warning.gif");
		}
		#endregion

		#region Methods
		private static Image ExtractImage(string imageName)
		{
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			Bitmap bmp = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream(cImagePath + imageName));
			//bmp.MakeTransparent();
			return bmp;
		}
		private static Cursor ExtractCursor(string imageName)
		{
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			Cursor cur = new Cursor(l_as.GetManifestResourceStream(cImagePath + imageName));
			return cur;
		}
		/// <summary>
		/// 화살표를 그립니다.
		/// </summary>
		/// <param name="g"> 칠하는 데 사용할 Graphics 개체 </param>
		/// <param name="rc"> 그리기 영역 </param>
		/// <param name="arrowGlyph"> 화살표 모양 </param>
		/// <param name="brush"> 도형내부를 채우는데 사용되는 Brush </param>
		static public void DrawArrowGlyph(Graphics g, Rectangle rc, ArrowGlyph arrowGlyph, Brush brush)
		{
			// Draw arrow glyph with the default 
			// size of 5 pixel wide and 3 pixel high
			DrawArrowGlyph(g, rc, 5, 3, arrowGlyph, brush);
		}
		/// <summary>
		/// 화살표를 그립니다.
		/// </summary>
		/// <param name="g"> 칠하는 데 사용할 Graphics 개체 </param>
		/// <param name="rc"> 그리기 영역 </param>
		/// <param name="arrowWidth"> 화살표의 너비 </param>
		/// <param name="arrowHeight"> 화살표의 높이 </param>
		/// <param name="arrowGlyph"> 화살표 모양 </param>
		/// <param name="brush"> 도형내부를 채우는데 사용되는 Brush </param>
		static public void DrawArrowGlyph(Graphics g, Rectangle rc, int arrowWidth, int arrowHeight, ArrowGlyph arrowGlyph, Brush brush)
		{
			// Tip: use an odd number for the arrowWidth and 
			// arrowWidth/2+1 for the arrowHeight 
			// so that the arrow gets the same pixel number
			// on the left and on the right and get symetrically painted
			
			Point[] pts = new Point[3];
			int yMiddle = rc.Top + rc.Height/2-arrowHeight/2+1;
			int xMiddle = rc.Left + rc.Width/2;
			
			if ( arrowGlyph == ArrowGlyph.Up )
			{
				pts[0] = new Point(xMiddle, yMiddle-2);
				pts[1] = new Point(xMiddle-arrowWidth/2-1, yMiddle+arrowHeight-1);
				pts[2] = new Point(xMiddle+arrowWidth/2+1,  yMiddle+arrowHeight-1);
				
			}
			else if ( arrowGlyph == ArrowGlyph.Down )
			{
				pts[0] = new Point(xMiddle-arrowWidth/2, yMiddle);
				pts[1] = new Point(xMiddle+arrowWidth/2+1,  yMiddle);
				pts[2] = new Point(xMiddle, yMiddle+arrowHeight);
			}
			else if ( arrowGlyph == ArrowGlyph.Left )
			{
				yMiddle = rc.Top + rc.Height/2;
				pts[0] = new Point(xMiddle-arrowHeight/2,  yMiddle);
				pts[1] = new Point(pts[0].X+arrowHeight, yMiddle-arrowWidth/2-1);
				pts[2] = new Point(pts[0].X+arrowHeight,  yMiddle+arrowWidth/2+1);

			}
			else if ( arrowGlyph == ArrowGlyph.Right )
			{
				yMiddle = rc.Top + rc.Height/2;
				pts[0] = new Point(xMiddle+arrowHeight/2+1,  yMiddle);
				pts[1] = new Point(pts[0].X-arrowHeight, yMiddle-arrowWidth/2-1);
				pts[2] = new Point(pts[0].X-arrowHeight,  yMiddle+arrowWidth/2+1);
			}

			g.FillPolygon(brush, pts);
		}
		/// <summary>
		/// BitMap 이미지를 Copy합니다.
		/// </summary>
		/// <param name="gDest"> 칠하는 데 사용할 Graphics 개체 </param>
		/// <param name="rcDest"> 그리기 영역 </param>
		/// <param name="xSrc"> Source의 X </param>
		/// <param name="ySrc"> Source의 Y </param>
		/// <param name="handleBitmap"> Bitmap의 Handle </param>
		static public void BlitBitmap(Graphics gDest, Rectangle rcDest, int xSrc, int ySrc, IntPtr handleBitmap)
		{
			// Use this function when you want faster painting of a image. Specially
			// if that image is being painting many time in a short period of time
			// --like when dragging the thumb of a scrollbar and painting an image in 
			// real time-- Having the handle of the bitmap saved somewhere avoids
			// recreating the handle every time the image is drawn as GDI+ does it 
			// every time it paints the image
			IntPtr hDCTo = gDest.GetHdc();
			IntPtr hDCSrc = Gdi32.CreateCompatibleDC(hDCTo);
			IntPtr hOldFromBitmap = Gdi32.SelectObject(hDCSrc, handleBitmap);
			Gdi32.BitBlt(hDCTo, rcDest.Left, rcDest.Top, rcDest.Width, rcDest.Height, hDCSrc, xSrc, ySrc, (int)Win32.PatBltTypes.SRCCOPY);

			// Cleanup
			Gdi32.SelectObject(hDCSrc, hOldFromBitmap);
			Gdi32.DeleteDC(hDCSrc);
			gDest.ReleaseHdc(hDCTo);
		}
		/// <summary>
		/// 정렬방식, Display영역에 따라 그리기위치를 가져옵니다.
		/// </summary>
		/// <param name="align"> ContentAlignment </param>
		/// <param name="clientLeft"> 표시영역 Left </param>
		/// <param name="clientTop"> 표시영역 Top </param>
		/// <param name="clientWidth"> 표시영역 Width </param>
		/// <param name="clientHeight"> 표시영역 Height </param>
		/// <param name="objWidth"> 보여줄 값의 Width </param>
		/// <param name="objHeight"> 보여줄 값의 Height </param>
		/// <returns> PointF </returns>
		static public PointF GetObjAlignment(ContentAlignment align, int clientLeft, int clientTop, int clientWidth, int clientHeight, float objWidth, float objHeight)
		{
			//default X left
			PointF point = new PointF((float)clientLeft,(float)clientTop);

			//Y
			if (align == ContentAlignment.TopCenter ||
				align == ContentAlignment.TopLeft ||
				align == ContentAlignment.TopRight) //Y Top
				point.Y = (float)clientTop;
			else if (align == ContentAlignment.BottomCenter ||
				align == ContentAlignment.BottomLeft ||
				align == ContentAlignment.BottomRight) //Y bottom
				point.Y = (float)clientTop + ((float)clientHeight) - objHeight;
			else //default Y middle
				point.Y = (float)clientTop + ((float)clientHeight)/2.0F - objHeight/2.0F;

			if ( align == ContentAlignment.BottomCenter ||
				align == ContentAlignment.MiddleCenter ||
				align == ContentAlignment.TopCenter)//X Center
				point.X = (float)clientLeft + ((float)clientWidth)/2.0F - objWidth/2.0F;
			else if (align == ContentAlignment.BottomRight ||
				align == ContentAlignment.MiddleRight ||
				align == ContentAlignment.TopRight)//X Right
				point.X = (float)clientLeft + (float)clientWidth - objWidth;
			//middle default already set

			return point;
		}
		static public SizeF MeasureString(Graphics g, string text, Font font, ContentAlignment align)
		{
			//ContentAlignment가 Left, Center이면 MeasureString그대로 적용
			//Right이면 굴림 등 특정 Font에서 그냥 MeasureString하면 Margin이 많이 적용되므로 다른 방법으로 설정
			if (IsRight(align))
			{
				StringFormat	format  = new StringFormat ();
				RectangleF rectF = new RectangleF(0,0, 1000,1000);
				CharacterRange[] ranges  = { new CharacterRange(0, text.Length) };
				Region[]		regions = new System.Drawing.Region[1];
				format.SetMeasurableCharacterRanges (ranges);

				regions = g.MeasureCharacterRanges (text, font, rectF, format);
				rectF  = regions[0].GetBounds (g);
				format.Dispose();
				//Margin고려
				return new SizeF(rectF.Right + 3.0f, rectF.Height + 1.5f);
			}
			else
				return g.MeasureString(text, font);
		}
		/// <summary>
		/// Alignment가 Left인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Left이면 true, 아니면 false </returns>
		public static bool IsLeft(ContentAlignment a)
		{
			return (a == ContentAlignment.BottomLeft ||
				a == ContentAlignment.MiddleLeft ||
				a == ContentAlignment.TopLeft);
		}
		/// <summary>
		/// Alignment가 Right인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Right이면 true, 아니면 false </returns>
		public static bool IsRight(ContentAlignment a)
		{
			return (a == ContentAlignment.BottomRight ||
				a == ContentAlignment.MiddleRight ||
				a == ContentAlignment.TopRight);
		}
		/// <summary>
		/// Alignment가 Center인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Center이면 true, 아니면 false </returns>
		public static bool IsHCenter(ContentAlignment a)
		{
			return (a == ContentAlignment.BottomCenter ||
				a == ContentAlignment.MiddleCenter ||
				a == ContentAlignment.TopCenter);
		}
		/// <summary>
		/// Alignment가 Left인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Left이면 true, 아니면 false </returns>
		public static bool IsTop(ContentAlignment a)
		{
			return (a == ContentAlignment.TopLeft ||
				a == ContentAlignment.TopRight ||
				a == ContentAlignment.TopCenter);
		}
		/// <summary>
		/// Alignment가 Right인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Right이면 true, 아니면 false </returns>
		public static bool IsBottom(ContentAlignment a)
		{
			return (a == ContentAlignment.BottomCenter ||
				a == ContentAlignment.BottomRight ||
				a == ContentAlignment.BottomLeft);
		}
		/// <summary>
		/// Alignment가 Center인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Center이면 true, 아니면 false </returns>
		public static bool IsVCenter(ContentAlignment a)
		{
			return (a == ContentAlignment.MiddleCenter ||
				a == ContentAlignment.MiddleLeft ||
				a == ContentAlignment.MiddleRight);
		}
		public static Size GetTextSize(Graphics graphics, string text, Font font, int width)
		{
			StringFormat format = new StringFormat();
			format.HotkeyPrefix = HotkeyPrefix.Show;
			//format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
			SizeF stringSize = graphics.MeasureString(text, font, width, format);

			return new Size((int)stringSize.Width, (int)stringSize.Height);
		}
		/// <summary>
		/// Font를 고려한 Text의 Size를 반환합니다.
		/// </summary>
		/// <param name="graphics"> Paint시 사용할 Graphics 개체 </param>
		/// <param name="text"> Text String </param>
		/// <param name="font"> Font 개체 </param>
		/// <returns> 해당 Text의 Size </returns>
		public static Size GetTextSize(Graphics graphics, string text, Font font)
		{
			IntPtr hdc = graphics.GetHdc();
			IntPtr fontHandle = font.ToHfont();
			IntPtr currentFontHandle = Gdi32.SelectObject(hdc, fontHandle);
			
			Win32.RECT rect = new Win32.RECT();
			rect.left = 0;
			rect.right = 0;
			rect.top = 0;
			rect.bottom = 0;
		
			User32.DrawText(hdc, text, text.Length, ref rect, 
				(int)(Win32.DrawTextFormatFlags.DT_SINGLELINE | Win32.DrawTextFormatFlags.DT_LEFT | Win32.DrawTextFormatFlags.DT_CALCRECT));
			Gdi32.SelectObject(hdc, currentFontHandle);
			Gdi32.DeleteObject(fontHandle);
			graphics.ReleaseHdc(hdc);
				
			return new Size(rect.right - rect.left, rect.bottom - rect.top);
		}
		#endregion
	}
}
