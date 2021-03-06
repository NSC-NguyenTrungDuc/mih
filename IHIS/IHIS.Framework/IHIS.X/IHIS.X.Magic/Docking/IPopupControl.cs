using System;

namespace IHIS.X.Magic.Docking
{
	/// <summary>
	/// IPopupControl Interface에 대한 요약 설명입니다.
	/// </summary>
	public interface IPopupControl
	{
		/*IPopupControl은 Docking되는 화면이나 Form에 사용되는 Control중에서 Popup형태로 다른 창을 띄우는
		 * Control (ex : XMemoBox, XFindBox, XDateTimePicker, XDatePicker...)에서 이 Interface를 상속받는다.
		 * Docking::AutoHidePanel에서는 Docking된 화면이나 Form (Content)에 있는 모든 Control의 GotFocus와
		 * LostFocus를 Event Handling하여 (AutoHidePanel::MonitorControl Method에서) Focus를 잃을때 Docking된
		 * Content가 자동숨기기 상태이면 닫히도록 처리한다. 
		 * (Content의 상태는 크게 고정된 형태, 자동숨기기형태, Floating형태로 가능한데, 고정된상태나 Floating상태
		 * 에서는 Focus를 잃는다고해서 자동으로 숨겨지는 것은 아니다)
		 * 그런데, Popup창을 띄우는 Control의 경우 Popup창이 Focus를 받으면서 해당 Control의 LostFocus가 발생하게
		 * 되어 자동숨기기상태에서 화면(Content)가 닫히게 된다.
		 * 이를 방지하기 위해 Popup창을 띄우는 Control의 경우 이 interface를 상속받게하고, 
		 * AutoHidePanel::MonitorControl Method에서 Control이 IPopupControl이 아닌 경우에만 GotFocus와 LostFocus
		 * Event를 Handling하게 한다 */
	}
}
