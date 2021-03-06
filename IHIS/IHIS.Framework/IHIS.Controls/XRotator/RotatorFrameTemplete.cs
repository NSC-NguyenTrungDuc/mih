using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace IHIS.Framework
{
	#region delegates
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	internal delegate void HeaderPersantageChangedEvent(object sender, EventArgs args);

	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	internal delegate void BodyTextColorChangedEvent(object sender, EventArgs args);
    
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="args"></param>
	internal delegate void TextAnimationDelayChangedEvent(object sender,EventArgs args);
	#endregion

	#region RotatorFrameTemplate
	internal class RotatorFrameTemplate
	{

		#region Fields
		/// <summary>
		/// In milliseconds time between the text animation
		/// </summary>
		private int textAnimationDelay = 200;

		/// <summary>
		/// 전체 Frame에서 Header의 %
		/// </summary>
		private int headerPersantage = 20;

		/// <summary>
		/// Brush type used to fill the background of the rotator frame header background
		/// </summary>
		private XRotatorBrushType headerBrushType = XRotatorBrushType.Solid;

		/// <summary>
		/// Brush type used to fill the background of the rotator frame main text area background
		/// </summary>
		private XRotatorBrushType bodyBrushType = XRotatorBrushType.Solid;

		internal XColor BorderColor = XColor.XRotatorBorderColor;

		//Header 모양
		private Font headerFont = new Font("MS UI Gothic", 9.75f);
		private XColor headerTextColor = XColor.XRotatorHeaderTextColor;
		private XColor headerBackColor = XColor.XRotatorHeaderBackColor;
		private XColor headerGradientStartColor = XColor.XRotatorHeaderGradientStartColor;
		private XColor headerGradientEndColor = XColor.XRotatorHeaderGradientEndColor;
		private Brush headerBrush = null;

		//Body 모양
		private Font bodyFont = new Font("MS UI Gothic", 9.75f);
		private XColor bodyTextColor = XColor.XRotatorBodyTextColor;
		private XColor bodyBackColor = XColor.XRotatorBodyBackColor;
		private XColor bodyGradientStartColor = XColor.XRotatorBodyGradientStartColor;
		private XColor bodyGradientEndColor = XColor.XRotatorBodyGradientEndColor;
		private Brush bodyBrush = null;
		#endregion

		#region Properties
		internal int TextAnimationDelay
		{
			get { return textAnimationDelay; }
			set 
			{
				if (value != textAnimationDelay)
				{
					textAnimationDelay = value;
					if (null != TextAnimationDelayChanged)
					{
						TextAnimationDelayChanged(this, EventArgs.Empty);
					}
				}
			}
		}

		/// <summary>
		/// Get the brush used for the header part of a rotator frame
		/// </summary>
		internal Brush HeaderBrush
		{
			get	{ return headerBrush; }
		}

		/// <summary>
		/// Get the brush used for the main text area of a rotator frame
		/// </summary>
		internal Brush BodyBrush
		{
			get	{ return bodyBrush;	}
		}

		/// <summary>
		/// Get/Set the font for the header text
		/// </summary>
		internal Font HeaderFont
		{
			get { return headerFont; }
			set { headerFont = value; }
		}

		/// <summary>
		/// Get/Set the font for the main text
		/// </summary>
		internal Font BodyFont
		{
			get	{ return bodyFont;}
			set	{ bodyFont = value;}
		}

		/// <summary>
		/// Get/Set the text color for the header text
		/// </summary>
		internal XColor HeaderTextColor
		{
			get { return headerTextColor; }
			set { headerTextColor = value; }
		}

		/// <summary>
		/// Get/Set the brush type for the header background
		/// </summary>
		internal XRotatorBrushType HeaderBrushType
		{
			get { return headerBrushType; }
			set { headerBrushType = value; }
		}

		/// <summary>
		/// Get/Set the brush type for the main text part background
		/// </summary>
		internal XRotatorBrushType BodyBrushType
		{
			get { return bodyBrushType; }
			set { bodyBrushType = value; }
		}

		internal XColor HeaderBackColor
		{
			get { return this.headerBackColor; }
			set { headerBackColor = value; }
		}

		internal XColor HeaderGradientStartColor
		{
			get { return headerGradientStartColor; }
			set { headerGradientStartColor = value; }
		}
		internal XColor HeaderGradientEndColor
		{
			get { return headerGradientEndColor; }
			set { headerGradientEndColor = value; }
		}
		
		internal XColor BodyBackColor
		{
			get { return this.bodyBackColor; }
			set { bodyBackColor = value; }
		}
		internal XColor BodyGradientStartColor
		{
			get { return bodyGradientStartColor; }
			set { bodyGradientStartColor = value; }
		}
		internal XColor BodyGradientEndColor
		{
			get { return bodyGradientEndColor; }
			set { bodyGradientEndColor = value; }
		}
		internal XColor BodyTextColor
		{
			get { return bodyTextColor; }
			set 
			{
				if (bodyTextColor != value)
				{
					bodyTextColor = value;
					if (BodyTextColorChanged != null)
						BodyTextColorChanged(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Get/Set the size in pixels for the rotator frame header 
		/// </summary>
		internal int HeaderPersantage
		{
			get { return headerPersantage; }
			set 
			{
				if (value != headerPersantage)
				{
					headerPersantage = Math.Min(Math.Max(10, value),90);
					if (null != HeaderPersantageChanged)
						HeaderPersantageChanged(this, EventArgs.Empty);
				}
			}
		}
		#endregion

		#region Events
		/// <summary>
		/// The event raised whenever the size of the rotator frame header has changed
		/// </summary>
		internal event HeaderPersantageChangedEvent HeaderPersantageChanged = null;

		/// <summary>
		/// Event raised whenever the text color for the main text in the rotator frame has changed
		/// </summary>
		internal event BodyTextColorChangedEvent BodyTextColorChanged = null;

		/// <summary>
		/// Event raised when the text animation delay has been changed
		/// </summary>
		internal event TextAnimationDelayChangedEvent TextAnimationDelayChanged = null;
		#endregion

		#region 생성자
		internal RotatorFrameTemplate()
		{
		}
		#endregion
	}
	#endregion
}
