using System;
using System.Drawing;

namespace IHIS.Framework
{
	/// <summary>
	/// XRowHeaderCell형 Cell class에 대한 요약설명입니다.
	/// </summary>
	public class XRowHeaderCell : XCell
	{
		/// <summary>
		/// Cell의 성격(Header)를 가져옵니다.
		/// </summary>
		public override XCellPersonality Personality
		{
			get { return XCellPersonality.RowHeader;}
		}
		/// <summary>
		/// XRowHeaderCell 생성자
		/// </summary>
		/// <param name="cellValue"> Cell의 값 </param>
		public XRowHeaderCell(object cellValue)
			:this(string.Empty, cellValue,XColor.XGridRowHeaderBackColor)
		{
		}
		/// <summary>
		/// XRowHeaderCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		public XRowHeaderCell(string cellName, object cellValue)
			:this(cellName, cellValue,XColor.XGridRowHeaderBackColor)
		{
		}
		/// <summary>
		/// XRowHeaderCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		/// <param name="headerBackColor"> Header의 Color(XColor 형식) </param>
		public XRowHeaderCell(string cellName, object cellValue, XColor headerBackColor):base(cellName, cellValue)
		{
			this.IsAddedHeader = false;  //추가된 Header 여부
			this.BackColor = headerBackColor;
		}
	}

}
