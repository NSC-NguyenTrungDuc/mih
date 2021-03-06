using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XComboCellEditor
	/// <summary>
	/// XComboCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XComboCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(ComboBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.ComboBox;}
		}
		
		private XDictComboBox editor = null;
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
		/// XComboCellEditor 생성자 
		/// </summary>
		public XComboCellEditor(XEditGridCell info, XEditGrid grid)
		{
			editor = CreateEditor();
			editor.Name = info.CellName;
			editor.DropDownStyle = info.DropDownStyle;
			editor.MaxDropDownItems = info.MaxDropDownItems;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			
			//콤보값 설정기준 자료사전 -> UserSQL -> ComboItems
            // TODO: remove later
			if ((info.SQLType == XComboSQLType.DictColumn) && (info.DictColumn.Trim() != ""))
			{
				editor.SQLType = info.SQLType;
				editor.CodeDisplay = info.CodeDisplay;
				editor.DictColumn = info.DictColumn;
			}
			else if ((info.SQLType == XComboSQLType.UserSQL) && (info.UserSQL.Trim() != ""))
			{
				//2005.11.28 DDLBSetting Event연결을 SQL설정전에 해야지 제대로 구동됨, Editor생성후에 처리함
				//XEditGrid의 SetBindVarValue 가 구동될 수 있도록 컬럼정보의 CellEditor를 설정함
				editor.DDLBSetting += new EventHandler(grid.EditGrid_DDLBSetting);
				info.CellEditor = this;

				editor.SQLType = info.SQLType;
			    editor.UserSQL = info.UserSQL;
			}
            
            if (info.ExecuteQuery != null)
            {
                editor.DDLBSetting += new EventHandler(grid.EditGrid_DDLBSetting);
                info.CellEditor = this;

                editor.SQLType = info.SQLType;
                editor.ExecuteQuery = info.ExecuteQuery;
                editor.SetDictDDLB();
            }
			else if (info.ComboItems.Count > 0)  //ComboItems로 SET
				editor.ComboItems.AddRange(info.ComboItems.ToArray());
			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// (StandardControl에서 Customizing된 Control로 생성)
		/// </summary>
		/// <returns> XDictComboBox 개체 </returns>
		protected virtual XDictComboBox CreateEditor()
		{
			return new XDictComboBox();
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
				InnerStartEdit(Editor);
				// Site에 따라 XDictComboBox를 쓰지않고, Site에 규격화된 XDictComboBox를 Editor로 써야함으로
				// 다른 Editor와 다르게 Editor Property를 이용하여 Setting해야함.
				editor.Font = this.Cell.Font;
				editor.Size = this.Cell.DisplayRectangle.Size;
				editor.Location = this.Cell.DisplayRectangle.Location;
				// DataValue설정시 SelectedIndexChanged Event는 발생하지 않게 처리
				editor.CallSelectedIndexChangedEvent = false;
				editor.Show();
				// Control Show후에 SelectedValue Set (Hide상태에서는 SelectedValue 정확히 반영되지 않음)
				editor.SetDataValue(this.Cell.Value);
				//Flag 복구
				editor.CallSelectedIndexChangedEvent = true;
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
			string displayText = string.Empty;
			try
			{
				if (editor.DropDownStyle == ComboBoxStyle.DropDown)
				{
					displayText = editor.Text;
				}
				else
				{
					//Cell의 DisplayText에 DisplayMembmer Set
					// Value = ValueItem임으로 이를 DisplayItem로 확인하여 Display
					foreach (XComboItem colItem in editor.ComboItems)
					{   
						if (colItem.ValueItem.Equals(Editor.DataValue.ToString()))
						{
							displayText = colItem.DisplayItem;
							break;
						}
					}
				}
				this.Cell.DisplayText = displayText;
				this.Cell.Value = Editor.DataValue;
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
			// ComboBox의 DropDownList가 아니면 SelectText
			if (((ComboBox)Editor).DropDownStyle != ComboBoxStyle.DropDownList)
				((ComboBox)Editor).SelectAll();
		}
	}
	#endregion
}
