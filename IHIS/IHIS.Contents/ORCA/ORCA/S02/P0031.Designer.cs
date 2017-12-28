namespace S02
{
    partial class P0031
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xTextBox1 = new IHIS.Framework.XTextBox();
            this.xTextBox2 = new IHIS.Framework.XTextBox();
            this.xButton1 = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // xTextBox1
            // 
            this.xTextBox1.Location = new System.Drawing.Point(21, 11);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(100, 20);
            this.xTextBox1.TabIndex = 0;
            this.xTextBox1.Text = "0031";
            // 
            // xTextBox2
            // 
            this.xTextBox2.Location = new System.Drawing.Point(21, 41);
            this.xTextBox2.Name = "xTextBox2";
            this.xTextBox2.Size = new System.Drawing.Size(516, 20);
            this.xTextBox2.TabIndex = 1;
            this.xTextBox2.Text = "Cannot find out-patient";
            // 
            // xButton1
            // 
            this.xButton1.Location = new System.Drawing.Point(245, 67);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(75, 27);
            this.xButton1.TabIndex = 2;
            this.xButton1.Text = "OK";
            // 
            // P0031
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 99);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.xTextBox2);
            this.Controls.Add(this.xTextBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "P0031";
            this.Text = "P0031";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IHIS.Framework.XTextBox xTextBox1;
        private IHIS.Framework.XTextBox xTextBox2;
        private IHIS.Framework.XButton xButton1;
    }
}