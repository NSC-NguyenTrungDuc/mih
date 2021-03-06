using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Data;

namespace IHIS.Framework
{
	/// <summary>
	/// TextEditorForm에 대한 요약 설명입니다.
	/// </summary>
	public class XGridAddHeaderForm : System.Windows.Forms.Form
	{
		private IHIS.Framework.XButton btnAdd;
		private IHIS.Framework.XButton btnDelete;
		private IHIS.Framework.XButton btnCancel;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XDataGrid bindGrid;
		/// <summary>
		/// 추가된 Header를 관리하는 ArrayList입니다.
		/// </summary>
	
		public ArrayList AddedHeaders = new ArrayList();
		private System.Data.DataSet dataSet1;
		private System.Data.DataTable dataTable1;
		private System.Data.DataColumn dataColumn1;
		private IHIS.Framework.XDataGridTableStyle aDataGridTableStyle1;
		private IHIS.Framework.XDataGridStringTextBoxColumn aDataGridStringTextBoxColumn1;

		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// XGridAddHeaderForm 생성자
		/// </summary>
		public XGridAddHeaderForm()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			dataTable1.DefaultView.AllowNew = false;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAdd = new IHIS.Framework.XButton();
			this.btnDelete = new IHIS.Framework.XButton();
			this.btnCancel = new IHIS.Framework.XButton();
			this.btnOK = new IHIS.Framework.XButton();
			this.bindGrid = new IHIS.Framework.XDataGrid();
			this.dataTable1 = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.aDataGridTableStyle1 = new IHIS.Framework.XDataGridTableStyle();
			this.aDataGridStringTextBoxColumn1 = new IHIS.Framework.XDataGridStringTextBoxColumn();
			this.dataSet1 = new System.Data.DataSet();
			((System.ComponentModel.ISupportInitialize)(this.bindGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.Location = new System.Drawing.Point(3, 234);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(59, 24);
			this.btnAdd.TabIndex = 14;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.Location = new System.Drawing.Point(67, 234);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnDelete.Size = new System.Drawing.Size(59, 24);
			this.btnDelete.TabIndex = 13;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(245, 234);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(56, 24);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "취   소";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(181, 234);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(56, 24);
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "확   인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// bindGrid
			// 
			this.bindGrid.CaptionVisible = false;
			this.bindGrid.DataSource = this.dataTable1;
			this.bindGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bindGrid.Location = new System.Drawing.Point(5, 5);
			this.bindGrid.Name = "bindGrid";
			this.bindGrid.Size = new System.Drawing.Size(294, 222);
			this.bindGrid.TabIndex = 15;
			this.bindGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								 this.aDataGridTableStyle1});
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.dataColumn1});
			this.dataTable1.TableName = "bindTable";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "HeaderText";
			// 
			// aDataGridTableStyle1
			// 
			this.aDataGridTableStyle1.DataGrid = this.bindGrid;
			this.aDataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												   this.aDataGridStringTextBoxColumn1});
			this.aDataGridTableStyle1.MappingName = "bindTable";
			// 
			// aDataGridStringTextBoxColumn1
			// 
			this.aDataGridStringTextBoxColumn1.HeaderText = "Header Text";
			this.aDataGridStringTextBoxColumn1.MappingName = "HeaderText";
			this.aDataGridStringTextBoxColumn1.Width = 250;
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("ko-KR");
			this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
																		  this.dataTable1});
			// 
			// XGridAddHeaderForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(304, 262);
			this.ControlBox = false;
			this.Controls.Add(this.bindGrid);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.DockPadding.Bottom = 35;
			this.DockPadding.Left = 5;
			this.DockPadding.Right = 5;
			this.DockPadding.Top = 5;
			this.Name = "XGridAddHeaderForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Header 추가";
			((System.ComponentModel.ISupportInitialize)(this.bindGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// AcceptData
			this.bindGrid.AcceptData();
			
			//삭제된 행은 제외 ResetUpdate
			this.bindGrid.ResetUpdate();

			//Validation Check ,findColInfos Set
			if (!CheckValidation())	return;

			// AddedHeaders에 HeaderText Set
			for (int i = 0 ; i < this.bindGrid.RowCount; i++)
			{
				AddedHeaders.Add(this.bindGrid.GetItem(i,0).ToString());
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			this.bindGrid.InsertRow(-1);
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.bindGrid.DeleteRow(-1);
		}

		#region Private Method
		
		private bool CheckValidation()
		{
			// 1개이상의 Header는 반드시 입력
			if (this.bindGrid.RowCount < 1) 
			{
				XMessageBox.Show("추가 Header는 1개이상이어야 합니다.");
				return false;
			}
			// 필수입력사항 CHECK
			for (int i = 0; i < this.bindGrid.RowCount ; i++)
			{
				if (this.bindGrid.GetItem(i,0).ToString().Trim().Equals(""))
				{
					XMessageBox.Show( "Header의 Text가 입력되지 않았습니다.");
					return false;
				}
			}
			return true;
		}
		#endregion
	}
}