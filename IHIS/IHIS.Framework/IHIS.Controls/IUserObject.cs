using System;
using System.ComponentModel;

namespace IHIS.Framework
{
	/// <summary>
	/// IUserObject Interface
	/// </summary>
	public interface IUserObject
	{
		/// <summary>
		/// Control Binding 허용여부를 가져옵니다.
		/// </summary>
		[Description("Control Binding 허용여부를 지정합니다.")]
		bool		AllowBindControls { get; }
		/// <summary>
		/// Member변수 Binding 허용여부를 가져옵니다.
		/// </summary>
		[Description("Member변수 Binding 허용여부를 지정합니다.")]
		bool		AllowBindVariables { get; }

		/// <summary>
		/// LayoutContainer의 Reset을 적용할지 여부를 지정합니다.
		/// true이면 XScreen, XForm의 Reset 호출시에 Reset되고, false이면 Reset하지 않습니다.
		/// </summary>
		bool ApplyLayoutContainerReset { get; set;}

		/// <summary>
		/// UserObject를 초기화합니다.
		/// </summary>
		void Reset();
	}
}
