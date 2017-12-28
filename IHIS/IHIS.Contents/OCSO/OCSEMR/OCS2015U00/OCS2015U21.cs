using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.Ocsemr;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Results.System;
namespace IHIS.OCSO
{
    using System.Collections;

    using IHIS.CloudConnector;
    using IHIS.CloudConnector.Contracts.Arguments.Ocso;
    using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
    using IHIS.CloudConnector.Contracts.Models.Ocso;
    using IHIS.CloudConnector.Contracts.Results.Ocso;
    using IHIS.Framework;
    using IHIS.OCSO.Properties;
    using IHIS.CloudConnector.Contracts.Models.OcsEmr;
    using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
    using IHIS.CloudConnector.Contracts.Results.OcsEmr;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
    using IHIS.CloudConnector.Contracts.Arguments.System;
    using IHIS.CloudConnector.Contracts.Arguments.Ocsa;

    public partial class OCS2015U21 : XScreen
    {
        private readonly OCS2015U00 mainScreen;
        bool flag = true;
        private int QueryTime;

        public OCS2015U21(OCS2015U00 mainScreen)
        {
            this.mainScreen = mainScreen;
            InitializeComponent();
            CheckSizeColumn();
            this.QueryTime = 30000;
            initializeComboListItem();
            layDoctorName.ExecuteQuery = GetDoctorNameList;

            //cboGwa.SetDataValue(UserInfo.Gwa);
            //fbxDoctor.SetEditValue(UserInfo.DoctorID);
            dbxDoctor_name.SetDataValue(UserInfo.UserName);
            if (NetInfo.Language.Equals(LangMode.Vi))
            {
                xEditGridCell2.ButtonText = "Tiếp nhận";
            }
            else if (NetInfo.Language.Equals(LangMode.En))
            {
                xEditGridCell2.ButtonText = "Receipt patient";
            }
            else if (NetInfo.Language.Equals(LangMode.Jr))
            {
                xEditGridCell2.ButtonText = "患者受付";
            }
        }

        public XDatePicker DtpNaewonDate
        {
            get
            {
                return dtpNaewonDate;
            }
        }

        public XDictComboBox CboQryDoctor
        {
            get
            {
                return this.cboQryDoctor;
            }
        }

        public XDictComboBox CboQryGwa
        {
            get
            {
                return this.cboQryGwa;
            }
        }

        public XDictComboBox CboGwa
        {
            get
            {
                return this.cboGwa;
            }
        }

        public XFindBox FbxDoctor
        {
            get
            {
                return this.fbxDoctor;
            }
        }

        public XPatientBox PaBox
        {
            get
            {
                return this.paBox;
            }
        }

        public XDisplayBox DbxDoctor_name
        {
            get
            {
                return this.dbxDoctor_name;
            }
        }

        public XEditGrid GrdPatientList
        {
            get
            {
                return this.grdPatientList;
            }
        }

        public XEditGridCell XEditGridCell63
        {
            get
            {
                return this.xEditGridCell63;
            }
        }

        public int Querytime
        {   
            get
            {
                return this.QueryTime;
            }
        }

        private List<OcsoOCS1003P01LayPatInfo> _lstLayPatInfo;
        public List<OcsoOCS1003P01LayPatInfo> LstLayPatInfo
        {
            get
            {
                if (_lstLayPatInfo != null)
                    return this._lstLayPatInfo;
                else
                    return new List<OcsoOCS1003P01LayPatInfo>();
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            mainScreen.FbxBunho.AcceptData();
            if (String.IsNullOrEmpty(this.dtpNaewonDate.GetDataValue()))
            {
                this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate());
            }
            this.dtpNaewonDate.SetDataValue(DateTime.Parse(this.dtpNaewonDate.GetDataValue()).AddDays(-1));
            this.dtpNaewonDate.AcceptData();
            mainScreen.LoadPatientList2015U21();
        }

        internal void Control_DataValidating(object sender, DataValidatingEventArgs e)
        {
            Control control = sender as Control;
            string bunho = "";
            object postCallArguments;

            switch (control.Name)
            {
                // 환자번호
                case "fbxBunho": // ★注意:TextBoxから直接入力される場合もあるので<< this.grdPatientList.CurrentRowNumber >>使用禁止

                    #region updated 2015.08.06

                    mainScreen.ResetSearchData();
                    // 스탠다드 번호로 변경 
                    bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
                    //LoadEmrCompositeFirst(bunho, 0, true);
                    string gwa = "";

                    // CurrentRowNumber 代わりに　DBから取得 単数・複数可能性あり
                    MultiLayout layPat = new MultiLayout();
                    layPat.LayoutItems.Add("gwa", DataType.String);
                    layPat.LayoutItems.Add("bunho", DataType.String);
                    layPat.LayoutItems.Add("doctor", DataType.String);
                    layPat.LayoutItems.Add("group_key", DataType.String);
                    layPat.LayoutItems.Add("naewon_yn", DataType.String);
                    layPat.LayoutItems.Add("login_doctor_yn", DataType.String);
                    layPat.InitializeLayoutTable();
                    layPat.ParamList = new List<string>(new string[] { "f_doctor", "f_bunho", "f_naewon_date", "f_login_doctor_yn" });

                    layPat.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
                    //layPat.SetBindVarValue("f_doctor", this.cboQryDoctor.GetDataValue());
                    layPat.SetBindVarValue("f_doctor", this.cboGwa.GetDataValue());
                    layPat.SetBindVarValue("f_bunho", bunho);
                    layPat.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
                    if (mainScreen.MDoctorLogin)
                        layPat.SetBindVarValue("f_login_doctor_yn", "Y");
                    else
                        layPat.SetBindVarValue("f_login_doctor_yn", "N");

                    // Connect cloud
                    layPat.ExecuteQuery = ExecuteQueryOcsoOCS1003P01LayPatInfo;
                    layPat.QueryLayout(false);

                    if (mainScreen.MPatientDoubleClick)
                    {
                        //this.cboQryGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                        this.cboGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                    }
                    else if (layPat.RowCount == 1)
                    {
                        gwa = layPat.GetItemString(0, "gwa");
                        //if (gwa != this.cboQryGwa.GetDataValue())
                        //    this.cboQryGwa.SetDataValue(gwa);
                        if (gwa != this.cboGwa.GetDataValue())
                            this.cboGwa.SetDataValue(gwa);
                    }

                    // 내원일자 입력체크
                    if (this.dtpNaewonDate.GetDataValue() == "")
                    {
                        mainScreen.MMsg = Resources.MSG026_MSG;
                        mainScreen.MCap = Resources.MSG026_CAP;

                        MessageBox.Show(mainScreen.MMsg, mainScreen.MCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(mainScreen.MMsg, MsgType.Error);

                        return;
                    }

                    if (e.DataValue == "")
                    {
                        mainScreen.InitializeBunho(false);
                        this.SetMsg("");
                        //mainScreen.ResetPatientprofile();
                        return;
                    }

                    // 이전데이터 저장여부
                    if (mainScreen.IsOrderDataModifed() == true)
                    {
                        // 저장안된 데이터 있다. 저장한다.
                        // 저장여부는 내부에서 판단.
                        mainScreen.BtnList.PerformClick(FunctionType.Update);
                    }

                    // 번호 변경시의 초기화
                    mainScreen.InitializeBunho(false);

                    // 각종체크 들어가 주시고....
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    // 환자정보 로드해 봅시다....
                    // 파라미터 셋팅
                    mainScreen.MPatientInfoParam.NaewonDate = this.dtpNaewonDate.GetDataValue();
                    mainScreen.MPatientInfoParam.NaewonKey = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
                    // 최초 로그인시 의사이ㅣㄴ경우 doctor combo 구성후 해당 의사로 셋팅해 놓고 안보이게 함.
                    // 따라서 그 의사만 계혹 설정될꺼고
                    // 의사가 아니면 콤보 박스가 변경이 가능할꺼고...
                    //mainScreen.MPatientInfoParam.InputID = this.cboQryDoctor.GetDataValue();
                    //mainScreen.MPatientInfoParam.Gwa = this.cboQryGwa.GetDataValue();
                    //mainScreen.MPatientInfoParam.Doctor = this.cboQryDoctor.GetDataValue();

                    //mainScreen.MPatientInfoParam.ApproveDoctor = this.cboQryDoctor.GetDataValue();

                    mainScreen.MPatientInfoParam.InputID = this.fbxDoctor.GetDataValue();
                    mainScreen.MPatientInfoParam.Gwa = this.cboGwa.GetDataValue();
                    mainScreen.MPatientInfoParam.Doctor = this.fbxDoctor.GetDataValue();

                    mainScreen.MPatientInfoParam.ApproveDoctor = this.fbxDoctor.GetDataValue();


                    mainScreen.MPatientInfoParam.IOEGubun = "O"; // 외래 
                    mainScreen.MPatientInfoParam.Bunho = bunho;
                    mainScreen.MPatientInfoParam.IsEnableIpwonReser = true;

                    mainScreen.MSelectedPatientInfo.Parameter = mainScreen.MPatientInfoParam;

                    //mGroup_key初期化
                    mainScreen.MGroup_key = "";

                    if (mainScreen.MSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.BaseInfo) == false)
                    {
                        mainScreen.MMsg = Resources.MSG027_MSG;
                        mainScreen.MCap = Resources.MSG027_CAP;

                        postCallArguments = new Hashtable();

                        ((Hashtable)postCallArguments).Add("success_yn", "N");
                        ((Hashtable)postCallArguments).Add("bunho", bunho);

                        PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);
                        XMessageBox.Show(Resources.MSG027_MSG, Resources.MSG027_CAP);
                        return;
                    }

                    if (mainScreen.MSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo) == false)
                    {
                        mainScreen.EnableBtnList = false;
                        //mainScreen.MMsg = Resources.MSG027_MSG;
                        //mainScreen.MCap = Resources.MSG027_CAP;

                        //postCallArguments = new Hashtable();

                        //((Hashtable)postCallArguments).Add("success_yn", "N");
                        //((Hashtable)postCallArguments).Add("bunho", bunho);

                        //PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);
                        //XMessageBox.Show(Resources.MSG027_MSG, Resources.MSG027_CAP);
                        //return;
                    }
                    else
                    {
                        mainScreen.EnableBtnList = true;
                        //if (mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString() != this.cboQryGwa.GetDataValue())
                        //    this.cboQryGwa.SetDataValue(mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

                        if (mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString() != this.cboGwa.GetDataValue())
                            this.cboGwa.SetDataValue(mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString());


                        if (mainScreen.MPatientDoubleClick)
                        {
                            mainScreen.MGroup_key = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key");
                        }
                        else if (layPat.RowCount == 1)
                        {
                            mainScreen.MGroup_key = layPat.GetItemString(0, "group_key");
                        }
                        else if (mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString() != "")
                        {
                            // Connect cloud
                            OcsoOCS1003P01GetGroupKeyArgs args = new OcsoOCS1003P01GetGroupKeyArgs();
                            args.Pkout1001 = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                            args.CodeType = "JUBSU_GUBUN";
                            OcsoOCS1003P01GetGroupKeyResult result = CloudService.Instance.Submit<OcsoOCS1003P01GetGroupKeyResult, OcsoOCS1003P01GetGroupKeyArgs>(args);
                            if (result != null)
                            {
                                mainScreen.MGroup_key = result.GroupKey;
                            }

                        }
                    }

                    if (mainScreen.MClickedNaewonKey != "")
                    {
                        mainScreen.MClickedNaewonKey = "";
                    }

                    if (mainScreen.MParamNaewonKey != "")
                    {
                        mainScreen.MParamNaewonKey = "";
                    }

                    // 내원 체크 
                    //https://sofiamedix.atlassian.net/browse/MED-11609
                    //if (mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() == "N")
                    //{
                    //    if (MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    //    {
                    //        postCallArguments = new Hashtable();

                    //        ((Hashtable)postCallArguments).Add("success_yn", "N");
                    //        ((Hashtable)postCallArguments).Add("bunho", bunho);

                    //        PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);

                    //        return;

                    //    }
                    //}

                    LoadEmrCompositeSecond(bunho, e.DataValue);

                    OCS2015U21SelectedPatientInfo selectedPat = new OCS2015U21SelectedPatientInfo();
                    selectedPat.ApproveDoctor = mainScreen.MSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                    selectedPat.Bunho = mainScreen.MSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                    selectedPat.Doctor = mainScreen.MSelectedPatientInfo.GetPatientInfo["doctor"].ToString();
                    selectedPat.Gwa = mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                    selectedPat.NaewonDate = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                    selectedPat.NaewonKey = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();

                    OCS2015U21ControlDataValidatingArgs controlArgs = new OCS2015U21ControlDataValidatingArgs();
                    controlArgs.HospCode = UserInfo.HospCode;
                    //controlArgs.Doctor = this.cboQryDoctor.GetDataValue();
                    controlArgs.Doctor = this.fbxDoctor.GetDataValue();
                    controlArgs.Bunho = bunho;
                    controlArgs.NaewonDate = this.dtpNaewonDate.GetDataValue();
                    controlArgs.LoginDoctorYn = mainScreen.MDoctorLogin ? "Y" : "N";
                    controlArgs.DataValue = e.DataValue;
                    controlArgs.Gwa = UserInfo.Gwa;
                    controlArgs.IoGubun = mainScreen.N_IO_Gubun;
                    controlArgs.UserId = UserInfo.UserID;
                    controlArgs.InsteadYn = "Y";
                    controlArgs.ApproveYn = "N";
                    controlArgs.Key = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                    controlArgs.SelectedPaInfo = selectedPat;

                    OCS2015U21ControlDataValidatingResult controlRes = CloudService.Instance.Submit<OCS2015U21ControlDataValidatingResult, OCS2015U21ControlDataValidatingArgs>(controlArgs);

                    if (controlRes.IsJaewonPatient)
                    {
                        mainScreen.MMsg = Resources.MSG028_MSG;
                        mainScreen.MCap = Resources.MSG027_CAP;

                        MessageBox.Show(mainScreen.MMsg, mainScreen.MCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.SetMsg(mainScreen.MMsg, MsgType.Error);

                        postCallArguments = new Hashtable();

                        ((Hashtable)postCallArguments).Add("success_yn", "N");
                        ((Hashtable)postCallArguments).Add("bunho", bunho);

                        PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);

                        return;
                    }

                    // 入院予約がある患者さんの場合、代行オーダーを入院オーダーにて登録するようにする。
                    //if (UserInfo.Gwa == "CK")
                    //{
                    //    XMessageBox.Show(controlRes.IsAbleInsteadOrder, Resources.MSG001_CAP, MessageBoxIcon.Stop);
                    //    return;

                    //    //string isInstead = "";
                    //    //isInstead = this.mOrderBiz.isAbleInsteadOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                    //    //                                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                    //    //                                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                    //    //if (isInstead != "")
                    //    //{
                    //    //    XMessageBox.Show(isInstead, "確認", MessageBoxIcon.Stop);
                    //    //    return;
                    //    //}
                    //}

                    // 기타 사항들 체크 및 visible 셋팅
                    mainScreen.CheckPatientEtcInfo(mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), bunho
                                            , mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), mainScreen.MSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

