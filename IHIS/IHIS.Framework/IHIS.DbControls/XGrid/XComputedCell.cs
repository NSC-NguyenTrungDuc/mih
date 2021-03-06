using System;
using System.Drawing;

namespace IHIS.Framework
{
	/// <summary>
	/// XComputedCell에 대한 요약설명입니다.
	/// </summary>
	public sealed class XComputedCell : XCell
	{
		/// <summary>
		/// Cell의 성격(Compute)을 가져옵니다.
		/// </summary>
		public override XCellPersonality Personality
		{
			get { return XCellPersonality.Compute;}
		}
		/// <summary>
		/// XComputedCell 생성자
		/// </summary>
		/// <param name="cellName"> Cell의 이름 </param>
		/// <param name="Value"> Cell의 값 </param>
		public XComputedCell(string cellName, object Value)
			:base(cellName, Value) 
		{
			this.TextAlignment = ContentAlignment.MiddleRight;  //Middle Right default
			this.BackColor = XColor.XGridComputedCellBackColor;
		}
	}

}
