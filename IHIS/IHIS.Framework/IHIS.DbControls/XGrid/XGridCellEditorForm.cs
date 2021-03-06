using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Data;

namespace IHIS.Framework
{
	/// <summary>
	/// XGridCellEditorForm에 대한 요약 설명입니다.
	/// </summary>
	public class XGridCellEditorForm : System.Windows.Forms.Form
	{
		private XGrid grid = null;
		private IServiceProvider provider = null;
		private bool isLoading = false;
		private ArrayList posArray = new ArrayList();  //중간이 비거나, 없는 pos의 위치저장(1,2-> 12형식으로 저장함)
		private ArrayList spanPosArray = new ArrayList();
		private Hashtable infoIndices = new Hashtable();
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XDataGrid cellInfoGrid;

		//cellInfoCollection 정보
		private XGridCellCollection cellInfos;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XButton btnAdd;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XTextBox txtLine;
		private IHIS.Framework.XTextBox txtCol;
		private System.Windows.Forms.Label label2;
		private System.Data.DataSet dataSet1;
		private System.Data.DataTable dataTable1;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn8;
		private System.Data.DataColumn dataColumn9;
		private System.Data.DataColumn dataColumn10;
		private IHIS.Framework.XDataGridTableStyle aDataGridTableStyle1;
		private IHIS.Framework.XDataGridStringTextBoxColumn aDataGridStringTextBoxColumn1;
		private IHIS.Framework.XDataGridStringTextBoxColumn aDataGridStringTextBoxColumn2;
		private IHIS.Framework.XDataGridComboBoxColumn aDataGridComboBoxColumn1;
		private IHIS.Framework.XDataGridCheckBoxColumn aDataGridCheckBoxColumn1;
		private IHIS.Framework.XDataGridComboBoxColumn aDataGridComboBoxColumn2;
		private IHIS.Framework.XButton btnUp;
		private IHIS.Framework.XButton btnDown;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataColumn dataColumn12;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// XGridCellEditorForm 생성자
		/// </summary>
		/// <param name="instance"> 컬렉션을 관리하는 개체 </param>
		/// <param name="cellInfos"> XGridCellCollection (컬럼정보) </param>
		public XGridCellEditorForm(object instance, XGridCellCollection cellInfos)
			: this(instance, cellInfos, null)
		{
		}

		/// <summary>
		/// XGridCellEditorForm 생성자
		/// </summary>
		/// <param name="instance"> 컬렉션을 관리하는 개체 </param>
		/// <param name="cellInfos"> XGridCellCollection (컬럼정보) </param>
		/// <param name="provider"> 서비스를 얻는 데 사용할 수 있는 IServiceProvider</param>
		public XGridCellEditorForm(object instance, XGridCellCollection cellInfos, IServiceProvider provider)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.cellInfos = cellInfos;  // cellInfo Set

			//Init
			posArray.Clear();
			spanPosArray.Clear();
			infoIndices.Clear();

			this.grid = (XGrid) instance;
			this.provider = provider;

			this.txtLine.Text = grid.LinePerRow.ToString();
			this.txtCol.Text  = grid.ColPerLine.ToString();

			//Line이 한줄이면 txtCol은 수정불가
			if (grid.LinePerRow == 1)
				this.txtCol.Enabled = false;

			//ComboColumn SET(CellType, TextAlignment)
			foreach (string item in Enum.GetNames(typeof(XCellDataType)))
			{
				this.aDataGridComboBoxColumn1.ComboItems.Add(item, item);
				((XComboBox)this.aDataGridComboBoxColumn1.Editor).ComboItems.Add(item,item);
			}
			foreach (string item in Enum.GetNames(typeof(ContentAlignment)))
			{
				this.aDataGridComboBoxColumn2.ComboItems.Add(item, item);
				((XComboBox)this.aDataGridComboBoxColumn2.Editor).ComboItems.Add(item,item);
			}

			//HeaderText MultiLine가능
			((XEditMask) aDataGridStringTextBoxColumn2.Editor).Multiline = true;

			//dataTable1 Default View
			this.dataTable1.DefaultView.AllowNew = false;
		}

		#region Private Method
		
