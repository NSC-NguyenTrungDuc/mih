using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel.Design.Serialization;

namespace IHIS.Framework
{
	/// <summary>
	/// Cell class에 대한 요약설명입니다.
	/// </summary>
	public class XCell
	{
		#region Fields Without Property
		private XColor insertedTextColor = XColor.InsertedForeColor;
		private XColor updatedTextColor = XColor.UpdatedForeColor;
		private string oldToolTipText = string.Empty;
		private int rowNumber = -1; //논리적인 행번호
		private bool buttonMouseOver = false; //Button형 Cell에 MouseOver상태인지 여부
		private static Pen						
			pen0, pen1, pen2,
			pen01, pen02, pen03, pen04, pen05, pen06, 
			pen07, pen08, pen09, pen10, pen11, pen12, pen13;

		private static LinearGradientBrush		
			brush01, brush02, brush03;
		private static SolidBrush   brush1;
		#endregion

		#region Fields With Property
		//Value에 관계없이 Display해야할 Text (있으면 DisplayText에서 Value에 관계없이 this.displayText로 Display함)
		private string displayText = "";
		private string cellName;
		private int row = -1;
		private int col = -1;
		private int rowSpan = 1;
		private int colSpan = 1;
		private bool isDesignMode = true;
		private XGrid grid;
		private object cellValue = null;
		private bool focused = false;
		private bool select = false;
		private ContentAlignment textAlignment = ContentAlignment.MiddleCenter;
		private XCellBorder focusBorder = new XCellBorder(XColor.XGridFocusCellBorderColor.Color,2);
		private XCellBorder normalBorder = new XCellBorder(XColor.XGridNormalCellBorderColor.Color,1);
		private bool isAddedHeader = false;  //추가된 Header에 의한 Cell여부를 나타냄
		private string toolTipText = string.Empty;
		private Image image = null;
		private Image sortImage = null;  // Sort시 보여줄 Image
		private ContentAlignment imageAlignment = ContentAlignment.MiddleLeft;
		private bool  imageStretch = false;
		private bool  changeTextRegionByImageRegion = true;  // Image의 영역에 따라 Text영역을 변경할 것인지 여부
		private object tag = null;
		private XCellDrawMode drawMode = XCellDrawMode.Flat;
		private XColor backColor = XColor.XGridRowBackColor;
		private XColor gradientStart = XColor.XGridColHeaderGradientStartColor;
		private XColor gradientEnd = XColor.XGridColHeaderGradientEndColor;
		private XColor foreColor = XColor.NormalForeColor;
		private XColor selectedBackColor = XColor.XGridSelectedCellBackColor;
		private XColor selectedForeColor = XColor.XGridSelectedCellForeColor;
		private Font font = new Font("MS UI Gothic",9.75f);
		//Button형 Cell관련
		private bool isButtonShape = false;
		private XButtonSchemes buttonScheme = XButtonSchemes.Blue;
		private bool buttonDisabled = false;
		#endregion

