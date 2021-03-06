namespace IHIS.BASS
{
    partial class HOTCODEMASTER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HOTCODEMASTER));
            this.grdList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnSearch = new IHIS.Framework.XButton();
            this.hotCodeTextBox = new IHIS.Framework.XTextBox();
            this.hangmogNameTextBox = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnClose = new IHIS.Framework.XButton();
            this.btnSave = new IHIS.Framework.XButton();
            this.btnBrowse = new IHIS.Framework.XButton();
            this.xProgressBar = new IHIS.Framework.XProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.grdList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24});
            this.grdList.ColPerLine = 24;
            this.grdList.Cols = 24;
            this.grdList.ExecuteQuery = null;
            this.grdList.FixedRows = 1;
            this.grdList.HeaderHeights.Add(21);
            this.grdList.Location = new System.Drawing.Point(23, 65);
            this.grdList.Name = "grdList";
            this.grdList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdList.ParamList")));
            this.grdList.Rows = 2;
            this.grdList.Size = new System.Drawing.Size(915, 472);
            this.grdList.TabIndex = 0;
            this.grdList.ToolTipActive = true;
            this.grdList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "hotcodeCol";
            this.xEditGridCell1.CellWidth = 133;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderText = "基準番号（ＨＯＴコード）";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hotcode7Col";
            this.xEditGridCell2.CellWidth = 129;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderText = "処方用番号（ＨＯＴ７）";
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "cinCodeCol";
            this.xEditGridCell3.CellWidth = 102;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderText = "会社識別用番号";
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "dispenseCodeCol";
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderText = "調剤用番号";
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "logisticCodeCol";
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderText = "物流用番号";
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "janCodeCol";
            this.xEditGridCell6.CellWidth = 76;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderText = "ＪＡＮコード";
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "yakKijunCodeCol";
            this.xEditGridCell7.CellWidth = 168;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderText = "薬価基準収載医薬品コード";
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "yjCodeCol";
            this.xEditGridCell8.CellWidth = 103;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderText = "個別医薬品コード";
            this.xEditGridCell8.IsReadOnly = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "sgCodeCol";
            this.xEditGridCell9.CellWidth = 202;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderText = "レセプト電算処理システムコード（１）";
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "sgCode1Col";
            this.xEditGridCell10.CellWidth = 199;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderText = "レセプト電算処理システムコード（２）";
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "hangmogNameCol";
            this.xEditGridCell11.CellWidth = 63;
            this.xEditGridCell11.Col = 10;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderText = "告示名称";
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "hangmogName1Col";
            this.xEditGridCell12.CellWidth = 51;
            this.xEditGridCell12.Col = 11;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderText = "販売名";
            this.xEditGridCell12.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "hangmogName2Col";
            this.xEditGridCell13.CellWidth = 200;
            this.xEditGridCell13.Col = 12;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderText = "レセプト電算処理システム医薬品名";
            this.xEditGridCell13.IsReadOnly = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "standardUnitCol";
            this.xEditGridCell14.CellWidth = 59;
            this.xEditGridCell14.Col = 13;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderText = "規格単位";
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "pkgStatusCol";
            this.xEditGridCell15.CellWidth = 61;
            this.xEditGridCell15.Col = 14;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderText = "包装形態";
            this.xEditGridCell15.IsReadOnly = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "pkgNumUnitCol";
            this.xEditGridCell16.Col = 15;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderText = "包装単位数";
            this.xEditGridCell16.IsReadOnly = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "ordDanuiCol";
            this.xEditGridCell17.CellWidth = 87;
            this.xEditGridCell17.Col = 16;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderText = "包装単位単位";
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pkgTotalCol";
            this.xEditGridCell18.CellWidth = 67;
            this.xEditGridCell18.Col = 17;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderText = "包装総量数";
            this.xEditGridCell18.IsReadOnly = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "pkgTotalUnitCol";
            this.xEditGridCell19.CellWidth = 87;
            this.xEditGridCell19.Col = 18;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderText = "包装総量単位";
            this.xEditGridCell19.IsReadOnly = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "classifCol";
            this.xEditGridCell20.CellWidth = 35;
            this.xEditGridCell20.Col = 19;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderText = "区分";
            this.xEditGridCell20.IsReadOnly = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "manufCompCol";
            this.xEditGridCell21.CellWidth = 64;
            this.xEditGridCell21.Col = 20;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderText = "製造会社";
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "salesCompCol";
            this.xEditGridCell22.CellWidth = 62;
            this.xEditGridCell22.Col = 21;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderText = "販売会社";
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "classifUpdCol";
            this.xEditGridCell23.CellWidth = 69;
            this.xEditGridCell23.Col = 22;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderText = "更新区分";
            this.xEditGridCell23.IsReadOnly = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "sgYmdCol";
            this.xEditGridCell24.Col = 23;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderText = "更新年月日";
            this.xEditGridCell24.IsReadOnly = true;
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(20, 27);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(143, 20);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "基準番号（ＨＯＴコード）";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(620, 549);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "検索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // hotCodeTextBox
            // 
            this.hotCodeTextBox.Location = new System.Drawing.Point(168, 27);
            this.hotCodeTextBox.Name = "hotCodeTextBox";
            this.hotCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.hotCodeTextBox.TabIndex = 4;
            // 
            // hangmogNameTextBox
            // 
            this.hangmogNameTextBox.Location = new System.Drawing.Point(385, 27);
            this.hangmogNameTextBox.Name = "hangmogNameTextBox";
            this.hangmogNameTextBox.Size = new System.Drawing.Size(182, 20);
            this.hangmogNameTextBox.TabIndex = 6;
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(308, 27);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(71, 20);
            this.xLabel2.TabIndex = 5;
            this.xLabel2.Text = "氏名(漢字)";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(863, 549);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "編集";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(782, 549);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(701, 549);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = "ブラウズ";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // xProgressBar
            // 
            this.xProgressBar.BackColor = IHIS.Framework.XColor.XProgressBarTextColor;
            this.xProgressBar.Location = new System.Drawing.Point(23, 549);
            this.xProgressBar.Name = "xProgressBar";
            this.xProgressBar.Size = new System.Drawing.Size(564, 29);
            this.xProgressBar.StepWidth = 5;
            this.xProgressBar.TabIndex = 11;
            this.xProgressBar.TextShadowAlpha = 255;
            this.xProgressBar.Visible = false;
            // 
            // HOTCODEMASTER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xProgressBar);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.hangmogNameTextBox);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.hotCodeTextBox);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.grdList);
            this.Name = "HOTCODEMASTER";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.HOTCODEMASTER_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IHIS.Framework.XEditGrid grdList;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XButton btnSearch;
        private IHIS.Framework.XTextBox hotCodeTextBox;
        private IHIS.Framework.XTextBox hangmogNameTextBox;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XButton btnClose;
        private IHIS.Framework.XButton btnSave;
        private IHIS.Framework.XButton btnBrowse;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XProgressBar xProgressBar;
    }
}
