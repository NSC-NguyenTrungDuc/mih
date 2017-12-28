namespace IHIS.OCSO
{
    partial class OCS1003Q07
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003Q07));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboGwa = new IHIS.Framework.XDictComboBox();
            this.rbnIn = new IHIS.Framework.XRadioButton();
            this.rbnOut = new IHIS.Framework.XRadioButton();
            this.rbnAll = new IHIS.Framework.XRadioButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.tabOrderGubun = new IHIS.Framework.XTabControl();
            this.tpgAll = new IHIS.X.Magic.Controls.TabPage();
            this.tpgDrg = new IHIS.X.Magic.Controls.TabPage();
            this.tpgGumsa = new IHIS.X.Magic.Controls.TabPage();
            this.tpgChuchi = new IHIS.X.Magic.Controls.TabPage();
            this.calOrder = new IHIS.Framework.XCalendar();
            this.layNaewonList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderHistory = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.tabOrderGubun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNaewonList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "선택.ICO");
            this.ImageList.Images.SetKeyName(1, "미선택.ICO");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(993, 36);
            this.xPanel1.TabIndex = 0;
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.Location = new System.Drawing.Point(0, 0);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(993, 32);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel2.BackgroundImage")));
            this.xPanel2.Controls.Add(this.cboGwa);
            this.xPanel2.Controls.Add(this.rbnIn);
            this.xPanel2.Controls.Add(this.rbnOut);
            this.xPanel2.Controls.Add(this.rbnAll);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(0, 36);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(993, 36);
            this.xPanel2.TabIndex = 1;
            // 
            // cboGwa
            // 
            this.cboGwa.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGwa.Location = new System.Drawing.Point(852, 5);
            this.cboGwa.Name = "cboGwa";
            this.cboGwa.Size = new System.Drawing.Size(130, 27);
            this.cboGwa.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGwa.TabIndex = 3;
            this.cboGwa.UserSQL = resources.GetString("cboGwa.UserSQL");
            this.cboGwa.SelectedValueChanged += new System.EventHandler(this.cboGwa_SelectedValueChanged);
            // 
            // rbnIn
            // 
            this.rbnIn.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnIn.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnIn.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnIn.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnIn.ImageIndex = 1;
            this.rbnIn.ImageList = this.ImageList;
            this.rbnIn.Location = new System.Drawing.Point(230, 2);
            this.rbnIn.Name = "rbnIn";
            this.rbnIn.Size = new System.Drawing.Size(111, 31);
            this.rbnIn.TabIndex = 2;
            this.rbnIn.TabStop = true;
            this.rbnIn.Tag = "I";
            this.rbnIn.Text = "入院";
            this.rbnIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnIn.UseVisualStyleBackColor = false;
            this.rbnIn.CheckedChanged += new System.EventHandler(this.rbnIoGubun_CheckedChanged);
            // 
            // rbnOut
            // 
            this.rbnOut.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnOut.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnOut.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnOut.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnOut.ImageIndex = 1;
            this.rbnOut.ImageList = this.ImageList;
            this.rbnOut.Location = new System.Drawing.Point(118, 2);
            this.rbnOut.Name = "rbnOut";
            this.rbnOut.Size = new System.Drawing.Size(111, 31);
            this.rbnOut.TabIndex = 1;
            this.rbnOut.TabStop = true;
            this.rbnOut.Tag = "O";
            this.rbnOut.Text = "外来";
            this.rbnOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnOut.UseVisualStyleBackColor = false;
            this.rbnOut.CheckedChanged += new System.EventHandler(this.rbnIoGubun_CheckedChanged);
            // 
            // rbnAll
            // 
            this.rbnAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbnAll.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbnAll.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnAll.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbnAll.ImageIndex = 1;
            this.rbnAll.ImageList = this.ImageList;
            this.rbnAll.Location = new System.Drawing.Point(6, 2);
            this.rbnAll.Name = "rbnAll";
            this.rbnAll.Size = new System.Drawing.Size(111, 31);
            this.rbnAll.TabIndex = 0;
            this.rbnAll.TabStop = true;
            this.rbnAll.Tag = "%";
            this.rbnAll.Text = "全体";
            this.rbnAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbnAll.UseVisualStyleBackColor = false;
            this.rbnAll.CheckedChanged += new System.EventHandler(this.rbnIoGubun_CheckedChanged);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.tabOrderGubun);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.Location = new System.Drawing.Point(0, 72);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(993, 26);
            this.xPanel3.TabIndex = 2;
            // 
            // tabOrderGubun
            // 
            this.tabOrderGubun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOrderGubun.IDEPixelArea = true;
            this.tabOrderGubun.IDEPixelBorder = false;
            this.tabOrderGubun.Location = new System.Drawing.Point(0, 0);
            this.tabOrderGubun.Name = "tabOrderGubun";
            this.tabOrderGubun.SelectedIndex = 0;
            this.tabOrderGubun.SelectedTab = this.tpgAll;
            this.tabOrderGubun.Size = new System.Drawing.Size(993, 26);
            this.tabOrderGubun.TabIndex = 0;
            this.tabOrderGubun.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tpgAll,
            this.tpgDrg,
            this.tpgGumsa,
            this.tpgChuchi});
            this.tabOrderGubun.SelectionChanged += new System.EventHandler(this.tabOrderGubun_SelectionChanged);
            // 
            // tpgAll
            // 
            this.tpgAll.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpgAll.ImageIndex = 0;
            this.tpgAll.ImageList = this.ImageList;
            this.tpgAll.Location = new System.Drawing.Point(0, 25);
            this.tpgAll.Name = "tpgAll";
            this.tpgAll.Size = new System.Drawing.Size(993, 1);
            this.tpgAll.TabIndex = 3;
            this.tpgAll.Tag = "%";
            this.tpgAll.Title = "全体";
            // 
            // tpgDrg
            // 
            this.tpgDrg.ImageIndex = 1;
            this.tpgDrg.ImageList = this.ImageList;
            this.tpgDrg.Location = new System.Drawing.Point(0, 25);
            this.tpgDrg.Name = "tpgDrg";
            this.tpgDrg.Selected = false;
            this.tpgDrg.Size = new System.Drawing.Size(993, 1);
            this.tpgDrg.TabIndex = 4;
            this.tpgDrg.Tag = "1";
            this.tpgDrg.Title = "薬・注射";
            // 
            // tpgGumsa
            // 
            this.tpgGumsa.ImageIndex = 1;
            this.tpgGumsa.ImageList = this.ImageList;
            this.tpgGumsa.Location = new System.Drawing.Point(0, 25);
            this.tpgGumsa.Name = "tpgGumsa";
            this.tpgGumsa.Selected = false;
            this.tpgGumsa.Size = new System.Drawing.Size(993, 1);
            this.tpgGumsa.TabIndex = 5;
            this.tpgGumsa.Tag = "2";
            this.tpgGumsa.Title = "検査";
            // 
            // tpgChuchi
            // 
            this.tpgChuchi.ImageIndex = 1;
            this.tpgChuchi.ImageList = this.ImageList;
            this.tpgChuchi.Location = new System.Drawing.Point(0, 25);
            this.tpgChuchi.Name = "tpgChuchi";
            this.tpgChuchi.Selected = false;
            this.tpgChuchi.Size = new System.Drawing.Size(993, 1);
            this.tpgChuchi.TabIndex = 6;
            this.tpgChuchi.Tag = "3";
            this.tpgChuchi.Title = "処置・手術";
            // 
            // calOrder
            // 
            this.calOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calOrder.EnableMultiSelection = false;
            this.calOrder.Footer.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calOrder.FullHolidaySelectable = true;
            this.calOrder.Header.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calOrder.IsJapanYearType = true;
            this.calOrder.Location = new System.Drawing.Point(0, 98);
            this.calOrder.MaxDate = new System.DateTime(2021, 1, 20, 0, 0, 0, 0);
            this.calOrder.MinDate = new System.DateTime(2001, 1, 20, 0, 0, 0, 0);
            this.calOrder.Name = "calOrder";
            this.calOrder.Size = new System.Drawing.Size(993, 594);
            this.calOrder.TabIndex = 3;
            this.calOrder.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.calOrder_MonthChanged);
            // 
            // layNaewonList
            // 
            this.layNaewonList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layNaewonList.QuerySQL = resources.GetString("layNaewonList.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "io_gubun";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "bunho";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "naewon_date";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "gwa";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "gwa_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "cnt";
            this.multiLayoutItem6.DataType = IHIS.Framework.DataType.Number;
            // 
            // layOrderHistory
            // 
            this.layOrderHistory.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            this.layOrderHistory.QuerySQL = resources.GetString("layOrderHistory.QuerySQL");
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "order_gubun";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "acting_date";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "order_gubun_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "gwa";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "gwa_name";
            // 
            // OCS1003Q07
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calOrder);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS1003Q07";
            this.Size = new System.Drawing.Size(993, 692);
            this.Load += new System.EventHandler(this.OCS1003Q07_Load);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.tabOrderGubun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNaewonList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XTabControl tabOrderGubun;
        private IHIS.Framework.XCalendar calOrder;
        private IHIS.Framework.XRadioButton rbnIn;
        private IHIS.Framework.XRadioButton rbnOut;
        private IHIS.Framework.XRadioButton rbnAll;
        private IHIS.X.Magic.Controls.TabPage tpgAll;
        private IHIS.X.Magic.Controls.TabPage tpgDrg;
        private IHIS.X.Magic.Controls.TabPage tpgGumsa;
        private IHIS.X.Magic.Controls.TabPage tpgChuchi;
        private IHIS.Framework.MultiLayout layNaewonList;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
        private IHIS.Framework.MultiLayout layOrderHistory;
        private IHIS.Framework.XDictComboBox cboGwa;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem8;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
    }
}
