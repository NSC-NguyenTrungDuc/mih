using System;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// IReservedMemoControl에 대한 요약 설명입니다.
	/// 예약글 Control을 만들때 구현해야할 Interface입니다.
	/// </summary>
	public interface IReservedMemoControl
	{
		/// <summary>
		/// 선택된 데이타를 가져옵니다.
		/// </summary>
		string	SelectedData { get;}
		/// <summary>
		/// 예약글 Control Load시 전달된 Parameter를 가져오거나 설정합니다.
		/// </summary>
		object	LoadParam	{ get; set;}
		/// <summary>
		/// 예약글 창에 있는 OKButton을 가져오거나 설정합니다.
		/// </summary>
		IButtonControl OKButton { get; set;}
		/// <summary>
		/// 예약글 창에 있는 CancelButton을 가져오거나 설정합니다.
		/// </summary>
		IButtonControl CancelButton { get; set;}
	}
}
