using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Data;
using System.Data.OracleClient;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace IHIS.Framework
{
	/// <summary>
	/// XSheet에 대한 요약설명입니다.
	/// </summary>
	[ToolboxItem(true),
	ToolboxBitmap(typeof(IHIS.Framework.XSheet), "Images.XSheet.bmp")]
	public class XSheet : CustomScrollControl
	{
		#region fields without Property
		private System.ComponentModel.IContainer components = null;
		private SheetBackContainer backContainer;
		private System.Windows.Forms.Panel splitPan;
		private int defaultWidth = 80;
		private int defaultHeight = 21; //Font 10고려하여 Default Height
		private const int cMoveDif = 2;
		private const int cResizingMin = 10;  // Resizing시의 최소 높이, 너비
		private XSheetCell resizingCell = null;
		private XSheetCell[] oldMouseSelection = new XSheetCell[0];
		private XSheetPrintDocument printDoc = null;
		private PageSettings pageSettings = new PageSettings();
		/// <summary>
		/// 선택영역 시작 Cell
		/// </summary>
		protected XSheetCell StartMouseSelectionCell = null;
		/// <summary>
		/// 선택영역 종료 Cell
		/// </summary>
		protected XSheetCell EndMouseSelectionCell = null;
		/// <summary>
		/// Array of cells(Cell[,])
		/// </summary>
		protected XSheetCell[,] Cells = null;
		/// <summary>
		/// MouseDown한 Cell입니다.
		/// </summary>
		protected XSheetCell MouseDownCell = null;
		/// <summary>
		/// Mouse Point에 있는 Cell
		/// </summary>
		protected XSheetCell CellUnderMouse = null;
		private bool gridResized = false;  //Grid가 Resize되었는지 여부
		private int borderWidth = 1;
		private XColor borderColor = XColor.XGridBorderColor;
		#endregion

		#region  Fields having Property
		private XColor backgroundColor = XColor.XGridBackColor;
		private bool enableMultiSelection = false;
		private bool rowResizable = false;
		private bool colResizable = false;
		private int fixedRows = 0;
		private int fixedCols = 0;
		private XSheetStatus sheetStatus = XSheetStatus.Normal;
		protected XSheetCell focusCell = null;  //2006.03.08 focusCell을 EditGrid에서 수정가능하도록 protected로 전환
		private XSheetSelection selection = null;
		private XSheetSelectionMode selectionMode = XSheetSelectionMode.Cell;
		private XSheetCellRowInfoCollection cellRowInfo = new XSheetCellRowInfoCollection();
		private XSheetCellColInfoCollection cellColInfo = new XSheetCellColInfoCollection();
		private int cols = 0;
		private int rows = 0;
		private bool reDraw = true;
		#endregion

		#region Event
		internal event XSheetCellEventHandler CellSelectionChange;
		//경고방지용
		private void OnCellSelectionChange(XSheetCell cell)
		{
			if (CellSelectionChange != null)
				CellSelectionChange(this, cell);
		}
		#endregion

		#region Base Proerties not browsable
		/// <summary>
		/// 도킹된 컨트롤의 테두리 안쪽여백을 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ScrollableControl.DockPaddingEdges DockPadding
		{
			get { return base.DockPadding;}
		}
		/// <summary>
		/// 사용자가 컨트롤로 끌어 온 데이터가 해당 컨트롤에서 허용되는지 여부를 나타내는 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new bool AllowDrop
		{
			get { return base.AllowDrop;}
			set { base.AllowDrop = value;}
		}
		/// <summary>
		/// 컨트롤에 표시할 배경 이미지를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Image BackgroundImage 
		{
			get { return base.BackgroundImage;}
			set { base.BackgroundImage = value;}
		}
		/// <summary>
		/// 컨트롤의 배경색을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Color BackColor
		{
			get { return base.BackColor;}
			set { base.BackColor = value;}
		}
		/// <summary>
		/// 컨트롤의 전경색을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Color ForeColor
		{
			get { return base.ForeColor;}
			set { base.ForeColor = value;}
		}
		/// <summary>
		/// 컨트롤의 Font를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Font Font
		{
			get { return base.Font;}
			set { base.Font = value;}
		}
		/// <summary>
		/// 자동 스크롤 여백의 크기를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMargin 
		{
			get { return base.AutoScrollMargin;}
			set { base.AutoScrollMargin = value;}
		}
		/// <summary>
		/// 자동 스크롤의 최소 크기를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size AutoScrollMinSize 
		{
			get { return base.AutoScrollMinSize;}
			set { base.AutoScrollMinSize = value;}
		}
		/// <summary>
		/// 오른쪽에서 왼쪽으로 쓰는 글꼴을 사용하는 로케일을 지원하도록 컨트롤 요소가 정렬되어 있는지 여부를 나타내는 값을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override RightToLeft RightToLeft
		{
			get { return base.RightToLeft;}
			set { base.RightToLeft = value;}
		}
		/// <summary>
		/// 액세스 가능 클라이언트 응용 프로그램에서 사용하는 컨트롤의 이름을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string AccessibleName 
		{
			get { return base.AccessibleName;}
			set { base.AccessibleName = value;}
		}
		/// <summary>
		/// 액세스 가능 클라이언트 응용 프로그램에서 사용하는 컨트롤의 설명을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new string AccessibleDescription 
		{
			get { return base.AccessibleDescription;}
			set { base.AccessibleDescription = value;}
		}
		/// <summary>
		/// 컨트롤의 액세스 가능 역할을 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new AccessibleRole AccessibleRole 
		{
			get { return base.AccessibleRole;}
			set { base.AccessibleRole = value;}
		}
		/// <summary>
		/// 컨트롤의 IME(Input Method Editor) 모드를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new ImeMode ImeMode
		{
			get { return base.ImeMode;}
			set { base.ImeMode = value;}
		}
		/// <summary>
		/// 마우스 포인터가 컨트롤 위에 있을 때 표시되는 커서를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Cursor Cursor
		{
			get { return base.Cursor;}
			set { base.Cursor = value;}
		}
		#endregion
		
		#region 생성자
		/// <summary>
		/// XSheet 생성자
		/// </summary>
		public XSheet()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.backContainer.Sheet = this;
			this.selection = new XSheetSelection(this);

			backContainer.AllowDrop = true;
			backContainer.Paint += new PaintEventHandler(BackContainer_Paint);
			backContainer.MouseDown += new MouseEventHandler(BackContainer_MouseDown);
			backContainer.MouseUp += new MouseEventHandler(BackContainer_MouseUp);
			backContainer.MouseMove += new MouseEventHandler(BackContainer_MouseMove);
			backContainer.MouseLeave += new EventHandler(BackContainer_MouseLeave);
			backContainer.MouseHover += new EventHandler(BackContainer_MouseHover);
			backContainer.MouseEnter += new EventHandler(BackContainer_MouseEnter);
			backContainer.MouseWheel += new MouseEventHandler(BackContainer_MouseWheel);
			backContainer.Click += new EventHandler(BackContainer_Click);
			backContainer.DoubleClick += new EventHandler(BackContainer_DoubleClick);
			backContainer.KeyDown += new KeyEventHandler(BackContainer_KeyDown);
			backContainer.KeyUp += new KeyEventHandler(BackContainer_KeyUp);
			backContainer.KeyPress += new KeyPressEventHandler(BackContainer_KeyPress);
			backContainer.DragDrop += new DragEventHandler(BackContainer_DragDrop);
			backContainer.DragEnter += new DragEventHandler(BackContainer_DragEnter);
			backContainer.DragLeave += new EventHandler(BackContainer_DragLeave);
			backContainer.DragOver  += new DragEventHandler(BackContainer_DragOver);
			backContainer.Validating += new CancelEventHandler(BackContainer_Validating);

			//BackColor Set
			this.BackColor = backgroundColor.Color;

			//PrintDocument,PageSetup SET
			this.printDoc = new XSheetPrintDocument(this);
			//Page Setting Margin 기본값 SET (원 기본값은 100milleInch = 2.54cm , 39milleInch = 1cm)
			this.pageSettings.Margins = new Margins(39,39,39,39);
			
		}

		/// <summary> 
		/// 사용된 자원을 해제합니다.
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.backContainer = new IHIS.Framework.SheetBackContainer();
			this.splitPan = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// backContainer
			// 
			this.backContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.backContainer.Location = new System.Drawing.Point(0, 0);
			this.backContainer.Name = "backContainer";
			this.backContainer.Size = new System.Drawing.Size(232, 200);
			this.backContainer.TabIndex = 0;
			// 
			// splitPan
			// 
			this.splitPan.BackColor = System.Drawing.Color.Violet;
			this.splitPan.Location = new System.Drawing.Point(24, 80);
			this.splitPan.Name = "splitPan";
			this.splitPan.Size = new System.Drawing.Size(2, 50);
			this.splitPan.TabIndex = 1;
			this.splitPan.Visible = false;
			// 
			// XSheet
			// 
			this.BackColor = System.Drawing.Color.LightGray;
			this.Controls.Add(this.splitPan);
			this.Controls.Add(this.backContainer);
			this.Name = "XSheet";
			this.Size = new System.Drawing.Size(232, 200);
			this.ResumeLayout(false);

		}
		#endregion

		#region Color, Font, Appearence Category
		/// <summary>
		/// Grid의 바탕배경색을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XGridBackColor"),
		Description("Grid 배경색을 설정합니다.")]
		public XColor BackgroundColor
		{
			get { return backgroundColor;}
			set 
			{ 
				backgroundColor = value;
				this.BackColor = backgroundColor.Color;
			}
		}
		#endregion

		#region Internal Properties
		/// <summary>
		/// 행의 Top,Height 정보를 관리하는 컬렉션입니다.
		/// </summary>
		[Browsable(false)]
		internal XSheetCellRowInfoCollection CellRowInfo
		{
			get { return cellRowInfo;}
		}
		/// <summary>
		/// 컬럼의 Left, Width 정보를 관리하는 컬렉션입니다.
		/// </summary>
		[Browsable(false)]
		internal XSheetCellColInfoCollection CellColInfo
		{
			get { return cellColInfo;}
		}
		/// <summary>
		/// Selected 된 Cell의 List를 가져옵니다.(Cell[])
		/// </summary>
		internal XSheetCell[] MouseSelection
		{
			get
			{
				int l_Count = 0;
				int l_StartRow = 0;
				int l_StartCol = 0;
				int l_EndRow = -1;
				int l_EndCol = -1;
					
				if (StartMouseSelectionCell != null && EndMouseSelectionCell != null)
				{
					l_StartRow = Math.Min(StartMouseSelectionCell.Row,EndMouseSelectionCell.Row);
					l_StartCol = Math.Min(StartMouseSelectionCell.Col,EndMouseSelectionCell.Col);
					//RowSpan을 고려 RowSpan영역에 있는 Row까지 모두 Select
					l_EndRow = Math.Max(StartMouseSelectionCell.Row + StartMouseSelectionCell.RowSpan -1,EndMouseSelectionCell.Row + EndMouseSelectionCell.RowSpan -1);
					//ColSpan을 고려 ColSpan영역에 있는 Col까지 모두 Select
					l_EndCol = Math.Max(StartMouseSelectionCell.Col + StartMouseSelectionCell.ColSpan -1,EndMouseSelectionCell.Col + EndMouseSelectionCell.ColSpan -1);
					
					//calcola le righe totali
					for (int r = l_StartRow; r <= l_EndRow; r++)
						for (int c = l_StartCol; c <= l_EndCol; c++)
							if (Cells[r,c] != null)
								l_Count++;
				}

				XSheetCell[] l_cells = new XSheetCell[l_Count];

				if (StartMouseSelectionCell != null && EndMouseSelectionCell != null)
				{
					int l_index = 0;
					for (int r = l_StartRow; r <= l_EndRow; r++)
						for (int c = l_StartCol; c <= l_EndCol; c++)
							if (Cells[r,c] != null)
							{
								l_cells[l_index] = Cells[r,c];
								l_index++;
							}
				}

				return l_cells;
			}
		}
		/// <summary>
		/// 컬럼의 갯수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public int Cols
		{
			get	{return this.cols;}
			set
			{
				if (this.cols < value)
					AddColumn(this.cols, value - this.cols);
				else if (this.cols > value)
					RemoveColumn(value, this.cols - value);
			}
		}
		/// <summary>
		/// 행의 갯수(Display되는 전체행)를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false)]
		public int Rows
		{
			get	{return this.rows;}
			set
			{
				if (this.rows < value)
					AddRow (this.rows, value - this.rows);
				else if (this.rows > value)
					RemoveRow(value, this.rows - value);
			}
		}
		/// <summary>
		/// 고정된 행의 갯수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int FixedRows
		{
			get{return fixedRows;}
			set{fixedRows = value;}
		}
		/// <summary>
		/// 고정된 열의 갯수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int FixedCols
		{
			get{return fixedCols;}
			set{fixedCols = value;}
		}
		/// <summary>
		/// 현재 Focus가 있는 Cell을 가져옵니다.(없으면 null)
		/// </summary>
		[Browsable(false)]
		public XSheetCell FocusCell
		{
			get{return focusCell;}
		}
		/// <summary>
		/// 현재 Selected된 Cell의 Selection을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public XSheetSelection Selection
		{
			get{return selection;}
		}
		/// <summary>
		/// ScrollBar가 이동한 위치(X,Y)를 가져옵니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point GridScrollPosition
		{
			get{return CustomScrollPosition;}
		}
		/// <summary>
		/// 고정된 열의 높이를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public int FixedRowsHeight
		{
			get 
			{
				int height = 0;
				for ( int i = 0; i < this.FixedRows ; i++)
					height+= this.CellRowInfo[i].Height;
				return height;
			}
		}
		/// <summary>
		/// 고정된 행의 너비를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public int FixedColsWidth
		{
			get 
			{
				int width = 0;
				for ( int i = 0; i < this.FixedCols ; i++)
				{
					width += this.CellColInfo[i].Width;
				}
				return width;
			}
		}
		/// <summary>
		/// Grid을 다시 그릴지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Redraw
		{
			get{return reDraw;}
			set
			{
				reDraw = value;
				if (reDraw)
					InvalidateCells();
			}
		}
		/// <summary>
		/// 현재 Mouse의 Pointer가 있는 Cell을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public XSheetCell UnderMouseCell
		{
			get { return CellUnderMouse;}
		}
		/// <summary>
		/// Grid에서 보여줄 ToolTipText를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SheetToolTipText
		{
			get{ return backContainer.ToolTipText;}
			set{ backContainer.ToolTipText = value;}
		}
		/// <summary>
		/// "Grid를 프린트할때 페이지설정을 관리합니다.
		/// </summary>
		[Browsable(false)]
		public PageSettings PageSettings
		{
			get { return pageSettings;}
		}
		#endregion

		#region Properties Browsable
		/// <summary>
		/// Multi 선택이 가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(true),
		Category("동작"),
		DefaultValue(false),
		Description("Multi로 선택이 가능한지 여부를 관리합니다.")]
		public bool EnableMultiSelection
		{
			get{return enableMultiSelection;}
			set{enableMultiSelection = value;}
		}
		/// <summary>
		/// ToolTip 활성화 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		MergableProperty(true),
		DefaultValue(false),
		Description("ToolTip 활성화여부를 설정합니다.")]
		public bool ToolTipActive
		{
			get { return backContainer.ToolTipActive;}
			set { backContainer.ToolTipActive = value;}
		}
		[Category("동작"),
		DefaultValue(XSheetSelectionMode.Cell),
		Description("Grid의 선택모드를 지정합니다.(행단위,열단위,Cell단위)")]
		public XSheetSelectionMode SelectionMode
		{
			get{return selectionMode;}
			set{ selectionMode = value;	}
		}
		/// <summary>
		/// Row의 Size를 조절 가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(false),
		Description("Row의 Size를 조절 가능한지여부를 관리합니다.")]
		public bool RowResizable
		{
			get { return rowResizable;}
			set { rowResizable = value;}
		}
		/// <summary>
		/// Column의 Size를 조절 가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(false),
		Description("Column의 Size를 조절 가능한지여부를 관리합니다.")]
		public bool ColResizable
		{
			get { return colResizable;}
			set { colResizable = value;}
		}
		#endregion

		#region this Property
		/// <summary>
		/// 지정된 row, col에 해당하는 Cell을 가져오거나 설정합니다.
		/// </summary>
		public XSheetCell this[int row, int col]
		{
			get
			{
				try
				{
					return Cells[row,col];
				}
				catch
				{
					return null;
				}
			}
			set
			{					
				InsertCell(row,col,value);
			}
		}
		#endregion

		#region Protected virtual Methods (필요시 override)
		/// <summary>
		/// CellFocusChange Event를 발생시킵니다.
		/// (Focus 변경시 Row의 값이 바뀌면 OnRowFocusChanged Invoker call)
		/// </summary>
		/// <param name="e"> CellEventArgs </param>
		protected virtual void OnCellFocusChange(XSheetCell cell)
		{
			//DesignMode시도 적용
			if ((cell.Focused) || this.DesignMode)
			{
				//이전의 FocusCell, InnerChangeFocusCell에서 FocusCell 변경 
				XSheetCell preFocusCell = this.focusCell;
				InnerChangeFocusCell(cell);
				if (this.focusCell != null)
				{
					ShowCell(this.focusCell);
				}
			}
			else
			{
				InnerChangeFocusCell(cell);
			}
		}
		#endregion

		#region Private Methods
		// Resizing되는 Cell의 상태를 고려하여 새 너비로 행의 너비를 변경한다.
		private void SetColWidthByResizingCell(XSheetCell resizeCell, int newWidth)
		{
			//ResizingCell이 ColSpan > 1이면 Padding된 만큼 Width를 더해서 Delta값을 구해야 한다.
			int changeCol = resizeCell.Col;
			int colWidth = cellColInfo[resizeCell.Col].Width;
			//ColSpan > 1이면 changeCol은 resizingCell의 Col과 ColSpan을 고려 마지막 col로 Set
			if (resizeCell.ColSpan > 1)
			{
				for ( int i = resizeCell.Col + 1 ; (i < resizeCell.Col + resizeCell.ColSpan) && (i < this.Cols) ; i++)
					colWidth += cellColInfo[i].Width;
				//변경할 Col은 마지막 Col
				changeCol = resizeCell.Col + resizeCell.ColSpan -1;
			}
			int l_DeltaWidth = colWidth - newWidth;
			if (l_DeltaWidth != 0)
			{
				//ChangeCol의 Width조정, changeCol 다음에 오는 Column의 Left 조정
				cellColInfo[changeCol].Width -= l_DeltaWidth;
				for (int c = changeCol + 1; c < this.cols; c++)
				{
					cellColInfo[c].Left -= l_DeltaWidth;
				}
				RecalculateScrollBar();
				InvalidateCells();
			}
		}
		// Resizing되는 Cell의 상태에 따라 새 행의 높이를 설정한다.
		private void SetRowHeightByResizingCell(XSheetCell resizeCell , int newHeight)
		{
			int changeRow = resizeCell.Row;
			int rowHeight = cellRowInfo[resizeCell.Row].Height;
			
			//RowSpan > 1이면 changeRow은 resizingCell의 Row과 RowSpan을 고려 마지막 row로 Set
			if (resizingCell.RowSpan > 1)
			{
				for ( int i = resizeCell.Row + 1 ; (i < resizeCell.Row + resizeCell.RowSpan) && (i < this.Rows) ; i++)
					rowHeight += cellRowInfo[i].Height;
				//변경할 Row은 마지막 Row
				changeRow = resizeCell.Row + resizingCell.RowSpan -1;
			}

			int l_DeltaHeight = rowHeight - newHeight;
			
			if (l_DeltaHeight!=0)
			{
				cellRowInfo[changeRow].Height -= l_DeltaHeight;

				for (int r = changeRow + 1; r < this.rows; r++)
				{
					cellRowInfo[r].Top -= l_DeltaHeight;
				}
				RecalculateScrollBar();
				InvalidateCells();
			}
		}
		private XSheetCell GetPaintCell(int emptyRow, int emptyCol)
		{
			XSheetCell prevRowCell = null;
			XSheetCell prevColCell = null;
			XSheetCell paintCell = null;
			for (int i = emptyRow -1 ; i >= 0 ; i--)
				if (this[i, emptyCol] != null)
				{
					prevRowCell = this[i,emptyCol];
					break;
				}
			for (int i = emptyCol -1 ; i >= 0; i--)
				if (this[emptyRow,i] != null)
				{
					prevColCell = this[emptyRow, i];
					break;
				}

			if (prevRowCell != null)
				if (prevRowCell.Row + prevRowCell.RowSpan > emptyRow)
					paintCell = prevRowCell;
			if (prevColCell != null)
				if (prevColCell.Col + prevColCell.ColSpan > emptyCol)
					paintCell = prevColCell;

			return paintCell;
		}
		#endregion

		#region 영역, Size 관련 Methods
		/// <summary>
		/// Cell의 DisplayRectangle(Visible한 영역)을 가져옵니다.
		/// </summary>
		/// <param name="cell"> Cell 객체 </param>
		/// <returns> Rectangle </returns>
		public Rectangle GetCellDisplayRectangle(XSheetCell cell)
		{
			if (cell == null)
				return new Rectangle(0,0,0,0);
			else
				return GetCellDisplayRectangle(cell.Row,cell.Col,cell.RowSpan,cell.ColSpan);
		}
		/// <summary>
		/// 지정한 영역의 DisplayRectangle(Visible한 영역)을 가져옵니다.
		/// </summary>
		/// <param name="row"> Row의 위치 </param>
		/// <param name="col"> Col의 위치 </param>
		/// <param name="rowSpan"> RowSpan값 </param>
		/// <param name="colSpan"> ColSpan값 </param>
		/// <returns> Rectangle </returns>
		public Rectangle GetCellDisplayRectangle(int row, int col, int rowSpan, int colSpan)
		{
			Rectangle l_tmp = GetCellAbsoluteRectangle(row,col,rowSpan,colSpan);
			int l_x = l_tmp.X;
			int l_y = l_tmp.Y;
			Point l_ScrollPos = CustomScrollPosition;
			if (row >=this.fixedRows)
				l_y += l_ScrollPos.Y;
			if (col >=this.fixedCols)
				l_x += l_ScrollPos.X;
			return (new Rectangle(l_x,l_y,l_tmp.Width,l_tmp.Height));
		}
		/// <summary>
		/// Cell의 AbsoluteRectangle(Grid에서의 절대위치영역)을 가져옵니다.
		/// </summary>
		/// <param name="cell"> Cell 객체 </param>
		/// <returns> Rectangle </returns>
		public Rectangle GetCellAbsoluteRectangle(XSheetCell cell)
		{
			if (cell == null)
				return new Rectangle(0,0,0,0);
			else
				return GetCellAbsoluteRectangle(cell.Row,cell.Col,cell.RowSpan,cell.ColSpan);
		}
		/// <summary>
		/// 지정한 영역의 AbsoluteRectangle(Grid에서의 절대위치영역)을 가져옵니다.
		/// </summary>
		/// <param name="row"> Row의 위치 </param>
		/// <param name="col"> Col의 위치 </param>
		/// <param name="rowSpan"> RowSpan 값 </param>
		/// <param name="colSpan"> ColSpan 값 </param>
		/// <returns></returns>
		public Rectangle GetCellAbsoluteRectangle(int row, int col, int rowSpan, int colSpan)
		{
			if (row >= 0 && row < this.rows &&
				col >= 0 && col < this.cols)
			{
				XSheetCellColInfo l_ColInfo = this.cellColInfo[col];
				XSheetCellRowInfo l_RowInfo = this.cellRowInfo[row];

				if ((l_ColInfo == null) || (l_RowInfo == null)) return new Rectangle(0,0,0,0);

				int l_Width = l_ColInfo.Width;
				int l_Height = l_RowInfo.Height;
				if (rowSpan > 1)
				{
					for (int r = row+1; (r < row + rowSpan) && (r < this.rows); r++)
						l_Height += cellRowInfo[r].Height;
				}
				if (colSpan > 1)
				{
					for (int c = col+1; (c < col + colSpan) && (c < this.cols); c++)
						l_Width += cellColInfo[c].Width;
				}

				return new Rectangle(l_ColInfo.Left,
					l_RowInfo.Top,
					l_Width,
					l_Height);
			}
			else
				return new Rectangle(0,0,0,0);
		}
		/// <summary>
		/// 절대영역 좌표로 그리기 시작열과 행, 종료열과 행을 가져옵니다.
		/// </summary>
		/// <param name="absoluteRect"> 절대영역(Rectangle) </param>
		/// <param name="startRow"> (out) 시작행 </param>
		/// <param name="endRow"> (out) 종료행 </param>
		/// <param name="startCol"> (out) 시작열 </param>
		/// <param name="endCol"> (out) 종료열 </param>
		protected void GetCellRangeFromAbsRect(Rectangle absoluteRect, out int startRow, out int endRow, out int startCol, out int endCol)
		{
			startRow = this.cellRowInfo.GetRowAtPoint(absoluteRect.Y);
			if (startRow == -1)
				startRow = 0;

			endRow = this.cellRowInfo.GetRowAtPoint(absoluteRect.Bottom);
			if (endRow == -1)
				endRow = this.rows -1;

			startCol = this.cellColInfo.GetColAtPoint(absoluteRect.X);
			if (startCol == -1)
				startCol = 0;

			endCol = this.cellColInfo.GetColAtPoint(absoluteRect.Right);
			if (endCol == -1)
				endCol = this.cols -1;
		}
		/// <summary>
		/// 지정한 Col의 너비를 가져옵니다.
		/// </summary>
		/// <param name="col"> Col의 위치 </param>
		/// <returns> 너비 </returns>
		public int GetColWidth(int col)
		{
			try
			{
				return cellColInfo[col].Width;
			}
			catch
			{
				return 0;
			}
		}
		/// <summary>
		/// 지정한 Col에 새 너비를 적용합니다.
		/// </summary>
		/// <param name="col"> Col의 위치 </param>
		/// <param name="newWidth"> 새 너비값 </param>
		internal void SetColWidth(int col, int newWidth)
		{
			try
			{
				int l_DeltaWidth = cellColInfo[col].Width - newWidth;
				if (l_DeltaWidth != 0)
				{
					cellColInfo[col].Width = newWidth;

					for (int c = col+1; c < this.cols; c++)
					{
						cellColInfo[c].Left -= l_DeltaWidth;
					}
					RecalculateScrollBar();
					InvalidateCells();
				}
			}
			catch{}
		}
		/// <summary>
		/// 지정한 Row의 높이를 가져옵니다.
		/// </summary>
		/// <param name="row"> Row의 위치 </param>
		/// <returns> 행 높이 </returns>
		public int GetRowHeight(int row)
		{
			try
			{
				return cellRowInfo[row].Height;
			}
			catch
			{
				return 0;
			}
		}
		/// <summary>
		/// 지정한 Col의 Left의 좌표를 가져옵니다.
		/// </summary>
		/// <param name="col"> Col의 위치 </param>
		/// <returns> Left 좌표 </returns>
		internal int GetColLeft(int col)
		{
			try
			{
				return cellColInfo[col].Left;
			}
			catch
			{
				return 0;
			}
		}
		/// <summary>
		/// 지정한 Row의 Top 좌표를 가져옵니다.
		/// </summary>
		/// <param name="row"> Row의 위치 </param>
		/// <returns> Top 좌표 </returns>
		internal int GetRowTop(int row)
		{
			try
			{
				return cellRowInfo[row].Top;
			}
			catch
			{
				return 0;
			}
		}
		/// <summary>
		/// 지정한 Row의 행높이를 새 높이로 설정합니다.
		/// </summary>
		/// <param name="row"> Row의 위치 </param>
		/// <param name="newHeight"> 새 높이 </param>
		internal void SetRowHeight(int row, int newHeight)
		{
			try
			{
				int l_DeltaHeight = cellRowInfo[row].Height-newHeight;
				if (l_DeltaHeight!=0)
				{
					cellRowInfo[row].Height = newHeight;

					for (int r = row+1; r < this.rows; r++)
					{
						cellRowInfo[r].Top -= l_DeltaHeight;
					}
					RecalculateScrollBar();
					InvalidateCells();
				}
			}
			catch{}
		}
		/// <summary>
		/// Scroll영역을 다시 계산합니다.
		/// </summary>
		internal void RecalculateScrollBar()
		{
			int l_MaxY = 0;
			int l_MaxX = 0;
			for (int r = 0; r < Rows; r++)
				l_MaxY += GetRowHeight(r);
			for (int c = 0; c < Cols; c++)
				l_MaxX += GetColWidth(c);

			CustomScrollArea = new Size(l_MaxX,l_MaxY);
		}

		/// <summary>
		/// VScrollBar의 위치,속성을 다시 조정합니다.
		/// </summary>
		protected override void RecalcVScrollBar()
		{
			base.RecalcVScrollBar();
			// VScrillBar SmallChange를 defaultHeight에 따라 조정한다.
			if ((VScrollBar != null) && (defaultHeight > 0))
				VScrollBar.SmallChange = VScrollBar.LargeChange / defaultHeight;
		}
		
		/// <summary>
		/// 지정 Row, Col에 있는 Cell을 제거합니다.
		/// </summary>
		/// <param name="row"> Row의 위치 </param>
		/// <param name="col"> Col의 위치 </param>
		protected virtual void RemoveCell(int row, int col)
		{
			try
			{
				if (Cells[row,col] != null)
				{
					XSheetCell tmp = Cells[row,col];

					tmp.Select = false; //deseleziono la cella (per evitare che venga rimossa senza essere stata aggiunta alla lista di selection
					tmp.LeaveFocus(); //tolgo l'eventuale focus dalla cella

					tmp.UnBindToSheet();

					Cells[row,col] = null;
					
					tmp.SelectionChange -= new EventHandler(Cell_SelectionChange); 
					tmp.Invalidated -= new InvalidateEventHandler(Cell_Invalidated);
					tmp.FocusChange -= new EventHandler(Cell_FocusChange);
				}
			}
			catch{}
		}

		/// <summary>
		/// 지정 Row, Col에 Cell 객체를 추가합니다.
		/// </summary>
		/// <param name="row"> Row의 위치 </param>
		/// <param name="col"> Col의 위치 </param>
		/// <param name="cell"> Cell 객체 </param>
		protected virtual void InsertCell(int row, int col, XSheetCell cell)
		{
			try
			{
				RemoveCell(row,col);
				Cells[row,col] = cell;
				if (cell != null)
				{
					if (cell.Sheet != null)
						throw new ArgumentException("This cell already have a linked grid","cell");

					cell.Select = false; //deseleziono la cella (per evitare che venga rimossa senza essere stata aggiunta alla lista di selection
					cell.LeaveFocus(); //tolgo l'eventuale focus dalla cella
					
					cell.SelectionChange += new EventHandler(Cell_SelectionChange); 
					cell.Invalidated += new InvalidateEventHandler(Cell_Invalidated);
					cell.FocusChange += new EventHandler(Cell_FocusChange);

					cell.BindToSheet(this,row,col);

					if (Redraw)
						cell.InvokeInvalidate();
				}
			}
			catch{}
		}

		/// <summary>
		/// 지정할 Cell을 Show합니다.(Display영역에 없으면 Scroll하여 보여줌)
		/// </summary>
		/// <param name="cellToShow"> 보여줄 Cell 객체 </param>
		protected void ShowCell(XSheetCell cellToShow)
		{
			// Cell의 Display영역과 Scroll영역을 비교하여 ScrollPosition 변경
			Rectangle l_cellRect = cellToShow.DisplayRectangle;
			Point l_newCustomScrollPosition = new Point(CustomScrollPosition.X,CustomScrollPosition.Y);
			bool l_ApplyScroll = false;
			Rectangle l_ClientRectangle = CustomClientRectangle;
			if (l_cellRect.Location.X <GetColLeft(Math.Min(this.fixedCols,cellToShow.Col)))
			{
				l_newCustomScrollPosition.X -= l_cellRect.Location.X-GetColLeft(Math.Min(this.fixedCols,cellToShow.Col));
				l_ApplyScroll = true;
			}
			if (l_cellRect.Location.Y <GetRowTop(Math.Min(this.fixedRows,cellToShow.Row)))
			{
				l_newCustomScrollPosition.Y -= l_cellRect.Location.Y-GetRowTop(Math.Min(this.fixedRows,cellToShow.Row));
				l_ApplyScroll = true;
			}
			if (l_cellRect.Right > l_ClientRectangle.Width)
			{
				l_newCustomScrollPosition.X -= l_cellRect.Right-l_ClientRectangle.Width;
				l_ApplyScroll = true;
			}
			if (l_cellRect.Bottom >l_ClientRectangle.Height)
			{
				l_newCustomScrollPosition.Y -= l_cellRect.Bottom-l_ClientRectangle.Height;
				l_ApplyScroll = true;
			}
			
			if (l_ApplyScroll)
			{
				CustomScrollPosition = l_newCustomScrollPosition;
			}
		}

		/// <summary>
		/// Grid를 다시 그립니다.
		/// </summary>
		protected void InvalidateCells()
		{
			Invalidate(true);
		}

		/// <summary>
		/// Point(X,Y)에 있는 Cell 객체를 가져옵니다.
		/// </summary>
		/// <param name="relativeViewPoint"> Point (X,Y) </param>
		/// <returns> Cell 객체(없으면 null) </returns>
		public virtual XSheetCell CellAtPoint(Point relativeViewPoint)
		{
			Point l_AbsolutePoint = new Point(relativeViewPoint.X - GridScrollPosition.X, relativeViewPoint.Y - GridScrollPosition.Y);
			XSheetCell l_tmp;

			//Search in fixed rows
			Point l_SearchFixedRows = new Point(l_AbsolutePoint.X, relativeViewPoint.Y);
			for (int r = 0; r < this.fixedRows; r++)
			{
				for (int c = 0; c < this.cols; c++)
					if (Cells[r,c] != null)
						if (Cells[r,c].AbsoluteRectangle.Contains(l_SearchFixedRows))
							return Cells[r,c];
			}

			//Search in fixed cols
			Point l_SearchFixedCols = new Point(relativeViewPoint.X,l_AbsolutePoint.Y);
			for (int c = 0; c < this.fixedCols; c++)
			{
				for (int r = 0; r < this.rows; r++)
					if (Cells[r,c] != null)
						if (Cells[r,c].AbsoluteRectangle.Contains(l_SearchFixedCols))
							return Cells[r,c];
			}


			for (int r = 0; r < this.rows; r++)
			{
				XSheetCellRowInfo l_RowInfo = cellRowInfo[r];
				if (l_RowInfo.Top <= l_AbsolutePoint.Y)
				{
					bool l_bIsInRow = (l_RowInfo.Top+l_RowInfo.Height >= l_AbsolutePoint.Y);

					for (int c = 0; c < this.cols; c++)
					{
						XSheetCellColInfo l_ColInfo = cellColInfo[c];
						if (l_ColInfo.Left <= l_AbsolutePoint.X)
						{
							l_tmp = Cells[r,c];
							if (l_tmp != null)
							{
								if (l_tmp.ColSpan>1 || l_tmp.RowSpan>1 || 
									l_bIsInRow ||
									(l_ColInfo.Left+l_ColInfo.Width >= l_AbsolutePoint.X) )
								{
									Rectangle l_Rct = GetCellAbsoluteRectangle(r,c,l_tmp.RowSpan,l_tmp.ColSpan);
									if (l_AbsolutePoint.Y <= l_Rct.Bottom && l_AbsolutePoint.X <= l_Rct.Right)
										return l_tmp; //FOUND
								}
							}
						}
					}
				}
			}

			//not found
			return null;
		}
		#endregion

		#region EventHandler, 관련 Private Method
		private void Cell_SelectionChange(object sender, EventArgs e)
		{
			OnCellSelectionChange((XSheetCell) sender);
		}
		//Cell의 Focus가 변경될때 Event Invoker Call
		private void Cell_FocusChange(object sender, EventArgs e)
		{
			OnCellFocusChange((XSheetCell)sender);
		}
		// Cell을 다시 그린다.
		private void Cell_Invalidated(object sender, InvalidateEventArgs e)
		{
			if (Redraw)
				backContainer.Invalidate(e.InvalidRect,false);
		}
		// OnCellFocusChange 에서 Call되어 Focus Cell 변경
		private void InnerChangeFocusCell(XSheetCell newCell)
		{
			int startRow, endRow, startCol, endCol;
			if (newCell == this.focusCell)
			{
				// Control, Shift Key를 누르지 않은 상태에서 Focus 변경시는 기존 선택영역 Clear
				if (((Control.ModifierKeys & Keys.Control) != Keys.Control) && ((Control.ModifierKeys & Keys.Shift) != Keys.Shift))
				{
					// 선택영역 Clear
					this.selection.Clear(newCell);
				}

				//Control Key 누른상태에서는 Toggle(Select상태이면 UnSelect)
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
					newCell.Select = !newCell.Select;
				else
					newCell.Select = true;
			}
			else
			{
				if (((Control.ModifierKeys & Keys.Control) != Keys.Control) && ((Control.ModifierKeys & Keys.Shift) != Keys.Shift))
				{
					if (this.focusCell != null)
						this.selection.Clear(newCell);
				}
				

				if (newCell != null)
				{
					//Control Key 누른상태에서는 Toggle(Select상태이면 UnSelect)
					if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
						newCell.Select = !newCell.Select;
					else
						newCell.Select = true;

					//SelectionMode에 따라 Select변경
					//DesignTime시는 Cell단위로만 선택
					if (!this.DesignMode)
					{
						//Shift Key를 누른 상태에서 FocusCell변경시 두 Cell 사이의 영역도 SELECT
						if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) && (focusCell != null))
						{
							startRow = Math.Max(0,Math.Min(focusCell.Row, newCell.Row));
							//RowSpan을 고려 RowSpan영역에 있는 Row까지 모두 Select
							endRow   = Math.Min(this.Rows - 1, Math.Max(focusCell.Row + focusCell.RowSpan - 1, newCell.Row + newCell.RowSpan - 1));
							startCol = Math.Max(0,Math.Min(focusCell.Col, newCell.Col));
							//ColSpan을 고려 ColSpan영역에 있는 Col까지 모두 Select
							endCol   = Math.Min(this.Cols - 1, Math.Max(focusCell.Col + focusCell.ColSpan - 1, newCell.Col + newCell.ColSpan -1));
							for(int r = startRow ; r <= endRow ; r++)
								for (int c = startCol ; c <= endCol ; c++)
									if (Cells[r, c] != null)
										Cells[r, c].Select = true;
						}
					}
				}
				// FocusCell 변경
				this.focusCell = newCell;
			}
		}
		// Resizing과 관련하여 SpiltPanel Visible, 위치 변경	
		private void ShowHideSpitPan(bool isVisible, bool isHorz, int x, int y)
		{
			this.splitPan.Visible = isVisible;
			if(isVisible) 
			{
				if(isHorz)
					this.splitPan.Size = new Size(this.DisplayRectangle.Width, 1);
				else
					this.splitPan.Size = new Size(1, this.DisplayRectangle.Height);
				this.splitPan.Location = new Point(x,y);
			}
		}
		//행 추가시 Cell 관리정보 변경
		private void InnerRowAdded(int row)
		{
			int l_Top = 0;
			if (row > 0)
			{
				l_Top = cellRowInfo[row-1].Top;
				l_Top += cellRowInfo[row-1].Height;
			}
			//Default Height로 SET
			cellRowInfo.Add(row,new XSheetCellRowInfo(defaultHeight,l_Top));

			// 다음 Row의 Top 위치 조정
			for (int r = row+1; r < cellRowInfo.Count;r++)
				cellRowInfo[r].Top += cellRowInfo[row].Height;
		}
		// Row 삭제시에 CellRowInfo 변경
		private void InnerOnRowRemoved(int row)
		{
			try
			{
				int l_OldTop = cellRowInfo[row].Top;
				for (int r = row + 1; r < cellRowInfo.Count;r++)
				{
					cellRowInfo[r].Top = l_OldTop;
					l_OldTop = l_OldTop+cellRowInfo[r].Height;
				}
				cellRowInfo.RemoveAt(row);
			}
			catch{}
		}
		// Column 추가시 CellColInfo 변경
		private void InnerColumnAdded(int col)
		{
			int l_Left = 0;
			if (col > 0)
			{
				l_Left = cellColInfo[col-1].Left;
				l_Left += cellColInfo[col-1].Width;
			}
			//Default Width로 SET
			cellColInfo.Add(col,new XSheetCellColInfo(defaultWidth,l_Left));

			// 다음 열의 Left위치 조정
			for (int c = col+1; c < cellColInfo.Count;c++)
				cellColInfo[c].Left += cellColInfo[col].Width;
		}
		// Column 삭제시 CellColInfo 변경
		private void InnerOnColumnRemoved(int col)
		{
			try
			{
				int l_OldLeft = cellColInfo[col].Left;
				// 다음 열의 Left 위치 조정
				for (int c = col + 1; c < cellColInfo.Count;c++)
				{
					cellColInfo[c].Left = l_OldLeft;
					l_OldLeft = l_OldLeft+cellColInfo[c].Width;
				}
				cellColInfo.RemoveAt(col);
			}
			catch{}
		}
		//Rows, Cols 값 변경에 따른 Cell[,] 변경	
		private void RedimMatrix(int rows, int cols)
		{
			if (Cells == null)
			{
				Cells = new XSheetCell[rows,cols];
			}
			else
			{
				if ((rows != Rows) || (cols != Cols))
				{
					XSheetCell[,] l_tmp = Cells;
					int l_minRows = Math.Min(l_tmp.GetLength(0),rows);
					int l_minCols = Math.Min(l_tmp.GetLength(1),cols);
					
					// 변경후 Rows 이후의 Row에 있는 Cell 제거
					// 변경후 Rows이후 Cell을 필요없는 Cell이므로 수행속도 향상을 위해 RemoveCell을 Call하지
					// 않고, Null SET
					for (int i = l_minRows; i <l_tmp.GetLength(0); i++)
						for (int j = 0; j < l_tmp.GetLength(1); j++)
							Cells[i,j] = null;
					// 변경후 Cols 이후의 Col에 있는 Cell 제거
					for (int i = 0; i <l_minRows; i++)
						for (int j = l_minCols; j < l_tmp.GetLength(1); j++)
							Cells[i,j] = null;

					Cells = new XSheetCell[rows,cols];

					// Cell[,] 할당
					for (int i = 0; i <l_minRows; i++)
						for (int j = 0; j < l_minCols; j++)
							Cells[i,j] = l_tmp[i,j];
				}
			}

			this.rows = Cells.GetLength(0);
			this.cols = Cells.GetLength(1);
			//FixedRows, Cols 변경
			this.fixedRows = Math.Min(this.fixedRows, this.rows);
			this.fixedCols = Math.Min(this.fixedCols, this.cols);
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// 선택영역이 변경될때 변경사항을 적용합니다.
		/// </summary>
		protected void MouseSelectionChange()
		{
			XSheetCell[] l_Cells = MouseSelection;
			// 이전 선택영역 Clear
			foreach (XSheetCell c in oldMouseSelection)
				c.Select = false;

			// 새 선택영역 선택
			foreach (XSheetCell c in l_Cells)
				c.Select = true;
			// 새영역을 이전영역으로 SET
			oldMouseSelection = l_Cells;
		}

		/// <summary>
		/// 선택영역을 Clear합니다.
		/// </summary>
		protected void MouseSelectionClear()
		{
			// Selection Clear
			oldMouseSelection = new XSheetCell[0];
			StartMouseSelectionCell = null;
			EndMouseSelectionCell = null;
		}
		/// <summary>
		/// 선택영역을 변경합니다.
		/// </summary>
		/// <param name="cornerCell"> 선택영역에서 BottomRight Cell 객체 </param>
		protected void ChangeMouseSelectionCorner(XSheetCell cornerCell)
		{
			bool l_bChange = false;
			if (StartMouseSelectionCell != this.focusCell)
			{
				StartMouseSelectionCell = this.focusCell;
				l_bChange = true;
			}
			if (EndMouseSelectionCell != cornerCell)
			{
				EndMouseSelectionCell = cornerCell;
				l_bChange = true;
			}

			if (l_bChange)
				MouseSelectionChange();
		}
		/// <summary>
		/// Mouse Pointer가 있는 Cell이 바뀔때 처리합니다.
		/// </summary>
		/// <param name="changeCell"> 변경된 Cell </param>
		protected void ChangeCellUnderMouse(XSheetCell changeCell)
		{
			if (CellUnderMouse != changeCell)
			{
				if (CellUnderMouse != null)
					CellUnderMouse.InvokeMouseLeave(EventArgs.Empty);
				CellUnderMouse = changeCell;
				if (changeCell != null)
					changeCell.InvokeMouseEnter(EventArgs.Empty);
			}
		}
		#endregion

		#region BackCotainer Event Handler (Event Invoker call)
		private void BackContainer_MouseMove(object sender, MouseEventArgs e)
		{
			//MouseMove Event call
			this.OnMouseMove(e);
		}
		private void BackContainer_MouseDown(object sender, MouseEventArgs e)
		{
			//MouseDown Event call
			this.OnMouseDown(e);
		}
		private void BackContainer_MouseUp(object sender, MouseEventArgs e)
		{
			//MouseUp Event call
			this.OnMouseUp(e);
		}
		private void BackContainer_MouseLeave(object sender, EventArgs e)
		{
			//MouseLeave Event call
			this.OnMouseLeave(e);
		}
		private void BackContainer_MouseHover(object sender, EventArgs e)
		{
			//MouseHover Event call
			this.OnMouseHover(e);
		}
		private void BackContainer_MouseEnter(object sender, EventArgs e)
		{
			//MouseEnter Event call
			this.OnMouseEnter(e);
		}
		private void BackContainer_MouseWheel(object sender, MouseEventArgs e)
		{
			//MouseWheel Event call
			this.OnMouseWheel(e);
		}
		// DragDrop은 GridAppearance에서 편집시만 기동하게함. 일반적으로는 쓰지 않음
		private void BackContainer_DragDrop(object sender, DragEventArgs e)
		{
			//DragDrop Event call
			this.OnDragDrop(e);
		}
		private void BackContainer_DragEnter(object sender, DragEventArgs e)
		{
			//DragEnter Event call
			this.OnDragEnter(e);
		}
		private void BackContainer_DragLeave(object sender, EventArgs e)
		{
			//DragLeave Event call
			this.OnDragLeave(e);
		}
		private void BackContainer_DragOver(object sender, DragEventArgs e)
		{
			//DragOver Event call
			this.OnDragOver(e);
		}
		private void BackContainer_Click(object sender, EventArgs e)
		{
			//Click Event Call
			this.OnClick(e);
		}

		private void BackContainer_DoubleClick(object sender, EventArgs e)
		{
			//DoubleClick Event call
			this.OnDoubleClick(e);
		}

		private void BackContainer_KeyDown(object sender, KeyEventArgs e)
		{
			//KeyDown Event call
			this.OnKeyDown(e);
		}
	
		private void BackContainer_KeyUp(object sender, KeyEventArgs e)
		{
			//KeyUp Event call
			this.OnKeyUp(e);
		}

		private void BackContainer_KeyPress(object sender, KeyPressEventArgs e)
		{
			//KeyPress Event call
			this.OnKeyPress(e);
		}

		private void BackContainer_Paint(object sender, PaintEventArgs e)
		{
			//Paint call
			this.OnPaint(e);
		}
		private void BackContainer_Validating(object sender, CancelEventArgs e)
		{
			// Window전환시 Grid에 Focus가 갈때 BackContainer에 Focus가 가므로 Validating Check
			this.OnValidating(e);
			// Validating후에 에러중인 Editor로 Focus이동 가능하게 하기 위해 cancel 복구	
			e.Cancel = false;
		}
		#endregion

		#region Event Invoker Override
		private bool isFocused = false;  //Focus를 받았을때 Border 색깔 변경에 사용
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave (e);
			//Border 정상으로 변경
			this.isFocused = false;
			this.DrawBorder(this.Handle);
		}
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);

			//Border Focus로 변경
			this.isFocused = true;
			this.DrawBorder(this.Handle);

		}
		/// <summary>
		/// Grid를 그립니다.
		/// </summary>
		/// <param name="e"> PaintEventArgs </param>
		protected override void OnPaint(PaintEventArgs e)
		{
			// Color 설정 변경여부 Check
			if (BackColor != backgroundColor.Color)
				BackColor = backgroundColor.Color;
			
			Point l_ScrollPoint = CustomScrollPosition;
			Rectangle l_AbsoluteDrawRect = new Rectangle(e.ClipRectangle.X - l_ScrollPoint.X,e.ClipRectangle.Y -l_ScrollPoint.Y,e.ClipRectangle.Width,e.ClipRectangle.Height);
			int startRow = 0, origStartRow = 0;
			int endRow = this.Rows - 1;
			int startCol = 0, origStartCol = 0;
			int endCol = this.Cols - 1;
			XSheetCell paintCell = null;

			// Clip영역으로 Paint시작,종료 Row, Col Get
			this.GetCellRangeFromAbsRect(l_AbsoluteDrawRect, out startRow, out endRow, out startCol, out endCol);
			
			origStartRow = startRow;
			origStartCol = startCol;

			//Draw all non fixed cells
			if (this.fixedRows > startRow)
				startRow = this.fixedRows;
			if (this.fixedCols > startCol)
				startCol = this.fixedCols;
			
			try
			{
				//Draw non Fixed Rows, Cols
				for (int r = startRow; r <= endRow ; r++)
				{
					// 영역 밖일때는 break
					if ( (cellRowInfo[r].Top + l_ScrollPoint.Y) > e.ClipRectangle.Bottom)
						break;
					// 영역에 속할때만 그림
					if ( (cellRowInfo[r].Top + cellRowInfo[r].Height + l_ScrollPoint.Y) > e.ClipRectangle.Top)
					{
						for (int c = startCol; c <= endCol ; c++)
						{
							if ( (cellColInfo[c].Left + l_ScrollPoint.X) > e.ClipRectangle.Right)
								break;

							if ( (cellColInfo[c].Left + cellColInfo[c].Width + l_ScrollPoint.X) > e.ClipRectangle.Left)
							{
								if (Cells[r,c] != null)
								{
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect,false);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else // RowSpan,ColSpan에 의해 Cell이 없는 경우는 Cell을 찾아 Paint
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false);
									// Reset
									paintCell = null;
								}
						
							}
						}
					}
				}
				
				//Draw fixed rows
				for (int r = 0; r < this.fixedRows; r++)
				{
					if ( cellRowInfo[r].Top > e.ClipRectangle.Bottom)
						break;

					if ( (cellRowInfo[r].Top + cellRowInfo[r].Height) > e.ClipRectangle.Top)
					{
						for (int c = this.fixedCols ; c < this.cols; c++)
						{
							if ( (cellColInfo[c].Left + l_ScrollPoint.X) > e.ClipRectangle.Right)
								break;
						
							if ( (cellColInfo[c].Left + cellColInfo[c].Width + l_ScrollPoint.X) > e.ClipRectangle.Left)
							{
								if (Cells[r,c] != null)
								{
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect,false);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false);
									// Reset
									paintCell = null;
								}
							}
						}
					}
				}
				
				//Draw Fixed Cols
				startRow = Math.Max(origStartRow, this.fixedRows);
				for (int r = startRow ; r <= endRow ; r++)
				{
					if ( (cellRowInfo[r].Top + l_ScrollPoint.Y) > e.ClipRectangle.Bottom)
						break;
					if ( (cellRowInfo[r].Top + cellRowInfo[r].Height + l_ScrollPoint.Y) > e.ClipRectangle.Top)
					{
						for (int c = 0 ; c < this.fixedCols ; c++)
						{
							if (cellColInfo[c].Left > e.ClipRectangle.Right)
								break;
							if ( (cellColInfo[c].Left + cellColInfo[c].Width ) > e.ClipRectangle.Left)
							{
								if (Cells[r,c] != null)
								{
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect,false);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false);
									// Reset
									paintCell = null;
								}
							}
						}
					}

				}

				
				//Draw both fixed rows and fixed cols
				for (int r = 0; r < this.fixedRows; r ++)
				{
					if ( cellRowInfo[r].Top  > e.ClipRectangle.Bottom)
						break;

					if ( (cellRowInfo[r].Top + cellRowInfo[r].Height ) > e.ClipRectangle.Top)
					{
						for (int c = 0; c < this.fixedCols; c ++)
						{
							if (cellColInfo[c].Left > e.ClipRectangle.Right)
								break;

							if ( (cellColInfo[c].Left + cellColInfo[c].Width ) > e.ClipRectangle.Left)
							{
								if (Cells[r,c] != null)
								{
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect, false);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false);
									// Reset
									paintCell = null;
								}
							}
						}
					}
				}
			}
			catch(Exception xe)
			{
				Debug.WriteLine("OnPaint error[" + xe.Message + "]");
			}

			//grid가 Resized되었으면 Border 다시그림
			if (this.gridResized)
			{
				this.DrawBorder(this.Handle);
				//Flag Clear
				this.gridResized = false;
			}
		}
		/// <summary>
		/// MouseMove Event를 발생시킵니다.
		/// (override) Mouse이동시 선택영역, Resizing Mode를 변환합니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			XSheetCell tmp = CellAtPoint(new Point(e.X,e.Y));
			XSheetCell selectEndCell = null;
			bool isDifX = false;
			bool isDifWidth = false;
			bool isDifY = false;
			bool isDifHeight = false;
			bool resizableColumn = true;
			bool resizableRow = true;
			Rectangle rect; 
			if (tmp != null)
			{
				tmp.InvokeMouseMove(e);

				if (this.focusCell!=null)
				{
					// Normal State일때는 Selection 변경
					if (e.Button == MouseButtons.Left && this.sheetStatus == XSheetStatus.Normal)
					{
						// 여러개 선택가능시
						if (enableMultiSelection)
						{
							// SelectionMode에 따라, endCell 변경, Row일때는 해당Row의 마지막 Column Cell
							// Col일때는 해당 Col의 마지막 Row Cell은 EndCell로 함
							switch(selectionMode)
							{
								case XSheetSelectionMode.Cell:
									selectEndCell = tmp;
									break;
								case XSheetSelectionMode.Row:
									try
									{
										selectEndCell = this[tmp.Row, this.Cols -1];
									}
									catch
									{
										selectEndCell = tmp;
									}
									break;
								case XSheetSelectionMode.Col:
									try
									{
										selectEndCell = this[this.Rows -1, tmp.Col];
									}
									catch
									{
										selectEndCell = tmp;
									}
									break;
								default:
									selectEndCell = tmp;
									break;
							}
							//SelectEndCell 변경시 (DesignMode시는 제외)
							if (!DesignMode)
								if ((selectionMode != XSheetSelectionMode.Cell) || (this.focusCell != selectEndCell))
									ChangeMouseSelectionCorner(selectEndCell);
						}
					}
					else
					{
						// 선택영역 Clear
						MouseSelectionClear();
					}
				}
				//DisplayRect Get
				rect = tmp.DisplayRectangle;
				
				// VScrollBar, HScrollBar가 있을때 e.X가 vScrollBar영역에 있거나, e.Y가 HScrollBar영역에 있으면 Resizing 모드로 변환하지 않음
				bool isInVScrollBarArea = false;
				bool isInHScrollBarArea = false;
				if (this.VScrollBar != null)
				{
					if (this.ClientRectangle.Width - this.VScrollBar.Width < e.X) isInVScrollBarArea = true;
				}
				if (this.HScrollBar != null)
				{
					if (this.ClientRectangle.Height - this.HScrollBar.Height < e.Y) isInHScrollBarArea = true;
				}
				if (!isInVScrollBarArea && !isInHScrollBarArea)
				{
					//Scroll X 위치도 고려 DisplayRect와 비교
					isDifX = (Math.Abs(e.X - rect.X) <= cMoveDif ? true : false);
					isDifWidth = (Math.Abs(e.X - (rect.X + rect.Width)) <= cMoveDif ? true : false);
					isDifY = (Math.Abs(e.Y - rect.Y) <= cMoveDif ? true : false);
					isDifHeight = (Math.Abs(e.Y - (rect.Y + rect.Height)) <= cMoveDif ? true : false);					
				}
				else
					return;

				//Cursor 변경 (Button Click없이 Mouse Move시)
				if(e.Button == MouseButtons.None)
				{
					
					resizableColumn = true;
					resizableRow = true;
					if (!this.colResizable) resizableColumn = false;
					if (!this.rowResizable) resizableRow = false;
					
					if(resizableColumn && ((isDifX && tmp.Col != 0) || isDifWidth))
					{
						this.Cursor = XSheetImage.LeftRightCursor;
						this.sheetStatus = XSheetStatus.ColResizing;
						if(isDifX)
						{
							bool isFounded = false;
							int  searchMinRow = 0;
							int  searchMaxRow = 0;
							int  endCol = 0;
							try
							{
								// 해당 Row의 tmp바로 앞에 있는 Cell 검색
								for (int i = tmp.Col -1 ; i >= endCol; i--)
								{
									if (this[tmp.Row, i] != null)
									{
										isFounded = true;
										this.resizingCell = this[tmp.Row, i];
										break;
									}
								}
								// 해당 Row에 없으면 RowPadding 고려하여 tmp.Col -1부터 이전 Cell중 바로 다음 Cell 을 ResizingCell로 Get
								if (!isFounded)
								{
									searchMinRow = 0;
									searchMaxRow = tmp.Row - 1;

									// Point가 있는 Cell의 바로 앞 Cell은 ColPad고려하여 Set
									for ( int i = tmp.Col - 1 ; i >= 0; i--)
									{
										for (int j = searchMaxRow ; j >= searchMinRow ; j--)
										{
											if (this[j, i] != null)
											{
												this.resizingCell = this[j, i];
												isFounded = true;
												break;
											}
										}
										if (isFounded) break;
									}
								}
							}
							catch
							{
								this.resizingCell = null;
							}
						}
						else
							this.resizingCell = tmp;
					}
					else if(resizableRow && (isDifY || isDifHeight)) //RowResizing이 가능할때만 RowResizing상태로 변환
					{
						this.Cursor = XSheetImage.UpDownCursor;
						this.sheetStatus = XSheetStatus.RowResizing;
						if(isDifY)
						{
							try
							{
								// Point가 있는 Cell의 바로 앞 Cell은 RowPad고려하여 Set
								for ( int i = tmp.Row - 1 ; i >= 0 ; i--)
								{
									if (this[i, tmp.Col] != null)
									{
										this.resizingCell = this[i,tmp.Col];
										break;
									}
								}
							}
							catch
							{
								this.resizingCell = null;
							}
						}
						else
							this.resizingCell = tmp;
					}
					else
					{
						this.Cursor = System.Windows.Forms.Cursors.Default;
						this.sheetStatus = XSheetStatus.Normal;
					}
				}
				else if(e.Button == MouseButtons.Left) // Resizing
				{
					if (this.sheetStatus == XSheetStatus.ColResizing)
					{
						if(this.resizingCell == null) return;
						int dispRectX = this.resizingCell.DisplayRectangle.X;
						
						// ColSpan > 1인 경우는 Span을 고려한 Width를 더하여 해당 Width까지만 Resizing가능
						for ( int i = this.resizingCell.Col ; i < this.resizingCell.Col + this.resizingCell.ColSpan -1 ; i++)
							dispRectX += this.CellColInfo[i].Width;

						// ColSpan고려 위치값 + 최소조정값보다  e.X가 적을 수는 없음, 
						if (dispRectX + cResizingMin > e.X ) return;

						this.ShowHideSpitPan(true, false, e.X, 0);
					}
					else if (this.sheetStatus == XSheetStatus.RowResizing)
					{
						if(this.resizingCell == null) return;
						// ResizingCell의 Y보다 e.Y가 적을 수는 없음, RowSpan > 1인 경우는 Span을 고려한 Height를 더하여 해당 높이까지만 Resizing가능
						int dispRectY = this.resizingCell.DisplayRectangle.Y;
						for ( int i = this.resizingCell.Row ; i < this.resizingCell.Row + this.resizingCell.RowSpan -1 ; i++)
							dispRectY += this.CellRowInfo[i].Height;

						// RowSpan고려 위치값 + 최소조정값보다  e.X가 적을 수는 없음, 
						if (dispRectY > e.Y) return;

						this.ShowHideSpitPan(true, true, 0, e.Y);
					}
				}
			}
			else // CellAtPoint is Null
			{
				if(e.Button == MouseButtons.Left)
				{
					if (this.sheetStatus == XSheetStatus.ColResizing)
						this.ShowHideSpitPan(true, false, e.X, 0);
					else if (this.sheetStatus == XSheetStatus.RowResizing)
						this.ShowHideSpitPan(true, true, 0, e.Y);
				}
				else  // Clear
				{
					this.Cursor = System.Windows.Forms.Cursors.Default;
					this.sheetStatus = XSheetStatus.Normal;
				}
			}
			// CellUnderMouse 변경
			ChangeCellUnderMouse(tmp);
		}
		/// <summary>
		/// MouseDown Event를 발생시킵니다.
		/// (override) Pointer의 위치에 따라 Resizing Mode로 변환합니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			MouseDownCell = CellAtPoint(new Point(e.X,e.Y));

			//MouseDown시 BackContainer에 Focus가 없으면 BackContainer에 Focus를 줌
			if (!this.backContainer.Focused)
				this.backContainer.Focus();

			if (MouseDownCell != null)
			{
				MouseDownCell.InvokeMouseDown(e);
			}

			if(this.sheetStatus == XSheetStatus.RowResizing)
			{
				this.Cursor = XSheetImage.UpDownCursor;
				if (e.Button == MouseButtons.Left)
					this.ShowHideSpitPan(true, true, 0, e.Y);
				else
					this.ShowHideSpitPan(false, true, 0, e.Y);
			}
			else if(this.sheetStatus == XSheetStatus.ColResizing)
			{
				this.Cursor = XSheetImage.LeftRightCursor;
				if (e.Button == MouseButtons.Left)
					this.ShowHideSpitPan(true, false, e.X ,0);
				else
					this.ShowHideSpitPan(false, false, e.X ,0);
			}
			else  // Normal 상태
			{
				if ((e.Button == MouseButtons.Left) && MouseDownCell != null)
				{
					MouseDownCell.Focus();
				}
			}

			base.OnMouseDown(e);
		}
		/// <summary>
		/// MouseUp Event를 발생시킵니다.
		/// (override) Resizing Mode시 행높이, 열너비 조정
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			//선택영역 Clear
			MouseSelectionClear();

			if (MouseDownCell != null)
				MouseDownCell.InvokeMouseUp(e);
			
			// Resizing
			if(this.sheetStatus == XSheetStatus.ColResizing)
			{
				// 조정 Size가 최소값이상일때 Resize
				if(this.resizingCell != null)
					if (this.splitPan.Location.X - this.resizingCell.DisplayRectangle.X >= cResizingMin)
						this.SetColWidthByResizingCell(this.resizingCell, this.splitPan.Location.X - this.resizingCell.DisplayRectangle.X);
			}
			else if (this.sheetStatus == XSheetStatus.RowResizing)
			{
				// 조정 Size가 최소값이상일때 Resize
				if(this.resizingCell != null)
					if (this.splitPan.Location.Y - this.resizingCell.DisplayRectangle.Y >= cResizingMin)
						this.SetRowHeightByResizingCell(this.resizingCell, this.splitPan.Location.Y - this.resizingCell.DisplayRectangle.Y);
			}
			
			//Reset
			this.splitPan.Visible = false;
			this.resizingCell = null;
			this.sheetStatus = XSheetStatus.Normal;
		}
		/// <summary>
		/// MouseLeave Event를 발생시킵니다.
		/// (override) 선택영역을 Clear합니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			// Cursor Change
			// BackContainer_MouseLeave Event는 VScrollBar와 HScrollBar가 있거나, Enable 상태이면 ScrollBar영역에 오면 발생하고
			// ScrollBar가 있으나, Disable상태이면 ClientRectangle을 벋어나야 발생한다.
			this.Cursor = System.Windows.Forms.Cursors.Default;
			
			//CellUnderMouse Clear
			ChangeCellUnderMouse(null);

			//선택영역 Clear
			MouseSelectionClear();
		}
		/// <summary>
		/// MouseWheel Event를 발생시킵니다.
		/// (override) Scroll Position을 다시 조정합니다.
		/// </summary>
		/// <param name="e"> MouseEventArgs </param>
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);

			try
			{
				if (e.Delta >= 120 || e.Delta <= -120)
				{
					Point t = CustomScrollPosition;
					int l_NewY = t.Y + 
						(SystemInformation.MouseWheelScrollLines * defaultHeight) *
						Math.Sign(e.Delta);

					//check that the value is between max and min
					if (l_NewY>0)
						l_NewY = 0;
					// ScrollPostion의 Y는 VScroll의 Max값에서 LargeChange값을 뺀 만큼만 이동가능함
					if (l_NewY < (-base.MaximumVScroll + base.LargeChangeVScroll) )
						l_NewY = -base.MaximumVScroll + base.LargeChangeVScroll;
					CustomScrollPosition = new Point(t.X,l_NewY);
				}
			}
			catch(Exception)
			{
				//error
			}
		}
		/// <summary>
		/// Click Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);

			if (MouseDownCell != null)
				MouseDownCell.InvokeClick();
		}
		/// <summary>
		/// DoubleClick Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);

			if (MouseDownCell != null)
				MouseDownCell.InvokeDoubleClick();
		}
		/// <summary>
		/// KeyDown Event를 발생시킵니다.
		/// (override) PageUp,PageDown시 Scroll합니다.
		/// </summary>
		/// <param name="e"> KeyEventArgs </param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if (this.focusCell != null)
			{
				this.focusCell.InvokeKeyDown(e);

				XSheetCell tmp = null;
				try
				{
					if (e.KeyCode == Keys.Down)
					{
						int tmpRow = this.focusCell.Row;
						tmpRow++;
						while (tmp == null && tmpRow < Rows)
						{
							tmp = Cells[tmpRow,this.focusCell.Col];
							tmpRow++;
						}
					}
					else if (e.KeyCode == Keys.Up)
					{
						int tmpRow = this.focusCell.Row;
						tmpRow--;
						while (tmp == null && tmpRow >= 0)
						{
							tmp = Cells[tmpRow,this.focusCell.Col];
							tmpRow--;
						}
					}
					else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Tab)
					{
						int tmpCol = this.focusCell.Col;
						tmpCol++;
						while (tmp == null && tmpCol < Cols)
						{
							tmp = Cells[this.focusCell.Row,tmpCol];
							tmpCol++;
						}
					}
					else if (e.KeyCode == Keys.Left)
					{
						int tmpCol = this.focusCell.Col;
						tmpCol--;
						while (tmp == null && tmpCol >= 0)
						{
							tmp = Cells[this.focusCell.Row,tmpCol];
							tmpCol--;
						}
					}
					else if (e.KeyCode == Keys.PageDown)
					{
						CustomScrollPageDown();
					}
					else if (e.KeyCode == Keys.PageUp)
					{
						CustomScrollPageUp();
					}

					if (tmp!=null)
						tmp.Focus();
				}
				catch{}
			}
		}
		/// <summary>
		/// KeyUp Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> KeyEventArgs </param>
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);

			if (this.focusCell != null)
				this.focusCell.InvokeKeyUp(e);
		}
		/// <summary>
		/// KeyPress Event를 발생시킵니다.
		/// (override) Enter Key 입력시 TAB키 발생, Ctrl+C입력시 선택영역을 복사합니다.
		/// </summary>
		/// <param name="e"> KeyPressEventArgs </param>
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);

			if (this.focusCell == null || e.KeyChar == '\t' || e.KeyChar == 13 )
			{
				//EnterKey입력시 TabKey Send
				if (e.KeyChar == (char)13)  // Enter시 Tab Key 발생
				{
					SendKeys.Send("{TAB}");
					return;
				}
			}
			else
			{
				// ClipboardCopy만 가능, Cut, Paste 불가
				// 3 == Ctrl + C
				if (e.KeyChar == 3) 
				{
					if (this.selection.Count > 0)
						this.selection.ClipboardCopy();
				}
				else
					this.focusCell.InvokeKeyPress(e);
			}
		}
		/// <summary>
		/// Resize Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> EventArgs </param>
		protected override void OnResize(EventArgs e)
		{
			// Flag Set
			this.gridResized = true;
			base.OnResize(e);
		}
		#endregion

		#region AddRow, Remove Methods
		/// <summary>
		/// 특정 Row의 위치 이후에 Row를 추가합니다.
		/// </summary>
		/// <param name="newRowPosition"> 추가할 Row의 위치 </param>
		/// <param name="newRowCount"> Row의 갯수(1 이상) </param>
		internal void AddRow(int newRowPosition, int newRowCount)
		{
			if (newRowCount <= 0) return;
			if ((newRowPosition < 0) || (newRowPosition > this.rows)) return;

			RedimMatrix(this.rows+newRowCount,this.cols);
			// 행추가시 Row의 관련정보 변경
			for (int r = newRowPosition; r < (newRowPosition+newRowCount); r++)
			{
				InnerRowAdded(r);
			}
			RecalculateScrollBar();
			InvalidateCells();
		}

		/// <summary>
		/// 시작 Row에서 종료 Row까지의 Row를 제거합니다.
		/// </summary>
		/// <param name="startRemoveRow"> 시작 Row </param>
		/// <param name="removeRowCount"> 삭제할 Row의 갯수 </param>
		internal void RemoveRow(int startRemoveRow, int removeRowCount)
		{
			if ((removeRowCount <= 0) || (removeRowCount > this.rows)) return;
			if ((startRemoveRow < 0)  || (startRemoveRow >= this.rows)) return;

			for (int r = (startRemoveRow+removeRowCount); r < this.rows; r++)
			{
				for (int c = 0; c < this.cols; c++)
				{
					XSheetCell tmp = Cells[r,c];
					RemoveCell(r,c);
					InsertCell(r-removeRowCount,c,tmp);
				}
			}
			RedimMatrix(this.rows-removeRowCount,this.cols);

			// Row삭제에 따른 관련정보 변경
			for (int r = startRemoveRow; r < (startRemoveRow+removeRowCount); r++)
			{
				InnerOnRowRemoved(startRemoveRow); 
			}
			RecalculateScrollBar();
			InvalidateCells();
		}
		#endregion

		#region AddColumn, Removecolumn Method
		/// <summary>
		/// 특정 컬럼의 위치 이후에 컬럼을 추가합니다.
		/// </summary>
		/// <param name="newColPosition"> 컬럼의 위치 </param>
		/// <param name="newColCount"> 추가 컬럼 갯수(1이상) </param>
		internal void AddColumn(int newColPosition, int newColCount)
		{
			if (newColCount <= 0) return;
			if ((newColPosition < 0) || (newColPosition > this.cols)) return;

			RedimMatrix(this.rows,this.cols+newColCount);

			// 컬럼추가에 따른 관련 정보 변경
			for (int c = newColPosition; c < (newColPosition+newColCount); c++)
			{
				InnerColumnAdded(c);
			}
			RecalculateScrollBar();
			InvalidateCells();
		}
		/// <summary>
		/// 시작 컬럼에서 종료컬럼까지의 컬럼을 제거합니다.
		/// </summary>
		/// <param name="startRemoveColumn"> 시작 컬럼 </param>
		/// <param name="removeColumnCount"> 삭제할 컬럼의 갯수 </param>
		internal void RemoveColumn(int startRemoveColumn, int removeColumnCount)
		{
			if (removeColumnCount <= 0) return;
			if ((startRemoveColumn < 0) || (startRemoveColumn >= this.cols)) return;

			for (int c = (startRemoveColumn+removeColumnCount); c < this.cols; c++)
			{
				for (int r = 0; r < this.rows; r++)
				{
					XSheetCell tmp = Cells[r,c];
					RemoveCell(r,c);
					InsertCell(r,c-removeColumnCount,tmp);
				}
			}

			RedimMatrix(this.rows,this.cols-removeColumnCount);

			// 컬럼제거에 따른 관련항목 변경
			for (int c = startRemoveColumn; c < (startRemoveColumn+removeColumnCount); c++)
			{
				InnerOnColumnRemoved(startRemoveColumn); 
			}

			RecalculateScrollBar();
			InvalidateCells();
		}
		#endregion

		#region AutoSizeColumn, AutoSizeRow Methods
		/// <summary>
		/// 특정컬럼의 너비를 자동조정합니다.
		/// </summary>
		/// <param name="col"> 컬럼위치 </param>
		/// <param name="minWidth"> 조정할 너비값 </param>
		public virtual void AutoSizeColumn(int col, int minWidth)
		{
			//개발자가 부여한 최소너비 그대로 적용
			int l_minWidth = Math.Max(minWidth,0);
			SetColWidth(col,l_minWidth);
		}
		/// <summary>
		/// 특정 행의 높이를 자동조정합니다.
		/// </summary>
		/// <param name="row"> 행의 위치 </param>
		/// <param name="minHeight"> 조정 높이 </param>
		public virtual void AutoSizeRow(int row , int minHeight)
		{
			//개발자가 부여한 최소높이 그대로 적용
			int l_minHeight = Math.Max(minHeight,0);
			SetRowHeight(row,l_minHeight);
		}

		/// <summary>
		/// Grid를 주어진 높이와 너비로 자동조정합니다.
		/// </summary>
		/// <param name="minHeight"> 조정 높이 </param>
		/// <param name="minWidth"> 조정 너비 </param>
		public virtual void AutoSizeAll(int minHeight, int minWidth)
		{
			int mWidth = Math.Max(minHeight,0);
			int mHeight = Math.Max(minHeight,0);
			for (int c = 0; c < this.cols; c++)
				AutoSizeColumn(c,mWidth);
			for (int r = 0; r < this.rows; r++)
				AutoSizeRow(r,mHeight);
		}

		/// <summary>
		/// Grid를 최초 설정된 높이와 너비로 자동조정합니다.
		/// </summary>
		public virtual void AutoSizeAll()
		{
			//기본값으로 SET
			for (int c = 0; c < this.cols; c++)
				AutoSizeColumn(c, this.defaultWidth);
			for (int r = 0; r < this.rows; r++)
				AutoSizeRow(r, this.defaultHeight);
		}
		#endregion
		
		#region WndProc, DrawBorder
		/// <summary>
		/// Window 메세지를 처리합니다.
		/// (override) 연속조회요청, Border를 그립니다.
		/// </summary>
		/// <param name="msg"> (ref) Message </param>
		protected override void WndProc(ref Message msg)
		{
			base.WndProc(ref msg);

			//NC영역 Get
			switch (msg.Msg)
			{
				case (int)Win32.Msgs.WM_NCCALCSIZE :
					int isValidClientArea = (int)msg.WParam;
					if (isValidClientArea != 0)
					{
						Win32.NCCALCSIZE_PARAMS newRect = (Win32.NCCALCSIZE_PARAMS)(Marshal.PtrToStructure(msg.LParam, typeof(Win32.NCCALCSIZE_PARAMS)));
						newRect.rgrc0.left += borderWidth;
						newRect.rgrc0.right -= borderWidth;
						newRect.rgrc0.top += borderWidth;
						newRect.rgrc0.bottom -= borderWidth;
						newRect.rgrc2.left += borderWidth;
						newRect.rgrc2.right -= borderWidth;
						newRect.rgrc2.top += borderWidth;
						newRect.rgrc2.bottom -= borderWidth;
						Marshal.StructureToPtr(newRect, msg.LParam, true);
					}
					else
					{
						Win32.RECT newRect = (Win32.RECT)(Marshal.PtrToStructure(msg.LParam, typeof(Win32.RECT)));
						newRect.left += borderWidth;
						newRect.right -= borderWidth;
						newRect.top += borderWidth;
						newRect.bottom -= borderWidth;
						Marshal.StructureToPtr(newRect, msg.LParam, true);
					}
					break;
				case (int)Win32.Msgs.WM_NCHITTEST :
					int x = (int)msg.LParam % 0x10000;
					int y = (int)msg.LParam / 0x10000;
					Point pos = this.PointToClient(new Point(x, y));
					if (x >= (Bounds.Width - borderWidth) || x <= borderWidth ||
						y >= (Bounds.Height - borderWidth) || y <= borderWidth )
					{
						msg.Result = (IntPtr)18;		// Border
					}
					break;
				case (int)Win32.Msgs.WM_NCPAINT :
					DrawBorder(msg.HWnd);
					msg.Result = IntPtr.Zero;
					break;
			}
		}
		//Border는 NC영역에서 그리기
		private void DrawBorder(IntPtr hwnd)
		{
			IntPtr hDC = User32.GetWindowDC(hwnd);
			Graphics g = Graphics.FromHdc(hDC);
			Pen rectPen;
			if (this.isFocused)
				rectPen = new Pen(Color.Orange,(float) borderWidth);
			else
				rectPen = new Pen(borderColor.Color,(float) borderWidth);
			g.DrawRectangle(rectPen , 0,0, this.Width - borderWidth, this.Height - borderWidth);

			rectPen.Dispose();
			g.Dispose();
			User32.ReleaseDC(hwnd, hDC);
		}
		#endregion

		#region GetNextCell, GetPrevCell
		/// <summary>
		/// 지정한 Cell의 다음 Cell을 가져옵니다.
		/// </summary>
		/// <param name="currentCell"> 현재 Cell </param>
		/// <returns> 다음 Cell </returns>
		[Description("현재 Cell의 다음 Cell을 가져옵니다.")]
		public XSheetCell GetNextCell(XSheetCell currentCell)
		{
			XSheetCell nextCell = null;
			int startCol = 0;
			if (currentCell == null) return null;
			
			// 현재Row의 다음 Row Search
			for (int i = currentCell.Col + 1 ; i < this.Cols ; i++)
			{
				if (this[currentCell.Row, i] != null)
				{
					nextCell = this[currentCell.Row, i];
					break;
				}
			}
			// 없으면 다음 Row의 1번째 컬럼
			if (nextCell == null)
			{
				for ( int i = startCol; i < this.Cols ; i++)
				{
					if (this[currentCell.Row + 1, i] != null)
					{
						nextCell = this[currentCell.Row + 1, i];
						break;
					}
				}
			}
			return nextCell;

		}
		/// <summary>
		/// 지정한 Cell의 이전 Cell을 가져옵니다.
		/// </summary>
		/// <param name="currentCell"> 현재 Cell </param>
		/// <returns> 이전 Cell </returns>
		[Description("현재 Cell의 이전 Cell을 가져옵니다.")]
		public XSheetCell GetPrevCell(XSheetCell currentCell)
		{
			XSheetCell prevCell = null;
			int startCol = 0;
			if (currentCell == null) return null;

			// 현재 Row의 이전 Col의 Cell 
			for ( int i = currentCell.Col - 1 ; i >= startCol ; i--)
			{
				if (this[currentCell.Row, i] != null)
				{
					prevCell = this[currentCell.Row, i];
					break;
				}
			}

			// 없으면 이전 Row의 마지막 Cell
			if (prevCell == null)
			{
				for (int i = this.Cols ; i >= startCol ; i--)
				{
					if (this[currentCell.Row -1, i] != null)
					{
						prevCell = this[currentCell.Row -1, i];
						break;
					}
				}
			}
			return prevCell;
		}
		#endregion

		#region ProcessCmdKey (TAB KEY 통제)
		/// <summary>
		/// 명령 키를 처리합니다.
		/// (override) (Shift) + TAB 키 입력시 이전, 다음 Cell로 이동합니다.
		/// </summary>
		/// <param name="msg"> (ref) Message </param>
		/// <param name="keyData"> Keys Enum </param>
		/// <returns> 해당키가 처리되었으면 true, 아니면 false </returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			XSheetCell moveCell = null;
			Keys keyCode = (Keys)(((int)keyData << 16) >> 16);		// Modifier Clear
			Keys modifier = (Keys)(((int)keyData >> 16) << 16);		// Modifier
			//TAB Press
			if ((keyCode == Keys.Tab) && ((keyData & Keys.Shift) != Keys.Shift))
			{
				// 다음 Cell로 이동
				moveCell = this.GetNextCell(this.FocusCell);
				if (moveCell != null)
				{
					//NextCell Focus
					moveCell.Focus();
					// TAB KEY 처리함
					return true;
				}
			}
			//Shift + TAB
			if ((keyCode == Keys.Tab) && ((keyData & Keys.Shift) == Keys.Shift))
			{
				// 이전 Cell로 이동
				moveCell = this.GetPrevCell(this.FocusCell);
				if (moveCell != null)
				{
					//PrevCell Focus
					moveCell.Focus();

					// Shift + TAB시에 선택영역 해제
					this.Selection.Clear(moveCell);

					// TAB KEY 처리함
					return true;
				}
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		#endregion

		#region Export Method 관련
		private string[] excelmap = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
										"AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ",
										"BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",
										"CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ"};
		private string GetExcelIndexToLetter(int i)
		{
			return excelmap[i];
		}
		/// <summary>
		/// Excel로 보기
		/// </summary>
		public virtual void ShowToExcel()
		{
			ExportSub(false, true);
		}
		/// <summary>
		/// Export
		/// </summary>
		/// <param name="runExcel"> Excel Run 여부 </param>
		public virtual void Export(bool runExcel)
		{
			ExportSub(true,true);
		}
		public virtual void Export()
		{
			ExportSub(true,false);
		}
		protected virtual void ExportSub(bool isSaveFile, bool runExcel)
		{
			if ((this.cols == 0) || (this.rows == 0)) return;

			ProgressForm progress = new ProgressForm(100);
            System.Globalization.CultureInfo oldCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.CultureInfo newCulture;

			string msg = "";
			try
			{
				string fileName = "";
				ArrayList excelProcList = new ArrayList();
				//파일을 Save하면 파일명칭지정하는 Dialog Show
				if (isSaveFile)
				{
					//Excel.ExcelApp를 사용하면 Interop.Excel등 다른 dll참조해야하고, 또한
					//Excel을 띄우게 되므로 html형식으로 Excel파일을 만듦
					SaveFileDialog dlg = new SaveFileDialog();
					dlg.Filter = "Excel files (*.xls)|*.xls"  ;
					dlg.FilterIndex = 1 ;
					dlg.RestoreDirectory = true ;
					if(dlg.ShowDialog() != DialogResult.OK)
						return;

					fileName = dlg.FileName;
				}
				else
				{
					//미지정이면 현재 Drive에 Temp Dir에 현재시간.xls 파일로 생성
					string path = Application.StartupPath.Substring(0,1) + ":\\Temp";
					if (!Directory.Exists(path))
						Directory.CreateDirectory(path);
					fileName = path + "\\" + DateTime.Now.ToString("HHmmss") + ".xls";
				}

				progress.Show();

				//GabageCollector를 쓰면 Excel이 죽지 않는 경우가 발생
				//기존에 떠있는 Excel 검색하여 저장후 새로 생긴 Excel Kill
				foreach(Process proc in Process.GetProcessesByName("EXCEL"))
					excelProcList.Add(proc.Id);
				
				progress.SetProgressValue(10);

				Excel.ApplicationClass excelApp = new Excel.ApplicationClass();
				if (excelApp == null)
				{
					msg = XMsg.GetMsg("M050"); // Excel파일을 생성하지 못했습니다.
					ShowErrMsg(msg);
					return;
				}
				
				excelApp.Visible = false;

                newCulture = new System.Globalization.CultureInfo(excelApp.LanguageSettings.get_LanguageID(Office.MsoAppLanguageID.msoLanguageIDUI));
                System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;

				int rowCount = this.rows;
				int colCount = this.cols;
				Excel.Workbook theWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
				Excel.Worksheet theWorkSheet = (Excel.Worksheet)theWorkBook.Worksheets[1];
				
				Excel.Range theRange = theWorkSheet.Cells.get_Range(GetExcelIndexToLetter(0) + "1", GetExcelIndexToLetter(colCount -1) + (rowCount + 1).ToString());

				object[,] dataArray = new object[rowCount, colCount];

				progress.SetProgressValue(20);

				for (int row = 0 ; row < rowCount ; row++)
				{
					for (int col = 0 ; col < colCount ; col++)
					{
						XSheetCell cell = this[row, col];
						if (cell != null)
							dataArray[row, col] = cell.CellText;
					}
				}
				
				progress.SetProgressValue(50);

				//Range Data Set
				theRange.Value = dataArray;

				progress.SetProgressValue(80);

				//SaveAs File
				theWorkBook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
					Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,Type.Missing, Type.Missing);

				//저장후 Excel Process 종료
				excelApp.Quit();

				//excelApp에 의해 생성된 Process Kill
				Process[] excelProcess = Process.GetProcessesByName("EXCEL");
				for (int i = 0 ; i < excelProcess.Length ; i++)
				{
					if (!excelProcList.Contains(excelProcess[i].Id))
						excelProcess[i].Kill();
				}

				progress.SetProgressValue(100);
				
				//Excel Run
				try
				{
					if (runExcel)
					{
						//Dir명이 Space가 들어가 있는 경우에 대비하여 arguments를 전달시에 양쪽을 ""로 묶음
						Process.Start("EXCEL.exe", "\"" + fileName + "\"");
					}
				}
				catch{}
			}
			catch(Exception e)
			{
				msg = XMsg.GetMsg("M051", e); // Excel파일 생성실패. 에러[" + e.Message + "]"
				ShowErrMsg(msg);
			}
			finally
			{
				if (progress != null)
					progress.Close();

                System.Threading.Thread.CurrentThread.CurrentCulture = oldCulture;
			}
		}
		protected void ShowErrMsg(string msg)
		{
			if (msg == "") return;
			XMessageBox.Show(msg);
		}
		#endregion

		#region ScrollControl override
		/// <summary>
		/// Grid를 Scroll합니다.
		/// </summary>
		/// <param name="deltaX"> 수평 이동값 </param>
		/// <param name="deltaY"> 수직 이동값 </param>
		protected override void ScrollControl(int deltaX, int deltaY)
		{
			if (deltaX != 0)
			{
				Win32.RECT clientRECT = new Win32.RECT(this.backContainer.ClientRectangle);
				// FixedCol영역은 제외
				clientRECT.left += this.FixedColsWidth;
				User32.ScrollWindow(this.backContainer.Handle, deltaX, 0, ref clientRECT, ref clientRECT);
			}
			if (deltaY != 0)
			{
				Win32.RECT clientRECT = new Win32.RECT(this.backContainer.ClientRectangle);
				// FixedRow영역은 제외 (상대좌표 계산)
				clientRECT.top += this.FixedRowsHeight;
				User32.ScrollWindow(this.backContainer.Handle, 0, deltaY, ref clientRECT, ref clientRECT);
			}
		}
		#endregion

		#region InvalidateRow,  InvalidateCol
		/// <summary>
		/// 지정한 Row영역을 Invalidate합니다.
		/// </summary>
		/// <param name="row"> Row 위치 </param>
		protected void InvalidateRow(int row)
		{
			if ((row >= 0) && (row < this.rows))
			{
				try
				{
					// Scroll위치 고려, X= 0, Y는 Scroll위치 고려한 Y, Width는 전체영역, Height는 Row의 Height만큼 Invalidate
					Rectangle rect = new Rectangle(0, this.cellRowInfo[row].Top + this.CustomScrollPosition.Y, this.CustomClientRectangle.Width, this.cellRowInfo[row].Height);
					Invalidate(rect, true);
				}
				catch{}
			}
		}
		/// <summary>
		/// 지정한 Col영역을 Invalidate합니다.
		/// </summary>
		/// <param name="col"> Col 위치 </param>
		protected void InvalidateCol(int col)
		{
			if ((col >= 0) && (col < this.cols))
			{
				try
				{
					// Scroll위치 고려, X= Scroll위치 고려한 X, Y는 0, Width는 Col의 Widht, Height는 전체영역 Invalidate
					Rectangle rect = new Rectangle(this.cellColInfo[col].Left + this.CustomScrollPosition.X, 0, this.cellColInfo[col].Width, this.CustomClientRectangle.Height);
					Invalidate(rect, true);
				}
				catch{}
			}
		}
		#endregion

		#region Grid Print 관련 Methods
		public virtual void PageSetup()
		{
			float converter = 2.54f;
			PageSetupDialog dlg = new PageSetupDialog();
			dlg.AllowPrinter = false; //Print 단추 Disable
			//원래 Margin 보관
			Margins origMargins = (Margins) pageSettings.Margins.Clone();
			this.printDoc.DefaultPageSettings = this.pageSettings;
			dlg.Document = this.printDoc;
			//dlg의 PageSettings.Margins 변경 (PageSettings (1/100 inch)단위 dlg의 단위는 millscm 단위, 1inch = 2.54cm)
			dlg.PageSettings.Margins.Left = (int) ((float)dlg.PageSettings.Margins.Left * converter);
			dlg.PageSettings.Margins.Right = (int) ((float)dlg.PageSettings.Margins.Right * converter);
			dlg.PageSettings.Margins.Top = (int) ((float)dlg.PageSettings.Margins.Top * converter);
			dlg.PageSettings.Margins.Bottom = (int) ((float)dlg.PageSettings.Margins.Bottom * converter);
			//PageSetupDialog는 취소를 누르면 Margins가 변경되어 나온다. 따라서, 원 마진을 보관하였다가 취소시는 원래 Margin으로 복구처리함.
			if (dlg.ShowDialog() == DialogResult.Cancel)
				pageSettings.Margins = (Margins) origMargins.Clone();
		}
		/// <summary>
		/// Grid를 Print합니다.
		/// </summary>
		public virtual void Print()
		{
			try
			{
				printDoc.DefaultPageSettings = this.pageSettings;
				//Page 설정
				printDoc.PrinterSettings.FromPage = 1;
				printDoc.PrinterSettings.ToPage = printDoc.CalcPageCount();
				printDoc.PrinterSettings.PrintRange = PrintRange.AllPages; // 최초 AllPages
				PrintDialog dlg = new PrintDialog();
				dlg.AllowSomePages = true;
				dlg.Document = printDoc;
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					//PrintDocument의 PageSetting의 PrinterSettings SET
					//전체인쇄, 부분인쇄시 변경시 DefaultPageSettings.PrinterSettings의 값을 변경해야함
					//변경하지 않으면 Print시 발생하는 OnPagePrint에서의 Argument로 전달되는 값이 항상 전체인쇄가 됨
					printDoc.DefaultPageSettings.PrinterSettings = dlg.PrinterSettings;
					// Print
					printDoc.Print();
				}
			}
			catch
			{
				string msg = XMsg.GetMsg("M068") + "\n" //출력에 실패하였습니다. 프린더의 전원을 확인해 주십시오.
					+ XMsg.GetMsg("M069") + "\n\n" //프린더 드라이버가 제대로 설정되어 있는지 확인해 주십시오.
					+ XMsg.GetMsg("M070");  //계속 출력이 안되면 전산실에 문의해 주십시오.
				MessageBox.Show(msg, "Print Error");
			}
		}
		/// <summary>
		/// Grid를 Print 미리보기합니다.
		/// </summary>
		public virtual void PrintPreview()
		{
			try
			{
				printDoc.DefaultPageSettings = this.pageSettings;
				// PreView일때는 전체 Page 인쇄로 설정
				printDoc.DefaultPageSettings.PrinterSettings.PrintRange = PrintRange.AllPages;
				PrintPreviewDialog dlg = new PrintPreviewDialog();
				dlg.Document = printDoc;
				dlg.ShowDialog();
			}
			catch
			{
				string msg = XMsg.GetMsg("M068") + "\n" //출력에 실패하였습니다. 프린더의 전원을 확인해 주십시오.
					+ XMsg.GetMsg("M069") + "\n\n" //프린더 드라이버가 제대로 설정되어 있는지 확인해 주십시오.
					+ XMsg.GetMsg("M070");  //계속 출력이 안되면 전산실에 문의해 주십시오.
				MessageBox.Show(msg, "Print Error");
			}
		}
		#endregion

	}

}
