using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IHIS.Framework
{

	#region IXScreen
	/// <summary>
	/// IXScreen에 대한 요약 설명입니다.
	/// </summary>
	public interface IXScreen
	{
		/// <summary>
		/// 특정 Command명으로 commandParam을 전달하여 명령을 실행합니다.
		/// </summary>
		/// <param name="command"> Command 명 </param>
		/// <param name="commandParam"> Argument를 관리하는 CommonItemCollection </param>
		/// <returns> object </returns>
		object Command(string command, CommonItemCollection commandParam);

		/// <summary>
		/// 화면에 있는 편집중인 값 Accept
		/// </summary>
		/// <returns></returns>
		bool AcceptData();
		
		/// <summary>
		/// 화면에 있는 DataControl의 값 Reset
		/// </summary>
		void Reset();

		/// <summary>
		/// 화면 활성화
		/// </summary>
		void Activate();

		/// <summary>
		/// 화면이 닫히는 동안 발생하는 Event
		/// </summary>
		event CancelEventHandler Closing;

		// <summary>
		/// 화면이 닫히는 조건 검사
		/// </summary>
		/// <returns></returns>
		bool CanClose();

	}
	#endregion

}
