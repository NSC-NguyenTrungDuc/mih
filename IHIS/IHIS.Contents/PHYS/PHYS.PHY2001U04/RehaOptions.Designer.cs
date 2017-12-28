namespace IHIS.PHYS
{
    partial class RehaOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RehaOptions));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdOCS0132 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0132)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // grdOCS0132
            // 
            this.grdOCS0132.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdOCS0132.ColPerLine = 2;
            this.grdOCS0132.Cols = 3;
            this.grdOCS0132.ExecuteQuery = null;
            this.grdOCS0132.FixedCols = 1;
            this.grdOCS0132.FixedRows = 1;
            this.grdOCS0132.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdOCS0132, "grdOCS0132");
            this.grdOCS0132.Name = "grdOCS0132";
            this.grdOCS0132.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0132.ParamList")));
            this.grdOCS0132.RowHeaderVisible = true;
            this.grdOCS0132.Rows = 2;
            this.grdOCS0132.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0132_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "option";
            this.xEditGridCell1.CellWidth = 191;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "value";
            this.xEditGridCell2.CellWidth = 354;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // RehaOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.grdOCS0132);
            this.Name = "RehaOptions";
            this.Load += new System.EventHandler(this.RehaOptions_Load);
            this.Controls.SetChildIndex(this.grdOCS0132, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0132)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGrid grdOCS0132;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
    }
}