using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using System.Globalization;

namespace IHIS.NUTS
{
    public partial class NUT9001U00 : XScreen
    {
        private string fknut2011 = "";
        private string magam_seq = "";

        public NUT9001U00()
        {
            InitializeComponent();
            this.grdINP5001.SavePerformer = new XSavePerformer(this);
        }

        #region Status BAR 관련 메소드

        private void InitStatusBar(int aMaxValue)
        {
            this.pgbProgress.Minimum = 0;
            this.pgbProgress.Maximum = aMaxValue;

            this.lbStatus.Text = "";
        }

        private void SetVisibleStatusBar(bool aIsVisible)
        {
            this.pnlStatus.Visible = aIsVisible;
        }

        private void SetStatusBar(int aCurrentValue, string aMessage)
        {
            this.pgbProgress.Value = aCurrentValue;
            this.pgbProgress.Refresh();
            
            //this.lbStatus.Text = aCurrentValue.ToString() + "/" + this.pgbProgress.Maximum.ToString() + "   " + aMessage;
            this.lbStatus.Text = aMessage;
            this.lbStatus.Refresh();
        }

        #endregion

        private bool CancelONOFF = true;

        private void btn_Click(object sender, EventArgs e)
        {
            
            Control ctl = sender as Control;
            this.ProcessMAGAM(ctl.Tag.ToString().Substring(0, 1), ctl.Tag.ToString().Substring(1, 1));
            
        }

        //aBLD_GUBUN B:breakfast, L:lunch, D:dinner
        //aMAGAM_GUBUN: N:cancel, S:途中締切, Y:最終締切
        private void ProcessMAGAM(string aBLD_GUBUN, string aMAGAM_GUBUN)
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();
                        
            XEditGrid grd = this.grdINP5001;
            int CurrenRow = grd.CurrentRowNumber;
            string JOJUSEOK_COLUMN_NAME = "";
            string I_NUT_GUBUN = "";
            string msg = "";
            string cap = "確認";
            bool IsSucess = true;


            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            this.InitStatusBar(100);
            this.SetVisibleStatusBar(true);

            switch (aBLD_GUBUN)
            {
                case "1":
                    JOJUSEOK_COLUMN_NAME = "nut_jo_magam_yn";
                    I_NUT_GUBUN = "JO";
                    msg = DateTime.Parse(this.grdINP5001.GetItemString(CurrenRow, "magam_date")).ToString("yyyy/MM/dd") + "  【朝食】";
                    break;
                case "2":
                    JOJUSEOK_COLUMN_NAME = "nut_ju_magam_yn";
                    I_NUT_GUBUN = "JU";
                    msg = DateTime.Parse(this.grdINP5001.GetItemString(CurrenRow, "magam_date")).ToString("yyyy/MM/dd") + "  【昼食】";
                    break;
                case "3":
                    JOJUSEOK_COLUMN_NAME = "nut_seok_magam_yn";
                    I_NUT_GUBUN = "SEOK";
                    msg = DateTime.Parse(this.grdINP5001.GetItemString(CurrenRow, "magam_date")).ToString("yyyy/MM/dd") + "  【夕食】";
                    break;
            }

            if (grd.GetItemString(CurrenRow, JOJUSEOK_COLUMN_NAME) == "Y")
            {
                XMessageBox.Show(msg + "最終締切が終わっています。確認して下さい。", "確認");
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SetVisibleStatusBar(false);
                return;
            }

            if (grd.GetItemString(CurrenRow, JOJUSEOK_COLUMN_NAME) == "N")
                msg += "  締切完了";
            else if (grd.GetItemString(CurrenRow, JOJUSEOK_COLUMN_NAME) == "S" && aMAGAM_GUBUN == "S")
                msg += "  再締切完了";
            else if (grd.GetItemString(CurrenRow, JOJUSEOK_COLUMN_NAME) == "S" && aMAGAM_GUBUN == "Y")
                msg += "  最終締切完了";

            grd.SetItemValue(CurrenRow, JOJUSEOK_COLUMN_NAME, aMAGAM_GUBUN);

