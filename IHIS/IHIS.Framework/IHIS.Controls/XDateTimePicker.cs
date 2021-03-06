using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XDateTimePicker에 대한 요약 설명입니다.
	/// (IHIS.X.Magic.Docking.IPopupControl를 상속받은 이유는 이 컨트롤을 사용하는 화면이 Docking형태로 열릴때
	/// 날짜창을 Popup하면서 생기는 문제를 방지하기 위해 상속(자세한 내용은 IPopupControl Comment참조))
	/// </summary>
	[DefaultEvent("DataValidating")]
	[ToolboxBitmap(typeof(IHIS.Framework.XDateTimePicker), "Images.XDateTimePicker.bmp")]
	public class XDateTimePicker : System.Windows.Forms.DateTimePicker, IDataControl, IHIS.X.Magic.Docking.IPopupControl
	{
		#region Class Variables
		private const int ARROW_WIDTH = 13;
		private bool droppedDown = false;
		private bool keyUpDownPressed = false;
		private bool readOnly = false;

		private bool dataChanged = false;
		private DateTime initialValue = DateTime.Today;
		private bool	enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		private XColor xCalendarMonthBackground			= XColor.XMonthCalendarBackColor;
		private XColor xCalendarForeColor				= XColor.NormalForeColor;
		private XColor xCalendarTitleBackColor			= XColor.XMonthCalendarTitleBackColor;
		private XColor xCalendarTitleForeColor			= XColor.XMonthCalendarTitleForeColor;
		private XColor xCalendarTrailingForeColor		= XColor.XMonthCalendarTrailingForeColor;
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XMonthCalendarBackColor"),
		Description("달력의 배경색을 지정합니다.")]
		public new XColor CalendarMonthBackground
		{
			get { return xCalendarMonthBackground;}
			set 
			{
				xCalendarMonthBackground = value;
				base.CalendarMonthBackground = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"NormalForeColor"),
		Description("달력의 텍스트색을 지정합니다.")]
		public new XColor CalendarForeColor
		{
			get { return xCalendarForeColor;}
			set 
			{
				xCalendarForeColor = value;
				base.CalendarForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XMonthCalendarTitleBackColor"),
		Description("달력 Title 배경색을 지정합니다.")]
		public new XColor CalendarTitleBackColor
		{
			get { return xCalendarTitleBackColor;}
			set 
			{
				xCalendarTitleBackColor = value;
				base.CalendarTitleBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XMonthCalendarTitleForeColor"),
		Description("달력 Title 텍스트색을 지정합니다.")]
		public new XColor CalendarTitleForeColor
		{
			get { return xCalendarTitleForeColor;}
			set 
			{
				xCalendarTitleForeColor = value;
				base.CalendarTitleForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XMonthCalendarTrailingForeColor"),
		Description("이전달과 다음달 날짜의 텍스트색을 지정합니다.")]
		public new XColor CalendarTrailingForeColor
		{
			get { return xCalendarTrailingForeColor;}
			set 
			{
				xCalendarTrailingForeColor = value;
				base.CalendarTrailingForeColor = value.Color;
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		/// <summary>
		/// 컨트롤에 표시되는 날짜 및 시간의 형식을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(DateTimePickerFormat.Custom)]
		public new DateTimePickerFormat Format
		{
			get { return base.Format; }
			set { base.Format = value; }
		}
		/// <summary>
		/// 사용자가 지정한 날짜 및 시간 형식 문자열을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue("yyyy/MM/dd")]
		public new string CustomFormat
		{
			get { return base.CustomFormat; }
			set { base.CustomFormat = value; }
		}
		/// <summary>
		/// 컨트롤의 기본 크기를 가져옵니다.
		/// </summary>
		protected override Size DefaultSize
		{
			get { return new System.Drawing.Size(100, this.PreferredHeight); }
		}
		#endregion

		#region Properties
		object IDataControl.DataValue
		{
			get	{ return this.DataValue; }
			set	
			{ 
				this.DataValue = (value == null ? "" : value.ToString());
				//IDataControl을 통해서 DataValue 설정시는 DataChanged = false (DataValidating Event call하지 않음)
				this.DataChanged = false;
			}
		}
		ControlDataType IDataControl.ContType
		{
			get{return ControlDataType.Date;}
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// 2005.09.06 DataValue YYYYMMDD -> YYYY/MM/DD로 변경
		/// </summary>
		protected virtual string DataValue
		{
			get
			{
				//yyyy/MM/dd로 해도 1999-01-01형태로 나오므로 - -> /로 변경함
				return this.Value.ToString("yyyy/MM/dd").Replace("-","/");
			}
			set
			{
				if (value == "") return;
				try
				{
					if (TypeCheck.IsDateTime(value))
						this.Value = DateTime.Parse(value);
					else  //YYYYMMDD
						this.Value = DateTime.Parse(value.Substring(0,4) + "/" + value.Substring(4,2) + "/" + value.Substring(6,2));
				}
				catch{}
			}
		}
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Protect속성을 지정합니다.")]
		public bool Protect
		{
			get { return readOnly;}
			set
			{
				readOnly = value;
				this.TabStop = !value;
				if (readOnly)
					this.ForeColor = XColor.DisabledForeColor.Color;
				else
					this.ForeColor = XColor.NormalForeColor.Color;
			}
		}
		/// <summary>
		/// 초기값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		Description("초기값을 지정합니다.")]
		public DateTime InitialValue
		{
			get{ return initialValue;}
			set
			{
				initialValue = value;
				// 현재값도 변경
				this.Value = initialValue;
			}
		}
		private bool ShouldSerializeInitialValue()
		{
			//날짜가 같으면 Serialize하지 않음
			return this.initialValue != DateTime.Today;
		}
		private void ResetInitialValue()
		{
			this.initialValue = DateTime.Today;
		}
		/// <summary>
		/// Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.")]
		public bool EnterKeyToTab
		{
			get { return enterKeyToTab; }
			set { enterKeyToTab = value;}
		}
		/// <summary>
		/// LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.")]
		public bool ApplyLayoutContainerReset
		{
			get { return applyLayoutContainerReset; }
			set { applyLayoutContainerReset = value;}
		}
		/// <summary>
		/// 컨트롤의 값이 변경되었는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		DefaultValue(false)]
		public bool DataChanged
		{
			get { return dataChanged; }
			set { dataChanged = value;}
		}
		#endregion

		#region Event
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("데이타 유효성검사가 진행될 때 발생합니다.")]
		public event DataValidatingEventHandler DataValidating;
		#endregion

		#region 생성자
		public XDateTimePicker()
		{
			this.Format = DateTimePickerFormat.Custom;
			this.CustomFormat = "yyyy/MM/dd";
			this.Value = this.initialValue;
			this.dataChanged = false;
			this.CalendarMonthBackground = XColor.XMonthCalendarBackColor;
			this.CalendarForeColor = XColor.NormalForeColor;
			this.CalendarTitleBackColor = XColor.XMonthCalendarTitleBackColor;
			this.CalendarTitleForeColor = XColor.XMonthCalendarTitleForeColor;
			this.CalendarTrailingForeColor = XColor.XMonthCalendarTrailingForeColor;

			// 2005/05/09 신종석 폰트 수정
			this.Font = new Font("MS UI Gothic", 9.75f);
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// ValueChanged Event를 발생시킵니다.
		/// (override) 값변경여부를 true로 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnValueChanged(EventArgs e)
		{
			base.OnValueChanged(e);
			dataChanged = true;
		}
		/// <summary>
		/// Validating Event를 발생시킵니다.
		/// (override) 데이타 변경시 DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 CancelEventArgs </param>
		protected override void OnValidating(CancelEventArgs e)
		{
			if (dataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(e.Cancel, DataValue);
				//Call전에 DataChanged Flag Clear (DataValidating에서 다른 Control에 Focus를 줄때 OnValidating에서 OnDataValidating을 Call하지 않도록 처리함.)
				dataChanged = false;
				OnDataValidating(ve);
				e.Cancel = ve.Cancel;
				//Cancel이면 dataChanged 다시 SET
				if (e.Cancel)
					dataChanged = true;
			}
			base.OnValidating(e);

			//Cancel이 아니면 dataChanged Clear
			if (!e.Cancel)
				dataChanged = false;
		}
		/// <summary>
		/// KeyPress Event를 발생시킵니다.
		/// (override) Enter Key입력시 TAB Key를 발생시킵니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 KeyPressEventArgs </param>
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (this.enterKeyToTab && e.KeyChar == (char)13)
			{
				SendKeys.Send("{TAB}");
			}
		}
		/// <summary>
		/// KeyDown Event를 발생시킵니다.
		/// (override) Up, Down Key입력시 Flag를 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 KeyEventArgs </param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
				keyUpDownPressed = true;
			else
				keyUpDownPressed = false;
		}
		/// <summary>
		/// TextChanged Event를 발생시킵니다.
		/// (override) 다음 Field로 이동합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			if (!this.droppedDown && !keyUpDownPressed)
			{
				// 다음 Field로 넘어가도록 (단, Calendar가 열려있거나, Up, Down키 입력시는 이동하지 않음)
				SendKeys.SendWait("{RIGHT}");
			}
			keyUpDownPressed = false;
		}
		/// <summary>
		/// 명령 키를 처리합니다.
		/// (override) ReadOnly 에서는 이동키외에는 Key는 처리하지 않습니다.
		/// </summary>
		/// <param name="msg"> (ref) 처리할 창 메시지를 나타내는 Message </param>
		/// <param name="keyData"> 처리할 키를 나타내는 Keys 값 </param>
		/// <returns> 컨트롤이 문자를 처리하면 true이고, 그렇지 않으면 false </returns>
		protected override  bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (readOnly)
			{
				Keys keyCode = (Keys)(((int)keyData << 16) >> 16);		// Modifier Clear
				Keys modifier = (Keys)(((int)keyData >> 16) << 16);		// Modifier
				switch (keyCode)
				{
					case Keys.Tab :
					case Keys.Enter :
					case Keys.Left :
					case Keys.Right :
					case Keys.Home :
					case Keys.End :
						return base.ProcessCmdKey(ref msg, keyData);
					default :
						return true;
				}
			}
			else
				return base.ProcessCmdKey(ref msg, keyData);
		}
		/// <summary>
		/// MouseEnter Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			if (!readOnly)
			{
				IntPtr hDC = User32.GetWindowDC(Handle);
				Graphics g = Graphics.FromHdc(hDC);
				DrawBorder(g, XColor.ActiveBorderColor.Color);
				DrawArrowSelected(g, false);
				g.Dispose();
				User32.ReleaseDC(Handle, hDC);
			}
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if ( !ContainsFocus )
			{
				IntPtr hDC = User32.GetWindowDC(Handle);
				Graphics g = Graphics.FromHdc(hDC);
				DrawBorder(g, XColor.NormalBorderColor.Color);
				DrawArrowNormal(g, false);
				g.Dispose();
				User32.ReleaseDC(Handle, hDC);
			}
		}
		/// <summary>
		/// LostFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.BackColor = XColor.XTextBoxBackColor.Color;
			IntPtr hDC = User32.GetWindowDC(Handle);
			Graphics g = Graphics.FromHdc(hDC);
			DrawBorder(g, XColor.NormalBorderColor.Color);
			DrawArrowNormal(g, false);
			g.Dispose();
			User32.ReleaseDC(Handle, hDC);
		}
		/// <summary>
		/// GotFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.BackColor = XColor.XTextBoxFocusBackColor.Color;
			if (!readOnly)
			{
				IntPtr hDC = User32.GetWindowDC(Handle);
				Graphics g = Graphics.FromHdc(hDC);
				DrawBorder(g, XColor.ActiveBorderColor.Color);
				DrawArrowSelected(g, false);
				g.Dispose();
				User32.ReleaseDC(Handle, hDC);
			}
		}
		/// <summary>
		/// DropDown Event를 발생시킵니다.
		/// (override) Drop시 Arrow영역을 상태에 따라 그립니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnDropDown(EventArgs e)
		{
			base.OnDropDown(e);
			droppedDown = true;
			IntPtr hDC = User32.GetWindowDC(Handle);
			Graphics g = Graphics.FromHdc(hDC);
			DrawArrowSelected(g, false);
			g.Dispose();
			User32.ReleaseDC(Handle, hDC);
		}
		/// <summary>
		/// CloseUp Event를 발생시킵니다.
		/// (override) Close시 Arrow영역을 상태에 따라 그립니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnCloseUp(EventArgs e)
		{
			base.OnCloseUp(e);
			droppedDown = false;
			IntPtr hDC = User32.GetWindowDC(Handle);
			Graphics g = Graphics.FromHdc(hDC);
			DrawArrowSelected(g, false);
			g.Dispose();
			User32.ReleaseDC(Handle, hDC);
		}
		/// <summary>
		/// Window Message를 처리합니다.
		/// (override) Mouse LeftButton Click, DoubleClick시 Calendar를 보여줍니다.
		/// </summary>
		/// <param name="m"> (ref) 처리할 Windows Message </param>
		protected override void WndProc(ref Message m)
		{
			bool doPainting =  false;
			bool fireBase = true;

			switch (m.Msg)
			{
				case (int)Win32.Msgs.WM_PAINT :
					doPainting = true;
					break;
				case (int)Win32.Msgs.WM_NCPAINT :
					// 3D Border Draw Suppress
					fireBase = false;
					break;
				case (int)Win32.Msgs.WM_LBUTTONDOWN :
				case (int)Win32.Msgs.WM_LBUTTONDBLCLK :
					// Button Click시 Native Button Suppress하기 위해 Key Send로 DropDown시킨다.
					int x = (int)m.LParam % 0x10000;
					int y = (int)m.LParam / 0x10000;
					if (x > this.Width - 23)
					{
						fireBase = false;
						this.Focus();
						if (!readOnly)
							SendKeys.Send("{F4}");
					}
					break;
				default:
					break;
			}

			if ( fireBase )
				base.WndProc(ref m);

			// Now let's do our own painting
			// we have to do it after the combox
			// does its own painting so that we can 
			// let the edit control in the combobox
			// take care of the text
			if ( doPainting )
				ForcePaint(ref m);
		}
		#endregion

		#region Event Invoker
		/// <summary>
		/// DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 ValidateEventArgs </param>
		protected virtual void OnDataValidating(DataValidatingEventArgs e)
		{
			if (DataValidating != null)
				DataValidating(this, e);
		}
		#endregion

		#region Implement IDataControl Methods
		/// <summary>
		/// 편집중인 데이타를 컨트롤의 값으로 설정합니다.
		/// </summary>
		/// <returns> 설정 성공시 true, 실패시 false </returns>
		public virtual bool AcceptData()
		{
			if (dataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(false, DataValue);
				//2006.05.02 Call전에 DataChanged Flag Clear (DataValidating Event에서 AcceptData를 호출하는 Logic이 들어가는 경우 무한 Loop방지)
				dataChanged = false;
				OnDataValidating(ve);
				//Cancel시에 Flag 다시 설정
				if (ve.Cancel)
					dataChanged = true;

				return !ve.Cancel;
			}
			else
				return true;
		}
		/// <summary>
		/// 컨트롤의 값을 Clear합니다.
		/// </summary>
		public void ResetData()
		{
			this.Value = this.initialValue;
			dataChanged = false;
		}
		#endregion

		#region Painting Implementation
		private void DrawBorder(Graphics g, Color color)
		{
			Rectangle rc = new Rectangle(0, 0, Bounds.Width, Bounds.Height);
			Pen pen = new Pen(new SolidBrush(color), 1);
			g.DrawRectangle(pen, rc.Left, rc.Top, rc.Width-1, rc.Height-1);
			
			// We need to draw an extra "inner" border to erase the ugly 3D look of  the combobox
			g.DrawRectangle(Pens.White, rc.Left+1, rc.Top+1, 
				rc.Width-SystemInformation.VerticalScrollBarWidth, rc.Height-3);
		}

		private void DrawArrowNormal(Graphics g, bool disable)
		{
			int left, top, arrowWidth, height;
			CalculateArrowBoxCoordinates(out left, out top, out arrowWidth, out height);

			// We are not going to draw the arrow background using the total
			// width of the arrow button in the combobox because it is too wide
			// and it does not look nice. However, we need to paint over the section
			// that correspond to the "original" arrow button dimension to avoid
			// clipping or painting problems
			Brush stripeColorBrush = new SolidBrush(ColorHelper.VSNetControlColor);
			if ( Enabled )
			{
				int width = SystemInformation.VerticalScrollBarWidth - ARROW_WIDTH;
				g.FillRectangle(Brushes.White, new Rectangle(left-width, top, 
					SystemInformation.VerticalScrollBarWidth, height));
			}

			if ( !disable) 
			{
				// Erase previous selected rectangle first
				DrawArrowSelected(g, true);
				// Now draw the unselected background
				g.FillRectangle(stripeColorBrush, left, top, arrowWidth, height);
			}
			else 
			{
				// Now draw the unselected background
				g.FillRectangle(stripeColorBrush, left-1, top-1, arrowWidth+2, height+2);
			}
			
			DrawArrowGlyph(g, disable);
			
		}

		private void DrawArrowSelected(Graphics g, bool erase)
		{
			
			int left, top, arrowWidth, height;
			CalculateArrowBoxCoordinates(out left, out top, out arrowWidth, out height);

			// We are not going to draw the arrow background using the total
			// width of the arrow button in the combobox because it too wide
			// and it does not look nice. However, we need to paint over the section
			// that correspond to the "original" arrow button dimension to avoid
			// clipping or painting problems
			if ( Enabled )
			{
				int width = SystemInformation.VerticalScrollBarWidth - ARROW_WIDTH;
				g.FillRectangle(Brushes.White, new Rectangle(left-width, top, 
					SystemInformation.VerticalScrollBarWidth, height));
			}
									
			if ( !erase )
			{
				if (droppedDown)
				{
					// If showing the list portion of the combo box, draw the arrow portion background using
					// the highlight color with some transparency
					// Don't use the graphics object that we get passed because that is associated
					// to the edit control of the combobox and we actually want to paint on the combobox area
					// and not be clipped only to the edit control client area
					g.FillRectangle(new SolidBrush(ColorHelper.VSNetPressedColor), left-1, top-1, arrowWidth+2, height+2);
					g.DrawRectangle(new Pen( new SolidBrush(XColor.ActiveBorderColor.Color), 1), left-1, top-1, arrowWidth+2, height+3);
					// The DrawArrow won't work with the passed Graphics object since it is the one for
					// the edit control and we need to paint on the combobox
					DrawArrowGlyph(g, false);
					return;
				}
				else
				{
					g.FillRectangle(new SolidBrush(ColorHelper.VSNetSelectionColor), left-1, top-1, arrowWidth+2, height+2);
					g.DrawRectangle(new Pen( new SolidBrush(XColor.ActiveBorderColor.Color), 1), left-1, top-2, arrowWidth+2, height+3);
				}
			}
			else 
			{
				g.FillRectangle(Brushes.White, left-1, top-1, arrowWidth+2, height+2);
			}

			DrawArrowGlyph(g, false);
         			
		}

		private void CalculateArrowBoxCoordinates(out int left, out int top, out int width, out int height)
		{
			Rectangle rc = new Rectangle(0, 0, Bounds.Width, Bounds.Height);
			width = ARROW_WIDTH;
			left = rc.Right - width - 2;
			top = rc.Top + 2;
			height = rc.Height - 4;
		}

		private void DrawArrowGlyph(Graphics g, bool disable)
		{
			int left, top, arrowWidth, height;
			CalculateArrowBoxCoordinates(out left, out top, out arrowWidth, out height);

			// Draw arrow glyph
			Point[] pts = new Point[3];
			pts[0] = new Point(left + arrowWidth/2 - 2, top + height/2-1);
			pts[1] = new Point(left + arrowWidth/2 + 3,  top + height/2-1);
			pts[2] = new Point(left + arrowWidth/2, (top + height/2-1) + 3);
			
			if ( disable ) 
			{
				g.FillPolygon(new SolidBrush(SystemColors.ControlDark), pts);	
			}
			else 
			{
				g.FillPolygon(Brushes.Black, pts);
			}
		}

		private void ForcePaint(ref Message m)
		{
			// Similar code to the OnPaint handler
			IntPtr hDC = User32.GetWindowDC(Handle);
			Graphics g = Graphics.FromHdc(hDC);
			if (!Enabled)
			{
				DrawDisableState();
				return;
			}

			Rectangle rc = new Rectangle(0, 0, Bounds.Width, Bounds.Height);

			if ( !ContainsFocus || readOnly )
			{
				DrawBorder(g, XColor.NormalBorderColor.Color);
				DrawArrowNormal(g, false);
			}
			else 
			{
				DrawBorder(g, XColor.ActiveBorderColor.Color);
				DrawArrowSelected(g, false);
			}
			g.Dispose();
			User32.ReleaseDC(Handle, hDC);
		}
		/// <summary>
		/// 비활성상태의 컨트롤을 그립니다.
		/// </summary>
		protected virtual void DrawDisableState()
		{
			IntPtr hDC = User32.GetWindowDC(Handle);
			Graphics g = Graphics.FromHdc(hDC);
			DrawBorder(g, SystemColors.ControlDark);
			DrawArrowNormal(g, true);
			g.Dispose();
			User32.ReleaseDC(Handle, hDC);
		}
		#endregion

		#region Data 가져오기, 설정 Method
		/// <summary>
		/// 해당 컨트롤의 DataValue를 가져옵니다.
		/// </summary>
		/// <returns></returns>
		public string GetDataValue()
		{
			return this.DataValue;
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 false로 설정합니다. Validation Check하지 않음)
		/// </summary>
		/// <param name="dataValue"></param>
		public void SetDataValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
		}
		/// <summary>
		/// 해당 컨트롤의 DataValue를 지정합니다.(이떄 DataChanged는 true로 설정합니다. Validation Check함)
		/// </summary>
		public void SetEditValue(object dataValue)
		{
			((IDataControl) this).DataValue = dataValue;
			this.DataChanged = true;
		}
		#endregion
	}
}
