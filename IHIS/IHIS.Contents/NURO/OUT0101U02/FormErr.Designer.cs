namespace IHIS.NURO
{
    partial class FormErr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormErr));
            this.panelTop = new IHIS.Framework.XPanel();
            this.btnExportErr = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.labelSex = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.AccessibleDescription = null;
            this.panelTop.AccessibleName = null;
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.BackgroundImage = null;
            this.panelTop.Controls.Add(this.btnExportErr);
            this.panelTop.Controls.Add(this.btnCancel);
            this.panelTop.Controls.Add(this.labelSex);
            this.panelTop.Font = null;
            this.panelTop.Name = "panelTop";
            // 
            // btnExportErr
            // 
            this.btnExportErr.AccessibleDescription = null;
            this.btnExportErr.AccessibleName = null;
            resources.ApplyResources(this.btnExportErr, "btnExportErr");
            this.btnExportErr.BackgroundImage = null;
            this.btnExportErr.Name = "btnExportErr";
            this.btnExportErr.Click += new System.EventHandler(this.btnExportErr_Click);
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
            // labelSex
            // 
            this.labelSex.AccessibleDescription = null;
            this.labelSex.AccessibleName = null;
            resources.ApplyResources(this.labelSex, "labelSex");
            this.labelSex.Name = "labelSex";
            // 
            // FormErr
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.panelTop);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormErr";
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel panelTop;
        private System.Windows.Forms.Label labelSex;
        private IHIS.Framework.XButton btnExportErr;
        private IHIS.Framework.XButton btnCancel;
    }
}