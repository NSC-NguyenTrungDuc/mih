using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// XTrackBar에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("DataValidating"),
	ToolboxBitmap(typeof(System.Windows.Forms.TrackBar))]
	public class XTrackBar : System.Windows.Forms.TrackBar, IDataControl
	{
		#region Fields
		private bool	dataChanged = false;
		private bool	enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		private XColor xBackColor = XColor.XTrackBarBackColor;
		#endregion
		
		#region Base Properties
		[DefaultValue(typeof(XColor),"XTrackBarBackColor"),
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
			get{return ControlDataType.Number;}
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
			set 
			{ 
				this.Enabled = !value;
				this.TabStop = !value;
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
			get	{ return this.Value.ToString(); }
			set	
			{ 
				//IntType 일때만 SET
				if (TypeCheck.IsInt(value))
					this.Value = Convert.ToInt32(value);
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
		#endregion

		#region 생성자
		public XTrackBar()
		{
			//Default 색 지정
			this.BackColor = XColor.XTrackBarBackColor;
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
			base.OnValueChanged(e);
			dataChanged = true;
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
				OnDataValidating(ve);
				e.Cancel = ve.Cancel;
			}
			base.OnValidating(e);
			//Cancel이 아니면 dataChanged Clear
			if (!e.Cancel)
				dataChanged = false;
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

		#region OnParentBackColorChanged
		protected override void OnParentBackColorChanged(EventArgs e)
		{
			//ColorStyle 적용
			/* CheckBox나 Radio등 DoubleBuffer를 지원하는 Control의 경우은 ColorStyle적용후 Invalidate()하면 OnPaint 가 발생하여 변경된 Color가 적용되나.
			 * TrackBar, RichTextBox, CheckedListBox, ListBox, ListView, TreeView Control은 DoubleBuffer를 지원하지 않고, .NET Painting을 사용하지 않는
			 * Control이므로 ColorStyle적용후 Invalidate()하면 OnPaint 가 발생하지 않는다. 그래서 변경된 ColorStyle의 BackColor, ForeColor가 적용되지 않는다.
			 * 그래서, 차선책으로 Parent의 Color가 변할때 배경색 OR 전경색을 ColorStyle이 적용된 색깔로 적용할 수 있도록
			 * OnParentBackColorChanged 에서 다시 설정한다.
			 * 이 경우 문제는 위 Control에 다른 배경색과 전경색을 준 경우 ColorStyle이나 Parent Control의 BackColor를 변경한 경우 기본색으로 변경되는
			 * 단점이 있다. 일단 위 Control은 기본색을 사용하도록 유도하고, OnParentBackColorChanged에서 Color를 다시 설정하는 것으로 처리한다.
			 * this.BackColor = uColor.uTrackBarBackColor 로 기본색을 적용하면 위의 문제가 있으므로 변경된 색의 Color를 base.BackColor로 적용함.
			 */
			base.BackColor = this.xBackColor.Color;
			base.OnParentBackColorChanged(e);
		}
		#endregion
	}
}
