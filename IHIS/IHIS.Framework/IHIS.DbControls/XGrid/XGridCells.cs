using System;
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
	#region XGridCell
	/// <summary>
	/// XGridCell(Cell컬럼 정보관리) class에 대한 요약 설명입니다.
	/// </summary>
	[Serializable,
	ToolboxItem(false),
	DesignTimeVisible(false),
	Designer(typeof(XGridCellDesigner))]
	public class XGridCell : Component
	{
		#region Fields
		private string cellName = string.Empty;   // Cell Name
		private string  headerText = string.Empty;     // Header Text
		private XCellDataType cellType = XCellDataType.String;  // Cell Data Type
		private bool	isVisible = true;
		private bool	isReadOnly	= true ;   // Edit불가 ReadOnly
		private ContentAlignment textAlignment = ContentAlignment.MiddleLeft;  // Text Alignment
		private ContentAlignment headerTextAlign = ContentAlignment.MiddleCenter;  // Header Text Alignment
		private string mask = string.Empty;
		private int cellWidth = 80;  // Default Cell Width
		private int decimalDigits = 0;
		private bool	generalNumberFormat = false; //Number의 Format이 일반형식(g)인지 n형식인지 여부
		private bool	showZeroDecimal = false;     //Decimal형일때 소수점이하가 0일때 .00를 보여줄지 여부를 관리(2006.03.13 추가)
		private bool	isJapanYearType = false; //Date형의 경우 연호 YY/MM/DD로 Display할지 여부
		private bool	invalidDateIsStringEmpty = true; //Date,DateTime, Time, Month형 컬럼의 값이 유효하지 않을때 ""를 보여줄지여부를 관리
		private int row = 0;
		private int col = 0;
		private int colSpan = 1;
		private int rowSpan = 1;
		private IDataControl bindControl = null;
		private char passwordChar = (char) 0;   //String형의 Password Char
		private string toolTipText = ""; //Grid가 ToolTipActive이고 ToolTipType은 ColumnDesc일때 보여줄 ToopTipText
		private bool	applyPaintingEvent = false;  //GridCellPainting Event를 적용할지 여부
		
		private XCellEditorStyle editorStyle = XCellEditorStyle.EditBox;
		private ImageList	imageList = null;
		private int			headerImageIndex = -1;
		private int			rowImageIndex = -1;
		private int			alterateRowImageIndex = -1;
		private Image headerImage = null;
		private Image rowImage = null;
		private Image alterateRowImage = null;
		private ContentAlignment headerImageAlign = ContentAlignment.MiddleLeft;
		private ContentAlignment rowImageAlign = ContentAlignment.MiddleLeft;
		private ContentAlignment alterateRowImageAlign = ContentAlignment.MiddleLeft;
		private bool  headerImageStretch = false;
		private bool  rowImageStretch = false;
		private bool  alterateRowImageStretch = false;

		private ArrayList maskSymbols = new ArrayList();   //MaskSymbol을 관리하는 ArrayList
		private bool suppressRepeating = false;  //Repeating Value는 Suppress할 것인지 여부
		private bool enableSort = false;         //컬럼이 Sort가 가능한지 여부

		// 2005/05/09 신종석 폰트 수정
		private Font headerFont = new Font("MS UI Gothic",9.75f);
		private Font rowFont = new Font("MS UI Gothic",9.75f);
		private Font alterateRowFont = new Font("MS UI Gothic",9.75f);
		// 폰트 수정 끝
		private XCellDrawMode headerDrawMode = XCellDrawMode.Vertical;
		private XCellDrawMode rowDrawMode = XCellDrawMode.Flat;
		private XCellDrawMode alterateRowDrawMode = XCellDrawMode.Flat;
		private XColor headerBackColor = XColor.XGridColHeaderBackColor;
		private XColor headerGradientStart = XColor.XGridColHeaderGradientStartColor;
		private XColor headerGradientEnd = XColor.XGridColHeaderGradientEndColor;
		private XColor rowBackColor = XColor.XGridRowBackColor;
		private XColor rowGradientStart = XColor.XGridColHeaderGradientStartColor;
		private XColor rowGradientEnd = XColor.XGridColHeaderGradientEndColor;
		private XColor alterateRowBackColor = XColor.XGridAlterateRowBackColor;
		private XColor alterateRowGradientStart = XColor.XGridColHeaderGradientStartColor;
		private XColor alterateRowGradientEnd = XColor.XGridColHeaderGradientEndColor;
		private XColor headerForeColor = XColor.XGridColHeaderForeColor;
		private XColor rowForeColor = XColor.NormalForeColor;
		private XColor alterateRowForeColor = XColor.NormalForeColor;
		private XColor selectedBackColor = XColor.XGridSelectedCellBackColor;
		private XColor selectedForeColor = XColor.XGridSelectedCellForeColor;
		//2006.01.10 기본선택배경색,전경색사용여부 추가
		private bool   applySelectedBackColorOnPaint = true; //Paint시 선택상태 배경색을 GridCellPainting에서 지정한 색을 사용할지, 기본선택색을 사용할지 여부(Default는 기본선택색사용)
		private bool   applySelectedForeColorOnPaint = true; //Paint시 선택상태 전경색을 GridCellPainting에서 지정한 색을 사용할지, 기본선택색을 사용할지 여부(Default는 기본선택색사용)
		#endregion

		#region Constructors
		/// <summary>
		/// XGridCell 생성자
		/// </summary>
		public XGridCell()
		{
            // MED-14286
            if (NetInfo.Language != LangMode.Jr)
            {
                this.headerFont =
                this.alterateRowFont =
                this.rowFont = Service.COMMON_FONT;
            }
		}
		#endregion

		#region Properties Not Browsable
		/// <summary>
		/// 컬럼의 Visible여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		MergableProperty(false),
		DefaultValue(true),
		Description("컬럼의 Visible여부를 설정합니다.")]
		public bool IsVisible
		{
			get { return isVisible; }
			set { isVisible = value ;}
		}
		/// <summary>
		/// 컬럼의 Row의 위치를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int Row
		{
			get { return row;}
			set { row = value;}
		}
		/// <summary>
		/// 컬럼의 Col의 위치를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int Col
		{
			get { return col;}
			set { col = value;}
		}
		/// <summary>
		/// 컬럼의 RowSpan의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(1)]
		public int RowSpan
		{
			get { return rowSpan;}
			set { rowSpan = value;}
		}
		/// <summary>
		/// 컬럼의 ColSpan의 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(1)]
		public int ColSpan
		{
			get { return colSpan;}
			set { colSpan = value;}
		}
		/// <summary>
		/// 컬럼의 Editor 형식(CellEditorStyle)을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(XCellEditorStyle.EditBox)]
		public XCellEditorStyle EditorStyle
		{
			get { return editorStyle;}
			set { editorStyle = value;}
		}
		/// <summary>
		/// MaskSymbol을 관리하는 ArrayList를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public ArrayList MaskSymbols
		{
			get { return maskSymbols;}
		}
		/// <summary>
		/// String형 컬럼에서 PasswordChar를 설정합니다.(AEditGridCell에서 Display)
		/// </summary>
		[Browsable(false),
		DefaultValue((char) 0)]
		public char PasswordChar
		{
			get { return passwordChar; }
			set 
			{ 
				if (passwordChar != value)
				{
					passwordChar = value;
					//passwordChar가 있으면 Mask는 Clear
					if (passwordChar != (char) 0)
						this.Mask = string.Empty;
				}
			}
		}
		#endregion

		#region Properties (헤더모양)
		/// <summary>
		/// 컬럼의 Header Text를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(""),
		Description("컬럼의 Header Text를 설정합니다.")]
        [Localizable(true)]
		public string HeaderText
		{
			get { return headerText; }
			set { headerText = value ;}
		}
		/// <summary>
		/// 컬럼 Header Text의 Alignment를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(ContentAlignment.MiddleCenter),
		Description("컬럼 Header Text의 Alignment를 설정합니다.")]
		public ContentAlignment HeaderTextAlign
		{
			get { return headerTextAlign; }
			set { headerTextAlign = value ;}
		}
		/// <summary>
		/// 컬럼 Header의 Font를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt"),
		Description("컬럼 Header의 Font를 설정합니다.")]
		public Font HeaderFont
		{
			get { return headerFont;}
			set { headerFont = value;}
		}
		/// <summary>
		/// 컬럼 Header의 그리기모드를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(XCellDrawMode.Vertical),
		Description("컬럼 Header의 그리기모드를 설정합니다.")]
		public XCellDrawMode HeaderDrawMode
		{
			get { return headerDrawMode;}
			set { headerDrawMode = value;}
		}
		/// <summary>
		/// 컬럼 Header의 배경색을 가져오거나 설정합니다.(Flat형일때 적용됨)
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderBackColor"),
		Description("컬럼 Header의 배경색을 설정합니다.(Flat형일때 적용됨)")]
		public XColor HeaderBackColor
		{
			get { return headerBackColor;}
			set { headerBackColor = value;}
		}
		/// <summary>
		/// 컬럼 Header의 Gradient 시작색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientStartColor"),
		Description("컬럼 Header의 Gradient 시작색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor HeaderGradientStart
		{
			get { return headerGradientStart;}
			set { headerGradientStart = value;}
		}
		/// <summary>
		/// 컬럼 Header의 Gradient 종료색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientEndColor"),
		Description("컬럼 Header의 Gradient 종료색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor HeaderGradientEnd
		{
			get { return headerGradientEnd;}
			set { headerGradientEnd = value;}
		}
		/// <summary>
		/// 컬럼 Header의 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderForeColor"),
		Description("컬럼 Header의 텍스트색을 설정합니다.")]
		public XColor HeaderForeColor
		{
			get { return headerForeColor;}
			set { headerForeColor = value;}
		}
		[Browsable(true), Category("헤더모양"),
		DefaultValue(-1),
		MergableProperty(true),
		Description("헤더의 이미지를 표시할 이미지목록의 인덱스를 설정합니다.")]
		[Editor(typeof(IHIS.Framework.ImageIndexesEditor), typeof(UITypeEditor))]
		[ImageList("ImageList")]
		public  int HeaderImageIndex
		{
			get { return headerImageIndex; }
			set
			{
				if (headerImageIndex != value)
				{
					headerImageIndex = value;
					if (headerImageIndex < 0)
						this.HeaderImage = null;
					else
					{
						try{ this.HeaderImage = imageList.Images[value];}
						catch{this.HeaderImage = null;	}
					}
				}
			}
		}
		/// <summary>
		/// 컬럼 헤더의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		DefaultValue(null),
		Description("Header의 Image를 설정합니다.")]
		public Image HeaderImage
		{
			get { return headerImage;}
			set { headerImage = value;}
		}
		/// <summary>
		/// Header의 Image Alignment를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(ContentAlignment.MiddleLeft),
		Description("Header의 Image Align을 설정합니다.")]
		public ContentAlignment HeaderImageAlign
		{
			get { return headerImageAlign;}
			set { headerImageAlign = value;}
		}
		/// <summary>
		/// Header의 Image의 Stretch여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("헤더모양"),
		MergableProperty(true),
		DefaultValue(false),
		Description("Header의 Image의 Stretch여부를 설정합니다.")]
		public bool HeaderImageStretch
		{
			get { return headerImageStretch;}
			set { headerImageStretch = value;}
		}
		#endregion

		#region Properties(컬럼정보)
		/// <summary>
		/// 컬럼의 이름을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		MergableProperty(false),
		DefaultValue(""),
		Description("컬럼의 이름을 설정합니다.")]
		public string CellName
		{
			get { return cellName; }
			set 
			{ 
				if (value.Trim() == string.Empty)
					throw(new Exception("컬럼명을 입력하십시오."));
				cellName = value ;
			}
		}
		/// <summary>
		/// 컬럼의 Data형식(CellDataType)을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(XCellDataType.String),
		Description("컬럼의 Data형식(XCellDataType)을 설정합니다.")]
		public XCellDataType CellType
		{
			get { return cellType; }
			set 
			{ 
				if (cellType != value)
				{
					cellType = value ;

					//2005.12.01 일본연호 표기 Clear
					this.isJapanYearType = false;

					//Alignment 변경
					switch (cellType)
					{
						case XCellDataType.Number:
						case XCellDataType.Decimal:
							this.TextAlignment = ContentAlignment.MiddleRight;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
						case XCellDataType.Date:
							this.TextAlignment = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CDateDefaultMask;
							break;
						case XCellDataType.DateTime:
							this.TextAlignment = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CDateTimeDefaultMask;
							break;
						case XCellDataType.Time:
							this.TextAlignment = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CTimeDefaultMask;
							break;
						case XCellDataType.Month:
							this.TextAlignment = ContentAlignment.MiddleCenter;
							this.mask = MaskHelper.CMonthDefaultMask;
							break;
						default:
							this.TextAlignment = ContentAlignment.MiddleLeft;
							this.mask = MaskHelper.CStringDefaultMask;
							break;
					}
				}
			}
		}
		/// <summary>
		/// 컬럼의 Mask를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		Description("컬럼의 Mask를 설정합니다.")]
		public string Mask
		{
			get { return mask; }
			set 
			{ 
				string errMsg = "";
				//Binary,
				if (cellType != XCellDataType.Binary)
				{
					MaskType mType = (MaskType) Enum.Parse(typeof(MaskType), cellType.ToString());
					if (!MaskHelper.IsValidMask(mType, value, out errMsg))
						throw(new Exception(errMsg));
					mask = value ;
					//Mask가 있으면 PasswordChar Clear
					if (mask != string.Empty)
						this.passwordChar = (char) 0;
				}
			}
		}
		// Mask의 Serialize 통제 Method
		// Mask의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private bool ShouldSerializeMask()
		{
			// Date(YYYY/MM/DD), DateTime(YYYY/MM/DD HH:MI:SS), Time(HH:MI:SS) Month(YYYY/MM) Default
			if (cellType == XCellDataType.Date)
				return (mask != MaskHelper.CDateDefaultMask);
			else if (cellType == XCellDataType.DateTime)
				return (mask != MaskHelper.CDateTimeDefaultMask);
			else if (cellType == XCellDataType.Time)
				return (mask != MaskHelper.CTimeDefaultMask);
			else if (cellType == XCellDataType.Month)
				return (mask != MaskHelper.CMonthDefaultMask);
			else
				return (mask != MaskHelper.CStringDefaultMask);
		}
		// 다시설정시 기본값
		// Mask의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private void ResetMask()
		{	
			// Date(YYYY/MM/DD), DateTime(YYYY/MM/DD HH:MI:SS), Time(HH:MI:SS) Default
			if (cellType == XCellDataType.Date)
				Mask = MaskHelper.CDateDefaultMask;
			else if (cellType == XCellDataType.DateTime)
				Mask = MaskHelper.CDateTimeDefaultMask;
			else if (cellType == XCellDataType.Time)
				Mask = MaskHelper.CTimeDefaultMask;
			else if (cellType == XCellDataType.Month)
				Mask = MaskHelper.CMonthDefaultMask;
			else
				Mask = MaskHelper.CStringDefaultMask;
		}
		/// <summary>
		/// 컬럼의 너비를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(80),
		Description("컬럼의 너비를 설정합니다.")]
		public int CellWidth
		{
			get { return cellWidth;}
			set 
			{ 
				// - 입력불가
				cellWidth = Math.Max(value,0);
			}
		}
		/// <summary>
		/// 컬럼이 Decimal형일때 Digits를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(0),
		Description("컬럼이 Decimal형일때 Digits를 설정합니다.")]
		public int DecimalDigits
		{
			get { return decimalDigits;}
			set { decimalDigits = Math.Max(value,0);}
		}
		[Category("컬럼정보"),
		DefaultValue(false),
		Description("Number형의 형식이 일반형식(1234)인지 숫자(1,234)형식인지 여부를 지정합니다.")]
		public bool GeneralNumberFormat
		{
			get { return generalNumberFormat;}
			set { generalNumberFormat = value;}
		}
		[Category("컬럼정보"),
		DefaultValue(false),
		Description("Decimal형일때 소수점이하가 0일때 .00형태로 보여줄지 여부를 지정합니다.")]
		public bool ShowZeroDecimal
		{
			get { return showZeroDecimal;}
			set { showZeroDecimal = value;}
		}
		/// <summary>
		/// DatePicker를 일본연호로 표기할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("컬럼정보"),DefaultValue(false),
		Description("일본연호로 표기할지 여부를 지정합니다.")]
		public virtual bool IsJapanYearType
		{
			get { return this.isJapanYearType; }
			set 
			{
				//2005.12.01 Date형과 Month형만 가능함
				if ((this.cellType == XCellDataType.Date) || (this.cellType == XCellDataType.Month))
					this.isJapanYearType = value;
				else
					this.isJapanYearType = false; //그외는 false
			}
		}
		/// <summary>
		/// Date,DateTime,Time,Month형 컬럼일때 값이 유효하지 않을때 ""를 보여줄지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("컬럼정보"),DefaultValue(true),
		Description("Date,DateTime,Time,Month형 컬럼일때 값이 유효하지 않을때 String.Empty를 보여줄지 여부를 지정합니다")]
		public virtual bool InvalidDateIsStringEmpty
		{
			get { return invalidDateIsStringEmpty;}
			set { invalidDateIsStringEmpty = value;}
		}
		/// <summary>
		/// 반복되는 값을 숨길지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(false),
		Description("반복되는 값을 숨길지 여부를 설정합니다.")]
		public bool SuppressRepeating
		{
			get { return suppressRepeating;}
			set { suppressRepeating = value;}
		}
		/// <summary>
		/// 컬럼이 Sort가 가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼정보"),
		DefaultValue(false),
		Description("컬럼이 Sort가 가능한지 여부를 설정합니다.")]
		public bool EnableSort
		{
			get { return enableSort;}
			set { enableSort = value;}
		}
		/// <summary>
		/// 버튼의 이미지를 표시할 이미지목록을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true), Category("컬럼정보"),
		DefaultValue(null),
		MergableProperty(true),
		Description("이미지를 표시할 이미지목록을 설정합니다.")]
		public ImageList ImageList
		{
			get { return imageList; }
			set
			{
				if (imageList != value)
				{
					imageList = value;
					if (imageList == null)
					{
						this.headerImageIndex = -1;
						this.rowImageIndex = -1;
						this.alterateRowImageIndex = -1;
						this.HeaderImage = null;
						this.RowImage = null;
						this.AlterateRowImage = null;
					}
					else
					{
						try	{this.HeaderImage = imageList.Images[headerImageIndex];	}
						catch {this.HeaderImage = null;}
						try	{this.RowImage = imageList.Images[rowImageIndex];}
						catch {this.RowImage = null;}
						try {this.AlterateRowImage = imageList.Images[alterateRowImageIndex];}
						catch {	this.AlterateRowImage = null;}
					}
				}
			}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(null),
		Description("컬럼과 데이타를 공유할 Bind Control을 지정합니다.")]
		public IDataControl BindControl
		{
			get { return bindControl;}
			set { bindControl = value;}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(""),
		Description("ToolTip활성화시에 ToolTipType이 컬럼설명(ColumnDesc)일때 보여줄 텍스트를 지정합니다.")]
		public string ToolTipText
		{
			get { return toolTipText;}
			set { toolTipText = value;}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(false),
		Description("이 컬럼에 GridCellPainting Event를 적용할지 여부를 지정합니다.")]
		public bool ApplyPaintingEvent
		{
			get { return applyPaintingEvent;}
			set { applyPaintingEvent = value;}
		}
		/// <summary>
		/// ReadOnly여부를 가져오거나 설정합니다.(AEditGridCell에서 Browse)
		/// </summary>
		[Browsable(false),
		DefaultValue(true)]
		public virtual bool IsReadOnly
		{
			get { return isReadOnly ;}
			set 
			{ 
				if (isReadOnly != value)
				{
					//BinaryType은 ReadOnly만 가능
					if ((CellType == XCellDataType.Binary) && !value)
						throw(new Exception("Binary Type은 ReadOnly 컬럼입니다."));

					isReadOnly = value ;
				}

			}
		}
		private bool ShouldSerializeIsReadOnly()
		{
			//Binary는 ReadOnly true
			if (CellType == XCellDataType.Binary)
				return !isReadOnly;
			else
				return isReadOnly;
		}
		private void ResetIsReadOnly()
		{
			if (CellType == XCellDataType.Binary)
				isReadOnly = true;
			else
				isReadOnly = false;
		}
		#endregion

		#region Properties (컬럼모양)
		/// <summary>
		/// Row Data Text의 Align을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		Description("Row Data Text의 Align을 설정합니다.")]
		public ContentAlignment TextAlignment
		{
			get { return textAlignment;}
			set { textAlignment = value;}
		}
		// TextAlignment의 Serialize 통제 Method
		// TextAlignment의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private bool ShouldSerializeTextAlignment()
		{
			bool result = false;
			switch (cellType)
			{
				case XCellDataType.String:
					result =  (textAlignment != ContentAlignment.MiddleLeft);
					break;
				case XCellDataType.Date:
				case XCellDataType.DateTime:
				case XCellDataType.Time:
				case XCellDataType.Month:
					result =  (textAlignment != ContentAlignment.MiddleCenter);
					break;
				case XCellDataType.Decimal:
				case XCellDataType.Number:
					result =  (textAlignment != ContentAlignment.MiddleRight);
					break;
				default:
					result =  (textAlignment != ContentAlignment.MiddleLeft);
					break;
			}
			return result;
		}
		// 다시설정시 기본값
		// TextAlignment의 DefaultValue Attribute를 주지 않고, Case에 따라 DefaultValue 변경
		private void ResetTextAlignment()
		{	
			switch (cellType)
			{
				case XCellDataType.String:
					TextAlignment = ContentAlignment.MiddleLeft;
					break;
				case XCellDataType.Date:
				case XCellDataType.DateTime:
				case XCellDataType.Time:
				case XCellDataType.Month:
					TextAlignment = ContentAlignment.MiddleCenter;
					break;
				case XCellDataType.Decimal:
				case XCellDataType.Number:
					TextAlignment = ContentAlignment.MiddleRight;
					break;
				default:
					TextAlignment = ContentAlignment.MiddleLeft;
					break;
			}
		}
		/// <summary>
		/// 행의 Font를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt"),
		Description("행의 Font를 설정합니다.")]
		public Font RowFont
		{
			get { return rowFont;}
			set { rowFont = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 Font를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt"),
		Description("교대로 반복되는 행의 Font를 설정합니다.")]
		public Font AlterateRowFont
		{
			get { return alterateRowFont;}
			set { alterateRowFont = value;}
		}
		/// <summary>
		/// 행의 그리기모드를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(XCellDrawMode.Flat),
		Description("행의 그리기모드를 설정합니다.")]
		public XCellDrawMode RowDrawMode
		{
			get { return rowDrawMode;}
			set { rowDrawMode = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 그리기모드를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(XCellDrawMode.Flat),
		Description("교대로 반복되는 행의 그리기모드를 설정합니다.")]
		public XCellDrawMode AlterateRowDrawMode
		{
			get { return alterateRowDrawMode;}
			set { alterateRowDrawMode = value;}
		}
		/// <summary>
		/// 행의 배경색을 가져오거나 설정합니다.(Flat형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridRowBackColor"),
		Description("행의 배경색을 설정합니다.(Flat형일때 적용됨)")]
		public XColor RowBackColor
		{
			get { return rowBackColor;}
			set { rowBackColor = value;}
		}
		/// <summary>
		/// 행의 Gradient 시작색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientStartColor"),
		Description("행의 Gradient 시작색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor RowGradientStart
		{
			get { return rowGradientStart;}
			set { rowGradientStart = value;}
		}
		/// <summary>
		/// 행의 Gradient 종료색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientEndColor"),
		Description("행의 Gradient 종료색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor RowGradientEnd
		{
			get { return rowGradientEnd;}
			set { rowGradientEnd = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 배경색을 가져오거나 설정합니다.(Flat형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridAlterateRowBackColor"),
		Description("교대로 반복되는 행의 배경색을 설정합니다.(Flat형일때 적용됨)")]
		public XColor AlterateRowBackColor
		{
			get { return alterateRowBackColor;}
			set { alterateRowBackColor = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 Gradient 시작색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientStartColor"),
		Description("교대로 반복되는 행의 Gradient 시작색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor AlterateRowGradientStart
		{
			get { return alterateRowGradientStart;}
			set { alterateRowGradientStart = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 Gradient 종료색을 가져오거나 설정합니다.(Gradient형일때 적용됨)
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridColHeaderGradientEndColor"),
		Description("교대로 반복되는 행의 Gradient 종료색을 설정합니다.(Gradient형일때 적용됨)")]
		public XColor AlterateRowGradientEnd
		{
			get { return alterateRowGradientEnd;}
			set { alterateRowGradientEnd = value;}
		}
		/// <summary>
		/// 행의 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "NormalForeColor"),
		Description("행의 텍스트색을 설정합니다.")]
		public XColor RowForeColor
		{
			get { return rowForeColor;}
			set { rowForeColor = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "NormalForeColor"),
		Description("교대로 반복되는 행의 텍스트색을 설정합니다.")]
		public XColor AlterateRowForeColor
		{
			get { return alterateRowForeColor;}
			set { alterateRowForeColor = value;}
		}
		/// <summary>
		/// 컬럼이 선택될때 배경색을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridSelectedCellBackColor"),
		Description("컬럼이 선택될때 배경색을 설정합니다.")]
		public XColor SelectedBackColor
		{
			get { return selectedBackColor;}
			set { selectedBackColor = value;}
		}
		/// <summary>
		/// 컬럼이 선택될때 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(typeof(XColor), "XGridSelectedCellForeColor"),
		Description("컬럼이 선택될때 텍스트색을 설정합니다.")]
		public XColor SelectedForeColor
		{
			get { return selectedForeColor;}
			set { selectedForeColor = value;}
		}
		[Browsable(true), Category("컬럼모양"),
		DefaultValue(-1),
		MergableProperty(true),
		Description("행의 이미지를 표시할 이미지목록의 인덱스를 설정합니다.")]
		[Editor(typeof(IHIS.Framework.ImageIndexesEditor), typeof(UITypeEditor))]
		[ImageList("ImageList")]
		public  int RowImageIndex
		{
			get { return rowImageIndex; }
			set
			{
				if (rowImageIndex != value)
				{
					rowImageIndex = value;
					if (rowImageIndex < 0)
						this.RowImage = null;
					else
					{
						try{ this.RowImage = imageList.Images[value];}
						catch{this.RowImage = null;	}
					}
				}
			}
		}
		[Browsable(true), Category("컬럼모양"),
		DefaultValue(-1),
		MergableProperty(true),
		Description("행의 이미지를 표시할 이미지목록의 인덱스를 설정합니다.")]
		[Editor(typeof(IHIS.Framework.ImageIndexesEditor), typeof(UITypeEditor))]
		[ImageList("ImageList")]
		public  int AlterateRowImageIndex
		{
			get { return alterateRowImageIndex; }
			set
			{
				if (alterateRowImageIndex != value)
				{
					alterateRowImageIndex = value;
					if (alterateRowImageIndex < 0)
						this.AlterateRowImage = null;
					else
					{
						try{ this.AlterateRowImage = imageList.Images[value];}
						catch{this.AlterateRowImage = null;	}
					}
				}
			}
		}
		/// <summary>
		/// 행의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(null),
		Description("행의 Image를 설정합니다.")]
		public Image RowImage
		{
			get { return rowImage;}
			set { rowImage = value;}
		}
		/// <summary>
		/// 행의 Image Alignment를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(ContentAlignment.MiddleLeft),
		Description("행의 Image Align을 설정합니다.")]
		public ContentAlignment RowImageAlign
		{
			get { return rowImageAlign;}
			set { rowImageAlign = value;}
		}
		/// <summary>
		/// 행의 Image의 Stretch여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(false),
		Description("행의 Image의 Stretch여부를 설정합니다.")]
		public bool RowImageStretch
		{
			get { return rowImageStretch;}
			set { rowImageStretch = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 Image를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		DefaultValue(null),
		Description("교대로 반복되는 행의 Image를 설정합니다.")]
		public Image AlterateRowImage
		{
			get { return alterateRowImage;}
			set { alterateRowImage = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 Image Alignment를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(ContentAlignment.MiddleLeft),
		Description("교대로 반복되는 행의 Image Align을 설정합니다.")]
		public ContentAlignment AlterateRowImageAlign
		{
			get { return alterateRowImageAlign;}
			set { alterateRowImageAlign = value;}
		}
		/// <summary>
		/// 교대로 반복되는 행의 Image의 Stretch여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(false),
		Description("교대로 반복되는 행의 Image의 Stretch여부를 설정합니다.")]
		public bool AlterateRowImageStretch
		{
			get { return alterateRowImageStretch;}
			set { alterateRowImageStretch = value;}
		}
		/// <summary>
		/// 선택상태일때 Paint시 배경색을 GridCellPainting에서 지정한 색을 사용할지, 기본선택색을 사용할지 여부를 지정합니다.(true:기본선택색사용, false:지정한색사용)
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(true),
		Description("선택상태일때 Paint시 배경색을 GridCellPainting에서 지정한 색을 사용할지, 기본선택색을 사용할지 여부를 지정합니다.(true:기본선택색사용, false:지정한색사용)")]
		public bool ApplySelectedBackColorOnPaint
		{
			get { return applySelectedBackColorOnPaint;}
			set { applySelectedBackColorOnPaint = value;}
		}
		/// <summary>
		/// 선택상태일때 Paint시 전경색을 GridCellPainting에서 지정한 색을 사용할지, 기본선택색을 사용할지 여부를 지정합니다.(true:기본선택색사용, false:지정한색사용)
		/// </summary>
		[Category("컬럼모양"),
		MergableProperty(true),
		DefaultValue(true),
		Description("선택상태일때 Paint시 전경색을 GridCellPainting에서 지정한 색을 사용할지, 기본선택색을 사용할지 여부를 지정합니다.(true:기본선택색사용, false:지정한색사용)")]
		public bool ApplySelectedForeColorOnPaint
		{
			get { return this.applySelectedForeColorOnPaint;}
			set { applySelectedForeColorOnPaint = value;}
		}
		#endregion
		
		#region ToString()
		/// <summary>
		/// 이 개체의 String표현을 가져옵니다.(컬럼명)
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return cellName;
		}
		#endregion

	}
	#endregion

	#region XGridCell Type Converter
	/// <summary>
	/// XGridCell TypeConverter
	/// </summary>
	public class XGridCellTypeConverter : TypeConverter
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
			XGridCell cellInfo;

			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is XGridCell)
				{
					cellInfo = (XGridCell)value;
					InstanceDescriptor id = new InstanceDescriptor(cellInfo.GetType().GetConstructor(Type.EmptyTypes), null, false);

					return id;
				}
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	#endregion

	#region XGridCellCollection 
	// XGridCell class 관리 Collection
	/// <summary>
	/// XGridCell 객체를 관리하는 컬렉션입니다.
	/// </summary>
	[Serializable]
	public class XGridCellCollection : CollectionBase
	{
		/// <summary>
		/// 해당 Index에 있는 XGridCell 객체를 반환합니다.
		/// </summary>
		public XGridCell this[int index]
		{
			get { return (XGridCell)List[index]; }
		}
		/// <summary>
		/// 해당 Key(string)를 가지는 XGridCell를 반환합니다.
		/// </summary>
		public XGridCell this[string key]
		{
			get
			{
				if (key == "") return null;
				foreach (XGridCell item in this)
				{
					if (item.CellName.ToUpper() == key.ToUpper()) return item;
				}
				return null;
			}
		}
		/// <summary>
		/// 해당 row, col을 가지는 XGridCell를 반환합니다.
		/// </summary>
		public XGridCell this[int row, int col]
		{
			get
			{
				foreach (XGridCell item in this)
				{
					if ((item.Row == row) && (item.Col == col))
						return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridCell 객체를 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="cellInfo"> XGridCell 객체 </param>
		public void Add(XGridCell cellInfo)
		{
			foreach (XGridCell info in List)
			{
				if ((info.CellName.Trim() != string.Empty) && (info.CellName == cellInfo.CellName))
					throw(new Exception("[XGridCell]이미 등록된 컬럼명과 동일합니다."));
			}
			List.Add(cellInfo);
		}
		/// <summary>
		/// XGridCell[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="cellInfos"> XGridCell[] </param>
		public void AddRange(XGridCell[] cellInfos)
		{
			List.Clear();
			foreach (XGridCell cellInfo in cellInfos)
			{
				Add(cellInfo);
			}
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridCell객체를 제거합니다.
		/// </summary>
		/// <param name="cellInfo">제거할 XGridCell객체</param>
		public void Remove(XGridCell cellInfo)
		{
			List.Remove(cellInfo);
		}
		// colIndex를 자기고 , XGridCell의 row와 Matching되는 XGridCell Return
		/// <summary>
		/// XGridCell의 row와 Matching되는 XGridCell 객체를 반환합니다.
		/// </summary>
		/// <param name="col"> column Index </param>
		/// <returns> XGridCell 객체 (없으면 null) </returns>
		public XGridCell GetXGridCellByColIndex(int col)
		{
			foreach (XGridCell info in this)
			{
				if ( info.Col == col)
					return info;
			}
			return null;
		}
		/// <summary>
		/// XGridCell 정보로 Cell의 위치정보를 가져옵니다.
		/// </summary>
		/// <param name="cellInfo"> XGridCell 객체 </param>
		/// <param name="headerLineCnt"> Header의 Line 수 </param>
		/// <param name="rowPos"> (out) Row의 위치 </param>
		/// <param name="rowSpan"> (out) RowSpan 값 </param>
		public void GetCellPositionByXGridCell(XGridCell cellInfo, int headerLineCnt, out int rowPos, out int rowSpan)
		{
			// out Init
			rowPos = 0;
			rowSpan = 1;
			int bfRowPosCnt = 0;
			int afRowPosCnt = 0;
			foreach (XGridCell info in this)
			{
				// 동일한 Col 위치일때 Or 
				if ( info.Col == cellInfo.Col)
				{
					if (info.Row < cellInfo.Row)
					{
						bfRowPosCnt++;
					}
					else if (info.Row > cellInfo.Row)
					{
						afRowPosCnt++;
					}
				}
				// info중에서 ColSpan이 큰 경우도 고려해야함
				if ((info.Col < cellInfo.Col) && ( cellInfo.Col < info.Col + info.ColSpan))
				{
					if (info.Row > cellInfo.Row)
						afRowPosCnt++;
					else if (info.Row < cellInfo.Row)
						bfRowPosCnt++;
				}
			}
			rowPos = bfRowPosCnt;
			if (bfRowPosCnt == 0 && afRowPosCnt == 0)
				rowSpan = headerLineCnt;
			else if (bfRowPosCnt == 0 && afRowPosCnt > 0)
				rowSpan = 1;
			else if (bfRowPosCnt > 0 && afRowPosCnt > 0)
				rowSpan = 1;
			else
				rowSpan = headerLineCnt - bfRowPosCnt;
		
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="cellInfo">컬렉션에서 찾을 XGridCell입니다.</param>
		/// <returns>cellInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XGridCell cellInfo)
		{
			return List.Contains(cellInfo);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="cellInfo">컬렉션에서 찾을 XGridCell입니다.</param>
		/// <returns>cellInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(string cellName)
		{
			foreach (XGridCell item in this)
			{
				if (item.CellName == cellName)
					return true;
			}
			return false;
		}
		/// <summary>
		/// 컬렉션에 속하는 XGridCell을 XGridCell[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XGridCell[] </returns>
		public XGridCell[] ToArray()
		{
			XGridCell[] cellInfoArray = new XGridCell[List.Count];
			for (int i = 0; i < List.Count; i++)
				cellInfoArray[i] = (XGridCell) List[i];
			return cellInfoArray;
		}
	}
	#endregion

	#region XGridCellDesigner
	/// <summary>
	/// XGridCellDesigner의 Designer입니다.
	/// </summary>
	internal class XGridCellDesigner : System.ComponentModel.Design.ComponentDesigner
	{
		private bool changeFlag = false;
		private ISelectionService iSvc;
		private IComponentChangeService iComp;

		/// <summary>
		/// Designer를 초기화 합니다.
		/// </summary>
		/// <param name="component"> Designer를 가진 IComponent 개체 </param>
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			// Hook up events
			iSvc = (ISelectionService) GetService(typeof(ISelectionService));
			iComp = (IComponentChangeService) GetService(typeof(IComponentChangeService));
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
			if (e.Component is XGridCell)
			{
				XGridCell info = (XGridCell) e.Component;
				// Control삭제시 OnComponentChanged 발생, 이때 e.Member가 null이므로
				// e.Member Check 해야함
				if (e.Member != null)
				{
					if (e.Member.Name == "CellType")
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
			if (changeFlag && (this.Component != null) && (this.Component is XGridCell))
			{
				XGridCell info = (XGridCell) this.Component;
				switch (info.CellType)
				{
					case XCellDataType.Date:
					case XCellDataType.Month:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");
						break;
					case XCellDataType.String:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");
						// Date,Month,DateTime,Time형 속성 Remove
						properties.Remove("IsJapanYearType");
						properties.Remove("InvalidDateIsStringEmpty");
						break;
					case XCellDataType.DateTime:
					case XCellDataType.Time:
						// Number관련 속성 Remove
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");
						// Date,Month형 속성 Remove
						properties.Remove("IsJapanYearType");
						break;
					case XCellDataType.Number:
						//Mask, DecimalDigits Remove
						properties.Remove("DecimalDigits");
						properties.Remove("Mask");
						properties.Remove("ShowZeroDecimal");
						// Date,Month,DateTime,Time형 속성 Remove
						properties.Remove("IsJapanYearType");
						properties.Remove("InvalidDateIsStringEmpty");
						break;
					case XCellDataType.Decimal:
						//Mask Remove
						properties.Remove("Mask");
						// Date,Month,DateTime,Time형 속성 Remove
						properties.Remove("IsJapanYearType");
						properties.Remove("InvalidDateIsStringEmpty");
						break;
					case XCellDataType.Binary:
						properties.Remove("Mask");
						properties.Remove("DecimalDigits");
						properties.Remove("GeneralNumberFormat");
						properties.Remove("ShowZeroDecimal");
						// Date,Month,DateTime,Time형 속성 Remove
						properties.Remove("IsJapanYearType");
						properties.Remove("InvalidDateIsStringEmpty");
						break;
				}
				//changeFlag Clear
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
			if ((this.Component != null) && (this.Component is XGridCell))
			{
				XGridCell info = (XGridCell) this.Component;
				//Mask관련
				if (!properties.Contains("Mask"))
					properties.Add("Mask", info.Mask);
				if (!properties.Contains("DecimalDigits"))
					properties.Add("DecimalDigits", info.DecimalDigits);
				if (!properties.Contains("GeneralNumberFormat"))
					properties.Add("GeneralNumberFormat", info.GeneralNumberFormat);
				if (!properties.Contains("ShowZeroDecimal"))
					properties.Add("ShowZeroDecimal", info.ShowZeroDecimal);
				if (!properties.Contains("IsJapanYearType"))
					properties.Add("IsJapanYearType", info.IsJapanYearType);
				if (!properties.Contains("InvalidDateIsStringEmpty"))
					properties.Add("InvalidDateIsStringEmpty", info.InvalidDateIsStringEmpty);
			}
		}
	}
	#endregion
}
