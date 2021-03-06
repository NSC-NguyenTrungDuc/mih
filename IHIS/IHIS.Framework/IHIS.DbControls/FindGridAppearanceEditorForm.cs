using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.Framework
{
	/// <summary>
	/// FormGridAppearance에 대한 요약 설명입니다.
	/// </summary>
	internal class FindGridAppearanceEditorForm : System.Windows.Forms.Form
	{
		private DataTable gridTable = new DataTable("Table");
		private DataGridTableStyle tblStyle = new DataGridTableStyle();
		private FindColumnInfoCollection colInfos = null;
		private IHIS.Framework.XButton btnOK;
		private IHIS.Framework.XButton btnCancel;
		private System.Windows.Forms.DataGrid dataGrid; //개별상속에서 사용가능
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FindGridAppearanceEditorForm(FindColumnInfoCollection colInfos)
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();
			
			this.colInfos = colInfos;
			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			InitializeGrid();
		}
		
		private void InitializeGrid()
		{
			DataColumn dtCol = null;
			DataGridTextBoxColumn dgColStyle = null;
			Type type = null;
			string formatStr = "";
			HorizontalAlignment align = HorizontalAlignment.Left;
			//1.컬럼정보로 DataTable 생성, 컬럼 Style 생성하여 테이블Style에 Add
			foreach (FindColumnInfo info in this.colInfos)
			{
				if (info.ColType == FindColType.String)
				{
					type = typeof(string);
					formatStr = "";
					align = HorizontalAlignment.Left;
				}
				else
				{
					type = typeof(double);
					formatStr = "n" + info.DecimalDigits.ToString();
					align = HorizontalAlignment.Right;
				}
				// 컬럼 생성 Add
				dtCol = new DataColumn(info.ColName, type);
				this.gridTable.Columns.Add(dtCol);

				// 컬럼 스타일 생성 Add
				dgColStyle = new DataGridTextBoxColumn();
				dgColStyle.MappingName = info.ColName;
				dgColStyle.HeaderText = info.HeaderText;
				dgColStyle.Format = formatStr;
				dgColStyle.Alignment = align;
				if (info.IsVisible)
					dgColStyle.Width = info.ColWidth;
				else
					dgColStyle.Width = 0;
				
				this.tblStyle.GridColumnStyles.Add(dgColStyle);

			}
			
			this.tblStyle.MappingName = this.gridTable.TableName;
			this.tblStyle.AllowSorting = false;
			this.tblStyle.RowHeaderWidth = 15;
			//Grid에 DataSource 연결, 테이블스타일 지정
			this.dataGrid.DataSource = gridTable;
			//AllowNew Property는 실행시 ArrowKey로 새행을 넣을 수 있는가의 여부
			//InsertRow Method를 통해서만 Insert가능하게 false로 설정
			this.gridTable.DefaultView.AllowNew = false;

			//TableStyles 지정
			this.dataGrid.TableStyles.Clear();
			this.dataGrid.TableStyles.Add(this.tblStyle);
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
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.btnOK = new IHIS.Framework.XButton();
			this.btnCancel = new IHIS.Framework.XButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid
			// 
			this.dataGrid.AllowNavigation = false;
			this.dataGrid.AllowSorting = false;
			this.dataGrid.CaptionVisible = false;
			this.dataGrid.DataMember = "";
			this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(5, 5);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.RowHeaderWidth = 15;
			this.dataGrid.Size = new System.Drawing.Size(566, 113);
			this.dataGrid.TabIndex = 0;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(398, 120);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(76, 26);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "확 인";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(494, 120);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnCancel.Size = new System.Drawing.Size(76, 26);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "취 소";
			// 
			// FindGridAppearanceEditorForm
			// 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(576, 148);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.dataGrid);
			this.DockPadding.Bottom = 30;
			this.DockPadding.Left = 5;
			this.DockPadding.Right = 5;
			this.DockPadding.Top = 5;
			this.Name = "FindGridAppearanceEditorForm";
			this.ShowInTaskbar = false;
			this.Text = "Find GRID 모양 편집기";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// GridColumnStyles의 변경된 정보를 FindColumnInfoCollection의 Width에 저장
			foreach (DataGridColumnStyle colStyle in this.dataGrid.TableStyles[0].GridColumnStyles)
			{
				// Width Set
				this.colInfos[colStyle.MappingName].ColWidth = colStyle.Width;
			}

			this.DialogResult = DialogResult.OK;
		}
	}
}
