namespace IHIS.NURI
{
    partial class ChangeGubun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeGubun));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dbxGubunName1 = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpGubunStart1 = new IHIS.Framework.XDatePicker();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboGubun = new IHIS.Framework.XDictComboBox();
            this.dtpGubunStart2 = new IHIS.Framework.XDatePicker();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.btnChange = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.grdGubunHistory = new IHIS.Framework.XGrid();
            this.xGridCell3 = new IHIS.Framework.XGridCell();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.xGridCell2 = new IHIS.Framework.XGridCell();
            this.xGridCell4 = new IHIS.Framework.XGridCell();
            this.xGridCell5 = new IHIS.Framework.XGridCell();
            this.layGubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xGridCell6 = new IHIS.Framework.XGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.grdGubunHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGubun)).BeginInit();
            this.SuspendLayout();
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(248, 10);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(74, 21);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "保険名";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxGubunName1
            // 
            this.dbxGubunName1.EdgeRounding = false;
            this.dbxGubunName1.Location = new System.Drawing.Point(322, 10);
            this.dbxGubunName1.Name = "dbxGubunName1";
            this.dbxGubunName1.Size = new System.Drawing.Size(282, 21);
            this.dbxGubunName1.TabIndex = 2;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(248, 37);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(74, 21);
            this.xLabel2.TabIndex = 3;
            this.xLabel2.Text = "保険適用日";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpGubunStart1
            // 
            this.dtpGubunStart1.Enabled = false;
            this.dtpGubunStart1.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpGubunStart1.IsJapanYearType = true;
            this.dtpGubunStart1.Location = new System.Drawing.Point(322, 37);
            this.dtpGubunStart1.Name = "dtpGubunStart1";
            this.dtpGubunStart1.Size = new System.Drawing.Size(145, 21);
            this.dtpGubunStart1.TabIndex = 4;
            this.dtpGubunStart1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(248, 101);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(74, 21);
            this.xLabel3.TabIndex = 5;
            this.xLabel3.Text = "保険名";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboGubun
            // 
            this.cboGubun.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.cboGubun.Location = new System.Drawing.Point(322, 101);
            this.cboGubun.Name = "cboGubun";
            this.cboGubun.Size = new System.Drawing.Size(282, 21);
            this.cboGubun.TabIndex = 6;
            // 
            // dtpGubunStart2
            // 
            this.dtpGubunStart2.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.dtpGubunStart2.IsJapanYearType = true;
            this.dtpGubunStart2.Location = new System.Drawing.Point(322, 129);
            this.dtpGubunStart2.Name = "dtpGubunStart2";
            this.dtpGubunStart2.Size = new System.Drawing.Size(145, 21);
            this.dtpGubunStart2.TabIndex = 8;
            this.dtpGubunStart2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpGubunStart2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpGubunStart2_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Location = new System.Drawing.Point(248, 129);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(74, 21);
            this.xLabel4.TabIndex = 7;
            this.xLabel4.Text = "保険適用日";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChange
            // 
            this.btnChange.Image = ((System.Drawing.Image)(resources.GetObject("btnChange.Image")));
            this.btnChange.ImageIndex = 1;
            this.btnChange.ImageList = this.imageList;
            this.btnChange.Location = new System.Drawing.Point(438, 160);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(89, 27);
            this.btnChange.TabIndex = 9;
            this.btnChange.Text = "保険変更";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageIndex = 2;
            this.btnClose.ImageList = this.imageList;
            this.btnClose.Location = new System.Drawing.Point(529, 160);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnClose.Size = new System.Drawing.Size(76, 27);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "아래로.gif");
            this.imageList.Images.SetKeyName(1, "전송_16.gif");
            this.imageList.Images.SetKeyName(2, "닫기.gif");
            // 
            // xLabel5
            // 
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel5.Image = ((System.Drawing.Image)(resources.GetObject("xLabel5.Image")));
            this.xLabel5.ImageIndex = 0;
            this.xLabel5.ImageList = this.imageList;
            this.xLabel5.Location = new System.Drawing.Point(327, 65);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(58, 29);
            this.xLabel5.TabIndex = 11;
            // 
            // grdGubunHistory
            // 
            this.grdGubunHistory.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell3,
            this.xGridCell1,
            this.xGridCell2,
            this.xGridCell4,
            this.xGridCell5,
            this.xGridCell6});
            this.grdGubunHistory.ColPerLine = 2;
            this.grdGubunHistory.Cols = 2;
            this.grdGubunHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdGubunHistory.FixedRows = 1;
            this.grdGubunHistory.HeaderHeights.Add(21);
            this.grdGubunHistory.Location = new System.Drawing.Point(0, 0);
            this.grdGubunHistory.Name = "grdGubunHistory";
            this.grdGubunHistory.QuerySQL = resources.GetString("grdGubunHistory.QuerySQL");
            this.grdGubunHistory.Rows = 2;
            this.grdGubunHistory.Size = new System.Drawing.Size(242, 193);
            this.grdGubunHistory.TabIndex = 12;
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "gubun";
            this.xGridCell3.Col = -1;
            this.xGridCell3.HeaderText = "gubun";
            this.xGridCell3.IsVisible = false;
            this.xGridCell3.Row = -1;
            // 
            // xGridCell1
            // 
            this.xGridCell1.CellName = "gubun_name";
            this.xGridCell1.CellWidth = 108;
            this.xGridCell1.HeaderText = "保険名";
            // 
            // xGridCell2
            // 
            this.xGridCell2.CellName = "start_date";
            this.xGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell2.CellWidth = 110;
            this.xGridCell2.Col = 1;
            this.xGridCell2.HeaderText = "保険適用日";
            this.xGridCell2.IsJapanYearType = true;
            // 
            // xGridCell4
            // 
            this.xGridCell4.CellName = "pkinp1002";
            this.xGridCell4.Col = -1;
            this.xGridCell4.IsVisible = false;
            this.xGridCell4.Row = -1;
            // 
            // xGridCell5
            // 
            this.xGridCell5.CellName = "gubun_ipwon_date";
            this.xGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xGridCell5.Col = -1;
            this.xGridCell5.IsVisible = false;
            this.xGridCell5.Row = -1;
            // 
            // layGubun
            // 
            this.layGubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layGubun.QuerySQL = resources.GetString("layGubun.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "gubun_name";
            // 
            // xLabel6
            // 
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.Image = ((System.Drawing.Image)(resources.GetObject("xLabel6.Image")));
            this.xLabel6.ImageIndex = 0;
            this.xLabel6.ImageList = this.imageList;
            this.xLabel6.Location = new System.Drawing.Point(398, 65);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(58, 29);
            this.xLabel6.TabIndex = 13;
            // 
            // xLabel7
            // 
            this.xLabel7.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel7.Image = ((System.Drawing.Image)(resources.GetObject("xLabel7.Image")));
            this.xLabel7.ImageIndex = 0;
            this.xLabel7.ImageList = this.imageList;
            this.xLabel7.Location = new System.Drawing.Point(469, 65);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(58, 29);
            this.xLabel7.TabIndex = 14;
            // 
            // xGridCell6
            // 
            this.xGridCell6.CellName = "fkinp1001";
            this.xGridCell6.Col = -1;
            this.xGridCell6.IsVisible = false;
            this.xGridCell6.Row = -1;
            // 
            // ChangeGubun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 215);
            this.Controls.Add(this.xLabel7);
            this.Controls.Add(this.xLabel6);
            this.Controls.Add(this.grdGubunHistory);
            this.Controls.Add(this.xLabel5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.dtpGubunStart2);
            this.Controls.Add(this.xLabel4);
            this.Controls.Add(this.cboGubun);
            this.Controls.Add(this.xLabel3);
            this.Controls.Add(this.dtpGubunStart1);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.dbxGubunName1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeGubun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "保険変更";
            this.Load += new System.EventHandler(this.ChangeGubun_Load);
            this.Controls.SetChildIndex(this.dbxGubunName1, 0);
            this.Controls.SetChildIndex(this.xLabel1, 0);
            this.Controls.SetChildIndex(this.xLabel2, 0);
            this.Controls.SetChildIndex(this.dtpGubunStart1, 0);
            this.Controls.SetChildIndex(this.xLabel3, 0);
            this.Controls.SetChildIndex(this.cboGubun, 0);
            this.Controls.SetChildIndex(this.xLabel4, 0);
            this.Controls.SetChildIndex(this.dtpGubunStart2, 0);
            this.Controls.SetChildIndex(this.btnChange, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.xLabel5, 0);
            this.Controls.SetChildIndex(this.grdGubunHistory, 0);
            this.Controls.SetChildIndex(this.xLabel6, 0);
            this.Controls.SetChildIndex(this.xLabel7, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdGubunHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGubun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDisplayBox dbxGubunName1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDatePicker dtpGubunStart1;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XDictComboBox cboGubun;
        private IHIS.Framework.XDatePicker dtpGubunStart2;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XButton btnChange;
        private IHIS.Framework.XButton btnClose;
        private System.Windows.Forms.ImageList imageList;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XGrid grdGubunHistory;
        private IHIS.Framework.XGridCell xGridCell1;
        private IHIS.Framework.XGridCell xGridCell2;
        private IHIS.Framework.XGridCell xGridCell3;
        private IHIS.Framework.XGridCell xGridCell4;
        private IHIS.Framework.MultiLayout layGubun;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XGridCell xGridCell5;
        private IHIS.Framework.XGridCell xGridCell6;
    }
}