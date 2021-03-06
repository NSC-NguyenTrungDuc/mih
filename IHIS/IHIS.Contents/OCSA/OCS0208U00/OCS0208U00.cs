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
using System.Windows.Forms.VisualStyles;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;

#endregion

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0208U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OCS0208U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]
        //Doctor
        string mDoctor = "";
        //Message처리
        string mbxMsg = "", mbxCap = "";
        // hospital code
        //string mHospCode = EnvironInfo.HospCode;
        string mHospCode = UserInfo.HospCode;

        bool isgrdOCS0208Save = false;
        bool isSaved0208 = false;
        private MultiLayout layDRG0120 = null;

        bool isClickedUPDOWN = false;

        #endregion

        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XEditGrid grdOCS0208;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
        private IHIS.Framework.XFindWorker fwkBokyong_code;
        private IHIS.Framework.XRadioButton rbtOut;
        private IHIS.Framework.XRadioButton rbtIn;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private XRadioButton rbtDonbog;
        private XButton btnUp;
        private XButton btnDown;
        private XHospBox xHospBox;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OCS0208U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            SaveLayoutList.Add(this.grdOCS0208);

            //			grdOCS0208.SavePerformer = new XSavePerformer(this);

            grdOCS0208.ParamList = CreateGrdOCS0208ParamList();
            grdOCS0208.ExecuteQuery = LoadGrdOCS0208;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS0208U00));
            this.rbtDonbog = new IHIS.Framework.XRadioButton();
            this.rbtOut = new IHIS.Framework.XRadioButton();
            this.rbtIn = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnUp = new IHIS.Framework.XButton();
            this.btnDown = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xHospBox = new IHIS.Framework.XHospBox();
            this.grdOCS0208 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.fwkBokyong_code = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            // 
            // rbtDonbog
            // 
            this.rbtDonbog.AccessibleDescription = null;
            this.rbtDonbog.AccessibleName = null;
            resources.ApplyResources(this.rbtDonbog, "rbtDonbog");
            this.rbtDonbog.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtDonbog.BackgroundImage = null;
            this.rbtDonbog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtDonbog.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtDonbog.ImageList = this.ImageList;
            this.rbtDonbog.Name = "rbtDonbog";
            this.rbtDonbog.UseVisualStyleBackColor = false;
            this.rbtDonbog.CheckedChanged += new System.EventHandler(this.rbtIn_CheckedChanged);
            // 
            // rbtOut
            // 
            this.rbtOut.AccessibleDescription = null;
            this.rbtOut.AccessibleName = null;
            resources.ApplyResources(this.rbtOut, "rbtOut");
            this.rbtOut.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaption);
            this.rbtOut.BackgroundImage = null;
            this.rbtOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOut.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.InactiveCaptionText);
            this.rbtOut.ImageList = this.ImageList;
            this.rbtOut.Name = "rbtOut";
            this.rbtOut.UseVisualStyleBackColor = false;
            this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtIn_CheckedChanged);
            // 
            // rbtIn
            // 
            this.rbtIn.AccessibleDescription = null;
            this.rbtIn.AccessibleName = null;
            resources.ApplyResources(this.rbtIn, "rbtIn");
            this.rbtIn.BackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.rbtIn.BackgroundImage = null;
            this.rbtIn.Checked = true;
            this.rbtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIn.ForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            this.rbtIn.ImageList = this.ImageList;
            this.rbtIn.Name = "rbtIn";
            this.rbtIn.TabStop = true;
            this.rbtIn.UseVisualStyleBackColor = false;
            this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtIn_CheckedChanged);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnUp);
            this.xPanel2.Controls.Add(this.btnDown);
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnUp
            // 
            this.btnUp.AccessibleDescription = null;
            this.btnUp.AccessibleName = null;
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.BackgroundImage = null;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Name = "btnUp";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.AccessibleDescription = null;
            this.btnDown.AccessibleName = null;
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.BackgroundImage = null;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Name = "btnDown";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.xHospBox);
            this.xPanel3.Controls.Add(this.rbtDonbog);
            this.xPanel3.Controls.Add(this.grdOCS0208);
            this.xPanel3.Controls.Add(this.rbtOut);
            this.xPanel3.Controls.Add(this.rbtIn);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // xHospBox
            // 
            this.xHospBox.AccessibleDescription = null;
            this.xHospBox.AccessibleName = null;
            resources.ApplyResources(this.xHospBox, "xHospBox");
            this.xHospBox.BackColor = System.Drawing.Color.Transparent;
            this.xHospBox.BackgroundImage = null;
            this.xHospBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xHospBox.HospCode = "";
            this.xHospBox.Name = "xHospBox";
            this.xHospBox.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.xHospBox_DataValidating);
            this.xHospBox.FindClick += new System.EventHandler(this.xHospBox_FindClick);
            // 
            // grdOCS0208
            // 
            resources.ApplyResources(this.grdOCS0208, "grdOCS0208");
            this.grdOCS0208.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdOCS0208.ColPerLine = 2;
            this.grdOCS0208.Cols = 2;
            this.grdOCS0208.ExecuteQuery = null;
            this.grdOCS0208.FixedRows = 1;
            this.grdOCS0208.FocusColumnName = "bogyong_code";
            this.grdOCS0208.HeaderHeights.Add(21);
            this.grdOCS0208.Name = "grdOCS0208";
            this.grdOCS0208.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS0208.ParamList")));
            this.grdOCS0208.QuerySQL = resources.GetString("grdOCS0208.QuerySQL");
            this.grdOCS0208.Rows = 2;
            this.grdOCS0208.ToolTipActive = true;
            this.grdOCS0208.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.grdOCS0208_GiveFeedback);
            this.grdOCS0208.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdOCS0208_PreSaveLayout);
            this.grdOCS0208.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS0208_GridColumnChanged);
            this.grdOCS0208.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdOCS0208_DragEnter);
            this.grdOCS0208.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS0208_MouseDown);
            this.grdOCS0208.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdOCS0208_DragDrop);
            this.grdOCS0208.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOCS0208_GridFindClick);
            this.grdOCS0208.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdOCS0208_SaveEnd);
            this.grdOCS0208.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS0208_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 5;
            this.xEditGridCell1.CellName = "doctor";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "seq";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bogyong_code";
            this.xEditGridCell3.CellWidth = 116;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 80;
            this.xEditGridCell4.CellName = "bogyong_name";
            this.xEditGridCell4.CellWidth = 323;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunryu1";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // fwkBokyong_code
            // 
            this.fwkBokyong_code.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkBokyong_code.ExecuteQuery = null;
            this.fwkBokyong_code.FormText = global::IHIS.OCSA.Properties.Resource.OCS0208U00_TCMAHDDT;
            this.fwkBokyong_code.InputSQL = "SELECT BOGYONG_CODE , BOGYONG_NAME \r\n  FROM DRG0120 A\r\n WHERE HOSP_CODE = FN_ADM_" +
                "LOAD_HOSP_CODE";
            this.fwkBokyong_code.IsSetControlText = true;
            this.fwkBokyong_code.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkBokyong_code.ParamList")));
            this.fwkBokyong_code.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkBokyong_code.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "bogyong_code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "bogyong_name";
            this.findColumnInfo2.ColWidth = 395;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // OCS0208U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Name = "OCS0208U00";
            this.UserChanged += new System.EventHandler(this.OCS0208U00_UserChanged);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS0208)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region [Screen Event]

        #region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
        public override object Command(string command, CommonItemCollection commandParam)
        {
            string bogyongCode = "";
            switch (command)
            {
                case "OCS0208Q00": //복용코드조회[내복약]
                    #region

                    if (commandParam.Contains("OCS0208"))
                    {
                        layDRG0120 = ((MultiLayout)commandParam["OCS0208"]);
                    }

                    if (layDRG0120.LayoutTable.Columns.Contains("bogyong_code"))
                    {
                        bogyongCode = layDRG0120.GetItemString(0, "bogyong_code");

                        if (this.grdOCS0208.CurrentRowNumber >= 0)
                        {
                            this.grdOCS0208.Focus();
                            this.grdOCS0208.SetFocusToItem(this.grdOCS0208.CurrentRowNumber, "bogyong_code");
                            this.grdOCS0208.SetItemValue(grdOCS0208.CurrentRowNumber, "bogyong_code", bogyongCode);
                            this.grdOCS0208.SetItemValue(grdOCS0208.CurrentRowNumber, "bogyong_name", this.GetCodeName("bogyong_code", bogyongCode));
                            this.grdOCS0208.AcceptData();
                        }
                    }
                    break;
                    #endregion

                case "OCS0208Q01": //복용코드조회[외용약]
                    #region

                    if (commandParam.Contains("bogyong_code"))
                    {
                        bogyongCode = commandParam["bogyong_code"].ToString();
                    }

                    if (this.grdOCS0208.CurrentRowNumber >= 0)
                    {
                        this.grdOCS0208.Focus();
                        this.grdOCS0208.SetFocusToItem(this.grdOCS0208.CurrentRowNumber, "bogyong_code");
                        this.grdOCS0208.SetItemValue(grdOCS0208.CurrentRowNumber, "bogyong_code", bogyongCode);
                        this.grdOCS0208.SetItemValue(grdOCS0208.CurrentRowNumber, "bogyong_name", this.GetCodeName("bogyong_code", bogyongCode));
                        this.grdOCS0208.AcceptData();
                    }

                    #endregion
                    break;
            }

            if (command == "F") return base.Command(command, commandParam);

            return base.Command(command, commandParam);
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 2015.06.23 Cloud updated START
            //this.mHospCode = "K01"; // test data
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                xHospBox.Visible = true;
                xButtonList1.SetEnabled(FunctionType.Insert, false);
                xButtonList1.SetEnabled(FunctionType.Update, false);
                xButtonList1.SetEnabled(FunctionType.Delete, false);
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                this.grdOCS0208.Height = 435;
                
            }
            else
            {
                xHospBox.Visible = false;
                this.grdOCS0208.Height = 515;
                rbtIn.Location = new Point(2,2);
                rbtOut.Location = new Point(234, 2);
                grdOCS0208.Location = new Point(0,32);

            }
            // 2015.06.23 Cloud updated END

            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0208;
            this.CurrMQLayout = this.grdOCS0208;

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            //복용구분
            grdOCS0208.SetBindVarValue("f_bunryu1", "1");

            /// 사용자 변경 Event Call /////////////////////////////////
            this.OCS0208U00_UserChanged(this, new System.EventArgs());
            /////////////////////////////////////////////////////////////
        }

        private void OCS0208U00_UserChanged(object sender, System.EventArgs e)
        {
            //의사코드를 가져온다.
            if (!LoadDoctor())
            {
                mbxMsg = NetInfo.Language == LangMode.Jr ? "使用権限がありません。ご確認ください｡" : Resource.OCS0208U00_XNKCQSD;
                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                XMessageBox.Show(mbxMsg, mbxCap);
                this.Close();
            }

            grdOCS0208.QueryLayout(true);
        }

        private bool LoadDoctor()
        {
            if (!TypeCheck.IsNull(UserInfo.UserID))
                mDoctor = UserInfo.UserID.ToString();
            grdOCS0208.SetBindVarValue("f_doctor", mDoctor);
            //의사코드를 가져온다. Load BAS0280
            return true;
        }
        #endregion

        #region [Load Code Name]
        /// <summary>
        /// 해당 코드에 대한 명을 가져옵니다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns></returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";
            string cmdText = "";
            object retVal = null;
            IHIS.Framework.BindVarCollection bindVars = new BindVarCollection();

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "bogyong_code_check":

                    /*cmdText = "SELECT FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE) BOGYONG_NAME"   
                        + "  FROM OCS0208 A "
                        + " WHERE A.DOCTOR       = :f_doctor"
                        + "   AND A.BOGYONG_CODE = :f_code";

                    bindVars.Clear();
                    bindVars.Add("f_doctor",mDoctor);
                    bindVars.Add("f_code",code);

                    retVal = Service.ExecuteScalar(cmdText,bindVars);

                    if(retVal == null)
                    {
                        codeName = "";
                    }
                    else
                        codeName = retVal.ToString();*/

                    // Cloud service
                    OcsaOCS0208U00LoadBogyongNameFromOcsArgs ocsArgs = new OcsaOCS0208U00LoadBogyongNameFromOcsArgs();
                    ocsArgs.Doctor = mDoctor;
                    ocsArgs.Code = code;
                    ocsArgs.HospCode = this.mHospCode;
                    OcsaOCS0208U00LoadBogyongNameFromOcsResult ocsResult =
                        CloudService.Instance
                            .Submit<OcsaOCS0208U00LoadBogyongNameFromOcsResult, OcsaOCS0208U00LoadBogyongNameFromOcsArgs>(ocsArgs);

                    if (ocsResult.ExecutionStatus == ExecutionStatus.Success && ocsResult.BogyongName != null)
                    {
                        codeName = ocsResult.BogyongName;
                    }

                    break;

                case "bogyong_code":

                    /*cmdText = ""
                        + " SELECT FN_OCS_LOAD_BOGYONG_NAME(A.BOGYONG_CODE) BOGYONG_NAME"
                        + " FROM DRG0120 A "
                        + " WHERE A.BOGYONG_CODE = :f_code";

                    bindVars.Clear();
                    bindVars.Add("f_code",code);
                    
                    retVal = Service.ExecuteScalar(cmdText,bindVars);

                    if(retVal == null)
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "登録されていないコードです。ご確認ください。" : Resource.OCS0208U00_XNMDK;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : Resource.OCS0208U00_XN;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                    }
                    else
                        codeName = retVal.ToString();*/

                    // Cloud service
                    OcsaOCS0208U00LoadBogyongNameFromDrgArgs drgArgs = new OcsaOCS0208U00LoadBogyongNameFromDrgArgs();
                    drgArgs.Code = code;
                    OcsaOCS0208U00LoadBogyongNameFromDrgResult drgResult =
                        CloudService.Instance
                            .Submit<OcsaOCS0208U00LoadBogyongNameFromDrgResult, OcsaOCS0208U00LoadBogyongNameFromDrgArgs>(drgArgs);

                    if (drgResult.ExecutionStatus == ExecutionStatus.Success && drgResult.BogyongName != null)
                    {
                        codeName = drgResult.BogyongName;
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "登録されていないコードです。ご確認ください。" : Resource.OCS0208U00_XNMDK;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : Resource.OCS0208U00_XN;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                    }


                    break;

                default:
                    break;
            }

            return codeName;
        }
        #endregion

        #region [Control Event]
        private void rbtIn_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbtIn.Checked)
            {
                rbtIn.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbtIn.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtIn.ImageIndex = 1;

                rbtOut.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtOut.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtOut.ImageIndex = 0;

                rbtDonbog.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtDonbog.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtDonbog.ImageIndex = 0;

                grdOCS0208.SetBindVarValue("f_bunryu1", "1");
                grdOCS0208.SetBindVarValue("f_hosp_code", mHospCode);
                grdOCS0208.SetBindVarValue("f_donbog_yn", "N");
                grdOCS0208.QueryLayout(true);
            }
            else if (rbtOut.Checked)
            {
                rbtOut.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbtOut.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtOut.ImageIndex = 1;

                rbtIn.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtIn.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtIn.ImageIndex = 0;

                rbtDonbog.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtDonbog.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtDonbog.ImageIndex = 0;

                grdOCS0208.SetBindVarValue("f_bunryu1", "6");
                grdOCS0208.SetBindVarValue("f_hosp_code", mHospCode);
                grdOCS0208.SetBindVarValue("f_donbog_yn", "N");
                grdOCS0208.QueryLayout(true);
            }
            else
            {
                rbtDonbog.BackColor = new XColor(System.Drawing.SystemColors.ActiveCaption);
                rbtDonbog.ForeColor = new XColor(System.Drawing.SystemColors.ActiveCaptionText);
                rbtDonbog.ImageIndex = 1;

                rbtIn.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtIn.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtIn.ImageIndex = 0;

                rbtOut.BackColor = new XColor(System.Drawing.SystemColors.InactiveCaption);
                rbtOut.ForeColor = new XColor(System.Drawing.SystemColors.InactiveCaptionText);
                rbtOut.ImageIndex = 0;

                grdOCS0208.SetBindVarValue("f_bunryu1", "1");
                grdOCS0208.SetBindVarValue("f_hosp_code", mHospCode);
                grdOCS0208.SetBindVarValue("f_donbog_yn", "Y");
                grdOCS0208.QueryLayout(true);
            }
        }
        #endregion

        #region {grdOCS0208 Event]
        private void grdOCS0208_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "bogyong_code":

                    if (e.ChangeValue.ToString().Trim() == "") break;

                    // 조건조회로 Data를 가져오는 경우 아래경우 다 check
                    // 중복 Check
                    // 현재 화면
                    //OcsaOCS0208U00LoadBogyongNameFromDrgResponse 
                    for (int i = 0; i < grdOCS0208.RowCount; i++)
                    {
                        //Toan comment for show add warning
                        //if (i != e.RowNumber)
                        //{
                            if (grdOCS0208.GetItemString(i, "bogyong_code").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "既に同一コードが登録されています。" : Resource.OCS0208U00_MDDK;
                                mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : Resource.OCS0208U00_XN;
                                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                        //}
                    }

                    if (e.Cancel) break;

                    // Delete Table Checkbb
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    bool deleted = false;
                    if (grdOCS0208.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdOCS0208.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                            {
                                deleted = true;
                                break;
                            }
                        }
                    }

                    if (deleted) break;

                    //Check Origin Data
                    string bogyong_name = this.GetCodeName("bogyong_code_check", e.ChangeValue.ToString());

                    if (bogyong_name != "")
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "既に同一コードが登録されています。" : Resource.OCS0208U00_MDDK;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "確認" : Resource.OCS0208U00_XN;
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }

                    //복용코드 Load
                    bogyong_name = this.GetCodeName("bogyong_code", e.ChangeValue.ToString());

                    if (bogyong_name == "")
                        e.Cancel = true;
                    else
                        grdOCS0208.SetItemValue(e.RowNumber, "bogyong_name", bogyong_name);

                    break;

                default:
                    break;
            }
        }

        private void grdOCS0208_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
        {
            if (e.ColName != "bogyong_code") return;

            CommonItemCollection openParam = new CommonItemCollection();
            openParam.Add("openSysID", "OCS0208U00");

            if (rbtIn.Checked)
            {
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q00", ScreenOpenStyle.ResponseFixed, openParam);
            }
            else
            {
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0208Q01", ScreenOpenStyle.ResponseFixed, openParam);
            }
        }

        private void grdOCS0208_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            //grdOCS0208
            for (int rowIndex = 0; rowIndex < grdOCS0208.RowCount; rowIndex++)
            {
                if (grdOCS0208.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0208.GetItemString(rowIndex, "bogyong_code").Trim() == "")
                    {
                        grdOCS0208.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                    }
                }

                if (grdOCS0208.GetItemString(rowIndex, "seq") != rowIndex.ToString()) grdOCS0208.SetItemValue(rowIndex, "seq", rowIndex + 1);
            }
        }

        private void grdOCS0208_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            isgrdOCS0208Save = e.IsSuccess;
            isSaved0208 = true;

            if (isSaved0208)
            {
                if (isgrdOCS0208Save)
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : Resource.OCS0208U00_LHT;
                    SetMsg(mbxMsg);
                }
                else
                {
                    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : Resource.OCS0208U00_LTB;
                    mbxMsg = mbxMsg + e.ErrMsg;
                    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap);
                }

                isgrdOCS0208Save = false;
                isSaved0208 = false;
            }
        }
        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)
        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }

            }

            return celReturn;
        }

        #endregion

        #region [ButtonList]
        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            SetMsg("");

            switch (e.Func)
            {
                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = grdOCS0208.InsertRow();
                        grdOCS0208.SetItemValue(currentRow, "doctor", mDoctor);
                    }
                    else
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);

                    break;

                case FunctionType.Query:
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    if(!InputValidating())
                        return;
                    if (isClickedUPDOWN)
                    {
                        for (int i = 0; i < this.grdOCS0208.RowCount; i++)
                            this.grdOCS0208.SetItemValue(i, "seq", i + 1);
                    }
                    bool success;
                    HandlePreSaveLayout(out success);
                    if(!success) break;
                    OcsaOCS0208U00SaveLayoutArgs args = new OcsaOCS0208U00SaveLayoutArgs();
                    args.GrdSaveItem = GetListDataForSaveLayout();
                    if (args.GrdSaveItem.Count == 0)
                    {
                        XMessageBox.Show(Resource.OCS0208U00_HNDL);
                        break;
                    }
                    args.UserId = UserInfo.UserID;
                    args.HospCode = this.mHospCode;
                    try
                    {
                        UpdateResult result = CloudService.Instance.Submit<UpdateResult, OcsaOCS0208U00SaveLayoutArgs>(args);
                        if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                        {
                            XMessageBox.Show(Resource.MSG_001);
                            xButtonList1.PerformClick(FunctionType.Query);
                        }
                        else
                        {
                            XMessageBox.Show(Resource.OCS0208U00_LTB);
                        }
                    }
                    catch (Exception ex)
                    {
                        //https://sofiamedix.atlassian.net/browse/MED-10610
                        //XMessageBox.Show(ex.Message);
                    }
                    grdOCS0208.QueryLayout(false);
                    break;

                default:

                    break;
            }
        }

        #endregion

        #region [XSavePerformer Class]
        /*private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private OCS0208U00 parent = null;

			public XSavePerformer(OCS0208U00 parent)
			{
				this.parent = parent;
			}

			public bool Execute(char callerID, RowDataItem item)
			{
				bool blValue = false;
				
				string cmdText = "";
				item.BindVarList.Add("f_user_id",UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

				switch(item.RowState)
				{
					case DataRowState.Added:
						cmdText = @"INSERT INTO OCS0208
                                          ( SYS_DATE
                                          , SYS_ID
                                          , DOCTOR
                                          , USER_ID
                                          , SEQ
                                          , BOGYONG_CODE
                                          , HOSP_CODE
                                          )
                                     VALUES
                                          ( SYSDATE
                                          , :f_user_id
                                          , :f_doctor
                                          , :f_user_id
                                          , :f_seq
                                          , :f_bogyong_code
                                          , :f_hosp_code
                                          )";

						blValue = Service.ExecuteNonQuery(cmdText, item.BindVarList);
						break;
					case DataRowState.Modified:
                        cmdText = @"UPDATE OCS0208 A
                                       SET SEQ = :f_seq
                                     WHERE A.HOSP_CODE    = :f_hosp_code
                                       AND A.BOGYONG_CODE = :f_bogyong_code";
                        blValue = Service.ExecuteNonQuery(cmdText, item.BindVarList);
						break;
					case DataRowState.Deleted:
						cmdText = @"DELETE OCS0208
							         WHERE DOCTOR        = :f_doctor
							           AND BOGYONG_CODE  = :f_bogyong_code
                                       AND HOSP_CODE     = :f_hosp_code";

						blValue = Service.ExecuteNonQuery(cmdText, item.BindVarList);
						break;
				}				
				
				return blValue;
			}
		}*/

        #endregion

        private void grdOCS0208_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdOCS0208.SetBindVarValue("f_bunryu1", "1");
            this.grdOCS0208.SetBindVarValue("f_donbog_yn", "N");
            this.grdOCS0208.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdOCS0208_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            int currRow = grd.GetHitRowNumber(e.Y);
            if (currRow < 0) return;
            if (grd.GetItemString(currRow, "bogyong_code") != "")
            {
                string bogyong_code_info = "[" + grd.GetItemString(currRow, "bogyong_code") + "] [" + grd.GetItemString(currRow, "bogyong_name") + "]";
                DragHelper.CreateDragCursor(grd, bogyong_code_info, this.Font);
                grd.DoDragDrop(currRow.ToString(), DragDropEffects.Move);
            }
        }

        private void grdOCS0208_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grdOCS0208_DragDrop(object sender, DragEventArgs e)
        {
            int fromRowNum = -1;
            int toRowNum = -1;

            fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
            Point clientPoint = this.grdOCS0208.PointToClient(new Point(e.X, e.Y));

            toRowNum = this.grdOCS0208.GetHitRowNumber(clientPoint.Y);

            if (fromRowNum == toRowNum || toRowNum < 0) return;

            DataRow backRow = this.grdOCS0208.LayoutTable.NewRow();


            //if (fromRowNum > toRowNum)
            //{
            //    backRow["bogyong_code"] = this.grdOCS0208.GetItemString(fromRowNum, "bogyong_code");
            //    backRow["bogyong_name"] = this.grdOCS0208.GetItemString(fromRowNum, "bogyong_name");
            //    backRow["seq"] = this.grdOCS0208.GetItemString(fromRowNum, "seq");
            //    backRow["bunryu1"] = this.grdOCS0208.GetItemString(fromRowNum, "bunryu1");
            //    backRow["doctor"] = this.grdOCS0208.GetItemString(fromRowNum, "doctor");

            //    for (int i = this.grdOCS0208.RowCount - 1; i > toRowNum; i--)
            //    {
            //        this.grdOCS0208.SetItemValue(i, "bogyong_code", this.grdOCS0208.GetItemString(i - 1, "bogyong_code"));
            //        this.grdOCS0208.SetItemValue(i, "bogyong_name", this.grdOCS0208.GetItemString(i - 1, "bogyong_name"));
            //        this.grdOCS0208.SetItemValue(i, "seq", this.grdOCS0208.GetItemString(i - 1, "seq"));
            //        this.grdOCS0208.SetItemValue(i, "bunryu1", this.grdOCS0208.GetItemString(i - 1, "bunryu1"));
            //        this.grdOCS0208.SetItemValue(i, "doctor", this.grdOCS0208.GetItemString(i - 1, "doctor"));
            //    }

            //    this.grdOCS0208.SetItemValue(toRowNum, "bogyong_code", backRow["bogyong_code"]);
            //    this.grdOCS0208.SetItemValue(toRowNum, "bogyong_name", backRow["bogyong_name"]);
            //    this.grdOCS0208.SetItemValue(toRowNum, "seq", backRow["seq"]);
            //    this.grdOCS0208.SetItemValue(toRowNum, "bunryu1", backRow["bunryu1"]);
            //    this.grdOCS0208.SetItemValue(toRowNum, "doctor", backRow["doctor"]);
            //}
            //else
            //{
            //    for (int i = this.grdOCS0208.RowCount - 1; i > toRowNum; i--)
            //    {
            //        this.grdOCS0208.SetItemValue(i, "bogyong_code", this.grdOCS0208.GetItemString(i - 1, "bogyong_code"));
            //        this.grdOCS0208.SetItemValue(i, "bogyong_name", this.grdOCS0208.GetItemString(i - 1, "bogyong_name"));
            //        this.grdOCS0208.SetItemValue(i, "seq", this.grdOCS0208.GetItemString(i - 1, "seq"));
            //        this.grdOCS0208.SetItemValue(i, "bunryu1", this.grdOCS0208.GetItemString(i - 1, "bunryu1"));
            //        this.grdOCS0208.SetItemValue(i, "doctor", this.grdOCS0208.GetItemString(i - 1, "doctor"));
            //    }
            //}

            foreach (DataColumn col in this.grdOCS0208.LayoutTable.Columns)
            {
                //swap

                //temp
                backRow[col.ColumnName] = this.grdOCS0208.GetItemString(toRowNum, col.ColumnName);
                //taget place
                this.grdOCS0208.SetItemValue(toRowNum, col.ColumnName, this.grdOCS0208.GetItemString(fromRowNum, col.ColumnName));
                //
                this.grdOCS0208.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName].ToString());
            }

            this.grdOCS0208.UnSelectAll();
            this.grdOCS0208.SelectRow(toRowNum);


        }

        #region [수식어순서 변경]

        /// <summary>
        /// 선택한 Row (from row)를 to row위치로 가져간다.
        /// </summary>
        /// <param name="grd">해당 Grid</param>
        /// <param name="fromRowNum">대상 row위치  </param>
        /// <param name="toRowNum"  >변경할 row위치</param>
        private void AlterGridRowPosition(XEditGrid grd, int fromRowNum, int toRowNum)
        {
            if (fromRowNum < 0 || toRowNum < 0 ||
                fromRowNum >= grd.RowCount || toRowNum >= grd.RowCount) return;

            int currentColNum = grd.CurrentColNumber;
            if (currentColNum == -1) currentColNum = 0;

            MultiLayout copyLay = grd.CopyToLayout();
            grd.LayoutTable.Rows.Clear();

            for (int i = 0; i < copyLay.RowCount; i++)
            {
                if (i == fromRowNum)
                    continue;

                //변경위치로 Row를 가져간다.
                if (i == toRowNum)
                {
                    if (fromRowNum < toRowNum)
                        grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);

                    grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[fromRowNum]);

                    if (fromRowNum > toRowNum)
                        grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
                }
                else
                    grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
            }

            grd.DisplayData();
            grd.SetFocusToItem(toRowNum, currentColNum);
            grd.SelectRow(toRowNum);

            //if(!dsvSave.Call())
            //{				
            //    mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다."; 
            //    mbxMsg = mbxMsg + dsvSave.ErrMsg;
            //    mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
            //    XMessageBox.Show(mbxMsg, mbxCap);
            //}

        }
        #endregion

        private void grdOCS0208_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시		
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            isClickedUPDOWN = true;

            if (grdOCS0208.CurrentRowNumber < 0) return;

            AlterGridRowPosition(grdOCS0208, grdOCS0208.CurrentRowNumber, grdOCS0208.CurrentRowNumber - 1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            isClickedUPDOWN = true;

            if (grdOCS0208.CurrentRowNumber < 0) return;

            AlterGridRowPosition(grdOCS0208, grdOCS0208.CurrentRowNumber, grdOCS0208.CurrentRowNumber + 1);
        }


        #region cloud service
        private List<string> CreateGrdOCS0208ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_doctor");
            paramList.Add("f_bunryu1");
            paramList.Add("f_donbog_yn");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0208(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsaOCS0208U00CommonDataArgs args = new OcsaOCS0208U00CommonDataArgs();
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            args.Bunryu1 = bc["f_bunryu1"] != null ? bc["f_bunryu1"].VarValue : "";
            args.HospCode = this.mHospCode;
            OcsaOCS0208U00CommonDataResult result =
                CloudService.Instance.Submit<OcsaOCS0208U00CommonDataResult, OcsaOCS0208U00CommonDataArgs>(
                    args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OcsaOCS0208U00GrdOCS0208U00ListInfo item in result.ListItem)
                {
                    object[] objects =
	                {
	                    item.Doctor,
	                    item.Seq,
	                    item.BogyongCode,
	                    item.BogyongName,
	                    item.Bunryu1
	                };
                    res.Add(objects);
                }
            }
            return res;
        }

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OcsaOCS0208U00GrdOCS0208U00ListInfo> GetListDataForSaveLayout()
        {
            List<OcsaOCS0208U00GrdOCS0208U00ListInfo> lstResult = new List<OcsaOCS0208U00GrdOCS0208U00ListInfo>();

            for (int i = 0; i < grdOCS0208.RowCount; i++)
            {
                if (grdOCS0208.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                OcsaOCS0208U00GrdOCS0208U00ListInfo item = new OcsaOCS0208U00GrdOCS0208U00ListInfo();
                item.Doctor = grdOCS0208.GetItemString(i, "doctor");
                item.Seq = grdOCS0208.GetItemString(i, "seq");
                item.BogyongCode = grdOCS0208.GetItemString(i, "bogyong_code");
                item.BogyongName = grdOCS0208.GetItemString(i, "bogyong_name");
                item.Bunryu1 = grdOCS0208.GetItemString(i, "bunryu1");

                item.DataRowState = grdOCS0208.GetRowState(i).ToString();
                lstResult.Add(item);

            }

            // Delete
            if (null != grdOCS0208.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0208.DeletedRowTable.Rows)
                {
                    OcsaOCS0208U00GrdOCS0208U00ListInfo item = new OcsaOCS0208U00GrdOCS0208U00ListInfo();
                    item.Doctor = Convert.ToString(dr["doctor"]);
                    item.BogyongCode = Convert.ToString(dr["bogyong_code"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private void HandlePreSaveLayout(out bool success)
        {
            success = true;

            // pre save handle
            for (int rowIndex = 0; rowIndex < grdOCS0208.RowCount; rowIndex++)
            {
                if (grdOCS0208.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0208.GetItemString(rowIndex, "bogyong_code").Trim() == "")
                    {
                        grdOCS0208.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;

                        success = false;
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다.";
                        mbxMsg = Resource.OCS0208U00_Lbl_Error1;
                        mbxCap = Resource.MSG_SAVE_ERROR_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap);
                        break;
                    }
                }
                else if (grdOCS0208.LayoutTable.Rows[rowIndex].RowState == DataRowState.Modified)
                {
                    string itemCheckNull = grdOCS0208.GetItemString(rowIndex, "bogyong_code");
                    if (TypeCheck.IsNull(itemCheckNull))
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다.";
                        mbxMsg = Resource.OCS0208U00_Lbl_Error1;
                        mbxCap = "Save Error";
                        XMessageBox.Show(mbxMsg, mbxCap);
                        success = false;
                        break;
                    }
                }

                if (grdOCS0208.GetItemString(rowIndex, "seq") != rowIndex.ToString()) grdOCS0208.SetItemValue(rowIndex, "seq", rowIndex + 1);
            }
        }
        #endregion

        private void xHospBox_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox.HospCode;
            grdOCS0208.QueryLayout(true);
        }

        private void xHospBox_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = e.DataValue;
                grdOCS0208.QueryLayout(true);
            }
        }
        #endregion

        private bool InputValidating()
        {
            int rowCount = grdOCS0208.RowCount;
            if (rowCount == 1) return true;
            for (int i = 0; i < rowCount; i++)
            {
                //Check existed
                if (this.CheckExist(this.grdOCS0208.GetItemString(i, "bogyong_code").ToString(), i, rowCount))
                {
                    XMessageBox.Show(Resource.SMS_VALIDATE, "", MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private bool CheckExist(string bogyongCode, int index, int length)
        {
            if (length == 1 || string.IsNullOrEmpty(bogyongCode)) return false;
            for (int i = index; i < length; i++)
            {
                for (int k = i + 1; k < this.grdOCS0208.RowCount; k++)
                {
                    if (this.grdOCS0208.GetItemString(k, "bogyong_code").ToString() == bogyongCode) return true;
                }
            }
            return false;
        }
    }
}