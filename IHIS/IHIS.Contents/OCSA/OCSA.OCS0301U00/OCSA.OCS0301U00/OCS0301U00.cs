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
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.OCSA.Properties;

namespace IHIS.OCSA
{
    public partial class OCS0301U00 : XScreen
    {
        public Hashtable hst_Dise;
        public string memb;
        public string FKOCS0300_SEQ;
        public string YAKSOK_CODE;
        public OCS0301U00()
        {
            InitializeComponent();
            
            //set mHospCode
            this.mHospCode = UserInfo.HospCode;
            //if (String.IsNullOrEmpty(this.mHospCode))
            //{
            //    this.mHospCode = "K01";
            //}

            //set enable/disable controls
            if (UserInfo.AdminType != AdminType.SuperAdmin)
            //if (false)
            {
                xHospBox1.Visible = false;
                btnInsertSetGubun.Enabled = true;
                btnDeleteSetGubun.Enabled = true;
                xPanel5.Enabled = true;
                //set edit fbxUser for OCSA: MED-5391
                if (EnvironInfo.CurrSystemID != "OCSA")
                {
                    fbxUser.Enabled = false;
                }

                btnList.SetEnabled(FunctionType.Insert, true);
                btnList.SetEnabled(FunctionType.Delete, true);
                btnList.SetEnabled(FunctionType.Update, true);

            }
            else 
            {
                xHospBox1.Visible = true;
                btnInsertSetGubun.Enabled = false;
                btnDeleteSetGubun.Enabled = false;
                xPanel5.Enabled = false;

                btnList.SetEnabled(FunctionType.Insert, false);
                btnList.SetEnabled(FunctionType.Delete, false);
                btnList.SetEnabled(FunctionType.Update, false);
            }

            fwkUser.ParamList = CreateFwkUserParamList();
            fwkUser.ExecuteQuery = LoadFwkUser;
            grdOCS0300.ParamList = CreateGrdOCS0300ParamList();
            grdOCS0300.ExecuteQuery = LoadGrdOCS0300;
            grdOCS0301.ParamList = CreateGrdOCS0301ParamList();
            grdOCS0301.ExecuteQuery = LoadGrdOCS0301;
            layQueryLayout.ParamList = CreateLayQueryLayoutParamList();
            layQueryLayout.ExecuteQuery = LoadLayQueryLayout;
            cboInputTab.ExecuteQuery = LoadCboInputTab;
            cboInputTab.SetDictDDLB();
            cboInputTabNew.ExecuteQuery = LoadCboInputTab;
            cboInputTabNew.SetDictDDLB();

            grdOCS307.ParamList = CreateLayQueryLayoutParamList();
            grdOCS307.ExecuteQuery = LoadOCS0301U00grd307;
            this.btnAplOrder.Enabled = true;
            
        }

        #region private fields

        private bool mIsAdminMode = false;     // 전체 화면 모드 ADMIN 모드인지 아닌지 여부
        private SetMode mCurrentMode = SetMode.UserMode;

        // Lib 변수 선언
        private IHIS.OCS.OrderBiz mOrderBiz;
        private IHIS.OCS.OrderFunc mOrderFunc = null;         // OCS 그룹 Function 라이브러리

        // 오더 패널 확장 관련 
        private int mMaxHeight = 156;
        private int mMinHeight = 0;
        private bool mIsExpanded = false;

        // 로컬 변수
        private string mMemb = "";
        public static string mPkSeq = "";


        // Label 관련 
        private string mBufferLabel = "";

        private OCS0301U00CboDoctorGwaResult cboDoctorGwaResult;

        private const string CACHE_OCS_COMBO_INPUT_TAB_KEYS = "OCSO.Cbo.InputTab";

        private string mHospCode = "";

        private DataTable _layDisplayTable;
        #endregion

