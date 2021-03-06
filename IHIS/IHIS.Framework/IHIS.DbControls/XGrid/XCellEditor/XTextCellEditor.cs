using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace IHIS.Framework
{
	#region XTextCellEditor
	/// <summary>
	/// XTextCellEditor에 대한 요약설명입니다.
	/// </summary>
	public class XTextCellEditor : XCellEditorBase
	{
		#region Properties
		/// <summary>
		/// 편집기의 Style을 가져옵니다.(EditBox형)
		/// </summary>
		public override XCellEditorStyle EditorStyle
		{
			get { return XCellEditorStyle.EditBox;}
		}
		
		private XEditMask editor = null;
		private XEditGridCell cellInfo = null;
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
		/// TextCellEditor 생성자
		/// </summary>
		/// <param name="info"> 컬럼정보 </param>
		public XTextCellEditor(XEditGridCell info)
		{
			this.cellInfo = info;
			editor = CreateEditor();
			editor.SetByteCheckMode(false); //Validating시에 Byte단위 길이 Check하지 않음
			editor.Name = info.CellName;
			editor.DecimalDigits = info.DecimalDigits;
			editor.GeneralNumberFormat = info.GeneralNumberFormat;
			editor.MinusAccept = info.MinusAccept;
			editor.MaxinumCipher = info.MaxinumCipher;
			editor.EnterKeyToTab = info.EnterKeyToTab;
			editor.EditMaskType = (MaskType) Enum.Parse(typeof(MaskType), Enum.GetName(typeof(XCellDataType), info.CellType));
				
			// Mask가 없으면 MaxLength Set(Collen만큼만 입력가능) 있으면 Mask까지만 입력가능
			if (info.CellType == XCellDataType.String)
			{
				if (info.Mask.Trim() == "")
					editor.MaxLength = info.CellLen;
				//PasswordChar Set
				if (info.PasswordChar != (char) 0)
					editor.PasswordChar = info.PasswordChar;
			}

			//ImeMode,CharaterCasting Set (Numeric,Date형은 ImeMode.Disable, String은 info.ImeMode에 따라
			switch(info.CellType)
			{
				case XCellDataType.Date:
				case XCellDataType.DateTime:
				case XCellDataType.Time:
				case XCellDataType.Decimal:
				case XCellDataType.Number:
				case XCellDataType.Month:
					editor.ImeMode = ImeMode.Disable;
					break;
				case XCellDataType.String:
					// 영문만 가능시 Disable
					if ((info.ImeMode == ColumnImeMode.OnlyEng) ||(info.ImeMode == ColumnImeMode.OnlyEngUpper)||(info.ImeMode == ColumnImeMode.OnlyEngLower))
						editor.ImeMode = ImeMode.Disable;
					else if (info.ImeMode == ColumnImeMode.Han)
					{
						editor.ImeMode = ImeMode.Hangul;
						editor.AccessibleName = "Hangul";  // GotFocus시 ImeMode다시 설정필요
					}
					else if ((info.ImeMode == ColumnImeMode.Eng)||(info.ImeMode == ColumnImeMode.EngUpper)||(info.ImeMode == ColumnImeMode.EngLower))
					{
						editor.ImeMode = ImeMode.Alpha;
						editor.AccessibleName = "Alpha"; // GotFocus시 ImeMode다시 설정필요
					}
					else if (info.ImeMode == ColumnImeMode.Hiragana)
					{
						editor.ImeMode = ImeMode.Hiragana;
						editor.AccessibleName = "Hiragana";
					}
					else if (info.ImeMode == ColumnImeMode.Katakana)
					{
						editor.ImeMode = ImeMode.Katakana;
						editor.AccessibleName = "Katakana";
					}
					else if (info.ImeMode == ColumnImeMode.KatakanaHalf)
					{
						editor.ImeMode = ImeMode.KatakanaHalf;
						editor.AccessibleName = "KatakanaHalf";
					}

					// CharacterCasting Set
					if ((info.ImeMode == ColumnImeMode.EngUpper)||(info.ImeMode == ColumnImeMode.OnlyEngUpper))
						editor.CharacterCasing = CharacterCasing.Upper;
					else if ((info.ImeMode == ColumnImeMode.EngLower)||(info.ImeMode == ColumnImeMode.OnlyEngLower))
						editor.CharacterCasing = CharacterCasing.Lower;
					else
						editor.CharacterCasing = CharacterCasing.Normal;
					break;
				default:
					break;
			}
			editor.Mask = info.Mask;
			//Date,Time,DateTime이 Mask가 없을 경우에는 Default Mask SET
			if (info.Mask == "")
			{
				if (info.CellType == XCellDataType.Date)
					editor.Mask = MaskHelper.CDateDefaultMask;
				else if (info.CellType == XCellDataType.DateTime)
					editor.Mask = MaskHelper.CDateTimeDefaultMask;
				else if (info.CellType == XCellDataType.Time)
					editor.Mask = MaskHelper.CTimeDefaultMask;
				else if (info.CellType == XCellDataType.Month)
					editor.Mask = MaskHelper.CMonthDefaultMask;
			}

			//2005.12.01 일본연호 표기 반영(Date,Month형만 가능)
			if ((info.CellType == XCellDataType.Date) || (info.CellType == XCellDataType.Month))
				editor.IsJapanYearType = info.IsJapanYearType;
			else  //그외는 false
				editor.IsJapanYearType = false;

			editor.Hide();
		}
		/// <summary>
		/// Editor에 사용할 Control을 생성합니다.
		/// (StandardControl에서 Customizing된 Control로 생성)
		/// </summary>
		/// <returns> IcmEditMask 개체 </returns>
		protected virtual XEditMask CreateEditor()
		{
			return new XEditMask();
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
				//Decimal형은 DecimalDigits에 관계없이 값을 Display, DBNull-> string.Empty, 
				//Digits가 3이더라도 1.1 -> 1.100으로 보여주지 않고, 1.1로 Display함
				//DisplayText Set
				//2006.03.13 ShowZeroDecimal의 속성에 따라 Digits 보여줄지 여부를 결정. true이면 1 -> 1.00형태로 보여줌
				if (this.cellInfo.CellType == XCellDataType.Decimal)
				{
					this.Cell.DisplayText = MaskHelper.GetDisplayText(MaskType.Decimal, cellInfo.MaskSymbols, cellInfo.DecimalDigits, cellInfo.GeneralNumberFormat, editor.GetDataValue(), cellInfo.ShowZeroDecimal);
				}
				else
				{
					//2006.01.06 Date,DateTime,Month, Time형은 Invalid할 경우에 cellInfo의 InvalidDateIsStringEmpty 속성에 따라 
					//DisplayText설정, true이면 ""로 반영, false이면 NullText 반영
					if ((cellInfo.CellType == XCellDataType.Date) || (cellInfo.CellType == XCellDataType.DateTime)
						||(cellInfo.CellType == XCellDataType.Month)||(cellInfo.CellType == XCellDataType.Time))
					{
						if (cellInfo.InvalidDateIsStringEmpty)
						{
							if (this.Cell.Value.ToString() == "")
								this.Cell.DisplayText = "";
							else
							{
								//2006.05.20 일본연호 형식의 Date형일때는 연호가 겹치는 년도에 잘못 날짜를 입력한 경우
								//사용자 편의를 위해 JapanYearHelper.GetDataValue에서 유효한 날짜로 Return하므로
								//여기서도 editor.Text로 받지 않고, 
								if (cellInfo.IsJapanYearType && (cellInfo.CellType == XCellDataType.Date))
									this.Cell.DisplayText = JapanYearHelper.GetDisplayText(MaskType.Date, Cell.Value);
								else
									this.Cell.DisplayText = editor.Text;
							}

						}
						else
						{
							//2006.05.20 일본연호 형식의 Date형일때는 연호가 겹치는 년도에 잘못 날짜를 입력한 경우
							//사용자 편의를 위해 JapanYearHelper.GetDataValue에서 유효한 날짜로 Return하므로
							//여기서도 editor.Text로 받지 않고, 
							if (cellInfo.IsJapanYearType && (cellInfo.CellType == XCellDataType.Date))
								this.Cell.DisplayText = JapanYearHelper.GetDisplayText(MaskType.Date, Cell.Value);
							else
								this.Cell.DisplayText = editor.Text;
						}

					}
					else
					{
						//2006.03.31 PasswordChar 적용, editor.Text가 PasswordChar가 적용되지 않은 것이 들어옴
						if (cellInfo.PasswordChar != (char) 0)
							this.Cell.DisplayText = "".PadLeft(editor.Text.Length, cellInfo.PasswordChar);
						else
							this.Cell.DisplayText = editor.Text;
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
			editor.SelectAll();
		}

	}
	#endregion
}
