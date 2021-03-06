using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms.Design;

namespace IHIS.Framework
{
	#region FindColumnInfoEditorForm
	/// <summary>
	/// FindColumnInfoEditorForm에 대한 요약 설명입니다.
	/// </summary>
	internal class FindColumnInfoEditorForm : System.Windows.Forms.Form
	{
		private IServiceProvider provider = null;
		private FindColumnInfoCollection findInfos = null;
		private DataTable itemTable = new DataTable("itemTable");
		private bool isLoading = false;

		private IHIS.Framework.XDataGrid itemGrid;
		private IHIS.Framework.XDataGridTableStyle xDataGridTableStyle1;
		private IHIS.Framework.XDataGridStringTextBoxColumn xDataGridStringTextBoxColumn1;
		private IHIS.Framework.XDataGridStringTextBoxColumn xDataGridStringTextBoxColumn2;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XButton btnAdd;
		private IHIS.Framework.XButton btnDown;
		private IHIS.Framework.XButton btnUp;
		private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn1;
		private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn2;
		private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn3;
		private IHIS.Framework.XDataGridCheckBoxColumn xDataGridCheckBoxColumn1;
		private IHIS.Framework.XDataGridNumericTextBoxColumn xDataGridNumericTextBoxColumn2;
		private IHIS.Framework.XDataGridStringTextBoxColumn xDataGridStringTextBoxColumn3;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// FindColumnInfoEditorForm 생성자
		/// </summary>
		/// <param name="cellInfos"> FindColumnInfoCollection (콤보정보) </param>
		/// <param name="provider"> 서비스를 얻는 데 사용할 수 있는 IServiceProvider</param>
		public FindColumnInfoEditorForm(FindColumnInfoCollection findInfos, IServiceProvider provider)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.findInfos = findInfos;
			this.provider = provider;

			//컬럼정의
			itemTable.Columns.Add("colName", typeof(string));
			itemTable.Columns.Add("headerText", typeof(string));
			itemTable.Columns.Add("colType", typeof(string));
			itemTable.Columns.Add("colAlign", typeof(string));
			itemTable.Columns.Add("filterType", typeof(string));
			itemTable.Columns.Add("isVisible", typeof(string));
			itemTable.Columns.Add("decimalDigits", typeof(int));
			itemTable.Columns.Add("mask", typeof(string));
			itemTable.Columns.Add("colWidth", typeof(int));
			itemTable.Columns.Add("OriginalSeq", typeof(int));  //이미 생성된 FindColumnInfo의 순서 (새로 생성시는 -1이 됨)
			//Default Value SET
			itemTable.Columns["colType"].DefaultValue = "String";
			itemTable.Columns["colAlign"].DefaultValue = "Left";
			itemTable.Columns["filterType"].DefaultValue = "No";
			itemTable.Columns["isVisible"].DefaultValue = "Y";
			itemTable.Columns["decimalDigits"].DefaultValue = 0;
			itemTable.Columns["colWidth"].DefaultValue = 80;
			itemTable.Columns["OriginalSeq"].DefaultValue = -1;

			//ComboColumn SET(ColType, ColAlign, FilterType)
			foreach (string item in Enum.GetNames(typeof(FindColType)))
			{
				this.xDataGridComboBoxColumn1.ComboItems.Add(item, item);
				((XComboBox)this.xDataGridComboBoxColumn1.Editor).ComboItems.Add(item,item);
			}
			foreach (string item in Enum.GetNames(typeof(HorizontalAlignment)))
			{
				this.xDataGridComboBoxColumn2.ComboItems.Add(item, item);
				((XComboBox)this.xDataGridComboBoxColumn2.Editor).ComboItems.Add(item,item);
			}
			foreach (string item in Enum.GetNames(typeof(FilterType)))
			{
				this.xDataGridComboBoxColumn3.ComboItems.Add(item, item);
				((XComboBox)this.xDataGridComboBoxColumn3.Editor).ComboItems.Add(item,item);
			}

