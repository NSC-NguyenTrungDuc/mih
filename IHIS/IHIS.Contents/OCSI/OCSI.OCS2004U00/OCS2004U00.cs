using System;
using System.Collections.Generic;
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
                        SetDirectInfo((MultiLayout)commandParam["DELETEDIRECT"], (MultiLayout)commandParam["DIRECT"], (MultiLayout)commandParam["DELETEDIRECTDETAIL"], (MultiLayout)commandParam["DIRECT_DETAIL"]);
                    }

                    break;

                    #endregion

                case "OCS0304Q00": // 약속지시사항

                    #region

                    if (commandParam.Contains("OCS0305"))
                    {
                        SetDirectInfo((MultiLayout)commandParam["OCS0305"]);
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

                }
                catch (Exception ex)
                {
                    XMessageBox.Show(ex.Message, "");
                }
            }
            else
            {
                dtpOrderDate.SetDataValue("2008-04-17"); //DateTime.Now.ToString("yyyy/MM/dd"); 

                mBunho = "001262154";
                mFkinp1001 = 1581476;
                mOrder_date = dtpOrderDate.GetDataValue();
                mInput_gubun = "D0";
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

            if (mArgOCS2005 != null)
            {
                this.SetDirectInfo(mArgOCS2005);
            }

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
            if (tabInput_gubun.SelectedTab == null) return;

            // 체크에 따라 이미지를 변경
            foreach (IHIS.X.Magic.Controls.TabPage page in tabInput_gubun.TabPages)
            {
                if (tabInput_gubun.SelectedTab == page)
                    page.ImageIndex = 1;
                else
                    page.ImageIndex = 0;
            }

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
            IHIS.Framework.MultiLayout dloParaOCS2005 = grdOCS2005.CopyToLayout();
            IHIS.Framework.MultiLayout dloParaOCS2016 = grdOCS2016.CopyToLayout();

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("input_gubun", mInput_gubun);
            openParams.Add("direct_mode", "2");
            openParams.Add("order_date", dtpOrderDate.GetDataValue());
            openParams.Add("DIRECT", dloParaOCS2005);
            openParams.Add("DIRECT_DETAIL", dloParaOCS2016);

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        // 세트지시사항
        private void btnYaksokDirect_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("memb", UserInfo.UserID);

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

                case FunctionType.Update:

                    // -- OCS2005 ---------------------------------------------------------------------------------------------------

                    foreach (DataRow row in layOCS2005.LayoutTable.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            string cmdText = string.Empty;
                            BindVarCollection bindVals = new BindVarCollection();

                            cmdText = @"UPDATE OCS2005
                                           SET UPD_ID         = :q_user_id       ,
                                               UPD_DATE       =  SYSDATE         ,
                                               HANGMOG_CODE_1 = :f_hangmog_code_1,
                                               HANGMOG_CODE_2 = :f_hangmog_code_2,
                                               HANGMOG_CODE_3 = :f_hangmog_code_3,
                                               HANGMOG_CODE_4 = :f_hangmog_code_4,
                                               NUM_VAL1       = :f_num_val1      ,
                                               NUM_VAL2       = :f_num_val2      ,
                                               NUM_VAL3       = :f_num_val3      ,
                                               NUM_VAL4       = :f_num_val4      ,
                                               DIRECT_TEXT    = :f_direct_text   ,
                                               DRT_FROM_DATE  = :f_drt_from_date ,
                                               DRT_TO_DATE    = :f_drt_to_date   ,
                                               CONTINUE_YN    = :f_continue_yn  
                                         WHERE BUNHO          = :f_bunho
                                           AND FKINP1001      = :f_fkinp1001
                                           AND ORDER_DATE     = :f_order_date
                                           AND INPUT_GUBUN    = :f_input_gubun
                                           AND PK_SEQ         = :f_pk_seq
                                           AND HOSP_CODE      = :f_hosp_code";

                            bindVals.Add("q_user_id", this.mMemb);
                            bindVals.Add("f_hangmog_code_1", row["hangmog_code_1"].ToString());
                            bindVals.Add("f_hangmog_code_2", row["hangmog_code_2"].ToString());
                            bindVals.Add("f_hangmog_code_3", row["hangmog_code_3"].ToString());
                            bindVals.Add("f_hangmog_code_4", row["hangmog_code_4"].ToString());
                            bindVals.Add("f_num_val1", row["num_val1"].ToString());
                            bindVals.Add("f_num_val2", row["num_val2"].ToString());
                            bindVals.Add("f_num_val3", row["num_val3"].ToString());
                            bindVals.Add("f_num_val4", row["num_val4"].ToString());
                            bindVals.Add("f_direct_text", row["direct_text"].ToString());
                            bindVals.Add("f_drt_from_date", row["drt_from_date"].ToString());
                            bindVals.Add("f_drt_to_date", row["drt_to_date"].ToString());
                            bindVals.Add("f_continue_yn", row["continue_yn"].ToString());
                            bindVals.Add("f_bunho", row["bunho"].ToString());
                            bindVals.Add("f_fkinp1001", row["fkinp1001"].ToString());
                            bindVals.Add("f_order_date", row["order_date"].ToString());
                            bindVals.Add("f_input_gubun", row["input_gubun"].ToString());
                            bindVals.Add("f_pk_seq", row["pk_seq"].ToString());
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
                        else if (row.RowState == DataRowState.Added)
                        {
                            string cmdSeq = string.Empty;
                            object retSeq = null;
                            BindVarCollection bindVal = new BindVarCollection();

                            cmdSeq =  @"SELECT NVL(MAX(PK_SEQ), 0) + 1
                                          FROM OCS2005
                                         WHERE BUNHO       = :f_bunho
                                           AND FKINP1001   = :f_fkinp1001
                                           AND ORDER_DATE  = :f_order_date
                                           AND INPUT_GUBUN = :f_input_gubun
                                           AND HOSP_CODE   = :f_hosp_code";

                            bindVal.Add("f_bunho", row["bunho"].ToString());
                            bindVal.Add("f_fkinp1001", row["fkinp1001"].ToString());
                            bindVal.Add("f_order_date", row["order_date"].ToString());
                            bindVal.Add("f_input_gubun", row["input_gubun"].ToString());
                            bindVal.Add("f_hosp_code", mHospCode);

                            retSeq = Service.ExecuteScalar(cmdSeq, bindVal);

                            
                            string cmdText = string.Empty;
                            BindVarCollection bindVals = new BindVarCollection();

                            cmdText = @"INSERT INTO OCS2005
                                               ( SYS_DATE       , UPD_ID         , UPD_DATE       , BUNHO          ,
                                                 FKINP1001      , ORDER_DATE     , INPUT_GUBUN    , INPUT_ID       ,
                                                 PK_SEQ         , DIRECT_GUBUN   , DIRECT_CODE    , DIRECT_CONT1   ,
                                                 DIRECT_CONT2   , CNT_PERHOUR    , CNT_PERDAY     , ACT_DAY        ,
                                                 FRENCH         , ACT_DQ1        , ACT_DQ2        , ACT_DQ3        ,
                                                 ACT_DQ4        , ACT_TIME       , DIRECT_TEXT    , HANGMOG_CODE_1 ,
                                                 HANGMOG_CODE_2 , HANGMOG_CODE_3 , HANGMOG_CODE_4 , NUM_VAL1       ,
                                                 NUM_VAL2       , NUM_VAL3       , NUM_VAL4       , HOSP_CODE      ,
                                                 SYS_ID         , DRT_FROM_DATE  , DRT_TO_DATE    , CONTINUE_YN)
                                         VALUES
                                               ( SYSDATE           , :q_user_id        , SYSDATE          , :f_bunho          ,
                                                 :f_fkinp1001      , :f_order_date     , :f_input_gubun   , :q_user_id        ,
                                                 :f_pk_seq         , :f_direct_gubun   , :f_direct_code   , :f_direct_cont1   ,
                                                 :f_direct_cont2   , :f_cnt_perhour    , :f_cnt_perday    , :f_act_day        ,
                                                 :f_french         , :f_act_dq1        , :f_act_dq2       , :f_act_dq3        ,
                                                 :f_act_dq4        , :f_act_time       , :f_direct_text   , :f_hangmog_code_1 ,
                                                 :f_hangmog_code_2 , :f_hangmog_code_3 , :f_hangmog_code_4, :f_num_val1       ,
                                                 :f_num_val2       , :f_num_val3       , :f_num_val4      , :f_hosp_code      ,
                                                 :q_user_id        , :f_drt_from_date  , :f_drt_to_date   , :f_continue_yn)";

                            bindVals.Add("q_user_id", this.mMemb);
                            bindVals.Add("f_bunho", mBunho);
                            bindVals.Add("f_fkinp1001", mFkinp1001.ToString());
                            bindVals.Add("f_order_date", mOrder_date);
                            bindVals.Add("f_input_gubun", row["input_gubun"].ToString());
                            bindVals.Add("f_pk_seq", retSeq.ToString());
                            bindVals.Add("f_direct_gubun", row["direct_gubun"].ToString());
                            bindVals.Add("f_direct_code", row["direct_code"].ToString());
                            bindVals.Add("f_direct_cont1", row["direct_cont1"].ToString());
                            bindVals.Add("f_direct_cont2", row["direct_cont2"].ToString());
                            bindVals.Add("f_cnt_perhour", row["cnt_perhour"].ToString());
                            bindVals.Add("f_cnt_perday", row["cnt_perday"].ToString());
                            bindVals.Add("f_act_day", row["act_day"].ToString());
                            bindVals.Add("f_french", row["french"].ToString());
                            bindVals.Add("f_act_dq1", row["act_dq1"].ToString());
                            bindVals.Add("f_act_dq2", row["act_dq2"].ToString());
                            bindVals.Add("f_act_dq3", row["act_dq3"].ToString());
                            bindVals.Add("f_act_dq4", row["act_dq4"].ToString());
                            bindVals.Add("f_act_time", row["act_time"].ToString());
                            bindVals.Add("f_direct_text", row["direct_text"].ToString());
                            bindVals.Add("f_hangmog_code_1", row["hangmog_code_1"].ToString());
                            bindVals.Add("f_hangmog_code_2", row["hangmog_code_2"].ToString());
                            bindVals.Add("f_hangmog_code_3", row["hangmog_code_3"].ToString());
                            bindVals.Add("f_hangmog_code_4", row["hangmog_code_4"].ToString());
                            bindVals.Add("f_num_val1", row["num_val1"].ToString());
                            bindVals.Add("f_num_val2", row["num_val2"].ToString());
                            bindVals.Add("f_num_val3", row["num_val3"].ToString());
                            bindVals.Add("f_num_val4", row["num_val4"].ToString());
                            bindVals.Add("f_hosp_code", mHospCode);
                            bindVals.Add("f_drt_from_date", row["drt_from_date"].ToString());
                            bindVals.Add("f_drt_to_date", row["drt_to_date"].ToString());
                            bindVals.Add("f_continue_yn", row["continue_yn"].ToString());

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

                    if (this.grdOCS2005.RowCount > 0)
                    {
                        for (int i = 0; i < this.grdOCS2005.LayoutTable.Rows.Count; i++)
                        {
                            if (this.grdOCS2005.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                            {
                                string cmdText = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();

                                cmdText = @"UPDATE OCS2005
                                               SET UPD_ID         = :q_user_id       ,
                                                   UPD_DATE       =  SYSDATE         ,
                                                   HANGMOG_CODE_1 = :f_hangmog_code_1,
                                                   HANGMOG_CODE_2 = :f_hangmog_code_2,
                                                   HANGMOG_CODE_3 = :f_hangmog_code_3,
                                                   HANGMOG_CODE_4 = :f_hangmog_code_4,
                                                   NUM_VAL1       = :f_num_val1      ,
                                                   NUM_VAL2       = :f_num_val2      ,
                                                   NUM_VAL3       = :f_num_val3      ,
                                                   NUM_VAL4       = :f_num_val4      ,
                                                   DIRECT_TEXT    = :f_direct_text   ,
                                                   DRT_FROM_DATE  = :f_drt_from_date ,
                                                   DRT_TO_DATE    = :f_drt_to_date   ,
                                                   CONTINUE_YN    = :f_continue_yn  
                                             WHERE BUNHO          = :f_bunho
                                               AND FKINP1001      = :f_fkinp1001
                                               AND ORDER_DATE     = :f_order_date
                                               AND INPUT_GUBUN    = :f_input_gubun
                                               AND PK_SEQ         = :f_pk_seq
                                               AND HOSP_CODE      = :f_hosp_code";

                                bindVals.Add("q_user_id", this.mMemb);
                                bindVals.Add("f_hangmog_code_1", this.grdOCS2005.GetItemValue(i, "hangmog_code_1").ToString());
                                bindVals.Add("f_hangmog_code_2", this.grdOCS2005.GetItemValue(i, "hangmog_code_2").ToString());
                                bindVals.Add("f_hangmog_code_3", this.grdOCS2005.GetItemValue(i, "hangmog_code_3").ToString());
                                bindVals.Add("f_hangmog_code_4", this.grdOCS2005.GetItemValue(i, "hangmog_code_4").ToString());
                                bindVals.Add("f_num_val1", this.grdOCS2005.GetItemValue(i, "num_val1").ToString());
                                bindVals.Add("f_num_val2", this.grdOCS2005.GetItemValue(i, "num_val2").ToString());
                                bindVals.Add("f_num_val3", this.grdOCS2005.GetItemValue(i, "num_val3").ToString());
                                bindVals.Add("f_num_val4", this.grdOCS2005.GetItemValue(i, "num_val4").ToString());
                                bindVals.Add("f_drt_from_date", this.grdOCS2005.GetItemValue(i, "drt_from_date").ToString());
                                bindVals.Add("f_drt_to_date", this.grdOCS2005.GetItemValue(i, "drt_to_date").ToString());
                                bindVals.Add("f_continue_yn", this.grdOCS2005.GetItemValue(i, "continue_yn").ToString());
                                bindVals.Add("f_bunho", this.grdOCS2005.GetItemValue(i, "bunho").ToString());
                                bindVals.Add("f_fkinp1001", this.grdOCS2005.GetItemValue(i, "fkinp1001").ToString());
                                bindVals.Add("f_order_date", this.grdOCS2005.GetItemValue(i, "order_date").ToString());
                                bindVals.Add("f_input_gubun", this.grdOCS2005.GetItemValue(i, "input_gubun").ToString());
                                bindVals.Add("f_pk_seq", this.grdOCS2005.GetItemValue(i, "pk_seq").ToString());
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
                            else if (this.grdOCS2005.LayoutTable.Rows[i].RowState == DataRowState.Added)
                            {
                                string cmdText = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();

                                cmdText = @"INSERT INTO OCS2005
                                                   ( SYS_DATE       , UPD_ID         , UPD_DATE       , BUNHO          ,
                                                     FKINP1001      , ORDER_DATE     , INPUT_GUBUN    , INPUT_ID       ,
                                                     PK_SEQ         , DIRECT_GUBUN   , DIRECT_CODE    , DIRECT_CONT1   ,
                                                     DIRECT_CONT2   , CNT_PERHOUR    , CNT_PERDAY     , ACT_DAY        ,
                                                     FRENCH         , ACT_DQ1        , ACT_DQ2        , ACT_DQ3        ,
                                                     ACT_DQ4        , ACT_TIME       , DIRECT_TEXT    , HANGMOG_CODE_1 ,
                                                     HANGMOG_CODE_2 , HANGMOG_CODE_3 , HANGMOG_CODE_4 , NUM_VAL1       ,
                                                     NUM_VAL2       , NUM_VAL3       , NUM_VAL4       , HOSP_CODE      ,
                                                     SYS_ID         , DRT_FROM_DATE  , DRT_TO_DATE    , CONTINUE_YN)
                                             VALUES
                                                   ( SYSDATE           , :q_user_id        , SYSDATE          , :f_bunho          ,
                                                     :f_fkinp1001      , :f_order_date     , :f_input_gubun   , :q_user_id        ,
                                                     :f_pk_seq         , :f_direct_gubun   , :f_direct_code   , :f_direct_cont1   ,
                                                     :f_direct_cont2   , :f_cnt_perhour    , :f_cnt_perday    , :f_act_day        ,
                                                     :f_french         , :f_act_dq1        , :f_act_dq2       , :f_act_dq3        ,
                                                     :f_act_dq4        , :f_act_time       , :f_direct_text   , :f_hangmog_code_1 ,
                                                     :f_hangmog_code_2 , :f_hangmog_code_3 , :f_hangmog_code_4, :f_num_val1       ,
                                                     :f_num_val2       , :f_num_val3       , :f_num_val4      , :f_hosp_code      ,
                                                     :q_user_id        , :f_drt_from_date  , :f_drt_to_date   , :f_continue_yn)";

                                bindVals.Add("q_user_id", this.mMemb);
                                bindVals.Add("f_bunho", mBunho);
                                bindVals.Add("f_fkinp1001", mFkinp1001.ToString());
                                bindVals.Add("f_order_date", mOrder_date);
                                bindVals.Add("f_input_gubun", this.grdOCS2005.GetItemValue(i, "input_gubun").ToString());
                                bindVals.Add("f_pk_seq", Max_pk_seq(i));
                                bindVals.Add("f_direct_gubun", this.grdOCS2005.GetItemValue(i, "direct_gubun").ToString());
                                bindVals.Add("f_direct_code", this.grdOCS2005.GetItemValue(i, "direct_code").ToString());
                                bindVals.Add("f_direct_cont1", this.grdOCS2005.GetItemValue(i, "direct_cont1").ToString());
                                bindVals.Add("f_direct_cont2", this.grdOCS2005.GetItemValue(i, "direct_cont2").ToString());
                                bindVals.Add("f_cnt_perhour", this.grdOCS2005.GetItemValue(i, "cnt_perhour").ToString());
                                bindVals.Add("f_cnt_perday", this.grdOCS2005.GetItemValue(i, "cnt_perday").ToString());
                                bindVals.Add("f_act_day", this.grdOCS2005.GetItemValue(i, "act_day").ToString());
                                bindVals.Add("f_french", this.grdOCS2005.GetItemValue(i, "french").ToString());
                                bindVals.Add("f_act_dq1", this.grdOCS2005.GetItemValue(i, "act_dq1").ToString());
                                bindVals.Add("f_act_dq2", this.grdOCS2005.GetItemValue(i, "act_dq2").ToString());
                                bindVals.Add("f_act_dq3", this.grdOCS2005.GetItemValue(i, "act_dq3").ToString());
                                bindVals.Add("f_act_dq4", this.grdOCS2005.GetItemValue(i, "act_dq4").ToString());
                                bindVals.Add("f_act_time", this.grdOCS2005.GetItemValue(i, "act_time").ToString());
                                bindVals.Add("f_direct_text", this.grdOCS2005.GetItemValue(i, "direct_text").ToString());
                                bindVals.Add("f_hangmog_code_1", this.grdOCS2005.GetItemValue(i, "hangmog_code_1").ToString());
                                bindVals.Add("f_hangmog_code_2", this.grdOCS2005.GetItemValue(i, "hangmog_code_2").ToString());
                                bindVals.Add("f_hangmog_code_3", this.grdOCS2005.GetItemValue(i, "hangmog_code_3").ToString());
                                bindVals.Add("f_hangmog_code_4", this.grdOCS2005.GetItemValue(i, "hangmog_code_4").ToString());
                                bindVals.Add("f_num_val1", this.grdOCS2005.GetItemValue(i, "num_val1").ToString());
                                bindVals.Add("f_num_val2", this.grdOCS2005.GetItemValue(i, "num_val2").ToString());
                                bindVals.Add("f_num_val3", this.grdOCS2005.GetItemValue(i, "num_val3").ToString());
                                bindVals.Add("f_num_val4", this.grdOCS2005.GetItemValue(i, "num_val4").ToString());
                                bindVals.Add("f_hosp_code", mHospCode);
                                bindVals.Add("f_drt_from_date", this.grdOCS2005.GetItemValue(i, "drt_from_date").ToString());
                                bindVals.Add("f_drt_to_date", this.grdOCS2005.GetItemValue(i, "drt_to_date").ToString());
                                bindVals.Add("f_continue_yn", this.grdOCS2005.GetItemValue(i, "continue_yn").ToString());

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

                    // -- OCS2016 ---------------------------------------------------------------------------------------------------
                    if (grdOCS2016.RowCount > 0)
                    {
                        for (int i = 0; i < this.grdOCS2016.LayoutTable.Rows.Count; i++)
                        {
                            if (this.grdOCS2016.LayoutTable.Rows[i].RowState == DataRowState.Modified)
                            {
                                string cmdText = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();

                                cmdText = @"UPDATE OCS2016
                                               SET UPD_ID       = :q_user_id ,
                                                   UPD_DATE     =  SYSDATE   ,
                                                   NUM_VAL1     = :f_num_val1,
                                                   NUM_VAL2     = :f_num_val2,
                                                   NUM_VAL3     = :f_num_val3
                                             WHERE BUNHO        = :f_bunho
                                               AND FKINP1001    = :f_fkinp1001
                                               AND ORDER_DATE   = :f_order_date
                                               AND INPUT_GUBUN  = :f_input_gubun
                                               AND DIRECT_GUBUN = :f_direct_gubun
                                               AND DIRECT_CODE  = :f_direct_code
                                               AND PK_SEQ       = :f_pk_seq
                                               AND HOSP_CODE    = :f_hosp_code";

                                bindVals.Add("q_user_id", this.mMemb);
                                bindVals.Add("f_num_val1", this.grdOCS2016.GetItemValue(i, "num_val1").ToString());
                                bindVals.Add("f_num_val2", this.grdOCS2016.GetItemValue(i, "num_val2").ToString());
                                bindVals.Add("f_num_val3", this.grdOCS2016.GetItemValue(i, "num_val3").ToString());
                                bindVals.Add("f_bunho", mBunho);
                                bindVals.Add("f_fkinp1001", mFkinp1001.ToString());
                                bindVals.Add("f_order_date", mOrder_date);
                                bindVals.Add("f_input_gubun", this.grdOCS2016.GetItemValue(i, "input_gubun").ToString());
                                bindVals.Add("f_direct_gubun", this.grdOCS2016.GetItemValue(i, "direct_gubun").ToString());
                                bindVals.Add("f_direct_code", this.grdOCS2016.GetItemValue(i, "direct_code").ToString());
                                bindVals.Add("f_pk_seq", this.grdOCS2016.GetItemValue(i, "pk_seq").ToString());
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
                            else if (this.grdOCS2016.LayoutTable.Rows[i].RowState == DataRowState.Added)
                            {
                                string cmdSeq = string.Empty;
                                object retSeq = null;
                                BindVarCollection bindVal = new BindVarCollection();

                                cmdSeq = @"SELECT NVL(MAX(PK_SEQ), 0) + 1
                                             FROM OCS2016
                                            WHERE BUNHO        = :f_bunho
                                              AND FKINP1001    = :f_fkinp1001
                                              AND ORDER_DATE   = :f_order_date
                                              AND INPUT_GUBUN  = :f_input_gubun
                                              AND DIRECT_GUBUN = :f_direct_gubun
                                              AND DIRECT_CODE  = :f_direct_code
                                              AND HOSP_CODE    = :f_hosp_code";

                                bindVal.Add("f_bunho", mBunho);
                                bindVal.Add("f_fkinp1001", mFkinp1001.ToString());
                                bindVal.Add("f_order_date", mOrder_date);
                                bindVal.Add("f_input_gubun", this.grdOCS2016.GetItemValue(i, "input_gubun").ToString());
                                bindVal.Add("f_direct_gubun", this.grdOCS2016.GetItemValue(i, "direct_gubun").ToString());
                                bindVal.Add("f_direct_code", this.grdOCS2016.GetItemValue(i, "direct_code").ToString());
                                bindVal.Add("f_hosp_code", mHospCode);

                                retSeq = Service.ExecuteScalar(cmdSeq, bindVal);

                                string cmdText = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();

                                cmdText = @"INSERT INTO OCS2016
                                                   ( SYS_DATE      , UPD_ID        , UPD_DATE      , BUNHO         ,
                                                     FKINP1001     , ORDER_DATE    , INPUT_GUBUN   , DIRECT_GUBUN  ,
                                                     DIRECT_CODE   , PK_SEQ        , NUM_VAL1      , NUM_VAL2      ,
                                                     NUM_VAL3      , SEQ           , DIRECT_DETAIL , HOSP_CODE)
                                             VALUES
                                                   ( SYSDATE        , :q_user_id    , SYSDATE          , :f_bunho         ,
                                                     :f_fkinp1001   , :f_order_date , :f_input_gubun   , :f_direct_gubun  ,
                                                     :f_direct_code , :f_pk_seq     , :f_num_val1      , :f_num_val2      , 
                                                     :f_num_val3    , :f_seq        , :f_direct_detail , :f_hosp_code)";

                                bindVals.Add("q_user_id", this.mMemb);
                                bindVals.Add("f_bunho", mBunho);
                                bindVals.Add("f_fkinp1001", mFkinp1001.ToString());
                                bindVals.Add("f_order_date", mOrder_date);
                                bindVals.Add("f_input_gubun", this.grdOCS2016.GetItemValue(i, "input_gubun").ToString());
                                bindVals.Add("f_direct_gubun", this.grdOCS2016.GetItemValue(i, "direct_gubun").ToString());
                                bindVals.Add("f_direct_code", this.grdOCS2016.GetItemValue(i, "direct_code").ToString());
                                bindVals.Add("f_pk_seq", retSeq.ToString());
                                bindVals.Add("f_num_val1", this.grdOCS2016.GetItemValue(i, "num_val1").ToString());
                                bindVals.Add("f_num_val2", this.grdOCS2016.GetItemValue(i, "num_val2").ToString());
                                bindVals.Add("f_num_val3", this.grdOCS2016.GetItemValue(i, "num_val3").ToString());
                                bindVals.Add("f_seq", this.grdOCS2016.GetItemValue(i, "seq").ToString());
                                bindVals.Add("f_direct_detail", this.grdOCS2016.GetItemValue(i, "direct_detail").ToString());
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
                    }

                    // DELETE -----------------------------------------------------------------------------------------------
                    if (layDeleteDetail.RowCount > 0)
                    {
                        foreach (DataRow row in layDeleteDetail.LayoutTable.Rows)
                        {
                            string cmdText = string.Empty;
                            BindVarCollection bindVals = new BindVarCollection();

                            cmdText = @"DELETE 
                                          FROM OCS2016
                                         WHERE BUNHO        = :f_bunho
                                           AND FKINP1001    = :f_fkinp1001
                                           AND ORDER_DATE   = :f_order_date
                                           AND INPUT_GUBUN  = :f_input_gubun
                                           AND DIRECT_GUBUN = :f_direct_gubun
                                           AND DIRECT_CODE  = :f_direct_code
                                           AND PK_SEQ       = :f_pk_seq;
                                           AND HOSP_CODE    = :f_hosp_code";

                            bindVals.Add("f_bunho", mBunho);
                            bindVals.Add("f_fkinp1001", mFkinp1001.ToString());
                            bindVals.Add("f_order_date", mOrder_date);
                            bindVals.Add("f_input_gubun", row["input_gubun"].ToString());
                            bindVals.Add("f_direct_gubun", row["direct_gubun"].ToString());
                            bindVals.Add("f_direct_code", row["direct_code"].ToString());
                            bindVals.Add("f_pk_seq", row["pk_seq"].ToString());
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

                    if (layDeleteData.RowCount > 0)
                    {
                        foreach (DataRow row in layDeleteData.LayoutTable.Rows)
                        {
                            string cmdText = string.Empty;
                            BindVarCollection bindVals = new BindVarCollection();

                            cmdText = @"DELETE 
                                          FROM OCS2005
                                         WHERE BUNHO          = :f_bunho
                                           AND FKINP1001      = :f_fkinp1001
                                           AND ORDER_DATE     = :f_order_date
                                           AND INPUT_GUBUN    = :f_input_gubun
                                           AND DIRECT_GUBUN   = :f_direct_gubun
                                           AND DIRECT_CODE    = :f_direct_code
                                           AND HOSP_CODE      = :f_hosp_code";

                            bindVals.Add("f_bunho", mBunho);
                            bindVals.Add("f_fkinp1001", mFkinp1001.ToString());
                            bindVals.Add("f_order_date", mOrder_date);
                            bindVals.Add("f_input_gubun", row["input_gubun"].ToString());
                            bindVals.Add("f_direct_gubun", row["direct_gubun"].ToString());
                            bindVals.Add("f_direct_code", row["direct_code"].ToString());
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

                        layDeleteData.Reset();
                    }

                    // DELETE END-----------------------------------------------------------------------------------------------

                    DataCall();

                    break;

                default:
                    break;
            }
        }
        #endregion

        #region [날짜입력 유효성체크 이벤트]
        private void dtpOrderDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "") dtpOrderDate.SetDataValue(DateTime.Now.ToString("yyyy/MM/dd"));
        }
        #endregion

        #region [QueryStart/End Event]
        // OCS0132 데이타 조회시 바인드변수 세팅
        private void layTabItem_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTabItem.SetBindVarValue("f_code_type", "INPUT_GUBUN");
            this.layTabItem.SetBindVarValue("f_code", "D%");
            this.layTabItem.SetBindVarValue("f_hosp_code", mHospCode);
        }

        // OCS2004 데이타 조회시 바인드변수 세팅
        private void layOCS2004_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOCS2004.SetBindVarValue("f_bunho", mBunho);
            this.layOCS2004.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.layOCS2004.SetBindVarValue("f_hosp_code", mHospCode);
            this.layOCS2004.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());
        }

        // OCS2005 데이타 조회시 바인드변수 세팅
        private void layOCS2005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOCS2005.SetBindVarValue("f_bunho", mBunho);
            this.layOCS2005.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.layOCS2005.SetBindVarValue("f_hosp_code", mHospCode);
            this.layOCS2005.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());
        }

        // OCS2016 데이타 조회시 바인드변수 세팅
        private void layOCS2016_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOCS2016.SetBindVarValue("f_bunho", mBunho);
            this.layOCS2016.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            this.layOCS2016.SetBindVarValue("f_hosp_code", mHospCode);
            this.layOCS2016.SetBindVarValue("f_order_date", dtpOrderDate.GetDataValue());
        }

        private void layOCS2004_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layOCS2004.RowCount > 0)
                this.txtHead_title.SetDataValue(layOCS2004.GetItemString(0, "head_title"));
        }

        private void layOCS2005_SaveEnd(object sender, SaveEndEventArgs e)
        {
            grdOCS2005.Reset();
        }

        private void layOCS2016_QueryEnd(object sender, QueryEndEventArgs e)
        {
            grdOCS2016.Reset();

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

            //if (e.ColName == "jisi_order_gubun" )
            //{
            //    e.Protect = true;
            //}
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
            e.Cancel = false;

            object previousValue = grdOCS2005.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // ?댁쟾 Value

            switch (e.ColName)
            {
                case "drt_from_date":

                    if (grdOCS2005.GetItemString(e.RowNumber, "drt_to_date") != null)
                    {
                        if (BetweenDay(e.ChangeValue.ToString(), grdOCS2005.GetItemString(e.RowNumber, "drt_to_date")) < 0)
                        {
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", "");
                            return;
                        }
                    }

                    break;

                case "drt_to_date":
                    if (grdOCS2005.GetItemString(e.RowNumber, "drt_to_date") != null)
                    {
                        if (BetweenDay(grdOCS2005.GetItemString(e.RowNumber, "drt_from_date"), e.ChangeValue.ToString()) < 0)
                        {
                            grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", "");
                            return;
                        }
                        else
                        {
                            grdOCS2005.SetItemValue(e.RowNumber, "continue_yn", "N");
                        }
                    }

                    break;

                case "continue_yn":

                    if (e.ChangeValue.ToString() == "Y")
                    {
                        grdOCS2005.SetItemValue(e.RowNumber, "drt_to_date", "");
                    }

                    break;

                default:
                    break;
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
            ApplyCurrentData();

            grdOCS2005.Reset();
            grdOCS2016.Reset();

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

            //화면에 해당 Input_gubun Data를 가져온다.
            for (int i = 0; i < layOCS2016.RowCount; i++)
            {
                if (arInput_gubun == "D%")
                {
                    if (layOCS2016.LayoutTable.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                        grdOCS2016.LayoutTable.ImportRow(layOCS2016.LayoutTable.Rows[i]);

                }
                else
                {
                    if (layOCS2016.LayoutTable.Rows[i]["input_gubun"].ToString() == arInput_gubun)
                        grdOCS2016.LayoutTable.ImportRow(layOCS2016.LayoutTable.Rows[i]);
                }
            }

            grdOCS2016.DisplayData();

            //화면에 Load된 Data를 삭제한다.
            for (int i = 0; i < layOCS2016.RowCount; i++)
            {
                if (arInput_gubun == "D%")
                {
                    if (layOCS2016.LayoutTable.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    {
                        layOCS2016.LayoutTable.Rows.Remove(layOCS2016.LayoutTable.Rows[i]);
                        i--;
                    }

                }
                else
                {
                    if (layOCS2016.LayoutTable.Rows[i]["input_gubun"].ToString() == arInput_gubun)
                    {
                        layOCS2016.LayoutTable.Rows.Remove(layOCS2016.LayoutTable.Rows[i]);
                        i--;
                    }
                }
            }
        }

        private void ApplyCurrentData()
        {
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
            foreach (DataRow row in this.grdOCS2016.LayoutTable.Select("", ""))
            {
                this.layOCS2016.LayoutTable.ImportRow(row);
            }

            //삭제된 Data를 적용한다.
            if (grdOCS2016.DeletedRowTable != null)
            {
                foreach (DataRow row in this.grdOCS2016.DeletedRowTable.Select("", ""))
                {
                    this.layOCS2016.LayoutTable.ImportRow(row);
                    this.layOCS2016.DeleteRow(layOCS2016.RowCount - 1);
                }
            }
        }

        private void CheckExistsDirect()
        {
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
            layOCS2004.Reset();
            layOCS2005.Reset();
            layOCS2016.Reset();
            grdOCS2005.Reset();
            grdOCS2016.Reset();

            layOCS2004.QueryLayout(false);
            layOCS2005.QueryLayout(false);
            layOCS2016.QueryLayout(false);

            CheckExistsDirect();
        }

        #endregion

        #region [지시사항 Setting]

        private void SetDirectInfo(MultiLayout layDirectInfo)
        {
            if (this.tabInput_gubun.SelectedTab == null) return;

            //간호지시사항인 경우 tab을 옮긴다.
            if (this.tabInput_gubun.SelectedTab.Tag.ToString() == "D%")
                this.tabInput_gubun.SelectedIndex = 0;

            string direct_gubun = "", direct_code = "", filter = "";
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
                            for (int j = 0; j < grdOCS2016.RowCount; i++)
                            {
                                if (direct_gubun == grdOCS2016.GetItemString(j, "direct_gubun") &&
                                   direct_code == grdOCS2016.GetItemString(j, "direct_code"))
                                {
                                    grdOCS2016.DeleteRow(j);
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

                    grdOCS2005.SetItemValue(insertRow, "bunho", mBunho);
                    grdOCS2005.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
                    grdOCS2005.SetItemValue(insertRow, "order_date", mOrder_date);
                    grdOCS2005.SetItemValue(insertRow, "input_gubun", this.tabInput_gubun.SelectedTab.Tag.ToString());
                    grdOCS2005.SetItemValue(insertRow, "input_gubun_name", this.tabInput_gubun.SelectedTab.Title);
                    grdOCS2005.SetItemValue(insertRow, "drt_from_date", dtpOrderDate.GetDataValue());
                }
            }

            CheckExistsDirect();
        }

        private void SetDirectInfo(MultiLayout layDeleteDirectInfo, MultiLayout layDirectInfo, MultiLayout layDeleteDirectDetailInfo, MultiLayout layDirectDetailInfo)
        {
            layDeleteData = layDeleteDirectInfo.Copy();
            layDeleteDetail = layDeleteDirectDetailInfo.Copy();

            if (this.tabInput_gubun.SelectedTab == null) return;

            //간호지시사항인 경우 tab을 옮긴다.
            if (this.tabInput_gubun.SelectedTab.Tag.ToString() == "D%")
                this.tabInput_gubun.SelectedIndex = 0;

            string direct_gubun = "", direct_code = "", pk_seq = "";
            int insertRow = -1;

            //지시사항 등록화면에서 삭제된 건 삭제
            foreach (DataRow row in layDeleteDirectInfo.LayoutTable.Rows)
            {
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();
                for (int i = 0; i < grdOCS2005.RowCount; i++)
                {
                    if (direct_gubun == grdOCS2005.GetItemString(i, "direct_gubun") && direct_code == grdOCS2005.GetItemString(i, "direct_code"))
                    {
                        grdOCS2005.DeleteRow(i);
                        break;
                    }
                }
            }

            foreach (DataRow row in layDirectInfo.LayoutTable.Rows)
            {
                if (row.RowState == DataRowState.Unchanged) continue;

                //기존에 등록되어진 지시사항 UPDATE
                if (row.RowState == DataRowState.Modified)
                {
                    direct_gubun = row["direct_gubun"].ToString();
                    direct_code = row["direct_code"].ToString();

                    for (int i = 0; i < grdOCS2005.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS2005.GetItemString(i, "direct_gubun") && direct_code == grdOCS2005.GetItemString(i, "direct_code"))
                        {
                            foreach (XEditGridCell cell in grdOCS2005.CellInfos)
                            {
                                if (layDirectInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS2005.SetItemValue(i, cell.CellName, row[cell.CellName]);
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
                    grdOCS2005.SetItemValue(insertRow, "order_date", mOrder_date);
                    grdOCS2005.SetItemValue(insertRow, "input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());
                    grdOCS2005.SetItemValue(insertRow, "input_gubun_name", this.tabInput_gubun.SelectedTab.Title);
                }
            }

            //지시사항 등록화면에서 삭제된 지시사항세부내역건 삭제			
            foreach (DataRow row in layDeleteDirectDetailInfo.LayoutTable.Rows)
            {
                direct_gubun = row["direct_gubun"].ToString();
                direct_code = row["direct_code"].ToString();
                pk_seq = row["pk_seq"].ToString();
                for (int i = 0; i < grdOCS2016.RowCount; i++)
                {
                    if (direct_gubun == grdOCS2016.GetItemString(i, "direct_gubun") &&
                        direct_code == grdOCS2016.GetItemString(i, "direct_code") &&
                        pk_seq == grdOCS2016.GetItemString(i, "pk_seq"))
                    {
                        grdOCS2016.DeleteRow(i);
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


                    for (int i = 0; i < grdOCS2016.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS2016.GetItemString(i, "direct_gubun") &&
                            direct_code == grdOCS2016.GetItemString(i, "direct_code") &&
                            pk_seq == grdOCS2016.GetItemString(i, "pk_seq"))
                        {
                            foreach (XEditGridCell cell in grdOCS2016.CellInfos)
                            {
                                if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                                    grdOCS2016.SetItemValue(i, cell.CellName, row[cell.CellName]);
                            }

                            break;
                        }
                    }
                }

                //새로이 등록한 지시사항 Insert
                if (row.RowState == DataRowState.Added)
                {
                    insertRow = grdOCS2016.InsertRow(-1);

                    foreach (XEditGridCell cell in grdOCS2016.CellInfos)
                    {
                        if (layDirectDetailInfo.LayoutItems.Contains(cell.CellName))
                            grdOCS2016.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                    }

                    grdOCS2016.SetItemValue(insertRow, "bunho", mBunho);
                    grdOCS2016.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
                    grdOCS2016.SetItemValue(insertRow, "order_date", mOrder_date);
                    grdOCS2016.SetItemValue(insertRow, "input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());
                }
            }

            CheckExistsDirect();

        }

        #endregion

    }
}