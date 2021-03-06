namespace IHIS.NURO
{
    partial class FormSelectPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectPatient));
            this.pnlSTTop = new IHIS.Framework.XPanel();
            this.txtBunho = new IHIS.Framework.XTextBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.grdPatientList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.btnLink = new IHIS.Framework.XButton();
            this.btnCreateTempID = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlSTTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSTTop
            // 
            this.pnlSTTop.AccessibleDescription = null;
            this.pnlSTTop.AccessibleName = null;
            resources.ApplyResources(this.pnlSTTop, "pnlSTTop");
            this.pnlSTTop.BackgroundImage = null;
            this.pnlSTTop.Controls.Add(this.txtBunho);
            this.pnlSTTop.Controls.Add(this.paBox);
            this.pnlSTTop.DrawBorder = true;
            this.pnlSTTop.Font = null;
            this.pnlSTTop.Name = "pnlSTTop";
            // 
            // txtBunho
            // 
            this.txtBunho.AccessibleDescription = null;
            this.txtBunho.AccessibleName = null;
            resources.ApplyResources(this.txtBunho, "txtBunho");
            this.txtBunho.BackgroundImage = null;
            this.txtBunho.Name = "txtBunho";
            this.txtBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtBunho_DataValidating);
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paBox.Name = "paBox";
            this.paBox.TabStop = false;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // grdPatientList
            // 
            resources.ApplyResources(this.grdPatientList, "grdPatientList");
            this.grdPatientList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdPatientList.ColPerLine = 5;
            this.grdPatientList.ColResizable = true;
            this.grdPatientList.Cols = 6;
            this.grdPatientList.ExecuteQuery = null;
            this.grdPatientList.FixedCols = 1;
            this.grdPatientList.FixedRows = 1;
            this.grdPatientList.HeaderHeights.Add(23);
            this.grdPatientList.Name = "grdPatientList";
            this.grdPatientList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientList.ParamList")));
            this.grdPatientList.RowHeaderVisible = true;
            this.grdPatientList.RowResizable = true;
            this.grdPatientList.Rows = 2;
            this.grdPatientList.ToolTipActive = true;
            this.grdPatientList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdPatientList_RowFocusChanged);
            this.grdPatientList.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPatientList_ItemValueChanging);
            this.grdPatientList.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdPatientList_GridCellFocusChanged);
            this.grdPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 99;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "patient_name";
            this.xEditGridCell2.CellWidth = 230;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 200;
            this.xEditGridCell3.CellName = "address";
            this.xEditGridCell3.CellWidth = 253;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "birth";
            this.xEditGridCell4.CellWidth = 160;
            this.xEditGridCell4.Col = 5;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "suname";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 100;
            this.xEditGridCell6.CellName = "suname2";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sex";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "tel";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "link_emr";
            this.xEditGridCell9.Col = 1;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            // 
            // btnLink
            // 
            this.btnLink.AccessibleDescription = null;
            this.btnLink.AccessibleName = null;
            resources.ApplyResources(this.btnLink, "btnLink");
            this.btnLink.BackgroundImage = null;
            this.btnLink.Name = "btnLink";
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnCreateTempID
            // 
            this.btnCreateTempID.AccessibleDescription = null;
            this.btnCreateTempID.AccessibleName = null;
            resources.ApplyResources(this.btnCreateTempID, "btnCreateTempID");
            this.btnCreateTempID.BackgroundImage = null;
            this.btnCreateTempID.Name = "btnCreateTempID";
            this.btnCreateTempID.Click += new System.EventHandler(this.btnCreateTempID_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.Control);
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.F2, global::IHIS.NURO.Properties.Resources.TXT_BTN_CLOSE, -1, global::IHIS.NURO.Properties.Resources.MSG_005)});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // FormSelectPatient
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnCreateTempID);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.grdPatientList);
            this.Controls.Add(this.pnlSTTop);
            this.Font = null;
            this.Icon = null;
            this.Name = "FormSelectPatient";
            this.Load += new System.EventHandler(this.FormSelectPatient_Load);
            this.pnlSTTop.ResumeLayout(false);
            this.pnlSTTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel pnlSTTop;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGrid grdPatientList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XButton btnLink;
        private IHIS.Framework.XButton btnCreateTempID;
        private IHIS.Framework.XTextBox txtBunho;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;

    }
}