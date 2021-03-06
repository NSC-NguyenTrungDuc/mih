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
	/// XMonthBox에 대한 요약 설명입니다.
	/// </summary>
	[DefaultEvent("DataValidating")]
	[ToolboxBitmap(typeof(IHIS.Framework.XMonthBox), "Images.XDateTimePicker.bmp")]
	public class XMonthBox : System.Windows.Forms.UserControl, IDataControl
	{
		#region Fields
		const string MAX_MONTH = "999912";
		const string MIN_MONTH = "100001";
		const string JAPAN_MAX_MONTH = "208712";  //현재, 평성99년으로 표시가능한 년도가 2087년( 변경시 추가되어야 함)
		const string JAPAN_MIN_MONTH = "186801";  //명치 원년(1868)
		private DateTime initValue = DateTime.Today;
		private XColor xBackColor = XColor.XScreenBackColor;
		private bool   invalidMonthIsThisMonth = true; //Month값이 유효하지 않을때 이전,다음버튼을 누를때 현재월표시여부
		//txtMonth의 DataValidating Event가 발생했는지 여부
		//이전,다음버튼을 누를때 DataValidating Event로 개발자가 Handling할때 txtMonth_DataValidating Event가 발생했으면
		//이전,다음버튼 Click Event를 발생시키지 않게하여 2번처리되는 것을 방지하기위해 사용
		//txtMonth_DataValidating Set, 이전,다음버튼 Event Handleer에서 Clear
		private bool firedtxtMonthDataValidatingEvent = false; 
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부

        //MED-11258
        private bool isVietnameseYearType = false;

		#endregion

		#region Properties

        //MED-11258
        public bool IsVietnameseYearType
        {
            get { return isVietnameseYearType; }
            set 
            {
                this.isVietnameseYearType = value;
                this.txtMonth.IsVietnameseYearType = value;
                if (value)
                {
                    this.txtMonth.EditVietnameseMaskType = MaskType.Month;
                }
            }
        }

		[Browsable(false)]
		[DefaultValue(typeof(XColor),"XScreenBackColor")]
		public new XColor BackColor
		{
			get { return this.xBackColor;}
			set {}  //Set 기능은 없음
		}

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
		protected virtual string DataValue
		{
			get	{ return this.txtMonth.GetDataValue(); }
			set	{ ((IDataControl) this.txtMonth).DataValue = value;}
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
		/// 다음 버튼의 활성화 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("다음 버튼의 활성화 여부를 지정합니다.")]
		public bool NextButtonEnable
		{ 
			get { return this.btnNext.Enabled;}
			set { this.btnNext.Enabled = value;}
		}
		/// <summary>
		/// 다음 버튼의 활성화 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("이전 버튼의 활성화 여부를 지정합니다.")]
		public bool PrevButtonEnable
		{ 
			get { return this.btnPrev.Enabled;}
			set { this.btnPrev.Enabled = value;}
		}
		/// <summary>
		/// 달을 편집가능한지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("달을 편집가능한지 여부를 지정합니다.")]
		public bool MonthEditable
		{ 
			get { return !this.txtMonth.Protect;}
			set { this.txtMonth.Protect = !value;}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("일본 연호 Type인지 여부를 지정합니다..")]
		public bool IsJapanYearType
		{ 
			get { return this.txtMonth.IsJapanYearType;}
			set { this.txtMonth.IsJapanYearType = value;}
		}
		/// <summary>
		/// 입력된 달이 유효하지 않을때 이전,다음버튼을 누를때 현재월을 표시할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(true),
		MergableProperty(true),
		Description("입력된 달이 유효하지 않을때 이전,다음버튼을 누를때 현재월을 표시할지 여부를 지정합니다.")]
		public bool InvalidMonthIsThisMonth
		{ 
			get { return invalidMonthIsThisMonth;}
			set { invalidMonthIsThisMonth  = !value;}
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
			get { return this.txtMonth.DataChanged; }
			set { this.txtMonth.DataChanged = value;}
		}
		#endregion

		#region Event
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("다음달 버튼을 눌렀을때 발생하는 이벤트입니다.")]
		public event XMonthBoxButtonClickEventHandler NextButtonClick;
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("이전달 버튼을 눌렀을때 발생하는 이벤트입니다.")]
		public event XMonthBoxButtonClickEventHandler PrevButtonClick;
		/// <summary>
		/// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("데이타 유효성검사가 진행될 때 발생합니다.")]
		public event DataValidatingEventHandler DataValidating;
		#endregion

		private IHIS.Framework.XEditMask txtMonth;
		private IHIS.Framework.XButton btnPrev;
		private IHIS.Framework.XButton btnNext;
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region 생성자
		public XMonthBox()
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();
			base.BackColor = XColor.XScreenBackColor.Color;
			this.Size = new Size(122,21);
			//this.DataValue == DateTime.Today.ToString("yyyyMM"); 초기값 반영은 확인후 반영

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

		#region Dispose
		/// <summary> 
		/// 사용 중인 모든 리소스를 정리합니다.
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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(XMonthBox));
			this.txtMonth = new IHIS.Framework.XEditMask();
			this.btnPrev = new IHIS.Framework.XButton();
			this.btnNext = new IHIS.Framework.XButton();
			this.SuspendLayout();
			// 
			// txtMonth
			// 
			this.txtMonth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMonth.EditMaskType = IHIS.Framework.MaskType.Month;
			this.txtMonth.Location = new System.Drawing.Point(0, 0);
			this.txtMonth.Name = "txtMonth";
			this.txtMonth.Size = new System.Drawing.Size(74, 20);
			this.txtMonth.TabIndex = 0;
			this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtMonth.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtMonth_DataValidating);
			// 
			// btnPrev
			// 
			this.btnPrev.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
			this.btnPrev.Location = new System.Drawing.Point(74, 0);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(24, 21);
			this.btnPrev.TabIndex = 1;
			this.btnPrev.TabStop = false;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnNext
			// 
			this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
			this.btnNext.Location = new System.Drawing.Point(98, 0);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(24, 21);
			this.btnNext.TabIndex = 2;
			this.btnNext.TabStop = false;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// XMonthBox
			// 
			this.Controls.Add(this.txtMonth);
			this.Controls.Add(this.btnPrev);
			this.Controls.Add(this.btnNext);
			this.Name = "XMonthBox";
            this.Size = new System.Drawing.Size(122, 21);
            this.Load += new System.EventHandler(this.XMonthBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Event Invoker
		protected virtual void OnNextButtonClick(XMonthBoxButtonClickEventArgs e)
		{
			if (this.NextButtonClick != null)
				this.NextButtonClick(this, e);
		}
		protected virtual void OnPrevButtonClick(XMonthBoxButtonClickEventArgs e)
		{
			if (this.PrevButtonClick != null)
				this.PrevButtonClick(this, e);
		}
		protected virtual void OnDataValidating(DataValidatingEventArgs e)
		{
			if (this.DataValidating != null)
				this.DataValidating(this, e);
		}
		#endregion

		#region Event Handler
		private void btnNext_Click(object sender, System.EventArgs e)
		{
			//2005.12.13 와력시 적용
			if (this.IsJapanYearType)
			{
				if (JapanYearHelper.IsValidJapanYear(this.txtMonth.Text + "/01"))
				{
					if (this.txtMonth.GetDataValue().CompareTo(JAPAN_MAX_MONTH) < 0)
					{
						DateTime dt = DateTime.Parse(JapanYearHelper.GetDataValue(MaskType.Date, this.txtMonth.Text + "/01"));
						this.txtMonth.SetEditValue(dt.AddMonths(1).ToString("yyyyMM"));
						//다음 버튼 Click Event 구동
						//2006.01.06 txtMonth_DataValidating 발생여부가 false일 경우에만 Event를 발생시킴
						//개발자가 XMonthBox의 DataValdating으로 이전,다음버튼을 누를때의 동작을 Handling할때 
						//사용자가 날짜 입력후 버튼을 누를때 2번 DataValdating이 발생하는 것을 방지하기위함
						if (!this.firedtxtMonthDataValidatingEvent && (this.NextButtonClick != null))
						{
							XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
							OnNextButtonClick(xe);
							//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
							if (xe.ResetDataChanged)
								this.DataChanged = false;
						}
					}
					//MAX이면 다음 버튼 Disable
					if (this.txtMonth.GetDataValue() == JAPAN_MAX_MONTH)
						this.btnNext.Enabled = false;
					if (!this.btnPrev.Enabled && (this.txtMonth.GetDataValue().CompareTo(JAPAN_MIN_MONTH) > 0))
						this.btnPrev.Enabled = true;
				}
				else if (this.invalidMonthIsThisMonth) //2006.01.10 유효한 날이 아닐때 true이면 현재월로 설정
				{
					this.txtMonth.SetEditValue(DateTime.Today.ToString("yyyyMM"));  //현재월로 설정
					//다음 버튼 Click Event 구동
					//2006.01.06 txtMonth_DataValidating 발생여부가 false일 경우에만 Event를 발생시킴
					//개발자가 XMonthBox의 DataValdating으로 이전,다음버튼을 누를때의 동작을 Handling할때 
					//사용자가 날짜 입력후 버튼을 누를때 2번 DataValdating이 발생하는 것을 방지하기위함
					if (!this.firedtxtMonthDataValidatingEvent && (this.NextButtonClick != null))
					{
						XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
						OnNextButtonClick(xe);
						//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
						if (xe.ResetDataChanged)
							this.DataChanged = false;
					}
					//MAX이면 다음 버튼 Disable
					if (this.txtMonth.GetDataValue() == JAPAN_MAX_MONTH)
						this.btnNext.Enabled = false;
					if (!this.btnPrev.Enabled && (this.txtMonth.GetDataValue().CompareTo(JAPAN_MIN_MONTH) > 0))
						this.btnPrev.Enabled = true;

				}
			}
			else //현재 월이 유효하면 다음달로 이동 (Max는 9999/12)
			{
				if (TypeCheck.IsDateTime(this.txtMonth.Text + "/01"))
				{
					if (this.txtMonth.GetDataValue().CompareTo(MAX_MONTH) < 0)
					{
						DateTime dt = DateTime.Parse(this.txtMonth.Text + "/01");
						this.txtMonth.SetEditValue(dt.AddMonths(1).ToString("yyyyMM"));
						if (!this.firedtxtMonthDataValidatingEvent && (this.NextButtonClick != null))
						{
							XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
							OnNextButtonClick(xe);
							//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
							if (xe.ResetDataChanged)
								this.DataChanged = false;
						}
					}
					//MAX이면 다음 버튼 Disable
					if (this.txtMonth.GetDataValue() == MAX_MONTH)
						this.btnNext.Enabled = false;
					if (!this.btnPrev.Enabled && (this.txtMonth.GetDataValue().CompareTo(MIN_MONTH) > 0))
						this.btnPrev.Enabled = true;
				}
				else if (this.invalidMonthIsThisMonth) //2006.01.10 유효한 날이 아닐때 true이면 현재월로 설정
				{
					this.txtMonth.SetEditValue(DateTime.Today.ToString("yyyyMM"));
					if (!this.firedtxtMonthDataValidatingEvent && (this.NextButtonClick != null))
					{
						XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
						OnNextButtonClick(xe);
						//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
						if (xe.ResetDataChanged)
							this.DataChanged = false;
					}
					//MAX이면 다음 버튼 Disable
					if (this.txtMonth.GetDataValue() == MAX_MONTH)
						this.btnNext.Enabled = false;
					if (!this.btnPrev.Enabled && (this.txtMonth.GetDataValue().CompareTo(MIN_MONTH) > 0))
						this.btnPrev.Enabled = true;
				}
			}
			//DataValdating발생 여부 Clear
			this.firedtxtMonthDataValidatingEvent = false;
		}

		private void btnPrev_Click(object sender, System.EventArgs e)
		{
			//2005.12.13 와력시 적용
			if (this.IsJapanYearType)
			{
				if (JapanYearHelper.IsValidJapanYear(this.txtMonth.Text + "/01"))
				{
					if (this.txtMonth.GetDataValue().CompareTo(JAPAN_MIN_MONTH) > 0)
					{
						DateTime dt = DateTime.Parse(JapanYearHelper.GetDataValue(MaskType.Date, this.txtMonth.Text + "/01"));
						this.txtMonth.SetEditValue(dt.AddMonths(-1).ToString("yyyyMM"));
						if (!this.firedtxtMonthDataValidatingEvent && (this.PrevButtonClick != null))
						{
							XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
							OnPrevButtonClick(xe);
							//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
							if (xe.ResetDataChanged)
								this.DataChanged = false;
						}
					}
					//MIN이면 이전 버튼 Disable
					if (this.txtMonth.GetDataValue() == JAPAN_MIN_MONTH)
						this.btnPrev.Enabled = false;
					if (!this.btnNext.Enabled && (this.txtMonth.GetDataValue().CompareTo(JAPAN_MAX_MONTH) < 0))
						this.btnNext.Enabled = true;
				}
				else if (this.invalidMonthIsThisMonth) //2006.01.10 유효한 날이 아닐때 true이면 현재월로 설정
				{
					this.txtMonth.SetEditValue(DateTime.Today.ToString("yyyyMM"));  //현재월로 설정
					//다음 버튼 Click Event 구동
					//2006.01.06 txtMonth_DataValidating 발생여부가 false일 경우에만 Event를 발생시킴
					//개발자가 XMonthBox의 DataValdating으로 이전,다음버튼을 누를때의 동작을 Handling할때 
					//사용자가 날짜 입력후 버튼을 누를때 2번 DataValdating이 발생하는 것을 방지하기위함
					if (!this.firedtxtMonthDataValidatingEvent && (this.PrevButtonClick != null))
					{
						XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
						OnPrevButtonClick(xe);
						//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
						if (xe.ResetDataChanged)
							this.DataChanged = false;
					}
					//MIN이면 이전 버튼 Disable
					if (this.txtMonth.GetDataValue() == JAPAN_MIN_MONTH)
						this.btnPrev.Enabled = false;
					if (!this.btnNext.Enabled && (this.txtMonth.GetDataValue().CompareTo(JAPAN_MAX_MONTH) < 0))
						this.btnNext.Enabled = true;

				}
			}
			else
			{
				//현재 월이 유효하면 이전달로 이동 (Max는 100001)
				if (TypeCheck.IsDateTime(this.txtMonth.Text + "/01"))
				{
					if (this.txtMonth.GetDataValue().CompareTo(MIN_MONTH) > 0)
					{
						DateTime dt = DateTime.Parse(this.txtMonth.Text + "/01");
						this.txtMonth.SetEditValue(dt.AddMonths(-1).ToString("yyyyMM"));
						if (!this.firedtxtMonthDataValidatingEvent && (this.PrevButtonClick != null))
						{
							XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
							OnPrevButtonClick(xe);
							//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
							if (xe.ResetDataChanged)
								this.DataChanged = false;
						}
					}
					//Min이면 이전 버튼 Disable
					if (this.txtMonth.GetDataValue() == MIN_MONTH)
						this.btnPrev.Enabled = false;
					if (!this.btnNext.Enabled && (this.txtMonth.GetDataValue().CompareTo(MAX_MONTH) < 0))
						this.btnNext.Enabled = true;
				}
				else if (this.invalidMonthIsThisMonth) //2006.01.10 유효한 날이 아닐때 true이면 현재월로 설정
				{
					this.txtMonth.SetEditValue(DateTime.Today.ToString("yyyyMM"));
					if (!this.firedtxtMonthDataValidatingEvent && (this.PrevButtonClick != null))
					{
						XMonthBoxButtonClickEventArgs xe = new XMonthBoxButtonClickEventArgs(true);
						OnPrevButtonClick(xe);
						//DataChanged을 Reset하여 버튼 Click후에 Focus이동시에 DataValdating이 발생하지 않도록 함
						if (xe.ResetDataChanged)
							this.DataChanged = false;
					}
					//Min이면 이전 버튼 Disable
					if (this.txtMonth.GetDataValue() == MIN_MONTH)
						this.btnPrev.Enabled = false;
					if (!this.btnNext.Enabled && (this.txtMonth.GetDataValue().CompareTo(MAX_MONTH) < 0))
						this.btnNext.Enabled = true;
				}
			}
			//DataValdating발생 여부 Clear
			this.firedtxtMonthDataValidatingEvent = false;
		}

		private void txtMonth_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			//XMonthBox의 DataValidating Event Call
			DataValidatingEventArgs xe = new DataValidatingEventArgs(e.Cancel, e.DataValue);
			OnDataValidating(xe);
			//Cancel Set
			e.Cancel = xe.Cancel;
			//Flag Set (DataValidating이 발생함)
			firedtxtMonthDataValidatingEvent = true;
		}
		protected override void OnValidating(CancelEventArgs e)
		{

			if (this.DataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(e.Cancel, DataValue);
				//Call전에 DataChanged Flag Clear (DataValidating에서 다른 Control에 Focus를 줄때 OnValidating에서 OnDataValidating을 Call하지 않도록 처리함.)
				this.DataChanged = false;
				OnDataValidating(ve);
				e.Cancel = ve.Cancel;
				//Cancel이면 dataChanged 다시 SET
				if (e.Cancel)
				{
					DataChanged = true;
					this.txtMonth.Focus();
				}
			}
			base.OnValidating(e);

			//Cancel이 아니면 dataChanged Clear
			if (!e.Cancel)
				DataChanged = false;
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
			this.DataValue = dataValue.ToString();
			this.DataChanged = true;
		}
		#endregion

		#region Implement IDataControl
		/// <summary>
		/// 편집중인 데이타를 컨트롤의 값으로 설정합니다.
		/// </summary>
		/// <returns> 설정 성공시 true, 실패시 false </returns>
		public virtual bool AcceptData()
		{
			if (this.DataChanged)
			{
				DataValidatingEventArgs ve = new DataValidatingEventArgs(false, DataValue);
				//2006.05.02 Call전에 DataChanged Flag Clear (DataValidating Event에서 AcceptData를 호출하는 Logic이 들어가는 경우 무한 Loop방지)
				DataChanged = false;
				OnDataValidating(ve);
				//Cancel시에 Flag 다시 설정
				if (ve.Cancel)
					DataChanged = true;

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
			this.txtMonth.ResetData();
			this.DataChanged = false;
		}
        #endregion
        private void XMonthBox_Load(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "vi-VN")
            {
                this.IsVietnameseYearType = true;
            }
        }
	}

	#region XMonthBoxButtonClickEventHandler
	/// <summary>
	/// XMonthBox에서 이전,다음버튼을 눌렀을때 발생하는 Event입니다.
	/// </summary>
	[Serializable]
	public delegate void XMonthBoxButtonClickEventHandler(object sender, XMonthBoxButtonClickEventArgs e);
	
	/// <summary>
	/// XMonthBox에서 이전,다음버튼을 눌렀을때 발생하는 Event에 데이타를 제공합니다.
	/// </summary>
	public class XMonthBoxButtonClickEventArgs : EventArgs
	{
		private bool	resetDataChanged = false;
		/// <summary>
		/// Event 호출후에 DataChanged를 Reset할지 여부를 지정합니다.
		/// </summary>
		public bool ResetDataChanged
		{
			get { return resetDataChanged; }
			set { resetDataChanged = value;}
		}
		/// <summary>
		/// DataValidatingEventArgs 생성자
		/// </summary>
		/// <param name="cancel"> Event 취소여부 </param>
		/// <param name="dataValue"> 데이타 값 </param>
		public XMonthBoxButtonClickEventArgs(bool resetDataChanged)
		{
			this.resetDataChanged = resetDataChanged;
		}
	}
	#endregion
}
