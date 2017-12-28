using System;
using System.Net;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;

namespace IHIS.OCSO
{
	#region HoSilBox (ｺｴｽﾇﾀｻ Displayﾇﾏｴﾂ PictureBox
	/// <summary>
	/// HoSilBoxｿ｡ ｴ・ﾑ ｿ萓・ｼｳｸ暲ﾔｴﾏｴﾙ.
	/// </summary>
	internal class HoSilBox : System.Windows.Forms.PictureBox
	{
		#region ｱﾗｸｮｱ・ｰ・ﾃ Fields
		const int BORDER_MARGIN = 3;
		const int TITLE_HEIGHT = 24;
		private Font titleFont = new Font("MS UI Gothic", 12.0f, FontStyle.Bold);
		private SolidBrush borderStatus1Brush = new SolidBrush(Color.FromArgb(160,197,216));
		private SolidBrush borderStatus2Brush = new SolidBrush(Color.FromArgb(196,217,161));
		private SolidBrush backStatus1Brush = new SolidBrush(Color.FromArgb(50,127,207));
		private SolidBrush backStatus2Brush = new SolidBrush(Color.FromArgb(53,156,39));
		private Pen        borderPen   = new Pen(Color.FromArgb(157,174,130));
		private Pen        whitePen   = new Pen(Color.White);
		private Brush	   textBrush  = new SolidBrush(Color.White);
		#endregion

		#region Fields having Property
		private string title = "";
		private HoSilStatus hStatus = HoSilStatus.State1;
		#endregion

		#region base Property
		[Browsable(false),
		DefaultValue(typeof(Color),"Transparent")]
		public new Color BackColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		#endregion

		#region Properties
		[DefaultValue(""),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ﾈ｣ｽﾇﾀﾇ Titleﾀｻ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public string Title
		{
			get { return title;}
			set 
			{
				if (title != value)
				{
					title = value;
					Invalidate(true);
				}
			}
		}
		[DefaultValue(HoSilStatus.State1),Category("ﾃﾟｰ｡ｼﾓｼｺ"),
		Description("ﾈ｣ｽﾇﾀﾇ ｻﾂｸｦ ｼｳﾁ､ﾇﾕｴﾏｴﾙ.")]
		public HoSilStatus HStatus
		{
			get { return hStatus;}
			set 
			{
				if (hStatus != value)
				{
					hStatus = value;
					Invalidate(true);
				}
			}
		}
		#endregion

		//ｺｴｽﾇﾀｻ ｺｸｿｩﾁﾖｴﾂ Picture Box
		public HoSilBox()
		{
			this.BorderStyle = BorderStyle.None;
			this.BackColor = Color.Transparent;
		}

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			int width = this.Size.Width;
			int height = this.Size.Height;
			Rectangle rect = Rectangle.Empty;

			if ((width < BORDER_MARGIN) || (height < TITLE_HEIGHT)) return;

			try
			{
				Brush borderBrush, backBrush;
				//ﾈ｣ｽﾇｻﾂｿ｡ ｵ郞・Brush ｼｱﾅﾃ
				borderBrush = borderStatus1Brush;
				backBrush   = backStatus1Brush;
				switch (hStatus)
				{
					case HoSilStatus.State2:
						borderBrush = borderStatus2Brush;
						backBrush   = backStatus2Brush;
						break;
					case HoSilStatus.State3:
						borderBrush = borderStatus2Brush;
						backBrush   = backStatus2Brush;
						break;
				}
				//Border Draw
				rect = new Rectangle(0,0, width, height);
				e.Graphics.FillRectangle(borderBrush, rect);

				//ｾﾈﾂﾊ Line Draw, Gray
				rect = new Rectangle(BORDER_MARGIN, BORDER_MARGIN, width - BORDER_MARGIN*2 -1 , height - BORDER_MARGIN*2);
				e.Graphics.DrawRectangle(borderPen, rect);
				//ｾﾈﾂﾊ Line Whiete Draw
				rect = new Rectangle(BORDER_MARGIN + 1, BORDER_MARGIN + 1, width - (BORDER_MARGIN + 1)*2 -1 , height - (BORDER_MARGIN + 1)*2);
				e.Graphics.DrawRectangle(whitePen, rect);
				//Back Draw
				rect = new Rectangle(BORDER_MARGIN + 2, BORDER_MARGIN + 2, width - (BORDER_MARGIN + 2)*2 -1 , height - (BORDER_MARGIN + 2)*2);
				e.Graphics.FillRectangle(backBrush, rect);

				//Title Draw
				if (title != "")
				{
					rect = new Rectangle( BORDER_MARGIN + 2 , BORDER_MARGIN + 2, width - (BORDER_MARGIN + 2)*2 , TITLE_HEIGHT);
					SizeF fontSize = e.Graphics.MeasureString(title, titleFont);
					e.Graphics.DrawString(title, titleFont, textBrush, 
						DrawHelper.GetObjAlignment(ContentAlignment.MiddleCenter, rect.X, rect.Y, rect.Width, rect.Height, fontSize.Width, fontSize.Height));
				}
			}
			catch(Exception xe)
			{
				Debug.WriteLine("HosilBox::OnPaint error=" + xe.Message);
			}
		}
		#endregion
	}
	#endregion

	#region enum
	/// <summary>
	/// ﾈ｣ｽﾇﾀﾇ ｼｺｰﾝﾀｻ ｳｪﾅｸｳｻｴﾂ Enum(ﾇ邏ﾂ ﾀﾏｹﾝｽﾇ, ﾆｯｽﾇｹﾛｿ｡ ｾｽ)
	/// </summary>
	internal enum HoSilStatus
	{
		State1,  //ﾀﾏｹﾝｽﾇ
		State2,  //ﾆｯｽﾇ
		State3   //ｱ簀ｸ
	}
	#endregion
}