		// 컬럼정보 입력시 확인사항
		// 1.cellName 필수입력
		// 2.String Type은 ColLen  0 불가
		// 3.ColName 중복입력 불가 (중복여부는 colName을 KEY로 지정하였으므로 따로 Check하지 않아도 Check 됨)
		// 4.Combo,DropDown형은 String만 가능
		private bool CheckValidation()
		{
			string	cellName = "";
			string	headerText = "";
			bool	isVisible = true;
			int rowCount = this.dataTable1.Rows.Count;
			int visibleCellCnt  = 0;
			int headerRowCount = 0;
			int linePerRow = 0;
			int colPerLine = 0;
			DataRow dtRow = null;
			XGridHeader[] origHeaderInfos;
			XGridComputedCell[] origComputedInfos;
			IDesignerHost host = null;
			if (provider != null)
			{
				host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
			}
			if (rowCount < 1)
			{
				
				grid.ColPerLine = 0;
				grid.HeaderHeights.Clear();
				if ((grid.HeaderInfos.Count > 0) && (host != null))
				{
					origHeaderInfos = new XGridHeader[grid.HeaderInfos.Count];
					for(int i = 0 ; i < grid.HeaderInfos.Count ; i++)
						origHeaderInfos[i] = grid.HeaderInfos[i];
					grid.AddedHeaderLine = 0;
					grid.HeaderInfos.Clear();

					foreach(XGridHeader info in origHeaderInfos)
						host.DestroyComponent(info);
				}
				if ((grid.ComputedCellInfos.Count > 0) && (host != null))
				{
					origComputedInfos = new XGridComputedCell[grid.ComputedCellInfos.Count];
					for(int i = 0 ; i < grid.ComputedCellInfos.Count ; i++)
						origComputedInfos[i] = grid.ComputedCellInfos[i];
					foreach(XGridComputedCell info in origComputedInfos)
						host.DestroyComponent(info);
				}
				return true;
			}

			for(int i = 0; i < rowCount ; i++)
			{
				dtRow = this.dataTable1.Rows[i];
				cellName = this.dataTable1.Rows[i]["cellName"].ToString();
				headerText = this.dataTable1.Rows[i]["headerText"].ToString();
				isVisible = GetBool(this.dataTable1.Rows[i]["isVisible"].ToString());
				if( cellName.Trim() == "")
				{
					MessageBox.Show("컬럼이름을 반드시 입력하십시오");
					this.cellInfoGrid.SetFocusToItem(i, "cellName");
					return false;
				}

				//NonVisible Column은 row, col -1 Set, ColSpan,RowSpan 1 SET
				if (!isVisible)
				{
					this.dataTable1.Rows[i]["row"] = -1;
					this.dataTable1.Rows[i]["col"] = -1;
					this.dataTable1.Rows[i]["rowSpan"] = 1;
					this.dataTable1.Rows[i]["colSpan"] = 1;
				}
				//VisibleCellCnt++
				if (isVisible)
					visibleCellCnt++;
			}
			// LinePerRow는 1이상이어야함
			if (!TypeCheck.IsInt(txtLine.Text))
			{
				MessageBox.Show("한 Row의 Line수는 1이상이어야 합니다.");
				return false;
			}
			else if (Int32.Parse(txtLine.Text) < 1)
			{
				MessageBox.Show("한 Row의 Line수는 1이상이어야 합니다.");
				return false;
			}

			// Line이 1이면 txtCol은 Visible 컬럼수만큼 Set
			if (Int32.Parse(txtLine.Text) == 1)
				txtCol.Text = visibleCellCnt.ToString();

			//ColPerLine은 1이상이어야함
			if(!TypeCheck.IsInt(txtCol.Text))
			{
				MessageBox.Show("한 Line의 컬럼수는 1이상이어야 합니다.");
				return false;
			}
			else if (Int32.Parse(txtCol.Text) < 1)
			{
				MessageBox.Show("한 Line의 컬럼수는 1이상이어야 합니다.");
				return false;
			}
			
			linePerRow = Int32.Parse(txtLine.Text);
			colPerLine = Int32.Parse(txtCol.Text);

			// LinePerRow * ColPerLine >= visibleCellCnt
			if (linePerRow * colPerLine < visibleCellCnt)
			{
				MessageBox.Show("Row의 Line수 * Line당 컬럼수는 Visible한 컬럼의 갯수보다 커야합니다.");
				return false;
			}
			// visibleCelCnt는 colPerLine * (linePerRow -1) 보다 커야함
			// ex > linePerRow = 3, colPerLine = 3 이면 visible한 컬럼은 3* 2 = 6보다는 커야함
			if (visibleCellCnt <= colPerLine * (linePerRow -1))
			{
				MessageBox.Show("Visible한 컬럼의 갯수는 (Row의 Line수 -1)*Line당 컬럼수보다 커야합니다.");
				return false;
			}

			//visibleCellCnt가 0이면 기존에 추가된 Header정보 Remove
			if (visibleCellCnt <= 0)
			{
				grid.ColPerLine = 0;
				grid.HeaderHeights.Clear();
				if ((grid.HeaderInfos.Count > 0) && (host != null))
				{
					origHeaderInfos = new XGridHeader[grid.HeaderInfos.Count];
					for(int i = 0 ; i < grid.HeaderInfos.Count ; i++)
						origHeaderInfos[i] = grid.HeaderInfos[i];
					grid.AddedHeaderLine = 0;
					grid.HeaderInfos.Clear();

					foreach(XGridHeader info in origHeaderInfos)
						host.DestroyComponent(info);
				}
				if ((grid.ComputedCellInfos.Count > 0) && (host != null))
				{
					origComputedInfos = new XGridComputedCell[grid.ComputedCellInfos.Count];
					for(int i = 0 ; i < grid.ComputedCellInfos.Count ; i++)
						origComputedInfos[i] = grid.ComputedCellInfos[i];
					foreach(XGridComputedCell info in origComputedInfos)
						host.DestroyComponent(info);
				}
				return true;
			}
			
			// LinePerRow와 컬럼에 따라 CellInfo의 row,col정하기
			// 이미 Apperance에서 지정된 row, col는 그대로 두고, -1일 경우에만 빈자리를 채움
			// Line 2,컬럼갯수 8이면 (0,0) ~ ( 1,3)까지로 row, col를 정해야함
			int row, col;
			int rowSpan, colSpan;
			int startCol,endCol;
			
			grid.LinePerRow = linePerRow;
			grid.ColPerLine = colPerLine;

			// RowHeaderVisible이면 Cell의 YPos는 1부터 시작 ColPerLine까지, 
			// Not visible이면 0 부터 시작 ColPerLine -1 까지
			if (grid.RowHeaderVisible)
			{
				startCol = 1;
				endCol = grid.ColPerLine + 1;
			}
			else
			{
				startCol = 0;
				endCol = grid.ColPerLine ;
			}

			// 추가된 Header정보, ComputedCell정보 변경
			// 1.기존에 추가된 Header의 Col >= endCol이면 해당 info Remove
			// Col + ColSpan > endCol이면 ColSpan 조정
			ArrayList removeHeaderInfos = new ArrayList();
			ArrayList removeComputeInfos = new ArrayList();
			foreach (XGridHeader info in grid.HeaderInfos)
			{
				if (info.Col >= endCol)
					removeHeaderInfos.Add(info);
				else if (info.Col + info.ColSpan > endCol)
					info.ColSpan = Math.Max(1, endCol - info.Col);
			}
			foreach (XGridHeader info in removeHeaderInfos)
			{
				//추가 Header정보는 바로 Destroy하여 Designer에 의해 다른 Property가 반영되도록 함
				if (host != null)
					host.DestroyComponent(info);
				
			}

			foreach (XGridComputedCell info in grid.ComputedCellInfos)
			{
				if (info.Col >= endCol)
					removeComputeInfos.Add(info);
				else if (info.Col + info.ColSpan > endCol)
					info.ColSpan = Math.Max(1, endCol - info.Col);
			}
			foreach (XGridComputedCell info in removeComputeInfos)
			{
				grid.ComputedCellInfos.Remove(info);
				if (host != null)
					host.DestroyComponent(info);
			}

			// Header의 Line수 = 추가Header Line 수 + LinePerRow
			headerRowCount = grid.AddedHeaderLine + grid.LinePerRow;

			// Header추가할 위치 저장
			for (int k = grid.AddedHeaderLine ; k < grid.LinePerRow + grid.AddedHeaderLine ; k++)
				for (int g = startCol ; g < endCol ; g++)
					posArray.Add(k.ToString() + "," + g.ToString());

			for (int  j = 0; j < rowCount; j++)
			{
				dtRow = this.dataTable1.Rows[j];
				row = Int32.Parse(this.dataTable1.Rows[j]["row"].ToString());
				col = Int32.Parse(this.dataTable1.Rows[j]["col"].ToString());
				rowSpan = Int32.Parse(this.dataTable1.Rows[j]["rowSpan"].ToString());
				colSpan = Int32.Parse(this.dataTable1.Rows[j]["colSpan"].ToString());
				isVisible = GetBool(this.dataTable1.Rows[j]["isVisible"].ToString());
				if (isVisible)
				{
					// 정상적인 Display정보일때 posArray에서 제거
					if ((row != -1) && (col != -1) && (row < headerRowCount) && (col < endCol))
					{
						//row + rowSpan > headerRowCount 이면 rowSpan 조정
						if (row + rowSpan > headerRowCount)
						{
							rowSpan = Math.Max(1, headerRowCount - row);
							this.dataTable1.Rows[j]["rowSpan"] = rowSpan;
						}
						//col + colSpan > endCol 이면 colSpan 조정
						if (col + colSpan > endCol)
						{
							colSpan = Math.Max(1, endCol - col);
							this.dataTable1.Rows[j]["colSpan"] = colSpan;
						}
						// posArray에서 info.Row, info.Col인 List 제거, RowSpan, ColSpan도 고려하여 사이에 있는 값은 제거
						for ( int r = row ; r < row + rowSpan ; r ++)
						{
							for (int c = col ; c < col + colSpan ; c++)
							{
								posArray.Remove(r.ToString() + "," + c.ToString());
								//Span된 위치에 있는 Cell정보 보관 (r,c, row, col)
								if ((r > row) || (c > col))
								{
									spanPosArray.Add(r.ToString() + "," + c.ToString() + "," + row.ToString() + "," + col.ToString());
									if (!infoIndices.ContainsKey(row.ToString() + "," + col.ToString()))
										// row, col과 Grid에서의 RowNumber 저장
										infoIndices.Add(row.ToString() + "," + col.ToString(), j);
								}
								
							}
						}
					}
				}
			}
			return true;
		}

