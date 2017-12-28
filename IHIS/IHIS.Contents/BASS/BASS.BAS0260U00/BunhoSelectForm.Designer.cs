namespace IHIS.BASS
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
            this.xGridCell3 = new IHIS.Framework.XEditGridCell();
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
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboBuseoGubun = new IHIS.Framework.XDictComboBox();
            this.xTextBoxGwaName = new IHIS.Framework.XTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnSelect = new IHIS.Framework.XButton();
            this.btnQuery = new IHIS.Framework.XButton();
            this.btnClose = new IHIS.Framework.XButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdPAList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdPAList
            // 
            resources.ApplyResources(this.grdPAList, "grdPAList");
            this.grdPAList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell3,
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
            this.xEditGridCell12});
            this.grdPAList.ColPerLine = 2;
            this.grdPAList.Cols = 3;
            this.grdPAList.ExecuteQuery = null;
            this.grdPAList.FixedCols = 1;
            this.grdPAList.FixedRows = 1;
            this.grdPAList.HeaderHeights.Add(21);
            this.grdPAList.Name = "grdPAList";
            this.grdPAList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPAList.ParamList")));
            this.grdPAList.RowHeaderVisible = true;
            this.grdPAList.Rows = 2;
            this.grdPAList.ToolTipActive = true;
            this.grdPAList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPAList_MouseDown);
            this.grdPAList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPAList_QueryStarting);
            // 
            // xGridCell3
            // 
            this.xGridCell3.CellName = "BUSEO_CODE";
            this.xGridCell3.CellWidth = 60;
            this.xGridCell3.Col = -1;
            this.xGridCell3.EnableSort = true;
            this.xGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xGridCell3, "xGridCell3");
            this.xGridCell3.IsReadOnly = true;
            this.xGridCell3.IsVisible = false;
            this.xGridCell3.Row = -1;
            this.xGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "BUSEO_NAME";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "BUSEO_NAME2";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "BUSEO_GUBUN";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "PARENT_BUSEO";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "GWA";
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "GWA_NAME";
            this.xEditGridCell6.CellWidth = 304;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsUpdCol = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "GWA_NAME2";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "GWA_GUBUN";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "PARENT_GWA";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "NOTE";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "LANGUAGE";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ACTIVE_FLG";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.cboBuseoGubun);
            this.xPanel1.Controls.Add(this.xTextBoxGwaName);
            this.xPanel1.Controls.Add(this.label2);
            this.xPanel1.Controls.Add(this.label1);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.Controls.Add(this.grdPAList);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // cboBuseoGubun
            // 
            this.cboBuseoGubun.AccessibleDescription = null;
            this.cboBuseoGubun.AccessibleName = null;
            resources.ApplyResources(this.cboBuseoGubun, "cboBuseoGubun");
            this.cboBuseoGubun.BackgroundImage = null;
            this.cboBuseoGubun.ExecuteQuery = null;
            this.cboBuseoGubun.Name = "cboBuseoGubun";
            this.cboBuseoGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboBuseoGubun.ParamList")));
            this.cboBuseoGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboBuseoGubun.UserSQL = "SELECT A.GWA, A.GWA_NAME\r\n  FROM BAS0260 A\r\nWHERE A.BUSEO_GUBUN = \'1\'\r\n  AND A.EN" +
                "D_DATE = TO_DATE(\'9998/12/31\', \'YYYY/MM/DD\')\r\n  AND A.OUT_JUBSU_YN = \'Y\'\r\nORDER " +
                "BY A.GWA";
            this.cboBuseoGubun.SelectedValueChanged += new System.EventHandler(this.cboBuseoGubun_SelectedValueChanged);
            // 
            // xTextBoxGwaName
            // 
            this.xTextBoxGwaName.AccessibleDescription = null;
            this.xTextBoxGwaName.AccessibleName = null;
            resources.ApplyResources(this.xTextBoxGwaName, "xTextBoxGwaName");
            this.xTextBoxGwaName.BackgroundImage = null;
            this.xTextBoxGwaName.Name = "xTextBoxGwaName";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnSelect);
            this.xPanel3.Controls.Add(this.btnQuery);
            this.xPanel3.Controls.Add(this.btnClose);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleDescription = null;
            this.btnSelect.AccessibleName = null;
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.BackgroundImage = null;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleDescription = null;
            this.btnQuery.AccessibleName = null;
            resources.ApplyResources(this.btnQuery, "btnQuery");
            this.btnQuery.BackgroundImage = null;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.BackgroundImage = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.AcceptButton = this.btnQuery;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BunhoSelectForm";
            this.Load += new System.EventHandler(this.BunhoSelectForm_Load);
            this.Controls.SetChildIndex(this.xPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdPAList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
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
        private IHIS.Framework.XEditGrid grdPAList;
        private IHIS.Framework.XEditGridCell xGridCell3;
        private IHIS.Framework.XPanel xPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private IHIS.Framework.XTextBox xTextBoxGwaName;
        private IHIS.Framework.XDictComboBox cboBuseoGubun;
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
    }
}