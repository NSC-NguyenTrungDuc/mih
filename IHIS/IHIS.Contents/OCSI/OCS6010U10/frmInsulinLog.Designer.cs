namespace IHIS.OCSI
{
    partial class frmInsulinLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInsulinLog));
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdOCS2016 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.cbxLimit7 = new IHIS.Framework.XCheckBox();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 652);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(465, 33);
            this.pnlBottom.TabIndex = 46;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(300, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(163, 31);
            this.btnList.TabIndex = 9;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdOCS2016
            // 
            this.grdOCS2016.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell1});
            this.grdOCS2016.ColPerLine = 7;
            this.grdOCS2016.Cols = 8;
            this.grdOCS2016.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS2016.FixedCols = 1;
            this.grdOCS2016.FixedRows = 1;
            this.grdOCS2016.HeaderHeights.Add(36);
            this.grdOCS2016.Location = new System.Drawing.Point(0, 0);
            this.grdOCS2016.Name = "grdOCS2016";
            this.grdOCS2016.QuerySQL = resources.GetString("grdOCS2016.QuerySQL");
            this.grdOCS2016.RowHeaderVisible = true;
            this.grdOCS2016.Rows = 2;
            this.grdOCS2016.Size = new System.Drawing.Size(465, 590);
            this.grdOCS2016.TabIndex = 47;
            this.grdOCS2016.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS2016_QueryEnd);
            this.grdOCS2016.Load += new System.EventHandler(this.grdOCS2016_Load);
            this.grdOCS2016.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS2016_QueryStarting);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "act_date";
            this.xEditGridCell6.CellWidth = 90;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.HeaderText = "投与日付";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "act_time";
            this.xEditGridCell7.CellWidth = 60;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.HeaderText = "投与時間";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.Mask = "XX:XX";
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "blood_sugar";
            this.xEditGridCell11.CellWidth = 75;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.HeaderText = "測定血糖値";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "fkocs2016";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "fkocs2016";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "suryang";
            this.xEditGridCell8.CellWidth = 51;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.HeaderText = "投与量";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ord_danui";
            this.xEditGridCell9.CellWidth = 40;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.HeaderText = "単位";
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 20;
            this.xEditGridCell10.CellName = "user_nm";
            this.xEditGridCell10.Col = 6;
            this.xEditGridCell10.HeaderText = "実施者";
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "kubun";
            this.xEditGridCell1.CellWidth = 23;
            this.xEditGridCell1.Col = 7;
            this.xEditGridCell1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.HeaderText = "区\r\n分";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.cbxLimit7);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(465, 62);
            this.pnlTop.TabIndex = 61;
            // 
            // paBox
            // 
            this.paBox.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.paBox.Location = new System.Drawing.Point(3, 4);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(457, 32);
            this.paBox.TabIndex = 58;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // cbxLimit7
            // 
            this.cbxLimit7.AutoSize = true;
            this.cbxLimit7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.cbxLimit7.Checked = true;
            this.cbxLimit7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxLimit7.Location = new System.Drawing.Point(252, 40);
            this.cbxLimit7.Name = "cbxLimit7";
            this.cbxLimit7.Size = new System.Drawing.Size(208, 17);
            this.cbxLimit7.TabIndex = 57;
            this.cbxLimit7.Tag = "7";
            this.cbxLimit7.Text = "最新一週間内の内訳のみ照会する";
            this.cbxLimit7.UseVisualStyleBackColor = false;
            this.cbxLimit7.CheckedChanged += new System.EventHandler(this.cbxLimit7_CheckedChanged);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grdOCS2016);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 62);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(465, 590);
            this.pnlCenter.TabIndex = 63;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "指";
            this.xComboItem1.ValueItem = "OCS";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "-";
            this.xComboItem2.ValueItem = "NUR";
            // 
            // frmInsulinLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 707);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmInsulinLog";
            this.Text = "インスリン投与履歴照会";
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2016)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdOCS2016;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XCheckBox cbxLimit7;
        private IHIS.Framework.XPanel pnlCenter;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
    }
}