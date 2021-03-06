using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Design;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;
namespace IHIS.Framework
{
	#region ColumnImeMode
	public enum ColumnImeMode
	{
		/// <summary>
		/// English(한영전환가능)
		/// </summary>
		Eng,
		/// <summary>
		/// English Upper(한영전환가능)
		/// </summary>
		EngUpper,
		/// <summary>
		/// English Upper(한영전환가능)
		/// </summary>
		EngLower,
		/// <summary>
		/// Korean(한영전환가능)
		/// </summary>
		Han,
		/// <summary>
		/// 미지정
		/// </summary>
		None,
		/// <summary>
		/// English(한영전환불가)
		/// </summary>
		OnlyEng,
		/// <summary>
		/// English Upper(한영전환불가)
		/// </summary>
		OnlyEngUpper,
		/// <summary>
		/// English Lower(한영전환불가)
		/// </summary>
		OnlyEngLower,
		/// <summary>
		/// 히라가나 (2Bytes)
		/// </summary>
		Hiragana,
		/// <summary>
		/// 카타카나 Full(2Byte)
		/// </summary>
		Katakana,
		/// <summary>
		/// 카나카나 반각
		/// </summary>
		KatakanaHalf

	}
	#endregion

	#region XDataGridColumnStyleBase
	public class XDataGridColumnStyleBase : DataGridColumnStyle
	{
		#region Class Fields
		const int xMargin = 1;
		const int yMargin = 1;
		private string oldVal= string.Empty;
		private XColor newTextColor = XColor.InsertedForeColor;
		private XColor modTextColor = XColor.UpdatedForeColor;
		private IEditorControl editor = null;
		private XColor backColor = XColor.XDataGridBackColor;
		private XColor foreColor = XColor.XDataGridForeColor;
		private XColor alternatingBackColor = XColor.XDataGridAlternatingBackColor;
		private Font	font = new Font("MS UI Gothic",9.75f);
		private HorizontalAlignment columnAlign = HorizontalAlignment.Left;
		protected bool isEditing = false;
		private bool enterKeyToTab	= true;	//Enter Key를 누르면 TAB Key를 발생시킬지 여부
		protected Image ColumnImage = null;
		#endregion

		#region Base Property Override
		[Category("컬럼정보")]
		public new string MappingName
		{
			get { return base.MappingName;}
			set { base.MappingName = value;}
		}
		[Category("컬럼정보")]
		public override bool ReadOnly 
		{
			get { return base.ReadOnly;}
			set { base.ReadOnly = value;}
		}
		[Category("헤더정보")]
		public override string HeaderText  
		{
			get { return base.HeaderText;}
			set { base.HeaderText = value;}
		}
		[Browsable(false),DefaultValue("(null)")]
		public override string NullText
		{
			get { return base.NullText;}
			set { base.NullText = value;}
		}
		[Category("컬럼정보"), DefaultValue(100)]
		public override int Width 
		{
			get { return base.Width;}
			set { base.Width = value;}
		}
		[Category("헤더정보"), DefaultValue(HorizontalAlignment.Center)]
		public override HorizontalAlignment Alignment
		{
			get { return base.Alignment;}
			set { base.Alignment = value;}
		}
		#endregion

