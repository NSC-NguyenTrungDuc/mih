using System;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	/// <summary>
	/// DragHelper에 대한 요약 설명입니다.
	/// </summary>
	public class DragHelper
	{
		private static Cursor dragCursor;
		public static Cursor DragCursor
		{
			get { return dragCursor;}
		}
		static DragHelper()
		{
			//DragCursor set
			dragCursor = DrawHelper.DragCursor;
		}
		public static void CreateDragCursor(Control control, string text, Font font)
		{
			try
			{
				//Size Get
				Graphics g = control.CreateGraphics();
				SizeF size = g.MeasureString(text, font);
				size = new SizeF(size.Width + 4.0f, size.Height + 4.0f);
				int X = (int) size.Width;
				int Y = (int) size.Height;
				int rnd = 1;
				//Bitmap Get
				Bitmap bmp = new Bitmap(X, Y, PixelFormat.Format24bppRgb);
				Graphics gh = Graphics.FromImage(bmp);
				//Fill Rect
				Brush brush = new SolidBrush(Color.FromArgb(0xFF, 0XFD, 0XFC, 0XEB));
				gh.FillRectangle(brush, new Rectangle(0,0, X, Y));
				//Border Draw
				Point[] points = new Point[] {
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

				points[1].Offset(-1, 0);
				points[2].Offset(-1, 0);
				points[3].Offset(-1, 0);
				points[4].Offset(-1, -1);
				points[5].Offset(-1, -1);
				points[6].Offset(-1, -1);
				points[7].Offset(0, -1);
				points[8].Offset(0, -1);
				points[9].Offset(0, -1);
				Pen pen = new Pen(new SolidBrush(Color.FromArgb(126,156,184)), 1.0f);
				gh.DrawLines(pen, points);
				//Text Draw
				gh.DrawString(text, font, Brushes.Gray, 1.0f, 3.0f);

				//DragPoint Image Draw
				Image pointBmp = DrawHelper.DragPoint;
				PointF ptImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, 0,0, X,Y, pointBmp.Width, pointBmp.Height);
				RectangleF imageRect = new RectangleF(0,0, X,Y);
				imageRect.Intersect(new RectangleF(ptImage, pointBmp.PhysicalDimension));
				//Truncate the Rectangle for appreximation problem
				gh.DrawImage(pointBmp, Rectangle.Truncate(imageRect));

				gh.Dispose();
				g.Dispose();
				//Icon Get
				Icon icon = Icon.FromHandle(bmp.GetHicon());
				//Drag Cursor Get
				dragCursor = new Cursor(icon.Handle);
			}
			catch(Exception xe)
			{
				Debug.WriteLine("DragHelper::CreateDragCursor Error=" + xe.Message);
			}
		}
	}
}
