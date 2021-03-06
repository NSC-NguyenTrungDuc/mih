using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Diagnostics;


namespace IHIS.Framework
{
	#region XTaskBarSetting Class
	internal class XTaskBarSetting : IDisposable
	{
		#region Fields
		/// <summary>
		/// ATaskBar settings
		/// </summary>
		private XTaskBarShape taskBar;
		/// <summary>
		/// ATaskItem settings
		/// </summary>
		private XTaskBarLinkShape taskLink;

		/// <summary>
		/// AExpando settings
		/// </summary>
		private XExpandoShape expando;
		/// <summary>
		/// AExpando header settings
		/// </summary>
		private XTaskBarHeaderShape header;
		#endregion

		#region Properties
		public XTaskBarShape TaskBar
		{
			get	{ return this.taskBar;}
		}
		public XTaskBarLinkShape TaskLink
		{
			get	{ return this.taskLink;}
		}
		public XExpandoShape Expando
		{
			get	{ return this.expando;}
		}
		public XTaskBarHeaderShape Header
		{
			get	{ return this.header;}
		}
		#endregion

		#region Constructor
		public XTaskBarSetting()
		{
			this.taskBar = new XTaskBarShape();
			this.taskLink = new XTaskBarLinkShape();
			this.expando = new XExpandoShape();
			this.header = new XTaskBarHeaderShape();
		}
		#endregion

		#region Methods
		public void SetUnthemedArrowImages()
		{
			// get the arrow images resource
			System.Reflection.Assembly myAssembly;
			myAssembly = this.GetType().Assembly;
			ResourceManager myManager = new ResourceManager("IHIS.Framework.XTaskBar.XExpandoArrows", myAssembly);
				
			// set the arrow images
			this.Header.SpecialArrowDown = new Bitmap((Image) myManager.GetObject("SPECIALGROUPEXPAND"));
			this.Header.SpecialArrowDownHot = new Bitmap((Image) myManager.GetObject("SPECIALGROUPEXPANDHOT"));
			this.Header.SpecialArrowUp = new Bitmap((Image) myManager.GetObject("SPECIALGROUPCOLLAPSE"));
			this.Header.SpecialArrowUpHot = new Bitmap((Image) myManager.GetObject("SPECIALGROUPCOLLAPSEHOT"));
				
			this.Header.NormalArrowDown = new Bitmap((Image) myManager.GetObject("NORMALGROUPEXPAND"));
			this.Header.NormalArrowDownHot = new Bitmap((Image) myManager.GetObject("NORMALGROUPEXPANDHOT"));
			this.Header.NormalArrowUp = new Bitmap((Image) myManager.GetObject("NORMALGROUPCOLLAPSE"));
			this.Header.NormalArrowUpHot = new Bitmap((Image) myManager.GetObject("NORMALGROUPCOLLAPSEHOT"));
		}
		/// <summary>
		/// Force use of default values
		/// </summary>
		public void UseClassicTheme()
		{
			this.TaskBar.SetDefaultValues();
			this.Expando.SetDefaultValues();
			this.Header.SetDefaultValues();
			this.TaskLink.SetDefaultValues();

			this.SetUnthemedArrowImages();
		}
		#endregion
		
		#region IDisposable Members
		public void Dispose()
		{
			this.taskBar.Dispose();
			this.header.Dispose();
		}
		#endregion
	}

	#endregion

	#region XTaskBarShape Class

	internal class XTaskBarShape : IDisposable
	{
		#region Fields
		// background gradient colors
		private Color gradientStartColor;
		private Color gradientEndColor;

		// background gradient direction
		private LinearGradientMode direction;

		// the amount of space between the border and the group panels
		private XTaskBarPadding padding;

		// the border around the ExplorerBar
		private XTaskBarBorder border;

		// the color of the border
		private Color borderColor;

		private Image backImage;

		private Image watermark;
		private ContentAlignment watermarkAlignment;
		#endregion
		
