using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XFindCellEditor
	/// <summary>
	/// XFindCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XFindCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(FindBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.FindBox;}
		}
		
		private XFindBox editor = null;
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
		/// XFindCellEditor 생성자
		/// </summary>
		public XFindCellEditor(XEditGridCell info)
		{
			editor = CreateEditor();
			editor.SetByteCheckMode(false); //Validating시에 Byte단위 길이 Check하지 않음
			editor.Name = info.CellName;
			//Property SET
			editor.FindWorker = info.FindWorker;
			editor.MaxLength = info.CellLen;
			editor.DataIndex = info.DataIndex;
			editor.ClickHotKey = info.ClickHotKey;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			editor.AutoTabDataSelected = info.AutoTabDataSelected;
			//IME Mode 설정
			// 영문만 가능시 Disable
			if ((info.ImeMode == ColumnImeMode.OnlyEng) ||(info.ImeMode == ColumnImeMode.OnlyEngUpper)||(info.ImeMode == ColumnImeMode.OnlyEngLower))
				editor.ImeMode = ImeMode.Disable;
			else if (info.ImeMode == ColumnImeMode.Han)
				editor.ImeMode = ImeMode.Hangul;
			else if ((info.ImeMode == ColumnImeMode.Eng)||(info.ImeMode == ColumnImeMode.EngUpper)||(info.ImeMode == ColumnImeMode.EngLower))
				editor.ImeMode = ImeMode.Alpha;
			else if (info.ImeMode == ColumnImeMode.Hiragana)
				editor.ImeMode = ImeMode.Hiragana;
			else if (info.ImeMode == ColumnImeMode.Katakana)
				editor.ImeMode = ImeMode.Katakana;
			else if (info.ImeMode == ColumnImeMode.KatakanaHalf)
				editor.ImeMode = ImeMode.KatakanaHalf;

			// CharacterCasting Set
			if ((info.ImeMode == ColumnImeMode.EngUpper)||(info.ImeMode == ColumnImeMode.OnlyEngUpper))
				editor.CharacterCasing = CharacterCasing.Upper;
			else if ((info.ImeMode == ColumnImeMode.EngLower)||(info.ImeMode == ColumnImeMode.OnlyEngLower))
				editor.CharacterCasing = CharacterCasing.Lower;
			else
				editor.CharacterCasing = CharacterCasing.Normal;

			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// (StandardControl에서 Customizing된 Control로 생성)
		/// </summary>
		/// <returns> XFindBox 개체 </returns>
		protected virtual XFindBox CreateEditor()
		{
			return new XFindBox();
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
				editor.Location = this.Cell.DisplayRectangle.Location;
				editor.SelectAll();
				editor.Show();
				// Control Show후 DataValue반영(특정 Control(ComboBox)의 경우 DataValue가 hide시에 정확히 반영되지 않음)
				editor.SetDataValue(this.Cell.Value);
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
			editor.SelectAll();
		}
	}
	#endregion
}
