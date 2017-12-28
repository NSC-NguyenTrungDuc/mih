namespace IHIS.NURO
{
    partial class ShowPWD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPWD));
            this.btnShowPWD1 = new IHIS.Framework.XButton();
            this.btnShowPWD = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.btnGenPWD = new IHIS.Framework.XButton();
            this.SuspendLayout();
            // 
            // btnShowPWD1
            // 
            this.btnShowPWD1.AccessibleDescription = null;
            this.btnShowPWD1.AccessibleName = null;
            resources.ApplyResources(this.btnShowPWD1, "btnShowPWD1");
            this.btnShowPWD1.BackgroundImage = null;
            this.btnShowPWD1.Image = global::IHIS.NURO.Properties.Resources.Print;
            this.btnShowPWD1.Name = "btnShowPWD1";
            this.btnShowPWD1.Click += new System.EventHandler(this.btnShowPWD_Click);
            // 
            // btnShowPWD
            // 
            this.btnShowPWD.AccessibleDescription = null;
            this.btnShowPWD.AccessibleName = null;
            resources.ApplyResources(this.btnShowPWD, "btnShowPWD");
            this.btnShowPWD.BackgroundImage = null;
            this.btnShowPWD.Image = global::IHIS.NURO.Properties.Resources.Print;
            this.btnShowPWD.Name = "btnShowPWD";
            this.btnShowPWD.Click += new System.EventHandler(this.btnShowPWD_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = null;
            this.btnCancel.AccessibleName = null;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.BackgroundImage = null;
            this.btnCancel.Image = global::IHIS.NURO.Properties.Resources.Close;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGenPWD
            // 
            this.btnGenPWD.AccessibleDescription = null;
            this.btnGenPWD.AccessibleName = null;
            resources.ApplyResources(this.btnGenPWD, "btnGenPWD");
            this.btnGenPWD.BackgroundImage = null;
            this.btnGenPWD.Image = global::IHIS.NURO.Properties.Resources.change_password_icon;
            this.btnGenPWD.Name = "btnGenPWD";
            this.btnGenPWD.Click += new System.EventHandler(this.btnGenPWD_Click);
            // 
            // ShowPWD
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btnGenPWD);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnShowPWD);
            this.Controls.Add(this.btnShowPWD1);
            this.Name = "ShowPWD";
            this.Controls.SetChildIndex(this.btnShowPWD1, 0);
            this.Controls.SetChildIndex(this.btnShowPWD, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnGenPWD, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XButton btnShowPWD1;
        private IHIS.Framework.XButton btnShowPWD;
        private IHIS.Framework.XButton btnCancel;
        private IHIS.Framework.XButton btnGenPWD;
    }
}