using System;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// XCheckBox에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("DataValidating")]
	[Designer(typeof(XCheckBoxDesigner))]
	[ToolboxBitmap(typeof(IHIS.Framework.XCheckBox), "Images.XCheckBox.bmp")]
	public class XCheckBox : System.Windows.Forms.CheckBox, IDataControl, IEditorControl
	{
		#region Class Variables
		const int CHECK_MARK_SIZE = 13;
		DrawState drawState = DrawState.Normal;
		Bitmap origMarkChecked = null;
		Bitmap origMarkUnchecked = null;
		Bitmap checkMarkChecked = null;
		Bitmap checkMarkUnchecked = null;
		Bitmap checkMarkHotChecked = null;
		Bitmap checkMarkHotUnchecked = null;
		Bitmap checkMarkDisableChecked = null;
		Bitmap checkMarkDisableUnchecked = null;

		// Interface 속성
		private bool	dataChanged = false;
		private string checkedValue = "Y", unCheckedValue = "N";
		private string checkedText = "",   unCheckedText = "";
		private bool enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private XColor xBackColor = XColor.XCheckBoxBackColor;
		private XColor xForeColor = XColor.NormalForeColor;
		private bool	callCheckedChangedEvent = true; //CheckedChanged Event를 Call할지 여부
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XCheckBoxBackColor"),
		Description("배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"NormalForeColor"),
		Description("텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		/// <summary>
		/// 평면 스타일 모양을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new FlatStyle FlatStyle
		{
			get {return base.FlatStyle;}
			set {base.FlatStyle = value;}
		}
		/// <summary>
		/// CheckBox 컨트롤의 모양을 결정하는 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Appearance  Appearance
		{
			get {return base.Appearance;}
			set {base.Appearance = value;}
		}
		#endregion

		#region Events
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("데이타 유효성검사가 진행될 때 발생합니다.")]
		public event DataValidatingEventHandler DataValidating;
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
			get{return ControlDataType.String;}
		}
		object IEditorControl.DataValue
		{
			get	{ return this.DataValue; }
			set	
			{ 
				this.DataValue = (value == null ? "" : value.ToString());
				//IEditorControl을 통해서 DataValue 설정시는 DataChanged = false (DataValidating Event call하지 않음)
				this.DataChanged = false;
			}
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected virtual string DataValue
		{
			get	{ return (Checked ? checkedValue : unCheckedValue); }
			set	
			{ 
				Checked = (value == checkedValue);
				if (Checked)
				{
					if (checkedText != "")
						this.Text = checkedText;
				}
				else
				{
					if (unCheckedText != "")
						this.Text = unCheckedText;
				}
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
			get { return !Enabled;}
			set { Enabled  = !value;}
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
		/// <summary>
		/// 체크된 상태의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue("Y"),
		Description("체크된 상태의 값을 지정합니다.")]
		public string CheckedValue
		{
			get	{return checkedValue;}
			set	{checkedValue = value;}
		}
		/// <summary>
		/// "체크되지 않은 상태의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue("N"),
		Description("체크되지 않은 상태의 값을 지정합니다.")]
		public string UnCheckedValue
		{
			get	{return unCheckedValue;}
			set	{unCheckedValue = value;}
		}
		/// <summary>
		/// 체크된 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue(""),
		Description("체크된 상태에서 보여줄 문자를 지정합니다.")]
		public string CheckedText
		{
			get	{return checkedText;}
			set { checkedText = value;}
		}
		/// <summary>
		/// 체크되지 않은 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		DefaultValue(""),
		Description("체크되지 않은 상태에서 보여줄 문자를 지정합니다.")]
		public string UnCheckedText
		{
			get	{return unCheckedText;}
			set { unCheckedText = value;}
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
		/// XCheckBox가 Grid의 Editor로 쓰일때 EditMode로 전환시에 DataValue를 설정시에
		/// callCheckedChangedEvent = false로 하여 CheckedChanged Event가 발생하지 않게함
		/// Grid의 ItemValueChanging Event가 2번 Call되는 것을 방지
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CallCheckedChangedEvent
		{
			get { return callCheckedChangedEvent;}
			set { callCheckedChangedEvent = value;}
		}
		#endregion

		#region Constructor(s)
		/// <summary>
		/// XCheckBox 생성자
		/// </summary>
		public XCheckBox()
		{
			//Default 색 지정
			this.BackColor = XColor.XCheckBoxBackColor;
			this.ForeColor = XColor.NormalForeColor;

			//this.Font = new Font("MS UI Gothic", 9.75f);

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }

			// Our control needs to have Flat style set
			FlatStyle = FlatStyle.Flat;
			this.Appearance = Appearance.Normal;
			// Load checkmark bitmap
			origMarkChecked = (Bitmap) DrawHelper.CheckIcon;
			origMarkUnchecked = (Bitmap)  DrawHelper.UnCheckIcon;

			checkMarkChecked = DoFiltering(origMarkChecked, Color.Black, XColor.NormalBorderColor.Color);
			checkMarkUnchecked = DoFiltering(origMarkUnchecked, Color.Black, XColor.NormalBorderColor.Color);

			checkMarkHotChecked = DoFiltering(origMarkChecked, Color.Black, XColor.ActiveBorderColor.Color);
			checkMarkHotUnchecked = DoFiltering(origMarkUnchecked, Color.Black, XColor.ActiveBorderColor.Color);

			checkMarkDisableChecked = DoFiltering(origMarkChecked, Color.Black, SystemColors.ControlDark);
			checkMarkDisableUnchecked = DoFiltering(origMarkUnchecked, Color.Black, SystemColors.ControlDark);
		}
		#endregion

		#region Overrides
		/// <summary>
		/// CheckedChanged Event를 발생시킵니다.
		/// (override) 체크상태에 따라 Text를 변경합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnCheckedChanged(EventArgs e)
		{
			// Checked에 따라 Text 변경
			if(this.Checked)
			{
				if(!this.checkedText.Trim().Equals(string.Empty))
					this.Text = this.checkedText;
			}
			else
			{
				if(!this.unCheckedText.Trim().Equals(string.Empty))
					this.Text = this.unCheckedText;
			}
			/* XCheckBox가 Grid의 Editor로 쓰일때 EditMode로 전환시에 DataValue를 설정시에
			 callCheckedChangedEvent = false로 하여 CheckedChanged Event가 발생하지 않게함
			Grid의 ItemValueChanging Event가 2번 Call되는 것을 방지 */
			if (this.callCheckedChangedEvent)
			{
				base.OnCheckedChanged(e);
				dataChanged = true;
			}
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
		/// MouseEnter Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseEnter(EventArgs e)
		{
			// Set state to hot
			base.OnMouseEnter(e);
			drawState = DrawState.Hot;
			Invalidate();
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseLeave(EventArgs e)
		{
			// Set state to Normal
			base.OnMouseLeave(e);
			if ( !ContainsFocus )
			{
				drawState = DrawState.Normal;
				Invalidate();
			}
		}
		/// <summary>
		/// GotFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnGotFocus(EventArgs e)
		{
			// Set state to Hot
			base.OnGotFocus(e);
			drawState = DrawState.Hot;
			Invalidate();
		}
		/// <summary>
		/// LostFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 기본 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnLostFocus(EventArgs e)
		{
			// Set state to Normal
			base.OnLostFocus(e);
			drawState = DrawState.Normal;
			Invalidate();
		}
		/// <summary>
		/// Window Message를 처리합니다.
		/// (override) 그리기시에 체크박스 상태에 따라 그립니다.
		/// </summary>
		/// <param name="m"> (ref) 처리할 Windows Message </param>
		protected override  void WndProc(ref Message m)
		{
			bool callBase = true;
						
			switch(m.Msg)
			{
				case ((int)Win32.Msgs.WM_PAINT):
				{
					// Let the edit control do its painting
					base.WndProc(ref m);
					// Now do our custom painting
					DrawCheckBoxState(Enabled?drawState:DrawState.Disable);
					callBase = false;
				}
					break;
				default:
					break;
			}

			if ( callBase )
				base.WndProc(ref m);
		
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			//ColorStyle 적용
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			if (base.ForeColor != xForeColor.Color)
				base.ForeColor = xForeColor.Color;
			base.OnPaint(e);
		}
		#endregion

		#region Implement IDataControl
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
			Checked = false;
			dataChanged = false;
		}
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

		#region Paint Subroutines
		private void DrawCheckBoxState(DrawState state)
		{
			Rectangle rect = ClientRectangle;

			// Create DC for the whole edit window instead of just for the client area
			IntPtr hDC = User32.GetDC(Handle);
			Rectangle checkMark = new Rectangle(rect.Left, rect.Top + (rect.Height-CHECK_MARK_SIZE)/2, 
				CHECK_MARK_SIZE, CHECK_MARK_SIZE);

			switch (CheckAlign)
			{
				case ContentAlignment.TopLeft :
					checkMark.Y = rect.Top;
					break;
				case ContentAlignment.TopCenter :
					checkMark.X = rect.Left + (rect.Width-CHECK_MARK_SIZE)/2;
					checkMark.Y = rect.Top;
					break;
				case ContentAlignment.TopRight :
					checkMark.X = rect.Right - CHECK_MARK_SIZE;
					checkMark.Y = rect.Top;
					break;
				case ContentAlignment.MiddleCenter :
					checkMark.X = rect.Left + (rect.Width-CHECK_MARK_SIZE)/2;
					break;
				case ContentAlignment.MiddleRight :
					checkMark.X = rect.Right - CHECK_MARK_SIZE;
					break;
				case ContentAlignment.BottomLeft :
					checkMark.Y = rect.Bottom - CHECK_MARK_SIZE;
					break;
				case ContentAlignment.BottomCenter :
					checkMark.X = rect.Left + (rect.Width-CHECK_MARK_SIZE)/2;
					checkMark.Y = rect.Bottom - CHECK_MARK_SIZE;
					break;
				case ContentAlignment.BottomRight :
					checkMark.X = rect.Right - CHECK_MARK_SIZE;
					checkMark.Y = rect.Bottom - CHECK_MARK_SIZE;
					break;
			}

			using (Graphics g = Graphics.FromHdc(hDC))
			{
				if ( state == DrawState.Normal )
				{
					// Draw normal black circle
					if ( Checked ) 
						g.DrawImage(checkMarkChecked, checkMark.Left, checkMark.Top);
					else
						g.DrawImage(checkMarkUnchecked, checkMark.Left, checkMark.Top);
				}
				else if ( state == DrawState.Hot )
				{
					if ( Checked ) 
						g.DrawImage(checkMarkHotChecked, checkMark.Left, checkMark.Top);
					else
						g.DrawImage(checkMarkHotUnchecked, checkMark.Left, checkMark.Top);
					
				}
				else if ( state == DrawState.Disable )
				{
					if ( Checked ) 
						g.DrawImage(checkMarkDisableChecked, checkMark.Left, checkMark.Top);
					else
						g.DrawImage(checkMarkDisableUnchecked, checkMark.Left, checkMark.Top);
				}
			}

			// Release DC
			User32.ReleaseDC(Handle, hDC);
		}

		private Bitmap DoFiltering(Bitmap bitmap, Color oldColor, Color newColor)
		{
			if (bitmap == null)
				return null;
			Bitmap copy = (Bitmap)bitmap.Clone();
			if ( newColor.R == oldColor.R && newColor.G == oldColor.G
				&& newColor.B == oldColor.B)
				return copy;

			for ( int i = 0; i < bitmap.Width; i++ )
			{
				for ( int j = 0; j < bitmap.Height; j++ )
				{
					Color currentPixel = copy.GetPixel(i, j);
					// Compare just RGB portion
					if ( currentPixel.R == oldColor.R && currentPixel.G == oldColor.G
						&& currentPixel.B == oldColor.B)
						try
						{
							copy.SetPixel(i, j, newColor);
						}
						catch {}
				}
			}
			return copy;
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

	/// <summary>
	/// ACheckDesigner에 대한 요약 설명입니다.
	/// 최초 Control을 Design할 때 기본으로 보이는 Text를 안보이게 합니다.
	/// </summary>
	internal class XCheckBoxDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		/// <summary>
		/// 디자이너가 초기화될 때 호출되므로 디자이너는 구성 요소의 속성을 기본값으로 설정
		/// (override) 기본값을 정의하지 않음 
		/// </summary>
		//public override void OnSetComponentDefaults()
		//{
		//}
        public override void InitializeNewComponent(System.Collections.IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            this.Control.Text = "";
        }

	}
}
