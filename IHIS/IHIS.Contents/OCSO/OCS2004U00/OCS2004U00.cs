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

        string mInput_gwa = "";
        string mInput_doctor = "";

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
            grdOCS2006.Reset();

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
            IHIS.Framework.MultiLayout dloParaOCS2006 = layOCS2006;

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("input_gubun", mInput_gubun);
            openParams.Add("direct_mode", "2");
            openParams.Add("order_date", dtpOrderDate.GetDataValue());
            openParams.Add("DIRECT", dloParaOCS2005);
            openParams.Add("DIRECT_DETAIL", dloParaOCS2006);

            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2005U00", ScreenOpenStyle.ResponseSizable, openParams);
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

                    try
                    {
                        //Service.BeginTransaction();
                        // -- OCS2005 ---------------------------------------------------------------------------------------------------

                        foreach (DataRow row in grdOCS2005.LayoutTable.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                string cmdText = string.Empty;
                                BindVarCollection bindVals = new BindVarCollection();

                                cmdText = @"UPDATE OCS2005
                                               SET UPD_ID         = :q_user_id       ,
                                                   UPD_DATE       =  SYSDATE         ,
                                                   DIRECT_TEXT    = :f_direct_text   ,
                                                   DRT_FROM_DATE  = :f_drt_from_date ,
                                                   DRT_TO_DATE    = :f_drt_to_date   ,
                                                   CONTINUE_YN    = :f_continue_yn  
                                             WHERE PKOCS2005      = :f_pkocs2005
                                               AND HOSP_CODE      = :f_hosp_code";

                                                  
//                                             WHERE BUNHO          = :f_bunho
//                                               AND FKINP1001      = :f_fkinp1001
//                                               AND ORDER_DATE     = :f_order_date
//                                               AND INPUT_GUBUN    = :f_input_gubun
//                                               AND PK_SEQ         = :f_pk_seq
//                                               AND HOSP_CODE      = :f_hosp_code";

                                bindVals.Add("q_user_id", this.mMemb);
                                bindVals.Add("f_direct_text", row["direct_text"].ToString());
                                bindVals.Add("f_drt_from_date", row["drt_from_date"].ToString());
                                bindVals.Add("f_drt_to_date", row["drt_to_date"].ToString());
                                bindVals.Add("f_continue_yn", row["continue_yn"].ToString());
                                //bindVals.Add("f_bunho",         row["bunho"].ToString());
                                //bindVals.Add("f_fkinp1001",     row["fkinp1001"].ToString());
                                //bindVals.Add("f_order_date",    row["order_date"].ToString());
                                //bindVals.Add("f_input_gubun",   row["input_gubun"].ToString());
                                //bindVals.Add("f_pk_seq",        row["pk_seq"].ToString());
                                bindVals.Add("f_pkocs2005",     row["pkocs2005"].ToString());
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
                            else if (row.RowState == DataRowState.Added)
                            {
                                string cmdSeq = string.Empty;
                                object retSeq = null;
                                string cmdText = string.Empty;
                                BindVarCollection bindVal = new BindVarCollection();
                                BindVarCollection bindVals = new BindVarCollection();

//                                cmdSeq = @"SELECT NVL(MAX(PK_SEQ), 0) + 1  AS  PK_SEQ
//                                             FROM OCS2005
//                                            WHERE PKOCS2005 = :f_pkocs2005
//                                              AND HOSP_CODE = :f_hosp_code";
//                                bindVal.Add("f_pkocs2005", row["pkocs2005"].ToString());

//                                cmdSeq = @"SELECT NVL(MAX(PK_SEQ), 0) + 1  AS  PK_SEQ
//  FROM OCS2005
// WHERE BUNHO       = :f_bunho
//   AND FKINP1001   = :f_fkinp1001
//   AND ORDER_DATE  = :f_order_date
//   AND INPUT_GUBUN = :f_input_gubun
//   AND HOSP_CODE   = :f_hosp_code";
//                                bindVal.Add("f_bunho", mBunho);
//                                bindVal.Add("f_fkinp1001", mFkinp1001.ToString());
//                                bindVal.Add("f_order_date", mOrder_date);
//                                bindVal.Add("f_input_gubun", mInput_gubun);
//                                bindVal.Add("f_hosp_code", mHospCode);

//                                retSeq = Service.ExecuteScalar(cmdSeq, bindVal);

                                cmdText = @"INSERT INTO OCS2005
                                                   ( SYS_DATE       , UPD_ID         , UPD_DATE       , BUNHO          ,
                                                     PKOCS2005      , INPUT_GWA      , INPUT_DOCTOR   ,
                                                     FKINP1001      , ORDER_DATE     , INPUT_GUBUN    , INPUT_ID       ,
                                                     PK_SEQ         , DIRECT_GUBUN   , DIRECT_CODE    , DIRECT_CONT1   ,
                                                     DIRECT_CONT2   , DIRECT_TEXT    , HOSP_CODE      ,
                                                     SYS_ID         , DRT_FROM_DATE  , DRT_TO_DATE    , CONTINUE_YN)
                                             VALUES
                                                   ( SYSDATE           , :q_user_id        , SYSDATE          , :f_bunho          ,
                                                     :f_pkocs2005      , :f_input_gwa      , :f_input_doctor  ,
                                                     :f_fkinp1001      , :f_order_date     , :f_input_gubun   , :q_user_id        ,
                                                     :f_pk_seq         , :f_direct_gubun   , :f_direct_code   , :f_direct_cont1   ,
                                                     :f_direct_cont2   , :f_direct_text   , :f_hosp_code      ,
                                                     :q_user_id        , :f_drt_from_date  , :f_drt_to_date   , :f_continue_yn)";

                                bindVals.Add("q_user_id",       this.mMemb);
                                bindVals.Add("f_bunho",         mBunho);
                                bindVals.Add("f_pkocs2005",     row["pkocs2005"].ToString());
                                bindVals.Add("f_fkinp1001",     mFkinp1001.ToString());
                                bindVals.Add("f_order_date",    mOrder_date);
                                bindVals.Add("f_input_gubun",   row["input_gubun"].ToString());
                                //bindVals.Add("f_pk_seq",        retSeq.ToString());   // 20101203
                                bindVals.Add("f_pk_seq",        row["pk_seq"].ToString());
                                bindVals.Add("f_direct_gubun",  row["direct_gubun"].ToString());
                                bindVals.Add("f_direct_code",   row["direct_code"].ToString());
                                bindVals.Add("f_direct_cont1",  row["direct_cont1"].ToString());
                                bindVals.Add("f_direct_cont2",  row["direct_cont2"].ToString());
                                bindVals.Add("f_direct_text",   row["direct_text"].ToString());
                                bindVals.Add("f_hosp_code",     mHospCode);
                                bindVals.Add("f_drt_from_date", row["drt_from_date"].ToString());
                                bindVals.Add("f_drt_to_date",   row["drt_to_date"].ToString());
                                bindVals.Add("f_continue_yn",   row["continue_yn"].ToString());

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
                                        /*@"DELETE 
                                              FROM OCS2006
                                             WHERE BUNHO        = :f_bunho
                                               AND FKINP1001    = :f_fkinp1001
                                               AND ORDER_DATE   = :f_order_date
                                               AND INPUT_GUBUN  = :f_input_gubun
                                               AND DIRECT_GUBUN = :f_direct_gubun
                                               AND DIRECT_CODE  = :f_direct_code
                                               AND PK_SEQ       = :f_pk_seq
                                               AND SEQ          = :f_seq
                                               AND HOSP_CODE    = :f_hosp_code";

                                bindVals.Add("f_bunho",         mBunho);
                                bindVals.Add("f_fkinp1001",     mFkinp1001.ToString());
                                bindVals.Add("f_order_date",    mOrder_date);
                                bindVals.Add("f_input_gubun",   row["input_gubun"].ToString());
                                bindVals.Add("f_direct_gubun",  row["direct_gubun"].ToString());
                                bindVals.Add("f_direct_code",   row["direct_code"].ToString());
                                bindVals.Add("f_pk_seq",        row["pk_seq"].ToString());
                                bindVals.Add("f_seq",           row["seq"].ToString());
                                bindVals.Add("f_hosp_code",     mHospCode);*/
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
                                        /*@"DELETE 
                                              FROM OCS2005
                                             WHERE BUNHO          = :f_bunho
                                               AND FKINP1001      = :f_fkinp1001
                                               AND ORDER_DATE     = :f_order_date
                                               AND INPUT_GUBUN    = :f_input_gubun
                                               --AND DIRECT_GUBUN   = :f_direct_gubun
                                               --AND DIRECT_CODE    = :f_direct_code
                                               AND PK_SEQ         = :f_pk_seq
                                               AND HOSP_CODE      = :f_hosp_code";

                                bindVals.Add("f_bunho",         mBunho);
                                bindVals.Add("f_fkinp1001",     mFkinp1001.ToString());
                                //bindVals.Add("f_order_date", mOrder_date);
                                bindVals.Add("f_order_date",    dtpOrderDate.GetDataValue());  // 20101220 KHJ
                                bindVals.Add("f_input_gubun",   row["input_gubun"].ToString());
                                bindVals.Add("f_direct_gubun",  row["direct_gubun"].ToString());
                                bindVals.Add("f_direct_code",   row["direct_code"].ToString());
                                bindVals.Add("f_pk_seq",        row["pk_seq"].ToString());
                                bindVals.Add("f_hosp_code",     mHospCode);*/

                                cmdTextD = @"DELETE FROM OCS2006
                                              WHERE FKOCS2005 = :f_fkocs2005
                                                AND HOSP_CODE = :f_hosp_code";
                                bindValsD.Add("f_fkocs2005", row["pkocs2005"].ToString());
                                bindValsD.Add("f_hosp_code", mHospCode);
                                         /*@"DELETE 
                                               FROM OCS2006
                                              WHERE BUNHO        = :f_bunho
                                                AND FKINP1001    = :f_fkinp1001
                                                AND ORDER_DATE   = :f_order_date
                                                AND INPUT_GUBUN  = :f_input_gubun
                                                --AND DIRECT_GUBUN = :f_direct_gubun
                                                --AND DIRECT_CODE  = :f_direct_code
                                                AND PK_SEQ       = :f_pk_seq
                                                --AND SEQ          = :f_seq
                                                AND HOSP_CODE    = :f_hosp_code";

                                bindValsD.Add("f_bunho",        mBunho);
                                bindValsD.Add("f_fkinp1001",    mFkinp1001.ToString());
                                bindValsD.Add("f_order_date",   dtpOrderDate.GetDataValue());
                                bindValsD.Add("f_input_gubun",  row["input_gubun"].ToString());
                                bindValsD.Add("f_direct_gubun", row["direct_gubun"].ToString());
                                bindValsD.Add("f_direct_code",  row["direct_code"].ToString());
                                bindValsD.Add("f_pk_seq",       row["pk_seq"].ToString());
                                //bindValsD.Add("f_seq", row["seq"].ToString());
                                bindValsD.Add("f_hosp_code",    mHospCode);*/

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
                        Service.CommitTransaction();

                        // -- OCS2006 ---------------------------------------------------------------------------------------------------
                        if (grdOCS2006.RowCount > 0)
                        {
                            for (int i = 0; i < this.grdOCS2006.LayoutTable.Rows.Count; i++)
                            {
                                if (this.grdOCS2006.LayoutTable.Rows[i].RowState == DataRowState.Modified)
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

                                                 /*WHERE BUNHO        = :f_bunho
                                                   AND FKINP1001    = :f_fkinp1001
                                                   AND ORDER_DATE   = :f_order_date
                                                   AND INPUT_GUBUN  = :f_input_gubun
                                                   --AND DIRECT_GUBUN = :f_direct_gubun
                                                   --AND DIRECT_CODE  = :f_direct_code
                                                   AND PK_SEQ       = :f_pk_seq
                                                   AND HOSP_CODE    = :f_hosp_code
                                                   AND SEQ          = :f_seq";*/

                                    bindVals.Add("q_user_id",           this.mMemb);
                                    bindVals.Add("f_hangmog_code",      this.grdOCS2006.GetItemString(i, "hangmog_code"));
                                    bindVals.Add("f_suryang",           this.grdOCS2006.GetItemString(i, "suryang"));
                                    bindVals.Add("f_nalsu",             this.grdOCS2006.GetItemString(i, "nalsu"));
                                    bindVals.Add("f_ord_danui",         this.grdOCS2006.GetItemString(i, "ord_danui"));
                                    bindVals.Add("f_bogyong_code",      this.grdOCS2006.GetItemString(i, "bogyong_code"));
                                    bindVals.Add("f_jusa_code",         this.grdOCS2006.GetItemString(i, "jusa_code"));
                                    bindVals.Add("f_jusa_spd_gubun",    this.grdOCS2006.GetItemString(i, "jusa_spd_gubun"));
                                    bindVals.Add("f_dv",                this.grdOCS2006.GetItemString(i, "dv"));
                                    bindVals.Add("f_dv_time",           this.grdOCS2006.GetItemString(i, "dv_time"));
                                    bindVals.Add("f_insulin_from",      this.grdOCS2006.GetItemString(i, "insulin_from"));
                                    bindVals.Add("f_insulin_to",        this.grdOCS2006.GetItemString(i, "insulin_to"));
                                    bindVals.Add("f_time_gubun",        this.grdOCS2006.GetItemString(i, "time_gubun"));
                                    bindVals.Add("f_bom_source_key",    this.grdOCS2006.GetItemString(i, "bom_source_key"));
                                    bindVals.Add("f_bom_yn",            this.grdOCS2006.GetItemString(i, "bom_yn"));
                                    bindVals.Add("f_direct_gubun",      this.grdOCS2006.GetItemString(i, "direct_gubun"));
                                    bindVals.Add("f_direct_code",       this.grdOCS2006.GetItemString(i, "direct_code"));
                                    bindVals.Add("f_direct_detail",     this.grdOCS2006.GetItemString(i, "direct_detail"));
                                    bindVals.Add("f_hosp_code",         mHospCode);
                                    bindVals.Add("f_fkocs2005",         this.grdOCS2006.GetItemString(i, "fkocs2005"));
                                   /* bindVals.Add("f_bunho",             mBunho);
                                    bindVals.Add("f_fkinp1001",         mFkinp1001.ToString());
                                    //bindVals.Add("f_order_date",    mOrder_date);
                                    bindVals.Add("f_order_date",        this.grdOCS2006.GetItemString(i, "order_date"));
                                    bindVals.Add("f_input_gubun",       this.grdOCS2006.GetItemValue(i, "input_gubun").ToString());
                                    bindVals.Add("f_direct_gubun",      this.grdOCS2006.GetItemValue(i, "direct_gubun").ToString());
                                    bindVals.Add("f_direct_code",       this.grdOCS2006.GetItemValue(i, "direct_code").ToString());
                                    bindVals.Add("f_pk_seq",            this.grdOCS2006.GetItemValue(i, "pk_seq").ToString());
                                    bindVals.Add("f_seq",               this.grdOCS2006.GetItemValue(i, "seq").ToString());*/

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
                                else if (this.grdOCS2006.LayoutTable.Rows[i].RowState == DataRowState.Added)
                                {
                                    //if(grdOCS2005.GetItemString(


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
                                           /*@"SELECT NVL(MAX(SEQ), 0) + 1
                                                 FROM OCS2006
                                                WHERE BUNHO        = :f_bunho
                                                  AND FKINP1001    = :f_fkinp1001
                                                  AND ORDER_DATE   = :f_order_date
                                                  /*
                                                  AND INPUT_GUBUN  = :f_input_gubun
                                                  AND DIRECT_GUBUN = :f_direct_gubun
                                                  AND DIRECT_CODE  = :f_direct_code
                                                  AND PK_SEQ       = :f_pk_seq
                                                  */
                                                  //AND HOSP_CODE    = :f_hosp_code";

                                    //bindVal.Add("f_bunho",          mBunho);
                                    //bindVal.Add("f_fkinp1001",      mFkinp1001.ToString());
                                    //bindVal.Add("f_order_date",     mOrder_date);
                                    //bindVal.Add("f_input_gubun",    this.grdOCS2006.GetItemValue(i, "input_gubun").ToString());
                                    //bindVal.Add("f_direct_gubun",   this.grdOCS2006.GetItemValue(i, "direct_gubun").ToString());
                                    //bindVal.Add("f_direct_code",    this.grdOCS2006.GetItemValue(i, "direct_code").ToString());
                                    //bindVal.Add("f_pk_seq",         this.grdOCS2006.GetItemValue(i, "pk_seq").ToString());
                                    bindVal.Add("f_fkocs2005",      grdOCS2006.GetItemString(i, "fkocs2005"));
                                    bindVal.Add("f_hosp_code",      mHospCode);

                                    Seq = Service.ExecuteScalar(cmdSeq, bindVal);

                                    cmdSeq = @"SELECT PK_SEQ
                                                 FROM OCS2005
                                                WHERE PKOCS2005 = :f_fkocs2005
                                                  AND HOSP_CODE = :f_hosp_code";

                                    pkSeq = Service.ExecuteDataTable(cmdSeq, bindVal);

                                    cmdText = @"INSERT INTO OCS2006
                                                       ( SYS_DATE      , UPD_ID        , UPD_DATE      , BUNHO         ,
                                                         FKOCS2005     ,
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
                                                         :f_fkocs2005   ,
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
                                    bindVals.Add("f_fkocs2005",     this.grdOCS2006.GetItemString(i, "fkocs2005"));
                                    bindVals.Add("f_fkinp1001",     mFkinp1001.ToString());
                                    bindVals.Add("f_order_date",    this.grdOCS2006.GetItemValue(i, "order_date").ToString());
                                    bindVals.Add("f_input_gubun",   this.grdOCS2006.GetItemValue(i, "input_gubun").ToString());
                                    bindVals.Add("f_direct_gubun",  this.grdOCS2006.GetItemValue(i, "direct_gubun").ToString());
                                    bindVals.Add("f_direct_code",   this.grdOCS2006.GetItemValue(i, "direct_code").ToString());

                                    bindVals.Add("f_pk_seq",        this.grdOCS2006.GetItemValue(i, "pk_seq").ToString());

                                    bindVals.Add("f_hangmog_code",  this.grdOCS2006.GetItemValue(i, "hangmog_code").ToString());
                                    bindVals.Add("f_suryang",       this.grdOCS2006.GetItemValue(i, "suryang").ToString());
                                    bindVals.Add("f_nalsu",         this.grdOCS2006.GetItemValue(i, "nalsu").ToString());
                                    bindVals.Add("f_ord_danui",     this.grdOCS2006.GetItemValue(i, "ord_danui").ToString());
                                    bindVals.Add("f_bogyong_code",  this.grdOCS2006.GetItemValue(i, "bogyong_code").ToString());
                                    bindVals.Add("f_jusa_code",     this.grdOCS2006.GetItemValue(i, "jusa_code").ToString());
                                    bindVals.Add("f_jusa_spd_gubun", this.grdOCS2006.GetItemValue(i, "jusa_spd_gubun").ToString());
                                    bindVals.Add("f_dv",            this.grdOCS2006.GetItemValue(i, "dv").ToString());
                                    bindVals.Add("f_dv_time",       this.grdOCS2006.GetItemValue(i, "dv_time").ToString());
                                    bindVals.Add("f_insulin_from",  this.grdOCS2006.GetItemValue(i, "insulin_from").ToString());
                                    bindVals.Add("f_insulin_to",    this.grdOCS2006.GetItemValue(i, "insulin_to").ToString());
                                    bindVals.Add("f_time_gubun",    this.grdOCS2006.GetItemValue(i, "time_gubun").ToString());
                                    bindVals.Add("f_bom_source_key", this.grdOCS2006.GetItemValue(i, "bom_source_key").ToString());
                                    bindVals.Add("f_bom_yn",        this.grdOCS2006.GetItemValue(i, "bom_yn").ToString());

                                    bindVals.Add("f_seq",           TypeCheck.NVL(grdOCS2006.GetItemValue(i, "seq"), Seq).ToString().ToString()); //20101203
                                    bindVals.Add("f_direct_detail", this.grdOCS2006.GetItemValue(i, "direct_detail").ToString());
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
                        //Service.RollbackTransaction();
                        XMessageBox.Show(xe.Message);
                        return;
                    }

                    //Service.CommitTransaction();
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
        private void layOCS2016_QueryStarting(object sender, CancelEventArgs e)
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

        private void layOCS2016_QueryEnd(object sender, QueryEndEventArgs e)
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

        private bool notRowFocusChangeFlag = true;
        private string itFirstFlag = "Y";

        private void LoadData(string arInput_gubun)
        {
            //화면에 있는 Data를 적용한다.
            ApplyCurrentData();

            grdOCS2005.Reset();
            grdOCS2006.Reset();


            notRowFocusChangeFlag = true;

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

            notRowFocusChangeFlag = false;

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

            //grdOCS2005.QueryLayout(false);
            layOCS2005.QueryLayout(false);
            layOCS2006.QueryLayout(false);

            //CheckExistsDirect();
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
                            for (int j = 0; j < grdOCS2006.RowCount; i++)
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

                                if(grdOCS2005.GetItemString(i, cell.CellName).Equals("continue_yn"))
                                {
                                    if (grdOCS2005.GetItemString(i, "continue_yn") != "Y" &&
                                        grdOCS2005.GetItemString(i, "drt_to_date") == ""     )
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


                    for (int i = 0; i < grdOCS2006.RowCount; i++)
                    {
                        if (direct_gubun == grdOCS2006.GetItemString(i, "direct_gubun") &&
                            direct_code == grdOCS2006.GetItemString(i, "direct_code") &&
                            pk_seq == grdOCS2006.GetItemString(i, "pk_seq"))
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
                    grdOCS2006.SetItemValue(insertRow, "order_date", mOrder_date);
                    //grdOCS2006.SetItemValue(insertRow, "order_date", dtpOrderDate.GetDataValue());  // 20101217 KHJ
                    grdOCS2006.SetItemValue(insertRow, "input_gubun", tabInput_gubun.SelectedTab.Tag.ToString());
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
    }
}