namespace IHIS.NURI
{
    partial class OCS2005R02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2005R02));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.cboKiGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpQryDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dwPrint = new IHIS.Framework.XDataWindow();
            this.layData = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layData)).BeginInit();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.fbxBunho);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.cboKiGubun);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpQryDate);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(565, 41);
            this.xPanel1.TabIndex = 1;
            // 
            // fbxBunho
            // 
            this.fbxBunho.Location = new System.Drawing.Point(461, 10);
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Size = new System.Drawing.Size(100, 20);
            this.fbxBunho.TabIndex = 5;
            // 
            // xLabel3
            // 
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Location = new System.Drawing.Point(373, 10);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(88, 20);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "患者番号";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboKiGubun
            // 
            this.cboKiGubun.Location = new System.Drawing.Point(297, 10);
            this.cboKiGubun.Name = "cboKiGubun";
            this.cboKiGubun.Size = new System.Drawing.Size(67, 21);
            this.cboKiGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboKiGubun.TabIndex = 3;
            this.cboKiGubun.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM OCS0132\r\nWHERE CODE_TYPE = \'KI_GUBUN\'\r\nORDER BY SORT" +
                "_KEY";
            // 
            // xLabel2
            // 
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Location = new System.Drawing.Point(209, 10);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(88, 20);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "食事区分";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpQryDate
            // 
            this.dtpQryDate.Location = new System.Drawing.Point(95, 10);
            this.dtpQryDate.Name = "dtpQryDate";
            this.dtpQryDate.Size = new System.Drawing.Size(104, 20);
            this.dtpQryDate.TabIndex = 1;
            this.dtpQryDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel1
            // 
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(6, 10);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(88, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "照会日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.Location = new System.Drawing.Point(0, 781);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(565, 40);
            this.xPanel2.TabIndex = 2;
            // 
            // btnList
            // 
            this.btnList.IsVisiblePreview = false;
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(317, 4);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Report;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dwPrint
            // 
            this.dwPrint.DataWindowObject = "ocs2005r02";
            this.dwPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwPrint.LibraryList = "..\\NURI\\nuri.ocs2005r02.pbd";
            this.dwPrint.Location = new System.Drawing.Point(0, 41);
            this.dwPrint.Name = "dwPrint";
            this.dwPrint.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Both;
            this.dwPrint.Size = new System.Drawing.Size(565, 740);
            this.dwPrint.TabIndex = 3;
            this.dwPrint.Text = "xDataWindow1";
            // 
            // layData
            // 
            this.layData.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem47,
            this.multiLayoutItem49});
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "fkinp1001";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suname2";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "birth";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "age";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "sex";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "height";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "weight";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "ipwon_date";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gwa";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "gwa_name";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "ho_dong";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "ho_dong_name";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "ho_code";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "sik_gubun";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "jusik";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "busik";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "drt_from_date";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "drt_to_date";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "order_date";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "sang_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "jori_type";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "kumjisik";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "direct_text";
            // 
            // OCS2005R02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dwPrint);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS2005R02";
            this.Size = new System.Drawing.Size(565, 821);
            this.Load += new System.EventHandler(this.OCS2005R02_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XFindBox fbxBunho;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XDictComboBox cboKiGubun;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDatePicker dtpQryDate;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XDataWindow dwPrint;
        private IHIS.Framework.MultiLayout layData;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem8;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem13;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem14;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem15;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem16;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem17;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem18;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem19;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem20;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem41;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem42;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem43;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem47;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem49;
    }
}
