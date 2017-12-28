using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHIS.SCHS
{
	/// <summary>
	/// frmHangmogCode에 대한 요약 설명입니다.
	/// </summary>
	public class frmHPCHangmogCode : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XButton xbtnExit;
		private IHIS.Framework.XButton xbtnSelect;
		private IHIS.Framework.XEditGrid grdHangmog;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHPCHangmogCode()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//

            this.grdHangmog.QueryLayout(false);

		}

		#region fields
        private string mHangmogCode = "";
        private string mHospCode = "";
		#endregion

		#region properties
		public string HangmogCode
		{
			get { return mHangmogCode; }
		}

        public string HospCode
        {
            get { return mHospCode; }
            set { this.mHospCode = value; }
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


		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHPCHangmogCode));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdHangmog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xbtnSelect = new IHIS.Framework.XButton();
            this.xbtnExit = new IHIS.Framework.XButton();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdHangmog);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 5);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel2.Size = new System.Drawing.Size(350, 358);
            this.xPanel2.TabIndex = 2;
            // 
            // grdHangmog
            // 
            this.grdHangmog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdHangmog.ColPerLine = 1;
            this.grdHangmog.Cols = 2;
            this.grdHangmog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHangmog.FixedCols = 1;
            this.grdHangmog.FixedRows = 1;
            this.grdHangmog.HeaderHeights.Add(21);
            this.grdHangmog.Location = new System.Drawing.Point(2, 2);
            this.grdHangmog.Name = "grdHangmog";
            this.grdHangmog.QuerySQL = resources.GetString("grdHangmog.QuerySQL");
            this.grdHangmog.RowHeaderVisible = true;
            this.grdHangmog.Rows = 2;
            this.grdHangmog.Size = new System.Drawing.Size(344, 352);
            this.grdHangmog.TabIndex = 0;
            this.grdHangmog.DoubleClick += new System.EventHandler(this.grdHangmog_DoubleClick);
            this.grdHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmog_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_code";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "hangmog_code";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "hangmog_name";
            this.xEditGridCell4.CellWidth = 300;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.HeaderText = "検査名";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xbtnSelect);
            this.xPanel3.Controls.Add(this.xbtnExit);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(5, 363);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(350, 32);
            this.xPanel3.TabIndex = 3;
            // 
            // xbtnSelect
            // 
            this.xbtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnSelect.Location = new System.Drawing.Point(183, 2);
            this.xbtnSelect.Name = "xbtnSelect";
            this.xbtnSelect.Size = new System.Drawing.Size(80, 27);
            this.xbtnSelect.TabIndex = 1;
            this.xbtnSelect.Text = "保存";
            this.xbtnSelect.Click += new System.EventHandler(this.xbtnSelect_Click);
            // 
            // xbtnExit
            // 
            this.xbtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xbtnExit.Location = new System.Drawing.Point(263, 2);
            this.xbtnExit.Name = "xbtnExit";
            this.xbtnExit.Size = new System.Drawing.Size(80, 27);
            this.xbtnExit.TabIndex = 0;
            this.xbtnExit.Text = "閉じる";
            this.xbtnExit.Click += new System.EventHandler(this.xbtnExit_Click);
            // 
            // frmHPCHangmogCode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(360, 422);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Name = "frmHPCHangmogCode";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "撮影";
            this.Controls.SetChildIndex(this.xPanel3, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void xbtnSelect_Click(object sender, System.EventArgs e)
		{
			int row = grdHangmog.CurrentRowNumber;
			if (row < 0) return;

			mHangmogCode = grdHangmog.GetItemString(row, "hangmog_code");

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void xbtnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void grdHangmog_DoubleClick(object sender, System.EventArgs e)
		{
			int row = grdHangmog.CurrentRowNumber;
			if (row < 0) return;

			mHangmogCode = grdHangmog.GetItemString(row, "hangmog_code");

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

        private void grdHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdHangmog.SetBindVarValue("f_hosp_code", this.HospCode);
        }
	}
}