using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace IHIS.Framework
{
	#region XTaskBarItem
	[ToolboxItem(false)]
	[DesignerAttribute(typeof(XTaskBarItemDesigner))]
	public class XTaskBarItem : Label
	{
		#region Fields
		/// <summary>
		/// System defined settings for the XTaskBarItem
		/// </summary>
		private XTaskBarSetting taskBarSetting;

		/// <summary>
		/// The Expando the XTaskBarItem belongs to
		/// </summary>
		private XExpando expando;

		/// <summary>
		/// The cached preferred width of the XTaskBarItem
		/// </summary>
		private int preferredWidth;
		
		/// <summary>
		/// The cached preferred height of the XTaskBarItem
		/// </summary>
		private int preferredHeight;

		/// <summary>
		/// The focus state of the XTaskBarItem
		/// </summary>
		private FocusStates focusState;

		/// <summary>
		/// The rectangle where the XTaskBarItems text is drawn
		/// </summary>
		private Rectangle textRect;
		#endregion	

		#region Base Property Override
		//기본값은 Top,Left,Rigth로 설정
		[DefaultValue(AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right)]
		public override AnchorStyles Anchor
		{
			get	{	return base.Anchor;}
			set	{	base.Anchor = value;}
		}
		[DefaultValue(typeof(Cursor), "Hand")]
		public override Cursor Cursor
		{
			get	{	return base.Cursor;}
			set	{	base.Cursor = value;}
		}
		/// <summary>
		/// The Image displayed by the XTaskBarItem
		/// </summary>
		[DefaultValue(null)]
		public new Image Image
		{
			get
			{
				return base.Image;
			}

			set
			{
				// make sure the image is 16x16
				if (value != null && (value.Width != 16 || value.Height != 16))
				{
					Bitmap bitmap = new Bitmap(value, 16, 16);

					base.Image = bitmap;
				}
				else
				{
					base.Image = value;
				}

				// invalidate the preferred size cache
				this.preferredWidth = -1;
				this.preferredHeight = -1;

				this.textRect.Width = 0;
				this.textRect.Height = 0;
			}
		}


		/// <summary>
		/// Gets or sets the ImageList that contains the images to 
		/// display in the XTaskBarItem
		/// </summary>
		public new ImageList ImageList
		{
			get
			{
				return base.ImageList;
			}

			set
			{
				// make sure the images inside the ImageList are 16x16
				if (value != null && (value.ImageSize.Width != 16 || value.ImageSize.Height != 16))
				{
					// make a copy of the imagelist and resize all the images
					ImageList imageList = new ImageList();
					imageList.ColorDepth = value.ColorDepth;
					imageList.TransparentColor = value.TransparentColor;
					imageList.ImageSize = new Size(16, 16);

					foreach (Image image in value.Images)
					{
						Bitmap bitmap = new Bitmap(image, 16, 16);

						imageList.Images.Add(bitmap);
					}

					base.ImageList = imageList;
				}
				else
				{
					base.ImageList = value;
				}

				// invalidate the preferred size cache
				this.preferredWidth = -1;
				this.preferredHeight = -1;

				this.textRect.Width = 0;
				this.textRect.Height = 0;
			}
		}


		/// <summary>
		/// Gets or sets the index value of the image displayed on the XTaskBarItem
		/// </summary>
		public new int ImageIndex
		{
			get
			{
				return base.ImageIndex;
			}

			set
			{
				base.ImageIndex = value;

				// invalidate the preferred size cache
				this.preferredWidth = -1;
				this.preferredHeight = -1;

				this.textRect.Width = 0;
				this.textRect.Height = 0;
			}
		}
		#endregion
		
		#region Constructor
		public XTaskBarItem() : base()
		{
			// set control styles
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.Selectable, true);

			// get the system theme settings
			this.taskBarSetting = XTaskBarUtil.GetTaskBarSetting();

			// preferred size
			this.preferredWidth = -1;
			this.preferredHeight = -1;

			// unfocused item
			this.focusState = FocusStates.None;

			this.Cursor = Cursors.Hand;

			this.textRect = new Rectangle();

			// 폰트 수정
            this.Font = new Font("MS UI Gothic", 9.75f);
		}

		#endregion

		#region Properties

		#region Colors
		internal Color LinkColor
		{
			get	{ return this.taskBarSetting.TaskLink.LinkColor;}
		}
		internal Color LinkHotColor
		{
			get	{ return this.taskBarSetting.TaskLink.HotLinkColor;}
		}
		internal Color DisabledColor
		{
			get
			{
				if (this.BackColor.A != 0)
				{
					return this.BackColor;
				}

				Color c = this.BackColor;

				for (Control control = this.Parent; (c.A == 0); control = control.Parent)
				{
					if (control == null)
					{
						return SystemColors.Control;
					}

					c = control.BackColor;
				}

				return c;
			}
		}
		/// <summary>
		/// The current color of the XTaskBarItems text
		/// </summary>
		internal Color FocusLinkColor
		{
			get
			{
				if (this.FocusState == FocusStates.Mouse)
				{
					return this.LinkHotColor;
				}

				return this.LinkColor;
			}
		}

		#endregion

		#region Expando

		/// <summary>
		/// The Expando the XTaskBarItem belongs to
		/// </summary>
		[Browsable(false)]
		public XExpando Expando
		{
			get	{ return this.expando;}
			set	{ this.expando = value;}
		}
		#endregion

		#region FlatStyle
	
		/// <summary>
		/// Overrides FlatStyle (Set 기능 없음)
		/// </summary>
		public new FlatStyle FlatStyle
		{
			get	{ return base.FlatStyle;}
			set	{}
		}

		#endregion

		#region Fonts
		/// <summary>
		/// The decoration to be used on the text when the XTaskBarItem is 
		/// in a highlighted state 
		/// </summary>
		internal FontStyle FontDecoration
		{
			get	{ return this.taskBarSetting.TaskLink.FontDecoration;}
		}


		/// <summary>
		/// Gets or sets the font of the text displayed by the XTaskBarItem
		/// </summary>
		[Browsable(true),
		 Description("이 컨트롤의 폰트 속성을 지정합니다."),
        DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get
			{
				if (this.FocusState == FocusStates.Mouse)
				{
					return new Font(base.Font.Name, base.Font.SizeInPoints, this.FontDecoration);
				}
				
				return base.Font;
			}

			set
			{
				base.Font = value;
			}
		}


		#endregion

		#region Margins

		/// <summary>
		/// The amount of space between individual XTaskBarItems 
		/// along each side of the XTaskBarItem
		/// </summary>
        /// //<VS.2005> Control의 Margin과 중복됨, Margin -> BarMargin으로 변경
		internal XTaskBarMargin BarMargin
		{
            get { return this.taskBarSetting.TaskLink.BarMargin; }
		}

		#endregion

		#region Padding

		/// <summary>
		/// The amount of space around the text along each 
		/// side of the XTaskBarItem
		/// </summary>
        /// //<VS.2005> Control의 Padding과 중복됨, Padding -> BarPadding으로 변경
		internal XTaskBarPadding BarPadding
		{
            get { return this.taskBarSetting.TaskLink.BarPadding; }
		}

		#endregion

		#region Preferred Size

		/// <summary>
		/// Gets the preferred width of the XTaskBarItem.
		/// Assumes that the text is required to fit on a single line
		/// </summary>
		[Browsable(false)]
		public override int PreferredWidth
		{
			get
			{
				//
				if (this.preferredWidth != -1)
				{
					return this.preferredWidth;
				}

				//
				if (this.Text.Length == 0)
				{
					this.preferredWidth = 0;

					return 0;
				}

				//
				Graphics g = this.CreateGraphics();

				//
				StringFormat sf = this.GetStringFormatForAlignment(this.TextAlign);

				//
				SizeF size = g.MeasureString(this.Text, this.Font, new SizeF(0, 0), sf);

				//
				sf.Dispose();
				g.Dispose();

				//
				this.preferredWidth = (int) size.Width + 18 + this.BarPadding.Left + this.BarPadding.Right;

				return this.preferredWidth;
			}
		}


		/// <summary>
		/// Gets the preferred height of the XTaskBarItem.
		/// Assumes that the text is required to fit within the
		/// current width of the XTaskBarItem
		/// </summary>
		[Browsable(false)]
		public override int PreferredHeight
		{
			get
			{
				//
				if (this.preferredHeight != -1)
				{
					return this.preferredHeight;
				}

				//
				if (this.Text.Length == 0)
				{
					this.preferredHeight = 16;

					return 16;
				}

				//
				Graphics g = this.CreateGraphics();

				//
				StringFormat sf = this.GetStringFormatForAlignment(this.TextAlign);

				//
				int width = this.Width - this.BarPadding.Right;

				if (this.Image != null)
				{
					width -= 16 - this.BarPadding.Left;
				}

				//
				SizeF size = g.MeasureString(this.Text, this.Font, width, sf);

				//
				sf.Dispose();
				g.Dispose();

				//
				int textHeight = (int) size.Height;

				//
				if (textHeight > 16)
				{
					this.preferredHeight = textHeight;
				}
				else
				{
					this.preferredHeight = 16;
				}

				return this.preferredHeight;
			}
		}


		/// <summary>
		/// This member overrides Label.DefaultSize
		/// </summary>
		[Browsable(false)]
		protected override Size DefaultSize
		{
			get
			{
				return new Size(162, 16);
			}
		}


		/// <summary>
		/// 
		/// </summary>
		protected StringFormat GetStringFormatForAlignment(ContentAlignment alignment)
		{
			StringFormat sf = new StringFormat();

			// should the text be aligned to the left/center/right
			switch (alignment)
			{
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.TopLeft:
				case ContentAlignment.BottomLeft:	sf.Alignment = StringAlignment.Near;
					break;

				case ContentAlignment.MiddleCenter:
				case ContentAlignment.TopCenter:
				case ContentAlignment.BottomCenter:	sf.Alignment = StringAlignment.Center;
					break;

				case ContentAlignment.MiddleRight:
				case ContentAlignment.TopRight:
				case ContentAlignment.BottomRight:	sf.Alignment = StringAlignment.Far;
					break;
			}

			// should the text be aligned to the top/middle/bottom
			switch (alignment)
			{
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.MiddleRight:	sf.Alignment = StringAlignment.Center;
					break;

				case ContentAlignment.TopLeft:
				case ContentAlignment.TopCenter:
				case ContentAlignment.TopRight:		sf.Alignment = StringAlignment.Near;
					break;

				case ContentAlignment.BottomLeft:
				case ContentAlignment.BottomCenter:
				case ContentAlignment.BottomRight:	sf.Alignment = StringAlignment.Far;
					break;
			}

			sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;

			return sf;
		}

		#endregion

		#region State

		/// <summary>
		/// Specifies whether the XTaskBarItem is in a highlighted state.
		/// </summary>
		internal FocusStates FocusState
		{
			get	{ return this.focusState;}
			set
			{
				if (this.focusState != value)
				{
					this.focusState = value;
					this.Invalidate();
				}
			}
		}

		#endregion

		#region TaskBarSetting
		internal XTaskBarSetting TaskBarSetting
		{
			set
			{
				// make sure we have a new value
				if (this.taskBarSetting != value)
				{
					// get rid of the old settings
					this.taskBarSetting = null;
					// set the new settings
					this.taskBarSetting = value;
					this.Invalidate();
				}
			}
		}

		#endregion

		#region Text

		/// <summary>
		/// Gets or sets the text associated with this XTaskBarItem
		/// </summary>
		[Bindable(true)]
		public override string Text
		{
			get	{ return base.Text;}
			set
			{
				base.Text = value;

				// reset the preferred width and height
				this.preferredHeight = -1;
				this.preferredWidth = -1;

				if (this.Expando != null)
					this.Expando.DoLayout();
			}
		}


		#endregion

		#endregion

		#region Override EventInvoker
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);

			this.FocusState = FocusStates.Mouse;
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			this.FocusState = FocusStates.None;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint(e);
			
			// do we have an image to draw
			if (this.Image != null)
			{
				if (this.Enabled)
				{
					e.Graphics.DrawImage(this.Image, 0, 0, 16, 16);
				}
				else
				{
					ControlPaint.DrawImageDisabled(e.Graphics, this.Image, 0, 0, this.BackColor);
				}
			}

			// do we have any text to draw
			if (this.Text.Length > 0)
			{
				if (this.textRect.Width == 0 && this.textRect.Height == 0)
				{
					if (this.Image != null)
					{
						this.textRect.X = 16 + this.BarPadding.Left;
					}
					
					this.textRect.Y = 0;
					this.textRect.Width = this.Width - this.textRect.X - this.BarPadding.Right;
					this.textRect.Height = this.PreferredHeight;
				}
				
				if (this.Enabled)
				{
					using (SolidBrush brush = new SolidBrush(this.FocusLinkColor))
					{
						e.Graphics.DrawString(this.Text, this.Font, brush, this.textRect);
					}
				}
				else
				{
					// draw disable text the same way as a Label
					ControlPaint.DrawStringDisabled(e.Graphics, this.Text, this.Font, this.DisabledColor, (RectangleF) this.textRect, new StringFormat());
				}
			}
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			// invalidate the preferred size cache
			this.preferredWidth = -1;
			this.preferredHeight = -1;

			this.textRect.Width = 0;
			this.textRect.Height = 0;
		}
		#endregion
	}
	#endregion

	#region XTaskBarItemDesigner
	internal class XTaskBarItemDesigner : ControlDesigner
	{
		public XTaskBarItemDesigner()
		{
		}
		protected override void PreFilterProperties(IDictionary properties)
		{
			//필요없는 Property 제거
			base.PreFilterProperties(properties);
			properties.Remove("AutoSize");
			properties.Remove("BackColor");
			properties.Remove("BorderStyle");
			properties.Remove("ForeColor");
			properties.Remove("ImageAlign");
			properties.Remove("RightToLeft");
			properties.Remove("TextAlign");
			properties.Remove("UseMnemonic");
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("CausesValidation");
			properties.Remove("FlatStyle");
		}
	}
	#endregion
}
