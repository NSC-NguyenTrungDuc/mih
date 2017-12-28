#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.XRTS.Properties;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// OCS118U에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class XRT0001U00 : IHIS.Framework.XScreen
    {
        #region Fields & Properties
        // 選択されたGRID
        private string SelectedGrid = "";
        private bool bIsSaveSuccess = true;
        private string mCaller = "";
        #endregion

        #region Constructor
        /// <summary>
        /// XRT0001U00
        /// </summary>
        public XRT0001U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            ApplyFont();
            this.SaveLayoutList.Add(this.grdXRT);
            //this.grdXRT.SavePerformer = new XSavePerformer(this);

            this.SaveLayoutList.Add(this.grdRadioList);
            //this.grdRadioList.SavePerformer = this.grdXRT.SavePerformer;

            // Updated by Cloud
            InitItemControls();
        }
        #endregion

        private void ApplyFont()
        {
            if (NetInfo.Language == LangMode.Vi || NetInfo.Language == LangMode.En)
            {
                ((System.ComponentModel.ISupportInitialize)(this.xButtonList)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdXRT)).BeginInit();

                this.grdXRT.RowHeaderFont = Service.COMMON_FONT_BOLD;
                this.grdRadioList.RowHeaderFont = Service.COMMON_FONT_BOLD;

                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell1);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell2);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell10);
                IHIS.Framework.BizCodeHelper.ApplyColumnFont(xEditGridCell23);

                ((System.ComponentModel.ISupportInitialize)(this.xButtonList)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdXRT)).EndInit();
            }
        }

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            grdXRT.RowFocusChanged += new RowFocusChangedEventHandler(grdXRT_RowFocusChanged);

            // TODO:  XRT0001U00.OnLoad 구현을 추가합니다.
            base.OnLoad(e);

            this.SelectedGrid = "M";

            if (!this.grdXRT.QueryLayout(true))
                XMessageBox.Show(Resources.XMessageBox1, Resources.caption1, MessageBoxIcon.Error);
        }

        private void txtSpYN1_TextChanged(object sender, System.EventArgs e)
        {
            if (this.txtSpYN1.Text == "Y")
            {
                this.rbnSpN1.Checked = false;
                this.rbnSpY1.Checked = true;
            }
            else if (this.txtSpYN1.Text == "N")
            {
                this.rbnSpY1.Checked = false;
                this.rbnSpN1.Checked = true;
            }
            else
            {
                this.rbnSpY1.Checked = false;
                this.rbnSpN1.Checked = false;
            }
            this.grdXRT.SetItemValue(this.grdXRT.CurrentRowNumber, "special_yn", this.txtSpYN1.Text);
        }

        private void rbnSpY1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rbnSpY1.Checked == true)
                this.txtSpYN1.Text = "Y";
        }

        private void rbnSpN1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.rbnSpN1.Checked == true)
                this.txtSpYN1.Text = "N";
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:

                    e.IsBaseCall = false;
                    e.IsSuccess = false;

                    XRT0001U00SaveLayoutArgs args = new XRT0001U00SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.SaveLayoutItem = GetListDataForSaveLayout();

                    // https://sofiamedix.atlassian.net/browse/MED-13505
                    if (args.SaveLayoutItem.Count > 0)
                    {
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, XRT0001U00SaveLayoutArgs>(args);
                        if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                        {
                            XMessageBox.Show(Resources.XMessageBox2, Resources.caption2, MessageBoxIcon.Asterisk);
                            this.grdXRT.QueryLayout(true);
                        }
                        else
                        {
                            XMessageBox.Show(Resources.XMessageBox3, Resources.caption3, MessageBoxIcon.Error);
                            this.bIsSaveSuccess = false;
                        }
                    }

                    break;

                case FunctionType.Insert://입력버튼이 클릭될때 상위마스터의 촬영코드창을 활성화시킴
                    e.IsBaseCall = false;

                    if (this.SelectedGrid.Equals("M"))
                    {
                        DataRowState RowState;

                        if (this.grdXRT.CurrentRowNumber < 0)
                        {
                            RowState = DataRowState.Unchanged;
                        }
                        else
                        {
                            RowState = this.grdXRT.LayoutTable.Rows[this.grdXRT.CurrentRowNumber].RowState;
                        }
                        if (RowState == DataRowState.Added)
                        {
                            e.IsBaseCall = false;
                        }
                        else
                        {
                            e.IsBaseCall = true;
                            this.txtXrayCode1.ReadOnly = false;
                            this.txtXrayCode1.Enabled = true;
                            this.txtXrayCode1.Focus();
                        }
                    }

                    if (this.SelectedGrid.Equals("D"))
                    {
                        //e.IsBaseCall = false;
                        this.setXrayCodeIdx();
                    }

                    break;

                case FunctionType.Query:

                    //e.IsBaseCall = false;
                    this.grdXRT.QueryLayout(true);

                    break;

                case FunctionType.Close:

                    //e.IsBaseCall = false;

                    break;

            }
        }

        private void xButtonList1_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            // https://sofiamedix.atlassian.net/browse/MED-13505
            //bIsSaveSuccess = true;
            //switch (e.Func)
            //{
            //    case FunctionType.Update:
            //        if (e.IsSuccess)
            //        {
            //            XMessageBox.Show(Resources.XMessageBox2, Resources.caption2, MessageBoxIcon.Asterisk);
            //            bIsSaveSuccess = true;

            //            this.grdXRT.QueryLayout(true);
            //        }
            //        else
            //        {
            //            XMessageBox.Show(Resources.XMessageBox3, Resources.caption3, MessageBoxIcon.Error);
            //            bIsSaveSuccess = false;
            //        }
            //        break;
            //}
        }

        private void grdXRT_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            //현재 수정중인 로우가 있다면 저장 혹은 삭제 후 이동토록 컨트롤
            try
            {
                DataRowState preRowState = this.grdXRT.LayoutTable.Rows[e.PreviousRow].RowState;
                if (preRowState == DataRowState.Added || preRowState == DataRowState.Modified)
                {
                    this.grdXRT.SetFocusToItem(e.PreviousRow, "xray_code");
                    string msg = (NetInfo.Language == LangMode.Ko ? Resources.msg_Ko
                        : Resources.msg_JP);
                    XMessageBox.Show(msg, Resources.caption4, MessageBoxIcon.Warning);
                }
            }
            catch { }

            DataRowState rowState = this.grdXRT.LayoutTable.Rows[this.grdXRT.CurrentRowNumber].RowState;
            //입력 버튼이 클릭 되었을 때만 체크
            if (rowState == DataRowState.Added)
            {
                this.txtXrayCode1.ReadOnly = false;
                this.txtXrayCode1.Enabled = true;
            }
            else
            {
                this.txtXrayCode1.ReadOnly = true;
                this.txtXrayCode1.Enabled = false;
            }

            if (this.grdXRT.GetItemString(this.grdXRT.CurrentRowNumber, "special_yn") == "Y") this.rbnSpY1.Checked = true;
            else this.rbnSpN1.Checked = true;


            this.grdRadioList.QueryLayout(false);
        }

        // 각각의 파인드 박스 컨트롤의 버튼이 클릭될때 그 컨트롤에 맞게 워커를 셋팅해 주어야 함
        private void fbxXrayGubun1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(this.fbxXrayGubun1.Name);
        }

        private void fbxXrayRoom1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(this.fbxXrayRoom1.Name);
        }

        private void fbxXrayBuwi1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(this.fbxXrayBuwi1.Name);
        }

        private void fbxModality1_FindClick(object sender, CancelEventArgs e)
        {
            this.MakeFindWorker(this.fbxModality1.Name);
        }

        private void fbxBuwiTong1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(this.fbxBuwiTong1.Name);
        }

        private void fbxReserType1_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.MakeFindWorker(this.fbxReserType1.Name);
        }

        private void txtXrayCode1_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.layDup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDup.SetBindVarValue("f_xray_code", e.DataValue);

            #region deleted by Cloud
            //this.layDup.QueryLayout();
            //if (this.layDup.GetItemValue("dup_yn").ToString() == "Y")
            //{
            //    e.Cancel = true;
            //    string msg = (NetInfo.Language == LangMode.Ko ? Resources.msg2_Ko
            //        : Resources.msg2_JP);

            //    XMessageBox.Show(e.DataValue + msg, Resources.caption4, MessageBoxIcon.Warning);
            //}
            #endregion

            // Updated by Cloud
            XRT0001U00LayDupArgs args = new XRT0001U00LayDupArgs();
            args.XrayCode = e.DataValue;
            XRT0001U00LayDupResult res = CloudService.Instance.Submit<XRT0001U00LayDupResult, XRT0001U00LayDupArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == "Y")
            {
                e.Cancel = true;
                string msg = (NetInfo.Language == LangMode.Ko ? Resources.msg2_Ko : Resources.msg2_JP);
                XMessageBox.Show(e.DataValue + msg, Resources.caption4, MessageBoxIcon.Warning);
            }
        }

        private void cbxNCard1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (this.cbxNCard1.Checked == true)
                this.txtNameCardYn.SetDataValue("Y");
            else if (this.cbxNCard1.Checked == false)
                this.txtNameCardYn.SetDataValue("N");
            else
                this.txtNameCardYn.SetDataValue("");
        }

        private void grdXRT_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdXRT.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdXRT.SetBindVarValue("f_txt_param", txtParam.GetDataValue());
            this.grdXRT.SetBindVarValue("f_xray_gubun", cbxXrayGubun.GetDataValue());

            if (this.rbxAll.Checked) this.grdXRT.SetBindVarValue("f_special_yn", "%");

            if (this.rbxSpecialY.Checked) this.grdXRT.SetBindVarValue("f_special_yn", "Y");

            if (this.rbxSpecialN.Checked) this.grdXRT.SetBindVarValue("f_special_yn", "N");
        }

        private void grdXRT_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.grdRadioList.QueryLayout(true);
        }

        private void grdRadioList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdRadioList.Reset();

            this.grdRadioList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdRadioList.SetBindVarValue("f_xray_code", this.grdXRT.GetItemString(this.grdXRT.CurrentRowNumber, "xray_code"));
        }

        private void fbx_DataValidating(object sender, DataValidatingEventArgs e)
        {
            #region deleted by Cloud
            //XFindBox fb = sender as XFindBox;
            //SingleLayoutItem item = new SingleLayoutItem();
            //item.DataName = "code_name";

            //this.vsvXRT0001.LayoutItems.Clear();

            //switch (fb.Name)
            //{
            //    case "fbxXrayGubun1":
            //        this.vsvXRT0001.QuerySQL = "select code_name from xrt0102 where hosp_code = :f_hosp_code and code_type = \'X1\' and code = :f_code";
            //        item.BindControl = txtXrayGubun1;
            //        break;
            //    case "fbxXrayRoom1":
            //        this.vsvXRT0001.QuerySQL = "select code_name from xrt0102 where hosp_code = :f_hosp_code and code_type = \'X6\' and code = :f_code";
            //        item.BindControl = txtXrayRoom1;
            //        break;
            //    case "fbxXrayBuwi1":
            //        if (e.DataValue == "")
            //            txtXrayBuwi1.SetDataValue("");
            //        this.vsvXRT0001.QuerySQL = "select buwi_name from xrt0122 where hosp_code = :f_hosp_code and buwi_code = :f_code and nvl(kaikei_yn, 'N') = 'N'";
            //        item.BindControl = txtXrayBuwi1;
            //        break;
            //    case "fbxModality1":
            //        if (e.DataValue == "")
            //            txtModality1.SetDataValue("");
            //        this.vsvXRT0001.QuerySQL = "select code_name from xrt0102 where hosp_code = :f_hosp_code and code_type = \'MO\' and code = :f_code";
            //        item.BindControl = txtModality1;
            //        break;
            //    case "fbxReserType1":
            //        this.vsvXRT0001.QuerySQL = "select code_name from xrt0102 where hosp_code = :f_hosp_code and code_type = \'Y\' and code = :f_code";
            //        item.BindControl = txtResType1;
            //        break;
            //    default:
            //        XMessageBox.Show("NO CONTROL FOUND", "ERROR");
            //        break;
            //}

            //this.vsvXRT0001.LayoutItems.Add(item);

            //this.vsvXRT0001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.vsvXRT0001.SetBindVarValue("f_code", fb.GetDataValue());
            //this.vsvXRT0001.QueryLayout();

            //if (this.vsvXRT0001.GetItemValue("code_name").ToString() == "")
            //{
            //    e.Cancel = true;
            //    item.BindControl.Text = "";
            //}
            //else
            //{
            //    item.BindControl.Text = this.vsvXRT0001.GetItemValue("code_name").ToString();
            //}
            #endregion

            #region Updated by Cloud

            XFindBox fb = sender as XFindBox;
            SingleLayoutItem item = new SingleLayoutItem();
            item.DataName = "code_name";

            switch (fb.Name)
            {
                case "fbxXrayGubun1":
                    item.BindControl = txtXrayGubun1;
                    break;
                case "fbxXrayRoom1":
                    item.BindControl = txtXrayRoom1;
                    break;
                case "fbxXrayBuwi1":
                    if (e.DataValue == "") { txtXrayBuwi1.SetDataValue(""); }
                    item.BindControl = txtXrayBuwi1;
                    break;
                case "fbxModality1":
                    if (e.DataValue == "") { txtModality1.SetDataValue(""); }
                    item.BindControl = txtModality1;
                    break;
                case "fbxReserType1":
                    item.BindControl = txtResType1;
                    break;
                default:
                    XMessageBox.Show("NO CONTROL FOUND", "ERROR");
                    return;
            }

            XRT0001U00FbxDataValidatingArgs args = new XRT0001U00FbxDataValidatingArgs();
            args.Code = fb.GetDataValue();
            args.FbName = fb.Name;
            XRT0001U00FbxDataValidatingResult res = CloudService.Instance.Submit<XRT0001U00FbxDataValidatingResult,
                XRT0001U00FbxDataValidatingArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.CodeName == "")
                {
                    e.Cancel = true;
                    item.BindControl.Text = "";
                }
                else
                {
                    item.BindControl.Text = res.CodeName;
                }
            }

            #endregion
        }

        private void rbxAll_Click(object sender, EventArgs e)
        {
            this.xButtonList.PerformClick(FunctionType.Query);
        }

        private void txtParam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) this.xButtonList.PerformClick(FunctionType.Query);
        }

        private void cbxXrayGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.xButtonList.PerformClick(FunctionType.Query);
        }

        private void rbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (((XRadioButton)sender).Name == "rbxAll")
            {
                this.rbxAll.ImageIndex = 0;
                this.rbxSpecialY.ImageIndex = 1;
                this.rbxSpecialN.ImageIndex = 1;

                this.rbxAll.BackColor = XColor.XCalendarWeekDayBackColor;
                this.rbxSpecialY.BackColor = XColor.XRotatorBodyGradientEndColor;
                this.rbxSpecialN.BackColor = XColor.XRotatorBodyGradientEndColor;
            }
            else if (((XRadioButton)sender).Name == "rbxSpecialY")
            {
                this.rbxAll.ImageIndex = 1;
                this.rbxSpecialY.ImageIndex = 0;
                this.rbxSpecialN.ImageIndex = 1;

                this.rbxAll.BackColor = XColor.XRotatorBodyGradientEndColor;
                this.rbxSpecialY.BackColor = XColor.XCalendarWeekDayBackColor;
                this.rbxSpecialN.BackColor = XColor.XRotatorBodyGradientEndColor;
            }
            else
            {
                this.rbxAll.ImageIndex = 1;
                this.rbxSpecialY.ImageIndex = 1;
                this.rbxSpecialN.ImageIndex = 0;

                this.rbxAll.BackColor = XColor.XRotatorBodyGradientEndColor;
                this.rbxSpecialY.BackColor = XColor.XRotatorBodyGradientEndColor;
                this.rbxSpecialN.BackColor = XColor.XCalendarWeekDayBackColor;
            }
        }

        private void grdRadioList_Click(object sender, EventArgs e)
        {
            this.SelectedGrid = "D";
        }

        private void grdXRT_Click(object sender, EventArgs e)
        {
            this.SelectedGrid = "M";
        }

        private void XRT0001U00_Closing(object sender, CancelEventArgs e)
        {
            if (!bIsSaveSuccess)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Methods

        private void setXrayCodeIdx()
        {
            int insertRow = -1;

            insertRow = this.grdRadioList.InsertRow();


            //XMessageBox.Show(this.grdRadioList.RowCount.ToString());
            this.grdRadioList.SetItemValue(insertRow, "xray_code", this.grdXRT.GetItemString(this.grdXRT.CurrentRowNumber, "xray_code"));
            this.grdRadioList.SetItemValue(insertRow, "xray_gubun", this.grdXRT.GetItemString(this.grdXRT.CurrentRowNumber, "xray_gubun"));
            this.grdRadioList.SetItemValue(insertRow, "xray_code_idx", (this.grdRadioList.RowCount));
        }

        //각각의 컨트롤(파인드박스)에 적합한 파인드 워커로 셋팅

        private bool MakeFindWorker(string aCtrName)
        {
            //mCaller = "";
            bool result = false;
            CommonItemCollection param = new CommonItemCollection();
            fwkXRT0001.ParamList = new List<string>(new string[] { "f_control_name", "f_find1" });
            fwkXRT0001.SetBindVarValue("f_control_name", aCtrName);
            fwkXRT0001.SetBindVarValue("f_find1", string.Empty);

            #region deleted by Cloud
//            //촬영구분 조회
//            string queryText1 = @"  SELECT CODE
//                                         , CODE_NAME
//                                      FROM XRT0102
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND CODE_TYPE = 'X1'
//                                       AND (CODE LIKE '%'||:f_find1||'%'
//                                        OR CODE_NAME LIKE '%'||:f_find1||'%')
//                                     ORDER BY SEQ  ";
//            //촬영실 조회
//            string queryText2 = @"  SELECT CODE
//                                         , CODE_NAME
//                                      FROM XRT0102
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND CODE_TYPE = 'X6'
//                                       AND (CODE LIKE '%'||:f_find1||'%'
//                                        OR CODE_NAME LIKE '%'||:f_find1||'%')
//                                     ORDER BY CODE  ";

//            //예약증타입 조회
//            string queryText5 = @"  SELECT CODE
//                                         , CODE_NAME
//                                      FROM XRT0102
//                                     WHERE HOSP_CODE = :f_hosp_code 
//                                       AND CODE_TYPE = 'Y'
//                                       AND (CODE LIKE '%'||:f_find1||'%'
//                                        OR CODE_NAME LIKE '%'||:f_find1||'%')
//                                     ORDER BY CODE ";
//            //モダリティ照会
//            string queryText6 = @"  SELECT CODE
//                                         , CODE_NAME
//                                      FROM XRT0102
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND CODE_TYPE = 'MO'
//                                       AND (CODE LIKE '%'||:f_find1||'%'
//                                        OR CODE_NAME LIKE '%'||:f_find1||'%')
//                                     ORDER BY CODE  ";
            #endregion

            switch (aCtrName)
            {
                case "fbxXrayGubun1":
                    //this.fwkXRT0001.FormText = Resources.fwkXRT0001Text1;
                    //this.fwkXRT0001.InputSQL = queryText1;
                    //this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fwkXRT0001Header1;
                    //this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fwkXRT0001Header2;
                    //result = true;
                    //break;
                case "fbxXrayGubun2":
                    this.fwkXRT0001.FormText = Resources.fwkXRT0001Text1;
                    //this.fwkXRT0001.InputSQL = queryText1;
                    this.fwkXRT0001.ExecuteQuery = GetFindWorker;
                    this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fwkXRT0001Header1;
                    this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fwkXRT0001Header2;
                    result = true;
                    break;
                case "fbxXrayRoom1":
                    //this.fwkXRT0001.FormText = Resources.fwkXRT0001Text2;
                    //this.fwkXRT0001.InputSQL = queryText2;
                    //this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fwkXRT0001Header3;
                    //this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fwkXRT0001Header4;
                    //result = true;
                    //break;
                case "fbxXrayRoom2":
                    this.fwkXRT0001.FormText = Resources.fwkXRT0001Text2;
                    //this.fwkXRT0001.InputSQL = queryText2;
                    this.fwkXRT0001.ExecuteQuery = GetFindWorker;
                    this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fwkXRT0001Header3;
                    this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fwkXRT0001Header4;
                    result = true;
                    break;
                case "fbxXrayBuwi1":
                    mCaller = "fbxXrayBuwi1";

                    param.Add("kaikei_yn", "N");
                    XScreen.OpenScreenWithParam(this, "XRTS", "XRT0122Q00", ScreenOpenStyle.ResponseFixed, param);
                    result = true;
                    break;
                case "fbxXrayBuwi2":
                    mCaller = "fbxXrayBuwi2";

                    param.Add("kaikei_yn", "N");
                    XScreen.OpenScreenWithParam(this, "XRTS", "XRT0122Q00", ScreenOpenStyle.ResponseFixed, param);
                    result = true;
                    break;
                case "fbxModality1":
                    //this.fwkXRT0001.FormText = Resources.fbxModalityFormText;
                    //this.fwkXRT0001.InputSQL = queryText6;
                    //this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fbxModalityHeader1;
                    //this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fbxModalityHeader2;
                    //result = true;
                    //break;
                case "fbxModality2":
                    this.fwkXRT0001.FormText = Resources.fbxModalityFormText;
                    //this.fwkXRT0001.InputSQL = queryText6;
                    this.fwkXRT0001.ExecuteQuery = GetFindWorker;
                    this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fbxModalityHeader1;
                    this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fbxModalityHeader2;
                    result = true;
                    break;
                case "fbxReserType1":
                    //this.fwkXRT0001.FormText = Resources.fbxReserTypeFormText;
                    //this.fwkXRT0001.InputSQL = queryText5;
                    //this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fbxReserTypeHeader1;
                    //this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fbxReserTypeHeader2;
                    //result = true;
                    //break;
                case "fbxReserType2":
                    this.fwkXRT0001.FormText = Resources.fbxReserTypeFormText;
                    //this.fwkXRT0001.InputSQL = queryText5;
                    this.fwkXRT0001.ExecuteQuery = GetFindWorker;
                    this.fwkXRT0001.ColInfos[0].HeaderText = Resources.fbxReserTypeHeader1;
                    this.fwkXRT0001.ColInfos[1].HeaderText = Resources.fbxReserTypeHeader2;
                    result = true;
                    break;
                default:
                    XMessageBox.Show("NO CONTROL FOUND", "ERROR");
                    result = false;
                    break;
            }
            //this.fwkXRT0001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            return result;
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "XRT0122Q00")
            {
                if (mCaller == "fbxXrayBuwi1")
                {
                    this.fbxXrayBuwi1.SetDataValue(commandParam["buwi_code"].ToString());
                    this.fbxXrayBuwi1.AcceptData();
                    this.grdXRT.SetItemValue(this.grdXRT.CurrentRowNumber, "xray_buwi", commandParam["buwi_code"].ToString());

                    this.txtXrayBuwi1.SetDataValue(commandParam["buwi_name"].ToString());
                    this.txtXrayBuwi1.AcceptData();
                    this.grdXRT.SetItemValue(this.grdXRT.CurrentRowNumber, "buwi_name", commandParam["buwi_name"].ToString());
                }
            }

            return base.Command(command, commandParam);
        }

        #endregion

        // deleted by Cloud
        #region XSavePerformer
