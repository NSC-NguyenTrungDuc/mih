using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Caching;
using System.Reflection;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using SystemModels = IHIS.CloudConnector.Contracts.Models.System;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.OCSA
{
    public partial class OCS0103U14 : XScreen
    {
        #region Auto gen code
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103U14));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlPatientInfo = new IHIS.Framework.XPanel();
            this.dbxInputGubunName = new IHIS.Framework.XDisplayBox();
            this.dpkOrder_Date = new IHIS.Framework.XDatePicker();
            this.dbxChojae_name = new IHIS.Framework.XDisplayBox();
            this.dbxWeight_height = new IHIS.Framework.XDisplayBox();
            this.dbxGubun_name = new IHIS.Framework.XDisplayBox();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.dbxAge_Sex = new IHIS.Framework.XDisplayBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.xFlatLabel3 = new IHIS.Framework.XFlatLabel();
            this.lblNaewonDate = new IHIS.Framework.XFlatLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pnlButton = new IHIS.Framework.XPanel();
            this.pbxCopy = new System.Windows.Forms.PictureBox();
            this.btnCut = new IHIS.Framework.XButton();
            this.btnCopy = new IHIS.Framework.XButton();
            this.btnPaste = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell493 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            this.pnlPatientInfo.SuspendLayout();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(2, "열지우기.ico");
            this.ImageList.Images.SetKeyName(3, "오른쪽_회색.gif");
            this.ImageList.Images.SetKeyName(4, "왼쪽_회색.gif");
            this.ImageList.Images.SetKeyName(5, "닫힌폴더.ico");
            this.ImageList.Images.SetKeyName(6, "열린폴더.ico");
            this.ImageList.Images.SetKeyName(7, "Plus.ico");
            this.ImageList.Images.SetKeyName(8, "오른쪽_회색1.gif");
            this.ImageList.Images.SetKeyName(9, "메뉴보기.gif");
            this.ImageList.Images.SetKeyName(10, "진료안내16.ico");
            this.ImageList.Images.SetKeyName(11, "++.gif");
            this.ImageList.Images.SetKeyName(12, "뒤로.gif");
            this.ImageList.Images.SetKeyName(13, "왼쪽_회색1.gif");
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            this.pnlTop.AllowDrop = true;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.pnlPatientInfo);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // pnlPatientInfo
            // 
            this.pnlPatientInfo.AccessibleDescription = null;
            this.pnlPatientInfo.AccessibleName = null;
            this.pnlPatientInfo.AllowDrop = true;
            resources.ApplyResources(this.pnlPatientInfo, "pnlPatientInfo");
            this.pnlPatientInfo.BackColor = IHIS.Framework.XColor.XRoundPanelBackColor;
            this.pnlPatientInfo.BackgroundImage = null;
            this.pnlPatientInfo.Controls.Add(this.dbxInputGubunName);
            this.pnlPatientInfo.Controls.Add(this.dpkOrder_Date);
            this.pnlPatientInfo.Controls.Add(this.dbxChojae_name);
            this.pnlPatientInfo.Controls.Add(this.dbxWeight_height);
            this.pnlPatientInfo.Controls.Add(this.dbxGubun_name);
            this.pnlPatientInfo.Controls.Add(this.dbxSuname);
            this.pnlPatientInfo.Controls.Add(this.dbxAge_Sex);
            this.pnlPatientInfo.Controls.Add(this.fbxBunho);
            this.pnlPatientInfo.Controls.Add(this.xFlatLabel3);
            this.pnlPatientInfo.Controls.Add(this.lblNaewonDate);
            this.pnlPatientInfo.DrawBorder = true;
            this.pnlPatientInfo.Font = null;
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            // 
            // dbxInputGubunName
            // 
            this.dbxInputGubunName.AccessibleDescription = null;
            this.dbxInputGubunName.AccessibleName = null;
            this.dbxInputGubunName.AllowDrop = true;
            resources.ApplyResources(this.dbxInputGubunName, "dbxInputGubunName");
            this.dbxInputGubunName.Image = null;
            this.dbxInputGubunName.Name = "dbxInputGubunName";
            // 
            // dpkOrder_Date
            // 
            this.dpkOrder_Date.AccessibleDescription = null;
            this.dpkOrder_Date.AccessibleName = null;
            this.dpkOrder_Date.AllowDrop = true;
            resources.ApplyResources(this.dpkOrder_Date, "dpkOrder_Date");
            this.dpkOrder_Date.BackgroundImage = null;
            this.dpkOrder_Date.IsVietnameseYearType = false;
            this.dpkOrder_Date.Name = "dpkOrder_Date";
            // 
            // dbxChojae_name
            // 
            this.dbxChojae_name.AccessibleDescription = null;
            this.dbxChojae_name.AccessibleName = null;
            this.dbxChojae_name.AllowDrop = true;
            resources.ApplyResources(this.dbxChojae_name, "dbxChojae_name");
            this.dbxChojae_name.Image = null;
            this.dbxChojae_name.Name = "dbxChojae_name";
            // 
            // dbxWeight_height
            // 
            this.dbxWeight_height.AccessibleDescription = null;
            this.dbxWeight_height.AccessibleName = null;
            this.dbxWeight_height.AllowDrop = true;
            resources.ApplyResources(this.dbxWeight_height, "dbxWeight_height");
            this.dbxWeight_height.Image = null;
            this.dbxWeight_height.Name = "dbxWeight_height";
            // 
            // dbxGubun_name
            // 
            this.dbxGubun_name.AccessibleDescription = null;
            this.dbxGubun_name.AccessibleName = null;
            this.dbxGubun_name.AllowDrop = true;
            resources.ApplyResources(this.dbxGubun_name, "dbxGubun_name");
            this.dbxGubun_name.Image = null;
            this.dbxGubun_name.Name = "dbxGubun_name";
            // 
            // dbxSuname
            // 
            this.dbxSuname.AccessibleDescription = null;
            this.dbxSuname.AccessibleName = null;
            this.dbxSuname.AllowDrop = true;
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Image = null;
            this.dbxSuname.Name = "dbxSuname";
            // 
            // dbxAge_Sex
            // 
            this.dbxAge_Sex.AccessibleDescription = null;
            this.dbxAge_Sex.AccessibleName = null;
            this.dbxAge_Sex.AllowDrop = true;
            resources.ApplyResources(this.dbxAge_Sex, "dbxAge_Sex");
            this.dbxAge_Sex.Image = null;
            this.dbxAge_Sex.Name = "dbxAge_Sex";
            // 
            // fbxBunho
            // 
            this.fbxBunho.AccessibleDescription = null;
            this.fbxBunho.AccessibleName = null;
            this.fbxBunho.AllowDrop = true;
            resources.ApplyResources(this.fbxBunho, "fbxBunho");
            this.fbxBunho.BackgroundImage = null;
            this.fbxBunho.EnableEdit = false;
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Protect = true;
            this.fbxBunho.ReadOnly = true;
            this.fbxBunho.TabStop = false;
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.AccessibleDescription = null;
            this.xFlatLabel3.AccessibleName = null;
            this.xFlatLabel3.AllowDrop = true;
            resources.ApplyResources(this.xFlatLabel3, "xFlatLabel3");
            this.xFlatLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel3.Name = "xFlatLabel3";
            // 
            // lblNaewonDate
            // 
            this.lblNaewonDate.AccessibleDescription = null;
            this.lblNaewonDate.AccessibleName = null;
            this.lblNaewonDate.AllowDrop = true;
            resources.ApplyResources(this.lblNaewonDate, "lblNaewonDate");
            this.lblNaewonDate.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.lblNaewonDate.Name = "lblNaewonDate";
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // xGridHeader1
            // 
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            // 
            // pnlButton
            // 
            this.pnlButton.AccessibleDescription = null;
            this.pnlButton.AccessibleName = null;
            resources.ApplyResources(this.pnlButton, "pnlButton");
            this.pnlButton.BackgroundImage = null;
            this.pnlButton.Controls.Add(this.pbxCopy);
            this.pnlButton.Controls.Add(this.btnCut);
            this.pnlButton.Controls.Add(this.btnCopy);
            this.pnlButton.Controls.Add(this.btnPaste);
            this.pnlButton.Controls.Add(this.btnList);
            this.pnlButton.DrawBorder = true;
            this.pnlButton.Font = null;
            this.pnlButton.Name = "pnlButton";
            // 
            // pbxCopy
            // 
            this.pbxCopy.AccessibleDescription = null;
            this.pbxCopy.AccessibleName = null;
            resources.ApplyResources(this.pbxCopy, "pbxCopy");
            this.pbxCopy.BackgroundImage = null;
            this.pbxCopy.Font = null;
            this.pbxCopy.ImageLocation = null;
            this.pbxCopy.Name = "pbxCopy";
            this.pbxCopy.TabStop = false;
            // 
            // btnCut
            // 
            this.btnCut.AccessibleDescription = null;
            this.btnCut.AccessibleName = null;
            resources.ApplyResources(this.btnCut, "btnCut");
            this.btnCut.BackgroundImage = null;
            this.btnCut.ImageIndex = 2;
            this.btnCut.Name = "btnCut";
            this.btnCut.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnCut.Tag = "0";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleDescription = null;
            this.btnCopy.AccessibleName = null;
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.BackgroundImage = null;
            this.btnCopy.ImageIndex = 2;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnCopy.Tag = "1";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.AccessibleDescription = null;
            this.btnPaste.AccessibleName = null;
            resources.ApplyResources(this.btnPaste, "btnPaste");
            this.btnPaste.BackgroundImage = null;
            this.btnPaste.ImageIndex = 3;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_INSERT_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_INSERT_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_DELETE_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_DELETE_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_PROCESS_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_PROCESS_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_CANCEL_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_CANCEL_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Update, -1, global::IHIS.OCSA.Properties.Resources.btn_Update),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Close, -1, global::IHIS.OCSA.Properties.Resources.btn_Close)});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnList_MouseDown);
            // 
            // xEditGridCell493
            // 
            this.xEditGridCell493.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell493.CellName = "specific_comment_sys_id";
            this.xEditGridCell493.Col = -1;
            this.xEditGridCell493.ExecuteQuery = null;
            this.xEditGridCell493.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell493, "xEditGridCell493");
            this.xEditGridCell493.IsVisible = false;
            this.xEditGridCell493.Row = -1;
            this.xEditGridCell493.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // OCS0103U14
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlTop);
            this.Name = "OCS0103U14";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS0103U10_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0103U10_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlPatientInfo;
        private IHIS.Framework.XFlatLabel lblNaewonDate;
        private IHIS.Framework.XDatePicker dpkOrder_Date;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XPanel pnlButton;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XFindBox fbxBunho;
        private IHIS.Framework.XFlatLabel xFlatLabel3;
        private IHIS.Framework.XDisplayBox dbxGubun_name;
        private IHIS.Framework.XDisplayBox dbxAge_Sex;
        private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XDisplayBox dbxWeight_height;
        private IHIS.Framework.XDisplayBox dbxChojae_name;
        private IHIS.Framework.XEditGridCell xEditGridCell493;
        private IHIS.Framework.XDisplayBox dbxInputGubunName;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XButton btnPaste;
        private PictureBox pbxCopy;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XButton btnCut;
        private IHIS.Framework.XButton btnCopy;
        #endregion


        private UCOCS0103U14 mainControl;
        
        #region Constructor
        /// <summary>
        /// OCS0103U14
        /// </summary>
        public OCS0103U14()
        {
           // MessageBox.Show("Constructor start");

            InitializeComponent();

            this.mainControl = new IHIS.OCSA.UCOCS0103U14();
            this.pnlFill.Controls.Add(this.mainControl);
            this.mainControl.Name = "OCS0103U14";
            this.mainControl.Dock = DockStyle.Fill;
            this.mainControl.Location = new Point(0, 0);
            this.mainControl.Size = new Size(1200, 531);

            this.mainControl.MContainer = this;
            this.mainControl.MPnlTop = this.pnlTop;
            this.mainControl.MBtnList = this.btnList;
            this.mainControl.MBtnCopy = this.btnCopy;
            this.mainControl.MBtnPaste = this.btnPaste;
            this.mainControl.MPbxCopy = this.pbxCopy;     

           // MessageBox.Show("Constructor end");

            //MED6991
            InitializeLookAndFeel();

            xFlatLabel3.Visible = true;
        }
        #endregion

        private void InitializeLookAndFeel()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                dbxInputGubunName.Width += 10;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(false);
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(true);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnPasteClick();
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.mainControl.HandleBtnListButtonClick(e.Func);
            e.IsBaseCall = false;
        }

        private void OCS0103U10_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void OCS0103U10_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.mainControl.MOpener = (XScreen)this.Opener;
            mainControl.InitItemsControl();
            string mInputGubunName = this.mainControl.ScreenOpen(this.OpenParam);
            
            if (e.OpenParam != null) // 다른 화면에서 콜되는 경우
            {
                // 오더일자
                if (this.OpenParam.Contains("order_date"))
                {
                    this.dpkOrder_Date.SetDataValue(this.OpenParam["order_date"].ToString());
                }
                else
                {
                    this.dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }

                if (this.OpenParam.Contains("patient_info"))
                {
                    // 환자정보가 있으면 이거 가져다 넣어주ㅝ야 함.
                    this.SetPatientInfo();
                }

                if (this.OpenParam.Contains("input_gubun"))
                {
                    this.dbxInputGubunName.SetDataValue("【 " + mInputGubunName + " 】");
                }

                // 오더일자와 환자번호는 변경할수 없도록 프로텍트 처리
                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;
            }
            else
            {
                this.dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            }
        }

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mainControl.MOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void SetPatientInfo()
        {
            try
            {
                // 환자정보
                this.dbxSuname.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["suname"].ToString() + " " + this.mainControl.MPatientInfo.GetPatientInfo["suname2"].ToString());
                // 성별 나이
                this.dbxAge_Sex.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["sex_age"].ToString());
                // 보험 이ㅣ름
                this.dbxGubun_name.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["gubun_name"].ToString());
                // 진료정보 ( 여기다가 뭘 넣을까.... )

                // 신장, 체중
                this.dbxWeight_height.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["weight_height"].ToString());

                //MED-8418
                if (this.mainControl.MPatientInfo.GetPatientInfo["chojae_name"] != null)
                {
                    this.dbxChojae_name.SetDataValue(this.mainControl.MPatientInfo.GetPatientInfo["chojae_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Exception on Method SetPatientInfo: " + ex.StackTrace);
            }
        }
    }
}
