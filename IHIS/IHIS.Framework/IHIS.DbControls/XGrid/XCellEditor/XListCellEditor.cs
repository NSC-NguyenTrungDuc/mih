using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XListCellEditor
	/// <summary>
	/// XListCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XListCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(ListBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.ListBox;}
		}
		
		private XDictListBox editor = null;
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
		/// XListCellEditor 생성자 
		/// </summary>
		public XListCellEditor(XEditGridCell info, XEditGrid grid)
		{
			editor = CreateEditor();
			editor.Name = info.CellName;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			//콤보값 설정기준 자료사전 -> UserSQL -> ComboItems
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
			else if (info.ComboItems.Count > 0)  //ComboItems로 SET
				editor.ListItems.AddRange(info.ComboItems.ToArray());
			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// (StandardControl에서 Customizing된 Control로 생성)
		/// </summary>
		/// <returns> XDictListBox 개체 </returns>
		protected virtual XDictListBox CreateEditor()
		{
			return new XDictListBox();
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
				Rectangle rect = this.Cell.DisplayRectangle;
				Rectangle gridRect = Cell.Grid.Bounds;
				//Height를 ListItems의 갯수를 고려하여 설정(한 ListItem의 height는 19(MS UI Gothic 9.75Font일때)
				//동적으로 변환시킬까? (2는 Line선 고려 ScrollBar가 생기지 않도록)
				editor.Size = new Size(rect.Width , editor.ListItems.Count*19 + 2);

				//Location은 무조건 아래로 Display하지 않고, 아래로 Display했을때 Grid영역밖이면 위로 Display
//				if (rect.Y + editor.Size.Height <= gridRect.Height)
//					editor.Location = rect.Location;
//				else   //위로 Display
//					editor.Location = new Point(rect.X, rect.Bottom - editor.Size.Height);

				if (rect.Bottom + editor.Size.Height <= gridRect.Height)
					editor.Location = new Point(rect.X, rect.Bottom);
				else   //위로 Display
					editor.Location = new Point(rect.X, rect.Top - editor.Size.Height);
				
				//editor.Location = new Point(this.Cell.DisplayRectangle.X, this.Cell.DisplayRectangle.Bottom);
				
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
				foreach (XComboItem item in editor.ListItems)
				{
					if (item.ValueItem.Equals(editor.GetDataValue()))
					{
						displayText = item.DisplayItem;
						break;
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
			// XDistListBox는 기능없음
		}
	}
	#endregion
}
