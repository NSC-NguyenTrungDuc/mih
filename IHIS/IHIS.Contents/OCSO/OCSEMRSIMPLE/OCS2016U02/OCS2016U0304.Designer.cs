namespace IHIS.OCSO
{
    partial class OCS2016U0304
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2016U0304));
            this.tabGroupOCS2016U0304 = new DevExpress.XtraTab.XtraTabControl();
            this.tabU03 = new DevExpress.XtraTab.XtraTabPage();
            this.ocS2015U03C1 = new IHIS.OCSO.OCS2015U03C();
            this.tabU04 = new DevExpress.XtraTab.XtraTabPage();
            this.ocS2015U04C1 = new IHIS.OCSO.OCS2015U04C();
            ((System.ComponentModel.ISupportInitialize)(this.tabGroupOCS2016U0304)).BeginInit();
            this.tabGroupOCS2016U0304.SuspendLayout();
            this.tabU03.SuspendLayout();
            this.tabU04.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGroupOCS2016U0304
            // 
            resources.ApplyResources(this.tabGroupOCS2016U0304, "tabGroupOCS2016U0304");
            this.tabGroupOCS2016U0304.Name = "tabGroupOCS2016U0304";
            this.tabGroupOCS2016U0304.SelectedTabPage = this.tabU03;
            this.tabGroupOCS2016U0304.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabU03,
            this.tabU04});
            // 
            // tabU03
            // 
            this.tabU03.Controls.Add(this.ocS2015U03C1);
            this.tabU03.Name = "tabU03";
            resources.ApplyResources(this.tabU03, "tabU03");
            // 
            // ocS2015U03C1
            // 
            resources.ApplyResources(this.ocS2015U03C1, "ocS2015U03C1");
            this.ocS2015U03C1.Name = "ocS2015U03C1";
            // 
            // tabU04
            // 
            this.tabU04.Controls.Add(this.ocS2015U04C1);
            this.tabU04.Name = "tabU04";
            resources.ApplyResources(this.tabU04, "tabU04");
            // 
            // ocS2015U04C1
            // 
            resources.ApplyResources(this.ocS2015U04C1, "ocS2015U04C1");
            this.ocS2015U04C1.IsEnableRightClick = false;
            this.ocS2015U04C1.Name = "ocS2015U04C1";
            // 
            // OCS2016U0304
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabGroupOCS2016U0304);
            this.MaximumSize = new System.Drawing.Size(270, 139);
            this.MinimumSize = new System.Drawing.Size(270, 139);
            this.Name = "OCS2016U0304";
            ((System.ComponentModel.ISupportInitialize)(this.tabGroupOCS2016U0304)).EndInit();
            this.tabGroupOCS2016U0304.ResumeLayout(false);
            this.tabU03.ResumeLayout(false);
            this.tabU03.PerformLayout();
            this.tabU04.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabGroupOCS2016U0304;
        private DevExpress.XtraTab.XtraTabPage tabU03;
        private DevExpress.XtraTab.XtraTabPage tabU04;
        public OCS2015U03C ocS2015U03C1;
        public OCS2015U04C ocS2015U04C1;

    }
}
