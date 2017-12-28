namespace IHIS.BASS
{
    partial class BAS0355U00
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0355U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.dtpQueryDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cboAutoOccurGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdBAS0355 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0355)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.dtpQueryDate);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.cboAutoOccurGubun);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(960, 41);
            this.xPanel1.TabIndex = 0;
            // 
            // dtpQueryDate
            // 
            this.dtpQueryDate.Location = new System.Drawing.Point(112, 10);
            this.dtpQueryDate.Name = "dtpQueryDate";
            this.dtpQueryDate.Size = new System.Drawing.Size(112, 20);
            this.dtpQueryDate.TabIndex = 3;
            this.dtpQueryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(14, 10);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(98, 21);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "基準日付";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboAutoOccurGubun
            // 
            this.cboAutoOccurGubun.Location = new System.Drawing.Point(365, 10);
            this.cboAutoOccurGubun.Name = "cboAutoOccurGubun";
            this.cboAutoOccurGubun.Size = new System.Drawing.Size(152, 21);
            this.cboAutoOccurGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboAutoOccurGubun.TabIndex = 1;
            this.cboAutoOccurGubun.UserSQL = "SELECT \'%\', \'全体\'\r\nFROM DUAL\r\nUNION ALL\r\nSELECT CODE, CODE_NAME\r\nFROM BAS0102 \r\nWH" +
                "ERE CODE_TYPE = \'AUTO_OCCUR_GUBUN\'\r\nORDER BY 1";
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(266, 10);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(98, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "自動発生区分";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdBAS0355
            // 
            this.grdBAS0355.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7});
            this.grdBAS0355.ColPerLine = 7;
            this.grdBAS0355.Cols = 8;
            this.grdBAS0355.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBAS0355.FixedCols = 1;
            this.grdBAS0355.FixedRows = 1;
            this.grdBAS0355.HeaderHeights.Add(28);
            this.grdBAS0355.Location = new System.Drawing.Point(0, 41);
            this.grdBAS0355.Name = "grdBAS0355";
            this.grdBAS0355.QuerySQL = resources.GetString("grdBAS0355.QuerySQL");
            this.grdBAS0355.RowHeaderVisible = true;
            this.grdBAS0355.Rows = 2;
            this.grdBAS0355.Size = new System.Drawing.Size(960, 509);
            this.grdBAS0355.TabIndex = 1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "auto_occur_gubun";
            this.xEditGridCell1.CellWidth = 103;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.HeaderText = "自動発生区分";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM BAS0102 \r\nWHERE CODE_TYPE = \'AUTO_OCCUR_GUBUN\'\r\nORDE" +
                "R BY CODE";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "condition";
            this.xEditGridCell2.CellWidth = 99;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "発生条件";
            this.xEditGridCell2.IsUpdatable = false;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "condition_name";
            this.xEditGridCell3.CellWidth = 220;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderText = "発生条件名称";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "start_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 100;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.HeaderText = "開始日";
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "end_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 90;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.HeaderText = "終了日";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "sg_code";
            this.xEditGridCell6.CellWidth = 95;
            this.xEditGridCell6.Col = 6;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell6.HeaderText = "発生コード";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "sg_name";
            this.xEditGridCell7.CellWidth = 204;
            this.xEditGridCell7.Col = 7;
            this.xEditGridCell7.HeaderText = "コード名称";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(960, 40);
            this.xPanel2.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(468, 2);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(487, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // BAS0355U00
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdBAS0355);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "BAS0355U00";
            this.Load += new System.EventHandler(this.BAS0355U00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0355)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGrid grdBAS0355;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XDatePicker dtpQueryDate;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDictComboBox cboAutoOccurGubun;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
    }
}
