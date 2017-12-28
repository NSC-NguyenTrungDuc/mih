namespace IHIS.NURO
{
    partial class RevertReason
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevertReason));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.txtReason = new IHIS.Framework.XRichTextBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnSubmit = new IHIS.Framework.XButton();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.txtReason);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // txtReason
            // 
            this.txtReason.AccessibleDescription = null;
            this.txtReason.AccessibleName = null;
            resources.ApplyResources(this.txtReason, "txtReason");
            this.txtReason.BackgroundImage = null;
            this.txtReason.Name = "txtReason";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnCancel);
            this.xPanel2.Controls.Add(this.btnSubmit);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.AccessibleDescription = null;
            this.btnSubmit.AccessibleName = null;
            resources.ApplyResources(this.btnSubmit, "btnSubmit");
            this.btnSubmit.BackgroundImage = null;
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // RevertReason
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Icon = null;
            this.Name = "RevertReason";
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XRichTextBox txtReason;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XButton btnSubmit;
    }
}