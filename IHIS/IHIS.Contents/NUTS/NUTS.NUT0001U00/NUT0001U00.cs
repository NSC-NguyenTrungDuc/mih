#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Nuts;
using IHIS.CloudConnector.Contracts.Models.Nuts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuts;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using System.IO;
using IHIS.NUTS.Properties;

#endregion

namespace IHIS.NUTS
{
    public partial class NUT0001U00 : IHIS.Framework.XScreen
    {
        public NUT0001U00()
        {
            InitializeComponent();
            grdNUT0001.SavePerformer = new XSavePerformer(this);
            grdNUT0002.SavePerformer = grdNUT0001.SavePerformer;
        }

        #region feilds
        private string mInOutGubun;
        private string mGwa;
        private string mOcs_flag;
        private string mFkocs;
        private string mBunho;
        private string mOrder_date; 
        private string mNaewon_key;
        private string mApproveDoctor;

        private string mquery_mode;
        private string mHangmog_code;
        private string mAutoColseYN;
        private string mCaller_screen_id;
        private string mACT_YN;
        private string mHope_date;
        private string mNutritionist;
        private string mNutritionist_name;

        private string mApproveDoctorID = "";
        private string mApproveDoctorGWA = "";

        private string mDoctorID = "";
        private string mDoctorGWA = "";
        private string mDoctorGWANAME = "";

        private NUT0001U00InitializeScreenResult loadScreenResult;
        private string doctorName = "";

        //private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz();

        Hashtable htNUT0001;
        /////////////Popup Menu ////////////////////////////////////////////////////////////////////////////
        private IHIS.X.Magic.Menus.PopupMenu popupOrderMenu = new IHIS.X.Magic.Menus.PopupMenu(); // 처방Grid용
        #endregion
        //private IHIS.OCS.HangmogInfo mHangmogInfo = new IHIS.OCS.HangmogInfo("OCSACT");// OCS 항목정보 그룹 라이브러리 	
        
        /// <summary>
        /// 定数のみ入力可能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ComBoInt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            XComboBox numCombo = sender as XComboBox;

            if (e.KeyChar != (char)8 && !TypeCheck.IsInt(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void InsertInitData()
        {
            //NUT0001_keyGET
            int currRow = this.grdNUT0001.InsertRow(-1);
            /*string cmdText = "SELECT NUT0001_SEQ.NEXTVAL SEQ FROM SYS.DUAL";
            object obj = Service.ExecuteScalar(cmdText);
            //項目名GET
            cmdText = @"SELECT FN_DRG_HANGMOG_NAME( '" + mHangmog_code + @"')
                        FROM SYS.DUAL";
            object hangmog_name = Service.ExecuteScalar(cmdText);*/

            this.grdNUT0001.SetItemValue(currRow, "pknut0001", loadScreenResult.Seq);
            this.grdNUT0001.SetItemValue(currRow, "sys_date", EnvironInfo.GetSysDate());
            this.grdNUT0001.SetItemValue(currRow, "fk_ocs", mFkocs);
            this.grdNUT0001.SetItemValue(currRow, "user_id", UserInfo.UserID);
            this.grdNUT0001.SetItemValue(currRow, "hosp_code", EnvironInfo.HospCode);
            this.grdNUT0001.SetItemValue(currRow, "data_kubun", "I");
            this.grdNUT0001.SetItemValue(currRow, "io_kubun", mInOutGubun);
            this.grdNUT0001.SetItemValue(currRow, "hangmog_code", mHangmog_code);
            this.grdNUT0001.SetItemValue(currRow, "hangmog_name", loadScreenResult.HangmogName);
            this.grdNUT0001.SetItemValue(currRow, "irai_date", mOrder_date);
            this.grdNUT0001.SetItemValue(currRow, "kanja_no", mBunho);
            this.grdNUT0001.SetItemValue(currRow, "sinryouka", this.mDoctorGWA);
            this.grdNUT0001.SetItemValue(currRow, "sindanisi", this.mDoctorID);
            this.grdNUT0001.SetItemValue(currRow, "sport_yn", "N");
            this.grdNUT0001.SetItemValue(currRow, "drink_yn", "N");
            this.grdNUT0001.SetItemValue(currRow, "syokai_gubun", "Y");

        }

        private void NUT0001U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            string cmd = "";
            BindVarCollection bind = new BindVarCollection();

            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("pkocskey"))
                    this.mFkocs = this.OpenParam["pkocskey"].ToString();

                if (this.OpenParam.Contains("in_out_gubun"))
                    this.mInOutGubun = this.OpenParam["in_out_gubun"].ToString();

                if (this.OpenParam.Contains("gwa"))
                    this.mGwa = this.OpenParam["gwa"].ToString();
                else
                    this.mGwa = "";

                if (this.OpenParam.Contains("bunho"))
                {
                    this.mBunho = this.OpenParam["bunho"].ToString();
                    this.patBox.SetPatientID(this.mBunho);
                }

                if (this.OpenParam.Contains("approve_doctor"))
                {
                    if (UserInfo.Gwa == "CK")
                    {
                        this.mApproveDoctorGWA = this.OpenParam["approve_doctor"].ToString().Substring(0, 2);
                        this.mApproveDoctorID = this.OpenParam["approve_doctor"].ToString().Substring(2);
                    }
                }

//                if (this.OpenParam.Contains("naewon_key"))
//                {
//                    this.mNaewon_key = this.OpenParam["naewon_key"].ToString();

//                    if (UserInfo.Gwa == "CK")
//                    {
//                        bind = new BindVarCollection();
//                        cmd = @"SELECT FN_OCS_GET_DOCTORIDBYNAEWONKEY(:f_hosp_code, :f_io_gubun, :f_naewon_key) DOCTORID
//                                     , FN_OCS_GETDOCTORGWABYNAEWONKEY(:f_hosp_code, :f_io_gubun, :f_naewon_key) DOCTORGWA
//                                  FROM SYS.DUAL";
                        
//                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bind.Add("f_io_gubun", this.mInOutGubun);
//                        bind.Add("f_naewon_key", this.mNaewon_key);

//                        DataTable dt = Service.ExecuteDataTable(cmd, bind);

//                        if (dt != null && dt.Rows.Count > 0)
//                        {
//                            mApproveDoctorID  = dt.Rows[0]["doctorid"].ToString();
//                            mApproveDoctorGWA = dt.Rows[0]["doctorgwa"].ToString();
//                        }
//                    }
//                }

                if (this.OpenParam.Contains("order_date"))
                    this.mOrder_date = this.OpenParam["order_date"].ToString();

                if (this.OpenParam.Contains("query_mode"))
                    this.mquery_mode = this.OpenParam["query_mode"].ToString();

                if (this.OpenParam.Contains("hangmog_code"))
                    this.mHangmog_code = this.OpenParam["hangmog_code"].ToString();

                if (this.OpenParam.Contains("caller_screen_id"))
                    this.mCaller_screen_id = this.OpenParam["caller_screen_id"].ToString();
                
                if (this.OpenParam.Contains("act_yn"))
                    this.mACT_YN = this.OpenParam["act_yn"].ToString();

                if(this.OpenParam.Contains("ocs_flag"))
                    this.mOcs_flag = this.OpenParam["ocs_flag"].ToString();

                if (this.OpenParam.Contains("nutritionist"))
                    this.mNutritionist = this.OpenParam["nutritionist"].ToString();
                
                if (this.OpenParam.Contains("nutritionist_name"))
                    this.mNutritionist_name = this.OpenParam["nutritionist_name"].ToString();

                if (this.OpenParam.Contains("hope_date") && this.OpenParam["hope_date"].ToString() != "")
                {
                    this.mHope_date = this.OpenParam["hope_date"].ToString();
                    this.dptReserDate.SetDataValue(this.mHope_date.ToString());
                }
                else
                    this.dptReserDate.SetDataValue(EnvironInfo.GetSysDate().ToString());


                // 自動出力用
                if (this.OpenParam.Contains("AutoCloseYN"))
                    this.mAutoColseYN = this.OpenParam["AutoCloseYN"].ToString();


                if (this.OpenParam.Contains("doctor"))
                    this.mDoctorID = this.OpenParam["doctor"].ToString();

                if (this.OpenParam.Contains("doctor_gwa"))
                    this.mDoctorGWA = this.OpenParam["doctor_gwa"].ToString();

                cmd = "";
                bind = new BindVarCollection();

                if (this.mDoctorID == "" || this.mDoctorGWA == "")
                {
                    if (UserInfo.UserGubun == UserType.Doctor)
                    {
                        this.mDoctorID = UserInfo.DoctorID;
                        this.mDoctorGWA = UserInfo.Gwa;
                        this.mDoctorGWANAME = UserInfo.GwaName;
                    }
                    else if (UserInfo.Gwa == "CK")
                    {
                        this.mDoctorID = this.mApproveDoctorID;
                        this.mDoctorGWA = this.mApproveDoctorGWA;
                    }
                    else
                    {
                        /*if (this.mInOutGubun == "O")
                        {
                            cmd = @"SELECT A.DOCTOR  DOCTOR
                                         , A.GWA     GWA
                                      FROM OCS1003 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.PKOCS1003 = :f_pkocskey
                                    ";
                        }
                        else
                        {
                            cmd = @"SELECT A.INPUT_DOCTOR DOCTOR
                                         , A.INPUT_GWA    GWA
                                      FROM OCS2003 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND A.PKOCS2003 = :f_pkocskey
                                    ";
                        }

                        bind.Add("f_hosp_code", EnvironInfo.HospCode);
                        bind.Add("f_pkocskey", this.mFkocs);

                        DataTable dt = Service.ExecuteDataTable(cmd, bind);

                        if (dt.Rows.Count > 0)
                        {
                            this.mDoctorID = dt.Rows[0]["doctor"].ToString();
                            this.mDoctorGWA = dt.Rows[0]["gwa"].ToString();
                        }*/
                        NUT0001U00LoadDoctorGwaArgs args = new NUT0001U00LoadDoctorGwaArgs();
                        args.InOutGubun = this.mInOutGubun;
                        args.Pkocskey = this.mFkocs;
                        NUT0001U00LoadDoctorGwaResult result =
                            CloudService.Instance.Submit<NUT0001U00LoadDoctorGwaResult, NUT0001U00LoadDoctorGwaArgs>(
                                args);
                        if (result.ExecutionStatus == ExecutionStatus.Success && result.DoctorGwaInfo.Count > 0)
                        {
                            this.mDoctorID = result.DoctorGwaInfo[0].Code;
                            this.mDoctorGWA = result.DoctorGwaInfo[0].CodeName;
                        }
                    }
                }

                loadScreenResult = this.GetScreenResult();

                if (this.mDoctorGWANAME == "")
                {
                    /*string cmd_gwaname = "";
                    BindVarCollection bind_gwaname = new BindVarCollection();

                    cmd_gwaname = @"SELECT FN_BAS_LOAD_GWA_NAME(:f_gwa_code, SYSDATE)
                                          FROM SYS.DUAL";
                    bind_gwaname.Add("f_gwa_code", this.mDoctorGWA);

                    object obj = Service.ExecuteScalar(cmd_gwaname, bind_gwaname);

                    if (obj != null)
                    {
                        this.mDoctorGWANAME = obj.ToString();
                    }*/
                    String result = loadScreenResult.GwaName;
                    if (result != "")
                    {
                        this.mDoctorGWANAME = result;
                    }
                }
            }
            //this.mHangmogInfo = new IHIS.OCS.HangmogInfo(TypeCheck.NVL(this.mCaller_screen_id, this.Name).ToString());        // OCS 항목정보 그룹 라이브러리
            this.grdNUT0001.ExecuteQuery = LoadGrdNUT0001;
            this.grdNUT0001.QueryLayout(false);
            
