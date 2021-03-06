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
	/// Cell의 그리기 모드를 나타내는 Enum입니다.
	/// </summary>
	public enum XSheetCellDrawMode
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
	/// Grid의 현상태를 나타내는 Enum입니다.
	/// </summary>
	public enum XSheetStatus
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
	public enum XSheetSelectionMode
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
	#endregion

	#region XSheetUtility
	/// <summary>
	/// SheetUtility에 대한 요약설명입니다.
	/// </summary>
	internal class XSheetUtility
	{
		#region Static Methods
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
		#endregion
	}
	#endregion

	#region XSheetImage
	/// <summary>
	/// Grid Icon을 관리하는 class입니다.
	/// </summary>
	internal class XSheetImage
	{
		#region Fields
		private const string cImagePath = @"IHIS.Framework.Images.";
		private static Cursor dragCursor;
		private static Cursor upDownCursor;
		private static Cursor leftRightCursor;
		private static Image blueball;
		private static Image redball;
		#endregion

		#region Properties
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
		#endregion

		static XSheetImage()
		{
			dragCursor		= ExtractCursor("Drag.cur");
			upDownCursor	= ExtractCursor("Updown.cur");
			leftRightCursor	= ExtractCursor("Leftright.cur");
			redball			= ExtractImage("Redball.gif");
			blueball		= ExtractImage("Blueball.gif");
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

	#region XSheetCellEventHandler
	/// <summary>
	/// Cell의 Selection 발생 Event를 처리하는 메서드를 나타냅니다.
	/// </summary>
	internal delegate void XSheetCellEventHandler(object sender, XSheetCell cell);
	#endregion

	#region XSheetSelection
	/// <summary>
	/// XSheetSelection class에 대한 요약 설명입니다.
	/// </summary>
	public class XSheetSelection : ICollection
	{
		#region Fields
		private XSheet sheet;
		private ArrayList selectedList = new ArrayList();
		private XSheetCell rightBottomCell = null;
		#endregion

		#region Properties
		/// <summary>
		/// Selection 객체를 포함하는 Sheet를 가져옵니다.
		/// </summary>
		internal XSheet Sheet
		{
			get{return sheet;}
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
		public XSheetCell this[int index]
		{
			get
			{
				try
				{
					return (XSheetCell)selectedList[index];
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
		public XSheetCell RightBottomCell
		{
			get{return rightBottomCell;}
		}
		/// <summary>
		/// 선택영역의 좌측상단 Cell 객체를 가져옵니다.
		/// </summary>
		public XSheetCell TopLeftCell
		{
			get
			{
				try
				{
					return this.sheet.FocusCell;
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
		/// <param name="sheet">  XSheet </param>
		internal XSheetSelection(XSheet sheet)
		{
			this.sheet = sheet;
			this.sheet.CellSelectionChange += new XSheetCellEventHandler(Sheet_CellSelectionChange);
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
		internal void Clear(XSheetCell cellLeaveThisCellSelected)
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
		public bool Contains(XSheetCell cell)
		{
			return selectedList.Contains(cell);
		}
		/// <summary>
		/// 특정 Cell의 선택영역의 Index를 반환합니다.
		/// </summary>
		/// <param name="cell"> Cell 객체 </param>
		/// <returns> Index </returns>
		public int IndexOf(XSheetCell cell)
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
			foreach ( XSheetCell c in this)
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
							if (sheet[r,c] != null && sheet[r,c].Select == true)
							{
								l_TabBuffer.Append(sheet[r,c].CellText);
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

		private void Sheet_CellSelectionChange(object sender, XSheetCell cell)
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

	#region XSheetCellRowInfo
	/// <summary>
	/// Row의 Top위치와 높이를 관리하는 Class입니다.
	/// </summary>
	internal class XSheetCellRowInfo
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
		/// XSheetCellRowInfo 생성자
		/// </summary>
		/// <param name="height"> 높이 </param>
		/// <param name="top"> Top의 위치 </param>
		public XSheetCellRowInfo(int height, int top)
		{
			this.height = height;
			this.top = top;
		}
	}
	#endregion
	
	#region XSheetCellColInfo
	/// <summary>
	/// Column의 너비와 Left 위치를 관리하는 Class입니다.
	/// </summary>
	internal class XSheetCellColInfo
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
		/// XSheetCellColInfo 생성자
		/// </summary>
		/// <param name="width"> 너비 </param>
		/// <param name="left"> left 위치 </param>
		public XSheetCellColInfo(int width, int left)
		{
			this.width = width;
			this.left = left;
		}
	}
	#endregion

	#region XSheetCellRowInfoCollection
	/// <summary>
	/// XSheetCellRowInfo 객체의 List를 관리하는 컬렉션입니다.
	/// </summary>
	internal class XSheetCellRowInfoCollection : ICollection
	{
		private class XSheetCellRowInfoTopComparer : IComparer
		{
			public System.Int32 Compare ( System.Object x , System.Object y )
			{
				return ((XSheetCellRowInfo)x).Top.CompareTo( ((XSheetCellRowInfo)y).Top);
			}
		}

		private ArrayList rowInfoList = new ArrayList();
		private XSheetCellRowInfoTopComparer comparer = new XSheetCellRowInfoTopComparer();

		/// <summary>
		/// 절대좌표 Y에 위치한 Row의 값을 가져옵니다.
		/// </summary>
		/// <param name="yPos"> 절대좌표 Y 위치 </param>
		/// <returns> Row의 값 </returns>
		internal int GetRowAtPoint(int yPos)
		{
			XSheetCellRowInfo findInfo = new XSheetCellRowInfo(0,yPos);
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
		/// XSheetCellRowInfo를 List에 추가합니다.
		/// </summary>
		/// <param name="rowInfo"> XSheetCellRowInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(XSheetCellRowInfo rowInfo)
		{
			return rowInfoList.Add(rowInfo);
		}
		/// <summary>
		/// XSheetCellRowInfo를 List의 특정 Index에 추가합니다.
		/// </summary>
		/// <param name="index"> 추가할 Index </param>
		/// <param name="rowInfo"> XSheetCellRowInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(int index, XSheetCellRowInfo rowInfo)
		{
			rowInfoList.Insert(index,rowInfo);
			return index;
		}
		/// <summary>
		/// XSheetCellRowInfo[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="rowInfos"> XSheetCellRowInfo[] </param>
		internal void AddRange(XSheetCellRowInfo[] rowInfos)
		{
			rowInfoList.Clear();
			foreach (XSheetCellRowInfo info in rowInfos)
				Add(info);
		}
		/// <summary>
		/// 해당 Index의 XSheetCellRowInfo를 삭제합니다.
		/// </summary>
		/// <param name="index"> 삭제할 위치 Index </param>
		internal void RemoveAt(int index)
		{
			rowInfoList.RemoveAt(index);
		}
		/// <summary>
		/// 컬렉션에 속하는 XSheetCellRowInfo을 XSheetCellRowInfo[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XSheetCellRowInfo[] </returns>
		internal XSheetCellRowInfo[] ToArray()
		{
			XSheetCellRowInfo[] rowInfoArray = new XSheetCellRowInfo[rowInfoList.Count];
			for (int i = 0; i < rowInfoList.Count; i++)
				rowInfoArray[i] = (XSheetCellRowInfo) rowInfoList[i];
			return rowInfoArray;
		}
		/// <summary>
		/// 해당 Index에 있는 XSheetCellRowInfo 객체를 반환합니다.
		/// </summary>
		internal XSheetCellRowInfo this[int index]
		{
			get
			{
				try
				{
					return (XSheetCellRowInfo)rowInfoList[index];
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
		/// List에 있는 XSheetCellRowInfo 객체의 갯수를 반환합니다.
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

	#region XSheetCellColInfoCollection
	/// <summary>
	/// XSheetCellColInfo 객체의 List를 관리하는 컬렉션입니다.
	/// </summary>
	internal class XSheetCellColInfoCollection : ICollection
	{
		private class XSheetCellColInfoLeftComparer : IComparer
		{
			public System.Int32 Compare ( System.Object x , System.Object y )
			{
				return ((XSheetCellColInfo)x).Left.CompareTo( ((XSheetCellColInfo)y).Left);
			}
		}

		private ArrayList colInfoList = new ArrayList();
		private XSheetCellColInfoLeftComparer comparer = new XSheetCellColInfoLeftComparer();

		/// <summary>
		/// 절대좌표 X에 위치한 Col의 값을 가져옵니다.
		/// </summary>
		/// <param name="xPos"> 절대좌표  X 위치 </param>
		/// <returns> Col의 값 </returns>
		internal int GetColAtPoint(int xPos)
		{
			XSheetCellColInfo findInfo = new XSheetCellColInfo(0, xPos);
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
		/// XSheetCellColInfo를 List에 추가합니다.
		/// </summary>
		/// <param name="colInfo"> XSheetCellColInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(XSheetCellColInfo colInfo)
		{
			return colInfoList.Add(colInfo);
		}
		/// <summary>
		/// XSheetCellColInfo를 List의 특정 Index에 추가합니다.
		/// </summary>
		/// <param name="index"> 추가할 Index </param>
		/// <param name="colInfo"> XSheetCellColInfo 객체 </param>
		/// <returns> 추가된 위치 Index </returns>
		internal int Add(int index, XSheetCellColInfo colInfo)
		{
			colInfoList.Insert(index,colInfo);
			return index;
		}
		/// <summary>
		/// XSheetCellColInfo[] 를 컬렉션에 추가합니다.
		/// </summary>
		/// <param name="colInfos"> XSheetCellColInfo[] </param>
		internal void AddRange(XSheetCellColInfo[] colInfos)
		{
			colInfoList.Clear();
			foreach (XSheetCellColInfo info in colInfos)
				Add(info);
		}
		/// <summary>
		/// 해당 Index의 XSheetCellColInfo를 삭제합니다.
		/// </summary>
		/// <param name="index"> 삭제할 위치 Index </param>
		internal void RemoveAt(int index)
		{
			colInfoList.RemoveAt(index);
		}
		/// <summary>
		/// 컬렉션에 속하는 XSheetCellColInfo을 XSheetCellColInfo[]에 복사하여 반환합니다.
		/// </summary>
		/// <returns> XSheetCellColInfo[] </returns>
		internal XSheetCellColInfo[] ToArray()
		{
			XSheetCellColInfo[] colInfoArray = new XSheetCellColInfo[colInfoList.Count];
			for (int i = 0; i < colInfoList.Count; i++)
				colInfoArray[i] = (XSheetCellColInfo) colInfoList[i];
			return colInfoArray;
		}
		/// <summary>
		/// 해당 Index에 있는 XSheetCellColInfo 객체를 반환합니다.
		/// </summary>
		internal XSheetCellColInfo this[int index]
		{
			get
			{
				try
				{
					return (XSheetCellColInfo)colInfoList[index];
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
		/// List에 있는 XSheetCellColInfo 객체의 갯수를 반환합니다.
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

	#region XSheetScrollPositionChangedEventHandler
	/// <summary>
	/// ScrollBar의 위치가 바뀔때 발생하는 이벤트를 처리하는 메서드를 나타냅니다.
	/// </summary>
	internal delegate void XSheetScrollPositionChangedEventHandler(object sender, XSheetScrollPositionChangedEventArgs e);
	/// <summary>
	/// ScrollBar의 위치가 바뀔때 발생하는 이벤트에 데이타를 전달합니다.
	/// </summary>
	internal class XSheetScrollPositionChangedEventArgs : EventArgs
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
		/// XSheetScrollPositionChangedEventArgs 생성자 
		/// </summary>
		/// <param name="newValue"> 새 위치값</param>
		/// <param name="oldValue"> 이전 위치값</param>
		internal XSheetScrollPositionChangedEventArgs(int newValue, int oldValue)
		{
			this.newValue = newValue;
			this.oldValue = oldValue;
		}
	}
	#endregion

}
