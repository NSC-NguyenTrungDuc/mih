namespace IHIS.OCSO
{
    partial class OCS2015U04C
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2015U04C));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tvBunho = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelBookmark,
            this.mnuEditBookmark});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // mnuDelBookmark
            // 
            this.mnuDelBookmark.Name = "mnuDelBookmark";
            resources.ApplyResources(this.mnuDelBookmark, "mnuDelBookmark");
            this.mnuDelBookmark.Tag = "mnuDelBookmark";
            // 
            // mnuEditBookmark
            // 
            this.mnuEditBookmark.Name = "mnuEditBookmark";
            resources.ApplyResources(this.mnuEditBookmark, "mnuEditBookmark");
            this.mnuEditBookmark.Tag = "mnuEditBookmark";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BASS.ico");
            // 
            // tvBunho
            // 
            this.tvBunho.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.tvBunho, "tvBunho");
            this.tvBunho.ImageList = this.imageList1;
            this.tvBunho.Name = "tvBunho";
            // 
            // OCS2015U04C
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvBunho);
            this.Name = "OCS2015U04C";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelBookmark;
        private System.Windows.Forms.ToolStripMenuItem mnuEditBookmark;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView tvBunho;
    }
}
