using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	/// <summary>
	/// CustomScrollControl class(Grid의 base class)에 대한 요약설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CustomScrollControl : System.Windows.Forms.UserControl
	{
		#region Fields
		private System.ComponentModel.Container components = null;
		private int oldVScrollValue = 0;  // VScroll의 이전값 저장
		private int oldHScrollValue = 0;  // HScroll의 이전값 저장
		/// <summary>
		/// VScrollBar
		/// </summary>
		protected XVScrollBar VScrollBar = null;
		/// <summary>
		/// HScrollBar
		/// </summary>
		protected XHScrollBar HScrollBar = null;
		protected bool DisplayCompleted = false;
		private Label bottomRightPan = null;
		private Size customScrollArea = new Size(0,0);  // Scroll할 수 있는 Area 저장
		private bool showBottomRightImage = true;
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		#region 생성자
		/// <summary>
		/// CustomScrollControl 생성자
		/// </summary>
		public CustomScrollControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// AutoScroll은 허용하지 않음
			base.AutoScroll = false;
		}
		#endregion

		#region Dispose
		/// <summary> 
		/// 사용된 모든 자원을 Clear 합니다.
		/// </summary>
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
		
		#region New, Override Property
		/// <summary>
		/// AutoScroll 속성을 가져오거나 설정합니다.(true는 불가)
		/// </summary>
		[Browsable(false)]
		public override bool AutoScroll
		{
			get{return false;}
			set
			{
				if (value)
					throw new ApplicationException("AutoScroll은 허용하지 않습니다.");
				base.AutoScroll = false;
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Grid의 RightBottom영역에 Image를 보여줄지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("Appearance"),
		DefaultValue(true),
		Description("Grid의 RightBottom영역에 Image를 보여줄지 여부를 설정합니다.")]
		public bool ShowBottomRightImage
		{
			get { return showBottomRightImage;}
			set 
			{ 
				if (showBottomRightImage != value)
				{
					showBottomRightImage = value;
					// ScrollBar 다시 계산
					RecalcCustomScrollBars();
				}
			}
		}
		/// <summary>
		/// ScrollControl의 Scroll영역을 가져오거나 설정합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public Size CustomScrollArea
		{
			get{return customScrollArea;}
			set
			{
				if (customScrollArea != value)
				{
					customScrollArea = value;
					// ScrollArea변경에 따른 ScrollBar, Panel 위치조정
					RecalcCustomScrollBars();
				}
			}
		}
		/// <summary>
		/// ScrollBar로 Scroll한 위치를 가져오거나 설정합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public Point CustomScrollPosition
		{
			get
			{
				int l_x = 0;
				if (HScrollBar!=null)
					l_x = -HScrollBar.Value;
				int l_y = 0;
				if (VScrollBar!=null)
					l_y = -VScrollBar.Value;
				return new Point(l_x,l_y);
			}
			set
			{
				if (HScrollBar!=null)
					HScrollBar.Value = -value.X;

				if (VScrollBar!=null)
				{
					VScrollBar.Value = -value.Y;
				}

			}
		}
		/// <summary>
		/// ScrollControl의 Client영역을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public Rectangle CustomClientRectangle
		{
			get
			{
				if (HScrollBar !=null && VScrollBar != null)
					return new Rectangle(ClientRectangle.X,ClientRectangle.Y,ClientRectangle.Width-VScrollBar.Width,ClientRectangle.Height-HScrollBar.Height);
				else if (HScrollBar == null && VScrollBar != null)
					return new Rectangle(ClientRectangle.X,ClientRectangle.Y,ClientRectangle.Width-VScrollBar.Width ,ClientRectangle.Height);
				else if (HScrollBar != null && VScrollBar == null)
					return new Rectangle(ClientRectangle.X,ClientRectangle.Y,ClientRectangle.Width,ClientRectangle.Height-HScrollBar.Height);
				else
					return ClientRectangle;
			}
		}
		/// <summary>
		/// VScrollBar의 상한값을 가져옵니다.
		/// </summary>
		[Description("VScrollBar의 상한값을 가져옵니다."),
		Browsable(false)]
		public int MaximumVScroll
		{
			get
			{
				if (VScrollBar == null)
					return 0;
				else
					return VScrollBar.Maximum;
			}
		}
		/// <summary>
		/// VScrollBar의 LargeChange 값을 가져옵니다.
		/// </summary>
		[Description("VScrollBar의 LargeChange 값을 가져옵니다."),
		Browsable(false)]
		public int LargeChangeVScroll
		{
			get
			{
				if (VScrollBar == null)
					return 0;
				else
					return VScrollBar.LargeChange;
			}
		}
		/// <summary>
		/// VScrollBar의 하한값을 가져옵니다.
		/// </summary>
		[Description("VScrollBar의 하한값을 가져옵니다."),
		Browsable(false)]
		public int MinimumVScroll
		{
			get {return 0;}
		}
		/// <summary>
		/// HScrollBar의 하한값을 가져옵니다.
		/// </summary>
		[Description("HScrollBar의 하한값을 가져옵니다."),
		Browsable(false)]
		public int MinimumHScroll
		{
			get	{return 0;}
		}
		/// <summary>
		/// HScrollBar의 상한값을 가져옵니다.
		/// </summary>
		[Description("HScrollBar의 상한값을 가져옵니다."),
		Browsable(false)]
		public int MaximumHScroll
		{
			get
			{
				if (HScrollBar == null)
					return 0;
				else
					return HScrollBar.Maximum;
			}
		}

		#endregion

		#region Protected Override Method
		/// <summary>
		/// SizeChanged Event를 발생시킵니다.
		/// (override) ScrollBar의 위치를 재조정합니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			// ClientRectangle에 따라 VScrollBar, HScrollBar를 생성 위치조정합니다.
			RecalcCustomScrollBars();
		}
		#endregion

		#region Proteced Virtual Method
		/// <summary>
		/// HScrollBar를 Remove합니다.
		/// </summary>
		[Description("HScrollBar를 Remove합니다.")]
		protected virtual void RemoveHScrollBar()
		{
			// Event Hander 제거, Control에서 HScrollBar 삭제
			if (HScrollBar != null)
			{
				HScrollBar.ValueChanged -= new EventHandler(HScrollChanged);
				Controls.Remove(HScrollBar);
				//<MEMORY LEAK> 2007.10.12 최초 Comment 처리됨, Dispose를 명시적으로 하지 않아서 leak 발생가능성 있음, Comment처리해제
				HScrollBar.Dispose();
				HScrollBar = null;
			}
		}
		/// <summary>
		/// VScrollBar를 Remove합니다.
		/// </summary>
		[Description("VScrollBar를 Remove합니다.")]
		protected virtual void RemoveVScrollBar()
		{
			// Event Hander 제거, Control에서 VScrollBar 삭제
			if (VScrollBar != null)
			{
				VScrollBar.ValueChanged -= new EventHandler(VScrollChanged);
				Controls.Remove(VScrollBar);
				//<MEMORY LEAK> 2007.10.12 최초 Comment 처리됨, Dispose를 명시적으로 하지 않아서 leak 발생가능성 있음, Comment처리해제
				VScrollBar.Dispose();
				VScrollBar = null;
			}		
		}

		/// <summary>
		/// HScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("HScrollBar의 위치를 조정합니다.")]
		protected virtual void RecalcHScrollBar()
		{
			if (HScrollBar == null)
			{
				//RecalcHScrollBar시에 VScroll이 있으면 VScrollBar.Value = 0
				if (VScrollBar != null)
				{
					VScrollBar.Value = Math.Max(VScrollBar.Minimum, VScrollBar.Value - VScrollBar.Width);
				}
				return;
			}

			// Location은 0, 전체높이 - ScrollBar의 높이
			HScrollBar.Location = new Point(0,ClientRectangle.Height-HScrollBar.Height);
			// ScrollBar의 Height는 HScrollBar가 있으면 Height고려, 없을때 bottomRightPan의 Height도 고려함.
			if (VScrollBar != null)
				HScrollBar.Width = ClientRectangle.Width- VScrollBar.Width;
			// RightBottomImage를 보여줄때 Pan이 있으면 Pan의 Height도 고려
			else if (this.showBottomRightImage && (this.bottomRightPan != null))
				HScrollBar.Width = ClientRectangle.Width - bottomRightPan.Width;
			else
				HScrollBar.Width = ClientRectangle.Width;

			HScrollBar.Minimum = 0;
			// 스크롤할 수 있는 범위의 상한 값 = ScrollArea만큼만 이동가능함
			HScrollBar.Maximum = Math.Max(0,customScrollArea.Width); //Math.Max(0,customScrollArea.Width - ClientRectangle.Width) + VScrollBar.Width;
			//스크롤 상자를 멀리 움직이는 경우 Value 속성에서 추가하거나 뺄 값
			try
			{
				HScrollBar.LargeChange = Math.Max(5,ClientRectangle.Width - VScrollBar.Width);
			}
			catch
			{
				HScrollBar.LargeChange = Math.Max(5,ClientRectangle.Width);
			}
			//스크롤 상자를 조금 움직일 때 Value 속성에서 추가하거나 뺄 값 
			HScrollBar.SmallChange = HScrollBar.LargeChange / 5;
			HScrollBar.BringToFront();
		}

		/// <summary>
		/// VScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("VScrollBar의 위치를 조정합니다.")]
		protected virtual void RecalcVScrollBar()
		{
			if (VScrollBar == null) return;

			VScrollBar.Location = new Point(ClientRectangle.Width-VScrollBar.Width,0);
			// ScrollBar의 Height는 HScrollBar가 있으면 Height고려, 없을때 bottomRightPan의 Height도 고려함.
			if (HScrollBar != null)
				VScrollBar.Height = ClientRectangle.Height- HScrollBar.Height;
			// RightBottomImage를 보여줄때 Pan이 있으면 Pan의 Height도 고려
			else if (this.showBottomRightImage && (this.bottomRightPan != null))
				VScrollBar.Height = ClientRectangle.Height- bottomRightPan.Height;
			else
				VScrollBar.Height = ClientRectangle.Height;
            
			VScrollBar.Minimum = 0;
			VScrollBar.Maximum = Math.Max(0,customScrollArea.Height);
			try
			{
				VScrollBar.LargeChange = Math.Max(5, ClientRectangle.Height - HScrollBar.Height);
			}
			catch
			{
				VScrollBar.LargeChange = Math.Max(5, ClientRectangle.Height);
			}
			VScrollBar.SmallChange = VScrollBar.LargeChange / 5;
			VScrollBar.BringToFront();
		}
		/// <summary>
		/// CustomScrollControl을 상속받은 Control의 Grid형식인지 Matrix형식인지여부를 가져옵니다.
		/// </summary>
		/// <returns> Grid형식이면 true, 아니면 false </returns>
		protected virtual bool IsGridType()
		{
			return true;
		}
		#endregion

		#region Public Method
		/// <summary>
		/// ClientRectangle에 따라 ScrollBar와 Panel을 Hide하거나 Show 위치조정합니다.
		/// </summary>
		public void RecalcCustomScrollBars()
		{
			try
			{
				Rectangle l_Client = ClientRectangle;
		
				bool isVScrollAdd = false;
				bool isHScrollAdd = false;
				//HScrollBar이 있으면 isVScrollAdd = l_Client.Height - HScrollBar.Height < customScrollArea.Height
				if (HScrollBar != null)
				{
					if (l_Client.Height - HScrollBar.Height < customScrollArea.Height)
						isVScrollAdd = true;
				}
				else
				{
					if (l_Client.Height < customScrollArea.Height)
						isVScrollAdd = true;
				}
				if (VScrollBar != null)
				{
					if (l_Client.Width - VScrollBar.Width < customScrollArea.Width)
						isHScrollAdd = true;
				}
				else
				{
					if (l_Client.Width < customScrollArea.Width)
						isHScrollAdd = true;
				}

				// 현재영역이 ScrollArea보다 작으면 Scrollbar Add
				if (isVScrollAdd || isHScrollAdd)
				{
					if (isVScrollAdd)
					{
						if (VScrollBar == null)
						{
							VScrollBar = new XVScrollBar(this);
							VScrollBar.DrawGripper = true;
							VScrollBar.ValueChanged += new EventHandler(VScrollChanged);
							Controls.Add(VScrollBar);
						}
					}
						// HScrollAdd만 있을 경우에는 VScroll Remove
					else 
					{
						oldVScrollValue = 0;
						RemoveVScrollBar();
						//Grid Type일 경우에는 bottomRightPan Remove
						if (IsGridType() && bottomRightPan != null)
						{
							bottomRightPan.Click -= new EventHandler(BottomRightPanClick);
							bottomRightPan.DoubleClick -= new EventHandler(BottomRightPanDoubleClick);
							Controls.Remove(bottomRightPan);
							//bottomRightPan.Dispose();
							bottomRightPan = null;
						}
					}
					//VScroll이 Added 될 수도 있으므로 isHScrollAdd 다시 판단
					if (!isHScrollAdd)
					{
						if (VScrollBar != null)
							if (l_Client.Width - VScrollBar.Width < customScrollArea.Width)
								isHScrollAdd = true;
					}
					else //Add일때 앞에서 VScrll이 Remove되었으면 l_Client.Width >= customScrollArea.Width 면 HScrollBar Remove
					{
						if(VScrollBar == null)
						{
							if (l_Client.Width >= customScrollArea.Width)
							{
								isHScrollAdd = false;
								oldHScrollValue = 0;
								RemoveHScrollBar();
								if (bottomRightPan != null)
								{
									bottomRightPan.Click -= new EventHandler(BottomRightPanClick);
									bottomRightPan.DoubleClick -= new EventHandler(BottomRightPanDoubleClick);
									Controls.Remove(bottomRightPan);
									//bottomRightPan.Dispose();
									bottomRightPan = null;
								}
							}
						}
					}
					if (isHScrollAdd)
					{
						if (HScrollBar == null)
						{
							HScrollBar = new XHScrollBar(this);
							HScrollBar.DrawGripper = true;
							HScrollBar.ValueChanged += new EventHandler(HScrollChanged);
							Controls.Add(HScrollBar);
						}
					}
					else // Remove HScroll
					{
						oldHScrollValue = 0;
						RemoveHScrollBar();
						if ((VScrollBar == null) && (bottomRightPan != null))
						{
							bottomRightPan.Click -= new EventHandler(BottomRightPanClick);
							bottomRightPan.DoubleClick -= new EventHandler(BottomRightPanDoubleClick);
							Controls.Remove(bottomRightPan);
							//bottomRightPan.Dispose();
							bottomRightPan = null;
						}
					}
					// GridType일때 VScrollBar 있으면 BottomRightPanel 추가
					if ((VScrollBar != null) && IsGridType())
					{
						if (bottomRightPan == null)
						{
							bottomRightPan = new Label();
							bottomRightPan.Click += new EventHandler(BottomRightPanClick);
							bottomRightPan.DoubleClick += new EventHandler(BottomRightPanDoubleClick);
							bottomRightPan.BackColor = Color.FromKnownColor(KnownColor.Control);
							bottomRightPan.Size = new Size(VScrollBar.Width, VScrollBar.Width);
							bottomRightPan.ImageAlign = ContentAlignment.MiddleCenter;
							// Image를 보여주면 Image Set
							if (this.showBottomRightImage)
							{
								if (this.DisplayCompleted)
									bottomRightPan.Image = XGridImage.Blueball;
								else
									bottomRightPan.Image = XGridImage.Redball;
							}
							//Controls에 Add시에 잔상이 보이지 않도록 Hide함
							bottomRightPan.Hide();
							Controls.Add(bottomRightPan);
						}
					}
						// HScrollBar가 있을때 MatrixType이면 bottomRightPan Add
					else if ((HScrollBar != null) && !IsGridType())
					{
						if (bottomRightPan == null)
						{
							bottomRightPan = new Label();
							bottomRightPan.Click += new EventHandler(BottomRightPanClick);
							bottomRightPan.DoubleClick += new EventHandler(BottomRightPanDoubleClick);
							bottomRightPan.BackColor = Color.FromKnownColor(KnownColor.Control);
							bottomRightPan.Size = new Size(HScrollBar.Height, HScrollBar.Height);
							bottomRightPan.ImageAlign = ContentAlignment.MiddleCenter;
							// Image를 보여주면 Image Set
							if (this.showBottomRightImage)
							{
								if (this.DisplayCompleted)
									bottomRightPan.Image = XGridImage.Blueball;
								else
									bottomRightPan.Image = XGridImage.Redball;
							}
							//Controls에 Add시에 잔상이 보이지 않도록 Hide함
							bottomRightPan.Hide();
							Controls.Add(bottomRightPan);
						}
					}
			
					// ScrollBar 위치조정
					RecalcVScrollBar();
					RecalcHScrollBar();
			
					//BottomRightPan Add
					//showBottomRightImage이면 GridType일때는 VScrollBar만 있어도 Add , MatrixType일때는 HScrllBar만 있어도 Add
					if (this.showBottomRightImage)
					{
						if ((VScrollBar != null) && IsGridType())
						{
							if (bottomRightPan != null)
							{
								// 위치 = Bottom, Right
								bottomRightPan.Location = new Point(ClientRectangle.Right - VScrollBar.Width,ClientRectangle.Bottom - VScrollBar.Width);
								bottomRightPan.Show();
								bottomRightPan.BringToFront();
							}
						}
						else if ((HScrollBar != null) && !IsGridType()) // Matrix Type
						{
							if (bottomRightPan != null)
							{
								// 위치 = Bottom, Right
								bottomRightPan.Location = new Point(ClientRectangle.Right - HScrollBar.Height,ClientRectangle.Bottom - HScrollBar.Height);
								bottomRightPan.Show();
								bottomRightPan.BringToFront();
							}
						}
					}
						// VScrollBar, HScrollBar 둘다 있으면 생성
					else
					{
						if (VScrollBar != null && HScrollBar != null)
						{
							if (bottomRightPan != null)
							{
								// 위치 = Bottom, Right
								bottomRightPan.Location = new Point(HScrollBar.Right,VScrollBar.Bottom);
								bottomRightPan.Show();
								bottomRightPan.BringToFront();
							}
						}
					}

					//VScroll Value 조정 (VScroll Value조정시 에러는 Catch)
					//Grid의 Height를 너무 작게 하면 LargeChange, Maxinum의 차이로 인해 Exception 발생가능함
					try
					{
						if (VScrollBar != null)
						{
							if (VScrollBar.Value + VScrollBar.LargeChange > VScrollBar.Maximum)
								VScrollBar.Value = VScrollBar.Maximum;
						}
					}
					catch{}
				}
					// 현재영역이 ScrollArea보다 크면 Reset, ScrollBar, Panel Remove
				else
				{
					oldHScrollValue = 0;
					oldVScrollValue = 0;
					RemoveVScrollBar();
					RemoveHScrollBar();

					if (bottomRightPan != null)
					{
						bottomRightPan.Click -= new EventHandler(BottomRightPanClick);
						bottomRightPan.DoubleClick -= new EventHandler(BottomRightPanDoubleClick);
						Controls.Remove(bottomRightPan);
						//bottomRightPan.Dispose();
						bottomRightPan = null;
					}
				}
			}
			catch{}
		}
		
		/// <summary>
		/// BottomRight의 Image를 Click시 발생합니다.
		/// </summary>
		protected virtual void OnBottomRightImageClick(){}
		/// <summary>
		/// BottomRight의 Image를 DoubleClick시 발생합니다.
		/// </summary>
		protected virtual void OnBottomRightImageDoubleClick(){}
		/// <summary>
		/// PageDown Key 입력시 VScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("PageDown시에 VScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollPageDown()
		{
			//Value의 가용값은 최대가 Maxinum - LargeChange 임
			if (VScrollBar!=null)
				VScrollBar.Value = Math.Min(VScrollBar.Value + VScrollBar.LargeChange, VScrollBar.Maximum - VScrollBar.LargeChange);
		}
		/// <summary>
		/// PageUp Key 입력시 VScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("PageUp시에 VScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollPageUp()
		{
			if (VScrollBar!=null)
				VScrollBar.Value = Math.Max(VScrollBar.Value - VScrollBar.LargeChange, VScrollBar.Minimum);
		}
		/// <summary>
		/// Right Key 입력시 HScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("Right시에 HScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollPageRight()
		{
			if (HScrollBar!=null)
				HScrollBar.Value = Math.Min(HScrollBar.Value + HScrollBar.LargeChange, HScrollBar.Maximum);
		}
		/// <summary>
		/// Left Key 입력시 HScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("Left시에 HScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollPageLeft()
		{
			if (HScrollBar!=null)
				HScrollBar.Value = Math.Max(HScrollBar.Value - HScrollBar.LargeChange, HScrollBar.Minimum);
		}
		/// <summary>
		/// Down Key 입력시 (Line 아래로 이동) VScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("Line 아래로 VScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollLineDown()
		{
			if (VScrollBar!=null)
				VScrollBar.Value = Math.Min(VScrollBar.Value + VScrollBar.SmallChange, VScrollBar.Maximum);
		}
		/// <summary>
		/// Up Key 입력시(Line 위로 이동) VScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("Line 위로 이동시 VScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollLineUp()
		{
			if (VScrollBar!=null)
				VScrollBar.Value = Math.Max(VScrollBar.Value - VScrollBar.SmallChange, VScrollBar.Minimum);
		}
		/// <summary>
		/// Line 오른쪽으로 이동시 HScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("Line 오른쪽으로 이동시 HScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollLineRight()
		{
			if (HScrollBar!=null)
				HScrollBar.Value = Math.Min(HScrollBar.Value + HScrollBar.SmallChange, HScrollBar.Maximum);
		}
		/// <summary>
		/// Line 왼쪽으로 이동시 HScrollBar의 위치를 조정합니다.
		/// </summary>
		[Description("Line 왼쪽으로 이동시 HScrollBar의 위치를 조정합니다.")]
		protected virtual void CustomScrollLineLeft()
		{
			if (HScrollBar!=null)
				HScrollBar.Value = Math.Max(HScrollBar.Value - HScrollBar.SmallChange, HScrollBar.Minimum);
		}

		#endregion


		#region EventHandler 구현부 
		
		//VScrollBar의 위치변경시 발생하여 VScrollPositionChanged Event를 발생시킵니다.
		private void VScrollChanged(object sender, EventArgs e)
		{
			try
			{
				OnVScrollChanged(-VScrollBar.Value,-oldVScrollValue);
				//Control Scroll
				ScrollControl(0,oldVScrollValue - VScrollBar.Value);
				oldVScrollValue = VScrollBar.Value;
			}
			catch{}
		}
		// HScrollBar의 위치변경시 발생하여 HScrollPositionChanged Event를 발생시킵니다.
		private void HScrollChanged(object sender, EventArgs e)
		{
			try
			{
				OnHScrollChanged(-HScrollBar.Value,-oldHScrollValue);
				//Control Scroll
				ScrollControl(oldHScrollValue - HScrollBar.Value ,0);
				oldHScrollValue = HScrollBar.Value;
			}
			catch{}
		}
		// BottomRightImage를 보여줄때 해당영역의 Click EventHandler (ImageClick시에 연속조회)
		private void BottomRightPanClick(object sender, EventArgs e)
		{
			OnBottomRightImageClick();	
		}
		// BottomRightImage를 보여줄때 해당영역의 DoubleClick EventHandler (ImageDoubleClick시에 연속조회)
		private void BottomRightPanDoubleClick(object sender, EventArgs e)
		{
			OnBottomRightImageDoubleClick();	
		}
		//VScrollBar의 값이 바뀔때 처리
		protected virtual void OnVScrollChanged(int newValue, int oldValue)
		{
		}
		//HScrollBar의 값이 바뀔때 처리
		protected virtual void OnHScrollChanged(int newValue, int oldValue)
		{
		}
		#endregion

		#region ScrollWindow, SetBottomRightImage
		/// <summary>
		/// Control을 Scroll합니다.
		/// </summary>
		/// <param name="deltaX"> 수평 이동값 </param>
		/// <param name="deltaY"> 수직 이동값 </param>
		protected virtual void ScrollControl(int deltaX, int deltaY)
		{
			User32.ScrollWindow(this.Handle, deltaX, deltaY, IntPtr.Zero, IntPtr.Zero);
		}
		/// <summary>
		/// 완료여부에 따라 RightBottom영역에 Image를 설정합니다.
		/// </summary>
		/// <param name="completed"> 완료여부 </param>
		protected virtual void SetBottomRightImage(bool completed)
		{
			if ( this.showBottomRightImage && (bottomRightPan != null))
			{
				if (completed)
					bottomRightPan.Image = XGridImage.Blueball;
				else
					bottomRightPan.Image = XGridImage.Redball;
			}
		}
		#endregion

	}
}
