namespace IHIS.OCSO
{
    partial class UCBtnList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCBtnList));
            this.panelBtnINJ = new IHIS.Framework.XPanel();
            this.btnListINJ = new IHIS.Framework.XButtonList();
            this.btnLabel = new IHIS.Framework.XButton();
            this.btnChkAllJubsu = new IHIS.Framework.XButton();
            this.btnPrintSetup = new IHIS.Framework.XButton();
            this.xDataWindow1 = new IHIS.Framework.XDataWindow();
            this.dw1 = new IHIS.Framework.XDataWindow();
            this.btnReInjActScrip = new IHIS.Framework.XButton();
            this.btnReser = new IHIS.Framework.XButton();
            this.btnReLabel = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.btnInjActScrip = new IHIS.Framework.XButton();
            this.panelBtnCPL = new IHIS.Framework.XPanel();
            this.btnOrderPrint = new IHIS.Framework.XButton();
            this.btnChkAllJubsuCPL = new IHIS.Framework.XButton();
            this.btnOrderCancel = new IHIS.Framework.XButton();
            this.btnPrintSetupCPL = new IHIS.Framework.XButton();
            this.btnBarcode = new IHIS.Framework.XButton();
            this.btnChangeTime = new IHIS.Framework.XButton();
            this.btnListCPL = new IHIS.Framework.XButtonList();
            this.xButton5 = new IHIS.Framework.XButton();
            this.panelBtnINJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListINJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.panelBtnCPL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnListCPL)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBtnINJ
            // 
            this.panelBtnINJ.AccessibleDescription = null;
            this.panelBtnINJ.AccessibleName = null;
            resources.ApplyResources(this.panelBtnINJ, "panelBtnINJ");
            this.panelBtnINJ.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.panelBtnINJ.BackgroundImage = null;
            this.panelBtnINJ.Controls.Add(this.btnListINJ);
            this.panelBtnINJ.Controls.Add(this.btnLabel);
            this.panelBtnINJ.Controls.Add(this.btnChkAllJubsu);
            this.panelBtnINJ.Controls.Add(this.btnPrintSetup);
            this.panelBtnINJ.Controls.Add(this.xDataWindow1);
            this.panelBtnINJ.Controls.Add(this.dw1);
            this.panelBtnINJ.Controls.Add(this.btnReInjActScrip);
            this.panelBtnINJ.Controls.Add(this.btnReser);
            this.panelBtnINJ.Controls.Add(this.btnReLabel);
            this.panelBtnINJ.Controls.Add(this.xButtonList1);
            this.panelBtnINJ.Controls.Add(this.btnInjActScrip);
            this.panelBtnINJ.DrawBorder = true;
            this.panelBtnINJ.Font = null;
            this.panelBtnINJ.Name = "panelBtnINJ";
            // 
            // btnListINJ
            // 
            this.btnListINJ.AccessibleDescription = null;
            this.btnListINJ.AccessibleName = null;
            resources.ApplyResources(this.btnListINJ, "btnListINJ");
            this.btnListINJ.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.btnListINJ.BackgroundImage = null;
            this.btnListINJ.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, Properties.Resources.TXT_PROCESS, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnListINJ.IsVisiblePreview = false;
            this.btnListINJ.IsVisibleReset = false;
            this.btnListINJ.Name = "btnListINJ";
            this.btnListINJ.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnListINJ.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListINJ_ButtonClick);
            // 
            // btnLabel
            // 
            this.btnLabel.AccessibleDescription = null;
            this.btnLabel.AccessibleName = null;
            resources.ApplyResources(this.btnLabel, "btnLabel");
            this.btnLabel.BackgroundImage = null;
            this.btnLabel.ImageIndex = 5;
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
            // 
            // btnChkAllJubsu
            // 
            this.btnChkAllJubsu.AccessibleDescription = null;
            this.btnChkAllJubsu.AccessibleName = null;
            resources.ApplyResources(this.btnChkAllJubsu, "btnChkAllJubsu");
            this.btnChkAllJubsu.BackgroundImage = null;
            this.btnChkAllJubsu.ImageIndex = 3;
            this.btnChkAllJubsu.Name = "btnChkAllJubsu";
            this.btnChkAllJubsu.Click += new System.EventHandler(this.btnChkAllJubsu_Click);
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.AccessibleDescription = null;
            this.btnPrintSetup.AccessibleName = null;
            resources.ApplyResources(this.btnPrintSetup, "btnPrintSetup");
            this.btnPrintSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetup.BackgroundImage = null;
            this.btnPrintSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetup.Image")));
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // xDataWindow1
            // 
            resources.ApplyResources(this.xDataWindow1, "xDataWindow1");
            this.xDataWindow1.DataWindowObject = "d_inj_ho_dong";
            this.xDataWindow1.LibraryList = "INJS\\injs.inj1001u01.pbd";
            this.xDataWindow1.Name = "xDataWindow1";
            // 
            // dw1
            // 
            resources.ApplyResources(this.dw1, "dw1");
            this.dw1.DataWindowObject = "d_jusa_label";
            this.dw1.LibraryList = "INJS\\injs.inj1001u01.pbd";
            this.dw1.Name = "dw1";
            // 
            // btnReInjActScrip
            // 
            this.btnReInjActScrip.AccessibleDescription = null;
            this.btnReInjActScrip.AccessibleName = null;
            resources.ApplyResources(this.btnReInjActScrip, "btnReInjActScrip");
            this.btnReInjActScrip.BackgroundImage = null;
            this.btnReInjActScrip.ImageIndex = 0;
            this.btnReInjActScrip.Name = "btnReInjActScrip";
            this.btnReInjActScrip.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReInjActScrip.Click += new System.EventHandler(this.btnReInjActScrip_Click);
            // 
            // btnReser
            // 
            this.btnReser.AccessibleDescription = null;
            this.btnReser.AccessibleName = null;
            resources.ApplyResources(this.btnReser, "btnReser");
            this.btnReser.BackgroundImage = null;
            this.btnReser.ImageIndex = 1;
            this.btnReser.Name = "btnReser";
            this.btnReser.Scheme = IHIS.Framework.XButtonSchemes.Green;
            this.btnReser.Click += new System.EventHandler(this.btnReser_Click);
            // 
            // btnReLabel
            // 
            this.btnReLabel.AccessibleDescription = null;
            this.btnReLabel.AccessibleName = null;
            resources.ApplyResources(this.btnReLabel, "btnReLabel");
            this.btnReLabel.BackgroundImage = null;
            this.btnReLabel.ImageIndex = 0;
            this.btnReLabel.Name = "btnReLabel";
            this.btnReLabel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnReLabel.Click += new System.EventHandler(this.btnReLabel_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisiblePreview = false;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            // 
            // btnInjActScrip
            // 
            this.btnInjActScrip.AccessibleDescription = null;
            this.btnInjActScrip.AccessibleName = null;
            resources.ApplyResources(this.btnInjActScrip, "btnInjActScrip");
            this.btnInjActScrip.BackgroundImage = null;
            this.btnInjActScrip.ImageIndex = 3;
            this.btnInjActScrip.Name = "btnInjActScrip";
            this.btnInjActScrip.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            // 
            // panelBtnCPL
            // 
            this.panelBtnCPL.AccessibleDescription = null;
            this.panelBtnCPL.AccessibleName = null;
            resources.ApplyResources(this.panelBtnCPL, "panelBtnCPL");
            this.panelBtnCPL.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.panelBtnCPL.BackgroundImage = null;
            this.panelBtnCPL.Controls.Add(this.btnOrderPrint);
            this.panelBtnCPL.Controls.Add(this.btnChkAllJubsuCPL);
            this.panelBtnCPL.Controls.Add(this.btnOrderCancel);
            this.panelBtnCPL.Controls.Add(this.btnPrintSetupCPL);
            this.panelBtnCPL.Controls.Add(this.btnBarcode);
            this.panelBtnCPL.Controls.Add(this.btnChangeTime);
            this.panelBtnCPL.Controls.Add(this.btnListCPL);
            this.panelBtnCPL.Controls.Add(this.xButton5);
            this.panelBtnCPL.DrawBorder = true;
            this.panelBtnCPL.Font = null;
            this.panelBtnCPL.Name = "panelBtnCPL";
            // 
            // btnOrderPrint
            // 
            this.btnOrderPrint.AccessibleDescription = null;
            this.btnOrderPrint.AccessibleName = null;
            resources.ApplyResources(this.btnOrderPrint, "btnOrderPrint");
            this.btnOrderPrint.BackgroundImage = null;
            this.btnOrderPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderPrint.Image")));
            this.btnOrderPrint.Name = "btnOrderPrint";
            this.btnOrderPrint.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnOrderPrint.Click += new System.EventHandler(this.btnOrderPrint_Click);
            // 
            // btnChkAllJubsuCPL
            // 
            this.btnChkAllJubsuCPL.AccessibleDescription = null;
            this.btnChkAllJubsuCPL.AccessibleName = null;
            resources.ApplyResources(this.btnChkAllJubsuCPL, "btnChkAllJubsuCPL");
            this.btnChkAllJubsuCPL.BackgroundImage = null;
            this.btnChkAllJubsuCPL.ImageIndex = 0;
            this.btnChkAllJubsuCPL.Name = "btnChkAllJubsuCPL";
            this.btnChkAllJubsuCPL.Click += new System.EventHandler(this.btnChkAllJubsuCPL_Click);
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.AccessibleDescription = null;
            this.btnOrderCancel.AccessibleName = null;
            resources.ApplyResources(this.btnOrderCancel, "btnOrderCancel");
            this.btnOrderCancel.BackgroundImage = null;
            this.btnOrderCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderCancel.Image")));
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // btnPrintSetupCPL
            // 
            this.btnPrintSetupCPL.AccessibleDescription = null;
            this.btnPrintSetupCPL.AccessibleName = null;
            resources.ApplyResources(this.btnPrintSetupCPL, "btnPrintSetupCPL");
            this.btnPrintSetupCPL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintSetupCPL.BackgroundImage = null;
            this.btnPrintSetupCPL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintSetupCPL.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSetupCPL.Image")));
            this.btnPrintSetupCPL.Name = "btnPrintSetupCPL";
            this.btnPrintSetupCPL.Click += new System.EventHandler(this.btnPrintSetupCPL_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.AccessibleDescription = null;
            this.btnBarcode.AccessibleName = null;
            resources.ApplyResources(this.btnBarcode, "btnBarcode");
            this.btnBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnBarcode.BackgroundImage = null;
            this.btnBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarcode.Image")));
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnChangeTime
            // 
            this.btnChangeTime.AccessibleDescription = null;
            this.btnChangeTime.AccessibleName = null;
            resources.ApplyResources(this.btnChangeTime, "btnChangeTime");
            this.btnChangeTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnChangeTime.BackgroundImage = null;
            this.btnChangeTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChangeTime.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTime.Image")));
            this.btnChangeTime.Name = "btnChangeTime";
            this.btnChangeTime.Click += new System.EventHandler(this.btnChangeTime_Click);
            // 
            // btnListCPL
            // 
            this.btnListCPL.AccessibleDescription = null;
            this.btnListCPL.AccessibleName = null;
            resources.ApplyResources(this.btnListCPL, "btnListCPL");
            this.btnListCPL.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.btnListCPL.BackgroundImage = null;
            this.btnListCPL.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, Properties.Resources.TXT_PROCESS, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnListCPL.IsVisibleReset = false;
            this.btnListCPL.Name = "btnListCPL";
            this.btnListCPL.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnListCPL.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnListCPL_ButtonClick);
            // 
            // xButton5
            // 
            this.xButton5.AccessibleDescription = null;
            this.xButton5.AccessibleName = null;
            resources.ApplyResources(this.xButton5, "xButton5");
            this.xButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.xButton5.BackgroundImage = null;
            this.xButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xButton5.Image = ((System.Drawing.Image)(resources.GetObject("xButton5.Image")));
            this.xButton5.Name = "xButton5";
            // 
            // UCBtnList
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.panelBtnCPL);
            this.Controls.Add(this.panelBtnINJ);
            this.Font = null;
            this.Name = "UCBtnList";
            this.panelBtnINJ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListINJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.panelBtnCPL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnListCPL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel panelBtnINJ;
        private IHIS.Framework.XButton btnLabel;
        private IHIS.Framework.XButton btnChkAllJubsu;
        private IHIS.Framework.XButton btnPrintSetup;
        private IHIS.Framework.XDataWindow xDataWindow1;
        private IHIS.Framework.XDataWindow dw1;
        private IHIS.Framework.XButton btnReInjActScrip;
        private IHIS.Framework.XButton btnReser;
        private IHIS.Framework.XButton btnReLabel;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XButton btnInjActScrip;
        private IHIS.Framework.XButtonList btnListINJ;
        private IHIS.Framework.XPanel panelBtnCPL;
        private IHIS.Framework.XButton btnOrderPrint;
        private IHIS.Framework.XButton btnChkAllJubsuCPL;
        private IHIS.Framework.XButton btnOrderCancel;
        private IHIS.Framework.XButton btnPrintSetupCPL;
        private IHIS.Framework.XButton btnBarcode;
        private IHIS.Framework.XButton btnChangeTime;
        private IHIS.Framework.XButtonList btnListCPL;
        private IHIS.Framework.XButton xButton5;
    }
}