            this.SetStatusBar(10, "締切情報生成中...");

            try
            {
                Service.BeginTransaction();
                //if (!this.grdINP5001.SaveLayout())
                //    XMessageBox.Show("保存に失敗しました｡");

                inputList.Clear();
                inputList.Add("I_UPD_ID", UserInfo.UserID);
                inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                inputList.Add("I_MAGAM_DATE", this.grdINP5001.GetItemString(CurrenRow, "magam_date"));
                inputList.Add("I_BLD_GUBUN", I_NUT_GUBUN);
                inputList.Add("I_NUT_MAGAM_GUBUN", this.grdINP5001.GetItemString(CurrenRow, JOJUSEOK_COLUMN_NAME));


                if (Service.ExecuteProcedure("PR_NUT_MAGAM", inputList, outputList))
                {
                    if (outputList.Count > 0)
                    {
                        if (outputList["O_FLAG"].ToString() == "N")
                            throw new Exception();
                    }
                    fknut2011 = outputList["O_FKNUT2011"].ToString();
                    magam_seq = outputList["O_MAGAM_SEQ"].ToString();
                }
                else
                {
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                    this.SetVisibleStatusBar(false);
                    throw new Exception(Service.ErrFullMsg);
                }

            }
            catch (Exception xe)
            {
                IsSucess = false;

                msg = "締切失敗";
                cap = "確認";

                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SetVisibleStatusBar(false);
                Service.RollbackTransaction();
                XMessageBox.Show(xe.Message, "確認", MessageBoxIcon.Error);
                //XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, "ExecuteUpdate Error", MessageBoxIcon.Error);
            }

            System.Threading.Thread.Sleep(500);
            this.SetStatusBar(20, "データ転送処理開始");

            if (!IsSucess)
                XMessageBox.Show(msg, cap);
            else
            {
                Service.CommitTransaction();


                // 栄養食事 SYSTEM I/F
                //this.procNUTInterface(this.grdINP5001.GetItemString(CurrenRow, "magam_date"), I_NUT_GUBUN);
                this.procNUTInterface(this.grdINP5001.GetItemString(CurrenRow, "magam_date"), I_NUT_GUBUN, fknut2011);
            }
            //else
            //{
            //    if (aMAGAM_GUBUN == "S")
            //    {
            //        switch (aBLD_GUBUN)
            //        {
            //            case "1":
            //                this.btn1thB.Text = fknut2011 + "次　" + this.btn1thB.Text;
            //                break;
            //            case "2":
            //                this.btn1thL.Text = fknut2011 + "次　" + this.btn1thL.Text;
            //                break;
            //            case "3":
            //                this.btn1thD.Text = fknut2011 + "次　" + this.btn1thD.Text;
            //                break;
            //        }
            //    }
            //}

            System.Threading.Thread.Sleep(500);
            this.SetStatusBar(90, "締切処理終了中...");

            RefreshButtonImage();

            System.Threading.Thread.Sleep(1000);
            this.SetStatusBar(100, "締切処理終了");

            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.SetVisibleStatusBar(false);

            this.btnList.PerformClick(FunctionType.Query);
        }

        #region 食事データI/F
        #region [procNUTInterface() 食事データI/F] Nutrition
        //public bool procNUTInterface(string aNUT_DATE, string aBLD_GUBUN)
        //{
        //    Hashtable inputList = new Hashtable();
        //    Hashtable outputList = new Hashtable();

        //    //１．中間テーブルデータ生成（NUT2011）
        //    inputList.Clear();
        //    inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);  // 病院コード
        //    inputList.Add("I_NUT_DATE", aNUT_DATE);            // 締切日付
        //    inputList.Add("I_BLD_GUBUN", aBLD_GUBUN);            // 朝昼夕区分

        //    try
        //    {
        //        Service.BeginTransaction();

        //        // IFSテーブル作成に必要なリターン値
        //        int rtnIfsCnt = -1;
        //        string PKNUT2011 = "";

        //        bool value = Service.ExecuteProcedure("PR_IFS_NUT_MASTER_INSERT", inputList, outputList);

