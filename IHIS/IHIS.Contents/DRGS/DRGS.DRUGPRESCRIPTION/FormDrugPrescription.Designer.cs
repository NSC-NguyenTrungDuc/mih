namespace IHIS.DRGS
{
    partial class FormDrugPrescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDrugPrescription));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cbxOutHospital = new IHIS.Framework.XCheckBox();
            this.cbxInHospital = new IHIS.Framework.XCheckBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.webControl1 = new EO.WebBrowser.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnPrintSetting = new IHIS.Framework.XButton();
            this.btnPDF = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.cbxOutHospital);
            this.xPanel1.Controls.Add(this.cbxInHospital);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // cbxOutHospital
            // 
            resources.ApplyResources(this.cbxOutHospital, "cbxOutHospital");
            this.cbxOutHospital.Name = "cbxOutHospital";
            this.cbxOutHospital.UseVisualStyleBackColor = false;
            this.cbxOutHospital.CheckedChanged += new System.EventHandler(this.cbxInHospital_CheckedChanged);
            // 
            // cbxInHospital
            // 
            resources.ApplyResources(this.cbxInHospital, "cbxInHospital");
            this.cbxInHospital.Checked = true;
            this.cbxInHospital.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxInHospital.Name = "cbxInHospital";
            this.cbxInHospital.UseVisualStyleBackColor = false;
            this.cbxInHospital.CheckedChanged += new System.EventHandler(this.cbxInHospital_CheckedChanged);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.webControl1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.webControl1, "webControl1");
            this.webControl1.Name = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnPrintSetting);
            this.xPanel3.Controls.Add(this.btnPDF);
            this.xPanel3.Controls.Add(this.xButtonList1);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnPrintSetting
            // 
            resources.ApplyResources(this.btnPrintSetting, "btnPrintSetting");
            this.btnPrintSetting.Name = "btnPrintSetting";
            this.btnPrintSetting.Click += new System.EventHandler(this.btnPrintSetting_Click);
            // 
            // btnPDF
            // 
            resources.ApplyResources(this.btnPDF, "btnPDF");
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // FormDrugPrescription
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            this.Name = "FormDrugPrescription";
            this.Load += new System.EventHandler(this.FormDrugPrescription_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButton btnPDF;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XButton btnPrintSetting;
        private EO.WebBrowser.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView1;
        private IHIS.Framework.XCheckBox cbxInHospital;
        private IHIS.Framework.XCheckBox cbxOutHospital;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}