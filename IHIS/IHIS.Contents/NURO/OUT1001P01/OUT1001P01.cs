#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.Framework;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Results.System;

#endregion

namespace IHIS.NURO
{
    /// <summary>
    /// OUT1001P01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OUT1001P01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGrid grdOUT1001;
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
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XDatePicker dtpNaewonDate;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPictureBox xPictureBox1;
        private IHIS.Framework.XPictureBox xPictureBox2;
        private IHIS.Framework.XPictureBox xPictureBox3;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XDisplayBox dbxFromGwaName;
        private IHIS.Framework.XDisplayBox dbxFromDoctorName;
        private IHIS.Framework.XFindBox fbxToGwa;
        private IHIS.Framework.XDisplayBox dbxToGwaName;
        private IHIS.Framework.XDisplayBox dbxToDoctorName;
        private IHIS.Framework.XFindBox fbxToDoctor;
        private IHIS.Framework.XDisplayBox dbxFromGwa;
        private IHIS.Framework.XDisplayBox dbxFromDoctor;
        private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.XPanel pnlToControl;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OUT1001P01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdOUT1001.ExecuteQuery = GetDataForGrdOUT1001;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT1001P01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dtpNaewonDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdOUT1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.dbxFromGwa = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.dbxFromGwaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.dbxFromDoctor = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.dbxFromDoctorName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.fbxToGwa = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.dbxToGwaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.fbxToDoctor = new IHIS.Framework.XFindBox();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.dbxToDoctorName = new IHIS.Framework.XDisplayBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPictureBox3 = new IHIS.Framework.XPictureBox();
            this.xPictureBox2 = new IHIS.Framework.XPictureBox();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.pnlToControl = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            this.pnlToControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.paBox);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackgroundImage = null;
            this.paBox.Font = null;
            this.paBox.Name = "paBox";
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.dtpNaewonDate);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // dtpNaewonDate
            // 
            this.dtpNaewonDate.AccessibleDescription = null;
            this.dtpNaewonDate.AccessibleName = null;
            resources.ApplyResources(this.dtpNaewonDate, "dtpNaewonDate");
            this.dtpNaewonDate.BackgroundImage = null;
            this.dtpNaewonDate.Font = null;
            this.dtpNaewonDate.IsVietnameseYearType = false;
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = null;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // grdOUT1001
            // 
            resources.ApplyResources(this.grdOUT1001, "grdOUT1001");
            this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell11});
            this.grdOUT1001.ColPerLine = 3;
            this.grdOUT1001.Cols = 4;
            this.grdOUT1001.ControlBinding = true;
            this.grdOUT1001.ExecuteQuery = null;
            this.grdOUT1001.FixedCols = 1;
            this.grdOUT1001.FixedRows = 1;
            this.grdOUT1001.HeaderHeights.Add(29);
            this.grdOUT1001.Name = "grdOUT1001";
            this.grdOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT1001.ParamList")));
            this.grdOUT1001.QuerySQL = resources.GetString("grdOUT1001.QuerySQL");
            this.grdOUT1001.ReadOnly = true;
            this.grdOUT1001.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdOUT1001.RowHeaderVisible = true;
            this.grdOUT1001.Rows = 2;
            this.grdOUT1001.ToolTipActive = true;
            this.grdOUT1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOUT1001_RowFocusChanged);
            this.grdOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT1001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pkout1001";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.dbxFromGwa;
            this.xEditGridCell3.CellName = "gwa";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // dbxFromGwa
            // 
            this.dbxFromGwa.AccessibleDescription = null;
            this.dbxFromGwa.AccessibleName = null;
            resources.ApplyResources(this.dbxFromGwa, "dbxFromGwa");
            this.dbxFromGwa.Font = null;
            this.dbxFromGwa.Image = null;
            this.dbxFromGwa.Name = "dbxFromGwa";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.dbxFromGwaName;
            this.xEditGridCell4.CellName = "gwa_name";
            this.xEditGridCell4.CellWidth = 91;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // dbxFromGwaName
            // 
            this.dbxFromGwaName.AccessibleDescription = null;
            this.dbxFromGwaName.AccessibleName = null;
            resources.ApplyResources(this.dbxFromGwaName, "dbxFromGwaName");
            this.dbxFromGwaName.Font = null;
            this.dbxFromGwaName.Image = null;
            this.dbxFromGwaName.Name = "dbxFromGwaName";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.dbxFromDoctor;
            this.xEditGridCell5.CellName = "doctor";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // dbxFromDoctor
            // 
            this.dbxFromDoctor.AccessibleDescription = null;
            this.dbxFromDoctor.AccessibleName = null;
            resources.ApplyResources(this.dbxFromDoctor, "dbxFromDoctor");
            this.dbxFromDoctor.Font = null;
            this.dbxFromDoctor.Image = null;
            this.dbxFromDoctor.Name = "dbxFromDoctor";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.dbxFromDoctorName;
            this.xEditGridCell6.CellName = "doctor_name";
            this.xEditGridCell6.CellWidth = 108;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdCol = false;
            // 
            // dbxFromDoctorName
            // 
            this.dbxFromDoctorName.AccessibleDescription = null;
            this.dbxFromDoctorName.AccessibleName = null;
            resources.ApplyResources(this.dbxFromDoctorName, "dbxFromDoctorName");
            this.dbxFromDoctorName.Font = null;
            this.dbxFromDoctorName.Image = null;
            this.dbxFromDoctorName.Name = "dbxFromDoctorName";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jubsu_no";
            this.xEditGridCell7.CellWidth = 76;
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.BindControl = this.fbxToGwa;
            this.xEditGridCell8.CellName = "to_gwa";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // fbxToGwa
            // 
            this.fbxToGwa.AccessibleDescription = null;
            this.fbxToGwa.AccessibleName = null;
            resources.ApplyResources(this.fbxToGwa, "fbxToGwa");
            this.fbxToGwa.ApplyByteLimit = true;
            this.fbxToGwa.AutoTabDataSelected = true;
            this.fbxToGwa.BackgroundImage = null;
            this.fbxToGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxToGwa.FindWorker = this.fwkCommon;
            this.fbxToGwa.Font = null;
            this.fbxToGwa.Name = "fbxToGwa";
            this.fbxToGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxToGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.BindControl = this.dbxToGwaName;
            this.xEditGridCell9.CellName = "to_gwa_name";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdCol = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // dbxToGwaName
            // 
            this.dbxToGwaName.AccessibleDescription = null;
            this.dbxToGwaName.AccessibleName = null;
            resources.ApplyResources(this.dbxToGwaName, "dbxToGwaName");
            this.dbxToGwaName.Font = null;
            this.dbxToGwaName.Image = null;
            this.dbxToGwaName.Name = "dbxToGwaName";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.BindControl = this.fbxToDoctor;
            this.xEditGridCell10.CellName = "to_doctor";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // fbxToDoctor
            // 
            this.fbxToDoctor.AccessibleDescription = null;
            this.fbxToDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxToDoctor, "fbxToDoctor");
            this.fbxToDoctor.ApplyByteLimit = true;
            this.fbxToDoctor.AutoTabDataSelected = true;
            this.fbxToDoctor.BackgroundImage = null;
            this.fbxToDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxToDoctor.FindWorker = this.fwkCommon;
            this.fbxToDoctor.Font = null;
            this.fbxToDoctor.Name = "fbxToDoctor";
            this.fbxToDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxToDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.BindControl = this.dbxToDoctorName;
            this.xEditGridCell11.CellName = "to_doctor_name";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsUpdCol = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // dbxToDoctorName
            // 
            this.dbxToDoctorName.AccessibleDescription = null;
            this.dbxToDoctorName.AccessibleName = null;
            resources.ApplyResources(this.dbxToDoctorName, "dbxToDoctorName");
            this.dbxToDoctorName.Font = null;
            this.dbxToDoctorName.Image = null;
            this.dbxToDoctorName.Name = "dbxToDoctorName";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel3.Controls.Add(this.dbxFromDoctor);
            this.xPanel3.Controls.Add(this.dbxFromGwa);
            this.xPanel3.Controls.Add(this.dbxFromDoctorName);
            this.xPanel3.Controls.Add(this.dbxFromGwaName);
            this.xPanel3.Controls.Add(this.xLabel5);
            this.xPanel3.Controls.Add(this.xLabel4);
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Font = null;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Font = null;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, Resources.BTN_PROCESS_TEXT, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel4.Controls.Add(this.xPictureBox3);
            this.xPanel4.Controls.Add(this.xPictureBox2);
            this.xPanel4.Controls.Add(this.xPictureBox1);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // xPictureBox3
            // 
            this.xPictureBox3.AccessibleDescription = null;
            this.xPictureBox3.AccessibleName = null;
            resources.ApplyResources(this.xPictureBox3, "xPictureBox3");
            this.xPictureBox3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPictureBox3.BackgroundImage = null;
            this.xPictureBox3.Font = null;
            this.xPictureBox3.ImageLocation = null;
            this.xPictureBox3.Name = "xPictureBox3";
            this.xPictureBox3.Protect = false;
            this.xPictureBox3.TabStop = false;
            // 
            // xPictureBox2
            // 
            this.xPictureBox2.AccessibleDescription = null;
            this.xPictureBox2.AccessibleName = null;
            resources.ApplyResources(this.xPictureBox2, "xPictureBox2");
            this.xPictureBox2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPictureBox2.BackgroundImage = null;
            this.xPictureBox2.Font = null;
            this.xPictureBox2.ImageLocation = null;
            this.xPictureBox2.Name = "xPictureBox2";
            this.xPictureBox2.Protect = false;
            this.xPictureBox2.TabStop = false;
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.AccessibleDescription = null;
            this.xPictureBox1.AccessibleName = null;
            resources.ApplyResources(this.xPictureBox1, "xPictureBox1");
            this.xPictureBox1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPictureBox1.BackgroundImage = null;
            this.xPictureBox1.Font = null;
            this.xPictureBox1.ImageLocation = null;
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.TabStop = false;
            // 
            // pnlToControl
            // 
            this.pnlToControl.AccessibleDescription = null;
            this.pnlToControl.AccessibleName = null;
            resources.ApplyResources(this.pnlToControl, "pnlToControl");
            this.pnlToControl.BackgroundImage = null;
            this.pnlToControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToControl.Controls.Add(this.dbxToDoctorName);
            this.pnlToControl.Controls.Add(this.fbxToDoctor);
            this.pnlToControl.Controls.Add(this.dbxToGwaName);
            this.pnlToControl.Controls.Add(this.fbxToGwa);
            this.pnlToControl.Controls.Add(this.xLabel6);
            this.pnlToControl.Controls.Add(this.xLabel7);
            this.pnlToControl.Controls.Add(this.xLabel3);
            this.pnlToControl.Font = null;
            this.pnlToControl.Name = "pnlToControl";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Font = null;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Font = null;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // OUT1001P01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlToControl);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.grdOUT1001);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "OUT1001P01";
            this.Load += new System.EventHandler(this.OUT1001P01_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT1001P01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            this.pnlToControl.ResumeLayout(false);
            this.pnlToControl.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Screen 변수

        private string mMsg = "";
        private string mCap = "";
        private string mHospCode = EnvironInfo.HospCode;
        private string mpkout1001 = string.Empty;

        #endregion

        #region Screen Load

        private void OUT1001P01_Load(object sender, System.EventArgs e)
        {
            this.ControlProtect(true);
            this.InitScreen();
        }

        #endregion

        #region Function

        #region InitScreen
        private void InitScreen()
        {
            if (this.OpenParam == null)
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
            }
            this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        #region Control Protect

        private void ControlProtect(bool aIsProtect)
        {
            foreach (Control control in this.pnlToControl.Controls)
            {
                if (control is IDataControl)
                {
                    ((IDataControl)control).Protect = aIsProtect;
                }
            }
        }

        #endregion

        #endregion

        //#region LoadData

        //private void LoadData (string aBunho, string aNaewonDate)
        //{
        //    if (TypeCheck.IsNull(aBunho)) return;
        //    if (TypeCheck.IsNull(aNaewonDate)) return;

        //    this.grdOUT1001.SetBindVarValue("f_bunho",       aBunho);
        //    this.grdOUT1001.SetBindVarValue("f_naewon_date", aNaewonDate);
        //    this.grdOUT1001.SetBindVarValue("f_hosp_code",   EnvironInfo.HospCode);

        //    this.grdOUT1001.QueryLayout(false);

        //    if (this.grdOUT1001.RowCount <= 0)
        //        this.grdOUT1001.Reset();

        //}

        //#endregion

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);

            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo))
            {
                return new XPatientInfo(this.paBox.BunHo, this.paBox.SuName, "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

        #region 업데이트

        private bool CheckUpdateData()
        {
            this.mCap = Resources.MSG001_CAP;

            foreach (DataRow dr in this.grdOUT1001.LayoutTable.Rows)
            {
                //2015/08/17: disable due to bug MED-3602
                //if (dr.RowState != DataRowState.Unchanged)
                //{
                    if (dr["to_gwa"].ToString() == "")
                    {
                        this.mMsg = Resources.MSG001_MSG_1;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }

                    if (dr["to_doctor"].ToString() == "")
                    {
                        this.mMsg = Resources.MSG001_MSG_2;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                //}
            }

            return true;
        }

        private bool UpdateData()
        {
            this.mCap = Resources.MSG001_CAP;

            if (ProcessUpdate() == true)
            {
                this.mMsg = Resources.MSG002_MSG_1;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {
                this.mMsg = Resources.MSG002_MSG_2;
                //this.mMsg += "-" + Service.ErrFullMsg;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        #endregion

        #region ProcessUpdate
        private bool ProcessUpdate()
        {
            //ArrayList inputList = new ArrayList();
            //ArrayList outputList = new ArrayList();

            //inputList.Add(grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "bunho"));
            //inputList.Add(grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pkout1001"));
            //inputList.Add(grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "to_gwa"));
            //inputList.Add(grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "to_doctor"));
            //inputList.Add(UserInfo.UserID);

            //if (!Service.ExecuteProcedure("PR_OUT_CHANGE_GWA_DOCTOR", inputList, outputList))
            //{
            //    return false;
            //}

            //// 접수정보를 확인할 수 없습니다.
            //if (outputList[0].ToString() == "JUBSU NOT FOUND")
            //{
            //    MessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            //return true;

            //tungtx
            OUT1001P01PrOutChangeGwaDoctorArgs args = new OUT1001P01PrOutChangeGwaDoctorArgs();
            args.Bunho = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "bunho");
            args.Pkout1001 = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "pkout1001");
            args.Gwa = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "to_gwa");
            args.Doctor = grdOUT1001.GetItemString(grdOUT1001.CurrentRowNumber, "to_doctor");
            args.UserId = UserInfo.UserID;

            UpdateResult result =
                CloudService.Instance.Submit<UpdateResult, OUT1001P01PrOutChangeGwaDoctorArgs>(
                    args);

            if (result.Msg == "JUBSU NOT FOUND")
            {
                MessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region XButtonList

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //case FunctionType.Query : 

                //    e.IsBaseCall = false;

                //    this.LoadData(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());

                //    break;

                case FunctionType.Process:

                    e.IsBaseCall = false;

                    this.mMsg = Resources.MSG003_MSG;
                    this.mCap = Resources.MSG001_CAP;

                    if (XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    this.AcceptData();

                    if (this.CheckUpdateData())
                    {
                        if (this.UpdateData())
                        {
                            this.btnList.PerformClick(FunctionType.Query);
                        }
                    }

                    break;

                case FunctionType.Reset:

                    e.IsBaseCall = false;

                    this.Reset();

                    this.InitScreen();

                    this.ControlProtect(true);

                    this.paBox.Focus();

                    break;
            }
        }

        #endregion

        #region XPatientBox

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Reset);
        }

        #endregion

       

        #region XFindBox
        
        private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            switch (control.Name)
            {
                case "fbxToGwa":

                    #region 변경후 진료과

                    //                    this.fwkCommon.InputSQL = @"SELECT A.GWA
                    //                                                     , A.GWA_NAME
                    //                                                     , A.BUSEO_CODE
                    //                                                  FROM BAS0260 A
                    //                                                 WHERE A.HOSP_CODE = :f_hosp_code
                    //                                                   AND A.BUSEO_GUBUN = '1'
                    //                                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
                    //                                                                          FROM BAS0260 B
                    //                                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
                    //                                                                           AND B.GWA         = A.GWA
                    //                                                                           AND B.START_DATE <= :f_start_date)
                    //                                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_start_date
                    //                                                   AND(A.GWA       LIKE '%' || :f_find1 || '%'
                    //                                                    OR A.GWA_NAME  LIKE '%' || :f_find1 || '%')
                    //                                                 ORDER BY A.GWA";


                    //this.fwkCommon.SetBindVarValue("f_start_date", this.dtpNaewonDate.GetDataValue());
                    //this.fwkCommon.SetBindVarValue("f_hosp_code", mHospCode);

                    fwkCommon.ParamList = new List<string>(new String[] { "f_buseo_ymd", "f_find1" });

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", this.mHospCode);
                    fwkCommon.BindVarList.Add("f_buseo_ymd", this.dtpNaewonDate.GetDataValue());

                    fwkCommon.ExecuteQuery = xFindWorker_GetDepartment;

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_1_TEXT, FindColType.String, 80, 0, true, FilterType.Yes);
                    this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_1_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    #endregion

                    break;

                case "fbxToDoctor":

                    #region 변경후 진료의

                    //                    this.fwkCommon.InputSQL = @"SELECT A.DOCTOR
                    //                                                     , A.DOCTOR_NAME
                    //                                                     , A.SORT_KEY || A.DOCTOR            CONT_KEY
                    //                                                  FROM BAS0270 A
                    //                                                 WHERE A.HOSP_CODE = :f_hosp_code
                    //                                                   AND DECODE(:f_gwa, '%', '%', A.DOCTOR_GWA)   = :f_gwa
                    //                                                   AND  (A.DOCTOR       LIKE '%' || :f_find1 || '%'
                    //                                                           OR A.DOCTOR_NAME  LIKE '%' || :f_find1 || '%')
                    //                                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
                    //                                                                          FROM BAS0270 B
                    //                                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
                    //                                                                           AND B.DOCTOR      = A.DOCTOR
                    //                                                                           AND B.START_DATE <= :f_doctor_ymd)
                    //                                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_doctor_ymd                                                   
                    //                                                 ORDER BY CONT_KEY";
                    fwkCommon.ParamList = new List<string>(new String[] { "f_gwa", "f_naewon_date", "f_find1" });
                    fwkCommon.BindVarList.Clear();

                    //if(fbxToGwa.GetDataValue() != "")
                    //    this.fwkCommon.SetBindVarValue("f_gwa", fbxToGwa.GetDataValue());
                    //else
                    //    this.fwkCommon.SetBindVarValue("f_gwa", "%");
                    //this.fwkCommon.SetBindVarValue("f_doctor_ymd", this.dtpNaewonDate.GetDataValue());
                    this.fwkCommon.BindVarList.Add("f_gwa", fbxToGwa.GetDataValue());
                    this.fwkCommon.BindVarList.Add("f_naewon_date", this.dtpNaewonDate.GetDataValue());
                    this.fwkCommon.BindVarList.Add("f_hosp_code", mHospCode);
                    fwkCommon.ExecuteQuery = xFindWorker_GetDoctor;

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("code", Resources.FWKCOMMON_CODE_2_TEXT, FindColType.String, 80, 0, true, FilterType.Yes);
                    this.fwkCommon.ColInfos.Add("code_name", Resources.FWKCOMMON_CODE_NAME_2_TEXT, FindColType.String, 200, 0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    #endregion

                    break;
            }
        }

        private void FindBox_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            object name = null;
            //string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();

            switch (control.Name)
            {
                case "fbxToGwa":

                    if (e.DataValue == "")
                    {
                        this.dbxToGwaName.SetDataValue("");
                        this.grdOUT1001.SetItemValue(grdOUT1001.CurrentRowNumber, "to_gwa_name", "");
                        this.fbxToDoctor.SetEditValue("");
                        this.fbxToDoctor.AcceptData();

                        this.SetMsg("");

                        return;
                    }

                    //                    cmdText = @"SELECT A.GWA_NAME
                    //                                  FROM BAS0260 A
                    //                                 WHERE A.HOSP_CODE = :f_hosp_code
                    //                                   AND A.BUSEO_GUBUN = '1'
                    //                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
                    //                                                          FROM BAS0260 B
                    //                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
                    //                                                           AND B.GWA         = A.GWA
                    //                                                           AND B.START_DATE <= :f_start_date)
                    //                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_start_date
                    //                                   AND(A.GWA       LIKE '%' || :f_find1 || '%'
                    //                                    OR A.GWA_NAME  LIKE '%' || :f_find1 || '%')
                    //                                 ORDER BY A.GWA";
                    //                    bindVars.Add("f_start_date", dtpNaewonDate.GetDataValue());
                    //                    bindVars.Add("f_find1", e.DataValue);
                    //                    bindVars.Add("f_hosp_code", mHospCode);
                    //                    name = Service.ExecuteScalar(cmdText, bindVars);



                    OUT1001P01FindboxValidatingArgs args = new OUT1001P01FindboxValidatingArgs();
                    args.ControlName = "fbxToGwa";
                    args.StartDate = dtpNaewonDate.GetDataValue();
                    args.Find1 = e.DataValue;


                    OUT1001P01FindboxValidatingResult result =
                        CloudService.Instance.Submit<OUT1001P01FindboxValidatingResult, OUT1001P01FindboxValidatingArgs>(
                            args);
                    if (result != null)
                    {
                        name = result.GwaName;
                    }

                    if (TypeCheck.IsNull(name))
                    {
                        this.mMsg = Resources.MSG004_MSG;

                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }

                    this.dbxToGwaName.SetDataValue(name.ToString());
                    this.grdOUT1001.SetItemValue(grdOUT1001.CurrentRowNumber, "to_gwa_name", name.ToString());

                    this.fbxToDoctor.SetEditValue("");
                    this.fbxToDoctor.AcceptData();

                    this.SetMsg("");

                    break;

                case "fbxToDoctor":

                    if (e.DataValue == "")
                    {
                        this.dbxToDoctorName.SetDataValue("");
                        this.grdOUT1001.SetItemValue(grdOUT1001.CurrentRowNumber, "to_doctor_name", "");

                        this.SetMsg("");

                        return;
                    }

                    //                    cmdText = @"SELECT A.DOCTOR_NAME
                    //                                  FROM BAS0270 A
                    //                                 WHERE A.HOSP_CODE = :f_hosp_code
                    //                                   AND A.DOCTOR_GWA = :f_gwa
                    //                                   AND A.DOCTOR     = :f_find1  
                    //                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
                    //                                                          FROM BAS0270 B
                    //                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
                    //                                                           AND B.DOCTOR      = A.DOCTOR
                    //                                                           AND B.START_DATE <= :f_start_date)
                    //                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_start_date
                    //                                 ORDER BY SORT_KEY";
                    //                    bindVars.Add("f_gwa", fbxToGwa.GetDataValue());
                    //                    bindVars.Add("f_find1", e.DataValue);
                    //                    bindVars.Add("f_start_date", dtpNaewonDate.GetDataValue());
                    //                    bindVars.Add("f_hosp_code", mHospCode);

                    //                    name = Service.ExecuteScalar(cmdText, bindVars);

                    OUT1001P01FindboxValidatingArgs args2 = new OUT1001P01FindboxValidatingArgs();
                    args2.ControlName = "fbxToDoctor";
                    args2.StartDate = dtpNaewonDate.GetDataValue();
                    args2.Find1 = e.DataValue;
                    args2.Gwa = fbxToGwa.GetDataValue();


                    OUT1001P01FindboxValidatingResult result2 =
                        CloudService.Instance.Submit<OUT1001P01FindboxValidatingResult, OUT1001P01FindboxValidatingArgs>(
                            args2);
                    if (result2 != null)
                    {
                        name = result2.DoctorName;
                    }

                    if (TypeCheck.IsNull(name))
                    {
                        this.mMsg = Resources.MSG005_MSG;

                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }

                    this.dbxToDoctorName.SetDataValue(name.ToString());
                    this.grdOUT1001.SetItemValue(grdOUT1001.CurrentRowNumber, "to_doctor_name", name.ToString());

                    this.SetMsg("");

                    break;
            }
        }

        #endregion

        private void grdOUT1001_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.ControlProtect(false);
        }

        private void OUT1001P01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {

            if (this.OpenParam != null)
            {
                if (OpenParam["bunho"] != null)
                {
                    this.paBox.SetPatientID(OpenParam["bunho"].ToString());
                }

                if (OpenParam["naewon_date"] != null)
                {
                    this.dtpNaewonDate.SetDataValue(OpenParam["naewon_date"]);
                    dtpNaewonDate.AcceptData();
                }

                if (OpenParam["pkout1001"] != null)
                {
                    mpkout1001 = OpenParam["pkout1001"].ToString();
                }

            }
            grdOUT1001.QueryLayout(true);            
            //fbxToGwa.Text = dbxFromGwa.Text;
            //fbxToDoctor.Text = dbxFromDoctor.Text;
            //dbxToGwaName.Text = dbxFromGwaName.Text;
            //dbxToDoctorName.Text = dbxFromDoctorName.Text;
        }

        private void grdOUT1001_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOUT1001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOUT1001.SetBindVarValue("f_bunho", paBox.BunHo);
            grdOUT1001.SetBindVarValue("f_naewon_date", dtpNaewonDate.GetDataValue());
            grdOUT1001.SetBindVarValue("f_pkout1001", mpkout1001);
        }

        private IList<object[]> GetDataForGrdOUT1001(BindVarCollection varlist)
        {
            IList<object[]> lstDataResult = new List<object[]>();
            OUT1001P01GrdOUT1001Args args = new OUT1001P01GrdOUT1001Args();
            args.Bunho = varlist["f_bunho"].VarValue;
            args.NaewonDate = varlist["f_naewon_date"].VarValue;
            args.Pkout1001 = varlist["f_pkout1001"].VarValue;
            OUT1001P01GrdOUT1001Result result =
                CloudService.Instance.Submit<OUT1001P01GrdOUT1001Result, OUT1001P01GrdOUT1001Args>(
                     args);
            if (result != null)
            {
                List<OUT1001P01GrdOUT1001ListItemInfo> grdList = result.GrdOUT1001List;
                foreach (OUT1001P01GrdOUT1001ListItemInfo info in grdList)
                {
                    object[] data =
                    {
                        info.Pkout1001,
                        info.Bunho,
                        info.Gwa,
                        info.GwaName,
                        info.Doctor,
                        info.DoctorName,
                        info.JubsuNo,
                        info.Gwa,
                        info.GwaName,
                        info.Doctor,
                        info.DoctorName

                    };
                    lstDataResult.Add(data);
                }
            }
            return lstDataResult;
        }

        private IList<object[]> xFindWorker_GetDepartment(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroOUT1001U01GetDepartmentArgs args = new NuroOUT1001U01GetDepartmentArgs(bindVarCollection["f_buseo_ymd"].VarValue, bindVarCollection["f_find1"].VarValue, "1");
            NuroOUT1001U01GetDepartmentResult result = CloudService.Instance.Submit<NuroOUT1001U01GetDepartmentResult, NuroOUT1001U01GetDepartmentArgs>(args);
            if (result != null)
            {
                IList<NuroOUT1001U01GetDepartmentInfo> lstDepartmentInfo = result.DeptItem;
                if (lstDepartmentInfo != null && lstDepartmentInfo.Count > 0)
                {
                    foreach (NuroOUT1001U01GetDepartmentInfo deptInfo in lstDepartmentInfo)
                    {
                        object[] objDeptInfo =
                        {
                            deptInfo.Gwa,
                            deptInfo.GwaName
                        };
                        lstResult.Add(objDeptInfo);
                    }

                }
            }
            return lstResult;
        }

        private IList<object[]> xFindWorker_GetDoctor(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroOUT1001U01GetDoctorArgs args = new NuroOUT1001U01GetDoctorArgs(bindVarCollection["f_naewon_date"].VarValue, bindVarCollection["f_gwa"].VarValue, bindVarCollection["f_find1"].VarValue);
            NuroOUT1001U01GetDoctorResult result =
                CloudService.Instance.Submit<NuroOUT1001U01GetDoctorResult, NuroOUT1001U01GetDoctorArgs>(args);
            if (result != null)
            {
                IList<NuroOUT1001U01GetDoctorInfo> listDoctorInfo = result.DoctorItem;
                if (listDoctorInfo != null && listDoctorInfo.Count > 0)
                {
                    foreach (NuroOUT1001U01GetDoctorInfo doctorInfo in listDoctorInfo)
                    {
                        object[] objDoctorInfo =
                        {
                            //doctorInfo.Gwa,
                            //doctorInfo.GwaName,
                            doctorInfo.Doctor, 
                            doctorInfo.DoctorName,
                            doctorInfo.Gwa,
                            doctorInfo.GwaName,
                            doctorInfo.WaitingPatient,
                            doctorInfo.TotalPatient
                        };
                        lstResult.Add(objDoctorInfo);
                    }

                }
            }
            return lstResult;
        }

    }
}