		#region Properties
		// TextBox Property(Only Get) , 개별상속에서 Override
		[Browsable(false)]
		public virtual IEditorControl Editor
		{
			get { return editor;}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(typeof(Font),"MS UI Gothic, 9.75pt")]
		public Font Font
		{
			get { return font;}
			set { font = value;}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(typeof(XColor),"XDataGridBackColor")]
		public XColor BackColor
		{
			get { return backColor;}
			set { backColor = value;}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(typeof(XColor),"XDataGridAlternatingBackColor")]
		public XColor AlternatingBackColor
		{
			get { return alternatingBackColor;}
			set { alternatingBackColor = value;}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(typeof(XColor),"XDataGridForeColor")]
		public XColor ForeColor
		{
			get { return foreColor;}
			set { foreColor = value;}
		}
		[Browsable(true), Category("컬럼정보"),DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment ColumnAlign
		{
			get { return columnAlign;}
			set { columnAlign = value;}
		}
		[Browsable(true),Category("컬럼정보"),DefaultValue(true)]
		public bool EnterKeyToTab
		{
			get { return enterKeyToTab; }
			set { enterKeyToTab = value;}
		}
		internal bool IsEditing  //Editing중인지 여부
		{
			get { return isEditing;}
		}
		#endregion

		#region 생성자
		// 생성자
		public XDataGridColumnStyleBase()
		{
			//Width Default 100
			this.Width = 100;
			this.Alignment = HorizontalAlignment.Center;
			CreateControl();
		}
		#endregion

		/// <summary>
		/// 개별상속에서 Override가 필요한 Virtual Method 목록
		/// </summary>
		#region Virtual Method
		// Combo, Find, Check Column에서 Overide하여 설정
		protected virtual void CreateControl()
		{
		}
		//Control의 Value Set (개별상속에서 Override 필요)
		//String, Numeric, DataTime Style에서 Override 필요
		protected virtual void SetControlValue(CurrencyManager source ,int rowNum)
		{
			//Editor가 XComboBox, XCheckBox이면 DataValue설정시에 SelectedIndexChanged, CheckedChanged Event가
			//발생하지 않도록 Flag 설정, XDataGrid::ItemValueChanged Event가 2번 발생하는 것 방지
			if (Editor is XComboBox)
				((XComboBox) Editor).CallSelectedIndexChangedEvent = false;
			else if (Editor is XCheckBox)
				((XCheckBox) Editor).CallCheckedChangedEvent = false;
			Editor.DataValue = GetDataAtRow(source, rowNum);
			
			//Value 설정후 Flag Reset
			if (Editor is XComboBox)
				((XComboBox) Editor).CallSelectedIndexChangedEvent = true;
			else if (Editor is XCheckBox)
				((XCheckBox) Editor).CallCheckedChangedEvent = true;

			if (Editor is TextBox)
				((TextBox)Editor).SelectAll();
		}
		
		//개별상속에서 Override(Column Data Set)
		protected virtual object GetActualValue()
		{
			return Editor.DataValue;
		}
		//개별상속에서 Override 필요
		protected virtual string GetDisplayText(CurrencyManager source,int rowNum)
		{
			return GetDataAtRow(source,rowNum).ToString();
		}
		#endregion

		/// <summary>
		/// DataGridColumnStyle class의 abstract, virtual Method Override
		/// </summary>
		#region Override Method (Paint, Edit, Commit)
		//개별상속에서 Override 필요
		protected override void SetDataGridInColumn(DataGrid Value)
		{
			base.SetDataGridInColumn(Value);
			Control cont = (Control) Editor;
			if(cont.Parent!=Value)
			{
				if(cont.Parent!=null)
				{
					cont.Parent.Controls.Remove(cont);
				}
			}
			if(Value!=null) 
			{
				Value.Controls.Add(cont);
			}
		}
		protected override void Abort(int RowNum)
		{	
			RollBack();
			HideControl();
			EndEdit();
		}
		// Commit Changes
		protected override bool Commit(CurrencyManager dataSource,int rowNum)
		{	
			// Control Hide
			HideControl();

			// Edit상태가 아니거나, EditingPosition과 Commit Position이 다르면 Return
			// DataGrid가 Deleting 중일때도 Return
			if(!isEditing)
			{
				this.EndEdit();
				return true;
			}

			object Value = GetActualValue();
			object OrgValue = null;
			XDataGrid dataGrid = (XDataGrid) this.DataGridTableStyle.DataGrid;
			try
			{
				OrgValue = GetDataAtRow(dataSource,rowNum);
			}
			catch
			{
				OrgValue = null;
			}
			if (Value.ToString() != OrgValue.ToString())
			{
				try
				{
					//Data Set
					SetDataAtRow(dataSource, rowNum, Value);

					//Grid의 GridColumnChanged Event가 있을때 Event Invoker Call
					if (dataGrid.ExistGridColumnChangedEvent())
					{
						DataRow dtRow = dataGrid.GetDataRow(rowNum);
						if (dtRow != null)
						{
							dtRow.ClearErrors();
							GridColumnChangedEventArgs ce = new GridColumnChangedEventArgs(rowNum, this.MappingName, dtRow , Value);
							dataGrid.OnGridColumnChanged(ce);
							if (ce.Cancel)
							{
								//에러 SET
								dtRow.SetColumnError(ce.ColName, "Validation Error");
								dataGrid.ErrorCell = dataGrid.CurrentCell;
							}
						}
					}
				}
				catch (Exception e)
				{
					Debug.WriteLine("Commit Error, ColName=" + this.HeaderText + ",에러=" + e.Message);
					return true;	
				}
			}
			this.EndEdit();
			return true;
		}

		// Remove focus
		protected override void ConcedeFocus()
		{
			((Control)Editor).Visible=false;
		}
		protected override void Edit(CurrencyManager source ,int rowNum,Rectangle bounds, bool readOnly,string instantText, bool cellIsVisible)
		{	
			DataGrid grid = this.DataGridTableStyle.DataGrid;
			if (grid == null) return;
			// DataGrid가 ReadOnly이면 EditMode 불가
			if (grid.ReadOnly) return;

			//TableStyle이 ReadOnly이면 Edit불가
			if (this.DataGridTableStyle.ReadOnly) return;
			
			Control control = (Control)Editor;
			control.Text = string.Empty;
			Rectangle originalBounds = bounds;
			oldVal = control.Text;
			
			if(cellIsVisible)  // Cell을 표시하면 Control Visible
			{
				// OffSet 조정 확정필요함, Edit Mode에서 Control과 Line사이의 간격조절, Width, Height는 
				// 협의하여 결정해야함
				//Bounds.Offset(xMargin, yMargin);
				bounds.Offset(0, 0);
				//Bounds.Width -= xMargin;
				//Bounds.Height -= yMargin * 2;
				control.Bounds = bounds;
				control.Visible = true;
				control.Font = this.font;
				control.Focus();
			}
			else
			{
				control.Bounds = originalBounds;
				control.Visible = false;
				return;
			}
			
			//Set Control Value
			SetControlValue(source, rowNum);
			control.RightToLeft = this.DataGridTableStyle.DataGrid.RightToLeft;
			isEditing = true;
		}

		// 한 행의 최소높이를 가져옵니다.
		protected override int GetMinimumHeight()
		{
			// Set the minimum height to the height of the Control
			return (this.FontHeight + 8);
		}
		//열을 자동으로 크기 조정하는 데 사용된 높이를 가져옴
		protected override int GetPreferredHeight(Graphics g ,object Value)
		{
			int NewLines = 1;
			return this.FontHeight * NewLines + yMargin;
		}
		//지정한 값의 너비와 높이를 가져옴
		protected override Size GetPreferredSize(Graphics g, object Value)
		{
			Size extents = Size.Ceiling(g.MeasureString(Value.ToString(), this.DataGridTableStyle.DataGrid.Font));
			extents.Width += xMargin * 2 + this.DataGridTableGridLineWidth ;
			extents.Height += yMargin;
			return extents;
		}

		//여러 Paint Method가 있으나, 실제 Paint시 사용되는 Method는 3번째 Method
		protected override void Paint(Graphics g,Rectangle bounds,CurrencyManager source,int rowNum)
		{	
			Paint(g, bounds, source, rowNum, false);
		}
		protected override void Paint(Graphics g,Rectangle bounds,CurrencyManager source,int rowNum,bool alignToRight)
		{
			string text = GetDisplayText(source, rowNum);	
			PaintText(g, bounds, text, alignToRight);
		}
		protected override void Paint(Graphics g,Rectangle bounds,CurrencyManager source,int rowNum,Brush backBrush ,Brush foreBrush ,bool alignToRight)
		{
			Brush fBrush = null;
			Brush bBrush = null;
			Font  textFont	 = this.font;
			Color bColor = this.backColor.Color;
			Color fColor = this.foreColor.Color;
			string text = GetDisplayText(source, rowNum);
			XDataGrid aGrid = (XDataGrid)this.DataGridTableStyle.DataGrid;

			if(rowNum >= source.List.Count ) return;
			DataRow dataRow = null;
			try
			{
				dataRow = ((DataRowView) source.List[rowNum]).Row;
			}
			catch(Exception e)
			{
				Debug.WriteLine("ColumnStyle Paint Error=" + e.Message);
				return;
			}
			
			//해당행이 선택되어 있으면 Argument로 넘어온 Brush 그대로 사용
			//DataGrid에서 Selected일때 SelectedBackColor, SelectedForeColor로 Brush를 만들어 넘김
			if (aGrid.IsSelected(rowNum))
			{
				fBrush = foreBrush;
				bBrush = backBrush;
			}
			else  //선택되지 않았으면 변경한 색깔 적용 Brush 생성
			{
				//AlternatingBackColor 적용
				if (rowNum%2 != 0)
					bColor = this.alternatingBackColor.Color;
			
				fBrush = new SolidBrush(fColor);
				bBrush = new SolidBrush(bColor);
			}
			PaintText(g, bounds, text, textFont, bBrush, fBrush, alignToRight);
		}

		//지정한 행의 값을 지정한 텍스트로 업데이트 
		protected override void UpdateUI(CurrencyManager Source,int RowNum, string InstantText)
		{
			base.UpdateUI(Source,RowNum, InstantText);
		}
		#endregion

		#region Protected Virtual Method
		/// <summary>
		/// 해당 Row의 값을 return
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		protected virtual object GetDataAtRow(CurrencyManager source, int row)
		{
			if(row >= source.List.Count) return string.Empty;
			try
			{
				return GetColumnValueAtRow(source, row);
			}
			catch(Exception e)
			{
				Debug.WriteLine("GetDataAtRow, name=" + this.MappingName + ",row=" + row.ToString() + ",err=" + e.Message);
				return string.Empty;
			}
		}
		/// <summary>
		/// 해당 Row의 값을 Set
		/// </summary>
		/// <param name="row"></param>
		/// <param name="Value"></param>
		protected virtual void SetDataAtRow(CurrencyManager source, int row, object Value)
		{
			if (row >= source.List.Count) return;

			this.SetColumnValueAtRow(source, row, Value);
		}
		#endregion


		/// <summary>
		/// 컬럼 Paint, Operate 관련 Private Method(EndEdit,HideControl, PaintText..)
		/// </summary>
		#region Private Method		 
		//----------------------------------------------------------------------
		// Helper Methods 
		//----------------------------------------------------------------------
		private int DataGridTableGridLineWidth
		{
			get
			{
				if(this.DataGridTableStyle.GridLineStyle == DataGridLineStyle.Solid) 
				{ 
					return 1;
				}
				else
				{
					return 0;
				}
			}
		}
		private void EndEdit()
		{
			isEditing = false;
			// Commit 후에 TextBox Text Clear
			((Control) Editor).Text = "";
			Invalidate();
		}

		private void HideControl()
		{
			Control control = (Control)Editor;
			if(control.Focused)
			{
				this.DataGridTableStyle.DataGrid.Focus();
			}
			control.Visible = false;
		}

		private void RollBack()
		{
			((Control)Editor).Text = oldVal;
		}
		private void PaintText(Graphics g ,Rectangle bounds,string text,bool alignToRight)
		{
			Brush bBrush = new SolidBrush(this.backColor.Color);
			Brush fBrush = new SolidBrush(this.foreColor.Color);
			PaintText(g, bounds, text, this.font , bBrush, fBrush, alignToRight);
			bBrush.Dispose();
			fBrush.Dispose();
		}
		//Column에 Text Setting시 사용되는 Method
		private void PaintText(Graphics g , Rectangle textBounds, string text, Font font, Brush backBrush,Brush foreBrush,bool alignToRight)
		{	
			Rectangle textRect = textBounds;

			g.FillRectangle(backBrush, textRect);
			//ColumnImage Draw
			if (ColumnImage != null)
			{
				ContentAlignment imageAlign = ContentAlignment.MiddleLeft;
				if (text == "")
					imageAlign = ContentAlignment.MiddleCenter;
				PointF imagePoint = GetObjAlignment(imageAlign, textRect.Left, textRect.Top, textRect.Width, textRect.Height, ColumnImage.Width, ColumnImage.Height);
				RectangleF imageRect = new RectangleF((float) textRect.X, (float) textRect.Y, (float) textRect.Width, (float) textRect.Height);
				imageRect.Intersect(new RectangleF(imagePoint, ColumnImage.PhysicalDimension));
				//Truncate the Rectangle for appreximation problem
				g.DrawImage(ColumnImage,Rectangle.Truncate(imageRect));
				//Left이면 ImageSize만큼 textRect 이동
				if (imageAlign == ContentAlignment.MiddleLeft)
				{
					textRect.X += ColumnImage.Width;
					textRect.Width -= ColumnImage.Width;
				}
			}
			
			if (text.Length > 0)
			{
				StringFormat format = new StringFormat();
				if(alignToRight)
				{
					format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
				}
				switch(this.columnAlign)
				{
					case HorizontalAlignment.Left:
						format.Alignment = StringAlignment.Near;
						break;
					case HorizontalAlignment.Right:
						format.Alignment = StringAlignment.Far;
						break;
					case HorizontalAlignment.Center:
						format.Alignment = StringAlignment.Center;
						break;
				}
			
				format.FormatFlags =StringFormatFlags.NoWrap;
				format.Trimming = StringTrimming.EllipsisCharacter;
				format.LineAlignment = StringAlignment.Center;

				g.DrawString(text, font, foreBrush, textRect, format);
				format.Dispose();
			}
		}
		#endregion

		#region GetObjAlignment
		private PointF GetObjAlignment(ContentAlignment align, int clientLeft, int clientTop, int clientWidth, int clientHeight, float objWidth, float objHeight)
		{
			//default X left
			PointF l_pointf = new PointF((float)clientLeft,(float)clientTop);

			//Y
			if (align == ContentAlignment.TopCenter ||
				align == ContentAlignment.TopLeft ||
				align == ContentAlignment.TopRight) //Y Top
				l_pointf.Y = (float)clientTop;
			else if (align == ContentAlignment.BottomCenter ||
				align == ContentAlignment.BottomLeft ||
				align == ContentAlignment.BottomRight) //Y bottom
				l_pointf.Y = (float)clientTop + ((float)clientHeight) - objHeight;
			else //default Y middle
				l_pointf.Y = (float)clientTop + ((float)clientHeight)/2.0F - objHeight/2.0F;

			if ( align == ContentAlignment.BottomCenter ||
				align == ContentAlignment.MiddleCenter ||
				align == ContentAlignment.TopCenter)//X Center
				l_pointf.X = (float)clientLeft + ((float)clientWidth)/2.0F - objWidth/2.0F;
			else if (align == ContentAlignment.BottomRight ||
				align == ContentAlignment.MiddleRight ||
				align == ContentAlignment.TopRight)//X Right
				l_pointf.X = (float)clientLeft + (float)clientWidth - objWidth;
			//middle default already set

			return l_pointf;
		}
		#endregion

	}
	#endregion