		#region Properties
		public Color GradientStartColor
		{
			get	{ return this.gradientStartColor;}
			set	{ this.gradientStartColor = value;}
		}
		public Color GradientEndColor
		{
			get	{ return this.gradientEndColor;}
			set	{ this.gradientEndColor = value;}
		}
		public LinearGradientMode GradientDirection
		{
			get	{ return this.direction;}
			set	{ this.direction = value;}
		}
		public XTaskBarBorder Border
		{
			get	{ return this.border;}
			set	{ this.border = value;}
		}
		public Color BorderColor
		{
			get	{ return this.borderColor;}
			set	{ this.borderColor = value;}
		}
		public Image BackImage
		{
			get	{ return this.backImage;}
			set	{ this.backImage = value;}
		}
		public Image Watermark
		{
			get	{ return this.watermark;}
			set	{ this.watermark = value;}
		}
		public ContentAlignment WatermarkAlignment
		{
			get	{ return this.watermarkAlignment;}
			set	{ this.watermarkAlignment = value;}
		}
		public XTaskBarPadding Padding
		{
			get	{ return this.padding;}
			set	{ this.padding = value;}
		}
		#endregion

		#region Constructor
		public XTaskBarShape()
		{
			// set background values
			this.gradientStartColor = Color.Transparent;
			this.gradientEndColor = Color.Transparent;
			this.direction = LinearGradientMode.Vertical;

			// set padding values
			this.padding = new XTaskBarPadding(12, 12, 12, 12);

			// set border values
			this.border = new XTaskBarBorder();
			this.borderColor = Color.Transparent;

			// images
			this.backImage = null;
			this.watermark = null;
			this.watermarkAlignment = ContentAlignment.BottomCenter;
		}
		#endregion

		#region Methods
		public void SetDefaultValues()
		{
			// set background values
			this.gradientStartColor = SystemColors.Window;
			this.gradientEndColor = SystemColors.Window;
			this.direction = LinearGradientMode.Vertical;

			// set padding values
			this.padding.Left = 12;
			this.padding.Top = 12;
			this.padding.Right = 12;
			this.padding.Bottom = 12;

			// set border values
			this.border = new XTaskBarBorder();
			this.borderColor = SystemColors.Window;

			// images
			this.backImage = null;
			this.watermark = null;
		}
		#endregion

		#region IDisposable Members

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			if (this.backImage != null)
			{
				this.backImage.Dispose();
				this.backImage = null;
			}

			if (this.watermark != null)
			{
				this.watermark.Dispose();
				this.watermark = null;
			}
		}

