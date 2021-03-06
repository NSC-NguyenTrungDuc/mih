using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XButtonCellEditor
	/// <summary>
	/// XButtonCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XButtonCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(CheckBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.ButtonBox;}
		}
		
		private XButton editor = null;
		/// <summary>
		/// 편집기의 편집컨트롤을 가져옵니다.
		/// </summary>
		public override IEditorControl Editor
		{
			get { return editor;}
		}
		#endregion
	
		#region 생성자
		/// <summary>
		/// XButtonCellEditor 생성자
		/// </summary>
		public XButtonCellEditor(XEditGridCell info)
		{
			editor = CreateEditor();
			editor.Name = info.CellName;
			editor.Text = info.ButtonText;
			editor.Scheme = info.ButtonScheme;
			editor.Image = info.ButtonImage;
			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// </summary>
		/// <returns> XButton 개체 </returns>
		protected virtual XButton CreateEditor()
		{
			return new XButton();
		}
		#endregion

		/// <summary>
		/// 편집을 시작합니다.
		/// </summary>
		/// <param name="editCell"> 편집하는 Cell 객체 </param>
		public override void StartEdit(XCell editCell)
		{
			this.Cell = editCell;
			if (this.Cell != null)
			{
				InnerStartEdit(editor);
				
				editor.Text = this.Cell.DisplayText;
				editor.Scheme = this.Cell.ButtonSheme;
				editor.Image = this.Cell.Image;
				editor.Font = this.Cell.Font;
				editor.Size = this.Cell.DisplayRectangle.Size;
				editor.Location = this.Cell.DisplayRectangle.Location;

				editor.Show();
				editor.BringToFront();
				editor.Focus();
			}
		}
		
		/// <summary>
		/// 편집값을 적용합니다.
		/// </summary>
		/// <returns> 적용성공시 true, 실패시 false </returns>
		public override bool ApplyEdit()
		{
			return true;
		}
		/// <summary>
		/// 편집기의 편집컨트롤의 Text를 Select합니다.
		/// </summary>
		public override void SelectText()
		{
			// SelectText 기능 없음
		}
	}
	#endregion
}