        //        if (value == false || TypeCheck.IsNull(outputList["O_PK"]) || outputList["O_PK"].ToString().Equals("-1"))
        //        {
        //            throw new Exception("転送マスタ（NUT2011）作成に問題が発生しました。");
        //        }
        //        else
        //        {
        //            // NUT2011キーをリターン
        //            PKNUT2011 = outputList["O_PK"].ToString();

        //            BindVarCollection item = new BindVarCollection();

        //            //２．I/Fテーブルデータ生成（IFS7501）
        //            // NUT2011キーでIFS7501データ作成
        //            rtnIfsCnt = this.makeIFSTBL_NUT(PKNUT2011, "Y");
        //        }
        //        Service.CommitTransaction();

        //        //３．食事データFILE転送
        //        if (rtnIfsCnt == 1)
        //        {
        //            DataTable dt = this.CursorIFS7501(PKNUT2011);

        //            for(int i = 0; i < dt.Rows.Count; i++)
        //                this.atcTrans_NUT(dt.Rows[i]["pkifs7501"].ToString());

        //            //XMessageBox.Show("データ転送");
        //            //XMessageBox.Show("問診データ転送の申請を成功しました。", "問診データ転送要請成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Service.RollbackTransaction();
        //        XMessageBox.Show(ex.Message, "問診データ転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    return true;
        //}
        public bool procNUTInterface(string aNUT_DATE, string aBLD_GUBUN, string aFKNUT2011)
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            int rtnIfsCnt = -1;
            try
            {
                Service.BeginTransaction();

                System.Threading.Thread.Sleep(500);
                this.SetStatusBar(30, "転送するデータ作成開始");

                //２．I/Fテーブルデータ生成（IFS7501）
                // NUT2011キーでIFS7501データ作成
                rtnIfsCnt = this.makeIFSTBL_NUT(aFKNUT2011, "Y");
                
                Service.CommitTransaction();

                //３．食事データFILE転送
                if (rtnIfsCnt == 1)
                {
                    DataTable dt = this.CursorIFS7501(aFKNUT2011);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.atcTrans_NUT(dt.Rows[i]["pkifs7501"].ToString());
                        this.SetStatusBar(60 + i, "データ転送中...");
                    }
                }
                
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
                this.SetVisibleStatusBar(false);
                Service.RollbackTransaction();
                XMessageBox.Show(ex.Message, "食事データ転送失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // 同じPKNUT2011が複数存在するので集めてPKIFS7501キーで伝送する。
        public DataTable CursorIFS7501(string aPKNUT2011)
        {
            System.Threading.Thread.Sleep(500);
            this.SetStatusBar(50, "転送するデータ作成中...");

            BindVarCollection bind = new BindVarCollection();
            string cmd = @"SELECT PKIFS7501
                             FROM IFS7501 A
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.FKNUT2011 = :f_pknut2011
                            ORDER BY A.PKIFS7501
                          ";
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_pknut2011", aPKNUT2011);

            DataTable dt = Service.ExecuteDataTable(cmd, bind);
            return dt;
        }

        public int makeIFSTBL_NUT(string aPKNUT2011, string aSEND_YN)
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();

            System.Threading.Thread.Sleep(500);
            this.SetStatusBar(40, "転送するデータ作成中...");

            int retVal = -1;

            inputList.Clear();
            outputList.Clear();

            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
            inputList.Add("I_MASTER_FK", aPKNUT2011);
            inputList.Add("I_SEND_YN", aSEND_YN);

            //inputList.Add(send_yn);

            bool ret = Service.ExecuteProcedure("PR_IFS_NUT_PROC_MAIN", inputList, outputList);

            if (ret == false || TypeCheck.IsNull(outputList["O_FLAG"]) || outputList["O_FLAG"].ToString() != "1")
            {
                throw new Exception(outputList["O_MSG"].ToString());
            }
            else retVal = Int32.Parse(outputList["O_FLAG"].ToString());

            return retVal;
        }

