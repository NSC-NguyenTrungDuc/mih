namespace IHIS.BASS
{
    partial class BAS2015U00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS2015U00));
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.rdb6 = new System.Windows.Forms.RadioButton();
            this.rdb5 = new System.Windows.Forms.RadioButton();
            this.rdb4 = new System.Windows.Forms.RadioButton();
            this.rdb3 = new System.Windows.Forms.RadioButton();
            this.rdb2 = new System.Windows.Forms.RadioButton();
            this.rdb1 = new System.Windows.Forms.RadioButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xMSG = new IHIS.Framework.XTextBox();
            this.btnSearchFile = new IHIS.Framework.XButton();
            this.txtFileDirectory = new IHIS.Framework.XTextBox();
            this.pathFile = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.progressBar);
            this.xPanel1.Controls.Add(this.rdb6);
            this.xPanel1.Controls.Add(this.rdb5);
            this.xPanel1.Controls.Add(this.rdb4);
            this.xPanel1.Controls.Add(this.rdb3);
            this.xPanel1.Controls.Add(this.rdb2);
            this.xPanel1.Controls.Add(this.rdb1);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Controls.Add(this.xMSG);
            this.xPanel1.Controls.Add(this.btnSearchFile);
            this.xPanel1.Controls.Add(this.txtFileDirectory);
            this.xPanel1.Controls.Add(this.pathFile);
            this.xPanel1.Controls.Add(this.xLabel11);
            this.xPanel1.Controls.Add(this.xLabel10);
            this.xPanel1.Controls.Add(this.xLabel9);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // progressBar
            // 
            this.progressBar.AccessibleDescription = null;
            this.progressBar.AccessibleName = null;
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.BackgroundImage = null;
            this.progressBar.Font = null;
            this.progressBar.Name = "progressBar";
            // 
            // rdb6
            // 
            this.rdb6.AccessibleDescription = null;
            this.rdb6.AccessibleName = null;
            resources.ApplyResources(this.rdb6, "rdb6");
            this.rdb6.BackgroundImage = null;
            this.rdb6.Font = null;
            this.rdb6.Name = "rdb6";
            this.rdb6.TabStop = true;
            this.rdb6.Tag = "DRUG_GENERIC_NAME";
            this.rdb6.UseVisualStyleBackColor = true;
            this.rdb6.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdb5
            // 
            this.rdb5.AccessibleDescription = null;
            this.rdb5.AccessibleName = null;
            resources.ApplyResources(this.rdb5, "rdb5");
            this.rdb5.BackgroundImage = null;
            this.rdb5.Font = null;
            this.rdb5.Name = "rdb5";
            this.rdb5.TabStop = true;
            this.rdb5.Tag = "DRUG_INTERACTION";
            this.rdb5.UseVisualStyleBackColor = true;
            this.rdb5.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdb4
            // 
            this.rdb4.AccessibleDescription = null;
            this.rdb4.AccessibleName = null;
            resources.ApplyResources(this.rdb4, "rdb4");
            this.rdb4.BackgroundImage = null;
            this.rdb4.Font = null;
            this.rdb4.Name = "rdb4";
            this.rdb4.TabStop = true;
            this.rdb4.Tag = "DRUG_CHECKING";
            this.rdb4.UseVisualStyleBackColor = true;
            this.rdb4.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdb3
            // 
            this.rdb3.AccessibleDescription = null;
            this.rdb3.AccessibleName = null;
            resources.ApplyResources(this.rdb3, "rdb3");
            this.rdb3.BackgroundImage = null;
            this.rdb3.Font = null;
            this.rdb3.Name = "rdb3";
            this.rdb3.TabStop = true;
            this.rdb3.Tag = "DRUG_DOSAGE";
            this.rdb3.UseVisualStyleBackColor = true;
            this.rdb3.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdb2
            // 
            this.rdb2.AccessibleDescription = null;
            this.rdb2.AccessibleName = null;
            resources.ApplyResources(this.rdb2, "rdb2");
            this.rdb2.BackgroundImage = null;
            this.rdb2.Font = null;
            this.rdb2.Name = "rdb2";
            this.rdb2.TabStop = true;
            this.rdb2.Tag = "DRUG_KINKI_DISEASE";
            this.rdb2.UseVisualStyleBackColor = true;
            this.rdb2.Click += new System.EventHandler(this.rdb_Click);
            // 
            // rdb1
            // 
            this.rdb1.AccessibleDescription = null;
            this.rdb1.AccessibleName = null;
            resources.ApplyResources(this.rdb1, "rdb1");
            this.rdb1.BackgroundImage = null;
            this.rdb1.Font = null;
            this.rdb1.Name = "rdb1";
            this.rdb1.TabStop = true;
            this.rdb1.Tag = "DRUG_KINKI_MESSAGE";
            this.rdb1.UseVisualStyleBackColor = true;
            this.rdb1.Click += new System.EventHandler(this.rdb_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None,Resources.BTN_LIST_UPDATE_TEXT, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, Resources.BTN_LIST_EXCUTE_TEXT, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xMSG
            // 
            this.xMSG.AccessibleDescription = null;
            this.xMSG.AccessibleName = null;
            resources.ApplyResources(this.xMSG, "xMSG");
            this.xMSG.BackgroundImage = null;
            this.xMSG.Name = "xMSG";
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.AccessibleDescription = null;
            this.btnSearchFile.AccessibleName = null;
            resources.ApplyResources(this.btnSearchFile, "btnSearchFile");
            this.btnSearchFile.BackgroundImage = null;
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // txtFileDirectory
            // 
            this.txtFileDirectory.AccessibleDescription = null;
            this.txtFileDirectory.AccessibleName = null;
            resources.ApplyResources(this.txtFileDirectory, "txtFileDirectory");
            this.txtFileDirectory.BackgroundImage = null;
            this.txtFileDirectory.Name = "txtFileDirectory";
            // 
            // pathFile
            // 
            this.pathFile.AccessibleDescription = null;
            this.pathFile.AccessibleName = null;
            resources.ApplyResources(this.pathFile, "pathFile");
            this.pathFile.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.pathFile.EdgeRounding = false;
            this.pathFile.Image = null;
            this.pathFile.Name = "pathFile";
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // BAS2015U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS2015U00";
            this.Load += new System.EventHandler(this.BAS2015U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XLabel xLabel8;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XLabel xLabel11;
        private IHIS.Framework.XLabel xLabel10;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButton btnSearchFile;
        private IHIS.Framework.XTextBox txtFileDirectory;
        private IHIS.Framework.XLabel pathFile;
        private IHIS.Framework.XTextBox xMSG;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RadioButton rdb3;
        private System.Windows.Forms.RadioButton rdb2;
        private System.Windows.Forms.RadioButton rdb1;
        private System.Windows.Forms.RadioButton rdb6;
        private System.Windows.Forms.RadioButton rdb5;
        private System.Windows.Forms.RadioButton rdb4;
        private System.Windows.Forms.ProgressBar progressBar;


    }
}
