using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XCellEditorBase
	/// <summary>
	/// CellEditorBase에 대한 요약설명입니다.
	/// </summary>
	public abstract class XCellEditorBase : ICellEditor
	{
		#region Properties
		private XCell cell = null;
		/// <summary>
		/// 편집기와 연결된 Cell을 가져오거나 설정합니다.
		/// </summary>
		public XCell Cell
		{
			get { return cell;}
			set { cell = value;}
		}
		/// <summary>
		/// 편집기의 Style을 가져옵니다.
		/// </summary>
		public virtual XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.EditBox;}
		}
		
		private IEditorControl editor = null;
		/// <summary>
		/// 편집기의 편집컨트롤을 가져옵니다.
		/// </summary>
		public virtual IEditorControl Editor
		{
			get { return editor;}
		}

		private bool isEditing = false;
		/// <summary>
		/// 편집중여부를 가져옵니다.
		/// </summary>
		public bool IsEditing
		{
			get { return isEditing;}
		}
		#endregion
	
		#region 생성자
		/// <summary>
		/// XCellEditorBase 생성자 
		/// </summary>
		public XCellEditorBase()
		{
		}
		#endregion
	
		#region Protected Method
		/// <summary>
		/// ContextAlignment형을 HorizontalAlignment로 변환합니다.
		/// </summary>
		/// <param name="align"> ContextAlignment </param>
		/// <returns> HorizontalAlignment </returns>
		protected HorizontalAlignment GetTextAlign(ContentAlignment align)
		{
			if (align.ToString().IndexOf("Center") >= 0)
				return HorizontalAlignment.Center;
			else if (align.ToString().IndexOf("Left") >= 0)
				return HorizontalAlignment.Left;
			else if (align.ToString().IndexOf("Right") >= 0)
				return HorizontalAlignment.Right;
			else
				return HorizontalAlignment.Left;
		}
		/// <summary>
		/// 편집시작시 편집컨트롤을 Grid에 Bind합니다.
		/// </summary>
		/// <param name="control"> 편집컨트롤 </param>
		protected virtual void InnerStartEdit(IEditorControl control)
		{
//			if (cell != null)
//			{
//				InnerRemoveControl();
//				editor = control;
//				try
//				{
//					cell.Grid.Controls.Add((Control)editor);
//				}
//				catch{}
//			}

			if (cell != null)
			{
				editor = control;
				try
				{
					//Editor Control을 Grid에 Add
					if (!cell.Grid.Controls.Contains((Control)editor))
						cell.Grid.Controls.Add((Control)editor);

				}
				catch{}
			}
		}
		/// <summary>
		/// 편집종료시 편집컨트롤을 Grid에서 제거합니다.
		/// </summary>
		protected virtual void InnerRemoveControl()
		{
//			try
//			{
//				if (cell != null)
//				{
//					// Control Hide 
//					((Control)editor).Hide();
//					// Remove후에도 Grid에서 계속 Focus 유지
//					if (cell.Grid != null)
//					{
//						cell.Grid.SetFocusOnCellsContainer();
//						cell.Grid.Controls.Remove((Control)editor);
//					}
//				}
//			}
//			catch{}

			try
			{
				if (cell != null)
				{
					// Control Hide (Size, Location도 조정하여 다시 StartEdit시에 다시 조정)
					//Size와 Location을 조정하지 않으면 StartEdit시에 Editor의 위치가 Cell과 일치않는 Case가 발생함.
					((Control)editor).Hide();
					((Control)editor).Size = new Size(0, ((Control)editor).Height);
					((Control)editor).Location = new Point(0,0);
					
				}
			}
			catch(Exception xe)
			{
				Debug.WriteLine("CellEditorBase::InnerRemoveControl Error=" + xe.Message);
			}
		}
		#endregion

		#region Public Method
		/// <summary>
		/// 편집을 시작합니다.
		/// </summary>
		/// <param name="editCell"> 편집하는 Cell 객체 </param>
		public abstract void StartEdit(XCell editCell);

		/// <summary>
		/// 편집값을 적용합니다.
		/// </summary>
		/// <returns> 적용성공시 true, 실패시 false </returns>
		public abstract bool ApplyEdit();
		/// <summary>
		/// 편집기의 편집컨트롤의 Text를 Select합니다.
		/// </summary>
		public abstract void SelectText();

		/// <summary>
		/// 편집을 종료합니다.
		/// </summary>
		/// <param name="cancel"> 편집값 미적용여부 </param>
		/// <returns> 편집종료 성공시 true, 실패시 false </returns>
		public virtual bool EndEdit(bool cancel)
		{
			bool isSuccess = true;
			if (!cancel)
			{
				isSuccess = ApplyEdit();
			}
			// 성공이면 Control제거
			if (isSuccess)
				InnerRemoveControl();

			return isSuccess;
		}
		#endregion
	}
	#endregion
}