			//데이타 설정
			DataRow dtRow = null;
			int index = 0;
			foreach (FindColumnInfo item in findInfos)
			{
				dtRow = itemTable.NewRow();
				dtRow["colName"] = item.ColName;
				dtRow["headerText"] = item.HeaderText;
				dtRow["colType"] = item.ColType.ToString();
				dtRow["colAlign"] = item.ColAlign.ToString();
				dtRow["filterType"] = item.FilterType.ToString();
				dtRow["isVisible"] = (item.IsVisible ? "Y" : "N");
				dtRow["decimalDigits"] = item.DecimalDigits;
				dtRow["mask"] = item.Mask;
				dtRow["colWidth"] = item.ColWidth;
				dtRow["OriginalSeq"] = index;
				itemTable.Rows.Add(dtRow);
				index++;
			}
			itemTable.AcceptChanges();

			this.itemGrid.DataSource = itemTable;
			itemTable.DefaultView.AllowNew = false;
		}

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

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.itemGrid = new IHIS.Framework.XDataGrid();
			this.xDataGridTableStyle1 = new IHIS.Framework.XDataGridTableStyle();
			this.xDataGridStringTextBoxColumn1 = new IHIS.Framework.XDataGridStringTextBoxColumn();
			this.xDataGridStringTextBoxColumn2 = new IHIS.Framework.XDataGridStringTextBoxColumn();
			this.xDataGridComboBoxColumn1 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.xDataGridComboBoxColumn2 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.xDataGridComboBoxColumn3 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.xDataGridCheckBoxColumn1 = new IHIS.Framework.XDataGridCheckBoxColumn();
			this.xDataGridNumericTextBoxColumn2 = new IHIS.Framework.XDataGridNumericTextBoxColumn();
			this.xDataGridStringTextBoxColumn3 = new IHIS.Framework.XDataGridStringTextBoxColumn();
			this.btnCancel = new IHIS.Framework.XButton();
			this.btnOK = new IHIS.Framework.XButton();
			this.btnDelete = new IHIS.Framework.XButton();
			this.btnAdd = new IHIS.Framework.XButton();
			this.btnDown = new IHIS.Framework.XButton();
			this.btnUp = new IHIS.Framework.XButton();
			((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// itemGrid
			// 
			this.itemGrid.CaptionVisible = false;
			this.itemGrid.DataSource = null;
			this.itemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemGrid.Location = new System.Drawing.Point(5, 5);
			this.itemGrid.Name = "itemGrid";
			this.itemGrid.Size = new System.Drawing.Size(742, 218);
			this.itemGrid.TabIndex = 1;
			this.itemGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.xDataGridTableStyle1});
			this.itemGrid.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.itemGrid_GridColumnChanged);
			// 
			// xDataGridTableStyle1
			// 
			this.xDataGridTableStyle1.DataGrid = this.itemGrid;
			this.xDataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												   this.xDataGridStringTextBoxColumn1,
																												   this.xDataGridStringTextBoxColumn2,
																												   this.xDataGridComboBoxColumn1,
																												   this.xDataGridComboBoxColumn2,
																												   this.xDataGridComboBoxColumn3,
																												   this.xDataGridCheckBoxColumn1,
																												   this.xDataGridNumericTextBoxColumn2,
																												   this.xDataGridStringTextBoxColumn3});
			this.xDataGridTableStyle1.MappingName = "itemTable";
			// 
			// xDataGridStringTextBoxColumn1
			// 
			this.xDataGridStringTextBoxColumn1.HeaderText = "ColName";
			this.xDataGridStringTextBoxColumn1.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
			this.xDataGridStringTextBoxColumn1.MappingName = "colName";
			// 
			// xDataGridStringTextBoxColumn2
			// 
			this.xDataGridStringTextBoxColumn2.HeaderText = "HeaderText";
			this.xDataGridStringTextBoxColumn2.ImeMode = IHIS.Framework.ColumnImeMode.Han;
			this.xDataGridStringTextBoxColumn2.MappingName = "headerText";
			this.xDataGridStringTextBoxColumn2.Width = 150;
			// 
			// xDataGridComboBoxColumn1
			// 
			this.xDataGridComboBoxColumn1.HeaderText = "ColType";
			this.xDataGridComboBoxColumn1.MappingName = "colType";
			this.xDataGridComboBoxColumn1.Width = 80;
			// 
			// xDataGridComboBoxColumn2
			// 
			this.xDataGridComboBoxColumn2.HeaderText = "Aligment";
			this.xDataGridComboBoxColumn2.MappingName = "colAlign";
			this.xDataGridComboBoxColumn2.Width = 60;
			// 
			// xDataGridComboBoxColumn3
			// 
			this.xDataGridComboBoxColumn3.HeaderText = "FilterType";
			this.xDataGridComboBoxColumn3.MappingName = "filterType";
			this.xDataGridComboBoxColumn3.Width = 70;
			// 
			// xDataGridCheckBoxColumn1
			// 
			this.xDataGridCheckBoxColumn1.HeaderText = "Visible";
			this.xDataGridCheckBoxColumn1.MappingName = "isVisible";
			this.xDataGridCheckBoxColumn1.Width = 50;
			// 
			// xDataGridNumericTextBoxColumn2
			// 
			this.xDataGridNumericTextBoxColumn2.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.xDataGridNumericTextBoxColumn2.HeaderText = "Digits";
			this.xDataGridNumericTextBoxColumn2.MappingName = "decimalDigits";
			this.xDataGridNumericTextBoxColumn2.MaxinumCipher = 1;
			this.xDataGridNumericTextBoxColumn2.Width = 40;
			// 
			// xDataGridStringTextBoxColumn3
			// 
			this.xDataGridStringTextBoxColumn3.HeaderText = "Mask";
			this.xDataGridStringTextBoxColumn3.MappingName = "mask";
			this.xDataGridStringTextBoxColumn3.Width = 150;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(680, 230);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(64, 26);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "취 소";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(612, 230);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(64, 26);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "확 인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Location = new System.Drawing.Point(72, 230);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDelete.Size = new System.Drawing.Size(64, 26);
			this.btnDelete.TabIndex = 12;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(6, 230);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(60, 26);
			this.btnAdd.TabIndex = 11;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDown
			// 
			this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDown.Location = new System.Drawing.Point(368, 230);
			this.btnDown.Name = "btnDown";
			this.btnDown.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDown.Size = new System.Drawing.Size(64, 26);
			this.btnDown.TabIndex = 10;
			this.btnDown.Text = "Down";
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUp.Location = new System.Drawing.Point(300, 230);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(64, 26);
			this.btnUp.TabIndex = 9;
			this.btnUp.Text = "Up";
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// FindColumnInfoEditorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(752, 258);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.itemGrid);
			this.DockPadding.Bottom = 35;
			this.DockPadding.Left = 5;
			this.DockPadding.Right = 5;
			this.DockPadding.Top = 5;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FindColumnInfoEditorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FindColumnInfo 편집기";
			((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Button Event
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.itemGrid.InsertRow(-1);
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.itemGrid.DeleteRow(-1);
		}
		private void btnUp_Click(object sender, System.EventArgs e)
		{
			this.itemGrid.RowMoveUp(this.itemGrid.CurrentRowIndex);
		}

		private void btnDown_Click(object sender, System.EventArgs e)
		{
			this.itemGrid.RowMoveDown(this.itemGrid.CurrentRowIndex);
		}
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// AcceptData
			this.itemGrid.AcceptData();
	
			// 저장전 Check사항 확인
			if (!CheckValidation())
				return;
			
			IDesignerHost host = null;
			if (provider != null)
			{
				host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
			}
			
			//기지정된 FindColumnInfos 보관
			FindColumnInfo[] origFindInfos = new FindColumnInfo[findInfos.Count];
			for (int i = 0 ; i < findInfos.Count ; i++)
				origFindInfos[i] = findInfos[i];

			//콤보정보 Clear
			findInfos.Clear();

			FindColumnInfo findInfo = null;
			int		originalSeq = 0;
			foreach (DataRow dtRow in this.itemTable.Rows)
			{
				originalSeq = (int) dtRow["OriginalSeq"];

				//원목록에서 있으면 원목록 그대로 사용, 없으면 Component 생성
				if (originalSeq >= 0)
					findInfo = origFindInfos[originalSeq] as FindColumnInfo;
				else
				{
					if (host != null)
						findInfo = (FindColumnInfo) host.CreateComponent(typeof(FindColumnInfo));
					else
						findInfo = new FindColumnInfo();
				}
				findInfo.ColName = dtRow["colName"].ToString();
				findInfo.HeaderText = dtRow["headerText"].ToString();
				findInfo.ColType = (FindColType)Enum.Parse(typeof(FindColType), dtRow["colType"].ToString());
				findInfo.ColAlign = (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), dtRow["colAlign"].ToString());
				findInfo.FilterType = (FilterType)Enum.Parse(typeof(FilterType), dtRow["filterType"].ToString());
				findInfo.IsVisible = (dtRow["isVisible"].ToString() == "Y" ? true : false);
				findInfo.DecimalDigits = (int) dtRow["decimalDigits"];
				findInfo.Mask = dtRow["mask"].ToString();
				findInfo.ColWidth = (int) dtRow["colWidth"];
				//FindColumnInfos Add
				this.findInfos.Add(findInfo);
			}
			
			//삭제된 FindColumnInfo Component 제거
			if (host != null)
			{
				foreach (FindColumnInfo item in origFindInfos)
					if (!findInfos.Contains(item))
						host.DestroyComponent(item);
			}
			
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		#endregion

		#region CheckValidation
		private bool CheckValidation()
		{
			//1.컬럼명 반드시 입력(컬럼명 중복불가)
			//2.Visible한 컬럼은 HeaderText 반드시 입력
			string colName = "", headerText = "", visibleYn = "";
			for(int i = 0; i < this.itemGrid.RowCount ; i++)
			{
				colName = this.itemGrid.GetItem(i, "colName").ToString().Trim();
				headerText = this.itemGrid.GetItem(i, "headerText").ToString().Trim();
				visibleYn = this.itemGrid.GetItem(i, "isVisible").ToString().Trim();
				if (colName == "")
				{
					XMessageBox.Show("컬럼명을 반드시 입력하십시오");
					this.itemGrid.SetFocusToItem(i, "colName");
					return false;
				}
				for (int j = 0 ; j < itemGrid.RowCount ; j++)
				{
					if (i != j)
					{
						if (colName == itemGrid.GetItem(j, "colName").ToString().Trim())
						{
							XMessageBox.Show("컬럼명은 중복할 수 없습니다.");
							this.itemGrid.SetFocusToItem(i, "colName");
							return false;
						}
					}
				}

				if ((visibleYn == "Y") && (headerText == ""))
				{
					XMessageBox.Show("Visible한 컬럼은 HeaderText를 반드시 입력하십시오");
					this.itemGrid.SetFocusToItem(i, "headerText");
					return false;
				}
			}
			return true;
		}
		#endregion

		#region Grid컬럼값 변경시 처리 (itemGrid_GridColumnChanged)
		private void itemGrid_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			if (isLoading) return;  //Loading시에는 변경하지 않음
			switch (e.ColName)
			{
				case "colType":  //컬럼 Type 변경
					//1.String형은 Left, DecimalDigits 0, DefaultMask
					//2.Date,DateTime형은 Center, DecimalDigits 0, DefaultMask
					//3.Number는 Rigth, DecimalDigits 0, Mask Clear
					if (e.ChangeValue.ToString() == "String")
					{
						e.DataRow["colAlign"] = "Left";
						e.DataRow["decimalDigits"] = 0;
						e.DataRow["mask"] = MaskHelper.CStringDefaultMask;
					}
					else if (e.ChangeValue.ToString() == "Date")
					{
						e.DataRow["colAlign"] = "Center";
						e.DataRow["decimalDigits"] = 0;
						e.DataRow["mask"] = MaskHelper.CDateDefaultMask;
					}
					else if (e.ChangeValue.ToString() == "DateTime")
					{
						e.DataRow["colAlign"] = "Center";
						e.DataRow["decimalDigits"] = 0;
						e.DataRow["mask"] = MaskHelper.CDateTimeDefaultMask;
					}
					else //Number
					{
						e.DataRow["colAlign"] = "Right";
						e.DataRow["decimalDigits"] = 0;
						e.DataRow["mask"] = "";
					}
					break;
				case "mask":  //Mask 변경시

					if (e.ChangeValue.ToString().Trim() == "") return;

					//컬럼Type에 따라 Mask Check Logic 변경
					string colType = e.DataRow["colType"].ToString();
					if (colType == "Number")  //Number는 Mask지정 의미 없음
					{
						MessageBox.Show("Number형은 Mask 지정할 수 없습니다");
						e.Cancel = true;
						return;
					}
					else
					{
						string errMsg = "";
						MaskType mType = MaskType.String;
						if (colType == "Date")
							mType = MaskType.Date;
						else if (colType == "DateTime")
							mType = MaskType.DateTime;
						if (!MaskHelper.IsValidMask(mType, e.ChangeValue.ToString(), out errMsg))
						{
							MessageBox.Show(errMsg);
							e.Cancel = true;
							return;
						}
					}
					break;
				case "decimalDigits":
					//DecimalDigits는 Number 형만 가능
					if (e.ChangeValue.ToString() == "0") return;

					if (e.DataRow["colType"].ToString() != "Number")
					{
						MessageBox.Show("Number형컬럼만 Digits지정가능합니다.");
						e.Cancel = true;
					}
					break;
				default:
					break;
			}
		}
		#endregion
	}
	#endregion

	#region FindColumnInfoEditor
	/// <summary>
	/// FindColumnInfoEditor에 대한 요약 설명입니다.
	/// </summary>
	internal class FindColumnInfoEditor : System.Drawing.Design.UITypeEditor
	{
		private IWindowsFormsEditorService edSvc = null;
		/// <summary>
		/// GetEditStyle에 표시된 편집기 스타일을 사용하여 지정된 개체의 값을 편집합니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <param name="provider"> 이 편집기에서 서비스를 얻는 데 사용할 수 있는 IServiceProvider </param>
		/// <param name="value"> 편집할 개체 </param>
		/// <returns> 개체의 새 값 </returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if (context != null	&& context.Instance != null	&& provider != null) 
			{
				
				//서비스 개체 즉, 다른 개체에 대한 사용자 지정 지원을 제공하는 개체를 검색하는 메커니즘을 정의합니다.
				//[ComVisible(false)] object GetService(Type serviceType); 지정된 형식의 서비스 개체를 가져옵니다
				edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (edSvc != null)
				{
					// 속성창 ShowDialog에 표시할 Form 생성
					FindColumnInfoEditorForm dlg = new FindColumnInfoEditorForm((FindColumnInfoCollection) value, provider);
					//Dialog Show
					//ComponentChanged Event가 발생하지 않으면 이 편집기를 호출한 Form에서는 변경여부를 알수가 없으므로
					//InitializeComponent()를 다시 설정하지 않는다. 따라서, 반드시 해주어야 함.
					if( edSvc.ShowDialog(dlg) == DialogResult.OK)
					{
						context.OnComponentChanged();  // ComponentChanged 이벤트를 발생시켜 InitialzeComponent에 반영되록함

					}
				}
			}

			return value;
		}
		
		/// <summary>
		/// EditValue 메서드에서 사용하는 편집기 스타일을 가져옵니다.
		/// </summary>
		/// <param name="context"> 추가 컨텍스트 정보를 얻는 데 사용할 수 있는 ITypeDescriptorContext </param>
		/// <returns> EditValue에서 사용하는 편집기 스타일을 나타내는 UITypeEditorEditStyle 값 </returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if (context != null && context.Instance != null) 
			{
				//UITypeEditorStyle Enum : UITypeEditor의 값 편집 스타일을 나타내는 식별자를 지정
				//DropDown 드롭다운 대화 상자에 호스팅될 사용자 인터페이스 및 아래쪽 화살표 단추를 표시합니다. 
				//Modal 모달 대화 상자를 시작하는 ... 단추를 표시합니다. 
				//None 대화형 UI(사용자 인터페이스) 구성 요소를 제공하지 않습니다. 
				return UITypeEditorEditStyle.Modal;  //  Modal상자 형식으로 속성창에 표시
			}
			return base.GetEditStyle(context);
		}
	}
	#endregion
}
