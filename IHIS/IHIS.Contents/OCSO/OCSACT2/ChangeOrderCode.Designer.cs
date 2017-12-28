namespace IHIS.OCSO
{
    partial class ChangeOrderCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeOrderCode));
            this.grdOrderList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdOrderList
            // 
            this.grdOrderList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell15,
            this.xEditGridCell16});
            this.grdOrderList.ColPerLine = 2;
            this.grdOrderList.Cols = 3;
            this.grdOrderList.ExecuteQuery = null;
            this.grdOrderList.FixedCols = 1;
            this.grdOrderList.FixedRows = 1;
            this.grdOrderList.HeaderHeights.Add(19);
            resources.ApplyResources(this.grdOrderList, "grdOrderList");
            this.grdOrderList.Name = "grdOrderList";
            this.grdOrderList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrderList.ParamList")));
            this.grdOrderList.QuerySQL = "-- Tenmp Order List --\r\nSELECT CODE\r\n     , CODE_NAME\r\n  FROM VW_OCS_DUMMY_ORDER_" +
                "DETAIL\r\n WHERE CODE_TYPE = :f_code_type";
            this.grdOrderList.ReadOnly = true;
            this.grdOrderList.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grdOrderList.RowHeaderVisible = true;
            this.grdOrderList.Rows = 2;
            this.grdOrderList.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdOrderList.ToolTipActive = true;
            this.grdOrderList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdOrderList_MouseDoubleClick);
            this.grdOrderList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrderList_QueryStarting);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "hangmog_code";
            this.xEditGridCell15.CellWidth = 119;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "hangmog_name";
            this.xEditGridCell16.CellWidth = 236;
            this.xEditGridCell16.Col = 2;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "照会", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "選択", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "閉じる", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XRotatorGradientStartColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // ChangeOrderCode
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.grdOrderList);
            this.Name = "ChangeOrderCode";
            this.Load += new System.EventHandler(this.ChangeOrderCode_Load);
            this.Controls.SetChildIndex(this.grdOrderList, 0);
            this.Controls.SetChildIndex(this.xPanel2, 0);
            this.Controls.SetChildIndex(this.xLabel4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XEditGrid grdOrderList;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel4;
    }
}