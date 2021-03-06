using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace IHIS.Framework
{
	#region XTaskBar
	
	/// <summary>
	/// Summary description for XTaskBar.
    /// //public class XTaskBar : ScrollableControl, ISupportInitialize
	/// </summary>
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(IHIS.Framework.XTaskBar), "Images.XTaskBar.bmp")]
	[DefaultProperty("Expandos")]
	[DesignerAttribute(typeof(XTaskBarDesigner))]
    public class XTaskBar : ScrollableControl, ISupportInitialize
	{
		#region Fields
		private System.ComponentModel.Container components = null;
		private XTaskBar.XExpandoCollection expandoCollection = null;
		// system defined settings for the TaskBar
		private XTaskBarSetting taskBarSetting;

		private bool animate = false;  //확장,축소시 애니메이션 여부
		private ArrayList animationHelpers;

		// are we initializing
		private bool initializing = false;

		private bool isClassicTheme = false;

		//2006.02.16 Expando를 확대,축소 할 수 있는지 여부를 관리
		private bool isExpandoChangable = true;

		#endregion

		#region Event Handlers
		/// <summary>
		/// Expando가 추가되었을때 발생합니다.
		/// </summary>
		[Description("Expando가 추가되었을때 발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event XTaskBarEventHandler ExpandoAdded; 
		/// <summary>
		/// Expando가 제거되었을때 발생합니다.
		/// </summary>
		[Description("Expando가 제거되었을때 발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event XTaskBarEventHandler ExpandoRemoved; 
		/// <summary>
		/// Expando가 확장,축소되었을때 발생합니다.
		/// </summary>
		[Description("Expando가 확장,축소되었을때 발생합니다."),
		Category("追加イベント"),
		Browsable(true)]
		public event XTaskBarEventHandler ExpandoStateChanged; 
		#endregion
			
		#region Constructor
		public XTaskBar()
		{
			// This call is required by the Windows.Forms Form Designer.
			components = new System.ComponentModel.Container();

			// set control styles
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			this.expandoCollection = new XTaskBar.XExpandoCollection(this);

			// get the system theme settings
			this.TaskBarSetting = XTaskBarUtil.GetTaskBarSetting();
			this.isClassicTheme = false;

			// size
			int width = (this.taskBarSetting.TaskBar.Padding.Left + 
				this.taskBarSetting.TaskBar.Padding.Right + 
				this.taskBarSetting.Header.BackImageWidth);
			int height = width;
			this.Size = new Size(width, height);

			// setup sutoscrolling
			this.AutoScroll = false;
			this.AutoScrollMargin = new Size(this.taskBarSetting.TaskBar.Padding.Right, 
				this.taskBarSetting.TaskBar.Padding.Bottom);

			// don't use animation
			this.animate = false;
			this.animationHelpers = new ArrayList();

		}

		#endregion

		#region Methods

		#region Animation
		internal void StartFadeAnimation(XExpando expando)
		{
			XTaskBarAnimationHelper animationHelper = new XTaskBarAnimationHelper(this, expando, XTaskBarAnimationHelper.FadeAnimation);
			this.animationHelpers.Add(animationHelper);

			animationHelper.StartAnimation();
		}
		internal void StartSlideAnimation(XExpando expando)
		{
			XTaskBarAnimationHelper animationHelper = new XTaskBarAnimationHelper(this, expando, XTaskBarAnimationHelper.SlideAnimation);
			this.animationHelpers.Add(animationHelper);

			animationHelper.StartAnimation();
		}
		internal void AnimationStopped(XTaskBarAnimationHelper animationHelper)
		{
			this.animationHelpers.Remove(animationHelper);

			animationHelper = null;

			this.Invalidate(true);
		}
		#endregion

		#region Appearance

		/// <summary>
		/// Forces the XTaskBar and all it's XExpandos to use a theme
		/// equivalent to Windows XPs classic theme 
		/// </summary>
		public void UseClassicTheme()
		{
			this.isClassicTheme = true;
			
			XTaskBarSetting setting = XTaskBarUtil.GetTaskBarSetting();
			setting.UseClassicTheme();

			this.taskBarSetting.Dispose();
			this.taskBarSetting = null;

			this.TaskBarSetting = setting;
		}
		/// <summary>
		/// Forces the XTaskBar and all it's XExpandos to use the 
		/// current system theme
		/// </summary>
		public void UseDefaultTheme()
		{
			this.isClassicTheme = false;
			
			XTaskBarSetting setting = XTaskBarUtil.GetTaskBarSetting();

			this.taskBarSetting.Dispose();
			this.taskBarSetting = null;

			this.TaskBarSetting = setting;
		}

		#endregion

		#region Dispose

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}

				if (this.taskBarSetting != null)
				{
					this.taskBarSetting.Dispose();
				}

                //2006.07.25 .NET 2003에서는 Expando를 제거하지 않은 상태에서 TaskBar를 삭제해도 문제가 발생하지 않았으나,
                //.NET 2005에서는 Expando가 있는 상태에서 TaskBar를 삭제시에 base.Dispose에서 에러가 발생함.(정확한 원인은 알수 없음)
                // <현상> TaskBar에 Expando가 있는 경우, Expando 위에 TaskBarItem가 있는 경우
                // <해결> XTaskBarDesinger에서 TaskBar가 삭제될때 Expandos 도 함께 삭제,
                //        XExpandoDesinger에서 Expando가 삭제될때 Items에 있는 TaskBarItem도 함께 삭제
                // <아래와 같이 Controls.Remove만 하면 해당 Expando 객체는 계속 Seriailize되어 Source에 남아 있음
                /*
                if (this.Expandos.Count > 0)
                {
                    for (int i = this.Expandos.Count - 1; i >= 0; i--)
                    {
                        XExpando expando = this.Expandos[i];
                        this.Controls.Remove(expando);
                    }
                }
                */

			}
            base.Dispose(disposing);

		}

		#endregion

		#region XExpandos

		/// <summary>
		/// Collaspes all the XExpandos contained in the XTaskBar
		/// </summary>
		// suggested by: PaleyX (jmpalethorpe@tiscali.co.uk)
		//               03/06/2004
		//               v1.1
		public void CollapseAll()
		{
			foreach (XExpando expando in this.Expandos)
			{
				expando.Collapsed = true;
			}
		}


		/// <summary>
		/// Expands all the XExpandos contained in the XTaskBar
		/// </summary>
		// suggested by: PaleyX (jmpalethorpe@tiscali.co.uk)
		//               03/06/2004
		//               v1.1
		public void ExpandAll()
		{
			foreach (XExpando expando in this.Expandos)
			{
				expando.Collapsed = false;
			}
		}
		public void CollapseAllButOne(XExpando expando)
		{
			foreach (XExpando e in this.Expandos)
			{
				if (e != expando)
				{
					e.Collapsed = true;
				}
				else
				{
					expando.Collapsed = false;
				}
			}
		}
		#endregion

		#region ISupportInitialize Implementation
		public void BeginInit()
		{
			this.initializing = true;
		}
		public void EndInit()
		{
			this.initializing = false;
			this.DoLayout();
		}
		
		#endregion

		#region Layout
		public void DoLayout()
		{
			// stop the layout engine
			this.SuspendLayout();
			
			XExpando e;
			Point p;
			
			// work out how wide to make the controls, and where
			// the top of the first control should be
			int y = this.DisplayRectangle.Y + this.BarPadding.Top;
            int width = this.ClientSize.Width - this.BarPadding.Left - this.BarPadding.Right;

			// for each control in our list...
			for (int i=0; i<this.Expandos.Count; i++)
			{
				e = this.Expandos[i];

				// go to the next expando if this one is invisible
				if (!e.Visible)
				{
					continue;
				}

                p = new Point(this.BarPadding.Left, y);

				// set the width and location of the control
				e.Location = p;
				e.Width = width;

				// update the next starting point
				y += e.Height + this.BarPadding.Bottom;
			}

			// restart the layout engine
			this.ResumeLayout(true);
		}


		/// <summary>
		/// Updates the layout of the XExpandos while in design mode, and 
		/// adds/removes XExpandos from the ControlCollection as necessary
		/// </summary>
		internal void UpdateXExpandos()
		{
			if (this.Expandos.Count == this.Controls.Count)
			{
				// make sure the the expandos index in the ControlCollection 
				// are the same as in the XExpandoCollection (indexes in the 
				// XExpandoCollection may have changed due to the user moving 
				// them around in the editor)
				this.MatchControlCollToXExpandoColl();				
				
				return;
			}

			// were any expandos added
			if (this.Expandos.Count > this.Controls.Count)
			{
				// add any extra expandos in the XExpandoCollection to the 
				// ControlCollection
				for (int i=0; i<this.Expandos.Count; i++)
				{
					if (!this.Controls.Contains(this.Expandos[i]))
					{
						this.OnExpandoAdded(new XTaskBarEventArgs(this, this.Expandos[i]));
					}
				}
			}
			else
			{
				// expandos were removed
				int i = 0;
				XExpando expando;

				// remove any extra expandos from the ControlCollection
				while (i < this.Controls.Count)
				{
					expando = (XExpando) this.Controls[i];
					
					if (!this.Expandos.Contains(expando))
					{
						this.OnExpandoRemoved(new XTaskBarEventArgs(this, expando));
					}
					else
					{
						i++;
					}
				}
			}
		}


		/// <summary>
		/// Make sure the the expandos index in the ControlCollection 
		/// are the same as in the XExpandoCollection (indexes in the 
		/// XExpandoCollection may have changed due to the user moving 
		/// them around in the editor or calling XExpandoCollection.Move())
		/// </summary>
		internal void MatchControlCollToXExpandoColl()
		{
			this.SuspendLayout();
				
			for (int i=0; i<this.Expandos.Count; i++)
			{
				this.Controls.SetChildIndex(this.Expandos[i], i);
			}

			this.ResumeLayout(false);
				
			this.DoLayout();

			this.Invalidate(true);
		}

		#endregion

		#endregion

		#region Properties
		
		[Browsable(false)]
		public bool Initializing
		{
			get {return this.initializing;}
		}

		#region Theme
		[Bindable(true),
		Category("追加プロパティ"), 
		DefaultValue(false),
		Description("TaskBar의 테마를 클래식 Style로 적용할지 여부를 관리합니다.")]
		public bool IsClassicTheme
		{
			get { return this.isClassicTheme;}
			set 
			{
				if (isClassicTheme != value)
				{
					isClassicTheme = value;
					if (value)
						this.UseClassicTheme();
					else
						this.UseDefaultTheme();
				}
			}
		}
		[Bindable(true),
		Category("追加プロパティ"), 
		DefaultValue(true),
		Description("Expando를 Click시에 확대,축소할수 있는지 여부를 관리합니다.(false시에는 확대,축소불가)")]
		public bool IsExpandoChangable
		{
			get { return this.isExpandoChangable;}
			set 
			{
				if (isExpandoChangable != value)
				{
					isExpandoChangable = value;
					this.Invalidate(true);
				}
			}
		}
		#endregion

		#region Animation

		/// <summary>
		/// Expando가 확장,축소될때 Animation을 적용할지 여부를 관리합니다.
		/// </summary>
		[Bindable(true),
		Category("追加プロパティ"), 
		DefaultValue(false),
		Description("Expando가 확장,축소될때 Animation을 적용할지 여부를 관리합니다.")]
		public bool Animate
		{
			get { return this.animate;}
			set	{ this.animate = value;}
		}


		/// <summary>
		/// 애니메이션 중인지를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public bool IsAnimating
		{
			get	{ return this.animationHelpers.Count > 0;}
		}
		#endregion

		#region Border
		internal XTaskBarBorder Border
		{
			get { return this.taskBarSetting.TaskBar.Border;}
		}
		internal Color BorderColor
		{
			get	{ return this.taskBarSetting.TaskBar.BorderColor;}
		}
		#endregion

		#region Colors
		internal Color GradientStartColor
		{
			get	{ return this.taskBarSetting.TaskBar.GradientStartColor;}
		}
		internal Color GradientEndColor
		{
			get	{ return this.taskBarSetting.TaskBar.GradientEndColor;}
		}
		internal LinearGradientMode GradientDirection
		{
			get	{ return this.taskBarSetting.TaskBar.GradientDirection;}
		}
		#endregion

		#region XExpandos
		/// <summary>
		/// TaskBar에 포함되는 Expando를 관리합니다.
		/// </summary>
		[Category("追加プロパティ"),
		DefaultValue(null), 
		Description("TaskBar에 포함되는 Expando를 관리합니다."), 
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), 
		Editor(typeof(XExpandoCollectionEditor), typeof(UITypeEditor))]
		public XTaskBar.XExpandoCollection Expandos
		{
			get	{ return this.expandoCollection;}
		}
		/// <summary>
		/// Controls 속성 Hide
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Control.ControlCollection Controls
		{
			get { return base.Controls;}
		}
		#endregion

		#region Images
		internal Image BackImage
		{
			get	{ return this.taskBarSetting.TaskBar.BackImage;}
		}
		internal Image Watermark
		{
			get	{ return this.taskBarSetting.TaskBar.Watermark;}
		}
		internal ContentAlignment WatermarkAlignment
		{
			get	{ return this.taskBarSetting.TaskBar.WatermarkAlignment;}
		}

		#endregion

		#region Padding
        //<VS.2005> Control의 Padding과 중복됨, Padding -> BarPadding으로 변경
		internal XTaskBarPadding BarPadding
		{
			get	{ return this.taskBarSetting.TaskBar.Padding;}
		}
		#endregion

		#region TaskBarSetting
		internal XTaskBarSetting TaskBarSetting
		{
			get	{ return this.taskBarSetting;}
			set
			{
				if (value == null)
					return;
				
				if (this.taskBarSetting != value)
				{
					if (this.taskBarSetting != null)
					{
						this.taskBarSetting.Dispose();
						this.taskBarSetting = null;
					}

					this.taskBarSetting = value;
					this.BackColor = this.taskBarSetting.TaskBar.GradientStartColor;
					this.BackgroundImage = this.BackImage;

					foreach (XExpando expando in this.Expandos)
					{
						expando.TaskBarSetting = this.taskBarSetting;
						expando.DoLayout();
					}

					this.DoLayout();

					this.Invalidate(true);
				}
			}
		}
		#endregion

    	#endregion

		#region EventInvoker Override
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);

			// make sure the control is an XExpando
			if ((e.Control as XExpando) == null)
			{
				// remove the control
				this.Controls.Remove(e.Control);

				// throw a hissy fit
				throw new InvalidCastException("TaskBar에는 Expando만 추가가능합니다.");
			}
			if (this.DesignMode && !this.Expandos.Contains((XExpando) e.Control))
			{
				this.Expandos.Add((XExpando) e.Control);
			}
		}
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);

            // make sure the control is an XExpando
            if ((e.Control as XExpando) == null)
            {
                // remove the control
                this.Controls.Remove(e.Control);
            }
            //2006.07.25 Expando를 개발자가 Delete Key를 눌러 삭제시에 Expandos Collection에서 Remove 처리
            //기존에는 이 Logic이 없어서 개발자가 Expando를 지워도 Expandos Collection에는 그대로 남는 문제 발생
            if (this.DesignMode && this.Expandos.Contains((XExpando)e.Control))
            {
                this.Expandos.Remove((XExpando)e.Control);
            }
        }
		#endregion

		#region EventInvoker
		/// <summary> 
		/// Event handler for the XExpando StateChanged event
		/// </summary>
		private void expando_StateChanged(XExpandoEventArgs e)
		{
			OnExpandoStateChanged(new XTaskBarEventArgs(this, e.Expando));
		}
		protected virtual void OnExpandoStateChanged(XTaskBarEventArgs e)
		{
			// if we are in design mode, don't animate as the gripper thingys
			// that are shown around the outside of the expando are incorrect
			// once the animation has finished.  instead, go straight to
			// being collapsed/expanded
			if (this.DesignMode)
			{
				if (e.Expando.Collapsed)
				{
					e.Expando.Collapse();
				}
				else
				{
					e.Expando.Expand();
				}

				// re-align the expandos
				this.DoLayout();
			}
				// start the animation if we are able to animate and we aren't 
				// initializing the taskBar
			else if (this.Animate && !this.initializing)
			{
				this.StartFadeAnimation(e.Expando);
			}
			else
			{
				// if we get here, the XExpando has collapsed/expanded itself
				// so we need to update the layout of the controls
				this.DoLayout();

				// sometimes the background colors doesn't update correctly,
				// so get the XTaskBar to repaint itself (without painting
				// the XExpandos)
				this.Invalidate(false);
			}
			
			if (ExpandoStateChanged != null)
				ExpandoStateChanged(e);
		}
		protected virtual void OnExpandoAdded(XTaskBarEventArgs e)
		{
			// add the expando to the ControlCollection if it hasn't already
			if (!this.Controls.Contains(e.Expando))
			{
				this.Controls.Add(e.Expando);
			}

			// set anchor styles
			e.Expando.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);		
			
			// tell the XExpando who's its daddy...
			e.Expando.TaskBar = this;
			e.Expando.TaskBarSetting = this.taskBarSetting;

			// listen for collapse/expand events
			e.Expando.StateChanged += new XExpandoEventHandler(this.expando_StateChanged);

			// update the layout of the controls
			this.DoLayout();

			if (ExpandoAdded != null)
				ExpandoAdded(e);
		}
		protected virtual void OnExpandoRemoved(XTaskBarEventArgs e)
		{
			// remove the control from the ControlCollection if it hasn't already
			if (this.Controls.Contains(e.Expando))
				this.Controls.Remove(e.Expando);

			// remove the StateChanged listener
			e.Expando.StateChanged -= new XExpandoEventHandler(this.expando_StateChanged);

			// update the layout of the controls
			this.DoLayout();

			if (ExpandoRemoved != null)
				ExpandoRemoved(e);
		}
		#endregion

		#region Paint
		protected override void OnPaint(PaintEventArgs e)
		{
			// paint background
			if (this.BackImage == null)
			{
				using (LinearGradientBrush brush = new LinearGradientBrush(this.DisplayRectangle, 
						   this.GradientStartColor, 
						   this.GradientEndColor, 
						   this.GradientDirection))
				{
					e.Graphics.FillRectangle(brush, this.DisplayRectangle);
				}
			}

			// draw the watermark if we have one
			if (this.Watermark != null)
			{
				Rectangle rect = new Rectangle(0, 0, this.Watermark.Width, this.Watermark.Height);

				// work out a rough location of where the watermark should go

				switch (this.WatermarkAlignment)
				{
					case ContentAlignment.BottomCenter:
					case ContentAlignment.BottomLeft:
					case ContentAlignment.BottomRight:
					{
						rect.Y = this.DisplayRectangle.Bottom - this.Watermark.Height;
						
						break;
					}

					case ContentAlignment.MiddleCenter:
					case ContentAlignment.MiddleLeft:
					case ContentAlignment.MiddleRight:
					{
						rect.Y = this.DisplayRectangle.Top + ((this.DisplayRectangle.Height - this.Watermark.Height) / 2);
						
						break;
					}
				}

				switch (this.WatermarkAlignment)
				{
					case ContentAlignment.BottomRight:
					case ContentAlignment.MiddleRight:
					case ContentAlignment.TopRight:
					{
						rect.X = this.ClientRectangle.Right - this.Watermark.Width;
						
						break;
					}

					case ContentAlignment.BottomCenter:
					case ContentAlignment.MiddleCenter:
					case ContentAlignment.TopCenter:
					{
						rect.X = this.ClientRectangle.Left + ((this.ClientRectangle.Width - this.Watermark.Width) / 2);
						
						break;
					}
				}

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

				// draw the watermark
				e.Graphics.DrawImage(this.Watermark, rect);
			}
		}

		#endregion

		#region System Colors

		/// <summary> 
		/// Raises the SystemColorsChanged event
		/// </summary>
		protected override void OnSystemColorsChanged(EventArgs e)
		{
			base.OnSystemColorsChanged(e);

			// don't go any further if we are explicitly using
			// the classic or a custom theme
			if (this.isClassicTheme)
				return;

			this.SuspendLayout();

			// get rid of the current system theme info
			this.taskBarSetting.Dispose();
			this.taskBarSetting = null;

			// get a new system theme info for the new theme
			this.taskBarSetting = XTaskBarUtil.GetTaskBarSetting();
			
			this.BackgroundImage = this.BackImage;


			// update the system settings for each expando
			foreach (Control control in this.Controls)
			{
				if (control is XExpando)
				{
					XExpando expando = (XExpando) control;
					
					expando.TaskBarSetting = this.taskBarSetting;
				}
			}

			// update the layout of the controls
			this.DoLayout();
		}

		#endregion

		#region XExpandoCollection
		public class XExpandoCollection : CollectionBase
		{
			#region Fields
			private XTaskBar owner;
			#endregion

			#region Properties
			public virtual XExpando this[int index]
			{
				get
				{
					return this.List[index] as XExpando;
				}
			}
			#endregion

			#region Constructor
			public XExpandoCollection(XTaskBar owner) : base()
			{
				if (owner == null)
				{
					throw new ArgumentNullException("Owner가 지정되지 않았습니다.");
				}
				this.owner = owner;
			}

			#endregion

			#region Methods
			public void Add(XExpando value)
			{
				if (value == null)
				{
					throw new ArgumentNullException("XExpando가 지정되지 않았습니다.");
				}

				this.List.Add(value);
				this.owner.Controls.Add(value);

				this.owner.OnExpandoAdded(new XTaskBarEventArgs(this.owner, value));
			}
			public void AddRange(XExpando[] expandos)
			{
				if (expandos == null)
				{
					throw new ArgumentNullException("XExpando[]가 지정되지 않았습니다.");
				}

				for (int i=0; i<expandos.Length; i++)
				{
					this.Add(expandos[i]);
				}
			}
			public new void Clear()
			{
				while (this.Count > 0)
				{
					this.RemoveAt(0);
				}
			}
			public bool Contains(XExpando expando)
			{
				return (this.IndexOf(expando) != -1);
			}
			public int IndexOf(XExpando expando)
			{
				if (expando == null)
					return -1;

				for (int i=0; i<this.Count; i++)
					if (this[i] == expando)
						return i;
				return -1;
			}
			public void Remove(XExpando value)
			{
				if (value == null) return;

				this.List.Remove(value);
                this.owner.Controls.Remove(value);
                this.owner.OnExpandoRemoved(new XTaskBarEventArgs(this.owner, value));
			}
			public new void RemoveAt(int index)
			{
				this.Remove(this[index]);
			}
			public void Move(XExpando value, int index)
			{
				if (value == null) return;

				// make sure the index is within range
				if (index < 0)
				{
					index = 0;
				}
				else if (index > this.Count)
				{
					index = this.Count;
				}

				// don't go any further if the expando is already 
				// in the desired position or we don't contain it
				if (!this.Contains(value) || this.IndexOf(value) == index)
				{
					return;
				}

				this.List.Remove(value);

				if (index > this.Count)
				{
					this.List.Add(value);
				}
				else
				{
					this.List.Insert(index, value);
				}

				// 다시 그리기
				this.owner.MatchControlCollToXExpandoColl();
			}
			public void MoveToTop(XExpando value)
			{
				this.Move(value, 0);
			}
			public void MoveToBottom(XExpando value)
			{
				this.Move(value, this.Count);
			}
			#endregion
		}

		#endregion
	
		#region XExpandoCollectionEditor
		internal class XExpandoCollectionEditor : CollectionEditor
		{
			public XExpandoCollectionEditor(Type type) : base(type)
			{
			}
			public override object EditValue(ITypeDescriptorContext context, IServiceProvider isp, object value)
			{
				XTaskBar originalControl = (XTaskBar) context.Instance;
				object returnObject = base.EditValue(context, isp, value);

				originalControl.UpdateXExpandos();
				return returnObject;
			}
			protected override object CreateInstance(Type itemType)
			{
				object expando = base.CreateInstance(itemType);
			
				((XExpando) expando).Name = "expando";
			
				return expando;
			}
		}
		#endregion
	}

	#endregion

	#region XTaskBarDesigner
	internal class XTaskBarDesigner : ScrollableControlDesigner
	{
        //2006.07.25 .NET 2003에서는 Expando를 제거하지 않은 상태에서 TaskBar를 삭제해도 문제가 발생하지 않았으나,
        //.NET 2005에서는 Expando가 있는 상태에서 TaskBar를 삭제시에 base.Dispose에서 에러가 발생함.(정확한 원인은 알수 없음)
        // <현상> TaskBar에 Expando가 있는 경우, Expando 위에 TaskBarItem가 있는 경우
        // <해결> XTaskBarDesinger에서 TaskBar가 삭제될때 Expandos 도 함께 삭제,
        //        XExpandoDesinger에서 Expando가 삭제될때 Items에 있는 TaskBarItem도 함께 삭제

        private XTaskBar taskBar = null;
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
            taskBar = (XTaskBar)component;

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
                //복사, 끌기 또는 이동 작업 중에 디자이너가 관리하는 구성 요소와 함께 복사 또는 이동할 구성 요소를 지정
                return taskBar.Expandos;
            }
        }

        private void OnComponentRemoving(object sender, ComponentEventArgs e)
        {
            //XTaskBar가 제거될때 관련된 XExpando도 같이 제거
            if (e.Component == taskBar)
            {
                XExpando expando = null;
                for (int idx = taskBar.Expandos.Count - 1; idx >= 0; idx--)
                {
                    expando = taskBar.Expandos[idx];
                    iComp.OnComponentChanging(taskBar, null);
                    taskBar.Expandos.Remove(expando);
                    iHost.DestroyComponent(expando);
                    iComp.OnComponentChanged(taskBar, null, null, null);
                }
            }
        }

		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			base.PreFilterProperties(properties);
			//필요없는 Property 제거
			properties.Remove("BackColor");
			properties.Remove("BackgroundImage");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("RightToLeft");
			properties.Remove("Text");
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

	#region XTaskBarAnimationHelper
	internal class XTaskBarAnimationHelper
	{
		#region Fields
		// animation types
		internal static int FadeAnimation = 1;
		internal static int SlideAnimation = 2;


		// the type of animation to perform
		private int animationType;

		// the XTaskBar the helper belongs to
		private XTaskBar taskBar;

		// the XExpando to animate
		private XExpando expando;

		// current frame in animation
		private int animationStepNum;

		// number of frames in the animation
		private int numAnimationSteps;

		// the amount of time each frame is shown (in milliseconds)
		private int animationFrameInterval;

		// are we currently animating
		private bool animating;

		// a timer to tell us when the next frame is due
		private Timer animationTimer;
		#endregion

		#region Properties
		public XTaskBar XTaskBar
		{
			get	{ return this.taskBar;}
		}
		public XExpando XExpando
		{
			get	{ return this.expando;}
		}
		public int NumAnimationSteps
		{
			get	{ return this.numAnimationSteps;}
			set
			{
				if (!this.animating)
					this.numAnimationSteps = Math.Max(value,0);
			}
		}
		public int AnimationFrameInterval
		{
			get	{ return this.animationFrameInterval;}
			set	{ this.animationFrameInterval = value;}
		}
		public bool Animating
		{
			get	{ return this.animating;}
		}
		public int AnimationType
		{
			get	{ return this.animationType;}
		}
		#endregion

		#region Constructor
		public XTaskBarAnimationHelper(XTaskBar taskBar, XExpando expando, int animationType)
		{
			this.taskBar = taskBar;
			this.expando = expando;
			this.animationType = animationType;

			this.animating = false;

			this.numAnimationSteps = 20;
			this.animationFrameInterval = 10;

			// I know that this isn't the best way to do this, but I 
			// haven't quite worked out how to do it with threads so 
			// this will have to do for the moment
			this.animationTimer = new Timer();
			this.animationTimer.Tick += new EventHandler(this.animationTimer_Tick);
			this.animationTimer.Interval = this.animationFrameInterval;
		}
		#endregion

		#region Methods

		/// <summary>
		/// Starts the XExpando collapse/expand animation
		/// </summary>
		public void StartAnimation()
		{
			// don't bother going any further if we are already animating
			if (this.Animating)
			{
				return;
			}
			
			this.animationStepNum = 0;

			// tell the expando to get ready to animate
			if (this.AnimationType == FadeAnimation)
			{
				this.expando.StartFadeAnimation();
			}
			else
			{
				this.expando.StartSlideAnimation();
			}

			// start the animation timer
			this.animationTimer.Start();
		}


		/// <summary>
		/// Updates the animation for the XExpando
		/// </summary>
		public void PerformAnimation()
		{
			// if we have more animation steps to perform
			if (this.animationStepNum < this.numAnimationSteps)
			{
				// update the animation step number
				this.animationStepNum++;

				// tell the animating expando to update the animation
				if (this.AnimationType == FadeAnimation)
				{
					this.expando.UpdateFadeAnimation(this.animationStepNum, this.numAnimationSteps);
				}
				else
				{
					this.expando.UpdateSlideAnimation(this.animationStepNum, this.numAnimationSteps);
				}

				// rearrange the groups
				this.taskBar.DoLayout();
			}
			else
			{
				// stop the animation
				this.animationTimer.Stop();

				if (this.AnimationType == FadeAnimation)
				{
					this.expando.StopFadeAnimation();
				}
				else
				{
					this.expando.StopSlideAnimation();
				}

				// let the XTaskBar know that the animation has finished
				// so it can do some cleaning up (like getting rid of us)
				this.taskBar.AnimationStopped(this);
			}
		}

		#endregion

		#region Events
		private void animationTimer_Tick(object sender, EventArgs e)
		{
			// do the next bit of the aniation
			this.PerformAnimation();
		}
		#endregion
	}

	#endregion

	#region XTaskBarEventHandler
	public delegate void XTaskBarEventHandler(XTaskBarEventArgs e);
	
	/// <summary>
	/// Summary description for XTaskBarEventArgs.
	/// </summary>
	public class XTaskBarEventArgs : EventArgs
	{
		#region Fields
		private XTaskBar taskBar;
		private XExpando expando;
		#endregion

		#region Properties
		public XTaskBar TaskBar
		{
			get	{ return this.taskBar;}
		}
		public XExpando Expando
		{
			get	{return this.expando;}
		}
		#endregion

		#region 생성자
		public XTaskBarEventArgs() : this(null, null)
		{
		}
		public XTaskBarEventArgs(XTaskBar taskBar) : this(taskBar, null)
		{
		}
		public XTaskBarEventArgs(XTaskBar taskBar, XExpando expando) : base()
		{
			this.taskBar = taskBar;
			this.expando = expando;
		}
		#endregion
	}
	#endregion
}
