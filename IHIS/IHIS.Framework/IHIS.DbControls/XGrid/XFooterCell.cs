using System;
using System.Drawing;

namespace IHIS.Framework
{
	/// <summary>
	/// XFooterCell형 Cell class에 대한 요약설명입니다.
	/// </summary>
	public class XFooterCell : XCell
	{
		private Font cellFont = new Font(FontFamily.GenericSansSerif, 6.0f, FontStyle.Regular);

		/// <summary>
		/// Cell의 성격(Header)를 가져옵니다.
		/// </summary>
		public override XCellPersonality Personality
		{
			get { return XCellPersonality.Footer;}
		}
		/// <summary>
		/// XFooterCell 생성자
		/// </summary>
		/// <param name="cellValue"> Cell의 값 </param>
		public XFooterCell(object cellValue)
			:this(string.Empty, cellValue,XColor.XGridFooterCellBackColor)
		{
		}
		/// <summary>
		/// XFooterCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		public XFooterCell(string cellName, object cellValue)
			:this(cellName, cellValue,XColor.XGridFooterCellBackColor)
		{
		}
		/// <summary>
		/// XFooterCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 Name </param>
		/// <param name="cellValue"> Cell의 값 </param>
		/// <param name="bandColor"> Band의 Color(XColor 형식) </param>
		public XFooterCell(string cellName, object cellValue, XColor bandColor):base(cellName, cellValue)
		{
			this.IsAddedHeader = false;  //추가된 Header 여부
			this.TextAlignment = ContentAlignment.MiddleLeft;
			this.BackColor = bandColor;
			this.Font = cellFont;
		}
	}

}
