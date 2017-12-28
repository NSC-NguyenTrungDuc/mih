namespace IHIS.DRGS
{
    partial class AntibioticList
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AntibioticList));
            this.grdAntibioticList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.lbTitle = new IHIS.Framework.XLabel();
            this.pnBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.grdAntibioticList)).BeginInit();
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAntibioticList
            // 
            this.grdAntibioticList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdAntibioticList.ColPerLine = 3;
            this.grdAntibioticList.Cols = 3;
            this.grdAntibioticList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAntibioticList.FixedRows = 1;
            this.grdAntibioticList.HeaderHeights.Add(23);
            this.grdAntibioticList.Location = new System.Drawing.Point(0, 33);
            this.grdAntibioticList.Name = "grdAntibioticList";
            this.grdAntibioticList.QuerySQL = resources.GetString("grdAntibioticList.QuerySQL");
            this.grdAntibioticList.ReadOnly = true;
            this.grdAntibioticList.Rows = 2;
            this.grdAntibioticList.Size = new System.Drawing.Size(573, 418);
            this.grdAntibioticList.TabIndex = 23;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hangmog_code";
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "項目コード";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_name";
            this.xEditGridCell2.CellWidth = 375;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "項目名";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "order_gubun";
            this.xEditGridCell3.HeaderText = "区分";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "yak_kizun_code";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "small_code";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // lbTitle
            // 
            this.lbTitle.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD2;
            this.lbTitle.BorderColor = IHIS.Framework.XColor.XRotatorGradientStartColor;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbTitle.ForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(573, 33);
            this.lbTitle.TabIndex = 24;
            this.lbTitle.Text = "院内抗生剤一覧";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.btnList);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 451);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(573, 34);
            this.pnBottom.TabIndex = 25;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "照会", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "閉じる", -1, "")});
            this.btnList.IsVisiblePreview = false;
            this.btnList.Location = new System.Drawing.Point(407, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(166, 34);
            this.btnList.TabIndex = 11;
            // 
            // AntibioticList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 485);
            this.Controls.Add(this.grdAntibioticList);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.lbTitle);
            this.Name = "AntibioticList";
            this.Load += new System.EventHandler(this.AntibioticList_Load);
            this.Controls.SetChildIndex(this.lbTitle, 0);
            this.Controls.SetChildIndex(this.pnBottom, 0);
            this.Controls.SetChildIndex(this.grdAntibioticList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdAntibioticList)).EndInit();
            this.pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XEditGrid grdAntibioticList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XLabel lbTitle;
        private IHIS.Framework.XPanel pnBottom;
        private IHIS.Framework.XButtonList btnList;
    }
}