                    // 환자정보 박스 기동
                    mainScreen.PaInfoBox.SetPatientID(bunho);

                    postCallArguments = new Hashtable();
                    ((Hashtable)postCallArguments).Add("success_yn", "Y");
                    ((Hashtable)postCallArguments).Add("bunho", bunho);

                    PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);

                    //insert by jc [患者を選択する際、InputTabの初期化（全体）するように] 2012/03/13
                    // 전체를 체크해 놓는다.
                    foreach (Control inputTabcontrol in mainScreen.PnlInputTab.Controls)
                    {
                        if (inputTabcontrol is XRadioButton && inputTabcontrol.Tag.ToString() == "%")
                        {
                            ((XRadioButton)inputTabcontrol).Checked = true;
                        }
                    }
                    //inser by jc [診療保留、診療保留取消の切り替えのため] 2012/09/08
                    this.SettingVisiblebyUser();

                    // 未承認オーダーがあれば承認画面POPUP 無ければDOオーダーPOPUP
                    int approveOrderCnt;
                    Int32.TryParse(controlRes.NotApproveOrderCnt, out approveOrderCnt);
                    if (mainScreen.MDoctorLogin && approveOrderCnt > 0)
                    {
                        mainScreen.BtnApprove.PerformClick();
                    }

                    mainScreen.MPatientDoubleClick = false;

                    //患者選択時傷病リストが拡張されてる状態に見せる。2013/04/29
                    if (!mainScreen.MIsExpandedSB)
                        mainScreen.BtnExpandSB.PerformClick();

                    mainScreen.GrdReserOrderList.ExecuteQuery = ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo;
                    //mainScreen.GrdReserOrderList.QueryLayout(false);
                    mainScreen.GrdReserOrderList.QueryLayout(true);

                    mainScreen.MPostApproveYN = controlRes.EnablePostApprove;

                    if (mainScreen.MPostApproveYN)
                        mainScreen.LblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_2;
                    else
                        mainScreen.LblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_1;

                    if (OnCloseParentForm != null)
                    {
                        OnCloseParentForm(this, EventArgs.Empty);
                    }

