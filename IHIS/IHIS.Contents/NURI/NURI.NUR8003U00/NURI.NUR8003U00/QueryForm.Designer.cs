namespace IHIS.NURI
{
    partial class QueryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.tabPages = new IHIS.Framework.XTabControl();
            this.tabBP = new IHIS.X.Magic.Controls.TabPage();
            this.grdBP = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.tabSyochi = new IHIS.X.Magic.Controls.TabPage();
            this.grdSyochi = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.tabPages.SuspendLayout();
            this.tabBP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBP)).BeginInit();
            this.tabSyochi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSyochi)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPages
            // 
            this.tabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPages.IDEPixelArea = true;
            this.tabPages.IDEPixelBorder = false;
            this.tabPages.Location = new System.Drawing.Point(0, 47);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.SelectedTab = this.tabSyochi;
            this.tabPages.Size = new System.Drawing.Size(383, 377);
            this.tabPages.TabIndex = 1;
            this.tabPages.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabSyochi,
            this.tabBP});
            // 
            // tabBP
            // 
            this.tabBP.Controls.Add(this.grdBP);
            this.tabBP.Location = new System.Drawing.Point(0, 25);
            this.tabBP.Name = "tabBP";
            this.tabBP.Selected = false;
            this.tabBP.Size = new System.Drawing.Size(383, 352);
            this.tabBP.TabIndex = 4;
            this.tabBP.Title = "血圧照会";
            // 
            // grdBP
            // 
            this.grdBP.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdBP.ColPerLine = 4;
            this.grdBP.Cols = 4;
            this.grdBP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBP.FixedRows = 1;
            this.grdBP.HeaderHeights.Add(21);
            this.grdBP.Location = new System.Drawing.Point(0, 0);
            this.grdBP.Name = "grdBP";
            this.grdBP.QuerySQL = resources.GetString("grdBP.QuerySQL");
            this.grdBP.Rows = 2;
            this.grdBP.Size = new System.Drawing.Size(383, 352);
            this.grdBP.TabIndex = 0;
            this.grdBP.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBP_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "ymd";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 122;
            this.xEditGridCell3.HeaderText = "記録日";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "time_gubun";
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.HeaderText = "時間";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bph";
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.HeaderText = "血圧H";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "bpl";
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.HeaderText = "血圧L";
            // 
            // tabSyochi
            // 
            this.tabSyochi.Controls.Add(this.grdSyochi);
            this.tabSyochi.Location = new System.Drawing.Point(0, 25);
            this.tabSyochi.Name = "tabSyochi";
            this.tabSyochi.Size = new System.Drawing.Size(383, 352);
            this.tabSyochi.TabIndex = 3;
            this.tabSyochi.Title = "処置";
            // 
            // grdSyochi
            // 
            this.grdSyochi.ApplyAutoHeight = true;
            this.grdSyochi.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdSyochi.ColPerLine = 2;
            this.grdSyochi.Cols = 2;
            this.grdSyochi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSyochi.FixedRows = 1;
            this.grdSyochi.HeaderHeights.Add(21);
            this.grdSyochi.Location = new System.Drawing.Point(0, 0);
            this.grdSyochi.Name = "grdSyochi";
            this.grdSyochi.QuerySQL = resources.GetString("grdSyochi.QuerySQL");
            this.grdSyochi.Rows = 2;
            this.grdSyochi.Size = new System.Drawing.Size(383, 352);
            this.grdSyochi.TabIndex = 0;
            this.grdSyochi.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdSyochi_QueryEnd);
            this.grdSyochi.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSyochi_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ymd";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 93;
            this.xEditGridCell1.HeaderText = "記録日";
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_value";
            this.xEditGridCell2.CellWidth = 272;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "処置内容";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(383, 47);
            this.pnlTop.TabIndex = 2;
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(3, 3);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(377, 34);
            this.paBox.TabIndex = 0;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.Location = new System.Drawing.Point(0, 424);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(383, 34);
            this.xPanel1.TabIndex = 3;
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(220, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 480);
            this.Controls.Add(this.tabPages);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.pnlTop);
            this.Name = "QueryForm";
            this.Text = "記録照会";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            this.Controls.SetChildIndex(this.tabPages, 0);
            this.tabPages.ResumeLayout(false);
            this.tabBP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBP)).EndInit();
            this.tabSyochi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSyochi)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XTabControl tabPages;
        private IHIS.X.Magic.Controls.TabPage tabSyochi;
        private IHIS.X.Magic.Controls.TabPage tabBP;
        private IHIS.Framework.XEditGrid grdSyochi;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGrid grdBP;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
    }
}