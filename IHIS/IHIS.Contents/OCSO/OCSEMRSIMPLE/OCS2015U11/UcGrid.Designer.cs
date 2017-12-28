namespace EmrDocker
{
    partial class UcGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcGrid));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderDisplayOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.colBtnDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colOderType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContents = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionDoYn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInputTab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupSer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInputTabAndGroupSer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdContent = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayOrther = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.colTagCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTagName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDirLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPkOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHospCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGwa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDoctor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.brower = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderDisplayOrder,
            this.colBtnDo,
            this.colOderType,
            this.colContents,
            this.colActionDoYn,
            this.colInputTab,
            this.colGroupSer,
            this.colInputTabAndGroupSer});
            this.gridView2.GridControl = this.grdContent;
            this.gridView2.Name = "gridView2";
            this.gridView2.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView2_CustomDrawCell);
            this.gridView2.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView2_ShowingEditor);
            // 
            // colOrderDisplayOrder
            // 
            resources.ApplyResources(this.colOrderDisplayOrder, "colOrderDisplayOrder");
            this.colOrderDisplayOrder.ColumnEdit = this.repositoryItemCheckedComboBoxEdit2;
            this.colOrderDisplayOrder.FieldName = "OrderDisplayOrder";
            this.colOrderDisplayOrder.Name = "colOrderDisplayOrder";
            // 
            // repositoryItemCheckedComboBoxEdit2
            // 
            resources.ApplyResources(this.repositoryItemCheckedComboBoxEdit2, "repositoryItemCheckedComboBoxEdit2");
            this.repositoryItemCheckedComboBoxEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemCheckedComboBoxEdit2.Buttons"))))});
            this.repositoryItemCheckedComboBoxEdit2.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit2.Items"), resources.GetString("repositoryItemCheckedComboBoxEdit2.Items1")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit2.Items2"), resources.GetString("repositoryItemCheckedComboBoxEdit2.Items3")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit2.Items4"), resources.GetString("repositoryItemCheckedComboBoxEdit2.Items5")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit2.Items6"), resources.GetString("repositoryItemCheckedComboBoxEdit2.Items7"))});
            this.repositoryItemCheckedComboBoxEdit2.Name = "repositoryItemCheckedComboBoxEdit2";
            this.repositoryItemCheckedComboBoxEdit2.ShowButtons = false;
            this.repositoryItemCheckedComboBoxEdit2.ShowPopupCloseButton = false;
            // 
            // colBtnDo
            // 
            resources.ApplyResources(this.colBtnDo, "colBtnDo");
            this.colBtnDo.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colBtnDo.FieldName = "BtnDo";
            this.colBtnDo.Name = "colBtnDo";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("repositoryItemButtonEdit1.Appearance.BackColor")));
            this.repositoryItemButtonEdit1.Appearance.BackColor2 = ((System.Drawing.Color)(resources.GetObject("repositoryItemButtonEdit1.Appearance.BackColor2")));
            this.repositoryItemButtonEdit1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("repositoryItemButtonEdit1.Appearance.GradientMode")));
            this.repositoryItemButtonEdit1.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this.repositoryItemButtonEdit1, "repositoryItemButtonEdit1");
            this.repositoryItemButtonEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            resources.ApplyResources(serializableAppearanceObject1, "serializableAppearanceObject1");
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseBorderColor = true;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), resources.GetString("repositoryItemButtonEdit1.Buttons1"), ((int)(resources.GetObject("repositoryItemButtonEdit1.Buttons2"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons3"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons4"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("repositoryItemButtonEdit1.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("repositoryItemButtonEdit1.Buttons8"), ((object)(resources.GetObject("repositoryItemButtonEdit1.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("repositoryItemButtonEdit1.Buttons10"))), ((bool)(resources.GetObject("repositoryItemButtonEdit1.Buttons11"))))});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemButtonEdit1.LookAndFeel.SkinName = "Office 2007 Blue";
            this.repositoryItemButtonEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // colOderType
            // 
            resources.ApplyResources(this.colOderType, "colOderType");
            this.colOderType.FieldName = "OderType";
            this.colOderType.Name = "colOderType";
            // 
            // colContents
            // 
            resources.ApplyResources(this.colContents, "colContents");
            this.colContents.FieldName = "Contents";
            this.colContents.Name = "colContents";
            // 
            // colActionDoYn
            // 
            resources.ApplyResources(this.colActionDoYn, "colActionDoYn");
            this.colActionDoYn.FieldName = "ActionDoYn";
            this.colActionDoYn.Name = "colActionDoYn";
            // 
            // colInputTab
            // 
            resources.ApplyResources(this.colInputTab, "colInputTab");
            this.colInputTab.FieldName = "InputTab";
            this.colInputTab.Name = "colInputTab";
            // 
            // colGroupSer
            // 
            resources.ApplyResources(this.colGroupSer, "colGroupSer");
            this.colGroupSer.FieldName = "GroupSer";
            this.colGroupSer.Name = "colGroupSer";
            // 
            // colInputTabAndGroupSer
            // 
            resources.ApplyResources(this.colInputTabAndGroupSer, "colInputTabAndGroupSer");
            this.colInputTabAndGroupSer.FieldName = "InputTabAndGroupSer";
            this.colInputTabAndGroupSer.Name = "colInputTabAndGroupSer";
            // 
            // grdContent
            // 
            resources.ApplyResources(this.grdContent, "grdContent");
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "ListOrder";
            this.grdContent.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdContent.MainView = this.gridView1;
            this.grdContent.Name = "grdContent";
            this.grdContent.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemMemoEdit2,
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckedComboBoxEdit2});
            this.grdContent.ToolTipController = this.toolTipController1;
            this.grdContent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            this.grdContent.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grdContent_ProcessGridKey);
            this.grdContent.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.BestFitMaxRowCount = 3;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colOrder,
            this.colTagCode,
            this.colTagName,
            this.colContent,
            this.colType,
            this.colCreateDate,
            this.colDirLocation,
            this.colPkOut,
            this.colHospCode,
            this.colGwa,
            this.colDateTime,
            this.colDoctor,
            this.colDisplayOrther});
            this.gridView1.GridControl = this.grdContent;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.EnableDetailToolTip = true;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails;
            this.gridView1.OptionsDetail.SmartDetailHeight = true;
            this.gridView1.OptionsPrint.PrintDetails = true;
            this.gridView1.OptionsPrint.PrintHeader = false;
            this.gridView1.OptionsPrint.PrintHorzLines = false;
            this.gridView1.OptionsPrint.PrintVertLines = false;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 0;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gridView1_CalcRowHeight);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.RowCellDefaultAlignment += new DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventHandler(this.gridView1_RowCellDefaultAlignment);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdContent_KeyDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            this.gridView1.RowCountChanged += new System.EventHandler(this.gridView1_RowCountChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colOrder
            // 
            resources.ApplyResources(this.colOrder, "colOrder");
            this.colOrder.FieldName = "Order";
            this.colOrder.Name = "colOrder";
            // 
            // colDisplayOrther
            // 
            resources.ApplyResources(this.colDisplayOrther, "colDisplayOrther");
            this.colDisplayOrther.ColumnEdit = this.repositoryItemCheckedComboBoxEdit1;
            this.colDisplayOrther.FieldName = "DisplayOrther";
            this.colDisplayOrther.Name = "colDisplayOrther";
            this.colDisplayOrther.OptionsColumn.FixedWidth = true;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            resources.ApplyResources(this.repositoryItemCheckedComboBoxEdit1, "repositoryItemCheckedComboBoxEdit1");
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemCheckedComboBoxEdit1.Buttons"))))});
            this.repositoryItemCheckedComboBoxEdit1.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit1.Items"), resources.GetString("repositoryItemCheckedComboBoxEdit1.Items1")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit1.Items2"), resources.GetString("repositoryItemCheckedComboBoxEdit1.Items3")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit1.Items4"), resources.GetString("repositoryItemCheckedComboBoxEdit1.Items5")),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(resources.GetString("repositoryItemCheckedComboBoxEdit1.Items6"), resources.GetString("repositoryItemCheckedComboBoxEdit1.Items7"))});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            this.repositoryItemCheckedComboBoxEdit1.ShowButtons = false;
            this.repositoryItemCheckedComboBoxEdit1.ShowPopupCloseButton = false;
            // 
            // colTagCode
            // 
            resources.ApplyResources(this.colTagCode, "colTagCode");
            this.colTagCode.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.colTagCode.FieldName = "TagCode";
            this.colTagCode.Name = "colTagCode";
            this.colTagCode.OptionsColumn.FixedWidth = true;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            resources.ApplyResources(this.repositoryItemGridLookUpEdit1, "repositoryItemGridLookUpEdit1");
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemGridLookUpEdit1.Buttons"))))});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colTagName
            // 
            resources.ApplyResources(this.colTagName, "colTagName");
            this.colTagName.FieldName = "TagName";
            this.colTagName.Name = "colTagName";
            this.colTagName.OptionsColumn.AllowEdit = false;
            this.colTagName.OptionsColumn.FixedWidth = true;
            this.colTagName.OptionsColumn.ReadOnly = true;
            // 
            // colContent
            // 
            resources.ApplyResources(this.colContent, "colContent");
            this.colContent.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colContent.FieldName = "Content";
            this.colContent.Name = "colContent";
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colType
            // 
            resources.ApplyResources(this.colType, "colType");
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            // 
            // colCreateDate
            // 
            resources.ApplyResources(this.colCreateDate, "colCreateDate");
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            // 
            // colDirLocation
            // 
            resources.ApplyResources(this.colDirLocation, "colDirLocation");
            this.colDirLocation.FieldName = "DirLocation";
            this.colDirLocation.Name = "colDirLocation";
            // 
            // colPkOut
            // 
            resources.ApplyResources(this.colPkOut, "colPkOut");
            this.colPkOut.FieldName = "PkOut";
            this.colPkOut.Name = "colPkOut";
            // 
            // colHospCode
            // 
            resources.ApplyResources(this.colHospCode, "colHospCode");
            this.colHospCode.FieldName = "HospCode";
            this.colHospCode.Name = "colHospCode";
            // 
            // colGwa
            // 
            resources.ApplyResources(this.colGwa, "colGwa");
            this.colGwa.FieldName = "Gwa";
            this.colGwa.Name = "colGwa";
            // 
            // colDateTime
            // 
            resources.ApplyResources(this.colDateTime, "colDateTime");
            this.colDateTime.FieldName = "DateTime";
            this.colDateTime.Name = "colDateTime";
            // 
            // colDoctor
            // 
            resources.ApplyResources(this.colDoctor, "colDoctor");
            this.colDoctor.FieldName = "Doctor";
            this.colDoctor.Name = "colDoctor";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.DoubleClick += new System.EventHandler(this.repositoryItemPictureEdit1_DoubleClick);
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repositoryItemMemoEdit1_EditValueChanging);
            this.repositoryItemMemoEdit1.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.repositoryItemMemoEdit1_FormatEditValue);
            // 
            // repositoryItemButtonEdit2
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit2, "repositoryItemButtonEdit2");
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemButtonEdit2.Buttons"))), resources.GetString("repositoryItemButtonEdit2.Buttons1"), ((int)(resources.GetObject("repositoryItemButtonEdit2.Buttons2"))), ((bool)(resources.GetObject("repositoryItemButtonEdit2.Buttons3"))), ((bool)(resources.GetObject("repositoryItemButtonEdit2.Buttons4"))), ((bool)(resources.GetObject("repositoryItemButtonEdit2.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("repositoryItemButtonEdit2.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit2.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, resources.GetString("repositoryItemButtonEdit2.Buttons8"), ((object)(resources.GetObject("repositoryItemButtonEdit2.Buttons9"))), ((DevExpress.Utils.SuperToolTip)(resources.GetObject("repositoryItemButtonEdit2.Buttons10"))), ((bool)(resources.GetObject("repositoryItemButtonEdit2.Buttons11"))))});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // toolTipController1
            // 
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brower});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            this.contextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
            // 
            // brower
            // 
            this.brower.Name = "brower";
            resources.ApplyResources(this.brower, "brower");
            // 
            // UcGrid
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdContent);
            this.Name = "UcGrid";
            this.Load += new System.EventHandler(this.grdContent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdContent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTagCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTagName;
        private DevExpress.XtraGrid.Columns.GridColumn colContent;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colBtnDo;
        private DevExpress.XtraGrid.Columns.GridColumn colOderType;
        private DevExpress.XtraGrid.Columns.GridColumn colContents;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDisplayOrder;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDirLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Columns.GridColumn colPkOut;
        private DevExpress.XtraGrid.Columns.GridColumn colHospCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGwa;
        private DevExpress.XtraGrid.Columns.GridColumn colDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDoctor;
        private DevExpress.XtraGrid.Columns.GridColumn colActionDoYn;
        private DevExpress.XtraGrid.Columns.GridColumn colInputTab;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupSer;
        private DevExpress.XtraGrid.Columns.GridColumn colInputTabAndGroupSer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem brower;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayOrther;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit2;


    }
}
