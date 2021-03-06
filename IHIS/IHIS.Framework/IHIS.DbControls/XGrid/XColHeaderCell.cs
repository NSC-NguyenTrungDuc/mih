using System;
using System.Drawing;

namespace IHIS.Framework
{
	/// <summary>
	/// Grid의 Sort Mode를 나타내는 Enum입니다.
	/// </summary>
	internal enum XGridSortStatus
	{
		/// <summary>
		/// Sort 없음
		/// </summary>
		None = 0,
		/// <summary>
		/// Ascending
		/// </summary>
		Ascending = 1,
		/// <summary>
		/// Descending
		/// </summary>
		Descending = 2
	}

	/// <summary>
	/// ColumnHeader형 Cell class에 대한 요약설명입니다.
	/// </summary>
	public class XColHeaderCell : XCell
	{
		private XGridSortStatus sortStatus = XGridSortStatus.None;
		/// <summary>
		/// 현재 Sort상태 가져오거나 설정합니다.
		/// </summary>
		internal XGridSortStatus SortStatus
		{
			get { return sortStatus;}
			set { sortStatus = value;}
		}

		/// <summary>
		/// Cell의 성격(Header)를 가져옵니다.
		/// </summary>
		public override XCellPersonality Personality
		{
			get { return XCellPersonality.ColHeader;}
		}
		/// <summary>
		/// ColHeaderCell 생성자
		/// </summary>
		public XColHeaderCell() 
			:this(string.Empty, "", false, XColor.XGridColHeaderBackColor)
		{
		}
		/// <summary>
		/// ColHeaderCell 생성자
		/// </summary>
		/// <param name="cellValue"> Cell의 값 </param>
		public XColHeaderCell(object cellValue)
			:this(string.Empty, cellValue, false, XColor.XGridColHeaderBackColor)
		{
		}
		/// <summary>
		/// ColHeaderCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		public XColHeaderCell(string cellName, object cellValue)
			:this(cellName, cellValue, false, XColor.XGridColHeaderBackColor)
		{
		}
		/// <summary>
		/// ColHeaderCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		/// <param name="isAddedHeader"> 추가된 Header 여부 </param>
		public XColHeaderCell(string cellName, object cellValue, bool isAddedHeader)
			:this(cellName, cellValue, isAddedHeader, XColor.XGridColHeaderBackColor)
		{
		}
		/// <summary>
		/// ColHeaderCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		/// <param name="isAddedHeader"> 추가된 Header여부 </param>
		/// <param name="headerBackColor"> Header의 Color(XColor 형식) </param>
		public XColHeaderCell(string cellName, object cellValue, bool isAddedHeader, XColor headerBackColor):base(cellName, cellValue)
		{
			this.IsAddedHeader = isAddedHeader;  //추가된 Header 여부
			this.DrawMode  = XCellDrawMode.Vertical;
			this.BackColor = headerBackColor;
			this.ForeColor = XColor.XGridColHeaderForeColor;
			this.Click += new EventHandler(HeaderCell_Click);
			this.DoubleClick += new EventHandler(HeaderCell_DoubleClick);
		}
		private void HeaderCell_DoubleClick(object sender, EventArgs e)
		{
			if (!this.IsDesignMode) //DesignMode가 아닐때
			{
				//Grid의 SortMode가 Double Click일때 적용 (추가 Header가 아니면)
				if ((this.Grid.SortMode == XGridSortMode.DoubleClick) && !this.IsAddedHeader)
				{
					if (sortStatus == XGridSortStatus.Ascending)
						SortColumn(false, this.CellName);
					else
						SortColumn(true, this.CellName);
				}
			}
		}
		private void HeaderCell_Click(object sender, EventArgs e)
		{
			if (!this.IsDesignMode) //DesignMode가 아닐때
			{
				//Grid의 SortMode가 Click일때 적용 (추가 Header가 아니면)
				if ((this.Grid.SortMode == XGridSortMode.SingleClick) && !this.IsAddedHeader)
				{
					if (sortStatus == XGridSortStatus.Ascending)
						SortColumn(false, this.CellName);
					else
						SortColumn(true, this.CellName);
				}
			}
		}
		private void SortColumn(bool isAsc, string cellName)
		{
			if (Grid !=null && Grid.Rows> (Row+1) && Grid.Cols > Grid.FixedCols)
			{
				if (Grid.SortRangeRows(isAsc, cellName))
				{
					//SortImage SET
					if (isAsc)
					{
						this.SortStatus = XGridSortStatus.Ascending;
						this.SortImage = XGridImage.SortUpIcon;  //SortUp
					}
					else
					{
						this.SortStatus = XGridSortStatus.Descending;
						this.SortImage = XGridImage.SortDownIcon;  //SortDown
					}
					// 다른 Header의 SortMode None으로 Clear
					for (int i = 0; i < Grid.LinePerRow + Grid.AddedHeaderLine ; i++)
						for (int j = 0; j < Grid.Cols ; j++)
							if ((Grid[i,j] != null) && (Grid[i,j] != this) && (Grid[i,j] is XColHeaderCell))
							{
								((XColHeaderCell)Grid[i,j]).SortStatus = XGridSortStatus.None;
								Grid[i,j].SortImage = null;
							}
				}
			}
		}
	}

}