	#region XDataGridStringTextBoxColumn
	public class XDataGridStringTextBoxColumn : XDataGridColumnStyleBase
	{
		#region Class Fields
		private XEditMask editor = null;
		private string mask = "";
		private ColumnImeMode imeMode = ColumnImeMode.None;
		private int maxLength = 30;
		#endregion
		
		#region Base Properties
		[Browsable(false)]
		public override IEditorControl Editor
		{
			get { return editor;}
		}
		#endregion

		#region Properties
		[Browsable(true), Category("컬럼정보"), DefaultValue(30)]
		public int MaxLength
		{
			get { return maxLength;}
			set { maxLength = Math.Max(value,0);}
		}
		[Browsable(true), Category("컬럼정보"), DefaultValue(ColumnImeMode.None)]
		public ColumnImeMode ImeMode
		{
			get { return imeMode;}
			set { imeMode = value;}
		}
		[Browsable(true), Category("컬럼정보"), DefaultValue("")]
		public string Mask
		{
			get { return mask;}
			set 
			{ 
				if (mask != value)
				{
					//Mask 유효성 Check
					string errMsg = "";
					if (!MaskHelper.IsValidMask(MaskType.String, value, out errMsg))
					{
						MessageBox.Show(errMsg, "마스크유효성 체크");
						return;
					}
					mask = value;
				}
			}
		}
		#endregion

