using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace IHIS.Framework
{
	/// <summary>
	/// ImageButton에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxBitmap(typeof(IHIS.Framework.XImageButton), "Images.XButton.bmp")]
	public class XImageButton : System.Windows.Forms.Control, IButtonControl
	{
		#region enum
		/// <summary>
		/// Button의 상태를 나타내는 Enum입니다.
		/// </summary>
		private enum States
		{
			/// <summary>
			/// 기본 상태
			/// </summary>
			Normal,
			/// <summary>
			/// Hover 상태
			/// </summary>
			MouseOver,
			/// <summary>
			/// Pushed 상태
			/// </summary>
			Pushed
		}
		#endregion

		#region Private Fields
		private System.ComponentModel.Container components = null;
		private Rectangle bounds;
		private Image normalImage;
		private Image pushedImage;
		private Image hoveredImage;
		private States state = States.Normal;
		private bool isLeftButtonClick = true;
		#endregion

		#region 생성자
		/// <summary>
		/// ImageButton 생성자
		/// </summary>
		public XImageButton()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(ControlStyles.StandardDoubleClick, false);
			this.SetStyle(ControlStyles.Selectable, true);
		}
		/// <summary>
		/// 컨트롤에서 사용하는 리소스를 모두 해제합니다.
		/// </summary>
		/// <param name="disposing"> Dispose 여부 </param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{	
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region base Properties not Browsable
		/// <summary>
		/// 컨트롤의 배경색을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override Color BackColor
		{
			get {return base.BackColor;}
			set {base.BackColor = value;}
		}
		/// <summary>
		/// 컨트롤의 전경색을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override Color ForeColor
		{
			get {return base.ForeColor;}
			set {base.ForeColor = value;}
		}
		/// <summary>
		/// 컨트롤에 표시할 배경 이미지를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override Image BackgroundImage 
		{
			get { return base.BackgroundImage;}
			set { base.BackgroundImage = value;}
		}
		/// <summary>
		/// 오른쪽에서 왼쪽으로 쓰는 글꼴을 사용하는 로케일을 지원하도록 컨트롤 요소가 정렬되어 있는지 여부를 나타내는 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public override RightToLeft RightToLeft 
		{
			get { return base.RightToLeft;}
			set { base.RightToLeft = value;}
		}
		
		// OnPaint에서 Heigh - 8 로 하여 Draw하는데, 이때 height - 8 = 0 이면 Error발생, height는 10이하는 안됨
		/// <summary>
		/// 컨트롤의 높이를 가져오거나 설정합니다.
		/// </summary>
		public new int Height
		{
			get { return ( base.Height > 8 ? base.Height : 10);}
			set { base.Height = (value > 8 ? value : 10); }
		}

		#endregion

		#region Properties
		/// <summary>
		/// 버튼의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(null),
		MergableProperty(true),
		Description("버튼의 일반상태 Image을 설정합니다.")]
		public Image NormalImage
		{
			get { return normalImage; }
			set
			{
				if ( normalImage != value)
				{
					normalImage = value;
					this.Invalidate();
				}
			}
		}
		/// <summary>
		/// 버튼의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(null),
		MergableProperty(true),
		Description("버튼의 눌려진상태 Image을 설정합니다.")]
		public Image PushedImage
		{
			get { return pushedImage; }
			set
			{
				if ( pushedImage != value)
				{
					pushedImage = value;
					this.Invalidate();
				}
			}
		}
		/// <summary>
		/// 버튼의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("Appearance"),
		DefaultValue(null),
		MergableProperty(true),
		Description("버튼의 Hover상태 Image을 설정합니다.")]
		public Image HoveredImage
		{
			get { return hoveredImage; }
			set
			{
				if ( hoveredImage != value)
				{
					hoveredImage = value;
					this.Invalidate();
				}
			}
		}
		#endregion
		
		#region Override Method
		/// <summary>
		/// MouseMove Event를 발생시킵니다.
		/// (override) 버튼의 상태에 따라 모양을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			//if (this.Parent != null && !this.Parent.ContainsFocus) return;
			base.OnMouseMove(e);

			if (bounds.Contains(e.X, e.Y))
			{
				if (state == States.Normal)
				{
					state = States.MouseOver;
					this.Invalidate(bounds);
				}
			}
			else
			{
				if (state != States.Normal)
				{
					state = States.Normal;
					this.Invalidate(bounds);
				}
			}
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseLeave(System.EventArgs e)
		{
			base.OnMouseLeave(e);
			if (state != States.Normal)
			{
				state = States.Normal;
				this.Invalidate(bounds);
			}
		}
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// (override) 버튼의 상태에 따라 모양을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			this.isLeftButtonClick = false;

			base.OnMouseDown(e);
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;
			
			//LeftButton Click
			this.isLeftButtonClick = true;

			if (bounds.Contains(e.X, e.Y))
			{
				state = States.Pushed;
				this.Focus();
			} 
			else
			{
				state = States.Normal;
			}
			this.Invalidate(bounds);
		}
		/// <summary>
		/// MouseUp Event를 발생시킵니다.
		/// (override) 버튼의 상태에 따라 모양을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 MouseEventArgs </param>
		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				state = States.Normal;
				this.Invalidate(bounds);
			}
		}
		/// <summary>
		/// KeyDown Event를 발생시킵니다.
		/// (override) Space Key입력시 MouseDown Event를 발생시킵니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 KeyEventArgs </param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Space)
			{
				//MouseDown
				OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, 2, 2, 0));
				//Click
				OnClick(EventArgs.Empty);
			}
		}
		/// <summary>
		/// 버튼의 색깔톤, 상태에 따라 버튼을 그립니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 PaintEventArgs </param>
		protected override void OnPaint(PaintEventArgs e)
		{
			Image drawImage = this.normalImage;
			//Disabled
			if (!this.Enabled && (normalImage != null))
				ControlPaint.DrawImageDisabled(e.Graphics, drawImage, 0, 0, this.BackColor);
			else
			{
				if (state == States.Pushed)
					drawImage = this.pushedImage;
				else if (state == States.MouseOver)
					drawImage = this.hoveredImage;
				if (drawImage != null)
					e.Graphics.DrawImageUnscaled(drawImage, 0,0);
				else
					e.Graphics.FillRectangle(Brushes.LightGray, e.ClipRectangle);

			}
		}
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnClick(EventArgs e)
		{
			// LeftButton Click시만 OnClick Call
			if (this.isLeftButtonClick)
			{
				if (state == States.Pushed)
				{
					state = States.Normal;
					this.Invalidate(bounds);
				}

				base.OnClick(e);
				// DialogResult가 None이 아니면 Form에 Result를 전달하여  Form Close
				if (this.DialogResult != DialogResult.None)
					if( this.TopLevelControl is Form)
						((Form)this.TopLevelControl).DialogResult = this.DialogResult;
			}
		}
		/// <summary>
		/// ParentChanged Event를 발생시킵니다.
		/// (override) 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>	
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			if (this.Parent == null) return;

			int X = this.Width;
			int Y = this.Height;

			this.bounds = new Rectangle(0, 0, X, Y);

			//this.BackColor = Color.FromArgb(0, this.Parent.BackColor);
			
			Point[] points = {
								 new Point(1, 0),
								 new Point(X-1, 0),
								 new Point(X-1, 1),
								 new Point(X, 1),
								 new Point(X, Y-1),
								 new Point(X-1, Y-1),
								 new Point(X-1, Y),
								 new Point(1, Y),
								 new Point(1, Y-1),
								 new Point(0, Y-1),
								 new Point(0, 1),
								 new Point(1, 1)};

			GraphicsPath path = new GraphicsPath();
			path.AddLines(points);

			this.Region = new Region(path);

		}
		/// <summary>
		/// Resize Event를 발생시킵니다.
		/// (override) 그리기 영역을 다시 설정합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>	
		protected override void OnResize(EventArgs e)
		{
			bounds = new Rectangle(0, 0, this.Width, this.Height);
			OnParentChanged(e);
			base.OnResize(e);
			this.Invalidate(bounds);
		}
		/// <summary>
		/// EnabledChanged Event를 발생시킵니다.
		/// (override) 활성,비활성에 따라 버튼을 다시 그립니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);
			this.Invalidate(bounds);
		}
		#endregion

		#region IButtonControl Implementation
		private DialogResult dialogResult = DialogResult.None;
		/// <summary>
		/// 모달 폼의 결과값을 가져오거나 설정합니다.
		/// </summary>
		[Category("Action"),
		DefaultValue(DialogResult.None),
		MergableProperty(true),
		Browsable(true),
		Description("모달 폼의 결과값을 지정합니다.")]
		public DialogResult DialogResult
		{
			get { return dialogResult;}
			set { dialogResult = value;}
		}
		// Button이 Default Button일때 Enter , Esc 키를 누르면 Call되는 Method
		// Form의 AcceptButton, CancelButton으로 지정되었거나, NotifyDefault의 value가 True이면 Key에 의해 발생함
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// </summary>
		public virtual void PerformClick()
		{
			// Click Event Call
			this.isLeftButtonClick = true;  // LeftButtonClick
			OnClick(EventArgs.Empty);
		}
		// Do Nothing
		/// <summary>
		/// 해당 모양과 동작이 적절하게 조정되도록 이 단추가 기본 단추임을 컨트롤에 알립니다.
		/// </summary>
		/// <param name="value"> 컨트롤이 기본 단추로 동작해야 하면 true이고, 그렇지 않으면 false </param>
		public virtual void NotifyDefault(bool value){}
		#endregion
	}
}
