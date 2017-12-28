namespace IHIS.OCSO
{
    partial class OCS4000U00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS4000U00));
            this.pnlPatientBox = new IHIS.Framework.XPanel();
            this.labelPrescriptionDate = new System.Windows.Forms.Label();
            this.xDatePickerPrescriptionDate = new IHIS.Framework.XDatePicker();
            this.pnlContent = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.webControl1 = new EO.WebBrowser.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xEditGrid1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.patientBox1 = new IHIS.Framework.XPatientBox();
            this.pnlPatientBox.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPatientBox
            // 
            this.pnlPatientBox.Controls.Add(this.labelPrescriptionDate);
            this.pnlPatientBox.Controls.Add(this.xDatePickerPrescriptionDate);
            this.pnlPatientBox.Controls.Add(this.patientBox1);
            this.pnlPatientBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatientBox.Location = new System.Drawing.Point(0, 0);
            this.pnlPatientBox.Name = "pnlPatientBox";
            this.pnlPatientBox.Size = new System.Drawing.Size(1246, 35);
            this.pnlPatientBox.TabIndex = 11;
            // 
            // labelPrescriptionDate
            // 
            this.labelPrescriptionDate.AutoSize = true;
            this.labelPrescriptionDate.Location = new System.Drawing.Point(1062, 9);
            this.labelPrescriptionDate.Name = "labelPrescriptionDate";
            this.labelPrescriptionDate.Size = new System.Drawing.Size(55, 15);
            this.labelPrescriptionDate.TabIndex = 6;
            this.labelPrescriptionDate.Text = "処方箋日";
            // 
            // xDatePickerPrescriptionDate
            // 
            this.xDatePickerPrescriptionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.xDatePickerPrescriptionDate.IsVietnameseYearType = false;
            this.xDatePickerPrescriptionDate.Location = new System.Drawing.Point(1122, 7);
            this.xDatePickerPrescriptionDate.Name = "xDatePickerPrescriptionDate";
            this.xDatePickerPrescriptionDate.Size = new System.Drawing.Size(100, 20);
            this.xDatePickerPrescriptionDate.TabIndex = 5;
            this.xDatePickerPrescriptionDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xDatePickerPrescriptionDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xDatePickerPrescriptionDate_DataValidating);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xPanel5);
            this.pnlContent.Controls.Add(this.xPanel4);
            this.pnlContent.Controls.Add(this.pnlBottom);
            this.pnlContent.Controls.Add(this.pnlPatientBox);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1246, 598);
            this.pnlContent.TabIndex = 12;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.webControl1);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel5.Location = new System.Drawing.Point(162, 35);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(1084, 522);
            this.xPanel5.TabIndex = 14;
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            this.webControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webControl1.Location = new System.Drawing.Point(0, 0);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(1084, 522);
            this.webControl1.TabIndex = 0;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.xEditGrid1);
            this.xPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel4.Location = new System.Drawing.Point(0, 35);
            this.xPanel4.Name = "xPanel4";
            this.xPanel4.Size = new System.Drawing.Size(162, 522);
            this.xPanel4.TabIndex = 13;
            // 
            // xEditGrid1
            // 
            this.xEditGrid1.ApplyAutoHeight = true;
            this.xEditGrid1.CallerID = '2';
            this.xEditGrid1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell1,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.xEditGrid1.ColPerLine = 1;
            this.xEditGrid1.ColResizable = true;
            this.xEditGrid1.Cols = 2;
            this.xEditGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xEditGrid1.ExecuteQuery = null;
            this.xEditGrid1.FixedCols = 1;
            this.xEditGrid1.FixedRows = 1;
            this.xEditGrid1.HeaderHeights.Add(29);
            this.xEditGrid1.Location = new System.Drawing.Point(0, 0);
            this.xEditGrid1.Name = "xEditGrid1";
            this.xEditGrid1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("xEditGrid1.ParamList")));
            this.xEditGrid1.ReadOnly = true;
            this.xEditGrid1.RowHeaderVisible = true;
            this.xEditGrid1.Rows = 2;
            this.xEditGrid1.SelectionModeChangeable = true;
            this.xEditGrid1.Size = new System.Drawing.Size(162, 522);
            this.xEditGrid1.TabIndex = 13;
            this.xEditGrid1.ToolTipActive = true;
            this.xEditGrid1.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.xEditGridPatient_RowFocusChanged);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "id";
            this.xEditGridCell2.CellWidth = 116;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.HeaderText = "ID";
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "create_date";
            this.xEditGridCell3.CellWidth = 135;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.HeaderText = "作成日";
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "input_value";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "input_content";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "print_content";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "prescription_date";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 557);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1246, 41);
            this.pnlBottom.TabIndex = 13;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(757, 5);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 1;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick_1);
            // 
            // patientBox1
            // 
            this.patientBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.patientBox1.Location = new System.Drawing.Point(1, 2);
            this.patientBox1.Name = "patientBox1";
            this.patientBox1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.patientBox1.Size = new System.Drawing.Size(423, 31);
            this.patientBox1.TabIndex = 4;
            this.patientBox1.PatientSelected += new System.EventHandler(this.patientBox1_PatientSelected);
            // 
            // OCS4000U00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Name = "OCS4000U00";
            this.Size = new System.Drawing.Size(1246, 598);
            this.Load += new System.EventHandler(this.OCS4000U00_Load);
            this.pnlPatientBox.ResumeLayout(false);
            this.pnlPatientBox.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xEditGrid1)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel pnlPatientBox;
        private IHIS.Framework.XPanel pnlContent;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XEditGrid xEditGrid1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList btnList;
        private Framework.XEditGridCell xEditGridCell1;
        private Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XDatePicker xDatePickerPrescriptionDate;
        private System.Windows.Forms.Label labelPrescriptionDate;
        private EO.WebBrowser.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView1;
        private Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XPatientBox patientBox1;
    }
}