//        private class XSavePerformer : ISavePerformer
//        {
//            XRT0001U00 parent = null;

//            public XSavePerformer(XRT0001U00 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";

//                item.BindVarList.Add("q_user_id", UserInfo.UserID);
//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

//                switch (callerID)
//                {
//                    #region [case '1']
//                    case '1':

//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO XRT0001 (
//                                                SYS_DATE,        SYS_ID,             
//                                                UPD_DATE,        UPD_ID,             HOSP_CODE,         
//                                                XRAY_CODE,       XRAY_NAME,          XRAY_GUBUN,
//                                                XRAY_ROOM,       XRAY_BUWI,          XRAY_BUWI_KAIKEI,
//                                                XRAY_BUWI_TONG,  XRAY_CNT,           NAME_PRINT_YN,      
//                                                SUGA_CODE,       SPECIAL_YN,         XRAY_NAME2,
//                                                XRAY_REAL_CNT,
//                                                SLIP_CODE,       RESER_TYPE,         JAERYO_YN,          
//                                                SORT,            XRAY_WAY,           TONG_GUBUN,
//                                                REQUEST_YN,      MODALITY,           FREQUENT_USE_YN,
//                                                TUBE_VOL,        TUBE_CUR,           XRAY_TIME,
//                                                TUBE_CUR_TIME,   IRRADIATION_TIME,   XRAY_DISTANCE
//                                            ) VALUES (
//                                                SYSDATE,           :q_user_id,            
//                                                SYSDATE,           :q_user_id,            :f_hosp_code,
//                                                :f_xray_code,      :f_xray_name,          :f_xray_gubun,
//                                                :f_xray_room,      :f_xray_buwi,          :f_xray_buwi_kaikei,
//                                                :f_xray_buwi_tong, :f_xray_cnt,           :f_name_print_yn,      
//                                                :f_suga_code,      :f_special_yn,         :f_xray_name2,
//                                                :f_xray_real_cnt,
//                                                :f_slip_code,      :f_reser_type,         :f_jaeryo_yn,          
//                                                :f_sort,           :f_xray_way,           :f_tong_gubun,         
//                                                :f_request_yn,     :f_modality,           :f_frequent_use_yn,
//                                                :f_tube_vol,       :f_tube_cur,           :f_xray_time,
//                                                :f_tube_cur_time,  :f_irradiation_time,   :f_xray_distance
//                                            )";