        public bool atcTrans_NUT(string aPKIFS7501)
        {
            if (TypeCheck.IsNull(aPKIFS7501))
            {
                throw new Exception("転送するデータが存在しません。");
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText;

            msgText = "97501" + aPKIFS7501;
            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (ret == -1)
            {
                throw new Exception("問診データを転送中､問題が発生しました。電文：" + msgText);
            }
            return true;
        }
        #endregion
        #endregion

        private void RefreshButtonImage()
        {
            string nut_jo_magam_yn = "";
            string nut_ju_magam_yn = "";
            string nut_seok_magam_yn = "";

            string b_seq = "";
            string l_seq = "";
            string d_seq = "";

            int CurrentRow = this.grdINP5001.CurrentRowNumber;

            if (CurrentRow < 0)
            {
                this.btnMiddle_B.ImageIndex = 0;
                this.btnMiddle_B.Text = "締切";
                this.btnMiddle_L.ImageIndex = 0;
                this.btnMiddle_L.Text = "締切";
                this.btnMiddle_D.ImageIndex = 0;
                this.btnMiddle_D.Text = "締切";
            }
            else
            {
                nut_jo_magam_yn = this.grdINP5001.GetItemString(CurrentRow, "nut_jo_magam_yn");
                nut_ju_magam_yn = this.grdINP5001.GetItemString(CurrentRow, "nut_ju_magam_yn");
                nut_seok_magam_yn = this.grdINP5001.GetItemString(CurrentRow, "nut_seok_magam_yn");

                b_seq = this.grdINP5001.GetItemString(CurrentRow, "b_seq");
                l_seq = this.grdINP5001.GetItemString(CurrentRow, "l_seq");
                d_seq = this.grdINP5001.GetItemString(CurrentRow, "d_seq");

                if (int.Parse(b_seq) > 0)
                    this.btnMiddle_B.Text = b_seq + "次　" + "締切完了";
                else
                    this.btnMiddle_B.Text = "締切";

                if (int.Parse(l_seq) > 0)
                    this.btnMiddle_L.Text = l_seq + "次　" + "締切完了";
                else
                    this.btnMiddle_L.Text = "締切";

                if (int.Parse(d_seq) > 0)
                    this.btnMiddle_D.Text = d_seq + "次　" + "締切完了";
                else
                    this.btnMiddle_D.Text = "締切";

                if (nut_jo_magam_yn == "Y")
                {
                    this.btnFinal_B.ImageIndex = 1;
                    this.btnFinal_B.Text = "最終締切完了";
                }
                else
                {
                    this.btnFinal_B.ImageIndex = 0;
                    this.btnFinal_B.Text = "最終締切";
                }

                if (nut_ju_magam_yn == "Y")
                {
                    this.btnFinal_L.ImageIndex = 1;
                    this.btnFinal_L.Text = "最終締切完了";
                }
                else
                {
                    this.btnFinal_L.ImageIndex = 0;
                    this.btnFinal_L.Text = "最終締切";
                }

                if (nut_seok_magam_yn == "Y")
                {
                    this.btnFinal_D.ImageIndex = 1;
                    this.btnFinal_D.Text = "最終締切完了";
                }
                else
                {
                    this.btnFinal_D.ImageIndex = 0;
                    this.btnFinal_D.Text = "最終締切";
                }
            }
        }
        private void NUT9001U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            string cmd = @"SELECT FN_NUT_IS_SIKSA_MAGAM_YN(:f_hosp_code) FROM SYS.DUAL";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);

            object obj = Service.ExecuteScalar(cmd, bind);
            
            string lastDinnerMagamYN = "";
            string lastMagamDate = "";
            
            if (obj.ToString() != "0")
            {
                lastMagamDate = obj.ToString().Substring(0, 10);
                lastDinnerMagamYN = obj.ToString().Substring(12, 1);
            }

            if (lastDinnerMagamYN == "Y")
                lastMagamDate = DateTime.Parse(lastMagamDate).AddDays(1).ToString("yyyy/MM/dd");

            if (lastMagamDate != "")
                this.dpkDeadLine.SetDataValue(lastMagamDate);
            else
                this.dpkDeadLine.SetDataValue(EnvironInfo.GetSysDate());

