using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// XGroupBox에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("DataValidating")]
	[ToolboxBitmap(typeof(IHIS.Framework.XGroupBox), "Images.XGroupBox.bmp")]
	public class XGroupBox : System.Windows.Forms.GroupBox, IDataControl
	{
		#region Class Variables
		private bool dataChanged = false;
		private XColor xBackColor	= XColor.XGroupBoxBackColor;
		private XColor xForeColor	= XColor.XGroupBoxForeColor;
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XGroupBoxBackColor"),
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
		[DefaultValue(typeof(XColor),"XGroupBoxForeColor"),
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
		/// 컨트롤의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		DefaultValue("")]
		protected virtual string DataValue
		{
			get
			{
				string	val = "";
				foreach(Control obj in Controls)
				{
					if (obj is XRadioButton)
					{
						if (((XRadioButton)obj).Checked)
						{
							val =  ((XRadioButton)obj).CheckedValue;
							break;
						}
					}
					else if (obj is XFlatRadioButton)
					{
						if (((XFlatRadioButton)obj).Checked)
						{
							val =  ((XFlatRadioButton)obj).CheckedValue;
							break;
						}
					}
				}
				return val;
			}
			set
			{
				XRadioButton	  radioBox;
				XFlatRadioButton  fRadioBox;
				foreach(Control obj in Controls)
				{
					if (obj is XRadioButton)
					{
						radioBox = (XRadioButton)obj;
						radioBox.Checked = false;
						if (radioBox.CheckedValue == value.ToString())
						{
							radioBox.Checked = true;
							break;
						}
					}
					else if (obj is XFlatRadioButton)
					{
						fRadioBox = (XFlatRadioButton)obj;
						fRadioBox.Checked = false;
						if (fRadioBox.CheckedValue == value.ToString())
						{
							fRadioBox.Checked = true;
							break;
						}
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
			get 
			{
				bool ret = true;
				XRadioButton	radioBox;
				foreach(Control obj in Controls)
				{
					if (obj is XRadioButton)
					{
						radioBox = (XRadioButton)obj;
						ret = !radioBox.Enabled;
						break;
					}
				}
				return ret;
			}
			set 
			{
				XRadioButton	radioBox;
				foreach(Control obj in Controls)
				{
					if (obj is XRadioButton)
					{
						radioBox = (XRadioButton)obj;
						radioBox.Enabled = !value;
					}
				}
			}
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
		public XGroupBox()
		{
			//Default 색 지정
			this.BackColor = XColor.XGroupBoxBackColor;
			this.ForeColor = XColor.XGroupBoxForeColor;
			// 2005/05/09 신종석 폰트 수정
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
		}
		#endregion

		#region Override
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
				//IDataControl을 통해서 DataValue 설정시는 DataChanged = false (DataValidating Event call하지 않음)
				this.DataChanged = false;
			}
		}
		ControlDataType IDataControl.ContType
		{
			get{return ControlDataType.String;}
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
			foreach(Control obj in Controls)
			{
				if ((obj is XRadioButton) && (obj is XFlatRadioButton))
				{
					((RadioButton)obj).Checked = false;
				}
			}
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

		#region SetDataChanged
		//XRadioButton에서 Check변경시 Set하기 위해 Call
		internal void SetDataChanged(bool dataChanged)
		{
			this.dataChanged = dataChanged;
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