		#region 생성자
		public XDataGridStringTextBoxColumn()
		{
            // MED-14286
            if (NetInfo.Language == LangMode.Jr)
            {
                this.Font = new Font("MS UI Gothic", 9.75f);
            }
            else
            {
                this.Font = Service.COMMON_FONT;
            }
		}
		#endregion

		/// <summary>
		/// Override Method (IcmDataGridControlColumnBase에 정의된 개별상속에서 Override해야할 Method 목록입니다.)
		/// </summary>
		#region Override Method (CreateControl, GetDisplayText) 
		protected override void CreateControl()
		{
			editor = new XEditMask();
			editor.Visible = false;
		}
		protected override  string GetDisplayText(CurrencyManager source,int rowNum)
		{
			//EditMask가 있으면 MaskSeperator를 포함한 Text로 display
			if(this.editor.Mask != "")
				return this.editor.GetDisplayText(GetDataAtRow(source,rowNum).ToString());
			else
				return GetDataAtRow(source,rowNum).ToString();	
		}
		#endregion
	}
	#endregion

	#region XDataGridNumericTextBoxColumn
	public class XDataGridNumericTextBoxColumn : XDataGridColumnStyleBase
	{
		#region Class Fields
		private XEditMask editor = null;
		private int decimalDigits = 0;
		private bool minusAccept = false;
		private int maxinumCipher = 12;
		#endregion
		
