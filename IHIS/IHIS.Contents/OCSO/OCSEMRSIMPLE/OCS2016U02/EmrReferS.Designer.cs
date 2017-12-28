namespace IHIS.OCSO
{
    partial class EmrReferS
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucView2 = new EmrDocker.UcViewS();
            this.panel2 = new System.Windows.Forms.Panel();
            this.emrHis = new IHIS.OCSO.OCS2015U03C();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bookMark = new IHIS.OCSO.OCS2015U04C();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ucView2);
            this.panel1.Location = new System.Drawing.Point(376, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 535);
            this.panel1.TabIndex = 1;
            // 
            // ucView2
            // 
            this.ucView2.Bunho = "";
            this.ucView2.CurrentPkout = null;
            this.ucView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucView2.IsEnableBtnEdit = true;
            this.ucView2.Location = new System.Drawing.Point(0, 0);
            this.ucView2.NaewonDate = "";
            this.ucView2.NaewonKey = "";
            this.ucView2.Name = "ucView2";
            this.ucView2.Pkout1001 = "";
            this.ucView2.Record_id = "";
            this.ucView2.Size = new System.Drawing.Size(791, 533);
            this.ucView2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.emrHis);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 258);
            this.panel2.TabIndex = 2;
            // 
            // emrHis
            // 
            this.emrHis.AutoSize = true;
            this.emrHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emrHis.Location = new System.Drawing.Point(0, 0);
            this.emrHis.Margin = new System.Windows.Forms.Padding(0);
            this.emrHis.Name = "emrHis";
            this.emrHis.Size = new System.Drawing.Size(373, 256);
            this.emrHis.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bookMark);
            this.panel3.Location = new System.Drawing.Point(1, 261);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 274);
            this.panel3.TabIndex = 3;
            // 
            // bookMark
            // 
            this.bookMark.AutoScroll = true;
            this.bookMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookMark.IsEnableRightClick = false;
            this.bookMark.Location = new System.Drawing.Point(0, 0);
            this.bookMark.Name = "bookMark";
            this.bookMark.Size = new System.Drawing.Size(374, 274);
            this.bookMark.TabIndex = 0;
            // 
            // EmrRefer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 557);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EmrRefer";
            this.Text = "EmrRefer";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private global::EmrDocker.UcViewS ucView2;
        private OCS2015U03C emrHis;
        private System.Windows.Forms.Panel panel3;
        private OCS2015U04C bookMark;
    }
}