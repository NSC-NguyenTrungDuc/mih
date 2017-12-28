using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.Collections;

namespace IHIS.NURI
{
    public partial class ChangeGubun : XForm
    {

        string mFkinp1001 = "";
        string mBunho = "";

        public ChangeGubun(string fkinp1001, string bunho)
        {
            this.mFkinp1001 = fkinp1001;
            this.mBunho = bunho;

            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            #region Insert

            string cmdText = "";
            string mMsg = "";
            BindVarCollection bindVars = new BindVarCollection();
            object retVal = null;

            string fkinp1001 = this.grdGubunHistory.GetItemString(this.grdGubunHistory.RowCount - 1, "fkinp1001");
            string gubun = this.cboGubun.GetDataValue();
            string gubun_ipwon_date = this.dtpGubunStart2.GetDataValue();

            try
            {
                Service.BeginTransaction();

                cmdText = string.Empty;
                bindVars.Clear();
                bindVars.Add("f_hosp_code", this.mHospCode);
                bindVars.Add("f_fkinp1001", fkinp1001);
                bindVars.Add("f_bunho", this.mBunho);
                bindVars.Add("f_gubun", "##"); //保険管理をしないため無保険で登録する。20130622
                //bindVars.Add("f_gubun_ipwon_date", gubun_ipwon_date);
                bindVars.Add("f_gubun_ipwon_date", gubun_ipwon_date);

                cmdText = @"SELECT 'Y'
                          FROM DUAL
                         WHERE EXISTS ( SELECT 'X'
                                          FROM BAS0210 A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.GUBUN     = :f_gubun
                                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND A.END_DATE )";

                retVal = null;
                retVal = Service.ExecuteScalar(cmdText, bindVars);
                if (TypeCheck.IsNull(retVal))
                {
                    mMsg = EnvironInfo.GetServerMsg(338); //保険者番号が正確ではありません。確認してください。;
                    throw new Exception();
                }
                else
                {
                    if (retVal.ToString() != "Y")
                    {
                        mMsg = EnvironInfo.GetServerMsg(338); ;
                        throw new Exception();
                    }
                }

                cmdText = @"SELECT NVL(A.GONGBI_YN, 'Y')
                          FROM BAS0210 A
                         WHERE A.HOSP_CODE = :f_hosp_code
                           AND A.GUBUN     = :f_gubun
                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND A.END_DATE";

                retVal = null;
                retVal = Service.ExecuteScalar(cmdText, bindVars);

                if ((TypeCheck.IsNull(retVal)))
                {
                    mMsg = EnvironInfo.GetServerMsg(361);//保険チェック情報の取り込み中にエラーが発生しました。;
                    throw new Exception();
                }

                string gongbiYN = retVal.ToString();

                string mJohap_Gubun = string.Empty;

                cmdText = string.Empty;

                cmdText = @"SELECT A.JOHAP_GUBUN
                          FROM BAS0210 A
                         WHERE A.HOSP_CODE = :f_hosp_code 
                           AND A.GUBUN     = :f_gubun
                           AND :f_gubun_ipwon_date BETWEEN A.START_DATE AND END_DATE";

                retVal = null;
                retVal = Service.ExecuteScalar(cmdText, bindVars);
                if (TypeCheck.IsNull(retVal))
                {
                    mMsg = EnvironInfo.GetServerMsg(334);//保険者番号の取り込み中にエラーが発生しました。;
                    throw new Exception();
                }
                else
                {
                    if (retVal.ToString().Length > 0)
                    {
                        mJohap_Gubun = retVal.ToString();
                    }
                }

                //if ((gongbiYN == "Y") && (this.dtpGubunStart2.GetDataValue() == ""))
                if (this.dtpGubunStart2.GetDataValue() == "")
                {
                    mMsg = EnvironInfo.GetServerMsg(358);//保険情報の適用日がありません。;
                    throw new Exception();
                }

                ArrayList inputList = new ArrayList();
                ArrayList outputList = new ArrayList();

                //inputList.Add(Convert.ToInt32(fkinp1001));
                inputList.Add(fkinp1001);
                inputList.Add(gubun);

                if (!Service.ExecuteProcedure("PR_INP_MAKE_PKINP1002", inputList, outputList))
                {
                    mMsg = "PR_INP_MAKE_PKINP1002 Error";
                    throw new Exception();
                }
                else
                {
                    bindVars.Add("f_pkinp1002", outputList[0].ToString());
                    bindVars.Add("f_seq", outputList[1].ToString());
                }

                if (bindVars["f_pkinp1002"].VarValue == "")
                {
                    mMsg = EnvironInfo.GetServerMsg(189);//保険情報の適用日がありません。;
                    throw new Exception();
                }


                cmdText = @"SELECT NVL(MAX(A.GUBUN_TRANS_CNT), 0) + 1
                          FROM INP1002 A
                         WHERE A.HOSP_CODE = :f_hosp_code
                           AND A.FKINP1001 = :f_fkinp1001";

                retVal = null;
                retVal = Service.ExecuteScalar(cmdText, bindVars);

                string cnt = "0";
                if (!TypeCheck.IsNull(retVal))
                    cnt = retVal.ToString();

                bindVars.Add("f_gubun_trans_cnt", cnt);
                bindVars.Add("f_gubun_trans_yn", "N");

                if (cnt != "1")
                {
                    cmdText = @"UPDATE INP1002 A
                                   SET A.UPD_DATE          = SYSDATE
                                     , A.UPD_ID            = :f_user_id
                                     , A.GUBUN_TOIWON_DATE = TO_DATE(:f_gubun_ipwon_date, 'YYYY/MM/DD') - 1
                                     , A.GUBUN_TRANS_YN    = 'Y'
                                 WHERE A.HOSP_CODE         = :f_hosp_code
                                   AND A.FKINP1001         = :f_fkinp1001  
                                   AND A.GUBUN_TRANS_CNT   = :f_gubun_trans_cnt - 1";

                    if (!Service.ExecuteNonQuery(cmdText, bindVars))
                    {
                        mMsg = "保険変更に失敗しました。"; ;
                        throw new Exception();
                    }
                }


                cmdText = @"INSERT INTO INP1002
                            ( SYS_DATE            , SYS_ID             , UPD_DATE           , UPD_ID
                            , HOSP_CODE           , PKINP1002          , FKINP1001          , BUNHO
                            , GUBUN               , SEQ                , GUBUN_TRANS_DATE   , GUBUN_IPWON_DATE
                            , GUBUN_TOIWON_DATE   , GUBUN_TRANS_CNT    , GUBUN_TRANS_YN     , SIMSAJA
                            , SIMSA_MAGAM_YN      )
                       VALUES
                            ( SYSDATE             , :f_user_id         , SYSDATE            , :f_user_id
                            , :f_hosp_code        , :f_pkinp1002       , :f_fkinp1001       , :f_bunho
                            , :f_gubun            , :f_seq             , NULL               , TO_DATE(:f_gubun_ipwon_date, 'YYYY/MM/DD')
                            , NULL                , :f_gubun_trans_cnt , :f_gubun_trans_yn  , NULL
                            , :f_simsa_magam_yn   )";

                if (!Service.ExecuteNonQuery(cmdText, bindVars))
                {
                    mMsg = "保険変更に失敗しました。";
                    throw new Exception();
                }
                Service.CommitTransaction();
                this.Close();
            }
            catch
            {
                Service.RollbackTransaction();
                XMessageBox.Show(mMsg, "保険変更失敗", MessageBoxIcon.Information);
                return;
            }
			#endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string mHospCode = "";
        private void ChangeGubun_Load(object sender, EventArgs e)
        {
            mHospCode = EnvironInfo.HospCode;

            this.grdGubunHistory.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdGubunHistory.SetBindVarValue("f_fkinp1001", mFkinp1001);
            this.grdGubunHistory.QueryLayout(true);

            this.dbxGubunName1.SetDataValue(this.grdGubunHistory.GetItemString(this.grdGubunHistory.RowCount - 1, "gubun_name"));
            this.dtpGubunStart1.SetDataValue(this.grdGubunHistory.GetItemString(this.grdGubunHistory.RowCount - 1, "start_date"));

            this.layGubun.SetBindVarValue("f_hosp_code", mHospCode);
            this.layGubun.SetBindVarValue("f_bunho", mBunho);
            this.layGubun.SetBindVarValue("f_gubun", this.grdGubunHistory.GetItemString(this.grdGubunHistory.RowCount - 1, "gubun"));
            this.layGubun.QueryLayout(true);

            this.cboGubun.SetComboItems(this.layGubun.LayoutTable, "gubun_name", "gubun");
            
            DateTime dt1 = EnvironInfo.GetSysDate();
            DateTime dt2 = Convert.ToDateTime(dtpGubunStart1.GetDataValue());
            TimeSpan ts = dt1 - dt2;

            if (ts.Days >= 1)
                this.dtpGubunStart2.SetDataValue(dt1);
            else
                this.dtpGubunStart2.SetDataValue(dt2.AddDays(1));            
        }

        private void dtpGubunStart2_DataValidating(object sender, DataValidatingEventArgs e)
        {
            DateTime dt1 = Convert.ToDateTime(dtpGubunStart2.GetDataValue());
            DateTime dt2 = Convert.ToDateTime(dtpGubunStart1.GetDataValue());
            TimeSpan ts = dt1 - dt2;

            if (ts.Days >= 1)
                this.dtpGubunStart2.SetDataValue(dt1);
            else
            {
                XMessageBox.Show("保険適用日を確認してください。\r\n現保険の適用日より後の日付を入力してください。", "保険適用日確認", MessageBoxIcon.Information);
                e.Cancel = true;
            }
            
        }
        
    }
}