		#region Properties
		/// <summary>
		/// Cell의 성격을 가져옵니다.
		/// </summary>
		public virtual XCellPersonality Personality
		{
			get { return XCellPersonality.Content;}
		}
		/// <summary>
		/// Cell의 이름을 가져오거나 설정합니다.
		/// </summary>
		public string CellName
		{
			get { return cellName; }
			set { cellName = value ;}
		}
		/// <summary>
		/// Cell의 Row 값을 가져오거나 설정합니다.
		/// </summary>
		public int Row
		{
			get {return row;}
			set {row = value;}
		}
		/// <summary>
		/// Cell의 Col 값을 가져오거나 설정합니다.
		/// </summary>
		public int Col
		{
			get {return col;}
			set {col = value;}
		}
		/// <summary>
		/// Cell의 ColSpan 값을 가져오거나 설정합니다.
		/// </summary>
		public int ColSpan
		{
			get{return colSpan;}
			set
			{
				colSpan = value;
				InvokeInvalidate();
			}
		}
		/// <summary>
		/// Cell의 RowSpan 값을 가져오거나 설정합니다.
		/// </summary>
		public int RowSpan
		{
			get{return rowSpan;}
			set
			{
				rowSpan = value;
				InvokeInvalidate();
			}
		}
		/// <summary>
		/// Cell이 DesignMode에서 설정되었는지 RunTime시 설정되었는지를 가져오거나 설정합니다.
		/// </summary>
		public bool IsDesignMode
		{
			get{return isDesignMode;}
			set{isDesignMode = value;}
		}
		/// <summary>
		/// Cell의 Display Text를 가져오거나 설정합니다.
		/// </summary>
		public string DisplayText
		{
			get { return displayText;}
			set { displayText = value;}
		}
		/// <summary>
		/// Cell Font을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		 DefaultValue(typeof(Font), "MS UI Gothic, 9.75pt")]
		public virtual Font Font
		{
			get { return font;}
			set 
			{
				if (font != value)
				{
					font = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell 그리기모드를 가져오거나 설정합니다.
		/// </summary>
		public virtual XCellDrawMode DrawMode
		{
			get { return drawMode;}
			set 
			{
				if (drawMode != value)
				{
					drawMode = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell 배경색을 가져오거나 설정합니다.
		/// </summary>
		public virtual XColor BackColor
		{
			get { return backColor;}
			set 
			{
				if (backColor != value)
				{
					backColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 시작색을 가져오거나 설정합니다.
		/// </summary>
		public virtual XColor GradientStart
		{
			get { return gradientStart;}
			set 
			{
				if (gradientStart != value)
				{
					gradientStart = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 배경을 Gradient로 그릴때 종료색을 가져오거나 설정합니다.
		/// </summary>
		public virtual XColor GradientEnd
		{
			get { return gradientEnd;}
			set 
			{
				if (gradientEnd != value)
				{
					gradientEnd = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell 텍스트색을 가져오거나 설정합니다.
		/// </summary>
		public virtual XColor ForeColor
		{
			get { return foreColor;}
			set 
			{
				if (foreColor != value)
				{
					foreColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 선택된 Cell 배경색을 가져오거나 설정합니다.
		/// </summary>
		public virtual XColor SelectedBackColor
		{
			get { return selectedBackColor;}
			set 
			{
				if (selectedBackColor != value)
				{
					selectedBackColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// 선택된 Cell의 Text색을 가져오거나 설정합니다.
		/// </summary>
		public virtual XColor SelectedForeColor
		{
			get { return selectedForeColor;}
			set 
			{
				if (selectedForeColor != value)
				{
					selectedForeColor = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell가 Attach된 Grid를 가져옵니다.
		/// </summary>
		public virtual XGrid Grid
		{
			get{return grid;}
		}
		/// <summary>
		/// CellType, Mask등에 따른 Paint시 보여줄 Display object를 가져옵니다.
		/// </summary>
		public virtual string CellDisplayText
		{
			get 
			{
				string dispText = "";
				string keyName = "";
				//Computed 컬럼은 ComputedKind에 따라 다르게 설정
				if (this.Personality == XCellPersonality.Compute)
				{
					dispText = Value.ToString();
					//DesignMode에서는 Expression을 그대로 보여줌
					if (this.IsDesignMode) return dispText;

					XGridComputedCell compInfo = Grid.ComputedCellInfos[this.Tag];
					if (compInfo != null)
					{
						switch (compInfo.ComputedKind)
						{
							case XGridComputedKind.Average:
							case XGridComputedKind.Count:
							case XGridComputedKind.DistinctCount:
							case XGridComputedKind.Sum:
								//Decimal형으로 설정
								dispText = MaskHelper.GetDisplayText(MaskType.Decimal, compInfo.MaskSymbols, compInfo.DecimalDigits, false ,dispText);
								break;
							case XGridComputedKind.Max:
							case XGridComputedKind.Min:
								//Computed컬럼으로 설정된 컬럼의 정보에 따라 설정
								keyName = XGridUtility.GetKeyNameByExpression(compInfo.ComputedKind, compInfo.Expression);
								XGridCell cellInfo = Grid.CellInfoList[keyName] as XGridCell;
								if (cellInfo != null)
									Grid.GetDisplayTextByInfo(cellInfo, this.Value);
								break;
						}
					}
				}
				else if (this.Personality == XCellPersonality.Content)
				{
					// DisplayText는 Format에 따라 다르게 주어야함, CellInfo의 CellDataType에 따라
					XGridCell info = Grid.CellInfoList[this.cellName] as XGridCell;
					if (info == null)  return Value.ToString();
					if (info.SuppressRepeating)
					{
						//2004.12.15 Repeating Check는 한 컬럼단위로 하지 않고, SupressRepeating이
						//지정된 모든 컬럼의 값을 비교하여 처리함.
						if (Grid.IsRepeatingValue(this.row))
							dispText = "";
						else
							dispText = this.displayText;
					}
					else
					{
						dispText = this.displayText;
					}
				}
				else  //ColHeader, RowHeader, GroupBand,Footer은 Value그래로 SET
					dispText = Value.ToString();

				return dispText;
			}
		}

		/// <summary>
		/// Cell의 값을 가져오거나 설정합니다.
		/// </summary>
		public virtual object Value
		{
			get{return cellValue;}
			set
			{
				if (cellValue != value)
				{
					cellValue = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 Absolute Rectangle을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public Rectangle AbsoluteRectangle
		{
			get
			{
				if (this.grid != null)
					return this.grid.GetCellAbsoluteRectangle(this.row,this.col,this.rowSpan,this.colSpan);
				else
					return new Rectangle(0,0,0,0);
			}
		}
		/// <summary>
		/// Cell의 Display 영역에 기초한 Display Rectangle을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public Rectangle DisplayRectangle
		{
			get
			{
				if (this.grid != null)
					return this.grid.GetCellDisplayRectangle(this.row,this.col,this.rowSpan,this.colSpan);
				else
					return new Rectangle(0,0,0,0);
			}
		}
		/// <summary>
		/// Cell의 Focus를 가지고 있는지 여부를 가져옵니다.
		/// </summary>
		public bool Focused
		{
			get{return focused;}
		}
		/// <summary>
		/// Cell의 Selected 상태인지 여부를 가져오거나 설정합니다.
		/// </summary>
		public bool Select
		{
			get{return select;}
			set
			{
				if (select != value)
				{
					select = value;
					OnSelectionChange(EventArgs.Empty);
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 Text 정렬방식(ContentAlignment)을 가져오거나 설정합니다.
		/// </summary>
		public ContentAlignment TextAlignment
		{
			get{	return textAlignment;}
			set
			{
				if (textAlignment != value)
				{
					textAlignment = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 Focus시 Border를 가져오거나 설정합니다.
		/// </summary>
		internal XCellBorder FocusBorder
		{
			get{return focusBorder;}
			set{ focusBorder = value;}
		}
		/// <summary>
		/// Cell이 Focus나 Select상태가 아닐때 Border를 가져오거나 설정합니다.
		/// </summary>
		internal XCellBorder NormalBorder
		{
			get{return normalBorder;}
			set{ normalBorder = value;}
		}
		/// <summary>
		/// Cell이 추가된 Header인지 여부를 가져오거나 설정합니다.
		/// </summary>
		internal bool IsAddedHeader
		{
			get { return isAddedHeader;}
			set { isAddedHeader = value;}
		}
		/// <summary>
		/// Cell의 ToolTipText를 가져오거나 설정합니다.
		/// </summary>
		public virtual string ToolTipText
		{
			get { return toolTipText;}
			set { toolTipText = value;}
		}
		/// <summary>
		/// Cell의 Image를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(null)]
		public Image Image
		{
			get { return image;}
			set 
			{ 
				if (image != value)
				{
					image = value;
					//ImageFormat이 BMP이면 TransParent 지정
					if (image != null)
					{
						try
						{
							Bitmap bmp = (Bitmap) image;
							bmp.MakeTransparent();
							image = bmp;
						}
						catch{}
					}
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell Image의 Alignmemt를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(ContentAlignment.MiddleLeft)]
		public ContentAlignment ImageAlignment
		{
			get { return imageAlignment;}
			set 
			{ 
				if (imageAlignment != value)
				{
					imageAlignment = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell Image의 Alignmemt를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(false)]
		public bool ImageStretch
		{
			get { return imageStretch;}
			set 
			{ 
				if (imageStretch != value)
				{
					imageStretch = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 SortImage를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(null)]
		internal Image SortImage
		{
			get { return sortImage;}
			set 
			{ 
				if (sortImage != value)
				{
					sortImage = value;
					//ImageFormat이 BMP이면 TransParent 지정
					if (sortImage != null)
					{
						try
						{
							Bitmap bmp = (Bitmap) sortImage;
							Color color = bmp.GetPixel(0,0);
							bmp.MakeTransparent(color);
							sortImage = bmp;
						}
						catch{}
					}
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 Text영역을 Image의 위치에 맞추어 조정할 것인지 여부를 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(true)]
		internal bool ChangeTextRegionByImageRegion
		{
			get { return changeTextRegionByImageRegion;}
			set 
			{ 
				if (changeTextRegionByImageRegion != value)
				{
					changeTextRegionByImageRegion = value;
					InvokeInvalidate();
				}
			}
		}
		/// <summary>
		/// Cell의 기타필요정보를 관리하는 object입니다.
		/// </summary>
		public object Tag
		{
			get { return tag;}
			set { tag = value;}
		}
		#endregion

		#region Internal Properties
		internal bool IsButtonShape
		{
			get { return isButtonShape;}
			set 
			{ 
				if (isButtonShape != value)
				{
					isButtonShape = value;
					InvokeInvalidate();
				}
			}
		}
		internal XButtonSchemes ButtonSheme
		{
			get { return buttonScheme;}
			set 
			{
				if (buttonScheme != value)
				{
					buttonScheme = value;
					InvokeInvalidate();
				}
			}
		}
		internal bool ButtonDisabled
		{
			get { return buttonDisabled;}
			set 
			{
				if (buttonDisabled != value)
				{
					buttonDisabled = value;
					InvokeInvalidate();
				}
			}
		}
		internal int RowNumber
		{
			get { return rowNumber;}
			set { rowNumber = value;}
		}
		#endregion

		#region 생성자
		/// <summary>
		/// Cell 생성자
		/// </summary>
		public XCell():this(null)
		{
		}
		/// <summary>
		/// Cell 생성자
		/// </summary>
		/// <param name="cellValue"> Cell의 값 </param>
		public XCell(object cellValue):this(string.Empty, cellValue)
		{
		}
		/// <summary>
		/// Cell 생성자 
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		public XCell(string cellName, object cellValue):this(cellName, cellValue, "")
		{
		}
		/// <summary>
		/// Cell 생성자 
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		/// <param name="displayText"> Cell의 DisplayText </param>
		public XCell(string cellName, object cellValue, string displayText)
		{
			this.cellName	= cellName;
			this.cellValue	= cellValue;
			this.displayText = displayText;
		}
		#endregion

		#region Internal Methods
		/// <summary>
		/// Grid에 Cell을 Binding합니다.
		/// </summary>
		/// <param name="grid"> XGrid </param>
		/// <param name="row"> Row의 값 </param>
		/// <param name="col"> Col의 값 </param>
		internal void BindToGrid(XGrid grid, int row, int col)
		{
			this.grid = grid;
			this.row = row;
			this.col = col;
		}
		/// <summary>
		/// Grid에서 Cell을 UnBind합니다.
		/// </summary>
		internal void UnBindToGrid()
		{
			this.grid = null;
			this.row = -1;
			this.col = -1;
		}
		/// <summary>
		/// Cell을 Display하는데 필요한 Size를 가져옵니다.
		/// </summary>
		/// <param name="g"> Graphics 객체 </param>
		/// <returns> Display에 필요한 Size </returns>
		internal Size GetRequiredSize(Graphics g)
		{
			SizeF l_fontSize;
			string text = this.CellDisplayText;
			if (text != "")
				l_fontSize = g.MeasureString(text,this.font);
			else
				l_fontSize = new SizeF(2,2);

			l_fontSize.Width += NormalBorder.Width * 2 + 2; //2 pixel 
			l_fontSize.Height += 8.3f; //FontSize에서 Margin 적용
			return l_fontSize.ToSize();
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Cell에 Focus를 설정합니다.
		/// </summary>
		/// <returns> Focus 상태가 되면 true, 아니면 false </returns>
		public virtual bool Focus()
		{
			return this.Focus(true);
		}

		/// <summary>
		/// Cell에 Focus를 설정합니다.
		/// </summary>
		/// <param name="checkGridFocus"> Grid에 Focus가 있을 경우에만 Focus를 줄지여부 </param>
		/// <returns> Focus 상태가 되면 true, 아니면 false </returns>
		public virtual bool Focus(bool checkGridFocus)
		{
			// checkGridFocus 이면 Grid가 Focus를 가지지 않으면 Cell도 Focus 가질수 없음
			if ((this.grid != null) && checkGridFocus)
				if (!this.grid.ContainsFocus)	return false;

			if ((Focused==false) && (this.grid != null))
			{
				this.focused = true;
				// 다시 한번 더 Check
				if (this.grid != null && this.grid.FocusCell != null)
				{
					if (this.grid.FocusCell.LeaveFocus())
					{
						OnFocusChange(EventArgs.Empty);
						InvokeInvalidate();
					}
					else
						this.focused = false;
				}
				else
				{
					OnFocusChange(EventArgs.Empty);
					InvokeInvalidate();
				}
			}
			//Content Cell이 아니면 Focus 관리하지 않음
			if(this.Personality != XCellPersonality.Content)
				this.focused = false;
			
			return this.focused;
		}
		
		/// <summary>
		/// Cell의 Focus를 제거합니다.
		/// </summary>
		/// <returns>성공시 true, 실패시 false </returns>
		public virtual bool LeaveFocus()
		{
			if (Focused == true)
			{
				// Grid가 에러상태이면 Focus 해제불가
				if ((this.grid != null) && (this.grid.HasError)) return false;

				//Focus해제
				this.focused = false;
				InvokeInvalidate();
			}
			return !this.focused;
		}
		/// <summary>
		/// Cell이 display영역에 있는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="displayRectangle"> Rectangle </param>
		/// <returns> Display영역에 있으면 True, 아니면 False </returns>
		public virtual bool IsInDisplayRegion(Rectangle displayRectangle)
		{
			Rectangle l_rc = this.DisplayRectangle;
			return l_rc.IntersectsWith(displayRectangle);
		}
		/// <summary>
		/// Cell이 Absolute 영역에 있는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="absoluteRectangle"> Rectangle </param>
		/// <returns> Absolute 영역에 있으면 true, 아니면 false </returns>
		public virtual bool IsInAbsoluteRegion(Rectangle absoluteRectangle)
		{
			Rectangle l_rc = AbsoluteRectangle;
			return l_rc.IntersectsWith(absoluteRectangle);
		}
		#endregion

		#region Public Event
		/// <summary>
		/// 마우스 단추를 클릭하면 발생하는 Event입니다.
		/// </summary>
		public event MouseEventHandler MouseDown;
		/// <summary>
		/// 마우스 단추를 눌렀다 놓으면 발생하는 Event입니다.
		/// </summary>
		public event MouseEventHandler MouseUp;
		/// <summary>
		/// 마우스 포인터를 컨트롤 위로 이동하면 발생하는 Event입니다.
		/// </summary>
		public event MouseEventHandler MouseMove;
		/// <summary>
		/// 마우스 포인터가 컨트롤에 들어가면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler MouseEnter;
		/// <summary>
		/// 마우스 포인터가 컨트롤을 벗어나면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler MouseLeave;
		/// <summary>
		/// 컨트롤에 포커스가 있을 때 키를 누르면 발생하는 Event입니다.
		/// </summary>
		public event KeyPressEventHandler KeyPress;
		/// <summary>
		/// 컨트롤에 포커스가 있을 때 키를 누르면 발생하는 Event입니다.
		/// </summary>
		public event KeyEventHandler KeyDown;
		/// <summary>
		/// 컨트롤에 포커스가 있을 때 키를 눌렀다 놓으면 발생하는 Event입니다.
		/// </summary>
		public event KeyEventHandler KeyUp;
		/// <summary>
		/// 컨트롤을 클릭하면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler Click;
		/// <summary>
		/// 컨트롤을 더블클릭하면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler DoubleClick;
		/// <summary>
		/// Select상태가 변경되면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler SelectionChange;
		/// <summary>
		/// Focus상태가 변경되면 발생하는 Event입니다.
		/// </summary>
		public event EventHandler FocusChange;
		/// <summary>
		/// 컨트롤 표시를 다시 그릴 필요가 있으면 발생하는 Event입니다.
		/// </summary>
		public event InvalidateEventHandler Invalidated;
		#endregion

		#region Event Raise Method
		/// <summary>
		/// Cell을 다시 그립니다.(InValidated Event를 발생시킵니다.)
		/// </summary>
		internal virtual void InvokeInvalidate()
		{
			if (this.grid != null)
				OnInvalidated(new InvalidateEventArgs(DisplayRectangle));
		}

		/// <summary>
		/// Cell을 그립니다.
		/// </summary>
		/// <param name="e"> PaintEventArgs </param>
		/// <param name="absoluteRectangle"> Absolute Rectangle </param>
		/// <param name="chekIfIsRegion"> 절대영역 Check 여부 </param>
		/// <param name="rowState"> Cell의 Row의 DataRowState Enum </param>
		internal void InvokePaint(PaintEventArgs e, Rectangle absoluteRectangle, bool chekIfIsRegion, DataRowState rowState)
		{
			if (this.grid==null)
				return;
			
			// FixedRows, FixedCols영역은 절대영역에 관계없이 그리고, NonFixedRows, NonFixedCols영역은
			// 절대영역밖이면 그리지 않음
			if (chekIfIsRegion == false || IsInAbsoluteRegion(absoluteRectangle))
			{
				// DisplayRect의 유효성 검사 (Width > 0, Height > 0)
				Rectangle l_rc = DisplayRectangle;
				Rectangle aRect = AbsoluteRectangle;
				if ((l_rc.Width <= 0) || (l_rc.Height <= 0))	return;

				Graphics g = e.Graphics;

				Region l_OldClip = g.Clip;
				// 그리기 영역은 Cell의 Display Rectangle 영역
				g.Clip = new Region(l_rc);
				
				int l_left = l_rc.X;
				int l_top = l_rc.Y;
				int l_width = l_rc.Width;
				int l_height = l_rc.Height;
								
				//HScroll에 의해 DispRect과 AbsolutRect이 다를때 Bottom이 FixedRowsHeight보다 작으면 그리지 않아도 됨
				if ((l_rc.Bottom != aRect.Bottom) && (l_rc.Bottom < Grid.FixedRowsHeight))
					return;

				//버튼형 Cell은 버튼 Shape을 그리고 성공시 return
				if (this.isButtonShape)
				{
					if (DrawButtonShape(g, l_rc))
					{
						g.Clip = l_OldClip;
						return;
					}
				}
				
				Color	bColor = this.backColor.Color;
				Color	fColor = this.foreColor.Color;
				Font	textFont = this.font;
				Color	gStartColor = this.gradientStart.Color;
				Color	gEndColor	= this.gradientEnd.Color;
				XCellDrawMode cellDrawMode = this.drawMode;
				Image	cellImage = this.image;
				bool	drawMiddleLine = false;
				Color	middleLineColor = Color.Black;
				bool	callEvent = false; //CellPainting Event Call 여부
				bool	applySelectedBackColorOnPaint = true; //선택상태일때 기본선택배경색 사용여부 (cellInfo의 속성을 참조)
				bool	applySelectedForeColorOnPaint = true; //선택상태일때 기본선택전경색 사용여부 (cellInfo의 속성을 참조)
				//Content Cell 데이타에 따라, Font, BackColor, ForeColor 변경
				if ((this.Personality == XCellPersonality.Content) && !this.isButtonShape)
				{
					if (Grid.ExistGridCellPaintingEvent())
					{
						XGridCell cellInfo = Grid.CellInfoList[this.cellName] as XGridCell;
						//2006.01.10 선택상태일때 기본선택색 사용여부 SET
						applySelectedBackColorOnPaint = cellInfo.ApplySelectedBackColorOnPaint;
						applySelectedForeColorOnPaint = cellInfo.ApplySelectedForeColorOnPaint;
						//Grid의 ApplyPaintEventToAllColumn이 true이면 모든 컬럼에 적용
						if (Grid.ApplyPaintEventToAllColumn)
							callEvent = true;
						else if ((cellInfo != null) && cellInfo.ApplyPaintingEvent) //AGridCell의 ApplyCellPainting이 true이면 적용
							callEvent = true;
						if (callEvent)
						{
							DataRow dataRow = Grid.LayoutTable.Rows[this.rowNumber];
							//GridColumnPaintingEventHandler Call
							//개발자가 Event를 Handling하여 색깔,Font 변경 필요시 
							XGridCellPaintEventArgs xe = new XGridCellPaintEventArgs(this.CellName, this.rowNumber, dataRow, textFont, bColor, fColor, gStartColor, gEndColor, cellDrawMode, cellImage);
							Grid.CallGridCellPainting(xe);
							textFont = xe.Font;
							bColor = xe.BackColor;
							fColor = xe.ForeColor;
							gStartColor = xe.GradientStartColor;
							gEndColor	= xe.GradientEndColor;
							cellDrawMode = xe.DrawMode;
							cellImage = xe.Image;
							drawMiddleLine = xe.DrawMiddleLine;
							middleLineColor = xe.MiddleLineColor;
						}
					}
				}
				//normal cell (Not Selected Cell OR Focused Cell)
				if (!Select || Focused)
				{
					Brush br;
					if ((cellDrawMode == XCellDrawMode.Flat) ||(cellDrawMode == XCellDrawMode.Raised3D)||(cellDrawMode == XCellDrawMode.Sunken3D))
					{
						br = new SolidBrush(bColor);

						g.FillRectangle(br,l_rc);
						//3D Style은 Border 그리기
						if (cellDrawMode == XCellDrawMode.Raised3D)
							ControlPaint.DrawBorder(g, l_rc,Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
								Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
								Color.Silver,2,ButtonBorderStyle.Outset,
								Color.Silver,2,ButtonBorderStyle.Outset);
						else if (cellDrawMode == XCellDrawMode.Sunken3D)
							ControlPaint.DrawBorder(g, l_rc,Color.Silver,2,ButtonBorderStyle.Inset,
								Color.Silver,2,ButtonBorderStyle.Inset,
								Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
								Color.WhiteSmoke,1,ButtonBorderStyle.Solid);
						br.Dispose();

					}
					else  //Gradient
					{
						br = new LinearGradientBrush(l_rc, gStartColor, gEndColor, 
							(LinearGradientMode) Enum.Parse(typeof(LinearGradientMode), cellDrawMode.ToString())); 
						g.FillRectangle(br,l_rc);
						br.Dispose();
					}
						
					

					//Focus시 FocusBorder Draw
					if (Focused)
					{
						using (Pen p = new Pen(FocusBorder.Color,FocusBorder.Width))
						{
							XGridUtility.DrawRectangleWithExternBound(g,p,l_rc);
						}
					}
				}
				else if (Select) //Selected
				{
					//2006.01.10 선택배경색 적용여부에 컬럼정보의 applySelectedBackColorOnPaint 사용여부 판단추가
					//2005.12.29 CellPaint Event Call시에 BackColor가 Cell의 기본BackColor와 다르면 bColor 적용
					if (applySelectedBackColorOnPaint||!callEvent || bColor.Equals(this.backColor.Color))
						bColor = this.SelectedBackColor.Color;  //BackColor변경이 없으면 선택영역 Color 적용

					using (SolidBrush br = new SolidBrush(bColor))
					{
						g.FillRectangle(br,l_rc);
					}
				}
					
				float margin = NormalBorder.Width;
				Pen l_CurrentPen = new Pen(NormalBorder.Color, margin);
				Pen l_HeaderPen = new Pen(Color.WhiteSmoke , margin);
				
				//Top (Header만 Top, Left그림)
				//Grid의 DrawCellLines가 true이면 Border Line 그림
				// 2006.07.25 DrawCellLines를 2개로 불리 (IsDrawRowVerticalLine(열구분Line), IsDrawRowHorizontalLine(행구분Line)
				// Header는 모두 그리고, Cell만 위 속성에 맞추어 그린다.
				//Header Border Draw
				if ((this.Personality == XCellPersonality.ColHeader) || (this.Personality == XCellPersonality.RowHeader))
				{
					//Top
					g.DrawLine(l_HeaderPen, l_left, l_top, l_left + l_width - margin, l_top);
					//Left
					g.DrawLine(l_HeaderPen, l_left, l_top, l_left, l_top + l_height);

				}
				else //Contents, Computed cell
				{
					if (grid.IsDrawRowVerticalLine)
					{
						//Right
						g.DrawLine(l_CurrentPen, l_left + l_width - margin, l_top, l_left + l_width - margin, l_top + l_height);
					}
					if (grid.IsDrawRowHorizontalLine)
					{
						//Bottom
						if (grid.IsDrawRowVerticalLine)  //Vertical Line이 있으면 Line 간 간격을 고려 Left, Right에 Margin 적용함
							g.DrawLine(l_CurrentPen, l_left + margin, l_top + l_height - margin, l_left + l_width - margin, l_top + l_height - margin);
						else  //Vertical이 없으므로 Left, Right Margin 적용하지 않음
							g.DrawLine(l_CurrentPen, l_left, l_top + l_height - margin, l_left + l_width, l_top + l_height - margin);
					}
				}


				l_CurrentPen.Dispose();
				l_HeaderPen.Dispose();
				l_CurrentPen = null;

				RectangleF drawRect = l_rc;
				drawRect.X += margin;
				drawRect.Y += margin;
				//Rect Valid Check
				drawRect.Width  = Math.Max(0, drawRect.Width - margin*2);
				drawRect.Height = Math.Max(0, drawRect.Height - margin*2);
				if ((drawRect.Width <= 0) || (drawRect.Height <= 0))
				{
					g.Clip = l_OldClip;
					return;
				}


				//SortImage Draw (우측에 SET)
				if (this.sortImage != null)
				{
					PointF ptSortImage = DrawHelper.GetObjAlignment(ContentAlignment.MiddleRight,(int) drawRect.Left, (int) drawRect.Top, (int) drawRect.Width, (int) drawRect.Height, sortImage.Width, sortImage.Height);
					RectangleF sortImageRect = drawRect;
					sortImageRect.Intersect(new RectangleF(ptSortImage, sortImage.PhysicalDimension));
					//Truncate the Rectangle for appreximation problem
					g.DrawImage(sortImage ,Rectangle.Truncate(sortImageRect));
				}
				//Image Draw
				if (cellImage != null)
				{
					// 전체영역에 Image Draw
					if (imageStretch)
					{
						g.DrawImage(cellImage, drawRect);
					}
						// Alignment에 따라 Image Size에 따라 SET
					else
					{
						PointF pointImage = DrawHelper.GetObjAlignment(imageAlignment,(int) drawRect.Left, (int) drawRect.Top, (int) drawRect.Width, (int) drawRect.Height, cellImage.Width, cellImage.Height);
						RectangleF imageRect = drawRect;
						imageRect.Intersect(new RectangleF(pointImage, cellImage.PhysicalDimension));
						//Truncate the Rectangle for appreximation problem
						g.DrawImage(cellImage,Rectangle.Truncate(imageRect));
					}
				}
				string dispText = this.CellDisplayText;
				//Text Draw
				if ((dispText.Length > 0) && (l_width > 2) && (l_height > 2))
				{
					RectangleF textRect = drawRect;
					//Align Text To Image (Image가 있으면 Image Size에 맞추어 Text Size 조정)
					if ((cellImage != null) && !imageStretch && changeTextRegionByImageRegion)
					{
						//imageAlignment가 Left이면 X이동 Width 감소, Right이면 Width감소
						if (XGridUtility.IsLeft(imageAlignment))
						{
							textRect.X += cellImage.Width;
							textRect.Width = Math.Max(0, textRect.Width - cellImage.Width);
						}
						else if (XGridUtility.IsRight(imageAlignment))
						{
							textRect.Width = Math.Max(0, textRect.Width - cellImage.Width);
						}
					}

					//Rect Validation Check
					if ((textRect.Width <= 0) || (textRect.Height <= 0))
					{
						g.Clip = l_OldClip;
						return;
					}

					SizeF l_fontSize = DrawHelper.MeasureString(g, dispText, textFont, this.textAlignment);
									
					Color l_FontColor;
									
					if ( this.Personality == XCellPersonality.Content)
					{
						//this.grid의 RowStateCheckOnPaint이면 DataRowState에 따라 ForeColor 색깔 변경
						if (this.grid.RowStateCheckOnPaint)
						{
							//2005.12.29 CellPaint Event Call시에 ForeColor가 Cell의 기본ForeColor와 다르면 fColor 적용
							if (callEvent && !fColor.Equals(this.foreColor.Color))
								l_FontColor = fColor;
							else if (rowState == DataRowState.Added)
								l_FontColor = insertedTextColor.Color;
							else if (rowState == DataRowState.Modified)
								l_FontColor = updatedTextColor.Color;
							else  // UnChanged
							{
								l_FontColor = fColor;
							}

						}
						else
						{
							l_FontColor = fColor;
						}
					}
					else
					{
						l_FontColor = fColor;
					}

					//Draw string (Selected상태이면 SelectedText Color)
					if (Select && !Focused) 
					{
						//2006.01.10 선택전경색 적용여부에 컬럼정보의 applySelectedBackColorOnPaint 사용여부 판단추가
						//2005.12.29 CellPaint Event Call시에 ForeColor가 Cell의 기본ForeColor와 다르면 fColor 적용
						if (applySelectedForeColorOnPaint||!callEvent || fColor.Equals(this.foreColor.Color))
							l_FontColor = this.selectedForeColor.Color;
					}
					
					using (SolidBrush br = new SolidBrush(l_FontColor))
					{
						g.DrawString(dispText,
							textFont,
							br,
							DrawHelper.GetObjAlignment(this.textAlignment,(int) textRect.Left,(int) textRect.Top, (int) textRect.Width, (int) textRect.Height,l_fontSize.Width,l_fontSize.Height));
					}
				}
				//2005.11.28 DrawMiddleLine 반영 (중간에 지정한 색으로 Line Draw)
				if (drawMiddleLine)
				{
					using (Pen linePen = new Pen(middleLineColor))
						g.DrawLine(linePen, new Point(l_rc.X, l_rc.Y + l_rc.Height/2), new Point(l_rc.Right,l_rc.Y + l_rc.Height/2)); 
				}
				//Region 반환
				g.Clip = l_OldClip;
			}
		}
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		internal void InvokeMouseDown(MouseEventArgs e)
		{
			if (MouseDown != null)
				MouseDown(this,e);
		}
		/// <summary>
		/// MouseUp Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		internal void InvokeMouseUp(MouseEventArgs e)
		{
			if (MouseUp != null)
				MouseUp(this,e);
		}
		/// <summary>
		/// MouseMove Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		internal void InvokeMouseMove(MouseEventArgs e)
		{
			if (MouseMove != null)
				MouseMove(this,e);
		}
		/// <summary>
		/// MouseEnter Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		internal void InvokeMouseEnter(EventArgs e)
		{
			// ToolTipText SET
			ApplyToolTipText();

			//버튼형Cell의 경우 MouseOver상태 Flag 설정
            //Disable tooltiptext when tooltiptext = " "
            if (Grid.GridToolTipText == " ")
            {
                Grid.ToolTipActive = false;
            }
            else
            {
                Grid.ToolTipActive = true;
            }
            if (this.isButtonShape)
            {
                this.buttonMouseOver = true;
                this.InvokeInvalidate();
            }

			if (MouseEnter!=null)
				MouseEnter(this,e);
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		internal void InvokeMouseLeave(EventArgs e)
		{
			// ResetToolTipText
			ResetToolTipText();
			
			//버튼형Cell의 경우 MouseOver상태 Clear
			if (this.isButtonShape)
			{
				this.buttonMouseOver = false;
				this.InvokeInvalidate();
			}

			if (MouseLeave!=null)
				MouseLeave(this,e);
		}
		/// <summary>
		/// KeyUp Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> KeyEventArgs </param>
		internal void InvokeKeyUp ( KeyEventArgs e)
		{
			if (KeyUp!=null)
				KeyUp(this,e);
		}
		/// <summary>
		/// KeyPress Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		internal void InvokeKeyPress ( KeyPressEventArgs e)
		{
			if (KeyPress!=null)
				KeyPress(this,e);
		}
		/// <summary>
		/// KeyDown Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> KeyEventArgs </param>
		internal void InvokeKeyDown ( KeyEventArgs e)
		{
			if (KeyDown!=null)
				KeyDown(this,e);
		
		}
		/// <summary>
		/// DoubleClick Event를 발생시킵니다.
		/// </summary>
		internal void InvokeDoubleClick ()
		{
			if (DoubleClick!=null)
				DoubleClick(this,EventArgs.Empty);
		}
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// </summary>
		internal void InvokeClick ()
		{
			if (Click!=null)
				Click(this,EventArgs.Empty);
		}
		#endregion
		
		#region Select, Focus, Invalidate Event Invoker
		/// <summary>
		/// SelectionChange Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected void OnSelectionChange(EventArgs e)
		{
			if (SelectionChange!=null)
				SelectionChange(this,e);
		}
		/// <summary>
		/// FocusChange Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected virtual void OnFocusChange(EventArgs e)
		{
			if (FocusChange != null)
				FocusChange(this,e);
		}
		/// <summary>
		/// Invalidated Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> InvalidateEventArgs </param>
		protected virtual void OnInvalidated(InvalidateEventArgs e)
		{
			if (Invalidated!= null)
				Invalidated(this,e);
		}
		#endregion

		#region ToolTipText 관련
		/// <summary>
		/// ToolTipText를 반영합니다.
		/// </summary>
		protected virtual void ApplyToolTipText()
		{
			// Cell에 Setting된 ToolTipText가 없으면 Value SET
			try
			{
				oldToolTipText = Grid.GridToolTipText;
				if (ToolTipText.Length > 0)
					Grid.GridToolTipText = ToolTipText;
				else
					Grid.GridToolTipText = this.Value.ToString();
			}
			catch{}
		}
		/// <summary>
		/// ToolTipText를 Reset합니다.
		/// </summary>
		protected virtual void ResetToolTipText()
		{
			try
			{
				Grid.GridToolTipText = oldToolTipText;
				oldToolTipText = string.Empty;
			}
			catch{}
		}
		#endregion

		#region Button모양 그리기
		private bool DrawButtonShape(Graphics g, Rectangle drawRect)
		{
			StringFormat textFormat  = new StringFormat();
			textFormat.HotkeyPrefix  = HotkeyPrefix.Show;
			textFormat.Trimming = StringTrimming.EllipsisWord;

			int L = drawRect.X;
			int T = drawRect.Y;
			int X = L + drawRect.Width;
			int Y = T + drawRect.Height;
			
			// Size가 최초 Size미만 이면 그리지 않음
			if ((X < 10) || (Y < 10)) return false;

			g.CompositingQuality = CompositingQuality.GammaCorrected;

			PointF textPoint = PointF.Empty;
			Rectangle imageRect = Rectangle.Empty;
			Rectangle textRect = drawRect;
			//Image가 있으면 Default Margin을 줌
			if (this.image != null)
			{
				textRect.X += 5;
				textRect.Width -= 5;
			}
			textRect.Y += 1;
			textRect.Height -= 1;
			if (this.image != null)
			{
				//ImagePadding 적용
				PointF pointImage = DrawHelper.GetObjAlignment(this.imageAlignment,textRect.Left, textRect.Top, textRect.Width, textRect.Height, Image.Width, Image.Height);
				RectangleF iRectF = textRect;
				iRectF.Intersect(new RectangleF(pointImage, Image.PhysicalDimension));
				imageRect = Rectangle.Truncate(iRectF);
				//imageAlignment가 Left이면 X이동 Width 감소, Right이면 Width감소
				if (DrawHelper.IsLeft(this.imageAlignment))
				{
					textRect.X += Image.Width;
					textRect.Width -= Image.Width;
				}
				else if (DrawHelper.IsRight(this.imageAlignment))
				{
					textRect.Width -= Image.Width;
				}
			}
			//TextPoint 계산
			Size textSize = DrawHelper.GetTextSize(g, this.displayText, this.font, textRect.Width);
			textPoint = DrawHelper.GetObjAlignment(this.textAlignment, textRect.Left, textRect.Top, textRect.Width, textRect.Height, textSize.Width, textSize.Height);
			
			//버튼 비활성화시 비활성 모양 Draw후 Return
			if (this.buttonDisabled)
			{
				SolidBrush				_brush01, _brush;
				Pen						_pen01, _pen02;
				_brush = new SolidBrush(Color.FromArgb(64, 201, 199, 186));
				_brush01 = new SolidBrush(Color.FromArgb(245, 244, 234));
				_pen01 = new Pen(Color.FromArgb(201, 199, 186));
				_pen02 = new Pen(Color.FromArgb(170, 201, 199, 186));
				try
				{
					g.FillRectangle(_brush01, L + 2, T + 2, X-4, Y-4);
					g.DrawLine(_pen01, L + 3, T + 1, X-4, T + 1);
					g.DrawLine(_pen01, L + 3, Y-2, X-4, Y-2);
					g.DrawLine(_pen01, L + 1, T + 3, L + 1, Y-4);
					g.DrawLine(_pen01, X-2, T + 3, X-2, Y-4);

					g.DrawLine(_pen02, L + 1, T + 2, L + 2, T + 1);
					g.DrawLine(_pen02, L + 1, Y-3, L + 2, Y-2);
					g.DrawLine(_pen02, X-2, T + 2, X-3, T + 1);
					g.DrawLine(_pen02, X-2, Y-3, X-3, Y-2);
					//g.FillRectangles(_brush, rects1);

					if (image != null) 
						ControlPaint.DrawImageDisabled(g, image, imageRect.X, imageRect.Y, this.backColor.Color);
					if (this.displayText != "")
						g.DrawString(this.displayText, this.Font, SystemBrushes.ControlDark, textPoint, textFormat);

					_brush.Dispose();
					_brush01.Dispose();
					_pen01.Dispose();
					_pen02.Dispose();
				}
				catch{}
				return true;
			}

			//Selected, MouseOver는 동일
			pen06 = new Pen(Color.FromArgb(206, 231, 255));
			pen07 = new Pen(Color.FromArgb(188, 212, 246));
			pen08 = new Pen(Color.FromArgb(137, 173, 228));
			pen09 = new Pen(Color.FromArgb(105, 130, 238));

			//Mouse Over
			brush03 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
				, Color.FromArgb(253, 216, 137), Color.FromArgb(248, 178, 48), 90.0f);
			pen10 = new Pen(Color.FromArgb(255, 240, 207));
			pen11 = new Pen(Color.FromArgb(253, 216, 137));
			pen12 = new Pen(Color.FromArgb(248, 178, 48));
			pen13 = new Pen(Color.FromArgb(229, 151, 0));

			switch (buttonScheme)
			{
				case XButtonSchemes.OliveGreen:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(254, 251, 250), Color.FromArgb(249, 243, 229), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(249, 243, 229));
					pen02 = new Pen(Color.FromArgb(242, 225, 208));
					pen03 = new Pen(Color.FromArgb(230, 209, 184));

					pen04 = new Pen(Color.FromArgb(242, 225, 208));
					pen05 = new Pen(Color.FromArgb(230, 209, 184));
					
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(142, 123, 117));
					pen1 = new Pen(Color.FromArgb(142, 123, 117));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;

				case XButtonSchemes.Silver:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(250, 252, 254), Color.FromArgb(228, 232, 248), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(228, 232, 248));
					pen02 = new Pen(Color.FromArgb(206, 213, 238));
					pen03 = new Pen(Color.FromArgb(182, 187, 224));

					pen04 = new Pen(Color.FromArgb(206, 213, 238));
					pen05 = new Pen(Color.FromArgb(182, 187, 224));
					
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(113, 121, 149));
					pen1 = new Pen(Color.FromArgb(113, 121, 149));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;

				case XButtonSchemes.Green:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(252, 254, 250), Color.FromArgb(232, 247, 227), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(232, 247, 227));
					pen02 = new Pen(Color.FromArgb(217, 238, 206));
					pen03 = new Pen(Color.FromArgb(191, 224, 180));

					pen04 = new Pen(Color.FromArgb(217, 238, 206));
					pen05 = new Pen(Color.FromArgb(191, 224, 180));
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(117, 141, 137));
					pen1 = new Pen(Color.FromArgb(117, 141, 137));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;
				
				case XButtonSchemes.HotPink:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(253, 250, 253), Color.FromArgb(247, 233, 243), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(247, 233, 243));
					pen02 = new Pen(Color.FromArgb(236, 212, 231));
					pen03 = new Pen(Color.FromArgb(224, 192, 214));

					pen04 = new Pen(Color.FromArgb(236, 212, 231));
					pen05 = new Pen(Color.FromArgb(224, 192, 214));
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(147, 120, 142));
					pen1 = new Pen(Color.FromArgb(147, 120, 142));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;
				case XButtonSchemes.SkyBlue:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(249, 253, 251), Color.FromArgb(223, 244, 239), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);

					pen01 = new Pen(Color.FromArgb(223, 244, 239));
					pen02 = new Pen(Color.FromArgb(196, 228, 221));
					pen03 = new Pen(Color.FromArgb(169, 213, 209));

					pen04 = new Pen(Color.FromArgb(196, 228, 221));
					pen05 = new Pen(Color.FromArgb(169, 213, 209));
					//Border
					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(93, 136, 139));
					pen1 = new Pen(Color.FromArgb(93, 136, 139));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;
				default:
					brush01 = new LinearGradientBrush(new Rectangle(2, 2, X-5, Y-7)
						, Color.FromArgb(255, 255, 255), Color.FromArgb(240, 244, 255), 90.0f);
					brush02 = new LinearGradientBrush(new Rectangle(2, 3, X-4, Y-8)
						, Color.FromArgb(186, 211, 245), Color.FromArgb(137,173 , 228), 90.0f);
					
					pen01 = new Pen(Color.FromArgb(228, 237, 240));
					pen02 = new Pen(Color.FromArgb(216, 226, 230));
					pen03 = new Pen(Color.FromArgb(195, 210, 216));

					pen04 = new Pen(Color.FromArgb(216, 226, 230));
					pen05 = new Pen(Color.FromArgb(195, 210, 216));

					brush1 = new SolidBrush(Color.FromArgb(92, 85, 125, 162));
					pen0 = new Pen(Color.FromArgb(116, 143, 139));
					pen1 = new Pen(Color.FromArgb(116, 143, 139));
					pen2 = new Pen(Color.FromArgb(192, 193, 210, 253));
					break;				
			}
			
			try
			{
				LinearGradientBrush brush0 = new LinearGradientBrush(new Rectangle(L + 0, T + 0, X, Y)
					, Color.FromArgb(64, 171, 168, 137), Color.FromArgb(92, 255, 255, 255), 85.0f);
				g.FillRectangle(brush0, new Rectangle(L + 0, T + 0, X, Y));
				brush0.Dispose();
			}
			catch{}
			
			try
			{
				if (this.buttonMouseOver)
				{
					Rectangle[] rects0 = new Rectangle[2];
					rects0[0] = new Rectangle(L + 2, T + 4, 2, Y-8);
					rects0[1] = new Rectangle(X-4, T + 4, 2, Y-8);

					g.FillRectangle(brush01, L + 2, T + 2, X-4, Y-7);
					g.DrawLine(pen01, L + 2, Y-5, X-2, Y-5);
					g.DrawLine(pen02, L + 2, Y-4, X-2, Y-4);
					g.DrawLine(pen03, L + 2, Y-3, X-2, Y-3);
					g.DrawLine(pen04, X-4, T + 4, X-4, Y-5);
					g.DrawLine(pen05, X-3, T + 4, X-3, Y-5);
					
					//Draw MouseHover Line
					g.FillRectangles(brush03, rects0);
					g.DrawLine(pen10, L + 2, T + 2, X-3, T + 2);
					g.DrawLine(pen11, L + 2, T + 3, X-3, T + 3);
					g.DrawLine(pen12, L + 2, Y-4, X-3, Y-4);
					g.DrawLine(pen13, L + 2, Y-3, X-3, Y-3);
				}
				else
				{
					g.FillRectangle(brush01, L + 2, T + 2, X-4, Y-7);
					g.DrawLine(pen01, L + 2, Y-5, X-2, Y-5);
					g.DrawLine(pen02, L + 2, Y-4, X-2, Y-4);
					g.DrawLine(pen03, L + 2, Y-3, X-2, Y-3);
					g.DrawLine(pen04, X-4, T + 4, X-4, Y-5);
					g.DrawLine(pen05, X-3, T + 4, X-3, Y-5);
				}
			}
			catch{}

			
			try
			{
				if (image != null)
					g.DrawImage(image, imageRect);
				if (this.displayText != "")
					g.DrawString(this.displayText, this.Font, SystemBrushes.ControlText, textPoint, textFormat);

				
				g.DrawLine(pen1, L + 1, T + 3, L + 3, T + 1);
				g.DrawLine(pen1, X-2, T + 3, X-4, L + 1);
				g.DrawLine(pen1, L + 1, Y-4, L + 3, Y-2);
				g.DrawLine(pen1, X-2, Y-4, X-4, Y-2);

				g.DrawLine(pen2, L + 1, T + 2, L + 2, T + 1);
				g.DrawLine(pen2, L + 1, Y-3, L + 2, Y-2);
				g.DrawLine(pen2, X-2, T + 2, X-3, T + 1);
				g.DrawLine(pen2, X-2, Y-3, X-3, Y-2);						

				g.DrawLine(pen0, L + 3, T + 1, X-4, T + 1);
				g.DrawLine(pen0, L + 3, Y-2, X-4, Y-2);
				g.DrawLine(pen0, L + 1, T + 3, L + 1, Y-4);
				g.DrawLine(pen0, X-2, T + 3, X-2, Y-4);
			}
			catch
			{
				return false;
			}
			return true;
		}
		private void DisposePensBrushes()
		{
			try
			{
				brush1.Dispose();
				pen0.Dispose();
				pen1.Dispose();
				pen2.Dispose();
				brush01.Dispose();
				brush02.Dispose();
				brush03.Dispose();
				pen01.Dispose();
				pen02.Dispose();
				pen03.Dispose();
				pen04.Dispose();
				pen05.Dispose();
				pen06.Dispose();
				pen07.Dispose();
				pen08.Dispose();
				pen09.Dispose();
				pen10.Dispose();
				pen11.Dispose();
				pen12.Dispose();
				pen13.Dispose();
			}
			catch{}
		}
		#endregion
	}
}