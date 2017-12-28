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
using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Results;

namespace IHIS.OCSA
{
    public partial class OCS0103U13 : XScreen
    {
        #region Fields



        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OCS0103U13()
        {
            InitializeComponent();

            this.mainControl = new IHIS.OCSA.UCOCS0103U13();
            this.pnlFill.Controls.Add(this.mainControl);
            this.mainControl.Name = "OCS0103U13";
            this.mainControl.Dock = DockStyle.Fill;
            this.mainControl.Location = new Point(0, 0);
            this.mainControl.Size = new Size(1300, 531);

            this.mainControl.MContainer = this;
            this.mainControl.MPnlTop = this.pnlTop;
            this.mainControl.MBtnList = this.btnList;
            this.mainControl.MBtnCopy = this.btnCopy;
            this.mainControl.MBtnPaste = this.btnPaste;
            //this.mainControl.MBtnMix = this.btnMix;
            //this.mainControl.MBtnMixCancel = this.btnMixCancel;
            //this.mainControl.MBtnChangeWonyoi = this.btnChangeWonyoi;
            //this.mainControl.MDbxWonyoiOrderYn = this.dbxWonyoiOrderYN;
            this.mainControl.MPbxCopy = this.pbxCopy;

            //MED6991
            InitializeLookAndFeel();
            xFlatLabel3.Visible = true;
        }
        #endregion

        #region Events

        private void OCS0103U10_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            string inputGunbunName = null;
            this.mainControl.ScreenOpen(this.OpenParam, ref inputGunbunName);
            this.mainControl.MOpener = (XScreen)this.Opener;

