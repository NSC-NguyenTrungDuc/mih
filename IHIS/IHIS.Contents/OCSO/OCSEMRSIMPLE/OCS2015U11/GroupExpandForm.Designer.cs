namespace IHIS.OCSO
{
    partial class GroupExpandForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdGroupDisease = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colJuSangYn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSangStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSangEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSangEndSayuName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdGroupProblem = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdGroupSpecialNote = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layGroupSpecialNote = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layItemSpecialNote = new DevExpress.XtraLayout.LayoutControlItem();
            this.layGroupProblem = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layItemProblem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layGroupDisease = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layItemDisease = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupDisease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupProblem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupSpecialNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupSpecialNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layItemSpecialNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupProblem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layItemProblem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupDisease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layItemDisease)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.grdGroupDisease);
            this.layoutControl1.Controls.Add(this.grdGroupProblem);
            this.layoutControl1.Controls.Add(this.grdGroupSpecialNote);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(744, 210);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            this.layoutControl1.GroupExpandChanged += new DevExpress.XtraLayout.Utils.LayoutGroupEventHandler(this.layoutControl1_GroupExpandChanged);
            // 
            // grdGroupDisease
            // 
            this.grdGroupDisease.Location = new System.Drawing.Point(22, 100);
            this.grdGroupDisease.MainView = this.gridView3;
            this.grdGroupDisease.Name = "grdGroupDisease";
            this.grdGroupDisease.Size = new System.Drawing.Size(700, 88);
            this.grdGroupDisease.TabIndex = 6;
            this.grdGroupDisease.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colJuSangYn,
            this.colModifierName,
            this.colSangStartDate,
            this.colSangEndDate,
            this.colSangEndSayuName});
            this.gridView3.GridControl = this.grdGroupDisease;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowColumnHeaders = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            // 
            // colJuSangYn
            // 
            this.colJuSangYn.Caption = "JuSangYn";
            this.colJuSangYn.FieldName = "JuSangYn";
            this.colJuSangYn.Name = "colJuSangYn";
            this.colJuSangYn.Visible = true;
            this.colJuSangYn.VisibleIndex = 0;
            this.colJuSangYn.Width = 130;
            // 
            // colModifierName
            // 
            this.colModifierName.Caption = "ModifierName";
            this.colModifierName.FieldName = "ModifierName";
            this.colModifierName.Name = "colModifierName";
            this.colModifierName.Visible = true;
            this.colModifierName.VisibleIndex = 1;
            this.colModifierName.Width = 228;
            // 
            // colSangStartDate
            // 
            this.colSangStartDate.Caption = "SangStartDate";
            this.colSangStartDate.FieldName = "SangStartDate";
            this.colSangStartDate.Name = "colSangStartDate";
            this.colSangStartDate.Visible = true;
            this.colSangStartDate.VisibleIndex = 2;
            this.colSangStartDate.Width = 110;
            // 
            // colSangEndDate
            // 
            this.colSangEndDate.Caption = "SangEndDate";
            this.colSangEndDate.FieldName = "SangEndDate";
            this.colSangEndDate.Name = "colSangEndDate";
            this.colSangEndDate.Visible = true;
            this.colSangEndDate.VisibleIndex = 3;
            this.colSangEndDate.Width = 110;
            // 
            // colSangEndSayuName
            // 
            this.colSangEndSayuName.Caption = "SangEndSayuName";
            this.colSangEndSayuName.FieldName = "SangEndSayuName";
            this.colSangEndSayuName.Name = "colSangEndSayuName";
            this.colSangEndSayuName.Visible = true;
            this.colSangEndSayuName.VisibleIndex = 4;
            this.colSangEndSayuName.Width = 140;
            // 
            // grdGroupProblem
            // 
            this.grdGroupProblem.Location = new System.Drawing.Point(12, 41);
            this.grdGroupProblem.MainView = this.gridView2;
            this.grdGroupProblem.Name = "grdGroupProblem";
            this.grdGroupProblem.Size = new System.Drawing.Size(696, 20);
            this.grdGroupProblem.TabIndex = 5;
            this.grdGroupProblem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colValue});
            this.gridView2.GridControl = this.grdGroupProblem;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowColumnHeaders = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            // 
            // colKey
            // 
            this.colKey.Caption = "Key";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            this.colKey.Width = 57;
            // 
            // colValue
            // 
            this.colValue.Caption = "Value";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 637;
            // 
            // grdGroupSpecialNote
            // 
            this.grdGroupSpecialNote.Location = new System.Drawing.Point(12, 12);
            this.grdGroupSpecialNote.MainView = this.gridView1;
            this.grdGroupSpecialNote.Name = "grdGroupSpecialNote";
            this.grdGroupSpecialNote.Size = new System.Drawing.Size(696, 20);
            this.grdGroupSpecialNote.TabIndex = 4;
            this.grdGroupSpecialNote.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colComments});
            this.gridView1.GridControl = this.grdGroupSpecialNote;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colComments
            // 
            this.colComments.Caption = "Comments";
            this.colComments.FieldName = "Comments";
            this.colComments.Name = "colComments";
            this.colComments.Visible = true;
            this.colComments.VisibleIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layGroupSpecialNote,
            this.layGroupProblem,
            this.layGroupDisease});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(744, 210);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layGroupSpecialNote
            // 
            this.layGroupSpecialNote.CustomizationFormText = "layoutControlGroup2";
            this.layGroupSpecialNote.ExpandButtonVisible = true;
            this.layGroupSpecialNote.Expanded = false;
            this.layGroupSpecialNote.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layItemSpecialNote});
            this.layGroupSpecialNote.Location = new System.Drawing.Point(0, 0);
            this.layGroupSpecialNote.Name = "layGroupSpecialNote";
            this.layGroupSpecialNote.Size = new System.Drawing.Size(724, 29);
            this.layGroupSpecialNote.Text = "layGroupSpecialNote";
            // 
            // layItemSpecialNote
            // 
            this.layItemSpecialNote.Control = this.grdGroupSpecialNote;
            this.layItemSpecialNote.CustomizationFormText = "layoutControlItem1";
            this.layItemSpecialNote.Location = new System.Drawing.Point(0, 0);
            this.layItemSpecialNote.Name = "layItemSpecialNote";
            this.layItemSpecialNote.Size = new System.Drawing.Size(700, 24);
            this.layItemSpecialNote.Text = "layItemSpecialNote";
            this.layItemSpecialNote.TextLocation = DevExpress.Utils.Locations.Right;
            this.layItemSpecialNote.TextSize = new System.Drawing.Size(0, 0);
            this.layItemSpecialNote.TextToControlDistance = 0;
            this.layItemSpecialNote.TextVisible = false;
            // 
            // layGroupProblem
            // 
            this.layGroupProblem.CustomizationFormText = "layoutControlGroup3";
            this.layGroupProblem.ExpandButtonVisible = true;
            this.layGroupProblem.Expanded = false;
            this.layGroupProblem.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layItemProblem});
            this.layGroupProblem.Location = new System.Drawing.Point(0, 29);
            this.layGroupProblem.Name = "layGroupProblem";
            this.layGroupProblem.Size = new System.Drawing.Size(724, 29);
            this.layGroupProblem.Text = "layGroupProblem";
            // 
            // layItemProblem
            // 
            this.layItemProblem.Control = this.grdGroupProblem;
            this.layItemProblem.CustomizationFormText = "layoutControlItem2";
            this.layItemProblem.Location = new System.Drawing.Point(0, 0);
            this.layItemProblem.Name = "layItemProblem";
            this.layItemProblem.Size = new System.Drawing.Size(700, 24);
            this.layItemProblem.Text = "layItemProblem";
            this.layItemProblem.TextLocation = DevExpress.Utils.Locations.Right;
            this.layItemProblem.TextSize = new System.Drawing.Size(0, 0);
            this.layItemProblem.TextToControlDistance = 0;
            this.layItemProblem.TextVisible = false;
            // 
            // layGroupDisease
            // 
            this.layGroupDisease.AppearanceGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.layGroupDisease.AppearanceGroup.Options.UseBackColor = true;
            this.layGroupDisease.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.layGroupDisease.AppearanceItemCaption.Options.UseBackColor = true;
            this.layGroupDisease.AppearanceTabPage.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.layGroupDisease.AppearanceTabPage.Header.Options.UseBackColor = true;
            this.layGroupDisease.AppearanceTabPage.HeaderActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.layGroupDisease.AppearanceTabPage.HeaderActive.Options.UseBackColor = true;
            this.layGroupDisease.AppearanceTabPage.HeaderDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.layGroupDisease.AppearanceTabPage.HeaderDisabled.Options.UseBackColor = true;
            this.layGroupDisease.CustomizationFormText = "layoutControlGroup4";
            this.layGroupDisease.ExpandButtonVisible = true;
            this.layGroupDisease.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layItemDisease});
            this.layGroupDisease.Location = new System.Drawing.Point(0, 58);
            this.layGroupDisease.Name = "layGroupDisease";
            this.layGroupDisease.Size = new System.Drawing.Size(724, 132);
            this.layGroupDisease.Text = "layGroupDisease";
            // 
            // layItemDisease
            // 
            this.layItemDisease.Control = this.grdGroupDisease;
            this.layItemDisease.CustomizationFormText = "layoutControlItem3";
            this.layItemDisease.Location = new System.Drawing.Point(0, 0);
            this.layItemDisease.Name = "layItemDisease";
            this.layItemDisease.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layItemDisease.Size = new System.Drawing.Size(700, 88);
            this.layItemDisease.Text = "layItemDisease";
            this.layItemDisease.TextLocation = DevExpress.Utils.Locations.Right;
            this.layItemDisease.TextSize = new System.Drawing.Size(0, 0);
            this.layItemDisease.TextToControlDistance = 0;
            this.layItemDisease.TextVisible = false;
            // 
            // GroupExpandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "GroupExpandForm";
            this.Size = new System.Drawing.Size(744, 210);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupDisease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupProblem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupSpecialNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupSpecialNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layItemSpecialNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupProblem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layItemProblem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGroupDisease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layItemDisease)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdGroupSpecialNote;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layItemSpecialNote;
        private DevExpress.XtraGrid.GridControl grdGroupDisease;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.GridControl grdGroupProblem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlGroup layGroupSpecialNote;
        private DevExpress.XtraLayout.LayoutControlGroup layGroupProblem;
        private DevExpress.XtraLayout.LayoutControlItem layItemProblem;
        private DevExpress.XtraLayout.LayoutControlGroup layGroupDisease;
        private DevExpress.XtraLayout.LayoutControlItem layItemDisease;
        private DevExpress.XtraGrid.Columns.GridColumn colComments;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colJuSangYn;
        private DevExpress.XtraGrid.Columns.GridColumn colModifierName;
        private DevExpress.XtraGrid.Columns.GridColumn colSangStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSangEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSangEndSayuName;
    }
}
