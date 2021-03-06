using System;
using System.Windows.Forms;

namespace IHIS.Framework
{
	#region ICellEditor
	/// <summary>
	/// ICellEditor에 대한 요약설명입니다.
	/// </summary>
	public interface ICellEditor
	{
		/// <summary>
		/// 편집기와 연결된 Cell을 가져오거나 설정합니다.
		/// </summary>
		XCell Cell{ get; set;}
		/// <summary>
		/// 편집기의 Style을 가져옵니다.
		/// </summary>
		XCellEditorStyle EditorStyle { get;}
		/// <summary>
		/// 편집기의 편집컨트롤을 가져옵니다.
		/// </summary>
		IEditorControl Editor { get ; }
		/// <summary>
		/// 편집중여부를 가져옵니다.
		/// </summary>
		bool IsEditing { get ;}

		/// <summary>
		/// 편집을 시작합니다.
		/// </summary>
		/// <param name="editCell"> 편집하는 Cell 객체 </param>
		void StartEdit(XCell editCell);

		/// <summary>
		/// 편집값을 적용합니다.
		/// </summary>
		/// <returns> 적용성공시 true, 실패시 false </returns>
		bool ApplyEdit();

		/// <summary>
		/// 편집을 종료합니다.
		/// </summary>
		/// <param name="cancel"> 편집값 미적용여부 </param>
		/// <returns> 편집종료 성공시 true, 실패시 false </returns>
		bool EndEdit(bool cancel);
		/// <summary>
		/// 편집기의 편집컨트롤의 Text를 Select합니다.
		/// </summary>
		void SelectText();

	}
	#endregion
}
