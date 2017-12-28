namespace EmrDocker
{
    partial class frEmrTemplateManager
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
            this.emrTemplateManager1 = new IHIS.OCSO.EmrTemplateManager();
            this.SuspendLayout();
            // 
            // emrTemplateManager1
            // 
            this.emrTemplateManager1.Location = new System.Drawing.Point(1, 0);
            this.emrTemplateManager1.Name = "emrTemplateManager1";
            this.emrTemplateManager1.Size = new System.Drawing.Size(559, 466);
            this.emrTemplateManager1.TabIndex = 0;
            // 
            // frEmrTemplateManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 496);
            this.Controls.Add(this.emrTemplateManager1);
            this.Name = "frEmrTemplateManager";
            this.Text = "frEmrTemplateManager";
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.OCSO.EmrTemplateManager emrTemplateManager1;
    }
}