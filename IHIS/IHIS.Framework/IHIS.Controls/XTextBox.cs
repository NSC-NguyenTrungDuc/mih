using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	/// <summary>
	/// XTextBox에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("DataValidating")]
	[Designer(typeof(XTextBoxDesigner))]
	[ToolboxBitmap(typeof(IHIS.Framework.XTextBox), "Images.XTextBox.bmp")]
	public class XTextBox : System.Windows.Forms.TextBox, IDataControl, IEditorControl
	{
		#region Class Variables
		private static Encoding kscEncoding = Service.BaseEncoding;
		private bool dataChanged = false;
		private bool protect = false;
		private bool applyByteLimit = false;  //Byte로 입력값 Check 여부
		private bool enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private bool autoTabAtMaxLength = false;  // SingleLine일때 maxLength에 도달하면 TAB을 발생시킬지 여부
		private XColor xBackColor				= XColor.XTextBoxBackColor;
		private XColor xForeColor				= XColor.NormalForeColor;
		private XColor focusBackColor			= XColor.XTextBoxFocusBackColor;
		private XColor origForeColor			= XColor.NormalForeColor;  //ForeColor 속성에서 설정한 원래 값
		protected bool IsEditMaskType	= false; //TextBox의 Type이 ATexBox에서 상속받은 AEditMask인지여부(EditMask일경우에는 applyByteLimit, autoTabAtMaxLength를 다르게 적용(OnTextChanged에서)
		protected bool CallTextChanged = true;
		private DrawState drawState = DrawState.Normal;  //Contro의 그리기 상태
		protected bool   CheckByteLimit = true; //Validating시에 입력값을 Byte단위로 Check할지 여부
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		#endregion

		#region Base Property
		[DefaultValue(typeof(XColor),"XTextBoxBackColor"),
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
				origForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		/// <summary>
		/// 읽기 전용인지 여부를 가져오거나 설정합니다.
		/// </summary>
		public new bool ReadOnly
		{
			get { return base.ReadOnly; }
			set
			{
				base.ReadOnly = value;
				this.TabStop = !value;
				if (value)
				{
					base.ForeColor = XColor.DisabledForeColor.Color;
				}
				else
					base.ForeColor = origForeColor.Color;  //ForeColor로 지정한 원래색으로 변경함
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		/// <summary>
		/// 컨트롤의 테두리 스타일을 가져오거나 설정합니다.
		/// </summary>	
		[DefaultValue(BorderStyle.FixedSingle)]
		public new BorderStyle BorderStyle
		{
			get { return base.BorderStyle; }
			set { base.BorderStyle = value; }
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
		[Browsable(false)]
		public virtual ControlDataType ContType
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
			get{return Text;}
			set{Text = value;}
		}
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Protect속성을 지정합니다.")]
		public bool Protect
		{
			get { return protect; }
			set
			{
				protect = value;
				base.ReadOnly = value;
				this.TabStop = !value;
				if (protect)
				{
					base.ForeColor = XColor.DisabledForeColor.Color;
					//this.BackColor = new XColor(Color.FromArgb(230,230,230));
				}
				else
				{
					base.ForeColor = this.origForeColor.Color;  //ForeColor에서 지정한 원래색으로 조정
				}
			}
		}
		/// <summary>
		/// 문자입력의 최대값을 Byte단위로 계산할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("문자입력의 최대값을 Byte 단위로 계산할지 여부를 설정합니다.")]
		public virtual bool ApplyByteLimit
		{
			get { return applyByteLimit; }
			set { applyByteLimit = value;}
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
		/// MultiLine이 아닐때 MaxLength에 도달하면 TAB Key를 발생시킬지 여부를 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("MultiLine이 아닐때 MaxLength에 도달하면 TAB Key를 발생시킬지 여부를 설정합니다.")]
		public bool AutoTabAtMaxLength
		{
			get { return autoTabAtMaxLength; }
			set { autoTabAtMaxLength = value;}
		}
		/// <summary>
		/// 컨트롤의 값이 변경되었는지 여부를 가져옵니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		/// <summary>
		/// 일본어 문자 입력시 Composition 완료시에 발생하는 Event 입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("일본어 문자 입력시 Composition 완료시에 발생합니다.(입력문자, 입력문자의 반각가나문자처리시 사용)")]
		public event CompositionEventHandler CompositionCompleted;

		#endregion

		#region Constructor(s)
		/// <summary>
		/// XTextBox 생성자
		/// </summary>
		public XTextBox()
		{
			// 2005/05/09 신종석 폰트 수정
			//this.Font = new Font("MS UI Gothic", 9.75f);
			BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }
		}
		#endregion

		#region Overrides
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

			//2005.10.24 Validation 통과시에 2Byte문자고려하여 Encoding Bytes수를 적용하여 MaxLength를 초과시에는 에러발생시킴
			if (!e.Cancel && !CheckByteLength())
				e.Cancel = true;  //유효통과하지 못함

			//Cancel이 아니면 dataChanged Clear
			if (!e.Cancel)
				dataChanged = false;

		}
		/// <summary>
		/// 문자열 MaxLength Check하기 (EditMask에서는 override하여 Mask가 없는 String형만 Check하기)
		/// </summary>
		/// <returns></returns>
		protected virtual bool CheckByteLength()
		{
			//2006.05.26 Design Mode시는 Check할 필요없음
			if (this.DesignMode) return true;

			//Byte단위 Length를 Check하지 않으면 return true;
			if (!this.CheckByteLimit) return true;

			Control parentControl = null;
			ParentIsIMsgContainer(this.Parent, out parentControl);

			//기존 Msg Clear (2006.02.02 기존 Msg Clear 하지 않음)
//			if (parentControl != null)
//				((IMsgContainer) parentControl).SetErrMsg("");	
			
			if ((this.Text != "") && (Service.BaseEncoding.GetByteCount(this.Text) > this.MaxLength))
			{
				//string msg = XMsg.GetMsg("M009") + MaxLength.ToString() + XMsg.GetMsg("M010"); //"입력한 문자열이 유효한 길이[" + MaxLength.ToString() + "자리]를 초과하였습니다."
				string msg = "";
				if (parentControl != null)
					((IMsgContainer) parentControl).SetErrMsg(msg);
				return false;
			}
			return true;
		}
		protected bool ParentIsIMsgContainer(Control parent, out Control parentControl)
		{
			parentControl = null;
			if(parent is IMsgContainer)
			{
				parentControl = parent;
				return true;
			}
			else
            {   //https://sofiamedix.atlassian.net/browse/MED-13340
				if(parent != null && parent.Parent != null)
					return ParentIsIMsgContainer(parent.Parent, out parentControl);
				else
					return false;
			}
		}
		/// <summary>
		/// TextChanged Event를 발생시킵니다.
		/// (override) 값변경여부를 true로 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnTextChanged(EventArgs e)
		{
			if (!this.CallTextChanged) return;

			base.OnTextChanged(e);
			dataChanged = true;

			//EditMaskType일 경우에는 applyByteLimit, autoTabAtMaxLength 다르게 적용(AEditMask::OnTextChanged에서 적용)
			if (!this.IsEditMaskType)
			{
				//ByteLimit Check
				if (this.applyByteLimit)
				{
					int textLen = kscEncoding.GetByteCount(this.Text);
					//한글 2byte, 영문 1byte의 길이가 MaxLength보다 더 크면
					if (textLen > this.MaxLength)
					{
						byte[] bytes = kscEncoding.GetBytes(this.Text);
						string temp = kscEncoding.GetString(bytes, 0, this.MaxLength);
						string temp1 = kscEncoding.GetString(bytes, 0, this.MaxLength - 1);
						string temp2 = kscEncoding.GetString(bytes, 0, this.MaxLength + 1);
						//한글이 MaxLength에서 잘리면
						if (temp.Length == temp2.Length)
							this.Text = temp1;
						else  //한글이 MaxLength까지이면
							this.Text = temp;

						this.SelectionStart = this.MaxLength;
					}
				}
				else if (!this.Multiline && this.autoTabAtMaxLength)  //MultiLine이 아닐때 MaxLength 도달시 TAB 발생시킴
				{
					if (this.Text.Length == this.MaxLength)
						SendKeys.SendWait("{TAB}");
				}
			}
		}
		/// <summary>
		/// GotFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.SelectAll();
			//Draw상태 SET
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
			base.OnLostFocus(e);
			drawState = DrawState.Normal;
			Invalidate();
		}
		/// <summary>
		/// KeyPress Event를 발생시킵니다.
		/// (override) Enter Key입력시 TAB Key를 발생시킵니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 KeyPressEventArgs </param>
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			// EnterKeyToTab 이고,MultiLine이 아니고, Enter Key 입력시 TAB Send
			if (this.enterKeyToTab && !this.Multiline && (e.KeyChar == (char)13))
			{
				SendKeys.Send("{TAB}");
			}

			// 더 반영해야함
			if (this.applyByteLimit)
			{
				if (Char.IsLetterOrDigit(e.KeyChar)||Char.IsSeparator(e.KeyChar)||Char.IsSymbol(e.KeyChar)||Char.IsPunctuation(e.KeyChar))
				{
					int totalTextLen = kscEncoding.GetByteCount(this.Text);
					int selectedTextLen = kscEncoding.GetByteCount(this.SelectedText);
					int charLen = kscEncoding.GetByteCount(e.KeyChar.ToString());
					if (charLen == 2) //한글
					{
					}
					else // 영문 (문자길이 MaxLength초과시 입력불가)
					{
						if (totalTextLen - selectedTextLen + charLen > this.MaxLength)
							e.Handled = true;
					}
				}
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
				drawState = DrawState.Normal;
				if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
					Invalidate();
			}
		}
		/// <summary>
		/// MouseEnter Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			drawState = DrawState.Hot;
			if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
				Invalidate();
		}
		/// <summary>
		/// Window Message를 처리합니다.
		/// (override) 그리기시에 상태에 따라 그립니다.
		/// </summary>
		/// <param name="m"> (ref) 처리할 Windows Message </param>
		protected override  void WndProc(ref Message m)
		{
			bool callBase = true;

			switch(m.Msg)
			{
				case ((int)Win32.Msgs.WM_PAINT):
				{
					if (BorderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
					{
						// Let the edit control do its painting
						base.WndProc(ref m);
						// Now do our custom painting
						DrawBorder(Enabled?drawState:DrawState.Disable);
						callBase = false;
					}
				}
					break;
				default:
					break;
			}

			//일본어 문자 입력 완료 처리(2006.04.13)
			if ((this.CompositionCompleted != null) && (m.Msg == (int) Win32.Msgs.WM_IME_COMPOSITION))
			{
				//전환 확정 읽기문자, 입력문자 처리
				if ((((int) m.LParam & (int) Imm32.GCSFlags.GCS_RESULTREADSTR) > 0)
					&& (((int) m.LParam & (int) Imm32.GCSFlags.GCS_RESULTSTR) > 0))
				{
					IntPtr hIMC = Imm32.ImmGetContext(this.Handle);
					int size1 = Imm32.ImmGetCompositionString(hIMC, Imm32.GCSFlags.GCS_RESULTREADSTR, null, 0);
					int size2 = Imm32.ImmGetCompositionString(hIMC, Imm32.GCSFlags.GCS_RESULTSTR, null, 0);
					StringBuilder sb1 = new StringBuilder(size1);
					StringBuilder sb2 = new StringBuilder(size2);
					Imm32.ImmGetCompositionString(hIMC, Imm32.GCSFlags.GCS_RESULTREADSTR, sb1, sb1.Capacity);
					Imm32.ImmGetCompositionString(hIMC, Imm32.GCSFlags.GCS_RESULTSTR, sb2, sb2.Capacity);
					Imm32.ImmReleaseContext(this.Handle, hIMC);
					//Event Call
					CompositionEventArgs xe = new CompositionEventArgs(GetResultString(sb2, size2), GetResultString(sb1, size1));
					OnCompositionCompleted(xe);
				}
			}

			if ( callBase )
				    base.WndProc(ref m);
		}
		#endregion

		#region GetResultString (OS따른 Composition 문자열 변환)
		//OS에 따른 문자열 구하기
		//WinNT이상(Win2000, WinXP는 UniCode사용 2byte문자-> 1byte문자로 변환, Win98이하는 1byte문자 그대로
		private string GetResultString(StringBuilder sb , int size)
		{
			string retString = "";
			switch (Environment.OSVersion.Platform)
			{
				case PlatformID.Win32NT:
					retString = sb.ToString().Substring(0, size/2);
					break;
				default:  //Win98이하 (Win32S, Win32Windows)
					retString = sb.ToString().Substring(0, sb.Capacity);
					break;
			}
			return retString;
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
		/// <summary>
		/// 문자입력 완료 Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnCompositionCompleted(CompositionEventArgs e)
		{
			if (CompositionCompleted != null)
				CompositionCompleted(this, e);
		}
		#endregion

		#region Implemention IDataControl Methods
		/// <summary>
		/// 편집중인 데이타를 컨트롤의 값으로 설정합니다.
		/// </summary>
		/// <returns> 설정 성공시 true, 실패시 false </returns>
		public virtual bool AcceptData()
		{
			bool ret = true;
			if (dataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(false, DataValue);
				//2006.05.02 Call전에 DataChanged Flag Clear (DataValidating Event에서 AcceptData를 호출하는 Logic이 들어가는 경우 무한 Loop방지)
				dataChanged = false;
				OnDataValidating(ve);
				//Cancel시에 Flag 다시 설정
				if (ve.Cancel)
					dataChanged = true;

				ret = !ve.Cancel;
			}
			//2005.10.24 2Byte문자고려하여 Encoding Bytes수를 적용하여 MaxLength를 초과시에는 에러발생시킴
			if (!CheckByteLength())
				ret = false;  //유효통과하지 못함

			return ret;
		}
		/// <summary>
		/// 컨트롤의 값을 Clear합니다.
		/// </summary>
		public virtual void ResetData()
		{
			dataChanged = false;
			Text = "";
		}
		#endregion

		#region Paint Subroutines
		private void DrawBorder(DrawState state)
		{
			//Border를 그리기 위한 Pen
			Pen borderPen = null;
			switch (state)
			{
				case DrawState.Hot :
					borderPen = new Pen(XColor.ActiveBorderColor.Color, 2);
					break;
				case DrawState.Disable :
					borderPen = SystemPens.ControlDark;
					break;
				default :
					borderPen = new Pen(XColor.NormalBorderColor.Color, 2);
					break;
			}

			IntPtr hDC = User32.GetDC(Handle);
			Rectangle rc = Bounds;
			using (Graphics g = Graphics.FromHdc(hDC))
			{
				//Draw Border
				g.DrawRectangle(borderPen, 0, 0, rc.Width , rc.Height );
			}

			// Release DC
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
            if (this.OnDataChanged != null)
            {
                OnDataChanged(this);
            }
		}

        public delegate void ResetOcsEmrDataOnDataChanged(object sender);
        public event ResetOcsEmrDataOnDataChanged OnDataChanged;
		#endregion

		#region SetByteCheckMode(bool checkByteLimit)
		public virtual void SetByteCheckMode(bool checkByteLimit)
		{
			this.CheckByteLimit = checkByteLimit;
		}
		#endregion

	}

	/// <summary>
	/// BlankTextDesigner에 대한 요약 설명입니다.
	/// 최초 Control을 Design할 때 기본으로 보이는 Text를 안보이게 합니다.
	/// </summary>
	internal class XTextBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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

	#region CompositionEventHandler (일본어 입력 문자처리 Event Handler)
	public delegate void CompositionEventHandler(object sender, CompositionEventArgs e);
	public class CompositionEventArgs : EventArgs
	{
		string resultReadString = "";    //Composition 완료후 읽기 문자
		string resultString = "";  //Composition 완료후 문자
		/// <summary>
		/// Composition 완료후 읽기 문자를 가져옵니다.
		/// </summary>
		public string ResultReadString
		{
			get { return resultReadString; }
		}
		public string ResultString
		{
			get { return resultString; }
		}
		public CompositionEventArgs(string resultString, string resultReadString)
		{
			this.resultString = resultString;
			this.resultReadString = resultReadString;
		}
	}
	#endregion
}
