using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XDatePickerCellEditor
	/// <summary>
	/// XDatePickerCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XDatePickerCellEditor : XCellEditorBase
	{
		#region Properties
		private XEditGridCell cellInfo = null;
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(DatePicker형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.DatePicker;}
		}
		
		private XDatePicker editor = null;
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
		/// XDatePickerCellEditor 생성자
		/// </summary>
		public XDatePickerCellEditor(XEditGridCell info)
		{
			cellInfo = info;
			editor = CreateEditor();
			//Property SET
			editor.ClickHotKey = info.ClickHotKey;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			editor.IsJapanYearType = info.IsJapanYearType;
			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// </summary>
		/// <returns> ADatePicker 개체 </returns>
		protected virtual XDatePicker CreateEditor()
		{
			return new XDatePicker();
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
				//2006.01.06 Invalid할 경우에 cellInfo의 InvalidDateIsStringEmpty 속성에 따라 
				//DisplayText설정, true이면 ""로 반영, false이면 NullText 반영
				if (cellInfo.InvalidDateIsStringEmpty)
				{
					if (this.Cell.Value.ToString() == "")
						this.Cell.DisplayText = "";
					else
						this.Cell.DisplayText = editor.Text;
				}
				else
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
