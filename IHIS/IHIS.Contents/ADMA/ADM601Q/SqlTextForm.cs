using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.ADMA
{
	/// <summary>
	/// SqlTextForm�� ��E� �侁E�����Դϴ�.
	/// </summary>
	public class SqlTextForm : System.Windows.Forms.Form
	{
		private IHIS.Framework.XButton btnClose;
		private System.Windows.Forms.RichTextBox txtSql;
		/// <summary>
		/// �ʼ�E�����̳� �����Դϴ�.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SqlTextForm(string sqlText)
		{
			//
			// Windows Form �����̳� ������ �ʿ��մϴ�.
			//
			InitializeComponent();

			this.txtSql.Text = sqlText;
		}

		/// <summary>
		/// �翁E���� ��E���ҽ��� �����մϴ�.
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

		#region Windows Form �����̳ʿ��� ������ �ڵ�E
		/// <summary>
		/// �����̳� ������ �ʿ��� �޼����Դϴ�.
		/// �� �޼����� ����E� �ڵ�E������� ��������E���ʽÿ�.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SqlTextForm));
			this.txtSql = new System.Windows.Forms.RichTextBox();
			this.btnClose = new IHIS.Framework.XButton();
			this.SuspendLayout();
			// 
			// txtSql
			// 
			this.txtSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSql.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtSql.Location = new System.Drawing.Point(2, 2);
			this.txtSql.Name = "txtSql";
			this.txtSql.ReadOnly = true;
			this.txtSql.Size = new System.Drawing.Size(428, 422);
			this.txtSql.TabIndex = 0;
			this.txtSql.Text = "";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
			this.btnClose.Location = new System.Drawing.Point(348, 426);
			this.btnClose.Name = "btnClose";
			this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
			this.btnClose.Size = new System.Drawing.Size(80, 28);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "�ͪ���E";
			// 
			// SqlTextForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(432, 456);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtSql);
			this.DockPadding.All = 2;
			this.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SqlTextForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SQL TEXT";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
