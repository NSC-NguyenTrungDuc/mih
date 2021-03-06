using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.Runtime.InteropServices;

namespace IHIS.Framework
{
	/// <summary>
	/// XDataGrid에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	[DefaultProperty("TableStyles")]
	[DefaultEvent("GridColumnChanged")]
	public class XDataGrid : System.Windows.Forms.DataGrid, System.ComponentModel.ISupportInitialize
	{
		#region Class Variables
		internal DataGridCell ErrorCell;  // Validation Error가 발생한 Cell
		private int headerHeight = 0;
		private int preRowNumer = 0;  // 이전 행번호
		private DataTable gridTable = null;
		private string tableName = string.Empty; //DataSource로 지정한 DataTable의 이름
		//Color 정의
		private XColor xAlternatingBackColor	= XColor.XDataGridAlternatingBackColor;
		private XColor xBackColor			= XColor.XDataGridBackColor;
		private XColor xForeColor			= XColor.XDataGridForeColor;
		private XColor xBackgroundColor		= XColor.XDataGridBackgroundColor;
		private XColor xCaptionBackColor	= XColor.XDataGridCaptionBackColor;
		private XColor xCaptionForeColor	= XColor.XDataGridCaptionForeColor;
		private XColor xGridLineColor		= XColor.XDataGridLineColor;
		private XColor xHeaderBackColor		= XColor.XDataGridHeaderBackColor;
		private XColor xHeaderForeColor		= XColor.XDataGridHeaderForeColor;
		private XColor xLinkColor			= XColor.XDataGridLinkColor;
		private XColor xParentRowsBackColor = XColor.XDataGridParentRowsBackColor;
		private XColor xParentRowsForeColor = XColor.XDataGridParentRowsForeColor;
		private XColor xSelectionBackColor	= XColor.XDataGridSelectionBackColor;
		private XColor xSelectionForeColor	= XColor.XDataGridSelectionForeColor;
		#endregion

