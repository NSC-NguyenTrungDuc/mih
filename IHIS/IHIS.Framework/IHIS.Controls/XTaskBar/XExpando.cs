using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace IHIS.Framework
{
	#region XExpando
	/// <summary>
	/// Summary description for XExpando.
	/// </summary>
	[ToolboxItem(false)]
	[DesignerAttribute(typeof(XExpandoDesigner))]
	public class XExpando : Control, ISupportInitialize
	{
		#region Fields
		private Container components = null;

		/// <summary>
		/// System settings for the XExpando
		/// </summary>
		private XTaskBarSetting taskBarSetting;

		/// <summary>
		/// Is the XExpando a special group (IsSpecialGroup이면 강조됨)
		/// </summary>
		private bool isSpecialGroup = false;

		/// <summary>
		/// The height of the XExpando in its expanded state
		/// </summary>
		private int expandedHeight;

		/// <summary>
		/// The image displayed on the left side of the titlebar
		/// </summary>
		private Image titleImage = null;

		/// <summary>
		/// WaterMark Image
		/// </summary>
		private Image waterMarkImage = null;

		/// <summary>
		/// The height of the header section 
		/// (includes titlebar and title image)
		/// </summary>
		private int headerHeight;

		/// <summary>
		/// Is the XExpando collapsed
		/// </summary>
		private bool collapsed;

		/// <summary>
		/// The state of the titlebar
		/// </summary>
		private FocusStates focusState;

		/// <summary>
		/// The height of the titlebar
		/// </summary>
		private int titleBarHeight;

		/// <summary>
		/// Are we currently animating a fade
		/// </summary>
		private bool animatingFade;

		/// <summary>
		/// Are we currently animating a slide
		/// </summary>
		private bool animatingSlide;

		/// <summary>
		/// An image of the "client area" which is used 
		/// during a fade animation
		/// </summary>
		private Image animationImage;

		/// <summary>
		/// The ATaskBar the XExpando belongs to
		/// </summary>
		private XTaskBar taskBar;

		/// <summary>
		/// Should the XExpando layout its items itself
		/// </summary>
		private bool autoLayout = false;

		/// <summary>
		/// The last known width of the XExpando 
		/// (used while animating)
		/// </summary>
		private int oldWidth = 0;

		/// <summary>
		/// Internal list of items contained in the XExpando
		/// </summary>
		private XTaskBarItemCollection itemList;

		/// <summary>
		/// Internal list of controls that have been hidden
		/// </summary>
		private ArrayList hiddenControls;

		/// <summary>
		/// A panel we can move our controls onto when we are 
		/// animating from collapsed to expanded.
		/// </summary>
		internal AnimationPanel dummyPanel;

		/// <summary>
		/// Is the XExpando allowed to collapse
		/// </summary>
		private bool canCollapse;

		/// <summary>
		/// The height of the XExpando at the end of its slide animation
		/// </summary>
		private int slideEndHeight;
		
		//Title의 Font
		private Font titleFont = null;

		//초기화 여부
		private bool initializing = false;
		#endregion

		#region Base Property Override
		//기본값은 Top,Left,Rigth로 설정
		[DefaultValue(AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right)]
		public override AnchorStyles Anchor
		{
			get	{	return base.Anchor;}
			set	{	base.Anchor = value;}
		}
		#endregion

		#region Properties

		#region Alignment
		/// <summary>
		/// The alignment of the text in the title bar.
		/// </summary>
		protected ContentAlignment TitleAlignment
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					return this.taskBarSetting.Header.SpecialAlignment;
				}
				
				return this.taskBarSetting.Header.NormalAlignment;
			}
		}
		#endregion

		#region Animation
		/// <summary>
		/// Gets whether the XExpando is currently animating
		/// </summary>
		[Browsable(false)]
		public bool Animating
		{
			get	{ return (this.animatingFade || this.animatingSlide);}
		}
		/// <summary>
		/// Gets the Image used by the XExpando while it is animating
		/// </summary>
		protected Image AnimationImage
		{
			get	{ return this.animationImage;}
		}
		#endregion

		#region Border
		/// <summary>
		/// The width of the border along each side of the XExpando's pane.
		/// </summary>
		internal XTaskBarBorder Border
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					return this.taskBarSetting.Expando.SpecialBorder;
				}
				
				return this.taskBarSetting.Expando.NormalBorder;
			}
		}
		/// <summary>
		/// The color of the border along each side of the XExpando's pane.
		/// </summary>
		internal Color BorderColor
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					return this.taskBarSetting.Expando.SpecialBorderColor;
				}
				
				return this.taskBarSetting.Expando.NormalBorderColor;
			}
		}
		/// <summary>
		/// The width of the border along each side of the XExpando's Title Bar.
		/// </summary>
		internal XTaskBarBorder TitleBorder
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					return this.taskBarSetting.Header.SpecialBorder;
				}
				
				return this.taskBarSetting.Header.NormalBorder;
			}
		}
		#endregion

		#region Color
		/// <summary>
		/// Gets the backgroubd color of the titlebar
		/// </summary>
		internal Color TitleBackColor
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					if (this.taskBarSetting.Header.SpecialBackColor != Color.Transparent)
					{
						return this.taskBarSetting.Header.SpecialBackColor;
					}
					
					return this.taskBarSetting.Header.SpecialBorderColor;
				}

				if (this.taskBarSetting.Header.NormalBackColor != Color.Transparent)
				{
					return this.taskBarSetting.Header.NormalBackColor;
				}
					
				return this.taskBarSetting.Header.NormalBorderColor;
			}
		}
		#endregion

		#region Client Rectangle
		/// <summary>
		/// Returns a fake Client Rectangle.  
		/// The rectangle takes into account the size of the titlebar 
		/// and borders (these are actually parts of the real 
		/// ClientRectangle)
		/// </summary>
		internal Rectangle PseudoClientRect
		{
			get
			{
				return new Rectangle(this.Border.Left, 
					this.HeaderHeight + this.Border.Top,
					this.Width - this.Border.Left - this.Border.Right,
					this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
			}
		}


		/// <summary>
		/// Returns the height of the fake client rectangle
		/// </summary>
		internal int PseudoClientHeight
		{	
			get	{return this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom;}
		}
		#endregion

		#region Display Rectangle
		/// <summary>
		/// Overrides DisplayRectangle so that docked controls
		/// don't cover the titlebar or borders
		/// </summary>
		[Browsable(false)]
		public override Rectangle DisplayRectangle
		{
			get
			{
				return new Rectangle(this.Border.Left, 
					this.HeaderHeight + this.Border.Top,
					this.Width - this.Border.Left - this.Border.Right,
					this.ExpandedHeight - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
			}
		}
		/// <summary>
		/// Gets a rectangle that contains the titlebar area
		/// </summary>
		[Browsable(false)]
		public Rectangle TitleBarRectangle
		{
			get
			{
				return new Rectangle(0,
					this.HeaderHeight - this.TitleBarHeight,
					this.Width,
					this.TitleBarHeight);
			}
		}
		#endregion

		#region Title
		[Bindable(true), 
		Category("追加プロパティ"),
		Description("타이틀의 Font를 가져오거나 설정합니다."),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt, style=Bold")]
		public Font TitleFont
		{
			get { return this.titleFont;}
			set 
			{
				if (this.titleFont != value)
				{
					try
					{
						this.titleFont = value;
						Graphics g = this.CreateGraphics();
						SizeF fSize = g.MeasureString("A", value);
						int height = (int) (fSize.Height + 8.3f);
						if (height >= 23)  //Title의 최소높이는 23
							this.titleBarHeight = height;
						else
							this.titleBarHeight = 23;
						g.Dispose();
						//높이조정에 따른 Layout 변경
						this.DoLayout();

						this.Invalidate(true);
					}
					catch{}
				}
			}
		}
		//기본Font와 동일하면 Serialize하지 않음
		private bool ShouldSerializeTitleFont()
		{
			if (!this.titleFont.Equals(XTaskBarUtil.ExpandoTitleFont))
				return true;
			else
				return false;
		}
		//기본값은 기본 TitleFont로 설정
		private void ResetTitleFont()
		{
			this.titleFont = XTaskBarUtil.ExpandoTitleFont;
		}

		/// <summary>
		/// The color of the Title Bar's text.
		/// </summary>
		internal Color TitleForeColor
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					return this.taskBarSetting.Header.SpecialTitleColor;
				}
				
				return this.taskBarSetting.Header.NormalTitleColor;
			}
		}


		/// <summary>
		/// The color of the Title Bar's text when highlighted.
		/// </summary>
		internal Color TitleHotForeColor
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					return this.taskBarSetting.Header.SpecialTitleHotColor;
				}
				
				return this.taskBarSetting.Header.NormalTitleHotColor;
			}
		}
		/// <summary>
		/// Gets the current color of the Title Bar's text, depending 
		/// on the current state of the XExpando
		/// </summary>
		internal Color TitleColor
		{
			get
			{
				if (this.FocusState == FocusStates.Mouse)
				{
					return this.TitleHotForeColor;
				}

				return this.TitleForeColor;
			}
		}
		/// <summary>
		/// The font used to render the Title Bar's text.
		/// </summary>