            string cmd_enable = @"SELECT A.CODE_NAME
                                    FROM OCS0132 A
                                   WHERE A.HOSP_CODE = :f_hosp_code
                                     AND A.CODE_TYPE = 'NUT_FINAL_MAGAM_ACTION'
                                     AND A.CODE      = :f_code
                                ";
            BindVarCollection bind_enable = new BindVarCollection();
            bind_enable.Add("f_hosp_code", EnvironInfo.HospCode);
            bind_enable.Add("f_code", "CHANGE_YN");

            object obj_enable = Service.ExecuteScalar(cmd_enable, bind_enable);

            this.cbxSiksaChangeYN.CheckedChanged -= new System.EventHandler(this.cbxSiksaChangeYN_CheckedChanged);

            if (obj_enable != null && obj_enable.ToString() == "Y")
                this.cbxSiksaChangeYN.Checked = true;
            else
                this.cbxSiksaChangeYN.Checked = false;

            this.cbxSiksaChangeYN.CheckedChanged += new System.EventHandler(this.cbxSiksaChangeYN_CheckedChanged);

            obj_enable = null;
            bind_enable.Clear();
            bind_enable.Add("f_hosp_code", EnvironInfo.HospCode);
            bind_enable.Add("f_code", "ENABLE_YN");

            obj_enable = Service.ExecuteScalar(cmd_enable, bind_enable);

            if (obj_enable != null && obj_enable.ToString() == "Y")
                this.cbxSiksaChangeYN.Enabled = true;
            else
                this.cbxSiksaChangeYN.Enabled = false;

