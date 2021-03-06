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
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using SystemModels = IHIS.CloudConnector.Contracts.Models.System;
using System.Reflection;
using System.Text.RegularExpressions;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results;
using System.Diagnostics;

namespace IHIS.OCSA
{
    public partial class OCS0103U10 : XScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0103U10));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlPatientInfo = new IHIS.Framework.XPanel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.btnChangeWonyoi = new IHIS.Framework.XButton();
            this.dbxInputGubunName = new IHIS.Framework.XDisplayBox();
            this.dpkOrder_Date = new IHIS.Framework.XDatePicker();
            this.dbxChojae_name = new IHIS.Framework.XDisplayBox();
            this.dbxWeight_height = new IHIS.Framework.XDisplayBox();
            this.dbxGubun_name = new IHIS.Framework.XDisplayBox();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.dbxAge_Sex = new IHIS.Framework.XDisplayBox();
            this.fbxBunho = new IHIS.Framework.XFindBox();
            this.lblNaewonDate = new IHIS.Framework.XFlatLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.btnCopy = new IHIS.Framework.XButton();
            this.pnlButton = new IHIS.Framework.XPanel();
            this.btnCut = new IHIS.Framework.XButton();
            this.btnHopeDateIlgwal = new IHIS.Framework.XButton();
            this.btnIlgwalChange = new IHIS.Framework.XButton();
            this.btnMakeSet = new IHIS.Framework.XButton();
            this.pbxCopy = new System.Windows.Forms.PictureBox();
            this.btnMixCancel = new IHIS.Framework.XButton();
            this.btnMix = new IHIS.Framework.XButton();
            this.btnPaste = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xEditGridCell493 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
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
            this.ImageList.Images.SetKeyName(7, "약국정보관리.ico");
            this.ImageList.Images.SetKeyName(8, "진료안내16.ico");
            this.ImageList.Images.SetKeyName(9, "++.gif");
            this.ImageList.Images.SetKeyName(10, "뒤로.gif");
            this.ImageList.Images.SetKeyName(11, "왼쪽_회색1.gif");
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
            this.pnlPatientInfo.Controls.Add(this.xFlatLabel1);
            this.pnlPatientInfo.Controls.Add(this.btnChangeWonyoi);
            this.pnlPatientInfo.Controls.Add(this.dbxInputGubunName);
            this.pnlPatientInfo.Controls.Add(this.dpkOrder_Date);
            this.pnlPatientInfo.Controls.Add(this.dbxChojae_name);
            this.pnlPatientInfo.Controls.Add(this.dbxWeight_height);
            this.pnlPatientInfo.Controls.Add(this.dbxGubun_name);
            this.pnlPatientInfo.Controls.Add(this.dbxSuname);
            this.pnlPatientInfo.Controls.Add(this.dbxAge_Sex);
            this.pnlPatientInfo.Controls.Add(this.fbxBunho);
            this.pnlPatientInfo.Controls.Add(this.lblNaewonDate);
            this.pnlPatientInfo.DrawBorder = true;
            this.pnlPatientInfo.Font = null;
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.AccessibleDescription = null;
            this.xFlatLabel1.AccessibleName = null;
            this.xFlatLabel1.AllowDrop = true;
            resources.ApplyResources(this.xFlatLabel1, "xFlatLabel1");
            this.xFlatLabel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xFlatLabel1.Name = "xFlatLabel1";
            // 
            // btnChangeWonyoi
            // 
            this.btnChangeWonyoi.AccessibleDescription = null;
            this.btnChangeWonyoi.AccessibleName = null;
            resources.ApplyResources(this.btnChangeWonyoi, "btnChangeWonyoi");
            this.btnChangeWonyoi.BackgroundImage = null;
            this.btnChangeWonyoi.Name = "btnChangeWonyoi";
            this.btnChangeWonyoi.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnChangeWonyoi.Click += new System.EventHandler(this.btnChangeWonyoi_Click);
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
            // pnlButton
            // 
            this.pnlButton.AccessibleDescription = null;
            this.pnlButton.AccessibleName = null;
            resources.ApplyResources(this.pnlButton, "pnlButton");
            this.pnlButton.BackgroundImage = null;
            this.pnlButton.Controls.Add(this.btnCut);
            this.pnlButton.Controls.Add(this.btnHopeDateIlgwal);
            this.pnlButton.Controls.Add(this.btnIlgwalChange);
            this.pnlButton.Controls.Add(this.btnMakeSet);
            this.pnlButton.Controls.Add(this.pbxCopy);
            this.pnlButton.Controls.Add(this.btnMixCancel);
            this.pnlButton.Controls.Add(this.btnMix);
            this.pnlButton.Controls.Add(this.btnPaste);
            this.pnlButton.Controls.Add(this.btnCopy);
            this.pnlButton.Controls.Add(this.btnList);
            this.pnlButton.DrawBorder = true;
            this.pnlButton.Font = null;
            this.pnlButton.Name = "pnlButton";
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
            // btnHopeDateIlgwal
            // 
            this.btnHopeDateIlgwal.AccessibleDescription = null;
            this.btnHopeDateIlgwal.AccessibleName = null;
            resources.ApplyResources(this.btnHopeDateIlgwal, "btnHopeDateIlgwal");
            this.btnHopeDateIlgwal.BackgroundImage = null;
            this.btnHopeDateIlgwal.Image = ((System.Drawing.Image)(resources.GetObject("btnHopeDateIlgwal.Image")));
            this.btnHopeDateIlgwal.Name = "btnHopeDateIlgwal";
            this.btnHopeDateIlgwal.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnHopeDateIlgwal.Click += new System.EventHandler(this.btnHopeDateIlgwal_Click);
            // 
            // btnIlgwalChange
            // 
            this.btnIlgwalChange.AccessibleDescription = null;
            this.btnIlgwalChange.AccessibleName = null;
            resources.ApplyResources(this.btnIlgwalChange, "btnIlgwalChange");
            this.btnIlgwalChange.BackgroundImage = null;
            this.btnIlgwalChange.Image = ((System.Drawing.Image)(resources.GetObject("btnIlgwalChange.Image")));
            this.btnIlgwalChange.Name = "btnIlgwalChange";
            this.btnIlgwalChange.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnIlgwalChange.Click += new System.EventHandler(this.btnIlgwalChange_Click);
            // 
            // btnMakeSet
            // 
            this.btnMakeSet.AccessibleDescription = null;
            this.btnMakeSet.AccessibleName = null;
            resources.ApplyResources(this.btnMakeSet, "btnMakeSet");
            this.btnMakeSet.BackgroundImage = null;
            this.btnMakeSet.Image = ((System.Drawing.Image)(resources.GetObject("btnMakeSet.Image")));
            this.btnMakeSet.Name = "btnMakeSet";
            this.btnMakeSet.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnMakeSet.Click += new System.EventHandler(this.btnMakeSet_Click);
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
            // btnMixCancel
            // 
            this.btnMixCancel.AccessibleDescription = null;
            this.btnMixCancel.AccessibleName = null;
            resources.ApplyResources(this.btnMixCancel, "btnMixCancel");
            this.btnMixCancel.BackgroundImage = null;
            this.btnMixCancel.ImageIndex = 6;
            this.btnMixCancel.Name = "btnMixCancel";
            this.btnMixCancel.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnMixCancel.Click += new System.EventHandler(this.btnMixCancel_Click);
            // 
            // btnMix
            // 
            this.btnMix.AccessibleDescription = null;
            this.btnMix.AccessibleName = null;
            resources.ApplyResources(this.btnMix, "btnMix");
            this.btnMix.BackgroundImage = null;
            this.btnMix.ImageIndex = 5;
            this.btnMix.Name = "btnMix";
            this.btnMix.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnMix.Click += new System.EventHandler(this.btnMix_Click);
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
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_insert, -1, global::IHIS.OCSA.Properties.Resources.btn_insert),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_delete, -1, global::IHIS.OCSA.Properties.Resources.btn_delete),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_process, -1, global::IHIS.OCSA.Properties.Resources.btn_process),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_cancel, -1, global::IHIS.OCSA.Properties.Resources.btn_cancel),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_update, -1, global::IHIS.OCSA.Properties.Resources.btn_update),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.OCSA.Properties.Resources.btn_close, -1, global::IHIS.OCSA.Properties.Resources.btn_close)});
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
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell60.CellName = "acting_day";
            this.xEditGridCell60.Col = 28;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.Row = 1;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // OCS0103U10
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlTop);
            this.Name = "OCS0103U10";
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
        private IHIS.Framework.XButton btnCopy;
        private IHIS.Framework.XButton btnMixCancel;
        private IHIS.Framework.XButton btnMix;
        private IHIS.Framework.XButton btnPaste;
        private PictureBox pbxCopy;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XButton btnMakeSet;
        private IHIS.Framework.XButton btnChangeWonyoi;
        private IHIS.Framework.XButton btnIlgwalChange;
        private IHIS.Framework.XButton btnHopeDateIlgwal;
        private UCOCS0103U10 mainControl;
        private XFlatLabel xFlatLabel1;
        private IHIS.Framework.XButton btnCut;

        #endregion

        #region Constructor
        public OCS0103U10()
        {
           // MessageBox.Show("Constructor start");

            InitializeComponent();

            this.mainControl = new IHIS.OCSA.UCOCS0103U10();
            this.pnlFill.Controls.Add(this.mainControl);
            this.mainControl.Name = "OCS0103U10";
            this.mainControl.Dock = DockStyle.Fill;
            this.mainControl.Location = new Point(0, 0);
            this.mainControl.Size = new Size(1200, 531);


            this.mainControl.MContainer = this;
            this.mainControl.MPnlTop = this.pnlTop;
            this.mainControl.MBtnList = this.btnList;
            this.mainControl.MBtnCopy = this.btnCopy;
            this.mainControl.MBtnPaste = this.btnPaste;
            this.mainControl.MBtnMix = this.btnMix;
            this.mainControl.MBtnMixCancel = this.btnMixCancel;
            this.mainControl.MBtnChangeWonyoi = this.btnChangeWonyoi;
            //this.mainControl.MDbxWonyoiOrderYn = this.dbxWonyoiOrderYN;
            this.mainControl.MPbxCopy = this.pbxCopy;    

            // MessageBox.Show("Constructor end");

            //MED6991
            InitializeLookAndFeel();
        }
        private bool isCheckOutHospCode = true;

        private void InitializeLookAndFeel()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                dbxInputGubunName.Width += 10;
            }
        }
        #endregion

        public override object Command(string command, CommonItemCollection commandParam)
        {
            return this.mainControl.Command(command, commandParam);
        }
    
        #region Events

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender == null) return;

            if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.Control) // 마우스오른쪽클릭 + Ctrl Key 입력시 
            {
                if (this.CurrMQLayout != null) this.mainControl.MOrderBiz.GridDisplayValue((XGrid)this.CurrMQLayout); // 현재 Current Row의 모든 값을 디스플레이한다 
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            this.mainControl.HandleBtnListClick(e.Func);
            e.IsBaseCall = false;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnPasteClick();
        }

        private void btnMix_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnMixClick();
        }

        private void btnMixCancel_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnMixCancelClick();
        }

        private void btnMakeSet_Click(object sender, EventArgs e)
        {
            this.mainControl.btnMakeSet_Click(sender, e);
        }

        private void btnIlgwalChange_Click(object sender, EventArgs e)
        {
            this.mainControl.btnIlgwalChange_Click(sender, e);
        }

        private void btnHopeDateIlgwal_Click(object sender, EventArgs e)
        {
            this.mainControl.btnHopeDateIlgwal_Click(sender, e);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(false);
        }
        private void btnCut_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(true);
        }

        private void OCS0103U10_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            string inputGubunName = null;
            string mDefaultWonyoiOrder = this.mainControl.ScreenOpen(this.OpenParam, ref inputGubunName);
            this.mainControl.MOpener = (XScreen)this.Opener;
            this.mainControl.ParentControl = this;
            if (this.OpenParam != null)
            {
                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;
                if (inputGubunName != null)
                    this.dbxInputGubunName.SetDataValue("【 " + inputGubunName + " 】");

                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }

                // 환자정보
                if (this.OpenParam.Contains("patient_info"))
                {
                    // 환자정보가 있으면 이거 가져다 넣어주ㅝ야 함.
                    this.SetPatientInfo();
                }
            }

            if (this.OpenParam != null && this.OpenParam.Contains("order_date"))
            {
                if (dpkOrder_Date != null)
                    dpkOrder_Date.SetDataValue(this.OpenParam["order_date"].ToString());
            }
            else
            {
                dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            }
            mainControl.SetEventCbxWonyoiOrderYN(false);
            mainControl.SetCbxWonyoiOrderYN(mDefaultWonyoiOrder);
            mainControl.ActionSelectGroupTab();
            mainControl.SetEventCbxWonyoiOrderYN(true);
            if (mDefaultWonyoiOrder == "Y")
            {
                //this.dbxWonyoiOrderYN.SetDataValue(Resources.TXT_00001);
                //this.btnChangeWonyoi.Text = Resources.TXT_00003;
               // this.dbxWonyoiOrderYN.SetDataValue(Resources.TXT_00003);
               // this.btnChangeWonyoi.Text = Resources.TXT_00001;
                this.btnChangeWonyoi.Text = Resources.TXT_00002;
            }
            else
            {
               // this.dbxWonyoiOrderYN.SetDataValue(Resources.TXT_00004);
                //this.btnChangeWonyoi.Text = Resources.TXT_00002;
                this.btnChangeWonyoi.Text = Resources.TXT_00001;
            }

            // 오더일자와 환자번호는 변경할수 없도록 프로텍트 처리
            this.dpkOrder_Date.Protect = true;
            this.fbxBunho.Protect = true;
        }

        /// <summary>
        /// 환자정보 라벨 셋팅
        /// </summary>
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

        private void OCS0103U10_Closing(object sender, CancelEventArgs e)
        {
            //string mbxMsg = "", mbxCap = "";

            //// 변경된 내용체크
            //foreach (DataRow dr in this.grdOrder.LayoutTable.Rows)
            //{
            //    if (dr.RowState != DataRowState.Unchanged)
            //    {
            //        this.mbxMsg = "変更されたデータが存在します。保存後画面を閉じますか?";
            //        this.mbxCap = "保存確認";

            //        if (XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //        {
            //            handeBtnListClick(FunctionType.Update);
            //            return;
            //        }
            //    }
            //}

            //if (grdDrgOrder.DeletedRowCount > 0)
            //{
            //    this.mbxMsg = "変更されたデータが存在します。保存後画面を閉じますか?";
            //    this.mbxCap = "保存確認";

            //    if (XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        handeBtnListClick(FunctionType.Update);
            //        return;
            //    }
            //}

            // 처방 변경된 자료가 있는 경우 자료 Reset됨을 알림
            // 처방 입력가능여부 이면서 자료 수정여부 체크
            //if (this.IsOrderInputCheck(false, true, false) && this.IsOrderDataModifed())
            //{
            //    mbxMsg = "저장하지 않은 데이타가 존재합니다.\r\n외래처방을 종료하시겠습니까?";
            //    mbxCap = "종료여부";
            //    if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            // 종료 버튼등 클릭여부 Validation Check 안하기 위함
            // Control의 Validation 체크에 의하여 종료가 안되는 것을 푼다... (중요)
            e.Cancel = false;
        }

        public void ChangWonyoi(string wonyoiOrder)
        {
            if (wonyoiOrder == "Y")
            {
                //this.dbxWonyoiOrderYN.SetDataValue(Resources.TXT_00001);
                this.btnChangeWonyoi.Text = Resources.TXT_00003;
            }
            else
            {
                //this.dbxWonyoiOrderYN.SetDataValue(Resources.TXT_00002);
                this.btnChangeWonyoi.Text = Resources.TXT_00004;
            }
        }

        private void btnChangeWonyoi_Click(object sender, EventArgs e)
        {            
            this.mainControl.HandleBtnChangeWonyoiClick();                
        }
        #endregion
    }
}
