using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace IHIS.Framework
{
	/// <summary>
	/// XRotatorUtil에 대한 요약 설명입니다.
	/// </summary>
	internal class XRotatorUtil
	{
		public static Image ResizeImage(Image img, int percent)
		{
			float percentage = ((float)percent / 100);

			int sourceWidth = img.Width;
			int sourceHeight = img.Height;
            
			int destWidth = (int)(sourceWidth * percentage);
			if (destWidth <= 0)
			{
				destWidth = 1;
			}
            
			int destHeight = (int)(sourceHeight * percentage);
			if (destHeight <= 0)
			{
				destHeight = 1;
			}
			//create the bitmap 
			Bitmap bitmap = new Bitmap(destWidth, destHeight,PixelFormat.Format32bppArgb);
			bitmap.SetResolution(img.HorizontalResolution,img.VerticalResolution);

			//create the graphics from the bitmap
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				//set graphic flags for quality
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				//draw the image on the graphic
				graphics.DrawImage(img, new Rectangle(0, 0, destWidth, destHeight), new Rectangle(0, 0, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
				//free the graphic object
			}
			return bitmap;
		}

		/// <summary>
		/// Resize an image 
		/// </summary>
		/// <param name="img">the source image to be resize</param>
		/// <param name="width">the new width</param>
		/// <param name="height">the new height</param>
		/// <returns></returns>
		public static Image ResizeImage(Image img, int width, int height)
		{
			//create the bitmap 
			if (width == 0)
			{
				width = 1;
			}
			if (height == 0)
			{
				height = 1;
			}
			Bitmap bitmap = new Bitmap(width, height , PixelFormat.Format32bppArgb);
			bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
			//create the graphics from the bitmap
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				//set graphic flags for quality
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
				//draw the image on the graphic
				graphics.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
				//free the graphic object
			}
			return bitmap;
		}
	}
}
