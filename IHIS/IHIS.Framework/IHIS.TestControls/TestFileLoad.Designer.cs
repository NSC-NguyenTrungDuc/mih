namespace IHIS.TestControls
{
    partial class TestFileLoad
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
            this.openFileDialogUSB = new System.Windows.Forms.OpenFileDialog();
            this.xButton1 = new IHIS.Framework.XButton();
            this.FileText = new IHIS.Framework.XTextBox();
            this.SuspendLayout();
            // 
            // openFileDialogUSB
            // 
            this.openFileDialogUSB.DefaultExt = "*.TXT";
            this.openFileDialogUSB.FileName = "ORDER.TXT";
            this.openFileDialogUSB.Filter = "IF 파일|*.TXT";
            // 
            // xButton1
            // 
            this.xButton1.Location = new System.Drawing.Point(12, 12);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(83, 36);
            this.xButton1.TabIndex = 2;
            this.xButton1.Text = "xButton1";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // FileText
            // 
            this.FileText.Location = new System.Drawing.Point(49, 67);
            this.FileText.Multiline = true;
            this.FileText.Name = "FileText";
            this.FileText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FileText.Size = new System.Drawing.Size(887, 259);
            this.FileText.TabIndex = 3;
            // 
            // TestFileLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 417);
            this.Controls.Add(this.FileText);
            this.Controls.Add(this.xButton1);
            this.Name = "TestFileLoad";
            this.Text = "TestFileLoad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IHIS.Framework.XButton xButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialogUSB;
        private IHIS.Framework.XTextBox FileText;        
    }
}