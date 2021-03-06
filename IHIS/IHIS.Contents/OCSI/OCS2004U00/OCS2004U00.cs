using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;

namespace IHIS.OCSI
{
    public partial class OCS2004U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]

        String mHospCode = EnvironInfo.HospCode;
        string mMemb = UserInfo.UserID;
        int mFkinp1001 = 0;
        string mBunho = "";
        string mOrder_date = "";
        string mInput_gubun = "";

        string mInput_gwa = "";
        string mInput_doctor = "";
        int mBeforeSelectedTabIndex = -1;
        MultiLayout mArgOCS2005 = null;


        //Data가 없는 경우 화면 닫을지 여부
        private bool mAuto_close = false;

        #endregion

        public OCS2004U00()
        {
            InitializeComponent();
        }

        #region [메세지 처리 코드]
        private void ShowMessage(string separation)
        {
            string msg = string.Empty;
            string cpt = string.Empty;

            switch (separation)
            {
                case "BUNHO_ERROR":
                    msg = "患者番号が正確ではないです。確認してください。";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "PKINP1001_ERROR":
                    msg = "入院情報が正確ではないです。確認してください。";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ORDER_DATE_ERROR":
                    msg = "オーダ日付が正確ではないです。確認してください。";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "INPUT_GUBUN_ERROR":
                    msg = "入力区分が正確ではないです。確認してください。";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ServiceError":
                    msg = String.Format("処理中にエラーが発生しました。\n\nエラー内容：{0}", Service.ErrFullMsg);
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region 현재 화면이 열려있는 경우에 호출을 받았을 경우 처리
        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OCS2005U00": // 지시사항

                    #region

                    if (commandParam.Contains("DIRECT"))
                    {
                        SetDirectInfo((MultiLayout)commandParam["DELETEDIRECT"], (MultiLayout)commandParam["DIRECT"], (MultiLayout)commandParam["DELETEDIRECTDETAIL"], (MultiLayout)commandParam["DIRECTDETAIL"]);
                    }

                    break;

                    #endregion

                case "OCS0304Q00": // 약속지시사항

                    #region

                    if (commandParam.Contains("OCS0305"))
                    {
                        SetDirectInfo((MultiLayout)commandParam["OCS0305"], (MultiLayout)commandParam["OCS0306"]);
                    }

                    break;
                    #endregion
            }

            if (command == "F") return base.Command(command, commandParam);

            return base.Command(command, commandParam);
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #region [OCS2004U00 스크린오픈 이벤트]
        private void OCS2004U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                    {
                        if (TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
                        {
                            ShowMessage("BUNHO_ERROR");
                            this.Close();
                            return;
                        }
                        else
                            mBunho = OpenParam["bunho"].ToString().Trim();
                    }
                    else
                    {
                        ShowMessage("BUNHO_ERROR");
                        this.Close();
                        return;
                    }

                    if (OpenParam.Contains("fkinp1001"))
                    {
                        if (!TypeCheck.IsInt(OpenParam["fkinp1001"].ToString()))
                        {
                            ShowMessage("PKINP1001_ERROR");
                            return;
                        }
                        else
                            mFkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString().Trim());
                    }
                    else
                    {
                        ShowMessage("PKINP1001_ERROR");
                        return;
                    }

                    if (OpenParam.Contains("order_date"))
                    {
                        if (!TypeCheck.IsDateTime(OpenParam["order_date"].ToString().Trim()))
                        {
                            ShowMessage("ORDER_DATE_ERROR");
                            return;
                        }
                        else
                        {
                            mOrder_date = OpenParam["order_date"].ToString();
                            dtpOrderDate.SetEditValue(OpenParam["order_date"]);
                        }      
                    }
                    else
                    {
                        ShowMessage("ORDER_DATE_ERROR");
                        return;
                    }

                    if (OpenParam.Contains("input_gubun"))
                    {
                        if (TypeCheck.IsNull(OpenParam["input_gubun"].ToString().Trim()))
                        {
                            ShowMessage("INPUT_GUBUN_ERROR");
                            this.Close();
                            return;
                        }
                        else
                            mInput_gubun = OpenParam["input_gubun"].ToString().Trim();
                    }
                    else
                    {
                        ShowMessage("INPUT_GUBUN_ERROR");
                        this.Close();
                        return;
                    }

                    if (OpenParam.Contains("OCS2005"))
                    {
                        if ((MultiLayout)OpenParam["OCS2005"] != null)
                        {
                            mArgOCS2005 = ((MultiLayout)OpenParam["OCS2005"]).Copy();
                        }
                    }

                    //Data가 없는 경우 화면 닫을지 여부
                    if (OpenParam.Contains("auto_close"))
                    {
                        mAuto_close = bool.Parse(OpenParam["auto_close"].ToString().Trim());
                        if (mAuto_close) this.ParentForm.WindowState = FormWindowState.Minimized;
                    }

                    ////////////////////////////////////////////////////////////
                    if (OpenParam.Contains("input_gwa"))
                    {
                        if (TypeCheck.IsNull(OpenParam["input_gwa"].ToString().Trim()))
                        {
                            ShowMessage("INPUT_GWA_ERROR");
                            this.Close();
                            return;
                        }
                        else
                            mInput_gwa = OpenParam["input_gwa"].ToString().Trim();
                    }
                    else
                    {
                        ShowMessage("INPUT_GWA_ERROR");
                        this.Close();
                        return;
                    }

                    if (OpenParam.Contains("input_doctor"))
                    {
                        if (TypeCheck.IsNull(OpenParam["input_doctor"].ToString().Trim()))
                        {
                            ShowMessage("INPUT_DOCTOR_ERROR");
                            this.Close();
                            return;
                        }
                        else
                            mInput_doctor = OpenParam["input_doctor"].ToString().Trim();
                    }
                    else
                    {
                        ShowMessage("INPUT_DOCTOR_ERROR");
                        this.Close();
                        return;
                    }
                    ////////////////////////////////////////////////////////////

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "");
                }
            }

            PostCallHelper.PostCall(new PostMethod(PostLoad));		
        }

        private void PostLoad()
        {
            this.OCS2004U00_UserChanged(this, new System.EventArgs());

            if (TypeCheck.IsNull(mBunho))
            {
                this.Close();
                return;
            }

            DataCall();

            //if (mArgOCS2005 != null)
            //{
            //    this.SetDirectInfo(mArgOCS2005);
            //}

            if (mAuto_close && layOCS2005.RowCount < 1)
            {
                this.Close();
                return;
            }
            else
                if (mAuto_close) this.ParentForm.WindowState = FormWindowState.Normal;
        }

        private void OCS2004U00_UserChanged(object sender, EventArgs e)
        {
            LoadInput_gubun();
        }

        #endregion

        #region [Input_gubun]

        private bool LoadInput_gubun()
        {
            // 탭구분 초기화
            try
            {
                this.tabInput_gubun.TabPages.Clear();
            }
            catch { }

            IHIS.X.Magic.Controls.TabPage page;
            IHIS.X.Magic.Controls.TabPage pageSelect = new IHIS.X.Magic.Controls.TabPage();

            if (layTabItem.QueryLayout(true))
            {
                if (layTabItem.LayoutTable.Rows.Count > 0)
                {
                    foreach (DataRow row in this.layTabItem.LayoutTable.Select())
                    {
                        page = new IHIS.X.Magic.Controls.TabPage();
                        page.Title = row["code_name"].ToString();
                        page.Tag = row["code"].ToString();
                        page.ImageIndex = 0;
                        tabInput_gubun.TabPages.Add(page);

                        if (row["code"].ToString() == mInput_gubun) pageSelect = page;
                    }

                    if (pageSelect.Tag != null)
                        tabInput_gubun.SelectedTab = pageSelect;
                    else
                        tabInput_gubun.SelectedIndex = 0;
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return false;
            }

            return true;
        }

        private void tabInput_gubun_SelectionChanged(object sender, EventArgs e)
        {
            XTabControl aTab = sender as XTabControl;

            if (tabInput_gubun.SelectedTab == null) return;

            // 未保存データ確認
            for (int i = 0; i < this.grdOCS2005.DeletedRowCount; i++)
            {
                if (this.mBeforeSelectedTabIndex != aTab.SelectedIndex)
                {
                    XMessageBox.Show("削除されてまだ保存されてないデータが存在します。保存してください。", "確認");
                    tabInput_gubun.SelectedIndex = this.mBeforeSelectedTabIndex;

                    return;
                }
            }

            for (int i = 0; i < this.grdOCS2005.DisplayRowCount; i++)
            {
                if (this.grdOCS2005.GetRowState(i) != DataRowState.Unchanged
                    && this.mBeforeSelectedTabIndex != aTab.SelectedIndex)
                {
                    XMessageBox.Show("保存されてないデータが存在します。保存してください。", "確認");
                    tabInput_gubun.SelectedIndex = this.mBeforeSelectedTabIndex;

                    return;
                }
            }

            // 체크에 따라 이미지를 변경
            foreach (IHIS.X.Magic.Controls.TabPage page in tabInput_gubun.TabPages)
            {
                if (tabInput_gubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }
            //grdOCS2006.Reset();

            LoadInput_gubunInfo(tabInput_gubun.SelectedTab.Tag.ToString());
        }

        private void LoadInput_gubunInfo(string arInput_gubun)
        {
            LoadData(arInput_gubun);
        }

        #endregion

        #region [버튼이벤트]
        // 지시사항등록
        private void btnDirect_Click(object sender, EventArgs e)
        {
            MultiLayout dloParaOCS2005 = this.grdOCS2005.CloneToLayout();

            foreach (DataRow row2005 in this.grdOCS2005.LayoutTable.Rows)
            {
                if(DateTime.Parse(TypeCheck.NVL(row2005["drt_to_date"].ToString(), "9998/12/31").ToString()) > DateTime.Parse(this.dtpOrderDate.GetDataValue()))
                        dloParaOCS2005.LayoutTable.ImportRow(row2005);
                
            }
            
            IHIS.Framework.MultiLayout dloParaOCS2006 = new MultiLayout();    //layOCS2006;

                        
            if (grdOCS2006.RowCount > 0)
            {

                dloParaOCS2006 = grdOCS2006.CopyToLayout();
            }
            else
            {
                dloParaOCS2006 = layOCS2006;
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("input_gubun",   mInput_gubun);
            openParams.Add("direct_mode",   "2");
            openParams.Add("order_date",    dtpOrderDate.GetDataValue());

            openParams.Add("bunho",     mBunho);
            openParams.Add("fkinp1001", mFkinp1001.ToString());

            openParams.Add("DIRECT",        dloParaOCS2005);
            openParams.Add("DIRECT_DETAIL", dloParaOCS2006);
            openParams.Add("select_input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U00", ScreenOpenStyle.ResponseSizable, openParams);
            
        }

        // 세트지시사항
        private void btnYaksokDirect_Click(object sender, EventArgs e)
        {
            this.layAllOCS2005.QueryLayout(false);

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("memb", UserInfo.UserID);

            openParams.Add("OCS2005", this.layAllOCS2005.LayoutTable);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0304Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        // 버튼리스트
        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    DataCall();

                    break;
                case FunctionType.Delete:

                    e.IsBaseCall = false;
                    // 削除可能かチェック
                    if (this.grdOCS2005.GetItemString(this.grdOCS2005.CurrentRowNumber, "siji_result_act_max_date") != "")
                    {
                        XMessageBox.Show("選択した件は削除することが出来ません。(実施された履歴が存在します。)", "確認");
                        return;
                    }
                    else
                        this.grdOCS2005.DeleteRow(this.grdOCS2005.CurrentRowNumber);

                    break;

                case FunctionType.Update:

                    if (!ChkData())
                        return;


                    Service.BeginTransaction();

                    try
                    {
                        string spName_dup = "PR_OCSI_OCS2005_DUP";
                        ArrayList inputList_dup = new ArrayList();
                        ArrayList outputList_dup = new ArrayList();
                        string IUD_GUBUN = "";

                        for (int i = 0; i < this.grdOCS2005.DeletedRowCount; i++)
                        {
                            #region DUPLICATION CHECK

                            inputList_dup.Clear();
                            outputList_dup.Clear();

                            IUD_GUBUN = "D";

                            if (!TypeCheck.IsNull(this.grdOCS2005.DeletedRowTable.Rows[i]["drt_from_date"].ToString())
                                && !TypeCheck.IsNull(this.grdOCS2005.DeletedRowTable.Rows[i]["drt_from_time"].ToString())
                                )
                            {
                                inputList_dup.Add(mHospCode);
                                inputList_dup.Add(IUD_GUBUN);
                                inputList_dup.Add(this.grdOCS2005.DeletedRowTable.Rows[i]["direct_code"].ToString());
                                inputList_dup.Add(mBunho);
                                inputList_dup.Add(mFkinp1001.ToString());
                                inputList_dup.Add(this.grdOCS2005.DeletedRowTable.Rows[i]["drt_from_date"].ToString());
                                inputList_dup.Add(this.grdOCS2005.DeletedRowTable.Rows[i]["drt_from_time"].ToString());
                                inputList_dup.Add(TypeCheck.NVL(this.grdOCS2005.DeletedRowTable.Rows[i]["drt_to_date"].ToString(), "9998/12/31"));
                                inputList_dup.Add(TypeCheck.NVL(this.grdOCS2005.DeletedRowTable.Rows[i]["drt_to_time"].ToString(), "2359"));
                                inputList_dup.Add(this.mMemb);
                                inputList_dup.Add(this.grdOCS2005.DeletedRowTable.Rows[i]["pkocs2005"].ToString());

                                if (Service.ExecuteProcedure(spName_dup, inputList_dup, outputList_dup))
                                {
                                    if (!outputList_dup[0].ToString().Equals("T"))
                                    {  // flag
                                        XMessageBox.Show(outputList_dup[1].ToString(), "確認", MessageBoxIcon.Stop);
                                        throw new Exception(outputList_dup[1].ToString());
                                    }
                                }
                                else
                                {
                                    XMessageBox.Show(Service.ErrFullMsg, "確認", MessageBoxIcon.Stop);
                                    throw new Exception(Service.ErrFullMsg);
                                }
                            }
                            #endregion DUPLICATION CHECK
                        }

                        #region DUPLICATION CHECK
                        for (int i = 0; i < this.grdOCS2005.DisplayRowCount; i++)
                        {
                        
                            inputList_dup.Clear();
                            outputList_dup.Clear();

                            if (this.grdOCS2005.GetRowState(i) == DataRowState.Unchanged)
                                continue;
                            else if (this.grdOCS2005.GetRowState(i) == DataRowState.Modified)
                                IUD_GUBUN = "U";
                            else if (this.grdOCS2005.GetRowState(i) == DataRowState.Added)
                                IUD_GUBUN = "I";

                            if (!TypeCheck.IsNull(this.grdOCS2005.GetItemString(i, "drt_from_date"))
                                && !TypeCheck.IsNull(this.grdOCS2005.GetItemString(i, "drt_from_time"))
                                )
                            {
                                inputList_dup.Add(mHospCode);
                                inputList_dup.Add(IUD_GUBUN);
                                inputList_dup.Add(this.grdOCS2005.GetItemString(i, "direct_code"));
                                inputList_dup.Add(mBunho);
                                inputList_dup.Add(mFkinp1001.ToString());
                                inputList_dup.Add(this.grdOCS2005.GetItemString(i, "drt_from_date"));
                                inputList_dup.Add(this.grdOCS2005.GetItemString(i, "drt_from_time"));
                                inputList_dup.Add(TypeCheck.NVL(this.grdOCS2005.GetItemString(i, "drt_to_date"), "9998/12/31"));
                                inputList_dup.Add(TypeCheck.NVL(this.grdOCS2005.GetItemString(i, "drt_to_time"), "2359"));
                                inputList_dup.Add(this.mMemb);
                                inputList_dup.Add(this.grdOCS2005.GetItemString(i, "pkocs2005"));

                                if (Service.ExecuteProcedure(spName_dup, inputList_dup, outputList_dup))
                                {
                                    if (!outputList_dup[0].ToString().Equals("T"))
                                    {  // flag
                                        //XMessageBox.Show(outputList_dup[1].ToString(), "確認", MessageBoxIcon.Stop);
                                        throw new Exception(" 対象：" + (i + 1) + "行 " + this.grdOCS2005.GetItemString(i, "direct_code_name") + "\r\n\r\n" + outputList_dup[1].ToString());
                                    }
                                }
                                else
                                {
                                    XMessageBox.Show(Service.ErrFullMsg, "確認", MessageBoxIcon.Stop);
                                    throw new Exception(Service.ErrFullMsg);
                                }
                            }
                            #endregion DUPLICATION CHECK
                        }

                        
                        if (!ApplyCurrentData())
                            throw new Exception("保存失敗"); // 화면에 적용
                        

                    }
                    catch (Exception xe)
                    {
                        Service.RollbackTransaction();
                        XMessageBox.Show(xe.Message, "保存失敗", MessageBoxIcon.Error);
                        //DataCall();
                        return;
                    }
                    

                    

                    try
                    {
                        

                        // -- OCS2005 ---------------------------------------------------------------------------------------------------
                        foreach(DataRow row in layOCS2005.LayoutTable.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                string cmdText = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();

                                if (row["drt_to_date"].ToString() != "" && row["drt_to_time"].ToString() == "")
                                    row["drt_to_time"] = "2359";

                                if (row["drt_to_date"].ToString() == "" && row["drt_to_time"].ToString() == "")
                                    row["continue_yn"] = "Y";

                                cmdText = @"UPDATE OCS2005
                                               SET UPD_ID         = :q_user_id       ,
                                                   UPD_DATE       =  SYSDATE         ,
                                                   DIRECT_CONT1   = :f_direct_cont1  ,
                                                   DIRECT_CONT2   = :f_direct_cont2  ,
                                                   DIRECT_TEXT    = :f_direct_text   ,
                                                   DRT_FROM_DATE  = :f_drt_from_date ,
                                                   DRT_TO_DATE    = :f_drt_to_date   ,
                                                   DRT_TO_TIME    = :f_drt_to_time   ,
                                                   DRT_FROM_TIME  = :f_drt_from_time ,
                                                   CONTINUE_YN    = :f_continue_yn   ,
                                                   JUSIK_YUDONG   = :f_jusik_yudong  ,
                                                   BUSIK_YUDONG   = :f_busik_yudong  ,
                                                   JORI_TYPE      = :f_jori_type     ,
                                                   KUMJISIK       = :f_kumjisik
                                             WHERE PKOCS2005      = :f_pkocs2005
                                               AND HOSP_CODE      = :f_hosp_code";

                                bindVals.Add("q_user_id",       this.mMemb);
                                bindVals.Add("f_direct_cont1",  row["direct_cont1"].ToString());
                                bindVals.Add("f_direct_cont2",  row["direct_cont2"].ToString());
                                bindVals.Add("f_direct_text",   row["direct_text"].ToString(), 2000);
                                bindVals.Add("f_drt_from_date", row["drt_from_date"].ToString());
                                bindVals.Add("f_drt_to_date",   row["drt_to_date"].ToString());
                                bindVals.Add("f_drt_to_time",   row["drt_to_time"].ToString());
                                bindVals.Add("f_drt_from_time", row["drt_from_time"].ToString());
                                bindVals.Add("f_continue_yn",   row["continue_yn"].ToString());
                                bindVals.Add("f_pkocs2005",     row["pkocs2005"].ToString());
                                bindVals.Add("f_hosp_code",     mHospCode);

                                bindVals.Add("f_jusik_yudong",  row["jusik_yudong"].ToString());
                                bindVals.Add("f_busik_yudong",  row["busik_yudong"].ToString());
                                bindVals.Add("f_jori_type",     row["jori_type"].ToString());
                                bindVals.Add("f_kumjisik",      row["kumjisik"].ToString());

                                Service.ExecuteNonQuery(cmdText, bindVals);

                                // DB 처리 성공
                                if (Service.ErrCode == 0)
                                {
                                    e.IsBaseCall = false;
                                }
                                // DB 처리 실패
                                else
                                {
                                    ShowMessage("ServiceError");
                                    e.IsBaseCall = false;
                                }
                            }
                            else if (row.RowState == DataRowState.Added)
                            {
                                string cmdSeq = string.Empty;
                                string cmdText = string.Empty;
                                BindVarCollection bindVal = new BindVarCollection();
                                BindVarCollection bindVals = new BindVarCollection();

                                if (row["drt_to_date"].ToString() != "" && row["drt_to_time"].ToString() == "")
                                    row["drt_to_time"] = "2359";

                                if (row["drt_to_date"].ToString() == "" && row["drt_to_time"].ToString() == "")
                                    row["continue_yn"] = "Y";


                                //#region DUPLICATION CHECK
                                //string spName_dup = "PR_OCSI_OCS2005_DUP";
                                //ArrayList inputList_dup = new ArrayList();
                                //ArrayList outputList_dup = new ArrayList();

                                //if (   !TypeCheck.IsNull(row["drt_from_date"].ToString())
                                //    && !TypeCheck.IsNull(row["drt_from_time"].ToString())
                                //    //&& !TypeCheck.IsNull(row["drt_to_date"].ToString())
                                //    //&& !TypeCheck.IsNull(row["drt_to_time"].ToString())
                                //    )
                                //{
                                //    inputList_dup.Add(mHospCode);
                                //    inputList_dup.Add("I");
                                //    inputList_dup.Add(row["direct_code"].ToString());
                                //    inputList_dup.Add(mBunho);
                                //    inputList_dup.Add(mFkinp1001.ToString());
                                //    inputList_dup.Add(row["drt_from_date"].ToString());
                                //    inputList_dup.Add(row["drt_from_time"].ToString());
                                //    inputList_dup.Add(TypeCheck.NVL(row["drt_to_date"].ToString(), "9998/12/31"));
                                //    inputList_dup.Add(TypeCheck.NVL(row["drt_to_time"].ToString(), "2359"));
                                //    inputList_dup.Add(this.mMemb);
                                //    inputList_dup.Add(row["pkocs2005"].ToString());

                                //    if (Service.ExecuteProcedure(spName_dup, inputList_dup, outputList_dup))
                                //    {
                                //        if (!outputList_dup[0].ToString().Equals("T"))  // flag
                                //            throw new Exception(outputList_dup[1].ToString());
                                //    }
                                //    else
                                //        throw new Exception(Service.ErrFullMsg);
                                //}
                                //#endregion DUPLICATION CHECK

                                cmdText = @"INSERT INTO OCS2005
                                                   ( SYS_DATE       , UPD_ID         , UPD_DATE       , BUNHO          ,
                                                     PKOCS2005      , INPUT_GWA      , INPUT_DOCTOR   ,
                                                     FKINP1001      , ORDER_DATE     , INPUT_GUBUN    , INPUT_ID       ,
                                                     PK_SEQ         , DIRECT_GUBUN   , DIRECT_CODE    , DIRECT_CONT1   ,
                                                     DIRECT_CONT2   , DIRECT_TEXT    , HOSP_CODE      ,
                                                     SYS_ID         , DRT_FROM_DATE  , DRT_TO_DATE    , CONTINUE_YN    ,
                                                     JUSIK_YUDONG   , BUSIK_YUDONG   , JORI_TYPE      , KUMJISIK       ,
                                                     DRT_TO_TIME    , DRT_FROM_TIME )
                                             VALUES
                                                   ( SYSDATE           , :q_user_id        , SYSDATE          , :f_bunho        ,
                                                     :f_pkocs2005      , :f_input_gwa      , :f_input_doctor  ,
                                                     :f_fkinp1001      , :f_order_date     , :f_input_gubun   , :q_user_id      ,
                                                     :f_pk_seq         , :f_direct_gubun   , :f_direct_code   , :f_direct_cont1 ,
                                                     :f_direct_cont2   , :f_direct_text    , :f_hosp_code     ,
                                                     :q_user_id        , :f_drt_from_date  , :f_drt_to_date   , :f_continue_yn  ,
                                                     :f_jusik_yudong   , :f_busik_yudong   , :f_jori_type     , :f_kumjisik     ,
                                                     :f_drt_to_time    , :f_drt_from_time)";

                                bindVals.Add("q_user_id",       this.mMemb);
                                bindVals.Add("f_bunho",         mBunho);
                                bindVals.Add("f_pkocs2005",     row["pkocs2005"].ToString());
                                bindVals.Add("f_fkinp1001",     mFkinp1001.ToString());
                                bindVals.Add("f_order_date",    dtpOrderDate.GetDataValue());   // 2011/05/31
                                //bindVals.Add("f_order_date",    row["drt_from_date"].ToString());   // 2011/05/31
                                bindVals.Add("f_input_gubun",   row["input_gubun"].ToString());
                                bindVals.Add("f_pk_seq",        row["pk_seq"].ToString());
                                bindVals.Add("f_direct_gubun",  row["direct_gubun"].ToString());
                                bindVals.Add("f_direct_code",   row["direct_code"].ToString());
                                bindVals.Add("f_direct_cont1",  row["direct_cont1"].ToString());
                                bindVals.Add("f_direct_cont2",  row["direct_cont2"].ToString());
                                bindVals.Add("f_direct_text",   row["direct_text"].ToString(), 2000);
                                bindVals.Add("f_hosp_code",     mHospCode);
                                bindVals.Add("f_drt_from_date", row["drt_from_date"].ToString());
                                bindVals.Add("f_drt_to_date",   row["drt_to_date"].ToString());
                                bindVals.Add("f_continue_yn",   row["continue_yn"].ToString());

                                bindVals.Add("f_jusik_yudong",  row["jusik_yudong"].ToString());
                                bindVals.Add("f_busik_yudong",  row["busik_yudong"].ToString());
                                bindVals.Add("f_jori_type",     row["jori_type"].ToString());
                                bindVals.Add("f_kumjisik",      row["kumjisik"].ToString());

                                bindVals.Add("f_drt_to_time",   row["drt_to_time"].ToString());
                                bindVals.Add("f_drt_from_time", row["drt_from_time"].ToString());

                                bindVals.Add("f_input_gwa",     mInput_gwa);
                                bindVals.Add("f_input_doctor",  mInput_doctor);

                                Service.ExecuteNonQuery(cmdText, bindVals);

                                // DB 처리 성공
                                if (Service.ErrCode == 0)
                                {
                                    e.IsBaseCall = false;
                                }
                                // DB 처리 실패
                                else
                                {
                                    ShowMessage("ServiceError");
                                    e.IsBaseCall = false;
                                }
                            }
                        }

                        #region delete

                        if (layDeleteDetail.RowCount > 0)
                        {
                            foreach (DataRow row in layDeleteDetail.LayoutTable.Rows)
                            {
                                string cmdText = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();

                                cmdText = @"DELETE FROM OCS2006
                                             WHERE FKOCS2005 = :f_fkocs2005
                                               AND SEQ       = :f_seq
                                               AND HOSP_CODE = :f_hosp_code"; 

                                bindVals.Add("f_fkocs2005", row["fkocs2005"].ToString());
                                bindVals.Add("f_seq",       row["seq"].ToString());
                                bindVals.Add("f_hosp_code", mHospCode);

                                Service.ExecuteNonQuery(cmdText, bindVals);

                                // DB 처리 성공
                                if (Service.ErrCode == 0)
                                {
                                    e.IsBaseCall = false;
                                }
                                // DB 처리 실패
                                else
                                {
                                    ShowMessage("ServiceError");
                                    e.IsBaseCall = false;
                                }
                            }
                            layDeleteDetail.Reset();
                        }

                        #region DELETE AT OCS2004

                            if (this.grdOCS2005.DeletedRowCount > 0)
                            {
                                foreach (DataRow row in this.grdOCS2005.DeletedRowTable.Rows)
                                {
                                    string cmdText = string.Empty;
                                    string cmdTextD = string.Empty;
                                    BindVarCollection bindVals = new BindVarCollection();
                                    BindVarCollection bindValsD = new BindVarCollection();

                                    cmdTextD = @"DELETE FROM OCS2006
                                                  WHERE FKOCS2005 = :f_fkocs2005
                                                    AND HOSP_CODE = :f_hosp_code";
                                    bindValsD.Add("f_fkocs2005", row["pkocs2005"].ToString());
                                    bindValsD.Add("f_hosp_code", mHospCode);

                                    Service.ExecuteNonQuery(cmdTextD, bindValsD);

                                    cmdText = @"DELETE FROM OCS2005
                                                 WHERE PKOCS2005 = :f_pkocs2005
                                                   AND HOSP_CODE = :f_hosp_code";
                                    bindVals.Add("f_pkocs2005", row["pkocs2005"].ToString());
                                    bindVals.Add("f_hosp_code", mHospCode);

                                    Service.ExecuteNonQuery(cmdText, bindVals);

                                    // DB 처리 성공
                                    if (Service.ErrCode == 0)
                                    {
                                        e.IsBaseCall = false;
                                    }
                                    // DB 처리 실패
                                    else
                                    {
                                        ShowMessage("ServiceError");
                                        e.IsBaseCall = false;
                                    }
                                }
                            }

                        #endregion DELETE AT OCS2004

                        if (layDeleteData.RowCount > 0)
                        {
                            foreach (DataRow row in layDeleteData.LayoutTable.Rows)
                            {
                                string cmdText = string.Empty;
                                string cmdTextD = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();
                                BindVarCollection bindValsD = new BindVarCollection();

                                cmdText = @"DELETE FROM OCS2005
                                             WHERE PKOCS2005 = :f_pkocs2005
                                               AND HOSP_CODE = :f_hosp_code";
                                bindVals.Add("f_pkocs2005", row["pkocs2005"].ToString());
                                bindVals.Add("f_hosp_code", mHospCode);

                                cmdTextD = @"DELETE FROM OCS2006
                                              WHERE FKOCS2005 = :f_fkocs2005
                                                AND HOSP_CODE = :f_hosp_code";
                                bindValsD.Add("f_fkocs2005", row["pkocs2005"].ToString());
                                bindValsD.Add("f_hosp_code", mHospCode);

                                if (layOCS2006.RowCount > 0)
                                {
                                    Service.ExecuteNonQuery(cmdTextD, bindValsD);
                                }

                                Service.ExecuteNonQuery(cmdText, bindVals);

                                // DB 처리 성공
                                if (Service.ErrCode == 0)
                                {
                                    e.IsBaseCall = false;
                                }
                                // DB 처리 실패
                                else
                                {
                                    ShowMessage("ServiceError");
                                    e.IsBaseCall = false;
                                }
                            }
                            layDeleteData.Reset();
                        }
                        #endregion

                        // -- OCS2006 ---------------------------------------------------------------------------------------------------
                        if(layOCS2006.RowCount > 0)
                        {
                            foreach(DataRow row in layOCS2006.LayoutTable.Rows)
                            {
                                if(row.RowState == DataRowState.Modified)
                                {
                                    string cmdText = string.Empty;
                                    BindVarCollection bindVals = new BindVarCollection();

                                    cmdText = @"UPDATE OCS2006
                                                   SET UPD_ID       = :q_user_id ,
                                                       UPD_DATE     =  SYSDATE   ,
                                                       HANGMOG_CODE = :f_hangmog_code,
                                                       SURYANG      = :f_suryang    ,
                                                       NALSU        = :f_nalsu      ,
                                                       ORD_DANUI    = :f_ord_danui  ,
                                                       BOGYONG_CODE = :f_bogyong_code,
                                                       JUSA_CODE    = :f_jusa_code  ,
                                                       JUSA_SPD_GUBUN = :f_jusa_spd_gubun,
                                                       DV           = :f_dv         ,
                                                       DV_TIME      = :f_dv_time    ,
                                                       INSULIN_FROM = :f_insulin_from   ,
                                                       INSULIN_TO   = :f_insulin_to ,
                                                       TIME_GUBUN   = :f_time_gubun ,
                                                       BOM_YN       = :f_bom_yn     ,
                                                       BOM_SOURCE_KEY = :f_bom_source_key,
                                                       DIRECT_GUBUN = :f_direct_gubun,
                                                       DIRECT_CODE  = :f_direct_code,
                                                       DIRECT_DETAIL = :f_direct_detail
                                                 WHERE FKOCS2005    = :f_fkocs2005
                                                   AND SEQ          = :f_seq
                                                   AND HOSP_CODE    = :f_hosp_code";

                                    bindVals.Add("q_user_id",           this.mMemb);
                                    bindVals.Add("f_hangmog_code",      row["hangmog_code"].ToString());
                                    bindVals.Add("f_suryang",           row["suryang"].ToString());
                                    bindVals.Add("f_nalsu",             row["nalsu"].ToString());
                                    bindVals.Add("f_ord_danui",         row["ord_danui"].ToString());
                                    bindVals.Add("f_bogyong_code",      row["bogyong_code"].ToString());
                                    bindVals.Add("f_jusa_code",         row["jusa_code"].ToString());
                                    bindVals.Add("f_jusa_spd_gubun",    row["jusa_spd_gubun"].ToString());
                                    bindVals.Add("f_dv",                row["dv"].ToString());
                                    bindVals.Add("f_dv_time",           row["dv_time"].ToString());
                                    bindVals.Add("f_insulin_from",      row["insulin_from"].ToString());
                                    bindVals.Add("f_insulin_to",        row["insulin_to"].ToString());
                                    bindVals.Add("f_time_gubun",        row["time_gubun"].ToString());
                                    bindVals.Add("f_bom_source_key",    row["bom_source_key"].ToString());
                                    bindVals.Add("f_bom_yn",            row["bom_yn"].ToString());
                                    bindVals.Add("f_direct_gubun",      row["direct_gubun"].ToString());
                                    bindVals.Add("f_direct_code",       row["direct_code"].ToString());
                                    bindVals.Add("f_direct_detail",     row["direct_detail"].ToString());
                                    bindVals.Add("f_hosp_code",         mHospCode);
                                    bindVals.Add("f_fkocs2005",         row["fkocs2005"].ToString());
                                    bindVals.Add("f_seq",               row["seq"].ToString());

                                    Service.ExecuteNonQuery(cmdText, bindVals);

                                    // DB 처리 성공
                                    if (Service.ErrCode == 0)
                                    {
                                        e.IsBaseCall = false;
                                    }
                                    // DB 처리 실패
                                    else
                                    {
                                        ShowMessage("ServiceError");
                                        e.IsBaseCall = false;
                                    }
                                }
                                else if (row.RowState == DataRowState.Added)
                                {
                                    string cmdSeq = string.Empty;
                                    object Seq = null;
                                    object pkSeq = null;
                                    string cmdText = string.Empty;
                                    BindVarCollection bindVal = new BindVarCollection();
                                    BindVarCollection bindVals = new BindVarCollection();

                                    cmdSeq = @"SELECT NVL(MAX(SEQ), 0) + 1
                                                 FROM OCS2006
                                                WHERE FKOCS2005 = :f_fkocs2005
                                                  AND HOSP_CODE = :f_hosp_code";

                                    bindVal.Add("f_fkocs2005",      row["fkocs2005"].ToString());
                                    bindVal.Add("f_hosp_code",      mHospCode);

                                    Seq = Service.ExecuteScalar(cmdSeq, bindVal);

                                    cmdSeq = @"SELECT PK_SEQ
                                                 FROM OCS2005
                                                WHERE PKOCS2005 = :f_fkocs2005
                                                  AND HOSP_CODE = :f_hosp_code";

                                    pkSeq = Service.ExecuteDataTable(cmdSeq, bindVal);

                                    cmdText = @"INSERT INTO OCS2006
                                                       ( SYS_DATE      , UPD_ID        , UPD_DATE      , BUNHO         ,
                                                         FKOCS2005     , SYS_ID        ,
                                                         FKINP1001     , ORDER_DATE    , INPUT_GUBUN   , DIRECT_GUBUN  ,
                                                         DIRECT_CODE   , PK_SEQ        , SEQ           , DIRECT_DETAIL ,
                                                         HOSP_CODE     ,
                                                         HANGMOG_CODE  , SURYANG       , NALSU         , ORD_DANUI     ,
                                                         BOGYONG_CODE  , JUSA_CODE     , JUSA_SPD_GUBUN, DV            ,
                                                         DV_TIME       , INSULIN_FROM  , INSULIN_TO    , TIME_GUBUN    ,
                                                         BOM_SOURCE_KEY, BOM_YN
                                                       )
                                                 VALUES
                                                       ( SYSDATE        , :q_user_id     , SYSDATE          , :f_bunho         ,
                                                         :f_fkocs2005   , :q_user_id     ,
                                                         :f_fkinp1001   , :f_order_date  , :f_input_gubun   , :f_direct_gubun  ,
                                                         :f_direct_code , :f_pk_seq      , :f_seq           , :f_direct_detail ,
                                                         :f_hosp_code   ,
                                                         :f_hangmog_code, :f_suryang     , :f_nalsu         , :f_ord_danui     ,
                                                         :f_bogyong_code, :f_jusa_code   , :f_jusa_spd_gubun, :f_dv            ,
                                                         :f_dv_time     , :f_insulin_from, :f_insulin_to    , :f_time_gubun    ,
                                                         :f_bom_source_key, :f_bom_yn
                                                       )";

                                    bindVals.Add("q_user_id",       this.mMemb);
                                    bindVals.Add("f_bunho",         mBunho);
                                    bindVals.Add("f_fkocs2005",     row["fkocs2005"].ToString());
                                    bindVals.Add("f_fkinp1001",     mFkinp1001.ToString());
                                    bindVals.Add("f_order_date",    row["order_date"].ToString());
                                    bindVals.Add("f_input_gubun",   row["input_gubun"].ToString());
                                    bindVals.Add("f_direct_gubun",  row["direct_gubun"].ToString());
                                    bindVals.Add("f_direct_code",   row["direct_code"].ToString());

                                    bindVals.Add("f_pk_seq",        row["pk_seq"].ToString());

                                    bindVals.Add("f_hangmog_code",  row["hangmog_code"].ToString());
                                    bindVals.Add("f_suryang",       row["suryang"].ToString());
                                    bindVals.Add("f_nalsu",         row["nalsu"].ToString());
                                    bindVals.Add("f_ord_danui",     row["ord_danui"].ToString());
                                    bindVals.Add("f_bogyong_code",  row["bogyong_code"].ToString());
                                    bindVals.Add("f_jusa_code",     row["jusa_code"].ToString());
                                    bindVals.Add("f_jusa_spd_gubun",row["jusa_spd_gubun"].ToString());
                                    bindVals.Add("f_dv",            row["dv"].ToString());
                                    bindVals.Add("f_dv_time",       row["dv_time"].ToString());
                                    bindVals.Add("f_insulin_from",  row["insulin_from"].ToString());
                                    bindVals.Add("f_insulin_to",    row["insulin_to"].ToString());
                                    bindVals.Add("f_time_gubun",    row["time_gubun"].ToString());
                                    bindVals.Add("f_bom_source_key",row["bom_source_key"].ToString());
                                    bindVals.Add("f_bom_yn",        row["bom_yn"].ToString());

                                    bindVals.Add("f_seq",           TypeCheck.NVL(row["seq"].ToString(), Seq).ToString()); //20101203
                                    bindVals.Add("f_direct_detail", row["direct_detail"].ToString());
                                    bindVals.Add("f_hosp_code",     mHospCode);

                                    Service.ExecuteNonQuery(cmdText, bindVals);

                                    // DB 처리 성공
                                    if (Service.ErrCode == 0)
                                    {
                                        e.IsBaseCall = false;
                                    }
                                    // DB 처리 실패
                                    else
                                    {
                                        ShowMessage("ServiceError");
                                        e.IsBaseCall = false;
                                    }
                                }
                            }
                        }
                        // DELETE END-----------------------------------------------------------------------------------------------*/
                    }
                    catch (Exception xe)
                    {
                        Service.RollbackTransaction();
                        XMessageBox.Show(xe.Message, "保存失敗", MessageBoxIcon.Error);
                        DataCall();
                        return;
                    }

                    Service.CommitTransaction();
                    SetMsg("保存が完了しました。", MsgType.Normal);
                    DataCall();

                    break;

                default:
                    break;
            }
        }
        #endregion

        private string DupCheck(string inputGubun, string dGubun, string dCode, string drtFrom, string drtTo, DataRowState rowState)
        {
            string returnValue = "";

            string cmdText = "";

            BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_bunho",        mBunho);
            bindVars.Add("f_fkinp1001",    mFkinp1001.ToString());
            bindVars.Add("f_input_gubun",  inputGubun);
            bindVars.Add("f_direct_gubun", dGubun);
            bindVars.Add("f_direct_code",  dCode);

            bindVars.Add("f_from_date",    drtFrom);
            bindVars.Add("f_to_date",      drtTo);

            DataTable rtTable = new DataTable();

            //if (rowState == DataRowState.Added || rowState == DataRowState.Modified)
            //{
            cmdText = @"SELECT A.DRT_FROM_DATE  ,
                               NVL(A.DRT_TO_DATE, '9998/12/31') DRT_TO_DATE ,
                               B.NUR_GR_NAME    ,
                               C.NUR_MD_NAME    ,
                               A.DIRECT_GUBUN   ,
                               A.DIRECT_CODE
                          FROM OCS2005 A ,
                               NUR0110 B ,
                               NUR0111 C
                         WHERE A.BUNHO        = :f_bunho
                           AND A.FKINP1001    = :f_fkinp1001
                           AND A.INPUT_GUBUN  = :f_input_gubun
                           AND A.HOSP_CODE    = FN_ADM_LOAD_HOSP_CODE()
                           
                           AND A.DIRECT_GUBUN = :f_direct_gubun
                           AND A.DIRECT_CODE  = :f_direct_code
                           AND A.PK_SEQ       = :f_pk_seq
                           
                           AND ( :f_from_date BETWEEN A.DRT_FROM_DATE AND NVL(A.DRT_TO_DATE, '9998/12/31')
                              OR NVL(:f_to_date, '9998/12/31') BETWEEN A.DRT_FROM_DATE AND NVL(A.DRT_TO_DATE, '9998/12/31') )
                           
                           AND A.DIRECT_GUBUN = B.NUR_GR_CODE
                           AND A.DIRECT_CODE  = C.NUR_MD_CODE
                           AND A.HOSP_CODE    = B.HOSP_CODE
                           AND B.HOSP_CODE    = C.HOSP_CODE
                         ORDER BY A.SYS_DATE ASC";
            //}

            rtTable = Service.ExecuteDataTable(cmdText, bindVars);

            if (rtTable.Rows.Count > 0)
            {
                string dupFrom = rtTable.Rows[0]["drt_from_date"].ToString().Remove(10);
                string dupTo   = rtTable.Rows[0]["drt_to_date"].ToString().Remove(10);
                string grName  = rtTable.Rows[0]["nur_gr_name"].ToString();
                string mdName  = rtTable.Rows[0]["nur_md_name"].ToString();
                returnValue = " 以下の指示期間と重複です。\n\r\n\r 指示名 : [ " + grName + " / " + mdName + " ]\n\r" +
                              " 重複期間 : [ " + dupFrom + " ] - [ " + TypeCheck.NVL(dupTo, "9998/12/31") + " ] \n\r\n\r" +
                              " 入力期間 : [ " + drtFrom + " ] - [ " + TypeCheck.NVL(drtTo, "9998/12/31") + " ]";
            }
            else if(rtTable.Rows.Count > 1)
            {
                returnValue = "";
            }
            return returnValue;
        }

        #region [날짜입력 유효성체크 이벤트]
        private void dtpOrderDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "") dtpOrderDate.SetDataValue(DateTime.Now.ToString("yyyy/MM/dd"));
            //mOrder_date = e.DataValue;

            //if (Convert.ToDateTime(dtpOrderDate.GetDataValue()) < EnvironInfo.GetSysDate()) btnDirect.Enabled = false;
            //else btnDirect.Enabled = true;

            DataCall();
        }
        #endregion

        #region [QueryStart/End Event]
        // OCS2005 데이타 조회시 바인드변수 세팅
        private void layOCS2005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOCS2005.SetBindVarValue("f_bunho", mBunho);
            this.layOCS2005.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.layOCS2005.SetBindVarValue("f_hosp_code", mHospCode);
            this.layOCS2005.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());
        }

        // OCS2016 데이타 조회시 바인드변수 세팅
        private void layOCS2006_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOCS2006.SetBindVarValue("f_bunho", mBunho);
            this.layOCS2006.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.layOCS2006.SetBindVarValue("f_hosp_code", mHospCode);
            this.layOCS2006.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());   //20101217 KHJ --
            this.layOCS2006.SetBindVarValue("f_pk_seq", grdOCS2005.GetItemString(grdOCS2005.CurrentRowNumber, "pk_seq"));
        }

        private void layOCS2005_SaveEnd(object sender, SaveEndEventArgs e)
        {
            grdOCS2005.Reset();
        }

        private void layOCS2006_QueryEnd(object sender, QueryEndEventArgs e)
        {
            grdOCS2006.Reset();

            if (this.tabInput_gubun.SelectedTab != null)
                this.LoadData(tabInput_gubun.SelectedTab.Tag.ToString());

            CheckExistsDirect();
        }

        #endregion

        #region [grdOCS2005 이벤트]
        private void grdOCS2005_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "direct_text" && e.DataRow["direct_cont_yn"].ToString() == "Y")
            {
                e.Protect = true;
            }

            if ((e.ColName == "drt_from_date" || e.ColName == "drt_from_time") && e.DataRow["siji_result_act_max_date"].ToString() != "")
            {
                e.Protect = true;
            }
        }

        private void grdOCS2005_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if ((e.ColName == "direct_text" && e.DataRow["direct_cont_yn"].ToString() == "Y") ||
                e.ColName != "direct_text" || (this.tabInput_gubun.SelectedTab != null && tabInput_gubun.SelectedTab.Tag.ToString() == "D%"))
            {
                e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
                e.BackColor = XColor.XDisplayBoxBackColor.Color; // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
            }
        }

        private void grdOCS2005_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            object previousValue = grid.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer);

            switch (e.ColName)
            {
                case "drt_from_date":

                    if (this.grdOCS2005.GetItemString(e.RowNumber, "siji_result_act_max_date") != "")
                    {
                        if (DateTime.Parse(this.grdOCS2005.GetItemString(e.RowNumber, "siji_result_act_max_date")) < DateTime.Parse(e.ChangeValue.ToString()))
                        {
                            XMessageBox.Show("既にこの指示事項に対して実施記録が存在します。ご確認して下さい", "確認");
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_from_date", previousValue.ToString());
                            //grdOCS2005.SetItemValue(e.RowNumber, "drt_from_time", "");
                            return;
                        }
                    }

                    if (grdOCS2005.GetItemString(e.RowNumber, "drt_to_date") != "")
                    {
                        if (BetweenDay(e.ChangeValue.ToString(), grdOCS2005.GetItemString(e.RowNumber, "drt_to_date")) < 0)
                        {
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", "");
                            return;
                        }
                    }
                    else
                    {
                        grdOCS2005.SetItemValue(e.RowNumber, "drt_from_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }

                    SetDrtFromDate(this.grdOCS2005, e.RowNumber, grdOCS2005.GetItemString(e.RowNumber, "drt_to_date"), grdOCS2005.GetItemString(e.RowNumber, "drt_to_time"));

                    break;

                case "drt_to_date":
                    if (grdOCS2005.GetItemString(e.RowNumber, "drt_to_date") != "")
                    {
                        if (this.grdOCS2005.GetItemString(e.RowNumber, "siji_result_act_max_date") != "")
                        {
                            if (DateTime.Parse(this.grdOCS2005.GetItemString(e.RowNumber, "siji_result_act_max_date")) > DateTime.Parse(e.ChangeValue.ToString()))
                            {
                                XMessageBox.Show("既にこの指示事項に対して実施記録が存在します。ご確認して下さい", "確認");
                                grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", previousValue.ToString());
                                //grdOCS2005.SetItemValue(e.RowNumber, "drt_to_time", "");
                            }
                        }

                        if (BetweenDay(grdOCS2005.GetItemString(e.RowNumber, "drt_from_date"), e.ChangeValue.ToString()) < 0)
                        {
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", "");
                            return;
                        }
                        else
                        {
                            grdOCS2005.SetItemValue(e.RowNumber, "continue_yn", "N");
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                        }
                    }
                    else
                        grdOCS2005.SetItemValue(e.RowNumber, "drt_to_time", "");

                    SetDrtFromDate(this.grdOCS2005, e.RowNumber, grdOCS2005.GetItemString(e.RowNumber, "drt_to_date"), grdOCS2005.GetItemString(e.RowNumber, "drt_to_time"));

                    break;
                case "drt_to_time":

                    if (this.grdOCS2005.GetItemString(e.RowNumber, "siji_result_act_max_date") != "")
                    {
                        if (DateTime.Parse(this.grdOCS2005.GetItemString(e.RowNumber, "siji_result_act_max_date")) > DateTime.Parse(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd")))
                        {
                            XMessageBox.Show("既にこの指示事項に対して実施記録が存在します。ご確認して下さい", "確認");
                            //grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", "");
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_time", previousValue.ToString());
                        }
                    }
                    else
                    {
                        if(this.grdOCS2005.GetItemString(e.RowNumber, "drt_to_date") == "")
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", dtpOrderDate.GetDataValue());

                        grdOCS2005.SetItemValue(e.RowNumber, "continue_yn", "N");
                    }

                    if (e.ChangeValue.ToString() != "")
                    {
                        if (this.grdOCS2005.GetItemString(e.RowNumber, "drt_to_date") == "")
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", dtpOrderDate.GetDataValue());

                        grdOCS2005.SetItemValue(e.RowNumber, "continue_yn", "N");
                    }

                    SetDrtFromDate(this.grdOCS2005, e.RowNumber, grdOCS2005.GetItemString(e.RowNumber, "drt_to_date"), grdOCS2005.GetItemString(e.RowNumber, "drt_to_time"));

                    break;

                case "continue_yn":

                    if (e.ChangeValue.ToString() == "Y")
                    {
                        grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", "");
                        grdOCS2005.SetItemValue(e.RowNumber, "drt_to_time", "");
                    }
                    else
                    {
                        grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", dtpOrderDate.GetDataValue());
                        grdOCS2005.SetItemValue(e.RowNumber, "drt_to_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                        
                    }

                    SetDrtFromDate(this.grdOCS2005, e.RowNumber, grdOCS2005.GetItemString(e.RowNumber, "drt_to_date"), grdOCS2005.GetItemString(e.RowNumber, "drt_to_time"));

                    break;

                default:
                    break;
            }

        }

        private void SetDrtFromDate(XEditGrid aGrd, int aCurrRow, string aInputDate, string aInputTime)
        {
            XEditGrid grd = aGrd;

            DateTime present = EnvironInfo.GetSysDateTime();

            string cmd_post = @"SELECT MIN(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD')||A.DRT_FROM_TIME) DRT_FROM_DATE
                                          FROM OCS2005 A
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.FKINP1001    = :f_fkinp1001
                                           AND A.DIRECT_GUBUN = :f_direct_gubun
                                           AND A.DIRECT_CODE  = :f_direct_code
                                           AND TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD')||A.DRT_FROM_TIME > TO_CHAR(TO_DATE(:f_kijun_date), 'YYYYMMDD')||:f_kijun_time
                                           AND A.PKOCS2005    <> :f_pkocs2005
                                        ";

            BindVarCollection bind_post = new BindVarCollection();
            bind_post.Add("f_hosp_code", EnvironInfo.HospCode);
            bind_post.Add("f_fkinp1001", grd.GetItemString(aCurrRow, "fkinp1001"));
            bind_post.Add("f_direct_gubun", grd.GetItemString(aCurrRow, "direct_gubun"));
            bind_post.Add("f_direct_code", grd.GetItemString(aCurrRow, "direct_code"));
            bind_post.Add("f_kijun_date", grd.GetItemString(aCurrRow, "drt_from_date").Replace("/", "").Replace("-", ""));
            bind_post.Add("f_kijun_time", present.ToString("HHmm"));
            bind_post.Add("f_pkocs2005", grd.GetItemString(aCurrRow, "pkocs2005"));
            //bind_post.Add("f_kijun_date", aInputDate);
            //bind_post.Add("f_kijun_time", aInputTime);

            object obj_post = Service.ExecuteScalar(cmd_post, bind_post);
            DateTime post_date = new DateTime();
            DateTime input_date = new DateTime();
            if (obj_post != null && obj_post.ToString() != "")
            {
                post_date = DateTime.Parse(obj_post.ToString().Substring(0, 4) + "/"
                                           + obj_post.ToString().Substring(4, 2) + "/"
                                           + obj_post.ToString().Substring(6, 2) + " "
                                           + obj_post.ToString().Substring(8, 2) + ":"
                                           + obj_post.ToString().Substring(10, 2)
                                           );

                

                grd.SetItemValue(aCurrRow, "drt_to_date", post_date.ToString("yyyy/MM/dd"));
                grd.SetItemValue(aCurrRow, "drt_to_time", post_date.AddMinutes(-1).ToString("HHmm"));
                grd.SetItemValue(aCurrRow, "continue_yn", "N");

                if (aInputDate != "" && aInputTime != "")
                {
                    input_date = DateTime.Parse(aInputDate + " " + aInputTime.Substring(0, 2) + ":" + aInputTime.Substring(2, 2));
                    if(input_date < post_date)
                    {
                        grd.SetItemValue(aCurrRow, "drt_to_date", aInputDate);
                        grd.SetItemValue(aCurrRow, "drt_to_time", aInputTime);
                    }
                }
            }
        }

        private int BetweenDay(string A, string B)
        {
            int between = -1;
            if (!TypeCheck.IsDateTime(A))
                return between;

            if (!TypeCheck.IsDateTime(B))
                return between;

            string cmdText = string.Empty;
            BindVarCollection bindVals = new BindVarCollection();

            cmdText = "SELECT TO_DATE('" + B + "', 'YYYY/MM/DD') - TO_DATE('" + A + "', 'YYYY/MM/DD') FROM DUAL ";

            between = Int32.Parse(Service.ExecuteScalar(cmdText, bindVals).ToString());

            return between;
        }

        #endregion

        #region [Funtion]

        private void LoadData(string arInput_gubun)
        {
            //화면에 있는 Data를 적용한다.
            if (!ApplyCurrentData()) return ;

            grdOCS2005.Reset();
            grdOCS2006.Reset();


            //화면에 해당 Input_gubun Data를 가져온다.
            for (int i = 0; i < layOCS2005.RowCount; i++)
            {
                if (arInput_gubun == "D%")
                {
                    if (layOCS2005.LayoutTable.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                        grdOCS2005.LayoutTable.ImportRow(layOCS2005.LayoutTable.Rows[i]);
                }
                else
                {
                    if (layOCS2005.LayoutTable.Rows[i]["input_gubun"].ToString() == arInput_gubun)
                        grdOCS2005.LayoutTable.ImportRow(layOCS2005.LayoutTable.Rows[i]);
                }
            }

            grdOCS2005.DisplayData();

            //화면에 Load된 Data를 삭제한다.
            for (int i = 0; i < layOCS2005.RowCount; i++)
            {
                if (arInput_gubun == "D%")
                {
                    if (layOCS2005.LayoutTable.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    {
                        layOCS2005.LayoutTable.Rows.Remove(layOCS2005.LayoutTable.Rows[i]);
                        i--;
                    }

                }
                else
                {
                    if (layOCS2005.LayoutTable.Rows[i]["input_gubun"].ToString() == arInput_gubun)
                    {
                        layOCS2005.LayoutTable.Rows.Remove(layOCS2005.LayoutTable.Rows[i]);
                        i--;
                    }
                }
            }




            for (int i = 0; i < layOCS2006.RowCount; i++)
            {
                if (arInput_gubun == "D%")
                {
                    if (layOCS2006.LayoutTable.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                        grdOCS2006.LayoutTable.ImportRow(layOCS2006.LayoutTable.Rows[i]);
                }
                else
                {
                    if (layOCS2006.LayoutTable.Rows[i]["input_gubun"].ToString() == arInput_gubun)
                        grdOCS2006.LayoutTable.ImportRow(layOCS2006.LayoutTable.Rows[i]);
                }
            }

            grdOCS2006.DisplayData();



            ///*
            //화면에 Load된 Data를 삭제한다.
            for (int i = 0; i < layOCS2006.RowCount; i++)
            {
                if (arInput_gubun == "D%")
                {
                    if (layOCS2006.LayoutTable.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    {
                        layOCS2006.LayoutTable.Rows.Remove(layOCS2006.LayoutTable.Rows[i]);
                        i--;
                    }

                }
                else
                {
                    if (layOCS2006.LayoutTable.Rows[i]["input_gubun"].ToString() == arInput_gubun)
                    {
                        layOCS2006.LayoutTable.Rows.Remove(layOCS2006.LayoutTable.Rows[i]);
                        i--;
                    }
                }
            }
            //*/


        }
        private bool ChkData()
        {
            for (int i = 0; i < this.grdOCS2005.RowCount; i++)
            {
                if (this.grdOCS2005.GetRowState(i) == DataRowState.Unchanged) continue;

                string from_datetime = this.grdOCS2005.GetItemDateTime(i, "drt_from_date").ToString("yyyyMMdd") + this.grdOCS2005.GetItemString(i, "drt_from_time");
                string to_datetime   = "";
                
                if(this.grdOCS2005.GetItemString(i, "drt_to_date") == "")
                    to_datetime = "999812312359";
                else
                    to_datetime = this.grdOCS2005.GetItemDateTime(i, "drt_to_date").ToString("yyyyMMdd") + this.grdOCS2005.GetItemString(i, "drt_to_time");

                if (long.Parse(from_datetime) > long.Parse(to_datetime))
                {
                    XMessageBox.Show("指示事項の開始日付と終了日付が正しくありません", "確認");
                    this.grdOCS2005.SetFocusToItem(i, "drt_to_date");
                    return false;
                }
            }
            return true;
        }

        private bool ApplyCurrentData()
        {
            #region ……… 기간중복 체크 ………
            for (int i = 0; i < grdOCS2005.RowCount; i++)
            {
                string msg = "";

                if (grdOCS2005.LayoutTable.Rows[i].RowState == DataRowState.Added)
                {

                    msg = DupCheck(grdOCS2005.GetItemString(i, "input_gubun")
                                 , grdOCS2005.GetItemString(i, "direct_gubun")
                                 , grdOCS2005.GetItemString(i, "direct_code")
                                 , grdOCS2005.GetItemString(i, "drt_from_date")
                                 , grdOCS2005.GetItemString(i, "drt_to_date")
                                 , grdOCS2005.LayoutTable.Rows[i].RowState);

                    if (msg.Trim().Length > 0)
                    {
                        XMessageBox.Show(msg, "保存失敗", MessageBoxIcon.Hand);
                        grdOCS2005.SelectRow(i);
                        return false;
                    }
                }
            }
            #endregion

            //화면에 있는 Data를 적용한다.
            foreach (DataRow row in this.grdOCS2005.LayoutTable.Select("", ""))
            {
                this.layOCS2005.LayoutTable.ImportRow(row);
            }

            //삭제된 Data를 적용한다.
            if (grdOCS2005.DeletedRowTable != null)
            {
                foreach (DataRow row in this.grdOCS2005.DeletedRowTable.Select("", ""))
                {
                    this.layOCS2005.LayoutTable.ImportRow(row);
                    this.layOCS2005.DeleteRow(layOCS2005.RowCount - 1);
                }
            }

            //화면에 있는 Data를 적용한다.
            foreach (DataRow row in this.grdOCS2006.LayoutTable.Select("", ""))
            {
                this.layOCS2006.LayoutTable.ImportRow(row);
            }

            //삭제된 Data를 적용한다.
            if (grdOCS2006.DeletedRowTable != null)
            {
                foreach (DataRow row in this.grdOCS2006.DeletedRowTable.Select("", ""))
                {
                    this.layOCS2006.LayoutTable.ImportRow(row);
                    this.layOCS2006.DeleteRow(layOCS2006.RowCount - 1);
                }
            }

            return true;
        }

        private void CheckExistsDirect()
        {
                //if(layTabColor
            foreach (IHIS.X.Magic.Controls.TabPage page in this.tabInput_gubun.TabPages)
            {
                if (layOCS2005.LayoutTable.Select(" input_gubun = '" + page.Tag.ToString() + "' ", "").Length > 0 ||
                    grdOCS2005.LayoutTable.Select(" input_gubun = '" + page.Tag.ToString() + "' ", "").Length > 0)
                    page.TitleTextColor = Color.Red;
                else
                    page.TitleTextColor = Color.Black;

            }
        }

        private string Max_pk_seq(int num)
        {
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVals = new BindVarCollection();

            cmdText = @"SELECT NVL(MAX(PK_SEQ), 0) + 1
                          FROM OCS2005
                         WHERE BUNHO       = :f_bunho
                           AND FKINP1001   = :f_fkinp1001
                           AND ORDER_DATE  = :f_order_date
                           AND INPUT_GUBUN = :f_input_gubun
                           AND HOSP_CODE   = :f_hosp_code";

            bindVals.Add("f_bunho", this.grdOCS2005.GetItemValue(num, "bunho").ToString());
            bindVals.Add("f_fkinp1001", this.grdOCS2005.GetItemValue(num, "fkinp1001").ToString());
            bindVals.Add("f_order_date", this.grdOCS2005.GetItemValue(num, "order_date").ToString());
            bindVals.Add("f_input_gubun", this.grdOCS2005.GetItemValue(num, "input_gubun").ToString());
            bindVals.Add("f_hosp_code", mHospCode);

            retVal = Service.ExecuteScalar(cmdText, bindVals);

            return retVal.ToString();
        }

        private void DataCall()
        {
            layOCS2005.Reset();
            layOCS2006.Reset();
            grdOCS2005.Reset();
            grdOCS2006.Reset();

            layOCS2005.QueryLayout(false);
            layOCS2006.QueryLayout(false);

            //CheckExistsDirect();
        }

        #endregion

        #region [지시사항 Setting]

        private void SetDirectInfo(MultiLayout layDirectInfo, MultiLayout layDirectDetailInfo)
        {
            if (this.tabInput_gubun.SelectedTab == null) return;

            //간호지시사항인 경우 tab을 옮긴다.
            if (this.tabInput_gubun.SelectedTab.Tag.ToString() == "D%")
                this.tabInput_gubun.SelectedIndex = 0;

            string direct_gubun = "", direct_code = "", filter = "", pk_seq = "", seq = "";
            int insertRow = -1;

            foreach (DataRow row in layDirectInfo.LayoutTable.Rows)
            {
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();
                filter = " direct_gubun = '" + direct_gubun + "' and  direct_code = '" + direct_code + "' ";

                //기존에 등록되어진 지시사항 UPDATE
                if (grdOCS2005.LayoutTable.Select(filter, "").Length > 0)
                {
                    for (int i = 0; i < grdOCS2005.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS2005.GetItemString(i, "direct_gubun") && direct_code == grdOCS2005.GetItemString(i, "direct_code"))
                        {
                            foreach (XEditGridCell cell in grdOCS2005.CellInfos)
                            {
                                if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS2005.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            }

                            //세부내역은 삭제
                            for (int j = 0; j < grdOCS2006.RowCount; j++)
                            {
                                if (direct_gubun == grdOCS2006.GetItemString(j, "direct_gubun") &&
                                   direct_code == grdOCS2006.GetItemString(j, "direct_code"))
                                {
                                    grdOCS2006.DeleteRow(j);
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
                else
                {
                    //신규등록
                    insertRow = grdOCS2005.InsertRow(-1);

                    foreach (XEditGridCell cell in grdOCS2005.CellInfos)
                    {
                        if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                            grdOCS2005.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                    }

                    grdOCS2005.SetItemValue(insertRow, "bunho",             mBunho);
                    grdOCS2005.SetItemValue(insertRow, "fkinp1001",         mFkinp1001);
                    grdOCS2005.SetItemValue(insertRow, "order_date",        mOrder_date);
                    grdOCS2005.SetItemValue(insertRow, "input_gubun",       this.tabInput_gubun.SelectedTab.Tag.ToString());
                    grdOCS2005.SetItemValue(insertRow, "input_gubun_name",  this.tabInput_gubun.SelectedTab.Title);
                    grdOCS2005.SetItemValue(insertRow, "drt_from_date",     dtpOrderDate.GetDataValue());
                    grdOCS2005.SetItemValue(insertRow, "continue_yn",       "Y");
                    //grdOCS2005.SetItemValue(insertRow, "drt_to_date",       dtpOrderDate.GetDataValue());
                    grdOCS2005.SetItemValue(insertRow, "drt_from_time",     EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    grdOCS2005.SetItemValue(insertRow, "drt_to_date",       null);

                    ///////////////////////////////////////////////////////////////////////////////////////////

                    // 사용자지시사항에서 가져온 항목과 일반지시사항에서 가져온 항목들이 섞이게 되서 pk_seq를 저장하기 전에 일괄적으로 재셋팅
                    // 셋팅하는 기준은 grdOCS2005 의 pkocs2005 값과 일치하는 grdOCS2006 의 값의 항목에 셋팅
                    int maxPkSeq = -1;

                    maxPkSeq = Convert.ToInt32(row["pk_seq"]);

                    for (int i = 0; i < grdOCS2005.RowCount; i++)
                    {
                        if (maxPkSeq <= grdOCS2005.GetItemInt(i, "pk_seq"))
                        {
                            maxPkSeq = grdOCS2005.GetItemInt(i, "pk_seq") + 1;
                        }
                    }

                    string cmdText = @"SELECT NVL(MAX(PK_SEQ), 0) PK_SEQ
  FROM OCS2005
 WHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
   AND BUNHO       = '" + mBunho + @"'
   AND FKINP1001   = '" + mFkinp1001 + @"'
   AND ORDER_DATE  = '" + mOrder_date + @"'
   AND INPUT_GUBUN = '" + tabInput_gubun.SelectedTab.Tag.ToString() + @"'";

                    int dbPkSeq = Convert.ToInt32(Service.ExecuteScalar(cmdText));

                    if (maxPkSeq <= dbPkSeq)
                    {
                        maxPkSeq = dbPkSeq + 1;
                    }

                    grdOCS2005.SetItemValue(insertRow, "pk_seq", maxPkSeq);

                    ///////////////////////////////////////////////////////////////////////////////////////////


                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////
            foreach (DataRow row in layDirectDetailInfo.LayoutTable.Rows)
            {
                //if (row.RowState == DataRowState.Unchanged) continue;

                //기존에 등록되어진 지시사항 UPDATE
                //if (row.RowState == DataRowState.Modified)
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();
                pk_seq = row["pk_seq"].ToString();
                seq = row["seq"].ToString();
                filter = " direct_gubun = '" + direct_gubun + "' and  direct_code = '" + direct_code + "' and pk_seq = '" + pk_seq + "' and seq = '" + seq + "'";
                if (grdOCS2006.LayoutTable.Select(filter, "").Length > 0)
                {
                    for (int i = 0; i < grdOCS2006.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS2006.GetItemString(i, "direct_gubun") &&
                            direct_code == grdOCS2006.GetItemString(i, "direct_code") &&
                            pk_seq == grdOCS2006.GetItemString(i, "pk_seq") &&
                            seq == grdOCS2006.GetItemString(i, "seq"))
                        {
                            foreach (XEditGridCell cell in grdOCS2006.CellInfos)
                            {
                                if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS2006.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            }

                            break;
                        }
                    }
                }
                else    //새로이 등록한 지시사항 Insert
                {
                    insertRow = grdOCS2006.InsertRow(-1);

                    foreach (XEditGridCell cell in grdOCS2006.CellInfos)
                    {
                        if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                            grdOCS2006.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                    }

                    grdOCS2006.SetItemValue(insertRow, "bunho",       mBunho);
                    grdOCS2006.SetItemValue(insertRow, "fkinp1001",   mFkinp1001);
                    grdOCS2006.SetItemValue(insertRow, "order_date",  mOrder_date);
                    grdOCS2006.SetItemValue(insertRow, "input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());
                    //grdOCS2006.SetItemValue(insertRow, "order_date", dtpOrderDate.GetDataValue());  // 20101217 KHJ
                }
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // 사용자지시사항에서 가져온 항목과 일반지시사항에서 가져온 항목들이 섞이게 되서 pk_seq를 저장하기 전에 일괄적으로 재셋팅 //
            // 셋팅하는 기준은 grdOCS2005 의 pkocs2005 값과 일치하는 grdOCS2006 의 값의 항목에 셋팅                                   //
            for (int i = 0; i < grdOCS2005.RowCount; i++)                                                                             //
            {
                for (int j = 0; j < grdOCS2006.RowCount; j++)
                {
                    if (grdOCS2005.GetItemString(i, "pkocs2005") == grdOCS2006.GetItemString(j, "fkocs2005"))
                    {
                        grdOCS2006.SetItemValue(j, "pk_seq", grdOCS2005.GetItemString(i, "pk_seq"));
                    }
                }                                                                                                                     //
            }                                                                                                                         //
            //                                                                                                                        //
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            CheckExistsDirect();
        }

        private void SetDirectInfo(MultiLayout layDeleteDirectInfo, MultiLayout layDirectInfo, MultiLayout layDeleteDirectDetailInfo, MultiLayout layDirectDetailInfo)
        {
            DateTime present = EnvironInfo.GetSysDateTime();
            /*
                DirectDetailInfoが削除、追加、修正された場合は新しいOCS2005を作成してその下に追加する。
            */
            #region []

            //int DirectDetailInfoChangedCnt = 0;
            //for (int i = 0; i < layDirectDetailInfo.LayoutTable.Rows.Count; i++)
            //{
            //    if (layDirectDetailInfo.LayoutTable.Rows[i].RowState(i) != DataRowState.Unchanged)
            //    {
            //        DirectDetailInfoChangedCnt++;
            //    }
            //}

            //if (layDeleteDirectDetailInfo.LayoutTable.Rows.Count > 0
            //    || DirectDetailInfoChangedCnt > 0)
            //{

            
            //}

            #endregion

            #region OCS2005
            //layDeleteData = layDeleteDirectInfo.Copy();
            //layDeleteDetail = layDeleteDirectDetailInfo.Copy();

            if (this.tabInput_gubun.SelectedTab == null) return;

            //간호지시사항인 경우 tab을 옮긴다.
            if (this.tabInput_gubun.SelectedTab.Tag.ToString() == "D%")
                this.tabInput_gubun.SelectedIndex = 0;

            string direct_gubun = "", direct_code = "", pk_seq = "", seq = "", pkocs2005 = "";
            int insertRow = -1;

            

            foreach (DataRow row in layDirectInfo.LayoutTable.Rows)
            {
                if (row.RowState == DataRowState.Unchanged) continue;

                //기존에 등록되어진 지시사항 UPDATE
                //if (row.RowState == DataRowState.Modified)
                //{
                //    direct_gubun = row["direct_gubun"].ToString();
                //    direct_code = row["direct_code"].ToString();

                //    for (int i = 0; i < grdOCS2005.RowCount; i++)
                //    {
                //        if (direct_gubun == grdOCS2005.GetItemString(i, "direct_gubun") && direct_code == grdOCS2005.GetItemString(i, "direct_code"))
                //        {
                //            foreach (XEditGridCell cell in grdOCS2005.CellInfos)
                //            {
                //                if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                //                    grdOCS2005.SetItemValue(i, cell.CellName, row[cell.CellName]);

                //                if(grdOCS2005.GetItemString(i, cell.CellName).Equals("continue_yn"))
                //                {
                //                    if (grdOCS2005.GetItemString(i, "continue_yn") != "Y" &&
                //                        grdOCS2005.GetItemString(i, "drt_to_date") == ""     )
                //                    {
                //                        grdOCS2005.SetItemValue(i, "continue_yn", "Y");
                //                    }
                //                }
                //            }

                //            break;
                //        }
                //    }
                //}

                if (row.RowState == DataRowState.Modified)
                {
                    pkocs2005 = row["pkocs2005"].ToString();
                    
                    for (int i = 0; i < grdOCS2005.RowCount; i++)
                    {
                        if (pkocs2005 == grdOCS2005.GetItemString(i, "pkocs2005"))
                        {
                            foreach (XEditGridCell cell in grdOCS2005.CellInfos)
                            {
                                if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS2005.SetItemValue(i, cell.CellName, row[cell.CellName]);

                                if (grdOCS2005.GetItemString(i, cell.CellName).Equals("continue_yn"))
                                {
                                    if (grdOCS2005.GetItemString(i, "continue_yn") != "Y" &&
                                        grdOCS2005.GetItemString(i, "drt_to_date") == "")
                                    {
                                        grdOCS2005.SetItemValue(i, "continue_yn", "Y");
                                    }
                                }
                            }

                            break;
                        }
                    }
                }

                //새로이 등록한 지시사항 Insert
                if (row.RowState == DataRowState.Added)
                {
                    insertRow = grdOCS2005.InsertRow(-1);

                    foreach (XEditGridCell cell in grdOCS2005.CellInfos)
                    {
                        if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                        {
                            grdOCS2005.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                        }
                    }

                    grdOCS2005.SetItemValue(insertRow, "bunho", mBunho);
                    grdOCS2005.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
                    //grdOCS2005.SetItemValue(insertRow, "order_date", mOrder_date);    // 2011/05/31
                    grdOCS2005.SetItemValue(insertRow, "order_date", dtpOrderDate.GetDataValue());  // 2011/05/31
                    grdOCS2005.SetItemValue(insertRow, "drt_from_time", present.ToString("HHmm"));  // 2013/12/20
                    grdOCS2005.SetItemValue(insertRow, "input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());
                    grdOCS2005.SetItemValue(insertRow, "input_gubun_name", this.tabInput_gubun.SelectedTab.Title);

                    string cmd_post = @"SELECT MIN(TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD')||A.DRT_FROM_TIME) DRT_FROM_DATE
                                          FROM OCS2005 A
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.FKINP1001    = :f_fkinp1001
                                           AND A.DIRECT_GUBUN = :f_direct_gubun
                                           AND A.DIRECT_CODE  = :f_direct_code
                                           AND TO_CHAR(A.DRT_FROM_DATE, 'YYYYMMDD')||A.DRT_FROM_TIME > TO_CHAR(TO_DATE(:f_kijun_date), 'YYYYMMDD')||:f_kijun_time
                                        ";

                    BindVarCollection bind_post = new BindVarCollection();
                    bind_post.Add("f_hosp_code",    EnvironInfo.HospCode);
                    bind_post.Add("f_fkinp1001",    row["fkinp1001"].ToString());
                    bind_post.Add("f_direct_gubun", row["direct_gubun"].ToString());
                    bind_post.Add("f_direct_code",  row["direct_code"].ToString());
                    bind_post.Add("f_kijun_date",   row["drt_from_date"].ToString().Replace("/", "").Replace("-", ""));
                    bind_post.Add("f_kijun_time",   present.ToString("HHmm"));

                    object obj_post = Service.ExecuteScalar(cmd_post, bind_post);
                    DateTime post_date = new DateTime();
                    if (obj_post != null && obj_post.ToString() != "")
                    {
                        post_date = DateTime.Parse(  obj_post.ToString().Substring(0, 4) + "/" 
                                                   + obj_post.ToString().Substring(4, 2) + "/" 
                                                   + obj_post.ToString().Substring(6, 2) + " " 
                                                   + obj_post.ToString().Substring(8, 2) + ":"
                                                   + obj_post.ToString().Substring(10, 2)
                                                   );
                        grdOCS2005.SetItemValue(insertRow, "drt_to_date", post_date.ToString("yyyy/MM/dd"));
                        grdOCS2005.SetItemValue(insertRow, "drt_to_time", post_date.AddMinutes(-1).ToString("HHmm"));
                        grdOCS2005.SetItemValue(insertRow, "continue_yn", "N");
                    }


                    
                }
            }
            #endregion OCS2005


            #region OCS2006
            //지시사항 등록화면에서 삭제된 지시사항세부내역건 삭제			
            foreach (DataRow row in layDeleteDirectDetailInfo.LayoutTable.Rows)
            {
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();
                pk_seq = row["pk_seq"].ToString();
                for (int i = 0; i < grdOCS2006.RowCount; i++)
                {
                    if (direct_gubun == grdOCS2006.GetItemString(i, "direct_gubun") &&
                        direct_code == grdOCS2006.GetItemString(i, "direct_code") &&
                        pk_seq == grdOCS2006.GetItemString(i, "pk_seq"))
                    {
                        grdOCS2006.DeleteRow(i);
                        break;
                    }
                }
            }

            foreach (DataRow row in layDirectDetailInfo.LayoutTable.Rows)
            {
                if (row.RowState == DataRowState.Unchanged) continue;

                //기존에 등록되어진 지시사항 UPDATE
                if (row.RowState == DataRowState.Modified)
                {
                    direct_gubun = row["direct_gubun"].ToString();
                    direct_code = row["direct_code"].ToString();
                    pk_seq = row["pk_seq"].ToString();
                    seq = row["seq"].ToString();


                    for (int i = 0; i < grdOCS2006.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS2006.GetItemString(i, "direct_gubun") &&
                            direct_code == grdOCS2006.GetItemString(i, "direct_code") &&
                            pk_seq == grdOCS2006.GetItemString(i, "pk_seq") &&
                            seq == grdOCS2006.GetItemString(i, "seq")
                            )
                        {
                            foreach (XEditGridCell cell in grdOCS2006.CellInfos)
                            {
                                if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS2006.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            }

                            break;
                        }
                    }
                }

                //새로이 등록한 지시사항 Insert
                if (row.RowState == DataRowState.Added)
                {
                    insertRow = grdOCS2006.InsertRow(-1);

                    foreach (XEditGridCell cell in grdOCS2006.CellInfos)
                    {
                        if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                            grdOCS2006.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                    }

                    grdOCS2006.SetItemValue(insertRow, "bunho", mBunho);
                    grdOCS2006.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
                    //grdOCS2006.SetItemValue(insertRow, "order_date", mOrder_date);    // 2011/05/31
                    grdOCS2006.SetItemValue(insertRow, "order_date", dtpOrderDate.GetDataValue());  // 20101217 KHJ
                    grdOCS2006.SetItemValue(insertRow, "input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());
                }
            }
            #endregion OCS2006

            //지시사항 등록화면에서 삭제된 건 삭제
            foreach (DataRow row in layDeleteDirectInfo.LayoutTable.Rows)
            {
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();

                pkocs2005 = "";
                pkocs2005 = row["pkocs2005"].ToString();

                for (int i = 0; i < grdOCS2005.RowCount; i++)
                {
                    if (direct_gubun == grdOCS2005.GetItemString(i, "direct_gubun") && direct_code == grdOCS2005.GetItemString(i, "direct_code") && grdOCS2005.GetItemString(i, "pkocs2005") == pkocs2005)
                    {
                        //grdOCS2005.DeleteRow(i);
                        this.grdOCS2005.SetItemValue(i, "continue_yn", "N");
                        this.grdOCS2005.SetItemValue(i, "drt_to_date", dtpOrderDate.GetDataValue());
                        this.grdOCS2005.SetItemValue(i, "drt_to_time", present.AddMinutes(-1).ToString("HHmm"));
                        break;
                    }
                }
            }

            CheckExistsDirect();

        }

        #endregion

        private void grdOCS2005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOCS2005.SetBindVarValue("f_bunho", mBunho);
            this.grdOCS2005.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.grdOCS2005.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdOCS2005.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());
            this.grdOCS2005.SetBindVarValue("f_input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());
        }

        private void grdOCS2005_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && e.Clicks == 2 && grdOCS2005.CurrentColName == "continue_yn")
            {
                if (grdOCS2005.CurrentRowNumber < 0)
                {
                    for (int i = 0; i < grdOCS2005.RowCount; i++)
                    {
                        if (grdOCS2005.GetItemString(i, "continue_yn") == "N")
                        {
                            grdOCS2005.SetItemValue(i, "continue_yn", "Y");
                        }
                        else
                        {
                            grdOCS2005.SetItemValue(i, "continue_yn", "N");
                        }
                    }
                }
            }
        }

        private void layAllOCS2005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layAllOCS2005.SetBindVarValue("f_bunho", mBunho);
            this.layAllOCS2005.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.layAllOCS2005.SetBindVarValue("f_hosp_code", mHospCode);
            this.layAllOCS2005.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());
        }

        private void tabInput_gubun_SelectionChanging(object sender, EventArgs e)
        {
            XTabControl aTab = sender as XTabControl;

            tabInput_gubun.SelectedIndex = this.mBeforeSelectedTabIndex;

            // 未保存データ確認
            for (int i = 0; i < this.grdOCS2005.DisplayRowCount; i++)
            {
                if (this.grdOCS2005.GetRowState(i) != DataRowState.Unchanged
                    && this.mBeforeSelectedTabIndex != aTab.SelectedIndex)
                {
                    if (XMessageBox.Show("保存されてないデータが存在します。保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.btnList.PerformClick(FunctionType.Update);
                    }
                }
            }
        }
    }
}