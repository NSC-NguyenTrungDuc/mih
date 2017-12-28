using System.Windows.Forms;
using IHIS.OCSA.Properties;

namespace IHIS.OCSA
{
    partial class OCS0103U18
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103U18));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlPatientInfo = new IHIS.Framework.XPanel();
            this.xRoundPanel1 = new IHIS.Framework.XRoundPanel();
            this.dbxInputGubunName = new IHIS.Framework.XDisplayBox();
            this.dbxChojae_name = new IHIS.Framework.XDisplayBox();
            this.dpkOrder_Date = new IHIS.Framework.XDatePicker();
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
            this.xRoundPanel1.SuspendLayout();
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
            this.ImageList.Images.SetKeyName(11, "수정.ico");
            this.ImageList.Images.SetKeyName(12, "++.gif");
            this.ImageList.Images.SetKeyName(13, "뒤로.gif");
            this.ImageList.Images.SetKeyName(14, "왼쪽_회색1.gif");
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
            this.pnlPatientInfo.Controls.Add(this.xRoundPanel1);
            this.pnlPatientInfo.Controls.Add(this.dpkOrder_Date);
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
            // xRoundPanel1
            // 
            this.xRoundPanel1.AccessibleDescription = null;
            this.xRoundPanel1.AccessibleName = null;
            resources.ApplyResources(this.xRoundPanel1, "xRoundPanel1");
            this.xRoundPanel1.BackgroundImage = null;
            this.xRoundPanel1.Controls.Add(this.dbxInputGubunName);
            this.xRoundPanel1.Controls.Add(this.dbxChojae_name);
            this.xRoundPanel1.Name = "xRoundPanel1";
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
            // dbxChojae_name
            // 
            this.dbxChojae_name.AccessibleDescription = null;
            this.dbxChojae_name.AccessibleName = null;
            this.dbxChojae_name.AllowDrop = true;
            resources.ApplyResources(this.dbxChojae_name, "dbxChojae_name");
            this.dbxChojae_name.Image = null;
            this.dbxChojae_name.Name = "dbxChojae_name";
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
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Insert, -1, global::IHIS.OCSA.Properties.Resources.btn_Insert),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Delete, -1, global::IHIS.OCSA.Properties.Resources.btn_Delete),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Process, -1, global::IHIS.OCSA.Properties.Resources.btn_Process),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Cancel, -1, global::IHIS.OCSA.Properties.Resources.btn_Cancel),
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
            // OCS0103U18
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlTop);
            this.Name = "OCS0103U18";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS0103U10_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0103U10_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            this.xRoundPanel1.ResumeLayout(false);
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
        private IHIS.Framework.XEditGridCell xEditGridCell493;
        private IHIS.Framework.XEditGridCell xEditGridCell50;
        private IHIS.Framework.XEditGridCell xEditGridCell51;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XButton btnPaste;
        private PictureBox pbxCopy;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XButton btnCut;
        private IHIS.Framework.XButton btnCopy;
        private IHIS.Framework.XRoundPanel xRoundPanel1;
        private IHIS.Framework.XDisplayBox dbxInputGubunName;
        private IHIS.Framework.XDisplayBox dbxChojae_name;
    }
}