		#endregion

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new IHIS.Framework.XButton();
			this.btnOK = new IHIS.Framework.XButton();
			this.cellInfoGrid = new IHIS.Framework.XDataGrid();
			this.dataTable1 = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataColumn6 = new System.Data.DataColumn();
			this.dataColumn7 = new System.Data.DataColumn();
			this.dataColumn8 = new System.Data.DataColumn();
			this.dataColumn9 = new System.Data.DataColumn();
			this.dataColumn10 = new System.Data.DataColumn();
			this.dataColumn11 = new System.Data.DataColumn();
			this.dataColumn12 = new System.Data.DataColumn();
			this.aDataGridTableStyle1 = new IHIS.Framework.XDataGridTableStyle();
			this.aDataGridStringTextBoxColumn1 = new IHIS.Framework.XDataGridStringTextBoxColumn();
			this.aDataGridStringTextBoxColumn2 = new IHIS.Framework.XDataGridStringTextBoxColumn();
			this.aDataGridComboBoxColumn1 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.aDataGridCheckBoxColumn1 = new IHIS.Framework.XDataGridCheckBoxColumn();
			this.aDataGridComboBoxColumn2 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.btnDelete = new IHIS.Framework.XButton();
			this.btnAdd = new IHIS.Framework.XButton();
			this.label1 = new System.Windows.Forms.Label();
			this.txtLine = new IHIS.Framework.XTextBox();
			this.txtCol = new IHIS.Framework.XTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dataSet1 = new System.Data.DataSet();
			this.btnUp = new IHIS.Framework.XButton();
			this.btnDown = new IHIS.Framework.XButton();
			((System.ComponentModel.ISupportInitialize)(this.cellInfoGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(654, 256);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(80, 28);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "취  소";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(566, 256);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 28);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "확  인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// cellInfoGrid
			// 
			this.cellInfoGrid.CaptionVisible = false;
			this.cellInfoGrid.DataSource = this.dataTable1;
			this.cellInfoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cellInfoGrid.Location = new System.Drawing.Point(5, 5);
			this.cellInfoGrid.Name = "cellInfoGrid";
			this.cellInfoGrid.Size = new System.Drawing.Size(728, 246);
			this.cellInfoGrid.TabIndex = 1;
			this.cellInfoGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									 this.aDataGridTableStyle1});
			this.cellInfoGrid.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.cellInfoGrid_GridColumnChanged);
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dataColumn1,
																			  this.dataColumn2,
																			  this.dataColumn3,
																			  this.dataColumn4,
																			  this.dataColumn5,
																			  this.dataColumn6,
																			  this.dataColumn7,
																			  this.dataColumn8,
																			  this.dataColumn9,
																			  this.dataColumn10,
																			  this.dataColumn11,
																			  this.dataColumn12});
			this.dataTable1.TableName = "cellInfo";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "cellName";
			this.dataColumn1.DefaultValue = "";
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "headerText";
			this.dataColumn2.DefaultValue = "";
			// 
			// dataColumn3
			// 
			this.dataColumn3.ColumnName = "cellType";
			this.dataColumn3.DefaultValue = "String";
			// 
			// dataColumn4
			// 
			this.dataColumn4.ColumnName = "isVisible";
			this.dataColumn4.DefaultValue = "Y";
			// 
			// dataColumn5
			// 
			this.dataColumn5.ColumnName = "textAlignment";
			this.dataColumn5.DefaultValue = "MiddleLeft";
			// 
			// dataColumn6
			// 
			this.dataColumn6.ColumnName = "row";
			this.dataColumn6.DataType = typeof(int);
			this.dataColumn6.DefaultValue = -1;
			// 
			// dataColumn7
			// 
			this.dataColumn7.ColumnName = "col";
			this.dataColumn7.DataType = typeof(int);
			this.dataColumn7.DefaultValue = -1;
			// 
			// dataColumn8
			// 
			this.dataColumn8.ColumnName = "rowSpan";
			this.dataColumn8.DataType = typeof(int);
			this.dataColumn8.DefaultValue = 1;
			// 
			// dataColumn9
			// 
			this.dataColumn9.ColumnName = "colSpan";
			this.dataColumn9.DataType = typeof(int);
			this.dataColumn9.DefaultValue = 1;
			// 
			// dataColumn10
			// 
			this.dataColumn10.ColumnName = "originalSeq";
			this.dataColumn10.DataType = typeof(int);
			this.dataColumn10.DefaultValue = -1;
			// 
			// dataColumn11
			// 
			this.dataColumn11.ColumnName = "origCellType";
			this.dataColumn11.DefaultValue = "";
			// 
			// dataColumn12
			// 
			this.dataColumn12.ColumnName = "mask";
			this.dataColumn12.DefaultValue = "";
			// 
			// aDataGridTableStyle1
			// 
			this.aDataGridTableStyle1.DataGrid = this.cellInfoGrid;
			this.aDataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												   this.aDataGridStringTextBoxColumn1,
																												   this.aDataGridStringTextBoxColumn2,
																												   this.aDataGridComboBoxColumn1,
																												   this.aDataGridCheckBoxColumn1,
																												   this.aDataGridComboBoxColumn2});
			this.aDataGridTableStyle1.MappingName = "cellInfo";
			// 
			// aDataGridStringTextBoxColumn1
			// 
			this.aDataGridStringTextBoxColumn1.HeaderText = "Name";
			this.aDataGridStringTextBoxColumn1.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
			this.aDataGridStringTextBoxColumn1.MappingName = "cellName";
			this.aDataGridStringTextBoxColumn1.Width = 170;
			// 
			// aDataGridStringTextBoxColumn2
			// 
			this.aDataGridStringTextBoxColumn2.HeaderText = "HeaderText";
			this.aDataGridStringTextBoxColumn2.ImeMode = IHIS.Framework.ColumnImeMode.Han;
			this.aDataGridStringTextBoxColumn2.MappingName = "headerText";
			this.aDataGridStringTextBoxColumn2.Width = 200;
			// 
			// aDataGridComboBoxColumn1
			// 
			this.aDataGridComboBoxColumn1.HeaderText = "Type";
			this.aDataGridComboBoxColumn1.MappingName = "cellType";
			// 
			// aDataGridCheckBoxColumn1
			// 
			this.aDataGridCheckBoxColumn1.HeaderText = "Visible";
			this.aDataGridCheckBoxColumn1.MappingName = "isVisible";
			this.aDataGridCheckBoxColumn1.Width = 60;
			// 
			// aDataGridComboBoxColumn2
			// 
			this.aDataGridComboBoxColumn2.HeaderText = "TextAlignment";
			this.aDataGridComboBoxColumn2.MappingName = "textAlignment";
			this.aDataGridComboBoxColumn2.Width = 150;
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Location = new System.Drawing.Point(256, 256);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDelete.Size = new System.Drawing.Size(80, 28);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(168, 256);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(80, 28);
			this.btnAdd.TabIndex = 4;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label1.Location = new System.Drawing.Point(6, 256);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Line수*컬럼수";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtLine
			// 
			this.txtLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLine.Location = new System.Drawing.Point(94, 256);
			this.txtLine.Name = "txtLine";
			this.txtLine.Size = new System.Drawing.Size(24, 20);
			this.txtLine.TabIndex = 10;
			this.txtLine.Text = "2";
			this.txtLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtLine.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtLine_DataValidating);
			// 
			// txtCol
			// 
			this.txtCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCol.Location = new System.Drawing.Point(126, 256);
			this.txtCol.Name = "txtCol";
			this.txtCol.Size = new System.Drawing.Size(24, 20);
			this.txtCol.TabIndex = 11;
			this.txtCol.Text = "2";
			this.txtCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(129)));
			this.label2.Location = new System.Drawing.Point(118, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(8, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "*";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("ko-KR");
			this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
																		  this.dataTable1});
			// 
			// btnUp
			// 
			this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUp.Location = new System.Drawing.Point(414, 256);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(52, 28);
			this.btnUp.TabIndex = 13;
			this.btnUp.Text = "Up";
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDown.Location = new System.Drawing.Point(470, 256);
			this.btnDown.Name = "btnDown";
			this.btnDown.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDown.Size = new System.Drawing.Size(52, 28);
			this.btnDown.TabIndex = 14;
			this.btnDown.Text = "Down";
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// XGridCellEditorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(738, 286);
			this.ControlBox = false;
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCol);
			this.Controls.Add(this.txtLine);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cellInfoGrid);
			this.DockPadding.Bottom = 35;
			this.DockPadding.Left = 5;
			this.DockPadding.Right = 5;
			this.DockPadding.Top = 5;
			this.Name = "XGridCellEditorForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "컬럼정보 편집기";
			((System.ComponentModel.ISupportInitialize)(this.cellInfoGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// AcceptData
			this.cellInfoGrid.AcceptData();
			int headerRowCount = 0;
			int endCol = 0;
			int row, col;
			bool isVisible;
			string[] rowCol;
			bool isCreateAEditCell = false; //AEditCell을 새로 생성하였는지 여부
			
			//삭제된 행은 제외 ResetUpdate
			this.cellInfoGrid.ResetUpdate();

			// 저장전 Check사항 확인
			if(!CheckValidation())
				return;
			
			IDesignerHost host = null;
			if (provider != null)
			{
				host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
			}

			headerRowCount = grid.AddedHeaderLine + grid.LinePerRow;
			endCol = grid.ColPerLine;
			if (grid.RowHeaderVisible) endCol++;

			DataRow dtRow;
			XGridCell cellInfo;
			// 원 목록 보관
			XGridCell[] originalCellInfos = new XGridCell[cellInfos.Count];
			for (int i = 0; i < cellInfos.Count; i++)
				originalCellInfos[i] = cellInfos[i];
			cellInfos.Clear();

			for (int i = 0 ; i < this.dataTable1.Rows.Count ; i++)
			{
				//Flag Clear
				isCreateAEditCell = false;

				dtRow = this.dataTable1.Rows[i];
				row = Int32.Parse(dtRow["row"].ToString());
				col = Int32.Parse(dtRow["col"].ToString());
				isVisible = GetBool(dtRow["isVisible"].ToString());

				// 원목록에 있으면 그대로 사용, 없으면 생성
				int originalSeq = int.Parse(dtRow["originalSeq"].ToString());
				if (originalSeq >= 0)
					cellInfo = originalCellInfos[originalSeq];
				else
				{
					//Flag Set
					isCreateAEditCell = true;
					if (provider != null)
					{
						cellInfo = (XGridCell) host.CreateComponent(typeof(XGridCell));
					}
					else
					{
						cellInfo = new XGridCell();
					}
				}
				//CellInfo의 DisplayOrder는 최초(-1)일때는 i로 SET
				//Appearance를 변경후에 DisplayOrder Setting후에는 변경된 DisplayOrder 그대로 SET
				cellInfo.CellName = dtRow["cellName"].ToString();
				cellInfo.HeaderText = dtRow["headerText"].ToString();
				cellInfo.CellType = (XCellDataType)Enum.Parse(typeof(XCellDataType), dtRow["cellType"].ToString());
				//새로 생성된 AEditCell이 아닐때 이전의 CellType과 원래 CellType이 같으면 이전에 설정되었던 Mask 그대로 적용
				//(CellType이 설정시에 Mask를 CellType에 따라 DefaultMask로 설정하므로 다시 설정)
				if (!isCreateAEditCell && dtRow["cellType"].Equals(dtRow["origCellType"]))
					cellInfo.Mask = dtRow["mask"].ToString();
				cellInfo.IsVisible = isVisible;
				cellInfo.TextAlignment = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), dtRow["textAlignment"].ToString());
				//Visible Column Pos Set (비정상적인 Pos를 가진 Info만 Row, Col 다시 설정)
				if (isVisible)
				{
					// Visible일때 비정상적인 Display Order 일때
					if ((row == -1) || (col == -1) || (row >= headerRowCount) || (col >= endCol))
					{
						if (posArray.Count > 0)
						{
							rowCol = posArray[0].ToString().Split(new Char[]{','});
							row = Int32.Parse(rowCol[0]);
							col = Int32.Parse(rowCol[1]);
							// Remove
							posArray.RemoveAt(0);
						}
						else if (spanPosArray.Count > 0)
						{
							rowCol = spanPosArray[0].ToString().Split(new Char[]{','});
							row = Int32.Parse(rowCol[0]);
							col = Int32.Parse(rowCol[1]);
							string key = rowCol[2] + "," + rowCol[3];
							int index = Int32.Parse(infoIndices[key].ToString());
							int rSpan = Int32.Parse(this.dataTable1.Rows[index]["rowSpan"].ToString());
							int cSpan = Int32.Parse(this.dataTable1.Rows[index]["colSpan"].ToString());
							// 추가된 위치가 Span위치인 CellInfo의 RowSpan은 추가위치 Row - Span된 Cell의 Row
							if (rSpan > 1)
							{
								// 아직 미설정된 cellInfo이면 Data SET
								if (index > i)
									this.dataTable1.Rows[index]["rowSpan"] = Math.Max(1, Int32.Parse(rowCol[0]) - Int32.Parse(rowCol[2]));
								else if (index < i) //이미 설정된 CellInfo이면 CellInfo에 바로 SET
									this.cellInfos[index].RowSpan = Math.Max(1, Int32.Parse(rowCol[0]) - Int32.Parse(rowCol[2]));
							}
							if (cSpan > 1)
							{
								if (index > i)
									this.dataTable1.Rows[index]["colSpan"] = Math.Max(1, Int32.Parse(rowCol[1]) - Int32.Parse(rowCol[3]));
								else if (index < i)
									this.cellInfos[index].ColSpan = Math.Max(1, Int32.Parse(rowCol[1]) - Int32.Parse(rowCol[3]));
							}
							spanPosArray.RemoveAt(0);
						}

						cellInfo.Row = row;
						cellInfo.Col = col;
					}
				}
				else  //Not visible
				{
					cellInfo.Row = row; //-1
					cellInfo.Col = col; //-1
				}
				cellInfo.RowSpan = Int32.Parse(dtRow["rowSpan"].ToString());
				cellInfo.ColSpan = Int32.Parse(dtRow["colSpan"].ToString());

				this.cellInfos.Add(cellInfo);
			}

			//컬럼위치 고려 RowSpan,ColSpan 다시 조정
			foreach (XGridCell info in this.cellInfos)
			{
				if (info.IsVisible)
				{
					if ((info.RowSpan > 1) && (info.Row + info.RowSpan > headerRowCount))
					{
						info.RowSpan = Math.Max(1, headerRowCount - info.Row);
					}
					//col + colSpan > endCol 이면 colSpan 조정
					if ((info.ColSpan > 1) && (info.Col + info.ColSpan > endCol))
					{
						info.ColSpan = Math.Max(1, endCol - info.Col);
					}
				}
			}
			
			// 제거된 CellInfo는 Component 삭제
			if (host != null)
			{
				foreach (XGridCell item in originalCellInfos)
					if (!cellInfos.Contains(item))
						host.DestroyComponent(item);
			}
			
			// CellInfos설정후 XGridComputedCells의 Row의 위치가 LinesPerRow보다 크거나 같으면 해당
			// XGridComputedCell Destrory
			int linesPerRow = 0;
			ArrayList removeCompInfos = new ArrayList();
			linesPerRow = grid.GetLinesPerRow();
			foreach (XGridComputedCell info in grid.ComputedCellInfos)
				if (info.Row >= linesPerRow)
					removeCompInfos.Add(info);
			foreach (XGridComputedCell compInfo in removeCompInfos)
			{
				grid.ComputedCellInfos.Remove(compInfo);
				if (host != null)
					host.DestroyComponent(compInfo);
			}
			//DialogResult Set
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.cellInfoGrid.InsertRow(-1);  // 마지막에 ADD
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.cellInfoGrid.DeleteRow(-1);  // 현재행 삭제
		}
		/// <summary>
		/// 폼이 Load될 때 CellInfos정보를 Grid에 Set합니다.
		/// </summary>
		/// <param name="e">이벤트 데이터가 들어 있는 EventArgs입니다.</param>
		protected override void OnLoad(System.EventArgs e)
		{
			base.OnLoad(e);

			isLoading = true;
			
			DataRow dtRow = null;
			//cellInfos정보를 cellInfoGrid에 SET
			for(int i = 0 ; i < cellInfos.Count ; i ++)
			{
				dtRow = this.dataTable1.NewRow();
				dtRow["cellName"] = cellInfos[i].CellName;
				dtRow["headerText"] = cellInfos[i].HeaderText;
				dtRow["cellType"] = cellInfos[i].CellType.ToString();
				dtRow["isVisible"] = (cellInfos[i].IsVisible ? "Y" : "N");
				dtRow["textAlignment"] = cellInfos[i].TextAlignment.ToString();
				dtRow["row"] = cellInfos[i].Row;
				dtRow["col"] = cellInfos[i].Col;
				dtRow["rowSpan"] = cellInfos[i].RowSpan;
				dtRow["colSpan"] = cellInfos[i].ColSpan;
				//Mask와 원래CellType저장
				dtRow["mask"] = cellInfos[i].Mask;
				dtRow["origCellType"] = cellInfos[i].CellType.ToString();
				dtRow["originalSeq"] = i;
				this.dataTable1.Rows.Add(dtRow);
			}
			dataTable1.AcceptChanges();
			isLoading = false;
		}
		
		private bool GetBool(string bstr)
		{
			bool boolean = true;
			switch (bstr.ToUpper())
			{
				case "Y":
					boolean = true;
					break;
				case "N":
					boolean = false;
					break;
				default:
					break;
			}
			return boolean;
		}

		private void txtLine_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// Line이 2이상이면 txtCol.Enable
			if (!TypeCheck.IsInt(e.DataValue)) 
				e.Cancel = true;
			else
			{
				if(Int32.Parse(e.DataValue.ToString()) == 1)
					this.txtCol.Enabled = false;
				else
					this.txtCol.Enabled = true;
			}
		}

		private void cellInfoGrid_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			// Loading중에는 Check하지 않음
			if (isLoading) return;

			//cellType이 Number,Decimal이면 Align Right, Date,Time이면 Center, string Left
			//Number,Decimal,Date,Time은 ColStyle은 Edit로 변경
			string data = e.ChangeValue.ToString();
			switch (e.ColName)
			{
				case "cellType":
					if ((data == "Number") || (data == "Decimal"))
						e.DataRow["textAlignment"] = "MiddleRight";
					else if ((data == "Date") || (data == "DateTime") || (data == "Time"))
						e.DataRow["textAlignment"] = "MiddleCenter";
					else
						e.DataRow["textAlignment"] = "MiddleLeft";
					break;
			}
		}

		private void btnUp_Click(object sender, System.EventArgs e)
		{
			this.cellInfoGrid.RowMoveUp(this.cellInfoGrid.CurrentCell.RowNumber);
		}

		private void btnDown_Click(object sender, System.EventArgs e)
		{
			this.cellInfoGrid.RowMoveDown(this.cellInfoGrid.CurrentCell.RowNumber);
		}
	}
}