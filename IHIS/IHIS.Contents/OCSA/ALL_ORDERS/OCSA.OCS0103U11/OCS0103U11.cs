using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
using IHIS.OCSA.Properties;
using PatientInfo = IHIS.OCS.PatientInfo;
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;

namespace IHIS.OCSA
{
    public partial class OCS0103U11 : XScreen
    {
        #region Auto-gen code

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103U11));
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
            this.mainControl = new IHIS.OCSA.UCOCS0103U11();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.pnlButton = new IHIS.Framework.XPanel();
            this.pbxCopy = new System.Windows.Forms.PictureBox();
            this.btnCut = new IHIS.Framework.XButton();
            this.btnCopy = new IHIS.Framework.XButton();
            this.btnIlgwalChange = new IHIS.Framework.XButton();
            this.btnPaste = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell493 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.pnlTop.SuspendLayout();
            this.pnlPatientInfo.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
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
            this.pnlTop.AllowDrop = true;
            this.pnlTop.Controls.Add(this.pnlPatientInfo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1300, 36);
            this.pnlTop.TabIndex = 4;
            // 
            // pnlPatientInfo
            // 
            this.pnlPatientInfo.AllowDrop = true;
            this.pnlPatientInfo.BackColor = IHIS.Framework.XColor.XRoundPanelBackColor;
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
            this.pnlPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatientInfo.DrawBorder = true;
            this.pnlPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            this.pnlPatientInfo.Size = new System.Drawing.Size(1300, 33);
            this.pnlPatientInfo.TabIndex = 0;
            // 
            // dbxInputGubunName
            // 
            this.dbxInputGubunName.AllowDrop = true;
            this.dbxInputGubunName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbxInputGubunName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.dbxInputGubunName.Location = new System.Drawing.Point(1135, 3);
            this.dbxInputGubunName.Name = "dbxInputGubunName";
            this.dbxInputGubunName.Size = new System.Drawing.Size(90, 26);
            this.dbxInputGubunName.TabIndex = 11;
            this.dbxInputGubunName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dpkOrder_Date
            // 
            this.dpkOrder_Date.AllowDrop = true;
            this.dpkOrder_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dpkOrder_Date.IsVietnameseYearType = false;
            this.dpkOrder_Date.Location = new System.Drawing.Point(108, 7);
            this.dpkOrder_Date.Name = "dpkOrder_Date";
            this.dpkOrder_Date.Size = new System.Drawing.Size(105, 20);
            this.dpkOrder_Date.TabIndex = 2;
            this.dpkOrder_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dbxChojae_name
            // 
            this.dbxChojae_name.AllowDrop = true;
            this.dbxChojae_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dbxChojae_name.Location = new System.Drawing.Point(1226, 3);
            this.dbxChojae_name.Name = "dbxChojae_name";
            this.dbxChojae_name.Size = new System.Drawing.Size(70, 26);
            this.dbxChojae_name.TabIndex = 10;
            this.dbxChojae_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxWeight_height
            // 
            this.dbxWeight_height.AllowDrop = true;
            this.dbxWeight_height.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dbxWeight_height.Location = new System.Drawing.Point(831, 3);
            this.dbxWeight_height.Name = "dbxWeight_height";
            this.dbxWeight_height.Size = new System.Drawing.Size(105, 26);
            this.dbxWeight_height.TabIndex = 9;
            this.dbxWeight_height.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxGubun_name
            // 
            this.dbxGubun_name.AllowDrop = true;
            this.dbxGubun_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dbxGubun_name.Location = new System.Drawing.Point(661, 3);
            this.dbxGubun_name.Name = "dbxGubun_name";
            this.dbxGubun_name.Size = new System.Drawing.Size(170, 26);
            this.dbxGubun_name.TabIndex = 7;
            this.dbxGubun_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxSuname
            // 
            this.dbxSuname.AllowDrop = true;
            this.dbxSuname.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.dbxSuname.Location = new System.Drawing.Point(392, 3);
            this.dbxSuname.Name = "dbxSuname";
            this.dbxSuname.Size = new System.Drawing.Size(183, 26);
            this.dbxSuname.TabIndex = 5;
            this.dbxSuname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxAge_Sex
            // 
            this.dbxAge_Sex.AllowDrop = true;
            this.dbxAge_Sex.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.dbxAge_Sex.Location = new System.Drawing.Point(575, 3);
            this.dbxAge_Sex.Name = "dbxAge_Sex";
            this.dbxAge_Sex.Size = new System.Drawing.Size(86, 26);
            this.dbxAge_Sex.TabIndex = 6;
            this.dbxAge_Sex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fbxBunho
            // 
            this.fbxBunho.AllowDrop = true;
            this.fbxBunho.EnableEdit = false;
            this.fbxBunho.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.fbxBunho.Location = new System.Drawing.Point(293, 7);
            this.fbxBunho.Name = "fbxBunho";
            this.fbxBunho.Protect = true;
            this.fbxBunho.ReadOnly = true;
            this.fbxBunho.Size = new System.Drawing.Size(97, 20);
            this.fbxBunho.TabIndex = 4;
            this.fbxBunho.TabStop = false;
            this.fbxBunho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xFlatLabel3
            // 
            this.xFlatLabel3.AllowDrop = true;
            this.xFlatLabel3.AutoSize = true;
            this.xFlatLabel3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.xFlatLabel3.Location = new System.Drawing.Point(246, 11);
            this.xFlatLabel3.Name = "xFlatLabel3";
            this.xFlatLabel3.Size = new System.Drawing.Size(55, 13);
            this.xFlatLabel3.TabIndex = 3;
            this.xFlatLabel3.Text = "患者番号";
            this.xFlatLabel3.Visible = false;
            // 
            // lblNaewonDate
            // 
            this.lblNaewonDate.AllowDrop = true;
            this.lblNaewonDate.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.lblNaewonDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNaewonDate.Image = ((System.Drawing.Image)(resources.GetObject("lblNaewonDate.Image")));
            this.lblNaewonDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNaewonDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNaewonDate.Location = new System.Drawing.Point(12, 8);
            this.lblNaewonDate.Name = "lblNaewonDate";
            this.lblNaewonDate.Size = new System.Drawing.Size(97, 19);
            this.lblNaewonDate.TabIndex = 1;
            this.lblNaewonDate.Text = "     オーダ日付";
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.mainControl);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 36);
            this.pnlFill.Margin = new System.Windows.Forms.Padding(7);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1300, 531);
            this.pnlFill.TabIndex = 9;
            // 
            // mainControl
            // 
            this.mainControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            this.mainControl.CausesValidation = false;
            this.mainControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.mainControl.Location = new System.Drawing.Point(0, 0);
            this.mainControl.MBtnCopy = null;
            this.mainControl.MBtnList = null;
            this.mainControl.MBtnPaste = null;
            this.mainControl.MBunho = null;
            this.mainControl.MContainer = null;
            this.mainControl.MOpener = null;
            this.mainControl.MPbxCopy = null;
            this.mainControl.MPnlTop = null;
            this.mainControl.Name = "mainControl";
            this.mainControl.Size = new System.Drawing.Size(1300, 530);
            this.mainControl.TabIndex = 0;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.pbxCopy);
            this.pnlButton.Controls.Add(this.btnCut);
            this.pnlButton.Controls.Add(this.btnCopy);
            this.pnlButton.Controls.Add(this.btnIlgwalChange);
            this.pnlButton.Controls.Add(this.btnPaste);
            this.pnlButton.Controls.Add(this.btnList);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.DrawBorder = true;
            this.pnlButton.Location = new System.Drawing.Point(0, 567);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1300, 33);
            this.pnlButton.TabIndex = 10;
            // 
            // pbxCopy
            // 
            this.pbxCopy.Image = ((System.Drawing.Image)(resources.GetObject("pbxCopy.Image")));
            this.pbxCopy.Location = new System.Drawing.Point(10, 7);
            this.pbxCopy.Name = "pbxCopy";
            this.pbxCopy.Size = new System.Drawing.Size(16, 17);
            this.pbxCopy.TabIndex = 101;
            this.pbxCopy.TabStop = false;
            this.pbxCopy.Visible = false;
            // 
            // btnCut
            // 
            this.btnCut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCut.ImageIndex = 2;
            this.btnCut.Location = new System.Drawing.Point(68, 2);
            this.btnCut.Name = "btnCut";
            this.btnCut.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnCut.Size = new System.Drawing.Size(61, 27);
            this.btnCut.TabIndex = 109;
            this.btnCut.Tag = "0";
            this.btnCut.Text = "Cut";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCopy.ImageIndex = 2;
            this.btnCopy.Location = new System.Drawing.Point(4, 2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnCopy.Size = new System.Drawing.Size(61, 27);
            this.btnCopy.TabIndex = 108;
            this.btnCopy.Tag = "1";
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnIlgwalChange
            // 
            this.btnIlgwalChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIlgwalChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnIlgwalChange.Image = ((System.Drawing.Image)(resources.GetObject("btnIlgwalChange.Image")));
            this.btnIlgwalChange.Location = new System.Drawing.Point(216, 2);
            this.btnIlgwalChange.Name = "btnIlgwalChange";
            this.btnIlgwalChange.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnIlgwalChange.Size = new System.Drawing.Size(83, 27);
            this.btnIlgwalChange.TabIndex = 104;
            this.btnIlgwalChange.Text = "一括変更";
            this.btnIlgwalChange.Visible = false;
            this.btnIlgwalChange.Click += new System.EventHandler(this.btnIlgwalChange_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPaste.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPaste.ImageIndex = 3;
            this.btnPaste.Location = new System.Drawing.Point(136, 2);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnPaste.Size = new System.Drawing.Size(74, 27);
            this.btnPaste.TabIndex = 98;
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_INSERT_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_INSERT_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_DELETE_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_DELETE_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_PROCESS_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_PROCESS_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.BTN_CANCEL_TEXT, -1, global::IHIS.OCSA.Properties.Resources.BTN_CANCEL_TEXT),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Update, -1, global::IHIS.OCSA.Properties.Resources.btn_Update),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_Close, -1, global::IHIS.OCSA.Properties.Resources.btn_Close)});
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(678, -1);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(593, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnList_MouseDown);
            // 
            // xEditGridCell493
            // 
            this.xEditGridCell493.CellName = "specific_comment_sys_id";
            this.xEditGridCell493.Col = -1;
            this.xEditGridCell493.ExecuteQuery = null;
            this.xEditGridCell493.HeaderText = "specific_comment_sys_id";
            this.xEditGridCell493.IsVisible = false;
            this.xEditGridCell493.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.ExecuteQuery = null;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.ExecuteQuery = null;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.ExecuteQuery = null;
            // 
            // OCS0103U11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "OCS0103U11";
            this.Size = new System.Drawing.Size(1300, 600);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OCS0103U10_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCS0103U10_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            this.pnlFill.ResumeLayout(false);
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
        private IHIS.Framework.XButton btnIlgwalChange;
        private IHIS.Framework.XButton btnCut;
        private IHIS.Framework.XButton btnCopy;
        private UCOCS0103U11 mainControl;

        #endregion

        #region 1. 생성자를 정의한다
        public OCS0103U11()
        {
           // MessageBox.Show("Constructor start");

            InitializeComponent();

           // MessageBox.Show("Constructor end");

            //this.cboSearchCondition.ExecuteQuery = LoadDataCboSearchCondition;
            //this.cboSearchCondition.SetDictDDLB();
            // CloudConnector updated code
            //InitItemsControl();
            this.mainControl.MContainer = this;
            this.mainControl.MPnlTop = this.pnlTop;
            this.mainControl.MBtnList = this.btnList;
            this.mainControl.MBtnCopy = this.btnCopy;
            this.mainControl.MBtnPaste = this.btnPaste;
            this.mainControl.MPbxCopy = this.pbxCopy;

            //MED6991
            InitializeLookAndFeel();
        }

        

        #endregion

        #region 2. Methods

        private void InitializeLookAndFeel()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                dbxInputGubunName.Width += 10;
            }
        }
        /// <summary>
        /// 해당 Screen의 각종 Control 관련 Setting
        /// </summary>
        private void InitializeScreen()
        {
            String result = this.mainControl.InitializeScreen();
            if (!String.IsNullOrEmpty(result))
            {
                this.dpkOrder_Date.SetDataValue(result);
            }
        }

        private void SetPatientInfo()
        {
            try
            {
                // 환자정보
                this.dbxSuname.SetDataValue(mainControl.MPatientInfo.GetPatientInfo["suname"].ToString() + " " + mainControl.MPatientInfo.GetPatientInfo["suname2"].ToString());
                // 성별 나이
                this.dbxAge_Sex.SetDataValue(mainControl.MPatientInfo.GetPatientInfo["sex_age"].ToString());
                // 보험 이ㅣ름
                this.dbxGubun_name.SetDataValue(mainControl.MPatientInfo.GetPatientInfo["gubun_name"].ToString());
                // 진료정보 ( 여기다가 뭘 넣을까.... )

                // 신장, 체중
                this.dbxWeight_height.SetDataValue(mainControl.MPatientInfo.GetPatientInfo["weight_height"].ToString());

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

        private void OCS0103U10_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            string inputGubunName = null;
            string mDefaultWonyoiOrder = this.mainControl.ScreenOpen(this.OpenParam, ref inputGubunName);
            this.mainControl.MOpener = (XScreen)this.Opener;

            if (this.OpenParam != null)
            {
                #region 파라미터 셋팅

                if (this.OpenParam.Contains("order_date"))
                {
                    this.dpkOrder_Date.SetDataValue(this.OpenParam["order_date"].ToString());
                }
                else
                {
                    dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }


                if (this.OpenParam.Contains("input_gubun"))
                {

                    //this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", this.mInputGubun, ref this.mInputGubunName);
                    this.dbxInputGubunName.SetDataValue("【 " + inputGubunName + " 】");
                }


                if (this.OpenParam.Contains("patient_info"))
                {
                    this.SetPatientInfo();
                }

                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;

                #endregion

            }
        }

        private void OCS0103U10_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) mainControl.MOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            e.IsBaseCall = false;
            mainControl.HandleBtnListClick(e.Func);
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            mainControl.HandleBtnPasteClick();
        }

        private void btnIlgwalChange_Click(object sender, EventArgs e)
        {
            mainControl.HandleBtnIlgwalChangeClick();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            mainControl.HandleBtnCopyClick(false);
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            mainControl.HandleBtnCopyClick(true);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            return this.mainControl.Command(command, commandParam);
        }
        #endregion

    }

}
