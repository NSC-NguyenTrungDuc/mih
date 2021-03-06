using System;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using System.Security;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	#region Enum
	/// <summary>
	/// SetComboItems할때 전체, 없음, 추가없음을 관리하는 Enum
	/// </summary>
	public enum XComboSetType
	{
		/// <summary>
		/// 추가없음
		/// </summary>
		NoAppend,
		/// <summary>
		/// (전체) 추가
		/// </summary>
		AppendAll,
		/// <summary>
		/// (없음) 추가
		/// </summary>
		AppendNone
	}
	#endregion

	#region XComboBox
	/// <summary>
	/// XComboBox에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("DataValidating")]
	[DefaultProperty("ComboItems")]
	[Designer(typeof(XComboBoxDesigner))]
	[ToolboxBitmap(typeof(IHIS.Framework.XComboBox), "Images.XComboBox.bmp")]
	public class XComboBox : System.Windows.Forms.ComboBox, IDataControl, IEditorControl
	{

		#region Class Variables
		private const int ARROW_WIDTH = 13;
		private DrawState drawState = DrawState.Normal;  //Contro의 그리기 상태


		private XColor xBackColor		= XColor.XComboBoxBackColor;
		private XColor xForeColor		= XColor.NormalForeColor;
		private XColor origForeColor    = XColor.NormalForeColor;  //ForeColor 속성에서 지정한 원래색
		private bool	dataChanged = false;
		private bool	readOnly = false;
		private bool enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private XComboItemCollection comboItems = new XComboItemCollection();
		private ImageList	imageList = null;
		//OnSelectedIndexChanged Invoker를 call할지 여부, OnBindingContextChanged에서 SelectedIndex변경시는 call하지 않음
		private bool callSelectedIndexChangedEventAtBindingContextChanged = true;
		private bool callSelectedIndexChangedEvent = true;
		private Image emptyImage = null;  //Image설정시 ImageIndex가 유효하지 않을때 그리는 Image
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XComboBoxBackColor"),
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
		//Default Value 변경
		[DefaultValue(ComboBoxStyle.DropDownList)]
		public new ComboBoxStyle DropDownStyle 
		{
			get { return base.DropDownStyle;}
			set { base.DropDownStyle = value;}
		}

		/// <summary>
		/// 값을 그릴 데이터 소스의 속성을 지정하는 문자열을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string ValueMember
		{
			get { return base.ValueMember;}
			set { base.ValueMember = value;}
		}
		/// <summary>
		/// 내용을 표시할 데이터 소스의 속성을 지정하는 문자열을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string DisplayMember
		{
			get { return base.DisplayMember;}
			set { base.DisplayMember = value;}
		}
		/// <summary>
		/// 이 ListControl 개체의 데이터 소스를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new object DataSource
		{
			get {return base.DataSource;}
			set {base.DataSource = value;}
		}
		/// <summary>
		/// ComboBox에 포함된 항목의 컬렉션을 나타내는 개체를 가져옵니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ComboBox.ObjectCollection Items
		{
			get	{return base.Items;}
		}
		/// <summary>
		/// 현재 선택되어 있는 항목을 지정하는 인덱스를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override int SelectedIndex 
		{
			get { return base.SelectedIndex;}
			set 
			{
				// ComboItems를 동적으로 Case에 따라 변경시키는 경우 case1: 2개 Add, case2: 3개 Add를 한후에
				// case2에서 3th를 선택후 case1으로 변경시에 SelectedIndex = 2이므로 out of range Error발생
				// 물론 개발자가 SelectedIndex = 0로 Clear후에 하면 에러가 발생하지 않으나, 안할 경우를 
				// 대비하여 try catch 함
				try
				{
					base.SelectedIndex = value;
				}
				catch{}
			}
		}
		public new bool Enabled 
		{
			get { return base.Enabled;}
			set
			{
				base.Enabled = value;
				this.Protect = !base.Enabled;
			}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion
		
		#region Property
		/// <summary>
		/// 이미지를 표시할 이미지목록을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("추가속성"),
		DefaultValue(null),
		MergableProperty(true),
		Description("이미지를 표시할 이미지목록을 설정합니다.")]
		public virtual ImageList ImageList
		{
			get { return imageList; }
			set
			{
				if (imageList != value)
				{
					imageList = value;
					//ImageList가 없으면 DrawMode Normal 있으면 OwnerDraw
					if (value == null)
					{
						this.DrawMode = DrawMode.Normal;
						this.emptyImage = null;
					}
					else
					{
						this.DrawMode = DrawMode.OwnerDrawFixed;
						this.emptyImage = new Bitmap(this.imageList.ImageSize.Width, this.imageList.ImageSize.Height);
					}

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
			get { return readOnly;}
			set
			{
				readOnly = value;
				this.TabStop = !value;
				if (readOnly) 
					base.ForeColor = XColor.DisabledForeColor.Color;
				else
					base.ForeColor = this.origForeColor.Color;  //ForeColor 속성에서 지정한 원래색으로 변경
			}
		}
		[Browsable(true), Category("추가속성")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public virtual XComboItemCollection ComboItems
		{
			get	{return comboItems;}
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected virtual string DataValue
		{
			get	
			{ 
				//DropDown형식이면 SelectedIndex가 없더라도 Text를 DataValue로
				if (this.DropDownStyle == ComboBoxStyle.DropDown)
				{
					//DropDown Style시는 Text와 DisplayItem비교하여 DataValue GET
					//ComboItem에 없는 값인 경우에도 SelectedIndex가 0인 경우가 생김
					foreach (XComboItem item in this.comboItems)
					{
						if (item.DisplayItem == this.Text)
							return item.ValueItem;
					}
					return this.Text;
				}
				else
				{
					if (this.SelectedIndex >= 0)
						return this.comboItems[this.SelectedIndex].ValueItem;
					else 
						return string.Empty;
				}
			}
			set	
			{
				if (this.DropDownStyle == ComboBoxStyle.DropDown)
				{
					bool found = false;
					foreach (XComboItem item in this.ComboItems)
					{
						if (item.ValueItem == value.ToString())
						{
							this.SelectedValue = value.ToString();
							this.Text = item.DisplayItem;
							found = true;
							break;
						}
					}
					if (!found)  //Found되지 않더라도 Text는 설정
					{
						this.SelectedIndex = -1;
						this.Text = value.ToString();
					}
				}
				else
				{
					bool found = false;
					foreach (XComboItem item in this.ComboItems)
					{
						if (item.ValueItem == value.ToString())
						{
							this.SelectedValue = value.ToString();
							found = true;
							break;
						}
					}
					if (!found)  //Found되지 않으면 SelectedIndex -1
					{
						this.SelectedIndex = -1;
						this.Text = "";
						/* 2006.01.16 Grid와 Binding된 Control일때 DataValue가 있는것을 선택후 ""인 것으로 행을 이동할때 앞에서 SelectedIndex = -1로 하는데
						 * 이상하게 OnTextChanged가 2번 발생하면서 SelectedIndex = 0로 설정되는 현상이 발생함.
						 * Reflector를 통해 Trace를 해보니 SelectedIndex 설정시에 ComboBox의 보통은 OnTextChanged가 한번 발생하고 정상적으로 되는데,
						 * 이상한 경우는 2번 발생하면서 SelectedIndex -> -1 -> 0로 변경됨. 어떤 Event Invoker에서 발생하는지를 확인해 보았으나, 
						 * SelectedIndex를 변경시키는 Event가 없음. 정확한 원인을 파악하고 해결해야 하나 DataSource로 ComboBox설정시에 여려 이상한
						 * 현상이 나타나는바 이를 해결하려면 Windows.Forms.ComboBox에서 상속안하고 구현해야 하나, 이는 시간이 많이 걸리므로
						 * 일단 이 현상을 피해가는 방법으로 처리한다. 따라서, SelectedIndex를 다시 확인하여 0로 변경되면 다시 설정한다.
						 * DropDown Style의 경우는 정상적으로 작동하나 DropDownList 형식에서만 문제가 발생함 */
						if (this.SelectedIndex > -1)
						{
							this.SelectedIndex = -1;
							this.Text = "";
						}
					}
				}
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
		/// XComboBox가 Grid의 Editor로 쓰일때 EditMode로 전환시에 DataValue를 설정시에
		/// callSelectedIndexChangedEvent = false로 하여 SelectedIndexChanged Event가 발생하지 않게함
		/// Grid의 ItemValueChanging Event가 2번 Call되는 것을 방지
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool CallSelectedIndexChangedEvent
		{
			get { return this.callSelectedIndexChangedEvent;}
			set { this.callSelectedIndexChangedEvent = value;}
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
		public XComboBox()
		{
			//DataSource Set
			this.DataSource = comboItems;
			this.ValueMember = "ValueItem";
			this.DisplayMember = "DisplayItem";
			this.DropDownStyle = ComboBoxStyle.DropDownList;

			this.Font = new Font("MS UI Gothic", 9.75f);
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

		#region Overrides
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
		/// SelectedIndexChanged Event를 발생시킵니다.
		/// (override) 데이타변경여부 속성을 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			// ComboItems를 동적으로 Case에 따라 변경시키는 경우 case1: 2개 Add, case2: 3개 Add를 한후에
			// case2에서 3th를 선택후 case1으로 변경시에 SelectedIndex = 2이므로 out of range Error발생
			// 물론 개발자가 SelectedIndex = 0로 Clear후에 하면 에러가 발생하지 않으나, 안할 경우를 
			// 대비하여 try catch 함
			// Grid의 Editor로 쓰일때 callSelectedIndexChangedEvent가 true이고, BindingCotextChanged Event에서 
			// SelectedIndex를 변경하는 경우가 아니면
			try
			{
				if (this.callSelectedIndexChangedEvent && this.callSelectedIndexChangedEventAtBindingContextChanged)
				{
					base.OnSelectedIndexChanged(e);
					dataChanged = true;
				}
			}
			catch{}
		}
		/// <summary>
		/// Validating Event를 발생시킵니다.
		/// (override) 데이타 변경시 DataValidating Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 CancelEventArgs </param>
		protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
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
		/// TextChanged Event를 발생시킵니다.
		/// (override) 텍스트변경시 리스트에서 일치하는 항목을 선택합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			//ValueItem입력시 DisplayItem 자동 선택 (DropDown형식은 제외), 2006.01.18 기능중복 Comment 처리
			//DropDown Style이 아니면 편집불가하므로 TextChange 될 경우는 내부적으로 처리하는 Logic밖에 없으므로 제거
//			if (DropDownStyle != ComboBoxStyle.DropDown)
//			{
//				for (int i = 0 ; i < this.ComboItems.Count ; i++)
//				{
//					if (this.Text == ComboItems[i].ValueItem)
//					{
//						this.SelectedIndex = i;
//						//Select All하지 않음
//						//this.SelectAll();
//						break;
//					}
//				}
//			}
			dataChanged = true;
		}
		/// <summary>
		/// KeyPress Event를 발생시킵니다.
		/// (override) Enter Key입력시 TAB Key를 발생, 입력키에 일치하는 항목을 선택합니다.
		/// </summary>
		/// <param name="e">  이벤트 데이터가 들어 있는 KeyPressEventArgs </param>
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			if (this.enterKeyToTab && e.KeyChar == (char)13)
			{
				SendKeys.Send("{TAB}");
				return;
			}

			// ValueItem입력시 DisplayItem 자동 선택
			// Edit 불가시 Key이벤트로 처리
			if (DropDownStyle != ComboBoxStyle.DropDown)
			{
				for (int i = 0 ; i < this.ComboItems.Count ; i++)
				{
					if (e.KeyChar.ToString() == ComboItems[i].ValueItem)
					{
						this.SelectedIndex = i;
						dataChanged = true;
					}
				}
			}

			base.OnKeyPress(e);
		}
		protected override void OnBindingContextChanged(EventArgs e)
		{
			//화면 동적 생성하여 SetComboItems로 콤보설정시에 SelectedIndex가 제대로
			//설정안되고,화면전환시 이전에 선택한 값이 Clear되는 문제가 발생
			//base.OnBindingContextChanged에서 처리후 SelectedIndex가 -1이 됨
			//이를 방지하기 위해 SelectedIndex 다시 설정
			//SelectedIndex변경시 SelectedIndexChanged Event call하지 않음
			this.callSelectedIndexChangedEventAtBindingContextChanged = false;
			int index = this.SelectedIndex;
			string text = this.Text;
			base.OnBindingContextChanged (e);


			if ((index != this.SelectedIndex) && (index < this.comboItems.Count))
				this.SelectedIndex = index;

			//index 가 -1일때 DropDown형식이면 이전 text 그대로 설정(base를 Call하면서 Text가 바뀜)
			if ((index == -1) && (this.DropDownStyle == ComboBoxStyle.DropDown))
				this.Text = text;
			//Flag Clear
			this.callSelectedIndexChangedEventAtBindingContextChanged = true;
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
				//Hover 그리기
				drawState = DrawState.Hot;
				this.Invalidate();
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
				//Normal 그리기
				drawState = DrawState.Normal;
				this.Invalidate();
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
			//Normal 그리기
			drawState = DrawState.Normal;
			this.Invalidate();
			
		}
		/// <summary>
		/// GotFocus Event를 발생시킵니다.
		/// (override) 컨트롤의 모양을 Hover 상태로 변경합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			if (!readOnly)
			{
				drawState = DrawState.Hot;
				this.Invalidate();
				
			}
		}
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			try
			{
				e.DrawBackground();
				e.DrawFocusRectangle();
				if (e.Index != -1)
				{
					int leftMargin = 0;
					//DrawImage, ImageIndex가 유효하면
					if (this.imageList != null)
					{
						int imageIndex = comboItems[e.Index].ImageIndex;
						if ((imageIndex >= 0) && (imageIndex < this.imageList.Images.Count))
						{
							this.imageList.Draw(e.Graphics, e.Bounds.X, e.Bounds.Y, imageIndex);
							leftMargin = this.imageList.ImageSize.Width;
						}
						else
						{
							//없으면 Empty Image Draw
							e.Graphics.DrawImage(this.emptyImage, e.Bounds.X, e.Bounds.Y);
							leftMargin = this.imageList.ImageSize.Width;
						}
					}
					//Text Draw
					using (Brush br = new SolidBrush(e.ForeColor))
						e.Graphics.DrawString(comboItems[e.Index].DisplayItem, e.Font, br, e.Bounds.X + leftMargin, e.Bounds.Y + 2);
				}
				else
				{
					using (Brush br = new SolidBrush(e.ForeColor))
						e.Graphics.DrawString(Text, e.Font, br,	e.Bounds.X , e.Bounds.Y);
				}
			}
			catch(Exception xe)
			{
				Debug.WriteLine("XComboBox::OnDrawItem, Name=" + this.Name + ",e.Index=" + e.Index.ToString() + ",에러[" + xe.Message + "]");
				if (e.Index != -1)
				{
					using (Brush br = new SolidBrush(e.ForeColor))
						e.Graphics.DrawString(this.comboItems[e.Index].DisplayItem, e.Font, br, e.Bounds.X, e.Bounds.Y);
				}
				else
				{
					using (Brush br = new SolidBrush(e.ForeColor))
						e.Graphics.DrawString(Text, e.Font, br, e.Bounds.X, e.Bounds.Y);
				}
			}
			base.OnDrawItem(e);
		}
		/// <summary>
		/// Window Message를 처리합니다.
		/// (override) ComboBox의 현재상태에 따라 모양을 그립니다.
		/// </summary>
		/// <param name="m"> (ref) 처리할 Windows Message </param>
		protected override void WndProc(ref Message m)
		{
			if (this.DropDownStyle == ComboBoxStyle.Simple)
			{
				base.WndProc(ref m);
				return;
			}

			IntPtr hDC = IntPtr.Zero;
			Graphics gdc = null;
			switch (m.Msg)
			{
				case (int) Win32.Msgs.WM_NCPAINT:	
					hDC = User32.GetWindowDC(this.Handle);
					gdc = Graphics.FromHdc(hDC);
					User32.SendMessage(this.Handle, (int) Win32.Msgs.WM_ERASEBKGND, hDC, IntPtr.Zero);
					SendPrintClientMsg();	// send to draw client area
					PaintFlatControlBorder(this, gdc);
					m.Result = (IntPtr) 1;	// indicate msg has been processed			
					User32.ReleaseDC(m.HWnd, hDC);
					gdc.Dispose();	

					break;
				case (int)  Win32.Msgs.WM_PAINT:
					base.WndProc(ref m);
					// flatten the border area again
					hDC = User32.GetWindowDC(this.Handle);
					gdc = Graphics.FromHdc(hDC);
					//ComboBox는 Flat Style이 없으므로 윗부분의 굵은 부분이 남게된다.
					//따라서, 이를 BackColor로 다시 덧칠한다.
					//Pen p = new Pen((this.Enabled? BackColor.Color:SystemColors.Control), 2);	
					Pen p = new Pen(BackColor.Color, 2);	
					gdc.DrawRectangle(p, new Rectangle(2, 2, this.Width-3, this.Height-3));
					PaintFlatDropDown(this, gdc);
					PaintFlatControlBorder(this, gdc);
					User32.ReleaseDC(m.HWnd, hDC);
					gdc.Dispose();	
					break;
				case (int)Win32.Msgs.WM_LBUTTONDOWN :
				case (int)Win32.Msgs.WM_LBUTTONDBLCLK :
					if (readOnly)  //ReadOnly상태일때는 DropDown 처리하지 않음
						return;
					else
						base.WndProc(ref m);
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}
		#endregion

		#region Paint Sub Routine
		private void SendPrintClientMsg()
		{
			// We send this message for the control to redraw the client area
			using (Graphics gClient = this.CreateGraphics())
			{
				IntPtr ptrClientDC = gClient.GetHdc();
				User32.SendMessage(this.Handle, (int) Win32.Msgs.WM_PRINTCLIENT, ptrClientDC, IntPtr.Zero);
				gClient.ReleaseHdc(ptrClientDC);
			}
			
		}

		private void PaintFlatControlBorder(Control ctrl, Graphics g)
		{
			//상태에 따라 Border Draw
			Rectangle rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
			if (drawState == DrawState.Normal)
				ControlPaint.DrawBorder(g, rect, XColor.NormalBorderColor.Color, ButtonBorderStyle.Solid);
			else if (drawState == DrawState.Hot)
				ControlPaint.DrawBorder(g, rect, XColor.ActiveBorderColor.Color, ButtonBorderStyle.Solid);
			else if (drawState == DrawState.Disable)
				ControlPaint.DrawBorder(g, rect, SystemColors.ControlDark, ButtonBorderStyle.Solid);
		}
		private void PaintFlatDropDown(Control ctrl, Graphics g)
		{
			//Button영역을 구해서 처리하는 로직(버튼의 영역이 너무커서 예쁘지 않음)
			//			Rectangle rect = new Rectangle(ctrl.Width-DropDownButtonWidth, 0, DropDownButtonWidth, ctrl.Height);
			//			ControlPaint.DrawComboButton(g, rect, ButtonState.Flat);

			//BUTTON영역을 FIX하여 그리는 로직, 상태에 따라 그림
			if (drawState == DrawState.Hot)
				DrawArrowSelected(g, false);
			else
				DrawArrowNormal(g, false);

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
				g.FillRectangle(new SolidBrush(ColorHelper.VSNetSelectionColor), left-1, top-1, arrowWidth+2, height+2);
				g.DrawRectangle(new Pen( new SolidBrush(XColor.ActiveBorderColor.Color), 1), left-1, top-2, arrowWidth+2, height+3);
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
		#endregion

		#region Implement IDataControl 
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
			this.SelectedIndex = -1;
			this.Text = "";
			dataChanged = false;
		}
		#endregion

		#region SetComboItems, RefreshComboItems
		public virtual void SetComboItems(DataTable dataTable, string displayMember, string valueMember, XComboSetType setType)
		{
			if (dataTable == null) return;
			//DisplayMember로 지정한 컬럼이 없으면 Return
			if (!dataTable.Columns.Contains(displayMember)) return;
			//ValueMember로 지정한 컬럼이 없으면 Return
			if (!dataTable.Columns.Contains(valueMember)) return;
			
			
			//DataSource Clear후 ComboItems, Items 다시 설정후 SET
			this.DataSource = null;

			this.comboItems.Clear();
			//전체, 없음 추가
			if (setType == XComboSetType.AppendAll)
				this.comboItems.Add("%", XMsg.GetField("F004")); //(전체)
			else if (setType == XComboSetType.AppendNone)
                this.comboItems.Add("", XMsg.GetField("F005")); //(없음)

			//DataRow Add
			foreach (DataRow dataRow in dataTable.Rows)
			{
				this.comboItems.Add(dataRow[valueMember].ToString(), dataRow[displayMember].ToString());
			}

			this.DataSource = comboItems;
			this.ValueMember = "ValueItem";
			this.DisplayMember = "DisplayItem";
		}
		/// <summary>
		/// 지정한 테이블로 ComboItems를 설정합니다.
		/// </summary>
		public virtual void SetComboItems(DataTable dataTable, string displayMember, string valueMember)
		{
			SetComboItems(dataTable, displayMember, valueMember, XComboSetType.NoAppend);
		}

        public virtual void SetComboItems(DataRow[] dataTable, string displayMember, string valueMember, XComboSetType setType)
        {
            if (dataTable.Length == 0) return;
            //DisplayMember로 지정한 컬럼이 없으면 Return
            if (dataTable[0][displayMember] == null) return;

            //ValueMember로 지정한 컬럼이 없으면 Return
            if (dataTable[0][valueMember] == null) return;

            //DataSource Clear후 ComboItems, Items 다시 설정후 SET
            this.DataSource = null;

            this.comboItems.Clear();
            //전체, 없음 추가
            if (setType == XComboSetType.AppendAll)
                this.comboItems.Add("%", XMsg.GetField("F004")); //(전체)
            else if (setType == XComboSetType.AppendNone)
                this.comboItems.Add("", XMsg.GetField("F005")); //(없음)

            //DataRow Add
            for (int i = 0; i < dataTable.Length; i++)
            {
                this.comboItems.Add(dataTable[i][valueMember].ToString(), dataTable[i][displayMember].ToString());
            }

            this.DataSource = comboItems;
            this.ValueMember = "ValueItem";
            this.DisplayMember = "DisplayItem";
        }
        public virtual void SetComboItems(DataRow[] dataTable, string displayMember, string valueMember)
        {
            SetComboItems(dataTable, displayMember, valueMember, XComboSetType.NoAppend);
        }



		/// <summary>
		/// ComboBox의 ComboItems에 직접 Add, Remove하고 나서 변경된 ComboItems를 적용합니다.
		/// </summary>
		public void RefreshComboItems()
		{
			this.DataSource = null;
			this.DataSource = this.comboItems;
			this.DisplayMember = "DisplayItem";
			this.ValueMember = "ValueItem";
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
	#endregion

	#region XComboItem
	/// <summary>
	/// 콤보박스의 리스트 항목(보여줄항목,값 항목)입니다.
	/// 2005.08.12 XComboItem을 Component화 함
	/// </summary>
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false)]
	public class XComboItem : System.ComponentModel.Component
	{
		private	string	displayItem = "";
		private	string	valueItem = "";
		private int		imageIndex = -1;
		/// <summary>
		/// 보여줄 값을 가져옵니다.
		/// </summary>
		[Browsable(true),Category("추가속성")]
        [Localizable(true)]
		public string DisplayItem
		{
			get {return displayItem;}
			set { displayItem = value;}
		}
		/// <summary>
		/// 실제값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성")]
		public string ValueItem
		{
			get {return valueItem;}
			set { valueItem = value;}
		}
		/// <summary>
		/// ImageList의 Index를 설정합니다.
		/// </summary>
		[Browsable(true),DefaultValue(-1),Category("추가속성")]
		public int ImageIndex
		{
			get {return imageIndex;}
			set { imageIndex = value;}
		}
		public XComboItem()
		{
		}
		/// <summary>
		/// ComboItem 생성자
		/// </summary>
		/// <param name="valueItem"> 실제값 </param>
		/// <param name="displayItem"> 보여줄 값 </param>
		public XComboItem(string valueItem, string displayItem)
			:this(valueItem, displayItem, -1)
		{
		}
		/// <summary>
		/// ComboItem 생성자
		/// </summary>
		/// <param name="valueItem"> 실제값 </param>
		/// <param name="displayItem"> 보여줄 값 </param>
		public XComboItem(string valueItem, string displayItem, int imageIndex)
		{
			this.valueItem = valueItem;
			this.displayItem = displayItem;
			this.imageIndex = imageIndex;
		}
	}
	#endregion

	#region XComboItem Collection
	/// <summary>
	/// XComboItem 을 관리하는 컬렉션입니다.
	/// </summary>
	[Serializable]
	[Editor(typeof(XComboItemEditor), typeof(UITypeEditor))]
	public class XComboItemCollection : System.Collections.CollectionBase
	{
		/// <summary>
		/// 지정한 인덱스에 있는 ComboItem 가져옵니다.
		/// </summary>
		public XComboItem this[int index]
		{
			get 
			{ 
				if (index > Count - 1 || index < 0)
					return null;
				else
					return (XComboItem)List[index];
			}
		}
		/// <summary>
		/// 지정한 key(string)에 해당하는 ComboItem을 가져옵니다.
		/// </summary>
		public XComboItem this[string key]
		{
			get
			{
				if (key == "") return null;
				foreach (XComboItem item in this)
				{
					if (item.ValueItem == key) return item;
				}
				return null;
			}
		}
		/// <summary>
		/// ComboItem을 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="comboItem"> ComboItem 개체 </param>
		/// <returns> 추가한 ComboItem 개체 </returns>
		public void Add(XComboItem comboItem)
		{
			//InitializeComponents에서 Serialize되는 순서가 AddRange -> Add가 먼저 발생하고,
			//다음에 XComboItem의 ValueItem과 DisplayItem이 설정되므로 ValueItem이 ""인 상태에서
			//Add가 발생하여 Exception이 발생함. 따라서, 동일한 값 확인여부를 Check하지 않음
//			foreach (XComboItem item in List)
//			{
//				
//				if (item.ValueItem == comboItem.ValueItem)
//					throw(new Exception("[XComboItem]이미 등록된 값과 동일합니다."));
//			}
			List.Add(comboItem);
		}
		/// <summary>
		/// ComboItem[]를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="items"> ComboItem[] </param>
		public void AddRange(XComboItem[] items)
		{
			List.Clear();
			foreach (XComboItem Item in items)
			{
				Add(Item);
			}
		}
		/// <summary>
		/// 실제값과 보여줄값으로 XComboItem을 만들어 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="valueItem"> 실제값 </param>
		/// <param name="displayItem"> 보여줄값 </param>
		/// <returns> 생성된 ComboItem 개체 </returns>
		public void Add(string valueItem, string displayItem)
		{
			foreach (XComboItem item in List)
			{
				if (item.ValueItem == valueItem)
					throw(new Exception("[XComboItem]이미 등록된 값과 동일합니다."));
			}
			XComboItem	comboItem = new XComboItem(valueItem, displayItem);
			List.Add(comboItem);
		}
		/// <summary>
		/// 실제값과 보여줄값으로 XComboItem을 만들어 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="valueItem"> 실제값 </param>
		/// <param name="displayItem"> 보여줄값 </param>
		/// <param name="imageIndex"> ImageList의 Index </param>
		/// <returns> 생성된 ComboItem 개체 </returns>
		public void Add(string valueItem, string displayItem, int imageIndex)
		{
			foreach (XComboItem item in List)
			{
				if (item.ValueItem == valueItem)
					throw(new Exception("[XComboItem]이미 등록된 값과 동일합니다."));
			}
			XComboItem	comboItem = new XComboItem(valueItem, displayItem, imageIndex);
			List.Add(comboItem);
		}
		/// <summary>
		/// 지정한 Index의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="index"> 지정 Index </param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0)
			{
				throw (new System.IndexOutOfRangeException());
			}
			else
			{
				List.RemoveAt(index); 
			}
		}
		/// <summary>
		/// 지정한 실제값의 ComboItem을 삭제합니다.
		/// </summary>
		/// <param name="valueMember"> ComboItem.ValueItem </param>
		public void Remove(string valueMember)
		{
			for (int i = 0 ; i < this.Count ; i++)
			{
				if (this[i].ValueItem == valueMember)
				{
					this.Remove(i);
					break;
				}

			}
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XComboItem객체를 제거합니다.
		/// </summary>
		/// <param name="item">제거할 XComboItem객체</param>
		public void Remove(XComboItem item)
		{
			List.Remove(item);
		}
		/// <summary>
		/// 컬렉션에 속하는 XComboItem을 ComboItem[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XComboItem[] </returns>
		public XComboItem[] ToArray()
		{
			XComboItem[] comboArray = new XComboItem[List.Count];
			for (int i = 0; i < List.Count; i++)
				comboArray[i] = (XComboItem) List[i];
			return comboArray;
		}
		/// <summary>
		/// 해당이름의 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="dataName"></param>
		/// <returns> PreDataItem가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다. </returns>
		public bool Contains(string valueItem)
		{
			foreach (XComboItem item in List)
				if (item.ValueItem == valueItem)
					return true;
			return false;
		}
		public bool Contains(XComboItem item)
		{
			return List.Contains(item);
		}
	}
	#endregion

	#region XComboItem Type Converter
	/// <summary>
	/// XComboItem Type Converter
	/// </summary>
	public class XComboItemTypeConverter : TypeConverter
	{
		/// <summary>
		/// 이 변환기가 개체를 지정된 형식으로 변환할 수 있는지 여부를 반환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="destinationType"> 변환할 대상 형식을 나타내는 Type </param>
		/// <returns> 이 변환기가 변환을 수행할 수 있으면 true이고, 그렇지 않으면 false </returns>
		public override bool CanConvertTo (ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;

			return base.CanConvertTo(context, destinationType);
		}
		/// <summary>
		/// 지정된 값 개체를 지정된 형식으로 변환합니다.
		/// </summary>
		/// <param name="context"> 형식 컨텍스트를 제공하는 ITypeDescriptorContext </param>
		/// <param name="culture"> CultureInfo 개체 </param>
		/// <param name="value"> 변환할 Object </param>
		/// <param name="destinationType"> value 매개 변수를 변환할 Type </param>
		/// <returns> 변환된 값을 나타내는 Object </returns>
		public override object ConvertTo
			(ITypeDescriptorContext context, CultureInfo culture,
			object value, System.Type destinationType )
		{
			XComboItem comboItem;
			object[] args;

			System.Type[] Types = new Type[]{typeof(string), typeof(string), typeof(int)};

			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is XComboItem)
				{
					comboItem = (XComboItem)value;
					args = new Object[]{comboItem.ValueItem, comboItem.DisplayItem, comboItem.ImageIndex};

					InstanceDescriptor id = new InstanceDescriptor(comboItem.GetType().GetConstructor(Types), args);

					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region XComboBoxDesigner
	internal class XComboBoxDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		private XComboBox comboBox = null;
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
			comboBox = (XComboBox) component;

			//Service Instance Set
			iSvc = (ISelectionService) GetService(typeof(ISelectionService));
			iComp = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			iHost = (IDesignerHost) GetService(typeof(IDesignerHost));
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
				// XComboBoxItem을 관련 Component로 함
				return comboBox.ComboItems;
			}
		}

		private void OnComponentRemoving(object sender, ComponentEventArgs e)
		{
			//XComboBox가 제거될때 관련된 XComboItem도 같이 제거
			if (e.Component == comboBox)
			{
				XComboItem cItem = null;
				for (int idx = comboBox.ComboItems.Count - 1; idx >= 0; idx--)
				{
					cItem = comboBox.ComboItems[idx];
					iComp.OnComponentChanging(comboBox, null);
					comboBox.ComboItems.Remove(cItem);
					iHost.DestroyComponent(cItem);
					iComp.OnComponentChanged(comboBox, null, null, null);
				}
			}
		}
	}
	#endregion
}
