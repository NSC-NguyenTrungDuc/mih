using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.NURO
{
	/// <summary>
	/// FormReser에 대한 요약 설명입니다.
	/// </summary>
	public class FormReser : IHIS.Framework.XForm
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XLabel xLabel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XPanel xPanel3;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGrid grdList;
		private IHIS.Framework.XButton btnClose;
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormReser(string aBunho, string aNaewonDate)
		{
			// 이 호출은 Windows.Forms Form 디자이너에 필요합니다.
			InitializeComponent();

			// TODO: InitializeComponent를 호출한 다음 초기화 작업을 추가합니다.
			this.mBunho = aBunho;
			this.mNaewonDate = aNaewonDate;

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

		#region 구성 요소 디자이너에서 생성한 코드
		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReser));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnClose = new IHIS.Framework.XButton();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdList);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.pictureBox1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(462, 239);
            this.xPanel1.TabIndex = 1;
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1});
            this.grdList.ColPerLine = 1;
            this.grdList.Cols = 2;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.FixedCols = 1;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(0);
            this.grdList.Location = new System.Drawing.Point(0, 38);
            this.grdList.Name = "grdList";
            this.grdList.QuerySQL = "SELECT HANGMOG_NAME\r\n     , HANGMOG_CODE   CONT_KEY\r\n  FROM VW_PFE_RESER\r\n WHERE " +
                "HOSP_CODE  = :f_hosp_code\r\n   AND BUNHO      = :f_bunho\r\n   AND RESER_DATE = :f_" +
                "naewon_date\r\n ORDER BY HANGMOG_NAME";
            this.grdList.ReadOnly = true;
            this.grdList.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdList.RowHeaderVisible = true;
            this.grdList.Rows = 2;
            this.grdList.Size = new System.Drawing.Size(462, 201);
            this.grdList.TabIndex = 39;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_name";
            this.xEditGridCell1.CellWidth = 414;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "項目名";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.Location = new System.Drawing.Point(0, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(462, 38);
            this.xPanel3.TabIndex = 38;
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel2.Location = new System.Drawing.Point(3, 5);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(198, 29);
            this.xLabel2.TabIndex = 37;
            this.xLabel2.Text = "   当 日 検 査 予 約";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(462, 239);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnClose);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 203);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(462, 36);
            this.xPanel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(372, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnClose.Size = new System.Drawing.Size(80, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormReser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "当日検査予約";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FormReser_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 사용자 변수

		private string mBunho      = "";
		private string mNaewonDate = "";

		string mMsg = string.Empty;
		string mCap = string.Empty;

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormReser_Load(object sender, System.EventArgs e)
        {
            this.grdList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
			this.grdList.SetBindVarValue("f_bunho"      , mBunho);
			this.grdList.SetBindVarValue("f_naewon_date", mNaewonDate);

			if(!this.grdList.QueryLayout(false))
			{
				XMessageBox.Show(Service.ErrFullMsg + " : FormReser Query Error");
			}

			if (this.grdList.RowCount > 0)
			{
				this.WindowState = FormWindowState.Normal;
			}
			else
			{
				this.btnClose.PerformClick();
			}
		}

		#region 닫기 버튼 클릭
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		#endregion


	}
}