                    mainScreen.InitSearchData();
                    mainScreen.CheckDiscuss(mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
                    break;

                    #endregion


                #region deleted

                //mainScreen.ResetSearchData();
                //// 스탠다드 번호로 변경 
                //bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
                ////bunho = e.DataValue;

                //#region 患者の診療科と今の診療科が違うと患者の診療科に合わせるように

                //string gwa = "";

                //// CurrentRowNumber 代わりに　DBから取得 単数・複数可能性あり
                //MultiLayout layPat = new MultiLayout();
                //layPat.LayoutItems.Add("gwa", DataType.String);
                //layPat.LayoutItems.Add("bunho", DataType.String);
                //layPat.LayoutItems.Add("doctor", DataType.String);
                //layPat.LayoutItems.Add("group_key", DataType.String);
                //layPat.LayoutItems.Add("naewon_yn", DataType.String);
                //layPat.LayoutItems.Add("login_doctor_yn", DataType.String);


                //layPat.InitializeLayoutTable();

                ////                    layPat.QuerySQL = @"SELECT A.GWA, A.BUNHO, A.DOCTOR, B.GROUP_KEY, A.NAEWON_YN
                ////                                          FROM OUT1001 A
                ////                                              ,BAS0102 B
                ////                                         WHERE A.HOSP_CODE         = :f_hosp_code
                ////                                           AND SUBSTR(A.DOCTOR, 3) = SUBSTR(:f_doctor, 3)
                ////                                           AND A.BUNHO             = :f_bunho
                ////                                           AND A.NAEWON_DATE       = :f_naewon_date
                ////                                           AND B.HOSP_CODE = A.HOSP_CODE
                ////                                           AND B.CODE_TYPE = 'JUBSU_GUBUN'
                ////                                           AND B.CODE      = A.JUBSU_GUBUN
                ////                                           AND ((:f_login_doctor_yn = 'Y' AND B.GROUP_KEY = '1') OR (:f_login_doctor_yn = 'N'))
                ////                                    ";

                //layPat.ParamList = new List<string>(new string[] { "f_doctor", "f_bunho", "f_naewon_date", "f_login_doctor_yn" });

                //layPat.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
                //layPat.SetBindVarValue("f_doctor", this.cboQryDoctor.GetDataValue());
                //layPat.SetBindVarValue("f_bunho", bunho);
                //layPat.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
                //if (mainScreen.MDoctorLogin)
                //    layPat.SetBindVarValue("f_login_doctor_yn", "Y");
                //else
                //    layPat.SetBindVarValue("f_login_doctor_yn", "N");

                //// Connect cloud
                //layPat.ExecuteQuery = ExecuteQueryOcsoOCS1003P01LayPatInfo;
                //layPat.QueryLayout(false);

                //if (mainScreen.MPatientDoubleClick)
                //{
                //    this.cboQryGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                //}
                //else if (layPat.RowCount == 1)
                //{
                //    gwa = layPat.GetItemString(0, "gwa");
                //    if (gwa != this.cboQryGwa.GetDataValue())
                //        this.cboQryGwa.SetDataValue(gwa);
                //}

                ////else if (layPat.RowCount > 1)
                ////{
                ////    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
                ////    return;
                ////}
                ////else if (this.grdPatientList.CurrentRowNumber > -1 && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa") != this.cboQryGwa.GetDataValue())
                ////{
                ////    this.cboQryGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));
                ////}

                ////else if (this.grdPatientList.CurrentRowNumber == -1 && e.DataValue != "")
                ////{

                ////}


                ////if (this.grdPatientList.CurrentRowNumber > -1 && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa") != this.cboQryGwa.GetDataValue())
                ////    this.cboQryGwa.SetDataValue(this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "gwa"));

                //#endregion

                //#region 환자번호 벨리데이팅 서비스

                //// 내원일자 입력체크
                //if (this.dtpNaewonDate.GetDataValue() == "")
                //{
                //    mainScreen.MMsg = Resources.MSG026_MSG;
                //    mainScreen.MCap = Resources.MSG026_CAP;

                //    MessageBox.Show(mainScreen.MMsg, mainScreen.MCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    this.SetMsg(mainScreen.MMsg, MsgType.Error);

                //    return;
                //}

                //// 이전데이터 저장여부
                //if (mainScreen.IsOrderDataModifed() == true)
                //{
                //    // 저장안된 데이터 있다. 저장한다.
                //    // 저장여부는 내부에서 판단.
                //    mainScreen.BtnList.PerformClick(FunctionType.Update);
                //}

                //// 번호 변경시의 초기화
                //mainScreen.InitializeBunho(false);

                //if (e.DataValue == "")
                //{
                //    mainScreen.InitializeBunho(false);
                //    this.SetMsg("");
                //    //mainScreen.ResetPatientprofile();
                //    return;
                //}

                //// 각종체크 들어가 주시고....
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //// 환자정보 로드해 봅시다....
                //// 파라미터 셋팅
                //mainScreen.MPatientInfoParam.NaewonDate = this.dtpNaewonDate.GetDataValue();
                //mainScreen.MPatientInfoParam.NaewonKey = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
                //// 최초 로그인시 의사이ㅣㄴ경우 doctor combo 구성후 해당 의사로 셋팅해 놓고 안보이게 함.
                //// 따라서 그 의사만 계혹 설정될꺼고
                //// 의사가 아니면 콤보 박스가 변경이 가능할꺼고...
                //mainScreen.MPatientInfoParam.InputID = this.cboQryDoctor.GetDataValue();
                //mainScreen.MPatientInfoParam.Gwa = this.cboQryGwa.GetDataValue();
                //mainScreen.MPatientInfoParam.Doctor = this.cboQryDoctor.GetDataValue();

                //mainScreen.MPatientInfoParam.ApproveDoctor = this.cboQryDoctor.GetDataValue();

                //mainScreen.MPatientInfoParam.IOEGubun = "O"; // 외래 
                //mainScreen.MPatientInfoParam.Bunho = bunho;
                //mainScreen.MPatientInfoParam.IsEnableIpwonReser = true;

                //mainScreen.MSelectedPatientInfo.Parameter = mainScreen.MPatientInfoParam;

                ////mGroup_key初期化
                //mainScreen.MGroup_key = "";

                //if (mainScreen.MSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo) == false)
                //{
                //    mainScreen.MMsg = Resources.MSG027_MSG;
                //    mainScreen.MCap = Resources.MSG027_CAP;

                //    // 2015.07.21 AnhNV deleted
                //    //MessageBox.Show(mainScreen.MMsg, mainScreen.MCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    //this.SetMsg(mainScreen.MMsg, MsgType.Error);

                //    postCallArguments = new Hashtable();

                //    ((Hashtable)postCallArguments).Add("success_yn", "N");
                //    ((Hashtable)postCallArguments).Add("bunho", bunho);

                //    PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);

                //    return;
                //}
                //else
                //{
                //    if (mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString() != this.cboQryGwa.GetDataValue())
                //        this.cboQryGwa.SetDataValue(mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

                //    if (mainScreen.MPatientDoubleClick)
                //    {
                //        mainScreen.MGroup_key = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key");
                //    }
                //    else if (layPat.RowCount == 1)
                //    {
                //        mainScreen.MGroup_key = layPat.GetItemString(0, "group_key");
                //    }
                //    else if (mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString() != "")
                //    {
                //        //                            string cmd = @"SELECT B.GROUP_KEY
                //        //                                          FROM OUT1001 A
                //        //                                              ,BAS0102 B
                //        //                                         WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + @"'
                //        //                                           AND A.PKOUT1001  = '" + mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString() + @"'
                //        //                                           AND B.HOSP_CODE  = A.HOSP_CODE
                //        //                                           AND B.CODE_TYPE  = 'JUBSU_GUBUN'
                //        //                                           AND B.CODE       = A.JUBSU_GUBUN
                //        //                                           
                //        //                                    ";
                //        //                            object obj = Service.ExecuteScalar(cmd);

                //        // Connect cloud
                //        OcsoOCS1003P01GetGroupKeyArgs args = new OcsoOCS1003P01GetGroupKeyArgs();
                //        args.Pkout1001 = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                //        args.CodeType = "JUBSU_GUBUN";
                //        OcsoOCS1003P01GetGroupKeyResult result = CloudService.Instance.Submit<OcsoOCS1003P01GetGroupKeyResult, OcsoOCS1003P01GetGroupKeyArgs>(args);
                //        if (result != null)
                //        {
                //            mainScreen.MGroup_key = result.GroupKey;
                //        }

                //    }
                //    //else if (layPat.RowCount > 1)
                //    //{
                //    //    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
                //    //    return;
                //    //}
                //    //else if (this.grdPatientList.CurrentRowNumber == -1 && e.DataValue != "")
                //    //    mainScreen.MGroup_key = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "group_key");
                //}


                //if (mainScreen.MClickedNaewonKey != "")
                //{
                //    mainScreen.MClickedNaewonKey = "";
                //}

                //if (mainScreen.MParamNaewonKey != "")
                //{
                //    mainScreen.MParamNaewonKey = "";
                //}

                //// 내원 체크 
                //if (mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() == "N")
                //{
                //    if (MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                //    {
                //        postCallArguments = new Hashtable();

                //        ((Hashtable)postCallArguments).Add("success_yn", "N");
                //        ((Hashtable)postCallArguments).Add("bunho", bunho);

                //        PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);

                //        return;

                //    }
                //}

                //// 재원환자 체크 
                //if (mainScreen.MOrderBiz.IsJaewonPatient(e.DataValue))
                //{
                //    mainScreen.MMsg = Resources.MSG028_MSG;
                //    mainScreen.MCap = Resources.MSG027_CAP;

                //    MessageBox.Show(mainScreen.MMsg, mainScreen.MCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    this.SetMsg(mainScreen.MMsg, MsgType.Error);

                //    postCallArguments = new Hashtable();

                //    ((Hashtable)postCallArguments).Add("success_yn", "N");
                //    ((Hashtable)postCallArguments).Add("bunho", bunho);

                //    PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);

                //    return;
                //}

                //// 入院予約がある患者さんの場合、代行オーダーを入院オーダーにて登録するようにする。
                //if (UserInfo.Gwa == "CK")
                //{
                //    string isInstead = "";
                //    isInstead = mainScreen.MOrderBiz.isAbleInsteadOrder(mainScreen.MSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                //                                        , mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                //                                        , mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                //    if (isInstead != "")
                //    {
                //        XMessageBox.Show(isInstead, Resources.MSG001_CAP, MessageBoxIcon.Stop);
                //        return;
                //    }
                //}

                //// 기타 사항들 체크 및 visible 셋팅
                //mainScreen.CheckPatientEtcInfo(mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), bunho
                //                        , mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), mainScreen.MSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

                //// 환자정보 박스 기동
                //mainScreen.PaInfoBox.SetPatientID(bunho);

                //postCallArguments = new Hashtable();
                //((Hashtable)postCallArguments).Add("success_yn", "Y");
                //((Hashtable)postCallArguments).Add("bunho", bunho);

                //PostCallHelper.PostCall(new PostMethodObject(mainScreen.PostBunhoValidating), postCallArguments);

                //#endregion

                ////insert by jc [患者を選択する際、InputTabの初期化（全体）するように] 2012/03/13
                //// 전체를 체크해 놓는다.
                //foreach (Control inputTabcontrol in mainScreen.PnlInputTab.Controls)
                //{
                //    if (inputTabcontrol is XRadioButton && inputTabcontrol.Tag.ToString() == "%")
                //    {
                //        ((XRadioButton)inputTabcontrol).Checked = true;
                //    }
                //}
                ////inser by jc [診療保留、診療保留取消の切り替えのため] 2012/09/08
                //this.SettingVisiblebyUser();

                //// 未承認オーダーがあれば承認画面POPUP 無ければDOオーダーPOPUP
                //if (mainScreen.MDoctorLogin && mainScreen.MOrderBiz.GetNotApproveOrderCnt(mainScreen.N_IO_Gubun, UserInfo.UserID, "Y", "N", mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
                //{
                //    mainScreen.BtnApprove.PerformClick();
                //}
                //// TODO: No need to check for DEMO
                ///*else
                //{
                //    // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                //    if (mainScreen.MPatientDoubleClick)
                //    {
                //        if (mainScreen.MOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", mainScreen.N_IO_Gubun) != "N"
                //        && mainScreen.MOrderBiz.GetOrderCount(mainScreen.N_IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                //        && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") != "E")
                //        {
                //            mainScreen.BtnDoOrder.PerformClick();
                //        }
                //    }
                //    else if (layPat.RowCount == 1)
                //    {
                //        if (mainScreen.MOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", mainScreen.N_IO_Gubun) != "N"
                //        && mainScreen.MOrderBiz.GetOrderCount(mainScreen.N_IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                //        && layPat.GetItemString(0, "naewon_yn") != "E")
                //        {
                //            mainScreen.BtnDoOrder.PerformClick();
                //        }
                //    }
                //    else if (mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "")
                //    {
                //        if (mainScreen.MOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", mainScreen.N_IO_Gubun) != "N"
                //        && mainScreen.MOrderBiz.GetOrderCount(mainScreen.N_IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                //        && mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "E")
                //        {
                //            mainScreen.BtnDoOrder.PerformClick();
                //        }
                //    }
                //}*/

                ////else if (layPat.RowCount > 1)
                ////{
                ////    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
                ////    return;
                ////}

                //mainScreen.MPatientDoubleClick = false;
                ////if (this.grdPatientList.CurrentRowNumber > -1)
                ////{
                ////    if (mainScreen.MOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", mainScreen.N_IO_Gubun) != "N"
                ////        && mainScreen.MOrderBiz.GetOrderCount(mainScreen.N_IO_Gubun, bunho, this.dtpNaewonDate.GetDataValue().ToString()) > 0
                ////        && this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "naewon_yn") != "E")
                ////    {
                ////        mainScreen.BtnDoOrder.PerformClick();
                ////    }
                ////}

                ////患者選択時傷病リストが拡張されてる状態に見せる。2013/04/29
                //if (!mainScreen.MIsExpandedSB)
                //    mainScreen.BtnExpandSB.PerformClick();

                //mainScreen.GrdReserOrderList.ExecuteQuery = ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo;
                ////mainScreen.GrdReserOrderList.QueryLayout(false);
                //mainScreen.GrdReserOrderList.QueryLayout(true);

                //mainScreen.MPostApproveYN = mainScreen.MOrderBiz.getEnablePostApprove("I", mainScreen.MSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());

                //if (mainScreen.MPostApproveYN)
                //    mainScreen.LblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_2;
                //else
                //    mainScreen.LblApproveFlag.Text = Resources.LBLAPPROVEFLAG_TEXT_1;

                //if (OnCloseParentForm != null)
                //{
                //    OnCloseParentForm(this, EventArgs.Empty);
                //}

                //mainScreen.InitSearchData();

                //break;

                #endregion

                // 내원일자
                case "dtpNaewonDate":

                    #region 내원일자 벨리데이팅

                    if (e.DataValue != "" && mainScreen.MDoctorLogin == false)
                    {
                        // 진료과 콤보 재조회
                        this.ReLoadGwaCombo(e.DataValue);

                        // 의사 콤보 재조회
                        //this.ReLoadDoctorCombo(e.DataValue, this.cboQryGwa.GetDataValue());
                        this.ReLoadDoctorCombo(e.DataValue, this.cboGwa.GetDataValue());
                    }

                    // 내원자 리스트 조회
                    //PatientListQuery(e.DataValue, this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());
                    PatientListQuery(e.DataValue, this.cboGwa.GetDataValue(), this.fbxDoctor.GetDataValue(),paBox.BunHo);
                    //mainScreen.InitializeBunho(false);

                    #endregion

                    break;
            }
        }

        private void LoadEmrCompositeSecond(string abunho, string edata)
        {
            string aDoctor = mainScreen.MSelectedPatientInfo.GetPatientInfo["doctor"].ToString();
            string aGwa = mainScreen.MSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
            string aNaewonDate = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            string aNaewonKey = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();

            LoadEmrCompositeSecondArgs compositeSecondArgs = new LoadEmrCompositeSecondArgs();
            FormEnvironInfoSysDateArgs sysDateArgs = new FormEnvironInfoSysDateArgs();
            compositeSecondArgs.EnvironInfoSysDate = sysDateArgs;

            OCS2015U21SelectedPatientInfo selectedPat = new OCS2015U21SelectedPatientInfo();
            selectedPat.ApproveDoctor = mainScreen.MSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            selectedPat.Bunho = abunho;
            selectedPat.Doctor = aDoctor;
            selectedPat.Gwa = aGwa;
            selectedPat.NaewonDate = aNaewonDate;
            selectedPat.NaewonKey = aNaewonKey;

            OCS2015U21ControlDataValidatingArgs controlArgs = new OCS2015U21ControlDataValidatingArgs();
            controlArgs.HospCode = UserInfo.HospCode;
            //controlArgs.Doctor = this.cboQryDoctor.GetDataValue();
            controlArgs.Doctor = this.fbxDoctor.GetDataValue();
            controlArgs.Bunho = abunho;
            controlArgs.NaewonDate = this.dtpNaewonDate.GetDataValue();
            controlArgs.LoginDoctorYn = mainScreen.MDoctorLogin ? "Y" : "N";
            controlArgs.DataValue = edata;
            controlArgs.Gwa = UserInfo.Gwa;
            controlArgs.IoGubun = mainScreen.N_IO_Gubun;
            controlArgs.UserId = UserInfo.UserID;
            controlArgs.InsteadYn = "Y";
            controlArgs.ApproveYn = "N";
            controlArgs.Key = aNaewonKey;
            controlArgs.SelectedPaInfo = selectedPat;
            compositeSecondArgs.Ocs2015u21ControlDataValidate = controlArgs;

            OpenAllergyInfo openAllergyInfo = new OpenAllergyInfo();
            openAllergyInfo.Bunho = abunho;
            openAllergyInfo.NaewonDate = aNaewonDate;
            OpenAllergyInfoArgs allergyInfoArgs = new OpenAllergyInfoArgs();
            allergyInfoArgs.Info1 = openAllergyInfo;
            compositeSecondArgs.OpenAllergyInfo = allergyInfoArgs;

            LoadConsultEndYNInfo loadConsultEndYnInfo = new LoadConsultEndYNInfo();
            loadConsultEndYnInfo.Bunho = abunho;
            if (string.IsNullOrEmpty(aDoctor))
                loadConsultEndYnInfo.ReqDoctor = "";
            else
                loadConsultEndYnInfo.ReqDoctor = aDoctor.Substring(2);
            LoadConsultEndYNArgs loadConsultEndYnArgs = new LoadConsultEndYNArgs();
            loadConsultEndYnArgs.LoadConsultEndYNInfo = loadConsultEndYnInfo;
            compositeSecondArgs.LoadConsultEndYn = loadConsultEndYnArgs;

            OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs loadConsultEndArgs = new OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs();
            LoadConsultEndYNInfo consultEndYNInfo = new LoadConsultEndYNInfo();
            consultEndYNInfo.Bunho = abunho;
            consultEndYNInfo.ReqDoctor = aDoctor;
            NoConfirmConsultInfo noConfirmConsultInfo = new NoConfirmConsultInfo();
            noConfirmConsultInfo.Bunho = abunho;
            noConfirmConsultInfo.Naewondate = aNaewonDate;
            noConfirmConsultInfo.Gwa = aGwa;
            noConfirmConsultInfo.Doctor = aDoctor;
            noConfirmConsultInfo.IoGubun = mainScreen.IO_Gubun;

            loadConsultEndArgs.ItemInfo = consultEndYNInfo;
            loadConsultEndArgs.ConfirmConsultInfo = noConfirmConsultInfo;
            compositeSecondArgs.Ocs1003p01LoadConsultEnd = loadConsultEndArgs;

            LoadPatientSpecificCommentArgs loadPatientSpecificCommentArgs = new LoadPatientSpecificCommentArgs();
            loadPatientSpecificCommentArgs.Bunho = abunho;
            compositeSecondArgs.LoadPatientSpecComment = loadPatientSpecificCommentArgs;

            GetOutJinryoCommentCntInfo commentCntInfo = new GetOutJinryoCommentCntInfo();
            commentCntInfo.Bunho = abunho;
            commentCntInfo.NaewonDate = aNaewonDate;
            commentCntInfo.Gwa = aGwa;
            commentCntInfo.Doctor = aDoctor;

            GetOutJinryoCommentCntArgs jinryoCommentCntArgs = new GetOutJinryoCommentCntArgs();
            jinryoCommentCntArgs.JinryoCommentCntInfo = commentCntInfo;

            compositeSecondArgs.GetOutJinryoComment = jinryoCommentCntArgs;

            IpwonReserStatusInfo ipwonReserStatusInfo = new IpwonReserStatusInfo();
            ipwonReserStatusInfo.Doctor = aDoctor;
            ipwonReserStatusInfo.Bunho = abunho;

            IpwonReserStatusArgs ipwonReserStatusArgs = new IpwonReserStatusArgs();
            ipwonReserStatusArgs.ReserStatusInfo = ipwonReserStatusInfo;
            compositeSecondArgs.IpwonReserStatus = ipwonReserStatusArgs;

            XPaInfoBoxArgs xPaInfoBoxArgs = new XPaInfoBoxArgs(abunho);
            compositeSecondArgs.XpaInfoBox = xPaInfoBoxArgs;


            OCS1003P01SettingVisibleByUserArgs settingVisibleByUserArgs = new OCS1003P01SettingVisibleByUserArgs();
            if (abunho != "")
            {
                NaewonYNInfo1 yninfo = new NaewonYNInfo1();
                yninfo.Bunho = abunho;
                yninfo.NaewonDate = aNaewonDate;
                yninfo.Pkout1001 = aNaewonKey;
                settingVisibleByUserArgs.NaewonParam = yninfo;
            }

            NotApproveOrderCntInfo cntInfo = new NotApproveOrderCntInfo();
            cntInfo.IoGubun = mainScreen.N_IO_Gubun;
            cntInfo.UserId = UserInfo.UserID;
            cntInfo.InsteadYn = "Y";
            cntInfo.ApproveYn = "N";
            cntInfo.Key = "%";

            settingVisibleByUserArgs.CountParam = cntInfo;

            compositeSecondArgs.Ocs1003p01SettingVisible = settingVisibleByUserArgs;

            OcsoOCS1003P01GridReserOrderListArgs vOcsoOCS1003P01GridReserOrderListArgs = new OcsoOCS1003P01GridReserOrderListArgs();
            vOcsoOCS1003P01GridReserOrderListArgs.Bunho = abunho;
            vOcsoOCS1003P01GridReserOrderListArgs.NaewonDate = aNaewonDate;
            compositeSecondArgs.Ocs1003p01GridReserOrder = vOcsoOCS1003P01GridReserOrderListArgs;

            OUT0106U00GridListArgs out0106U00GridListArgs = new OUT0106U00GridListArgs();
            out0106U00GridListArgs.Bunho = abunho;
            out0106U00GridListArgs.NaewonDate = aNaewonDate;
            compositeSecondArgs.Out0106u00GridLst = out0106U00GridListArgs;

            NuroPatientReceptionHistoryListArgs receptHisArg = new NuroPatientReceptionHistoryListArgs();
            receptHisArg.PatientCode = abunho;
            compositeSecondArgs.NuroPatientReceptionHis = receptHisArg;

            EMRSetDataForTvExamHistArgs dataForTvExamHistArgs = new EMRSetDataForTvExamHistArgs();
            dataForTvExamHistArgs.Bunho = abunho;
            dataForTvExamHistArgs.HospCode = UserInfo.HospCode;
            compositeSecondArgs.EmrSetDataTvxam = dataForTvExamHistArgs;

            OcsEmrHistoryClinicReferArgs emrHistoryClinicReferArgs = new OcsEmrHistoryClinicReferArgs();
            emrHistoryClinicReferArgs.Bunho = abunho;
            compositeSecondArgs.OcsemrHisClinicRefer = emrHistoryClinicReferArgs;

            OCS2015U06EmrRecordArgs emrRecordArgs = new OCS2015U06EmrRecordArgs();
            emrRecordArgs.Bunho = abunho;
            emrRecordArgs.HospCode = UserInfo.HospCode;
            compositeSecondArgs.Ocs2015u06EmrRecord = emrRecordArgs;

            SettingDiscussArgs settingDiscussArgs = new SettingDiscussArgs(aGwa);
            compositeSecondArgs.SettingDiscuss = settingDiscussArgs;

            OCS2015U00GetDiscussNotifyArgs discussNotifyArgs = new OCS2015U00GetDiscussNotifyArgs();
            compositeSecondArgs.Ocs2015u00GetDiscussNotify = discussNotifyArgs;

            EMRGetLatestWarningStatusArgs latestWarningStatusArgs = new EMRGetLatestWarningStatusArgs();
            latestWarningStatusArgs.Bunho = abunho;
            compositeSecondArgs.EmrGetLastestWarning = latestWarningStatusArgs;


            OCS1003P01GrdPatientArgs grdPatientArgs = new OCS1003P01GrdPatientArgs();
            grdPatientArgs.OrderCnt = cntInfo;
            grdPatientArgs.NaewonYn = "%";
            grdPatientArgs.NaewonDate = aNaewonDate;
            grdPatientArgs.ReserYn = "%";
            grdPatientArgs.Doctor = TypeCheck.NVL(aDoctor, "%").ToString();
            if (mainScreen.MDoctorLogin)
                grdPatientArgs.DoctorModeYn = "Y";
            else
                grdPatientArgs.DoctorModeYn = "N";
            grdPatientArgs.Bunho = "%";

            compositeSecondArgs.Ocs1003p01GrdPatient = grdPatientArgs;

            OcsoOCS1003P01BtnListQueryArgs btnListQueryArgs = new OcsoOCS1003P01BtnListQueryArgs();
            btnListQueryArgs.Bunho = abunho;
            btnListQueryArgs.Gwa = "%";
            btnListQueryArgs.NaewonDate = aNaewonDate;
            btnListQueryArgs.Fkout1001 = aNaewonKey;
            btnListQueryArgs.QueryGubun = "N";
            btnListQueryArgs.InputGubun = mainScreen.MDoctorLogin ? "NR" : mainScreen.mInputGubun;
            btnListQueryArgs.Bunho2 = abunho;
            btnListQueryArgs.NaewonDate2 = mainScreen.DtpNaewonDate.GetDataValue();
            compositeSecondArgs.Ocs1003p01BtnListQuery = btnListQueryArgs;

            NUR1016U00GrdNUR1016Args grdNur1016Args = new NUR1016U00GrdNUR1016Args();
            grdNur1016Args.Bunho = abunho;
            compositeSecondArgs.Nur1016u00Grd = grdNur1016Args;

            NUR1017U00GrdNUR1017Args grdNur1017Args = new NUR1017U00GrdNUR1017Args();
            grdNur1017Args.Bunho = abunho;
            compositeSecondArgs.Nur1017u00Grd = grdNur1017Args;

            OCS2015U00GetPatientInfoArgs getPatientInfoArgs = new OCS2015U00GetPatientInfoArgs();
            getPatientInfoArgs.Bunho = abunho;
            compositeSecondArgs.Ocs2015u00GetPatientInfo = getPatientInfoArgs;

            OCS2015U09GetTemplateComboBoxArgs templateComboBoxArgs = new OCS2015U09GetTemplateComboBoxArgs();
            templateComboBoxArgs.UserId = UserInfo.UserID;
            compositeSecondArgs.Ocs2015u09GetTemplateCombo = templateComboBoxArgs;

            OCS2015U06OrderTypeComboArgs orderTypeComboArgs = new OCS2015U06OrderTypeComboArgs();
            compositeSecondArgs.Ocs2015u06OrderTypeCombo = orderTypeComboArgs;

            OCS0103U13CboListArgs cboListArg = new OCS0103U13CboListArgs();
            cboListArg.ComboItemListInfo = new List<ComboDataSourceInfo>();
            cboListArg.ComboItemListInfo.Add(new ComboDataSourceInfo("suryang", string.Empty, string.Empty, string.Empty));
            cboListArg.ComboItemListInfo.Add(new ComboDataSourceInfo("nalsu", string.Empty, string.Empty, string.Empty));
            cboListArg.ComboItemListInfo.Add(new ComboDataSourceInfo("order_gubun_bas", string.Empty, string.Empty, string.Empty));
            compositeSecondArgs.Ocs0103u13CboLst = cboListArg;

            LoadEmrCompositeSecondResult res =
                CloudService.Instance.Submit<LoadEmrCompositeSecondResult, LoadEmrCompositeSecondArgs>(
                    compositeSecondArgs, false, CallbackCompositeSecond);
        }

        /// <summary>
        /// Get data for grdReserOrderList
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            OcsoOCS1003P01GridReserOrderListArgs vOcsoOCS1003P01GridReserOrderListArgs = new OcsoOCS1003P01GridReserOrderListArgs();
            vOcsoOCS1003P01GridReserOrderListArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            vOcsoOCS1003P01GridReserOrderListArgs.NaewonDate = bc["f_naewon_date"] != null ? bc["f_naewon_date"].VarValue : "";
            OcsoOCS1003P01GridReserOrderListResult result = CloudService.Instance.Submit<OcsoOCS1003P01GridReserOrderListResult, OcsoOCS1003P01GridReserOrderListArgs>(vOcsoOCS1003P01GridReserOrderListArgs);
            if (result != null)
            {
                res = grdReserOrderList_createData(result.GridReserOrderList);
            }
            return res;
        }


        private void grdPatientList_PreEndInitializing(object sender, EventArgs e)
        {
            mainScreen.grdPatientList_PreEndInitializing(sender, e);
        }

        internal IList<object[]> grdReserOrderList_createData(
            List<OcsoOCS1003P01GridReserOrderListInfo> lstGridReserOrderListInfo)
        {
            IList<object[]> lstObject = new List<object[]>();
            if (lstGridReserOrderListInfo != null && lstGridReserOrderListInfo.Count > 0)
            {
                foreach (OcsoOCS1003P01GridReserOrderListInfo gridReserOrderListInfo in lstGridReserOrderListInfo)
                {
                    lstObject.Add(new object[]
                    {
                        gridReserOrderListInfo.KizyunDate,
                        gridReserOrderListInfo.Gwa,
                        gridReserOrderListInfo.GwaName,
                        gridReserOrderListInfo.Doctor,
                        gridReserOrderListInfo.DoctorName,
                        gridReserOrderListInfo.HangmogCode,
                        gridReserOrderListInfo.HangmogName,
                        gridReserOrderListInfo.JundalTable,
                        gridReserOrderListInfo.JundalPart,
                        gridReserOrderListInfo.JundalPartName,
                        gridReserOrderListInfo.ReserTime,
                        gridReserOrderListInfo.ReserYn,
                        gridReserOrderListInfo.ActYn,
                        gridReserOrderListInfo.OrderDate,
                        gridReserOrderListInfo.Pksch
                    });
                }
            }

            return lstObject;
        }

        /// <summary>
        /// Get data for layPat
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> ExecuteQueryOcsoOCS1003P01LayPatInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OcsoOCS1003P01LayPatArgs vOcsoOCS1003P01LayPatArgs = new OcsoOCS1003P01LayPatArgs();
            vOcsoOCS1003P01LayPatArgs.FDoctor = bc["f_doctor"].VarValue;
            vOcsoOCS1003P01LayPatArgs.FBunho = bc["f_bunho"].VarValue;
            vOcsoOCS1003P01LayPatArgs.FNaewonDate = bc["f_naewon_date"].VarValue;
            vOcsoOCS1003P01LayPatArgs.FLoginDoctorYn = bc["f_login_doctor_yn"].VarValue;
            OcsoOCS1003P01LayPatResult result = CloudService.Instance.Submit<OcsoOCS1003P01LayPatResult, OcsoOCS1003P01LayPatArgs>(vOcsoOCS1003P01LayPatArgs);
            if (result != null)
            {
                if (_lstLayPatInfo != null) _lstLayPatInfo.Clear();
                _lstLayPatInfo = result.LayPatInfo;

                foreach (OcsoOCS1003P01LayPatInfo item in result.LayPatInfo)
                {
                    object[] objects = 
				{ 
					item.Gwa, 
					item.Bunho, 
					item.Doctor, 
					item.GroupKey, 
					item.NaewonYn
				};
                    res.Add(objects);
                }
            }

            return res;
        }
        private void btnPost_Click(object sender, EventArgs e)
        {
            mainScreen.FbxBunho.AcceptData();
            if (String.IsNullOrEmpty(this.dtpNaewonDate.GetDataValue()))
            {
                this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate());
            }
            this.dtpNaewonDate.SetDataValue(DateTime.Parse(this.dtpNaewonDate.GetDataValue()).AddDays(1));
            this.dtpNaewonDate.AcceptData();
            mainScreen.LoadPatientList2015U21();
        }

        internal void cboQryGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ChangeUser();
        }

        private void ChangeUser()
        {
            #region [再ログイン]

         //   string gwa = this.cboQryGwa.GetDataValue();
            //string gwa = UserInfo.Gwa;
            string gwa = UserInfo.Gwa;
            string gwaName = "";
            string errMsg = "";

            if (gwa == "")
                return;

            //ドクターの場合のみ再ログインをする。
            if (mainScreen.MDoctorLogin)
            {

                //string cmdStr = "SELECT A.GWA_NAME"s
                //                + "  FROM BAS0260 A"
                //                + " WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "'"
                //                + "   AND A.GWA   = '" + gwa + "'"
                //                + "   AND SYSDATE BETWEEN A.START_DATE AND A.END_DATE";

                //object retVal = Service.ExecuteScalar(cmdStr);

                //if (!TypeCheck.IsNull(retVal))
                //{
                //    gwaName = retVal.ToString();
                //}

                ////tungtx
                //OCS1003P01ChangeUserArgs args = new OCS1003P01ChangeUserArgs();
                //args.Gwa = gwa;
                //OCS1003P01ChangeUserResult result =
                //    CloudService.Instance.Submit<OCS1003P01ChangeUserResult, OCS1003P01ChangeUserArgs>(args);
                //if (result != null)
                //{
                //    if (!String.IsNullOrEmpty(result.GwaName))
                //    {
                //        gwaName = result.GwaName;
                //    }
                //}
                gwaName = dbxDoctor_name.Text;


                //사용자 정보 Check 실패시 return
                if (!UserInfoUtil.CheckUserDoctor(EnvironInfo.CurrSystemID, UserInfo.UserID, UserInfo.UserPswd, false, gwa, gwaName, out errMsg))
                {
                    //lbMsg.Text = errMsg;
                    //this.txtUserID.Focus();
                    return;
                }

                //시스템 사용자 진입 등록
                UserInfoUtil.RegisterSystemUser(EnvironInfo.CurrSystemID, UserInfo.UserID);

                //ID 저장시 Registry에 SET
                UserInfoUtil.SetSystemUserToRegistry(EnvironInfo.CurrSystemID, UserInfo.UserID, true);

                //mdiForm.SetStatusBar(UserInfo.UserName, UserInfo.BuseoName, "");
                //mdiForm.Refresh();
            }

            this.SettingVisiblebyUser();

            #endregion

            //// 주치의 콤보박스 재구성
            //this.ReLoadDoctorCombo(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue());

            //// 환자리스트 로드 
            //this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

            // 주치의 콤보박스 재구성
            this.ReLoadDoctorCombo(this.dtpNaewonDate.GetDataValue(), gwa);

            // 환자리스트 로드 
            //this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), gwa, this.cboQryDoctor.GetDataValue());
            //this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), gwa, this.fbxDoctor.GetDataValue(),paBox.BunHo);
        }

        /// <summary>
        /// 조회용 진료과 콤보 재구성
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        internal void ReLoadGwaCombo(string aNaewonDate)
        {
            //this.cboQryGwa.SelectedValueChanged -= new EventHandler(cboQryGwa_SelectedValueChanged);
            //string aCurrentGwa = this.cboQryGwa.GetDataValue();
            ////DataTable dt = this.mOrderBiz.LoadComboDataSource("gwa", aNaewonDate).LayoutTable;
            //cboQryGwa.ExecuteQuery = mainScreen.LoadDataCboGwa;

            //this.cboGwa.SelectedValueChanged -= new EventHandler(cboGwa_SelectedValueChanged);
            string aCurrentGwa = this.cboGwa.GetDataValue();
            //DataTable dt = this.mOrderBiz.LoadComboDataSource("gwa", aNaewonDate).LayoutTable;
            //cboGwa.ExecuteQuery = mainScreen.LoadDataCboGwa;


            if (aCurrentGwa == "")
            {
                aCurrentGwa = mainScreen.MParamGwa;
            }

            //this.cboQryGwa.SetComboItems(dt, "code_name", "code");
            //this.cboQryGwa.SetDictDDLB();

            if (mainScreen.MDoctorLogin == true)
            {
                //this.cboQryGwa.SetDataValue(this.mainScreen.MInputGwa);
                this.cboGwa.SetDataValue(this.mainScreen.MInputGwa);
            }
            else
            {

                //if (aCurrentGwa != "" && this.cboQryGwa.ComboItems.Contains(aCurrentGwa))
                //{
                //    this.cboQryGwa.SetDataValue(aCurrentGwa);
                //}
                //else
                //{
                //    if (this.mainScreen.MInputGwa != "" && this.cboQryGwa.ComboItems.Contains(mainScreen.MInputGwa))
                //    {
                //        this.cboQryGwa.SetDataValue(mainScreen.MInputGwa);
                //    }
                //    else
                //    {
                //        this.cboQryGwa.SelectedIndex = 0;
                //    }
                //}
                if (aCurrentGwa != "" && this.cboGwa.ComboItems.Contains(aCurrentGwa))
                {
                    this.cboGwa.SetDataValue(aCurrentGwa);
                }
                else
                {
                    if (this.mainScreen.MInputGwa != "" && this.cboGwa.ComboItems.Contains(mainScreen.MInputGwa))
                    {
                        this.cboGwa.SetDataValue(mainScreen.MInputGwa);
                    }
                    else
                    {
                        this.cboGwa.SelectedIndex = 0;
                    }
                }
            }

            //this.cboQryGwa.SelectedValueChanged += new EventHandler(cboQryGwa_SelectedValueChanged);            
        }

        public XPanel PnlUser
        {
            get { return pnlUser; }
        }

        /// <summary>
        /// 조회용 주치의 콤보 재구성
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aGwa">진료과</param>
        internal void ReLoadDoctorCombo(string aNaewonDate, string aGwa)
        {
            //try
            //{
            //    this.cboQryDoctor.SelectedValueChanged -= new EventHandler(cboQryDoctor_SelectedValueChanged);
            //    string aCurrentDoctor = this.cboQryDoctor.GetDataValue();
            //    DataTable dt = mainScreen.MOrderBiz.LoadComboDataSource("doctor", aNaewonDate, aGwa).LayoutTable;

            //    if (aCurrentDoctor == "")
            //    {
            //        aCurrentDoctor = mainScreen.MParamDoctor;
            //    }
            //    else
            //    {
            //        //変更された後の診療科に設定。
            //        aCurrentDoctor = aGwa + aCurrentDoctor.Substring(2);
            //    }

            //    this.cboQryDoctor.SetComboItems(dt, "code_name", "code");

            //    if (mainScreen.MDoctorLogin == true)
            //    {
            //        this.cboQryDoctor.SetDataValue(UserInfo.DoctorID);
            //    }
            //    else
            //    {
            //        if (aCurrentDoctor != "" && this.cboQryDoctor.ComboItems.Contains(aCurrentDoctor))
            //        {
            //            this.cboQryDoctor.SetDataValue(aCurrentDoctor);
            //        }
            //        else
            //        {
            //            this.cboQryDoctor.SelectedIndex = 0;
            //        }
            //    }

            //    this.cboQryDoctor.SelectedValueChanged += new EventHandler(cboQryDoctor_SelectedValueChanged);

            //    string dsItmeCboQryDoctor = "";
            //    if (this.cboQryDoctor.ComboItems[this.cboQryDoctor.SelectedIndex] != null)
            //        dsItmeCboQryDoctor = this.cboQryDoctor.ComboItems[this.cboQryDoctor.SelectedIndex].DisplayItem;
            //    mainScreen.LblApproveDoctorName.Text = "⇒ " + dsItmeCboQryDoctor;
            //}
            //catch (Exception ex)
            //{
            //    Service.WriteLog("Error: ReLoadDoctorCombo on OCS2015U21" + ex.StackTrace);
            //}
        }

        /// <summary>
        /// 환자별로 Visible 셋팅될것들...
        /// </summary>
        internal void SettingVisiblebyUser()
        {

            if (!this.Visible)
            {
                this.pnlUser.Visible = true;
            }
            // 의사가 로그인 한 경우
            if (mainScreen.MDoctorLogin == true)
            {
                // tungtx
                // Connect cloud
                OCS1003P01SettingVisibleByUserArgs args = new OCS1003P01SettingVisibleByUserArgs();
                if (grdPatientList.GetItemString(grdPatientList.CurrentRowNumber, "bunho").ToString() != "")
                {
                    NaewonYNInfo1 yninfo = new NaewonYNInfo1();
                    yninfo.Bunho = mainScreen.MSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                    yninfo.NaewonDate = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                    yninfo.Pkout1001 = mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                    args.NaewonParam = yninfo;
                }

                NotApproveOrderCntInfo cntInfo = new NotApproveOrderCntInfo();
                cntInfo.IoGubun = mainScreen.N_IO_Gubun;
                cntInfo.UserId = UserInfo.UserID;
                cntInfo.InsteadYn = "Y";
                cntInfo.ApproveYn = "N";
                cntInfo.Key = "%";

                args.CountParam = cntInfo;
                OCS1003P01SettingVisibleByUserResult result =
                    CloudService.Instance
                        .Submit<OCS1003P01SettingVisibleByUserResult, OCS1003P01SettingVisibleByUserArgs>(args);
                int countValue = 0;
                if (result != null && result.CountValue != null)
                {
                    countValue = Int32.Parse(result.CountValue);
                }
                // End connect cloud

                this.pnlUser.Visible = false;
                //this.cboQryDoctor.Protect = true;
                //mainScreen.BtnIpwonReser.Visible = true;
                mainScreen.BtnConsult.Enabled = true;
                mainScreen.BtnConsultAnswer.Enabled = true;
                //mainScreen.BtnJinryoReser.Enabled = true;
                mainScreen.BtnConsultAnswer.Enabled = true;
                mainScreen.BtnOpenOutSang.Enabled = true;

                mainScreen.BtnList.FunctionItems.Clear();
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Query, Shortcut.None, Resources.QUERY_BUTTON_TEXT, -1, ""));
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Cancel, Shortcut.None, Resources.CANCEL_BUTTON_TEXT, -1, "OliveGreen"));
                //該当する患者のステータスが保留であれば診療保留ボタンを保留取消に切り替えるように修正 2012/09/10
                if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "bunho").ToString() != "")
                {
                    //if (mainScreen.MOrderBiz.GetNaewonYN(mainScreen.MSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), mainScreen.MSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) == "H")
                    //    mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET1_BUTTON_TEXT, -1, "HotPink"));
                    //else
                    //    mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET2_BUTTON_TEXT, -1, "HotPink"));

                    if (!String.IsNullOrEmpty(result.YnValue) && "H".Equals(result.YnValue))
                        mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET1_BUTTON_TEXT, -1, "HotPink"));
                    else
                        mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET2_BUTTON_TEXT, -1, "HotPink"));
                }
                else
                    mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET2_BUTTON_TEXT, -1, "HotPink"));
                //mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Insert, Shortcut.None, "傷病入力", -1, ""));
                //mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Delete, Shortcut.None, "傷病削除", -1, ""));
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, Resources.UPDATE_BUTTON_TEXT, -1, ""));
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.PROCESS_BUTTON_TEXT, -1, "OliveGreen"));
                //mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Close, Shortcut.None, "閉じる", -1, ""));
                //mainScreen.BtnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //mainScreen.BtnList.Location = new Point(924, 639);
                mainScreen.BtnList.InitializeButtons();
                mainScreen.BtnList.Refresh();

                mainScreen.BtnApprove.Enabled = true;

                //mainScreen.PbxApprove.Visible = mainScreen.MOrderBiz.GetNotApproveOrderCnt(this.IO_Gubun, UserInfo.UserID, "Y", "N", "%") > 0 ? true : false;
                mainScreen.PbxApprove.Visible = countValue > 0 ? true : false;

            }
            // 의사 이외의 사람들이 로그인 한 경우
            else
            {
                this.pnlUser.Visible = false;

                mainScreen.BtnIpwonReser.Enabled = true;
                mainScreen.BtnConsult.Enabled = false;
                mainScreen.BtnConsultAnswer.Enabled = true;
                //mainScreen.BtnJinryoReser.Enabled = false;
                mainScreen.BtnConsultAnswer.Enabled = false;
                mainScreen.BtnOpenOutSang.Enabled = false;
                mainScreen.BtnList.FunctionItems.Clear();

                #region DzungTA change due to issue MED-2841
                //mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Query, Shortcut.None, Resources.QUERY_BUTTON_TEXT, -1, ""));
                ////mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Insert, Shortcut.None, "傷病入力", -1, ""));
                ////mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Delete, Shortcut.None, "傷病削除", -1, ""));
                //mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, Resources.UPDATE_BUTTON_TEXT, -1, ""));

                //if (UserInfo.Gwa != "CK")
                //    mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.PROCESS_BUTTON_TEXT, -1, "OliveGreen"));

                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Query, Shortcut.None, Resources.QUERY_BUTTON_TEXT, -1, ""));
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Cancel, Shortcut.None, Resources.CANCEL_BUTTON_TEXT, -1, ""));
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Reset, Shortcut.None, Resources.RESET2_BUTTON_TEXT, -1, ""));
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, Resources.UPDATE_BUTTON_TEXT, -1, ""));
                mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.PROCESS_BUTTON_TEXT, -1, ""));
                #endregion

                //mainScreen.BtnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Close, Shortcut.None, "閉じる", -1, ""));
                //mainScreen.BtnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //mainScreen.BtnList.Location = new Point(924, 639);
                mainScreen.BtnList.InitializeButtons();
                mainScreen.BtnList.Refresh();

                mainScreen.BtnApprove.Enabled = false;
                mainScreen.PbxApprove.Visible = false;

                mainScreen.BtnList.SetEnabled(FunctionType.Cancel, false);
                mainScreen.BtnList.SetEnabled(FunctionType.Reset, false);
                mainScreen.BtnList.SetEnabled(FunctionType.Process, false);
            }
        }

        void cboQryDoctor_SelectedValueChanged(object sender, EventArgs e)
        {
             //환자리스트 로드 
            PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboQryGwa.GetDataValue(), this.cboQryDoctor.GetDataValue());

            mainScreen.MPostApproveYN = mainScreen.MOrderBiz.getEnablePostApprove("O", this.cboQryDoctor.SelectedValue.ToString());

            if (mainScreen.MPostApproveYN)
                mainScreen.LblApproveFlag.Text = "事後";
            else
                mainScreen.LblApproveFlag.Text = "事前";

            mainScreen.LblApproveDoctorName.Text = "⇒ " + this.cboQryDoctor.ComboItems[this.cboQryDoctor.SelectedIndex].DisplayItem;
        }

        private void rbnNotJinryo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton control = sender as RadioButton;

            if (control.Checked)
            {
                control.ImageIndex = 3;
                control.BackColor = mainScreen.MSelectedBackColor.Color;
                control.ForeColor = mainScreen.MSelectedForeColor.Color;

                // 환자 리스트 필터링
                SetPatientListGridFilter();
            }
            else
            {
                control.ImageIndex = 4;
                control.BackColor = mainScreen.MUnSelectedBackColor.Color;
                control.ForeColor = mainScreen.MUnSelectedForeColor.Color;
            }
        }

        private void btnHelp2_Click(object sender, EventArgs e)
        {
            pnlHelp2.Visible = !pnlHelp2.Visible;
        }

        private void grdPatientList_MouseDown(object sender, MouseEventArgs e)
        {
            int rowNumber = -1;
            XEditGrid grd = sender as XEditGrid;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                rowNumber = this.grdPatientList.GetHitRowNumber(e.Y);
                // 현재 선택된 로우의 환자번호 적용
                if (rowNumber >= 0)
                {
                    // 현재 파인드 박스의 환자번호와 선택된 번호가 
                    // 동일한경우는 스킵
                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        ProcessMouseClick(rowNumber);
                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                        //MED-9995 have to close after using, otherwise it will cause exeception
                        this.Dispose(false);
                    }
                }
            }
        }

        private void ProcessMouseClick(int rowNumber)
        {
            //mainScreen.MParamNaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
            mainScreen.MClickedNaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
            //insert by jc [選択された患者の保険を取得]
            mainScreen.MClickedGubun = this.grdPatientList.GetItemString(rowNumber, "gubun");

            string bunho = this.grdPatientList.GetItemString(rowNumber, "bunho");

            LoadEmrCompositeFirst(bunho, rowNumber, true);
            //同名二人CHECK2013/01/05

            // TODO: No need to check for DEMO
            /*if (mainScreen.IsSameNameCHK() == true)
                        {
                            if (MessageBox.Show("同じ名前の患者さんが受付されています。\n[漢字名: " + this.grdPatientList.GetItemString(rowNumber, "suname") + "], \n[カナ名: "
                                                                                          + this.grdPatientList.GetItemString(rowNumber, "suname2") + "], \n[年齢: "
                                                                                          + this.grdPatientList.GetItemString(rowNumber, "age") + "]\nこの患者さんでよろしいでしょうか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                return;
                        }*/

            //insert by jc [共通医を選択すると診療を進めるかを聞くメッセージを表示する。] 2012/03/12
            if (mainScreen.IsCommonDoctorJubsu(this.grdPatientList.GetItemString(rowNumber, "pk_naewon")) == true)
            {
                if (MessageBox.Show("共通医受付患者です。診療を開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                    DialogResult.No)
                    return;
                else
                {
                    if (mainScreen.MDoctorLogin)
                        mainScreen.ProcessCommonDoctor(this.grdPatientList.GetItemString(rowNumber, "pk_naewon"));
                }
            }
            mainScreen.MPatientDoubleClick = true;
            mainScreen.FbxBunho.SetEditValue(this.grdPatientList.GetItemString(rowNumber, "bunho"));

            mainScreen.FbxBunho.AcceptData();

            mainScreen.SetDefaultTemplate = true;
        }

        private void LoadEmrCompositeFirst(string bunho, int rowNumber, bool selectFromU21)
        {
            LoadEmrCompositeFirstArgs compositeFirstArgs = new LoadEmrCompositeFirstArgs();
            if (selectFromU21)
            {
                OcsoOCS1003P01CheckYArgs checkYArgs = new OcsoOCS1003P01CheckYArgs();
                checkYArgs.NaewonKey = this.grdPatientList.GetItemString(rowNumber, "pk_naewon");
                compositeFirstArgs.Ocs1003p01CheckY = checkYArgs;
            }

            OCS2015U00GetMaxSizeArgs maxSizeArgs = new OCS2015U00GetMaxSizeArgs();
            compositeFirstArgs.Ocs2015u00GetMaxSize = maxSizeArgs;

            OCS2015U06EmrTagArgs emrTagargs = new OCS2015U06EmrTagArgs();
            compositeFirstArgs.Ocs2015u06EmrTag = emrTagargs;

            OcsoOCS1003P01LayPatArgs layPatArgs = new OcsoOCS1003P01LayPatArgs();
            layPatArgs.FDoctor = this.cboQryDoctor.GetDataValue();
            layPatArgs.FBunho = bunho;
            layPatArgs.FNaewonDate = this.dtpNaewonDate.GetDataValue();
            layPatArgs.FLoginDoctorYn = mainScreen.MDoctorLogin ? "Y" : "N";
            compositeFirstArgs.Ocs1003p01LayPat = layPatArgs;

            PatientInfoLoadPatientNaewonListArgs patientNaewonListArgs = new PatientInfoLoadPatientNaewonListArgs();
            patientNaewonListArgs.Bunho = bunho;
            patientNaewonListArgs.NaewonDateBase = "";
            patientNaewonListArgs.ApproveDoctor = this.cboQryDoctor.GetDataValue();
            patientNaewonListArgs.DoctorModeYn = UserInfo.UserGubun == UserType.Doctor ? "Y" : "N";
            patientNaewonListArgs.IoGubun = "O";
            patientNaewonListArgs.PkKeyOut = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
            patientNaewonListArgs.NaewonDate = this.dtpNaewonDate.GetDataValue();
            patientNaewonListArgs.Gwa = this.cboQryGwa.GetDataValue();
            patientNaewonListArgs.Doctor = this.cboQryDoctor.GetDataValue();
            patientNaewonListArgs.JaewonFlag = TypeCheck.NVL(mainScreen.MPatientInfoParam.JaewonFlag, "Y").ToString();
            string inp = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
            if (!TypeCheck.IsInt(inp)) inp = "";
            patientNaewonListArgs.PkKeyInp = inp;
            patientNaewonListArgs.IsEnableIpwonReser = "Y";
            compositeFirstArgs.PatientInfoNaewonLst = patientNaewonListArgs;

            FormEnvironInfoSysDateArgs sysDateArgs = new FormEnvironInfoSysDateArgs();
            compositeFirstArgs.EnvironInfoSysDate = sysDateArgs;

            PrOcsLoadNaewonInfoArgs niArgs = new PrOcsLoadNaewonInfoArgs();
            niArgs.NaewonKey = TypeCheck.NVL(mainScreen.MClickedNaewonKey, mainScreen.MParamNaewonKey).ToString();
            int index = niArgs.NaewonKey.IndexOf('.');
            if (index >= 0)
            {
                niArgs.NaewonKey = niArgs.NaewonKey.Substring(0, index);
            }
            compositeFirstArgs.OcsLoadNaewonInfo = niArgs;
            OCS2015U00GetPatientInfoArgs getPatientInfoArgs = new OCS2015U00GetPatientInfoArgs();
            getPatientInfoArgs.Bunho = bunho;
            compositeFirstArgs.Ocs2015u00GetPatientInfo = getPatientInfoArgs;

            LoadEmrCompositeFirstResult res = CloudService.Instance.Submit<LoadEmrCompositeFirstResult, LoadEmrCompositeFirstArgs>(compositeFirstArgs, false, CallbackCompositeFist);

        }

        public void ProcessMouseClick(string aBunho, string aGubun, string aPkNaewon)
        {
            try
            {
                mainScreen.MClickedNaewonKey = aPkNaewon;
                //insert by jc [選択された患者の保険を取得]
                mainScreen.MClickedGubun = aGubun;

                string bunho = aBunho;

                LoadEmrCompositeFirst(bunho, 0, false);
                //同名二人CHECK2013/01/05

                // TODO: No need to check for DEMO
                /*if (mainScreen.IsSameNameCHK() == true)
                {
                    if (MessageBox.Show("同じ名前の患者さんが受付されています。\n[漢字名: " + this.grdPatientList.GetItemString(rowNumber, "suname") + "], \n[カナ名: "
                                                                                    + this.grdPatientList.GetItemString(rowNumber, "suname2") + "], \n[年齢: "
                                                                                    + this.grdPatientList.GetItemString(rowNumber, "age") + "]\nこの患者さんでよろしいでしょうか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;
                }*/

                //insert by jc [共通医を選択すると診療を進めるかを聞くメッセージを表示する。] 2012/03/12
                if (mainScreen.IsCommonDoctorJubsu(aPkNaewon) == true)
                {
                    if (MessageBox.Show("共通医受付患者です。診療を開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                        DialogResult.No)
                        return;
                    else
                    {
                        if (mainScreen.MDoctorLogin)
                            mainScreen.ProcessCommonDoctor(aPkNaewon);
                    }
                }
                mainScreen.MPatientDoubleClick = true;
                mainScreen.FbxBunho.SetEditValue(aBunho);

                mainScreen.FbxBunho.AcceptData();

                mainScreen.SetDefaultTemplate = true;
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error in the method: ProcessMouseClick()" + ex.StackTrace);
            }
        }

        private void grdPatientList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            // 예약환자인경우
            if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
            {
                e.BackColor = mainScreen.MReserPatientColor.Color;
            }

            // 検査予約(次回)
            if (grid.GetItemString(e.RowNumber, "kensa_yn") == "Y")
            {
                e.BackColor = mainScreen.MKensaReserPatientColor.Color;
            }

            // 진료의뢰환자의 경우 핑크
            if (grid.GetItemString(e.RowNumber, "consult_yn") == "Y")
            {
                e.BackColor = Color.LightPink;
            }

            // 공통의인경우 
            if (e.ColName == "suname")
            {
                if (grid.GetItemString(e.RowNumber, "common_doctor_yn") == "Y")
                {
                    e.BackColor = Color.Khaki;
                }
            }

            ////

            if (grid.GetItemString(e.RowNumber, "sysId") == "MBSO")
            {
                e.BackColor = Color.LightYellow;
            }

            //if (grid.GetItemString(e.RowNumber, "hide_yn") == "N")
            //{
            //    grid.CellInfos[e.RowNumber, 37].EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            //    //this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            //}
            //else
            //{ 
            //    //this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.EditBox;
            //    grid.CellInfos[e.RowNumber, 37].EditorStyle = IHIS.Framework.XCellEditorStyle.EditBox;
            //}
            if (mainScreen.MDoctorLogin)
            {
                if (grid.GetItemString(e.RowNumber, "hide_yn") == "N")
                {
                    this.grdPatientList.ChangeButtonEnable("hide_yn", e.RowNumber, true);
                }
                else
                {
                    this.grdPatientList.ChangeButtonEnable("hide_yn", e.RowNumber, false);
                }
            }
            else
            {
                this.grdPatientList.ChangeButtonEnable("hide_yn", e.RowNumber, false);
            }


        }

        private void grdPatientList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPatientList.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
        }

        /// <summary>
        /// 대기환자 그리드 쿼리
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aGwa">진료과</param>
        /// <param name="aDoctor">주치의</param>
        /// <returns>성공시 true</returns>
        internal bool PatientListQuery(string aNaewonDate, string aGwa, string aDoctor)
        {
            // Connect cloud 
            mainScreen.grdPatientResult = mainScreen.grdPatient_getData(aNaewonDate, aDoctor);
            if (grdPatientList == null)
            {
                return false;
            }

            string prevKey = "";

            int approve_cnt = 0;
            if (!string.IsNullOrEmpty(mainScreen.grdPatientResult.CntValue))
            {
                approve_cnt = Int32.Parse(mainScreen.grdPatientResult.CntValue);
            }

            //mainScreen.BtnApprove.Text = "承認待ち有";
            mainScreen.toolTip1.SetToolTip(mainScreen.BtnApprove, Resources.PRE_APPROVE_BUTTON_TEXT + approve_cnt + Resources.SUFFIX_APPROVE_BUTTON_TEXT);

            if (approve_cnt > 0)
                mainScreen.PbxApprove.Visible = true;
            else
                mainScreen.PbxApprove.Visible = false;

            if (this.grdPatientList.RowCount > 0 &&
                this.grdPatientList.CurrentRowNumber >= 0)
            {
                prevKey = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pk_naewon");
            }

            grdPatientList.ExecuteQuery = mainScreen.grdPatientList_CreateData;

            if (this.grdPatientList.QueryLayout(true) == true)
            {
                // 조회후 현재 라디오 버튼에 따른 필터링.

                this.SetPatientListGridFilter();

                // 이전 환자 선택 없으면 제일처음
                if (prevKey != "")
                {
                    for (int i = 0; i < this.grdPatientList.RowCount; i++)
                    {
                        if (this.grdPatientList.GetItemString(i, "pk_naewon") == prevKey)
                        {
                            this.grdPatientList.SetFocusToItem(i, 0);
                            break;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        internal bool PatientListQuery(string aNaewonDate, string aGwa, string aDoctor, string PatientCode)
        {
            // Connect cloud 
            mainScreen.grdPatientResultOCS2015U21 = mainScreen.grdPatient_getDataOCS2015U21(aNaewonDate, aDoctor, PatientCode, aGwa);
            if (grdPatientList == null)
            {
                return false;
            }

            string prevKey = "";

            int approve_cnt = 0;
            if (!string.IsNullOrEmpty(mainScreen.grdPatientResultOCS2015U21.CntValue))
            {
                approve_cnt = Int32.Parse(mainScreen.grdPatientResultOCS2015U21.CntValue);
            }

            //mainScreen.BtnApprove.Text = "承認待ち有";
            mainScreen.toolTip1.SetToolTip(mainScreen.BtnApprove, Resources.PRE_APPROVE_BUTTON_TEXT + approve_cnt + Resources.SUFFIX_APPROVE_BUTTON_TEXT);

            if (approve_cnt > 0)
                mainScreen.PbxApprove.Visible = true;
            else
                mainScreen.PbxApprove.Visible = false;

            if (this.grdPatientList.RowCount > 0 &&
                this.grdPatientList.CurrentRowNumber >= 0)
            {
                prevKey = this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "pk_naewon");
            }

            grdPatientList.ExecuteQuery = mainScreen.grdPatientList_CreateData2015U21;
            
            if (this.grdPatientList.QueryLayout(true) == true)
            {
                // 조회후 현재 라디오 버튼에 따른 필터링.

                this.SetPatientListGridFilter();

                // 이전 환자 선택 없으면 제일처음
                if (prevKey != "")
                {
                    for (int i = 0; i < this.grdPatientList.RowCount; i++)
                    {
                        if (this.grdPatientList.GetItemString(i, "pk_naewon") == prevKey)
                        {
                            this.grdPatientList.SetFocusToItem(i, 0);
                            break;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        private void SetPatientListGridFilter()
        {
            //if (this.grdPatientList.RowCount <= 0) return; ImgLst

            string filter = "";

            if (this.rbnNotJinryo.Checked)
            {
                filter = "jinryo_end_yn='N'";
            }
            else if (this.rbnJinryo.Checked)
            {
                filter = "jinryo_end_yn='Y'";
            }

            this.grdPatientList.SetFilter(filter);

            SetPatientListImage();
        }


        private void SetPatientListImage()
        {
            for (int i = 0; i < this.grdPatientList.RowCount; i++)
            {
                // 예약환자
                if (this.grdPatientList.GetItemString(i, "reser_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[19];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/予約患者";
                    //MED-6663 edit by TungTX
                    //Start MED-6663

                    //MED-8001 edit by HoangVV
                    //Start MED-8001
                    //this.grdPatientList.SetItemValue(i, "arrive_time", "");
                    this.grdPatientList.ResetUpdate();
                }
                else
                {
                    //this.grdPatientList.SetItemValue(i, "jinryo_time", "");
                    this.grdPatientList.ResetUpdate();
                }
                //End MED-8001
                //End MED-6663
                

                if (this.grdPatientList.GetItemString(i, "kensa_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[29];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/検査予約あり";
                }

                // 컨설트 환자
                if (this.grdPatientList.GetItemString(i, "consult_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[22];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/診療依頼";
                }

                // 공통의 환자
                if (this.grdPatientList.GetItemString(i, "common_doctor_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[34];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/共通医";
                }

                switch (this.grdPatientList.GetItemString(i, "jubsu_gubun"))
                {
                    case "07":    // 약만의 환자

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[6];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/薬のみ";

                        break;

                    case "14":    // 긴급환자

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[30];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/救急";

                        break;

                    case "15":  // 건강진단

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[33];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;

                    case "20":  // 外診１

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[41];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;

                    case "21":  // 外診２

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[42];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;

                    case "22":  // 再診

                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].Image = mainScreen.ImgLst.Images[43];
                        this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 0].ToolTipText + "/健康診断";

                        break;
                }

                if (this.grdPatientList.GetItemString(i, "unapprove_yn") == "Y")
                {
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].Image = mainScreen.ImgLst.Images[44];
                    this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].ToolTipText = this.grdPatientList[i + this.grdPatientList.HeaderHeights.Count, 3].ToolTipText + "/未承認オーダーあり";
                }
            }
        }

        private void pnlUser_VisibleChanged(object sender, EventArgs e)
        {
            UpdateHelpPanel();
        }

        public void UpdateHelpPanel()
        {
            if (this.pnlUser.Visible == false && this.btnHelp2.Location.Y > 100)
            {
                this.btnHelp2.Location = new Point(this.btnHelp2.Location.X, this.btnHelp2.Location.Y - this.pnlUser.Height);
                this.pnlHelp2.Location = new Point(this.pnlHelp2.Location.X, this.pnlHelp2.Location.Y - this.pnlUser.Height);
            }
            else if (this.pnlUser.Visible && this.btnHelp2.Location.Y < 100)
            {
                this.btnHelp2.Location = new Point(this.btnHelp2.Location.X, this.btnHelp2.Location.Y + this.pnlUser.Height);
                this.pnlHelp2.Location = new Point(this.pnlHelp2.Location.X, this.pnlHelp2.Location.Y + this.pnlUser.Height);
            }
        }

        #region DzungTA add new event
        public delegate void CloseParentFormHandler(object sender, EventArgs e);
        public event CloseParentFormHandler OnCloseParentForm;
        #endregion

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackCompositeFist(LoadEmrCompositeFirstArgs args, LoadEmrCompositeFirstResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();
            cacheOne.Add(args.Ocs1003p01CheckY, new KeyValuePair<int, object>(1, result.Ocs1003p01CheckY));
            cacheOne.Add(args.Ocs2015u00GetMaxSize, new KeyValuePair<int, object>(1, result.Ocs2015u00GetMaxSize));
            //cacheOne.Add(args.Ocs2015u06EmrTag, result.Ocs2015u06EmrTag);
            cacheOne.Add(args.Ocs1003p01LayPat, new KeyValuePair<int, object>(1, result.Ocs1003p01LayPat));
            cacheOne.Add(args.PatientInfoNaewonLst, new KeyValuePair<int, object>(4, result.PatientInfoNaewonLst));
            cacheOne.Add(args.EnvironInfoSysDate, new KeyValuePair<int, object>(1, result.EnvironInfoSysDate));
            cacheOne.Add(args.OcsLoadNaewonInfo, new KeyValuePair<int, object>(3, result.OcsLoadNaewonInfo));
            cacheOne.Add(args.Ocs2015u00GetPatientInfo, new KeyValuePair<int, object>(5, result.Ocs2015u00GetPatientInfo));
            cacheData.Add(CachePolicy.ONCE, cacheOne);
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();
            cacheSession.Add(args.Ocs2015u06EmrTag, new KeyValuePair<int, object>(0, result.Ocs2015u06EmrTag));
            cacheData.Add(CachePolicy.SESSION, cacheSession);
            return cacheData;
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackCompositeSecond(LoadEmrCompositeSecondArgs args, LoadEmrCompositeSecondResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();
            cacheOne.Add(args.EnvironInfoSysDate, new KeyValuePair<int, object>(2, result.EnvironInfoSysDate));
            cacheOne.Add(args.Ocs2015u21ControlDataValidate, new KeyValuePair<int, object>(1, result.Ocs2015u21ControlDataValidate));
            cacheOne.Add(args.OpenAllergyInfo, new KeyValuePair<int, object>(1, result.OpenAllergyInfo));
            cacheOne.Add(args.LoadConsultEndYn, new KeyValuePair<int, object>(1, result.LoadConsultEndYn));
            cacheOne.Add(args.Ocs1003p01LoadConsultEnd, new KeyValuePair<int, object>(1, result.Ocs1003p01LoadConsultEnd));
            cacheOne.Add(args.LoadPatientSpecComment, new KeyValuePair<int, object>(1, result.LoadPatientSpecComment));
            cacheOne.Add(args.GetOutJinryoComment, new KeyValuePair<int, object>(1, result.GetOutJinryoComment));
            cacheOne.Add(args.IpwonReserStatus, new KeyValuePair<int, object>(1, result.IpwonReserStatus));
            cacheOne.Add(args.XpaInfoBox, new KeyValuePair<int, object>(1, result.XpaInfoBox));
            cacheOne.Add(args.Ocs1003p01SettingVisible, new KeyValuePair<int, object>(1, result.Ocs1003p01SettingVisible));
            cacheOne.Add(args.Ocs1003p01GridReserOrder, new KeyValuePair<int, object>(1, result.Ocs1003p01GridReserOrder));
            cacheOne.Add(args.Out0106u00GridLst, new KeyValuePair<int, object>(3, result.Out0106u00GridLst));
            cacheOne.Add(args.NuroPatientReceptionHis, new KeyValuePair<int, object>(1, result.NuroPatientReceptionHis));
            cacheOne.Add(args.EmrSetDataTvxam, new KeyValuePair<int, object>(1, result.EmrSetDataTvxam));
            cacheOne.Add(args.OcsemrHisClinicRefer, new KeyValuePair<int, object>(1, result.OcsemrHisClinicRefer));
            cacheOne.Add(args.Ocs2015u06EmrRecord, new KeyValuePair<int, object>(1, result.Ocs2015u06EmrRecord));
            cacheOne.Add(args.SettingDiscuss, new KeyValuePair<int, object>(2, result.SettingDiscuss));
            cacheOne.Add(args.Ocs2015u00GetDiscussNotify, new KeyValuePair<int, object>(1, result.Ocs2015u00GetDiscussNotify));
            cacheOne.Add(args.EmrGetLastestWarning, new KeyValuePair<int, object>(1, result.EmrGetLastestWarning));
            cacheOne.Add(args.Ocs0103u13CboLst, new KeyValuePair<int, object>(3, result.Ocs0103u13CboLst));
            cacheOne.Add(args.Ocs1003p01GrdPatient, new KeyValuePair<int, object>(1, result.Ocs1003p01GrdPatient));
            cacheOne.Add(args.Ocs1003p01BtnListQuery, new KeyValuePair<int, object>(1, result.Ocs1003p01BtnListQuery));
            cacheOne.Add(args.Nur1016u00Grd, new KeyValuePair<int, object>(1, result.Nur1016u00Grd));
            cacheOne.Add(args.Nur1017u00Grd, new KeyValuePair<int, object>(1, result.Nur1017u00Grd));
            cacheOne.Add(args.Ocs2015u09GetTemplateCombo, new KeyValuePair<int, object>(1, result.Ocs2015u09GetTemplateCombo));
            cacheOne.Add(args.Ocs2015u06OrderTypeCombo, new KeyValuePair<int, object>(1, result.Ocs2015u06OrderTypeCombo));
            cacheData.Add(CachePolicy.ONCE, cacheOne);
            return cacheData;
        }

        private void btnAutoReload_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                btnAutoReload.ImageIndex = 4;
                flag = false;
                //PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboGwa.GetDataValue(), this.fbxDoctor.GetDataValue(), this.paBox.BunHo);
                this.QueryTime = 30000;
            }
            else
            {
                btnAutoReload.ImageIndex = 3;
                flag = true;
            }      
        }

        private void timAutoReLoad_Tick(object sender, EventArgs e)
        {
            if (flag == true)
            {
                this.lbTime.Text = (this.QueryTime / 1000).ToString();
                this.QueryTime = this.QueryTime - 1000;
                if (QueryTime == 0)
                {
                    // 受付TABの場合、再照会
                    PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboGwa.GetDataValue(), this.fbxDoctor.GetDataValue(), this.paBox.BunHo);
                    SetPatientListGridFilter();
                    this.timAutoReLoad.Stop();

                    this.timAutoReLoad.Start();

                    this.QueryTime = 30000;
                }
            }
            else
            {
                lbTime.Text = "30";
            }
        }

        private IList<object[]> createListDataForCombo(IList<ComboListItemInfo> lstComboDept)
        {
            IList<object[]> lstData = new List<object[]>();
            if (lstComboDept != null && lstComboDept.Count > 0)
            {
                foreach (ComboListItemInfo comboListItemInfo in lstComboDept)
                {
                    object[] obj = { comboListItemInfo.Code, comboListItemInfo.CodeName };
                    lstData.Add(obj);
                }
            }
            return lstData;
        }

        private InitializeComboListItemResult initializeComboListItem()
        {
            InitializeComboListItemResult result = new InitializeComboListItemResult();
            InitializeComboListItemArgs args = new InitializeComboListItemArgs();
            args.CodeType = "JUBSU_GUBUN";
            args.ComboTimeType = "NUR2001U04_TIMER";

            result = CacheService.Instance.Get<InitializeComboListItemArgs, InitializeComboListItemResult>(args);

            if (result != null)
            {
                cboGwa.SetDictDDLB(createListDataForCombo(result.ComboDepartmentItem));
            }
            return result;
        }

        private void fbxDoctor_FindClick(object sender, CancelEventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("gwa", this.cboGwa.GetDataValue().ToString());
            openParams.Add("word", "");
            openParams.Add("all_gubun", "Y");

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void fbxDoctor_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private List<string> CreateDoctorNameParamList()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_doctor");
            lstParam.Add("f_date");
            return lstParam;
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "OCS0270Q00")
            {
                if (commandParam["gwa"] != null)
                    this.cboGwa.SetDataValue(commandParam["gwa"].ToString());

                //this.dbxDoctor_name.SetEditValue(commandParam["doctor_name"].ToString());
                //this.dbxDoctor_name.AcceptData();

                this.fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                this.fbxDoctor.AcceptData();
            }

            return base.Command(command, commandParam);
        }

        private IList<object[]> GetDoctorNameList(BindVarCollection list)
        {
            List<object[]> doctorNameList = new List<object[]>();

            // set arguments
            NuroNUR2001U04DoctorNameArgs doctorNameArgs = new NuroNUR2001U04DoctorNameArgs();
            doctorNameArgs.DoctorCode = list["f_doctor"].VarValue;
            doctorNameArgs.Date = list["f_date"].VarValue;
            // get results
            NuroNUR2001U04DoctorNameResult result =
                CloudService.Instance.Submit<NuroNUR2001U04DoctorNameResult, NuroNUR2001U04DoctorNameArgs>(
                    doctorNameArgs);

            IList<DataStringListItemInfo> doctorNameListItems = result.DoctorName;
            foreach (DataStringListItemInfo item in doctorNameListItems)
            {
                doctorNameList.Add(new object[]
                {
                    item.DataValue
                });
            }
            return doctorNameList;
        }

        private void fbxDoctor_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                this.dbxDoctor_name.ResetData();
                return;
            }
            this.layDoctorName.ParamList = CreateDoctorNameParamList();
            this.layDoctorName.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDoctorName.SetBindVarValue("f_doctor", e.DataValue);
            this.layDoctorName.SetBindVarValue("f_date", this.dtpNaewonDate.GetDataValue());
            this.layDoctorName.QueryLayout();
            this.dbxDoctor_name.SetDataValue(this.layDoctorName.GetItemValue("doctor_name"));
            if (this.layDoctorName.GetItemValue("doctor_name").ToString() == "")
            {
                e.Cancel = true;
                return;
            }

            //mainScreen.MPostApproveYN = mainScreen.MOrderBiz.getEnablePostApprove("O", this.cboQryDoctor.SelectedValue.ToString());

            //if (mainScreen.MPostApproveYN)
            //    mainScreen.LblApproveFlag.Text = "事後";
            //else
            //    mainScreen.LblApproveFlag.Text = "事前";

            //mainScreen.LblApproveDoctorName.Text = "⇒ " + this.cboQryDoctor.ComboItems[this.cboQryDoctor.SelectedIndex].DisplayItem;

            mainScreen.MPostApproveYN = mainScreen.MOrderBiz.getEnablePostApprove("O", this.fbxDoctor.GetDataValue().ToString());

            if (mainScreen.MPostApproveYN)
                mainScreen.LblApproveFlag.Text = "事後";
            else
                mainScreen.LblApproveFlag.Text = "事前";

            mainScreen.LblApproveDoctorName.Text = "⇒ " + dbxDoctor_name.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(this.paBox.BunHo))
            //{
            //    cboGwa.SelectedIndex = 0;
            //}

            PatientListQuery(this.dtpNaewonDate.GetDataValue(), this.cboGwa.GetDataValue(), this.fbxDoctor.GetDataValue(), this.paBox.BunHo);
            SetPatientListGridFilter();
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
           
        }

        private void paBox_PatientSelectionFailed(object sender, EventArgs e)
        {
            //string a = paBox.BunHo.ToString();
            //MessageBox.Show(a);
        }

        private void paBox_ParentChanged(object sender, EventArgs e)
        {
            //string a = paBox.BunHo.ToString();
            //MessageBox.Show(a);
        }

        private void paBox_Validating(object sender, CancelEventArgs e)
        {
            //string a = paBox.BunHo.t
            //MessageBox.Show(a);
        }

        private void cboGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (int.Parse(cboGwa.SelectedIndex.ToString()) != 0)
            //{
            //    if (int.Parse(cboGwa.GetDataValue().ToString()) != int.Parse(UserInfo.Gwa))
            //    {
            //        fbxDoctor.SetEditValue("");
            //        dbxDoctor_name.SetDataValue("");
            //    }
                
            //}
            this.ChangeUser();
            fbxDoctor.SetEditValue("");
            dbxDoctor_name.SetDataValue("");
            this.PatientListQuery(this.dtpNaewonDate.GetDataValue(), cboGwa.GetDataValue(), this.fbxDoctor.GetDataValue(), paBox.BunHo);
        }

        private void grdPatientList_Click(object sender, EventArgs e)
        {
            int rownumber = grdPatientList.CurrentRowNumber;
            string columname = grdPatientList.CurrentColName;
            DataTable dtPatient = grdPatientList.LayoutTable;
            if (dtPatient != null && dtPatient.Rows.Count > 0 && rownumber >= 0 && !string.IsNullOrEmpty(columname) && columname == "hide_yn")
            {
                if (dtPatient.Rows[rownumber]["hide_yn"].ToString() == "N")
                {
                    //Check count order
                    OCS2015U21GrdPatientCheckOrderArgs args_checkorder = new OCS2015U21GrdPatientCheckOrderArgs();
                    args_checkorder.Fkout1001 = GrdPatientList.GetItemString(GrdPatientList.CurrentRowNumber, "pk_naewon");
                    UpdateResult result_checkorder =
                        CloudService.Instance.Submit<UpdateResult, OCS2015U21GrdPatientCheckOrderArgs>(
                            args_checkorder);

                    if (result_checkorder.Result == true )
                    {
                        XMessageBox.Show(Resources.MSG0036_MSG);
                        return;
                    }



                    //Request update to server         
                    if (XMessageBox.Show(Resources.MSG0034_MSG, Resources.MSG0034_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    //Change doctor

                    OUT1001P01PrOutChangeGwaDoctorArgs args = new OUT1001P01PrOutChangeGwaDoctorArgs();
                    args.Bunho = GrdPatientList.GetItemString(GrdPatientList.CurrentRowNumber, "bunho");
                    args.Pkout1001 = GrdPatientList.GetItemString(GrdPatientList.CurrentRowNumber, "pk_naewon");
                    args.Gwa = UserInfo.Gwa;
                    args.Doctor = UserInfo.DoctorID;
                    args.UserId = UserInfo.UserID;

                    UpdateResult result =
                        CloudService.Instance.Submit<UpdateResult, OUT1001P01PrOutChangeGwaDoctorArgs>(
                            args);

                    if (result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
                    {
                        XMessageBox.Show(Resources.MSG0035_MSG);
                        return;
                    }

                    //Close From and reload 2015U00
                    if (rownumber >= 0)
                    {
                        // 현재 파인드 박스의 환자번호와 선택된 번호가 
                        // 동일한경우는 스킵
                        try
                        {
                            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                            ProcessMouseClick(rownumber);
                        }
                        finally
                        {
                            this.Cursor = System.Windows.Forms.Cursors.Default;
                            //MED-9995 have to close after using, otherwise it will cause exeception
                            this.Dispose(false);
                        }
                    }
                }
            }
        }

        private void CheckSizeColumn()
        {
            if(NetInfo.Language == LangMode.Jr)
            {
                grdPatientList.AutoSizeColumn(1, 60);
                grdPatientList.AutoSizeColumn(2, 65);
                grdPatientList.AutoSizeColumn(3, 110);
                grdPatientList.AutoSizeColumn(5, 50);
                grdPatientList.AutoSizeColumn(6, 50);
                grdPatientList.AutoSizeColumn(7, 110);
                grdPatientList.AutoSizeColumn(8, 39);
                grdPatientList.AutoSizeColumn(9, 69);
                grdPatientList.AutoSizeColumn(10, 80);
                grdPatientList.AutoSizeColumn(11, 39);
                grdPatientList.AutoSizeColumn(12, 39);
                grdPatientList.AutoSizeColumn(13, 39);
                grdPatientList.AutoSizeColumn(14, 80);
                grdPatientList.AutoSizeColumn(15, 90);
                grdPatientList.AutoSizeColumn(16, 70);
            }
        }

    }
}