		#region Base Properties
		[Browsable(false)]
		public override IEditorControl Editor
		{
			get { return editor;}
		}
		#endregion

		#region Property
		
		[Browsable(true), Category("컬럼정보"), DefaultValue(0)]
		public int DecimalDigits
		{
			get { return decimalDigits;}
			set { decimalDigits = Math.Max(0,value);}
		}
		[Browsable(true), Category("컬럼정보"), DefaultValue(false)]
		public bool	MinusAccept
		{
			get { return minusAccept;}
			set { minusAccept = value;}
		}
		[Browsable(true), Category("컬럼정보"), DefaultValue(12)]
		public int MaxinumCipher
		{
			get { return maxinumCipher;}
			set { maxinumCipher = ((value > 12) ? 12 : ((value <= 0) ? 12 : value));}
		}
		#endregion

		#region 생성자
		public XDataGridNumericTextBoxColumn()
		{
			this.ColumnAlign = HorizontalAlignment.Right;
		}
		#endregion
		
		/// <summary>
		/// Override Method 
		/// </summary>
		#region Override Method (CreateControl, GetDisplayText) 
		protected override void CreateControl()
		{
			editor = new XEditMask();
			editor.Visible = false;
		}

		protected override  string GetDisplayText(CurrencyManager source,int rowNum)
		{
			object data = GetDataAtRow(source,rowNum);
			try
			{
				//Number형은 모두 Double로 Convert하여 Text Get
				if (data == DBNull.Value) return "";
				if (data.ToString() == string.Empty) return "";

				return Convert.ToDouble(data).ToString("n" + this.DecimalDigits.ToString());
			}
			catch(Exception e)
			{
				Debug.WriteLine("NumericColumn::GetDisplayText Error=" + e.Message + ",data=" + data.ToString());
				return "";
			}
		}
		#endregion
	}
	#endregion