            if (this.mCaller_screen_id == "OCSACT")
            {
                int currRow = this.grdNUT0001.CurrentRowNumber;
                this.grdNUT0001.SetItemValue(currRow, "nutritionist", mNutritionist);
                this.grdNUT0001.SetItemValue(currRow, "nutritionist_name", mNutritionist_name);

                if(this.grdNUT0001.GetItemString(currRow, "acting_date") == "")
                    this.grdNUT0001.SetItemValue(currRow, "acting_date", loadScreenResult.SysDate);
                if (this.grdNUT0001.GetItemString(currRow, "nutritionist_name") == "")
                    this.grdNUT0001.SetItemValue(currRow, "nutritionist_name", UserInfo.UserName.ToString());
                if (this.grdNUT0001.GetItemString(currRow, "nutritionist") == "")
                    this.grdNUT0001.SetItemValue(currRow, "nutritionist", UserInfo.UserID.ToString());
                
            }

            if (this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "sport_yn") == "Y")
                this.rbtSport_y.Checked = true;
            else
                this.rbtSport_n.Checked = true;

            if (this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "drink_yn") == "Y")
                this.rbtDrink_y.Checked = true;
            else
                this.rbtDrink_n.Checked = true;

            if (this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "syokai_gubun") == "Y")
                this.rbtSyokai.Checked = true;
            else if (this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "syokai_gubun") == "N")
                this.rbtSaikai.Checked = true;


            if (this.grdNUT0001.RowCount < 1)
                this.InsertInitData();
            else
            {
                this.grdNUT0002.ParamList = CreateGrdNUT0002ParamList();
                this.grdNUT0002.ExecuteQuery = LoadGrdNUT0002;
                this.grdNUT0002.QueryLayout(false);
            }
            this.InitScreen();

            if (this.mAutoColseYN == "Y")
                this.btnList.PerformClick(FunctionType.Print);
        }
        public bool IsPossibleInsteadOrder(string aPKKEY, string aINPUT_GUBUN, string aIO_GUBUN)
        {
            /*string cmd = "";
            BindVarCollection bind = new BindVarCollection();

            cmd = @"SELECT FN_OCS_INSTEAD_MODIFIED_CHECK(:f_hosp_code, :f_pkocskey, 'CK', :f_io_gubun) FROM SYS.DUAL";
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_pkocskey", aPKKEY);
            bind.Add("f_input_gubun", aINPUT_GUBUN);
            bind.Add("f_io_gubun", aIO_GUBUN);

            object obj = Service.ExecuteScalar(cmd, bind);

            if (obj != null)
            {
                if (obj.ToString() == "1")
                    return true;
                else
                    return false;
            }

            return false;*/
            return loadScreenResult.IsPossibleInsteadOrder;
        }

        private void InitScreen()
        {
            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            popupOrderMenu.MenuCommands.Clear();
            popupOrderMenu.MenuCommands.Add(new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG_001, (Image)this.imageListPopupMenu.Images[4],
                new EventHandler(PopUpMenuDelete_Click)));

            lblGwa.Text = this.mDoctorGWANAME;

            if (UserInfo.Gwa == "CK" && this.IsPossibleInsteadOrder(this.mFkocs, "CK", this.mInOutGubun) == false)
            {
                this.pnlByoumei.Enabled = false;
                this.pnlCenter.Enabled = false;
                this.pnlBottom.Enabled = false;
            }
            else
            {
                // 実績画面から呼び出された際には画面全体を修正不可とする。
                if (this.mCaller_screen_id == "OCSACT" || this.mCaller_screen_id == "OCSAPPROVE")
                {
                    this.pnlByoumei.Enabled = false;
                    this.pnlCenter.Enabled = false;

                    this.pnlBottom.Enabled = true;

                    //if (this.mACT_YN != "Y")
                    //    this.pnlBottom.Enabled = true;
                }
                else
                {
                    switch (this.mOcs_flag)
                    {
                        case "1": // 通常
                            this.pnlByoumei.Enabled = true;
                            this.pnlCenter.Enabled = true;
                            this.pnlBottom.Enabled = false;
                            break;
                        case "2": // 予約、受付
                            this.pnlByoumei.Enabled = true;
                            this.pnlCenter.Enabled = true;
                            this.pnlBottom.Enabled = false;
                            break;
                        case "3": // 実施
                            this.pnlByoumei.Enabled = false;
                            this.pnlCenter.Enabled = false;
                            this.pnlBottom.Enabled = false;
                            break;
                        case "4": // 会計
                            this.pnlByoumei.Enabled = false;
                            this.pnlCenter.Enabled = false;
                            this.pnlBottom.Enabled = false;
                            break;

                    }
                }
            }

            if (this.mCaller_screen_id == "OCSAPPROVE")
            {
                this.btnList.FunctionItems.Clear();
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Process, Shortcut.None, Resources.BTN_PROCESS_TEXT, -1, ""));
                //this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Update, Shortcut.None, "保存", -1, "OliveGreen"));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Print, Shortcut.None, Resources.BTN_PRINT_TEXT, -1, ""));
                this.btnList.FunctionItems.Add(new CustomFunctionItem(FunctionType.Close, Shortcut.None, Resources.BTN_CLOSE_TEXT, -1, "OliveGreen"));

                this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                //this.btnList.Location = new Point(this.Parent.Width - 460, this.Parent.Height - 35);
                this.btnList.InitializeButtons();
                this.btnList.Refresh();
            }
        }
        // 처방행삭제
        private void PopUpMenuDelete_Click(object sender, System.EventArgs e)
        {
            if (this.btnList.Enabled)
            {
                this.grdNUT0002.DeleteRow(this.grdNUT0002.CurrentRowNumber);
                this.grdNUT0002.UnSelectAll();
            }
        }

        private void grdNUT0001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUT0001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUT0001.SetBindVarValue("f_pkocskey", mFkocs);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    /*this.grdNUT0002.SaveLayout();
                    this.grdNUT0001.SaveLayout();*/
                    NUT0001U00SaveLayoutArgs saveLayoutArgs = new NUT0001U00SaveLayoutArgs();
                    saveLayoutArgs.Grd001ItemInfo = GetGrd0001DataForSaveLayout();
                    saveLayoutArgs.Grd002ItemInfo = GetGrd0002DataForSaveLayout();
                    UpdateResult saveLayoutResult =
                        CloudService.Instance.Submit<UpdateResult, NUT0001U00SaveLayoutArgs>(saveLayoutArgs);

                    InvokeReturnSendReturnDataTable();
                    Close();
                    break;
                case FunctionType.Print:

                    if (this.mCaller_screen_id == "OCSACT")
                    {
                        this.CreateIraisyo();
                        this.CreateIraisyo_answer();
                    }
                    else
                        this.CreateIraisyo();

                    break;
                case FunctionType.Close:

                    break;

                case FunctionType.Process:
                    e.IsBaseCall = false;

                    this.CreateIraisyoEMR();
                    this.CreateIraisyo_answerEMR();

                    string FKNaewon_key = "";
                    /*string cmd = @"SELECT A.FKOUT1001
                                     FROM OCS1003 A
                                    WHERE :f_io_kubun = 'O'
                                      AND A.HOSP_CODE = :f_hosp_code
                                      AND A.PKOCS1003 = :f_pkocs
                                    UNION
                                   SELECT A.FKINP1001
                                     FROM OCS2003 A
                                    WHERE :f_io_kubun = 'I'
                                      AND A.HOSP_CODE = :f_hosp_code
                                      AND A.PKOCS2003 = :f_pkocs
                                ";
                    BindVarCollection bind = new BindVarCollection();
                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    bind.Add("f_pkocs", this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "fk_ocs"));
                    bind.Add("f_io_kubun", this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "io_kubun"));

                    object obj = Service.ExecuteScalar(cmd, bind);

                    if(obj != null)
                        FKNaewon_key = obj.ToString();*/
                    NUT0001U00GetNaewonKeyArgs args = new NUT0001U00GetNaewonKeyArgs();
                    args.Pkocs = this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "fk_ocs");
                    args.IoKubun = grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "io_kubun");
                    NUT0001U00GetNaewonKeyResult result =
                        CloudService.Instance.Submit<NUT0001U00GetNaewonKeyResult, NUT0001U00GetNaewonKeyArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        FKNaewon_key = result.Result;
                    }

                    switch(this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "io_kubun"))
                    {
                        case "I":
                            if (   EMRHelper.EMRPrint(dwIraisyo
                                                    , EMRIOTGubun.IN
                                                    , this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "kanja_no")
                                                    , EnvironInfo.GetSysDate().ToShortDateString()
                                                    , ""
                                                    , this.Name
                                                    , FKNaewon_key
                                                   )
                                && EMRHelper.EMRPrint(dwAnswer
                                                    , EMRIOTGubun.IN
                                                    , this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "kanja_no")
                                                    , EnvironInfo.GetSysDate().ToShortDateString()
                                                    , ""
                                                    , this.Name
                                                    , FKNaewon_key
                                                   )
                                )
                                XMessageBox.Show(Resources.MSG_002);
                            else
                                XMessageBox.Show(Resources.MSG_003);
                            break;

                        case "O":
                            if (   EMRHelper.EMRPrint(dwIraisyo
                                                    , EMRIOTGubun.OUT
                                                    , this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "kanja_no")
                                                    , EnvironInfo.GetSysDate().ToShortDateString()
                                                    , FKNaewon_key
                                                    , this.Name
                                                    , ""
                                                   )
                                && EMRHelper.EMRPrint(dwAnswer
                                                    , EMRIOTGubun.OUT
                                                    , this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "kanja_no")
                                                    , EnvironInfo.GetSysDate().ToShortDateString()
                                                    , FKNaewon_key
                                                    , this.Name
                                                    , ""
                                                   )
                                )
                                XMessageBox.Show(Resources.MSG_002);
                            else
                                XMessageBox.Show(Resources.MSG_003);
                            break;

                        default:
                            if (   EMRHelper.EMRPrint(dwIraisyo
                                                    , EMRIOTGubun.COM
                                                    , this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "kanja_no")
                                                    , EnvironInfo.GetSysDate().ToShortDateString()
                                                    , FKNaewon_key
                                                    , this.Name
                                                    , ""
                                                   )
                                )
                                XMessageBox.Show(Resources.MSG_002);
                            else
                                XMessageBox.Show(Resources.MSG_003);
                            break;
                    }
                    break;
            }
        }

        private void CreateIraisyo_answer()
        {
            //if (this.grdNUT0001.GetRowState(this.grdNUT0001.CurrentRowNumber) == DataRowState.Unchanged)
            //{
                this.dwAnswer.Reset();
                this.layIraisyo.Reset();
                int currRow = layIraisyo.InsertRow(-1);
                //患者データ
                layIraisyo.LayoutTable.Rows[currRow]["kanji_name"] = patBox.SuName;
                layIraisyo.LayoutTable.Rows[currRow]["kana_name"] = patBox.SuName2;
                layIraisyo.LayoutTable.Rows[currRow]["birth_date"] = patBox.Birth;
                layIraisyo.LayoutTable.Rows[currRow]["age"] = patBox.YearAge;

                if (patBox.Sex == "M")
                    layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.MALE_TEXT;
                else
                    layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.FEMALE_TEXT;

                //依頼データ
                foreach (DataColumn cl in grdNUT0001.LayoutTable.Columns)
                {
                    if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = grdNUT0001.GetItemString(0, cl.ColumnName);
                    }

                    if (cl.ColumnName == "reser_date" && this.grdNUT0001.GetItemString(0, "reser_date") != "")
                    {
                        layIraisyo.LayoutTable.Rows[currRow]["reser_date"] = DateTime.Parse(this.grdNUT0001.GetItemString(0, "reser_date")).ToString("yyyy/MM/dd");
                    }
                }

                //傷病データ
                for (int i = 0; i < this.grdNUT0002.RowCount; i++)
                {
                    foreach (DataColumn cl in grdNUT0002.LayoutTable.Columns)
                    {
                        if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi" || cl.ColumnName == "display_syoubyoumei")
                        {
                            if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName + (i + 1).ToString()))
                            {
                                if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi")
                                {
                                    string date = grdNUT0002.GetItemString(i, cl.ColumnName);
                                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6);
                                }
                                else
                                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = grdNUT0002.GetItemString(i, cl.ColumnName);
                            }
                        }
                    }
                }
            //}
            dwAnswer.FillData(this.layIraisyo.LayoutTable);
            dwAnswer.Print();
        }

        

        private void CreateIraisyo()
        {
            NUT0001U00LoadDoctorNameArgs args = new NUT0001U00LoadDoctorNameArgs();
            args.Param = grdNUT0001.GetItemString(0, "sindanisi");
            NUT0001U00LoadDoctorNameResult result =
                CloudService.Instance.Submit<NUT0001U00LoadDoctorNameResult, NUT0001U00LoadDoctorNameArgs>(args);

            this.layIraisyo.Reset();
            this.dwIraisyo.Reset();

            //if (this.grdNUT0001.GetRowState(this.grdNUT0001.CurrentRowNumber) == DataRowState.Unchanged)
            //{
                int currRow = layIraisyo.InsertRow(-1);
                //患者データ
                layIraisyo.LayoutTable.Rows[currRow]["kanji_name"] = patBox.SuName;
                layIraisyo.LayoutTable.Rows[currRow]["kana_name"] = patBox.SuName2;
                layIraisyo.LayoutTable.Rows[currRow]["birth_date"] = patBox.Birth;
                layIraisyo.LayoutTable.Rows[currRow]["age"] = patBox.YearAge;

                if (patBox.Sex == "M")
                    layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.MALE_TEXT;
                else
                    layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.FEMALE_TEXT;

                //依頼データ
                foreach (DataColumn cl in grdNUT0001.LayoutTable.Columns)
                {
                    if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = grdNUT0001.GetItemString(0, cl.ColumnName);
                    }

                    if (cl.ColumnName == "sindanisi")
                    {
                        /*string cmd = @"SELECT FN_BAS_LOAD_DOCTOR_NAME('" + grdNUT0001.GetItemString(0, cl.ColumnName) + "', SYSDATE) FROM DUAL";
                        object obj = Service.ExecuteScalar(cmd);
                        if(obj != null)
                            layIraisyo.LayoutTable.Rows[currRow]["sindanisi"] = obj.ToString();*/
                        if (result.ExecutionStatus == ExecutionStatus.Success)
                        {
                            layIraisyo.LayoutTable.Rows[currRow]["sindanisi"] = result.Result;
                        }
                    }
                    if (cl.ColumnName == "io_kubun")
                    {
                        if (this.grdNUT0001.GetItemString(0, "io_kubun") == "O")
                            layIraisyo.LayoutTable.Rows[currRow]["io_kubun"] = Resources.IO_KUBUN_TEXT_1;
                        else
                            layIraisyo.LayoutTable.Rows[currRow]["io_kubun"] = Resources.IO_KUBUN_TEXT_2;
                    }
                    if (cl.ColumnName == "reser_date" && this.grdNUT0001.GetItemString(0, "reser_date") != "")
                    {
                        layIraisyo.LayoutTable.Rows[currRow]["reser_date"] = DateTime.Parse(this.grdNUT0001.GetItemString(0, "reser_date")).ToString("yyyy/MM/dd");
                    }
                    if (cl.ColumnName == "syokai_gubun")
                    {
                        if(this.grdNUT0001.GetItemString(0, "syokai_gubun") == "Y")
                            layIraisyo.LayoutTable.Rows[currRow]["syokai_gubun"] = Resources.SYOKAI_GUBUN_TEXT_1;
                        else
                            layIraisyo.LayoutTable.Rows[currRow]["syokai_gubun"] = Resources.SYOKAI_GUBUN_TEXT_2;
                    }
                }

                //傷病データ
                for (int i = 0; i < this.grdNUT0002.RowCount; i++)
                {
                    foreach (DataColumn cl in grdNUT0002.LayoutTable.Columns)
                    {
                        if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi" || cl.ColumnName == "display_syoubyoumei")
                        {
                            if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName + (i + 1).ToString()))
                            {
                                if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi")
                                {
                                    string date = grdNUT0002.GetItemString(i, cl.ColumnName);
                                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6);
                                }
                                else
                                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = grdNUT0002.GetItemString(i, cl.ColumnName);
                            }
                        }
                    }
                }
            //}
            dwIraisyo.FillData(this.layIraisyo.LayoutTable);
            dwIraisyo.Print();
        
        }

        private void CreateIraisyo_answerEMR()
        {
            //if (this.grdNUT0001.GetRowState(this.grdNUT0001.CurrentRowNumber) == DataRowState.Unchanged)
            //{
            this.dwAnswer.Reset();
            this.layIraisyo.Reset();
            int currRow = layIraisyo.InsertRow(-1);
            //患者データ
            layIraisyo.LayoutTable.Rows[currRow]["kanji_name"] = patBox.SuName;
            layIraisyo.LayoutTable.Rows[currRow]["kana_name"] = patBox.SuName2;
            layIraisyo.LayoutTable.Rows[currRow]["birth_date"] = patBox.Birth;
            layIraisyo.LayoutTable.Rows[currRow]["age"] = patBox.YearAge;

            if (patBox.Sex == "M")
                layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.MALE_TEXT;
            else
                layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.FEMALE_TEXT;

            //依頼データ
            foreach (DataColumn cl in grdNUT0001.LayoutTable.Columns)
            {
                if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName))
                {
                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = grdNUT0001.GetItemString(0, cl.ColumnName);
                }

                if (cl.ColumnName == "reser_date" && this.grdNUT0001.GetItemString(0, "reser_date") != "")
                {
                    layIraisyo.LayoutTable.Rows[currRow]["reser_date"] = DateTime.Parse(this.grdNUT0001.GetItemString(0, "reser_date")).ToString("yyyy/MM/dd");
                }
            }

            //傷病データ
            for (int i = 0; i < this.grdNUT0002.RowCount; i++)
            {
                foreach (DataColumn cl in grdNUT0002.LayoutTable.Columns)
                {
                    if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi" || cl.ColumnName == "display_syoubyoumei")
                    {
                        if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName + (i + 1).ToString()))
                        {
                            if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi")
                            {
                                string date = grdNUT0002.GetItemString(i, cl.ColumnName);
                                layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6);
                            }
                            else
                                layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = grdNUT0002.GetItemString(i, cl.ColumnName);
                        }
                    }
                }
            }
            //}
            dwAnswer.FillData(this.layIraisyo.LayoutTable);
            //dwAnswer.Print();
        }

        private void CreateIraisyoEMR()
        {
            NUT0001U00LoadDoctorNameArgs args = new NUT0001U00LoadDoctorNameArgs();
            args.Param = grdNUT0001.GetItemString(0, "sindanisi");
            NUT0001U00LoadDoctorNameResult result =
                CloudService.Instance.Submit<NUT0001U00LoadDoctorNameResult, NUT0001U00LoadDoctorNameArgs>(args);

            this.layIraisyo.Reset();
            this.dwIraisyo.Reset();

            //if (this.grdNUT0001.GetRowState(this.grdNUT0001.CurrentRowNumber) == DataRowState.Unchanged)
            //{
            int currRow = layIraisyo.InsertRow(-1);
            //患者データ
            layIraisyo.LayoutTable.Rows[currRow]["kanji_name"] = patBox.SuName;
            layIraisyo.LayoutTable.Rows[currRow]["kana_name"] = patBox.SuName2;
            layIraisyo.LayoutTable.Rows[currRow]["birth_date"] = patBox.Birth;
            layIraisyo.LayoutTable.Rows[currRow]["age"] = patBox.YearAge;

            if (patBox.Sex == "M")
                layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.MALE_TEXT;
            else
                layIraisyo.LayoutTable.Rows[currRow]["sex"] = Resources.FEMALE_TEXT;

            //依頼データ
            foreach (DataColumn cl in grdNUT0001.LayoutTable.Columns)
            {
                if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName))
                {
                    layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName] = grdNUT0001.GetItemString(0, cl.ColumnName);
                }

                if (cl.ColumnName == "sindanisi")
                {
                    /*string cmd = @"SELECT FN_BAS_LOAD_DOCTOR_NAME('" + grdNUT0001.GetItemString(0, cl.ColumnName) + "', SYSDATE) FROM DUAL";
                    object obj = Service.ExecuteScalar(cmd);
                    if (obj != null)
                        layIraisyo.LayoutTable.Rows[currRow]["sindanisi"] = obj.ToString();*/
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        layIraisyo.LayoutTable.Rows[currRow]["sindanisi"] = result.Result;
                    }
                }
                if (cl.ColumnName == "io_kubun")
                {
                    if (this.grdNUT0001.GetItemString(0, "io_kubun") == "O")
                        layIraisyo.LayoutTable.Rows[currRow]["io_kubun"] = Resources.IO_KUBUN_TEXT_1;
                    else
                        layIraisyo.LayoutTable.Rows[currRow]["io_kubun"] = Resources.IO_KUBUN_TEXT_2;
                }
                if (cl.ColumnName == "reser_date" && this.grdNUT0001.GetItemString(0, "reser_date") != "")
                {
                    layIraisyo.LayoutTable.Rows[currRow]["reser_date"] = DateTime.Parse(this.grdNUT0001.GetItemString(0, "reser_date")).ToString("yyyy/MM/dd");
                }
                if (cl.ColumnName == "syokai_gubun")
                {
                    if (this.grdNUT0001.GetItemString(0, "syokai_gubun") == "Y")
                        layIraisyo.LayoutTable.Rows[currRow]["syokai_gubun"] = Resources.SYOKAI_GUBUN_TEXT_1;
                    else
                        layIraisyo.LayoutTable.Rows[currRow]["syokai_gubun"] = Resources.SYOKAI_GUBUN_TEXT_2;
                }
            }

            //傷病データ
            for (int i = 0; i < this.grdNUT0002.RowCount; i++)
            {
                foreach (DataColumn cl in grdNUT0002.LayoutTable.Columns)
                {
                    if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi" || cl.ColumnName == "display_syoubyoumei")
                    {
                        if (layIraisyo.LayoutTable.Columns.Contains(cl.ColumnName + (i + 1).ToString()))
                        {
                            if (cl.ColumnName == "hassyoubi" || cl.ColumnName == "sindanbi")
                            {
                                string date = grdNUT0002.GetItemString(i, cl.ColumnName);
                                layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6);
                            }
                            else
                                layIraisyo.LayoutTable.Rows[currRow][cl.ColumnName + (i + 1).ToString()] = grdNUT0002.GetItemString(i, cl.ColumnName);
                        }
                    }
                }
            }
            //}
            dwIraisyo.FillData(this.layIraisyo.LayoutTable);
            //dwIraisyo.Print();

        }

        private void InvokeReturnSendReturnDataTable()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("NUT0001U00", "changed");
            param.Add("reserDate", this.dptReserDate.GetDataValue());

            ((IXScreen)this.Opener).Command(this.Name, param);
        }

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUT0001U00 parent = null;

            public XSavePerformer(NUT0001U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                string t_chk = "";

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @" INSERT INTO NUT0001(   SYS_DATE,
                                                                    USER_ID,
                                                                    UPD_DATE,
                                                                    HOSP_CODE,
                                                                    PKNUT0001,
                                                                    DATA_KUBUN,
                                                                    FK_OCS,
                                                                    IO_KUBUN,
                                                                    HANGMOG_CODE,
                                                                    HANGMOG_NAME,
                                                                    IRAI_DATE,
                                                                    
                                                                    KANJA_NO,
                                                                    SINRYOUKA,
                                                                    SINDANISI,
                                                                    BMI,
                                                                    SIJIJIKOU,
                                                                    TARGETWEIGHT,
                                                                    SPORT_YN,
                                                                    DRINK_YN,
                                                                    ENERGY,
                                                                    PROTEIN,
                                                                    FAT,
                                                                    PS,
                                                                    SUGAR,
                                                                    SALT,
                                                                    WATER,
                                                                    BP,
                                                                    FBS,
                                                                    A1C,
                                                                    TCH,
                                                                    TG,
                                                                    HDL,
                                                                    LDL,
                                                                    HB,
                                                                    ALB,
                                                                    BUN,
                                                                    CRE,
                                                                    AST_GOT,
                                                                    ALT_GPT,
                                                                    GAMMAGT,
                                                                    HEIGHT,
                                                                    WEIGHT,
                                                                    SYOKAI_GUBUN
                                                                    )
                                             VALUES(SYSDATE,
                                                    :f_user_id,
                                                    SYSDATE,
                                                    :f_hosp_code,
                                                    :f_pknut0001,
                                                    :f_data_kubun,
                                                    :f_fk_ocs,
                                                    :f_io_kubun,
                                                    :f_hangmog_code,
                                                    :f_hangmog_name,
                                                    :f_irai_date,
                                                    
                                                    :f_kanja_no,
                                                    :f_sinryouka,
                                                    :f_sindanisi,
                                                    :f_bmi,
                                                    :f_sijijikou,
                                                    :f_targetweight,
                                                    :f_sport_yn,
                                                    :f_drink_yn,
                                                    :f_energy,
                                                    :f_protein,
                                                    :f_fat,
                                                    :f_ps,
                                                    :f_sugar,
                                                    :f_salt,
                                                    :f_water,
                                                    :f_bp,
                                                    :f_fbs,
                                                    :f_a1c,
                                                    :f_tch,
                                                    :f_tg,
                                                    :f_hdl,
                                                    :f_ldl,
                                                    :f_hb,
                                                    :f_alb,
                                                    :f_bun,
                                                    :f_cre,
                                                    :f_ast_got,
                                                    :f_alt_gpt,
                                                    :f_gammagt,
                                                    :f_height,
                                                    :f_weight,
                                                    :f_syokai_gubun
                                                    )";

                                break;
                            case DataRowState.Modified:
                                cmdText = @" UPDATE NUT0001
                                                SET UPD_DATE            = :f_upd_date,
                                                    IRAI_DATE           = :f_irai_date,
                                                    
                                                    BMI                 = :f_bmi,
                                                    SIJIJIKOU           = :f_sijijikou,
                                                    TARGETWEIGHT        = :f_targetweight,
                                                    SPORT_YN            = :f_sport_yn,
                                                    DRINK_YN            = :f_drink_yn,
                                                    ENERGY              = :f_energy,
                                                    PROTEIN             = :f_protein,
                                                    FAT                 = :f_fat,
                                                    PS                  = :f_ps,
                                                    SUGAR               = :f_sugar,
                                                    SALT                = :f_salt,
                                                    WATER               = :f_water,
                                                    BP                  = :f_bp,
                                                    FBS                 = :f_fbs,
                                                    A1C                 = :f_a1c,
                                                    TCH                 = :f_tch,
                                                    TG                  = :f_tg,
                                                    HDL                 = :f_hdl,
                                                    LDL                 = :f_ldl,
                                                    HB                  = :f_hb,
                                                    ALB                 = :f_alb,
                                                    BUN                 = :f_bun,
                                                    CRE                 = :f_cre,
                                                    AST_GOT             = :f_ast_got,
                                                    ALT_GPT             = :f_alt_gpt,
                                                    GAMMAGT             = :f_gammagt,
                                                    NUTRITIONIST        = :f_nutritionist,
                                                    NUTRITIONIST_NAME   = :f_nutritionist_name,
                                                    NUTRITION_OBJECT    = :f_nutrition_object,
                                                    ACTING_DATE         = :f_acting_date,
                                                    REMARK              = :f_remark,
                                                    HEIGHT              = :f_height,
                                                    WEIGHT              = :f_weight,
                                                    SYOKAI_GUBUN        = :f_syokai_gubun
                                              WHERE HOSP_CODE   = :f_hosp_code
                                                AND PKNUT0001      = :f_pknut0001";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUT0001
                                             WHERE PKNUT0001      = :f_pknut0001";
                                break;
                        }
                        break;
                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                
                                string NUT0002_SEQ = @"SELECT NUT0002_SEQ.NEXTVAL FROM SYS.DUAL";
                                object pk_chk = Service.ExecuteScalar(NUT0002_SEQ);
                                item.BindVarList.Add("f_pknut0002", pk_chk.ToString());

                                cmdText = @"   INSERT INTO NUT0002
                                               VALUES (SYSDATE
                                                    , :f_user_id
                                                    , SYSDATE
                                                    , :f_hosp_code
                                                    , :f_pknut0002
                                                    , :f_data_kubun
                                                    , :f_fknut0001
                                                    , :f_fkoutsang
                                                    , :f_io_kubun   )";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUT0002 A
                                             WHERE A.HOSP_CODE = :f_hosp_code 
                                               AND A.PKNUT0002 = :f_pknut0002";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        private void btnSindanmei_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mBunho);
            openParams.Add("gwa", mGwa);
            openParams.Add("io_gubun", mInOutGubun);
            openParams.Add("nut0002", this.grdNUT0002.LayoutTable);

            //사용자조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OUTS", "OUTSANGQ00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "OUTSANGQ00":
                    if (commandParam.Contains("OUTSANG") && (MultiLayout)commandParam["OUTSANG"] != null &&
                        ((MultiLayout)commandParam["OUTSANG"]).RowCount > 0)
                    {
                        string sang_name = "";
                        

                        for (int i = 0; i < ((MultiLayout)commandParam["OUTSANG"]).RowCount; i++)
                        {
                            if (TypeCheck.IsNull(sang_name))
                                sang_name = sang_name + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name");
                            else
                                sang_name = sang_name + "\r\n" + ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name");
                        }

                        for (int i = 0; i < ((MultiLayout)commandParam["OUTSANG"]).RowCount; i++)
                        {
                            if (dupSangChk(((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "pkoutsang")))
                                continue;

                            this.grdNUT0002.InsertRow(-1);
                            int currRow = this.grdNUT0002.CurrentRowNumber;
                            this.grdNUT0002.SetItemValue(currRow, "syoubyoumei_code", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_code"));
                            this.grdNUT0002.SetItemValue(currRow, "sang_start_date", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_start_date"));
                            this.grdNUT0002.SetItemValue(currRow, "sang_jindan_date", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_jindan_date"));
                            this.grdNUT0002.SetItemValue(currRow, "display_syoubyoumei", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "display_sang_name"));
                            this.grdNUT0002.SetItemValue(currRow, "syoubyoumei", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "sang_name"));
                            this.grdNUT0002.SetItemValue(currRow, "hosp_code", EnvironInfo.HospCode);
                            this.grdNUT0002.SetItemValue(currRow, "sys_date", EnvironInfo.GetSysDateTime());
                            this.grdNUT0002.SetItemValue(currRow, "data_kubun", "I");
                            this.grdNUT0002.SetItemValue(currRow, "io_kubun", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "io_gubun"));
                            this.grdNUT0002.SetItemValue(currRow, "user_id", UserInfo.UserID);
                            //this.grdByoumei.SetItemValue(currRow, "fk_ocs_irai", this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "pkphy8002"));
                            this.grdNUT0002.SetItemValue(currRow, "pre_modifier_name", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "pre_modifier_name"));
                            this.grdNUT0002.SetItemValue(currRow, "post_modifier_name", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "post_modifier_name"));
                            this.grdNUT0002.SetItemValue(currRow, "fkoutsang", ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, "pkoutsang"));
                            this.grdNUT0002.SetItemValue(currRow, "fknut0001", this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "pknut0001"));
                            string pre_modifier = "pre_modifier";
                            string post_modifier = "post_modifier";

                            for (int j = 1; j <= 10; j++)
                            {
                                this.grdNUT0002.SetItemValue(currRow, pre_modifier + j.ToString(), ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, pre_modifier + j.ToString()));
                                this.grdNUT0002.SetItemValue(currRow, post_modifier + j.ToString(), ((MultiLayout)commandParam["OUTSANG"]).GetItemString(i, post_modifier + j.ToString()));
                            }
                        }
                  }
                  break;
            }
            return base.Command(command, commandParam);
        }
        /// <summary>
        /// OUTSANGQ00から傷病を取得してPHY8003にINSERTする際にすでにあるものは排除するため
        /// </summary>
        /// <param name="aPkoutsang">OUTSANGのPRIMARYKEY</param>
        private bool dupSangChk(string aPkoutsang)
        {
            for (int i = 0; i < this.grdNUT0002.RowCount; i++)
            {
                if (this.grdNUT0002.GetItemString(i, "fkoutsang") == aPkoutsang)
                {
                    return true;
                }
            }
            return false;
        }

        private void NUT0001U00_Load(object sender, EventArgs e)
        {
            SetControl(ref htNUT0001, pnlCenter, ref grdNUT0001);
            SetControl(ref htNUT0001, pnlBottom, ref grdNUT0001);
            SetControl(ref htNUT0001, pnlByoumei, ref grdNUT0001);
            SetControl(ref htNUT0001, grbSijijikou, ref grdNUT0001);
            SetControl(ref htNUT0001, grbSidoueiyouryou, ref grdNUT0001);
            SetControl(ref htNUT0001, grbKensachi, ref grdNUT0001);
            SetControl(ref htNUT0001, grbSidounaiyou, ref grdNUT0001);
            SetControl(ref htNUT0001, grbIsihenoDengon, ref grdNUT0001);
        }

        //#region [Control]
        /// <summary>
        /// Control Binding, Set Hashtable
        /// 1.Hashtable에 각 DataControl를 Load시켜서 해당 Control의 제어를 용이하게 한다.
        /// 2.해당Control Event Binding
        /// </summary>
        private void SetControl(ref Hashtable htControl, XPanel pnlControl, ref XEditGrid grdControl)
        {
            htControl = new Hashtable();
            string colName = "";

            foreach (object obj in pnlControl.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XDictComboBox") >= 0)
                    {
                        colName = ((XDictComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDictComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        //((XFindBox)obj).FindClick += new System.ComponentModel.CancelEventHandler(Control_FindClick);
                        ((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDatePicker)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }
            grdControl.InitializeColumns();
        }

        private void SetControl(ref Hashtable htControl, XGroupBox pnlControl, ref XEditGrid grdControl)
        {
            htControl = new Hashtable();
            string colName = "";

            foreach (object obj in pnlControl.Controls)
            {
                try
                {
                    if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
                    {
                        colName = ((XComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XDictComboBox") >= 0)
                    {
                        colName = ((XDictComboBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDictComboBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
                    {
                        colName = ((XTextBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XTextBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
                    {
                        colName = ((XEditMask)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XEditMask)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
                    {
                        colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XCheckBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
                    {
                        colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                    }
                    else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
                    {
                        colName = ((XFindBox)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        //((XFindBox)obj).FindClick += new System.ComponentModel.CancelEventHandler(Control_FindClick);
                        ((XFindBox)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }
                    else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
                    {
                        colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
                        htControl.Add(colName, obj);
                        //Binding
                        SetGridBinding(grdControl, colName, (IDataControl)obj);
                        ((XDatePicker)obj).DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.Control_DataValidating);
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }
            }
            grdControl.InitializeColumns();
        }
        /// <summary>
        /// 해당 Grid에 Binding 
        /// ** Frame에서 제공하는 SetBindControl이 문제가 있어서 별도 처리.
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        private void SetGridBinding(XEditGrid aGrid, string colName, IDataControl control)
        {
            foreach (XEditGridCell cell in aGrid.CellInfos)
            {
                if (cell.CellName == colName)
                    cell.BindControl = control;
            }
        }
        /// <summary>
        /// 해당 항목 Control의 컬럼명을 가져온다.
        /// </summary>
        /// <param name="obj"> 항목 Control</param>
        /// <returns></returns>
        private string GetColumnName(object obj)
        {
            string colName = "";

            if (obj.GetType().Name.ToString().IndexOf("XComboBox") >= 0)
            {
                colName = ((XComboBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().Name.ToString().IndexOf("XTextBox") >= 0)
            {
                colName = ((XTextBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().Name.ToString().IndexOf("XEditMask") >= 0)
            {
                colName = ((XEditMask)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XCheckBox") >= 0)
            {
                colName = ((XCheckBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XDisplayBox") >= 0)
            {
                colName = ((XDisplayBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XFindBox") >= 0)
            {
                colName = ((XFindBox)obj).Name.Substring(3).ToLower();
            }
            else if (obj.GetType().ToString().IndexOf("XDatePicker") >= 0)
            {
                colName = ((XDatePicker)obj).Name.Substring(3).ToLower();
            }
            return colName;
        }
        private void Control_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            e.Cancel = false;
            string codeName = "";
            string colName = GetColumnName(sender);

            switch (colName)
            {
                default:
                    break;
            }
        }

        private void grdNUT0002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUT0002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUT0002.SetBindVarValue("f_fknut0001", this.grdNUT0001.GetItemString(this.grdNUT0001.CurrentRowNumber, "pknut0001"));
        }

        private void rbtSport_n_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtSport_n.Checked == true)
                this.grdNUT0001.SetItemValue(this.grdNUT0001.CurrentRowNumber, "sport_yn", "N");
            else
                this.grdNUT0001.SetItemValue(this.grdNUT0001.CurrentRowNumber, "sport_yn", "Y");
        }

        private void rbtDrink_n_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDrink_n.Checked == true)
                this.grdNUT0001.SetItemValue(this.grdNUT0001.CurrentRowNumber, "drink_yn", "N");
            else
                this.grdNUT0001.SetItemValue(this.grdNUT0001.CurrentRowNumber, "drink_yn", "Y");
        }

        private void grdNUT0002_MouseDown(object sender, MouseEventArgs e)
        {
            int curRowIndex = -1;
            XEditGrid grd = sender as XEditGrid;

            curRowIndex = grd.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                popupOrderMenu.TrackPopup(grd.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        private void txtBMI_MouseClick(object sender, MouseEventArgs e)
        {
            //if (this.txtWeight.Text != "" && this.txtHeight.Text != "")
            //{
            //    double weight = double.Parse(this.txtWeight.Text);
            //    double height = double.Parse(this.txtHeight.Text);

            //    double bmi = 0d;


            //    bmi = weight / ((height / 100) * (height / 100));

            //    string bmi_str = String.Format("{0:F2}", bmi);
            //    //ＢＭＩ＝体重(kg)÷身長(m)２
            //    //string cmd = "SELECT FN_NUT_GET_BMI(" + weight + ", " + height + ") BMI FROM SYS.DUAL";

            //    ////BindVarCollection bind = new BindVarCollection();
            //    ////bind.Add("f_weight", weight);
            //    ////bind.Add("f_height", height);

            //    //object result = Service.ExecuteScalar(cmd);

            //    if (bmi_str != "")
            //        this.txtBMI.Text = bmi_str;
            //}
        }

        private void BMI_TargetWeight_Validated(object sender, EventArgs e)
        {

            if (this.txtWeight.Text.Trim() != "" && this.txtHeight.Text.Trim() != "")
            {
                if (!TypeCheck.IsDouble(this.txtWeight.Text))
                {
                    XMessageBox.Show(Resources.MSG_004, Resources.CAP_004);
                    this.txtWeight.Focus();
                    return;
                }
                if (!TypeCheck.IsDouble(this.txtHeight.Text))
                {
                    XMessageBox.Show(Resources.MSG_004, Resources.CAP_004);
                    this.txtHeight.Focus();
                    return;
                }

                double weight = double.Parse(this.txtWeight.Text);
                double height = double.Parse(this.txtHeight.Text);

                // BMI
                double bmi = 0d;
                bmi = weight / ((height / 100) * (height / 100));
                string bmi_str = String.Format("{0:F2}", bmi);
                if (bmi_str != "")
                    this.grdNUT0001.SetItemValue(0, "bmi", bmi_str);

                //目標体重
                double targetweight = 0d;
                targetweight = (height / 100) * (height / 100) * 22;
                string targetweight_str = String.Format("{0:F2}", targetweight);
                if (targetweight_str != "")
                    this.grdNUT0001.SetItemValue(0, "targetweight", targetweight_str);

                //ＢＭＩ＝体重(kg)÷身長(m)２
                //string cmd = "SELECT FN_NUT_GET_BMI(" + weight + ", " + height + ") BMI FROM SYS.DUAL";

                ////BindVarCollection bind = new BindVarCollection();
                ////bind.Add("f_weight", weight);
                ////bind.Add("f_height", height);

                //object result = Service.ExecuteScalar(cmd);
            }
            else if(this.txtWeight.Text.Trim() != "")
            {
                if (!TypeCheck.IsDouble(this.txtWeight.Text))
                {
                    XMessageBox.Show(Resources.MSG_004, Resources.CAP_004);
                    this.txtWeight.Focus();
                    return;
                }
            }
            else if (this.txtHeight.Text.Trim() != "")
            {
                if (!TypeCheck.IsDouble(this.txtHeight.Text))
                {
                    XMessageBox.Show(Resources.MSG_004, Resources.CAP_004);
                    this.txtHeight.Focus();
                    return;
                }
            }
        }

        private void rbtSyokai_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtSyokai.Checked == true)
                this.grdNUT0001.SetItemValue(this.grdNUT0001.CurrentRowNumber, "syokai_gubun", "Y");
            else
                this.grdNUT0001.SetItemValue(this.grdNUT0001.CurrentRowNumber, "syokai_gubun", "N");
        }

        private void txtBMI_Validated(object sender, EventArgs e)
        {
            if (this.txtBMI.Text == "")
            {
                this.txtBMI.ResetText();
            }
        }

        private void txtBp_Validated(object sender, EventArgs e)
        {
            if (this.txtBp.Text == "")
                return;

            string[] BP = this.txtBp.Text.Split('/');

            if (BP.Length != 2)
            {
                XMessageBox.Show(Resources.MSG_005, Resources.CAP_004);
                this.txtBp.Focus();
                return;
            }

            for (int i = 0; i < BP.Length; i++)
            {
                if (BP[i] != "")
                {
                    if (!TypeCheck.IsInt(BP[i]))
                    {
                        XMessageBox.Show(Resources.MSG_006, Resources.CAP_004);
                        this.txtBp.Focus();
                        return;
                    }
                }
                else
                {
                    XMessageBox.Show(Resources.MSG_006, Resources.CAP_004);
                    this.txtBp.Focus();
                    return;
                }
            }

            if (int.Parse(BP[0]) < int.Parse(BP[1]))
            {
                XMessageBox.Show(Resources.MSG_007, Resources.CAP_004);
                this.txtBp.Focus();
                return;
            }
                        
        }
        private void txtKensa_Validated(object sender, EventArgs e)
        {
            XTextBox text = sender as XTextBox;
            string value = text.Text;

            if (value != "")
            {
                if (!TypeCheck.IsDouble(value))
                {
                    XMessageBox.Show(Resources.MSG_008, Resources.CAP_004);
                    text.Focus();
                    return;
                }
            }

        }

        #region cloud services

        private NUT0001U00InitializeScreenResult GetScreenResult()
        {
            NUT0001U00InitializeScreenArgs args = new NUT0001U00InitializeScreenArgs();
            args.DoctorGwaName = mDoctorGWANAME;
            args.GwaCode = mDoctorGWA;
            args.Pkocskey = mFkocs;
            args.InOutGubun = mInOutGubun;
            args.HangmogCode = mHangmog_code;
            NUT0001U00InitializeScreenResult result =
                CloudService.Instance.Submit<NUT0001U00InitializeScreenResult, NUT0001U00InitializeScreenArgs>(args);
            return result;
        }

        private List<object[]> LoadGrdNUT0001(BindVarCollection bc) 
		{ 
			List<object[]> res = new List<object[]>(); 
			NUT0001U00InitializeScreenResult result = this.loadScreenResult;
			if (result.ExecutionStatus == ExecutionStatus.Success) 
			{ 
				foreach (NUT0001U00GrdNUT0001ItemInfo item in result.Grd001ItemInfo) 
				{ 
					object[] objects = 
						{ 
                        item.SysDate, 
                        item.UserId, 
                        item.UpdDate, 
                        item.HospCode, 
                        item.Pknut0001, 
                        item.DataKubun, 
                        item.FkOcs, 
                        item.IoKubun, 
                        item.HangmogCode, 
                        item.HangmogName, 
                        item.IraiDate, 
                        item.KanjaNo, 
                        item.Sinryouka, 
                        item.Sindanisi, 
                        item.Bmi, 
                        item.Sijijikou, 
                        item.Targetweight, 
                        item.SportYn, 
                        item.DrinkYn, 
                        item.Energy, 
                        item.Protein, 
                        item.Fat, 
                        item.Ps, 
                        item.Sugar, 
                        item.Salt, 
                        item.Water, 
                        item.Bp, 
                        item.Fbs, 
                        item.A1c, 
                        item.Tch, 
                        item.Tg, 
                        item.Hdl, 
                        item.Ldl, 
                        item.Hb, 
                        item.Alb, 
                        item.Bun, 
                        item.Cre, 
                        item.AstGot, 
                        item.AltGpt, 
                        item.Gammagt, 
                        item.Nutritionist, 
                        item.NutritionistName, 
                        item.NutritionObject, 
                        item.ActingDate, 
                        item.Remark, 
                        item.Weight, 
                        item.Height, 
                        item.SyokaiGubun, 
                        item.ReserDate
						}; 
					res.Add(objects); 
				} 
			} 
			return res; 
		}

        private List<string> CreateGrdNUT0002ParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_fknut0001");
            return paramList;
        }

        private List<object[]> LoadGrdNUT0002(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            NUT0001U00Grd0002Args args = new NUT0001U00Grd0002Args();
            args.Fknut0001 = bc["f_fknut0001"] != null ? bc["f_fknut0001"].VarValue : "";
            NUT0001U00Grd0002Result result = CloudService.Instance.Submit<NUT0001U00Grd0002Result, NUT0001U00Grd0002Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (NUT0001U00GrdNUT0002ItemInfo item in result.Grd002ItemInfo)
                {
                    object[] objects = 
				{ 
					item.SysDate, 
					item.UserId, 
					item.UpdDate, 
					item.HospCode, 
					item.Pknut0002, 
					item.DataKubun, 
					item.Fknut0001, 
					item.IoKubun, 
					item.SangCode, 
					item.DisplaySyoubyoumei, 
					item.PreModifier1, 
					item.PreModifier2, 
					item.PreModifier3, 
					item.PreModifier4, 
					item.PreModifier5, 
					item.PreModifier6, 
					item.PreModifier7, 
					item.PreModifier8, 
					item.PreModifier9, 
					item.PreModifier10, 
					item.PostModifier1, 
					item.PostModifier2, 
					item.PostModifier3, 
					item.PostModifier4, 
					item.PostModifier5, 
					item.PostModifier6, 
					item.PostModifier7, 
					item.PostModifier8, 
					item.PostModifier9, 
					item.PostModifier10, 
					item.SangStartDate, 
					item.SangJindanDate, 
					item.PreModifierName, 
					item.PostModifierName, 
					item.SangName, 
					item.Fkoutsang, 
					item.DataRowState
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<NUT0001U00GrdNUT0001ItemInfo> GetGrd0001DataForSaveLayout()
        {
            List<NUT0001U00GrdNUT0001ItemInfo> lstResult = new List<NUT0001U00GrdNUT0001ItemInfo>();

            for (int i = 0; i < grdNUT0001.RowCount; i++)
            {
                NUT0001U00GrdNUT0001ItemInfo item = new NUT0001U00GrdNUT0001ItemInfo();
                item.SysDate = grdNUT0001.GetItemString(i, "sys_date");
                item.UserId = grdNUT0001.GetItemString(i, "user_id");
                item.UpdDate = grdNUT0001.GetItemString(i, "upd_date");
                item.HospCode = grdNUT0001.GetItemString(i, "hosp_code");
                item.Pknut0001 = grdNUT0001.GetItemString(i, "pknut0001");
                item.DataKubun = grdNUT0001.GetItemString(i, "data_kubun");
                item.FkOcs = grdNUT0001.GetItemString(i, "fk_ocs");
                item.IoKubun = grdNUT0001.GetItemString(i, "io_kubun");
                item.HangmogCode = grdNUT0001.GetItemString(i, "hangmog_code");
                item.HangmogName = grdNUT0001.GetItemString(i, "hangmog_name");
                item.IraiDate = grdNUT0001.GetItemString(i, "irai_date");
                item.KanjaNo = grdNUT0001.GetItemString(i, "kanja_no");
                item.Sinryouka = grdNUT0001.GetItemString(i, "sinryouka");
                item.Sindanisi = grdNUT0001.GetItemString(i, "sindanisi");
                item.Bmi = grdNUT0001.GetItemString(i, "bmi");
                item.Sijijikou = grdNUT0001.GetItemString(i, "sijijikou");
                item.Targetweight = grdNUT0001.GetItemString(i, "targetweight");
                item.SportYn = grdNUT0001.GetItemString(i, "sport_yn");
                item.DrinkYn = grdNUT0001.GetItemString(i, "drink_yn");
                item.Energy = grdNUT0001.GetItemString(i, "energy");
                item.Protein = grdNUT0001.GetItemString(i, "protein");
                item.Fat = grdNUT0001.GetItemString(i, "fat");
                item.Ps = grdNUT0001.GetItemString(i, "ps");
                item.Sugar = grdNUT0001.GetItemString(i, "sugar");
                item.Salt = grdNUT0001.GetItemString(i, "salt");
                item.Water = grdNUT0001.GetItemString(i, "water");
                item.Bp = grdNUT0001.GetItemString(i, "bp");
                item.Fbs = grdNUT0001.GetItemString(i, "fbs");
                item.A1c = grdNUT0001.GetItemString(i, "a1c");
                item.Tch = grdNUT0001.GetItemString(i, "tch");
                item.Tg = grdNUT0001.GetItemString(i, "tg");
                item.Hdl = grdNUT0001.GetItemString(i, "hdl");
                item.Ldl = grdNUT0001.GetItemString(i, "ldl");
                item.Hb = grdNUT0001.GetItemString(i, "hb");
                item.Alb = grdNUT0001.GetItemString(i, "alb");
                item.Bun = grdNUT0001.GetItemString(i, "bun");
                item.Cre = grdNUT0001.GetItemString(i, "cre");
                item.AstGot = grdNUT0001.GetItemString(i, "ast_got");
                item.AltGpt = grdNUT0001.GetItemString(i, "alt_gpt");
                item.Gammagt = grdNUT0001.GetItemString(i, "gammagt");
                item.Nutritionist = grdNUT0001.GetItemString(i, "nutritionist");
                item.NutritionistName = grdNUT0001.GetItemString(i, "nutritionist_name");
                item.NutritionObject = grdNUT0001.GetItemString(i, "nutrition_object");
                item.ActingDate = grdNUT0001.GetItemString(i, "acting_date");
                item.Remark = grdNUT0001.GetItemString(i, "remark");
                item.Weight = grdNUT0001.GetItemString(i, "weight");
                item.Height = grdNUT0001.GetItemString(i, "height");
                item.SyokaiGubun = grdNUT0001.GetItemString(i, "syokai_gubun");
                item.ReserDate = grdNUT0001.GetItemString(i, "reser_date");

                item.DataRowState = grdNUT0001.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdNUT0001.DeletedRowTable)
            {
                foreach (DataRow dr in grdNUT0001.DeletedRowTable.Rows)
                {
                    NUT0001U00GrdNUT0001ItemInfo item = new NUT0001U00GrdNUT0001ItemInfo();
                    item.Pknut0001 = Convert.ToString(dr["pknut0001"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private List<NUT0001U00GrdNUT0002ItemInfo> GetGrd0002DataForSaveLayout()
        {
            List<NUT0001U00GrdNUT0002ItemInfo> lstResult = new List<NUT0001U00GrdNUT0002ItemInfo>();

            for (int i = 0; i < grdNUT0002.RowCount; i++)
            {
                NUT0001U00GrdNUT0002ItemInfo item = new NUT0001U00GrdNUT0002ItemInfo();
                item.SysDate = grdNUT0002.GetItemString(i, "sys_date");
                item.UserId = grdNUT0002.GetItemString(i, "user_id");
                item.UpdDate = grdNUT0002.GetItemString(i, "upd_date");
                item.HospCode = grdNUT0002.GetItemString(i, "hosp_code");
                item.Pknut0002 = grdNUT0002.GetItemString(i, "pknut0002");
                item.DataKubun = grdNUT0002.GetItemString(i, "data_kubun");
                item.Fknut0001 = grdNUT0002.GetItemString(i, "fknut0001");
                item.IoKubun = grdNUT0002.GetItemString(i, "io_kubun");
                item.SangCode = grdNUT0002.GetItemString(i, "syoubyoumei_code");
                item.DisplaySyoubyoumei = grdNUT0002.GetItemString(i, "display_syoubyoumei");
                item.PreModifier1 = grdNUT0002.GetItemString(i, "pre_modifier1");
                item.PreModifier2 = grdNUT0002.GetItemString(i, "pre_modifier2");
                item.PreModifier3 = grdNUT0002.GetItemString(i, "pre_modifier3");
                item.PreModifier4 = grdNUT0002.GetItemString(i, "pre_modifier4");
                item.PreModifier5 = grdNUT0002.GetItemString(i, "pre_modifier5");
                item.PreModifier6 = grdNUT0002.GetItemString(i, "pre_modifier6");
                item.PreModifier7 = grdNUT0002.GetItemString(i, "pre_modifier7");
                item.PreModifier8 = grdNUT0002.GetItemString(i, "pre_modifier8");
                item.PreModifier9 = grdNUT0002.GetItemString(i, "pre_modifier9");
                item.PreModifier10 = grdNUT0002.GetItemString(i, "pre_modifier10");
                item.PostModifier1 = grdNUT0002.GetItemString(i, "post_modifier1");
                item.PostModifier2 = grdNUT0002.GetItemString(i, "post_modifier2");
                item.PostModifier3 = grdNUT0002.GetItemString(i, "post_modifier3");
                item.PostModifier4 = grdNUT0002.GetItemString(i, "post_modifier4");
                item.PostModifier5 = grdNUT0002.GetItemString(i, "post_modifier5");
                item.PostModifier6 = grdNUT0002.GetItemString(i, "post_modifier6");
                item.PostModifier7 = grdNUT0002.GetItemString(i, "post_modifier7");
                item.PostModifier8 = grdNUT0002.GetItemString(i, "post_modifier8");
                item.PostModifier9 = grdNUT0002.GetItemString(i, "post_modifier9");
                item.PostModifier10 = grdNUT0002.GetItemString(i, "post_modifier10");
                item.SangStartDate = grdNUT0002.GetItemString(i, "sang_start_date");
                item.SangJindanDate = grdNUT0002.GetItemString(i, "sang_jindan_date");
                item.PreModifierName = grdNUT0002.GetItemString(i, "pre_modifier_name");
                item.PostModifierName = grdNUT0002.GetItemString(i, "post_modifier_name");
                item.SangName = grdNUT0002.GetItemString(i, "syoubyoumei");
                item.Fkoutsang = grdNUT0002.GetItemString(i, "fkoutsang");

                item.DataRowState = grdNUT0002.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdNUT0002.DeletedRowTable)
            {
                foreach (DataRow dr in grdNUT0002.DeletedRowTable.Rows)
                {
                    NUT0001U00GrdNUT0002ItemInfo item = new NUT0001U00GrdNUT0002ItemInfo();
                    item.Pknut0002 = Convert.ToString(dr["pknut0002"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        #endregion
    }
}

