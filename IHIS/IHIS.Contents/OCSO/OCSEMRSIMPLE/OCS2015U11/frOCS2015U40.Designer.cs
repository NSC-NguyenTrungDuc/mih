namespace IHIS.OCSO
{
    partial class frOCS2015U40
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frOCS2015U40));
            this.btnExit = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.ImageIndex = 18;
            this.btnExit.Name = "btnExit";
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frOCS2015U40
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Name = "frOCS2015U40";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.XButton btnExit;
    }
}