	#region XDataGridDateTimeTextBoxColumn
	// DateTimeTextBoxColumn Inhert
	public class XDataGridDateTimeTextBoxColumn : XDataGridColumnStyleBase
	{
		#region Class Fields
		private XEditMask editor = null;
		private string	mask = "YYYY/MM/DD";
		private bool	isDateTime = false;  //DateTime형인지 여부
		#endregion
		
		#region Base Properties
		[Browsable(false)]
		public override IEditorControl Editor
		{
			get { return editor;}
		}
		#endregion

		#region Properties
		[Browsable(true), Category("컬럼정보"), DefaultValue(false)]
		public bool IsDateTime
		{
			get { return isDateTime;}
			set 
			{ 
				isDateTime = value;
				if (value)
					this.Mask = "YYYY/MM/DD HH:MI:SS";
				else
					this.Mask = "YYYY/MM/DD";
			}
		}
		[Browsable(true), Category("컬럼정보"), DefaultValue("YYYY/MM/DD")]
		public string Mask
		{
			get { return mask;}
			set 
			{ 
				if (mask != value)
				{
					//Mask 유효성 Check
					string errMsg = "";
					MaskType maskType = MaskType.Date;
					if (this.isDateTime)
						maskType = MaskType.DateTime;

					if (!MaskHelper.IsValidMask(maskType, value, out errMsg))
					{
						MessageBox.Show(errMsg, "마스크유효성 체크");
						return;
					}
					mask = value;
				}
			}
		}
		#endregion
		