//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE XRT0001
//                                           SET UPD_ID           = :q_user_id
//                                             , UPD_DATE         = SYSDATE
//                                             , XRAY_NAME        = :f_xray_name
//                                             , XRAY_GUBUN       = :f_xray_gubun
//                                             , XRAY_ROOM        = :f_xray_room
//                                             , XRAY_BUWI        = :f_xray_buwi
//                                             , XRAY_BUWI_KAIKEI = :f_xray_buwi_kaikei
//                                             , XRAY_BUWI_TONG   = :f_xray_buwi_tong
//                                             , XRAY_CNT         = :f_xray_cnt
//                                             , NAME_PRINT_YN    = :f_name_print_yn
//                                             , SUGA_CODE        = :f_suga_code
//                                             , SPECIAL_YN       = :f_special_yn
//                                             , XRAY_REAL_CNT    = :f_xray_real_cnt
//                                             , SLIP_CODE        = :f_slip_code
//                                             , RESER_TYPE       = :f_reser_type
//                                             , JAERYO_YN        = :f_jaeryo_yn
//                                             , SORT             = :f_sort
//                                             , XRAY_WAY         = :f_xray_way
//                                             , TONG_GUBUN       = :f_tong_gubun   
//                                             , REQUEST_YN       = :f_request_yn
//                                             , MODALITY         = :f_modality
//                                             , FREQUENT_USE_YN  = :f_frequent_use_yn
//                                             , XRAY_NAME2       = :f_xray_name2
//                                             , TUBE_VOL         = :f_tube_vol
//                                             , TUBE_CUR         = :f_tube_cur
//                                             , XRAY_TIME        = :f_xray_time
//                                             , TUBE_CUR_TIME    = :f_tube_cur_time
//                                             , IRRADIATION_TIME = :f_irradiation_time
//                                             , XRAY_DISTANCE    = :f_xray_distance
//                                         WHERE HOSP_CODE        = :f_hosp_code
//                                           AND XRAY_CODE        = :f_xray_code";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE XRT0001
//                                         WHERE HOSP_CODE = :f_hosp_code
//                                           AND XRAY_CODE = :f_xray_code";
//                                break;
//                        }

