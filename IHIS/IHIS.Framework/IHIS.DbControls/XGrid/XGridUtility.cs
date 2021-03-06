using System;
using System.Text;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace IHIS.Framework
{
	#region Enum
	/// <summary>
	/// Cell의 성격을 나타내는 Enum입니다.
	/// </summary>
	public enum XCellPersonality
	{
		/// <summary>
		/// ColumnHeader Cell
		/// </summary>
		ColHeader,
		/// <summary>
		/// Content Cell(Actual Cell)
		/// </summary>
		Content,
		/// <summary>
		/// Compute Cell
		/// </summary>
		Compute,
		/// <summary>
		/// Row의 Header Cell
		/// </summary>
		RowHeader,
		/// <summary>
		/// Group을 표시하는 Band Cell
		/// </summary>
		GroupBand,
		/// <summary>
		/// Grid의 Footer에 표시되는 Cell
		/// </summary>
		Footer

	}
	/// <summary>
	/// Grid의 현상태를 나타내는 Enum입니다.
	/// </summary>
	public enum XGridStatus
	{
		/// <summary>
		/// Column Resize 중
		/// </summary>
		ColResizing = 0,
		/// <summary>
		/// Row Resize 중
		/// </summary>
		RowResizing	,
		/// <summary>
		/// 정상 상태
		/// </summary>
		Normal
	}
	/// <summary>
	/// Grid Selection시 선택단위를 나타내는 Enum입니다.
	/// </summary>
	public enum XGridSelectionMode
	{
		/// <summary>
		/// Cell 단위로 선택
		/// </summary>
		Cell = 1,
		/// <summary>
		/// Row 단위로 선택
		/// </summary>
		Row = 2,
		/// <summary>
		/// Column 단위로 선택
		/// </summary>
		Col = 3
	}
	/// <summary>
	/// Cell의 DataType을 나타내는 Enum입니다.
	/// </summary>
	public enum XCellDataType
	{
		/// <summary>
		/// String형 Data
		/// </summary>
		String	= 0	,
		/// <summary>
		/// Number형 Data
		/// </summary>
		Number		,
		/// <summary>
		/// Decimal형 Data
		/// </summary>
		Decimal		,
		/// <summary>
		/// Date형(YYYYMMDD)형 Data
		/// </summary>
		Date		,
		/// <summary>
		/// DateTime형(YYYYMMDDHHMISS)형 Data
		/// </summary>
		DateTime	,
		/// <summary>
		/// Month형(YYYYMM)형의 데이타
		/// </summary>
		Month,
		/// <summary>
		/// Time형(HHMISS) Data
		/// </summary>
		Time		,
		/// <summary>
		/// Binary형 Data
		/// </summary>
		Binary
	}
	/// <summary>
	/// Cell 편집기 스타일을 나타내는 Enum입니다.
	/// </summary>
	public enum XCellEditorStyle
	{
		/// <summary>
		/// EditBox형 편집기
		/// </summary>
		EditBox = 0,
		/// <summary>
		/// ComboBox형 편집기
		/// </summary>
		ComboBox,
		/// <summary>
		/// FindBox형 편집기
		/// </summary>
		FindBox,
		/// <summary>
		/// CheckBox형 편집기
		/// </summary>
		CheckBox,
		/// <summary>
		/// MemoBox형 편집기
		/// </summary>
		MemoBox,
		/// <summary>
		/// Button형 편집기
		/// </summary>
		ButtonBox,
		/// <summary>
		/// DatePicker형 편집기
		/// </summary>
		DatePicker,
		/// <summary>
		/// ListBox형 편집기
		/// </summary>
		ListBox,
		/// <summary>
		/// NumericUpDownBox형 편집기(Number, Decimal만 가능)
		/// </summary>
		UpDownBox
	}
	/// <summary>
	/// Grid의 EditMode 전환방법을 나타내는 Enum입니다.
	/// </summary>
	public enum XGridEditType
	{
		/// <summary>
		/// Click시 EditMode로 전환합니다.
		/// </summary>
		SingleClick = 0,
		/// <summary>
		/// Double Click시 EditMode로 전환합니다.
		/// </summary>
		DoubleClick
	}
	/// <summary>
	/// Grid의 Sort전환 방법을 나타내는 Enum입니다.
	/// </summary>
	public enum XGridSortMode
	{
		/// <summary>
		/// 컬럼 Header Click시에 Sort를 시작합니다.
		/// </summary>
		SingleClick = 0,
		/// <summary>
		/// 컬럼 Header DoubleClick시에 Sort를 시작합니다.
		/// </summary>
		DoubleClick
	}
	/// <summary>
	/// Cell의 그리기 모드를 나타내는 Enum입니다.
	/// </summary>
	public enum XCellDrawMode
	{
		/// <summary>
		/// Flat형으로 그리기
		/// </summary>
		Flat,
		/// <summary>
		/// 오른쪽 위에서 왼쪽 아래로 향하는 Gradient로 그리기
		/// </summary>
		BackwardDiagonal,
		/// <summary>
		/// 왼쪽 위에서 오른쪽 아래로 향하는 Gradient로 그리기
		/// </summary>
		ForwardDiagonal,
		/// <summary>
		/// 왼쪽에서 오른쪽으로 향하는 Gradient로 그리기
		/// </summary>
		Horizontal,
		/// <summary>
		/// 위쪽에서 아래쪽으로 향하는 Gradient로 그리기
		/// </summary>
		Vertical,
		/// <summary>
		/// 3D모양의 볼록한 그리기
		/// </summary>
		Raised3D,
		/// <summary>
		/// 3D모양의 오목한 그리기
		/// </summary>
		Sunken3D
	}
	/// <summary>
	/// Compute의 종류를 나타내는 Enum입니다.
	/// </summary>
	public enum XGridComputedKind
	{
		/// <summary>
		/// Data의 갯수
		/// </summary>
		Count,
		/// <summary>
		/// Distinct한 Data의 갯수
		/// </summary>
		DistinctCount,
		/// <summary>
		/// Data의 합
		/// </summary>
		Sum,
		/// <summary>
		/// Data의 평균
		/// </summary>
		Average,
		/// <summary>
		/// Data중 Max값
		/// </summary>
		Max,
		/// <summary>
		/// Data중 Min값
		/// </summary>
		Min,
		/// <summary>
		/// 보여줄 Text
		/// </summary>
		Text
	}
	public enum XGridToolTipType
	{
		/// <summary>
		/// 현재 Cell에 있는 데이타를 보여줌
		/// </summary>
		Data,
		/// <summary>
		/// 컬럼정보에서 설정한 ToolTipText를 보여줌
		/// </summary>
		ColumnDesc
	}
	#endregion

	#region XGridUtility
	/// <summary>
	/// GridUtility에 대한 요약설명입니다.
	/// </summary>
	internal class XGridUtility
	{
		#region static Fields
		private static string[] expressionFunctions = {"Sum(n)","Average(n)","Max(n)","Min(n)","Count(n)","DistinctCount(n)"};
		/// <summary>
		/// Computed Cell에 사용할 Expression의 Function List입니다.
		/// </summary>
		internal static string[] ExpressionFunctions
		{
			get { return expressionFunctions;}
		}
		private static string keyInitValue = "$$$";
		private static string footerKeyValue = "@@All@@";
		private static string footerGroupName = "All";
		private static string footerName = "Footer";
		/// <summary>
		/// XGridGroupDataList의 KeyValue의 초기값입니다.
		/// </summary>
		internal static string KeyInitValue
		{
			get { return keyInitValue;}
		}
		/// <summary>
		/// Footer Group(All)의 KeyValue의 값입니다.
		/// </summary>
		internal static string FooterKeyValue
		{
			get { return footerKeyValue;}
		}
		/// <summary>
		/// Footer Group명(All)을 나타내는 값입니다.
		/// </summary>
		internal static string FooterGroupName
		{
			get { return footerGroupName;}
		}
		/// <summary>
		/// Footer의 이름(Footer)을 나타내는 값입니다.
		/// </summary>
		internal static string FooterName
		{
			get { return footerName;}
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// XGridComputedKind, Expression으로 Function에 포함된 KeyName Return
		/// </summary>
		/// <param name="kind"> XGridComputedKind Enum </param>
		/// <param name="expression"> Expression Text </param>
		/// <returns></returns>
		internal static string GetKeyNameByExpression(XGridComputedKind kind, string expression)
		{
			string keyName = "";
			if (kind == XGridComputedKind.Text)  //Text는 KeyName이 Expression 전체
				keyName = expression;
			else
			{
				//Function에서 컬럼명 찾기
				int pos1 = -1, pos2 = -1;
				pos1 = expression.IndexOf('(');
				pos2 = expression.IndexOf(')');
				if ((pos1 > 0) && (pos2 > 0) && (pos1 < pos2))
				{
					keyName = expression.Substring(pos1 + 1, pos2 - pos1 -1).Trim();
				}
			}
			return keyName;
		}
		/// <summary>
		/// Expression으로 Computed의 종류를 가져옵니다.
		/// </summary>
		/// <param name="expression"> Expression string </param>
		/// <returns> XGridComputedKind Enum </returns>
		internal static XGridComputedKind GetXGridComputedKindByExpression(string expression)
		{
			XGridComputedKind kind = XGridComputedKind.Text;
			int pos1 = -1, pos2 = -1;
			string funcName = "";
			pos1 = expression.IndexOf('"');
			if (pos1 >= 0)
				kind = XGridComputedKind.Text;
			else
			{
				pos1 = expression.IndexOf('(');
				pos2 = expression.IndexOf(')');
				if ((pos1 > 0) && (pos2 > 0) && (pos1 < pos2))
				{
					funcName = expression.Substring(0, pos1).Trim();
					kind = (XGridComputedKind) Enum.Parse(typeof(XGridComputedKind), funcName);
				}
			}
			return kind;
		}
		/// <summary>
		/// Expression의 유효성여부를 Check합니다.
		/// </summary>
		/// <param name="cellInfos"> 컬럼정보를 관리하는 컬렉션 </param>
		/// <param name="expression"> Expression Text </param>
		/// <param name="errMsg"> (out) 유효하지 않을때의 Error Message </param>
		/// <returns> 유효하면 true, 아니면 false </returns>
		internal static bool VerifyExpression(XGridCellCollection cellInfos, string expression, out string errMsg)
		{
			errMsg = "";

			//Computed 컬럼에 사용한 Expression이 정확한지 여부 확인
			//1.FunctionList와 동일한 Format이어야함
			//2.지정한 컬럼명이 cellInfos에 있는지 확인
			//3.Text는 ""로 묶여있는지 여부 확인
			if (expression.Trim() == "")
			{
				errMsg = "Expression이 지정되지 않았습니다.";
				return false;
			}
			int pos1 = -1, pos2 = -1;
			string text = expression.Trim();
			string colName = "";
			string funcName = "";
			bool   isMatch = false;
			XCellDataType cellType = XCellDataType.String;
			pos1 = text.IndexOf('"');
			//Text Expression
			if (pos1 >= 0)
			{
				pos2 = text.IndexOf('"', pos1 + 1);
				if (pos2 < 0)
				{
					errMsg = "Text는 \"\"로 묶어야 합니다.";
					return false;
				}
				//컬럼명 + "AAA" 형식, OR "AAA" + 컬럼명 형식은 불가
				if (text.Substring(pos1, pos2 - pos1 + 1) != text)
				{
					errMsg = "Expression이 잘못 지정되었습니다.(\"AAA\"형식이 아님)";
					return false;
				}
			}
				// Function Expression
			else
			{
				pos1 = text.IndexOf('(');
				pos2 = text.IndexOf(')');
				if ((pos1 < 0) || (pos2 < 0))
				{
					errMsg = "Expression이 잘못 지정되었습니다.";
					return false;
				}
				if (pos2 <= pos1)
				{
					errMsg = "Expression이 잘못 지정되었습니다.";
					return false;
				}
				colName = text.Substring(pos1 + 1, pos2 - pos1 -1);
				funcName = text.Replace(colName,"n");  // sum (deptCode) -> sum(n)으로 변경
				colName = colName.Trim(); //Space 제거
				//Function이 일치하는지 여부 Check
				for (int i = 0 ; i < XGridUtility.ExpressionFunctions.Length ; i++)
				{
					if (funcName == XGridUtility.ExpressionFunctions[i])
					{
						isMatch = true;
						break;
					}
				}
				if (!isMatch)
				{
					errMsg = "Expression에 사용가능한 Function이 아닙니다.";
					return false;
				}
				isMatch = false;
				//컬럼명 Match 여부 확인
				foreach (XGridCell info in cellInfos)
				{
					if (colName == info.CellName)
					{
						isMatch = true;
						cellType = info.CellType;
						//Computed컬럼에는 ReadOnly컬럼만 설정가능
						if (!info.IsReadOnly)
						{
							errMsg = "ReadOnly컬럼만 Computed컬럼에 사용할 수 있습니다.";
							return false;
						}
						break;
					}
				}
				if (!isMatch)
				{
					errMsg = "Expression에 사용한 컬럼이 잘못 지정되었습니다.";
					return false;
				}
				//Binary Type은 count,distinctCount 가능
				//Sum,average Function은 number Type만 가능
				if (cellType == XCellDataType.Binary)
				{
					if (funcName != "Count(n)")
					{
						errMsg = "Binary Type의 컬럼은 Count Expression만 가능합니다.";
						return false;
					}
				}
				if ((funcName == "Sum(n)") || (funcName == "Average(n)"))
				{
					if ((cellType != XCellDataType.Number) && (cellType != XCellDataType.Decimal))
					{
						errMsg = "Sum, Average는 Number Type 컬럼만 가능합니다.";
						return false;
					}
				}
				
			}
			return true;
		}
		/// <summary>
		/// 지정한 Bound에 맞추어 사각형을 그립니다.
		/// </summary>
		/// <param name="g"> Graphics </param>
		/// <param name="p"> Pen </param>
		/// <param name="r"> Rectangle </param>
		internal static void DrawRectangleWithExternBound(Graphics g, Pen p, Rectangle r)
		{
			//da rivedere e ottimizzare 
			if (p.Width > 0.0)
			{
				r.Y += (int)p.Width-1;
				r.X += (int)p.Width-1;
				r.Width -= (int)(p.Width*2-1);
				r.Height -= (int)(p.Width*2-1);
				g.DrawRectangle(p,r);
			}
		}
		/// <summary>
		/// High order Word를 반환합니다.
		/// </summary>
		/// <param name="Number"> 32bit int </param>
		/// <returns> High order Word </returns>
		internal static int HiWord(int Number) 
		{ 
			return (Number >> 16) & 0xffff; 
		} 
		/// <summary>
		/// low order Word를 반환합니다.
		/// </summary>
		/// <param name="Number"> 32bit int </param>
		/// <returns> low order Word </returns>
		internal static int LoWord(int Number) 
		{ 
			return Number & 0xffff; 
		}
		/// <summary>
		/// Alignment가 Left인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Left이면 true, 아니면 false </returns>
		internal static bool IsLeft(ContentAlignment a)
		{
			return (a == ContentAlignment.BottomLeft ||
				a == ContentAlignment.MiddleLeft ||
				a == ContentAlignment.TopLeft);
		}
		/// <summary>
		/// Alignment가 Right인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Right이면 true, 아니면 false </returns>
		internal static bool IsRight(ContentAlignment a)
		{
			return (a == ContentAlignment.BottomRight ||
				a == ContentAlignment.MiddleRight ||
				a == ContentAlignment.TopRight);
		}
		/// <summary>
		/// Alignment가 Center인지 여부를 반환합니다.
		/// </summary>
		/// <param name="a"> ContentAlignment </param>
		/// <returns> Center이면 true, 아니면 false </returns>
		internal static bool IsCenter(ContentAlignment a)
		{
			return (a == ContentAlignment.BottomCenter ||
				a == ContentAlignment.MiddleCenter ||
				a == ContentAlignment.TopCenter);
		}
		internal static DataType ConvertToDataType(XCellDataType cellType)
		{
			DataType	dataType;
			switch(cellType)
			{
				case XCellDataType.Date:
					dataType = DataType.Date;
					break;
				case XCellDataType.DateTime:
					dataType = DataType.DateTime;
					break;
				case XCellDataType.Time:
					dataType = DataType.String;
					break;
				case XCellDataType.Number:
				case XCellDataType.Decimal:
					dataType = DataType.Number;
					break;
				case XCellDataType.String:
					dataType = DataType.String;
					break;
				case XCellDataType.Month:
					dataType = DataType.String;
					break;
				default:
					dataType = DataType.String;
					break;
			}
			return dataType;
		}
		#endregion
	}
	#endregion

	#region XCellEventHandler
	/// <summary>
	/// Cell의 Selection 발생 Event를 처리하는 메서드를 나타냅니다.
	/// </summary>
	internal delegate void XCellEventHandler(object sender, XCell cell);
	#endregion

	#region XGridSelection
	/// <summary>
	/// XGridSelection class에 대한 요약 설명입니다.
	/// </summary>
	public class XGridSelection : ICollection
	{
		#region Fields
		private XGrid grid;
		private ArrayList selectedList = new ArrayList();
		private XCell rightBottomCell = null;
		#endregion

		#region Properties
		/// <summary>
		/// Selection 객체를 포함하는 Grid를 가져옵니다.
		/// </summary>
		internal XGrid Grid
		{
			get{return grid;}
		}
		/// <summary>
		/// Selected된 Cell의 갯수를 가져옵니다.
		/// </summary>
		public int Count
		{
			get{return selectedList.Count;}
		}
		/// <summary>
		/// ICollection에 대한 액세스가 동기화되거나 스레드로부터 보호되는지 여부를 나타내는 값을 가져옵니다.
		/// </summary>
		bool ICollection.IsSynchronized
		{
			get{return selectedList.IsSynchronized;}
		}
		/// <summary>
		/// ICollection에 대한 액세스를 동기화하는 데 사용할 수 있는 개체를 가져옵니다.
		/// </summary>
		object ICollection.SyncRoot
		{
			get{return selectedList.SyncRoot;}
		}
		/// <summary>
		/// 지정한 Index에 있는 Cell 객체를 가져옵니다.
		/// </summary>
		public XCell this[int index]
		{
			get
			{
				try
				{
					return (XCell)selectedList[index];
				}
				catch
				{
					return null;
				}
			}
		}
		/// <summary>
		/// 선택영역의 우측하단 Cell 객체를 가져옵니다.
		/// </summary>
		public XCell RightBottomCell
		{
			get{return rightBottomCell;}
		}
		/// <summary>
		/// 선택영역의 좌측상단 Cell 객체를 가져옵니다.
		/// </summary>
		public XCell TopLeftCell
		{
			get
			{
				try
				{
					return this.grid.FocusCell;
				}
				catch
				{
					return null;
				}
			}
		}
		#endregion

		#region 생성자
		/// <summary>
		/// Selection 생성자 
		/// </summary>
		/// <param name="grid">  XGrid </param>
		internal XGridSelection(XGrid grid)
		{
			this.grid = grid;
			this.grid.CellSelectionChange += new XCellEventHandler(Grid_CellSelectionChange);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Selection된 모든 Cell의 선택을 해제합니다.
		/// </summary>
		internal void Clear()
		{
			int l_Count = this.Count;
			for (int i = 0; i < l_Count; i++)
				this[0].Select = false;
		}
		/// <summary>
		/// 특정 Cell만 제외하고 나머지 Cell의 선택을 해제합니다.
		/// </summary>
		/// <param name="cellLeaveThisCellSelected"> Cell 객체 </param>
		internal void Clear(XCell cellLeaveThisCellSelected)
		{
			int l_Count = Count;
			int indexToDel = 0;
			for (int i = 0; i < l_Count; i++)
			{
				if (this[indexToDel] != cellLeaveThisCellSelected)
					this[indexToDel].Select = false;
				else
					indexToDel++; 
			}
		}
		/// <summary>
		/// Source 배열의 지정한 Index에서 시작하여 대상 Array에 복사합니다.
		/// </summary>
		/// <param name="array"> 대상 Array </param>
		/// <param name="index"> 시작 Index </param>
		void ICollection.CopyTo ( System.Array array , int index )
		{
			selectedList.CopyTo(array,index);
		}
		/// <summary>
		/// ArrrayList의 섹션에 대한 열거자를 반환합니다.
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return selectedList.GetEnumerator();
		}
		/// <summary>
		/// 선택영역에서 해당 Cell을 포함하는지 여부를 반환합니다.
		/// </summary>
		/// <param name="cell"> Cell 객체 </param>
		/// <returns> 포함하면 true, 아니면 false </returns>
		public bool Contains(XCell cell)
		{
			return selectedList.Contains(cell);
		}
		/// <summary>
		/// 특정 Cell의 선택영역의 Index를 반환합니다.
		/// </summary>
		/// <param name="cell"> Cell 객체 </param>
		/// <returns> Index </returns>
		public int IndexOf(XCell cell)
		{
			return selectedList.IndexOf(cell);
		}
		/// <summary>
		/// 선택영역의 시작,종료 Row, Col을 반환합니다.
		/// </summary>
		/// <param name="row1"> (out) 시작 Row </param>
		/// <param name="col1"> (out) 시작 Col </param>
		/// <param name="row2"> (out) 종료 Row </param>
		/// <param name="col2"> (out) 종료 Col </param>
		internal void FindSelectionCorner(out int row1,out int col1, out int row2,out  int col2)
		{
			row1 = int.MaxValue;
			col1 = int.MaxValue;
			row2 = int.MinValue;
			col2 = int.MinValue;
			foreach ( XCell c in this)
			{
				if (row1 > c.Row)
					row1 = c.Row;
				if (col1 > c.Col)
					col1 = c.Col;
				if (row2 < c.Row)
					row2 = c.Row;
				if (col2 < c.Col)
					col2 = c.Col;
			}
		}
		/// <summary>
		/// 선택영역을 Clipboard에 복사합니다.
		/// </summary>
		internal void ClipboardCopy()
		{
			try
			{
				int row1,col2,row2,col1;
				if (Count>0)
				{
				
					//Clipboard text format
					FindSelectionCorner(out row1,out col1, out row2,out col2);
					System.Text.StringBuilder l_TabBuffer = new System.Text.StringBuilder();
					for (int r = row1; r <= row2; r++)
					{
						for (int c = col1;c <= col2; c++)
						{
							//devo controllare che la cella sia selezionata perch?la find trova soltanto gli estremi
							if (grid[r,c] != null && grid[r,c].Select == true)
							{
								l_TabBuffer.Append(grid[r,c].Value.ToString());
							}

							if (c<col2)
							{
								l_TabBuffer.Append("\t");
							}
						}
						if (r<row2)
						{
							l_TabBuffer.Append("\x0D\x0A");
						}
					}
					DataObject l_dataObj = new DataObject();
					l_dataObj.SetData(DataFormats.Text,l_TabBuffer.ToString());

					Clipboard.SetDataObject(l_dataObj,true);
				}
			}
			catch{}
		}
		#endregion

		#region Event Handlers

		private void Grid_CellSelectionChange(object sender, XCell cell)
		{
			if (cell.Select == true)
			{
				if (selectedList.Contains(cell) == false)
				{
					selectedList.Add(cell);

					if (this.rightBottomCell == null ||
						cell.Row > this.rightBottomCell.Row ||
						cell.Col > this.rightBottomCell.Col)
					{
						if (this.rightBottomCell != null)
							this.rightBottomCell.InvokeInvalidate();
						this.rightBottomCell = cell;
					}
				}
			}
			else
			{
				selectedList.Remove(cell);

				if (cell == this.rightBottomCell)
				{
					this.rightBottomCell.InvokeInvalidate();
					//bisognerebbe ricalcolare la cella RightBottom
					this.rightBottomCell = null;
				}
			}
		}
		#endregion

	}
	#endregion

	#region XCellRowInfo
	/// <summary>
	/// Row의 Top위치와 높이를 관리하는 Class입니다.
	/// </summary>
	internal class XCellRowInfo
	{
		private int height = 0;
		private int top	   = 0;
		/// <summary>
		/// Row의 높이를 가져오거나 설정합니다.
		/// </summary>
		public int Height
		{
			get { return height;}
			set { height = value;}
		}
		/// <summary>
		/// Row의 Top 위치를 가져오거나 설정합니다.
		/// </summary>
		public int Top
		{
			get { return top;}
			set { top = value;}
		}
		/// <summary>
		/// XCellRowInfo 생성자
		/// </summary>
		/// <param name="height"> 높이 </param>
		/// <param name="top"> Top의 위치 </param>
		public XCellRowInfo(int height, int top)
		{
			this.height = height;
			this.top = top;
		}
	}
	#endregion
	
	#region XCellColInfo
	/// <summary>
	/// Column의 너비와 Left 위치를 관리하는 Class입니다.
	/// </summary>
	internal class XCellColInfo
	{
		private int width = 0;
		private int left = 0;
		/// <summary>
		/// Column의 너비를 가져오거나 설정합니다.
		/// </summary>
		public int Width
		{
			get { return width;}
			set { width = value;}
		}
		/// <summary>
		/// Column의 Left 위치를 가져오거나 설정합니다.
		/// </summary>
		public int Left
		{
			get { return left;}
			set { left = value;}
		}
		/// <summary>
		/// XCellColInfo 생성자
		/// </summary>
		/// <param name="width"> 너비 </param>
		/// <param name="left"> left 위치 </param>
		public XCellColInfo(int width, int left)
		{
			this.width = width;
			this.left = left;
		}
	}
	#endregion

	#region XCellRowInfoCollection
	/// <summary>
	/// XCellRowInfo 객체의 List를 관리하는 컬렉션입니다.
	/// </summary>
	internal class XCellRowInfoCollection : ICollection
	{
		private class XCellRowInfoTopComparer : IComparer
		{
			public System.Int32 Compare ( System.Object x , System.Object y )
			{
				return ((XCellRowInfo)x).Top.CompareTo( ((XCellRowInfo)y).Top);
			}
		}

		private ArrayList rowInfoList = new ArrayList();
		private XCellRowInfoTopComparer comparer = new XCellRowInfoTopComparer();

		/// <summary>
		/// 절대좌표 Y에 위치한 Row의 값을 가져옵니다.
		/// </summary>
		/// <param name="yPos"> 절대좌표 Y 위치 </param>
		/// <returns> Row의 값 </returns>
		internal int GetRowAtPoint(int yPos)
		{
			XCellRowInfo findInfo = new XCellRowInfo(0,yPos);
			int findRow = rowInfoList.BinarySearch(findInfo, comparer);
			if (findRow >= 0) 
				return findRow;
			else
			{
				//bitwise operator to return the nearest index
				findRow = ~findRow; 
				if (findRow <= 0)
					return -1; 
				else if (findRow <= rowInfoList.Count)
					return findRow -1; 
				else
					return -1; 
			}
		}
		/// <summary>
		/// XCellRowInfo를 List에 추가합니다.
		/// </summary>
		/// <param name="rowInfo"> XCellRowInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(XCellRowInfo rowInfo)
		{
			return rowInfoList.Add(rowInfo);
		}
		/// <summary>
		/// XCellRowInfo를 List의 특정 Index에 추가합니다.
		/// </summary>
		/// <param name="index"> 추가할 Index </param>
		/// <param name="rowInfo"> XCellRowInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(int index, XCellRowInfo rowInfo)
		{
			rowInfoList.Insert(index,rowInfo);
			return index;
		}
		/// <summary>
		/// XCellRowInfo[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="rowInfos"> XCellRowInfo[] </param>
		internal void AddRange(XCellRowInfo[] rowInfos)
		{
			rowInfoList.Clear();
			foreach (XCellRowInfo info in rowInfos)
				Add(info);
		}
		/// <summary>
		/// 해당 Index의 XCellRowInfo를 삭제합니다.
		/// </summary>
		/// <param name="index"> 삭제할 위치 Index </param>
		internal void RemoveAt(int index)
		{
			rowInfoList.RemoveAt(index);
		}
		/// <summary>
		/// 컬렉션에 속하는 XCellRowInfo을 XCellRowInfo[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XCellRowInfo[] </returns>
		internal XCellRowInfo[] ToArray()
		{
			XCellRowInfo[] rowInfoArray = new XCellRowInfo[rowInfoList.Count];
			for (int i = 0; i < rowInfoList.Count; i++)
				rowInfoArray[i] = (XCellRowInfo) rowInfoList[i];
			return rowInfoArray;
		}
		/// <summary>
		/// 해당 Index에 있는 XCellRowInfo 객체를 반환합니다.
		/// </summary>
		internal XCellRowInfo this[int index]
		{
			get
			{
				try
				{
					return (XCellRowInfo)rowInfoList[index];
				}
				catch
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Source 배열의 지정한 Index에서 시작하여 대상 Array에 복사합니다.
		/// </summary>
		/// <param name="array"> 대상 Array </param>
		/// <param name="index"> 시작 Index </param>
		void ICollection.CopyTo ( System.Array array , int index )
		{
			rowInfoList.CopyTo(array,index);
		}
		/// <summary>
		/// List에 있는 XCellRowInfo 객체의 갯수를 반환합니다.
		/// </summary>
		public int Count
		{
			get{return rowInfoList.Count;}
		}
		/// <summary>
		/// 액세스가 동기화(스레드 안전)되는지 여부를 나타내는 값을 가져옵니다.
		/// </summary>
		bool ICollection.IsSynchronized
		{
			get{return rowInfoList.IsSynchronized;}
		}
		/// <summary>
		/// 액세스를 동기화하는 데 사용할 수 있는 개체를 가져옵니다.
		/// </summary>
		object ICollection.SyncRoot
		{
			get{return rowInfoList.SyncRoot;}
		}
		/// <summary>
		/// ArrayList 전체에 걸쳐 반복할 수 있는 열거자를 반환합니다.
		/// </summary>
		/// <returns> IEnumerator </returns>
		IEnumerator IEnumerable.GetEnumerator (  )
		{
			return rowInfoList.GetEnumerator();
		}
	}
	#endregion

	#region XCellColInfoCollection
	/// <summary>
	/// XCellColInfo 객체의 List를 관리하는 컬렉션입니다.
	/// </summary>
	internal class XCellColInfoCollection : ICollection
	{
		private class XCellColInfoLeftComparer : IComparer
		{
			public System.Int32 Compare ( System.Object x , System.Object y )
			{
				return ((XCellColInfo)x).Left.CompareTo( ((XCellColInfo)y).Left);
			}
		}

		private ArrayList colInfoList = new ArrayList();
		private XCellColInfoLeftComparer comparer = new XCellColInfoLeftComparer();

		/// <summary>
		/// 절대좌표 X에 위치한 Col의 값을 가져옵니다.
		/// </summary>
		/// <param name="xPos"> 절대좌표  X 위치 </param>
		/// <returns> Col의 값 </returns>
		internal int GetColAtPoint(int xPos)
		{
			XCellColInfo findInfo = new XCellColInfo(0, xPos);
			int findCol = colInfoList.BinarySearch(findInfo, comparer);
			if (findCol >= 0) 
				return findCol;
			else
			{
				//bitwise operator to return the nearest index
				findCol = ~findCol; 
				if (findCol <= 0)
					return -1; 
				else if (findCol <= colInfoList.Count)
					return findCol -1; 
				else
					return -1; 
			}
		}
		/// <summary>
		/// XCellColInfo를 List에 추가합니다.
		/// </summary>
		/// <param name="colInfo"> XCellColInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(XCellColInfo colInfo)
		{
			return colInfoList.Add(colInfo);
		}
		/// <summary>
		/// XCellColInfo를 List의 특정 Index에 추가합니다.
		/// </summary>
		/// <param name="index"> 추가할 Index </param>
		/// <param name="colInfo"> XCellColInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(int index, XCellColInfo colInfo)
		{
			colInfoList.Insert(index,colInfo);
			return index;
		}
		/// <summary>
		/// XCellColInfo[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="colInfos"> XCellColInfo[] </param>
		internal void AddRange(XCellColInfo[] colInfos)
		{
			colInfoList.Clear();
			foreach (XCellColInfo info in colInfos)
				Add(info);
		}
		/// <summary>
		/// 해당 Index의 XCellColInfo를 삭제합니다.
		/// </summary>
		/// <param name="index"> 삭제할 위치 Index </param>
		internal void RemoveAt(int index)
		{
			colInfoList.RemoveAt(index);
		}
		/// <summary>
		/// 컬렉션에 속하는 XCellColInfo을 XCellColInfo[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XCellColInfo[] </returns>
		internal XCellColInfo[] ToArray()
		{
			XCellColInfo[] colInfoArray = new XCellColInfo[colInfoList.Count];
			for (int i = 0; i < colInfoList.Count; i++)
				colInfoArray[i] = (XCellColInfo) colInfoList[i];
			return colInfoArray;
		}
		/// <summary>
		/// 해당 Index에 있는 XCellColInfo 객체를 반환합니다.
		/// </summary>
		internal XCellColInfo this[int index]
		{
			get
			{
				try
				{
					return (XCellColInfo)colInfoList[index];
				}
				catch
				{
					return null;
				}
			}
		}
		/// <summary>
		/// Source 배열의 지정한 Index에서 시작하여 대상 Array에 복사합니다.
		/// </summary>
		/// <param name="array"> 대상 Array </param>
		/// <param name="index"> 시작 Index </param>
		void ICollection.CopyTo ( System.Array array , int index )
		{
			colInfoList.CopyTo(array,index);
		}
		/// <summary>
		/// List에 있는 XCellColInfo 객체의 갯수를 반환합니다.
		/// </summary>
		public int Count
		{
			get{return colInfoList.Count;}
		}
		/// <summary>
		/// 액세스가 동기화(스레드 안전)되는지 여부를 나타내는 값을 가져옵니다.
		/// </summary>
		bool ICollection.IsSynchronized
		{
			get{return colInfoList.IsSynchronized;}
		}
		/// <summary>
		/// 액세스를 동기화하는 데 사용할 수 있는 개체를 가져옵니다.
		/// </summary>
		object ICollection.SyncRoot
		{
			get{return colInfoList.SyncRoot;}
		}
		/// <summary>
		/// ArrayList 전체에 걸쳐 반복할 수 있는 열거자를 반환합니다.
		/// </summary>
		/// <returns> IEnumerator </returns>
		IEnumerator IEnumerable.GetEnumerator (  )
		{
			return colInfoList.GetEnumerator();
		}

	}
	#endregion

	#region XCellBorder
	/// <summary>
	/// Cell의 테두리의 색깔과 너비를 관리하는 Structure입니다.
	/// </summary>
	internal struct XCellBorder
	{
		private float width;
		private Color color;
		/// <summary>
		/// 테두리의 너비를 가져오거나 설정합니다.
		/// </summary>
		internal float Width
		{
			get{return width;}
			set{width = value;}
		}
		/// <summary>
		/// 테두리의 Color를 가져오거나 설정합니다.
		/// </summary>
		internal Color Color
		{
			get{return color;}
			set{color = value;}
		}
		/// <summary>
		/// XCellBorder 생성자 
		/// </summary>
		/// <param name="color"> Color </param>
		internal XCellBorder(Color color)
		{
			this.color = color;
			this.width = 1;
		}
		/// <summary>
		/// XCellBorder 생성자 
		/// </summary>
		/// <param name="color"> Color </param>
		/// <param name="width"> 너비 </param>
		internal XCellBorder(Color color, float width)
		{
			this.color = color;
			this.width = width;
		}
	}
	#endregion

	#region XGridScrollPositionChangedEventHandler
	/// <summary>
	/// ScrollBar의 위치가 바뀔때 발생하는 이벤트를 처리하는 메서드를 나타냅니다.
	/// </summary>
	internal delegate void XGridScrollPositionChangedEventHandler(object sender, XGridScrollPositionChangedEventArgs e);
	/// <summary>
	/// ScrollBar의 위치가 바뀔때 발생하는 이벤트에 데이타를 전달합니다.
	/// </summary>
	internal class XGridScrollPositionChangedEventArgs : EventArgs
	{
		private int newValue;
		private int oldValue;
		/// <summary>
		/// 새 위치값을 가져옵니다.
		/// </summary>
		public int NewValue
		{
			get{return newValue;}
		}
		/// <summary>
		/// 이전 위치값을 가져옵니다.
		/// </summary>
		public int OldValue
		{
			get{return oldValue;}
		}
		/// <summary>
		/// 이전위치와 새위치의 차이값을 가져옵니다.
		/// </summary>
		public int Delta
		{
			get{return oldValue - newValue;}
		}
		/// <summary>
		/// XGridScrollPositionChangedEventArgs 생성자 
		/// </summary>
		/// <param name="newValue"> 새 위치값</param>
		/// <param name="oldValue"> 이전 위치값</param>
		internal XGridScrollPositionChangedEventArgs(int newValue, int oldValue)
		{
			this.newValue = newValue;
			this.oldValue = oldValue;
		}
	}
	#endregion

	#region XCellComparer
	/// <summary>
	/// XCellComparer class에 대한 요약 설명입니다.
	/// </summary>
	internal class XCellComparer : IComparer
	{
		/// <summary>
		/// 두개의 값을 비교합니다.
		/// </summary>
		/// <param name="x"> 비교 object </param>
		/// <param name="y"> 비교 object </param>
		/// <returns> 같으면 0, x가 크면 1, 작으면 -1  </returns>
		public virtual int Compare ( System.Object x , System.Object y )
		{
			object vx = null;
			object vy = null;

			//Cell object
			if (x==null && y==null)
				return 0;
			if (x==null)
				return -1;
			if (y==null)
				return 1;

			if (x is IComparable)
				return ((IComparable)x).CompareTo(y);
			if (y is IComparable)
				return (-1* ((IComparable)y).CompareTo(x));

			//Cell.Value object
			try
			{
				vx = ((XCell)x).Value;
				vy = ((XCell)y).Value;

				if (vx==null && vy==null)
					return 0;
				if (vx==null)
					return -1;
				if (vy==null)
					return 1;
			
				if (vx is IComparable)
					return ((IComparable)vx).CompareTo(vy);
				if (vy is IComparable)
					return (-1* ((IComparable)vy).CompareTo(vx));
			}
			catch
			{
				return 0;
			}

			throw new ArgumentException("Invalid cell object, no IComparable interface found");
		}
	}
	#endregion

	#region XNumericCellComparer
	/// <summary>
	/// XCellNumericComparer class에 대한 요약 설명입니다.
	/// </summary>
	internal class XNumericCellComparer : IComparer
	{
		/// <summary>
		/// 두개의 값을 비교합니다.
		/// </summary>
		/// <param name="x"> 비교 object </param>
		/// <param name="y"> 비교 object </param>
		/// <returns> 같으면 0, x가 크면 1, 작으면 -1  </returns>
		public virtual int Compare ( System.Object x , System.Object y )
		{
			object vx = null;
			object vy = null;
			//Cell object
			if (x==null && y==null)
				return 0;
			if (x==null)
				return -1;
			if (y==null)
				return 1;
			
			try
			{
				//Cell.Value object
				vx = ((XCell)x).Value;
				vy = ((XCell)y).Value;

				if (vx==null && vy==null)
					return 0;
				if (vx==null)
					return -1;
				if (vy==null)
					return 1;
				// 둘다 Double이 아니면 0, vx가 아니면 -1, vy가 아니면 1
				if (!TypeCheck.IsDouble(vx) && !TypeCheck.IsDouble(vy))
					return 0;
				else if (!TypeCheck.IsDouble(vx))
					return -1;
				else if (!TypeCheck.IsDouble(vy))
					return 1;
			}
			catch
			{
				return 0;
			}

			return Double.Parse(vx.ToString()).CompareTo(Double.Parse(vy.ToString()));
			
		}
	}
	#endregion

	#region XCellStringComparer
	/// <summary>
	/// XCellStringComparer class에 대한 요약 설명입니다.
	/// </summary>
	internal class XCellStringComparer : IComparer
	{
		/// <summary>
		/// 두개의 값을 비교합니다.
		/// </summary>
		/// <param name="x"> 비교 object </param>
		/// <param name="y"> 비교 object </param>
		/// <returns> 같으면 0, x가 크면 1, 작으면 -1  </returns>
		public virtual int Compare ( System.Object x , System.Object y )
		{
			//object null check
			if (x==null && y==null)
				return 0;
			if (x==null)
				return -1;
			if (y==null)
				return 1;

			if (x is IComparable)
				return ((IComparable)x).CompareTo(y);
			if (y is IComparable)
				return (-1* ((IComparable)y).CompareTo(x));

			throw new ArgumentException("Invalid object, no IComparable interface found");
		}
	}
	#endregion

	#region XCellNumericComparer
	/// <summary>
	/// XCellNumericComparer class에 대한 요약 설명입니다.
	/// </summary>
	internal class XCellNumericComparer : IComparer
	{
		/// <summary>
		/// 두개의 값을 비교합니다.
		/// </summary>
		/// <param name="x"> 비교 object </param>
		/// <param name="y"> 비교 object </param>
		/// <returns> 같으면 0, x가 크면 1, 작으면 -1  </returns>
		public virtual int Compare ( System.Object x , System.Object y )
		{
			//Cell object
			if (x==null && y==null)
				return 0;
			if (x==null)
				return -1;
			if (y==null)
				return 1;
			
			// 둘다 Double이 아니면 0, vx가 아니면 -1, vy가 아니면 1
			if (!TypeCheck.IsDouble(x) && !TypeCheck.IsDouble(y))
				return 0;
			else if (!TypeCheck.IsDouble(x))
				return -1;
			else if (!TypeCheck.IsDouble(y))
				return 1;
			
			return Double.Parse(x.ToString()).CompareTo(Double.Parse(y.ToString()));
		}
	}
	#endregion

	#region XGridImage
	/// <summary>
	/// Grid Icon을 관리하는 class입니다.
	/// </summary>
	internal class XGridImage
	{
		#region Fields
		private const string cImagePath = @"IHIS.Framework.Images.";
		private static Image sortUpIcon;
		private static Image sortDownIcon;
		private static Image cleanBox;
		private static Image paddingHeader;
		private static Image recoverPadding;
		private static Image sameWidth;
		private static Cursor dragCursor;
		private static Cursor upDownCursor;
		private static Cursor leftRightCursor;
		private static Image blueball;
		private static Image redball;
		private static Image emptyMemo;
		private static Image fullMemo;
		#endregion

		#region Properties
		/// <summary>
		/// Up삼각형 모양의 Icon을 가져옵니다.
		/// </summary>
		public static Image SortUpIcon
		{
			get { return sortUpIcon;}
		}
		/// <summary>
		/// Down삼각형 모양의 Icon을 가져옵니다.
		/// </summary>
		public static Image SortDownIcon
		{
			get { return sortDownIcon;}
		}
		/// <summary>
		/// CleanBox Image을 가져옵니다.
		/// </summary>
		public static Image CleanBox
		{
			get { return cleanBox;}
		}
		/// <summary>
		/// Drag Cursor 을 가져옵니다.
		/// </summary>
		public static Cursor DragCursor
		{
			get { return dragCursor;}
		}
		/// <summary>
		/// UpDown Cursor 을 가져옵니다.
		/// </summary>
		public static Cursor UpDownCursor
		{
			get { return upDownCursor;}
		}
		/// <summary>
		/// LeftRight Cursor 을 가져옵니다.
		/// </summary>
		public static Cursor LeftRightCursor
		{
			get { return leftRightCursor;}
		}
		/// <summary>
		/// PaddingHeader Image을 가져옵니다.
		/// </summary>
		public static Image PaddingHeader
		{
			get { return paddingHeader;}
		}
		/// <summary>
		/// RecoverPadding Image을 가져옵니다.
		/// </summary>
		public static Image RecoverPadding
		{
			get { return recoverPadding;}
		}
		/// <summary>
		/// SameWidth Image을 가져옵니다.
		/// </summary>
		public static Image SameWidth
		{
			get { return sameWidth;}
		}
		/// <summary>
		/// RedBall Image을 가져옵니다.
		/// </summary>
		public static Image Redball
		{
			get { return redball;}
		}
		/// <summary>
		/// BlueBall Image을 가져옵니다.
		/// </summary>
		public static Image Blueball
		{
			get { return blueball;}
		}
		/// <summary>
		/// EmptyMemo Image을 가져옵니다.
		/// </summary>
		public static Image EmptyMemo
		{
			get { return emptyMemo;}
		}
		/// <summary>
		/// FullMemo Image을 가져옵니다.
		/// </summary>
		public static Image FullMemo
		{
			get { return fullMemo;}
		}
		#endregion

		static XGridImage()
		{
			sortUpIcon		= ExtractImage("SortUp.ico");
			sortDownIcon	= ExtractImage("SortDown.ico");
			cleanBox		= ExtractImage("Cleanbox.gif");
			dragCursor		= ExtractCursor("Drag.cur");
			upDownCursor	= ExtractCursor("Updown.cur");
			leftRightCursor	= ExtractCursor("Leftright.cur");
			paddingHeader	= ExtractImage("PaddingHeader.gif");
			recoverPadding	= ExtractImage("RecoverPadding.gif");
			sameWidth		= ExtractImage("SameWidth.gif");
			redball			= ExtractImage("Redball.gif");
			blueball		= ExtractImage("Blueball.gif");
			emptyMemo		= ExtractImage("EmptyMemo.gif");
			fullMemo		= ExtractImage("FullMemo.gif");
		}
		private static Image ExtractImage(string imageName)
		{
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			Bitmap bmp = (Bitmap) Bitmap.FromStream(l_as.GetManifestResourceStream(cImagePath + imageName));
			return bmp;
		}
		private static Cursor ExtractCursor(string imageName)
		{
			System.Reflection.Assembly l_as = System.Reflection.Assembly.GetExecutingAssembly();
			Cursor cur = new Cursor(l_as.GetManifestResourceStream(cImagePath + imageName));
			return cur;
		}

	}
	#endregion

	#region XGridGroupRowInfo, XGridGroupRowInfoCollection
	/// <summary>
	/// Group에 의해 추가된 Row의 정보(Group명, Key값, Row위치)관리하는 Class입니다.
	/// </summary>
	internal class XGridGroupRowInfo
	{
		private string groupName = "";
		private string keyValue = "";
		private int row = 0;
		private int aboveRowNumber = 0;  // 해당 GroupRow가 위치한 바로 위의 논리적인 Row의 Number
		/// <summary>
		/// Group명을 가져오거나 설정합니다.
		/// </summary>
		public string GroupName
		{
			get { return groupName;}
			set { groupName = value;}
		}
		/// <summary>
		/// Group시의 Key값을 가져오거나 설정합니다.
		/// </summary>
		public string KeyValue
		{
			get { return keyValue;}
			set { keyValue = value;}
		}
		/// <summary>
		/// Group Row의 Display된 위치를 가져오거나 설정합니다.
		/// </summary>
		public int Row
		{
			get { return row;}
			set { row = value;}
		}
		/// <summary>
		/// Group Row가 위치한 바로 위의 논리적인 RowNumber를 가져오거나 설정합니다.
		/// </summary>
		public int AboveRowNumber
		{
			get { return aboveRowNumber;}
			set { aboveRowNumber = value;}
		}
		/// <summary>
		/// XCellColInfo 생성자
		/// </summary>
		/// <param name="groupName"> Group명 </param>
		/// <param name="keyValue"> Key 값 </param>
		/// <param name="row"> Row의 Display위치 </param>
		/// <param name="aboveRowNumber"> GroupRow가 위치한 바로 위의 논리적인 RowNumber </param>
		public XGridGroupRowInfo(string groupName, string keyValue, int row, int aboveRowNumber)
		{
			this.groupName = groupName;
			this.keyValue = keyValue;
			this.row = row;
			this.aboveRowNumber = aboveRowNumber;
		}
	}
	/// <summary>
	/// XGridGroupRowInfo 객체를 관리하는 컬렉션입니다.
	/// </summary>
	internal class XGridGroupRowInfoCollection : CollectionBase
	{
		/// <summary>
		/// 해당 Index에 있는 XGridGroupRowInfo 객체를 반환합니다.
		/// </summary>
		public XGridGroupRowInfo this[int index]
		{
			get { return (XGridGroupRowInfo)List[index]; }
		}
		/// <summary>
		/// 특정 Group명과 KeyValue를 가지는 XGridGroupRowInfo 객체를 반환합니다.
		/// </summary>
		public XGridGroupRowInfo this[string groupName, string keyValue]
		{
			get
			{
				if (groupName == "") return null;
				foreach (XGridGroupRowInfo item in this)
				{
					if ((item.GroupName.ToUpper() == groupName.ToUpper()) && (item.KeyValue == keyValue))
						return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridGroupRowInfo 객체를 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="groupInfo"> XGridGroupRowInfo 객체 </param>
		public void Add(XGridGroupRowInfo groupInfo)
		{
			List.Add(groupInfo);
		}
		/// <summary>
		/// XGridGroupRowInfo 개체를 생성하여 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="groupName"> 그룹명 </param>
		/// <param name="keyValue"> Group Key 값 </param>
		/// <param name="row"> GroupRow의 Display Row 위치 </param>
		/// <param name="aboveRowNumber"> GroupRow가 위치한 바로 위의 논리적인 RowNumber </param>
		public void Add(string groupName, string keyValue, int row, int aboveRowNumber)
		{
			XGridGroupRowInfo groupInfo = new XGridGroupRowInfo(groupName, keyValue, row, aboveRowNumber);
			List.Add(groupInfo);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupRowInfo객체를 제거합니다.
		/// </summary>
		/// <param name="groupInfo">제거할 XGridGroupRowInfo객체</param>
		public void Remove(XGridGroupRowInfo groupInfo)
		{
			List.Remove(groupInfo);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupRowInfo객체를 제거합니다.
		/// </summary>
		/// <param name="groupName">제거할 Group명 </param>
		/// <param name="keyValue">제거할 Group의 Key값 </param>
		public void Remove(string groupName, string keyValue)
		{
			XGridGroupRowInfo groupInfo = null;
			foreach (XGridGroupRowInfo info in List)
			{
				if ((info.GroupName == groupName) && (info.KeyValue == keyValue))
				{
					groupInfo = info;
					break;
				}
			}
			if (groupInfo != null)
				List.Remove(groupInfo);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="groupInfo">컬렉션에서 찾을 GroupColumnInfo입니다.</param>
		/// <returns>groupInfo가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XGridGroupRowInfo groupInfo)
		{
			return List.Contains(groupInfo);
		}
		/// <summary>
		/// rowNumber보다 작은 GroupRow의 Line수를 가져옵니다.
		/// </summary>
		/// <param name="isLogical"> 인수로 전달되는 rowNumber가 Display위치인지 논리적인 RowNumber인지 여부 </param>
		/// <param name="rowNumber"> 논리적 Or Display RowNumber </param>
		/// <param name="linesPerRow"> Grid의 한 Row의 Line 수 </param>
		/// <returns> GroupRow의 Line의 갯수 </returns>
		public int GetBelowGroupLineCount(bool isLogical, int rowNumber, int linesPerRow)
		{
			int groupRowCount = 0;
			//물리적인 Row보다 작거나 같은 XGridGroupRowInfo의 갯수* 한 Row의 Line수 Return
			//물리적인 Row를 논리적인 RowNumber로 변환할 때 사용함
			foreach (XGridGroupRowInfo info in List)
			{
				if (isLogical)
				{
					if (rowNumber > info.AboveRowNumber)
						groupRowCount++;
					else
						break;
				}
				else
				{
					//if (rowNumber >= info.Row + linesPerRow)
					if (rowNumber >= info.Row)
						groupRowCount++;
					else
						break;
				}
			}
			return groupRowCount * linesPerRow;
		}
		/// <summary>
		/// Display한 Row의 값이 GroupLine에 속하는지 여부를 가져옵니다.
		/// </summary>
		/// <param name="row"> Grid에서의 Row의 위치 </param>
		/// <param name="linesPerRow"> Grid의 한 Row의 Line 수 </param>
		/// <returns> GroupRow에 속하는 Row이면 true, 아니면 false </returns>
		public bool IsInGroupLine(int row, int linesPerRow)
		{
			foreach (XGridGroupRowInfo info in List)
			{
				if ((row >= info.Row) && (row < info.Row + linesPerRow))
					return true;
			}
			return false;
		}
		/// <summary>
		/// 해당 Group명과 KeyValue를 가진 Bottom의 XGridGroupRowInfo를 Return합니다.
		/// </summary>
		/// <param name="groupName"> Group명 </param>
		/// <param name="keyValue"> KeyValue값 </param>
		/// <returns> XGridGroupRowInfo 개체 </returns>
		public XGridGroupRowInfo GetBottomXGridGroupRowInfo(string groupName, string keyValue)
		{
			XGridGroupRowInfo info = null;
			for (int i = List.Count -1 ; i >= 0 ; i++)
			{
				info = List[i] as XGridGroupRowInfo;
				if ((info.GroupName == groupName) && (info.KeyValue == keyValue))
					return info;
			}
			return null;
		}
	}
	#endregion

	#region XGridGroupData, XGridGroupSubData, XGridGroupDataCollection, XGridGroupSubDataCollection
	internal class XGridGroupData
	{
		private string groupName = "";
		private string keyValue = XGridUtility.KeyInitValue; // 최초는 $$$
		private XGridGroupSubDataCollection subDataList = new XGridGroupSubDataCollection();
		internal string GroupName
		{
			get { return groupName;}
		}
		internal string KeyValue
		{
			get { return keyValue;}
			set { keyValue = value;}
		}
		internal XGridGroupSubDataCollection SubDataList
		{
			get { return subDataList;}
		}
		internal XGridGroupData(string groupName)
		{
			this.groupName = groupName;
		}
	}
	internal class XGridGroupSubData
	{
		private Guid identifier;  //ComputedXGridCell의 식별자
		private XGridComputedKind kind;
		private string keyName;
		private int    dataCount = 0;  //Data의 갯수
		private object dataValue = "";
		private ArrayList dataList = new ArrayList();  //Data의 List 보관
		internal Guid Identifier
		{
			get { return identifier;}
		}
		internal string KeyName
		{
			get { return keyName;}
		}
		internal int DataCount
		{
			get { return dataCount;}
			set { dataCount = value;}
		}
		internal object DataValue
		{
			get { return dataValue;}
			set { dataValue = value;}
		}
		internal XGridComputedKind Kind
		{
			get { return kind;}
		}
		internal ArrayList DataList
		{
			get { return dataList;}
		}
		internal XGridGroupSubData(Guid identifier, XGridComputedKind kind, string keyName)
		{
			this.identifier = identifier;
			this.kind = kind;
			this.keyName = keyName;
		}
	}

	/// <summary>
	/// XGridGroupData 객체를 관리하는 컬렉션입니다.
	/// </summary>
	internal class XGridGroupDataCollection : CollectionBase
	{
		/// <summary>
		/// 해당 Index에 있는 XGridGroupSubData 객체를 반환합니다.
		/// </summary>
		public XGridGroupData this[int index]
		{
			get { return (XGridGroupData)List[index]; }
		}
		/// <summary>
		/// 특정 GroupName 가지는 XGridGroupSubData 객체를 반환합니다.
		/// </summary>
		public XGridGroupData this[string groupName]
		{
			get
			{
				if (groupName == "") return null;
				foreach (XGridGroupData item in this)
				{
					if (item.GroupName == groupName)
						return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridGroupData 객체를 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="groupData"> XGridGroupData 객체 </param>
		public void Add(XGridGroupData groupData)
		{
			foreach (XGridGroupData item in List)
			{
				if (item.GroupName == groupData.GroupName)
					throw(new Exception("[XGridGroupData]이미 등록된 그룹명과 동일합니다."));
			}
			List.Add(groupData);
		}
		/// <summary>
		/// XGridGroupData 개체를 생성하여 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="groupName"> XGridComputedKind Enum </param>
		public void Add(string groupName)
		{
			foreach (XGridGroupData item in List)
			{
				if (item.GroupName == groupName)
					throw(new Exception("[XGridGroupData]이미 등록된 그룹명과 동일합니다."));
			}
			XGridGroupData groupData = new XGridGroupData(groupName);
			List.Add(groupData);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupData객체를 제거합니다.
		/// </summary>
		/// <param name="groupData">제거할 XGridGroupData객체</param>
		public void Remove(XGridGroupData groupData)
		{
			List.Remove(groupData);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupData객체를 제거합니다.
		/// </summary>
		/// <param name="groupName"> 제거할 Group명 </param>
		public void Remove(string groupName)
		{
			XGridGroupData groupData = null;
			foreach (XGridGroupData item in List)
			{
				if (item.GroupName == groupName)
				{
					groupData = item;
					break;
				}
			}
			if (groupData != null)
				List.Remove(groupData);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="groupData">컬렉션에서 찾을 XGridGroupData입니다.</param>
		/// <returns> XGridGroupData가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XGridGroupData groupData)
		{
			return List.Contains(groupData);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="groupName"> 그룸명 </param>
		public bool Contains(string groupName)
		{
			foreach (XGridGroupData item in List)
				if (item.GroupName == groupName)
					return true;
			return false;
		}
	}

	/// <summary>
	/// XGridGroupSubData 객체를 관리하는 컬렉션입니다.
	/// </summary>
	internal class XGridGroupSubDataCollection : CollectionBase
	{
		/// <summary>
		/// 해당 Index에 있는 XGridGroupSubData 객체를 반환합니다.
		/// </summary>
		public XGridGroupSubData this[int index]
		{
			get { return (XGridGroupSubData)List[index]; }
		}
		/// <summary>
		/// 특정 identifier 가지는 XGridGroupSubData 객체를 반환합니다.
		/// </summary>
		public XGridGroupSubData this[Guid identifier]
		{
			get
			{
				foreach (XGridGroupSubData item in this)
				{
					if (item.Identifier == identifier)
						return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridGroupSubData 객체를 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="subData"> XGridGroupSubData 객체 </param>
		public void Add(XGridGroupSubData subData)
		{
			foreach (XGridGroupSubData item in List)
			{
				if (item.Identifier == subData.Identifier)
					throw(new Exception("[XGridGroupSubData]이미 등록된 XGridGroupSubData와 동일합니다."));
			}
			List.Add(subData);
		}
		/// <summary>
		/// XGridGroupSubData 개체를 생성하여 컬렉션의 끝에 추가합니다.
		/// </summary>
		/// <param name="identifier"> ComputedXGridCell의 식별자 </param>
		/// <param name="kind"> XGridComputedKind Enum </param>
		/// <param name="keyName"> Data를 표시하는 KeyName </param>
		public void Add(Guid identifier, XGridComputedKind kind, string keyName)
		{
			foreach (XGridGroupSubData item in List)
			{
				if (item.Identifier == identifier)
					throw(new Exception("[XGridGroupSubData]이미 등록된 XGridGroupSubData와 동일합니다."));
			}
			XGridGroupSubData subData = new XGridGroupSubData(identifier, kind, keyName);
			List.Add(subData);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupSubData객체를 제거합니다.
		/// </summary>
		/// <param name="subData">제거할 XGridGroupSubData객체</param>
		public void Remove(XGridGroupSubData subData)
		{
			List.Remove(subData);
		}
		/// <summary>
		/// 컬렉션에서 맨 처음 발견되는 XGridGroupSubData객체를 제거합니다.
		/// </summary>
		/// <param name="identifier"> 식별자 </param>
		public void Remove(Guid identifier)
		{
			XGridGroupSubData subData = null;
			foreach (XGridGroupSubData item in List)
			{
				if (item.Identifier == identifier)
				{
					subData = item;
					break;
				}
			}
			if (subData != null)
				List.Remove(subData);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="subData">컬렉션에서 찾을 XGridGroupSubData입니다.</param>
		/// <returns> XGridGroupSubData가 컬렉션에 있으면 true이고, 그렇지 않으면 false입니다.</returns>
		public bool Contains(XGridGroupSubData subData)
		{
			return List.Contains(subData);
		}
		/// <summary>
		/// 요소가 컬렉션에 있는지 여부를 확인합니다.
		/// </summary>
		/// <param name="identifier"> 식별자 </param>
		public bool Contains(Guid identifier)
		{
			foreach (XGridGroupSubData item in List)
				if (item.Identifier == identifier)
					return true;
			return false;
		}
	}
	#endregion

	#region XGridDataItemCollection
	/// <summary>
	/// Data Item class (dataName과 dataValue 관리)
	/// </summary>
	internal class XGridDataItem
	{
		private string		dataName;
		private object		dataValue;
		
		/// <summary>
		/// Data의 Name을 가져오거나 설정합니다.
		/// </summary>
		public string DataName
		{
			get { return dataName; }
			set { dataName = value; }
		}
		/// <summary>
		/// Data의 Value를 가져오거나 설정합니다.
		/// </summary>
		public object DataValue
		{
			get { return dataValue; }
			set { dataValue = value; }
		}
		/// <summary>
		/// XGridDataItem 생성자
		/// </summary>
		public XGridDataItem()
		{
		}
		/// <summary>
		/// XGridDataItem 생성자
		/// </summary>
		/// <param name="dataName"></param>
		/// <param name="dataValue"></param>
		public XGridDataItem(string dataName, object dataValue)
		{
			this.dataName = dataName;
			this.dataValue = dataValue;
		}
	}

	/// <summary>
	/// Data Item Collection
	/// </summary>
	internal class XGridDataItemCollection : CollectionBase
	{
		/// <summary>
		/// XGridDataItemCollection 생성자
		/// </summary>
		public XGridDataItemCollection()
		{
		}
		
		/// <summary>
		/// 지정한 Index에 있는 XGridDataItem을 가져옵니다.
		/// </summary>
		public XGridDataItem this[int index]
		{
			get { return (XGridDataItem)List[index]; }
		}
		
		/// <summary>
		/// 지정한 Key에 있는 XGridDataItem을 가져옵니다.
		/// </summary>
		public XGridDataItem this[string key]
		{
			get
			{
				if (key == "") return null;
				foreach (XGridDataItem item in this)
				{
					if (item.DataName == key) return item;
				}
				return null;
			}
		}
		/// <summary>
		/// XGridDataItem 을 Collection의 끝에 추가합니다.
		/// </summary>
		/// <param name="item"> XGridDataItem class</param>
		public void Add(XGridDataItem item)
		{
			List.Add(item);
		}
		/// <summary>
		/// XGridDataItem[]를 Collection에 추가합니다.
		/// </summary>
		/// <param name="items"> XGridDataItem class Array</param>
		public void AddRange(XGridDataItem[] items)
		{
			List.Clear();
			foreach (XGridDataItem Item in items)
			{
				List.Add(Item);
			}
		}
		/// <summary>
		/// dataName과 dataValue로 XGridDataItem을 생성 Collection의 끝에 추가합니다.
		/// </summary>
		/// <param name="dataName"> XGridDataItem의 DataName </param>
		/// <param name="dataValue"> XGridDataItem의 DataValue </param>
		public void Add(string dataName, object dataValue)
		{
			XGridDataItem	item = new XGridDataItem(dataName, dataValue);
			List.Add(item);
		}
		/// <summary>
		/// 해당 Index의 XGridDataItem을 제거합니다.
		/// </summary>
		/// <param name="index"></param>
		public void Remove(int index)
		{
			if (index > Count - 1 || index < 0)
			{
				throw (new IndexOutOfRangeException());
			}
			else
			{
				List.RemoveAt(index); 
			}
		}
	}
	#endregion

	#region XCellPosInfoCollection
	/// <summary>
	/// Data Item class (dataName과 dataValue 관리)
	/// </summary>
	internal class XCellPosInfo
	{
		private string		cellName = string.Empty;
		private int			rowPos = 0;
		private int			rowSpan = 1;
		
		internal string CellName
		{
			get { return cellName; }
			set { cellName = value; }
		}
		internal int RowPos
		{
			get { return rowPos; }
			set { rowPos = value; }
		}
		internal int RowSpan
		{
			get { return rowSpan; }
			set { rowSpan = value; }
		}
		public XCellPosInfo(string cellName, int rowPos, int rowSpan)
		{
			this.cellName = cellName;
			this.rowPos = rowPos;
			this.rowSpan = rowSpan;
		}
	}

	/// <summary>
	/// Data Item Collection
	/// </summary>
	internal class XCellPosInfoCollection : CollectionBase
	{
		/// <summary>
		/// XCellPosInfoCollection 생성자
		/// </summary>
		public XCellPosInfoCollection()
		{
		}
		
		/// <summary>
		/// 지정한 Index에 있는 XGridDataItem을 가져옵니다.
		/// </summary>
		public XCellPosInfo this[int index]
		{
			get { return (XCellPosInfo)List[index]; }
		}
		/// <summary>
		/// 지정한 Key에 있는 XGridDataItem을 가져옵니다.
		/// </summary>
		public XCellPosInfo this[string key]
		{
			get
			{
				if (key == "") return null;
				foreach (XCellPosInfo item in this)
				{
					if (item.CellName == key) return item;
				}
				return null;
			}
		}
		public void Add(string cellName, int rowPos, int rowSpan)
		{
			XCellPosInfo item = new XCellPosInfo(cellName, rowPos, rowSpan);
			List.Add(item);
		}
	}
	#endregion

	#region enum DataBufferType
	public enum DataBufferType
	{
		/// <summary>
		/// 이전값
		/// </summary>
		PreviousBuffer,
		/// <summary>
		/// 현재값
		/// </summary>
		CurrentBuffer,
		/// <summary>
		/// 원래값
		/// </summary>
		OriginalBuffer
	}
	#endregion

}
