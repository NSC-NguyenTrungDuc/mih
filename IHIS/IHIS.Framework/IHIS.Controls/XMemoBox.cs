using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace IHIS.Framework
{
	/// <summary>
	/// MemoBox에 대한 요약 설명입니다.
	/// (IHIS.X.Magic.Docking.IPopupControl를 상속받은 이유는 이 컨트롤을 사용하는 화면이 Docking형태로 열릴때
	/// 메모창을 Popup하면서 생기는 문제(Focus를 잃으면서 도킹된 화면이 닫히는 문제)를 방지하기 위해 상속(자세한 내용은 IPopupControl Comment참조))
	/// </summary>
	[ToolboxBitmap(typeof(IHIS.Framework.XMemoBox), "Images.XMemoBox.bmp")]
	[Designer(typeof(XMemoBoxDesigner))]
	public class XMemoBox : System.Windows.Forms.Control, IDataControl, IEditorControl, IHIS.X.Magic.Docking.IPopupControl
	{
		#region Class Fields
		static Color borderColor = Color.FromArgb(127,157,185);
		const int memoButtonWidth = 20;
		const int minFormWidth = 290;
		const int minFormHeight = 180;
		static Image memoImage = null;
		static ImageList memoImageList = null;

		private Keys clickHotKey = Keys.F4;  //Click 처리를 할 Hot Key 정의
		private string dataValue = string.Empty;
		private bool dataChanged = false;
		private bool enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		private Size memoFormSize = new Size(minFormWidth,minFormHeight);  //MemoForm의 Size
		private bool displayMemoText = false; //메모한 Text를 보여줄지 여부
		private int	 maxTextLength = 500; //최대문자길이
		private ImeMode textImeMode = ImeMode.NoControl;  //입력TextBox의 ImeMode를 설정합니다.
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
		
		private bool  buttonHover = false;
		private bool  buttonPressed = false;
		private Form formMemo = null;
		private XButton	btnOK = null;
		private XButton	btnClear = null;
		private XButton btnCancel = null;
		private XButton btnReserve = null;
		private XTextBox txtMemo = null;
		private Form parentForm = null;
		private bool containFocus = false;
		private bool isPopupedByClick = false; //Click에 의해 PopUp 되었는지 여부
		private StringFormat textFormat = new StringFormat();
		//Protect 관련
		private bool	readOnly = false;

		//예약글 관련
		private bool showReservedMemoButton = false;  //예약글 버튼을 보여줄지 여부
		private string reservedMemoClassName = "";
		private string reservedMemoFileName  = "";
		private bool appendReservedMemoText = false;  //예약글 선택시 기존 메모Text에 예약글을 Append할지 여부를 관리합니다.
		//예약글 관련
		private Form	formReservedMemo = null;
		private Panel	pnlReservedMemo = null;
		private Control	reservedMemoControl = null;
		private XButton	btnOK1 = null;
		private XButton btnCancel1 = null;
		private bool	isControlCreated = false;
		private object	loadParam = null;
		#endregion
		
		#region OrigProperties
		//Enabled 속성은 Control의 Enabled속성을 쓰지 않고, readOnly값을 사용
		//MemoBox의 Enabled,Protect속성에 Control의 Enabled속성을 쓰면 Control자체가 비활성화되어 MemoBox에 있는
		//메모를 보여줄수 없다. 따라서, 메모창이 Popup은 가능하게 하되 편집을 못하게 하는 것으로 처리한다.
		public new bool Enabled
		{
			get { return !readOnly;}
			set { readOnly = !value;}
		}
		[Browsable(true), DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public override Font Font
		{
			get	{ return base.Font;	}
			set	{ base.Font = value;}
		}
		#endregion

		#region Properties
		[Browsable(true), Category("추가속성"), DefaultValue(Keys.F4),
		Description("Click을 발생시킬 Hot Key를 지정합니다.")]
		public Keys ClickHotKey
		{
			get { return clickHotKey;}
			set { clickHotKey = value;}
		}
		[Browsable(true), Category("추가속성"), DefaultValue(false),
		Description("Protect속성을 지정합니다.")]
		public bool Protect
		{
			get { return readOnly;}
			set { readOnly = value;}
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
		/// 메모창에 입력할 수 있는 최대 Text길이를 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(500),
		MergableProperty(true),
		Description("메모창에 입력할 수 있는 최대 Text길이를 설정합니다.")]
		public int MaxTextLength
		{
			get { return maxTextLength; }
			set { maxTextLength = Math.Max(0,value);}
		}
		/// <summary>
		/// 메모창의 TextBox의 ImeMode를 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(ImeMode.NoControl),
		MergableProperty(true),
		Description("메모창의 TextBox의 ImeMode를 설정합니다.")]
		public ImeMode TextImeMode
		{
			get { return textImeMode; }
			set { textImeMode = value;}
		}
		/// <summary>
		/// 메모가 입력된 경우 메모 Text를 보여줄지 여부를 관리합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("메모가 입력된 경우 메모 Text를 보여줄지 여부를 관리합니다.")]
		public bool DisplayMemoText
		{
			get { return displayMemoText; }
			set 
			{ 
				if (displayMemoText != value)
				{
					displayMemoText = value;
					this.Invalidate();
				}
			}
		}
		/// <summary>
		/// Memo Form의 Size를 설정합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),
		MergableProperty(true),
		Description("Memo Form의 Size를 설정합니다.")]
		public Size MemoFormSize
		{
			get { return memoFormSize; }
			set 
			{ 
				if (memoFormSize != value)
				{
					//최초영역이상 Check
					memoFormSize.Width = Math.Max(value.Width, minFormWidth);
					memoFormSize.Height = Math.Max(value.Height, minFormHeight);
				}
			}
		}
		// Size가 기본 최소값이면 Serialize 하지 않음
		private bool ShouldSerializeMemoFormSize()
		{
			if ((memoFormSize.Width == minFormWidth) && (memoFormSize.Height == minFormHeight))
				return false;
			else 
				return true;
		}
		//기본값은 기본 최소값으로 설정
		private void ResetMemoFormSize()
		{
			//Reset시 기본 최초 size로 설정
			memoFormSize = new Size(minFormWidth, minFormHeight);
		}
		/// <summary>
		/// DataValue는 외부로 노출하지 않고, Method(GetDataValue, SetDataValue(..)를 통해 접근함.
		/// </summary>
		protected virtual string DataValue
		{
			get { return dataValue;}
			set 
			{ 
				if (dataValue != value)
				{
					dataValue = value;
					this.Invalidate();
				}
			}
		}
		/// <summary>
		/// 컨트롤의 값이 변경되었는지 여부를 가져옵니다.
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
		/// 예약글 버튼을 보여줄지 여부를 관리합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		MergableProperty(true),
		Description("예약글 버튼을 보여줄지 여부를 관리합니다.")]
		public bool ShowReservedMemoButton
		{
			get { return showReservedMemoButton; }
			set 
			{  
				if (showReservedMemoButton != value)
				{
					showReservedMemoButton = value;
					if (this.btnReserve != null)
						this.btnReserve.Visible = value;
				}
			}
		}
		/// <summary>
		/// 예약글 컨트롤을 관리하는 파일명을 관리합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(""),
		Description("예약글 컨트롤을 관리하는 파일명을 관리합니다.(실행시 파일위치로 지정하십시오)"),
		Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string ReservedMemoFileName
		{
			get { return reservedMemoFileName; }
			set { reservedMemoFileName = value;}
		}
		/// <summary>
		/// 예약글 컨트롤의 클래스명을 관리합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(""),
		Description("예약글 컨트롤의 클래스명을 관리합니다.(ex:IHIS.시스템ID.ClassName)")]
		public string ReservedMemoClassName
		{
			get { return reservedMemoClassName; }
			set { reservedMemoClassName = value;}
		}
		/// <summary>
		/// 예약글 선택시 기존 메모Text에 예약글을 Append할지 여부를 관리합니다.
		/// </summary>
		[Browsable(true),Category("추가속성"),DefaultValue(false),
		Description("예약글 선택시 기존 메모Text에 예약글을 Append할지 여부를 관리합니다.")]
		public bool AppendReservedMemoText
		{
			get { return this.appendReservedMemoText; }
			set { appendReservedMemoText = value;}
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
		/// 메모창에서 확인버튼을 누를때 Event입니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("메모창에서 확인버튼을 누를때 발생합니다.")]
		public event EventHandler OKButtonClicked;
		/// <summary>
		/// 메모박스를 Click하여 메모창이 뜨기 전에 발생합니다.
		/// </summary>
		[Browsable(true),Category("추가이벤트"),
		Description("메모박스를 Click하여 메모창이 뜨기 전에 발생합니다.(특정조건에 따라 창 띄울지 여부를 결정)")]
		public event CancelEventHandler MemoFormShowing;

        /// <summary>
        /// 예약글 버튼을 누를때 발생하는 Event입니다.
        /// </summary>
        [Browsable(true), Category("추가이벤트"),
        Description("예약글 버튼을 누를때 발생합니다.(예약글 Control에 Parameter 설정)")]
        public event EventHandler ReservedMemoButtonClick;
        #endregion
		
		#region 생성자s
		static XMemoBox()
		{
			//메모 이미지 GET
			memoImage = DrawHelper.MemoImage;
			memoImageList = new ImageList();
			memoImageList.ColorDepth = ColorDepth.Depth8Bit;
			memoImageList.ImageSize = new Size(16, 13);
			Bitmap bmp = (Bitmap)DrawHelper.MemoImages;
			bmp.MakeTransparent(Color.Magenta);
			memoImageList.Images.AddStrip(bmp);
		}
		public XMemoBox()
		{
			//Text Draw시 Format Set
			textFormat.Alignment = StringAlignment.Near;
			textFormat.FormatFlags =StringFormatFlags.NoWrap;
			textFormat.Trimming = StringTrimming.EllipsisCharacter;
			textFormat.LineAlignment = StringAlignment.Center;

			//RunTime시
			if (!this.DesignMode)
			{
				//Control, Form Create
				this.formMemo = new Form();
				this.formMemo.Name = "FormMemo";
				this.formMemo.FormBorderStyle = FormBorderStyle.FixedDialog;
				this.formMemo.ControlBox = false;
				this.formMemo.StartPosition = FormStartPosition.Manual;
				this.formMemo.ShowInTaskbar = false;
				this.formMemo.DockPadding.Bottom = 30;
				this.formMemo.DockPadding.Left = 2;
				this.formMemo.DockPadding.Right = 2;
				this.formMemo.DockPadding.Top = 2;
				this.formMemo.KeyPreview = true;
				this.formMemo.KeyDown += new KeyEventHandler(formMemo_KeyDown);
				this.formMemo.ClientSize = new System.Drawing.Size(minFormWidth, minFormHeight);
				this.formMemo.Activated += new EventHandler(formMemo_Activated);
			
				this.btnOK = new XButton();
				this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
				this.btnOK.Enabled = false;
				this.btnOK.Location = new System.Drawing.Point(10, 153);
				this.btnOK.Name = "btnOK";
                //this.btnOK.Size = new System.Drawing.Size(60, 24);
                this.btnOK.Size = new System.Drawing.Size(80, 24);
				this.btnOK.TabIndex = 1;
				this.btnOK.Text = XMsg.GetField("F011"); //확인(F2)
				this.btnOK.Click += new System.EventHandler(btnOK_Click);

				this.btnClear = new XButton();
				this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                //this.btnClear.Location = new System.Drawing.Point(80, 153);                
                this.btnClear.Location = new System.Drawing.Point(100, 153); 
				this.btnClear.Name = "btnClear";
				this.btnClear.Size = new System.Drawing.Size(60, 24);
				this.btnClear.TabIndex = 2;
				this.btnClear.Text = XMsg.GetField("F012"); //삭제(F8)
				this.btnClear.Click += new System.EventHandler(btnClear_Click);

				this.btnReserve = new XButton();
				this.btnReserve.Visible = false; //최초 Not Visible
				this.btnReserve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
				this.btnReserve.Location = new System.Drawing.Point(150, 153);
				this.btnReserve.Name = "btnReserve";
				this.btnReserve.Scheme = IHIS.Framework.XButtonSchemes.Silver;
				this.btnReserve.Size = new System.Drawing.Size(60, 24);
				this.btnReserve.TabIndex = 3;
				this.btnReserve.Text = XMsg.GetField("F013"); //예약글
				this.btnReserve.Click += new System.EventHandler(btnReserve_Click);

				this.btnCancel = new XButton();
				this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.btnCancel.Location = new System.Drawing.Point(220, 153);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
				this.btnCancel.Size = new System.Drawing.Size(60, 24);
				this.btnCancel.TabIndex = 4;
				this.btnCancel.Text = XMsg.GetField("F001"); //취 소
				this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
			
				this.txtMemo = new XTextBox();
				this.txtMemo.SetByteCheckMode(false); //TextBox Validating시에 Byte단위 문자수 Check하지 않음
				this.txtMemo.ApplyByteLimit = true; //입력문자는 Byte단위로 통제함
				this.txtMemo.AcceptsReturn = true;
				this.txtMemo.AcceptsTab = true;
				this.txtMemo.AutoSize = false;
				this.txtMemo.Dock = System.Windows.Forms.DockStyle.Fill;
				this.txtMemo.Location = new System.Drawing.Point(2, 2);
				this.txtMemo.Multiline = true;
				this.txtMemo.Name = "txtMemo";
				this.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
				this.txtMemo.TabIndex = 0;
				this.txtMemo.TextChanged += new System.EventHandler(txtMemo_TextChanged);

				//Control Add
				this.formMemo.Controls.Add(this.btnOK);
				this.formMemo.Controls.Add(this.btnClear);
				this.formMemo.Controls.Add(this.btnReserve);
				this.formMemo.Controls.Add(this.btnCancel);
				this.formMemo.Controls.Add(this.txtMemo);
				//CancelButton SET
				this.formMemo.CancelButton = this.btnCancel;

				// 2005/05/09 신종석 폰트 수정
				this.Font = new Font("MS UI Gothic", 9.75f);

				//예약글 창 Panel Set
				this.formReservedMemo = new Form();
				this.formReservedMemo.Name = "ReservedMemoForm";
				this.formReservedMemo.FormBorderStyle = FormBorderStyle.FixedDialog;
				this.formReservedMemo.ControlBox = false;
				this.formReservedMemo.StartPosition = FormStartPosition.Manual;
				this.formReservedMemo.ShowInTaskbar = false;
				this.formReservedMemo.DockPadding.Bottom = 30;
				this.formReservedMemo.ClientSize = new System.Drawing.Size(minFormWidth, minFormHeight);
				this.formReservedMemo.BackColor = XColor.XScreenBackColor.Color;

				this.btnOK1 = new XButton();
				this.btnOK1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.btnOK1.Location = new System.Drawing.Point(150, 153);
				this.btnOK1.Name = "btnOK";
				this.btnOK1.Size = new System.Drawing.Size(60, 24);
				this.btnOK1.TabIndex = 0;
				this.btnOK1.Text = XMsg.GetField("F014"); //선 택
				this.btnOK1.Click += new System.EventHandler(btnOK1_Click);

				this.btnCancel1 = new XButton();
				this.btnCancel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.btnCancel1.Location = new System.Drawing.Point(220, 153);
				this.btnCancel1.Name = "btnCancel";
				this.btnCancel1.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
				this.btnCancel1.Size = new System.Drawing.Size(60, 24);
				this.btnCancel1.TabIndex = 1;
				this.btnCancel1.Text = XMsg.GetField("F015"); //닫 기" : "閉じる");
				this.btnCancel1.Click += new System.EventHandler(btnCancel1_Click);
				
				this.pnlReservedMemo = new Panel();
				this.pnlReservedMemo.Name = "pnlReservedMemo";
				this.pnlReservedMemo.Dock = DockStyle.Fill;

				//Panel, Button Add
				this.formReservedMemo.Controls.Add(this.btnOK1);
				this.formReservedMemo.Controls.Add(this.btnCancel1);
				this.formReservedMemo.Controls.Add(this.pnlReservedMemo);
				//CancelButton SET
				this.formReservedMemo.CancelButton = this.btnCancel1;

			}
		}
		#endregion

		#region Event Handler (메모창 관련)
		private void formMemo_Activated(object sender, System.EventArgs e)
		{
			//예약글창 Hide
			this.formReservedMemo.Hide();
		}
		private void formMemo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//F2 Key 입력시 확인처리
			if ((e.KeyCode == Keys.F2) && !e.Shift && !e.Alt && !e.Control)
			{
				if (this.btnOK.Enabled)
				{
					this.btnOK.PerformClick();
					e.Handled = true;
				}
			}
			else if ((e.KeyCode == Keys.F8) && !e.Shift && !e.Alt && !e.Control)  //삭제(F8)
			{
				if (this.btnClear.Enabled)
				{
					this.btnClear.PerformClick();
					e.Handled = true;
				}
			}
		}
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.dataValue != this.txtMemo.GetDataValue())
			{
				this.dataValue = this.txtMemo.GetDataValue().TrimEnd();
				dataChanged = true;
			}
			this.formMemo.Hide();
			this.isPopupedByClick = false;
			//확인버튼 누름 Event Call
			OnOKButtonClicked(EventArgs.Empty);
		}
		private void btnClear_Click(object sender, System.EventArgs e)	
		{
			//TextBox의 Text Reset
			this.txtMemo.Text = "";
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.formMemo.Hide();
			this.isPopupedByClick = false;
		}
		private void btnReserve_Click(object sender, System.EventArgs e)
		{
            //2010.05.12 예약글 버튼 Click Event 발생시킴
            this.OnReservedMemoButtonClick(EventArgs.Empty);

            //이미 생성되어 있으면 위치만 조정후 Show
			if (this.isControlCreated)
			{
				//예약글창 Position 설정
				SetReservedMemoFormPosition(reservedMemoControl);
				//Show
				formReservedMemo.Show();
				return;
			}

			// 기존 Control Remove
			if (this.reservedMemoControl != null)
			{
				this.pnlReservedMemo.Controls.Remove(reservedMemoControl);
				reservedMemoControl.Dispose();	
			}

			reservedMemoControl = CreateReservedMemoControl();
			if (reservedMemoControl == null) return;
			
			//예약글 컨트롤에 Parameter, 버튼 참조 전달
			((IReservedMemoControl) reservedMemoControl).LoadParam = this.loadParam;
			((IReservedMemoControl) reservedMemoControl).OKButton = this.btnOK1;
			((IReservedMemoControl) reservedMemoControl).CancelButton = this.btnCancel1;

			//예약창 Panel에 Control Add
			this.pnlReservedMemo.Controls.Add(reservedMemoControl);

			//예약글창 Position 설정
			SetReservedMemoFormPosition(reservedMemoControl);
			//Flag Set
			this.isControlCreated = true;
			//Show
			formReservedMemo.Show();
		}
		private void txtMemo_TextChanged(object sender, System.EventArgs e)
		{
			//Text 변경시 OK 버튼 Enable
			if (!this.btnOK.Enabled)
				this.btnOK.Enabled = true;
				
		}
		#endregion

		#region Override Methods
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress (e);
			// Enter Key 입력시 TAB Send
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

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			containFocus = false;
			//PopUp에 Focus가 없으면 Hide
			if (!formMemo.ContainsFocus)
			{
				this.formMemo.Hide();
				this.txtMemo.ResetData();
				this.isPopupedByClick = false; //Flag Clear
				//예약글창 Hide
				this.formReservedMemo.Hide();
			}
			Invalidate();
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);
			containFocus = true;
			//메모창 Hide
			this.formMemo.Hide();
			//예약글창 Hide
			this.formReservedMemo.Hide();
			Invalidate();
		}
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (e.KeyCode == this.clickHotKey)
			{
				ToggleMemoForm(this, EventArgs.Empty);
				//Flag Toggle
				this.isPopupedByClick = !this.isPopupedByClick;
			}
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
				case (int)Win32.Msgs.WM_NCHITTEST :
					int x = (int)m.LParam % 0x10000;
					int y = (int)m.LParam / 0x10000;
					Point pos = this.PointToClient(new Point(x, y));
					buttonPressed = false;
					//Object Catch
					if (pos.X >= 0)
						m.Result = (IntPtr) 19;
					//MemoButton Hoverring Draw
					if (pos.X >= (Bounds.Width - memoButtonWidth))
					{
						
						if (!buttonHover)
						{
							buttonHover = true;
							DrawMemoButton(m.HWnd);
						}
					}
					else if (buttonHover)
					{
						buttonHover = false;
						DrawMemoButton(m.HWnd);
					}
					this.DrawMemo(m.HWnd);
					break;
				case (int)Win32.Msgs.WM_PAINT :
					this.DrawMemo(m.HWnd);
					// Paint Message에서도 Button을 칠한다.
					DrawMemoButton(m.HWnd);
					break;
				case (int)Win32.Msgs.WM_NCPAINT :
					this.DrawMemo(m.HWnd);
					DrawMemoButton(m.HWnd);
					m.Result = IntPtr.Zero;
					break;
				case (int)Win32.Msgs.WM_NCLBUTTONUP :
						buttonPressed = false;
						ToggleMemoForm(this, EventArgs.Empty);
						//Flag Toggle
						this.isPopupedByClick = !this.isPopupedByClick;
						DrawMemo(m.HWnd);
						DrawMemoButton(m.HWnd);
					break;
				case (int)Win32.Msgs.WM_NCLBUTTONDOWN :
					if (this.Focus())
					{
						buttonPressed = true;
						DrawMemoButton(m.HWnd);
					}
					break;
				case (int)Win32.Msgs.WM_NCMOUSELEAVE :
					if (buttonHover)
					{
						buttonHover = false;
						DrawMemoButton(m.HWnd);
					}
					break;
				case (int)Win32.Msgs.WM_NCMOUSEMOVE :
					RequestMouseLeaveMessage(m.HWnd);
					break;
			}
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
		/// OKButtonClicked Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected virtual void OnOKButtonClicked(EventArgs e)
		{
			if (OKButtonClicked != null)
				OKButtonClicked(this, e);
		}
		/// <summary>
		/// MemoFormShowing Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> CancelEventArgs </param>
		protected virtual void OnMemoFormShowing(CancelEventArgs e)
		{
			if (MemoFormShowing != null)
				MemoFormShowing(this, e);
		}
        /// <summary>
        /// ReservedMemoButtonClick Event를 발생시킵니다.
        /// </summary>
        /// <param name="e"> EventArgs </param>
        protected virtual void OnReservedMemoButtonClick(EventArgs e)
        {
            if (ReservedMemoButtonClick != null)
                ReservedMemoButtonClick(this, e);
        }
        #endregion

		#region Implemention IDataControl Methods
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
		public virtual void ResetData()
		{
			dataChanged = false;
			this.dataValue = "";
		}
		#endregion

		#region 메모창 팝업 관련
		private void ToggleMemoForm(object sender, EventArgs e)
		{
			if (!this.formMemo.Visible)
			{
				//메모창이 뜨기전 조건에 따른 창을 띄울지 여부를 검사
				CancelEventArgs xe = new CancelEventArgs();
				this.OnMemoFormShowing(xe);
				//창을 띄우지 않음
				if (xe.Cancel) return;

				if (this.isPopupedByClick)
				{
					if (this.dataValue != this.txtMemo.GetDataValue())
					{
						this.dataValue = this.txtMemo.GetDataValue();
						dataChanged = true;
					}
					return;
				}

				SetMemoFormPosition();
				//Font 설정
				this.txtMemo.Font = this.Font;
				this.txtMemo.SetDataValue(this.dataValue);
				//ReadOnly여부에 따라 메모창의 Control Enable 속성 변경
				if (this.readOnly)
				{
					//메모창 ReadOnly는 OK, 삭제,예약글 버튼 비활성화, 메모TextBox ReadOnly
					this.btnOK.Enabled = false;
					this.btnClear.Enabled = false;
					this.btnReserve.Enabled = false;
					this.txtMemo.ReadOnly = true;
					//ReadOnly이면 BackColor가 회색이 되므로 원상태로 복구
					this.txtMemo.BackColor = XColor.XTextBoxBackColor;
					this.formMemo.Show();				
					this.formMemo.BringToFront();
					this.txtMemo.Focus();
					this.txtMemo.SelectionLength = 0;
					this.txtMemo.SelectionStart = this.txtMemo.Text.Length;
				}
				else
				{
					//예약글, 메모TextBox 비활성화 해제
					this.txtMemo.ReadOnly = false;
					//TextBox 최대 문자길이 SET
					this.txtMemo.MaxLength = this.maxTextLength;
					//ImeMode 설정
					this.txtMemo.ImeMode = this.textImeMode;
					this.formMemo.Show();				
					this.formMemo.BringToFront();
					this.txtMemo.Focus();
					this.txtMemo.SelectionLength = 0;
					this.txtMemo.SelectionStart = this.txtMemo.Text.Length;
					this.btnOK.Enabled = false;
					this.btnClear.Enabled = true;
					this.btnReserve.Enabled = true;
				}
				if (this.parentForm == null)
					parentForm = this.FindForm();
				if (parentForm != null)
				{
					User32.SendMessage(parentForm.Handle, 0x0086, 1, 0);  //WM_NCACTIVATE
					//parentForm이 TopMost이면 formMemo도 TopMost 설정
					if (parentForm.TopMost)
						this.formMemo.TopMost = true;
					else
						this.formMemo.TopMost = false;
				}
			}
			else
			{
				if (this.dataValue != this.txtMemo.GetDataValue())
				{
					this.dataValue = this.txtMemo.GetDataValue();
					dataChanged = true;
				}
				this.formMemo.Hide();
			}
		}

		private void SetMemoFormPosition()
		{
			//MemoFormSize.Width가 기본Width이면 MemoBox의 Width를 적용(최소와비교)
			//Height가 기본 Height이면 Width의 2/3로 적용, 있으면 지정한 Height로 적용(최소와 비교)
			if (this.memoFormSize.Width == minFormWidth)
				formMemo.Width = Math.Max(minFormWidth, this.Width);
			else
				formMemo.Width = Math.Max(minFormWidth, memoFormSize.Width);
			
			if (this.memoFormSize.Height == minFormHeight)  //너비의 2/3
				formMemo.Height = Math.Max(minFormHeight, formMemo.Width/3*2);
			else
				formMemo.Height = Math.Max(minFormHeight, memoFormSize.Height);

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
					for (int i = 1 ; i < SystemInformation.MonitorCount; i++)
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
			if (formMemo.Width > rc.Width - pos.X)
			{
				pos.X = Math.Max(rc.Width - formMemo.Width, 0);
			}
			if (formMemo.Height > rc.Height - pos.Y)
			{
				if (formMemo.Height > pos.Y - this.Height)
					pos.Y = Math.Max(rc.Height - formMemo.Height, 0);
				else
					pos.Y -= (formMemo.Height + this.Height);
			}
			formMemo.Location = pos;

			//예약글 버튼 활성화 및 Size 조정
			if (this.showReservedMemoButton)
			{
				this.btnReserve.Visible = true;
				//가운데로 설정 Left 160
//				this.btnReserve.Location  = new Point(160, this.btnReserve.Location.Y);
			}
			else
				this.btnReserve.Visible = false;
		}
		#endregion

		#region MemoBox 그리기
		private void DrawMemo(IntPtr hwnd)
		{
			IntPtr hDC = User32.GetWindowDC(hwnd);
			Graphics g = Graphics.FromHdc(hDC);
			Rectangle rect = new Rectangle(0,0, Bounds.Width - memoButtonWidth -1, Bounds.Height -1);
			g.FillRectangle(new SolidBrush(Color.WhiteSmoke), rect);
			Point imagePos = new Point(rect.Left + (rect.Width - memoImage.Width) / 2 + 1, rect.Top + (rect.Height - memoImage.Height) / 2);
			if (this.dataValue.ToString() != "")
			{
				if (this.displayMemoText)  //Memo에 적힌 Text도 보여주어야 하면
				{
					//Image Left Draw
					imagePos = new Point(2, rect.Top + (rect.Height - memoImage.Height) / 2);
					g.DrawImage(memoImageList.Images[0], imagePos);
					int imgWidth = memoImageList.Images[0].Width;
					//Text Draw
					if (rect.Width - 3 - imgWidth > 0)
					{
						Rectangle textRect = new Rectangle(3 + imgWidth, 1, rect.Width - 3 - imgWidth, rect.Height);
						//New Line이 있으면 첫번째 줄만 Display하고 ...붙임
						string text = this.dataValue.ToString();
						int index = text.IndexOf('\n');
						if (index > 0)
							text = text.Substring(0, index) + "...";
						g.DrawString(text, this.Font, Brushes.Black, textRect, textFormat);						
					}
				}
				else
				{
					//Center에 Image Draw
					g.DrawImage(memoImageList.Images[0], imagePos);
				}
			}
			else
			{
				//Center에 Image Draw
				g.DrawImage(memoImageList.Images[1], imagePos);
			}
			Pen rectPen = null;
			Pen focusPen = null;
			rectPen = new Pen(borderColor);
			g.DrawRectangle(rectPen, rect);
			//Focus시 Dot Rectangle Draw
			if (this.containFocus)
			{
				Rectangle fRect = new Rectangle(2,2, rect.Width -4, rect.Height -4);
				focusPen = new Pen(Color.Gray);
				focusPen.DashStyle = DashStyle.Dot;
				g.DrawRectangle(focusPen, fRect);
				focusPen.Dispose();
			}
			rectPen.Dispose();
			g.Dispose();
			User32.ReleaseDC(hwnd, hDC);
		}
		private void DrawMemoButton(IntPtr hwnd)
		{
			IntPtr hDC = User32.GetWindowDC(hwnd);
			Graphics g = Graphics.FromHdc(hDC);

			Rectangle buttonRect = new Rectangle(Bounds.Width - memoButtonWidth -1, 0, memoButtonWidth , Bounds.Height - 1);
			g.FillRectangle(new SolidBrush(Color.WhiteSmoke), buttonRect);
			Point imagePos = new Point(buttonRect.Left + (buttonRect.Width - memoImage.Width) / 2 + 1, buttonRect.Top + (buttonRect.Height - memoImage.Height) / 2);
			if (buttonHover && !buttonPressed)
				imagePos.Offset(0, -1);
			g.DrawImage(memoImage, imagePos);
			Pen rectPen = null;
			if (buttonPressed)
				rectPen = new Pen(Color.LightSeaGreen);
			else if (buttonHover)
				rectPen = new Pen(Color.Blue);
			else
				rectPen = new Pen(borderColor);

			g.DrawRectangle(rectPen, buttonRect);

			// Button에 Mouse Pointer가 있는 상태
			if (buttonHover)
			{
				g.DrawLine(new Pen(Color.White), buttonRect.Location, new Point(buttonRect.Right, buttonRect.Top));
				g.DrawLine(new Pen(Color.White), buttonRect.Location, new Point(buttonRect.Left, buttonRect.Bottom));
				g.DrawLine(new Pen(Color.DarkGray), new Point(buttonRect.Right - 1, buttonRect.Top + 1), new Point(buttonRect.Right - 1, buttonRect.Bottom - 1));
				g.DrawLine(new Pen(Color.DarkGray), new Point(buttonRect.Left + 1, buttonRect.Bottom - 1), new Point(buttonRect.Right - 1, buttonRect.Bottom - 1));
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

		#region 예약글 창 관련
		private void btnOK1_Click(object sender, System.EventArgs e)
		{
			//예약글창에서 설정된 값을 txtMemo에 설정
			//2006.02.09 AppendReservedMemoText 속성에 따라 Append할지 Replace할지 정함
			if (!this.appendReservedMemoText)
				this.txtMemo.Text = ((IReservedMemoControl)reservedMemoControl).SelectedData;
			else
				this.txtMemo.Text += ((IReservedMemoControl)reservedMemoControl).SelectedData;

			//txtMemo Focus
			this.txtMemo.Focus();
			this.txtMemo.SelectionLength = 0;
			this.txtMemo.SelectionStart = this.txtMemo.Text.Length;

			//Hide
			this.formReservedMemo.Hide();
		}
		private void btnCancel1_Click(object sender, System.EventArgs e)
		{
			//txtMemo Focus
			this.txtMemo.Focus();
			this.txtMemo.SelectionLength = 0;
			this.txtMemo.SelectionStart = this.txtMemo.Text.Length;

			//Hide
			this.formReservedMemo.Hide();
		}
		private Control CreateReservedMemoControl()
		{
			string msg = "";
			//File이 존재하는지 여부 Check
			if (!File.Exists(this.reservedMemoFileName))
			{
				msg = XMsg.GetMsg("M011");//예약글을 띄울 파일이 존재하지 않습니다.
				XMessageBox.Show(msg, "XMemoBox");
				return null;
			}
			//어셈블리명은 Path제외한 파일명에서 .dll 제거
			string asmName = this.reservedMemoFileName;
			asmName = asmName.Substring(asmName.LastIndexOf("\\") + 1).Replace(".dll","");
			//에셈블리가 Loaded 되어 있느지 확인
			Assembly asm = LoadedAssembly(asmName);
			if (asm == null)
			{
				asm = Assembly.LoadFrom(this.reservedMemoFileName);
			}
			if (this.reservedMemoClassName == "")
			{
				msg = XMsg.GetMsg("M012");//예약글 Class명이 지정되지 않았습니다.
				XMessageBox.Show(msg, "XMemoBox");
				return null;
			}
			Type ctlType = asm.GetType(this.reservedMemoClassName);
			if (ctlType == null)
			{
				msg = XMsg.GetMsg("M013");//예약글창을 띄울 컨트롤의 이름이 잘못 지정되었습니다.
				XMessageBox.Show(msg, "XMemoBox");
				return null;
			}
			//Instance 생성
			object obj = null;
			try
			{
				obj = Activator.CreateInstance(ctlType);
			}
			catch
			{
				msg = XMsg.GetMsg("M014");//예약글창을 띄울 컨트롤을 생성하지 못했습니다.
				XMessageBox.Show(msg, "XMemoBox");
				return null;
			}
			//Class가 Control이 아니면 에러 (이후는 Interface로 확인)
			if (!(obj is Control))
			{
				msg = XMsg.GetMsg("M015");//예약글창에 지정한 클래스가 컨트롤이 아닙니다.
				XMessageBox.Show(msg, "XMemoBox");
				return null;
			}
			//obj가 IReservedMemoControl이 아니면 에러
			if (!(obj is IReservedMemoControl))
			{
				msg = XMsg.GetMsg("M015");//예약글창에 지정한 클래스가 컨트롤이 아닙니다.
				XMessageBox.Show(msg, "XMemoBox");
				return null;
			}
			return obj as Control;
		}
		private Assembly LoadedAssembly(string asmName)
		{
			Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();

			foreach (Assembly asm in asms)
			{
				if (asm.GetName().Name.ToLower() == asmName.ToLower())
					return asm;
			}
			return null;
		}
		private void SetReservedMemoFormPosition(Control cont)
		{
			//Form의 Size는 Control의 Size와 동일하게
			this.formReservedMemo.ClientSize = new Size(cont.Width, cont.Height + 30);

			/*Screen이 2개이상일 경우에는 rc의 Width는 두 모니터의 Width를 더한값, Height는
			 *Second화면의 해상도가 같으면 관계없으나, 해상도가 다르면 Second화면의 WorkingArea의 Y는
			 *0부터시작하지않고, Primary의 기준에서 얼만큼 높이에 있는냐로 처리됨.
			 *ex> Primary : 1280*1024 Second 1024*768이면 Primary.WorkingArea(0,0,1280,994) Second.WorkingArea(1280,256,1024,768)
			 *따라서, 높이는 Second의 WorkingArea의 Y + Height로 설정해야함
			 */
			Rectangle rc = Screen.PrimaryScreen.WorkingArea;
			// 위치 조정(Dual Monitor일때 Second화면에 있으면 X값은 Primary화면의Width + Second에서의 위치로 표시됨
			int totalHeight = this.Height;
			Point pos = this.PointToScreen(new Point(0,totalHeight));
			// 2006.03.28 모니터 3개이상도 고려하여 반영
			if (SystemInformation.MonitorCount > 1)
			{
				//pos.X가 Second Monitor 이상에 있으면 rc 변경
				if (pos.X > rc.Width)
				{
					//두번째 Monitor 부터 위치 파악
					for (int i = 1 ; i < SystemInformation.MonitorCount; i++)
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
			if (formReservedMemo.Width > rc.Width - pos.X)
			{
				pos.X = Math.Max(rc.Width - formReservedMemo.Width, 0);
			}
			if (formReservedMemo.Height > rc.Height - pos.Y)
			{
				if (formReservedMemo.Height > pos.Y - totalHeight)
					pos.Y = Math.Max(rc.Height - formReservedMemo.Height, 0);
				else
					pos.Y -= (formReservedMemo.Height + totalHeight);
			}
			formReservedMemo.Location = pos;
		}
		#endregion

		#region SetReservedMemoControlLoadParam(object loadParam)
		/// <summary>
		/// 예약글 컨트롤을 Load할때 전달할 Parameter를 설정합니다.
		/// </summary>
		/// <param name="loadParam"></param>
		public void SetReservedMemoControlLoadParam(object loadParam)
		{
			this.loadParam = loadParam;
		}
		#endregion

	}

	#region XMemoBoxDesigner
	/// <summary>
	/// XMemoBox의 Designer입니다.
	/// </summary>
	internal class XMemoBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
			if (e.Component is XMemoBox)
			{
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					//ShowReservedMemoButton(예약글버튼 Visible여부에 따라 Visible Property변경)
					if (e.Member.Name == "ShowReservedMemoButton")
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
			if (changeFlag && (this.Control != null) && (this.Control is XMemoBox))
			{
				XMemoBox memoBox = (XMemoBox) this.Control;

				//예약글 컨트롤 Not Visible이면 예약글 관련 Property Remove
				if (!memoBox.ShowReservedMemoButton)
				{
					properties.Remove("ReservedMemoClassName");
					properties.Remove("ReservedMemoFileName");
					properties.Remove("AppendReservedMemoText");
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
			// 동적으로 변경할 Property Add (예약글관련 속성)
			if ((this.Control != null) && (this.Control is XMemoBox))
			{
				XMemoBox memoBox = (XMemoBox) this.Control;
				if (!properties.Contains("ReservedMemoClassName"))
					properties.Add("ReservedMemoClassName", memoBox.ReservedMemoClassName);
				if (!properties.Contains("ReservedMemoFileName"))
					properties.Add("ReservedMemoFileName", memoBox.ReservedMemoFileName);
				if (!properties.Contains("AppendReservedMemoText"))
					properties.Add("AppendReservedMemoText", memoBox.AppendReservedMemoText);
			}
		}
	}
	#endregion
}
