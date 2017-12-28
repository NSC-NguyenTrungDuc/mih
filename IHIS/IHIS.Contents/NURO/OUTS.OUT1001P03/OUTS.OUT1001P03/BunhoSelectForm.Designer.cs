namespace IHIS.NURO
{
    partial class BunhoSelectForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BunhoSelectForm));
            this.grdPAList = new IHIS.Framework.XEditGrid();
            this.xGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnQuery = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.cbxQueryFlag = new IHIS.Framework.XCheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdPAList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPAList
            // 
            this.grdPAList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell3});
            this.grdPAList.ColPerLine = 3;
            this.grdPAList.Cols = 4;
            resources.ApplyResources(this.grdPAList, "grdPAList");
            this.grdPAList.ExecuteQuery = null;
            this.grdPAList.FixedCols = 1;
            this.grdPAList.FixedRows = 1;
            this.grdPAList.HeaderHeights.Add(21);
            this.grdPAList.Name = "grdPAList";
           // this.grdPAList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPAList.ParamList")));
           // this.grdPAList.QuerySQL = null;
            this.grdPAList.RowHeaderVisible = true;
            this.grdPAList.Rows = 2;
            this.grdPAList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPAList_MouseDown);
            this.grdPAList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPAList_QueryStarting);
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "bunho";
            this.xGridCell1.Col = 1;
            this.xGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.IsReadOnly = true;
            this.xGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "suname";
            this.xGridCell2.CellWidth = 150;
            this.xGridCell2.Col = 2;
            this.xGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell2, "xGridCell2");
            this.xGridCell2.IsReadOnly = true;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "sex";
            this.xGridCell3.CellWidth = 60;
            this.xGridCell3.Col = 3;
            this.xGridCell3.EnableSort = true;
            this.xGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            this.xGridCell3.IsReadOnly = true;
            this.xGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Controls.Add(this.grdPAList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Controls.Add(this.cbxQueryFlag);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnSelect);
            this.xPanel3.Controls.Add(this.btnQuery);
            this.xPanel3.Controls.Add(this.btnClose);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnSelect
            // 
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.Image = global::IHIS.NURO.Properties.Resources.전송_16;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnQuery
            // 
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.Image = global::IHIS.NURO.Properties.Resources.조회;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::IHIS.NURO.Properties.Resources.닫기;
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbxQueryFlag
            // 
            resources.ApplyResources(this.cbxQueryFlag, "cbxQueryFlag");
            this.cbxQueryFlag.Name = "cbxQueryFlag";
            this.cbxQueryFlag.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // BunhoSelectForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BunhoSelectForm";
            this.Load += new System.EventHandler(this.BunhoSelectForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdPAList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.XButton btnQuery;
        private IHIS.Framework.XButton btnSelect;
        private System.Windows.Forms.ImageList imageList1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XCheckBox cbxQueryFlag;
        private IHIS.Framework.XEditGrid grdPAList;
        private IHIS.Framework.XEditGridCell xGridCell1;
        private IHIS.Framework.XEditGridCell xGridCell2;
        private IHIS.Framework.XEditGridCell xGridCell3;
        private IHIS.Framework.XPanel xPanel3;
    }
}