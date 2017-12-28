using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.CPLS
{
	/// <summary>
	/// Summary description for ProgressForm.
	/// </summary>
	internal class ProgressForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label TITLE;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ProgressForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ProgressForm));
			this.TITLE = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// TITLE
			// 
			this.TITLE.BackColor = System.Drawing.Color.Transparent;
			this.TITLE.Dock = System.Windows.Forms.DockStyle.Top;
			this.TITLE.Location = new System.Drawing.Point(0, 0);
			this.TITLE.Name = "TITLE";
			this.TITLE.Size = new System.Drawing.Size(379, 29);
			this.TITLE.TabIndex = 2;
			this.TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(7, 34);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(366, 17);
			this.progressBar1.TabIndex = 1;
			// 
			// ProgressForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(379, 58);
			this.ControlBox = false;
			this.Controls.Add(this.TITLE);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "ProgressForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProgressForm";
			this.ResumeLayout(false);

		}
		#endregion

		public void UpdateTitle(string mtxt)
		{
			TITLE.Text = mtxt ;
			Update();
		}

		public void Init(string maxpos , string mttl)
		{
			progressBar1.Minimum = 0;
			progressBar1.Maximum = int.Parse(maxpos);
			TITLE.Text = mttl ;
			Update();
		}

		public void MoveProgress(int nstep)
		{
			progressBar1.Value = nstep;
			Update();
		}

		public void MoveProgress(int nstep , string mtxt)
		{
			progressBar1.Value = nstep;
			TITLE.Text = mtxt ;
			Update();
		}
	}
}
