using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace IHIS.Framework
{
    /// <summary>
    /// XDatePicker에 대한 요약 설명입니다.
    /// (IHIS.X.Magic.Docking.IPopupControl를 상속받은 이유는 이 컨트롤을 사용하는 화면이 Docking형태로 열릴때
    /// 날짜창을 Popup하면서 생기는 문제를 방지하기 위해 상속(자세한 내용은 IPopupControl Comment참조))
    /// </summary>
    [ToolboxBitmap(typeof(IHIS.Framework.XDatePicker), "Images.XDateTimePicker.bmp")]
    public class XDatePicker : IHIS.Framework.XTextBox, IHIS.X.Magic.Docking.IPopupControl
    {
        #region Enum, Struct
        /// <summary>
        /// Date의 Group을 나타내는 Enum입니다.
        /// </summary>
        private enum DateGroup
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
            Day
        }
        #endregion

        #region Class Fields
        const int PERIOD_END = 3;
        private string period = "平成";

        const int pickerButtonWidth = 18;
        private Image pickerImage;
        private bool buttonHover = false;
        private bool buttonPressed = false;
        private Keys clickHotKey = Keys.F4;  //Click 처리를 할 Hot Key 정의
        // Mask 관련
        private string mask = "YYYY/MM/DD";
        private ArrayList maskSymbols = new ArrayList();
        private bool isCopyKeyDown = false;  //Ctrl + C를 눌렀는지 여부

        //FormPicker 관련
        private DatePickerForm formPicker = null;
        private bool isPopupedByClick = false; //Click에 의해 PopUp 되었는지 여부
        private bool isJapanYearType = false;  //연호를 쓰는 Type인지 여부
        // TODO demo
        //private bool isJapanYearType = true;  //연호를 쓰는 Type인지 여부
        //MED-11258
        private bool isVietnameseYearType = false;
        #endregion

        #region Properties
        /// <summary>
        /// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
        /// </summary>
        protected override string DataValue
        {
            get
            {
                if (!this.isJapanYearType)
                    return MaskHelper.GetDataValue(MaskType.Date, this.maskSymbols, this.Text);
                else  //일본연호 표시를 DataValue는 YYYY/MM/DD로 Return
                    return JapanYearHelper.GetDataValue(MaskType.Date, this.Text);
            }
            set
            {
                // DisplayText로 Text Set
                if (!this.isJapanYearType)
                {
                    //MED-11258
                    if (Thread.CurrentThread.CurrentUICulture.Name == "vi-VN" && this.mask == MaskHelper.CDateVietnameseMask && this.isVietnameseYearType == true)
                    {
                        value = DateTime.Parse(value).ToString("dd/MM/yyyy");
                        Text = MaskHelper.GetVietnameseDisplayText(MaskType.Date, this.maskSymbols, 0, false, value, true, false);
                    }
                    else
                        Text = MaskHelper.GetDisplayText(MaskType.Date, this.maskSymbols, 0, false, value);
                }
                else
                {
                    Text = JapanYearHelper.GetDisplayText(MaskType.Date, value, out this.period);
                }
            }
        }
        [Browsable(true), Category("추가속성"), DefaultValue(Keys.F4),
        Description("Click을 발생시킬 Hot Key를 지정합니다.")]
        public Keys ClickHotKey
        {
            get { return clickHotKey; }
            set { clickHotKey = value; }
        }
        /// <summary>
        /// 컨트롤이 편집가능한지 여부를 가져오거나 설정합니다.
        /// </summary>
        [Browsable(true), Category("추가속성"), DefaultValue(false),
        MergableProperty(true),
        Description("Protect속성을 지정합니다.")]
        public new bool Protect
        {
            get { return base.Protect; }
            set
            {
                base.Protect = value;
            }
        }
        [Browsable(true), Category("추가속성"), DefaultValue(false),
        MergableProperty(true),
        Description("일본 연호 Type인지 여부를 지정합니다.")]
        public bool IsJapanYearType
        {
            get { return isJapanYearType; }
            set
            {
                if (isJapanYearType != value)
                {
                    isJapanYearType = value;
                    if (value)  //maskSymbols 다시 SET
                    {
                        JapanYearHelper.SetMaskSymbols(MaskType.Date, maskSymbols);
                        this.Text = JapanYearHelper.GetNullText(MaskType.Date, out this.period);
                    }
                    else  //MaskSymbols Text 다시 설정
                    {
                        this.mask = MaskHelper.CDateDefaultMask;
                        MaskHelper.SetMaskSymbols(MaskType.Date, this.mask, maskSymbols);
                        this.Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);

                    }
                }
            }
        }

        //MED-11258
        public bool IsVietnameseYearType
        {
            get { return isVietnameseYearType; }
            set
            {
                isVietnameseYearType = value;
                //MED-11258
                if (Thread.CurrentThread.CurrentUICulture.Name == "vi-VN" && isVietnameseYearType)
                {
                    this.mask = MaskHelper.CDateVietnameseMask;
                    MaskHelper.SetVietnameseMaskSymbols(MaskType.Date, this.mask, maskSymbols);
                    this.Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);

                }
            }
        }

        #endregion

        #region Original Property 재정의
        //ControlType은 Date만 가능함
        [Browsable(false)]
        public override ControlDataType ContType
        {
            get { return ControlDataType.Date; }
        }
        /// <summary>
        /// 문자입력의 최대값을 Byte단위로 계산할지 여부를 가져오거나 설정합니다.
        /// (EditMask에서는 기능없음)
        /// </summary>
        [Browsable(false), DefaultValue(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ApplyByteLimit
        {
            get { return false; }
            set { }
        }
        /// <summary>
        /// MaxLength도달시 TAB키 자동발생 기능은 없음
        /// </summary>
        [Browsable(false), DefaultValue(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool AutoTabAtMaxLength
        {
            get { return base.AutoTabAtMaxLength; }
            set { base.AutoTabAtMaxLength = value; }
        }

        /// <summary>
        /// 여러 줄을 입력할 수 있는지 여부를 가져오거나 설정합니다.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public override bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = value; }
        }
        /// <summary>
        /// Text를 설정합니다.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public new bool AcceptsReturn
        {
            get { return base.AcceptsReturn; }
            set { base.AcceptsReturn = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public new bool AcceptsTab
        {
            get { return base.AcceptsTab; }
            set { base.AcceptsTab = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public new char PasswordChar
        {
            get { return base.PasswordChar; }
            set { base.PasswordChar = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public new ScrollBars ScrollBars
        {
            get { return base.ScrollBars; }
            set { base.ScrollBars = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public new bool WordWrap
        {
            get { return base.WordWrap; }
            set { base.WordWrap = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        Browsable(false)]
        public new string[] Lines
        {
            get { return base.Lines; }
            set { base.Lines = value; }
        }

        #endregion

        #region Events
        // Interface Event
        /// <summary>
        /// FindButton을 클릭할 때 발생하는 Event입니다.
        /// </summary>
        [Browsable(true),
        Category("추가이벤트"),
        Description("FindButton을 클릭할 때 발생합니다.")]
        public event CancelEventHandler PickerClick;
        #endregion

        #region 생성자
        public XDatePicker()
        {
            // Assembly에서 Image Get
            pickerImage = DrawHelper.PickerImage;
            //MaskSymbols SET

            //MED-11258
            //if (!isJapanYearType)
            //{
            //    this.mask = (Thread.CurrentThread.CurrentUICulture.Name == "vi-VN") ? MaskHelper.CDateVietnameseMask : MaskHelper.CDateDefaultMask;
            //}

            // MED-12235: Change the mask of the DateTimePicker
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "vi-VN")
            {
                this.mask = MaskHelper.CDateVietnameseMask;
            }
            MaskHelper.SetMaskSymbols(MaskType.Date, this.mask, this.maskSymbols);
            //NullText Set
            this.Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);

            //EditMaskType여부 SET(true)
            this.IsEditMaskType = true;

            //Run Time시에 FormPicker 생성
            if (!this.DesignMode)
            {
                this.formPicker = new DatePickerForm();
                //달력 선택 Event Handling
                this.formPicker.calendar.DateSelected += new DateRangeEventHandler(OnCalendarDateSelected);
                //취소 버튼
                this.formPicker.btnCancel.Click += new System.EventHandler(btnCancel_Click);
            }
        }
        #endregion

        #region Dispose (<MEMORY LEAK> 관련)
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //<MEMORY LEAK> Form Displose
                if (this.formPicker != null)
                    this.formPicker.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Pickter Form 관련 EventHandler
        private void OnCalendarDateSelected(object sender, DateRangeEventArgs e)
        {
            //Form Hide, Flag Clear
            this.formPicker.Hide();
            this.isPopupedByClick = false;
            //DataValue Set
            this.DataValue = formPicker.calendar.SelectionStart.ToString("yyyy/MM/dd").Replace("-", "/");
            //2005.07.12 날짜 선택시에 DataValidating Event Call (날짜직접입력과 선택시 동일한 이벤트에서 다음처리를 할 수 있도록 함)
            if (this.DataChanged)
            {
                DataValidatingEventArgs ve = new DataValidatingEventArgs(false, DataValue);
                this.DataChanged = false; //Call전에 False
                OnDataValidating(ve);
                //Cancel이면 dataChanged 다시 SET
                if (ve.Cancel)
                    DataChanged = true;
            }
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            //Form Hide, Flag Clear
            this.formPicker.Hide();
            this.isPopupedByClick = false;
        }
        #endregion

        #region Event Invokers
        protected virtual void OnPickerClick(CancelEventArgs e)
        {
            if (PickerClick != null)
                PickerClick(this, e);
        }
        #endregion

        #region MaskDate
        /// <summary>
        /// Key입력시 Date형 MaskType에 지정된 Mask에 따라 Text를 설정합니다.
        /// </summary>
        /// <param name="e"> KeyPressEventArgs </param>
        protected virtual void MaskDate(KeyPressEventArgs e)
        {
            string setText = "";
            int selectionStart = 0;
            DateGroup group = DateGroup.Year;
            // Mask정보가 없으면 Check하지 않음
            if (this.maskSymbols.Count < 1) return;

            e.Handled = true;

            if (IsCorrectChar(e.KeyChar))
            {
                // 전체선택이면 NullText Set
                if (this.SelectedText == this.Text)
                {
                    // MED-12235: Allow input day in the first
                    //this.Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);
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
                    if (((MaskSymbol)this.maskSymbols[maskSymbols.Count - 1]).SepPos <= this.SelectionStart) return;

                    // Start위치가 Seperator Pos에 없으면 해당위치에 KeyChar로 채움(Month,Day는 Valid Check)
                    if (!IsInSeperatorPos(this.SelectionStart))
                    {
                        group = FindDateGroup(this.SelectionStart);
                        
                        switch (group)
                        {
                            case DateGroup.Year:
                                SetSelectedText(e.KeyChar.ToString());
                                break;
                            case DateGroup.Month:
                            case DateGroup.Day:
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
                        group = FindDateGroup(this.SelectionStart);
                        switch (group)
                        {
                            case DateGroup.Year:
                                SetSelectedText(e.KeyChar.ToString());
                                break;
                            case DateGroup.Month:
                            case DateGroup.Day:
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
        /// EditMaskType, 기타정보에 따라 입력Key값의 유효성여부를 Check합니다.
        /// </summary>
        /// <param name="ch"> 입력 Char </param>
        /// <returns> 유효한 값이면 true, 아니면 false </returns>
        protected virtual bool IsCorrectChar(char ch)
        {
            return Char.IsDigit(ch) || (ch == 8);  // 숫자, BackSpace
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

            //Popup Hide
            this.formPicker.Hide();
            //Flag는 남겨둠
            //this.isPopupedByClick = false; //Flag Clear

            //ImeMode 변경불가
            this.ImeMode = ImeMode.Disable;
            //전체 선택
            if (!this.isJapanYearType)
                this.SelectAll();
            else
                this.SetSelectionStart(PERIOD_END);  //연호 다음으로 SET
        }
        protected override void OnLostFocus(EventArgs e)
        {

            CheckEndDate();
            base.OnLostFocus(e);
            //PopUp에 Focus가 없으면 Hide
            if (!formPicker.ContainsFocus)
            {
                this.formPicker.Hide();
                this.isPopupedByClick = false; //Flag Clear
            }
        }
        protected void CheckEndDate()
        {
            if (NetInfo.Language == LangMode.Jr && isJapanYearType == false && DataValue != "")
            { 
            //compare
                DateTime selectTime = Convert.ToDateTime(DataValue);
                DateTime maxEndTime = Convert.ToDateTime("9998/12/31");
                int result = DateTime.Compare(selectTime, maxEndTime);
                if (result > 0) DataValue = maxEndTime.ToString("yyyy/MM/dd");
            }
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
                if (!e.Handled && !this.ReadOnly && this.Enabled)
                {
                    //Mask Set
                    if (!this.isJapanYearType)
                        MaskDate(e);
                    else
                        MaskJapanYearDate(e);
                }
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

            if (e.Control && (e.KeyCode == Keys.C))  //Enable에 관계없이 처리
            {
                this.isCopyKeyDown = true;  //Copy Key Flag Set (OnKeyPress에서 Copy Key는 본래기능 부여)
            }
            else if (!this.Protect && this.Enabled) // 아래는 편집가능시만 적용함
            {
                if (e.KeyCode == this.clickHotKey)
                {
                    TogglePickerForm(this, EventArgs.Empty);
                    //Flag Toggle
                    this.isPopupedByClick = !this.isPopupedByClick;
                }
                else if (e.KeyCode == Keys.Delete) // Delete처리, Mask가 있으면 
                {
                    // 전체선택이면 NullText Set
                    if (this.SelectedText == this.Text)
                    {
                        if (!this.isJapanYearType)
                        {
                            this.Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);
                            SetSelectionStart(0);
                        }
                        else
                        {
                            this.Text = JapanYearHelper.GetNullText(MaskType.Date, out this.period);
                            SetSelectionStart(PERIOD_END);
                        }

                        e.Handled = true;
                        return;
                    }
                    else if (this.SelectionLength > 0)
                    {
                        //Handled True
                        e.Handled = true;
                        if (!this.isJapanYearType)
                            SetEmptyText();
                        else
                            SetJapanYearEmptyText();
                    }
                    else
                    {

                        e.Handled = true;
                        if (this.isJapanYearType && this.SelectionStart < PERIOD_END) return;

                        setText = MaskHelper.CZeroChar.ToString();
                        // Seperator 위치에 있으면 다음위치로 이동
                        if (this.IsInSeperatorPos(this.SelectionStart))
                            SetSelectionStart(this.SelectionStart);
                        else
                            SetSelectedText(setText);
                    }
                }
                else if (this.isJapanYearType) // 일본연호로 표시시에 Arrow Key 반영하기
                {
                    //Up,Right는 연호증가, Down,Left는 연호감소
                    //if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Right))
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
        }
        /// <summary>
        /// MouseDown Event를 발생시킵니다.
        /// (override) Select위치가 Seperator위치이면 위치이동합니다.
        /// </summary>
        /// <param name="e"> MouseEventArgs </param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //Number형이 아닌 경우 Data가 있는 경우에는 MouseDown한 위치에 그대로
            //데이타가 없으면 첫번째 위치로 이동
            string japanPeriod = "";
            string nullText = (!this.isJapanYearType ? MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0)
                : JapanYearHelper.GetNullText(MaskType.Date, out japanPeriod));
            if (this.Text == nullText)  // 첫번째로 이동
            {
                if (!this.isJapanYearType)
                    SetSelectionStart(0);
                else //연호 다음으로 이동
                    SetSelectionStart(PERIOD_END);
            }
            else
            {
                // SelectedStart가 Seperator Position에 있으면 이동
                if (IsInSeperatorPos(this.SelectionStart))
                    SetSelectionStart(this.SelectionStart);
            }
        }
        /// <summary>
        /// Validating Event를 발생시킵니다.
        /// (override) EditMaskType에 따라 Validation Check합니다.
        /// </summary>
        /// <param name="e"> CancelEventArgs </param>
        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            //Validation 통과시
            if (!e.Cancel)
            {
                if (!this.isJapanYearType)
                {
                    // 정확한 DateTime이 아니면 NullText Set
                    try
                    {
                        DateTime.Parse(this.Text);
                    }
                    catch
                    {
                        this.Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);
                    }
                }
                else  //JapanNull text Set
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
                            this.Text = JapanYearHelper.GetNullText(MaskType.Date, out this.period);
                    }
                }
                //DataChanged Clear
                this.DataChanged = false;
            }
        }

        /// <summary>
        /// 컨트롤의 값을 Clear합니다.
        /// </summary>
        public override void ResetData()
        {
            base.ResetData();
            //Text를 NullText로 SET
            if (!this.isJapanYearType)
                Text = MaskHelper.GetNullText(MaskType.Date, this.maskSymbols, 0);
            else
                Text = JapanYearHelper.GetNullText(MaskType.Date, out this.period);

            //DataChanged Clear
            this.DataChanged = false;

        }
        #endregion

        #region Override Methods
        protected override void SetBoundsCore(int x, int y, int w, int h, BoundsSpecified bs)
        {
            if (w < pickerButtonWidth + 5)
                w = pickerButtonWidth + 5;
            base.SetBoundsCore(x, y, w, h, bs);
        }

        /// <summary>
        /// Non Client 영역 관련
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case (int)Win32.Msgs.WM_NCCALCSIZE:
                    int isValidClientArea = (int)m.WParam;
                    if (isValidClientArea != 0)
                    {
                        Win32.NCCALCSIZE_PARAMS newRect = (Win32.NCCALCSIZE_PARAMS)(Marshal.PtrToStructure(m.LParam, typeof(Win32.NCCALCSIZE_PARAMS)));
                        newRect.rgrc0.right -= pickerButtonWidth - 1;
                        newRect.rgrc2.right -= pickerButtonWidth - 1;
                        Marshal.StructureToPtr(newRect, m.LParam, true);
                    }
                    else
                    {
                        Win32.RECT newRect = (Win32.RECT)(Marshal.PtrToStructure(m.LParam, typeof(Win32.RECT)));
                        newRect.right -= pickerButtonWidth - 1;
                        Marshal.StructureToPtr(newRect, m.LParam, true);
                    }
                    break;
                case (int)Win32.Msgs.WM_NCHITTEST:
                    int x = (int)m.LParam % 0x10000;
                    int y = (int)m.LParam / 0x10000;
                    Point pos = this.PointToClient(new Point(x, y));
                    buttonPressed = false;
                    if (pos.X >= (Bounds.Width - pickerButtonWidth))
                    {
                        m.Result = (IntPtr)19;		// Object
                        if (!this.Protect && this.Enabled)
                        {
                            if (!buttonHover)
                            {
                                buttonHover = true;
                                DrawPickerButton(m.HWnd);
                            }
                        }
                        else
                        {
                            if (buttonHover)
                            {
                                buttonHover = false;
                                DrawPickerButton(m.HWnd);
                            }
                        }
                    }
                    else if (buttonHover)
                    {
                        buttonHover = false;
                        DrawPickerButton(m.HWnd);
                    }
                    break;
                case (int)Win32.Msgs.WM_NCPAINT:
                    DrawPickerButton(m.HWnd);
                    m.Result = IntPtr.Zero;
                    break;
                case (int)Win32.Msgs.WM_NCLBUTTONUP:
                    if (!this.Protect && this.Enabled)
                    {
                        buttonPressed = false;
                        TogglePickerForm(this, EventArgs.Empty);
                        //Flag Toggle
                        this.isPopupedByClick = !this.isPopupedByClick;
                        DrawPickerButton(m.HWnd);
                    }
                    break;
                case (int)Win32.Msgs.WM_NCLBUTTONDOWN:
                    if (!this.Protect && this.Enabled)
                    {
                        if (this.Focus())
                        {
                            buttonPressed = true;
                            DrawPickerButton(m.HWnd);
                        }
                    }
                    break;
                case (int)Win32.Msgs.WM_NCMOUSELEAVE:
                    if (buttonHover)
                    {
                        buttonHover = false;
                        DrawPickerButton(m.HWnd);
                    }
                    break;
                case (int)Win32.Msgs.WM_NCMOUSEMOVE:
                    RequestMouseLeaveMessage(m.HWnd);
                    break;
            }
        }
        #endregion

        #region Picker창 팝업 관련
        private void TogglePickerForm(object sender, EventArgs e)
        {
            if (!this.formPicker.Visible)
            {
                //Enabled, ReadOnly Return
                if (!this.Enabled || this.ReadOnly) return;

                //버튼영역 Click을 했으면 Return
                if (this.isPopupedByClick) return;

                //Find Click Event 발생시킴
                if (PickerClick != null)
                {
                    CancelEventArgs xe = new CancelEventArgs(false);
                    OnPickerClick(xe);
                    //Find 조건이 맞지 않으면 Find창 띄우지 않음
                    if (xe.Cancel) return;
                }

                SetPickerFormPosition();

                //Data설정
                DateTime defaultDate = DateTime.Today;
                try
                {
                    string dataValue = this.DataValue;
                    if (dataValue != "") //YYYY/MM/DD형식
                        defaultDate = DateTime.Parse(dataValue);
                    this.formPicker.calendar.SelectionStart = defaultDate;
                    this.formPicker.calendar.SelectionEnd = defaultDate;
                }
                catch
                {
                    defaultDate = DateTime.Today;
                    this.formPicker.calendar.SelectionStart = defaultDate;
                    this.formPicker.calendar.SelectionEnd = defaultDate;
                }

                this.formPicker.Show();
                this.formPicker.BringToFront();
                this.formPicker.calendar.Focus();

                //ParentForm Active 유지
                Form parentForm = this.FindForm();
                if (parentForm != null)
                {
                    User32.SendMessage(parentForm.Handle, 0x0086, 1, 0);  //WM_NCACTIVATE
                    //parentForm이 TopMost이면 formPicker도 TopMost 설정
                    if (parentForm.TopMost)
                        this.formPicker.TopMost = true;
                    else
                        this.formPicker.TopMost = false;
                }



            }
            else  //Visible이면 Hide
            {
                this.formPicker.Hide();
            }
        }

        private void SetPickerFormPosition()
        {
            /*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
             *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
             *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
             *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
             *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
             */
            Rectangle rc = Screen.PrimaryScreen.WorkingArea;
            // 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
            Point pos = this.PointToScreen(new Point(0, this.Height));
            // 2006.03.28 모니터 3개이상도 고려하여 반영
            if (SystemInformation.MonitorCount > 1)
            {
                //pos.X가 Second Monitor 이상에 있으면 rc 변경
                if (pos.X > rc.Width)
                {
                    //두번째 Monitor 부터 위치 파악
                    for (int i = 1; i < SystemInformation.MonitorCount; i++)
                    {
                        Rectangle sRect = Screen.AllScreens[i].WorkingArea;
                        //cont가 위치하는 Monitor 확인
                        if ((pos.X >= sRect.Left) && (pos.X <= sRect.Right))
                        {
                            rc = new Rectangle(rc.X, rc.Y, sRect.Right, sRect.Y + sRect.Height);
                            break;
                        }
                    }
                }
            }
            if (formPicker.Width > rc.Width - pos.X)
            {
                pos.X = Math.Max(rc.Width - formPicker.Width, 0);
            }
            if (formPicker.Height > rc.Height - pos.Y)
            {
                if (formPicker.Height > pos.Y - this.Height)
                    pos.Y = Math.Max(rc.Height - formPicker.Height, 0);
                else
                    pos.Y -= (formPicker.Height + this.Height);
            }
            formPicker.Location = pos;
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
            foreach (MaskSymbol symbol in this.maskSymbols)
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
            //2010.11.02 kimminsoo 수정. 편집입력시에는 3자리이상 입력 불가능. 단 테이블 내에 존재하는 平成 3자리 이상 데이터는 조회가능
            //if ( Text.Length > 11 ) Text = "平成 99/12/31";//JapanYearHelper.GetDataValue(MaskType.Date, "平成 99/12/31");

            int start = currPos;
            int cnt = 0;
            int bfSepPos = 0;
            foreach (MaskSymbol symbol in this.maskSymbols)
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
            temp = temp.Replace('Y', MaskHelper.CZeroChar).Replace('M', MaskHelper.CZeroChar).Replace('D', MaskHelper.CZeroChar);

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
        /// 현재 SelectionStart위치가 어떤 DateGroup에 속하는지를 찾습니다.
        /// (Date,Time, DateTime형의 MaskType일때만 적용됨)
        /// </summary>
        /// <param name="startPos"> 현재 SelectionStart 위치 </param>
        /// <returns> 해당되는 DateGroup Enum </returns>
        private DateGroup FindDateGroup(int startPos)
        {
            DateGroup group = DateGroup.Year;
            foreach (MaskSymbol symbol in this.maskSymbols)
            {
                if ((startPos >= (symbol.SepPos - symbol.MaskStrLen)) && (startPos < symbol.SepPos))
                {
                    switch (symbol.MaskStr.ToUpper())
                    {
                        case "YYYY":
                            group = DateGroup.Year;
                            break;
                        case "MM":
                            group = DateGroup.Month;
                            break;
                        case "DD":
                            group = DateGroup.Day;
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
        /// <param name="group"> DateGroup Enum </param>
        /// <param name="startPos"> 현재 SelectionStart 위치 </param>
        /// <param name="keyChar"> 입력 문자 </param>
        /// <param name="setText"> (out) 입력문자대신에 설정할 문자열 </param>
        /// <param name="selectionStart"> (out) 문자열 설정후 이동위치 </param>
        /// <returns> 유효한 문자이면 True, 아니면 false </returns>
        private bool IsValidDateTime(DateGroup group, int startPos, char keyChar, out string setText, out int selectionStart)
        {
            setText = "";
            selectionStart = startPos;

            string groupMask = "";
            int maxValue = 0, minValue = 0, firstValue = 0;
            int start = -1, end = -1;
            string year = "0", month = "0";
            switch (group)
            {
                case DateGroup.Year:
                    groupMask = "YYYY";
                    maxValue = DateTime.MaxValue.Year;
                    minValue = DateTime.MinValue.Year;
                    break;
                case DateGroup.Month:
                    groupMask = "MM";
                    maxValue = 12;
                    firstValue = 1;
                    break;
                case DateGroup.Day:
                    groupMask = "DD";
                    break;
            }
            foreach (MaskSymbol symbol in this.maskSymbols)
            {
                if (symbol.MaskStr.ToUpper() == groupMask)
                {
                    if ((startPos >= symbol.SepPos - symbol.MaskStrLen) && (startPos < symbol.SepPos))
                    {
                        start = symbol.SepPos - symbol.MaskStrLen;
                        end = symbol.SepPos;

                        //MED-12235: Allow validation when the day in the first of format mask
                        if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "vi-VN")
                        {
                            string yearMask = "yyyy";
                            int yearPosition = MaskHelper.CDateVietnameseMask.IndexOf(yearMask);
                            year = this.Text.Substring(yearPosition, yearMask.Length);
                            if (year == "0000") year = DateTime.Now.Year + "";

                            string monthMask = "MM";
                            int monthPosition = MaskHelper.CDateVietnameseMask.IndexOf(monthMask);
                            month = this.Text.Substring(monthPosition, monthMask.Length);
                            if (month == "00") month = DateTime.Now.Month + "";
                        }
                        break;
                    }
                }
                // DD일 경우에는 YEAR, MONTH로 DayInMonth를 구하기위해 year, month값 SET
                if (group == DateGroup.Day)
                {
                    if (symbol.MaskStr.ToUpper() == "YYYY")
                        year = this.Text.Substring(symbol.SepPos - symbol.MaskStrLen, symbol.MaskStrLen);
                    if (symbol.MaskStr.ToUpper() == "MM")
                        month = this.Text.Substring(symbol.SepPos - symbol.MaskStrLen, symbol.MaskStrLen);
                }
            }
            // startPos와 DateGroup이 제대로 Mapping되지 않았으면 false
            if ((start == -1) || (end == -1)) return false;

            //setText Set
            for (int i = 0; i < startPos - start; i++)
                setText += this.Text[start + i];
            // 마지막에 입력문자 SET
            setText += keyChar;
            // DD일 경우에는 YEAR, MONTH로 DayInMonth를 구해서 maxValue SET
            if (group == DateGroup.Day)
            {
                //Year, Month Data 입력여부 확인
                try
                {
                    maxValue = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));
                    firstValue = Int32.Parse(maxValue.ToString().Substring(0, 1));
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
                    if ((group != DateGroup.Year) && (setText.Length == 1))
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

        #region Other Private Methos (버튼 Draw)
        private void DrawPickerButton(IntPtr hwnd)
        {
            IntPtr hDC = User32.GetWindowDC(hwnd);
            Graphics g = Graphics.FromHdc(hDC);

            Rectangle buttonRect = new Rectangle(Bounds.Width - pickerButtonWidth - 1, 0, pickerButtonWidth, Bounds.Height - 1);
            g.FillRectangle(new SolidBrush(Color.Beige), buttonRect);
            Point imagePos = new Point(buttonRect.Left + (buttonRect.Width - pickerImage.Width) / 2 + 1, buttonRect.Top + (buttonRect.Height - pickerImage.Height) / 2);
            if (buttonHover && !buttonPressed)
                imagePos.Offset(0, -1);
            g.DrawImage(pickerImage, imagePos);
            Pen rectPen = null;
            if (buttonPressed)
                rectPen = new Pen(Color.LightSeaGreen);
            else if (buttonHover)
                rectPen = new Pen(XColor.ActiveBorderColor.Color);
            else
                rectPen = new Pen(XColor.NormalBorderColor.Color);

            g.DrawRectangle(rectPen, buttonRect);

            // Button에 Mouse Pointer가 있는 상태
            if (buttonHover)
            {
                g.DrawLine(Pens.White, buttonRect.Location, new Point(buttonRect.Right, buttonRect.Top));
                g.DrawLine(Pens.White, buttonRect.Location, new Point(buttonRect.Left, buttonRect.Bottom));
                g.DrawLine(Pens.DarkGray, new Point(buttonRect.Right - 1, buttonRect.Top + 1), new Point(buttonRect.Right - 1, buttonRect.Bottom - 1));
                g.DrawLine(Pens.DarkGray, new Point(buttonRect.Left + 1, buttonRect.Bottom - 1), new Point(buttonRect.Right - 1, buttonRect.Bottom - 1));
            }

            rectPen.Dispose();
            g.Dispose();
            User32.ReleaseDC(hwnd, hDC);
        }

        private void RequestMouseLeaveMessage(IntPtr hwnd)
        {
            Win32.TRACKMOUSEEVENTS tme = new Win32.TRACKMOUSEEVENTS();
            tme.cbSize = 16;
            tme.dwFlags = (uint)(Win32.TrackerEventFlags.TME_NONCLIENT | Win32.TrackerEventFlags.TME_LEAVE);
            tme.hWnd = hwnd;
            tme.dwHoverTime = 0;
            User32.TrackMouseEvent(ref tme);
        }
        #endregion

        #region 일본연호 관련 MaskHelper 함수
        protected virtual void MaskJapanYearDate(KeyPressEventArgs e)
        {
            string setText = "";
            int selectionStart = 0;
            DateGroup group = DateGroup.Year;
            // Mask정보가 없으면 Check하지 않음
            if (this.maskSymbols.Count < 1) return;

            e.Handled = true;

            if (IsCorrectChar(e.KeyChar))
            {
                // 전체선택이면 NullText Set
                if (this.SelectedText == this.Text)
                {
                    this.Text = JapanYearHelper.GetNullText(MaskType.Date, out this.period);
                    // 초기 SelectStart Set
                    SetSelectionStart(PERIOD_END);
                }
                if (e.KeyChar == 8)  //BackSpace
                {
                    if (this.SelectionLength > 0) // 선택된 영역 Empty String 채우기
                    {
                        SetJapanYearEmptyText();
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
                        SetJapanYearEmptyText();
                    // Mask가 모두 입력되었으면 Return
                    if (((MaskSymbol)this.maskSymbols[maskSymbols.Count - 1]).SepPos <= this.SelectionStart) return;
                    //연호위치 다음으로 이동
                    this.SelectionStart = Math.Max(PERIOD_END, this.SelectionStart);
                    // Start위치가 Seperator Pos에 없으면 해당위치에 KeyChar로 채움(Month,Day는 Valid Check)
                    if (!IsInSeperatorPos(this.SelectionStart))
                    {
                        group = FindJapanDateGroup(this.SelectionStart);
                        switch (group)
                        {
                            case DateGroup.Year:
                            case DateGroup.Month:
                            case DateGroup.Day:
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
                        group = FindJapanDateGroup(this.SelectionStart);
                        switch (group)
                        {
                            case DateGroup.Year:
                                SetSelectedText(e.KeyChar.ToString());
                                break;
                            case DateGroup.Month:
                            case DateGroup.Day:
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
        private DateGroup FindJapanDateGroup(int startPos)
        {
            DateGroup group = DateGroup.Year;
            foreach (MaskSymbol symbol in this.maskSymbols)
            {
                if ((startPos >= (symbol.SepPos - symbol.MaskStrLen)) && (startPos < symbol.SepPos))
                {
                    switch (symbol.MaskStr.ToUpper())
                    {
                        case "MM":
                            group = DateGroup.Month;
                            break;
                        case "DD":
                            group = DateGroup.Day;
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
        /// <param name="group"> DateGroup Enum </param>
        /// <param name="startPos"> 현재 SelectionStart 위치 </param>
        /// <param name="keyChar"> 입력 문자 </param>
        /// <param name="setText"> (out) 입력문자대신에 설정할 문자열 </param>
        /// <param name="selectionStart"> (out) 문자열 설정후 이동위치 </param>
        /// <returns> 유효한 문자이면 True, 아니면 false </returns>
        private bool IsValidJapanDateTime(DateGroup group, int startPos, char keyChar, out string setText, out int selectionStart)
        {
            setText = "";
            selectionStart = startPos;

            string groupMask = "";
            int maxValue = 0, minValue = 0, firstValue = 0;
            int start = -1, end = -1;
            string year = "0", month = "0";
            switch (group)
            {
                case DateGroup.Year:
                    groupMask = "YY";
                    //해당 연호의 최대년수
                    maxValue = JapanYearHelper.GetMaxYear(this.period);
                    minValue = 0;
                    firstValue = Int32.Parse(maxValue.ToString().Substring(0, 1));
                    break;
                case DateGroup.Month:
                    groupMask = "MM";
                    maxValue = 12;
                    firstValue = 1;
                    break;
                case DateGroup.Day:
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
                        end = symbol.SepPos;
                        break;
                    }
                }
                // DD일 경우에는 YEAR, MONTH로 DayInMonth를 구하기위해 year, month값 SET
                if (group == DateGroup.Day)
                {
                    if (symbol.MaskStr.ToUpper() == "YY")
                    {
                        year = this.Text.Substring(3, 2);
                        year = JapanYearHelper.ConvertToYear(this.period, Int32.Parse(year)).ToString("0000");
                    }
                    if (symbol.MaskStr.ToUpper() == "MM")
                        month = this.Text.Substring(symbol.SepPos - symbol.MaskStrLen, symbol.MaskStrLen);
                }
            }
            // startPos와 DateGroup이 제대로 Mapping되지 않았으면 false
            if ((start == -1) || (end == -1)) return false;

            //setText Set
            for (int i = 0; i < startPos - start; i++)
                setText += this.Text[start + i];
            // 마지막에 입력문자 SET
            setText += keyChar;
            // DD일 경우에는 YEAR, MONTH로 DayInMonth를 구해서 maxValue SET
            if (group == DateGroup.Day)
            {
                //Year, Month Data 입력여부 확인
                try
                {
                    maxValue = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));
                    firstValue = Int32.Parse(maxValue.ToString().Substring(0, 1));
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
        private void SetJapanYearEmptyText()
        {
            int start = this.SelectionStart;
            string temp = (this.period + " YY/MM/DD").Substring(this.SelectionStart, this.SelectionLength);
            temp = temp.Replace('Y', MaskHelper.CZeroChar).Replace('M', MaskHelper.CZeroChar).Replace('D', MaskHelper.CZeroChar);

            //선택된 Text를 변경함
            this.SelectedText = temp;
            //선택된 Length Clear
            this.SelectionLength = 0;
            //선택시작위치 처음 선택위치로 설정 (시작위치는 3)
            this.SelectionStart = Math.Max(3, start);
            //Seperator고려 입력가능한 위치로 이동
            if (this.IsInSeperatorPos(this.SelectionStart))
                SetSelectionStart(this.SelectionStart);
        }
        #endregion

        #region SetDefaultJapanPeriod(일본 기본 연호 Set Method)
        public void SetDefaultJapanPeriod(string period)
        {
            if (!this.isJapanYearType) return;  //일본연호 표기시만 사용
            if (!JapanYearHelper.IsValidPeriod(period)) return;
            string text = JapanYearHelper.GetNullText(MaskType.Date, out this.period);
            Text = text.Replace(this.period, period);
            this.period = period;
            this.DataChanged = false;
        }
        #endregion

    }
}
