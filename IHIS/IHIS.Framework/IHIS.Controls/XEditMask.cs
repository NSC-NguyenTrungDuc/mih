using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;
using System.ComponentModel.Design;
using System.Threading;

namespace IHIS.Framework
{
	#region MaskType Enum
	/// <summary>
	/// EditMask의 DataType을 나타내는 Enum입니다.
	/// </summary>
	public enum MaskType
	{
		/// <summary>
		/// String형 EditMask
		/// </summary>
		String = 0,
		/// <summary>
		/// Number형 EditMask
		/// </summary>
		Number,
		/// <summary>
		/// Decimal형 EditMask
		/// </summary>
		Decimal,
		/// <summary>
		/// Date형 EditMask(yyyy/mm/dd)
		/// </summary>
		Date,
		/// <summary>
		/// Time형 EditMask(hh:mi,hh:mi:ss)
		/// </summary>
		Time,
		/// <summary>
		/// DateTime형 EditMask(yyyy/mm/dd hh:mi:ss)
		/// </summary>
		DateTime,
		/// <summary>
		/// YearMonth형 EditMask(YYYY/MM, YYYY-MM)
		/// </summary>
		Month
	}
	#endregion

	#region MaskSymbol
	/// <summary>
	/// Mask의 분석정보를 관리하는 struct 입니다.
	/// </summary>
	internal struct MaskSymbol
	{
		/// <summary>
		/// Mask의 Seperator 문자
		/// </summary>
		public char	Seperator;
		/// <summary>
		/// Mask에서 Seperator의 위치
		/// </summary>
		public int	SepPos;
		/// <summary>
		/// Seperator앞에 있는 Mask 문자열
		/// </summary>
		public string MaskStr;
		/// <summary>
		/// Mask 문자열의 길이
		/// </summary>
		public int	MaskStrLen;
		/// <summary>
		/// MaskSymbol 생성자
		/// </summary>
		/// <param name="sep"> Seperator char </param>
		/// <param name="pos"> Seperator Position </param>
		/// <param name="str"> Seperator앞에 있는 Mask 문자열 </param>
		/// <param name="strLen"> Mask 문자열의 길이 </param>
		public MaskSymbol(char sep, int pos, string str, int strLen)
		{
			Seperator = sep;
			SepPos = pos;
			MaskStr = str;
			MaskStrLen = strLen;
		}
	}
	#endregion

	/// <summary>
	/// EditMask에 대한 요약 설명입니다.
	/// </summary>
	[DefaultProperty("EditMaskType")]
	[ToolboxBitmap(typeof(IHIS.Framework.XEditMask), "Images.XTextBox.bmp")]
	[Designer(typeof(XEditMaskDesigner))]
	public class XEditMask : IHIS.Framework.XTextBox
	{
		#region Enum, Struct
		/// <summary>
		/// DateTime의 Group을 나타내는 Enum입니다.
		/// </summary>
		protected enum DateTimeGroup
		{
			/// <summary>
			/// 년도
			/// </summary>
			Year,
			/// <summary>
			/// 월
			/// </summary>
			Month,
			/// <summary>
			/// 일
			/// </summary>
			Day,
			/// <summary>
			/// 시간
			/// </summary>
			Hour,
			/// <summary>
			/// 분
			/// </summary>
			Minute,
			/// <summary>
			/// 초
			/// </summary>
			Second
		}
		#endregion

		#region Class Variables
		const int PERIOD_END = 3;  //일본어 Date, Month Mode일때 연호의 끝위치
		private string period = "平成";  //일본연호 관리

		// Mask 관련
		private MaskType editMaskType = MaskType.String;
		private string  mask = "";
		private int     decimalDigits = 0;
		private bool	minusAccept = false;
		private int		maxinumCipher = 12;	// 최대자리수(넘버, Decimal관련)
		private ArrayList maskSymbols = new ArrayList();
		private char stringMaskChar = 'X';
		private bool	isCopyKeyDown = false;  //Ctrl + C를 눌렀는지 여부
		private bool	generalNumberFormat = false; //Number의 Format이 일반형식(g)인지 n형식인지 여부
		private bool	isJapanYearType = false;  //연호를 쓰는 Type인지 여부
        //MED-11258
        private bool    isVietnameseYearType = false;
		#endregion

		#region Original Property 재정의

        //MED-11258
        public bool IsVietnameseYearType
        {
            get { return isVietnameseYearType; }
            set
            {
                this.isVietnameseYearType = value;
            }
        }

