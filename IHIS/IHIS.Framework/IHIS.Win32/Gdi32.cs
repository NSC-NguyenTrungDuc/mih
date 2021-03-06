using System;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
    public class Gdi32
    {
        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int CombineRgn(IntPtr dest, IntPtr src1, IntPtr src2, int flags);

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr CreateRectRgnIndirect(ref Win32.RECT rect); 

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int GetClipBox(IntPtr hDC, ref Win32.RECT rectBox); 

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn); 

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr CreateBrushIndirect(ref Win32.LOGBRUSH brush); 

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern bool PatBlt(IntPtr hDC, int x, int y, int width, int height, uint flags); 

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr DeleteObject(IntPtr hObject);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern IntPtr CreateDC(string szdriver, string szdevice, string szoutput, IntPtr devmode);
		
		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern bool DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", CharSet=CharSet.Auto)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("gdi32")]
		public static extern int SetBkMode(IntPtr hDC, Win32.BackgroundMode mode);

		[DllImport("gdi32.dll")]
		public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);

		[DllImport("gdi32.dll", ExactSpelling=true)]
		public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);
		
		[DllImport("gdi32.dll")]
		public static extern int SetROP2(IntPtr hdc,int enDrawMode);
		
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreatePen(Win32.PenStyles enPenStyle,int nWidth,int crColor);

		[DllImport("gdi32.dll")]
		public static extern void Rectangle(IntPtr hdc,int X1,int Y1,int X2,int Y2);
		[DllImport("gdi32.dll")]
		public static extern bool MoveToEx(IntPtr hdc,int X,int Y, IntPtr oldPoint);
		[DllImport("gdi32.dll")]
		public static extern bool LineTo(IntPtr hdc,int EndX,int EndY);

		[DllImport("gdi32.dll")]
		public static extern IntPtr GetStockObject(int brStyle);

		[DllImport("gdi32.dll", CharSet=CharSet.Auto)]
		public static extern bool BitBlt(
			IntPtr hdcDest, // handle to destination DC
			int nXDest,  // x-coord of destination upper-left corner
			int nYDest,  // y-coord of destination upper-left corner
			int nWidth,  // width of destination rectangle
			int nHeight, // height of destination rectangle
			IntPtr hdcSrc,  // handle to source DC
			int nXSrc,   // x-coordinate of source upper-left corner
			int nYSrc,   // y-coordinate of source upper-left corner
			System.Int32 dwRop  // raster operation code
			);
    }
}