		#region Base Property
		[DefaultValue(typeof(XColor),"XDataGridAlternatingBackColor"),
		Description("교대로 반복되는 행의 배경색을 지정합니다.")]
		public new XColor AlternatingBackColor
		{
			get { return xAlternatingBackColor;}
			set 
			{
				xAlternatingBackColor = value;
				base.AlternatingBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridBackColor"),
		Description("행의 배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridBackgroundColor"),
		Description("Grid의 배경색을 지정합니다.")]
		public new XColor BackgroundColor
		{
			get { return xBackgroundColor;}
			set 
			{
				xBackgroundColor = value;
				base.BackgroundColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridCaptionBackColor"),
		Description("Caption의 배경색을 지정합니다.")]
		public new XColor CaptionBackColor
		{
			get { return xCaptionBackColor;}
			set 
			{
				xCaptionBackColor = value;
				base.CaptionBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridCaptionForeColor"),
		Description("Caption의 텍스트색을 지정합니다.")]
		public new XColor CaptionForeColor
		{
			get { return xCaptionForeColor;}
			set 
			{
				xCaptionForeColor = value;
				base.CaptionForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridForeColor"),
		Description("행의 텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridLineColor"),
		Description("라인의 색을 지정합니다.")]
		public new XColor GridLineColor
		{
			get { return xGridLineColor;}
			set 
			{
				xGridLineColor = value;
				base.GridLineColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridHeaderBackColor"),
		Description("헤더의 배경색을 지정합니다.")]
		public new XColor HeaderBackColor
		{
			get { return xHeaderBackColor;}
			set 
			{
				xHeaderBackColor = value;
				base.HeaderBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridHeaderForeColor"),
		Description("헤더의 텍스트색을 지정합니다.")]
		public new XColor HeaderForeColor
		{
			get { return xHeaderForeColor;}
			set 
			{
				xHeaderForeColor = value;
				base.HeaderForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridLinkColor"),
		Description("Link시 색을 지정합니다.")]
		public new XColor LinkColor
		{
			get { return xLinkColor;}
			set 
			{
				xLinkColor = value;
				base.LinkColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridParentRowsBackColor"),
		Description("Parent Row의 배경색을 지정합니다.")]
		public new XColor ParentRowsBackColor
		{
			get { return xParentRowsBackColor;}
			set 
			{
				xParentRowsBackColor = value;
				base.ParentRowsBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridParentRowsForeColor"),
		Description("Parent Row의 텍스트색을 지정합니다.")]
		public new XColor ParentRowsForeColor
		{
			get { return xParentRowsForeColor;}
			set 
			{
				xParentRowsForeColor = value;
				base.ParentRowsForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridSelectionBackColor"),
		Description("선택된 행의 배경색을 지정합니다.")]
		public new XColor SelectionBackColor
		{
			get { return xSelectionBackColor;}
			set 
			{
				xSelectionBackColor = value;
				base.SelectionBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridSelectionForeColor"),
		Description("선택된 행의 배경색을 지정합니다.")]
		public new XColor SelectionForeColor
		{
			get { return xSelectionForeColor;}
			set 
			{
				xSelectionForeColor = value;
				base.SelectionForeColor = value.Color;
			}
		}

		[Editor(typeof(XTableStyleCollectionEditor), typeof(UITypeEditor))]
		public new GridTableStylesCollection TableStyles
		{
			get{return base.TableStyles;}
		}
		[Browsable(false),DefaultValue("")]
		public new string DataMember
		{
			get { return base.DataMember;}
			set { base.DataMember = value;}
		}

		[Category("데이터")]
		public new DataTable DataSource
		{
			get 
			{ 
				try
				{
					return (DataTable) base.DataSource;
				}
				catch
				{
					return null;
				}
			}
			set 
			{
				//DataSource는 DataTable만 가능
				if (base.DataSource != value)
				{
					base.DataSource = value;
					gridTable = value;
					//TableName Reset
					this.tableName = "";
					//Handler Add
					if (base.DataSource != null)
					{
						((DataTable) base.DataSource).DefaultView.AllowNew = false;
						//TableName Set
						this.tableName = gridTable.TableName;
					}

				}
			}
		}
		[DefaultValue(15)]
		public new int RowHeaderWidth
		{
			get { return base.RowHeaderWidth;}
			set { base.RowHeaderWidth = value;}
		}
		[DefaultValue(false)]
		public new bool AllowNavigation
		{
			get { return base.AllowNavigation;}
			set { base.AllowNavigation = value;}
		}
		[DefaultValue(false)]
		public new bool AllowSorting
		{
			get { return base.AllowSorting;}
			set { base.AllowSorting = value;}
		}
		#endregion

		#region Properties
		[Browsable(false)]
		public int DisplayRowCount  //View에서 Display되는 RowCount
		{
			get
			{ 
				try
				{
					return this.ListManager.List.Count;
				}
				catch
				{
					return 0;
				}
			}
		}
		[Browsable(false)]
		public int RowCount  //실제 RowCount
		{
			get
			{
				if (this.gridTable == null) return 0;
				return this.gridTable.Rows.Count;
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// ColumnChanged : Column값을 변경시에 Validation Check 추가 Event Handler
		/// </summary>
		[Description("컬럼의 값이 변경되었을 때 발생합니다."),
		Category("추가이벤트"),	
		Browsable(true)]
		public event GridColumnChangedEventHandler GridColumnChanged;
		/// <summary>
		/// 행이 변경될때 발생시킬 Event
		/// </summary>
		[Description("행이 변경될 때 발생합니다."),
		Category("추가이벤트"),
		Browsable(true)]
		public event RowFocusChangedEventHandler RowFocusChanged;
		#endregion
		
		#region 생성자
		public XDataGrid()
		{
			this.AllowNavigation = false;
			this.AllowSorting = false;
			this.RowHeaderWidth = 15;
			//Default Color SET
			AlternatingBackColor	= XColor.XDataGridAlternatingBackColor;
			BackColor			= XColor.XDataGridBackColor;
			ForeColor			= XColor.XDataGridForeColor;
			BackgroundColor		= XColor.XDataGridBackgroundColor;
			CaptionBackColor	= XColor.XDataGridCaptionBackColor;
			CaptionForeColor	= XColor.XDataGridCaptionForeColor;
			GridLineColor		= XColor.XDataGridLineColor;
			HeaderBackColor		= XColor.XDataGridHeaderBackColor;
			HeaderForeColor		= XColor.XDataGridHeaderForeColor;
			LinkColor			= XColor.XDataGridLinkColor;
			ParentRowsBackColor = XColor.XDataGridParentRowsBackColor;
			ParentRowsForeColor = XColor.XDataGridParentRowsForeColor;
			SelectionBackColor	= XColor.XDataGridSelectionBackColor;
			SelectionForeColor	= XColor.XDataGridSelectionForeColor;
		}
		#endregion

		#region Override Event Invoker
		protected override void OnCurrentCellChanged(EventArgs e)
		{
			// Column Edit후에 Validation에서 Error발생하면 Cell이동불가
			if (this.gridTable.HasErrors)
			{
				this.CurrentCell = this.ErrorCell;
			}
			if ((this.CurrentCell.ColumnNumber) >= 0 && (this.CurrentCell.RowNumber >=0))
			{
				//RowFocusChanged Event 발생
				if (this.preRowNumer != this.CurrentCell.RowNumber)
				{
					if (this.RowFocusChanged != null)
						OnRowFocusChanged(new RowFocusChangedEventArgs(this.preRowNumer, this.CurrentCell.RowNumber));
				}

				//preRowNumber 저장
				this.preRowNumer = this.CurrentCell.RowNumber;
			}
			base.OnCurrentCellChanged(e);
		}

		/// <summary>
		/// DataGrid Focus를 잃을 때 발생합니다.
		/// DataGrid가 Error를 가지고 있으면 다른 Control이 작동하지 못하도록 합니다.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnValidating(CancelEventArgs e)
		{
			// DataTable에 Error가 있으면 Focus 이동 불가
			if (this.gridTable != null)
				e.Cancel = this.gridTable.HasErrors;

			base.OnValidating(e);
		}
		#endregion

		#region InitializeColumns
		/// <summary>
		/// 지정한 컬럼Style로 컬럼을 초기화 합니다.
		/// </summary>
		public void InitializeColumns()
		{
			//RunTime시만 적용
			if (this.DesignMode) return;
			
			bool connected = true;
			//DataSource가 연결되지 않았으면 TableStyles[0]로 Initialize
			if (this.DataSource == null)
				connected = false;
			else
			{
				//TableName SET
				this.tableName = this.DataSource.TableName;

				//DefaultView.AllowNew false
				this.DataSource.DefaultView.AllowNew = false;
			}

			//TableStyle이 없으면 Return
			if (this.TableStyles.Count < 1) return;

			//TableStyle중에 tableName과 Mapping되는 Style이 없으면 TableStyles[0]로 초기화
			if (!this.TableStyles.Contains(this.tableName))
				connected = false;

			InitializeColumnsSub(connected);
		}

		private void InitializeColumnsSub(bool connected)
		{
			//DesignTime시 정상적으로 DataSource가 연결되어 있으면 해당 TableName의 TableStyle적용
			//아니면 TableStyles[0] Style을 적용
			DataGridTableStyle tableStyle = null;
			if (connected)
				tableStyle = this.TableStyles[this.tableName];
			else
				tableStyle = this.TableStyles[0];

			foreach (XDataGridColumnStyleBase colStyle in tableStyle.GridColumnStyles)
			{
				if (colStyle is XDataGridStringTextBoxColumn)
				{
					XDataGridStringTextBoxColumn style = (XDataGridStringTextBoxColumn) colStyle;
					((XEditMask)style.Editor).Name = style.MappingName; //컬럼명 SET
					((XEditMask)style.Editor).Click			+= new EventHandler(DataGrid_Click);
					((XEditMask)style.Editor).DoubleClick	+= new EventHandler(DataGrid_DoubleClick);
					((XEditMask)style.Editor).MaxLength = style.MaxLength;
					((XEditMask)style.Editor).TextAlign = style.ColumnAlign;
					((XEditMask)style.Editor).EditMaskType = MaskType.String;
					((XEditMask)style.Editor).Mask = style.Mask;
					((XEditMask)style.Editor).EnterKeyToTab = style.EnterKeyToTab;

					//IME Mode 설정
					// 영문만 가능시 Disable
					if ((style.ImeMode == ColumnImeMode.OnlyEng) ||(style.ImeMode == ColumnImeMode.OnlyEngUpper)||(style.ImeMode == ColumnImeMode.OnlyEngLower))
						((XEditMask)style.Editor).ImeMode = ImeMode.Disable;
					else if (style.ImeMode == ColumnImeMode.Han)
					{
						//2005.10.
						((XEditMask)style.Editor).ImeMode = ImeMode.Hangul;
						((XEditMask)style.Editor).AccessibleName = "Hangul";  // GotFocus시 ImeMode다시 설정필요
					}
					else if ((style.ImeMode == ColumnImeMode.Eng)||(style.ImeMode == ColumnImeMode.EngUpper)||(style.ImeMode == ColumnImeMode.EngLower))
					{
						((XEditMask)style.Editor).ImeMode = ImeMode.Alpha;
						((XEditMask)style.Editor).AccessibleName = "Alpha"; // GotFocus시 ImeMode다시 설정필요
					}
					else if (style.ImeMode == ColumnImeMode.Hiragana)
					{
						((XEditMask)style.Editor).ImeMode = ImeMode.Hiragana;
						((XEditMask)style.Editor).AccessibleName = "Hiragana"; // GotFocus시 ImeMode다시 설정필요
					}
					else if (style.ImeMode == ColumnImeMode.Katakana)
					{
						((XEditMask)style.Editor).ImeMode = ImeMode.Katakana;
						((XEditMask)style.Editor).AccessibleName = "Katakana"; // GotFocus시 ImeMode다시 설정필요
					}
					else if (style.ImeMode == ColumnImeMode.KatakanaHalf)
					{
						((XEditMask)style.Editor).ImeMode = ImeMode.KatakanaHalf;
						((XEditMask)style.Editor).AccessibleName = "KatakanaHalf"; // GotFocus시 ImeMode다시 설정필요
					}


					// CharacterCasting Set
					if ((style.ImeMode == ColumnImeMode.EngUpper)||(style.ImeMode == ColumnImeMode.OnlyEngUpper))
						((XEditMask)style.Editor).CharacterCasing = CharacterCasing.Upper;
					else if ((style.ImeMode == ColumnImeMode.EngLower)||(style.ImeMode == ColumnImeMode.OnlyEngLower))
						((XEditMask)style.Editor).CharacterCasing = CharacterCasing.Lower;
					else
						((XEditMask)style.Editor).CharacterCasing = CharacterCasing.Normal;

				}
				else if (colStyle is XDataGridDateTimeTextBoxColumn)
				{
					XDataGridDateTimeTextBoxColumn style = (XDataGridDateTimeTextBoxColumn) colStyle;
					((XEditMask)style.Editor).Name = style.MappingName; //컬럼명 SET
					((XEditMask)style.Editor).Click			+= new EventHandler(DataGrid_Click);
					((XEditMask)style.Editor).DoubleClick	+= new EventHandler(DataGrid_DoubleClick);
					if (style.IsDateTime)
						((XEditMask)style.Editor).EditMaskType = MaskType.DateTime;
					else
						((XEditMask)style.Editor).EditMaskType = MaskType.Date;
					((XEditMask)style.Editor).TextAlign = style.ColumnAlign;
					((XEditMask)style.Editor).Mask = style.Mask;
					((XEditMask)style.Editor).EnterKeyToTab = style.EnterKeyToTab;
				}
				else if (colStyle is XDataGridNumericTextBoxColumn)
				{
					XDataGridNumericTextBoxColumn style = (XDataGridNumericTextBoxColumn) colStyle;
					((XEditMask)style.Editor).Name = style.MappingName; //컬럼명 SET
					((XEditMask)style.Editor).Click			+= new EventHandler(DataGrid_Click);
					((XEditMask)style.Editor).DoubleClick	+= new EventHandler(DataGrid_DoubleClick);
					if (style.DecimalDigits > 0)
						((XEditMask)style.Editor).EditMaskType = MaskType.Decimal;
					else
						((XEditMask)style.Editor).EditMaskType = MaskType.Number;
					((XEditMask)style.Editor).DecimalDigits = style.DecimalDigits;
					((XEditMask)style.Editor).MinusAccept = style.MinusAccept;
					((XEditMask)style.Editor).MaxinumCipher = style.MaxinumCipher;
					((XEditMask)style.Editor).EnterKeyToTab = style.EnterKeyToTab;
				}
				else if (colStyle is XDataGridComboBoxColumn)
				{
					XDataGridComboBoxColumn style = (XDataGridComboBoxColumn) colStyle;
					((XComboBox)style.Editor).Name = style.MappingName; //컬럼명 SET
					((XComboBox)style.Editor).Click			+= new EventHandler(DataGrid_Click);
					((XComboBox)style.Editor).DoubleClick	+= new EventHandler(DataGrid_DoubleClick);
					//ComboItem Set, DropDownStyle, MaxDropDownItems
					((XComboBox)style.Editor).DropDownStyle = style.DropDownStyle;
					((XComboBox)style.Editor).MaxDropDownItems = style.MaxDropDownItems;
					((XComboBox)style.Editor).EnterKeyToTab = style.EnterKeyToTab;
					((XComboBox)style.Editor).ComboItems.AddRange(style.ComboItems.ToArray());
				}
				else if (colStyle is XDataGridCheckBoxColumn)
				{
					XDataGridCheckBoxColumn style = (XDataGridCheckBoxColumn) colStyle;
					((XCheckBox)style.Editor).Name = style.MappingName; //컬럼명 SET
					((XCheckBox)style.Editor).Click			+= new EventHandler(DataGrid_Click);
					((XCheckBox)style.Editor).DoubleClick	+= new EventHandler(DataGrid_DoubleClick);
					((XCheckBox)style.Editor).CheckedValue = style.CheckedValue;
					((XCheckBox)style.Editor).UnCheckedValue = style.UnCheckedValue;
					((XCheckBox)style.Editor).CheckedText = style.CheckedText;
					((XCheckBox)style.Editor).UnCheckedText = style.UnCheckedText;
					((XCheckBox)style.Editor).EnterKeyToTab = style.EnterKeyToTab;
					//Alignment (Text가 없으면 Center)
					if ((style.CheckedText == "")&&(style.UnCheckedText == ""))
						((XCheckBox)style.Editor).CheckAlign = ContentAlignment.MiddleCenter;
				}
			}
		}
		#endregion

		#region Private Methods
		private object ConvertDateTimeValue(object dataValue)
		{
			if (dataValue is DateTime) return dataValue;
			if (dataValue == null) return DBNull.Value;
			if (dataValue.ToString() == "") return DBNull.Value;

			if (dataValue is string)
			{
				string data = dataValue.ToString();
				if (data.Length == 14) //YYYYMMDDHHMISS
				{
					try
					{
						return DateTime.Parse(data.Substring(0,4) + "/" + data.Substring(4,2) + "/" + data.Substring(6,2) + " "
							+ data.Substring(8,2) + ":" + data.Substring(10,2) + ":" + data.Substring(12));

					}
					catch
					{
						return DBNull.Value;
					}
				}
				else if (data.Length == 12) //YYYYMMDDHHMI
				{
					try
					{
						return DateTime.Parse(data.Substring(0,4) + "/" + data.Substring(4,2) + "/" + data.Substring(6,2) + " "
							+ data.Substring(8,2) + ":" + data.Substring(10,2));
					}
					catch
					{
						return DBNull.Value;
					}
				}
				else //YYYYMMDD형
				{
					try
					{
						return DateTime.Parse(data.Substring(0,4) + "/" + data.Substring(4,2) + "/" + data.Substring(6));
					}
					catch
					{
						return DBNull.Value;
					}
				}
			}
			return dataValue;
		}
		private void DataGrid_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}
		//Edit상태에서는 Grid의 DoubleClick이 발생하지 않으므로, Editor의 DoubleClick을
		//Handling하여 Grid의 OnDoubleClick Invoker를 발생시킴
		private void DataGrid_DoubleClick(object sender, EventArgs e)
		{
			this.OnDoubleClick(e);
		}
		#endregion

		#region Override ProcessDialogKey
		protected override bool ProcessKeyPreview(ref Message m)
		{
			bool lb = true;
			if ((m.Msg == (int)Win32.Msgs.WM_KEYDOWN) ||(m.Msg == (int)Win32.Msgs.WM_KEYUP)) 
			{
				// VK_LEFT, VK_RIGHT는 Column Edit Mode에서는 다른 Column으로 이동하지 않고, 문자편집가능하도록 함
				// 처리하지 않으면 현재 다음 컬럼으로 이동함
				if(((int)m.WParam == (int)Win32.VirtualKeys.VK_LEFT) || ((int)m.WParam == (int)Win32.VirtualKeys.VK_RIGHT))
					lb = false;
				// VK_HOME, VK_END Key도 처리하지 않음(EditMode에서 해당 Control에 Home End 처리)
				if(((int)m.WParam == (int)Win32.VirtualKeys.VK_HOME) || ((int)m.WParam == (int)Win32.VirtualKeys.VK_END))
					lb = false;
				else if ((int)m.WParam == (int)Win32.VirtualKeys.VK_TAB)
					lb = false;
				else if (((int)m.WParam == (int)Win32.VirtualKeys.VK_UP) ||((int)m.WParam == (int)Win32.VirtualKeys.VK_DOWN))
				{
					//ComboColumn에서는 ArrowKey 처리하지 않고, ColumnStyle의 ComboBox의 고유기능 사용(Tab Key는 처리하지 않음)
					try
					{
						if (this.TableStyles[this.tableName].GridColumnStyles[this.CurrentCell.ColumnNumber] is XDataGridComboBoxColumn)
							lb = false;
					}
					catch{}
				}
			}
			if (lb)
				lb = base.ProcessKeyPreview(ref m);
			return lb;
		}
		#endregion

		#region Override OnPaint
		//private int headerHeight = 0;
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);

			//headerHeight Get
			if(this.headerHeight == 0)
			{
				//HeaderFont로 String의 크기를 구해  + 8.3 (Try해서 얻은 값)
				Graphics graph = CreateGraphics();
				SizeF cSize = graph.MeasureString("A", this.HeaderFont);
				headerHeight = (int) (cSize.Height + 8.3);
				graph.Dispose();
			}
			
			//Header를 다시 그릴때만 그림
			if (e.ClipRectangle.Y < this.headerHeight)
			{
				this.DrawHeaderHorzGrad(e);
			}
		}
		
		private void DrawHeaderHorzGrad(PaintEventArgs pe)
		{
			//DesignMode시만 그림
			if (!this.DesignMode) return;

			//DataSource가 있으면 DataSource로 그리므로 그리지 않음
			if (this.DataSource != null) return;

			int iPosX = 0;
			int xMargin = 0;
			int yMargin = 0;
			//BorderStyle에 따라 마진 변경
			if(this.BorderStyle != BorderStyle.None)
			{
				xMargin = 2;
				yMargin = 2;
			}

			//Caption Visible이면 yMargin headerWidth만큼 적용
			if (this.CaptionVisible)
				yMargin += this.headerHeight;

			if (this.TableStyles.Count > 0)
			{
				if (this.TableStyles[0].RowHeadersVisible)
				{
					iPosX = xMargin  + this.TableStyles[0].RowHeaderWidth + 1 ;
					this.RowHeaderWidth = this.TableStyles[0].RowHeaderWidth;
				}
				else
					iPosX = xMargin;

			}
			else
				iPosX = xMargin;

			Rectangle rect ;
			StringFormat format  = new StringFormat();
			format.LineAlignment = StringAlignment.Center;
			format.Alignment     = StringAlignment.Center;
			
			//ScrollBar가 있을땐 Scroll된 값만큼 좌표 이동하여 그림
			if (this.HorizScrollBar.Value > 0)
			{
				// Then to translate, appending to world transform.
				// xMargin만큼은 제외
				pe.Graphics.TranslateTransform(-this.HorizScrollBar.Value , 0, MatrixOrder.Append);
			}
			
			if(this.TableStyles.Count > 0)
			{
				Brush bBrush = new SolidBrush(this.TableStyles[0].HeaderBackColor);
				Brush fBrush = new SolidBrush(this.TableStyles[0].HeaderForeColor);
				
				//RowHeaderVisible이면 RowHeader도 그림
				if (this.TableStyles[0].RowHeadersVisible)
				{
					rect = new Rectangle(xMargin, yMargin, this.TableStyles[0].RowHeaderWidth, this.headerHeight);
					pe.Graphics.FillRectangle(bBrush,rect);
					//Border 그리기
					ControlPaint.DrawBorder(pe.Graphics, rect ,Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
						Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
						SystemColors.ControlLight,1,ButtonBorderStyle.Outset,
						SystemColors.ControlLight,1,ButtonBorderStyle.Outset);
				}

				foreach(DataGridColumnStyle colStyle in this.TableStyles[0].GridColumnStyles)
				{
					//Width가 0가 아니면 Draw
					if(colStyle.Width > 0)
					{
						//rect 는 x,y Margin을 고려하여 SET
						rect = new Rectangle(iPosX, yMargin, colStyle.Width , this.headerHeight);
						
						//Fill Rect
						pe.Graphics.FillRectangle(bBrush,rect);
						//Border 그리기
						ControlPaint.DrawBorder(pe.Graphics, rect ,Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
							Color.WhiteSmoke,1,ButtonBorderStyle.Solid,
							SystemColors.ControlLight,1,ButtonBorderStyle.Outset,
							SystemColors.ControlLight,1,ButtonBorderStyle.Outset);

						//text color
						pe.Graphics.DrawString(colStyle.HeaderText, this.TableStyles[0].HeaderFont ,fBrush,rect,format);

						iPosX = iPosX + colStyle.Width ;
					}
				}
				format.Dispose();
				bBrush.Dispose();
				fBrush.Dispose();
			}
		}
		#endregion

		#region Override OnMouseDown
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			if (e.Button == MouseButtons.Left)
			{
				HitTestInfo hInfo = this.HitTest(e.X, e.Y);
				//컬럼, 특정 Row Click시에 그 컬럼이 
				if ((hInfo.Column >= 0) && (hInfo.Row >= 0))
				{
					//DataSource에 지정한 tableName과 일치하는 TableStyle이 있으면
					if (this.TableStyles.Contains(this.tableName))
					{
						DataGridColumnStyle style = this.TableStyles[this.tableName].GridColumnStyles[hInfo.Column];
						if (style is XDataGridCheckBoxColumn)
						{
							//Grid의 OnMouseDown보다 ColumnStyle의 Edit가 먼저 발생
							//따라서, Click을 통해 Edit가 되었을 경우에는 CheckBox의 상태를 변경함
							((XDataGridCheckBoxColumn) style).TogglingCheckState();
						}
					}
				}
			}
		}
		#endregion

		#region Event Invoker
		/// <summary>
		/// Column 값 변경시 Validation Check
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected internal void OnGridColumnChanged(GridColumnChangedEventArgs e)
		{
			if (GridColumnChanged != null)
				this.GridColumnChanged(this, e);
		}
		internal bool ExistGridColumnChangedEvent()
		{
			if (this.GridColumnChanged != null)
				return true;
			return false;
		}
		/// <summary>
		/// RowFocusChanged Event를 발생시킵니다.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnRowFocusChanged(RowFocusChangedEventArgs e)
		{
			//DataGrid가 ReadOnly이면 CurrentRow HighLight
			if (this.ReadOnly)
				this.Select(e.CurrentRow);
			if (RowFocusChanged != null)
				RowFocusChanged(this, e);
		}
		#endregion

		#region InsertRow,DeleteRow, AcceptData
		/// <summary>
		/// 새행 추가
		/// </summary>
		/// <returns></returns>
		public virtual bool InsertRow()
		{
			return InsertRow(this.CurrentCell.RowNumber, true);
		}
		// 새행추가 Focus를 줌
		public virtual bool InsertRow(int row)
		{
			return InsertRow(row, true);
		}
		/// <summary>
		/// 새행 추가 : Row전에 새행 추가, Row = 0 이면 끝에 추가 (return, 1:Success, -1:Fail)
		/// </summary>
		public bool InsertRow(int row, bool editMode)
		{
			if (this.gridTable == null) return false;
			//Table이 Error상태이면 Return
			if (this.gridTable.HasErrors) return false;

			//Flag Set
			int bfRowCount = this.ListManager.List.Count;
			
			//중간에 삽입없음, 맨 마지막에 추가
			DataRow dtRow = this.gridTable.NewRow();
			this.gridTable.Rows.Add(dtRow);
			// row의 위치가 바뀌었으므로 CurrencyManager의 Position을 Row와 같게 Set
			// Position을 정확히 Setting하지 않으면 Insert후에 Focus를 제대로 가지지 못하고
			// 입력후 Commit시에 Positon과 RowNum이 달라 Error가 발생함(반드시 해야함)
			this.ListManager.Position = bfRowCount;
			//Position과 RowNumber를 항상 일치시켜야 함.(여러Row가 있을때 Reset후 InsertRow를 하면
			if (this.ListManager.Position != this.CurrentCell.RowNumber)
			{
				try
				{
					this.CurrentCell = new DataGridCell(this.ListManager.Position, 0);
				}
				catch
				{
					return true;
				}
			}

			// focus를 주어야 하면, 첫번째 Editable Column으로 Edit Mode 시작
			if ( editMode && this.CurrentCell.RowNumber >= 0)
			{
				//첫번째 Edit가능 컬럼 Find
				int firstColNo = this.FirstEditableColumn();
				//첫번째 Edit가능컬럼과 TableName과 일치하는 TableStyle존재시에
				if ((firstColNo >= 0) && this.TableStyles.Contains(this.tableName))
				{
					this.BeginEdit(this.TableStyles[this.tableName].GridColumnStyles[firstColNo], this.CurrentCell.RowNumber);
				}
			}
			return true;

		}
		public virtual bool DeleteRow()
		{
			return DeleteRow(this.CurrentCell.RowNumber);
		}
		/// <summary>
		/// 행 삭제 :row 행을 Delete, 0 미만 현재행 삭제 , return : 1:Success, -1:Fail 
		/// </summary>
		[Description("행을 삭제합니다.")]
		public virtual bool DeleteRow(int row)
		{
			DataRow dtRow = null;
			
			if (this.gridTable == null) return false;

			if (this.gridTable.HasErrors) return false;

			if (this.CurrentCell.RowNumber < 0) return false;

			//마지막 행 여부
			bool isLastRow = ((this.CurrentCell.RowNumber == this.DisplayRowCount - 1) ? true : false);

			//row -1, ListManager.Count 보다크면 현재행 삭제
			try
			{
				if ((row < 0) || (row >= this.ListManager.List.Count))
				{
					//GridTable이 아닌 ListManager에서 DataRow Get
					dtRow = ((DataRowView) this.ListManager.List[this.CurrentCell.RowNumber]).Row;
					//removeDataRow은 Deleted Buffer에 남겨두지 않고 DataTable에서 Remove
					this.gridTable.Rows.Remove(dtRow);
				}
				else
				{
					dtRow = ((DataRowView) this.ListManager.List[row]).Row;
					//removeDataRow은 Deleted Buffer에 남겨두지 않고 DataTable에서 Remove
					this.gridTable.Rows.Remove(dtRow);
				}
			}
			catch(Exception e)
			{
				Debug.WriteLine("XDataGrid::DeleteRow Error=" + e.Message);
				return false;
			}
			return true;
		}
		[Description("Edit중인 Data를 DataTable에 Setting합니다.")]
		public virtual bool AcceptData()
		{
			//테이블이 없으면 실패
			if (this.gridTable == null) return false;
			//컬럼스타일이 없으면 성공
			if (this.TableStyles.Count < 1) return true;

			if (this.gridTable.Rows.Count < 1) return true;

			int rowNum = this.CurrentCell.RowNumber;
			int colNum = this.CurrentCell.ColumnNumber;

			if(rowNum < 0 || colNum < 0) return true;

			try
			{
				// 편집시작하여 편집중인 값 반영
				// BeginEdit에 의해 편집중인 값이 바뀌면 DataTable의 ColumnChanged Event가 발생하여
				// OnGridColumnChanged Invoker Call, GridColumnChanged Event를 Handling하면
				// Event에 의해 다른 처리 가능
				// 원래값과 값이 같으면 Invoker 발생하지 않음
				if (this.TableStyles.Contains(this.tableName))
				{
					this.BeginEdit(this.TableStyles[this.tableName].GridColumnStyles[colNum], rowNum);

					//편집종료
					this.EndEdit(this.TableStyles[this.tableName].GridColumnStyles[colNum], rowNum, false);
					
					//컬럼의 편집을 종료해도 Editor의 값은 반영이 되나, DataRow의 상태가 바뀌지 않음
					//따라서, DataRow의 EndEdit를 call하여 DataRow의 상태 반영처리함
					this.DataSource.Rows[rowNum].EndEdit();
				}
				//GridColumnChanged Event에 의해 반영된 값 Display
				this.Invalidate();
				// 편집중인 상태에서 Error가 Setting 되었으면 전송,조회불가
				if (this.gridTable.HasErrors) return false;

				return true;
			}
			catch(Exception e)
			{
				this.ShowErrMsg("XDataGrid::AcceptData 에러[" + e.Message + "]");
				return false;
			}
		}
		/// <summary>
		/// Reset
		/// </summary>
		[Description("DataGrid를 초기화합니다.")]
		public virtual void Reset()
		{
			if (this.gridTable == null) return;

			this.gridTable.Clear();
			
			// Position Clear
			this.ListManager.Position = -1;

			//PrevRowNumber Clear
			this.preRowNumer = -1;

		}
		/// <summary>
		/// 상태 Reset (NotModified로)
		/// </summary>
		[Description("자료상태를 Reset합니다.")]
		public virtual void ResetUpdate()
		{
			if (this.gridTable == null) return;

			this.gridTable.AcceptChanges();
		}
		protected virtual int FirstEditableColumn()
		{
			if (this.ReadOnly) return -1;
			//지정한 DataSource의 테이블명과 일치하는 TableStyle이 없으면 -1
			if (!this.TableStyles.Contains(this.tableName)) return -1;

			for (int i = 0; i < this.TableStyles[this.tableName].GridColumnStyles.Count ; i++)
			{
				DataGridColumnStyle style = this.TableStyles[this.tableName].GridColumnStyles[i];
				if ((style.Width != 0) && !style.ReadOnly)
					return i;
			}
			return -1;
		}
		#endregion

		#region GetItem method
		[Description("Cell(행번호, 컬럼명) 의 Data를 가져옵니다.")]
		public object GetItem(int rowNum, string colName)
		{
			return GetItem(rowNum, colName, false);
		}
		[Description("Cell(행번호, 컬럼번호) 의 Data를 가져옵니다.")]
		public object GetItem(int rowNum, int colNum)
		{
			return GetItem(rowNum, colNum, false);
		}
		[Description("Cell(행번호, 컬럼명,원래값여부) 의 Data를 가져옵니다.")]
		public object GetItem(int rowNum, string colName, bool isOriginal)
		{
			object data = DBNull.Value;
			try
			{
				DataRow dtRow = ((DataRowView)this.ListManager.List[rowNum]).Row;
				switch (dtRow.RowState)
				{
					case DataRowState.Added:
						if (isOriginal)
							data = dtRow[colName];
						else //Added상태는 원래값과 현재값이 동일함.
							data = dtRow[colName];
						break;
					case DataRowState.Unchanged:
					case DataRowState.Modified:
						if (isOriginal) // 원래값
							data = dtRow[colName, DataRowVersion.Original];
						else
							data = dtRow[colName]; //현재값
						break;
				}
			}
			catch
			{
				data = DBNull.Value;
			}
			return data;
		}
		[Description("Cell(행번호, 컬럼번호,원래값여부) 의 Data를 가져옵니다.")]
		public object GetItem(int rowNum, int colNum, bool isOriginal)
		{
			object data = DBNull.Value;
			try
			{
				DataRow dtRow = ((DataRowView)this.ListManager.List[rowNum]).Row;
				switch (dtRow.RowState)
				{
					case DataRowState.Added:
							data = dtRow[colNum];  //현재값과 원래값이 같음
						break;
					case DataRowState.Unchanged:
					case DataRowState.Modified:
						if (isOriginal)
							data = dtRow[colNum, DataRowVersion.Original];
						else
							data = dtRow[colNum];
						break;
				}
			}
			catch
			{
				data = DBNull.Value;
			}
			return data;
		}
		#endregion

		#region SetItem Method
		// Setting RowData 
		// Return Value : true : Success false:Fail
		[Description("Cell(행번호, 컬럼명) 의 Data를 설정합니다.")]
		public bool SetItem(int rowNum, string colName, object data)
		{
			try
			{
				object dataValue = data;
				//DateTime형 컬럼은 String이 YYYYMMDD,YYYYMMDDHHMISS형일때도 수용함
				if (this.gridTable.Columns[colName].DataType == typeof(DateTime))
					dataValue = this.ConvertDateTimeValue(dataValue);

				((DataRowView)this.ListManager.List[rowNum]).Row[colName] = data;
				//Column이 Editing중이면 Editor의 DataValue도 Data로 SET
				if (this.TableStyles.Contains(this.tableName))
				{
					if (((XDataGridColumnStyleBase)this.TableStyles[this.tableName].GridColumnStyles[colName]).IsEditing)
						((XDataGridColumnStyleBase)this.TableStyles[this.tableName].GridColumnStyles[colName]).Editor.DataValue = data;
				}
			}
			catch(Exception e)
			{
				ShowErrMsg("XDataGrid::SetItem(" + rowNum.ToString() + "," + colName +") 에러[" + e.Message + "]");
				return false;
			}
			return true;
		}
		// Setting RowData 
		// Return Value : true : Success false:Fail
		[Description("Cell(행번호, 컬럼번호) 의 Data를 설정합니다.")]
		public bool SetItem(int rowNum, int colNum, object data)
		{
			try
			{
				
				object dataValue = data;
				//DateTime형 컬럼은 String이 YYYYMMDD,YYYYMMDDHHMISS형일때도 수용함
				if (this.gridTable.Columns[colNum].DataType == typeof(DateTime))
					dataValue = this.ConvertDateTimeValue(dataValue);

				((DataRowView)this.ListManager.List[rowNum]).Row[colNum] = dataValue;
				//Column이 Editing중이면 Editor의 DataValue도 Data로 SET
				if (this.TableStyles.Contains(this.tableName))
				{
					if (((XDataGridColumnStyleBase)this.TableStyles[this.tableName].GridColumnStyles[colNum]).IsEditing)
						((XDataGridColumnStyleBase)this.TableStyles[this.tableName].GridColumnStyles[colNum]).Editor.DataValue = dataValue;
				}
			}
			catch(Exception e)
			{
				ShowErrMsg("XDataGrid::SetItem(" + rowNum.ToString() + "," + colNum.ToString() +") 에러[" + e.Message + "]");
				return false;
			}
			return true;
		}
		#endregion

		#region SetFocus 관련 Method
		// 해당 Item에 Focus를 준다.
		// return value : true.Success, false.Fail
		[Description("Cell(행번호, 컬럼명) 에 Focus를 설정합니다.")]
		public bool SetFocusToItem(int rowNum, string colName)
		{
			int index = -1;
			try
			{
				if (!this.TableStyles.Contains(this.tableName)) return false;
				for (int i = 0; i < this.TableStyles[this.tableName].GridColumnStyles.Count ; i++)
				{
					DataGridColumnStyle style = this.TableStyles[this.tableName].GridColumnStyles[i];
					if (style.MappingName == colName)
					{
						index = i;
						break;
					}
				}
				if (index >= 0)
				{
					this.CurrentCell = new DataGridCell(rowNum, index);
					//BeginEdit
					this.BeginEdit(this.TableStyles[this.tableName].GridColumnStyles[colName], rowNum);
				}
			}
			catch(Exception e)
			{
				Debug.WriteLine("XDataGrid::SetFocusToItem, rowNum[" + rowNum.ToString() + "],colName[" + colName + "], Error=" + e.Message);
				return false;
			}
			//ListManager의 위치 조정
			this.ListManager.Position = rowNum;
			return true;
		}
		[Description("Cell(행번호, 컬럼번호) 에 Focus를 설정합니다.")]
		public bool SetFocusToItem(int rowNum, int colNum)
		{
			try
			{
				this.CurrentCell = new DataGridCell(rowNum, colNum);
				
				if (!this.TableStyles.Contains(this.tableName)) return false;

				//BeginEdit
				this.BeginEdit(this.TableStyles[this.tableName].GridColumnStyles[colNum], rowNum);
			}
			catch(Exception e)
			{
				Debug.WriteLine("XDataGrid::SetFocusToItem, rowNum[" + rowNum.ToString() + "],colNum[" + colNum.ToString() + "], Error=" + e.Message);
				return false;
			}
			//ListManager의 위치 조정
			this.ListManager.Position = rowNum;
			return true;
		}
		#endregion

		#region ISupportInitialize Implementation
		//DataGrid가 ISupportInitialize 를 구현하고 있으나, Override하지 못하므로
		//다시 Interface를 정의하고, 구현하여 EndInit에서 컬럼 초기화
		public new void EndInit()
		{
			//컬럼 초기화
			InitializeColumns();
			base.EndInit();
		}
		#endregion

		#region RowMoveUp, RowMoveDown, GetDataRow
		/// <summary>
		/// 현재행 앞으로 이동, return : 1:Success, -1:Fail
		/// </summary>
		[Description("현재 Row를 한 Row 위로 이동합니다.")]
		public bool RowMoveUp(int currRow)
		{
			if (this.gridTable == null) return false;

			// 현재Row를 한 Row 위로 올리고, 위의 Row를 아래로 내림
			DataTable dtblTemp;
			DataRow dtRowPrev = null ;
			int rowNum = 0;
			if (currRow > 0)
			{
				dtblTemp = this.gridTable.Copy(); //기존 DataTable 저장
				this.gridTable.Rows.Clear();
				try
				{
					foreach(DataRow dataRow in dtblTemp.Rows)
					{
						if(rowNum == currRow - 1 )
						{
							dtRowPrev = dataRow;
						}
						else if(rowNum == currRow)
						{
							this.gridTable.ImportRow(dataRow);
							this.gridTable.ImportRow(dtRowPrev);
						}
						else
							this.gridTable.ImportRow(dataRow);
						rowNum++;
					}
				}
				catch
				{
					return false;
				}
				// row의 위치가 바뀌었으므로 CurrencyManager의 Position을 Row와 같게 Set
				this.ListManager.Position = currRow - 1;
				dtblTemp.Dispose();
			}
			return true;
		}
		/// <summary>
		/// 현재행 아래로 이동
		/// </summary>
		[Description("현재 Row를 한 Row 아래로 이동합니다.")]
		public bool RowMoveDown(int currRow)
		{
			if (this.gridTable == null) return false;

			// 현재Row를 한 Row 위로 올리고, 위의 Row를 아래로 내림
			DataTable dtblTemp;
			DataRow dtRowCurr = null ;
			int rowNum = 0;
			// 현재행이 전체 Row보다 작을때만 MoveDown 가능
			if (currRow < this.gridTable.Rows.Count - 1)
			{
				dtblTemp = this.gridTable.Copy(); //기존 DataTable 저장
				this.gridTable.Rows.Clear();
				try
				{
					foreach(DataRow dataRow in dtblTemp.Rows)
					{
						if(rowNum == currRow )
						{
							dtRowCurr = dataRow;
						}
						else if(rowNum == currRow + 1 )
						{
							this.gridTable.ImportRow(dataRow);
							this.gridTable.ImportRow(dtRowCurr);
						}
						else
							this.gridTable.ImportRow(dataRow);
						rowNum++;
					}
				}
				catch
				{
					return false;
				}
				// 입력후 Commit시에 Positon과 RowNum이 달라 Error가 발생함(반드시 해야함)
				this.ListManager.Position = currRow + 1;
				dtblTemp.Dispose();
			}
			return true;
		}
		internal DataRow GetDataRow(int rowNumber)
		{
			DataRow dtRow = null;
			try
			{
				dtRow = ((DataRowView)this.ListManager.List[rowNumber]).Row;
			}
			catch
			{
				dtRow = null;
			}
			return dtRow;
		}
		#endregion

		#region ShowErrMsg
		protected void ShowErrMsg(string msg)
		{
			MessageBox.Show(msg);
		}
		#endregion

		#region XTableStyleCollectionEditor
		private class XTableStyleCollectionEditor : CollectionEditor
		{
			public XTableStyleCollectionEditor(Type type):base(type)
			{
			}
			protected override System.Type[] CreateNewItemTypes()
			{
				return new Type[] {typeof(XDataGridTableStyle)};
			} 
		} 
		#endregion
	}

	#region XDataGridTableStyle
	public class XDataGridTableStyle : DataGridTableStyle
	{
		#region Class Fields
		private XColor xAlternatingBackColor	= XColor.XDataGridAlternatingBackColor;
		private XColor xBackColor			= XColor.XDataGridBackColor;
		private XColor xForeColor			= XColor.XDataGridForeColor;
		private XColor xGridLineColor		= XColor.XDataGridLineColor;
		private XColor xHeaderBackColor		= XColor.XDataGridHeaderBackColor;
		private XColor xHeaderForeColor		= XColor.XDataGridHeaderForeColor;
		private XColor xLinkColor			= XColor.XDataGridLinkColor;
		private XColor xSelectionBackColor	= XColor.XDataGridSelectionBackColor;
		private XColor xSelectionForeColor	= XColor.XDataGridSelectionForeColor;
		#endregion

		#region Base Properties
		[DefaultValue(typeof(XColor),"XDataGridAlternatingBackColor"),
		Description("교대로 반복되는 행의 배경색을 지정합니다.")]
		public new XColor AlternatingBackColor
		{
			get { return xAlternatingBackColor;}
			set 
			{
				xAlternatingBackColor = value;
				base.AlternatingBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridBackColor"),
		Description("행의 배경색을 지정합니다.")]
		public new XColor BackColor
		{
			get { return xBackColor;}
			set 
			{
				xBackColor = value;
				base.BackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridForeColor"),
		Description("행의 텍스트색을 지정합니다.")]
		public new XColor ForeColor
		{
			get { return xForeColor;}
			set 
			{
				xForeColor = value;
				base.ForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridLineColor"),
		Description("라인의 색을 지정합니다.")]
		public new XColor GridLineColor
		{
			get { return xGridLineColor;}
			set 
			{
				xGridLineColor = value;
				base.GridLineColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridHeaderBackColor"),
		Description("헤더의 배경색을 지정합니다.")]
		public new XColor HeaderBackColor
		{
			get { return xHeaderBackColor;}
			set 
			{
				xHeaderBackColor = value;
				base.HeaderBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridHeaderForeColor"),
		Description("헤더의 텍스트색을 지정합니다.")]
		public new XColor HeaderForeColor
		{
			get { return xHeaderForeColor;}
			set 
			{
				xHeaderForeColor = value;
				base.HeaderForeColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridLinkColor"),
		Description("Link시 색을 지정합니다.")]
		public new XColor LinkColor
		{
			get { return xLinkColor;}
			set 
			{
				xLinkColor = value;
				base.LinkColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridSelectionBackColor"),
		Description("선택된 행의 배경색을 지정합니다.")]
		public new XColor SelectionBackColor
		{
			get { return xSelectionBackColor;}
			set 
			{
				xSelectionBackColor = value;
				base.SelectionBackColor = value.Color;
			}
		}
		[DefaultValue(typeof(XColor),"XDataGridSelectionForeColor"),
		Description("선택된 행의 배경색을 지정합니다.")]
		public new XColor SelectionForeColor
		{
			get { return xSelectionForeColor;}
			set 
			{
				xSelectionForeColor = value;
				base.SelectionForeColor = value.Color;
			}
		}
		//Color 재정의
		[DefaultValue(15)]
		public new int RowHeaderWidth
		{
			get { return base.RowHeaderWidth;}
			set { base.RowHeaderWidth = value;}
		}
		[DefaultValue(false)]
		public new bool AllowSorting
		{
			get { return base.AllowSorting;}
			set { base.AllowSorting = value;}
		}
		#endregion

		public XDataGridTableStyle()
		{
			this.RowHeaderWidth = 15;  //기본값 15
			this.AllowSorting = false;
			//Default Color SET
			AlternatingBackColor	= XColor.XDataGridAlternatingBackColor;
			BackColor			= XColor.XDataGridBackColor;
			ForeColor			= XColor.XDataGridForeColor;
			GridLineColor		= XColor.XDataGridLineColor;
			HeaderBackColor		= XColor.XDataGridHeaderBackColor;
			HeaderForeColor		= XColor.XDataGridHeaderForeColor;
			LinkColor			= XColor.XDataGridLinkColor;
			SelectionBackColor	= XColor.XDataGridSelectionBackColor;
			SelectionForeColor	= XColor.XDataGridSelectionForeColor;
		}

		//over ride base class object which points to the collection editor
		[Editor(typeof(XColumnStyleCollectionEditor), typeof(UITypeEditor))]
		public new GridColumnStylesCollection GridColumnStyles
		{
			get {return base.GridColumnStyles;}
		}

		protected override DataGridColumnStyle CreateGridColumn(PropertyDescriptor prop, bool isDefault)
		{
			return base.CreateGridColumn(prop, isDefault);
		}
		
		#region XColumnStyleCollectionEditor
		private class XColumnStyleCollectionEditor : CollectionEditor
		{
			public XColumnStyleCollectionEditor(Type type) : base(type)
			{
			}

			protected override System.Type[] CreateNewItemTypes()
			{
				return new Type[] {	
									  typeof(XDataGridStringTextBoxColumn),
									  typeof(XDataGridNumericTextBoxColumn),
									  typeof(XDataGridDateTimeTextBoxColumn),
									  typeof(XDataGridComboBoxColumn),
									  typeof(XDataGridCheckBoxColumn)
								  }; 
			} 
		} 
		#endregion
	}
	#endregion

	#region GridColumnChanged EventHandler
	/// <summary>
	/// Grid의 컬럼값이 변경될때 발생이벤트를 처리하는 메서드입니다.
	/// </summary>
	[Serializable]
	public delegate void GridColumnChangedEventHandler(object sender, GridColumnChangedEventArgs e);
	
	/// <summary>
	/// Grid의 컬럼값이 변경될때 발생이벤트에 데이타를 제공합니다.
	/// </summary>
	public class GridColumnChangedEventArgs : EventArgs
	{
		private int		rowNumber;
		private DataRow dataRow;
		private string	colName;
		private object	changeValue;
		private bool	cancel;
		/// <summary>
		/// 현재 행번호를 가져옵니다.
		/// </summary>
		public int RowNumber
		{
			get { return rowNumber;}
		}
		/// <summary>
		/// 현재 컬럼명을 가져옵니다.
		/// </summary>
		public string  ColName
		{
			get { return colName;}
		}
		/// <summary>
		/// 현재 행의 DataRow 객체를 가져옵니다.
		/// </summary>
		public DataRow  DataRow
		{
			get { return dataRow;}
		}
		/// <summary>
		/// 변경된 값을 가져옵니다.
		/// </summary>
		public object ChangeValue
		{
			get { return changeValue;}
		}
		/// <summary>
		/// 이벤트의 취소여부를 가져오거나 설정합니다.
		/// </summary>
		public bool Cancel
		{
			get { return cancel;}
			set { cancel = value;}
		}
		/// <summary>
		/// GridColumnChangedEventArgs 생성자
		/// </summary>
		/// <param name="rowNumber"> 현재행번호 </param>
		/// <param name="colName"> 컬럼명 </param>
		/// <param name="dataRow"> 현재행의 DataRow객체 </param>
		/// <param name="changeValue"> 변경값 </param>
		public GridColumnChangedEventArgs(int rowNumber, string colName, DataRow dataRow, object changeValue)
		{
			this.rowNumber = rowNumber;
			this.colName = colName;
			this.dataRow = dataRow;
			this.changeValue = changeValue;
			this.cancel = false;
		}
	}
	#endregion

	#region RowFocusChangedEventHandler
	[Serializable]
	public delegate void RowFocusChangedEventHandler(Object sender, RowFocusChangedEventArgs e);

	public class RowFocusChangedEventArgs : EventArgs
	{
		private int currentRow;
		private int previousRow;
		public int CurrentRow
		{
			get { return currentRow;}
		}
		public int PreviousRow
		{
			get { return previousRow;}
		}
		public RowFocusChangedEventArgs(int prevRow, int currRow)
		{
			previousRow = prevRow;
			currentRow = currRow;
		}
	}
	#endregion

}