		/// <summary>
		/// 문자입력의 최대값을 Byte단위로 계산할지 여부를 가져오거나 설정합니다.
		/// (EditMask에서는 기능없음)
		/// </summary>
		[Browsable(false),DefaultValue(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override bool ApplyByteLimit
		{
			get { return false; }
			set {  }
		}
		[Browsable(false),DefaultValue(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool AutoTabAtMaxLength
		{
			get { return base.AutoTabAtMaxLength; }
			set { base.AutoTabAtMaxLength = value;}
		}
		/// <summary>
		/// 여러 줄을 입력할 수 있는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override bool Multiline
		{
			get{ return base.Multiline;}
			set{ base.Multiline = value ;}
		}
		/// <summary>
		/// Text를 설정합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override string Text 
		{
			get { return base.Text;}
			set { base.Text = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new bool AcceptsReturn
		{
			get { return base.AcceptsReturn;}
			set { base.AcceptsReturn = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new bool AcceptsTab
		{
			get { return base.AcceptsTab;}
			set { base.AcceptsTab = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override bool AutoSize
		{
			get { return base.AutoSize;}
			set { base.AutoSize = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new char PasswordChar
		{
			get { return base.PasswordChar;}
			set { base.PasswordChar = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new ScrollBars ScrollBars
		{
			get { return base.ScrollBars;}
			set { base.ScrollBars = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public override RightToLeft RightToLeft 
		{
			get { return base.RightToLeft;}
			set { base.RightToLeft = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new bool WordWrap 
		{
			get { return base.WordWrap;}
			set { base.WordWrap = value;}
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		Browsable(false)]
		public new string[] Lines
		{
			get { return base.Lines;}
			set { base.Lines = value;}
		}
		#endregion

		#region Properties
		[Browsable(false)]
		public override ControlDataType ContType
		{
			get
			{
				ControlDataType contType = ControlDataType.String;
				switch (this.editMaskType)
				{
					case MaskType.Number:
					case MaskType.Decimal:
						contType = ControlDataType.Number;
						break;
					case MaskType.Date:
						contType = ControlDataType.Date;
						break;
					case MaskType.DateTime:
						contType = ControlDataType.DateTime;
						break;
					case MaskType.Time:
						contType = ControlDataType.Time;
						break;

				}
				return contType;
			}
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected override string DataValue
		{
			get
			{
				//2005.11.30 Date, Month형 일때 일본연호 Type이면 분기
				if (this.isJapanYearType)
					return JapanYearHelper.GetDataValue(editMaskType, this.Text);
				else
					return MaskHelper.GetDataValue(this.editMaskType, this.maskSymbols, this.Text);
			}
			set
			{
				//TextChanged Event Call하지 않음
				this.CallTextChanged = false;
				//2005.11.30 Date, Month형 일때 일본연호 Type이면 분기
                if (this.isJapanYearType)
                    Text = JapanYearHelper.GetDisplayText(editMaskType, value, out this.period);
                else // DisplayText로 Text Set
                {
                    if (isVietnameseYearType)
                        Text = MaskHelper.GetVietnameseDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, this.generalNumberFormat, value, true, false);
                    else
                        Text = MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, this.generalNumberFormat, value);
                }
				this.CallTextChanged = true;
			}
		}
		/// <summary>
		/// EditMask의 DataType을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(MaskType.String),
		MergableProperty(true),
		Description("EditMask의 MaskType을 지정합니다")]
		public MaskType EditMaskType
		{
			get { return editMaskType; }
			set 
			{ 
				if (editMaskType != value)
				{
					editMaskType = value;
 
					//japanyearType Clear
					this.isJapanYearType = false;

					// MaskType에 따라 TextAlign Set (String Left, Number right, Date, Time은 Center)
					switch(editMaskType)
					{
						case MaskType.String:
							this.TextAlign = HorizontalAlignment.Left;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
						case MaskType.Month:
							this.TextAlign = HorizontalAlignment.Center;
							this.mask = MaskHelper.CMonthDefaultMask;
							break;
						case MaskType.Date:
							this.TextAlign = HorizontalAlignment.Center;
							this.mask = MaskHelper.CDateDefaultMask;
							break;
						case MaskType.DateTime:
							this.TextAlign = HorizontalAlignment.Center;
							this.mask = MaskHelper.CDateTimeDefaultMask;
							break;
						case MaskType.Time:
							this.TextAlign = HorizontalAlignment.Center;
							this.mask = MaskHelper.CTimeDefaultMask;
							break;
						case MaskType.Number:
						case MaskType.Decimal:
							this.TextAlign = HorizontalAlignment.Right;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
						default:
							this.TextAlign = HorizontalAlignment.Left;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
					}
					//MaskSymbols SET
					MaskHelper.SetMaskSymbols(this.editMaskType, this.mask, this.maskSymbols);
					if (this.editMaskType == MaskType.String) 
						this.stringMaskChar = MaskHelper.MaskSeperator;
					//Text를 NullText로 SET
					Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					Invalidate(ClientRectangle);
					//DataChanged Clear
					this.DataChanged = false;
				}
			}
		}

        //MED-11258
        public MaskType EditVietnameseMaskType
        {
            get { return editMaskType; }
            set
            {
                
                    editMaskType = value;

                    //japanyearType Clear
                    this.isJapanYearType = false;

                    // MaskType에 따라 TextAlign Set (String Left, Number right, Date, Time은 Center)
                    switch (editMaskType)
                    {
                        case MaskType.Month:
                            this.TextAlign = HorizontalAlignment.Center;
                            //MED-11258
                            this.mask = (Thread.CurrentThread.CurrentUICulture.Name == "vi-VN" && isVietnameseYearType == true) ? MaskHelper.CMonthVietnameseMask : MaskHelper.CMonthDefaultMask;
                            break;                        
                        default:
                            break;
                    }
                    //MaskSymbols SET
                    if (isVietnameseYearType)
                        MaskHelper.SetVietnameseMaskSymbols(this.editMaskType, this.mask, this.maskSymbols);
                    if (this.editMaskType == MaskType.String)
                        this.stringMaskChar = MaskHelper.MaskSeperator;
                    //Text를 NullText로 SET
                    Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
                    Invalidate(ClientRectangle);
                    //DataChanged Clear
                    this.DataChanged = false;
                
            }
        }

		/// <summary>
		/// EditMask의 Mask를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		Description("EditMask의 Mask를 지정합니다")]
		public string Mask
		{
			get { return mask; }
			set 
			{ 
				string errMsg = "";
				if (!MaskHelper.IsValidMask(this.editMaskType, value, out errMsg))
				{
					MessageBox.Show(errMsg);
					return;
				}
				mask = value;
				//MaskSymbols SET
				MaskHelper.SetMaskSymbols(this.editMaskType, this.mask, this.maskSymbols);
				if (this.editMaskType == MaskType.String) 
					this.stringMaskChar = MaskHelper.MaskSeperator;
				//Text를 NullText로 SET
				Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
				Invalidate(ClientRectangle);
				//DataChanged Clear
				this.DataChanged = false;
			}
		}
		// Mask의 Serialize 통제 Method
		// Mask의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private bool ShouldSerializeMask()
		{
			// Date(YYYY/MM/DD), DateTime(YYYY/MM/DD HH:MI:SS), Time(HH:MI:SS) Default
			if (editMaskType == MaskType.Date)
				return (mask != MaskHelper.CDateDefaultMask);
			else if (editMaskType == MaskType.Month)
				return (mask != MaskHelper.CMonthDefaultMask);
			else if (editMaskType == MaskType.DateTime)
				return (mask != MaskHelper.CDateTimeDefaultMask);
			else if (editMaskType == MaskType.Time)
				return (mask != MaskHelper.CTimeDefaultMask);
			else
				return (mask != MaskHelper.CStringDefaultMask);
		}
		// 다시설정시 기본값
		// Mask의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private void ResetMask()
		{	
			// Date(YYYY/MM/DD), DateTime(YYYY/MM/DD HH:MI:SS), Time(HH:MI:SS) Month(YYYY/MM) Default
			if (editMaskType == MaskType.Date)
				Mask = MaskHelper.CDateDefaultMask;
			else if (editMaskType == MaskType.Month)
				Mask = MaskHelper.CMonthDefaultMask;
			else if (editMaskType == MaskType.DateTime)
				Mask = MaskHelper.CDateTimeDefaultMask;
			else if (editMaskType == MaskType.Time)
				Mask = MaskHelper.CTimeDefaultMask;
			else
				Mask = MaskHelper.CStringDefaultMask;
		}
		/// <summary>
		/// Decimal Type의 Digits를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(0),
		MergableProperty(true),
		Description("Decimal Type의 Digits를 지정합니다")]
		public int DecimalDigits
		{
			get { return decimalDigits;}
			set { decimalDigits = Math.Max(0,value);}
		}
		/// <summary>
		/// Number,Decimal형에서 -를 입력가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Number Type에서 -를 입력가능한지를 설정합니다.")]
		public bool	MinusAccept
		{
			get { return minusAccept;}
			set { minusAccept = value;}
		}
		/// <summary>
		/// Number,Decimal형의 숫자 자리수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(12),
		MergableProperty(true),
		Description("Number Type에서 숫자 자리수를 설정합니다.(1~12)")]
		public int MaxinumCipher
		{
			get { return maxinumCipher;}
			set { maxinumCipher = ((value > 12) ? 12 : ((value <= 0) ? 12 : value));}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("Number형의 형식이 일반형식(1234)인지 숫자(1,234)형식인지 여부를 지정합니다.")]
		public bool GeneralNumberFormat
		{
			get { return generalNumberFormat;}
			set 
			{ 
				if (generalNumberFormat != value)
				{
					generalNumberFormat = value;
					//RunTime시는 Text 변경
					if (!this.DesignMode)
					{
						this.CallTextChanged = false; //Text Changed Event Call하지 않음
						Text = MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, value, this.DataValue);
						this.CallTextChanged = true;
					}
				}
			}
		}
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("일본 연호 Type인지 여부를 지정합니다.")]
		public bool IsJapanYearType
		{
			get { return isJapanYearType;} 
			set 
			{
				if (isJapanYearType != value)
				{
					isJapanYearType = value;
					//Date형과 Month형만 지정가능함
					if ((this.editMaskType != MaskType.Date) && (this.editMaskType != MaskType.Month)) return;

					if (value)  //maskSymbols 다시 SET
					{
						JapanYearHelper.SetMaskSymbols(this.editMaskType, maskSymbols);
						this.Text = JapanYearHelper.GetNullText(this.editMaskType, out this.period);
					}
					else  //MaskSymbols Text 다시 설정
					{
						if (this.editMaskType == MaskType.Date)
							this.mask = MaskHelper.CDateDefaultMask;
						else
							this.mask = MaskHelper.CMonthDefaultMask;
						MaskHelper.SetMaskSymbols(MaskType.Date, this.mask, maskSymbols);
						this.Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);
					}
				}
			}
		}
		#endregion

		#region Constructor(s)
		/// <summary>
		/// XEditMask 생성자
		/// </summary>
		public XEditMask()
		{
			//EditMaskType여부 SET(true)
			this.IsEditMaskType = true;
		}
		#endregion

		#region Overrides
		/// <summary>
		/// GotFocus Event를 발생시킵니다.
		/// (override) ImeMode를 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 EventArgs </param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);

			// GotFocus시 ImeMode Set
			SetImeMode();

			//2005.11.30 Date, Month형 일때 일본연호 Type이면 분기
			if (this.isJapanYearType)
				this.SetSelectionStart(PERIOD_END);  //연호 다음으로 SET
			else //전체 선택
				this.SelectAll();
		}
		/// <summary>
		/// KeyPress Event를 발생시킵니다.
		/// (override) Enter Key입력시 TAB Key를 발생, Mask에 따라 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 KeyPressEventArgs </param>
		protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)  // Enter시 Tab Key 발생
				base.OnKeyPress(e);
			else if (this.isCopyKeyDown)  //Copy Key는 본래기능 그대로 유지
				return;
			else
			{
				base.OnKeyPress(e);
				//ReadOnly일때는 Mask Set하지 않음
				if(!e.Handled && !this.ReadOnly)
					//Mask Set
					SetEditMask(e);
			}
		}
		/// <summary>
		/// KeyDown Event를 발생시킵니다.
		/// (override) Delete, Left, Right Key 입력시 Mask에 따라 입력을 제어합니다.
		/// </summary>
		/// <param name="e"> 이벤트 데이터가 들어 있는 KeyEventArgs </param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			//Ctrl + C Key Flag Clear
			isCopyKeyDown = false;

			string setText = "";
			// Delete처리, Mask가 있으면 
			if(e.KeyCode == Keys.Delete)
			{
				// 전체선택이면 NullText Set
				if (this.SelectedText == this.Text)
				{
					//2005.11.30 Date, Month형 일때 일본연호 Type이면 분기
					if (this.isJapanYearType)
					{
						this.Text = JapanYearHelper.GetNullText(editMaskType, out this.period);
						SetSelectionStart(PERIOD_END);
					}
					else
					{
						this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
						//Decimal은 Digits가 있으면 Digits 앞에
						if (this.editMaskType == MaskType.Decimal)
						{
							if (this.Text.IndexOf(".") >= 0)
								SetSelectionStart(this.Text.IndexOf("."));
						}
						else
							SetSelectionStart(0);
					}
					e.Handled = true;
					return;
				}
				else if (this.SelectionLength > 0)
				{
					switch (editMaskType)
					{
						case MaskType.Date:
						case MaskType.Month:
							//2005.11.30 일본연호Type으로 분기
							if (this.isJapanYearType)
								SetJapanYearEmptyText(editMaskType);
							else
							{
								if (this.mask == "") return;
								SetEmptyText();
							}
							//Handled True
							e.Handled = true;
							break;
						case MaskType.Time:
						case MaskType.DateTime:
						case MaskType.String:
							if (this.mask == "") return;
							
							//Handled True
							e.Handled = true;
							SetEmptyText();
							break;
					}
				}
				else 
				{
					switch (editMaskType)
					{
						case MaskType.String:
							if (this.mask == "") return;
							e.Handled = true;
							setText = MaskHelper.CSpaceChar.ToString();
							// Seperator 위치에 있으면 다음위치로 이동
							if (this.IsInSeperatorPos(this.SelectionStart))
								SetSelectionStart(this.SelectionStart);
							else
							{
								SetSelectedText(setText);
								//편집을 용이하게 하기위해 SelectionStart를 다음위치로 이동하지 않고 지워진 문자 앞에 위치하도록함
								this.SelectionStart--;
							}
							break;
						case MaskType.Date:
						case MaskType.Month:
							e.Handled = true;
							//2005.11.30 일본연호Type으로 분기
							//일본 연호 영역은 DELETE 불가
							if (this.isJapanYearType && this.SelectionStart < PERIOD_END) return;
							
							setText = MaskHelper.CZeroChar.ToString();
							// Seperator 위치에 있으면 다음위치로 이동
							if (this.IsInSeperatorPos(this.SelectionStart))
								SetSelectionStart(this.SelectionStart);
							else
								SetSelectedText(setText);

							break;
						case MaskType.Time:
						case MaskType.DateTime:
							e.Handled = true;
							setText = MaskHelper.CZeroChar.ToString();
							// Seperator 위치에 있으면 다음위치로 이동
							if (this.IsInSeperatorPos(this.SelectionStart))
								SetSelectionStart(this.SelectionStart);
							else
								SetSelectedText(setText);
							break;
						case MaskType.Decimal:
							int idx = this.Text.IndexOf(".");
							// 123.000에서 SelectionStart가 . 위치이후에 있으면 0로 채움
							if (idx >= 0)
							{
								if (idx <= this.SelectionStart)
								{
									e.Handled = true;
									//DecimalDigits 만큼까지만 0를 채움
									if (this.SelectionStart - idx <= this.decimalDigits)
									{
										// .위치에 있으면 SelectionStart이동
										if (idx == this.SelectionStart)
											this.SelectionStart++;
										// 0로 채움
										SetSelectedText(MaskHelper.CZeroChar.ToString());
									}
								}
							}
							break;
					}
				}
			}
			else if (e.Control && (e.KeyCode == Keys.C))
			{
				this.isCopyKeyDown = true;  //Copy Key Flag Set (OnKeyPress에서 Copy Key는 본래기능 부여)
			}
			else if (this.isJapanYearType) // 일본연호로 표시시에 Arrow Key 반영하기
			{
				//Up,Right는 연호증가, Down,Left는 연호감소
				if (e.KeyCode == Keys.Up)
				{
					int pos = this.SelectionStart;
					string bfPeriod = this.period;
					e.Handled = true;
					this.period = JapanYearHelper.GetNextJapanPeriod(this.period, true);
					this.Text = this.Text.Replace(bfPeriod, this.period);
					this.SelectionStart = pos;

				}
					//else if ((e.KeyCode == Keys.Down) || (e.KeyCode == Keys.Left))
				else if (e.KeyCode == Keys.Down)
				{
					int pos1 = this.SelectionStart;
					string bfPeriod1 = this.period;
					e.Handled = true;
					this.period = JapanYearHelper.GetNextJapanPeriod(this.period, false);
					this.Text = this.Text.Replace(bfPeriod1, this.period);
					this.SelectionStart = pos1;
				}
				else if (e.KeyCode == Keys.Left)  //Left 이동시에 PERIOD_END(3)보다 작게 이동 불가
				{
					if (this.SelectionStart <= PERIOD_END)
					{
						this.SelectionStart = PERIOD_END;
						e.Handled = true;
					}
				}
				else if ((e.KeyCode == Keys.H) || (e.KeyCode == Keys.M) || (e.KeyCode == Keys.T) || (e.KeyCode == Keys.S))
				{
					//연호단축키는 확인후 반영 (명치(M.meizi), 대정(T.taisyou),소화(S.syouwa), 평성(H.heisei)
					int pos = this.SelectionStart;
					string bfPeriod = this.period;
					e.Handled = true;
					this.period = (e.KeyCode == Keys.H ? "平成" : (e.KeyCode == Keys.S ? "昭和" : (e.KeyCode == Keys.T ? "大正" : "明治")));
					this.Text = this.Text.Replace(bfPeriod, this.period);
					this.SelectionStart = pos;
				}
			}
		}
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// (override) Select위치가 Seperator위치이면 위치이동합니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			//Number형이 아닌 경우 Data가 있는 경우에는 MouseDown한 위치에 그대로
			//데이타가 없으면 첫번째 위치로 이동
			if ((this.EditMaskType != MaskType.Number) && (this.editMaskType != MaskType.Decimal))
			{
				//2005.11.30 일본연호 Logic 추가
				string japanPeriod = "";
				string nullText = (this.isJapanYearType ? JapanYearHelper.GetNullText(editMaskType, out japanPeriod)
					: MaskHelper.GetNullText(editMaskType, this.maskSymbols, 0));
				if (this.Text == nullText)  // 첫번째로 이동
				{
					if (this.isJapanYearType)  //연호다음으로 이동
						SetSelectionStart(PERIOD_END);
					else
						SetSelectionStart(0);
				}
				else
				{
					// SelectedStart가 Seperator Position에 있으면 이동
					if (IsInSeperatorPos(this.SelectionStart))
						SetSelectionStart(this.SelectionStart);
				}
			}
		}
		/// <summary>
		/// TextChanged Event를 발생시킵니다.
		/// (override) Number, Decimal형의 Text를 재설정합니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnTextChanged(EventArgs e)
		{
			if (!this.CallTextChanged) return;

			base.OnTextChanged (e);
			string text = "";
			int    idx = 0;
			if (editMaskType == MaskType.Number)
			{
				text = this.Text;
				idx = text.IndexOf(",");
				try
				{
					// ,의 위치가 -,123 or ,123인 경우는 text를 변경하여 SET
					if ((idx == 0) ||(idx == 1))
						text = text.Substring(0,idx) + text.Substring(idx + 1);
					//GeneralNumber Format일 경우에는 Format 변경하지 않음
					if (!this.generalNumberFormat)
						this.Text = Decimal.Parse(text).ToString("n0");
					this.SelectionStart = this.Text.Length;
				}
				catch{}
			}
			else if (editMaskType == MaskType.Decimal)
			{
				//DecimalDigits == 0 이면 Number와 동일하게 적용
				if (this.decimalDigits <= 0)
				{
					text = this.Text;
                    idx = text.IndexOf(MaskHelper.SplitNumber);
					try
					{
						// ,의 위치가 -,123 or ,123인 경우는 text를 변경하여 SET
						if ((idx == 0) ||(idx == 1))
							text = text.Substring(0,idx) + text.Substring(idx + 1);
						//GeneralNumber Format일 경우에는 Format 변경하지 않음
						if (!this.generalNumberFormat)
							this.Text = Decimal.Parse(text).ToString("n0");

						this.SelectionStart = this.Text.Length;
					}
					catch{}
				}
				else
				{
					text = this.Text;
                    idx = text.IndexOf(MaskHelper.SplitNumber);
					try
					{
						int startPos = this.SelectionStart;
                        int dotIdx = this.Text.IndexOf(MaskHelper.Comma);
						// 변경전 SelectedStart가 소수점영역에 있으면 Text 변경하지 않음
						if (dotIdx >= 0)
						{
							if ((startPos >= 0) && (startPos <= dotIdx))
							{
								// ,의 위치가 -,123 or ,123인 경우는 text를 변경하여 SET
								if ((idx == 0) ||(idx == 1))
									text = text.Substring(0,idx) + text.Substring(idx + 1);
								// MinusAccept일때 -.000형태이면 Text 변경하지 않음
								if (!this.minusAccept || (text.Substring(0,dotIdx) != "-"))
								{
									// text가 NullText이면 변경하지 않음
									if (text != MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits))
									{
										//GeneralNumber Format일 경우에는 1111.11형식으로
										if (this.generalNumberFormat)
                                            this.Text = Decimal.Parse(text).ToString("n" + this.decimalDigits.ToString()).Replace(MaskHelper.SplitNumber, "");
										else
											this.Text = Decimal.Parse(text).ToString("n" + this.decimalDigits.ToString());
									}
								}
								// Format변경후 다시 Idx 구함
                                dotIdx = this.Text.IndexOf(MaskHelper.Comma);
								this.SelectionStart = dotIdx;
							}
						}
						else
						{
							// ,의 위치가 -,123 or ,123인 경우는 text를 변경하여 SET
							if ((idx == 0) ||(idx == 1))
								text = text.Substring(0,idx) + text.Substring(idx + 1);
							//GeneralNumber Format일 경우에는 1111.11형식으로
							if (this.generalNumberFormat)
                                this.Text = Decimal.Parse(text).ToString("n" + this.decimalDigits.ToString()).Replace(MaskHelper.SplitNumber, "");
							else
								this.Text = Decimal.Parse(text).ToString("n" + this.decimalDigits.ToString());
							this.SelectionStart = this.Text.Length;
						}
					}
					catch{}
				}
			}
		}
		/// <summary>
		/// Validating Event를 발생시킵니다.
		/// (override) EditMaskType에 따라 Validation Check합니다.
		/// </summary>
		/// <param name="e"> CancelEventArgs </param>
		protected override void OnValidating(CancelEventArgs e)
		{
			base.OnValidating (e);
		
			//Validation 통과시
			if (!e.Cancel)
			{
				// Date, DateTime, Time,NUmber형일때 Validation Check
				if ((this.editMaskType == MaskType.Date) || (this.editMaskType == MaskType.DateTime))
				{
					//2005.11.30 일본연호Type 추가
					if (this.isJapanYearType)
					{
						//2006/05/20 ValidYear Check 규칙 변경
						// 연호가 겹치는 년의 날짜를 잘못 입력시에 바로 NullText를 설정하지 않고
						//사용자의 편의를 위해 correctText를 Text로 SET (날짜형식만 적용)
						//IsValidJapanYear(yearText, out string correctText)를 사용함.
						string correctText = "";
						if (!JapanYearHelper.IsValidJapanYear(this.Text, out correctText))
						{
							if (correctText != "")
							{
								this.Text = correctText;
								//Period 다시 설정
								this.period = this.Text.Substring(0, 2);
							}
							else
								this.Text = JapanYearHelper.GetNullText(editMaskType, out this.period);
						}
					}
					else
					{
						// 정확한 DateTime이 아니면 NullText Set
						try
						{
							DateTime.Parse(this.Text);
						}
						catch
						{
							this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
						}
					}
				}
				else if (this.editMaskType == MaskType.Month)
				{
					//2005.11.30 일본연호Type 추가
					if (this.isJapanYearType)
					{
						if (!JapanYearHelper.IsValidJapanYear(this.Text + "/01"))  //유효한 일본 와력이 아니면 Null Set
							this.Text = JapanYearHelper.GetNullText(editMaskType, out this.period);
					}
					else
					{
						try
						{
							DateTime.Parse(this.Text + "/01");
						}
						catch
						{
							this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
						}
					}
				}
				else if (this.editMaskType == MaskType.Time)
				{
					try
					{
						TimeSpan.Parse(this.Text);
					}
					catch
					{
						this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					}
				}
				else if ((this.editMaskType == MaskType.Decimal)||(this.editMaskType == MaskType.Number))
				{
					try
					{
						// 0일때는 NullText SET (-.000 -> 0로 됨)
						if (Double.Parse(this.Text) == 0)
						{
							//number Type에서 0를 입력시 0입력도 유효하다고 할 수 있음
							if (editMaskType == MaskType.Number)
								this.Text = "0";
							else
								this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
						}
					}
					catch
					{
						this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					}
				}
				//DataChanged Clear
				this.DataChanged = false;	
			}
		}

		protected override bool CheckByteLength()
		{
			//2006.05.26 Design Mode시는 Check할 필요없음
			if (this.DesignMode) return true;


			if (!this.CheckByteLimit) return true;

			//유효문자길이 Check(Mask가 없는 String형만 Check함)
			//2005.10.24 2Byte문자고려하여 Encoding Bytes수를 적용하여 MaxLength를 초과시에는 에러발생시킴
			if ((this.EditMaskType == MaskType.String) && (this.mask == ""))
			{
				Control parentControl = null;
				ParentIsIMsgContainer(this.Parent, out parentControl);
				//기존 Msg Clear
				if (parentControl != null)
					((IMsgContainer) parentControl).SetErrMsg("");	
				
				if ((this.Text != "") && (Service.BaseEncoding.GetByteCount(this.Text) > this.MaxLength))
				{
					string msg = XMsg.GetMsg("M009") + MaxLength.ToString() + XMsg.GetMsg("M010"); //"입력한 문자열이 유효한 길이[" + MaxLength.ToString() + "자리]를 초과하였습니다."
					if (parentControl != null)
						((IMsgContainer) parentControl).SetErrMsg(msg);	
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 컨트롤의 값을 Clear합니다.
		/// </summary>
		public override void ResetData()
		{
			base.ResetData();

			//2005.11.30 일본연호 추가
			if (this.isJapanYearType)
				Text = JapanYearHelper.GetNullText(editMaskType, out this.period);
			else //Text를 NullText로 SET
				Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
		}
		#endregion

		#region Mast Set , ImeMode Set
		/// <summary>
		/// EditMaskType, 지정한 정보에 따라 ImeMode를 설정합니다.
		/// </summary>
		protected virtual void SetImeMode()
		{
			MaskType mType = this.editMaskType;
			switch(mType)
			{
				case MaskType.Date:
				case MaskType.DateTime:
				case MaskType.Decimal:
				case MaskType.Number:
				case MaskType.Time:
				case MaskType.Month:
					//ImeMode 변경불가
					this.ImeMode = ImeMode.Disable;
					break;
				case MaskType.String:
					//EditMask가 있는 String은 ImeMode 변경불가
					if(!this.mask.Trim().Equals(""))
						this.ImeMode = ImeMode.Disable;
					else if (this.AccessibleName != "")  //Grid의 Editor로 쓰일때 AccessibleName에 ImeMode String 저장함
					{
						if (this.AccessibleName == "Alpha")
							this.ImeMode = ImeMode.Alpha;
						else if (this.AccessibleName == "Hangul")
							this.ImeMode = ImeMode.Hangul;
						else if (this.AccessibleName == "Katakana")
							this.ImeMode = ImeMode.Katakana;
						else if (this.AccessibleName == "KatakanaHalf")
							this.ImeMode = ImeMode.KatakanaHalf;
					}
					break;
				default:
					break;
			}
		}
		/// <summary>
		/// EditMaskType, Mask에 따라 키입력시 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected virtual void SetEditMask(KeyPressEventArgs e)
		{
			// MaskType에 따라 해당 Mask Set Method call
			switch(this.editMaskType)
			{
				case MaskType.String:
					this.MaskString(e);
					break;
				case MaskType.Date:
				case MaskType.Month:
					//2005.11.30 일본연호 표기로 분기
					if (!this.isJapanYearType)
						this.MaskDate(e);
					else
						this.MaskJapanYearDate(e);
					break;
				case MaskType.DateTime:
					this.MaskDateTime(e);
					break;
				case MaskType.Time:
					this.MaskTime(e);
					break;
				case MaskType.Number:
					this.MaskNumber(e);
					break;
				case MaskType.Decimal:
					this.MaskDecimal(e);
					break;
			}
		}
		#endregion

		#region Mask 설정 Method
		/// <summary>
		/// Key입력시 DateTime형 MaskType에 지정된 Mask에 따라 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected virtual void MaskDateTime(KeyPressEventArgs e)  // DateTimeType Mask(YYYY/MM/DD HH:MM:SS)		
		{
			string setText = "";
			int selectionStart = 0;
			DateTimeGroup group = DateTimeGroup.Year;
			// Mask정보가 없으면 Check하지 않음
			if (this.maskSymbols.Count < 1) return;

			e.Handled = true;

			if (IsCorrectChar(e.KeyChar))
			{
				// 전체선택이면 NullText Set
				if(this.SelectedText == this.Text)
				{
					this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					// 초기 SelectStart Set
					SetSelectionStart(0);
				}
				if (e.KeyChar == 8)  //BackSpace
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
						SetEmptyText();
					else
					{
						// SelectionStart위치 변경
						if (this.SelectionStart > 0)
							this.SelectionStart--;
						// Start위치가 Seperator Pos에 없으면 해당위치에 Space로 채움
						if (!IsInSeperatorPos(this.SelectionStart)) 
						{
							this.SelectionLength = 1;
							this.SelectedText = MaskHelper.CZeroChar.ToString();
							// SelectedText를 변경하면 SelectionStart가 1증가 -> 복구
							if (this.SelectionStart > 0)
								this.SelectionStart--;
							this.SelectionLength = 0;
						}
					}
				}
				else
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
						SetEmptyText();

					// Mask가 모두 입력되었으면 Return
					if (((MaskSymbol) this.maskSymbols[maskSymbols.Count -1]).SepPos <= this.SelectionStart) return;

					// Start위치가 Seperator Pos에 없으면 해당위치에 KeyChar로 채움(Month,Day는 Valid Check)
					if (!IsInSeperatorPos(this.SelectionStart))
					{
						group = FindDateTimeGroup(this.SelectionStart);
						switch (group)
						{
							case DateTimeGroup.Year:
								SetSelectedText(e.KeyChar.ToString());
								break;
							case DateTimeGroup.Month:
							case DateTimeGroup.Day:
							case DateTimeGroup.Hour:
							case DateTimeGroup.Minute:
							case DateTimeGroup.Second:
								if (IsValidDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
								{
									this.SelectionStart = selectionStart;
									SetSelectedText(setText);
								}
								else
									return;
								break;
							default:
								return;
						}
					}
						//Seperator위치이면 SelectionStart 변경후 해당위치에 KeyChar를 채움
					else
					{
						SetSelectionStart(this.SelectionStart);
						group = FindDateTimeGroup(this.SelectionStart);
						switch (group)
						{
							case DateTimeGroup.Year:
								SetSelectedText(e.KeyChar.ToString());
								break;
							case DateTimeGroup.Month:
							case DateTimeGroup.Day:
							case DateTimeGroup.Hour:
							case DateTimeGroup.Minute:
							case DateTimeGroup.Second:
								if (IsValidDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
								{
									this.SelectionStart = selectionStart;
									SetSelectedText(setText);
								}
								else
									return;
								break;
							default:
								return;
						}
					}
				}
			}
		}
		/// <summary>
		/// Key입력시 Number형 MaskType에 지정된 Mask에 따라 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected virtual void MaskNumber(KeyPressEventArgs e)  // NumberType Mask
		{
			if (IsCorrectChar(e.KeyChar))
			{
				if (Char.IsDigit(e.KeyChar))
				{
					// 전체선택이면 NullText Set
					if(this.SelectedText == this.Text)
					{
						this.Text = "";
						// 초기 SelectStart Set
						SetSelectionStart(0);
					}
					else if (this.SelectionLength > 0)
					{
						e.Handled = true;
						//선택된 Text가 ,이면 MaxinumCipher만큼 입력되었을때 ,아래의 값을 변경
						if (this.SelectedText == ",")
						{
							if (this.Text.Replace(",","").Replace("-","").Length >= this.maxinumCipher)
							{
								this.SelectionStart += 1; //다음으로 이동
								this.SelectedText = e.KeyChar.ToString();
							}
							else
								this.SelectedText = e.KeyChar.ToString();

						}
						else
							this.SelectedText = e.KeyChar.ToString();
					}
					else
					{
						//숫자입력시 MaxinumCipher까지만 입력가능
						//최초 -입력시는 -는 길이에서 제외
						if (this.Text.Replace(",","").Replace("-","").Length >= this.maxinumCipher)
							e.Handled = true;
					}
				}
			}
			else
				e.Handled = true;
			
		}
		/// <summary>
		/// Key입력시 Decimal형 MaskType에 지정된 Mask에 따라 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected virtual void MaskDecimal(KeyPressEventArgs e)  // NumberType Mask
		{
			//DecimalDigits가 0이하이면 MaskNumber 적용
			if (this.decimalDigits <= 0)
			{
				MaskNumber(e);
				return;
			}

			int idx = 0;
			if (IsCorrectChar(e.KeyChar))
			{
				// 전체선택이면 NullText Set
				if(this.SelectedText == this.Text)
				{
					this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					// 초기 SelectStart Set
					SetSelectionStart(0);
				}
				if (e.KeyChar == 46) //.입력시 .다음위치로 이동
				{
					e.Handled = true;
					idx = this.Text.IndexOf(".");
					if (idx >= 0)
						this.SelectionStart = idx + 1;
				}
                if (e.KeyChar == 44) //.입력시 .다음위치로 이동
                {
                    e.Handled = true;
                    idx = this.Text.IndexOf(",");
                    if (idx >= 0)
                        this.SelectionStart = idx + 1;
                }
				else if (Char.IsDigit(e.KeyChar))
				{
					idx = this.Text.IndexOf(MaskHelper.Comma);
					if (this.SelectionLength > 0)
					{
						e.Handled = true;
						// 소수점 포함하여 부분선택시 선택영역에서 소수점이하는 제외처리
						if ((idx >= 0) && ((this.SelectionStart <= idx) && (this.SelectionStart + this.SelectionLength >= idx)))
						{
							//선택된Text가 ".00"형태일때 MaxinumCipher만큼 모두 입력되었으면 소수이하 첫번째 변경
							if (this.SelectionStart == idx)
							{
                                if (this.Text.Replace(MaskHelper.SplitNumber, "").Replace("-", "").Length - (this.decimalDigits + 1) >= this.maxinumCipher)
								{
									this.SelectionLength = 1;
									this.SelectionStart += 1;
									this.SelectedText = e.KeyChar.ToString();
								}
								else
								{
									this.SelectionLength = idx - this.SelectionStart;
									this.SelectedText = e.KeyChar.ToString();
								}
							}
							else
							{
								this.SelectionLength = idx - this.SelectionStart;
								this.SelectedText = e.KeyChar.ToString();
							}
						}
						else if ((idx >= 0) && (this.SelectionStart > idx))  //소수점이하 부분선택시는 한개를 선택하여 선택Text만 변경
						{
							this.SelectionLength = 1;
							this.SelectedText = e.KeyChar.ToString();
						}
						else
						{
							//선택된 Text가 ,이면 MaxinumCipher만큼 입력되었을때 ,아래의 값을 변경
                            if (this.SelectedText == MaskHelper.SplitNumber)
							{
								if (this.decimalDigits > 0)
								{
                                    if (this.Text.Replace(MaskHelper.SplitNumber, "").Replace("-", "").Length - (this.decimalDigits + 1) >= this.maxinumCipher)
									{
										this.SelectionStart += 1; //다음으로 이동
										this.SelectedText = e.KeyChar.ToString();
									}
									else
										this.SelectedText = e.KeyChar.ToString();
								}
								else
								{
                                    if (this.Text.Replace(MaskHelper.SplitNumber, "").Replace("-", "").Length >= this.maxinumCipher)
									{
										this.SelectionStart += 1; //다음으로 이동
										this.SelectedText = e.KeyChar.ToString();
									}
									else
										this.SelectedText = e.KeyChar.ToString();
								}
							}
							else
								this.SelectedText = e.KeyChar.ToString();
						}
					}
					else
					{
						if ((idx >= 0) && (this.SelectionStart > idx))
						{
							e.Handled = true;
							//Digit를 다 채웠으면 입력불가
							if (this.SelectionStart >= this.Text.Length)
								return;
							this.SelectionLength = 1;
							this.SelectedText = e.KeyChar.ToString();
							this.SelectionLength = 0;
						}
						//숫자입력시 maxinumCipher만큼만 입력가능 (Digits 제외)
						//최초 -입력시는 -는 길이에서 제외
						if (this.decimalDigits > 0)
						{
                            if (this.Text.Replace(MaskHelper.SplitNumber, "").Replace("-", "").Length - (this.decimalDigits + 1) >= this.maxinumCipher)
								e.Handled = true;
						}
						else
						{
                            if (this.Text.Replace(MaskHelper.SplitNumber, "").Replace("-", "").Length >= this.maxinumCipher)
								e.Handled = true;
						}
					}

				}
				else if (e.KeyChar == 8) // BackSpace
				{
                    idx = this.Text.IndexOf(MaskHelper.Comma);
					// Decimal Digits가 있고, Start위치가 .보다 크면 해당위치에 0로 채움
					if ((idx >= 0) && (this.SelectionStart > idx)) 
					{
						e.Handled = true;
						// SelectionStart위치 변경
						if (this.SelectionStart > 0)
							this.SelectionStart--;
						// 변경후 SelectionStart가 .위치에 없을때 문자 0로 채움
						if (this.SelectionStart != idx)
						{
							this.SelectionLength = 1;
							this.SelectedText = MaskHelper.CZeroChar.ToString();
							// SelectedText를 변경하면 SelectionStart가 1증가 -> 복구
							if (this.SelectionStart > 0)
								this.SelectionStart--;
							this.SelectionLength = 0;
						}
					}
				}
			}
			else
				e.Handled = true;
		}
		/// <summary>
		/// Key입력시 Time형 MaskType에 지정된 Mask에 따라 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected virtual void MaskTime(KeyPressEventArgs e)
		{
			string setText = "";
			int selectionStart = 0;
			DateTimeGroup group = DateTimeGroup.Hour;

			// Mask정보가 없으면 Check하지 않음
			if (this.maskSymbols.Count < 1) return;
			
			e.Handled = true;

			if (IsCorrectChar(e.KeyChar))
			{
				// 전체선택이면 NullText Set
				if(this.SelectedText == this.Text)
				{
					this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					// 초기 SelectStart Set
					SetSelectionStart(0);
				}
				if (e.KeyChar == 8)  //BackSpace Key
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
						SetEmptyText();
					else
					{
						// SelectionStart위치 변경
						if (this.SelectionStart > 0)
							this.SelectionStart--;
						// Start위치가 Seperator Pos에 없으면 해당위치에 Space로 채움
						if (!IsInSeperatorPos(this.SelectionStart)) 
						{
							this.SelectionLength = 1;
							this.SelectedText = MaskHelper.CZeroChar.ToString();
							// SelectedText를 변경하면 SelectionStart가 1증가 -> 복구
							if (this.SelectionStart > 0)
								this.SelectionStart--;
							this.SelectionLength = 0;
						}
					}
				}
				else
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
						SetEmptyText();

					// Mask가 모두 입력되었으면 Return
					if (((MaskSymbol) this.maskSymbols[maskSymbols.Count -1]).SepPos <= this.SelectionStart) return;

					// Start위치가 Seperator Pos에 없으면 해당위치에 KeyChar로 채움(Month,Day는 Valid Check)
					if (!IsInSeperatorPos(this.SelectionStart))
					{
						group = FindDateTimeGroup(this.SelectionStart);
						if (IsValidDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
						{
							this.SelectionStart = selectionStart;
							SetSelectedText(setText);
						}
						else
							return;
					}
						//Seperator위치이면 SelectionStart 변경후 해당위치에 KeyChar를 채움
					else
					{
						SetSelectionStart(this.SelectionStart);
						group = FindDateTimeGroup(this.SelectionStart);
						if (IsValidDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
						{
							this.SelectionStart = selectionStart;
							SetSelectedText(setText);
						}
						else
							return;
					}
				}
			}
		}
		/// <summary>
		/// Key입력시 Date형 MaskType에 지정된 Mask에 따라 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected virtual void MaskDate(KeyPressEventArgs e)
		{
			string setText = "";
			int selectionStart = 0;
			DateTimeGroup group = DateTimeGroup.Year;
			// Mask정보가 없으면 Check하지 않음
			if (this.maskSymbols.Count < 1) return;
			
			e.Handled = true;

			if (IsCorrectChar(e.KeyChar))
			{
				// 전체선택이면 NullText Set
				if(this.SelectedText == this.Text)
				{
					this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					// 초기 SelectStart Set
					SetSelectionStart(0);
				}
				if (e.KeyChar == 8)  //BackSpace
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
					{
						SetEmptyText();
					}
					else
					{
						// SelectionStart위치 변경
						if (this.SelectionStart > 0)
							this.SelectionStart--;
						// Start위치가 Seperator Pos에 없으면 해당위치에 Space로 채움
						if (!IsInSeperatorPos(this.SelectionStart)) 
						{
							this.SelectionLength = 1;
							this.SelectedText = MaskHelper.CZeroChar.ToString();
							// SelectedText를 변경하면 SelectionStart가 1증가 -> 복구
							if (this.SelectionStart > 0)
								this.SelectionStart--;
							this.SelectionLength = 0;
						}
					}
				}
				else
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
						SetEmptyText();
					// Mask가 모두 입력되었으면 Return
					if (((MaskSymbol) this.maskSymbols[maskSymbols.Count -1]).SepPos <= this.SelectionStart) return;

					// Start위치가 Seperator Pos에 없으면 해당위치에 KeyChar로 채움(Month,Day는 Valid Check)
					if (!IsInSeperatorPos(this.SelectionStart))
					{
						group = FindDateTimeGroup(this.SelectionStart);
						switch (group)
						{
							case DateTimeGroup.Year:
								SetSelectedText(e.KeyChar.ToString());
								break;
							case DateTimeGroup.Month:
							case DateTimeGroup.Day:
								if (IsValidDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
								{
									this.SelectionStart = selectionStart;
									SetSelectedText(setText);
								}
								else
									return;
								break;
							default:
								return;
						}
					}
					else //Seperator위치이면 SelectionStart 변경후 해당위치에 KeyChar를 채움
					{
						SetSelectionStart(this.SelectionStart);
						group = FindDateTimeGroup(this.SelectionStart);
						switch (group)
						{
							case DateTimeGroup.Year:
								SetSelectedText(e.KeyChar.ToString());
								break;
							case DateTimeGroup.Month:
							case DateTimeGroup.Day:
								if (IsValidDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
								{
									this.SelectionStart = selectionStart;
									SetSelectedText(setText);
								}
								else
									return;
								break;
							default:
								return;
						}
					}
				}
			}
		}
	
		/// <summary>
		/// Key입력시 String형 MaskType에 지정된 Mask에 따라 Text를 설정합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected virtual void MaskString(KeyPressEventArgs e)
		{
			// Mask정보가 없으면 Check하지 않음
			if (this.maskSymbols.Count < 1) return;
			e.Handled = true;
			if (IsCorrectChar(e.KeyChar))
			{
				// 전체선택이면 NullText Set
				if(this.SelectedText == this.Text)
				{
					this.Text = MaskHelper.GetNullText(this.editMaskType, this.maskSymbols, this.decimalDigits);
					// 초기 SelectStart Set
					SetSelectionStart(0);
				}

				if (e.KeyChar == 8)
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
					{
						SetEmptyText();
					}
					else
					{
						// SelectionStart위치 변경
						if (this.SelectionStart > 0)
							this.SelectionStart--;
						// Start위치가 Seperator Pos에 없으면 해당위치에 Space로 채움
						if (!IsInSeperatorPos(this.SelectionStart)) 
						{
							this.SelectionLength = 1;
							this.SelectedText = MaskHelper.CSpaceChar.ToString();
							// SelectedText를 변경하면 SelectionStart가 1증가 -> 복구
							if (this.SelectionStart > 0)
								this.SelectionStart--;
							this.SelectionLength = 0;
						}
					}
				}
				else
				{
					if (this.SelectionLength > 0)
						SetEmptyText();

					// Mask가 모두 입력되었으면 Return
					if (((MaskSymbol) this.maskSymbols[maskSymbols.Count -1]).SepPos <= this.SelectionStart) return;

					// Start위치가 Seperator Pos에 없으면 해당위치에 KeyChar로 채움
					if (!IsInSeperatorPos(this.SelectionStart))
						SetSelectedText(e.KeyChar.ToString());
					else //Seperator위치이면 SelectionStart 변경후 해당위치에 KeyChar를 채움
					{
						SetSelectionStart(this.SelectionStart);
						SetSelectedText(e.KeyChar.ToString());
					}
				}
			}
		}
		/// <summary>
		/// EditMaskType, 기타정보에 따라 입력Key값의 유효성여부를 Check합니다.
		/// </summary>
		/// <param name="ch"> 입력 Char </param>
		/// <returns> 유효한 값이면 true, 아니면 false </returns>
		protected virtual bool IsCorrectChar(char ch)
		{
			bool   ret = false;
			switch (this.editMaskType)
			{
				case MaskType.Date:
				case MaskType.Time:
				case MaskType.DateTime:
				case MaskType.Month:
					ret = Char.IsDigit(ch)||(ch == 8);  // 숫자, BackSpace
					break;
				case MaskType.Number:
					ret = Char.IsDigit(ch)||(ch == 8);  // 숫자, BackSpace
					// minus입력가능시 Check
					if (!ret && this.minusAccept)
					{
						ret = (ch == 45);  // - 입력가능
						// minus는 맨앞에만 가능
						if (this.SelectionStart != 0) ret = false;
					}
					break;
				case MaskType.Decimal:
                    if (MaskHelper.Comma == ".")
                    {
                        ret = Char.IsDigit(ch) || (ch == 8) || (ch == 46);  // 숫자, BackSpace, .
                        // minus입력가능시 Check
                        if (!ret && this.minusAccept)
                        {
                            ret = (ch == 45);  // - 입력가능
                            // minus는 맨앞에만 가능
                            if (this.SelectionStart != 0) ret = false;
                        }
                    }
                    else
                    {
                        ret = Char.IsDigit(ch) || (ch == 8) || (ch == 44);  // 숫자, BackSpace, .
                        // minus입력가능시 Check
                        if (!ret && this.minusAccept)
                        {
                            ret = (ch == 45);  // - 입력가능
                            // minus는 맨앞에만 가능
                            if (this.SelectionStart != 0) ret = false;
                        }
                    }
					break;
				case MaskType.String:
					if (this.stringMaskChar == 'X')
						ret = Char.IsLetterOrDigit(ch);
					else
						ret = Char.IsDigit(ch);
					//BackSpace
					if (!ret) ret = (ch == 8);
					break;

			}
			return ret;
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// SelectionStart위치에 있는 Text를 변경합니다.
		/// </summary>
		/// <param name="text"> 변경할 Text </param>
		protected void SetSelectedText(string text)
		{
			this.SelectionLength = text.Length;
			this.SelectedText = text;
			this.SelectionLength = 0;
			SetSelectionStart(this.SelectionStart);
		}
		/// <summary>
		/// 현재 Cursor의 위치가 Seperator 위치인지 여부를 판단합니다.
		/// </summary>
		/// <param name="startPos"> SelectionStart 위치 </param>
		/// <returns> Seperator위치이면 true, 아니면 false </returns>
		protected bool IsInSeperatorPos(int startPos)
		{
			foreach(MaskSymbol symbol in this.maskSymbols)
				if (symbol.SepPos == startPos)
					return true;
			return false;
		}
		/// <summary>
		/// SelectionStart의 위치는 Seperator를 고려하여 다시 설정합니다.
		/// </summary>
		/// <param name="currPos"> 현재 SelectionStart의 위치 </param>
		protected void SetSelectionStart(int currPos)
		{
			int start = currPos;
			int cnt = 0;
			int bfSepPos = 0;
			foreach(MaskSymbol symbol in this.maskSymbols)
			{
				if (symbol.SepPos >= currPos)
				{
					if (cnt == 0)
					{
						if (symbol.SepPos == currPos)  // Seperator위치에 있으면 한칸이동
							start++;
						else  // 중간에 있으면 break
							break;
					}
					else if (symbol.SepPos - bfSepPos == 1)  // 연속인경우 계속위치이동
						start = symbol.SepPos + 1;
					else
						break;
					cnt++;
					bfSepPos = symbol.SepPos;
				}
			}
			this.SelectionLength = 0;
			this.SelectionStart = start;
		}
		protected void SetEmptyText()
		{
			int start = this.SelectionStart;
			string temp = this.mask.Substring(this.SelectionStart, this.SelectionLength);
			if (editMaskType == MaskType.String)
				temp = temp.Replace('X', MaskHelper.CSpaceChar).Replace('#', MaskHelper.CSpaceChar);
			else if (editMaskType == MaskType.Date)
				temp = temp.Replace('Y', MaskHelper.CZeroChar).Replace('M', MaskHelper.CZeroChar).Replace('D', MaskHelper.CZeroChar);
			else if (editMaskType == MaskType.Month)
				temp = temp.Replace('Y', MaskHelper.CZeroChar).Replace('M', MaskHelper.CZeroChar);
			else if (editMaskType == MaskType.DateTime)
				temp = temp.Replace('Y', MaskHelper.CZeroChar).Replace('M', MaskHelper.CZeroChar).Replace('D', MaskHelper.CZeroChar).Replace('H', MaskHelper.CZeroChar).Replace('I', MaskHelper.CZeroChar).Replace('S', MaskHelper.CZeroChar);
			else
				temp = temp.Replace('H', MaskHelper.CZeroChar).Replace('M', MaskHelper.CZeroChar).Replace('I', MaskHelper.CZeroChar).Replace('S', MaskHelper.CZeroChar);
			//선택된 Text를 변경함
			this.SelectedText = temp;
			//선택된 Length Clear
			this.SelectionLength = 0;
			//선택시작위치 처음 선택위치로 설정
			this.SelectionStart = start;
			//Seperator고려 입력가능한 위치로 이동
			if (this.IsInSeperatorPos(this.SelectionStart))
				SetSelectionStart(this.SelectionStart);
		}
		/// <summary>
		/// 현재 SelectionStart위치가 어떤 DateTimeGroup에 속하는지를 찾습니다.
		/// (Date,Time, DateTime형의 MaskType일때만 적용됨)
		/// </summary>
		/// <param name="startPos"> 현재 SelectionStart 위치 </param>
		/// <returns> 해당되는 DateTimeGroup Enum </returns>
		private DateTimeGroup FindDateTimeGroup(int startPos)
		{
			DateTimeGroup group = DateTimeGroup.Year;
			foreach (MaskSymbol symbol in this.maskSymbols)
			{
				if ((startPos >= (symbol.SepPos - symbol.MaskStrLen)) && (startPos < symbol.SepPos))
				{
					switch (symbol.MaskStr.ToUpper())
					{
						case "YYYY":
							group = DateTimeGroup.Year;
							break;
						case "MM":
							group = DateTimeGroup.Month;
							break;
						case "DD":
							group = DateTimeGroup.Day;
							break;
						case "HH":
							group = DateTimeGroup.Hour;
							break;
						case "MI":
							group = DateTimeGroup.Minute;
							break;
						case "SS":
							group = DateTimeGroup.Second;
							break;
					}
					break;
				}
			}
			return group;
		}
		/// <summary>
		/// 현재위치에서 입력한 문자가 유효한 DateTime값인지 여부를 Check하고, 설정할 문자열을 가져옵니다.
		/// </summary>
		/// <param name="group"> DateTimeGroup Enum </param>
		/// <param name="startPos"> 현재 SelectionStart 위치 </param>
		/// <param name="keyChar"> 입력 문자 </param>
		/// <param name="setText"> (out) 입력문자대신에 설정할 문자열 </param>
		/// <param name="selectionStart"> (out) 문자열 설정후 이동위치 </param>
		/// <returns> 유효한 문자이면 True, 아니면 false </returns>
		private bool IsValidDateTime(DateTimeGroup group, int startPos, char keyChar, out string setText, out int selectionStart)
		{
			setText = "";
			selectionStart = startPos;

			if (this.mask == "") return false;

			string groupMask = "";
			int maxValue = 0, minValue = 0, firstValue = 0;
			int start = -1, end = -1;
			string year = "0", month = "0";
			switch (group)
			{
				case DateTimeGroup.Year:
					groupMask = "YYYY";
					maxValue = DateTime.MaxValue.Year;
					minValue = DateTime.MinValue.Year;
					break;
				case DateTimeGroup.Month:
					groupMask = "MM";
					maxValue = 12;
					firstValue = 1;
					break;
				case DateTimeGroup.Day:
					groupMask = "DD";
					break;
				case DateTimeGroup.Hour:
					groupMask = "HH";
					maxValue = 23;
					firstValue = 2;
					break;
				case DateTimeGroup.Minute:
					groupMask = "MI";
					maxValue = 59;
					firstValue = 5;
					break;
				case DateTimeGroup.Second:
					groupMask = "SS";
					maxValue = 59;
					firstValue = 5;
					break;
			}
			foreach (MaskSymbol symbol in this.maskSymbols)
			{
				if (symbol.MaskStr.ToUpper() == groupMask)
				{
					if ((startPos >= symbol.SepPos - symbol.MaskStrLen) && (startPos < symbol.SepPos))
					{
						start = symbol.SepPos - symbol.MaskStrLen;
						end   = symbol.SepPos;
						break;
					}
				}
				// DD일 경우에는 YEAR, MONTH로 DayInMonth를 구하기위해 year, month값 SET
				if (group == DateTimeGroup.Day)
				{
					if (symbol.MaskStr.ToUpper() == "YYYY")
						year = this.Text.Substring(symbol.SepPos - symbol.MaskStrLen, symbol.MaskStrLen);
					if (symbol.MaskStr.ToUpper() == "MM")
						month = this.Text.Substring(symbol.SepPos - symbol.MaskStrLen, symbol.MaskStrLen);
				}
			}
			// startPos와 DateTimeGroup이 제대로 Mapping되지 않았으면 false
			if ((start == -1) || (end == -1)) return false;
			
			//setText Set
			for (int i = 0 ; i < startPos - start ; i++)
				setText += this.Text[start + i];
			// 마지막에 입력문자 SET
			setText += keyChar;
			// DD일 경우에는 YEAR, MONTH로 DayInMonth를 구해서 maxValue SET
			if(group == DateTimeGroup.Day)
			{
				//Year, Month Data 입력여부 확인
				try
				{
					maxValue = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));
					firstValue = Int32.Parse(maxValue.ToString().Substring(0,1));
				}
				catch
				{
					return false;
				}
			}
			// Valid Check
			try
			{
				if ((Int32.Parse(setText) >= minValue) && (Int32.Parse(setText) <= maxValue))
				{
					selectionStart = start;
					//Month,Day,Hour,Minute,Second는 2자리로 Padding 
					if ((group != DateTimeGroup.Year) && (setText.Length == 1))
						// MM에서 5를 입력시 05로 Padding 
						if (Int32.Parse(setText) > firstValue)
							setText = "0" + setText;

					return true;
				}
			}
			catch
			{
				return false;
			}
			return false;
		}
		#endregion

		#region GetDisplayText
		/// <summary>
		/// Mask 정보에 따른 Display할 Text를 가져옵니다.
		/// </summary>
		/// <param name="dataValue"> DataValue string </param>
		/// <returns> DisplayText </returns>
		public string GetDisplayText(string dataValue)
		{
			return MaskHelper.GetDisplayText(this.editMaskType, this.maskSymbols, this.decimalDigits, this.generalNumberFormat, dataValue);
		}
		#endregion

		#region 일본연호 관련 MaskHelper 함수
		protected virtual void MaskJapanYearDate(KeyPressEventArgs e)
		{
			string setText = "";
			int selectionStart = 0;
			DateTimeGroup group = DateTimeGroup.Year;
			// Mask정보가 없으면 Check하지 않음
			if (this.maskSymbols.Count < 1) return;
			
			e.Handled = true;

			if (IsCorrectChar(e.KeyChar))
			{
				// 전체선택이면 NullText Set
				if(this.SelectedText == this.Text)
				{
					this.Text = JapanYearHelper.GetNullText(MaskType.Date, out this.period);
					// 초기 SelectStart Set
					SetSelectionStart(PERIOD_END);
				}
				if (e.KeyChar == 8)  //BackSpace
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
					{
						SetJapanYearEmptyText(this.editMaskType);
					}
					else
					{
						// SelectionStart위치 변경(연호위치로는 이동 불가)
						if (this.SelectionStart > 0)
							this.SelectionStart--;
						if (this.SelectionStart < PERIOD_END)
						{
							this.SelectionStart = PERIOD_END;
							return;
						}
						// Start위치가 Seperator Pos에 없으면 해당위치에 Space로 채움
						if (!IsInSeperatorPos(this.SelectionStart)) 
						{
							this.SelectionLength = 1;
							this.SelectedText = MaskHelper.CZeroChar.ToString();
							// SelectedText를 변경하면 SelectionStart가 1증가 -> 복구
							if (this.SelectionStart > 0)
								this.SelectionStart--;
							this.SelectionLength = 0;
						}
					}
				}
				else
				{
					if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
						SetJapanYearEmptyText(this.editMaskType);
					// Mask가 모두 입력되었으면 Return
					if (((MaskSymbol) this.maskSymbols[maskSymbols.Count -1]).SepPos <= this.SelectionStart) return;
					//연호위치 다음으로 이동
					this.SelectionStart = Math.Max(PERIOD_END, this.SelectionStart);
					// Start위치가 Seperator Pos에 없으면 해당위치에 KeyChar로 채움(Month,Day는 Valid Check)
					if (!IsInSeperatorPos(this.SelectionStart))
					{
						group = FindJapanDateTimeGroup(this.SelectionStart);
						switch (group)
						{
							case DateTimeGroup.Year:
							case DateTimeGroup.Month:
							case DateTimeGroup.Day:
								if (IsValidJapanDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
								{
									this.SelectionStart = selectionStart;
									SetSelectedText(setText);
								}
								else
									return;
								break;
							default:
								return;
						}
					}
					else //Seperator위치이면 SelectionStart 변경후 해당위치에 KeyChar를 채움
					{
						SetSelectionStart(this.SelectionStart);
						group = FindJapanDateTimeGroup(this.SelectionStart);
						switch (group)
						{
							case DateTimeGroup.Year:
								SetSelectedText(e.KeyChar.ToString());
								break;
							case DateTimeGroup.Month:
							case DateTimeGroup.Day:
								if (IsValidJapanDateTime(group, this.SelectionStart, e.KeyChar, out setText, out selectionStart))
								{
									this.SelectionStart = selectionStart;
									SetSelectedText(setText);
								}
								else
									return;
								break;
							default:
								return;
						}
					}
				}
			}
		}
		private DateTimeGroup FindJapanDateTimeGroup(int startPos)
		{
			DateTimeGroup group = DateTimeGroup.Year;
			foreach (MaskSymbol symbol in this.maskSymbols)
			{
				if ((startPos >= (symbol.SepPos - symbol.MaskStrLen)) && (startPos < symbol.SepPos))
				{
					switch (symbol.MaskStr.ToUpper())
					{
						case "MM":
							group = DateTimeGroup.Month;
							break;
						case "DD":
							group = DateTimeGroup.Day;
							break;
					}
					break;
				}
			}
			return group;
		}
		/// <summary>
		/// 현재위치에서 입력한 문자가 유효한 DateTime값인지 여부를 Check하고, 설정할 문자열을 가져옵니다.
		/// </summary>
		/// <param name="group"> DateTimeGroup Enum </param>
		/// <param name="startPos"> 현재 SelectionStart 위치 </param>
		/// <param name="keyChar"> 입력 문자 </param>
		/// <param name="setText"> (out) 입력문자대신에 설정할 문자열 </param>
		/// <param name="selectionStart"> (out) 문자열 설정후 이동위치 </param>
		/// <returns> 유효한 문자이면 True, 아니면 false </returns>
		private bool IsValidJapanDateTime(DateTimeGroup group, int startPos, char keyChar, out string setText, out int selectionStart)
		{
			setText = "";
			selectionStart = startPos;

			string groupMask = "";
			int maxValue = 0, minValue = 0, firstValue = 0;
			int start = -1, end = -1;
			string year = "0", month = "0";
			switch (group)
			{
				case DateTimeGroup.Year:
					groupMask = "YY";
					//해당 연호의 최대년수
					maxValue = JapanYearHelper.GetMaxYear(this.period);
					minValue = 0;
					firstValue = Int32.Parse(maxValue.ToString().Substring(0,1));
					break;
				case DateTimeGroup.Month:
					groupMask = "MM";
					maxValue = 12;
					firstValue = 1;
					break;
				case DateTimeGroup.Day:
					groupMask = "DD";
					break;
			}
			foreach (MaskSymbol symbol in this.maskSymbols)
			{
				if (symbol.MaskStr == groupMask)
				{
					if ((startPos >= symbol.SepPos - symbol.MaskStrLen) && (startPos < symbol.SepPos))
					{
						start = symbol.SepPos - symbol.MaskStrLen;
						end   = symbol.SepPos;
						break;
					}
				}
				// DD일 경우에는 YEAR, MONTH로 DayInMonth를 구하기위해 year, month값 SET
				if (group == DateTimeGroup.Day)
				{
					if (symbol.MaskStr.ToUpper() == "YY")
					{
						year = this.Text.Substring(3,2);
						year = JapanYearHelper.ConvertToYear(this.period, Int32.Parse(year)).ToString("0000");
					}
					if (symbol.MaskStr.ToUpper() == "MM")
						month = this.Text.Substring(symbol.SepPos - symbol.MaskStrLen, symbol.MaskStrLen);
				}
			}
			// startPos와 DateTimeGroup이 제대로 Mapping되지 않았으면 false
			if ((start == -1) || (end == -1)) return false;
			
			//setText Set
			for (int i = 0 ; i < startPos - start ; i++)
				setText += this.Text[start + i];
			// 마지막에 입력문자 SET
			setText += keyChar;
			// DD일 경우에는 YEAR, MONTH로 DayInMonth를 구해서 maxValue SET
			if(group == DateTimeGroup.Day)
			{
				//Year, Month Data 입력여부 확인
				try
				{
					maxValue = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));
					firstValue = Int32.Parse(maxValue.ToString().Substring(0,1));
				}
				catch
				{
					return false;
				}
			}
			// Valid Check
			try
			{
				if ((Int32.Parse(setText) >= minValue) && (Int32.Parse(setText) <= maxValue))
				{
					selectionStart = start;
					//Year, Month,Day,는 2자리로 Padding 
					if (setText.Length == 1)
						// MM에서 5를 입력시 05로 Padding 
						if (Int32.Parse(setText) > firstValue)
							setText = "0" + setText;
					return true;
				}
			}
			catch
			{
				return false;
			}
			return false;
		}
		private void SetJapanYearEmptyText(MaskType mType)
		{
			int start = this.SelectionStart;
			string temp;
			if (mType == MaskType.Date)
				temp = (this.period + " YY/MM/DD").Substring(this.SelectionStart, this.SelectionLength);
			else
				temp = (this.period + " YY/MM").Substring(this.SelectionStart, this.SelectionLength);
			temp = temp.Replace('Y', MaskHelper.CZeroChar).Replace('M', MaskHelper.CZeroChar).Replace('D', MaskHelper.CZeroChar);

			//선택된 Text를 변경함
			this.SelectedText = temp;
			//선택된 Length Clear
			this.SelectionLength = 0;
			//선택시작위치 처음 선택위치로 설정 (시작위치는 3)
			this.SelectionStart = Math.Max(3,start);
			//Seperator고려 입력가능한 위치로 이동
			if (this.IsInSeperatorPos(this.SelectionStart))
				SetSelectionStart(this.SelectionStart);
		}
		#endregion
	}

	#region XEditMaskDesigner
	/// <summary>
	/// XEditMask의 Designer입니다.
	/// </summary>
	internal class XEditMaskDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		private bool changeFlag = false;
		/// <summary>
		/// Designer를 초기화 합니다.
		/// </summary>
		/// <param name="component"> Designer를 가진 IComponent 개체 </param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			// Hook up events
			ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
			s.SelectionChanged += new EventHandler(OnSelectionChanged);
			IComponentChangeService c = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			c.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
		}

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


		private void OnSelectionChanged(object sender, System.EventArgs e)
		{
			if (!changeFlag)
			{
				ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
		
				//Selected된 상태이면 속성 동적으로 변경
				if (s.GetComponentSelected(this.Component))
				{
					changeFlag = true;
					// EditMaskType이 바뀌면 속성 동적으로 변경
					//Refresh를 하면 PreFilterProperties,PostFilterProperties call
					TypeDescriptor.Refresh(this.Component);
				}
			}
		}
		private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
			if (e.Component is XEditMask)
			{
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				// 2005.11.30 IsJapanYearType의 속성이 바뀔때도 처리함
				if (e.Member != null)
				{
					if ((e.Member.Name == "EditMaskType") || (e.Member.Name == "IsJapanYearType"))
					{
						changeFlag = true;
						// EditMaskType이 바뀌면 속성 동적으로 변경
						//Refresh를 하면 PreFilterProperties,PostFilterProperties call
						TypeDescriptor.Refresh(this.Component);
					}
				}
			}
		}
		/// <summary>
		/// Designer의 리소스를 해제합니다.
		/// (override) 연결된 EventHandler를 해제합니다.
		/// </summary>
		/// <param name="disposing"> disposing 여부 </param>
		protected override void Dispose(bool disposing)
		{
			ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
			IComponentChangeService c = (IComponentChangeService) GetService(typeof(IComponentChangeService));

			// Unhook events
			s.SelectionChanged -= new EventHandler(OnSelectionChanged);
			c.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
			base.Dispose(disposing);
		}
		/// <summary>
		/// 디자이너에서 TypeDescriptor를 통해 노출되는 속성 집합의 항목을 변경하거나 제거하도록 합니다.
		/// (override) EditMaskType에 따라 속성을 동적으로 변경합니다.
		/// </summary>
		/// <param name="properties"> 구성 요소의 클래스에 대한 속성입니다 </param>
		protected override void PostFilterProperties(System.Collections.IDictionary properties)
		{
			// MaskType속성 변경시만 Property Change
			if (changeFlag && (this.Control != null) && (this.Control is XEditMask))
			{
				XEditMask editMask = (XEditMask) this.Control;
				switch (editMask.EditMaskType)
				{
					case MaskType.Date:
					case MaskType.Month:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("GeneralNumberFormat");
						//JapanYearType이 true이면 Mask remove
						if (editMask.IsJapanYearType)
							properties.Remove("Mask");
						break;
					case MaskType.String:
					case MaskType.DateTime:
					case MaskType.Time:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("GeneralNumberFormat");
						//IsJapanYearType 속성 Remove
						properties.Remove("IsJapanYearType");
						break;
					case MaskType.Number:
						// Mask, DecimalDigits Remove
						properties.Remove("DecimalDigits");
						properties.Remove("Mask");
						//IsJapanYearType 속성 Remove
						properties.Remove("IsJapanYearType");
						break;
					case MaskType.Decimal:
						//Mask Remove
						properties.Remove("Mask");
						//IsJapanYearType 속성 Remove
						properties.Remove("IsJapanYearType");
						break;
				}
			}
			
			base.PostFilterProperties(properties);
		}
		/// <summary>
		/// 구성 요소가 TypeDescriptor를 통해 노출하는 속성 집합을 조정합니다.
		/// (override) EditMaskType에 따른 동적변경속성을 추가합니다.
		/// </summary>
		/// <param name="properties"> 구성 요소의 클래스에 대한 속성입니다 </param>
		protected override void PreFilterProperties(System.Collections.IDictionary properties)
		{
			base.PreFilterProperties(properties);
			// 동적으로 변경할 Property Add
			if ((this.Control != null) && (this.Control is XEditMask))
			{
				XEditMask editMask = (XEditMask) this.Control;
				if (!properties.Contains("Mask"))
					properties.Add("Mask", editMask.Mask);
				if (!properties.Contains("DecimalDigits"))
					properties.Add("DecimalDigits", editMask.DecimalDigits);
				if (!properties.Contains("MinusAccept"))
					properties.Add("MinusAccept", editMask.MinusAccept);
				if (!properties.Contains("MaxinumCipher"))
					properties.Add("MaxinumCipher", editMask.MaxinumCipher);
				if (!properties.Contains("GeneralNumberFormat"))
					properties.Add("GeneralNumberFormat", editMask.GeneralNumberFormat);
				if (!properties.Contains("IsJapanYearType"))
					properties.Add("IsJapanYearType", editMask.IsJapanYearType);
			}
		}
	}
	#endregion
}