            if (this.OpenParam != null)
            {
                // 오더일자
                if (this.OpenParam.Contains("order_date"))
                {
                    this.dpkOrder_Date.SetDataValue(this.OpenParam["order_date"].ToString());
                }
                else
                {
                    this.dpkOrder_Date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                // 환자정보
                if (this.OpenParam.Contains("patient_info"))
                {
                    // 환자정보가 있으면 이거 가져다 넣어주ㅝ야 함.
                    this.SetPatientInfo();
                }

                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    this.fbxBunho.AcceptData();
                }

                // 오더일자와 환자번호는 변경할수 없도록 프로텍트 처리
                this.dpkOrder_Date.Protect = true;
                this.fbxBunho.Protect = true;
                this.Focus();
            }
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            e.IsBaseCall = false;
            this.mainControl.HandleBtnListClick(e.Func);
        }

        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(false);
        }

        private void btnCut_Click(object sender, System.EventArgs e)
        {
            this.mainControl.HandleBtnCopyClick(true);
        }

        private void btnPaste_Click(object sender, System.EventArgs e)
        {
            this.mainControl.HandleBtnPasteClick();
        }

        private void btnMakeSet_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnMakeSetClick(sender, e);
        }

        private void btnIlgwalChange_Click(object sender, EventArgs e)
        {
            this.mainControl.HandleBtnIlgwalChangeClick(sender, e);
        }

        private void OCS0103U13_Closing(object sender, CancelEventArgs e)
        {
            //string mbxMsg = "", mbxCap = "";

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

        private void btnList_MouseDown(object sender, MouseEventArgs e)
        {
            this.mainControl.HandleBtnListMouseDown(sender, e);
        }

        #endregion

        #region Methods

        private void InitializeLookAndFeel()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                dbxInputGubunName.Width += 10;
            }
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

        public override object Command(string command, CommonItemCollection commandParam)
        {
            return this.mainControl.Command(command, commandParam);
        }

        #endregion
    }

    //insert by jc 
    #region XSavePeformer
    //public class XSavePeformer : ISavePerformer
    //{
    //    private OCS0103U13 parent = null;
    //    private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS0103U13");

    //    public XSavePeformer(OCS0103U13 parent)
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
    //            case '2':    // 삭제로직...

    //                #region 오더 삭제
    //                // 삭제시 DC 반납 원오더 원래대로 위치
    //                if (item.BindVarList["f_source_ord_key"].VarValue != "")
    //                {
    //                    inList.Clear();
    //                    outList.Clear();
    //                    inList.Add("I");
    //                    inList.Add(item.BindVarList["f_source_ord_key"].VarValue);

    //                    spName = "PR_OCS_UPDATE_DC_YN";

    //                    if (Service.ExecuteProcedure(spName, inList, outList) == false)
    //                    {
    //                        MessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                        return false;
    //                    }
    //                }

    //                // 현재 오더가 n데이 오더인경우 해당 키로 발생된 오더 삭제

    //                if (item.BindVarList["f_nday_yn"].VarValue == "Y")
    //                {
    //                    spName = "PR_OCS_DELETE_NDAY_ORDER";
    //                    inList.Clear();
    //                    inList.Add(item.BindVarList["f_pkocskey"].VarValue);
    //                    outList.Clear();

    //                    if (Service.ExecuteProcedure(spName, inList, outList) == false)
    //                    {
    //                        return false;
    //                    }

    //                    if (outList[0].ToString() != "0")
    //                    {
    //                        return false;
    //                    }
    //                }

    //                cmdText = " DELETE FROM OCS2003 "
    //                        + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
    //                        + "    AND PKOCS2003 = :f_pkocskey ";



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
    //                            cmdText = " SELECT OCSKEY_SEQ.NEXTVAL "
    //                                    + "   FROM SYS.DUAL ";

    //                            t_chk = Service.ExecuteScalar(cmdText);

    //                            item.BindVarList.Remove("f_pkocskey");
    //                            item.BindVarList.Add("f_pkocskey", t_chk.ToString());
    //                        }

    //                        // 시퀀스 가져오기
    //                        if (item.BindVarList["f_seq"].VarValue == "")
    //                        {
    //                            cmdText = " SELECT MAX(SEQ)+1 SEQ "
    //                                    + "   FROM OCS2003 "
    //                                    + "  WHERE HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
    //                                    + "    AND BUNHO      = '" + item.BindVarList["f_bunho"].VarValue + "' "
    //                                    + "    AND FKINP1001  = " + item.BindVarList["f_in_out_key"].VarValue
    //                                    + "    AND ORDER_DATE = TO_DATE('" + item.BindVarList["f_order_date"].VarValue + "', 'YYYY/MM/DD')  ";

    //                            t_chk = Service.ExecuteScalar(cmdText);

    //                            if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
    //                            {
    //                                t_chk = "1";
    //                            }

    //                            item.BindVarList.Remove("f_seq");
    //                            item.BindVarList.Add("f_seq", t_chk.ToString());
    //                        }

    //                        cmdText = " INSERT INTO OCS2003 "
    //                                + "      ( SYS_DATE             , SYS_ID               , UPD_DATE          , UPD_ID                  , HOSP_CODE             , "
    //                                + "        PKOCS2003            , BUNHO                , ORDER_DATE        , ORDER_TIME              , DOCTOR                , "
    //                                + "        INPUT_ID             , INPUT_PART           , INPUT_GUBUN       , SEQ                     , RESIDENT              , "
    //                                + "        HANGMOG_CODE         , GROUP_SER            , SLIP_CODE         , NDAY_YN                 , ORDER_GUBUN           , "
    //                                + "        SPECIMEN_CODE        , SURYANG              , ORD_DANUI         , DV_TIME                 , DV                    , "
    //                                + "        NALSU                , JUSA                 , BOGYONG_CODE      , EMERGENCY               , JAERYO_JUNDAL_YN      , "
    //                                + "        JUNDAL_TABLE         , JUNDAL_PART          , MOVE_PART         , MUHYO                   , PORTABLE_YN           , "
    //                                + "        ANTI_CANCER_YN       , PAY                  , RESER_DATE        , RESER_TIME              , DC_YN                 , "
    //                                + "        DC_GUBUN             , BANNAB_YN            , BANNAB_CONFIRM    , ACT_DOCTOR              , ACT_GWA               , "
    //                                + "        ACT_BUSEO            , OCS_FLAG             , SG_CODE           , SG_YMD                  , IO_GUBUN              , "
    //                                + "        BICHI_YN             , DRG_BUNHO            , SUB_SUSUL         , WONYOI_ORDER_YN         , "
    //                                + "        POWDER_YN            , HOPE_DATE            , HOPE_TIME         , DV_1                    , "
    //                                + "        DV_2                 , DV_3                 , DV_4              , MIX_GROUP               , ORDER_REMARK          , "
    //                                + "        NURSE_REMARK         , BOM_OCCUR_YN         , BOM_SOURCE_KEY    , DISPLAY_YN              , NURSE_CONFIRM_USER    , "
    //                                + "        NURSE_CONFIRM_DATE   , NURSE_CONFIRM_TIME   , TEL_YN            , "
    //                                + "        REGULAR_YN           , INPUT_TAB            , HUBAL_CHANGE_YN   , PHARMACY                , INPUT_DOCTOR          , "
    //                                + "        JUSA_SPD_GUBUN       , DRG_PACK_YN          , SORT_FKOCSKEY     , FKINP1001               , INPUT_GWA             , "
    //                                + "        NDAY_OCCUR_YN        ) "
    //                                + " VALUES "
    //                                + "      ( SYSDATE              , :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
    //                                + "        :f_pkocskey          , :f_bunho             , :f_order_date     , TO_CHAR(SYSDATE, 'HH24MI'), :f_doctor               , "
    //                                + "        :f_input_id          , :f_input_part        , :f_input_gubun    , :f_seq                  , :f_doctor                , "
    //                                + "        :f_hangmog_code      , :f_group_ser         , :f_slip_code      , :f_nday_yn              , :f_order_gubun           , "
    //                                + "        :f_specimen_code     , :f_suryang           , :f_ord_danui      , :f_dv_time              , :f_dv                    , "
    //                                + "        :f_nalsu             , :f_jusa              , :f_bogyong_code   , :f_emergency            , :f_jaeryo_jundal_yn      , "
    //                                + "        :f_jundal_table      , :f_jundal_part       , :f_move_part      , :f_muhyo                , :f_portable_yn           , "
    //                                + "        'N'                  , :f_pay               , :f_reser_date     , :f_reser_time           , :f_dc_yn                 , "
    //                                + "        :f_dc_gubun          , :f_bannab_yn         , :f_bannab_confirm , :f_act_doctor           , :f_act_gwa               , "
    //                                + "        :f_act_buseo         , :f_ocs_flag          , :f_sg_code        , :f_sg_ymd               , :f_io_gubun              , "
    //                                + "        :f_bichi_yn          , :f_drg_bunho         , :f_sub_susul      , :f_wonyoi_order_yn      , "
    //                                + "        :f_powder_yn         , :f_hope_date         , :f_hope_time      , :f_dv_1                 , "
    //                                + "        :f_dv_2              , :f_dv_3              , :f_dv_4           , :f_mix_group            , :f_order_remark          , "
    //                                + "        :f_nurse_remark      , :f_bom_occur_yn      , :f_bom_source_key , 'Y'                     , :f_nurse_confirm_user    , "
    //                                + "        :f_nurse_confirm_date, :f_nurse_confirm_time, :f_tel_yn         , "
    //                                + "        :f_regular_yn        , :f_input_tab         , :f_hubal_change_yn, :f_pharmacy             , :f_input_doctor          , "
    //                                + "        :f_jusa_spd_gubun    , :f_drg_pack_yn       , :f_sort_fkocskey  , :f_in_out_key           , :f_input_gwa             , "
    //                                + "        'N'                  ) ";



    //                        break;

    //                    case DataRowState.Modified:

    //                        cmdText = " UPDATE OCS2003 "
    //                                + "    SET UPD_DATE         = SYSDATE "
    //                                + "      , UPD_ID           = :q_user_id "
    //                                + "      , ORDER_GUBUN      = :f_order_gubun "
    //                                + "      , SURYANG          = :f_suryang "
    //                                + "      , DV_TIME          = :f_dv_time "
    //                                + "      , DV               = :f_dv "
    //                                + "      , NDAY_YN          = :f_nday_yn "
    //                                + "      , NALSU            = :f_nalsu "
    //                                + "      , JUSA             = :f_jusa  "
    //                                + "      , BOGYONG_CODE     = :f_bogyong_code "
    //                                + "      , EMERGENCY        = :f_emergency "
    //                                + "      , JAERYO_JUNDAL_YN = :f_jaeryo_jundal_yn "
    //                                + "      , JUNDAL_TABLE     = :f_jundal_table "
    //                                + "      , JUNDAL_PART      = :f_jundal_part "
    //                                + "      , MOVE_PART        = :f_move_part "
    //                                + "      , MUHYO            = :f_muhyo "
    //                                + "      , PORTABLE_YN      = :f_portable_yn "
    //                                + "      , ANTI_CANCER_YN   = :f_anti_cancer_yn "
    //                                + "      , DC_YN            = :f_dc_yn "
    //                                + "      , DC_GUBUN         = :f_dc_gubun "
    //                                + "      , BANNAB_YN        = :f_bannab_yn "
    //                                + "      , BANNAB_CONFIRM   = :f_bannab_confirm "
    //                                + "      , POWDER_YN        = :f_powder_yn "
    //                                + "      , HOPE_DATE        = :f_hope_date "
    //                                + "      , HOPE_TIME        = :f_hope_time "
    //                                + "      , DV_1             = :f_dv_1 "
    //                                + "      , DV_2             = :f_dv_2 "
    //                                + "      , DV_3             = :f_dv_3 "
    //                                + "      , DV_4             = :f_dv_4 "
    //                                + "      , MIX_GROUP        = :f_mix_group "
    //                                + "      , ORDER_REMARK     = :f_order_remark "
    //                                + "      , NURSE_REMARK     = :f_nurse_remark "
    //                                + "      , BOM_OCCUR_YN     = :f_bom_occur_yn "
    //                                + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
    //                                + "      , NURSE_CONFIRM_USER = :f_nurse_confirm_user "
    //                                + "      , NURSE_CONFIRM_DATE = :f_nurse_confirm_date "
    //                                + "      , NURSE_CONFIRM_TIME = :f_nurse_confirm_time "
    //                                + "      , REGULAR_YN       = :f_regular_yn "
    //                                + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
    //                                + "      , PHARMACY         = :f_pharmacy "
    //                                + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
    //                                + "      , DRG_PACK_YN      = :f_drg_pack_yn "
    //                                + "      , SORT_FKOCSKEY    = :f_sort_fkocskey "
    //                                + "      , WONYOI_ORDER_YN  = :f_wonyoi_order_yn "
    //                                + "      , DISPLAY_YN       = CASE WHEN DC_GUBUN = 'Y' AND SORT_FKOCSKEY IS NOT NULL AND :f_dc_gubun = 'N' THEN 'N' "
    //                                + "                                ELSE DISPLAY_YN END "
    //                                + "      , SPECIMEN_CODE    = :f_specimen_code "
    //                                + "  WHERE HOSP_CODE = '" + EnvironInfo.HospCode + "' "
    //                                + "    AND PKOCS2003 = :f_pkocskey ";



    //                        break;

    //                }

    //                #endregion

    //                break;
    //        }

    //        bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

    //        // 오더 업데이트의 경우는 정시약도 같이 업데이트 되어야 함.
    //        if (callerId == '3' && isSuccess)
    //        {
    //            if (this.mOrderBiz.SaveRegularOrder("2", item.BindVarList["f_pkocskey"].VarValue) == false)
    //            {
    //                isSuccess = false;
    //            }
    //            else
    //            {
    //                isSuccess = true;
    //            }
    //        }

    //        return isSuccess;
    //    }
    //}
    #endregion
}