		#region 생성자
		public XDataGridDateTimeTextBoxColumn()
		{
			this.ColumnAlign = HorizontalAlignment.Center;
		}
		#endregion
		
		#region Override Method (CreateControl, GetDisplayText)
		protected override void CreateControl()
		{
			editor = new XEditMask();
			editor.Visible = false;
		}
		protected override  string GetDisplayText(CurrencyManager source,int rowNum)
		{
			//EditMask가 있으면 MaskSeperator를 포함한 Text로 display
			if(this.editor.Mask != "")
				return this.editor.GetDisplayText(GetDataAtRow(source,rowNum).ToString());
			else
				return GetDataAtRow(source,rowNum).ToString();
		}
		protected override object GetActualValue()
		{
			//Editor의 DataValue는 YYYYMMDD형으로 String을 Return
			//ColumnType에 따라서, String형이면 그대로, DateTime형이면 DateTime으로 Convert하여 Return
			if (Editor.DataValue.ToString() == "") return DBNull.Value;

			if ((this.DataGridTableStyle != null) && (this.DataGridTableStyle.DataGrid != null) && (this.DataGridTableStyle.DataGrid.DataSource != null))
			{
				if (this.DataGridTableStyle.DataGrid.DataSource is DataTable)
				{
					if (((DataTable)this.DataGridTableStyle.DataGrid.DataSource).Columns.Contains(this.MappingName))
					{
						//DateTime형이면 DataValue Convert
						if (((DataTable)this.DataGridTableStyle.DataGrid.DataSource).Columns[this.MappingName].DataType.Equals(typeof(DateTime)))
						{
							string data = Editor.DataValue.ToString();
							if (this.IsDateTime)
							{
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
								else
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
							}
							else
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
						else
							return Editor.DataValue;
					}
					else
						return Editor.DataValue;

				}
				else
					return Editor.DataValue;
			}
			else
				return Editor.DataValue;
		}
		#endregion
	} 
	#endregion

	#region XDataGridCheckBoxColumn
	public class XDataGridCheckBoxColumn : XDataGridColumnStyleBase
	{
		#region Fields
		private XCheckBox editor = null;
		private string checkedValue = "Y";
		private string unCheckedValue = "N";
		private string checkedText = "";
		private string unCheckedText = "";
		private Image checkImage = null;
		private Image unCheckImage = null;
		#endregion

		#region Properties
		[Browsable(false)]
		public override IEditorControl Editor
		{
			get { return editor;}
		}
		[Browsable(true),Category("컬럼정보"),DefaultValue("Y")]
		public string CheckedValue
		{
			get	{return checkedValue;}
			set	{checkedValue = value;}
		}
		[Browsable(true),Category("컬럼정보"),DefaultValue("N")]
		public string UnCheckedValue
		{
			get	{return unCheckedValue;}
			set	{unCheckedValue = value;}
		}
		[Browsable(true),Category("컬럼정보"),DefaultValue("")]
		public string CheckedText
		{
			get	{return checkedText;}
			set { checkedText = value;}
		}
		[Browsable(true),Category("컬럼정보"),DefaultValue("")]
		public string UnCheckedText
		{
			get	{return unCheckedText;}
			set { unCheckedText = value;}
		}
		#endregion

