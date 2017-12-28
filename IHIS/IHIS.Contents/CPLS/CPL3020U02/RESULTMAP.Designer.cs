namespace IHIS.CPLS
{
    partial class RESULTMAP
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RESULTMAP));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dbxSpecimen_ser = new IHIS.Framework.XDisplayBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cbxAll = new IHIS.Framework.XCheckBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.dbxEquip = new IHIS.Framework.XDisplayBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.grdResultList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.grdIDList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIDList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "照会", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "適用", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.None, "取消", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "閉じる", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.dbxSpecimen_ser);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.dbxSuname);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.cbxAll);
            this.xPanel1.Controls.Add(this.dtpToDate);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.dtpFromDate);
            this.xPanel1.Controls.Add(this.xLabel9);
            this.xPanel1.Controls.Add(this.dbxEquip);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Name = "xPanel1";
            // 
            // dbxSpecimen_ser
            // 
            resources.ApplyResources(this.dbxSpecimen_ser, "dbxSpecimen_ser");
            this.dbxSpecimen_ser.Name = "dbxSpecimen_ser";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // cbxAll
            // 
            resources.ApplyResources(this.cbxAll, "cbxAll");
            this.cbxAll.Name = "cbxAll";
            this.cbxAll.UseVisualStyleBackColor = false;
            this.cbxAll.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // dbxEquip
            // 
            resources.ApplyResources(this.dbxEquip, "dbxEquip");
            this.dbxEquip.Name = "dbxEquip";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XRotatorGradientStartColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // grdResultList
            // 
            this.grdResultList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell12});
            this.grdResultList.ColPerLine = 4;
            this.grdResultList.Cols = 5;
            resources.ApplyResources(this.grdResultList, "grdResultList");
            this.grdResultList.ExecuteQuery = null;
            this.grdResultList.FixedCols = 1;
            this.grdResultList.FixedRows = 1;
            this.grdResultList.HeaderHeights.Add(34);
            this.grdResultList.Name = "grdResultList";
            this.grdResultList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdResultList.ParamList")));
            this.grdResultList.QuerySQL = resources.GetString("grdResultList.QuerySQL");
            this.grdResultList.ReadOnly = true;
            this.grdResultList.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grdResultList.RowHeaderVisible = true;
            this.grdResultList.Rows = 2;
            this.grdResultList.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdResultList.ToolTipActive = true;
            this.grdResultList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdResultList_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "result_code";
            this.xEditGridCell11.CellWidth = 94;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.CellWidth = 93;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_name";
            this.xEditGridCell2.CellWidth = 176;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell12.CellName = "result_val";
            this.xEditGridCell12.CellWidth = 75;
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdIDList
            // 
            this.grdIDList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell7});
            this.grdIDList.ColPerLine = 5;
            this.grdIDList.Cols = 6;
            resources.ApplyResources(this.grdIDList, "grdIDList");
            this.grdIDList.ExecuteQuery = null;
            this.grdIDList.FixedCols = 1;
            this.grdIDList.FixedRows = 1;
            this.grdIDList.HeaderHeights.Add(34);
            this.grdIDList.Name = "grdIDList";
            this.grdIDList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdIDList.ParamList")));
            this.grdIDList.QuerySQL = resources.GetString("grdIDList.QuerySQL");
            this.grdIDList.ReadOnly = true;
            this.grdIDList.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grdIDList.RowHeaderVisible = true;
            this.grdIDList.Rows = 2;
            this.grdIDList.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdIDList.ToolTipActive = true;
            this.grdIDList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdIDList_QueryEnd);
            this.grdIDList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdIDList_RowFocusChanged);
            this.grdIDList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdIDList_QueryStarting);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "result_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "proc_time";
            this.xEditGridCell6.CellWidth = 77;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.Mask = "##:##:##";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 13;
            this.xEditGridCell3.CellName = "sample_id";
            this.xEditGridCell3.CellWidth = 94;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 13;
            this.xEditGridCell5.CellName = "specimen_ser";
            this.xEditGridCell5.CellWidth = 90;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "patient_id";
            this.xEditGridCell7.Col = 5;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // RESULTMAP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdIDList);
            this.Controls.Add(this.grdResultList);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "RESULTMAP";
            this.Load += new System.EventHandler(this.RESULTMAP_Load);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.grdResultList, 0);
            this.Controls.SetChildIndex(this.grdIDList, 0);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIDList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XDisplayBox dbxEquip;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XEditGrid grdResultList;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGrid grdIDList;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XDatePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XLabel xLabel9;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XCheckBox cbxAll;
        private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDisplayBox dbxSpecimen_ser;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;

    }
}