//		internal Font TitleFont
//		{
//			get
//			{
//				return this.taskBarSetting.Header.TitleFont;
//			}
//		}
		#endregion		

		#region Images

		/// <summary>
		/// Gets the expand/collapse arrow image currently displayed 
		/// in the title bar, depending on the current state of the XExpando
		/// </summary>
		internal Image ArrowImage
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					if (this.collapsed)
					{
						if (this.FocusState == FocusStates.None)
						{
							return this.taskBarSetting.Header.SpecialArrowDown;
						}
						else
						{
							return this.taskBarSetting.Header.SpecialArrowDownHot;
						}
					}
					else
					{
						if (this.FocusState == FocusStates.None)
						{
							return this.taskBarSetting.Header.SpecialArrowUp;
						}
						else
						{
							return this.taskBarSetting.Header.SpecialArrowUpHot;
						}
					}
				}
				else
				{
					if (this.collapsed)
					{
						if (this.FocusState == FocusStates.None)
						{
							return this.taskBarSetting.Header.NormalArrowDown;
						}
						else
						{
							return this.taskBarSetting.Header.NormalArrowDownHot;
						}
					}
					else
					{
						if (this.FocusState == FocusStates.None)
						{
							return this.taskBarSetting.Header.NormalArrowUp;
						}
						else
						{
							return this.taskBarSetting.Header.NormalArrowUpHot;
						}
					}
				}
			}
		}


		/// <summary>
		/// Gets the width of the expand/collapse arrow image 
		/// currently displayed in the title bar
		/// </summary>
		internal int ArrowImageWidth
		{
			get
			{
				if (this.ArrowImage == null)
				{
					return 0;
				}

				return this.ArrowImage.Width;
			}
		}


		/// <summary>
		/// Gets the height of the expand/collapse arrow image 
		/// currently displayed in the title bar
		/// </summary>
		internal int ArrowImageHeight
		{
			get
			{
				if (this.ArrowImage == null)
				{
					return 0;
				}
			
				return this.ArrowImage.Height;
			}
		}


		/// <summary>
		/// The background image used for the Title Bar.
		/// </summary>
		internal Image TitleBackImage
		{
			get
			{
				if (this.IsSpecialGroup)
				{
					return this.taskBarSetting.Header.SpecialBackImage;
				}
				
				return this.taskBarSetting.Header.NormalBackImage;
			}
		}


		/// <summary>
		/// Gets the height of the background image used for the Title Bar.
		/// </summary>
		internal int TitleBackImageHeight
		{
			get
			{
				return this.taskBarSetting.Header.BackImageHeight;
			}
		}


		/// <summary>
		/// 타이틀의 이미지를 가져오거나 설정합니다.
		/// </summary>
		[Bindable(true), 
		Category("追加プロパティ"),
		DefaultValue(null),
		Description("타이틀의 이미지를 가져오거나 설정합니다.")]
		public Image TitleImage
		{
			get	{ return this.titleImage;}
			set
			{
				if (this.titleImage != value)
				{
					this.titleImage = value;

					this.DoLayout();

					this.Invalidate();

					OnTitleImageChanged(new XExpandoEventArgs(this));
				}
			}
		}
		/// <summary>
		/// WaterMark의 이미지를 가져오거나 설정합니다.
		/// </summary>
		[Bindable(true), 
		Category("追加プロパティ"),
		DefaultValue(null),
		Description("WaterMark의 이미지를 가져오거나 설정합니다.")]
		public Image WaterMarkImage
		{
			get	{return this.waterMarkImage;}
			set
			{
				if (this.waterMarkImage != value)
				{
					this.waterMarkImage = value;

					this.Invalidate();
				}
			}
		}
		#endregion

		#region Items

		/// <summary>
		/// An XExpando.XTaskBarItemCollection representing the collection of 
		/// Controls contained within the XExpando
		/// </summary>
		[Category("追加プロパティ"),
		DefaultValue(null), 
		Description("Expand에 들어갈 컨트롤(XTaskBarItem)을 관리하는 컬렉션입니다."), 
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), 
		Editor(typeof(XTaskBarItemCollectionEditor), typeof(UITypeEditor))]
		public XExpando.XTaskBarItemCollection Items
		{
			get	{ return this.itemList;}
		}
		/// <summary>
		/// Controls Hide
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Control.ControlCollection Controls
		{
			get	{return base.Controls;}
		}
		#endregion

		#region Layout

		/// <summary>
		/// Expando가 자동으로 Items를 Layout할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Bindable(true),
		Category("追加プロパティ"),
		DefaultValue(false),
		Description("Expando가 자동으로 Items를 Layout할지 여부를 가져오거나 설정합니다.")]
		public bool AutoLayout
		{
			get	{ return this.autoLayout;}
			set	
			{
				if (this.autoLayout != value)
				{
					this.autoLayout = value;
					if (this.autoLayout)
						this.DoLayout();
				}
			}
		}
	
		/// <summary>
		/// Expando가 확장되었을때의 높이를 가져오거나 설정합니다.
		/// </summary>
		[Bindable(true),
		Category("追加プロパティ"),
		DefaultValue(100),
		Description("Expando가 확장되었을때의 높이를 가져오거나 설정합니다.")]
		public int ExpandedHeight
		{
			get	{ return this.expandedHeight;}
			set
			{
				this.expandedHeight = value;

				if (!this.collapsed && !this.Animating)
				{
					this.Height = this.expandedHeight;

					if (this.taskBar != null)
						this.taskBar.DoLayout();
				}
			}
		}
		/// <summary>
		/// The height of the header section of the XExpando
		/// </summary>
		[Browsable(false)]
		public int HeaderHeight
		{
			get	{ return this.headerHeight;}
		}
		/// <summary>
		/// The height of the titlebar
		/// </summary>
		[Browsable(false)]
		internal int TitleBarHeight
		{
			get	{ return this.titleBarHeight;}
		}
		#endregion

		#region Padding
		/// <summary>
		/// The amount of space between the border and items along 
		/// each side of the ExplorerBarGroup.
		/// </summary>
        /// <VS.2005> Control의 Padding과 중복됨, Padding -> BarPadding으로 변경
		internal XTaskBarPadding BarPadding
		{
			get
			{
				if (this.IsSpecialGroup)
					return this.taskBarSetting.Expando.SpecialPadding;
				return this.taskBarSetting.Expando.NormalPadding;
			}
		}
		/// <summary>
		/// The amount of space between the border and items along 
		/// each side of the Title Bar.
		/// </summary>
		internal XTaskBarPadding TitlePadding
		{
			get
			{
				if (this.IsSpecialGroup)
					return this.taskBarSetting.Header.SpecialPadding;
				return this.taskBarSetting.Header.NormalPadding;
			}
		}
		#endregion

		#region Size
		public new Size Size
		{
			get	{return base.Size;}
			set
			{
				if (!this.Size.Equals(value))
				{
					if (!this.Animating)
					{
						this.Width = value.Width;
						//Collapsed가 적용된 Expando는 ExpanedHeight를 Height로 조정하지 않음
						//개발자가 지정한 ExpandedHeight 그대로 적용
						if (!this.collapsed)
							this.ExpandedHeight = value.Height;
					}
				}
			}
		}

		#endregion

		#region Special Groups
		/// <summary>
		/// Expando가 Special Group인지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Bindable(true), 
		Category("追加プロパティ"),
		DefaultValue(false),
		Description("Expando가 Special Group인지 여부를 가져오거나 설정합니다.")]
		public bool IsSpecialGroup
		{
			get	{ return this.isSpecialGroup;}
			set
			{
				this.isSpecialGroup = value;

				this.DoLayout();

				if (this.isSpecialGroup)
				{
					this.BackColor = this.taskBarSetting.Expando.SpecialBackColor;
				}
				else
				{
					this.BackColor = this.taskBarSetting.Expando.NormalBackColor;
				}
				
				this.Invalidate();

				OnSpecialGroupChanged(new XExpandoEventArgs(this));
			}
		}
		#endregion

		#region State

		/// <summary>
		/// Expando가 축소될지여부를 가져오거나 설정합니다.
		/// </summary>
		[Bindable(true), 
		Category("追加プロパティ"),
		DefaultValue(false),
		Description("Expando가 축소될지여부를 가져오거나 설정합니다.")]
		public bool Collapsed
		{
			get	{ return this.collapsed;}
			set
			{
				if (this.collapsed != value)
				{
					// don't bother if we're not enabled
					if (!this.Enabled)
						return;
					
					// if we're supposed to collapse, check if we can
					if (value && !this.CanCollapse)
						return;
					
					this.collapsed = value;

					// if we don't have a taskBar or the taskBar can't 
					// animate then we'd better expand/collapse by ourself
					// 초기화시에는 TaskBar의 Animate에 관계없이 Collapse적용
					if (this.TaskBar == null || this.initializing || !this.TaskBar.Animate)
					{
						if (this.collapsed)
							this.Collapse();
						else
							this.Expand();
					}

					// let everyone know we've collapsed/expanded
					this.OnStateChanged(new XExpandoEventArgs(this));
				}
			}
		}
		/// <summary>
		/// Specifies whether the title bar is in a highlighted state.
		/// </summary>
		internal FocusStates FocusState
		{
			get	{ return this.focusState;}
			set
			{
				if (this.focusState != value)
				{
					this.focusState = value;

					this.InvalidateTitleBar();
				}
			}
		}
		/// <summary>
		/// Expando가 축소될 수 있는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Bindable(true), 
		Category("追加プロパティ"),
		DefaultValue(true),
		Description("Expando가 축소될 수 있는지 여부를 가져오거나 설정합니다.")]
		public bool CanCollapse
		{
			get	{ return this.canCollapse; }
			set	{ this.canCollapse = value;}
		}
		#endregion

		#region TaskBarSetting
		internal XTaskBarSetting TaskBarSetting
		{
			get { return this.taskBarSetting;}
			set
			{
				// make sure we have a new value
				if (this.taskBarSetting != value)
				{
					// get rid of the old settings
					if (this.taskBarSetting != null)
					{
						this.taskBarSetting.Dispose();
						this.taskBarSetting = null;
					}

					// set the new settings
					this.taskBarSetting = value;
				}

				if (this.IsSpecialGroup)
				{
					this.BackColor = this.taskBarSetting.Expando.SpecialBackColor;
				}
				else
				{
					this.BackColor = this.taskBarSetting.Expando.NormalBackColor;
				}
				// update the system settings for each XTaskBarItem
				for (int i=0; i<this.itemList.Count; i++)
				{
					Control control = (Control) this.itemList[i];

					if (control is XTaskBarItem)
					{
						((XTaskBarItem) control).TaskBarSetting = this.taskBarSetting;
					}
				}

				// if our parent is not an ATaskBar then re-layout the 
				// XExpando (don't need to do this if our parent is a 
				// ATaskBar as it will tell us when to do it)
				if (this.TaskBar == null)
				{
					this.DoLayout();
				}
			}
		}
		#endregion
		
		#region Text
		[Bindable(true), 
		Category("追加プロパティ"),
		DefaultValue(""),
		Description("Expando의 Text를 가져오거나 설정합니다.")]
		public override string Text
		{
			get	{ return base.Text;}
			set
			{
				if (base.Text != value)
				{
					base.Text = value;
					this.InvalidateTitleBar();
				}
			}
		}
		#endregion

		#region Visible
		/// <summary>
		/// Gets or sets a value indicating whether the XExpando is displayed
		/// </summary>
		public new bool Visible
		{
			get {	return base.Visible;}
			set
			{
				if (base.Visible != value)
				{
					base.Visible = value;

					if (this.TaskBar != null)
					{
						this.TaskBar.DoLayout();
					}
				}
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether the control can 
		/// respond to user interaction
		/// </summary>
		public new bool Enabled
		{
			get	{return base.Enabled;}
			set
			{
				if (base.Enabled != value && !this.Animating)
				{
					base.Enabled = value;
				}
			}
		}
		#endregion

		#region TaskBar
		[Browsable(false)]
		public XTaskBar TaskBar
		{
			get { return this.taskBar;}
			set 
			{
				if (this.taskBar != value)
				{
					this.taskBar = value;
					if (value != null)
						this.taskBarSetting = this.taskBar.TaskBarSetting;
				}
			}
		}
		#endregion

		#endregion

		#region Event
		/// <summary>
		/// Expando가 확장,축소될때 발생합니다.
		/// </summary>
		[Description("Expando가 확장,축소되었을때  발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event XExpandoEventHandler StateChanged;
		
		/// <summary>
		/// Title의 이미지가 바뀌었을때  발생합니다.
		/// </summary>
		[Description("Title의 이미지가 바뀌었을때  발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event XExpandoEventHandler TitleImageChanged;
		
		/// <summary>
		/// IsSpecialGroup 속성이 바뀌었을때 발생합니다.
		/// </summary>
		[Description("IsSpecialGroup 속성이 바뀌었을때 발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event XExpandoEventHandler SpecialGroupChanged;

		/// <summary>
		/// Expando의 Control이 추가되었을때  발생합니다.
		/// </summary>
		[Description("Expando의 Control이 추가되었을때  발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event ControlEventHandler ItemAdded;

		/// <summary>
		/// Expando의 Control이 제거되었을때  발생합니다.
		/// </summary>
		[Description("Expando의 Control이 제거되었을때  발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event ControlEventHandler ItemRemoved;

		#endregion	
		
		#region Constructor
		
		/// <summary>
		/// Initializes a new instance of the XExpando class with default settings
		/// </summary>
		public XExpando() : base()
		{
			// This call is required by the Windows.Forms Form Designer.
			this.components = new System.ComponentModel.Container();

			// set control styles
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.Selectable, true);

			// get the system theme settings
			this.taskBarSetting = XTaskBarUtil.GetTaskBarSetting();
			this.BackColor = this.taskBarSetting.Expando.NormalBackColor;
            //<FOR_TEST>
            //Logs.WriteLog("XExpando::생성자 Name=" + this.Name + ",BackColor=" + this.BackColor.ToString() + ",NormalBorder" + this.taskBarSetting.Expando.NormalBorderColor.ToString());
			// the height of the XExpando in the expanded state
			this.expandedHeight = 100;

			// size
			this.Size = new Size(this.taskBarSetting.Header.BackImageWidth, this.expandedHeight);
			this.titleBarHeight = this.taskBarSetting.Header.BackImageHeight;
			this.headerHeight = this.titleBarHeight;
			this.oldWidth = this.Width;

			//TitleFont Set
			this.titleFont = this.taskBarSetting.Header.TitleFont;

			// start expanded
			this.collapsed = false;
			
			// not a special group
			this.isSpecialGroup = false;

			// unfocused titlebar
			this.focusState = FocusStates.None;

			// no title image
			this.titleImage = null;
			this.waterMarkImage = null;

			// animation
			this.animatingFade = false;
			this.animatingSlide = false;
			this.animationImage = null;
			this.slideEndHeight = -1;

			// don't get the XExpando to layout its items itself
			this.autoLayout = false;

			// don't know which ATaskBar we belong to
			this.taskBar = null;

			// internal list of items
			this.itemList = new XTaskBarItemCollection(this);
			this.hiddenControls = new ArrayList();

			// initialise the dummyPanel
			this.dummyPanel = new AnimationPanel();
			this.dummyPanel.Size = this.Size;
			this.dummyPanel.Location = new Point(-1000, 0);

			this.canCollapse = true;

			// 2005/05/09 신종석 폰트 지정 추가
            this.TitleFont = new Font("MS UI Gothic", 9.75f, FontStyle.Bold);
			
		}

		#endregion

		#region Methods

		#region Animation

		#region Fade Collapse/Expand

		/// <summary>
		/// Collapses the group without any animation.  
		/// </summary>
		public void Collapse()
		{
			if (!this.Enabled)
			{
				return;
			}
			
			this.Height = this.headerHeight;
		}


		/// <summary>
		/// Expands the group without any animation.  
		/// </summary>
		public void Expand()
		{
			if (!this.Enabled)
			{
				return;
			}
			
			this.Height = this.expandedHeight;
		}


		/// <summary>
		/// Gets the XExpando ready to start its collapse/expand animation
		/// </summary>
		internal void StartFadeAnimation()
		{
			if (!this.Enabled)
			{
				return;
			}
			
			//
			this.animatingFade = true;

			//
			this.SuspendLayout();

			// get an image of the client area that we can
			// use for alpha-blending in our animation
			this.animationImage = this.GetFadeAnimationImage();

			// set each control invisible (otherwise they
			// appear to slide off the bottom of the group)
			foreach (Control control in this.Controls)
			{
				control.Visible = false;
			}

			// restart the layout engine
			this.ResumeLayout(false);
		}


		/// <summary>
		/// Updates the next "frame" of the animation
		/// </summary>
		internal void UpdateFadeAnimation(int animationStepNum, int numAnimationSteps)
		{
			if (!this.Enabled)
			{
				return;
			}
			
			// the percentage we need to adjust our height by
			// double step = (1 / (double) numAnimationSteps) * animationStepNum;
			// replacement by: Joel Holdsworth (joel@airwebreathe.org.uk)
			//                 Paolo Messina (ppescher@hotmail.com)
			//                 05/06/2004
			//                 v1.1
			double step = (1.0 - Math.Cos(Math.PI * (double) animationStepNum / (double) numAnimationSteps)) / 2.0;
			
			// set the height of the group
			if (this.collapsed)
			{
				this.Height = this.expandedHeight - (int) ((this.expandedHeight - this.headerHeight) * step);
			}
			else
			{
				this.Height = this.headerHeight + (int) ((this.expandedHeight - this.headerHeight) * step);
			}

			// draw the next frame
			this.Invalidate();
		}


		/// <summary>
		/// Gets the XExpando to stop its animation
		/// </summary>
		internal void StopFadeAnimation()
		{
			if (!this.Enabled)
			{
				return;
			}
			
			//
			this.animatingFade = false;

			//
			this.SuspendLayout();

			// get rid of the image used for the animation
			this.animationImage.Dispose();
			this.animationImage = null;

			// set the final height of the group, depending on
			// whether we are collapsed or expanded
			if (this.collapsed)
			{
				this.Collapse();
			}
			else
			{
				this.Expand();
			}

			// set each control visible again
			foreach (Control control in this.Controls)
			{
				control.Visible = !this.hiddenControls.Contains(control);
			}

			//
			this.ResumeLayout(true);
		}


		/// <summary>
		/// Returns an image of the group's display area to be used
		/// in the fade animation
		/// </summary>
		/// <returns>The Image to use during the fade animation</returns>
		internal Image GetFadeAnimationImage()
		{
			try
			{
				if (this.Height == this.ExpandedHeight)
					return this.GetExpandedImage();
				else
					return this.GetCollapsedImage();
			}
			catch
			{
				return null;
			}
		}


		/// <summary>
		/// Gets the image to be used in the animation while the 
		/// XExpando is in its expanded state
		/// </summary>
		/// <returns>The Image to use during the fade animation</returns>
		internal Image GetExpandedImage()
		{
			// create a new image to draw into
			Image image = new Bitmap(this.Width, this.Height);

			// get a graphics object we can draw into
			Graphics g = Graphics.FromImage(image);
			IntPtr hDC = g.GetHdc();

			// some flags to tell the control how to draw itself
			IntPtr flags = (IntPtr) (Win32.WmPrintFlags.PRF_CLIENT | Win32.WmPrintFlags.PRF_CHILDREN | Win32.WmPrintFlags.PRF_ERASEBKGND);

			User32.SendMessage(this.Handle, (int) Win32.Msgs.WM_PRINT, hDC, flags);

			// clean up resources
			g.ReleaseHdc(hDC);
			g.Dispose();

			// return the completed animation image
			return image;
		}


		/// <summary>
		/// Gets the image to be used in the animation while the 
		/// XExpando is in its collapsed state
		/// </summary>
		/// <returns>The Image to use during the fade animation</returns>
		internal Image GetCollapsedImage()
		{
			int width = this.Width;
			int height = this.ExpandedHeight;
			
			
			// create a new image to draw that is the same
			// size we would be if we were expanded
			Image backImage = new Bitmap(width, height);

			// get a graphics object we can draw into
			Graphics g = Graphics.FromImage(backImage);

			// draw our parents background
			this.PaintTransparentBackground(g, new Rectangle(0, 0, width, height));

			// don't need to draw the titlebar as it is ignored 
			// when we paint with the animation image, but we do 
			// need to draw the borders and "client area"

			// borders
			using (SolidBrush brush = new SolidBrush(this.BorderColor))
			{
				// top border
				g.FillRectangle(brush, 
					this.Border.Left, 
					this.HeaderHeight, 
					width - this.Border.Left - this.Border.Right, 
					this.Border.Top); 
				
				// left border
				g.FillRectangle(brush, 
					0, 
					this.HeaderHeight, 
					this.Border.Left, 
					height - this.HeaderHeight); 
				
				// right border
				g.FillRectangle(brush, 
					width - this.Border.Right, 
					this.HeaderHeight, 
					this.Border.Right, 
					height - this.HeaderHeight); 
				
				// bottom border
				g.FillRectangle(brush, 
					this.Border.Left, 
					height - this.Border.Bottom, 
					width - this.Border.Left - this.Border.Right, 
					this.Border.Bottom); 
			}

			// "client area"
			using (SolidBrush brush = new SolidBrush(this.BackColor))
			{
				g.FillRectangle(brush, 
					this.Border.Left, 
					this.HeaderHeight, 
					width - this.Border.Left - this.Border.Right,
					height - this.HeaderHeight - this.Border.Bottom - this.Border.Top);
			}

			// waterMarkImage
			if (this.WaterMarkImage != null)
			{
				// work out a rough location of where the waterMarkImage should go
				Rectangle rect = new Rectangle(0, 0, this.WaterMarkImage.Width, this.WaterMarkImage.Height);
				rect.X = width - this.Border.Right - this.WaterMarkImage.Width;
				rect.Y = height - this.Border.Bottom - this.WaterMarkImage.Height;

				// shrink the destination rect if necesary so that we
				// can see all of the image
				
				if (rect.X < 0)
				{
					rect.X = 0;
				}

				if (rect.Width > this.ClientRectangle.Width)
				{
					rect.Width = this.ClientRectangle.Width;
				}

				if (rect.Y < this.DisplayRectangle.Top)
				{
					rect.Y = this.DisplayRectangle.Top;
				}

				if (rect.Height > this.DisplayRectangle.Height)
				{
					rect.Height = this.DisplayRectangle.Height;
				}

				// draw the waterMarkImage
				g.DrawImage(this.WaterMarkImage, rect);
			}

			// cleanup resources;
			g.Dispose();

			// make sure the dummyPanel is the same size as our image
			// (we don't want any tiling of the image)
			this.dummyPanel.Size = new Size(width, height);
			this.dummyPanel.HeaderHeight = this.HeaderHeight;
			this.dummyPanel.Border = this.Border;
			
			// set the image as the dummyPanels background
			this.dummyPanel.BackImage = backImage;

			// move all our controls to the dummyPanel, and then add
			// the dummyPanel to us
			while (this.Controls.Count > 0)
			{
				Control control = this.Controls[0];

				this.Controls.RemoveAt(0);
				this.dummyPanel.Controls.Add(control);

				control.Visible = !this.hiddenControls.Contains(control);
			}
			this.Controls.Add(this.dummyPanel);


			// create a new image for the dummyPanel to draw itself into
			Image image = new Bitmap(width, height);

			// get a graphics object we can draw into
			g = Graphics.FromImage(image);
			IntPtr hDC = g.GetHdc();

			// some flags to tell the control how to draw itself
			IntPtr flags = (IntPtr) (Win32.WmPrintFlags.PRF_CLIENT | Win32.WmPrintFlags.PRF_CHILDREN);
			
			// tell the control to draw itself
			User32.SendMessage(this.dummyPanel.Handle, (int) Win32.Msgs.WM_PRINT, hDC, flags);


			// clean up resources
			g.ReleaseHdc(hDC);
			g.Dispose();

			this.Controls.Remove(this.dummyPanel);

			// get our controls back
			while (this.dummyPanel.Controls.Count > 0)
			{
				Control control = this.dummyPanel.Controls[0];

				control.Visible = false;
				
				this.dummyPanel.Controls.RemoveAt(0);
				this.Controls.Add(control);
			}

			// dispose of the background image
			this.dummyPanel.BackImage = null;
			backImage.Dispose();

			return image;
		}

		#endregion

		#region Slide Show/Hide

		/// <summary>
		/// Gets the XExpando ready to start its show/hide animation
		/// </summary>
		internal void StartSlideAnimation()
		{
			if (!this.Enabled)
			{
				return;
			}
			
			this.animatingSlide = true;
			
			this.slideEndHeight = this.CalcHeightAndLayout();
		}


		/// <summary>
		/// Updates the next "frame" of the animation
		/// </summary>
		internal void UpdateSlideAnimation(int animationStepNum, int numAnimationSteps)
		{
			if (!this.Enabled)
			{
				return;
			}
			
			// the percentage we need to adjust our height by
			// double step = (1 / (double) numAnimationSteps) * animationStepNum;
			// replacement by: Joel Holdsworth (joel@airwebreathe.org.uk)
			//                 Paolo Messina (ppescher@hotmail.com)
			//                 05/06/2004
			//                 v1.1
			double step = (1.0 - Math.Cos(Math.PI * (double) animationStepNum / (double) numAnimationSteps)) / 2.0;
			
			// set the height of the group
			this.Height = this.expandedHeight + (int) ((this.slideEndHeight - this.expandedHeight) * step);

			// draw the next frame
			this.Invalidate();
		}


		/// <summary>
		/// Gets the XExpando to stop its animation
		/// </summary>
		internal void StopSlideAnimation()
		{
			if (!this.Enabled)
			{
				return;
			}
			
			this.animatingSlide = false;

			// make sure we're the right height
			this.Height = this.slideEndHeight;
			this.slideEndHeight = -1;

			this.DoLayout();
		}

		#endregion

		#endregion

		#region Controls

		/// <summary>
		/// Hides the specified Control
		/// </summary>
		/// <param name="control">The Control to hide</param>
		public void HideControl(Control control)
		{
			this.HideControl(control, false);
		}


		/// <summary>
		/// Hides the specified Control
		/// </summary>
		/// <param name="control">The Control to hide</param>
		/// <param name="animate">Will any animation be performed</param>
		public void HideControl(Control control, bool animate)
		{
			this.HideControl(new Control[] {control}, animate);
		}


		/// <summary>
		/// Hides the Controls contained in the specified array
		/// </summary>
		/// <param name="controls">The array Controls to hide</param>
		public void HideControl(Control[] controls)
		{
			this.HideControl(controls, false);
		}


		/// <summary>
		/// Hides the Controls contained in the specified array
		/// </summary>
		/// <param name="controls">The array Controls to hide</param>
		/// <param name="animate">Will any animation be performed</param>
		public void HideControl(Control[] controls, bool animate)
		{
			// don't bother if we are animating or are collapsed
			// or are disabled
			if (this.Animating || this.Collapsed || !this.Enabled)
			{
				return;
			}
			
			this.SuspendLayout();
			
			// flag to check if we actually hid any controls
			bool anyHidden = false;
			
			foreach (Control control in controls)
			{
				// hide the control if we own it and it is not already hidden
				if (this.Controls.Contains(control) && !this.hiddenControls.Contains(control))
				{
					anyHidden = true;

					control.Visible = false;
					this.hiddenControls.Add(control);
				}
			}

			this.ResumeLayout(false);

			// if we didn't hide any, get out of here
			if (!anyHidden)
			{
				return;
			}

			// are we able to animate?
			if (!animate || !this.AutoLayout || this.TaskBar == null || !this.TaskBar.Animate)
			{
				// guess not
				this.DoLayout();
			}
			else
			{
				this.TaskBar.StartSlideAnimation(this);
			}
		}


		/// <summary>
		/// Shows the specified Control
		/// </summary>
		/// <param name="control">The Control to show</param>
		public void ShowControl(Control control)
		{
			this.ShowControl(control, false);
		}
		

		/// <summary>
		/// Shows the specified Control
		/// </summary>
		/// <param name="control">The Control to show</param>
		/// <param name="animate">Will any animation be performed</param>
		public void ShowControl(Control control, bool animate)
		{
			this.ShowControl(new Control[] {control}, animate);
		}


		/// <summary>
		/// Shows the Controls contained in the specified array
		/// </summary>
		/// <param name="controls">The array Controls to show</param>
		public void ShowControl(Control[] controls)
		{
			this.ShowControl(controls, false);
		}


		/// <summary>
		/// Shows the Controls contained in the specified array
		/// </summary>
		/// <param name="controls">The array Controls to show</param>
		/// <param name="animate">Will any animation be performed</param>
		public void ShowControl(Control[] controls, bool animate)
		{
			// don't bother if we are animating or are collapsed
			// or are disabled
			if (this.Animating || this.Collapsed || !this.Enabled)
			{
				return;
			}
			
			this.SuspendLayout();
			
			// flag to check if any controls were shown
			bool anyHidden = false;
			
			foreach (Control control in controls)
			{
				// show the control if we own it and it is not already shown
				if (this.Controls.Contains(control) && this.hiddenControls.Contains(control))
				{
					anyHidden = true;

					control.Visible = true;
					this.hiddenControls.Remove(control);
				}
			}

			this.ResumeLayout(false);

			// if we didn't show any, get out of here
			if (!anyHidden)
			{
				return;
			}

			// are we able to animate?
			if (!animate || !this.AutoLayout || this.TaskBar == null || !this.TaskBar.Animate)
			{
				// guess not
				this.DoLayout();
			}
			else
			{
				this.TaskBar.StartSlideAnimation(this);
			}
		}

		#endregion
		
		#region Invalidation

		/// <summary>
		/// Invalidates the titlebar area
		/// </summary>
		public void InvalidateTitleBar()
		{
			this.Invalidate(new Rectangle(0, 0, this.Width, this.headerHeight), false);
		}

		#endregion

		#region ISupportInitialize Members

		/// <summary>
		/// Signals the object that initialization is starting
		/// </summary>
		public void BeginInit()
		{
			//초기화 Flag Set
			//최초 Collapsed로 적용된 Expando는 TaskBar에 Animate여부에 관계없이 Collapse적용
			this.initializing = true;
		}


		/// <summary>
		/// Signals the object that initialization is complete
		/// </summary>
		public void EndInit()
		{
			this.initializing = false;
			this.DoLayout();
		}

		#endregion

		#region Layout

		/// <summary>
		/// Forces the control to apply layout logic to child controls, 
		/// and adjusts the height of the XExpando if necessary
		/// </summary>
		public virtual void DoLayout()
		{
			// stop the layout engine
			this.SuspendLayout();

			// work out the height of the header section

			// is there an image to display on the titlebar
			if (this.titleImage != null)
			{
				// is the image bigger than the height of the titlebar
				if (this.titleImage.Height > this.titleBarHeight)
				{
					this.headerHeight = this.titleImage.Height;
				}
					// is the image smaller than the height of the titlebar
				else if (this.titleImage.Height < this.titleBarHeight)
				{
					this.headerHeight = this.titleBarHeight;
				}
					// is the image smaller than the current header height
				else if (this.titleImage.Height < this.headerHeight)
				{
					this.headerHeight = this.titleImage.Height;
				}
			}
			else
			{
				this.headerHeight = this.titleBarHeight;
			}

			// do we need to layout our items
			if (this.AutoLayout)
			{
				Control c;
				XTaskBarItem ti;
				Point p;

				// work out how wide to make the controls, and where
				// the top of the first control should be
				int y = this.DisplayRectangle.Y + this.BarPadding.Top;
				int width = this.PseudoClientRect.Width - this.BarPadding.Left - this.BarPadding.Right;

				// for each control in our list...
				for (int i=0; i<this.itemList.Count; i++)
				{
					c = (Control) this.itemList[i];

					if (this.hiddenControls.Contains(c))
					{
						continue;
					}

					// set the starting point
					p = new Point(this.BarPadding.Left, y);

					// is the control a XTaskBarItem?  if so, we may
					// need to take into account the margins
					if (c is XTaskBarItem)
					{
						ti = (XTaskBarItem) c;
						
						// only adjust the y co-ord if this isn't the first item 
						if (i > 0)
						{
							y += ti.Margin.Top;

							p.Y = y;
						}

						// adjust and set the width and height
						width -= ti.Margin.Left + ti.Margin.Right;

						ti.Width = width;
						ti.Height = ti.PreferredHeight;
					}					

					// set the location of the control
					c.Location = p;

					// update the next starting point.
					y += c.Height;

					// is the control a XTaskBarItem?  if so, we may
					// need to take into account the bottom margin
					if (i < this.itemList.Count-1)
					{
						if (c is XTaskBarItem)
						{
							ti = (XTaskBarItem) c;
							
							y += ti.Margin.Bottom;
						}
						else
						{
                            y += this.taskBarSetting.TaskLink.BarMargin.Bottom;
						}
					}
				}

				// workout where the bottom of the XExpando should be
				y += this.BarPadding.Bottom + this.Border.Bottom;

				// adjust the ExpandedHeight if they're not the same
				if (y != this.ExpandedHeight)
				{
					this.ExpandedHeight = y;

					// if we're not collapsed then we had better change
					// our height as well
					if (!this.Collapsed)
					{
						this.Height = this.ExpandedHeight;

						// if we belong to a ATaskBar then it needs to
						// re-layout its XExpandos
						if (this.TaskBar != null)
						{
							this.TaskBar.DoLayout();
						}
					}
				}
			}

			// restart the layout engine
			this.ResumeLayout(true);
		}


		/// <summary>
		/// Calculates the height that the XExpando would be if a 
		/// call to DoLayout() were made
		/// </summary>
		/// <returns>The height that the XExpando would be if a 
		/// call to DoLayout() were made</returns>
		internal int CalcHeightAndLayout()
		{
			// stop the layout engine
			this.SuspendLayout();

			// work out the height of the header section

			// is there an image to display on the titlebar
			if (this.titleImage != null)
			{
				// is the image bigger than the height of the titlebar
				if (this.titleImage.Height > this.titleBarHeight)
				{
					this.headerHeight = this.titleImage.Height;
				}
					// is the image smaller than the height of the titlebar
				else if (this.titleImage.Height < this.titleBarHeight)
				{
					this.headerHeight = this.titleBarHeight;
				}
					// is the image smaller than the current header height
				else if (this.titleImage.Height < this.headerHeight)
				{
					this.headerHeight = this.titleImage.Height;
				}
			}
			else
			{
				this.headerHeight = this.titleBarHeight;
			}

			int y = -1;

			// do we need to layout our items
			if (this.AutoLayout)
			{
				Control c;
				XTaskBarItem ti;
				Point p;

				// work out how wide to make the controls, and where
				// the top of the first control should be
				y = this.DisplayRectangle.Y + this.BarPadding.Top;
				int width = this.PseudoClientRect.Width - this.BarPadding.Left - this.BarPadding.Right;

				// for each control in our list...
				for (int i=0; i<this.itemList.Count; i++)
				{
					c = (Control) this.itemList[i];

					if (this.hiddenControls.Contains(c))
					{
						continue;
					}

					// set the starting point
					p = new Point(this.BarPadding.Left, y);

					// is the control a XTaskBarItem?  if so, we may
					// need to take into account the margins
					if (c is XTaskBarItem)
					{
						ti = (XTaskBarItem) c;
						
						// only adjust the y co-ord if this isn't the first item 
						if (i > 0)
						{
							y += ti.Margin.Top;

							p.Y = y;
						}

						// adjust and set the width and height
						width -= ti.Margin.Left + ti.Margin.Right;

						ti.Width = width;
						ti.Height = ti.PreferredHeight;
					}					

					// set the location of the control
					c.Location = p;

					// update the next starting point.
					y += c.Height;

					// is the control a XTaskBarItem?  if so, we may
					// need to take into account the bottom margin
					if (i < this.itemList.Count-1)
					{
						if (c is XTaskBarItem)
						{
							ti = (XTaskBarItem) c;
							
							y += ti.Margin.Bottom;
						}
						else
						{
                            y += this.taskBarSetting.TaskLink.BarMargin.Bottom;
						}
					}
				}

				// workout where the bottom of the XExpando should be
				y += this.BarPadding.Bottom + this.Border.Bottom;
			}

			// restart the layout engine
			this.ResumeLayout(true);

			return y;
		}


		/// <summary>
		/// Updates the layout of the XExpandos items while in design mode, and 
		/// adds/removes itemss from the ControlCollection as necessary
		/// </summary>
		internal void UpdateItems()
		{
			if (this.Items.Count == this.Controls.Count)
			{
				// make sure the the items index in the ControlCollection 
				// are the same as in the XTaskBarItemCollection (indexes in the 
				// XTaskBarItemCollection may have changed due to the user moving 
				// them around in the editor)
				this.MatchControlCollToItemColl();				
				
				return;
			}

			// were any items added
			if (this.Items.Count > this.Controls.Count)
			{
				// add any extra items in the XTaskBarItemCollection to the 
				// ControlCollection
				for (int i=0; i<this.Items.Count; i++)
				{
					if (!this.Controls.Contains(this.Items[i]))
					{
						this.OnItemAdded(new ControlEventArgs(this.Items[i]));
					}
				}
			}
			else
			{
				// items were removed
				int i = 0;
				Control control;

				// remove any extra items from the ControlCollection
				while (i < this.Controls.Count)
				{
					control = (Control) this.Controls[i];
					
					if (!this.Items.Contains(control))
					{
						this.OnItemRemoved(new ControlEventArgs(control));
					}
					else
					{
						i++;
					}
				}
			}

			this.Invalidate(true);
		}


		/// <summary>
		/// Make sure the controls index in the ControlCollection 
		/// are the same as in the XTaskBarItemCollection (indexes in the 
		/// XTaskBarItemCollection may have changed due to the user moving 
		/// them around in the editor or calling XTaskBarItemCollection.Move())
		/// </summary>
		internal void MatchControlCollToItemColl()
		{
			this.SuspendLayout();
				
			for (int i=0; i<this.Items.Count; i++)
			{
				this.Controls.SetChildIndex(this.Items[i], i);
			}

			this.ResumeLayout(false);
				
			this.DoLayout();

			this.Invalidate(true);
		}

		#endregion

		#endregion

		#region Override EventInvoker
		protected override void OnControlAdded(ControlEventArgs e)
		{
			// don't do anything if we are animating
			// (as we're probably the ones who added the control)
			if (this.Animating)
			{
				return;
			}
			
			base.OnControlAdded(e);
			// check if the expando was added by dragging it onto 
			// the taskBar instead of being added to the expando 
			// collection during design time
			if (this.DesignMode && !this.Items.Contains(e.Control))
			{
				this.Items.Add(e.Control);
			}
		}
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			// don't do anything if we are animating 
			// (as we're probably the ones who removed the control)
			if (this.Animating)
			{
				return;
			}
			
			base.OnControlRemoved(e);

			// remove the control from the itemList
			if (this.Items.Contains(e.Control))
			{
				this.Items.Remove(e.Control);
			}

			// update the layout of the controls
			this.DoLayout();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			// was it the left mouse button
			if (e.Button == MouseButtons.Left)
			{
				// was it in the titlebar area
				if (e.Y < this.HeaderHeight && e.Y > (this.HeaderHeight - this.TitleBarHeight))
				{
					// make sure that our taskPane (if we have one) is not animating
					if (this.TaskBar == null || !this.TaskBar.IsAnimating)
					{
						//2006.02.16 TaskBar가 있을때 IsExpandoChangable(Click시에 확대축소가능여부에 따라 설정
						if ((this.TaskBar != null) && !this.TaskBar.IsExpandoChangable)
							return;

						// collapse/expand the group
						this.Collapsed = !this.Collapsed;
					}
				}
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			// check if the mouse is moving in the titlebar area
			if (e.Y < this.HeaderHeight && e.Y > (this.HeaderHeight - this.TitleBarHeight))
			{
				// change the cursor to a hand and highlight the titlebar
				this.Cursor = Cursors.Hand;
				this.FocusState = FocusStates.Mouse;
			}
			else
			{
				// reset the titlebar highlight and cursor if they haven't already
				this.Cursor = Cursors.Default;
				this.FocusState = FocusStates.None;
			}
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			// reset the titlebar highlight if it hasn't already
			this.FocusState = FocusStates.None;
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);

			// if we are currently animating and the width of the
			// group has changed (eg. due to a scrollbar on the 
			// ATaskBar appearing/disappearing), get a new image 
			// to use for the animation. (if we were to continue to 
			// use the old image it would be shrunk or stretched making 
			// the animation look wierd)
			if (this.Animating && this.Width != this.oldWidth)
			{
				this.oldWidth = this.Width;
				
				if (this.AnimationImage != null)
				{
					// get the new animationImage
					this.animationImage = this.GetFadeAnimationImage();
				}
			}
				// check if the width has changed.  if it has re-layout
				// the group so that the XTaskBarItems can resize themselves
				// if neccessary
			else if (this.Width != this.oldWidth)
			{
				this.oldWidth = this.Width;
				
				this.DoLayout();
			}
		}
		#endregion

		#region EventInvoker
		protected virtual void OnStateChanged(XExpandoEventArgs e)
		{
			if (StateChanged != null)
				StateChanged(e);
		}
		protected virtual void OnTitleImageChanged(XExpandoEventArgs e)
		{
			if (TitleImageChanged != null)
				TitleImageChanged(e);
		}
		protected virtual void OnSpecialGroupChanged(XExpandoEventArgs e)
		{
			if (SpecialGroupChanged != null)
				SpecialGroupChanged(e);
		}
		protected virtual void OnItemAdded(ControlEventArgs e)
		{
			// add the expando to the ControlCollection if it hasn't already
			if (!this.Controls.Contains(e.Control))
			{
				this.Controls.Add(e.Control);
			}

			// check if the control is a XTaskBarItem
			if (e.Control is XTaskBarItem)
			{
				XTaskBarItem item = (XTaskBarItem) e.Control;
			
				// set anchor styles
				item.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
			
				// tell the XTaskBarItem who's its daddy...
				item.Expando = this;
				item.TaskBarSetting = this.taskBarSetting;
			}

			// update the layout of the controls
			this.DoLayout();

			if (ItemAdded != null)
				ItemAdded(this, e);
		}
		protected virtual void OnItemRemoved(ControlEventArgs e)
		{
			// remove the control from the ControlCollection if it hasn't already
			if (this.Controls.Contains(e.Control))
			{
				this.Controls.Remove(e.Control);
			}

			// update the layout of the controls
			this.DoLayout();

			//
			if (ItemRemoved != null)
				ItemRemoved(this, e);
		}

		#endregion

		#region Paint
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			// if we have a transparent backgroubd color, get windows
			// to paint our background for us
			if (this.BackColor == Color.Transparent)
			{
				base.OnPaintBackground(e);
			}
			else
			{
				this.PaintTransparentBackground(e.Graphics, this.ClientRectangle);
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			// paint the titlebar
			PaintTitleBar(e.Graphics);

			// only paint the border and "display rect" if we are not collapsed
			if (this.Height != this.headerHeight)
			{
				PaintBorder(e.Graphics);

				PaintDisplayRect(e.Graphics);
			}
		}
		protected void PaintTransparentBackground(Graphics g, Rectangle clipRect)
		{
			// check if we have a parent
			if (this.Parent != null)
			{
				// convert the clipRects coordinates from ours to our parents
				clipRect.Offset(this.Location);

				PaintEventArgs e = new PaintEventArgs(g, clipRect);

				// save the graphics state so that if anything goes wrong 
				// we're not fubar
				GraphicsState state = g.Save();

				try
				{
					// move the graphics object so that we are drawing in 
					// the correct place
					g.TranslateTransform((float) -this.Location.X, (float) -this.Location.Y);
					
					// draw the parents background and foreground
					this.InvokePaintBackground(this.Parent, e);
					this.InvokePaint(this.Parent, e);

					return;
				}
				finally
				{
					// reset everything back to where they were before
					g.Restore(state);
					clipRect.Offset(-this.Location.X, -this.Location.Y);
				}
			}

			// we don't have a parent, so fill the rect with
			// the default control color
			g.FillRectangle(SystemBrushes.Control, clipRect);
		}
		protected void PaintDisplayRect(Graphics g)
		{
			// are we animating a fade
			if (this.animatingFade && this.AnimationImage != null)
			{
				// calculate the transparency value for the animation image
				float alpha = (((float) (this.Height - this.HeaderHeight)) / ((float) (this.ExpandedHeight - this.HeaderHeight)));
				
				float[][] ptsArray = {new float[] {1, 0, 0, 0, 0},
										 new float[] {0, 1, 0, 0, 0},
										 new float[] {0, 0, 1, 0, 0},
										 new float[] {0, 0, 0, alpha, 0}, 
										 new float[] {0, 0, 0, 0, 1}}; 

				ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
				ImageAttributes imageAttributes = new ImageAttributes();
				imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

				// work out how far up the animation image we need to start
				int y = this.AnimationImage.Height - this.PseudoClientHeight - this.Border.Bottom;

				// draw the image
				g.DrawImage(this.AnimationImage,
					new Rectangle(0, this.HeaderHeight, this.Width, this.Height - this.HeaderHeight),
					0,
					y,
					this.AnimationImage.Width, 
					this.AnimationImage.Height - y,
					GraphicsUnit.Pixel,
					imageAttributes);
			}
				// are we animating a slide
			else if (this.animatingSlide)
			{
				// just paint the area with a solid brush
				using (SolidBrush brush = new SolidBrush(this.BackColor))
				{
					g.FillRectangle(brush, 
						this.Border.Left, 
						this.HeaderHeight + this.Border.Top, 
						this.Width - this.Border.Left - this.Border.Right,
						this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
				}
			}
			else
			{
				// just paint the area with a solid brush
				using (SolidBrush brush = new SolidBrush(this.BackColor))
				{
					g.FillRectangle(brush, this.DisplayRectangle);
				}

				if (this.WaterMarkImage != null)
				{
					// work out a rough location of where the waterMarkImage should go
					Rectangle rect = new Rectangle(0, 0, this.WaterMarkImage.Width, this.WaterMarkImage.Height);
					rect.X = this.PseudoClientRect.Right - this.WaterMarkImage.Width;
					rect.Y = this.DisplayRectangle.Bottom - this.WaterMarkImage.Height;

					// shrink the destination rect if necesary so that we
					// can see all of the image
				
					if (rect.X < 0)
					{
						rect.X = 0;
					}

					if (rect.Width > this.ClientRectangle.Width)
					{
						rect.Width = this.ClientRectangle.Width;
					}

					if (rect.Y < this.DisplayRectangle.Top)
					{
						rect.Y = this.DisplayRectangle.Top;
					}

					if (rect.Height > this.DisplayRectangle.Height)
					{
						rect.Height = this.DisplayRectangle.Height;
					}

					// draw the waterMarkImage
					g.DrawImage(this.WaterMarkImage, rect);
				}
			}
		}
		protected void PaintTitleBar(Graphics g)
		{
			int y = 0;
			
			// work out where the top of the titleBar actually is
			if (this.HeaderHeight > this.TitleBarHeight)
			{
				y = this.HeaderHeight - this.TitleBarHeight;
			}
			
			// draw the title background image if we have one
			if (this.TitleBackImage != null)
			{
				if (this.Enabled)
				{
					g.DrawImage(this.TitleBackImage, 0, y, this.Width, this.TitleBarHeight);
				}
				else
				{
					// first stretch the background image for ControlPaint.
					using (Image image = new Bitmap(this.TitleBackImage, this.Width, this.TitleBarHeight))
					{
						ControlPaint.DrawImageDisabled(g, image, 0, y, this.TitleBackColor);
					}
				}
			}
			else
			{
				Color c = this.TitleBackColor;
                //<FOR_TEST>
                //Logs.WriteLog("PaintTitleBar Name=" + this.Name + ",TitleBackColor=" + c.ToString());
				
				using (SolidBrush brush = new SolidBrush(this.TitleBackColor))
				{
					g.FillRectangle(brush, 0, y, this.Width, this.TitleBarHeight);
				}
			}

			// draw the titlebar image if we have one
			if (this.TitleImage != null)
			{
				if (this.Enabled)
				{
					g.DrawImage(this.TitleImage, 0, 0);
				}
				else
				{
					ControlPaint.DrawImageDisabled(g, TitleImage, 0, 0, this.TitleBackColor);
				}
			}

			// get which collapse/expand arrow we should draw
			Image arrowImage = this.ArrowImage;

			// get the titlebar's border and padding
			XTaskBarBorder border = this.TitleBorder;
			XTaskBarPadding padding = this.TitlePadding;

			// draw the arrow if we have one
			// 2006.02.18 TaskBar가 있을때 IsExpandoChangable이 false이면 arrowImage는 그리지 않음
			if ((arrowImage != null) && ((this.TaskBar == null) || this.TaskBar.IsExpandoChangable))
			{
				// work out where to position the arrow
				int x = this.Width - arrowImage.Width - border.Right - padding.Right;
				y += border.Top + padding.Top;

				// draw it...
				if (this.Enabled)
				{
					g.DrawImage(arrowImage, x, y);
				}
				else
				{
					ControlPaint.DrawImageDisabled(g, arrowImage, x, y, this.TitleBackColor);
				}
			}

			// check if we have any text to draw in the titlebar
			if (this.Text.Length > 0)
			{
				// a rectangle that will contain our text
				Rectangle rect = new Rectangle();
				
				// work out the x coordinate
				if (this.TitleImage == null)
				{
					rect.X = border.Left + padding.Left;
				}
				else
				{
					rect.X = this.TitleImage.Width + border.Left;
				}

				// work out the y coordinate
				ContentAlignment alignment = this.TitleAlignment;

				switch (alignment)
				{
					case ContentAlignment.MiddleLeft:
					case ContentAlignment.MiddleCenter:
					case ContentAlignment.MiddleRight:	
						rect.Y = ((this.HeaderHeight - this.TitleFont.Height) / 2) + ((this.HeaderHeight - this.TitleBarHeight) / 2) + border.Top + padding.Top;
						break;

					case ContentAlignment.TopLeft:
					case ContentAlignment.TopCenter:
					case ContentAlignment.TopRight:		
						rect.Y = (this.HeaderHeight - this.TitleBarHeight) + border.Top + padding.Top;
						break;

					case ContentAlignment.BottomLeft:
					case ContentAlignment.BottomCenter:
					case ContentAlignment.BottomRight:	
						rect.Y = this.HeaderHeight - this.TitleFont.Height;
						break;
				}

				// the height of the rectangle
				rect.Height = this.TitleFont.Height;

				// make sure the text stays inside the header
				if (rect.Bottom > this.HeaderHeight)
				{
					rect.Y -= rect.Bottom - this.HeaderHeight;
				}
					
				// work out how wide the rectangle should be
				if (arrowImage != null)
				{
					rect.Width = this.Width - arrowImage.Width - border.Right - padding.Right - rect.X;
				}
				else
				{
					rect.Width = this.Width - border.Right - padding.Right - rect.X;
				}

				// don't wrap the string, and use an ellipsis if
				// the string is too big to fit the rectangle
				StringFormat sf = new StringFormat();
				sf.FormatFlags = StringFormatFlags.NoWrap;
				sf.Trimming = StringTrimming.EllipsisCharacter;

				// should the string be aligned to the left/center/right
				switch (alignment)
				{
					case ContentAlignment.MiddleLeft:
					case ContentAlignment.TopLeft:
					case ContentAlignment.BottomLeft:	
						sf.Alignment = StringAlignment.Near;
						break;

					case ContentAlignment.MiddleCenter:
					case ContentAlignment.TopCenter:
					case ContentAlignment.BottomCenter:	
						sf.Alignment = StringAlignment.Center;
						break;

					case ContentAlignment.MiddleRight:
					case ContentAlignment.TopRight:
					case ContentAlignment.BottomRight:	
						sf.Alignment = StringAlignment.Far;
						break;
				}

				// draw the text
				using (SolidBrush brush = new SolidBrush(this.TitleColor))
				{
					if (this.Enabled)
					{
						g.DrawString(this.Text, this.TitleFont, brush, rect, sf);
                        //<FOR_TEST>
                        //Logs.WriteLog("PaintTitleBar Name=" + this.Name + ",TitleColor=" + this.TitleColor.ToString());
					}
					else
					{
						ControlPaint.DrawStringDisabled(g, this.Text, this.TitleFont, SystemColors.ControlLightLight, rect, sf);
					}
				}
			}
		}
		protected void PaintBorder(Graphics g)
		{
			// get the current border and border colors
			XTaskBarBorder border = this.Border;
			Color c = this.BorderColor;

			// check if we are currently animating a fade
			if (this.animatingFade)
			{
				// calculate the alpha value for the color
				int alpha = (int) (255 * (((float) (this.Height - this.HeaderHeight)) / ((float) (this.ExpandedHeight - this.HeaderHeight))));

				// make sure it doesn't go past 0 or 255
				if (alpha < 0)
				{
					alpha = 0;
				}
				else if (alpha > 255)
				{
					alpha = 255;
				}

				// update the color with the alpha value
				c = Color.FromArgb(alpha, c.R, c.G, c.B);
			}
			
			// draw the borders
			using (SolidBrush brush = new SolidBrush(c))
			{
				g.FillRectangle(brush, border.Left, this.HeaderHeight, this.Width-border.Left-border.Right, border.Top); // top border
				g.FillRectangle(brush, 0, this.HeaderHeight, border.Left, this.Height-this.HeaderHeight); // left border
				g.FillRectangle(brush, this.Width-border.Right, this.HeaderHeight, border.Right, this.Height-this.HeaderHeight); // right border
				g.FillRectangle(brush, border.Left, this.Height-border.Bottom, this.Width-border.Left-border.Right, border.Bottom); // bottom border
			}
		}

		#endregion

		#region AnimationPanel
		internal class AnimationPanel : Panel
		{
			#region Fields

			/// <summary>
			/// The height of the header section 
			/// (includes titlebar and title image)
			/// </summary>
			private int headerHeight;
 
			/// <summary>
			/// The border around the "client area"
			/// </summary>
			private XTaskBarBorder border;

			/// <summary>
			/// The background image displayed in the control
			/// </summary>
			private Image backImage;

			#endregion


			#region Constructor
			public AnimationPanel() : base()
			{
				this.headerHeight = 0;
				this.border = new XTaskBarBorder();
				this.backImage = null;
			}
			#endregion


			#region Properties

			/// <summary>
			/// Overrides AutoScroll to disable scrolling
			/// </summary>
			public new bool AutoScroll
			{
				get	{return false;}
				set	{}
			}
			/// <summary>
			/// Gets or sets the height of the header section of the XExpando
			/// </summary>
			public int HeaderHeight
			{
				get	{ return this.headerHeight;	}
				set	{ this.headerHeight = value;}
			}


			/// <summary>
			/// Gets or sets the border around the "client area"
			/// </summary>
			public XTaskBarBorder Border
			{
				get	{ return this.border;}
				set	{ this.border = value;}
			}
			/// <summary>
			/// Gets or sets the background image displayed in the control
			/// </summary>
			public Image BackImage
			{
				get	{ return this.backImage;}
				set	{ this.backImage = value;}
			}
			/// <summary>
			/// Overrides DisplayRectangle so that docked controls
			/// don't cover the titlebar or borders
			/// </summary>
			public override Rectangle DisplayRectangle
			{
				get
				{
					return new Rectangle(this.Border.Left, 
						this.HeaderHeight + this.Border.Top,
						this.Width - this.Border.Left - this.Border.Right,
						this.Height - this.HeaderHeight - this.Border.Top - this.Border.Bottom);
				}
			}

			#endregion


			#region Events
			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);

				if (this.BackImage != null)
				{
					e.Graphics.DrawImageUnscaled(this.BackImage, 0, 0);
				}
			}

			#endregion
		}
		#endregion

		#region XTaskBarItemCollection
		public class XTaskBarItemCollection : CollectionBase
		{
			#region Fields
			/// <summary>
			/// The XExpando that owns this ControlCollection
			/// </summary>
			private XExpando owner;
			#endregion

			#region Constructor
			public XTaskBarItemCollection(XExpando owner) : base()
			{
				if (owner == null)
					throw new ArgumentNullException("Owner가 지정되지 않았습니다.");
				this.owner = owner;
			}
			#endregion

			#region Methods
			public void Add(Control value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("Control이 지정되지 않았습니다.");
				}

				this.List.Add(value);
				this.owner.Controls.Add(value);

				this.owner.OnItemAdded(new ControlEventArgs(value));
			}
			public void AddRange(Control[] controls)
			{
				if (controls == null)
				{
					throw new ArgumentNullException("Control[]가 지정되지 않았습니다.");
				}

				for (int i=0; i<controls.Length; i++)
				{
					this.Add(controls[i]);
				}
			}
			public new void Clear()
			{
				while (this.Count > 0)
				{
					this.RemoveAt(0);
				}
			}
			public bool Contains(Control control)
			{
				return (this.IndexOf(control) != -1);
			}
			public int IndexOf(Control control)
			{
				if (control == null)
					return -1;
				
				for (int i=0; i< this.Count; i++)
					if (this[i] == control)
						return i;
				return -1;
			}
			public void Remove(Control value)
			{
				if (value == null) return;

				this.List.Remove(value);
				this.owner.Controls.Remove(value);

				this.owner.OnItemRemoved(new ControlEventArgs(value));
			}
			public new void RemoveAt(int index)
			{
				this.Remove(this[index]);
			}
			public void Move(Control value, int index)
			{
				if (value == null) return;

				// make sure the index is within range
				if (index < 0)
					index = 0;
				else if (index > this.Count)
					index = this.Count;

				// don't go any further if the expando is already 
				// in the desired position or we don't contain it
				if (!this.Contains(value) || this.IndexOf(value) == index)
					return;

				this.List.Remove(value);
				if (index > this.Count)
					this.List.Add(value);
				else
					this.List.Insert(index, value);
			}
			public void MoveToTop(Control value)
			{
				this.Move(value, 0);
			}
			public void MoveToBottom(Control value)
			{
				this.Move(value, this.Count);
			}
			#endregion

			#region Properties
			public virtual Control this[int index]
			{
				get	{ return this.List[index] as Control;}
			}
			#endregion
		}

		#endregion
	
		#region XTaskBarItemCollectionEditor

		/// <summary>
		/// 
		/// </summary>
		internal class XTaskBarItemCollectionEditor : CollectionEditor
		{
			/// <summary>
			/// Initializes a new instance of the CollectionEditor class 
			/// using the specified collection type
			/// </summary>
			/// <param name="type"></param>
			public XTaskBarItemCollectionEditor(Type type) : base(type)
			{
			
			}

			public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
			{
				XExpando originalControl = (XExpando) context.Instance;

				object returnObject = base.EditValue(context, isp, value);

				originalControl.UpdateItems();

				return returnObject;
			}
			protected override object CreateInstance(Type itemType)
			{
				// ignore the type of item we're supposed to create 
				// and assume the user wants to create a taskitem
				object item = base.CreateInstance(typeof(XTaskBarItem));
			
				((XTaskBarItem) item).Name = "taskitem";
			
				return item;
			}
		}

		#endregion
	}
	#endregion

	#region XExpandoEventHandler
	public delegate void XExpandoEventHandler(XExpandoEventArgs e);
	
	/// <summary>
	/// Summary description for XExpandoEventArgs.
	/// </summary>
	public class XExpandoEventArgs : EventArgs
	{
		#region Field
		/// <summary>
		/// The XExpando thet generated the event
		/// </summary>
		private XExpando expando;
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets the XExpando that generated the event
		/// </summary>
		public XExpando Expando
		{
			get	{ return this.expando;}
		}
		/// <summary>
		/// Gets whether the XExpando is collapsed
		/// </summary>
		public bool Collapsed
		{
			get	{ return this.expando.Collapsed;}
		}
		#endregion

		#region Constructor
		public XExpandoEventArgs(XExpando expando)
		{
			this.expando = expando;
		}
		#endregion
	}

	#endregion

	#region XExpandoConverter
	internal class XExpandoConverter : TypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}

			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor) && value is XExpando)
			{
				ConstructorInfo ci = typeof(XExpando).GetConstructor(new Type[] {});

				if (ci != null)
				{
					return new InstanceDescriptor(ci, null, false);
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region XExpandoDesigner

	/// <summary>
	/// Summary description for XExpandoDesigner.
	/// </summary>
	internal class XExpandoDesigner : ParentControlDesigner
	{
        //2006.07.25 .NET 2003에서는 Expando를 제거하지 않은 상태에서 TaskBar를 삭제해도 문제가 발생하지 않았으나,
        //.NET 2005에서는 Expando가 있는 상태에서 TaskBar를 삭제시에 base.Dispose에서 에러가 발생함.(정확한 원인은 알수 없음)
        // <현상> TaskBar에 Expando가 있는 경우, Expando 위에 TaskBarItem가 있는 경우
        // <해결> XTaskBarDesinger에서 TaskBar가 삭제될때 Expandos 도 함께 삭제,
        //        XExpandoDesinger에서 Expando가 삭제될때 Items에 있는 TaskBarItem도 함께 삭제

        private XExpando expando = null;
        private ISelectionService iSvc;
        private IComponentChangeService iComp;
        private IDesignerHost iHost;

        /// <summary>
        /// 디자이너를 지정된 구성 요소로 초기화합니다.
        /// </summary>
        /// <param name="component">디자이너에 연결할 IComponent</param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            // Design하고있는 Control 등록
            expando = (XExpando)component;

            //Service Instance Set
            iSvc = (ISelectionService)GetService(typeof(ISelectionService));
            iComp = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            iHost = (IDesignerHost)GetService(typeof(IDesignerHost));
            iComp.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
        }
        /// <summary>
        /// 관리되지 않는 리소스를 해제하고 필요에 따라 관리되는 리소스를 해제합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스와 관리되지 않는 리소스를 모두 해제하려면 true로 설정하고, 관리되지 않는 리소스만 해제하려면 false로 설정합니다.</param>
        protected override void Dispose(bool disposing)
        {
            // Unhook events
            iComp.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);
            base.Dispose(disposing);
        }

        /// <summary>
        /// 디자이너가 관리하는 구성 요소와 관련된 구성 요소 컬렉션을 가져옵니다.
        /// </summary>
        public override ICollection AssociatedComponents
        {
            get
            {
                //Expando와 관련된 XTaskBarItemCollection Items
                return expando.Items;
            }
        }

        private void OnComponentRemoving(object sender, ComponentEventArgs e)
        {
            //XExpando가 제거될때 관련된 Items에 포함된 Controls도 같이 제거
            if (e.Component == expando)
            {
                Control cont = null;
                for (int idx = expando.Items.Count - 1; idx >= 0; idx--)
                {
                    cont =  expando.Items[idx];
                    iComp.OnComponentChanging(expando, null);
                    expando.Items.Remove(cont);
                    iHost.DestroyComponent(cont);
                    iComp.OnComponentChanged(expando, null, null, null);
                }
            }
        }

		// 필요없는 Property제거
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);
			
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("RightToLeft");
			properties.Remove("BackColor");
			properties.Remove("BackgroundImage");
			properties.Remove("BorderStyle");
			properties.Remove("Cursor");
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("CausesValidation");
			properties.Remove("AutoScroll");
			properties.Remove("AutoScrollMargin");
			properties.Remove("AutoScrollMinSize");
		}
	}

	#endregion

	#region FocusStates
	internal enum FocusStates
	{
		/// <summary>
		/// Normal state
		/// </summary>
		None = 0,	
		
		/// <summary>
		/// The mouse is over the title bar
		/// </summary>
		Mouse = 1,	
		
		/// <summary>
		/// Gained focus via the keyboard
		/// </summary>
		Keyboard = 2
	}
	#endregion
}