		#region 생성자
		public XDataGridCheckBoxColumn()
		{
			//ImageGet
			Bitmap bmp = (Bitmap) DrawHelper.CheckIcon;
			bmp.MakeTransparent();
			checkImage = bmp;
			bmp = (Bitmap) DrawHelper.UnCheckIcon;
			bmp.MakeTransparent();
			unCheckImage = bmp;
		}
		#endregion

		/// <summary>
		/// Override Method
		/// </summary>
		#region Override Method (CreateControl, SetControlValue, GetActualValue, GetDisplayText) 
		protected override void CreateControl()
		{
			editor = new XCheckBox();
			editor.Visible = false;
			//editor.BackColor = Color.FloralWhite;
			editor.BackColor = XColor.XCheckBoxBackColor;
		}
		protected override  string GetDisplayText(CurrencyManager source,int rowNum)
		{
			string Value = GetDataAtRow(source, rowNum).ToString();
			if(Value == this.CheckedValue)
			{
				this.ColumnImage = this.checkImage;
				return this.checkedText;
			}
			else
			{
				this.ColumnImage = this.unCheckImage;
				return this.unCheckedText;
			}
		}
		#endregion

		#region TogglingCheckState
		internal void TogglingCheckState()
		{
			//Click을 통해 Edit모드로 전환시에 Check상태 변경
			if (this.isEditing)
				this.editor.Checked = !this.editor.Checked;
		}
		#endregion

	}
	#endregion

	#region XDataGridComboBoxColumn
	public class XDataGridComboBoxColumn : XDataGridColumnStyleBase
	{
		#region Fields
		private XComboBox editor = null;
		private XComboItemCollection comboItems = new XComboItemCollection();
		private ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDownList;
		private int maxDropDownItems = 8;
		#endregion

		#region Properties
		[Browsable(false)]
		public override IEditorControl Editor
		{
			get { return editor;}
		}
		[Browsable(true), Category("컬럼정보")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public XComboItemCollection ComboItems
		{
			get { return comboItems;}
		}
		[Browsable(true), Category("컬럼정보"),
		DefaultValue(ComboBoxStyle.DropDownList)]
		public ComboBoxStyle DropDownStyle
		{
			get { return dropDownStyle;}
			set { dropDownStyle = value;}
		}
		[Browsable(true), Category("컬럼정보"),
		DefaultValue(8)]
		public int MaxDropDownItems
		{
			get { return maxDropDownItems;}
			set { maxDropDownItems = Math.Max(8,value);}
		}
		#endregion

		#region 생성자
		public XDataGridComboBoxColumn(){}
		#endregion

		/// <summary>
		/// Override Method (IcmDataGridControlColumnBase에 정의된 개별상속에서 Override해야할 Method 목록입니다.)
		/// </summary>
		#region Override Method (CreateControl, GetDisplayText) 

		protected override void CreateControl()
		{
			editor = new XComboBox();
			editor.Visible = false;
		}
		
		protected override  string GetDisplayText(CurrencyManager source,int rowNum)
		{
			string Value = GetDataAtRow(source, rowNum).ToString();
			string dispText = string.Empty;
			if(Value != string.Empty)
			{
				//DropDown형식은 Value가 ComboItems에 없으면 DisplayText에 Value SET
				if (this.dropDownStyle == ComboBoxStyle.DropDown)
				{
					bool found = false;
					foreach (XComboItem colItem in editor.ComboItems)
					{  
						if (colItem.ValueItem.Equals(Value))
						{
							dispText = colItem.DisplayItem;
							found = true;
							break;
						}
					}
					if (!found)
						dispText = Value;
				}
				else
				{
					// Value = ValueItem임으로 이를 DisplayItem로 확인하여 Display
					foreach (XComboItem colItem in editor.ComboItems)
					{  
						if (colItem.ValueItem.Equals(Value))
						{
							dispText = colItem.DisplayItem;
							break;
						}
					}
				}
			}
			return dispText;
		}
		#endregion

	}
	#endregion
}