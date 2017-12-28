namespace EmrDocker
{
    partial class PopupPrintEmr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupPrintEmr));
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xButtonList2 = new IHIS.Framework.XButtonList();
            this.pnlButton = new IHIS.Framework.XPanel();
            this.cbxDiseasePrinting = new IHIS.Framework.XCheckBox();
            this.xFlatLabel6 = new IHIS.Framework.XFlatLabel();
            this.cbxOrderInfo = new IHIS.Framework.XCheckBox();
            this.xFlatLabel5 = new IHIS.Framework.XFlatLabel();
            this.cbxPatientInfo = new IHIS.Framework.XCheckBox();
            this.xFlatLabel4 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.dpkEndDate = new IHIS.Framework.XDatePicker();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.cbxPrintAll = new IHIS.Framework.XCheckBox();
            this.dpkStartDate = new IHIS.Framework.XDatePicker();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.webControl1 = new EO.WebBrowser.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).BeginInit();
            this.pnlButton.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xButtonList1
            // 
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, global::EmrDocker.Resources.PopupPrintEmr_BtnPrint, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::EmrDocker.Resources.PopupPrintEmr_BtnClose, -1, "")});
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xButtonList2
            // 
            this.xButtonList2.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, global::EmrDocker.Resources.PopupPrintEmr_BtnPrintSetting, -1, "")});
            resources.ApplyResources(this.xButtonList2, "xButtonList2");
            this.xButtonList2.Name = "xButtonList2";
            this.xButtonList2.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList2.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList2_ButtonClick);
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.cbxDiseasePrinting);
            this.pnlButton.Controls.Add(this.xFlatLabel6);
            this.pnlButton.Controls.Add(this.cbxOrderInfo);
            this.pnlButton.Controls.Add(this.xFlatLabel5);
            this.pnlButton.Controls.Add(this.cbxPatientInfo);
            this.pnlButton.Controls.Add(this.xFlatLabel4);
            this.pnlButton.Controls.Add(this.xFlatLabel2);
            this.pnlButton.Controls.Add(this.dpkEndDate);
            this.pnlButton.Controls.Add(this.xFlatLabel1);
            this.pnlButton.Controls.Add(this.cbxPrintAll);
            this.pnlButton.Controls.Add(this.dpkStartDate);
            this.pnlButton.Controls.Add(this.xFlatLabel3);
            resources.ApplyResources(this.pnlButton, "pnlButton");
            this.pnlButton.DrawBorder = true;
            this.pnlButton.Name = "pnlButton";
            // 
            // cbxDiseasePrinting
            // 
            resources.ApplyResources(this.cbxDiseasePrinting, "cbxDiseasePrinting");
            this.cbxDiseasePrinting.Name = "cbxDiseasePrinting";
            this.cbxDiseasePrinting.UseVisualStyleBackColor = false;
            this.cbxDiseasePrinting.CheckedChanged += new System.EventHandler(this.cbxDiseasePrinting_CheckedChanged);
            // 
            // xFlatLabel6
            // 
            this.xFlatLabel6.AllowDrop = true;
            this.xFlatLabel6.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xFlatLabel6, "xFlatLabel6");
            this.xFlatLabel6.Name = "xFlatLabel6";
            // 
            // cbxOrderInfo
            // 
            resources.ApplyResources(this.cbxOrderInfo, "cbxOrderInfo");
            this.cbxOrderInfo.Name = "cbxOrderInfo";
            this.cbxOrderInfo.UseVisualStyleBackColor = false;
            this.cbxOrderInfo.CheckedChanged += new System.EventHandler(this.cbxOrderInfo_CheckedChanged);
            // 
            // xFlatLabel5
            // 
            this.xFlatLabel5.AllowDrop = true;
            this.xFlatLabel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xFlatLabel5, "xFlatLabel5");
            this.xFlatLabel5.Name = "xFlatLabel5";
            // 
            // cbxPatientInfo
            // 
            resources.ApplyResources(this.cbxPatientInfo, "cbxPatientInfo");
            this.cbxPatientInfo.Name = "cbxPatientInfo";
            this.cbxPatientInfo.UseVisualStyleBackColor = false;
            this.cbxPatientInfo.CheckedChanged += new System.EventHandler(this.cbxPatientInfo_CheckedChanged);
            // 
            // xFlatLabel4
            // 
            this.xFlatLabel4.AllowDrop = true;
            resources.ApplyResources(this.xFlatLabel4, "xFlatLabel4");
            this.xFlatLabel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel4.Name = "xFlatLabel4";
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.AllowDrop = true;
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel2.Name = "xFlatLabel2";
            // 
            // dpkEndDate
            // 
            this.dpkEndDate.AllowDrop = true;
            resources.ApplyResources(this.dpkEndDate, "dpkEndDate");
            this.dpkEndDate.IsVietnameseYearType = false;
            this.dpkEndDate.Name = "dpkEndDate";
            this.dpkEndDate.TextChanged += new System.EventHandler(this.dpkEndDate_TextChanged);
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AllowDrop = true;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // cbxPrintAll
            // 
            resources.ApplyResources(this.cbxPrintAll, "cbxPrintAll");
            this.cbxPrintAll.Name = "cbxPrintAll";
            this.cbxPrintAll.UseVisualStyleBackColor = false;
            this.cbxPrintAll.CheckedChanged += new System.EventHandler(this.cbxPrintAll_CheckedChanged);
            // 
            // dpkStartDate
            // 
            this.dpkStartDate.AllowDrop = true;
            resources.ApplyResources(this.dpkStartDate, "dpkStartDate");
            this.dpkStartDate.IsVietnameseYearType = false;
            this.dpkStartDate.Name = "dpkStartDate";
            this.dpkStartDate.TextChanged += new System.EventHandler(this.dpkStartDate_TextChanged);
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.AllowDrop = true;
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel3.Name = "xFlatLabel3";
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Controls.Add(this.xButtonList2);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.webControl1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.webControl1, "webControl1");
            this.webControl1.Name = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.LoadCompleted += new EO.WebBrowser.LoadCompletedEventHandler(this.webView1_LoadCompleted);
            // 
            // PopupPrintEmr
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlButton);
            this.Name = "PopupPrintEmr";
            this.Load += new System.EventHandler(this.PopupPrintEmr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList2)).EndInit();
            this.pnlButton.ResumeLayout(false);
            this.pnlButton.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XButtonList xButtonList2;
        private IHIS.Framework.XPanel pnlButton;
        private IHIS.Framework.XCheckBox cbxPatientInfo;
        private IHIS.Framework.XFlatLabel xFlatLabel4;
        private IHIS.Framework.XFlatLabel xFlatLabel2;
        private IHIS.Framework.XDatePicker dpkEndDate;
        private IHIS.Framework.XFlatLabel xFlatLabel1;
        private IHIS.Framework.XCheckBox cbxPrintAll;
        private IHIS.Framework.XDatePicker dpkStartDate;
        private IHIS.Framework.XFlatLabel xFlatLabel3;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XCheckBox cbxDiseasePrinting;
        private IHIS.Framework.XFlatLabel xFlatLabel6;
        private IHIS.Framework.XCheckBox cbxOrderInfo;
        private IHIS.Framework.XFlatLabel xFlatLabel5;
        private EO.WebBrowser.WebView webView1;
        private EO.WebBrowser.WinForm.WebControl webControl1;


    }
}