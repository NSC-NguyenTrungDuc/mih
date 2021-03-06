using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	#region XEditGridCell
	/// <summary>
	/// XEditGridCell에 대한 요약 설명입니다.
	/// </summary>
	[Serializable,
	DesignTimeVisible(false),
	Designer(typeof(XEditGridCellDesigner))]
	public class XEditGridCell : XGridCell
	{
		#region Fields
		const int minMemoFormWidth = 290;
		const int minMemoFormHeight = 180;
		private ColumnImeMode	imeMode = ColumnImeMode.None;
		private int				cellLen = 10;   // Column Len(string일때 사용)
		private bool			isUpdCol = true   ;   // Update Column 여부
		private bool			isUpdatable = true ;   // Updatable 가능여부 (새로입력시만 수정가능)
		private bool			isNotNull	= false;   // NotNull 컬럼
		private string			initValue = string.Empty;
		private bool			autoInsertAtEnterKey = false; //Grid의 autoInsertAtEnterKey가 true일때 이 컬럼이 EnteryKey일때 자동개행하는 컬럼인지 여부
		//Editor관련 변수
		private XComboItemCollection comboItems = new XComboItemCollection();
		private ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDownList;
		private int maxDropDownItems = 8;
		private string dictColumn = "";
		private string userSQL = "";
		private bool codeDisplay = true;
		private XComboSQLType sqlType = XComboSQLType.DictColumn;

		private XFindWorker findWorker = null;
		private int		dataIndex = 0; // Find후 Return되는 값중 데이타로 설정한 Index
		private Keys	clickHotKey = Keys.F4;  //Click 처리를 할 Hot Key 정의
		private bool  autoTabDataSelected = false; //Find창을 띄운후 데이타선택시 자동으로 TAB 발생시킬지 여부
		private bool	enableEdit = true; //FindBox의 텍스트 편집가능한지 여부

		private bool	minusAccept = false;
		private int		maxinumCipher = 12;

		private string	checkedValue = "Y";
		private string	checkedText = "";
		private string	unCheckedValue = "N";
		private string	unCheckedText = "";
		private ICellEditor cellEditor = null;
		private bool enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부

		//MemoBox Editor 관련
		private Size memoFormSize = new Size(minMemoFormWidth,minMemoFormHeight);
		private bool displayMemoText = false; //메모한 Text를 보여줄지 여부
		private bool showReservedMemoButton = false;  //예약글 버튼을 보여줄지 여부
		private string reservedMemoClassName = "";
		private string reservedMemoFileName  = "";
		private bool appendReservedMemoText = false;  //예약글 선택시 기존 메모Text에 예약글을 Append할지 여부를 관리합니다.

		//ButtonBox Editor관련
		private string	buttonText = "";
		private XButtonSchemes buttonScheme = XButtonSchemes.Blue;
		private Image	buttonImage = null;

		//NumericUpDown Editor 관련 (Increment, Maxinum, Mininum, DecimalPlaces
		private double increment = 1.0; //increment
		private double maxinum = 100.0;  //Maxinum
		private double mininum = 0.0;    //Mininum
		private int decimalPlaces = 0;  //Decimal Digits
	    private ExecuteQueryData executeQuery;

	    public ExecuteQueryData ExecuteQuery
	    {
	        get { return executeQuery; }
	        set { executeQuery = value; }
	    }	    

	    #endregion

		#region 생성자
		/// <summary>
		/// XEditGridCell 생성자
		/// </summary>
		public XEditGridCell()
		{
			//IsReadOnly Default false
			base.IsReadOnly = false;
		}
		#endregion

		#region Properties
		/// <summary>
		/// 컬럼의 ImeMode를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(ColumnImeMode.None),
		Description("컬럼의 ImeMode를 설정합니다.")]
		public ColumnImeMode ImeMode
		{
			get { return imeMode; }
			set { imeMode = value ;}
		}
		/// <summary>
		/// 저장시 포함되는 컬럼 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(true),
		Description("저장시 포함할 컬럼인지 여부를 설정합니다.")]
		public bool IsUpdCol
		{
			get { return isUpdCol ;}
			set { isUpdCol = value ;}
		}
		/// <summary>
		/// 수정가능한지(새행시 입력가능,수정불가) 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(true),
		Description("컬럼을 수정가능한지(새행시 입력가능,수정불가) 여부를 설정합니다.")]
		public bool IsUpdatable
		{
			get { return isUpdatable ;}
			set { isUpdatable = value ;}
		}
		/// <summary>
		/// NotNull 컬럼여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(false),
		Description("NotNull 컬럼인지 여부를 설정합니다.(입력전문에 포함되는 컬럼인 경우 Null Check)")]
		public bool IsNotNull
		{
			get { return isNotNull ;}
			set { isNotNull = value ;}
		}
		/// <summary>
		/// 컬럼의 데이타 길이를 가져오거나 설정합니다.(String형일때 지정한 길이만큼 입력가능)
		/// </summary>
		[Category("컬럼정보"),
		Description("컬럼의 데이타 길이를 설정합니다.(String형일때 지정한 길이만큼 입력가능)")]
		public int CellLen
		{
			get { return cellLen ;}
			set { cellLen = value ;}
		}
		private bool ShouldSerializeCellLen()
		{
			// String, StringFix5, Number, Decimal만 CellLen Serialize
			if ((this.CellType == XCellDataType.String) ||
				(this.CellType == XCellDataType.Number) || (this.CellType == XCellDataType.Decimal))
				return (cellLen != 10);
			else
				return false;
		}
		private void ResetCellLen()
		{
			// String, Number, Decimal만 CellLen 10 Default 그외는 해당 고정길이
			CellLen = 10;
		}
		/// <summary>
		/// 초기값을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(""),
		Description("컬럼의 초기값을 설정합니다.")]
		public string InitValue
		{
			get { return initValue;}
			set 
			{ 
				// 초기값 Validation Check
				if (value != "")
				{
					switch (CellType)
					{
						case XCellDataType.Date:
						case XCellDataType.DateTime:
							if ((value.ToUpper() != "TODAY") && !TypeCheck.IsDateTime(value))
								throw(new Exception("초기값이 잘못 지정되었습니다.(Today,1900/01/01,1900-01-01형식만 가능)"));
							break;
						case XCellDataType.Time:
							if ((value.ToUpper() != "NOW") && !TypeCheck.IsTime(value))
								throw(new Exception("초기값이 잘못 지정되었습니다.(Now,11:11:11, 11:11 형식만 가능)"));
							break;
						case XCellDataType.Decimal:
						case XCellDataType.Number:
							if (!TypeCheck.IsDouble(value))
								throw(new Exception("초기값이 잘못 지정되었습니다.(숫자만 가능)"));
							break;

					}
				}
				initValue = value;
			}
		}
		[Category("컬럼정보"),
		DefaultValue(false),
		Description("컬럼의 초기값을 설정합니다.")]
		public bool AutoInsertAtEnterKey
		{
			get { return autoInsertAtEnterKey;}
			set { autoInsertAtEnterKey = value;}
		}
		/// <summary>
		/// Number,Decimal형에서 -를 입력가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(false),
		MergableProperty(true),
		Description("Number Type에서 -를 입력가능한지를 설정합니다.")]
		public bool	MinusAccept
		{
			get { return minusAccept;}
			set { minusAccept = value;}
		}
		/// <summary>
		/// Number,Decimal형에서 자리수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(12),
		MergableProperty(true),
		Description("Number Type에서 숫자 자리수를 설정합니다.(1~12)")]
		public int MaxinumCipher
		{
			get { return maxinumCipher;}
			set { maxinumCipher = ((value > 12) ? 12 : ((value <= 0) ? 12 : value));}
		}
		/// <summary>
		/// ComboBox형 Editor의 Combo Data를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Description("ComboBox,ListBox형 Editor의 Combo(List) Data를 설정합니다.")]
		public XComboItemCollection ComboItems
		{
			get { return comboItems;}
			set { comboItems = value;}
		}
		[Browsable(true), Category("에디터정보"),
		MergableProperty(true),
		DefaultValue(ComboBoxStyle.DropDownList),
		Description("ComboBox형 Editor의 DropDownStyle을 설정합니다.")]
		public ComboBoxStyle DropDownStyle
		{
			get { return dropDownStyle;}
			set { dropDownStyle = value;}
		}
		[Browsable(true), Category("에디터정보"),
		MergableProperty(true),
		DefaultValue(8),
		Description("ComboBox형 Editor의 MaxDropDownItems을 설정합니다.")]
		public int MaxDropDownItems
		{
			get { return maxDropDownItems;}
			set { maxDropDownItems = Math.Max(8,value);}
		}
		/// <summary>
		/// ComboBox형 Editor의 자료사전과 사용자SQL 사용구분을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DefaultValue(XComboSQLType.DictColumn),
		Description("ComboBox,ListBox형 Editor의 자료사전과 사용자SQL 사용구분을 설정합니다.")]
		public XComboSQLType SQLType
		{
			get { return sqlType; }
			set { sqlType = value; }
		}
		/// <summary>
		/// ComboBox형 Editor의 자료사전명을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),DefaultValue(""),
		Description("ComboBox,ListBox형 Editor의 자료사전명을 설정합니다.")]
		public string DictColumn
		{
			get { return dictColumn;}
			set { dictColumn = value;}
		}
		/// <summary>
		/// ComboBox형 Editor에서 자료사전사용시 Code값을 Display할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DefaultValue(true),
		Description("ComboBox,ListBox형 Editor에서 자료사전사용시 Code값을 Display할지 여부를 설정합니다.")]
		public bool CodeDisplay
		{
			get { return codeDisplay; }
			set { codeDisplay = value; }
		}
		/// <summary>
		/// ComboBox형 Editor의 사용자 정의 SQL을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		DefaultValue(""),
		Editor(typeof(TextEditor), typeof(UITypeEditor)),
		Description("ComboBox,ListBox형 Editor의 사용자 정의 SQL을 설정합니다.")]
		public string UserSQL
		{
			get { return userSQL; }
			set { userSQL = value;}
		}
		/// <summary>
		/// FindBox형 Editor의 FindParam을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DefaultValue(null),
		Description("FindBox형 Editor의 FindWorker을 설정합니다.")]
		public XFindWorker FindWorker
		{
			get { return findWorker;}
			set { findWorker = value;}
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(0),
		MergableProperty(true),
		Description("Find후 Return값들중 컨트롤의 값으로 사용할 값의 Index입니다.")]
		public int	DataIndex
		{
			get { return dataIndex; }
			set { dataIndex = Math.Max(0, value); }
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(Keys.F4),
		MergableProperty(true),
		Description("Click을 발생시킬 Hot Key를 지정합니다.")]
		public Keys ClickHotKey
		{
			get { return clickHotKey;}
			set { clickHotKey = value;}
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(false),
		Description("Find창에서 데이타 선택시 자동으로 TAB을 발생시킬지 여부를 지정합니다.")]
		public bool AutoTabDataSelected
		{
			get { return autoTabDataSelected;}
			set { autoTabDataSelected = value;}
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(true),
		Description("FindBox에서 텍스트 편집이 가능한지 여부를 지정합니다.")]
		public bool EnableEdit
		{
			get { return enableEdit;}
			set { enableEdit = value;}
		}
		/// <summary>
		/// CheckBox형 Editor의 체크된 상태의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DefaultValue("Y"),
		Description("CheckBox형 Editor의 체크된 상태의 값을 지정합니다.")]
		public string CheckedValue
		{
			get	{return checkedValue;}
			set	
			{
				//CheckedValue 반드시 입력
				if ((EditorStyle == XCellEditorStyle.CheckBox) && (value.Trim() == ""))
					throw(new Exception("CheckedValue를 입력하십시오."));

				checkedValue = value;
			}
		}
		/// <summary>
		/// CheckBox형 Editor의 체크되지 않은 상태의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DefaultValue("N"),
		Description("CheckBox형 Editor의 체크되지 않은 상태의 값을 지정합니다.")]
		public string UnCheckedValue
		{
			get	{return unCheckedValue;}
			set	
			{
				//CheckedValue 반드시 입력
				if ((EditorStyle == XCellEditorStyle.CheckBox) && (value.Trim() == ""))
					throw(new Exception("UnCheckedValue를 입력하십시오."));

				unCheckedValue = value;
			}
		}
		/// <summary>
		/// CheckBox형 Editor의 체크된 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DefaultValue(""),
		Description("CheckBox형 Editor의 체크된 상태에서 보여줄 문자를 지정합니다.")]
		public string CheckedText
		{
			get	{return checkedText;}
			set { checkedText = value;}
		}
		/// <summary>
		/// CheckBox형 Editor의 체크되지 않은 상태에서 보여줄 문자를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		DefaultValue(""),
		Description("CheckBox형 Editor의 체크되지 않은 상태에서 보여줄 문자를 지정합니다.")]
		public string UnCheckedText
		{
			get	{return unCheckedText;}
			set { unCheckedText = value;}
		}
		/// <summary>
		/// Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(true),
		MergableProperty(true),
		Description("Enter Key를 입력시 TAB Key를 발생시킬지 여부를 설정합니다.")]
		public bool EnterKeyToTab
		{
			get { return enterKeyToTab; }
			set { enterKeyToTab = value;}
		}
		/// <summary>
		/// Memo Form의 Size를 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),
		MergableProperty(true),
		Description("MemoEditor의 Form의 Size를 설정합니다.")]
		public Size MemoFormSize
		{
			get { return memoFormSize; }
			set 
			{ 
				if (memoFormSize != value)
				{
					//최초영역이상 Check
					memoFormSize.Width = Math.Max(value.Width, minMemoFormWidth);
					memoFormSize.Height = Math.Max(value.Height, minMemoFormHeight);
				}
			}
		}
		// Size가 기본 최소값이면 Serialize 하지 않음
		private bool ShouldSerializeMemoFormSize()
		{
			if ((memoFormSize.Width == minMemoFormWidth) && (memoFormSize.Height == minMemoFormHeight))
				return false;
			else 
				return true;
		}
		//기본값은 기본 최소값으로 설정
		private void ResetMemoFormSize()
		{
			//Reset시 기본 최초 size로 설정
			memoFormSize = new Size(minMemoFormWidth, minMemoFormHeight);
		}
		/// <summary>
		/// 메모가 입력된 경우 메모 Text를 보여줄지 여부를 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(false),
		MergableProperty(true),
		Description("메모가 입력된 경우 메모 Text를 보여줄지 여부를 관리합니다.")]
		public bool DisplayMemoText
		{
			get { return displayMemoText; }
			set { displayMemoText = value;}
		}
		/// <summary>
		/// 예약글 버튼을 보여줄지 여부를 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(false),
		MergableProperty(true),
		Description("예약글 버튼을 보여줄지 여부를 관리합니다.")]
		public bool ShowReservedMemoButton
		{
			get { return showReservedMemoButton; }
			set { showReservedMemoButton = value;}
		}
		/// <summary>
		/// 예약글 컨트롤을 관리하는 파일명을 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(""),
		Description("예약글 컨트롤을 관리하는 파일명을 관리합니다.(실행시 파일위치로 지정하십시오.)"),
		Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string ReservedMemoFileName
		{
			get { return reservedMemoFileName; }
			set { reservedMemoFileName = value;}
		}
		/// <summary>
		/// 예약글 컨트롤의 클래스명을 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(""),
		Description("예약글 컨트롤의 클래스명을 관리합니다.(ex:IHIS.시스템ID.ClassName)")]
		public string ReservedMemoClassName
		{
			get { return reservedMemoClassName; }
			set { reservedMemoClassName = value;}
		}
		/// <summary>
		/// 예약글 선택시 기존 메모Text에 예약글을 Append할지 여부를 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(false),
		Description("예약글 선택시 기존 메모Text에 예약글을 Append할지 여부를 관리합니다.")]
		public bool AppendReservedMemoText
		{
			get { return this.appendReservedMemoText; }
			set { appendReservedMemoText = value;}
		}
		/// <summary>
		/// 버튼의 Text를 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(""),
		Description("버튼의 Text를 관리합니다.")]
		public string ButtonText
		{
			get { return buttonText; }
			set { buttonText = value;}
		}
		/// <summary>
		/// 버튼의 Sheme를 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(XButtonSchemes.Blue),
		Description("버튼의 Sheme을 관리합니다.")]
		public XButtonSchemes ButtonScheme
		{
			get { return buttonScheme; }
			set { buttonScheme = value;}
		}
		/// <summary>
		/// 버튼의 Image를 관리합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(null),
		Description("버튼의 Image를 관리합니다.")]
		public Image ButtonImage
		{
			get { return this.buttonImage; }
			set { this.buttonImage = value;}
		}
		/// <summary>
		/// DatePicker를 일본연호로 표기할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue(false),
		Description("일본연호로 표기할지 여부를 지정합니다.")]
		public override bool IsJapanYearType
		{
			get { return base.IsJapanYearType; }
			set { base.IsJapanYearType = value;}
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(1.0),
		Description("NumericUpDown Editor의 Increment를 지정합니다.")]
		public double Increment
		{
			get { return this.increment; }
			set { this.increment = value; }
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(100.0),
		Description("NumericUpDown Editor의 Maxinum 값을 지정합니다.")]
		public double Maxinum
		{
			get { return this.maxinum; }
			set 
			{
				if (this.maxinum != value)
				{
					this.maxinum = value; 
					//Mininum 값 다시 설정
					this.mininum = Math.Min(this.mininum, this.maxinum);
				}
			}
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(0.0),
		Description("NumericUpDown Editor의 Mininum 값을 지정합니다.")]
		public double Mininum
		{
			get { return this.mininum; }
			set 
			{
				if (this.mininum != value)
				{
					this.mininum = value;
					//Maxinum 값 다시 설정
					this.maxinum = Math.Max(this.mininum, this.maxinum);
				}
			}
		}
		[Browsable(true), Category("에디터정보"), DefaultValue(0),
		Description("NumericUpDown Editor의 DecimalPlaces 값을 지정합니다.")]
		public int DecimalPlaces
		{
			get { return this.decimalPlaces; }
			set 
			{ 
				//0이상 값만 허용함.
				this.decimalPlaces = Math.Max(0,value); 
			}
		}
		/// <summary>
		/// 컬럼의 Editor를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(null),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ICellEditor CellEditor
		{
			get { return cellEditor;}
			set { cellEditor = value;}
		}
		#endregion

		#region base Properties
		/// <summary>
		/// 컬럼의 Data형식(XCellDataType)을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(XCellDataType.String),
		Description("컬럼의 Data형식(XCellDataType)을 설정합니다.")]
		public new XCellDataType CellType
		{
			get { return base.CellType;}
			set
			{
				//String,StringFix5, Date Type이 아니면 EditorStyle은 모두 EditBox로 SET
				if ((value != XCellDataType.String) && (value != XCellDataType.Date))
					this.EditorStyle = XCellEditorStyle.EditBox;
				//2006.07.17 EditorStyle이 UpDownBox일때 value가 Number, Decimal이 아니면 EditBox형으로 변경
				if ((this.EditorStyle == XCellEditorStyle.UpDownBox)
					&&((value != XCellDataType.Number) && (value != XCellDataType.Decimal)))
					this.EditorStyle = XCellEditorStyle.EditBox;
				//Binary는 ReadOnly로 설정
				if (value == XCellDataType.Binary)
					this.IsReadOnly = true;

				base.CellType = value;
			}
		}
		/// <summary>
		/// 컬럼의 Editor 형식(XCellEditorStyle)을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		Category("에디터정보"),
		DefaultValue(XCellEditorStyle.EditBox),
		Description("컬럼의 Editor 형식을 설정합니다.")]
		public new XCellEditorStyle EditorStyle
		{
			get { return base.EditorStyle;}
			set 
			{ 
				//XCellEditorStyle과 CellType비교 Validation Check
				//Combo,FindBox, CheckBox, MemoBox Style은 String Type만 가능합니다.
				switch (value)
				{
					case XCellEditorStyle.CheckBox:
					case XCellEditorStyle.ComboBox:
					case XCellEditorStyle.FindBox:
					case XCellEditorStyle.ListBox:
					case XCellEditorStyle.MemoBox:
						if (CellType != XCellDataType.String)
							throw(new Exception("Combo,FindBox, CheckBox Style은 String Type만 가능합니다."));
						break;
					case XCellEditorStyle.UpDownBox:  //2006.07.17 Number, Decimal 만 가능
						if ((CellType != XCellDataType.Number) && (CellType != XCellDataType.Decimal))
							throw (new Exception("UpDownBox Style은 Number, Decimal Type만 가능합니다."));
						break;
//					case XCellEditorStyle.DatePicker:  //Date형만 가능
//						if (CellType != XCellDataType.Date)
//							throw(new Exception("DatePicker Style은 Date Type만 가능합니다."));
//						break;
				}
				base.EditorStyle = value;
			}
		}
		/// <summary>
		/// 컬럼의 Visible여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		MergableProperty(false),
		DefaultValue(true),
		Description("컬럼의 Visible여부를 설정합니다.")]
		public new bool IsVisible
		{
			get { return base.IsVisible;}
			set 
			{ 
				//NotVisible이면 EditorStyle EditBox로 SET
				if (!value)
					this.EditorStyle = XCellEditorStyle.EditBox;

				base.IsVisible = value;
			}
		}
		/// <summary>
		/// ReadOnly여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		Category("컬럼정보"),
		DefaultValue(false),
		Description("ReadOnly 컬럼인지 여부를 설정합니다.")]
		public override bool IsReadOnly
		{
			get { return base.IsReadOnly ;}
			set { base.IsReadOnly = value;}
		}
		/// <summary>
		/// String형 컬럼에서 PasswordChar를 설정합니다.
		/// </summary>
		[Browsable(true),Category("에디터정보"),DefaultValue((char) 0),
		MergableProperty(true),
		Description("String형 컬럼의 PasswordChar를 설정합니다.")]
		public new char PasswordChar
		{
			get { return base.PasswordChar; }
			set { base.PasswordChar = value;}
		}
		#endregion
	}
	#endregion

	#region XEditGridCell Type Converter
	/// <summary>
	/// XEditGridCell TypeConverter
	/// </summary>
	public class XEditGridCellTypeConverter : TypeConverter
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
			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is XEditGridCell)
				{
					XEditGridCell cellInfo = (XEditGridCell)value;
					InstanceDescriptor id = new InstanceDescriptor(cellInfo.GetType().GetConstructor(Type.EmptyTypes), null, false);
					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region XEditGridCellDesigner
	/// <summary>
	/// IcmEditMask의 Designer입니다.
	/// </summary>
	internal class XEditGridCellDesigner : System.ComponentModel.Design.ComponentDesigner
	{
		private XEditGridCell cellInfo = null;
		private bool changeFlag = false;
		private ISelectionService iSvc;
		private IComponentChangeService iComp;
		private IDesignerHost iHost;

		/// <summary>
		/// 디자이너가 관리하는 구성 요소와 관련된 구성 요소 컬렉션을 가져옵니다.
		/// </summary>
		public override ICollection AssociatedComponents
		{
			get 
			{ 
				//복사, 끌기 또는 이동 작업 중에 디자이너가 관리하는 구성 요소와 함께 복사 또는 이동할 구성 요소를 지정
				// XEditGridCell의 ComboItems가 관련 Component임
				return cellInfo.ComboItems;
			}
		}

		/// <summary>
		/// Designer를 초기화 합니다.
		/// </summary>
		/// <param name="component"> Designer를 가진 IComponent 개체 </param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);

			// Design하고있는 Component 등록
			cellInfo = (XEditGridCell) component;
			// Hook up events
			iSvc = (ISelectionService) GetService(typeof(ISelectionService));
			iComp = (IComponentChangeService) GetService(typeof(IComponentChangeService));
			iHost = (IDesignerHost) GetService(typeof(IDesignerHost));
			iSvc.SelectionChanged += new EventHandler(OnSelectionChanged);
			iComp.ComponentChanged += new ComponentChangedEventHandler(OnComponentChanged);
		}
		private void OnSelectionChanged(object sender, System.EventArgs e)
		{
			if (!changeFlag)
			{
				//Selected된 상태이면 속성 동적으로 변경
				if (iSvc.GetComponentSelected(this.Component))
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
			if (e.Component is XEditGridCell)
			{
				XEditGridCell info = (XEditGridCell) e.Component;

				//ComboStyle, ListBox Style 이 아닐경우 info.ComboItems가 있으면 XComboItem Component 삭제처리함
				if ((info.EditorStyle != XCellEditorStyle.ComboBox) && (info.EditorStyle != XCellEditorStyle.ListBox))
				{
					if (info.ComboItems.Count > 0)
					{
						//ComboItems Clear, xComboItem Component Destroy
						XComboItem item = null;
						for (int idx = info.ComboItems.Count - 1; idx >= 0; idx--)
						{
							item = info.ComboItems[idx];
							info.ComboItems.Remove(idx);
							iHost.DestroyComponent(item);
						}
					}

				}
						

				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					if ((e.Member.Name == "EditorStyle")||(e.Member.Name == "CellType"))
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
			// Unhook events
			iSvc.SelectionChanged -= new EventHandler(OnSelectionChanged);
			iComp.ComponentChanged -= new ComponentChangedEventHandler(OnComponentChanged);
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
			if (changeFlag && (this.Component != null) && (this.Component is XEditGridCell))
			{
				XEditGridCell info = (XEditGridCell) this.Component;
				switch (info.EditorStyle)
				{
					case XCellEditorStyle.CheckBox:
						//CheckBox와 관련된 Property만 보여줌
						properties.Remove("ComboItems");
						properties.Remove("DropDownStyle");
						properties.Remove("MaxDropDownItems");
						properties.Remove("DictColumn");
						properties.Remove("CodeDisplay");
						properties.Remove("SQLType");
						properties.Remove("UserSQL");
						properties.Remove("FindWorker");
						properties.Remove("DataIndex");
						properties.Remove("ClickHotKey");
						properties.Remove("AutoTabDataSelected");
						properties.Remove("EnableEdit");
						properties.Remove("MemoFormSize");
						properties.Remove("DisplayMemoText");
						properties.Remove("ShowReservedMemoButton");
						properties.Remove("ReservedMemoFileName");
						properties.Remove("ReservedMemoClassName");
						properties.Remove("AppendReservedMemoText");
						properties.Remove("ButtonText");
						properties.Remove("ButtonScheme");
						properties.Remove("ButtonImage");
						//Mask관련 속성 Remove
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("PasswordChar");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
						//DatePicker 속성 Remove
						properties.Remove("IsJapanYearType");
						//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
						properties.Remove("InvalidDateIsStringEmpty");
						//NumericUpDown 관련
						properties.Remove("Increment");
						properties.Remove("Maxinum");
						properties.Remove("Mininum");
						properties.Remove("DecimalPlaces");
						break;
					case XCellEditorStyle.ComboBox:
					case XCellEditorStyle.ListBox:
						//Combo관련
						properties.Remove("FindWorker");
						properties.Remove("DataIndex");
						properties.Remove("ClickHotKey");
						properties.Remove("AutoTabDataSelected");
						properties.Remove("EnableEdit");
						properties.Remove("CheckedText");
						properties.Remove("CheckedValue");
						properties.Remove("UnCheckedText");
						properties.Remove("UnCheckedValue");
						properties.Remove("MemoFormSize");
						properties.Remove("DisplayMemoText");
						properties.Remove("ShowReservedMemoButton");
						properties.Remove("ReservedMemoFileName");
						properties.Remove("ReservedMemoClassName");
						properties.Remove("AppendReservedMemoText");
						properties.Remove("ButtonText");
						properties.Remove("ButtonScheme");
						properties.Remove("ButtonImage");
						//Mask관련 속성 Remove
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("PasswordChar");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
						//DatePicker 속성 Remove
						properties.Remove("IsJapanYearType");
						//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
						properties.Remove("InvalidDateIsStringEmpty");

						//ListBox는 DropDownStyle, MaxDropDownItems도 Remove
						if (info.EditorStyle == XCellEditorStyle.ListBox)
						{
							properties.Remove("DropDownStyle");
							properties.Remove("MaxDropDownItems");
						}
						//NumericUpDown 관련
						properties.Remove("Increment");
						properties.Remove("Maxinum");
						properties.Remove("Mininum");
						properties.Remove("DecimalPlaces");
						break;
					case XCellEditorStyle.FindBox:
						//Find관련
						properties.Remove("ComboItems");
						properties.Remove("DropDownStyle");
						properties.Remove("MaxDropDownItems");
						properties.Remove("DictColumn");
						properties.Remove("CodeDisplay");
						properties.Remove("SQLType");
						properties.Remove("UserSQL");
						properties.Remove("CheckedText");
						properties.Remove("CheckedValue");
						properties.Remove("UnCheckedText");
						properties.Remove("UnCheckedValue");
						properties.Remove("MemoFormSize");
						properties.Remove("DisplayMemoText");
						properties.Remove("ShowReservedMemoButton");
						properties.Remove("ReservedMemoFileName");
						properties.Remove("ReservedMemoClassName");
						properties.Remove("AppendReservedMemoText");
						properties.Remove("ButtonText");
						properties.Remove("ButtonScheme");
						properties.Remove("ButtonImage");
						//Mask관련 속성 Remove
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("PasswordChar");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
						//DatePicker 속성 Remove
						properties.Remove("IsJapanYearType");
						//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
						properties.Remove("InvalidDateIsStringEmpty");
						//NumericUpDown 관련
						properties.Remove("Increment");
						properties.Remove("Maxinum");
						properties.Remove("Mininum");
						properties.Remove("DecimalPlaces");
						break;
					case XCellEditorStyle.MemoBox:
						//Memo관련
						properties.Remove("ComboItems");
						properties.Remove("DropDownStyle");
						properties.Remove("MaxDropDownItems");
						properties.Remove("DictColumn");
						properties.Remove("CodeDisplay");
						properties.Remove("SQLType");
						properties.Remove("UserSQL");
						properties.Remove("FindWorker");
						properties.Remove("DataIndex");
						properties.Remove("AutoTabDataSelected");
						properties.Remove("EnableEdit");
						properties.Remove("CheckedText");
						properties.Remove("CheckedValue");
						properties.Remove("UnCheckedText");
						properties.Remove("UnCheckedValue");
						properties.Remove("ButtonText");
						properties.Remove("ButtonScheme");
						properties.Remove("ButtonImage");
						//Mask관련 속성 Remove
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("PasswordChar");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
						//DatePicker 속성 Remove
						properties.Remove("IsJapanYearType");
						//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
						properties.Remove("InvalidDateIsStringEmpty");
						//NumericUpDown 관련
						properties.Remove("Increment");
						properties.Remove("Maxinum");
						properties.Remove("Mininum");
						properties.Remove("DecimalPlaces");
						break;
					case XCellEditorStyle.ButtonBox:
						properties.Remove("FindWorker");
						properties.Remove("DataIndex");
						properties.Remove("ClickHotKey");
						properties.Remove("AutoTabDataSelected");
						properties.Remove("EnableEdit");
						properties.Remove("ComboItems");
						properties.Remove("DropDownStyle");
						properties.Remove("MaxDropDownItems");
						properties.Remove("DictColumn");
						properties.Remove("CodeDisplay");
						properties.Remove("SQLType");
						properties.Remove("UserSQL");
						properties.Remove("CheckedText");
						properties.Remove("CheckedValue");
						properties.Remove("UnCheckedText");
						properties.Remove("UnCheckedValue");
						properties.Remove("MemoFormSize");
						properties.Remove("DisplayMemoText");
						properties.Remove("ShowReservedMemoButton");
						properties.Remove("ReservedMemoFileName");
						properties.Remove("ReservedMemoClassName");
						properties.Remove("AppendReservedMemoText");
						//Mask관련 속성 Remove
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("PasswordChar");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
						//DatePicker 속성 Remove
						properties.Remove("IsJapanYearType");
						//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
						properties.Remove("InvalidDateIsStringEmpty");
						//NumericUpDown 관련
						properties.Remove("Increment");
						properties.Remove("Maxinum");
						properties.Remove("Mininum");
						properties.Remove("DecimalPlaces");
						break;
					case XCellEditorStyle.DatePicker:
						//DatePicker관련 (ClickHotKey)
						properties.Remove("FindWorker");
						properties.Remove("DataIndex");
						properties.Remove("AutoTabDataSelected");
						properties.Remove("EnableEdit");
						properties.Remove("ComboItems");
						properties.Remove("DropDownStyle");
						properties.Remove("MaxDropDownItems");
						properties.Remove("DictColumn");
						properties.Remove("CodeDisplay");
						properties.Remove("SQLType");
						properties.Remove("UserSQL");
						properties.Remove("CheckedText");
						properties.Remove("CheckedValue");
						properties.Remove("UnCheckedText");
						properties.Remove("UnCheckedValue");
						properties.Remove("MemoFormSize");
						properties.Remove("DisplayMemoText");
						properties.Remove("ShowReservedMemoButton");
						properties.Remove("ReservedMemoFileName");
						properties.Remove("ReservedMemoClassName");
						properties.Remove("AppendReservedMemoText");
						properties.Remove("ButtonText");
						properties.Remove("ButtonScheme");
						properties.Remove("ButtonImage");
						//Mask관련 속성 Remove
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("PasswordChar");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
						//NumericUpDown 관련
						properties.Remove("Increment");
						properties.Remove("Maxinum");
						properties.Remove("Mininum");
						properties.Remove("DecimalPlaces");
						break;
					case XCellEditorStyle.UpDownBox:
						//UpDownBox와 관련된 Property만 보여줌
						properties.Remove("CheckedText");
						properties.Remove("CheckedValue");
						properties.Remove("UnCheckedText");
						properties.Remove("UnCheckedValue");
						properties.Remove("ComboItems");
						properties.Remove("DropDownStyle");
						properties.Remove("MaxDropDownItems");
						properties.Remove("DictColumn");
						properties.Remove("CodeDisplay");
						properties.Remove("SQLType");
						properties.Remove("UserSQL");
						properties.Remove("FindWorker");
						properties.Remove("DataIndex");
						properties.Remove("ClickHotKey");
						properties.Remove("AutoTabDataSelected");
						properties.Remove("EnableEdit");
						properties.Remove("MemoFormSize");
						properties.Remove("DisplayMemoText");
						properties.Remove("ShowReservedMemoButton");
						properties.Remove("ReservedMemoFileName");
						properties.Remove("ReservedMemoClassName");
						properties.Remove("AppendReservedMemoText");
						properties.Remove("ButtonText");
						properties.Remove("ButtonScheme");
						properties.Remove("ButtonImage");
						//Mask관련 속성 Remove
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("MinusAccept");
						properties.Remove("MaxinumCipher");
						properties.Remove("PasswordChar");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
						//DatePicker 속성 Remove
						properties.Remove("IsJapanYearType");
						//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
						properties.Remove("InvalidDateIsStringEmpty");
						break;
					case XCellEditorStyle.EditBox:
						//EditBox관련
						properties.Remove("ComboItems");
						properties.Remove("DropDownStyle");
						properties.Remove("MaxDropDownItems");
						properties.Remove("DictColumn");
						properties.Remove("CodeDisplay");
						properties.Remove("SQLType");
						properties.Remove("UserSQL");
						properties.Remove("FindWorker");
						properties.Remove("DataIndex");
						properties.Remove("ClickHotKey");
						properties.Remove("AutoTabDataSelected");
						properties.Remove("EnableEdit");
						properties.Remove("CheckedText");
						properties.Remove("CheckedValue");
						properties.Remove("UnCheckedText");
						properties.Remove("UnCheckedValue");
						properties.Remove("MemoFormSize");
						properties.Remove("DisplayMemoText");
						properties.Remove("ShowReservedMemoButton");
						properties.Remove("ReservedMemoFileName");
						properties.Remove("ReservedMemoClassName");
						properties.Remove("AppendReservedMemoText");
						properties.Remove("ButtonText");
						properties.Remove("ButtonScheme");
						properties.Remove("ButtonImage");
						
					switch (info.CellType)
					{
						case XCellDataType.String:
							// Number관련 속성 Remove
							properties.Remove("DecimalDigits");
							properties.Remove("MinusAccept");
							properties.Remove("MaxinumCipher");
							properties.Remove("GeneralNumberFormat");
							properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
							//Date, Month형 속성
							properties.Remove("IsJapanYearType");
							//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
							properties.Remove("InvalidDateIsStringEmpty");
							break;
						
						case XCellDataType.Date:
						case XCellDataType.Month:
							// Number관련,EditoStyle 속성 Remove
							properties.Remove("EditorStyle");
							properties.Remove("DecimalDigits");
							properties.Remove("MinusAccept");
							properties.Remove("MaxinumCipher");
							properties.Remove("PasswordChar");
							properties.Remove("GeneralNumberFormat");
							properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
							break;
						case XCellDataType.DateTime:
						case XCellDataType.Time:
						
							// Number관련,EditoStyle 속성 Remove
							properties.Remove("EditorStyle");
							properties.Remove("DecimalDigits");
							properties.Remove("MinusAccept");
							properties.Remove("MaxinumCipher");
							properties.Remove("PasswordChar");
							properties.Remove("GeneralNumberFormat");
							properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
							//Date, Month형 속성
							properties.Remove("IsJapanYearType");
							break;
						case XCellDataType.Number:
							// EditoStyle, Mask, DecimalDigits Remove
							properties.Remove("EditorStyle");
							properties.Remove("DecimalDigits");
							properties.Remove("Mask");
							properties.Remove("PasswordChar");
							properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
							//Date, Month형 속성
							properties.Remove("IsJapanYearType");
							//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
							properties.Remove("InvalidDateIsStringEmpty");
							break;
						case XCellDataType.Decimal:
							//EditorMask Remove
							properties.Remove("EditorStyle");
							properties.Remove("Mask");
							properties.Remove("PasswordChar");
							//Date, Month형 속성
							properties.Remove("IsJapanYearType");
							//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
							properties.Remove("InvalidDateIsStringEmpty");
							break;
						case XCellDataType.Binary:
							properties.Remove("EditorStyle");
							properties.Remove("Mask");
							properties.Remove("DecimalDigits");
							properties.Remove("MinusAccept");
							properties.Remove("MaxinumCipher");
							properties.Remove("PasswordChar");
							properties.Remove("GeneralNumberFormat");
							properties.Remove("ShowZeroDecimal");  //2006.03.13 추가
							//Date, Month형 속성
							properties.Remove("IsJapanYearType");
							//DatePicker, EditBox + Date, Datetime, Month, Time 관련 속성 Remove
							properties.Remove("InvalidDateIsStringEmpty");
							break;
					}
						break;
				}
				//changeFlag clear
				changeFlag = false;
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
			if ((this.Component != null) && (this.Component is XEditGridCell))
			{
				XEditGridCell info = (XEditGridCell) this.Component;
				//ComboBox관련 속성
				if (!properties.Contains("ComboItems"))
					properties.Add("ComboItems", info.ComboItems);
				if (!properties.Contains("DropDownStyle"))
					properties.Add("DropDownStyle", info.DropDownStyle);
				if (!properties.Contains("MaxDropDownItems"))
					properties.Add("MaxDropDownItems", info.MaxDropDownItems);
				if (!properties.Contains("DictColumn"))
					properties.Add("DictColumn", info.DictColumn);
				if (!properties.Contains("CodeDisplay"))
					properties.Add("CodeDisplay", info.CodeDisplay);
				if (!properties.Contains("SQLType"))
					properties.Add("SQLType", info.SQLType);
				if (!properties.Contains("UserSQL"))
					properties.Add("UserSQL", info.UserSQL);
				//FindBox관련
				if (!properties.Contains("FindWorker"))
					properties.Add("FindWorker", info.FindWorker);
				if (!properties.Contains("DataIndex"))
					properties.Add("DataIndex", info.DataIndex);
				if (!properties.Contains("ClickHotKey"))
					properties.Add("ClickHotKey", info.ClickHotKey);
				if (!properties.Contains("AutoTabDataSelected"))
					properties.Add("AutoTabDataSelected", info.AutoTabDataSelected);
				if (!properties.Contains("EnableEdit"))
					properties.Add("EnableEdit", info.EnableEdit);
				//CheckBox관련
				if (!properties.Contains("CheckedText"))
					properties.Add("CheckedText", info.CheckedText);
				if (!properties.Contains("CheckedValue"))
					properties.Add("CheckedValue", info.CheckedValue);
				if (!properties.Contains("UnCheckedText"))
					properties.Add("UnCheckedText", info.UnCheckedText);
				if (!properties.Contains("UnCheckedValue"))
					properties.Add("UnCheckedValue", info.UnCheckedValue);
				//MemoBox관련
				if (!properties.Contains("MemoFormSize"))
					properties.Add("MemoFormSize", info.MemoFormSize);
				if (!properties.Contains("DisplayMemoText"))
					properties.Add("DisplayMemoText", info.DisplayMemoText);
				if (!properties.Contains("ShowReservedMemoButton"))
					properties.Add("ShowReservedMemoButton", info.ShowReservedMemoButton);
				if (!properties.Contains("ReservedMemoFileName"))
					properties.Add("ReservedMemoFileName", info.ReservedMemoFileName);
				if (!properties.Contains("ReservedMemoClassName"))
					properties.Add("ReservedMemoClassName", info.ReservedMemoClassName);
				if (!properties.Contains("AppendReservedMemoText"))
					properties.Add("AppendReservedMemoText", info.AppendReservedMemoText);
				//Button관련
				if (!properties.Contains("ButtonText"))
					properties.Add("ButtonText", info.ButtonText);
				if (!properties.Contains("ButtonScheme"))
					properties.Add("ButtonScheme", info.ButtonScheme);
				if (!properties.Contains("ButtonImage"))
					properties.Add("ButtonImage", info.ButtonImage);
				//NumericUpDown 관련
				if (!properties.Contains("Increment"))
					properties.Add("Increment", info.Increment);
				if (!properties.Contains("Maxinum"))
					properties.Add("Maxinum", info.Maxinum);
				if (!properties.Contains("Mininum"))
					properties.Add("Mininum", info.Mininum);
				if (!properties.Contains("DecimalPlaces"))
					properties.Add("DecimalPlaces", info.DecimalPlaces);
				//Mask관련
				if (!properties.Contains("EditorStyle"))
					properties.Add("EditorStyle", info.EditorStyle);
				if (!properties.Contains("Mask"))
					properties.Add("Mask", info.Mask);
				if (!properties.Contains("DecimalDigits"))
					properties.Add("DecimalDigits", info.DecimalDigits);
				if (!properties.Contains("MinusAccept"))
					properties.Add("MinusAccept", info.MinusAccept);
				if (!properties.Contains("MaxinumCipher"))
					properties.Add("MaxinumCipher", info.MaxinumCipher);
				if (!properties.Contains("PasswordChar"))
					properties.Add("PasswordChar", info.PasswordChar);
				if (!properties.Contains("GeneralNumberFormat"))
					properties.Add("GeneralNumberFormat", info.GeneralNumberFormat);
				if (!properties.Contains("ShowZeroDecimal"))
					properties.Add("ShowZeroDecimal", info.ShowZeroDecimal);
				//DatePicker 관련
				if (!properties.Contains("IsJapanYearType"))
					properties.Add("IsJapanYearType", info.IsJapanYearType);
				//EditBox,DatePicker + Date, DateTime, Month, Time형 속성(Invalid한 날짜를 보여줄지 여부)
				if (!properties.Contains("IsJapanYearType"))
					properties.Add("IsJapanYearType", info.InvalidDateIsStringEmpty);
			}
		}
	}
	#endregion
}
