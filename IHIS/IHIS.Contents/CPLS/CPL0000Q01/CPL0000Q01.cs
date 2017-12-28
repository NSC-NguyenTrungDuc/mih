#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0000Q01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0000Q01 : IHIS.Framework.XScreen
    {
        private XLabel xLabel1;
        private XTextBox txtKrn;
        private XTextBox txtKrt;
        private XLabel xLabel2;
        private XTextBox txtPwd;
        private XLabel xLabel3;
        private XTextBox txtXid;
        private XLabel xLabel4;
        private XLabel xLabel5;
        private XLabel xLabel6;
        private XLabel xLabel7;
        private XLabel xLabel8;
        private XLabel xLabel9;
        private XLabel xLabel10;
        private XLabel xLabel11;
        private XLabel xLabel12;
        private XLabel xLabel13;
        private XLabel xLabel14;
        private XLabel xLabel15;
        private XLabel xLabel16;
        private XLabel xLabel17;
        private XLabel xLabel18;
        private XDatePicker dtpFromOrderDate;
        private XDatePicker dtpToOrderDate;
        private XDatePicker dtpToJubsuDate;
        private XDatePicker dtpFromJubsuDate;
        private XDatePicker dtpToResultDate;
        private XDatePicker dtpFromResultDate;
        private XLabel xLabel19;
        private XLabel xLabel20;
        private XComboBox cboSrt1;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboBox cboSrt2;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XComboItem xComboItem9;
        private XButton btnSendUrl;
        private XTextBox txtServerIP;
        private XLabel xLabel21;
        private XRichTextBox txtSettingURL;
        private XComboItem xComboItem10;
        private XComboItem xComboItem11;
        private XPanel xPanel1;
        private XButton btnSettingUrl;
        private XEditGridCell xEditGridCell7;
        private XPatientBox paBox;
        private XPanel xPanel2;
        private XPanel xPanel3;
        private XFindBox fbxIT10;
        private XFindBox fbxIT9;
        private XFindBox fbxIT8;
        private XFindBox fbxIT7;
        private XFindBox fbxIT6;
        private XFindBox fbxIT5;
        private XFindBox fbxIT4;
        private XFindBox fbxIT3;
        private XFindBox fbxIT2;
        private XFindBox fbxIT1;
        private XDisplayBox dbxIT10;
        private XDisplayBox dbxIT9;
        private XDisplayBox dbxIT8;
        private XDisplayBox dbxIT7;
        private XDisplayBox dbxIT6;
        private XDisplayBox dbxIT5;
        private XDisplayBox dbxIT4;
        private XDisplayBox dbxIT3;
        private XDisplayBox dbxIT2;
        private XDisplayBox dbxIT1;
        private XFindWorker fwkHangmogCode;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private SingleLayout layBmlUrlInfo;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private XButton btnClose;
        private XLabel xLabel22;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CPL0000Q01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0000Q01));
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtKrn = new IHIS.Framework.XTextBox();
            this.txtKrt = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtPwd = new IHIS.Framework.XTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtXid = new IHIS.Framework.XTextBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.dtpFromOrderDate = new IHIS.Framework.XDatePicker();
            this.dtpToOrderDate = new IHIS.Framework.XDatePicker();
            this.dtpToJubsuDate = new IHIS.Framework.XDatePicker();
            this.dtpFromJubsuDate = new IHIS.Framework.XDatePicker();
            this.dtpToResultDate = new IHIS.Framework.XDatePicker();
            this.dtpFromResultDate = new IHIS.Framework.XDatePicker();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.cboSrt1 = new IHIS.Framework.XComboBox();
            this.xComboItem10 = new IHIS.Framework.XComboItem();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.cboSrt2 = new IHIS.Framework.XComboBox();
            this.xComboItem11 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.btnSendUrl = new IHIS.Framework.XButton();
            this.txtServerIP = new IHIS.Framework.XTextBox();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.txtSettingURL = new IHIS.Framework.XRichTextBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.fbxIT10 = new IHIS.Framework.XFindBox();
            this.fwkHangmogCode = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.fbxIT9 = new IHIS.Framework.XFindBox();
            this.fbxIT8 = new IHIS.Framework.XFindBox();
            this.fbxIT7 = new IHIS.Framework.XFindBox();
            this.fbxIT6 = new IHIS.Framework.XFindBox();
            this.fbxIT5 = new IHIS.Framework.XFindBox();
            this.fbxIT4 = new IHIS.Framework.XFindBox();
            this.fbxIT3 = new IHIS.Framework.XFindBox();
            this.fbxIT2 = new IHIS.Framework.XFindBox();
            this.fbxIT1 = new IHIS.Framework.XFindBox();
            this.dbxIT10 = new IHIS.Framework.XDisplayBox();
            this.dbxIT9 = new IHIS.Framework.XDisplayBox();
            this.dbxIT8 = new IHIS.Framework.XDisplayBox();
            this.dbxIT7 = new IHIS.Framework.XDisplayBox();
            this.dbxIT6 = new IHIS.Framework.XDisplayBox();
            this.dbxIT5 = new IHIS.Framework.XDisplayBox();
            this.dbxIT4 = new IHIS.Framework.XDisplayBox();
            this.dbxIT3 = new IHIS.Framework.XDisplayBox();
            this.dbxIT2 = new IHIS.Framework.XDisplayBox();
            this.dbxIT1 = new IHIS.Framework.XDisplayBox();
            this.btnSettingUrl = new IHIS.Framework.XButton();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnClose = new IHIS.Framework.XButton();
            this.layBmlUrlInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel1.Location = new System.Drawing.Point(9, 69);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(100, 20);
            this.xLabel1.TabIndex = 15;
            this.xLabel1.Text = "氏名";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKrn
            // 
            this.txtKrn.Location = new System.Drawing.Point(115, 69);
            this.txtKrn.Name = "txtKrn";
            this.txtKrn.Size = new System.Drawing.Size(100, 20);
            this.txtKrn.TabIndex = 2;
            this.txtKrn.Tag = "krn";
            // 
            // txtKrt
            // 
            this.txtKrt.Location = new System.Drawing.Point(115, 98);
            this.txtKrt.Name = "txtKrt";
            this.txtKrt.Size = new System.Drawing.Size(100, 20);
            this.txtKrt.TabIndex = 3;
            this.txtKrt.Tag = "krt";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel2.Location = new System.Drawing.Point(9, 98);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(100, 20);
            this.xLabel2.TabIndex = 17;
            this.xLabel2.Text = "ｶﾙﾃNO";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(115, 40);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 20);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.Tag = "pwd";
            this.txtPwd.Text = "LC";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel3.Location = new System.Drawing.Point(9, 40);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(100, 20);
            this.xLabel3.TabIndex = 21;
            this.xLabel3.Text = "パスワード";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtXid
            // 
            this.txtXid.Location = new System.Drawing.Point(115, 11);
            this.txtXid.Name = "txtXid";
            this.txtXid.Size = new System.Drawing.Size(100, 20);
            this.txtXid.TabIndex = 0;
            this.txtXid.Tag = "xid";
            this.txtXid.Text = "BML";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel4.Location = new System.Drawing.Point(9, 11);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(100, 20);
            this.xLabel4.TabIndex = 19;
            this.xLabel4.Text = "ユーザーＩＤ";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel5
            // 
            this.xLabel5.BackColor = IHIS.Framework.XColor.XListBoxAlternatingItemBackColor;
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel5.Image = ((System.Drawing.Image)(resources.GetObject("xLabel5.Image")));
            this.xLabel5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel5.Location = new System.Drawing.Point(9, 7);
            this.xLabel5.Name = "xLabel5";
            this.xLabel5.Size = new System.Drawing.Size(100, 20);
            this.xLabel5.TabIndex = 23;
            this.xLabel5.Text = "患者ID";
            this.xLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel6.Location = new System.Drawing.Point(446, 127);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(100, 20);
            this.xLabel6.TabIndex = 33;
            this.xLabel6.Text = "項目ｺｰﾄﾞ５";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel7.Location = new System.Drawing.Point(446, 40);
            this.xLabel7.Name = "xLabel7";
            this.xLabel7.Size = new System.Drawing.Size(100, 20);
            this.xLabel7.TabIndex = 31;
            this.xLabel7.Text = "項目ｺｰﾄﾞ２";
            this.xLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel8
            // 
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel8.Location = new System.Drawing.Point(446, 11);
            this.xLabel8.Name = "xLabel8";
            this.xLabel8.Size = new System.Drawing.Size(100, 20);
            this.xLabel8.TabIndex = 29;
            this.xLabel8.Text = "項目ｺｰﾄﾞ１";
            this.xLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel9.Location = new System.Drawing.Point(446, 98);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(100, 20);
            this.xLabel9.TabIndex = 27;
            this.xLabel9.Text = "項目ｺｰﾄﾞ４";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel10.Location = new System.Drawing.Point(446, 69);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(100, 20);
            this.xLabel10.TabIndex = 25;
            this.xLabel10.Text = "項目ｺｰﾄﾞ３";
            this.xLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel11.Location = new System.Drawing.Point(446, 272);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(100, 20);
            this.xLabel11.TabIndex = 43;
            this.xLabel11.Text = "項目ｺｰﾄﾞ１０";
            this.xLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel12.Location = new System.Drawing.Point(446, 185);
            this.xLabel12.Name = "xLabel12";
            this.xLabel12.Size = new System.Drawing.Size(100, 20);
            this.xLabel12.TabIndex = 41;
            this.xLabel12.Text = "項目ｺｰﾄﾞ７";
            this.xLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel13.Location = new System.Drawing.Point(446, 156);
            this.xLabel13.Name = "xLabel13";
            this.xLabel13.Size = new System.Drawing.Size(100, 20);
            this.xLabel13.TabIndex = 39;
            this.xLabel13.Text = "項目ｺｰﾄﾞ６";
            this.xLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel14.Location = new System.Drawing.Point(446, 243);
            this.xLabel14.Name = "xLabel14";
            this.xLabel14.Size = new System.Drawing.Size(100, 20);
            this.xLabel14.TabIndex = 37;
            this.xLabel14.Text = "項目ｺｰﾄﾞ９";
            this.xLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel15
            // 
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel15.Location = new System.Drawing.Point(446, 214);
            this.xLabel15.Name = "xLabel15";
            this.xLabel15.Size = new System.Drawing.Size(100, 20);
            this.xLabel15.TabIndex = 35;
            this.xLabel15.Text = "項目ｺｰﾄﾞ８";
            this.xLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel16.Location = new System.Drawing.Point(227, 69);
            this.xLabel16.Name = "xLabel16";
            this.xLabel16.Size = new System.Drawing.Size(100, 20);
            this.xLabel16.TabIndex = 47;
            this.xLabel16.Text = "採取日";
            this.xLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel17
            // 
            this.xLabel17.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel17.Location = new System.Drawing.Point(227, 11);
            this.xLabel17.Name = "xLabel17";
            this.xLabel17.Size = new System.Drawing.Size(100, 20);
            this.xLabel17.TabIndex = 46;
            this.xLabel17.Text = "依頼日";
            this.xLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel18
            // 
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel18.Location = new System.Drawing.Point(227, 127);
            this.xLabel18.Name = "xLabel18";
            this.xLabel18.Size = new System.Drawing.Size(100, 20);
            this.xLabel18.TabIndex = 45;
            this.xLabel18.Text = "報告日";
            this.xLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFromOrderDate
            // 
            this.dtpFromOrderDate.Location = new System.Drawing.Point(333, 11);
            this.dtpFromOrderDate.Name = "dtpFromOrderDate";
            this.dtpFromOrderDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFromOrderDate.TabIndex = 7;
            this.dtpFromOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpToOrderDate
            // 
            this.dtpToOrderDate.Location = new System.Drawing.Point(333, 37);
            this.dtpToOrderDate.Name = "dtpToOrderDate";
            this.dtpToOrderDate.Size = new System.Drawing.Size(100, 20);
            this.dtpToOrderDate.TabIndex = 8;
            this.dtpToOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpToJubsuDate
            // 
            this.dtpToJubsuDate.Location = new System.Drawing.Point(333, 95);
            this.dtpToJubsuDate.Name = "dtpToJubsuDate";
            this.dtpToJubsuDate.Size = new System.Drawing.Size(100, 20);
            this.dtpToJubsuDate.TabIndex = 10;
            this.dtpToJubsuDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFromJubsuDate
            // 
            this.dtpFromJubsuDate.Location = new System.Drawing.Point(333, 69);
            this.dtpFromJubsuDate.Name = "dtpFromJubsuDate";
            this.dtpFromJubsuDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFromJubsuDate.TabIndex = 9;
            this.dtpFromJubsuDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpToResultDate
            // 
            this.dtpToResultDate.Location = new System.Drawing.Point(333, 153);
            this.dtpToResultDate.Name = "dtpToResultDate";
            this.dtpToResultDate.Size = new System.Drawing.Size(100, 20);
            this.dtpToResultDate.TabIndex = 12;
            this.dtpToResultDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFromResultDate
            // 
            this.dtpFromResultDate.Location = new System.Drawing.Point(333, 127);
            this.dtpFromResultDate.Name = "dtpFromResultDate";
            this.dtpFromResultDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFromResultDate.TabIndex = 11;
            this.dtpFromResultDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel19
            // 
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel19.Location = new System.Drawing.Point(9, 157);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(100, 20);
            this.xLabel19.TabIndex = 55;
            this.xLabel19.Text = "並び順１桁目";
            this.xLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel20
            // 
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel20.Location = new System.Drawing.Point(9, 186);
            this.xLabel20.Name = "xLabel20";
            this.xLabel20.Size = new System.Drawing.Size(100, 20);
            this.xLabel20.TabIndex = 54;
            this.xLabel20.Text = "並び順２桁目";
            this.xLabel20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSrt1
            // 
            this.cboSrt1.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem10,
            this.xComboItem1,
            this.xComboItem2});
            this.cboSrt1.Location = new System.Drawing.Point(115, 156);
            this.cboSrt1.Name = "cboSrt1";
            this.cboSrt1.Size = new System.Drawing.Size(100, 21);
            this.cboSrt1.TabIndex = 5;
            // 
            // xComboItem10
            // 
            this.xComboItem10.DisplayItem = "なし";
            this.xComboItem10.ValueItem = "000";
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "昇順";
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "降順";
            this.xComboItem2.ValueItem = "2";
            // 
            // cboSrt2
            // 
            this.cboSrt2.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem11,
            this.xComboItem3,
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8,
            this.xComboItem9});
            this.cboSrt2.Location = new System.Drawing.Point(115, 185);
            this.cboSrt2.Name = "cboSrt2";
            this.cboSrt2.Size = new System.Drawing.Size(100, 21);
            this.cboSrt2.TabIndex = 6;
            // 
            // xComboItem11
            // 
            this.xComboItem11.DisplayItem = "なし";
            this.xComboItem11.ValueItem = "000";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "日付";
            this.xComboItem3.ValueItem = "1";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "ｶﾙﾃNO";
            this.xComboItem4.ValueItem = "2";
            // 
            // xComboItem5
            // 
            this.xComboItem5.DisplayItem = "患者ID";
            this.xComboItem5.ValueItem = "3";
            // 
            // xComboItem6
            // 
            this.xComboItem6.DisplayItem = "氏名";
            this.xComboItem6.ValueItem = "4";
            // 
            // xComboItem7
            // 
            this.xComboItem7.DisplayItem = "診療科";
            this.xComboItem7.ValueItem = "5";
            // 
            // xComboItem8
            // 
            this.xComboItem8.DisplayItem = "病棟";
            this.xComboItem8.ValueItem = "6";
            // 
            // xComboItem9
            // 
            this.xComboItem9.DisplayItem = "医師";
            this.xComboItem9.ValueItem = "7";
            // 
            // btnSendUrl
            // 
            this.btnSendUrl.Image = ((System.Drawing.Image)(resources.GetObject("btnSendUrl.Image")));
            this.btnSendUrl.Location = new System.Drawing.Point(605, 2);
            this.btnSendUrl.Name = "btnSendUrl";
            this.btnSendUrl.Size = new System.Drawing.Size(103, 31);
            this.btnSendUrl.TabIndex = 1;
            this.btnSendUrl.Text = "結果照会";
            this.btnSendUrl.Click += new System.EventHandler(this.btnSendUrl_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(115, 128);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 20);
            this.txtServerIP.TabIndex = 4;
            this.txtServerIP.Tag = "kid";
            this.txtServerIP.Text = "192.168.1.177";
            // 
            // xLabel21
            // 
            this.xLabel21.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel21.Location = new System.Drawing.Point(9, 128);
            this.xLabel21.Name = "xLabel21";
            this.xLabel21.Size = new System.Drawing.Size(100, 20);
            this.xLabel21.TabIndex = 59;
            this.xLabel21.Text = "server IP";
            this.xLabel21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSettingURL
            // 
            this.txtSettingURL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingURL.Enabled = false;
            this.txtSettingURL.Location = new System.Drawing.Point(8, 301);
            this.txtSettingURL.Name = "txtSettingURL";
            this.txtSettingURL.Size = new System.Drawing.Size(799, 44);
            this.txtSettingURL.TabIndex = 25;
            this.txtSettingURL.Tag = "kid";
            this.txtSettingURL.Text = "";
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel1.Controls.Add(this.xLabel22);
            this.xPanel1.Controls.Add(this.fbxIT10);
            this.xPanel1.Controls.Add(this.fbxIT9);
            this.xPanel1.Controls.Add(this.fbxIT8);
            this.xPanel1.Controls.Add(this.fbxIT7);
            this.xPanel1.Controls.Add(this.fbxIT6);
            this.xPanel1.Controls.Add(this.fbxIT5);
            this.xPanel1.Controls.Add(this.fbxIT4);
            this.xPanel1.Controls.Add(this.fbxIT3);
            this.xPanel1.Controls.Add(this.fbxIT2);
            this.xPanel1.Controls.Add(this.fbxIT1);
            this.xPanel1.Controls.Add(this.dbxIT10);
            this.xPanel1.Controls.Add(this.dbxIT9);
            this.xPanel1.Controls.Add(this.dbxIT8);
            this.xPanel1.Controls.Add(this.dbxIT7);
            this.xPanel1.Controls.Add(this.dbxIT6);
            this.xPanel1.Controls.Add(this.dbxIT5);
            this.xPanel1.Controls.Add(this.dbxIT4);
            this.xPanel1.Controls.Add(this.dbxIT3);
            this.xPanel1.Controls.Add(this.dbxIT2);
            this.xPanel1.Controls.Add(this.dbxIT1);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.txtKrn);
            this.xPanel1.Controls.Add(this.txtServerIP);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xLabel21);
            this.xPanel1.Controls.Add(this.txtKrt);
            this.xPanel1.Controls.Add(this.txtXid);
            this.xPanel1.Controls.Add(this.cboSrt2);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.cboSrt1);
            this.xPanel1.Controls.Add(this.txtPwd);
            this.xPanel1.Controls.Add(this.xLabel19);
            this.xPanel1.Controls.Add(this.xLabel20);
            this.xPanel1.Controls.Add(this.dtpToResultDate);
            this.xPanel1.Controls.Add(this.xLabel10);
            this.xPanel1.Controls.Add(this.dtpFromResultDate);
            this.xPanel1.Controls.Add(this.dtpToJubsuDate);
            this.xPanel1.Controls.Add(this.xLabel9);
            this.xPanel1.Controls.Add(this.dtpFromJubsuDate);
            this.xPanel1.Controls.Add(this.dtpToOrderDate);
            this.xPanel1.Controls.Add(this.xLabel8);
            this.xPanel1.Controls.Add(this.dtpFromOrderDate);
            this.xPanel1.Controls.Add(this.xLabel16);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.xLabel17);
            this.xPanel1.Controls.Add(this.xLabel18);
            this.xPanel1.Controls.Add(this.xLabel6);
            this.xPanel1.Controls.Add(this.xLabel11);
            this.xPanel1.Controls.Add(this.xLabel15);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.xLabel14);
            this.xPanel1.Controls.Add(this.xLabel13);
            this.xPanel1.Controls.Add(this.txtSettingURL);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 42);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(819, 355);
            this.xPanel1.TabIndex = 1;
            // 
            // fbxIT10
            // 
            this.fbxIT10.FindWorker = this.fwkHangmogCode;
            this.fbxIT10.Location = new System.Drawing.Point(552, 272);
            this.fbxIT10.Name = "fbxIT10";
            this.fbxIT10.Size = new System.Drawing.Size(100, 20);
            this.fbxIT10.TabIndex = 22;
            this.fbxIT10.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fwkHangmogCode
            // 
            this.fwkHangmogCode.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkHangmogCode.FormText = "項目コード照会";
            this.fwkHangmogCode.InputSQL = resources.GetString("fwkHangmogCode.InputSQL");
            this.fwkHangmogCode.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkHangmogCode.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "hangmog_code";
            this.findColumnInfo1.ColWidth = 117;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.Yes;
            this.findColumnInfo1.HeaderText = "項目コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "hangmog_name";
            this.findColumnInfo2.ColWidth = 303;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.Yes;
            this.findColumnInfo2.HeaderText = "項目名";
            // 
            // fbxIT9
            // 
            this.fbxIT9.FindWorker = this.fwkHangmogCode;
            this.fbxIT9.Location = new System.Drawing.Point(552, 243);
            this.fbxIT9.Name = "fbxIT9";
            this.fbxIT9.Size = new System.Drawing.Size(100, 20);
            this.fbxIT9.TabIndex = 21;
            this.fbxIT9.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT8
            // 
            this.fbxIT8.FindWorker = this.fwkHangmogCode;
            this.fbxIT8.Location = new System.Drawing.Point(552, 214);
            this.fbxIT8.Name = "fbxIT8";
            this.fbxIT8.Size = new System.Drawing.Size(100, 20);
            this.fbxIT8.TabIndex = 20;
            this.fbxIT8.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT7
            // 
            this.fbxIT7.FindWorker = this.fwkHangmogCode;
            this.fbxIT7.Location = new System.Drawing.Point(552, 185);
            this.fbxIT7.Name = "fbxIT7";
            this.fbxIT7.Size = new System.Drawing.Size(100, 20);
            this.fbxIT7.TabIndex = 19;
            this.fbxIT7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT6
            // 
            this.fbxIT6.FindWorker = this.fwkHangmogCode;
            this.fbxIT6.Location = new System.Drawing.Point(552, 156);
            this.fbxIT6.Name = "fbxIT6";
            this.fbxIT6.Size = new System.Drawing.Size(100, 20);
            this.fbxIT6.TabIndex = 18;
            this.fbxIT6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT5
            // 
            this.fbxIT5.FindWorker = this.fwkHangmogCode;
            this.fbxIT5.Location = new System.Drawing.Point(552, 127);
            this.fbxIT5.Name = "fbxIT5";
            this.fbxIT5.Size = new System.Drawing.Size(100, 20);
            this.fbxIT5.TabIndex = 17;
            this.fbxIT5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT4
            // 
            this.fbxIT4.FindWorker = this.fwkHangmogCode;
            this.fbxIT4.Location = new System.Drawing.Point(552, 98);
            this.fbxIT4.Name = "fbxIT4";
            this.fbxIT4.Size = new System.Drawing.Size(100, 20);
            this.fbxIT4.TabIndex = 16;
            this.fbxIT4.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT3
            // 
            this.fbxIT3.FindWorker = this.fwkHangmogCode;
            this.fbxIT3.Location = new System.Drawing.Point(552, 69);
            this.fbxIT3.Name = "fbxIT3";
            this.fbxIT3.Size = new System.Drawing.Size(100, 20);
            this.fbxIT3.TabIndex = 15;
            this.fbxIT3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT2
            // 
            this.fbxIT2.FindWorker = this.fwkHangmogCode;
            this.fbxIT2.Location = new System.Drawing.Point(552, 40);
            this.fbxIT2.Name = "fbxIT2";
            this.fbxIT2.Size = new System.Drawing.Size(100, 20);
            this.fbxIT2.TabIndex = 14;
            this.fbxIT2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // fbxIT1
            // 
            this.fbxIT1.FindWorker = this.fwkHangmogCode;
            this.fbxIT1.Location = new System.Drawing.Point(552, 11);
            this.fbxIT1.Name = "fbxIT1";
            this.fbxIT1.Size = new System.Drawing.Size(100, 20);
            this.fbxIT1.TabIndex = 13;
            this.fbxIT1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxIT_DataValidating);
            // 
            // dbxIT10
            // 
            this.dbxIT10.Location = new System.Drawing.Point(658, 272);
            this.dbxIT10.Name = "dbxIT10";
            this.dbxIT10.Size = new System.Drawing.Size(149, 20);
            this.dbxIT10.TabIndex = 69;
            // 
            // dbxIT9
            // 
            this.dbxIT9.Location = new System.Drawing.Point(658, 243);
            this.dbxIT9.Name = "dbxIT9";
            this.dbxIT9.Size = new System.Drawing.Size(149, 20);
            this.dbxIT9.TabIndex = 68;
            // 
            // dbxIT8
            // 
            this.dbxIT8.Location = new System.Drawing.Point(658, 214);
            this.dbxIT8.Name = "dbxIT8";
            this.dbxIT8.Size = new System.Drawing.Size(149, 20);
            this.dbxIT8.TabIndex = 67;
            // 
            // dbxIT7
            // 
            this.dbxIT7.Location = new System.Drawing.Point(658, 185);
            this.dbxIT7.Name = "dbxIT7";
            this.dbxIT7.Size = new System.Drawing.Size(149, 20);
            this.dbxIT7.TabIndex = 66;
            // 
            // dbxIT6
            // 
            this.dbxIT6.Location = new System.Drawing.Point(658, 156);
            this.dbxIT6.Name = "dbxIT6";
            this.dbxIT6.Size = new System.Drawing.Size(149, 20);
            this.dbxIT6.TabIndex = 65;
            // 
            // dbxIT5
            // 
            this.dbxIT5.Location = new System.Drawing.Point(658, 127);
            this.dbxIT5.Name = "dbxIT5";
            this.dbxIT5.Size = new System.Drawing.Size(149, 20);
            this.dbxIT5.TabIndex = 64;
            // 
            // dbxIT4
            // 
            this.dbxIT4.Location = new System.Drawing.Point(658, 98);
            this.dbxIT4.Name = "dbxIT4";
            this.dbxIT4.Size = new System.Drawing.Size(149, 20);
            this.dbxIT4.TabIndex = 63;
            // 
            // dbxIT3
            // 
            this.dbxIT3.Location = new System.Drawing.Point(658, 69);
            this.dbxIT3.Name = "dbxIT3";
            this.dbxIT3.Size = new System.Drawing.Size(149, 20);
            this.dbxIT3.TabIndex = 62;
            // 
            // dbxIT2
            // 
            this.dbxIT2.Location = new System.Drawing.Point(658, 40);
            this.dbxIT2.Name = "dbxIT2";
            this.dbxIT2.Size = new System.Drawing.Size(149, 20);
            this.dbxIT2.TabIndex = 61;
            // 
            // dbxIT1
            // 
            this.dbxIT1.Location = new System.Drawing.Point(658, 11);
            this.dbxIT1.Name = "dbxIT1";
            this.dbxIT1.Size = new System.Drawing.Size(149, 20);
            this.dbxIT1.TabIndex = 60;
            // 
            // btnSettingUrl
            // 
            this.btnSettingUrl.Image = ((System.Drawing.Image)(resources.GetObject("btnSettingUrl.Image")));
            this.btnSettingUrl.Location = new System.Drawing.Point(500, 2);
            this.btnSettingUrl.Name = "btnSettingUrl";
            this.btnSettingUrl.Size = new System.Drawing.Size(103, 31);
            this.btnSettingUrl.TabIndex = 0;
            this.btnSettingUrl.Text = "setting URL";
            this.btnSettingUrl.Click += new System.EventHandler(this.btnSettingUrl_Click);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ds";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.HeaderText = "ㅇㄴ";
            // 
            // paBox
            // 
            this.paBox.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.paBox.Location = new System.Drawing.Point(45, 2);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(761, 32);
            this.paBox.TabIndex = 0;
            // 
            // xPanel2
            // 
            this.xPanel2.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.paBox);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 5);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(819, 37);
            this.xPanel2.TabIndex = 0;
            // 
            // xPanel3
            // 
            this.xPanel3.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel3.Controls.Add(this.btnClose);
            this.xPanel3.Controls.Add(this.btnSettingUrl);
            this.xPanel3.Controls.Add(this.btnSendUrl);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Location = new System.Drawing.Point(5, 397);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(819, 38);
            this.xPanel3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(710, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 31);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "閉じる";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // layBmlUrlInfo
            // 
            this.layBmlUrlInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3});
            this.layBmlUrlInfo.QuerySQL = resources.GetString("layBmlUrlInfo.QuerySQL");
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.txtServerIP;
            this.singleLayoutItem1.DataName = "server_ip";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.txtXid;
            this.singleLayoutItem2.DataName = "user_id";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.BindControl = this.txtPwd;
            this.singleLayoutItem3.DataName = "password";
            // 
            // xLabel22
            // 
            this.xLabel22.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel22.Location = new System.Drawing.Point(8, 279);
            this.xLabel22.Name = "xLabel22";
            this.xLabel22.Size = new System.Drawing.Size(206, 20);
            this.xLabel22.TabIndex = 70;
            this.xLabel22.Text = "URL TEXT";
            this.xLabel22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CPL0000Q01
            // 
            this.BackGroundColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "CPL0000Q01";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(829, 440);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CPL0000Q01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Send URL
        private void btnSendUrl_Click(object sender, EventArgs e)
        {
            btnSettingUrl_Click(sender, e);

            try
            {
                //System.Diagnostics.Process.Start("http://localhost/CPL");  hospital show
                System.Diagnostics.Process.Start(txtSettingURL.Text);
            }
            catch(Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("ex.Message [" + ex.Message + "], ex.Source [" + ex.Source + "], ex.StackTrace [" + ex.StackTrace + "]");
            }
        }
        #endregion

        #region Setting URL
        private void btnSettingUrl_Click(object sender, EventArgs e)
        {
            string serverIP = "";
            string xid = "";
            string pwd = "";
            string krn = "";
            string krt = "";
            string kid = "";
            string it1 = "";
            string it2 = "";
            string it3 = "";
            string it4 = "";
            string it5 = "";
            string it6 = "";
            string it7 = "";
            string it8 = "";
            string it9 = "";
            string it10 = "";

            string yy1 = "";
            string mm1 = "";
            string dd1 = "";
            string yy2 = "";
            string mm2 = "";
            string dd2 = "";

            string yy1s = "";
            string mm1s = "";
            string dd1s = "";
            string yy2s = "";
            string mm2s = "";
            string dd2s = "";

            string yy1r = "";
            string mm1r = "";
            string dd1r = "";
            string yy2r = "";
            string mm2r = "";
            string dd2r = "";

            string srt = "";

            serverIP = txtServerIP.Text;
            xid = txtXid.Text;
            if (!TypeCheck.IsNull(xid)) xid = "xid=" + xid;
            pwd = txtPwd.Text;
            if (!TypeCheck.IsNull(pwd)) pwd = "&pwd=" + pwd;
            krn = txtKrn.Text;
            if (!TypeCheck.IsNull(krn)) krn = "&krn=" + krn;
            //mins update 2011.04.13 kid를 쓰지 않고 krt를 환자번호로 사용
            //krt = txtKrt.Text;
            krt = paBox.BunHo;
            //mins update 2011.06.01 환자번호 앞에 0 빼고 처리하기
            /*if (krt.Length > 0)
            {
                string ch = "";
                for (int i = 0; i < krt.Length; i++)
                {
                    ch = krt.Substring(i, 1);
                    if (ch != "0")
                    {
                        krt = krt.Substring(i);
                        break;
                    }
                }
            }*/
            if (krt.Length > 8)
            {
                krt = krt.Substring(1, 8);
            }

            if (!TypeCheck.IsNull(krt)) krt = "&krt=" + krt;
            //mins update 2011.04.13 kid를 쓰지 않고 krt를 환자번호로 사용
            //kid = paBox.BunHo;
            if (!TypeCheck.IsNull(kid)) kid = "&kid=" + kid;
            it1 = fbxIT1.Text;
            if (!TypeCheck.IsNull(it1)) it1 = "&it1=" + it1;
            it2 = fbxIT2.Text;
            if (!TypeCheck.IsNull(it2)) it2 = "&it2=" + it2;
            it3 = fbxIT3.Text;
            if (!TypeCheck.IsNull(it3)) it3 = "&it3=" + it3;
            it4 = fbxIT4.Text;
            if (!TypeCheck.IsNull(it4)) it4 = "&it4=" + it4;
            it5 = fbxIT5.Text;
            if (!TypeCheck.IsNull(it5)) it5 = "&it5=" + it5;
            it6 = fbxIT6.Text;
            if (!TypeCheck.IsNull(it6)) it6 = "&it6=" + it6;
            it7 = fbxIT7.Text;
            if (!TypeCheck.IsNull(it7)) it7 = "&it7=" + it7;
            it8 = fbxIT8.Text;
            if (!TypeCheck.IsNull(it8)) it8 = "&it8=" + it8;
            it9 = fbxIT9.Text;
            if (!TypeCheck.IsNull(it9)) it9 = "&it9=" + it9;
            it10 = fbxIT10.Text;
            if (!TypeCheck.IsNull(it10)) it10 = "&it10=" + it10;

            if (!TypeCheck.IsNull(dtpFromOrderDate.GetDataValue()))
            {
                yy1 = "&yy1=" + (DateTime.Parse(dtpFromOrderDate.GetDataValue())).ToString("yyyy");
                mm1 = "&mm1=" + (DateTime.Parse(dtpFromOrderDate.GetDataValue())).ToString("MM");
                dd1 = "&dd1=" + (DateTime.Parse(dtpFromOrderDate.GetDataValue())).ToString("dd");
            }

            if (!TypeCheck.IsNull(dtpToOrderDate.GetDataValue()))
            {
                yy2 = "&yy2=" + (DateTime.Parse(dtpToOrderDate.GetDataValue())).ToString("yyyy");
                mm2 = "&mm2=" + (DateTime.Parse(dtpToOrderDate.GetDataValue())).ToString("MM");
                dd2 = "&dd2=" + (DateTime.Parse(dtpToOrderDate.GetDataValue())).ToString("dd");
            }

            if (!TypeCheck.IsNull(dtpFromJubsuDate.GetDataValue()))
            {
                yy1s = "&yy1s=" + (DateTime.Parse(dtpFromJubsuDate.GetDataValue())).ToString("yyyy");
                mm1s = "&mm1s=" + (DateTime.Parse(dtpFromJubsuDate.GetDataValue())).ToString("MM");
                dd1s = "&dd1s=" + (DateTime.Parse(dtpFromJubsuDate.GetDataValue())).ToString("dd");
            }

            if (!TypeCheck.IsNull(dtpToJubsuDate.GetDataValue()))
            {
                yy2s = "&yy2s=" + (DateTime.Parse(dtpToJubsuDate.GetDataValue())).ToString("yyyy");
                mm2s = "&mm2s=" + (DateTime.Parse(dtpToJubsuDate.GetDataValue())).ToString("MM");
                dd2s = "&dd2s=" + (DateTime.Parse(dtpToJubsuDate.GetDataValue())).ToString("dd");
            }

            if (!TypeCheck.IsNull(dtpFromResultDate.GetDataValue()))
            {
                yy1r = "&yy1r=" + (DateTime.Parse(dtpFromResultDate.GetDataValue())).ToString("yyyy");
                mm1r = "&mm1r=" + (DateTime.Parse(dtpFromResultDate.GetDataValue())).ToString("MM");
                dd1r = "&dd1r=" + (DateTime.Parse(dtpFromResultDate.GetDataValue())).ToString("dd");
            }

            if (!TypeCheck.IsNull(dtpToResultDate.GetDataValue()))
            {
                yy2r = "&yy2r=" + (DateTime.Parse(dtpToResultDate.GetDataValue())).ToString("yyyy");
                mm2r = "&mm2r=" + (DateTime.Parse(dtpToResultDate.GetDataValue())).ToString("MM");
                dd2r = "&dd2r=" + (DateTime.Parse(dtpToResultDate.GetDataValue())).ToString("dd");
            }

            srt = cboSrt1.GetDataValue() + cboSrt2.GetDataValue();

            if (srt.Length == 2)
                srt = "&srt=" + srt;
            else
                srt = "";

            string targetUrl = "http://" + serverIP + "/W_tlim/t_select2.asp?"
                             + xid
                             + pwd
                             + krn
                             + krt
                             + kid
                             + it1
                             + it2
                             + it3
                             + it4
                             + it5
                             + it6
                             + it7
                             + it8
                             + it9
                             + it10
                             + yy1
                             + mm1
                             + dd1
                             + yy2
                             + mm2
                             + dd2
                             + yy1s
                             + mm1s
                             + dd1s
                             + yy2s
                             + mm2s
                             + dd2s
                             + yy1r
                             + mm1r
                             + dd1r
                             + yy2r
                             + mm2r
                             + dd2r
                             + srt;

            txtSettingURL.Text = targetUrl;
        }
        #endregion

        
        #region 파인드박스 벨리데이팅 서비스
        private void fbxIT_DataValidating(object sender, DataValidatingEventArgs e)
        {
            MakeValService((XFindBox)sender);
        }

        //각각의 컨트롤(파인드박스)에 맞는 벨리데이션 서비스로 셋팅
        private bool MakeValService(XFindBox aCtl)
        {
            //findBox validation 
            BindVarCollection bindVarList = new BindVarCollection();
            string cmdText = "";
            object retVal = null;

            bindVarList.Add("f_code", aCtl.GetDataValue());
            cmdText = "select gumsa_name from cpl0101 where hangmog_code = :f_code";
            retVal = Service.ExecuteScalar(cmdText, bindVarList);

            if (retVal == null)
            {
                this.SetMsg(XMsg.GetMsg("M001"), MsgType.Normal); //존재하지 않는 항목코드입니다.
                return false;
            }

            switch (aCtl.Name)
            {
                case "fbxIT1":
                    dbxIT1.Text = "";
                    this.dbxIT1.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT2":
                    dbxIT2.Text = "";
                    this.dbxIT2.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT3":
                    dbxIT3.Text = "";
                    this.dbxIT3.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT4":
                    dbxIT4.Text = "";
                    this.dbxIT4.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT5":
                    dbxIT5.Text = "";
                    this.dbxIT5.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT6":
                    dbxIT6.Text = "";
                    this.dbxIT6.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT7":
                    dbxIT7.Text = "";
                    this.dbxIT7.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT8":
                    dbxIT8.Text = "";
                    this.dbxIT8.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT9":
                    dbxIT9.Text = "";
                    this.dbxIT9.SetDataValue(retVal.ToString());
                    break;
                case "fbxIT10":
                    dbxIT10.Text = "";
                    this.dbxIT10.SetDataValue(retVal.ToString());
                    break;
                default:
                    return false;
            }

            return true;
        }
        #endregion

        #region 스크린 오픈 이벤트
        private void CPL0000Q01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            layBmlUrlInfo.QueryLayout();

            if (!TypeCheck.IsNull(layBmlUrlInfo.GetItemValue("server_ip").ToString()))
            {
                txtServerIP.Text = layBmlUrlInfo.GetItemValue("server_ip").ToString();
            }

            if (!TypeCheck.IsNull(layBmlUrlInfo.GetItemValue("user_id").ToString()))
            {
                txtXid.Text = layBmlUrlInfo.GetItemValue("user_id").ToString();
            }

            if (!TypeCheck.IsNull(layBmlUrlInfo.GetItemValue("password").ToString()))
            {
                txtPwd.Text = layBmlUrlInfo.GetItemValue("password").ToString();
            }

            if (!TypeCheck.IsNull(OpenParam))
            {
                if (OpenParam.Contains("close_yn") && OpenParam["close_yn"].ToString() == "Y")
                {
                    this.ParentForm.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    this.ParentForm.WindowState = FormWindowState.Normal;
                }

                if (OpenParam.Contains("bunho"))
                {
                    paBox.SetPatientID(OpenParam["bunho"].ToString());
                }

                if (OpenParam.Contains("send_yn") && OpenParam["send_yn"].ToString() == "Y")
                {
                    btnSendUrl_Click(sender, e);
                }

                if (OpenParam.Contains("close_yn") && OpenParam["close_yn"].ToString() == "Y")
                {
                    PostCallHelper.PostCall(this.Close);
                }
            }
        }
        #endregion

        #region Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

