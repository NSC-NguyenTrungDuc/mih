namespace IHIS.OCSA
{
    partial class FrmSettingTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettingTime));
            this.btnOk = new IHIS.Framework.XButton();
            this.btnCancel = new IHIS.Framework.XButton();
            this.PnlRule = new IHIS.Framework.XPanel();
            this.RdgRule = new DevExpress.XtraEditors.RadioGroup();
            this.PnlTime = new IHIS.Framework.XPanel();
            this.PnlDaily = new IHIS.Framework.XPanel();
            this.timeDaily = new DevExpress.XtraEditors.TimeEdit();
            this.PnlWeekly = new IHIS.Framework.XPanel();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.cboDayOfWeek = new DevExpress.XtraEditors.ComboBoxEdit();
            this.timeWeekly = new DevExpress.XtraEditors.TimeEdit();
            this.PnlMonthly = new IHIS.Framework.XPanel();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.spnMonth = new DevExpress.XtraEditors.SpinEdit();
            this.timeMonthly = new DevExpress.XtraEditors.TimeEdit();
            this.PnlRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RdgRule.Properties)).BeginInit();
            this.PnlTime.SuspendLayout();
            this.PnlDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeDaily.Properties)).BeginInit();
            this.PnlWeekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDayOfWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeWeekly.Properties)).BeginInit();
            this.PnlMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeMonthly.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.ImageIndex = 3;
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ImageIndex = 3;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PnlRule
            // 
            resources.ApplyResources(this.PnlRule, "PnlRule");
            this.PnlRule.AllowDrop = true;
            this.PnlRule.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlRule.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlRule.Controls.Add(this.RdgRule);
            this.PnlRule.DrawBorder = true;
            this.PnlRule.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlRule.Name = "PnlRule";
            // 
            // RdgRule
            // 
            resources.ApplyResources(this.RdgRule, "RdgRule");
            this.RdgRule.Name = "RdgRule";
            this.RdgRule.Properties.AccessibleDescription = resources.GetString("RdgRule.Properties.AccessibleDescription");
            this.RdgRule.Properties.AccessibleName = resources.GetString("RdgRule.Properties.AccessibleName");
            this.RdgRule.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("RdgRule.Properties.Appearance.BackColor")));
            this.RdgRule.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("RdgRule.Properties.Appearance.GradientMode")));
            this.RdgRule.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("RdgRule.Properties.Appearance.Image")));
            this.RdgRule.Properties.Appearance.Options.UseBackColor = true;
            this.RdgRule.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RdgRule.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RdgRule.Properties.Items"), resources.GetString("RdgRule.Properties.Items1")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RdgRule.Properties.Items2"), resources.GetString("RdgRule.Properties.Items3")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((object)(resources.GetObject("RdgRule.Properties.Items4"))), resources.GetString("RdgRule.Properties.Items5"))});
            this.RdgRule.SelectedIndexChanged += new System.EventHandler(this.RdgRule_SelectedIndexChanged);
            // 
            // PnlTime
            // 
            resources.ApplyResources(this.PnlTime, "PnlTime");
            this.PnlTime.AllowDrop = true;
            this.PnlTime.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlTime.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ControlDark);
            this.PnlTime.Controls.Add(this.PnlDaily);
            this.PnlTime.Controls.Add(this.PnlWeekly);
            this.PnlTime.Controls.Add(this.PnlMonthly);
            this.PnlTime.DrawBorder = true;
            this.PnlTime.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlTime.Name = "PnlTime";
            // 
            // PnlDaily
            // 
            resources.ApplyResources(this.PnlDaily, "PnlDaily");
            this.PnlDaily.AllowDrop = true;
            this.PnlDaily.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlDaily.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlDaily.Controls.Add(this.timeDaily);
            this.PnlDaily.DrawBorder = true;
            this.PnlDaily.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlDaily.Name = "PnlDaily";
            // 
            // timeDaily
            // 
            resources.ApplyResources(this.timeDaily, "timeDaily");
            this.timeDaily.Name = "timeDaily";
            this.timeDaily.Properties.AccessibleDescription = resources.GetString("timeDaily.Properties.AccessibleDescription");
            this.timeDaily.Properties.AccessibleName = resources.GetString("timeDaily.Properties.AccessibleName");
            this.timeDaily.Properties.AutoHeight = ((bool)(resources.GetObject("timeDaily.Properties.AutoHeight")));
            this.timeDaily.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeDaily.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("timeDaily.Properties.Mask.AutoComplete")));
            this.timeDaily.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("timeDaily.Properties.Mask.BeepOnError")));
            this.timeDaily.Properties.Mask.EditMask = resources.GetString("timeDaily.Properties.Mask.EditMask");
            this.timeDaily.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("timeDaily.Properties.Mask.IgnoreMaskBlank")));
            this.timeDaily.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("timeDaily.Properties.Mask.MaskType")));
            this.timeDaily.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("timeDaily.Properties.Mask.PlaceHolder")));
            this.timeDaily.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("timeDaily.Properties.Mask.SaveLiteral")));
            this.timeDaily.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("timeDaily.Properties.Mask.ShowPlaceHolders")));
            this.timeDaily.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("timeDaily.Properties.Mask.UseMaskAsDisplayFormat")));
            this.timeDaily.Properties.NullValuePrompt = resources.GetString("timeDaily.Properties.NullValuePrompt");
            this.timeDaily.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("timeDaily.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // PnlWeekly
            // 
            resources.ApplyResources(this.PnlWeekly, "PnlWeekly");
            this.PnlWeekly.AllowDrop = true;
            this.PnlWeekly.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlWeekly.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlWeekly.Controls.Add(this.xFlatLabel2);
            this.PnlWeekly.Controls.Add(this.cboDayOfWeek);
            this.PnlWeekly.Controls.Add(this.timeWeekly);
            this.PnlWeekly.DrawBorder = true;
            this.PnlWeekly.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlWeekly.Name = "PnlWeekly";
            // 
            // xFlatLabel2
            // 
            resources.ApplyResources(this.xFlatLabel2, "xFlatLabel2");
            this.xFlatLabel2.AllowDrop = true;
            this.xFlatLabel2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel2.Name = "xFlatLabel2";
            // 
            // cboDayOfWeek
            // 
            resources.ApplyResources(this.cboDayOfWeek, "cboDayOfWeek");
            this.cboDayOfWeek.Name = "cboDayOfWeek";
            this.cboDayOfWeek.Properties.AccessibleDescription = resources.GetString("cboDayOfWeek.Properties.AccessibleDescription");
            this.cboDayOfWeek.Properties.AccessibleName = resources.GetString("cboDayOfWeek.Properties.AccessibleName");
            this.cboDayOfWeek.Properties.AutoHeight = ((bool)(resources.GetObject("cboDayOfWeek.Properties.AutoHeight")));
            this.cboDayOfWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboDayOfWeek.Properties.Buttons"))))});
            this.cboDayOfWeek.Properties.NullValuePrompt = resources.GetString("cboDayOfWeek.Properties.NullValuePrompt");
            this.cboDayOfWeek.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboDayOfWeek.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // timeWeekly
            // 
            resources.ApplyResources(this.timeWeekly, "timeWeekly");
            this.timeWeekly.Name = "timeWeekly";
            this.timeWeekly.Properties.AccessibleDescription = resources.GetString("timeWeekly.Properties.AccessibleDescription");
            this.timeWeekly.Properties.AccessibleName = resources.GetString("timeWeekly.Properties.AccessibleName");
            this.timeWeekly.Properties.AutoHeight = ((bool)(resources.GetObject("timeWeekly.Properties.AutoHeight")));
            this.timeWeekly.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeWeekly.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("timeWeekly.Properties.Mask.AutoComplete")));
            this.timeWeekly.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("timeWeekly.Properties.Mask.BeepOnError")));
            this.timeWeekly.Properties.Mask.EditMask = resources.GetString("timeWeekly.Properties.Mask.EditMask");
            this.timeWeekly.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("timeWeekly.Properties.Mask.IgnoreMaskBlank")));
            this.timeWeekly.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("timeWeekly.Properties.Mask.MaskType")));
            this.timeWeekly.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("timeWeekly.Properties.Mask.PlaceHolder")));
            this.timeWeekly.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("timeWeekly.Properties.Mask.SaveLiteral")));
            this.timeWeekly.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("timeWeekly.Properties.Mask.ShowPlaceHolders")));
            this.timeWeekly.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("timeWeekly.Properties.Mask.UseMaskAsDisplayFormat")));
            this.timeWeekly.Properties.NullValuePrompt = resources.GetString("timeWeekly.Properties.NullValuePrompt");
            this.timeWeekly.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("timeWeekly.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // PnlMonthly
            // 
            resources.ApplyResources(this.PnlMonthly, "PnlMonthly");
            this.PnlMonthly.AllowDrop = true;
            this.PnlMonthly.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlMonthly.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlMonthly.Controls.Add(this.xFlatLabel3);
            this.PnlMonthly.Controls.Add(this.spnMonth);
            this.PnlMonthly.Controls.Add(this.timeMonthly);
            this.PnlMonthly.DrawBorder = true;
            this.PnlMonthly.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.PnlMonthly.Name = "PnlMonthly";
            // 
            // xFlatLabel3
            // 
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.AllowDrop = true;
            this.xFlatLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel3.Name = "xFlatLabel3";
            // 
            // spnMonth
            // 
            resources.ApplyResources(this.spnMonth, "spnMonth");
            this.spnMonth.Name = "spnMonth";
            this.spnMonth.Properties.AccessibleDescription = resources.GetString("spnMonth.Properties.AccessibleDescription");
            this.spnMonth.Properties.AccessibleName = resources.GetString("spnMonth.Properties.AccessibleName");
            this.spnMonth.Properties.AutoHeight = ((bool)(resources.GetObject("spnMonth.Properties.AutoHeight")));
            this.spnMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spnMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnMonth.Properties.IsFloatValue = false;
            this.spnMonth.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("spnMonth.Properties.Mask.AutoComplete")));
            this.spnMonth.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("spnMonth.Properties.Mask.BeepOnError")));
            this.spnMonth.Properties.Mask.EditMask = resources.GetString("spnMonth.Properties.Mask.EditMask");
            this.spnMonth.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("spnMonth.Properties.Mask.IgnoreMaskBlank")));
            this.spnMonth.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("spnMonth.Properties.Mask.MaskType")));
            this.spnMonth.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("spnMonth.Properties.Mask.PlaceHolder")));
            this.spnMonth.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("spnMonth.Properties.Mask.SaveLiteral")));
            this.spnMonth.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("spnMonth.Properties.Mask.ShowPlaceHolders")));
            this.spnMonth.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("spnMonth.Properties.Mask.UseMaskAsDisplayFormat")));
            this.spnMonth.Properties.MaxValue = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.spnMonth.Properties.NullValuePrompt = resources.GetString("spnMonth.Properties.NullValuePrompt");
            this.spnMonth.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("spnMonth.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // timeMonthly
            // 
            resources.ApplyResources(this.timeMonthly, "timeMonthly");
            this.timeMonthly.Name = "timeMonthly";
            this.timeMonthly.Properties.AccessibleDescription = resources.GetString("timeMonthly.Properties.AccessibleDescription");
            this.timeMonthly.Properties.AccessibleName = resources.GetString("timeMonthly.Properties.AccessibleName");
            this.timeMonthly.Properties.AutoHeight = ((bool)(resources.GetObject("timeMonthly.Properties.AutoHeight")));
            this.timeMonthly.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeMonthly.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("timeMonthly.Properties.Mask.AutoComplete")));
            this.timeMonthly.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("timeMonthly.Properties.Mask.BeepOnError")));
            this.timeMonthly.Properties.Mask.EditMask = resources.GetString("timeMonthly.Properties.Mask.EditMask");
            this.timeMonthly.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("timeMonthly.Properties.Mask.IgnoreMaskBlank")));
            this.timeMonthly.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("timeMonthly.Properties.Mask.MaskType")));
            this.timeMonthly.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("timeMonthly.Properties.Mask.PlaceHolder")));
            this.timeMonthly.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("timeMonthly.Properties.Mask.SaveLiteral")));
            this.timeMonthly.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("timeMonthly.Properties.Mask.ShowPlaceHolders")));
            this.timeMonthly.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("timeMonthly.Properties.Mask.UseMaskAsDisplayFormat")));
            this.timeMonthly.Properties.NullValuePrompt = resources.GetString("timeMonthly.Properties.NullValuePrompt");
            this.timeMonthly.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("timeMonthly.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // FrmSettingTime
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ControlBox = false;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.PnlRule);
            this.Controls.Add(this.PnlTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmSettingTime";
            this.PnlRule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RdgRule.Properties)).EndInit();
            this.PnlTime.ResumeLayout(false);
            this.PnlDaily.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeDaily.Properties)).EndInit();
            this.PnlWeekly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDayOfWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeWeekly.Properties)).EndInit();
            this.PnlMonthly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spnMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeMonthly.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Framework.XButton btnOk;
        private Framework.XButton btnCancel;
        private Framework.XPanel PnlRule;
        private Framework.XPanel PnlTime;
        private DevExpress.XtraEditors.RadioGroup RdgRule;
        private Framework.XPanel PnlDaily;
        private DevExpress.XtraEditors.TimeEdit timeDaily;
        private Framework.XPanel PnlWeekly;
        private Framework.XPanel PnlMonthly;
        private DevExpress.XtraEditors.TimeEdit timeWeekly;
        private DevExpress.XtraEditors.ComboBoxEdit cboDayOfWeek;
        private Framework.XFlatLabel xFlatLabel2;
        private Framework.XFlatLabel xFlatLabel3;
        private DevExpress.XtraEditors.TimeEdit timeMonthly;
        private DevExpress.XtraEditors.SpinEdit spnMonth;
    }
}