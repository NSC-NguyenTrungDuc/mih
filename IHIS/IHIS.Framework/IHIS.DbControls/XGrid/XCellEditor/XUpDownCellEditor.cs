using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XUpDownCellEditor
	/// <summary>
	/// XUpDownCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XUpDownCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(UpDownBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.UpDownBox;}
		}
		
		private XNumericUpDown editor = null;
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
		/// XUpDownCellEditor 생성자
		/// </summary>
		public XUpDownCellEditor(XEditGridCell info)
		{
			editor = CreateEditor();
			editor.Name = info.CellName;
			editor.Increment = Decimal.Parse(info.Increment.ToString());
			editor.Maximum = Decimal.Parse(info.Maxinum.ToString());
			editor.Minimum = Decimal.Parse(info.Mininum.ToString());
			editor.DecimalPlaces = info.DecimalDigits;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// (StandardControl에서 Customizing된 Control로 생성)
		/// </summary>
		/// <returns> XNumericUpDown 개체 </returns>
		protected virtual XNumericUpDown CreateEditor()
		{
			return new XNumericUpDown();
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

				editor.Font = this.Cell.Font;
				editor.Size = this.Cell.DisplayRectangle.Size;
				editor.TextAlign = GetTextAlign(this.Cell.TextAlignment);
				editor.Location = this.Cell.DisplayRectangle.Location;
				editor.Show();
				// Control Show후에 DataValue반영(특정 Control의 경우 DataValue가 hide시에 정확히 반영되지 않음)
				// DataValue설정시 ValueChanged Event는 발생하지 않게 처리
				editor.CallValueChangedEvent = false;
				editor.SetDataValue(this.Cell.Value.ToString());
				editor.CallValueChangedEvent = true;
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
			bool isSuccess = true;
			try
			{
				this.Cell.Value = editor.GetDataValue();
				//DisplayText Set
				this.Cell.DisplayText = editor.Text;
			}
			catch
			{
				isSuccess = false;
			}
			return isSuccess;

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
