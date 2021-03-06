using System;
using System.Collections.Generic;
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

    public delegate IList<object[]> ExecuteQueryData(BindVarCollection varList);

        /// <summary>
	/// XGrid에 대한 요약설명입니다.
	/// </summary>
	[ToolboxItem(true),
	ToolboxBitmap(typeof(IHIS.Framework.XGrid), "Images.XGrid.bmp")]
	[Designer(typeof(XGridDesigner))]
	public class XGrid : CustomScrollControl, IMultiQueryLayout, IDetailLayout, ISupportInitialize
	{
		#region fields without Property
		private System.ComponentModel.IContainer components;
		private BackContainer backContainer;
		private System.Windows.Forms.Panel splitPan;
		private int DefaultWidth = 80;
		// WndProc UserDefined Msg Field
		private const int MsgContCall = (int) Win32.Msgs.WM_USER + 5;
		private const int cMoveDif = 2;
		private const int cResizingMin = 10;  // Resizing시의 최소 높이, 너비
		private const int cRowHeaderWidth = 25;  // RowHeader의 너비
		private const int cDisplayRowUnit = 100; // 100건단위로 보여줌
		private const int FIRST_DISP_COUNT = 200;  //최초 Display할 건수
		private const string TABLE_NAME = "LayoutTable";  //Layout Table의 이름
		private XCell resizingCell = null;
		private XCell[] oldMouseSelection = new XCell[0];
		private bool isScrollReCalc = true;  // ScrollBar의 위치를 다시 계산할지 여부
		private XGridGroupDataCollection GroupDataList = new XGridGroupDataCollection();
		//Cell의 위치를 관리하는 컬렉션
		private XCellPosInfoCollection rowPosList = new XCellPosInfoCollection();
		private XGridPrintDocument printDoc = null;
		private PageSettings pageSettings = new PageSettings();
		/// <summary>
		/// Grid에 Display된 Row의 갯수
		/// </summary>
		protected int DisplayedRowCount = 0;
		private XGridSelectionMode origSelectionMode = XGridSelectionMode.Row;
		/// <summary>
		/// 선택영역 시작 Cell
		/// </summary>
		protected XCell StartMouseSelectionCell = null;
		/// <summary>
		/// 선택영역 종료 Cell
		/// </summary>
		protected XCell EndMouseSelectionCell = null;
		/// <summary>
		/// Focus 변경전 이전 RowNumber
		/// </summary>
		protected int PreRowNumber = -1; // Focus Change전의 이전 RowNumber
		/// <summary>
		/// Array of cells(Cell[,])
		/// </summary>
		protected XCell[,] Cells = null;
		/// <summary>
		/// MouseDown한 Cell입니다.
		/// </summary>
		protected XCell MouseDownCell = null;
		/// <summary>
		/// Grid에서 에러 발생여부
		/// </summary>
		protected bool HasErrors = false;
		/// <summary>
		/// Mouse Point에 있는 Cell
		/// </summary>
		protected XCell CellUnderMouse = null;
		/// <summary>
		/// RowFilter 적용중인지 여부
		/// </summary>
		protected bool IsFiltering = false;
		/// <summary>
		/// Layout의 Table
		/// </summary>
		private DataTable layoutTable = null;
		/// <summary>
		/// Sort,Filtering전의 원래 DataTable
		/// </summary>
		protected DataTable OrigLayoutTable = null;
		/// <summary>
		/// Filtering후에 Filter된 행의 OrigLayoutTable에서의 Index관리 List
		/// </summary>
		protected ArrayList OrigTableRowIndexList = new ArrayList();
		/// <summary>
		/// Group에 의해 생성된 Row의 위치정보
		/// </summary>
		internal XGridGroupRowInfoCollection GroupRowInfos = new XGridGroupRowInfoCollection();
		private bool gridResized = false;  //Grid가 Resize되었는지 여부
		private int borderWidth = 1;
		private XColor borderColor = XColor.XGridBorderColor;
		private ArrayList distinctDataList = new ArrayList();  // DistinctCount계산시 Data를 관리하는 ArrayList
		private XGridDataItemCollection dataItems = new XGridDataItemCollection();

		//현재Row 강조 Font, Color
		protected Font CurrentRowHeaderFont = new Font(FontFamily.GenericSansSerif, 7.0f, FontStyle.Bold);
		protected XColor CurrentRowForeColor = new XColor(Color.Brown);
		private ArrayList supressColumnList = new ArrayList();  //Supress Repeating Column List
		internal Hashtable CellInfoList = new Hashtable(); //컬럼정보 검색속도향샹을 위해 컬럼정보를 관리하는 Hashtable
		protected  ILayoutContainer LayoutContainer = null;
		private bool isLeftMouseDown = false; //Left MouseDown을 했는지 여부
		private BindVarCollection bindVarList = new BindVarCollection();  //조회 SQL의 Bind변수 리스트
		//2007.11.08 QueryEnd Event에 callerID를 설정하기 위해 XEditGrid에만 선언된 callerID를 protected로 XGrid로 옮김.
		protected char callerID = '1';  //수행자를 Call하는 Grid의 ID
		#endregion

		#region  Fields having Property
		private XColor backgroundColor = XColor.XGridBackColor;
		private XColor rowHeaderBackColor = XColor.XGridRowHeaderBackColor;
		private XColor rowHeaderForeColor = XColor.XGridRowHeaderForeColor;
		// 2005/05/09 신종석 폰트 수정(기존 : FontFamily.GenericSansSerif, 7.0f, FontStyle.Regular)
		private Font rowHeaderFont = new Font("MS UI Gothic", 7.0f, FontStyle.Bold);
		private XCellDrawMode rowHeaderDrawMode = XCellDrawMode.Flat;
		
		private XGridCellCollection cellInfos = new XGridCellCollection();
		private XGridHeaderCollection headerInfos = new XGridHeaderCollection();
		private XGridComputedCellCollection computedCellInfos = new XGridComputedCellCollection();
		private XGridGroupInfoCollection groupInfos = new XGridGroupInfoCollection();
		private ArrayList headerHeights = new ArrayList();
		private int defaultHeight = 21; //MS UI Gothic 9.75f는 TextBox등 Control의 Height가 21으로 굴림(22)보다 작음
		private bool enableMultiSelection = false;
		private bool rowStateCheckOnPaint = false;
		private bool rowResizable = false;
		private bool colResizable = false;
		private XGridStatus gridStatus = XGridStatus.Normal;
		private int autoSizeHeight = 21;
		private int fixedRows = 0;
		private int fixedCols = 0;
		protected XCell focusCell = null;  //2006.03.08 focusCell을 EditGrid에서 수정가능하도록 protected로 전환
		private XGridSelection selection = null;
		private XGridSelectionMode selectionMode = XGridSelectionMode.Row;
		private int linePerRow = 1;  //사용자가 지정한 한 행의 Line수
		private int colPerLine = 0;
		private int addedHeaderLine = 0;  // 추가된 Header의 Line수를 나타냄
		private XCellRowInfoCollection cellRowInfo = new XCellRowInfoCollection();
		private XCellColInfoCollection cellColInfo = new XCellColInfoCollection();
		private int cols = 0;
		private int rows = 0;
		private bool reDraw = true;
		private bool rowHeaderVisible = false;
		private bool colHeaderVisible = true;  //컬럼 Header의 Visible 여부
		private bool showNumberAtRowHeader = true;
		private bool selectionModeChangeable = false;  // SelectionMode 변경가능여부
		private bool resizableAtOnlyHeader = true;    // Cursor가 Header에 있을때만 Resize 가능한지 여부
		private bool readOnly = true;
		private bool controlBinding = false;  //Control과의 Binding 여부
		private ImageList imageList = null;  //ImageList
		private bool applyAutoHeight = false;
		private XGridSortMode sortMode = XGridSortMode.DoubleClick;  //컬럼Header Double Click시에 Sort적용
		private bool isDrawRowVerticalLine = true;  //행의 Vertical Line(컬럼구분 Line) 을 그릴지 여부
		private bool isDrawRowHorizontalLine = true;  //행의 Horizontal Line(행 구분) 을 그릴지 여부
		private XGridToolTipType toolTipType = XGridToolTipType.Data; //ToolTip활성화시 보여줄 Text의 Type
		private bool	applyPaintEventToAllColumn = false;  //컬럼의 ApplyPaintingEvent여부에 관계없이 전체컬럼에 GridCellPainting Event 적용
		private IMasterLayout masterLayout = null;  //Grid의 MasterGrid
		protected Hashtable relationKeys = new Hashtable();  //(컬럼명, Master컬럼명)형태로 관리되는 Key 컬럼관리 List
		protected string relationTableName = "";  //이 Layout이 Detail로 사용될때 이 Layout과 관련된 Table명(DB Table)
		private bool togglingRowSelection = false; //선택모드가 Row일때 Ctrl, Shift를 누르지 않은 상태에서 Click시에 선택된 Row Toggling여부
		private string querySQL = "";   //Grid에 데이타를 조회할 SQL을 지정합니다.
		private bool   isAllDataQuery = false; //데이타 전체 조회 여부 (true : 연속조회 사용안함)
		private bool	applyLayoutContainerReset = true;  //LayoutContainer의 Reset 호출시에 Reset를 적용할지 여부
        private ExecuteQueryData executeQuery;
        private List<string> paramList = new List<string>();        

        //2015/08/19: pagination
        private int mPage = 1;
        #endregion

		#region Event
		/// <summary>
		/// 행이 변경될때 발생하는 Event입니다.
		/// </summary>
		[Description("행이 변경되었을 때 발생합니다."),
		Category("추가이벤트"),
		Browsable(true)]
		public event RowFocusChangedEventHandler RowFocusChanged;

		/// <summary>
		/// 행이 변경될때 발생하는 Event입니다.
		/// </summary>
		[Description("행이 변경되기전에 발생합니다."),
		Category("추가이벤트"),
		Browsable(true)]
		public event RowFocusChangingEventHandler RowFocusChanging;

		[Description("컬럼을 그릴때 발생합니다.(데이타에 따른 색깔,폰트변경)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event XGridCellPaintEventHandler GridCellPainting;

		[Description("Cell의 Focus가 변경되었을때 발생합니다."),
		Category("추가이벤트"),
		Browsable(true)]
		public event XGridCellFocusChangedEventHandler GridCellFocusChanged;

		[Description("컬럼의 값이 변경되었을 때 발생합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridColumnChangedEventHandler GridColumnChanged;

		[Description("Grid가 Sort되었을때 발생합니다.(Sort, Sort가능한 컬럼헤더 Click시)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event EventHandler GridSorted;

		[Description("Grid가 다음 Display를 하고난 후 발생합니다.(Display미완료시 Scroll할때)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event XGridContDisplayedEventHandler GridContDisplayed;

		[Description("Grid의 Filter가 변경되었을때 발생합니다.(SetFilter,ClearFilter시)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event EventHandler GridFilterChanged;

		[Description("Grid의 DisplayData를 Call한 후에 발생합니다."),
		Category("추가이벤트"),
		Browsable(true)]
		public event EventHandler GridDataDisplayed;

		[Description("Grid의 조회가 시작되었을때 발생합니다.(Bind변수에 값 설정, 조건에 따른 조회여부 설정)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event CancelEventHandler QueryStarting;
		//2007.11.08 조회종료 Event 추가 (성공여부에 따라 추가 처리시에 사용)
		[Description("조회가 끝났을때 발생합니다.(조회 성공여부에 따라 추가처리시 사용)"),
		Category("추가이벤트"),
		Browsable(true)]
		public event QueryEndEventHandler QueryEnd;
		#endregion

		#region Internal Event
		internal event XCellEventHandler CellSelectionChange;
		//경고방지용
		private void OnCellSelectionChange(XCell cell)
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
		/// XGrid 생성자
		/// </summary>
		public XGrid()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			this.backContainer.Grid = this;
			this.selection = new XGridSelection(this);

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
            //<.NET 2005 Event 추가> MouseClick, MouseDoubleClick , MouseCaptureChanged, PreviewKeyDown
            backContainer.MouseClick += new MouseEventHandler(BackContainer_MouseClick);
            backContainer.MouseDoubleClick += new MouseEventHandler(BackContainer_MouseDoubleClick);
            backContainer.MouseCaptureChanged += new EventHandler(BackContainer_MouseCaptureChanged);
            backContainer.PreviewKeyDown += new PreviewKeyDownEventHandler(BackContainer_PreviewKeyDown);

			//BackColor Set
			this.BackColor = backgroundColor.Color;

			//PrintDocument,PageSetup SET
			this.printDoc = new XGridPrintDocument(this);
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
			this.components = new System.ComponentModel.Container();
			this.backContainer = new IHIS.Framework.BackContainer();
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
			// XGrid
			// 
			this.BackColor = System.Drawing.Color.LightGray;
			this.Controls.Add(this.splitPan);
			this.Controls.Add(this.backContainer);
			this.Name = "XGrid";
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
		
		/// <summary>
		/// RowHeader의 배경색을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XGridRowHeaderBackColor"),
		Description("Grid RowHeader의 배경색을 설정합니다.")]
		public XColor RowHeaderBackColor
		{
			get { return rowHeaderBackColor;}
			set 
			{
				rowHeaderBackColor = value;
				// RowHeadervisible일때 0,0컬럼 Color SET
				try
				{
					if (this.rowHeaderVisible)
						if (Cells[0,0] != null)
							Cells[0,0].BackColor = rowHeaderBackColor;
				}
				catch{}

				InvalidateCells();
			}
		}
		/// <summary>
		/// RowHeader의 Text 색을 가져오거나 설정합니다.
		/// </summary>
		[DefaultValue(typeof(XColor),"XGridRowHeaderForeColor"),
		Description("Grid RowHeader의 Text 색을 설정합니다.")]
		public XColor RowHeaderForeColor
		{
			get { return rowHeaderForeColor;}
			set
			{
				rowHeaderForeColor = value;
				InvalidateCells();
			}
		}
		/// <summary>
		/// RowHeader의 Font를 가져오거나 설정합니다.
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(typeof(Font), "MS UI Gothic, 7pt, style=Bold"),
		Description("Grid RowHeader의 Font를 설정합니다.")]
		public Font RowHeaderFont
		{
			get { return rowHeaderFont;}
			set 
			{
				rowHeaderFont = value;
				// 현재행을 강조하는 RowHeaderFont SET
				if (rowHeaderFont.Bold)
					this.CurrentRowHeaderFont = new Font(rowHeaderFont, FontStyle.Regular);
				else
					this.CurrentRowHeaderFont = new Font(rowHeaderFont, FontStyle.Bold);	
				InvalidateCells();
			}
		}
		/// <summary>
		/// RowHeader의 DrawMode를 가져오거나 설정합니다.
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(XCellDrawMode.Flat),
		Description("RowHeader의 DrawMode를 설정합니다.")]
		public XCellDrawMode RowHeaderDrawMode
		{
			get { return rowHeaderDrawMode;}
			set 
			{
				rowHeaderDrawMode = value;
				InvalidateCells();
			}
		}
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(null),
		Description("ImageList를 설정합니다.")]
		public ImageList ImageList
		{
			get { return imageList;}
			set { imageList = value;}
		}
		/// <summary>
		/// 행 높이의 초기값을 가져오거나 설정합니다.
		/// 굴림체,굴림은 9F:21, 10F:22이나 MS UI Gothic은 9F : 19, 10F:21)
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(21),
		Description("행 높이의 초기값을 설정합니다.")]
		public virtual int DefaultHeight
		{
			get { return defaultHeight;}
			set { defaultHeight = Math.Max(this.MinHeight,value);}
		}
		/// <summary>
		/// RowHeader를 보여줄지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(false),
		Description("RowHeader를 보여줄지 여부를 설정합니다.")]
		public bool RowHeaderVisible
		{
			get { return rowHeaderVisible;}
			set 
			{ 
				if (rowHeaderVisible != value)
				{
					rowHeaderVisible = value;
					// 컬럼정보의 각 컬럼의 위치정보 변경
					ChangeGridByRowHeaderVisible();
				}
			}
		}
		/// <summary>
		/// 컬럼Header를 보여줄지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(true),
		Description("컬럼Header를 보여줄지 여부를 설정합니다.")]
		public bool ColHeaderVisible
		{
			get { return colHeaderVisible;}
			set 
			{ 
				if (colHeaderVisible != value)
				{
					colHeaderVisible = value;
					if (value) //Visible이면 AutoSizeHeight Header 조정로 조정
					{
						//DesignMode시 HeaderHeights 다시 설정
						int count = this.headerHeights.Count;
						if (this.DesignMode)
						{
							this.headerHeights.Clear();
							for (int i = 0 ; i < count ; i ++)
								this.headerHeights.Add(this.autoSizeHeight);
						}
						//Header Row의 Height 적용
						for (int i = 0 ; i < count ; i++)
							this.SetRowHeight(i, this.autoSizeHeight);

					}
					else
					{
						int count = this.headerHeights.Count;
						if (this.DesignMode)
						{
							this.headerHeights.Clear();
							for (int i = 0 ; i < count ; i ++)
								this.headerHeights.Add(0);
						}
						//Header Row의 Height 적용
						for (int i = 0 ; i < count ; i++)
							this.SetRowHeight(i, 0);
					}
				}
			}
		}
		/// <summary>
		/// RowHeader에 행번호를 보여줄지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(true),
		Description("RowHeader에 행번호를 보여줄지여부를 설정합니다.")]
		public bool ShowNumberAtRowHeader
		{
			get { return showNumberAtRowHeader;}
			set 
			{ 
				if (showNumberAtRowHeader != value)
				{
					showNumberAtRowHeader = value;
					// Visible속성에 따라 RowHeader에 Value SET
					ChangeGridByShowNumberAtRowHeader();
				}
				
			}
		}
		/// <summary>
		/// 행의 Vertical Line(컬럼구분 Line) 을 그릴지 여부를 지정합니다. 
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(true),
		Description("행의 Vertical Line(컬럼구분 Line) 을 그릴지 여부를 지정합니다. ")]
		public bool IsDrawRowVerticalLine
		{
			get { return isDrawRowVerticalLine;}
			set 
			{ 
				if (isDrawRowVerticalLine != value)
				{
					isDrawRowVerticalLine = value;
					this.InvalidateCells();
				}
			}
		}
		/// <summary>
		/// 행의 Horizontal Line(행구분 Line) 을 그릴지 여부를 지정합니다.
		/// </summary>
		[Category("Appearance"),
		MergableProperty(true),
		DefaultValue(true),
		Description("행의 Horizontal Line(행구분 Line) 을 그릴지 여부를 지정합니다. ")]
		public bool IsDrawRowHorizontalLine
		{
			get { return isDrawRowHorizontalLine; }
			set
			{
				if (isDrawRowHorizontalLine != value)
				{
					isDrawRowHorizontalLine = value;
					this.InvalidateCells();
				}
			}
		}
		#endregion

		#region Internal Properties
		/// <summary>
		/// 행의 Top,Height 정보를 관리하는 컬렉션입니다.
		/// </summary>
		[Browsable(false)]
		internal XCellRowInfoCollection CellRowInfo
		{
			get { return cellRowInfo;}
		}
		/// <summary>
		/// 컬럼의 Left, Width 정보를 관리하는 컬렉션입니다.
		/// </summary>
		[Browsable(false)]
		internal XCellColInfoCollection CellColInfo
		{
			get { return cellColInfo;}
		}
		/// <summary>
		/// Selected 된 Cell의 List를 가져옵니다.(Cell[])
		/// </summary>
		internal XCell[] MouseSelection
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

				XCell[] l_cells = new XCell[l_Count];

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
		/// 현재 Resizing하고 있는 Cell을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		internal XCell ResizingCell
		{
			get { return resizingCell;}
		}
		#endregion

		#region Properties not browsable
		[Browsable(false)]
		public DataTable LayoutTable
		{
			get { return layoutTable;}
		}
		/// <summary>
		/// 컬럼정보를 관리합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Editor(typeof(XGridCellEditor), typeof(UITypeEditor)),
		Bindable(true),
		Description("컬럼정보를 관리합니다.")]
		public virtual XGridCellCollection CellInfos
		{
			get { return cellInfos ;}
			set { cellInfos = value;}
		}
		/// <summary>
		/// Grid에 Sum,Average 등 Compute 컬럼을 추가할 때 정보를 관리합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public XGridComputedCellCollection ComputedCellInfos
		{
			get { return computedCellInfos ;}
			set { computedCellInfos = value;}
		}
		/// <summary>
		/// 추가된 Header의 정보를 관리합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Browsable(false)]
		public XGridGroupInfoCollection GroupInfos
		{
			get { return groupInfos;}
			set { groupInfos = value;}
		}
		/// <summary>
		/// 추가된 Header의 정보를 관리합니다.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Browsable(false)]
		public XGridHeaderCollection HeaderInfos
		{
			get { return headerInfos;}
			set { headerInfos = value;}
		}
		/// <summary>
		/// Focus가 있는 현재 Column의 ColNumber를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public int CurrentColNumber  // Focus가 있는 Column의 ColNumber
		{
			get
			{
				if (this.focusCell != null)
				{
					if (this.rowHeaderVisible)
						return this.focusCell.Col - 1;
					else
						return this.focusCell.Col;
				}
				else
					return -1;

			}
		}
		/// <summary>
		/// 현재 Grid의 상태를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public XGridStatus GridStatus
		{
			get { return gridStatus;}
		}
		/// <summary>
		/// 열높이 자동조정시 열의 높이를 가져오거나 설정합니다.
		/// 굴림체,굴림은 9F:21, 10F:22이나 MS UI Gothic은 9F : 19, 10F:21)
		/// </summary>
		[Browsable(false),
		DefaultValue(21)]
		public virtual int AutoSizeHeight
		{
			get	{return autoSizeHeight;}
			set {autoSizeHeight = value;}
		}
		/// <summary>
		/// 한개 DataRow를 몇개의 Line으로 Display할지 Line수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(1)]
		public int LinePerRow
		{
			get { return linePerRow;}
			set { linePerRow = value;}
		}
		/// <summary>
		/// 한 Line당 몇개의 컬럼을 Display할지 컬럼수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int ColPerLine
		{
			get { return colPerLine;}
			set { colPerLine = value;}
		}
		/// <summary>
		/// 추가된 Header의 Line수를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(0)]
		public int AddedHeaderLine
		{
			get { return addedHeaderLine;}
			set { addedHeaderLine = value;}
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
		public XCell FocusCell
		{
			get{return focusCell;}
		}
		/// <summary>
		/// 현재 Selected된 Cell의 Selection을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public XGridSelection Selection
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
		/// Header의 높이를 관리하는 리스트를 가져옵니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public virtual ArrayList HeaderHeights
		{
			get { return headerHeights;}
		}

		/// <summary>
		/// 최소 높이(각 Site의 Font크기에 맞추어 조정(9F:21, 10F:23)) 
		/// 굴림체,굴림은 9F:21, 10F:22이나 MS UI Gothic은 9F : 19, 10F:21)
		/// </summary>
		[Browsable(false)]
		protected virtual int MinHeight
		{
			get { return 21;}
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
		/// Grid가 에러상태인지 여부를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public bool HasError
		{
			get { return HasErrors;}
		}
		/// <summary>
		/// 현재 Mouse의 Pointer가 있는 Cell을 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public XCell UnderMouseCell
		{
			get { return CellUnderMouse;}
		}
		/// <summary>
		/// Grid에서 보여줄 ToolTipText를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string GridToolTipText
		{
			get{ return backContainer.ToolTipText;}
			set{ backContainer.ToolTipText = value;}
		}
		/// <summary>
		/// 편집가능여부를 가져오거나 설정합니다.
		/// </summary>
		[Browsable(false),
		DefaultValue(true)]
		public virtual bool ReadOnly
		{
			get{return readOnly;}
			set{readOnly = value;}
		}
		// MultiRecord의 현재 RowNumber : 물리적인 Row가 아닌 논리적인 Row
		/// <summary>
		/// Grid의 현재 RowNumber를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public int CurrentRowNumber
		{
			get
			{
				if ((this.focusCell != null) && 
					((focusCell.Personality == XCellPersonality.Content)||(focusCell.Personality == XCellPersonality.RowHeader)))
				{
					int linesPerRow = this.GetLinesPerRow();
					try
					{
						return ((this.focusCell.Row - this.addedHeaderLine - this.linePerRow 
							- GroupRowInfos.GetBelowGroupLineCount(false, this.focusCell.Row, linesPerRow))/linesPerRow);
					}
					catch
					{
						return -1;
					}
				}
				else
					return -1;
			}
		}
		/// <summary>
		/// 현재 Focus가 있는 컬럼의 컬럼명, Cell이 Content, ColHeader일때만 컬럼명을 Get
		/// </summary>
		[Browsable(false)]
		public string CurrentColName  
		{
			get
			{
				if ((this.focusCell != null) && 
					((focusCell.Personality == XCellPersonality.Content) || (focusCell.Personality == XCellPersonality.ColHeader)))
					return focusCell.CellName;
				else
					return "";
			}
		}
		
		/// <summary>
		/// Grid의 RowCount(Data의 갯수)를 가져옵니다.
		/// </summary>
		[Browsable(false)]
		public int RowCount
		{
			get 
			{
				try
				{
					return this.layoutTable.Rows.Count;
				}
				catch
				{
					return 0;
				}
			}
		}
		/// <summary>
		/// "Grid를 프린트할때 페이지설정을 관리합니다.
		/// </summary>
		[Browsable(false)]
		public PageSettings PageSettings
		{
			get { return pageSettings;}
		}
        /// <summary>
        /// 현재 Grid에 Display되고 있는 행의 갯수를 가져옵니다.
        /// </summary>
        [Browsable(false)]
        public int DisplayRowCount
        {
            get { return this.DisplayedRowCount; }
        }
        #endregion

		#region Properties Browsable
		[Category("데이타"),
		DefaultValue(""),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
		Editor(typeof(SQLEditor), typeof(UITypeEditor)),
		Description("Grid의 데이타를 조회할 SQL을 지정합니다.")]
		public string QuerySQL
		{
			get { return querySQL;}
			set 
			{
				querySQL = value;
				//RunTime시에 SQL에 포함된 bindVar 분석
				if (!this.DesignMode)
				{
					SQLHelper.InitBindVarList(querySQL, this.BindVarList);
				}
			}
		}

		[Category("데이타"),
		DefaultValue(false),
		Description("조회시 전체 데이타를 조회할지 여부를 지정합니다.")]
		public bool IsAllDataQuery
		{
			get { return isAllDataQuery;}
			set { isAllDataQuery = value;}
		}

		[Category("동작"),
		DefaultValue(false),
		Description("IDataControl과 데이타를 Bind할지 여부를 지정합니다.")]
		public bool ControlBinding
		{
			get { return controlBinding;}
			set { controlBinding = value;}
		}
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
		/// Row의 상태에 따라 Text색깔을 변경할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(false),
		Description("Row의 상태에 따라 Text색깔 변경여부를 관리합니다.")]
		public bool RowStateCheckOnPaint
		{
			get { return rowStateCheckOnPaint;}
			set { rowStateCheckOnPaint = value;}
		}
		/// <summary>
		/// Row의 상태에 따라 Text색깔을 변경할지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(false),
		Description("컬럼의 ApplyPaintingEvent 속성에 관계없이 전체컬럼에 GridCellPainting Event를 적용할지 여부를 지정합니다.")]
		public bool ApplyPaintEventToAllColumn
		{
			get { return applyPaintEventToAllColumn;}
			set { applyPaintEventToAllColumn = value;}
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
		/// <summary>
		/// ToolTip 활성화 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		MergableProperty(true),
		DefaultValue(XGridToolTipType.Data),
		Description("ToolTip 활성화시에 ToolTip에 보여줄 Text의 형식을 지정합니다.(Data:컬럼의 값, ColumnDesc :컬럼정보에서 설정한 ToolTipText를 보여줌)")]
		public XGridToolTipType ToolTipType
		{
			get { return this.toolTipType;}
			set { this.toolTipType = value;}
		}
		/// <summary>
		/// SelectionMode를 Header선택시에 변경할 수 있는지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(false),
		Description("SelectionMode를 Header선택시에 변경할 수 있는지 여부를 관리합니다.")]
		public bool SelectionModeChangeable
		{
			get { return selectionModeChangeable;}
			set { selectionModeChangeable = value;}
		}
		/// <summary>
		/// Selection Mode(Cell,Row,Col)를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(XGridSelectionMode.Row),
		Description("Grid의 선택모드를 지정합니다.(행단위,열단위,Cell단위)")]
		public XGridSelectionMode SelectionMode
		{
			get{return selectionMode;}
			set
			{
				selectionMode = value;
				//원 선택모드 보관
				this.origSelectionMode = value;
			}
		}
		/// <summary>
		/// Cursor가 Header에 있을때만 Resize 가능한지 여부를 가져오거나 설정합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(true),
		Description("Cursor가 Header에 있을때만 Resize 가능한지 여부를 관리합니다.")]
		public bool ResizableAtOnlyHeader
		{
			get { return resizableAtOnlyHeader;}
			set { resizableAtOnlyHeader = value;}
		}
		/// <summary>
		/// 컬럼의 Data에 따라 Height 자동조절이 가능한지 여부를 관리합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(false),
		Description("컬럼의 Data에 따라 Height 자동조절이 가능한지 여부를 관리합니다.")]
		public bool ApplyAutoHeight
		{
			get { return applyAutoHeight;}
			set { applyAutoHeight = value;}
		}
		/// <summary>
		/// 컬럼Header를 눌렀을때 언제 Sort를 적용할지 여부를 관리합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(XGridSortMode.DoubleClick),
		Description("컬럼헤더를 눌렀을때 언제 Sort를 적용할지 여부를 관리합니다.(SingleClick,DoubleClick)")]
		public XGridSortMode SortMode
		{
			get { return sortMode;}
			set { sortMode = value;}
		}
		/// <summary>
		/// 선택모드가 Row일때 Ctrl, Shift Key를 누르지 않은 상태에서 Click시 선택된 행을 Toggling할지여부를 관리합니다.
		/// </summary>
		[Category("동작"),
		DefaultValue(false),
		Description("선택모드가 Row일때 Ctrl, Shift Key를 누르지 않은 상태에서 Click시 선택된 행을 Toggling할지여부를 관리합니다.")]
		public bool TogglingRowSelection
		{
			get { return togglingRowSelection;}
			set { togglingRowSelection = value;}
		}
		/// <summary>
		/// LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.
		/// </summary>
		[Browsable(true),Category("동작"),DefaultValue(true),
		MergableProperty(true),
		Description("LayoutContainer(XScreen,XForm)의 Reset호출시에 Reset을 적용할지 여부를 지정합니다.")]
		public bool ApplyLayoutContainerReset
		{
			get { return applyLayoutContainerReset; }
			set { applyLayoutContainerReset = value;}
		}
		[Category("마스터관리"),
		DefaultValue(null),
		Description("이 Grid의 Master가 되는 Grid를 관리합니다.")]
		public IMasterLayout MasterLayout
		{
			get { return masterLayout;}
			set { masterLayout = value;}
		}
		#endregion

		#region this Property
		/// <summary>
		/// 지정된 row, col에 해당하는 Cell을 가져오거나 설정합니다.
		/// </summary>
		public XCell this[int row, int col]
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
		public XCell this[int rowNumber, string colName]
		{
			get
			{
				try
				{
					//지정한 행번호, 컬럼명에 해당하는 Cell return
					XGridCell info = this.CellInfoList[colName] as XGridCell;
					//컬럼 잘못 지정하거나 Visible한 컬럼이 아니면 Null
					if ((info == null) || !info.IsVisible) return null;
					//RowNumber를 잘못 지정하였으면 Null
					if ((rowNumber < 0) || (rowNumber >= this.DisplayedRowCount)) return null;
					// 논리적인 rowNum으로 물리적인 row Get
					// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
					int linesPerRow = this.GetLinesPerRow();
					int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
					int rowPos = 0, rowSpan = 0;
					//추가된 Header 행과 Design을 고려하여 rowPos 계산
					if (this.AddedHeaderLine > 0)
						this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow , out rowPos, out rowSpan);
					else
						rowPos = info.Row;
					row += rowPos;

					return Cells[row, info.Col];
				}
				catch
				{
					return null;
				}
			}
        }
        #endregion
        #region ExecuteQuery, ParamList

        public ExecuteQueryData ExecuteQuery
        {
            get { return executeQuery; }
            set { executeQuery = value; }
        }

        public List<string> ParamList
        {
            get { return paramList; }
            set
            {
                paramList = value;
                SQLHelper.InitBindVarListFromParamList(paramList, this.BindVarList);
            }
        }

        #endregion
		#region Protected virtual Methods (필요시 override)
		//해당 Row의 DataRowState Get (XGrid에서는 모두 Unchanged이며, CellGrid에서 해당 Row의 Table의 State에 따라 Get
		/// <summary>
		/// 현재 행의 DataRowState를 가져옵니다.
		/// </summary>
		/// <param name="row"> 현재 행</param>
		/// <returns> DataRowState Enum </returns>
		protected virtual DataRowState GetDataRowState(int row)
		{
			try
			{
				int linesPerRow = this.GetLinesPerRow();
				int rowNumber = ((row - this.addedHeaderLine - this.linePerRow 
					- GroupRowInfos.GetBelowGroupLineCount(false, row, linesPerRow))/linesPerRow);

				return this.layoutTable.Rows[rowNumber].RowState;
			}
			catch
			{
				return DataRowState.Unchanged;
			}
		}
		//CellGrid에서는 EditorStyle에 따라 다르게 구현함
		/// <summary>
		/// CellInfo에 따라 해당 Row에 값을 Setting합니다.
		/// </summary>
		/// <param name="info"> CellInfo (cell정보) </param>
		/// <param name="row"> Row 의 위치 </param>
		/// <param name="rowSpan"> RowSpan 값 </param>
		/// <param name="dataValue"> Cell의 Value </param>
		/// <param name="linesPerRow"> 한 행의 Line수 </param>
		protected virtual void DisplayCell(XGridCell info, int row, int rowSpan, object dataValue, int linesPerRow, int rowNumber)
		{
			if (info.IsVisible)
			{
				string displayText = this.GetDisplayTextByInfo(info, dataValue);
				// Grid Data Set
				this[row , info.Col] = CreateContentCell(info, dataValue,displayText, rowSpan, (rowNumber%2 == 1));
				this[row , info.Col].RowNumber = rowNumber;
				//Binary이면 Image Set
				if (info.CellType == XCellDataType.Binary)
					SetImageByBinaryData(this[row, info.Col], dataValue);
			}
		}
		/// <summary>
		/// CellFocusChange Event를 발생시킵니다.
		/// (Focus 변경시 Row의 값이 바뀌면 OnRowFocusChanged Invoker call)
		/// </summary>
		/// <param name="e"> CellEventArgs </param>
		protected virtual void OnCellFocusChange(XCell cell)
		{
			//DesignMode시도 적용
			if ((cell.Focused) || this.DesignMode)
			{
				//이전의 FocusCell, InnerChangeFocusCell에서 FocusCell 변경 
				XCell preFocusCell = this.focusCell;
				int nextRowNumber = GetLogicalRowNumber(cell.Row);
				//2005.09.21 Cell변경전에 OnRowFocusChaning Event Call
				if (((cell.Personality == XCellPersonality.Content) ||(cell.Personality == XCellPersonality.RowHeader))
					&& (nextRowNumber >= 0) && (nextRowNumber != this.PreRowNumber))
				{
					OnRowFocusChanging(new RowFocusChangingEventArgs(nextRowNumber, PreRowNumber));
				}

				InnerChangeFocusCell(cell);
				if (this.focusCell != null)
				{
					ShowCell(this.focusCell);
					int currRowNumber = this.CurrentRowNumber;
					int prevRowNumber = this.PreRowNumber;
					// RowNumber가 바뀌면 RowFocusChanged Event Call (RowHeader, Content 일때)
					if (((focusCell.Personality == XCellPersonality.Content) ||(focusCell.Personality == XCellPersonality.RowHeader)) 
						&& (currRowNumber >= 0) && (prevRowNumber != currRowNumber))
					{
						//선택영역 Toggling적용시
						if (this.togglingRowSelection && (this.selectionMode == XGridSelectionMode.Row))
						{
							//이전행이 선택된 상태가 아니면 이전 FocusCell의 Select Clear
							if (!IsSelectedRow(prevRowNumber) && (preFocusCell != null))
								preFocusCell.Select = false;
						}

						//preRowNumber 저장
						this.PreRowNumber = currRowNumber;
						OnRowFocusChanged(new RowFocusChangedEventArgs(prevRowNumber, currRowNumber));
					}
					//현재Cell이 Content일때 GridCellFocusChanged Event 발생시킴
					if ((focusCell.Personality == XCellPersonality.Content) && (currRowNumber >= 0))
					{
						OnGridCellFocusChanged(new XGridCellFocusChangedEventArgs(focusCell.CellName, currRowNumber));
					}
				}
			}
			else
			{
				InnerChangeFocusCell(cell);
			}
		}
		#endregion

		#region IDetailLayout Properties
		Hashtable IDetailLayout.RelationKeys
		{
			get { return relationKeys;}
		}
		string   IDetailLayout.RelationTableName
		{
			get { return this.relationTableName;}
		}

            public BindVarCollection BindVarList
            {
                get { return bindVarList; }
            }

            #endregion

		#region Public Methods
		/// <summary>
		/// Grid의 자료상태를 Reset(Not Modified 상태)합니다.
		/// </summary>
		public virtual void ResetUpdate()
		{
			if (this.LayoutTable == null) return;

			this.LayoutTable.AcceptChanges();

			if (this.OrigLayoutTable != null)
				this.OrigLayoutTable.AcceptChanges();
		}
		public virtual bool AcceptData()
		{
			//Bind된 Control의 AcceptData먼저 호출
			//Validation을 통과하지 못하면 false return
			if (!this.BindControlAcceptData()) return false;

			return true;
		}
		#endregion

		#region Private Methods
		// Resizing되는 Cell의 상태를 고려하여 새 너비로 행의 너비를 변경한다.
		private void SetColWidthByResizingCell(XCell resizeCell, int newWidth)
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

				// DesignMode에서 Resize시에 CellInfo의 CellWidth, XGridHeader의 HeaderWidth 변경
				if (DesignMode)
				{
                    IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                    /* .net 2003 context.OnComponentChanged() 만 Call하면 InitialzeComponent 에 변경된 Component의 속성이 반영
                    * .NET 2005 context.OnComponentChanged() Call로 반영안됨
                    * 따라서, 각 Compoent별로 Component가 변경됨을 Designer에 알려주어야 함.
                    */
                    //c.OnComponentChanging(this, null);
                    for (int i = 0; i < this.cellColInfo.Count; i++)
                    {
                        try
                        {
                            foreach (XGridHeader info in this.headerInfos)
                            {
                                if (info.Col == i)
                                {
                                    info.HeaderWidth = cellColInfo[i].Width;
                                    //.NET 2005 각 Info의 OnComponent Changed Call
                                    c.OnComponentChanged(info, null, null, null);
                                }
                            }
                            foreach (XGridCell info in this.cellInfos)
                            {
                                if (info.Col == i)
                                {
                                    info.CellWidth = cellColInfo[i].Width;
                                    c.OnComponentChanged(info, null, null, null);
                                }
                            }
                        }
                        catch { }
                    }
                    //c.OnComponentChanged(this, null, null, null);
				}
			}
		}
		// Resizing되는 Cell의 상태에 따라 새 행의 높이를 설정한다.
		private void SetRowHeightByResizingCell(XCell resizeCell , int newHeight)
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

				//DesignMode시 HeaderHeights 변경
				if (DesignMode)
				{
					IComponentChangeService c = (IComponentChangeService) GetService(typeof(IComponentChangeService));
					c.OnComponentChanging(this, null);
					//HeaderLines까지
					//for (int i = 0; i < cellRowInfo.Count ; i++)
					for (int i = 0; i < this.addedHeaderLine + this.linePerRow ; i++)
					{
						try
						{
							this.headerHeights[i] = cellRowInfo[i].Height;
						}
						catch{}
					}
					c.OnComponentChanged(this, null, null, null);
				}
			}
		}
		private XCell GetPaintCell(int emptyRow, int emptyCol)
		{
			XCell prevRowCell = null;
			XCell prevColCell = null;
			XCell paintCell = null;
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
		public Rectangle GetCellDisplayRectangle(XCell cell)
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
		public Rectangle GetCellAbsoluteRectangle(XCell cell)
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
				XCellColInfo l_ColInfo = this.cellColInfo[col];
				XCellRowInfo l_RowInfo = this.cellRowInfo[row];

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
			//Flag가 false이면 Scroll영역을 다시 설정하지 않음
			//VScrollBar에 의해 ContCall시에 Group영역 Remove에 의한 ContCall발생을 방지
			if (!this.isScrollReCalc) return;

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
					XCell tmp = Cells[row,col];

					tmp.Select = false; //deseleziono la cella (per evitare che venga rimossa senza essere stata aggiunta alla lista di selection
					tmp.LeaveFocus(); //tolgo l'eventuale focus dalla cella

					tmp.UnBindToGrid();

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
		protected virtual void InsertCell(int row, int col, XCell cell)
		{
			try
			{
				RemoveCell(row,col);
				Cells[row,col] = cell;
				if (cell != null)
				{
					if (cell.Grid != null)
						throw new ArgumentException("This cell already have a linked grid","cell");

					cell.Select = false; //deseleziono la cella (per evitare che venga rimossa senza essere stata aggiunta alla lista di selection
					cell.LeaveFocus(); //tolgo l'eventuale focus dalla cella
					
					cell.SelectionChange += new EventHandler(Cell_SelectionChange); 
					cell.Invalidated += new InvalidateEventHandler(Cell_Invalidated);
					cell.FocusChange += new EventHandler(Cell_FocusChange);

					cell.BindToGrid(this,row,col);

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
		protected void ShowCell(XCell cellToShow)
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
            //if (l_cellRect.Right > l_ClientRectangle.Width)
            //{
            //    l_newCustomScrollPosition.X -= l_cellRect.Right-l_ClientRectangle.Width;
            //    l_ApplyScroll = true;
            //}
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
		public virtual XCell CellAtPoint(Point relativeViewPoint)
		{
			Point l_AbsolutePoint = new Point(relativeViewPoint.X - GridScrollPosition.X, relativeViewPoint.Y - GridScrollPosition.Y);
			XCell l_tmp;

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
				XCellRowInfo l_RowInfo = cellRowInfo[r];
				if (l_RowInfo.Top <= l_AbsolutePoint.Y)
				{
					bool l_bIsInRow = (l_RowInfo.Top+l_RowInfo.Height >= l_AbsolutePoint.Y);

					for (int c = 0; c < this.cols; c++)
					{
						XCellColInfo l_ColInfo = cellColInfo[c];
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
			OnCellSelectionChange((XCell) sender);
		}
		//Cell의 Focus가 변경될때 Event Invoker Call
		private void Cell_FocusChange(object sender, EventArgs e)
		{
			OnCellFocusChange((XCell)sender);
		}
		// Cell을 다시 그린다.
		private void Cell_Invalidated(object sender, InvalidateEventArgs e)
		{
			if (Redraw)
				backContainer.Invalidate(e.InvalidRect,false);
		}
		// OnCellFocusChange 에서 Call되어 Focus Cell 변경
		private void InnerChangeFocusCell(XCell newCell)
		{
			int startRow, endRow, startCol, endCol;
			if (newCell == this.focusCell)
			{
				// Control, Shift Key를 누르지 않은 상태에서 Focus 변경시는 기존 선택영역 Clear
				if (((Control.ModifierKeys & Keys.Control) != Keys.Control) && ((Control.ModifierKeys & Keys.Shift) != Keys.Shift))
				{
					//선택모드가 Row일때 Row Toggling이면 RowHeader나  Content를 누를때는 OnMouseDown에서 Toggling하므로 
					//아닌 경우에만 선택영역 Clear
					if (!(this.togglingRowSelection && (this.selectionMode == XGridSelectionMode.Row) &&
						((newCell.Personality == XCellPersonality.RowHeader) ||(newCell.Personality == XCellPersonality.Content))))
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
					if ((this.focusCell != null) && (this.focusCell.Personality == XCellPersonality.ColHeader))
						this.selection.Clear(newCell);
					//선택모드가 Row일때 Row Toggling이면 RowHeader나  Content를 누를때는 OnMouseDown에서 Toggling하므로 
					//아닌 경우에만 선택영역 Clear
					else if (!(this.togglingRowSelection && (this.selectionMode == XGridSelectionMode.Row) && 
						((newCell.Personality == XCellPersonality.RowHeader)||(newCell.Personality == XCellPersonality.Content)))
						||(enableMultiSelection == false))
					{
						this.selection.Clear(newCell);
					}
				}
				
				bool applyRowSelect = true;
				if ((this.togglingRowSelection && (this.selectionMode == XGridSelectionMode.Row) &&
					((newCell.Personality == XCellPersonality.RowHeader) ||(newCell.Personality == XCellPersonality.Content))))
				{
					int currRowNumber = this.CurrentRowNumber;
					int newRowNumber = this.GetLogicalRowNumber(newCell.Row);
					if (newRowNumber >= 0)
					{
						//현재 Focus가 있는 행번호와 newCell의 행번호가 같을때 
						if (currRowNumber == newRowNumber)
						{
							//LeftMouseDown하여 Cell을 변경시
							if (this.isLeftMouseDown)
							{
								//현재행이 선택되어 있으면 UnSelect하고 Select 적용하지 않음
								if (this.IsSelectedRow(currRowNumber))
								{
									this.UnSelectRow(currRowNumber);
									applyRowSelect = false;
								}
							}
							else
							{
								//선택안된 상태이면 선택안된 상태 그대로 유지
								if (!this.IsSelectedRow(currRowNumber))
								{
									//부분선택된 Cell Clear
									this.UnSelectRow(currRowNumber);
									applyRowSelect = false;
								}
							}
						}
						else //행이 다를때 새행이 이미 선택되어 있으면 UnSelect하고 선택적용하지 않음
						{
							if (IsSelectedRow(newRowNumber))
							{
								this.UnSelectRow(newRowNumber);
								applyRowSelect = false;
							}
						}
					}

				}
				
				//LeftMouseDown Flag Clear
				this.isLeftMouseDown = false;

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
						if (this.SelectionMode == XGridSelectionMode.Row)
						{
							//Shift Key를 누른 상태에서 FocusCell변경시 두 Cell 사이의 영역도 SELECT
							if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) && (focusCell != null))
							{
								startRow = Math.Min(focusCell.Row, newCell.Row);
								//RowSpan을 고려 RowSpan영역에 있는 Row까지 모두 Select
								endRow   = Math.Max(focusCell.Row + focusCell.RowSpan - 1, newCell.Row + newCell.RowSpan - 1);
								for (int r = startRow ; r <= endRow ; r++)
									for(int c = 0;c < this.Cols ; c++)
										if (Cells[r, c] != null)
											Cells[r, c].Select = true;
									
							}
							else
							{
								if (applyRowSelect)
								{
									//newCell의 Row로 행번호 GET
									int rowNumber = this.GetLogicalRowNumber(newCell.Row);
									//해당 행 선택
									this.SelectRow(rowNumber);
								}
							}
						}
						else if (this.SelectionMode == XGridSelectionMode.Col)
						{
							//Shift Key를 누른 상태에서 FocusCell변경시 두 Cell 사이의 영역도 SELECT
							if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) && (focusCell != null))
							{
								startCol = Math.Min(focusCell.Col, newCell.Col);
								//ColSpan을 고려 ColSpan영역에 있는 Col까지 모두 Select
								endCol   = Math.Max(focusCell.Col + focusCell.ColSpan - 1, newCell.Col + newCell.ColSpan -1);
								for(int r = 0 ; r < this.Rows ; r++)
									for (int c = startCol ; c <= endCol ; c++)
										if (Cells[r, c] != null)
											Cells[r, c].Select = true;
							}
							else
							{
								//ColSpan을 고려 ColSpan영역에 있는 Col까지 모두 Select
								for(int r = 0 ; r < this.Rows ; r++)
									for (int c = newCell.Col ; c < newCell.Col + newCell.ColSpan ; c++)
										if (Cells[r, c] != null)
											Cells[r, c].Select = true;
							}
						}
						else   // Cell SelectionMode
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
				}
				// FocusCell 변경
				this.focusCell = newCell;
			}
		}
		/// <summary>
		/// Display된 Row의 값으로 DataTable와 관련된 논리적인 행번호 Return
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		private int GetLogicalRowNumber(int row)
		{
			if ((row < 0) || (row >= this.Rows)) return -1;
			try
			{
				int linesPerRow = this.GetLinesPerRow();
				return ((row - this.addedHeaderLine - this.linePerRow 
					- GroupRowInfos.GetBelowGroupLineCount(false, row, linesPerRow))/linesPerRow);
			}
			catch
			{
				return -1;
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
			// Header는 지정한 Width로 Set
			if (row < this.linePerRow + this.addedHeaderLine)
			{
				if (this.headerHeights.Count > row)
					cellRowInfo.Add(row,new XCellRowInfo(Int32.Parse(this.headerHeights[row].ToString()),l_Top));
				else
					cellRowInfo.Add(row,new XCellRowInfo(this.autoSizeHeight,l_Top));
			}
			else  //Content는 defaultHeight
				cellRowInfo.Add(row,new XCellRowInfo(defaultHeight,l_Top));

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

			// RowHeaderVisible일때는 col = 0에 cRowHeaderWidth로 SET
			if (this.rowHeaderVisible && (col == 0))
			{
				cellColInfo.Add(col, new XCellColInfo(cRowHeaderWidth, l_Left));
			}
				//Serialize되는 순서에 의해 cols가 먼저 설정되므로 colPerLine과 비교 RowHeaderWidth SET
			else if ((this.cols > this.colPerLine) && (col == 0))
			{
				cellColInfo.Add(col, new XCellColInfo(cRowHeaderWidth, l_Left));
			}
			else  // CellInfo의 Width로 SET
			{
				//CellInfo의 Width, 우선 없으면 XGridHeader Width로 Width Set
				XGridCell info = this.CellInfos.GetXGridCellByColIndex(col);
				if ( info != null)
					cellColInfo.Add(col,new XCellColInfo(info.CellWidth ,l_Left));
				else
				{
					XGridHeader hInfo = this.HeaderInfos.GetXGridHeaderByColIndex(col);
					if (hInfo != null)
						cellColInfo.Add(col,new XCellColInfo(hInfo.HeaderWidth,l_Left));
					else
						cellColInfo.Add(col,new XCellColInfo(DefaultWidth,l_Left));
				}
			}

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
				Cells = new XCell[rows,cols];
			}
			else
			{
				if ((rows != Rows) || (cols != Cols))
				{
					XCell[,] l_tmp = Cells;
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

					Cells = new XCell[rows,cols];

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
			XCell[] l_Cells = MouseSelection;
			// 이전 선택영역 Clear
			foreach (XCell c in oldMouseSelection)
				c.Select = false;

			// 새 선택영역 선택
			foreach (XCell c in l_Cells)
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
			oldMouseSelection = new XCell[0];
			StartMouseSelectionCell = null;
			EndMouseSelectionCell = null;
		}
		/// <summary>
		/// 선택영역을 변경합니다.
		/// </summary>
		/// <param name="cornerCell"> 선택영역에서 BottomRight Cell 객체 </param>
		protected void ChangeMouseSelectionCorner(XCell cornerCell)
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
		protected void ChangeCellUnderMouse(XCell changeCell)
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
        //<.NET 2005 Event 추가>
        private void BackContainer_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }
        private void BackContainer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }
        private void BackContainer_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.OnMouseCaptureChanged(e);
        }
        private void BackContainer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.OnPreviewKeyDown(e);
        }
		#endregion

		#region ParentIsILayoutContainer
		/// <summary>
		/// Parent Control이 ILayoutContainer인지 여부를 반환합니다.
		/// </summary>
		/// <param name="parent"> Parent Control </param>
		/// <param name="parentControl"> (out) Parent Control 개체 </param>
		/// <returns> ILayoutContainer이면 true, 아니면 false </returns>
		protected bool ParentIsILayoutContainer(Control parent, out Control parentControl)
		{
			parentControl = null;
			if(parent is ILayoutContainer)
			{
				parentControl = parent;
				return true;
			}
			else
			{
				if(parent.Parent != null)
					return ParentIsILayoutContainer(parent.Parent, out parentControl);
				else
					return false;
			}
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

			if (this.LayoutContainer == null)
			{
				Control parentControl = null;
				if (this.Parent != null)
				{
					// DataLayout Container의 Current DataLayout 초기화
					if(ParentIsILayoutContainer(this.Parent, out parentControl))
					{
						this.LayoutContainer = (ILayoutContainer) parentControl;
					}
				}
			}
			// Grid의 Parent가 IDataLayoutContainer(Screen) 이면
			if (this.LayoutContainer != null)
			{
				//Grid를 현재 MultiOutputLayout으로 설정
				LayoutContainer.CurrMQLayout = this;
			}
		}
		protected override void OnParentChanged(EventArgs e)
		{
			base.OnParentChanged(e);
			Control parentControl = null;
			if (this.Parent != null)
			{
				// DataLayout Container의 Current DataLayout 초기화
				if(ParentIsILayoutContainer(this.Parent, out parentControl))
				{
					this.LayoutContainer = (ILayoutContainer) parentControl;
					if (this.LayoutContainer.CurrMQLayout == null)
						this.LayoutContainer.CurrMQLayout = this;
				}
			}
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
			XCell paintCell = null;

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
				DataRowState rowState = DataRowState.Unchanged;
				//Draw non Fixed Rows, Cols
				for (int r = startRow; r <= endRow ; r++)
				{
					rowState = GetDataRowState(r);
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
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect,false,rowState);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else // RowSpan,ColSpan에 의해 Cell이 없는 경우는 Cell을 찾아 Paint
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false,rowState);
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
					rowState = GetDataRowState(r);
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
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect,false, rowState);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false, rowState);
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
					rowState = GetDataRowState(r);
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
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect,false, rowState);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false, rowState);
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
					rowState = GetDataRowState(r);

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
									Cells[r,c].InvokePaint(e, l_AbsoluteDrawRect, false,rowState);
									// ColSpan된 영역은 Skip
									if (Cells[r,c].ColSpan > 1)
										c += (Cells[r,c].ColSpan - 1);
								}
								else
								{
									paintCell = this.GetPaintCell(r,c);
									if (paintCell != null)
										paintCell.InvokePaint(e, l_AbsoluteDrawRect,false, rowState);
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

			XCell tmp = CellAtPoint(new Point(e.X,e.Y));
			XCell selectEndCell = null;
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
					if (e.Button == MouseButtons.Left && this.gridStatus == XGridStatus.Normal)
					{
						//선택영역 Toggling일때는 적용하지 않음(2004.08.20)
						if (!this.togglingRowSelection && enableMultiSelection)
						{
							// SelectionMode에 따라, endCell 변경, Row일때는 해당Row의 마지막 Column Cell
							// Col일때는 해당 Col의 마지막 Row Cell은 EndCell로 함
							switch(selectionMode)
							{
								case XGridSelectionMode.Cell:
									selectEndCell = tmp;
									break;
								case XGridSelectionMode.Row:
									try
									{
										selectEndCell = this[tmp.Row, this.Cols -1];
									}
									catch
									{
										selectEndCell = tmp;
									}
									break;
								case XGridSelectionMode.Col:
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
								if ((selectionMode != XGridSelectionMode.Cell) || (this.focusCell != selectEndCell))
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
					// ColHeader일때만 Resizing함
					//tmp의 Col이 0일때는 isDifX시는 ColResizing하지 않음
					//ColResizable일때만 Size 조정가능
					//Header일때만 Resize가능하면 ColHeader, RowHeader일때만 Resize가능
					//DesignMode시는 Property에 관계없이 Resize 가능
					if (DesignMode)
					{
						resizableColumn = true;
						resizableRow = true;
					}
					else
					{
						if (this.resizableAtOnlyHeader)
						{
							if (tmp.Personality == XCellPersonality.ColHeader)
								resizableColumn = true;
							else
								resizableColumn = false;
							if (tmp.Personality == XCellPersonality.RowHeader)
								resizableRow = true;
							else
								resizableRow = false;
						}
						else
						{
							resizableColumn = true;
							resizableRow = true;
						}
						if (!this.colResizable) resizableColumn = false;
						if (!this.rowResizable) resizableRow = false;
					}
					
					if(resizableColumn && ((isDifX && tmp.Col != 0) || isDifWidth))
					{
						this.Cursor = XGridImage.LeftRightCursor;
						this.gridStatus = XGridStatus.ColResizing;
						if(isDifX)
						{
							bool isHeader = (tmp.Personality == XCellPersonality.ColHeader ? true : false);
							bool isFounded = false;
							int  linesPerRow = 0;
							int  logicalRowNumber = 0;
							int	 headerLines = this.addedHeaderLine + this.linePerRow;
							int  searchMinRow = 0;
							int  searchMaxRow = 0;
							int  endCol = 0;
							if (this.rowHeaderVisible) endCol = 1;

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
									if (isHeader)
									{
										searchMinRow = 0;
										searchMaxRow = tmp.Row - 1;
									}
									else
									{
										linesPerRow = this.GetLinesPerRow();
										logicalRowNumber = (tmp.Row - headerLines)/linesPerRow;
										searchMinRow = headerLines + linesPerRow * logicalRowNumber;
										searchMaxRow = headerLines + linesPerRow * (logicalRowNumber + 1) - 1;

									}
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
						// Resizing해야할 Cell이 RowHeader이면 Resize하지 못함
						if ((this.resizingCell != null) && (this.resizingCell.Personality == XCellPersonality.RowHeader))
						{
							this.Cursor = System.Windows.Forms.Cursors.Default;
							this.gridStatus = XGridStatus.Normal;
						}

					}
						//RowResizing이 가능할때만 RowResizing상태로 변환
					else if(resizableRow && (isDifY || isDifHeight))
					{
						this.Cursor = XGridImage.UpDownCursor;
						this.gridStatus = XGridStatus.RowResizing;
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
						this.gridStatus = XGridStatus.Normal;
					}
				}
					// Resizing
				else if(e.Button == MouseButtons.Left)
				{
					if (this.gridStatus == XGridStatus.ColResizing)
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
					else if (this.gridStatus == XGridStatus.RowResizing)
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
					if (this.gridStatus == XGridStatus.ColResizing)
						this.ShowHideSpitPan(true, false, e.X, 0);
					else if (this.gridStatus == XGridStatus.RowResizing)
						this.ShowHideSpitPan(true, true, 0, e.Y);
				}
				else  // Clear
				{
					this.Cursor = System.Windows.Forms.Cursors.Default;
					this.gridStatus = XGridStatus.Normal;
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
			
				// Left Button, Normal상태일때 SelectionMode 변경
				if(e.Button == MouseButtons.Left && this.gridStatus == XGridStatus.Normal)
				{
					
					//LeftMouseDown Flag Set
					this.isLeftMouseDown = true;

					// Multi 선택이 가능, SelectionMode 변경가능시
					//SelectionMode가 Row, Col이면 Content Click시에 기존 SelectionMode 그대로 적용
					// DesignMode시는 제외
					if (!this.DesignMode && this.enableMultiSelection && this.selectionModeChangeable)
					{
						switch(MouseDownCell.Personality)
						{
							case XCellPersonality.ColHeader:
								this.selectionMode = XGridSelectionMode.Col;
								break;
							case XCellPersonality.RowHeader:
								this.selectionMode = XGridSelectionMode.Row;
								break;
							case XCellPersonality.Content:
								this.selectionMode = this.origSelectionMode;
								break;
							default:
								this.selectionMode = XGridSelectionMode.Cell;
								break;
						}

						//선택영역 Toggling적용(같은 Cell을 Click하면 CellFocusChange가 발생하지 않으므로
						//MouseDown에서 선택영역 Toggling적용
						if (this.focusCell == MouseDownCell)
						{
							//선택영역 Toggling적용시
							if (this.togglingRowSelection && (this.selectionMode == XGridSelectionMode.Row))
							{
								int currRowNumber = this.CurrentRowNumber;
								if (IsSelectedRow(currRowNumber))
									UnSelectRow(currRowNumber);
								else
									SelectRow(currRowNumber);
							}
						}

					}
				}
			}

			if(this.gridStatus == XGridStatus.RowResizing)
			{
				this.Cursor = XGridImage.UpDownCursor;
				if (e.Button == MouseButtons.Left)
					this.ShowHideSpitPan(true, true, 0, e.Y);
				else
					this.ShowHideSpitPan(false, true, 0, e.Y);
			}
			else if(this.gridStatus == XGridStatus.ColResizing)
			{
				this.Cursor = XGridImage.LeftRightCursor;
				if (e.Button == MouseButtons.Left)
					this.ShowHideSpitPan(true, false, e.X ,0);
				else
					this.ShowHideSpitPan(false, false, e.X ,0);
			}
			else  // Normal 상태
			{
				if ((e.Button == MouseButtons.Left) && MouseDownCell != null)
				{
					//DesignMode시 Focus변경
					if (DesignMode)
					{
						ISelectionService s = (ISelectionService) GetService(typeof(ISelectionService));
						ArrayList a = new ArrayList();

						// Cell 선택시에 관련 Component로 Selection 변경
						this.OnCellFocusChange(MouseDownCell);
						XGridCell info = this.CellInfoList[MouseDownCell.CellName] as XGridCell;
						if (info != null)
						{
							a.Add(info);
							// 구성요소 선택
							s.SetSelectedComponents(a);
							Invalidate();
						}
							// 추가된 Header가 Click되었을때 추가 Header정보로 Select변경
						else
						{
							XGridHeader hInfo = HeaderInfos[MouseDownCell.Tag];
							if (hInfo != null)
							{
								a.Add(hInfo);
								// 구성요소 선택
								s.SetSelectedComponents(a);
								Invalidate();
							}
							else
							{
								//ComputedCellInfo 검색
								XGridComputedCell cInfo = ComputedCellInfos[MouseDownCell.Tag];
								if (cInfo != null)
								{
									a.Add(cInfo);
									// 구성요소 선택
									s.SetSelectedComponents(a);
									Invalidate();
								}
							}
						}
					}
					else
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
			if(this.gridStatus == XGridStatus.ColResizing)
			{
				// 조정 Size가 최소값이상일때 Resize
				if(this.resizingCell != null)
					if (this.splitPan.Location.X - this.resizingCell.DisplayRectangle.X >= cResizingMin)
						this.SetColWidthByResizingCell(this.resizingCell, this.splitPan.Location.X - this.resizingCell.DisplayRectangle.X);
			}
			else if (this.gridStatus == XGridStatus.RowResizing)
			{
				// 조정 Size가 최소값이상일때 Resize
				if(this.resizingCell != null)
					if (this.splitPan.Location.Y - this.resizingCell.DisplayRectangle.Y >= cResizingMin)
						this.SetRowHeightByResizingCell(this.resizingCell, this.splitPan.Location.Y - this.resizingCell.DisplayRectangle.Y);
			}
			
			//Reset
			this.splitPan.Visible = false;
			this.resizingCell = null;
			this.gridStatus = XGridStatus.Normal;
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

				XCell tmp = null;
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
			// Row에 Cell 추가(의미없음)
//			for (int r = this.rows-1; r > (newRowPosition+newRowCount-1); r--)
//			{
//				for (int c = 0; c < this.cols; c++)
//				{
//					XCell tmp = Cells[r-newRowCount,c];
//					RemoveCell(r-newRowCount,c);
//					InsertCell(r,c,tmp);
//				}
//			}

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
					XCell tmp = Cells[r,c];
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

			// 컬럼추가(의미없음)
//			for (int c = this.cols-1; c > (newColPosition+newColCount-1); c--)
//			{
//				for (int r = 0; r < this.rows; r++)
//				{
//					XCell tmp = Cells[r,c-newColCount];
//					RemoveCell(r,c-newColCount);
//					InsertCell(r,c,tmp);
//				}
//			}

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
					XCell tmp = Cells[r,c];
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
			foreach(XGridCell info in this.CellInfos)
			{
				if (info.IsVisible)
					AutoSizeColumn(info.Col, info.CellWidth);
			}
			for (int r = 0; r < this.rows; r++)
			{
				//Header
				if ( r < this.linePerRow + this.addedHeaderLine)
					AutoSizeRow(r, Int32.Parse(this.headerHeights[r].ToString()));
					// Content (Default Height)
				else
					AutoSizeRow(r, this.defaultHeight);
			}
		}
		#endregion
		
		#region GetLinesPerRow Method
		//CellInfos를 고려한 1Row의 Line수 Return
		/// <summary>
		/// Grid의 모양을 고려한 한 Row의 Line수를 가져옵니다.
		/// </summary>
		/// <returns> 한 Row의 Line수 </returns>
		public int GetLinesPerRow()
		{
			int lines = 0;
			int rowPos = 0;
			int rowSpan = 1;
			int maxRowPos = -1;
			if (this.AddedHeaderLine <= 0)
				lines = this.LinePerRow;
			else
			{
				foreach(XGridCell info in this.CellInfos)
				{
					this.CellInfos.GetCellPositionByXGridCell(info, this.LinePerRow + this.AddedHeaderLine, out rowPos, out rowSpan);
					maxRowPos = Math.Max(maxRowPos, rowPos);
				}
				lines = maxRowPos + 1;
			}
			return lines;
		}
		#endregion

		#region InitailizeColumns Method
		/// <summary>
		/// 컬럼정보로 Grid를 초기화합니다.
		/// </summary>
		public virtual void InitializeColumns()
		{
			int infoCount = this.CellInfos.Count;
			int numberOfColumn = 0;
			//SupressRepeatingColumnList Clear
			this.supressColumnList.Clear();
			
			if (infoCount < 1)
			{
				this.Rows = 0;
				this.Cols = 0;
				this.FixedCols = 0;
				this.FixedRows = 0;
				return;
			}
			
			// 그리기 멈춤
			this.Redraw = false;

			//기존의 Cell 제거
			for (int r = 0 ; r < this.Rows ; r++)
				for (int c = 0 ; c < this.Cols ; c++)
					this[r,c] = null;
			
			//Column갯수 = RowHeaderVisible이면 한 Line당 컬럼수 +1, Not Visible이면 한 Line당 컬럼수
			if (this.rowHeaderVisible)
				numberOfColumn = this.ColPerLine + 1;
			else
				numberOfColumn = this.ColPerLine;

			this.Cols = numberOfColumn;

			//Row의 갯수는 LinePerRow + AddedHeaderLine
			//Row의 갯수는 Header의 갯수
			this.Rows = this.LinePerRow + this.AddedHeaderLine;
			this.FixedRows = this.LinePerRow + this.AddedHeaderLine;

			//RowHeaderVisible이면 FixedCols = 1로 SET
			if (this.rowHeaderVisible)
				this.FixedCols = 1;
			else
				this.FixedCols = 0;

			// HeaderHeights Set(추가된 Line만큼만 SET)
			for ( int i = this.headerHeights.Count ; i < this.Rows ; i++)
			{
				this.headerHeights.Add(this.autoSizeHeight);
			}
			// Rows가 더 작을때 기존의 정보 Clear
			int hCount = this.headerHeights.Count;
			for ( int i = this.Rows ; i < hCount ; i++)
				this.headerHeights.RemoveAt(this.Rows);

			//RowHeaderVisible이면 (0,0)에 RowHeader SET, RowSpan은 Header의 Line수만큼
			if (this.rowHeaderVisible)
			{
				this[0,0] = CreateRowHeaderCell("","", this.Rows);
			}
			
			//HeaderInfos로 ColHeaderCell Set
			foreach (XGridHeader info in this.HeaderInfos)
			{
				if ((info.Row < this.Rows) && (info.Col < this.Cols))
					this[info.Row, info.Col] = CreateColHeaderCell(info);
			}

			//컬럼정보 List Clear
			this.CellInfoList.Clear();
			//CellInfo Collection정보로 HeaderCell Set
			foreach (XGridCell info in this.CellInfos)
			{
				//Visible한 Column만 Set
				if (info.IsVisible)
				{
					if ((info.Row < this.Rows) && (info.Col < this.Cols))
					{
						this[info.Row, info.Col] = CreateColHeaderCell(info);
					}
				}
				//CellInfoList Set(Grid의 컬럼이 많은 경우 CellInfos[colName]으로 접근하면 속도가 느리다
				//따라서, Hashtable에 저장하여 검색속도를 향샹시킴
				this.CellInfoList.Add(info.CellName, info);
			}
			//DesignMode시 GroupBand, Footer, ComputedCell Add
			CreateGroupBand();
			CreateFooter();

			// 그리기시작
			this.Redraw = true;

			//DesignMode가 아니면 컬럼너비 다시 조정
			if(!this.DesignMode)
			{
				try
				{
					//GroupData List 초기화
					InitializeGroupDataList();

					// 컬럼너비 다시조정
					// Serialize되는 순서가 Cols가 먼저되고, 나중에 각 CellInfo의 값이 설정되므로 Width다시 조정해야함
					ArrayList columnPosList = new ArrayList();
					foreach (XGridCell info in CellInfos)
					{
						if (info.IsVisible)
						{
							SetColWidth(info.Col, info.CellWidth);
							columnPosList.Add(info.Col);
						}
					}
					// 이미 설정된 Col Position 외에 Width 변경
					foreach (XGridHeader info in HeaderInfos)
					{
						if (!columnPosList.Contains(info.Col))
							SetColWidth(info.Col, info.HeaderWidth);
					}

					//CellInfoParam으로 동적으로 변경시에 reportTable은 null이 아님.
					//이때는 컬럼 모두 삭제후 다시 컬럼 SET
					if (layoutTable == null)
						layoutTable = new DataTable(TABLE_NAME);
					else  //기존에 정의된 컬럼 Clear
						LayoutTable.Columns.Clear();  // 컬럼 Clear

					DataColumn dtCol;
					MaskType maskType;
					foreach (XGridCell info in this.CellInfos)
					{
						//DataColumn 생성, ColumnName 은 ColumnInfo 정보 참조
						dtCol = new DataColumn(info.CellName);
						dtCol.AllowDBNull = true;  // null 허용
						dtCol.DataType = GetColumnType(info.CellType);
						LayoutTable.Columns.Add(dtCol);
						//CellInfo의 MaskSymbols SET (Binary, StringPrefix5는 제외)
						if (info.CellType != XCellDataType.Binary)
						{
							try
							{

								info.MaskSymbols.Clear();
								maskType = (MaskType) Enum.Parse(typeof(MaskType), info.CellType.ToString());
								MaskHelper.SetMaskSymbols(maskType, info.Mask, info.MaskSymbols);
							}
							catch(Exception xe)
							{
								MessageBox.Show(info.CellType.ToString() + ",Error=" + xe.Message);
							}
						}
						//BindControl DataValidating Event Handling
						if (this.controlBinding && info.BindControl != null)
						{
							info.BindControl.DataValidating += new DataValidatingEventHandler(Grid_BindControlDataValidating);
						}
						//SupressRepeatingColumnList Set
						if (info.SuppressRepeating)
							this.supressColumnList.Add(info.CellName);
					}

					//OrigDataTable에 GridTable의 Copy본 저장
					this.OrigLayoutTable = this.LayoutTable.Copy();

					//RunTime시에 MasterGrid의 DetailLayouts에 Grid를 설정합니다.
					if (this.masterLayout != null)
						this.masterLayout.DetailLayouts.Add(this);
				}
				catch(Exception e)
				{
					string msg = XMsg.GetMsg("M049", e); // XGrid::InitializeColumns, 에러[" + e.Message + "]"
					ShowErrMsg(msg);
				}
			}
		}
		private void Grid_BindControlDataValidating(object sender, DataValidatingEventArgs e)
		{
			IDataControl bindCont = (IDataControl) sender;
			XGridCell cellInfo = null;
			int row = this.CurrentRowNumber;
			if ((this.RowCount > 0) && (row >= 0))
			{
				//Binding된 Control로 컬럼정보 GET
				foreach (XGridCell info in this.cellInfos)
				{
					if (info.BindControl == bindCont)
					{
						cellInfo = info;
						break;
					}
				}
				if (cellInfo == null) return;

				
				object dataValue = e.DataValue;
				// 원 Data와 BindControl의 Data가 다르면 Data Set
				if (!GetItemValue(row, cellInfo.CellName).Equals(dataValue))
				{
					this.SetItemValue(row, cellInfo.CellName, dataValue);
				}
			}
		}
		private Type GetColumnType(XCellDataType cellType)
		{
			Type type = typeof(string);
			switch (cellType)
			{
				//Date는 YYYYMMDD, DateTime은 YYYYMMDDHHMISS 형의 String으로 관리
				case XCellDataType.String :
				case XCellDataType.Date :  
				case XCellDataType.DateTime:
				case XCellDataType.Time :
					type = typeof(string);
					break;
				case XCellDataType.Number :  //Number,Decimal은 Double로 관리
				case XCellDataType.Decimal :
					type = typeof(double);
					break;
				case XCellDataType.Binary :
					type = typeof(object);
					break;
			}
			return type ;
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

		#region GetItem, SetItem, SetItemSub
		/// <summary>
		/// Cell(행번호, 컬럼명) 의 Data를 가져옵니다.
		/// </summary>
		/// <param name="rowNum"> 행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <returns> Cell의 값 </returns>
		[Description("Cell(행번호, 컬럼명) 의 Data를 가져옵니다.")]
		public virtual object GetItemValue(int rowNumber, string colName)
		{
			return GetItemValue(rowNumber, colName, DataBufferType.CurrentBuffer);
		}
		/// <summary>
		/// Cell(행번호, 컬럼명,원래값여부) 의 Data를 가져옵니다.
		/// </summary>
		/// <param name="rowNum"> 행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <param name="isOriginal"> 원래값 여부 </param>
		/// <returns> Cell의 값 </returns>
		[Description("Cell(행번호, 컬럼명,원래값여부) 의 Data를 가져옵니다.")]
		public virtual object GetItemValue(int rowNumber, string colName, bool isOriginal)
		{
			if (isOriginal)
				return GetItemValue(rowNumber, colName, DataBufferType.OriginalBuffer);
			else
				return GetItemValue(rowNumber, colName, DataBufferType.CurrentBuffer);
		}
		public object GetItemValue(int rowNumber, string colName, DataBufferType bufferType)
		{
			object data = DBNull.Value;
			string msg = "";
			if ((rowNumber < 0) || (rowNumber >= RowCount))
				return data;

			if (!this.CellInfoList.Contains(colName))
			{
				msg = XMsg.GetMsg("M041") + "[" + colName + "]" + XMsg.GetMsg("M042"); //"컬럼명[" + colName + "]을 잘못지정하셨습니다."
				XMessageBox.Show(msg, "GetItemValue");
				return data;
			}
			try
			{
				DataRow dtRow = this.LayoutTable.Rows[rowNumber];
				switch (dtRow.RowState)
				{
					case DataRowState.Added:
						if (bufferType == DataBufferType.CurrentBuffer) // 현재값
							data = dtRow[colName];
						else if (bufferType == DataBufferType.OriginalBuffer) //Added상태는 원래값과 현재값이 동일함.
							data = dtRow[colName];
						else // 이전값
							data = dtRow[colName, DataRowVersion.Current];
						break;
					case DataRowState.Unchanged:
					case DataRowState.Modified:
						if (bufferType == DataBufferType.CurrentBuffer) // 현재값
							data = dtRow[colName];
						else if (bufferType == DataBufferType.OriginalBuffer) //원래값
							data = dtRow[colName, DataRowVersion.Original];
						else // 이전값
							data = dtRow[colName, DataRowVersion.Current];
						break;
				}
			}
			catch(Exception xe)
			{
				XMessageBox.Show("GetItemValue Error[" + xe.Message + "]", "GetItemValue");
				data = DBNull.Value;
			}
            //2010.05.25 김민수 추가 - 바인딩시 date 타입에 'yyyy/MM/dd' 형태로 들어가도록..
            XGridCell cellinfo = this.CellInfoList[colName] as XGridCell;
            if ((cellinfo.CellType == XCellDataType.Date) && (TypeCheck.IsDateTime(data)))
                data = DateTime.Parse(data.ToString()).ToString("yyyy/MM/dd").Replace("-", "/");
            //data = ((DateTime) data).ToString("yyyy/MM/dd").Replace("-","/");
            else if ((cellinfo.CellType == XCellDataType.DateTime) && (TypeCheck.IsDateTime(data)))
                data = DateTime.Parse(data.ToString()).ToString("yyyy/MM/dd HH:mm:ss").Replace("-", "/");
            return data;
		}
		/// <summary>
		/// Cell(행번호, 컬럼명) 의 Data를 설정합니다.
		/// </summary>
		/// <param name="rowNum"> 행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <param name="data"> 설정할 값 </param>
		/// <returns> 성공시 1, 실패시 -1 </returns>
		[Description("Cell(행번호, 컬럼명) 의 Data를 설정합니다.")]
		public virtual bool SetItemValue(int rowNumber, string colName, object data)
		{
			if ((rowNumber < 0) || (rowNumber >= this.RowCount)) return false;

			int rowPos = 0;
			int rowSpan = 0;
			int row = 0;
			int linesPerRow = this.GetLinesPerRow();
			string displayText = string.Empty;
			//해당 Cell에 Data Set
			XGridCell info = this.CellInfoList[colName] as XGridCell;
			try
			{
				//원 데이타와 값이 다를 경우에만 설정
				if (!this.LayoutTable.Rows[rowNumber][colName].Equals(data))
				{
					//BinaryType의 경우 Image로 데이타 설정시에 byte[]로 Convert하여 Data 관리
					//2006.02.20 Date,DateTime형일때 Data가 DateTime형이면 string으로 변환하여 SET
					if (info.CellType == XCellDataType.Binary)
						data = ConvertBinaryData(data);
					else if ((info.CellType == XCellDataType.Date) && (data is DateTime))  
						data = ((DateTime) data).ToString("yyyy/MM/dd").Replace("-","/");
					else if ((info.CellType == XCellDataType.DateTime) && (data is DateTime))  
						data = ((DateTime) data).ToString("yyyy/MM/dd HH:mm:ss").Replace("-","/");

					//Binary 데이타의 경우 Image는 byte[]로 변환하여 Data 관리
					this.LayoutTable.Rows[rowNumber][colName] = data ;
					//원 DataTable에서 SET
					//필터링중이면 RowIndexList에서 행번호를 구하여 SET, 아니면 RowNum 적용
					if (this.IsFiltering)
						this.OrigLayoutTable.Rows[(int) this.OrigTableRowIndexList[rowNumber]][colName] = data;
					else
						this.OrigLayoutTable.Rows[rowNumber][colName] = data;

					//2006.07.13 BindControl 반영
					//SetItemValue시에 BindControl이 있으면 BindControl의 값도 변경처리
					if (this.controlBinding && info.BindControl != null)
						info.BindControl.DataValue = data;
				}

				if ((info != null) && info.IsVisible)
				{
					// 논리적인 rowNum으로 물리적인 row Get
					// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
					row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
					if (this.AddedHeaderLine > 0)
						this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow , out rowPos, out rowSpan);
					else
						rowPos = info.Row;
					row += rowPos;
					
					//SubCall
					SetItemSub(info, row, data);
				}
			}
            //catch (Exception e)
   			catch
            {
                //To do
                //string msg = "SetItemValue(" + rowNumber.ToString() + ", " + colName +"), Error[" + e.Message + "]";
                //ShowErrMsg(msg);
				return false;
			}
			return true;
		}
		private object ConvertBinaryData(object data)
		{
			try
			{
				//Binary Type의 경우 Image를 설정하면 byte[]로 변환하여 데이타를 설정하기 위해 Convert
				if (data is byte[])
					return data;
				else if (data is Image)
				{
					using (MemoryStream ms = new MemoryStream())
					{
						Image img = (Image) data;
						img.Save(ms, img.RawFormat);
						return ms.ToArray();
					}
				}
				else
					return DBNull.Value;
			}
			catch
			{
				return DBNull.Value;
			}
		}
		//CellGrid에서는 DisplayText까지 Setting함
		/// <summary>
		/// 컬럼정보를 이용 Cell의 값을 설정합니다.
		/// </summary>
		/// <param name="info"> XGridCell 객체(컬럼정보) </param>
		/// <param name="row"> 행번호 </param>
		/// <param name="data"> 설정할 값 </param>
		protected virtual void SetItemSub(XGridCell info, int row, object data)
		{
			XCell cell = this[row, info.Col];
			if (cell != null)
			{
				//Binary이면 Image Set
				if (info.CellType == XCellDataType.Binary)
				{
					cell.Value = data;
					SetImageByBinaryData(this[row, info.Col], data);
				}
				else
				{
					cell.Value = data;
					//DisplayText Set
					cell.DisplayText = this.GetDisplayTextByInfo(info, data);
				}
			}
		}
		#endregion

		#region GetItemString, GetItemInt, GetItemLong, GetItemDouble, GetItemDateTime
		public virtual string GetItemString(int rowNumber, string colName)
		{
			return GetItemValue(rowNumber, colName).ToString();
		}
		public virtual string GetItemString(int rowNumber, string colName, bool isOriginal)
		{
			return GetItemValue(rowNumber, colName, isOriginal).ToString();
		}
		public virtual string GetItemString(int rowNumber, string colName, DataBufferType bufferType)
		{
			return GetItemValue(rowNumber, colName, bufferType).ToString();
		}
		public virtual int GetItemInt(int rowNumber, string colName)
		{
			try
			{
				return Int32.Parse(GetItemValue(rowNumber, colName).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M005"); // [GetItemInt]데이타가 Int형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual int GetItemInt(int rowNumber, string colName, bool isOriginal)
		{
			try
			{
				return Int32.Parse(GetItemValue(rowNumber, colName, isOriginal).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M005"); // [GetItemInt]데이타가 Int형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual int GetItemInt(int rowNumber, string colName, DataBufferType bufferType)
		{
			try
			{
				return Int32.Parse(GetItemValue(rowNumber, colName, bufferType).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M005"); // [GetItemInt]데이타가 Int형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual long GetItemLong(int rowNumber, string colName)
		{
			try
			{
				return Int64.Parse(GetItemValue(rowNumber, colName).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M006"); // [GetItemLong]데이타가 Long형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual long GetItemLong(int rowNumber, string colName, bool isOriginal)
		{
			try
			{
				return Int64.Parse(GetItemValue(rowNumber, colName, isOriginal).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M006"); // [GetItemLong]데이타가 Long형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual long GetItemLong(int rowNumber, string colName, DataBufferType bufferType)
		{
			try
			{
				return Int64.Parse(GetItemValue(rowNumber, colName, bufferType).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M006"); // [GetItemLong]데이타가 Long형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual double GetItemDouble(int rowNumber, string colName)
		{
			try
			{
				return double.Parse(GetItemValue(rowNumber, colName).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M007"); // [GetItemDouble]데이타가 Double형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual double GetItemDouble(int rowNumber, string colName, bool isOriginal)
		{
			try
			{
				return double.Parse(GetItemValue(rowNumber, colName, isOriginal).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M007"); // [GetItemDouble]데이타가 Double형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual double GetItemDouble(int rowNumber, string colName, DataBufferType bufferType)
		{
			try
			{
				return double.Parse(GetItemValue(rowNumber, colName, bufferType).ToString());
			}
			catch
			{
				string msg = XMsg.GetMsg("M007"); // [GetItemDouble]데이타가 Double형이 아닙니다."
				throw(new Exception(msg));
			}
		}
		public virtual DateTime GetItemDateTime(int rowNumber, string colName)
		{
			return GetItemDateTimeSub(colName, GetItemValue(rowNumber, colName));
		}
		public virtual DateTime GetItemDateTime(int rowNumber, string colName, bool isOriginal)
		{
			return GetItemDateTimeSub(colName, GetItemValue(rowNumber, colName, isOriginal));
		}
		public virtual DateTime GetItemDateTime(int rowNumber, string colName, DataBufferType bufferType)
		{
			return GetItemDateTimeSub(colName, GetItemValue(rowNumber, colName, bufferType));
		}
		private DateTime GetItemDateTimeSub(string colName, object dataValue)
		{
			string msg = XMsg.GetMsg("M008"); // [GetItemDateTime]데이타가 DateTime형이 아닙니다."
			string data ="";
			try
			{
				if (dataValue.GetType() == typeof(DateTime))
					return (DateTime) dataValue;
				else if (dataValue.GetType() == typeof(string))
				{
					//Date형(YYYY/MM/DD), DateTime형(YYYY/MM/DD HH:MI:00, YYYY/MM/DD HH:MI:SS)
					//2005.11.10 Date형의 Data는 YYYY/MM/DD형으로 DateTime의 데이타는 YYYY/MM/DD HH:MI:SS 으로 관리함
					XGridCell  cellInfo = this.CellInfoList[colName] as XGridCell;
					data = dataValue.ToString();
					if (cellInfo.CellType == XCellDataType.Date)
					{
						if (TypeCheck.IsDateTime(data)) 
						{
							return DateTime.Parse(data);
						}
						else if (data.Length == 8)  //YYYYMMDD 형 (현재는 YYYYMMDD로 관리하지 않음)
						{
							data = data.Substring(0,4) + "/" + data.Substring(4,2) + "/" + data.Substring(6);
							if (TypeCheck.IsDateTime(data))
								return DateTime.Parse(data);
							else
								throw(new Exception(msg));	
						}
						else
							throw(new Exception(msg));
					}
					else if (cellInfo.CellType == XCellDataType.DateTime)
					{
						if (TypeCheck.IsDateTime(data)) 
						{
							return DateTime.Parse(data);
						}
						if (data.Length == 14)  //YYYYMMDDHHMISS형
						{
							data = data.Substring(0,4) + "/" + data.Substring(4,2) + "/" + data.Substring(6,2)
								+ " " + data.Substring(8,2) + ":" + data.Substring(10,2) + ":" + data.Substring(12);
							if (TypeCheck.IsDateTime(data))
								return DateTime.Parse(data);
							else
								throw(new Exception(msg));
						}
						else if (data.Length == 12) //YYYYMMDDHHMI형
						{
							data = data.Substring(0,4) + "/" + data.Substring(4,2) + "/" + data.Substring(6,2)
								+ " " + data.Substring(8,2) + ":" + data.Substring(10,2) + ":00";
							if (TypeCheck.IsDateTime(data))
								return DateTime.Parse(data);
							else
								throw(new Exception(msg));
						}
						else
							throw(new Exception(msg));
					}
					else
					{
						//Data의 형식이 다름 에러
						throw(new Exception(msg));
					}
				}
				else
				{
					//Data의 형식이 다름 에러
					throw(new Exception(msg));
				}
			}
			catch
			{
				throw(new Exception(msg));
			}
		}
		#endregion

		#region GetNextCell, GetPrevCell ,GetCellByCellInfo Method
		/// <summary>
		/// 행번호와 컬럼정보로 해당 Cell을 가져옵니다.
		/// </summary>
		/// <param name="info"> CellInfo 객체(컬럼정보) </param>
		/// <param name="rowNumber"> 행번호 </param>
		/// <returns> Cell 객체 </returns>
		[Description("RowNumber와 Cell정보로 해당 Cell을 가져옵니다.")]
		public XCell GetCellByCellInfo(XGridCell info , int rowNumber)
		{
			int rowPos = 0;
			int rowSpan = 0;
			int row = 0;
			int linesPerRow = this.GetLinesPerRow();
			if ((info == null) || (rowNumber >= this.RowCount) || (rowNumber < 0)) return null;
			if (!info.IsVisible) return null;
			//논리적인 rowNumber를 물리적인 row로 변경
			if (this.AddedHeaderLine > 0)
				this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
			else
				rowPos = info.Row;
			
			// AddedHeader수 + Header수 + GroupRow의 Line수 + rowNumber*한Row의 Line수 + rowPos
			row = (this.AddedHeaderLine + this.LinePerRow 
				+ this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow)) + rowNumber*linesPerRow + rowPos;
			// row, yPos 위치의 Cell Return
			return this[row, info.Col];

		}
		/// <summary>
		/// 지정한 Cell의 다음 Cell을 가져옵니다.
		/// </summary>
		/// <param name="currentCell"> 현재 Cell </param>
		/// <returns> 다음 Cell </returns>
		[Description("현재 Cell의 다음 Cell을 가져옵니다.")]
		public XCell GetNextCell(XCell currentCell)
		{
			XCell nextCell = null;
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
			// RowHeaderVisible이면 RowHeader 제외 첫번째 컬럼
			if (this.rowHeaderVisible) startCol = 1;

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
		public XCell GetPrevCell(XCell currentCell)
		{
			XCell prevCell = null;
			int startCol = 0;
			if (currentCell == null) return null;

			// RowHeaderVisible이면 RowHeader 제외 첫번째 컬럼
			if (this.rowHeaderVisible) startCol = 1;

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
			XCell moveCell = null;
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
			ExportSub(false, true, false);
		}
		/// <summary>
		/// Excel로 보기
		/// </summary>
		/// <param name="onlyDisplayedColumn"> Display되는 컬럼만 Export 여부 </param>
		public virtual void ShowToExcel(bool onlyDisplayedColumn)
		{
			ExportSub(false, true, onlyDisplayedColumn);
		}
		/// <summary>
		/// Export
		/// </summary>
		/// <param name="runExcel"> Excel Run 여부 </param>
		public virtual void Export(bool runExcel)
		{
			ExportSub(true,true, false);
		}
		public virtual void Export()
		{
			ExportSub(true,false, false);
		}
		/// <summary>
		/// Export
		/// </summary>
		/// <param name="runExcel"> Excel Run 여부 </param>
		/// <param name="onlyDisplayedColumn"> Display되는 컬럼만 Export 여부 </param>
		public virtual void Export(bool runExcel, bool onlyDisplayedColumn)
		{
			ExportSub(true, runExcel, onlyDisplayedColumn);
		}
		protected virtual void ExportSub(bool isSaveFile, bool runExcel, bool onlyDisplayedColumn)
		{
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

				//2005.11.22 onlyDisplayedColumn 속성 반영 (true이면 컬럼List중에서 visible한 컬럼만 SET 
				int colCount = this.LayoutTable.Columns.Count;
				ArrayList dispColList = new ArrayList();
				if (onlyDisplayedColumn)
				{
					foreach (XGridCell info in this.CellInfos)
						if (info.IsVisible)
							dispColList.Add(info.CellName);
					//컬럼의 갯수는 보여지는 컬럼의 갯수
					colCount = dispColList.Count;
				}
				else  //DataTable에 있는 모든 컬럼을 dispColList에 SET
				{
					foreach (DataColumn dtCol in this.LayoutTable.Columns)
						dispColList.Add(dtCol.ColumnName);
				}
				if (colCount == 0) return;

                newCulture = new System.Globalization.CultureInfo(excelApp.LanguageSettings.get_LanguageID(Office.MsoAppLanguageID.msoLanguageIDUI));
                System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;


				Excel.Workbook theWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
				Excel.Worksheet theWorkSheet = (Excel.Worksheet)theWorkBook.Worksheets[1];
				int rowCount = this.LayoutTable.Rows.Count;
				int colIndex = 0;
				int rowIndex = 0;
				Excel.Range theRange = theWorkSheet.Cells.get_Range(GetExcelIndexToLetter(0) + "1", GetExcelIndexToLetter(colCount -1) + (rowCount + 1).ToString());

				//Header 포함 Row의 갯수 + 1
				object[,] dataArray = new object[rowCount + 1, colCount];

				progress.SetProgressValue(20);
				
				//Header 설정 (있으면 설정, 없으면 컬럼명으로 설정)
				//Date,DataTime형 컬럼 List Date형이면 Y, DateTime형이면 T
				Hashtable dateColunmList = new Hashtable();
				ArrayList	colNameList = new ArrayList();  //컬럼명 SET
				XGridCell cellInfo = null;
				object data = DBNull.Value;
				string colName = "";
				//foreach (DataColumn dtCol in this.LayoutTable.Columns)
				foreach (string columnName in dispColList)
				{
					cellInfo = this.cellInfos[columnName];
					if (cellInfo == null)
					{
						dataArray[0, colIndex] = columnName;
						if (this.layoutTable.Columns[columnName].DataType == typeof(DateTime))
							dateColunmList.Add(columnName, "T");
					}
					else
					{
						if (cellInfo.HeaderText != "")
							dataArray[0, colIndex] = cellInfo.HeaderText;
						else
							dataArray[0, colIndex] = columnName;

						//Date형,DateTime형 컬럼 SET
						if (cellInfo.CellType == XCellDataType.Date)
							dateColunmList.Add(columnName, "Y");
						else if (cellInfo.CellType == XCellDataType.DateTime)
							dateColunmList.Add(columnName, "T");
					}
					colIndex++;
					//컬럼명 List에 Add
					colNameList.Add(columnName);
				}
				
				//Data 설정
				foreach (DataRow dtRow in this.LayoutTable.Rows)
				{
					rowIndex++;

					for (int i = 0 ; i < colCount ; i++)
					{
						colName = colNameList[i].ToString();
						data = dtRow[i];
						if (dateColunmList.Contains(colName))
						{
							if (dateColunmList[colName].ToString() == "Y") //Date형 YYYYMMDD형 -> YYYY/MM/DD형으로
							{
								try
								{
									if (data == DBNull.Value)
										dataArray[rowIndex, i] = string.Empty;
									else
									{
										//Date형은 YYYY/MM/DD로 관리함
										if (TypeCheck.IsDateTime(data))
											dataArray[rowIndex, i] = data;
										else  //YYYYMMDD 형
											dataArray[rowIndex, i] = data.ToString().Substring(0,4) + "/" + data.ToString().Substring(4,2) + "/" + data.ToString().Substring(6,2);
									}
								}
								catch
								{
									dataArray[rowIndex, i] = string.Empty;
								}
							}
							else //DateTime형 YYYY/MM/DD HH:MI:SS
							{
								try
								{
									if (data == DBNull.Value)
										dataArray[rowIndex, i] = string.Empty;
									else
										dataArray[rowIndex, i] = ((DateTime)data).ToString("yyyy/MM/dd HH:mm:ss");
								}
								catch
								{
									dataArray[rowIndex, i] = string.Empty;
								}
							}
						}
						else
						{
							dataArray[rowIndex, i] = data.ToString();
						}

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
		#endregion

        #region Events
        /// <summary>
        /// 데이타 유효성검사가 진행될 때 발생하는 Event입니다.
        /// </summary>
        [Browsable(true), Category("추가이벤트"),
        Description("데이타 유효성검사가 진행될 때 발생합니다."), Localizable(false)]
        public event EventHandler PreEndInitializing;
        #endregion

		#region ISupportInitialize Implementation
		/// <summary>
		/// 초기화가 시작됨을 개체에 알립니다.
		/// </summary>
		public virtual void BeginInit()
		{
		}
		/// <summary>
		/// 초기화 종료시 컬럼을 초기화(InitializeColumns)합니다.
		/// </summary>
		public virtual void EndInit()
		{
		    if (PreEndInitializing != null && !DesignMode)
		    {
		        PreEndInitializing(this, new EventArgs());
		    }
			this.InitializeColumns();
		}
		#endregion

		#region OnRowFocusChanged, OnGridColumnPainting, OnCleared, OnGridColumnChanged
		//GridCellPainting이 Event Handling되고 있는지 여부
		//있으면 XCell의 InvokePaint에서 XGridCellEventArgs를 만들어 Handling하고 없으면 Handling하지 않음
		internal bool ExistGridCellPaintingEvent()
		{
			if (this.GridCellPainting != null)
				return true;
			return false;
		}
		//XCell의 Paint시에 값에따른 색깔,폰트변경시 Call
		internal void CallGridCellPainting(XGridCellPaintEventArgs e)
		{
			OnGridCellPainting(e);
		}
		protected virtual void OnGridCellPainting(XGridCellPaintEventArgs e)
		{
			if (this.GridCellPainting != null)
				GridCellPainting(this,e);
		}
		protected virtual void OnGridColumnChanged(GridColumnChangedEventArgs e)
		{
			if (GridColumnChanged != null)
				this.GridColumnChanged(this, e);
		}
		/// <summary>
		/// RowFocusChanged Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"> RowFocusChangedEventArgs </param>
		protected virtual void OnRowFocusChanged(RowFocusChangedEventArgs e)
		{

			//BindControl에 Value Set
			this.SetBindControlDataValue(e.CurrentRow);

			//RowHeaderVisible이고, RowHeader에 RowNumber를 Display하고 있으면
			//현재Row의 Font를 굵게, 이전 Row은 원상태로 복구
			if (RowHeaderVisible && ShowNumberAtRowHeader)
			{
				int currRow = this.focusCell.Row;
				int prevRow = 0;
				if (e.CurrentRow > e.PreviousRow)
				{
					for (int i = currRow - 1 ; i >= 0 ; i--)
					{
						if ((this[i,0] != null) && (this[i,0].Personality == XCellPersonality.RowHeader) && this[i,0].Value.Equals(e.PreviousRow + 1))
						{
							prevRow = i;
							break;
						}
					}
				}
				else
				{
					for (int i = currRow + 1 ; i < this.rows ; i++)
					{
						if ((this[i,0] != null) && (this[i,0].Personality == XCellPersonality.RowHeader) && this[i,0].Value.Equals(e.PreviousRow + 1))
						{
							prevRow = i;
							break;
						}
					}
				}
				//Font 변경
				if (this[currRow,0] != null)
				{
					this[currRow,0].Font = this.CurrentRowHeaderFont;
					this[currRow,0].ForeColor = this.CurrentRowForeColor;
				}
				else
				{
					for (int i = currRow -1 ; i > 0 ; i--)
					{
						if (this[i,0] != null)
						{
							this[i,0].Font = this.CurrentRowHeaderFont;
							this[i,0].ForeColor = this.CurrentRowForeColor;
							break;
						}
					}
				}
				if (this[prevRow,0] != null)
				{
					this[prevRow,0].Font = this.rowHeaderFont;
					this[prevRow,0].ForeColor = this.RowHeaderForeColor;
				}
				
			}

			if (RowFocusChanged != null)
				RowFocusChanged(this, e);
		}
		/// <summary>
		/// RowFocusChanging Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnRowFocusChanging(RowFocusChangingEventArgs e)
		{
			if (this.RowFocusChanging != null)
				RowFocusChanging(this, e);
		}
		protected virtual void OnGridCellFocusChanged(XGridCellFocusChangedEventArgs e)
		{
			if (this.GridCellFocusChanged != null)
				GridCellFocusChanged(this,e);
		}
		/// <summary>
		/// GridSorted Event 발생
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnGridSorted(EventArgs e)
		{
			if (this.GridSorted != null)
				GridSorted(this, e);
		}

		/// <summary>
		/// GridDataDisplayed Event 발생
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnGridDataDisplayed(EventArgs e)
		{
			if (this.GridDataDisplayed != null)
				GridDataDisplayed(this, e);
		}
		/// <summary>
		/// GridContDisplayed Event 발생
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnGridContDisplayed(XGridContDisplayedEventArgs e)
		{
			if (this.GridContDisplayed != null)
				GridContDisplayed(this, e);
		}
		/// <summary>
		/// GridFilterChanged Event 발생
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnGridFilterChanged(EventArgs e)
		{
			if (this.GridFilterChanged != null)
				GridFilterChanged(this, e);
		}
		/// <summary>
		/// QueryStarting Event 발생(Bind 변수 SET)
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnQueryStarting(CancelEventArgs e)
		{
			if (this.QueryStarting != null)
				QueryStarting(this, e);
		}
		//2007.11.08 QueryEnd Invoker 추가
		protected virtual void OnQueryEnd(QueryEndEventArgs e)
		{
			if (this.QueryEnd != null)
				QueryEnd(this, e);
		}
		#endregion

		#region ModifyOtherColumnInfos
		/// <summary>
		/// 변경된 컬럼정보로 다른 관련정보를 변경합니다.
		/// </summary>
		/// <param name="cellInfos"> XGridCellCollection (컬럼정보 컬렉션) </param>
		/// <returns> Group관련 정보가 변경되었으면 true, 아니면 false </returns>
		internal bool ModifyOtherColumnInfos(XGridCellCollection cellInfos)
		{
			//DesignMode시만 적용됨
			if (!DesignMode) return false;

			ArrayList colNameList = new ArrayList();
			ArrayList expInfoList = new ArrayList();
			bool groupChanged = false;
			int endCol = this.LinePerRow;
			int linesPerRow = this.GetLinesPerRow();
			if (this.rowHeaderVisible) endCol +=1;

			foreach (XGridCell info in cellInfos)
				colNameList.Add(info.CellName);

			//ComputedCellInfo의 Expression에 사용된 colName List 작성
			ArrayList compInfoList = new ArrayList();
			ArrayList groupInfoList = new ArrayList();

			foreach(XGridGroupInfo info in this.GroupInfos)
			{
				// info의 컬럼List에 있는 컬럼이 컬럼List에 없으면 삭제할 List에 Add
				for (int i = 0 ; i < info.ColumnList.Count ; i++)
				{
					if (!colNameList.Contains(info.ColumnList[i]))
					{
						groupInfoList.Add(info);
						break;
					}
				}
			}
			//삭제할 List가 있으면 컬렉션에서 Remove
			for (int i = 0 ; i < groupInfoList.Count ; i++)
			{
				groupChanged = true;
				this.GroupInfos.Remove((XGridGroupInfo) groupInfoList[i]);
			}
			
			string errMsg = "";
			foreach(XGridComputedCell info in this.ComputedCellInfos)
			{
				//Expression이 잘못 되었으면 해당 info 삭제 List에 추가
				//Expression에 지정한 컬럼이 없거나, XCellDataType과 Function이 Match되지 않는 경우
				if (!XGridUtility.VerifyExpression(this.cellInfos, info.Expression, out errMsg))
				{
					MessageBox.Show(errMsg, "Verify Expression");
					compInfoList.Add(info);
				}

				//Group명이 GroupInfos에 없으면 삭제 List에 Add, 단 All은 Footer이므로 제외
				if ((info.GroupName != XGridUtility.FooterGroupName) && !GroupInfos.Contains(info.GroupName))
					if (!compInfoList.Contains(info))
						compInfoList.Add(info);
			}
			//삭제할 List가 있으면 컬렉션에서 Remove
			for (int i = 0 ; i < compInfoList.Count ; i++)
			{
				groupChanged = true;
				this.ComputedCellInfos.Remove((XGridComputedCell) compInfoList[i]);
				IDesignerHost host = (IDesignerHost) GetService(typeof(IDesignerHost));
				host.DestroyComponent((XGridComputedCell) compInfoList[i]);
			}

			//ComputedCellInfo 의 info.Row + info.RowSpan > linesPerRow이면 RowSpan조정
			//ComputedCellInfo 의  info.Col + info.ColSpan > endCol이면 ColSpan조정
			foreach (XGridComputedCell info in ComputedCellInfos)
			{
				if (info.Row + info.RowSpan > linesPerRow)
					info.RowSpan = Math.Max(1, linesPerRow - info.Row);
				if (info.Col + info.ColSpan > endCol)
					info.ColSpan = Math.Max(1, endCol - info.Col);
			}
			return groupChanged;
		}
		#endregion

		#region SortRangeRows
		protected internal bool SortRangeRows(bool isAsc, string cellName)
		{
			//Data가 있을 경우에만 Sort
			if (this.RowCount < 1) return false;

			string msg = "";
			//조회미완료시는 Sort불가
			if (!this.IsQueryCompleted)
			{
				msg = XMsg.GetMsg("M052"); // 조회미완료된 상태에서는 Sort할 수 없습니다."
				ShowErrMsg(msg);
				return false;
			}
			//필터링중에는 Sort불가
			if (this.IsFiltering)
			{
				msg = XMsg.GetMsg("M053"); // 필터링중에는 Sorting할 수 없습니다."
				ShowErrMsg(msg);
				return false;
			}

			XGridCell cellInfo = this.CellInfoList[cellName] as XGridCell;
			bool result = true;

			if (cellInfo == null) return false;

			//Binary DataType은 Sort불가
			if (cellInfo.CellType == XCellDataType.Binary) return false;

			// Sort가 가능한 컬럼이 아니면 Sort불가
			if (!cellInfo.EnableSort) return false;

			//원데이타를 TempTable에 Copy
			DataTable tempTable = this.LayoutTable.Copy();

			try
			{
				//TempTable Sort
				if (isAsc)
				{
					tempTable.DefaultView.Sort = cellName + " ASC";
				}
				else
				{
					tempTable.DefaultView.Sort = cellName + " DESC";
				}
				//GridTable Clear
				this.LayoutTable.Rows.Clear();
				//Sorting된 Row를 기준으로 GridTable을 다시 채움
				foreach (DataRowView rowView in tempTable.DefaultView)
					this.LayoutTable.ImportRow(rowView.Row);

				//원 DataTable을 GridTable과 동일하게 설정
				this.OrigLayoutTable = this.LayoutTable.Copy();

				//기존 Displayed Cell Clear
				this.Reset(false);

				DisplayDataSub(0,FIRST_DISP_COUNT,false);

				//GridSorted Event 발생
				if (this.GridSorted != null)
					OnGridSorted(EventArgs.Empty);

			}
			catch(Exception xe)
			{
				msg = "SortRangeRows Error[" + xe.Message + "]";
				ShowErrMsg(msg);
				result = false;
			}
			return result;
		}
		#endregion

		#region Sort
		public virtual bool Sort(string sortNotation)
		{
			//Sort 표기법은 "컬럼명 ASC(DESC) {, 컬럼명 ASC(DESC) }
			//DataView의 Sort속성은 2개의 컬럼만 지정가능 (3개이상은 적용되지 않음)
			//Data가 있을 경우에만 Sort
			if (this.RowCount < 1) return true;
			
			string msg = "";
			//조회미완료시는 Sort불가
			if (!this.IsQueryCompleted)
			{
				msg = XMsg.GetMsg("M052"); // 조회미완료된 상태에서는 Sort할 수 없습니다."
				ShowErrMsg(msg);
				return false;
			}
			//필터링중에는 Sort불가
			if (this.IsFiltering)
			{
				msg = XMsg.GetMsg("M053"); // 필터링중에는 Sorting할 수 없습니다."
				ShowErrMsg(msg);
				return false;
			}

			try
			{
				//원데이타를 TempTable에 Copy
				DataTable tempTable = this.LayoutTable.Copy();
				
				//TempTable의 DefaultView에 Sort 적용
				//Notation이 이상하면 Exception 발생
				tempTable.DefaultView.Sort = sortNotation;

				//GridTable Clear
				this.LayoutTable.Rows.Clear();
				//Sorting된 Row를 기준으로 GridTable을 다시 채움
				foreach (DataRowView rowView in tempTable.DefaultView)
					this.LayoutTable.ImportRow(rowView.Row);

				//원 DataTable을 GridTable과 동일하게 설정
				this.OrigLayoutTable = this.LayoutTable.Copy();

				//기존 Displayed Cell Clear
				this.Reset(false);

				DisplayDataSub(0, FIRST_DISP_COUNT, false);

				//GridSorted Event 발생
				if (this.GridSorted != null)
					OnGridSorted(EventArgs.Empty);
			}
			catch(Exception xe)
			{
				msg = "Sort Error["+ xe.Message + "]";
				ShowErrMsg(msg);
				return false;
			}
			return true;
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

		#region ChangeGrid (Property변경에 따른 Grid변경)
		/// <summary>
		/// RowHeader Visible에 따라 Grid의 모양을 변경합니다.
		/// </summary>
		protected virtual void ChangeGridByRowHeaderVisible()
		{
			bool changeCol = false;

			// Rows,Cols 0이면 Return
			if ((this.Rows == 0) || (this.Cols == 0)) return;

			//RowHeaderVisible이면 컬럼정보중 Col = 0인 컬럼이 있으면 컬럼위치 + 1
			//!RowHeaderVisible이면 컬럼정보중 Col = 0인 컬럼이 없으면 컬럼위치 -1
			if (rowHeaderVisible)
			{
				// this[0,0]가 RowHeader이면 변경하지 않음
				if ((this[0,0] != null) && (this[0,0].Personality == XCellPersonality.RowHeader)) return;

				foreach (XGridCell info in this.cellInfos)
				{
					if (info.IsVisible && (info.Col == 0))
					{
						changeCol = true;
						break;
					}
				}
				if (!changeCol)
				{
					foreach (XGridHeader info in this.headerInfos)
					{
						if (info.Col == 0)
						{
							changeCol = true;
							break;
						}
					}
				}
			}
			else
			{
				// this[0,0]가 RowHeader가 아니면 변경하지 않음
				if ((this[0,0] != null) && (this[0,0].Personality != XCellPersonality.RowHeader)) return;

				changeCol = true;
				foreach (XGridCell info in this.cellInfos)
				{
					if (info.IsVisible && (info.Col == 0))
					{
						changeCol = false;
						break;
					}
				}
				if (changeCol)
				{
					foreach (XGridHeader info in this.headerInfos)
					{
						if (info.Col == 0)
						{
							changeCol = false;
							break;
						}
					}
				}
			}

			// 그리기 중지
			this.Redraw = false;

			// 기존 Data, CellColInfo 보관
			XCell[,] bfCells = new XCell[Rows, Cols];
			for (int r = 0 ; r < this.Rows ; r++)
				for (int c = 0; c < this.Cols ; c++)
					bfCells[r,c] = this[r,c];

			XCellRowInfoCollection bfRowInfos = new XCellRowInfoCollection();
			// 단순 복사를 하면 Rows = 0, Cols = 0시에 복사된 개체의 Left와 Top이 변경되므로 Deep Copy
			foreach (XCellRowInfo info in this.CellRowInfo)
				bfRowInfos.Add(new XCellRowInfo(info.Height, info.Top));
			int bfRows = this.Rows;
			int bfCols = this.Cols;
			int headerLines = this.LinePerRow + this.AddedHeaderLine; // ColHeader의 Line수
			int linesPerRow = this.GetLinesPerRow();  // 한 Row의 Line 수
			int dispRowNumber = 0;
			int modifier = 0;
			int groupLineCnt = 0;

			this.Rows = 0;
			this.Cols = 0;
			this.FixedRows = 0;

			//1.컬럼정보의 Col 위치조정(true이면 +1, false 이면 -1)
			//2.추가Header정보의 Col위치조정(true이면 +1, false 이면 -1)
			//3.ComputedCellInfo의 Col위치 조정
			if (rowHeaderVisible)
			{
                if (changeCol && DesignMode)
                {
                    IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                    /* .net 2003 context.OnComponentChanged() 만 Call하면 InitialzeComponent 에 변경된 Component의 속성이 반영
                    * .NET 2005 context.OnComponentChanged() Call로 반영안됨
                    * 따라서, 각 Compoent별로 Component가 변경됨을 Designer에 알려주어야 함.
                    */
                    foreach (XGridCell info in this.cellInfos)
                    {
                        if (info.IsVisible)
                        {
                            info.Col += 1;
                            //.NET 2005 각 Info의 OnComponent Changed Call
                            c.OnComponentChanged(info, null, null, null);
                        }
                    }
                    foreach (XGridHeader info in this.headerInfos)
                    {
                        info.Col += 1;
                        //.NET 2005 각 Info의 OnComponent Changed Call
                        c.OnComponentChanged(info, null, null, null);
                    }
                    foreach (XGridComputedCell info in this.computedCellInfos)
                    {
                        info.Col += 1;
                        //.NET 2005 각 Info의 OnComponent Changed Call
                        c.OnComponentChanged(info, null, null, null);
                    }
                }

				this.Rows = bfRows;
				this.Cols = bfCols + 1;
				this.FixedRows = this.LinePerRow + this.AddedHeaderLine;
				//CellRowInfo조정
				this.CellRowInfo.AddRange(bfRowInfos.ToArray());

				//Scroll영역 다시 설정
				RecalculateScrollBar();

				// Grid에 Cell SET 
				for (int r = 0; r < this.Rows ; r++)
				{
					if (r >= headerLines)
					{
						groupLineCnt = this.GroupRowInfos.GetBelowGroupLineCount(false, r, linesPerRow);
						// Logical한 DataRow Number = (Row - Header의 Line수 - GroupRow의 Line수)/한 Row의 Line 수
						// 행번호 Display시는 +1 -> Excel처럼 0번째행이 1로 보이게 함
						dispRowNumber =  (r - headerLines - groupLineCnt)/linesPerRow + 1;
						// Modifier 한 Row의 Line수가 1이 아닐때 modifier != 0가 아니면 RowHeader추가하지 않음
						// 0인 위치에 RowHeader추가후 RowPad를 함
						modifier  =  (r - headerLines - groupLineCnt)%linesPerRow;
					}
					for (int c = 0; c < this.Cols ; c++)
					{
						// ColHeader위치에 RowHeader 추가 (0,0 RowHeader Set)
						if ((r == 0) && (c == 0))
						{
							this[r,c] = CreateRowHeaderCell("","", headerLines);
						}
							// Row에 RowHeader추가, DesignMode시 GroupBand,Footer에는 RowHeader추가하지 않음
							// r이 GroupRow에 속하면 RowHeader추가하지 않음
							// DesignGrid이면 RowHeader추가하지 않음
						else if ((r >= headerLines) && (c == 0))
						{
							if (!DesignMode && (modifier == 0) && !GroupRowInfos.IsInGroupLine(r, linesPerRow))
							{
								// 행번호를 RowHeader에 보이면 Value를 행번호로 SET
								if (this.showNumberAtRowHeader)
									this[r,c] = CreateRowHeaderCell(dispRowNumber.ToString(), dispRowNumber.ToString(), linesPerRow);
								else // Cell의 이름만 행번호로 SET
									this[r,c] = CreateRowHeaderCell(dispRowNumber.ToString(), "", linesPerRow);
							}
						}
							// c = 1 ~ Cols 까지 기존 Cell Set
						else if (c > 0)
						{
							this[r,c] = bfCells[r, c -1];
							if (this[r,c] != null)
								this[r,c].Col = c;
						}
					}
				}
			}
			else
			{
                if (changeCol && DesignMode)
                {
                    IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                    /* .net 2003 context.OnComponentChanged() 만 Call하면 InitialzeComponent 에 변경된 Component의 속성이 반영
                    * .NET 2005 context.OnComponentChanged() Call로 반영안됨
                    * 따라서, 각 Compoent별로 Component가 변경됨을 Designer에 알려주어야 함.
                    */
                    foreach (XGridCell info in this.cellInfos)
                    {
                        if (info.IsVisible)
                        {
                            info.Col -= 1;
                            //.NET 2005 각 Info의 OnComponent Changed Call
                            c.OnComponentChanged(info, null, null, null);
                        }
                    }
                    foreach (XGridHeader info in this.headerInfos)
                    {
                        info.Col -= 1;
                        //.NET 2005 각 Info의 OnComponent Changed Call
                        c.OnComponentChanged(info, null, null, null);
                    }
                    foreach (XGridComputedCell info in this.computedCellInfos)
                    {
                        info.Col -= 1;
                        //.NET 2005 각 Info의 OnComponent Changed Call
                        c.OnComponentChanged(info, null, null, null);
                    }
                }
				this.Rows = bfRows;
				this.Cols = bfCols - 1;
				this.FixedRows = this.LinePerRow + this.AddedHeaderLine;
				//CellRowInfo 조정
				this.CellRowInfo.AddRange(bfRowInfos.ToArray());
				//Scroll영역 다시 설정
				RecalculateScrollBar();

				// Grid에 Cell SET (기존 Col = 1 -> 0 Col로 SET)
				for (int r = 0; r < this.Rows ; r++)
				{
					for (int c = 0; c < this.Cols ; c++)
					{
						this[r,c] = bfCells[r, c + 1];
						if (this[r,c] != null)
							this[r,c].Col = c;
					}
				}
			}
			// 다시 그리기
			this.Redraw = true;
		}
		/// <summary>
		/// RowHeader에 행번호 보여주기여부에 따라 Grid의 모양을 변경합니다.
		/// </summary>
		protected virtual void ChangeGridByShowNumberAtRowHeader()
		{
			// 그리기 중단
			this.Redraw = false;

			// RowHeader가 Visible일때만 변경
			if (rowHeaderVisible)
			{
				if (showNumberAtRowHeader)
				{
					// RowHeader의 Value를 해당 CellName으로 SET, CellName에 Display할 번호가 있음
					for (int r = 0 ; r < this.Rows ; r++)
						if ((this[r,0] != null) && (this[r,0].Personality == XCellPersonality.RowHeader))
							this[r,0].Value = this[r,0].CellName;
				}
				else
				{
					// RowHeader의 Value를 RESET
					for (int r = 0 ; r < this.Rows ; r++)
						if ((this[r,0] != null) && (this[r,0].Personality == XCellPersonality.RowHeader))
							this[r,0].Value = "";
				}
			}
			// 그리기 시작
			this.Redraw = true;
			
		}
		#endregion

		#region Image Set Methods
		/// <summary>
		/// CheckBox형 Column의 Image를 설정합니다.
		/// </summary>
		/// <param name="cell"> Image를 설정할 Cell 개체 </param>
		/// <param name="isChecked"> Check형 여부 </param>
		/// <param name="text"> Cell에 Display할 Text </param>
		protected virtual void SetCheckStyleCellImage(XCell cell, bool isChecked, string text)
		{
			// Cell의 Image를 Checked이면 CheckIcon, 없으면 UnCheckIcon으로 SET
			// Text가 있으면 Align은 Left, 없으면 Center
			if (text != "")
				cell.ImageAlignment = ContentAlignment.MiddleLeft;
			else
				cell.ImageAlignment = ContentAlignment.MiddleCenter;
			if (isChecked)
				cell.Image = DrawHelper.CheckIcon;
			else
				cell.Image = DrawHelper.UnCheckIcon;
		}
		/// <summary>
		/// MemoBox형 Column의 Image를 설정합니다.
		/// </summary>
		/// <param name="cell"> Image를 설정할 Cell 개체 </param>
		protected virtual void SetMemoStyleCellImage(XCell cell, bool textDisplay)
		{
			//내용이 있으면 FullMemoImage, 없으면 EmptyMemoImage SET
			cell.ImageAlignment = ContentAlignment.MiddleCenter;
			if (cell.Value == null)
				cell.Image = XGridImage.EmptyMemo;
			else if (cell.Value.ToString() == "")
				cell.Image = XGridImage.EmptyMemo;
			else
			{
				cell.Image = XGridImage.FullMemo;
				//Text를 Display해야하면 데이타가 있을때 (Image Left Align)
				if (textDisplay)
					cell.ImageAlignment = ContentAlignment.MiddleLeft;
			}
		}
		/// <summary>
		/// Binary Data(byte[])로 Cell의 Image를 설정합니다.
		/// </summary>
		/// <param name="cell"> Image를 설정할 Cell </param>
		/// <param name="data"> byte[] 형식의 Data </param>
		protected virtual void SetImageByBinaryData(XCell cell, object data)
		{
			try
			{
				if (data == null) return;
				if (data is Image)
				{
					cell.ImageStretch = false;
					cell.ImageAlignment = ContentAlignment.MiddleCenter;
					cell.Image = (Image) data;
				}
				else if (data is byte[])
				{
					byte[] binaryBuffer = data as byte[];
					if (binaryBuffer.Length > 0)
					{
						MemoryStream ms = new MemoryStream(binaryBuffer, false);
						cell.ImageStretch = false;
						cell.ImageAlignment = ContentAlignment.MiddleCenter;
						cell.Image = Image.FromStream(ms);
					}
					else
						cell.Image = null;
				}
			}
			catch{}
		}
		#endregion

		#region CreateCell Methods, IsAlteratRow Methods
		/// <summary>
		/// 물리적인 row가 논리적인 교대로 반복되는 행인지 여부를 가져옵니다.
		/// </summary>
		/// <param name="linesPerRow"> 한 행의 Line 수 </param>
		/// <param name="row"> 물리적인 Cell의 Row</param>
		/// <returns> 교대로 반복되는 행이면 true, 아니면 false </returns>
		protected virtual bool IsAlterateRow(int linesPerRow, int row)
		{
			if (linesPerRow < 1) return false;
			// Header영역이면 false
			if (row < (this.addedHeaderLine + this.linePerRow)) return false;
			// row - HeaderLine수 - GroupRow의 Line수
			if (((row - this.addedHeaderLine - this.linePerRow - this.GroupRowInfos.GetBelowGroupLineCount(false, row, linesPerRow))/linesPerRow)%2 == 1)
				return true;
			else
				return false;
		}
		/// <summary>
		/// 컬럼정보로 ColHeaderCell을 생성합니다.
		/// </summary>
		/// <param name="info"> 컬럼정보를 관리하는 CellInfo 개체 </param>
		/// <returns> ColHeadrCell 개체 </returns>
		protected virtual XColHeaderCell CreateColHeaderCell(XGridCell info)
		{
			XColHeaderCell cell = new XColHeaderCell(info.CellName, info.HeaderText);
			cell.RowSpan = info.RowSpan;
			cell.ColSpan = info.ColSpan;
			cell.DrawMode = info.HeaderDrawMode;
			cell.Font = info.HeaderFont;
			cell.BackColor = info.HeaderBackColor;
			cell.GradientStart = info.HeaderGradientStart;
			cell.GradientEnd = info.HeaderGradientEnd;
			cell.TextAlignment = info.HeaderTextAlign;
			cell.ForeColor = info.HeaderForeColor;
			cell.Image = info.HeaderImage;
			cell.ImageAlignment = info.HeaderImageAlign;
			cell.ImageStretch = info.HeaderImageStretch;
			cell.SelectedBackColor = info.SelectedBackColor;
			cell.SelectedForeColor = info.SelectedForeColor;
			cell.IsDesignMode = this.DesignMode;
			//ToolTipType이 ColumnDesc이면 cell의 ToolTipText를 컬럼정보의 ToolTipText로 설정
			if (this.ToolTipType == XGridToolTipType.ColumnDesc)
				cell.ToolTipText = info.ToolTipText;
			return cell;
		}
		/// <summary>
		/// 추가 Header 정보로 ColHeaderCell을 생성합니다.
		/// </summary>
		/// <param name="info"> 추가 Header정보를 관리하는 XGridHeader 개체 </param>
		/// <returns> ColHeaderCell 개체 </returns>
		protected virtual XColHeaderCell CreateColHeaderCell(XGridHeader info)
		{
			XColHeaderCell cell = new XColHeaderCell("",info.HeaderText, true);
			cell.RowSpan = info.RowSpan;
			cell.ColSpan = info.ColSpan;
			cell.DrawMode = info.HeaderDrawMode;
			cell.Font = info.HeaderFont;
			cell.BackColor = info.HeaderBackColor;
			cell.GradientStart = info.HeaderGradientStart;
			cell.GradientEnd = info.HeaderGradientEnd;
			cell.TextAlignment = info.HeaderTextAlign;
			cell.ForeColor = info.HeaderForeColor;
			cell.Image = info.HeaderImage;
			cell.ImageAlignment = info.HeaderImageAlign;
			cell.ImageStretch = info.HeaderImageStretch;
			cell.Tag = info.Identifier;
			cell.SelectedBackColor = info.SelectedBackColor;
			cell.SelectedForeColor = info.SelectedForeColor;
			cell.IsDesignMode = this.DesignMode;
			return cell;
		}
		/// <summary>
		/// RowHeaderCell을 생성합니다.
		/// </summary>
		/// <param name="cellName"> Cell의 이름 </param>
		/// <param name="cellValue"> Cell의 Value </param>
		/// <param name="rowSpan"> Cell의 RowSpan </param>
		/// <returns> RowHeaderCell 개체 </returns>
		protected virtual XRowHeaderCell CreateRowHeaderCell(string cellName, object cellValue, int rowSpan)
		{
			XRowHeaderCell cell = new XRowHeaderCell(cellName, cellValue);
			cell.ColSpan = 1;
			cell.RowSpan = Math.Max(rowSpan,1);
			cell.Font = this.rowHeaderFont;
			cell.BackColor = this.rowHeaderBackColor;
			cell.ForeColor = this.rowHeaderForeColor;
			cell.IsDesignMode = this.DesignMode;
			cell.DrawMode = this.rowHeaderDrawMode;
			return cell;
		}
		/// <summary>
		/// 컬럼정보로 데이타 행의 Cell을 생성합니다.
		/// </summary>
		/// <param name="info"> 컬럼정보를 관리하는 CellInfo 개체 </param>
		/// <param name="dataValue"> Cell의 Value </param>
		/// <param name="displayText"> Cell의 DisplayText </param>
		/// <param name="rowSpan"> Cell의 RowSpan </param>
		/// <param name="isAlterateRow"> 교대로 반복되는 행인지 여부 </param>
		/// <returns> Cell 개체 </returns>
		protected virtual XCell CreateContentCell(XGridCell info, object dataValue, string displayText, int rowSpan, bool isAlterateRow)
		{
			XCell cell = new XCell(info.CellName, dataValue, displayText);
			cell.RowSpan = rowSpan;
			cell.ColSpan = info.ColSpan;
			cell.SelectedBackColor = info.SelectedBackColor;
			cell.SelectedForeColor = info.SelectedForeColor;
			cell.TextAlignment = info.TextAlignment;
			cell.IsDesignMode = this.DesignMode;
			//ToolTipType이 ColumnDesc이면 cell의 ToolTipText를 컬럼정보의 ToolTipText로 설정
			if (this.ToolTipType == XGridToolTipType.ColumnDesc)
				cell.ToolTipText = info.ToolTipText;
			if (isAlterateRow)
			{
				cell.DrawMode = info.AlterateRowDrawMode;
				cell.Font = info.AlterateRowFont;
				cell.BackColor = info.AlterateRowBackColor;
				cell.GradientStart = info.AlterateRowGradientStart;
				cell.GradientEnd = info.AlterateRowGradientEnd;
				cell.ForeColor = info.AlterateRowForeColor;
				cell.Image= info.AlterateRowImage;
				cell.ImageAlignment = info.AlterateRowImageAlign;
				cell.ImageStretch = info.AlterateRowImageStretch;
			}
			else
			{
				cell.DrawMode = info.RowDrawMode;
				cell.Font = info.RowFont;
				cell.BackColor = info.RowBackColor;
				cell.GradientStart = info.RowGradientStart;
				cell.GradientEnd = info.RowGradientEnd;
				cell.ForeColor = info.RowForeColor;
				cell.Image= info.RowImage;
				cell.ImageAlignment = info.RowImageAlign;
				cell.ImageStretch = info.RowImageStretch;
			}
			return cell;
		}
		/// <summary>
		/// 컬럼정보등으로 ComputedCell개체를 생성합니다.
		/// </summary>
		/// <param name="info"> 컬럼정보를 관리하는 ComputedCellInfo 개체 </param>
		/// <param name="dataValue"> Cell의 Value </param>
		/// <returns> ComputedCell 개체 </returns>
		protected virtual XComputedCell CreateComputedCell(XGridComputedCell info, object dataValue)
		{
			XComputedCell cell = new XComputedCell(info.GroupName, dataValue);
			//Tag에 Identifier명 저장
			cell.Tag = info.Identifier;
			cell.RowSpan = info.RowSpan;
			cell.ColSpan = info.ColSpan;
			cell.SelectedBackColor = info.SelectedBackColor;
			cell.SelectedForeColor = info.SelectedForeColor;
			cell.TextAlignment = info.TextAlignment;
			cell.DrawMode = info.DrawMode;
			cell.Font = info.Font;
			cell.BackColor = info.BackColor;
			cell.GradientStart = info.GradientStart;
			cell.GradientEnd = info.GradientEnd;
			cell.ForeColor = info.ForeColor;
			cell.Image = info.Image;
			cell.ImageAlignment = info.ImageAlign;
			cell.ImageStretch = info.ImageStretch;
			cell.IsDesignMode = this.DesignMode;

			return cell;
		}
		#endregion

		#region CreateGroupBand, CreateFooter
		/// <summary>
		/// Design Time시 GroupBand를 생성합니다.
		/// </summary>
		protected virtual void CreateGroupBand()
		{
			//DesignMode시만 적용
			if (!this.DesignMode) return;

			int linesPerRow = this.GetLinesPerRow();
			int startCol = 0;
			int bfRows = this.Rows;
			ArrayList posArray = new ArrayList();
			if (this.RowHeaderVisible) startCol = 1;

			// GroupBand영역의 Row, Col 저장, Footer영역에 있는 ComputedCell이 없는
			// 영역에만 GroupBand SET
			foreach (XGridGroupInfo info in this.groupInfos)
			{
				bfRows = this.Rows;
				this.Rows += linesPerRow;
				//CellName은 Group명
				for (int i = bfRows ; i < this.Rows ; i++)
					for (int j = startCol ; j < this.Cols ; j++)
						posArray.Add(i.ToString() + "," + j.ToString() + "," + info.GroupName);
			}
			int row = 0;
			// Group의 Computed Cell 추가
			foreach (XGridComputedCell info in this.computedCellInfos)
			{
				if (info.GroupName != XGridUtility.FooterGroupName)  //Footer가 아니면
				{
					row = GetRowByGroupName(info.GroupName, true, info.Row);
					this[row,info.Col] = CreateComputedCell(info, info.Expression);
					// Span고려 posArray에서 ComputedCell이 있는 위치는 제거
					for (int i = row ; i < row + info.RowSpan ; i++)
						for (int j = info.Col ; j < info.Col + info.ColSpan ; j++)
							posArray.Remove(i.ToString() + "," + j.ToString() + "," + info.GroupName);
				}
			}
			string[] rowCol;
			// posArray에 남아있는 영역에만 GroupBandCell SET
			for (int i = 0; i < posArray.Count ; i++)
			{
				rowCol = posArray[i].ToString().Split(new Char[]{','});
				this[Int32.Parse(rowCol[0]), Int32.Parse(rowCol[1])] = new XGroupBandCell(rowCol[2], rowCol[2]);
			}
		}
		/// <summary>
		/// Design Time시 Footer를 생성합니다.
		/// </summary>
		protected virtual void CreateFooter()
		{
			//DesignMode시만 적용 (DesignGrid일때는 GroupBand표시)
			if (!this.DesignMode) return;
			
			// 일단 Footer 추가
			int linesPerRow = this.GetLinesPerRow();
			int startCol = 0;
			int bfRows= this.Rows;
			int row = 0;
			ArrayList posArray = new ArrayList();
			if (this.RowHeaderVisible) startCol = 1;
			
			// Rows 증가
			this.Rows += linesPerRow;
			
			// Footer영역의 Row, Col 저장, Footer영역에 있는 ComputedCell이 없는
			// 영역에만 FooterCell SET
			for (int i = bfRows ; i < this.Rows ; i++)
				for (int j = startCol ; j < this.Cols ; j++)
					posArray.Add(i.ToString() + "," + j.ToString());

			// Footer의 Computed Cell 추가
			foreach (XGridComputedCell info in this.computedCellInfos)
			{
				if (info.GroupName == XGridUtility.FooterGroupName)  //Footer가 아니면
				{
					row = GetRowByGroupName(info.GroupName, true, info.Row);
					
					this[row,info.Col] = CreateComputedCell(info, info.Expression);
					// Span고려 posArray에서 ComputedCell이 있는 위치는 제거
					for (int i = row ; i < row + info.RowSpan ; i++)
						for (int j = info.Col ; j < info.Col + info.ColSpan ; j++)
							posArray.Remove(i.ToString() + "," + j.ToString());
				}
			}
			string[] rowCol;
			// posArray에 남아있는 영역에만 FooterCell SET
			for (int i = 0; i < posArray.Count ; i++)
			{
				rowCol = posArray[i].ToString().Split(new Char[]{','});
				this[Int32.Parse(rowCol[0]), Int32.Parse(rowCol[1])] = new XFooterCell(XGridUtility.FooterGroupName, XGridUtility.FooterName);
			}
		}
		#endregion

		#region GetRowByGroupName
		private int GetRowByGroupName(string groupName, bool isDisplayPos, int row)
		{
			//Group명에 따라 row를 변환
			// DisplayPos이면 ComputedCellInfo에 있는 Row -> Display할 Row로 변환
			// else Display된 Row를 ComputedCellInfo의 Row로 변환
			int rowNum = 0;
			int headerLines = this.AddedHeaderLine + this.LinePerRow;
			int linesPerRow = this.GetLinesPerRow();

			if (isDisplayPos)
			{
				if (groupName == XGridUtility.FooterGroupName) // Footer
					rowNum = headerLines + this.GroupInfos.Count * linesPerRow + row;
				else  //Group2 -> (2 - 1) * linesPerRow
					rowNum = headerLines + (Int32.Parse(groupName.Substring(5)) -1) * linesPerRow + row;
			}
			else
			{
				if (groupName == XGridUtility.FooterGroupName)
					rowNum = row - headerLines - this.GroupInfos.Count * linesPerRow;
				else
					rowNum = row - headerLines - (Int32.Parse(groupName.Substring(5)) -1) * linesPerRow;
			}
			return rowNum;
		}
		#endregion

		#region Group관련 Methods
		//그룹이 존재하는지 여부
		private bool ExistGroup()
		{
			if (this.GroupDataList.Count < 1) return false;
			//FooterGroup이 아니면 true, 그외는 false
			foreach (XGridGroupData groupData in GroupDataList)
			{
				if (groupData.GroupName != XGridUtility.FooterGroupName)
					return true;
			}
			return false;
		}
		//Footer에 Text외에 Sum, Average등의 Computed Field가 존재하는지 여부
		private bool ExistFooterComputedField()
		{
			if (this.GroupDataList.Count < 1) return false;
			foreach (XGridComputedCell info in this.ComputedCellInfos)
			{
				if (info.GroupName == XGridUtility.FooterGroupName)
					if (info.ComputedKind != XGridComputedKind.Text)
						return true;
			}
			return false;
																	
		}
		/// <summary>
		/// GroupDataCollection을 초기화합니다.(RunTime시)
		/// </summary>
		internal void InitializeGroupDataList()
		{
			// 기존 Data Clear
			this.GroupDataList.Clear();

			string keyName = "";
			//GroupDataList초기화
			//ComputedCellInfos를 바탕으로 GroupData를 생성하여 GroupDataList 에 SET
			//Footer에 있는 Computed컬럼은 제외
			//GroupDataList에 Add순서는 Group중에 컬럼이 많이 지정된 Group부터 SET
			ArrayList orderList = new ArrayList();
			ArrayList groupNameList = new ArrayList();
			foreach (XGridGroupInfo info in this.groupInfos)
				orderList.Add( info.ColumnList.Count.ToString() + "," + info.GroupName);
			orderList.Sort(Comparer.Default);  // 컬럼의 갯수순으로 Sort (1,Group2)(2,Group1)(3,Group3) 순으로 됨
			// 컬럼갯수가 많은 순으로 GroupName SET
			string[] tempStrs;
			for (int i = orderList.Count - 1 ; i >= 0 ; i--)
			{
				tempStrs = orderList[i].ToString().Split(new Char[] {','});
				groupNameList.Add(tempStrs[1]);
			}
			// 마지막에 Footer의 GroupName을 All로 저장
			groupNameList.Add(XGridUtility.FooterGroupName);
			
			foreach (string groupName in groupNameList)
			{
				foreach (XGridComputedCell info in this.computedCellInfos)
				{
					if (info.GroupName == groupName)
					{
						if (GroupDataList.Contains(info.GroupName))
						{
							keyName = XGridUtility.GetKeyNameByExpression(info.ComputedKind, info.Expression);
							//SubDataList에 동일한 Identifier를 가진 GroupSubData 없으면 Add
							if (!GroupDataList[info.GroupName].SubDataList.Contains(info.Identifier))
								GroupDataList[info.GroupName].SubDataList.Add(info.Identifier, info.ComputedKind, keyName);
						}
						else  //없으면 생성, GroupSubData SET
						{
							GroupDataList.Add(info.GroupName);
							keyName = XGridUtility.GetKeyNameByExpression(info.ComputedKind, info.Expression);
							GroupDataList[info.GroupName].SubDataList.Add(info.Identifier, info.ComputedKind, keyName);
						}
					}
				}
			}
		}
		private int SetMiddleComputedColumn(DataRow dtRow, int row, bool isFirst, int rowCount)
		{
			//Computed컬럼이 설정된 것이 없으면 Return
			if (GroupDataList.Count < 1) return row;

			XGridDataItemCollection items = new XGridDataItemCollection();
			foreach (DataColumn dtCol in this.LayoutTable.Columns)
				items.Add(dtCol.ColumnName, dtRow[dtCol.ColumnName]);

			return SetMiddleComputedColumn(items, row, isFirst, rowCount);
		}
		/// <summary>
		/// Data값을 비교하여 누적하고 ComputedCell을 생성합니다.
		/// </summary>
		/// <param name="dataItems"> Data를 관리하는 컬렉션 </param>
		/// <param name="row"> Display해야할 Row </param>
		/// <returns> 누적후 현재 Display Row (에러발생시 -1) </returns>
		private int SetMiddleComputedColumn(XGridDataItemCollection dataItems, int row, bool isFirst, int rowCount)
		{
			//Computed컬럼이 설정된 것이 없으면 Return
			if (GroupDataList.Count < 1) return row;

			string keyValue = "";
			int linesPerRow = this.GetLinesPerRow();
			int currRow = row;
			XGridComputedCell compInfo = null;
			object cellValue = null;
			XGridDataItem dataItem;
			bool     isMax = true;
			XCellDataType cellType = XCellDataType.String;
			object compValue;
			foreach (XGridGroupData item in this.GroupDataList)
			{
				keyValue = "";
				if (item.GroupName == XGridUtility.FooterGroupName) //Footer
					keyValue = XGridUtility.FooterKeyValue;
				else  // Group
				{
					//GroupInfos에서 해당 Group의 컬럼 List
					if (GroupInfos[item.GroupName] != null)
					{
						foreach (string colName in GroupInfos[item.GroupName].ColumnList)
						{
							if (dataItems[colName] != null)
								keyValue += dataItems[colName].DataValue.ToString();
						}
					}
				}

				//KeyValue가 서로 다르면 ComputedCell을 설정 
				//단 최초 item.KeyValue = "$$$"이므로 이 경우는 제외
				if ((item.KeyValue != XGridUtility.KeyInitValue) && (item.KeyValue != keyValue))
				{
					//Row증가
					this.Rows += linesPerRow;
					foreach (XGridGroupSubData subItem in item.SubDataList)
					{
						compInfo = this.ComputedCellInfos[subItem.Identifier];
						this.distinctDataList.Clear();
						if (compInfo != null)
						{
							cellValue = subItem.DataValue;
							//Text는 Text SET (""는 제거)
							if (subItem.Kind == XGridComputedKind.Text)
								cellValue = compInfo.Expression.Replace("\"","");
								//Average는 cellValue에 합계 저장함으로 DataCount로 나눔
							else if (subItem.Kind == XGridComputedKind.Average)
								cellValue = Double.Parse(cellValue.ToString())/subItem.DataCount;
							else if (subItem.Kind == XGridComputedKind.DistinctCount)
							{
								// 보관된 subItem의 DataList에서 Distinct한 Data의 갯수 Count
								foreach (object data in subItem.DataList)
								{
									if (!this.distinctDataList.Contains(data))
										this.distinctDataList.Add(data);
								}
								cellValue = this.distinctDataList.Count;
							}
							this[currRow + compInfo.Row, compInfo.Col] = CreateComputedCell(compInfo, cellValue);
						}
						else  //이런 경우는 발생하지 않아야 함
						{
							string msg = "[SetMiddleComputedColumn, ComputedCellInfo]" + XMsg.GetMsg("M054"); // SetMiddleComputedColumn, ComputedCellInfo 정보가 없습니다."
							ShowErrMsg(msg);
							return -1;
						}
						//subItem의 Data Clear
						subItem.DataCount = 0;
						subItem.DataValue = "";
						subItem.DataList.Clear();
					}
					//그룹Row정보에 Add 
					this.GroupRowInfos.Add(item.GroupName, item.KeyValue, currRow, rowCount - 1);

					currRow += linesPerRow;  // 현재행 누적
				}

				//KeyValue SET
				item.KeyValue = keyValue;

				foreach (XGridGroupSubData subItem in item.SubDataList)
				{
					dataItem = dataItems[subItem.KeyName];
					subItem.DataCount++;  //DataCount증가
					if ((subItem.Kind != XGridComputedKind.Text) && (dataItem != null))
					{
						subItem.DataList.Add(dataItem.DataValue);  //DataList에 DataValue보관

						switch (subItem.Kind)
						{
							case XGridComputedKind.Count:
								subItem.DataValue = subItem.DataCount;
								break;
							case XGridComputedKind.Sum:
								if (TypeCheck.IsDouble(dataItem.DataValue))
									subItem.DataValue = (subItem.DataValue.ToString() == "" ? 0 : Double.Parse(subItem.DataValue.ToString())) 
										+ Double.Parse(dataItem.DataValue.ToString());
								break;
							case XGridComputedKind.Average:
								// 합계를 저장하여 계산시 Count로 나누어줌
								if (TypeCheck.IsDouble(dataItem.DataValue))
									subItem.DataValue = (subItem.DataValue.ToString() == "" ? 0 : Double.Parse(subItem.DataValue.ToString())) 
										+ Double.Parse(dataItem.DataValue.ToString());
								break;
							case XGridComputedKind.Max:
							case XGridComputedKind.Min:
								if (subItem.Kind == XGridComputedKind.Min) isMax = false;
								//최초이면 첫번째 데이타를 동일하게 설정
								if (isFirst) subItem.DataValue = dataItem.DataValue;
								//DataValue가 Date=YYYYMMDD, DateTime=YYYYMMDDHHMISS, Time=HHMISS형으로 옮으로 String처럼 비교해도 됨
								//DataType이 Number이면 Conversion하여 비교함
								if (this.cellInfos[subItem.KeyName] != null)
								{
									cellType = this.cellInfos[subItem.KeyName].CellType;
									if ((cellType == XCellDataType.Number) || (cellType == XCellDataType.Decimal))
									{
										if (TypeCheck.IsDecimal(dataItem.DataValue))
										{
											compValue = (subItem.DataValue.ToString() == "" ? "0" : subItem.DataValue);
											subItem.DataValue = (Decimal.Compare(Decimal.Parse(compValue.ToString()), Decimal.Parse(dataItem.DataValue.ToString())) > 0 ? (isMax ? compValue : dataItem.DataValue) : (isMax ? dataItem.DataValue : compValue));
										}
									}
									else
									{
										subItem.DataValue = (String.Compare(subItem.DataValue.ToString(), dataItem.DataValue.ToString()) > 0 ? (isMax ? subItem.DataValue : dataItem.DataValue) : (isMax ? dataItem.DataValue : subItem.DataValue));
									}
								}
								else  // 발생하지 않아야 함
								{
									ShowErrMsg("XGrid::SetMiddleComputedColumn, GroupSubData keyName[" + subItem.KeyName + "] Error");
									return -1;
								}
								break;
						}
					}
				}
			}
			return currRow;  // 누적후 행번호 Return
		}
		// GroupDataList에 누적된 마지막 값 SET
		/// <summary>
		/// Group정보에 누적된 마지막 값으로 마지막 ComputedColumn을 설정합니다.
		/// </summary>
		/// <param name="row"> 설정한 Row의 위치 </param>
		protected void SetBottomComputedColumn(int row, int rowCount)
		{
			//Computed컬럼이 설정된 것이 없으면 Return
			if (GroupDataList.Count < 1) return;

			XGridComputedCell compInfo = null;
			object cellValue = null;
			int currRow = row;
			int linesPerRow = this.GetLinesPerRow();
			foreach (XGridGroupData item in this.GroupDataList)
			{
				//Row증가
				//this.AddRow(currRow, linesPerRow);
				this.Rows += linesPerRow;
				foreach (XGridGroupSubData subItem in item.SubDataList)
				{
					compInfo = this.ComputedCellInfos[subItem.Identifier];
					this.distinctDataList.Clear();
					if (compInfo != null)
					{
						cellValue = subItem.DataValue;
						//Text는 Text SET (""는 제거)
						if (subItem.Kind == XGridComputedKind.Text)
							cellValue = compInfo.Expression.Replace("\"","");
							//Average는 cellValue에 합계 저장함으로 DataCount로 나눔
						else if (subItem.Kind == XGridComputedKind.Average)
							cellValue = Double.Parse(cellValue.ToString())/subItem.DataCount;
						else if (subItem.Kind == XGridComputedKind.DistinctCount)
						{
							// 보관된 subItem의 DataList에서 Distinct한 Data의 갯수 Count
							foreach (object data in subItem.DataList)
							{
								if (!this.distinctDataList.Contains(data))
									this.distinctDataList.Add(data);
							}
							cellValue = this.distinctDataList.Count;
						}
						this[currRow + compInfo.Row, compInfo.Col] = CreateComputedCell(compInfo, cellValue);
					}
					else  //이런 경우는 발생하지 않아야 함
					{
						string msg = "[SetBottomComputedColumn, ComputedCellInfo]" + XMsg.GetMsg("M054"); // SetMiddleComputedColumn, ComputedCellInfo 정보가 없습니다."
						ShowErrMsg(msg);
						return;
					}
				}
				//그룹Row정보에 Add
				this.GroupRowInfos.Add(item.GroupName, item.KeyValue, currRow, rowCount - 1);
				currRow += linesPerRow;  // 현재행 누적
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

		#region DisplayData ,Reset
		/// <summary>
		/// LayoutTable에 직접 데이타를 설정한 후에 데이타를 Display하고자 할때 사용합니다.
		/// </summary>
        // <<2013.12.03>> LKH AllDataQuery 추가
        public void DisplayData()
        {
            DisplayData(false);
        }
        public void DisplayData(bool isAllDataQuery)
        {
            string msg = "";
            //조회미완료시는 Sort불가
            if (!this.IsQueryCompleted)
            {
                msg = XMsg.GetMsg("M055"); // 조회미완료된 상태에서는 DisplayData할 수 없습니다.
                ShowErrMsg(msg);
                return;
            }
            //필터링중에는 Sort불가
            if (this.IsFiltering)
            {
                msg = XMsg.GetMsg("M056"); // 필터링중에는 DisplayData할 수 없습니다."
                ShowErrMsg(msg);
                return;
            }

            try
            {
                //기존 Displayed Cell Clear
                this.Reset(false);

                //원 DataTable을 GridTable과 동일하게 설정
                this.OrigLayoutTable = this.LayoutTable.Copy();

                if (this.RowCount < 1) return;

                if (isAllDataQuery)
                    DisplayDataSub(0, this.LayoutTable.Rows.Count, true);
                else
                    DisplayDataSub(0, FIRST_DISP_COUNT, true);

                //GridSorted Event 발생
                if (this.GridDataDisplayed != null)
                    OnGridDataDisplayed(EventArgs.Empty);
            }
            catch (Exception xe)
            {
                msg = "DisplayData Error[" + xe.Message + "]";
                ShowErrMsg(msg);
            }
        }
        /// <summary>
		/// Grid에 데이타를 Display합니다.
		/// </summary>
		/// <param name="bfDisplayCount"> 이전에 Display된 행의 갯수 </param>
		/// <param name="displayCount"> 새로 Display할 행의 갯수 </param>
		/// <param name="isFocusToFirstCol"> 첫번째 컬럼에 Focus를 줄지 여부(Sort, Filter시는 false)</param>
		private void DisplayDataSub(int bfDisplayCount, int displayCount, bool isFocusToFirstCol)
		{
			// 그리기 멈춤
			this.Redraw = false;

			int bfRows = this.Rows;
			DataRow dtRow = null;
			int linesPerRow = GetLinesPerRow();
			int bfRowCount = 0;
			int displayRowNumber = 0;
			int currRow = bfRows;

			//SetValue중간에 Rows증가에 의해 RecalcScrollVar가 발생하는데, Row추가시마다 Scroll영역을
			//다시 계산할 필요가 없음. Flag를 설정하여 Scroll영역 계산하지 않도록 함
			this.isScrollReCalc = false;

			//최대조회Row = 이전Row + 보여줄 ROw 와 RowCount중 작은 값
			//Sort, SetFilter에서는 0, 300으로 보내고, SetValue에서는 이전Row와 조회된건수로 보낸다.
			int endRowCount = Math.Min(displayCount + bfDisplayCount, this.LayoutTable.Rows.Count);
			//Display완료여부 SET, Service  조회 완료시
			if (IsQueryCompleted && (endRowCount >= this.LayoutTable.Rows.Count))
			{
				this.SetBottomRightImage(true);
				this.DisplayCompleted = true;
			}
			else
				this.DisplayCompleted = false;

			//Cell의 Position 정보 계산
			this.CalcRowPosition();
			
			try
			{
				/*Group이 존재하는지 여부에 따라 DisplayDataSub 방식 변경
					 * Group이 존재하면 한행식 Add 처리, 그룹이 존재하지 않으면 Rows를 전체로 설정하여 처리함
					 * 대부분 Group이 존재하지 않으므로 속도향상 */
				if (ExistGroup())
				{
					//시작은 이전 Row부터 EndRow까지
					for (int i = bfDisplayCount; i < endRowCount ; i++)
					{
						dtRow = this.LayoutTable.Rows[i];
				
						// Group에 의해 중간중간에 ComputedColumn SET
						currRow = this.SetMiddleComputedColumn(dtRow, currRow, (i == 0), i);

						this.Rows += linesPerRow;

						displayRowNumber = bfRowCount + i + 1;  // 실제 Row수 + 1

						// RowHeaderVisible이면 RowHeader SET
						if (this.rowHeaderVisible)
						{
							// RowNumber를 Show해야하면 Value에도 displayRowNumber SET
							if (this.showNumberAtRowHeader)
								this[currRow, 0] = CreateRowHeaderCell(displayRowNumber.ToString(), displayRowNumber,linesPerRow);
							else
								this[currRow, 0] = CreateRowHeaderCell(displayRowNumber.ToString(), "",linesPerRow);
						}

						//Row의 Height 자동조정
						if (this.applyAutoHeight)
							this.ApplyAutoHeightAtRow(currRow, linesPerRow, dtRow, (displayRowNumber%2 == 0 ? true : false));

						foreach (XGridCell info in this.cellInfos)
						{
							if (info.IsVisible && info.CellWidth > 0)
								DisplayCell(info, currRow + rowPosList[info.CellName].RowPos , rowPosList[info.CellName].RowSpan , dtRow[info.CellName],linesPerRow, i);
						}
						// 현재행 누적
						currRow += linesPerRow;
					}
				}
				else
				{
					//Rows를 Display하는 행의 갯수*한행의 Line수로 설정
					this.Rows += linesPerRow*(endRowCount - bfDisplayCount);
					
					//Footer에 Text외에 다른 ComputedField가 존재하는지 여부(존재하면 ComputedField의 값을 계산해야함)
					bool existFooterField = ExistFooterComputedField();

					//시작은 이전 Row부터 EndRow까지
					for (int i = bfDisplayCount; i < endRowCount ; i++)
					{
						dtRow = this.LayoutTable.Rows[i];
				
						//Footer 에 있는 Computed Field의 값 계산
						if (existFooterField)
							this.SetMiddleComputedColumn(dtRow, currRow, (i == 0), i);

						displayRowNumber = bfRowCount + i + 1;  // 실제 Row수 + 1

						// RowHeaderVisible이면 RowHeader SET
						if (this.rowHeaderVisible)
						{
							// RowNumber를 Show해야하면 Value에도 displayRowNumber SET
							if (this.showNumberAtRowHeader)
								this[currRow, 0] = CreateRowHeaderCell(displayRowNumber.ToString(), displayRowNumber,linesPerRow);
							else
								this[currRow, 0] = CreateRowHeaderCell(displayRowNumber.ToString(), "",linesPerRow);
						}

						//Row의 Height 자동조정
						if (this.applyAutoHeight)
							this.ApplyAutoHeightAtRow(currRow, linesPerRow, dtRow, (displayRowNumber%2 == 0 ? true : false));

						foreach (XGridCell info in this.cellInfos)
						{
							if (info.IsVisible && info.CellWidth > 0)
								DisplayCell(info, currRow + rowPosList[info.CellName].RowPos , rowPosList[info.CellName].RowSpan , dtRow[info.CellName],linesPerRow, i);
						}
						// 현재행 누적
						currRow += linesPerRow;
					}
				}
			}
			catch(Exception xe)
			{
				string msg = "DisplayDataSub Error[" + xe.Message + "]";
				ShowErrMsg(msg);
				// Scroll영역 계산
				this.isScrollReCalc = true;
				this.RecalculateScrollBar();
				// 그리기 시작
				this.Redraw = true;
				return;
			}
			
			
			// 마지막에 누적된 GroupDataList를 SET(Display완료시)
			if (this.DisplayCompleted)
				SetBottomComputedColumn(currRow, endRowCount);


			//SelectionMode 복구
			this.selectionMode = this.origSelectionMode;

			// 조회후 첫번째 Row에 Focus
			// RowHeader 다음의 첫번째 컬럼
			// 첫번째 행에 Focus 하고자 할때(Sort, Filter에서는 현재 Scroll 유지)
			if (isFocusToFirstCol)
			{
				if (this.rowHeaderVisible)
				{
					if (this[bfRows,1] != null)
						this[bfRows,1].Focus(false);
				}
				else
				{
					if (this[bfRows,0] != null)
						this[bfRows,0].Focus(false);
				}
			}
			this.isScrollReCalc = true;
			//Data설정완료후 Scroll영역 계산
			this.RecalculateScrollBar();
			//DisplayedRowCount SET
			this.DisplayedRowCount = endRowCount;
			//행단위 선택이면 첫번째 행 Select
			if (this.selectionMode == XGridSelectionMode.Row)
				this.SelectRow(bfDisplayCount); //첫번째행 Select

            // 조회후 첫번째 Row에 Focus
            // RowHeader 다음의 첫번째 컬럼
            // 첫번째 행에 Focus 하고자 할때(Sort, Filter에서는 현재 Scroll 유지)
            // <ALL_QUERY> 2011.03.19 XCell.Focus()를 먼저주면 OnVScrollChanged 가 발생하여 정상처리를 못함. 따라서, SelectRow후에 Focus를 준다.
            if (isFocusToFirstCol)
            {
                if (this.rowHeaderVisible)
                {
                    if (this[bfRows, 1] != null)
                        this[bfRows, 1].Focus(false);
                }
                else
                {
                    if (this[bfRows, 0] != null)
                        this[bfRows, 0].Focus(false);
                }
            }

			// 그리기 시작
			this.Redraw = true;

		}
		private void Reset(bool clearTable)
		{
			//gridTable, origGridTable Reset
			if (this.LayoutTable != null && clearTable)
			{
				this.LayoutTable.Rows.Clear();
				//원 데이타 테이블도 Clear
				this.OrigLayoutTable.Rows.Clear();
			}

			//For SqlServer source Table Clear
			//this.sourceTable = null;
			//this.sourceRowIndex = 0;

			//기존 DataReader가 있을때 이미 Open되어 있으면 Close
			/*if ((this.xgridData != null) && !xgridData.IsClosed)
			{
				this.xgridData.Close();
				this.xgridData = null;
			}*/
			
			//Reset BindControlDataValue
			this.ResetBindControlDataValue();
			
			this.Redraw = false;

			//Row감소에 따른 Flag를 설정하여 Scroll영역 계산하지 않도록 함
			this.isScrollReCalc = false;

			//Rows를 Header만 남겨둠
			this.Rows = this.LinePerRow + this.AddedHeaderLine;
			this.FixedRows = this.LinePerRow + this.AddedHeaderLine;
			
			//FocusCell Clear
			this.focusCell = null;
			//preRowNumber -1 Set
			this.PreRowNumber = -1;
			//연속조회 Flag Clear
			this.DisplayCompleted = false;
			//Display된 Row의 갯수 Clear
			this.DisplayedRowCount = 0;
			//조회완료여부 Clear
			this.IsQueryCompleted = true;

			// Header의 Sort상태 Reset
			for (int i = 0; i < this.linePerRow + this.addedHeaderLine ; i++)
				for ( int j = 0; j < this.cols ; j++)
					if ((this[i,j] != null) && (this[i,j].Personality == XCellPersonality.ColHeader))
					{
						((XColHeaderCell)this[i,j]).SortStatus = XGridSortStatus.None;
						this[i,j].SortImage = null;
					}

			//GroupDataList의 GroupSubData의 DataCount, DataValue Clear, GroupRowInfos Clear
			foreach (XGridGroupData item in this.GroupDataList)
			{
				//item의 KeyValue 초기화
				item.KeyValue = XGridUtility.KeyInitValue;
				foreach (XGridGroupSubData subItem in item.SubDataList)
				{
					subItem.DataCount = 0;
					subItem.DataValue = "";
					subItem.DataList.Clear();
				}
			}
			this.GroupRowInfos.Clear();
			
			this.isScrollReCalc = true;
			this.RecalculateScrollBar();
			//
			if (this[0,0] != null)
				this[0,0].Focus(false);
			this.Redraw = true;
		}
		public virtual void Reset()
		{
			this.Reset(true);
		}
		#endregion

		#region 연속 Display관련
		/// <summary>
		/// 조회 Data로 Grid의 값을 Setting합니다.(DataTable에 SET)
		/// </summary>
		protected virtual void ContDisplay(bool rePainting)
		{
			if (this.LayoutTable == null) return;
			//Display완료시는 Return
			if (this.DisplayCompleted) return;

			//Table에 데이타가 없으면 Return
			if (this.LayoutTable.Rows.Count == 0)
			{
				this.DisplayCompleted = true;
				return;
			}

			if (rePainting)
			{
				// 그리기 멈춤
				this.Redraw = false;
				//SetValue중간에 Rows증가에 의해 RecalcScrollVar가 발생하는데, Row추가시마다 Scroll영역을
				//다시 계산할 필요가 없음. Flag를 설정하여 Scroll영역 계산하지 않도록 함
				this.isScrollReCalc = false;
			}

			int bfRows = this.Rows;
			DataRow dtRow = null;
			int linesPerRow = GetLinesPerRow();
			int bfRowCount = this.DisplayedRowCount; //Display된 Row의 갯수
			int displayRowNumber = 0;
			int currRow = bfRows;

			//연속조회시 이전에 Display된 Row + Display단위
			int endRowCount = Math.Min(bfRowCount + cDisplayRowUnit, this.LayoutTable.Rows.Count);
			//Display완료여부 SET
			if (endRowCount >= this.LayoutTable.Rows.Count)
			{
				this.SetBottomRightImage(true);
				this.DisplayCompleted = true;
			}
			else
				this.DisplayCompleted = false;
			
			//Cell의 Position 정보 계산
			this.CalcRowPosition();

			for (int i = bfRowCount; i < endRowCount ; i++)
			{
				dtRow = this.LayoutTable.Rows[i];
				
				// Group에 의해 중간중간에 ComputedColumn SET
				currRow = this.SetMiddleComputedColumn(dtRow, currRow, false, i);

				this.Rows += linesPerRow;
				// RowHeaderVisible이면 RowHeader SET
				if (this.rowHeaderVisible)
				{
					displayRowNumber = i + 1;  // 실제 Row수 + 1
					// RowNumber를 Show해야하면 Value에도 displayRowNumber SET
					if (this.showNumberAtRowHeader)
						this[currRow, 0] = CreateRowHeaderCell(displayRowNumber.ToString(), displayRowNumber,linesPerRow);
					else
						this[currRow, 0] = CreateRowHeaderCell(displayRowNumber.ToString(), "",linesPerRow);
				}

				//Row의 Height 자동조정
				if (this.applyAutoHeight)
					this.ApplyAutoHeightAtRow(currRow, linesPerRow, dtRow, (displayRowNumber%2 == 0 ? true : false));
				
				try
				{
					foreach (XGridCell info in this.cellInfos)
					{
						if (info.IsVisible)
							DisplayCell(info, currRow + rowPosList[info.CellName].RowPos , rowPosList[info.CellName].RowSpan , dtRow[info.CellName],linesPerRow, i);

					}
				}
				catch(Exception e)
				{
					string msg = "ContDisplay, Error[" + e.Message + "]";
					ShowErrMsg(msg);
					// Scroll영역 계산
					this.isScrollReCalc = true;
					this.RecalculateScrollBar();
					// 그리기 시작
					this.Redraw = true;
					return;
				}
				// 현재행 누적
				currRow += linesPerRow;
			}
			
			// 마지막에 누적된 GroupDataList를 SET(Display완료시)
			if (this.DisplayCompleted)
				SetBottomComputedColumn(currRow, endRowCount);
			
			//DisplayedRowCount SET
			this.DisplayedRowCount = endRowCount;

			if (rePainting)
			{
				this.isScrollReCalc = true;
				//Data설정완료후 Scroll영역 계산
				this.RecalculateScrollBar();
				// 그리기 시작
				this.Redraw = true;
			}

			//GridContDisplayed Event 발생
			if (this.GridContDisplayed != null)
			{
				XGridContDisplayedEventArgs xe = new XGridContDisplayedEventArgs(bfRowCount, this.DisplayedRowCount);
				OnGridContDisplayed(xe);
			}
		}
		protected override void OnVScrollChanged(int newValue, int oldValue)
		{
			// Bar가 맨 아래에 오게되면 VScrollBar의 Value + LargeChange = Maxinum 이 된다. 이때 ContCall 발생시킴
			// ContCall을 바로 Call하게 되면 ContCall후에 Scroll Event의 다른 동작이 발생하여 계속 ContCall을 부르는 현상이 발생함
			// 따라서, ContCall을 Post Message하여 Scroll 완료후에 발생하도록 수정함(조회미완료시)
			if ((this.VScrollBar != null) && (this.VScrollBar.Value + this.VScrollBar.LargeChange >= this.VScrollBar.Maximum ))
			{
				//조회미완료시는 데이타 조회
                if (!this.IsQueryCompleted)
                {
                    this.mPage++;
                    QueryLayoutSubForOracle(false, this.mPage);
                }
                else if (!this.DisplayCompleted) //Sort, Filter후에 모두 Display를 하지 않았으면 연속조회 처리
                    ContDisplay(true);

			}
		}
		/// <summary>
		/// BottomRight의 Image를 Click시 조회가 완료되지 않았으면 계속 조회합니다.
		/// </summary>
		protected override void OnBottomRightImageClick()
		{
			// Image가 있을때 조회미완료이면 연속조회 Event Call
			// Display미완료이면 계속 Display
			if (this.ShowBottomRightImage)
			{
                if (!this.IsQueryCompleted)  //조회계속
                { 
                    //QueryLayoutSub(false);
                    this.mPage++;
                    QueryLayoutSubForOracle(false, this.mPage);
                }
                else if (!this.DisplayCompleted)
                    ContDisplay(true);
			}
		}

		/// <summary>
		/// BottomRight의 Image를 DoubleClick시 조회가 완료되지 않았으면 완료시까지 조회합니다.
		/// </summary>
		protected override void OnBottomRightImageDoubleClick()
		{
			// Image가 있을때 조회미완료이면 조회확인후 연속조회
			// Display미완료이면 Display완료시까지 조회
			if (this.ShowBottomRightImage)
			{
                // https://sofiamedix.atlassian.net/browse/MED-12237
                string msg = "";
                string cap = XMsg.GetMsg("M076");

				if (!this.IsQueryCompleted)
				{
                    //if (XMessageBox.Show("전체데이타를 조회하시겠습니까?", "전체조회확인", MessageBoxButtons.OKCancel) == DialogResult.OK)

                    // https://sofiamedix.atlassian.net/browse/MED-12237
                    //if (XMessageBox.Show("全体のデータを照会しますか？","全体照会確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    msg = XMsg.GetMsg("M077");
                    if (XMessageBox.Show(msg, cap, MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
                        //do
                        //{
                        //    QueryLayoutSub(false);
                        //}
                        //while (!this.IsQueryCompleted);
                        //<ALL_QUERY> 전체조회 Logic 변경

                        //2015/09/17 edit by Cloud
                        //QueryLayoutSub(true);
                        QueryLayout(true);
					}
				}
				else if (!this.DisplayCompleted)
				{
					// 전체조회 확인 Message
                    //if (XMessageBox.Show("조회건수[" + this.DisplayedRowCount.ToString("n0") + "건],전체건수[" + this.LayoutTable.Rows.Count.ToString("n0") + "건]\r\n\r\n" + "전체데이타를 조회하시겠습니까?", "전체조회확인", MessageBoxButtons.OKCancel) == DialogResult.OK)

                    // https://sofiamedix.atlassian.net/browse/MED-12237
                    msg = string.Format(XMsg.GetMsg("M078"), this.DisplayedRowCount.ToString("n0"), this.LayoutTable.Rows.Count.ToString("n0"), Environment.NewLine);
                    // 照会件数[1件],全体件数[100件]\r\n\r\n
                    // 全体データを照会しますか？
                    //if (XMessageBox.Show("照会件数[" + this.DisplayedRowCount.ToString("n0") + "件],全体件数[" + this.LayoutTable.Rows.Count.ToString("n0") + "件]\r\n\r\n" + "全体データを照会しますか？", "全体照会確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (XMessageBox.Show(msg, cap, MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						PostCallHelper.PostCall(new PostMethod(ContDisplayAtDoubleClick));
					}
				}
			}
		}
		private void ContDisplayAtDoubleClick()
		{
			this.Redraw = false;
			this.isScrollReCalc = false;
			ProgressForm dlg = new ProgressForm(this.RowCount);
			dlg.Show();
			do
			{
				ContDisplay(false);
				dlg.SetProgressValue(this.DisplayedRowCount);
			}
			while(!this.DisplayCompleted);
			dlg.Close();
			this.isScrollReCalc = true;
			this.RecalculateScrollBar();
			this.Redraw = true;
		}
		#endregion

		#region Filtering 관련
		public virtual void SetFilter(string filter)
		{
			//Grid에 데이타가 없으면 Filter 불가
			if (this.LayoutTable == null) return ;
			if (this.OrigLayoutTable == null) return;

			string msg = "";
			//원 데이타가 없으면 Return
			if (this.OrigLayoutTable.Rows.Count == 0)
			{
                //2010.2010.08.10 kimminsoo 필터링할 테이타가 없으면 그냥 넘어가기
				//msg = XMsg.GetMsg("M057"); // 필터링할 데이타가 없습니다."
				//ShowErrMsg(msg);
				return ;
			}

			//조회미완료시는 Sort불가
			if (!this.IsQueryCompleted)
			{
				msg = XMsg.GetMsg("M058"); // 조회미완료된 상태에서는 필터링할 수 없습니다."
				ShowErrMsg(msg);
				return;
			}
			
			//원 DataTable Copy
			DataTable tempTable = this.OrigLayoutTable.Copy();
			try
			{
				//tempTable Filter 적용
				tempTable.DefaultView.RowFilter = filter;
				//GridTable Data Clear
				this.LayoutTable.Rows.Clear();
				//행 IndexList Clear
				this.OrigTableRowIndexList.Clear();
				int index = 0;
				foreach (DataRowView rowView in tempTable.DefaultView)
				{
					this.LayoutTable.ImportRow(rowView.Row);
					index = 0;
					//전체행중에서 Filtering된 행이 있는 Index를 List에 SET
					foreach (DataRow dtRow in tempTable.Rows)
					{
						if (dtRow.Equals(rowView.Row))
							this.OrigTableRowIndexList.Add(index);
						index++;
					}
				}

				//기존 Displayed Cell Clear
				this.Reset(false);

				DisplayDataSub(0,FIRST_DISP_COUNT, false);
				//필터링 중 Flag 설정
				this.IsFiltering = true;

				//GridFilterChanged Event 발생
				if (this.GridFilterChanged != null)
					OnGridFilterChanged(EventArgs.Empty);
			}
			catch(Exception e)
			{
				msg = "SetFilter Error["+ e.Message + "]";
				this.ShowErrMsg(msg);
				tempTable.Dispose();
				//필터링 중 Flag Reset
				this.IsFiltering = false;
			}
		}
		public virtual void ClearFilter()
		{
			//Filtering중이 아니면 Return
			if (!this.IsFiltering) return;

			//Grid에 데이타가 없으면 Clear
			//Display완료전까지는 Clear불가
			if (this.LayoutTable == null) return ;
			if (this.OrigLayoutTable == null) return;
			//원데이타가 한건도 없으면 Return
			if (this.OrigLayoutTable.Rows.Count == 0) return;

			try
			{
				//GridTable에 원Table의 데이타 SET
				this.layoutTable = this.OrigLayoutTable.Copy();

				//기존 Displayed Cell Clear
				this.Reset(false);

				DisplayDataSub(0,FIRST_DISP_COUNT, false);
				//필터링 중 Flag Clear
				this.IsFiltering = false;

				//GridFilterChanged Event 발생
				if (this.GridFilterChanged != null)
					OnGridFilterChanged(EventArgs.Empty);
			}
			catch(Exception xe)
			{
				string msg = "ClearFilter Error["+ xe.Message + "]";
				this.ShowErrMsg(msg);
				//필터링 중 Flag Set
				this.IsFiltering = true;
			}
		}
		#endregion

		#region Control Binding 관련
		/// <summary>
		/// Grid의 Data를 FieldValue Format으로 변경하여 DataValue Set
		/// </summary>
		/// <param name="currRow"></param>
		protected virtual bool SetBindControlDataValue(int currRow)
		{
			if (!this.controlBinding) return false;
			if (this.LayoutTable == null) return false;
			if (currRow < 0) return false;
			if (this.RowCount < 1) return false;

			foreach (XGridCell info in this.cellInfos)
			{
				if (info.BindControl != null)
				{
					try
					{
						info.BindControl.DataValue = this.LayoutTable.Rows[currRow][info.CellName];
					}
					catch
					{
						info.BindControl.DataValue = string.Empty;
					}
				}
			}
			return true;
		}
		protected void ResetBindControlDataValue()
		{
			if (!this.controlBinding) return;
			foreach (XGridCell info in this.cellInfos)
			{
				if (info.BindControl != null)
					info.BindControl.DataValue = string.Empty;
			}
		}
		//BindedControl AcceptData return : true(성공), false(실패)
		protected bool BindControlAcceptData()
		{
			if (!this.controlBinding) return true;
			
			foreach (XGridCell info in this.cellInfos)
			{
				if ((info.BindControl != null) && ((Control) info.BindControl).Focused)
				{
					return info.BindControl.AcceptData();
				}
			}
			return true;
		}
		#endregion

		#region CalcRowPosition, ApplyAutoHeightAtRow
		/// <summary>
		/// Grid에 Focus를 유지합니다.
		/// </summary>
		internal bool SetFocusOnCellsContainer()
		{
			return backContainer.Focus();
		}
		protected void CalcRowPosition()
		{
			rowPosList.Clear();
			int linesPerRow = this.GetLinesPerRow();
			int rowPos = 0;
			int rowSpan = 0;
			foreach (XGridCell info in this.cellInfos)
			{
				if (info.IsVisible && info.CellWidth > 0)
				{
					if (this.AddedHeaderLine > 0)
					{
						this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
					}
					else
					{
						rowPos = info.Row;
						rowSpan = info.RowSpan;
					}
					rowPosList.Add(info.CellName, rowPos, rowSpan);
				}
				else
					rowPosList.Add(info.CellName, -1, -1);
			}
		}
		protected void ApplyAutoHeightAtRow(int currRow, int linesPerRow, DataRow dataRow, bool isAlterateRow)
		{
			if (!this.applyAutoHeight) return;
			Graphics g = this.CreateGraphics();
			SizeF tSize;
			int mHeight = 0;
			int textHeight = 0;
			Hashtable heightList = new Hashtable();
			for (int i = 0; i < linesPerRow ; i++)
				heightList.Add(i.ToString(), 0);

			foreach (XGridCell info in this.cellInfos)
			{
				if ((info.CellType == XCellDataType.String)	&& info.IsVisible && (info.CellWidth > 0))
				{
					string data = dataRow[info.CellName].ToString();
					string posStr = this.rowPosList[info.CellName].RowPos.ToString();
					mHeight = Convert.ToInt32(heightList[posStr]);
					if (data != string.Empty)
					{
						if (isAlterateRow)
							tSize = g.MeasureString(data, info.AlterateRowFont);
						else
							tSize = g.MeasureString(data, info.RowFont);
						textHeight = (int) (tSize.Height + 8.3);
						//TextHeight와 Default Height중 큰 값
						mHeight = Math.Max(mHeight, textHeight);
					}
					else
					{
						textHeight = 0;
						//TextHeight와 Default Height중 큰 값
						mHeight = Math.Max(mHeight, textHeight);
					}
					heightList[posStr] = mHeight;

				}
			}
			for (int i = 0; i < heightList.Count ; i++)
			{
				mHeight = Convert.ToInt32(heightList[i.ToString()]);
				if (mHeight != this.defaultHeight)
					this.AutoSizeRow(currRow + i, mHeight);
			}
			g.Dispose();
		}
		#endregion

		#region ShowErrMsg
		protected void ShowErrMsg(string msg)
		{
			if (msg == "") return;
			
			if (this.LayoutContainer != null)
				LayoutContainer.SetMsg(msg, MsgType.Error);
			else
			{
				XMessageBox.Show(msg);
			}
		}
		//조회 Service Msg 처리
		protected void SetServiceMsg(ServiceType sType, ServiceMsgType msgType)
		{
			if (this.LayoutContainer != null)
				this.LayoutContainer.SetServiceMsg(sType, msgType);
		}
		#endregion

		#region GetHitRowNumber
		public int GetHitRowNumber(int y)
		{
			int row = -1;
			int rowNumber = -1;
			XCellRowInfo rowInfo = null;
			//Scroll고려 yPos 절대좌표로 계산
			int yPos = y - this.CustomScrollPosition.Y;
			for (int i = 0; i < this.Rows ; i++)
			{
				rowInfo = this.cellRowInfo[i];
				//Position이 해당Row에 속하면 Row Set
				if ((rowInfo.Top <= yPos) && (rowInfo.Top + rowInfo.Height > yPos))
				{
					row = i;
					break;
				}
			}
			if ((row >= 0) && (row < this.Rows))
			{
				int linesPerRow = this.GetLinesPerRow();
				try
				{
					rowNumber = ((row - this.addedHeaderLine - this.linePerRow 
						- GroupRowInfos.GetBelowGroupLineCount(false, row, linesPerRow))/linesPerRow);
				}
				catch
				{
					rowNumber = -1;
				}
			}
			return rowNumber;
		}
		#endregion

		#region SetContextMenu
		/// <summary>
		/// Grid에 ContextMenu를 설정합니다.(Grid의 Editor의 ContextMenu도 같이 설정)
		/// </summary>
		/// <param name="menu"></param>
		public virtual void SetContextMenu(ContextMenu menu)
		{
			try
			{
				this.ContextMenu = menu;
			}
			catch{}
		}
		#endregion

		#region SelectRow, UnSelectRow, IsSelectedRow
		/// <summary>
		/// 지정한 행을 선택합니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		public virtual void SelectRow(int rowNumber)
		{
			//지정한 행을 선택합니다.
			if ((rowNumber < 0) || (rowNumber >= this.LayoutTable.Rows.Count)) return;
			
			// 논리적인 row으로 물리적인 row Get
			// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
			int linesPerRow = this.GetLinesPerRow();
			int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
			for (int i = row ; i < row + linesPerRow ; i++)
			{
				for (int j = 0 ; j < this.Cols ; j++)
				{
					if (this[i,j] != null)
						this[i,j].Select = true;
				}
			}
		}
		/// <summary>
		/// 지정한 행을 선택해제합니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		public virtual void UnSelectRow(int rowNumber)
		{
			//지정한 행을 선택합니다.
			if ((rowNumber < 0) || (rowNumber >= this.LayoutTable.Rows.Count)) return;
			
			// 논리적인 row으로 물리적인 row Get
			// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
			int linesPerRow = this.GetLinesPerRow();
			int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
			for (int i = row ; i < row + linesPerRow ; i++)
			{
				for (int j = 0 ; j < this.Cols ; j++)
				{
					if (this[i,j] != null)
						this[i,j].Select = false;
				}
			}
		}
		/// <summary>
		/// 지정한 행이 선택되어 있는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		/// <returns> 선택되어 있으면 true, 아니면 false</returns>
		public virtual bool IsSelectedRow(int rowNumber)
		{
			//지정한 행을 선택합니다.
			if ((rowNumber < 0) || (rowNumber >= this.LayoutTable.Rows.Count)) return false;
			
			// 논리적인 row으로 물리적인 row Get
			// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
			// 행에 있는 전체Cell이 선택되어 있을때 선택된 것으로 처리함.
			int linesPerRow = this.GetLinesPerRow();
			int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
			int cellCount = 0, selectedCount = 0;
			for (int i = row ; i < row + linesPerRow ; i++)
			{
				for (int j = 0 ; j < this.Cols ; j++)
				{
					if (this[i,j] != null)
					{
						cellCount++;
						if (this[i,j].Select)
							selectedCount++;
					}
				}
			}
			if (cellCount == selectedCount)
				return true;
			else
				return false;
		}
		/// <summary>
		/// 모든 행을 모두 선택해제합니다.
		/// </summary>
		public virtual void UnSelectAll()
		{
			this.selection.Clear();
		}
		#endregion

		#region GetDisplayTextByInfo
		/// <summary>
		/// 컬럼정보를 이용하여 Display할 Text를 가져옵니다.
		/// </summary>
		/// <param name="info"> XGridCell 객체(컬럼정보) </param>
		/// <param name="dataValue"> 실제 값 </param>
		/// <returns> Display Text </returns>
		internal string GetDisplayTextByInfo(XGridCell info, object dataValue)
		{
			string displayText = string.Empty;

			// BinaryType은 displayText 없음
			if (info.CellType == XCellDataType.Binary) return displayText;
			//EditorStyle이 EditBox,DatePicker가 아니면 empty
			if ((info.EditorStyle != XCellEditorStyle.EditBox) && (info.EditorStyle != XCellEditorStyle.DatePicker)) return displayText;
			
			//Mask에 따라 DisplayText 설정
			//Text를 Mask에 맞추어 Set
			MaskType mType = MaskType.String;
			switch(info.CellType)
			{
				case XCellDataType.String:
				case XCellDataType.DateTime:
				case XCellDataType.Time:
				case XCellDataType.Number:
				case XCellDataType.Decimal:
					mType = (MaskType) Enum.Parse(typeof(MaskType), Enum.GetName(typeof(XCellDataType), info.CellType));
					try
					{
						//Decimal의 경우 Decimal Digits를 정확히 반영하지 않고, 값에따라 Display함 (마지막 Argument false로 설정함)
						//2006.01.06 DateTime,Time형이 Invalid일때 CellInfo의 InvalidDateIsStringEmpty속성에 따라 Return하도록 처리함.
						//true이면 "", false이면 0000/00/00 형식으로 Return
						//2006.03.13 ShowZeroDecimal 속성에 따라 .00형태를 보여줄지 여부를 결정함
						displayText = MaskHelper.GetDisplayText(mType, info.MaskSymbols, info.DecimalDigits, info.GeneralNumberFormat, dataValue, info.ShowZeroDecimal , info.InvalidDateIsStringEmpty);
					}
					catch
					{
						displayText = string.Empty;
					}
					//String형일때 PasswordChar가 있으면 dispText는 PasswordChar로 변경
					if ((info.CellType == XCellDataType.String) && (info.PasswordChar != (char) 0) && (displayText != string.Empty))
					{
						StringBuilder sb = new StringBuilder();
						for (int i = 0 ; i < displayText.Length ; i++)
							sb.Append(info.PasswordChar);
						displayText = sb.ToString();
					}
					break;

				case XCellDataType.Date:  //Date형은 일본연호 표시 처리
				case XCellDataType.Month:
					mType = (MaskType) Enum.Parse(typeof(MaskType), Enum.GetName(typeof(XCellDataType), info.CellType));
					if (info.IsJapanYearType)
					{
						try
						{
							//2006.01.06 DateTime,Time형이 Invalid일때 CellInfo의 InvalidDateIsStringEmpty속성에 따라 Return하도록 처리함.
							//true이면 "", false이면 0000/00/00 형식으로 Return
							displayText = JapanYearHelper.GetDisplayText(mType, dataValue, info.InvalidDateIsStringEmpty);
						}
						catch
						{
							displayText = string.Empty;
						}
					}
					else
					{
						try
						{
							//Decimal의 경우 Decimal Digits를 정확히 반영하지 않고, 값에따라 Display함 (마지막 Argument false로 설정함)
							//2006.01.06 DateTime,Time형이 Invalid일때 CellInfo의 InvalidDateIsStringEmpty속성에 따라 Return하도록 처리함.
							//true이면 "", false이면 0000/00/00 형식으로 Return
							displayText = MaskHelper.GetDisplayText(mType, info.MaskSymbols, info.DecimalDigits, info.GeneralNumberFormat, dataValue, false, info.InvalidDateIsStringEmpty);
						}
						catch
						{
							displayText = string.Empty;
						}
					}
					break;
			}
			return displayText;
		}
		#endregion

		#region SetFocusToItem
		public virtual bool SetFocusToItem(int rowNumber, string colName)
		{
			int index = 0;
			XGridCell cellInfo = null;
			int rowPos = 0;
			int rowSpan = 0;
			bool isMatch = false;
			int linesPerRow = this.GetLinesPerRow();
			if (rowNumber < 0) return false;
			if (rowNumber >= this.RowCount ) return false;
			
			try
			{
				for (index = 0; index < this.CellInfos.Count ; index ++)
				{
					cellInfo = this.CellInfos[index];
					if (cellInfo.CellName.ToUpper().Equals(colName.ToUpper()))
					{
						isMatch = true;
						break;
					}
				}

				if (!isMatch) return false;  // 대응되는 AEditGridCell가 없으면 return
				//NonVisible Column
				if (!cellInfo.IsVisible) return false;
			
				//논리적인 rowNumber를 물리적인 row로 변경
				if (this.AddedHeaderLine > 0)
					this.CellInfos.GetCellPositionByXGridCell(cellInfo, linesPerRow, out rowPos, out rowSpan);
				else
					rowPos = cellInfo.Row;
			
				// 논리적인 rowNum으로 물리적인 row Get
				// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
				int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow) + rowPos;

				//Cell Focus
				if (this[row, cellInfo.Col] != null)
					this[row, cellInfo.Col].Focus(false);
			}
			catch
			{
				return false;
			}
			return true;
		}
		public virtual bool SetFocusToItem(int rowNumber, int colNum)
		{
			int index = 0;
			XGridCell cellInfo = null;
			int rowPos = 0;
			int rowSpan = 0;
			bool isMatch = false;
			int linesPerRow = this.GetLinesPerRow();
			int colNumber = colNum;

			if (rowNumber < 0) return false;
			if (rowNumber >= this.RowCount) return false;

			//RowHeaderVisible이면 colNumber 하나 증가
			if (this.RowHeaderVisible)
				colNumber += 1;
			
			try
			{
				//xPos = 0 이고, yPos가 colNum인 AEditGridCell Get
				for (index = 0; index < this.CellInfos.Count ; index ++)
				{
					cellInfo = this.CellInfos[index];
					if (this.AddedHeaderLine > 0)
						this.CellInfos.GetCellPositionByXGridCell(cellInfo, linesPerRow, out rowPos, out rowSpan);
					else
						rowPos = cellInfo.Row;
					if ((rowPos == 0) && (cellInfo.Col == colNumber))
					{
						isMatch = true;
						break;
					}
				}
				
				if (!isMatch) return false;

				//NonVisible Column
				if (!cellInfo.IsVisible) return false;
			
				//논리적인 rowNumber를 물리적인 row로 변경
				if (this.AddedHeaderLine > 0)
					this.CellInfos.GetCellPositionByXGridCell(cellInfo, linesPerRow, out rowPos, out rowSpan);
				else
					rowPos = cellInfo.Row;
			
				// 논리적인 rowNum으로 물리적인 row Get
				// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
				int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow) + rowPos;

				//Cell Focus
				if (this[row, cellInfo.Col] != null)
					this[row, cellInfo.Col].Focus(false);
			}
			catch
			{
				return false;
			}
			return true;
		}
		#endregion

            #region QueryLayout(데이타를 조회하여 Grid를 Display), QueryLayoutStarting

            //private OracleDataReader xgridData = null;
            private IList<object[]> xgridData = null;
    //		private IDataReader xgridData = null;
            protected bool IsQueryCompleted = true; //조회 완료여부
            private const int QUERY_RECORD_UNIT = 200; //한번 조회시에 Record 건수(200건씩 조회)
            //private DataTable sourceTable = null;
            //private int sourceRowIndex = 0;

            public bool setDataForGrid(IList<object[]> lstGridData)
            {
                //Layout Reset
                this.Reset();
                string msg = "";
                if (lstGridData == null)
                {
                    msg = XMsg.GetMsg("M074") + "[" + Service.ErrMsg + "]";
                    return false;
                }

                bool hasRows = lstGridData.Count > 0;
                if (!hasRows)
                {
                    SetBottomRightImage(true);
                    DisplayCompleted = true;

                    SetServiceMsg(ServiceType.Query, ServiceMsgType.NoData); //조회 데이타가 없습니다.
                    return true;
                }
                xgridData = lstGridData;
                return QueryLayoutSubForOracle(true);
            }

            protected virtual void QueryLayoutStarting()
            {
                //SetValue를 시작할때 필요한 Logic 추가 (XEditGrid에서 편집중이면 편집 종료 처리)
            }

		public bool QueryLayout(bool isAllDataQuery)
		{
			//<미확정> SqlServer 이외에는 Oracle (DataReader사용)
			/*if (Service.CurrentDBKind == DataBaseKind.SqlServer)
				return QueryLayoutForSqlServer(isAllDataQuery);
			else*/
				return QueryLayoutForOracle(isAllDataQuery);
		}
		protected virtual bool QueryLayoutSub(bool isAllDataQuery)
		{
			//<미확정> SqlServer 이외에는 Oracle (DataReader사용)
			/*if (Service.CurrentDBKind == DataBaseKind.SqlServer)
				return QueryLayoutSubForSqlServer(isAllDataQuery);
			else*/
				return QueryLayoutSubForOracle(isAllDataQuery);
		}

		private bool QueryLayoutForOracle(bool isAllDataQuery)
		{
            this.mPage = 1;

			//조회 시작 Event Call (Bind 변수 동적으로 할당, 조건에 따른 조회여부 설정)
			CancelEventArgs xe = new CancelEventArgs();
			OnQueryStarting(xe);
			if (xe.Cancel)
			{
				//Layout Reset
				this.Reset();
				return false;
			}

			//2006.04.04 조회 Msg 처리
			SetServiceMsg(ServiceType.Query, ServiceMsgType.Processing);  //조회중입니다. Msg

			//Layout Reset
			this.Reset();
			string msg = "";

			if (this.executeQuery == null)
			{
                msg =  XMsg.GetMsg("M072"); //조회 SQL이 정의되지 않았습니다.
                //this.ShowErrMsg(msg);
                Logs.WriteLog(msg);
				return false;
			}
			
			this.IsQueryCompleted = true; //조회 완료됨

			//기존 DataReader가 있을때 이미 Open되어 있으면 Close
			/*if ((this.xgridData != null) && !xgridData.IsClosed)
			{
				this.xgridData.Close();
				this.xgridData = null;
			}*/

			//DataReader Get
            if (!isAllDataQuery)
            {
                if (this.BindVarList.Contains("f_page_number"))
                {
                    this.BindVarList["f_page_number"].VarValue = this.mPage.ToString();
                }
            }
            else
            {
                if (this.BindVarList.Contains("f_page_number"))
                {
                    this.BindVarList["f_page_number"].VarValue = String.Empty;
                }
            }
            this.xgridData = executeQuery(this.BindVarList);
			//SQL 에러
            if (xgridData == null)
			{
				msg = XMsg.GetMsg("M074") + "[" + Service.ErrMsg + "]"; //데이타 조회실패
				//this.ShowErrMsg(msg); //메세지는 개발자가 보여줄지 말지 결정한다.
				//2007.11.08 추가 QueryEnd Event Invoke (조회실패)
				OnQueryEnd(new QueryEndEventArgs(this.callerID, false, msg));
				return false;
			}
			//조회된 데이타가 없으면 Return
			/*IDataReader는 HasRows 속성이 없고, 상속한 Class만 가지고 있다. 나머지 Read, GetValues()는 IDataReader로
			 * 사용하고 HasRows판단은 각 Class로 변환하여 판단하자 */
            bool hasRows = xgridData.Count > 0;
			/*if (xgridData is System.Data.OracleClient.OracleDataReader)
				hasRows = ((System.Data.OracleClient.OracleDataReader) xgridData).HasRows;
			else if (xgridData is System.Data.SqlClient.SqlDataReader)
				hasRows = ((System.Data.SqlClient.SqlDataReader) xgridData).HasRows;
			else if (xgridData is System.Data.Odbc.OdbcDataReader)
				hasRows = ((System.Data.Odbc.OdbcDataReader) xgridData).HasRows;
			else if (xgridData is System.Data.OleDb.OleDbDataReader)
				hasRows = ((System.Data.OleDb.OleDbDataReader) xgridData).HasRows;
			else 
				hasRows = false; //지원하지 않음*/

			if (!hasRows)
			{
				this.SetBottomRightImage(true);
				this.DisplayCompleted = true;
				//2007.11.08 추가 QueryEnd Event Invoke (조회성공)
				//<미확정> callerID는 XEditGrid에만 있으므로 1로 설정한다.
				OnQueryEnd(new QueryEndEventArgs(this.callerID, true,""));
				SetServiceMsg(ServiceType.Query, ServiceMsgType.NoData);  //조회 데이타가 없습니다.
				return true;
			}
			
			bool ret = QueryLayoutSub(isAllDataQuery);

			//2007.11.08 추가 QueryEnd Event Invoke (조회성공 OR 실패)
			msg = (ret ? "" : XMsg.GetMsg("M074")); //실패시만 데이타조회에러 MSG SET
			OnQueryEnd(new QueryEndEventArgs(this.callerID, ret,""));

			return ret;
		}

        /// <summary>
        /// 2015/08/19: pagination QueryLayout
        /// </summary>
        /// <param name="isAllDataQuery"></param>
        /// <returns></returns>
        //private bool QueryLayoutForOracle(bool isAllDataQuery, int pageNumber)
        //{
        //    //?? ?? Event Call (Bind ?? ???? ??, ??? ?? ???? ??)
        //    CancelEventArgs xe = new CancelEventArgs();
        //    OnQueryStarting(xe);
        //    if (xe.Cancel)
        //    {
        //        //Layout Reset
        //        this.Reset();
        //        return false;
        //    }

        //    //2006.04.04 ?? Msg ??
        //    SetServiceMsg(ServiceType.Query, ServiceMsgType.Processing);  //??????. Msg

        //    //Layout Reset
        //    this.Reset();
        //    string msg = "";

        //    if (this.executeQuery == null)
        //    {
        //        msg = XMsg.GetMsg("M072"); //?? SQL? ???? ?????.
        //        this.ShowErrMsg(msg);
        //        return false;
        //    }

        //    this.IsQueryCompleted = true; //?? ???

        //    //?? DataReader? ??? ?? Open?? ??? Close
        //    /*if ((this.xgridData != null) && !xgridData.IsClosed)
        //    {
        //        this.xgridData.Close();
        //        this.xgridData = null;
        //    }*/

        //    //DataReader Get
        //    if (this.BindVarList.Contains("f_page_number"))
        //    {
        //        this.BindVarList["f_page_number"].VarValue = this.mPage.ToString();
        //    }

        //    this.xgridData = executeQuery(this.BindVarList);
        //    //SQL ??
        //    if (xgridData == null)
        //    {
        //        msg = XMsg.GetMsg("M074") + "[" + Service.ErrMsg + "]"; //??? ????
        //        //this.ShowErrMsg(msg); //???? ???? ???? ?? ????.
        //        //2007.11.08 ?? QueryEnd Event Invoke (????)
        //        OnQueryEnd(new QueryEndEventArgs(this.callerID, false, msg));
        //        return false;
        //    }
        //    //??? ???? ??? Return
        //    /*IDataReader? HasRows ??? ??, ??? Class? ??? ??. ??? Read, GetValues()? IDataReader?
        //     * ???? HasRows??? ? Class? ???? ???? */
        //    bool hasRows = xgridData.Count > 0;
        //    /*if (xgridData is System.Data.OracleClient.OracleDataReader)
        //        hasRows = ((System.Data.OracleClient.OracleDataReader) xgridData).HasRows;
        //    else if (xgridData is System.Data.SqlClient.SqlDataReader)
        //        hasRows = ((System.Data.SqlClient.SqlDataReader) xgridData).HasRows;
        //    else if (xgridData is System.Data.Odbc.OdbcDataReader)
        //        hasRows = ((System.Data.Odbc.OdbcDataReader) xgridData).HasRows;
        //    else if (xgridData is System.Data.OleDb.OleDbDataReader)
        //        hasRows = ((System.Data.OleDb.OleDbDataReader) xgridData).HasRows;
        //    else 
        //        hasRows = false; //???? ??*/

        //    if (!hasRows)
        //    {
        //        this.SetBottomRightImage(true);
        //        this.DisplayCompleted = true;
        //        //2007.11.08 ?? QueryEnd Event Invoke (????)
        //        //<???> callerID? XEditGrid?? ???? 1? ????.
        //        OnQueryEnd(new QueryEndEventArgs(this.callerID, true, ""));
        //        SetServiceMsg(ServiceType.Query, ServiceMsgType.NoData);  //?? ???? ????.
        //        return true;
        //    }

        //    bool ret = QueryLayoutSub(isAllDataQuery);

        //    //2007.11.08 ?? QueryEnd Event Invoke (???? OR ??)
        //    msg = (ret ? "" : XMsg.GetMsg("M074")); //???? ??????? MSG SET
        //    OnQueryEnd(new QueryEndEventArgs(this.callerID, ret, ""));

        //    return ret;
        //}

		private bool QueryLayoutSubForOracle(bool isAllDataQuery)
		{

			try
			{
				if (this.xgridData == null)
				{
					this.IsQueryCompleted = true;
					this.SetBottomRightImage(true);
					this.DisplayCompleted = true;
					return false;
				}

				//Fill Starting
				QueryLayoutStarting();

				
				int bfRowCount = this.DisplayedRowCount; //Display된 Row의 갯수

				//조회된 데이타로 LayoutTable에 담음, OrigDataTable에도 함께 담음
				DataRow dtRow = null;
				//컬럼 갯수만큼 할당
				//object[] dataValues = new object[this.cellInfos.Count];
				int dataCount = 0, colIndex = 0, rowCount = 0;
				//while (xgridData.Read())
                foreach(object[] dataValues in xgridData)
				{
                    dataCount = dataValues.Length;
					dtRow = LayoutTable.NewRow();
					colIndex = 0;
					foreach (XGridCell info in this.cellInfos)
					{
						switch (info.CellType)
						{
							case XCellDataType.String:
							case XCellDataType.DateTime:
							case XCellDataType.Time:
							case XCellDataType.Month:
							case XCellDataType.Binary:
								//Data의 갯수보다 작으면
								if (colIndex < dataCount)
								{
									try
									{
										dtRow[colIndex] = dataValues[colIndex];
									}
									catch
									{
										dtRow[colIndex] = DBNull.Value;
									}
								}
								break;
							case XCellDataType.Number:
							case XCellDataType.Decimal:
								//Data의 갯수보다 작으면
								if (colIndex < dataCount)
								{
									try
									{
										dtRow[colIndex] = Double.Parse(dataValues[colIndex].ToString());
									}
									catch
									{
										dtRow[colIndex] = DBNull.Value;
									}
								}
								break;
                            case XCellDataType.Date:
                                //Data의 갯수보다 작으면
                                if (colIndex < dataCount)
                                {
                                    try
                                    {
                                        dtRow[colIndex] = DateTime.Parse(dataValues[colIndex].ToString()).ToString("yyyy/MM/dd").Replace("-", "/");
                                    }
                                    catch
                                    {
                                        dtRow[colIndex] = DBNull.Value;
                                    }
                                }
                                break;
                        }
						colIndex++;
					}
					LayoutTable.Rows.Add(dtRow);
					OrigLayoutTable.Rows.Add(dtRow.ItemArray);
					//2005.11.09 XEditGrid에서 처음조회후 값을 수정하고 다시 연속조회하여 SetValue시에
					//LayoutTable전체를 AcceptChanges하면 이전에 수정된 값도 Unchanged상태가 됨
					//이를 방지하기 위해 DataRow별로 AcceptChange함, OrigLayoutTable은 관계없음
					dtRow.AcceptChanges();
					rowCount++;
					//전체조회가 아니고 단위 조회당 건수(200건) 보다 크면 Break
					if (!isAllDataQuery && (rowCount >= QUERY_RECORD_UNIT))
					{
						this.IsQueryCompleted = false; //계속조회중
						break;
					}
				}
				//데이타 모두 조회이면 조회 완료 Flag Set
				if (isAllDataQuery || (rowCount < QUERY_RECORD_UNIT))
				{
					this.IsQueryCompleted = true;
					SetServiceMsg(ServiceType.Query, ServiceMsgType.Normal);  //조회가 완료되었습니다.
				}
				else
					SetServiceMsg(ServiceType.Query, ServiceMsgType.ContQry);  //조회가 계속됩니다.

				//AcceptChanges
				OrigLayoutTable.AcceptChanges();
				//DisplayDataSub (조회된 데이타는 Display
				DisplayDataSub(this.DisplayedRowCount, rowCount, true);
				
			}
			catch(Exception xe)
			{
				this.IsQueryCompleted = true;
				this.SetBottomRightImage(true);
				this.DisplayCompleted = true;
				this.ShowErrMsg(xe.Message);
				return false;
			}
			finally
			{
				//조회 완료시는 Reader Close
				if (this.IsQueryCompleted && this.xgridData != null)
				{
					//this.xgridData.Close();
					this.xgridData = null;
				}
			}
			return true;

		}

        /// <summary>
        /// 2015/08/19 pagination
        /// </summary>
        /// <param name="isAllDataQuery"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        private bool QueryLayoutSubForOracle(bool isAllDataQuery, int pageNumber)
        {

            try
            {
                if (this.BindVarList.Contains("f_page_number"))
                {
                    this.BindVarList["f_page_number"].VarValue = this.mPage.ToString();
                }

                this.xgridData = executeQuery(this.BindVarList);

                if (this.xgridData == null)
                {
                    this.IsQueryCompleted = true;
                    this.SetBottomRightImage(true);
                    this.DisplayCompleted = true;
                    return false;
                }

                //Fill Starting
                QueryLayoutStarting();


                int bfRowCount = this.DisplayedRowCount; //Display된 Row의 갯수

                //조회된 데이타로 LayoutTable에 담음, OrigDataTable에도 함께 담음
                DataRow dtRow = null;
                //컬럼 갯수만큼 할당
                //object[] dataValues = new object[this.cellInfos.Count];
                int dataCount = 0, colIndex = 0, rowCount = 0;
                //while (xgridData.Read())
                foreach (object[] dataValues in xgridData)
                {
                    dataCount = dataValues.Length;
                    dtRow = LayoutTable.NewRow();
                    colIndex = 0;
                    foreach (XGridCell info in this.cellInfos)
                    {
                        switch (info.CellType)
                        {
                            case XCellDataType.String:
                            case XCellDataType.DateTime:
                            case XCellDataType.Time:
                            case XCellDataType.Month:
                            case XCellDataType.Binary:
                                //Data의 갯수보다 작으면
                                if (colIndex < dataCount)
                                {
                                    try
                                    {
                                        dtRow[colIndex] = dataValues[colIndex];
                                    }
                                    catch
                                    {
                                        dtRow[colIndex] = DBNull.Value;
                                    }
                                }
                                break;
                            case XCellDataType.Number:
                            case XCellDataType.Decimal:
                                //Data의 갯수보다 작으면
                                if (colIndex < dataCount)
                                {
                                    try
                                    {
                                        dtRow[colIndex] = Double.Parse(dataValues[colIndex].ToString());
                                    }
                                    catch
                                    {
                                        dtRow[colIndex] = DBNull.Value;
                                    }
                                }
                                break;
                            case XCellDataType.Date:
                                //Data의 갯수보다 작으면
                                if (colIndex < dataCount)
                                {
                                    try
                                    {
                                        dtRow[colIndex] = DateTime.Parse(dataValues[colIndex].ToString()).ToString("yyyy/MM/dd").Replace("-", "/");
                                    }
                                    catch
                                    {
                                        dtRow[colIndex] = DBNull.Value;
                                    }
                                }
                                break;
                        }
                        colIndex++;
                    }
                    LayoutTable.Rows.Add(dtRow);
                    OrigLayoutTable.Rows.Add(dtRow.ItemArray);
                    //2005.11.09 XEditGrid에서 처음조회후 값을 수정하고 다시 연속조회하여 SetValue시에
                    //LayoutTable전체를 AcceptChanges하면 이전에 수정된 값도 Unchanged상태가 됨
                    //이를 방지하기 위해 DataRow별로 AcceptChange함, OrigLayoutTable은 관계없음
                    dtRow.AcceptChanges();
                    rowCount++;
                    //전체조회가 아니고 단위 조회당 건수(200건) 보다 크면 Break
                    if (!isAllDataQuery && (rowCount >= QUERY_RECORD_UNIT))
                    {
                        this.IsQueryCompleted = false; //계속조회중
                        break;
                    }
                }
                //데이타 모두 조회이면 조회 완료 Flag Set
                if (isAllDataQuery || (rowCount < QUERY_RECORD_UNIT))
                {
                    this.IsQueryCompleted = true;
                    SetServiceMsg(ServiceType.Query, ServiceMsgType.Normal);  //조회가 완료되었습니다.
                }
                else
                    SetServiceMsg(ServiceType.Query, ServiceMsgType.ContQry);  //조회가 계속됩니다.

                //AcceptChanges
                OrigLayoutTable.AcceptChanges();
                //DisplayDataSub (조회된 데이타는 Display
                DisplayDataSub(this.DisplayedRowCount, rowCount, true);

            }
            catch (Exception xe)
            {
                this.IsQueryCompleted = true;
                this.SetBottomRightImage(true);
                this.DisplayCompleted = true;
                this.ShowErrMsg(xe.Message);
                return false;
            }
            finally
            {
                //조회 완료시는 Reader Close
                if (this.IsQueryCompleted && this.xgridData != null)
                {
                    //this.xgridData.Close();
                    this.xgridData = null;
                }
            }
            return true;

        }

		//For SqlServer ExecuteDataTable 사용
		/*private bool QueryLayoutForSqlServer(bool isAllDataQuery)
		{
			//조회 시작 Event Call (Bind 변수 동적으로 할당, 조건에 따른 조회여부 설정)
			CancelEventArgs xe = new CancelEventArgs();
			OnQueryStarting(xe);
			if (xe.Cancel)
			{
				//Layout Reset
				this.Reset();
				return false;
			}

			//2006.04.04 조회 Msg 처리
			SetServiceMsg(ServiceType.Query, ServiceMsgType.Processing);  //조회중입니다. Msg

			//Layout Reset
			this.Reset();
			string msg = "";

			if (this.querySQL == "")
			{
				msg =  XMsg.GetMsg("M072"); //조회 SQL이 정의되지 않았습니다.
				this.ShowErrMsg(msg);
				return false;
			}

			this.IsQueryCompleted = true; //조회 완료됨

			//DataTable Get
			sourceTable = Service.ExecuteDataTable(this.querySQL, this.bindVarList);
			//SQL 에러
			if (sourceTable == null)
			{
				msg = XMsg.GetMsg("M074") + "[" + Service.ErrMsg + "]"; //데이타 조회실패
				//this.ShowErrMsg(msg); //메세지는 개발자가 보여줄지 말지를 결정한다.
				//2007.11.08 추가 QueryEnd Event Invoke (조회실패)
				OnQueryEnd(new QueryEndEventArgs(this.callerID, false, msg));
				return false;
			}

			//조회된 데이타가 없으면 Return
			if (sourceTable.Rows.Count < 1)
			{
				this.SetBottomRightImage(true);
				this.DisplayCompleted = true;
				//2007.11.08 추가 QueryEnd Event Invoke (조회성공)
				OnQueryEnd(new QueryEndEventArgs(this.callerID, true,""));
				SetServiceMsg(ServiceType.Query, ServiceMsgType.NoData);  //조회 데이타가 없습니다.
				return true;
			}
			bool ret = QueryLayoutSub(isAllDataQuery);
			msg = (ret ? "" : XMsg.GetMsg("M074")) ; //실패시만 데이타조회에러 MSG SET
			//2007.11.08 추가 QueryEnd Event Invoke (조회성공 OR 실패)
			OnQueryEnd(new QueryEndEventArgs(this.callerID, ret, msg));

			return ret;
		}*/
		/*private bool QueryLayoutSubForSqlServer(bool isAllDataQuery)
		{

			try
			{
				//Fill Starting
				QueryLayoutStarting();


				int bfRowCount = this.DisplayedRowCount; //Display된 Row의 갯수

				//조회된 데이타로 LayoutTable에 담음, OrigDataTable에도 함께 담음
				DataRow dtRow = null, dataRow = null;
				//컬럼 갯수만큼 할당
				object[] dataValues = new object[this.cellInfos.Count];
				int dataCount = sourceTable.Columns.Count;
				int colIndex = 0, rowCount = 0;
				for (int i = this.sourceRowIndex ; i < this.sourceTable.Rows.Count ; i++)
				{
					dataRow = sourceTable.Rows[i];
					dtRow = LayoutTable.NewRow();
					colIndex = 0;
					foreach (XGridCell info in this.cellInfos)
					{
						switch (info.CellType)
						{
							case XCellDataType.String:
							case XCellDataType.DateTime:
							case XCellDataType.Time:
							case XCellDataType.Month:
							case XCellDataType.Binary:
								//Data의 갯수보다 작으면
								if (colIndex < dataCount)
								{
									try
									{
										dtRow[colIndex] = dataRow[colIndex];
									}
									catch
									{
										dtRow[colIndex] = DBNull.Value;
									}
								}
								break;
							case XCellDataType.Number:
							case XCellDataType.Decimal:
								//Data의 갯수보다 작으면
								if (colIndex < dataCount)
								{
									try
									{
										dtRow[colIndex] = Double.Parse(dataRow[colIndex].ToString());
									}
									catch
									{
										dtRow[colIndex] = DBNull.Value;
									}
								}
								break;
                            case XCellDataType.Date:
                                //Data의 갯수보다 작으면
                                if (colIndex < dataCount)
                                {
                                    try
                                    {
                                        dtRow[colIndex] = DateTime.Parse(dataRow[colIndex].ToString()).ToString("yyyy/MM/dd").Replace("-", "/");
                                    }
                                    catch
                                    {
                                        dtRow[colIndex] = DBNull.Value;
                                    }
                                }
                                break;
						}
						colIndex++;
					}
					LayoutTable.Rows.Add(dtRow);
					OrigLayoutTable.Rows.Add(dtRow.ItemArray);
					//2005.11.09 uEditGrid에서 처음조회후 값을 수정하고 다시 연속조회하여 SetValue시에
					//LayoutTable전체를 AcceptChanges하면 이전에 수정된 값도 Unchanged상태가 됨
					//이를 방지하기 위해 DataRow별로 AcceptChange함, OrigLayoutTable은 관계없음
					dtRow.AcceptChanges();
					rowCount++;
					//source의 Index 증가
					this.sourceRowIndex++;
					//전체조회가 아니고 단위 조회당 건수(200건) 보다 크면 Break
					if (!isAllDataQuery && (rowCount >= QUERY_RECORD_UNIT))
					{
						this.IsQueryCompleted = false; //계속조회중
						break;
					}

				}
				//데이타 모두 조회이면 조회 완료 Flag Set
				if (isAllDataQuery || (rowCount < QUERY_RECORD_UNIT))
				{
					this.IsQueryCompleted = true;
					SetServiceMsg(ServiceType.Query, ServiceMsgType.Normal);  //조회가 완료되었습니다.
				}
				else
					SetServiceMsg(ServiceType.Query, ServiceMsgType.ContQry);  //조회가 계속됩니다.

				//AcceptChanges
				OrigLayoutTable.AcceptChanges();
				//DisplayDataSub (조회된 데이타는 Display
				DisplayDataSub(this.DisplayedRowCount, rowCount, true);

			}
			catch (Exception xe)
			{
				this.IsQueryCompleted = true;
				this.SetBottomRightImage(true);
				this.DisplayCompleted = true;
				this.ShowErrMsg(xe.Message);
				return false;
			}
			return true;

		}*/
		#endregion

		#region SetRowVisible, IsVisibleRow
		/// <summary>
		/// 지정한 행을 보이게하거나, 안보이게 합니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		public virtual void SetRowVisible(int rowNumber, bool isVisible)
		{
			//RowNumber Check
			if ((rowNumber < 0) || (rowNumber >= this.layoutTable.Rows.Count)) 
			{
				string msg = "[SetRowVisible]" + XMsg.GetMsg("M009") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M004"); //행번호를 잘못 입력하셨습니다.
				ShowErrMsg(msg);
				return;
			}
			try
			{
				// 논리적인 rowNum으로 물리적인 row Get
				// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
				int linesPerRow = this.GetLinesPerRow();
				int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);

				//해당 row부터, 한 행의 Line수까지 Row의 Height를 Visible시는 DefaultHeight로 false시는 0
				if (isVisible)
				{
					for (int i = row ; i < row + linesPerRow ; i++)
						this.AutoSizeRow(i, this.DefaultHeight);
				}
				else
				{
					for (int i = row ; i < row + linesPerRow ; i++)
						this.AutoSizeRow(i, 0);
				}
			}
			catch{}
		}
		/// <summary>
		/// 지정한 행이 보이는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="rowNumber"></param>
		/// <returns></returns>
		public virtual bool IsVisibleRow(int rowNumber)
		{
			if ((rowNumber < 0) || (rowNumber >= this.layoutTable.Rows.Count)) 
			{
				string msg = "[IsVisibleRow]" + XMsg.GetMsg("M009") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M004"); //행번호를 잘못 입력하셨습니다.
				ShowErrMsg(msg);
				return false;
			}
			try
			{
				// 논리적인 rowNum으로 물리적인 row Get
				// = HeaderLine수 + rowNum보다 작은 GroupRow의 Line수 + rowNum * 한 Row의 Line수
				int linesPerRow = this.GetLinesPerRow();
				int row = (rowNumber*linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);

				if (this.cellRowInfo[row].Height == 0)
					return false;
				else
					return true;
			}
			catch
			{
				return false;
			}

			
		}
		#endregion

		#region IsRepeatingValue
		/// <summary>
		/// 특정 Cell을 Paint시에 그 컬럼이 SupressRepeating컬럼일때 SupressColumn으로 지정된 컬럼의
		/// 이전값과 비교하여 반복되는 값인지 여부 Check (ACell::CellDisplayText에서 Call)
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		internal bool IsRepeatingValue(int row)
		{
			int rowNumber = this.GetLogicalRowNumber(row);
			if ((rowNumber < 1) || (rowNumber >= this.RowCount)) return false;
			//SupressRepeating Column으로 지정된 컬럼의 이전행의 값과 비교하여 값을 비교하여 
			//값이 같으면 true, 아니면 false
			foreach (string colName in this.supressColumnList)
				if (!this.layoutTable.Rows[rowNumber -1][colName].Equals(layoutTable.Rows[rowNumber][colName]))
					return false;
			return true;
		}
		#endregion

		#region SetTopRow, SetBottomRow, SetLeftColumn, SetRigthColumn(지정한 행이 맨처음,마지막에, 지정한 컬럼을 왼쪽, 오른쪽으로 Scroll)
		public void SetTopRow(int rowNumber)
		{
			try
			{
				string msg = "";
				if ((rowNumber < 0) || (rowNumber >= this.DisplayedRowCount))
				{
					msg = "[SetTopRow]" + XMsg.GetMsg("M009") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M004"); //행번호를 잘못 입력하셨습니다.
					ShowErrMsg(msg);
					return;
				}
				//물리적 Cell로 변경
				int headerCnt = this.addedHeaderLine + this.linePerRow;
				int linesPerRow = this.GetLinesPerRow();
				int row = (rowNumber*linesPerRow) + headerCnt + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
				//FixedRows가 Header의 갯수인 경우만 적용
				//FixedRows 적용된 상태에서도 처리해야함(단 row가 FixedRows 보다 작으면 적용되면 안됨)
				if (row < this.fixedRows)
				{
					msg = "[SetTopRow]" + XMsg.GetMsg("M059") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M060"); //"지정한 행[" + rowNumber.ToString() + "]이 고정행 영역에 속하므로 적용할 수 없습니다"
					this.ShowErrMsg(msg);
					return;
				}
				XCell cell = (this.rowHeaderVisible ? this[row,1] : this[row, 0]);
				if (cell != null)
				{
					//Cell의 DisplayRect를 Header 다음으로 위치하도록 Scroll 처리함
					int headerBottom = this.cellRowInfo[fixedRows - 1].Top + this.cellRowInfo[fixedRows - 1].Height;
					Rectangle rect = cell.DisplayRectangle;
					Point l_scrollPos = this.CustomScrollPosition;
					if (rect.Top != headerBottom)
					{
						//ScrollPos 설정
						l_scrollPos.Y += headerBottom - rect.Top;
						this.CustomScrollPosition = new Point(l_scrollPos.X, l_scrollPos.Y);
						//Focus, Grid에 Focus가 있는지 여부는 Check하지 않음
						cell.Focus(false);
					}
				}
			}
			catch{}
		}
		public void SetBottomRow(int rowNumber)
		{
			try
			{
				string msg = "";
				if ((rowNumber < 0) || (rowNumber >= this.DisplayedRowCount))
				{
					msg = "[SetBottomRow]" + XMsg.GetMsg("M009") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M004"); //행번호를 잘못 입력하셨습니다.
					ShowErrMsg(msg);
					return;
				}
				//FixedRows가 Header의 갯수인 경우만 적용
				int headerCnt = this.addedHeaderLine + this.linePerRow;
				//물리적 Cell로 변경
				int linesPerRow = this.GetLinesPerRow();
				int row = (rowNumber*linesPerRow) + headerCnt + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
				//FixedRows 적용된 상태에서도 처리해야함(단 row가 FixedRows 보다 작으면 적용되면 안됨)
				if (row < this.fixedRows)
				{
					msg = "[SetBottomRow]" + XMsg.GetMsg("M059") + "[" + rowNumber.ToString() + "]" + XMsg.GetMsg("M060"); //"지정한 행[" + rowNumber.ToString() + "]이 고정행 영역에 속하므로 적용할 수 없습니다"
					this.ShowErrMsg(msg);
					return;
				}

				XCell cell = (this.rowHeaderVisible ? this[row,1] : this[row, 0]);
				if (cell != null)
				{
					//절대좌표가 Grid의 Bottom보다 작으면 Scroll.Y = 0
					Rectangle aRect = cell.AbsoluteRectangle;
					Rectangle gridRect = this.CustomClientRectangle; //ScrollBar를 뺀 영역 자표
					Rectangle dRect = cell.DisplayRectangle;
					Point l_scrollPos = this.CustomScrollPosition;
					int cellBottom = dRect.Bottom;
					//한행의 Line수가 2이상일때는 아래Row의 Height도 고려해야함
					if (linesPerRow >= 2)
					{
						for (int i = row + 1 ; i < row + linesPerRow ; i++)
							cellBottom += this.CellRowInfo[i].Height;
					}
					if (aRect.Bottom < gridRect.Bottom)
					{
						l_scrollPos.Y = 0;
						this.CustomScrollPosition = new Point(l_scrollPos.X, l_scrollPos.Y);
						//Focus, Grid에 Focus가 있는지 여부는 Check하지 않음
						cell.Focus(false);
					}
						//else if (dRect.Bottom != gridRect.Bottom)
					else if (cellBottom != gridRect.Bottom)
					{
						//ScrollPos 설정
						l_scrollPos.Y += gridRect.Bottom - cellBottom;
						this.CustomScrollPosition = new Point(l_scrollPos.X, l_scrollPos.Y);
						//Focus, Grid에 Focus가 있는지 여부는 Check하지 않음
						cell.Focus(false);
					}
				}
			}
			catch{}
		}
		//지정한 컬럼을 맨 좌측으로 이동
		public void SetLeftColumn(string colName)
		{
			try
			{
				string msg = "";
				if (!this.CellInfos.Contains(colName))
				{
					msg = "[SetLeftColum]" + XMsg.GetMsg("M003") + "[" + colName + "]" + XMsg.GetMsg("M004"); // "컬럼명[" + colName + "]를 잘못 지정하셨습니다."
					ShowErrMsg(msg);
					return;
				}
				if (this.RowCount < 1)
				{
					msg = "[SetLeftColumn]" + XMsg.GetMsg("M061"); // Grid에 데이타가 없습니다."
					ShowErrMsg(msg);
					return;
				}
				//FixedCols가 행번호 Visible이면 1,아니면 0이어야 가능(FixedCols가 설정된 상태는 안됨)
				//FixedCols 적용된 상태에서도 처리해야함(단 AGridCell의 col이 fixedCols 내에 있으면 안됨)
				XGridCell info = this.CellInfos[colName];
				if (info.Col < this.fixedCols)
				{
					msg = "[SetLeftColumn]" + XMsg.GetMsg("M043") + "[" + colName + "]" + XMsg.GetMsg("M062"); // 컬럼[" + colName + "]이 고정된열 영역에 있으므로 적용할 수 없습니다.[SetLeftColumn]"
					this.ShowErrMsg(msg);
					return;
				}
				
				//첫번째 행의 Cell Get
				XCell cell = this[0, colName];
				//첫번째행의 Cell Get
				if (cell != null)
				{
					//DisplayRect와 ScrollPos의 차이만큼 적용함
					Rectangle rect = cell.DisplayRectangle;
					Point l_scrollPos = this.CustomScrollPosition;
					//Left 기준은 FixedCols -1 의 Left + Width
					int baseLeft = this.cellColInfo[fixedCols -1].Left + cellColInfo[fixedCols -1].Width;
					if (rect.Left != baseLeft)
					{
						//ScrollPos X설정
						l_scrollPos.X += baseLeft - rect.Left;
						this.CustomScrollPosition = new Point(l_scrollPos.X, l_scrollPos.Y);
					}
				}
			}
			catch{}
		}
		//지정한 컬럼을 맨 우측으로 이동
		public void SetRightColumn(string colName)
		{
			string msg;
			try
			{
				if (!this.CellInfos.Contains(colName))
				{
					msg = "[SetRightColumn]" + XMsg.GetMsg("M003") + "[" + colName + "]" + XMsg.GetMsg("M004"); // "컬럼명[" + colName + "]를 잘못 지정하셨습니다."
					ShowErrMsg(msg);
					return;
				}
				if (this.RowCount < 1)
				{
					msg = "[SetRightColumn]" + XMsg.GetMsg("M061"); // Grid에 데이타가 없습니다."
					ShowErrMsg(msg);
					return;
				}
				//FixedCols가 행번호 Visible이면 1,아니면 0이어야 가능(FixedCols가 설정된 상태는 안됨)
				//FixedCols 적용된 상태에서도 처리해야함(단 AGridCell의 col이 fixedCols 내에 있으면 안됨)
				XGridCell info = this.CellInfos[colName];
				if (info.Col < this.fixedCols)
				{
					msg = "[SetRightColumn]" + XMsg.GetMsg("M043") + "[" + colName + "]" + XMsg.GetMsg("M062"); // 컬럼[" + colName + "]이 고정된열 영역에 있으므로 적용할 수 없습니다.[SetLeftColumn]"
					this.ShowErrMsg(msg);
					return;
				}
				
				//첫번째 행의 Cell Get
				XCell cell = this[0, colName];
				//첫번째행의 Cell Get
				if (cell != null)
				{
					//절대좌표가 Grid의 Right보다 작으면 CustomScrollPos.X = 0 (ScrollX없음)
					Rectangle aRect = cell.AbsoluteRectangle;
					Rectangle gridRect = this.CustomClientRectangle; //ScrollBar를 뺀 영역 자표
					//DisplayRect와 ScrollPos의 차이만큼 적용함
					Rectangle dRect = cell.DisplayRectangle;
					Point l_scrollPos = this.CustomScrollPosition;
					if (aRect.Right < gridRect.Right)
					{
						l_scrollPos.X = 0;
						this.CustomScrollPosition = new Point(l_scrollPos.X, l_scrollPos.Y);
					}
					else if (dRect.Right != gridRect.Right)
					{
						//ScrollPos X설정
						l_scrollPos.X += gridRect.Right - dRect.Right;
						this.CustomScrollPosition = new Point(l_scrollPos.X, l_scrollPos.Y);
					}
				}
			}
			catch{}
		}
		#endregion

		#region ImportRowRange(DataRow를 그대로 지정한 행 아래에 Import)
		public virtual bool ImportRowRange(DataTable table, int row)
		{
			if (table == null) return false;
			if (table.Rows.Count < 0) return false;
			DataRow[] dtRows = new DataRow[table.Rows.Count];
			for (int i = 0 ; i < dtRows.Length ; i++)
				dtRows[i] = table.Rows[i];

			return ImportRowRange(dtRows, row);

		}
		public virtual bool ImportRowRange(DataRow[] dtRows, int row)
		{
			string msg = "";
			//필터링중이면 Insert불가
			if (this.IsFiltering)
			{
				msg = XMsg.GetMsg("M035"); // 필터링중에는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			//Computed 컬럼이 있거나, Grouping된 상태에서는 행입력불가
			if (this.GroupInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M036"); // 그룹핑한 Grid는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			if (this.ComputedCellInfos.Count > 0)
			{
				msg = XMsg.GetMsg("M037"); // Computed컬럼이 사용된 Grid는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}
			//조회 미완료시는 Import불가
			if (!this.IsQueryCompleted)
			{
				msg = XMsg.GetMsg("M038"); // 조회미완료된 상태에서는 행Import 불가합니다."
				ShowErrMsg(msg);
				return false;
			}

			int bfRowCount = this.DisplayedRowCount; //현재 Display된 Row의 갯수
			int bfRows = this.Rows;  // Display되는 Rows(Header포함)
			int rowPos = 0;
			int rowSpan = 1;
			int sourceIndex = 0;
			int destinationIndex = 0;
			int copyLength = 0;
			int startRowIndex = 0;  
			int rowNumber = row ;
			int linesPerRow = this.GetLinesPerRow();
			int dispRowNumber = 0;
			int rowHeaderIndex = 0;
			string displayText = string.Empty;
			object dataValue = string.Empty;
			int importCount = dtRows.Length;
			ArrayList columnList = new ArrayList();
			DataRow dataRow = null, origDataRow = null;
			
			if (this.LayoutTable == null) return false;
			if (importCount <= 0) return false;
			
			//Cell의 Position 정보 계산
			this.CalcRowPosition();

			// 그리기 멈춤
			this.Redraw = false;

			try
			{	
				//dtRow에서 DataTable에서 포함된 컬럼중 Grid의 컬럼과 일치하는 컬럼 List Get
				foreach (XGridCell info in this.CellInfos)
					if (dtRows[0].Table.Columns.Contains(info.CellName))
						columnList.Add(info.CellName);
				// Row증가
				this.Rows += linesPerRow * importCount ;


				// 맨 아래에 Row Add
				if (row < 0 || (row >= bfRowCount -1))
				{
					for (int i = 0 ; i < importCount ; i++)
					{
						rowNumber = bfRowCount + i;
						// RowHeaderVisible이면 RowHeader SET
						if (this.RowHeaderVisible)
						{
							// RowNumber를 보여주어야 하면 Value에도 RowNumber SET(실제 Row수 + 1)
							dispRowNumber = bfRowCount + 1 + i;
							if (this.ShowNumberAtRowHeader)
								this[bfRows,0] = CreateRowHeaderCell(dispRowNumber.ToString() , dispRowNumber, linesPerRow);
							else
								this[bfRows,0] = CreateRowHeaderCell(dispRowNumber.ToString() , "", linesPerRow);
						}
						//행추가
						dataRow = this.LayoutTable.NewRow();
						origDataRow = this.OrigLayoutTable.NewRow();
						foreach (XGridCell info in this.CellInfos)
						{
							//Import하는 Row의 테이블의 컬럼과 일치하면
							if (columnList.Contains(info.CellName))
							{
								//GridTable, OrigGridTable의 행의 값 설정
								dataRow[info.CellName] = dtRows[i][info.CellName];
								origDataRow[info.CellName] = dtRows[i][info.CellName];
								//컬럼존재여부 확인
								if (info.IsVisible && (info.CellWidth > 0))
								{
									dataValue = dtRows[i][info.CellName];
									// 추가된 Header가 있으면 info의 xPos와 rowSpan을 AGridCells의 정보와 조정하여 Get
									if (this.AddedHeaderLine > 0)
									{
										this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
									}
									else
									{
										rowPos = info.Row;
										rowSpan = info.RowSpan;
									}
									
									// Grid Add
									displayText = GetDisplayTextByInfo(info, dataValue);
									this[rowPos + bfRows , info.Col] = CreateContentCell(info, displayText, displayText, rowSpan, (rowNumber%2 == 1));
									this[rowPos + bfRows , info.Col].RowNumber = rowNumber;
									//Binary Data Set
									if (info.CellType == XCellDataType.Binary)
										this.SetImageByBinaryData(this[rowPos + bfRows , info.Col], dataValue);
								}
							}
						}
						//Row의 Height 자동조정
						if (this.applyAutoHeight)
							this.ApplyAutoHeightAtRow(bfRows, linesPerRow, dataRow, (rowNumber%2 == 0 ? false : true));

						this.LayoutTable.Rows.InsertAt(dataRow, rowNumber);
						this.OrigLayoutTable.Rows.InsertAt(origDataRow, rowNumber);
						//한행 Insert되었으므로 DisplayCount 증가
						this.DisplayedRowCount += 1;
						//Rows 증가
						bfRows += linesPerRow;
					}
				}
				else // 중간에 Row Insert
				{
					//Copy시작 Index = Header의 수((AddedHeader수 + LinePerRow)*Cols) + DataRow의 수(row*한Row의Line수*Cols)
					sourceIndex = (this.AddedHeaderLine + this.LinePerRow)*this.Cols + row*linesPerRow*this.Cols;
					//한 ImportCount 갯수만큼 아래로
					destinationIndex = sourceIndex + linesPerRow * importCount*this.Cols;
					// Copy수 = (bfRowCount - row)*한Row의Line수* Cols
					copyLength = (bfRowCount - row)*linesPerRow*this.Cols;
					Array.Copy(this.Cells, sourceIndex, this.Cells, destinationIndex, copyLength);
					// Copy된 Cell의 Row를 변경할 시작 Row = HeaderLine수 + row + importCount의 Line수
					startRowIndex = this.AddedHeaderLine + this.LinePerRow + (row + importCount)*linesPerRow;
					
					// 삽입된 Row의 Cells은 null로 Set
					for (int i = startRowIndex - importCount*linesPerRow ; i < startRowIndex ; i++)
						for (int j = 0 ; j < this.Cols ; j++)
							if (this[i,j] != null)
								Cells[i,j] = null;
					
					for (int i = 0 ; i < importCount ; i++)
					{
						// RowHeaderVisible이면 RowHeader SET
						if (this.RowHeaderVisible)
						{
							// RowNumber를 보여주어야 하면 Value에도 RowNumber SET(실제 Row수 + 1)
							dispRowNumber = row + 1 + i;
							rowHeaderIndex = this.AddedHeaderLine + this.LinePerRow + (row + i)*linesPerRow;
							if (this.ShowNumberAtRowHeader)
								this[rowHeaderIndex,0] = CreateRowHeaderCell(dispRowNumber.ToString() , dispRowNumber, linesPerRow);
							else
								this[rowHeaderIndex,0] = CreateRowHeaderCell(dispRowNumber.ToString() , "", linesPerRow);

							this[rowHeaderIndex,0].ColSpan = 1;
							this[rowHeaderIndex,0].RowSpan = linesPerRow;
						}
					}

					// Copy된 Cell의 Row를 변경
					XGridCell aGridCell = null;
					XCell cell = null;
					bool changeStyle = true;
					int  rowIndex = 0;
					for (int i = startRowIndex ; i < this.Rows ; i++)
					{
						//행 자동크기 조정 반영(한행의 line수를 고려하여 한 행 시작 Row일때만 적용함)
						if (this.applyAutoHeight && (i%linesPerRow == 0))
						{
							//자동크기를 조정할 DataRow는 아직 Import하는 행을 InsertAt하기 전이므로 기존의 RowNumber로 계산함)
							this.ApplyAutoHeightAtRow(i, linesPerRow, this.layoutTable.Rows[row + rowIndex], ((row + rowIndex)%2 == 0 ? false : true));
							rowIndex++;
						}
						for (int j = 0 ; j < this.Cols ; j++)
						{
							cell = this[i,j];
							if (cell != null)
							{
								//RowNumer 증가
								cell.RowNumber += importCount;

								cell.Row = i;
								changeStyle = true;
								//RowHeaderVisible일때 RowHeader는 Style변경하지 않음
								if (this.RowHeaderVisible && j == 0) changeStyle = false;
								//짝수건 Import시는 변경할 필요없음
								if (changeStyle && (importCount%2 == 1))
								{
									aGridCell = this.CellInfoList[cell.CellName] as XGridCell;
									// 교대로 반복되는 행이면 교대로 반복되는 행의 Style 적용
									// 단 버튼형은 적용하지 않음
									if (aGridCell != null)
									{
										//속도향상을 위해 행과 교대로반복되는 행의 속성이 다를 경우에만 SET
										if (cell.RowNumber%2 == 1)
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.AlterateRowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.AlterateRowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.AlterateRowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.AlterateRowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.AlterateRowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.AlterateRowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.AlterateRowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.AlterateRowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.AlterateRowImageStretch;
											}
										}
										else //속도향상을 위해 행과 교대로반복되는 행의 속성이 다를 경우에만 SET
										{
											if (aGridCell.RowDrawMode != aGridCell.AlterateRowDrawMode)
												cell.DrawMode = aGridCell.RowDrawMode;
											if (aGridCell.RowFont != aGridCell.AlterateRowFont)
												cell.Font = aGridCell.RowFont;
											if (aGridCell.RowBackColor != aGridCell.AlterateRowBackColor)
												cell.BackColor = aGridCell.RowBackColor;
											if (aGridCell.RowGradientStart != aGridCell.AlterateRowGradientStart)
												cell.GradientStart = aGridCell.RowGradientStart;
											if (aGridCell.RowGradientEnd != aGridCell.AlterateRowGradientEnd)
												cell.GradientEnd = aGridCell.RowGradientEnd;
											if (aGridCell.RowForeColor != aGridCell.AlterateRowForeColor)
												cell.ForeColor = aGridCell.RowForeColor;
											if (cell.Image != null)
											{
												if (aGridCell.RowImage != aGridCell.AlterateRowImage)
													cell.Image= aGridCell.RowImage;
												if (aGridCell.RowImageAlign != aGridCell.AlterateRowImageAlign)
													cell.ImageAlignment = aGridCell.RowImageAlign;
												if (aGridCell.RowImageStretch != aGridCell.AlterateRowImageStretch)
													cell.ImageStretch = aGridCell.RowImageStretch;
											}
										}
									}
								}
							}
						}
					}

					// RowHeaderVisible이면 이후행의 행번호 변경
					if (this.RowHeaderVisible)
					{
						for ( int i = startRowIndex ; i < this.Rows ; i++)
						{
							if (this[i,0] != null)
							{
								dispRowNumber = Int32.Parse(this[i,0].CellName) + importCount;
								this[i,0].CellName = dispRowNumber.ToString();
								// RowNumber를 보여주면 Value도 SET
								if (this.ShowNumberAtRowHeader)
									this[i,0].Value = dispRowNumber;
							}
						}
					}
					
					startRowIndex = this.AddedHeaderLine + this.LinePerRow + row*linesPerRow;

					for (int i = 0 ; i < importCount ; i++)
					{
						rowNumber = row + i;
						//행추가
						dataRow = this.LayoutTable.NewRow();
						origDataRow = this.OrigLayoutTable.NewRow();
						//추가된 Row에 Cell Add
						foreach (XGridCell info in this.CellInfos)
						{
							//컬럼존재여부 확인
							if (columnList.Contains(info.CellName))
							{
								//GridTable, OrigGridTable의 행의 값 설정
								dataRow[info.CellName] = dtRows[i][info.CellName];
								origDataRow[info.CellName] = dtRows[i][info.CellName];

								//컬럼이 Visible이면 Cell Set
								if (info.IsVisible && (info.CellWidth > 0))
								{
									dataValue = dtRows[i][info.CellName];
									// 추가된 Header가 있으면 info의 xPos와 rowSpan을 AGridCells의 정보와 조정하여 Get
									if (this.AddedHeaderLine > 0)
									{
										this.CellInfos.GetCellPositionByXGridCell(info, linesPerRow, out rowPos, out rowSpan);
									}
									else
									{
										rowPos = info.Row;
										rowSpan = info.RowSpan;
									}
									// Grid Add
									displayText = GetDisplayTextByInfo(info, dataValue);
									this[rowPos + startRowIndex, info.Col] = CreateContentCell(info, dataValue, displayText, rowSpan, (rowNumber%2 == 1));
									this[rowPos + startRowIndex, info.Col].RowNumber = rowNumber;
									//Binary Data Set
									if (info.CellType == XCellDataType.Binary)
										this.SetImageByBinaryData(this[rowPos + bfRows , info.Col], dataValue);
								}
							}
						}

						//Row의 Height 자동조정
						if (this.applyAutoHeight)
							this.ApplyAutoHeightAtRow(startRowIndex, linesPerRow, dataRow, (rowNumber%2 == 0 ? false : true));

						//GridTable, OrigGridTable에 행삽입
						this.LayoutTable.Rows.InsertAt(dataRow, rowNumber);
						this.OrigLayoutTable.Rows.InsertAt(origDataRow, rowNumber);
						//한행 Insert되었으므로 DisplayCount 증가
						this.DisplayedRowCount += 1;

						startRowIndex += linesPerRow;
					}
				}
			}
			catch(Exception e)
			{
				msg = XMsg.GetMsg("M039", e); // ImportRowRange, 에러[" + e.Message + "]"
				ShowErrMsg(msg);
				//Display된 행갯수 복구
				this.DisplayedRowCount = bfRowCount;
				this.Redraw = true;
				return false;
			}
			// 그리기 시작
			this.Redraw = true;

			return true;

		}
		#endregion

		#region SetRelationKey, SetRelationTable
		/// <summary>
		/// 지정한 컬럼과 Master의 컬럼을 Mapping 시킵니다.
		/// </summary>
		/// <param name="colName"> 컬럼명 </param>
		/// <param name="masterColName"> MasterLayout의 컬럼명 </param>
		public void SetRelationKey(string colName, string masterColName)
		{
			string msg = "";
			if (!this.CellInfoList.Contains(colName)) 
			{
				msg = "[SetRelationKey]" + XMsg.GetMsg("M003") + "[" + colName + "]" + XMsg.GetMsg("M004"); // "컬럼명[" + colName + "]를 잘못 지정하셨습니다."
				ShowErrMsg(msg);
				return;
			}
			if (this.MasterLayout != null && this.MasterLayout is XGrid)
			{
				if (!((XGrid)this.MasterLayout).CellInfos.Contains(masterColName))
				{
					msg = "[SetRelationKey]Master" + XMsg.GetMsg("M003") + "[" + colName + "]" + XMsg.GetMsg("M004"); // "컬럼명[" + colName + "]를 잘못 지정하셨습니다."
					ShowErrMsg(msg);
					return;
				}
				//Relation Key 관리 Hashtable에 Add
				if (!this.relationKeys.Contains(colName))
					this.relationKeys.Add(colName, masterColName);
			}
		}
		/// <summary>
		/// Grid가 Detail을 보여줄때 이 Grid과 관련됨 DB Table명을 지정합니다.
		/// Master 삭제시 이 Table
		/// </summary>
		/// <param name="tableName"></param>
		public void SetRelationTable(string tableName)
		{
			this.relationTableName = tableName;
		}
		#endregion

		#region GetRowState
		/// <summary>
		/// 지정한 행의 DataRow의 상태를 가져옵니다. (rowNumber를 잘못 지정하였으면 Detached)
		/// </summary>
		/// <param name="rowNumber"></param>
		/// <returns></returns>
		public DataRowState GetRowState(int rowNumber)
		{
			if (this.layoutTable == null)
				return DataRowState.Detached;
			else if ((rowNumber < 0) || (rowNumber >= this.RowCount))
				return DataRowState.Detached;
			else
				return this.layoutTable.Rows[rowNumber].RowState;
		}
		#endregion

		#region SetBindControl (IDataControl과 컬럼 Binding)
		public void SetBindControl(string colName, IDataControl control)
		{
			string msg = "";
			if (!this.ControlBinding)
			{
				msg = XMsg.GetMsg("M063"); // Grid ControlBinding 속성이 지정되지 않았습니다."
				this.ShowErrMsg(msg);
				return;
			}
			if (!this.CellInfoList.Contains(colName))
			{
				msg = "[SetBindControl]" + XMsg.GetMsg("M003") + "[" + colName + "]" + XMsg.GetMsg("M004"); // "컬럼명[" + colName + "]를 잘못 지정하셨습니다."
				this.ShowErrMsg(msg);
				return;
			}
			if (control == null)
			{
				msg = XMsg.GetMsg("M064"); // Control이 잘못 지정되었습니다."
				this.ShowErrMsg(msg);
				return;
			}
			XGridCell info = this.CellInfoList[colName] as XGridCell;
			//Control의 Type과 DataType의 일치여부 확인
			if (!IsMatchedDataType(info.CellType, control.ContType))
			{
				msg = "Column Type[" + info.CellType.ToString() + "] Control Type[" + control.ContType.ToString() +"] Mismatch.";
				this.ShowErrMsg(msg);
				return;
			}
			//기존에 BindControl이 있었으면 기존 BindControl의 DataValidating Event Handler 제거
			if (info.BindControl != null)
				info.BindControl.DataValidating -= new DataValidatingEventHandler(Grid_BindControlDataValidating);

			//새로운 BindControl 연결, Event Handling
			info.BindControl = control;
			info.BindControl.DataValidating += new DataValidatingEventHandler(Grid_BindControlDataValidating);
		}
		private bool IsMatchedDataType(XCellDataType cellType, ControlDataType contType)
		{
			if (contType == ControlDataType.AllType) return true;
			switch (contType)
			{
				case ControlDataType.String:
					if (cellType != XCellDataType.String)
						return false;
					break;
				case ControlDataType.Date:
					if (cellType != XCellDataType.Date) return false;
					break;
				case ControlDataType.DateTime:
					if (cellType != XCellDataType.DateTime) return false;
					break;
				case ControlDataType.Number:
					if ((cellType != XCellDataType.Number) && (cellType != XCellDataType.Decimal)) return false;
					break;
				case ControlDataType.Time:
					if (cellType != XCellDataType.Time) return false;
					break;
				case ControlDataType.Binary:
					if (cellType != XCellDataType.Binary) return false;
					break;
				default:
					break;
			}
			return true;
		}
		#endregion

		#region SetBindVarValue(QuerySQL의 BindVar에 값 설정)
		public void SetBindVarValue(string varName, string varValue)
		{
			//VarName이 정확하면 VarValue SET
			BindVar bVar = this.BindVarList[varName];
			if (bVar != null)
				bVar.VarValue = varValue;
		}
		//값과 ValueLen 설정
		public void SetBindVarValue(string varName, string varValue, int valueLen)
		{
			//VarName이 정확하면 VarValue SET
			BindVar bVar = this.BindVarList[varName];
			if (bVar != null)
			{
				bVar.VarValue = varValue;
				bVar.ValueLen = valueLen;
			}
		}
		#endregion

		#region MoveRow, MoveUpRow, MoveDownRow (행 변경)
		public virtual bool MoveRow(int fromRowNumber, int toRowNumber)
		{
			DataTable tempTable = null;
			try
			{
				if (this.layoutTable == null) return false;

				if ((fromRowNumber < 0) || (fromRowNumber >= this.RowCount) || (fromRowNumber >= this.DisplayedRowCount)
					|| (toRowNumber < 0) || (toRowNumber >= this.RowCount) || (toRowNumber >= this.DisplayedRowCount))
				{
					this.ShowErrMsg("MoveRow, 행번호를 잘못 입력하셨습니다. 시작행[" + fromRowNumber + "],종료행[" + toRowNumber + "]");
					return false;
				}

				//Grouping된 Grid는 MoveRow 불가
				if (this.GroupInfos.Count > 0)
				{
					ShowErrMsg("MoveRow, 그룹핑된 Grid는 MoveRow 불가합니다.");
					return false;
				}

				/* fromRow와 toRow의 위치를 바꾼다.
				 * LayoutTable, OrigLayoutTable의 행의 위치를 바꾼다.
				 * Cell의 위치를 바꾼다.
				 */
				tempTable = this.layoutTable.Copy(); //기존 DataTable 저장
				DataRow dtRowFrom = tempTable.Rows[fromRowNumber];
				DataRow dtRowTo = tempTable.Rows[toRowNumber];
				//기존 Table Clear
				this.layoutTable.Rows.Clear();
				this.OrigLayoutTable.Rows.Clear();
				int rowNum = 0;
				foreach (DataRow dataRow in tempTable.Rows)
				{

					if (rowNum == fromRowNumber) //시작행 -> 끝행으로 Imort
					{
						this.layoutTable.ImportRow(dtRowTo);
						this.OrigLayoutTable.ImportRow(dtRowTo);
					}
					else if (rowNum == toRowNumber) //끝행 -> 시작행으로 Imort
					{
						this.layoutTable.ImportRow(dtRowFrom);
						this.OrigLayoutTable.ImportRow(dtRowFrom);
					}
					else //다른 행은 데이타 그대로 Import
					{
						this.layoutTable.ImportRow(dataRow);
						this.OrigLayoutTable.ImportRow(dataRow);
						//<미확정> ImportRow시에 DataRow의 상태는 어떻게 되나, 그대로 유지해야 한다.(그대로 유지함)
					}
					rowNum++;
				}

				//fromRowNumber에 있는 Cell을 모은다.
				int fromPhysicalRow = GetPhysicalRowFromRowNumber(fromRowNumber);
				int toPhysicalRow = GetPhysicalRowFromRowNumber(toRowNumber);
				bool isAlterateFromRowNumber = (fromRowNumber % 2 == 0 ? false : true); //교대로 반복되는 행인지 여부
				bool isAlterateToRowNumber = (toRowNumber % 2 == 0 ? false : true); //교대로 반복되는 행인지 여부
				if ((fromPhysicalRow < 0) || (toPhysicalRow < 0))
				{
					Debug.WriteLine("MoveRow :: fromPhysicalRow[" + fromPhysicalRow + "],toPhysicalRow[" + toPhysicalRow + "]이상함");
					return false;
				}

				int linesPerRow = this.GetLinesPerRow(); //한행의 Line 수
				//fromPhysicalRow 에서 한행의 Line수 + fromPhysicalRow 까지의 Cell을 ArrayList에 저장, to도 마찬가지
				//둘의 RowNumber를 바꾼다. this[i,j] = cell로 할당
				ArrayList fromCellList = new ArrayList();
				ArrayList toCellList = new ArrayList();
				int startCol = (this.RowHeaderVisible ? 1 : 0);  //시작열은 행번호가 있으면 1, 아니면 0
				int rowCount = 0;
				XCell firstFromCell = null;
				for (int i = fromPhysicalRow; i < fromPhysicalRow + linesPerRow; i++)
				{
					for (int j = startCol; j < this.Cols; j++)
					{
						XCell cell = this[i, j];
						if (cell != null)
						{
							if ((i == fromPhysicalRow) && (j == startCol))
								firstFromCell = cell;

							// this[i,j] = null Clear
							this[i, j] = null;
							cell.RowNumber = toRowNumber;  //RowNumber는 종료행으로
							MoveInfo mInfo = new MoveInfo();
							mInfo.Row = toPhysicalRow + rowCount; //Row의 값을 이동할 Row로 변경
							mInfo.Col = j;
							//fromRowNumber와 toRowNumber의 교대로 반복되는 행여부가 다르면 toRowNumber의 교대로 반복되는 행의 BackColor 적용
							if (isAlterateFromRowNumber != isAlterateToRowNumber)
							{
								XGridCell info = (XGridCell) this.CellInfoList[cell.CellName];
								if (isAlterateToRowNumber)
									cell.BackColor = info.AlterateRowBackColor;
								else
									cell.BackColor = info.RowBackColor;
							}
							mInfo.Cell = cell;
							fromCellList.Add(mInfo);
						}
					}
					rowCount++;
				}
				rowCount = 0;
				for (int i = toPhysicalRow; i < toPhysicalRow + linesPerRow; i++)
				{
					for (int j = startCol; j < this.Cols; j++)
					{
						XCell cell = this[i, j];
						if (cell != null)
						{
							// this[i,j] = null Clear
							this[i, j] = null;
							cell.RowNumber = fromRowNumber;  //RowNumber는 시작행으로
							MoveInfo mInfo = new MoveInfo();
							mInfo.Row = fromPhysicalRow + rowCount; //Row의 값을 이동할 Row로 변경
							mInfo.Col = j;
							//fromRowNumber와 toRowNumber의 교대로 반복되는 행여부가 다르면 fromRowNumber의 교대로 반복되는 행의 BackColor 적용
							if (isAlterateFromRowNumber != isAlterateToRowNumber)
							{
								XGridCell info = (XGridCell) this.CellInfoList[cell.CellName];
								if (isAlterateFromRowNumber)
									cell.BackColor = info.AlterateRowBackColor;
								else
									cell.BackColor = info.RowBackColor;
							}
							mInfo.Cell = cell;
							toCellList.Add(mInfo);
						}
					}
					rowCount++;
				}

				//fromCellList, toCellList에서 데이타를 조회 this[i,j]에 SET
				foreach (MoveInfo info in fromCellList)
				{
					this[info.Row, info.Col] = info.Cell;
				}
				foreach (MoveInfo info in toCellList)
				{
					this[info.Row, info.Col] = info.Cell;
				}

				//SetFocus (toRowNumber)
				//<미확정> Grid에 Focus가 없어서 인지 Focus가 정확히 가지 않음
				this.SetFocusToItem(toRowNumber, firstFromCell.CellName);
				if (this.SelectionMode == XGridSelectionMode.Row)  //Row선택하게(임시)
					this.SelectRow(toRowNumber);
                

				return true;
			}
			catch (Exception ex)
			{
				this.ShowErrMsg("MoveRow 에러[" + ex.Message + "]");
				return false;
			}
			finally
			{
				if (tempTable != null)
					tempTable.Dispose();
			}
		}
		//이동 정보 관리 Class
		private class MoveInfo
		{
			public int Row;
			public int Col;
			public XCell Cell;
		}
		public virtual bool MoveUpRow(int rowNumber)
		{
			if (rowNumber <= 0) return true;

			return MoveRow(rowNumber, rowNumber - 1);
		}
		public virtual bool MoveDownRow(int rowNumber)
		{
			if (rowNumber >= this.DisplayedRowCount - 1) return true;
			return MoveRow(rowNumber, rowNumber + 1);
		}
		//논리적 행 번호로 물리적 행을 가져온다.
		private int GetPhysicalRowFromRowNumber(int rowNumber)
		{
			int linesPerRow = this.GetLinesPerRow();
			try
			{
				return (rowNumber * linesPerRow) + this.LinePerRow + this.AddedHeaderLine + this.GroupRowInfos.GetBelowGroupLineCount(true, rowNumber, linesPerRow);
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region CloneToLayout, CopyToLayout (Grid와 동일한 구조를 가지는 MultiLayout를 Return)
		/// <summary>
		/// Grid의 컬럼정보와 동일한 구조를 가지는 MultiLayout를 Return
		/// </summary>
		/// <returns></returns>
		public virtual MultiLayout CloneToLayout()
		{
			//2005.11.11 .Clone - 데이타구조, LayoutTable
			//Master관계 및 삭제된 Table은 복사하지 않음
			MultiLayout layout = new MultiLayout();
			//InputLayoutID는 XEditGrid에서 Override하여 설정함
			//XGrid는 isNotNull, isUpdItem을 관리하지 않으므로 XEditGrid에서 override하여 다시 정의함(여기서는 default false, false)
			foreach (XGridCell info in this.CellInfos)
			{
				MultiLayoutItem item = new MultiLayoutItem();
				item.DataName = info.CellName;
				item.DataType = XGridUtility.ConvertToDataType(info.CellType);
				item.IsNotNull = false;
				item.IsUpdItem = false;
				layout.LayoutItems.Add(item);
			}
			//LayoutTable 생성 (초기화)
			layout.InitializeLayoutTable();

			return layout;

		}
		/// <summary>
		/// Grid의 컬럼정보와 동일한 구조,데이타를 가지는 MultiLayout를 Return
		/// </summary>
		/// <returns></returns>
		public virtual MultiLayout CopyToLayout()
		{
			MultiLayout layout = this.CloneToLayout();

			int index = 0;
			DataRow dataRow = null;
			//Data Import
			foreach (DataRow dtRow in this.layoutTable.Rows)
			{
				//Data Add
				layout.LayoutTable.Rows.Add(dtRow.ItemArray);
				dataRow = layout.LayoutTable.Rows[index];
				//DataRow의 상태 설정
				if (dtRow.RowState == DataRowState.Unchanged)
					dataRow.AcceptChanges();
				else if (dtRow.RowState == DataRowState.Modified)
				{
					dataRow.AcceptChanges();  //Unchanged
					dataRow[0] = dataRow[0];  //값을 하나 설정하여 Modified로 변경함
				}
				index++;
			}
			return layout;
		}

		#endregion

	}

	#region XGridCellPaintEventHandler
	public delegate void XGridCellPaintEventHandler(object sender, XGridCellPaintEventArgs e);

	public class XGridCellPaintEventArgs : EventArgs 
	{ 
		private string colName = "";   //컬럼명
		private int rowNumber = -1;
		private DataRow dataRow = null;
		private Font	font;
		private Color	backColor = Color.White;
		private Color	foreColor = Color.Black;
		private XCellDrawMode drawMode = XCellDrawMode.Flat;
		private Color	gradientStartColor = Color.White;
		private Color	gradientEndColor   = Color.WhiteSmoke;
		private Image	image = null;
		private bool    drawMiddleLine = false;  //중간에 Line을 그릴지 여부
		private Color   middleLineColor = Color.Black;  //중간 Line의 색깔
		
		public string ColName
		{
			get { return colName;}
		}
		public int RowNumber
		{
			get { return rowNumber;}
		}
		public DataRow DataRow
		{
			get { return dataRow;}
		}
		public Font Font
		{
			get { return font;}
			set { font = value;}
		}
		public Color BackColor
		{
			get { return backColor;}
			set { backColor = value;}
		}
		public Color ForeColor
		{
			get { return foreColor;}
			set { foreColor = value;}
		}
		public Color GradientStartColor
		{
			get { return gradientStartColor;}
			set { gradientStartColor = value;}
		}
		public Color GradientEndColor
		{
			get { return gradientEndColor;}
			set { gradientEndColor = value;}
		}
		public XCellDrawMode DrawMode
		{
			get { return drawMode;}
			set { drawMode = value;}
		}
		public Image Image
		{
			get { return image;}
			set { image = value;}
		}
		public bool DrawMiddleLine
		{
			get { return drawMiddleLine;}
			set { drawMiddleLine = value;}
		}
		public Color MiddleLineColor
		{
			get { return middleLineColor;}
			set { middleLineColor = value;}
		}
		public XGridCellPaintEventArgs(string colName, int rowNumber, DataRow dataRow, Font font, Color backColor, Color foreColor, Color gradientStart, Color gradientEnd, XCellDrawMode drawMode, Image image)
		{ 
			this.colName = colName;
			this.rowNumber = rowNumber ;
			this.dataRow = dataRow;
			this.font = font;
			this.backColor = backColor;
			this.foreColor = foreColor;
			this.gradientStartColor = gradientStart;
			this.gradientEndColor = gradientEnd;
			this.drawMode = drawMode;
			this.image = image;
		} 
	} 
	#endregion

	#region XGridCellFocusChangedEventHandler
	public delegate void XGridCellFocusChangedEventHandler(object sender, XGridCellFocusChangedEventArgs e);

	public class XGridCellFocusChangedEventArgs : EventArgs 
	{ 
		private string colName = "";   //컬럼명
		private int rowNumber = -1;
		
		public string ColName
		{
			get { return colName;}
		}
		public int RowNumber
		{
			get { return rowNumber;}
		}
		public XGridCellFocusChangedEventArgs(string colName, int rowNumber)
		{ 
			this.colName = colName;
			this.rowNumber = rowNumber ;
		} 
	} 
	#endregion

	#region XGridContDisplayedEventHandler
	public delegate void XGridContDisplayedEventHandler(object sender, XGridContDisplayedEventArgs e);

	public class XGridContDisplayedEventArgs : EventArgs 
	{ 
		//다음 Display전에 Display된 행의 갯수
		private int beforeDisplayCount = 0;
		//다음 Display후에 Display된 행의 갯수
		private int afterDisplayCount = 0;
		
		public int BeforeDisplayCount
		{
			get { return beforeDisplayCount;}
		}
		public int AfterDisplayCount
		{
			get { return afterDisplayCount;}
		}
		public XGridContDisplayedEventArgs(int beforeDisplayCount, int afterDisplayCount)
		{ 
			this.beforeDisplayCount = beforeDisplayCount;
			this.afterDisplayCount = afterDisplayCount ;
		} 
	} 
	#endregion

	#region RowFocusChangedEventHandler
	[Serializable]
	public delegate void RowFocusChangingEventHandler(object sender, RowFocusChangingEventArgs e);

	public class RowFocusChangingEventArgs : EventArgs
	{
		private int currentRow;
		private int nextRow;
		public int CurrentRow
		{
			get { return currentRow;}
		}
		public int NextRow
		{
			get { return nextRow;}
		}
		public RowFocusChangingEventArgs(int nextRow, int currRow)
		{
			this.nextRow = nextRow;
			this.currentRow = currRow;
		}
	}
	#endregion

}