            this.btnList.PerformClick(FunctionType.Query);
            
        }

        private void grdINP5001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP5001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP5001.SetBindVarValue("f_magam_date", this.dpkDeadLine.GetDataValue());
        }

        private void grdINP5001_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            RefreshButtonImage();
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.grdINP5001.QueryLayout(false);
                    if (this.grdINP5001.RowCount < 1)
                    {
                        RefreshButtonImage();
                        PostCallHelper.PostCall(InsertRow);
                    }
                    //btn name change

                    break;

                case FunctionType.Update:
                    
                    break;

                case FunctionType.Close:
                    break;
            }
        }

        private void InsertRow()
        {
            int CurrenRow = this.grdINP5001.InsertRow(-1);
            this.grdINP5001.SetItemValue(CurrenRow, "magam_date", this.dpkDeadLine.GetDataValue());
            this.grdINP5001.SetItemValue(CurrenRow, "charge_yn", "N");
            this.grdINP5001.SetItemValue(CurrenRow, "nut_jo_magam_yn", "N");
            this.grdINP5001.SetItemValue(CurrenRow, "nut_ju_magam_yn", "N");
            this.grdINP5001.SetItemValue(CurrenRow, "nut_seok_magam_yn", "N");

            this.grdINP5001.SetItemValue(CurrenRow, "b_seq", "N");
            this.grdINP5001.SetItemValue(CurrenRow, "l_seq", "N");
            this.grdINP5001.SetItemValue(CurrenRow, "d_seq", "N");
        }

        #region [-- XSavePerformer --]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUT9001U00 parent = null;

            public XSavePerformer(NUT9001U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Modified:
                                cmdText = @"UPDATE INP5001
                                               SET UPD_ID            = :q_user_id
                                                 , UPD_DATE          = SYSDATE
                                                 , NUT_JO_MAGAM_YN   = :f_nut_jo_magam_yn
                                                 , NUT_JU_MAGAM_YN   = :f_nut_ju_magam_yn
                                                 , NUT_SEOK_MAGAM_YN = :f_nut_seok_magam_yn
                                             WHERE PKOCS2005     = :f_pkocs2005
                                               AND HOSP_CODE     = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }

        }
        #endregion

        private void btnChangedList_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            string magam_seq = "";
            switch (ctl.Tag.ToString())
            {
                case "1":
                    magam_seq = this.grdINP5001.GetItemString(this.grdINP5001.CurrentColNumber, "b_seq");
                    break;
                case "2":
                    magam_seq = this.grdINP5001.GetItemString(this.grdINP5001.CurrentColNumber, "l_seq");
                    break;
                case "3":
                    magam_seq = this.grdINP5001.GetItemString(this.grdINP5001.CurrentColNumber, "d_seq");
                    break;
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("nut_date", dpkDeadLine.GetDataValue().ToString());
            openParams.Add("bld_gubun", ctl.Tag.ToString());
            openParams.Add("magam_seq", magam_seq);
            XScreen.OpenScreenWithParam(this, "NUTS", "NUT9001Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
        }

        private void btnFinal_C_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            string cmd = "";
            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_magam_date", this.grdINP5001.GetItemString(this.grdINP5001.CurrentRowNumber, "magam_date"));
            bind.Add("f_yn", "N");
            // check
            switch (ctl.Tag.ToString())
            {
                
                case "1C":
                    cmd = @"UPDATE INP5001 A
                               SET A.NUT_JO_MAGAM_YN = :f_yn
                             WHERE A.HOSP_CODE       = :f_hosp_code
                               AND A.MAGAM_DATE      = :f_magam_date
                               ";
                    

                    break;

                case "2C":
                    cmd = @"UPDATE INP5001 A
                               SET A.NUT_JU_MAGAM_YN = :f_yn
                             WHERE A.HOSP_CODE       = :f_hosp_code
                               AND A.MAGAM_DATE      = :f_magam_date
                               ";
                    break;

                case "3C":
                    cmd = @"UPDATE INP5001 A
                               SET A.NUT_SEOK_MAGAM_YN = :f_yn
                             WHERE A.HOSP_CODE         = :f_hosp_code
                               AND A.MAGAM_DATE        = :f_magam_date
                               ";
                    break;

            }

            if (!Service.ExecuteNonQuery(cmd, bind))
                XMessageBox.Show(Service.ErrFullMsg, "");
            else
                this.btnList.PerformClick(FunctionType.Query);
        }

        private void btnDatePlusMinus_Click(object sender, EventArgs e)
        {
            Control ctl = sender as Control;
            if (ctl.Tag.ToString() == "-")
                this.dpkDeadLine.SetDataValue(DateTime.Parse(this.dpkDeadLine.GetDataValue()).AddDays(-1));
            else if (ctl.Tag.ToString() == "+")
                this.dpkDeadLine.SetDataValue(DateTime.Parse(this.dpkDeadLine.GetDataValue()).AddDays(+1));

            this.dpkDeadLine.AcceptData();
        }

        private void grdINP5001_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.btnFinal_BC.Enabled = true;
            this.btnFinal_LC.Enabled = true;
            this.btnFinal_DC.Enabled = true;

            this.btnMiddle_B.Enabled = true;
            this.btnMiddle_L.Enabled = true;
            this.btnMiddle_D.Enabled = true;

            this.btnFinal_B.Enabled = true;
            this.btnFinal_L.Enabled = true;
            this.btnFinal_D.Enabled = true;


            string cmd = @" SELECT MAX(MAGAM_SEQ) MAGAM_SEQ
                              FROM NUT2011 A
                             WHERE A.HOSP_CODE = :f_hosp_code
                               AND A.NUT_DATE  = :f_nut_date
                               AND A.BLD_GUBUN = :f_bld_gubun ";

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            
            for (int i = 1; i <= 3; i++)
            {
                switch (i)
                {
                    case 1: // B
                        bind.Add("f_nut_date", DateTime.Parse(this.grdINP5001.GetItemString(this.grdINP5001.CurrentRowNumber, "magam_date")).ToString("yyyy/MM/dd"));
                        bind.Add("f_bld_gubun", ((i % 3) + 1).ToString());
                        break;

                    case 2: // L
                        bind.Add("f_nut_date", DateTime.Parse(this.grdINP5001.GetItemString(this.grdINP5001.CurrentRowNumber, "magam_date")).ToString("yyyy/MM/dd"));
                        bind.Add("f_bld_gubun", ((i % 3) + 1).ToString());
                        break;

                    case 3: // D
                        bind.Add("f_nut_date", DateTime.Parse(this.grdINP5001.GetItemString(this.grdINP5001.CurrentRowNumber, "magam_date")).AddDays(1).ToString("yyyy/MM/dd"));
                        bind.Add("f_bld_gubun", ((i % 3) + 1).ToString());
                        break;
                }

                object obj = Service.ExecuteScalar(cmd, bind);

                if (obj.ToString() != "" && int.Parse(obj.ToString()) > 0)
                {
                    switch (i)
                    {
                        case 1: // B
                            this.btnFinal_B.Enabled = false;
                            this.btnMiddle_B.Enabled = false;
                            this.btnFinal_BC.Enabled = false;
                            break;

                        case 2: // L
                            this.btnFinal_L.Enabled = false;
                            this.btnMiddle_L.Enabled = false;
                            this.btnFinal_LC.Enabled = false;
                            break;

                        case 3: // D
                            this.btnFinal_D.Enabled = false;
                            this.btnMiddle_D.Enabled = false;
                            this.btnFinal_DC.Enabled = false;
                            break;
                    }
                }

                switch (i)
                {
                    case 1: // B
                        if (this.grdINP5001.GetItemString(this.grdINP5001.CurrentRowNumber, "nut_jo_magam_yn") != "Y")
                            this.btnFinal_BC.Enabled = false;
                        else
                        {
                            this.btnFinal_B.Enabled = false;
                            this.btnMiddle_B.Enabled = false;
                        }
                        break;

                    case 2: // L
                        if (this.grdINP5001.GetItemString(this.grdINP5001.CurrentRowNumber, "nut_ju_magam_yn") != "Y")
                            this.btnFinal_LC.Enabled = false;
                        else
                        {
                            this.btnFinal_L.Enabled = false;
                            this.btnMiddle_L.Enabled = false;
                        }
                        break;

                    case 3: // D
                        if (this.grdINP5001.GetItemString(this.grdINP5001.CurrentRowNumber, "nut_seok_magam_yn") != "Y")
                            this.btnFinal_DC.Enabled = false;
                        else
                        {
                            this.btnFinal_D.Enabled = false;
                            this.btnMiddle_D.Enabled = false;
                        }
                        break;
                }
            }
        }

        private void dpkDeadLine_TextChanged(object sender, EventArgs e)
        {
            if(TypeCheck.IsDateTime(this.dpkDeadLine.GetDataValue()))
            {
                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        private void cbxSiksaChangeYN_CheckedChanged(object sender, EventArgs e)
        {
            this.cbxSiksaChangeYN.CheckedChanged -= new System.EventHandler(this.cbxSiksaChangeYN_CheckedChanged);
            if (this.cbxSiksaChangeYN.Checked)
            {
                if (XMessageBox.Show("最終締切後、食事箋の修正が可能となります。このまま続けますか？", "確認", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    this.cbxSiksaChangeYN.Checked = false;
                }
            }
            else
            {
                if (XMessageBox.Show("最終締切後、食事箋の修正が不可となります。このまま続けますか？", "確認", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    this.cbxSiksaChangeYN.Checked = true;
                }
            }
            this.cbxSiksaChangeYN.CheckedChanged += new System.EventHandler(this.cbxSiksaChangeYN_CheckedChanged);
                
            string cmd = @"UPDATE OCS0132 A
                              SET A.CODE_NAME = :f_value
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.CODE_TYPE = 'NUT_FINAL_MAGAM_ACTION'
                              AND A.CODE      = :f_code
                            ";
            

            BindVarCollection bind = new BindVarCollection();
            bind.Add("f_hosp_code", EnvironInfo.HospCode);
            bind.Add("f_value", this.cbxSiksaChangeYN.Checked == true ? "Y" : "N");
            bind.Add("f_code", "CHANGE_YN");

            if (!Service.ExecuteNonQuery(cmd, bind))
            {
                XMessageBox.Show("保存失敗しました。やり直してください。", "確認");
            }
        }
    }
}