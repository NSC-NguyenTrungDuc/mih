namespace IHIS.TestControls
{
    partial class TestXProgressBar
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.xProgressBar1 = new IHIS.Framework.XProgressBar();
            this.xProgressBar2 = new IHIS.Framework.XProgressBar();
            this.PgbBar = new IHIS.Framework.XProgressBar();
            this.xButton3 = new IHIS.Framework.XButton();
            this.xButton4 = new IHIS.Framework.XButton();
            this.xButton2 = new IHIS.Framework.XButton();
            this.xButton1 = new IHIS.Framework.XButton();
            this.MinPgbBar = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.MaxPgbBar = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.AddPgbBar = new IHIS.Framework.XTextBox();
            this.MsgPgbBar = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.SuspendLayout();
            // 
            // xProgressBar1
            // 
            this.xProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.xProgressBar1.Name = "xProgressBar1";
            this.xProgressBar1.Size = new System.Drawing.Size(100, 29);
            this.xProgressBar1.TabIndex = 0;
            // 
            // xProgressBar2
            // 
            this.xProgressBar2.Location = new System.Drawing.Point(0, 0);
            this.xProgressBar2.Name = "xProgressBar2";
            this.xProgressBar2.Size = new System.Drawing.Size(100, 29);
            this.xProgressBar2.TabIndex = 0;
            // 
            // PgbBar
            // 
            this.PgbBar.Location = new System.Drawing.Point(37, 27);
            this.PgbBar.Name = "PgbBar";
            this.PgbBar.Size = new System.Drawing.Size(262, 29);
            this.PgbBar.TabIndex = 0;
            // 
            // xButton3
            // 
            this.xButton3.Location = new System.Drawing.Point(230, 99);
            this.xButton3.Name = "xButton3";
            this.xButton3.Size = new System.Drawing.Size(69, 35);
            this.xButton3.TabIndex = 5;
            this.xButton3.Text = "End";
            this.xButton3.Click += new System.EventHandler(this.xButton3_Click);
            // 
            // xButton4
            // 
            this.xButton4.Location = new System.Drawing.Point(132, 132);
            this.xButton4.Name = "xButton4";
            this.xButton4.Size = new System.Drawing.Size(69, 35);
            this.xButton4.TabIndex = 6;
            this.xButton4.Text = "Add";
            this.xButton4.Click += new System.EventHandler(this.xButton4_Click);
            // 
            // xButton2
            // 
            this.xButton2.Location = new System.Drawing.Point(132, 77);
            this.xButton2.Name = "xButton2";
            this.xButton2.Size = new System.Drawing.Size(69, 35);
            this.xButton2.TabIndex = 3;
            this.xButton2.Text = "Start";
            this.xButton2.Click += new System.EventHandler(this.xButton2_Click);
            // 
            // xButton1
            // 
            this.xButton1.Location = new System.Drawing.Point(37, 99);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(69, 35);
            this.xButton1.TabIndex = 4;
            this.xButton1.Text = "Init";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // MinPgbBar
            // 
            this.MinPgbBar.Location = new System.Drawing.Point(115, 217);
            this.MinPgbBar.Name = "MinPgbBar";
            this.MinPgbBar.Size = new System.Drawing.Size(59, 20);
            this.MinPgbBar.TabIndex = 7;
            this.MinPgbBar.Text = "0";
            this.MinPgbBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xLabel1
            // 
            this.xLabel1.AutoSize = true;
            this.xLabel1.Location = new System.Drawing.Point(37, 219);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(27, 13);
            this.xLabel1.TabIndex = 8;
            this.xLabel1.Text = "Min";
            // 
            // xLabel2
            // 
            this.xLabel2.AutoSize = true;
            this.xLabel2.Location = new System.Drawing.Point(37, 271);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(29, 13);
            this.xLabel2.TabIndex = 8;
            this.xLabel2.Text = "Max";
            // 
            // MaxPgbBar
            // 
            this.MaxPgbBar.Location = new System.Drawing.Point(115, 271);
            this.MaxPgbBar.Name = "MaxPgbBar";
            this.MaxPgbBar.Size = new System.Drawing.Size(59, 20);
            this.MaxPgbBar.TabIndex = 7;
            this.MaxPgbBar.Text = "100";
            this.MaxPgbBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // xLabel3
            // 
            this.xLabel3.AutoSize = true;
            this.xLabel3.Location = new System.Drawing.Point(37, 244);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(25, 13);
            this.xLabel3.TabIndex = 8;
            this.xLabel3.Text = "add";
            // 
            // AddPgbBar
            // 
            this.AddPgbBar.Location = new System.Drawing.Point(115, 244);
            this.AddPgbBar.Name = "AddPgbBar";
            this.AddPgbBar.Size = new System.Drawing.Size(59, 20);
            this.AddPgbBar.TabIndex = 7;
            this.AddPgbBar.Text = "10";
            this.AddPgbBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MsgPgbBar
            // 
            this.MsgPgbBar.Location = new System.Drawing.Point(115, 191);
            this.MsgPgbBar.Name = "MsgPgbBar";
            this.MsgPgbBar.Size = new System.Drawing.Size(184, 20);
            this.MsgPgbBar.TabIndex = 7;
            this.MsgPgbBar.Text = "Working... ";
            // 
            // xLabel4
            // 
            this.xLabel4.AutoSize = true;
            this.xLabel4.Location = new System.Drawing.Point(35, 191);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(33, 13);
            this.xLabel4.TabIndex = 8;
            this.xLabel4.Text = "Text";
            // 
            // TestXProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 340);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.xLabel3);
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.MaxPgbBar);
            this.Controls.Add(this.AddPgbBar);
            this.Controls.Add(this.MsgPgbBar);
            this.Controls.Add(this.MinPgbBar);
            this.Controls.Add(this.xButton3);
            this.Controls.Add(this.xButton4);
            this.Controls.Add(this.xButton2);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.PgbBar);
            this.Name = "TestXProgressBar";
            this.Text = "TestXProgressBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IHIS.Framework.XProgressBar xProgressBar1;
        private IHIS.Framework.XProgressBar xProgressBar2;
        private IHIS.Framework.XProgressBar PgbBar;
        private IHIS.Framework.XButton xButton3;
        private IHIS.Framework.XButton xButton4;
        private IHIS.Framework.XButton xButton2;
        private IHIS.Framework.XButton xButton1;
        private IHIS.Framework.XTextBox MinPgbBar;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XTextBox MaxPgbBar;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XTextBox AddPgbBar;
        private IHIS.Framework.XTextBox MsgPgbBar;
        private IHIS.Framework.XLabel xLabel4;
    }
}