using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XCheckCellEditor
	/// <summary>
	/// XCheckCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XCheckCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(CheckBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.CheckBox;}
		}
		
		private XCheckBox editor = null;
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
		/// XCheckCellEditor 생성자
		/// </summary>
		public XCheckCellEditor(XEditGridCell info)
		{
			editor = CreateEditor();
			editor.Name = info.CellName;
			editor.FlatStyle =	FlatStyle.Standard;
			editor.CheckedValue = info.CheckedValue;
			editor.CheckedText = info.CheckedText;
			editor.UnCheckedValue = info.UnCheckedValue;
			editor.UnCheckedText = info.UnCheckedText;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// (StandardControl에서 Customizing된 Control로 생성)
		/// </summary>
		/// <returns> XCheckBox 개체 </returns>
		protected virtual XCheckBox CreateEditor()
		{
			return new XCheckBox();
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
				// Size가 Border를 덮지 않도록 -1
				editor.Width --;
				editor.Height --;
				editor.Location = this.Cell.DisplayRectangle.Location;

				//CheckedText, UnCheckedText가 없으면 CheckAlign Center로, 있으면 Left로
				if ((editor.CheckedText == "") && (editor.UnCheckedText == ""))
					editor.CheckAlign = ContentAlignment.MiddleCenter;
				else
				{
					editor.CheckAlign = ContentAlignment.MiddleLeft;
					//Location 약간 우측으로 이동
					editor.Location = new Point(editor.Location.X + 2, editor.Location.Y);
					editor.Width -= 2;
				}

				editor.Show();
				// Control Show후에 DataValue반영(특정 Control의 경우 DataValue가 hide시에 정확히 반영되지 않음)
				// DataValue설정시 CheckedChanged Event는 발생하지 않게 처리
				editor.CallCheckedChangedEvent = false;
				editor.SetDataValue(this.Cell.Value);
				editor.CallCheckedChangedEvent = true;
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
				this.Cell.Value = editor.GetDataValue();
				//Value에 따라 Image SET
				if (editor.GetDataValue() == editor.CheckedValue)
				{
					this.Cell.Image = DrawHelper.CheckIcon;
					displayText = editor.CheckedText;
				}
				else
				{
					this.Cell.Image = DrawHelper.UnCheckIcon;
					displayText = editor.UnCheckedText;
				}
				this.Cell.DisplayText = displayText;
				//DisplayText가 있으면 Left, 없으면 Center
				if (displayText != "")
					this.Cell.ImageAlignment = ContentAlignment.MiddleLeft;
				else
					this.Cell.ImageAlignment = ContentAlignment.MiddleCenter;


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

		#region TogglingCheckState
		internal void TogglingCheckState()
		{
			//Click을 통해 Edit모드로 전환시에 Check상태 변경
			this.editor.Checked = !this.editor.Checked;
		}
		#endregion
	}
	#endregion
}
