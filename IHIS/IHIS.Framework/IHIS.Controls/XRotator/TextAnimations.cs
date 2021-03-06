using System;
using System.Drawing;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region delegator
	internal delegate void AnimationFinished(object sender, EventArgs e);
	#endregion

	#region TextAnimation
	/// <summary>
	/// TextAnimation에 대한 요약 설명입니다.
	/// </summary>
	internal abstract class TextAnimation
	{
		#region Members

		/// <summary>
		/// Flag for raising the finish animation only once
		/// </summary>
		protected bool eventSignaled = false;

		/// <summary>
		/// text to be animated
		/// </summary>
		protected string text = "";

		/// <summary>
		/// Reference to the graphics object doing the text rendering
		/// </summary>
		protected Graphics graphics = null;

		/// <summary>
		/// The color of the text
		/// </summary>
		protected Color textColor = Color.Empty;

		/// <summary>
		/// Reference to the font used in rendering the text
		/// </summary>
		protected Font font = new Font("Arial" ,10);

		//<IHIS>
		public RectangleF FrameArea = RectangleF.Empty; //RotatorFrame의 Area

		public XRotatorItem ItemData = null;
		#endregion

		#region Properties
		/// <summary>
		/// Get/Set the text to be animated
		/// </summary>
		public virtual string Text
		{
			get { return text;}
			set	{ text = value;}
		}
		/// <summary>
		/// Set the graphic object
		/// </summary>
		public Graphics Graphics
		{
			set	{ this.graphics = value;}
		}
		/// <summary>
		/// Set the text color
		/// </summary>
		public virtual Color TextColor
		{
			set	{ this.textColor = value;}
		}

		/// <summary>
		/// Set the font used in drawing the text
		/// </summary>
		public Font Font
		{
			set	{ this.font = value;}
		}
		#endregion

		#region Abstract
		/// <summary>
		/// Method to reset the animation
		/// </summary>
		public abstract void Reset();

		/// <summary>
		/// The method responsible for drawing the text
		/// </summary>
		public abstract void DrawText();
            
		#endregion
	}
	#endregion

	#region FadeTextAnimation
	internal class FadeTextAnimation : TextAnimation
	{
		#region Members
		private int fadingStep = 1;
		public event AnimationFinished AnimationFinished = null;
		#endregion

		#region Override
		public override void DrawText()
		{
			if (this.ItemData == null) return;
			if (text == "") return;

			StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.MeasureTrailingSpaces);
			SizeF size = graphics.MeasureString(text, font, ItemData.TextArea.Size, stringFormat);
			float widthAdjustment = (ItemData.TextArea.Width - size.Width) / 2;
			float heightAdjustment = (ItemData.TextArea.Height - size.Height) / 2;

			RectangleF tempArea = new RectangleF(new PointF(ItemData.TextArea.X + widthAdjustment, ItemData.TextArea.Y + heightAdjustment), size);

			if (fadingStep >= 255)
			{
				using (Brush brush = new SolidBrush(textColor))
				{
					graphics.DrawString(text, font, brush, tempArea);
					if (!eventSignaled && AnimationFinished != null)
						AnimationFinished(this, EventArgs.Empty);
				}
			}
			else
			{

				using (Brush brush = new SolidBrush(Color.FromArgb(fadingStep, textColor)))
					graphics.DrawString(text, font, brush, tempArea);

				fadingStep += fadingStep;
			}
		}


		public override void Reset()
		{
			fadingStep = 1;
			eventSignaled = false;
		}
		#endregion
       
	}
	#endregion

	#region TypingTextAnimation
	internal class TypingTextAnimation : TextAnimation, IDisposable
	{
		#region Members
		/// <summary>
		/// index of the current character within the given text
		/// </summary>
		private int index = 0;
		/// <summary>
		/// The brush used in drawing the text
		/// </summary>
		private Brush brush = null;
		/// <summary>
		/// The string formatting flags
		/// </summary>
		private StringFormat stringFormat = null;
		public event AnimationFinished AnimationFinished = null;
		private bool isExceedArea = false; //Text가 Area를 초과하는지 여부
 		#endregion

		#region 생성자
		public TypingTextAnimation()
		{
			//set the string format flags
			stringFormat = new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.MeasureTrailingSpaces);
			stringFormat.Trimming = StringTrimming.EllipsisWord;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Set the color of the text being animated
		/// </summary>
		public override Color TextColor
		{
			set
			{
				if (value != textColor)
				{
					textColor = value;
					this.brush = new SolidBrush(textColor);
				}
			}
		}
		/// <summary>
		/// Set the text to be animated
		/// </summary>
		public override string Text
		{
			set
			{
				text = value;
				//reset index
				index = 0;
				//flag for raising the animaiton finished event
				eventSignaled = false;
			}
		}
		#endregion

		#region Override
		/// <summary>
		/// Reset the animation
		/// </summary>
		public override void Reset()
		{
			index = 0;
			eventSignaled = false;
		}

		/// <summary>
		/// The method responsible for drawing the text
		/// </summary>
		public override void DrawText()
		{
			if (this.ItemData == null) return;
			if (this.text == "") return; //그릴 것이 없음

			if (null == brush)
				brush = new SolidBrush(textColor);
			//calculate the text size if needed
			if (!this.ItemData.MeasuredBodyTextSize)
			{
				//Set Measured Flag
				this.ItemData.MeasuredBodyTextSize = true;
                
				//<IHIS>
				SizeF size = graphics.MeasureString(text, font, this.FrameArea.Size, stringFormat);
				//center the text within the given rectangle
				float widthAdjustment = (FrameArea.Width - size.Width) / 2;
				float heightAdjustment = (FrameArea.Height - size.Height) / 2;
				//set the new area
				ItemData.TextArea = new RectangleF(new PointF(FrameArea.X, FrameArea.Y + heightAdjustment), size);
			}
            

			if (index >= text.Length)
			{
				if (!isExceedArea)  //Text가 Area를 초과하지 않을 경우만 Text Set
					graphics.DrawString(text, font, brush, ItemData.TextArea);

				//raise the event if necessary
				if (null != AnimationFinished && !eventSignaled)
				{
					AnimationFinished(this, EventArgs.Empty);
					eventSignaled = true;
				}
			}
			else
			{
				//draw part of the text
				string drawText = text.Substring(0, index);
				graphics.DrawString(drawText, font, brush, ItemData.TextArea);
				//set the new step of the animation
				index++ ;
				if (index > text.Length)
					index = text.Length;

				SizeF sizeExceed = graphics.MeasureString(drawText, font, ItemData.TextArea.Size, stringFormat);
				//if text exceeds the available area don't draw it
				if (sizeExceed.Height > ItemData.TextArea.Height)
				{
					isExceedArea = true; //Flag Set
					index = text.Length;
				}
				else
					isExceedArea = false; //Flag Clear
			}
		}
		#endregion

		#region IDisposable Members
		public void Dispose()
		{
			if (null != brush)
			{
				brush.Dispose();
				brush = null;
			}
		}
		#endregion
	}
	#endregion

	#region NoTextAnimation
	internal class NoTextAnimation : TextAnimation, IDisposable
	{
		#region Members
		private Brush brush = null;
		public event AnimationFinished AnimationFinished = null;
		#endregion

		#region Override
		public override void Reset()
		{
			//기능없음            
		}

		public override void DrawText()
		{
			if (this.ItemData == null) return;
			if (text == "") return;
			if(null == brush)
				brush = new SolidBrush(textColor);

			graphics.DrawString(text, font, brush, ItemData.TextArea);
			if (!eventSignaled && AnimationFinished != null)
				AnimationFinished(this, EventArgs.Empty);
		}
		#endregion

		#region IDisposable Members
		public void Dispose()
		{
			if (null != brush)
			{
				brush.Dispose();
				brush = null;
			}
		}
		#endregion
	}
	#endregion

	#region TextAnimationFactory
	internal class TextAnimationFactory
	{
		public static TextAnimation GetAnimation(XRotatorAnimationMode mode)
		{
			TextAnimation animation = null;
			switch (mode)
			{
				case XRotatorAnimationMode.None :
					animation = new NoTextAnimation();
					break;

				case XRotatorAnimationMode.Fading:
					animation = new FadeTextAnimation();
					break;
                    
				case XRotatorAnimationMode.Typing:
					animation = new TypingTextAnimation();
					break;
			}
			return animation;
		}
	}
	#endregion
}