        private void OCS0301U00_Load(object sender, EventArgs e)
        {
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            if (this.Opener is IHIS.Framework.MdiForm &&
                (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            {
                Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);
            }

            // Library 할당
            mOrderBiz = new IHIS.OCS.OrderBiz(this.Name);
            this.mOrderFunc = new IHIS.OCS.OrderFunc(this.Name);            // OCS 그룹 Function 라이브러리

            //this.grdOCS0300.SavePerformer = new XSavePeformer(this);
            //this.grdOCS0301.SavePerformer = this.grdOCS0300.SavePerformer;
            //this.laySaveLayout.SavePerformer = this.grdOCS0300.SavePerformer;
            //this.layDeletedData.SavePerformer = this.grdOCS0300.SavePerformer;

            // 초기화
            this.InitScreen();

            // 유저 체인지 이벤트 구동
            this.OCS0301U00_UserChanged(this, new EventArgs());

            PostCallHelper.PostCall(new PostMethod(this.PostScreenLoad));
            this.DisableDoctorGwaCombo();
        }

        private void OCS0301U00_UserChanged(object sender, EventArgs e)
        {
            // 유저 그룹으로 어드민모드인지 아닌지르ㄹ 판단한다.
            // 어드민 모드인경우는 병원 셋트와 과별 셋트를 구성할 수 있다.
            if (UserInfo.UserGroup == "ADMIN" || UserInfo.UserGroup == "OCSA")
                this.mIsAdminMode = true;
            else
                this.mIsAdminMode = false;
        }

        private void OCS0301U00_Closing(object sender, CancelEventArgs e)
        {
            // 변경된 데이터 있는지 확인하고 있으면 물어봄
            if (this.IsExistModifiedData() == true)
            {
                if (XMessageBox.Show(XMsg.GetMsg("M005"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    this.btnList.PerformClick(FunctionType.Update);
                }
            }
        }

        /// <summary>
        /// 내복약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U10()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 주사약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U12()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 검체검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U13()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("open_popup", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 생리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U14()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 병리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U15()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 방사선오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U16()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 처치오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U17()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 수술오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U18()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 기타오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U19()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 기타오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U11()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("order_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
            //param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", "O");
            param.Add("input_gubun", "D0");
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            //param.Add("input_part", UserInfo.Gwa);
            param.Add("naewon_key", ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString());
            //param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", "セット");
            param.Add("in_data_row", this.layRehaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", IHIS.OCS.OrderVariables.OrderMode.SetOrder);
            param.Add("memb", this.mMemb);
            param.Add("yaksok_code", this.grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "yaksok_code"));
            param.Add("isOpenPopUp", true);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
        }

        private void fbxUser_FindClick(object sender, CancelEventArgs e)
        {
            if (NetInfo.Language == LangMode.Jr)
            {
                this.fwkUser.FormText = "検索";
            }
            else
                this.fwkUser.FormText = "Tìm kiếm";
            XFindBox control = sender as XFindBox;

            if (this.mIsAdminMode)
            {
                this.fwkUser.SetBindVarValue("f_query_mode", "0");
                this.fwkUser.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            }
            else
            {
                this.fwkUser.SetBindVarValue("f_query_mode", "1");
                this.fwkUser.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            }
        }

        private void fbxUser_DataValidating(object sender, DataValidatingEventArgs e)
        {
            // cloud service
            cboDoctorGwaResult = GetCboDoctorGwaResult(e.DataValue);
            if (cboDoctorGwaResult != null && cboDoctorGwaResult.ExecutionStatus == ExecutionStatus.Success)
            {


                if (e.DataValue == "")
                {
                    this.dbxUserName.SetDataValue("");
                    this.SetMsg("");

                    InitializeAll();
                    return;
                }

                // 병원공통인경우
                if (e.DataValue == "ADMIN" && this.mIsAdminMode)
                {
                    this.dbxUserName.SetDataValue(Resources.MSG_2);
                    this.SetMsg("");

                    this.mCurrentMode = SetMode.HospitalMode;

                    //this.DisableDoctorGwaCombo();
                }
                else
                {
                    string name = "";
                    // 진료과인지 체크 
                    if (this.mIsAdminMode)
                        //this.mOrderBiz.LoadColumnCodeName("gwa", e.DataValue, ref name);
                        name = cboDoctorGwaResult.GwaInfo;

                    if (name == "")
                    {
                        // 사용자 체크 
                        //this.mOrderBiz.LoadColumnCodeName("user_id", e.DataValue, ref name);
                        name = cboDoctorGwaResult.UserInfo;

                        if (name != "")
                            this.mCurrentMode = SetMode.UserMode;
                    }
                    else
                        this.mCurrentMode = SetMode.GwaMode;

                    if (name == "")
                    {
                        this.dbxUserName.SetDataValue("");
                        // 사용자정보가 정확하지 않습니다.
                        XMessageBox.Show(XMsg.GetMsg("M001"), XMsg.GetField("F001"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        this.SetMsg(XMsg.GetMsg("M001"), MsgType.Error);
                        e.Cancel = true;
                        InitializeAll();
                        return;
                    }

                    /*UserType userGubun = mOrderBiz.LoadUserGubun(e.DataValue);
                    switch (userGubun)
                    {
                        case UserType.Doctor:
                            this.mCurrentMode = SetMode.DoctorMode;
                            this.EnableDoctorGwaCombo(e.DataValue);
                            break;
                        case UserType.Nurse:
                            this.mCurrentMode = SetMode.NurseMode;
                            this.DisableDoctorGwaCombo();
                            break;
                        default:
                            this.DisableDoctorGwaCombo();
                            break;
                    }*/

                    // cloud service
                    string userGubun = cboDoctorGwaResult.UserGubun;
                    switch (userGubun)
                    {
                        case "1":
                            this.mCurrentMode = SetMode.DoctorMode;
                            this.EnableDoctorGwaCombo(e.DataValue);
                            break;
                        case "2":
                            this.mCurrentMode = SetMode.NurseMode;
                            this.DisableDoctorGwaCombo();
                            break;
                        default:
                            this.DisableDoctorGwaCombo();
                            break;
                    }

                    this.dbxUserName.SetDataValue(name);


                }
            }
            PostCallHelper.PostCall(new PostMethod(this.PostUserValidating));
        }

        private void btnExpandOrderPanel_Click(object sender, EventArgs e)
        {
            if (this.mIsExpanded)
            {
                this.btnExpandOrderPanel.ImageIndex = 0;
                this.pnlSetCode.Size = new Size(this.pnlSetCode.Size.Width, this.mMaxHeight);
                this.mIsExpanded = false;
            }
            else
            {
                this.btnExpandOrderPanel.ImageIndex = 1;
                this.pnlSetCode.Size = new Size(this.pnlSetCode.Size.Width, this.mMinHeight);
                this.mIsExpanded = true;
            }
        }

        private void btnInsertSetGubun_Click(object sender, EventArgs e)
        {
            if (this.IsInputAvailable("1") == false) return;

            // 신규 셋트 구분 생성 

            this.tvwOCS0300.AfterLabelEdit -= new NodeLabelEditEventHandler(tvwOCS0300_AfterLabelEdit);

            // Grid 신규 로우 생성 
            int newRowNum = this.grdOCS0300.InsertRow(-1);
            this.grdOCS0300.SetItemValue(newRowNum, "memb", this.mMemb);
            this.grdOCS0300.SetItemValue(newRowNum, "memb_gubun", "00");
            this.grdOCS0300.SetItemValue(newRowNum, "pk_seq", "");
            this.grdOCS0300.SetItemValue(newRowNum, "yaksok_gubun", "00");
            this.grdOCS0300.SetItemValue(newRowNum, "yaksok_gubun_name", Resources.MSG_1);
            this.grdOCS0300.SetItemValue(newRowNum, "seq", newRowNum+1);
            this.grdOCS0300.SetItemValue(newRowNum, "hosp_code", EnvironInfo.HospCode);
            this.grdOCS0300.SetItemValue(newRowNum, "input_tab", this.cboInputTab.GetDataValue());
            
            // Tree Node 생성
            // Node Info 
            Hashtable nodeInfo = new Hashtable();
            nodeInfo.Add("memb", this.mMemb);
            nodeInfo.Add("memb_gubun", "00");
            nodeInfo.Add("pk_seq", "");
            nodeInfo.Add("yaksok_gubun", "00");
            nodeInfo.Add("yaksok_gubun_name", Resources.MSG_1);
            nodeInfo.Add("seq", newRowNum + 1);
            nodeInfo.Add("hosp_code", EnvironInfo.HospCode);
            nodeInfo.Add("row_number", newRowNum.ToString());
            nodeInfo.Add("input_tab", this.cboInputTab.GetDataValue());

            TreeNode node = new TreeNode(nodeInfo["yaksok_gubun_name"].ToString(), 12, 13);
            node.Tag = nodeInfo;
            this.tvwOCS0300.Nodes.Add(node);
            this.tvwOCS0300.SelectedNode = node;
            this.tvwOCS0300.SelectedNode.BeginEdit();

            // 이거 하고 그냥 저장 해 버리자...
            // 그래야 키값을 딸수가 있을듯...
            OCS0301U00.mPkSeq = "";

            // Updated by Cloud
            //if (this.grdOCS0300.SaveLayout() == true)
            if (SaveGrdOCS0300())
            {
                this.LoadOCS0300(false);
                if (OCS0301U00.mPkSeq != "")
                {
                    this.ReMakeTreeView(this.grdOCS0300, OCS0301U00.mPkSeq);
                    this.tvwOCS0300.SelectedNode.BeginEdit();
                }
            }

            this.tvwOCS0300.AfterLabelEdit += new NodeLabelEditEventHandler(tvwOCS0300_AfterLabelEdit);
        }

        private void btnDeleteSetGubun_Click(object sender, EventArgs e)
        {
            string currPkSeq = "";
            this.tvwOCS0300.AfterLabelEdit -= new NodeLabelEditEventHandler(tvwOCS0300_AfterLabelEdit);

            if (this.tvwOCS0300.SelectedNode == null)
            {
                XMessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.IsInputAvailable("1") == false) return;
            // 셋트 구분 삭제

            if (this.IsSetGubunDeleteAvailable() == false)
            {
                XMessageBox.Show(XMsg.GetMsg("M003"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.grdOCS0300.DeleteRow(int.Parse(((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["row_number"].ToString()));

            if (this.grdOCS0300.RowCount > 0)
                currPkSeq = this.grdOCS0300.GetItemString(this.grdOCS0300.CurrentRowNumber, "pk_seq");

            this.tvwOCS0300.Nodes.Remove(this.tvwOCS0300.SelectedNode);

            if (/*this.grdOCS0300.SaveLayout()*/SaveGrdOCS0300() == true)
            {
                this.LoadOCS0300(false);

                this.ReMakeTreeView(this.grdOCS0300, currPkSeq);
            }

            this.tvwOCS0300.AfterLabelEdit += new NodeLabelEditEventHandler(tvwOCS0300_AfterLabelEdit);
        }

        /// <summary>
        /// 약오더 입력버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrgOrder_Click(object sender, EventArgs e)
        {
            if (this.IsInputAvailable("3") == false) return;

            if (this.tvwOCS0300.SelectedNode == null ||
                this.grdOCS0300.CurrentRowNumber < 0)
                return;
            
            //switch (this.cboInputTab.GetDataValue())
            switch (this.cboInputTabNew.GetDataValue())
            {
                case "01" : // 내복약
                    this.OpenScreen_OCS0103U10();
                    break;

                case "03" : // 주사약
                    this.OpenScreen_OCS0103U12();
                    break;

                case "04" : // 검체검사
                    this.OpenScreen_OCS0103U13();
                    break;

                case "05" : // 생리검사
                    this.OpenScreen_OCS0103U14();
                    break;

                case "06":  // 병리검사
                    this.OpenScreen_OCS0103U15();
                    break; 

                case "07" : // 방사선
                    this.OpenScreen_OCS0103U16();
                    break;

                case "08" : // 처치
                    this.OpenScreen_OCS0103U17();
                    break;

                case "09":  // 마취 수술
                    this.OpenScreen_OCS0103U18();
                    break;

                case "11":  // 기타
                    this.OpenScreen_OCS0103U19();
                    break;
            }

            
        }

        private void btnYaksokGubunUp_Click(object sender, EventArgs e)
        {
            if (this.grdOCS0300.CurrentRowNumber <= 0) return;

            this.AcceptData();

            this.MoveGridRow(this.grdOCS0300, this.grdOCS0300.CurrentRowNumber, this.grdOCS0300.CurrentRowNumber - 1);
        }

        private void btnYaksokGubunDown_Click(object sender, EventArgs e)
        {
            if (this.grdOCS0300.CurrentRowNumber == this.grdOCS0300.RowCount - 1 ||
                this.grdOCS0300.CurrentRowNumber < 0)
                return;

            this.AcceptData();

            this.MoveGridRow(this.grdOCS0300, this.grdOCS0300.CurrentRowNumber, this.grdOCS0300.CurrentRowNumber + 1);
            
        }

        private void cboDoctorGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboDoctorGwa.GetDataValue() == "")
            {
                //this.ClearMemb();
                this.InitializeAll();
            }
            else
            {
                this.CreateMemb();

                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        private void cboInputTab_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboInputTab.GetDataValue() != "")
            {
                this.LoadOCS0300(true);
            }
            //insert by jc
            this.btnDrugOrder.Enabled = false;
            this.btnJusaOrder.Enabled = false;
            this.btnCplOrder.Enabled = false;
            this.btnPfeOrder.Enabled = false;
            this.btnXrtOrder.Enabled = false;
            this.btnChuchiOrder.Enabled = false;
            this.btnSusulOrder.Enabled = false;
            this.btnEtcOrder.Enabled = false;
            this.btnAplOrder.Enabled = false;
            this.btnRehaOrder.Enabled = false;

            switch (this.cboInputTab.GetDataValue())
            {
                case "00":
                    this.btnDrugOrder.Enabled = true;
                    this.btnJusaOrder.Enabled = true;
                    this.btnCplOrder.Enabled = true;
                    this.btnPfeOrder.Enabled = true;
                    this.btnXrtOrder.Enabled = true;
                    this.btnChuchiOrder.Enabled = true;
                    this.btnSusulOrder.Enabled = true;
                    this.btnEtcOrder.Enabled = true;
                    this.btnAplOrder.Enabled = true;
                    this.btnRehaOrder.Enabled = true;
                    break;
                case "01":
                    this.btnDrugOrder.Enabled = true;
                    break;
                case "03":
                    this.btnJusaOrder.Enabled = true;
                    break;
                case "04":
                    this.btnCplOrder.Enabled = true;
                    break;
                case "05":
                    this.btnPfeOrder.Enabled = true;
                    break;
                case "06":
                    this.btnAplOrder.Enabled = true;
                    break;
                case "07":
                    this.btnXrtOrder.Enabled = true;
                    break;
                case "08":
                    this.btnChuchiOrder.Enabled = true;
                    break;
                case "09":
                    this.btnSusulOrder.Enabled = true;
                    break;
                case "10":
                    this.btnRehaOrder.Enabled = true;
                    break;
                case "11":
                    this.btnEtcOrder.Enabled = true;
                    break;
            }
        }

        private void tvwOCS0300_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            this.mBufferLabel = e.Node.Text;            
        }

        private void tvwOCS0300_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            Hashtable nodeInfo = e.Node.Tag as Hashtable;

            int applyRow = int.Parse(nodeInfo["row_number"].ToString());

            if (TypeCheck.IsNull(e.Label))
            {
                if (this.mBufferLabel == "")
                {
                    XMessageBox.Show(XMsg.GetMsg("M002"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    e.Node.Text = this.mBufferLabel;

                    this.grdOCS0300.SetItemValue(applyRow, "yaksok_gubun_name", this.mBufferLabel);
                }
            }
            else if (TypeCheck.IsNull(nodeInfo["yaksok_gubun_name"]) || e.Label != nodeInfo["yaksok_gubun_name"].ToString())
            {
                nodeInfo.Remove("yaksok_gubun_name");
                nodeInfo.Add("yaksok_gubun_name", e.Label);

                this.grdOCS0300.SetItemValue(applyRow, "yaksok_gubun_name", e.Label);
            }

            this.mBufferLabel = "";
        }

        private void tvwOCS0300_AfterSelect(object sender, TreeViewEventArgs e)
        {
            grdOCS307.Reset();

            int rownumber = int.Parse(((Hashtable)e.Node.Tag)["row_number"].ToString());

            this.grdOCS0300.SetFocusToItem(rownumber, 0);

            this.LoadOCS0301(this.grdOCS0300.GetItemString(rownumber, "memb"), this.grdOCS0300.GetItemString(rownumber, "pk_seq"));
            // 로드는 변경사항 체크와 저장시 용이하게 하기 위하여 그리드의 RowFocusChanged 이벤트로 변경

            
        }

        // Load OCS0300
        private void LoadOCS0300(bool aIsMakeTree)
        {
            this.grdOCS0300.SetBindVarValue("f_memb", this.mMemb);
            this.grdOCS0300.SetBindVarValue("f_input_tab", this.cboInputTab.GetDataValue());
            this.grdOCS0300.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdOCS0300.QueryLayout(true);

            if (aIsMakeTree)
                this.ReMakeTreeView(this.grdOCS0300, "");

            if (this.tvwOCS0300.SelectedNode == null && this.tvwOCS0300.Nodes.Count > 0)
            {
                this.tvwOCS0300.SelectedNode = this.tvwOCS0300.Nodes[0];
            }

            if (this.grdOCS0300.RowCount <= 0)
            {
                this.InitializeSetCode();

            }
        }

        private void LoadOCS0301(string aMemb, string aFKOCS0300seq)
        {
            this.grdOCS0301.SetBindVarValue("f_memb", aMemb);
            this.grdOCS0301.SetBindVarValue("f_fkocs0300_seq", aFKOCS0300seq);
            this.grdOCS0301.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdOCS0301.QueryLayout(false);

            if (this.grdOCS0301.RowCount <= 0) this.InitializeOrderLayouot();
        }

        private void LoadOCS0303(string aMemb, string aFKOCS0300seq, string aYaksokCode)
        {
            this.layQueryLayout.SetBindVarValue("f_memb"         , aMemb);
            this.layQueryLayout.SetBindVarValue("f_fkocs0300_seq", aFKOCS0300seq);
            this.layQueryLayout.SetBindVarValue("f_yaksok_code"  , aYaksokCode);
            this.layQueryLayout.SetBindVarValue("f_hosp_code"    , EnvironInfo.HospCode);

            this.layQueryLayout.QueryLayout(true);

            // 중간 레이아웃 초기화
            this.layDeletedData.Reset();
            this.laySaveLayout.Reset();
            this.layDrugOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            this.laySusulOrder.Reset();
            this.layChuchiOrder.Reset();
            this.layEtcOrder.Reset();
            this.layRehaOrder.Reset();

            foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
            {
                switch (dr["input_tab"].ToString())
                {
                    case "01":  // 내복약오더

                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "03":  // 주사오더

                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "04":  // 검체검사 오더

                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "05":  // 생리검사 오더

                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "06":  // 병리검사 오더

                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "07":  // 방사선 오더

                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "08":  // 처치

                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "09":  // 마취 수술

                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "10":  // 기타 오더

                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "11":  // 기타 오더

                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }

            this.DislplayOrderDataWindow("%");

            _layDisplayTable = layDisplayLayout.LayoutTable.Copy();
        }

        private void LoadOCS0301U00grd307(string aMemb, string aFKOCS0300seq, string aYaksokCode)
        {
            this.grdOCS307.SetBindVarValue("f_memb", aMemb);
            this.grdOCS307.SetBindVarValue("f_fkocs0300_seq", aFKOCS0300seq);
            this.grdOCS307.SetBindVarValue("f_yaksok_code", aYaksokCode);
            this.grdOCS307.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            this.grdOCS307.QueryLayout(true);
            
        }

        private bool CheckUpdatingDataBefore()
        {
            for(int i = 0; i < this.grdOCS0301.DisplayRowCount; i++)
            {

                if (this.grdOCS0301.GetItemString(i, "yaksok_code") == ""
                    || this.grdOCS0301.GetItemString(i, "yaksok_name") == "")
                {
                    XMessageBox.Show(Resources.OCS0301U00_nmdt, Resources.OCS0301U00_xn);
                    return false;
                }
            }
            return true;
        }

        private bool MergeToSaveLayout()
        {
            // 약부터 시작해서 차례로 넣는다.

            this.laySaveLayout.Reset();

            // 내복약오더
            foreach (DataRow dr in this.layDrugOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 주사약오더
            foreach (DataRow dr in this.layJusaOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 검체검사오더
            foreach (DataRow dr in this.layCplOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 생리검사오더
            foreach (DataRow dr in this.layPfeOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 생리검사오더
            foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 병리검사오더
            foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 처치오더
            foreach (DataRow dr in this.layChuchiOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 수술오더
            foreach (DataRow dr in this.laySusulOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // リハビリ
            foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 기타오더
            foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            return true;
        }

        private bool SaveOCS0300()
        {
            // TODO: remove
            //if (this.grdOCS0300.SaveLayout() == false)
                return false;

            return true;
        }

        private bool SaveOCS0301()
        {
            // TODO: remove
            //if (this.grdOCS0301.SaveLayout() == false)
                return false;

            return true;
        }

        private bool SaveOCS0303()
        {
            // TODO: remove
            //if (this.layDeletedData.SaveLayout() == false)
                return false;

            if (this.laySaveLayout.SaveLayout() == false)
                return false;

            return true;
        }

        private void InitScreen()
        {
            this.cboInputTab.SelectedIndex = 0;
        }

        private void InitializeAll()
        {
            this.ClearMemb();
            this.InitializeSetCode();
            this.InitializeOrderLayouot();
        }

        private void InitializeOrderLayouot()
        {
            this.layAplOrder.Reset();
            this.layChuchiOrder.Reset();
            this.layCplOrder.Reset();
            this.layDeletedData.Reset();
            this.layDrugOrder.Reset();
            this.layEtcOrder.Reset();
            this.layJusaOrder.Reset();
            this.layPfeOrder.Reset();
            this.layQueryLayout.Reset();
            this.laySaveLayout.Reset();
            this.laySusulOrder.Reset();
            this.layXrtOrder.Reset();
            this.layRehaOrder.Reset();

            //this.dwOrderInfo.Reset();
        }

        private void InitializeSetCode()
        {
            this.grdOCS0301.Reset();

            this.InitializeOrderLayouot();
        }

        private void EnableDoctorGwaCombo(string aUserId)
        {
            this.MakeDoctorGwaCombo(aUserId);

            this.lblDoctorGwa.Visible = true;
            this.cboDoctorGwa.Visible = true;
        }

        private void DisableDoctorGwaCombo()
        {
            this.lblDoctorGwa.Visible = false;
            this.cboDoctorGwa.Visible = false;
        }

        private void MakeDoctorGwaCombo(string aUserId)
        {
            this.cboDoctorGwa.SelectedValueChanged -= new EventHandler(cboDoctorGwa_SelectedValueChanged);

            //string cmd = " SELECT '%', '共通' "
            //           + "   FROM SYS.DUAL "
            //           + "  UNION ALL "
            //           + " SELECT A.DOCTOR_GWA, B.GWA_NAME "
            //           + "   FROM BAS0272 A "
            //           + "      , BAS0260 B "
            //           + "  WHERE A.SABUN = '" + aUserId + "' "
            //           + "    AND A.START_DATE = ( SELECT MAX(X.START_DATE) "
            //           + "                           FROM BAS0272 X "
            //           + "                          WHERE X.SABUN = A.SABUN "
            //           + "                            AND X.DOCTOR_GWA = A.DOCTOR_GWA "
            //           + "                            AND X.START_DATE <= TRUNC(SYSDATE) ) "
            //           + "    AND A.DOCTOR_GWA = B.GWA " 
            //           + "    AND B.START_DATE = ( SELECT MAX(Z.START_DATE) "
            //           + "                           FROM BAS0260 Z "
            //           + "                          WHERE Z.BUSEO_CODE = B.BUSEO_CODE "
            //           + "                            AND Z.START_DATE <= TRUNC(SYSDATE) ) "
            //           + "  ORDER BY 1 ";
            this.cboDoctorGwa.SetBindVarValue("f_user_id", aUserId);
            this.cboDoctorGwa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.cboDoctorGwa.UserSQL = cmd;
            this.cboDoctorGwa.ExecuteQuery = LoadCboDoctorGwa;
            this.cboDoctorGwa.SetDictDDLB();

            if (this.cboDoctorGwa.ComboItems.Count > 0)
            {
                this.cboDoctorGwa.SelectedIndex = 0;
            }

            this.cboDoctorGwa.SelectedValueChanged += new EventHandler(cboDoctorGwa_SelectedValueChanged);
        }

        private void ClearMemb()
        {
            this.mMemb = "";
        }

        private void CreateMemb()
        {
            if (this.mCurrentMode == SetMode.DoctorMode)
            {
                if (this.cboDoctorGwa.GetDataValue() == "%")
                {
                    this.mMemb = this.fbxUser.GetDataValue();
                }
                else
                {
                    this.mMemb = this.cboDoctorGwa.GetDataValue() + this.fbxUser.GetDataValue();
                }
            }
            else
            {
                this.mMemb = this.fbxUser.GetDataValue();
            }
        }

        /// <summary>
        /// 입력가능여부 체크
        /// </summary>
        /// <param name="aCheckMode">"1" 셋트 구분 입력, "2" 셋트 코드 입력, "3" 오더입력</param>
        /// <returns></returns>
        private bool IsInputAvailable(string aCheckMode)
        {
            if (this.mMemb == "")
            {
                XMessageBox.Show(XMsg.GetMsg("M007"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.fbxUser.Focus();
                return false;
            }

            if (aCheckMode == "2" || aCheckMode == "3")
            {
                if (this.tvwOCS0300.Nodes.Count <= 0 || this.tvwOCS0300.SelectedNode == null)
                {
                    XMessageBox.Show(XMsg.GetMsg("M008"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (aCheckMode == "3")
            {
                if (this.grdOCS0301.CurrentRowNumber < 0)
                {
                    XMessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private bool IsSetGubunDeleteAvailable()
        {
            if (this.grdOCS0301.RowCount > 0) return false;

            return true;
        }

        private void RecieveAndSetOrderInfo(string aCommand, XEditGrid aGrid)
        {
            switch (aCommand)
            {
                case "OCS0103U10": // 약오더인경우 

                    #region 약오더

                    this.layDrugOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U12": // 주사오더 

                    #region 주사오더

                    this.layJusaOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layJusaOrder.SetItemValue(this.layJusaOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layJusaOrder.SetItemValue(this.layJusaOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U13": // 약오더인경우 

                    #region 검체검사

                    this.layCplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U14": // 생리검사오더 

                    #region 생리검사

                    this.layPfeOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layPfeOrder.SetItemValue(this.layPfeOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layPfeOrder.SetItemValue(this.layPfeOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U15": // 병리검사오더 

                    #region 병리검사

                    this.layAplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layAplOrder.SetItemValue(this.layAplOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layAplOrder.SetItemValue(this.layAplOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U16": // 방사선오더 

                    #region 방사선 

                    this.layXrtOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layXrtOrder.SetItemValue(this.layXrtOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layXrtOrder.SetItemValue(this.layXrtOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U17": // 처치 

                    #region 처치

                    this.layChuchiOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U18": // 수술 

                    #region 수술

                    this.laySusulOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.laySusulOrder.SetItemValue(this.laySusulOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.laySusulOrder.SetItemValue(this.laySusulOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U19": // 기타

                    #region 기타

                    this.layEtcOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;
                case "OCS0103U11": // 기타

                    #region 기타

                    this.layRehaOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (layDeletedData.LayoutTable.Select("pkocskey=" + aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString()).Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            //this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "naewon_type", this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            //this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "jubsu_no", this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                        }
                    }

                    #endregion

                    break;
            }
        }

        //private void SetDisplayLayout(string aInputTab)
        //{
        //    this.layDisplayLayout.Reset();

        //    MultiLayout layTemp = this.layDisplayLayout.Clone();
        //    MultiLayout sourceLay = this.layQueryLayout.Clone();

        //    #region [ 내복약 ]

        //    if (aInputTab == "01" || aInputTab == "%")    // 내복약
        //    {
        //        sourceLay.Reset();

        //        // 내복약 셋팅
        //        foreach (DataRow drugFilter in this.layDrugOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(drugFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

        //        foreach (DataRow drugRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(drugRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 주사약 ]

        //    if (aInputTab == "03" || aInputTab == "%")    // 주사약
        //    {
        //        sourceLay.Reset();

        //        // 주사약 셋팅
        //        foreach (DataRow jusaFilter in this.layJusaOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(jusaFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

        //        foreach (DataRow jusaRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(jusaRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 검체검사 ]

        //    if (aInputTab == "04" || aInputTab == "%")
        //    {
        //        sourceLay.Reset();

        //        // 검체검사 셋팅
        //        foreach (DataRow cplFilter in this.layCplOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(cplFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
        //        // 검체검사 오더 셋팅

        //        foreach (DataRow cplRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(cplRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 생리검사 ]

        //    if (aInputTab == "05" || aInputTab == "%")
        //    {
        //        sourceLay.Reset();

        //        // 생리검사 셋팅
        //        foreach (DataRow pfeFilter in this.layPfeOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(pfeFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
        //        // 생리검사 오더 셋팅

        //        foreach (DataRow pfeRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(pfeRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 병리검사 ]

        //    if (aInputTab == "06" || aInputTab == "%")
        //    {
        //        sourceLay.Reset();

        //        // 병리검사 셋팅
        //        foreach (DataRow aplFilter in this.layAplOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(aplFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
        //        // 병리검사 오더 셋팅

        //        foreach (DataRow aplRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(aplRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 방사선 ]

        //    if (aInputTab == "07" || aInputTab == "%")
        //    {
        //        sourceLay.Reset();

        //        // 병리검사 셋팅
        //        foreach (DataRow xrtFilter in this.layXrtOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(xrtFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
        //        // 병리검사 오더 셋팅

        //        foreach (DataRow xrtRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(xrtRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 처치오더 ]

        //    if (aInputTab == "08" || aInputTab == "%")
        //    {
        //        sourceLay.Reset();

        //        // 처치오더 셋팅
        //        foreach (DataRow chuchiFilter in this.layChuchiOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(chuchiFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
        //        // 처치 오더 셋팅

        //        foreach (DataRow chuchiRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(chuchiRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 수술오더 ]

        //    if (aInputTab == "09" || aInputTab == "%")
        //    {
        //        sourceLay.Reset();

        //        // 수술오더 셋팅
        //        foreach (DataRow susulFilter in this.laySusulOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(susulFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
        //        // 수술오더  셋팅

        //        foreach (DataRow susulRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(susulRow);
        //        }
        //    }

        //    #endregion

        //    #region [ 기타오더 ]

        //    if (aInputTab == "11" || aInputTab == "%")
        //    {
        //        sourceLay.Reset();

        //        // 기타오더 셋팅
        //        foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Rows)
        //        {
        //            sourceLay.LayoutTable.ImportRow(etcFilter);
        //        }

        //        this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
        //        // 기타오더  셋팅

        //        foreach (DataRow etcRow in layTemp.LayoutTable.Rows)
        //        {
        //            this.layDisplayLayout.LayoutTable.ImportRow(etcRow);
        //        }
        //    }

        //    #endregion
        //}

        private void SetDisplayLayout(string aInputTab)
        {
            this.layDisplayLayout.Reset();

            MultiLayout layTemp = this.layDisplayLayout.Clone();
            MultiLayout sourceLay = this.layQueryLayout.Clone();

            #region [ 내복약 ]

            if (aInputTab == "01" || aInputTab == "%")    // 내복약
            {
                sourceLay.Reset();

                // 내복약 셋팅
                //foreach (DataRow drugFilter in this.layDrugOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                //{
                //    sourceLay.LayoutTable.ImportRow(drugFilter);
                //}
                for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layDrugOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow drugRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(drugRow);
                }
            }

            #endregion

            #region [ 주사약 ]

            if (aInputTab == "03" || aInputTab == "%")    // 주사약
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow jusaRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(jusaRow);
                }
            }

            #endregion

            #region [ 검체검사 ]

            if (aInputTab == "04" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layCplOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 검체검사 오더 셋팅

                foreach (DataRow cplRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(cplRow);
                }
            }

            #endregion

            #region [ 생리검사 ]

            if (aInputTab == "05" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 생리검사 오더 셋팅

                foreach (DataRow pfeRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(pfeRow);
                }
            }

            #endregion

            #region [ 병리검사 ]

            if (aInputTab == "06" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layAplOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 병리검사 오더 셋팅

                foreach (DataRow aplRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(aplRow);
                }
            }

            #endregion

            #region [ 방사선 ]

            if (aInputTab == "07" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 병리검사 오더 셋팅

                foreach (DataRow xrtRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(xrtRow);
                }
            }

            #endregion

            #region [ 처치오더 ]

            if (aInputTab == "08" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 처치 오더 셋팅

                foreach (DataRow chuchiRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(chuchiRow);
                }
            }

            #endregion

            #region [ 수술오더 ]

            if (aInputTab == "09" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 수술오더  셋팅

                foreach (DataRow susulRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(susulRow);
                }
            }

            #endregion

            #region [ 기타오더 ]

            if (aInputTab == "11" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layEtcOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layEtcOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 기타오더  셋팅

                foreach (DataRow etcRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(etcRow);
                }
            }

            #endregion

            #region [ リハビリ ]

            if (aInputTab == "10" || aInputTab == "%")
            {
                sourceLay.Reset();

                for (int i = 0; i < this.layRehaOrder.RowCount; i++)
                {
                    sourceLay.LayoutTable.ImportRow(this.layRehaOrder.LayoutTable.Rows[i]);
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 기타오더  셋팅

                foreach (DataRow etcRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(etcRow);
                }
            }

            #endregion

        }

        private void DislplayOrderDataWindow(string aInputTab)
        {
            this.SetDisplayLayout(aInputTab);

            //this.dwOrderInfo.Reset();

            //this.dwOrderInfo.FillData(this.layDisplayLayout.LayoutTable);
        }

        private bool IsInsertGridOCS0301()
        {
            if (this.IsInputAvailable("2") == false) return false;

            ArrayList list = new ArrayList();
            bool isFind = false;

            foreach (XEditGridCell cell in this.grdOCS0301.CellInfos)
            {
                if (cell.IsNotNull)
                {
                    list.Add(cell.CellName);
                }
            }

            for (int i = 0; i < this.grdOCS0301.RowCount; i++)
            {
                if (this.grdOCS0301.GetRowState(i) == DataRowState.Added)
                {
                    foreach (string cellName in list)
                    {
                        if (this.grdOCS0301.GetItemString(i, cellName) == "")
                        {
                            isFind = true;
                            break;
                        }
                    }
                }
            }

            if (isFind) return false;

            return true;
        }

        private bool SetInitGridValue(int aRowNumber)
        {
            /*string cmd = "SELECT OCS0301_SEQ.NEXTVAL FROM SYS.DUAL";
            object obj = Service.ExecuteScalar(cmd);*/
            OCS0301U00SeqArgs args = new OCS0301U00SeqArgs();
            args.HospCode = mHospCode != null ? mHospCode : "";
            OCS0301U00SeqResult result = CloudService.Instance.Submit<OCS0301U00SeqResult, OCS0301U00SeqArgs>(args);

            Hashtable nodeInfo = this.tvwOCS0300.SelectedNode.Tag as Hashtable;
            
            this.grdOCS0301.SetItemValue(aRowNumber, "memb", nodeInfo["memb"].ToString());
            this.grdOCS0301.SetItemValue(aRowNumber, "fkocs0300_seq", nodeInfo["pk_seq"].ToString());
            this.grdOCS0301.SetItemValue(aRowNumber, "hosp_code", EnvironInfo.HospCode);
            this.grdOCS0301.SetItemValue(aRowNumber, "memb_gubun", "00");
            if(aRowNumber == 0)
                this.grdOCS0301.SetItemValue(aRowNumber, "seq", 1);
            else
                this.grdOCS0301.SetItemValue(aRowNumber, "seq", this.grdOCS0301.GetItemInt(aRowNumber-1, "seq") + 1);

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                this.grdOCS0301.SetItemValue(aRowNumber, "yaksok_code", nodeInfo["input_tab"].ToString() + "/" + nodeInfo["memb"].ToString() + "/" + nodeInfo["pk_seq"].ToString() + "/" + result.Seq);
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool IsExistModifiedData(XEditGrid grid)
        {
            if (grid.DeletedRowTable != null &&
                grid.DeletedRowTable.Rows.Count > 0)
                return true;

            for (int i = 0; i < grid.RowCount; i++)
            {
                if (grid.GetRowState(i) != DataRowState.Unchanged)
                    return true;
            }

            return false;
        }

        private bool IsExistModifiedData(MultiLayout grid)
        {
            

            for (int i = 0; i < grid.RowCount; i++)
            {
                if (grid.LayoutTable.Rows[i].RowState != DataRowState.Unchanged)
                    return true;
            }

            return false;
        }

        private bool IsExistModifiedOrderData()
        {
            if (this.layDeletedData.RowCount > 0) return true;

            foreach (object ctl in this.Controls)
            {
                if (ctl is MultiLayout )
                {
                    if (IsExistModifiedData((MultiLayout)ctl))
                        return true;
                }
            }

            return false;
        }

        private bool IsExistModifiedData()
        {
            // 셋트 구분 체크
            if (this.IsExistModifiedData(this.grdOCS0300) == true)
                return true;

            // 세트 코드 체크
            if (this.IsExistModifiedData(this.grdOCS0301) == true)
                return true;

            // 오더 체크
            if (this.IsExistModifiedOrderData() == true)
                return true;

            // 2015.07.08 AnhNV Added
            if (Compare2Tables(_layDisplayTable, layDisplayLayout.LayoutTable) == false)
            {
                return true;
            }

            return false;
        }

        #region Compare2Tables
        /// <summary>
        /// Compare2Tables
        /// </summary>
        /// <param name="table1"></param>
        /// <param name="table2"></param>
        /// <returns>TRUE: 2 tables are equal, otherwise FALSE</returns>
        private bool Compare2Tables(DataTable tbl1, DataTable tbl2)
        {
            if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
            {
                return false;
            }

            for (int i = 0; i < tbl1.Rows.Count; i++)
            {
                for (int c = 0; c < tbl1.Columns.Count; c++)
                {
                    if (!Equals(tbl1.Rows[i][c], tbl2.Rows[i][c]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        private void MoveGridRow(XEditGrid aGrid, int aFromRowNum, int aToRowNum)
        {
            MultiLayout tempLayout = aGrid.CloneToLayout();
            string selectedPkSeq = "";

            foreach (DataRow dr in aGrid.LayoutTable.Rows)
                tempLayout.LayoutTable.ImportRow(dr);

            aGrid.Reset();

            for (int i = 0; i < tempLayout.LayoutTable.Rows.Count; i++)
            {
                if (i == aFromRowNum) continue;

                if (aFromRowNum > aToRowNum && i == aToRowNum)
                {
                    aGrid.LayoutTable.ImportRow(tempLayout.LayoutTable.Rows[aFromRowNum]);
                }

                aGrid.LayoutTable.ImportRow(tempLayout.LayoutTable.Rows[i]);

                if (aFromRowNum < aToRowNum && i == aToRowNum)
                {
                    aGrid.LayoutTable.ImportRow(tempLayout.LayoutTable.Rows[aFromRowNum]);
                }
            }

            aGrid.DisplayData();

            if (this.tvwOCS0300.SelectedNode != null)
                selectedPkSeq = ((Hashtable)this.tvwOCS0300.SelectedNode.Tag)["pk_seq"].ToString();
            
            this.ReMakeTreeView(aGrid, selectedPkSeq);

            this.ReMakeSeq(aGrid);
        }

        private void ReMakeSeq(XEditGrid aGrid)
        {
            for (int i = 0; i < aGrid.RowCount; i++)
            {
                if (aGrid.GetItemString(i, "seq") != (i + 1).ToString())
                {
                    aGrid.SetItemValue(i, "seq", i + 1);
                }
            }
        }

        private void ReMakeTreeView(XEditGrid aGrid, string aSelectedPkSeq)
        {
         
            this.tvwOCS0300.AfterSelect -= new TreeViewEventHandler(tvwOCS0300_AfterSelect);
            this.tvwOCS0300.Nodes.Clear();

            Hashtable nodeInfo;
            TreeNode node = null; ;
            TreeNode selectedNode = null;

            for (int i = 0; i < aGrid.RowCount; i++)
            {
                nodeInfo = new Hashtable();

                foreach (DataColumn cl in aGrid.LayoutTable.Columns)
                {
                    nodeInfo.Add(cl.ColumnName, aGrid.GetItemString(i, cl.ColumnName));
                }
                nodeInfo.Add("row_number", i);

                node = new TreeNode(aGrid.GetItemString(i, "yaksok_gubun_name"), 12, 13);
                node.Tag = nodeInfo;

                this.tvwOCS0300.Nodes.Add(node);

                if (aGrid.GetItemString(i, "pk_seq") == aSelectedPkSeq)
                {
                    selectedNode = node;
                }
            }

            this.tvwOCS0300.AfterSelect += new TreeViewEventHandler(tvwOCS0300_AfterSelect);

            if (selectedNode != null)
            {
                this.tvwOCS0300.SelectedNode = selectedNode;
            }
        }

        private bool IsEmptySetCode()
        {
            if (this.layDrugOrder.RowCount > 0)
                return false;

            if (this.layJusaOrder.RowCount > 0)
                return false;

            if (this.layCplOrder.RowCount > 0)
                return false;

            if (this.layPfeOrder.RowCount > 0)
                return false;

            if (this.layXrtOrder.RowCount > 0)
                return false;

            if (this.layAplOrder.RowCount > 0)
                return false;

            if (this.layChuchiOrder.RowCount > 0)
                return false;

            if (this.laySusulOrder.RowCount > 0)
                return false;
            
            if (this.layEtcOrder.RowCount > 0)
                return false;

            if (this.layRehaOrder.RowCount > 0)
                return false;

            return true;

        }

        private void PostScreenLoad()
        {
            //if (!this.mIsAdminMode)
            //{
            //    this.fbxUser.SetEditValue(UserInfo.UserID);
            //    this.fbxUser.AcceptData();
            //}

            if (EnvironInfo.CurrSystemID == "OCSA")
            {
            }
            else
            {
                this.fbxUser.SetEditValue(UserInfo.UserID);
                this.fbxUser.AcceptData();
                //this.fbxUser.Protect = true;
            }

            _layDisplayTable = layDisplayLayout.LayoutTable.Copy();
        }

        private void PostUserValidating()
        {
            this.CreateMemb();

            this.btnList.PerformClick(FunctionType.Query);
        }

        private void grdOCS0300_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //isCheckReloadGrd307 = true;
            XEditGrid grid = sender as XEditGrid;

            this.LoadOCS0301(grid.GetItemString(e.CurrentRow, "memb"), grid.GetItemString(e.CurrentRow, "pk_seq"));            
        }

        private void grdOCS0300_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            if (this.IsExistModifiedData(this.grdOCS0301) ||
                this.IsExistModifiedOrderData() )
            {
                if (XMessageBox.Show(XMsg.GetMsg("M005"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.btnList.PerformClick(FunctionType.Update);
            }
        }

        private void grdOCS0301_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            if (this.IsExistModifiedOrderData())
            {
                if (XMessageBox.Show(XMsg.GetMsg("M005"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.btnList.PerformClick(FunctionType.Update);
            }
        }

        private void grdOCS0301_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            LoadOCS0303(grid.GetItemString(e.CurrentRow, "memb"), grid.GetItemString(e.CurrentRow, "fkocs0300_seq"), grid.GetItemString(e.CurrentRow, "yaksok_code"));

            LoadOCS0301U00grd307(grid.GetItemString(e.CurrentRow, "memb"), grid.GetItemString(e.CurrentRow, "fkocs0300_seq"), grid.GetItemString(e.CurrentRow, "yaksok_code"));

            memb = grid.GetItemString(e.CurrentRow, "memb");
            FKOCS0300_SEQ = grid.GetItemString(e.CurrentRow, "fkocs0300_seq");
            YAKSOK_CODE = grid.GetItemString(e.CurrentRow, "yaksok_code");
        }
        

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    this.AcceptData();
                    if (CurrMQLayout == grdOCS307)
                    {
                        if (this.IsInputAvailable("1") == false) return;
                        this.LoadOCS0300(true);
                    }
                    else
                    {
                        if (this.IsInputAvailable("1") == false) return;
                        this.LoadOCS0300(true);
                    }

                    break;

                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    if (CurrMQLayout == grdOCS307)
                    {
                        int newRow = this.grdOCS307.InsertRow(-1);
                    }
                    else
                    {
                        if (!this.IsInsertGridOCS0301()) return;

                        int newRow = this.grdOCS0301.InsertRow(-1);

                        if (!this.SetInitGridValue(newRow))
                            return;

                        //// Insert한 Row 중에 Not Null필드 미입력 Row Search 하여 해당 Row로 이동
                        //XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)this.grdOCS0301);

                        //if (emptyNewCell != null)
                        //{
                        //    e.IsSuccess = false;
                        //    e.IsBaseCall = false;

                        //    ((XEditGrid)this.grdOCS0301).SetFocusToItem(emptyNewCell.Row, emptyNewCell.CellName);
                        //    break;
                        //}              
                        memb = grdOCS0301.GetItemString(newRow, "memb");
                        FKOCS0300_SEQ = grdOCS0301.GetItemString(newRow, "fkocs0300_seq");
                        YAKSOK_CODE = grdOCS0301.GetItemString(newRow, "yaksok_code");
                    }
                    break;
                case FunctionType.Delete:

                    e.IsBaseCall = false;

                    this.AcceptData();
                    if (CurrMQLayout == grdOCS307)
                    {
                        //if (this.IsEmptySetCode() == false)
                        //{
                        //    XMessageBox.Show(XMsg.GetMsg("M011"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        //    return;
                        //}

                        //if (this.IsExistModifiedOrderData() == true)
                        //{
                        //    if (XMessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //    {
                        //        this.btnList.PerformClick(FunctionType.Update);
                        //    }
                        //    else
                        //    {
                        //        return;
                        //    }
                        //}

                        this.grdOCS307.DeleteRow(this.grdOCS307.CurrentRowNumber);
                    }
                    else
                    {
                        if (this.IsEmptySetCode() == false)
                        {
                            XMessageBox.Show(XMsg.GetMsg("M011"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            return;
                        }

                        if (this.IsExistModifiedOrderData() == true)
                        {
                            if (XMessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F002"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.btnList.PerformClick(FunctionType.Update);
                            }
                            else
                            {
                                return;
                            }
                        }

                        this.grdOCS0301.DeleteRow(this.grdOCS0301.CurrentRowNumber);
                    }
                    break;

                case FunctionType.Update:                    
                    if (grdOCS0307_CheckDuplicated())
                    {
                        XMessageBox.Show(Resources.OCS0301U00_307_duplicated, Resources.CAP_13, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (grdOCS0301.RowCount > 0)
                    {
                        if (YAKSOK_CODE.Length == 0)
                        {
                            memb = grdOCS0301.GetItemString(0, "memb");
                            FKOCS0300_SEQ = grdOCS0301.GetItemString(0, "fkocs0300_seq");
                            YAKSOK_CODE = grdOCS0301.GetItemString(0, "yaksok_code");
                        }
                    }
                    

                    e.IsBaseCall = false;
                    e.IsSuccess = true;

                    this.AcceptData();

                        if (this.CheckUpdatingDataBefore() == false) return;

                        // 저장 레이아웃 생성 
                        if (this.MergeToSaveLayout() == false) return;

                        #region deleted by Cloud
                        //// 저장시작
                        //try
                        //{
                        //    // TODO: remove
                        //    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                        //    //Service.BeginTransaction();

                        //    if (this.SaveOCS0303() == false)
                        //    {
                        //        //MessageBox.Show(XMsg.GetMsg("M006") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        MessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //      //  Service.RollbackTransaction();
                        //        return;
                        //    }

                        //    if (this.SaveOCS0301() == false)
                        //    {
                        //        //MessageBox.Show(XMsg.GetMsg("M006") + "-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        MessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        //Service.RollbackTransaction();
                        //        return;
                        //    }

                        //    if (this.SaveOCS0300() == false)
                        //    {
                        //        //MessageBox.Show(XMsg.GetMsg("M006") +"-" + Service.ErrFullMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        MessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        //Service.RollbackTransaction();
                        //        return;
                        //    }

                        //}
                        //catch
                        //{
                        //   // Service.RollbackTransaction();
                        //}
                        //finally
                        //{
                        //    this.Cursor = System.Windows.Forms.Cursors.Default;
                        //}
                        #endregion

                        // updated by Cloud
                        OCS0301U00MembCRUDArgs args = new OCS0301U00MembCRUDArgs();
                        args.UserId = UserInfo.UserID;
                        args.GrdOCS0300Info = GetGrdOCS0300ForSaveLayout();
                        args.GrdOCS0301Info = GetGrdOCS0301ForSaveLayout();
                        args.DeleteLayoutInfo = GetLayDeletedForSaveLayout();
                        args.SaveLayoutInfo = GetLaySaveForSaveLayout();
                        args.GrdOCS0307Info = GetOCS0301U00grd307ForSaveLayout();
                        args.HospCode = mHospCode != null ? mHospCode : "";


                        if (args.DeleteLayoutInfo.Count > 0 || args.GrdOCS0300Info.Count > 0
                            || args.GrdOCS0301Info.Count > 0 || args.SaveLayoutInfo.Count > 0 || args.GrdOCS0307Info.Count > 0)
                        {
                            UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS0301U00MembCRUDArgs>(args);

                            if (res.ExecutionStatus != ExecutionStatus.Success || !res.Result)
                            {
                                e.IsSuccess = false;
                                XMessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                XMessageBox.Show(Resources.MSG_SAVE, Resources.CAP_13, MessageBoxButtons.OK, MessageBoxIcon.Information);                                
                            }
                            //else
                            //{
                            //    e.IsSuccess = true;
                            //    XMessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                            //}
                        }

                        // Row focus 이벤트를 기동하여 재조회를 실시한다.
                        this.grdOCS0301_RowFocusChanged(this.grdOCS0301, new RowFocusChangedEventArgs(this.grdOCS0301.CurrentRowNumber, this.grdOCS0301.CurrentRowNumber));
                        grdOCS0301.ResetUpdate();
                        //Service.CommitTransaction();
                    
                    break;

                //case FunctionType.Close:
                //    //if (UserInfo.AdminType == AdminType.SuperAdmin)
                //    ////if (true)
                //    //{
                //    //    e.IsBaseCall = false;
                //    //    this.Close();
                //    //}

                //    DialogResult dr = XMessageBox.Show(Resources.OCS0301U00_SCREEN_CLOSE, Resources.OCS0301U00_M004, MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2, MessageBoxIcon.Asterisk);
                //    if (dr == DialogResult.Cancel)
                //    {
                //        e.IsBaseCall = false;
                //        return;
                //    }
                //    break;
            }
        }

        private bool grdOCS0307_CheckDuplicated()
        {
            bool flag = false;
            Hashtable tmp = new Hashtable();            
            for (int i = 0; i < grdOCS307.RowCount; i++)
            {
                if (!tmp.ContainsKey(grdOCS307.GetItemString(i, "sang_code")))
                {
                    if (flag == false)
                    {
                        tmp.Add(grdOCS307.GetItemString(i, "sang_code"), grdOCS307.GetItemString(i, "sang_code"));                        
                    }                   
                }
                else
                {
                    flag = true;
                    break;
                }
            }
            return flag;
            
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            int insertRow;
            int currentRow;
            

            switch (command)
            {
                case "OCS0103U10": // 약오더 화면

                    #region 약 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("drug_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["drug_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U12": // 주사오더 화면

                    #region 주사 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("jusa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["jusa_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U13": // 검체검사오더

                    #region 검체검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("gumsa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["gumsa_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U14": // 생리검사오더

                    #region 생리검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("pfe_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["pfe_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U15": // 병리검사오더

                    #region 병리검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("apl_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["apl_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U16": // 방사선오더

                    #region 방사선검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("xrt_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["xrt_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U17": // 처치오더

                    #region 처치 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("chuchi_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["chuchi_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U18": // 수술오더

                    #region 수술 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("susul_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["susul_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U19": // 기타오더

                    #region 기타오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("etc_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["etc_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U11": // リハビリ

                    #region リハビリ

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("reha_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["reha_order"]);
                            this.DislplayOrderDataWindow("%");
                        }
                    }

                    #endregion

                    break;
                case "CHT0110Q01": // 상병조회
                    if (commandParam.Contains("CHT0110") && (MultiLayout)commandParam["CHT0110"] != null &&
                        ((MultiLayout)commandParam["CHT0110"]).RowCount > 0)
                    {
                        currentRow = this.grdOCS307.CurrentRowNumber;
                        this.grdOCS307.Focus();
                        foreach (DataRow row in ((MultiLayout)commandParam["CHT0110"]).LayoutTable.Rows)
                        {
                            if (hst_Dise != null && hst_Dise.Count > 0)
                            {
                                if (!hst_Dise.ContainsKey(row["sang_code"].ToString()))
                                {
                                    if (currentRow >= 0)
                                    {
                                        this.grdOCS307.SetItemValue(currentRow, "sang_code", row["sang_code"]);
                                        this.grdOCS307.SetItemValue(currentRow, "sang_name", row["sang_name"]);
                                        grdOCS307.Refresh();
                                        currentRow = -1;
                                    }
                                    else
                                    {
                                        insertRow = this.grdOCS307.InsertRow(this.grdOCS307.CurrentRowNumber);
                                        this.grdOCS307.SetItemValue(insertRow, "sang_code", row["sang_code"]);
                                        this.grdOCS307.SetItemValue(insertRow, "sang_name", row["sang_name"]);
                                    }
                                    hst_Dise.Add(row["sang_code"].ToString(), row["sang_name"].ToString());
                                }
                            }
                            else
                            {
                                if (currentRow >= 0)
                                {
                                    this.grdOCS307.SetItemValue(currentRow, "sang_code", row["sang_code"]);
                                    this.grdOCS307.SetItemValue(currentRow, "sang_name", row["sang_name"]);
                                    grdOCS307.Refresh();
                                    currentRow = -1;
                                }
                                else
                                {
                                    insertRow = this.grdOCS307.InsertRow(this.grdOCS307.CurrentRowNumber);
                                    this.grdOCS307.SetItemValue(insertRow, "sang_code", row["sang_code"]);
                                    this.grdOCS307.SetItemValue(insertRow, "sang_name", row["sang_name"]);
                                }
                                hst_Dise.Add(row["sang_code"].ToString(), row["sang_name"].ToString());
                            }                           
                        }
                        this.grdOCS307.AcceptData();                        
                    }

                    break;					
            }
            return base.Command(command, commandParam);
        }

        private bool IsSetCode()
        {
            bool result = true;

            if (this.fbxUser.GetDataValue() == "" || this.tvwOCS0300.SelectedNode == null)
                result = false;

            if (this.grdOCS0301.RowCount < 1)
                result = false;

            if (this.grdOCS0301.GetItemString(this.grdOCS0301.CurrentRowNumber, "yaksok_code") == "")
                result = false;

            if (!result)
            {
                XMessageBox.Show(Resources.OCS0301U00_text2706, Resources.OCS0301U00_xn);
            }
            return result;
        }

        private void btnDrugOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U10();
        }

        private void btnJusaOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U12();
        }

        private void btnCplOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U13();
        }

        private void btnPfeOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U14();
        }

        private void btnXrtOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;
            
            this.OpenScreen_OCS0103U16();
        }

        private void btnChuchiOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U17();
        }

        private void btnSusulOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U18();
        }

        private void btnEtcOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U19();
        }

        private void btnReha_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U11();
        }

        private void btnAplOrder_Click(object sender, EventArgs e)
        {
            if (!IsSetCode())
                return;

            this.OpenScreen_OCS0103U15();
        }
        
        #region cloud service

        private OCS0301U00CboDoctorGwaResult GetCboDoctorGwaResult(string userId)
        {
            OCS0301U00CboDoctorGwaArgs args = new OCS0301U00CboDoctorGwaArgs();
            args.GwaInfo = new LoadColumnCodeNameInfo();
            args.GwaInfo.ColName = "gwa";
            args.GwaInfo.Arg1 = userId;
            args.UserInfo = new LoadColumnCodeNameInfo();
            args.UserInfo.ColName = "user_id";
            args.UserInfo.Arg1 = userId;
            args.UserId = userId;
            args.HospCode = mHospCode != null ? mHospCode : "";

            return CloudService.Instance.Submit<OCS0301U00CboDoctorGwaResult, OCS0301U00CboDoctorGwaArgs>(args);
        }

        private List<object[]> LoadCboDoctorGwa(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            foreach (ComboListItemInfo item in cboDoctorGwaResult.DoctorGwaCb)
            {
                object[] objects = 
			    { 
				    item.Code, 
				    item.CodeName
			    };
                res.Add(objects);
            }
            return res; 
        }

        private List<string> CreateFwkUserParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_query_mode");
            paramList.Add("f_find1");
            return paramList;
        }

        private List<object[]> LoadFwkUser(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0301U00FwkUserArgs args = new OCS0301U00FwkUserArgs();
            args.QueryMode = bc["f_query_mode"] != null ? bc["f_query_mode"].VarValue : "";
            args.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            args.HospCode = mHospCode != null ? mHospCode : "";

            OCS0301U00FwkUserResult result = CloudService.Instance.Submit<OCS0301U00FwkUserResult, OCS0301U00FwkUserArgs>(args);
            if (result != null)
            {
                foreach (TripleListItemInfo item in result.FwkUser)
                {
                    object[] objects = 
				{ 
					item.Item1, 
					item.Item2, 
					item.Item3
				};
                    res.Add(objects);
                }
            }
            return res; 
        }

        private List<string> CreateGrdOCS0300ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_memb");
            paramList.Add("f_input_tab");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0300(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0301U00GrdOCS0300Args args = new OCS0301U00GrdOCS0300Args();
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.InputTab = bc["f_input_tab"] != null ? bc["f_input_tab"].VarValue : "";
            args.HospCode = mHospCode != null ? mHospCode : "";

            OCS0301U00GrdOCS0300Result result = CloudService.Instance.Submit<OCS0301U00GrdOCS0300Result, OCS0301U00GrdOCS0300Args>(args);
            if (result != null)
            {
                foreach (OCS0301U00MembGrdInfo item in result.GridInfo)
                {
                    object[] objects = 
				{ 
					item.Memb, 
					item.KeySeq, 
					item.Yaksok, 
					item.YaksokName, 
					item.Seq, 
					item.HospCode, 
					item.MembGubun, 
					item.InputTab
				};
                    res.Add(objects);
                }
            }
            return res; 
        }
        private List<string> CreateGrdOCS0301ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_memb");
            paramList.Add("f_fkocs0300_seq");
            return paramList;
        }

        private List<object[]> LoadGrdOCS0301(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0301U00GrdOCS0301Args args = new OCS0301U00GrdOCS0301Args();
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.Fkocs0300Seq = bc["f_fkocs0300_seq"] != null ? bc["f_fkocs0300_seq"].VarValue : "";
            args.HospCode = mHospCode != null ? mHospCode : "";

            OCS0301U00GrdOCS0301Result result = CloudService.Instance.Submit<OCS0301U00GrdOCS0301Result, OCS0301U00GrdOCS0301Args>(args);
            if (result != null)
            {
                foreach (OCS0301U00MembGrdInfo item in result.GridInfo)
                {
                    object[] objects = 
				{ 
					item.Memb, 
					item.KeySeq, 
					item.Yaksok, 
					item.YaksokName, 
					item.Seq, 
					item.HospCode, 
					item.MembGubun, 
					item.InputTab
				};
                    res.Add(objects);
                }
            }
            return res; 
        }
        private List<string> CreateLayQueryLayoutParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_memb");
            paramList.Add("f_fkocs0300_seq");
            paramList.Add("f_yaksok_code");
            return paramList;
        }

        private List<object[]> LoadLayQueryLayout(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCS0301U00LayQueryLayoutArgs args = new OCS0301U00LayQueryLayoutArgs();
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.Fkocs0300Seq = bc["f_fkocs0300_seq"] != null ? bc["f_fkocs0300_seq"].VarValue : "";
            args.YaksokCode = bc["f_yaksok_code"] != null ? bc["f_yaksok_code"].VarValue : "";
            args.HospCode = mHospCode != null ? mHospCode : "";

            OCS0301U00LayQueryLayoutResult result = CloudService.Instance.Submit<OCS0301U00LayQueryLayoutResult, OCS0301U00LayQueryLayoutArgs>(args);
            if (result != null)
            {
                
                foreach (OCS0301U00LayoutInfo item in result.LayoutInfo)
                {
                    object[] objects = 
				{ 
					item.InOutKey, 
					item.Pkocskey, 
					item.Bunho, 
					item.OrderDate, 
					item.Gwa, 
					item.Doctor, 
					item.Resident, 
					item.NaewonType, 
					item.JubsuNo, 
					item.InputId, 
					item.InputPart, 
					item.InputGwa, 
					item.InputDoctor, 
					item.InputGubun, 
					item.InputGubunName, 
					item.GroupSer, 
					item.InputTab, 
					item.InputTabName, 
					item.OrderGubun, 
					item.OrderGubunName, 
					item.GroupYn, 
					item.Seq, 
					item.SlipCode, 
					item.HangmogCode, 
					item.HangmogName, 
					item.SpecimenCode, 
					item.SpecimenName, 
					item.Suryang, 
					item.SunabSuryang, 
					item.SubulSuryang, 
					item.OrdDanui, 
					item.OrdDanuiName, 
					item.DvTime, 
					item.Dv, 
					item.Dv1, 
					item.Dv2, 
					item.Dv3, 
					item.Dv4, 
					item.Nalsu, 
					item.SunabNalsu, 
					item.Jusa, 
					item.JusaName, 
					item.JusaSpdGubun, 
					item.BogyongCode, 
					item.BogyongName, 
					item.Emergency, 
					item.JaeryoJundalYn, 
					item.JundalTable, 
					item.JundalPart, 
					item.MovePart, 
					item.PortableYn, 
					item.PowderYn, 
					item.HubalChangeYn, 
					item.Pharmacy, 
					item.DrgPackYn, 
					item.Muhyo, 
					item.PrnYn, 
					item.ToiwonDrgYn, 
					item.PrnNurse, 
					item.AppendYn, 
					item.OrderRemark, 
					item.NurseRemark, 
					item.Comments, 
					item.MixGroup, 
					item.Amt, 
					item.Pay, 
					item.WonyoiOrderYn, 
					item.DangilGumsaOrderYn, 
					item.DangilGumsaResultYn, 
					item.BomOccurYn, 
					item.BomSourceKey, 
					item.DisplayYn, 
					item.SunabYn, 
					item.SunabDate, 
					item.SunabTime, 
					item.HopeDate, 
					item.HopeTime, 
					item.NurseConfirmUser, 
					item.NurseConfirmDate, 
					item.NurseConfirmTime, 
					item.NursePickupUser, 
					item.NursePickupDate, 
					item.NursePickupTime, 
					item.NurseHoldUser, 
					item.NurseHoldDate, 
					item.NurseHoldTime, 
					item.ReserDate, 
					item.ReserTime, 
					item.JubsuDate, 
					item.JubsuTime, 
					item.ActingDate, 
					item.ActingTime, 
					item.ActingDay, 
					item.ResultDate, 
					item.DcGubun, 
					item.DcYn, 
					item.BannabYn, 
					item.BannabConfirm, 
					item.SourceOrdKey, 
					item.OcsFlag, 
					item.SgCode, 
					item.SgYmd, 
					item.IoGubun, 
					item.AfterActYn, 
					item.BichiYn, 
					item.DrgBunho, 
					item.SubSusul, 
					item.PrintYn, 
					item.Chisik, 
					item.TelYn, 
					item.OrderGubunBas, 
					item.InputControl, 
					item.SugaYn, 
					item.JaeryoYn, 
					item.WonyoiCheck, 
					item.EmergencyCheck, 
					item.SpecimenCheck, 
					item.PortableYn2, 
					item.BulyongCheck, 
					item.SunabCheck, 
					item.DcCheck, 
					item.DcGubunCheck, 
					item.ConfirmCheck, 
					item.ReserYnCheck, 
					item.ChisikYn, 
					item.NdayYn, 
					item.DefaultJaeryoJundalYn, 
					item.DefaultWonyoiYn, 
					item.SpecificComment, 
					item.SpecificCommentName, 
					item.SpecificCommentSysId, 
					item.SpecificCommentPgmId, 
					item.SpecificCommentNotNull, 
					item.SpecificCommentTableId, 
					item.SpecificCommentColId, 
					item.DonbogYn, 
					item.OrderGubunBasName, 
					item.ActDoctor, 
					item.ActBuseo, 
					item.ActGwa, 
					item.HomeCareYn, 
					item.RegularYn, 
					item.SortFkocskey, 
					item.ChildYn, 
					item.IfInputControl, 
					item.SlipName, 
					item.OrgKey, 
					item.ParentKey, 
					item.BunCode, 
					item.Memb, 
					item.YaksokCode, 
					item.WonnaeDrgYn, 
					item.HubalChangeCheck, 
					item.DrgPackCheck, 
					item.PharmacyCheck, 
					item.PowderCheck, 
					item.JundalTableOut, 
					item.JundalPartOut, 
					item.JundalTableInp, 
					item.JundalPartInp, 
					item.MovePartOut, 
					item.MovePartInp, 
                    item.Dv5,
                    item.Dv6,
                    item.Dv7,
                    item.Dv8,
					item.GeneralDispYn, 
					item.OrderByKey
				};
                    res.Add(objects);
                }
            }
            return res; 
        }

        private List<object[]> LoadCboInputTab(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ComboInputTabArgs args = new ComboInputTabArgs();
            args.HospCode = mHospCode;
           // hoangVV MED-8428
            ComboResult result = CacheService.Instance.Get<ComboInputTabArgs, ComboResult>(args);
           //old ComboResult result = CacheService.Instance.Get<ComboInputTabArgs, ComboResult>(new ComboInputTabArgs());
           //end MED-8428
           // ComboResult result = CloudService.Instance.Submit<ComboResult, ComboInputTabArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    res.Add(new object[]
                    {
                        item.Code,
                        item.CodeName
                    });
                }
            }
            return res;
        }

        private List<object[]> LoadOCS0301U00grd307(BindVarCollection bc)
        {
            hst_Dise = new Hashtable();

            List<object[]> res = new List<object[]>();
            OCS0301U00LayQueryLayoutArgs args = new OCS0301U00LayQueryLayoutArgs();
            args.Memb = bc["f_memb"] != null ? bc["f_memb"].VarValue : "";
            args.Fkocs0300Seq = bc["f_fkocs0300_seq"] != null ? bc["f_fkocs0300_seq"].VarValue : "";
            args.YaksokCode = bc["f_yaksok_code"] != null ? bc["f_yaksok_code"].VarValue : "";
            args.HospCode = mHospCode != null ? mHospCode : "";

            OCS0301U00LayQueryLayoutResult result = CloudService.Instance.Submit<OCS0301U00LayQueryLayoutResult, OCS0301U00LayQueryLayoutArgs>(args);
            if (result != null)
            {

                foreach (OCS0301U00Membgrd307Info item in result.ListInfo)
                {
                    object[] objects = 
				    { 
    					item.SangCode,
                        item.SangName,
                        item.Pkocs0307,
                        item.DataRowState
				    };
                    res.Add(objects);
                    if (!hst_Dise.ContainsKey(item.SangCode.ToString()))
                    {
                        hst_Dise.Add(item.SangCode.ToString(), item.SangName.ToString());
                    }
                   
                }
            }
            //isCheckReloadGrd307 = false;
            return res;
         
        }

        #region GetGrdOCS0300ForSaveLayout
        /// <summary>
        /// GetGrdOCS0300ForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0301U00MembGrdInfo> GetGrdOCS0300ForSaveLayout()
        {
            List<OCS0301U00MembGrdInfo> lstData = new List<OCS0301U00MembGrdInfo>();

            for (int i = 0; i < grdOCS0300.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdOCS0300.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0301U00MembGrdInfo item  = new OCS0301U00MembGrdInfo();
                item.InputTab               = grdOCS0300.GetItemString(i, "input_tab");
                item.KeySeq                 = grdOCS0300.GetItemString(i, "pk_seq");
                item.Memb                   = grdOCS0300.GetItemString(i, "memb");
                item.MembGubun              = grdOCS0300.GetItemString(i, "memb_gubun");
                item.Seq                    = grdOCS0300.GetItemString(i, "seq");
                item.Yaksok                 = grdOCS0300.GetItemString(i, "yaksok_gubun");
                item.YaksokName             = grdOCS0300.GetItemString(i, "yaksok_gubun_name");
                item.DataRowState           = grdOCS0300.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // deleted
            if (null != grdOCS0300.DeletedRowTable)
            {
                for (int i = 0; i < grdOCS0300.DeletedRowTable.Rows.Count; i++)
                {
                    OCS0301U00MembGrdInfo item  = new OCS0301U00MembGrdInfo();
                    item.KeySeq                 = grdOCS0300.DeletedRowTable.Rows[i]["pk_seq"].ToString();
                    item.Memb                   = grdOCS0300.DeletedRowTable.Rows[i]["memb"].ToString();
                    item.MembGubun              = grdOCS0300.DeletedRowTable.Rows[i]["memb_gubun"].ToString();
                    item.DataRowState           = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetOCS0301U00grd307ForSaveLayout
        /// <summary>
        /// GetOCS0301U00grd307ForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0301U00Membgrd307Info> GetOCS0301U00grd307ForSaveLayout()
        {
            List<OCS0301U00Membgrd307Info> lstData = new List<OCS0301U00Membgrd307Info>();            
            //Hashtable tmp = new Hashtable();            
            for (int i = 0; i < grdOCS307.RowCount; i++)
            {
                
                if (grdOCS307.GetRowState(i) == DataRowState.Unchanged) continue;
                //if (!tmp.ContainsKey(grdOCS307.GetItemString(i, "sang_code")))
                //{
                    OCS0301U00Membgrd307Info item = new OCS0301U00Membgrd307Info();
                    item.Memb = memb;
                    item.Fkocs0300Seq = FKOCS0300_SEQ;
                    item.YaksokCode = YAKSOK_CODE;
                    item.Pkocs0307 = grdOCS307.GetItemString(i, "pkocs0307");
                    item.DataRowState = grdOCS307.GetRowState(i).ToString();
                    item.SangCode = grdOCS307.GetItemString(i, "sang_code");
                    item.SangName = grdOCS307.GetItemString(i, "sang_name");
                    lstData.Add(item);
                   // tmp.Add(grdOCS307.GetItemString(i, "sang_code"), grdOCS307.GetItemString(i, "sang_code"));
                //}
                
            }
            

            // deleted
            if (null != grdOCS307.DeletedRowTable)
            {
                for (int i = 0; i < grdOCS307.DeletedRowTable.Rows.Count; i++)
                {
                    OCS0301U00Membgrd307Info item = new OCS0301U00Membgrd307Info();
                    item.Memb = "";
                    item.Fkocs0300Seq = "";
                    item.YaksokCode = "";
                    item.Pkocs0307 = grdOCS307.DeletedRowTable.Rows[i]["pkocs0307"].ToString();
                    item.DataRowState = DataRowState.Deleted.ToString();
                    item.SangCode = grdOCS307.DeletedRowTable.Rows[i]["sang_code"].ToString(); ;
                    item.SangName = grdOCS307.DeletedRowTable.Rows[i]["sang_name"].ToString(); ;
                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetGrdOCS0301ForSaveLayout
        /// <summary>
        /// GetGrdOCS0301ForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0301U00MembGrdInfo> GetGrdOCS0301ForSaveLayout()
        {
            List<OCS0301U00MembGrdInfo> lstData = new List<OCS0301U00MembGrdInfo>();

            for (int i = 0; i < grdOCS0301.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdOCS0301.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0301U00MembGrdInfo item = new OCS0301U00MembGrdInfo();
                item.KeySeq                 = grdOCS0300.GetItemString(grdOCS0300.CurrentRowNumber, "pk_seq");
                item.Memb                   = grdOCS0300.GetItemString(grdOCS0300.CurrentRowNumber, "memb");
                item.MembGubun              = grdOCS0301.GetItemString(i, "memb_gubun");

                string seq = char.GetNumericValue(grdOCS0301.GetItemString(i, "seq"), 0).ToString();
                item.Seq = seq;

                item.Yaksok                 = grdOCS0301.GetItemString(i, "yaksok_code");
                item.YaksokName             = grdOCS0301.GetItemString(i, "yaksok_name");
                item.DataRowState           = grdOCS0301.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // deleted
            if (null != grdOCS0301.DeletedRowTable)
            {
                for (int i = 0; i < grdOCS0301.DeletedRowTable.Rows.Count; i++)
                {
                    OCS0301U00MembGrdInfo item  = new OCS0301U00MembGrdInfo();
                    item.KeySeq                 = grdOCS0300.GetItemString(grdOCS0300.CurrentRowNumber, "pk_seq");
                    item.Memb                   = grdOCS0300.GetItemString(grdOCS0300.CurrentRowNumber, "memb");
                    item.Yaksok                 = grdOCS0301.DeletedRowTable.Rows[i]["yaksok_code"].ToString();
                    item.MembGubun              = grdOCS0301.DeletedRowTable.Rows[i]["memb_gubun"].ToString();
                    item.DataRowState           = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion
        private void grdOCS0301_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            int myInt;
            if (!Int32.TryParse(grdOCS0301.GetItemString(grdOCS0301.CurrentRowNumber, "seq"), out myInt))
            {
                e.Cancel = true;   
            }
        }
        #region GetLayDeletedForSaveLayout
        /// <summary>
        /// GetLayDeletedForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0301U00SaveLayoutInfo> GetLayDeletedForSaveLayout()
        {
            List<OCS0301U00SaveLayoutInfo> lstData = new List<OCS0301U00SaveLayoutInfo>();

            if (null != this.layDeletedData.LayoutTable)
            {
                for (int i = 0; i < this.layDeletedData.LayoutTable.Rows.Count; i++)
                {
                    OCS0301U00SaveLayoutInfo item = new OCS0301U00SaveLayoutInfo();
                    item.Pkocskey = layDeletedData.LayoutTable.Rows[i]["pkocskey"].ToString();
                    item.DataRowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetLaySaveForSaveLayout
        /// <summary>
        /// GetLaySaveForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0301U00SaveLayoutInfo> GetLaySaveForSaveLayout()
        {
            List<OCS0301U00SaveLayoutInfo> lstData = new List<OCS0301U00SaveLayoutInfo>();
            MergeToSaveLayout();

            if (null != this.laySaveLayout.LayoutTable)
            {
                for (int i = 0; i < this.laySaveLayout.LayoutTable.Rows.Count; i++)
                {
                    // Skip unchanged rows
                    if (this.laySaveLayout.LayoutTable.Rows[i].RowState == DataRowState.Unchanged) continue;

                    OCS0301U00SaveLayoutInfo item = new OCS0301U00SaveLayoutInfo();

                    item.Memb                   = grdOCS0300.GetItemString(grdOCS0300.CurrentRowNumber, "memb");
                    item.YaksokCode             = laySaveLayout.LayoutTable.Rows[i]["yaksok_code"].ToString();
                    item.GroupSer               = laySaveLayout.LayoutTable.Rows[i]["group_ser"].ToString();
                    item.HangmogCode            = laySaveLayout.LayoutTable.Rows[i]["hangmog_code"].ToString();
                    item.Seq                    = laySaveLayout.LayoutTable.Rows[i]["seq"].ToString();
                    //item.Pkocskey               = grdOCS0300.GetItemString(grdOCS0300.CurrentRowNumber, "pk_seq");
                    item.Pkocskey               = laySaveLayout.LayoutTable.Rows[i]["pkocskey"].ToString();
                    item.SpecimenCode           = laySaveLayout.LayoutTable.Rows[i]["specimen_code"].ToString();
                    item.Suryang                = laySaveLayout.LayoutTable.Rows[i]["suryang"].ToString();
                    item.OrdDanui               = laySaveLayout.LayoutTable.Rows[i]["ord_danui"].ToString();
                    item.DvTime                 = laySaveLayout.LayoutTable.Rows[i]["dv_time"].ToString();
                    item.Dv                     = laySaveLayout.LayoutTable.Rows[i]["dv"].ToString();
                    item.Nalsu                  = laySaveLayout.LayoutTable.Rows[i]["nalsu"].ToString();
                    item.Jusa                   = laySaveLayout.LayoutTable.Rows[i]["jusa"].ToString();
                    item.BogyongCode            = laySaveLayout.LayoutTable.Rows[i]["bogyong_code"].ToString();
                    item.Emergency              = laySaveLayout.LayoutTable.Rows[i]["emergency"].ToString();
                    item.Muhyo                  = laySaveLayout.LayoutTable.Rows[i]["muhyo"].ToString();
                    item.PortableYn             = laySaveLayout.LayoutTable.Rows[i]["portable_yn"].ToString();
                    item.Pay                    = laySaveLayout.LayoutTable.Rows[i]["pay"].ToString();
                    item.PowderYn               = laySaveLayout.LayoutTable.Rows[i]["powder_yn"].ToString();
                    item.Dv1                    = laySaveLayout.LayoutTable.Rows[i]["dv_1"].ToString();
                    item.Dv2                    = laySaveLayout.LayoutTable.Rows[i]["dv_2"].ToString();
                    item.Dv3                    = laySaveLayout.LayoutTable.Rows[i]["dv_3"].ToString();
                    item.Dv4                    = laySaveLayout.LayoutTable.Rows[i]["dv_4"].ToString();
                    item.MixGroup               = laySaveLayout.LayoutTable.Rows[i]["mix_group"].ToString();
                    item.Dv5                    = laySaveLayout.LayoutTable.Rows[i]["dv_5"].ToString();
                    item.Dv6                    = laySaveLayout.LayoutTable.Rows[i]["dv_6"].ToString();
                    item.Dv7                    = laySaveLayout.LayoutTable.Rows[i]["dv_7"].ToString();
                    item.Dv8                    = laySaveLayout.LayoutTable.Rows[i]["dv_8"].ToString();
                    item.OrderRemark            = laySaveLayout.LayoutTable.Rows[i]["order_remark"].ToString();
                    item.NurseRemark            = laySaveLayout.LayoutTable.Rows[i]["nurse_remark"].ToString();
                    item.OrderGubun             = laySaveLayout.LayoutTable.Rows[i]["order_gubun"].ToString();
                    item.WonyoiOrderYn          = laySaveLayout.LayoutTable.Rows[i]["wonyoi_order_yn"].ToString();
                    item.DangilGumsaOrderYn     = laySaveLayout.LayoutTable.Rows[i]["dangil_gumsa_order_yn"].ToString();
                    item.DangilGumsaResultYn    = laySaveLayout.LayoutTable.Rows[i]["dangil_gumsa_result_yn"].ToString();
                    item.InputTab               = laySaveLayout.LayoutTable.Rows[i]["input_tab"].ToString();
                    //item.HubulChangeYn          = laySaveLayout.LayoutTable.Rows[i]["hubul_change_yn"].ToString();
                    item.Pharmacy               = laySaveLayout.LayoutTable.Rows[i]["pharmacy"].ToString();
                    item.JusaSpdGubun           = laySaveLayout.LayoutTable.Rows[i]["jusa_spd_gubun"].ToString();
                    item.DrgPackYn              = laySaveLayout.LayoutTable.Rows[i]["drg_pack_yn"].ToString();
                    //item.HospCode               = laySaveLayout.LayoutTable.Rows[i]["hosp_code"].ToString();
                    item.HangmogName            = laySaveLayout.LayoutTable.Rows[i]["hangmog_name"].ToString();
                    item.Amt                    = laySaveLayout.LayoutTable.Rows[i]["amt"].ToString();
                    item.BomSourceKey           = laySaveLayout.LayoutTable.Rows[i]["bom_source_key"].ToString();
                    item.NdayYn                 = laySaveLayout.LayoutTable.Rows[i]["nday_yn"].ToString();
                    item.InOutKey               = laySaveLayout.LayoutTable.Rows[i]["in_out_key"].ToString();
                    item.JundalTableOut         = laySaveLayout.LayoutTable.Rows[i]["jundal_table_out"].ToString();
                    item.JundalPartOut          = laySaveLayout.LayoutTable.Rows[i]["jundal_part_out"].ToString();
                    item.JundalTableInp         = laySaveLayout.LayoutTable.Rows[i]["jundal_table_inp"].ToString();
                    item.JundalPartInp          = laySaveLayout.LayoutTable.Rows[i]["jundal_part_inp"].ToString();
                    item.MovePartOut            = laySaveLayout.LayoutTable.Rows[i]["move_part_out"].ToString();
                    item.MovePartInp            = laySaveLayout.LayoutTable.Rows[i]["move_part_inp"].ToString();
                    item.GeneralDispYn          = laySaveLayout.LayoutTable.Rows[i]["general_disp_yn"].ToString();
                    //item.HubalChangeYn          = laySaveLayout.LayoutTable.Rows[i]["hubal_change_yn"].ToString();
                    item.DataRowState           = laySaveLayout.LayoutTable.Rows[i].RowState.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region SaveGrdOCS0300
        /// <summary>
        /// SaveGrdOCS0300
        /// </summary>
        /// <returns></returns>
        private bool SaveGrdOCS0300()
        {
            OCS0301U00MembCRUDArgs args = new OCS0301U00MembCRUDArgs();
            args.UserId = UserInfo.UserID;
            args.GrdOCS0300Info = GetGrdOCS0300ForSaveLayout();
            args.GrdOCS0301Info = new List<OCS0301U00MembGrdInfo>(); // don't use
            args.DeleteLayoutInfo = new List<OCS0301U00SaveLayoutInfo>(); // don't use
            args.SaveLayoutInfo = new List<OCS0301U00SaveLayoutInfo>(); // don't use
            args.GrdOCS0307Info = new List<OCS0301U00Membgrd307Info>(); // don't use
            args.HospCode = mHospCode != null ? mHospCode : "";
            
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS0301U00MembCRUDArgs>(args);

            if (res.ExecutionStatus != ExecutionStatus.Success)
            {
                return false;
            }

            OCS0301U00.mPkSeq = res.Msg;
            return true;
        }
        #endregion

        

        private void xHospBox1_FindClick(object sender, EventArgs e)
        {
            this.mHospCode = xHospBox1.HospCode;

            CreateMemb();
            btnList.PerformClick(FunctionType.Query);
            cboInputTab.SetDictDDLB();
            cboInputTabNew.SetDictDDLB();
            cboDoctorGwa.SetDictDDLB();
        }

        #endregion

        private void xHospBox1_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (!e.Cancel)
            {
                this.mHospCode = xHospBox1.HospCode;

                CreateMemb();
                btnList.PerformClick(FunctionType.Query);
                cboInputTab.SetDictDDLB();
                cboInputTabNew.SetDictDDLB();
                cboDoctorGwa.SetDictDDLB();
            }
        }


        private void grdOCS307_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;
            XEditGrid grd = sender as XEditGrid;

            if (sender == null ||
                ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;
            switch (e.ColName)
            {
                case "sang_code": // 상병코드

                    CommonItemCollection openParams = new CommonItemCollection();
                    openParams.Add("sang_inx",
                        ((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).GetDataValue());

                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseSizable, openParams);

                    e.Cancel = true;
                    break;

                default:

                    break;
            }


            //CommonItemCollection openParams = new CommonItemCollection();
            //openParams.Add("sang_inx","");
            //XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }
    }

    // deleted by Cloud
    #region XSavePeformer
    //public class XSavePeformer : ISavePerformer
    //{
    //    private OCS0301U00 parent = null;
    //    private IHIS.OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OCS0301U00");


    //    public XSavePeformer(OCS0301U00 parent)
    //    {
    //        this.parent = parent;
    //    }

    //    public bool Execute(char callerId, RowDataItem item)
    //    {
    //        string cmdText = "";
    //        object t_chk = "";
    //        string spName = "";
    //        ArrayList inList = new ArrayList();
    //        ArrayList outList = new ArrayList();

    //        item.BindVarList.Add("q_user_id", UserInfo.UserID);
    //        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
    //        switch (callerId)
    //        {
    //            case '1':    // 셋트 구분 

    //                #region 셋트 구분 저장

    //                if (item.RowState == DataRowState.Added)
    //                {
    //                    cmdText = " SELECT MAX(A.PK_SEQ) + 1"
    //                            + "   FROM OCS0300 A "
    //                            + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
    //                            + "    AND A.MEMB_GUBUN = '" + item.BindVarList["f_memb_gubun"].VarValue + "' "
    //                            + "    AND A.MEMB = '" + item.BindVarList["f_memb"].VarValue + "' ";

    //                    t_chk = Service.ExecuteScalar(cmdText);

    //                    if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "" || t_chk.ToString() == "0")
    //                    {
    //                        t_chk = "1";
    //                    }

    //                    OCS0301U00.mPkSeq = t_chk.ToString();

    //                    cmdText = " INSERT INTO OCS0300 "
    //                            + "      ( SYS_DATE         , SYS_ID    , UPD_DATE  , UPD_ID "
    //                            + "      , HOSP_CODE        , MEMB      , PK_SEQ    , YAKSOK_GUBUN "
    //                            + "      , YAKSOK_GUBUN_NAME, SEQ       , MEMB_GUBUN, INPUT_TAB ) "
    //                            + " VALUES "
    //                            + "      ( SYSDATE             , :q_user_id, SYSDATE   , :q_user_id "
    //                            + "      , :f_hosp_code        , :f_memb   , " + t_chk.ToString() + ", :f_yaksok_gubun "
    //                            + "      , :f_yaksok_gubun_name, :f_seq    , :f_memb_gubun, :f_input_tab ) ";
    //                }
    //                else if (item.RowState == DataRowState.Modified)
    //                {
    //                    cmdText = " UPDATE OCS0300 "
    //                            + "    SET SEQ = :f_seq "
    //                            + "      , YAKSOK_GUBUN_NAME = :f_yaksok_gubun_name "
    //                            + "      , UPD_ID = :q_user_id "
    //                            + "      , UPD_DATE = SYSDATE "
    //                            + "  WHERE HOSP_CODE = :f_hosp_code "
    //                            + "    AND MEMB_GUBUN = :f_memb_gubun "
    //                            + "    AND MEMB = :f_memb "
    //                            + "    AND PK_SEQ = :f_pk_seq ";
    //                }
    //                else if (item.RowState == DataRowState.Deleted)
    //                {
    //                    cmdText = " DELETE FROM OCS0300 "
    //                            + "  WHERE HOSP_CODE = :f_hosp_code "
    //                            + "    AND MEMB_GUBUN = :f_memb_gubun "
    //                            + "    AND MEMB = :f_memb "
    //                            + "    AND PK_SEQ = :f_pk_seq ";
    //                }


    //                #endregion

    //                break;

    //            case '4':    // 셋트 코드

    //                #region 셋트 코드 저장 

    //                switch (item.RowState)
    //                {
    //                    case DataRowState.Added:



    //                        cmdText = " INSERT INTO OCS0301 "
    //                                + "      ( SYS_DATE     , SYS_ID     , UPD_DATE  , UPD_ID "
    //                                + "      , MEMB         , YAKSOK_CODE, YAKSOK_NAME, SEQ    "
    //                                + "      , FKOCS0300_SEQ, HOSP_CODE  , MEMB_GUBUN) "
    //                                + " VALUES "
    //                                + "      ( SYSDATE         , :q_user_id    , SYSDATE       , :q_user_id "
    //                                + "      , :f_memb         , :f_yaksok_code, :f_yaksok_name, :f_seq "
    //                                + "      , :f_fkocs0300_seq, :f_hosp_code  , :f_memb_gubun ) ";

    //                        break;

    //                    case DataRowState.Modified:

    //                        cmdText = " UPDATE OCS0301 "
    //                                + "    SET SEQ           = :f_seq "
    //                                + "      , YAKSOK_NAME   = :f_yaksok_name "
    //                                + "      , UPD_DATE      = SYSDATE "
    //                                + "      , UPD_ID        = :q_user_id "
    //                                + "  WHERE HOSP_CODE     = :f_hosp_code "
    //                                + "    AND MEMB          = :f_memb "
    //                                + "    AND FKOCS0300_SEQ = :f_fkocs0300_seq "
    //                                + "    AND YAKSOK_CODE   = :f_yaksok_code ";

    //                        break;

    //                    case DataRowState.Deleted:

    //                        cmdText = " DELETE FROM OCS0301 "
    //                                + "  WHERE HOSP_CODE     = :f_hosp_code "
    //                                + "    AND MEMB          = :f_memb "
    //                                + "    AND FKOCS0300_SEQ = :f_fkocs0300_seq "
    //                                + "    AND YAKSOK_CODE   = :f_yaksok_code ";

    //                        break;
    //                }

    //                #endregion

    //                break;

    //            case '2':    // 삭제로직...

    //                #region 오더 삭제

                    
    //                cmdText = " DELETE FROM OCS0303 "
    //                        + "  WHERE HOSP_CODE = :f_hosp_code "
    //                        + "    AND PKOCS0303 = :f_pkocskey ";

    //                #endregion

    //                break;

    //            case '3':    // 인서트 & 업데이트 

    //                #region 오더 입력 및 변경

    //                switch (item.RowState)
    //                {
    //                    case DataRowState.Added:
    //                        // 키가 입력되지 않은경우 키를 따야함..
    //                        if (item.BindVarList["f_pkocskey"].VarValue == "")
    //                        {
    //                            cmdText = " SELECT OCS0303_SEQ.NEXTVAL "
    //                                    + "   FROM SYS.DUAL ";

    //                            t_chk = Service.ExecuteScalar(cmdText);

    //                            item.BindVarList.Remove("f_pkocskey");
    //                            item.BindVarList.Add("f_pkocskey", t_chk.ToString());
    //                        }

    //                        // 시퀀스 가져오기
    //                        if (item.BindVarList["f_seq"].VarValue == "")
    //                        {
    //                            cmdText = " SELECT MAX(SEQ)+1 SEQ "
    //                                    + "   FROM OCS0303 "
    //                                    + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
    //                                    + "    AND MEMB = '" + item.BindVarList["f_memb"].VarValue + "' "
    //                                    + "    AND YAKSOK_CODE = '" + item.BindVarList["f_yaksok_code"].VarValue + "' "
    //                                    + "    AND FKOCS0300_SEQ = " + item.BindVarList["f_in_out_key"].VarValue + " ";

    //                            t_chk = Service.ExecuteScalar(cmdText);

    //                            if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
    //                            {
    //                                t_chk = "1";
    //                            }

    //                            item.BindVarList.Remove("f_seq");
    //                            item.BindVarList.Add("f_seq", t_chk.ToString());
    //                        }

    //                        if (item.BindVarList["f_general_disp_yn"].VarValue == "")
    //                            item.BindVarList["f_general_disp_yn"].VarValue = "N";

    //                        cmdText = " INSERT INTO OCS0303 "
    //                                + "      ( SYS_DATE             , SYS_ID                , UPD_DATE       , MEMB "
    //                                + "      , YAKSOK_CODE          , GROUP_SER             , HANGMOG_CODE   , SEQ "
    //                                + "      , PKOCS0303            , SPECIMEN_CODE         , SURYANG        , ORD_DANUI "
    //                                + "      , DV_TIME              , DV                    , NALSU          , JUSA "
    //                                + "      , BOGYONG_CODE         , EMERGENCY             , MUHYO          , PORTABLE_YN "
    //                                + "      , PAY                  , PRN_YN                , POWDER_YN      , DV_1 "
    //                                + "      , DV_2                 , DV_3                  , DV_4           , MIX_GROUP "
    //                                + "      , DV_5                 , DV_6                  , DV_7           , DV_8 "
    //                                + "      , ORDER_REMARK         , NURSE_REMARK          , ORDER_GUBUN    , WONYOI_ORDER_YN "
    //                                + "      , DANGIL_GUMSA_ORDER_YN, DANGIL_GUMSA_RESULT_YN, INPUT_TAB      , HUBAL_CHANGE_YN "
    //                                + "      , PHARMACY             , JUSA_SPD_GUBUN        , DRG_PACK_YN    , UPD_ID "
    //                                + "      , HOSP_CODE            , MEMB_GUBUN            , HANGMOG_NAME   , AMT "
    //                                + "      , BOM_SOURCE_KEY       , NDAY_YN               , FKOCS0300_SEQ  , JUNDAL_TABLE_OUT  "
    //                                + "      , JUNDAL_PART_OUT      , JUNDAL_TABLE_INP      , JUNDAL_PART_INP, MOVE_PART_OUT "
    //                                + "      , MOVE_PART_INP        , GENERAL_DISP_YN) "
    //                                + " VALUES "
    //                                + "      ( SYSDATE                 , :q_user_id               , SYSDATE           , :f_memb "
    //                                + "      , :f_yaksok_code          , :f_group_ser             , :f_hangmog_code   , :f_seq  "
    //                                + "      , :f_pkocskey             , :f_specimen_code         , :f_suryang        , :f_ord_danui "
    //                                + "      , :f_dv_time              , :f_dv                    , :f_nalsu          , :f_jusa "
    //                                + "      , :f_bogyong_code         , :f_emergency             , :f_muhyo          , :f_portable_yn "
    //                                + "      , :f_pay                  , 'N'                      , :f_powder_yn      , :f_dv_1 "
    //                                + "      , :f_dv_2                 , :f_dv_3                  , :f_dv_4           , :f_mix_group "
    //                                + "      , :f_dv_5                 , :f_dv_6                  , :f_dv_7           , :f_dv_8 "
    //                                + "      , :f_order_remark         , :f_nurse_remark          , :f_order_gubun    , :f_wonyoi_order_yn "
    //                                + "      , :f_dangil_gumsa_order_yn, :f_dangil_gumsa_result_yn, :f_input_tab      , :f_hubul_change_yn "
    //                                + "      , :f_pharmacy             , :f_jusa_spd_gubun        , :f_drg_pack_yn    , :q_user_id "
    //                                + "      , :f_hosp_code            , '00'                     , :f_hangmog_name   , :f_amt "
    //                                + "      , :f_bom_source_key       , :f_nday_yn               , :f_in_out_key     , :f_jundal_table_out "
    //                                + "      , :f_jundal_part_out      , :f_jundal_table_inp      , :f_jundal_part_inp, :f_move_part_out "
    //                                + "      , :f_move_part_inp        , :f_general_disp_yn) ";



    //                        break;

    //                    case DataRowState.Modified:
                            
    //                        if (item.BindVarList["f_general_disp_yn"].VarValue == "")
    //                            item.BindVarList["f_general_disp_yn"].VarValue = "N";

    //                        cmdText = " UPDATE OCS0303 "
    //                                + "    SET UPD_DATE         = SYSDATE "
    //                                + "      , UPD_ID           = :q_user_id "
    //                                + "      , NDAY_YN          = :f_nday_yn "
    //                                + "      , SURYANG          = :f_suryang "
    //                                + "      , NALSU            = :f_nalsu "
    //                                + "      , JUSA             = :f_jusa  "
    //                                + "      , BOGYONG_CODE     = :f_bogyong_code "
    //                                + "      , EMERGENCY        = :f_emergency "
    //                                + "      , MUHYO            = :f_muhyo "
    //                                + "      , POWDER_YN        = :f_powder_yn "
    //                                + "      , DV_1             = :f_dv_1 "
    //                                + "      , DV_2             = :f_dv_2 "
    //                                + "      , DV_3             = :f_dv_3 "
    //                                + "      , DV_4             = :f_dv_4 "
    //                                + "      , DV_5             = :f_dv_5 "
    //                                + "      , DV_6             = :f_dv_6 "
    //                                + "      , DV_7             = :f_dv_7 "
    //                                + "      , DV_8             = :f_dv_8 "
    //                                + "      , MIX_GROUP        = :f_mix_group "
    //                                + "      , ORDER_REMARK     = :f_order_remark "
    //                                + "      , NURSE_REMARK     = :f_nurse_remark "
    //                                //insert by jc [wonyoi_order_yn]
    //                                + "      , WONYOI_ORDER_YN  = :f_wonyoi_order_yn "
    //                                + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
    //                                + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
    //                                + "      , PHARMACY         = :f_pharmacy "
    //                                + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
    //                                + "      , DRG_PACK_YN      = :f_drg_pack_yn "
    //                                + "      , DANGIL_GUMSA_ORDER_YN = :f_dangil_gumsa_order_yn "
    //                                + "      , DANGIL_GUMSA_RESULT_YN = :f_dangil_gumsa_result_yn "
    //                                + "      , DV_TIME          = :f_dv_time "
    //                                + "      , DV               = :f_dv "
    //                                + "      , ORD_DANUI        = :f_ord_danui "
    //                                + "      , SPECIMEN_CODE    = :f_specimen_code "
    //                                + "      , JUNDAL_TABLE_OUT = :f_jundal_table_out "
    //                                + "      , JUNDAL_PART_OUT  = :f_jundal_part_out "
    //                                + "      , JUNDAL_TABLE_INP = :f_jundal_table_inp "
    //                                + "      , JUNDAL_PART_INP  = :f_jundal_part_inp "
    //                                + "      , MOVE_PART_OUT    = :f_move_part_out "
    //                                + "      , MOVE_PART_INP    = :f_move_part_inp "
    //                                + "      , GENERAL_DISP_YN  = :f_general_disp_yn "
    //                                + "      , SEQ              = :f_seq "
    //                                + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
    //                                + "    AND PKOCS0303 = :f_pkocskey ";



    //                        break;

    //                }

    //                #endregion

    //                break;
    //        }

    //        bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

    //        return isSuccess;
    //    }
    //}
    #endregion

    #region Enum SetMode

    internal enum SetMode
    {
        UserMode,        // 사용자를 선택한경우
        DoctorMode,      // 사용자중 의사를 선택한 경우
        NurseMode,       // 사용자중 간호사를 선택한 경우
        GwaMode,         // 진료과를 선택한경우
        HospitalMode     // 병원을 선택한경우
    }

    #endregion
}