		#endregion

		
	}

	#endregion

	#region XTaskBarLinkShape Class

	internal class XTaskBarLinkShape
	{
		#region Fields
		private XTaskBarPadding padding; 
		private XTaskBarMargin margin;

		// the normal color of the text
		private Color linkNormal;

		//  color of the text when highlighted
		private Color linkHot;

		// the decoration of the text when highlightd
		private FontStyle fontDecoration;

		// should the text wrap
		private bool wrap; 
		#endregion

		#region Properties
        //<VS.2005> Control의 Margin과 중복됨, Margin -> BarMargin으로 변경
		public XTaskBarMargin BarMargin
		{
			get	{ return this.margin;}
			set	{ this.margin = value;}
		}
        //<VS.2005> Control의 Padding과 중복됨, Padding -> BarPadding으로 변경
		public XTaskBarPadding BarPadding
		{
			get	{ return this.padding;}
			set	{ this.padding = value;}
		}
		public Color LinkColor
		{
			get	{ return this.linkNormal;}
			set	{ this.linkNormal = value;}
		}
		public Color HotLinkColor
		{
			get	{ return this.linkHot;}
			set	{ this.linkHot = value;}
		}
		public FontStyle FontDecoration
		{
			get	{ return this.fontDecoration;}
			set	{ this.fontDecoration = value;}
		}
		public bool Wrap
		{
			get	{ return this.wrap;}
			set	{ this.wrap = value;}
		}
		#endregion

		#region Constructor
		public XTaskBarLinkShape()
		{
			// set padding values
			this.padding = new XTaskBarPadding(6, 0, 4, 0);

			// set margin values
			this.margin = new XTaskBarMargin(0, 4, 0, 0);

			// set text values
			this.linkNormal = SystemColors.ControlText;
			this.linkHot = SystemColors.ControlText;

			this.fontDecoration = FontStyle.Underline;

			this.wrap = false;
		}
		#endregion

		#region Methods
		public void SetDefaultValues()
		{
			// set padding values
			this.padding.Left = 6;
			this.padding.Top = 0;
			this.padding.Right = 4;
			this.padding.Bottom = 0;

			// set margin values
			this.margin.Left = 0;
			this.margin.Top = 4;
			this.margin.Right = 0;
			this.margin.Bottom = 0;

			// set text values
			this.linkNormal = SystemColors.ControlText;
			this.linkHot = SystemColors.HotTrack;

			this.fontDecoration = FontStyle.Underline;

			this.wrap = false;
		}
		#endregion
	}

	#endregion

	#region XExpandoShape Class
	internal class XExpandoShape
	{
		#region Fields
		// the expando's background color
		private Color specialBackColor;
		private Color normalBackColor;

		// the expando's border
		private XTaskBarBorder specialBorder;
		private XTaskBarBorder normalBorder;

		// the color of the border
		private Color specialBorderColor;
		private Color normalBorderColor;

		// the amount of space between the expando's border and
		// other objects.
		private XTaskBarPadding specialPadding;
		private XTaskBarPadding normalPadding;

		// the expando's watermark image
		//private Image watermark;
		private ContentAlignment watermarkAlignment;
		#endregion

		#region Properties
		public Color SpecialBackColor
		{
			get	{ return this.specialBackColor;	}
			set	{ this.specialBackColor = value;}
		}
		public Color NormalBackColor
		{
			get	{ return this.normalBackColor;}
			set	{ this.normalBackColor = value;}
		}
		public ContentAlignment WatermarkAlignment
		{
			get	{ return this.watermarkAlignment;}
			set	{ this.watermarkAlignment = value;}
		}
		public XTaskBarBorder SpecialBorder
		{
			get {return this.specialBorder;	}
			set	{ this.specialBorder = value;}
		}
		public XTaskBarBorder NormalBorder
		{
			get {return this.normalBorder;	}
			set	{ this.normalBorder = value;}
		}
		public Color SpecialBorderColor
		{
			get	{ return this.specialBorderColor;}
			set	{ this.specialBorderColor = value;}
		}
		public Color NormalBorderColor
		{
			get	{ return this.normalBorderColor;}
			set	{ this.normalBorderColor = value;}
		}
		public XTaskBarPadding SpecialPadding
		{
			get	{ return this.specialPadding;}
			set	{ this.specialPadding = value;}
		}
		public XTaskBarPadding NormalPadding
		{
			get	{ return this.normalPadding;}
			set	{ this.normalPadding = value;}
		}
		#endregion

		#region Constructor
		public XExpandoShape()
		{
			// set background color values
			this.specialBackColor = Color.Transparent;
			this.normalBackColor = Color.Transparent;

			// set border values
			this.specialBorder = new XTaskBarBorder(1, 0, 1, 1);
			this.specialBorderColor = Color.Transparent;

			this.normalBorder = new XTaskBarBorder(1, 0, 1, 1);
			this.normalBorderColor = Color.Transparent;

			// set padding values
			this.specialPadding = new XTaskBarPadding(12, 10, 12, 10);
			this.normalPadding = new XTaskBarPadding(12, 10, 12, 10);

			// set background image values
			this.watermarkAlignment = ContentAlignment.BottomRight;

            //<FOR_TEST>
            //Logs.WriteLog("XExpandoShape생성자 normalBackColor=" + normalBackColor.ToString());
		}

		#endregion

		#region Methods
		public void SetDefaultValues()
		{
			// set background color values
			this.specialBackColor = SystemColors.Window;
			this.normalBackColor = SystemColors.Window;

			// set border values
			this.specialBorder.Left = 1;
			this.specialBorder.Top = 0;
			this.specialBorder.Right = 1;
			this.specialBorder.Bottom = 1;

			this.specialBorderColor = SystemColors.Highlight;

			this.normalBorder.Left = 1;
			this.normalBorder.Top = 0;
			this.normalBorder.Right = 1;
			this.normalBorder.Bottom = 1;

			this.normalBorderColor = SystemColors.Control;

			// set padding values
			this.specialPadding.Left = 12;
			this.specialPadding.Top = 10;
			this.specialPadding.Right = 12;
			this.specialPadding.Bottom = 10;
			
			this.normalPadding.Left = 12;
			this.normalPadding.Top = 10;
			this.normalPadding.Right = 12;
			this.normalPadding.Bottom = 10;

			// set background image values
			this.watermarkAlignment = ContentAlignment.BottomRight;
            //<FOR_TEST>
            //Logs.WriteLog("XExpandoShape::SetDefaultValues normalBackColor=" + normalBackColor.ToString());
		}

		#endregion
	}
	#endregion

	#region XTaskBarHeaderShape Class

	internal class XTaskBarHeaderShape : IDisposable
	{
		#region Fields
		private Font titleFont;
		// the header's margin.
		// this is the same for both special and normal headers.
		// not sure what it does.
		private int margin;

		// background images for the header
		private Image specialBackImage;
		private Image normalBackImage;

		// the height and width of the background images
		private int backImageWidth;
		private int backImageHeight;

		// the color of the header's title text
		private Color specialTitle;
		private Color normalTitle;

		// the color of the header's title text when
		// the mouse is over the header
		private Color specialTitleHot;
		private Color normalTitleHot;

		// the alignment of the header's title text.
		private ContentAlignment specialAlignment;
		private ContentAlignment normalAlignment;

		// the amount of space between the header's border and
		// other objects (text, arrows, etc).
		private XTaskBarPadding specialPadding;
		private XTaskBarPadding normalPadding;

		// the border around the header.
		private XTaskBarBorder specialBorder;
		private XTaskBarBorder normalBorder;

		// the color of the header's border.
		private Color specialBorderColor;
		private Color normalBorderColor;

		//
		private Color specialBackColor;
		private Color normalBackColor;

		// the header's arrow images
		private Image specialArrowUp;
		private Image specialArrowUpHot;
		private Image specialArrowDown;
		private Image specialArrowDownHot;
		private Image normalArrowUp;
		private Image normalArrowUpHot;
		private Image normalArrowDown;
		private Image normalArrowDownHot;
		#endregion

		#region Properties
		public XTaskBarBorder SpecialBorder
		{
			get { return this.specialBorder;}
			set	{ this.specialBorder = value;}
		}
		public XTaskBarBorder NormalBorder
		{
			get { return this.normalBorder;}
			set	{ this.normalBorder = value;}
		}
		public Color SpecialBorderColor
		{
			get	{ return this.specialBorderColor;}
			set	{ this.specialBorderColor = value;}
		}
		public Color SpecialBackColor
		{
			get	{ return this.specialBackColor;}
			set	{ this.specialBackColor = value;}
		}
		public Color NormalBorderColor
		{
			get	{ return this.normalBorderColor;}
			set	{ this.normalBorderColor = value;}
		}
		public Color NormalBackColor
		{
			get	{ return this.normalBackColor;}
			set	{ this.normalBackColor = value;}
		}
		public Font TitleFont
		{
			get	{return this.titleFont;}
		}
		public string FontName
		{
			get	{ return this.TitleFont.Name;}
			set { this.titleFont = new Font(value, this.TitleFont.SizeInPoints, this.TitleFont.Style);}
		}

		public float FontSize
		{
			get	{ return this.TitleFont.SizeInPoints;}
			set	{ this.titleFont = new Font(this.TitleFont.Name, value, this.TitleFont.Style);}
		}
		public FontStyle FontWeight
		{
			get	{ return this.TitleFont.Style;}
			set	
			{ 
				value |= this.TitleFont.Style;
				this.titleFont = new Font(this.TitleFont.Name, this.TitleFont.SizeInPoints, value);
			}
		}
		public FontStyle FontStyle
		{
			get	{return this.TitleFont.Style;}
			set
			{
				value |= this.TitleFont.Style;
				this.titleFont = new Font(this.TitleFont.Name, this.TitleFont.SizeInPoints, value);
			}
		}
		public Image SpecialBackImage
		{
			get	{ return this.specialBackImage;}
			set
			{
				this.specialBackImage = value;
				if (value!= null)
				{
					this.backImageWidth = value.Width;
					this.backImageHeight = value.Height;
				}
			}
		}
		public Image NormalBackImage
		{
			get { return this.normalBackImage;}
			set
			{
				this.normalBackImage = value;

				if (value!= null)
				{
					this.backImageWidth = value.Width;
					this.backImageHeight = value.Height;
				}
			}
		}
		public int BackImageWidth
		{
			get
			{
				if (this.backImageWidth == -1)
					return 186;
				return this.backImageWidth;
			}
			set	{this.backImageWidth = value;}
		}
		public int BackImageHeight
		{
			get
			{
				if (this.backImageHeight < 23)
					return 23;
				return this.backImageHeight;
			}
			set	{this.backImageHeight = value;}
		}
		public Image SpecialArrowUp
		{
			get	{ return this.specialArrowUp;}
			set	{ this.specialArrowUp = value;}
		}
		public Image SpecialArrowUpHot
		{
			get	{ return this.specialArrowUpHot;}
			set	{ this.specialArrowUpHot = value;}
		}
		public Image SpecialArrowDown
		{
			get	{ return this.specialArrowDown;}
			set	{ this.specialArrowDown = value;}
		}
		public Image SpecialArrowDownHot
		{
			get	{ return this.specialArrowDownHot;}
			set	{ this.specialArrowDownHot = value;}
		}
		public Image NormalArrowUp
		{
			get	{ return this.normalArrowUp;}
			set	{ this.normalArrowUp = value;}
		}
		public Image NormalArrowUpHot
		{
			get	{ return this.normalArrowUpHot;}
			set	{ this.normalArrowUpHot = value;}
		}
		public Image NormalArrowDown
		{
			get	{ return this.normalArrowDown;}
			set	{ this.normalArrowDown = value;}
		}
		public Image NormalArrowDownHot
		{
			get	{ return this.normalArrowDownHot;}
			set	{ this.normalArrowDownHot = value;}
		}
		public int Margin
		{
			get	{ return this.margin;}
			set	{ this.margin = value;}
		}
		public XTaskBarPadding SpecialPadding
		{
			get	{ return this.specialPadding;}
			set	{ this.specialPadding = value;}
		}
		public XTaskBarPadding NormalPadding
		{
			get	{ return this.normalPadding;}
			set	{ this.normalPadding = value;}
		}
		public Color SpecialTitleColor
		{
			get	{ return this.specialTitle;}
			set
			{
				this.specialTitle = value;

				// set the SpecialTitleHotColor as well just in case
				// it isn't/wasn't set during UIFILE parsing
				if (this.SpecialTitleHotColor == Color.Transparent)
				{
					this.SpecialTitleHotColor = value;
				}
			}
		}
		public Color SpecialTitleHotColor
		{
			get	{ return this.specialTitleHot;}
			set	{ this.specialTitleHot = value;}
		}
		public Color NormalTitleColor
		{
			get	{return this.normalTitle;}
			set
			{
				this.normalTitle = value;

				// set the NormalTitleHotColor as well just in case
				// it isn't/wasn't set during UIFILE parsing
				if (this.NormalTitleHotColor == Color.Transparent)
				{
					this.NormalTitleHotColor = value;
				}
			}
		}
		public Color NormalTitleHotColor
		{
			get { return this.normalTitleHot;}
			set	{ this.normalTitleHot = value;}
		}
		public ContentAlignment SpecialAlignment
		{
			get	{ return this.specialAlignment;	}
			set	{ this.specialAlignment = value;}
		}
		public ContentAlignment NormalAlignment
		{
			get	{ return this.normalAlignment;	}
			set	{ this.normalAlignment = value;}
		}
		#endregion

		#region Constructor
		public XTaskBarHeaderShape()
		{
			this.titleFont = XTaskBarUtil.ExpandoTitleFont;

			this.margin = 15;

			// set title colors and alignment
			this.specialTitle = Color.Transparent;
			this.specialTitleHot = Color.Transparent;
			
			this.normalTitle = Color.Transparent;
			this.normalTitleHot = Color.Transparent;
			
			this.specialAlignment = ContentAlignment.MiddleLeft;
			this.normalAlignment = ContentAlignment.MiddleLeft;

			// set padding values
			this.specialPadding = new XTaskBarPadding(10, 0, 1, 0);
			this.normalPadding = new XTaskBarPadding(10, 0, 1, 0);

			// set border values
			this.specialBorder = new XTaskBarBorder(2, 2, 2, 0);
			this.specialBorderColor = Color.Transparent;

			this.normalBorder = new XTaskBarBorder(2, 2, 2, 0);
			this.normalBorderColor = Color.Transparent;
			
			this.specialBackColor = Color.Transparent;
			this.normalBackColor = Color.Transparent;

			// set background image values
			this.specialBackImage = null;
			this.normalBackImage = null;

			this.backImageWidth = -1;
			this.backImageHeight = -1;

			// set arrow values
			this.specialArrowUp = null;
			this.specialArrowUpHot = null;
			this.specialArrowDown = null;
			this.specialArrowDownHot = null;

			this.normalArrowUp = null;
			this.normalArrowUpHot = null;
			this.normalArrowDown = null;
			this.normalArrowDownHot = null;

            //<FOR_TEST>
            //Logs.WriteLog("XTaskBarHeaderShape::생성자 normalTitle=" + this.normalTitle.ToString());
		}

		#endregion

		#region Methods
		/// <summary>
		/// 
		/// </summary>
		public void SetDefaultValues()
		{
			this.titleFont = XTaskBarUtil.ExpandoTitleFont;

			this.margin = 15;

			// set title colors and alignment
			this.specialTitle = SystemColors.HighlightText;
			this.specialTitleHot = SystemColors.HighlightText;
			
			this.normalTitle = SystemColors.ControlText;
			this.normalTitleHot = SystemColors.ControlText;
			
			this.specialAlignment = ContentAlignment.MiddleLeft;
			this.normalAlignment = ContentAlignment.MiddleLeft;

			// set padding values
			this.specialPadding.Left = 10;
			this.specialPadding.Top = 0;
			this.specialPadding.Right = 1;
			this.specialPadding.Bottom = 0;

			this.normalPadding.Left = 10;
			this.normalPadding.Top = 0;
			this.normalPadding.Right = 1;
			this.normalPadding.Bottom = 0;

			// set border values
			this.specialBorder.Left = 2;
			this.specialBorder.Top = 2;
			this.specialBorder.Right = 2;
			this.specialBorder.Bottom = 0;

			this.specialBorderColor = SystemColors.Highlight;

			this.normalBorder.Left = 2;
			this.normalBorder.Top = 2;
			this.normalBorder.Right = 2;
			this.normalBorder.Bottom = 0;

			this.normalBorderColor = SystemColors.Control;

			// set background image values
			this.specialBackImage = null;
			this.normalBackImage = null;

			this.backImageWidth = 186;
			this.backImageHeight = 25;

			// set arrow values
			this.specialArrowUp = null;
			this.specialArrowUpHot = null;
			this.specialArrowDown = null;
			this.specialArrowDownHot = null;

			this.normalArrowUp = null;
			this.normalArrowUpHot = null;
			this.normalArrowDown = null;
			this.normalArrowDownHot = null;
            //<FOR_TEST>
            //Logs.WriteLog("XTaskBarHeaderShape::SetDefaultValues normalTitle=" + this.normalTitle.ToString());
		}

		#endregion

		#region IDisposable Members
		public void Dispose()
		{
			if (this.specialBackImage != null)
			{
				this.specialBackImage.Dispose();
				this.specialBackImage = null;
			}

			if (this.normalBackImage != null)
			{
				this.normalBackImage.Dispose();
				this.normalBackImage = null;
			}


			if (this.specialArrowUp != null)
			{
				this.specialArrowUp.Dispose();
				this.specialArrowUp = null;
			}

			if (this.specialArrowUpHot != null)
			{
				this.specialArrowUpHot.Dispose();
				this.specialArrowUpHot = null;
			}

			if (this.specialArrowDown != null)
			{
				this.specialArrowDown.Dispose();
				this.specialArrowDown = null;
			}

			if (this.specialArrowDownHot != null)
			{
				this.specialArrowDownHot.Dispose();
				this.specialArrowDownHot = null;
			}
			
			if (this.normalArrowUp != null)
			{
				this.normalArrowUp.Dispose();
				this.normalArrowUp = null;
			}

			if (this.normalArrowUpHot != null)
			{
				this.normalArrowUpHot.Dispose();
				this.normalArrowUpHot = null;
			}

			if (this.normalArrowDown != null)
			{
				this.normalArrowDown.Dispose();
				this.normalArrowDown = null;
			}

			if (this.normalArrowDownHot != null)
			{
				this.normalArrowDownHot.Dispose();
				this.normalArrowDownHot = null;
			}
		}
		#endregion
	}

	#endregion

	#region XTaskBarBorder Class
	internal class XTaskBarBorder
	{
		#region Fields
		private int left;
		private int right;
		private int top;
		private int bottom;
		#endregion

		#region Properties
		public int Left
		{
			get { return this.left;}
			set	{ this.left = Math.Max(0, value);}
		}
		public int Right
		{
			get { return this.right;}
			set	{ this.right = Math.Max(0, value);}
		}
		public int Top
		{
			get { return this.top;}
			set	{ this.top = Math.Max(0, value);}
		}
		public int Bottom
		{
			get { return this.bottom;}
			set	{ this.bottom = Math.Max(0, value);}
		}
		#endregion

		
		#region 생성자
		public XTaskBarBorder()
		{
			this.left = 0;
			this.right = 0;
			this.top = 0;
			this.bottom = 0;
		}
		public XTaskBarBorder(int left, int top, int right, int bottom)
		{
			this.left = Math.Max(0,left);
			this.right = Math.Max(0,right);
			this.top = Math.Max(0,top);
			this.bottom = Math.Max(0,bottom);
		}
		#endregion
	}
	#endregion

	#region XTaskBarPadding Class
	internal class XTaskBarPadding
	{
		#region Fields
		private int left;
		private int right;
		private int top;
		private int bottom;
		#endregion

		#region Properties
		public int Left
		{
			get { return this.left;}
			set	{ this.left = Math.Max(0, value);}
		}
		public int Right
		{
			get { return this.right;}
			set	{ this.right = Math.Max(0, value);}
		}
		public int Top
		{
			get { return this.top;}
			set	{ this.top = Math.Max(0, value);}
		}
		public int Bottom
		{
			get { return this.bottom;}
			set	{ this.bottom = Math.Max(0, value);}
		}
		#endregion

		
		#region 생성자
		public XTaskBarPadding()
		{
			this.left = 0;
			this.right = 0;
			this.top = 0;
			this.bottom = 0;
		}
		public XTaskBarPadding(int left, int top, int right, int bottom)
		{
			this.left = Math.Max(0,left);
			this.right = Math.Max(0,right);
			this.top = Math.Max(0,top);
			this.bottom = Math.Max(0,bottom);
		}
		#endregion
	}
	#endregion

	#region XTaskBarMargin Class
	internal class XTaskBarMargin
	{
		#region Fields
		private int left;
		private int right;
		private int top;
		private int bottom;
		#endregion

		#region Properties
		public int Left
		{
			get { return this.left;}
			set	{ this.left = Math.Max(0, value);}
		}
		public int Right
		{
			get { return this.right;}
			set	{ this.right = Math.Max(0, value);}
		}
		public int Top
		{
			get { return this.top;}
			set	{ this.top = Math.Max(0, value);}
		}
		public int Bottom
		{
			get { return this.bottom;}
			set	{ this.bottom = Math.Max(0, value);}
		}
		#endregion

		
		#region 생성자
		public XTaskBarMargin()
		{
			this.left = 0;
			this.right = 0;
			this.top = 0;
			this.bottom = 0;
		}
		public XTaskBarMargin(int left, int top, int right, int bottom)
		{
			this.left = Math.Max(0,left);
			this.right = Math.Max(0,right);
			this.top = Math.Max(0,top);
			this.bottom = Math.Max(0,bottom);
		}
		#endregion
	}
	#endregion
}
