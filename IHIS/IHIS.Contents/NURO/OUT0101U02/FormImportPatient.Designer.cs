using IHIS.NURO.Properties;
namespace IHIS.NURO
{
    partial class FormImportPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImportPatient));
            this.panelDetail = new IHIS.Framework.XPanel();
            this.panelBottom = new IHIS.Framework.XPanel();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.panelTop = new IHIS.Framework.XPanel();
            this.cbxIgnoreErr = new IHIS.Framework.XCheckBox();
            this.cbxIgnoreDuplicate = new IHIS.Framework.XCheckBox();
            this.reqTel = new System.Windows.Forms.Label();
            this.labelTel = new System.Windows.Forms.Label();
            this.cboTel = new IHIS.Framework.XDictComboBox();
            this.reqBunhoType = new System.Windows.Forms.Label();
            this.labelBunhoType = new System.Windows.Forms.Label();
            this.cboBunhoType = new IHIS.Framework.XDictComboBox();
            this.reqAddr3 = new System.Windows.Forms.Label();
            this.reqAddr2 = new System.Windows.Forms.Label();
            this.reqAddr1 = new System.Windows.Forms.Label();
            this.reqZipCode = new System.Windows.Forms.Label();
            this.reqBirth = new System.Windows.Forms.Label();
            this.reqNameKanji = new System.Windows.Forms.Label();
            this.reqNameKana = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelAddr3 = new System.Windows.Forms.Label();
            this.labelAddr2 = new System.Windows.Forms.Label();
            this.labelAddr1 = new System.Windows.Forms.Label();
            this.labelZipCode = new System.Windows.Forms.Label();
            this.labelBirth = new System.Windows.Forms.Label();
            this.labelNameKanji = new System.Windows.Forms.Label();
            this.labelNameKana = new System.Windows.Forms.Label();
            this.labelBunho = new System.Windows.Forms.Label();
            this.labelSex = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.cboAddress3 = new IHIS.Framework.XDictComboBox();
            this.cboAddress2 = new IHIS.Framework.XDictComboBox();
            this.cboAddress1 = new IHIS.Framework.XDictComboBox();
            this.cboZipcode = new IHIS.Framework.XDictComboBox();
            this.cboBirth = new IHIS.Framework.XDictComboBox();
            this.cboNameKanji = new IHIS.Framework.XDictComboBox();
            this.cboNameKana = new IHIS.Framework.XDictComboBox();
            this.cboBunho = new IHIS.Framework.XDictComboBox();
            this.cboSex = new IHIS.Framework.XDictComboBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboEncoding = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtFile = new IHIS.Framework.XTextBox();
            this.btnBrowse = new IHIS.Framework.XButton();
            this.cbxHasHeader = new IHIS.Framework.XCheckBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.lb1 = new IHIS.Framework.XLabel();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetail
            // 
            this.panelDetail.AccessibleDescription = null;
            this.panelDetail.AccessibleName = null;
            resources.ApplyResources(this.panelDetail, "panelDetail");
            this.panelDetail.BackColor = IHIS.Framework.XColor.XDataGridLineColor;
            this.panelDetail.BackgroundImage = null;
            this.panelDetail.Font = null;
            this.panelDetail.Name = "panelDetail";
            // 
            // panelBottom
            // 
            this.panelBottom.AccessibleDescription = null;
            this.panelBottom.AccessibleName = null;
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.BackgroundImage = null;
            this.panelBottom.Controls.Add(this.progBar);
            this.panelBottom.Controls.Add(this.btnList);
            this.panelBottom.Font = null;
            this.panelBottom.Name = "panelBottom";
            // 
            // progBar
            // 
            this.progBar.AccessibleDescription = null;
            this.progBar.AccessibleName = null;
            resources.ApplyResources(this.progBar, "progBar");
            this.progBar.BackgroundImage = null;
            this.progBar.Font = null;
            this.progBar.Name = "progBar";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.MSG_ERR_CHECK, -1, global::IHIS.NURO.Properties.Resources.MSG_ERR_CHECK),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.TXT_PROCESS, -1, global::IHIS.NURO.Properties.Resources.MSG_ERR_CHECK),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.MSG_ERR_CHECK, -1, global::IHIS.NURO.Properties.Resources.MSG_ERR_CHECK)});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.panelTop);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // panelTop
            // 
            this.panelTop.AccessibleDescription = null;
            this.panelTop.AccessibleName = null;
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.BackgroundImage = null;
            this.panelTop.Controls.Add(this.cbxIgnoreErr);
            this.panelTop.Controls.Add(this.cbxIgnoreDuplicate);
            this.panelTop.Controls.Add(this.reqTel);
            this.panelTop.Controls.Add(this.labelTel);
            this.panelTop.Controls.Add(this.cboTel);
            this.panelTop.Controls.Add(this.reqBunhoType);
            this.panelTop.Controls.Add(this.labelBunhoType);
            this.panelTop.Controls.Add(this.cboBunhoType);
            this.panelTop.Controls.Add(this.reqAddr3);
            this.panelTop.Controls.Add(this.reqAddr2);
            this.panelTop.Controls.Add(this.reqAddr1);
            this.panelTop.Controls.Add(this.reqZipCode);
            this.panelTop.Controls.Add(this.reqBirth);
            this.panelTop.Controls.Add(this.reqNameKanji);
            this.panelTop.Controls.Add(this.reqNameKana);
            this.panelTop.Controls.Add(this.label12);
            this.panelTop.Controls.Add(this.labelAddr3);
            this.panelTop.Controls.Add(this.labelAddr2);
            this.panelTop.Controls.Add(this.labelAddr1);
            this.panelTop.Controls.Add(this.labelZipCode);
            this.panelTop.Controls.Add(this.labelBirth);
            this.panelTop.Controls.Add(this.labelNameKanji);
            this.panelTop.Controls.Add(this.labelNameKana);
            this.panelTop.Controls.Add(this.labelBunho);
            this.panelTop.Controls.Add(this.labelSex);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.xLabel14);
            this.panelTop.Controls.Add(this.xLabel13);
            this.panelTop.Controls.Add(this.cboAddress3);
            this.panelTop.Controls.Add(this.cboAddress2);
            this.panelTop.Controls.Add(this.cboAddress1);
            this.panelTop.Controls.Add(this.cboZipcode);
            this.panelTop.Controls.Add(this.cboBirth);
            this.panelTop.Controls.Add(this.cboNameKanji);
            this.panelTop.Controls.Add(this.cboNameKana);
            this.panelTop.Controls.Add(this.cboBunho);
            this.panelTop.Controls.Add(this.cboSex);
            this.panelTop.Font = null;
            this.panelTop.Name = "panelTop";
            // 
            // cbxIgnoreErr
            // 
            this.cbxIgnoreErr.AccessibleDescription = null;
            this.cbxIgnoreErr.AccessibleName = null;
            resources.ApplyResources(this.cbxIgnoreErr, "cbxIgnoreErr");
            this.cbxIgnoreErr.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.cbxIgnoreErr.BackgroundImage = null;
            this.cbxIgnoreErr.Name = "cbxIgnoreErr";
            this.cbxIgnoreErr.UseVisualStyleBackColor = false;
            // 
            // cbxIgnoreDuplicate
            // 
            this.cbxIgnoreDuplicate.AccessibleDescription = null;
            this.cbxIgnoreDuplicate.AccessibleName = null;
            resources.ApplyResources(this.cbxIgnoreDuplicate, "cbxIgnoreDuplicate");
            this.cbxIgnoreDuplicate.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.cbxIgnoreDuplicate.BackgroundImage = null;
            this.cbxIgnoreDuplicate.Name = "cbxIgnoreDuplicate";
            this.cbxIgnoreDuplicate.UseVisualStyleBackColor = false;
            // 
            // reqTel
            // 
            this.reqTel.AccessibleDescription = null;
            this.reqTel.AccessibleName = null;
            resources.ApplyResources(this.reqTel, "reqTel");
            this.reqTel.ForeColor = System.Drawing.Color.Red;
            this.reqTel.Name = "reqTel";
            // 
            // labelTel
            // 
            this.labelTel.AccessibleDescription = null;
            this.labelTel.AccessibleName = null;
            resources.ApplyResources(this.labelTel, "labelTel");
            this.labelTel.Name = "labelTel";
            // 
            // cboTel
            // 
            this.cboTel.AccessibleDescription = null;
            this.cboTel.AccessibleName = null;
            resources.ApplyResources(this.cboTel, "cboTel");
            this.cboTel.BackgroundImage = null;
            this.cboTel.ExecuteQuery = null;
            this.cboTel.Name = "cboTel";
            this.cboTel.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTel.ParamList")));
            this.cboTel.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // reqBunhoType
            // 
            this.reqBunhoType.AccessibleDescription = null;
            this.reqBunhoType.AccessibleName = null;
            resources.ApplyResources(this.reqBunhoType, "reqBunhoType");
            this.reqBunhoType.ForeColor = System.Drawing.Color.Red;
            this.reqBunhoType.Name = "reqBunhoType";
            // 
            // labelBunhoType
            // 
            this.labelBunhoType.AccessibleDescription = null;
            this.labelBunhoType.AccessibleName = null;
            resources.ApplyResources(this.labelBunhoType, "labelBunhoType");
            this.labelBunhoType.Name = "labelBunhoType";
            // 
            // cboBunhoType
            // 
            this.cboBunhoType.AccessibleDescription = null;
            this.cboBunhoType.AccessibleName = null;
            resources.ApplyResources(this.cboBunhoType, "cboBunhoType");
            this.cboBunhoType.BackgroundImage = null;
            this.cboBunhoType.ExecuteQuery = null;
            this.cboBunhoType.Name = "cboBunhoType";
            this.cboBunhoType.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBunhoType.ParamList")));
            this.cboBunhoType.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // reqAddr3
            // 
            this.reqAddr3.AccessibleDescription = null;
            this.reqAddr3.AccessibleName = null;
            resources.ApplyResources(this.reqAddr3, "reqAddr3");
            this.reqAddr3.ForeColor = System.Drawing.Color.Red;
            this.reqAddr3.Name = "reqAddr3";
            // 
            // reqAddr2
            // 
            this.reqAddr2.AccessibleDescription = null;
            this.reqAddr2.AccessibleName = null;
            resources.ApplyResources(this.reqAddr2, "reqAddr2");
            this.reqAddr2.ForeColor = System.Drawing.Color.Red;
            this.reqAddr2.Name = "reqAddr2";
            // 
            // reqAddr1
            // 
            this.reqAddr1.AccessibleDescription = null;
            this.reqAddr1.AccessibleName = null;
            resources.ApplyResources(this.reqAddr1, "reqAddr1");
            this.reqAddr1.ForeColor = System.Drawing.Color.Red;
            this.reqAddr1.Name = "reqAddr1";
            // 
            // reqZipCode
            // 
            this.reqZipCode.AccessibleDescription = null;
            this.reqZipCode.AccessibleName = null;
            resources.ApplyResources(this.reqZipCode, "reqZipCode");
            this.reqZipCode.ForeColor = System.Drawing.Color.Red;
            this.reqZipCode.Name = "reqZipCode";
            // 
            // reqBirth
            // 
            this.reqBirth.AccessibleDescription = null;
            this.reqBirth.AccessibleName = null;
            resources.ApplyResources(this.reqBirth, "reqBirth");
            this.reqBirth.ForeColor = System.Drawing.Color.Red;
            this.reqBirth.Name = "reqBirth";
            // 
            // reqNameKanji
            // 
            this.reqNameKanji.AccessibleDescription = null;
            this.reqNameKanji.AccessibleName = null;
            resources.ApplyResources(this.reqNameKanji, "reqNameKanji");
            this.reqNameKanji.ForeColor = System.Drawing.Color.Red;
            this.reqNameKanji.Name = "reqNameKanji";
            // 
            // reqNameKana
            // 
            this.reqNameKana.AccessibleDescription = null;
            this.reqNameKana.AccessibleName = null;
            resources.ApplyResources(this.reqNameKana, "reqNameKana");
            this.reqNameKana.ForeColor = System.Drawing.Color.Red;
            this.reqNameKana.Name = "reqNameKana";
            // 
            // label12
            // 
            this.label12.AccessibleDescription = null;
            this.label12.AccessibleName = null;
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Name = "label12";
            // 
            // labelAddr3
            // 
            this.labelAddr3.AccessibleDescription = null;
            this.labelAddr3.AccessibleName = null;
            resources.ApplyResources(this.labelAddr3, "labelAddr3");
            this.labelAddr3.Name = "labelAddr3";
            // 
            // labelAddr2
            // 
            this.labelAddr2.AccessibleDescription = null;
            this.labelAddr2.AccessibleName = null;
            resources.ApplyResources(this.labelAddr2, "labelAddr2");
            this.labelAddr2.Name = "labelAddr2";
            // 
            // labelAddr1
            // 
            this.labelAddr1.AccessibleDescription = null;
            this.labelAddr1.AccessibleName = null;
            resources.ApplyResources(this.labelAddr1, "labelAddr1");
            this.labelAddr1.Name = "labelAddr1";
            // 
            // labelZipCode
            // 
            this.labelZipCode.AccessibleDescription = null;
            this.labelZipCode.AccessibleName = null;
            resources.ApplyResources(this.labelZipCode, "labelZipCode");
            this.labelZipCode.Name = "labelZipCode";
            // 
            // labelBirth
            // 
            this.labelBirth.AccessibleDescription = null;
            this.labelBirth.AccessibleName = null;
            resources.ApplyResources(this.labelBirth, "labelBirth");
            this.labelBirth.Name = "labelBirth";
            // 
            // labelNameKanji
            // 
            this.labelNameKanji.AccessibleDescription = null;
            this.labelNameKanji.AccessibleName = null;
            resources.ApplyResources(this.labelNameKanji, "labelNameKanji");
            this.labelNameKanji.Name = "labelNameKanji";
            // 
            // labelNameKana
            // 
            this.labelNameKana.AccessibleDescription = null;
            this.labelNameKana.AccessibleName = null;
            resources.ApplyResources(this.labelNameKana, "labelNameKana");
            this.labelNameKana.Name = "labelNameKana";
            // 
            // labelBunho
            // 
            this.labelBunho.AccessibleDescription = null;
            this.labelBunho.AccessibleName = null;
            resources.ApplyResources(this.labelBunho, "labelBunho");
            this.labelBunho.Name = "labelBunho";
            // 
            // labelSex
            // 
            this.labelSex.AccessibleDescription = null;
            this.labelSex.AccessibleName = null;
            resources.ApplyResources(this.labelSex, "labelSex");
            this.labelSex.Name = "labelSex";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            // 
            // cboAddress3
            // 
            this.cboAddress3.AccessibleDescription = null;
            this.cboAddress3.AccessibleName = null;
            resources.ApplyResources(this.cboAddress3, "cboAddress3");
            this.cboAddress3.BackgroundImage = null;
            this.cboAddress3.ExecuteQuery = null;
            this.cboAddress3.Name = "cboAddress3";
            this.cboAddress3.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboAddress3.ParamList")));
            this.cboAddress3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboAddress2
            // 
            this.cboAddress2.AccessibleDescription = null;
            this.cboAddress2.AccessibleName = null;
            resources.ApplyResources(this.cboAddress2, "cboAddress2");
            this.cboAddress2.BackgroundImage = null;
            this.cboAddress2.ExecuteQuery = null;
            this.cboAddress2.Name = "cboAddress2";
            this.cboAddress2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboAddress2.ParamList")));
            this.cboAddress2.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboAddress1
            // 
            this.cboAddress1.AccessibleDescription = null;
            this.cboAddress1.AccessibleName = null;
            resources.ApplyResources(this.cboAddress1, "cboAddress1");
            this.cboAddress1.BackgroundImage = null;
            this.cboAddress1.ExecuteQuery = null;
            this.cboAddress1.Name = "cboAddress1";
            this.cboAddress1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboAddress1.ParamList")));
            this.cboAddress1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboZipcode
            // 
            this.cboZipcode.AccessibleDescription = null;
            this.cboZipcode.AccessibleName = null;
            resources.ApplyResources(this.cboZipcode, "cboZipcode");
            this.cboZipcode.BackgroundImage = null;
            this.cboZipcode.ExecuteQuery = null;
            this.cboZipcode.Name = "cboZipcode";
            this.cboZipcode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboZipcode.ParamList")));
            this.cboZipcode.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboBirth
            // 
            this.cboBirth.AccessibleDescription = null;
            this.cboBirth.AccessibleName = null;
            resources.ApplyResources(this.cboBirth, "cboBirth");
            this.cboBirth.BackgroundImage = null;
            this.cboBirth.ExecuteQuery = null;
            this.cboBirth.Name = "cboBirth";
            this.cboBirth.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBirth.ParamList")));
            this.cboBirth.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboNameKanji
            // 
            this.cboNameKanji.AccessibleDescription = null;
            this.cboNameKanji.AccessibleName = null;
            resources.ApplyResources(this.cboNameKanji, "cboNameKanji");
            this.cboNameKanji.BackgroundImage = null;
            this.cboNameKanji.ExecuteQuery = null;
            this.cboNameKanji.Name = "cboNameKanji";
            this.cboNameKanji.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboNameKanji.ParamList")));
            this.cboNameKanji.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboNameKana
            // 
            this.cboNameKana.AccessibleDescription = null;
            this.cboNameKana.AccessibleName = null;
            resources.ApplyResources(this.cboNameKana, "cboNameKana");
            this.cboNameKana.BackgroundImage = null;
            this.cboNameKana.ExecuteQuery = null;
            this.cboNameKana.Name = "cboNameKana";
            this.cboNameKana.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboNameKana.ParamList")));
            this.cboNameKana.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboBunho
            // 
            this.cboBunho.AccessibleDescription = null;
            this.cboBunho.AccessibleName = null;
            resources.ApplyResources(this.cboBunho, "cboBunho");
            this.cboBunho.BackgroundImage = null;
            this.cboBunho.ExecuteQuery = null;
            this.cboBunho.Name = "cboBunho";
            this.cboBunho.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBunho.ParamList")));
            this.cboBunho.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboSex
            // 
            this.cboSex.AccessibleDescription = null;
            this.cboSex.AccessibleName = null;
            resources.ApplyResources(this.cboSex, "cboSex");
            this.cboSex.BackgroundImage = null;
            this.cboSex.ExecuteQuery = null;
            this.cboSex.Name = "cboSex";
            this.cboSex.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSex.ParamList")));
            this.cboSex.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.cboEncoding);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.txtFile);
            this.xPanel2.Controls.Add(this.btnBrowse);
            this.xPanel2.Controls.Add(this.cbxHasHeader);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Controls.Add(this.lb1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // cboEncoding
            // 
            this.cboEncoding.AccessibleDescription = null;
            this.cboEncoding.AccessibleName = null;
            resources.ApplyResources(this.cboEncoding, "cboEncoding");
            this.cboEncoding.BackgroundImage = null;
            this.cboEncoding.ExecuteQuery = null;
            this.cboEncoding.Name = "cboEncoding";
            this.cboEncoding.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboEncoding.ParamList")));
            this.cboEncoding.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtFile
            // 
            this.txtFile.AccessibleDescription = null;
            this.txtFile.AccessibleName = null;
            resources.ApplyResources(this.txtFile, "txtFile");
            this.txtFile.ApplyByteLimit = true;
            this.txtFile.BackgroundImage = null;
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.AccessibleDescription = null;
            this.btnBrowse.AccessibleName = null;
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.BackgroundImage = null;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbxHasHeader
            // 
            this.cbxHasHeader.AccessibleDescription = null;
            this.cbxHasHeader.AccessibleName = null;
            resources.ApplyResources(this.cbxHasHeader, "cbxHasHeader");
            this.cbxHasHeader.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.cbxHasHeader.BackgroundImage = null;
            this.cbxHasHeader.Font = null;
            this.cbxHasHeader.Name = "cbxHasHeader";
            this.cbxHasHeader.UseVisualStyleBackColor = false;
            this.cbxHasHeader.CheckedChanged += new System.EventHandler(this.cbxSkipHeader_CheckedChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // lb1
            // 
            this.lb1.AccessibleDescription = null;
            this.lb1.AccessibleName = null;
            resources.ApplyResources(this.lb1, "lb1");
            this.lb1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lb1.EdgeRounding = false;
            this.lb1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lb1.Image = null;
            this.lb1.Name = "lb1";
            // 
            // FormImportPatient
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.panelBottom);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = null;
            this.Name = "FormImportPatient";
            this.Load += new System.EventHandler(this.FormImportPatient_Load);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel panelDetail;
        private IHIS.Framework.XPanel panelBottom;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XTextBox txtFile;
        private IHIS.Framework.XButton btnBrowse;
        private IHIS.Framework.XCheckBox cbxHasHeader;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel lb1;
        private IHIS.Framework.XPanel panelTop;
        private IHIS.Framework.XLabel xLabel14;
        private IHIS.Framework.XLabel xLabel13;
        private IHIS.Framework.XDictComboBox cboAddress3;
        private IHIS.Framework.XDictComboBox cboAddress2;
        private IHIS.Framework.XDictComboBox cboAddress1;
        private IHIS.Framework.XDictComboBox cboZipcode;
        private IHIS.Framework.XDictComboBox cboBirth;
        private IHIS.Framework.XDictComboBox cboNameKanji;
        private IHIS.Framework.XDictComboBox cboNameKana;
        private IHIS.Framework.XDictComboBox cboBunho;
        private IHIS.Framework.XDictComboBox cboSex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSex;
        private System.Windows.Forms.Label labelAddr3;
        private System.Windows.Forms.Label labelAddr2;
        private System.Windows.Forms.Label labelAddr1;
        private System.Windows.Forms.Label labelZipCode;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.Label labelNameKanji;
        private System.Windows.Forms.Label labelNameKana;
        private System.Windows.Forms.Label labelBunho;
        private System.Windows.Forms.Label reqBirth;
        private System.Windows.Forms.Label reqNameKanji;
        private System.Windows.Forms.Label reqNameKana;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label reqAddr3;
        private System.Windows.Forms.Label reqAddr2;
        private System.Windows.Forms.Label reqAddr1;
        private System.Windows.Forms.Label reqZipCode;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label reqBunhoType;
        private System.Windows.Forms.Label labelBunhoType;
        private IHIS.Framework.XDictComboBox cboBunhoType;
        private System.Windows.Forms.Label reqTel;
        private System.Windows.Forms.Label labelTel;
        private IHIS.Framework.XDictComboBox cboTel;
        private IHIS.Framework.XCheckBox cbxIgnoreErr;
        private IHIS.Framework.XCheckBox cbxIgnoreDuplicate;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDictComboBox cboEncoding;
    }
}