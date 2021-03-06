using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XNumericUpDown에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("DataValidating"),
	ToolboxBitmap(typeof(System.Windows.Forms.NumericUpDown))]
	public class XNumericUpDown : System.Windows.Forms.NumericUpDown, IDataControl, IEditorControl
	{
		#region Fields
		private bool	dataChanged = false;
		private bool enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private XColor xBackColor = XColor.XNumericUpDownBackColor;
		private XColor xForeColor = XColor.NormalForeColor;
		private XColor origForeColor    = XColor.NormalForeColor;  //ForeColor 속성에서 지정한 원래색
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		private bool callValueChangedEvent = true; //ValueChanged Event를 Call할지 여부
		#endregion
		
		#region Base Properties
		[DefaultValue(typeof(XColor),"XNumericUpDownBackColor"),
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
				if (value)
				{
					base.ForeColor = XColor.DisabledForeColor.Color;
				}
				else
					base.ForeColor = this.origForeColor.Color;  //ForeColor에서 지정한 원래색으로 조정
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

		#region Events
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("데이타 유효성검사가 진행될 때 발생합니다.")]
		public event DataValidatingEventHandler DataValidating;
		#endregion

		#region Properties
		/// <summary>
		/// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Protect속성을 지정합니다.")]
		public bool Protect
		{ 
			get { return ReadOnly;}
			set 
			{ 
				ReadOnly  = value;
				if (ReadOnly)
					base.ForeColor = XColor.DisabledForeColor.Color;
				else
					base.ForeColor = this.origForeColor.Color;  //ForeColor에서 지정한 원래색으로 조정
			}
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
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected virtual string DataValue
		{
			get { return Value.ToString();}
			set 
			{ 
				if (TypeCheck.IsDecimal(value))
					Value = Convert.ToDecimal(value);
			}
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
		/// XNumericUpDown이 Grid의 Editor로 쓰일때 EditMode로 전환시에 DataValue를 설정시에
		/// callValueChangedEvent = false로 하여 ValueChanged Event가 발생하지 않게함
		/// Grid의 ItemValueChanging Event가 2번 Call되는 것을 방지
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CallValueChangedEvent
		{
			get { return callValueChangedEvent; }
			set { callValueChangedEvent = value; }
		}
		#endregion

		#region 생성자
		public XNumericUpDown()
		{
			//Default 색 지정
			this.BackColor = XColor.XNumericUpDownBackColor;
			this.ForeColor = XColor.NormalForeColor;
			this.Font = new Font("MS UI Gothic", 9.75f);
			BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		}
		#endregion

		#region Override
		/// <summary>
		/// Validated Event를 발생시킵니다.
		/// (override) 값변경여부를 true로 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnValueChanged(EventArgs e)
		{
			/* XNumericUpDown이 Grid의 Editor로 쓰일때 EditMode로 전환시에 DataValue를 설정시에
			 callValueChangedEvent = false로 하여 CheckedChanged Event가 발생하지 않게함
			Grid의 ItemValueChanging Event가 2번 Call되는 것을 방지 */
			if (this.callValueChangedEvent)
			{
				base.OnValueChanged(e);
				dataChanged = true;
			}
		}
		protected override void OnTextChanged(EventArgs e)
		{
			this.UpdateEditText();
			base.OnTextChanged(e);
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
		#endregion

		#region OnPaint
		protected override void OnPaint(PaintEventArgs e)
		{
			if (base.BackColor != xBackColor.Color)
				base.BackColor = xBackColor.Color;
			if (base.ForeColor != xForeColor.Color)
				base.ForeColor = xForeColor.Color;

			base.OnPaint(e);
		}
		#endregion

		#region Implement IDataControl
		object IDataControl.DataValue
		{
			get	{ return this.DataValue; }
			set	
			{ 
				this.DataValue = (value == null ? "" : value.ToString());
				//IEditorControl을 통해서 DataValue 설정시는 DataChanged = false (DataValidating Event call하지 않음)
				this.DataChanged = false;
			}
		}
		ControlDataType IDataControl.ContType
		{
			get{return ControlDataType.Number;}
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
			this.Value = this.Minimum;
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
