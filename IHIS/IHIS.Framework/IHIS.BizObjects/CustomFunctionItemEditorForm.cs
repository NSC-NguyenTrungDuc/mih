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
	#region CustomFunctionItemEditorForm
	/// <summary>
	/// CustomFunctionItemEditorForm에 대한 요약 설명입니다.
	/// </summary>
	internal class CustomFunctionItemEditorForm : System.Windows.Forms.Form
	{
		private CustomFunctionItemCollection funcItems = null;
		private DataTable itemTable = new DataTable("itemTable");

		private IHIS.Framework.XDataGrid itemGrid;
		private IHIS.Framework.XDataGridTableStyle xDataGridTableStyle1;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XButton btnAdd;
		private IHIS.Framework.XButton btnDown;
		private IHIS.Framework.XButton btnUp;
		private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn1;
		private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn2;
		private IHIS.Framework.XDataGridStringTextBoxColumn xDataGridStringTextBoxColumn3;
		private IHIS.Framework.XDataGridNumericTextBoxColumn xDataGridNumericTextBoxColumn1;
		private IHIS.Framework.XDataGridComboBoxColumn xDataGridComboBoxColumn3;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// CustomFunctionItemEditorForm 생성자
		/// </summary>
		/// <param name="cellInfos"> CustomFunctionItemCollection (콤보정보) </param>
		public CustomFunctionItemEditorForm(CustomFunctionItemCollection funcItems)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			this.funcItems = funcItems;

			//FunctionType Combo 설정
			XComboBox comboBox = (XComboBox) this.xDataGridComboBoxColumn1.Editor;
			foreach (string item in Enum.GetNames(typeof(IHIS.Framework.FunctionType)))
				comboBox.ComboItems.Add(item, item);

			//ShortCut Combo 설정
			comboBox = (XComboBox) this.xDataGridComboBoxColumn2.Editor;
			foreach (string item in Enum.GetNames(typeof(System.Windows.Forms.Shortcut)))
				comboBox.ComboItems.Add(item, item);

			comboBox = (XComboBox) this.xDataGridComboBoxColumn3.Editor;
			comboBox.ComboItems.Add("", "(기본사용)");
			foreach (string item in Enum.GetNames(typeof(IHIS.Framework.XButtonSchemes)))
				comboBox.ComboItems.Add(item, item);

			//컬럼정의
			itemTable.Columns.Add("FuncType", typeof(string));
			itemTable.Columns.Add("ShortCut", typeof(string));
			itemTable.Columns.Add("Text", typeof(string));
			itemTable.Columns.Add("ImageIndex", typeof(int));
			itemTable.Columns.Add("Scheme", typeof(string));
			itemTable.Columns["FuncType"].DefaultValue = "Close";
			itemTable.Columns["ShortCut"].DefaultValue = "None";
			itemTable.Columns["ImageIndex"].DefaultValue = -1;
			//데이타 설정
			DataRow dtRow = null;
			foreach (CustomFunctionItem item in funcItems)
			{
				dtRow = itemTable.NewRow();
				dtRow["FuncType"] = item.FuncType.ToString();
				dtRow["ShortCut"] = item.ShortCut.ToString();
				dtRow["Text"] = item.Text;
				dtRow["ImageIndex"] = item.ImageIndex;
				dtRow["Scheme"] = item.Scheme;
				itemTable.Rows.Add(dtRow);
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
			this.xDataGridComboBoxColumn1 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.xDataGridComboBoxColumn2 = new IHIS.Framework.XDataGridComboBoxColumn();
			this.xDataGridStringTextBoxColumn3 = new IHIS.Framework.XDataGridStringTextBoxColumn();
			this.xDataGridNumericTextBoxColumn1 = new IHIS.Framework.XDataGridNumericTextBoxColumn();
			this.xDataGridComboBoxColumn3 = new IHIS.Framework.XDataGridComboBoxColumn();
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
			this.itemGrid.Location = new System.Drawing.Point(4, 4);
			this.itemGrid.Name = "itemGrid";
			this.itemGrid.Size = new System.Drawing.Size(496, 219);
			this.itemGrid.TabIndex = 1;
			this.itemGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.xDataGridTableStyle1});
			// 
			// xDataGridTableStyle1
			// 
			this.xDataGridTableStyle1.DataGrid = this.itemGrid;
			this.xDataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												   this.xDataGridComboBoxColumn1,
																												   this.xDataGridComboBoxColumn2,
																												   this.xDataGridStringTextBoxColumn3,
																												   this.xDataGridNumericTextBoxColumn1,
																												   this.xDataGridComboBoxColumn3});
			this.xDataGridTableStyle1.MappingName = "itemTable";
			// 
			// xDataGridComboBoxColumn1
			// 
			this.xDataGridComboBoxColumn1.HeaderText = "FunctionType";
			this.xDataGridComboBoxColumn1.MappingName = "FuncType";
			this.xDataGridComboBoxColumn1.MaxDropDownItems = 12;
			// 
			// xDataGridComboBoxColumn2
			// 
			this.xDataGridComboBoxColumn2.HeaderText = "ShortCut";
			this.xDataGridComboBoxColumn2.MappingName = "ShortCut";
			this.xDataGridComboBoxColumn2.MaxDropDownItems = 20;
			// 
			// xDataGridStringTextBoxColumn3
			// 
			this.xDataGridStringTextBoxColumn3.HeaderText = "Text";
			this.xDataGridStringTextBoxColumn3.MappingName = "Text";
			// 
			// xDataGridNumericTextBoxColumn1
			// 
			this.xDataGridNumericTextBoxColumn1.ColumnAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.xDataGridNumericTextBoxColumn1.HeaderText = "Image";
			this.xDataGridNumericTextBoxColumn1.MappingName = "ImageIndex";
			this.xDataGridNumericTextBoxColumn1.MaxinumCipher = 1;
			this.xDataGridNumericTextBoxColumn1.Width = 50;
			// 
			// xDataGridComboBoxColumn3
			// 
			this.xDataGridComboBoxColumn3.HeaderText = "Scheme";
			this.xDataGridComboBoxColumn3.MappingName = "Scheme";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(446, 229);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(55, 25);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "취 소";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(389, 229);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(57, 25);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "확 인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Location = new System.Drawing.Point(62, 229);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDelete.Size = new System.Drawing.Size(56, 25);
			this.btnDelete.TabIndex = 12;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(4, 229);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(52, 25);
			this.btnAdd.TabIndex = 11;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDown
			// 
			this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDown.Location = new System.Drawing.Point(214, 228);
			this.btnDown.Name = "btnDown";
			this.btnDown.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDown.Size = new System.Drawing.Size(56, 25);
			this.btnDown.TabIndex = 10;
			this.btnDown.Text = "Down";
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUp.Location = new System.Drawing.Point(160, 228);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(55, 25);
			this.btnUp.TabIndex = 9;
			this.btnUp.Text = "Up";
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// CustomFunctionItemEditorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(504, 257);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.itemGrid);
			this.DockPadding.Bottom = 34;
			this.DockPadding.Left = 4;
			this.DockPadding.Right = 4;
			this.DockPadding.Top = 4;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CustomFunctionItemEditorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CustomFunctionItem 편집기";
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
			
			//콤보정보 Clear
			funcItems.Clear();

			foreach (DataRow dtRow in this.itemTable.Rows)
			{
				funcItems.Add(
					(FunctionType)Enum.Parse(typeof(FunctionType), dtRow["FuncType"].ToString()),
					(Shortcut)Enum.Parse(typeof(Shortcut), dtRow["ShortCut"].ToString()),
					dtRow["Text"].ToString().Trim(),
					(int) dtRow["ImageIndex"],
					dtRow["Scheme"].ToString());
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		#endregion

		#region CheckValidation
		private bool CheckValidation()
		{
			//FunctionType 반드시 입력
			string funcType = "";
			for(int i = 0; i < this.itemGrid.RowCount ; i++)
			{
				funcType = this.itemGrid.GetItem(i, "FuncType").ToString().Trim();
				if (funcType == "")
				{
					XMessageBox.Show("FunctionType을 반드시 입력하십시오");
					this.itemGrid.SetFocusToItem(i, "FuncType");
					return false;
				}
			}
			return true;
		}
		#endregion
	}
	#endregion

	#region CustomFunctionItemEditor
	/// <summary>
	/// CustomFunctionItemEditor에 대한 요약 설명입니다.
	/// </summary>
	internal class CustomFunctionItemEditor : System.Drawing.Design.UITypeEditor
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
					//Custom Type일때 버튼 초기화
					if (!(context.Instance is XButtonList)) return value;

					XButtonList btnList = (XButtonList) context.Instance;
					//CustomType이 아니면 처리 불가
					if (btnList.PerformerType != FunctionPerformerType.Custom) return value;

					// 속성창 ShowDialog에 표시할 Form 생성
					CustomFunctionItemEditorForm dlg = new CustomFunctionItemEditorForm((CustomFunctionItemCollection) value);
					//Dialog Show
					//ComponentChanged Event가 발생하지 않으면 이 편집기를 호출한 Form에서는 변경여부를 알수가 없으므로
					//InitializeComponent()를 다시 설정하지 않는다. 따라서, 반드시 해주어야 함.
					if( edSvc.ShowDialog(dlg) == DialogResult.OK)
					{
						context.OnComponentChanged();  // ComponentChanged 이벤트를 발생시켜 InitialzeComponent에 반영되록함
						
						// DesignMode에서도 ButtonList 의 각 Column정보 초기화
						btnList.InitializeButtons();

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