//                        break;
//                    #endregion

//                    #region [case '2']
//                    case '2':

//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO XRT0002 (
//                                                              SYS_DATE
//                                                            , UPD_ID
//                                                            , UPD_DATE
//                                                            , HOSP_CODE
//                                                            , XRAY_CODE
//                                                            , XRAY_GUBUN
//                                                            , XRAY_CODE_IDX
//                                                            , XRAY_CODE_IDX_NM
//                                                            , TUBE_VOL
//                                                            , TUBE_CUR
//                                                            , XRAY_TIME
//                                                            , TUBE_CUR_TIME
//                                                            , IRRADIATION_TIME
//                                                            , XRAY_DISTANCE
//                                                            ) VALUES (
//                                                              SYSDATE
//                                                            , :q_user_id
//                                                            , SYSDATE
//                                                            , :f_hosp_code
//                                                            , :f_xray_code
//                                                            , :f_xray_gubun
//                                                            , :f_xray_code_idx
//                                                            , :f_xray_code_idx_nm
//                                                            , :f_tube_vol
//                                                            , :f_tube_cur
//                                                            , :f_xray_time
//                                                            , :f_tube_cur_time
//                                                            , :f_irradiation_time
//                                                            , :f_xray_distance
//                                                            )";
//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE XRT0002 
//                                           SET UPD_ID           = :q_user_id
//                                             , UPD_DATE         = SYSDATE
//                                             , HOSP_CODE        = :f_hosp_code
//                                             , XRAY_CODE        = :f_xray_code
//                                             , XRAY_GUBUN       = :f_xray_gubun
//                                             , XRAY_CODE_IDX    = :f_xray_code_idx
//                                             , XRAY_CODE_IDX_NM = :f_xray_code_idx_nm
//                                             , TUBE_VOL         = :f_tube_vol
//                                             , TUBE_CUR         = :f_tube_cur
//                                             , XRAY_TIME        = :f_xray_time
//                                             , TUBE_CUR_TIME    = :f_tube_cur_time
//                                             , IRRADIATION_TIME = :f_irradiation_time
//                                             , XRAY_DISTANCE    = :f_xray_distance
//                                         WHERE HOSP_CODE        = :f_hosp_code
//                                           AND XRAY_CODE        = :f_xray_code
//                                           AND XRAY_CODE_IDX    = :f_xray_code_idx";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DELETE XRT0002
//                                         WHERE HOSP_CODE      = :f_hosp_code
//                                           AND XRAY_CODE      = :f_xray_code
//                                           AND XRAY_CODE_IDX  = :f_xray_code_idx";
//                                break;
//                        }
//                        break;
//                    #endregion
//                }
//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
//            }
//        }
        #endregion

        #region Cloud updated code

        #region InitItemControls
        /// <summary>
        /// InitItemControls
        /// </summary>
        private void InitItemControls()
        {
            // cbxXrayGubun
            cbxXrayGubun.ExecuteQuery = GetCbxXrayGubun;
            cbxXrayGubun.SetDictDDLB();

            // grdRadioList
            grdRadioList.ParamList = new List<string>(new string[] { "f_xray_code" });
            grdRadioList.ExecuteQuery = GetGrdRadioList;

            // grdXRT
            grdXRT.ParamList = new List<string>(new string[] { "f_special_yn", "f_txt_param", "f_xray_gubun" });
            grdXRT.ExecuteQuery = GetGrdXRT;
        }
        #endregion

        #region GetCbxXrayGubun
        /// <summary>
        /// GetCbxXrayGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCbxXrayGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CacheService.Instance.Get<CbxXrayGubunArgs, ComboResult>(new CbxXrayGubunArgs());

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in res.ComboItem)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName, });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdRadioList
        /// <summary>
        /// GetGrdRadioList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdRadioList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT0001U00GrdRadioListArgs args = new XRT0001U00GrdRadioListArgs();
            args.XrayCode = bvc["f_xray_code"].VarValue;
            XRT0001U00GrdRadioListResult res = CloudService.Instance.Submit<XRT0001U00GrdRadioListResult,
                XRT0001U00GrdRadioListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0001U00GrdRadioListInfo item in res.GrdRadioItem)
                {
                    lObj.Add(new object[]
                    {
                        item.XrayCode,
                        item.XrayGubun,
                        item.XrayCodeIdx,
                        item.XrayCodeIdxNm,
                        item.TubeVol,
                        item.TubeCur,
                        item.XrayTime,
                        item.TubeCurTime,
                        item.IrradiationTime,
                        item.XrayDistance,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetGrdXRT
        /// <summary>
        /// GetGrdXRT
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdXRT(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT0001U00GrdXRTArgs args = new XRT0001U00GrdXRTArgs();
            args.SpecialYn  = bvc["f_special_yn"].VarValue;
            args.TxtParam   = bvc["f_txt_param"].VarValue;
            args.XrayGubun  = bvc["f_xray_gubun"].VarValue;
            XRT0001U00GrdXRTResult res = CloudService.Instance.Submit<XRT0001U00GrdXRTResult, XRT0001U00GrdXRTArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0001U00GrdXRTInfo item in res.GrdXrtItem)
                {
                    lObj.Add(new object[]
                    {
                        item.XrayCode,
                        item.XrayName,
                        item.XrayGubun,
                        item.XrayRoom,
                        item.XrayBuwi,
                        item.XrayBuwiKaikei,
                        item.XrayBuwiTong,
                        item.XrayCnt,
                        item.NamePrintYn,
                        item.SugaCode,
                        item.SpecialYn,
                        item.XrayRealCnt,
                        item.SlipCode,
                        item.ReserType,
                        item.GubunName,
                        item.RoomName,
                        item.BuwiName,
                        item.BuwiKaikeiName,
                        item.BuwiTongName,
                        item.ReserTypeName,
                        item.JaeryoYn,
                        item.Sort,
                        item.XrayWay,
                        item.FrequentUseYn,
                        item.Modality,
                        item.ModalityName,
                        item.Lpad,
                        item.XrayName2,
                        item.TongGubun,
                        item.RequestYn,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetFindWorker
        /// <summary>
        /// GetFindWorker
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFindWorker(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            XRT0001U00MakeFindWorkerArgs args = new XRT0001U00MakeFindWorkerArgs();
            args.CtrName = bvc["f_control_name"].VarValue;
            args.Find1 = bvc["f_find1"].VarValue;
            ComboResult res = CloudService.Instance.Submit<ComboResult, XRT0001U00MakeFindWorkerArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in res.ComboItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<XRT0001U00SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<XRT0001U00SaveLayoutInfo> lstData = new List<XRT0001U00SaveLayoutInfo>();

            #region grdXRT

            // Insert/update
            for (int i = 0; i < grdXRT.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdXRT.GetRowState(i) == DataRowState.Unchanged) continue;

                XRT0001U00SaveLayoutInfo item = new XRT0001U00SaveLayoutInfo();

                // https://sofiamedix.atlassian.net/browse/MED-13505
                if (TypeCheck.IsNull(grdXRT.GetItemString(i, "xray_cnt")))
                {
                    XMessageBox.Show(Resources.MSG_REQUIRED_XRAY_CNT, Resources.caption1, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<XRT0001U00SaveLayoutInfo>();
                }

                item.XrayCode                 = grdXRT.GetItemString(i,"xray_code");
                item.XrayRoom                 = grdXRT.GetItemString(i,"xray_room");
                item.XrayBuwiTong             = grdXRT.GetItemString(i,"xray_buwi_tong");
                item.SugaCode                 = grdXRT.GetItemString(i,"suga_code");
                item.XrayRealCnt              = grdXRT.GetItemString(i,"xray_real_cnt");
                item.SlipCode                 = grdXRT.GetItemString(i,"slip_code");
                item.Sort                     = grdXRT.GetItemString(i,"sort");
                //item.RequestYn                = grdXRT.GetItemString(i,"request_yn");
                //item.TubeVol                  = grdXRT.GetItemString(i,"tube_vol");
                //item.TubeCurTime              = grdXRT.GetItemString(i,"tube_cur_time");
                item.XrayName                 = grdXRT.GetItemString(i,"xray_name");
                item.XrayBuwi                 = grdXRT.GetItemString(i,"xray_buwi");
                item.XrayCnt                  = grdXRT.GetItemString(i,"xray_cnt");
                item.SpecialYn                = grdXRT.GetItemString(i,"special_yn");
                item.ReserType                = grdXRT.GetItemString(i,"reser_type");
                item.XrayWay                  = grdXRT.GetItemString(i,"xray_way");
                item.Modality                 = grdXRT.GetItemString(i,"modality");
                //item.TubeCur                  = grdXRT.GetItemString(i,"tube_cur");
                //item.IrradiationTime          = grdXRT.GetItemString(i,"irradiation_time");
                item.XrayGubun                = grdXRT.GetItemString(i,"xray_gubun");
                item.XrayBuwiKaikei           = grdXRT.GetItemString(i,"xray_buwi_kaikei");
                item.NamePrintYn              = grdXRT.GetItemString(i,"name_print_yn");
                item.XrayName2                = grdXRT.GetItemString(i,"xray_name2");
                item.JaeryoYn                 = grdXRT.GetItemString(i,"jaeryo_yn");
                item.TongGubun                = grdXRT.GetItemString(i,"tong_gubun");
                item.FrequentUseYn            = grdXRT.GetItemString(i,"frequent_use_yn");
                //item.XrayTime                 = grdXRT.GetItemString(i,"xray_time");
                //item.XrayDistance             = grdXRT.GetItemString(i,"xray_distance");
                //item.XrayCodeIdx              = grdXRT.GetItemString(i,"xray_code_idx");
                //item.XrayCodeIdxNm            = grdXRT.GetItemString(i,"xray_code_idx_nm");
                item.RowState                 = grdXRT.GetRowState(i).ToString();
                item.CallerId                 = "1";

                lstData.Add(item);
            }

            // Delete
            if (null != grdXRT.DeletedRowTable)
            {
                for (int i = 0; i < grdXRT.DeletedRowTable.Rows.Count; i++)
                {
                    XRT0001U00SaveLayoutInfo item = new XRT0001U00SaveLayoutInfo();

                    item.XrayCode = Convert.ToString(grdXRT.DeletedRowTable.Rows[i]["xray_code"]);
                    item.RowState = DataRowState.Deleted.ToString();
                    item.CallerId = "1";

                    lstData.Add(item);
                }
            }
            #endregion

            #region grdRadioList

            // Insert/update
            for (int i = 0; i < grdRadioList.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdRadioList.GetRowState(i) == DataRowState.Unchanged) continue;

                XRT0001U00SaveLayoutInfo item = new XRT0001U00SaveLayoutInfo();

                item.XrayCode                 = grdRadioList.GetItemString(i,"xray_code");
                //item.XrayRoom                 = grdRadioList.GetItemString(i,"xray_room");
                //item.XrayBuwiTong             = grdRadioList.GetItemString(i,"xray_buwi_tong");
                //item.SugaCode                 = grdRadioList.GetItemString(i,"suga_code");
                //item.XrayRealCnt              = grdRadioList.GetItemString(i,"xray_real_cnt");
                //item.SlipCode                 = grdRadioList.GetItemString(i,"slip_code");
                //item.Sort                     = grdRadioList.GetItemString(i,"sort");
                //item.RequestYn                = grdRadioList.GetItemString(i,"request_yn");
                item.TubeVol                  = grdRadioList.GetItemString(i,"tube_vol");
                item.TubeCurTime              = grdRadioList.GetItemString(i,"tube_cur_time");
                //item.XrayName                 = grdRadioList.GetItemString(i,"xray_name");
                //item.XrayBuwi                 = grdRadioList.GetItemString(i,"xray_buwi");
                //item.XrayCnt                  = grdRadioList.GetItemString(i,"xray_cnt");
                //item.SpecialYn                = grdRadioList.GetItemString(i,"special_yn");
                //item.ReserType                = grdRadioList.GetItemString(i,"reser_type");
                //item.XrayWay                  = grdRadioList.GetItemString(i,"xray_way");
                //item.Modality                 = grdRadioList.GetItemString(i,"modality");
                item.TubeCur                  = grdRadioList.GetItemString(i,"tube_cur");
                item.IrradiationTime          = grdRadioList.GetItemString(i,"irradiation_time");
                item.XrayGubun                = grdRadioList.GetItemString(i,"xray_gubun");
                //item.XrayBuwiKaikei           = grdRadioList.GetItemString(i,"xray_buwi_kaikei");
                //item.NamePrintYn              = grdRadioList.GetItemString(i,"name_print_yn");
                //item.XrayName2                = grdRadioList.GetItemString(i,"xray_name2");
                //item.JaeryoYn                 = grdRadioList.GetItemString(i,"jaeryo_yn");
                //item.TongGubun                = grdRadioList.GetItemString(i,"tong_gubun");
                //item.FrequentUseYn            = grdRadioList.GetItemString(i,"frequent_use_yn");
                item.XrayTime                 = grdRadioList.GetItemString(i,"xray_time");
                item.XrayDistance             = grdRadioList.GetItemString(i,"xray_distance");
                item.XrayCodeIdx              = grdRadioList.GetItemString(i,"xray_code_idx");
                item.XrayCodeIdxNm            = grdRadioList.GetItemString(i,"xray_code_idx_nm");
                item.RowState                 = grdRadioList.GetRowState(i).ToString();
                item.CallerId                 = "2";

                lstData.Add(item);
            }

            // Delete
            if (null != grdRadioList.DeletedRowTable)
            {
                for (int i = 0; i < grdRadioList.DeletedRowTable.Rows.Count; i++)
                {
                    XRT0001U00SaveLayoutInfo item = new XRT0001U00SaveLayoutInfo();

                    item.XrayCode       = Convert.ToString(grdRadioList.DeletedRowTable.Rows[i]["xray_code"]);
                    item.XrayCodeIdx    = Convert.ToString(grdRadioList.DeletedRowTable.Rows[i]["xray_code_idx"]);
                    item.RowState       = DataRowState.Deleted.ToString();
                    item.CallerId       = "2";

                    lstData.Add(item);
                }
            }

            #endregion

            return lstData;
        }
        #endregion

        #endregion
    }
}

