using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XMemoCellEditor
	/// <summary>
	/// XMemoCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XMemoCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(FindBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.MemoBox;}
		}
		
		private XMemoBox editor = null;
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
		/// XMemoCellEditor 생성자
		/// </summary>
		public XMemoCellEditor(XEditGridCell info)
		{
			editor = CreateEditor();
			editor.Name = info.CellName;
			//Property SET
			editor.ClickHotKey = info.ClickHotKey;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			editor.MemoFormSize = info.MemoFormSize;
			editor.DisplayMemoText = info.DisplayMemoText;
			editor.MaxTextLength = info.CellLen;  //최대입력가능 길이를 CellLen으로 설정
			editor.ShowReservedMemoButton = info.ShowReservedMemoButton;
			editor.ReservedMemoFileName = info.ReservedMemoFileName;
			editor.ReservedMemoClassName = info.ReservedMemoClassName;
			editor.AppendReservedMemoText = info.AppendReservedMemoText;  //2006.02.09 예약글 Append 여부 추가
			//Text의 ImeMode 설정
			switch (info.ImeMode)
			{
				case ColumnImeMode.Eng:
				case ColumnImeMode.EngLower:
				case ColumnImeMode.EngUpper:
					editor.TextImeMode = ImeMode.Alpha;
					break;
				case ColumnImeMode.Han:
					editor.TextImeMode = ImeMode.Hangul;
					break;
				case ColumnImeMode.OnlyEng:
				case ColumnImeMode.OnlyEngLower:
				case ColumnImeMode.OnlyEngUpper:
					editor.TextImeMode = ImeMode.Disable;
					break;
				case ColumnImeMode.Hiragana:
					editor.TextImeMode = ImeMode.Hiragana;
					break;
				case ColumnImeMode.Katakana:
					editor.TextImeMode = ImeMode.Katakana;
					break;
				case ColumnImeMode.KatakanaHalf:
					editor.TextImeMode = ImeMode.KatakanaHalf;
					break;
			}

			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// (StandardControl에서 Customizing된 Control로 생성)
		/// </summary>
		/// <returns> AFindBox 개체 </returns>
		protected virtual XMemoBox CreateEditor()
		{
			return new XMemoBox();
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
				//Editor에 Value가 ""가 아니면 FullMemoImage, 아니면 EmptyMemoImage
				this.Cell.ImageAlignment = ContentAlignment.MiddleCenter;
				if (editor.GetDataValue() == "")
				{
					this.Cell.Image = XGridImage.EmptyMemo;
					this.Cell.DisplayText = "";
				}
				else
				{
					this.Cell.Image = XGridImage.FullMemo;
					//Text를 Display해야 하면 Image LeftAlign, Text는 가공하여 처리
					if (editor.DisplayMemoText)
					{
						this.Cell.ImageAlignment = ContentAlignment.MiddleLeft;
						int index = editor.GetDataValue().IndexOf('\n');
						if (index > 0)
							this.Cell.DisplayText = editor.GetDataValue().Substring(0, index) + "...";
						else
							this.Cell.DisplayText = editor.GetDataValue();
					}
				}
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
			//기능없음
		}

		#region DisplayMemoForm
		//MemoBox가 Grid의 Editor로 쓰일때 Grid Click시에 EditMode가 아니라도 MemoForm Display하기 위해 사용
		internal void DisplayMemoForm()
		{
			if (this.editor.Handle != IntPtr.Zero)
				User32.SendMessage(this.editor.Handle, (int) Win32.Msgs.WM_NCLBUTTONUP, 0,0);
		}
		#endregion
	}
	#endregion
}
