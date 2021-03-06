using System;
using System.Drawing;

namespace IHIS.Framework
{
	/// <summary>
	/// RubberBandRect에 대한 요약 설명입니다.
	/// 이미지에디서에서 선택시 영역을 표시하는 Rectangle
	/// 
	/// </summary>
	internal class BandRectangle
	{
		const int NULL_BRUSH = 5;
		const int R2_XORPEN = 7;
		const int BLACK_PEN = 0;
		
		public BandRectangle() {}

		public void DrawXORRectangle( Graphics g,int X1, int Y1, int X2, int Y2 )
		{
			// Extract the Win32 HDC from the Graphics object supplied.
			IntPtr hdc = g.GetHdc();
		
			// Create a pen with a dotted style to draw the border of the
			IntPtr gdiPen = Gdi32.CreatePen(Win32.PenStyles.PS_DOT ,1, BLACK_PEN );
			
			// Set the ROP cdrawint mode to XOR.
			Gdi32.SetROP2( hdc, R2_XORPEN );
			
			// Select the pen into the device context.
			IntPtr oldPen = Gdi32.SelectObject(hdc, gdiPen );
			
			// Create a stock NULL_BRUSH brush and select it into the device
			// context so that the rectangle isn't filled.
			IntPtr oldBrush = Gdi32.SelectObject( hdc, Gdi32.GetStockObject( NULL_BRUSH ));
			
			// Now XOR the hollow rectangle on the Graphics object with
			// a dotted outline.
			Gdi32.Rectangle( hdc, X1, Y1, X2, Y2 );
			
			// Put the old stuff back where it was.
			Gdi32.SelectObject( hdc, oldBrush ); // no need to delete a stock object
			Gdi32.SelectObject( hdc, oldPen );
			Gdi32.DeleteObject( gdiPen );		// but we do need to delete the pen
			
			// Return the device context to Windows.
			g.ReleaseHdc( hdc );
		}

		public void DrawXORLine(Graphics g, int X1, int Y1, int X2, int Y2)
		{
			// Extract the Win32 HDC from the Graphics object supplied.
			IntPtr hdc = g.GetHdc();
		
			// Create a pen with a dotted style to draw the border of the
			IntPtr gdiPen = Gdi32.CreatePen(Win32.PenStyles.PS_DOT ,1, BLACK_PEN );
			
			// Set the ROP cdrawint mode to XOR.
			Gdi32.SetROP2( hdc, R2_XORPEN );
			
			// Select the pen into the device context.
			IntPtr oldPen = Gdi32.SelectObject(hdc, gdiPen );
			
			// Now XOR the hollow Line on the Graphics object with  a dotted line.
			Gdi32.MoveToEx(hdc, X1, Y1, IntPtr.Zero);
			Gdi32.LineTo(hdc, X2, Y2);
		
			// Put the old stuff back where it was.
			Gdi32.SelectObject( hdc, oldPen );
			Gdi32.DeleteObject( gdiPen );		// but we do need to delete the pen
			
			// Return the device context to Windows.
			g.ReleaseHdc( hdc );
		}
	}
}
